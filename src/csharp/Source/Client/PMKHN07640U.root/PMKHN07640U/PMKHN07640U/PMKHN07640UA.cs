//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 得意先マスタ（インポート）
// プログラム概要   : 得意先マスタ（インポート）処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉学智
// 作 成 日  2009/05/12  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 ：李亜博
// 修 正 日  2012/06/12  修正内容 ：大陽案件、Redmine#30393 
//                                  得意先マスタインポート・エクスポート 得意先掛率グループとチェックを追加
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 ：李亜博
// 修 正 日  2012/06/28  修正内容 ：内部発見バッグの対応：大小写について
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 ：李亜博
// 修 正 日  2012/06/28  修正内容 ：内部発見バッグの対応：ログファイル形について
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 李亜博
// 修 正 日  2012/06/28  修正内容 : 内部発見バッグの対応：ログファイルの名について
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 ：李亜博
// 修 正 日  2012/07/03  修正内容 ：大陽案件、Redmine#30393 
//                                  得意先マスタインポート・エクスポート 得意先掛率グループとチェックを追加の改良
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 ：李亜博
// 修 正 日  2012/07/20  修正内容 ：大陽案件、Redmine#30387 
//                                  障害一覧の指摘NO.108の対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 ：李亜博
// 修 正 日  2012/07/26  修正内容 ：大陽案件、Redmine#30387 
//                                  障害一覧の指摘NO.119の対応 メッセージの修正
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
using System.IO;// ADD  2012/06/12  李亜博 Redmine#30393

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 得意先マスタ（インポート） UIフォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 得意先マスタ（インポート） UIフォームクラス</br>
    /// <br>Programmer : 劉学智</br>
    /// <br>Date       : 2009.05.12</br>
    /// <br>Update Note: 2012/06/12 李亜博</br>
    /// <br>管理番号   : 10801804-00 大陽案件</br>
    /// <br>             Redmine#30393   得意先マスタインポート・エクスポート 得意先掛率グループとチェックを追加</br>
    /// <br>Update Note: 2012/06/28 李亜博</br>
    /// <br>管理番号   : 10801804-00 大陽案件</br>
    /// <br>             内部発見バッグの対応：大小写について</br>
    /// <br>Update Note: 2012/06/28 李亜博</br>
    /// <br>管理番号   : 10801804-00 大陽案件</br>
    /// <br>             内部発見バッグの対応：ログファイル形について</br>
    /// <br>Update Note: 2012/06/28 李亜博</br>
    /// <br>管理番号   : 10801804-00 大陽案件</br>
    /// <br>             内部発見バッグの対応：ログファイルの名について</br>
    /// <br>Update Note: 2012/07/03 李亜博</br>
    /// <br>管理番号   : 10801804-00 大陽案件</br>
    /// <br>             Redmine#30393  得意先マスタインポート・エクスポート 得意先掛率グループとチェックを追加の改良</br>
    /// <br>Update Note: 2012/07/20 李亜博</br>
    /// <br>管理番号   : 10801804-00 大陽案件</br>
    /// <br>             Redmine#30387  障害一覧の指摘NO.108の対応</br>
    /// <br>Update Note: 2012/07/26 李亜博</br>
    /// <br>管理番号   : 10801804-00 大陽案件</br>
    /// <br>             Redmine#30387  障害一覧の指摘NO.119の対応 メッセージの修正</br>
    /// </remarks>

    public partial class PMKHN07640UA : Form, IImportConditionInpType
    {
        #region ■ Constructor
        /// <summary>
        /// 得意先マスタ（インポート） UIフォームクラス
        /// </summary>
        /// <remarks>
        /// <br>Note       : 得意先マスタ（インポート） UIフォームクラスの初期化およびインスタンスの生成を行う</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.05.12</br>
        /// <br></br>
        /// </remarks>
        public PMKHN07640UA()
        {
            InitializeComponent();

            // 得意先マスタ（インポート）のアクセス
            this._customerImportAcs = new CustomerImportAcs();

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
        // 得意先マスタ（インポート）のアクセス
        private CustomerImportAcs _customerImportAcs;
        // 企業コード
        private string _enterpriseCode = "";
        // 読込件数
        private Int32 _readCnt = 0;
        // 追加件数
        private Int32 _addCnt = 0;
        // 更新件数
        private Int32 _updCnt = 0;
        //エラー更新件数
        private Int32 _logCnt = 0;// ADD  2012/06/12  李亜博 Redmine#30393
        #endregion ■ Private Member

        #region ■ Private Const
        private const int ct_AddUpdCd = 0;
        private const int ct_AddCd = 1;
        private const int ct_UpdCd = 2;
        private const string ct_AddUpdNm = "追加更新";
        private const string ct_AddNm = "追加";
        private const string ct_UpdNm = "更新";

        // ------ ADD START 2012/07/20 Redmine#30393 李亜博 for 障害一覧の指摘NO.108の対応-------->>>>
        private const int ct_CheckCd = 0;
        private const int ct_UnCheckCd = 1;
        private const string ct_CheckCdNm = "あり";
        private const string ct_UnCheckNm = "なし";
        // ------ ADD END 2012/07/20 Redmine#30393 李亜博 for 障害一覧の指摘NO.108の対応--------<<<<
        // クラスID
        private const string ct_ClassID = "PMKHN07640UA";
        // プログラムID
        private const string ct_PGID = "PMKHN07640U";
        // CSV名称
        private string _printName = "得意先マスタ（インポート）";
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
        /// <br>Programmer : 劉学智</br>
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
        /// <br>Programmer : 劉学智</br>
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
        /// <br>Programmer : 劉学智</br>
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
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        public bool ImportBeforeCheck()
        {
            //実装しない
            return true;
        }

        /// <summary>
        /// ベースにチェックエラーがあれば、フォーカスの設定
        /// </summary>
        /// <remarks>
        /// <br>Note	   : ベースにチェックエラーがあれば、フォーカスの設定を行う。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.05.12</br>
        /// <br>Update Note: 2012/06/12 李亜博</br>
        /// <br>管理番号   : 10801804-00 大陽案件</br>
        /// <br>             Redmine#30393   得意先マスタインポート・エクスポート 得意先掛率グループとチェックを追加</br>
        /// </remarks>
        public void CheckErrEvent()
        {
            this.uLabel_ReadCnt.Text = "0";
            this.uLabel_AddCnt.Text = "0";
            this.uLabel_UpdCnt.Text = "0";
            this.uLabel_LogCnt.Text = "0";// ADD  2012/06/12  李亜博 Redmine#30393
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
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.05.12</br>
        /// <br>Update Note: 2012/06/12 李亜博</br>
        /// <br>管理番号   : 10801804-00 大陽案件</br>
        /// <br>             Redmine#30393   得意先マスタインポート・エクスポート 得意先掛率グループとチェックを追加</br>
        /// <br>Update Note: 2012/06/28 李亜博</br>
        /// <br>管理番号   : 10801804-00 大陽案件</br>
        /// <br>             Redmine#30393  内部発見バッグの対応</br>
        /// <br>Update Note: 2012/07/20 李亜博</br>
        /// <br>管理番号   : 10801804-00 大陽案件</br>
        /// <br>             Redmine#30387  障害一覧の指摘NO.108の対応</br>
        /// <br>Update Note: 2012/07/26 李亜博</br>
        /// <br>管理番号   : 10801804-00 大陽案件</br>
        /// <br>             Redmine#30387  障害一覧の指摘NO.119の対応</br>
        /// </remarks>
        public int Import(object csvDataList)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // --------------- ADD START 2012/06/12 Redmine#30393 李亜博-------->>>>
            string errMessage = "";
            Control errComponent = null;
            string errorFile = "";//ADD 李亜博 2012/06/28 FOR 内部発見バッグの対応
            // 入力チェック処理
            //if (!this.ScreenInputCheck(ref errMessage, ref errComponent))// DEL  2012/06/28  李亜博 FOR 内部発見バッグの対応
            if (!this.ScreenInputCheck(ref errMessage, ref errComponent, ref errorFile))// ADD  2012/06/28  李亜博 FOR 内部発見バッグの対応
            {
                // メッセージを表示
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMessage, 0);

                // コントロールにフォーカスをセット
                if (errComponent != null)
                {
                    errComponent.Focus();
                }

                return status;
            }

            // --------------- ADD END 2012/06/12 Redmine#30393 李亜博--------<<<<

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
                this.uLabel_LogCnt.Text = "0";// ADD  2012/06/12  李亜博 Redmine#30393
                // 処理区分とCSVデータを設定する
                ExtrInfo_CustomerImportWorkTbl importWorkTbl = new ExtrInfo_CustomerImportWorkTbl();
                importWorkTbl.EnterpriseCode = this._enterpriseCode;
                importWorkTbl.ProcessKbn = (int)this.tComboEditor_ProcessKbn.Value;
                importWorkTbl.CsvDataInfoList = (List<string[]>)csvDataList;
                importWorkTbl.CheckKbn = (int)this.tComboEditor_CheckKbn.Value;// ADD  2012/07/20  李亜博 Redmine#30393 for 障害一覧の指摘NO.108の対応
                //importWorkTbl.ErrorLogFileName = this.tEdit_LogFileName.Text;// ADD  2012/06/12  李亜博 Redmine#30393// DEL  2012/06/28  李亜博 FOR 内部発見バッグの対応


                // --------------- ADD START 2012/06/28  李亜博 FOR 内部発見バッグの対応-------->>>>
                if (!string.IsNullOrEmpty(errorFile))
                {
                    importWorkTbl.ErrorLogFileName = errorFile;

                }
                else
                {
                    importWorkTbl.ErrorLogFileName = this.tEdit_LogFileName.Text;
                }
                // --------------- ADD END 2012/06/28  李亜博 FOR 内部発見バッグの対応--------<<<<
                string errMsg = string.Empty;
                // インポート処理
                // status = this._customerImportAcs.Import(importWorkTbl, out this._readCnt, out this._addCnt, out this._updCnt, out errMsg);// DEL  2012/06/12  李亜博 Redmine#30393
                status = this._customerImportAcs.Import(importWorkTbl, out this._readCnt, out this._addCnt, out this._updCnt, out this._logCnt, out errMsg);// ADD  2012/06/12  李亜博 Redmine#30393 
                // ダイアログを閉じる
                form.Close();

                switch (status)
                {
                    case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                        // 読込件数
                        this.uLabel_ReadCnt.Text = NumberFormat(this._readCnt);
                        // --------------- ADD START 2012/06/12 Redmine#30393 李亜博-------->>>>
                        // エラー件数
                        this.uLabel_LogCnt.Text = NumberFormat(this._logCnt);
                        // --------------- ADD END 2012/06/12 Redmine#30393 李亜博--------<<<<
                        if (this._addCnt > 0 || this._updCnt > 0)
                        {
                            // 追加件数
                            this.uLabel_AddCnt.Text = NumberFormat(this._addCnt);
                            // 更新件数
                            this.uLabel_UpdCnt.Text = NumberFormat(this._updCnt);
                            // --------------- ADD START 2012/06/12 Redmine#30393 李亜博-------->>>>
                            //if (this._logCnt != 0)// DEL  2012/07/26  李亜博 Redmine#30393
                            if (this._logCnt > 0)// ADD  2012/07/26  李亜博 Redmine#30393
                            {
                                //エラーありの場合、メッセージを表示する
                                // MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "インポートに失敗した行があります。\r\n" + this.tEdit_LogFileName.DataText + "を参照して下さい。", 0);// DEL  2012/06/28  李亜博 FOR 内部発見バッグの対応
                                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "インポートに失敗した行があります。\r\n" + importWorkTbl.ErrorLogFileName + "を参照して下さい。", 0);// ADD  2012/06/28  李亜博 FOR 内部発見バッグの対応
                                status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                            }
                            // --------------- ADD END 2012/06/12 Redmine#30393 李亜博--------<<<<
                        }
                        else
                        {
                            // --------------- DEL START 2012/06/12 Redmine#30393 李亜博-------->>>>
                            //// 追加件数と更新件数が全てゼロの場合、メッセージを表示する
                            //   MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "該当データ無し", 0);
                            //   status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                            // --------------- DEl END 2012/06/12 Redmine#30393 李亜博--------<<<<

                            // ------ DEL START 2012/07/26 Redmine#30393 李亜博 for 障害一覧の指摘NO.119の対応-------->>>>
                            // --------------- ADD START 2012/06/12 Redmine#30393 李亜博-------->>>>
                            //if (this._logCnt == 0)
                            //{ // 追加件数と更新件数が全てゼロの場合、メッセージを表示する
                            //    MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "該当データ無し", 0);
                            //    status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                            //}
                            //else
                            //{
                            //    //MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "インポートに失敗した行があります。\r\n" + this.tEdit_LogFileName.DataText + "を参照して下さい。", 0);// DEL  2012/06/28  李亜博 FOR 内部発見バッグの対応
                            //    MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "インポートに失敗した行があります。\r\n" + importWorkTbl.ErrorLogFileName + "を参照して下さい。", 0);// ADD  2012/06/28  李亜博 FOR 内部発見バッグの対応
                            //    status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                            //}
                            // --------------- ADD END 2012/06/12 Redmine#30393 李亜博--------<<<<
                            // ------ DEL END 2012/07/26 Redmine#30393 李亜博 for 障害一覧の指摘NO.119の対応--------<<<<

                            // ------ ADD START 2012/07/26 Redmine#30393 李亜博 for 障害一覧の指摘NO.119の対応-------->>>>
                            // エラー件数
                            this.uLabel_LogCnt.Text = NumberFormat(this._logCnt);
                            if (this._logCnt > 0)
                            {
                                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "インポートに失敗した行があります。\r\n" + importWorkTbl.ErrorLogFileName + "を参照して下さい。", 0);
                            }
                            MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, "該当データ無し", 0);
                            status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                            // ------ ADD END 2012/07/26 Redmine#30393 李亜博 for 障害一覧の指摘NO.119の対応--------<<<<

                        }
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                        MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "既に他端末により削除されています。", 0);
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                        MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "既に他端末により更新されています。", 0);
                        break;
                    default:
                        MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP, "得意先マスタのインポートに失敗しました。", (int)ConstantManagement.MethodResult.ctFNC_ERROR);
                        break;
                }
            }
            catch
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP, "得意先マスタのインポートに失敗しました。", (int)ConstantManagement.MethodResult.ctFNC_ERROR);
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
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.05.12</br>
        /// <br>Update Note: 2012/06/12 李亜博</br>
        /// <br>管理番号   : 10801804-00 大陽案件</br>
        /// <br>             Redmine#30393   得意先マスタインポート・エクスポート 得意先掛率グループとチェックを追加</br>
        /// <br>Update Note: 2012/07/20 李亜博</br>
        /// <br>管理番号   : 10801804-00 大陽案件</br>
        /// <br>             Redmine#30387  障害一覧の指摘NO.108の対応</br>
        /// </remarks>

        private int InitializeScreen(out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;

            try
            {
                this.tComboEditor_ProcessKbn.BeginUpdate();
                this.tComboEditor_CheckKbn.BeginUpdate(); // ADD  2012/07/20  李亜博 Redmine#30393 for 障害一覧の指摘NO.108の対応
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

                // ------ ADD START 2012/07/20 Redmine#30393 李亜博 for 障害一覧の指摘NO.108の対応-------->>>>
                Infragistics.Win.ValueListItem listItem3 = new Infragistics.Win.ValueListItem();
                listItem3.DataValue = ct_CheckCd;
                listItem3.DisplayText = ct_CheckCdNm;

                Infragistics.Win.ValueListItem listItem4 = new Infragistics.Win.ValueListItem();
                listItem4.DataValue = ct_UnCheckCd;
                listItem4.DisplayText = ct_UnCheckNm;

                this.tComboEditor_CheckKbn.Items.AddRange(new Infragistics.Win.ValueListItem[] { listItem3, listItem4 });

                this.tComboEditor_CheckKbn.SelectedIndex = 0;
                // ------ ADD END 2012/07/20 Redmine#30393 李亜博 for 障害一覧の指摘NO.108の対応--------<<<<

                // 「追加更新」を選択されています
                this.tComboEditor_ProcessKbn.SelectedIndex = 0;
                this.tComboEditor_ProcessKbn.Focus();

                this.uButton_TextFileGuide.ImageList = IconResourceManagement.ImageList16;
                // ﾃｷｽﾄﾌｧｲﾙ名
                this.uButton_TextFileGuide.Appearance.Image = Size16_Index.STAR1;

                // --------------- ADD START 2012/06/12 Redmine#30393 李亜博-------->>>>
                this.uButton_LogFileGuide.ImageList = IconResourceManagement.ImageList16;
                //エラーログ格納フォルダ
                this.uButton_LogFileGuide.Appearance.Image = Size16_Index.STAR1;
                // --------------- ADD END 2012/06/12 Redmine#30393 李亜博--------<<<<
                
                // 前回表示状態が保存されていれば上書き
                this.uiMemInput1.ReadMemInput();

                this.tComboEditor_ProcessKbn.EndUpdate();
                this.tComboEditor_CheckKbn.EndUpdate();// ADD  2012/07/20  李亜博 Redmine#30393 for 障害一覧の指摘NO.108の対応

                // --------------- ADD START 2012/06/12 Redmine#30393 李亜博-------->>>>
                if (string.IsNullOrEmpty(this.tEdit_LogFileName.DataText.Trim()))
                {
                    this.tEdit_LogFileName.DataText = this.tEdit_TextFileName.DataText;
                }
                // --------------- ADD END 2012/06/12 Redmine#30393 李亜博--------<<<<
                
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
        /// <br>Programmer	: 劉学智</br>
        /// <br>Date		: 2009.05.12</br>
        /// <br>Update Note : 2012/06/12 李亜博</br>
        /// <br>管理番号    : 10801804-00 大陽案件</br>
        /// <br>              Redmine#30393   得意先マスタインポート・エクスポート 得意先掛率グループとチェックを追加</br>
        /// <br>Update Note : 2012/07/20 李亜博</br>
        /// <br>管理番号    : 10801804-00 大陽案件</br>
        /// <br>              Redmine#30387  障害一覧の指摘NO.108の対応</br>
        /// </remarks>
        private void SetUIMemInputControl()
        {
            // 入力保存項目をセット
            List<Control> saveCtrAry = new List<Control>();

            saveCtrAry.Add(this.tComboEditor_ProcessKbn);
            saveCtrAry.Add(this.tEdit_TextFileName);
            saveCtrAry.Add(this.tEdit_LogFileName);// ADD  2012/06/12  李亜博 Redmine#30393
            saveCtrAry.Add(this.tComboEditor_CheckKbn);// ADD  2012/07/20  李亜博 Redmine#30393 for 障害一覧の指摘NO.108の対応
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
        /// <br>Programmer	: 劉学智</br>
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
        /// <br>Programmer : 劉学智</br>
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
        /// <br>Programmer : 劉学智</br>
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
        // --------------- ADD START 2012/06/12 Redmine#30393 李亜博-------->>>>
        #region ◆ 入力チェック処理
        /// <summary>
        /// 入力チェック処理
        /// </summary>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <param name="errComponent">エラー発生コンポーネント</param>
        /// <param name="errorFile">エラーログのパス</param>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: 画面の入力チェックを行う。</br>
        /// <br>Programmer	: 李亜博</br>
        /// <br>Date		: 2012/06/12</br>
        /// </remarks>
        //private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)// DEL  2012/06/28  李亜博 FOR 内部発見バッグの対応
        private bool ScreenInputCheck(ref string errMessage, ref Control errComponent, ref string errorFile)// ADD  2012/06/28  李亜博 FOR 内部発見バッグの対応
        {
            bool status = true;

            string fileName = tEdit_TextFileName.DataText.Trim();
            string errorLogFileName = tEdit_LogFileName.DataText.Trim();

            //パス入力しない場合
            if (errorLogFileName == string.Empty)
            {
                errMessage = "エラーログファイル名を入力してください。";
                errComponent = this.tEdit_LogFileName;
                status = false;
                return status;
            }
            //ディレクトリ存在しない場合
            int dir_index = errorLogFileName.LastIndexOf("\\");
            int file_index = errorLogFileName.LastIndexOf(".");
            if (!Directory.Exists(errorLogFileName))
            {
                //if (dir_index > 0 && file_index > 0 && errorLogFileName.Substring(file_index + 1).ToUpper().Equals("CSV"))// DEL  2012/06/28  李亜博 FOR 内部発見バッグの対応
                if (dir_index > 0 && file_index > 0) // ADD  2012/06/28  李亜博 FOR 内部発見バッグの対応
                {
                    string errorLogFileDir = string.Empty;
                    if (file_index > dir_index)
                    {
                        errorLogFileDir = errorLogFileName.Substring(0, dir_index);
                    }
                    else
                    {
                        errorLogFileDir = errorLogFileName;
                    }
                    if (!Directory.Exists(errorLogFileDir))
                    {
                        //errMessage = "エラーログファイルパスが不正です。";//DEL 2012/07/03 Redmine#30393 李亜博
                        errMessage = "CSVファイルパスが不正です。";//ADD 2012/07/03 Redmine#30393 李亜博
                        errComponent = this.tEdit_LogFileName;
                        status = false;
                        return status;
                    }
                }
                else
                {
                    //errMessage = "エラーログファイルパスが不正です。";//DEL 2012/07/03 Redmine#30393 李亜博
                    errMessage = "CSVファイルパスが不正です。";//ADD 2012/07/03 Redmine#30393 李亜博
                    errComponent = this.tEdit_LogFileName;
                    status = false;
                    return status;
                }
            }
            else
            {
                // --------------- DEL START 2012/06/28 李亜博 FOR 内部発見バッグの対応-------->>>>
                //if (dir_index + 1 == errorLogFileName.Length)
                //    this.tEdit_LogFileName.DataText = errorLogFileName + "_Error.CSV";
                //else
                //    this.tEdit_LogFileName.DataText = errorLogFileName + "\\_Error.CSV";
                // --------------- DEL END 2012/06/28 李亜博 FOR 内部発見バッグの対応--------<<<<
                // --------------- ADD START 2012/06/28 李亜博 FOR 内部発見バッグの対応-------->>>>
                if (dir_index + 1 == errorLogFileName.Length)
                {
                    errorFile = errorLogFileName + Guid.NewGuid().ToString() + ".CSV";
                }
                else
                {
                    this.tEdit_LogFileName.DataText = errorLogFileName + "\\";
                    errorFile = errorLogFileName + "\\" + Guid.NewGuid().ToString() + ".CSV";
                }
                // --------------- ADD END 2012/06/28 李亜博 FOR 内部発見バッグの対応--------<<<<
               

            }
            //同じパスの場合
            //if (fileName.Equals(errorLogFileName))// DEL  2012/06/28  李亜博 FOR 内部発見バッグの対応
            if ((fileName.ToLower()).Equals(errorLogFileName.ToLower())) // ADD  2012/06/28  李亜博 FOR 内部発見バッグの対応
            {
                errMessage = "テキストファイル名とエラーログファイル名は同一の指定は出来ません。";
                errComponent = this.tEdit_LogFileName;
                status = false;
                return status;
            }

            return true;
        }
        #endregion ◆ 入力チェック処理
        // --------------- ADD END 2012/06/12 Redmine#30393 李亜博--------<<<<
        #region ■ Control Event
        /// <summary>
        /// PMKHN07640UA_Load Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note	   : ユーザーがﾌｫｰﾑを読み込むときに発生する</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private void PMKHN07640UA_Load(object sender, EventArgs e)
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
        /// <br>Programmer  : 劉学智</br>
        /// <br>Date        : 2009.05.12</br>
        /// <br>Update Note : 2012/06/12 李亜博</br>
        /// <br>管理番号    : 10801804-00 大陽案件</br>
        /// <br>              Redmine#30393   得意先マスタインポート・エクスポート 得意先掛率グループとチェックを追加</br>
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
                    this.tEdit_LogFileName.DataText = this.GetErroLogFileNameFromTextFileName(this.tEdit_TextFileName.DataText.Trim()); // ADD  2012/06/12  李亜博 Redmine#30393
                }
            }
        }

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
        /// <br>Update Note : 2012/06/12 李亜博</br>
        /// <br>管理番号    : 10801804-00 大陽案件</br>
        /// <br>              Redmine#30393   得意先マスタインポート・エクスポート 得意先掛率グループとチェックを追加</br>
        /// <br>Update Note : 2012/07/20 李亜博</br>
        /// <br>管理番号    : 10801804-00 大陽案件</br>
        /// <br>              Redmine#30387  障害一覧の指摘NO.108の対応</br>
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
                        // ------ DEL START 2012/07/20 Redmine#30393 李亜博 for 障害一覧の指摘NO.108の対応-------->>>>
                        //// 処理区分→テキストファイル名
                        //e.NextCtrl = this.tEdit_TextFileName;
                        // ------ DEL END 2012/07/20 Redmine#30393 李亜博 for 障害一覧の指摘NO.108の対応--------<<<<
                        e.NextCtrl = this.tComboEditor_CheckKbn;// ADD  2012/07/20  李亜博 Redmine#30393 for 障害一覧の指摘NO.108の対応
                    }
                    // ------ ADD START 2012/07/20 Redmine#30393 李亜博 for 障害一覧の指摘NO.108の対応-------->>>>
                    else if (e.PrevCtrl == this.tComboEditor_CheckKbn)
                    {
                        e.NextCtrl = this.tEdit_TextFileName;
                    }
                    // ------ ADD END 2012/07/20 Redmine#30393 李亜博 for 障害一覧の指摘NO.108の対応--------<<<<
                    else if (e.PrevCtrl == this.tEdit_TextFileName)
                    {
                        // ﾃｷｽﾄﾌｧｲﾙ名→ ファイルダイアログ
                        e.NextCtrl = this.uButton_TextFileGuide;
                    }
                    else if (e.PrevCtrl == this.uButton_TextFileGuide)
                    {
                        // --------------- DEL START 2012/06/12 Redmine#30393 李亜博-------->>>>
                        // ファイルダイアログ→  倉庫(開始)
                        // e.NextCtrl = this.tComboEditor_ProcessKbn;
                        // --------------- DEL END 2012/06/12 Redmine#30393 李亜博--------<<<<
                        // --------------- ADD START 2012/06/12 Redmine#30393 李亜博-------->>>>
                        // ファイルダイアログ→  エラーログファイル名
                        e.NextCtrl = this.tEdit_LogFileName;
                        // --------------- ADD END 2012/06/12 Redmine#30393 李亜博--------<<<<
                    }
                    // --------------- ADD START 2012/06/12 Redmine#30393 李亜博-------->>>>
                    else if (e.PrevCtrl == this.tEdit_LogFileName)
                    {
                        // エラーログファイル名→  エラーログファイルダイアログ
                        e.NextCtrl = this.uButton_LogFileGuide;
                    }
                    else if (e.PrevCtrl == this.uButton_TextFileGuide)
                    {
                        // エラーログファイルダイアログ→  処理区分
                        e.NextCtrl = this.tComboEditor_ProcessKbn;
                    }
                    // --------------- ADD END 2012/06/12 Redmine#30393 李亜博--------<<<<
                }
            }
            else
            {
                // SHIFTキー押下
                if (e.Key == Keys.Tab)
                {
                    if (e.PrevCtrl == this.tComboEditor_ProcessKbn)
                    {
                        // --------------- DEL START 2012/06/12 Redmine#30393 李亜博-------->>>>
                        // 処理区分→ファイルダイアログ
                        //e.NextCtrl = this.uButton_TextFileGuide;
                        // --------------- DEl END 2012/06/12 Redmine#30393 李亜博--------<<<<
                        // --------------- ADD START 2012/06/12 Redmine#30393 李亜博-------->>>>
                        // 処理区分→エラーログファイルダイアログ
                        e.NextCtrl = this.uButton_LogFileGuide;
                        // --------------- ADD END 2012/06/12 Redmine#30393 李亜博--------<<<<
                    }
                    // --------------- ADD START 2012/06/12 Redmine#30393 李亜博-------->>>>
                    else if (e.PrevCtrl == this.uButton_LogFileGuide)
                    {
                        // エラーログファイルダイアログ→エラーログファイル名
                        e.NextCtrl = this.tEdit_LogFileName;
                    }
                    else if (e.PrevCtrl == this.tEdit_LogFileName)
                    {
                        // エラーログファイル名→ファイルダイアログ
                        e.NextCtrl = this.uButton_TextFileGuide;
                    }
                    // --------------- ADD END 2012/06/12 Redmine#30393 李亜博--------<<<<
                    else if (e.PrevCtrl == this.uButton_TextFileGuide)
                    {
                        // ファイルダイアログ→テキストファイル名
                        e.NextCtrl = this.tEdit_TextFileName;
                    }
                    else if (e.PrevCtrl == this.tEdit_TextFileName)
                    {
                        // ------ DEL START 2012/07/20 Redmine#30393 李亜博 for 障害一覧の指摘NO.108の対応-------->>>>
                        //// テキストファイル名→ 処理区分
                        //e.NextCtrl = this.tComboEditor_ProcessKbn;
                        // ------ DEL END 2012/07/20 Redmine#30393 李亜博 for 障害一覧の指摘NO.108の対応--------<<<<
                        e.NextCtrl = this.tComboEditor_CheckKbn;// ADD  2012/07/20  李亜博 Redmine#30393 for 障害一覧の指摘NO.108の対応
                    }
                    // ------ ADD START 2012/07/20 Redmine#30393 李亜博 for 障害一覧の指摘NO.108の対応-------->>>>
                    else if (e.PrevCtrl == this.tComboEditor_CheckKbn)
                    {
                        e.NextCtrl = this.tComboEditor_ProcessKbn;
                    }
                    // ------ ADD END 2012/07/20 Redmine#30393 李亜博 for 障害一覧の指摘NO.108の対応--------<<<<
                }
            }
        }
        #endregion
        // --------------- ADD START 2012/06/12 Redmine#30393 李亜博-------->>>>
        /// <summary>
        /// CSVファイル選択ボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note        : CSVファイル選択ボタンクリック時に発生します。</br> 
        /// <br>Programmer  : 李亜博</br>
        /// <br>Date        : 2012/06/12</br>
        /// </remarks>
        private void uButton_LogFileGuide_Click(object sender, EventArgs e)
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
                    this.tEdit_LogFileName.DataText = openFileDialog.FileName;
                }
            }
        }
        /// <summary>
        /// エラーログ格納フォルダ値が変更された
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note        : エラーログ格納フォルダ値が変更時に発生します。</br> 
        /// <br>Programmer  : 李亜博</br>
        /// <br>Date        : 2012/06/12</br>
        /// </remarks>
        private void tEdit_TextFileName_ValueChanged(object sender, EventArgs e)
        {
            this.tEdit_LogFileName.DataText = this.GetErroLogFileNameFromTextFileName(this.tEdit_TextFileName.DataText.Trim());
        }
        /// <summary>
        /// エラーログファイル名前取得
        /// </summary>
        /// <param name="textName">テキストファイル名前</param>
        /// <returns>エラーログファイル名前</returns>
        /// <remarks>
        /// <br>Note        : エラーログファイル名前取得するを行う。</br> 
        /// <br>Programmer  : 李亜博</br>
        /// <br>Date        : 2009/06/12</br>
        /// </remarks>
        private string GetErroLogFileNameFromTextFileName(string textName)
        {
            string errorLogFileName = this.tEdit_LogFileName.DataText.Trim();
            if (string.IsNullOrEmpty(textName.Trim())) return errorLogFileName;
            try
            {
                string textFilePath = textName.Substring(0, textName.LastIndexOf('\\'));
                string textFileName = textName.Substring(textName.LastIndexOf('\\') + 1, textName.Length - 5 - textName.LastIndexOf('\\'));
                errorLogFileName = textFilePath + "\\" + textFileName + "_Error.CSV";
                return errorLogFileName;
            }
            catch
            {
                return errorLogFileName;
            }
        }
        // --------------- ADD END 2012/06/12 Redmine#30393 李亜博--------<<<<
        #endregion ■ Control Event

       

    }
}
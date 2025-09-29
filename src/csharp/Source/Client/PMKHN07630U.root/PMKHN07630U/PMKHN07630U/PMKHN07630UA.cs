//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 商品マスタ（インポート）
// プログラム概要   : 商品マスタ（インポート）処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉学智
// 作 成 日  2009/05/12  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30517 夏野 駿希
// 修 正 日  2010/03/31  修正内容 : Mantis.15256 商品マスタインポートの対象項目設定対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : wangf
// 修 正 日  2012/06/12  修正内容 : 大陽案件、Redmine#30387 商品マスタインボートチェックの追加の対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : wangf
// 修 正 日  2012/06/27  修正内容 : 内部発見バッグの対応：大小写について
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : wangf
// 修 正 日  2012/06/28  修正内容 : 内部発見バッグの対応：エラーメッセージ不正
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : wangf
// 修 正 日  2012/06/28  修正内容 : 内部発見バッグの対応：ログファイル形について
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : wangf
// 修 正 日  2012/06/29  修正内容 : 内部発見バッグの対応：ログファイルの名について
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : wangf
// 修 正 日  2012/07/03  修正内容 : 大陽案件、Redmine#30387 商品マスタインボートチェックの追加の対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : wangf
// 修 正 日  2012/07/20  修正内容 : 大陽案件、Redmine#30387 商品マスタインボート仕様変更の対応
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
// 2010/03/31 Add >>>
using System.IO;
using Broadleaf.Application.Resources;
// 2010/03/31 Add <<<
using Broadleaf.Application.Remoting.ParamData; // ADD wangf 2012/06/12 FOR Redmine#30387

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 商品マスタ（インポート） UIフォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 商品マスタ（インポート） UIフォームクラス</br>
    /// <br>Programmer : 劉学智</br>
    /// <br>Date       : 2009.05.12</br>
    /// <br>UpdateNote : </br>
    /// <br>Update Note: 2012/07/20 wangf </br>
    /// <br>           : 10801804-00、大陽案件、Redmine#30387 商品マスタインボート仕様変更の対応</br>
    /// </remarks>
    public partial class PMKHN07630UA : Form, IImportConditionInpType
    {
        #region ■ Constructor
        /// <summary>
        /// 商品マスタ（インポート） UIフォームクラス
        /// </summary>
        /// <remarks>
        /// <br>Note       : 商品マスタ（インポート） UIフォームクラスの初期化およびインスタンスの生成を行う</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.05.12</br>
        /// <br></br>
        /// </remarks>
        public PMKHN07630UA()
        {
            InitializeComponent();

            // 商品マスタ（インポート）のアクセス
            this._goodsUImportAcs = new GoodsUImportAcs();

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
        // 商品マスタ（インポート）のアクセス
        private GoodsUImportAcs _goodsUImportAcs;
        // 企業コード
        private string _enterpriseCode = "";
        // 読込件数
        private Int32 _readCnt = 0;
        // 追加件数
        private Int32 _addCnt = 0;
        // 更新件数
        private Int32 _updCnt = 0;
        // ------------ADD wangf 2012/06/12 FOR Redmine#30387--------->>>>
        // 日付取得部品
        private DateGetAcs _dateGetAcs;
        // 締日チェック部品
        private TotalDayCalculator _totalDayCalculator;
        // ------------ADD wangf 2012/06/12 FOR Redmine#30387---------<<<<
        #endregion ■ Private Member

        #region ■ Private Const
        private const int ct_AddUpdCd = 0;
        private const int ct_AddCd = 1;
        private const int ct_UpdCd = 2;
        private const string ct_AddUpdNm = "追加更新";
        private const string ct_AddNm = "追加";
        private const string ct_UpdNm = "更新";
        // ------------ADD wangf 2012/07/20 FOR Redmine#30387--------->>>>
        private const int ct_DataCheckOn = 0;
        private const int ct_DataCheckOff = 1;
        private const string ct_DataCheckOnNm = "あり";
        private const string ct_DataCheckOffNm = "なし";
        // ------------ADD wangf 2012/07/20 FOR Redmine#30387---------<<<<
        // ------------ADD wangf 2012/06/12 FOR Redmine#30387--------->>>>
        // エラーログが出力する時、確認メッセージ
        private const string ERRORLOG_EXPORT_MSG = "インポートに失敗した行があります。\r\n{0}を参照して下さい。";
        // ------------ADD wangf 2012/06/12 FOR Redmine#30387---------<<<<
        // クラスID
        private const string ct_ClassID = "PMKHN07630UA";
        // プログラムID
        private const string ct_PGID = "PMKHN07630U";
        // CSV名称
        private string _printName = "商品マスタ（インポート）";
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
            // 実装しない
            return true;
        }

        /// <summary>
        /// ベースにチェックエラーがあれば、フォーカスの設定
        /// </summary>
        /// <remarks>
        /// <br>Note	   : ベースにチェックエラーがあれば、フォーカスの設定を行う。</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.05.12</br>
        /// <br>Update Note: 2012/06/12 wangf </br>
        /// <br>           : 10801804-00、大陽案件、Redmine#30387 商品マスタインボートチェックの追加の対応</br>
        /// </remarks>
        public void CheckErrEvent()
        {
            this.uLabel_ReadCnt.Text = "0";
            this.uLabel_AddCnt.Text = "0";
            this.uLabel_UpdCnt.Text = "0";
            this.uLabel_ErrorCnt.Text = "0"; // ADD wangf 2012/06/12 FOR Redmine#30387
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
        /// <br>Update Note: 2012/06/12 wangf </br>
        /// <br>           : 10801804-00、大陽案件、Redmine#30387 商品マスタインボートチェックの追加の対応</br>
        /// <br>Update Note: 2012/07/20 wangf </br>
        /// <br>           : 10801804-00、大陽案件、Redmine#30387 商品マスタインボート仕様変更の対応</br>
        /// </remarks>
        public int Import(object csvDataList)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            // ------------ADD wangf 2012/06/12 FOR Redmine#30387--------->>>>

            string errMessage = "";
            Control errComponent = null;

            string errorLogPath = "";//ADD wangf 2012/06/29 FOR 内部発見バッグの対応
            // 入力チェック処理
            //if (!this.ScreenInputCheck(ref errMessage, ref errComponent))//DEL wangf 2012/06/29 FOR 内部発見バッグの対応
            if (!this.ScreenInputCheck(ref errMessage, out errorLogPath, ref errComponent))//ADD wangf 2012/06/29 FOR 内部発見バッグの対応
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
            // ------------ADD wangf 2012/06/12 FOR Redmine#30387---------<<<<

            try
            {
                // 2010/03/31 Add >>>
                List<SetUpControlInfo> list = new List<SetUpControlInfo>();
                if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, "PMKHN07630U_Construction.XML")))
                {
                    list = UserSettingController.DeserializeUserSetting<List<SetUpControlInfo>>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, "PMKHN07630U_Construction.XML"));
                }
                List<int[]> setUpControlInfoList = new List<int[]>();
                int[] setUpControlItem;
                for (int i = 0; i < list.Count; i++)
                {
                    setUpControlItem = new int[2] { list[i].ItemId, list[i].UpdateDiv };
                    setUpControlInfoList.Add(setUpControlItem);
                }
                // 2010/03/31 Add <<<

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
                this.uLabel_ErrorCnt.Text = "0"; // ADD wangf 2012/06/12 FOR Redmine#30387

                // 処理区分とCSVデータを設定する
                ExtrInfo_GoodsUImportWorkTbl importWorkTbl = new ExtrInfo_GoodsUImportWorkTbl();
                importWorkTbl.EnterpriseCode = this._enterpriseCode;
                importWorkTbl.ProcessKbn = (int)this.tComboEditor_ProcessKbn.Value;
                importWorkTbl.CsvDataInfoList = (List<string[]>)csvDataList;
                importWorkTbl.SetUpInfoList = setUpControlInfoList; // 2010/03/31 Add
                // ------------ADD wangf 2012/06/12 FOR Redmine#30387--------->>>>
                //importWorkTbl.ErrorLogFileName = this.tEdit_ErrorLogFileName.DataText.Trim();//DEL wangf 2012/06/29 FOR 内部発見バッグの対応
                importWorkTbl.ErrorLogFileName = errorLogPath;//ADD wangf 2012/06/29 FOR 内部発見バッグの対応
                importWorkTbl.PriceStartDate = this.GetPriceStartDate();
                // ------------ADD wangf 2012/06/12 FOR Redmine#30387---------<<<<
                importWorkTbl.DataCheckKbn = (int)this.tComboEditor_DataCheckKbn.Value; // ADD wangf 2012/07/20 FOR Redmine#30387

                string errMsg = string.Empty;
                int errCnt = 0;  // ADD wangf 2012/06/12 FOR Redmine#30387
                // インポート処理
                //status = this._goodsUImportAcs.Import(importWorkTbl, out this._readCnt, out this._addCnt, out this._updCnt, out errMsg); // DEL wangf 2012/06/12 FOR Redmine#30387
                status = this._goodsUImportAcs.Import(importWorkTbl, out this._readCnt, out this._addCnt, out this._updCnt, out errCnt, out errMsg); // ADD wangf 2012/06/12 FOR Redmine#30387

                // ダイアログを閉じる
                form.Close();

                switch (status)
                {
                    case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                        // 読込件数
                        this.uLabel_ReadCnt.Text = NumberFormat(this._readCnt);
                        if (this._addCnt > 0 || this._updCnt > 0)
                        {
                            // 追加件数
                            this.uLabel_AddCnt.Text = NumberFormat(this._addCnt);
                            // 更新件数
                            this.uLabel_UpdCnt.Text = NumberFormat(this._updCnt);
                            // ------------ADD wangf 2012/06/12 FOR Redmine#30387--------->>>>
                            // エラー件数
                            this.uLabel_ErrorCnt.Text = NumberFormat(errCnt);
                            if (errCnt > 0)
                            {
                                //MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, string.Format(ERRORLOG_EXPORT_MSG, importWorkTbl.ErrorLogFileName), 0);// DEL wangf 2012/06/12 FOR Redmine#30387
                                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, string.Format(ERRORLOG_EXPORT_MSG, this.tEdit_ErrorLogFileName.DataText.Trim()), 0);// ADD wangf 2012/06/12 FOR Redmine#30387
                            }
                            // ------------ADD wangf 2012/06/12 FOR Redmine#30387---------<<<<
                        }
                        else
                        {
                            // ------------ADD wangf 2012/06/12 FOR Redmine#30387--------->>>>
                            // エラー件数
                            this.uLabel_ErrorCnt.Text = NumberFormat(errCnt);
                            if (errCnt > 0)
                            {
                                MsgDispProc(emErrorLevel.ERR_LEVEL_INFO, string.Format(ERRORLOG_EXPORT_MSG, importWorkTbl.ErrorLogFileName), 0);
                            }
                            // ------------ADD wangf 2012/06/12 FOR Redmine#30387---------<<<<
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
                        MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP, "商品マスタのインポートに失敗しました。", (int)ConstantManagement.MethodResult.ctFNC_ERROR);
                        break;
                }
            }
            catch
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP, "商品マスタのインポートに失敗しました。", (int)ConstantManagement.MethodResult.ctFNC_ERROR);
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
        /// <br>Update Note: 2012/06/12 wangf </br>
        /// <br>           : 10801804-00、大陽案件、Redmine#30387 商品マスタインボートチェックの追加の対応</br>
        /// <br>Update Note: 2012/07/20 wangf </br>
        /// <br>           : 10801804-00、大陽案件、Redmine#30387 商品マスタインボート仕様変更の対応</br>
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
                // ------------ADD wangf 2012/07/20 FOR Redmine#30387--------->>>>
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
                // ------------ADD wangf 2012/07/20 FOR Redmine#30387---------<<<<

                this.uButton_TextFileGuide.ImageList = IconResourceManagement.ImageList16;
                // ﾃｷｽﾄﾌｧｲﾙ名
                this.uButton_TextFileGuide.Appearance.Image = Size16_Index.STAR1;
                // ------------ADD wangf 2012/06/12 FOR Redmine#30387--------->>>>
                // エラーログファイル名
                this.uButton_ErrorLogFileGuide.ImageList = IconResourceManagement.ImageList16;
                // ﾃｷｽﾄﾌｧｲﾙ名
                this.uButton_ErrorLogFileGuide.Appearance.Image = Size16_Index.STAR1;
                // ------------ADD wangf 2012/06/12 FOR Redmine#30387---------<<<<

                // 前回表示状態が保存されていれば上書き
                this.uiMemInput1.ReadMemInput();

                this.tComboEditor_ProcessKbn.EndUpdate();
                this.tComboEditor_DataCheckKbn.EndUpdate(); // ADD wangf 2012/07/20 FOR Redmine#30387
                // ------------ADD wangf 2012/06/12 FOR Redmine#30387--------->>>>
                if (string.IsNullOrEmpty(this.tEdit_ErrorLogFileName.DataText.Trim()))
                {
                    this.tEdit_ErrorLogFileName.DataText = this.tEdit_TextFileName.DataText;
                }
                // ------------ADD wangf 2012/06/12 FOR Redmine#30387---------<<<<
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
        /// <br>Update Note : 2012/06/12 wangf </br>
        /// <br>            : 10801804-00、大陽案件、Redmine#30387 商品マスタインボートチェックの追加の対応</br>
        /// <br>Update Note : 2012/07/20 wangf </br>
        /// <br>            : 10801804-00、大陽案件、Redmine#30387 商品マスタインボート仕様変更の対応</br>
        /// </remarks>
        private void SetUIMemInputControl()
        {
            // 入力保存項目をセット
            List<Control> saveCtrAry = new List<Control>();

            saveCtrAry.Add(this.tComboEditor_ProcessKbn);
            saveCtrAry.Add(this.tEdit_TextFileName);
            saveCtrAry.Add(this.tEdit_ErrorLogFileName);　// ADD wangf 2012/06/12 FOR Redmine#30387
            saveCtrAry.Add(this.tComboEditor_DataCheckKbn);　// ADD wangf 2012/07/20 FOR Redmine#30387
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
        // ------------ADD wangf 2012/06/12 FOR Redmine#30387--------->>>>
        #region ◆ 入力チェック処理
        /// <summary>
        /// 入力チェック処理
        /// </summary>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <param name="filePath">エラーログファイルバス</param>
        /// <param name="errComponent">エラー発生コンポーネント</param>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: 画面の入力チェックを行う。</br>
        /// <br>Programmer	: wangf</br>
        /// <br>Date		: 2012/06/12</br>
        /// <br>Update Note : 2012/07/03 wangf </br>
        /// <br>            : 10801804-00、大陽案件、Redmine#30387 商品マスタインボートチェックの追加の対応</br>
        /// </remarks>
        //private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
        private bool ScreenInputCheck(ref string errMessage,out string filePath, ref Control errComponent)
        {
            bool status = true;

            string fileName = tEdit_TextFileName.DataText.Trim();
            string errorLogFileName = tEdit_ErrorLogFileName.DataText.Trim();

            filePath = tEdit_ErrorLogFileName.DataText.Trim();//ADD wangf 2012/06/29 FOR 内部発見バッグの対応
            //パス入力しない場合
            if (errorLogFileName == string.Empty)
            {
                //errMessage = "エラーログフォルダを入力してください。";//DEL wangf 2012/06/28 FOR 内部発見バッグの対応
                errMessage = "エラーログファイル名を入力してください。";//ADD wangf 2012/06/28 FOR 内部発見バッグの対応
                errComponent = this.tEdit_ErrorLogFileName;
                status = false;
                return status;
            }
            //ディレクトリ存在しない場合
            int dir_index = errorLogFileName.LastIndexOf("\\");
            int file_index = errorLogFileName.LastIndexOf(".");
            if (!Directory.Exists(errorLogFileName))
            {
                //if (dir_index > 0 && file_index > 0 && errorLogFileName.Substring(file_index + 1).ToUpper().Equals("CSV"))//DEL wangf 2012/06/28 FOR 内部発見バッグの対応
                if (dir_index > 0 && file_index > 0)//ADD wangf 2012/06/28 FOR 内部発見バッグの対応
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
                        //errMessage = "エラーログフォルダパス不正です。";//DEL wangf 2012/06/28 FOR 内部発見バッグの対応
                        //errMessage = "エラーログファイルパスが不正です。";//ADD wangf 2012/06/28 FOR 内部発見バッグの対応 // DEL wangf 2012/07/03 FOR Redmine#30387
                        errMessage = "CSVファイルパスが不正です。"; // ADD wangf 2012/07/03 FOR Redmine#30387
                        errComponent = this.tEdit_ErrorLogFileName;
                        status = false;
                        return status;
                    }
                }
                else
                {
                    //errMessage = "エラーログフォルダパス不正です。";//DEL wangf 2012/06/28 FOR 内部発見バッグの対応
                    //errMessage = "エラーログファイルパスが不正です。";//ADD wangf 2012/06/28 FOR 内部発見バッグの対応 // DEL wangf 2012/07/03 FOR Redmine#30387
                    errMessage = "CSVファイルパスが不正です。"; // ADD wangf 2012/07/03 FOR Redmine#30387
                    errComponent = this.tEdit_ErrorLogFileName;
                    status = false;
                    return status;
                }
            }
            else
            {
                if (dir_index + 1 == errorLogFileName.Length)
                    //this.tEdit_ErrorLogFileName.DataText = errorLogFileName + "_Error.CSV";//DEL wangf 2012/06/29 FOR 内部発見バッグの対応
                    filePath = errorLogFileName + Guid.NewGuid().ToString() + ".CSV";//ADD wangf 2012/06/29 FOR 内部発見バッグの対応
                else
                    //this.tEdit_ErrorLogFileName.DataText = errorLogFileName + "\\_Error.CSV";//DEL wangf 2012/06/29 FOR 内部発見バッグの対応
                    filePath = errorLogFileName + "\\" + Guid.NewGuid().ToString() + ".CSV";//ADD wangf 2012/06/29 FOR 内部発見バッグの対応
            }
            //同じパスの場合
            //if (fileName.Equals(errorLogFileName))//DEL wangf 2012/06/27 FOR 内部発見バッグの対応
            if (fileName.ToUpper().Equals(errorLogFileName.ToUpper()))//ADD wangf 2012/06/27 FOR 内部発見バッグの対応
            {
                errMessage = "テキストファイル名とエラーログファイル名は同一の指定は出来ません。";
                errComponent = this.tEdit_ErrorLogFileName;
                status = false;
                return status;
            }

            return true;
        }
        #endregion ◆ 入力チェック処理
        // ------------ADD wangf 2012/06/12 FOR Redmine#30387---------<<<<
        #endregion ■ Private Method

        #region ■ Control Event
        /// <summary>
        /// PMKHN07620UA_Load Event
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note	   : ユーザーがﾌｫｰﾑを読み込むときに発生する</br>
        /// <br>Programmer : 劉学智</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private void PMKHN07630UA_Load(object sender, EventArgs e)
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
        /// <br>Update Note : 2012/06/12 wangf </br>
        /// <br>            : 10801804-00、大陽案件、Redmine#30387 商品マスタインボートチェックの追加の対応</br>
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
                    this.tEdit_ErrorLogFileName.DataText = this.GetErroLogFileNameFromTextFileName(this.tEdit_TextFileName.DataText.Trim()); // ADD wangf 2012/06/12 FOR Redmine#30387
                }
            }
        }
        // ------------ADD wangf 2012/06/12 FOR Redmine#30387--------->>>>
        /// <summary>
        /// エラーログCSVファイル選択ボタンクリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note        : エラーログCSVファイル選択ボタンクリック時に発生します。</br> 
        /// <br>Programmer  : wangf</br>
        /// <br>Date        : 2009/06/12</br>
        /// </remarks>
        private void uButton_ErrorLogFileGuide_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                // タイトルバーの文字列
                openFileDialog.Title = "エラーログファイル選択";
                openFileDialog.RestoreDirectory = true;
                if (this.tEdit_ErrorLogFileName.Text.Trim() == string.Empty)
                {
                    openFileDialog.InitialDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                }
                else
                {
                    openFileDialog.FileName = System.IO.Path.GetFileName(this.tEdit_ErrorLogFileName.Text);
                    openFileDialog.InitialDirectory = System.IO.Path.GetDirectoryName(this.tEdit_ErrorLogFileName.Text);
                }
                //「ファイルの種類」を指定
                openFileDialog.Filter = "CSVファイル (*.CSV)|*.CSV|すべてのファイル (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    this.tEdit_ErrorLogFileName.DataText = openFileDialog.FileName;
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
        /// <br>Programmer  : wangf</br>
        /// <br>Date        : 2009/06/12</br>
        /// </remarks>
        private void tEdit_TextFileName_ValueChanged(object sender, EventArgs e)
        {
            this.tEdit_ErrorLogFileName.DataText = this.GetErroLogFileNameFromTextFileName(this.tEdit_TextFileName.DataText.Trim());
        }
        /// <summary>
        /// エラーログファイル名前取得
        /// </summary>
        /// <param name="textName">テキストファイル名前</param>
        /// <returns>エラーログファイル名前</returns>
        /// <remarks>
        /// <br>Note        : エラーログファイル名前取得するを行う。</br> 
        /// <br>Programmer  : wangf</br>
        /// <br>Date        : 2009/06/12</br>
        /// </remarks>
        private string GetErroLogFileNameFromTextFileName(string textName)
        {
            string errorLogFileName = this.tEdit_ErrorLogFileName.DataText.Trim();
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
        /// <summary>
        /// 価格開始日取得処理
        /// </summary>
        /// <returns>価格開始日</returns>
        /// <remarks>
        /// <br>Note        : 価格開始日取得処理を行う。</br> 
        /// <br>Programmer  : wangf</br>
        /// <br>Date        : 2009/06/12</br>
        /// </remarks>
        private DateTime GetPriceStartDate()
        {
            try
            {
                //--------------------------------------------------
                // 通常は、前回月次更新日の翌日
                //--------------------------------------------------
                DateTime prevTotalDay = GetHisTotalDayMonthly();
                if (prevTotalDay != DateTime.MinValue)
                {
                    // 前回月次更新日の翌日
                    return prevTotalDay.AddDays(1);
                }

                //--------------------------------------------------
                // （※新規搬入して一度も月次更新をしていないような場合）自社.期首日
                //--------------------------------------------------
                if (_dateGetAcs == null)
                {
                    _dateGetAcs = DateGetAcs.GetInstance();
                }
                else
                {
                    _dateGetAcs.ReloadCompanyInf(); // 必ず再取得する
                }
                List<DateTime> startMonthDateList;
                List<DateTime> endMonthDateList;

                CompanyInf companyInf = _dateGetAcs.GetCompanyInf();
                if (companyInf != null && companyInf.CompanyBiginDate != 0)
                {
                    _dateGetAcs.GetFinancialYearTable(out startMonthDateList, out endMonthDateList);
                    if (startMonthDateList != null && startMonthDateList.Count > 0)
                    {
                        // 期首日←最初の月の開始日
                        return startMonthDateList[0];
                    }
                }
            }
            catch
            {
            }

            // ※通常は発生しないが期首日も取得できなかった場合は既存処理と同様。
            return DateTime.Now;
        }
        /// <summary>
        /// 前回月次更新日取得処理
        /// </summary>
        /// <returns>前回月次更新日</returns>
        /// <remarks>
        /// <br>Note        : 前回月次更新日取得処理を行う。</br> 
        /// <br>Programmer  : wangf</br>
        /// <br>Date        : 2009/06/12</br>
        /// </remarks>
        private DateTime GetHisTotalDayMonthly()
        {
            if (_totalDayCalculator == null) this._totalDayCalculator = TotalDayCalculator.GetInstance();

            int status;
            DateTime prevTotalDay;

            // 締日算出モジュールのキャッシュクリア
            this._totalDayCalculator.ClearCache();

            // 買掛オプション判定
            PurchaseStatus ps;
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_StockingPayment);
            if (ps == PurchaseStatus.Contract)
            {
                // 買掛オプションあり
                // 売上月次処理日、仕入月次処理日の古い年月取得
                this._totalDayCalculator.InitializeHisMonthly();
                status = this._totalDayCalculator.GetHisTotalDayMonthly(string.Empty, out prevTotalDay);
                if (prevTotalDay == DateTime.MinValue)
                {
                    // 売上月次処理日取得
                    status = this._totalDayCalculator.GetHisTotalDayMonthlyAccRec(string.Empty, out prevTotalDay);
                    if (prevTotalDay == DateTime.MinValue)
                    {
                        // 仕入月次処理日取得
                        status = this._totalDayCalculator.GetHisTotalDayMonthlyAccPay(string.Empty, out prevTotalDay);
                    }
                }
            }
            else
            {
                // 買掛オプションなし
                // 売上月次処理日取得
                this._totalDayCalculator.InitializeHisMonthlyAccRec();
                status = this._totalDayCalculator.GetHisTotalDayMonthlyAccRec(string.Empty, out prevTotalDay);
            }

            return prevTotalDay;
        }
        // ------------ADD wangf 2012/06/12 FOR Redmine#30387---------<<<<

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
        /// <br>Update Note : 2012/07/20 wangf </br>
        /// <br>            : 10801804-00、大陽案件、Redmine#30387 商品マスタインボート仕様変更の対応</br>
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
                        /* ------------DEL wangf 2012/07/20 FOR Redmine#30387--------->>>>
                        // 処理区分→テキストファイル名
                        e.NextCtrl = this.tEdit_TextFileName;
                        // ------------DEL wangf 2012/07/20 FOR Redmine#30387---------<<<<*/
                        // ------------ADD wangf 2012/07/20 FOR Redmine#30387--------->>>>
                        // 処理区分→チェック区分
                        e.NextCtrl = this.tComboEditor_DataCheckKbn;
                        // ------------ADD wangf 2012/07/20 FOR Redmine#30387---------<<<<
                    }
                    // ------------ADD wangf 2012/07/20 FOR Redmine#30387--------->>>>
                    if (e.PrevCtrl == this.tComboEditor_DataCheckKbn)
                    {
                        // チェック区分→ﾃｷｽﾄﾌｧｲﾙ名
                        e.NextCtrl = this.tEdit_TextFileName;
                    }
                    // ------------ADD wangf 2012/07/20 FOR Redmine#30387---------<<<<
                    else if (e.PrevCtrl == this.tEdit_TextFileName)
                    {
                        // ﾃｷｽﾄﾌｧｲﾙ名→ ファイルダイアログ
                        e.NextCtrl = this.uButton_TextFileGuide;
                    }
                    else if (e.PrevCtrl == this.uButton_TextFileGuide)
                    {
                        /* ------------DEL wangf 2012/06/12 FOR Redmine#30387--------->>>>
                        // ファイルダイアログ→  倉庫(開始)
                        e.NextCtrl = this.tComboEditor_ProcessKbn;
                        // ------------DEL wangf 2012/06/12 FOR Redmine#30387---------<<<<*/
                        // ------------ADD wangf 2012/06/12 FOR Redmine#30387--------->>>>
                        // ファイルダイアログ→  エラーログファイル名
                        e.NextCtrl = this.tEdit_ErrorLogFileName;
                        // ------------ADD wangf 2012/06/12 FOR Redmine#30387---------<<<<
                    }
                    // ------------ADD wangf 2012/06/12 FOR Redmine#30387--------->>>>
                    else if (e.PrevCtrl == this.tEdit_ErrorLogFileName)
                    {
                        // エラーログファイル名→  エラーログファイルダイアログ
                        e.NextCtrl = this.uButton_ErrorLogFileGuide;
                    }
                    else if (e.PrevCtrl == this.uButton_TextFileGuide)
                    {
                        // エラーログファイルダイアログ→  処理区分
                        e.NextCtrl = this.tComboEditor_ProcessKbn;
                    }
                    // ------------ADD wangf 2012/06/12 FOR Redmine#30387---------<<<<
                }
            }
            else
            {
                // SHIFTキー押下
                if (e.Key == Keys.Tab)
                {
                    if (e.PrevCtrl == this.tComboEditor_ProcessKbn)
                    {
                        /* ------------DEL wangf 2012/06/12 FOR Redmine#30387--------->>>>
                        // 処理区分→ファイルダイアログ
                        e.NextCtrl = this.uButton_TextFileGuide;
                        // ------------DEL wangf 2012/06/12 FOR Redmine#30387---------<<<<*/
                        // ------------ADD wangf 2012/06/12 FOR Redmine#30387--------->>>>
                        // 処理区分→エラーログファイルダイアログ
                        e.NextCtrl = this.uButton_TextFileGuide;
                        // ------------ADD wangf 2012/06/12 FOR Redmine#30387---------<<<<
                    }
                    // ------------ADD wangf 2012/06/12 FOR Redmine#30387--------->>>>
                    else if (e.PrevCtrl == this.uButton_ErrorLogFileGuide)
                    {
                        // エラーログファイルダイアログ→エラーログファイル名
                        e.NextCtrl = this.tEdit_ErrorLogFileName;
                    }
                    else if (e.PrevCtrl == this.tEdit_ErrorLogFileName)
                    {
                        // エラーログファイル名→ファイルダイアログ
                        e.NextCtrl = this.uButton_TextFileGuide;
                    }
                    // ------------ADD wangf 2012/06/12 FOR Redmine#30387---------<<<<
                    else if (e.PrevCtrl == this.uButton_TextFileGuide)
                    {
                        // ファイルダイアログ→テキストファイル名
                        e.NextCtrl = this.tEdit_TextFileName;
                    }
                    else if (e.PrevCtrl == this.tEdit_TextFileName)
                    {
                        /* ------------DEL wangf 2012/07/20 FOR Redmine#30387--------->>>>
                        // テキストファイル名→ 処理区分
                        e.NextCtrl = this.tComboEditor_ProcessKbn;
                        // ------------DEL wangf 2012/07/20 FOR Redmine#30387---------<<<<*/
                        // ------------ADD wangf 2012/07/20 FOR Redmine#30387--------->>>>
                        // テキストファイル名→ チェック区分
                        e.NextCtrl = this.tComboEditor_DataCheckKbn;
                        // ------------ADD wangf 2012/07/20 FOR Redmine#30387---------<<<<
                    }
                    // ------------ADD wangf 2012/07/20 FOR Redmine#30387--------->>>>
                    else if (e.PrevCtrl == this.tComboEditor_DataCheckKbn)
                    {
                        // チェック区分→処理区分
                        e.NextCtrl = this.tComboEditor_ProcessKbn;
                    }
                    // ------------ADD wangf 2012/07/20 FOR Redmine#30387---------<<<<
                }
            }
        }
        #endregion
        #endregion ■ Control Event

    }
}
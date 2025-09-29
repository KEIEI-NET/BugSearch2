//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 拠点管理接続先設定マスタメンテナンス
// プログラム概要   : 拠点管理接続先設定マスタの登録・変更を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 作 成 日  2009/04/21  修正内容 : 新規作成
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
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using System.Net.NetworkInformation;

namespace Broadleaf.Windows.Forms
{
    /// <summary>拠点管理接続先設定フォームクラス</summary>
    /// <remarks> 
    /// <br>note			:	拠点管理接続先設定フォームクラスです。
    ///							IMasterMaintenanceSingleTypeを実装しています。</br>              
    /// <br>Programer		:	李占川</br>                            
    /// <br>Date			:	2009.04.21</br>
    /// <br></br>
    /// <br>UpdateNote      :   2009.04.21  李占川 新規</br>
    /// <br></br>
    /// </remarks>
    public partial class PMKYO09250UA : Form, IMasterMaintenanceSingleType
    {
        # region Constructor
        /// <summary>PMKYO09250UAコンストラクタ</summary>
        /// <remarks> 
        /// <br>note        :	接続先設定アクセスクラスを生成します。
        ///						フレーム画面の印刷ボタン非表示設定を行います。</br>
        /// <br>Programer   :	李占川</br>                            
        /// <br>Date        :	2009.04.21</br>                              
        /// </remarks>
        public PMKYO09250UA()
        {
            InitializeComponent();

            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._secMngConnectStAcs = new SecMngConnectStAcs();

            // 印刷可能フラグを設定します。
            // Frameの印刷ボタンの表示非表示の制御に使用します。
            _canPrint = false;
        }
        # endregion

        # region Events
        /// <summary>画面非表示イベント</summary>
        /// <remarks>
        /// 画面が非表示状態になった際に発生します。
        /// </remarks>
        public event MasterMaintenanceSingleTypeUnDisplayingEventHandler UnDisplaying;
        # endregion

        #region Private Members
        private string _enterpriseCode;
        private SecMngConnectSt _secMngConnectSt;
        private SecMngConnectStAcs _secMngConnectStAcs;

        //比較用clone
        private SecMngConnectSt _secMngConnectStClone;

        // プロパティ用
        private bool _canPrint;
        /// <summary>終了プロパティ</summary>
        /// <remarks>
        /// アセンブリを終了するか、しないかを取得又はセットします。
        /// </remarks>
        private bool _canClose;

        // メインフレームグリッド用表示項目タイトル
        private const string HTML_HEADER_TITLE = "設定項目";
        private const string HTML_HEADER_VALUE = "設定値";
        private const string HTML_UNREGISTER = "未設定";

        // 編集モード
        private const string INSERT_MODE = "新規モード";
        private const string UPDATE_MODE = "更新モード";
        private const string DELETE_MODE = "削除モード";

        private const string CONNECTPOINTDIV_1 = "データセンター";
        private const string CONNECTPOINTDIV_2 = "集計機";

        private const string MARK_DOT = ".";
        # endregion

        # region Properties
        /// <summary>印刷プロパティ</summary>
        /// <remarks>
        /// 印刷可能かどうかの設定を取得します。（false固定）
        /// </remarks>
        public bool CanPrint
        {
            get { return _canPrint; }
        }

        /// <summary>画面クローズプロパティ</summary>
        /// <remarks>
        /// 画面クローズを許可するかどうかの設定を取得または設定します。
        /// falseの場合は、画面を閉じる際、CloseではなくHide(非表示)を実行します。
        /// </remarks>
        public bool CanClose
        {
            get { return _canClose; }
            set { _canClose = value; }
        }
        # endregion

        # region Public Methods
        /// <summary>印刷処理</summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note		:	（未実装）</br>
        /// <br>Programer   :	李占川</br>                            
        /// <br>Date        :	2009.04.21</br>     
        /// </remarks>
        public int Print()
        {
            // 印刷用アセンブリをロードする（未実装）
            return 0;
        }

        /// <summary>HTMLコード取得処理</summary>
        /// <returns>HTMLコード</returns>
        /// <remarks>
        /// <br>Note		:	ビュー用のＨＴＭＬコードを取得します。</br>
        /// <br>Programer   :	李占川</br>                            
        /// <br>Date        :	2009.04.21</br>     
        /// </remarks>
        public string GetHtmlCode()
        {
            string outCode = "";

            // tHtmlGenerate部品の引数を生成する
            string[,] array = new string[4, 2];

            this.tHtmlGenerate1.Coltypes = new int[2];

            this.tHtmlGenerate1.Coltypes[0] = this.tHtmlGenerate1.ColtypeString;
            this.tHtmlGenerate1.Coltypes[1] = this.tHtmlGenerate1.ColtypeString;

            array[0, 0] = HTML_HEADER_TITLE; //「設定項目」
            array[0, 1] = HTML_HEADER_VALUE; //「設定値」

            array[1, 0] = this.uLable_ConnectPointDivTitle.Text;    //接続先
            array[2, 0] = this.uLable_ApServerIpAddressTitle.Text;    //アプリケーションサーバー
            array[3, 0] = this.uLabel_DbServerIpAddressTitle.Text;    //データベース

            // レジ番号取得
            int status = this._secMngConnectStAcs.Search(out this._secMngConnectSt, this._enterpriseCode);

            // 正常場合
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                // 接続先
                if (this._secMngConnectSt.ConnectPointDiv == 0)
                {
                    array[1, 1] = CONNECTPOINTDIV_1;
                }
                else
                {
                    array[1, 1] = CONNECTPOINTDIV_2;
                }

                if (this._secMngConnectSt.ApServerIpAddress == string.Empty)
                {
                    array[2, 1] = HTML_UNREGISTER;
                }
                else
                {
                    // アプリケーションサーバー
                    array[2, 1] = this._secMngConnectSt.ApServerIpAddress;
                }

                if (this._secMngConnectSt.DbServerIpAddress == string.Empty)
                {
                    array[3, 1] = HTML_UNREGISTER;
                }
                else
                {
                    // データベース
                    array[3, 1] = this._secMngConnectSt.DbServerIpAddress;
                }
            }
            else
            {
                array[1, 1] = CONNECTPOINTDIV_1;
                array[2, 1] = HTML_UNREGISTER;
                array[3, 1] = HTML_UNREGISTER;
            }
            this.tHtmlGenerate1.ShowArrayStringtoGridwithProperty(array, ref outCode);
            return outCode;
        }

        # endregion

        # region Control Events
        /// <summary>Form.Load イベント(PMKYO09250UA)</summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note		:	ユーザーがフォームを読み込むときに発生します。</br>
        /// <br>Programer   :	李占川</br>                            
        /// <br>Date        :	2009.04.21</br>     
        /// </remarks>
        private void PMKYO09250UA_Load(object sender, EventArgs e)
        {
            // 画面初期設定処理
            ScreenInitialSetting();

            this.tComboEditor_ConnectPointDiv.Focus();
        }

        /// <summary>Control.Click イベント(Save_Button)</summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note			:	保存ボタンコントロールがクリックされたときに
        ///							発生します。</br>
        /// <br>Programer       :	李占川</br>                            
        /// <br>Date            :	2009.04.21</br>  
        /// </remarks>
        private void Save_Button_Click(object sender, EventArgs e)
        {
            // オフライン状態チェック
            if (!CheckOnline())
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOP,
                    this.Text,
                    this.Text + "画面保存処理に失敗しました。",
                    (int)ConstantManagement.DB_Status.ctDB_OFFLINE, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                return;
            }

            SaveProc();
        }

        /// <summary>Control.Click イベント(Cancel_Button)</summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note			:	閉じるボタンコントロールがクリックされたときに
        ///							発生します。</br>
        /// <br>Programer       :	李占川</br>                            
        /// <br>Date            :	2009.04.21</br>  
        /// </remarks>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            //保存確認
            SecMngConnectSt compareSecMngConnectSt = new SecMngConnectSt();
            compareSecMngConnectSt = this._secMngConnectSt.Clone();
            //現在の画面情報を取得する
            ScreenToSecMngConnectSt(ref compareSecMngConnectSt);

            //最初に取得した画面情報と比較 
            if (!(this._secMngConnectStClone.Equals(compareSecMngConnectSt)))
            {
                //画面情報が変更されていた場合は、保存確認メッセージを表示する 
                // 保存確認
                DialogResult res = TMsgDisp.Show(
                    this, 								// 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_SAVECONFIRM, // エラーレベル
                    "PMKYO09250U", 						// アセンブリＩＤまたはクラスＩＤ
                    null, 								// 表示するメッセージ
                    0, 									// ステータス値
                    MessageBoxButtons.YesNoCancel);	// 表示するボタン
                switch (res)
                {
                    case DialogResult.Yes:
                        {
                            SaveProc();
                            return;
                        }
                    case DialogResult.No:
                        {
                            this._secMngConnectSt = this._secMngConnectStClone.Clone();
                            break;
                        }
                    default:
                        {
                            return;
                        }
                }
            }

            DialogResult dialogResult = DialogResult.Cancel;
            // 画面非表示イベント
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(dialogResult);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.Cancel;

            this._secMngConnectStClone = null;

            // CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルして
            // フォームを非表示化する。
            if (CanClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }

        /// <summary>tComboEditorのValueChangedイベント</summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note			:	ValueChangedときに発生します。</br>
        /// <br>Programer       :	李占川</br>                            
        /// <br>Date            :	2009.04.21</br>  
        /// </remarks>
        private void tComboEditor_ConnectPointDiv_ValueChanged(object sender, EventArgs e)
        {
            this.ScreenClear(false);

            this.SetIPAddEnabled(this.tComboEditor_ConnectPointDiv.SelectedIndex);
        }

        /// <summary>Form.Closing イベント(MAPOS09150UA)</summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">キャンセルできるイベントのデータを提供するクラス</param>
        /// <remarks>
        /// <br>Note			:	フォームを閉じる前に、ユーザーがフォームを閉じ
        ///							ようとしたときに発生します。</br>
        /// <br>Programer       :	李占川</br>                            
        /// <br>Date            :	2009.04.21</br>  
        /// </remarks>
        private void PMKYO09250UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._secMngConnectStClone = null;

            // CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルして
            // フォームを非表示化する。
            //（フォームの「×」をクリックされた場合の対応です。）
            if (CanClose == false)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        /// <summary>画面VisibleChangeイベント</summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note			:	VisibleChangedときに発生します。</br>
        /// <br>Programer       :	李占川</br>                            
        /// <br>Date            :	2009.04.21</br>  
        /// </remarks>
        private void PMKYO09250UA_VisibleChanged(object sender, EventArgs e)
        {
            // 自分自身が非表示になった場合は以下の処理をキャンセルする。
            if (this.Visible == false)
            {
                // メインフレームアクティブ化
                this.Owner.Activate();
                return;
            }

            // データがセットされていたら抜ける
            if (this._secMngConnectStClone != null)
            {
                return;
            }

            Initial_Timer.Enabled = true;

            this.ScreenClear(true);
        }

        /// <summary>
        /// Timer.Tick イベント(timer)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : 指定された間隔の時間が経過したときに発生します。
        ///					  この処理は、システムが提供するスレッド プール
        ///					  スレッドで実行されます。</br>
        /// <br>Programer   :	李占川</br>                            
        /// <br>Date        :	2009.04.21</br>  
        /// </remarks>
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            Initial_Timer.Enabled = false;

            // 画面再構築処理
            ScreenReconstruction();

            // 接続先チェック処理
            this.CheckConnectInfo();
        }

        /// <summary>
        ///	ValueChangedイベント(tNedit_ApServerIpAddress1)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">キャンセルできるイベントのデータを提供するクラス</param>
        /// <remarks>
        /// <br>Note		: KeyUpときに発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/04/27</br>
        /// </remarks>
        private void tNedit_ApServerIpAddress1_ValueChanged(object sender, EventArgs e)
        {
            if (tNedit_ApServerIpAddress1.DataText.Length == tNedit_ApServerIpAddress1.MaxLength)
            {
                tNedit_ApServerIpAddress2.Focus();
            }
        }

        /// <summary>
        ///	ValueChangedイベント(tNedit_ApServerIpAddress2)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">キャンセルできるイベントのデータを提供するクラス</param>
        /// <remarks>
        /// <br>Note		: KeyUpときに発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/04/27</br>
        /// </remarks>
        private void tNedit_ApServerIpAddress2_ValueChanged(object sender, EventArgs e)
        {
            if (tNedit_ApServerIpAddress2.DataText.Length == tNedit_ApServerIpAddress2.MaxLength)
            {
                tNedit_ApServerIpAddress3.Focus();
            }
        }

        /// <summary>
        ///	ValueChangedイベント(tNedit_ApServerIpAddress3)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">キャンセルできるイベントのデータを提供するクラス</param>
        /// <remarks>
        /// <br>Note		: KeyUpときに発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/04/27</br>
        /// </remarks>
        private void tNedit_ApServerIpAddress3_ValueChanged(object sender, EventArgs e)
        {
            if (tNedit_ApServerIpAddress3.DataText.Length == tNedit_ApServerIpAddress3.MaxLength)
            {
                tNedit_ApServerIpAddress4.Focus();
            }
        }

        /// <summary>
        ///	ValueChangedイベント(tNedit_DbServerIpAddress1)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">キャンセルできるイベントのデータを提供するクラス</param>
        /// <remarks>
        /// <br>Note		: KeyUpときに発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/04/27</br>
        /// </remarks>
        private void tNedit_DbServerIpAddress1_ValueChanged(object sender, EventArgs e)
        {
            if (tNedit_DbServerIpAddress1.DataText.Length == tNedit_DbServerIpAddress1.MaxLength)
            {
                tNedit_DbServerIpAddress2.Focus();
            }
        }

        /// <summary>
        ///	ValueChangedイベント(tNedit_DbServerIpAddress2)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">キャンセルできるイベントのデータを提供するクラス</param>
        /// <remarks>
        /// <br>Note		: KeyUpときに発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/04/27</br>
        /// </remarks>
        private void tNedit_DbServerIpAddress2_ValueChanged(object sender, EventArgs e)
        {
            if (tNedit_DbServerIpAddress2.DataText.Length == tNedit_DbServerIpAddress2.MaxLength)
            {
                tNedit_DbServerIpAddress3.Focus();
            }
        }

        /// <summary>
        ///	ValueChangedイベント(tNedit_DbServerIpAddress3)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">キャンセルできるイベントのデータを提供するクラス</param>
        /// <remarks>
        /// <br>Note		: KeyUpときに発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2009/04/27</br>
        /// </remarks>
        private void tNedit_DbServerIpAddress3_ValueChanged(object sender, EventArgs e)
        {
            if (tNedit_DbServerIpAddress3.DataText.Length == tNedit_DbServerIpAddress3.MaxLength)
            {
                tNedit_DbServerIpAddress4.Focus();
            }
        }
        # endregion

        # region private Methods
        /// <summary>画面初期設定処理</summary>
        /// <remarks>
        /// <br>Note		:	画面の初期設定を行います。</br>
        /// <br>Programer   :	李占川</br>                            
        /// <br>Date        :	2009.04.21</br>    
        /// </remarks>
        private void ScreenInitialSetting()
        {
            // アイコンリソース管理クラスを使用して、アイコンを表示する
            ImageList imageList24 = IconResourceManagement.ImageList24;

            this.Save_Button.ImageList = imageList24;
            this.Cancel_Button.ImageList = imageList24;

            this.Save_Button.Appearance.Image = Size24_Index.SAVE;
            this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;

            // 接続先
            this.tComboEditor_ConnectPointDiv.Items.Clear();
            this.tComboEditor_ConnectPointDiv.Items.Add(0, CONNECTPOINTDIV_1);
            this.tComboEditor_ConnectPointDiv.Items.Add(1, CONNECTPOINTDIV_2);

            // アプリケーションサーバー
            this.tNedit_ApServerIpAddress1.Clear();
            this.tNedit_ApServerIpAddress2.Clear();
            this.tNedit_ApServerIpAddress3.Clear();
            this.tNedit_ApServerIpAddress4.Clear();

            // データベース
            this.tNedit_DbServerIpAddress1.Clear();
            this.tNedit_DbServerIpAddress2.Clear();
            this.tNedit_DbServerIpAddress3.Clear();
            this.tNedit_DbServerIpAddress4.Clear();
        }

        /// <summary>画面再構築処理</summary>
        /// <remarks>
        /// <br>Note        : モードに基づいて画面を再構築します。</br>
        /// <br>Programer   :	李占川</br>                            
        /// <br>Date        :	2009.04.21</br>    
        /// </remarks>
        private void ScreenReconstruction()
        {
            Mode_Label.Text = UPDATE_MODE;

            // 画面展開処理
            this.SecMngConnectStToScreen();

            if (this._secMngConnectSt == null)
            {
                this._secMngConnectSt = new SecMngConnectSt();
            }

            //クローン作成
            this._secMngConnectStClone = this._secMngConnectSt.Clone();
            //画面情報を比較用クローンにコピーする　
            ScreenToSecMngConnectSt(ref this._secMngConnectStClone);

            this.tComboEditor_ConnectPointDiv.Focus();
        }

        /// <summary>画面クリア処理</summary>
        /// <param name="flag">True:接続先クリア. False:接続先クリアしない</param>
        /// <remarks>
        /// <br>Note		:	画面クリア処理を行います。</br>
        /// <br>Programer   :	李占川</br>                            
        /// <br>Date        :	2009.04.21</br>    
        /// </remarks>
        private void ScreenClear(bool flag)
        {
            if (flag)
            {
                this.tComboEditor_ConnectPointDiv.SelectedIndex = 0;
            }

            this.tNedit_ApServerIpAddress1.Clear();
            this.tNedit_ApServerIpAddress2.Clear();
            this.tNedit_ApServerIpAddress3.Clear();
            this.tNedit_ApServerIpAddress4.Clear();
            this.tNedit_DbServerIpAddress1.Clear();
            this.tNedit_DbServerIpAddress2.Clear();
            this.tNedit_DbServerIpAddress3.Clear();
            this.tNedit_DbServerIpAddress4.Clear();
        }

        /// <summary>画面展開処理</summary>
        /// <remarks>
        /// <br>Note		:	接続先設定クラスから画面にデータを展開します。</br>
        /// <br>Programer   :	李占川</br>                            
        /// <br>Date        :	2009.04.21</br>   
        /// </remarks>
        private void SecMngConnectStToScreen()
        {
            if (this._secMngConnectSt != null)
            {
                this.tComboEditor_ConnectPointDiv.SelectedIndex = this._secMngConnectSt.ConnectPointDiv;

                if (this._secMngConnectSt.ConnectPointDiv == 1)
                {
                    string[] apServerIpAddress = this._secMngConnectSt.ApServerIpAddress.Split('.');
                    this.tNedit_ApServerIpAddress1.SetInt(int.Parse(apServerIpAddress[0]));
                    this.tNedit_ApServerIpAddress2.SetInt(int.Parse(apServerIpAddress[1]));
                    this.tNedit_ApServerIpAddress3.SetInt(int.Parse(apServerIpAddress[2]));
                    this.tNedit_ApServerIpAddress4.SetInt(int.Parse(apServerIpAddress[3]));

                    string[] dbServerIpAddress = this._secMngConnectSt.DbServerIpAddress.Split('.');
                    this.tNedit_DbServerIpAddress1.SetInt(int.Parse(dbServerIpAddress[0]));
                    this.tNedit_DbServerIpAddress2.SetInt(int.Parse(dbServerIpAddress[1]));
                    this.tNedit_DbServerIpAddress3.SetInt(int.Parse(dbServerIpAddress[2]));
                    this.tNedit_DbServerIpAddress4.SetInt(int.Parse(dbServerIpAddress[3]));
                }
            }
        }

        /// <summary>画面情報－接続先設定クラス格納処理(保存確認メッセージ用)</summary>
        /// <param name="secMngConnectSt">接続先設定クラス</param>
        /// <remarks>
        /// <br>Note			:	画面情報から接続先設定クラスにデータを
        ///							格納します。</br>
        /// <br>Programer       :	李占川</br>                            
        /// <br>Date            :	2009.04.21</br>   
        /// </remarks>
        private void ScreenToSecMngConnectSt(ref SecMngConnectSt secMngConnectSt)
        {
            if (secMngConnectSt == null)
            {
                // 新規の場合
                secMngConnectSt = new SecMngConnectSt();
            }
            //ヘッダ部
            secMngConnectSt.EnterpriseCode = this._enterpriseCode;
            secMngConnectSt.SectionCode = "0";

            secMngConnectSt.ConnectPointDiv = this.tComboEditor_ConnectPointDiv.SelectedIndex;

            secMngConnectSt.ApServerIpAddress = GetIPAddress(1);

            secMngConnectSt.DbServerIpAddress = GetIPAddress(2);
        }

        /// <summary>保存処理(SaveProc())</summary>
        /// <remarks>
        /// <br>Note　　　  : 保存処理を行います。</br>
        /// <br>Programer   :	李占川</br>                            
        /// <br>Date        :	2009.04.21</br>    
        /// </remarks>
        private bool SaveProc()
        {
            Control control = null;
            string checkMessage = "";
            bool ret = true;

            //画面データ入力チェック処理
            ret = CheckInputData(ref control, ref checkMessage);
            if (ret == false)
            {
                // 入力チェック
                TMsgDisp.Show(
                    this, 								// 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                    "PMKYO09250U", 						// アセンブリＩＤまたはクラスＩＤ
                    checkMessage, 						// 表示するメッセージ
                    0, 									// ステータス値
                    MessageBoxButtons.OK);				// 表示するボタン

                control.Focus();
                return false;
            }

            // 画面からクラスにデータをセットします。
            ScreenToSecMngConnectSt(ref this._secMngConnectSt);

            // 拠点管理接続先設定マスタ登録
            int status = this._secMngConnectStAcs.Write(ref _secMngConnectSt);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        this._secMngConnectSt = this._secMngConnectStClone.Clone();
                        ExclusiveTransaction(status);
                        return false;
                    }
                default:
                    {
                        // 登録失敗
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                            "PMKYO09250U", 						// アセンブリＩＤまたはクラスＩＤ
                            "拠点管理接続先設定", 					// プログラム名称
                            "SavePosTerminalMg", 					// 処理名称
                            TMsgDisp.OPE_UPDATE, 				// オペレーション
                            "登録に失敗しました。", 			// 表示するメッセージ
                            status, 							// ステータス値
                            this._secMngConnectStAcs, 				// エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン

                        return false;
                    }
            }

            DialogResult dialogResult = DialogResult.OK;

            Mode_Label.Text = UPDATE_MODE;

            // 画面非表示イベント
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this._secMngConnectStClone = null;

            this.DialogResult = dialogResult;

            // CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルして
            // フォームを非表示化する。
            if (CanClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }

            return true;
        }
        /// <summary>画面チェック処理</summary>
        /// <param name="control">コントロール</param>
        /// <param name="checkMessage">メッセージ</param>
        /// <returns>true:正常　false:異常</returns>
        /// <remarks>
        /// <br>Note		:	画面入力データのチェック結果を返却します。</br>
        /// <br>Programer   :	李占川</br>                            
        /// <br>Date        :	2009.04.21</br>    
        /// </remarks>
        private bool CheckInputData(ref Control control, ref string checkMessage)
        {
            // 接続先が「集計機」場合
            if (this.tComboEditor_ConnectPointDiv.SelectedIndex == 1)
            {
                // データベースのIPアドレスが入力されていない（全て空白）場合
                if (this.tNedit_ApServerIpAddress1.DataText == string.Empty
                    && this.tNedit_ApServerIpAddress2.DataText == string.Empty
                    && this.tNedit_ApServerIpAddress3.DataText == string.Empty
                    && this.tNedit_ApServerIpAddress4.DataText == string.Empty
                    && this.tNedit_DbServerIpAddress1.DataText == string.Empty
                    && this.tNedit_DbServerIpAddress2.DataText == string.Empty
                    && this.tNedit_DbServerIpAddress3.DataText == string.Empty
                    && this.tNedit_DbServerIpAddress4.DataText == string.Empty)
                {
                    control = this.tNedit_ApServerIpAddress1;
                    checkMessage = "アプリケーションサーバー、データベースのIPアドレスを入力してください。";
                    return false;
                }

                // 接続先が「集計機」場合、データベースを入力して、アプリケーションサーバーが入力しないの場合
                if (this.tNedit_ApServerIpAddress1.DataText == string.Empty
                    || !CheckIPAddress(this.tNedit_ApServerIpAddress1.DataText))
                {
                    control = this.tNedit_ApServerIpAddress1;
                    checkMessage = "アプリケーションサーバーのIPアドレスが不正です。";
                    return false;
                }

                if (this.tNedit_ApServerIpAddress2.DataText == string.Empty
                    || !CheckIPAddress(this.tNedit_ApServerIpAddress2.DataText))
                {
                    control = this.tNedit_ApServerIpAddress2;
                    checkMessage = "アプリケーションサーバーのIPアドレスが不正です。";
                    return false;
                }

                if (this.tNedit_ApServerIpAddress3.DataText == string.Empty
                    || !CheckIPAddress(this.tNedit_ApServerIpAddress3.DataText))
                {
                    control = this.tNedit_ApServerIpAddress3;
                    checkMessage = "アプリケーションサーバーのIPアドレスが不正です。";
                    return false;
                }

                if (this.tNedit_ApServerIpAddress4.DataText == string.Empty
                    || !CheckIPAddress(this.tNedit_ApServerIpAddress4.DataText))
                {
                    control = this.tNedit_ApServerIpAddress4;
                    checkMessage = "アプリケーションサーバーのIPアドレスが不正です。";
                    return false;
                }

                // 接続先が「集計機」場合、アプリケーションサーバーを入力して、データベースが入力しないの場合
                if (this.tNedit_DbServerIpAddress1.DataText == string.Empty
                    || !CheckIPAddress(this.tNedit_DbServerIpAddress1.DataText))
                {
                    control = this.tNedit_DbServerIpAddress1;
                    checkMessage = "データベースのIPアドレスが不正です。";
                    return false;
                }

                if (this.tNedit_DbServerIpAddress2.DataText == string.Empty
                    || !CheckIPAddress(this.tNedit_DbServerIpAddress2.DataText))
                {
                    control = this.tNedit_DbServerIpAddress2;
                    checkMessage = "データベースのIPアドレスが不正です。";
                    return false;
                }

                if (this.tNedit_DbServerIpAddress3.DataText == string.Empty
                    || !CheckIPAddress(this.tNedit_DbServerIpAddress3.DataText))
                {
                    control = this.tNedit_DbServerIpAddress3;
                    checkMessage = "データベースのIPアドレスが不正です。";
                    return false;
                }

                if (this.tNedit_DbServerIpAddress4.DataText == string.Empty
                    || !CheckIPAddress(this.tNedit_DbServerIpAddress4.DataText))
                {
                    control = this.tNedit_DbServerIpAddress4;
                    checkMessage = "データベースのIPアドレスが不正です。";
                    return false;
                }
            }

            return true;
        }

        /// <summary>IPアドレスチェック処理</summary>
        /// <param name="iPAddress">IPアドレス</param>
        /// <remarks>
        /// <br>Note		:	IPアドレスチェック処理を行います。</br>
        /// <br>Programer   :	李占川</br>                            
        /// <br>Date        :	2009.04.21</br>    
        /// </remarks>
        private bool CheckIPAddress(string iPAddress)
        {
            try
            {
                int inIPAddress = Convert.ToInt32(iPAddress);
                // IPアドレス
                if (inIPAddress > 255 || inIPAddress < 0)
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>接続先チェック処理</summary>
        /// <remarks>
        /// <br>Note		:	接続先チェック処理を行います。</br>
        /// <br>Programer   :	李占川</br>                            
        /// <br>Date        :	2009.04.27</br>    
        /// </remarks>
        private void CheckConnectInfo()
        {
            // 拠点管理接続先設定マスタの接続先が「集計機」の場合
            if (this._secMngConnectSt.ConnectPointDiv == 1)
            {
                bool checkFlag = true;
                SecMngConnectSt registrySecMngConnectSt;
                // 情報の取得(レジストリ)
                int status = this._secMngConnectStAcs.GetRegistryKey(out registrySecMngConnectSt);
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    // 接続先チェック処理
                    checkFlag = this.CheckRegistAndDB(this._secMngConnectStClone, registrySecMngConnectSt);
                }
                else
                {
                    checkFlag = false;
                }

                if (!checkFlag)
                {
                    // 入力チェック
                    TMsgDisp.Show(
                        this, 								// 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_INFO,        // エラーレベル
                        "PMKYO09250U", 						// アセンブリＩＤまたはクラスＩＤ
                        "接続先情報が設定されていません。\r\n" +
                        "保存を実行して下さい。", 	        // 表示するメッセージ
                        (int)ConstantManagement.MethodResult.ctFNC_NORMAL, // ステータス値
                        MessageBoxButtons.OK);				// 表示するボタン
                }
            }
        }

        /// <summary>接続先チェック処理</summary>
        /// <param name="dBSecMngConnectSt">DB接続先</param>
        /// <param name="registSecMngConnectSt">レジストリ接続先</param>
        /// <remarks>
        /// <br>Note		:	接続先チェック処理を行います。</br>
        /// <br>Programer   :	李占川</br>                            
        /// <br>Date        :	2009.04.27</br>    
        /// </remarks>
        private bool CheckRegistAndDB(SecMngConnectSt dBSecMngConnectSt, SecMngConnectSt registSecMngConnectSt)
        {
            // レジストリとDB比較
            if (!(dBSecMngConnectSt.ApServerIpAddress.Equals(registSecMngConnectSt.ApServerIpAddress)
                && dBSecMngConnectSt.DbServerIpAddress.Equals(registSecMngConnectSt.DbServerIpAddress)))
            {
                // 不一致
                return false;
            }
            return true;
        }

        /// <summary>IPアドレス取得処理</summary>
        /// <param name="ipFlag">1:アプリケーションサーバー; 2:データベース</param>
        /// <remarks>
        /// <br>Note		:	IPアドレス取得処理を行います。</br>
        /// <br>Programer   :	李占川</br>                            
        /// <br>Date        :	2009.04.21</br>    
        /// </remarks>
        private string GetIPAddress(int ipFlag)
        {
            StringBuilder ipAddress = new StringBuilder();
            switch (ipFlag)
            {
                // アプリケーションサーバー
                case 1:
                    {
                        if (!(tNedit_ApServerIpAddress1.DataText == string.Empty
                            && tNedit_ApServerIpAddress2.DataText == string.Empty
                            && tNedit_ApServerIpAddress3.DataText == string.Empty
                            && tNedit_ApServerIpAddress4.DataText == string.Empty))
                        {
                            ipAddress.Append(tNedit_ApServerIpAddress1.GetInt().ToString());
                            ipAddress.Append(MARK_DOT);
                            ipAddress.Append(tNedit_ApServerIpAddress2.GetInt().ToString());
                            ipAddress.Append(MARK_DOT);
                            ipAddress.Append(tNedit_ApServerIpAddress3.GetInt().ToString());
                            ipAddress.Append(MARK_DOT);
                            ipAddress.Append(tNedit_ApServerIpAddress4.GetInt().ToString());
                        }

                        break;
                    }
                // データベース
                case 2:
                    {
                        if (!(tNedit_DbServerIpAddress1.DataText == string.Empty
                            && tNedit_DbServerIpAddress2.DataText == string.Empty
                            && tNedit_DbServerIpAddress3.DataText == string.Empty
                            && tNedit_DbServerIpAddress4.DataText == string.Empty))
                        {
                            ipAddress.Append(tNedit_DbServerIpAddress1.GetInt().ToString());
                            ipAddress.Append(MARK_DOT);
                            ipAddress.Append(tNedit_DbServerIpAddress2.GetInt().ToString());
                            ipAddress.Append(MARK_DOT);
                            ipAddress.Append(tNedit_DbServerIpAddress3.GetInt().ToString());
                            ipAddress.Append(MARK_DOT);
                            ipAddress.Append(tNedit_DbServerIpAddress4.GetInt().ToString());
                        }

                        break;
                    }
            }
            return ipAddress.ToString();
        }

        /// <summary>IPアドレス入力Enabled処理</summary>
        /// <param name="selectIndex">0:アプリケーションサーバー; 1:データベース:</param>
        /// <remarks>
        /// <br>Note		:	IPアドレス入力Enabled処理を行います。</br>
        /// <br>Programer   :	李占川</br>                            
        /// <br>Date        :	2009.04.21</br>    
        /// </remarks>
        private void SetIPAddEnabled(int selectIndex)
        {
            // 接続先が「データセンター」場合
            if (selectIndex == 0)
            {
                this.tNedit_ApServerIpAddress1.Enabled = false;
                this.tNedit_ApServerIpAddress2.Enabled = false;
                this.tNedit_ApServerIpAddress3.Enabled = false;
                this.tNedit_ApServerIpAddress4.Enabled = false;

                this.tNedit_DbServerIpAddress1.Enabled = false;
                this.tNedit_DbServerIpAddress2.Enabled = false;
                this.tNedit_DbServerIpAddress3.Enabled = false;
                this.tNedit_DbServerIpAddress4.Enabled = false;
            }
            else
            {
                this.tNedit_ApServerIpAddress1.Enabled = true;
                this.tNedit_ApServerIpAddress2.Enabled = true;
                this.tNedit_ApServerIpAddress3.Enabled = true;
                this.tNedit_ApServerIpAddress4.Enabled = true;

                this.tNedit_DbServerIpAddress1.Enabled = true;
                this.tNedit_DbServerIpAddress2.Enabled = true;
                this.tNedit_DbServerIpAddress3.Enabled = true;
                this.tNedit_DbServerIpAddress4.Enabled = true;
            }
        }

        /// <summary>排他処理</summary>
        /// <param name="status">チェック結果</param>
        /// <remarks>
        /// <br>Note       : 画面入力情報の不正チェックを行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.04.27</br>
        /// </remarks>
        private void ExclusiveTransaction(int status)
        {
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // 他端末更新
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                            "PMKYO09250U", 						// アセンブリＩＤまたはクラスＩＤ
                            "既に他端末より更新されています。", // 表示するメッセージ
                            0, 									// ステータス値
                            MessageBoxButtons.OK);				// 表示するボタン
                        this.Hide();
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // 他端末削除
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                            "PMKYO09250U", 						// アセンブリＩＤまたはクラスＩＤ
                            "既に他端末より削除されています。", // 表示するメッセージ
                            0, 									// ステータス値
                            MessageBoxButtons.OK);				// 表示するボタン
                        this.Hide();
                        break;
                    }
            }
            this._secMngConnectStClone = null;
        }
        # endregion

        #region ◎ オフライン状態チェック処理
        /// <summary>				
        /// ログオン時オンライン状態チェック処理				
        /// </summary>				
        /// <returns>チェック処理結果</returns>				
        public static bool CheckOnline()
        {
            if (Broadleaf.Application.Common.LoginInfoAcquisition.OnlineFlag == false)
            {
                return false;
            }
            else
            {
                // ローカルエリア接続状態によるオンライン判定				
                if (CheckRemoteOn() == false)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>				
        /// リモート接続可能判定				
        /// </summary>				
        /// <returns>判定結果</returns>				
        private static bool CheckRemoteOn()
        {
            bool isLocalAreaConnected = NetworkInterface.GetIsNetworkAvailable();

            if (isLocalAreaConnected == false)
            {
                // インターネット接続不能状態				
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion
    }
}
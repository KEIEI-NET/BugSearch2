using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Resources;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// SuperFrontmanメインメニュー
    /// </summary>
    /// <remarks>
    /// <br>Note       : SuperFrontmanメインメニュー</br>
    /// <br>Programmer : 96137　久保田　信一</br>
    /// <br>Date       : 2006.09.09</br>
    /// <br></br>
    /// <br>Update Note: リモートメンテナンス機能実装</br>
    /// <br>Programmer : 23002 上野 耕平</br>
    /// <br></br>
    /// <br>Update Note: アドオン機能実装</br>
    /// <br>Programmer : 23002 上野 耕平</br>
    /// <br>Date       : 2007.03.28</br>
    /// <br></br>
    /// <br>Update Note: ネットワーク通信テスト機能実装</br>
    /// <br>Programmer : 23002 上野 耕平</br>
    /// <br>Date       : 2008.04.04</br>
    /// <br></br>
    /// <br>Update Note: ヘルプページのURLを認証情報から取得</br>
    /// <br>Programmer : 23002 上野 耕平</br>
    /// <br>Date       : 2008.12.09</br>
    /// </remarks>
    public partial class SFNETMENUF : Form
    {

        #region 共通変数
        //アセンブリルートパス
        private string _assemblyPath = "";
        private SFNETMENU1CF _settingForm = null;
        #endregion

        #region 初期処理
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param rKeyName="args">起動ﾊﾟﾗﾒｰﾀ</param>
        public SFNETMENUF(string[] args)
        {
            InitializeComponent();

            //メニューリスト読込
            string msg = "";
            if (SFNETMENU1CF.Initialize(out msg))
            {
                //ﾛｸﾞｲﾝ従業員の情報から選択メニュー情報を取得
                SFNETMENU1CF.GetSelectMainMenuItem(Program._sfNetMenuServerInfo.EmployeeCode,this);
                //選択情報から画面を生成
                string selectXml = SFNETMENU1CF.GetXmlPath(this,SFNETMENU1CF.SelectItem.Path);
                this.sfMenuPanel.LoadSettingFromFile(selectXml);

                //クリックイベント定義(ボタンがカクテイしているもの)
                ClickIventAdd();
            }
            else
            {
                throw new Exception(msg);
            }
           
            //メニュー起動時のアドオンスタート
            AddonStart(SfNetMenuAddOnInfo.AddonRunType.MenuOpening,"");
        }

        /// <summary>
        /// 画面Load
        /// </summary>
        /// <param rKeyName="sender"></param>
        /// <param rKeyName="e"></param>
        private void SFNETMENUF_Load(object sender, EventArgs e)
        {
            //●アセンブリルートPath取得
            _assemblyPath = Path.GetDirectoryName(this.GetType().Assembly.Location);

            //●画面Text表示
            this.Text = MakeMenuText();
        }

        /// <summary>
        /// 画面破棄イベント
        /// </summary>
        /// <param rKeyName="sender"></param>
        /// <param rKeyName="e"></param>
        private void SFNETMENUF_FormClosing(object sender, FormClosingEventArgs e)
        {
            //メニュー終了時のアドオンスタート
            AddonStart(SfNetMenuAddOnInfo.AddonRunType.MenuEnding, "");

            if (_settingForm != null)
            {
                _settingForm.Dispose();
                _settingForm = null;
            }
        }
        #endregion

        #region 画面文字表示制御
        /// <summary>
        /// メニューテキスト生成
        /// </summary>
        /// <returns>メニューテキスト</returns>
        private string MakeMenuText()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(".NS MainMenu ");
            if (Program._sfNetMenuServerInfo.OnlineFlag) sb.Append("[Online] ");
            else sb.Append("[Offline] ");
            if (!Program._sfNetMenuServerInfo.LoginFlag)
            {
                sb.Append("未Login");
                this.sfMenuPanel.Controls.Find("logout", false)[0].Enabled = false;
                this.sfMenuPanel.Controls.Find("login", false)[0].Enabled = true;
            }
            else
            {
                sb.Append(Program._sfNetMenuServerInfo.EmployeeName);
                this.sfMenuPanel.Controls.Find("logout", false)[0].Enabled = true;
                this.sfMenuPanel.Controls.Find("login", false)[0].Enabled = false;
            }
            this.sfMenuPanel.Controls.Find("logout", false)[0].Refresh();
            this.sfMenuPanel.Controls.Find("login", false)[0].Refresh();
            return sb.ToString();
        }
        #endregion

        #region PGCall
        /// <summary>
        /// 各業務アプリを起動します
        /// </summary>
        /// <param rKeyName="appFullPath">業務アプリのフルパス</param>
        /// <param rKeyName="param">起動パラメータ</param>
        private void StartChildApplication(string appFullPath, string param)
        {
            //起動プログラム存在チェック
            if (System.IO.File.Exists(appFullPath) == false)
            {
                TMsgDisp.Show(this.Owner, emErrorLevel.ERR_LEVEL_EXCLAMATION, Program.pgId, "起動対象のプログラムが見つかりません", 0, MessageBoxButtons.OK);
                return;
            }

            //業務アプリに渡すパラメータ 
            string paramata = string.Format("{0} {1} {2}", Program._sfNetMenuServerInfo.AccessTicket, Program._sfNetMenuServerInfo.PMCPortNo, param);

            //0 AccessTicket  1 ポート番号
            System.Diagnostics.Process process = System.Diagnostics.Process.Start(appFullPath, paramata);       

        }

        /// <summary>
        /// アセンブリをロードします
        /// </summary>
        /// <param rKeyName="asmPath">アセンブリパス（空白時はカレント）</param>
        /// <param rKeyName="asmName">アセンブリ名称</param>
        /// <param rKeyName="className">クラス名称</param>
        /// <param rKeyName="msgFlg">メッセージ表示フラグ</param>
        /// <param rKeyName="infoStr">メッセージ表示用文字列</param>
        /// <returns>オブジェクト</returns>
        private object LoadAssembly(string asmPath, string asmName, string className, bool msgFlg, string infoStr)
        {
            //パスが空ならカレントをセット
            if ((asmPath == null) || (asmPath == "")) asmPath = Path.GetDirectoryName(this.GetType().Assembly.Location);
            //設定値チェック
            if ((asmName == null) || (asmName == "") || (className == null) || (className == ""))
            {
                if (msgFlg) TMsgDisp.Show(this.Owner, emErrorLevel.ERR_LEVEL_EXCLAMATION, Program.pgId, infoStr + "が設定されていません", 0, MessageBoxButtons.OK);
                return null;
            }
            //取得した情報を元にインスタンス化
            //アセンブリのフルパスを生成します（アプリケーション起動フォルダパス＋アセンブリ名）
            string dtPath = System.IO.Path.Combine(asmPath, asmName);

            //アセンブリの存在チェックを行います
            if (System.IO.File.Exists(dtPath))
            {
                //アセンブリをロードします
                Assembly dtAsm = Assembly.LoadFrom(dtPath);
                //クラス名からクラス情報取得
                Type dtType = dtAsm.GetType(className);
                //該当クラスをインスタンス化
                if (dtType != null)
                {
                    //取得したクラスをインスタンス化
                    object objwk = Activator.CreateInstance(dtType);
                    if ((objwk == null) && (msgFlg))
                    {
                        TMsgDisp.Show(this.Owner, emErrorLevel.ERR_LEVEL_EXCLAMATION, Program.pgId, infoStr + "が正しく設定されていません", 0, MessageBoxButtons.OK);
                    }
                    return objwk;
                }
                //クラス名に該当するものが見当たらない場合
                else
                {
                    if (msgFlg) TMsgDisp.Show(this.Owner, emErrorLevel.ERR_LEVEL_EXCLAMATION, Program.pgId, infoStr + "が正しく設定されていません", 0, MessageBoxButtons.OK);
                    return null;
                }
            }
            //アセンブリ名に該当するものが見当たらない場合
            else
            {
                if (msgFlg) TMsgDisp.Show(this.Owner, emErrorLevel.ERR_LEVEL_EXCLAMATION, Program.pgId, infoStr + "プログラムが見つかりません", 0, MessageBoxButtons.OK);
                return null;
            }
        }
        #endregion

        #region Clickイベント
        /// <summary>
        /// ログインメニューClick
        /// </summary>
        /// <param rKeyName="sender"></param>
        /// <param rKeyName="e"></param>
        private void MainMenuLogin_Click(object sender, EventArgs e)
        {
            string retMsg;
			//ログイン成功の場合
            if( Program._sfNetMenuServerInfo.EmployeeLogin(this.Owner, out retMsg) )
            {
                //ﾛｸﾞｲﾝ従業員の情報から選択メニュー情報を取得
                SFNETMENU1CF.GetSelectMainMenuItem(Program._sfNetMenuServerInfo.EmployeeCode, this);
                //選択情報から画面を生成
                string selectXml = SFNETMENU1CF.GetXmlPath(this, SFNETMENU1CF.SelectItem.Path);
                if( File.Exists(selectXml) )
                {
                    this.sfMenuPanel.LoadSettingFromFile(selectXml);
                }
                else
                {
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, Program.pgId, "メニューイメージ情報が取得出来ません", 0, MessageBoxButtons.OK);
                }
                //クリックイベント定義(ボタンがカクテイしているもの)
                ClickIventAdd();

                //画面表示制御
                this.Text = MakeMenuText();

                // --- DEL m.suzuki 2010/04/06 ---------->>>>>
                //// 2008.04.04 UENO ADD STA 
                //if( Program._sfNetMenuServerInfo.OnlineFlag )
                //{
                //    //ネットワーク通信テスト開始
                //    NetWorkTestRun();
                //}
                //// 2008.04.04 UENO ADD END 
                // --- DEL m.suzuki 2010/04/06 ----------<<<<<

                //従業員ログインOKのアドオンスタート
                AddonStart(SfNetMenuAddOnInfo.AddonRunType.EmployeeLogin, "");

            }
            else
            {
                //ログイン不可時のメッセージがある場合には表示
                if( retMsg != "" )
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, Program.pgId, retMsg, 0, MessageBoxButtons.OK);

                //従業員ログインNGのアドオンスタート
                AddonStart(SfNetMenuAddOnInfo.AddonRunType.EmployeeLoginError, "");
            }
        }

        /// <summary>
        /// ログアウトメニューClick
        /// </summary>
        /// <param rKeyName="sender"></param>
        /// <param rKeyName="e"></param>
        private void MainMenuLogOut_Click(object sender, EventArgs e)
        {
            //ログオフ
            Program._sfNetMenuServerInfo.EmployeeLogoff();
            //●画面Text表示
            this.Text = MakeMenuText();

            //従業員ログオフのアドオンスタート
            AddonStart(SfNetMenuAddOnInfo.AddonRunType.EmployeeLogOut, "");
        }

        /// <summary>
        /// 業務メニュー
        /// </summary>
        /// <param rKeyName="sender"></param>
        /// <param rKeyName="e"></param>
        private void MainMenuBusinessMenu_Click(object sender, EventArgs e)
        {
            StartChildApplication("SFNETMENU2.EXE", "");

            //業務アプリのアドオンスタート
            AddonStart(SfNetMenuAddOnInfo.AddonRunType.Sfnetmenu2Opening, "");
        }

        /// <summary>
        /// 設定
        /// </summary>
        /// <param rKeyName="sender"></param>
        /// <param rKeyName="e"></param>
        private void MainMenuSetting_Click(object sender, EventArgs e)
        {
            if (Program._sfNetMenuServerInfo.EmployeeCode == null || Program._sfNetMenuServerInfo.EmployeeCode.Length == 0)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, Program.pgId, "従業員ログインしてください", 0, MessageBoxButtons.OK);
            }
            else
            {
                if (_settingForm == null) _settingForm = new SFNETMENU1CF();
                if (_settingForm.ShowDialog(this) == DialogResult.OK)
                {
                    //ﾛｸﾞｲﾝ従業員の情報から選択メニュー情報を取得
                    SFNETMENU1CF.GetSelectMainMenuItem(Program._sfNetMenuServerInfo.EmployeeCode,this);
                    //選択情報から画面を生成
                    string selectXml = SFNETMENU1CF.GetXmlPath(this,SFNETMENU1CF.SelectItem.Path);
                    this.sfMenuPanel.LoadSettingFromFile(selectXml);

                    //クリックイベント定義(ボタンがカクテイしているもの)
                    ClickIventAdd();

                    //画面表示制御
                    MakeMenuText();

                    //設定のアドオンスタート
                    AddonStart(SfNetMenuAddOnInfo.AddonRunType.SettingOpening, "");
                }
            }
        }

        /// <summary>
        /// インフォメーション
        /// </summary>
        /// <param rKeyName="sender"></param>
        /// <param rKeyName="e"></param>
        private void MainMenuInformation_Click(object sender, EventArgs e)
        {
            //本番用
            // --- UPD m.suzuki 2010/04/06 ---------->>>>>
            ////StartChildApplication("NsBrowser.EXE", string.Format("/Ext /Tkt:1 /Fnc:1 /Lmt:2 /Mhf:1 {0}", Program._sfNetMenuServerInfo.TopPage));
            //StartChildApplication( "NsBrowser.EXE", string.Format( "/Ext /Tkt:1 /Fnc:0 /Lmt:2 /Mhf:1 /BrwsTyp:1 {0}", Program._sfNetMenuServerInfo.TopPage ) );
            StartChildApplication( "NsBrowser.EXE", string.Format( "/Ext /Tkt:1 /Fnc:0 /Lmt:2 /Mhf:1 /BrwsTyp:1 /Prdct:{1} {0}/{1}/{2}", Program._sfNetMenuServerInfo.TopPage, ConstantManagement_SF_PRO.ProductCode, "info/index.html" ) );
            // --- UPD m.suzuki 2010/04/06 ----------<<<<<

            //品管テスト用
            //StartChildApplication("NsBrowser.EXE", string.Format("/Ext /Tkt:1 /Fnc:0 /Lmt:2 /Mhf:1 /BrwsTyp:1 {0}", "http://10.20.150.130/TOPWEB/index.html"));
            //インフォメーションのアドオンスタート
            AddonStart(SfNetMenuAddOnInfo.AddonRunType.InformationOpening, "");
        }

        /// <summary>
        /// ヘルプ
        /// </summary>
        /// <param rKeyName="sender"></param>
        /// <param rKeyName="e"></param>
        private void MainMenuHelp_Click(object sender, EventArgs e)
        {
            //本番WEB
            //StartChildApplication("NsBrowser.EXE", string.Format("/Ext /Fnc:0 /Lmt:2 /Mhf:1 /BrwsTyp:1 {0}", "http://www35.superfrontman.net/onlinehelp/guide/index.html"));
            //本番ﾃｽﾄ用
            //StartChildApplication("NsBrowser.EXE", string.Format("/Ext /Fnc:0 /Lmt:2 /Mhf:1 /BrwsTyp:1 {0}", "http://www40.superfrontman.net/onlinehelp/help/bkns/index.html"));
            //BL研修用サーバ
            //StartChildApplication("NsBrowser.EXE", string.Format("/Ext /Fnc:0 /Lmt:2 /Mhf:1 /BrwsTyp:1 {0}", "http://BL/onlinehelp/help/bkns/index.html"));
            
            //品質管理用
            //StartChildApplication("NsBrowser.EXE", string.Format("/Ext /Fnc:0 /Lmt:2 /Mhf:1 /BrwsTyp:1 {0}", "http://10.0.41.111/online_help/guide/index.html"));
            //TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, Program.pgId, "ヘルプは現在開けません。もうしばらくお待ちください。", 0, MessageBoxButtons.OK);

            // --- UPD m.suzuki 2010/04/06 ---------->>>>>
            //// 2008.12.09 UENO ADD STA
            ////認証情報から取得したURL
            //StartChildApplication("NsBrowser.EXE", string.Format("/Ext /Fnc:0 /Lmt:2 /Mhf:1 /BrwsTyp:1 {0}", Program._sfNetMenuServerInfo.HelpPage));
            //// 2008.12.09 UENO ADD END
            this.StartChildApplication( "NsBrowser.EXE", string.Format( "/Ext /Fnc:0 /Lmt:2 /Mhf:1 /BrwsTyp:1 /Prdct:{1} {0}/{1}/{2}", Program._sfNetMenuServerInfo.TopPage, ConstantManagement_SF_PRO.ProductCode, "onlinehelp/index.html" ) );
            // --- UPD m.suzuki 2010/04/06 ----------<<<<<

            //ヘルプのアドオンスタート
            AddonStart(SfNetMenuAddOnInfo.AddonRunType.HelpOpening, "");
        }

        /// <summary>
        /// リモートメンテナンス
        /// </summary>
        /// <param rKeyName="sender"></param>
        /// <param rKeyName="e"></param>
        private void MainMenuRemoteMaintenance_Click(object sender, EventArgs e)
        {
            if( Program._sfNetMenuServerInfo.EmployeeCode == null || Program._sfNetMenuServerInfo.EmployeeCode.Length == 0 )
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, Program.pgId, "従業員ログインしてください", 0, MessageBoxButtons.OK);
            }
            else
            {
                //リモートメンテナンスオプションチェック
                //契約またはトライアル契約している場合はリモートメンテナンス起動(メニューサーバー情報クラスにてチェックを行う）
                if( (int)Program._sfNetMenuServerInfo.SoftwarePurchasedCheckForUSB(Broadleaf.Application.Resources.ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_RemoteMaintenance) > 0 )
                {
                    //起動プログラムパス
                    string appFullPath = "RemoteMaintenance\\NTRsupport.exe";

                    //起動プログラム存在チェック
                    if( System.IO.File.Exists(appFullPath) == false )
                    {
                        TMsgDisp.Show(this.Owner, emErrorLevel.ERR_LEVEL_EXCLAMATION, Program.pgId, "起動対象のプログラムが見つかりません", 0, MessageBoxButtons.OK);
                        return;
                    }

                    //リモートメンテンナス（インキエロ）起動
                    System.Diagnostics.Process process = System.Diagnostics.Process.Start(appFullPath);

                    //設定のアドオンスタート
                    AddonStart(SfNetMenuAddOnInfo.AddonRunType.RemoteMaintenanceOpening, "");
                }
                else
                {
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, Program.pgId, "未契約ソフトウェアです", 0, MessageBoxButtons.OK);
                }
            }
        }

        /// <summary>
        /// クリックイベント追加
        /// </summary>
        private void ClickIventAdd()
        {
            //クリックイベント定義(ボタンがカクテイしているもの)
            this.sfMenuPanel.Controls.Find("logout", false)[0].Click += new EventHandler(MainMenuLogOut_Click);
            this.sfMenuPanel.Controls.Find("login", false)[0].Click += new EventHandler(MainMenuLogin_Click);
            this.sfMenuPanel.Controls.Find("businessMenu", false)[0].Click += new EventHandler(MainMenuBusinessMenu_Click);
            this.sfMenuPanel.Controls.Find("setting", false)[0].Click += new EventHandler(MainMenuSetting_Click);
            this.sfMenuPanel.Controls.Find("information", false)[0].Click += new EventHandler(MainMenuInformation_Click);
            this.sfMenuPanel.Controls.Find("help", false)[0].Click += new EventHandler(MainMenuHelp_Click);
            this.sfMenuPanel.Controls.Find("remoteMaintenance", false)[0].Click += new EventHandler(MainMenuRemoteMaintenance_Click);
            
        }


        
        #endregion

        #region アドオン起動
        /// <summary>
        /// アドオンを起動
        /// </summary>
        /// <param rKeyName="addonRunType">アドオンの実行タイミング</param>
        /// <param rKeyName="param">起動パラメータ</param>
        private void AddonStart(Broadleaf.Windows.Forms.SfNetMenuAddOnInfo.AddonRunType addonRunType, string param)
        {
            //「SfNetMenuServerInfo」側で「SfNetMenuAddOnInfo」をキャッシュしています。
            SfNetMenuAddOnInfo sfNetMenuAddOnInfo = Program._sfNetMenuServerInfo.GetSfNetMenuAddOnInfo("MenuSettings\\AppSettingData\\SFNETMENU_Config.dat", new string[] { "SFNETMENU", "Addon", "Key" });

            //起動するアドオンのファイルパス
            List<string> addonFullPathList = sfNetMenuAddOnInfo.GetAddonList(addonRunType);
            if( addonFullPathList == null )
            {
                return;
            }

            //アプリに渡すパラメータ 
            string paramata = string.Format("{0} {1} {2}", Program._sfNetMenuServerInfo.AccessTicket, Program._sfNetMenuServerInfo.PMCPortNo, param);

            for( int ix = 0; ix < addonFullPathList.Count; ix++ )
            {
                //起動プログラム存在チェック
                if( System.IO.File.Exists(addonFullPathList[ix]) )
                {
                    try
                    {
                        //0 AccessTicket  1 ポート番号
                        System.Diagnostics.Process process = System.Diagnostics.Process.Start(addonFullPathList[ix], paramata);
                    }
                    catch(Exception ex)
                    {
                        TMsgDisp.Show(this.Owner, emErrorLevel.ERR_LEVEL_EXCLAMATION, Program.pgId, addonFullPathList[ix] + " の起動に失敗しました。", 0, MessageBoxButtons.OK);
                    }
                }
            }
        }
        #endregion

        // --- DEL m.suzuki 2010/04/06 ---------->>>>>
        #region ネットワーク通信テスト
        ///// <summary>
        ///// ネットワーク通信テスト
        ///// </summary>
        //private void NetWorkTestRun()
        //{
        //    NetWorkTest netWorkTest = new NetWorkTest();
        //    //
        //    //ネットワーク通信テスト用にスレッド生成
        //    System.Threading.Thread networkTestThread = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(netWorkTest.TestStart));
        //    networkTestThread.IsBackground = false;

        //    //パラメータ（企業コード、製品名称、アクセスチケット）
        //    object para = new object[] { 
        //        Program._sfNetMenuServerInfo.CompanyAuthInfoWork.EnterpriseInfoWork.EnterpriseCode,
        //        Program._sfNetMenuServerInfo.ProductCode,
        //        Program._sfNetMenuServerInfo.AccessTicket};

        //    //別スレッドでネットワーク通信テストを行う。
        //    networkTestThread.Start(para);
        //}
        #endregion
        // --- DEL m.suzuki 2010/04/06 ----------<<<<<
    }
}
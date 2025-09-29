using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting;
using Broadleaf.Library.Runtime.InteropServices;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// public class name:   EmployeeLoginForm2AF
    /// <summary>
    ///                      従業員ログイン画面(felica対応版)
    ///                      SFCMN00655Uをベースとして作成
    /// </summary>
    /// <remarks>
    /// <br>note             :   従業員ログイン画面</br>
    /// <br>Programmer       :   23002　上野　耕平</br>
    /// <br>Date             :   2008.11.13</br>
    /// <br>Update Note      :    
    ///                      :   2009.01.26 上野　耕平
    ///                      :   ・手入力ログイン後、ポーリングが止まらない現象の修正</br>
    /// <br></br>
    /// <br>Update Note: 2010.02.18  22018 鈴木 正臣</br>
    /// <br>           : PM.NS対応</br>
    /// <br>           : 　・NetAdvantageバージョンアップ対応</br>
    /// <br>           : 　・アイコン変更(SF→NS)</br>
    /// </remarks>
    public partial class EmployeeLogin2FormAF :Form
    {
        #region プライベートメンバ
        //企業ログイン情報格納用
        private CompanyAuthInfoWork _companyAuthInfoWork = null;
        //従業員ログインパラメータ情報格納用
        private EmployeeAuthInfoWork _paraEmployeeAuthInfoWork = null;
        //従業員ログイン結果情報格納用
        private EmployeeAuthInfoWork _employeeAuthInfoWork = null;
        //従業員ログインリモートオブジェクトインターフェース
        private IEmployeeLogin2DB _iEmployeeLogin2DB = null;

        //アクセスチケットパラメータ格納用
        private string _accessTicket = null;
        //従業員ログインドメイン文字列
        private string _domainStr = null;
        //オンラインフラグ
        private bool _onlineFlag = false;

        //プログラムID
        private const string pgId = "SFCMN03510U";
        
        //Felica対応表示用タイマー
        private Timer timer_FelicaInfo;
        //フェリカアクセスクラス
        static private FelicaAcs _felicaAcs = null;
        //フェリカチェック間隔
        private int felicaInterval = 400;
        //フェリカチェック回数 0無制限
        private int felicaRetry = 0;

        
        //ログイン処理排他オブジェクト
        private object _loginObject = new object();
        #endregion

        #region コンストラクタ
        /// <summary>
        /// 従業員ログイン画面クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 初期処理：Owner設定</br>
        /// <br>Programmer : 23002 上野　耕平</br>
        /// <br>Date       : 2008.11.13</br>
        /// </remarks>		
        public EmployeeLogin2FormAF()
        {
            InitializeComponent();
        }
        #endregion

        #region パブリックメソッド
        /// <summary>
        /// 従業員ログイン開始
        /// </summary>
        /// <param name="owner">ログイン画面Owner</param>
        /// <param name="accessTicket">アクセスチケット</param>
        /// <param name="domainStr">従業員ログインドメイン文字列</param>
        /// <param name="companyAuthInfoWork">企業ログイン情報</param>
        /// <param name="employeeAuthInfoWork">従業員ログイン情報</param>
        /// <returns>STATUS</returns>
        public int ShowDialog(IWin32Window owner, string accessTicket, string domainStr, CompanyAuthInfoWork companyAuthInfoWork, ref EmployeeAuthInfoWork employeeAuthInfoWork)
        {
            //戻り値を該当無しで初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            //従業員ログイン情報パラメータからオンラインフラグ判定
            if( employeeAuthInfoWork == null )
                _onlineFlag = true;
            else
                _onlineFlag = false;

            //企業ログイン情報取得
            _companyAuthInfoWork = companyAuthInfoWork;
            //パラメータ従業員ログインクラス初期化
            _paraEmployeeAuthInfoWork = employeeAuthInfoWork;

            if( accessTicket == null || accessTicket == "" || companyAuthInfoWork == null || companyAuthInfoWork.EnterpriseInfoWork == null )
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, pgId, "企業認証されていないか、企業認証が無効になっています。再度企業認証を行ってください。", 0, MessageBoxButtons.OK);
                return status;
            }

            //ワーククラス初期化
            _employeeAuthInfoWork = null;

            //従業員ログインインターフェース初期化
            _iEmployeeLogin2DB = null;

            //アクセスチケット保存
            _accessTicket = accessTicket;
            //ドメイン文字列保存
            _domainStr = domainStr;

            //ステータスバーのメッセージをセットします。
            ultraStatusBar_EmployeeLogin.Panels["Info"].Text = "カードをリーダーにかざすか、ログイン情報を入力して下さい";
            ultraStatusBar_EmployeeLogin.Panels["Info"].Enabled = true;

            //フェリカポーリングストップ（念のため）
            FelicaStopPolling();

            //Felicaアクセスクラス初期化
            //if(_onlineFlag && _felicaAcs == null )
            if( _onlineFlag )
            {
                _felicaAcs = new FelicaAcs();

                // フェリカ初期化処理
                if( _felicaAcs.InitializeLibrary() )
                {
                    // コールバックデリゲートに登録
                    _felicaAcs.CallBackDelegate = new FelicaAcs.PollingCallBackDelegate(PollingSuccessCallBack);

                    // フェリカリーダーオープン処理
                    if( !_felicaAcs.OpenReaderWriterAuto() )
                    {
                        FelicaDispose();
                        ultraStatusBar_EmployeeLogin.Panels["Info"].Text = "従業員ログイン情報を入力して下さい";
                    }
                }
                else
                {
                    FelicaDispose();
                    ultraStatusBar_EmployeeLogin.Panels["Info"].Text = "従業員ログイン情報を入力して下さい";
                }
            }


            //画面表示
            this.ShowDialog(owner);

            //企業・従業員ログイン情報があれば取得戻り値を戻す
            if( _employeeAuthInfoWork != null )
            {
                //ログイン情報設定
                employeeAuthInfoWork = _employeeAuthInfoWork;
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            return status;
        }
        #endregion

        #region プライベートメソッド
        /// <summary>
        /// 従業員ログイン処理（実行部）
        /// </summary>
        /// <param name="felicaLogin"></param>
        /// <returns></returns>
        private bool LoginProc(string loginID, string loginPassword, bool felicaMode)
        {
            bool result = false;
            //●ログイン情報取得
            //timer_FelicaInfo.Stop();
            FelicaStopPolling();
            ultraStatusBar_EmployeeLogin.Panels["Info"].Enabled = true;
            ultraStatusBar_EmployeeLogin.Panels["Info"].Text = "ログイン処理中...";
            ultraStatusBar_EmployeeLogin.Refresh();
            ultraStatusBar_EmployeeLogin.Update();

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            object retEmpObj = null;
            string retMsg = "";

            //オンライン時
            if( _onlineFlag )
            {
                if ( _iEmployeeLogin2DB == null )
                    _iEmployeeLogin2DB = MediationEmployeeLogin2DB.GetEmployeeLogin2DB(_domainStr);
                //入力内容設定
                object paraCmpObj = (object)_companyAuthInfoWork;
                status = _iEmployeeLogin2DB.Login(_accessTicket, loginID.Trim(), loginPassword.Trim(), felicaMode, ref paraCmpObj, out retEmpObj, out retMsg);
            }
            //オフライン時
            else
            {
                if( _paraEmployeeAuthInfoWork.EmployeeWork.LoginPassword == loginPassword.Trim() )
                {
                    retEmpObj = _paraEmployeeAuthInfoWork;
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    retMsg = "";
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_EOF;
                    retMsg = "パスワードが異なります。再度入力してください。CapsのOn/Off等確認してください。";
                }
            }

            if( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            {
                //●戻り値設定
                _employeeAuthInfoWork = retEmpObj as EmployeeAuthInfoWork;
                if( _employeeAuthInfoWork == null )
                {
                    TMsgDisp.Show(this.Owner, emErrorLevel.ERR_LEVEL_INFO, pgId, "従業員ログイン認証結果が取得できません。再度ログインしてください", 0, MessageBoxButtons.OK);
                }
                else
                {
                    ////●画面終了
                    //this.Close();
                    //return;
                    result = true;
                    return result;
                }
            }
            else if( status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND )
            {
                TMsgDisp.Show(this.Owner, emErrorLevel.ERR_LEVEL_INFO, pgId, retMsg, 0, MessageBoxButtons.OK);
                tEdit_LoginId.Text = "";
                tEdit_LoginPassword.Text = "";
                tEdit_LoginId.Focus();
            }
            else if( status == (int)ConstantManagement.DB_Status.ctDB_EOF )
            {
                TMsgDisp.Show(this.Owner, emErrorLevel.ERR_LEVEL_INFO, pgId, retMsg, 0, MessageBoxButtons.OK);
                tEdit_LoginPassword.Text = "";
                tEdit_LoginPassword.Focus();
            }
            else if( status == (int)ConstantManagement.DB_Status.ctDB_ERROR )
            {
                if( retMsg == null || retMsg == "" )
                {
                    TMsgDisp.Show(this.Owner, emErrorLevel.ERR_LEVEL_STOPDISP, pgId, "従業員認証サーバーでエラーが発生しました。認証出来ません。", 0, MessageBoxButtons.OK);
                }
                else
                {
                    TMsgDisp.Show(this.Owner, emErrorLevel.ERR_LEVEL_STOPDISP, pgId, string.Format("{0}[{1}]", "従業員認証サーバーでエラーが発生しました。", retMsg), 0, MessageBoxButtons.OK);
                }
            }

            if( _felicaAcs != null)
            {
                FelicaStartPolling();
                ultraStatusBar_EmployeeLogin.Panels["Info"].Text = "カードをリーダーにかざすか、ログイン情報を入力して下さい";
            }
            else
            {
                ultraStatusBar_EmployeeLogin.Panels["Info"].Text = "従業員ログイン情報を入力して下さい";
            }
            
           
            return result;
        }
        #endregion

        #region コントロールイベント
        /// <summary>
        /// フォーカスコントロール処理
        /// </summary>
        /// <param name="sender">イベント発生オブジェクト</param>
        /// <param name="e">イベント内容</param>
        private void tArrowKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            //イベント内容/移動元コントロールが無ければ終了
            if( e == null || e.PrevCtrl == null )
                return;

            int prevTag = System.Convert.ToInt32(e.PrevCtrl.Tag);
            switch( prevTag )
            {
                case 1:
                    if( e.Key == System.Windows.Forms.Keys.Return || e.Key == System.Windows.Forms.Keys.Tab )
                        e.NextCtrl = tEdit_LoginPassword;
                    break;
                case 2:
                    if( e.Key == System.Windows.Forms.Keys.Return || e.Key == System.Windows.Forms.Keys.Tab )
                        e.NextCtrl = ultraButton_OK;
                    break;
                case 100:
                    if( e.Key == System.Windows.Forms.Keys.Tab )
                        e.NextCtrl = ultraButton_CANCEL;
                    else if( e.Key == System.Windows.Forms.Keys.Return )
                    {
                        e.NextCtrl = e.PrevCtrl;
                        ultraButton_OK_Click(null, null);//OKボタン押下
                    }
                    break;
                case 200:
                    if( e.Key == System.Windows.Forms.Keys.Tab )
                        e.NextCtrl = tEdit_LoginId;
                    else if( e.Key == System.Windows.Forms.Keys.Return )
                    {
                        e.NextCtrl = e.PrevCtrl;
                        ultraButton_CANCEL_Click(null, null);//OKボタン押下
                    }
                    break;
            }


        }

        /// <summary>
        /// CANCELボタンClickイベント
        /// </summary>
        /// <param name="sender">イベント発生オブジェクト</param>
        /// <param name="e">イベント内容</param>
        private void ultraButton_CANCEL_Click(object sender, System.EventArgs e)
        {
            //画面終了
            this.Close();
        }

        /// <summary>
        /// OKボタンClickイベント
        /// </summary>
        /// <param name="sender">イベント発生オブジェクト</param>
        /// <param name="e">イベント内容</param>
        private void ultraButton_OK_Click(object sender, System.EventArgs e)
        {
            FelicaStopPolling();

            //●ログインID未入力チェック
            if( tEdit_LoginId.Text.Trim() == "" )
            {
                TMsgDisp.Show(this.Owner, emErrorLevel.ERR_LEVEL_INFO, pgId, "ログインIDを入力してください", 0, MessageBoxButtons.OK);
                tEdit_LoginId.Focus();

                // >>>> 2009.01.26 上野 Add ポーリングが止まらない現象対応 >>>>>>>>>>>>>>>>>>>>>>>>> 
                FelicaStartPolling();
                // <<<< 2009.01.26 上野 Add ポーリングが止まらない現象対応 <<<<<<<<<<<<<<<<<<<<<<<<<
            }
            else
            {
                //ログイン処理がFelicaと重ならないように排他
                lock( _loginObject )
                {
                    //従業員ログイン処理
                    if( LoginProc(tEdit_LoginId.Text, tEdit_LoginPassword.Text, false) )
                    {
                        this.Close();
                    }
                    else
                    {
                        // >>>> 2009.01.26 上野 Add ポーリングが止まらない現象対応 >>>>>>>>>>>>>>>>>>>>>>>>>
                        FelicaStartPolling();
                        // <<<< 2009.01.26 上野 Add ポーリングが止まらない現象対応 <<<<<<<<<<<<<<<<<<<<<<<<<
                    }
                }
            }
            // >>>> 2009.01.26 上野 Del ポーリングが止まらない現象対応 >>>>>>>>>>>>>>>>>>>>>>>>>
            //FelicaStartPolling();
            // <<<< 2009.01.26 上野 Del ポーリングが止まらない現象対応 <<<<<<<<<<<<<<<<<<<<<<<<<
        }
        

        /// <summary>
        /// タイマーイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_FelicaInfo_Tick(object sender, EventArgs e)
        {
            ultraStatusBar_EmployeeLogin.Panels["Info"].Enabled = !ultraStatusBar_EmployeeLogin.Panels["Info"].Enabled;

            // --- ADD m.suzuki 2010/02/18 ---------->>>>>
            // まれに「リーダーが初期されていない」状態になるので、
            // 再度、初期化とオープンを行って復旧する。
            if ( _felicaAcs != null )
            {
                if ( _felicaAcs.FelicaLastErrType == FeliCaErrorType.FELICA_LIBRARY_NOT_INITIALIZED ||
                    _felicaAcs.FelicaLastErrType == FeliCaErrorType.FELICA_READER_WRITER_NOT_OPENED )
                {
                    // フェリカ初期化処理
                    if ( _felicaAcs.InitializeLibrary() )
                    {
                        // フェリカリーダーオープン処理
                        if ( !_felicaAcs.OpenReaderWriterAuto() )
                        {
                        }
                    }
                    else
                    {
                    }
                }
            }
            // --- ADD m.suzuki 2010/02/18 ----------<<<<<
        }

        /// <summary>
        /// 画面生成イベント
        /// </summary>
        /// <param name="sender">イベント発生オブジェクト</param>
        /// <param name="e">イベント内容</param>
        private void EmployeeLoginFormAF_Load(object sender, System.EventArgs e)
        {
            //オンライン時
            if( _onlineFlag )
            {
                Text = "従業員ログイン[Online]";
                //Edit内容初期化
                tEdit_LoginId.Text = "";
                tEdit_LoginId.ReadOnly = false;
                tEdit_LoginId.Appearance.BackColor = System.Drawing.Color.White;
                tEdit_LoginPassword.Text = "";
                //メッセージ内容初期化
                //ultraStatusBar_EmployeeLogin.Panels["Info"].Text = "カードをリーダーにかざすか、ログイン情報を入力して下さい";
                //ログインIDを初期フォーカス位置に設定
                tEdit_LoginId.Focus();
            }
            else
            {
                Text = "従業員ログイン[Offline]";
                //Edit内容初期化
                tEdit_LoginId.Text = _paraEmployeeAuthInfoWork.EmployeeWork.LoginId;
                tEdit_LoginId.ReadOnly = true;
                tEdit_LoginId.Appearance.BackColor = System.Drawing.Color.AliceBlue;
                tEdit_LoginPassword.Text = "";
                //メッセージ内容初期化
                ultraStatusBar_EmployeeLogin.Panels["Info"].Text = "前回ログインした従業員パスワードを入力して下さい";
                //ログインIDを初期フォーカス位置に設定
                tEdit_LoginPassword.Focus();
            }

            if( _felicaAcs != null )
            {
                //Felicaポーリングスタート
                FelicaStartPolling();
            }
        }

        /// <summary>
        /// 画面終了イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EmployeeLoginFormAF_FormClosing(object sender, FormClosingEventArgs e)
        {
            //FelicaStopPolling();
            FelicaDispose();
        }

        #endregion

        #region Felica系処理
        /// <summary>
        /// 連続ポーリングコールバック
        /// </summary>
        /// <param name="idm"></param>
        /// <param name="pmm"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        private bool PollingSuccessCallBack(UInt64 idm, UInt64 pmm, bool result)
        {
            // --- ADD m.suzuki 2010/02/18 ---------->>>>>
            if ( idm == 0 )
            {
                // 一度ポーリング成功と認識しても、idm=0ならばキャンセルする
                // （※リーダーが接続されていない場合に誤認識する為、対応）
                FelicaStartPolling();
                return false;
            }
            // --- ADD m.suzuki 2010/02/18 ----------<<<<<

            bool loginStatus = false;
            if( result )
            {
                //ログイン処理が通常ログインと重ならないように排他
                lock( _loginObject )
                {
                    //従業員ログイン処理
                    loginStatus = LoginProc(idm.ToString(), "", true);

                    if( loginStatus )
                    {
                        this.Close();
                    }
                    else
                    {
                        FelicaStartPolling();
                    }
                }
            }
            else
            {
                if( _felicaAcs.FelicaLastErrType == FeliCaErrorType.FELICA_READER_WRITER_OPEN_AUTO_ERROR
                    || _felicaAcs.FelicaLastErrType == FeliCaErrorType.FELICA_POLLING_ERROR
                    || _felicaAcs.RwLastErrType == RwErrorType.RW_DEVICE_PLUGIN_NOT_FOUND
                    || _felicaAcs.RwLastErrType == RwErrorType.RW_READER_WRITER_DISCONNECTED )
                {
                    FelicaDispose();
                    ultraStatusBar_EmployeeLogin.Panels["Info"].Text = "従業員ログイン情報を入力して下さい";
                }
            }

            return result;
        }



        /// <summary>
        /// フェリカカード監視スタート
        /// </summary>
        private void FelicaStartPolling()
        {
            if( _felicaAcs != null )
            {
                timer_FelicaInfo.Enabled = true;
                timer_FelicaInfo.Start();

                _felicaAcs.StartPolling(felicaInterval, felicaRetry);
            }
        }

        /// <summary>
        /// フェリカカード監視ストップ
        /// </summary>
        private void FelicaStopPolling()
        {
            if( _felicaAcs != null )
            {
                _felicaAcs.StopPolling();
            }

            timer_FelicaInfo.Stop();
            timer_FelicaInfo.Enabled = false;
        }


        /// <summary>
        /// フェリカ破棄処理
        /// </summary>
        private void FelicaDispose()
        {
            FelicaStopPolling();

            if( _felicaAcs != null )
            {
                try
                {
                    ultraStatusBar_EmployeeLogin.Panels["Info"].Enabled = true;

                    _felicaAcs.Dispose();
                    _felicaAcs = null;
                }
                catch( Exception )
                {
                    _felicaAcs = null;
                }
            }
        }
        #endregion
    }
}
//****************************************************************************//
// システム         : 卸商仕入受信処理
// プログラム名称   : 卸商仕入受信処理Controller
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2008/11/17  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024　佐々木 健
// 作 成 日  2009/10/09  修正内容 : 受信の該当データ無し対応
//----------------------------------------------------------------------------//
// 管理番号  11770032-00 作成担当 : 田建委
// 作 成 日  2021/09/06  修正内容 : PMKOBETSU-4166 既存障害対応
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.IO;

using Broadleaf.Application.Controller.Agent;
using Broadleaf.Application.UIData;
//---ADD 田建委 2021/09/06 PMKOBETSU-4166 既存障害対応----->>>>
using Microsoft.Win32;
using Broadleaf.Application.Common;
using System.Xml;
//---ADD 田建委 2021/09/06 PMKOBETSU-4166 既存障害対応-----<<<<

namespace Broadleaf.Application.Controller
{
    #region <進捗更新/>

    /// <summary>
    /// 進捗更新用イベントパラメータクラス
    /// </summary>
    public sealed class UpdateProgressEventArgs : EventArgs
    {
        #region <進捗名称/>

        /// <summary>進捗名称</summary>
        private string _name;
        /// <summary>
        /// 進捗名称のアクセサ
        /// </summary>
        /// <value>進捗名称</value>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        #endregion  // <進捗名称/>

        #region <件数/>

        /// <summary>件数</summary>
        private int _count;
        /// <summary>
        /// 件数のアクセサ
        /// </summary>
        /// <value>件数</value>
        public int Count
        {
            get { return _count; }
            set { _count = value; }
        }

        #endregion  // <件数/>

        #region <最大値/>

        /// <summary>最大値</summary>
        private int _max;
        /// <summary>
        /// 最大値のアクセサ
        /// </summary>
        /// <value>最大値</value>
        public int Max
        {
            get { return _max; }
            set { _max = value; }
        }

        #endregion  // <最大値/>

        #region <処理中フラグ/>

        /// <summary>処理中フラグ</summary>
        private bool _isRunning;
        /// <summary>
        /// 処理中フラグのアクセサ
        /// </summary>
        /// <value>
        /// <c>true</c> :処理中<br/>
        /// <c>false</c>:処理終了
        /// </value>
        public bool IsRunning
        {
            get { return _isRunning; }
            set { _isRunning = value; }
        }

        #endregion  // <処理中フラグ/>

        #region <Constructor/>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="name">進捗名称</param>
        /// <param name="count">件数</param>
        public UpdateProgressEventArgs(
            string name,
            int count
        ) : this(name, count, 0)
        { }

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="name">進捗名称</param>
        /// <param name="count">件数</param>
        /// <param name="max">最大値</param>
        public UpdateProgressEventArgs(
            string name,
            int count,
            int max
        ) : base()
        {
            _name   = name;
            _count  = count;
            _max    = max;
        }

        #endregion  // <Constructor/>

        #region <Override/>

        /// <summary>
        /// 文字列に変換します。
        /// </summary>
        /// <returns>文字列</returns>
        public override string ToString()
        {
            if (Max.Equals(0))
            {
                return Name + "[" + Count.ToString() + "]"; // LITERAL:
            }
            else
            {
                StringBuilder str = new StringBuilder();
                {
                    str.Append(Name).Append("...[").Append(Count).Append("/").Append(Max).Append("] ");

                    int progress = (int)(((double)Count / (double)Max) * 100.0);
                    str.Append(progress).Append("%");
                }
                return str.ToString();
            }
        }

        #endregion  // <Override/>
    }

    /// <summary>
    /// 進捗を更新するイベントハンドラ
    /// </summary>
    /// <param name="sender">イベントソース</param>
    /// <param name="e">イベントパラメータ</param>
    public delegate void UpdateProgressEventHandler(
        object sender,
        UpdateProgressEventArgs e
    );

    /// <summary>
    /// 進捗を更新するインターフェース
    /// </summary>
    public interface IProgressUpdatable
    {
        /// <summary>
        /// 進捗を更新します。
        /// </summary>
        /// <param name="e">進捗更新用イベントパラメータ</param>
        void Update(UpdateProgressEventArgs e);
    }

    #endregion  // <進捗更新/>

    #region <Controller/>

    /// <summary>
    /// 卸商仕入受信処理Controllerクラス
    /// </summary>
    public abstract class OroshishoStockReceptionController : IProgressUpdatable
    {
        #region <IProgressUpdatable メンバ/>

        /// <summary>
        /// 進捗を更新します。
        /// </summary>
        /// <param name="e">進捗更新用イベントパラメータ</param>
        public void Update(UpdateProgressEventArgs e)
        {
            RaiseUpdateProgressEvent(e);
        }

        #endregion  // <IProgressUpdatable メンバ/>

        #region <進捗を更新するイベント/>

        /// <summary>進捗を更新するイベント</summary>
        public event UpdateProgressEventHandler UpdateProgress;

        /// <summary>
        /// 進捗を更新するイベントを発生させます。
        /// </summary>
        /// <param name="e">イベントパラメータ</param>
        protected void RaiseUpdateProgressEvent(UpdateProgressEventArgs e)
        {
            UpdateProgress(this, e);
        }

        #endregion  // <進捗を更新するイベント/>

        #region <UOE発注先/>

        /// <summary>UOE発注先</summary>
        private readonly UOESupplierHelper _uoeSupplier;
        /// <summary>
        /// UOE発注先を取得します。
        /// </summary>
        /// <value>UOE発注先</value>
        protected UOESupplierHelper UOESupplier { get { return _uoeSupplier; } }

        #endregion  // <UOE発注先/>

        /// <summary>
        /// 処理を実行します。
        /// </summary>
        /// <returns>結果コード</returns>
        public abstract int Execute();

        // 2009/10/09 Add >>>
        /// <summary>
        /// 処理ID
        /// </summary>
        public abstract Result.ProcessID ProcessID { get;}
        // 2009/10/09 Add <<<

        #region <Constructor/>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="uoeSupplier">UOE発注先</param>
        protected OroshishoStockReceptionController(UOESupplierHelper uoeSupplier)
        {
            _uoeSupplier = uoeSupplier;
            UpdateProgress += DebugWriteLine;
        }

        #endregion  // <Constructor/>

        #region <デバッグ用/>

        /// <summary>
        /// 進捗をDebug.WriteLine()します。
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private static void DebugWriteLine(
            object sender,
            UpdateProgressEventArgs e
        )
        {
            Debug.WriteLine(e.Count.ToString());
        }

        #endregion  // <デバッグ用/>
    }

    #endregion  // <Controller/>

    /// <summary>
    /// 仕入受信処理Controllerクラス
    /// </summary>
    public sealed class ReceiveStockAcs : OroshishoStockReceptionController
    {
        #region <生成物/>

        /// <summary>生成物</summary>
        /// <remarks>受信テキスト</remarks>
        private IAgreegate<ReceivedText> _product;
        /// <summary>
        /// 生成物（受信テキスト）を取得します。
        /// </summary>
        /// <value>生成物（受信テキスト）</value>
        public IAgreegate<ReceivedText> Product { get { return _product; } }

        #endregion  // <生成物/>

        #region const
        // インストールディレクトリ
        private const string REG_INSTALL_DIRECTORY = @"InstallDirectory";
        // レジストキー文字列
        private const string REG_KEY_CLIENT = @"Broadleaf\Product\Partsman";
        // レジストキー文字列（KEY32）
        private const string REG_KEY32 = @"SOFTWARE\";
        // レジストキー文字列（KEY64） ※取得できない場合
        private const string REG_KEY64 = @"SOFTWARE\WOW6432Node\";
        // UISettingsフォルダ
        private const string DIR_UISETTINGS = @"UISettings";
        // ログ出力制御設定ファイル名
        private const string XML_FILE_NAME = @"PMUOE01303A_LogOutEnabler.xml";
        // ログ出力制御設定ファイルログ出力区分
        private const string XML_LOGOUTDIV = "LogOutDiv";
        // ログフォルダ名
        private const string LogDirName = @"Log";
        // ログファイル名
        private const string LogName = @"siirezyushindenbun_{0}.log";
        // 日付フォマード
        private const string DateFomart = "yyyyMMdd";
        #endregion

        #region <Constructor/>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="uoeSupplier">UOE発注先</param>
        public ReceiveStockAcs(UOESupplierHelper uoeSupplier) : base(uoeSupplier) { }

        #endregion  // <Constructor/>

        #region <Override/>

        // 2009/10/09 Add >>>
        public override Result.ProcessID ProcessID { get { return Result.ProcessID.ReceiveStock; } }
        // 2009/10/09 Add <<<

        /// <summary>
        /// 処理を実行します。
        /// </summary>
        /// <returns>結果コード</returns>
        /// <see cref="OroshishoStockReceptionController"/>
        public override int Execute()
        {
            // 送信電文（開局→仕入要求→閉局）
            List<UoeSndHed> uoeSndHedList = new List<UoeSndHed>();
            {
                uoeSndHedList.Add(UOESupplier.TelegramEssence.UOESendHeader);
            }
            PrintUoeSndHed(uoeSndHedList[0], UOESupplier);

            // UOE送信機能を用い、送受信
            UoeRecHed receivedUoeRecHed = null;
            string errorMessage = string.Empty;
            int status = UOESendReceiveComponent.ReceiveUOEStockRequestText(
                UOESupplier.TelegramEssence.UOESendReceiveControlParameter,
                uoeSndHedList,
                UOESupplier.ReceivingUOESupplierType,
                out receivedUoeRecHed,
                out errorMessage
            );
            PrintUoeRecHed(receivedUoeRecHed);

            // 受信件数を取得
            int receivedCount = 0;
            if (status.Equals((int)Result.Code.Normal))
            {
                if (receivedUoeRecHed != null)
                {
                    _product = new ReceivedTextAgreegate(receivedUoeRecHed);
                    receivedCount = Product.Size;
                }
                // 2009/10/09 Add >>>
                if (receivedCount == 0) status = (int)Result.RemoteStatus.NotFound;
                // 2009/10/09 Add <<<
            }

            // --- ADD  鹿庭  2021/04/20 ---------->>>>>
            // --- UPD 田建委 2021/09/06 PMKOBETSU-4166 既存障害対応 ----->>>>>
            // ログファイルを日ごとに作成
            //string filePath = @"C:\Program Files (x86)\Partsman\Log\siirezyushindenbun_" + DateTime.Now.ToString("yyyyMMdd") + ".log";
            // カレントディレクトリ取得
            string installDir = GetCurrentDirectory(REG_KEY_CLIENT);
            // 設定ファイル取得
            bool logOutDiv = GetClientXml(installDir);
            if (logOutDiv)
            {
                // ログフォルダ
                string logDir = Path.Combine(installDir, LogDirName);

                if (!Directory.Exists(logDir))
                {
                    // Logフォルダーが存在しない場合、作成する
                    Directory.CreateDirectory(logDir);
                }
                string filePath = Path.Combine(logDir, string.Format(LogName, DateTime.Now.ToString(DateFomart)));
                // --- UPD 田建委 2021/09/06 PMKOBETSU-4166 既存障害対応 -----<<<<<
                if (!File.Exists(filePath))
                {
                    File.Create(filePath).Close();
                }
                // --- ADD  鹿庭  2021/04/20 ----------<<<<<

                // --- ADD  梶谷貴士  2020/10/21 ---------->>>>>
                //受信電文の内容をログに保存
                if (receivedCount != 0)
                {
                    File.AppendAllText(filePath, DateTime.Now.ToString() + "\r\n" + _product);
                }
                // --- ADD  鹿庭  2021/04/20 ---------->>>>>
                else
                {
                    File.AppendAllText(filePath, DateTime.Now.ToString() + " Status：" + status.ToString() + " Count：" + receivedCount + " ErrorMessage：" + errorMessage + "\r\n");
                }
                // --- ADD  鹿庭  2021/04/20 ----------<<<<<

                // --- ADD  梶谷貴士  2020/10/21 ----------<<<<<
            }// ADD 田建委 2021/09/06 PMKOBETSU-4166 既存障害対応

            RaiseUpdateProgressEvent(new UpdateProgressEventArgs(
                "仕入受信処理", // LITERAL:
                receivedCount
            ));

            return status;
        }

        // --- ADD 田建委 2021/09/06 PMKOBETSU-4166 既存障害対応 ----->>>>>
        /// <summary>
        /// クライアントXML情報取得
        /// 当関数で発生する例外処理は呼び出し元で破棄する
        /// </summary>
        /// <param name="installDir">パス</param>
        /// <remarks>
        /// <br>Note       : クライアントXML情報取得を行います。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2021/09/06</br>
        /// </remarks>
        private bool GetClientXml(string installDir)
        {
            string uisettingsDir = string.Empty;
            string xmlPath = string.Empty;

            // 戻りパラメータ初期値
            bool logOutDiv = false;

            if (!string.IsNullOrEmpty(installDir))
            {
                // カレントディレクトリ取得が成功した場合
                // UISettingフォルダ
                uisettingsDir = Path.Combine(installDir, DIR_UISETTINGS);

                // フルパス
                xmlPath = Path.Combine(uisettingsDir, XML_FILE_NAME);

                if (UserSettingController.ExistUserSetting(xmlPath))
                {
                    XmlReaderSettings settings = new XmlReaderSettings();
                    using (XmlReader reader = XmlReader.Create(xmlPath, settings))
                    {
                        // ログ出力可否制御ファイルを読み込む
                        while (reader.Read())
                        {
                            //ログファイル出力区分(true:出力する；false:出力しない)
                            if (reader.IsStartElement(XML_LOGOUTDIV)) logOutDiv = Convert.ToBoolean(reader.ReadElementString(XML_LOGOUTDIV).Trim());
                        }
                    }
                }
            }
            return logOutDiv;
        }

        /// <summary>
        /// カレントディレクトリのパス取得
        /// 当関数で発生する例外処理は呼び出し元で破棄する
        /// </summary>
        /// <param name="regKeyStr">regKeyStr</param>
        /// <returns>カレントディレクトリフルパス</returns>
        /// <remarks>
        /// <br>Note       : カレントディレクトリのパスを取得します。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2021/09/06</br>
        /// </remarks>
        private string GetCurrentDirectory(string regKeyStr)
        {
            string defaultDir = string.Empty;

            // 戻り値初期値
            string homeDir = string.Empty;

            try
            {
                // 実行ファイル格納パスを初期ディレクトリとする
                defaultDir = AppDomain.CurrentDomain.BaseDirectory;
            }
            catch
            {
                // 初期ディレクトリは念のための処理のため、
                // 取得できなくても処理続行する
            }

            try
            {
                // レジストリ情報よりキー情報を取得
                RegistryKey registryKey = GetRegistryKey(regKeyStr);

                if (registryKey != null)
                {
                    homeDir = registryKey.GetValue(REG_INSTALL_DIRECTORY, defaultDir).ToString();
                }
            }
            catch
            {
                // 例外時初期ディレクトリ取得可能性があるため処理続行
            }

            // 取得ディレクトリが存在しない場合は初期ディレクトリを設定
            if (!Directory.Exists(homeDir))
            {
                homeDir = defaultDir;
            }

            return homeDir;
        }

        /// <summary>
        /// レジストリキー情報取得
        /// 当関数で例外処理は不要なため呼び出し元で実装する
        /// </summary>
        /// <param name="regKeyStr">取得レジストリキー</param>
        /// <returns>RegistryKey</returns>
        /// <remarks>
        /// <br>Note       : レジストリキー情報を取得します。</br>
        /// <br>Programmer : 田建委</br>
        /// <br>Date       : 2021/09/06</br>
        /// </remarks>
        private RegistryKey GetRegistryKey(string regKeyStr)
        {
            RegistryKey registryKey = null;

            // レジストリ情報よりキー情報を取得
            registryKey = Registry.LocalMachine.OpenSubKey(REG_KEY32 + regKeyStr);

            if (registryKey == null)
            {
                // 取得できない場合、念のため
                registryKey = Registry.LocalMachine.OpenSubKey(REG_KEY64 + regKeyStr);
            }

            return registryKey;
        }
        // --- ADD 田建委 2021/09/06 PMKOBETSU-4166 既存障害対応 -----<<<<<
        #endregion  // <Override/>

        #region <Debug/>

        /// <summary>
        /// 送信電文情報を表示します。
        /// </summary>
        /// <param name="uoeSndHed">送信電文情報</param>
        /// <param name="uoeSupplier">UOE発注先</param>
        [Conditional("DEBUG")]
        private static void PrintUoeSndHed(
            UoeSndHed uoeSndHed,
            UOESupplierHelper uoeSupplier
        )
        {
            Debug.WriteLine(SendingStockReceptionTelegramEssence.ConvertString(
                uoeSndHed,
                uoeSupplier
            ));
        }

        /// <summary>
        /// 受信結果を表示します。
        /// </summary>
        /// <param name="uoeRecHed">受信結果</param>
        [Conditional("DEBUG")]
        private static void PrintUoeRecHed(UoeRecHed uoeRecHed)
        {
            Debug.WriteLine(SendingStockReceptionTelegramEssence.ConvertString(uoeRecHed));
        }

        #endregion  // <Debug/>
    }
}

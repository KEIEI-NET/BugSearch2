using System;
using System.IO;

//using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// バックアップ処理画面保存クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : バックアップ処理画面保存クラスです。</br>
    /// <br>Programmer : 孫俊華</br>
    /// <br>Date       : 2011.06.25</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class UiSetByAssembly
    {
        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region Private Members

        private string _saveFilePath;
        private string _executionDiv;
        private string _executeHour;
        private string _executeMinute;
        private string _shutdownDiv;
        # endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region Constructors
        /// <summary>
        /// オプション設定クラス
        /// </summary>
        /// <remarks>
        /// <br>Note       : オプション設定クラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 孫俊華</br>
        /// <br>Date       : 2011.06.25</br>
        /// </remarks>
        public UiSetByAssembly()
        {
            //保存先フォルダ
            this._saveFilePath = "";
            //処理区分
            this._executionDiv = "";
            //処理開始時間の時
            this._executeHour = "";
            //処理開始時間の分
            this._executeMinute = "";
            //自動シャットダウン区分
            this._shutdownDiv= "";
        }

        /// <summary>
        /// バックアップ処理画面保存オプション設定クラス
        /// </summary>
        /// <param name="saveFilePath">保存先フォルダ</param>
        /// <param name="executionDiv">処理区分</param>
        /// <param name="executeHour">処理開始時間の時</param>
        ///<param name="executeMinute">処理開始時間の分</param>
        /// <param name="shutdownDiv">自動シャットダウン区分</param>
        /// <remarks>
        /// <br>Note       : バックアップ処理画面保存クラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 孫俊華</br>
        /// <br>Date       : 2011.06.25</br>
        /// </remarks>
        public UiSetByAssembly(string saveFilePath, string executionDiv, string executeHour, string executeMinute, string shutdownDiv)
        {
            this._saveFilePath = saveFilePath;
            this._executionDiv = executionDiv;
            this._executeHour = executeHour;
            this._executeMinute = executeMinute;
            this._shutdownDiv = shutdownDiv;

        }
        # endregion

        // ===================================================================================== //
        // プロパティ
        // ===================================================================================== //
        # region Properties
        /// <summary>保存先フォルダプロパティ</summary>
        public string SaveFilePath
        {
            get { return this._saveFilePath; }
            set { this._saveFilePath = value; }
        }

        /// <summary>処理区分プロパティ</summary>
        public string ExecutionDiv
        {
            get { return this._executionDiv; }
            set { this._executionDiv = value; }
        }

        /// <summary>処理開始時間の時プロパティ</summary>
        public string ExecuteHour
        {
            get { return this._executeHour; }
            set { this._executeHour = value; }
        }
        /// <summary>処理開始時間の分プロパティ</summary>
        public string ExecutionMinute
        {
            get { return this._executeMinute; }
            set { this._executeMinute = value; }
        }

        /// <summary>自動シャットダウン区分プロパティ</summary>
        public string ShutdownDiv
        {
            get { return this._shutdownDiv; }
            set { this._shutdownDiv= value; }
        }

        # endregion

        /// <summary>
        /// バックアップ処理画面保存処理
        /// </summary>
        /// <returns>バックアップ処理画面保存処理設定クラス</returns>
        public UiSetByAssembly Clone()
        {
            return new UiSetByAssembly(this._saveFilePath, this._executionDiv, this._executeHour, this._executeMinute, this._shutdownDiv);
        }
    }

    /// <summary>
    /// バックアップ処理画面保存処理設定クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : バックアップ処理画面保存処理を管理するクラスです。</br>
    /// <br>Programmer : 孫俊華</br>
    /// <br>Date       : 2011.06.25</br>
    /// <br></br>
    /// </remarks>
    public class UiSetByAssemblyAcs
    {
        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region Private Members
        private static UiSetByAssembly _UiSetByAssembly;
        private const string XML_FILE_NAME = "PMKHN09290U_Settings.XML ";
        # endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region Constructors
        /// <summary>
        /// バックアップ処理画面保存クラスアクセスクラス
        /// </summary>
        /// <remarks>
        /// <br>Note       : バックアップ処理画面保存クラスアクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 孫俊華</br>
        /// <br>Date       : 2011.06.25</br>
        /// </remarks>
        public UiSetByAssemblyAcs()
        {
            if (_UiSetByAssembly == null)
            {
                _UiSetByAssembly = new UiSetByAssembly();
            }
            this.Deserialize();
        }
        # endregion

        // ===================================================================================== //
        // イベント
        // ===================================================================================== //
        # region Event
        /// <summary>データ変更後発生イベント</summary>
        public static event EventHandler DataChanged;
        # endregion

        // ===================================================================================== //
        // プロパティ
        // ===================================================================================== //
        # region Properties



        /// <summary> 保存先フォルダ設定値プロパティ</summary>
        public string SaveFilePath
        {
            get
            {
                if (_UiSetByAssembly == null)
                {
                    _UiSetByAssembly = new UiSetByAssembly();
                }
                return _UiSetByAssembly.SaveFilePath;
            }
            set
            {
                if (_UiSetByAssembly == null)
                {
                    _UiSetByAssembly = new UiSetByAssembly();
                }
                _UiSetByAssembly.SaveFilePath = value;
            }
        }

        /// <summary> 処理区分設定値プロパティ</summary>
        public string ExecutionDiv
        {
            get
            {
                if (_UiSetByAssembly == null)
                {
                    _UiSetByAssembly = new UiSetByAssembly();
                }
                return _UiSetByAssembly.ExecutionDiv;
            }
            set
            {
                if (_UiSetByAssembly == null)
                {
                    _UiSetByAssembly = new UiSetByAssembly();
                }
                _UiSetByAssembly.ExecutionDiv = value;
            }
        }

        /// <summary> 処理開始時間の時設定値プロパティ</summary>
        public string ExecuteHour
        {
            get
            {
                if (_UiSetByAssembly == null)
                {
                    _UiSetByAssembly = new UiSetByAssembly();
                }
                return _UiSetByAssembly.ExecuteHour;
            }
            set
            {
                if (_UiSetByAssembly == null)
                {
                    _UiSetByAssembly = new UiSetByAssembly();
                }
                _UiSetByAssembly.ExecuteHour = value;
            }
        }

        /// <summary> 処理開始時間の分設定値プロパティ</summary>
        public string ExecutionMinute
        {
            get
            {
                if (_UiSetByAssembly == null)
                {
                    _UiSetByAssembly = new UiSetByAssembly();
                }
                return _UiSetByAssembly.ExecutionMinute;
            }
            set
            {
                if (_UiSetByAssembly == null)
                {
                    _UiSetByAssembly = new UiSetByAssembly();
                }
                _UiSetByAssembly.ExecutionMinute = value;
            }
        }

        /// <summary> 自動シャットダウン区分設定値プロパティ</summary>
        public string ShutdownDiv
        {
            get
            {
                if (_UiSetByAssembly == null)
                {
                    _UiSetByAssembly = new UiSetByAssembly();
                }
                return _UiSetByAssembly.ShutdownDiv;
            }
            set
            {
                if (_UiSetByAssembly == null)
                {
                    _UiSetByAssembly = new UiSetByAssembly();
                }
                _UiSetByAssembly.ShutdownDiv = value;
            }
        }

        # endregion

        // ===================================================================================== //
        // パブリックメソッド
        // ===================================================================================== //
        # region Public Methods
        /// <summary>
        /// バックアップ処理画面保存処理クラスシリアライズ処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : バックアップ処理画面保存処理クラスのシリアライズを行います。</br>
        /// <br>Programmer : 孫俊華</br>
        /// <br>Date       : 2011.06.25</br>
        /// </remarks>
        public void Serialize()
        {
            UserSettingController.SerializeUserSetting(_UiSetByAssembly, Path.Combine               (ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME));

            if (DataChanged != null)
            {
                // データ変更後発生イベント実行
                DataChanged(this, new EventArgs());
            }
        }

        /// <summary>
        /// バックアップ処理画面保存処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : バックアップ処理画面保存クラスをデシリアライズします。</br>
        /// <br>Programmer : 孫俊華</br>
        /// <br>Date       : 2011.06.25</br>
        /// </remarks>
        public void Deserialize()
        {
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME)))
            {
                _UiSetByAssembly = UserSettingController.DeserializeUserSetting<UiSetByAssembly>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME));
            }
        }
        # endregion
    }
}

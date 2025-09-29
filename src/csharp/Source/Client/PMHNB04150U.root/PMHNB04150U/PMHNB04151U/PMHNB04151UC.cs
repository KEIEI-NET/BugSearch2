using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Windows.Forms
{
   /// <summary>
	/// 売上速報表示 ユーザー設定情報クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 売上速報表示のユーザー設定情報を管理するクラス</br>
	/// <br>Programmer : 30418 徳永</br>
	/// <br>Date       : 2008.11.210</br>
	/// <br></br>
	/// </remarks>
	[Serializable]
	public class SalesReportSetting
	{
		#region プライベート変数

        /// <summary>設定：起動時の抽出 0:しない 1:する</summary>
		private int _startupSearch;

        /// <summary>設定：自動更新 0:しない 0~:更新間隔(分)</summary>
		private int _autoUpdateTime;

        /// <summary>設定：拠点初期値 0:自拠点 1:全社</summary>
        private int _initialSectionCode;

        #endregion // プライベート変数

        #region 初期設定値

        /// <summary>初期設定値：起動時の抽出 初期値「しない」</summary>
        private const int DEFAULT_STARTUP_SEARCH = 1;

        /// <summary>初期設定値：自動更新 初期値「0:しない」</summary>
        private const int DEFAULT_AUTO_UPDATE = 0;

        /// <summary>初期設定値：拠点の初期値 初期値「自拠点」</summary>
        private const int DEFAULT_INITIAL_SECTIONCODE = 0;

        #endregion // 初期設定値

		#region コンストラクタ

		/// <summary>
		/// 売上速報表示用ユーザー設定クラス
		/// </summary>
		/// <remarks>
		/// <br>Note       : 売上速報表示用ユーザー設定クラスの新しいインスタンスを初期化</br>
		/// <br>Programmer : 34108 徳永</br>
		/// <br>Date       : 2008.11.20</br>
		/// </remarks>
		public SalesReportSetting()
		{
            this._startupSearch = DEFAULT_STARTUP_SEARCH;
			this._autoUpdateTime = DEFAULT_AUTO_UPDATE;
			this._initialSectionCode = DEFAULT_INITIAL_SECTIONCODE;
		}

		/// <summary>
		/// 売上速報表示用ユーザー設定クラス
		/// </summary>
        /// <param name="startupSearch"></param>
        /// <param name="autoUpdateTime"></param>
        /// <param name="initialSectionCode"></param>
		/// <remarks>
		/// <br>Note       : 売上速報表示用ユーザー設定クラスの新しいインスタンスを初期化</br>
		/// <br>Programmer : 34108 徳永</br>
		/// <br>Date       : 2008.11.20</br>
		/// </remarks>
		public SalesReportSetting(int startupSearch, int autoUpdateTime, int initialSectionCode)
		{
            this._startupSearch = startupSearch;
			this._autoUpdateTime = autoUpdateTime;
			this._initialSectionCode = initialSectionCode;
		}
		#endregion // コンストラクタ

		#region 公開プロパティ

		/// <summary>起動時の抽出プロパティ</summary>
		public int StartupSearch
		{
			get { return this._startupSearch; }
			set { this._startupSearch = value; }
		}

		/// <summary>自動更新プロパティ</summary>
		public int AutoUpdateTime
		{
			get { return this._autoUpdateTime; }
			set { this._autoUpdateTime = value; }
		}

        /// <summary>拠点の初期値プロパティ</summary>
		public int InitialSectionCode
		{
			get { return this._initialSectionCode; }
			set { this._initialSectionCode = value; }
		}

        #endregion // 公開プロパティ

        #region クローン

		/// <summary>
		/// 売上速報表示用ユーザー設定クラス複製処理
		/// </summary>
		/// <returns>売上速報表示用ユーザー設定クラス</returns>
		public SalesReportSetting Clone()
		{
			return new SalesReportSetting(this._startupSearch, this._autoUpdateTime, this._initialSectionCode);
		}

		#endregion // クローン
	}

    /// <summary>
    /// 売上速報表示用 ユーザー設定アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上速報表示のユーザー設定情報を管理するクラス</br>
    /// <br>Programmer : 30418 徳永</br>
    /// <br>Date       : 2008.11.21</br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class SalesReportSettingAcs
    {
        # region パブリック定数

        /// <summary>設定画面：起動時の抽出　初期値「しない」</summary>
        public static readonly int SETTING_DEFVALUE_START_SEARCH = 1;

        /// <summary>設定画面：自動更新　初期値「0:しない」</summary>
        public static readonly int SETTING_DEFVALUE_AUTO_UPDATE = 0;

        /// <summary>設定画面：拠点の初期値　初期値「自拠点」</summary>
        public static readonly int SETTING_DEFVALUE_DEF_SECTIONCODE = 0;

        # endregion // パブリック定数

        # region プライベート変数

        /// <summary>XMLファイル名称：初期値「PMKHN04150U_Construction.XML」</summary>
        private const string CT_XML_FILE_NAME = "PMKHN04150U_Construction.XML";

        /// <summary>XMLファイル名：初期値なし</summary>
        private string _xmlFileName = "";

        /// <summary>売上速報表示用ユーザー設定クラス</summary>
        private static SalesReportSetting _salesReportSetting;

        /// <summary>設定実行フラグ</summary>
        private bool _alreadySetup = false;

        # endregion // プライベート変数

        # region コンストラクタ

        /// <summary>
        /// 売上速報表示用ユーザー設定 アクセスクラス
        /// </summary>
        /// <remarks>
        /// <br>Note       : 売上速報表示用ユーザー設定 アクセスクラスの新しいインスタンスを作成</br>
        /// <br>Programmer : 34108 徳永</br>
        /// <br>Date       : 2008.11.20</br>
        /// </remarks>
        public SalesReportSettingAcs()
        {
            this._xmlFileName = CT_XML_FILE_NAME;
            if (_salesReportSetting == null)
            {
                _salesReportSetting = new SalesReportSetting();
            }
            this.Deserialize();
        }

        /// <summary>
        /// 売上速報表示用ユーザー設定 アクセスクラス
        /// </summary>
        /// <param name="xmlFileName">XMLファイル名</param>
        /// <remarks>
        /// <br>Note       : 売上速報表示用ユーザー設定 アクセスクラスの新しいインスタンスを作成</br>
        /// <br>Programmer : 34108 徳永</br>
        /// <br>Date       : 2008.11.20</br>
        /// </remarks>
        public SalesReportSettingAcs(string xmlFileName)
        {
            this._xmlFileName = xmlFileName;
            if (_salesReportSetting == null)
            {
                _salesReportSetting = new SalesReportSetting();
            }
            this.Deserialize();
        }

        # endregion // コンストラクタ

        # region プロパティ

        /// <summary>設定実行フラグ</summary>
        public bool AlreadySetup
        {
            get { return this._alreadySetup; }
            set { this._alreadySetup = value; }
        }

        /// <summary>起動時の抽出プロパティ</summary>
        public int StartupSearch
        {
            get
            {
                if (_salesReportSetting == null)
                {
                    _salesReportSetting = new SalesReportSetting();
                }
                return _salesReportSetting.StartupSearch;
            }
            set
            {
                if (_salesReportSetting == null)
                {
                    _salesReportSetting = new SalesReportSetting();
                }
                _salesReportSetting.StartupSearch = value;
            }
        }

        /// <summary>自動更新プロパティ</summary>
        public int AutoUpdateTime
        {
            get
            {
                if (_salesReportSetting == null)
                {
                    _salesReportSetting = new SalesReportSetting();
                }
                return _salesReportSetting.AutoUpdateTime;
            }
            set
            {
                if (_salesReportSetting == null)
                {
                    _salesReportSetting = new SalesReportSetting();
                }
                _salesReportSetting.AutoUpdateTime = value;
            }
        }

        /// <summary>拠点の初期値プロパティ</summary>
        public int InitialSectionCode
        {
            get
            {
                if (_salesReportSetting == null)
                {
                    _salesReportSetting = new SalesReportSetting();
                }
                return _salesReportSetting.InitialSectionCode;
            }
            set
            {
                if (_salesReportSetting == null)
                {
                    _salesReportSetting = new SalesReportSetting();
                }
                _salesReportSetting.InitialSectionCode = value;
            }
        }

        # endregion // プロパティ

        # region パブリックメソッド

        /// <summary>
        /// シリアライズ処理
        /// </summary>
        public void Serialize()
        {
            UserSettingController.SerializeUserSetting(_salesReportSetting, Path.Combine(ConstantManagement_ClientDirectory.UISettings, this._xmlFileName));
        }

        /// <summary>
        /// デシリアライズ処理
        /// </summary>
        public void Deserialize()
        {
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, this._xmlFileName)))
            {
                _salesReportSetting = UserSettingController.DeserializeUserSetting<SalesReportSetting>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, this._xmlFileName));
                this._alreadySetup = true;
            }
            else
            {
                this._alreadySetup = false;
            }
        }

        # endregion // パブリックメソッド
    }
}

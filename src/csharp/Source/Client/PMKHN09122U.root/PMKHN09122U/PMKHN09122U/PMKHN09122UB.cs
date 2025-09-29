//****************************************************************************//
// システム         : 操作履歴表示
// プログラム名称   : 操作履歴表示メインフレームのタブ構成
// プログラム概要   : 操作履歴表示メインフレームのタブ構成を定義します。
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22018 鈴木 正臣
// 作 成 日  2010/02/22  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Drawing;
using System.Windows.Forms;

using Broadleaf.Library.Resources;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 操作履歴表示メインフレームのタブ構成クラス
    /// </summary>
    /// <remarks>
    /// <br>Note         : 操作履歴表示・ログ表示を行います。</br>
    /// <br>Programmer   : 22018 鈴木　正臣</br>
    /// <br>Date         : 2010.02.22</br>
    /// <br></br>
    /// </remarks>
    // --- UPD m.suzuki 2010/02/22 ---------->>>>>
    //internal sealed class TabConfig
    internal sealed class TabConfigForRef
    // --- UPD m.suzuki 2010/02/22 ----------<<<<<
    {
        #region <操作権限設定/>
        // --- DEL m.suzuki 2010/02/22 ---------->>>>>
        ///// <summary>操作権限設定タブのキー</summary>
        //public const string SECURITY_MANAGEMENT_SETTING_KEY = "TAB_SECURITY_MANAGEMENT_SETTING";

        ///// <summary>操作権限設定タブのテキスト（タイトル）</summary>
        //private const string SECURITY_MANAGEMENT_SETTING_TEXT = "操作権限設定"; // LITERAL:

        ///// <summary>操作権限設定タブのアイコン（インデックス）</summary>
        //private const int SECURITY_MANAGEMENT_SETTING_ICON_INDEX = (int)Size16_Index.EDITING;

        ///// <summary>
        ///// 操作権限設定タブ構成インスタンスを生成します。
        ///// </summary>
        ///// <returns>操作権限設定タブ構成インスタンス</returns>
        //private static TabConfigForRef CreateSecurityManagementSettingTabConfig()
        //{
        //    return new TabConfigForRef(
        //        SECURITY_MANAGEMENT_SETTING_KEY,
        //        SECURITY_MANAGEMENT_SETTING_TEXT,
        //        IconResourceManagement.ImageList16.Images[SECURITY_MANAGEMENT_SETTING_ICON_INDEX],
        //        new PMKHN09130UA()
        //    );
        //}
        // --- DEL m.suzuki 2010/02/22 ----------<<<<<
        #endregion  // <操作権限設定/>

        #region <操作権限一覧表示/>
        // --- DEL m.suzuki 2010/02/22 ---------->>>>>
        ///// <summary>操作権限一覧表示タブのキー</summary>
        //public const string SECURITY_MANAGEMENT_VIEW_KEY = "TAB_SECURITY_MANAGEMENT_VIEW";

        ///// <summary>操作権限一覧表示タブのテキスト</summary>
        //private const string SECURITY_MANAGEMENT_VIEW_TEXT = "従業員権限一覧表示";    // LITERAL:

        ///// <summary>操作権限一覧表示タブのアイコン（インデックス）</summary>
        //private const int SECURITY_MANAGEMENT_VIEW_ICON_INDEX = (int)Size16_Index.VIEW;

        ///// <summary>
        ///// 操作権限一覧表示タブ構成インスタンスを生成します。
        ///// </summary>
        ///// <returns>操作権限一覧表示タブ構成インスタンス</returns>
        //private static TabConfigForRef CreateSecurityManagementViewTabConfig()
        //{
        //    return new TabConfigForRef(
        //        SECURITY_MANAGEMENT_VIEW_KEY,
        //        SECURITY_MANAGEMENT_VIEW_TEXT,
        //        IconResourceManagement.ImageList16.Images[SECURITY_MANAGEMENT_VIEW_ICON_INDEX],
        //        new PMKHN09130UB()
        //    );
        //}
        // --- DEL m.suzuki 2010/02/22 ----------<<<<<
        #endregion  // <操作権限一覧表示/>

        #region <操作履歴表示/>

        /// <summary>操作履歴表示タブのキー</summary>
        public const string OPERATION_LOG_VIEW_KEY = "TAB_OPERATION_LOG_VIEW";

        /// <summary>操作履歴表示タブのテキスト</summary>
        private const string OPERATION_LOG_VIEW_TEXT = "操作履歴表示";  // LITERAL:

        /// <summary>操作履歴表示タブのアイコン（インデックス）</summary>
        private const int OPERATION_LOG_VIEW_ICON_INDEX = (int)Size16_Index.INPUTCHECK;

        /// <summary>
        /// 操作履歴表示タブ構成インスタンスを生成します。
        /// </summary>
        /// <returns>操作履歴表示タブ構成インスタンス</returns>
        private static TabConfigForRef CreateOperationLogViewTabConfig()
        {
            return new TabConfigForRef(
                OPERATION_LOG_VIEW_KEY,
                OPERATION_LOG_VIEW_TEXT,
                IconResourceManagement.ImageList16.Images[OPERATION_LOG_VIEW_ICON_INDEX],
                new PMKHN09140UA()
            );
        }

        #endregion  // <操作履歴表示/>

        #region <エラーログ表示/>

        /// <summary>エラーログ表示タブのキー</summary>
        public const string ERROR_LOG_VIEW_KEY = "TAB_ERROR_LOG_VIEW";

        /// <summary>エラーログ表示タブのテキスト</summary>
        private const string ERROR_LOG_VIEW_TEXT = "ログ表示";  // LITERAL:

        /// <summary>エラーログ表示タブのアイコン（インデックス）</summary>
        private const int ERROR_LOG_VIEW_ICON_INDEX = (int)Size16_Index.INPUTCHECK;

        /// <summary>
        /// エラーログ表示タブ構成インスタンスを生成します。
        /// </summary>
        /// <returns>エラーログ表示タブ構成インスタンス</returns>
        private static TabConfigForRef CreateErrorLogViewTabConfig()
        {
            return new TabConfigForRef(
                ERROR_LOG_VIEW_KEY,
                ERROR_LOG_VIEW_TEXT,
                IconResourceManagement.ImageList16.Images[ERROR_LOG_VIEW_ICON_INDEX],
                new PMKHN09140UB()
            );
        }

        #endregion  // <エラーログ表示/>

        /// <summary>
        /// タブ構成インスタンスを生成します。
        /// </summary>
        /// <remarks>
        /// キーに該当するものがない場合、null を返します。
        /// </remarks>
        /// <param name="tabKey">タブのキー</param>
        /// <returns>タブ構成インスタンス</returns>
        public static TabConfigForRef CreateInstance(string tabKey)
        {
            switch (tabKey)
            {
                // --- DEL m.suzuki 2010/02/22 ---------->>>>>
                //case SECURITY_MANAGEMENT_SETTING_KEY:
                //    return CreateSecurityManagementSettingTabConfig();

                //case SECURITY_MANAGEMENT_VIEW_KEY:
                //    return CreateSecurityManagementViewTabConfig();
                // --- DEL m.suzuki 2010/02/22 ----------<<<<<

                case OPERATION_LOG_VIEW_KEY:
                    return CreateOperationLogViewTabConfig();

                case ERROR_LOG_VIEW_KEY:
                    return CreateErrorLogViewTabConfig();

                default:
                    return null;
            }
        }

        /// <summary>
        /// イメージリストを取得します。
        /// </summary>
        /// <value>イメージリスト</value>
        public static ImageList ImageList
        {
            get { return IconResourceManagement.ImageList16; }
        }

        #region <アクセサ/>

        /// <summary>タブのキー</summary>
		private readonly string _key;
        /// <summary>
        /// タブのキーを取得します。
        /// </summary>
        /// <value>タブのキー</value>
        public string Key
        {
            get { return _key; }
        }

        /// <summary>タブのテキスト（タイトル）</summary>
        private readonly string _text;
        /// <summary>
        /// タブのテキスト（タイトル）を取得します。
        /// </summary>
        /// <value>タブのテキスト（タイトル）</value>
        public string Text
        {
            get { return _text; }
        }

        /// <summary>タブのアイコン</summary>
        private readonly Image _icon;
        /// <summary>
        /// タブのアイコンを取得します。
        /// </summary>
        /// <value>タブのアイコン</value>
        public Image Icon
        {
            get { return _icon; }
        }

        /// <summary>対応するフォームコントロール</summary>
        private readonly Form _form;
        /// <summary>
        /// 対応するフォームコントロールを取得します。
        /// </summary>
        /// <value>対応するフォームコントロール</value>
        public Form Form
        {
            get { return _form; }
        }

        #endregion  // <アクセサ/>

        #region <Constructor/>

        /// <summary>
		/// カスタムコンストラクタ
        /// </summary>
        /// <param name="key">タブのキー</param>
        /// <param name="text">タブのテキスト（タイトル）</param>
        /// <param name="icon">タブのアイコン</param>
        /// <param name="form">対応するフォームコントロール</param>
        private TabConfigForRef(
			string key, 
			string text,
            Image icon,
            Form form
		)
        {
            _key = key;
            _text = text;
            _icon = icon;
            _form = form;
        }

        #endregion  // <Constructor/>
    }
}
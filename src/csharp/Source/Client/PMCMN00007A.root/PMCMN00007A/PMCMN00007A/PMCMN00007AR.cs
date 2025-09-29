//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : マスタメンテナンス
// プログラム概要   : マスタメンテナンスの制御全般を行います。
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 修 正 日  2008/09/01  修正内容 : 新規作成
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2008/11/13  修正内容 : マスメン、帳票用OperationToolBarクラス追加
//                       　　　　 : マスメン用MasMainOperationButtonクラス追加
//                       　　　　 : ログ書込み時のプログラムIDをマスタフレームのIDに固定
//                       　　　　 : ・マスメン "SFCMN09000U" 
//                       　　　　 : ・帳票　　 "SFANL07200U"
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Diagnostics;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller.Agent;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller
{
    using OperationLimitationAcs= SingletonPolicy<OperationStDBAgent>;
    using OperationMasterAcs    = SingletonPolicy<OperationLcDBAgent>;
    using OperationHistoryLogAcs= SingletonPolicy<OperationHistoryLog>;

    using ButtonType = Infragistics.Win.Misc.UltraButton;
    using ToolBarType= Infragistics.Win.UltraWinToolbars.UltraToolbarsManager;
    using ToolClickEventHandlerType = Infragistics.Win.UltraWinToolbars.ToolClickEventHandler;
    using ToolClickEventArgsType    = Infragistics.Win.UltraWinToolbars.ToolClickEventArgs;

    /// <summary>
    /// 操作権限の制御アイテムクラス
    /// </summary>
    public abstract class OperationControlItem
    {
        #region <操作情報/>

        /// <summary>デフォルトステータス(ログ出力で使用)</summary>
        public const int DEFAULT_STATUS = 0;
        /// <summary>デフォルトメッセージ(ログ出力で使用)</summary>
        public const string DEFAULT_MESSAGE = "";
        /// <summary>デフォルトデータ(ログ出力で使用)</summary>
        public const string DEFAULT_DATA = "";

        /// <summary>カテゴリコード</summary>
        private readonly int _categoryCode;
        /// <summary>
        /// カテゴリコードを取得します。
        /// </summary>
        /// <value>カテゴリコード</value>
        protected int CategoryCode
        {
            get { return _categoryCode; }
        }

        /// <summary>プログラムID</summary>
        private readonly string _pgId;
        /// <summary>
        /// プログラムIDを取得します。
        /// </summary>
        /// <value>プログラムID</value>
        protected string PgId
        {
            get { return _pgId; }
        }

        /// <summary>プログラム名称</summary>
        private string _pgName;
        /// <summary>
        /// プログラム名称を取得します。
        /// </summary>
        /// <value>プログラム名称</value>
        protected string PgName
        {
            get
            {
                if (string.IsNullOrEmpty(_pgName))
                {
                    _pgName = OperationMasterAcs.Instance.Policy.GetProgramName(PgId);
                }
                return _pgName;
            }
        }

        /// <summary>ログインしている従業員</summary>
        private readonly Employee _loginEmployee;
        /// <summary>
        /// ログインしている従業員を取得します。
        /// </summary>
        /// <value>ログインしている従業員</value>
        protected Employee LoginEmployee
        {
            get { return _loginEmployee; }
        }

        #endregion  // <操作情報/>

        #region <Constructor>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="categoryCode">カテゴリコード</param>
        /// <param name="pgId">プログラムID</param>
        /// <param name="pgName">プログラム名称</param>
        /// <param name="loginEmployee">ログイン従業員</param>
        protected OperationControlItem(
            int categoryCode,
            string pgId,
            string pgName,
            Employee loginEmployee
        )
        {
            _categoryCode   = categoryCode;
            _pgId           = pgId;
            _pgName         = pgName;
            _loginEmployee  = loginEmployee;
        }

        #endregion  // <Constructor>

        /// <summary>
        /// 操作権限の制御を開始します。
        /// </summary>
        public abstract void BeginControl();
    }

    #region <ボタン/>

    /// <summary>
    /// 操作権限の制御ボタンクラス
    /// </summary>
    public class OperationButton : OperationControlItem
    {
        #region <アクセサ/>

        /// <summary>制御対象となるボタン</summary>
        private readonly ButtonType _button;
        /// <summary>
        /// 制御対象となるボタンを取得します。
        /// </summary>
        /// <value>制御対象となるボタン</value>
        protected ButtonType Button
        {
            get { return _button; }
        }

        /// <summary>オペレーションコード</summary>
        private readonly int _operationCode;
        /// <summary>
        /// オペレーションコードを取得します。
        /// </summary>
        /// <value>オペレーションコード</value>
        protected int OperationCode
        {
            get { return _operationCode; }
        }

        /// <summary>ログを記録するフラグ</summary>
        private readonly bool _withLogs;
        /// <summary>
        /// ログを記録するフラグを取得します。
        /// </summary>
        /// <value>ログを記録するフラグ</value>
        protected bool WithLogs
        {
            get { return _withLogs; }
        }

        #endregion  // <アクセサ/>

        #region <Constructor/>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="categoryCode">カテゴリコード</param>
        /// <param name="pgId">プログラムID</param>
        /// <param name="pgName">プログラム名称</param>
        /// <param name="operationCode">オペレーションコード</param>
        /// <param name="loginEmployee">ログイン従業員</param>
        /// <param name="button">制御対象となるボタン</param>
        /// <param name="withLogs">ログを記録するフラグ</param>
        public OperationButton(
            int categoryCode,
            string pgId,
            string pgName,
            int operationCode,
            Employee loginEmployee,
            ButtonType button,
            bool withLogs
        ) : base(categoryCode, pgId, pgName, loginEmployee)
        {
            _button         = button;
            _operationCode  = operationCode;
            _withLogs       = withLogs;
        }

        #endregion  // <Constructor/>

        /// <summary>
        /// 表示できるか判定します。
        /// </summary>
        /// <returns><c>true</c> :表示できる。<br/><c>false</c>:表示できない。</returns>
        protected bool CanVisible()
        {
            OperationLimit operationLimit = OperationLimit.Enable;
            if (OperationMasterAcs.Instance.Policy.IsTargetOperation(CategoryCode, PgId, OperationCode))
            {
                operationLimit = OperationLimitationAcs.Instance.Policy.GetOperationLimit(
                    CategoryCode,
                    PgId,
                    OperationCode,
                    LoginEmployee
                );
            }
            return !operationLimit.Equals(OperationLimit.Disable);
        }

        /// <summary>
        /// 操作履歴を出力するイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        protected virtual void WriteOperationLog(
            object sender,
            EventArgs e
        )
        {
            const string METHOD_NAME = "WriteOperationLog";
            if (!WithLogs) return;  // ログ記録の対象でなければ、何もしない

            Debug.WriteLine(PgName + "をボタン操作！");
            // 操作ログ出力
            OperationHistoryLogAcs.Instance.Policy.WriteOperationLog(
                this,
                LogDataKind.OperationLog,
                PgId,
                PgName,
                METHOD_NAME,
                OperationCode,
                DEFAULT_STATUS,
                DEFAULT_MESSAGE,
                DEFAULT_DATA
            );
        }

        #region <Override/>

        /// <see cref="OperationControlItem"/>
        public override void BeginControl()
        {
            if (Button.Visible)
            {
                Button.Visible = CanVisible();
            }
            Button.Click += new EventHandler(this.WriteOperationLog);
        }

        #endregion  // <Override/>
    }

    // --- ADD 2008/11/13 -------------------------------->>>>>
    /// <summary>
    /// 操作権限の制御ボタンクラス（マスメン用）
    /// </summary>
    public sealed class MasMainOperationButton : OperationButton
    {
        private const string _logPGID = "SFCMN09000U";

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="categoryCode">カテゴリコード</param>
        /// <param name="pgId">プログラムID</param>
        /// <param name="pgName">プログラム名称</param>
        /// <param name="operationCode">オペレーションコード</param>
        /// <param name="loginEmployee">ログイン従業員</param>
        /// <param name="button">制御対象となるボタン</param>
        /// <param name="withLogs">ログを記録するフラグ</param>
        public MasMainOperationButton(
            int categoryCode,
            string pgId,
            string pgName,
            int operationCode,
            Employee loginEmployee,
            ButtonType button,
            bool withLogs
        ) : base(categoryCode,
            pgId,
            pgName,
            operationCode,
            loginEmployee,
            button,
            withLogs)
        {
        }

        protected override void WriteOperationLog(
            object sender,
            EventArgs e
        )
        {
            const string METHOD_NAME = "WriteOperationLog";
            if (!WithLogs) return;  // ログ記録の対象でなければ、何もしない

            Debug.WriteLine(PgName + "をボタン操作！");
            // 操作ログ出力
            OperationHistoryLogAcs.Instance.Policy.WriteOperationLog(
                this,
                LogDataKind.OperationLog,
                _logPGID,
                PgName,
                METHOD_NAME,
                OperationCode,
                DEFAULT_STATUS,
                DEFAULT_MESSAGE,
                DEFAULT_DATA
            );
        }
    }
    // --- ADD 2008/11/13 --------------------------------<<<<<
    #endregion  // <ボタン/>

    #region <ツールバー/>

    /// <summary>
    /// ツールボタン情報クラス
    /// </summary>
    public class ToolButtonInfo : KeyValuePair<Pair<int, bool>>
    {
        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="key">ツールボタンのキー</param>
        /// <param name="operationCode">対応するオペレーションコード</param>
        /// <param name="withLogs">ログ記録するフラグ</param>
        public ToolButtonInfo(
            string key,
            int operationCode,
            bool withLogs
        ) : base(key, new Pair<int, bool>(operationCode, withLogs))
        { }
    }

    /// <summary>
    /// 操作権限の制御ツールバークラス
    /// </summary>
    public class OperationToolBar : OperationControlItem
    {
        #region <アクセサ/>

        /// <summary>制御対象となるツールバー</summary>
        private readonly ToolBarType _toolBar;
        /// <summary>
        /// 制御対象となるツールバーを取得します。
        /// </summary>
        /// <value>制御対象となるツールバー</value>
        protected ToolBarType ToolBar
        {
            get { return _toolBar; }
        }

        /// <summary>ツールボタン情報のマップ</summary>
        private readonly Dictionary<string, ToolButtonInfo> _toolButtonInfoMap;
        /// <summary>
        /// ツールボタン情報のマップを取得します。
        /// </summary>
        /// <value>ツールボタン情報のマップ</value>
        protected Dictionary<string, ToolButtonInfo> ToolButtonInfoMap
        {
            get { return _toolButtonInfoMap; }
        }

        #endregion  // <アクセサ/>

        #region <Constructor/>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="categoryCode">カテゴリコード</param>
        /// <param name="pgId">プログラムID</param>
        /// <param name="pgName">プログラム名称</param>
        /// <param name="loginEmployee">ログイン従業員</param>
        /// <param name="toolBar">制御対象となるツールバー</param>
        /// <param name="toolButtonInfoList">対象とするツールボタン情報のリスト</param>
        public OperationToolBar(
            int categoryCode,
            string pgId,
            string pgName,
            Employee loginEmployee,
            ToolBarType toolBar,
            List<ToolButtonInfo> toolButtonInfoList
        ) : base(categoryCode, pgId, pgName, loginEmployee)
        {
            _toolBar = toolBar;

            _toolButtonInfoMap = new Dictionary<string, ToolButtonInfo>();
            foreach (ToolButtonInfo eToolButtonInfo in toolButtonInfoList)
            {
                _toolButtonInfoMap.Add(eToolButtonInfo.Key, eToolButtonInfo);
            }
        }

        #endregion  // <Constructor/>

        /// <summary>
        /// 表示できるか判定します。
        /// </summary>
        /// <param name="toolButtonInfo">ツールボタン情報</param>
        /// <returns><c>true</c> :表示できる。<br/><c>false</c>:表示できない。</returns>
        protected bool CanVisible(ToolButtonInfo toolButtonInfo)
        {
            OperationLimit operationLimit = OperationLimit.Enable;
            if (OperationMasterAcs.Instance.Policy.IsTargetOperation(CategoryCode, PgId, toolButtonInfo.Value.First))
            {
                operationLimit = OperationLimitationAcs.Instance.Policy.GetOperationLimit(
                    CategoryCode,
                    PgId,
                    toolButtonInfo.Value.First,
                    LoginEmployee
                );
            }
            return !operationLimit.Equals(OperationLimit.Disable);
        }

        /// <summary>
        /// 操作履歴を出力するイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        protected virtual void WriteOperationLog(
            object sender,
            ToolClickEventArgsType e
        )
        {
            const string METHOD_NAME = "WriteOperationLog";
            if (!ToolButtonInfoMap.ContainsKey(e.Tool.Key)) return;

            ToolButtonInfo toolButtonInfo = ToolButtonInfoMap[e.Tool.Key];
            if (!toolButtonInfo.Value.Second) return;   // ログ記録の対象でなければ、何もしない

            Debug.WriteLine(PgName + "をツールボタン操作！");
            // 操作ログ出力
            OperationHistoryLogAcs.Instance.Policy.WriteOperationLog(
                this,
                LogDataKind.OperationLog,
                PgId,
                PgName,
                METHOD_NAME,
                toolButtonInfo.Value.First,
                DEFAULT_STATUS,
                DEFAULT_MESSAGE,
                DEFAULT_DATA
            );
        }

        #region <Override/>

        /// <see cref="OperationControlItem"/>
        public override void BeginControl()
        {
            foreach (ToolButtonInfo eToolButtonInfo in ToolButtonInfoMap.Values)
            {
                if (ToolBar.Tools[eToolButtonInfo.Key].SharedProps.Visible)
                {
                    ToolBar.Tools[eToolButtonInfo.Key].SharedProps.Visible = CanVisible(eToolButtonInfo);
                }
            }

            ToolBar.ToolClick += new ToolClickEventHandlerType(this.WriteOperationLog);
        }

        #endregion  // <Override/>
    }

    // --- ADD 2008/11/13 -------------------------------->>>>>
    /// <summary>
    /// 操作権限の制御ツールバークラス（マスメン用）
    /// </summary>
    public sealed class MasMainOperationToolBar : OperationToolBar
    {
        private const string _logPGID = "SFCMN09000U";

        public MasMainOperationToolBar(
            int categoryCode,
            string pgId,
            string pgName,
            Employee loginEmployee,
            ToolBarType toolBar,
            List<ToolButtonInfo> toolButtonInfoList
        ) : base(categoryCode,
            pgId,   // MOD 2009/02/18 不具合対応[8971] _logPGID→pgId
            pgName,
            loginEmployee,
            toolBar,
            toolButtonInfoList)
        {
        }

        /// <summary>
        /// 操作履歴を出力するイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        protected override void WriteOperationLog(
            object sender,
            ToolClickEventArgsType e
        )
        {
            const string METHOD_NAME = "WriteOperationLog";
            if (!ToolButtonInfoMap.ContainsKey(e.Tool.Key)) return;

            ToolButtonInfo toolButtonInfo = ToolButtonInfoMap[e.Tool.Key];
            if (!toolButtonInfo.Value.Second) return;   // ログ記録の対象でなければ、何もしない

            Debug.WriteLine(PgName + "をツールボタン操作！");
            // 操作ログ出力
            OperationHistoryLogAcs.Instance.Policy.WriteOperationLog(
                this,
                LogDataKind.OperationLog,
                _logPGID,
                PgName,
                METHOD_NAME,
                toolButtonInfo.Value.First,
                DEFAULT_STATUS,
                DEFAULT_MESSAGE,
                DEFAULT_DATA
            );
        }
    }

    /// <summary>
    /// 操作権限の制御ツールバークラス（帳票用）
    /// </summary>
    public sealed class ReportOperationToolBar : OperationToolBar
    {
        private const string _logPGID = "SFANL07200U";

        public ReportOperationToolBar(
            int categoryCode,
            string pgId,
            string pgName,
            Employee loginEmployee,
            ToolBarType toolBar,
            List<ToolButtonInfo> toolButtonInfoList
        ) : base(categoryCode,
            pgId,
            pgName,
            loginEmployee,
            toolBar,
            toolButtonInfoList)
        {
        }

        /// <summary>
        /// 操作履歴を出力するイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        protected override void WriteOperationLog(
            object sender,
            ToolClickEventArgsType e
        )
        {
            const string METHOD_NAME = "WriteOperationLog";
            if (!ToolButtonInfoMap.ContainsKey(e.Tool.Key)) return;

            ToolButtonInfo toolButtonInfo = ToolButtonInfoMap[e.Tool.Key];
            if (!toolButtonInfo.Value.Second) return;   // ログ記録の対象でなければ、何もしない

            Debug.WriteLine(PgName + "をツールボタン操作！");
            // 操作ログ出力
            OperationHistoryLogAcs.Instance.Policy.WriteOperationLog(
                this,
                LogDataKind.OperationLog,
                _logPGID,
                PgName,
                METHOD_NAME,
                toolButtonInfo.Value.First,
                DEFAULT_STATUS,
                DEFAULT_MESSAGE,
                DEFAULT_DATA
            );
        }
    }
    // --- ADD 2008/11/13 --------------------------------<<<<<

    #endregion  // <ツールバー/>
}

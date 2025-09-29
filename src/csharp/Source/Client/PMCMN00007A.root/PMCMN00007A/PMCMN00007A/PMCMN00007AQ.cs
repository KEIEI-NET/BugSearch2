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
// 修 正 日  2008/08/29  修正内容 : 新規作成
// 管理番号              作成担当 : 上野 俊治
// 修 正 日  2008/11/13  修正内容 : MasMainController、ReportControllerのAddControlItemにて
//                                : マスメン用、帳票用のツールバー、ボタン制御
//                                : インスタンスを生成するよう修正
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;

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

    #region <操作権限/>

    /// <summary>
    /// 操作権限インターフェース
    /// </summary>
    public interface IOperationAuthority
    {
        #region <対象とする機能/>

        /// <summary>
        /// カテゴリコードを取得します。（読取専用）
        /// </summary>
        /// <value>カテゴリコード</value>
        int CategoryCode { get; }

        /// <summary>
        /// プログラムID(アセンブリID)を取得します。（読取専用）
        /// </summary>
        /// <value>プログラムID</value>
        string ProgramId { get; }

        /// <summary>
        /// プログラム名称のアクセサ
        /// </summary>
        /// <value>プログラム名称</value>
        string ProgramName
        {
            get;
            set;
        }

        /// <summary>
        /// ログイン従業員を取得します。（読取専用）
        /// </summary>
        /// <value>ログイン従業員</value>
        Employee LoginEmployee { get; }

        #endregion  // <対象とする機能/>

        /// <summary>
        /// 起動可能か判定します。
        /// </summary>
        /// <returns>
        /// <c>true</c> :起動可<br/>
        /// <c>false</c>:起動不可
        /// </returns>
        bool CanRun();

        /// <summary>
        /// 操作可能か判定します。
        /// </summary>
        /// <param name="operationCode">オペレーションコード</param>
        /// <returns>
        /// <c>true</c> :操作可<br/>
        /// <c>false</c>:操作不可
        /// </returns>
        bool Enabled(int operationCode);

        /// <summary>
        /// 操作可能（ログ書き込み必要）か判定します。
        /// </summary>
        /// <param name="operationCode">オペレーションコード</param>
        /// <returns>
        /// <c>true</c> :操作可能（ログ書き込み必要）<br/>
        /// <c>false</c>:操作可能（ログ書き込み必要）ではない
        /// </returns>
        bool EnabledWithLog(int operationCode);

        /// <summary>
        /// 操作不可か判定します。
        /// </summary>
        /// <param name="operationCode">オペレーションコード</param>
        /// <returns>
        /// <c>true</c> :操作不可<br/>
        /// <c>false</c>:操作可
        /// </returns>
        bool Disabled(int operationCode);

        /// <summary>
        /// ロガーを取得します。（読取専用）
        /// </summary>
        /// <value>ロガー</value>
        OperationHistoryLogHelper Logger { get; }
    }

    /// <summary>
    /// 操作権限の実装クラス
    /// </summary>
    public sealed class OperationAuthorityImpl : IOperationAuthority
    {
        #region <IOperationAuthority メンバ/>

        #region <対象とする機能/>

        /// <summary>カテゴリコード</summary>
        private readonly int _categoryCode;
        /// <summary>
        /// カテゴリコードを取得します。（読取専用）
        /// </summary>
        /// <value>カテゴリコード</value>
        /// <see cref="IOperationAuthority"/>
        public int CategoryCode
        {
            get { return _categoryCode; }
        }

        /// <summary>プログラムID</summary>
        private readonly string _programId;
        /// <summary>
        /// プログラムID(アセンブリID)を取得します。（読取専用）
        /// </summary>
        /// <value>プログラムID</value>
        /// <see cref="IOperationAuthority"/>
        public string ProgramId
        {
            get { return _programId; }
        }

        /// <summary>プログラム名称</summary>
        private string _programName;
        /// <summary>
        /// プログラム名称のアクセサ
        /// </summary>
        /// <value>プログラム名称</value>
        /// <see cref="IOperationAuthority"/>
        public string ProgramName
        {
            get { return _programName; }
            set { _programName = value; }
        }

        /// <summary>ログイン従業員</summary>
        private readonly Employee _loginEmployee;
        /// <summary>
        /// ログイン従業員を取得します。（読取専用）
        /// </summary>
        /// <value>ログイン従業員</value>
        /// <see cref="IOperationAuthority"/>
        public Employee LoginEmployee
        {
            get { return _loginEmployee; }
        }

        #endregion  // <対象とする機能/>

        /// <summary>
        /// 起動可能か判定します。
        /// </summary>
        /// <returns>
        /// <c>true</c> :起動可<br/>
        /// <c>false</c>:起動不可
        /// </returns>
        /// <see cref="IOperationAuthority"/>
        public bool CanRun()
        {
            return CanRun(DEFAULT_RUN_OPERATION_CODE);
        }

        /// <summary>
        /// 操作可能か判定します。
        /// </summary>
        /// <param name="operationCode">オペレーションコード</param>
        /// <returns>
        /// <c>true</c> :操作可<br/>
        /// <c>false</c>:操作不可
        /// </returns>
        /// <see cref="IOperationAuthority"/>
        public bool Enabled(int operationCode)
        {
            //return GetOperationLimit(operationCode).Equals(OperationLimit.Enable);
            return GetOperationLimit(operationCode).Equals(OperationLimit.EnableWithLog);
        }

        /// <summary>
        /// 操作可能（ログ書き込み必要）か判定します。
        /// </summary>
        /// <param name="operationCode">オペレーションコード</param>
        /// <returns>
        /// <c>true</c> :操作可能（ログ書き込み必要）<br/>
        /// <c>false</c>:操作可能（ログ書き込み必要）ではない
        /// </returns>
        /// <see cref="IOperationAuthority"/>
        public bool EnabledWithLog(int operationCode)
        {
            return GetOperationLimit(operationCode).Equals(OperationLimit.EnableWithLog);
        }

        /// <summary>
        /// 操作不可か判定します。
        /// </summary>
        /// <param name="operationCode">オペレーションコード</param>
        /// <returns>
        /// <c>true</c> :操作不可<br/>
        /// <c>false</c>:操作可
        /// </returns>
        /// <see cref="IOperationAuthority"/>
        public bool Disabled(int operationCode)
        {
            return GetOperationLimit(operationCode).Equals(OperationLimit.Disable);
        }

        /// <summary>ロガー</summary>
        private readonly OperationHistoryLogHelper _logger;
        /// <summary>
        /// ロガーを取得します。（読取専用）
        /// </summary>
        /// <value>ロガー</value>
        /// <see cref="IOperationAuthority"/>
        public OperationHistoryLogHelper Logger
        {
            get { return _logger; }
        }

        #endregion  // <IOperationAuthority メンバ/>

        /// <summary>起動操作のオペレーションコードのデフォルト値</summary>
        public const int DEFAULT_RUN_OPERATION_CODE = 0;

        #region <Constructor/>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <remarks>
        /// 設定されるプログラムID(アセンブリID)に拡張子が含まれる場合、拡張子は除外されます。
        /// </remarks>
        /// <param name="categoryCode">カテゴリーコード</param>
        /// <param name="programId">プログラムID（またはアセンブリID）</param>
        /// <param name="owner">所有者</param>
        /// <exception cref="ArgumentNullException">プログラムIDが<c>null</c>または空です。</exception>
        public OperationAuthorityImpl(
            EntityUtil.CategoryCode categoryCode,
            string programId,
            object owner
        )
        {
            #region <Guard Phrase/>

            if (string.IsNullOrEmpty(programId)) throw new ArgumentNullException("programId is null or empty.");

            #endregion  // <Guard Phrase/>

            _categoryCode   = (int)categoryCode;
            _programId      = GetProgramId(programId);
            _programName    = OperationMasterAcs.Instance.Policy.GetProgramName(_programId);
            _loginEmployee  = LoginInfoAcquisition.Employee;

            _logger = new OperationHistoryLogHelper(this, owner);
        }

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <remarks>
        /// 設定されるプログラムID(アセンブリID)に拡張子が含まれる場合、拡張子は除外されます。
        /// </remarks>
        /// <param name="categoryCode">カテゴリーコード</param>
        /// <param name="programId">プログラムID（またはアセンブリID）</param>
        /// <exception cref="ArgumentNullException">プログラムIDが<c>null</c>または空です。</exception>
        public OperationAuthorityImpl(
            EntityUtil.CategoryCode categoryCode,
            string programId
        ) : this(categoryCode, programId, null)
        { }

        #endregion  // <Constructor/>

        /// <summary>
        /// 操作権限を取得します。
        /// </summary>
        /// <param name="operationCode">オペレーションコード</param>
        /// <returns>操作権限</returns>
        public OperationLimit GetOperationLimit(int operationCode)
        {
            OperationLimit operationLimit = OperationLimit.Enable;
            if (OperationMasterAcs.Instance.Policy.IsTargetOperation(CategoryCode, ProgramId, operationCode))
            {
                operationLimit = OperationLimitationAcs.Instance.Policy.GetOperationLimit(
                    CategoryCode,
                    ProgramId,
                    operationCode,
                    LoginEmployee);
            }
            return operationLimit;
        }

        /// <summary>
        /// 起動可能か判定します。
        /// </summary>
        /// <param name="startOperationCode">起動操作のオペレーションコード</param>
        /// <returns>
        /// <c>true</c> :起動可<br/>
        /// <c>false</c>:起動不可
        /// </returns>
        public bool CanRun(int startOperationCode)
        {
            return !GetOperationLimit(startOperationCode).Equals(OperationLimit.Disable);
        }

        /// <summary>
        /// プログラムIDを取得します。
        /// </summary>
        /// <param name="assemblyId">アセンブリID</param>
        /// <returns>プログラムID</returns>
        private static string GetProgramId(string assemblyId)
        {
            string pgId = string.Empty;
            if (Path.HasExtension(assemblyId.Trim()))
            {
                pgId = Path.GetFileNameWithoutExtension(assemblyId.Trim());
            }
            else
            {
                pgId = assemblyId.Trim();
            }
            return pgId;
        }
    }

    #endregion  // <操作権限/>

    #region <操作履歴ログクラスのヘルパ/>

    /// <summary>
    /// 操作履歴ログクラスのヘルパクラス
    /// </summary>
    public sealed class OperationHistoryLogHelper
    {
        #region <所有者/>

        /// <summary>所有者</summary>
        private readonly object _owner;
        /// <summary>
        /// 所有者を取得します。
        /// </summary>
        /// <value>所有者</value>
        private object Owner
        {
            get
            {
                if (_owner == null) return Parent;
                return _owner;
            }
        }

        /// <summary>親オブジェクト</summary>
        private readonly IOperationAuthority _parent;
        /// <summary>
        /// 親オブジェクトを取得します。
        /// </summary>
        /// <value>親オブジェクト</value>
        private IOperationAuthority Parent
        {
            get { return _parent; }
        }

        #endregion  // <所有者/>

        #region <Constructor/>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="parent">親オブジェクト</param>
        /// <param name="owner">所有者</param>
        public OperationHistoryLogHelper(
            IOperationAuthority parent,
            object owner
        )
        {
            _parent= parent;
            _owner = owner;
        }

        #endregion  // <Constructor/>

        /// <summary>
        /// 操作履歴ログの書込みオブジェクトを取得します。
        /// </summary>
        /// <value>操作履歴ログの書込みオブジェクト</value>
        public static OperationHistoryLog Writer
        {
            get { return OperationHistoryLogAcs.Instance.Policy; }
        }

        #region <操作履歴ログの書込み/>

        /// <summary>
        /// 操作履歴ログを書き込みます。
        /// </summary>
        /// <remarks>
        /// ログ書き込みが不要な操作であれば、ログ書き込みを行いません。
        /// </remarks>
        /// <param name="logDataKind">ログ種別</param>
        /// <param name="methodName">ログを発生させたメソッド名</param>
        /// <param name="operationCode">
        /// オペレーションコード<br/>
        /// ※オペレーションマスタの登録内容と整合性が取れている必要があります。
        /// </param>
        /// <param name="status">ステータス（エラーステータスなど）</param>
        /// <param name="message">メッセージ（エラー内容・処理内容など）</param>
        /// <param name="data">データ（エラー原因のデータのキー／詳細説明など）</param>
        public void WriteOperationLog(
            LogDataKind logDataKind,
            string methodName,
            int operationCode,
            int status,
            string message,
            string data
        )
        {
            if (Parent.EnabledWithLog(operationCode))
            {
                Writer.WriteOperationLog(
                    Owner,
                    logDataKind,
                    Parent.ProgramId,
                    Parent.ProgramName,
                    methodName,
                    operationCode,
                    status,
                    message,
                    data
                );
            }
        }

        /// <summary>
        /// 操作履歴ログを書き込みます。
        /// </summary>
        /// <remarks>
        /// ログ書き込みが不要な操作であれば、ログ書き込みを行いません。
        /// </remarks>
        /// <param name="logDataCreateDateTime">ログデータ作成日時</param>
        /// <param name="logDataKind">ログ種別</param>
        /// <param name="methodName">ログを発生させたメソッド名</param>
        /// <param name="operationCode">
        /// オペレーションコード<br/>
        /// ※オペレーションマスタの登録内容と整合性が取れている必要があります。
        /// </param>
        /// <param name="status">ステータス（エラーステータスなど）</param>
        /// <param name="message">メッセージ（エラー内容・処理内容など）</param>
        /// <param name="data">データ（エラー原因のデータのキー／詳細説明など）</param>
        public void WriteOperationLog(
            DateTime logDataCreateDateTime,
            LogDataKind logDataKind,
            string methodName,
            int operationCode,
            int status,
            string message,
            string data
        )
        {
            if (Parent.EnabledWithLog(operationCode))
            {
                Writer.WriteOperationLog(
                    Owner,
                    logDataCreateDateTime,
                    logDataKind,
                    Parent.ProgramId,
                    Parent.ProgramName,
                    methodName,
                    operationCode,
                    status,
                    message,
                    data
                );
            }
        }

        /// <summary>
        /// 操作履歴ログを書き込みます。
        /// </summary>
        /// <remarks>
        /// ログ書き込みが不要な操作であれば、ログ書き込みを行いません。
        /// </remarks>
        /// <param name="methodName">ログを発生させたメソッド名</param>
        /// <param name="operationCode">
        /// オペレーションコード<br/>
        /// ※オペレーションマスタの登録内容と整合性が取れている必要があります。
        /// </param>
        public void WriteOperationLog(
            string methodName,
            int operationCode
        )
        {
            WriteOperationLog(
                LogDataKind.OperationLog,
                methodName,
                operationCode,
                OperationControlItem.DEFAULT_STATUS,
                OperationControlItem.DEFAULT_MESSAGE,
                OperationControlItem.DEFAULT_DATA
            );
        }

        /// <summary>
        /// 操作履歴ログを書き込みます。
        /// </summary>
        /// <remarks>
        /// ログ書き込みが不要な操作であれば、ログ書き込みを行いません。
        /// </remarks>
        /// <param name="logDataCreateDateTime">ログデータ作成日時</param>
        /// <param name="methodName">ログを発生させたメソッド名</param>
        /// <param name="operationCode">
        /// オペレーションコード<br/>
        /// ※オペレーションマスタの登録内容と整合性が取れている必要があります。
        /// </param>
        public void WriteOperationLog(
            DateTime logDataCreateDateTime,
            string methodName,
            int operationCode
        )
        {
            WriteOperationLog(
                logDataCreateDateTime,
                LogDataKind.OperationLog,
                methodName,
                operationCode,
                OperationControlItem.DEFAULT_STATUS,
                OperationControlItem.DEFAULT_MESSAGE,
                OperationControlItem.DEFAULT_DATA
            );
        }

        /// <summary>
        /// 操作履歴ログを書き込みます。
        /// </summary>
        /// <remarks>
        /// ログ書き込みが不要な操作であれば、ログ書き込みを行いません。
        /// </remarks>
        /// <param name="methodName">ログを発生させたメソッド名</param>
        /// <param name="operationCode">
        /// オペレーションコード<br/>
        /// ※オペレーションマスタの登録内容と整合性が取れている必要があります。
        /// </param>
        /// <param name="status">ステータス（エラーステータスなど）</param>
        /// <param name="message">メッセージ（エラー内容・処理内容など）</param>
        public void WriteOperationLog(
            string methodName,
            int operationCode,
            int status,
            string message
        )
        {
            WriteOperationLog(
                LogDataKind.OperationLog,
                methodName,
                operationCode,
                status,
                message,
                OperationControlItem.DEFAULT_DATA
            );
        }

        /// <summary>
        /// 操作履歴ログを書き込みます。
        /// </summary>
        /// <remarks>
        /// ログ書き込みが不要な操作であれば、ログ書き込みを行いません。
        /// </remarks>
        /// <param name="logDataCreateDateTime">ログデータ作成日時</param>
        /// <param name="methodName">ログを発生させたメソッド名</param>
        /// <param name="operationCode">
        /// オペレーションコード<br/>
        /// ※オペレーションマスタの登録内容と整合性が取れている必要があります。
        /// </param>
        /// <param name="status">ステータス（エラーステータスなど）</param>
        /// <param name="message">メッセージ（エラー内容・処理内容など）</param>
        public void WriteOperationLog(
            DateTime logDataCreateDateTime,
            string methodName,
            int operationCode,
            int status,
            string message
        )
        {
            WriteOperationLog(
                logDataCreateDateTime,
                LogDataKind.OperationLog,
                methodName,
                operationCode,
                status,
                message,
                OperationControlItem.DEFAULT_DATA
            );
        }

        #endregion  // <操作履歴ログの書込み/>
    }

    #endregion  // <操作履歴ログクラスのヘルパ/>

    #region <操作権限の制御オブジェクト/>

    /// <summary>
    /// 操作権限の設定に従って、コントロールを制御するクラス
    /// </summary>
    public abstract class OperationAuthorityController : IOperationAuthority
    {
        #region <IOperationAuthority メンバ/>

        #region <対象とする機能/>

        /// <summary>
        /// カテゴリコードを取得します。
        /// </summary>
        /// <value>カテゴリコード</value>
        /// <see cref="IOperationAuthority"/>
        public int CategoryCode
        {
            get { return OpeAuthComponent.CategoryCode; }
        }

        /// <summary>
        /// プログラムID(アセンブリID)のアクセサ
        /// </summary>
        /// <value>プログラムID</value>
        /// <see cref="IOperationAuthority"/>
        public string ProgramId
        {
            get { return OpeAuthComponent.ProgramId; }
        }

        /// <summary>
        /// プログラム名称を取得します。
        /// </summary>
        /// <value>プログラム名称</value>
        /// <see cref="IOperationAuthority"/>
        public string ProgramName
        {
            get { return OpeAuthComponent.ProgramName; }
            set { OpeAuthComponent.ProgramName = value; }
        }

        /// <summary>
        /// ログイン従業員を取得します。
        /// </summary>
        /// <value>ログイン従業員</value>
        /// <see cref="IOperationAuthority"/>
        public Employee LoginEmployee
        {
            get { return OpeAuthComponent.LoginEmployee; }
        }

        #endregion  // <対象とする機能/>

        /// <summary>
        /// 起動可能か判定します。
        /// </summary>
        /// <returns><c>true</c> :起動可<br/><c>false</c>:起動不可</returns>
        /// <see cref="IOperationAuthority"/>
        public virtual bool CanRun()
        {
            return OpeAuthComponent.CanRun();
        }

        /// <summary>
        /// 操作可能か判定します。
        /// </summary>
        /// <param name="operationCode">オペレーションコード</param>
        /// <returns>
        /// <c>true</c> :操作可<br/>
        /// <c>false</c>:操作不可
        /// </returns>
        /// <see cref="IOperationAuthority"/>
        public bool Enabled(int operationCode)
        {
            return OpeAuthComponent.Enabled(operationCode);
        }

        /// <summary>
        /// 操作可能（ログ書き込み必要）か判定します。
        /// </summary>
        /// <param name="operationCode">オペレーションコード</param>
        /// <returns>
        /// <c>true</c> :操作可能（ログ書き込み必要）<br/>
        /// <c>false</c>:操作可能（ログ書き込み必要）ではない
        /// </returns>
        /// <see cref="IOperationAuthority"/>
        public bool EnabledWithLog(int operationCode)
        {
            return OpeAuthComponent.EnabledWithLog(operationCode);
        }

        /// <summary>
        /// 操作不可か判定します。
        /// </summary>
        /// <param name="operationCode">オペレーションコード</param>
        /// <returns>
        /// <c>true</c> :操作不可<br/>
        /// <c>false</c>:操作可
        /// </returns>
        /// <see cref="IOperationAuthority"/>
        public bool Disabled(int operationCode)
        {
            return OpeAuthComponent.Disabled(operationCode);
        }

        /// <summary>
        /// ロガーを取得します。（読取専用）
        /// </summary>
        /// <value>ロガー</value>
        /// <see cref="IOperationAuthority"/>
        public OperationHistoryLogHelper Logger
        {
            get { return OpeAuthComponent.Logger; }
        }

        #endregion  // <IOperationAuthority メンバ/>

        #region <操作権限コンポーネント/>

        /// <summary>操作権限コンポーネント</summary>
        private readonly IOperationAuthority _opeAuthComponent;
        /// <summary>
        /// 操作権限コンポーネントを取得します。
        /// </summary>
        /// <value>操作権限コンポーネント</value>
        protected IOperationAuthority OpeAuthComponent
        {
            get { return _opeAuthComponent; }
        }

        #endregion  // <操作権限コンポーネント/>

        #region <操作権限の制御コントロール/>

        /// <summary>操作権限の制御コントロールのリスト</summary>
        private readonly List<OperationControlItem> _controlItemList;
        /// <summary>
        /// 操作権限の制御コントロールのリストを取得します。
        /// </summary>
        /// <value>操作権限の制御コントロールのリスト</value>
        protected List<OperationControlItem> ControlItemList
        {
            get { return _controlItemList; }
        }

        #endregion  // <操作権限の制御コントロール/>

        #region <Constructor/>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <remarks>
        /// 設定されるプログラムID(アセンブリID)に拡張子が含まれる場合、拡張子は除外されます。
        /// </remarks>
        /// <param name="categoryCode">カテゴリコード</param>
        /// <param name="assemblyId">アセンブリID</param>
        protected OperationAuthorityController(
            EntityUtil.CategoryCode categoryCode,
            string assemblyId
        )
        {
            _opeAuthComponent = new OperationAuthorityImpl(categoryCode, assemblyId);
            _controlItemList= new List<OperationControlItem>();
        }

        #endregion  // <Constructor/>

        /// <summary>
        /// 操作権限の制御を行うボタンコントロールを追加します。
        /// </summary>
        /// <param name="button">操作権限の制御を行うボタンコントロール</param>
        /// <param name="operationCode">オペレーションコード</param>
        /// <param name="withLogs">ログ記録を行うフラグ</param>
        /// <exception cref="ArgumentNullException"><c>button</c>が<c>null</c>です。</exception>
        /// <see cref="IOperationAuthority"/>
        public virtual void AddControlItem(
            ButtonType button,
            int operationCode,
            bool withLogs
        )
        {
            #region <Guard Pharse/>

            if (button == null) throw new ArgumentNullException("button is null.");

            #endregion  // <Guard Phrase/>

            ControlItemList.Add(new OperationButton(
                CategoryCode,
                ProgramId,
                ProgramName,
                operationCode,
                LoginEmployee,
                button,
                withLogs
            ));
        }

        /// <summary>
        /// 操作権限の制御を行うツールバーコントロールを追加します。
        /// </summary>
        /// <param name="toolBar">操作権限の制御を行うツールバーコントロール</param>
        /// <param name="toolButtonInfoList">対象とするツールボタン情報のリスト</param>
        /// <exception cref="ArgumentNullException">
        /// <c>toolBar</c>が<c>null</c>です。<br/>
        /// または<c>toolButtonInfoList</c>が<c>null</c>です。
        /// </exception>
        public virtual void AddControlItem(
            ToolBarType toolBar,
            List<ToolButtonInfo> toolButtonInfoList
        )
        {
            #region <Guard Pharse/>

            if (toolBar == null)            throw new ArgumentNullException("toolBar is null.");
            if (toolButtonInfoList == null) throw new ArgumentNullException("toolButtonInfoList is null.");

            #endregion  // <Guard Phrase/>

            ControlItemList.Add(new OperationToolBar(
                CategoryCode,
                ProgramId,
                ProgramName,
                LoginEmployee,
                toolBar,
                toolButtonInfoList
            ));
        }

        /// <summary>
        /// 操作権限の制御を開始します。
        /// </summary>
        /// <see cref="IOperationAuthority"/>
        public void BeginControl()
        {
            foreach (OperationControlItem eItem in ControlItemList)
            {
                eItem.BeginControl();
            }
        }

        /// <summary>
        /// 起動可能か判定します。
        /// </summary>
        /// <param name="startOperationCode">起動操作のオペレーションコード</param>
        /// <returns><c>true</c> :起動可<br/><c>false:</c>起動不可</returns>
        protected bool CanRun(int startOperationCode)
        {
            try
            {
                return ((OperationAuthorityImpl)OpeAuthComponent).CanRun(startOperationCode);
            }
            catch (InvalidCastException e)
            {
                Debug.WriteLine(e.ToString());
                return false;
            }
        }
    }

    #region <マスメン/>

    /// <summary>
    /// マスメンフレームのオペレーションコード
    /// </summary>
    public enum MasMainFrameOpeCode : int
    {
        /// <summary>起動</summary>
        Run = 0,
        /// <summary>追加(新規)</summary>
        New = 1,
        /// <summary>更新(修正)</summary>
        Modify = 2,
        /// <summary>削除</summary>
        Delete = 3,
        /// <summary>完全削除</summary>
        DeletePhysically = 4,
        /// <summary>復旧</summary>
        Revival = 5,
        /// <summary>印刷</summary>
        Print = 6,
        /// <summary>詳細</summary>
        Details = 7
    }

    /// <summary>
    /// 操作権限の設定に従って、コントロールを制御するクラス(マスメン用)
    /// </summary>
    public sealed class MasMainController : OperationAuthorityController
    {
        #region <Constructor/>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="assemblyId">アセンブリID</param>
        public MasMainController(string assemblyId) : base(EntityUtil.CategoryCode.MasterMaintenance, assemblyId)
        {
            const string METHOD_NAME = "MasMainController";

            OperationLimit operationLimit = OperationLimit.Enable;

            if (OperationMasterAcs.Instance.Policy.IsTargetOperation(CategoryCode, ProgramId, (int)ReportFrameOpeCode.Run))
            {
                operationLimit = OperationLimitationAcs.Instance.Policy.GetOperationLimit(
                    CategoryCode,
                    ProgramId,
                    (int)MasMainFrameOpeCode.Run,
                    LoginEmployee
                );
            }

            if (operationLimit.Equals(OperationLimit.EnableWithLog))
            {
                string programName = OperationMasterAcs.Instance.Policy.GetProgramName(ProgramId);
                Debug.WriteLine(programName + "を起動！");
                // 操作ログ出力
                OperationHistoryLogAcs.Instance.Policy.WriteOperationLog(
                    this,
                    LogDataKind.OperationLog,
                    ProgramId,
                    programName,
                    METHOD_NAME,
                    (int)MasMainFrameOpeCode.Run,
                    OperationControlItem.DEFAULT_STATUS,
                    OperationControlItem.DEFAULT_MESSAGE,
                    OperationControlItem.DEFAULT_DATA
                );
            }
        }

        #endregion  // <Constructor/>

        #region <Override/>

        /// <see cref="OperationAuthorityController"/>
        public override bool CanRun()
        {
            return base.CanRun((int)MasMainFrameOpeCode.Run);
        }

        // --- ADD 2008/11/13 -------------------------------->>>>>
        /// <summary>
        /// 操作権限の制御を行うボタンコントロールを追加します。
        /// </summary>
        /// <param name="button">操作権限の制御を行うボタンコントロール</param>
        /// <param name="operationCode">オペレーションコード</param>
        /// <param name="withLogs">ログ記録を行うフラグ</param>
        /// <exception cref="ArgumentNullException"><c>button</c>が<c>null</c>です。</exception>
        /// <see cref="IOperationAuthority"/>
        public override void AddControlItem(
            ButtonType button,
            int operationCode,
            bool withLogs
        )
        {
            #region <Guard Pharse/>

            if (button == null) throw new ArgumentNullException("button is null.");

            #endregion  // <Guard Phrase/>

            ControlItemList.Add(new MasMainOperationButton(
                CategoryCode,
                ProgramId,
                ProgramName,
                operationCode,
                LoginEmployee,
                button,
                withLogs
            ));
        }

        /// <summary>
        /// 操作権限の制御を行うツールバーコントロールを追加します。
        /// </summary>
        /// <param name="toolBar">操作権限の制御を行うツールバーコントロール</param>
        /// <param name="toolButtonInfoList">対象とするツールボタン情報のリスト</param>
        /// <exception cref="ArgumentNullException">
        /// <c>toolBar</c>が<c>null</c>です。<br/>
        /// または<c>toolButtonInfoList</c>が<c>null</c>です。
        /// </exception>
        public override void AddControlItem(
            ToolBarType toolBar,
            List<ToolButtonInfo> toolButtonInfoList
        )
        {
            #region <Guard Pharse/>

            if (toolBar == null) throw new ArgumentNullException("toolBar is null.");
            if (toolButtonInfoList == null) throw new ArgumentNullException("toolButtonInfoList is null.");

            #endregion  // <Guard Phrase/>

            ControlItemList.Add(new MasMainOperationToolBar(
                CategoryCode,
                ProgramId,
                ProgramName,
                LoginEmployee,
                toolBar,
                toolButtonInfoList
            ));
        }
        // --- ADD 2008/11/13 --------------------------------<<<<<

        #endregion  // <Override/>

        /// <summary>
        /// 操作権限の制御を行うボタンコントロールを追加します。
        /// </summary>
        /// <param name="operationCode">オペレーションコード</param>
        /// <param name="button">操作権限の制御を行うボタンコントロール</param>
        /// <param name="withLogs">ログ記録を行うフラグ</param>
        /// <exception cref="ArgumentNullException"><c>button</c>が<c>null</c>です。</exception>
        public void AddControlItem(
            MasMainFrameOpeCode operationCode,
            ButtonType button,
            bool withLogs
        )
        {
            //base.AddControlItem(button, (int)operationCode, withLogs); // DEL 2008/11/13
            this.AddControlItem(button, (int)operationCode, withLogs); // ADD 2008/11/13
        }
    }

    /// <summary>
    /// マスメンのツールボタン情報クラス
    /// </summary>
    public sealed class MasMainToolButtonInfo : ToolButtonInfo
    {
        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="key">キー</param>
        /// <param name="operationCode">オペレーションコード</param>
        /// <param name="withLogs">ログ記録するフラグ</param>
        public MasMainToolButtonInfo(
            string key,
            MasMainFrameOpeCode operationCode,
            bool withLogs
        ) : base(key, (int)operationCode, withLogs)
        { }
    }

    #endregion  // <マスメン/>

    #region <帳票/>

    /// <summary>
    /// 帳票フレームのオペレーションコード
    /// </summary>
    public enum ReportFrameOpeCode : int
    {
        /// <summary>起動</summary>
        Run = 0,
        /// <summary>PDF出力(PDF表示)</summary>
        OutputPDF = 1,
        /// <summary>印刷</summary>
        Print = 2,
        /// <summary>抽出</summary>
        Extract = 3,
        /// <summary>PDF履歴保存</summary>
        SavePDF = 4,
        /// <summary>テキスト出力</summary>
        OutputText = 5,
        /// <summary>グラフ表示</summary>
        ShowGraph = 6,
        /// <summary>設定</summary>
        Setup = 7
    }

    /// <summary>
    /// 操作権限の設定に従って、コントロールを制御するクラス(帳票用)
    /// </summary>
    public sealed class ReportController : OperationAuthorityController
    {
        #region <Constructor/>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="assemblyId">アセンブリID</param>
        public ReportController(string assemblyId) : base(EntityUtil.CategoryCode.Report, assemblyId)
        {
            const string METHOD_NAME = "ReportController";

            OperationLimit operationLimit = OperationLimit.Enable;

            if (OperationMasterAcs.Instance.Policy.IsTargetOperation(CategoryCode, ProgramId, (int)ReportFrameOpeCode.Run))
            {
                operationLimit = OperationLimitationAcs.Instance.Policy.GetOperationLimit(
                    CategoryCode,
                    ProgramId,
                    (int)ReportFrameOpeCode.Run,
                    LoginEmployee
                );
            }

            if (operationLimit.Equals(OperationLimit.EnableWithLog))
            {
                string programName = OperationMasterAcs.Instance.Policy.GetProgramName(ProgramId);
                Debug.WriteLine(programName + "を起動！");
                // 操作ログ出力
                OperationHistoryLogAcs.Instance.Policy.WriteOperationLog(
                    this,
                    LogDataKind.OperationLog,
                    ProgramId,
                    programName,
                    METHOD_NAME,
                    (int)ReportFrameOpeCode.Run,
                    OperationControlItem.DEFAULT_STATUS,
                    OperationControlItem.DEFAULT_MESSAGE,
                    OperationControlItem.DEFAULT_DATA
                );
            }
        }

        #endregion  // <Constructor/>

        #region <Override/>

        /// <see cref="OperationAuthorityController"/>
        public override bool CanRun()
        {
            return base.CanRun((int)ReportFrameOpeCode.Run);
        }

        // --- ADD 2008/11/13 -------------------------------->>>>>
        /// <summary>
        /// 操作権限の制御を行うツールバーコントロールを追加します。
        /// </summary>
        /// <param name="toolBar">操作権限の制御を行うツールバーコントロール</param>
        /// <param name="toolButtonInfoList">対象とするツールボタン情報のリスト</param>
        /// <exception cref="ArgumentNullException">
        /// <c>toolBar</c>が<c>null</c>です。<br/>
        /// または<c>toolButtonInfoList</c>が<c>null</c>です。
        /// </exception>
        public override void AddControlItem(
            ToolBarType toolBar,
            List<ToolButtonInfo> toolButtonInfoList
        )
        {
            #region <Guard Pharse/>

            if (toolBar == null) throw new ArgumentNullException("toolBar is null.");
            if (toolButtonInfoList == null) throw new ArgumentNullException("toolButtonInfoList is null.");

            #endregion  // <Guard Phrase/>

            ControlItemList.Add(new ReportOperationToolBar(
                CategoryCode,
                ProgramId,
                ProgramName,
                LoginEmployee,
                toolBar,
                toolButtonInfoList
            ));
        }
        // --- ADD 2008/11/13 --------------------------------<<<<<

        #endregion  // <Override/>

        

        /// <summary>
        /// 操作権限の制御を行うボタンコントロールを追加します。
        /// </summary>
        /// <param name="operationCode">オペレーションコード</param>
        /// <param name="button">操作権限の制御を行うボタンコントロール</param>
        /// <param name="withLogs">ログ記録を行うフラグ</param>
        /// <exception cref="ArgumentNullException"><c>button</c>が<c>null</c>です。</exception>
        public void AddControlItem(
            ReportFrameOpeCode operationCode,
            ButtonType button,
            bool withLogs
        )
        {
            //base.AddControlItem(button, (int)operationCode, withLogs); // DEL 2008/11/13
            this.AddControlItem(button, (int)operationCode, withLogs); // ADD 2008/11/13
        }
    }

    /// <summary>
    /// 帳票のツールボタン情報クラス
    /// </summary>
    public sealed class ReportToolButtonInfo : ToolButtonInfo
    {
        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="key">キー</param>
        /// <param name="operationCode">オペレーションコード</param>
        /// <param name="withLogs">ログ記録するフラグ</param>
        public ReportToolButtonInfo(
            string key,
            ReportFrameOpeCode operationCode,
            bool withLogs
        ) : base(key, (int)operationCode, withLogs)
        { }
    }

    #endregion  // <帳票/>

    #region <エントリ/>

    /// <summary>
    /// エントリフレームのオペレーションコード
    /// </summary>
    public enum EntryFrameOpeCode : int
    {
        /// <summary>起動</summary>
        Run = 0
    }

    /// <summary>
    /// 操作権限の設定に従って、コントロールを制御するクラス(エントリ用)
    /// </summary>
    public sealed class EntryController : OperationAuthorityController
    {
        #region <Constructor/>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="assemblyId">アセンブリID</param>
        public EntryController(string assemblyId) : base(EntityUtil.CategoryCode.Entry, assemblyId)
        {
            const string METHOD_NAME = "EntryController";

            OperationLimit operationLimit = OperationLimit.Enable;

            if (OperationMasterAcs.Instance.Policy.IsTargetOperation(CategoryCode, ProgramId, (int)EntryFrameOpeCode.Run))
            {
                operationLimit = OperationLimitationAcs.Instance.Policy.GetOperationLimit(
                    CategoryCode,
                    ProgramId,
                    (int)EntryFrameOpeCode.Run,
                    LoginEmployee
                );
            }

            if (operationLimit.Equals(OperationLimit.EnableWithLog))
            {
                string programName = OperationMasterAcs.Instance.Policy.GetProgramName(ProgramId);
                Debug.WriteLine(programName + "を起動！");
                // 操作ログ出力
                OperationHistoryLogAcs.Instance.Policy.WriteOperationLog(
                    this,
                    LogDataKind.OperationLog,
                    ProgramId,
                    programName,
                    METHOD_NAME,
                    (int)EntryFrameOpeCode.Run,
                    OperationControlItem.DEFAULT_STATUS,
                    OperationControlItem.DEFAULT_MESSAGE,
                    OperationControlItem.DEFAULT_DATA
                );
            }
        }

        #endregion  // <Constructor/>

        #region <Override/>

        /// <see cref="OperationAuthorityController"/>
        public override bool CanRun()
        {
            return base.CanRun((int)EntryFrameOpeCode.Run);
        }

        #endregion  // <Override/>
    }

    /// <summary>
    /// エントリのツールボタン情報クラス
    /// </summary>
    public sealed class EntryToolButtonInfo : ToolButtonInfo
    {
        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="key">キー</param>
        /// <param name="operationCode">オペレーションコード</param>
        /// <param name="withLogs">ログ記録するフラグ</param>
        public EntryToolButtonInfo(
            string key,
            int operationCode,
            bool withLogs
        ) : base(key, operationCode, withLogs)
        { }
    }

    #endregion  // <エントリ/>

    #endregion  // <操作権限の制御オブジェクト/>
}

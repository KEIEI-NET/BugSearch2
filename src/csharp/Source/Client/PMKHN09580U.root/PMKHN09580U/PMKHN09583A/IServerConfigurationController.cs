//****************************************************************************//
// システム         : プリンタ設定マスタ（サーバ用）
// プログラム名称   : プリンタ設定マスタ（サーバ用）コントローラ
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2009/09/16  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Data;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// サーバ構成設定コントローラインターフェース
    /// </summary>
    public interface IServerConfigurationController
    {
        /// <summary>
        /// 企業コードを取得します。
        /// </summary>
        string EnterpriseCode { get; }

        /// <summary>
        /// 拠点コードを取得します。
        /// </summary>
        string SectionCode { get; }

        /// <summary>
        /// DBを取得します。
        /// </summary>
        DataSet DBModel { get; }

        /// <summary>
        /// デフォルトビューを取得します。
        /// </summary>
        DataView DefaultView { get; }

        /// <summary>
        /// ロードします。
        /// </summary>
        void Load();

        /// <summary>
        /// レコードを書込みます。
        /// </summary>
        void WriteRecord();

        /// <summary>
        /// レコードを論理削除します。
        /// </summary>
        void DeleteRecord();

        /// <summary>
        /// レコードを復活させます。
        /// </summary>
        void ReviveRecord();

        /// <summary>
        /// レコードを物理削除します。
        /// </summary>
        void DestroyRecord();

        /// <summary>
        /// インポートします。
        /// </summary>
        void Import();

        /// <summary>表示を更新するイベント</summary>
        event UpdateViewEventHandler UpdatingView;
    }

    #region <表示更新イベント定義>

    /// <summary>
    /// 表示更新イベントハンドラ
    /// </summary>
    /// <param name="sender">イベントソース</param>
    /// <param name="e">イベントパラメータ</param>
    public delegate void UpdateViewEventHandler(
        object sender,
        UpdateViewEventArgs e
    );

    /// <summary>
    /// 表示更新イベントパラメータクラス
    /// </summary>
    public sealed class UpdateViewEventArgs : EventArgs
    {
        #region <元となったイベントのパラメータ>

        /// <summary>元となったイベントのパラメータ</summary>
        private readonly EventArgs _innerEventArgs;
        /// <summary>元となったイベントのパラメータを取得します。</summary>
        public EventArgs InnerEventArgs { get { return _innerEventArgs; } }

        #endregion // </元となったイベントのパラメータ>

        #region <Constructor>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public UpdateViewEventArgs() : this(new EventArgs()) { }

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="innerEventArgs">元となったイベントのパラメータ</param>
        public UpdateViewEventArgs(EventArgs innerEventArgs) : base()
        {
            _innerEventArgs = innerEventArgs;
        }

        #endregion // </Constructor>
    }

    #endregion // </表示更新イベント定義>
}

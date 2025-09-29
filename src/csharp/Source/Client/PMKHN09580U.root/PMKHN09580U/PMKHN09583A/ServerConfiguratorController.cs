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
using System.Diagnostics;

using Broadleaf.Application.Common;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// サーバ構成設定コントローラクラス
    /// </summary>
    /// <typeparam name="TDataSet">データセットの型</typeparam>
    public abstract class ServerConfiguratorController<TDataSet> : IServerConfigurationController
        where TDataSet : DataSet, new()
    {
        #region <IServerConfigurationController メンバ>

        /// <summary>企業コード</summary>
        private readonly string _enterpriseCode;
        /// <summary>企業コードを取得します。</summary>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
        }

        /// <summary>
        /// 拠点コードを取得します。
        /// </summary>
        public string SectionCode
        {
            get { return string.Empty; }
        }

        /// <summary>
        /// DBを取得します。
        /// </summary>
        public DataSet DBModel
        {
            get { return DBEntity; }
        }

        /// <summary>
        /// デフォルトビューを取得します。
        /// </summary>
        public DataView DefaultView
        {
            get
            {
                if (DBEntity == null)
                {
                    return new TDataSet().Tables[0].DefaultView;
                }
                return DBEntity.Tables[0].DefaultView;
            }
        }

        /// <summary>
        /// ロードします。
        /// </summary>
        public void Load()
        {
            _dbEntity = LoadOwnDB();
        }

        /// <summary>
        /// レコードを挿入します。
        /// </summary>
        public void WriteRecord()
        {
            WriteSelectedRecord();
        }

        /// <summary>
        /// レコードを論理削除します。
        /// </summary>
        public void DeleteRecord()
        {
            DeleteSelectedRecord();
        }

        /// <summary>
        /// レコードを復活させます。
        /// </summary>
        public void ReviveRecord()
        {
            ReviveSelectedRecord();
        }

        /// <summary>
        /// レコードを物理削除します。
        /// </summary>
        public void DestroyRecord()
        {
            DestroySelectedRecord();
        }

        /// <summary>
        /// インポートします。
        /// </summary>
        public void Import()
        {
            _dbEntity = ImportOtherDB();
        }

        /// <summary>表示を更新するイベント</summary>
        public event UpdateViewEventHandler UpdatingView;

        #endregion // </IServerConfigurationController メンバ>

        /// <summary>
        /// 結果コード列挙型
        /// </summary>
        protected enum ResultCode : int
        {
            /// <summary>正常</summary>
            Normal = 0
        }

        #region <DBの実態>

        /// <summary>DB</summary>
        private TDataSet _dbEntity;
        /// <summary>DBを取得します。</summary>
        public TDataSet DBEntity
        {
            get
            {
                if (_dbEntity == null)
                {
                    InitializeDB();
                }
                return _dbEntity;
            }
        }

        /// <summary>
        /// DBを初期化します。
        /// </summary>
        private void InitializeDB()
        {
            Load();
        }

        #endregion // <DBの実態>

        #region <Constructor>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        protected ServerConfiguratorController()
        {
            _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            UpdatingView += new UpdateViewEventHandler(OnUpdateView);
        }

        #endregion // </Constructor>

        /// <summary>
        /// 自身のDBからロードします。
        /// </summary>
        /// <returns>データセット</returns>
        protected abstract TDataSet LoadOwnDB();

        /// <summary>
        /// 選択しているレコードを書込みます。
        /// </summary>
        protected abstract void WriteSelectedRecord();

        /// <summary>
        /// 選択しているレコードを論理削除します。
        /// </summary>
        protected abstract void DeleteSelectedRecord();

        /// <summary>
        /// 選択しているレコードを復活させます。
        /// </summary>
        protected abstract void ReviveSelectedRecord();

        /// <summary>
        /// 選択しているレコードを物理削除します。
        /// </summary>
        protected abstract void DestroySelectedRecord();

        /// <summary>
        /// 他のDBからインポートします。
        /// </summary>
        /// <returns>データセット</returns>
        protected abstract TDataSet ImportOtherDB();

        #region <表示更新>

        /// <summary>
        /// 表示を更新するイベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        protected virtual void OnUpdateView(
            object sender,
            UpdateViewEventArgs e
        )
        {
            Debug.WriteLine("デフォルト表示更新処理");
        }

        /// <summary>
        /// 表示更新イベントを発生させます。
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        protected void RaiseUpdateViewEvent(
            object sender,
            UpdateViewEventArgs e
        )
        {
            UpdatingView(sender, e);
        }

        #endregion // </表示更新>
    }
}

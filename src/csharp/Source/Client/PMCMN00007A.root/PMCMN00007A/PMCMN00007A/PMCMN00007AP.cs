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
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 操作権限に応じたボタン制御用インターフェース
    /// </summary>
    public interface IOperationAuthorityControllable
    {
        /// <summary>
        /// 操作権限の設定に従って、コントロールを制御するオブジェクトにアクセスします。
        /// </summary>
        OperationAuthorityController OperationController
        {
            get;
            set;
        }
    }

    #region <実装/>

    /// <summary>
    /// 操作権限に応じたボタン制御用インターフェースの実装クラス
    /// </summary>
    /// <typeparam name="TOperationAuthorityController">操作権限の制御クラス</typeparam>
    public sealed class OperationAuthorityControllableImpl<TOperationAuthorityController>
        : IOperationAuthorityControllable
        where TOperationAuthorityController : OperationAuthorityController
    {
        #region <IOperationAuthorityControllable メンバ/>

        /// <see cref="IOperationAuthorityControllable"/>
        public OperationAuthorityController OperationController
        {
            get { return _operationController; }
            set { _operationController = value; }
        }

        #endregion  // <IOperationAuthorityControllable メンバ/>

        /// <summary>操作権限の制御オブジェクト</summary>
        private OperationAuthorityController _operationController;
        /// <summary>
        /// 操作権限の制御オブジェクトを取得します。（<c>TOperationAuthorityController</c>でダウンキャスト）
        /// </summary>
        /// <value>操作権限の制御オブジェクト（<c>TOperationAuthorityController</c>でダウンキャスト）</value>
        /// <exception cref="InvalidCastException">操作権限の制御オブジェクトの型が合っていません。</exception>
        public TOperationAuthorityController MyOpeCtrl
        {
            get { return (TOperationAuthorityController)_operationController; }
        }

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public OperationAuthorityControllableImpl() { }
    }

    #endregion  // <実装/>

    #region <コレクション/>

    /// <summary>
    /// 操作権限の制御オブジェクトのマップクラス
    /// </summary>
    /// <remarks>キー：プログラムIDまたはアセンブリID</remarks>
    /// <typeparam name="TOperationAuthorityController">操作権限の制御クラス</typeparam>
    public sealed class OperationAuthorityControllableMap<TOperationAuthorityController>
        : Dictionary<
            string,
            OperationAuthorityControllableImpl<TOperationAuthorityController>
        >
        where TOperationAuthorityController : OperationAuthorityController
    {
        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public OperationAuthorityControllableMap() : base() { }

        /// <summary>
        /// 制御オブジェクトを追加します。
        /// </summary>
        /// <param name="assemblyId">アセンブリIDまたはプログラムID</param>
        /// <returns>追加した制御オブジェクト</returns>
        public IOperationAuthorityControllable AddController(string assemblyId)
        {
            if (!base.ContainsKey(assemblyId))
            {
                base.Add(assemblyId, new OperationAuthorityControllableImpl<TOperationAuthorityController>());
            }
            return base[assemblyId];
        }
    }

    #endregion  // <コレクション/>

    #region <フォーム/>

    /// <summary>
    /// 操作権限の制御オブジェクトを持つフォーム
    /// </summary>
    /// <typeparam name="TOperationAuthorityController">操作権限の制御クラス</typeparam>
    public class OperationAuthorityControllableForm<TOperationAuthorityController>
        : System.Windows.Forms.Form,
        IOperationAuthorityControllable
        where TOperationAuthorityController : OperationAuthorityController
    {
        #region <IOperationAuthorityControllable メンバ/>

        /// <see cref="IOperationAuthorityControllable"/>
        public OperationAuthorityController OperationController
        {
            get { return _operationController; }
            set { _operationController = value; }
        }

        #endregion  // <IOperationAuthorityControllable メンバ/>

        /// <summary>操作権限の制御オブジェクト</summary>
        private OperationAuthorityController _operationController;
        /// <summary>
        /// 操作権限の制御オブジェクトを取得します。
        /// </summary>
        /// <value>操作権限の制御オブジェクト</value>
        /// <exception cref="InvalidCastException">操作権限の制御オブジェクトの型が合っていません。</exception>
        protected TOperationAuthorityController MyOpeCtrl
        {
            get { return (TOperationAuthorityController)_operationController; }
        }

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        protected OperationAuthorityControllableForm() : base() { }
    }

    #endregion  // <フォーム/>
}

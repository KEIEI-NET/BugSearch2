//****************************************************************************//
// システム         : 回答送信処理
// プログラム名称   : 回答送信処理アクセス
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2009/05/22  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;

namespace Broadleaf.Application.Controller.Util
{
    /// <summary>
    /// 3組クラス
    /// </summary>
    /// <typeparam name="TFirst">1番目の要素の型</typeparam>
    /// <typeparam name="TSecond">2番目の要素の型</typeparam>
    /// <typeparam name="TThird">3番目の要素の型</typeparam>
    public class Triple<TFirst, TSecond, TThird>
    {
        #region <1番目の要素>

        /// <summary>1番目の要素</summary>
        private TFirst _first;
        /// <summary>1番目の要素を取得または設定します。</summary>
        public TFirst First
        {
            get { return _first; }
            set { _first = value; }
        }

        #endregion // </1番目の要素>

        #region <2番目の要素>

        /// <summary>2番目の要素</summary>
        private TSecond _second;
        /// <summary>2番目の要素を取得または設定します。</summary>
        public TSecond Second
        {
            get { return _second; }
            set { _second = value; }
        }

        #endregion // </2番目の要素>

        #region <3番目の要素>

        /// <summary>3番目の要素</summary>
        private TThird _third;
        /// <summary>3番目の要素を取得または設定します。</summary>
        public TThird Third
        {
            get { return _third; }
            set { _third = value; }
        }

        #endregion // </3番目の要素>

        #region <Constructor>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public Triple() { }

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="first">1番目の要素</param>
        /// <param name="second">2番目の要素</param>
        /// <param name="third">3番目の要素</param>
        public Triple(
            TFirst first,
            TSecond second,
            TThird third
        )
        {
            _first = first;
            _second = second;
            _third = third;
        }

        #endregion // </Constructor>
    }
}

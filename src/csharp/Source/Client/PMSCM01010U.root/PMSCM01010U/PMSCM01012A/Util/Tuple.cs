//****************************************************************************//
// システム         : 自働回答処理
// プログラム名称   : 自働回答処理アクセス
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2009/05/20  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;

namespace Broadleaf.Application.Controller.Util
{
    /// <summary>
    /// Nullオブジェクトクラス
    /// </summary>
    public class NullObject
    {
        /// <summary>デフォルトコンストラクタ</summary>
        public NullObject() { }
    }

    /// <summary>
    /// タプルクラス
    /// </summary>
    public class Tuple<T01, T02, T03, T04, T05, T06, T07, T08, T09, T10>
        where T01 : class, new()
        where T02 : class, new()
        where T03 : class, new()
        where T04 : class, new()
        where T05 : class, new()
        where T06 : class, new()
        where T07 : class, new()
        where T08 : class, new()
        where T09 : class, new()
        where T10 : class, new()
    {
        #region <1番目>

        /// <summary>1番目のメンバ</summary>
        private T01 _member01;
        /// <summary>1番目のメンバを取得または設定します。</summary>
        public T01 Member01
        {
            get
            {
                if (_member01 == null) _member01 = new T01();
                return _member01;
            }
            set { _member01 = value; }
        }

        #endregion // </1番目>

        #region <2番目>

        /// <summary>2番目のメンバ</summary>
        private T02 _member02;
        /// <summary>2番目のメンバを取得または設定します。</summary>
        public T02 Member02
        {
            get
            {
                if (_member02 == null) _member02 = new T02();
                return _member02;
            }
            set { _member02 = value; }
        }

        #endregion // </2番目>

        #region <3番目>

        /// <summary>3番目のメンバ</summary>
        private T03 _member03;
        /// <summary>3番目のメンバを取得または設定します。</summary>
        public T03 Member03
        {
            get
            {
                if (_member03 == null) _member03 = new T03();
                return _member03;
            }
            set { _member03 = value; }
        }

        #endregion // </3番目>

        #region <4番目>

        /// <summary>4番目のメンバ</summary>
        private T04 _member04;
        /// <summary>4番目のメンバを取得または設定します。</summary>
        public T04 Member04
        {
            get
            {
                if (_member04 == null) _member04 = new T04();
                return _member04;
            }
            set { _member04 = value; }
        }

        #endregion // </4番目>

        #region <5番目>

        /// <summary>5番目のメンバ</summary>
        private T05 _member05;
        /// <summary>5番目のメンバを取得または設定します。</summary>
        public T05 Member05
        {
            get
            {
                if (_member05 == null) _member05 = new T05();
                return _member05;
            }
            set { _member05 = value; }
        }

        #endregion // </5番目>

        #region <6番目>

        /// <summary>6番目のメンバ</summary>
        private T06 _member06;
        /// <summary>6番目のメンバを取得または設定します。</summary>
        public T06 Member06
        {
            get
            {
                if (_member06 == null) _member06 = new T06();
                return _member06;
            }
            set { _member06 = value; }
        }

        #endregion // </6番目>

        #region <7番目>

        /// <summary>7番目のメンバ</summary>
        private T07 _member07;
        /// <summary>7番目のメンバを取得または設定します。</summary>
        public T07 Member07
        {
            get
            {
                if (_member07 == null) _member07 = new T07();
                return _member07;
            }
            set { _member07 = value; }
        }

        #endregion // </7番目>

        #region <8番目>

        /// <summary>8番目のメンバ</summary>
        private T08 _member08;
        /// <summary>8番目のメンバを取得または設定します。</summary>
        public T08 Member08
        {
            get
            {
                if (_member08 == null) _member08 = new T08();
                return _member08;
            }
            set { _member08 = value; }
        }

        #endregion // </8番目>

        #region <9番目>

        /// <summary>9番目のメンバ</summary>
        private T09 _member09;
        /// <summary>9番目のメンバを取得または設定します。</summary>
        public T09 Member09
        {
            get
            {
                if (_member09 == null) _member09 = new T09();
                return _member09;
            }
            set { _member09 = value; }
        }

        #endregion // </9番目>

        #region <10番目>

        /// <summary>10番目のメンバ</summary>
        private T10 _member10;
        /// <summary>10番目のメンバを取得または設定します。</summary>
        public T10 Member10
        {
            get
            {
                if (_member10 == null) _member10 = new T10();
                return _member10;
            }
            set { _member10 = value; }
        }

        #endregion // </10番目>

        #region <Constructor>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public Tuple() { }

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="member01">1番目の値</param>
        /// <param name="member02">2番目の値</param>
        /// <param name="member03">3番目の値</param>
        /// <param name="member04">4番目の値</param>
        /// <param name="member05">5番目の値</param>
        /// <param name="member06">6番目の値</param>
        /// <param name="member07">7番目の値</param>
        /// <param name="member08">8番目の値</param>
        /// <param name="member09">9番目の値</param>
        /// <param name="member10">10番目の値</param>
        public Tuple(
            T01 member01,
            T02 member02,
            T03 member03,
            T04 member04,
            T05 member05,
            T06 member06,
            T07 member07,
            T08 member08,
            T09 member09,
            T10 member10
        )
        {
            _member01 = member01;
            _member02 = member02;
            _member03 = member03;
            _member04 = member04;
            _member05 = member05;
            _member06 = member06;
            _member07 = member07;
            _member08 = member08;
            _member09 = member09;
            _member10 = member10;
        }

        #endregion // <Constructor>
    }
}

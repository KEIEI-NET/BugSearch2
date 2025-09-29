//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : ＴＢＯ情報出力
// プログラム概要   : ＴＢＯ情報出力
//----------------------------------------------------------------------------//
//                (c)Copyright  2016 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号 : 11270029-00  作成担当 : 河原林　一生
// 作 成 日 : 2016/05/20   修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 商品カテゴリ変換用データモデルクラス
    /// </summary>
    /// <remarks>
    /// <br>Note        : XMLファイルから読み込んだデータモデルクラス</br>
    /// <br>Programmer  : 河原林　一生</br>
    /// <br>Date        : 2016/05/20</br>
    /// </remarks>
    [Serializable]
    public class TBOGoodsMGroup
    {
        /// <summary>
        /// 商品カテゴリ
        /// </summary>
        private string category;
        /// <summary>
        /// 商品中分類
        /// </summary>
        private string goodsMGroup;

        /// <summary>
        /// 商品カテゴリ
        /// </summary>
        public string Category
        {
            get { return this.category; }
            set { this.category = value; }
        }
        /// <summary>
        /// 商品中分類
        /// </summary>
        public string GoodsMGroup
        {
            get { return this.goodsMGroup; }
            set { this.goodsMGroup = value; }
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public TBOGoodsMGroup()
        {
            this.category = String.Empty;
            this.goodsMGroup = String.Empty;
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="category">商品カテゴリ</param>
        /// <param name="goodsMGroup">商品中分類</param>
        public TBOGoodsMGroup(string category, string goodsMGroup)
        {
            this.category = category;
            this.goodsMGroup = goodsMGroup;
        }
    }
}

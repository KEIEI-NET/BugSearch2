//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : BLグループマスタ（エクスポート）
// プログラム概要   : BLグループマスタのｴｸｽﾎﾟｰﾄ処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 作 成 日  2009/05/13  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   BLGroupSetExp
    /// <summary>
    ///                      グループコードマスタ（エクスポート)結果クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   グループコードマスタ（エクスポート)結果クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/10/24  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks> 
    public class BLGroupSetExp
    {
        /// <summary>BLグループコード</summary>
        private Int32 _bLGroupCode;

        /// <summary>BLグループコード名称</summary>
        private string _bLGroupName = "";

        /// <summary>BLグループコードカナ名称</summary>
        private string _bLGroupKanaName = "";

        /// <summary>販売区分コード</summary>
        private Int32 _salesCode;

        /// <summary>販売区分名</summary>
        private string _salesCodeName = "";

        /// <summary>商品大分類コード</summary>
        private Int32 _goodsLGroup;

        /// <summary>商品大分類名</summary>
        private string _goodsLGroupName = "";

        /// <summary>商品中分類コード</summary>
        private Int32 _goodsMGroup;

        /// <summary>商品中分類名</summary>
        private string _goodsMGroupName = "";


        /// public propaty name  :  BLGroupCode
        /// <summary>BLグループコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLグループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGroupCode
        {
            get { return _bLGroupCode; }
            set { _bLGroupCode = value; }
        }

        /// public propaty name  :  BLGroupName
        /// <summary>BLグループコード名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLグループコード名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BLGroupName
        {
            get { return _bLGroupName; }
            set { _bLGroupName = value; }
        }

        /// public propaty name  :  BLGroupKanaName
        /// <summary>BLグループコードカナ名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLグループコードカナ名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BLGroupKanaName
        {
            get { return _bLGroupKanaName; }
            set { _bLGroupKanaName = value; }
        }

        /// public propaty name  :  SalesCode
        /// <summary>販売区分コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売区分コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesCode
        {
            get { return _salesCode; }
            set { _salesCode = value; }
        }

        /// public propaty name  :  SalesCodeName
        /// <summary>販売区分名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売区分名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesCodeName
        {
            get { return _salesCodeName; }
            set { _salesCodeName = value; }
        }

        /// public propaty name  :  GoodsLGroup
        /// <summary>商品大分類コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品大分類コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsLGroup
        {
            get { return _goodsLGroup; }
            set { _goodsLGroup = value; }
        }

        /// public propaty name  :  GoodsLGroupName
        /// <summary>商品大分類名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品大分類名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsLGroupName
        {
            get { return _goodsLGroupName; }
            set { _goodsLGroupName = value; }
        }

        /// public propaty name  :  GoodsMGroup
        /// <summary>商品中分類コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品中分類コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMGroup
        {
            get { return _goodsMGroup; }
            set { _goodsMGroup = value; }
        }

        /// public propaty name  :  GoodsMGroupName
        /// <summary>商品中分類名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品中分類名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsMGroupName
        {
            get { return _goodsMGroupName; }
            set { _goodsMGroupName = value; }
        }

        /// <summary>
        /// ＢＬグループ（印刷）データクラス複製処理
        /// </summary>
        /// <returns>SecInfoSetクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいSecInfoSetクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public BLGroupSetExp Clone()
        {
            return new BLGroupSetExp(this._bLGroupCode, this._bLGroupName, this._bLGroupKanaName, this._salesCode, this._salesCodeName, this._goodsLGroup, this._goodsLGroupName, this._goodsMGroup, this._goodsMGroupName);

        }

        /// <summary>
        /// ＢＬグループ（印刷）データクラスワークコンストラクタ
        /// </summary>
        /// <returns>EmployeeSetWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   EmployeeSetWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public BLGroupSetExp()
        {
        }

        /// <summary>
        /// ＢＬグループ（印刷）データクラスワークコンストラクタ
        /// </summary>
        /// <param name="BLGroupCode"></param>
        /// <param name="BLGroupName"></param>
        /// <param name="BLGroupKanaName"></param>
        /// <param name="SalesCode"></param>
        /// <param name="SalesCodeName"></param>
        /// <param name="GoodsLGroup"></param>
        /// <param name="GoodsLGroupName"></param>
        /// <param name="GoodsMGroup"></param>
        /// <param name="GoodsMGroupName"></param>
        public BLGroupSetExp(Int32 BLGroupCode, string BLGroupName, string BLGroupKanaName, Int32 SalesCode, string SalesCodeName, Int32 GoodsLGroup, string GoodsLGroupName, Int32 GoodsMGroup, string GoodsMGroupName)
        {
            this._bLGroupCode = BLGroupCode;
            this._bLGroupName = BLGroupName;
            this._bLGroupKanaName = BLGroupKanaName;
            this._salesCode = SalesCode;
            this._salesCodeName = SalesCodeName;
            this._goodsLGroup = GoodsLGroup;
            this._goodsLGroupName = GoodsLGroupName;
            this._goodsMGroup = GoodsMGroup;
            this._goodsMGroupName = GoodsMGroupName;

        }
    }
}

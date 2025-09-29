using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   BLGoodsCdSet
    /// <summary>
    ///                      BLコードマスタ（印刷）結果クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   BLコードマスタ（印刷）結果クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/10/24  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks> 
    public class BLGoodsCdSet 
    {
        /// <summary>BL商品コード</summary>
        private Int32 _bLGoodsCode;

        /// <summary>BL商品コード名称（全角）</summary>
        private string _bLGoodsFullName = "";

        /// <summary>BL商品コード名称（半角）</summary>
        private string _bLGoodsHalfName = "";

        /// <summary>BLグループコード</summary>
        /// <remarks>商品区分詳細</remarks>
        private Int32 _bLGroupCode;

        /// <summary>BLグループコードカナ名称</summary>
        private string _bLGroupKanaName = "";

        /// <summary>商品掛率グループコード</summary>
        private Int32 _goodsRateGrpCode;

        /// <summary>商品掛率グループコード名</summary>
        private string _goodsRateGrpCodeName = "";

        /// <summary>BL商品分類</summary>
        private Int32 _bLGoodsGenreCode;

        /// <summary>BL商品分類名</summary>
        private string _bLGoodsGenreCodeName = "";


        /// public propaty name  :  BLGoodsCode
        /// <summary>BL商品コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGoodsCode
        {
            get { return _bLGoodsCode; }
            set { _bLGoodsCode = value; }
        }

        /// public propaty name  :  BLGoodsFullName
        /// <summary>BL商品コード名称（全角）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コード名称（全角）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BLGoodsFullName
        {
            get { return _bLGoodsFullName; }
            set { _bLGoodsFullName = value; }
        }

        /// public propaty name  :  BLGoodsHalfName
        /// <summary>BL商品コード名称（半角）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コード名称（半角）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BLGoodsHalfName
        {
            get { return _bLGoodsHalfName; }
            set { _bLGoodsHalfName = value; }
        }

        /// public propaty name  :  BLGroupCode
        /// <summary>BLグループコードプロパティ</summary>
        /// <value>商品区分詳細</value>
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

        /// public propaty name  :  GoodsRateGrpCode
        /// <summary>商品掛率グループコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品掛率グループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsRateGrpCode
        {
            get { return _goodsRateGrpCode; }
            set { _goodsRateGrpCode = value; }
        }

        /// public propaty name  :  GoodsRateGrpCodeName
        /// <summary>商品掛率グループコード名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品掛率グループコード名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsRateGrpCodeName
        {
            get { return _goodsRateGrpCodeName; }
            set { _goodsRateGrpCodeName = value; }
        }

        /// public propaty name  :  BLGoodsGenreCode
        /// <summary>BL商品分類プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品分類プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGoodsGenreCode
        {
            get { return _bLGoodsGenreCode; }
            set { _bLGoodsGenreCode = value; }
        }

        /// public propaty name  :  BLGoodsGenreCodeName
        /// <summary>BL商品分類名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品分類名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BLGoodsGenreCodeName
        {
            get { return _bLGoodsGenreCodeName; }
            set { _bLGoodsGenreCodeName = value; }
        }

        /// <summary>
        /// BLコード（印刷）データクラス複製処理
        /// </summary>
        /// <returns>SecInfoSetクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいSecInfoSetクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public BLGoodsCdSet Clone()
        {
            return new BLGoodsCdSet(this._bLGoodsCode,this._bLGoodsFullName,this._bLGoodsHalfName,this._bLGroupCode,this._bLGroupKanaName,this._goodsRateGrpCode,this._goodsRateGrpCodeName,this._bLGoodsGenreCode,this._bLGoodsGenreCodeName);

        }

        /// <summary>
		/// BLコード（印刷）データクラスワークコンストラクタ
		/// </summary>
        /// <returns>BLGoodsCdSetクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   EmployeeSetWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public BLGoodsCdSet()
		{
		}

        /// <summary>
        /// BLコード（印刷）データクラスワークコンストラクタ
        /// </summary>
        /// <param name="BLGoodsCode"></param>
        /// <param name="BLGoodsFullName"></param>
        /// <param name="BLGoodsHalfName"></param>
        /// <param name="BLGroupCode"></param>
        /// <param name="BLGroupKanaName"></param>
        /// <param name="GoodsRateGrpCode"></param>
        /// <param name="GoodsRateGrpCodeName"></param>
        /// <param name="BLGoodsGenreCode"></param>
        /// <param name="BLGoodsGenreCodeName"></param>
        public BLGoodsCdSet(Int32 BLGoodsCode,string BLGoodsFullName,string BLGoodsHalfName,Int32 BLGroupCode,string BLGroupKanaName,Int32 GoodsRateGrpCode,string GoodsRateGrpCodeName,Int32 BLGoodsGenreCode,string BLGoodsGenreCodeName)
        {
            this._bLGoodsCode = BLGoodsCode;
            this._bLGoodsFullName = BLGoodsFullName;
            this._bLGoodsHalfName = BLGoodsHalfName;
            this._bLGroupCode = BLGroupCode;
            this._bLGroupKanaName = BLGroupKanaName;
            this._goodsRateGrpCode = GoodsRateGrpCode;
            this._goodsRateGrpCodeName = GoodsRateGrpCodeName;
            this._bLGoodsGenreCode = BLGoodsGenreCode;
            this._bLGoodsGenreCodeName = BLGoodsGenreCodeName;
        }
    }
}

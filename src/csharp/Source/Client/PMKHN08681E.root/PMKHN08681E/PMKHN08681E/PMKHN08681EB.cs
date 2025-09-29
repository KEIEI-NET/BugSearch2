using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   PartsPosCodeSet
    /// <summary>
    ///                      部位マスタ（印刷）結果クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   部位マスタ（印刷）結果クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/10/24  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks> 
    public class PartsPosCodeSet
    {
        /// <summary>得意先コード</summary>
        private Int32 _customerCode;

        /// <summary>得意先名</summary>
        private string _customerSnm;

        /// <summary>検索部位コード</summary>
        private Int32 _searchPartsPosCode;

        /// <summary>検索部位コード名称</summary>
        /// <remarks>表示順位0、BLコード0の場合部位名称をセット</remarks>
        private string _searchPartsPosName = "";

        /// <summary>検索部位表示順位</summary>
        private Int32 _posDispOrder;

        /// <summary>BLコード</summary>
        /// <remarks>０の場合、部位名称用レコード</remarks>
        private Int32 _tbsPartsCode;

        /// <summary>BL商品コード名称（半角）</summary>
        private string _bLGoodsHalfName = "";

        /// public propaty name  :  CustomerCode
        /// <summary>得意先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
        }

        /// public propaty name  :  CustomerCode
        /// <summary>得意先名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustomerSnm
        {
            get { return _customerSnm; }
            set { _customerSnm = value; }
        }

        /// public propaty name  :  SearchPartsPosCode
        /// <summary>検索部位コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   検索部位コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SearchPartsPosCode
        {
            get { return _searchPartsPosCode; }
            set { _searchPartsPosCode = value; }
        }

        /// public propaty name  :  SearchPartsPosName
        /// <summary>検索部位コード名称プロパティ</summary>
        /// <value>表示順位0、BLコード0の場合部位名称をセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   検索部位コード名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SearchPartsPosName
        {
            get { return _searchPartsPosName; }
            set { _searchPartsPosName = value; }
        }

        /// public propaty name  :  PosDispOrder
        /// <summary>検索部位表示順位プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   検索部位表示順位プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PosDispOrder
        {
            get { return _posDispOrder; }
            set { _posDispOrder = value; }
        }

        /// public propaty name  :  TbsPartsCode
        /// <summary>BLコードプロパティ</summary>
        /// <value>０の場合、部位名称用レコード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TbsPartsCode
        {
            get { return _tbsPartsCode; }
            set { _tbsPartsCode = value; }
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

        /// <summary>
        /// 部位（印刷）データクラス複製処理
        /// </summary>
        /// <returns>SecInfoSetクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいSecInfoSetクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PartsPosCodeSet Clone()
        {
            return new PartsPosCodeSet(this._customerCode, this._customerSnm, this._searchPartsPosCode, this._searchPartsPosName, this._posDispOrder, this._tbsPartsCode, this._bLGoodsHalfName);
        }

        /// <summary>
        /// 部位（印刷）データクラスワークコンストラクタ
        /// </summary>
        /// <returns>PartsPosCodeSetクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   EmployeeSetWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PartsPosCodeSet()
        {
        }

        /// <summary>
        /// 部位（印刷）データクラスワークコンストラクタ
        /// </summary>
        /// <param name="CustomerCode"></param>
        /// <param name="CustomerSnm"></param>
        /// <param name="SearchPartsPosCode"></param>
        /// <param name="SearchPartsPosName"></param>
        /// <param name="PosDispOrder"></param>
        /// <param name="TbsPartsCode"></param>
        /// <param name="BLGoodsHalfName"></param>
        public PartsPosCodeSet(Int32 CustomerCode, string CustomerSnm, Int32 SearchPartsPosCode, string SearchPartsPosName, Int32 PosDispOrder, Int32 TbsPartsCode, string BLGoodsHalfName)
        {
            this._customerCode = CustomerCode;
            this._customerSnm = CustomerSnm;
            this._searchPartsPosCode = SearchPartsPosCode;
            this._searchPartsPosName = SearchPartsPosName;
            this._posDispOrder = PosDispOrder;
            this._tbsPartsCode = TbsPartsCode;
            this._bLGoodsHalfName = BLGoodsHalfName;
        }
    }
}

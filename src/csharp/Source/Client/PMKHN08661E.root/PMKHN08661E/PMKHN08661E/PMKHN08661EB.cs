using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   GoodsSetSet
    /// <summary>
    ///                      セットマスタ（印刷）結果クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   セットマスタ（印刷）結果クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/10/24  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks> 
    public class GoodsSetSet
    {
        /// <summary>親メーカーコード</summary>
        private Int32 _parentGoodsMakerCd;

        /// <summary>親メーカー名</summary>
        private string _parentGoodsMakerName = "";

        /// <summary>親商品番号</summary>
        private string _parentGoodsNo = "";

        /// <summary>表示順位</summary>
        private Int32 _displayOrder;

        /// <summary>子商品番号</summary>
        private string _subGoodsNo = "";

        /// <summary>商品名称カナ</summary>
        private string _goodsNameKana = "";

        /// <summary>子商品メーカーコード</summary>
        private Int32 _subGoodsMakerCd;

        /// <summary>子商品メーカー名</summary>
        private string _subGoodsMakerName = "";

        /// <summary>数量（浮動）</summary>
        private Double _cntFl;

        /// <summary>セット規格・特記事項</summary>
        private string _setSpecialNote = "";


        /// public propaty name  :  ParentGoodsMakerCd
        /// <summary>親メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   親メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ParentGoodsMakerCd
        {
            get { return _parentGoodsMakerCd; }
            set { _parentGoodsMakerCd = value; }
        }

        /// public propaty name  :  ParentGoodsMakerName
        /// <summary>親メーカー名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   親メーカー名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ParentGoodsMakerName
        {
            get { return _parentGoodsMakerName; }
            set { _parentGoodsMakerName = value; }
        }

        /// public propaty name  :  ParentGoodsNo
        /// <summary>親商品番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   親商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ParentGoodsNo
        {
            get { return _parentGoodsNo; }
            set { _parentGoodsNo = value; }
        }

        /// public propaty name  :  DisplayOrder
        /// <summary>表示順位プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   表示順位プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DisplayOrder
        {
            get { return _displayOrder; }
            set { _displayOrder = value; }
        }

        /// public propaty name  :  SubGoodsNo
        /// <summary>子商品番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   子商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SubGoodsNo
        {
            get { return _subGoodsNo; }
            set { _subGoodsNo = value; }
        }

        /// public propaty name  :  GoodsNameKana
        /// <summary>商品名称カナプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品名称カナプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNameKana
        {
            get { return _goodsNameKana; }
            set { _goodsNameKana = value; }
        }

        /// public propaty name  :  SubGoodsMakerCd
        /// <summary>子商品メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   子商品メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SubGoodsMakerCd
        {
            get { return _subGoodsMakerCd; }
            set { _subGoodsMakerCd = value; }
        }

        /// public propaty name  :  SubGoodsMakerName
        /// <summary>子商品メーカー名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   子商品メーカー名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SubGoodsMakerName
        {
            get { return _subGoodsMakerName; }
            set { _subGoodsMakerName = value; }
        }

        /// public propaty name  :  CntFl
        /// <summary>数量（浮動）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   数量（浮動）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double CntFl
        {
            get { return _cntFl; }
            set { _cntFl = value; }
        }

        /// public propaty name  :  SetSpecialNote
        /// <summary>セット規格・特記事項プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   セット規格・特記事項プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SetSpecialNote
        {
            get { return _setSpecialNote; }
            set { _setSpecialNote = value; }
        }

        /// <summary>
        /// セット（印刷）データクラス複製処理
        /// </summary>
        /// <returns>SecInfoSetクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいSecInfoSetクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public GoodsSetSet Clone()
        {
            return new GoodsSetSet(this._parentGoodsMakerCd, this._parentGoodsMakerName, this._parentGoodsNo, this._displayOrder, this._subGoodsNo, this._goodsNameKana, this._subGoodsMakerCd, this._subGoodsMakerName, this._cntFl, this._setSpecialNote);
        }

        /// <summary>
        /// セット（印刷）データクラスワークコンストラクタ
        /// </summary>
        /// <returns>GoodsSetSetクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsSetSetクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public GoodsSetSet()
        {
        }

        /// <summary>
        /// セット（印刷）データクラスワークコンストラクタ
        /// </summary>
        /// <param name="ParentGoodsMakerCd"></param>
        /// <param name="ParentGoodsMakerName"></param>
        /// <param name="ParentGoodsNo"></param>
        /// <param name="DisplayOrder"></param>
        /// <param name="SubGoodsNo"></param>
        /// <param name="GoodsNameKana"></param>
        /// <param name="SubGoodsMakerCd"></param>
        /// <param name="SubGoodsMakerName"></param>
        /// <param name="CntFl"></param>
        /// <param name="SetSpecialNote"></param>
        public GoodsSetSet(Int32 ParentGoodsMakerCd, string ParentGoodsMakerName, string ParentGoodsNo, Int32 DisplayOrder, string SubGoodsNo, string GoodsNameKana, Int32 SubGoodsMakerCd, string SubGoodsMakerName, Double CntFl, string SetSpecialNote)
        {
            this._parentGoodsMakerCd = ParentGoodsMakerCd;
            this._parentGoodsMakerName = ParentGoodsMakerName;
            this._parentGoodsNo = ParentGoodsNo;
            this._displayOrder = DisplayOrder;
            this._subGoodsNo = SubGoodsNo;
            this._goodsNameKana = GoodsNameKana;
            this._subGoodsMakerCd = SubGoodsMakerCd;
            this._subGoodsMakerName = SubGoodsMakerName;
            this._cntFl = CntFl;
            this._setSpecialNote = SetSpecialNote;
        }
    }
}

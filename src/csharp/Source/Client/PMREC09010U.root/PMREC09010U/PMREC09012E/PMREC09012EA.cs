using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   SearchCondition
    /// <summary>
    ///                      リコメンド商品関連設定マスタ抽出条件クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   リコメンド商品関連設定マスタ抽出条件クラス</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2015/01/20</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class SearchCondition
    {
        /// <summary>問合せ元企業コード</summary>
        private string _inqOriginalEpCd = "";

        /// <summary>問合せ元拠点コード</summary>
        private string _inqOriginalSecCd = "";

        /// <summary>問合せ先企業コード</summary>
        private string _inqOtherEpCd = "";

        /// <summary>問合せ先拠点コード</summary>
        private string _inqOtherSecCd = "";

        /// <summary>得意先コード</summary>
        private Int32 _customerCode;

        /// <summary>推奨元BLコード（開始）</summary>
        private Int32 _recSourceBLGoodsCdSt;

        /// <summary>推奨元BLコード（終了）</summary>
        private Int32 _recSourceBLGoodsCdEd;

        /// <summary>削除指定区分</summary>
        private Int32 _deleteFlag;

        /// public propaty name  :  InqOriginalEpCd
        /// <summary>問合せ元企業コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ元企業コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InqOriginalEpCd
        {
            get { return _inqOriginalEpCd; }
            set { _inqOriginalEpCd = value; }
        }

        /// public propaty name  :  InqOriginalSecCd
        /// <summary>問合せ元拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ元拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InqOriginalSecCd
        {
            get { return _inqOriginalSecCd; }
            set { _inqOriginalSecCd = value; }
        }


        /// public propaty name  :  InqOtherEpCd
        /// <summary>問合せ先企業コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ先企業コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InqOtherEpCd
        {
            get { return _inqOtherEpCd; }
            set { _inqOtherEpCd = value; }
        }

        /// public propaty name  :  InqOtherSecCd
        /// <summary>問合せ先拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ先拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InqOtherSecCd
        {
            get { return _inqOtherSecCd; }
            set { _inqOtherSecCd = value; }
        }

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

        /// public propaty name  :  RecSourceBLGoodsCdSt
        /// <summary>推奨元BLコード（開始）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   推奨元BLコード（開始）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 RecSourceBLGoodsCdSt
        {
            get { return _recSourceBLGoodsCdSt; }
            set { _recSourceBLGoodsCdSt = value; }
        }

        /// public propaty name  :  RecSourceBLGoodsCdEd
        /// <summary>推奨元BLコード（終了）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   推奨元BLコード（終了）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 RecSourceBLGoodsCdEd
        {
            get { return _recSourceBLGoodsCdEd; }
            set { _recSourceBLGoodsCdEd = value; }
        }

        /// public propaty name  :  DeleteFlag
        /// <summary>削除指定区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   削除指定区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DeleteFlag
        {
            get { return _deleteFlag; }
            set { _deleteFlag = value; }
        }

        /// <summary>
        /// リコメンド商品関連設定マスタ抽出条件コンストラクタ
        /// </summary>
        /// <returns>SearchConditionクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SearchConditionクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SearchCondition()
        {
        }
    }
}

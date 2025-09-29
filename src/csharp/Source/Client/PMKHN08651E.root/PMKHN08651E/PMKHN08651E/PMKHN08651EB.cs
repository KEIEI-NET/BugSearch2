using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   PartsSubstSet
    /// <summary>
    ///                      代替マスタ（印刷）結果クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   代替マスタ（印刷）結果クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/10/24  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks> 
    public class PartsSubstSet
    {
        /// <summary>変換元メーカーコード</summary>
        private Int32 _chgSrcMakerCd;

        /// <summary>変換元メーカー名</summary>
        private string _chgSrcMakerName = "";

        /// <summary>変換元商品番号</summary>
        private string _chgSrcGoodsNo = "";

        /// <summary>変換先メーカーコード</summary>
        private Int32 _chgDestMakerCd;

        /// <summary>変換先メーカー名</summary>
        private string _chgDestMakerName = "";

        /// <summary>変換先商品番号</summary>
        private string _chgDestGoodsNo = "";

        /// <summary>適用開始日</summary>
        private DateTime _applyStaDate;

        /// <summary>適用終了日</summary>
        private DateTime _applyEndDate;


        /// public propaty name  :  ChgSrcMakerCd
        /// <summary>変換元メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   変換元メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ChgSrcMakerCd
        {
            get { return _chgSrcMakerCd; }
            set { _chgSrcMakerCd = value; }
        }

        /// public propaty name  :  ChgSrcMakerName
        /// <summary>変換元メーカー名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   変換元メーカー名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ChgSrcMakerName
        {
            get { return _chgSrcMakerName; }
            set { _chgSrcMakerName = value; }
        }

        /// public propaty name  :  ChgSrcGoodsNo
        /// <summary>変換元商品番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   変換元商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ChgSrcGoodsNo
        {
            get { return _chgSrcGoodsNo; }
            set { _chgSrcGoodsNo = value; }
        }

        /// public propaty name  :  ChgDestMakerCd
        /// <summary>変換先メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   変換先メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ChgDestMakerCd
        {
            get { return _chgDestMakerCd; }
            set { _chgDestMakerCd = value; }
        }

        /// public propaty name  :  ChgDestMakerName
        /// <summary>変換先メーカー名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   変換先メーカー名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ChgDestMakerName
        {
            get { return _chgDestMakerName; }
            set { _chgDestMakerName = value; }
        }

        /// public propaty name  :  ChgDestGoodsNo
        /// <summary>変換先商品番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   変換先商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ChgDestGoodsNo
        {
            get { return _chgDestGoodsNo; }
            set { _chgDestGoodsNo = value; }
        }

        /// public propaty name  :  ApplyStaDate
        /// <summary>適用開始日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   適用開始日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime ApplyStaDate
        {
            get { return _applyStaDate; }
            set { _applyStaDate = value; }
        }

        /// public propaty name  :  ApplyEndDate
        /// <summary>適用終了日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   適用終了日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime ApplyEndDate
        {
            get { return _applyEndDate; }
            set { _applyEndDate = value; }
        }

        /// <summary>
        /// 代替（印刷）データクラス複製処理
        /// </summary>
        /// <returns>SecInfoSetクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいSecInfoSetクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PartsSubstSet Clone()
        {
            return new PartsSubstSet(this._chgSrcMakerCd, this._chgSrcMakerName, this._chgSrcGoodsNo, this._chgDestMakerCd, this._chgDestMakerName, this._chgDestGoodsNo, this._applyStaDate, this._applyEndDate);
        }

        /// <summary>
        /// 代替（印刷）データクラスワークコンストラクタ
        /// </summary>
        /// <returns>PartsSubstSetクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PartsSubstSetクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PartsSubstSet()
        {
        }

        /// <summary>
        /// 代替（印刷）データクラスワークコンストラクタ
        /// </summary>
        /// <param name="ChgSrcMakerCd"></param>
        /// <param name="ChgSrcMakerName"></param>
        /// <param name="ChgSrcGoodsNo"></param>
        /// <param name="ChgDestMakerCd"></param>
        /// <param name="ChgDestMakerName"></param>
        /// <param name="ChgDestGoodsNo"></param>
        /// <param name="ApplyStaDate"></param>
        /// <param name="ApplyEndDate"></param>
        public PartsSubstSet(Int32 ChgSrcMakerCd, string ChgSrcMakerName, string ChgSrcGoodsNo, Int32 ChgDestMakerCd, string ChgDestMakerName, string ChgDestGoodsNo, DateTime ApplyStaDate, DateTime ApplyEndDate)
        {
            this._chgSrcMakerCd = ChgSrcMakerCd;
            this._chgSrcMakerName = ChgSrcMakerName;
            this._chgSrcGoodsNo = ChgSrcGoodsNo;
            this._chgDestMakerCd = ChgDestMakerCd;
            this._chgDestMakerName = ChgDestMakerName;
            this._chgDestGoodsNo = ChgDestGoodsNo;
            this._applyStaDate = ApplyStaDate;
            this._applyEndDate = ApplyEndDate;
        }
    }
}

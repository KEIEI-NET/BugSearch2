using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   TBOSearchCondWork
    /// <summary>
    ///                      提供車輌情報結合検索条件クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   提供車輌情報結合検索条件クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :    </br>
    /// <br>Genarated Date   :   2008/05/13  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class TBOSearchCondWork
    {
        /// <summary>BLコード</summary>
        private Int32 _tbsPartsCode;

        /// <summary>BLコード枝番</summary>
        private Int32 _tbsPartsCdDerivedNo;

        /// <summary>装備名称</summary>
        private string[] _equipName;

        /// <summary>装備分類</summary>
        private Int32 _equipGenreCode;

        /// <summary>検索品名検索用車メーカーコード[0の場合は検索品名検索なし]</summary>
        private Int32 _carMakerCd;

        /// public propaty name  :  TbsPartsCode
        /// <summary>BLコードプロパティ</summary>
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

        /// public propaty name  :  TbsPartsCdDerivedNo
        /// <summary>BLコード枝番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLコード枝番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TbsPartsCdDerivedNo
        {
            get { return _tbsPartsCdDerivedNo; }
            set { _tbsPartsCdDerivedNo = value; }
        }

        /// public propaty name  :  EquipName
        /// <summary>装備名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   装備名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string[] EquipName
        {
            get { return _equipName; }
            set { _equipName = value; }
        }

        /// public propaty name  :  EquipGenreCode
        /// <summary>装備分類プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   装備分類プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EquipGenreCode
        {
            get { return _equipGenreCode; }
            set { _equipGenreCode = value; }
        }

        /// public propaty name  :  CarMakerCd
        /// <summary>検索品名検索用車メーカーコード[0の場合は検索品名検索なし]プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   検索品名検索用車メーカーコード[0の場合は検索品名検索なし]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CarMakerCd
        {
            get { return _carMakerCd; }
            set { _carMakerCd = value; }
        }

        /// <summary>
        /// 提供車輌情報結合検索条件クラスワークコンストラクタ
        /// </summary>
        /// <returns>TBOSearchCondWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   TBOSearchCondWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public TBOSearchCondWork()
        {
        }

    }
}

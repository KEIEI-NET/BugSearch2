using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   PartsSubstUSearchParamWork
    /// <summary>
    ///                      代替新旧関連表示抽出条件ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   代替新旧関連表示抽出条件ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/10/01  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class PartsSubstUSearchParamWork 
	{
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>検索区分</summary>
        /// <remarks>0:代替先,1:代替元</remarks>
        private Int32 _searchDiv;

        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>変換元メーカーコード</summary>
        private Int32 _chgSrcMakerCd;

        /// <summary>変換元商品番号</summary>
        private string _chgSrcGoodsNo = "";


        /// public propaty name  :  EnterpriseCode
        /// <summary>企業コードプロパティ</summary>
        /// <value>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   企業コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// public propaty name  :  SearchDiv
        /// <summary>検索区分プロパティ</summary>
        /// <value>0:代替先,1:代替元</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   検索区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SearchDiv
        {
            get { return _searchDiv; }
            set { _searchDiv = value; }
        }

        /// public propaty name  :  SectionCode
        /// <summary>拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

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


        /// <summary>
        /// 代替新旧関連表示抽出条件ワークコンストラクタ
        /// </summary>
        /// <returns>PartsSubstUSearchParamWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PartsSubstUSearchParamWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PartsSubstUSearchParamWork()
        {
        }

	}
}

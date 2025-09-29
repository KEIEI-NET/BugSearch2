using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   UsrPartsNoSearchCondWork
    /// <summary>
    ///                      ユーザー結合検索抽出条件クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   ユーザー結合検索抽出条件クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :    </br>
    /// <br>Genarated Date   :   2008/05/15  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class UsrPartsNoSearchCondWork
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>メーカーコード</summary>
        /// <remarks>1～899:提供分, 900～ユーザー登録</remarks>
        private Int32 _makerCode;

        /// <summary>部品品番</summary>
        private string _prtsNo = "";

        /// <summary>検索範囲</summary>
        private int _searchRange;

        /// public property name  :  EnterpriseCode
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

        /// public property name  :  MakerCode
        /// <summary>メーカーコードプロパティ</summary>
        /// <value>1～899:提供分, 900～ユーザー登録</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MakerCode
        {
            get { return _makerCode; }
            set { _makerCode = value; }
        }

        /// public property name  :  PrtsNo
        /// <summary>部品品番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品品番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PrtsNo
        {
            get { return _prtsNo; }
            set { _prtsNo = value; }
        }

        /// <summary>
        /// 検索範囲 [ 0 : 商品情報のみ[デフォルト]  1 : 商品情報及びセット情報  2 : 品番結合検索 ]
        /// </summary>
        public int SearchRange
        {
            get { return _searchRange; }
            set { _searchRange = value; }
        }

        /// <summary>
        /// ユーザー結合検索抽出条件クラスワークコンストラクタ
        /// </summary>
        /// <returns>UsrPartsNoSearchCondWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UsrPartsNoSearchCondWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public UsrPartsNoSearchCondWork()
        {
        }

        /// <summary>
        /// ユーザー結合検索抽出条件クラスワークコンストラクタ
        /// </summary>
        /// <returns>UsrPartsNoSearchCondWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UsrPartsNoSearchCondWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public UsrPartsNoSearchCondWork(UsrPartsNoSearchCondWork srcObject)
        {
            _enterpriseCode = srcObject.EnterpriseCode;
            _makerCode = srcObject.MakerCode;
            _prtsNo = srcObject.PrtsNo;
        }

    }

    /// <summary>
    /// 
    /// </summary>
    public enum UsrSearchFlg
    {
        /// <summary>ユーザー商品のみ</summary>
        UsrPartsOnly = 0,
        /// <summary>ユーザー商品とセット取得</summary>
        UsrPartsAndSet = 1,
        /// <summary>ユーザーセットのみ取得</summary>
        UsrSetOnly = 2,
        /// <summary>ユーザー商品と結合、セット</summary>
        UsrPartsJoinSet = 3,
        /// <summary>ユーザー商品、結合、セット、代替全て取得</summary>
        UsrPartsAndAll = 4
    }
}

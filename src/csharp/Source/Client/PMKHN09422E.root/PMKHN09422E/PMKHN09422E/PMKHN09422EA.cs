//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : ユーザー価格・原価一括設定
// プログラム概要   : ユーザー価格・原価を複数件一括で修正・登録する。
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 劉洋
// 作 成 日  2009/04/08  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日               修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   UserPriceData
    /// <summary>
    ///                      ユーザー価格・原価一括設定
    /// </summary>
    /// <remarks>
    /// <br>note             :   ユーザー価格・原価一括設定ヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2009/04/13  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class UserPriceData
    {
        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>拠点名称</summary>
        private string _sectionName = "";

        /// <summary>BL商品コード</summary>
        private Int32 _bLGoodsCode;

        /// <summary>BL商品名称</summary>
        private string _bLGoodsName = "";

        /// <summary>商品メーカーコード</summary>
        private Int32 _goodsMakerCd;

        /// <summary>商品メーカー名称</summary>
        private string _goodsMakerName = "";


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

        /// public propaty name  :  SectionName
        /// <summary>拠点名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionName
        {
            get { return _sectionName; }
            set { _sectionName = value; }
        }

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

        /// public propaty name  :  BLGoodsName
        /// <summary>BL商品名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BLGoodsName
        {
            get { return _bLGoodsName; }
            set { _bLGoodsName = value; }
        }

        /// public propaty name  :  GoodsMakerCd
        /// <summary>商品メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCd
        {
            get { return _goodsMakerCd; }
            set { _goodsMakerCd = value; }
        }

        /// public propaty name  :  GoodsMakerName
        /// <summary>商品メーカー名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品メーカー名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsMakerName
        {
            get { return _goodsMakerName; }
            set { _goodsMakerName = value; }
        }


        /// <summary>
        /// ユーザー価格・原価一括設定コンストラクタ
        /// </summary>
        /// <returns>UserPriceDataクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UserPriceDataクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public UserPriceData()
        {
        }

        /// <summary>
        /// ユーザー価格・原価一括設定コンストラクタ
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="sectionName">拠点名称</param>
        /// <param name="bLGoodsCode">BL商品コード</param>
        /// <param name="bLGoodsName">BL商品名称</param>
        /// <param name="goodsMakerCd">商品メーカーコード</param>
        /// <param name="goodsMakerName">商品メーカー名称</param>
        /// <returns>UserPriceDataクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UserPriceDataクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public UserPriceData(string sectionCode, string sectionName, Int32 bLGoodsCode, string bLGoodsName, Int32 goodsMakerCd, string goodsMakerName)
        {
            this._sectionCode = sectionCode;
            this._sectionName = sectionName;
            this._bLGoodsCode = bLGoodsCode;
            this._bLGoodsName = bLGoodsName;
            this._goodsMakerCd = goodsMakerCd;
            this._goodsMakerName = goodsMakerName;

        }

        /// <summary>
        /// ユーザー価格・原価一括設定複製処理
        /// </summary>
        /// <returns>UserPriceDataクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいUserPriceDataクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public UserPriceData Clone()
        {
            return new UserPriceData(this._sectionCode, this._sectionName, this._bLGoodsCode, this._bLGoodsName, this._goodsMakerCd, this._goodsMakerName);
        }

        /// <summary>
        /// ユーザー価格・原価一括設定比較処理
        /// </summary>
        /// <param name="target">比較対象のUserPriceDataクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UserPriceDataクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(UserPriceData target)
        {
            return ((this.SectionCode == target.SectionCode)
                 && (this.SectionName == target.SectionName)
                 && (this.BLGoodsCode == target.BLGoodsCode)
                 && (this.BLGoodsName == target.BLGoodsName)
                 && (this.GoodsMakerCd == target.GoodsMakerCd)
                 && (this.GoodsMakerName == target.GoodsMakerName));
        }

        /// <summary>
        /// ユーザー価格・原価一括設定比較処理
        /// </summary>
        /// <param name="userPriceData1">
        ///                    比較するUserPriceDataクラスのインスタンス
        /// </param>
        /// <param name="userPriceData2">比較するUserPriceDataクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UserPriceDataクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(UserPriceData userPriceData1, UserPriceData userPriceData2)
        {
            return ((userPriceData1.SectionCode == userPriceData2.SectionCode)
                 && (userPriceData1.SectionName == userPriceData2.SectionName)
                 && (userPriceData1.BLGoodsCode == userPriceData2.BLGoodsCode)
                 && (userPriceData1.BLGoodsName == userPriceData2.BLGoodsName)
                 && (userPriceData1.GoodsMakerCd == userPriceData2.GoodsMakerCd)
                 && (userPriceData1.GoodsMakerName == userPriceData2.GoodsMakerName));
        }
        /// <summary>
        /// ユーザー価格・原価一括設定比較処理
        /// </summary>
        /// <param name="target">比較対象のUserPriceDataクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UserPriceDataクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(UserPriceData target)
        {
            ArrayList resList = new ArrayList();
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.SectionName != target.SectionName) resList.Add("SectionName");
            if (this.BLGoodsCode != target.BLGoodsCode) resList.Add("BLGoodsCode");
            if (this.BLGoodsName != target.BLGoodsName) resList.Add("BLGoodsName");
            if (this.GoodsMakerCd != target.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (this.GoodsMakerName != target.GoodsMakerName) resList.Add("GoodsMakerName");

            return resList;
        }

        /// <summary>
        /// ユーザー価格・原価一括設定比較処理
        /// </summary>
        /// <param name="userPriceData1">比較するUserPriceDataクラスのインスタンス</param>
        /// <param name="userPriceData2">比較するUserPriceDataクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UserPriceDataクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(UserPriceData userPriceData1, UserPriceData userPriceData2)
        {
            ArrayList resList = new ArrayList();
            if (userPriceData1.SectionCode != userPriceData2.SectionCode) resList.Add("SectionCode");
            if (userPriceData1.SectionName != userPriceData2.SectionName) resList.Add("SectionName");
            if (userPriceData1.BLGoodsCode != userPriceData2.BLGoodsCode) resList.Add("BLGoodsCode");
            if (userPriceData1.BLGoodsName != userPriceData2.BLGoodsName) resList.Add("BLGoodsName");
            if (userPriceData1.GoodsMakerCd != userPriceData2.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (userPriceData1.GoodsMakerName != userPriceData2.GoodsMakerName) resList.Add("GoodsMakerName");

            return resList;
        }
    }
}

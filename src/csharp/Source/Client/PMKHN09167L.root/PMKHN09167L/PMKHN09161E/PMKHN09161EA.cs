using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   AuthorityLevel
    /// <summary>
    ///                      権限レベルマスタ
    /// </summary>
    /// <remarks>
    /// <br>note             :   権限レベルマスタヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/7/3</br>
    /// <br>Genarated Date   :   2008/07/18  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class AuthorityLevel
    {
        /// <summary>提供日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _offerDate;

        /// <summary>権限レベル区分</summary>
        /// <remarks>0:職種 1:雇用形態</remarks>
        private Int32 _authorityLevelDiv;

        /// <summary>権限レベルコード</summary>
        /// <remarks>100(最高権限)～10(最低権限)</remarks>
        private Int32 _authorityLevelCd;

        /// <summary>権限レベル名称</summary>
        private string _authorityLevelNm = "";


        /// public propaty name  :  OfferDate
        /// <summary>提供日付プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   提供日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OfferDate
        {
            get { return _offerDate; }
            set { _offerDate = value; }
        }

        /// public propaty name  :  AuthorityLevelDiv
        /// <summary>権限レベル区分プロパティ</summary>
        /// <value>0:職種 1:雇用形態</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   権限レベル区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AuthorityLevelDiv
        {
            get { return _authorityLevelDiv; }
            set { _authorityLevelDiv = value; }
        }

        /// public propaty name  :  AuthorityLevelCd
        /// <summary>権限レベルコードプロパティ</summary>
        /// <value>100(最高権限)～10(最低権限)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   権限レベルコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AuthorityLevelCd
        {
            get { return _authorityLevelCd; }
            set { _authorityLevelCd = value; }
        }

        /// public propaty name  :  AuthorityLevelNm
        /// <summary>権限レベル名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   権限レベル名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AuthorityLevelNm
        {
            get { return _authorityLevelNm; }
            set { _authorityLevelNm = value; }
        }


        /// <summary>
        /// 権限レベルマスタコンストラクタ
        /// </summary>
        /// <returns>AuthorityLevelクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   AuthorityLevelクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public AuthorityLevel()
        {
        }

        /// <summary>
        /// 権限レベルマスタコンストラクタ
        /// </summary>
        /// <param name="offerDate">提供日付(YYYYMMDD)</param>
        /// <param name="authorityLevelDiv">権限レベル区分(0:職種 1:雇用形態)</param>
        /// <param name="authorityLevelCd">権限レベルコード(100(最高権限)～10(最低権限))</param>
        /// <param name="authorityLevelNm">権限レベル名称</param>
        /// <returns>AuthorityLevelクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   AuthorityLevelクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public AuthorityLevel(Int32 offerDate, Int32 authorityLevelDiv, Int32 authorityLevelCd, string authorityLevelNm)
        {
            this._offerDate = offerDate;
            this._authorityLevelDiv = authorityLevelDiv;
            this._authorityLevelCd = authorityLevelCd;
            this._authorityLevelNm = authorityLevelNm;

        }

        /// <summary>
        /// 権限レベルマスタ複製処理
        /// </summary>
        /// <returns>AuthorityLevelクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいAuthorityLevelクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public AuthorityLevel Clone()
        {
            return new AuthorityLevel(this._offerDate, this._authorityLevelDiv, this._authorityLevelCd, this._authorityLevelNm);
        }

        /// <summary>
        /// 権限レベルマスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のAuthorityLevelクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   AuthorityLevelクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(AuthorityLevel target)
        {
            return ((this.OfferDate == target.OfferDate)
                 && (this.AuthorityLevelDiv == target.AuthorityLevelDiv)
                 && (this.AuthorityLevelCd == target.AuthorityLevelCd)
                 && (this.AuthorityLevelNm == target.AuthorityLevelNm));
        }

        /// <summary>
        /// 権限レベルマスタ比較処理
        /// </summary>
        /// <param name="authorityLevel1">
        ///                    比較するAuthorityLevelクラスのインスタンス
        /// </param>
        /// <param name="authorityLevel2">比較するAuthorityLevelクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   AuthorityLevelクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(AuthorityLevel authorityLevel1, AuthorityLevel authorityLevel2)
        {
            return ((authorityLevel1.OfferDate == authorityLevel2.OfferDate)
                 && (authorityLevel1.AuthorityLevelDiv == authorityLevel2.AuthorityLevelDiv)
                 && (authorityLevel1.AuthorityLevelCd == authorityLevel2.AuthorityLevelCd)
                 && (authorityLevel1.AuthorityLevelNm == authorityLevel2.AuthorityLevelNm));
        }
        /// <summary>
        /// 権限レベルマスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のAuthorityLevelクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   AuthorityLevelクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(AuthorityLevel target)
        {
            ArrayList resList = new ArrayList();
            if (this.OfferDate != target.OfferDate) resList.Add("OfferDate");
            if (this.AuthorityLevelDiv != target.AuthorityLevelDiv) resList.Add("AuthorityLevelDiv");
            if (this.AuthorityLevelCd != target.AuthorityLevelCd) resList.Add("AuthorityLevelCd");
            if (this.AuthorityLevelNm != target.AuthorityLevelNm) resList.Add("AuthorityLevelNm");

            return resList;
        }

        /// <summary>
        /// 権限レベルマスタ比較処理
        /// </summary>
        /// <param name="authorityLevel1">比較するAuthorityLevelクラスのインスタンス</param>
        /// <param name="authorityLevel2">比較するAuthorityLevelクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   AuthorityLevelクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(AuthorityLevel authorityLevel1, AuthorityLevel authorityLevel2)
        {
            ArrayList resList = new ArrayList();
            if (authorityLevel1.OfferDate != authorityLevel2.OfferDate) resList.Add("OfferDate");
            if (authorityLevel1.AuthorityLevelDiv != authorityLevel2.AuthorityLevelDiv) resList.Add("AuthorityLevelDiv");
            if (authorityLevel1.AuthorityLevelCd != authorityLevel2.AuthorityLevelCd) resList.Add("AuthorityLevelCd");
            if (authorityLevel1.AuthorityLevelNm != authorityLevel2.AuthorityLevelNm) resList.Add("AuthorityLevelNm");

            return resList;
        }
    }
}

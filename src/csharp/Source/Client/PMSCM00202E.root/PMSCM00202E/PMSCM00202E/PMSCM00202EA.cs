using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   CMTCnectInfo
    /// <summary>
    ///                      簡単問合せ接続情報
    /// </summary>
    /// <remarks>
    /// <br>note             :   簡単問合せ接続情報ヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2010/03/25  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class SimplInqCnectInfo
    {
        /// <summary>レジ番号</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private Int32 _cashRegisterNo;

        /// <summary>得意先コード</summary>
        private Int32 _customerCode;


        /// public propaty name  :  CashRegisterNo
        /// <summary>レジ番号プロパティ</summary>
        /// <value>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   レジ番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CashRegisterNo
        {
            get { return _cashRegisterNo; }
            set { _cashRegisterNo = value; }
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


        /// <summary>
        /// 簡単問合せ接続情報コンストラクタ
        /// </summary>
        /// <returns>CMTCnectInfoクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CMTCnectInfoクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SimplInqCnectInfo()
        {
        }

        /// <summary>
        /// 簡単問合せ接続情報コンストラクタ
        /// </summary>
        /// <param name="cashRegisterNo">レジ番号(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="customerCode">得意先コード</param>
        /// <returns>CMTCnectInfoクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CMTCnectInfoクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SimplInqCnectInfo(Int32 cashRegisterNo, Int32 customerCode)
        {
            this._cashRegisterNo = cashRegisterNo;
            this._customerCode = customerCode;

        }

        /// <summary>
        /// 簡単問合せ接続情報複製処理
        /// </summary>
        /// <returns>CMTCnectInfoクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいCMTCnectInfoクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SimplInqCnectInfo Clone()
        {
            return new SimplInqCnectInfo(this._cashRegisterNo, this._customerCode);
        }

        /// <summary>
        /// 簡単問合せ接続情報比較処理
        /// </summary>
        /// <param name="target">比較対象のCMTCnectInfoクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CMTCnectInfoクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(SimplInqCnectInfo target)
        {
            return ( ( this.CashRegisterNo == target.CashRegisterNo )
                 && ( this.CustomerCode == target.CustomerCode ) );
        }

        /// <summary>
        /// 簡単問合せ接続情報比較処理
        /// </summary>
        /// <param name="cMTCnectInfo1">
        ///                    比較するCMTCnectInfoクラスのインスタンス
        /// </param>
        /// <param name="cMTCnectInfo2">比較するCMTCnectInfoクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CMTCnectInfoクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(SimplInqCnectInfo cMTCnectInfo1, SimplInqCnectInfo cMTCnectInfo2)
        {
            return ( ( cMTCnectInfo1.CashRegisterNo == cMTCnectInfo2.CashRegisterNo )
                 && ( cMTCnectInfo1.CustomerCode == cMTCnectInfo2.CustomerCode ) );
        }
        /// <summary>
        /// 簡単問合せ接続情報比較処理
        /// </summary>
        /// <param name="target">比較対象のCMTCnectInfoクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CMTCnectInfoクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(SimplInqCnectInfo target)
        {
            ArrayList resList = new ArrayList();
            if (this.CashRegisterNo != target.CashRegisterNo) resList.Add("CashRegisterNo");
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");

            return resList;
        }

        /// <summary>
        /// 簡単問合せ接続情報比較処理
        /// </summary>
        /// <param name="cMTCnectInfo1">比較するCMTCnectInfoクラスのインスタンス</param>
        /// <param name="cMTCnectInfo2">比較するCMTCnectInfoクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CMTCnectInfoクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(SimplInqCnectInfo cMTCnectInfo1, SimplInqCnectInfo cMTCnectInfo2)
        {
            ArrayList resList = new ArrayList();
            if (cMTCnectInfo1.CashRegisterNo != cMTCnectInfo2.CashRegisterNo) resList.Add("CashRegisterNo");
            if (cMTCnectInfo1.CustomerCode != cMTCnectInfo2.CustomerCode) resList.Add("CustomerCode");

            return resList;
        }
    }
}

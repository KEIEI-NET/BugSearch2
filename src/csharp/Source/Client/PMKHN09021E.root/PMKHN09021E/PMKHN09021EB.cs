using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   OfrSupplier
    /// <summary>
    ///                      仕入先マスタ（提供）
    /// </summary>
    /// <remarks>
    /// <br>note             :   仕入先マスタ（提供）ヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2007/1/29</br>
    /// <br>Genarated Date   :   2008/10/30  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/4/25  杉村</br>
    /// </remarks>
    public class OfrSupplier
    {
        /// <summary>提供日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _offerDate;

        /// <summary>仕入先コード</summary>
        private Int32 _supplierCd;

        /// <summary>仕入先名1</summary>
        private string _supplierNm1 = "";

        /// <summary>仕入先カナ</summary>
        private string _supplierKana = "";

        /// <summary>仕入先略称</summary>
        private string _supplierSnm = "";


        /// public propaty name  :  OfferDate
        /// <summary>提供日付プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   提供日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime OfferDate
        {
            get { return _offerDate; }
            set { _offerDate = value; }
        }

        /// public propaty name  :  SupplierCd
        /// <summary>仕入先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierCd
        {
            get { return _supplierCd; }
            set { _supplierCd = value; }
        }

        /// public propaty name  :  SupplierNm1
        /// <summary>仕入先名1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先名1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierNm1
        {
            get { return _supplierNm1; }
            set { _supplierNm1 = value; }
        }

        /// public propaty name  :  SupplierKana
        /// <summary>仕入先カナプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先カナプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierKana
        {
            get { return _supplierKana; }
            set { _supplierKana = value; }
        }

        /// public propaty name  :  SupplierSnm
        /// <summary>仕入先略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierSnm
        {
            get { return _supplierSnm; }
            set { _supplierSnm = value; }
        }


        /// <summary>
        /// 仕入先マスタ（提供）コンストラクタ
        /// </summary>
        /// <returns>OfrSupplierクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   OfrSupplierクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public OfrSupplier()
        {
        }

        /// <summary>
        /// 仕入先マスタ（提供）コンストラクタ
        /// </summary>
        /// <param name="offerDate">提供日付(YYYYMMDD)</param>
        /// <param name="supplierCd">仕入先コード</param>
        /// <param name="supplierNm1">仕入先名1</param>
        /// <param name="supplierKana">仕入先カナ</param>
        /// <param name="supplierSnm">仕入先略称</param>
        /// <returns>OfrSupplierクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   OfrSupplierクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public OfrSupplier( DateTime offerDate, Int32 supplierCd, string supplierNm1, string supplierKana, string supplierSnm )
        {
            this._offerDate = offerDate;
            this._supplierCd = supplierCd;
            this._supplierNm1 = supplierNm1;
            this._supplierKana = supplierKana;
            this._supplierSnm = supplierSnm;

        }

        /// <summary>
        /// 仕入先マスタ（提供）複製処理
        /// </summary>
        /// <returns>OfrSupplierクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいOfrSupplierクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public OfrSupplier Clone()
        {
            return new OfrSupplier( this._offerDate, this._supplierCd, this._supplierNm1, this._supplierKana, this._supplierSnm );
        }

        /// <summary>
        /// 仕入先マスタ（提供）比較処理
        /// </summary>
        /// <param name="target">比較対象のOfrSupplierクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   OfrSupplierクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals( OfrSupplier target )
        {
            return ((this.OfferDate == target.OfferDate)
                 && (this.SupplierCd == target.SupplierCd)
                 && (this.SupplierNm1 == target.SupplierNm1)
                 && (this.SupplierKana == target.SupplierKana)
                 && (this.SupplierSnm == target.SupplierSnm));
        }

        /// <summary>
        /// 仕入先マスタ（提供）比較処理
        /// </summary>
        /// <param name="ofrSupplier1">
        ///                    比較するOfrSupplierクラスのインスタンス
        /// </param>
        /// <param name="ofrSupplier2">比較するOfrSupplierクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   OfrSupplierクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals( OfrSupplier ofrSupplier1, OfrSupplier ofrSupplier2 )
        {
            return ((ofrSupplier1.OfferDate == ofrSupplier2.OfferDate)
                 && (ofrSupplier1.SupplierCd == ofrSupplier2.SupplierCd)
                 && (ofrSupplier1.SupplierNm1 == ofrSupplier2.SupplierNm1)
                 && (ofrSupplier1.SupplierKana == ofrSupplier2.SupplierKana)
                 && (ofrSupplier1.SupplierSnm == ofrSupplier2.SupplierSnm));
        }
        /// <summary>
        /// 仕入先マスタ（提供）比較処理
        /// </summary>
        /// <param name="target">比較対象のOfrSupplierクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   OfrSupplierクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare( OfrSupplier target )
        {
            ArrayList resList = new ArrayList();
            if ( this.OfferDate != target.OfferDate ) resList.Add( "OfferDate" );
            if ( this.SupplierCd != target.SupplierCd ) resList.Add( "SupplierCd" );
            if ( this.SupplierNm1 != target.SupplierNm1 ) resList.Add( "SupplierNm1" );
            if ( this.SupplierKana != target.SupplierKana ) resList.Add( "SupplierKana" );
            if ( this.SupplierSnm != target.SupplierSnm ) resList.Add( "SupplierSnm" );

            return resList;
        }

        /// <summary>
        /// 仕入先マスタ（提供）比較処理
        /// </summary>
        /// <param name="ofrSupplier1">比較するOfrSupplierクラスのインスタンス</param>
        /// <param name="ofrSupplier2">比較するOfrSupplierクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   OfrSupplierクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare( OfrSupplier ofrSupplier1, OfrSupplier ofrSupplier2 )
        {
            ArrayList resList = new ArrayList();
            if ( ofrSupplier1.OfferDate != ofrSupplier2.OfferDate ) resList.Add( "OfferDate" );
            if ( ofrSupplier1.SupplierCd != ofrSupplier2.SupplierCd ) resList.Add( "SupplierCd" );
            if ( ofrSupplier1.SupplierNm1 != ofrSupplier2.SupplierNm1 ) resList.Add( "SupplierNm1" );
            if ( ofrSupplier1.SupplierKana != ofrSupplier2.SupplierKana ) resList.Add( "SupplierKana" );
            if ( ofrSupplier1.SupplierSnm != ofrSupplier2.SupplierSnm ) resList.Add( "SupplierSnm" );

            return resList;
        }
    }
}

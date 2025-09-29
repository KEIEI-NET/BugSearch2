//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   未入金一覧表 抽出条件クラス
//                  :   PMKAU02004E.DLL
// Name Space       :   Broadleaf.Application.UIData
// Programmer       :   22018 鈴木正臣
// Date             :   2010/07/01
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//**********************************************************************
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// public class name:   NoDepSalListCdtn
    /// <summary>
    ///                      未入金一覧表抽出条件ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   未入金一覧表抽出条件ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/3/25</br>
    /// <br>Genarated Date   :   2010/07/01  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class NoDepSalListCdtn
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>開始請求拠点コード</summary>
        private string _demandAddUpSecCdSt = "";

        /// <summary>終了請求拠点コード</summary>
        private string _demandAddUpSecCdEd = "";

        /// <summary>開始請求得意先コード</summary>
        private Int32 _claimCodeSt;

        /// <summary>終了請求得意先コード</summary>
        private Int32 _claimCodeEd;

        /// <summary>日付区分</summary>
        /// <remarks>0:売上日, 1:入力日</remarks>
        private Int32 _targetDateDiv;

        /// <summary>開始対象日</summary>
        /// <remarks>yyyymmdd</remarks>
        private Int32 _dateSt;

        /// <summary>終了対象日</summary>
        /// <remarks>yyyymmdd</remarks>
        private Int32 _dateEd;

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";


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

        /// public propaty name  :  DemandAddUpSecCdSt
        /// <summary>開始請求拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始請求拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DemandAddUpSecCdSt
        {
            get { return _demandAddUpSecCdSt; }
            set { _demandAddUpSecCdSt = value; }
        }

        /// public propaty name  :  DemandAddUpSecCdEd
        /// <summary>終了請求拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了請求拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DemandAddUpSecCdEd
        {
            get { return _demandAddUpSecCdEd; }
            set { _demandAddUpSecCdEd = value; }
        }

        /// public propaty name  :  ClaimCodeSt
        /// <summary>開始請求得意先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始請求得意先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ClaimCodeSt
        {
            get { return _claimCodeSt; }
            set { _claimCodeSt = value; }
        }

        /// public propaty name  :  ClaimCodeEd
        /// <summary>終了請求得意先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了請求得意先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ClaimCodeEd
        {
            get { return _claimCodeEd; }
            set { _claimCodeEd = value; }
        }

        /// public propaty name  :  TargetDateDiv
        /// <summary>日付区分プロパティ</summary>
        /// <value>0:売上日, 1:入力日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   日付区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TargetDateDiv
        {
            get { return _targetDateDiv; }
            set { _targetDateDiv = value; }
        }

        /// public propaty name  :  DateSt
        /// <summary>開始対象日プロパティ</summary>
        /// <value>yyyymmdd</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始対象日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DateSt
        {
            get { return _dateSt; }
            set { _dateSt = value; }
        }

        /// public propaty name  :  DateEd
        /// <summary>終了対象日プロパティ</summary>
        /// <value>yyyymmdd</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了対象日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DateEd
        {
            get { return _dateEd; }
            set { _dateEd = value; }
        }

        /// public propaty name  :  EnterpriseName
        /// <summary>企業名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   企業名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EnterpriseName
        {
            get { return _enterpriseName; }
            set { _enterpriseName = value; }
        }


        /// <summary>
        /// 未入金一覧表抽出条件ワークコンストラクタ
        /// </summary>
        /// <returns>NoDepSalListCdtnクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   NoDepSalListCdtnクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public NoDepSalListCdtn()
        {
        }

        /// <summary>
        /// 未入金一覧表抽出条件ワークコンストラクタ
        /// </summary>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="demandAddUpSecCdSt">開始請求拠点コード</param>
        /// <param name="demandAddUpSecCdEd">終了請求拠点コード</param>
        /// <param name="claimCodeSt">開始請求得意先コード</param>
        /// <param name="claimCodeEd">終了請求得意先コード</param>
        /// <param name="targetDateDiv">日付区分(0:売上日, 1:入力日)</param>
        /// <param name="dateSt">開始対象日(yyyymmdd)</param>
        /// <param name="dateEd">終了対象日(yyyymmdd)</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <returns>NoDepSalListCdtnクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   NoDepSalListCdtnクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public NoDepSalListCdtn( string enterpriseCode, string demandAddUpSecCdSt, string demandAddUpSecCdEd, Int32 claimCodeSt, Int32 claimCodeEd, Int32 targetDateDiv, Int32 dateSt, Int32 dateEd, string enterpriseName )
        {
            this._enterpriseCode = enterpriseCode;
            this._demandAddUpSecCdSt = demandAddUpSecCdSt;
            this._demandAddUpSecCdEd = demandAddUpSecCdEd;
            this._claimCodeSt = claimCodeSt;
            this._claimCodeEd = claimCodeEd;
            this._targetDateDiv = targetDateDiv;
            this._dateSt = dateSt;
            this._dateEd = dateEd;
            this._enterpriseName = enterpriseName;

        }

        /// <summary>
        /// 未入金一覧表抽出条件ワーク複製処理
        /// </summary>
        /// <returns>NoDepSalListCdtnクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいNoDepSalListCdtnクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public NoDepSalListCdtn Clone()
        {
            return new NoDepSalListCdtn( this._enterpriseCode, this._demandAddUpSecCdSt, this._demandAddUpSecCdEd, this._claimCodeSt, this._claimCodeEd, this._targetDateDiv, this._dateSt, this._dateEd, this._enterpriseName );
        }

        /// <summary>
        /// 未入金一覧表抽出条件ワーク比較処理
        /// </summary>
        /// <param name="target">比較対象のNoDepSalListCdtnクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   NoDepSalListCdtnクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals( NoDepSalListCdtn target )
        {
            return ((this.EnterpriseCode == target.EnterpriseCode)
                 && (this.DemandAddUpSecCdSt == target.DemandAddUpSecCdSt)
                 && (this.DemandAddUpSecCdEd == target.DemandAddUpSecCdEd)
                 && (this.ClaimCodeSt == target.ClaimCodeSt)
                 && (this.ClaimCodeEd == target.ClaimCodeEd)
                 && (this.TargetDateDiv == target.TargetDateDiv)
                 && (this.DateSt == target.DateSt)
                 && (this.DateEd == target.DateEd)
                 && (this.EnterpriseName == target.EnterpriseName));
        }

        /// <summary>
        /// 未入金一覧表抽出条件ワーク比較処理
        /// </summary>
        /// <param name="noDepSalListCdtn1">
        ///                    比較するNoDepSalListCdtnクラスのインスタンス
        /// </param>
        /// <param name="noDepSalListCdtn2">比較するNoDepSalListCdtnクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   NoDepSalListCdtnクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals( NoDepSalListCdtn noDepSalListCdtn1, NoDepSalListCdtn noDepSalListCdtn2 )
        {
            return ((noDepSalListCdtn1.EnterpriseCode == noDepSalListCdtn2.EnterpriseCode)
                 && (noDepSalListCdtn1.DemandAddUpSecCdSt == noDepSalListCdtn2.DemandAddUpSecCdSt)
                 && (noDepSalListCdtn1.DemandAddUpSecCdEd == noDepSalListCdtn2.DemandAddUpSecCdEd)
                 && (noDepSalListCdtn1.ClaimCodeSt == noDepSalListCdtn2.ClaimCodeSt)
                 && (noDepSalListCdtn1.ClaimCodeEd == noDepSalListCdtn2.ClaimCodeEd)
                 && (noDepSalListCdtn1.TargetDateDiv == noDepSalListCdtn2.TargetDateDiv)
                 && (noDepSalListCdtn1.DateSt == noDepSalListCdtn2.DateSt)
                 && (noDepSalListCdtn1.DateEd == noDepSalListCdtn2.DateEd)
                 && (noDepSalListCdtn1.EnterpriseName == noDepSalListCdtn2.EnterpriseName));
        }
        /// <summary>
        /// 未入金一覧表抽出条件ワーク比較処理
        /// </summary>
        /// <param name="target">比較対象のNoDepSalListCdtnクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   NoDepSalListCdtnクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare( NoDepSalListCdtn target )
        {
            ArrayList resList = new ArrayList();
            if ( this.EnterpriseCode != target.EnterpriseCode ) resList.Add( "EnterpriseCode" );
            if ( this.DemandAddUpSecCdSt != target.DemandAddUpSecCdSt ) resList.Add( "DemandAddUpSecCdSt" );
            if ( this.DemandAddUpSecCdEd != target.DemandAddUpSecCdEd ) resList.Add( "DemandAddUpSecCdEd" );
            if ( this.ClaimCodeSt != target.ClaimCodeSt ) resList.Add( "ClaimCodeSt" );
            if ( this.ClaimCodeEd != target.ClaimCodeEd ) resList.Add( "ClaimCodeEd" );
            if ( this.TargetDateDiv != target.TargetDateDiv ) resList.Add( "TargetDateDiv" );
            if ( this.DateSt != target.DateSt ) resList.Add( "DateSt" );
            if ( this.DateEd != target.DateEd ) resList.Add( "DateEd" );
            if ( this.EnterpriseName != target.EnterpriseName ) resList.Add( "EnterpriseName" );

            return resList;
        }

        /// <summary>
        /// 未入金一覧表抽出条件ワーク比較処理
        /// </summary>
        /// <param name="noDepSalListCdtn1">比較するNoDepSalListCdtnクラスのインスタンス</param>
        /// <param name="noDepSalListCdtn2">比較するNoDepSalListCdtnクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   NoDepSalListCdtnクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare( NoDepSalListCdtn noDepSalListCdtn1, NoDepSalListCdtn noDepSalListCdtn2 )
        {
            ArrayList resList = new ArrayList();
            if ( noDepSalListCdtn1.EnterpriseCode != noDepSalListCdtn2.EnterpriseCode ) resList.Add( "EnterpriseCode" );
            if ( noDepSalListCdtn1.DemandAddUpSecCdSt != noDepSalListCdtn2.DemandAddUpSecCdSt ) resList.Add( "DemandAddUpSecCdSt" );
            if ( noDepSalListCdtn1.DemandAddUpSecCdEd != noDepSalListCdtn2.DemandAddUpSecCdEd ) resList.Add( "DemandAddUpSecCdEd" );
            if ( noDepSalListCdtn1.ClaimCodeSt != noDepSalListCdtn2.ClaimCodeSt ) resList.Add( "ClaimCodeSt" );
            if ( noDepSalListCdtn1.ClaimCodeEd != noDepSalListCdtn2.ClaimCodeEd ) resList.Add( "ClaimCodeEd" );
            if ( noDepSalListCdtn1.TargetDateDiv != noDepSalListCdtn2.TargetDateDiv ) resList.Add( "TargetDateDiv" );
            if ( noDepSalListCdtn1.DateSt != noDepSalListCdtn2.DateSt ) resList.Add( "DateSt" );
            if ( noDepSalListCdtn1.DateEd != noDepSalListCdtn2.DateEd ) resList.Add( "DateEd" );
            if ( noDepSalListCdtn1.EnterpriseName != noDepSalListCdtn2.EnterpriseName ) resList.Add( "EnterpriseName" );

            return resList;
        }
    }
}

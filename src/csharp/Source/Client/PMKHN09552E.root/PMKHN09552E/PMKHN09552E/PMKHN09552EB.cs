//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 重点品目設定マスタ
// プログラム概要   : 重点品目設定の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/05/22  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   ImportantPrtStOrder
    /// <summary>
    ///                      重点品目設定マスタ抽出条件クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   重点品目設定マスタ抽出条件クラスヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :    2009/4/13</br>
    /// <br>Genarated Date   :   2009/05/22  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class ImportantPrtStOrder
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>拠点コード</summary>
        /// <remarks>00は全社</remarks>
        private string _sectionCode = "";

        /// <summary>開始得意先コード</summary>
        /// <remarks>0は全得意先</remarks>
        private Int32 _st_CustomerCode;

        /// <summary>終了得意先コード</summary>
        /// <remarks>0は全得意先</remarks>
        private Int32 _ed_CustomerCode;

        /// <summary>開始仕入先コード</summary>
        private Int32 _st_SupplierCd;

        /// <summary>終了仕入先コード</summary>
        private Int32 _ed_SupplierCd;

        /// <summary>開始商品中分類コード</summary>
        private Int32 _st_GoodsMGroup;

        /// <summary>終了商品中分類コード</summary>
        private Int32 _ed_GoodsMGroup;

        /// <summary>開始BLグループコード</summary>
        private Int32 _st_BLGroupCode;

        /// <summary>終了BLグループコード</summary>
        private Int32 _ed_BLGroupCode;

        /// <summary>開始BL商品コード</summary>
        private Int32 _st_BLGoodsCode;

        /// <summary>終了BL商品コード</summary>
        private Int32 _ed_BLGoodsCode;

        /// <summary>開始商品メーカーコード</summary>
        private Int32 _st_GoodsMakerCd;

        /// <summary>終了商品メーカーコード</summary>
        private Int32 _ed_GoodsMakerCd;

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

        /// public propaty name  :  SectionCode
        /// <summary>拠点コードプロパティ</summary>
        /// <value>00は全社</value>
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

        /// public propaty name  :  St_CustomerCode
        /// <summary>開始得意先コードプロパティ</summary>
        /// <value>0は全得意先</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始得意先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_CustomerCode
        {
            get { return _st_CustomerCode; }
            set { _st_CustomerCode = value; }
        }

        /// public propaty name  :  Ed_CustomerCode
        /// <summary>終了得意先コードプロパティ</summary>
        /// <value>0は全得意先</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了得意先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_CustomerCode
        {
            get { return _ed_CustomerCode; }
            set { _ed_CustomerCode = value; }
        }

        /// public propaty name  :  St_SupplierCd
        /// <summary>開始仕入先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始仕入先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_SupplierCd
        {
            get { return _st_SupplierCd; }
            set { _st_SupplierCd = value; }
        }

        /// public propaty name  :  Ed_SupplierCd
        /// <summary>終了仕入先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了仕入先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_SupplierCd
        {
            get { return _ed_SupplierCd; }
            set { _ed_SupplierCd = value; }
        }

        /// public propaty name  :  St_GoodsMGroup
        /// <summary>開始商品中分類コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始商品中分類コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_GoodsMGroup
        {
            get { return _st_GoodsMGroup; }
            set { _st_GoodsMGroup = value; }
        }

        /// public propaty name  :  Ed_GoodsMGroup
        /// <summary>終了商品中分類コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了商品中分類コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_GoodsMGroup
        {
            get { return _ed_GoodsMGroup; }
            set { _ed_GoodsMGroup = value; }
        }

        /// public propaty name  :  St_BLGroupCode
        /// <summary>開始BLグループコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始BLグループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_BLGroupCode
        {
            get { return _st_BLGroupCode; }
            set { _st_BLGroupCode = value; }
        }

        /// public propaty name  :  Ed_BLGroupCode
        /// <summary>終了BLグループコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了BLグループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_BLGroupCode
        {
            get { return _ed_BLGroupCode; }
            set { _ed_BLGroupCode = value; }
        }

        /// public propaty name  :  St_BLGoodsCode
        /// <summary>開始BL商品コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始BL商品コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_BLGoodsCode
        {
            get { return _st_BLGoodsCode; }
            set { _st_BLGoodsCode = value; }
        }

        /// public propaty name  :  Ed_BLGoodsCode
        /// <summary>終了BL商品コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了BL商品コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_BLGoodsCode
        {
            get { return _ed_BLGoodsCode; }
            set { _ed_BLGoodsCode = value; }
        }

        /// public propaty name  :  St_GoodsMakerCd
        /// <summary>開始商品メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始商品メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_GoodsMakerCd
        {
            get { return _st_GoodsMakerCd; }
            set { _st_GoodsMakerCd = value; }
        }

        /// public propaty name  :  Ed_GoodsMakerCd
        /// <summary>終了商品メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了商品メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_GoodsMakerCd
        {
            get { return _ed_GoodsMakerCd; }
            set { _ed_GoodsMakerCd = value; }
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
        /// 重点品目設定マスタ抽出条件クラスコンストラクタ
        /// </summary>
        /// <returns>ImportantPrtStOrderクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ImportantPrtStOrderクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ImportantPrtStOrder()
        {
        }

        /// <summary>
        /// 重点品目設定マスタ抽出条件クラスコンストラクタ
        /// </summary>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="sectionCode">拠点コード(00は全社)</param>
        /// <param name="st_CustomerCode">開始得意先コード(0は全得意先)</param>
        /// <param name="ed_CustomerCode">終了得意先コード(0は全得意先)</param>
        /// <param name="st_SupplierCd">開始仕入先コード</param>
        /// <param name="ed_SupplierCd">終了仕入先コード</param>
        /// <param name="st_GoodsMGroup">開始商品中分類コード</param>
        /// <param name="ed_GoodsMGroup">終了商品中分類コード</param>
        /// <param name="st_BLGroupCode">開始BLグループコード</param>
        /// <param name="ed_BLGroupCode">終了BLグループコード</param>
        /// <param name="st_BLGoodsCode">開始BL商品コード</param>
        /// <param name="ed_BLGoodsCode">終了BL商品コード</param>
        /// <param name="st_GoodsMakerCd">開始商品メーカーコード</param>
        /// <param name="ed_GoodsMakerCd">終了商品メーカーコード</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <returns>ImportantPrtStOrderクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ImportantPrtStOrderクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ImportantPrtStOrder( string enterpriseCode, string sectionCode, Int32 st_CustomerCode, Int32 ed_CustomerCode, Int32 st_SupplierCd, Int32 ed_SupplierCd, Int32 st_GoodsMGroup, Int32 ed_GoodsMGroup, Int32 st_BLGroupCode, Int32 ed_BLGroupCode, Int32 st_BLGoodsCode, Int32 ed_BLGoodsCode, Int32 st_GoodsMakerCd, Int32 ed_GoodsMakerCd, string enterpriseName )
        {
            this._enterpriseCode = enterpriseCode;
            this._sectionCode = sectionCode;
            this._st_CustomerCode = st_CustomerCode;
            this._ed_CustomerCode = ed_CustomerCode;
            this._st_SupplierCd = st_SupplierCd;
            this._ed_SupplierCd = ed_SupplierCd;
            this._st_GoodsMGroup = st_GoodsMGroup;
            this._ed_GoodsMGroup = ed_GoodsMGroup;
            this._st_BLGroupCode = st_BLGroupCode;
            this._ed_BLGroupCode = ed_BLGroupCode;
            this._st_BLGoodsCode = st_BLGoodsCode;
            this._ed_BLGoodsCode = ed_BLGoodsCode;
            this._st_GoodsMakerCd = st_GoodsMakerCd;
            this._ed_GoodsMakerCd = ed_GoodsMakerCd;
            this._enterpriseName = enterpriseName;

        }

        /// <summary>
        /// 重点品目設定マスタ抽出条件クラス複製処理
        /// </summary>
        /// <returns>ImportantPrtStOrderクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいImportantPrtStOrderクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ImportantPrtStOrder Clone()
        {
            return new ImportantPrtStOrder( this._enterpriseCode, this._sectionCode, this._st_CustomerCode, this._ed_CustomerCode, this._st_SupplierCd, this._ed_SupplierCd, this._st_GoodsMGroup, this._ed_GoodsMGroup, this._st_BLGroupCode, this._ed_BLGroupCode, this._st_BLGoodsCode, this._ed_BLGoodsCode, this._st_GoodsMakerCd, this._ed_GoodsMakerCd, this._enterpriseName );
        }

        /// <summary>
        /// 重点品目設定マスタ抽出条件クラス比較処理
        /// </summary>
        /// <param name="target">比較対象のImportantPrtStOrderクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ImportantPrtStOrderクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals( ImportantPrtStOrder target )
        {
            return ((this.EnterpriseCode == target.EnterpriseCode)
                 && (this.SectionCode == target.SectionCode)
                 && (this.St_CustomerCode == target.St_CustomerCode)
                 && (this.Ed_CustomerCode == target.Ed_CustomerCode)
                 && (this.St_SupplierCd == target.St_SupplierCd)
                 && (this.Ed_SupplierCd == target.Ed_SupplierCd)
                 && (this.St_GoodsMGroup == target.St_GoodsMGroup)
                 && (this.Ed_GoodsMGroup == target.Ed_GoodsMGroup)
                 && (this.St_BLGroupCode == target.St_BLGroupCode)
                 && (this.Ed_BLGroupCode == target.Ed_BLGroupCode)
                 && (this.St_BLGoodsCode == target.St_BLGoodsCode)
                 && (this.Ed_BLGoodsCode == target.Ed_BLGoodsCode)
                 && (this.St_GoodsMakerCd == target.St_GoodsMakerCd)
                 && (this.Ed_GoodsMakerCd == target.Ed_GoodsMakerCd)
                 && (this.EnterpriseName == target.EnterpriseName));
        }

        /// <summary>
        /// 重点品目設定マスタ抽出条件クラス比較処理
        /// </summary>
        /// <param name="sCMPrtSettingOrder1">
        ///                    比較するImportantPrtStOrderクラスのインスタンス
        /// </param>
        /// <param name="sCMPrtSettingOrder2">比較するImportantPrtStOrderクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ImportantPrtStOrderクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals( ImportantPrtStOrder importantPrtStOrder1, ImportantPrtStOrder importantPrtStOrder2 )
        {
            return ((importantPrtStOrder1.EnterpriseCode == importantPrtStOrder2.EnterpriseCode)
                 && (importantPrtStOrder1.SectionCode == importantPrtStOrder2.SectionCode)
                 && (importantPrtStOrder1.St_CustomerCode == importantPrtStOrder2.St_CustomerCode)
                 && (importantPrtStOrder1.Ed_CustomerCode == importantPrtStOrder2.Ed_CustomerCode)
                 && (importantPrtStOrder1.St_SupplierCd == importantPrtStOrder2.St_SupplierCd)
                 && (importantPrtStOrder1.Ed_SupplierCd == importantPrtStOrder2.Ed_SupplierCd)
                 && (importantPrtStOrder1.St_GoodsMGroup == importantPrtStOrder2.St_GoodsMGroup)
                 && (importantPrtStOrder1.Ed_GoodsMGroup == importantPrtStOrder2.Ed_GoodsMGroup)
                 && (importantPrtStOrder1.St_BLGroupCode == importantPrtStOrder2.St_BLGroupCode)
                 && (importantPrtStOrder1.Ed_BLGroupCode == importantPrtStOrder2.Ed_BLGroupCode)
                 && (importantPrtStOrder1.St_BLGoodsCode == importantPrtStOrder2.St_BLGoodsCode)
                 && (importantPrtStOrder1.Ed_BLGoodsCode == importantPrtStOrder2.Ed_BLGoodsCode)
                 && (importantPrtStOrder1.St_GoodsMakerCd == importantPrtStOrder2.St_GoodsMakerCd)
                 && (importantPrtStOrder1.Ed_GoodsMakerCd == importantPrtStOrder2.Ed_GoodsMakerCd)
                 && (importantPrtStOrder1.EnterpriseName == importantPrtStOrder2.EnterpriseName));
        }
        /// <summary>
        /// 重点品目設定マスタ抽出条件クラス比較処理
        /// </summary>
        /// <param name="target">比較対象のImportantPrtStOrderクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ImportantPrtStOrderクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare( ImportantPrtStOrder target )
        {
            ArrayList resList = new ArrayList();
            if ( this.EnterpriseCode != target.EnterpriseCode ) resList.Add( "EnterpriseCode" );
            if ( this.SectionCode != target.SectionCode ) resList.Add( "SectionCode" );
            if ( this.St_CustomerCode != target.St_CustomerCode ) resList.Add( "St_CustomerCode" );
            if ( this.Ed_CustomerCode != target.Ed_CustomerCode ) resList.Add( "Ed_CustomerCode" );
            if ( this.St_SupplierCd != target.St_SupplierCd ) resList.Add( "St_SupplierCd" );
            if ( this.Ed_SupplierCd != target.Ed_SupplierCd ) resList.Add( "Ed_SupplierCd" );
            if ( this.St_GoodsMGroup != target.St_GoodsMGroup ) resList.Add( "St_GoodsMGroup" );
            if ( this.Ed_GoodsMGroup != target.Ed_GoodsMGroup ) resList.Add( "Ed_GoodsMGroup" );
            if ( this.St_BLGroupCode != target.St_BLGroupCode ) resList.Add( "St_BLGroupCode" );
            if ( this.Ed_BLGroupCode != target.Ed_BLGroupCode ) resList.Add( "Ed_BLGroupCode" );
            if ( this.St_BLGoodsCode != target.St_BLGoodsCode ) resList.Add( "St_BLGoodsCode" );
            if ( this.Ed_BLGoodsCode != target.Ed_BLGoodsCode ) resList.Add( "Ed_BLGoodsCode" );
            if ( this.St_GoodsMakerCd != target.St_GoodsMakerCd ) resList.Add( "St_GoodsMakerCd" );
            if ( this.Ed_GoodsMakerCd != target.Ed_GoodsMakerCd ) resList.Add( "Ed_GoodsMakerCd" );
            if ( this.EnterpriseName != target.EnterpriseName ) resList.Add( "EnterpriseName" );

            return resList;
        }

        /// <summary>
        /// 重点品目設定マスタ抽出条件クラス比較処理
        /// </summary>
        /// <param name="sCMPrtSettingOrder1">比較するImportantPrtStOrderクラスのインスタンス</param>
        /// <param name="sCMPrtSettingOrder2">比較するImportantPrtStOrderクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ImportantPrtStOrderクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare( ImportantPrtStOrder importantPrtStOrder1, ImportantPrtStOrder importantPrtStOrder2 )
        {
            ArrayList resList = new ArrayList();
            if ( importantPrtStOrder1.EnterpriseCode != importantPrtStOrder2.EnterpriseCode ) resList.Add( "EnterpriseCode" );
            if ( importantPrtStOrder1.SectionCode != importantPrtStOrder2.SectionCode ) resList.Add( "SectionCode" );
            if ( importantPrtStOrder1.St_CustomerCode != importantPrtStOrder2.St_CustomerCode ) resList.Add( "St_CustomerCode" );
            if ( importantPrtStOrder1.Ed_CustomerCode != importantPrtStOrder2.Ed_CustomerCode ) resList.Add( "Ed_CustomerCode" );
            if ( importantPrtStOrder1.St_SupplierCd != importantPrtStOrder2.St_SupplierCd ) resList.Add( "St_SupplierCd" );
            if ( importantPrtStOrder1.Ed_SupplierCd != importantPrtStOrder2.Ed_SupplierCd ) resList.Add( "Ed_SupplierCd" );
            if ( importantPrtStOrder1.St_GoodsMGroup != importantPrtStOrder2.St_GoodsMGroup ) resList.Add( "St_GoodsMGroup" );
            if ( importantPrtStOrder1.Ed_GoodsMGroup != importantPrtStOrder2.Ed_GoodsMGroup ) resList.Add( "Ed_GoodsMGroup" );
            if ( importantPrtStOrder1.St_BLGroupCode != importantPrtStOrder2.St_BLGroupCode ) resList.Add( "St_BLGroupCode" );
            if ( importantPrtStOrder1.Ed_BLGroupCode != importantPrtStOrder2.Ed_BLGroupCode ) resList.Add( "Ed_BLGroupCode" );
            if ( importantPrtStOrder1.St_BLGoodsCode != importantPrtStOrder2.St_BLGoodsCode ) resList.Add( "St_BLGoodsCode" );
            if ( importantPrtStOrder1.Ed_BLGoodsCode != importantPrtStOrder2.Ed_BLGoodsCode ) resList.Add( "Ed_BLGoodsCode" );
            if ( importantPrtStOrder1.St_GoodsMakerCd != importantPrtStOrder2.St_GoodsMakerCd ) resList.Add( "St_GoodsMakerCd" );
            if ( importantPrtStOrder1.Ed_GoodsMakerCd != importantPrtStOrder2.Ed_GoodsMakerCd ) resList.Add( "Ed_GoodsMakerCd" );
            if ( importantPrtStOrder1.EnterpriseName != importantPrtStOrder2.EnterpriseName ) resList.Add( "EnterpriseName" );

            return resList;
        }
    }
}

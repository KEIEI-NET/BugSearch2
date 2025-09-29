//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 表示区分マスタメンテナンス
// プログラム概要   : 表示区分マスタの登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 呉元嘯
// 作 成 日  2009/10/15  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   PriceSelectSet
    /// <summary>
    ///                      標準価格選択設定マスタ
    /// </summary>
    /// <remarks>
    /// <br>note             :   標準価格選択設定マスタヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2009/09/15</br>
    /// <br>Genarated Date   :   2009/10/15  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class PriceSelectSet
    {
        /// <summary>作成日時</summary>
        /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        private DateTime _createDateTime;

        /// <summary>更新日時</summary>
        /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        private DateTime _updateDateTime;

        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>GUID</summary>
        /// <remarks>共通ファイルヘッダ</remarks>
        private Guid _fileHeaderGuid;

        /// <summary>更新従業員コード</summary>
        /// <remarks>共通ファイルヘッダ</remarks>
        private string _updEmployeeCode = "";

        /// <summary>更新アセンブリID1</summary>
        /// <remarks>共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）</remarks>
        private string _updAssemblyId1 = "";

        /// <summary>更新アセンブリID2</summary>
        /// <remarks>共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）</remarks>
        private string _updAssemblyId2 = "";

        /// <summary>論理削除区分</summary>
        /// <remarks>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>標準価格選択設定パターン</summary>
        /// <remarks>0:ﾒｰｶｰｺｰﾄﾞ・BLｺｰﾄﾞ・得意先ｺｰﾄﾞ,1:ﾒｰｶｰｺｰﾄﾞ・得意先ｺｰﾄﾞ,2:BLｺｰﾄﾞ・得意先ｺｰﾄﾞ,3:ﾒｰｶｰｺｰﾄﾞ・BLｺｰﾄﾞ・得意先掛率ｸﾞﾙｰﾌﾟ,4:ﾒｰｶｰｺｰﾄﾞ・得意先掛率ｸﾞﾙｰﾌﾟ,5:BLｺｰﾄﾞ・得意先掛率ｸﾞﾙｰﾌﾟ,6:ﾒｰｶｰｺｰﾄﾞ・BLｺｰﾄﾞ,7:ﾒｰｶｰｺｰﾄﾞ,8:BLｺｰﾄﾞ</remarks>
        private Int32 _priceSelectPtn;

        /// <summary>商品メーカーコード</summary>
        private Int32 _goodsMakerCd;

        /// <summary>BL商品コード</summary>
        private Int32 _bLGoodsCode;

        /// <summary>得意先掛率グループコード</summary>
        private Int32 _custRateGrpCode;

        /// <summary>得意先コード</summary>
        private Int32 _customerCode;

        /// <summary>標準価格選択区分</summary>
        /// <remarks>0:優良,1:純正,2:高い方(1:N),,3:高い方(1:1)</remarks>
        private Int32 _priceSelectDiv;

        /// <summary>得意先略称</summary>
        private string _customerSnm = "";

        /// <summary>BL商品コード名称（全角）</summary>
        private string _bLGoodsFullName = "";

        /// <summary>メーカー名称</summary>
        private string _makerName = "";

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";

        /// <summary>更新従業員名称</summary>
        private string _updEmployeeName = "";


        /// public propaty name  :  CreateDateTime
        /// <summary>作成日時プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime CreateDateTime
        {
            get { return _createDateTime; }
            set { _createDateTime = value; }
        }

        /// public propaty name  :  CreateDateTimeJpFormal
        /// <summary>作成日時 和暦プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CreateDateTimeJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeJpInFormal
        /// <summary>作成日時 和暦(略)プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CreateDateTimeJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeAdFormal
        /// <summary>作成日時 西暦プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CreateDateTimeAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeAdInFormal
        /// <summary>作成日時 西暦(略)プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CreateDateTimeAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _createDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTime
        /// <summary>更新日時プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime UpdateDateTime
        {
            get { return _updateDateTime; }
            set { _updateDateTime = value; }
        }

        /// public propaty name  :  UpdateDateTimeJpFormal
        /// <summary>更新日時 和暦プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdateDateTimeJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeJpInFormal
        /// <summary>更新日時 和暦(略)プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdateDateTimeJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeAdFormal
        /// <summary>更新日時 西暦プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdateDateTimeAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDateTime); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeAdInFormal
        /// <summary>更新日時 西暦(略)プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdateDateTimeAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _updateDateTime); }
            set { }
        }

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

        /// public propaty name  :  FileHeaderGuid
        /// <summary>GUIDプロパティ</summary>
        /// <value>共通ファイルヘッダ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   GUIDプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Guid FileHeaderGuid
        {
            get { return _fileHeaderGuid; }
            set { _fileHeaderGuid = value; }
        }

        /// public propaty name  :  UpdEmployeeCode
        /// <summary>更新従業員コードプロパティ</summary>
        /// <value>共通ファイルヘッダ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdEmployeeCode
        {
            get { return _updEmployeeCode; }
            set { _updEmployeeCode = value; }
        }

        /// public propaty name  :  UpdAssemblyId1
        /// <summary>更新アセンブリID1プロパティ</summary>
        /// <value>共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新アセンブリID1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdAssemblyId1
        {
            get { return _updAssemblyId1; }
            set { _updAssemblyId1 = value; }
        }

        /// public propaty name  :  UpdAssemblyId2
        /// <summary>更新アセンブリID2プロパティ</summary>
        /// <value>共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新アセンブリID2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdAssemblyId2
        {
            get { return _updAssemblyId2; }
            set { _updAssemblyId2 = value; }
        }

        /// public propaty name  :  LogicalDeleteCode
        /// <summary>論理削除区分プロパティ</summary>
        /// <value>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   論理削除区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 LogicalDeleteCode
        {
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
        }

        /// public propaty name  :  PriceSelectPtn
        /// <summary>標準価格選択設定パターンプロパティ</summary>
        /// <value>0:ﾒｰｶｰｺｰﾄﾞ・BLｺｰﾄﾞ・得意先ｺｰﾄﾞ,1:ﾒｰｶｰｺｰﾄﾞ・得意先ｺｰﾄﾞ,2:BLｺｰﾄﾞ・得意先ｺｰﾄﾞ,3:ﾒｰｶｰｺｰﾄﾞ・BLｺｰﾄﾞ・得意先掛率ｸﾞﾙｰﾌﾟ,4:ﾒｰｶｰｺｰﾄﾞ・得意先掛率ｸﾞﾙｰﾌﾟ,5:BLｺｰﾄﾞ・得意先掛率ｸﾞﾙｰﾌﾟ,6:ﾒｰｶｰｺｰﾄﾞ・BLｺｰﾄﾞ,7:ﾒｰｶｰｺｰﾄﾞ,8:BLｺｰﾄﾞ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   標準価格選択設定パターンプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PriceSelectPtn
        {
            get { return _priceSelectPtn; }
            set { _priceSelectPtn = value; }
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

        /// public propaty name  :  CustRateGrpCode
        /// <summary>得意先掛率グループコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先掛率グループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustRateGrpCode
        {
            get { return _custRateGrpCode; }
            set { _custRateGrpCode = value; }
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

        /// public propaty name  :  PriceSelectDiv
        /// <summary>標準価格選択区分プロパティ</summary>
        /// <value>0:優良,1:純正,2:高い方(1:N),,3:高い方(1:1)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   標準価格選択区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PriceSelectDiv
        {
            get { return _priceSelectDiv; }
            set { _priceSelectDiv = value; }
        }

        /// public propaty name  :  CustomerSnm
        /// <summary>得意先略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustomerSnm
        {
            get { return _customerSnm; }
            set { _customerSnm = value; }
        }

        /// public propaty name  :  BLGoodsFullName
        /// <summary>BL商品コード名称（全角）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コード名称（全角）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BLGoodsFullName
        {
            get { return _bLGoodsFullName; }
            set { _bLGoodsFullName = value; }
        }

        /// public propaty name  :  MakerName
        /// <summary>メーカー名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカー名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MakerName
        {
            get { return _makerName; }
            set { _makerName = value; }
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

        /// public propaty name  :  UpdEmployeeName
        /// <summary>更新従業員名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新従業員名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdEmployeeName
        {
            get { return _updEmployeeName; }
            set { _updEmployeeName = value; }
        }


        /// <summary>
        /// 標準価格選択設定マスタコンストラクタ
        /// </summary>
        /// <returns>PriceSelectSetクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PriceSelectSetクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PriceSelectSet()
        {
        }

        /// <summary>
        /// 標準価格選択設定マスタコンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
        /// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
        /// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="priceSelectPtn">標準価格選択設定パターン(0:ﾒｰｶｰｺｰﾄﾞ・BLｺｰﾄﾞ・得意先ｺｰﾄﾞ,1:ﾒｰｶｰｺｰﾄﾞ・得意先ｺｰﾄﾞ,2:BLｺｰﾄﾞ・得意先ｺｰﾄﾞ,3:ﾒｰｶｰｺｰﾄﾞ・BLｺｰﾄﾞ・得意先掛率ｸﾞﾙｰﾌﾟ,4:ﾒｰｶｰｺｰﾄﾞ・得意先掛率ｸﾞﾙｰﾌﾟ,5:BLｺｰﾄﾞ・得意先掛率ｸﾞﾙｰﾌﾟ,6:ﾒｰｶｰｺｰﾄﾞ・BLｺｰﾄﾞ,7:ﾒｰｶｰｺｰﾄﾞ,8:BLｺｰﾄﾞ)</param>
        /// <param name="goodsMakerCd">商品メーカーコード</param>
        /// <param name="bLGoodsCode">BL商品コード</param>
        /// <param name="custRateGrpCode">得意先掛率グループコード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="priceSelectDiv">標準価格選択区分(0:優良,1:純正,2:高い方(1:N),,3:高い方(1:1))</param>
        /// <param name="customerSnm">得意先略称</param>
        /// <param name="bLGoodsFullName">BL商品コード名称（全角）</param>
        /// <param name="makerName">メーカー名称</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="updEmployeeName">更新従業員名称</param>
        /// <returns>PriceSelectSetクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PriceSelectSetクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PriceSelectSet(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 priceSelectPtn, Int32 goodsMakerCd, Int32 bLGoodsCode, Int32 custRateGrpCode, Int32 customerCode, Int32 priceSelectDiv, string customerSnm, string bLGoodsFullName, string makerName, string enterpriseName, string updEmployeeName)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._priceSelectPtn = priceSelectPtn;
            this._goodsMakerCd = goodsMakerCd;
            this._bLGoodsCode = bLGoodsCode;
            this._custRateGrpCode = custRateGrpCode;
            this._customerCode = customerCode;
            this._priceSelectDiv = priceSelectDiv;
            this._customerSnm = customerSnm;
            this._bLGoodsFullName = bLGoodsFullName;
            this._makerName = makerName;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;

        }

        /// <summary>
        /// 標準価格選択設定マスタ複製処理
        /// </summary>
        /// <returns>PriceSelectSetクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいPriceSelectSetクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PriceSelectSet Clone()
        {
            return new PriceSelectSet(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._priceSelectPtn, this._goodsMakerCd, this._bLGoodsCode, this._custRateGrpCode, this._customerCode, this._priceSelectDiv, this._customerSnm, this._bLGoodsFullName, this._makerName, this._enterpriseName, this._updEmployeeName);
        }

        /// <summary>
        /// 標準価格選択設定マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のPriceSelectSetクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PriceSelectSetクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(PriceSelectSet target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.PriceSelectPtn == target.PriceSelectPtn)
                 && (this.GoodsMakerCd == target.GoodsMakerCd)
                 && (this.BLGoodsCode == target.BLGoodsCode)
                 && (this.CustRateGrpCode == target.CustRateGrpCode)
                 && (this.CustomerCode == target.CustomerCode)
                 && (this.PriceSelectDiv == target.PriceSelectDiv)
                 && (this.CustomerSnm == target.CustomerSnm)
                 && (this.BLGoodsFullName == target.BLGoodsFullName)
                 && (this.MakerName == target.MakerName)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName));
        }

        /// <summary>
        /// 標準価格選択設定マスタ比較処理
        /// </summary>
        /// <param name="priceSelectSet1">
        ///                    比較するPriceSelectSetクラスのインスタンス
        /// </param>
        /// <param name="priceSelectSet2">比較するPriceSelectSetクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PriceSelectSetクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(PriceSelectSet priceSelectSet1, PriceSelectSet priceSelectSet2)
        {
            return ((priceSelectSet1.CreateDateTime == priceSelectSet2.CreateDateTime)
                 && (priceSelectSet1.UpdateDateTime == priceSelectSet2.UpdateDateTime)
                 && (priceSelectSet1.EnterpriseCode == priceSelectSet2.EnterpriseCode)
                 && (priceSelectSet1.FileHeaderGuid == priceSelectSet2.FileHeaderGuid)
                 && (priceSelectSet1.UpdEmployeeCode == priceSelectSet2.UpdEmployeeCode)
                 && (priceSelectSet1.UpdAssemblyId1 == priceSelectSet2.UpdAssemblyId1)
                 && (priceSelectSet1.UpdAssemblyId2 == priceSelectSet2.UpdAssemblyId2)
                 && (priceSelectSet1.LogicalDeleteCode == priceSelectSet2.LogicalDeleteCode)
                 && (priceSelectSet1.PriceSelectPtn == priceSelectSet2.PriceSelectPtn)
                 && (priceSelectSet1.GoodsMakerCd == priceSelectSet2.GoodsMakerCd)
                 && (priceSelectSet1.BLGoodsCode == priceSelectSet2.BLGoodsCode)
                 && (priceSelectSet1.CustRateGrpCode == priceSelectSet2.CustRateGrpCode)
                 && (priceSelectSet1.CustomerCode == priceSelectSet2.CustomerCode)
                 && (priceSelectSet1.PriceSelectDiv == priceSelectSet2.PriceSelectDiv)
                 && (priceSelectSet1.CustomerSnm == priceSelectSet2.CustomerSnm)
                 && (priceSelectSet1.BLGoodsFullName == priceSelectSet2.BLGoodsFullName)
                 && (priceSelectSet1.MakerName == priceSelectSet2.MakerName)
                 && (priceSelectSet1.EnterpriseName == priceSelectSet2.EnterpriseName)
                 && (priceSelectSet1.UpdEmployeeName == priceSelectSet2.UpdEmployeeName));
        }
        /// <summary>
        /// 標準価格選択設定マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のPriceSelectSetクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PriceSelectSetクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(PriceSelectSet target)
        {
            ArrayList resList = new ArrayList();
            if (this.CreateDateTime != target.CreateDateTime) resList.Add("CreateDateTime");
            if (this.UpdateDateTime != target.UpdateDateTime) resList.Add("UpdateDateTime");
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.FileHeaderGuid != target.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (this.UpdEmployeeCode != target.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (this.UpdAssemblyId1 != target.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (this.UpdAssemblyId2 != target.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (this.PriceSelectPtn != target.PriceSelectPtn) resList.Add("PriceSelectPtn");
            if (this.GoodsMakerCd != target.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (this.BLGoodsCode != target.BLGoodsCode) resList.Add("BLGoodsCode");
            if (this.CustRateGrpCode != target.CustRateGrpCode) resList.Add("CustRateGrpCode");
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.PriceSelectDiv != target.PriceSelectDiv) resList.Add("PriceSelectDiv");
            if (this.CustomerSnm != target.CustomerSnm) resList.Add("CustomerSnm");
            if (this.BLGoodsFullName != target.BLGoodsFullName) resList.Add("BLGoodsFullName");
            if (this.MakerName != target.MakerName) resList.Add("MakerName");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }

        /// <summary>
        /// 標準価格選択設定マスタ比較処理
        /// </summary>
        /// <param name="priceSelectSet1">比較するPriceSelectSetクラスのインスタンス</param>
        /// <param name="priceSelectSet2">比較するPriceSelectSetクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PriceSelectSetクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(PriceSelectSet priceSelectSet1, PriceSelectSet priceSelectSet2)
        {
            ArrayList resList = new ArrayList();
            if (priceSelectSet1.CreateDateTime != priceSelectSet2.CreateDateTime) resList.Add("CreateDateTime");
            if (priceSelectSet1.UpdateDateTime != priceSelectSet2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (priceSelectSet1.EnterpriseCode != priceSelectSet2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (priceSelectSet1.FileHeaderGuid != priceSelectSet2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (priceSelectSet1.UpdEmployeeCode != priceSelectSet2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (priceSelectSet1.UpdAssemblyId1 != priceSelectSet2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (priceSelectSet1.UpdAssemblyId2 != priceSelectSet2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (priceSelectSet1.LogicalDeleteCode != priceSelectSet2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (priceSelectSet1.PriceSelectPtn != priceSelectSet2.PriceSelectPtn) resList.Add("PriceSelectPtn");
            if (priceSelectSet1.GoodsMakerCd != priceSelectSet2.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (priceSelectSet1.BLGoodsCode != priceSelectSet2.BLGoodsCode) resList.Add("BLGoodsCode");
            if (priceSelectSet1.CustRateGrpCode != priceSelectSet2.CustRateGrpCode) resList.Add("CustRateGrpCode");
            if (priceSelectSet1.CustomerCode != priceSelectSet2.CustomerCode) resList.Add("CustomerCode");
            if (priceSelectSet1.PriceSelectDiv != priceSelectSet2.PriceSelectDiv) resList.Add("PriceSelectDiv");
            if (priceSelectSet1.CustomerSnm != priceSelectSet2.CustomerSnm) resList.Add("CustomerSnm");
            if (priceSelectSet1.BLGoodsFullName != priceSelectSet2.BLGoodsFullName) resList.Add("BLGoodsFullName");
            if (priceSelectSet1.MakerName != priceSelectSet2.MakerName) resList.Add("MakerName");
            if (priceSelectSet1.EnterpriseName != priceSelectSet2.EnterpriseName) resList.Add("EnterpriseName");
            if (priceSelectSet1.UpdEmployeeName != priceSelectSet2.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }
    }
}

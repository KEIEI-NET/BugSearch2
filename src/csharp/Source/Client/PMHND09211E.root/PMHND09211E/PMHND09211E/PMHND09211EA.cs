//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 商品バーコード関連付けマスタ
// プログラム概要   : 商品バーコード関連付けテーブルに対して各操作処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370006-00 作成担当 : 3H 張小磊
// 作 成 日  2017/06/12  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   GoodsBarCodeRevn
    /// <summary>
    ///                      商品バーコード関連付けマスタ
    /// </summary>
    /// <remarks>
    /// <br>note             :   商品バーコード関連付けマスタヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2017/06/12  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class GoodsBarCodeRevn
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

        /// <summary>商品メーカーコード</summary>
        private Int32 _goodsMakerCd;

        /// <summary>商品番号</summary>
        private string _goodsNo = "";

        /// <summary>商品バーコード</summary>
        private string _goodsBarCode;

        /// <summary>商品バーコード種別</summary>
        private Int32 _goodsBarCodeKind;

        /// <summary>チェックデジット区分</summary>
        private Int32 _checkdigitCode;

        /// <summary>提供日付</summary>
        private Int32 _offerDate;

        /// <summary>提供データ区分</summary>
        private Int32 _offerDataDiv;

        /// <summary>メーカー名称</summary>
        private string _makerName = "";

        /// <summary>商品名称</summary>
        private string _goodsName = "";

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

        /// public propaty name  :  GoodsNo
        /// <summary>商品番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNo
        {
            get { return _goodsNo; }
            set { _goodsNo = value; }
        }

        /// public propaty name  :  GoodsBarCode
        /// <summary>商品バーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品バーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsBarCode
        {
            get { return _goodsBarCode; }
            set { _goodsBarCode = value; }
        }

        /// public propaty name  :  GoodsBarCodeKind
        /// <summary>商品バーコード種別プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品バーコード種別プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsBarCodeKind
        {
            get { return _goodsBarCodeKind; }
            set { _goodsBarCodeKind = value; }
        }

        /// public propaty name  :  CheckdigitCode
        /// <summary>チェックデジット区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   チェックデジット区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CheckdigitCode
        {
            get { return _checkdigitCode; }
            set { _checkdigitCode = value; }
        }

        /// public propaty name  :  OfferDate
        /// <summary>提供日付プロパティ</summary>
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

        /// public propaty name  :  OfferDataDiv
        /// <summary>提供データ区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   提供データ区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OfferDataDiv
        {
            get { return _offerDataDiv; }
            set { _offerDataDiv = value; }
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

        /// public propaty name  :  GoodsName
        /// <summary>商品名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsName
        {
            get { return _goodsName; }
            set { _goodsName = value; }
        }

        /// <summary>
        /// 商品バーコード関連付けマスタコンストラクタ
        /// </summary>
        /// <returns>GoodsBarCodeRevnクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsBarCodeRevnクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public GoodsBarCodeRevn()
        {
        }

        /// <summary>
        /// 商品バーコード関連付けマスタコンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
        /// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
        /// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="goodsMakerCd">商品メーカーコード</param>
        /// <param name="goodsNo">商品番号</param>
        /// <param name="goodsBarCode">商品バーコード</param>
        /// <param name="goodsBarCodeKind">商品バーコード種別</param>
        /// <param name="checkdigitCode">チェックデジット区分</param>
        /// <param name="offerDate">提供日付</param>
        /// <param name="offerDataDiv">提供データ区分</param>
        /// <param name="makerName">メーカー名称</param>
        /// <param name="goodsName">商品名称</param>
        /// <returns>GoodsBarCodeRevnクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsBarCodeRevnクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public GoodsBarCodeRevn(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 goodsMakerCd, string goodsNo, string goodsBarCode, Int32 goodsBarCodeKind, Int32 checkdigitCode, Int32 offerDate, Int32 offerDataDiv, string makerName, string goodsName)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._goodsMakerCd = goodsMakerCd;
            this._goodsNo = goodsNo;
            this._goodsBarCode = goodsBarCode;
            this._goodsBarCodeKind = goodsBarCodeKind;
            this._checkdigitCode = checkdigitCode;
            this._offerDate = offerDate;
            this._offerDataDiv = offerDataDiv;
            this._makerName = makerName;
            this._goodsName = goodsName;
        }

        /// <summary>
        /// 商品バーコード関連付けマスタ複製処理
        /// </summary>
        /// <returns>GoodsBarCodeRevnクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいGoodsBarCodeRevnクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public GoodsBarCodeRevn Clone()
        {
            return new GoodsBarCodeRevn(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._goodsMakerCd, this._goodsNo, this._goodsBarCode, this._goodsBarCodeKind, this._checkdigitCode, this._offerDate, this._offerDataDiv, this._makerName, this._goodsName);
        }

        /// <summary>
        /// 商品バーコード関連付けマスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のGoodsBarCodeRevnクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsBarCodeRevnクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(GoodsBarCodeRevn target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.GoodsMakerCd == target.GoodsMakerCd)
                 && (this.GoodsNo == target.GoodsNo)
                 && (this.GoodsBarCode == target.GoodsBarCode)
                 && (this.GoodsBarCodeKind == target.GoodsBarCodeKind)
                 && (this.CheckdigitCode == target.CheckdigitCode)
                 && (this.OfferDate == target.OfferDate)
                 && (this.OfferDataDiv == target.OfferDataDiv)
                 && (this.MakerName == target.MakerName)
                 && (this.GoodsName == target.GoodsName));
        }

        /// <summary>
        /// 商品バーコード関連付けマスタ比較処理
        /// </summary>
        /// <param name="goodsBarCodeRevn1">
        ///                    比較するGoodsBarCodeRevnクラスのインスタンス
        /// </param>
        /// <param name="goodsBarCodeRevn2">比較するGoodsBarCodeRevnクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsBarCodeRevnクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(GoodsBarCodeRevn goodsBarCodeRevn1, GoodsBarCodeRevn goodsBarCodeRevn2)
        {
            return ((goodsBarCodeRevn1.CreateDateTime == goodsBarCodeRevn2.CreateDateTime)
                 && (goodsBarCodeRevn1.UpdateDateTime == goodsBarCodeRevn2.UpdateDateTime)
                 && (goodsBarCodeRevn1.EnterpriseCode == goodsBarCodeRevn2.EnterpriseCode)
                 && (goodsBarCodeRevn1.FileHeaderGuid == goodsBarCodeRevn2.FileHeaderGuid)
                 && (goodsBarCodeRevn1.UpdEmployeeCode == goodsBarCodeRevn2.UpdEmployeeCode)
                 && (goodsBarCodeRevn1.UpdAssemblyId1 == goodsBarCodeRevn2.UpdAssemblyId1)
                 && (goodsBarCodeRevn1.UpdAssemblyId2 == goodsBarCodeRevn2.UpdAssemblyId2)
                 && (goodsBarCodeRevn1.LogicalDeleteCode == goodsBarCodeRevn2.LogicalDeleteCode)
                 && (goodsBarCodeRevn1.GoodsMakerCd == goodsBarCodeRevn2.GoodsMakerCd)
                 && (goodsBarCodeRevn1.GoodsNo == goodsBarCodeRevn2.GoodsNo)
                 && (goodsBarCodeRevn1.GoodsBarCode == goodsBarCodeRevn2.GoodsBarCode)
                 && (goodsBarCodeRevn1.GoodsBarCodeKind == goodsBarCodeRevn2.GoodsBarCodeKind)
                 && (goodsBarCodeRevn1.CheckdigitCode == goodsBarCodeRevn2.CheckdigitCode)
                 && (goodsBarCodeRevn1.OfferDate == goodsBarCodeRevn2.OfferDate)
                 && (goodsBarCodeRevn1.OfferDataDiv == goodsBarCodeRevn2.OfferDataDiv)
                 && (goodsBarCodeRevn1.MakerName == goodsBarCodeRevn2.MakerName)
                 && (goodsBarCodeRevn1.GoodsName == goodsBarCodeRevn2.GoodsName));
        }
        /// <summary>
        /// 商品バーコード関連付けマスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のGoodsBarCodeクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsBarCodeクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(GoodsBarCodeRevn target)
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
            if (this.GoodsMakerCd != target.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (this.GoodsNo != target.GoodsNo) resList.Add("GoodsNo");
            if (this.GoodsBarCode != target.GoodsBarCode) resList.Add("GoodsBarCode");
            if (this.GoodsBarCodeKind != target.GoodsBarCodeKind) resList.Add("GoodsBarCodeKind");
            if (this.CheckdigitCode != target.CheckdigitCode) resList.Add("CheckdigitCode");
            if (this.OfferDate != target.OfferDate) resList.Add("OfferDate");
            if (this.OfferDataDiv != target.OfferDataDiv) resList.Add("OfferDataDiv");
            if (this.MakerName != target.MakerName) resList.Add("MakerName");
            if (this.GoodsName != target.GoodsName) resList.Add("GoodsName");
            return resList;
        }

        /// <summary>
        /// 商品バーコード関連付けマスタ比較処理
        /// </summary>
        /// <param name="goodsBarCodeRevn1">比較するGoodsBarCodeクラスのインスタンス</param>
        /// <param name="goodsBarCodeRevn2">比較するGoodsBarCodeクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsBarCodeクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(GoodsBarCodeRevn goodsBarCodeRevn1, GoodsBarCodeRevn goodsBarCodeRevn2)
        {
            ArrayList resList = new ArrayList();
            if (goodsBarCodeRevn1.CreateDateTime != goodsBarCodeRevn2.CreateDateTime) resList.Add("CreateDateTime");
            if (goodsBarCodeRevn1.UpdateDateTime != goodsBarCodeRevn2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (goodsBarCodeRevn1.EnterpriseCode != goodsBarCodeRevn2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (goodsBarCodeRevn1.FileHeaderGuid != goodsBarCodeRevn2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (goodsBarCodeRevn1.UpdEmployeeCode != goodsBarCodeRevn2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (goodsBarCodeRevn1.UpdAssemblyId1 != goodsBarCodeRevn2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (goodsBarCodeRevn1.UpdAssemblyId2 != goodsBarCodeRevn2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (goodsBarCodeRevn1.LogicalDeleteCode != goodsBarCodeRevn2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (goodsBarCodeRevn1.GoodsMakerCd != goodsBarCodeRevn2.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (goodsBarCodeRevn1.GoodsNo != goodsBarCodeRevn2.GoodsNo) resList.Add("GoodsNo");
            if (goodsBarCodeRevn1.GoodsBarCode != goodsBarCodeRevn2.GoodsBarCode) resList.Add("GoodsBarCode");
            if (goodsBarCodeRevn1.GoodsBarCodeKind != goodsBarCodeRevn2.GoodsBarCodeKind) resList.Add("GoodsBarCodeKind");
            if (goodsBarCodeRevn1.CheckdigitCode != goodsBarCodeRevn2.CheckdigitCode) resList.Add("CheckdigitCode");
            if (goodsBarCodeRevn1.OfferDate != goodsBarCodeRevn2.OfferDate) resList.Add("OfferDate");
            if (goodsBarCodeRevn1.OfferDataDiv != goodsBarCodeRevn2.OfferDataDiv) resList.Add("OfferDataDiv");
            if (goodsBarCodeRevn1.MakerName != goodsBarCodeRevn2.MakerName) resList.Add("MakerName");
            if (goodsBarCodeRevn1.GoodsName != goodsBarCodeRevn2.GoodsName) resList.Add("GoodsName");
            return resList;
        }
    }
}

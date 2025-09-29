using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   GoodsUpdate
    /// <summary>
    ///                      商品マスタ更新条件
    /// </summary>
    /// <remarks>
    /// <br>note             :   商品マスタ更新条件ヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2011/07/22</br>
    /// <br>Genarated Date   :   2011/07/22  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   許雁波</br>
    /// <br>                 :   連番1029  新規</br>
    /// <br>Update Note      :   価格更新区分追加の対応</br>
    /// <br>Programmer       :   yangmj</br>
    /// <br>Date             :   2012/06/12</br>
    /// </remarks>
    public class GoodsUpdate
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

        /// <summary>名称更新区分</summary>
        /// <remarks>0:更新する,1:更新しない</remarks>
        private Int32 _goodsNameUpdateDivCd;

        /// <summary>層別更新区分</summary>
        /// <remarks>0:更新する,1:更新しない</remarks>
        private Int32 _rateRankUpdateDivCd;

        /// <summary>BL商品コード更新区分</summary>
        /// <remarks>0:更新する,1:更新しない</remarks>
        private Int32 _bLCodeUpdateDivCd;

        // --- ADD yangmj 2012/06/12 価格更新区分追加----------------- >>>>>
        /// <summary>価格更新区分</summary>
        /// <remarks>0:更新する,1:更新しない</remarks>
        private Int32 _priceUpdateDivCd;
        // --- ADD yangmj 2012/06/12 価格更新区分追加----------------- <<<<<

        /// <summary>商品メーカーコード</summary>
        private Int32 _goodsMakerCd;

        /// <summary>商品中分類コード</summary>
        /// <remarks>※中分類</remarks>
        private Int32 _goodsMGroup;

        /// <summary>BL商品コード</summary>
        private Int32 _bLGoodsCode;

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

        /// public propaty name  :  GoodsNameUpdateDivCd
        /// <summary>名称更新区分プロパティ</summary>
        /// <value>0:更新する,1:更新しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   名称更新区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsNameUpdateDivCd
        {
            get { return _goodsNameUpdateDivCd; }
            set { _goodsNameUpdateDivCd = value; }
        }

        /// public propaty name  :  RateRankUpdateDivCd
        /// <summary>層別更新区分プロパティ</summary>
        /// <value>0:更新する,1:更新しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   層別更新区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 RateRankUpdateDivCd
        {
            get { return _rateRankUpdateDivCd; }
            set { _rateRankUpdateDivCd = value; }
        }

        /// public propaty name  :  BLCodeUpdateDivCd
        /// <summary>BL商品コード更新区分プロパティ</summary>
        /// <value>0:更新する,1:更新しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コード更新区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLCodeUpdateDivCd
        {
            get { return _bLCodeUpdateDivCd; }
            set { _bLCodeUpdateDivCd = value; }
        }

        // --- ADD yangmj 2012/06/12 価格更新区分追加----------------- >>>>>
        /// public propaty name  :  PriceUpdateDivCd
        /// <summary>価格更新区分プロパティ</summary>
        /// <value>0:更新する,1:更新しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   価格更新区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PriceUpdateDivCd
        {
            get { return _priceUpdateDivCd; }
            set { _priceUpdateDivCd = value; }
        }
        // --- ADD yangmj 2012/06/12 価格更新区分追加----------------- <<<<<

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

        /// public propaty name  :  GoodsMGroup
        /// <summary>商品中分類コードプロパティ</summary>
        /// <value>※中分類</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品中分類コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMGroup
        {
            get { return _goodsMGroup; }
            set { _goodsMGroup = value; }
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
        /// 商品マスタ更新条件コンストラクタ
        /// </summary>
        /// <returns>GoodsUpdateクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsUpdateクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public GoodsUpdate()
        {
        }

        /// <summary>
        /// 商品マスタ更新条件コンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
        /// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
        /// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="goodsNameUpdateDivCd">名称更新区分(0:更新する,1:更新しない)</param>
        /// <param name="rateRankUpdateDivCd">層別更新区分(0:更新する,1:更新しない)</param>
        /// <param name="bLCodeUpdateDivCd">BL商品コード更新区分(0:更新する,1:更新しない)</param>
        /// <param name="priceUpdateDivCd">価格更新区分(0:更新する,1:更新しない)</param>
        /// <param name="goodsMakerCd">商品メーカーコード</param>
        /// <param name="goodsMGroup">商品中分類コード(※中分類)</param>
        /// <param name="bLGoodsCode">BL商品コード</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="updEmployeeName">更新従業員名称</param>
        /// <returns>GoodsUpdateクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsUpdateクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        //public GoodsUpdate(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 goodsNameUpdateDivCd, Int32 rateRankUpdateDivCd, Int32 bLCodeUpdateDivCd, Int32 goodsMakerCd, Int32 goodsMGroup, Int32 bLGoodsCode, string enterpriseName, string updEmployeeName)//DEL yangmj 2012/06/12 価格更新区分追加
        public GoodsUpdate(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 goodsNameUpdateDivCd, Int32 rateRankUpdateDivCd, Int32 bLCodeUpdateDivCd, Int32 priceUpdateDivCd, Int32 goodsMakerCd, Int32 goodsMGroup, Int32 bLGoodsCode, string enterpriseName, string updEmployeeName) //ADD yangmj 2012/06/12 価格更新区分追加
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._goodsNameUpdateDivCd = goodsNameUpdateDivCd;
            this._rateRankUpdateDivCd = rateRankUpdateDivCd;
            this._bLCodeUpdateDivCd = bLCodeUpdateDivCd;
            this._priceUpdateDivCd = priceUpdateDivCd;//ADD yangmj 2012/06/12 価格更新区分追加
            this._goodsMakerCd = goodsMakerCd;
            this._goodsMGroup = goodsMGroup;
            this._bLGoodsCode = bLGoodsCode;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;

        }

        /// <summary>
        /// 商品マスタ更新条件複製処理
        /// </summary>
        /// <returns>GoodsUpdateクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいGoodsUpdateクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public GoodsUpdate Clone()
        {
            //return new GoodsUpdate(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._goodsNameUpdateDivCd, this._rateRankUpdateDivCd, this._bLCodeUpdateDivCd, this._goodsMakerCd, this._goodsMGroup, this._bLGoodsCode, this._enterpriseName, this._updEmployeeName);// DEL yangmj 2012/06/12 価格更新区分追加
            return new GoodsUpdate(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._goodsNameUpdateDivCd, this._rateRankUpdateDivCd, this._bLCodeUpdateDivCd, this._priceUpdateDivCd, this._goodsMakerCd, this._goodsMGroup, this._bLGoodsCode, this._enterpriseName, this._updEmployeeName);// ADD yangmj 2012/06/12 価格更新区分追加
        }

        /// <summary>
        /// 商品マスタ更新条件比較処理
        /// </summary>
        /// <param name="target">比較対象のGoodsUpdateクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsUpdateクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(GoodsUpdate target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.GoodsNameUpdateDivCd == target.GoodsNameUpdateDivCd)
                 && (this.RateRankUpdateDivCd == target.RateRankUpdateDivCd)
                 && (this.BLCodeUpdateDivCd == target.BLCodeUpdateDivCd)
                 && (this.PriceUpdateDivCd == target.PriceUpdateDivCd) // ADD yangmj 2012/06/12 価格更新区分追加
                 && (this.GoodsMakerCd == target.GoodsMakerCd)
                 && (this.GoodsMGroup == target.GoodsMGroup)
                 && (this.BLGoodsCode == target.BLGoodsCode)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName));
        }

        /// <summary>
        /// 商品マスタ更新条件比較処理
        /// </summary>
        /// <param name="goodsUpdate1">
        ///                    比較するGoodsUpdateクラスのインスタンス
        /// </param>
        /// <param name="goodsUpdate2">比較するGoodsUpdateクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsUpdateクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(GoodsUpdate goodsUpdate1, GoodsUpdate goodsUpdate2)
        {
            return ((goodsUpdate1.CreateDateTime == goodsUpdate2.CreateDateTime)
                 && (goodsUpdate1.UpdateDateTime == goodsUpdate2.UpdateDateTime)
                 && (goodsUpdate1.EnterpriseCode == goodsUpdate2.EnterpriseCode)
                 && (goodsUpdate1.FileHeaderGuid == goodsUpdate2.FileHeaderGuid)
                 && (goodsUpdate1.UpdEmployeeCode == goodsUpdate2.UpdEmployeeCode)
                 && (goodsUpdate1.UpdAssemblyId1 == goodsUpdate2.UpdAssemblyId1)
                 && (goodsUpdate1.UpdAssemblyId2 == goodsUpdate2.UpdAssemblyId2)
                 && (goodsUpdate1.LogicalDeleteCode == goodsUpdate2.LogicalDeleteCode)
                 && (goodsUpdate1.GoodsNameUpdateDivCd == goodsUpdate2.GoodsNameUpdateDivCd)
                 && (goodsUpdate1.RateRankUpdateDivCd == goodsUpdate2.RateRankUpdateDivCd)
                 && (goodsUpdate1.BLCodeUpdateDivCd == goodsUpdate2.BLCodeUpdateDivCd)
                 && (goodsUpdate1.PriceUpdateDivCd == goodsUpdate2.PriceUpdateDivCd) // ADD yangmj 2012/06/12 価格更新区分追加
                 && (goodsUpdate1.GoodsMakerCd == goodsUpdate2.GoodsMakerCd)
                 && (goodsUpdate1.GoodsMGroup == goodsUpdate2.GoodsMGroup)
                 && (goodsUpdate1.BLGoodsCode == goodsUpdate2.BLGoodsCode)
                 && (goodsUpdate1.EnterpriseName == goodsUpdate2.EnterpriseName)
                 && (goodsUpdate1.UpdEmployeeName == goodsUpdate2.UpdEmployeeName));
        }
        /// <summary>
        /// 商品マスタ更新条件比較処理
        /// </summary>
        /// <param name="target">比較対象のGoodsUpdateクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsUpdateクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(GoodsUpdate target)
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
            if (this.GoodsNameUpdateDivCd != target.GoodsNameUpdateDivCd) resList.Add("GoodsNameUpdateDivCd");
            if (this.RateRankUpdateDivCd != target.RateRankUpdateDivCd) resList.Add("RateRankUpdateDivCd");
            if (this.BLCodeUpdateDivCd != target.BLCodeUpdateDivCd) resList.Add("BLCodeUpdateDivCd");
            if (this.PriceUpdateDivCd != target.BLCodeUpdateDivCd) resList.Add("PriceUpdateDivCd"); // ADD yangmj 2012/06/12 価格更新区分追加
            if (this.GoodsMakerCd != target.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (this.GoodsMGroup != target.GoodsMGroup) resList.Add("GoodsMGroup");
            if (this.BLGoodsCode != target.BLGoodsCode) resList.Add("BLGoodsCode");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }

        /// <summary>
        /// 商品マスタ更新条件比較処理
        /// </summary>
        /// <param name="goodsUpdate1">比較するGoodsUpdateクラスのインスタンス</param>
        /// <param name="goodsUpdate2">比較するGoodsUpdateクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsUpdateクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(GoodsUpdate goodsUpdate1, GoodsUpdate goodsUpdate2)
        {
            ArrayList resList = new ArrayList();
            if (goodsUpdate1.CreateDateTime != goodsUpdate2.CreateDateTime) resList.Add("CreateDateTime");
            if (goodsUpdate1.UpdateDateTime != goodsUpdate2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (goodsUpdate1.EnterpriseCode != goodsUpdate2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (goodsUpdate1.FileHeaderGuid != goodsUpdate2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (goodsUpdate1.UpdEmployeeCode != goodsUpdate2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (goodsUpdate1.UpdAssemblyId1 != goodsUpdate2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (goodsUpdate1.UpdAssemblyId2 != goodsUpdate2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (goodsUpdate1.LogicalDeleteCode != goodsUpdate2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (goodsUpdate1.GoodsNameUpdateDivCd != goodsUpdate2.GoodsNameUpdateDivCd) resList.Add("GoodsNameUpdateDivCd");
            if (goodsUpdate1.RateRankUpdateDivCd != goodsUpdate2.RateRankUpdateDivCd) resList.Add("RateRankUpdateDivCd");
            if (goodsUpdate1.BLCodeUpdateDivCd != goodsUpdate2.BLCodeUpdateDivCd) resList.Add("BLCodeUpdateDivCd");
            if (goodsUpdate1.PriceUpdateDivCd != goodsUpdate2.BLCodeUpdateDivCd) resList.Add("PriceUpdateDivCd");// ADD yangmj 2012/06/12 価格更新区分追加
            if (goodsUpdate1.GoodsMakerCd != goodsUpdate2.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (goodsUpdate1.GoodsMGroup != goodsUpdate2.GoodsMGroup) resList.Add("GoodsMGroup");
            if (goodsUpdate1.BLGoodsCode != goodsUpdate2.BLGoodsCode) resList.Add("BLGoodsCode");
            if (goodsUpdate1.EnterpriseName != goodsUpdate2.EnterpriseName) resList.Add("EnterpriseName");
            if (goodsUpdate1.UpdEmployeeName != goodsUpdate2.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }
    }
}

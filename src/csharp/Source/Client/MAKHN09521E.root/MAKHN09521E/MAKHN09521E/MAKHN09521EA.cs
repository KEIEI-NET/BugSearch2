using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   GoodsMng
    /// <summary>
    ///                      商品管理情報ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   商品管理情報ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2007/08/22  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class GoodsMng
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

        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>拠点ガイド名称</summary>
        private string _sectionGuideNm = "";

        /// <summary>商品メーカーコード</summary>
        /// <remarks>桁数変更</remarks>
        private Int32 _goodsMakerCd;

        /// <summary>商品メーカー名称コード</summary>
        /// <remarks>桁数変更</remarks>
        private string _goodsMakerName = "";

        /// <summary>商品番号</summary>
        /// <remarks>桁数変更</remarks>
        private string _goodsNo = "";

        /// <summary>商品名称</summary>
        /// <remarks>桁数変更</remarks>
        private string _goodsName = "";

        /// <summary>BLコード</summary>
        private Int32 _blGoodsCode;

        /// <summary>BLコード名称</summary>
        private string _blGoodsName = "";

        /// <summary>仕入先コード</summary>
        private Int32 _supplierCd1;

        /// <summary>仕入先名称</summary>
        private string _SupplierSnm = "";

        /// <summary>発注ロット</summary>
        private Int32 _supplierLot1;

        /// <summary>商品中分類</summary>
        private Int32 _goodsMGroup;

        /// <summary>商品中分類名称</summary>
        private string _goodsMGroupNm = "";

        /// public propaty name  :  CreateDateTime
        /// <summary>作成日時プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// 
        /// <br>note             :   作成日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime CreateDateTime
        {
            get { return _createDateTime; }
            set { _createDateTime = value; }
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

        /// public propaty name  :  SectionGuideNm
        /// <summary>拠点ガイド名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点ガイド名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionGuideNm
        {
            get { return _sectionGuideNm; }
            set { _sectionGuideNm = value; }
        }

        /// public propaty name  :  GoodsMakerCd
        /// <summary>商品メーカーコードプロパティ</summary>
        /// <value>桁数変更</value>
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
        /// <value>桁数変更</value>
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

        /// public propaty name  :  GoodsNo
        /// <summary>商品番号プロパティ</summary>
        /// <value>桁数変更</value>
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

        /// public propaty name  :  GoodsName
        /// <summary>商品名称プロパティ</summary>
        /// <value>桁数変更</value>
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



        /// public propaty name  :  BLGoodsCode
        /// <summary>BLコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGoodsCode
        {
            get { return _blGoodsCode; }
            set { _blGoodsCode = value; }
        }

        /// public propaty name  :  BLGoodsName
        /// <summary>BLコード名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BLGoodsName
        {
            get { return _blGoodsName; }
            set { _blGoodsName = value; }
        }

        
        /// public propaty name  :  SupplierCd1
        /// <summary>仕入コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注先コード１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierCd1
        {
            get { return _supplierCd1; }
            set { _supplierCd1 = value; }
        }

        /// public propaty name  :  SupplierSnm
        /// <summary>仕入先名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注先名称１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierSnm
        {
            get { return _SupplierSnm; }
            set { _SupplierSnm = value; }
        }

        /// public propaty name  :  SupplierLot1
        /// <summary>発注ロットプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注ロット１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierLot1
        {
            get { return _supplierLot1; }
            set { _supplierLot1 = value; }
        }

        /// public propaty name  :  GoodsMGroup
        /// <summary>商品中分類プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品中分類プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMGroup
        {
            get { return _goodsMGroup; }
            set { _goodsMGroup = value; }
        }

        /// public propaty name  :  GoodsMGroupNm
        /// <summary>商品中分類名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品中分類名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsMGroupNm
        {
            get { return _goodsMGroupNm; }
            set { _goodsMGroupNm = value; }
        }


        /// <summary>
        /// 商品管理情報ワークコンストラクタ
        /// </summary>
        /// <returns>GoodsMngクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsMngクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public GoodsMng()
        {
        }

        /// <summary>
        /// 商品管理情報ワークコンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
        /// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
        /// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="sectionGuideNm">拠点ガイド名称</param>
        /// <param name="goodsMakerCd">商品メーカーコード(桁数変更)</param>
        /// <param name="goodsmakerName">商品メーカー名称(桁数変更)</param>
        /// <param name="goodsNo">商品番号(桁数変更)</param>
        /// <param name="goodsName">商品名称(桁数変更)</param>
        /// <param name="blGoodsCode">BLコード</param>
        /// <param name="blGoodsName">BLコード名称</param>
        /// <param name="SupplierSnm">仕入先名称</param>
        /// <param name="supplierCd1">仕入先コード</param>
        /// <param name="supplierLot1">発注ロット</param>
        /// <param name="goodsMGroup">商品中分類</param>
        /// <param name="goodsMGroupNm">商品中分類名称</param>
        /// <returns>GoodsMngクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsMngクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public GoodsMng(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, string sectionGuideNm, Int32 goodsMakerCd, string goodsmakerName, string goodsNo, string goodsName, Int32 blGoodsCode, string blGoodsName, Int32 supplierCd1, string SupplierSnm, Int32 supplierLot1, Int32 goodsMGroup, string goodsMGroupNm)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._sectionCode = sectionCode;
            this._sectionGuideNm = sectionGuideNm;
            this._goodsMakerCd = goodsMakerCd;
            this._goodsMakerName = goodsmakerName;
            this._goodsNo = goodsNo;
            this._goodsName = goodsName;
            this._blGoodsCode = blGoodsCode;
            this._blGoodsName = blGoodsName;
            this._supplierCd1 = supplierCd1;
            this._SupplierSnm = SupplierSnm;
            this._supplierLot1 = supplierLot1;
            this._goodsMGroup = goodsMGroup;
            this._goodsMGroupNm = goodsMGroupNm;

        }

        /// <summary>
        /// 商品管理情報ワーク複製処理
        /// </summary>
        /// <returns>GoodsMngクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいGoodsMngクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public GoodsMng Clone()
        {
            return new GoodsMng(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._sectionGuideNm, this._goodsMakerCd, this._goodsMakerName, this._goodsNo, this._goodsName, this._blGoodsCode, this._blGoodsName, this._supplierCd1, this._SupplierSnm, this._supplierLot1, this._goodsMGroup, this._goodsMGroupNm);
        }

        /// <summary>
        /// 商品管理情報ワーク比較処理
        /// </summary>
        /// <param name="target">比較対象のGoodsMngクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsMngクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(GoodsMng target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.SectionCode == target.SectionCode)
                 && (this.SectionGuideNm == target.SectionGuideNm)
                 && (this.GoodsMakerCd == target.GoodsMakerCd)
                 && (this.GoodsMakerName == target.GoodsMakerName)
                 && (this.GoodsNo == target.GoodsNo)
                 && (this.GoodsName == target.GoodsName)
                 && (this.BLGoodsCode == target.BLGoodsCode)
                 && (this.BLGoodsName == target.BLGoodsName)
                 && (this.SupplierCd1 == target.SupplierCd1)
                 && (this.SupplierSnm == target.SupplierSnm)
                 && (this.SupplierLot1 == target.SupplierLot1)
                 && (this._goodsMGroup == target.GoodsMGroup)
                 && (this._goodsMGroupNm == target.GoodsMGroupNm)
);
        }

        /// <summary>
        /// 商品管理情報ワーク比較処理
        /// </summary>
        /// <param name="goodsMng1">
        ///                    比較するGoodsMngクラスのインスタンス
        /// </param>
        /// <param name="goodsMng2">比較するGoodsMngクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :  
        /// GoodsMngクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(GoodsMng goodsMng1, GoodsMng goodsMng2)
        {
            return ((goodsMng1.CreateDateTime == goodsMng2.CreateDateTime)
                 && (goodsMng1.UpdateDateTime == goodsMng2.UpdateDateTime)
                 && (goodsMng1.EnterpriseCode == goodsMng2.EnterpriseCode)
                 && (goodsMng1.FileHeaderGuid == goodsMng2.FileHeaderGuid)
                 && (goodsMng1.UpdEmployeeCode == goodsMng2.UpdEmployeeCode)
                 && (goodsMng1.UpdAssemblyId1 == goodsMng2.UpdAssemblyId1)
                 && (goodsMng1.UpdAssemblyId2 == goodsMng2.UpdAssemblyId2)
                 && (goodsMng1.LogicalDeleteCode == goodsMng2.LogicalDeleteCode)
                 && (goodsMng1.SectionCode == goodsMng2.SectionCode)
                 && (goodsMng1.SectionGuideNm == goodsMng2.SectionGuideNm)
                 && (goodsMng1.GoodsMakerCd == goodsMng2.GoodsMakerCd)
                 && (goodsMng1.GoodsMakerName == goodsMng2.GoodsMakerName)
                 && (goodsMng1.GoodsNo == goodsMng2.GoodsNo)
                 && (goodsMng1.GoodsName == goodsMng2.GoodsName)
                 && (goodsMng1.BLGoodsCode == goodsMng2.BLGoodsCode)
                 && (goodsMng1.BLGoodsName == goodsMng2.BLGoodsName)
                 && (goodsMng1.SupplierCd1 == goodsMng2.SupplierCd1)
                 && (goodsMng1.SupplierSnm == goodsMng2.SupplierSnm)
                 && (goodsMng1.SupplierLot1 == goodsMng2.SupplierLot1)
                 && (goodsMng1.GoodsMGroup == goodsMng2.GoodsMGroup)
                 && (goodsMng1.GoodsMGroupNm == goodsMng2.GoodsMGroupNm)
);
        }
        /// <summary>
        /// 商品管理情報ワーク比較処理
        /// </summary>
        /// <param name="target">比較対象のGoodsMngクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsMngクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(GoodsMng target)
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
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.SectionGuideNm != target.SectionGuideNm) resList.Add("SectionGuideNm");
            if (this.GoodsMakerCd != target.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (this.GoodsMakerName != target.GoodsMakerName) resList.Add("GoodsMakerName");
            if (this.GoodsNo != target.GoodsNo) resList.Add("GoodsNo");
            if (this.GoodsName != target.GoodsName) resList.Add("GoodsName");
            if (this.BLGoodsCode != target.BLGoodsCode) resList.Add("BLGoodsCode");
            if (this.BLGoodsName != target.BLGoodsName) resList.Add("BLGoodsName");
            if (this.SupplierCd1 != target.SupplierCd1) resList.Add("SupplierCd1");
            if (this.SupplierSnm != target.SupplierSnm) resList.Add("SupplierSnm");
            if (this.SupplierLot1 != target.SupplierLot1) resList.Add("SupplierLot1");
            if (this.GoodsMGroup != target.GoodsMGroup) resList.Add("GoodsMGroup");
            if (this.GoodsMGroupNm != target.GoodsMGroupNm) resList.Add("GoodsMGroupNm");

            return resList;
        }

        /// <summary>
        /// 商品管理情報ワーク比較処理
        /// </summary>
        /// <param name="goodsMng1">比較するGoodsMngクラスのインスタンス</param>
        /// <param name="goodsMng2">比較するGoodsMngクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsMngクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(GoodsMng goodsMng1, GoodsMng goodsMng2)
        {
            ArrayList resList = new ArrayList();
            if (goodsMng1.CreateDateTime != goodsMng2.CreateDateTime) resList.Add("CreateDateTime");
            if (goodsMng1.UpdateDateTime != goodsMng2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (goodsMng1.EnterpriseCode != goodsMng2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (goodsMng1.FileHeaderGuid != goodsMng2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (goodsMng1.UpdEmployeeCode != goodsMng2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (goodsMng1.UpdAssemblyId1 != goodsMng2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (goodsMng1.UpdAssemblyId2 != goodsMng2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (goodsMng1.LogicalDeleteCode != goodsMng2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (goodsMng1.SectionCode != goodsMng2.SectionCode) resList.Add("SectionCode");
            if (goodsMng1.SectionGuideNm != goodsMng2.SectionGuideNm) resList.Add("SectionGuideNm");
            if (goodsMng1.GoodsMakerCd != goodsMng2.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (goodsMng1.GoodsMakerName != goodsMng2.GoodsMakerName) resList.Add("GoodsMakerName");
            if (goodsMng1.GoodsNo != goodsMng2.GoodsNo) resList.Add("GoodsNo");
            if (goodsMng1.GoodsName != goodsMng2.GoodsName) resList.Add("GoodsName");
            if (goodsMng1.BLGoodsCode != goodsMng2.BLGoodsCode) resList.Add("BLGoodsCode");
            if (goodsMng1.BLGoodsName != goodsMng2.BLGoodsName) resList.Add("BlGoodsName");
            if (goodsMng1.SupplierCd1 != goodsMng2.SupplierCd1) resList.Add("SupplierCd1");
            if (goodsMng1.SupplierSnm != goodsMng2.SupplierSnm) resList.Add("SupplierSnm");
            if (goodsMng1.SupplierLot1 != goodsMng2.SupplierLot1) resList.Add("SupplierLot1");
            if (goodsMng1.GoodsMGroup != goodsMng2.GoodsMGroup) resList.Add("GoodsMGroup");
            if (goodsMng1.GoodsMGroupNm != goodsMng2.GoodsMGroupNm) resList.Add("GoodsMGroupNm");

            return resList;
        }
    }
}

using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   InventDataPreWork
	/// <summary>
	///                      棚卸データ（準備処理履歴）ワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   棚卸データ（準備処理履歴）ワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2007/4/2</br>
	/// <br>Genarated Date   :   2007/09/25  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class InventDataPreWork : IFileHeader
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
        /// <remarks>自拠点をセット</remarks>
        private string _sectionCode = "";

        /// <summary>棚卸準備処理日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _inventoryPreprDay;

        /// <summary>棚卸準備処理時間</summary>
        /// <remarks>HHMMSS</remarks>
        private Int32 _inventoryPreprTim;

        /// <summary>棚卸処理区分</summary>
        /// <remarks>※１</remarks>
        private Int32 _inventoryProcDiv;

        /// <summary>倉庫コード開始</summary>
        private string _warehouseCodeSt = "";

        /// <summary>倉庫コード終了</summary>
        private string _warehouseCodeEd = "";

        // -------ADD 2011/01/30------->>>>>
        /// <summary>管理拠点開始</summary>
        private string _mngSectionCodeSt = "";

        /// <summary>管理拠点終了</summary>
        private string _mngSectionCodeEd = "";
        // -------ADD 2011/01/30------->>>>>

        /// <summary>棚番開始</summary>
        private string _shelfNoSt = "";

        /// <summary>棚番終了</summary>
        private string _shelfNoEd = "";

        /// <summary>仕入先コード開始</summary>
        /// <remarks>※仕入先コードとして使用</remarks>
        private Int32 _startSupplierCode;

        /// <summary>仕入先コード終了</summary>
        /// <remarks>※仕入先コードとして使用</remarks>
        private Int32 _endSupplierCode;

        /// <summary>ＢＬ商品コード開始</summary>
        private Int32 _bLGoodsCodeSt;

        /// <summary>ＢＬ商品コード終了</summary>
        private Int32 _bLGoodsCodeEd;

        /// <summary>商品メーカーコード開始</summary>
        /// <remarks>ﾊﾟｯｹｰｼﾞ毎にﾕｰｻﾞｰ登録範囲が異なる</remarks>
        private Int32 _goodsMakerCdSt;

        /// <summary>商品メーカーコード終了</summary>
        /// <remarks>ﾊﾟｯｹｰｼﾞ毎にﾕｰｻﾞｰ登録範囲が異なる</remarks>
        private Int32 _goodsMakerCdEd;

        /// <summary>BLグループコード開始</summary>
        private Int32 _bLGroupCodeSt;

        /// <summary>BLグループコード終了</summary>
        private Int32 _bLGroupCodeEd;

        /// <summary>受託在庫抽出区分</summary>
        /// <remarks>0:抽出する,1:抽出しない</remarks>
        private Int32 _trtStkExtraDiv;

        /// <summary>委託（自社）在庫抽出区分</summary>
        /// <remarks>0:抽出する,1:抽出しない</remarks>
        private Int32 _entCmpStkExtraDiv;

        /// <summary>最終棚卸更新日開始</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _ltInventoryUpdateSt;

        /// <summary>最終棚卸更新日終了</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _ltInventoryUpdateEd;

        /// <summary>選択倉庫コード１</summary>
        private string _selWarehouseCode1 = "";

        /// <summary>選択倉庫コード２</summary>
        private string _selWarehouseCode2 = "";

        /// <summary>選択倉庫コード３</summary>
        private string _selWarehouseCode3 = "";

        /// <summary>選択倉庫コード４</summary>
        private string _selWarehouseCode4 = "";

        /// <summary>選択倉庫コード５</summary>
        private string _selWarehouseCode5 = "";

        /// <summary>選択倉庫コード６</summary>
        private string _selWarehouseCode6 = "";

        /// <summary>選択倉庫コード７</summary>
        private string _selWarehouseCode7 = "";

        /// <summary>選択倉庫コード８</summary>
        private string _selWarehouseCode8 = "";

        /// <summary>選択倉庫コード９</summary>
        private string _selWarehouseCode9 = "";

        /// <summary>選択倉庫コード１０</summary>
        private string _selWarehouseCode10 = "";

        /// <summary>棚卸実施日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _inventoryDate;


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
        /// <value>自拠点をセット</value>
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

        /// public propaty name  :  InventoryPreprDay
        /// <summary>棚卸準備処理日付プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   棚卸準備処理日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime InventoryPreprDay
        {
            get { return _inventoryPreprDay; }
            set { _inventoryPreprDay = value; }
        }

        /// public propaty name  :  InventoryPreprTim
        /// <summary>棚卸準備処理時間プロパティ</summary>
        /// <value>HHMMSS</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   棚卸準備処理時間プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 InventoryPreprTim
        {
            get { return _inventoryPreprTim; }
            set { _inventoryPreprTim = value; }
        }

        /// public propaty name  :  InventoryProcDiv
        /// <summary>棚卸処理区分プロパティ</summary>
        /// <value>※１</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   棚卸処理区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 InventoryProcDiv
        {
            get { return _inventoryProcDiv; }
            set { _inventoryProcDiv = value; }
        }

        /// public propaty name  :  WarehouseCodeSt
        /// <summary>倉庫コード開始プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫コード開始プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseCodeSt
        {
            get { return _warehouseCodeSt; }
            set { _warehouseCodeSt = value; }
        }

        /// public propaty name  :  WarehouseCodeEd
        /// <summary>倉庫コード終了プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫コード終了プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseCodeEd
        {
            get { return _warehouseCodeEd; }
            set { _warehouseCodeEd = value; }
        }

        // -------ADD 2011/01/30------->>>>>
        /// public propaty name  :  MngSectionCodeSt
        /// <summary>管理拠点開始プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   管理拠点開始プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MngSectionCodeSt
        {
            get { return _mngSectionCodeSt; }
            set { _mngSectionCodeSt = value; }
        }

        /// public propaty name  :  MngSectionCodeEd
        /// <summary>管理拠点終了プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   管理拠点終了プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MngSectionCodeEd
        {
            get { return _mngSectionCodeEd; }
            set { _mngSectionCodeEd = value; }
        }
        // -------ADD 2011/01/30------->>>>>

        /// public propaty name  :  ShelfNoSt
        /// <summary>棚番開始プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   棚番開始プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ShelfNoSt
        {
            get { return _shelfNoSt; }
            set { _shelfNoSt = value; }
        }

        /// public propaty name  :  ShelfNoEd
        /// <summary>棚番終了プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   棚番終了プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ShelfNoEd
        {
            get { return _shelfNoEd; }
            set { _shelfNoEd = value; }
        }

        /// public propaty name  :  StartSupplierCode
        /// <summary>仕入先コード開始プロパティ</summary>
        /// <value>※仕入先コードとして使用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先コード開始プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StartSupplierCode
        {
            get { return _startSupplierCode; }
            set { _startSupplierCode = value; }
        }

        /// public propaty name  :  EndSupplierCode
        /// <summary>仕入先コード終了プロパティ</summary>
        /// <value>※仕入先コードとして使用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先コード終了プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EndSupplierCode
        {
            get { return _endSupplierCode; }
            set { _endSupplierCode = value; }
        }

        /// public propaty name  :  BLGoodsCodeSt
        /// <summary>ＢＬ商品コード開始プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ＢＬ商品コード開始プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGoodsCodeSt
        {
            get { return _bLGoodsCodeSt; }
            set { _bLGoodsCodeSt = value; }
        }

        /// public propaty name  :  BLGoodsCodeEd
        /// <summary>ＢＬ商品コード終了プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ＢＬ商品コード終了プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGoodsCodeEd
        {
            get { return _bLGoodsCodeEd; }
            set { _bLGoodsCodeEd = value; }
        }

        /// public propaty name  :  GoodsMakerCdSt
        /// <summary>商品メーカーコード開始プロパティ</summary>
        /// <value>ﾊﾟｯｹｰｼﾞ毎にﾕｰｻﾞｰ登録範囲が異なる</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品メーカーコード開始プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCdSt
        {
            get { return _goodsMakerCdSt; }
            set { _goodsMakerCdSt = value; }
        }

        /// public propaty name  :  GoodsMakerCdEd
        /// <summary>商品メーカーコード終了プロパティ</summary>
        /// <value>ﾊﾟｯｹｰｼﾞ毎にﾕｰｻﾞｰ登録範囲が異なる</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品メーカーコード終了プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCdEd
        {
            get { return _goodsMakerCdEd; }
            set { _goodsMakerCdEd = value; }
        }

        /// public propaty name  :  BLGroupCodeSt
        /// <summary>BLグループコード開始プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLグループコード開始プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGroupCodeSt
        {
            get { return _bLGroupCodeSt; }
            set { _bLGroupCodeSt = value; }
        }

        /// public propaty name  :  BLGroupCodeEd
        /// <summary>BLグループコード終了プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLグループコード終了プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGroupCodeEd
        {
            get { return _bLGroupCodeEd; }
            set { _bLGroupCodeEd = value; }
        }

        /// public propaty name  :  TrtStkExtraDiv
        /// <summary>受託在庫抽出区分プロパティ</summary>
        /// <value>0:抽出する,1:抽出しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受託在庫抽出区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TrtStkExtraDiv
        {
            get { return _trtStkExtraDiv; }
            set { _trtStkExtraDiv = value; }
        }

        /// public propaty name  :  EntCmpStkExtraDiv
        /// <summary>委託（自社）在庫抽出区分プロパティ</summary>
        /// <value>0:抽出する,1:抽出しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   委託（自社）在庫抽出区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EntCmpStkExtraDiv
        {
            get { return _entCmpStkExtraDiv; }
            set { _entCmpStkExtraDiv = value; }
        }

        /// public propaty name  :  LtInventoryUpdateSt
        /// <summary>最終棚卸更新日開始プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   最終棚卸更新日開始プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime LtInventoryUpdateSt
        {
            get { return _ltInventoryUpdateSt; }
            set { _ltInventoryUpdateSt = value; }
        }

        /// public propaty name  :  LtInventoryUpdateEd
        /// <summary>最終棚卸更新日終了プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   最終棚卸更新日終了プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime LtInventoryUpdateEd
        {
            get { return _ltInventoryUpdateEd; }
            set { _ltInventoryUpdateEd = value; }
        }

        /// public propaty name  :  SelWarehouseCode1
        /// <summary>選択倉庫コード１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   選択倉庫コード１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SelWarehouseCode1
        {
            get { return _selWarehouseCode1; }
            set { _selWarehouseCode1 = value; }
        }

        /// public propaty name  :  SelWarehouseCode2
        /// <summary>選択倉庫コード２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   選択倉庫コード２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SelWarehouseCode2
        {
            get { return _selWarehouseCode2; }
            set { _selWarehouseCode2 = value; }
        }

        /// public propaty name  :  SelWarehouseCode3
        /// <summary>選択倉庫コード３プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   選択倉庫コード３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SelWarehouseCode3
        {
            get { return _selWarehouseCode3; }
            set { _selWarehouseCode3 = value; }
        }

        /// public propaty name  :  SelWarehouseCode4
        /// <summary>選択倉庫コード４プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   選択倉庫コード４プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SelWarehouseCode4
        {
            get { return _selWarehouseCode4; }
            set { _selWarehouseCode4 = value; }
        }

        /// public propaty name  :  SelWarehouseCode5
        /// <summary>選択倉庫コード５プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   選択倉庫コード５プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SelWarehouseCode5
        {
            get { return _selWarehouseCode5; }
            set { _selWarehouseCode5 = value; }
        }

        /// public propaty name  :  SelWarehouseCode6
        /// <summary>選択倉庫コード６プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   選択倉庫コード６プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SelWarehouseCode6
        {
            get { return _selWarehouseCode6; }
            set { _selWarehouseCode6 = value; }
        }

        /// public propaty name  :  SelWarehouseCode7
        /// <summary>選択倉庫コード７プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   選択倉庫コード７プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SelWarehouseCode7
        {
            get { return _selWarehouseCode7; }
            set { _selWarehouseCode7 = value; }
        }

        /// public propaty name  :  SelWarehouseCode8
        /// <summary>選択倉庫コード８プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   選択倉庫コード８プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SelWarehouseCode8
        {
            get { return _selWarehouseCode8; }
            set { _selWarehouseCode8 = value; }
        }

        /// public propaty name  :  SelWarehouseCode9
        /// <summary>選択倉庫コード９プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   選択倉庫コード９プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SelWarehouseCode9
        {
            get { return _selWarehouseCode9; }
            set { _selWarehouseCode9 = value; }
        }

        /// public propaty name  :  SelWarehouseCode10
        /// <summary>選択倉庫コード１０プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   選択倉庫コード１０プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SelWarehouseCode10
        {
            get { return _selWarehouseCode10; }
            set { _selWarehouseCode10 = value; }
        }

        /// public propaty name  :  InventoryDate
        /// <summary>棚卸実施日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   棚卸実施日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime InventoryDate
        {
            get { return _inventoryDate; }
            set { _inventoryDate = value; }
        }


        /// <summary>
        /// 棚卸データ（準備処理履歴）ワークコンストラクタ
        /// </summary>
        /// <returns>InventDataPreWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   InventDataPreWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public InventDataPreWork()
        {
        }

    }

/// <summary>
///  Ver5.10.1.0用のカスタムシライアライザです。
/// </summary>
/// <returns>InventDataPreWorkクラスのインスタンス(object)</returns>
/// <remarks>
/// <br>Note　　　　　　 :   InventDataPreWorkクラスのカスタムシリアライザを定義します</br>
/// <br>Programer        :   自動生成</br>
/// </remarks>
public class InventDataPreWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
{
    #region ICustomSerializationSurrogate メンバ

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシリアライザです
    /// </summary>
    /// <remarks>
    /// <br>Note　　　　　　 :   InventDataPreWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public void Serialize(System.IO.BinaryWriter writer, object graph)
    {
        // TODO:  InventDataPreWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
        if (writer == null)
            throw new ArgumentNullException();

        if (graph != null && !(graph is InventDataPreWork || graph is ArrayList || graph is InventDataPreWork[]))
            throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(InventDataPreWork).FullName));

        if (graph != null && graph is InventDataPreWork)
        {
            Type t = graph.GetType();
            if (!CustomFormatterServices.NeedCustomSerialization(t))
                throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
        }

        //SerializationTypeInfo
        Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.InventDataPreWork");

        //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
        int occurrence = 0;     //一般にゼロの場合もありえます
        if (graph is ArrayList)
        {
            serInfo.RetTypeInfo = 0;
            occurrence = ((ArrayList)graph).Count;
        }
        else if (graph is InventDataPreWork[])
        {
            serInfo.RetTypeInfo = 2;
            occurrence = ((InventDataPreWork[])graph).Length;
        }
        else if (graph is InventDataPreWork)
        {
            serInfo.RetTypeInfo = 1;
            occurrence = 1;
        }

        serInfo.Occurrence = occurrence;		 //繰り返し数	

        //作成日時
        serInfo.MemberInfo.Add(typeof(Int64)); //CreateDateTime
        //更新日時
        serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTime
        //企業コード
        serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
        //GUID
        serInfo.MemberInfo.Add(typeof(byte[]));  //FileHeaderGuid
        //更新従業員コード
        serInfo.MemberInfo.Add(typeof(string)); //UpdEmployeeCode
        //更新アセンブリID1
        serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId1
        //更新アセンブリID2
        serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId2
        //論理削除区分
        serInfo.MemberInfo.Add(typeof(Int32)); //LogicalDeleteCode
        //拠点コード
        serInfo.MemberInfo.Add(typeof(string)); //SectionCode
        //棚卸準備処理日付
        serInfo.MemberInfo.Add(typeof(Int32)); //InventoryPreprDay
        //棚卸準備処理時間
        serInfo.MemberInfo.Add(typeof(Int32)); //InventoryPreprTim
        //棚卸処理区分
        serInfo.MemberInfo.Add(typeof(Int32)); //InventoryProcDiv
        //倉庫コード開始
        serInfo.MemberInfo.Add(typeof(string)); //WarehouseCodeSt
        //倉庫コード終了
        serInfo.MemberInfo.Add(typeof(string)); //WarehouseCodeEd
        // -------ADD 2011/01/30------->>>>>
        //管理拠点開始
        serInfo.MemberInfo.Add(typeof(string)); //MngSectionCodeSt
        //管理拠点終了
        serInfo.MemberInfo.Add(typeof(string)); //MngSectionCodeEd
        // -------ADD 2011/01/30-------<<<<<
        //棚番開始
        serInfo.MemberInfo.Add(typeof(string)); //ShelfNoSt
        //棚番終了
        serInfo.MemberInfo.Add(typeof(string)); //ShelfNoEd
        //仕入先コード開始
        serInfo.MemberInfo.Add(typeof(Int32)); //StartSupplierCode
        //仕入先コード終了
        serInfo.MemberInfo.Add(typeof(Int32)); //EndSupplierCode
        //ＢＬ商品コード開始
        serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCodeSt
        //ＢＬ商品コード終了
        serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCodeEd
        //商品メーカーコード開始
        serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCdSt
        //商品メーカーコード終了
        serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCdEd
        //BLグループコード開始
        serInfo.MemberInfo.Add(typeof(Int32)); //BLGroupCodeSt
        //BLグループコード終了
        serInfo.MemberInfo.Add(typeof(Int32)); //BLGroupCodeEd
        //受託在庫抽出区分
        serInfo.MemberInfo.Add(typeof(Int32)); //TrtStkExtraDiv
        //委託（自社）在庫抽出区分
        serInfo.MemberInfo.Add(typeof(Int32)); //EntCmpStkExtraDiv
        //最終棚卸更新日開始
        serInfo.MemberInfo.Add(typeof(Int32)); //LtInventoryUpdateSt
        //最終棚卸更新日終了
        serInfo.MemberInfo.Add(typeof(Int32)); //LtInventoryUpdateEd
        //選択倉庫コード１
        serInfo.MemberInfo.Add(typeof(string)); //SelWarehouseCode1
        //選択倉庫コード２
        serInfo.MemberInfo.Add(typeof(string)); //SelWarehouseCode2
        //選択倉庫コード３
        serInfo.MemberInfo.Add(typeof(string)); //SelWarehouseCode3
        //選択倉庫コード４
        serInfo.MemberInfo.Add(typeof(string)); //SelWarehouseCode4
        //選択倉庫コード５
        serInfo.MemberInfo.Add(typeof(string)); //SelWarehouseCode5
        //選択倉庫コード６
        serInfo.MemberInfo.Add(typeof(string)); //SelWarehouseCode6
        //選択倉庫コード７
        serInfo.MemberInfo.Add(typeof(string)); //SelWarehouseCode7
        //選択倉庫コード８
        serInfo.MemberInfo.Add(typeof(string)); //SelWarehouseCode8
        //選択倉庫コード９
        serInfo.MemberInfo.Add(typeof(string)); //SelWarehouseCode9
        //選択倉庫コード１０
        serInfo.MemberInfo.Add(typeof(string)); //SelWarehouseCode10
        //棚卸実施日
        serInfo.MemberInfo.Add(typeof(Int32)); //InventoryDate


        serInfo.Serialize(writer, serInfo);
        if (graph is InventDataPreWork)
        {
            InventDataPreWork temp = (InventDataPreWork)graph;

            SetInventDataPreWork(writer, temp);
        }
        else
        {
            ArrayList lst = null;
            if (graph is InventDataPreWork[])
            {
                lst = new ArrayList();
                lst.AddRange((InventDataPreWork[])graph);
            }
            else
            {
                lst = (ArrayList)graph;
            }

            foreach (InventDataPreWork temp in lst)
            {
                SetInventDataPreWork(writer, temp);
            }

        }


    }


    /// <summary>
    /// InventDataPreWorkメンバ数(publicプロパティ数)
    /// </summary>
    //private const int currentMemberCount = 39;// DEL 2011/01/30
    private const int currentMemberCount = 41;// ADD 2011/01/30

    /// <summary>
    ///  InventDataPreWorkインスタンス書き込み
    /// </summary>
    /// <remarks>
    /// <br>Note　　　　　　 :   InventDataPreWorkのインスタンスを書き込み</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    private void SetInventDataPreWork(System.IO.BinaryWriter writer, InventDataPreWork temp)
    {
        //作成日時
        writer.Write((Int64)temp.CreateDateTime.Ticks);
        //更新日時
        writer.Write((Int64)temp.UpdateDateTime.Ticks);
        //企業コード
        writer.Write(temp.EnterpriseCode);
        //GUID
        byte[] fileHeaderGuidArray = temp.FileHeaderGuid.ToByteArray();
        writer.Write(fileHeaderGuidArray.Length);
        writer.Write(temp.FileHeaderGuid.ToByteArray());
        //更新従業員コード
        writer.Write(temp.UpdEmployeeCode);
        //更新アセンブリID1
        writer.Write(temp.UpdAssemblyId1);
        //更新アセンブリID2
        writer.Write(temp.UpdAssemblyId2);
        //論理削除区分
        writer.Write(temp.LogicalDeleteCode);
        //拠点コード
        writer.Write(temp.SectionCode);
        //棚卸準備処理日付
        writer.Write((Int64)temp.InventoryPreprDay.Ticks);
        //棚卸準備処理時間
        writer.Write(temp.InventoryPreprTim);
        //棚卸処理区分
        writer.Write(temp.InventoryProcDiv);
        //倉庫コード開始
        writer.Write(temp.WarehouseCodeSt);
        //倉庫コード終了
        writer.Write(temp.WarehouseCodeEd);
        // -------ADD 2011/01/30------->>>>>
        //管理拠点開始
        writer.Write(temp.MngSectionCodeSt);
        //管理拠点終了
        writer.Write(temp.MngSectionCodeEd);
        // -------ADD 2011/01/30-------<<<<<
        //棚番開始
        writer.Write(temp.ShelfNoSt);
        //棚番終了
        writer.Write(temp.ShelfNoEd);
        //仕入先コード開始
        writer.Write(temp.StartSupplierCode);
        //仕入先コード終了
        writer.Write(temp.EndSupplierCode);
        //ＢＬ商品コード開始
        writer.Write(temp.BLGoodsCodeSt);
        //ＢＬ商品コード終了
        writer.Write(temp.BLGoodsCodeEd);
        //商品メーカーコード開始
        writer.Write(temp.GoodsMakerCdSt);
        //商品メーカーコード終了
        writer.Write(temp.GoodsMakerCdEd);
        //BLグループコード開始
        writer.Write(temp.BLGroupCodeSt);
        //BLグループコード終了
        writer.Write(temp.BLGroupCodeEd);
        //受託在庫抽出区分
        writer.Write(temp.TrtStkExtraDiv);
        //委託（自社）在庫抽出区分
        writer.Write(temp.EntCmpStkExtraDiv);
        //最終棚卸更新日開始
        writer.Write((Int64)temp.LtInventoryUpdateSt.Ticks);
        //最終棚卸更新日終了
        writer.Write((Int64)temp.LtInventoryUpdateEd.Ticks);
        //選択倉庫コード１
        writer.Write(temp.SelWarehouseCode1);
        //選択倉庫コード２
        writer.Write(temp.SelWarehouseCode2);
        //選択倉庫コード３
        writer.Write(temp.SelWarehouseCode3);
        //選択倉庫コード４
        writer.Write(temp.SelWarehouseCode4);
        //選択倉庫コード５
        writer.Write(temp.SelWarehouseCode5);
        //選択倉庫コード６
        writer.Write(temp.SelWarehouseCode6);
        //選択倉庫コード７
        writer.Write(temp.SelWarehouseCode7);
        //選択倉庫コード８
        writer.Write(temp.SelWarehouseCode8);
        //選択倉庫コード９
        writer.Write(temp.SelWarehouseCode9);
        //選択倉庫コード１０
        writer.Write(temp.SelWarehouseCode10);
        //棚卸実施日
        writer.Write((Int64)temp.InventoryDate.Ticks);

    }

    /// <summary>
    ///  InventDataPreWorkインスタンス取得
    /// </summary>
    /// <returns>InventDataPreWorkクラスのインスタンス</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   InventDataPreWorkのインスタンスを取得します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    private InventDataPreWork GetInventDataPreWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
    {
        // V5.1.0.0なので不要ですが、V5.1.0.1以降では
        // serInfo.MemberInfo.Count < currentMemberCount
        // のケースについての配慮が必要になります。

        InventDataPreWork temp = new InventDataPreWork();

        //作成日時
        temp.CreateDateTime = new DateTime(reader.ReadInt64());
        //更新日時
        temp.UpdateDateTime = new DateTime(reader.ReadInt64());
        //企業コード
        temp.EnterpriseCode = reader.ReadString();
        //GUID
        int lenOfFileHeaderGuidArray = reader.ReadInt32();
        byte[] fileHeaderGuidArray = reader.ReadBytes(lenOfFileHeaderGuidArray);
        temp.FileHeaderGuid = new Guid(fileHeaderGuidArray);
        //更新従業員コード
        temp.UpdEmployeeCode = reader.ReadString();
        //更新アセンブリID1
        temp.UpdAssemblyId1 = reader.ReadString();
        //更新アセンブリID2
        temp.UpdAssemblyId2 = reader.ReadString();
        //論理削除区分
        temp.LogicalDeleteCode = reader.ReadInt32();
        //拠点コード
        temp.SectionCode = reader.ReadString();
        //棚卸準備処理日付
        temp.InventoryPreprDay = new DateTime(reader.ReadInt64());
        //棚卸準備処理時間
        temp.InventoryPreprTim = reader.ReadInt32();
        //棚卸処理区分
        temp.InventoryProcDiv = reader.ReadInt32();
        //倉庫コード開始
        temp.WarehouseCodeSt = reader.ReadString();
        //倉庫コード終了
        temp.WarehouseCodeEd = reader.ReadString();
        // -------ADD 2011/01/30------->>>>>
        //管理拠点開始
        temp.MngSectionCodeSt = reader.ReadString();
        //管理拠点終了
        temp.MngSectionCodeEd = reader.ReadString();
        // -------ADD 2011/01/30-------<<<<<
        //棚番開始
        temp.ShelfNoSt = reader.ReadString();
        //棚番終了
        temp.ShelfNoEd = reader.ReadString();
        //仕入先コード開始
        temp.StartSupplierCode = reader.ReadInt32();
        //仕入先コード終了
        temp.EndSupplierCode = reader.ReadInt32();
        //ＢＬ商品コード開始
        temp.BLGoodsCodeSt = reader.ReadInt32();
        //ＢＬ商品コード終了
        temp.BLGoodsCodeEd = reader.ReadInt32();
        //商品メーカーコード開始
        temp.GoodsMakerCdSt = reader.ReadInt32();
        //商品メーカーコード終了
        temp.GoodsMakerCdEd = reader.ReadInt32();
        //BLグループコード開始
        temp.BLGroupCodeSt = reader.ReadInt32();
        //BLグループコード終了
        temp.BLGroupCodeEd = reader.ReadInt32();
        //受託在庫抽出区分
        temp.TrtStkExtraDiv = reader.ReadInt32();
        //委託（自社）在庫抽出区分
        temp.EntCmpStkExtraDiv = reader.ReadInt32();
        //最終棚卸更新日開始
        temp.LtInventoryUpdateSt = new DateTime(reader.ReadInt64());
        //最終棚卸更新日終了
        temp.LtInventoryUpdateEd = new DateTime(reader.ReadInt64());
        //選択倉庫コード１
        temp.SelWarehouseCode1 = reader.ReadString();
        //選択倉庫コード２
        temp.SelWarehouseCode2 = reader.ReadString();
        //選択倉庫コード３
        temp.SelWarehouseCode3 = reader.ReadString();
        //選択倉庫コード４
        temp.SelWarehouseCode4 = reader.ReadString();
        //選択倉庫コード５
        temp.SelWarehouseCode5 = reader.ReadString();
        //選択倉庫コード６
        temp.SelWarehouseCode6 = reader.ReadString();
        //選択倉庫コード７
        temp.SelWarehouseCode7 = reader.ReadString();
        //選択倉庫コード８
        temp.SelWarehouseCode8 = reader.ReadString();
        //選択倉庫コード９
        temp.SelWarehouseCode9 = reader.ReadString();
        //選択倉庫コード１０
        temp.SelWarehouseCode10 = reader.ReadString();
        //棚卸実施日
        temp.InventoryDate = new DateTime(reader.ReadInt64());


        //以下は読み飛ばしです。このバージョンが想定する EmployeeWork型以降のバージョンの
        //データをデシリアライズする場合、シリアライズしたフォーマッタが記述した
        //型情報にしたがって、ストリームから情報を読み出します...といっても
        //読み出して捨てることになります。
        for (int k = currentMemberCount; k < serInfo.MemberInfo.Count; ++k)
        {
            //byte[],char[]をデシリアライズする直前に、そのlengthが
            //デシリアライズされているケースがある、byte[],char[]の
            //デシリアライズにはlengthが必要なのでint型のデータをデ
            //シリアライズした場合は、この値をこの変数に退避します。
            int optCount = 0;
            object oMemberType = serInfo.MemberInfo[k];
            if (oMemberType is Type)
            {
                Type t = (Type)oMemberType;
                object oData = TypeDeserializer.DeserializePrimitiveType(reader, t, optCount);
                if (t.Equals(typeof(int)))
                {
                    optCount = Convert.ToInt32(oData);
                }
                else
                {
                    optCount = 0;
                }
            }
            else if (oMemberType is string)
            {
                Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate((string)oMemberType);
                object userData = formatter.Deserialize(reader);  //読み飛ばし
            }
        }
        return temp;
    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムデシリアライザです
    /// </summary>
    /// <returns>InventDataPreWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   InventDataPreWorkクラスのカスタムデシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public object Deserialize(System.IO.BinaryReader reader)
    {
        object retValue = null;
        Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
        ArrayList lst = new ArrayList();
        for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
        {
            InventDataPreWork temp = GetInventDataPreWork(reader, serInfo);
            lst.Add(temp);
        }
        switch (serInfo.RetTypeInfo)
        {
            case 0:
                retValue = lst;
                break;
            case 1:
                retValue = lst[0];
                break;
            case 2:
                retValue = (InventDataPreWork[])lst.ToArray(typeof(InventDataPreWork));
                break;
        }
        return retValue;
    }

    #endregion
}
}

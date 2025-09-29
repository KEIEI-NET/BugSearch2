using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   InventInputSearchCndtnWork
    /// <summary>
    ///                      棚卸検索抽出条件ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   棚卸検索抽出条件ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/03/19  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// <br>Update Note      : l2011/01/11 liyp </br>
    /// <br>                  貸出分の印刷がされない不具合の修正</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class InventInputSearchCndtnWork
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>開始拠点コード</summary>
        private string _st_SectionCode = "";

        /// <summary>終了拠点コード</summary>
        private string _ed_SectionCode = "";

        /// <summary>開始メーカーコード</summary>
        private Int32 _st_MakerCode;

        /// <summary>終了メーカーコード</summary>
        private Int32 _ed_MakerCode;

        /// <summary>開始商品番号</summary>
        private string _st_GoodsNo = "";

        /// <summary>終了商品番号</summary>
        private string _ed_GoodsNo = "";

        /// <summary>倉庫指定区分</summary>
        /// <remarks>0:範囲,1:単独</remarks>
        private Int32 _warehouseDiv;

        /// <summary>開始倉庫コード</summary>
        private string _st_WarehouseCode = "";

        /// <summary>終了倉庫コード</summary>
        private string _ed_WarehouseCode = "";

        /// <summary>倉庫コード01</summary>
        private string _warehouseCd01 = "";

        /// <summary>倉庫コード02</summary>
        private string _warehouseCd02 = "";

        /// <summary>倉庫コード03</summary>
        private string _warehouseCd03 = "";

        /// <summary>倉庫コード04</summary>
        private string _warehouseCd04 = "";

        /// <summary>倉庫コード05</summary>
        private string _warehouseCd05 = "";

        /// <summary>倉庫コード06</summary>
        private string _warehouseCd06 = "";

        /// <summary>倉庫コード07</summary>
        private string _warehouseCd07 = "";

        /// <summary>倉庫コード08</summary>
        private string _warehouseCd08 = "";

        /// <summary>倉庫コード09</summary>
        private string _warehouseCd09 = "";

        /// <summary>倉庫コード10</summary>
        private string _warehouseCd10 = "";

        /// <summary>開始棚番</summary>
        private string _st_WarehouseShelfNo = "";

        /// <summary>終了棚番</summary>
        private string _ed_WarehouseShelfNo = "";

        /// <summary>開始自社分類コード</summary>
        private Int32 _st_EnterpriseGanreCode;

        /// <summary>終了自社分類コード</summary>
        private Int32 _ed_EnterpriseGanreCode;

        /// <summary>開始BLコード</summary>
        private Int32 _st_BLGoodsCode;

        /// <summary>終了BLコード</summary>
        private Int32 _ed_BLGoodsCode;

        /// <summary>開始仕入先コード</summary>
        private Int32 _st_SupplierCd;

        /// <summary>終了仕入先コード</summary>
        private Int32 _ed_SupplierCd;

        /// <summary>開始棚卸準備処理日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _st_InventoryPreprDay;

        /// <summary>終了棚卸準備処理日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _ed_InventoryPreprDay;

        /// <summary>棚卸日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _inventoryDate;

        /// <summary>開始棚卸通番</summary>
        private Int32 _st_InventorySeqNo;

        /// <summary>終了棚卸通番</summary>
        private Int32 _ed_InventorySeqNo;

        /// <summary>開始グループコード</summary>
        private Int32 _st_BLGroupCode;

        /// <summary>終了グループコード</summary>
        private Int32 _ed_BLGroupCode;

        /// <summary>差異分抽出区分</summary>
        /// <remarks>0:全て,1:数未入力分のみ,2:数入力分のみ,3:差異分のみ</remarks>
        private Int32 _difCntExtraDiv;

        /// <summary>在庫数0抽出区分</summary>
        /// <remarks>0:抽出する,1:抽出しない</remarks>
        private Int32 _stockCntZeroExtraDiv;

        /// <summary>棚卸在庫数0抽出区分</summary>
        /// <remarks>0:抽出する,1:抽出しない</remarks>
        private Int32 _ivtStkCntZeroExtraDiv;

        /// <summary>帳票種別</summary>
        /// <remarks>0:棚卸記入表、1:棚卸差異表、2:棚卸表</remarks>
        private Int32 _selectedPaperKind;

        /// <summary>出力指定区分</summary>
        /// <remarks>0:全て,1:棚卸未入力分のみ,2:差異分のみ,3:重複棚番ありのみ</remarks>
        private Int32 _outputAppointDiv;

        /// <summary>抽出対象日付区分</summary>
        /// <remarks>0:棚卸準備処理日,1:棚卸実施日,2:棚卸更新日</remarks>
        private Int32 _targetDateExtraDiv;

        /// <summary>在庫数算出フラグ</summary>
        /// <remarks>0:在庫数算出しない, 1:在庫数算出する</remarks>
        private Int32 _calcStockAmountDiv;

        /// <summary>在庫数算出日付</summary>
        /// <remarks>在庫数算出フラグ=1のときの在庫数算出日付</remarks>
        private DateTime _calcStockAmountDate;

        /// <summary>在庫区分</summary>
        /// <remarks>0:全て,1:自社,2:受託</remarks>
        private Int32 _stockDiv;

        /// <summary>貸出抽出区分</summary>
        /// <remarks>0:印刷しない,1:印刷する</remarks>
        private Int32 _lendExtraDiv;

        /// <summary>来勘計上抽出区分</summary>
        /// <remarks>0:印刷しない,1:印刷する</remarks>
        private Int32 _delayPaymentDiv;

        // -----------ADD 2011/01/11 ------------------>>>>>
        /// <summary>数量出力区分</summary>
        private Int32 _numOutputDiv;
        /// <summary>棚番出力区分</summary>
        /// <remarks>0:全て出力,1:棚番なしのみ出力,2:棚番なし以外出力</remarks>
        private Int32 _warehouseShelfOutputDiv;
        // -----------ADD 2011/01/11 ------------------<<<<<

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

        /// public propaty name  :  St_SectionCode
        /// <summary>開始拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string St_SectionCode
        {
            get { return _st_SectionCode; }
            set { _st_SectionCode = value; }
        }

        /// public propaty name  :  Ed_SectionCode
        /// <summary>終了拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Ed_SectionCode
        {
            get { return _ed_SectionCode; }
            set { _ed_SectionCode = value; }
        }

        /// public propaty name  :  St_MakerCode
        /// <summary>開始メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_MakerCode
        {
            get { return _st_MakerCode; }
            set { _st_MakerCode = value; }
        }

        /// public propaty name  :  Ed_MakerCode
        /// <summary>終了メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_MakerCode
        {
            get { return _ed_MakerCode; }
            set { _ed_MakerCode = value; }
        }

        /// public propaty name  :  St_GoodsNo
        /// <summary>開始商品番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string St_GoodsNo
        {
            get { return _st_GoodsNo; }
            set { _st_GoodsNo = value; }
        }

        /// public propaty name  :  Ed_GoodsNo
        /// <summary>終了商品番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Ed_GoodsNo
        {
            get { return _ed_GoodsNo; }
            set { _ed_GoodsNo = value; }
        }

        /// public propaty name  :  WarehouseDiv
        /// <summary>倉庫指定区分プロパティ</summary>
        /// <value>0:範囲,1:単独</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫指定区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 WarehouseDiv
        {
            get { return _warehouseDiv; }
            set { _warehouseDiv = value; }
        }

        /// public propaty name  :  St_WarehouseCode
        /// <summary>開始倉庫コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始倉庫コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string St_WarehouseCode
        {
            get { return _st_WarehouseCode; }
            set { _st_WarehouseCode = value; }
        }

        /// public propaty name  :  Ed_WarehouseCode
        /// <summary>終了倉庫コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了倉庫コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Ed_WarehouseCode
        {
            get { return _ed_WarehouseCode; }
            set { _ed_WarehouseCode = value; }
        }

        /// public propaty name  :  WarehouseCd01
        /// <summary>倉庫コード01プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫コード01プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseCd01
        {
            get { return _warehouseCd01; }
            set { _warehouseCd01 = value; }
        }

        /// public propaty name  :  WarehouseCd02
        /// <summary>倉庫コード02プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫コード02プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseCd02
        {
            get { return _warehouseCd02; }
            set { _warehouseCd02 = value; }
        }

        /// public propaty name  :  WarehouseCd03
        /// <summary>倉庫コード03プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫コード03プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseCd03
        {
            get { return _warehouseCd03; }
            set { _warehouseCd03 = value; }
        }

        /// public propaty name  :  WarehouseCd04
        /// <summary>倉庫コード04プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫コード04プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseCd04
        {
            get { return _warehouseCd04; }
            set { _warehouseCd04 = value; }
        }

        /// public propaty name  :  WarehouseCd05
        /// <summary>倉庫コード05プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫コード05プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseCd05
        {
            get { return _warehouseCd05; }
            set { _warehouseCd05 = value; }
        }

        /// public propaty name  :  WarehouseCd06
        /// <summary>倉庫コード06プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫コード06プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseCd06
        {
            get { return _warehouseCd06; }
            set { _warehouseCd06 = value; }
        }

        /// public propaty name  :  WarehouseCd07
        /// <summary>倉庫コード07プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫コード07プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseCd07
        {
            get { return _warehouseCd07; }
            set { _warehouseCd07 = value; }
        }

        /// public propaty name  :  WarehouseCd08
        /// <summary>倉庫コード08プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫コード08プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseCd08
        {
            get { return _warehouseCd08; }
            set { _warehouseCd08 = value; }
        }

        /// public propaty name  :  WarehouseCd09
        /// <summary>倉庫コード09プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫コード09プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseCd09
        {
            get { return _warehouseCd09; }
            set { _warehouseCd09 = value; }
        }

        /// public propaty name  :  WarehouseCd10
        /// <summary>倉庫コード10プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫コード10プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseCd10
        {
            get { return _warehouseCd10; }
            set { _warehouseCd10 = value; }
        }

        /// public propaty name  :  St_WarehouseShelfNo
        /// <summary>開始棚番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始棚番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string St_WarehouseShelfNo
        {
            get { return _st_WarehouseShelfNo; }
            set { _st_WarehouseShelfNo = value; }
        }

        /// public propaty name  :  Ed_WarehouseShelfNo
        /// <summary>終了棚番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了棚番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Ed_WarehouseShelfNo
        {
            get { return _ed_WarehouseShelfNo; }
            set { _ed_WarehouseShelfNo = value; }
        }

        /// public propaty name  :  St_EnterpriseGanreCode
        /// <summary>開始自社分類コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始自社分類コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_EnterpriseGanreCode
        {
            get { return _st_EnterpriseGanreCode; }
            set { _st_EnterpriseGanreCode = value; }
        }

        /// public propaty name  :  Ed_EnterpriseGanreCode
        /// <summary>終了自社分類コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了自社分類コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_EnterpriseGanreCode
        {
            get { return _ed_EnterpriseGanreCode; }
            set { _ed_EnterpriseGanreCode = value; }
        }

        /// public propaty name  :  St_BLGoodsCode
        /// <summary>開始BLコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始BLコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_BLGoodsCode
        {
            get { return _st_BLGoodsCode; }
            set { _st_BLGoodsCode = value; }
        }

        /// public propaty name  :  Ed_BLGoodsCode
        /// <summary>終了BLコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了BLコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_BLGoodsCode
        {
            get { return _ed_BLGoodsCode; }
            set { _ed_BLGoodsCode = value; }
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

        /// public propaty name  :  St_InventoryPreprDay
        /// <summary>開始棚卸準備処理日付プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始棚卸準備処理日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime St_InventoryPreprDay
        {
            get { return _st_InventoryPreprDay; }
            set { _st_InventoryPreprDay = value; }
        }

        /// public propaty name  :  Ed_InventoryPreprDay
        /// <summary>終了棚卸準備処理日付プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了棚卸準備処理日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime Ed_InventoryPreprDay
        {
            get { return _ed_InventoryPreprDay; }
            set { _ed_InventoryPreprDay = value; }
        }

        /// public propaty name  :  InventoryDate
        /// <summary>棚卸日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   棚卸日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime InventoryDate
        {
            get { return _inventoryDate; }
            set { _inventoryDate = value; }
        }

        /// public propaty name  :  St_InventorySeqNo
        /// <summary>開始棚卸通番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始棚卸通番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_InventorySeqNo
        {
            get { return _st_InventorySeqNo; }
            set { _st_InventorySeqNo = value; }
        }

        /// public propaty name  :  Ed_InventorySeqNo
        /// <summary>終了棚卸通番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了棚卸通番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_InventorySeqNo
        {
            get { return _ed_InventorySeqNo; }
            set { _ed_InventorySeqNo = value; }
        }

        /// public propaty name  :  St_BLGroupCode
        /// <summary>開始グループコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始グループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_BLGroupCode
        {
            get { return _st_BLGroupCode; }
            set { _st_BLGroupCode = value; }
        }

        /// public propaty name  :  Ed_BLGroupCode
        /// <summary>終了グループコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了グループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_BLGroupCode
        {
            get { return _ed_BLGroupCode; }
            set { _ed_BLGroupCode = value; }
        }

        /// public propaty name  :  DifCntExtraDiv
        /// <summary>差異分抽出区分プロパティ</summary>
        /// <value>0:全て,1:数未入力分のみ,2:数入力分のみ,3:差異分のみ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   差異分抽出区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DifCntExtraDiv
        {
            get { return _difCntExtraDiv; }
            set { _difCntExtraDiv = value; }
        }

        /// public propaty name  :  StockCntZeroExtraDiv
        /// <summary>在庫数0抽出区分プロパティ</summary>
        /// <value>0:抽出する,1:抽出しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫数0抽出区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockCntZeroExtraDiv
        {
            get { return _stockCntZeroExtraDiv; }
            set { _stockCntZeroExtraDiv = value; }
        }

        /// public propaty name  :  IvtStkCntZeroExtraDiv
        /// <summary>棚卸在庫数0抽出区分プロパティ</summary>
        /// <value>0:抽出する,1:抽出しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   棚卸在庫数0抽出区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 IvtStkCntZeroExtraDiv
        {
            get { return _ivtStkCntZeroExtraDiv; }
            set { _ivtStkCntZeroExtraDiv = value; }
        }

        /// public propaty name  :  SelectedPaperKind
        /// <summary>帳票種別プロパティ</summary>
        /// <value>0:棚卸記入表、1:棚卸差異表、2:棚卸表</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   帳票種別プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SelectedPaperKind
        {
            get { return _selectedPaperKind; }
            set { _selectedPaperKind = value; }
        }

        /// public propaty name  :  OutputAppointDiv
        /// <summary>出力指定区分プロパティ</summary>
        /// <value>0:全て,1:棚卸未入力分のみ,2:差異分のみ,3:重複棚番ありのみ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出力指定区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OutputAppointDiv
        {
            get { return _outputAppointDiv; }
            set { _outputAppointDiv = value; }
        }

        /// public propaty name  :  TargetDateExtraDiv
        /// <summary>抽出対象日付区分プロパティ</summary>
        /// <value>0:棚卸準備処理日,1:棚卸実施日,2:棚卸更新日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   抽出対象日付区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TargetDateExtraDiv
        {
            get { return _targetDateExtraDiv; }
            set { _targetDateExtraDiv = value; }
        }

        /// public propaty name  :  CalcStockAmountDiv
        /// <summary>在庫数算出フラグプロパティ</summary>
        /// <value>0:在庫数算出しない, 1:在庫数算出する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫数算出フラグプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CalcStockAmountDiv
        {
            get { return _calcStockAmountDiv; }
            set { _calcStockAmountDiv = value; }
        }

        /// public propaty name  :  CalcStockAmountDate
        /// <summary>在庫数算出日付プロパティ</summary>
        /// <value>在庫数算出フラグ=1のときの在庫数算出日付</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫数算出日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime CalcStockAmountDate
        {
            get { return _calcStockAmountDate; }
            set { _calcStockAmountDate = value; }
        }

        /// public propaty name  :  StockDiv
        /// <summary>在庫区分プロパティ</summary>
        /// <value>0:全て,1:自社,2:受託</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockDiv
        {
            get { return _stockDiv; }
            set { _stockDiv = value; }
        }

        /// public propaty name  :  LendExtraDiv
        /// <summary>貸出抽出区分プロパティ</summary>
        /// <value>0:印刷しない,1:印刷する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   貸出抽出区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 LendExtraDiv
        {
            get { return _lendExtraDiv; }
            set { _lendExtraDiv = value; }
        }

        /// public propaty name  :  DelayPaymentDiv
        /// <summary>来勘計上抽出区分プロパティ</summary>
        /// <value>0:印刷しない,1:印刷する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   来勘計上抽出区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DelayPaymentDiv
        {
            get { return _delayPaymentDiv; }
            set { _delayPaymentDiv = value; }
        }

        // -----------ADD 2011/01/11 ------------------>>>>>
        /// public propaty name  :  NumOutputDiv
        /// <summary>数量出力区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   数量出力区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 NumOutputDiv
        {
            get { return _numOutputDiv; }
            set { _numOutputDiv = value; }
        }

        /// public propaty name  :  NumOutputDiv
        /// <summary>棚番出力区分</summary>
        /// <remarks>0:全て出力,1:棚番なしのみ出力,2:棚番なし以外出力</remarks>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   棚番出力区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 WarehouseShelfOutputDiv
        {
            get { return _warehouseShelfOutputDiv; }
            set { _warehouseShelfOutputDiv = value; }
        }
        // -----------ADD 2011/01/11 ------------------<<<<<

        /// <summary>
        /// 棚卸検索抽出条件クラスワークコンストラクタ
        /// </summary>
        /// <returns>InventInputSearchCndtnWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   InventInputSearchCndtnWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public InventInputSearchCndtnWork()
        {
        }

    }
}

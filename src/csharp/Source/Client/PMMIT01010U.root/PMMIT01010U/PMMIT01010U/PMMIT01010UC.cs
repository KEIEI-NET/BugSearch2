using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Controller;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 検索見積 列情報初期設定クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 列情報の初期設定を行うクラスです。</br>
    /// <br>Programmer : 21024 佐々木 健</br>
    /// <br>Date       : 2008.07.10</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2009.06.18 21024 佐々木 健 MANTIS[0013553] 純優対比表示(在庫)の初期値で、優良の現在庫数が表示されるように修正</br>
    /// </remarks>
    internal class EstimateInputColInfoInitialSetting
    {
        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        #region ■Constructor
        /// <summary>
        /// コンストラクタ（Singletonデザインパターンを採用している為、private）
        /// </summary>
        private EstimateInputColInfoInitialSetting()
        {
            this._estimateInputConstructionAcs = EstimateInputConstructionAcs.GetInstance();
            this._estimateInputDataSet = new EstimateInputDataSet();
            this._estimateDetailDataTable = this._estimateInputDataSet.EstimateDetail;

            this.CreateDefaultDetailPattern();
            this._estimateInputConstructionAcs.EstimateDetailPatternInfoDetaultList = this._estimateDetailPatternInfoList;
            this._estimateInputConstructionAcs.ColDisplayBasicInfoList = this._colDisplayInfoList;
            this._estimateInputConstructionAcs.ColDisplayAddInfoDictionary = this._colDisplayAddInfoDictionary;
        }

        /// <summary>
        /// インスタンス取得処理
        /// </summary>
        /// <returns>検索見積 列情報初期設定インスタンス</returns>
        public static EstimateInputColInfoInitialSetting GetInstance()
        {
            if (_estimateInputColInfoInitialSetting == null)
            {
                _estimateInputColInfoInitialSetting = new EstimateInputColInfoInitialSetting();
            }

            return _estimateInputColInfoInitialSetting;
        }

        #endregion


        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        #region ■Private Member
        private static EstimateInputColInfoInitialSetting _estimateInputColInfoInitialSetting;

        private EstimateInputDataSet _estimateInputDataSet;
        private EstimateInputDataSet.EstimateDetailDataTable _estimateDetailDataTable;
        private EstimateInputConstructionAcs _estimateInputConstructionAcs;
        private List<ColDisplayBasicInfo> _colDisplayInfoList;
        private Dictionary<EstmDtlPtnInfo.SearchType, List<ColDisplayAddInfo>> _colDisplayAddInfoDictionary;
        private List<EstmDtlPtnInfo> _estimateDetailPatternInfoList;
        private Dictionary<string, ColDisplayBasicInfo> _colDisplayInfoBasicInfoDictionary;
        #endregion

        // ===================================================================================== //
        // 列挙体
        // ===================================================================================== //
        #region ■Enums

        #endregion

        // ===================================================================================== //
        // パブリックメソッド
        // ===================================================================================== //
        #region ■Public Methods

        /// <summary>
        /// カラムの属性取得
        /// </summary>
        /// <param name="key">キー</param>
        /// <returns>属性</returns>
        public ColDisplayBasicInfo.DataAttribute GetAttr(string key)
        {
            try
            {
                return this._colDisplayInfoBasicInfoDictionary[key].Attr;
            }
            catch (Exception)
            {
                return ColDisplayBasicInfo.DataAttribute.None;
            }
        }

        #endregion

        // ===================================================================================== //
        // プライベートメソッド
        // ===================================================================================== //
        #region ■Private Methods

        private void CreateDefaultDetailPattern()
        {
            int visiblePosition = 1;

            this._colDisplayInfoList = new List<ColDisplayBasicInfo>();
            this._colDisplayAddInfoDictionary = new Dictionary<EstmDtlPtnInfo.SearchType, List<ColDisplayAddInfo>>();

            // 表示する項目のリスト(表示項目を追加する場合はここに追加)
            this._colDisplayInfoList = new List<ColDisplayBasicInfo>();
            //-----<< 純正情報 >>-----//
            this._colDisplayInfoList.Add(new ColDisplayBasicInfo(this._estimateDetailDataTable.BLGoodsCodeColumn.ColumnName, this._estimateDetailDataTable.BLGoodsCodeColumn.Caption, false, ColDisplayBasicInfo.DataAttribute.PureParts));                                 // BLコード
            this._colDisplayInfoList.Add(new ColDisplayBasicInfo(this._estimateDetailDataTable.GoodsNameColumn.ColumnName, this._estimateDetailDataTable.GoodsNameColumn.Caption, false, ColDisplayBasicInfo.DataAttribute.PureParts));                                     // 品名
            this._colDisplayInfoList.Add(new ColDisplayBasicInfo(this._estimateDetailDataTable.GoodsNoColumn.ColumnName, this._estimateDetailDataTable.GoodsNoColumn.Caption, false, ColDisplayBasicInfo.DataAttribute.PureParts));                                         // 品番
            this._colDisplayInfoList.Add(new ColDisplayBasicInfo(this._estimateDetailDataTable.ShipmentCntColumn.ColumnName, this._estimateDetailDataTable.ShipmentCntColumn.Caption, false, ColDisplayBasicInfo.DataAttribute.PureParts));                                 // QTY
            this._colDisplayInfoList.Add(new ColDisplayBasicInfo(this._estimateDetailDataTable.ListPriceDisplayColumn.ColumnName, this._estimateDetailDataTable.ListPriceDisplayColumn.Caption, false, ColDisplayBasicInfo.DataAttribute.PureParts));                       // 定価
            this._colDisplayInfoList.Add(new ColDisplayBasicInfo(this._estimateDetailDataTable.OpenPriceDivDisplayColumn.ColumnName, this._estimateDetailDataTable.OpenPriceDivDisplayColumn.Caption, false, ColDisplayBasicInfo.DataAttribute.PureParts));                 // OP
            this._colDisplayInfoList.Add(new ColDisplayBasicInfo(this._estimateDetailDataTable.GoodsMakerCdColumn.ColumnName, this._estimateDetailDataTable.GoodsMakerCdColumn.Caption, false, ColDisplayBasicInfo.DataAttribute.PureParts));                               // メーカーコード
            this._colDisplayInfoList.Add(new ColDisplayBasicInfo(this._estimateDetailDataTable.MakerNameColumn.ColumnName, this._estimateDetailDataTable.MakerNameColumn.Caption, false, ColDisplayBasicInfo.DataAttribute.PureParts));                                     // メーカー名称
            this._colDisplayInfoList.Add(new ColDisplayBasicInfo(this._estimateDetailDataTable.WarehouseCodeColumn.ColumnName, this._estimateDetailDataTable.WarehouseCodeColumn.Caption, false, ColDisplayBasicInfo.DataAttribute.PureParts));                             // 倉庫
            this._colDisplayInfoList.Add(new ColDisplayBasicInfo(this._estimateDetailDataTable.WarehouseShelfNoColumn.ColumnName, this._estimateDetailDataTable.WarehouseShelfNoColumn.Caption, true, ColDisplayBasicInfo.DataAttribute.PureParts));                        // 棚番
            this._colDisplayInfoList.Add(new ColDisplayBasicInfo(this._estimateDetailDataTable.ShipmentPosCntColumn.ColumnName, this._estimateDetailDataTable.ShipmentPosCntColumn.Caption, true, ColDisplayBasicInfo.DataAttribute.PureParts));                            // 現在庫数
            this._colDisplayInfoList.Add(new ColDisplayBasicInfo(this._estimateDetailDataTable.ExistSetInfoDisplayColumn.ColumnName, this._estimateDetailDataTable.ExistSetInfoDisplayColumn.Caption, true, ColDisplayBasicInfo.DataAttribute.PureParts));                  // セット
            this._colDisplayInfoList.Add(new ColDisplayBasicInfo(this._estimateDetailDataTable.SupplierCdColumn.ColumnName, this._estimateDetailDataTable.SupplierCdColumn.Caption, false, ColDisplayBasicInfo.DataAttribute.PureParts));                                   // 仕入先
            this._colDisplayInfoList.Add(new ColDisplayBasicInfo(this._estimateDetailDataTable.PrintSelectColumn.ColumnName, this._estimateDetailDataTable.PrintSelectColumn.Caption, false, ColDisplayBasicInfo.DataAttribute.PureParts));                                 // 印刷
            this._colDisplayInfoList.Add(new ColDisplayBasicInfo(this._estimateDetailDataTable.OrderSelectColumn.ColumnName, this._estimateDetailDataTable.OrderSelectColumn.Caption, true, ColDisplayBasicInfo.DataAttribute.PureParts));                                  // 発注
            //-----<< 優良情報 >>-----//
            this._colDisplayInfoList.Add(new ColDisplayBasicInfo(this._estimateDetailDataTable.BLGoodsCode_PrimeColumn.ColumnName, this._estimateDetailDataTable.BLGoodsCode_PrimeColumn.Caption, false, ColDisplayBasicInfo.DataAttribute.PrimeParts));                    // BLコード（優良）
            this._colDisplayInfoList.Add(new ColDisplayBasicInfo(this._estimateDetailDataTable.GoodsName_PrimeColumn.ColumnName, this._estimateDetailDataTable.GoodsName_PrimeColumn.Caption, false, ColDisplayBasicInfo.DataAttribute.PrimeParts));                        // 品名（優良）
            this._colDisplayInfoList.Add(new ColDisplayBasicInfo(this._estimateDetailDataTable.GoodsNo_PrimeColumn.ColumnName, this._estimateDetailDataTable.GoodsNo_PrimeColumn.Caption, false, ColDisplayBasicInfo.DataAttribute.PrimeParts));                            // 品番（優良）
            this._colDisplayInfoList.Add(new ColDisplayBasicInfo(this._estimateDetailDataTable.ShipmentCnt_PrimeColumn.ColumnName, this._estimateDetailDataTable.ShipmentCnt_PrimeColumn.Caption, false, ColDisplayBasicInfo.DataAttribute.PrimeParts));                    // QTY（優良）
            this._colDisplayInfoList.Add(new ColDisplayBasicInfo(this._estimateDetailDataTable.ListPriceDisplay_PrimeColumn.ColumnName, this._estimateDetailDataTable.ListPriceDisplay_PrimeColumn.Caption, false, ColDisplayBasicInfo.DataAttribute.PrimeParts));          // 定価（優良）
            this._colDisplayInfoList.Add(new ColDisplayBasicInfo(this._estimateDetailDataTable.OpenPriceDivDisplay_PrimeColumn.ColumnName, this._estimateDetailDataTable.OpenPriceDivDisplay_PrimeColumn.Caption, false, ColDisplayBasicInfo.DataAttribute.PrimeParts));    // OP（優良）
            this._colDisplayInfoList.Add(new ColDisplayBasicInfo(this._estimateDetailDataTable.GoodsMakerCd_PrimeColumn.ColumnName, this._estimateDetailDataTable.GoodsMakerCd_PrimeColumn.Caption, false, ColDisplayBasicInfo.DataAttribute.PrimeParts));                  // メーカーコード（優良）
            this._colDisplayInfoList.Add(new ColDisplayBasicInfo(this._estimateDetailDataTable.MakerName_PrimeColumn.ColumnName, this._estimateDetailDataTable.MakerName_PrimeColumn.Caption, false, ColDisplayBasicInfo.DataAttribute.PrimeParts));                        // メーカー名称（優良）
            this._colDisplayInfoList.Add(new ColDisplayBasicInfo(this._estimateDetailDataTable.WarehouseCode_PrimeColumn.ColumnName, this._estimateDetailDataTable.WarehouseCode_PrimeColumn.Caption, false, ColDisplayBasicInfo.DataAttribute.PrimeParts));                // 倉庫（優良）
            this._colDisplayInfoList.Add(new ColDisplayBasicInfo(this._estimateDetailDataTable.WarehouseShelfNo_PrimeColumn.ColumnName, this._estimateDetailDataTable.WarehouseShelfNo_PrimeColumn.Caption, true, ColDisplayBasicInfo.DataAttribute.PrimeParts));           // 棚番（優良）
            this._colDisplayInfoList.Add(new ColDisplayBasicInfo(this._estimateDetailDataTable.ShipmentPosCnt_PrimeColumn.ColumnName, this._estimateDetailDataTable.ShipmentPosCnt_PrimeColumn.Caption, true, ColDisplayBasicInfo.DataAttribute.PrimeParts));               // 現在庫数（優良）
            this._colDisplayInfoList.Add(new ColDisplayBasicInfo(this._estimateDetailDataTable.ExistSetInfoDisplay_PrimeColumn.ColumnName, this._estimateDetailDataTable.ExistSetInfoDisplay_PrimeColumn.Caption, true, ColDisplayBasicInfo.DataAttribute.PrimeParts));     // セット（優良）
            this._colDisplayInfoList.Add(new ColDisplayBasicInfo(this._estimateDetailDataTable.SupplierCd_PrimeColumn.ColumnName, this._estimateDetailDataTable.SupplierCd_PrimeColumn.Caption, false, ColDisplayBasicInfo.DataAttribute.PrimeParts));                      // 仕入先（優良）
            this._colDisplayInfoList.Add(new ColDisplayBasicInfo(this._estimateDetailDataTable.PrintSelect_PrimeColumn.ColumnName, this._estimateDetailDataTable.PrintSelect_PrimeColumn.Caption, false, ColDisplayBasicInfo.DataAttribute.PrimeParts));                    // 印刷（優良）
            this._colDisplayInfoList.Add(new ColDisplayBasicInfo(this._estimateDetailDataTable.OrderSelect_PrimeColumn.ColumnName, this._estimateDetailDataTable.OrderSelect_PrimeColumn.Caption, true, ColDisplayBasicInfo.DataAttribute.PrimeParts));                     // 発注（優良）
            //-----<< その他 >>-----//
            this._colDisplayInfoList.Add(new ColDisplayBasicInfo(this._estimateDetailDataTable.JoinSourPartsNoWithHColumn.ColumnName, this._estimateDetailDataTable.JoinSourPartsNoWithHColumn.Caption, true, ColDisplayBasicInfo.DataAttribute.None));                     // 結合元品番
            this._colDisplayInfoList.Add(new ColDisplayBasicInfo(this._estimateDetailDataTable.CtlgPartsNoColumn.ColumnName, this._estimateDetailDataTable.CtlgPartsNoColumn.Caption, true, ColDisplayBasicInfo.DataAttribute.None));                                       // カタログ品番
            this._colDisplayInfoList.Add(new ColDisplayBasicInfo(this._estimateDetailDataTable.StandardNameColumn.ColumnName, this._estimateDetailDataTable.StandardNameColumn.Caption, true, ColDisplayBasicInfo.DataAttribute.None));                                     // 規格
            this._colDisplayInfoList.Add(new ColDisplayBasicInfo(this._estimateDetailDataTable.SpecialNoteColumn.ColumnName, this._estimateDetailDataTable.SpecialNoteColumn.Caption, true, ColDisplayBasicInfo.DataAttribute.None));                                       // 特記事項


            this._colDisplayInfoBasicInfoDictionary = new Dictionary<string, ColDisplayBasicInfo>();
            foreach (ColDisplayBasicInfo colDisplayBasicInfo in this._colDisplayInfoList)
            {
                _colDisplayInfoBasicInfoDictionary.Add(colDisplayBasicInfo.Key, colDisplayBasicInfo);
            }

            // 検索部品「純正」の項目制御リスト(このリストに含まれない場合は、表示、固定、移動はチェック無し)
            List<ColDisplayAddInfo> colDisplayInfoList_Pure = new List<ColDisplayAddInfo>();
            visiblePosition = 1;
            colDisplayInfoList_Pure.Add(new ColDisplayAddInfo(this._estimateDetailDataTable.BLGoodsCodeColumn.ColumnName, visiblePosition++, true, true, true));                    // BLコード
            colDisplayInfoList_Pure.Add(new ColDisplayAddInfo(this._estimateDetailDataTable.GoodsNameColumn.ColumnName, visiblePosition++, true, true, true));                      // 品名
            colDisplayInfoList_Pure.Add(new ColDisplayAddInfo(this._estimateDetailDataTable.GoodsNoColumn.ColumnName, visiblePosition++, true, true, true));                        // 品番
            colDisplayInfoList_Pure.Add(new ColDisplayAddInfo(this._estimateDetailDataTable.ShipmentCntColumn.ColumnName, visiblePosition++, false, true, true));                   // QTY
            colDisplayInfoList_Pure.Add(new ColDisplayAddInfo(this._estimateDetailDataTable.ListPriceDisplayColumn.ColumnName, visiblePosition++, false, true, true));              // 標準価格
            colDisplayInfoList_Pure.Add(new ColDisplayAddInfo(this._estimateDetailDataTable.OpenPriceDivDisplayColumn.ColumnName, visiblePosition++, false, true, false));          // OP
            colDisplayInfoList_Pure.Add(new ColDisplayAddInfo(this._estimateDetailDataTable.GoodsMakerCdColumn.ColumnName, visiblePosition++, false, true, true));                  // メーカーコード
            colDisplayInfoList_Pure.Add(new ColDisplayAddInfo(this._estimateDetailDataTable.MakerNameColumn.ColumnName, visiblePosition++, false, true, false));                    // メーカー名称
            colDisplayInfoList_Pure.Add(new ColDisplayAddInfo(this._estimateDetailDataTable.WarehouseCodeColumn.ColumnName, visiblePosition++, false, true, true));                 // 倉庫コード
            colDisplayInfoList_Pure.Add(new ColDisplayAddInfo(this._estimateDetailDataTable.WarehouseShelfNoColumn.ColumnName, visiblePosition++, false, true, false));             // 棚番
            colDisplayInfoList_Pure.Add(new ColDisplayAddInfo(this._estimateDetailDataTable.ShipmentPosCntColumn.ColumnName, visiblePosition++, false, true, false));               // 現在庫数
            colDisplayInfoList_Pure.Add(new ColDisplayAddInfo(this._estimateDetailDataTable.SupplierCdColumn.ColumnName, visiblePosition++, false, true, true));                    // 仕入先コード
            colDisplayInfoList_Pure.Add(new ColDisplayAddInfo(this._estimateDetailDataTable.PrintSelectColumn.ColumnName, visiblePosition++, false, true, true));                   // 印刷
            colDisplayInfoList_Pure.Add(new ColDisplayAddInfo(this._estimateDetailDataTable.ExistSetInfoDisplayColumn.ColumnName, visiblePosition++, false, true, false));          // セット
            colDisplayInfoList_Pure.Add(new ColDisplayAddInfo(this._estimateDetailDataTable.OrderSelectColumn.ColumnName, visiblePosition++, false, true, false));                  // 発注


            // 検索部品「優良」の項目制御リスト(このリストに含まれない場合は、表示、固定、移動はチェック無し)
            List<ColDisplayAddInfo> colDisplayInfoList_Prime = new List<ColDisplayAddInfo>();
            visiblePosition = 1;
            colDisplayInfoList_Prime.Add(new ColDisplayAddInfo(this._estimateDetailDataTable.BLGoodsCode_PrimeColumn.ColumnName, visiblePosition++, true, true, true));             // BLコード（優良）
            colDisplayInfoList_Prime.Add(new ColDisplayAddInfo(this._estimateDetailDataTable.GoodsName_PrimeColumn.ColumnName, visiblePosition++, true, true, true));               // 品名（優良）
            colDisplayInfoList_Prime.Add(new ColDisplayAddInfo(this._estimateDetailDataTable.GoodsNo_PrimeColumn.ColumnName, visiblePosition++, true, true, true));                 // 品番（優良）
            colDisplayInfoList_Prime.Add(new ColDisplayAddInfo(this._estimateDetailDataTable.ShipmentCnt_PrimeColumn.ColumnName, visiblePosition++, false, true, true));            // QTY（優良）
            colDisplayInfoList_Prime.Add(new ColDisplayAddInfo(this._estimateDetailDataTable.ListPriceDisplay_PrimeColumn.ColumnName, visiblePosition++, false, true, true));       // 標準価格（優良）
            colDisplayInfoList_Prime.Add(new ColDisplayAddInfo(this._estimateDetailDataTable.OpenPriceDivDisplay_PrimeColumn.ColumnName, visiblePosition++, false, true, false));   // OP（優良）
            colDisplayInfoList_Prime.Add(new ColDisplayAddInfo(this._estimateDetailDataTable.GoodsMakerCd_PrimeColumn.ColumnName, visiblePosition++, false, true, true));           // メーカーコード（優良）
            colDisplayInfoList_Prime.Add(new ColDisplayAddInfo(this._estimateDetailDataTable.MakerName_PrimeColumn.ColumnName, visiblePosition++, false, true, false));             // メーカー名称（優良）
            colDisplayInfoList_Prime.Add(new ColDisplayAddInfo(this._estimateDetailDataTable.WarehouseCode_PrimeColumn.ColumnName, visiblePosition++, false, true, true));          // 倉庫コード（優良）
            colDisplayInfoList_Prime.Add(new ColDisplayAddInfo(this._estimateDetailDataTable.WarehouseShelfNo_PrimeColumn.ColumnName, visiblePosition++, false, true, false));      // 棚番（優良）
            colDisplayInfoList_Prime.Add(new ColDisplayAddInfo(this._estimateDetailDataTable.ShipmentPosCnt_PrimeColumn.ColumnName, visiblePosition++, false, true, false));        // 現在庫数（優良）
            colDisplayInfoList_Prime.Add(new ColDisplayAddInfo(this._estimateDetailDataTable.SupplierCd_PrimeColumn.ColumnName, visiblePosition++, false, true, true));             // 仕入先コード（優良）
            colDisplayInfoList_Prime.Add(new ColDisplayAddInfo(this._estimateDetailDataTable.PrintSelect_PrimeColumn.ColumnName, visiblePosition++, false, true, true));            // 印刷（優良）
            colDisplayInfoList_Prime.Add(new ColDisplayAddInfo(this._estimateDetailDataTable.ExistSetInfoDisplay_PrimeColumn.ColumnName, visiblePosition++, false, true, false));   // セット（優良）
            colDisplayInfoList_Prime.Add(new ColDisplayAddInfo(this._estimateDetailDataTable.OrderSelect_PrimeColumn.ColumnName, visiblePosition++, false, true, false));           // 発注（優良）

            // 検索部品「無し(表示のみ)」の項目制御リスト
            List<ColDisplayAddInfo> colDisplayInfoList_None = new List<ColDisplayAddInfo>();

            this._colDisplayAddInfoDictionary.Add(EstmDtlPtnInfo.SearchType.Pure, colDisplayInfoList_Pure);
            this._colDisplayAddInfoDictionary.Add(EstmDtlPtnInfo.SearchType.Prime, colDisplayInfoList_Prime);
            this._colDisplayAddInfoDictionary.Add(EstmDtlPtnInfo.SearchType.None, colDisplayInfoList_None);

            int patternOrder = 1;

            // 明細パターンの初期値
            //-----<< 純正 >>-----//
            List<EstmDtlColInfo> estimateDetailColInfo_pure = new List<EstmDtlColInfo>();
            visiblePosition = 1;
            estimateDetailColInfo_pure.Add(new EstmDtlColInfo(this._estimateDetailDataTable.BLGoodsCodeColumn.ColumnName, visiblePosition++, true, true, true));                    // BLコード
            estimateDetailColInfo_pure.Add(new EstmDtlColInfo(this._estimateDetailDataTable.GoodsNameColumn.ColumnName, visiblePosition++, true, true, true));                      // 品名
            estimateDetailColInfo_pure.Add(new EstmDtlColInfo(this._estimateDetailDataTable.GoodsNoColumn.ColumnName, visiblePosition++, true, true, true));                        // 品番
            estimateDetailColInfo_pure.Add(new EstmDtlColInfo(this._estimateDetailDataTable.ShipmentCntColumn.ColumnName, visiblePosition++, true, false, true));                   // QTY
            estimateDetailColInfo_pure.Add(new EstmDtlColInfo(this._estimateDetailDataTable.ListPriceDisplayColumn.ColumnName, visiblePosition++, true, false, true));              // 標準価格
            estimateDetailColInfo_pure.Add(new EstmDtlColInfo(this._estimateDetailDataTable.OpenPriceDivDisplayColumn.ColumnName, visiblePosition++, true, false, false));          // OP
            estimateDetailColInfo_pure.Add(new EstmDtlColInfo(this._estimateDetailDataTable.GoodsMakerCdColumn.ColumnName, visiblePosition++, true, false, true));                  // メーカーコード
            estimateDetailColInfo_pure.Add(new EstmDtlColInfo(this._estimateDetailDataTable.MakerNameColumn.ColumnName, visiblePosition++, true, false, false));                    // メーカー名称
            estimateDetailColInfo_pure.Add(new EstmDtlColInfo(this._estimateDetailDataTable.WarehouseCodeColumn.ColumnName, visiblePosition++, true, false, true));                 // 倉庫コード
            estimateDetailColInfo_pure.Add(new EstmDtlColInfo(this._estimateDetailDataTable.WarehouseShelfNoColumn.ColumnName, visiblePosition++, true, false, false));             // 棚番
            estimateDetailColInfo_pure.Add(new EstmDtlColInfo(this._estimateDetailDataTable.ShipmentPosCntColumn.ColumnName, visiblePosition++, true, false, false));               // 現在庫数
            estimateDetailColInfo_pure.Add(new EstmDtlColInfo(this._estimateDetailDataTable.ExistSetInfoDisplayColumn.ColumnName, visiblePosition++, true, false, false));          // セット
            estimateDetailColInfo_pure.Add(new EstmDtlColInfo(this._estimateDetailDataTable.SupplierCdColumn.ColumnName, visiblePosition++, true, false, true));                    // 仕入先コード
            estimateDetailColInfo_pure.Add(new EstmDtlColInfo(this._estimateDetailDataTable.PrintSelectColumn.ColumnName, visiblePosition++, true, false, true));                   // 印刷
            estimateDetailColInfo_pure.Add(new EstmDtlColInfo(this._estimateDetailDataTable.OrderSelectColumn.ColumnName, visiblePosition++, true, false, false));                  // 発注

            EstmDtlPtnInfo estimateDetailPatternInfo_Pure = new EstmDtlPtnInfo(Guid.NewGuid(), "純正表示", patternOrder++, EstmDtlPtnInfo.SearchType.Pure, estimateDetailColInfo_pure);

            //-----<< 優良 >>-----//
            List<EstmDtlColInfo> estimateDetailColInfo_prime = new List<EstmDtlColInfo>();
            visiblePosition = 1;
            estimateDetailColInfo_prime.Add(new EstmDtlColInfo(this._estimateDetailDataTable.BLGoodsCode_PrimeColumn.ColumnName, visiblePosition++, true, true, true));             // BLコード（優良）
            estimateDetailColInfo_prime.Add(new EstmDtlColInfo(this._estimateDetailDataTable.GoodsName_PrimeColumn.ColumnName, visiblePosition++, true, true, true));               // 品名（優良）
            estimateDetailColInfo_prime.Add(new EstmDtlColInfo(this._estimateDetailDataTable.GoodsNo_PrimeColumn.ColumnName, visiblePosition++, true, true, true));                 // 品番（優良）
            estimateDetailColInfo_prime.Add(new EstmDtlColInfo(this._estimateDetailDataTable.ShipmentCnt_PrimeColumn.ColumnName, visiblePosition++, true, false, true));            // QTY（優良）
            estimateDetailColInfo_prime.Add(new EstmDtlColInfo(this._estimateDetailDataTable.ListPriceDisplay_PrimeColumn.ColumnName, visiblePosition++, true, false, true));       // 標準価格（優良）
            estimateDetailColInfo_prime.Add(new EstmDtlColInfo(this._estimateDetailDataTable.OpenPriceDivDisplay_PrimeColumn.ColumnName, visiblePosition++, true, false, false));   // OP（優良）
            estimateDetailColInfo_prime.Add(new EstmDtlColInfo(this._estimateDetailDataTable.GoodsMakerCd_PrimeColumn.ColumnName, visiblePosition++, true, false, true));           // メーカーコード（優良）
            estimateDetailColInfo_prime.Add(new EstmDtlColInfo(this._estimateDetailDataTable.MakerName_PrimeColumn.ColumnName, visiblePosition++, true, false, false));             // メーカー名称（優良）
            estimateDetailColInfo_prime.Add(new EstmDtlColInfo(this._estimateDetailDataTable.WarehouseCode_PrimeColumn.ColumnName, visiblePosition++, true, false, true));          // 倉庫コード（優良）
            estimateDetailColInfo_prime.Add(new EstmDtlColInfo(this._estimateDetailDataTable.WarehouseShelfNo_PrimeColumn.ColumnName, visiblePosition++, true, false, false));      // 棚番（優良）
            estimateDetailColInfo_prime.Add(new EstmDtlColInfo(this._estimateDetailDataTable.ShipmentPosCnt_PrimeColumn.ColumnName, visiblePosition++, true, false, false));        // 現在庫数（優良）
            estimateDetailColInfo_prime.Add(new EstmDtlColInfo(this._estimateDetailDataTable.ExistSetInfoDisplay_PrimeColumn.ColumnName, visiblePosition++, true, false, false));   // セット（優良）
            estimateDetailColInfo_prime.Add(new EstmDtlColInfo(this._estimateDetailDataTable.SupplierCd_PrimeColumn.ColumnName, visiblePosition++, true, false, true));             // 仕入先コード（優良）
            estimateDetailColInfo_prime.Add(new EstmDtlColInfo(this._estimateDetailDataTable.PrintSelect_PrimeColumn.ColumnName, visiblePosition++, true, false, true));            // 印刷（優良）
            estimateDetailColInfo_prime.Add(new EstmDtlColInfo(this._estimateDetailDataTable.OrderSelect_PrimeColumn.ColumnName, visiblePosition++, true, false, false));           // 発注（優良）

            EstmDtlPtnInfo estimateDetailPatternInfo_Prime = new EstmDtlPtnInfo(Guid.NewGuid(), "優良表示", patternOrder++, EstmDtlPtnInfo.SearchType.Prime, estimateDetailColInfo_prime);

            //-----<< 純・優対比（品番） >>-----//
            List<EstmDtlColInfo> estimateDetailColInfo_CompareGoodsNo = new List<EstmDtlColInfo>();
            visiblePosition = 1;
            estimateDetailColInfo_CompareGoodsNo.Add(new EstmDtlColInfo(this._estimateDetailDataTable.BLGoodsCodeColumn.ColumnName, visiblePosition++, true, true, true));                  // BLコード
            estimateDetailColInfo_CompareGoodsNo.Add(new EstmDtlColInfo(this._estimateDetailDataTable.GoodsNameColumn.ColumnName, visiblePosition++, true, true, true));                    // 品名
            estimateDetailColInfo_CompareGoodsNo.Add(new EstmDtlColInfo(this._estimateDetailDataTable.GoodsNoColumn.ColumnName, visiblePosition++, true, true, true));                      // 品番
            estimateDetailColInfo_CompareGoodsNo.Add(new EstmDtlColInfo(this._estimateDetailDataTable.ShipmentCntColumn.ColumnName, visiblePosition++, true, false, true));                 // QTY
            estimateDetailColInfo_CompareGoodsNo.Add(new EstmDtlColInfo(this._estimateDetailDataTable.ListPriceDisplayColumn.ColumnName, visiblePosition++, true, false, true));            // 標準価格
            estimateDetailColInfo_CompareGoodsNo.Add(new EstmDtlColInfo(this._estimateDetailDataTable.OpenPriceDivDisplayColumn.ColumnName, visiblePosition++, true, false, false));        // OP
            estimateDetailColInfo_CompareGoodsNo.Add(new EstmDtlColInfo(this._estimateDetailDataTable.PrintSelectColumn.ColumnName, visiblePosition++, true, false, true));                 // 印刷
            estimateDetailColInfo_CompareGoodsNo.Add(new EstmDtlColInfo(this._estimateDetailDataTable.GoodsNo_PrimeColumn.ColumnName, visiblePosition++, true, false, true));               // 品番（優良）
            estimateDetailColInfo_CompareGoodsNo.Add(new EstmDtlColInfo(this._estimateDetailDataTable.ShipmentCnt_PrimeColumn.ColumnName, visiblePosition++, true, false, true));           // QTY（優良）
            estimateDetailColInfo_CompareGoodsNo.Add(new EstmDtlColInfo(this._estimateDetailDataTable.ListPriceDisplay_PrimeColumn.ColumnName, visiblePosition++, true, false, true));      // 標準価格（優良）
            estimateDetailColInfo_CompareGoodsNo.Add(new EstmDtlColInfo(this._estimateDetailDataTable.OpenPriceDivDisplay_PrimeColumn.ColumnName, visiblePosition++, true, false, false));  // OP（優良）
            estimateDetailColInfo_CompareGoodsNo.Add(new EstmDtlColInfo(this._estimateDetailDataTable.PrintSelect_PrimeColumn.ColumnName, visiblePosition++, true, false, true));           // 印刷（優良）

            EstmDtlPtnInfo estimateDetailPatternInfo_CompareGoodsNo = new EstmDtlPtnInfo(Guid.NewGuid(), "純・優対比（品番）", patternOrder++, EstmDtlPtnInfo.SearchType.Pure, estimateDetailColInfo_CompareGoodsNo);

            //-----<< 純・優対比（在庫） >>-----//
            List<EstmDtlColInfo> estimateDetailColInfo_CompareStock = new List<EstmDtlColInfo>();
            visiblePosition = 1;
            estimateDetailColInfo_CompareStock.Add(new EstmDtlColInfo(this._estimateDetailDataTable.BLGoodsCodeColumn.ColumnName, visiblePosition++, true, true, true));                    // BLコード
            estimateDetailColInfo_CompareStock.Add(new EstmDtlColInfo(this._estimateDetailDataTable.GoodsNameColumn.ColumnName, visiblePosition++, true, true, true));                      // 品名
            estimateDetailColInfo_CompareStock.Add(new EstmDtlColInfo(this._estimateDetailDataTable.GoodsNoColumn.ColumnName, visiblePosition++, true, true, true));                        // 品番
            estimateDetailColInfo_CompareStock.Add(new EstmDtlColInfo(this._estimateDetailDataTable.ShipmentPosCntColumn.ColumnName, visiblePosition++, true, false, false));               // 現在庫数
            estimateDetailColInfo_CompareStock.Add(new EstmDtlColInfo(this._estimateDetailDataTable.WarehouseShelfNoColumn.ColumnName, visiblePosition++, true, false, false));             // 棚番
            estimateDetailColInfo_CompareStock.Add(new EstmDtlColInfo(this._estimateDetailDataTable.PrintSelectColumn.ColumnName, visiblePosition++, true, false, true));                   // 印刷
            estimateDetailColInfo_CompareStock.Add(new EstmDtlColInfo(this._estimateDetailDataTable.GoodsNo_PrimeColumn.ColumnName, visiblePosition++, true, false, true));                 // 品番（優良）
            // 2009.06.18 >>>
            //estimateDetailColInfo_CompareStock.Add(new EstmDtlColInfo(this._estimateDetailDataTable.ShipmentCnt_PrimeColumn.ColumnName, visiblePosition++, true, false, false));            // 現在庫数（優良）
            estimateDetailColInfo_CompareStock.Add(new EstmDtlColInfo(this._estimateDetailDataTable.ShipmentPosCnt_PrimeColumn.ColumnName, visiblePosition++, true, false, false));            // 現在庫数（優良）
            // 2009.06.18 <<<
            estimateDetailColInfo_CompareStock.Add(new EstmDtlColInfo(this._estimateDetailDataTable.WarehouseShelfNo_PrimeColumn.ColumnName, visiblePosition++, true, false, false));       // 棚番（優良）
            estimateDetailColInfo_CompareStock.Add(new EstmDtlColInfo(this._estimateDetailDataTable.PrintSelect_PrimeColumn.ColumnName, visiblePosition++, true, false, true));             // 印刷（優良）

            EstmDtlPtnInfo estimateDetailPatternInfo_CompareStock = new EstmDtlPtnInfo(Guid.NewGuid(), "純・優対比（在庫）", patternOrder++, EstmDtlPtnInfo.SearchType.Pure, estimateDetailColInfo_CompareStock);

            //-----<< 純・優対比（メーカー） >>-----//
            List<EstmDtlColInfo> estimateDetailColInfo_CompareMaker = new List<EstmDtlColInfo>();
            visiblePosition = 1;
            estimateDetailColInfo_CompareMaker.Add(new EstmDtlColInfo(this._estimateDetailDataTable.BLGoodsCodeColumn.ColumnName, visiblePosition++, true, true, true));                    // BLコード
            estimateDetailColInfo_CompareMaker.Add(new EstmDtlColInfo(this._estimateDetailDataTable.GoodsNameColumn.ColumnName, visiblePosition++, true, true, true));                      // 品名
            estimateDetailColInfo_CompareMaker.Add(new EstmDtlColInfo(this._estimateDetailDataTable.GoodsNoColumn.ColumnName, visiblePosition++, true, true, true));                        // 品番
            estimateDetailColInfo_CompareMaker.Add(new EstmDtlColInfo(this._estimateDetailDataTable.ShipmentCntColumn.ColumnName, visiblePosition++, true, false, true));                   // QTY
            estimateDetailColInfo_CompareMaker.Add(new EstmDtlColInfo(this._estimateDetailDataTable.GoodsMakerCdColumn.ColumnName, visiblePosition++, true, false, true));                  // メーカーコード
            estimateDetailColInfo_CompareMaker.Add(new EstmDtlColInfo(this._estimateDetailDataTable.MakerNameColumn.ColumnName, visiblePosition++, true, false, false));                    // メーカー名称
            estimateDetailColInfo_CompareMaker.Add(new EstmDtlColInfo(this._estimateDetailDataTable.PrintSelectColumn.ColumnName, visiblePosition++, true, false, true));                   // 印刷
            estimateDetailColInfo_CompareMaker.Add(new EstmDtlColInfo(this._estimateDetailDataTable.GoodsNo_PrimeColumn.ColumnName, visiblePosition++, true, false, true));                 // 品番（優良）
            estimateDetailColInfo_CompareMaker.Add(new EstmDtlColInfo(this._estimateDetailDataTable.ShipmentCnt_PrimeColumn.ColumnName, visiblePosition++, true, false, true));             // QTY（優良）
            estimateDetailColInfo_CompareMaker.Add(new EstmDtlColInfo(this._estimateDetailDataTable.GoodsMakerCd_PrimeColumn.ColumnName, visiblePosition++, true, false, true));            // メーカーコード（優良）
            estimateDetailColInfo_CompareMaker.Add(new EstmDtlColInfo(this._estimateDetailDataTable.MakerName_PrimeColumn.ColumnName, visiblePosition++, true, false, false));              // メーカー名称（優良）
            estimateDetailColInfo_CompareMaker.Add(new EstmDtlColInfo(this._estimateDetailDataTable.PrintSelect_PrimeColumn.ColumnName, visiblePosition++, true, false, true));             // 印刷(優良)

            EstmDtlPtnInfo estimateDetailPatternInfo_CompareMaker = new EstmDtlPtnInfo(Guid.NewGuid(), "純・優対比（メーカー）", patternOrder++, EstmDtlPtnInfo.SearchType.Pure, estimateDetailColInfo_CompareMaker);


            //-----<< 結合情報 >>-----//
            List<EstmDtlColInfo> estimateDetailColInfo_PartsJoinInfo = new List<EstmDtlColInfo>();
            visiblePosition = 1;
            estimateDetailColInfo_PartsJoinInfo.Add(new EstmDtlColInfo(this._estimateDetailDataTable.BLGoodsCodeColumn.ColumnName, visiblePosition++, true, true, false));                  // BLコード
            estimateDetailColInfo_PartsJoinInfo.Add(new EstmDtlColInfo(this._estimateDetailDataTable.GoodsNameColumn.ColumnName, visiblePosition++, true, true, false));                    // 品名
            estimateDetailColInfo_PartsJoinInfo.Add(new EstmDtlColInfo(this._estimateDetailDataTable.GoodsNo_PrimeColumn.ColumnName, visiblePosition++, true, true, false));                // 優良品番
            estimateDetailColInfo_PartsJoinInfo.Add(new EstmDtlColInfo(this._estimateDetailDataTable.JoinSourPartsNoWithHColumn.ColumnName, visiblePosition++, true, true, false));         // 結合元品番
            estimateDetailColInfo_PartsJoinInfo.Add(new EstmDtlColInfo(this._estimateDetailDataTable.CtlgPartsNoColumn.ColumnName, visiblePosition++, true, true, false));                  // カタログ品番


            EstmDtlPtnInfo estimateDetailPatternInfo_PartsJoinInfo = new EstmDtlPtnInfo(Guid.NewGuid(), "結合情報", patternOrder++, EstmDtlPtnInfo.SearchType.None, estimateDetailColInfo_PartsJoinInfo);

            //-----<< オプション/規格 >>-----//
            List<EstmDtlColInfo> estimateDetailColInfo_OptionInfo = new List<EstmDtlColInfo>();
            visiblePosition = 1;
            estimateDetailColInfo_OptionInfo.Add(new EstmDtlColInfo(this._estimateDetailDataTable.BLGoodsCodeColumn.ColumnName, visiblePosition++, true, true, false));                     // BLコード
            estimateDetailColInfo_OptionInfo.Add(new EstmDtlColInfo(this._estimateDetailDataTable.GoodsNameColumn.ColumnName, visiblePosition++, true, true, false));                       // 品名
            estimateDetailColInfo_OptionInfo.Add(new EstmDtlColInfo(this._estimateDetailDataTable.GoodsNoColumn.ColumnName, visiblePosition++, true, true, false));                         // 品番
            estimateDetailColInfo_OptionInfo.Add(new EstmDtlColInfo(this._estimateDetailDataTable.ShipmentCntColumn.ColumnName, visiblePosition++, true, true, false));                     // QTY
            estimateDetailColInfo_OptionInfo.Add(new EstmDtlColInfo(this._estimateDetailDataTable.ListPriceDisplayColumn.ColumnName, visiblePosition++, true, true, false));                // 標準価格
            estimateDetailColInfo_OptionInfo.Add(new EstmDtlColInfo(this._estimateDetailDataTable.OpenPriceDivDisplayColumn.ColumnName, visiblePosition++, true, true, false));             // OP
            estimateDetailColInfo_OptionInfo.Add(new EstmDtlColInfo(this._estimateDetailDataTable.SpecialNoteColumn.ColumnName, visiblePosition++, true, false, false));                    // 特記事項
            estimateDetailColInfo_OptionInfo.Add(new EstmDtlColInfo(this._estimateDetailDataTable.StandardNameColumn.ColumnName, visiblePosition++, true, false, false));                   // 規格

            EstmDtlPtnInfo estimateDetailPatternInfo_OptionInfo = new EstmDtlPtnInfo(Guid.NewGuid(), "規格/オプション情報", patternOrder++, EstmDtlPtnInfo.SearchType.None, estimateDetailColInfo_OptionInfo);


            this._estimateDetailPatternInfoList = new List<EstmDtlPtnInfo>();
            this._estimateDetailPatternInfoList.Add(estimateDetailPatternInfo_Pure);
            this._estimateDetailPatternInfoList.Add(estimateDetailPatternInfo_Prime);
            this._estimateDetailPatternInfoList.Add(estimateDetailPatternInfo_CompareGoodsNo);
            this._estimateDetailPatternInfoList.Add(estimateDetailPatternInfo_CompareStock);
            this._estimateDetailPatternInfoList.Add(estimateDetailPatternInfo_CompareMaker);
            this._estimateDetailPatternInfoList.Add(estimateDetailPatternInfo_PartsJoinInfo);
            this._estimateDetailPatternInfoList.Add(estimateDetailPatternInfo_OptionInfo);
        }

        #endregion
    }
}

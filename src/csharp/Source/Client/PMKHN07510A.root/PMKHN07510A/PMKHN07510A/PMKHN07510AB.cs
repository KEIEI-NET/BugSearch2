using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// メール初期値データ用のデータコンバートクラス
    /// </summary>
    public static class MailDefaultDataConverter
    {
        #region ■ ヘッダデータ用

        #region ○ 売上データ（UI）
        /// <summary>
        /// メール初期値ヘッダデータへの変換（売上データ(UI)用）
        /// </summary>
        /// <param name="src">売上データオブジェクト</param>
        /// <returns></returns>
        public static MailDefaultHeader ConverToMailDefaultHeader(SalesSlip src)
        {
            MailDefaultHeader header = new MailDefaultHeader();

            #region 項目コピー

            header.AcptAnOdrStatus = src.AcptAnOdrStatus; // 受注ステータス
            header.SalesSlipNum = src.SalesSlipNum; // 売上伝票番号
            header.SectionCode = src.SectionCode; // 拠点コード
            header.SubSectionCode = src.SubSectionCode; // 部門コード
            header.DebitNoteDiv = src.DebitNoteDiv; // 赤伝区分
            header.SalesSlipCd = src.SalesSlipCd; // 売上伝票区分
            header.AccRecDivCd = src.AccRecDivCd; // 売掛区分
            header.SalesInpSecCd = src.SalesInpSecCd; // 売上入力拠点コード
            header.DemandAddUpSecCd = src.DemandAddUpSecCd; // 請求計上拠点コード
            header.ResultsAddUpSecCd = src.ResultsAddUpSecCd; // 実績計上拠点コード
            header.UpdateSecCd = src.UpdateSecCd; // 更新拠点コード
            header.ShipmentDay = src.ShipmentDay; // 出荷日付
            header.SalesDate = src.SalesDate; // 売上日付
            header.AddUpADate = src.AddUpADate; // 計上日付
            header.EstimateDivide = src.EstimateDivide; // 見積区分
            header.InputAgenCd = src.InputAgenCd; // 入力担当者コード
            header.InputAgenNm = src.InputAgenNm; // 入力担当者名称
            header.SalesInputCode = src.SalesInputCode; // 売上入力者コード
            header.FrontEmployeeCd = src.FrontEmployeeCd; // 受付従業員コード
            header.SalesEmployeeCd = src.SalesEmployeeCd; // 販売従業員コード
            header.TotalAmountDispWayCd = src.TotalAmountDispWayCd; // 総額表示方法区分
            header.TotalCost = src.TotalCost; // 原価金額計
            header.ConsTaxLayMethod = src.ConsTaxLayMethod; // 消費税転嫁方式
            header.ClaimCode = src.ClaimCode; // 請求先コード
            header.CustomerCode = src.CustomerCode; // 得意先コード
            header.CustomerName = src.CustomerName; // 得意先名称
            header.CustomerName2 = src.CustomerName2; // 得意先名称2
            header.CustomerSnm = src.CustomerSnm; // 得意先略称
            header.HonorificTitle = src.HonorificTitle; // 敬称
            header.CustSlipNo = src.CustSlipNo; // 得意先伝票番号
            header.SlipAddressDiv = src.SlipAddressDiv; // 伝票住所区分
            header.AddresseeCode = src.AddresseeCode; // 納品先コード
            header.AddresseeName = src.AddresseeName; // 納品先名称
            header.AddresseeName2 = src.AddresseeName2; // 納品先名称2
            header.AddresseePostNo = src.AddresseePostNo; // 納品先郵便番号
            header.AddresseeAddr1 = src.AddresseeAddr1; // 納品先住所1（都道府県市区郡・町村・字）
            header.AddresseeAddr3 = src.AddresseeAddr3; // 納品先住所3（番地）
            header.AddresseeAddr4 = src.AddresseeAddr4; // 納品先住所4（アパート名称）
            header.AddresseeTelNo = src.AddresseeTelNo; // 納品先電話番号
            header.AddresseeFaxNo = src.AddresseeFaxNo; // 納品先FAX番号
            header.PartySaleSlipNum = src.PartySaleSlipNum; // 相手先伝票番号
            header.SlipNote = src.SlipNote; // 伝票備考
            header.SlipNote2 = src.SlipNote2; // 伝票備考２
            header.SlipNote3 = src.SlipNote3; // 伝票備考３
            header.RetGoodsReasonDiv = src.RetGoodsReasonDiv; // 返品理由コード
            header.RetGoodsReason = src.RetGoodsReason; // 返品理由
            header.BusinessTypeCode = src.BusinessTypeCode; // 業種コード
            header.DeliveredGoodsDiv = src.DeliveredGoodsDiv; // 納品区分
            header.SalesAreaCode = src.SalesAreaCode; // 販売エリアコード
            header.EraNameDispCd1 = src.EraNameDispCd1; // 元号表示区分１

            #endregion

            #region 合計金額

            if (src.TotalAmountDispWayCd == 0)
            {
                switch (src.ConsTaxLayMethod)
                {
                    case 0: // 伝票転嫁
                    case 1: // 明細転嫁
                        // 売上合計金額(税抜き)
                        header.SalesTotalPriceTaxExc = src.SalesTotalTaxExc;

                        // 売上消費税（合計）
                        header.SalesPriceConsTaxTotal = src.SalesSubtotalTax;

                        // 売上合計金額（税込み）
                        header.SalesTotalPrice = src.SalesTotalTaxInc; 

                        break;

                    case 2: // 請求親
                    case 3: // 請求子
                    case 9: // 非課税
                        // 売上合計金額(税抜き)
                        header.SalesTotalPriceTaxExc = 
                            src.ItdedSalesInTax + 
                            src.ItdedSalesOutTax + 
                            src.SalSubttlSubToTaxFre +
                            src.ItdedSalesDisOutTax +
                            src.ItdedSalesDisInTax + 
                            src.ItdedSalesDisTaxFre;

                        // 売上消費税（合計）
                        header.SalesPriceConsTaxTotal = src.SalAmntConsTaxInclu + src.SalesDisTtlTaxInclu;

                        // 売上合計金額（税込み）
                        header.SalesTotalPrice = 
                            src.ItdedSalesInTax + 
                            src.ItdedSalesOutTax + 
                            src.SalSubttlSubToTaxFre +
                            src.ItdedSalesDisOutTax + 
                            src.ItdedSalesDisInTax + 
                            src.ItdedSalesDisTaxFre +
                            src.SalAmntConsTaxInclu + 
                            src.SalesDisTtlTaxInclu;

                        break;
                }
            }
            else
            {
                // 売上合計金額(税抜き)
                header.SalesTotalPriceTaxExc = src.SalesTotalTaxInc;
                
                // 売上消費税（合計）
                header.SalesPriceConsTaxTotal = src.SalesSubtotalTax;
                
                // 売上合計金額（税込み）
                header.SalesTotalPrice = src.SalesTotalTaxInc;
            }

            #endregion

            return header;
        }
        #endregion

        #region ○ 売上データ（リモート）
        /// <summary>
        /// メール初期値ヘッダデータへの変換（売上データ(リモート)用）
        /// </summary>
        /// <param name="src">売上データ リモートオブジェクト</param>
        /// <returns></returns>
        public static MailDefaultHeader ConverToMailDefaultHeader(SalesSlipWork src)
        {
            MailDefaultHeader header = new MailDefaultHeader();

            #region 項目コピー

            header.AcptAnOdrStatus = src.AcptAnOdrStatus; // 受注ステータス
            header.SalesSlipNum = src.SalesSlipNum; // 売上伝票番号
            header.SectionCode = src.SectionCode; // 拠点コード
            header.SubSectionCode = src.SubSectionCode; // 部門コード
            header.DebitNoteDiv = src.DebitNoteDiv; // 赤伝区分
            header.SalesSlipCd = src.SalesSlipCd; // 売上伝票区分
            header.AccRecDivCd = src.AccRecDivCd; // 売掛区分
            header.SalesInpSecCd = src.SalesInpSecCd; // 売上入力拠点コード
            header.DemandAddUpSecCd = src.DemandAddUpSecCd; // 請求計上拠点コード
            header.ResultsAddUpSecCd = src.ResultsAddUpSecCd; // 実績計上拠点コード
            header.UpdateSecCd = src.UpdateSecCd; // 更新拠点コード
            header.ShipmentDay = src.ShipmentDay; // 出荷日付
            header.SalesDate = src.SalesDate; // 売上日付
            header.AddUpADate = src.AddUpADate; // 計上日付
            header.EstimateDivide = src.EstimateDivide; // 見積区分
            header.InputAgenCd = src.InputAgenCd; // 入力担当者コード
            header.InputAgenNm = src.InputAgenNm; // 入力担当者名称
            header.SalesInputCode = src.SalesInputCode; // 売上入力者コード
            header.FrontEmployeeCd = src.FrontEmployeeCd; // 受付従業員コード
            header.SalesEmployeeCd = src.SalesEmployeeCd; // 販売従業員コード
            header.TotalAmountDispWayCd = src.TotalAmountDispWayCd; // 総額表示方法区分
            header.TotalCost = src.TotalCost; // 原価金額計
            header.ConsTaxLayMethod = src.ConsTaxLayMethod; // 消費税転嫁方式
            header.ClaimCode = src.ClaimCode; // 請求先コード
            header.CustomerCode = src.CustomerCode; // 得意先コード
            header.CustomerName = src.CustomerName; // 得意先名称
            header.CustomerName2 = src.CustomerName2; // 得意先名称2
            header.CustomerSnm = src.CustomerSnm; // 得意先略称
            header.HonorificTitle = src.HonorificTitle; // 敬称
            header.CustSlipNo = src.CustSlipNo; // 得意先伝票番号
            header.SlipAddressDiv = src.SlipAddressDiv; // 伝票住所区分
            header.AddresseeCode = src.AddresseeCode; // 納品先コード
            header.AddresseeName = src.AddresseeName; // 納品先名称
            header.AddresseeName2 = src.AddresseeName2; // 納品先名称2
            header.AddresseePostNo = src.AddresseePostNo; // 納品先郵便番号
            header.AddresseeAddr1 = src.AddresseeAddr1; // 納品先住所1（都道府県市区郡・町村・字）
            header.AddresseeAddr3 = src.AddresseeAddr3; // 納品先住所3（番地）
            header.AddresseeAddr4 = src.AddresseeAddr4; // 納品先住所4（アパート名称）
            header.AddresseeTelNo = src.AddresseeTelNo; // 納品先電話番号
            header.AddresseeFaxNo = src.AddresseeFaxNo; // 納品先FAX番号
            header.PartySaleSlipNum = src.PartySaleSlipNum; // 相手先伝票番号
            header.SlipNote = src.SlipNote; // 伝票備考
            header.SlipNote2 = src.SlipNote2; // 伝票備考２
            header.SlipNote3 = src.SlipNote3; // 伝票備考３
            header.RetGoodsReasonDiv = src.RetGoodsReasonDiv; // 返品理由コード
            header.RetGoodsReason = src.RetGoodsReason; // 返品理由
            header.BusinessTypeCode = src.BusinessTypeCode; // 業種コード
            header.DeliveredGoodsDiv = src.DeliveredGoodsDiv; // 納品区分
            header.SalesAreaCode = src.SalesAreaCode; // 販売エリアコード
            header.EraNameDispCd1 = src.EraNameDispCd1; // 元号表示区分１

            #endregion

            #region 合計金額

            if (src.TotalAmountDispWayCd == 0)
            {
                switch (src.ConsTaxLayMethod)
                {
                    case 0: // 伝票転嫁
                    case 1: // 明細転嫁
                        // 売上合計金額(税抜き)
                        header.SalesTotalPriceTaxExc = src.SalesTotalTaxExc;

                        // 売上消費税（合計）
                        header.SalesPriceConsTaxTotal = src.SalesSubtotalTax;

                        // 売上合計金額（税込み）
                        header.SalesTotalPrice = src.SalesTotalTaxInc;

                        break;

                    case 2: // 請求親
                    case 3: // 請求子
                    case 9: // 非課税
                        // 売上合計金額(税抜き)
                        header.SalesTotalPriceTaxExc =
                            src.ItdedSalesInTax +
                            src.ItdedSalesOutTax +
                            src.SalSubttlSubToTaxFre +
                            src.ItdedSalesDisOutTax +
                            src.ItdedSalesDisInTax +
                            src.ItdedSalesDisTaxFre;

                        // 売上消費税（合計）
                        header.SalesPriceConsTaxTotal = src.SalAmntConsTaxInclu + src.SalesDisTtlTaxInclu;

                        // 売上合計金額（税込み）
                        header.SalesTotalPrice =
                            src.ItdedSalesInTax +
                            src.ItdedSalesOutTax +
                            src.SalSubttlSubToTaxFre +
                            src.ItdedSalesDisOutTax +
                            src.ItdedSalesDisInTax +
                            src.ItdedSalesDisTaxFre +
                            src.SalAmntConsTaxInclu +
                            src.SalesDisTtlTaxInclu;

                        break;
                }
            }
            else
            {
                // 売上合計金額(税抜き)
                header.SalesTotalPriceTaxExc = src.SalesTotalTaxInc;

                // 売上消費税（合計）
                header.SalesPriceConsTaxTotal = src.SalesSubtotalTax;

                // 売上合計金額（税込み）
                header.SalesTotalPrice = src.SalesTotalTaxInc;
            }

            #endregion

            return header;
        }
        #endregion

        #endregion

        #region 明細データ用

        /// <summary>
        /// メール初期値明細データへの変換（売上明細データ(UI)用）
        /// </summary>
        /// <param name="src">売上明細データオブジェクト</param>
        /// <returns></returns>
        public static MailDefaultDetail ConverToMailDefaultDetail(SalesDetail src)
        {
            MailDefaultDetail detail = new MailDefaultDetail();

            #region 項目コピー

            detail.SalesRowNo = src.SalesRowNo; // 売上行番号
            detail.SalesRowDerivNo = src.SalesRowDerivNo; // 売上行番号枝番
            detail.DeliGdsCmpltDueDate = src.DeliGdsCmpltDueDate; // 納品完了予定日
            detail.GoodsKindCode = src.GoodsKindCode; // 商品属性
            detail.GoodsMakerCd = src.GoodsMakerCd; // 商品メーカーコード
            detail.MakerName = src.MakerName; // メーカー名称
            detail.GoodsNo = src.GoodsNo; // 商品番号
            detail.GoodsName = src.GoodsName; // 商品名称
            detail.BLGoodsCode = src.BLGoodsCode; // BL商品コード
            detail.BLGoodsFullName = src.BLGoodsFullName; // BL商品コード名称（全角）
            detail.EnterpriseGanreCode = src.EnterpriseGanreCode; // 自社分類コード
            detail.EnterpriseGanreName = src.EnterpriseGanreName; // 自社分類名称
            detail.WarehouseCode = src.WarehouseCode; // 倉庫コード
            detail.WarehouseName = src.WarehouseName; // 倉庫名称
            detail.WarehouseShelfNo = src.WarehouseShelfNo; // 倉庫棚番
            detail.SalesOrderDivCd = src.SalesOrderDivCd; // 売上在庫取寄せ区分
            detail.OpenPriceDiv = src.OpenPriceDiv; // オープン価格区分
            detail.ListPriceRate = src.ListPriceRate; // 定価率
            detail.ListPriceTaxIncFl = src.ListPriceTaxIncFl; // 定価（税込，浮動）
            detail.ListPriceTaxExcFl = src.ListPriceTaxExcFl; // 定価（税抜，浮動）
            detail.SalesRate = src.SalesRate; // 売価率
            detail.SalesUnPrcTaxIncFl = src.SalesUnPrcTaxIncFl; // 売上単価（税込，浮動）
            detail.SalesUnPrcTaxExcFl = src.SalesUnPrcTaxExcFl; // 売上単価（税抜，浮動）
            detail.SalesUnitCost = src.SalesUnitCost; // 原価単価
            detail.PrtBLGoodsCode = src.PrtBLGoodsCode; // BL商品コード（印刷）
            detail.PrtBLGoodsName = src.PrtBLGoodsName; // BL商品コード名称（印刷）
            detail.SalesCode = src.SalesCode; // 販売区分コード
            detail.SalesCdNm = src.SalesCdNm; // 販売区分名称
            detail.WorkManHour = src.WorkManHour; // 作業工数
            detail.ShipmentCnt = src.ShipmentCnt; // 出荷数
            detail.SalesMoneyTaxInc = src.SalesMoneyTaxInc; // 売上金額（税込み）
            detail.SalesMoneyTaxExc = src.SalesMoneyTaxExc; // 売上金額（税抜き）
            detail.Cost = src.Cost; // 原価
            detail.SalesGoodsCd = src.SalesGoodsCd; // 売上商品区分
            detail.SalesPriceConsTax = src.SalesPriceConsTax; // 売上金額消費税額
            detail.TaxationDivCd = src.TaxationDivCd; // 課税区分
            detail.PartySlipNumDtl = src.PartySlipNumDtl; // 相手先伝票番号（明細）
            detail.SupplierCd = src.SupplierCd; // 仕入先コード
            detail.SupplierSnm = src.SupplierSnm; // 仕入先略称
            detail.OrderNumber = src.OrderNumber; // 発注番号
            detail.WayToOrder = src.WayToOrder; // 注文方法
            detail.PrtGoodsNo = src.PrtGoodsNo; // 印刷用商品番号
            detail.PrtMakerCode = src.PrtMakerCode; // 印刷用メーカーコード
            detail.PrtMakerName = src.PrtMakerName; // 印刷用メーカー名称
            //detail.CampaignCode = src.CampaignCode; // キャンペーンコード
            //detail.CampaignName = src.CampaignName; // キャンペーン名称
            //detail.GoodsDivCd = src.GoodsDivCd; // 商品種別
            //detail.AnswerDelivDate = src.AnswerDelivDate; // 回答納期


            #endregion

            return detail;
        }

        /// <summary>
        /// メール初期値明細データへの変換（売上明細データ(リモート)用）
        /// </summary>
        /// <param name="src">売上明細データ リモートオブジェクト</param>
        /// <returns></returns>
        public static MailDefaultDetail ConverToMailDefaultDetail(SalesDetailWork src)
        {
            MailDefaultDetail detail = new MailDefaultDetail();

            #region 項目コピー

            detail.SalesRowNo = src.SalesRowNo; // 売上行番号
            detail.SalesRowDerivNo = src.SalesRowDerivNo; // 売上行番号枝番
            detail.DeliGdsCmpltDueDate = src.DeliGdsCmpltDueDate; // 納品完了予定日
            detail.GoodsKindCode = src.GoodsKindCode; // 商品属性
            detail.GoodsMakerCd = src.GoodsMakerCd; // 商品メーカーコード
            detail.MakerName = src.MakerName; // メーカー名称
            detail.GoodsNo = src.GoodsNo; // 商品番号
            detail.GoodsName = src.GoodsName; // 商品名称
            detail.BLGoodsCode = src.BLGoodsCode; // BL商品コード
            detail.BLGoodsFullName = src.BLGoodsFullName; // BL商品コード名称（全角）
            detail.EnterpriseGanreCode = src.EnterpriseGanreCode; // 自社分類コード
            detail.EnterpriseGanreName = src.EnterpriseGanreName; // 自社分類名称
            detail.WarehouseCode = src.WarehouseCode; // 倉庫コード
            detail.WarehouseName = src.WarehouseName; // 倉庫名称
            detail.WarehouseShelfNo = src.WarehouseShelfNo; // 倉庫棚番
            detail.SalesOrderDivCd = src.SalesOrderDivCd; // 売上在庫取寄せ区分
            detail.OpenPriceDiv = src.OpenPriceDiv; // オープン価格区分
            detail.ListPriceRate = src.ListPriceRate; // 定価率
            detail.ListPriceTaxIncFl = src.ListPriceTaxIncFl; // 定価（税込，浮動）
            detail.ListPriceTaxExcFl = src.ListPriceTaxExcFl; // 定価（税抜，浮動）
            detail.SalesRate = src.SalesRate; // 売価率
            detail.SalesUnPrcTaxIncFl = src.SalesUnPrcTaxIncFl; // 売上単価（税込，浮動）
            detail.SalesUnPrcTaxExcFl = src.SalesUnPrcTaxExcFl; // 売上単価（税抜，浮動）
            detail.SalesUnitCost = src.SalesUnitCost; // 原価単価
            detail.PrtBLGoodsCode = src.PrtBLGoodsCode; // BL商品コード（印刷）
            detail.PrtBLGoodsName = src.PrtBLGoodsName; // BL商品コード名称（印刷）
            detail.SalesCode = src.SalesCode; // 販売区分コード
            detail.SalesCdNm = src.SalesCdNm; // 販売区分名称
            detail.WorkManHour = src.WorkManHour; // 作業工数
            detail.ShipmentCnt = src.ShipmentCnt; // 出荷数
            detail.SalesMoneyTaxInc = src.SalesMoneyTaxInc; // 売上金額（税込み）
            detail.SalesMoneyTaxExc = src.SalesMoneyTaxExc; // 売上金額（税抜き）
            detail.Cost = src.Cost; // 原価
            detail.SalesGoodsCd = src.SalesGoodsCd; // 売上商品区分
            detail.SalesPriceConsTax = src.SalesPriceConsTax; // 売上金額消費税額
            detail.TaxationDivCd = src.TaxationDivCd; // 課税区分
            detail.PartySlipNumDtl = src.PartySlipNumDtl; // 相手先伝票番号（明細）
            detail.SupplierCd = src.SupplierCd; // 仕入先コード
            detail.SupplierSnm = src.SupplierSnm; // 仕入先略称
            detail.OrderNumber = src.OrderNumber; // 発注番号
            detail.WayToOrder = src.WayToOrder; // 注文方法
            detail.PrtGoodsNo = src.PrtGoodsNo; // 印刷用商品番号
            detail.PrtMakerCode = src.PrtMakerCode; // 印刷用メーカーコード
            detail.PrtMakerName = src.PrtMakerName; // 印刷用メーカー名称
            //detail.CampaignCode = src.CampaignCode; // キャンペーンコード
            //detail.CampaignName = src.CampaignName; // キャンペーン名称
            //detail.GoodsDivCd = src.GoodsDivCd; // 商品種別
            //detail.AnswerDelivDate = src.AnswerDelivDate; // 回答納期


            #endregion

            return detail;
        }


        #endregion

        #region 車両データ用

        /// <summary>
        /// メール初期値車両データへの変換（車輌管理マスタ リモート用）
        /// </summary>
        /// <param name="src">車輌管理マスタオブジェクト</param>
        /// <returns></returns>
        public static MailDefaultCar ConverToMailDefaultCar(CarManagementWork src)
        {
            MailDefaultCar car = new MailDefaultCar();

            #region 項目コピー

            car.CarMngCode = src.CarMngCode; // 車両管理コード
            car.NumberPlate1Code = src.NumberPlate1Code; // 陸運事務所番号
            car.NumberPlate1Name = src.NumberPlate1Name; // 陸運事務局名称
            car.NumberPlate2 = src.NumberPlate2; // 車両登録番号（種別）
            car.NumberPlate3 = src.NumberPlate3; // 車両登録番号（カナ）
            car.NumberPlate4 = src.NumberPlate4; // 車両登録番号（プレート番号）
            car.FirstEntryDate = src.FirstEntryDate; // 初年度
            car.MakerCode = src.MakerCode; // メーカーコード
            car.MakerFullName = src.MakerFullName; // メーカー全角名称
            car.ModelCode = src.ModelCode; // 車種コード
            car.ModelSubCode = src.ModelSubCode; // 車種サブコード
            car.ModelFullName = src.ModelFullName; // 車種全角名称
            car.ExhaustGasSign = src.ExhaustGasSign; // 排ガス記号
            car.SeriesModel = src.SeriesModel; // シリーズ型式
            car.CategorySignModel = src.CategorySignModel; // 型式（類別記号）
            car.FullModel = src.FullModel; // 型式（フル型）
            car.ModelDesignationNo = src.ModelDesignationNo; // 型式指定番号
            car.CategoryNo = src.CategoryNo; // 類別番号
            car.FrameModel = src.FrameModel; // 車台型式
            car.FrameNo = src.FrameNo; // 車台番号
            car.EngineModelNm = src.EngineModelNm; // エンジン型式名称
            car.Mileage = src.Mileage; // 車両走行距離
            car.CarNote = src.CarNote; // 車輌備考

            #endregion

            return car;
        }

        /// <summary>
        /// メール初期値車両データへの変換（受注マスタ(車両) リモート用）
        /// </summary>
        /// <param name="src">受注マスタ（車両）オブジェクト</param>
        /// <returns></returns>
        public static MailDefaultCar ConverToMailDefaultCar(AcceptOdrCarWork src)
        {
            MailDefaultCar car = new MailDefaultCar();

            #region 項目コピー

            car.CarMngCode = src.CarMngCode; // 車両管理コード
            car.NumberPlate1Code = src.NumberPlate1Code; // 陸運事務所番号
            car.NumberPlate1Name = src.NumberPlate1Name; // 陸運事務局名称
            car.NumberPlate2 = src.NumberPlate2; // 車両登録番号（種別）
            car.NumberPlate3 = src.NumberPlate3; // 車両登録番号（カナ）
            car.NumberPlate4 = src.NumberPlate4; // 車両登録番号（プレート番号）
            car.FirstEntryDate = src.FirstEntryDate; // 初年度
            car.MakerCode = src.MakerCode; // メーカーコード
            car.MakerFullName = src.MakerFullName; // メーカー全角名称
            car.ModelCode = src.ModelCode; // 車種コード
            car.ModelSubCode = src.ModelSubCode; // 車種サブコード
            car.ModelFullName = src.ModelFullName; // 車種全角名称
            car.ExhaustGasSign = src.ExhaustGasSign; // 排ガス記号
            car.SeriesModel = src.SeriesModel; // シリーズ型式
            car.CategorySignModel = src.CategorySignModel; // 型式（類別記号）
            car.FullModel = src.FullModel; // 型式（フル型）
            car.ModelDesignationNo = src.ModelDesignationNo; // 型式指定番号
            car.CategoryNo = src.CategoryNo; // 類別番号
            car.FrameModel = src.FrameModel; // 車台型式
            car.FrameNo = src.FrameNo; // 車台番号
            car.EngineModelNm = src.EngineModelNm; // エンジン型式名称
            car.Mileage = src.Mileage; // 車両走行距離
            car.CarNote = src.CarNote; // 車輌備考

            #endregion

            return car;
        }



        #endregion

    }
}

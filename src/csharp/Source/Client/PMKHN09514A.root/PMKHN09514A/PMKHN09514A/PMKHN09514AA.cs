//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : ＴＢＯ情報出力
// プログラム概要   : ＴＢＯ情報出力
//----------------------------------------------------------------------------//
//                (c)Copyright  2016 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号 : 11270029-00  作成担当 : 黄亜光
// 作 成 日 : 2016/05/20   修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号 : 11270029-00  作成担当 : 時シン
// 作 成 日 : 2016/07/04   修正内容 : Redmine#48794 PKG改良案件(TBO情報出力)の仕様変更依頼
//----------------------------------------------------------------------------//

using System;
using System.Text;
using System.Data;
using System.Collections;
using System.Collections.Generic;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

//--- ADD 2016/07/05 佐々木（貴） --->>>
using Microsoft.Win32;
using System.IO;
//--- ADD 2016/07/05 佐々木（貴） ---<<<

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ＴＢＯ情報出力 アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note        : ＴＢＯ情報出力で使用するデータを取得する。</br>
    /// <br>Programmer  : 黄亜光</br>
    /// <br>Date        : 2016/05/20</br>
    /// <br>Programmer  : 時シン</br>
    /// <br>Date        : 2016/07/04</br>
    /// <br>Note        : </br>
    /// <br>Update Note : 2016/07/04 時シン</br>
    /// <br>管理番号    : 11270029-00 </br>
    /// <br>              Redmine#48794 PKG改良案件(TBO情報出力)の仕様変更依頼</br>
    /// <br>Update Note : 2016/07/05 30757佐々木（貴）</br>
    /// <br>管理番号    : 11270029-00 PKG改良案件(TBO情報出力)の仕様変更依頼検証用</br>
    /// <br>              ログクラスの追加</br>
    /// </remarks>
    public class TBODataExportAcs
    {
        #region ■ Constructor
        /// <summary>
        /// ＴＢＯ情報出力アクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note        : ＴＢＯ情報出力アクセスクラスの初期化を行う。</br>
        /// <br>Programmer  : 黄亜光</br>
        /// <br>Date        : 2016/05/20</br>
        /// </remarks>
        public TBODataExportAcs()
        {
            this._iTBODataExportDB = (ITBODataExportDB)MediationTBODataExportDB.GetTBODataExportDB();
            this.goodsMGroupDic = new Dictionary<string, List<string>>();
            logFile = new LogFile( true ); //ADD 2016/07/05 佐々木（貴）11270029-00 PKG改良案件(TBO情報出力)の仕様変更依頼
        }
        #endregion ■ Constructor

        #region ■ Private Member
        private ITBODataExportDB _iTBODataExportDB;
        private Dictionary<string, List<string>> goodsMGroupDic = null;

        // ADD by 時シン 016/07/04 FOR Redmine#48794 PKG改良案件(TBO情報出力)の仕様変更依頼 ---->>>>>
        /// <summary>
        /// 売上全体設定マスタリストキャッシュ領域
        /// </summary>
        private List<SalesTtlSt> salesTtlStList;

        /// <summary>
        /// 売上全体設定マスタ情報キャッシュ領域
        /// </summary>
        private SalesTtlSt salesTtlStCache;
        // ADD by 時シン 016/07/04 FOR Redmine#48794 PKG改良案件(TBO情報出力)の仕様変更依頼 ----<<<<<

        //--- ADD 2016/07/05 佐々木（貴）11270029-00 PKG改良案件(TBO情報出力)の仕様変更依頼 --->>>
        /// <summary>ログ記録管理クラス</summary>
        private LogFile logFile = null;
        //--- ADD 2016/07/05 佐々木（貴）11270029-00 PKG改良案件(TBO情報出力)の仕様変更依頼 ---<<<
        #endregion ■ Private Member

        #region ■ Constant
        private const string FILE_NAME_TBOGOODSMCODELIST = "PMKHN09510U_TBOGoodsMCodeList.XML";
        private const string CATEGORY_TIRE = "1";
        private const string CATEGORY_BATTERY = "2";
        private const string CATEGORY_OIL = "3";

        // ADD by 時シン 016/07/04 FOR Redmine#48794 PKG改良案件(TBO情報出力)の仕様変更依頼 ---->>>>>
        /// <summary>
        /// 商品抽出条件->商品属性
        /// </summary>
        /// <remarks>
        /// GoodsAcs.Search()を使用する場合、GoodsKindCodeパラメータに9をセットしないと純正品以外の
        /// 商品情報を取得できない。
        /// </remarks>
        private const int GoodsSearchCondGoodsKindCode = 9;

        /// <summary>ローカルDB読み込み判定</summary>
#if DEBUG
        private const bool LocalDBReadFlag = false; // true:ローカル参照 false:サーバー参照
#else
        private const bool LocalDBReadFlag = false; // true:ローカル参照 false:サーバー参照
#endif

        /// <summary>拠点コード(全体)</summary>
        private const string DefaultSectionCode = "00";
        /// <summary>売価未設定時区分:ゼロ表示</summary>
        private const int UnPrcNonSettingDivZero = 0;
        /// <summary>売価未設定時区分:定価表示</summary>
        private const int UnPrcNonSettingDivSuggestPrice = 1;
        
        // ADD by 時シン 016/07/04 FOR Redmine#48794 PKG改良案件(TBO情報出力)の仕様変更依頼 ----<<<<<
        #endregion

        #region ■ Public Method
        /// <summary>
        /// データ抽出処理
        /// </summary>
        /// <param name="condition">抽出条件</param>
        /// <param name="proposeGoodsList">TBO検索結果</param>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note        : テキスト出力データを取得する。</br>
        /// <br>Programmer  : 黄亜光</br>
        /// <br>Date        : 2016/05/20</br>
        /// </remarks>
        public int SearchTBODataExportMain(TBODataExportCond condition, out List<Propose_Goods> proposeGoodsList, out string errMessage)
        {
            proposeGoodsList = new List<Propose_Goods>();

            // データ検索
            ArrayList retTBODataList = null;
            int status = SearchTBODataExportProc(condition, out retTBODataList, out errMessage);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // データ変換
                status = ConvertTBOData(condition, retTBODataList, out proposeGoodsList, out errMessage);
            }

            return status;
        }
        #endregion ■ Public Method

        #region ■ Private Method
        /// <summary>
        /// データ取得
        /// </summary>
        /// <param name="condition">抽出条件</param>
        /// <param name="retTBODataList">データ検索結果</param>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note        : TBOデータを取得する。</br>
        /// <br>Programmer  : 黄亜光</br>
        /// <br>Date        : 2016/05/20</br>
        /// </remarks>
        private int SearchTBODataExportProc(TBODataExportCond condition, out ArrayList retTBODataList, out string errMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            retTBODataList = null; // TBO検索結果
            errMessage = String.Empty;

            // 商品カテゴリ変換XMLファイルの読み込み
            DeserializeXMLFile();

            // 商品カテゴリ毎の中分類をセット
            condition.GoodsMGroup = new ArrayList();
            condition.GoodsMGroup.AddRange(this.goodsMGroupDic[condition.CategoryID.ToString()]);

            //-----------------------------------------------------------------------------
            // データ検索
            //-----------------------------------------------------------------------------
            try
            {
                object result = null;
                status = this._iTBODataExportDB.SearchTBOData(out result, (object)condition, out errMessage);

                // 正常の場合
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    retTBODataList = (ArrayList)result;
                }
            }
            catch (Exception ex)
            {
                errMessage = ex.Message;
            }

            return status;
        }

        /// <summary>
        /// データ変換の処理
        /// </summary>
        /// <param name="condition">抽出条件</param>
        /// <param name="resultTBODataList">データ検索結果</param>
        /// <param name="proposeGoodsList">変換結果</param>
        /// <param name="errMessage">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : データ変換の処理を行う。</br>
        /// <br>Programmer : 黄亜光</br>
        /// <br>Date       : 2016/05/20</br>
        /// <br>Update Note: 2016/07/04 時シン</br>
        /// <br>管理番号   : 11270029-00 </br>
        /// <br>             Redmine#48794 PKG改良案件(TBO情報出力)の仕様変更依頼</br>
        /// </remarks>
        private int ConvertTBOData(TBODataExportCond condition, ArrayList resultTBODataList, out List<Propose_Goods> proposeGoodsList, out string errMessage)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            proposeGoodsList = new List<Propose_Goods>();
            errMessage = String.Empty;

            // ADD by 時シン 016/07/04 FOR Redmine#48794 PKG改良案件(TBO情報出力)の仕様変更依頼 ---->>>>>
            // 商品アクセス
            GoodsAcs goodsAcs = new GoodsAcs();
            // 仕入先アクセス
            SupplierAcs supplierAcs = new SupplierAcs();

            DateTime priceStartDateDT = new DateTime();  // 適用日
            if (condition.PriceStartDate.ToString().Length == 8)
            {
                int year = Int32.Parse(condition.PriceStartDate.ToString().Substring(0, 4));
                int month = Int32.Parse(condition.PriceStartDate.ToString().Substring(4, 2));
                int day = Int32.Parse(condition.PriceStartDate.ToString().Substring(6, 2));
                priceStartDateDT = new DateTime(year, month, day);
            }
            // 税率情報
            TaxRateSetAcs taxRateSetAcs = new TaxRateSetAcs();
            TaxRateSet taxRateSet = new TaxRateSet();
            taxRateSetAcs.Read(out taxRateSet, condition.EnterpriseCode, 0);

            //商品検索条件
            GoodsCndtn cndtn = new GoodsCndtn();
            // 商品連結情報
            List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>();
            // 単価算出クラス
            UnitPriceCalculation upc = new UnitPriceCalculation();
            // 単価計算パラメータオブジェクト
            UnitPriceCalcParam unitPriceCalcParam = new UnitPriceCalcParam();
            // ADD by 時シン 016/07/04 FOR Redmine#48794 PKG改良案件(TBO情報出力)の仕様変更依頼 ----<<<<<
            try
            {
                // ADD by 時シン 016/07/04 FOR Redmine#48794 PKG改良案件(TBO情報出力)の仕様変更依頼 ---->>>>>

                //  売上全体設定マスタから、売価未設定時区分を取得
                SalesTtlSt salesTtlSt = null;
                this.GetSalesTtlSt( 
                      out salesTtlSt
                    , condition.EnterpriseCode
                    , condition.SectionCodeRF.Trim() );
                int unPrcNonSettingDiv = salesTtlSt != null ? salesTtlSt.UnPrcNonSettingDiv : 0;

                //得意先情報より各パラメータを取得する
                List<CustRateGroup> custRateGroupList = null;　//得意先掛率グループ
                int salesCnsTaxFrcProcCd = 0;                  //売上消費税端数処理コード
                int salesUnPrcFrcProcCd = 0;                   // 売上単価端数処理コード
                if (  condition.CustomerCode > 0 )
                {
                    //得意先掛率グループの取得
                    this.GetCustRateGroupList( out custRateGroupList, condition.EnterpriseCode, condition.CustomerCode );

                    // 得意先マスタアクセサ
                    CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();

                    // 売上消費税端数処理コードの取得
                    salesCnsTaxFrcProcCd = customerInfoAcs.GetSalesFractionProcCd(
                          condition.EnterpriseCode
                        , condition.CustomerCode
                        , CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd );
                    // 売上単価端数処理コードの取得
                    salesUnPrcFrcProcCd = customerInfoAcs.GetSalesFractionProcCd(
                          condition.EnterpriseCode
                        , condition.CustomerCode
                        , CustomerInfoAcs.FracProcMoneyDiv.UnPrcFrcProcCd );
                }
                
                // ADD by 時シン 016/07/04 FOR Redmine#48794 PKG改良案件(TBO情報出力)の仕様変更依頼 ----<<<<<

                foreach (TBODataExportResultWork result in resultTBODataList)
                {
                    // ADD by 時シン 016/07/04 FOR Redmine#48794 PKG改良案件(TBO情報出力)の仕様変更依頼 ---->>>>>
                    bool salesUnitPriceFlg = false;//売価算出済みフラグ
                    
                    cndtn.EnterpriseCode = condition.EnterpriseCode;
                    cndtn.SectionCode = condition.SectionCodeRF.Trim();
                    cndtn.GoodsMakerCd = result.GoodsMakerCdRF;
                    cndtn.GoodsNo = result.GoodsNoRF;
                    cndtn.GoodsKindCode = TBODataExportAcs.GoodsSearchCondGoodsKindCode;
                    //商品連結情報取得
                    status = goodsAcs.Search(cndtn, out goodsUnitDataList, out errMessage);
                    List<UnitPriceCalcRet> unitPriceCalcRetList = null;
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && goodsUnitDataList != null && goodsUnitDataList.Count > 0)
                    {
                        unitPriceCalcParam.BLGoodsCode = goodsUnitDataList[0].BLGoodsCode;  //BLコード
                        unitPriceCalcParam.BLGroupCode = goodsUnitDataList[0].BLGroupCode;  //BLグループコード
                        unitPriceCalcParam.CountFl = 1;  //数量
                        unitPriceCalcParam.CustomerCode = condition.CustomerCode; //得意先コード
                        unitPriceCalcParam.CustRateGrpCode =
                            this.GetCustRateGroupCode( goodsUnitDataList[0].GoodsMakerCd, custRateGroupList ); // 得意先掛率グループコード
                        unitPriceCalcParam.GoodsMakerCd = goodsUnitDataList[0].GoodsMakerCd;
                        unitPriceCalcParam.GoodsNo = goodsUnitDataList[0].GoodsNo;            // 品番
                        unitPriceCalcParam.GoodsRateGrpCode = goodsUnitDataList[0].GoodsRateGrpCode;   // 商品掛率グループコード
                        unitPriceCalcParam.GoodsRateRank = goodsUnitDataList[0].GoodsRateRank;      // 商品掛率ランク
                        unitPriceCalcParam.PriceApplyDate = priceStartDateDT;  // 適用日
                        unitPriceCalcParam.SalesCnsTaxFrcProcCd = salesCnsTaxFrcProcCd; // 売上消費税端数処理コード
                        unitPriceCalcParam.SalesUnPrcFrcProcCd = salesUnPrcFrcProcCd; // 売上単価端数処理コード

                        unitPriceCalcParam.SectionCode = goodsUnitDataList[0].SectionCode;  // 拠点コード

                        // 仕入消費税端数処理コード
                        unitPriceCalcParam.StockCnsTaxFrcProcCd = supplierAcs.GetStockFractionProcCd(
                            goodsUnitDataList[0].EnterpriseCode,
                            goodsUnitDataList[0].SupplierCd,
                            SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd );
                        // 仕入単価端数処理コード
                        unitPriceCalcParam.StockUnPrcFrcProcCd = supplierAcs.GetStockFractionProcCd(
                            goodsUnitDataList[0].EnterpriseCode,
                            goodsUnitDataList[0].SupplierCd,
                            SupplierAcs.StockFracProcMoneyDiv.UnPrcFrcProcCd );

                        unitPriceCalcParam.SupplierCd = goodsUnitDataList[0].SupplierCd;     // 仕入先コード
                        unitPriceCalcParam.TaxationDivCd = goodsUnitDataList[0].TaxationDivCd;  // 課税区分
                        unitPriceCalcParam.TaxRate = TaxRateSetAcs.GetTaxRate( taxRateSet, priceStartDateDT );  // 消費税税率…税率設定マスタ
                        unitPriceCalcParam.ConsTaxLayMethod = taxRateSet.ConsTaxLayMethod;  // 消費税転嫁方式
                        unitPriceCalcParam.TotalAmountDispWayCd = 0;  // 総額表示方法区分
                        unitPriceCalcParam.TtlAmntDspRateDivCd = 0;  // 総額表示掛率適用区分

                        unitPriceCalcRetList = new List<UnitPriceCalcRet>();
                        upc.CalculateSalesRelevanceUnitPriceRateCache( unitPriceCalcParam, goodsUnitDataList[0], out unitPriceCalcRetList );
                    }
                    else if ( status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND )
                    {
                        this.logFile.Write( string.Format(
                              "商品情報の取得でエラーが発生しました (メーカーコード：{0}、品番：{1}、エラーコード：{2})"
                            , cndtn.GoodsMakerCd
                            , cndtn.GoodsNo
                            , status ) );
                    }
                    // ADD by 時シン 016/07/04 FOR Redmine#48794 PKG改良案件(TBO情報出力)の仕様変更依頼 ----<<<<<

                    Propose_Goods proposeGoods = new Propose_Goods();

                    // 拠点コード
                    proposeGoods.SectionCode = condition.SectionCodeRF.Trim();
                    // 商品カテゴリ
                    proposeGoods.GoodsCategory = Convert.ToInt64(condition.CategoryID);
                    // 商品番号
                    proposeGoods.GoodsNo = result.GoodsNoRF;
                    // 商品名称
                    proposeGoods.GoodsName = result.GoodsNameRF;
                    // 商品メーカーコード
                    proposeGoods.GoodsMakerCd = result.GoodsMakerCdRF;
                    // メーカー名称
                    proposeGoods.MakerName = result.MakerNameRF;
                    // 在庫状況区分
                    if (result.ShipmentPosCntRF <= 0)
                    {
                        proposeGoods.StockStatusDiv = 0;
                    }
                    else if (result.ShipmentPosCntRF < result.MinimumStockCntRF)
                    {
                        proposeGoods.StockStatusDiv = 2;
                    }
                    else
                    {
                        proposeGoods.StockStatusDiv = 3;
                    }
                    // DEL by 時シン 016/07/04 FOR Redmine#48794 PKG改良案件(TBO情報出力)の仕様変更依頼 ---->>>>>
                    // 希望小売価格
                    //proposeGoods.SuggestPrice = result.SuggestPriceRF;
                    // 仕入原価
                    //proposeGoods.PurchaseCost = result.PurchaseCostRF;
                    // DEL by 時シン 016/07/04 FOR Redmine#48794 PKG改良案件(TBO情報出力)の仕様変更依頼 ----<<<<<
                    // ADD by 時シン 016/07/04 FOR Redmine#48794 PKG改良案件(TBO情報出力)の仕様変更依頼 ---->>>>>
                    if (unitPriceCalcRetList != null && unitPriceCalcRetList.Count > 0)
                    {
                        foreach (UnitPriceCalcRet priceRet in unitPriceCalcRetList)
                        {
                            int unitPriceKind = 0;
                            try
                            {
                                unitPriceKind = string.IsNullOrEmpty( priceRet.UnitPriceKind ) ? 0 : Convert.ToInt32( priceRet.UnitPriceKind );
                            }
                            catch
                            {
                            }
                            switch (unitPriceKind)
                            {
                                case (int)Broadleaf.Application.Common.UnitPriceCalculation.UnitPriceKind.SalesUnitPrice:
                                    // 売上単価→卸値にセット
                                    proposeGoods.TradePrice = priceRet.UnitPriceTaxExcFl;
                                    salesUnitPriceFlg = true;
                                    break;
                                case (int)Broadleaf.Application.Common.UnitPriceCalculation.UnitPriceKind.UnitCost:
                                    //原価単価→仕入原価にセット
                                    proposeGoods.PurchaseCost = priceRet.UnitPriceTaxExcFl;
                                    break;
                                case (int)Broadleaf.Application.Common.UnitPriceCalculation.UnitPriceKind.ListPrice:
                                    //定価→希望小売価格にセット
                                    proposeGoods.SuggestPrice = priceRet.UnitPriceTaxExcFl;
                                    break;
                                default:
                                    //何れにもセットしない
                                    break;
                            }
                        }
                    }
                    else
                    {
                        // 希望小売価格
                        proposeGoods.SuggestPrice = result.SuggestPriceRF;
                        // 仕入原価
                        proposeGoods.PurchaseCost = result.PurchaseCostRF;
                    }

                    // 売価算出されなかった場合、売価未設定時区分に応じた売価設定を行う
                    if (!salesUnitPriceFlg)
                    {
                        switch (unPrcNonSettingDiv)
                        {
                            // ゼロ表示
                            case TBODataExportAcs.UnPrcNonSettingDivZero:
                                proposeGoods.TradePrice = 0;
                                break;
                            // 定価表示
                            case TBODataExportAcs.UnPrcNonSettingDivSuggestPrice:
                                proposeGoods.TradePrice = proposeGoods.SuggestPrice;
                                break;
                            default:
                                proposeGoods.TradePrice = 0;
                                break;
                        }
                    }

                    // ADD by 時シン 016/07/04 FOR Redmine#48794 PKG改良案件(TBO情報出力)の仕様変更依頼 ----<<<<<
                    // PM更新日時
                    proposeGoods.PMUpdateTime = result.PMUpdateTimeRF;
                    // 検索タグ1
                    proposeGoods.SearchTag1 = result.SearchTag1RF;
                    // 在庫数
                    proposeGoods.StockCnt = result.ShipmentPosCntRF;
                    // BL商品コード
                    proposeGoods.BLGoodsCode = result.BLGoodsCodeRF;

                    proposeGoodsList.Add(proposeGoods);
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (Exception ex)
            {
                errMessage = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        /// <summary>
        /// 商品カテゴリ変換用XMLファイルのデシリアライズ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 商品カテゴリ変換用のデータモデルを生成する</br>
        /// <br>Programmer : 河原林　一生</br>
        /// <br>Date       : 2016/05/20</br>
        /// </remarks>
        private void DeserializeXMLFile()
        {
            if (this.goodsMGroupDic != null)
            {
                this.goodsMGroupDic.Clear();
            }

            string xmlFilePath = System.IO.Path.Combine(ConstantManagement_ClientDirectory.UISettings, FILE_NAME_TBOGOODSMCODELIST);
            List<TBOGoodsMGroup> goodsMGroupList = UserSettingController.DeserializeUserSetting<List<TBOGoodsMGroup>>(xmlFilePath);
            foreach (TBOGoodsMGroup group in goodsMGroupList)
            {
                if (!this.goodsMGroupDic.ContainsKey(group.Category))
                {
                    this.goodsMGroupDic.Add(group.Category, new List<string>());
                }
                this.goodsMGroupDic[group.Category].Add(group.GoodsMGroup);
            }
        }

        // ADD by 時シン 016/07/04 FOR Redmine#48794 PKG改良案件(TBO情報出力)の仕様変更依頼 ---->>>>>
        /// <summary>
        /// 得意先掛率グループ取得
        /// </summary>
        /// <param name="custRateGroupList">得意先掛率グループリスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <returns>処理結果</returns>
        /// <remarks>
        /// <br>Note       : 指定得意先コードの得意先掛率グループをリストで取得する</br>
        /// <br>Programmer : 時シン</br>
        /// <br>Date       : 2016/07/04</br>
        /// <br>管理番号   : 11270029-00 PKG改良案件(TBO情報出力)の仕様変更依頼</br>
        /// </remarks>
        private int GetCustRateGroupList( out List<CustRateGroup> custRateGroupList, string enterpriseCode, int customerCode )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            //
            //得意先掛率グループの取得
            //
            custRateGroupList = null;
            if( customerCode > 0)
            {
                CustRateGroupAcs custRateGroupAcs = new CustRateGroupAcs();
                ArrayList resultList = null;
                status = custRateGroupAcs.Search(
                      out resultList
                    , enterpriseCode
                    , customerCode
                    , ConstantManagement.LogicalMode.GetData0 );
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && resultList != null)
                {
                    custRateGroupList = new List<CustRateGroup>( (CustRateGroup[])resultList.ToArray( typeof( CustRateGroup ) ) );
                }
            }
            return status;
        }

        /// <summary>
        /// 得意先掛率グループコード取得
        /// </summary>
        /// <param name="goodsMakerCode">部品メーカーコード</param>
        /// <param name="custRateGroupList">得意先掛率グループリスト</param>
        /// <returns>得意先掛率グループコード　※取得できなかった場合-1を返す</returns>
        /// <remarks>
        /// <br>Note       : 得意先掛率グループリストから部品メーカーコードに紐付く得意先掛率グループコードを取得</br>
        /// <br>Programmer : 時シン</br>
        /// <br>Date       : 2016/07/04</br>
        /// <br>管理番号   : 11270029-00 PKG改良案件(TBO情報出力)の仕様変更依頼</br>
        /// </remarks>
        private int GetCustRateGroupCode( int goodsMakerCode, List<CustRateGroup> custRateGroupList )
        {
            int PureGoodsMakerCode = 999;                                    // 純正メーカー最大コード
            int pureCode = ( goodsMakerCode <= PureGoodsMakerCode ) ? 0 : 1; // 0:純正 1:優良

            if (custRateGroupList == null)
            {
                return -1;
            }

            // 単独キー
            CustRateGroup custRateGroup = custRateGroupList.Find(
                delegate( CustRateGroup custRate )
                {
                    if (( custRate.GoodsMakerCd == goodsMakerCode ) &&
                        ( custRate.PureCode == pureCode ))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );
            if (custRateGroup != null) return custRateGroup.CustRateGrpCode;

            // 共通キー
            custRateGroup = custRateGroupList.Find(
                delegate( CustRateGroup custRate )
                {
                    if (( custRate.GoodsMakerCd == 0 ) &&
                        ( custRate.PureCode == pureCode ))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );
            if (custRateGroup != null) return custRateGroup.CustRateGrpCode;

            return -1;
        }

        # region ■売上全体設定マスタ制御処理
        /// <summary>
        /// 売上全体設定マスタ取得
        /// </summary>
        /// <param name="salesTtlSt">売上全体設定マスタ</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <remarks>
        /// <br>Note       : 売上全体設定マスタを取得</br>
        /// <br>Programmer : 時シン</br>
        /// <br>Date       : 2016/07/04</br>
        /// <br>管理番号   : 11270029-00 PKG改良案件(TBO情報出力)の仕様変更依頼</br>
        /// </remarks>
        internal void GetSalesTtlSt( out SalesTtlSt salesTtlSt, string enterpriseCode, string sectionCode )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            salesTtlSt = null;
            if (salesTtlStCache != null
                 && this.salesTtlStCache.EnterpriseCode.Trim().Equals( enterpriseCode.Trim() )
                 && this.salesTtlStCache.SectionCode.Trim().Equals( sectionCode.Trim() ))
            {
                salesTtlSt = this.salesTtlStCache;
            }

            if (salesTtlSt == null)
            {
                // 売上全体設定マスタリストが未取得の場合、売上全体設定マスタリストを取得する
                if (salesTtlStList == null || salesTtlStList.Count <= 0)
                {
                    #region ●売上全体設定マスタ取得 DCKHN09212A
                    this.logFile.Write( "売上全体設定を取得" );
                    SalesTtlStAcs salesTtlStAcs = new SalesTtlStAcs();          // 売上全体設定マスタアクセサ
                    salesTtlStAcs.IsLocalDBRead = LocalDBReadFlag;
                    ArrayList salesTtlStResList;
                    status = salesTtlStAcs.SearchOnlySalesTtlInfo( out salesTtlStResList, enterpriseCode );
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && salesTtlStResList != null)
                    {
                        this.salesTtlStList = new List<SalesTtlSt>( (SalesTtlSt[])salesTtlStResList.ToArray( typeof( SalesTtlSt ) ) );
                    }
                    #endregion //●売上全体設定マスタ取得 DCKHN09212A
                }

                this.salesTtlStCache = null;
                if (this.salesTtlStList != null)
                {
                    this.salesTtlStCache = this.salesTtlStList.Find(
                        delegate( SalesTtlSt salesttl )
                        {
                            if (( salesttl.SectionCode.Trim() == sectionCode.Trim() ) &&
                                ( salesttl.EnterpriseCode.Trim() == enterpriseCode.Trim() ))
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    );

                    if (this.salesTtlStCache == null)
                    {
                        this.salesTtlStCache = this.salesTtlStList.Find(
                            delegate( SalesTtlSt salesttl )
                            {
                                if (( salesttl.SectionCode.Trim() == DefaultSectionCode.Trim() ) &&
                                    ( salesttl.EnterpriseCode.Trim() == enterpriseCode.Trim() ))
                                {
                                    return true;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                        );
                    }

                    salesTtlSt = this.salesTtlStCache;
                }
            }
        }
        # endregion //■売上全体設定マスタ制御処理
        
        // ADD by 時シン 016/07/04 FOR Redmine#48794 PKG改良案件(TBO情報出力)の仕様変更依頼 ----<<<<<

        #endregion ■ Private Method
    }

    //--- ADD 2016/07/05 佐々木（貴）11270029-00 PKG改良案件(TBO情報出力)の仕様変更依頼 --->>>
    #region Log
    /// <summary>
    /// ログ記録クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : [InstallDirectory]\Log\PMKHN09514A__yyyyMMdd_HHmmss.log にログ出力を行う</br>
    /// <br>Programmer : 佐々木（貴）</br>
    /// <br>Date       : 2016/07/05</br>
    /// <br>管理番号   : 11270029-00 PKG改良案件(TBO情報出力)の仕様変更依頼</br>
    /// </remarks>
    public class LogFile
    {
        const string _logFileNameFormat = @"PMKHN09514A_{0:yyyyMMdd_HHmmss}.log";
        const int cMaxTextLength = 4000;

        private bool _errorFlg = false;
        private string _folderPath = string.Empty;
        private string _fileName = string.Empty;

        /// <summary>
        /// エラーフラグを取得します。
        /// </summary>
        /// <remarks>
        /// エラーログが１回でも記録された場合は True を返す。
        /// </remarks>
        public bool ErrorFlg
        {
            get { return this._errorFlg; }
        }

        /// <summary>
        /// ログファイルのファイル名を取得します。
        /// </summary>
        /// <remarks>
        /// ログファイルのファイル名をフルパスで取得します。
        /// </remarks>
        public string FileName
        {
            get { return this._fileName; }
        }

        /// <summary>
        /// ログ記録クラス コンストラクタ
        /// </summary>
        /// <param name="clientMode">True: クライアントモード, False: サーバーモード</param>
        public LogFile( bool clientMode )
        {
            string keyPath = "";

            if (clientMode)
            {
                // クラインアント
                keyPath = @String.Format( @"SOFTWARE\Broadleaf\Product\Partsman" );
            }

            else
            {
                // サーバー
                keyPath = @String.Format( @"SOFTWARE\Broadleaf\Service\Partsman\USER_AP" );
            }

            RegistryKey key = Registry.LocalMachine.OpenSubKey( keyPath );

            try
            {
                if (key.GetValue( "InstallDirectory" ) != null)
                {
                    this._folderPath = (string)key.GetValue( "InstallDirectory" );
                }
                else
                {
                    // 取得できなかった場合は、保険としてアセンブリが配置されているフォルダを採用する
                    this._folderPath = System.AppDomain.CurrentDomain.BaseDirectory;
                }

                this._folderPath = Path.Combine( this._folderPath, "Log" );
            }
            finally
            {
                key.Close();
            }
        }

        /// <summary>
        /// ログ記録
        /// </summary>
        /// <param name="ex">例外オブジェクト</param>
        /// <param name="text">記録メッセージ</param>
        public void Write( Exception ex, string text )
        {
            this._errorFlg = true;

            if (string.IsNullOrEmpty( text ))
            {
                this.Write( ex.Message );

            }
            else
            {
                this.Write( string.Format( "{0} ({1})", ex.Message, text ) );
            }
        }

        /// <summary>
        /// ログ記録
        /// </summary>
        /// <param name="text">記録メッセージ</param>
        public void Write( string text )
        {
            string contents = string.Empty;

            if (string.IsNullOrEmpty( this._fileName ))
            {
                this._fileName = System.IO.Path.Combine( this._folderPath, string.Format( _logFileNameFormat, DateTime.Now ) );
            }

            contents = string.Format( "[{0:HH:mm:ss}] {1}" + Environment.NewLine, DateTime.Now, text );

            if (!System.IO.Directory.Exists( this._folderPath ))
            {
                // ログフォルダが存在しない場合は作成する
                System.IO.Directory.CreateDirectory( this._folderPath );
            }

            // ログの追記
            System.IO.File.AppendAllText( this._fileName, contents );
        }

    }
    #endregion
    //--- ADD 2016/07/05 佐々木（貴）11270029-00 PKG改良案件(TBO情報出力)の仕様変更依頼 ---<<<

}

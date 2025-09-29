//**********************************************************************//
// システム         ：PM.NS
// プログラム名称   ：PMTAB 自動回答処理(検索) テーブルアクセスクラス
// プログラム概要   ：PMTAB常駐処理よりパラメータで車両、部品検索条件が渡される
//                    車両、部品検索条件より車両、部品の検索を行い、
//                    取得した情報をSCM_DBの検索結果関連のテーブルに書込む
// ---------------------------------------------------------------------//
//					Copyright(c) 2013 Broadleaf Co.,Ltd.				//
// =====================================================================//
// 履歴
//----------------------------------------------------------------------//
// 管理番号  10902622-01  作成担当 : songg
// 作 成 日  2013/05/29   作成内容 : PMTAB 自動回答処理(検索)
//----------------------------------------------------------------------//
// 修正内容　ソースチェック確認事項一覧にNo.36の対応　               　      
// 管理番号  10902622-01 作成担当 : songg                                    
// 作 成 日  2013/06/18  作成内容 : 車両検索時、全選択のロジックを追加する
//----------------------------------------------------------------------//
// 修正内容　ソースチェック確認事項一覧にNo.43の対応　               　      
// 管理番号  10902622-01 作成担当 : huangt                                    
// 作 成 日  2013/06/20  作成内容 : 車両検索後のSCM-DBのPMTAB売上(車両情報)セッション管理トランザクションデータを更新します。
//----------------------------------------------------------------------//
// 修正内容　障害報告 #37231の対応　               　      
// 管理番号  10902622-01 作成担当 : huangt                                    
// 作 成 日  2013/06/25  作成内容 : タブレットログ対応
//----------------------------------------------------------------------//
// 修正内容　ログ見直し
// 管理番号  10902622-01 作成担当 : 吉岡
// 作 成 日  2013/07/29  作成内容 : ログ見直し
//----------------------------------------------------------------------//
// 修正内容　Rdmine#39496対応
// 管理番号  10902622-01 作成担当 : 吉岡
// 作 成 日  2013/08/01  作成内容 : Rdmine#39496対応
//----------------------------------------------------------------------//
// 管理番号              作成担当 : 吉岡
// 作 成 日  2013/10/08  修正内容 : 山形部品速度遅延対応 SCM仕掛一覧№10579
//----------------------------------------------------------------------//
// 管理番号              作成担当 : 湯上
// 作 成 日  2013/10/08  修正内容 : 山形部品速度遅延対応 SCM仕掛一覧№10579
//----------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// PMTAB 自動回答処理(検索) テーブルアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       :PMTAB常駐処理よりパラメータで車両、部品検索条件が渡される</br>
    /// <br>            車両、部品検索条件より車両、部品の検索を行い、取得した情報を</br>
    /// <br>            SCM_DBの検索結果関連のテーブルに書込む</br>
    /// <br>Programmer : songg</br>
    /// <br>Date       : 2013/05/29</br>
    /// </remarks>
    public class ScmSearchForTablet
    {
        #region ■ Constructor
        /// <summary>
        /// PMTAB 自動回答処理(検索) Constructor
        /// </summary>
        /// <remarks>
        /// <br>Programmer : songg</br>
        /// <br>Date       : 2013/05/29</br>
        /// </remarks>
        public ScmSearchForTablet()
        {
            // 初期化検索アクセス
            _searchAcs = new PMTAB00142AB();
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            // コンストラクタでログ出力用ディレクトリを作成
            System.IO.Directory.CreateDirectory(EasyLogger.OutPutPath);
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

        }
        #endregion ■ Constructor

        #region ■ Private Member
        // 検索アクセス
        PMTAB00142AB _searchAcs;
        // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
        private const string CLASS_NAME = "ScmSearchForTablet";
        // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

        #endregion ■ Private Member

        #region ■ Property
        // ADD 2013/10/08 SCM仕掛一覧№10579対応 ------------------------------->>>>>
        private GoodsAcs _goodsAccesser;
        public GoodsAcs GoodsAccesser
        {
            get { return _goodsAccesser; }
            set { _goodsAccesser = value; }
        }
        // キャンペーン売価優先設定リスト
        private ArrayList _campaignPrcPrStList;
        public ArrayList CampaignPrcPrStList
        {
            get { return _campaignPrcPrStList; }
            set { _campaignPrcPrStList = value; }
        }
        // ADD 2013/10/08 SCM仕掛一覧№10579対応 -------------------------------<<<<<

        #endregion // ■ Property

        #region ■ Public Method
        /// <summary>
        /// PMTAB 自動回答処理(検索)処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="goodsNo">品番</param>
        /// <param name="blGoodsCode">ＢＬコード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="businessSessionId">業務セッションコード</param>
        /// <param name="tabSearchGuid">PMTAB明細識別GUID</param>
        /// <param name="message">メッセージ</param>
        /// <returns>ステータス</returns>
        public int SearchForTablet(string enterpriseCode,
            string sectionCode, string goodsNo, int blGoodsCode, int customerCode, string businessSessionId, string tabSearchGuid,
            out string message)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            const string methodName = "SearchForTablet";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // UPD 2013/07/29 吉岡 ログ見直し----------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
            // EasyLogger.Write(CLASS_NAME, methodName, "▼▼▼▼▼自動回答処理(検索)処理　開始▼▼▼▼▼");
            EasyLogger.Write(CLASS_NAME, methodName, "▼自動回答処理(検索)処理　開始▼");
            // UPD 2013/07/29 吉岡 ログ見直し-----------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            EasyLogger.Write(CLASS_NAME, methodName, "仕入金額処理区分設定マスタ　取得結果"
                + "　業務セッションID：" + businessSessionId
                + "　PMTAB明細識別GUID：" + tabSearchGuid
                );
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

            message = "";

            if (string.IsNullOrEmpty(businessSessionId))
            {
                message = "業務セッションコードがありません";
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, message);
                // UPD 2013/07/29 吉岡 ログ見直し----------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
                // EasyLogger.Write(CLASS_NAME, methodName, "▲▲▲▲▲自動回答処理(検索)処理　終了▲▲▲▲▲");
                EasyLogger.Write(CLASS_NAME, methodName, "▲自動回答処理(検索)処理　終了▲");
                // UPD 2013/07/29 吉岡 ログ見直し-----------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 ");
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
                return (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_ERROR;
            }

            if (string.IsNullOrEmpty(tabSearchGuid))
            {
                message = "PMTAB明細識別GUIDがありません";
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, message);
                // UPD 2013/07/29 吉岡 ログ見直し----------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
                // EasyLogger.Write(CLASS_NAME, methodName, "▲▲▲▲▲自動回答処理(検索)処理　終了▲▲▲▲▲");
                EasyLogger.Write(CLASS_NAME, methodName, "▲自動回答処理(検索)処理　終了▲");
                // UPD 2013/07/29 吉岡 ログ見直し-----------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 " + message);
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
                return (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_ERROR;
            }

            string pmTabSearchGuid = tabSearchGuid;

            // ADD 2013/08/01 吉岡 Redmine#39496 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            this._searchAcs.SetDataInit(enterpriseCode, customerCode);
            // ADD 2013/08/01 吉岡 Redmine#39496 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

            // ADD 2013/10/08 SCM仕掛一覧№10579対応 ------------------------------->>>>>
            this._searchAcs.GoodsAccesser = GoodsAccesser;
            this._searchAcs.CampaignPrcPrStList = CampaignPrcPrStList;
            // ADD 2013/10/08 SCM仕掛一覧№10579対応 -------------------------------<<<<<

            // 品番検索の場合
            if (!string.IsNullOrEmpty(goodsNo))
            {
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
                //return SearchByGoodsNoForTablet(enterpriseCode,
                //                            sectionCode, goodsNo, blGoodsCode, customerCode, businessSessionId, pmTabSearchGuid,
                //                            out message);
                EasyLogger.Write(CLASS_NAME, methodName,
                    "品番検索条件　企業コード：" + enterpriseCode
                    + "  拠点コード：" + sectionCode
                    + "  業務セッションID：" + businessSessionId
                    + "  明細識別GUID：" + pmTabSearchGuid
                    + "  商品番号：" + goodsNo
                    + "  BLコード：" + blGoodsCode
                    + "  得意先コード：" + customerCode
                    );

                int status = SearchByGoodsNoForTablet(enterpriseCode,
                                            sectionCode, goodsNo, blGoodsCode, customerCode, businessSessionId, pmTabSearchGuid,
                                            out message);

                EasyLogger.Write(CLASS_NAME, methodName, "品番検索 status：" + status.ToString() + " " + message);
                // UPD 2013/07/29 吉岡 ログ見直し----------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
                // EasyLogger.Write(CLASS_NAME, methodName, "▲▲▲▲▲自動回答処理(検索)処理　終了▲▲▲▲▲");
                EasyLogger.Write(CLASS_NAME, methodName, "▲自動回答処理(検索)処理　終了▲");
                // UPD 2013/07/29 吉岡 ログ見直し-----------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
                return status;
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
            }
            // BLコード検索の場合
            else if (0 != blGoodsCode)
            {
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
                //return SearchByCarAndBLCodeForTablet(enterpriseCode,
                //            sectionCode, goodsNo, blGoodsCode, customerCode, businessSessionId, pmTabSearchGuid,
                //            out message);
                EasyLogger.Write(CLASS_NAME, methodName,
                    "BLコード検索　企業コード：" + enterpriseCode
                    + "  拠点コード：" + sectionCode
                    + "  業務セッションID：" + businessSessionId
                    + "  明細識別GUID：" + pmTabSearchGuid
                    + "  商品番号：" + goodsNo
                    + "  BLコード：" + blGoodsCode
                    + "  得意先コード：" + customerCode
                    );

                int status = SearchByCarAndBLCodeForTablet(enterpriseCode,
                            sectionCode, goodsNo, blGoodsCode, customerCode, businessSessionId, pmTabSearchGuid,
                            out message);

                EasyLogger.Write(CLASS_NAME, methodName, "BLコード検索 status：" + status.ToString() + " " + message);
                // UPD 2013/07/29 吉岡 ログ見直し----------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
                // EasyLogger.Write(CLASS_NAME, methodName, "▲▲▲▲▲自動回答処理(検索)処理　終了▲▲▲▲▲");
                EasyLogger.Write(CLASS_NAME, methodName, "▲自動回答処理(検索)処理　終了▲");
                // UPD 2013/07/29 吉岡 ログ見直し-----------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
                return status;
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
            }
            else
            {
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, "検索種別(品番orBLコード)の判定ができません");
                // UPD 2013/07/29 吉岡 ログ見直し----------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
                // EasyLogger.Write(CLASS_NAME, methodName, "▲▲▲▲▲自動回答処理(検索)処理　終了▲▲▲▲▲");
                EasyLogger.Write(CLASS_NAME, methodName, "▲自動回答処理(検索)処理　終了▲");
                // UPD 2013/07/29 吉岡 ログ見直し-----------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
                return (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_ERROR;
            }
        }
        #region ◆ BLコード検索

        /// <summary>
        /// BLコード検索処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : BLコード検索処理と行います</br>
        /// <br>Programmer : songg</br>
        /// <br>Date       : 2013/05/29</br>
        /// </remarks>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="goodsNo">品番コード</param>
        /// <param name="blGoodsCode">BL商品コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="businessSessionId">業務セションID</param>
        /// <param name="pmTabSearchGuid">PMTAB明細識別GUID</param>
        /// <param name="message">メッセージ</param>
        /// <returns>ステータス</returns>
        private int SearchByCarAndBLCodeForTablet(string enterpriseCode,
            string sectionCode, string goodsNo, int blGoodsCode, int customerCode, string businessSessionId, string pmTabSearchGuid,
            out string message)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            const string methodName = "SearchByCarAndBLCodeForTablet";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<

            int status = (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_ERROR;
            message = "";

            int makerCode = 0;
            int modelCode = 0;
            int modelSubCode = 0;
            int modelDesignationNo = 0;
            int categoryNo = 0;
            string fullModel = "";
            string carInspectCertModel = "";


            // SCM DB からPMTAB売上データ(車両情報)を取得する
            ArrayList pmTabSalesDtCarList = new ArrayList();
            status = _searchAcs.ReadPmTabSalesDtCar(enterpriseCode, businessSessionId, ref pmTabSalesDtCarList);
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, "SCM DB からPMTAB売上データ(車両情報)を取得 status：" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
                return status;
            }

            if (pmTabSalesDtCarList.Count > 0)
            {
                PmTabSalesDtCarWork pmTabSalesDtCarWork = pmTabSalesDtCarList[0] as PmTabSalesDtCarWork;
                makerCode = pmTabSalesDtCarWork.MakerCode;
                modelCode = pmTabSalesDtCarWork.ModelCode;
                modelSubCode = pmTabSalesDtCarWork.ModelSubCode;
                modelDesignationNo = pmTabSalesDtCarWork.ModelDesignationNo;
                categoryNo = pmTabSalesDtCarWork.CategoryNo;
                fullModel = pmTabSalesDtCarWork.FullModel;
                carInspectCertModel = pmTabSalesDtCarWork.CarInspectCertModel;
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, "PMTAB売上データ(車両情報) 取得結果（車両検索条件）"
                    + "　メーカーコード:" + pmTabSalesDtCarWork.MakerCode.ToString()
                    + "　車種コード:" + pmTabSalesDtCarWork.ModelCode.ToString()
                    + "　車種サブコード:" + pmTabSalesDtCarWork.ModelSubCode.ToString()
                    + "　型式指定番号:" + pmTabSalesDtCarWork.ModelDesignationNo.ToString()
                    + "　類別番号:" + pmTabSalesDtCarWork.CategoryNo.ToString()
                    + "　型式（フル型）:" + pmTabSalesDtCarWork.FullModel
                    + "　車検証型式:" + pmTabSalesDtCarWork.CarInspectCertModel
                    );
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
            }
            else
            {
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, "PMTAB売上データ(車両情報) 取得件数 0 件");
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
                return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }



            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            //return status = _searchAcs.SearchByCarAndBLCodeForTablet(enterpriseCode, sectionCode,
            //    goodsNo, blGoodsCode, customerCode,
            //    makerCode, modelCode, modelSubCode,
            //    modelDesignationNo, categoryNo, fullModel, carInspectCertModel,
            //    businessSessionId, pmTabSearchGuid, out message
            //    , (PmTabSalesDtCarWork)(pmTabSalesDtCarList[0])); //-----ADD songg 2013/06/18 ソースチェック確認事項一覧にNo.36の対応 ----<<<<<
            status = _searchAcs.SearchByCarAndBLCodeForTablet(enterpriseCode, sectionCode,
                goodsNo, blGoodsCode, customerCode,
                makerCode, modelCode, modelSubCode,
                modelDesignationNo, categoryNo, fullModel, carInspectCertModel,
                businessSessionId, pmTabSearchGuid, out message
                , (PmTabSalesDtCarWork)(pmTabSalesDtCarList[0])); //-----ADD songg 2013/06/18 ソースチェック確認事項一覧にNo.36の対応 ----<<<<<
            EasyLogger.Write(CLASS_NAME, methodName, "BLコード検索　status：" + status.ToString() + " " + message);
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
            return status;
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
        }
        #endregion ◆BLコード検索

        #region ◆ 品番検索
        /// <summary>
        /// 品番検索処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 品番検索処理と行います</br>
        /// <br>Programmer : songg</br>
        /// <br>Date       : 2013/05/29</br>
        /// </remarks>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="goodsNo">品番コード</param>
        /// <param name="blGoodsCode">BL商品コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="businessSessionId">業務セションID</param>
        /// <param name="pmTabSearchGuid">PMTAB明細識別GUID</param>
        /// <param name="message">メッセージ</param>
        /// <returns>ステータス</returns>
        private int SearchByGoodsNoForTablet(string enterpriseCode,
            string sectionCode, string goodsNo, int blGoodsCode, int customerCode, string businessSessionId, string pmTabSearchGuid,
            out string message)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            const string methodName = "SearchByGoodsNoForTablet";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 開始");
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
            int status = (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_ERROR;
            message = "";

            int makerCode = 0;
            int modelCode = 0;
            int modelSubCode = 0;
            int modelDesignationNo = 0;
            int categoryNo = 0;
            string fullModel = "";
            string carInspectCertModel = "";

            // SCM DB からPMTAB売上データ(車両情報)を取得する
            ArrayList pmTabSalesDtCarList = new ArrayList();
            status = _searchAcs.ReadPmTabSalesDtCar(enterpriseCode, businessSessionId, ref pmTabSalesDtCarList);
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, "SCM DB からPMTAB売上データ(車両情報)を取得 status：" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
                return status;
            }

            if (pmTabSalesDtCarList.Count > 0)
            {
                PmTabSalesDtCarWork pmTabSalesDtCarWork = pmTabSalesDtCarList[0] as PmTabSalesDtCarWork;
                makerCode = pmTabSalesDtCarWork.MakerCode;
                modelCode = pmTabSalesDtCarWork.ModelCode;
                modelSubCode = pmTabSalesDtCarWork.ModelSubCode;
                modelDesignationNo = pmTabSalesDtCarWork.ModelDesignationNo;
                categoryNo = pmTabSalesDtCarWork.CategoryNo;
                fullModel = pmTabSalesDtCarWork.FullModel;
                carInspectCertModel = pmTabSalesDtCarWork.CarInspectCertModel;
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, "PMTAB売上データ(車両情報) 取得結果（車両検索条件）"
                    + "　メーカーコード:" + pmTabSalesDtCarWork.MakerCode.ToString()
                    + "　車種コード:" + pmTabSalesDtCarWork.ModelCode.ToString()
                    + "　車種サブコード:" + pmTabSalesDtCarWork.ModelSubCode.ToString()
                    + "　型式指定番号:" + pmTabSalesDtCarWork.ModelDesignationNo.ToString()
                    + "　類別番号:" + pmTabSalesDtCarWork.CategoryNo.ToString()
                    + "　型式（フル型）:" + pmTabSalesDtCarWork.FullModel
                    + "　車検証型式:" + pmTabSalesDtCarWork.CarInspectCertModel
                    );
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
            }
            else
            {
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, "PMTAB売上データ(車両情報) 取得件数 0 件");
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了 ");
                // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
                return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }



            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- >>>>>
            //return status = _searchAcs.SearchByGoodsNoForTablet(enterpriseCode, sectionCode,
            //    goodsNo, blGoodsCode, customerCode,
            //    makerCode, modelCode, modelSubCode,
            //    modelDesignationNo, categoryNo, fullModel, carInspectCertModel,
            //    businessSessionId, pmTabSearchGuid, out message
            //    , (PmTabSalesDtCarWork)(pmTabSalesDtCarList[0])); // ADD huangt 2013/06/20 ソースチェック確認事項一覧にNo.43の対応
            status = _searchAcs.SearchByGoodsNoForTablet(enterpriseCode, sectionCode,
                goodsNo, blGoodsCode, customerCode,
                makerCode, modelCode, modelSubCode,
                modelDesignationNo, categoryNo, fullModel, carInspectCertModel,
                businessSessionId, pmTabSearchGuid, out message
                , (PmTabSalesDtCarWork)(pmTabSalesDtCarList[0]));
            EasyLogger.Write(CLASS_NAME, methodName, "品番検索　status：" + status.ToString() + " " + message);
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " 終了");
            return status;
            // ----- ADD huangt 2013/06/25 Redmine#37231 タブレットログ対応 ----- <<<<<
        }
        #endregion ◆ 品番検索

        #endregion ■ Public Method
    }
}

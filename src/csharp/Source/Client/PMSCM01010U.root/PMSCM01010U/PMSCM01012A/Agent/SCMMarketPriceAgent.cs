//****************************************************************************//
// システム         : 自働回答処理
// プログラム名称   : 自働回答処理アクセス
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2009/05/22  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 佐々木 健
// 作 成 日  2010/03/12  修正内容 : 高速化
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2010/04/22  修正内容 : 相場情報は相場価格 種別コード# - 品質コード# で取得(SCM相場価格設定マスタの変更)
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Web.Services.Protocols;

using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;
using Broadleaf.Application.UIData.Util;
using Broadleaf.RCDS.Web.Services;

using System.Collections;       // 2010/03/12 Add


namespace Broadleaf.Application.Controller.Agent
{
    using RealAccesserType  = SCMMrktPriStAcs;
    using RecordType        = SCMMrktPriSt;

    /// <summary>
    /// 相場価格種別コード列挙型
    /// </summary>
    public enum MarketPriceKindCd : int
    {
        /// <summary>なし</summary>
        None = -1,
        /// <summary>新品</summary>
        New = 0,
        /// <summary>リビルト</summary>
        Rebuild = 1,
        /// <summary>中古</summary>
        Used = 2
    }

    /// <summary>
    /// 相場価格回答区分列挙型
    /// </summary>
    public enum MarketPriceAnswerDiv : int
    {
        /// <summary>0:しない</summary>
        None = 0,
        /// <summary>1:する(売価率)</summary>
        Rate = 1,
        /// <summary>2:する(加算テーブル)</summary>
        Table = 2
    }

    /// <summary>
    /// 端数処理区分列挙型
    /// </summary>
    public enum FractionProcCd : int
    {
        /// <summary>10円単位(四捨五入)</summary>
        RoundingOff10Yen = 0,
        /// <summary>100円単位(四捨五入)</summary>
        RoundingOff100Yen = 1
    }

    /// <summary>
    /// SCM相場価格設定アクセスの代理人クラス
    /// </summary>
    public class SCMMarketPriceAgent : AgentPolicy<RealAccesserType, RecordType>
    {
        private const string MY_NAME = "SCM相場価格設定マスタ";

        #region <Constructor>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public SCMMarketPriceAgent() : base() { }

        #endregion // </Constructor>

        // 2010/03/12 >>>
        Dictionary<string, List<RecordType>> _recordlist;

        /// <summary>
        /// 見積全体設定を、拠点コード逆順にソートする
        /// </summary>
        /// <remarks></remarks>
        private class SCMMrktPriStComparer : Comparer<RecordType>
        {
            public override int Compare(RecordType x, RecordType y)
            {
                int result = y.SectionCode.Trim().CompareTo(x.SectionCode.Trim());
                if (result != 0) return result;

                return result;
            }
        }
        // 2010/03/12 <<<

        #region <SCM相場価格設定マスタの検索>

        /// <summary>
        /// 検索します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>該当するSCM相場価格設定 ※指定拠点で件数0の場合、全社設定で再検索します。</returns>
        public RecordType Find(
            string enterpriseCode,
            string sectionCode
        )
        {
            #region <Guard Phrase>

            if (string.IsNullOrEmpty(enterpriseCode.Trim()) || string.IsNullOrEmpty(sectionCode.Trim()))
            {
                return new RecordType();
            }

            #endregion // </Guard Phrase>

            const string ALL_SECTION_CODE = SecInfoSetAgent.ALL_SECTION_CODE;   // 全社設定

            string key = SCMEntityUtil.FormatEnterpriseCode(enterpriseCode) + SCMEntityUtil.FormatSectionCode(sectionCode);
            if (FoundRecordMap.ContainsKey(key))
            {
                return FoundRecordMap[key];
            }

            RecordType foundRecord = null;

            // 2010/03/12 Add >>>
            //int status = RealAccesser.Read(out foundRecord, enterpriseCode, sectionCode);
            //if (!status.Equals((int)ResultUtil.ResultCode.Normal) && !status.Equals((int)ResultUtil.ResultCode.NotFound))
            //{
            //    Debug.Assert(false, MY_NAME + "の検索が失敗しました。");
            //    int sectionCodeNo = SCMEntityUtil.ConvertNumber(sectionCode.Trim());
            //    if (sectionCodeNo > 0)
            //    {
            //        return Find(enterpriseCode, ALL_SECTION_CODE);  // 全社設定で再検索
            //    }
            //}

            //if (SCMDataHelper.IsAvailableRecord(foundRecord))
            //{
            //    FoundRecordMap.Add(key, foundRecord);
            //}
            //else
            //{
            //    int sectionCodeNo = SCMEntityUtil.ConvertNumber(sectionCode.Trim());
            //    if (sectionCodeNo > 0)
            //    {
            //        return Find(enterpriseCode, ALL_SECTION_CODE);  // 全社設定で再検索
            //    }
            //}

            if (_recordlist == null) _recordlist = new Dictionary<string, List<RecordType>>();

            if (!_recordlist.ContainsKey(enterpriseCode))
            {
                _recordlist.Add(enterpriseCode, GetRecordList(enterpriseCode));
            }

            if (_recordlist[enterpriseCode] != null && _recordlist[enterpriseCode].Count > 0)
            {
                foundRecord = ( (List<RecordType>)_recordlist[enterpriseCode] ).Find(
                     delegate(RecordType rec)
                     {
                         if (rec.SectionCode.Trim() == sectionCode.Trim() || rec.SectionCode.Trim() == ALL_SECTION_CODE.Trim())
                         {
                             return true;
                         }
                         return false;
                     });
            }

            if (foundRecord != null && foundRecord.LogicalDeleteCode.Equals(0))
            {
                FoundRecordMap.Add(key, foundRecord);
            }
            // 2010/03/12 Add <<<

            return foundRecord ?? new RecordType();
        }

        // 2010/03/12 Add >>>
        /// <summary>
        /// レコードリストの取得
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <returns></returns>
        private List<RecordType> GetRecordList(string enterpriseCode)
        {
            List<RecordType> retList = new List<RecordType>();
            ArrayList al;
            int status = RealAccesser.SearchAll(out al, enterpriseCode);

            if (status.Equals((int)ResultUtil.ResultCode.Normal))
            {
                if (al != null && al.Count > 0)
                {
                    foreach (SCMMrktPriSt rec in al)
                    {
                        if (rec.LogicalDeleteCode == 0)
                        {
                            retList.Add(rec);
                        }
                    }

                    retList.Sort(new SCMMrktPriStComparer());
                }
            }

            return retList;
        }
        // 2010/03/12 Add <<<

        #endregion // </SCM相場価格設定マスタの検索>

        /// <summary>
        /// 相場情報を取得します。
        /// </summary>
        /// <param name="detailRecord">SCM受注明細データ(問合せ・発注)のレコード</param>
        /// <param name="model">関連型式</param>
        /// <param name="scmGoodsUnitData">SCM情報付商品連結データ</param>
        /// <returns>該当する相場情報</returns>
        public IList<SCMSobaResponseHelper> GetSobaResponse(
            ISCMOrderDetailRecord detailRecord,
            string model,
            SCMGoodsUnitData scmGoodsUnitData
        )
        {
            const string METHOD_NAME = "GetSobaResponse()"; // ログ用

            #region <Log>

            string msg = "相場情報取得中...";
            EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

            #endregion // </Log>

            IList<SCMSobaResponseHelper> scmSobaResponseList = new List<SCMSobaResponseHelper>();
            {
                // SCM相場価格設定を取得
                SCMMrktPriSt foundMarketPriceSetting = Find(
                    detailRecord.InqOtherEpCd,
                    detailRecord.InqOtherSecCd
                );
                if (!SCMDataHelper.IsAvailableRecord(foundMarketPriceSetting)) foundMarketPriceSetting = null;
                if (foundMarketPriceSetting != null)
                {
                    #region <相場価格 種別コード1 - 品質コード1>
                    
                    if (EnabledMarketPrice(foundMarketPriceSetting.MarketPriceKindCd1))
                    {
                        scmSobaResponseList.Add(new SCMSobaResponseHelper(
                            foundMarketPriceSetting,
                            1,
                            GetSobaResTypeFromWebService(foundMarketPriceSetting, 1, detailRecord, model, scmGoodsUnitData)
                        ));
                    }

                    #endregion // </相場価格 種別コード1 - 品質コード1>

                    #region <相場価格 種別コード2 - 品質コード2>

                    if (EnabledMarketPrice(foundMarketPriceSetting.MarketPriceKindCd2))
                    {
                        scmSobaResponseList.Add(new SCMSobaResponseHelper(
                            foundMarketPriceSetting,
                            2,
                            GetSobaResTypeFromWebService(foundMarketPriceSetting, 2, detailRecord, model, scmGoodsUnitData)
                        ));
                    }

                    #endregion // </相場価格 種別コード2 - 品質コード2>

                    #region <相場価格 種別コード3 - 品質コード3>

                    if (EnabledMarketPrice(foundMarketPriceSetting.MarketPriceKindCd3))
                    {
                        scmSobaResponseList.Add(new SCMSobaResponseHelper(
                            foundMarketPriceSetting,
                            3,
                            GetSobaResTypeFromWebService(foundMarketPriceSetting, 3, detailRecord, model, scmGoodsUnitData)
                        ));
                    }

                    #endregion // </相場価格 種別コード3 - 品質コード3>
                }
            }
            return scmSobaResponseList;
        }

        /// <summary>
        /// 相場価格が有効であるか判断します。
        /// </summary>
        /// <param name="marketPriceKindCd">相場価格種別コード</param>
        /// <returns>
        /// <c>true</c> :有効です。<br/>
        /// <c>false</c>:無効です。
        /// </returns>
        private static bool EnabledMarketPrice(int marketPriceKindCd)
        {
            // -1:なし, 0:新品, 1:リビルト, 2:中古
            return !marketPriceKindCd.Equals((int)MarketPriceKindCd.None);
        }

        /// <summary>
        /// 相場情報のリクエスト情報を生成します。
        /// </summary>
        /// <param name="marketPriceSetting">SCM相場価格設定</param>
        /// <param name="marketPriceKindNo">相場価格種別番号</param>
        /// <param name="detailRecord">SCM受注明細データ(問合せ・発注)のレコード</param>
        /// <param name="model">関連型式</param>
        /// <param name="scmGoodsUnitData">SCM情報付商品連結データ</param>
        /// <returns>相場情報のリクエスト情報</returns>
        private static GetSobaReqType CreateSobaRequest(
            SCMMrktPriSt marketPriceSetting,
            int marketPriceKindNo,
            ISCMOrderDetailRecord detailRecord,
            string model,
            SCMGoodsUnitData scmGoodsUnitData
        )
        {
            GetSobaReqType request = new GetSobaReqType();
            {
                request.UC = detailRecord.EnterpriseCode;   // 企業コード：ログイン情報
                request.AT = string.Empty;                  // アクセスチケット：？
                request.GC = string.Empty;                  // ジェネレーションコード：ログイン情報

                // BLコード
                request.BLCodeList = new BLCodeType[1];
                request.BLCodeList[0] = new BLCodeType();
                request.BLCodeList[0].BLCode = scmGoodsUnitData.RealGoodsUnitData.BLGoodsCode.ToString();

                request.Model = model;                                                              // 関連型式
                request.AreaCode = marketPriceSetting.MarketPriceAreaCd;                            // 地区コード
                request.KindCode = GetMarketPriceKindCd(marketPriceSetting, marketPriceKindNo);     // 種別コード
                // DEL 2010/04/22 相場情報は相場価格 種別コード# - 品質コード# で取得(SCM相場価格設定マスタの変更) ---------->>>>>
                //request.QualityCode = marketPriceSetting.MarketPriceQualityCd;                      // 品質コード
                // DEL 2010/04/22 相場情報は相場価格 種別コード# - 品質コード# で取得(SCM相場価格設定マスタの変更) ----------<<<<<
                // ADD 2010/04/22 相場情報は相場価格 種別コード# - 品質コード# で取得(SCM相場価格設定マスタの変更) ---------->>>>>
                request.QualityCode = GetMarketPriceQualityCd(marketPriceSetting, marketPriceKindNo);   // 品質コード
                // ADD 2010/04/22 相場情報は相場価格 種別コード# - 品質コード# で取得(SCM相場価格設定マスタの変更) ----------<<<<<
                request.MtDateTime = new MtDateTimeType();  // FIXME:newするだけでよい？
                //{
                //    const string DATE_TIME_FORMAT = "yyyyMMddHHmmss";
                //    DateTime now = DateTime.Now;
                //    request.MtDateTime.AreaDateTime = now.ToString(DATE_TIME_FORMAT);
                //    request.MtDateTime.KindDateTime = now.ToString(DATE_TIME_FORMAT);
                //    request.MtDateTime.QualityDateTime = now.ToString(DATE_TIME_FORMAT);
                //}
            }
            return request;
        }

        /// <summary>
        /// Webサービスより相場情報を取得します。
        /// </summary>
        /// <param name="marketPriceSetting">SCM相場価格設定</param>
        /// <param name="marketPriceKindNo">相場価格種別番号</param>
        /// <param name="detailRecord">SCM受注明細データ(問合せ・発注)のレコード</param>
        /// <param name="model">関連型式</param>
        /// <param name="scmGoodsUnitData">SCM情報付商品連結データ</param>
        /// <returns>該当する相場情報</returns>
        private static GetSobaResType GetSobaResTypeFromWebService(
            SCMMrktPriSt marketPriceSetting,
            int marketPriceKindNo,
            ISCMOrderDetailRecord detailRecord,
            string model,
            SCMGoodsUnitData scmGoodsUnitData
        )
        {
            const string METHOD_NAME = "GetSobaResTypeFromWebService()";    // ログ用

            // リクエスト情報を生成
            GetSobaReqType request = CreateSobaRequest(
                marketPriceSetting,
                marketPriceKindNo,
                detailRecord,
                model,
                scmGoodsUnitData
            );
            try
            {
                #region <Log>

                const string TAB = "\t";

                StringBuilder msg = new StringBuilder();
                {
                    msg.Append("相場情報取得[リクエスト]").Append(Environment.NewLine);
                    msg.Append(TAB).Append("企業コード：").Append(request.UC).Append(Environment.NewLine);
                    msg.Append(TAB).Append("アクセスチケット：").Append(request.AT).Append(Environment.NewLine);
                    msg.Append(TAB).Append("ジェネレーションコード：").Append(request.GC).Append(Environment.NewLine);

                    msg.Append(TAB).Append("BLコード：").Append(request.BLCodeList[0].BLCode).Append(Environment.NewLine);
                    msg.Append(TAB).Append("関連型式：").Append(request.Model).Append(Environment.NewLine);
                    msg.Append(TAB).Append("地区コード：").Append(request.AreaCode).Append(Environment.NewLine);
                    msg.Append(TAB).Append("種別コード：").Append(request.KindCode).Append(Environment.NewLine);
                    msg.Append(TAB).Append("品質コード：").Append(request.QualityCode).Append(Environment.NewLine);

                    msg.Append(TAB).Append("MtDateTime.AreaDateTime = ").Append(request.MtDateTime.AreaDateTime).Append(Environment.NewLine);
                    msg.Append(TAB).Append("MtDateTime.KindDateTime = ").Append(request.MtDateTime.KindDateTime).Append(Environment.NewLine);
                    msg.Append(TAB).Append("MtDateTime.QualityDateTime = ").Append(request.MtDateTime.QualityDateTime);
                }
                EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg.ToString()));

                #endregion // </Log>

                SobaService sobaService = new SobaService();
                {
                    // Webサービスアクセス
                    GetSobaResType response = sobaService.GetSoba(request);

                    #region <Log>

                    if (response == null)
                    {
                        EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg("レスポンスがnullです。"));
                    }
                    else
                    {
                        string message = "相場情報取得[レスポンス]" + Environment.NewLine;
                        message += string.Format(
                            "\t件数：response.SobaList[0].Cnt = {0}, response.SobaList[0].StdDev = {1}",
                            response.SobaList[0].Cnt,
                            response.SobaList[0].StdDev
                        );
                        EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(message));
                    }

                    #endregion // </Log>

                    return response;
                }
            }
            catch (SoapException ex)
            {
                Debug.WriteLine(ex.ToString());
                //Debug.Assert(false, ex.ToString());
                LogHelper.WriteExceptionLog(
                    MY_NAME,
                    METHOD_NAME,
                    "GetSobaResType response = sobaService.GetSoba(request);",
                    ex
                );
                return null;
            }
        }

        #region <相場価格種別>

        /// <summary>
        /// 相場価格種別コードを取得します。
        /// </summary>
        /// <param name="marketPriceSetting">SCM相場価格設定</param>
        /// <param name="marketPriceKindNo">相場価格種別番号</param>
        /// <returns>相場価格種別コード</returns>
        public static int GetMarketPriceKindCd(
            SCMMrktPriSt marketPriceSetting,
            int marketPriceKindNo
        )
        {
            switch (marketPriceKindNo)
            {
                case 1: // 相場価格種別コード1
                    return marketPriceSetting.MarketPriceKindCd1;
                case 2: // 相場価格種別コード2
                    return marketPriceSetting.MarketPriceKindCd2;
                case 3: // 相場価格種別コード3
                    return marketPriceSetting.MarketPriceKindCd3;
                default:
                    return marketPriceSetting.MarketPriceKindCd1;
            }
        }

        /// <summary>相場価格種別のマップ</summary>
        private IDictionary<string, GetKindListResType> _marketPriceKindMap;
        /// <summary>相場価格種別のマップを取得します。</summary>
        /// <remarks>キー：企業コード</remarks>
        private IDictionary<string, GetKindListResType> MarketPriceKindMap
        {
            get
            {
                if (_marketPriceKindMap == null)
                {
                    _marketPriceKindMap = new Dictionary<string, GetKindListResType>();
                }
                return _marketPriceKindMap;
            }
        }

        /// <summary>
        /// 相場価格種別名称を取得します。
        /// </summary>
        /// <param name="marketPriceSetting">SCM相場価格設定</param>
        /// <param name="marketPriceKindNo">相場価格種別番号</param>
        /// <returns>相場価格種別名称</returns>
        public string GetMarketPriceKindNm(
            SCMMrktPriSt marketPriceSetting,
            int marketPriceKindNo
        )
        {
            const string METHOD_NAME = "GetMarketPriceKindNm()";    // ログ用

            GetKindListResType foundKindListResponse = null;
            if (MarketPriceKindMap.ContainsKey(marketPriceSetting.EnterpriseCode))
            {
                foundKindListResponse = MarketPriceKindMap[marketPriceSetting.EnterpriseCode];
            }
            else
            {
                try
                {
                    // 相場価格種別の情報取得
                    GetKindListReqType request = new GetKindListReqType();
                    {
                        request.UC = marketPriceSetting.EnterpriseCode; // 企業コード
                    }
                    KindService kindService = new KindService();
                    {
                        foundKindListResponse = kindService.GetKindList(request);
                    }
                    MarketPriceKindMap.Add(marketPriceSetting.EnterpriseCode, foundKindListResponse);
                }
                catch (SoapException ex)
                {
                    Debug.WriteLine(ex.ToString());
                    LogHelper.WriteExceptionLog(
                        MY_NAME,
                        METHOD_NAME,
                        "GetKindListResType response = kindService.GetKindList(request);",
                        ex
                    );
                    foundKindListResponse = null;
                }
            }   // if (MarketPriceKindMap.ContainsKey(marketPriceSetting.EnterpriseCode))
            if (foundKindListResponse == null) return string.Empty;

            int marketPriceKindCd = GetMarketPriceKindCd(marketPriceSetting, marketPriceKindNo);
            foreach (KindType kindType in foundKindListResponse.KindList)
            {
                if (marketPriceKindCd.Equals(kindType.KindCode)) return kindType.KindName;
            }
            return string.Empty;
        }

        #endregion // </相場価格種別>

        // ADD 2010/04/22 相場情報は相場価格 種別コード# - 品質コード# で取得(SCM相場価格設定マスタの変更) ---------->>>>>
        #region <相場価格品質>

        /// <summary>
        /// 相場価格品質コードを取得します。
        /// </summary>
        /// <param name="marketPriceSetting">SCM相場価格設定</param>
        /// <param name="marketPriceQualityNo">相場価格品質番号</param>
        /// <returns>相場価格品質コード</returns>
        private static int GetMarketPriceQualityCd(
            SCMMrktPriSt marketPriceSetting,
            int marketPriceQualityNo
        )
        {
            switch (marketPriceQualityNo)
            {
                case 1: // 相場価格品質コード1
                    return marketPriceSetting.MarketPriceQualityCd;
                case 2: // 相場価格品質コード2
                    return marketPriceSetting.MarketPriceQualityCd2;
                case 3: // 相場価格品質コード3
                    return marketPriceSetting.MarketPriceQualityCd3;
                default:
                    return marketPriceSetting.MarketPriceQualityCd;
            }
        }

        #endregion // </相場価格品質>
        // ADD 2010/04/22 相場情報は相場価格 種別コード# - 品質コード# で取得(SCM相場価格設定マスタの変更) ----------<<<<<

        #region 実験コード

        /// <summary>
        /// 相場情報の取得テスト
        /// </summary>
        private static void TestWebService()
        {
            GetSobaReqType request = new GetSobaReqType();
            {
                request.UC = "0101150842020000";    // 企業コード：ログイン情報
                //request.AT = "";    // アクセスチケット：？
                //request.GC = "";    // ジェネレーションコード：ログイン情報

                request.BLCodeList = new BLCodeType[1];
                request.BLCodeList[0] = new BLCodeType();
                request.BLCodeList[0].BLCode = "1"; // BLコード
                request.Model = "E-HR32-GFE";       // 関連型式
                request.AreaCode = 0;               // 地区コード
                request.KindCode = 0;               // 種別コード
                request.QualityCode = 0;            // 品質コード
            }
            SobaService sobaService = new SobaService();
            try
            {
                //// 相場価格地域の情報取得(実験)
                //AreaService areaService = new AreaService();
                //GetAreaListReqType getAreaListReqType = new GetAreaListReqType();
                //GetAreaListResType getAreaListResType = areaService.GetAreaList(getAreaListReqType);

                GetSobaResType response = sobaService.GetSoba(request);
            }
            catch (SoapException ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        #endregion // 実験コード
    }
}

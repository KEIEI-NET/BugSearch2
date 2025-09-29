using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.RCDS.Web.Services;
using System.Web.Services.Protocols;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 相場Webサービスアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 新規作成 (※参考:PMSCM01010U)</br>
    /// <br>Programmer : 22018　鈴木 正臣</br>
    /// <br>Date       : 2010/06/17</br>
    /// </remarks>
    public class SobaServiceAcs
    {
        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        #region ■ Private Member
        /// <summary>相場サービス</summary>
        private SobaService _sobaService;

        /// <summary>相場価格種別のマップ</summary>
        private IDictionary<string, GetKindListResType> _marketPriceKindMap;
        /// <summary>相場価格品質のマップ</summary>
        private IDictionary<string, GetQualityListResType> _marketPriceQualityMap;
        /// <summary>相場価格地域のマップ</summary>
        private IDictionary<string, GetAreaListResType> _marketPriceAreaMap;
        #endregion

        // ===================================================================================== //
        // 列挙体
        // ===================================================================================== //
        #region ■ private Enum
        /// <summary>
        /// 相場価格種別コード列挙型
        /// </summary>
        private enum MarketPriceKindCd : int
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
        private enum MarketPriceAnswerDiv : int
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
        private enum FractionProcCd : int
        {
            /// <summary>10円単位(四捨五入)</summary>
            RoundingOff10Yen = 0,
            /// <summary>100円単位(四捨五入)</summary>
            RoundingOff100Yen = 1
        }
        #endregion

        // ===================================================================================== //
        // クラス
        // ===================================================================================== //
        #region ■ class
        /// <summary>
        /// 相場取得情報（※リクエストとレスポンスをまとめる）
        /// </summary>
        public class GetSobaResTypeUnitData
        {
            private int _index;
            private GetSobaReqType _getSobaReqType;
            private GetSobaResType _getSobaResType;

            /// <summary>
            /// 相場価格マスタ上の何番目の設定かを表すindex
            /// </summary>
            public int Index
            {
                get { return _index; }
                set { _index = value; }
            }
            /// <summary>
            /// リクエスト(条件)
            /// </summary>
            public GetSobaReqType GetSobaReqType
            {
                get { return _getSobaReqType; }
                set { _getSobaReqType = value; }
            }
            /// <summary>
            /// レスポンス(結果)
            /// </summary>
            public GetSobaResType GetSobaResType
            {
                get { return _getSobaResType; }
                set { _getSobaResType = value; }
            }
            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="getSobaResType"></param>
            public GetSobaResTypeUnitData( GetSobaReqType getSobaReqType, GetSobaResType getSobaResType, int index )
            {
                _index = index;
                _getSobaReqType = getSobaReqType;
                _getSobaResType = getSobaResType;
            }
        }
        #endregion

        // ===================================================================================== //
        // プロパティ
        // ===================================================================================== //
        #region ■ Property
        /// <summary>相場価格種別のマップを取得します。</summary>
        /// <remarks>キー：企業コード</remarks>
        private IDictionary<string, GetKindListResType> MarketPriceKindMap
        {
            get
            {
                if ( _marketPriceKindMap == null )
                {
                    _marketPriceKindMap = new Dictionary<string, GetKindListResType>();
                }
                return _marketPriceKindMap;
            }
        }
        /// <summary>相場価格品質のマップを取得します。</summary>
        /// <remarks>キー：企業コード</remarks>
        private IDictionary<string, GetQualityListResType> MarketPriceQualityMap
        {
            get
            {
                if ( _marketPriceQualityMap == null )
                {
                    _marketPriceQualityMap = new Dictionary<string, GetQualityListResType>();
                }
                return _marketPriceQualityMap;
            }
        }
        /// <summary>相場価格地域のマップを取得します。</summary>
        /// <remarks>キー：企業コード</remarks>
        private IDictionary<string, GetAreaListResType> MarketPriceAreaMap
        {
            get
            {
                if ( _marketPriceAreaMap == null )
                {
                    _marketPriceAreaMap = new Dictionary<string, GetAreaListResType>();
                }
                return _marketPriceAreaMap;
            }
        }
        #endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        #region ■ Costructor
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public SobaServiceAcs()
        {
        }
        #endregion

        // ===================================================================================== //
        // パブリックメソッド
        // ===================================================================================== //
        #region ■ Public Method
        # region [相場価格情報取得]
        /// <summary>
        /// 相場価格情報取得
        /// </summary>
        /// <param name="marketPriceAcqCond"></param>
        /// <param name="scmMrktPriSt"></param>
        /// <returns></returns>
        public List<GetSobaResTypeUnitData> GetSobaResponce( MarketPriceAcqCond marketPriceAcqCond, SCMMrktPriSt scmMrktPriSt )
        {
            // 返却リスト初期化
            List<GetSobaResTypeUnitData> getSobaResTypeList = new List<GetSobaResTypeUnitData>();

            // 相場サービス生成
            if ( _sobaService == null )
            {
                _sobaService = new SobaService();
            }

            // 価格種別リスト
            List<int> kindCdList = new List<int>();
            kindCdList.Add( scmMrktPriSt.MarketPriceKindCd1 );
            kindCdList.Add( scmMrktPriSt.MarketPriceKindCd2 );
            kindCdList.Add( scmMrktPriSt.MarketPriceKindCd3 );

            for ( int index = 0; index < kindCdList.Count; index++ )
            {
                // 無効値なら迂回（-1:なし, 0:新品, 1:リビルト, 2:中古）
                if ( kindCdList[index] < 0 ) continue;

                // 相場情報取得
                GetSobaResTypeUnitData sobaRes = GetSobaResponceProc( marketPriceAcqCond, scmMrktPriSt, index );
                if ( sobaRes != null )
                {
                    getSobaResTypeList.Add( sobaRes );
                }
            }

            return getSobaResTypeList;
        }
        # endregion

        # region [相場価格算出]
        /// <summary>
        /// 相場価格算出処理
        /// </summary>
        /// <param name="sobaRes"></param>
        /// <param name="scmMrktPriSt"></param>
        /// <returns></returns>
        public static long GetMarketPrice( GetSobaResType sobaRes, SCMMrktPriSt scmMrktPriSt )
        {
            if ( sobaRes.SobaList != null && sobaRes.SobaList.Length > 0 )
            {
                double marketPriceResponse = (double)sobaRes.SobaList[0].StdDev;   // 標準偏差相場

                if ( scmMrktPriSt.MarketPriceAnswerDiv.Equals( (int)MarketPriceAnswerDiv.Rate ) )
                {
                    // 相場価格回答区分が「1:する(売価率)」の場合
                    double marketPriceSalesRate = scmMrktPriSt.MarketPriceSalesRate / 100.0;  // ∵100.0% は 100.0
                    long marketPrice = RoundingOff( marketPriceResponse * marketPriceSalesRate, scmMrktPriSt.FractionProcCd );
                    return marketPrice;
                }
                else if ( scmMrktPriSt.MarketPriceAnswerDiv.Equals( (int)MarketPriceAnswerDiv.Table ) )
                {
                    // 相場価格回答区分が「2:する(加算テーブル)」の場合
                    long marketPrice = GetMarketPriceFromAddTable( marketPriceResponse, scmMrktPriSt );
                    return marketPrice;
                }
            }

            return 0;
        }
        # endregion

        # region [名称取得]
        /// <summary>
        /// 相場価格種別名称を取得します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="marketPriceKindCd">種別コード</param>
        /// <returns>相場価格種別名称</returns>
        public string GetMarketPriceKindNm( string enterpriseCode, int marketPriceKindCd )
        {
            GetKindListResType foundKindListResponse = null;
            if ( MarketPriceKindMap.ContainsKey( enterpriseCode ) )
            {
                foundKindListResponse = MarketPriceKindMap[enterpriseCode];
            }
            else
            {
                try
                {
                    // 相場価格種別の情報取得
                    GetKindListReqType request = new GetKindListReqType();
                    {
                        request.UC = enterpriseCode; // 企業コード
                    }
                    KindService kindService = new KindService();
                    {
                        foundKindListResponse = kindService.GetKindList( request );
                    }
                    MarketPriceKindMap.Add( enterpriseCode, foundKindListResponse );
                }
                catch ( SoapException ex )
                {
                    foundKindListResponse = null;
                }
            }
            if ( foundKindListResponse == null ) return string.Empty;

            foreach ( KindType kindType in foundKindListResponse.KindList )
            {
                if ( marketPriceKindCd.Equals( kindType.KindCode ) ) return kindType.KindName;
            }
            return string.Empty;
        }
        /// <summary>
        /// 相場価格品質名称を取得します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="marketPriceKindCd">品質コード</param>
        /// <returns>相場価格品質名称</returns>
        public string GetMarketPriceQualityNm( string enterpriseCode, int marketPriceQualityCd )
        {
            GetQualityListResType foundQualityListResponse = null;
            if ( MarketPriceQualityMap.ContainsKey( enterpriseCode ) )
            {
                foundQualityListResponse = MarketPriceQualityMap[enterpriseCode];
            }
            else
            {
                try
                {
                    // 相場価格種別の品質取得
                    GetQualityListReqType request = new GetQualityListReqType();
                    {
                        request.UC = enterpriseCode; // 企業コード
                    }
                    QualityService QualityService = new QualityService();
                    {
                        foundQualityListResponse = QualityService.GetQualityList( request );
                    }
                    MarketPriceQualityMap.Add( enterpriseCode, foundQualityListResponse );
                }
                catch ( SoapException ex )
                {
                    foundQualityListResponse = null;
                }
            }
            if ( foundQualityListResponse == null ) return string.Empty;

            foreach ( QualityType QualityType in foundQualityListResponse.QualityList )
            {
                if ( marketPriceQualityCd.Equals( QualityType.QualityCode ) ) return QualityType.QualityName;
            }
            return string.Empty;
        }
        /// <summary>
        /// 相場価格地域名称を取得します。
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="marketPriceKindCd">地域コード</param>
        /// <returns>相場価格地域名称</returns>
        public string GetMarketPriceAreaNm( string enterpriseCode, int marketPriceAreaCd )
        {
            GetAreaListResType foundAreaListResponse = null;
            if ( MarketPriceAreaMap.ContainsKey( enterpriseCode ) )
            {
                foundAreaListResponse = MarketPriceAreaMap[enterpriseCode];
            }
            else
            {
                try
                {
                    // 相場価格地域の情報取得
                    GetAreaListReqType request = new GetAreaListReqType();
                    {
                        request.UC = enterpriseCode; // 企業コード
                    }
                    AreaService AreaService = new AreaService();
                    {
                        foundAreaListResponse = AreaService.GetAreaList( request );
                    }
                    MarketPriceAreaMap.Add( enterpriseCode, foundAreaListResponse );
                }
                catch ( SoapException ex )
                {
                    foundAreaListResponse = null;
                }
            }
            if ( foundAreaListResponse == null ) return string.Empty;

            foreach ( AreaType AreaType in foundAreaListResponse.AreaList )
            {
                if ( marketPriceAreaCd.Equals( AreaType.AreaCode ) ) return AreaType.AreaName;
            }
            return string.Empty;
        }
        # endregion
        #endregion

        // ===================================================================================== //
        // プライベートメソッド
        // ===================================================================================== //
        #region ■ Private Method

        # region [相場価格情報取得]
        /// <summary>
        /// 相場価格情報取得処理
        /// </summary>
        /// <param name="marketPriceAcqCond"></param>
        /// <param name="scmMrktPriSt"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private GetSobaResTypeUnitData GetSobaResponceProc( MarketPriceAcqCond marketPriceAcqCond, SCMMrktPriSt scmMrktPriSt, int index )
        {
            try
            {
                // 相場リクエスト条件
                GetSobaReqType request = CreateSobaRequest( marketPriceAcqCond, scmMrktPriSt, index );

                // 相場情報取得
                GetSobaResType response = _sobaService.GetSoba( request );

                // 結果が取得できなかったか、または
                // 取得した結果の金額がゼロの場合はデータなしと判断する
                if ( response == null ||
                     response.SobaList == null || 
                     response.SobaList.Length == 0 || 
                     response.SobaList[0].StdDev == 0 )
                {
                    return null;
                }

                return new GetSobaResTypeUnitData( request, response, index );
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        # endregion

        # region [相場リクエスト条件生成]
        /// <summary>
        /// 相場リクエスト条件生成
        /// </summary>
        /// <param name="marketPriceAcqCond"></param>
        /// <param name="scmMrktPriSt"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private GetSobaReqType CreateSobaRequest( MarketPriceAcqCond marketPriceAcqCond, SCMMrktPriSt scmMrktPriSt, int index )
        {
            GetSobaReqType request = new GetSobaReqType();

            request.UC = marketPriceAcqCond.EnterpriseCode; // 企業コード：ログイン情報
            request.AT = marketPriceAcqCond.AaccessTicket; // アクセスチケット
            request.GC = marketPriceAcqCond.GenerationCode; // ジェネレーションコード

            request.BLCodeList = GetBLCodeList( marketPriceAcqCond ); // BLコード
            request.Model = marketPriceAcqCond.RelevanceModel; // 関連型式
            request.AreaCode = scmMrktPriSt.MarketPriceAreaCd;  // 地区コード
            request.KindCode = GetMarketPriceKindCd( scmMrktPriSt, index ); // 種別コード(cd1 or cd2 or cd3)
            request.QualityCode = GetMarketPriceQualityCd( scmMrktPriSt, index ); // 品質コード(cd1 or cd2 or cd3)
            request.MtDateTime = new MtDateTimeType();

            return request;
        }
        /// <summary>
        /// BLコードリスト取得
        /// </summary>
        /// <param name="marketPriceAcqCond"></param>
        /// <returns></returns>
        private BLCodeType[] GetBLCodeList( MarketPriceAcqCond marketPriceAcqCond )
        {
            BLCodeType[] blCodeList = new BLCodeType[1];
            blCodeList[0] = new BLCodeType();
            blCodeList[0].BLCode = marketPriceAcqCond.BLGoodsCode.ToString();
            return blCodeList;
        }
        /// <summary>
        /// 相場価格種別コード取得
        /// </summary>
        /// <param name="marketPriceSetting"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private int GetMarketPriceKindCd( SCMMrktPriSt marketPriceSetting, int index )
        {
            switch ( index )
            {
                case 0: // 相場価格種別コード1
                    return marketPriceSetting.MarketPriceKindCd1;
                case 1: // 相場価格種別コード2
                    return marketPriceSetting.MarketPriceKindCd2;
                case 2: // 相場価格種別コード3
                    return marketPriceSetting.MarketPriceKindCd3;
                default:
                    return marketPriceSetting.MarketPriceKindCd1;
            }
        }
        /// <summary>
        /// 相場価格品質コード取得
        /// </summary>
        /// <param name="marketPriceSetting"></param>
        /// <param name="marketPriceQualityCd"></param>
        /// <returns></returns>
        private int GetMarketPriceQualityCd( SCMMrktPriSt marketPriceSetting, int index )
        {
            switch ( index )
            {
                case 0: // 相場価格品質コード1
                    return marketPriceSetting.MarketPriceQualityCd;
                case 1: // 相場価格品質コード2
                    return marketPriceSetting.MarketPriceQualityCd2;
                case 2: // 相場価格品質コード3
                    return marketPriceSetting.MarketPriceQualityCd3;
                default:
                    return marketPriceSetting.MarketPriceQualityCd;
            }
        }
        # endregion

        # region [相場価格算出用]
        /// <summary>
        /// 相場価格を加算テーブルより取得します。
        /// </summary>
        /// <param name="marketPrice">相場価格</param>
        /// <param name="marketPriceSetting">SCM相場価格設定</param>
        /// <returns></returns>
        private static long GetMarketPriceFromAddTable( double marketPrice, SCMMrktPriSt marketPriceSetting )
        {
            long nMarketPrice = (long)marketPrice;
            {
                // 1以上～○○円未満(加算範囲1)
                if ( 1.0 <= marketPrice && marketPrice <= (double)marketPriceSetting.AddPaymntAmbit1 )
                {
                    nMarketPrice += (long)marketPriceSetting.AddPaymnt1;
                }
                // 加算額範囲1を超え～○○円以下(加算範囲2)
                else if ( (double)marketPriceSetting.AddPaymntAmbit1 < marketPrice && marketPrice <= (double)marketPriceSetting.AddPaymntAmbit2 )
                {
                    nMarketPrice += (long)marketPriceSetting.AddPaymnt2;
                }
                // 加算額範囲2を超え～○○円以下(加算範囲3)
                else if ( (double)marketPriceSetting.AddPaymntAmbit2 < marketPrice && marketPrice <= (double)marketPriceSetting.AddPaymntAmbit3 )
                {
                    nMarketPrice += (long)marketPriceSetting.AddPaymnt3;
                }
                // 加算額範囲3を超え～○○円以下(加算範囲4)
                else if ( (double)marketPriceSetting.AddPaymntAmbit3 < marketPrice && marketPrice <= (double)marketPriceSetting.AddPaymntAmbit4 )
                {
                    nMarketPrice += (long)marketPriceSetting.AddPaymnt4;
                }
                // 加算額範囲4を超え～○○円以下(加算範囲5)
                else if ( (double)marketPriceSetting.AddPaymntAmbit4 < marketPrice && marketPrice <= (double)marketPriceSetting.AddPaymntAmbit5 )
                {
                    nMarketPrice += (long)marketPriceSetting.AddPaymnt5;
                }
                // 加算額範囲5を超え～○○円以下(加算範囲6)
                else if ( (double)marketPriceSetting.AddPaymntAmbit5 < marketPrice && marketPrice <= (double)marketPriceSetting.AddPaymntAmbit6 )
                {
                    nMarketPrice += (long)marketPriceSetting.AddPaymnt6;
                }
                // 加算額範囲6を超え～○○円以下(加算範囲7)
                else if ( (double)marketPriceSetting.AddPaymntAmbit6 < marketPrice && marketPrice <= (double)marketPriceSetting.AddPaymntAmbit7 )
                {
                    nMarketPrice += (long)marketPriceSetting.AddPaymnt7;
                }
                // 加算額範囲7を超え～○○円以下(加算範囲8)
                else if ( (double)marketPriceSetting.AddPaymntAmbit7 < marketPrice && marketPrice <= (double)marketPriceSetting.AddPaymntAmbit8 )
                {
                    nMarketPrice += (long)marketPriceSetting.AddPaymnt8;
                }
                // 加算額範囲8を超え～○○円以下(加算範囲9)
                else if ( (double)marketPriceSetting.AddPaymntAmbit8 < marketPrice && marketPrice <= (double)marketPriceSetting.AddPaymntAmbit9 )
                {
                    nMarketPrice += (long)marketPriceSetting.AddPaymnt9;
                }
                // 加算額範囲9を超え～○○円以下(加算範囲10)
                else if ( (double)marketPriceSetting.AddPaymntAmbit9 < marketPrice && marketPrice <= (double)marketPriceSetting.AddPaymntAmbit10 )
                {
                    nMarketPrice += (long)marketPriceSetting.AddPaymnt10;
                }
            }
            nMarketPrice = RoundingOff( (double)nMarketPrice, marketPriceSetting.FractionProcCd );
            return nMarketPrice;
        }
        /// <summary>
        /// 相場価格を四捨五入します。
        /// </summary>
        /// <param name="marketPrice">相場価格</param>
        /// <param name="fractionProcCd">端数処理区分</param>
        /// <returns>四捨五入した相場価格</returns>
        private static long RoundingOff( double marketPrice, int fractionProcCd )
        {
            long nMarketPrice = (long)marketPrice;
            int targetIndex = -1;
            int addValue = 0;
            switch ( fractionProcCd )
            {
                case (int)FractionProcCd.RoundingOff10Yen:
                    {
                        if ( marketPrice <= 10.0 ) return nMarketPrice;
                        targetIndex = nMarketPrice.ToString().Length - 1;
                        addValue = 10;
                        break;
                    }
                case (int)FractionProcCd.RoundingOff100Yen:
                    {
                        if ( marketPrice <= 100.0 ) return nMarketPrice;
                        targetIndex = nMarketPrice.ToString().Length - 2;
                        addValue = 100;
                        break;
                    }
                default:
                    return nMarketPrice;
            }
            string strMarketPrice = nMarketPrice.ToString();

            // 対象桁以降を0に設定
            char[] chrMarketPrices = strMarketPrice.ToCharArray();
            for ( int i = strMarketPrice.Length - 1; i > targetIndex; i-- )
            {
                chrMarketPrices[i] = '0';
            }

            if ( int.Parse( chrMarketPrices[targetIndex].ToString() ) <= 4 )
            {
                // 四捨
                chrMarketPrices[targetIndex] = '0';
                strMarketPrice = new string( chrMarketPrices );
                addValue = 0;
            }
            else
            {
                // 五入
                chrMarketPrices[targetIndex] = '0';
                strMarketPrice = new string( chrMarketPrices );
            }
            nMarketPrice = long.Parse( strMarketPrice ) + addValue;

            return nMarketPrice;
        }
        # endregion

        #endregion

    }
}

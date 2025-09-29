//****************************************************************************//
// ƒVƒXƒeƒ€         : ©“­‰ñ“šˆ—
// ƒvƒƒOƒ‰ƒ€–¼Ì   : ©“­‰ñ“šˆ—ƒAƒNƒZƒX
// ƒvƒƒOƒ‰ƒ€ŠT—v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// —š—ğ
//----------------------------------------------------------------------------//
// ŠÇ—”Ô†              ì¬’S“– : H“¡ Œb—D
// ì ¬ “ú  2009/05/22  C³“à—e : V‹Kì¬
//----------------------------------------------------------------------------//
using System;
using System.Diagnostics;

using Broadleaf.Application.Controller.Agent;
using Broadleaf.Application.UIData;
using Broadleaf.RCDS.Web.Services;

namespace Broadleaf.Application.Controller.Util
{
    using SCMMarketPriceServer = SingletonInstance<SCMMarketPriceAgent>;    // SCM‘Šê‰¿Šiİ’èƒ}ƒXƒ^

    /// <summary>
    /// SCM‘Šêî•ñƒŒƒXƒ|ƒ“ƒX‚Ìƒwƒ‹ƒpƒNƒ‰ƒX
    /// </summary>
    public class SCMSobaResponseHelper
    {
        private const string MY_NAME = "SCMSobaResponseHelper"; // ƒƒO—p

        #region <SCM‘Šê‰¿Šiİ’è>

        /// <summary>SCM‘Šê‰¿Šiİ’è</summary>
        private readonly SCMMrktPriSt _marketPriceSetting;
        /// <summary>SCM‘Šê‰¿Šiİ’è‚ğæ“¾‚µ‚Ü‚·B</summary>
        private SCMMrktPriSt MarketPriceSetting {  get { return _marketPriceSetting; } }

        /// <summary>‘Šê‰¿Šií•Ê”Ô†</summary>
        private readonly int _marketPriceKindNo;
        /// <summary>‘Šê‰¿Šií•Ê”Ô†‚ğæ“¾‚µ‚Ü‚·B</summary>
        private int MarketPriceKindNo { get { return _marketPriceKindNo; } }

        /// <summary>
        /// ‘Šê‰¿Šiİ’èƒ}ƒXƒ^‚ğæ“¾‚µ‚Ü‚·B
        /// </summary>
        private static SCMMarketPriceAgent MarketPriceDB
        {
            get { return SCMMarketPriceServer.Singleton.Instance; }
        }

        #endregion // </SCM‘Šê‰¿Šiİ’è>

        #region <–{•¨‚ÌƒŒƒXƒ|ƒ“ƒX>

        /// <summary>–{•¨‚ÌƒŒƒXƒ|ƒ“ƒX</summary>
        private readonly GetSobaResType _realResponse;
        /// <summary>–{•¨‚ÌƒŒƒXƒ|ƒ“ƒX‚ğæ“¾‚µ‚Ü‚·B</summary>
        public GetSobaResType RealResponse { get { return _realResponse; } }

        /// <summary>
        /// ‘Šêî•ñ‚ª‘¶İ‚·‚é‚©”»’f‚µ‚Ü‚·B
        /// </summary>
        public bool Exists
        {
            get { return RealResponse != null && Count > 0; }
        }

        #endregion // </–{•¨‚ÌƒŒƒXƒ|ƒ“ƒX>

        #region <Constructor>

        /// <summary>
        /// ƒJƒXƒ^ƒ€ƒRƒ“ƒXƒgƒ‰ƒNƒ^
        /// </summary>
        /// <param name="marketPriceSetting">‘Šê‰¿Šiİ’è</param>
        /// <param name="marketPriceKindNo">‘Šê‰¿Šií•Ê”Ô†</param>
        /// <param name="realResponse">–{•¨‚ÌƒŒƒXƒ|ƒ“ƒX</param>
        public SCMSobaResponseHelper(
            SCMMrktPriSt marketPriceSetting,
            int marketPriceKindNo,
            GetSobaResType realResponse
        )
        {
            _marketPriceSetting = marketPriceSetting;
            _marketPriceKindNo  = marketPriceKindNo;
            _realResponse       = realResponse;
        }

        #endregion // </Constructor>

        /// <summary>
        /// Œ”‚ğæ“¾‚µ‚Ü‚·B
        /// </summary>
        private int Count
        {
            get
            {
                if (RealResponse == null || RealResponse.SobaList == null)
                {
                    return 0;
                }
                return RealResponse.SobaList[0].Cnt;
            }
        }

        /// <summary>
        /// ‘Šê‰¿Šií•ÊƒR[ƒh‚ğæ“¾‚µ‚Ü‚·B
        /// </summary>
        public int MarketPriceKindCd
        {
            get
            {
                return SCMMarketPriceAgent.GetMarketPriceKindCd(MarketPriceSetting, MarketPriceKindNo);
            }
        }

        /// <summary>
        /// ‘Šê‰¿Šií•Ê–¼Ì‚ğæ“¾‚µ‚Ü‚·B
        /// </summary>
        public string MarketPriceKindNm
        {
            get
            {
                return MarketPriceDB.GetMarketPriceKindNm(MarketPriceSetting, MarketPriceKindNo);
            }
        }

        /// <summary>
        /// ‘Šê‰¿Ši‚ğæ“¾‚µ‚Ü‚·B
        /// </summary>
        /// <returns>‘Šê‰¿Ši</returns>
        public long GetMarketPrice()
        {
            const string METHOD_NAME = "GetMarketPrice()";  // ƒƒO—p

            #region <Guard Phrase>

            if (!Exists) return 0;
            if (MarketPriceSetting == null) return 0;

            #endregion // </Guard Phrase>

            double marketPriceResponse = (double)RealResponse.SobaList[0].StdDev;   // •W€•Î·‘Šê

            // ‘Šê‰¿Ši‰ñ“š‹æ•ª‚ªu1:‚·‚é(”„‰¿—¦)v‚Ìê‡
            if (MarketPriceSetting.MarketPriceAnswerDiv.Equals((int)MarketPriceAnswerDiv.Rate))
            {
                #region <Log>

                string msg = "”„‰¿—¦‚©‚ç‘Šê‰¿Ši‚ğZo";
                EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                #endregion // </Log>

                double marketPriceSalesRate = MarketPriceSetting.MarketPriceSalesRate / 100.0;  // æ100.0% ‚Í 100.0

                long marketPrice = RoundingOff(
                    marketPriceResponse * marketPriceSalesRate,
                    MarketPriceSetting.FractionProcCd
                );
                return marketPrice;
            }

            // ‘Šê‰¿Ši‰ñ“š‹æ•ª‚ªu2:‚·‚é(‰ÁZƒe[ƒuƒ‹)v‚Ìê‡
            if (MarketPriceSetting.MarketPriceAnswerDiv.Equals((int)MarketPriceAnswerDiv.Table))
            {
                #region <Log>

                string msg = "‰ÁZƒe[ƒuƒ‹‚©‚ç‘Šê‰¿Ši‚ğZo";
                EasyLogger.WriteDebugLog(MY_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                #endregion // </Log>

                long marketPrice = GetMarketPriceFromAddTable(marketPriceResponse, MarketPriceSetting);
                return marketPrice;
            }

            return 0;
        }

        #region <‘Šê‰¿Ši‚ÌZo>

        /// <summary>
        /// ‘Šê‰¿Ši‚ğ‰ÁZƒe[ƒuƒ‹‚æ‚èæ“¾‚µ‚Ü‚·B
        /// </summary>
        /// <param name="marketPrice">‘Šê‰¿Ši</param>
        /// <param name="marketPriceSetting">SCM‘Šê‰¿Šiİ’è</param>
        /// <returns></returns>
        private static long GetMarketPriceFromAddTable(
            double marketPrice,
            SCMMrktPriSt marketPriceSetting
        )
        {
            long nMarketPrice = (long)marketPrice;
            {
                // 1ˆÈã`››‰~–¢–(‰ÁZ”ÍˆÍ1)
                if (1.0 <= marketPrice && marketPrice <= (double)marketPriceSetting.AddPaymntAmbit1)
                {
                    nMarketPrice += (long)marketPriceSetting.AddPaymnt1;
                }
                // ‰ÁZŠz”ÍˆÍ1‚ğ’´‚¦`››‰~ˆÈ‰º(‰ÁZ”ÍˆÍ2)
                else if ((double)marketPriceSetting.AddPaymntAmbit1 < marketPrice && marketPrice <= (double)marketPriceSetting.AddPaymntAmbit2)
                {
                    nMarketPrice += (long)marketPriceSetting.AddPaymnt2;
                }
                // ‰ÁZŠz”ÍˆÍ2‚ğ’´‚¦`››‰~ˆÈ‰º(‰ÁZ”ÍˆÍ3)
                else if ((double)marketPriceSetting.AddPaymntAmbit2 < marketPrice && marketPrice <= (double)marketPriceSetting.AddPaymntAmbit3)
                {
                    nMarketPrice += (long)marketPriceSetting.AddPaymnt3;
                }
                // ‰ÁZŠz”ÍˆÍ3‚ğ’´‚¦`››‰~ˆÈ‰º(‰ÁZ”ÍˆÍ4)
                else if ((double)marketPriceSetting.AddPaymntAmbit3 < marketPrice && marketPrice <= (double)marketPriceSetting.AddPaymntAmbit4)
                {
                    nMarketPrice += (long)marketPriceSetting.AddPaymnt4;
                }
                // ‰ÁZŠz”ÍˆÍ4‚ğ’´‚¦`››‰~ˆÈ‰º(‰ÁZ”ÍˆÍ5)
                else if ((double)marketPriceSetting.AddPaymntAmbit4 < marketPrice && marketPrice <= (double)marketPriceSetting.AddPaymntAmbit5)
                {
                    nMarketPrice += (long)marketPriceSetting.AddPaymnt5;
                }
                // ‰ÁZŠz”ÍˆÍ5‚ğ’´‚¦`››‰~ˆÈ‰º(‰ÁZ”ÍˆÍ6)
                else if ((double)marketPriceSetting.AddPaymntAmbit5 < marketPrice && marketPrice <= (double)marketPriceSetting.AddPaymntAmbit6)
                {
                    nMarketPrice += (long)marketPriceSetting.AddPaymnt6;
                }
                // ‰ÁZŠz”ÍˆÍ6‚ğ’´‚¦`››‰~ˆÈ‰º(‰ÁZ”ÍˆÍ7)
                else if ((double)marketPriceSetting.AddPaymntAmbit6 < marketPrice && marketPrice <= (double)marketPriceSetting.AddPaymntAmbit7)
                {
                    nMarketPrice += (long)marketPriceSetting.AddPaymnt7;
                }
                // ‰ÁZŠz”ÍˆÍ7‚ğ’´‚¦`››‰~ˆÈ‰º(‰ÁZ”ÍˆÍ8)
                else if ((double)marketPriceSetting.AddPaymntAmbit7 < marketPrice && marketPrice <= (double)marketPriceSetting.AddPaymntAmbit8)
                {
                    nMarketPrice += (long)marketPriceSetting.AddPaymnt8;
                }
                // ‰ÁZŠz”ÍˆÍ8‚ğ’´‚¦`››‰~ˆÈ‰º(‰ÁZ”ÍˆÍ9)
                else if ((double)marketPriceSetting.AddPaymntAmbit8 < marketPrice && marketPrice <= (double)marketPriceSetting.AddPaymntAmbit9)
                {
                    nMarketPrice += (long)marketPriceSetting.AddPaymnt9;
                }
                // ‰ÁZŠz”ÍˆÍ9‚ğ’´‚¦`››‰~ˆÈ‰º(‰ÁZ”ÍˆÍ10)
                else if ((double)marketPriceSetting.AddPaymntAmbit9 < marketPrice && marketPrice <= (double)marketPriceSetting.AddPaymntAmbit10)
                {
                    nMarketPrice += (long)marketPriceSetting.AddPaymnt10;
                }
            }
            nMarketPrice = RoundingOff((double)nMarketPrice, marketPriceSetting.FractionProcCd);
            return nMarketPrice;
        }

        /// <summary>
        /// ‘Šê‰¿Ši‚ğlÌŒÜ“ü‚µ‚Ü‚·B
        /// </summary>
        /// <param name="marketPrice">‘Šê‰¿Ši</param>
        /// <param name="fractionProcCd">’[”ˆ—‹æ•ª</param>
        /// <returns>lÌŒÜ“ü‚µ‚½‘Šê‰¿Ši</returns>
        private static long RoundingOff(
            double marketPrice,
            int fractionProcCd
        )
        {
            long nMarketPrice = (long)marketPrice;
            int targetIndex = -1;
            int addValue = 0;
            switch (fractionProcCd)
            {
                case (int)FractionProcCd.RoundingOff10Yen:
                    {
                        if (marketPrice <= 10.0) return nMarketPrice;
                        targetIndex = nMarketPrice.ToString().Length - 1;
                        addValue = 10;
                        break;
                    }
                case (int)FractionProcCd.RoundingOff100Yen:
                    {
                        if (marketPrice <= 100.0) return nMarketPrice;
                        targetIndex = nMarketPrice.ToString().Length - 2;
                        addValue = 100;
                        break;
                    }
                default:
                    return nMarketPrice;
            }
            string strMarketPrice = nMarketPrice.ToString();

            // ‘ÎÛŒ…ˆÈ~‚ğ0‚Éİ’è
            char[] chrMarketPrices = strMarketPrice.ToCharArray();
            for (int i = strMarketPrice.Length - 1; i > targetIndex; i--)
            {
                chrMarketPrices[i] = '0';
            }
            
            if (int.Parse(chrMarketPrices[targetIndex].ToString()) <= 4)
            {
                // lÌ
                chrMarketPrices[targetIndex] = '0';
                strMarketPrice = new string(chrMarketPrices);
                addValue = 0;
            }
            else
            {   
                // ŒÜ“ü
                chrMarketPrices[targetIndex] = '0';
                strMarketPrice = new string(chrMarketPrices);
            }
            nMarketPrice = long.Parse(strMarketPrice) + addValue;

            return nMarketPrice;
        }

        #endregion // </‘Šê‰¿Ši‚ÌZo>
    }
}

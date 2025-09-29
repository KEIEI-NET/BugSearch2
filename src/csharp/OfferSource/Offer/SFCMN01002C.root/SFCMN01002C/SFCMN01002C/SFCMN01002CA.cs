using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting;

namespace Broadleaf.ServiceProcess
{
    /// <summary>
    /// 提供APリモートプロキシサーバークラスリソース
    /// </summary>
    /// <remarks>
    /// <br>Note       : このクラスはリモートオブジェクトのプロキシクラス用リソースです。</br>
    /// <br>Programmer : 96137　久保田　信一</br>
    /// <br>Date       : 2005.07.20</br>
    /// <br></br>
    /// <br>Update Note: 2012/06/01  980035 金沢 貞義</br>
    /// <br>             SCM改良</br>
    /// <br></br>
    /// <br>Update Note: 2013/02/19  980035 金沢 貞義</br>
    /// <br>             2013年03月改良（PM.NS強化月間対応）</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public class Tbs002ServerServiceResource
    {
        /// <summary>
        /// リソース情報取得
        /// </summary>
        /// <returns>リソース情報</returns>
        public static List<RemoteAssemblyInfo> GetRemoteResource()
        {
            List<RemoteAssemblyInfo> retList = new List<RemoteAssemblyInfo>();

            #region 置換開始位置

            # region [1次分+1.5次分]
            // 1次分+1.5次分
            //retList.Add( new RemoteAssemblyInfo( "", "PMTKD01211R.DLL", "Broadleaf.Application.Remoting.JoinPartsDB", "MyAppJoinParts", WellKnownObjectMode.Singleton ) );
            //retList.Add( new RemoteAssemblyInfo( "", "PMTKD01221R.DLL", "Broadleaf.Application.Remoting.SetPartsDB", "MyAppSetParts", WellKnownObjectMode.Singleton ) );
            ////retList.Add( new RemoteAssemblyInfo( "", "PMTKD01104R.DLL", "Broadleaf.Application.Remoting.DeleteOfferDB", "MyAppDeleteOffer", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMTKD00011R.DLL", "Broadleaf.Application.Remoting.VersionChkTkdWorkDB", "MyAppVersionChkTkdWork", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMTKD09111R.DLL", "Broadleaf.Application.Remoting.SearchPrtCtlDB", "MyAppSearchPrtCtl", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMTKD09222R.DLL", "Broadleaf.Application.Remoting.MergeDataGetDB", "MyAppMergeDataGet", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMTKD09091R.DLL", "Broadleaf.Application.Remoting.OfrSupplierDB", "MyAppOfrSupplier", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMCMN06111R.DLL", "Broadleaf.Application.Remoting.SyncProcessDB", "MyAppSyncProcess", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMCMN06211R.DLL", "Broadleaf.Application.Remoting.SyncInfoDB", "MyAppSyncInfo", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMTKD06161R.DLL", "Broadleaf.Application.Remoting.OfferPartsInfDB", "MyAppOfferPartsInf", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMTKD09081R.DLL", "Broadleaf.Application.Remoting.PartsPosCodeDB", "MyAppPartsPosCode", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMTKD06032R.DLL", "Broadleaf.Application.Remoting.OfferPrimeBlSearchDB", "MyAppOfferPrimeBlSearch", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMTKD06072R.DLL", "Broadleaf.Application.Remoting.TBOSearchInfDB", "MyAppTBOSearchInf", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMTKD06091R.DLL", "Broadleaf.Application.Remoting.ClgPrmPartsInfoSearchDB", "MyAppClgPrmPartsInfoSearch", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMTKD09021R.DLL", "Broadleaf.Application.Remoting.PrimeSettingDB", "MyAppPrimeSetting", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMTKD09061R.DLL", "Broadleaf.Application.Remoting.PrimePartsInfDB", "MyAppPrimePartsInf", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMTKD09071R.DLL", "Broadleaf.Application.Remoting.ModelNameDB", "MyAppModelName", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMTKD08004R.DLL", "Broadleaf.Application.Remoting.FrePSalesSlipOfferDB", "MyAppFrePSalesSlipOffer", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMTKD09041R.DLL", "Broadleaf.Application.Remoting.BLGroupDB", "MyAppBLGroup", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMTKD09051R.DLL", "Broadleaf.Application.Remoting.GoodsMGroupDB", "MyAppGoodsMGroup", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMTKD09031R.DLL", "Broadleaf.Application.Remoting.TbsPartsCodeDB", "MyAppTbsPartsCode", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMTKD06101R.DLL", "Broadleaf.Application.Remoting.CarModelCtlDB", "MyAppCarModelCtl", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMTKD06111R.DLL", "Broadleaf.Application.Remoting.CarModelSearchDB", "MyAppCarModelSearch", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMTKD06121R.DLL", "Broadleaf.Application.Remoting.ColTrmEquInfDB", "MyAppColTrmEquInf", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMTKD06131R.DLL", "Broadleaf.Application.Remoting.PrdTypYearDB", "MyAppPrdTypYear", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMTKD06141R.DLL", "Broadleaf.Application.Remoting.CategoryEquipmentDB", "MyAppCategoryEquipment", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMTKD06151R.DLL", "Broadleaf.Application.Remoting.CtgyMdlLnkDB", "MyAppCtgyMdlLnk", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "SFTKD08114R.DLL", "Broadleaf.Application.Remoting.PrtItemSetDB", "MyAppPrtItemSet", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "SFTKD08154R.DLL", "Broadleaf.Application.Remoting.FPprSchmGrDB", "MyAppFPprSchmGr", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "DCKHN09054R.DLL", "Broadleaf.Application.Remoting.OfrGoodsPriceDB", "MyAppOfrGoodsPrice", WellKnownObjectMode.Singleton ) );
            //retList.Add(new RemoteAssemblyInfo("", "DCKHN09064R.DLL", "Broadleaf.Application.Remoting.OfrLGoodsGanreDB", "MyAppOfrLGoodsGanre", WellKnownObjectMode.Singleton));
            retList.Add( new RemoteAssemblyInfo( "", "DCKHN09074R.DLL", "Broadleaf.Application.Remoting.OfrMGoodsGanreDB", "MyAppOfrMGoodsGanre", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "DCKHN09084R.DLL", "Broadleaf.Application.Remoting.OfrDGoodsGanreDB", "MyAppOfrDGoodsGanre", WellKnownObjectMode.Singleton ) );
            //retList.Add(new RemoteAssemblyInfo("", "DCKHN09114R.DLL", "Broadleaf.Application.Remoting.RateMngGoodsDB", "MyAppRateMngGoods", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "DCKHN09124R.DLL", "Broadleaf.Application.Remoting.RateMngCustDB", "MyAppRateMngCust", WellKnownObjectMode.Singleton));
            retList.Add( new RemoteAssemblyInfo( "", "DCTKD09024R.DLL", "Broadleaf.Application.Remoting.MnyKindDivDB", "MyAppMnyKindDiv", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "MACMN00134R.DLL", "Broadleaf.Application.Remoting.GoodsRelationDataDB", "MyAppGoodsRelationData", WellKnownObjectMode.Singleton ) );
            //retList.Add(new RemoteAssemblyInfo("", "MATKD08114R.DLL", "Broadleaf.Application.Remoting.GoodsDB", "MyAppGoods", WellKnownObjectMode.Singleton));
            //retList.Add(new RemoteAssemblyInfo("", "MATKD08184R.DLL", "Broadleaf.Application.Remoting.MakerDB", "MyAppMaker", WellKnownObjectMode.Singleton));
            //retList.Add( new RemoteAssemblyInfo( "", "MATKD08244R.DLL", "Broadleaf.Application.Remoting.BLGoodsCdDB", "MyAppBLGoodsCd", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "SFCMN00014R.DLL", "Broadleaf.Application.Remoting.RemoteDB", "MyAppRemote", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "SFCMN00322R.DLL", "Broadleaf.Application.Remoting.TransferSpeedCheckDB", "MyAppTransferSpeedCheck", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "SFTKD00422R.DLL", "Broadleaf.Application.Remoting.OfferAddressInfoDB", "OfferAddressInfo", WellKnownObjectMode.Singleton ) );
            //retList.Add( new RemoteAssemblyInfo( "", "SFTKD00432R.DLL", "Broadleaf.Application.Remoting.OfferPartsInfDB", "MyAppOfferPartsInf", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "SFTKD02012R.DLL", "Broadleaf.Application.Remoting.PostNumberDB", "MyAppPostNumber", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "SFTKD02072R.DLL", "Broadleaf.Application.Remoting.PMakerNmDB", "MyAppPMakerNm", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "SFTKD08042R.DLL", "Broadleaf.Application.Remoting.UserGdBdDB", "MyAppUserGdBd", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "SFUKK09048R.DLL", "Broadleaf.Application.Remoting.MnyKindDivDB", "MyAppMnyKindDiv", WellKnownObjectMode.Singleton ) );
            # endregion

            # region [SCM]
            // SCM
            //retList.Add( new RemoteAssemblyInfo( "", "PMTKD09101R.DLL", "Broadleaf.Application.Remoting.TbsPartsCodeChgDB", "MyAppTbsPartsCodeChg", WellKnownObjectMode.Singleton ) );
            // --- ADD s.Kanazawa 2012/06/01 ---------->>>>>
            retList.Add(new RemoteAssemblyInfo("", "PMTKD09120R.DLL", "Broadleaf.Application.Remoting.AutoEstmPtNoChgDB", "MyAppAutoEstmPtNoChg", WellKnownObjectMode.Singleton));
            // --- ADD s.Kanazawa 2012/06/01 ----------<<<<<
            # endregion

            # region [3次分]
            // 3次分
            retList.Add( new RemoteAssemblyInfo( "", "PMTKD01104R.DLL", "Broadleaf.Application.Remoting.OfferDataDeleteDB", "MyAppOfferDataDelete", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMTKD01211R.DLL", "Broadleaf.Application.Remoting.JoinPartsDB", "MyAppJoinParts", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMTKD01221R.DLL", "Broadleaf.Application.Remoting.SetPartsDB", "MyAppSetParts", WellKnownObjectMode.Singleton ) );
            # endregion

            // --- ADD s.Kanazawa 2013/02/19 ---------->>>>>
            # region [2013年03月改良]
            // 2013年03月改良
            retList.Add(new RemoteAssemblyInfo("", "PMKHN09911R.DLL", "Broadleaf.Application.Remoting.PureSettingPmDB", "MyAppPureSettingPm", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMKHN09915R.DLL", "Broadleaf.Application.Remoting.PartsLayerStPmDB", "MyAppPartsLayerStPm", WellKnownObjectMode.Singleton));
            # endregion
            // --- ADD s.Kanazawa 2013/02/19 ----------<<<<<

            //# region [キャンペーン管理]
            //retList.Add( new RemoteAssemblyInfo( "", "PMTKD09301R.DLL", "Broadleaf.Application.Remoting.PtMkrPricePmDB", "MyAppPtMkrPricePm", WellKnownObjectMode.Singleton ) );
            //# endregion

            //--- ADD 2013/07/29 m.suzuki --->>>>>
            # region [PMタブレット(201308)]
            retList.Add( new RemoteAssemblyInfo( "", "SFTKD00402R.DLL", "Broadleaf.Application.Remoting.CategoryModelDesiguationDB", "MyAppCategoryModelDesiguation", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "SFTKD00512R.DLL", "Broadleaf.Application.Remoting.ColorCodeDB", "MyAppColorCode", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "SFTKD00552R.DLL", "Broadleaf.Application.Remoting.CarModelDB", "MyAppCarModel", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "SFTKD00562R.DLL", "Broadleaf.Application.Remoting.CtgyMdlLnkDB", "MyAppCtgyMdlLnk", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "SFTKD00682R.DLL", "Broadleaf.Application.Remoting.ColorDspDtDB", "MyAppColorDspDt", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "SFTKD01204R.DLL", "Broadleaf.Application.Remoting.CarMakerDB", "MyAppCarMaker", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "SFTKD01224R.DLL", "Broadleaf.Application.Remoting.ModelNameDB", "MyAppModelName", WellKnownObjectMode.Singleton ) );
            # endregion
            //--- ADD 2013/07/29 m.suzuki ---<<<<<

            #endregion 置換終了位置

            return retList;
        }
    }
}

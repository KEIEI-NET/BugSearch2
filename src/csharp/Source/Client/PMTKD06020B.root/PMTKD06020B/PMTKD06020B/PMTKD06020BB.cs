using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Controller
{
    class SearchPrtCtlAcs
    {
        /// <summary>0:標準 20:外装</summary>
        private int _searchPrtTyp;
        /// <summary>0:大型契約なし 1:大型契約あり</summary>
        private int _bigCarOfferDiv;
        /// <summary>0:2輪契約なし 1:2輪契約あり</summary>
        private int _bikeSearch;
        /// <summary>0:タクティ検索契約なし 1:タクティ検索契約あり</summary>
        private int _tactiSearch;
        private List<int> currentList;
        private List<int>[] lstSearchPrt;

        /// <summary>0:2輪契約なし 1:2輪契約あり</summary>
        public int BikeSearch
        {
            get { return _bikeSearch; }
        }

        /// <summary>0:タクティ検索契約なし 1:タクティ検索契約あり</summary>
        public int TactiSearch
        {
            get { return _tactiSearch; }
        }

        //>>>2010/03/29
        /// <summary>0:大型契約なし 1:大型契約あり</summary>
        public int BigCarOfferDiv
        {
            get { return _bigCarOfferDiv; }
        }
        //<<<2010/03/29

        /// <summary>
        /// コンストラクター
        /// </summary>
        ///// <param name="searchPrtTyp">検索タイプ</param>
        ///// <param name="bigCarOfferDiv">大型提供区分</param>
        public SearchPrtCtlAcs()//int searchPrtTyp, int bigCarOfferDiv)
        {
            lstSearchPrt = new List<int>[6];
            for (int i = 0; i < 6; i++)
            {
                lstSearchPrt[i] = new List<int>();
            }
            // 検索無しは-1
            _searchPrtTyp = -1;

            // 基本提供データ 契約状況
            PurchaseStatus psBasicOffer = LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_BasicOfferData);
            // 大型提供区分 契約状況
            // 2009/10/23 >>>
            //PurchaseStatus psBigCarOffer = LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_OutsideOfferData);
            PurchaseStatus psBigCarOffer = LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_BigCarOfferData);
            // 2009/10/23 <<<
            // 検索Bタイプ（外装） 契約状況
            // 2009/10/23 >>>
            //PurchaseStatus psPrtTyp = LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_BigCarOfferData);
            PurchaseStatus psPrtTyp = LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_OutsideOfferData);
            // 2009/10/23 <<<
            // 2輪検索契約状況
            PurchaseStatus psBikeSearch = LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_BikeSearch);
            // タクティ検索契約状況
            PurchaseStatus psTactiSearch = LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_TactiSearch);

            if (psBigCarOffer == PurchaseStatus.Contract || psBigCarOffer == PurchaseStatus.Trial_Contract)   // 大型契約あり
                _bigCarOfferDiv = 1;
            if (psBasicOffer == PurchaseStatus.Contract || psBasicOffer == PurchaseStatus.Trial_Contract) // 基本提供データ
                _searchPrtTyp = 10;
            if (psPrtTyp == PurchaseStatus.Contract || psPrtTyp == PurchaseStatus.Trial_Contract) // 外装契約あり
                _searchPrtTyp = 20;
            if (psBikeSearch == PurchaseStatus.Contract || psBikeSearch == PurchaseStatus.Trial_Contract) // 2輪契約あり
                _bikeSearch = 1;
            if (psTactiSearch == PurchaseStatus.Contract || psTactiSearch == PurchaseStatus.Trial_Contract) // タクティ検索契約あり
                _tactiSearch = 1;

            //_searchPrtTyp = 0; // test
            int ind = 0;
            switch (_searchPrtTyp)
            {
                case 0: // 0:標準 
                    ind = 0 + _bigCarOfferDiv;
                    break;
                case 10: // 10:拡張
                    ind = 2 + _bigCarOfferDiv;
                    break;
                case 20: // 20:外装
                    ind = 4 + _bigCarOfferDiv;
                    break;
            }
            currentList = lstSearchPrt[ind];
        }

        /// <summary>
        /// リモートからの検索品目リストを設定する。
        /// </summary>        
        /// <param name="lst">リスト</param>
        public void AddList(ArrayList lst)
        {
            foreach (SearchPrtCtlWork searchPrtCtlWork in lst)
            {
                int ind = 0;
                switch (searchPrtCtlWork.SearchPrtType)
                {
                    case 0: // 0:標準 
                        ind = 0 + searchPrtCtlWork.BigCarOfferDiv;
                        break;
                    case 10: // 10:拡張
                        ind = 2 + searchPrtCtlWork.BigCarOfferDiv;
                        break;
                    case 20: // 20:外装
                        ind = 4 + searchPrtCtlWork.BigCarOfferDiv;
                        break;
                }
                if (lstSearchPrt[ind].Contains(searchPrtCtlWork.TbsPartsCode) == false)
                    lstSearchPrt[ind].Add(searchPrtCtlWork.TbsPartsCode);
            }
        }

        /// <summary>
        /// BLコードチェック処理
        /// </summary>
        /// <param name="blCode">BLコード</param>
        /// <returns>true:表示／false:非表示</returns>
        public bool IsBLEnabled(int blCode)
        {
            if (_searchPrtTyp == -1) return false;

            if (currentList.Contains(blCode))
                return true;
            return false;
        }

    }
}

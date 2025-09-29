//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 単品売価設定一括登録・修正
// プログラム概要   : 掛率マスタの単品設定分を対象に、複数件一括で登録・修正、一括削除、引用登録を行う。
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張凱
// 作 成 日  2010/08/04  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using System.Collections;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Collections;
using Broadleaf.Xml.Serialization;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 単品売価設定一括登録・修正アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 単品売価設定一括登録・修正のアクセス制御を行います。</br>
    /// <br>Programmer  : 張凱</br>
    /// <br>Date        : 2010/08/10</br>
    /// </remarks>
    public class CustomerCodeRateSetUpdateAcs
    {
        #region ■ Private Members
        // 掛率マスタリモート
        private ISingleGoodsRateDB _iRateDB = null;
        #endregion ■ Private Members


        #region ■ Construcstor
        /// <summary>
        /// 単品売価設定一括登録・修正アクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 単品売価設定一括登録・修正アクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2010/08/10</br>
        /// </remarks>
        public CustomerCodeRateSetUpdateAcs()
        {
            try
            {
                // リモートオブジェクト取得
                this._iRateDB = (ISingleGoodsRateDB)MediationSingleGoodsRateDB.GetSingleGoodsRateDB();
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iRateDB = null;
            }
        }
        #endregion ■ Construcstor


        #region ■ Public Methods
        /// <summary>
        /// 掛率マスタ更新処理
        /// </summary>
        /// <param name="rateSearchParam">掛率マスタ更新条件</param>
        /// <remarks>
        /// <br>Note       : 掛率マスタを更新します。</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2010/08/10</br>
        /// </remarks>
        public int CustomerUpdate(GoodsRateSetSearchParam rateSearchParam)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            try
            {
                // クラスメンバコピー処理(E→D)
                SingleGoodsRateSearchParamWork paraWork = CopyToRateSearchParamWorkFromCustomerParam(rateSearchParam);

                object paraObj = paraWork;

                status = this._iRateDB.WriteCustomer(ref paraObj);
                if (status == 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return (status);
        }

        /// <summary>
        /// 掛率マスタ更新処理
        /// </summary>
        /// <param name="rateSearchParam">掛率マスタ更新条件</param>
        /// <remarks>
        /// <br>Note       : 掛率マスタを更新します。</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2010/08/10</br>
        /// </remarks>
        public int CustomerUpdateGrp(out List<GoodsRateSetSearchResult> rateSearchResultList, GoodsRateSetSearchParam rateSearchParam)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            rateSearchResultList = new List<GoodsRateSetSearchResult>();

            try
            {
                // クラスメンバコピー処理(E→D)
                SingleGoodsRateSearchParamWork paraWork = CopyToRateSearchParamWorkFromCustomerParam(rateSearchParam);

                object paraObj = paraWork;
                object retObj;

                status = this._iRateDB.WriteCustomerGrp(out retObj, ref paraObj);
                if (status == 0)
                {
                    ArrayList retWorkList = retObj as ArrayList;

                    foreach (SingleGoodsRateSearchResultWork retWork in retWorkList)
                    {
                        // クラスメンバコピー処理(D→E)
                        rateSearchResultList.Add(CopyToRateSearchResultFromRateSearchResultWork(retWork));
                    }
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return (status);
        }

        /// <summary>
        /// 掛率マスタ更新処理
        /// </summary>
        /// <param name="rateSearchParam">掛率マスタ更新条件</param>
        /// <remarks>
        /// <br>Note       : 掛率マスタを更新します。</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2010/08/10</br>
        /// </remarks>
        public int CustomerAllDelete(GoodsRateSetSearchParam rateSearchParam)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            try
            {
                // クラスメンバコピー処理(E→D)
                SingleGoodsRateSearchParamWork paraWork = CopyToRateSearchParamWorkFromCustomerParam(rateSearchParam);

                object paraObj = paraWork;

                status = this._iRateDB.CustomerAllDelete(ref paraObj);
                if (status == 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return (status);
        }

        #endregion ■ Public Methods


        #region ■ Private Methods
        /// <summary>
        /// クラスメンバコピー処理(E→D)
        /// </summary>
        /// <param name="rateSearchParam">掛率マスタ更新条件</param>
        /// <returns>掛率マスタ更新条件ワーク</returns>
        /// <remarks>
        /// <br>Note       : クラスメンバをコピーします。</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2010/08/10</br>
        /// </remarks>
        private SingleGoodsRateSearchParamWork CopyToRateSearchParamWorkFromCustomerParam(GoodsRateSetSearchParam rateSearchParam)
        {
            SingleGoodsRateSearchParamWork paraWork = new SingleGoodsRateSearchParamWork();

            paraWork.EnterpriseCode = rateSearchParam.EnterpriseCode;       // 企業コード
            paraWork.SectionCode = rateSearchParam.SectionCode;             // 引用元.拠点コード
            paraWork.CustomerCode = rateSearchParam.CustomerCode;           // 得意先コード
            paraWork.CustRateGrpCode = rateSearchParam.CustRateGrpCode;     // 得意先掛率コード
            paraWork.PrmSectionCode = rateSearchParam.PrmSectionCode;       // 引用先.拠点コード
            paraWork.ObjectDiv = rateSearchParam.ObjectDiv;                 // 更新区分
            paraWork.RateMngGoodsCd = rateSearchParam.RateMngGoodsCd;       // 削除区分
            paraWork.RateMngCustCd = rateSearchParam.RateMngCustCd;         // 指定区分
            paraWork.UnSettingFlg = rateSearchParam.UnSettingFlg;           // 未設定
            paraWork.GoodsNo = rateSearchParam.GoodsNo;                     //商品番号
            paraWork.GoodsMakerCd = rateSearchParam.GoodsMakerCd;           //商品ﾒｰｶｰｺｰﾄﾞ 
            paraWork.BlGoodsCode = rateSearchParam.BlGoodsCode;             //BL商品ｺｰﾄﾞ
            paraWork.BlGroupCode = rateSearchParam.BlGroupCode;             //BLｸﾞﾙｰﾌﾟｺｰﾄﾞ

            return paraWork;
        }

        /// <summary>
        /// クラスメンバコピー処理(D→E)
        /// </summary>
        /// <param name="rateSearchResultWork">掛率マスタ検索結果ワーク</param>
        /// <returns>掛率マスタ検索結果</returns>
        /// <remarks>
        /// <br>Note       : クラスメンバをコピーします。</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2010/08/10</br>
        /// </remarks>
        private GoodsRateSetSearchResult CopyToRateSearchResultFromRateSearchResultWork(SingleGoodsRateSearchResultWork rateSearchResultWork)
        {
            GoodsRateSetSearchResult result = new GoodsRateSetSearchResult();

            // 掛率マスタより取得
            result.CreateDateTime = rateSearchResultWork.CreateDateTime;            // 作成日時
            result.UpdateDateTime = rateSearchResultWork.UpdateDateTime;            // 更新日時
            result.EnterpriseCode = rateSearchResultWork.EnterpriseCode;            // 企業コード
            result.FileHeaderGuid = rateSearchResultWork.FileHeaderGuid;            // GUID
            result.UpdEmployeeCode = rateSearchResultWork.UpdEmployeeCode;          // 更新従業員コード
            result.UpdAssemblyId1 = rateSearchResultWork.UpdAssemblyId1;            // 更新アセンブリID1
            result.UpdAssemblyId2 = rateSearchResultWork.UpdAssemblyId2;            // 更新アセンブリID2
            result.LogicalDeleteCode = rateSearchResultWork.LogicalDeleteCode;      // 論理削除区分
            result.SectionCode = rateSearchResultWork.SectionCode;                  // 拠点コード
            result.UnitRateSetDivCd = rateSearchResultWork.UnitRateSetDivCd;        // 単価掛率設定区分
            result.UnitPriceKind = rateSearchResultWork.UnitPriceKind;              // 単価種類
            result.RateSettingDivide = rateSearchResultWork.RateSettingDivide;      // 掛率設定区分
            result.RateMngGoodsCd = rateSearchResultWork.RateMngGoodsCd;            // 掛率設定区分（商品）
            result.RateMngGoodsNm = rateSearchResultWork.RateMngGoodsNm;            // 掛率設定名称（商品）
            result.RateMngCustCd = rateSearchResultWork.RateMngCustCd;              // 掛率設定区分（得意先）
            result.RateMngCustNm = rateSearchResultWork.RateMngCustNm;              // 掛率設定名称（得意先）
            result.GoodsMakerCd = rateSearchResultWork.GoodsMakerCd;                // 商品メーカーコード
            result.GoodsNo = rateSearchResultWork.GoodsNo;                          // 商品番号
            result.GoodsRateRank = rateSearchResultWork.GoodsRateRank;              // 商品掛率ランク
            result.GoodsRateGrpCode = rateSearchResultWork.GoodsRateGrpCode;        // 商品掛率グループコード
            result.BLGroupCode = rateSearchResultWork.BLGroupCode;                  // BLグループコード
            result.BLGoodsCode = rateSearchResultWork.BLGoodsCode;                  // BL商品コード
            result.CustomerCode = rateSearchResultWork.CustomerCode;                // 得意先コード
            result.CustRateGrpCode = rateSearchResultWork.CustRateGrpCode;          // 得意先掛率グループコード
            result.SupplierCd = rateSearchResultWork.SupplierCd;                    // 仕入先コード
            result.LotCount = rateSearchResultWork.LotCount;                        // ロット数
            result.PriceFl = rateSearchResultWork.PriceFl;                          // 価格（浮動）
            result.RateVal = rateSearchResultWork.RateVal;                          // 掛率
            result.UpRate = rateSearchResultWork.UpRate;                            // UP率
            result.GrsProfitSecureRate = rateSearchResultWork.GrsProfitSecureRate;  // 粗利確保率
            result.UnPrcFracProcUnit = rateSearchResultWork.UnPrcFracProcUnit;      // 単価端数処理単位
            result.UnPrcFracProcDiv = rateSearchResultWork.UnPrcFracProcDiv;        // 単価端数処理区分
            // 優良設定マスタ、商品管理情報マスタより取得
            result.PrmGoodsMGroup = rateSearchResultWork.PrmGoodsMGroup;            // 商品中分類コード
            result.PrmTbsPartsCode = rateSearchResultWork.PrmTbsPartsCode;          // BLコード
            result.BLGoodsHalfName = rateSearchResultWork.BLGoodsHalfName;          // BL商品コード名称（半角）
            result.PrmPartsMakerCd = rateSearchResultWork.PrmPartsMakerCd;          // 部品メーカーコード
            result.MakerName = rateSearchResultWork.MakerName;                      // メーカー名称
            result.GoodsSupplierCd = rateSearchResultWork.GoodsSupplierCd;          // 仕入先コード

            result.ListPrice = rateSearchResultWork.ListPrice;          // 標準価格
            result.SalesUnitCost = rateSearchResultWork.SalesUnitCost;          // 原単価

            result.BfPriceFl = rateSearchResultWork.BfPriceFl;                          // 価格（浮動）
            result.BfRateVal = rateSearchResultWork.BfRateVal;                          // 掛率
            result.BfUpRate = rateSearchResultWork.BfUpRate;                            // UP率
            result.BfGrsProfitSecureRate = rateSearchResultWork.BfGrsProfitSecureRate;  // 粗利確保率
            result.UpdateDiv = rateSearchResultWork.UpdateDiv;

            return result;
        }

        #endregion ■ Private Methods
    }
}

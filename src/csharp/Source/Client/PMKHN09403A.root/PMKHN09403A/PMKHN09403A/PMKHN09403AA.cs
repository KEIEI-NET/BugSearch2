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
    /// 掛率マスタ一括修正・登録アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 掛率マスタ一括修正・登録のアクセス制御を行います。</br>
    /// <br>Programmer : 30414 忍 幸史</br>
    /// <br>Date       : 2009/01/19</br>
    /// <br>UpdateNote : Redmine#37884 掛率マスタ一括登録修正既存障害の対応依頼</br>
    /// <br>Programmer : liuyu</br>
    /// <br>Date       : 2013/07/08</br>
    /// </remarks>
    public class RatePackageUpdateAcs
    {
        #region ■ Private Members
        // 掛率マスタリモート
        private IRateDB _iRateDB = null;
        #endregion ■ Private Members


        #region ■ Construcstor
        /// <summary>
        /// 掛率マスタ一括修正・登録アクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 掛率マスタ一括修正・登録アクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2009/01/19</br>
        /// </remarks>
        public RatePackageUpdateAcs()
        {
            try
            {
                // リモートオブジェクト取得
                this._iRateDB = (IRateDB)MediationRateDB.GetRateDB();
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
        /// <param name="saveList">保存リスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 掛率マスタを更新します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2009/01/19</br>
        /// </remarks>
        public int Write(ArrayList saveList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList paraRateList = new ArrayList();

                for (int i = 0; i < saveList.Count; i++)
                {
                    // クラスメンバコピー処理
                    paraRateList.Add(CopyToRateWorkFromRate((Rate)saveList[i]));
                }

                object paraObj = (object)paraRateList;

                status = this._iRateDB.Write(ref paraObj);
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return (status);
        }

        /// <summary>
        /// 掛率マスタ削除処理
        /// </summary>
        /// <param name="deleteList">削除リスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 掛率マスタを削除します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2009/01/19</br>
        /// </remarks>
        public int Delete(ArrayList deleteList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                byte[] paraRateWork = null;
                ArrayList rateWorkList = new ArrayList();

                for (int i = 0; i < deleteList.Count; i++)
                {
                    // クラスメンバコピー処理
                    rateWorkList.Add(CopyToRateWorkFromRate((Rate)deleteList[i]));
                }

                // ArrayListから配列を生成
                RateWork[] rateWorks = (RateWork[])rateWorkList.ToArray(typeof(RateWork));

                // シリアライズ
                paraRateWork = XmlByteSerializer.Serialize(rateWorks);

                // 物理削除処理
                //status = this._iRateDB.Delete(paraRateWork);
                status = this._iRateDB.DeleteRate(paraRateWork);
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return (status);
        }

        /// <summary>
        /// 掛率マスタ検索処理
        /// </summary>
        /// <param name="rateSearchResultList">掛率マスタ検索結果リスト</param>
        /// <param name="rateSearchParam">掛率マスタ検索条件</param>
        /// <remarks>
        /// <br>Note       : 掛率マスタを検索します。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2009/01/19</br>
        /// </remarks>
        public int Search(out List<RateSearchResult> rateSearchResultList, RateSearchParam rateSearchParam)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            rateSearchResultList = new List<RateSearchResult>();

            try
            {
                // クラスメンバコピー処理(E→D)
                RateSearchParamWork paraWork = CopyToRateSearchParamWorkFromRateSearchParam(rateSearchParam);

                object paraObj = paraWork;
                object retObj;

                //status = this._iRateDB.SearchRate(out retObj, paraObj, 0, ConstantManagement.LogicalMode.GetData0);//DEL 2013/07/08 掛率マスタ一括登録修正既存障害の対応依頼
                status = this._iRateDB.SearchRate(out retObj, paraObj, 0, ConstantManagement.LogicalMode.GetData01);//ADD 2013/07/08 掛率マスタ一括登録修正既存障害の対応依頼
                if (status == 0)
                {
                    ArrayList retWorkList = retObj as ArrayList;

                    foreach (RateSearchResultWork retWork in retWorkList)
                    {
                        // クラスメンバコピー処理(D→E)
                        rateSearchResultList.Add(CopyToRateSearchResultFromRateSearchResultWork(retWork));
                    }
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                rateSearchResultList = new List<RateSearchResult>();
            }

            return (status);
        }

        #endregion ■ Public Methods


        #region ■ Private Methods
        /// <summary>
        /// クラスメンバコピー処理(E→D)
        /// </summary>
        /// <param name="rateSearchParam">掛率マスタ検索条件</param>
        /// <returns>掛率マスタ検索条件ワーク</returns>
        /// <remarks>
        /// <br>Note       : クラスメンバをコピーします。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2009/01/19</br>
        /// </remarks>
        private RateSearchParamWork CopyToRateSearchParamWorkFromRateSearchParam(RateSearchParam rateSearchParam)
        {
            RateSearchParamWork paraWork = new RateSearchParamWork();

            paraWork.EnterpriseCode = rateSearchParam.EnterpriseCode;       // 企業コード
            paraWork.SectionCode = rateSearchParam.SectionCode;             // 拠点コード
            paraWork.SupplierCd = rateSearchParam.SupplierCd;               // 仕入先コード
            paraWork.GoodsRateGrpCode = rateSearchParam.GoodsRateGrpCode;   // 商品掛率グループコード
            paraWork.GoodsMakerCd = rateSearchParam.GoodsMakerCd;           // メーカーコード
            paraWork.CustomerCode = rateSearchParam.CustomerCode;           // 得意先コード
            paraWork.CustRateGrpCode = rateSearchParam.CustRateGrpCode;     // 得意先掛率グループコード
            paraWork.PrmSectionCode = rateSearchParam.PrmSectionCode;       // ログイン拠点コード

            return paraWork;
        }

        /// <summary>
        /// クラスメンバコピー処理(D→E)
        /// </summary>
        /// <param name="rateSearchResultWork">掛率マスタ検索結果ワーク</param>
        /// <returns>掛率マスタ検索結果</returns>
        /// <remarks>
        /// <br>Note       : クラスメンバをコピーします。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2009/01/19</br>
        /// </remarks>
        private RateSearchResult CopyToRateSearchResultFromRateSearchResultWork(RateSearchResultWork rateSearchResultWork)
        {
            RateSearchResult result = new RateSearchResult();

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

            return result;
        }

        /// <summary>
        /// クラスメンバーコピー処理（掛率設定クラス⇒掛率設定ワーククラス）
        /// </summary>
        /// <param name="rate">掛率設定クラス</param>
        /// <returns>RateWork</returns>
        /// <remarks>
        /// <br>Note       : 掛率設定クラスから掛率設定ワーククラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2009/01/19</br>
        /// </remarks>
        private RateWork CopyToRateWorkFromRate(Rate rate)
        {
            RateWork rateWork = new RateWork();

            rateWork.CreateDateTime = rate.CreateDateTime;              // 作成日時
            rateWork.UpdateDateTime = rate.UpdateDateTime;              // 更新日時
            rateWork.EnterpriseCode = rate.EnterpriseCode;              // 企業コード
            rateWork.FileHeaderGuid = rate.FileHeaderGuid;              // GUID
            rateWork.UpdEmployeeCode = rate.UpdEmployeeCode;            // 更新従業員コード
            rateWork.UpdAssemblyId1 = rate.UpdAssemblyId1;              // 更新アセンブリID1
            rateWork.UpdAssemblyId2 = rate.UpdAssemblyId2;              // 更新アセンブリID2
            rateWork.LogicalDeleteCode = rate.LogicalDeleteCode;        // 論理削除区分
            rateWork.SectionCode = rate.SectionCode;                    // 拠点コード
            rateWork.UnitRateSetDivCd = rate.UnitRateSetDivCd;          // 単価掛率設定区分
            rateWork.UnitPriceKind = rate.UnitPriceKind;                // 単価種類
            rateWork.RateSettingDivide = rate.RateSettingDivide;        // 掛率設定区分
            rateWork.RateMngGoodsCd = rate.RateMngGoodsCd;              // 掛率設定区分（商品）
            rateWork.RateMngGoodsNm = rate.RateMngGoodsNm;              // 掛率設定名称（商品）
            rateWork.RateMngCustCd = rate.RateMngCustCd;                // 掛率設定区分（得意先）
            rateWork.RateMngCustNm = rate.RateMngCustNm;                // 掛率設定名称（得意先）
            rateWork.GoodsMakerCd = rate.GoodsMakerCd;                  // 商品メーカーコード
            rateWork.GoodsNo = rate.GoodsNo;                            // 商品番号
            rateWork.GoodsRateRank = rate.GoodsRateRank;                // 商品掛率ランク
            rateWork.BLGoodsCode = rate.BLGoodsCode;                    // BL商品コード
            rateWork.CustomerCode = rate.CustomerCode;                  // 得意先コード
            rateWork.CustRateGrpCode = rate.CustRateGrpCode;            // 得意先掛率グループコード
            rateWork.SupplierCd = rate.SupplierCd;                      // 仕入先コード
            rateWork.LotCount = rate.LotCount;                          // ロット数 
            rateWork.PriceFl = rate.PriceFl;                            // 価格
            rateWork.RateVal = rate.RateVal;                            // 掛率
            rateWork.UnPrcFracProcUnit = rate.UnPrcFracProcUnit;        // 単価端数処理単位
            rateWork.UnPrcFracProcDiv = rate.UnPrcFracProcDiv;          // 単価端数処理区分
            rateWork.GoodsRateGrpCode = rate.GoodsRateGrpCode;          // 商品掛率グループコード
            rateWork.BLGroupCode = rate.BLGroupCode;                    // BLグループコード
            rateWork.UpRate = rate.UpRate;                              // UP率
            rateWork.GrsProfitSecureRate = rate.GrsProfitSecureRate;    // 粗利確保率

            return rateWork;
        }
        #endregion ■ Private Methods
    }
}

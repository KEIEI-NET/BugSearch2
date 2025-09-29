using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;

using Broadleaf.Library.Collections;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Text;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.LocalAccess;

using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.InteropServices;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 商品アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 商品アクセスクラス(掛率(単品売価)情報)のアクセス制御を行います。</br>
    /// <br>Programmer : 22018 鈴木 正臣</br>
    /// <br>Date       : 2008.09.10</br>
    /// <br>Update Note: 2009/02/10 30414 忍 幸史 障害ID:11264対応</br>
    /// </remarks>
    public partial class GoodsAcs
    {
        /// <summary>掛率アクセスクラス</summary>
        private RateAcs _rateAcs;

        /// <summary>
        /// 掛率.単品売価読み込み処理
        /// </summary>
        /// <param name="goodsUnitData"></param>
        /// <param name="logicalMode"></param>
        /// <param name="unitRateList"></param>
        /// <returns></returns>
        public int ReadUnitRate( GoodsUnitData goodsUnitData, ConstantManagement.LogicalMode logicalMode, out List<Rate> unitRateList )
        {
            // 売価設定,品番+メーカー,得意先グループの区分値は1A4
            const string ct_UnitPriceKind_Sa = "1";
            // --- CHG 2009/02/10 障害ID:11264対応------------------------------------------------------>>>>>
            //const string ct_RateSettingDiv_GnMkCgr = "A4";
            //const string ct_UnitRateSetDiv_SaGnMkCgr = "1A4";
            const string ct_RateSettingDiv_GnMkCgr = "4A";
            const string ct_UnitRateSetDiv_SaGnMkCgr = "14A";
            // --- CHG 2009/02/10 障害ID:11264対応------------------------------------------------------<<<<<
            // 全拠点を表す拠点コード
            const string ct_SectionCode_All = "00";


            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            unitRateList = new List<Rate>();

            //------------------------------------------
            // アクセスクラスインスタンス生成
            //------------------------------------------
            if ( _rateAcs == null )
            {
                _rateAcs = new RateAcs();
            }

            //------------------------------------------
            // 検索条件のセット
            //------------------------------------------
            Rate paraRate = new Rate();
            paraRate.EnterpriseCode = goodsUnitData.EnterpriseCode;     // 企業コード
            paraRate.GoodsNo = goodsUnitData.GoodsNo;                   // 品番
            paraRate.GoodsMakerCd = goodsUnitData.GoodsMakerCd;         // メーカーコード
            paraRate.SectionCode = ct_SectionCode_All;                  // 拠点(←全社を指定)
            paraRate.UnitPriceKind = ct_UnitPriceKind_Sa;
            paraRate.RateSettingDivide = ct_RateSettingDiv_GnMkCgr;
            paraRate.UnitRateSetDivCd = ct_UnitRateSetDiv_SaGnMkCgr;    // 単価掛率設定区分(←売価設定,品番+メーカー,得意先グループ)
            paraRate.LotCount = -1;                                     // ロット数(-1:無視)

            //------------------------------------------
            // 検索
            //------------------------------------------
            ArrayList retList;
            string msg;

            // ※SearchRateが期待する動作をしないので
            //   SearchAllで全件取得して論理削除分を除外する。

            status = _rateAcs.SearchAll( out retList, ref paraRate, out msg );
            if ( status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
            {
                // 返却結果をセット
                foreach ( Rate rate in retList )
                {
                    // 論理削除は除外
                    if ( rate.LogicalDeleteCode != 0 ) continue;

                    // 掛率リストに追加
                    unitRateList.Add( rate );
                }
            }

            return status;
        }
        /// <summary>
        /// 掛率リスト変換処理（RateWorkList→RateList）
        /// </summary>
        /// <param name="rateWorkList"></param>
        private List<Rate> CopyToRateFromRateWork( ArrayList rateWorkList )
        {
            List<Rate> rateList = new List<Rate>();
            foreach ( RateWork rateWork in rateWorkList )
            {
                rateList.Add( GetRateFromRateWork( rateWork ) );
            }
            return rateList;
        }
        /// <summary>
        /// 掛率リスト取得処理
        /// </summary>
        /// <param name="rateWorkList"></param>
        /// <param name="rateList"></param>
        private void CreateRateWorkListFromRateList( ref ArrayList rateWorkList, List<Rate> rateList )
        {
            if ( rateWorkList == null )
            {
                rateWorkList = new ArrayList();
            }

            // 内容コピー
            foreach ( Rate rate in rateList )
            {
                rateWorkList.Add( GetRateWorkFromRate( rate ) );
            }
        }
        /// <summary>
        /// 掛率変換処理（掛率→掛率Work）
        /// </summary>
        /// <param name="rate"></param>
        /// <returns></returns>
        private RateWork GetRateWorkFromRate( Rate rate )
        {
            RateWork rateWork = new RateWork();

            # region [掛率]
            rateWork.CreateDateTime = rate.CreateDateTime; // 作成日時
            rateWork.UpdateDateTime = rate.UpdateDateTime; // 更新日時
            rateWork.EnterpriseCode = rate.EnterpriseCode; // 企業コード
            rateWork.FileHeaderGuid = rate.FileHeaderGuid; // GUID
            rateWork.UpdEmployeeCode = rate.UpdEmployeeCode; // 更新従業員コード
            rateWork.UpdAssemblyId1 = rate.UpdAssemblyId1; // 更新アセンブリID1
            rateWork.UpdAssemblyId2 = rate.UpdAssemblyId2; // 更新アセンブリID2
            rateWork.LogicalDeleteCode = rate.LogicalDeleteCode; // 論理削除区分
            rateWork.SectionCode = rate.SectionCode; // 拠点コード
            rateWork.UnitRateSetDivCd = rate.UnitRateSetDivCd; // 単価掛率設定区分
            rateWork.UnitPriceKind = rate.UnitPriceKind; // 単価種類
            rateWork.RateSettingDivide = rate.RateSettingDivide; // 掛率設定区分
            rateWork.RateMngGoodsCd = rate.RateMngGoodsCd; // 掛率設定区分（商品）
            rateWork.RateMngGoodsNm = rate.RateMngGoodsNm; // 掛率設定名称（商品）
            rateWork.RateMngCustCd = rate.RateMngCustCd; // 掛率設定区分（得意先）
            rateWork.RateMngCustNm = rate.RateMngCustNm; // 掛率設定名称（得意先）
            rateWork.GoodsMakerCd = rate.GoodsMakerCd; // 商品メーカーコード
            rateWork.GoodsNo = rate.GoodsNo; // 商品番号
            rateWork.GoodsRateRank = rate.GoodsRateRank; // 商品掛率ランク
            rateWork.GoodsRateGrpCode = rate.GoodsRateGrpCode; // 商品掛率グループコード
            rateWork.BLGroupCode = rate.BLGroupCode; // BLグループコード
            rateWork.BLGoodsCode = rate.BLGoodsCode; // BL商品コード
            rateWork.CustomerCode = rate.CustomerCode; // 得意先コード
            rateWork.CustRateGrpCode = rate.CustRateGrpCode; // 得意先掛率グループコード
            rateWork.SupplierCd = rate.SupplierCd; // 仕入先コード
            rateWork.LotCount = rate.LotCount; // ロット数
            rateWork.PriceFl = rate.PriceFl; // 価格（浮動）
            rateWork.RateVal = rate.RateVal; // 掛率
            rateWork.UpRate = rate.UpRate; // UP率
            rateWork.GrsProfitSecureRate = rate.GrsProfitSecureRate; // 粗利確保率
            rateWork.UnPrcFracProcUnit = rate.UnPrcFracProcUnit; // 単価端数処理単位
            rateWork.UnPrcFracProcDiv = rate.UnPrcFracProcDiv; // 単価端数処理区分
            # endregion

            return rateWork;
        }
        /// <summary>
        /// 掛率変換処理（掛率Work→掛率）
        /// </summary>
        /// <param name="rateWork"></param>
        /// <returns></returns>
        private Rate GetRateFromRateWork( RateWork rateWork )
        {
            Rate rate = new Rate();

            # region [掛率]
            rate.CreateDateTime = rateWork.CreateDateTime; // 作成日時
            rate.UpdateDateTime = rateWork.UpdateDateTime; // 更新日時
            rate.EnterpriseCode = rateWork.EnterpriseCode; // 企業コード
            rate.FileHeaderGuid = rateWork.FileHeaderGuid; // GUID
            rate.UpdEmployeeCode = rateWork.UpdEmployeeCode; // 更新従業員コード
            rate.UpdAssemblyId1 = rateWork.UpdAssemblyId1; // 更新アセンブリID1
            rate.UpdAssemblyId2 = rateWork.UpdAssemblyId2; // 更新アセンブリID2
            rate.LogicalDeleteCode = rateWork.LogicalDeleteCode; // 論理削除区分
            rate.SectionCode = rateWork.SectionCode; // 拠点コード
            rate.UnitRateSetDivCd = rateWork.UnitRateSetDivCd; // 単価掛率設定区分
            rate.UnitPriceKind = rateWork.UnitPriceKind; // 単価種類
            rate.RateSettingDivide = rateWork.RateSettingDivide; // 掛率設定区分
            rate.RateMngGoodsCd = rateWork.RateMngGoodsCd; // 掛率設定区分（商品）
            rate.RateMngGoodsNm = rateWork.RateMngGoodsNm; // 掛率設定名称（商品）
            rate.RateMngCustCd = rateWork.RateMngCustCd; // 掛率設定区分（得意先）
            rate.RateMngCustNm = rateWork.RateMngCustNm; // 掛率設定名称（得意先）
            rate.GoodsMakerCd = rateWork.GoodsMakerCd; // 商品メーカーコード
            rate.GoodsNo = rateWork.GoodsNo; // 商品番号
            rate.GoodsRateRank = rateWork.GoodsRateRank; // 商品掛率ランク
            rate.GoodsRateGrpCode = rateWork.GoodsRateGrpCode; // 商品掛率グループコード
            rate.BLGroupCode = rateWork.BLGroupCode; // BLグループコード
            rate.BLGoodsCode = rateWork.BLGoodsCode; // BL商品コード
            rate.CustomerCode = rateWork.CustomerCode; // 得意先コード
            rate.CustRateGrpCode = rateWork.CustRateGrpCode; // 得意先掛率グループコード
            rate.SupplierCd = rateWork.SupplierCd; // 仕入先コード
            rate.LotCount = rateWork.LotCount; // ロット数
            rate.PriceFl = rateWork.PriceFl; // 価格（浮動）
            rate.RateVal = rateWork.RateVal; // 掛率
            rate.UpRate = rateWork.UpRate; // UP率
            rate.GrsProfitSecureRate = rateWork.GrsProfitSecureRate; // 粗利確保率
            rate.UnPrcFracProcUnit = rateWork.UnPrcFracProcUnit; // 単価端数処理単位
            rate.UnPrcFracProcDiv = rateWork.UnPrcFracProcDiv; // 単価端数処理区分
            # endregion

            return rate;
        }
    }
}

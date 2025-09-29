using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// 商品連結データコンバーター
	/// </summary>
	/// <remarks>
	/// <br>Note       : 商品関連のデータコンバートを行います。</br>
	/// <br>Programmer : 18012 Y.Sasaki</br>
	/// <br>Date       : 2007.01.24</br>
    /// <br>Programmer : 20056 對馬 大輔</br>
    /// <br>Date       : 2007.08.30</br>
    /// <br>           :・DC.NS対応</br>
    /// <br>-----------------------------------------------------------------------------------------</br>
    /// <br>UpdateNote : 2008.06.18 20056 對馬 大輔</br>
    /// <br>           : PM.NS対応(コメント無し)</br>
    /// </remarks>
	class GoosUnitConverer
	{
		private static GoodsAcs mGoodsAcs = new GoodsAcs();
		private static string mEnterpriseCode = LoginInfoAcquisition.EnterpriseCode;

		/// <summary>
		/// 商品連結データから商品データ取得
		/// </summary>
		/// <param name="goodsUnitData">商品連結データ</param>
		/// <returns>Goods</returns>
		public static ArrayList ConvertFromGoosUnit(GoodsUnitData goodsUnitData)
		{
			ArrayList dataList = new ArrayList();
			ArrayList goodsList = new ArrayList();

            // 商品クラス取得
            goodsList.Add(GoosUnitConverer.GoodsFromGoosUnit(goodsUnitData));

			// 商品クラス追加
			if (goodsList.Count > 0)
				dataList.Add(goodsList);

			return dataList; 
		}

		/// <summary>
		/// 商品連結データから商品関連データリスト取得
		/// </summary>
		/// <param name="goodsUnitDataList">商品連結データリスト</param>
		/// <returns>商品関連データリスト</returns>
		public static ArrayList ConvertFromGoosUnit(List<GoodsUnitData> goodsUnitDataList)
		{
			ArrayList dataList = new ArrayList();
			ArrayList goodsList = new ArrayList();

			foreach (GoodsUnitData goodsUnitData in goodsUnitDataList)
			{
                // 商品クラス取得
                goodsList.Add(GoosUnitConverer.GoodsFromGoosUnit(goodsUnitData));
			}

			// 商品クラス追加
			if (goodsList.Count > 0)
				dataList.Add(goodsList);

			return dataList;
		}

        /// <summary>
        /// 商品連結データ作成処理
        /// </summary>
        /// <param name="goods">商品データクラス</param>
        /// <returns></returns>
        public static GoodsUnitData MakeGoodsUnitData(Goods goods)
		{
			// 商品データがない場合は連結データが作れない為Nullを返す
			if (goods == null) return null;

			// 商品共通データの商品情報を設定する
			GoodsUnitData goodsUnitData = MakeCommonGoodsUnit(goods);

			return goodsUnitData; 
		}

		/// <summary>
		/// 商品連結データから商品データ取得
		/// </summary>
		/// <param name="goodsUnitData">商品連結データ</param>
		/// <returns>Goods</returns>
		public static Goods GoodsFromGoosUnit(GoodsUnitData goodsUnitData)
		{
			Goods goods = new Goods();

			if (goodsUnitData != null)
			{
                goods.CreateDateTime = goodsUnitData.CreateDateTime; // 作成日時
                goods.UpdateDateTime = goodsUnitData.UpdateDateTime; // 更新日時
                goods.EnterpriseCode = goodsUnitData.EnterpriseCode; // 企業コード
                goods.FileHeaderGuid = goodsUnitData.FileHeaderGuid; // GUID
                goods.UpdEmployeeCode = goodsUnitData.UpdEmployeeCode; // 更新従業員コード
                goods.UpdAssemblyId1 = goodsUnitData.UpdAssemblyId1; // 更新アセンブリID1
                goods.UpdAssemblyId2 = goodsUnitData.UpdAssemblyId2; // 更新アセンブリID2
                goods.LogicalDeleteCode = goodsUnitData.LogicalDeleteCode; // 論理削除区分
                goods.GoodsMakerCd = goodsUnitData.GoodsMakerCd; // 商品メーカーコード
                goods.GoodsNo = goodsUnitData.GoodsNo; // 商品番号
                goods.GoodsName = goodsUnitData.GoodsName; // 商品名称
                goods.GoodsNameKana = goodsUnitData.GoodsNameKana; // 商品名称カナ
                goods.Jan = goodsUnitData.Jan; // JANコード
                goods.BLGoodsCode = goodsUnitData.BLGoodsCode; // BL商品コード
                goods.DisplayOrder = goodsUnitData.DisplayOrder; // 表示順位
                goods.GoodsRateRank = goodsUnitData.GoodsRateRank; // 商品掛率ランク
                goods.TaxationDivCd = goodsUnitData.TaxationDivCd; // 課税区分
                goods.GoodsNoNoneHyphen = goodsUnitData.GoodsNoNoneHyphen; // ハイフン無商品番号
                goods.OfferDate = goodsUnitData.OfferDate; // 提供日付
                goods.GoodsKindCode = goodsUnitData.GoodsKindCode; // 商品属性
                goods.GoodsNote1 = goodsUnitData.GoodsNote1; // 商品備考１
                goods.GoodsNote2 = goodsUnitData.GoodsNote2; // 商品備考２
                goods.GoodsSpecialNote = goodsUnitData.GoodsSpecialNote; // 商品規格・特記事項
                goods.EnterpriseGanreCode = goodsUnitData.EnterpriseGanreCode; // 自社分類コード
                goods.UpdateDate = goodsUnitData.UpdateDate; // 更新年月日
			}

			return goods;
		}

		/// <summary>
		/// 商品連結データ共通商品データ設定
		/// </summary>
		/// <param name="goods">商品データ</param>
		/// <returns>商品連結データ</returns>
		private static GoodsUnitData MakeCommonGoodsUnit(Goods goods)
		{
			GoodsUnitData goodsUnitData = new GoodsUnitData();

            goodsUnitData.CreateDateTime = goods.CreateDateTime; // 作成日時
            goodsUnitData.UpdateDateTime = goods.UpdateDateTime; // 更新日時
            goodsUnitData.EnterpriseCode = goods.EnterpriseCode; // 企業コード
            goodsUnitData.FileHeaderGuid = goods.FileHeaderGuid; // GUID
            goodsUnitData.UpdEmployeeCode = goods.UpdEmployeeCode; // 更新従業員コード
            goodsUnitData.UpdAssemblyId1 = goods.UpdAssemblyId1; // 更新アセンブリID1
            goodsUnitData.UpdAssemblyId2 = goods.UpdAssemblyId2; // 更新アセンブリID2
            goodsUnitData.LogicalDeleteCode = goods.LogicalDeleteCode; // 論理削除区分
            goodsUnitData.GoodsMakerCd = goods.GoodsMakerCd; // 商品メーカーコード
            goodsUnitData.GoodsNo = goods.GoodsNo; // 商品番号
            goodsUnitData.GoodsName = goods.GoodsName; // 商品名称
            goodsUnitData.GoodsNameKana = goods.GoodsNameKana; // 商品名称カナ
            goodsUnitData.Jan = goods.Jan; // JANコード
            goodsUnitData.BLGoodsCode = goods.BLGoodsCode; // BL商品コード
            goodsUnitData.DisplayOrder = goods.DisplayOrder; // 表示順位
            goodsUnitData.GoodsRateRank = goods.GoodsRateRank; // 商品掛率ランク
            goodsUnitData.TaxationDivCd = goods.TaxationDivCd; // 課税区分
            goodsUnitData.GoodsNoNoneHyphen = goods.GoodsNoNoneHyphen; // ハイフン無商品番号
            goodsUnitData.OfferDate = goods.OfferDate; // 提供日付
            goodsUnitData.GoodsKindCode = goods.GoodsKindCode; // 商品属性
            goodsUnitData.GoodsNote1 = goods.GoodsNote1; // 商品備考１
            goodsUnitData.GoodsNote2 = goods.GoodsNote2; // 商品備考２
            goodsUnitData.GoodsSpecialNote = goods.GoodsSpecialNote; // 商品規格・特記事項
            goodsUnitData.EnterpriseGanreCode = goods.EnterpriseGanreCode; // 自社分類コード
            goodsUnitData.UpdateDate = goods.UpdateDate; // 更新年月日

			return goodsUnitData;
		}
    }
}

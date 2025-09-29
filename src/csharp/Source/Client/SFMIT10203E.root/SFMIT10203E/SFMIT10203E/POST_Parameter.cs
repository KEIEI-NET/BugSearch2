using System;
using System.Collections.Generic;
using System.Text;

using System.Drawing;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 提案商品登録POSTパラメータ
    /// </summary>
    public class ProposeGoods_MAIN
    {
        public ProposeGoods[] goods;
    }

    /// public class name:   ProposeGoods
	/// <summary>
	///                      提案商品クラス
	/// </summary>
	/// <remarks>
	/// <br>note             :   提案商品クラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2016/5/24</br>
	/// <br>Genarated Date   :   2016/06/03  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   2016/6/2  中村仁</br>
	/// <br>                 :   在庫数</br>
	/// <br>                 :   BL商品コード</br>
	/// <br>                 :   BL商品コード枝番</br>
	/// <br>                 :   を追加</br>
	/// </remarks>
    public class ProposeGoods
    {
        /// <summary>UUID</summary>
        public string uuid = "";

        /// <summary>作成日時</summary>
        public long insDtTime;

        /// <summary>更新日時</summary>
        public long updDtTime;

        /// <summary>作成アカウントID</summary>
        public Int32 insAccountId;

        /// <summary>更新アカウントID</summary>
        public Int32 updAccountId;

        /// <summary>論理削除区分</summary>
        public Int32 logicalDelDiv;

        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        public string enterpriseCode = "";

        /// <summary>企業名称</summary>
        public string enterpriseName = "";

        /// <summary>拠点コード</summary>
        public string sectionCode = "";

        /// <summary>拠点名称</summary>
        public string sectionName = "";

        /// <summary>提案商品ID</summary>
        public long proposeGoodsId;

        /// <summary>提案商品名称</summary>
        public string proposeGoodsName = "";

        /// <summary>商品カテゴリーID</summary>
        public long goodsCategoryId;

        /// <summary>BLコード</summary>
        public Int32 blCode;

        /// <summary>BLコード枝番</summary>
        public Int32 blCodeBranche;

        /// <summary>品番</summary>
        public string partsNumber = "";

        /// <summary>PMメーカーコード</summary>
        public Int32 pmMakerCode;

        /// <summary>メーカー名称</summary>
        public string makerName = "";

        /// <summary>画像ID</summary>
        public long imageId;

        /// <summary>発売日</summary>
        public string releaseDate = "";

        /// <summary>在庫状態</summary>
        public Int32 stockState;

        /// <summary>商品説明</summary>
        public string goodsNote = "";

        /// <summary>商品PR</summary>
        public string goodsPr = "";

        /// <summary>希望小売価格</summary>
        public long suggestPrice;

        /// <summary>店頭価格</summary>
        public long shopPrice;

        /// <summary>卸値</summary>
        public long tradePrice;

        /// <summary>仕入原価</summary>
        public long purchaseCost;

        /// <summary>おすすめフラグ</summary>
        public bool recommendFlag;

        /// <summary>並び順</summary>
        public Int32 sortNo;

        /// <summary>公開フラグ</summary>
        public bool releaseFlag;

        /// <summary>PM更新日時</summary>
        public long pmUpdDtTime;

        // 手動追加↓

        /// <summary>画像ID</summary>
        public Image image_Data;

        /// <summary>付随整備リスト</summary>
        public AttendRepair[] attendRepairList;

        /// <summary>商品タグリスト</summary>
        public GoodsTag[] goodsTagList;

        /// <summary>個別設定</summary>
        public ProposeDistGoodsSetting[] proposeDistGoodsSetting;


        /// <summary>公開開始日</summary>
        public string shopSaleBeginDate = "";

        /// <summary>公開終了日</summary>
        public string shopSaleEndDate = "";


        /// <summary>
        /// 提案商品クラスコンストラクタ
        /// </summary>
        /// <returns>ProposeGoodsクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ProposeGoodsクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ProposeGoods()
        {
        }

        /// <summary>
        /// 提案商品クラスコンストラクタ
        /// </summary>
        /// <param name="uuid">UUID</param>
        /// <param name="insDtTime">作成日時</param>
        /// <param name="updDtTime">更新日時</param>
        /// <param name="insAccountId">作成アカウントID</param>
        /// <param name="updAccountId">更新アカウントID</param>
        /// <param name="logicalDelDiv">論理削除区分</param>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="sectionName">拠点名称</param>
        /// <param name="proposeGoodsId">提案商品ID</param>
        /// <param name="proposeGoodsName">提案商品名称</param>
        /// <param name="goodsCategoryId">商品カテゴリーID</param>
        /// <param name="blCode">BLコード</param>
        /// <param name="blCodeBranche">BLコード枝番</param>
        /// <param name="partsNumber">品番</param>
        /// <param name="pmMakerCode">PMメーカーコード</param>
        /// <param name="makerName">メーカー名称</param>
        /// <param name="imageId">画像ID</param>
        /// <param name="releaseDate">発売日</param>
        /// <param name="stockState">在庫状態</param>
        /// <param name="goodsNote">商品説明</param>
        /// <param name="goodsPr">商品PR</param>
        /// <param name="suggestPrice">希望小売価格</param>
        /// <param name="shopPrice">店頭価格</param>
        /// <param name="tradePrice">卸値</param>
        /// <param name="purchaseCost">仕入原価</param>
        /// <param name="recommendFlag">おすすめフラグ</param>
        /// <param name="sortNo">並び順</param>
        /// <param name="releaseFlag">公開フラグ</param>
        /// <param name="pmUpdDtTime">PM更新日時</param>
        /// 
        /// <returns>ProposeGoodsクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ProposeGoodsクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ProposeGoods(string uuid, long insDtTime, long updDtTime, Int32 insAccountId, Int32 updAccountId, Int32 logicalDelDiv, string enterpriseCode, string enterpriseName, string sectionCode, string sectionName, 
            long proposeGoodsId, string proposeGoodsName, long goodsCategoryId, Int32 blCode, Int32 blCodeBranche, string partsNumber, Int32 pmMakerCode, string makerName, long imageId, string releaseDate, 
            Int32 stockState, string goodsNote, string goodsPr, long suggestPrice, 
            long shopPrice, long tradePrice, long purchaseCost, bool recommendFlag, 
            Int32 sortNo, bool releaseFlag, long pmUpdDtTime, Image image_Data,
            string shopSaleBeginDate, string shopSaleEndDate,
            AttendRepair[] attendRepairList, GoodsTag[] goodsTagList, ProposeDistGoodsSetting[] proposeDistGoodsSetting)
        {
            this.uuid = uuid;
            this.insDtTime = insDtTime;
            this.updDtTime = updDtTime;
            this.insAccountId = insAccountId;
            this.updAccountId = updAccountId;
            this.logicalDelDiv = logicalDelDiv;
            this.enterpriseCode = enterpriseCode;
            this.enterpriseName = enterpriseName;
            this.sectionCode = sectionCode;
            this.sectionName = sectionName;
            this.proposeGoodsId = proposeGoodsId;
            this.proposeGoodsName = proposeGoodsName;
            this.goodsCategoryId = goodsCategoryId;
            this.blCode = blCode;
            this.blCodeBranche = blCodeBranche;
            this.partsNumber = partsNumber;
            this.pmMakerCode = pmMakerCode;
            this.makerName = makerName;
            this.imageId = imageId;
            this.releaseDate = releaseDate;
            this.stockState = stockState;
            this.goodsNote = goodsNote;
            this.goodsPr = goodsPr;
            this.suggestPrice = suggestPrice;
            this.shopPrice = shopPrice;
            this.tradePrice = tradePrice;
            this.purchaseCost = purchaseCost;
            this.recommendFlag = recommendFlag;
            this.sortNo = sortNo;
            this.releaseFlag = releaseFlag;
            this.pmUpdDtTime = pmUpdDtTime;
            this.shopSaleBeginDate = shopSaleBeginDate;
            this.shopSaleEndDate = shopSaleEndDate;
            this.image_Data = image_Data;
            this.attendRepairList = attendRepairList;
            this.goodsTagList = goodsTagList;
            this.proposeDistGoodsSetting = proposeDistGoodsSetting;
        }

        /// <summary>
        /// 提案商品クラス複製処理
        /// </summary>
        /// <returns>ProposeGoodsクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいProposeGoodsクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ProposeGoods Clone()
        {
            return new ProposeGoods(this.uuid, this.insDtTime, this.updDtTime, this.insAccountId, this.updAccountId, this.logicalDelDiv, this.enterpriseCode, this.enterpriseName, this.sectionCode, this.sectionName, this.proposeGoodsId, this.proposeGoodsName, this.goodsCategoryId, this.blCode, this.blCodeBranche, this.partsNumber, this.pmMakerCode, this.makerName, this.imageId, this.releaseDate, this.stockState, this.goodsNote, this.goodsPr, this.suggestPrice, this.shopPrice, this.tradePrice, this.purchaseCost, this.recommendFlag, this.sortNo, this.releaseFlag, this.pmUpdDtTime,
                this.image_Data, this.shopSaleBeginDate, this.shopSaleEndDate, this.attendRepairList, this.goodsTagList, this.proposeDistGoodsSetting);
        }


        /// <summary>
        /// 提案商品クラス比較処理
        /// </summary>
        /// <param name="proposeGoods1">
        ///                    比較するProposeGoodsクラスのインスタンス
        /// </param>
        /// <param name="proposeGoods2">比較するProposeGoodsクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ProposeGoodsクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(ProposeGoods proposeGoods1, ProposeGoods proposeGoods2)
        {
            // 画像、配列メンバーは対象外なので注意

            return ((proposeGoods1.uuid == proposeGoods2.uuid)
                 && (proposeGoods1.insDtTime == proposeGoods2.insDtTime)
                 && (proposeGoods1.updDtTime == proposeGoods2.updDtTime)
                 && (proposeGoods1.insAccountId == proposeGoods2.insAccountId)
                 && (proposeGoods1.updAccountId == proposeGoods2.updAccountId)
                 && (proposeGoods1.logicalDelDiv == proposeGoods2.logicalDelDiv)
                 && (proposeGoods1.enterpriseCode == proposeGoods2.enterpriseCode)
                 && (proposeGoods1.enterpriseName == proposeGoods2.enterpriseName)
                 && (proposeGoods1.sectionCode == proposeGoods2.sectionCode)
                 && (proposeGoods1.sectionName == proposeGoods2.sectionName)
                 && (proposeGoods1.proposeGoodsId == proposeGoods2.proposeGoodsId)
                 && (proposeGoods1.proposeGoodsName == proposeGoods2.proposeGoodsName)
                 && (proposeGoods1.goodsCategoryId == proposeGoods2.goodsCategoryId)
                 && (proposeGoods1.blCode == proposeGoods2.blCode)
                 && (proposeGoods1.blCodeBranche == proposeGoods2.blCodeBranche)
                 && (proposeGoods1.partsNumber == proposeGoods2.partsNumber)
                 && (proposeGoods1.pmMakerCode == proposeGoods2.pmMakerCode)
                 && (proposeGoods1.makerName == proposeGoods2.makerName)
                 && (proposeGoods1.imageId == proposeGoods2.imageId)
                 && (proposeGoods1.releaseDate == proposeGoods2.releaseDate)
                 && (proposeGoods1.stockState == proposeGoods2.stockState)
                 && (proposeGoods1.goodsNote == proposeGoods2.goodsNote)
                 && (proposeGoods1.goodsPr == proposeGoods2.goodsPr)
                 && (proposeGoods1.suggestPrice == proposeGoods2.suggestPrice)
                 && (proposeGoods1.shopPrice == proposeGoods2.shopPrice)
                 && (proposeGoods1.tradePrice == proposeGoods2.tradePrice)
                 && (proposeGoods1.purchaseCost == proposeGoods2.purchaseCost)
                 && (proposeGoods1.recommendFlag == proposeGoods2.recommendFlag)
                 && (proposeGoods1.sortNo == proposeGoods2.sortNo)
                 && (proposeGoods1.releaseFlag == proposeGoods2.releaseFlag)
                 && (proposeGoods1.shopSaleBeginDate == proposeGoods2.shopSaleBeginDate)
                 && (proposeGoods1.shopSaleEndDate == proposeGoods2.shopSaleEndDate)
                 && (proposeGoods1.pmUpdDtTime == proposeGoods2.pmUpdDtTime));
        }
    }


    /// <summary>
    /// 付随整備
    /// </summary>
    public class AttendRepair
    {
        /// <summary>UUID</summary>
        public string uuid;

        /// <summary>作成日</summary>
        public long insDtTime;

        /// <summary>更新日</summary>
        public long updDtTime;

        /// <summary>アカウントID</summary>
        public int insAccountId;

        /// <summary>更新アカウントID</summary>
        public int updAccountId;

        /// <summary>論理削除区分</summary>
        public int logicalDelDiv;

        /// <summary>企業コード</summary>
        public string enterpriseCode;

        /// <summary>拠点コード</summary>
        public string sectionCode;
       
        /// <summary>提案付随整備ID サロゲートキー</summary>
        public long proposeAttendRepairId;

        /// <summary>付随整備ID</summary>
        public long attendRepairId;

        /// <summary>付随整備名称</summary>
        public string repairName;

        /// <summary>付随整備金額</summary>
        public long repairPrice;

        /// <summary>提案商品ID</summary>
        public long proposeGoodsId;

        /// <summary>表示順</summary>
        public int sortNo;

        /// <summary>データタイプ(整備、部品？)</summary>
        public int dataType;

        /// <summary>金額タイプ(単価、金額？)</summary>
        public int priceType;

        /// <summary>
        /// 付随整備コンストラクタ
        /// </summary>
        public AttendRepair()
        {

        }

        /// <summary>
        /// 付随整備コンストラクタ
        /// </summary>
        /// <param name="uuid"></param>
        /// <param name="insDtTime"></param>
        /// <param name="updDtTime"></param>
        /// <param name="insAccountId"></param>
        /// <param name="updAccountId"></param>
        /// <param name="logicalDelDiv"></param>
        /// <param name="enterpriseCode"></param>
        /// <param name="sectionCode"></param>
        /// <param name="proposeAttendRepairId"></param>
        /// <param name="attendRepairId"></param>
        /// <param name="repairName"></param>
        /// <param name="repairPrice"></param>
        /// <param name="proposeGoodsId"></param>
        /// <param name="sortNo"></param>
        /// <param name="dataType"></param>
        /// <param name="priceType"></param>
        public AttendRepair(string uuid, long insDtTime, long updDtTime, int insAccountId, int updAccountId, int logicalDelDiv, string enterpriseCode, string sectionCode,
                            long proposeAttendRepairId, long attendRepairId, string repairName, long repairPrice, long proposeGoodsId, int sortNo, int dataType, int priceType)
        {
            this.uuid = uuid;
            this.insDtTime = insDtTime;
            this.updDtTime = updDtTime;
            this.insAccountId = insAccountId;
            this.updAccountId = updAccountId;
            this.logicalDelDiv = logicalDelDiv;
            this.enterpriseCode = enterpriseCode;
            this.sectionCode = sectionCode;
            this.proposeAttendRepairId = proposeAttendRepairId;
            this.attendRepairId = attendRepairId;
            this.repairName = repairName;
            this.repairPrice = repairPrice;
            this.proposeGoodsId = proposeGoodsId;
            this.sortNo = sortNo;
            this.dataType = dataType;
            this.priceType = priceType;
        }

        /// <summary>
        /// 付随整備複製処理
        /// </summary>
        /// <returns>GoodsTagクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいGoodsTagクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public AttendRepair Clone()
        {
            return new AttendRepair(this.uuid, this.insDtTime, this.updDtTime, this.insAccountId, this.updAccountId, this.logicalDelDiv, this.enterpriseCode, this.sectionCode,
                       this.proposeAttendRepairId, this.attendRepairId, this.repairName, this.repairPrice, this.proposeGoodsId, this.sortNo, this.dataType, this.priceType);
        }
    }

    /// <summary>
    /// 商品タグ
    /// </summary>
    public class GoodsTag
    {
        /// <summary>UUID</summary>
        public string uuid;

        /// <summary>作成日</summary>
        public long insDtTime;

        /// <summary>更新日</summary>
        public long updDtTime;

        /// <summary>アカウントID</summary>
        public int insAccountId;

        /// <summary>更新アカウントID</summary>
        public int updAccountId;

        /// <summary>論理削除区分</summary>
        public int logicalDelDiv;

        /// <summary>企業コード</summary>
        public string enterpriseCode;

        /// <summary>拠点コード</summary>
        public string sectionCode;

        /// <summary>提案商品ID</summary>
        public long proposeGoodsId;

        /// <summary>商品タグID（サロゲート）</summary>
        public long goodsTagId;

        /// <summary>商品タグ</summary>
        public string tag;

        /// <summary>商品タグ番号（1～10）</summary>
        public int tagNo;


        /// <summary>
        /// 商品タグクラスコンストラクタ
        /// </summary>
        public GoodsTag()
        {

        }

        /// <summary>
        /// 商品タグクラスコンストラクタ
        /// </summary>
        public GoodsTag(string uuid, long insDtTime, long updDtTime, int insAccountId, int updAccountId, int logicalDelDiv, string enterpriseCode, string sectionCode, long proposeGoodsId, long goodsTagId, string tag, int tagNo)
        {
            this.uuid = uuid;
            this.insDtTime = insDtTime;
            this.updDtTime = updDtTime;
            this.insAccountId = insAccountId;
            this.updAccountId = updAccountId;
            this.logicalDelDiv = logicalDelDiv;
            this.enterpriseCode = enterpriseCode;
            this.sectionCode = sectionCode;
            this.proposeGoodsId = proposeGoodsId;
            this.goodsTagId = goodsTagId;
            this.tag = tag;
            this.tagNo = tagNo;
        }

        /// <summary>
        /// 商品タグ複製処理
        /// </summary>
        /// <returns>ProposeGoodsクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいProposeGoodsクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public GoodsTag Clone()
        {
            return new GoodsTag(this.uuid, this.insDtTime, this.updDtTime, this.insAccountId, this.updAccountId, this.logicalDelDiv, this.enterpriseCode, this.sectionCode, this.proposeGoodsId, this.goodsTagId, this.tag, this.tagNo);
        }
    }

    /// <summary>
    /// 個別設定 
    /// </summary>
    public class ProposeDistGoodsSetting
    {
        /// <summary>企業コード</summary>
        public string enterpriseCode;

        /// <summary>拠点コード</summary>
        public string sectionCode;

        /// <summary>アカウントID</summary>
        public int insAccountId;

        /// <summary>更新アカウントID</summary>
        public int updAccountId;

        /// <summary>作成日</summary>
        public long insDtTime;

        /// <summary>更新日</summary>
        public long updDtTime;

        /// <summary>論理削除区分</summary>
        public int logicalDelDiv;

        /// <summary>提案商品ID</summary>
        public long proposeGoodsId;

        /// <summary>個別設定企業コード</summary>
        public string proposeDistEnterpriseCode;

        /// <summary>個別設定拠点コード</summary>
        public string proposeDistSectionCode;

        /// <summary>個別設定ID(サロゲートキー)</summary>
        public long proposeDistGoodsSettingId;

        /// <summary>希望小売価格</summary>
        public long suggestPrice;

        /// <summary>店頭価格</summary>
        public long shopPrice;

        /// <summary>卸値</summary>
        public long tradePrice;

        /// <summary>仕入原価</summary>
        public Double purchaseCost;

        /// <summary>UUID</summary>
        public string uuid;
    }

    /// <summary>
    /// 新着情報 
    /// </summary>
    public class News
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        public string enterpriseCode = "";

        /// <summary>企業名称</summary>
        public string enterpriseName = "";

        /// <summary>拠点コード</summary>
        public string sectionCode = "";

        /// <summary>拠点名称</summary>
        public string sectionName = "";

        /// <summary>商品カテゴリーID</summary>
        public long goodsCategoryId;

        /// <summary>タイトル</summary>
        public string newsTitle;

        /// <summary>本文</summary>
        public string newsContent;

        /// <summary>提案日時</summary>
        public string proposeDate;

        /// <summary>提案先情報リスト</summary>
        public ProposeStore[] proposeStoreList;
    }
 
    /// <summary>
    /// 提案先情報
    /// </summary>
    public class ProposeStore
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        public string enterpriseCode = "";

        /// <summary>企業名称</summary>
        public string enterpriseName = "";

        /// <summary>拠点コード</summary>
        public string sectionCode = "";

        /// <summary>拠点名称</summary>
        public string sectionName = "";

    }

    /// <summary>
    /// 提案先情報
    /// </summary>
    public class DestSetting_MAIN
    {
        public DestSetting[] destSettings;
    }

    /// <summary>
    /// 提案先情報
    /// </summary>
    public class DestSetting
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        public string enterpriseCode = "";

        /// <summary>拠点コード</summary>
        public string sectionCode;

        /// <summary>アカウントID</summary>
        public int insAccountId;

        /// <summary>更新アカウントID</summary>
        public int updAccountId;

        /// <summary>作成日</summary>
        public long insDtTime;

        /// <summary>更新日</summary>
        public long updDtTime;

        /// <summary>論理削除区分</summary>
        public int logicalDelDiv;

        /// <summary>公開情報ID</summary>
        public long proposeDestId;

        /// <summary>公開先企業コード</summary>
        public string proposeDestEnterpriseCode = "";

        /// <summary>公開先企業名称</summary>
        public string proposeDestEnterpriseName = "";

        /// <summary>公開先拠点コード</summary>
        public string proposeDestSectionCode;

        /// <summary>公開先拠点名称</summary>
        public string proposeDestSectionName = "";

        /// <summary>商品カテゴリーID</summary>
        public long goodsCategoryId;

    }
}

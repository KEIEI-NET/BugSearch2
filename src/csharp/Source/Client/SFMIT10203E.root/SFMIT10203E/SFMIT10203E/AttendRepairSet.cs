using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 付随整備
    /// </summary>
    public class AttendRepairSetMain
    {
        public AttendRepairSet[] attendrepairs;
    }

    /// <summary>
    /// 付随整備
    /// </summary>
    public class AttendRepairSet
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

        /// <summary>付随整備ID(サロゲートキー)</summary>
        public long attendRepairId;
      
        /// <summary>企業コード</summary>
        public string enterpriseCode;

        /// <summary>商品カテゴリID</summary>
        public long goodsCategoryId;

        /// <summary>データ区分(1:作業、2：部品)</summary>
        public int dataType;

        /// <summary>金額タイプ(1：単価、2：金額)</summary>
        public int priceType;

        /// <summary>並び順</summary>
        public int sortNo;

        /// <summary>整備名称</summary>
        public string repairName;

        /// <summary>整備料金</summary>
        public long repairPrice;

        /// <summary>使用・未使用フラグ</summary>
        public bool displayFlag;

        /// <summary>提供元付随整備ID</summary>
        public long storeAttendRepairId;

        ///// <summary>提供元企業コード</summary>
        //public string sourceEnterpriseCode;

        ///// <summary>提供元企業名称</summary>
        //public string sourceEnterpriseName;

        ///// <summary>BLコード</summary>
        //public int blCode;

        ///// <summary>BLコード枝番号</summary>
        //public int blCodeBranch;

   

        ///// <summary>作業・部品区分</summary>
        //public int divCode;

        ///// <summary>作業・部品区分名称</summary>
        //public string divName;

        /// <summary>
        /// 付随整備設定コンストラクタ
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// </remarks>
        public AttendRepairSet()
        {

        }

         /// <summary>
        /// 商品カテゴリー設定コンストラクタ
        /// </summary>
        /// <param name="uuid">UUID</param>
        /// <param name="insDtTime">作成日</param>
        /// <param name="updDtTime">更新日</param>
        /// <param name="insAccountId">アカウントID</param>
        /// <param name="updAccountId">更新アカウントID</param>
        /// <param name="logicalDelDiv">論理削除区分</param>
        /// <param name="attendRepairId">付随整備ID</param>
        /// <param name="dataType">データ区分(1:作業、2：部品)</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="goodsCategoryId">商品カテゴリID</param>
        /// <param name="priceType">金額タイプ(1：単価、2：金額)</param>
        /// <param name="sortNo">並び順</param>
        /// <param name="repairName">整備名称</param>
        /// <param name="repairPrice">整備料金</param>
        /// <returns></returns>
        /// <remarks>
        /// </remarks>
        public AttendRepairSet(string uuid, long insDtTime, long updDtTime, int insAccountId, int updAccountId, int logicalDelDiv, long attendRepairId, 
            string enterpriseCode, long goodsCategoryId,int dataType, int priceType, int sortNo, string repairName, long repairPrice)
        {
            this.uuid = uuid;
            this.insDtTime = insDtTime;
            this.updDtTime = updDtTime;
            this.insAccountId = insAccountId;
            this.updAccountId = updAccountId;
            this.logicalDelDiv = updAccountId;
            this.attendRepairId = attendRepairId;
            this.dataType = dataType;
            this.enterpriseCode = enterpriseCode;
            this.goodsCategoryId = goodsCategoryId;
            this.priceType = priceType;
            this.repairName = repairName;
            this.repairPrice = repairPrice;
            this.sortNo = sortNo;
        }

        /// <summary>
        /// 商品カテゴリー設定複製処理
        /// </summary>
        /// <remarks>
        /// </remarks>
        public AttendRepairSet Clone()
        {
            return new AttendRepairSet(this.uuid, this.insDtTime, this.updDtTime, this.insAccountId, this.updAccountId, this.logicalDelDiv, this.attendRepairId, this.enterpriseCode, this.goodsCategoryId, this.dataType, this.priceType, this.sortNo, this.repairName, this.repairPrice);
        }
    }


   

   

   

}

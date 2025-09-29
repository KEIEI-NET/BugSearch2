using System;
using System.Collections;
using System.Text;

namespace Broadleaf.Application.UIData
{

    /// public class name:   GoodsCategory_MAIN
    /// <summary>
    /// 商品カテゴリー設定(メイン)　シリアライズ用
    /// </summary>
    /// <remarks>
    /// </remarks>
    public class GoodsCategory_MAIN
    {
        public GoodsCategory[] GoodsCategory;
    }

    /// public class name:   goodsCategory
    /// <summary>
    ///                      商品カテゴリー設定
    /// </summary>
    /// <remarks>
    /// <br>note             :   商品カテゴリー設定ヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2016/5/24</br>
    /// <br>Genarated Date   :   2016/05/25  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class GoodsCategory
    {
        /// <summary>UUID</summary>
        public string uuid = "";

        /// <summary>作成日時</summary>
        public long insDtTime;

        /// <summary>更新日時</summary>
        public long updDtTime;

        /// <summary>作成アカウントID</summary>
        public int insAccountId;

        /// <summary>更新アカウントID</summary>
        public int updAccountId;

        /// <summary>論理削除区分</summary>
        public int logicalDelDiv;

        /// <summary>商品カテゴリーID</summary>
        public long goodsCategoryId;

        /// <summary>商品カテゴリー名</summary>
        public string goodsCategoryName = "";


        /// public propaty name  :  uuid
        /// <summary>UUIDプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UUIDプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Uuid
        {
            get { return uuid; }
            set { uuid = value; }
        }

        /// public propaty name  :  insDtTime
        /// <summary>作成日時プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public long InsDtTime
        {
            get { return insDtTime; }
            set { insDtTime = value; }
        }

        /// public propaty name  :  upd_dt_time
        /// <summary>更新日時プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public long UpdDtTime
        {
            get { return updDtTime; }
            set { updDtTime = value; }
        }

        /// public propaty name  :  ins_account_id
        /// <summary>作成アカウントIDプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成アカウントIDプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public int InsAccountId
        {
            get { return insAccountId; }
            set { insAccountId = value; }
        }

        /// public propaty name  :  upd_account_id
        /// <summary>更新アカウントIDプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新アカウントIDプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public int UpdAccountId
        {
            get { return updAccountId; }
            set { updAccountId = value; }
        }

        /// public propaty name  :  logical_del_div
        /// <summary>論理削除区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   論理削除区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public int LogicalDelDiv
        {
            get { return logicalDelDiv; }
            set { logicalDelDiv = value; }
        }

        /// public propaty name  :  goods_category_id
        /// <summary>商品カテゴリーIDプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品カテゴリーIDプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public long GoodsCategoryId
        {
            get { return goodsCategoryId; }
            set { goodsCategoryId = value; }
        }

        /// public propaty name  :  goods_category_name
        /// <summary>商品カテゴリー名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品カテゴリー名プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsCategoryName
        {
            get { return goodsCategoryName; }
            set { goodsCategoryName = value; }
        }


        /// <summary>
        /// 商品カテゴリー設定コンストラクタ
        /// </summary>
        /// <returns>t_goods_categoryクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   t_goods_categoryクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public GoodsCategory()
        {
        }

        /// <summary>
        /// 商品カテゴリー設定コンストラクタ
        /// </summary>
        /// <param name="uuid">UUID</param>
        /// <param name="insDtTime">作成日時</param>
        /// <param name="upd_dt_time">更新日時</param>
        /// <param name="ins_account_id">作成アカウントID</param>
        /// <param name="upd_account_id">更新アカウントID</param>
        /// <param name="logical_del_div">論理削除区分</param>
        /// <param name="goods_category_id">商品カテゴリーID</param>
        /// <param name="goods_category_name">商品カテゴリー名</param>
        /// <returns>t_goods_categoryクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   t_goods_categoryクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public GoodsCategory(string uuid, long insDtTime, long upd_dt_time, int ins_account_id, int upd_account_id, int logical_del_div, long goods_category_id, string goods_category_name)
        {
            this.uuid = uuid;
            this.insDtTime = insDtTime;
            this.updDtTime = upd_dt_time;
            this.insAccountId = ins_account_id;
            this.updAccountId = upd_account_id;
            this.logicalDelDiv = logical_del_div;
            this.goodsCategoryId = goods_category_id;
            this.goodsCategoryName = goods_category_name;

        }

        /// <summary>
        /// 商品カテゴリー設定複製処理
        /// </summary>
        /// <returns>t_goods_categoryクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいt_goods_categoryクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public GoodsCategory Clone()
        {
            return new GoodsCategory(this.uuid, this.insDtTime, this.updDtTime, this.insAccountId, this.updAccountId, this.logicalDelDiv, this.goodsCategoryId, this.goodsCategoryName);
        }

        /// <summary>
        /// 商品カテゴリー設定比較処理
        /// </summary>
        /// <param name="target">比較対象のt_goods_categoryクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   t_goods_categoryクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(GoodsCategory target)
        {
            return ((this.Uuid == target.Uuid)
                 && (this.InsDtTime == target.InsDtTime)
                 && (this.UpdDtTime == target.UpdDtTime)
                 && (this.InsAccountId == target.InsAccountId)
                 && (this.UpdAccountId == target.UpdAccountId)
                 && (this.LogicalDelDiv == target.LogicalDelDiv)
                 && (this.GoodsCategoryId == target.GoodsCategoryId)
                 && (this.GoodsCategoryName == target.GoodsCategoryName));
        }

        /// <summary>
        /// 商品カテゴリー設定比較処理
        /// </summary>
        /// <param name="t_goods_category1">
        ///                    比較するt_goods_categoryクラスのインスタンス
        /// </param>
        /// <param name="t_goods_category2">比較するt_goods_categoryクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   t_goods_categoryクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(GoodsCategory goodsCategory1, GoodsCategory goodsCategory2)
        {
            return ((goodsCategory1.Uuid == goodsCategory2.Uuid)
                 && (goodsCategory1.InsDtTime == goodsCategory2.InsDtTime)
                 && (goodsCategory1.UpdDtTime == goodsCategory2.UpdDtTime)
                 && (goodsCategory1.InsAccountId == goodsCategory2.InsAccountId)
                 && (goodsCategory1.UpdAccountId == goodsCategory2.UpdAccountId)
                 && (goodsCategory1.LogicalDelDiv == goodsCategory2.LogicalDelDiv)
                 && (goodsCategory1.GoodsCategoryId == goodsCategory2.GoodsCategoryId)
                 && (goodsCategory1.GoodsCategoryName == goodsCategory2.GoodsCategoryName));
        }
        /// <summary>
        /// 商品カテゴリー設定比較処理
        /// </summary>
        /// <param name="target">比較対象のt_goods_categoryクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   t_goods_categoryクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(GoodsCategory target)
        {
            ArrayList resList = new ArrayList();
            if (this.Uuid != target.Uuid) resList.Add("Uuid");
            if (this.InsDtTime != target.InsDtTime) resList.Add("InsDtTime");
            if (this.UpdDtTime != target.UpdDtTime) resList.Add("UpdDtTime");
            if (this.InsAccountId != target.InsAccountId) resList.Add("InsAccountId");
            if (this.UpdAccountId != target.UpdAccountId) resList.Add("UpdAccountId");
            if (this.LogicalDelDiv != target.LogicalDelDiv) resList.Add("LogicalDelDiv");
            if (this.GoodsCategoryId != target.GoodsCategoryId) resList.Add("GoodsCategoryId");
            if (this.GoodsCategoryName != target.GoodsCategoryName) resList.Add("GoodsCategoryName");

            return resList;
        }

        /// <summary>
        /// 商品カテゴリー設定比較処理
        /// </summary>
        /// <param name="t_goods_category1">比較するt_goods_categoryクラスのインスタンス</param>
        /// <param name="t_goods_category2">比較するt_goods_categoryクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   t_goods_categoryクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(GoodsCategory goodsCategory1, GoodsCategory goodscategory2)
        {
            ArrayList resList = new ArrayList();
            if (goodsCategory1.Uuid != goodscategory2.Uuid) resList.Add("Uuid");
            if (goodsCategory1.InsDtTime != goodscategory2.InsDtTime) resList.Add("InsDtTime");
            if (goodsCategory1.UpdDtTime != goodscategory2.UpdDtTime) resList.Add("UpdDtTime");
            if (goodsCategory1.InsAccountId != goodscategory2.InsAccountId) resList.Add("InsAccountId");
            if (goodsCategory1.UpdAccountId != goodscategory2.UpdAccountId) resList.Add("UpdAccountId");
            if (goodsCategory1.LogicalDelDiv != goodscategory2.LogicalDelDiv) resList.Add("LogicalDelDiv");
            if (goodsCategory1.GoodsCategoryId != goodscategory2.GoodsCategoryId) resList.Add("GoodsCategoryId");
            if (goodsCategory1.GoodsCategoryName != goodscategory2.GoodsCategoryName) resList.Add("GoodsCategoryName");

            return resList;
        }
    }
}

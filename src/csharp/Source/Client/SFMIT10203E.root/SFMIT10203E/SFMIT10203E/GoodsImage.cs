using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Broadleaf.Application.UIData
{
     /// <summary>
    /// 商品画像メインクラス
    /// </summary>
    public class GoodsImage_MAIN
    {
        public GoodsImage image;
    }

    /// <summary>
    /// 商品画像クラス
    /// </summary>
    public class GoodsImage
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

        /// <summary>画像ID</summary>
        public long imageId;

        /// <summary>画像データBase64</summary>
        public string imageData;

        /// <summary>画像データ</summary>
        public Image imageData_Image;

        /// <summary>画像名称</summary>
        public string imageKeyword;

        /// <summary>商品カテゴリーID</summary>
        public long goodsCategoryId;


        /// <summary>
        /// 商品画像 複製処理
        /// </summary>
        /// <returns>GoodsImageクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいGoodsImageクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public GoodsImage Clone()
        {
            return new GoodsImage(this.uuid, this.insDtTime, this.updDtTime, this.insAccountId, this.updAccountId, this.logicalDelDiv, this.enterpriseCode, this.imageId, this.imageData,this.imageData_Image, this.imageKeyword, this.goodsCategoryId);
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public GoodsImage()
        {

        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public GoodsImage(string uuid, long insDtTime, long updDtTime, int insAccountId, int updAccountId, int logicalDelDiv,
            string enterpriseCode, long imageId, string imageData, Image imageData_Image, string imageKeyword, long goodsCategoryId)
        {
            this.uuid = uuid;
            this.insDtTime = insDtTime;
            this.updDtTime = updDtTime;
            this.insAccountId = insAccountId;
            this.updAccountId = updAccountId;
            this.logicalDelDiv = logicalDelDiv;
            this.enterpriseCode = enterpriseCode;
            this.imageId = imageId;
            this.imageData = imageData;
            this.imageData_Image = imageData_Image;
            this.imageKeyword = imageKeyword;
            this.goodsCategoryId = goodsCategoryId;
        }
    }
}

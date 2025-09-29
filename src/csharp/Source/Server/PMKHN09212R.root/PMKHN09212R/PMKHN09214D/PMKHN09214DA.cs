using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   PriceMergeSt
    /// <summary>
    ///                      価格改正全体設定ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   価格改正全体設定ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/3/17</br>
    /// <br>Genarated Date   :   2008/09/10  (CSharp File Generated Date)</br>
    /// <br></br>
    /// <br>Update Note      : 2009/12/11 21024 佐々木 健</br>
    /// <br>                 :・BLコード更新区分対応(MANTIS[0014775])</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class PriceMergeSt
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";
        
        /// <summary>名称更新区分</summary>
        /// <remarks>0：する　1:しない</remarks>
        private Int32 _nameMergeFlg;

        /// <summary>層別更新区分</summary>
        /// <remarks>0：する　1:しない</remarks>
        private Int32 _goodsRankMergeFlg;

        /// <summary>価格更新区分</summary>
        /// <remarks>0：する　1:しない</remarks>
        private Int32 _priceMergeFlg;

        /// <summary>オープン価格区分</summary>
        /// <remarks>0：価格を引継ぐ　1:０で更新</remarks>
        private Int32 _openPriceFlg;

        /// <summary>価格管理件数</summary>
        /// <remarks>3,4,5　（管理件数をセット）　</remarks>
        private Int32 _priceManage;

        /// <summary>価格改正処理区分</summary>
        /// <remarks>0:シンク処理後直ぐ実行　1:手動実行</remarks>
        private Int32 _priceRevisionFlg;

        // 2009/12/11 Add >>>
        /// <summary>BLコード更新区分</summary>
        /// <remarks>0：する　1:しない</remarks>
        private Int32 _blGoodsCdMergeFlg;
        // 2009/12/11 Add <<<


        /// public propaty name  :  EnterpriseCode
        /// <summary>企業コードプロパティ</summary>
        /// <value>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   企業コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// public propaty name  :  NameMergeFlg
        /// <summary>名称更新区分プロパティ</summary>
        /// <value>0：する　1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   名称更新区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 NameMergeFlg
        {
            get { return _nameMergeFlg; }
            set { _nameMergeFlg = value; }
        }

        /// public propaty name  :  GoodsRankMergeFlg
        /// <summary>層別更新区分プロパティ</summary>
        /// <value>0：する　1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   層別更新区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsRankMergeFlg
        {
            get { return _goodsRankMergeFlg; }
            set { _goodsRankMergeFlg = value; }
        }

        /// public propaty name  :  PriceMergeFlg
        /// <summary>価格更新区分プロパティ</summary>
        /// <value>0：する　1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   価格更新区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PriceMergeFlg
        {
            get { return _priceMergeFlg; }
            set { _priceMergeFlg = value; }
        }

        /// public propaty name  :  OpenPriceFlg
        /// <summary>オープン価格区分プロパティ</summary>
        /// <value>0：価格を引継ぐ　1:０で更新</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   オープン価格区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OpenPriceFlg
        {
            get { return _openPriceFlg; }
            set { _openPriceFlg = value; }
        }

        /// public propaty name  :  PriceManage
        /// <summary>価格管理件数プロパティ</summary>
        /// <value>3,4,5　（管理件数をセット）　</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   価格管理件数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PriceManage
        {
            get { return _priceManage; }
            set { _priceManage = value; }
        }

        /// public propaty name  :  PriceRevisionFlg
        /// <summary>価格改正処理区分プロパティ</summary>
        /// <value>0:シンク処理後直ぐ実行　1:手動実行</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   価格改正処理区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PriceRevisionFlg
        {
            get { return _priceRevisionFlg; }
            set { _priceRevisionFlg = value; }
        }

        // 2009/12/11 Add >>>
        /// public propaty name  :  BLGoodeCodeMergeFlg
        /// <summary>BLコード更新区分プロパティ</summary>
        /// <value>0：する　1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLコード更新区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGoodeCdMergeFlg
        {
            get { return _blGoodsCdMergeFlg; }
            set { _blGoodsCdMergeFlg = value; }
        }
        // 2009/12/11 Add <<<


        /// <summary>
        /// 価格改正全体設定ワークコンストラクタ
        /// </summary>
        /// <returns>PriceMergeStクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PriceMergeStクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PriceMergeSt()
        {
        }

    }

}

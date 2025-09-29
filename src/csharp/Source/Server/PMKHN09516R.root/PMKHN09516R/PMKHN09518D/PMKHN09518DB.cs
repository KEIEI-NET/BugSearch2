//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : ＴＢＯ情報出力
// プログラム概要   : ＴＢＯ情報出力 抽出結果ワーク
//----------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号 : 11270029-00  作成担当 : 黄亜光
// 作 成 日 : 2016/05/20   修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Library.Data;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   TBODataExportResultWork
    /// <summary>
    ///                      ＴＢＯ情報出力結果クラスワークワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   ＴＢＯ情報出力結果クラスワークワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2016/05/20</br>
    /// <br>Genarated Date   :   2016/05/20  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class TBODataExportResultWork
    {
        /// <summary>拠点コード</summary>
        private string _sectionCodeRF = "";

        /// <summary>商品カテゴリ</summary>
        /// <remarks>1:タイヤ,2:バッテリー,3:オイル</remarks>
        private Int32 _goodsCategoryRF;

        /// <summary>商品番号</summary>
        private string _goodsNoRF = "";

        /// <summary>商品名称</summary>
        private string _goodsNameRF = "";

        /// <summary>商品メーカーコード</summary>
        private Int32 _goodsMakerCdRF;

        /// <summary>メーカー名称</summary>
        private string _makerNameRF = "";

        /// <summary>発売日</summary>
        private Int32 _releaseDateRF;

        /// <summary>在庫状況区分</summary>
        /// <remarks>0:入荷待ち,1:在庫不足,2:在庫残少,3:在庫豊富</remarks>
        private Int32 _stockStatusDivRF;

        /// <summary>商品説明</summary>
        /// <remarks>改行コードは\nに置換</remarks>
        private string _goodsNoteRF = "";

        /// <summary>商品PR</summary>
        /// <remarks>改行コードは\nに置換</remarks>
        private string _goodsPRRF = "";

        /// <summary>希望小売価格</summary>
        private Double _suggestPriceRF;

        /// <summary>店頭価格</summary>
        private Double _shopPriceRF;

        /// <summary>卸値</summary>
        private Double _tradePriceRF;

        /// <summary>仕入原価</summary>
        private Double _purchaseCostRF;

        /// <summary>PM更新日時</summary>
        private Int64 _pMUpdateTimeRF;

        /// <summary>検索タグ1</summary>
        private string _searchTag1RF = "";

        /// <summary>検索タグ2</summary>
        private string _searchTag2RF = "";

        /// <summary>検索タグ3</summary>
        private string _searchTag3RF = "";

        /// <summary>検索タグ4</summary>
        private string _searchTag4RF = "";

        /// <summary>検索タグ5</summary>
        private string _searchTag5RF = "";

        /// <summary>検索タグ6</summary>
        private string _searchTag6RF = "";

        /// <summary>検索タグ7</summary>
        private string _searchTag7RF = "";

        /// <summary>検索タグ8</summary>
        private string _searchTag8RF = "";

        /// <summary>検索タグ9</summary>
        private string _searchTag9RF = "";

        /// <summary>検索タグ10</summary>
        private string _searchTag10RF = "";

        /// <summary>在庫数</summary>
        private Double _shipmentPosCntRF;

        /// <summary>最低在庫数</summary>
        private Double _minimumStockCntRF;

        /// <summary>BL商品コード</summary>
        private Int32 _bLGoodsCodeRF;

        /// <summary>BL商品コード枝番</summary>
        private Int32 _bLGoodsCodeDivRF;

        /// public propaty name  :  SectionCodeRF
        /// <summary>拠点コード</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionCodeRF
        {
            get { return _sectionCodeRF; }
            set { _sectionCodeRF = value; }
        }

        /// public propaty name  :  GoodsCategoryRF
        /// <summary>商品カテゴリプロパティ</summary>
        /// <value>1:タイヤ,2:バッテリー,3:オイル,</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品カテゴリプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsCategoryRF
        {
            get { return _goodsCategoryRF; }
            set { _goodsCategoryRF = value; }
        }

        /// public propaty name  :  GoodsNoRF
        /// <summary>商品番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNoRF
        {
            get { return _goodsNoRF; }
            set { _goodsNoRF = value; }
        }

        /// public propaty name  :  GoodsNameRF
        /// <summary>商品名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNameRF
        {
            get { return _goodsNameRF; }
            set { _goodsNameRF = value; }
        }

        /// public propaty name  :  GoodsMakerCdRF
        /// <summary>商品メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCdRF
        {
            get { return _goodsMakerCdRF; }
            set { _goodsMakerCdRF = value; }
        }

        /// public propaty name  :  MakerNameRF
        /// <summary>メーカー名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカー名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MakerNameRF
        {
            get { return _makerNameRF; }
            set { _makerNameRF = value; }
        }

        /// public propaty name  :  ReleaseDateRF
        /// <summary>発売日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発売日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ReleaseDateRF
        {
            get { return _releaseDateRF; }
            set { _releaseDateRF = value; }
        }

        /// public propaty name  :  StockStatusDivRF
        /// <summary>在庫状況区分プロパティ</summary>
        /// <value>0:入荷待ち,1:在庫不足,2:在庫残少,3:在庫豊富</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫状況区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockStatusDivRF
        {
            get { return _stockStatusDivRF; }
            set { _stockStatusDivRF = value; }
        }

        /// public propaty name  :  GoodsNoteRF
        /// <summary>商品説明プロパティ</summary>
        /// <value>改行コードは\nに置換</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品説明プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNoteRF
        {
            get { return _goodsNoteRF; }
            set { _goodsNoteRF = value; }
        }

        /// public propaty name  :  GoodsPRRF
        /// <summary>商品PRコードプロパティ</summary>
        /// <value>改行コードは\nに置換</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品PRプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsPRRF
        {
            get { return _goodsPRRF; }
            set { _goodsPRRF = value; }
        }

        /// public propaty name  :  SuggestPriceRF
        /// <summary>希望小売価格プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   希望小売価格プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SuggestPriceRF
        {
            get { return _suggestPriceRF; }
            set { _suggestPriceRF = value; }
        }

        /// public propaty name  :  ShopPriceRF
        /// <summary>店頭価格プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   店頭価格プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ShopPriceRF
        {
            get { return _shopPriceRF; }
            set { _shopPriceRF = value; }
        }

        /// public propaty name  :  TradePriceRF
        /// <summary>卸値プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   卸値プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double TradePriceRF
        {
            get { return _tradePriceRF; }
            set { _tradePriceRF = value; }
        }

        /// public propaty name  :  PurchaseCostRF
        /// <summary>仕入原価プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入原価プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double PurchaseCostRF
        {
            get { return _purchaseCostRF; }
            set { _purchaseCostRF = value; }
        }

        /// public propaty name  :  PMUpdateTimeRF
        /// <summary>PM更新日時プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PM更新日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 PMUpdateTimeRF
        {
            get { return _pMUpdateTimeRF; }
            set { _pMUpdateTimeRF = value; }
        }

        /// public propaty name  :  SearchTag1RF
        /// <summary>検索タグ1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   検索タグ1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SearchTag1RF
        {
            get { return _searchTag1RF; }
            set { _searchTag1RF = value; }
        }

        /// public propaty name  :  SearchTag2RF
        /// <summary>検索タグ2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   検索タグ2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SearchTag2RF
        {
            get { return _searchTag2RF; }
            set { _searchTag2RF = value; }
        }

        /// public propaty name  :  SearchTag3RF
        /// <summary>検索タグ3プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   検索タグ3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SearchTag3RF
        {
            get { return _searchTag3RF; }
            set { _searchTag3RF = value; }
        }

        /// public propaty name  :  SearchTag4RF
        /// <summary>検索タグ4プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   検索タグ4プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SearchTag4RF
        {
            get { return _searchTag4RF; }
            set { _searchTag4RF = value; }
        }

        /// public propaty name  :  SearchTag5RF
        /// <summary>検索タグ5プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   検索タグ5プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SearchTag5RF
        {
            get { return _searchTag5RF; }
            set { _searchTag5RF = value; }
        }

        /// public propaty name  :  SearchTag6RF
        /// <summary>検索タグ6プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   検索タグ6プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SearchTag6RF
        {
            get { return _searchTag6RF; }
            set { _searchTag6RF = value; }
        }

        /// public propaty name  :  SearchTag7RF
        /// <summary>検索タグ7プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   検索タグ7プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SearchTag7RF
        {
            get { return _searchTag7RF; }
            set { _searchTag7RF = value; }
        }

        /// public propaty name  :  SearchTag8RF
        /// <summary>検索タグ8プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   検索タグ8プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SearchTag8RF
        {
            get { return _searchTag8RF; }
            set { _searchTag8RF = value; }
        }

        /// public propaty name  :  SearchTag9RF
        /// <summary>検索タグ9プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   検索タグ9プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SearchTag9RF
        {
            get { return _searchTag9RF; }
            set { _searchTag9RF = value; }
        }

        /// public propaty name  :  SearchTag10RF
        /// <summary>検索タグ10プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   検索タグ10プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SearchTag10RF
        {
            get { return _searchTag10RF; }
            set { _searchTag10RF = value; }
        }

        /// public propaty name  :  ShipmentPosCntRF
        /// <summary>在庫数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ShipmentPosCntRF
        {
            get { return _shipmentPosCntRF; }
            set { _shipmentPosCntRF = value; }
        }

        /// public propaty name  :  MinimumStockCntRF
        /// <summary>最低在庫数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   最低在庫数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double MinimumStockCntRF
        {
            get { return _minimumStockCntRF; }
            set { _minimumStockCntRF = value; }
        }

        /// public propaty name  :  BLGoodsCodeRF
        /// <summary>BL商品コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGoodsCodeRF
        {
            get { return _bLGoodsCodeRF; }
            set { _bLGoodsCodeRF = value; }
        }

        /// public propaty name  :  BLGoodsCodeDivRF
        /// <summary>BL商品コード枝番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGoodsCodeDivRF
        {
            get { return _bLGoodsCodeDivRF; }
            set { _bLGoodsCodeDivRF = value; }
        }


        /// <summary>
        /// コーエイ個別 ＴＢＯ情報出力抽出結果ワークコンストラクタ
        /// </summary>
        /// <returns>TBODataExportResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   TBODataExportResultWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public TBODataExportResultWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>TBODataExportResultWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   TBODataExportResultWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class TBODataExportResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   TBODataExportResultWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  TBODataExportResultWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is TBODataExportResultWork || graph is ArrayList || graph is TBODataExportResultWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(TBODataExportResultWork).FullName));

            if (graph != null && graph is TBODataExportResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.TBODataExportResultWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is TBODataExportResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((TBODataExportResultWork[])graph).Length;
            }
            else if (graph is TBODataExportResultWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;   //繰り返し数 

            //拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //SectionCodeRF
            //商品カテゴリ
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsCategoryRF
            //商品番号
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNoRF
            //商品名称
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNameRF
            //商品メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32));  //GoodsMakerCdRF
            //メーカー名称
            serInfo.MemberInfo.Add(typeof(string)); //MakerNameRF
            //発売日
            serInfo.MemberInfo.Add(typeof(Int32)); //ReleaseDateRF
            //在庫状況区分
            serInfo.MemberInfo.Add(typeof(Int32)); //StockStatusDivRF
            //商品説明
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNoteRF
            //商品PR
            serInfo.MemberInfo.Add(typeof(string)); //GoodsPRRF
            //希望小売価格
            serInfo.MemberInfo.Add(typeof(Double)); //SuggestPriceRF
            //店頭価格
            serInfo.MemberInfo.Add(typeof(Double)); //ShopPriceRF
            //卸値
            serInfo.MemberInfo.Add(typeof(Double)); //TradePriceRF
            //仕入原価
            serInfo.MemberInfo.Add(typeof(Double)); //PurchaseCostRF
            //PM更新日時
            serInfo.MemberInfo.Add(typeof(Int64)); //PMUpdateTimeRF
            //検索タグ1
            serInfo.MemberInfo.Add(typeof(string)); //SearchTag1RF
            //検索タグ2
            serInfo.MemberInfo.Add(typeof(string)); //SearchTag2RF
            //検索タグ3
            serInfo.MemberInfo.Add(typeof(string)); //SearchTag3RF
            //検索タグ4
            serInfo.MemberInfo.Add(typeof(string)); //SearchTag4RF
            //検索タグ5
            serInfo.MemberInfo.Add(typeof(string)); //SearchTag5RF
            //検索タグ6
            serInfo.MemberInfo.Add(typeof(string)); //SearchTag6RF
            //検索タグ7
            serInfo.MemberInfo.Add(typeof(string)); //SearchTag7RF
            //検索タグ8
            serInfo.MemberInfo.Add(typeof(string)); //SearchTag8RF
            //検索タグ9
            serInfo.MemberInfo.Add(typeof(string)); //SearchTag9RF
            //検索タグ10
            serInfo.MemberInfo.Add(typeof(string)); //SearchTag10RF
            //在庫数
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmentPosCntRF
            //最低在庫数
            serInfo.MemberInfo.Add(typeof(Double)); //MinimumStockCntRF
            //BL商品コード
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCodeRF
            //BL商品コード枝番
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCodeDivRF

            serInfo.Serialize(writer, serInfo);
            if (graph is TBODataExportResultWork)
            {
                TBODataExportResultWork temp = (TBODataExportResultWork)graph;

                TBODataExportResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is TBODataExportResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((TBODataExportResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (TBODataExportResultWork temp in lst)
                {
                    TBODataExportResultWork(writer, temp);
                }
            }
        }

        /// <summary>
        /// TBODataExportResultWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 29;

        /// <summary>
        ///  TBODataExportResultWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   TBODataExportResultWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void TBODataExportResultWork(System.IO.BinaryWriter writer, TBODataExportResultWork temp)
        {
            //拠点コード
            writer.Write(temp.SectionCodeRF);
            //商品カテゴリ
            writer.Write(temp.GoodsCategoryRF);
            //商品番号
            writer.Write(temp.GoodsNoRF);
            //商品名称
            writer.Write(temp.GoodsNameRF);
            //商品メーカーコード
            writer.Write(temp.GoodsMakerCdRF);
            //メーカー名称
            writer.Write(temp.MakerNameRF);
            //発売日
            writer.Write(temp.ReleaseDateRF);
            //在庫状況区分
            writer.Write(temp.StockStatusDivRF);
            //商品説明
            writer.Write(temp.GoodsNoteRF);
            //商品PR
            writer.Write(temp.GoodsPRRF);
            //希望小売価格
            writer.Write(temp.SuggestPriceRF);
            //店頭価格
            writer.Write(temp.ShopPriceRF);
            //卸値
            writer.Write(temp.TradePriceRF);
            //仕入原価
            writer.Write(temp.PurchaseCostRF);
            //PM更新日時
            writer.Write(temp.PMUpdateTimeRF);
            //検索タグ1
            writer.Write(temp.SearchTag1RF);
            //検索タグ2
            writer.Write(temp.SearchTag2RF);
            //検索タグ3
            writer.Write(temp.SearchTag3RF);
            //検索タグ4
            writer.Write(temp.SearchTag4RF);
            //検索タグ5
            writer.Write(temp.SearchTag5RF);
            //検索タグ6
            writer.Write(temp.SearchTag6RF);
            //検索タグ7
            writer.Write(temp.SearchTag7RF);
            //検索タグ8
            writer.Write(temp.SearchTag8RF);
            //検索タグ9
            writer.Write(temp.SearchTag9RF);
            //検索タグ10
            writer.Write(temp.SearchTag10RF);
            //在庫数
            writer.Write(temp.ShipmentPosCntRF);
            //最低在庫数
            writer.Write(temp.MinimumStockCntRF);
            //BL商品コード
            writer.Write(temp.BLGoodsCodeRF);
            //BL商品コード枝番
            writer.Write(temp.BLGoodsCodeDivRF);
        }

        /// <summary>
        ///  TBODataExportResultWorkインスタンス取得
        /// </summary>
        /// <returns>TBODataExportResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   TBODataExportResultWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private TBODataExportResultWork GetTBODataExportResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            TBODataExportResultWork temp = new TBODataExportResultWork();


            //拠点コード
            temp.SectionCodeRF = reader.ReadString();
            //商品カテゴリ
            temp.GoodsCategoryRF = reader.ReadInt32();
            //商品番号
            temp.GoodsNoRF = reader.ReadString();
            //商品名称
            temp.GoodsNameRF = reader.ReadString();
            //商品メーカーコード
            temp.GoodsMakerCdRF = reader.ReadInt32();
            //メーカー名称
            temp.MakerNameRF = reader.ReadString();
            //発売日
            temp.ReleaseDateRF = reader.ReadInt32();
            //在庫状況区分
            temp.StockStatusDivRF = reader.ReadInt32();
            //商品説明
            temp.GoodsNoteRF = reader.ReadString();
            //商品PR
            temp.GoodsPRRF = reader.ReadString();
            //希望小売価格
            temp.SuggestPriceRF = reader.ReadDouble();
            //店頭価格
            temp.ShopPriceRF = reader.ReadDouble();
            //卸値
            temp.TradePriceRF = reader.ReadDouble();
            //仕入原価
            temp.PurchaseCostRF = reader.ReadDouble();
            //PM更新日時
            temp.PMUpdateTimeRF = reader.ReadInt64();
            //検索タグ1
            temp.SearchTag1RF = reader.ReadString();
            //検索タグ2
            temp.SearchTag2RF = reader.ReadString();
            //検索タグ3
            temp.SearchTag3RF = reader.ReadString();
            //検索タグ4
            temp.SearchTag4RF = reader.ReadString();
            //検索タグ5
            temp.SearchTag5RF = reader.ReadString();
            //検索タグ6
            temp.SearchTag6RF = reader.ReadString();
            //検索タグ7
            temp.SearchTag7RF = reader.ReadString();
            //検索タグ8
            temp.SearchTag8RF = reader.ReadString();
            //検索タグ9
            temp.SearchTag9RF = reader.ReadString();
            //検索タグ10
            temp.SearchTag10RF = reader.ReadString();
            //在庫数
            temp.ShipmentPosCntRF = reader.ReadDouble();
            //最低在庫数
            temp.MinimumStockCntRF = reader.ReadDouble();
            //BL商品コード
            temp.BLGoodsCodeRF = reader.ReadInt32();
            //BL商品コード枝番
            temp.BLGoodsCodeDivRF = reader.ReadInt32();


            //以下は読み飛ばしです。このバージョンが想定する EmployeeWork型以降のバージョンの
            //データをデシリアライズする場合、シリアライズしたフォーマッタが記述した
            //型情報にしたがって、ストリームから情報を読み出します...といっても
            //読み出して捨てることになります。
            for (int k = currentMemberCount; k < serInfo.MemberInfo.Count; ++k)
            {
                //byte[],char[]をデシリアライズする直前に、そのlengthが
                //デシリアライズされているケースがある、byte[],char[]の
                //デシリアライズにはlengthが必要なのでint型のデータをデ
                //シリアライズした場合は、この値をこの変数に退避します。
                int optCount = 0;
                object oMemberType = serInfo.MemberInfo[k];
                if (oMemberType is Type)
                {
                    Type t = (Type)oMemberType;
                    object oData = TypeDeserializer.DeserializePrimitiveType(reader, t, optCount);
                    if (t.Equals(typeof(int)))
                    {
                        optCount = Convert.ToInt32(oData);
                    }
                    else
                    {
                        optCount = 0;
                    }
                }
                else if (oMemberType is string)
                {
                    Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate((string)oMemberType);
                    object userData = formatter.Deserialize(reader);  //読み飛ばし
                }
            }
            return temp;
        }

        /// <summary>
        ///  Ver5.10.1.0用のカスタムデシリアライザです
        /// </summary>
        /// <returns>TBODataExportResultWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   TBODataExportResultWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                TBODataExportResultWork temp = GetTBODataExportResultWork(reader, serInfo);
                lst.Add(temp);
            }
            switch (serInfo.RetTypeInfo)
            {
                case 0:
                    retValue = lst;
                    break;
                case 1:
                    retValue = lst[0];
                    break;
                case 2:
                    retValue = (TBODataExportResultWork[])lst.ToArray(typeof(TBODataExportResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }


}


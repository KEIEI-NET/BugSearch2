using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   StockAdjustResultWork
    /// <summary>
    ///                      在庫仕入確認表抽出結果クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   在庫仕入確認表抽出結果クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2009/03/09  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2011/11/15 redmine#26559 許培珠</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class StockAdjustResultWork
    {
        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>拠点ガイド名称</summary>
        private string _sectionGuideNm = "";

        /// <summary>倉庫コード</summary>
        private string _warehouseCode = "";

        /// <summary>倉庫名称</summary>
        private string _warehouseName = "";

        /// <summary>受払元伝票区分</summary>
        /// <remarks>10:仕入,11:受託,12:受計上,13:在庫仕入20:売上,21:売計上,22:委託,23:売切,30:移動出荷,31:移動入荷,40:調整,41:半黒,42:マスタメンテ,50:棚卸,60:組立,61:分解,70:補充入庫,71:補充出庫</remarks>
        private Int32 _acPaySlipCd;

        /// <summary>受払元取引区分</summary>
        /// <remarks>10:通常伝票,11:返品,12:値引,20:赤伝,21:削除,22:解除30:在庫数調整,31:原価調整,32:製番調整,33:不良品,34:抜出,35:消去,40:過不足更新,42:マスタメンテ,90:取消</remarks>
        private Int32 _acPayTransCd;

        /// <summary>調整日付</summary>
        private DateTime _adjustDate;

        /// <summary>在庫調整伝票番号</summary>
        private Int32 _stockAdjustSlipNo;

        /// <summary>在庫調整行番号</summary>
        private Int32 _stockAdjustRowNo;

        /// <summary>商品メーカーコード</summary>
        private Int32 _goodsMakerCd;

        /// <summary>メーカー名称</summary>
        private string _makerName = "";

        /// <summary>商品番号</summary>
        private string _goodsNo = "";

        /// <summary>商品名称</summary>
        private string _goodsName = "";

        /// <summary>入力日付</summary>
        private DateTime _inputDay;

        // ----- DEL 2011/11/15 xupz---------->>>>>
        ///// <summary>仕入入力者コード</summary>
        //private string _stockInputCode = "";

        ///// <summary>仕入入力者名称</summary>
        //private string _stockInputName = "";
        // ----- DEL 2011/11/15 xupz----------<<<<<

        // ----- ADD 2011/11/15 xupz---------->>>>>
        /// <summary>仕入担当者コード</summary>
        private string _stockAgentCode = "";

        /// <summary>仕入担当者名称</summary>
        private string _stockAgentName = "";
        // ----- ADD 2011/11/15 xupz----------<<<<<

        /// <summary>調整数</summary>
        /// <remarks>変更前と変更後の仕入在庫数の差を登録する。</remarks>
        private Double _adjustCount;

        /// <summary>定価（浮動）</summary>
        private Double _listPriceFl;

        /// <summary>仕入単価（税抜,浮動）</summary>
        /// <remarks>在庫調整入力、棚卸過不足更新の単価変更時にセット</remarks>
        private Double _stockUnitPriceFl;

        /// <summary>変更前仕入単価（浮動）</summary>
        private Double _bfStockUnitPriceFl;

        /// <summary>倉庫棚番</summary>
        private string _warehouseShelfNo = "";

        /// <summary>明細備考</summary>
        private string _dtlNote = "";

        /// <summary>伝票備考</summary>
        private string _slipNote = "";

        /// <summary>オープン価格区分</summary>
        private Int32 _openPriceDiv;

        /// <summary>仕入金額（税抜き）</summary>
        private Int64 _stockPriceTaxExc;


        /// public propaty name  :  SectionCode
        /// <summary>拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

        /// public propaty name  :  SectionGuideNm
        /// <summary>拠点ガイド名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点ガイド名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionGuideNm
        {
            get { return _sectionGuideNm; }
            set { _sectionGuideNm = value; }
        }

        /// public propaty name  :  WarehouseCode
        /// <summary>倉庫コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseCode
        {
            get { return _warehouseCode; }
            set { _warehouseCode = value; }
        }

        /// public propaty name  :  WarehouseName
        /// <summary>倉庫名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseName
        {
            get { return _warehouseName; }
            set { _warehouseName = value; }
        }

        /// public propaty name  :  AcPaySlipCd
        /// <summary>受払元伝票区分プロパティ</summary>
        /// <value>10:仕入,11:受託,12:受計上,13:在庫仕入20:売上,21:売計上,22:委託,23:売切,30:移動出荷,31:移動入荷,40:調整,41:半黒,42:マスタメンテ,50:棚卸,60:組立,61:分解,70:補充入庫,71:補充出庫</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受払元伝票区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AcPaySlipCd
        {
            get { return _acPaySlipCd; }
            set { _acPaySlipCd = value; }
        }

        /// public propaty name  :  AcPayTransCd
        /// <summary>受払元取引区分プロパティ</summary>
        /// <value>10:通常伝票,11:返品,12:値引,20:赤伝,21:削除,22:解除30:在庫数調整,31:原価調整,32:製番調整,33:不良品,34:抜出,35:消去,40:過不足更新,42:マスタメンテ,90:取消</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受払元取引区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AcPayTransCd
        {
            get { return _acPayTransCd; }
            set { _acPayTransCd = value; }
        }

        /// public propaty name  :  AdjustDate
        /// <summary>調整日付プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   調整日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime AdjustDate
        {
            get { return _adjustDate; }
            set { _adjustDate = value; }
        }

        /// public propaty name  :  StockAdjustSlipNo
        /// <summary>在庫調整伝票番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫調整伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockAdjustSlipNo
        {
            get { return _stockAdjustSlipNo; }
            set { _stockAdjustSlipNo = value; }
        }

        /// public propaty name  :  StockAdjustRowNo
        /// <summary>在庫調整行番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫調整行番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockAdjustRowNo
        {
            get { return _stockAdjustRowNo; }
            set { _stockAdjustRowNo = value; }
        }

        /// public propaty name  :  GoodsMakerCd
        /// <summary>商品メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCd
        {
            get { return _goodsMakerCd; }
            set { _goodsMakerCd = value; }
        }

        /// public propaty name  :  MakerName
        /// <summary>メーカー名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカー名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MakerName
        {
            get { return _makerName; }
            set { _makerName = value; }
        }

        /// public propaty name  :  GoodsNo
        /// <summary>商品番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNo
        {
            get { return _goodsNo; }
            set { _goodsNo = value; }
        }

        /// public propaty name  :  GoodsName
        /// <summary>商品名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsName
        {
            get { return _goodsName; }
            set { _goodsName = value; }
        }

        /// public propaty name  :  InputDay
        /// <summary>入力日付プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime InputDay
        {
            get { return _inputDay; }
            set { _inputDay = value; }
        }

        // ----- DEL 2011/11/15 xupz---------->>>>>
        ///// public propaty name  :  StockInputCode
        ///// <summary>仕入入力者コードプロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   仕入入力者コードプロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public string StockInputCode
        //{
        //    get { return _stockInputCode; }
        //    set { _stockInputCode = value; }
        //}

        ///// public propaty name  :  StockInputName
        ///// <summary>仕入入力者名称プロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   仕入入力者名称プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public string StockInputName
        //{
        //    get { return _stockInputName; }
        //    set { _stockInputName = value; }
        //}
        // ----- DEL 2011/11/15 xupz----------<<<<<

        // ----- ADD 2011/11/15 xupz---------->>>>>
        /// public propaty name  :  StockAgentCode
        /// <summary>仕入担当者コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入担当者コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockAgentCode
        {
            get { return _stockAgentCode; }
            set { _stockAgentCode = value; }
        }

        /// public propaty name  :  StockAgentName
        /// <summary>仕入担当者名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入担当者名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockAgentName
        {
            get { return _stockAgentName; }
            set { _stockAgentName = value; }
        }
        // ----- ADD 2011/11/15 xupz----------<<<<<

        /// public propaty name  :  AdjustCount
        /// <summary>調整数プロパティ</summary>
        /// <value>変更前と変更後の仕入在庫数の差を登録する。</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   調整数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double AdjustCount
        {
            get { return _adjustCount; }
            set { _adjustCount = value; }
        }

        /// public propaty name  :  ListPriceFl
        /// <summary>定価（浮動）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   定価（浮動）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ListPriceFl
        {
            get { return _listPriceFl; }
            set { _listPriceFl = value; }
        }

        /// public propaty name  :  StockUnitPriceFl
        /// <summary>仕入単価（税抜,浮動）プロパティ</summary>
        /// <value>在庫調整入力、棚卸過不足更新の単価変更時にセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入単価（税抜,浮動）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double StockUnitPriceFl
        {
            get { return _stockUnitPriceFl; }
            set { _stockUnitPriceFl = value; }
        }

        /// public propaty name  :  BfStockUnitPriceFl
        /// <summary>変更前仕入単価（浮動）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   変更前仕入単価（浮動）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double BfStockUnitPriceFl
        {
            get { return _bfStockUnitPriceFl; }
            set { _bfStockUnitPriceFl = value; }
        }

        /// public propaty name  :  WarehouseShelfNo
        /// <summary>倉庫棚番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫棚番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseShelfNo
        {
            get { return _warehouseShelfNo; }
            set { _warehouseShelfNo = value; }
        }

        /// public propaty name  :  DtlNote
        /// <summary>明細備考プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   明細備考プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DtlNote
        {
            get { return _dtlNote; }
            set { _dtlNote = value; }
        }

        /// public propaty name  :  SlipNote
        /// <summary>伝票備考プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票備考プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SlipNote
        {
            get { return _slipNote; }
            set { _slipNote = value; }
        }

        /// public propaty name  :  OpenPriceDiv
        /// <summary>オープン価格区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   オープン価格区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OpenPriceDiv
        {
            get { return _openPriceDiv; }
            set { _openPriceDiv = value; }
        }

        /// public propaty name  :  StockPriceTaxExc
        /// <summary>仕入金額（税抜き）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入金額（税抜き）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockPriceTaxExc
        {
            get { return _stockPriceTaxExc; }
            set { _stockPriceTaxExc = value; }
        }


        /// <summary>
        /// 在庫仕入確認表抽出結果クラスワークコンストラクタ
        /// </summary>
        /// <returns>StockAdjustResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockAdjustResultWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public StockAdjustResultWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>StockAdjustResultWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   StockAdjustResultWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class StockAdjustResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockAdjustResultWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  StockAdjustResultWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is StockAdjustResultWork || graph is ArrayList || graph is StockAdjustResultWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(StockAdjustResultWork).FullName));

            if (graph != null && graph is StockAdjustResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.StockAdjustResultWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is StockAdjustResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((StockAdjustResultWork[])graph).Length;
            }
            else if (graph is StockAdjustResultWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //拠点ガイド名称
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideNm
            //倉庫コード
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseCode
            //倉庫名称
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseName
            //受払元伝票区分
            serInfo.MemberInfo.Add(typeof(Int32)); //AcPaySlipCd
            //受払元取引区分
            serInfo.MemberInfo.Add(typeof(Int32)); //AcPayTransCd
            //調整日付
            serInfo.MemberInfo.Add(typeof(Int32)); //AdjustDate
            //在庫調整伝票番号
            serInfo.MemberInfo.Add(typeof(Int32)); //StockAdjustSlipNo
            //在庫調整行番号
            serInfo.MemberInfo.Add(typeof(Int32)); //StockAdjustRowNo
            //商品メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //メーカー名称
            serInfo.MemberInfo.Add(typeof(string)); //MakerName
            //商品番号
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //商品名称
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            //入力日付
            serInfo.MemberInfo.Add(typeof(Int32)); //InputDay
            // ----- DEL 2011/11/15 xupz---------->>>>>
            ////仕入入力者コード
            //serInfo.MemberInfo.Add(typeof(string)); //StockInputCode
            ////仕入入力者名称
            //serInfo.MemberInfo.Add(typeof(string)); //StockInputName
            // ----- DEL 2011/11/15 xupz----------<<<<<
            // ----- ADD 2011/11/15 xupz---------->>>>>
            //仕入担当者コード
            serInfo.MemberInfo.Add(typeof(string)); //StockAgentCode
            //仕入担当者名称
            serInfo.MemberInfo.Add(typeof(string)); //StockAgentName
            // ----- ADD 2011/11/15 xupz----------<<<<<
            //調整数
            serInfo.MemberInfo.Add(typeof(Double)); //AdjustCount
            //定価（浮動）
            serInfo.MemberInfo.Add(typeof(Double)); //ListPriceFl
            //仕入単価（税抜,浮動）
            serInfo.MemberInfo.Add(typeof(Double)); //StockUnitPriceFl
            //変更前仕入単価（浮動）
            serInfo.MemberInfo.Add(typeof(Double)); //BfStockUnitPriceFl
            //倉庫棚番
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseShelfNo
            //明細備考
            serInfo.MemberInfo.Add(typeof(string)); //DtlNote
            //伝票備考
            serInfo.MemberInfo.Add(typeof(string)); //SlipNote
            //オープン価格区分
            serInfo.MemberInfo.Add(typeof(Int32)); //OpenPriceDiv
            //仕入金額（税抜き）
            serInfo.MemberInfo.Add(typeof(Int64)); //StockPriceTaxExc


            serInfo.Serialize(writer, serInfo);
            if (graph is StockAdjustResultWork)
            {
                StockAdjustResultWork temp = (StockAdjustResultWork)graph;

                SetStockAdjustResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is StockAdjustResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((StockAdjustResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (StockAdjustResultWork temp in lst)
                {
                    SetStockAdjustResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// StockAdjustResultWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 25;

        /// <summary>
        ///  StockAdjustResultWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockAdjustResultWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetStockAdjustResultWork(System.IO.BinaryWriter writer, StockAdjustResultWork temp)
        {
            //拠点コード
            writer.Write(temp.SectionCode);
            //拠点ガイド名称
            writer.Write(temp.SectionGuideNm);
            //倉庫コード
            writer.Write(temp.WarehouseCode);
            //倉庫名称
            writer.Write(temp.WarehouseName);
            //受払元伝票区分
            writer.Write(temp.AcPaySlipCd);
            //受払元取引区分
            writer.Write(temp.AcPayTransCd);
            //調整日付
            writer.Write((Int64)temp.AdjustDate.Ticks);
            //在庫調整伝票番号
            writer.Write(temp.StockAdjustSlipNo);
            //在庫調整行番号
            writer.Write(temp.StockAdjustRowNo);
            //商品メーカーコード
            writer.Write(temp.GoodsMakerCd);
            //メーカー名称
            writer.Write(temp.MakerName);
            //商品番号
            writer.Write(temp.GoodsNo);
            //商品名称
            writer.Write(temp.GoodsName);
            //入力日付
            writer.Write((Int64)temp.InputDay.Ticks);
            // ----- DEL 2011/11/15 xupz---------->>>>>
            ////仕入入力者コード
            //writer.Write(temp.StockInputCode);
            ////仕入入力者名称
            //writer.Write(temp.StockInputName);
            // ----- DEL 2011/11/15 xupz----------<<<<<
            // ----- ADD 2011/11/15 xupz---------->>>>>
            //仕入担当者コード
            writer.Write(temp.StockAgentCode);
            //仕入担当者名称
            writer.Write(temp.StockAgentName);
            // ----- ADD 2011/11/15 xupz----------<<<<<
            //調整数
            writer.Write(temp.AdjustCount);
            //定価（浮動）
            writer.Write(temp.ListPriceFl);
            //仕入単価（税抜,浮動）
            writer.Write(temp.StockUnitPriceFl);
            //変更前仕入単価（浮動）
            writer.Write(temp.BfStockUnitPriceFl);
            //倉庫棚番
            writer.Write(temp.WarehouseShelfNo);
            //明細備考
            writer.Write(temp.DtlNote);
            //伝票備考
            writer.Write(temp.SlipNote);
            //オープン価格区分
            writer.Write(temp.OpenPriceDiv);
            //仕入金額（税抜き）
            writer.Write(temp.StockPriceTaxExc);

        }

        /// <summary>
        ///  StockAdjustResultWorkインスタンス取得
        /// </summary>
        /// <returns>StockAdjustResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockAdjustResultWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private StockAdjustResultWork GetStockAdjustResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            StockAdjustResultWork temp = new StockAdjustResultWork();

            //拠点コード
            temp.SectionCode = reader.ReadString();
            //拠点ガイド名称
            temp.SectionGuideNm = reader.ReadString();
            //倉庫コード
            temp.WarehouseCode = reader.ReadString();
            //倉庫名称
            temp.WarehouseName = reader.ReadString();
            //受払元伝票区分
            temp.AcPaySlipCd = reader.ReadInt32();
            //受払元取引区分
            temp.AcPayTransCd = reader.ReadInt32();
            //調整日付
            temp.AdjustDate = new DateTime(reader.ReadInt64());
            //在庫調整伝票番号
            temp.StockAdjustSlipNo = reader.ReadInt32();
            //在庫調整行番号
            temp.StockAdjustRowNo = reader.ReadInt32();
            //商品メーカーコード
            temp.GoodsMakerCd = reader.ReadInt32();
            //メーカー名称
            temp.MakerName = reader.ReadString();
            //商品番号
            temp.GoodsNo = reader.ReadString();
            //商品名称
            temp.GoodsName = reader.ReadString();
            //入力日付
            temp.InputDay = new DateTime(reader.ReadInt64());
            // ----- DEL 2011/11/15 xupz---------->>>>>
            ////仕入入力者コード
            //temp.StockInputCode = reader.ReadString();
            ////仕入入力者名称
            //temp.StockInputName = reader.ReadString();
            // ----- DEL 2011/11/15 xupz----------<<<<<
            // ----- ADD 2011/11/15 xupz---------->>>>>
            //仕入担当者コード
            temp.StockAgentCode = reader.ReadString();
            //仕入担当者名称
            temp.StockAgentName = reader.ReadString();
            // ----- ADD 2011/11/15 xupz----------<<<<<
            //調整数
            temp.AdjustCount = reader.ReadDouble();
            //定価（浮動）
            temp.ListPriceFl = reader.ReadDouble();
            //仕入単価（税抜,浮動）
            temp.StockUnitPriceFl = reader.ReadDouble();
            //変更前仕入単価（浮動）
            temp.BfStockUnitPriceFl = reader.ReadDouble();
            //倉庫棚番
            temp.WarehouseShelfNo = reader.ReadString();
            //明細備考
            temp.DtlNote = reader.ReadString();
            //伝票備考
            temp.SlipNote = reader.ReadString();
            //オープン価格区分
            temp.OpenPriceDiv = reader.ReadInt32();
            //仕入金額（税抜き）
            temp.StockPriceTaxExc = reader.ReadInt64();


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
        /// <returns>StockAdjustResultWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockAdjustResultWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                StockAdjustResultWork temp = GetStockAdjustResultWork(reader, serInfo);
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
                    retValue = (StockAdjustResultWork[])lst.ToArray(typeof(StockAdjustResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}

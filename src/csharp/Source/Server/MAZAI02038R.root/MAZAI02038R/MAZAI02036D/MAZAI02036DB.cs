using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   StockMoveListResultWork
    /// <summary>
    ///                      在庫・倉庫移動確認表抽出結果クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   在庫・倉庫移動確認表抽出結果クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2009/01/23  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class StockMoveListResultWork
    {
        /// <summary>移動元拠点コード</summary>
        private string _bfSectionCode = "";

        /// <summary>移動元拠点ガイド略称</summary>
        private string _bfSectionGuideSnm = "";

        /// <summary>移動元倉庫コード</summary>
        private string _bfEnterWarehCode = "";

        /// <summary>移動元倉庫名称</summary>
        private string _bfEnterWarehName = "";

        /// <summary>移動元棚番</summary>
        private string _bfShelfNo = "";

        /// <summary>出荷予定日</summary>
        /// <remarks>在庫移動処理（出荷側）を行った時にセット</remarks>
        private DateTime _shipmentScdlDay;

        /// <summary>出荷確定日</summary>
        /// <remarks>出荷確定処理（出荷側）を行った時にセット</remarks>
        private DateTime _shipmentFixDay;

        /// <summary>入荷日</summary>
        /// <remarks>在庫移動処理（入荷側）を行った時にセット</remarks>
        private DateTime _arrivalGoodsDay;

        /// <summary>在庫移動伝票番号</summary>
        private Int32 _stockMoveSlipNo;

        /// <summary>在庫移動行番号</summary>
        private Int32 _stockMoveRowNo;

        /// <summary>移動先拠点コード</summary>
        private string _afSectionCode = "";

        /// <summary>移動先拠点ガイド略称</summary>
        private string _afSectionGuideSnm = "";

        /// <summary>移動先倉庫コード</summary>
        private string _afEnterWarehCode = "";

        /// <summary>移動先倉庫名称</summary>
        private string _afEnterWarehName = "";

        /// <summary>移動先棚番</summary>
        private string _afShelfNo = "";

        /// <summary>商品番号</summary>
        private string _goodsNo = "";

        /// <summary>商品名称</summary>
        private string _goodsName = "";

        /// <summary>定価（浮動）</summary>
        private Double _listPriceFl;

        /// <summary>仕入単価（税抜,浮動）</summary>
        /// <remarks>在庫移動する在庫の仕入価格情報をセット</remarks>
        private Double _stockUnitPriceFl;

        /// <summary>移動数</summary>
        private Double _moveCount;

        /// <summary>入力日</summary>
        /// <remarks>YYYYMMDD　（更新年月日）</remarks>
        private DateTime _inputDay;

        /// <summary>商品メーカーコード</summary>
        private Int32 _goodsMakerCd;

        /// <summary>メーカー名称</summary>
        private string _makerName = "";

        /// <summary>BL商品コード</summary>
        private Int32 _bLGoodsCode;

        /// <summary>BL商品コード名称（全角）</summary>
        private string _bLGoodsFullName = "";

        /// <summary>商品名称カナ</summary>
        private string _goodsNameKana = "";

        /// <summary>仕入先コード</summary>
        private Int32 _supplierCd;

        /// <summary>仕入先略称</summary>
        private string _supplierSnm = "";

        /// <summary>倉庫備考1</summary>
        /// <remarks>在庫移動時の移動伝票に出力する備考をセット</remarks>
        private string _warehouseNote1 = "";

        /// <summary>倉庫備考2</summary>
        /// <remarks>　〃</remarks>
        private string _warehouseNote2 = "";

        /// <summary>伝票摘要</summary>
        /// <remarks>車販の場合、摘要+注文書№+管理番号を格納</remarks>
        private string _outline = "";

        /// <summary>課税区分</summary>
        /// <remarks>0:課税,1:非課税,2:課税（内税）</remarks>
        private Int32 _taxationDivCd;

        /// <summary>伝票発行済区分</summary>
        /// <remarks>0:未発行 1:発行済</remarks>
        private Int32 _slipPrintFinishCd;

        /// <summary>移動金額</summary>
        private Int64 _stockMovePrice;

        /// <summary>在庫移動形式</summary>
        private Int32 _stockMoveFormal;


        /// public propaty name  :  BfSectionCode
        /// <summary>移動元拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   移動元拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BfSectionCode
        {
            get { return _bfSectionCode; }
            set { _bfSectionCode = value; }
        }

        /// public propaty name  :  BfSectionGuideSnm
        /// <summary>移動元拠点ガイド略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   移動元拠点ガイド略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BfSectionGuideSnm
        {
            get { return _bfSectionGuideSnm; }
            set { _bfSectionGuideSnm = value; }
        }

        /// public propaty name  :  BfEnterWarehCode
        /// <summary>移動元倉庫コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   移動元倉庫コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BfEnterWarehCode
        {
            get { return _bfEnterWarehCode; }
            set { _bfEnterWarehCode = value; }
        }

        /// public propaty name  :  BfEnterWarehName
        /// <summary>移動元倉庫名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   移動元倉庫名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BfEnterWarehName
        {
            get { return _bfEnterWarehName; }
            set { _bfEnterWarehName = value; }
        }

        /// public propaty name  :  BfShelfNo
        /// <summary>移動元棚番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   移動元棚番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BfShelfNo
        {
            get { return _bfShelfNo; }
            set { _bfShelfNo = value; }
        }

        /// public propaty name  :  ShipmentScdlDay
        /// <summary>出荷予定日プロパティ</summary>
        /// <value>在庫移動処理（出荷側）を行った時にセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷予定日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime ShipmentScdlDay
        {
            get { return _shipmentScdlDay; }
            set { _shipmentScdlDay = value; }
        }

        /// public propaty name  :  ShipmentFixDay
        /// <summary>出荷確定日プロパティ</summary>
        /// <value>出荷確定処理（出荷側）を行った時にセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷確定日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime ShipmentFixDay
        {
            get { return _shipmentFixDay; }
            set { _shipmentFixDay = value; }
        }

        /// public propaty name  :  ArrivalGoodsDay
        /// <summary>入荷日プロパティ</summary>
        /// <value>在庫移動処理（入荷側）を行った時にセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入荷日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime ArrivalGoodsDay
        {
            get { return _arrivalGoodsDay; }
            set { _arrivalGoodsDay = value; }
        }

        /// public propaty name  :  StockMoveSlipNo
        /// <summary>在庫移動伝票番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫移動伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockMoveSlipNo
        {
            get { return _stockMoveSlipNo; }
            set { _stockMoveSlipNo = value; }
        }

        /// public propaty name  :  StockMoveRowNo
        /// <summary>在庫移動行番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫移動行番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockMoveRowNo
        {
            get { return _stockMoveRowNo; }
            set { _stockMoveRowNo = value; }
        }

        /// public propaty name  :  AfSectionCode
        /// <summary>移動先拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   移動先拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AfSectionCode
        {
            get { return _afSectionCode; }
            set { _afSectionCode = value; }
        }

        /// public propaty name  :  AfSectionGuideSnm
        /// <summary>移動先拠点ガイド略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   移動先拠点ガイド略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AfSectionGuideSnm
        {
            get { return _afSectionGuideSnm; }
            set { _afSectionGuideSnm = value; }
        }

        /// public propaty name  :  AfEnterWarehCode
        /// <summary>移動先倉庫コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   移動先倉庫コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AfEnterWarehCode
        {
            get { return _afEnterWarehCode; }
            set { _afEnterWarehCode = value; }
        }

        /// public propaty name  :  AfEnterWarehName
        /// <summary>移動先倉庫名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   移動先倉庫名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AfEnterWarehName
        {
            get { return _afEnterWarehName; }
            set { _afEnterWarehName = value; }
        }

        /// public propaty name  :  AfShelfNo
        /// <summary>移動先棚番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   移動先棚番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AfShelfNo
        {
            get { return _afShelfNo; }
            set { _afShelfNo = value; }
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
        /// <value>在庫移動する在庫の仕入価格情報をセット</value>
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

        /// public propaty name  :  MoveCount
        /// <summary>移動数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   移動数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double MoveCount
        {
            get { return _moveCount; }
            set { _moveCount = value; }
        }

        /// public propaty name  :  InputDay
        /// <summary>入力日プロパティ</summary>
        /// <value>YYYYMMDD　（更新年月日）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime InputDay
        {
            get { return _inputDay; }
            set { _inputDay = value; }
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

        /// public propaty name  :  BLGoodsCode
        /// <summary>BL商品コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGoodsCode
        {
            get { return _bLGoodsCode; }
            set { _bLGoodsCode = value; }
        }

        /// public propaty name  :  BLGoodsFullName
        /// <summary>BL商品コード名称（全角）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL商品コード名称（全角）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BLGoodsFullName
        {
            get { return _bLGoodsFullName; }
            set { _bLGoodsFullName = value; }
        }

        /// public propaty name  :  GoodsNameKana
        /// <summary>商品名称カナプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品名称カナプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNameKana
        {
            get { return _goodsNameKana; }
            set { _goodsNameKana = value; }
        }

        /// public propaty name  :  SupplierCd
        /// <summary>仕入先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierCd
        {
            get { return _supplierCd; }
            set { _supplierCd = value; }
        }

        /// public propaty name  :  SupplierSnm
        /// <summary>仕入先略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierSnm
        {
            get { return _supplierSnm; }
            set { _supplierSnm = value; }
        }

        /// public propaty name  :  WarehouseNote1
        /// <summary>倉庫備考1プロパティ</summary>
        /// <value>在庫移動時の移動伝票に出力する備考をセット</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫備考1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseNote1
        {
            get { return _warehouseNote1; }
            set { _warehouseNote1 = value; }
        }

        /// public propaty name  :  WarehouseNote2
        /// <summary>倉庫備考2プロパティ</summary>
        /// <value>　〃</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫備考2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseNote2
        {
            get { return _warehouseNote2; }
            set { _warehouseNote2 = value; }
        }

        /// public propaty name  :  Outline
        /// <summary>伝票摘要プロパティ</summary>
        /// <value>車販の場合、摘要+注文書№+管理番号を格納</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票摘要プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Outline
        {
            get { return _outline; }
            set { _outline = value; }
        }

        /// public propaty name  :  TaxationDivCd
        /// <summary>課税区分プロパティ</summary>
        /// <value>0:課税,1:非課税,2:課税（内税）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   課税区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TaxationDivCd
        {
            get { return _taxationDivCd; }
            set { _taxationDivCd = value; }
        }

        /// public propaty name  :  SlipPrintFinishCd
        /// <summary>伝票発行済区分プロパティ</summary>
        /// <value>0:未発行 1:発行済</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票発行済区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SlipPrintFinishCd
        {
            get { return _slipPrintFinishCd; }
            set { _slipPrintFinishCd = value; }
        }

        /// public propaty name  :  StockMovePrice
        /// <summary>移動金額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   移動金額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 StockMovePrice
        {
            get { return _stockMovePrice; }
            set { _stockMovePrice = value; }
        }

        /// public propaty name  :  StockMoveFormal
        /// <summary>在庫移動形式プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫移動形式プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockMoveFormal
        {
            get { return _stockMoveFormal; }
            set { _stockMoveFormal = value; }
        }


        /// <summary>
        /// 在庫・倉庫移動確認表抽出結果クラスワークコンストラクタ
        /// </summary>
        /// <returns>StockMoveListResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockMoveListResultWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public StockMoveListResultWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>StockMoveListResultWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   StockMoveListResultWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class StockMoveListResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockMoveListResultWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  StockMoveListResultWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is StockMoveListResultWork || graph is ArrayList || graph is StockMoveListResultWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(StockMoveListResultWork).FullName));

            if (graph != null && graph is StockMoveListResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.StockMoveListResultWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is StockMoveListResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((StockMoveListResultWork[])graph).Length;
            }
            else if (graph is StockMoveListResultWork)
            {

                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //移動元拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //BfSectionCode
            //移動元拠点ガイド略称
            serInfo.MemberInfo.Add(typeof(string)); //BfSectionGuideSnm
            //移動元倉庫コード
            serInfo.MemberInfo.Add(typeof(string)); //BfEnterWarehCode
            //移動元倉庫名称
            serInfo.MemberInfo.Add(typeof(string)); //BfEnterWarehName
            //移動元棚番
            serInfo.MemberInfo.Add(typeof(string)); //BfShelfNo
            //出荷予定日
            serInfo.MemberInfo.Add(typeof(Int32)); //ShipmentScdlDay
            //出荷確定日
            serInfo.MemberInfo.Add(typeof(Int32)); //ShipmentFixDay
            //入荷日
            serInfo.MemberInfo.Add(typeof(Int32)); //ArrivalGoodsDay
            //在庫移動伝票番号
            serInfo.MemberInfo.Add(typeof(Int32)); //StockMoveSlipNo
            //在庫移動行番号
            serInfo.MemberInfo.Add(typeof(Int32)); //StockMoveRowNo
            //移動先拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //AfSectionCode
            //移動先拠点ガイド略称
            serInfo.MemberInfo.Add(typeof(string)); //AfSectionGuideSnm
            //移動先倉庫コード
            serInfo.MemberInfo.Add(typeof(string)); //AfEnterWarehCode
            //移動先倉庫名称
            serInfo.MemberInfo.Add(typeof(string)); //AfEnterWarehName
            //移動先棚番
            serInfo.MemberInfo.Add(typeof(string)); //AfShelfNo
            //商品番号
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //商品名称
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            //定価（浮動）
            serInfo.MemberInfo.Add(typeof(Double)); //ListPriceFl
            //仕入単価（税抜,浮動）
            serInfo.MemberInfo.Add(typeof(Double)); //StockUnitPriceFl
            //移動数
            serInfo.MemberInfo.Add(typeof(Double)); //MoveCount
            //入力日
            serInfo.MemberInfo.Add(typeof(Int32)); //InputDay
            //商品メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //メーカー名称
            serInfo.MemberInfo.Add(typeof(string)); //MakerName
            //BL商品コード
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //BL商品コード名称（全角）
            serInfo.MemberInfo.Add(typeof(string)); //BLGoodsFullName
            //商品名称カナ
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNameKana
            //仕入先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //仕入先略称
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSnm
            //倉庫備考1
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseNote1
            //倉庫備考2
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseNote2
            //伝票摘要
            serInfo.MemberInfo.Add(typeof(string)); //Outline
            //課税区分
            serInfo.MemberInfo.Add(typeof(Int32)); //TaxationDivCd
            //伝票発行済区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipPrintFinishCd
            //移動金額
            serInfo.MemberInfo.Add(typeof(Int64)); //StockMovePrice
            //在庫移動形式
            serInfo.MemberInfo.Add(typeof(Int32)); //StockMoveFormal


            serInfo.Serialize(writer, serInfo);
            if (graph is StockMoveListResultWork)
            {
                StockMoveListResultWork temp = (StockMoveListResultWork)graph;

                SetStockMoveListResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is StockMoveListResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((StockMoveListResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (StockMoveListResultWork temp in lst)
                {
                    SetStockMoveListResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// StockMoveListResultWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 35;

        /// <summary>
        ///  StockMoveListResultWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockMoveListResultWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetStockMoveListResultWork(System.IO.BinaryWriter writer, StockMoveListResultWork temp)
        {
            //移動元拠点コード
            writer.Write(temp.BfSectionCode);
            //移動元拠点ガイド略称
            writer.Write(temp.BfSectionGuideSnm);
            //移動元倉庫コード
            writer.Write(temp.BfEnterWarehCode);
            //移動元倉庫名称
            writer.Write(temp.BfEnterWarehName);
            //移動元棚番
            writer.Write(temp.BfShelfNo);
            //出荷予定日
            writer.Write((Int64)temp.ShipmentScdlDay.Ticks);
            //出荷確定日
            writer.Write((Int64)temp.ShipmentFixDay.Ticks);
            //入荷日
            writer.Write((Int64)temp.ArrivalGoodsDay.Ticks);
            //在庫移動伝票番号
            writer.Write(temp.StockMoveSlipNo);
            //在庫移動行番号
            writer.Write(temp.StockMoveRowNo);
            //移動先拠点コード
            writer.Write(temp.AfSectionCode);
            //移動先拠点ガイド略称
            writer.Write(temp.AfSectionGuideSnm);
            //移動先倉庫コード
            writer.Write(temp.AfEnterWarehCode);
            //移動先倉庫名称
            writer.Write(temp.AfEnterWarehName);
            //移動先棚番
            writer.Write(temp.AfShelfNo);
            //商品番号
            writer.Write(temp.GoodsNo);
            //商品名称
            writer.Write(temp.GoodsName);
            //定価（浮動）
            writer.Write(temp.ListPriceFl);
            //仕入単価（税抜,浮動）
            writer.Write(temp.StockUnitPriceFl);
            //移動数
            writer.Write(temp.MoveCount);
            //入力日
            writer.Write((Int64)temp.InputDay.Ticks);
            //商品メーカーコード
            writer.Write(temp.GoodsMakerCd);
            //メーカー名称
            writer.Write(temp.MakerName);
            //BL商品コード
            writer.Write(temp.BLGoodsCode);
            //BL商品コード名称（全角）
            writer.Write(temp.BLGoodsFullName);
            //商品名称カナ
            writer.Write(temp.GoodsNameKana);
            //仕入先コード
            writer.Write(temp.SupplierCd);
            //仕入先略称
            writer.Write(temp.SupplierSnm);
            //倉庫備考1
            writer.Write(temp.WarehouseNote1);
            //倉庫備考2
            writer.Write(temp.WarehouseNote2);
            //伝票摘要
            writer.Write(temp.Outline);
            //課税区分
            writer.Write(temp.TaxationDivCd);
            //伝票発行済区分
            writer.Write(temp.SlipPrintFinishCd);
            //移動金額
            writer.Write(temp.StockMovePrice);
            //在庫移動形式
            writer.Write(temp.StockMoveFormal);

        }

        /// <summary>
        ///  StockMoveListResultWorkインスタンス取得
        /// </summary>
        /// <returns>StockMoveListResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockMoveListResultWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private StockMoveListResultWork GetStockMoveListResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            StockMoveListResultWork temp = new StockMoveListResultWork();

            //移動元拠点コード
            temp.BfSectionCode = reader.ReadString();
            //移動元拠点ガイド略称
            temp.BfSectionGuideSnm = reader.ReadString();
            //移動元倉庫コード
            temp.BfEnterWarehCode = reader.ReadString();
            //移動元倉庫名称
            temp.BfEnterWarehName = reader.ReadString();
            //移動元棚番
            temp.BfShelfNo = reader.ReadString();
            //出荷予定日
            temp.ShipmentScdlDay = new DateTime(reader.ReadInt64());
            //出荷確定日
            temp.ShipmentFixDay = new DateTime(reader.ReadInt64());
            //入荷日
            temp.ArrivalGoodsDay = new DateTime(reader.ReadInt64());
            //在庫移動伝票番号
            temp.StockMoveSlipNo = reader.ReadInt32();
            //在庫移動行番号
            temp.StockMoveRowNo = reader.ReadInt32();
            //移動先拠点コード
            temp.AfSectionCode = reader.ReadString();
            //移動先拠点ガイド略称
            temp.AfSectionGuideSnm = reader.ReadString();
            //移動先倉庫コード
            temp.AfEnterWarehCode = reader.ReadString();
            //移動先倉庫名称
            temp.AfEnterWarehName = reader.ReadString();
            //移動先棚番
            temp.AfShelfNo = reader.ReadString();
            //商品番号
            temp.GoodsNo = reader.ReadString();
            //商品名称
            temp.GoodsName = reader.ReadString();
            //定価（浮動）
            temp.ListPriceFl = reader.ReadDouble();
            //仕入単価（税抜,浮動）
            temp.StockUnitPriceFl = reader.ReadDouble();
            //移動数
            temp.MoveCount = reader.ReadDouble();
            //入力日
            temp.InputDay = new DateTime(reader.ReadInt64());
            //商品メーカーコード
            temp.GoodsMakerCd = reader.ReadInt32();
            //メーカー名称
            temp.MakerName = reader.ReadString();
            //BL商品コード
            temp.BLGoodsCode = reader.ReadInt32();
            //BL商品コード名称（全角）
            temp.BLGoodsFullName = reader.ReadString();
            //商品名称カナ
            temp.GoodsNameKana = reader.ReadString();
            //仕入先コード
            temp.SupplierCd = reader.ReadInt32();
            //仕入先略称
            temp.SupplierSnm = reader.ReadString();
            //倉庫備考1
            temp.WarehouseNote1 = reader.ReadString();
            //倉庫備考2
            temp.WarehouseNote2 = reader.ReadString();
            //伝票摘要
            temp.Outline = reader.ReadString();
            //課税区分
            temp.TaxationDivCd = reader.ReadInt32();
            //伝票発行済区分
            temp.SlipPrintFinishCd = reader.ReadInt32();
            //移動金額
            temp.StockMovePrice = reader.ReadInt64();
            //在庫移動形式
            temp.StockMoveFormal = reader.ReadInt32();


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
        /// <returns>StockMoveListResultWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockMoveListResultWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                StockMoveListResultWork temp = GetStockMoveListResultWork(reader, serInfo);
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
                    retValue = (StockMoveListResultWork[])lst.ToArray(typeof(StockMoveListResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}

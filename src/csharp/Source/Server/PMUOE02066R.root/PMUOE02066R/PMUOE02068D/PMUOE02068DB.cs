using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   EnterSchResultWork
    /// <summary>
    ///                      入庫予定表抽出結果クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   入庫予定表抽出結果クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/12/04  (CSharp File Generated Date)</br>
    /// <br>Note             :   ハンディターミナル二次開発の対応</br>
    /// <br>Programmer       :   譚洪</br>
    /// <br>Date             :   2017/09/14</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class EnterSchResultWork
    {
        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>拠点ガイド略称</summary>
        /// <remarks>帳票印字用</remarks>
        private string _sectionGuideSnm = "";

        /// <summary>倉庫コード</summary>
        private string _warehouseCode = "";

        /// <summary>倉庫名称</summary>
        private string _warehouseName = "";

        /// <summary>倉庫棚番</summary>
        private string _warehouseShelfNo = "";

        /// <summary>商品番号</summary>
        private string _goodsNo = "";

        /// <summary>商品メーカーコード</summary>
        private Int32 _goodsMakerCd;

        /// <summary>商品名称</summary>
        private string _goodsName = "";

        /// <summary>受注数量</summary>
        private Double _acceptAnOrderCnt;

        /// <summary>UOE拠点出庫数</summary>
        private Int32 _uOESectOutGoodsCnt;

        /// <summary>BO出庫数1</summary>
        /// <remarks>サブ本部フォロー数</remarks>
        private Int32 _bOShipmentCnt1;

        /// <summary>BO出庫数2</summary>
        /// <remarks>本部フォロー数</remarks>
        private Int32 _bOShipmentCnt2;

        /// <summary>BO出庫数3</summary>
        /// <remarks>ルートフォロー数</remarks>
        private Int32 _bOShipmentCnt3;

        /// <summary>メーカーフォロー数</summary>
        private Int32 _makerFollowCnt;

        /// <summary>EO引当数</summary>
        private Int32 _eOAlwcCount;

        /// <summary>回答定価</summary>
        private Double _answerListPrice;

        /// <summary>回答原価単価</summary>
        private Double _answerSalesUnitCost;

        /// <summary>仕入先コード</summary>
        private Int32 _supplierCd;

        /// <summary>BO伝票番号１</summary>
        /// <remarks>サブ本部フォロー伝票№</remarks>
        private string _bOSlipNo1 = "";

        /// <summary>BO伝票番号２</summary>
        /// <remarks>本部フォロー伝票№</remarks>
        private string _bOSlipNo2 = "";

        /// <summary>BO伝票番号３</summary>
        /// <remarks>ルートフォロー伝票№</remarks>
        private string _bOSlipNo3 = "";

        /// <summary>UOE拠点伝票番号</summary>
        private string _uOESectionSlipNo = "";

        /// <summary>ＵＯＥリマーク１</summary>
        private string _uoeRemark1 = "";

        /// <summary>ＵＯＥリマーク２</summary>
        private string _uoeRemark2 = "";

        /// <summary>受信日付</summary>
        private DateTime _receiveDate;

        // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- >>>>
        /// <summary>通信アセンブリID</summary>
        private string _commAssemblyId = "";
        // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- <<<<


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

        /// public propaty name  :  SectionGuideSnm
        /// <summary>拠点ガイド略称プロパティ</summary>
        /// <value>帳票印字用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点ガイド略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionGuideSnm
        {
            get { return _sectionGuideSnm; }
            set { _sectionGuideSnm = value; }
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

        /// public propaty name  :  AcceptAnOrderCnt
        /// <summary>受注数量プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注数量プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double AcceptAnOrderCnt
        {
            get { return _acceptAnOrderCnt; }
            set { _acceptAnOrderCnt = value; }
        }

        /// public propaty name  :  UOESectOutGoodsCnt
        /// <summary>UOE拠点出庫数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE拠点出庫数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UOESectOutGoodsCnt
        {
            get { return _uOESectOutGoodsCnt; }
            set { _uOESectOutGoodsCnt = value; }
        }

        /// public propaty name  :  BOShipmentCnt1
        /// <summary>BO出庫数1プロパティ</summary>
        /// <value>サブ本部フォロー数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BO出庫数1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BOShipmentCnt1
        {
            get { return _bOShipmentCnt1; }
            set { _bOShipmentCnt1 = value; }
        }

        /// public propaty name  :  BOShipmentCnt2
        /// <summary>BO出庫数2プロパティ</summary>
        /// <value>本部フォロー数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BO出庫数2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BOShipmentCnt2
        {
            get { return _bOShipmentCnt2; }
            set { _bOShipmentCnt2 = value; }
        }

        /// public propaty name  :  BOShipmentCnt3
        /// <summary>BO出庫数3プロパティ</summary>
        /// <value>ルートフォロー数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BO出庫数3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BOShipmentCnt3
        {
            get { return _bOShipmentCnt3; }
            set { _bOShipmentCnt3 = value; }
        }

        /// public propaty name  :  MakerFollowCnt
        /// <summary>メーカーフォロー数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカーフォロー数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MakerFollowCnt
        {
            get { return _makerFollowCnt; }
            set { _makerFollowCnt = value; }
        }

        /// public propaty name  :  EOAlwcCount
        /// <summary>EO引当数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   EO引当数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EOAlwcCount
        {
            get { return _eOAlwcCount; }
            set { _eOAlwcCount = value; }
        }

        /// public propaty name  :  AnswerListPrice
        /// <summary>回答定価プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回答定価プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double AnswerListPrice
        {
            get { return _answerListPrice; }
            set { _answerListPrice = value; }
        }

        /// public propaty name  :  AnswerSalesUnitCost
        /// <summary>回答原価単価プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回答原価単価プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double AnswerSalesUnitCost
        {
            get { return _answerSalesUnitCost; }
            set { _answerSalesUnitCost = value; }
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

        /// public propaty name  :  BOSlipNo1
        /// <summary>BO伝票番号１プロパティ</summary>
        /// <value>サブ本部フォロー伝票№</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BO伝票番号１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BOSlipNo1
        {
            get { return _bOSlipNo1; }
            set { _bOSlipNo1 = value; }
        }

        /// public propaty name  :  BOSlipNo2
        /// <summary>BO伝票番号２プロパティ</summary>
        /// <value>本部フォロー伝票№</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BO伝票番号２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BOSlipNo2
        {
            get { return _bOSlipNo2; }
            set { _bOSlipNo2 = value; }
        }

        /// public propaty name  :  BOSlipNo3
        /// <summary>BO伝票番号３プロパティ</summary>
        /// <value>ルートフォロー伝票№</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BO伝票番号３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BOSlipNo3
        {
            get { return _bOSlipNo3; }
            set { _bOSlipNo3 = value; }
        }

        /// public propaty name  :  UOESectionSlipNo
        /// <summary>UOE拠点伝票番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE拠点伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UOESectionSlipNo
        {
            get { return _uOESectionSlipNo; }
            set { _uOESectionSlipNo = value; }
        }

        /// public propaty name  :  UoeRemark1
        /// <summary>ＵＯＥリマーク１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ＵＯＥリマーク１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UoeRemark1
        {
            get { return _uoeRemark1; }
            set { _uoeRemark1 = value; }
        }

        /// public propaty name  :  UoeRemark2
        /// <summary>ＵＯＥリマーク２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ＵＯＥリマーク２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UoeRemark2
        {
            get { return _uoeRemark2; }
            set { _uoeRemark2 = value; }
        }

        /// public propaty name  :  ReceiveDate
        /// <summary>受信日付プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受信日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime ReceiveDate
        {
            get { return _receiveDate; }
            set { _receiveDate = value; }
        }

        // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- >>>>
        /// public propaty name  :  CommAssemblyId
        /// <summary>通信アセンブリIDプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   通信アセンブリIDプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CommAssemblyId
        {
            get { return _commAssemblyId; }
            set { _commAssemblyId = value; }
        }
        // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- <<<<

        /// <summary>
        /// 入庫予定表抽出結果クラスワークコンストラクタ
        /// </summary>
        /// <returns>EnterSchResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   EnterSchResultWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public EnterSchResultWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>EnterSchResultWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   EnterSchResultWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class EnterSchResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   EnterSchResultWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>UpdateNote       :   ハンディターミナル二次開発の対応</br>
        /// <br>Programmer       :   譚洪</br>
        /// <br>Date             :   2017/09/14</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  EnterSchResultWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is EnterSchResultWork || graph is ArrayList || graph is EnterSchResultWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(EnterSchResultWork).FullName));

            if (graph != null && graph is EnterSchResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.EnterSchResultWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is EnterSchResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((EnterSchResultWork[])graph).Length;
            }
            else if (graph is EnterSchResultWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //拠点ガイド略称
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideSnm
            //倉庫コード
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseCode
            //倉庫名称
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseName
            //倉庫棚番
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseShelfNo
            //商品番号
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //商品メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //商品名称
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            //受注数量
            serInfo.MemberInfo.Add(typeof(Double)); //AcceptAnOrderCnt
            //UOE拠点出庫数
            serInfo.MemberInfo.Add(typeof(Int32)); //UOESectOutGoodsCnt
            //BO出庫数1
            serInfo.MemberInfo.Add(typeof(Int32)); //BOShipmentCnt1
            //BO出庫数2
            serInfo.MemberInfo.Add(typeof(Int32)); //BOShipmentCnt2
            //BO出庫数3
            serInfo.MemberInfo.Add(typeof(Int32)); //BOShipmentCnt3
            //メーカーフォロー数
            serInfo.MemberInfo.Add(typeof(Int32)); //MakerFollowCnt
            //EO引当数
            serInfo.MemberInfo.Add(typeof(Int32)); //EOAlwcCount
            //回答定価
            serInfo.MemberInfo.Add(typeof(Double)); //AnswerListPrice
            //回答原価単価
            serInfo.MemberInfo.Add(typeof(Double)); //AnswerSalesUnitCost
            //仕入先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //BO伝票番号１
            serInfo.MemberInfo.Add(typeof(string)); //BOSlipNo1
            //BO伝票番号２
            serInfo.MemberInfo.Add(typeof(string)); //BOSlipNo2
            //BO伝票番号３
            serInfo.MemberInfo.Add(typeof(string)); //BOSlipNo3
            //UOE拠点伝票番号
            serInfo.MemberInfo.Add(typeof(string)); //UOESectionSlipNo
            //ＵＯＥリマーク１
            serInfo.MemberInfo.Add(typeof(string)); //UoeRemark1
            //ＵＯＥリマーク２
            serInfo.MemberInfo.Add(typeof(string)); //UoeRemark2
            //受信日付
            serInfo.MemberInfo.Add(typeof(Int32)); //ReceiveDate

            // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- >>>>
            //通信アセンブリID
            serInfo.MemberInfo.Add(typeof(string)); //CommAssemblyId
            // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- <<<<

            serInfo.Serialize(writer, serInfo);
            if (graph is EnterSchResultWork)
            {
                EnterSchResultWork temp = (EnterSchResultWork)graph;

                SetEnterSchResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is EnterSchResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((EnterSchResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (EnterSchResultWork temp in lst)
                {
                    SetEnterSchResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// EnterSchResultWorkメンバ数(publicプロパティ数)
        /// </summary>
        //private const int currentMemberCount = 25;  // DEL 2017/09/14 譚洪 ハンディターミナル二次開発
        private const int currentMemberCount = 26;  // ADD 2017/09/14 譚洪 ハンディターミナル二次開発

        /// <summary>
        ///  EnterSchResultWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   EnterSchResultWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>UpdateNote       :   ハンディターミナル二次開発の対応</br>
        /// <br>Programmer       :   譚洪</br>
        /// <br>Date             :   2017/09/14</br>
        /// </remarks>
        private void SetEnterSchResultWork(System.IO.BinaryWriter writer, EnterSchResultWork temp)
        {
            //拠点コード
            writer.Write(temp.SectionCode);
            //拠点ガイド略称
            writer.Write(temp.SectionGuideSnm);
            //倉庫コード
            writer.Write(temp.WarehouseCode);
            //倉庫名称
            writer.Write(temp.WarehouseName);
            //倉庫棚番
            writer.Write(temp.WarehouseShelfNo);
            //商品番号
            writer.Write(temp.GoodsNo);
            //商品メーカーコード
            writer.Write(temp.GoodsMakerCd);
            //商品名称
            writer.Write(temp.GoodsName);
            //受注数量
            writer.Write(temp.AcceptAnOrderCnt);
            //UOE拠点出庫数
            writer.Write(temp.UOESectOutGoodsCnt);
            //BO出庫数1
            writer.Write(temp.BOShipmentCnt1);
            //BO出庫数2
            writer.Write(temp.BOShipmentCnt2);
            //BO出庫数3
            writer.Write(temp.BOShipmentCnt3);
            //メーカーフォロー数
            writer.Write(temp.MakerFollowCnt);
            //EO引当数
            writer.Write(temp.EOAlwcCount);
            //回答定価
            writer.Write(temp.AnswerListPrice);
            //回答原価単価
            writer.Write(temp.AnswerSalesUnitCost);
            //仕入先コード
            writer.Write(temp.SupplierCd);
            //BO伝票番号１
            writer.Write(temp.BOSlipNo1);
            //BO伝票番号２
            writer.Write(temp.BOSlipNo2);
            //BO伝票番号３
            writer.Write(temp.BOSlipNo3);
            //UOE拠点伝票番号
            writer.Write(temp.UOESectionSlipNo);
            //ＵＯＥリマーク１
            writer.Write(temp.UoeRemark1);
            //ＵＯＥリマーク２
            writer.Write(temp.UoeRemark2);
            //受信日付
            writer.Write((Int64)temp.ReceiveDate.Ticks);

            // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- >>>>
            //通信アセンブリID
            writer.Write(temp.CommAssemblyId);
            // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- <<<<

        }

        /// <summary>
        ///  EnterSchResultWorkインスタンス取得
        /// </summary>
        /// <returns>EnterSchResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   EnterSchResultWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>UpdateNote       :   ハンディターミナル二次開発の対応</br>
        /// <br>Programmer       :   譚洪</br>
        /// <br>Date             :   2017/09/14</br>
        /// </remarks>
        private EnterSchResultWork GetEnterSchResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            EnterSchResultWork temp = new EnterSchResultWork();

            //拠点コード
            temp.SectionCode = reader.ReadString();
            //拠点ガイド略称
            temp.SectionGuideSnm = reader.ReadString();
            //倉庫コード
            temp.WarehouseCode = reader.ReadString();
            //倉庫名称
            temp.WarehouseName = reader.ReadString();
            //倉庫棚番
            temp.WarehouseShelfNo = reader.ReadString();
            //商品番号
            temp.GoodsNo = reader.ReadString();
            //商品メーカーコード
            temp.GoodsMakerCd = reader.ReadInt32();
            //商品名称
            temp.GoodsName = reader.ReadString();
            //受注数量
            temp.AcceptAnOrderCnt = reader.ReadDouble();
            //UOE拠点出庫数
            temp.UOESectOutGoodsCnt = reader.ReadInt32();
            //BO出庫数1
            temp.BOShipmentCnt1 = reader.ReadInt32();
            //BO出庫数2
            temp.BOShipmentCnt2 = reader.ReadInt32();
            //BO出庫数3
            temp.BOShipmentCnt3 = reader.ReadInt32();
            //メーカーフォロー数
            temp.MakerFollowCnt = reader.ReadInt32();
            //EO引当数
            temp.EOAlwcCount = reader.ReadInt32();
            //回答定価
            temp.AnswerListPrice = reader.ReadDouble();
            //回答原価単価
            temp.AnswerSalesUnitCost = reader.ReadDouble();
            //仕入先コード
            temp.SupplierCd = reader.ReadInt32();
            //BO伝票番号１
            temp.BOSlipNo1 = reader.ReadString();
            //BO伝票番号２
            temp.BOSlipNo2 = reader.ReadString();
            //BO伝票番号３
            temp.BOSlipNo3 = reader.ReadString();
            //UOE拠点伝票番号
            temp.UOESectionSlipNo = reader.ReadString();
            //ＵＯＥリマーク１
            temp.UoeRemark1 = reader.ReadString();
            //ＵＯＥリマーク２
            temp.UoeRemark2 = reader.ReadString();
            //受信日付
            temp.ReceiveDate = new DateTime(reader.ReadInt64());

            // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- >>>>
            //通信アセンブリID
            temp.CommAssemblyId = reader.ReadString();
            // ------ ADD 2017/09/14 譚洪 ハンディターミナル二次開発 --------- <<<<


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
        /// <returns>EnterSchResultWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   EnterSchResultWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                EnterSchResultWork temp = GetEnterSchResultWork(reader, serInfo);
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
                    retValue = (EnterSchResultWork[])lst.ToArray(typeof(EnterSchResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }



}

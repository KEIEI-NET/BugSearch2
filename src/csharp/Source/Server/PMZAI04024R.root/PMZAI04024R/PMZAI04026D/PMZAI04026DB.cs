using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   StckAssemOvhulRstWork
    /// <summary>
    ///                      在庫組立・分解処理抽出結果クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   在庫組立・分解処理抽出結果クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/10/06  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class StckAssemOvhulRstWork
    {
        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>親商品番号</summary>
        private string _parentGoodsNo = "";

        /// <summary>親商品名称カナ</summary>
        private string _parentGoodsNameKana = "";

        /// <summary>親商品メーカーコード</summary>
        private Int32 _parentGoodsMakerCd;

        /// <summary>親メーカー略称</summary>
        private string _parentMakerShortName = "";

        /// <summary>親倉庫コード</summary>
        private string _parentWarehouseCode = "";

        /// <summary>親倉庫名称</summary>
        private string _parentWarehouseName = "";

        /// <summary>親現在在庫数</summary>
        /// <remarks>仕入在庫数</remarks>
        private Double _parentSupplierStock;

        /// <summary>親最高在庫数</summary>
        private Double _parentMaximumStockCnt;

        /// <summary>親最低在庫数</summary>
        private Double _parentMinimumStockCnt;

        /// <summary>表示順位</summary>
        private Int32 _displayOrder;

        /// <summary>子商品番号</summary>
        private string _subGoodsNo = "";

        /// <summary>子商品名称カナ</summary>
        private string _subGoodsNameKana = "";

        /// <summary>子商品メーカーコード</summary>
        private Int32 _subGoodsMakerCd;

        /// <summary>QTY</summary>
        /// <remarks>数量（浮動）</remarks>
        private Double _cntFl;

        /// <summary>提供区分</summary>
        /// <remarks>0:ユーザデータ,1:提供データ</remarks>
        private Int32 _offerDataDiv;

        /// <summary>子現在在庫数</summary>
        /// <remarks>仕入在庫数</remarks>
        private Double _subSupplierStock;

        /// <summary>拠点倉庫コード１</summary>
        /// <remarks>拠点毎の倉庫優先順位1</remarks>
        private string _sectWarehouseCd1 = "";

        /// <summary>拠点倉庫コード２</summary>
        /// <remarks>拠点毎の倉庫優先順位2</remarks>
        private string _sectWarehouseCd2 = "";

        /// <summary>拠点倉庫コード３</summary>
        /// <remarks>拠点毎の倉庫優先順位3</remarks>
        private string _sectWarehouseCd3 = "";


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

        /// public propaty name  :  ParentGoodsNo
        /// <summary>親商品番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   親商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ParentGoodsNo
        {
            get { return _parentGoodsNo; }
            set { _parentGoodsNo = value; }
        }

        /// public propaty name  :  ParentGoodsNameKana
        /// <summary>親商品名称カナプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   親商品名称カナプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ParentGoodsNameKana
        {
            get { return _parentGoodsNameKana; }
            set { _parentGoodsNameKana = value; }
        }

        /// public propaty name  :  ParentGoodsMakerCd
        /// <summary>親商品メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   親商品メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ParentGoodsMakerCd
        {
            get { return _parentGoodsMakerCd; }
            set { _parentGoodsMakerCd = value; }
        }

        /// public propaty name  :  ParentMakerShortName
        /// <summary>親メーカー略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   親メーカー略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ParentMakerShortName
        {
            get { return _parentMakerShortName; }
            set { _parentMakerShortName = value; }
        }

        /// public propaty name  :  ParentWarehouseCode
        /// <summary>親倉庫コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   親倉庫コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ParentWarehouseCode
        {
            get { return _parentWarehouseCode; }
            set { _parentWarehouseCode = value; }
        }

        /// public propaty name  :  ParentWarehouseName
        /// <summary>親倉庫名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   親倉庫名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ParentWarehouseName
        {
            get { return _parentWarehouseName; }
            set { _parentWarehouseName = value; }
        }

        /// public propaty name  :  ParentSupplierStock
        /// <summary>親現在在庫数プロパティ</summary>
        /// <value>仕入在庫数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   親現在在庫数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ParentSupplierStock
        {
            get { return _parentSupplierStock; }
            set { _parentSupplierStock = value; }
        }

        /// public propaty name  :  ParentMaximumStockCnt
        /// <summary>親最高在庫数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   親最高在庫数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ParentMaximumStockCnt
        {
            get { return _parentMaximumStockCnt; }
            set { _parentMaximumStockCnt = value; }
        }

        /// public propaty name  :  ParentMinimumStockCnt
        /// <summary>親最低在庫数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   親最低在庫数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ParentMinimumStockCnt
        {
            get { return _parentMinimumStockCnt; }
            set { _parentMinimumStockCnt = value; }
        }

        /// public propaty name  :  DisplayOrder
        /// <summary>表示順位プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   表示順位プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DisplayOrder
        {
            get { return _displayOrder; }
            set { _displayOrder = value; }
        }

        /// public propaty name  :  SubGoodsNo
        /// <summary>子商品番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   子商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SubGoodsNo
        {
            get { return _subGoodsNo; }
            set { _subGoodsNo = value; }
        }

        /// public propaty name  :  SubGoodsNameKana
        /// <summary>子商品名称カナプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   子商品名称カナプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SubGoodsNameKana
        {
            get { return _subGoodsNameKana; }
            set { _subGoodsNameKana = value; }
        }

        /// public propaty name  :  SubGoodsMakerCd
        /// <summary>子商品メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   子商品メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SubGoodsMakerCd
        {
            get { return _subGoodsMakerCd; }
            set { _subGoodsMakerCd = value; }
        }

        /// public propaty name  :  CntFl
        /// <summary>QTYプロパティ</summary>
        /// <value>数量（浮動）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   QTYプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double CntFl
        {
            get { return _cntFl; }
            set { _cntFl = value; }
        }

        /// public propaty name  :  OfferDataDiv
        /// <summary>提供区分プロパティ</summary>
        /// <value>0:ユーザデータ,1:提供データ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   提供区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OfferDataDiv
        {
            get { return _offerDataDiv; }
            set { _offerDataDiv = value; }
        }

        /// public propaty name  :  SubSupplierStock
        /// <summary>子現在在庫数プロパティ</summary>
        /// <value>仕入在庫数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   子現在在庫数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double SubSupplierStock
        {
            get { return _subSupplierStock; }
            set { _subSupplierStock = value; }
        }

        /// public propaty name  :  SectWarehouseCd1
        /// <summary>拠点倉庫コード１プロパティ</summary>
        /// <value>拠点毎の倉庫優先順位1</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点倉庫コード１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectWarehouseCd1
        {
            get { return _sectWarehouseCd1; }
            set { _sectWarehouseCd1 = value; }
        }

        /// public propaty name  :  SectWarehouseCd2
        /// <summary>拠点倉庫コード２プロパティ</summary>
        /// <value>拠点毎の倉庫優先順位2</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点倉庫コード２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectWarehouseCd2
        {
            get { return _sectWarehouseCd2; }
            set { _sectWarehouseCd2 = value; }
        }

        /// public propaty name  :  SectWarehouseCd3
        /// <summary>拠点倉庫コード３プロパティ</summary>
        /// <value>拠点毎の倉庫優先順位3</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点倉庫コード３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectWarehouseCd3
        {
            get { return _sectWarehouseCd3; }
            set { _sectWarehouseCd3 = value; }
        }


        /// <summary>
        /// 在庫組立・分解処理抽出結果クラスワークコンストラクタ
        /// </summary>
        /// <returns>StckAssemOvhulRstWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StckAssemOvhulRstWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public StckAssemOvhulRstWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>StckAssemOvhulRstWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   StckAssemOvhulRstWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class StckAssemOvhulRstWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   StckAssemOvhulRstWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  StckAssemOvhulRstWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is StckAssemOvhulRstWork || graph is ArrayList || graph is StckAssemOvhulRstWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(StckAssemOvhulRstWork).FullName));

            if (graph != null && graph is StckAssemOvhulRstWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.StckAssemOvhulRstWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is StckAssemOvhulRstWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((StckAssemOvhulRstWork[])graph).Length;
            }
            else if (graph is StckAssemOvhulRstWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //親商品番号
            serInfo.MemberInfo.Add(typeof(string)); //ParentGoodsNo
            //親商品名称カナ
            serInfo.MemberInfo.Add(typeof(string)); //ParentGoodsNameKana
            //親商品メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //ParentGoodsMakerCd
            //親メーカー略称
            serInfo.MemberInfo.Add(typeof(string)); //ParentMakerShortName
            //親倉庫コード
            serInfo.MemberInfo.Add(typeof(string)); //ParentWarehouseCode
            //親倉庫名称
            serInfo.MemberInfo.Add(typeof(string)); //ParentWarehouseName
            //親現在在庫数
            serInfo.MemberInfo.Add(typeof(Double)); //ParentSupplierStock
            //親最高在庫数
            serInfo.MemberInfo.Add(typeof(Double)); //ParentMaximumStockCnt
            //親最低在庫数
            serInfo.MemberInfo.Add(typeof(Double)); //ParentMinimumStockCnt
            //表示順位
            serInfo.MemberInfo.Add(typeof(Int32)); //DisplayOrder
            //子商品番号
            serInfo.MemberInfo.Add(typeof(string)); //SubGoodsNo
            //子商品名称カナ
            serInfo.MemberInfo.Add(typeof(string)); //SubGoodsNameKana
            //子商品メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //SubGoodsMakerCd
            //QTY
            serInfo.MemberInfo.Add(typeof(Double)); //CntFl
            //提供区分
            serInfo.MemberInfo.Add(typeof(Int32)); //OfferDataDiv
            //子現在在庫数
            serInfo.MemberInfo.Add(typeof(Double)); //SubSupplierStock
            //拠点倉庫コード１
            serInfo.MemberInfo.Add(typeof(string)); //SectWarehouseCd1
            //拠点倉庫コード２
            serInfo.MemberInfo.Add(typeof(string)); //SectWarehouseCd2
            //拠点倉庫コード３
            serInfo.MemberInfo.Add(typeof(string)); //SectWarehouseCd3


            serInfo.Serialize(writer, serInfo);
            if (graph is StckAssemOvhulRstWork)
            {
                StckAssemOvhulRstWork temp = (StckAssemOvhulRstWork)graph;

                SetStckAssemOvhulRstWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is StckAssemOvhulRstWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((StckAssemOvhulRstWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (StckAssemOvhulRstWork temp in lst)
                {
                    SetStckAssemOvhulRstWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// StckAssemOvhulRstWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 20;

        /// <summary>
        ///  StckAssemOvhulRstWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   StckAssemOvhulRstWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetStckAssemOvhulRstWork(System.IO.BinaryWriter writer, StckAssemOvhulRstWork temp)
        {
            //拠点コード
            writer.Write(temp.SectionCode);
            //親商品番号
            writer.Write(temp.ParentGoodsNo);
            //親商品名称カナ
            writer.Write(temp.ParentGoodsNameKana);
            //親商品メーカーコード
            writer.Write(temp.ParentGoodsMakerCd);
            //親メーカー略称
            writer.Write(temp.ParentMakerShortName);
            //親倉庫コード
            writer.Write(temp.ParentWarehouseCode);
            //親倉庫名称
            writer.Write(temp.ParentWarehouseName);
            //親現在在庫数
            writer.Write(temp.ParentSupplierStock);
            //親最高在庫数
            writer.Write(temp.ParentMaximumStockCnt);
            //親最低在庫数
            writer.Write(temp.ParentMinimumStockCnt);
            //表示順位
            writer.Write(temp.DisplayOrder);
            //子商品番号
            writer.Write(temp.SubGoodsNo);
            //子商品名称カナ
            writer.Write(temp.SubGoodsNameKana);
            //子商品メーカーコード
            writer.Write(temp.SubGoodsMakerCd);
            //QTY
            writer.Write(temp.CntFl);
            //提供区分
            writer.Write(temp.OfferDataDiv);
            //子現在在庫数
            writer.Write(temp.SubSupplierStock);
            //拠点倉庫コード１
            writer.Write(temp.SectWarehouseCd1);
            //拠点倉庫コード２
            writer.Write(temp.SectWarehouseCd2);
            //拠点倉庫コード３
            writer.Write(temp.SectWarehouseCd3);

        }

        /// <summary>
        ///  StckAssemOvhulRstWorkインスタンス取得
        /// </summary>
        /// <returns>StckAssemOvhulRstWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StckAssemOvhulRstWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private StckAssemOvhulRstWork GetStckAssemOvhulRstWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            StckAssemOvhulRstWork temp = new StckAssemOvhulRstWork();

            //拠点コード
            temp.SectionCode = reader.ReadString();
            //親商品番号
            temp.ParentGoodsNo = reader.ReadString();
            //親商品名称カナ
            temp.ParentGoodsNameKana = reader.ReadString();
            //親商品メーカーコード
            temp.ParentGoodsMakerCd = reader.ReadInt32();
            //親メーカー略称
            temp.ParentMakerShortName = reader.ReadString();
            //親倉庫コード
            temp.ParentWarehouseCode = reader.ReadString();
            //親倉庫名称
            temp.ParentWarehouseName = reader.ReadString();
            //親現在在庫数
            temp.ParentSupplierStock = reader.ReadDouble();
            //親最高在庫数
            temp.ParentMaximumStockCnt = reader.ReadDouble();
            //親最低在庫数
            temp.ParentMinimumStockCnt = reader.ReadDouble();
            //表示順位
            temp.DisplayOrder = reader.ReadInt32();
            //子商品番号
            temp.SubGoodsNo = reader.ReadString();
            //子商品名称カナ
            temp.SubGoodsNameKana = reader.ReadString();
            //子商品メーカーコード
            temp.SubGoodsMakerCd = reader.ReadInt32();
            //QTY
            temp.CntFl = reader.ReadDouble();
            //提供区分
            temp.OfferDataDiv = reader.ReadInt32();
            //子現在在庫数
            temp.SubSupplierStock = reader.ReadDouble();
            //拠点倉庫コード１
            temp.SectWarehouseCd1 = reader.ReadString();
            //拠点倉庫コード２
            temp.SectWarehouseCd2 = reader.ReadString();
            //拠点倉庫コード３
            temp.SectWarehouseCd3 = reader.ReadString();


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
        /// <returns>StckAssemOvhulRstWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StckAssemOvhulRstWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                StckAssemOvhulRstWork temp = GetStckAssemOvhulRstWork(reader, serInfo);
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
                    retValue = (StckAssemOvhulRstWork[])lst.ToArray(typeof(StckAssemOvhulRstWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}

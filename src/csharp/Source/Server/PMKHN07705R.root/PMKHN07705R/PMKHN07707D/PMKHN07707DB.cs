using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SalesSliptextResultWork
    /// <summary>
    ///                      売上データテキスト出力（TMY)結果ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   売上データテキスト出力（TMY)結果ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/3/25</br>
    /// <br>Genarated Date   :   2012/11/02  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SalesSliptextResultWork
    {
        /// <summary>得意先コード</summary>
        private Int32 _customerCode;

        /// <summary>売上日付</summary>
        /// <remarks>(YYYYMMDD)</remarks>
        private Int32 _salesDate;

        /// <summary>売上伝票番号</summary>
        private string _salesSlipNum = "";

        /// <summary>商品番号</summary>
        private string _goodsNo = "";

        /// <summary>商品メーカーコード</summary>
        /// <remarks>ﾊﾟｯｹｰｼﾞ毎にﾕｰｻﾞｰ登録範囲が異なる</remarks>
        private Int32 _goodsMakerCd;

        /// <summary>BL商品コード</summary>
        private Int32 _bLGoodsCode;

        /// <summary>出荷数</summary>
        private Double _shipmentCnt;

        /// <summary>仕入先コード</summary>
        private Int32 _supplierCd;

        /// <summary>売上行番号</summary>
        /// <remarks>一式伝票:ゼロ、セット品の子商品:親商品と同じ行番号</remarks>
        private Int32 _salesRowNo;


        /// public propaty name  :  CustomerCode
        /// <summary>得意先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
        }

        /// public propaty name  :  SalesDate
        /// <summary>売上日付プロパティ</summary>
        /// <value>(YYYYMMDD)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesDate
        {
            get { return _salesDate; }
            set { _salesDate = value; }
        }

        /// public propaty name  :  SalesSlipNum
        /// <summary>売上伝票番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesSlipNum
        {
            get { return _salesSlipNum; }
            set { _salesSlipNum = value; }
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
        /// <value>ﾊﾟｯｹｰｼﾞ毎にﾕｰｻﾞｰ登録範囲が異なる</value>
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

        /// public propaty name  :  ShipmentCnt
        /// <summary>出荷数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ShipmentCnt
        {
            get { return _shipmentCnt; }
            set { _shipmentCnt = value; }
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

        /// public propaty name  :  SalesRowNo
        /// <summary>売上行番号プロパティ</summary>
        /// <value>一式伝票:ゼロ、セット品の子商品:親商品と同じ行番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上行番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesRowNo
        {
            get { return _salesRowNo; }
            set { _salesRowNo = value; }
        }


        /// <summary>
        /// 売上データテキスト出力（TMY)結果ワークコンストラクタ
        /// </summary>
        /// <returns>SalesSliptextResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesSliptextResultWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SalesSliptextResultWork()
        {
        }


    }
    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>SalesSliptextResultWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   SalesSliptextResultWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class SalesSliptextResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesSliptextResultWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SalesSliptextResultWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SalesSliptextResultWork || graph is ArrayList || graph is SalesSliptextResultWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(SalesSliptextResultWork).FullName));

            if (graph != null && graph is SalesSliptextResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SalesSliptextResultWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SalesSliptextResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SalesSliptextResultWork[])graph).Length;
            }
            else if (graph is SalesSliptextResultWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //得意先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //売上日付
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesDate
            //売上伝票番号
            serInfo.MemberInfo.Add(typeof(string)); //SalesSlipNum
            //商品番号
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //商品メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //BL商品コード
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //出荷数
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmentCnt
            //仕入先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //売上行番号
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesRowNo


            serInfo.Serialize(writer, serInfo);
            if (graph is SalesSliptextResultWork)
            {
                SalesSliptextResultWork temp = (SalesSliptextResultWork)graph;

                SetSalesSliptextResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SalesSliptextResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SalesSliptextResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SalesSliptextResultWork temp in lst)
                {
                    SetSalesSliptextResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SalesSliptextResultWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 9;

        /// <summary>
        ///  SalesSliptextResultWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesSliptextResultWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetSalesSliptextResultWork(System.IO.BinaryWriter writer, SalesSliptextResultWork temp)
        {
            //得意先コード
            writer.Write(temp.CustomerCode);
            //売上日付
            writer.Write(temp.SalesDate);
            //売上伝票番号
            writer.Write(temp.SalesSlipNum);
            //商品番号
            writer.Write(temp.GoodsNo);
            //商品メーカーコード
            writer.Write(temp.GoodsMakerCd);
            //BL商品コード
            writer.Write(temp.BLGoodsCode);
            //出荷数
            writer.Write(temp.ShipmentCnt);
            //仕入先コード
            writer.Write(temp.SupplierCd);
            //売上行番号
            writer.Write(temp.SalesRowNo);

        }

        /// <summary>
        ///  SalesSliptextResultWorkインスタンス取得
        /// </summary>
        /// <returns>SalesSliptextResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesSliptextResultWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private SalesSliptextResultWork GetSalesSliptextResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            SalesSliptextResultWork temp = new SalesSliptextResultWork();

            //得意先コード
            temp.CustomerCode = reader.ReadInt32();
            //売上日付
            temp.SalesDate = reader.ReadInt32();
            //売上伝票番号
            temp.SalesSlipNum = reader.ReadString();
            //商品番号
            temp.GoodsNo = reader.ReadString();
            //商品メーカーコード
            temp.GoodsMakerCd = reader.ReadInt32();
            //BL商品コード
            temp.BLGoodsCode = reader.ReadInt32();
            //出荷数
            temp.ShipmentCnt = reader.ReadDouble();
            //仕入先コード
            temp.SupplierCd = reader.ReadInt32();
            //売上行番号
            temp.SalesRowNo = reader.ReadInt32();


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
        /// <returns>SalesSliptextResultWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesSliptextResultWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SalesSliptextResultWork temp = GetSalesSliptextResultWork(reader, serInfo);
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
                    retValue = (SalesSliptextResultWork[])lst.ToArray(typeof(SalesSliptextResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}

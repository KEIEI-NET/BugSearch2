using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   TrustStockResultWork
    /// <summary>
    ///                      委託在庫補充処理抽出結果クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   委託在庫補充処理抽出結果クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/11/13  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class TrustStockResultWork
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>倉庫コード(委託)</summary>
        /// <remarks>倉庫マスタ</remarks>
        private string _tru_WarehouseCode = "";

        /// <summary>倉庫名称(委託)</summary>
        private string _tru_WarehouseName = "";

        /// <summary>倉庫コード(補充元)</summary>
        /// <remarks>在庫マスタ </remarks>
        private string _rep_WarehouseCode = "";

        /// <summary>倉庫名称(補充元)</summary>
        private string _rep_WarehouseName = "";

        /// <summary>商品メーカーコード</summary>
        private Int32 _goodsMakerCd;

        /// <summary>メーカー略称</summary>
        private string _makerShortName = "";

        /// <summary>商品番号</summary>
        private string _goodsNo = "";

        /// <summary>商品名称</summary>
        private string _goodsName = "";

        /// <summary>倉庫棚番(委託)</summary>
        private string _tru_WarehouseShelfNo = "";

        /// <summary>最高在庫数</summary>
        private Double _maximumStockCnt;

        /// <summary>出荷可能数(委託)</summary>
        /// <remarks>出荷可能数＝仕入在庫数 ＋ 入荷数（未計上）－ 出荷数（未計上）－受注数 － 移動中仕入在庫数</remarks>
        private Double _tru_ShipmentPosCnt;

        /// <summary>補充数</summary>
        /// <remarks>委託倉庫最高数－委託倉庫現在庫数</remarks>
        private Double _replenishCount;

        /// <summary>補充後現在個数</summary>
        /// <remarks>出荷可能数－補充数</remarks>
        private Double _replenishNStockCount;

        /// <summary>倉庫棚番(補充元)</summary>
        private string _rep_WarehouseShelfNo = "";

        /// <summary>出荷可能数(補充元)</summary>
        /// <remarks>出荷可能数＝仕入在庫数 ＋ 入荷数（未計上）－ 出荷数（未計上）－受注数 － 移動中仕入在庫数</remarks>
        private Double _rep_ShipmentPosCnt;

        /// <summary>商品番号未登録フラグ</summary>
        private Int32 _goodsFlg;

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

        /// public propaty name  :  Tru_WarehouseCode
        /// <summary>倉庫コード(委託)プロパティ</summary>
        /// <value>倉庫マスタ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫コード(委託)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Tru_WarehouseCode
        {
            get { return _tru_WarehouseCode; }
            set { _tru_WarehouseCode = value; }
        }

        /// public propaty name  :  Tru_WarehouseName
        /// <summary>倉庫名称(委託)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫名称(委託)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Tru_WarehouseName
        {
            get { return _tru_WarehouseName; }
            set { _tru_WarehouseName = value; }
        }

        /// public propaty name  :  Rep_WarehouseCode
        /// <summary>倉庫コード(補充元)プロパティ</summary>
        /// <value>在庫マスタ </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫コード(補充元)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Rep_WarehouseCode
        {
            get { return _rep_WarehouseCode; }
            set { _rep_WarehouseCode = value; }
        }

        /// public propaty name  :  Rep_WarehouseName
        /// <summary>倉庫名称(補充元)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫名称(補充元)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Rep_WarehouseName
        {
            get { return _rep_WarehouseName; }
            set { _rep_WarehouseName = value; }
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

        /// public propaty name  :  MakerShortName
        /// <summary>メーカー略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカー略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MakerShortName
        {
            get { return _makerShortName; }
            set { _makerShortName = value; }
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

        /// public propaty name  :  Tru_WarehouseShelfNo
        /// <summary>倉庫棚番(委託)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫棚番(委託)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Tru_WarehouseShelfNo
        {
            get { return _tru_WarehouseShelfNo; }
            set { _tru_WarehouseShelfNo = value; }
        }

        /// public propaty name  :  MaximumStockCnt
        /// <summary>最高在庫数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   最高在庫数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double MaximumStockCnt
        {
            get { return _maximumStockCnt; }
            set { _maximumStockCnt = value; }
        }

        /// public propaty name  :  Tru_ShipmentPosCnt
        /// <summary>出荷可能数(委託)プロパティ</summary>
        /// <value>出荷可能数＝仕入在庫数 ＋ 入荷数（未計上）－ 出荷数（未計上）－受注数 － 移動中仕入在庫数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷可能数(委託)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double Tru_ShipmentPosCnt
        {
            get { return _tru_ShipmentPosCnt; }
            set { _tru_ShipmentPosCnt = value; }
        }

        /// public propaty name  :  ReplenishCount
        /// <summary>補充数プロパティ</summary>
        /// <value>委託倉庫最高数－委託倉庫現在庫数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   補充数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ReplenishCount
        {
            get { return _replenishCount; }
            set { _replenishCount = value; }
        }

        /// public propaty name  :  ReplenishNStockCount
        /// <summary>補充後現在個数プロパティ</summary>
        /// <value>出荷可能数－補充数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   補充後現在個数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double ReplenishNStockCount
        {
            get { return _replenishNStockCount; }
            set { _replenishNStockCount = value; }
        }

        /// public propaty name  :  Rep_WarehouseShelfNo
        /// <summary>倉庫棚番(補充元)プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫棚番(補充元)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Rep_WarehouseShelfNo
        {
            get { return _rep_WarehouseShelfNo; }
            set { _rep_WarehouseShelfNo = value; }
        }

        /// public propaty name  :  Rep_ShipmentPosCnt
        /// <summary>出荷可能数(補充元)プロパティ</summary>
        /// <value>出荷可能数＝仕入在庫数 ＋ 入荷数（未計上）－ 出荷数（未計上）－受注数 － 移動中仕入在庫数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷可能数(補充元)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double Rep_ShipmentPosCnt
        {
            get { return _rep_ShipmentPosCnt; }
            set { _rep_ShipmentPosCnt = value; }
        }

        /// public propaty name  :  GoodsMakerCd
        /// <summary>商品番号未登録フラグプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品番号未登録フラグプロパティプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsFlg
        {
            get { return _goodsFlg; }
            set { _goodsFlg = value; }
        }


        /// <summary>
        /// 委託在庫補充処理抽出結果クラスワークコンストラクタ
        /// </summary>
        /// <returns>TrustStockResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   TrustStockResultWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public TrustStockResultWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>TrustStockResultWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   TrustStockResultWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class TrustStockResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   TrustStockResultWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  TrustStockResultWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is TrustStockResultWork || graph is ArrayList || graph is TrustStockResultWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(TrustStockResultWork).FullName));

            if (graph != null && graph is TrustStockResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.TrustStockResultWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is TrustStockResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((TrustStockResultWork[])graph).Length;
            }
            else if (graph is TrustStockResultWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //企業コード
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //倉庫コード(委託)
            serInfo.MemberInfo.Add(typeof(string)); //Tru_WarehouseCode
            //倉庫名称(委託)
            serInfo.MemberInfo.Add(typeof(string)); //Tru_WarehouseName
            //倉庫コード(補充元)
            serInfo.MemberInfo.Add(typeof(string)); //Rep_WarehouseCode
            //倉庫名称(補充元)
            serInfo.MemberInfo.Add(typeof(string)); //Rep_WarehouseName
            //商品メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //メーカー略称
            serInfo.MemberInfo.Add(typeof(string)); //MakerShortName
            //商品番号
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //商品名称
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            //倉庫棚番(委託)
            serInfo.MemberInfo.Add(typeof(string)); //Tru_WarehouseShelfNo
            //最高在庫数
            serInfo.MemberInfo.Add(typeof(Double)); //MaximumStockCnt
            //出荷可能数(委託)
            serInfo.MemberInfo.Add(typeof(Double)); //Tru_ShipmentPosCnt
            //補充数
            serInfo.MemberInfo.Add(typeof(Double)); //ReplenishCount
            //補充後現在個数
            serInfo.MemberInfo.Add(typeof(Double)); //ReplenishNStockCount
            //倉庫棚番(補充元)
            serInfo.MemberInfo.Add(typeof(string)); //Rep_WarehouseShelfNo
            //出荷可能数(補充元)
            serInfo.MemberInfo.Add(typeof(Double)); //Rep_ShipmentPosCnt
            //商品未登録フラグ
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsFlg


            serInfo.Serialize(writer, serInfo);
            if (graph is TrustStockResultWork)
            {
                TrustStockResultWork temp = (TrustStockResultWork)graph;

                SetTrustStockResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is TrustStockResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((TrustStockResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (TrustStockResultWork temp in lst)
                {
                    SetTrustStockResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// TrustStockResultWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 17;

        /// <summary>
        ///  TrustStockResultWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   TrustStockResultWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetTrustStockResultWork(System.IO.BinaryWriter writer, TrustStockResultWork temp)
        {
            //企業コード
            writer.Write(temp.EnterpriseCode);
            //倉庫コード(委託)
            writer.Write(temp.Tru_WarehouseCode);
            //倉庫名称(委託)
            writer.Write(temp.Tru_WarehouseName);
            //倉庫コード(補充元)
            writer.Write(temp.Rep_WarehouseCode);
            //倉庫名称(補充元)
            writer.Write(temp.Rep_WarehouseName);
            //商品メーカーコード
            writer.Write(temp.GoodsMakerCd);
            //メーカー略称
            writer.Write(temp.MakerShortName);
            //商品番号
            writer.Write(temp.GoodsNo);
            //商品名称
            writer.Write(temp.GoodsName);
            //倉庫棚番(委託)
            writer.Write(temp.Tru_WarehouseShelfNo);
            //最高在庫数
            writer.Write(temp.MaximumStockCnt);
            //出荷可能数(委託)
            writer.Write(temp.Tru_ShipmentPosCnt);
            //補充数
            writer.Write(temp.ReplenishCount);
            //補充後現在個数
            writer.Write(temp.ReplenishNStockCount);
            //倉庫棚番(補充元)
            writer.Write(temp.Rep_WarehouseShelfNo);
            //出荷可能数(補充元)
            writer.Write(temp.Rep_ShipmentPosCnt);
            //商品番号未登録フラグ
            writer.Write(temp.GoodsFlg);

        }

        /// <summary>
        ///  TrustStockResultWorkインスタンス取得
        /// </summary>
        /// <returns>TrustStockResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   TrustStockResultWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private TrustStockResultWork GetTrustStockResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            TrustStockResultWork temp = new TrustStockResultWork();

            //企業コード
            temp.EnterpriseCode = reader.ReadString();
            //倉庫コード(委託)
            temp.Tru_WarehouseCode = reader.ReadString();
            //倉庫名称(委託)
            temp.Tru_WarehouseName = reader.ReadString();
            //倉庫コード(補充元)
            temp.Rep_WarehouseCode = reader.ReadString();
            //倉庫名称(補充元)
            temp.Rep_WarehouseName = reader.ReadString();
            //商品メーカーコード
            temp.GoodsMakerCd = reader.ReadInt32();
            //メーカー略称
            temp.MakerShortName = reader.ReadString();
            //商品番号
            temp.GoodsNo = reader.ReadString();
            //商品名称
            temp.GoodsName = reader.ReadString();
            //倉庫棚番(委託)
            temp.Tru_WarehouseShelfNo = reader.ReadString();
            //最高在庫数
            temp.MaximumStockCnt = reader.ReadDouble();
            //出荷可能数(委託)
            temp.Tru_ShipmentPosCnt = reader.ReadDouble();
            //補充数
            temp.ReplenishCount = reader.ReadDouble();
            //補充後現在個数
            temp.ReplenishNStockCount = reader.ReadDouble();
            //倉庫棚番(補充元)
            temp.Rep_WarehouseShelfNo = reader.ReadString();
            //出荷可能数(補充元)
            temp.Rep_ShipmentPosCnt = reader.ReadDouble();
            //商品番号未登録フラグ
            temp.GoodsFlg = reader.ReadInt32();


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
        /// <returns>TrustStockResultWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   TrustStockResultWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                TrustStockResultWork temp = GetTrustStockResultWork(reader, serInfo);
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
                    retValue = (TrustStockResultWork[])lst.ToArray(typeof(TrustStockResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }


}

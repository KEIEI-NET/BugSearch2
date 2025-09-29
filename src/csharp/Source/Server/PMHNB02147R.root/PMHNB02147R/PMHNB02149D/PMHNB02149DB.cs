using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   ShipGdsPrimeListResultWork
    /// <summary>
    ///                      出荷商品優良対応表抽出結果クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   出荷商品優良対応表抽出結果クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2009/02/12  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class ShipGdsPrimeListResultWork
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>計上拠点コード</summary>
        /// <remarks>集計の対象となっている拠点コード</remarks>
        private string _addUpSecCode = "";

        /// <summary>拠点ガイド略称</summary>
        /// <remarks>帳票印字用</remarks>
        private string _sectionGuideSnm = "";

        /// <summary>商品メーカーコード</summary>
        private Int32 _goodsMakerCd;

        /// <summary>商品番号</summary>
        private string _goodsNo = "";

        //------ ADD START 2014/12/30 尹晶晶 FOR Redmine#44209改良 ------>>>>>
        /// <summary>対応商品番号</summary>
        private string _oldGoodsNo = "";
        //------ ADD END 2014/12/30 尹晶晶 FOR Redmine#44209改良 ------<<<<<

        /// <summary>BLグループコード</summary>
        private Int32 _bLGroupCode;

        /// <summary>売上回数（在庫）</summary>
        /// <remarks>出荷回数(売上時のみ）</remarks>
        private Int32 _st_SalesTimes;

        /// <summary>売上数計（在庫）</summary>
        /// <remarks>出荷数(返品は減算)</remarks>
        private Double _st_TotalSalesCount;

        /// <summary>売上金額（在庫）</summary>
        /// <remarks>税抜き（値引,返品含まず）</remarks>
        private Int64 _st_SalesMoney;

        /// <summary>返品額（在庫）</summary>
        private Int64 _st_SalesRetGoodsPrice;

        /// <summary>値引金額（在庫）</summary>
        private Int64 _st_DiscountPrice;

        /// <summary>粗利金額（在庫）</summary>
        private Int64 _st_GrossProfit;

        /// <summary>売上回数（取寄）</summary>
        /// <remarks>出荷回数(売上時のみ）</remarks>
        private Int32 _or_SalesTimes;

        /// <summary>売上数計（取寄）</summary>
        /// <remarks>出荷数(返品は減算)</remarks>
        private Double _or_TotalSalesCount;

        /// <summary>売上金額（取寄）</summary>
        /// <remarks>税抜き（値引,返品含まず）</remarks>
        private Int64 _or_SalesMoney;

        /// <summary>返品額（取寄）</summary>
        private Int64 _or_SalesRetGoodsPrice;

        /// <summary>値引金額（取寄）</summary>
        private Int64 _or_DiscountPrice;

        /// <summary>粗利金額（取寄）</summary>
        private Int64 _or_GrossProfit;


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

        /// public propaty name  :  AddUpSecCode
        /// <summary>計上拠点コードプロパティ</summary>
        /// <value>集計の対象となっている拠点コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddUpSecCode
        {
            get { return _addUpSecCode; }
            set { _addUpSecCode = value; }
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

        //------ ADD START 2014/12/30 尹晶晶 FOR Redmine#44209改良 ------>>>>>
        /// public propaty name  :  OldGoodsNo
        /// <summary>商品番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string OldGoodsNo
        {
            get { return _oldGoodsNo; }
            set { _oldGoodsNo = value; }
        }
        //------ ADD END 2014/12/30 尹晶晶 FOR Redmine#44209改良 ------<<<<<

        /// public propaty name  :  BLGroupCode
        /// <summary>BLグループコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BLグループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BLGroupCode
        {
            get { return _bLGroupCode; }
            set { _bLGroupCode = value; }
        }

        /// public propaty name  :  St_SalesTimes
        /// <summary>売上回数（在庫）プロパティ</summary>
        /// <value>出荷回数(売上時のみ）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上回数（在庫）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_SalesTimes
        {
            get { return _st_SalesTimes; }
            set { _st_SalesTimes = value; }
        }

        /// public propaty name  :  St_TotalSalesCount
        /// <summary>売上数計（在庫）プロパティ</summary>
        /// <value>出荷数(返品は減算)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上数計（在庫）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double St_TotalSalesCount
        {
            get { return _st_TotalSalesCount; }
            set { _st_TotalSalesCount = value; }
        }

        /// public propaty name  :  St_SalesMoney
        /// <summary>売上金額（在庫）プロパティ</summary>
        /// <value>税抜き（値引,返品含まず）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上金額（在庫）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 St_SalesMoney
        {
            get { return _st_SalesMoney; }
            set { _st_SalesMoney = value; }
        }

        /// public propaty name  :  St_SalesRetGoodsPrice
        /// <summary>返品額（在庫）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   返品額（在庫）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 St_SalesRetGoodsPrice
        {
            get { return _st_SalesRetGoodsPrice; }
            set { _st_SalesRetGoodsPrice = value; }
        }

        /// public propaty name  :  St_DiscountPrice
        /// <summary>値引金額（在庫）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   値引金額（在庫）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 St_DiscountPrice
        {
            get { return _st_DiscountPrice; }
            set { _st_DiscountPrice = value; }
        }

        /// public propaty name  :  St_GrossProfit
        /// <summary>粗利金額（在庫）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   粗利金額（在庫）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 St_GrossProfit
        {
            get { return _st_GrossProfit; }
            set { _st_GrossProfit = value; }
        }

        /// public propaty name  :  Or_SalesTimes
        /// <summary>売上回数（取寄）プロパティ</summary>
        /// <value>出荷回数(売上時のみ）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上回数（取寄）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Or_SalesTimes
        {
            get { return _or_SalesTimes; }
            set { _or_SalesTimes = value; }
        }

        /// public propaty name  :  Or_TotalSalesCount
        /// <summary>売上数計（取寄）プロパティ</summary>
        /// <value>出荷数(返品は減算)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上数計（取寄）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double Or_TotalSalesCount
        {
            get { return _or_TotalSalesCount; }
            set { _or_TotalSalesCount = value; }
        }

        /// public propaty name  :  Or_SalesMoney
        /// <summary>売上金額（取寄）プロパティ</summary>
        /// <value>税抜き（値引,返品含まず）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上金額（取寄）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 Or_SalesMoney
        {
            get { return _or_SalesMoney; }
            set { _or_SalesMoney = value; }
        }

        /// public propaty name  :  Or_SalesRetGoodsPrice
        /// <summary>返品額（取寄）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   返品額（取寄）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 Or_SalesRetGoodsPrice
        {
            get { return _or_SalesRetGoodsPrice; }
            set { _or_SalesRetGoodsPrice = value; }
        }

        /// public propaty name  :  Or_DiscountPrice
        /// <summary>値引金額（取寄）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   値引金額（取寄）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 Or_DiscountPrice
        {
            get { return _or_DiscountPrice; }
            set { _or_DiscountPrice = value; }
        }

        /// public propaty name  :  Or_GrossProfit
        /// <summary>粗利金額（取寄）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   粗利金額（取寄）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 Or_GrossProfit
        {
            get { return _or_GrossProfit; }
            set { _or_GrossProfit = value; }
        }


        /// <summary>
        /// 出荷商品優良対応表抽出結果クラスワークコンストラクタ
        /// </summary>
        /// <returns>ShipGdsPrimeListResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ShipGdsPrimeListResultWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ShipGdsPrimeListResultWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>ShipGdsPrimeListResultWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   ShipGdsPrimeListResultWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class ShipGdsPrimeListResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   ShipGdsPrimeListResultWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  ShipGdsPrimeListResultWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is ShipGdsPrimeListResultWork || graph is ArrayList || graph is ShipGdsPrimeListResultWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(ShipGdsPrimeListResultWork).FullName));

            if (graph != null && graph is ShipGdsPrimeListResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.ShipGdsPrimeListResultWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is ShipGdsPrimeListResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((ShipGdsPrimeListResultWork[])graph).Length;
            }
            else if (graph is ShipGdsPrimeListResultWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //企業コード
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //計上拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //AddUpSecCode
            //拠点ガイド略称
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideSnm
            //商品メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //商品番号
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //------ ADD START 2014/12/30 尹晶晶 FOR Redmine#44209改良 ------>>>>>
            //対応商品番号
            serInfo.MemberInfo.Add(typeof(string)); //OldGoodsNo
            //------ ADD END 2014/12/30 尹晶晶 FOR Redmine#44209改良 ------<<<<<
            //BLグループコード
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGroupCode
            //売上回数（在庫）
            serInfo.MemberInfo.Add(typeof(Int32)); //St_SalesTimes
            //売上数計（在庫）
            serInfo.MemberInfo.Add(typeof(Double)); //St_TotalSalesCount
            //売上金額（在庫）
            serInfo.MemberInfo.Add(typeof(Int64)); //St_SalesMoney
            //返品額（在庫）
            serInfo.MemberInfo.Add(typeof(Int64)); //St_SalesRetGoodsPrice
            //値引金額（在庫）
            serInfo.MemberInfo.Add(typeof(Int64)); //St_DiscountPrice
            //粗利金額（在庫）
            serInfo.MemberInfo.Add(typeof(Int64)); //St_GrossProfit
            //売上回数（取寄）
            serInfo.MemberInfo.Add(typeof(Int32)); //Or_SalesTimes
            //売上数計（取寄）
            serInfo.MemberInfo.Add(typeof(Double)); //Or_TotalSalesCount
            //売上金額（取寄）
            serInfo.MemberInfo.Add(typeof(Int64)); //Or_SalesMoney
            //返品額（取寄）
            serInfo.MemberInfo.Add(typeof(Int64)); //Or_SalesRetGoodsPrice
            //値引金額（取寄）
            serInfo.MemberInfo.Add(typeof(Int64)); //Or_DiscountPrice
            //粗利金額（取寄）
            serInfo.MemberInfo.Add(typeof(Int64)); //Or_GrossProfit


            serInfo.Serialize(writer, serInfo);
            if (graph is ShipGdsPrimeListResultWork)
            {
                ShipGdsPrimeListResultWork temp = (ShipGdsPrimeListResultWork)graph;

                SetShipGdsPrimeListResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is ShipGdsPrimeListResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((ShipGdsPrimeListResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (ShipGdsPrimeListResultWork temp in lst)
                {
                    SetShipGdsPrimeListResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// ShipGdsPrimeListResultWorkメンバ数(publicプロパティ数)
        /// </summary>
        //private const int currentMemberCount = 18; // DEL 2014/12/30 尹晶晶 FOR Redmine#44209改良
        private const int currentMemberCount = 19; // ADD 2014/12/30 尹晶晶 FOR Redmine#44209改良

        /// <summary>
        ///  ShipGdsPrimeListResultWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   ShipGdsPrimeListResultWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetShipGdsPrimeListResultWork(System.IO.BinaryWriter writer, ShipGdsPrimeListResultWork temp)
        {
            //企業コード
            writer.Write(temp.EnterpriseCode);
            //計上拠点コード
            writer.Write(temp.AddUpSecCode);
            //拠点ガイド略称
            writer.Write(temp.SectionGuideSnm);
            //商品メーカーコード
            writer.Write(temp.GoodsMakerCd);
            //商品番号
            writer.Write(temp.GoodsNo);
            //------ ADD START 2014/12/30 尹晶晶 FOR Redmine#44209改良 ------>>>>>
            //対応商品番号
            writer.Write(temp.OldGoodsNo);
            //------ ADD END 2014/12/30 尹晶晶 FOR Redmine#44209改良 ------<<<<<
            //BLグループコード
            writer.Write(temp.BLGroupCode);
            //売上回数（在庫）
            writer.Write(temp.St_SalesTimes);
            //売上数計（在庫）
            writer.Write(temp.St_TotalSalesCount);
            //売上金額（在庫）
            writer.Write(temp.St_SalesMoney);
            //返品額（在庫）
            writer.Write(temp.St_SalesRetGoodsPrice);
            //値引金額（在庫）
            writer.Write(temp.St_DiscountPrice);
            //粗利金額（在庫）
            writer.Write(temp.St_GrossProfit);
            //売上回数（取寄）
            writer.Write(temp.Or_SalesTimes);
            //売上数計（取寄）
            writer.Write(temp.Or_TotalSalesCount);
            //売上金額（取寄）
            writer.Write(temp.Or_SalesMoney);
            //返品額（取寄）
            writer.Write(temp.Or_SalesRetGoodsPrice);
            //値引金額（取寄）
            writer.Write(temp.Or_DiscountPrice);
            //粗利金額（取寄）
            writer.Write(temp.Or_GrossProfit);

        }

        /// <summary>
        ///  ShipGdsPrimeListResultWorkインスタンス取得
        /// </summary>
        /// <returns>ShipGdsPrimeListResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ShipGdsPrimeListResultWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private ShipGdsPrimeListResultWork GetShipGdsPrimeListResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            ShipGdsPrimeListResultWork temp = new ShipGdsPrimeListResultWork();

            //企業コード
            temp.EnterpriseCode = reader.ReadString();
            //計上拠点コード
            temp.AddUpSecCode = reader.ReadString();
            //拠点ガイド略称
            temp.SectionGuideSnm = reader.ReadString();
            //商品メーカーコード
            temp.GoodsMakerCd = reader.ReadInt32();
            //商品番号
            temp.GoodsNo = reader.ReadString();
            //------ ADD START 2014/12/30 尹晶晶 FOR Redmine#44209改良 ------>>>>>
            //対応商品番号
            temp.OldGoodsNo = reader.ReadString();
            //------ ADD END 2014/12/30 尹晶晶 FOR Redmine#44209改良 ------<<<<<
            //BLグループコード
            temp.BLGroupCode = reader.ReadInt32();
            //売上回数（在庫）
            temp.St_SalesTimes = reader.ReadInt32();
            //売上数計（在庫）
            temp.St_TotalSalesCount = reader.ReadDouble();
            //売上金額（在庫）
            temp.St_SalesMoney = reader.ReadInt64();
            //返品額（在庫）
            temp.St_SalesRetGoodsPrice = reader.ReadInt64();
            //値引金額（在庫）
            temp.St_DiscountPrice = reader.ReadInt64();
            //粗利金額（在庫）
            temp.St_GrossProfit = reader.ReadInt64();
            //売上回数（取寄）
            temp.Or_SalesTimes = reader.ReadInt32();
            //売上数計（取寄）
            temp.Or_TotalSalesCount = reader.ReadDouble();
            //売上金額（取寄）
            temp.Or_SalesMoney = reader.ReadInt64();
            //返品額（取寄）
            temp.Or_SalesRetGoodsPrice = reader.ReadInt64();
            //値引金額（取寄）
            temp.Or_DiscountPrice = reader.ReadInt64();
            //粗利金額（取寄）
            temp.Or_GrossProfit = reader.ReadInt64();


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
        /// <returns>ShipGdsPrimeListResultWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ShipGdsPrimeListResultWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                ShipGdsPrimeListResultWork temp = GetShipGdsPrimeListResultWork(reader, serInfo);
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
                    retValue = (ShipGdsPrimeListResultWork[])lst.ToArray(typeof(ShipGdsPrimeListResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}

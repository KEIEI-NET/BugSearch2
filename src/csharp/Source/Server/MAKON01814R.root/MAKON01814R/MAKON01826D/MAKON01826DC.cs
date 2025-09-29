using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    # region Delete 2007/09/10
    /*
    /// public class name:   StockExplaDataWork
    /// <summary>
    ///                      仕入詳細データワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   仕入詳細データワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2007/08/07  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class StockExplaDataWork : IFileHeader
    {
        /// <summary>作成日時</summary>
        /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        private DateTime _createDateTime;

        /// <summary>更新日時</summary>
        /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        private DateTime _updateDateTime;

        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>GUID</summary>
        /// <remarks>共通ファイルヘッダ</remarks>
        private Guid _fileHeaderGuid;

        /// <summary>更新従業員コード</summary>
        /// <remarks>共通ファイルヘッダ</remarks>
        private string _updEmployeeCode = "";

        /// <summary>更新アセンブリID1</summary>
        /// <remarks>共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）</remarks>
        private string _updAssemblyId1 = "";

        /// <summary>更新アセンブリID2</summary>
        /// <remarks>共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）</remarks>
        private string _updAssemblyId2 = "";

        /// <summary>論理削除区分</summary>
        /// <remarks>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>仕入形式</summary>
        /// <remarks>0:買取(仕入),1:受託</remarks>
        private Int32 _supplierFormal;

        /// <summary>仕入伝票番号</summary>
        /// <remarks>システムが自動採番</remarks>
        private Int32 _supplierSlipNo;

        /// <summary>仕入行番号</summary>
        private Int32 _stockRowNo;

        /// <summary>仕入詳細番号</summary>
        private Int32 _stckSlipExpNum;

        /// <summary>製造番号1</summary>
        private string _productNumber1 = "";

        /// <summary>製造番号2</summary>
        private string _productNumber2 = "";

        /// <summary>商品電話番号1</summary>
        private string _stockTelNo1 = "";

        /// <summary>商品電話番号2</summary>
        private string _stockTelNo2 = "";

        /// <summary>仕入伝票詳細備考</summary>
        private string _stockExpSlipNote = "";

        /// <summary>製番在庫マスタGUID</summary>
        private Guid _productStockGuid;

        /// <summary>在庫更新識別区分</summary>
        /// <remarks>0:仕入詳細データ更新,1:製番在庫マスタ更新</remarks>
        private Int32 _stockUpdDiscDiv;

        /// <summary>製番在庫更新日時</summary>
        /// <remarks>製番在庫共通クラス（ProductStockCommon）</remarks>
        private DateTime _productUpdateDateTime;


        /// public propaty name  :  CreateDateTime
        /// <summary>作成日時プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime CreateDateTime
        {
            get { return _createDateTime; }
            set { _createDateTime = value; }
        }

        /// public propaty name  :  UpdateDateTime
        /// <summary>更新日時プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime UpdateDateTime
        {
            get { return _updateDateTime; }
            set { _updateDateTime = value; }
        }

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

        /// public propaty name  :  FileHeaderGuid
        /// <summary>GUIDプロパティ</summary>
        /// <value>共通ファイルヘッダ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   GUIDプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Guid FileHeaderGuid
        {
            get { return _fileHeaderGuid; }
            set { _fileHeaderGuid = value; }
        }

        /// public propaty name  :  UpdEmployeeCode
        /// <summary>更新従業員コードプロパティ</summary>
        /// <value>共通ファイルヘッダ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdEmployeeCode
        {
            get { return _updEmployeeCode; }
            set { _updEmployeeCode = value; }
        }

        /// public propaty name  :  UpdAssemblyId1
        /// <summary>更新アセンブリID1プロパティ</summary>
        /// <value>共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新アセンブリID1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdAssemblyId1
        {
            get { return _updAssemblyId1; }
            set { _updAssemblyId1 = value; }
        }

        /// public propaty name  :  UpdAssemblyId2
        /// <summary>更新アセンブリID2プロパティ</summary>
        /// <value>共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新アセンブリID2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdAssemblyId2
        {
            get { return _updAssemblyId2; }
            set { _updAssemblyId2 = value; }
        }

        /// public propaty name  :  LogicalDeleteCode
        /// <summary>論理削除区分プロパティ</summary>
        /// <value>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   論理削除区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 LogicalDeleteCode
        {
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
        }

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

        /// public propaty name  :  SupplierFormal
        /// <summary>仕入形式プロパティ</summary>
        /// <value>0:買取(仕入),1:受託</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入形式プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierFormal
        {
            get { return _supplierFormal; }
            set { _supplierFormal = value; }
        }

        /// public propaty name  :  SupplierSlipNo
        /// <summary>仕入伝票番号プロパティ</summary>
        /// <value>システムが自動採番</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierSlipNo
        {
            get { return _supplierSlipNo; }
            set { _supplierSlipNo = value; }
        }

        /// public propaty name  :  StockRowNo
        /// <summary>仕入行番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入行番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockRowNo
        {
            get { return _stockRowNo; }
            set { _stockRowNo = value; }
        }

        /// public propaty name  :  StckSlipExpNum
        /// <summary>仕入詳細番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入詳細番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StckSlipExpNum
        {
            get { return _stckSlipExpNum; }
            set { _stckSlipExpNum = value; }
        }

        /// public propaty name  :  ProductNumber1
        /// <summary>製造番号1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   製造番号1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ProductNumber1
        {
            get { return _productNumber1; }
            set { _productNumber1 = value; }
        }

        /// public propaty name  :  ProductNumber2
        /// <summary>製造番号2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   製造番号2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ProductNumber2
        {
            get { return _productNumber2; }
            set { _productNumber2 = value; }
        }

        /// public propaty name  :  StockTelNo1
        /// <summary>商品電話番号1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品電話番号1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockTelNo1
        {
            get { return _stockTelNo1; }
            set { _stockTelNo1 = value; }
        }

        /// public propaty name  :  StockTelNo2
        /// <summary>商品電話番号2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品電話番号2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockTelNo2
        {
            get { return _stockTelNo2; }
            set { _stockTelNo2 = value; }
        }

        /// public propaty name  :  StockExpSlipNote
        /// <summary>仕入伝票詳細備考プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入伝票詳細備考プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string StockExpSlipNote
        {
            get { return _stockExpSlipNote; }
            set { _stockExpSlipNote = value; }
        }

        /// public propaty name  :  ProductStockGuid
        /// <summary>製番在庫マスタGUIDプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   製番在庫マスタGUIDプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Guid ProductStockGuid
        {
            get { return _productStockGuid; }
            set { _productStockGuid = value; }
        }

        /// public propaty name  :  StockUpdDiscDiv
        /// <summary>在庫更新識別区分プロパティ</summary>
        /// <value>0:仕入詳細データ更新,1:製番在庫マスタ更新</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫更新識別区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockUpdDiscDiv
        {
            get { return _stockUpdDiscDiv; }
            set { _stockUpdDiscDiv = value; }
        }

        /// public propaty name  :  ProductUpdateDateTime
        /// <summary>製番在庫更新日時プロパティ</summary>
        /// <value>製番在庫共通クラス（ProductStockCommon）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   製番在庫更新日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime ProductUpdateDateTime
        {
            get { return _productUpdateDateTime; }
            set { _productUpdateDateTime = value; }
        }


        /// <summary>
        /// 仕入詳細データワークコンストラクタ
        /// </summary>
        /// <returns>StockExplaDataWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockExplaDataWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public StockExplaDataWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>StockExplaDataWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   StockExplaDataWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class StockExplaDataWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockExplaDataWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  StockExplaDataWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is StockExplaDataWork || graph is ArrayList || graph is StockExplaDataWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(StockExplaDataWork).FullName));

            if (graph != null && graph is StockExplaDataWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.StockExplaDataWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is StockExplaDataWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((StockExplaDataWork[])graph).Length;
            }
            else if (graph is StockExplaDataWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //作成日時
            serInfo.MemberInfo.Add(typeof(Int64)); //CreateDateTime
            //更新日時
            serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTime
            //企業コード
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //GUID
            serInfo.MemberInfo.Add(typeof(byte[]));  //FileHeaderGuid
            //更新従業員コード
            serInfo.MemberInfo.Add(typeof(string)); //UpdEmployeeCode
            //更新アセンブリID1
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId1
            //更新アセンブリID2
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId2
            //論理削除区分
            serInfo.MemberInfo.Add(typeof(Int32)); //LogicalDeleteCode
            //拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //仕入形式
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierFormal
            //仕入伝票番号
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierSlipNo
            //仕入行番号
            serInfo.MemberInfo.Add(typeof(Int32)); //StockRowNo
            //仕入詳細番号
            serInfo.MemberInfo.Add(typeof(Int32)); //StckSlipExpNum
            //製造番号1
            serInfo.MemberInfo.Add(typeof(string)); //ProductNumber1
            //製造番号2
            serInfo.MemberInfo.Add(typeof(string)); //ProductNumber2
            //商品電話番号1
            serInfo.MemberInfo.Add(typeof(string)); //StockTelNo1
            //商品電話番号2
            serInfo.MemberInfo.Add(typeof(string)); //StockTelNo2
            //仕入伝票詳細備考
            serInfo.MemberInfo.Add(typeof(string)); //StockExpSlipNote
            //製番在庫マスタGUID
            serInfo.MemberInfo.Add(typeof(byte[]));  //ProductStockGuid
            //在庫更新識別区分
            serInfo.MemberInfo.Add(typeof(Int32)); //StockUpdDiscDiv
            //製番在庫更新日時
            serInfo.MemberInfo.Add(typeof(Int64)); //ProductUpdateDateTime


            serInfo.Serialize(writer, serInfo);
            if (graph is StockExplaDataWork)
            {
                StockExplaDataWork temp = (StockExplaDataWork)graph;

                SetStockExplaDataWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is StockExplaDataWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((StockExplaDataWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (StockExplaDataWork temp in lst)
                {
                    SetStockExplaDataWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// StockExplaDataWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 21;

        /// <summary>
        ///  StockExplaDataWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockExplaDataWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetStockExplaDataWork(System.IO.BinaryWriter writer, StockExplaDataWork temp)
        {
            //作成日時
            writer.Write((Int64)temp.CreateDateTime.Ticks);
            //更新日時
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
            //企業コード
            writer.Write(temp.EnterpriseCode);
            //GUID
            byte[] fileHeaderGuidArray = temp.FileHeaderGuid.ToByteArray();
            writer.Write(fileHeaderGuidArray.Length);
            writer.Write(temp.FileHeaderGuid.ToByteArray());
            //更新従業員コード
            writer.Write(temp.UpdEmployeeCode);
            //更新アセンブリID1
            writer.Write(temp.UpdAssemblyId1);
            //更新アセンブリID2
            writer.Write(temp.UpdAssemblyId2);
            //論理削除区分
            writer.Write(temp.LogicalDeleteCode);
            //拠点コード
            writer.Write(temp.SectionCode);
            //仕入形式
            writer.Write(temp.SupplierFormal);
            //仕入伝票番号
            writer.Write(temp.SupplierSlipNo);
            //仕入行番号
            writer.Write(temp.StockRowNo);
            //仕入詳細番号
            writer.Write(temp.StckSlipExpNum);
            //製造番号1
            writer.Write(temp.ProductNumber1);
            //製造番号2
            writer.Write(temp.ProductNumber2);
            //商品電話番号1
            writer.Write(temp.StockTelNo1);
            //商品電話番号2
            writer.Write(temp.StockTelNo2);
            //仕入伝票詳細備考
            writer.Write(temp.StockExpSlipNote);
            //製番在庫マスタGUID
            byte[] productStockGuidArray = temp.ProductStockGuid.ToByteArray();
            writer.Write(productStockGuidArray.Length);
            writer.Write(temp.ProductStockGuid.ToByteArray());
            //在庫更新識別区分
            writer.Write(temp.StockUpdDiscDiv);
            //製番在庫更新日時
            writer.Write((Int64)temp.ProductUpdateDateTime.Ticks);

        }

        /// <summary>
        ///  StockExplaDataWorkインスタンス取得
        /// </summary>
        /// <returns>StockExplaDataWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockExplaDataWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private StockExplaDataWork GetStockExplaDataWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            StockExplaDataWork temp = new StockExplaDataWork();

            //作成日時
            temp.CreateDateTime = new DateTime(reader.ReadInt64());
            //更新日時
            temp.UpdateDateTime = new DateTime(reader.ReadInt64());
            //企業コード
            temp.EnterpriseCode = reader.ReadString();
            //GUID
            int lenOfFileHeaderGuidArray = reader.ReadInt32();
            byte[] fileHeaderGuidArray = reader.ReadBytes(lenOfFileHeaderGuidArray);
            temp.FileHeaderGuid = new Guid(fileHeaderGuidArray);
            //更新従業員コード
            temp.UpdEmployeeCode = reader.ReadString();
            //更新アセンブリID1
            temp.UpdAssemblyId1 = reader.ReadString();
            //更新アセンブリID2
            temp.UpdAssemblyId2 = reader.ReadString();
            //論理削除区分
            temp.LogicalDeleteCode = reader.ReadInt32();
            //拠点コード
            temp.SectionCode = reader.ReadString();
            //仕入形式
            temp.SupplierFormal = reader.ReadInt32();
            //仕入伝票番号
            temp.SupplierSlipNo = reader.ReadInt32();
            //仕入行番号
            temp.StockRowNo = reader.ReadInt32();
            //仕入詳細番号
            temp.StckSlipExpNum = reader.ReadInt32();
            //製造番号1
            temp.ProductNumber1 = reader.ReadString();
            //製造番号2
            temp.ProductNumber2 = reader.ReadString();
            //商品電話番号1
            temp.StockTelNo1 = reader.ReadString();
            //商品電話番号2
            temp.StockTelNo2 = reader.ReadString();
            //仕入伝票詳細備考
            temp.StockExpSlipNote = reader.ReadString();
            //製番在庫マスタGUID
            int lenOfProductStockGuidArray = reader.ReadInt32();
            byte[] productStockGuidArray = reader.ReadBytes(lenOfProductStockGuidArray);
            temp.ProductStockGuid = new Guid(productStockGuidArray);
            //在庫更新識別区分
            temp.StockUpdDiscDiv = reader.ReadInt32();
            //製番在庫更新日時
            temp.ProductUpdateDateTime = new DateTime(reader.ReadInt64());


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
        /// <returns>StockExplaDataWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockExplaDataWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                StockExplaDataWork temp = GetStockExplaDataWork(reader, serInfo);
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
                    retValue = (StockExplaDataWork[])lst.ToArray(typeof(StockExplaDataWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
    */
    #endregion
}
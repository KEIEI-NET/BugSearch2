using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   GoodsMngWork
    /// <summary>
    ///                      商品管理情報ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   商品管理情報ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2012/06/04</br>
    /// <br>Update Note      :   2012/07/03</br>
    /// <br>管理番号         :   10801804-00、大陽案件、お客様の指摘の対応</br>
    /// <br>Update Note      :   2012/09/24 李亜博</br>
    /// <br>管理番号         :   10801804-00</br>
    /// <br>                     2012/10/17配信分、Redmine#32367 商品管理情報マスタに入力パターンを追加したと伴い、不具合現象の対応。</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class ImportGoodsMngWork : IFileHeader
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

        /// <summary>商品中分類コード</summary>
        /// <remarks>※中分類</remarks>
        //private Int32 _goodsMGroup;// DEL 2012/09/24 李亜博 for Redmine#32367 
        private string _goodsMGroup;// ADD 2012/09/24 李亜博 for Redmine#32367 

        /// <summary>商品メーカーコード</summary>
        private string _goodsMakerCd;

        /// <summary>BL商品コード</summary>
        //private Int32 _bLGoodsCode;// DEL 2012/09/24 李亜博 for Redmine#32367 
        private string _bLGoodsCode;// ADD 2012/09/24 李亜博 for Redmine#32367 

        /// <summary>商品番号</summary>
        private string _goodsNo = "";

        /// <summary>仕入先コード</summary>
        private string _supplierCd;

        /// <summary>発注ロット</summary>
        private string _supplierLot;

        /// <summary>商品中分類名称</summary>
        private string _goodsMGroupName = "";

        /// <summary>メーカー名称</summary>
        private string _makerName = "";

        /// <summary>商品名称</summary>
        private string _goodsName = "";

        /// <summary>BL商品コード名称（全角）</summary>
        private string _bLGoodsFullName = "";

        /// <summary>仕入先略称</summary>
        private string _supplierSnm = "";

        // ---ADD 2012/07/03 張曼 ----- >>>>>
        /// <summary>エラーメッセージ</summary>
        private string _erroLogMessage = "";
        // ---ADD 2012/07/03 張曼 ----- <<<<<

        /// <summary>拠点ガイド名称</summary>
        /// <remarks>ＵＩ用（既存のコンボボックス等）</remarks>
        private string _sectionGuideNm = "";

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

        /// public propaty name  :  GoodsMGroup
        /// <summary>商品中分類コードプロパティ</summary>
        /// <value>※中分類</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品中分類コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        //public Int32 GoodsMGroup// DEL 2012/09/24 李亜博 for Redmine#32367 
        public string GoodsMGroup// ADD 2012/09/24 李亜博 for Redmine#32367 
        {
            get { return _goodsMGroup; }
            set { _goodsMGroup = value; }
        }

        /// public propaty name  :  GoodsMakerCd
        /// <summary>商品メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsMakerCd
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
        //public Int32 BLGoodsCode// DEL 2012/09/24 李亜博 for Redmine#32367 
        public string BLGoodsCode// ADD 2012/09/24 李亜博 for Redmine#32367
        {
            get { return _bLGoodsCode; }
            set { _bLGoodsCode = value; }
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

        /// public propaty name  :  SupplierCd
        /// <summary>仕入先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierCd
        {
            get { return _supplierCd; }
            set { _supplierCd = value; }
        }

        /// public propaty name  :  SupplierLot
        /// <summary>発注ロットプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発注ロットプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SupplierLot
        {
            get { return _supplierLot; }
            set { _supplierLot = value; }
        }

        /// public propaty name  :  GoodsMGroupName
        /// <summary>商品中分類名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品中分類名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsMGroupName
        {
            get { return _goodsMGroupName; }
            set { _goodsMGroupName = value; }
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

        // ---ADD 2012/07/03 張曼 ----- >>>>>
        /// public propaty name  :  ErroLogMessage
        /// <summary>エラーメッセージプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   エラーメッセージプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ErroLogMessage
        {
            get { return _erroLogMessage; }
            set { _erroLogMessage = value; }
        }
        // ---ADD 2012/07/03 張曼 ----- <<<<<

        /// public propaty name  :  SectionGuideNm
        /// <summary>拠点ガイド名称プロパティ</summary>
        /// <value>ＵＩ用（既存のコンボボックス等）</value>
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


        /// <summary>
        /// 商品管理情報ワークコンストラクタ
        /// </summary>
        /// <returns>GoodsMngWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsMngWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ImportGoodsMngWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>GoodsMngWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   GoodsMngWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class ImportGoodsMngWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsMngWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  GoodsMngWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is ImportGoodsMngWork || graph is ArrayList || graph is ImportGoodsMngWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(ImportGoodsMngWork).FullName));

            if (graph != null && graph is ImportGoodsMngWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.GoodsMngWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is ImportGoodsMngWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((ImportGoodsMngWork[])graph).Length;
            }
            else if (graph is ImportGoodsMngWork)
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
            //商品中分類コード
            //serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMGroup// DEL 2012/09/24 李亜博 for Redmine#32367 
            serInfo.MemberInfo.Add(typeof(string));  //GoodsMGroup// ADD 2012/09/24 李亜博 for Redmine#32367 
            //商品メーカーコード
            serInfo.MemberInfo.Add(typeof(string)); //GoodsMakerCd
            //BL商品コード
            //serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode// DEL 2012/09/24 李亜博 for Redmine#32367 
            serInfo.MemberInfo.Add(typeof(string));  //BLGoodsCode // ADD 2012/09/24 李亜博 for Redmine#32367
            //商品番号
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //仕入先コード
            serInfo.MemberInfo.Add(typeof(string)); //SupplierCd
            //発注ロット
            serInfo.MemberInfo.Add(typeof(string)); //SupplierLot
            //商品中分類名称
            serInfo.MemberInfo.Add(typeof(string)); //GoodsMGroupName
            //メーカー名称
            serInfo.MemberInfo.Add(typeof(string)); //MakerName
            //商品名称
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            //BL商品コード名称（全角）
            serInfo.MemberInfo.Add(typeof(string)); //BLGoodsFullName
            //仕入先略称
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSnm
            // ---ADD 2012/07/03 張曼 ----- >>>>>
            //エラーメッセージ
            serInfo.MemberInfo.Add(typeof(string)); //ErroLogMessage
            // ---ADD 2012/07/03 張曼 ----- <<<<<
            //拠点ガイド名称
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideNm


            serInfo.Serialize(writer, serInfo);
            if (graph is ImportGoodsMngWork)
            {
                ImportGoodsMngWork temp = (ImportGoodsMngWork)graph;

                SetGoodsMngWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is ImportGoodsMngWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((ImportGoodsMngWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (ImportGoodsMngWork temp in lst)
                {
                    SetGoodsMngWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// GoodsMngWorkメンバ数(publicプロパティ数)
        /// </summary>
        // ---ADD 2012/07/03 張曼 ----- >>>>>
        //private const int currentMemberCount = 21;
        private const int currentMemberCount = 22;
        // ---ADD 2012/07/03 張曼 ----- <<<<<
        /// <summary>
        ///  GoodsMngWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsMngWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetGoodsMngWork(System.IO.BinaryWriter writer, ImportGoodsMngWork temp)
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
            //商品中分類コード
            writer.Write(temp.GoodsMGroup);
            //商品メーカーコード
            writer.Write(temp.GoodsMakerCd);
            //BL商品コード
            writer.Write(temp.BLGoodsCode);
            //商品番号
            writer.Write(temp.GoodsNo);
            //仕入先コード
            writer.Write(temp.SupplierCd);
            //発注ロット
            writer.Write(temp.SupplierLot);
            //商品中分類名称
            writer.Write(temp.GoodsMGroupName);
            //メーカー名称
            writer.Write(temp.MakerName);
            //商品名称
            writer.Write(temp.GoodsName);
            //BL商品コード名称（全角）
            writer.Write(temp.BLGoodsFullName);
            //仕入先略称
            writer.Write(temp.SupplierSnm);
            // ---ADD 2012/07/03 張曼 ----- >>>>>
            //エラーメッセージ
            writer.Write(temp.ErroLogMessage);
            // ---ADD 2012/07/03 張曼 ----- <<<<<
            //拠点ガイド名称
            writer.Write(temp.SectionGuideNm);

        }

        /// <summary>
        ///  GoodsMngWorkインスタンス取得
        /// </summary>
        /// <returns>GoodsMngWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsMngWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private ImportGoodsMngWork GetGoodsMngWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            ImportGoodsMngWork temp = new ImportGoodsMngWork();

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
            //商品中分類コード
            //temp.GoodsMGroup = reader.ReadInt32();// DEL 2012/09/24 李亜博 for Redmine#32367 
            temp.GoodsMGroup = reader.ReadString();// ADD 2012/09/24 李亜博 for Redmine#32367 
            //商品メーカーコード
            temp.GoodsMakerCd = reader.ReadString();
            //BL商品コード
            //temp.BLGoodsCode = reader.ReadInt32();// DEL 2012/09/24 李亜博 for Redmine#32367 
            temp.BLGoodsCode = reader.ReadString();// ADD 2012/09/24 李亜博 for Redmine#32367 
            //商品番号
            temp.GoodsNo = reader.ReadString();
            //仕入先コード
            temp.SupplierCd = reader.ReadString();
            //発注ロット
            temp.SupplierLot = reader.ReadString();
            //商品中分類名称
            temp.GoodsMGroupName = reader.ReadString();
            //メーカー名称
            temp.MakerName = reader.ReadString();
            //商品名称
            temp.GoodsName = reader.ReadString();
            //BL商品コード名称（全角）
            temp.BLGoodsFullName = reader.ReadString();
            //仕入先略称
            temp.SupplierSnm = reader.ReadString();
            // ---ADD 2012/07/03 張曼 ----- >>>>>
            //エラーメッセージ
            temp.ErroLogMessage = reader.ReadString();
            // ---ADD 2012/07/03 張曼 ----- <<<<<
            //拠点ガイド名称
            temp.SectionGuideNm = reader.ReadString();


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
        /// <returns>GoodsMngWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsMngWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                ImportGoodsMngWork temp = GetGoodsMngWork(reader, serInfo);
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
                    retValue = (ImportGoodsMngWork[])lst.ToArray(typeof(ImportGoodsMngWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }


}

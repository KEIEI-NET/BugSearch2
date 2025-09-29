using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   HandyMakerGoodsPtrnHisResultWork
    /// <summary>
    ///                      メーカー品番パターン検索履歴データワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   メーカー品番パターン検索履歴データワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2020/03/24  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class HandyMakerGoodsPtrnHisResultWork : IFileHeader
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

        /// <summary>パターン検索履歴通番</summary>
        /// <remarks>ユニーク通番</remarks>
        private Int32 _makerGoodsSerchHisNo;

        /// <summary>実行日付</summary>
        /// <remarks>在庫検索を実行した日付</remarks>
        private Int32 _searchDate;

        /// <summary>商品メーカーコード</summary>
        private Int32 _goodsMakerCd;

        /// <summary>バーコードデータ</summary>
        /// <remarks>スキャンされたバーコードデータ（スキャンしていない場合はNull)</remarks>
        private string _barCodeData = "";

        /// <summary>メーカー品番パターンNo.</summary>
        /// <remarks>合致したメーカー品番パターン№（合致無しの場合は0）</remarks>
        private Int32 _makerGoodsPtrnNo;

        /// <summary>検索商品番号</summary>
        /// <remarks>パターン編集又は手入力された商品番号</remarks>
        private string _searchGoodsNo = "";

        /// <summary>登録商品番号</summary>
        /// <remarks>登録処理で使用された商品番号</remarks>
        private string _entryGoodsNo = "";

        /// <summary>使用回数</summary>
        /// <remarks>メーカー、バーコード、検索品番、登録品番毎の使用回数</remarks>
        private Int32 _useCount;

        /// <summary>登録ステータス</summary>
        /// <remarks>0:未登録、1:登録</remarks>
        private Int32 _entryStatus;

        /// <summary>UOE発注データ区分</summary>
        /// <remarks>0:該当なし、1：該当あり</remarks>
        private Int32 _uOEOrderTdlKind;

        /// <summary>メーカー名称</summary>
        private string _makerName = "";


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

        /// public propaty name  :  MakerGoodsSerchHisNo
        /// <summary>パターン検索履歴通番プロパティ</summary>
        /// <value>ユニーク通番</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   パターン検索履歴通番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MakerGoodsSerchHisNo
        {
            get { return _makerGoodsSerchHisNo; }
            set { _makerGoodsSerchHisNo = value; }
        }

        /// public propaty name  :  SearchDate
        /// <summary>実行日付プロパティ</summary>
        /// <value>在庫検索を実行した日付</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   実行日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SearchDate
        {
            get { return _searchDate; }
            set { _searchDate = value; }
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

        /// public propaty name  :  BarCodeData
        /// <summary>バーコードデータプロパティ</summary>
        /// <value>スキャンされたバーコードデータ（スキャンしていない場合はNull)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   バーコードデータプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BarCodeData
        {
            get { return _barCodeData; }
            set { _barCodeData = value; }
        }

        /// public propaty name  :  MakerGoodsPtrnNo
        /// <summary>メーカー品番パターンNo.プロパティ</summary>
        /// <value>合致したメーカー品番パターン№（合致無しの場合は0）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカー品番パターンNo.プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MakerGoodsPtrnNo
        {
            get { return _makerGoodsPtrnNo; }
            set { _makerGoodsPtrnNo = value; }
        }

        /// public propaty name  :  SearchGoodsNo
        /// <summary>検索商品番号プロパティ</summary>
        /// <value>パターン編集又は手入力された商品番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   検索商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SearchGoodsNo
        {
            get { return _searchGoodsNo; }
            set { _searchGoodsNo = value; }
        }

        /// public propaty name  :  EntryGoodsNo
        /// <summary>登録商品番号プロパティ</summary>
        /// <value>登録処理で使用された商品番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   登録商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EntryGoodsNo
        {
            get { return _entryGoodsNo; }
            set { _entryGoodsNo = value; }
        }

        /// public propaty name  :  UseCount
        /// <summary>使用回数プロパティ</summary>
        /// <value>メーカー、バーコード、検索品番、登録品番毎の使用回数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   使用回数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UseCount
        {
            get { return _useCount; }
            set { _useCount = value; }
        }

        /// public propaty name  :  EntryStatus
        /// <summary>登録ステータスプロパティ</summary>
        /// <value>0:未登録、1:登録</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   登録ステータスプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EntryStatus
        {
            get { return _entryStatus; }
            set { _entryStatus = value; }
        }

        /// public propaty name  :  UOEOrderTdlKind
        /// <summary>UOE発注データ区分プロパティ</summary>
        /// <value>0:該当なし、1：該当あり</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE発注データ区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UOEOrderTdlKind
        {
            get { return _uOEOrderTdlKind; }
            set { _uOEOrderTdlKind = value; }
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


        /// <summary>
        /// メーカー品番パターン検索履歴データワークコンストラクタ
        /// </summary>
        /// <returns>HandyMakerGoodsPtrnHisResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   HandyMakerGoodsPtrnHisResultWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public HandyMakerGoodsPtrnHisResultWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>HandyMakerGoodsPtrnHisResultWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   HandyMakerGoodsPtrnHisResultWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class HandyMakerGoodsPtrnHisResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   HandyMakerGoodsPtrnHisResultWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  HandyMakerGoodsPtrnHisResultWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is HandyMakerGoodsPtrnHisResultWork || graph is ArrayList || graph is HandyMakerGoodsPtrnHisResultWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(HandyMakerGoodsPtrnHisResultWork).FullName));

            if (graph != null && graph is HandyMakerGoodsPtrnHisResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.HandyMakerGoodsPtrnHisResultWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is HandyMakerGoodsPtrnHisResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((HandyMakerGoodsPtrnHisResultWork[])graph).Length;
            }
            else if (graph is HandyMakerGoodsPtrnHisResultWork)
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
            //パターン検索履歴通番
            serInfo.MemberInfo.Add(typeof(Int32)); //MakerGoodsSerchHisNo
            //実行日付
            serInfo.MemberInfo.Add(typeof(Int32)); //SearchDate
            //商品メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //バーコードデータ
            serInfo.MemberInfo.Add(typeof(string)); //BarCodeData
            //メーカー品番パターンNo.
            serInfo.MemberInfo.Add(typeof(Int32)); //MakerGoodsPtrnNo
            //検索商品番号
            serInfo.MemberInfo.Add(typeof(string)); //SearchGoodsNo
            //登録商品番号
            serInfo.MemberInfo.Add(typeof(string)); //EntryGoodsNo
            //使用回数
            serInfo.MemberInfo.Add(typeof(Int32)); //UseCount
            //登録ステータス
            serInfo.MemberInfo.Add(typeof(Int32)); //EntryStatus
            //UOE発注データ区分
            serInfo.MemberInfo.Add(typeof(Int32)); //UOEOrderTdlKind
            //メーカー名称
            serInfo.MemberInfo.Add(typeof(string)); //MakerName


            serInfo.Serialize(writer, serInfo);
            if (graph is HandyMakerGoodsPtrnHisResultWork)
            {
                HandyMakerGoodsPtrnHisResultWork temp = (HandyMakerGoodsPtrnHisResultWork)graph;

                SetHandyMakerGoodsPtrnHisResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is HandyMakerGoodsPtrnHisResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((HandyMakerGoodsPtrnHisResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (HandyMakerGoodsPtrnHisResultWork temp in lst)
                {
                    SetHandyMakerGoodsPtrnHisResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// HandyMakerGoodsPtrnHisResultWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 19;

        /// <summary>
        ///  HandyMakerGoodsPtrnHisResultWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   HandyMakerGoodsPtrnHisResultWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetHandyMakerGoodsPtrnHisResultWork(System.IO.BinaryWriter writer, HandyMakerGoodsPtrnHisResultWork temp)
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
            //パターン検索履歴通番
            writer.Write(temp.MakerGoodsSerchHisNo);
            //実行日付
            writer.Write(temp.SearchDate);
            //商品メーカーコード
            writer.Write(temp.GoodsMakerCd);
            //バーコードデータ
            writer.Write(temp.BarCodeData);
            //メーカー品番パターンNo.
            writer.Write(temp.MakerGoodsPtrnNo);
            //検索商品番号
            writer.Write(temp.SearchGoodsNo);
            //登録商品番号
            writer.Write(temp.EntryGoodsNo);
            //使用回数
            writer.Write(temp.UseCount);
            //登録ステータス
            writer.Write(temp.EntryStatus);
            //UOE発注データ区分
            writer.Write(temp.UOEOrderTdlKind);
            //メーカー名称
            writer.Write(temp.MakerName);

        }

        /// <summary>
        ///  HandyMakerGoodsPtrnHisResultWorkインスタンス取得
        /// </summary>
        /// <returns>HandyMakerGoodsPtrnHisResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   HandyMakerGoodsPtrnHisResultWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private HandyMakerGoodsPtrnHisResultWork GetHandyMakerGoodsPtrnHisResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            HandyMakerGoodsPtrnHisResultWork temp = new HandyMakerGoodsPtrnHisResultWork();

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
            //パターン検索履歴通番
            temp.MakerGoodsSerchHisNo = reader.ReadInt32();
            //実行日付
            temp.SearchDate = reader.ReadInt32();
            //商品メーカーコード
            temp.GoodsMakerCd = reader.ReadInt32();
            //バーコードデータ
            temp.BarCodeData = reader.ReadString();
            //メーカー品番パターンNo.
            temp.MakerGoodsPtrnNo = reader.ReadInt32();
            //検索商品番号
            temp.SearchGoodsNo = reader.ReadString();
            //登録商品番号
            temp.EntryGoodsNo = reader.ReadString();
            //使用回数
            temp.UseCount = reader.ReadInt32();
            //登録ステータス
            temp.EntryStatus = reader.ReadInt32();
            //UOE発注データ区分
            temp.UOEOrderTdlKind = reader.ReadInt32();
            //メーカー名称
            temp.MakerName = reader.ReadString();


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
        /// <returns>HandyMakerGoodsPtrnHisResultWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   HandyMakerGoodsPtrnHisResultWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                HandyMakerGoodsPtrnHisResultWork temp = GetHandyMakerGoodsPtrnHisResultWork(reader, serInfo);
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
                    retValue = (HandyMakerGoodsPtrnHisResultWork[])lst.ToArray(typeof(HandyMakerGoodsPtrnHisResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }


}

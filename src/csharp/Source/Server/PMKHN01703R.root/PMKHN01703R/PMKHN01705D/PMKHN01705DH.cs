//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 明治産業商品セットマスタ変換処理
//----------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11003519-00 作成担当 : 陳永康
// 作 成 日  2015/01/26  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   GoodsSetChgWork
    /// <summary>
    ///                      商品セットワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   商品セットワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2015/01/26</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class GoodsSetChgWork : IFileHeader
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

        /// <summary>親メーカーコード</summary>
        private Int32 _parentGoodsMakerCd;

        /// <summary>親商品番号</summary>
        private string _parentGoodsNo = "";

        /// <summary>子商品メーカーコード</summary>
        private Int32 _subGoodsMakerCd;

        /// <summary>子商品番号</summary>
        private string _subGoodsNo = "";

        /// <summary>数量（浮動）</summary>
        private Double _cntFl;

        /// <summary>表示順位</summary>
        private Int32 _displayOrder;

        /// <summary>セット規格・特記事項</summary>
        private string _setSpecialNote = "";

        /// <summary>カタログ図番</summary>
        private string _catalogShapeNo = "";

        /// <summary>新品番</summary>
        private string _newPrmSetDtlName = "";

        /// <summary>旧品番</summary>
        private string _oldPrmSetDtlName = "";

        /// <summary>メーカーコード</summary>
        private Int32 _goodsMakerCd;

        /// <summary>変換後親メーカーコード</summary>
        private Int32 _afChgParentGoodsMakerCd;

        /// <summary>変換後親商品番号</summary>
        private string _afChgParentGoodsNo = "";

        /// <summary>変換後子商品メーカーコード</summary>
        private Int32 _afChgSubGoodsMakerCd;

        /// <summary>変換後子商品番号</summary>
        private string _afChgSubGoodsNo = "";

        /// <summary>備考</summary>
        private string _afContentExplain = "";


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

        /// public propaty name  :  ParentGoodsMakerCd
        /// <summary>親メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   親メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ParentGoodsMakerCd
        {
            get { return _parentGoodsMakerCd; }
            set { _parentGoodsMakerCd = value; }
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

        /// public propaty name  :  CntFl
        /// <summary>数量（浮動）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   数量（浮動）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double CntFl
        {
            get { return _cntFl; }
            set { _cntFl = value; }
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

        /// public propaty name  :  SetSpecialNote
        /// <summary>セット規格・特記事項プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   セット規格・特記事項プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SetSpecialNote
        {
            get { return _setSpecialNote; }
            set { _setSpecialNote = value; }
        }

        /// public propaty name  :  CatalogShapeNo
        /// <summary>カタログ図番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   カタログ図番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CatalogShapeNo
        {
            get { return _catalogShapeNo; }
            set { _catalogShapeNo = value; }
        }

        /// public propaty name  :  NewPrmSetDtlName
        /// <summary>新品番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   新品番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string NewPrmSetDtlName
        {
            get { return _newPrmSetDtlName; }
            set { _newPrmSetDtlName = value; }
        }

        /// public propaty name  :  OldPrmSetDtlName
        /// <summary>旧品番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   旧品番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string OldPrmSetDtlName
        {
            get { return _oldPrmSetDtlName; }
            set { _oldPrmSetDtlName = value; }
        }

        /// public propaty name  :  GoodsMakerCd
        /// <summary>メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCd
        {
            get { return _goodsMakerCd; }
            set { _goodsMakerCd = value; }
        }

        /// public propaty name  :  AfChgParentGoodsMakerCd
        /// <summary>変換後親メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   変換後親メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AfChgParentGoodsMakerCd
        {
            get { return _afChgParentGoodsMakerCd; }
            set { _afChgParentGoodsMakerCd = value; }
        }

        /// public propaty name  :  AfChgParentGoodsNo
        /// <summary>変換後親商品番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   変換後親商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AfChgParentGoodsNo
        {
            get { return _afChgParentGoodsNo; }
            set { _afChgParentGoodsNo = value; }
        }

        /// public propaty name  :  AfChgSubGoodsMakerCd
        /// <summary>変換後子商品メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   変換後子商品メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AfChgSubGoodsMakerCd
        {
            get { return _afChgSubGoodsMakerCd; }
            set { _afChgSubGoodsMakerCd = value; }
        }

        /// public propaty name  :  AfChgSubGoodsNo
        /// <summary>変換後子商品番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   変換後子商品番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AfChgSubGoodsNo
        {
            get { return _afChgSubGoodsNo; }
            set { _afChgSubGoodsNo = value; }
        }

        /// public propaty name  :  AfContentExplain
        /// <summary>備考プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   備考プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AfContentExplain
        {
            get { return _afContentExplain; }
            set { _afContentExplain = value; }
        }


        /// <summary>
        /// 商品セットワークコンストラクタ
        /// </summary>
        /// <returns>GoodsSetChgWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsSetChgWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public GoodsSetChgWork()
        {
        }

    }
    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>GoodsSetChgWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   GoodsSetChgWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class GoodsSetChgWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsSetChgWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  GoodsSetChgWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is GoodsSetChgWork || graph is ArrayList || graph is GoodsSetChgWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(GoodsSetChgWork).FullName));

            if (graph != null && graph is GoodsSetChgWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.GoodsSetChgWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is GoodsSetChgWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((GoodsSetChgWork[])graph).Length;
            }
            else if (graph is GoodsSetChgWork)
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
            //親メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //ParentGoodsMakerCd
            //親商品番号
            serInfo.MemberInfo.Add(typeof(string)); //ParentGoodsNo
            //子商品メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //SubGoodsMakerCd
            //子商品番号
            serInfo.MemberInfo.Add(typeof(string)); //SubGoodsNo
            //数量（浮動）
            serInfo.MemberInfo.Add(typeof(Double)); //CntFl
            //表示順位
            serInfo.MemberInfo.Add(typeof(Int32)); //DisplayOrder
            //セット規格・特記事項
            serInfo.MemberInfo.Add(typeof(string)); //SetSpecialNote
            //カタログ図番
            serInfo.MemberInfo.Add(typeof(string)); //CatalogShapeNo
            //新品番
            serInfo.MemberInfo.Add(typeof(string)); //NewPrmSetDtlName
            //旧品番
            serInfo.MemberInfo.Add(typeof(string)); //OldPrmSetDtlName
            //メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //変換後親メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //AfChgParentGoodsMakerCd
            //変換後親商品番号
            serInfo.MemberInfo.Add(typeof(string)); //AfChgParentGoodsNo
            //変換後子商品メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //AfChgSubGoodsMakerCd
            //変換後子商品番号
            serInfo.MemberInfo.Add(typeof(string)); //AfChgSubGoodsNo
            //備考
            serInfo.MemberInfo.Add(typeof(string)); //AfContentExplain


            serInfo.Serialize(writer, serInfo);
            if (graph is GoodsSetChgWork)
            {
                GoodsSetChgWork temp = (GoodsSetChgWork)graph;

                SetGoodsSetChgWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is GoodsSetChgWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((GoodsSetChgWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (GoodsSetChgWork temp in lst)
                {
                    SetGoodsSetChgWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// GoodsSetChgWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 24;

        /// <summary>
        ///  GoodsSetChgWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsSetChgWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetGoodsSetChgWork(System.IO.BinaryWriter writer, GoodsSetChgWork temp)
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
            //親メーカーコード
            writer.Write(temp.ParentGoodsMakerCd);
            //親商品番号
            writer.Write(temp.ParentGoodsNo);
            //子商品メーカーコード
            writer.Write(temp.SubGoodsMakerCd);
            //子商品番号
            writer.Write(temp.SubGoodsNo);
            //数量（浮動）
            writer.Write(temp.CntFl);
            //表示順位
            writer.Write(temp.DisplayOrder);
            //セット規格・特記事項
            writer.Write(temp.SetSpecialNote);
            //カタログ図番
            writer.Write(temp.CatalogShapeNo);
            //新品番
            writer.Write(temp.NewPrmSetDtlName);
            //旧品番
            writer.Write(temp.OldPrmSetDtlName);
            //メーカーコード
            writer.Write(temp.GoodsMakerCd);
            //変換後親メーカーコード
            writer.Write(temp.AfChgParentGoodsMakerCd);
            //変換後親商品番号
            writer.Write(temp.AfChgParentGoodsNo);
            //変換後子商品メーカーコード
            writer.Write(temp.AfChgSubGoodsMakerCd);
            //変換後子商品番号
            writer.Write(temp.AfChgSubGoodsNo);
            //備考
            writer.Write(temp.AfContentExplain);

        }

        /// <summary>
        ///  GoodsSetChgWorkインスタンス取得
        /// </summary>
        /// <returns>GoodsSetChgWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsSetChgWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private GoodsSetChgWork GetGoodsSetChgWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            GoodsSetChgWork temp = new GoodsSetChgWork();

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
            //親メーカーコード
            temp.ParentGoodsMakerCd = reader.ReadInt32();
            //親商品番号
            temp.ParentGoodsNo = reader.ReadString();
            //子商品メーカーコード
            temp.SubGoodsMakerCd = reader.ReadInt32();
            //子商品番号
            temp.SubGoodsNo = reader.ReadString();
            //数量（浮動）
            temp.CntFl = reader.ReadDouble();
            //表示順位
            temp.DisplayOrder = reader.ReadInt32();
            //セット規格・特記事項
            temp.SetSpecialNote = reader.ReadString();
            //カタログ図番
            temp.CatalogShapeNo = reader.ReadString();
            //新品番
            temp.NewPrmSetDtlName = reader.ReadString();
            //旧品番
            temp.OldPrmSetDtlName = reader.ReadString();
            //メーカーコード
            temp.GoodsMakerCd = reader.ReadInt32();
            //変換後親メーカーコード
            temp.AfChgParentGoodsMakerCd = reader.ReadInt32();
            //変換後親商品番号
            temp.AfChgParentGoodsNo = reader.ReadString();
            //変換後子商品メーカーコード
            temp.AfChgSubGoodsMakerCd = reader.ReadInt32();
            //変換後子商品番号
            temp.AfChgSubGoodsNo = reader.ReadString();
            //備考
            temp.AfContentExplain = reader.ReadString();


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
        /// <returns>GoodsSetChgWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   GoodsSetChgWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                GoodsSetChgWork temp = GetGoodsSetChgWork(reader, serInfo);
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
                    retValue = (GoodsSetChgWork[])lst.ToArray(typeof(GoodsSetChgWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }


}

//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 優良データ削除処理
// プログラム概要   : 優良データ削除処理
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10704766-00 作成担当 : 梁森東
// 作 成 日  2011/07/15  修正内容 : 連番No.2 新規作成                      
//----------------------------------------------------------------------------//
// 管理番号  11100068-00 作成担当 : 高騁
// 修 正 日  2015/06/08  修正内容 : REDMINE#45792の対応"商品マスタ削除" と同時に
//                                  掛率マスタは、削除する・削除しないを制御できるように修正する。
//----------------------------------------------------------------------------//
//****************************************************************************//
using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   DeleteConditionWork
    /// <summary>
    ///                      削除データワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   削除データワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2011/7/15</br>
    /// <br>Genarated Date   :   2011/07/16  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class DeleteConditionWork : IFileHeader
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

        /// <summary>削除区分</summary>
        private Int32 _deleteCode;

        /// <summary>商品メーカーコード</summary>
        private Int32 _goodsMakerCode;

        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>拠点名称</summary>
        private string _sectionName = "";

        /// <summary>コード1</summary>
        private Int32 _code1;

        /// <summary>コード2</summary>
        private Int32 _code2;

        /// <summary>コード3</summary>
        private Int32 _code3;

        /// <summary>コード4</summary>
        private Int32 _code4;

        /// <summary>商品削除区分</summary>
        private Int32 _goodsDeleteCode;

        /// <summary>結合削除区分</summary>
        private Int32 _joinDeleteCode;

        /// <summary>掛率削除区分</summary>
        private Int32 _rateDeleteCode; // ADD 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正

        /// <summary>商品削除件数</summary>
        private Int32 _goodsDeleteCnt;

        /// <summary>結合削除件数</summary>
        private Int32 _joinDeleteCnt;

        /// <summary>在庫削除件数</summary>
        private Int32 _stockDeleteCnt;

        /// <summary>掛率削除件数</summary>
        private Int32 _rateDeleteCnt; // ADD 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正

        /// <summary>商品未削除件数</summary>
        private Int32 _goodsNotDeleteCnt;

        /// <summary>結合未削除件数</summary>
        private Int32 _joinNotDeleteCnt;

        /// <summary>在庫未削除件数</summary>
        private Int32 _stockNotDeleteCnt;

        /// <summary>掛率未削除件数</summary>
        private Int32 _rateNotDeleteCnt; // ADD 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正

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

        /// public propaty name  :  DeleteCode
        /// <summary>削除区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   削除区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DeleteCode
        {
            get { return _deleteCode; }
            set { _deleteCode = value; }
        }

        /// public propaty name  :  GoodsMakerCode
        /// <summary>商品メーカーコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCode
        {
            get { return _goodsMakerCode; }
            set { _goodsMakerCode = value; }
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

        /// public propaty name  :  SectionName
        /// <summary>拠点名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionName
        {
            get { return _sectionName; }
            set { _sectionName = value; }
        }

        /// public propaty name  :  Code1
        /// <summary>コード1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   コード1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Code1
        {
            get { return _code1; }
            set { _code1 = value; }
        }

        /// public propaty name  :  Code2
        /// <summary>コード2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   コード2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Code2
        {
            get { return _code2; }
            set { _code2 = value; }
        }

        /// public propaty name  :  Code3
        /// <summary>コード3プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   コード3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Code3
        {
            get { return _code3; }
            set { _code3 = value; }
        }

        /// public propaty name  :  Code4
        /// <summary>コード4プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   コード4プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Code4
        {
            get { return _code4; }
            set { _code4 = value; }
        }

        /// public propaty name  :  GoodsDeleteCode
        /// <summary>商品削除区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品削除区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsDeleteCode
        {
            get { return _goodsDeleteCode; }
            set { _goodsDeleteCode = value; }
        }

        /// public propaty name  :  JoinDeleteCode
        /// <summary>結合削除区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   結合削除区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 JoinDeleteCode
        {
            get { return _joinDeleteCode; }
            set { _joinDeleteCode = value; }
        }

        // ---- ADD 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正 ---->>>>>
        /// public propaty name  :  RateDeleteCode
        /// <value>掛率削除区分プロパティ）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 RateDeleteCode
        {
            get { return _rateDeleteCode; }
            set { _rateDeleteCode = value; }
        }
        // ---- ADD 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正 ----<<<<<

        /// public propaty name  :  GoodsDeleteCnt
        /// <summary>商品削除件数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品削除件数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsDeleteCnt
        {
            get { return _goodsDeleteCnt; }
            set { _goodsDeleteCnt = value; }
        }

        /// public propaty name  :  JoinDeleteCnt
        /// <summary>結合削除件数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   結合削除件数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 JoinDeleteCnt
        {
            get { return _joinDeleteCnt; }
            set { _joinDeleteCnt = value; }
        }

        /// public propaty name  :  StockDeleteCnt
        /// <summary>在庫削除件数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫削除件数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockDeleteCnt
        {
            get { return _stockDeleteCnt; }
            set { _stockDeleteCnt = value; }
        }

        // ---- ADD 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正 ---->>>>>
        /// public propaty name  :  RateDeleteCnt
        /// <summary>掛率削除件数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   掛率削除件数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 RateDeleteCnt
        {
            get { return _rateDeleteCnt; }
            set { _rateDeleteCnt = value; }
        }
        // ---- ADD 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正 ----<<<<<

        /// public propaty name  :  GoodsNotDeleteCnt
        /// <summary>商品未削除件数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品未削除件数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsNotDeleteCnt
        {
            get { return _goodsNotDeleteCnt; }
            set { _goodsNotDeleteCnt = value; }
        }

        /// public propaty name  :  JoinNotDeleteCnt
        /// <summary>結合未削除件数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   結合未削除件数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 JoinNotDeleteCnt
        {
            get { return _joinNotDeleteCnt; }
            set { _joinNotDeleteCnt = value; }
        }

        /// public propaty name  :  StockNotDeleteCnt
        /// <summary>在庫未削除件数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫未削除件数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockNotDeleteCnt
        {
            get { return _stockNotDeleteCnt; }
            set { _stockNotDeleteCnt = value; }
        }

        // ---- ADD 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正 ---->>>>>
        /// public propaty name  :  RateNotDeleteCnt
        /// <summary>掛率未削除件数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   掛率未削除件数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 RateNotDeleteCnt
        {
            get { return _rateNotDeleteCnt; }
            set { _rateNotDeleteCnt = value; }
        }
        // ---- ADD 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正 ----<<<<<

        /// <summary>
        /// 削除データワークコンストラクタ
        /// </summary>
        /// <returns>DeleteConditionWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   DeleteConditionWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DeleteConditionWork()
        {
        }

    }
    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>DeleteConditionWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   DeleteConditionWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class DeleteConditionWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   DeleteConditionWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  DeleteConditionWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is DeleteConditionWork || graph is ArrayList || graph is DeleteConditionWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(DeleteConditionWork).FullName));

            if (graph != null && graph is DeleteConditionWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.DeleteConditionWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is DeleteConditionWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((DeleteConditionWork[])graph).Length;
            }
            else if (graph is DeleteConditionWork)
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
            //削除区分
            serInfo.MemberInfo.Add(typeof(Int32)); //DeleteCode
            //商品メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCode
            //拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //拠点名称
            serInfo.MemberInfo.Add(typeof(string)); //SectionName
            //コード1
            serInfo.MemberInfo.Add(typeof(Int32)); //Code1
            //コード2
            serInfo.MemberInfo.Add(typeof(Int32)); //Code2
            //コード3
            serInfo.MemberInfo.Add(typeof(Int32)); //Code3
            //コード4
            serInfo.MemberInfo.Add(typeof(Int32)); //Code4
            //商品削除区分
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsDeleteCode
            //結合削除区分
            serInfo.MemberInfo.Add(typeof(Int32)); //JoinDeleteCode
            //掛率削除区分
            serInfo.MemberInfo.Add(typeof(Int32)); //RateDeleteCode // ADD 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正
            //商品削除件数
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsDeleteCnt
            //結合削除件数
            serInfo.MemberInfo.Add(typeof(Int32)); //JoinDeleteCnt
            //在庫削除件数
            serInfo.MemberInfo.Add(typeof(Int32)); //StockDeleteCnt
            //掛率削除件数
            serInfo.MemberInfo.Add(typeof(Int32)); //RateDeleteCnt // ADD 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正
            //商品未削除件数
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsNotDeleteCnt
            //結合未削除件数
            serInfo.MemberInfo.Add(typeof(Int32)); //JoinNotDeleteCnt
            //在庫未削除件数
            serInfo.MemberInfo.Add(typeof(Int32)); //StockNotDeleteCnt
            //掛率未削除件数
            serInfo.MemberInfo.Add(typeof(Int32)); //RateNotDeleteCnt // ADD 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正


            serInfo.Serialize(writer, serInfo);
            if (graph is DeleteConditionWork)
            {
                DeleteConditionWork temp = (DeleteConditionWork)graph;

                SetDeleteConditionWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is DeleteConditionWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((DeleteConditionWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (DeleteConditionWork temp in lst)
                {
                    SetDeleteConditionWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// DeleteConditionWorkメンバ数(publicプロパティ数)
        /// </summary>
        //private const int currentMemberCount = 24; // DEL 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正
        private const int currentMemberCount = 27; // ADD 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正

        /// <summary>
        ///  DeleteConditionWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   DeleteConditionWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetDeleteConditionWork(System.IO.BinaryWriter writer, DeleteConditionWork temp)
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
            //削除区分
            writer.Write(temp.DeleteCode);
            //商品メーカーコード
            writer.Write(temp.GoodsMakerCode);
            //拠点コード
            writer.Write(temp.SectionCode);
            //拠点名称
            writer.Write(temp.SectionName);
            //コード1
            writer.Write(temp.Code1);
            //コード2
            writer.Write(temp.Code2);
            //コード3
            writer.Write(temp.Code3);
            //コード4
            writer.Write(temp.Code4);
            //商品削除区分
            writer.Write(temp.GoodsDeleteCode);
            //結合削除区分
            writer.Write(temp.JoinDeleteCode);
            //掛率削除区分
            writer.Write(temp.RateDeleteCode); // ADD 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正
            //商品削除件数
            writer.Write(temp.GoodsDeleteCnt);
            //結合削除件数
            writer.Write(temp.JoinDeleteCnt);
            //掛率削除件数
            writer.Write(temp.RateDeleteCnt); // ADD 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正
            //在庫削除件数
            writer.Write(temp.StockDeleteCnt);
            //商品未削除件数
            writer.Write(temp.GoodsNotDeleteCnt);
            //結合未削除件数
            writer.Write(temp.JoinNotDeleteCnt);
            //在庫未削除件数
            writer.Write(temp.StockNotDeleteCnt);
            //掛率未削除件数
            writer.Write(temp.RateNotDeleteCnt); // ADD 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正

        }

        /// <summary>
        ///  DeleteConditionWorkインスタンス取得
        /// </summary>
        /// <returns>DeleteConditionWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   DeleteConditionWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private DeleteConditionWork GetDeleteConditionWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            DeleteConditionWork temp = new DeleteConditionWork();

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
            //削除区分
            temp.DeleteCode = reader.ReadInt32();
            //商品メーカーコード
            temp.GoodsMakerCode = reader.ReadInt32();
            //拠点コード
            temp.SectionCode = reader.ReadString();
            //拠点名称
            temp.SectionName = reader.ReadString();
            //コード1
            temp.Code1 = reader.ReadInt32();
            //コード2
            temp.Code2 = reader.ReadInt32();
            //コード3
            temp.Code3 = reader.ReadInt32();
            //コード4
            temp.Code4 = reader.ReadInt32();
            //商品削除区分
            temp.GoodsDeleteCode = reader.ReadInt32();
            //結合削除区分
            temp.JoinDeleteCode = reader.ReadInt32();
            //掛率削除区分
            temp.RateDeleteCode = reader.ReadInt32(); // ADD 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正
            //商品削除件数
            temp.GoodsDeleteCnt = reader.ReadInt32();
            //結合削除件数
            temp.JoinDeleteCnt = reader.ReadInt32();
            //在庫削除件数
            temp.StockDeleteCnt = reader.ReadInt32();
            //掛率削除件数
            temp.RateDeleteCnt = reader.ReadInt32(); // ADD 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正
            //商品未削除件数
            temp.GoodsNotDeleteCnt = reader.ReadInt32();
            //結合未削除件数
            temp.JoinNotDeleteCnt = reader.ReadInt32();
            //在庫未削除件数
            temp.StockNotDeleteCnt = reader.ReadInt32();
            //掛率未削除件数
            temp.RateNotDeleteCnt = reader.ReadInt32(); // ADD 高騁 2015/06/08 for REDMINE#45792掛率マスタ削除・削除しないの制御修正


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
        /// <returns>DeleteConditionWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   DeleteConditionWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                DeleteConditionWork temp = GetDeleteConditionWork(reader, serInfo);
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
                    retValue = (DeleteConditionWork[])lst.ToArray(typeof(DeleteConditionWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}

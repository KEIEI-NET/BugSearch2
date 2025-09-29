//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : お買得商品グループ設定マスタ抽出結果
// プログラム概要   : お買得商品グループ設定マスタ抽出結果データパラメータ
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 自動生成
// 作 成 日  2015/02/23  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   RecBgnGrpWork
    /// <summary>
    ///                      お買得商品グループ設定マスタ抽出結果ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   お買得商品グループ設定マスタ抽出結果ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2015/02/23  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class RecBgnGrpWork 
    {
        /// <summary>作成日時</summary>
        /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        private DateTime _createDateTime;

        /// <summary>更新日時</summary>
        /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        private DateTime _updateDateTime;

        /// <summary>論理削除区分</summary>
        /// <remarks>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>問合せ元企業コード</summary>
        private string _inqOriginalEpCd = "";

        /// <summary>問合せ元拠点コード</summary>
        private string _inqOriginalSecCd = "";

        /// <summary>お買得商品グループコード</summary>
        /// <remarks>0:グループ無し</remarks>
        private Int16 _brgnGoodsGrpCode;

        /// <summary>表示順位</summary>
        private Int32 _displayOrder;

        /// <summary>お買得商品グループタイトル</summary>
        /// <remarks>(半角全角混在)</remarks>
        private string _brgnGoodsGrpTitle = "";

        /// <summary>お買得商品グループコメントタグ</summary>
        /// <remarks>(半角全角混在)</remarks>
        private string _brgnGoodsGrpTag = "";

        /// <summary>お買得商品グループコメント</summary>
        /// <remarks>(半角全角混在)</remarks>
        private string _brgnGoodsGrpComment = "";

        /// public propaty name  :  CreateDateTime
        /// <summary>作成日時</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime CreateDateTime
        {
            get { return _createDateTime; }
            set { _createDateTime = value; }
        }

        /// public propaty name  :  UpdateDateTime
        /// <summary>更新日時</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime UpdateDateTime
        {
            get { return _updateDateTime; }
            set { _updateDateTime = value; }
        }

        /// public propaty name  :  LogicalDeleteCode
        /// <summary>論理削除区分</summary>
        /// <value>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   論理削除区分</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 LogicalDeleteCode
        {
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
        }

        /// public propaty name  :  InqOriginalEpCd
        /// <summary>問合せ元企業コード</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ元企業コード</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InqOriginalEpCd
        {
            get { return _inqOriginalEpCd; }
            set { _inqOriginalEpCd = value; }
        }

        /// public propaty name  :  InqOriginalSecCd
        /// <summary>問合せ元拠点コード</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ元拠点コード</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InqOriginalSecCd
        {
            get { return _inqOriginalSecCd; }
            set { _inqOriginalSecCd = value; }
        }

        /// public propaty name  :  BrgnGoodsGrpCode
        /// <summary>お買得商品グループコード</summary>
        /// <value>0:グループ無し</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   お買得商品グループコード</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int16 BrgnGoodsGrpCode
        {
            get { return _brgnGoodsGrpCode; }
            set { _brgnGoodsGrpCode = value; }
        }

        /// public propaty name  :  DisplayOrder
        /// <summary>表示順位</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   表示順位</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DisplayOrder
        {
            get { return _displayOrder; }
            set { _displayOrder = value; }
        }

        /// public propaty name  :  BrgnGoodsGrpTitle
        /// <summary>お買得商品グループタイトル</summary>
        /// <value>(半角全角混在)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   お買得商品グループタイトル</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BrgnGoodsGrpTitle
        {
            get { return _brgnGoodsGrpTitle; }
            set { _brgnGoodsGrpTitle = value; }
        }

        /// public propaty name  :  BrgnGoodsGrpTag
        /// <summary>お買得商品グループコメントタグ</summary>
        /// <value>(半角全角混在)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   お買得商品グループコメントタグ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BrgnGoodsGrpTag
        {
            get { return _brgnGoodsGrpTag; }
            set { _brgnGoodsGrpTag = value; }
        }

        /// public propaty name  :  BrgnGoodsGrpComment
        /// <summary>お買得商品グループコメント</summary>
        /// <value>(半角全角混在)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   お買得商品グループコメント</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BrgnGoodsGrpComment
        {
            get { return _brgnGoodsGrpComment; }
            set { _brgnGoodsGrpComment = value; }
        }



        /// <summary>
        /// お買得商品グループ設定マスタ抽出結果ワークコンストラクタ
        /// </summary>
        /// <returns>RecBgnGrpWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RecBgnGrpWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public RecBgnGrpWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>RecBgnGrpWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   RecBgnGrpWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class RecBgnGrpWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   RecBgnGrpWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  RecBgnGrpWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is RecBgnGrpWork || graph is ArrayList || graph is RecBgnGrpWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(RecBgnGrpWork).FullName));

            if (graph != null && graph is RecBgnGrpWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.RecBgnGrpWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is RecBgnGrpWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((RecBgnGrpWork[])graph).Length;
            }
            else if (graph is RecBgnGrpWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //作成日時
            serInfo.MemberInfo.Add(typeof(Int64)); //CreateDateTime
            //更新日時
            serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTime
            //論理削除区分
            serInfo.MemberInfo.Add(typeof(Int32)); //LogicalDeleteCode
            //問合せ元企業コード
            serInfo.MemberInfo.Add(typeof(string)); //InqOriginalEpCd
            //問合せ元拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //InqOriginalSecCd
            //お買得商品グループコード
            serInfo.MemberInfo.Add(typeof(Int16)); //BrgnGoodsGrpCode
            //表示順位
            serInfo.MemberInfo.Add(typeof(Int32)); //DisplayOrder
            //お買得商品グループタイトル
            serInfo.MemberInfo.Add(typeof(string)); //BrgnGoodsGrpTitle
            //お買得商品グループコメントタグ
            serInfo.MemberInfo.Add(typeof(string)); //BrgnGoodsGrpTag
            //お買得商品グループコメント
            serInfo.MemberInfo.Add(typeof(string)); //BrgnGoodsGrpComment



            serInfo.Serialize(writer, serInfo);
            if (graph is RecBgnGrpWork)
            {
                RecBgnGrpWork temp = (RecBgnGrpWork)graph;

                SetRecBgnGrpWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is RecBgnGrpWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((RecBgnGrpWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (RecBgnGrpWork temp in lst)
                {
                    SetRecBgnGrpWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// RecBgnGrpWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 10;

        /// <summary>
        ///  RecBgnGrpWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   RecBgnGrpWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetRecBgnGrpWork(System.IO.BinaryWriter writer, RecBgnGrpWork temp)
        {
            //作成日時
            writer.Write((Int64)temp.CreateDateTime.Ticks);
            //更新日時
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
            //論理削除区分
            writer.Write((Int32)temp.LogicalDeleteCode);
            //問合せ元企業コード
            writer.Write(temp.InqOriginalEpCd);
            //問合せ元拠点コード
            writer.Write(temp.InqOriginalSecCd);
            //お買得商品グループコード
            writer.Write(temp.BrgnGoodsGrpCode);
            //表示順位
            writer.Write((Int32)temp.DisplayOrder);
            //お買得商品グループタイトル
            writer.Write(temp.BrgnGoodsGrpTitle);
            //お買得商品グループコメントタグ
            writer.Write(temp.BrgnGoodsGrpTag);
            //お買得商品グループコメント
            writer.Write(temp.BrgnGoodsGrpComment);


        }

        /// <summary>
        ///  RecBgnGrpWorkインスタンス取得
        /// </summary>
        /// <returns>RecBgnGrpWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RecBgnGrpWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private RecBgnGrpWork GetRecBgnGrpWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            RecBgnGrpWork temp = new RecBgnGrpWork();

            //作成日時
            temp.CreateDateTime = new DateTime(reader.ReadInt64());
            //更新日時
            temp.UpdateDateTime = new DateTime(reader.ReadInt64());
            //論理削除区分
            temp.LogicalDeleteCode = reader.ReadInt32();
            //問合せ元企業コード
            temp.InqOriginalEpCd = reader.ReadString();
            //問合せ元拠点コード
            temp.InqOriginalSecCd = reader.ReadString();
            //お買得商品グループコード
            temp.BrgnGoodsGrpCode = reader.ReadInt16();
            //表示順位
            temp.DisplayOrder = reader.ReadInt32();
            //お買得商品グループタイトル
            temp.BrgnGoodsGrpTitle = reader.ReadString();
            //お買得商品グループコメントタグ
            temp.BrgnGoodsGrpTag = reader.ReadString();
            //お買得商品グループコメント
            temp.BrgnGoodsGrpComment = reader.ReadString();



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
        /// <returns>RecBgnGrpWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   RecBgnGrpWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                RecBgnGrpWork temp = GetRecBgnGrpWork(reader, serInfo);
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
                    retValue = (RecBgnGrpWork[])lst.ToArray(typeof(RecBgnGrpWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}

//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 他社部品検索履歴照会 
// プログラム概要   : 他社部品検索履歴照会を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 朱 猛
// 作 成 日  2010/11/11  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 朱 猛
// 作 成 日  2010/11/19  修正内容 : Redmine#17394
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 朱 猛
// 作 成 日  2010/11/24  修正内容 : Redmine#17451
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   ScmInqLogInquiryWork
    /// <summary>
    ///                      SCM問合せログ問合せワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   SCM問合せログ問合せワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2010/10/14</br>
    /// <br>Genarated Date   :   2010/11/24  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class ScmInqLogInquiryWork
    {
        /// <summary>作成日時</summary>
        /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        private DateTime _createDateTime;

        /// <summary>連結元企業名称</summary>
        private string _cnectOriginalEpNm = "";

        /// <summary>問合せ元データ入力システム</summary>
        /// <remarks>1:SF.NS 2:BK/BF.NS 3:RC.NS 4:SF7 5:BK-P 6:RC7</remarks>
        private Int32 _inqDataInputSystem;

        /// <summary>SCM問合せ内容</summary>
        /// <remarks>nvarchar(max)</remarks>
        private string _scmInqContents = "";


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

        /// public propaty name  :  CnectOriginalEpNm
        /// <summary>連結元企業名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   連結元企業名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CnectOriginalEpNm
        {
            get { return _cnectOriginalEpNm; }
            set { _cnectOriginalEpNm = value; }
        }

        /// public propaty name  :  InqDataInputSystem
        /// <summary>問合せ元データ入力システムプロパティ</summary>
        /// <value>1:SF.NS 2:BK/BF.NS 3:RC.NS 4:SF7 5:BK-P 6:RC7</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問合せ元データ入力システムプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 InqDataInputSystem
        {
            get { return _inqDataInputSystem; }
            set { _inqDataInputSystem = value; }
        }

        /// public propaty name  :  ScmInqContents
        /// <summary>SCM問合せ内容プロパティ</summary>
        /// <value>nvarchar(max)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   SCM問合せ内容プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ScmInqContents
        {
            get { return _scmInqContents; }
            set { _scmInqContents = value; }
        }


        /// <summary>
        /// SCM問合せログ問合せワークコンストラクタ
        /// </summary>
        /// <returns>ScmInqLogInquiryWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ScmInqLogInquiryWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ScmInqLogInquiryWork()
        {
        }

    }


    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>ScmInqLogInquiryWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   ScmInqLogInquiryWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class ScmInqLogInquiryWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   ScmInqLogInquiryWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  ScmInqLogInquiryWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !( graph is ScmInqLogInquiryWork || graph is ArrayList || graph is ScmInqLogInquiryWork[] ))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(ScmInqLogInquiryWork).FullName));

            if (graph != null && graph is ScmInqLogInquiryWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.ScmInqLogInquiryWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ( (ArrayList)graph ).Count;
            }
            else if (graph is ScmInqLogInquiryWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ( (ScmInqLogInquiryWork[])graph ).Length;
            }
            else if (graph is ScmInqLogInquiryWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //作成日時
            serInfo.MemberInfo.Add(typeof(Int64)); //CreateDateTime
            //連結元企業名称
            serInfo.MemberInfo.Add(typeof(string)); //CnectOriginalEpNm
            //問合せ元データ入力システム
            serInfo.MemberInfo.Add(typeof(Int32)); //InqDataInputSystem
            //SCM問合せ内容
            serInfo.MemberInfo.Add(typeof(string)); //ScmInqContents


            serInfo.Serialize(writer, serInfo);
            if (graph is ScmInqLogInquiryWork)
            {
                ScmInqLogInquiryWork temp = (ScmInqLogInquiryWork)graph;

                SetScmInqLogInquiryWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is ScmInqLogInquiryWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((ScmInqLogInquiryWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (ScmInqLogInquiryWork temp in lst)
                {
                    SetScmInqLogInquiryWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// ScmInqLogInquiryWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 4;

        /// <summary>
        ///  ScmInqLogInquiryWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   ScmInqLogInquiryWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetScmInqLogInquiryWork(System.IO.BinaryWriter writer, ScmInqLogInquiryWork temp)
        {
            //作成日時
            writer.Write((Int64)temp.CreateDateTime.Ticks);
            //連結元企業名称
            writer.Write(temp.CnectOriginalEpNm);
            //問合せ元データ入力システム
            writer.Write(temp.InqDataInputSystem);
            //SCM問合せ内容
            writer.Write(temp.ScmInqContents);

        }

        /// <summary>
        ///  ScmInqLogInquiryWorkインスタンス取得
        /// </summary>
        /// <returns>ScmInqLogInquiryWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ScmInqLogInquiryWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private ScmInqLogInquiryWork GetScmInqLogInquiryWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            ScmInqLogInquiryWork temp = new ScmInqLogInquiryWork();

            //作成日時
            temp.CreateDateTime = new DateTime(reader.ReadInt64());
            //連結元企業名称
            temp.CnectOriginalEpNm = reader.ReadString();
            //問合せ元データ入力システム
            temp.InqDataInputSystem = reader.ReadInt32();
            //SCM問合せ内容
            temp.ScmInqContents = reader.ReadString();


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
        /// <returns>ScmInqLogInquiryWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   ScmInqLogInquiryWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                ScmInqLogInquiryWork temp = GetScmInqLogInquiryWork(reader, serInfo);
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
                    retValue = (ScmInqLogInquiryWork[])lst.ToArray(typeof(ScmInqLogInquiryWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}

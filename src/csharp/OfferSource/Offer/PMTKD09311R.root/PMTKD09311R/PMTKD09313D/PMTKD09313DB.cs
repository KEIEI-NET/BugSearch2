//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 優良部品詳細マスタDBリモートオブジェクト
// プログラム概要   : 優良部品詳細マスタの取得を行います。
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370090-00 作成担当 : 櫻井　亮太
// 作 成 日  2017/10/17  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   PrmPrtDtParaWork
    /// <summary>
    ///                      優良部品詳細情報条件ワークワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   優良部品詳細情報条件ワークワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2017/10/6</br>
    /// <br>Genarated Date   :   2017/10/24  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class PrmPrtDtParaWork
    {
        /// <summary>部品メーカーコード</summary>
        /// <remarks>自動車ﾒｰｶｰ(1～899:提供分, 900～998:ﾕｰｻﾞｰ登録),優良ﾒｰｶｰ(1000～8999:提供,9000～9999:ﾕｰｻﾞｰ登録)</remarks>
        private Int32 _partsMakerCode;

        /// <summary>優良品番(－付き品番)</summary>
        /// <remarks>ハイフン付き</remarks>
        private string _primePartsNoWithH = "";

        /// <summary>詳細マスタ有無区分</summary>
        /// <remarks>0:無し,1:有り</remarks>
        private Int16 _dtlMstExistDiv;


        /// public propaty name  :  PartsMakerCode
        /// <summary>部品メーカーコードプロパティ</summary>
        /// <value>自動車ﾒｰｶｰ(1～899:提供分, 900～998:ﾕｰｻﾞｰ登録),優良ﾒｰｶｰ(1000～8999:提供,9000～9999:ﾕｰｻﾞｰ登録)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品メーカーコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PartsMakerCode
        {
            get { return _partsMakerCode; }
            set { _partsMakerCode = value; }
        }

        /// public propaty name  :  PrimePartsNoWithH
        /// <summary>優良品番(－付き品番)プロパティ</summary>
        /// <value>ハイフン付き</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良品番(－付き品番)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PrimePartsNoWithH
        {
            get { return _primePartsNoWithH; }
            set { _primePartsNoWithH = value; }
        }

        /// public propaty name  :  DtlMstExistDiv
        /// <summary>詳細マスタ有無区分プロパティ</summary>
        /// <value>0:無し,1:有り</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   詳細マスタ有無区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int16 DtlMstExistDiv
        {
            get { return _dtlMstExistDiv; }
            set { _dtlMstExistDiv = value; }
        }


        /// <summary>
        /// 優良部品詳細情報条件ワークワークコンストラクタ
        /// </summary>
        /// <returns>PrmPrtDtParaWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PrmPrtDtParaWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PrmPrtDtParaWork()
        {
        }

    }
    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>PrmPrtDtParaWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   PrmPrtDtParaWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class PrmPrtDtParaWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   PrmPrtDtParaWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  PrmPrtDtParaWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is PrmPrtDtParaWork || graph is ArrayList || graph is PrmPrtDtParaWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(PrmPrtDtParaWork).FullName));

            if (graph != null && graph is PrmPrtDtParaWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.PrmPrtDtParaWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is PrmPrtDtParaWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((PrmPrtDtParaWork[])graph).Length;
            }
            else if (graph is PrmPrtDtParaWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //部品メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //PartsMakerCode
            //優良品番(－付き品番)
            serInfo.MemberInfo.Add(typeof(string)); //PrimePartsNoWithH
            //詳細マスタ有無区分
            serInfo.MemberInfo.Add(typeof(Int16)); //DtlMstExistDiv


            serInfo.Serialize(writer, serInfo);
            if (graph is PrmPrtDtParaWork)
            {
                PrmPrtDtParaWork temp = (PrmPrtDtParaWork)graph;

                SetPrmPrtDtParaWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is PrmPrtDtParaWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((PrmPrtDtParaWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (PrmPrtDtParaWork temp in lst)
                {
                    SetPrmPrtDtParaWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// PrmPrtDtParaWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 3;

        /// <summary>
        ///  PrmPrtDtParaWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   PrmPrtDtParaWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetPrmPrtDtParaWork(System.IO.BinaryWriter writer, PrmPrtDtParaWork temp)
        {
            //部品メーカーコード
            writer.Write(temp.PartsMakerCode);
            //優良品番(－付き品番)
            writer.Write(temp.PrimePartsNoWithH);
            //詳細マスタ有無区分
            writer.Write(temp.DtlMstExistDiv);

        }

        /// <summary>
        ///  PrmPrtDtParaWorkインスタンス取得
        /// </summary>
        /// <returns>PrmPrtDtParaWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PrmPrtDtParaWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private PrmPrtDtParaWork GetPrmPrtDtParaWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            PrmPrtDtParaWork temp = new PrmPrtDtParaWork();

            //部品メーカーコード
            temp.PartsMakerCode = reader.ReadInt32();
            //優良品番(－付き品番)
            temp.PrimePartsNoWithH = reader.ReadString();
            //詳細マスタ有無区分
            temp.DtlMstExistDiv = reader.ReadInt16();


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
        /// <returns>PrmPrtDtParaWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PrmPrtDtParaWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                PrmPrtDtParaWork temp = GetPrmPrtDtParaWork(reader, serInfo);
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
                    retValue = (PrmPrtDtParaWork[])lst.ToArray(typeof(PrmPrtDtParaWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}

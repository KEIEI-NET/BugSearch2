//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 仕入先総括マスタ一覧表抽出結果クラスワーク
// プログラム概要   : 仕入先総括マスタ一覧表抽出結果クラスワークヘッダファイル
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : FSI菅原　要
// 作 成 日  2012/09/07  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SumSuppStPrintResultWork
    /// <summary>
    ///                      仕入先総括一覧表 抽出結果ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   仕入先総括一覧表 抽出結果ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2012/09/07  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SumSuppStPrintResultWork
    {
        /// <summary>総括拠点コード</summary>
        private string _sumSectionCd = "";

        /// <summary>総括仕入先コード</summary>
        private Int32 _sumSupplierCd;

        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>仕入先コード</summary>
        private Int32 _supplierCode;


        /// public propaty name  :  SumSectionCd
        /// <summary>総括拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   総括拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SumSectionCd
        {
            get { return _sumSectionCd; }
            set { _sumSectionCd = value; }
        }

        /// public propaty name  :  SumSupplierCd
        /// <summary>総括仕入先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   総括仕入先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SumSupplierCd
        {
            get { return _sumSupplierCd; }
            set { _sumSupplierCd = value; }
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

        /// public propaty name  :  SupplierCode
        /// <summary>仕入先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupplierCode
        {
            get { return _supplierCode; }
            set { _supplierCode = value; }
        }


        /// <summary>
        /// 仕入先総括一覧表 抽出結果ワークコンストラクタ
        /// </summary>
        /// <returns>SumSuppStPrintResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SumSuppStPrintResultWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SumSuppStPrintResultWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>SumSuppStPrintResultWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   SumSuppStPrintResultWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class SumSuppStPrintResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SumSuppStPrintResultWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SumSuppStPrintResultWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SumSuppStPrintResultWork || graph is ArrayList || graph is SumSuppStPrintResultWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(SumSuppStPrintResultWork).FullName));

            if (graph != null && graph is SumSuppStPrintResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SumSuppStPrintResultWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SumSuppStPrintResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SumSuppStPrintResultWork[])graph).Length;
            }
            else if (graph is SumSuppStPrintResultWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //総括拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //SumSectionCd
            //総括仕入先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SumSupplierCd
            //拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //仕入先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCode


            serInfo.Serialize(writer, serInfo);
            if (graph is SumSuppStPrintResultWork)
            {
                SumSuppStPrintResultWork temp = (SumSuppStPrintResultWork)graph;

                SetSumSuppStPrintResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SumSuppStPrintResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SumSuppStPrintResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SumSuppStPrintResultWork temp in lst)
                {
                    SetSumSuppStPrintResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SumSuppStPrintResultWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 4;

        /// <summary>
        ///  SumSuppStPrintResultWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SumSuppStPrintResultWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetSumSuppStPrintResultWork(System.IO.BinaryWriter writer, SumSuppStPrintResultWork temp)
        {
            //総括拠点コード
            writer.Write(temp.SumSectionCd);
            //総括仕入先コード
            writer.Write(temp.SumSupplierCd);
            //拠点コード
            writer.Write(temp.SectionCode);
            //仕入先コード
            writer.Write(temp.SupplierCode);

        }

        /// <summary>
        ///  SumSuppStPrintResultWorkインスタンス取得
        /// </summary>
        /// <returns>SumSuppStPrintResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SumSuppStPrintResultWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private SumSuppStPrintResultWork GetSumSuppStPrintResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            SumSuppStPrintResultWork temp = new SumSuppStPrintResultWork();

            //総括拠点コード
            temp.SumSectionCd = reader.ReadString();
            //総括仕入先コード
            temp.SumSupplierCd = reader.ReadInt32();
            //拠点コード
            temp.SectionCode = reader.ReadString();
            //仕入先コード
            temp.SupplierCode = reader.ReadInt32();


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
        /// <returns>SumSuppStPrintResultWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SumSuppStPrintResultWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SumSuppStPrintResultWork temp = GetSumSuppStPrintResultWork(reader, serInfo);
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
                    retValue = (SumSuppStPrintResultWork[])lst.ToArray(typeof(SumSuppStPrintResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }



}

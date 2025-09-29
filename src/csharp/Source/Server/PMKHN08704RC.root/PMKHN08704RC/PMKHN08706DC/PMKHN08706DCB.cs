//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 部品価格展開処理件数クラスワーク
// プログラム概要   : 部品価格展開処理件数クラスワークを管理する
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10703874-00 作成担当 : huangqb
// 作 成 日  K2011/07/14 作成内容 : イスコ個別対応
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   CostExpandProcessNumWork
    /// <summary>
    ///                      部品価格展開処理件数クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   部品価格展開処理件数クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   K2011/07/14</br>
    /// <br>Genarated Date   :   K2011/07/14  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class CostExpandProcessNumWork
    {
        /// <summary>Ｂ’価格（トヨタ）</summary>
        private Int64 _toyotaBProcessNum;

        /// <summary>原価（トヨタ）</summary>
        private Int64 _toyotaProcessNum;

        /// <summary>Ｂ’価格（タクティ）</summary>
        private Int64 _takuthiBProcessNum;

        /// <summary>原価（タクティ）</summary>
        private Int64 _takuthiProcessNum;

        /// <summary>原価（日産）</summary>
        private Int64 _nissanProcessNum;

        /// <summary>原価（ピットワーク）</summary>
        private Int64 _bittowaakuProcessNum;


        /// public propaty name  :  ToyotaBProcessNum
        /// <summary>Ｂ’価格（トヨタ）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   Ｂ’価格（トヨタ）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ToyotaBProcessNum
        {
            get { return _toyotaBProcessNum; }
            set { _toyotaBProcessNum = value; }
        }

        /// public propaty name  :  ToyotaProcessNum
        /// <summary>原価（トヨタ）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   原価（トヨタ）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ToyotaProcessNum
        {
            get { return _toyotaProcessNum; }
            set { _toyotaProcessNum = value; }
        }

        /// public propaty name  :  TakuthiBProcessNum
        /// <summary>Ｂ’価格（タクティ）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   Ｂ’価格（タクティ）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TakuthiBProcessNum
        {
            get { return _takuthiBProcessNum; }
            set { _takuthiBProcessNum = value; }
        }

        /// public propaty name  :  TakuthiProcessNum
        /// <summary>原価（タクティ）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   原価（タクティ）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 TakuthiProcessNum
        {
            get { return _takuthiProcessNum; }
            set { _takuthiProcessNum = value; }
        }

        /// public propaty name  :  NissanProcessNum
        /// <summary>原価（日産）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   原価（日産）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 NissanProcessNum
        {
            get { return _nissanProcessNum; }
            set { _nissanProcessNum = value; }
        }

        /// public propaty name  :  BittowaakuProcessNum
        /// <summary>原価（ピットワーク）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   原価（ピットワーク）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 BittowaakuProcessNum
        {
            get { return _bittowaakuProcessNum; }
            set { _bittowaakuProcessNum = value; }
        }


        /// <summary>
        /// 部品価格展開処理件数クラスワークコンストラクタ
        /// </summary>
        /// <returns>CostExpandProcessNumWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CostExpandProcessNumWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public CostExpandProcessNumWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>CostExpandProcessNumWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   CostExpandProcessNumWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class CostExpandProcessNumWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   CostExpandProcessNumWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  CostExpandProcessNumWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is CostExpandProcessNumWork || graph is ArrayList || graph is CostExpandProcessNumWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(CostExpandProcessNumWork).FullName));

            if (graph != null && graph is CostExpandProcessNumWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.CostExpandProcessNumWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is CostExpandProcessNumWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((CostExpandProcessNumWork[])graph).Length;
            }
            else if (graph is CostExpandProcessNumWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //Ｂ’価格（トヨタ）
            serInfo.MemberInfo.Add(typeof(Int64)); //ToyotaBProcessNum
            //原価（トヨタ）
            serInfo.MemberInfo.Add(typeof(Int64)); //ToyotaProcessNum
            //Ｂ’価格（タクティ）
            serInfo.MemberInfo.Add(typeof(Int64)); //TakuthiBProcessNum
            //原価（タクティ）
            serInfo.MemberInfo.Add(typeof(Int64)); //TakuthiProcessNum
            //原価（日産）
            serInfo.MemberInfo.Add(typeof(Int64)); //NissanProcessNum
            //原価（ピットワーク）
            serInfo.MemberInfo.Add(typeof(Int64)); //BittowaakuProcessNum


            serInfo.Serialize(writer, serInfo);
            if (graph is CostExpandProcessNumWork)
            {
                CostExpandProcessNumWork temp = (CostExpandProcessNumWork)graph;

                SetCostExpandProcessNumWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is CostExpandProcessNumWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((CostExpandProcessNumWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (CostExpandProcessNumWork temp in lst)
                {
                    SetCostExpandProcessNumWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// CostExpandProcessNumWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 6;

        /// <summary>
        ///  CostExpandProcessNumWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   CostExpandProcessNumWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetCostExpandProcessNumWork(System.IO.BinaryWriter writer, CostExpandProcessNumWork temp)
        {
            //Ｂ’価格（トヨタ）
            writer.Write(temp.ToyotaBProcessNum);
            //原価（トヨタ）
            writer.Write(temp.ToyotaProcessNum);
            //Ｂ’価格（タクティ）
            writer.Write(temp.TakuthiBProcessNum);
            //原価（タクティ）
            writer.Write(temp.TakuthiProcessNum);
            //原価（日産）
            writer.Write(temp.NissanProcessNum);
            //原価（ピットワーク）
            writer.Write(temp.BittowaakuProcessNum);

        }

        /// <summary>
        ///  CostExpandProcessNumWorkインスタンス取得
        /// </summary>
        /// <returns>CostExpandProcessNumWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CostExpandProcessNumWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private CostExpandProcessNumWork GetCostExpandProcessNumWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            CostExpandProcessNumWork temp = new CostExpandProcessNumWork();

            //Ｂ’価格（トヨタ）
            temp.ToyotaBProcessNum = reader.ReadInt64();
            //原価（トヨタ）
            temp.ToyotaProcessNum = reader.ReadInt64();
            //Ｂ’価格（タクティ）
            temp.TakuthiBProcessNum = reader.ReadInt64();
            //原価（タクティ）
            temp.TakuthiProcessNum = reader.ReadInt64();
            //原価（日産）
            temp.NissanProcessNum = reader.ReadInt64();
            //原価（ピットワーク）
            temp.BittowaakuProcessNum = reader.ReadInt64();


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
        /// <returns>CostExpandProcessNumWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CostExpandProcessNumWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                CostExpandProcessNumWork temp = GetCostExpandProcessNumWork(reader, serInfo);
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
                    retValue = (CostExpandProcessNumWork[])lst.ToArray(typeof(CostExpandProcessNumWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}

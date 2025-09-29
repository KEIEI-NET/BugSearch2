//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 部品価格展開処理エラークラスワーク
// プログラム概要   : 部品価格展開処理エラークラスワークを管理する
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
    /// public class name:   CostExpandErrorWork
    /// <summary>
    ///                      部品価格展開処理エラークラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   部品価格展開処理エラークラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   K2011/07/14</br>
    /// <br>Genarated Date   :   K2011/07/14  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class CostExpandErrorWork
    {
        /// <summary>品番</summary>
        private string _goodsNo = "";

        /// <summary>メーカー</summary>
        private Int32 _goodsMakerCd;

        /// <summary>メッセージ</summary>
        private string _errorMessage = "";


        /// public propaty name  :  GoodsNo
        /// <summary>品番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsNo
        {
            get { return _goodsNo; }
            set { _goodsNo = value; }
        }

        /// public propaty name  :  GoodsMakerCd
        /// <summary>メーカープロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカープロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCd
        {
            get { return _goodsMakerCd; }
            set { _goodsMakerCd = value; }
        }

        /// public propaty name  :  ErrorMessage
        /// <summary>メッセージプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メッセージプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; }
        }


        /// <summary>
        /// 部品価格展開処理エラークラスワークコンストラクタ
        /// </summary>
        /// <returns>CostExpandErrorWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CostExpandErrorWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public CostExpandErrorWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>CostExpandErrorWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   CostExpandErrorWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class CostExpandErrorWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   CostExpandErrorWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  CostExpandErrorWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is CostExpandErrorWork || graph is ArrayList || graph is CostExpandErrorWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(CostExpandErrorWork).FullName));

            if (graph != null && graph is CostExpandErrorWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.CostExpandErrorWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is CostExpandErrorWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((CostExpandErrorWork[])graph).Length;
            }
            else if (graph is CostExpandErrorWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //品番
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //メーカー
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //メッセージ
            serInfo.MemberInfo.Add(typeof(string)); //ErrorMessage


            serInfo.Serialize(writer, serInfo);
            if (graph is CostExpandErrorWork)
            {
                CostExpandErrorWork temp = (CostExpandErrorWork)graph;

                SetCostExpandErrorWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is CostExpandErrorWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((CostExpandErrorWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (CostExpandErrorWork temp in lst)
                {
                    SetCostExpandErrorWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// CostExpandErrorWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 3;

        /// <summary>
        ///  CostExpandErrorWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   CostExpandErrorWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetCostExpandErrorWork(System.IO.BinaryWriter writer, CostExpandErrorWork temp)
        {
            //品番
            writer.Write(temp.GoodsNo);
            //メーカー
            writer.Write(temp.GoodsMakerCd);
            //メッセージ
            writer.Write(temp.ErrorMessage);

        }

        /// <summary>
        ///  CostExpandErrorWorkインスタンス取得
        /// </summary>
        /// <returns>CostExpandErrorWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CostExpandErrorWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private CostExpandErrorWork GetCostExpandErrorWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            CostExpandErrorWork temp = new CostExpandErrorWork();

            //品番
            temp.GoodsNo = reader.ReadString();
            //メーカー
            temp.GoodsMakerCd = reader.ReadInt32();
            //メッセージ
            temp.ErrorMessage = reader.ReadString();


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
        /// <returns>CostExpandErrorWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CostExpandErrorWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                CostExpandErrorWork temp = GetCostExpandErrorWork(reader, serInfo);
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
                    retValue = (CostExpandErrorWork[])lst.ToArray(typeof(CostExpandErrorWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}

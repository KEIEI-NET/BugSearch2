//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : PM離島価格マスタ抽出結果
// プログラム概要   : PM離島価格マスタ抽出結果データパラメータ
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 自動生成
// 作 成 日  2015.02.24  修正内容 : 新規作成
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   PmIsolPrcWork
    /// <summary>
    ///                      PM離島価格マスタ抽出結果ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   PM離島価格マスタ抽出結果ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2015.02.24  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class PmIsolPrcWork 
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

        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>メーカーコード</summary>
        /// <remarks>1～899:提供分, 900～ユーザー登録</remarks>
        private Int32 _makerCode;

        /// <summary>上限金額</summary>
        /// <remarks>(9999999)</remarks>
        private double _upperLimitPrice;

        /// <summary>PM端数処理単位</summary>
        /// <remarks>(9999999)</remarks>
        private double _pMFractionProcUnit;

        /// <summary>PM端数処理区分</summary>
        /// <remarks>1:切捨て, 2:四捨五入, 3:切上げ</remarks>
        private Int32 _pMFractionProcCd;

        /// <summary>定価UP率</summary>
        /// <remarks>(999)</remarks>
        private double _listPriceUpRate;

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

        /// public propaty name  :  EnterpriseCode
        /// <summary>企業コード</summary>
        /// <value>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   企業コード</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// public propaty name  :  SectionCode
        /// <summary>拠点コード</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コード</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

        /// public propaty name  :  MakerCode
        /// <summary>メーカーコード</summary>
        /// <value>1～899:提供分, 900～ユーザー登録</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカーコード</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MakerCode
        {
            get { return _makerCode; }
            set { _makerCode = value; }
        }

        /// public propaty name  :  UpperLimitPrice
        /// <summary>上限金額</summary>
        /// <value>(9999999)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   上限金額</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public double UpperLimitPrice
        {
            get { return _upperLimitPrice; }
            set { _upperLimitPrice = value; }
        }

        /// public propaty name  :  PMFractionProcUnit
        /// <summary>PM端数処理単位</summary>
        /// <value>(9999999)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PM端数処理単位</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public double PMFractionProcUnit
        {
            get { return _pMFractionProcUnit; }
            set { _pMFractionProcUnit = value; }
        }

        /// public propaty name  :  PMFractionProcCd
        /// <summary>PM端数処理区分</summary>
        /// <value>1:切捨て, 2:四捨五入, 3:切上げ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PM端数処理区分</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PMFractionProcCd
        {
            get { return _pMFractionProcCd; }
            set { _pMFractionProcCd = value; }
        }

        /// public propaty name  :  ListPriceUpRate
        /// <summary>定価UP率</summary>
        /// <value>(999)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   定価UP率</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public double ListPriceUpRate
        {
            get { return _listPriceUpRate; }
            set { _listPriceUpRate = value; }
        }



        /// <summary>
        /// PM離島価格マスタ抽出結果ワークコンストラクタ
        /// </summary>
        /// <returns>PmIsolPrcWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PmIsolPrcWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PmIsolPrcWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>PmIsolPrcWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   PmIsolPrcWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class PmIsolPrcWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   PmIsolPrcWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  PmIsolPrcWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is PmIsolPrcWork || graph is ArrayList || graph is PmIsolPrcWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(PmIsolPrcWork).FullName));

            if (graph != null && graph is PmIsolPrcWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.PmIsolPrcWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is PmIsolPrcWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((PmIsolPrcWork[])graph).Length;
            }
            else if (graph is PmIsolPrcWork)
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
            //企業コード
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //MakerCode
            //上限金額
            serInfo.MemberInfo.Add(typeof(double)); //UpperLimitPrice
            //PM端数処理単位
            serInfo.MemberInfo.Add(typeof(double)); //PMFractionProcUnit
            //PM端数処理区分
            serInfo.MemberInfo.Add(typeof(Int32)); //PMFractionProcCd
            //定価UP率
            serInfo.MemberInfo.Add(typeof(double)); //ListPriceUpRate



            serInfo.Serialize(writer, serInfo);
            if (graph is PmIsolPrcWork)
            {
                PmIsolPrcWork temp = (PmIsolPrcWork)graph;

                SetPmIsolPrcWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is PmIsolPrcWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((PmIsolPrcWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (PmIsolPrcWork temp in lst)
                {
                    SetPmIsolPrcWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// PmIsolPrcWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 10;

        /// <summary>
        ///  PmIsolPrcWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   PmIsolPrcWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetPmIsolPrcWork(System.IO.BinaryWriter writer, PmIsolPrcWork temp)
        {
            //作成日時
            writer.Write((Int64)temp.CreateDateTime.Ticks);
            //更新日時
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
            //論理削除区分
            writer.Write((Int32)temp.LogicalDeleteCode);
            //企業コード
            writer.Write(temp.EnterpriseCode);
            //拠点コード
            writer.Write(temp.SectionCode);
            //メーカーコード
            writer.Write((Int32)temp.MakerCode);
            //上限金額
            writer.Write((double)temp.UpperLimitPrice);
            //PM端数処理単位
            writer.Write((double)temp.PMFractionProcUnit);
            //PM端数処理区分
            writer.Write((Int32)temp.PMFractionProcCd);
            //定価UP率
            writer.Write((double)temp.ListPriceUpRate);


        }

        /// <summary>
        ///  PmIsolPrcWorkインスタンス取得
        /// </summary>
        /// <returns>PmIsolPrcWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PmIsolPrcWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private PmIsolPrcWork GetPmIsolPrcWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            PmIsolPrcWork temp = new PmIsolPrcWork();

            //作成日時
            temp.CreateDateTime = new DateTime(reader.ReadInt64());
            //更新日時
            temp.UpdateDateTime = new DateTime(reader.ReadInt64());
            //論理削除区分
            temp.LogicalDeleteCode = reader.ReadInt32();
            //企業コード
            temp.EnterpriseCode = reader.ReadString();
            //拠点コード
            temp.SectionCode = reader.ReadString();
            //メーカーコード
            temp.MakerCode = reader.ReadInt32();
            //上限金額
            temp.UpperLimitPrice = reader.ReadDouble();
            //PM端数処理単位
            temp.PMFractionProcUnit = reader.ReadDouble();
            //PM端数処理区分
            temp.PMFractionProcCd = reader.ReadInt32();
            //定価UP率
            temp.ListPriceUpRate = reader.ReadDouble();



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
        /// <returns>PmIsolPrcWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PmIsolPrcWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                PmIsolPrcWork temp = GetPmIsolPrcWork(reader, serInfo);
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
                    retValue = (PmIsolPrcWork[])lst.ToArray(typeof(PmIsolPrcWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}

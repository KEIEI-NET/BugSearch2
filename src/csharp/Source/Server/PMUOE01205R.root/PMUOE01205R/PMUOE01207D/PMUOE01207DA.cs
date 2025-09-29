//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   UOE入庫更新データパラメータ
//                  :   PMUOE01207D.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   21112　久保田
// Date             :   2008.10.17
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   UOEStockUpdSearchWork
    /// <summary>
    ///                      UOE入庫更新検索条件クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   UOE入庫更新検索条件クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/10/20  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class UOEStockUpdSearchWork
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>拠点コード</summary>
        /// <remarks>ログイン拠点コードを設定</remarks>
        private string _sectionCode = "";

        /// <summary>処理区分</summary>
        /// <remarks>0:在庫一括 1:在庫一括以外</remarks>
        private Int32 _procDiv;

        /// <summary>UOE発注先コード</summary>
        /// <remarks>画面上の仕入先コードを設定</remarks>
        private Int32 _uOESupplierCd;

        /// <summary>伝票番号</summary>
        /// <remarks>画面上の納品書番号を設定</remarks>
        private string _slipNo = "";


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

        /// public propaty name  :  SectionCode
        /// <summary>拠点コードプロパティ</summary>
        /// <value>ログイン拠点コードを設定</value>
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

        /// public propaty name  :  ProcDiv
        /// <summary>処理区分プロパティ</summary>
        /// <value>0:在庫一括 1:在庫一括以外</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   処理区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ProcDiv
        {
            get { return _procDiv; }
            set { _procDiv = value; }
        }

        /// public propaty name  :  UOESupplierCd
        /// <summary>UOE発注先コードプロパティ</summary>
        /// <value>画面上の仕入先コードを設定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE発注先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UOESupplierCd
        {
            get { return _uOESupplierCd; }
            set { _uOESupplierCd = value; }
        }

        /// public propaty name  :  SlipNo
        /// <summary>伝票番号プロパティ</summary>
        /// <value>画面上の納品書番号を設定</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SlipNo
        {
            get { return _slipNo; }
            set { _slipNo = value; }
        }


        /// <summary>
        /// UOE入庫更新検索条件クラスワークコンストラクタ
        /// </summary>
        /// <returns>UOEStockUpdSearchWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UOEStockUpdSearchWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public UOEStockUpdSearchWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>UOEStockUpdSearchWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   UOEStockUpdSearchWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class UOEStockUpdSearchWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   UOEStockUpdSearchWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  UOEStockUpdSearchWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is UOEStockUpdSearchWork || graph is ArrayList || graph is UOEStockUpdSearchWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(UOEStockUpdSearchWork).FullName));

            if (graph != null && graph is UOEStockUpdSearchWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.UOEStockUpdSearchWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is UOEStockUpdSearchWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((UOEStockUpdSearchWork[])graph).Length;
            }
            else if (graph is UOEStockUpdSearchWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //企業コード
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //処理区分
            serInfo.MemberInfo.Add(typeof(Int32)); //ProcDiv
            //UOE発注先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //UOESupplierCd
            //伝票番号
            serInfo.MemberInfo.Add(typeof(string)); //SlipNo


            serInfo.Serialize(writer, serInfo);
            if (graph is UOEStockUpdSearchWork)
            {
                UOEStockUpdSearchWork temp = (UOEStockUpdSearchWork)graph;

                SetUOEStockUpdSearchWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is UOEStockUpdSearchWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((UOEStockUpdSearchWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (UOEStockUpdSearchWork temp in lst)
                {
                    SetUOEStockUpdSearchWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// UOEStockUpdSearchWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 5;

        /// <summary>
        ///  UOEStockUpdSearchWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   UOEStockUpdSearchWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetUOEStockUpdSearchWork(System.IO.BinaryWriter writer, UOEStockUpdSearchWork temp)
        {
            //企業コード
            writer.Write(temp.EnterpriseCode);
            //拠点コード
            writer.Write(temp.SectionCode);
            //処理区分
            writer.Write(temp.ProcDiv);
            //UOE発注先コード
            writer.Write(temp.UOESupplierCd);
            //伝票番号
            writer.Write(temp.SlipNo);

        }

        /// <summary>
        ///  UOEStockUpdSearchWorkインスタンス取得
        /// </summary>
        /// <returns>UOEStockUpdSearchWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UOEStockUpdSearchWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private UOEStockUpdSearchWork GetUOEStockUpdSearchWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            UOEStockUpdSearchWork temp = new UOEStockUpdSearchWork();

            //企業コード
            temp.EnterpriseCode = reader.ReadString();
            //拠点コード
            temp.SectionCode = reader.ReadString();
            //処理区分
            temp.ProcDiv = reader.ReadInt32();
            //UOE発注先コード
            temp.UOESupplierCd = reader.ReadInt32();
            //伝票番号
            temp.SlipNo = reader.ReadString();


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
        /// <returns>UOEStockUpdSearchWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UOEStockUpdSearchWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                UOEStockUpdSearchWork temp = GetUOEStockUpdSearchWork(reader, serInfo);
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
                    retValue = (UOEStockUpdSearchWork[])lst.ToArray(typeof(UOEStockUpdSearchWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}

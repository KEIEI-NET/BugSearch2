using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   CreditMngListResultWork
    /// <summary>
    ///                      与信管理表リモート抽出結果クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   与信管理表リモート抽出結果クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2007/11/15  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class CreditMngListResultWork
    {
        /// <summary>得意先コード</summary>
        private Int32 _customerCode;

        /// <summary>得意先略称</summary>
        private string _customerSnm = "";

        /// <summary>与信額</summary>
        private Int64 _creditMoney;

        /// <summary>警告与信額</summary>
        private Int64 _warningCreditMoney;

        /// <summary>現在売掛残高</summary>
        private Int64 _prsntAccRecBalance;

        /// <summary>使用率</summary>
        private Double _creditRate;

        /// <summary>顧客担当従業員コード</summary>
        /// <remarks>文字型</remarks>
        private string _customerAgentCd = "";

        /// <summary>顧客担当従業員名称</summary>
        private string _customerAgentNm = "";

        /// <summary>管理拠点コード</summary>
        private string _mngSectionCode = "";

        /// <summary>管理拠点ガイド名称</summary>
        private string _sectionGuideNm = "";


        /// public propaty name  :  CustomerCode
        /// <summary>得意先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
        }

        /// public propaty name  :  CustomerSnm
        /// <summary>得意先略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustomerSnm
        {
            get { return _customerSnm; }
            set { _customerSnm = value; }
        }

        /// public propaty name  :  CreditMoney
        /// <summary>与信額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   与信額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 CreditMoney
        {
            get { return _creditMoney; }
            set { _creditMoney = value; }
        }

        /// public propaty name  :  WarningCreditMoney
        /// <summary>警告与信額プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   警告与信額プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 WarningCreditMoney
        {
            get { return _warningCreditMoney; }
            set { _warningCreditMoney = value; }
        }

        /// public propaty name  :  PrsntAccRecBalance
        /// <summary>現在売掛残高プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   現在売掛残高プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 PrsntAccRecBalance
        {
            get { return _prsntAccRecBalance; }
            set { _prsntAccRecBalance = value; }
        }

        /// public propaty name  :  CreditRate
        /// <summary>使用率プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   使用率プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double CreditRate
        {
            get { return _creditRate; }
            set { _creditRate = value; }
        }

        /// public propaty name  :  CustomerAgentCd
        /// <summary>顧客担当従業員コードプロパティ</summary>
        /// <value>文字型</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   顧客担当従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustomerAgentCd
        {
            get { return _customerAgentCd; }
            set { _customerAgentCd = value; }
        }

        /// public propaty name  :  CustomerAgentNm
        /// <summary>顧客担当従業員名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   顧客担当従業員名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustomerAgentNm
        {
            get { return _customerAgentNm; }
            set { _customerAgentNm = value; }
        }

        /// public propaty name  :  MngSectionCode
        /// <summary>管理拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   管理拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MngSectionCode
        {
            get { return _mngSectionCode; }
            set { _mngSectionCode = value; }
        }

        /// public propaty name  :  SectionGuideNm
        /// <summary>管理拠点ガイド名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   管理拠点ガイド名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionGuideNm
        {
            get { return _sectionGuideNm; }
            set { _sectionGuideNm = value; }
        }


        /// <summary>
        /// 与信管理表リモート抽出結果クラスワークコンストラクタ
        /// </summary>
        /// <returns>CreditMngListResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CreditMngListResultWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public CreditMngListResultWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>CreditMngListResultWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   CreditMngListResultWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class CreditMngListResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   CreditMngListResultWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  CreditMngListResultWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is CreditMngListResultWork || graph is ArrayList || graph is CreditMngListResultWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(CreditMngListResultWork).FullName));

            if (graph != null && graph is CreditMngListResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.CreditMngListResultWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is CreditMngListResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((CreditMngListResultWork[])graph).Length;
            }
            else if (graph is CreditMngListResultWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //得意先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //得意先略称
            serInfo.MemberInfo.Add(typeof(string)); //CustomerSnm
            //与信額
            serInfo.MemberInfo.Add(typeof(Int64)); //CreditMoney
            //警告与信額
            serInfo.MemberInfo.Add(typeof(Int64)); //WarningCreditMoney
            //現在売掛残高
            serInfo.MemberInfo.Add(typeof(Int64)); //PrsntAccRecBalance
            //使用率
            serInfo.MemberInfo.Add(typeof(Double)); //CreditRate
            //顧客担当従業員コード
            serInfo.MemberInfo.Add(typeof(string)); //CustomerAgentCd
            //顧客担当従業員名称
            serInfo.MemberInfo.Add(typeof(string)); //CustomerAgentNm
            //管理拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //MngSectionCode
            //管理拠点ガイド名称
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideNm


            serInfo.Serialize(writer, serInfo);
            if (graph is CreditMngListResultWork)
            {
                CreditMngListResultWork temp = (CreditMngListResultWork)graph;

                SetCreditMngListResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is CreditMngListResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((CreditMngListResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (CreditMngListResultWork temp in lst)
                {
                    SetCreditMngListResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// CreditMngListResultWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 10;

        /// <summary>
        ///  CreditMngListResultWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   CreditMngListResultWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetCreditMngListResultWork(System.IO.BinaryWriter writer, CreditMngListResultWork temp)
        {
            //得意先コード
            writer.Write(temp.CustomerCode);
            //得意先略称
            writer.Write(temp.CustomerSnm);
            //与信額
            writer.Write(temp.CreditMoney);
            //警告与信額
            writer.Write(temp.WarningCreditMoney);
            //現在売掛残高
            writer.Write(temp.PrsntAccRecBalance);
            //使用率
            writer.Write(temp.CreditRate);
            //顧客担当従業員コード
            writer.Write(temp.CustomerAgentCd);
            //顧客担当従業員名称
            writer.Write(temp.CustomerAgentNm);
            //管理拠点コード
            writer.Write(temp.MngSectionCode);
            //管理拠点ガイド名称
            writer.Write(temp.SectionGuideNm);

        }

        /// <summary>
        ///  CreditMngListResultWorkインスタンス取得
        /// </summary>
        /// <returns>CreditMngListResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CreditMngListResultWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private CreditMngListResultWork GetCreditMngListResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            CreditMngListResultWork temp = new CreditMngListResultWork();

            //得意先コード
            temp.CustomerCode = reader.ReadInt32();
            //得意先略称
            temp.CustomerSnm = reader.ReadString();
            //与信額
            temp.CreditMoney = reader.ReadInt64();
            //警告与信額
            temp.WarningCreditMoney = reader.ReadInt64();
            //現在売掛残高
            temp.PrsntAccRecBalance = reader.ReadInt64();
            //使用率
            temp.CreditRate = reader.ReadDouble();
            //顧客担当従業員コード
            temp.CustomerAgentCd = reader.ReadString();
            //顧客担当従業員名称
            temp.CustomerAgentNm = reader.ReadString();
            //管理拠点コード
            temp.MngSectionCode = reader.ReadString();
            //管理拠点ガイド名称
            temp.SectionGuideNm = reader.ReadString();


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
        /// <returns>CreditMngListResultWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CreditMngListResultWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                CreditMngListResultWork temp = GetCreditMngListResultWork(reader, serInfo);
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
                    retValue = (CreditMngListResultWork[])lst.ToArray(typeof(CreditMngListResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}

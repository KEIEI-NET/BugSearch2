using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   MonthlyAddUpWork
    /// <summary>
    ///                      月次更新パラメータクラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   月次更新パラメータクラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/07/31  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class MonthlyAddUpWork
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>計上拠点コード</summary>
        /// <remarks>集計の対象となっている拠点コード,全社：""またはNull</remarks>
        private string _addUpSecCode = "";

        /// <summary>計上年月日</summary>
        /// <remarks>YYYYMMDD　月次締を行った日</remarks>
        private DateTime _addUpDate;

        /// <summary>計上年月</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _addUpYearMonth;

        /// <summary>自社締日</summary>
        /// <remarks>DD</remarks>
        private Int32 _companyTotalDay;

        /// <summary>処理内容フラグ</summary>
        /// <remarks>1:締取消,2:月次更新処理</remarks>
        private Int32 _procCntntsFlag;

        /// <summary>在庫更新区分</summary>
        /// <remarks>1:更新,2:更新なし</remarks>
        private Int32 _stockUpdDiv;

        /// <summary>期末更新区分</summary>
        /// <remarks>0:期末以外,1:期末</remarks>
        private Int32 _termLastDiv;

        /// <summary>前回月次処理日</summary>
        private DateTime _lstMonAddUpProcDay;

        /// <summary>今回月次処理日</summary>
        private DateTime _thisMonAddUpProcDay;

        /// <summary>開始計上日付</summary>
        /// <remarks>在庫開始集計日</remarks>
        private DateTime _addUpDateSt;

        /// <summary>終了計上日付</summary>
        /// <remarks>在庫終了集計日</remarks>
        private DateTime _addUpDateEd;

        /// <summary>在庫評価方法</summary>
        /// <remarks>1:最終仕入原価法,2:移動平均法,3:個別単価法</remarks>
        private Int32 _stockPointWay;

        /// <summary>端数処理区分</summary>
        /// <remarks>1:切捨て,2:四捨五入,3:切上げ</remarks>
        private Int32 _fractionProcCd;

        /// <summary>データ保存月数</summary>
        private Int32 _dataSaveMonths;

        /// <summary>実績データ保存月数</summary>
        private Int32 _resultDtSaveMonths;

        /// <summary>車輌部品データ保存月数</summary>
        private Int32 _caPrtsDtSaveMonths;

        /// <summary>マスタ保存月数</summary>
        private Int32 _masterSaveMonths;


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

        /// public propaty name  :  ResultsAddUpSecCd
        /// <summary>計上拠点コードプロパティ</summary>
        /// <value>集計の対象となっている拠点コード,全社：""またはNull</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddUpSecCode
        {
            get { return _addUpSecCode; }
            set { _addUpSecCode = value; }
        }

        /// public propaty name  :  AddUpDate
        /// <summary>計上年月日プロパティ</summary>
        /// <value>YYYYMMDD　月次締を行った日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上年月日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime AddUpDate
        {
            get { return _addUpDate; }
            set { _addUpDate = value; }
        }

        /// public propaty name  :  SalesDate
        /// <summary>計上年月プロパティ</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上年月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime AddUpYearMonth
        {
            get { return _addUpYearMonth; }
            set { _addUpYearMonth = value; }
        }

        /// public propaty name  :  CompanyTotalDay
        /// <summary>自社締日プロパティ</summary>
        /// <value>DD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社締日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CompanyTotalDay
        {
            get { return _companyTotalDay; }
            set { _companyTotalDay = value; }
        }

        /// public propaty name  :  ProcCntntsFlag
        /// <summary>処理内容フラグプロパティ</summary>
        /// <value>1:締取消,2:月次更新処理</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   処理内容フラグプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ProcCntntsFlag
        {
            get { return _procCntntsFlag; }
            set { _procCntntsFlag = value; }
        }

        /// public propaty name  :  StockUpdDiv
        /// <summary>在庫更新区分プロパティ</summary>
        /// <value>1:更新,2:更新なし</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫更新区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockUpdDiv
        {
            get { return _stockUpdDiv; }
            set { _stockUpdDiv = value; }
        }

        /// public propaty name  :  TermLastDiv
        /// <summary>期末更新区分プロパティ</summary>
        /// <value>0:期末以外,1:期末</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   期末更新区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TermLastDiv
        {
            get { return _termLastDiv; }
            set { _termLastDiv = value; }
        }

        /// public propaty name  :  LstMonAddUpProcDay
        /// <summary>前回月次処理日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   前回月次処理日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime LstMonAddUpProcDay
        {
            get { return _lstMonAddUpProcDay; }
            set { _lstMonAddUpProcDay = value; }
        }

        /// public propaty name  :  ThisMonAddUpProcDay
        /// <summary>今回月次処理日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   今回月次処理日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime ThisMonAddUpProcDay
        {
            get { return _thisMonAddUpProcDay; }
            set { _thisMonAddUpProcDay = value; }
        }

        /// public propaty name  :  AddUpDateSt
        /// <summary>開始計上日付プロパティ</summary>
        /// <value>在庫開始集計日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始計上日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime AddUpDateSt
        {
            get { return _addUpDateSt; }
            set { _addUpDateSt = value; }
        }

        /// public propaty name  :  AddUpDateEd
        /// <summary>終了計上日付プロパティ</summary>
        /// <value>在庫終了集計日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了計上日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime AddUpDateEd
        {
            get { return _addUpDateEd; }
            set { _addUpDateEd = value; }
        }

        /// public propaty name  :  StockPointWay
        /// <summary>在庫評価方法プロパティ</summary>
        /// <value>1:最終仕入原価法,2:移動平均法,3:個別単価法</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫評価方法プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockPointWay
        {
            get { return _stockPointWay; }
            set { _stockPointWay = value; }
        }

        /// public propaty name  :  FractionProcCd
        /// <summary>端数処理区分プロパティ</summary>
        /// <value>1:切捨て,2:四捨五入,3:切上げ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   端数処理区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 FractionProcCd
        {
            get { return _fractionProcCd; }
            set { _fractionProcCd = value; }
        }

        /// public propaty name  :  DataSaveMonths
        /// <summary>データ保存月数プロパティ</summary>
        /// <value>データ保存月数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   データ保存月数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DataSaveMonths
        {
            get { return _dataSaveMonths; }
            set { _dataSaveMonths = value; }
        }

        /// public propaty name  :  ResultDtSaveMonths
        /// <summary>実績データ保存月数プロパティ</summary>
        /// <value>実績データ保存月数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   実績データ保存月数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ResultDtSaveMonths
        {
            get { return _resultDtSaveMonths; }
            set { _resultDtSaveMonths = value; }
        }

        /// public propaty name  :  CaPrtsDtSaveMonths
        /// <summary>車輌部品データ保存月数プロパティ</summary>
        /// <value>車輌部品データ保存月数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車輌部品データ保存月数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CaPrtsDtSaveMonths
        {
            get { return _caPrtsDtSaveMonths; }
            set { _caPrtsDtSaveMonths = value; }
        }

        /// public propaty name  :  MasterSaveMonths
        /// <summary>マスタ保存月数プロパティ</summary>
        /// <value>マスタ保存月数</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   マスタ保存月数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MasterSaveMonths
        {
            get { return _masterSaveMonths; }
            set { _masterSaveMonths = value; }
        }


        /// <summary>
        /// 月次更新パラメータクラスワークコンストラクタ
        /// </summary>
        /// <returns>MonthlyAddUpWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   MonthlyAddUpWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public MonthlyAddUpWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>MonthlyAddUpWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   MonthlyAddUpWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class MonthlyAddUpWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   MonthlyAddUpWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  MonthlyAddUpWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is MonthlyAddUpWork || graph is ArrayList || graph is MonthlyAddUpWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(MonthlyAddUpWork).FullName));

            if (graph != null && graph is MonthlyAddUpWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.MonthlyAddUpWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is MonthlyAddUpWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((MonthlyAddUpWork[])graph).Length;
            }
            else if (graph is MonthlyAddUpWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //企業コード
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //計上拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //ResultsAddUpSecCd
            //計上年月日
            serInfo.MemberInfo.Add(typeof(Int32)); //AddUpDate
            //計上年月
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesDate
            //自社締日
            serInfo.MemberInfo.Add(typeof(Int32)); //CompanyTotalDay
            //処理内容フラグ
            serInfo.MemberInfo.Add(typeof(Int32)); //ProcCntntsFlag
            //在庫更新区分
            serInfo.MemberInfo.Add(typeof(Int32)); //StockUpdDiv
            //期末更新区分
            serInfo.MemberInfo.Add(typeof(Int32)); //TermLastDiv
            //前回月次処理日
            serInfo.MemberInfo.Add(typeof(Int32)); //LstMonAddUpProcDay
            //今回月次処理日
            serInfo.MemberInfo.Add(typeof(Int32)); //ThisMonAddUpProcDay
            //開始計上日付
            serInfo.MemberInfo.Add(typeof(Int32)); //AddUpDateSt
            //終了計上日付
            serInfo.MemberInfo.Add(typeof(Int32)); //AddUpDateEd
            //在庫評価方法
            serInfo.MemberInfo.Add(typeof(Int32)); //StockPointWay
            //端数処理区分
            serInfo.MemberInfo.Add(typeof(Int32)); //FractionProcCd
            //データ保存月数
            serInfo.MemberInfo.Add(typeof(Int32)); //DataSaveMonths
            //実績データ保存月数
            serInfo.MemberInfo.Add(typeof(Int32)); //ResultDtSaveMonths
            //車輌部品データ保存月数
            serInfo.MemberInfo.Add(typeof(Int32)); //CaPrtsDtSaveMonths
            //マスタ保存月数
            serInfo.MemberInfo.Add(typeof(Int32)); //MasterSaveMonths


            serInfo.Serialize(writer, serInfo);
            if (graph is MonthlyAddUpWork)
            {
                MonthlyAddUpWork temp = (MonthlyAddUpWork)graph;

                SetMonthlyAddUpWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is MonthlyAddUpWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((MonthlyAddUpWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (MonthlyAddUpWork temp in lst)
                {
                    SetMonthlyAddUpWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// MonthlyAddUpWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 18;

        /// <summary>
        ///  MonthlyAddUpWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   MonthlyAddUpWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetMonthlyAddUpWork(System.IO.BinaryWriter writer, MonthlyAddUpWork temp)
        {
            //企業コード
            writer.Write(temp.EnterpriseCode);
            //計上拠点コード
            writer.Write(temp.AddUpSecCode);
            //計上年月日
            writer.Write((Int64)temp.AddUpDate.Ticks);
            //計上年月
            writer.Write((Int64)temp.AddUpYearMonth.Ticks);
            //自社締日
            writer.Write(temp.CompanyTotalDay);
            //処理内容フラグ
            writer.Write(temp.ProcCntntsFlag);
            //在庫更新区分
            writer.Write(temp.StockUpdDiv);
            //期末更新区分
            writer.Write(temp.TermLastDiv);
            //前回月次処理日
            writer.Write((Int64)temp.LstMonAddUpProcDay.Ticks);
            //今回月次処理日
            writer.Write((Int64)temp.ThisMonAddUpProcDay.Ticks);
            //開始計上日付
            writer.Write((Int64)temp.AddUpDateSt.Ticks);
            //終了計上日付
            writer.Write((Int64)temp.AddUpDateEd.Ticks);
            //在庫評価方法
            writer.Write(temp.StockPointWay);
            //端数処理区分
            writer.Write(temp.FractionProcCd);
            //データ保存月数
            writer.Write(temp.DataSaveMonths);
            //実績データ保存月数
            writer.Write(temp.ResultDtSaveMonths);
            //車輌部品データ保存月数
            writer.Write(temp.CaPrtsDtSaveMonths);
            //マスタ保存月数
            writer.Write(temp.MasterSaveMonths);

        }

        /// <summary>
        ///  MonthlyAddUpWorkインスタンス取得
        /// </summary>
        /// <returns>MonthlyAddUpWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   MonthlyAddUpWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private MonthlyAddUpWork GetMonthlyAddUpWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            MonthlyAddUpWork temp = new MonthlyAddUpWork();

            //企業コード
            temp.EnterpriseCode = reader.ReadString();
            //計上拠点コード
            temp.AddUpSecCode = reader.ReadString();
            //計上年月日
            temp.AddUpDate = new DateTime(reader.ReadInt64());
            //計上年月
            temp.AddUpYearMonth = new DateTime(reader.ReadInt64());
            //自社締日
            temp.CompanyTotalDay = reader.ReadInt32();
            //処理内容フラグ
            temp.ProcCntntsFlag = reader.ReadInt32();
            //在庫更新区分
            temp.StockUpdDiv = reader.ReadInt32();
            //期末更新区分
            temp.TermLastDiv = reader.ReadInt32();
            //前回月次処理日
            temp.LstMonAddUpProcDay = new DateTime(reader.ReadInt64());
            //今回月次処理日
            temp.ThisMonAddUpProcDay = new DateTime(reader.ReadInt64());
            //開始計上日付
            temp.AddUpDateSt = new DateTime(reader.ReadInt64());
            //終了計上日付
            temp.AddUpDateEd = new DateTime(reader.ReadInt64());
            //在庫評価方法
            temp.StockPointWay = reader.ReadInt32();
            //端数処理区分
            temp.FractionProcCd = reader.ReadInt32();
            //データ保存月数
            temp.DataSaveMonths = reader.ReadInt32();
            //実績データ保存月数
            temp.ResultDtSaveMonths = reader.ReadInt32();
            //車輌部品データ保存月数
            temp.CaPrtsDtSaveMonths = reader.ReadInt32();
            //マスタ保存月数
            temp.MasterSaveMonths = reader.ReadInt32();


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
        /// <returns>MonthlyAddUpWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   MonthlyAddUpWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                MonthlyAddUpWork temp = GetMonthlyAddUpWork(reader, serInfo);
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
                    retValue = (MonthlyAddUpWork[])lst.ToArray(typeof(MonthlyAddUpWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }


}

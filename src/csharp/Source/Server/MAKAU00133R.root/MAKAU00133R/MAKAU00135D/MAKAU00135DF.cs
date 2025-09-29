using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   MTtlSumCompWork
    /// <summary>
    ///                      月次集計企業管理テーブルワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   月次集計企業管理テーブルワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2006/12/04</br>
    /// <br>Genarated Date   :   2008/02/26  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2006/12/04  村瀬　勝也</br>
    /// <br>                 :   テーブル名称を任意拠点範囲設定マスタ</br>
    /// <br>                 :   (VolSecAbtRF)から集計拠点グループ</br>
    /// <br>                 :   マスタ(SumGrpRF)に変更。</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class MTtlSumCompWork
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

        /// <summary>対象パッケージ</summary>
        private string _packageName = "";

        /// <summary>集計モード</summary>
        /// <remarks>0：集計、１：解除→集計</remarks>
        private Int32 _summarizeMode;

        /// <summary>集計対象年月日（開始）</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _summarizeStaYeMon;

        /// <summary>集計対象年月日（終了）</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _summarizeEndYeMon;

        /// <summary>計上年月</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _addUpYearMonth;

        /// <summary>スケジュール日時</summary>
        /// <remarks>集計実行日（DateTime:精度は100ナノ秒）</remarks>
        private DateTime _scheduleDateTime;

        /// <summary>集計完了日</summary>
        /// <remarks>集計完了日</remarks>
        private DateTime _isSummarized;

        /// <summary>DWH集計完了日</summary>
        /// <remarks>ＤＷＨ集計完了日（ﾃﾞｰﾀｳｴｱﾊｳｽ用集計に仕様する）</remarks>
        private DateTime _isDwhSummarized;


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

        /// public propaty name  :  UpdateDateTime
        /// <summary>更新日時プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime UpdateDateTime
        {
            get { return _updateDateTime; }
            set { _updateDateTime = value; }
        }

        /// public propaty name  :  LogicalDeleteCode
        /// <summary>論理削除区分プロパティ</summary>
        /// <value>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   論理削除区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 LogicalDeleteCode
        {
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
        }

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

        /// public propaty name  :  PackageName
        /// <summary>対象パッケージプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   対象パッケージプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PackageName
        {
            get { return _packageName; }
            set { _packageName = value; }
        }

        /// public propaty name  :  SummarizeMode
        /// <summary>集計モードプロパティ</summary>
        /// <value>0：集計、１：解除→集計</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   集計モードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SummarizeMode
        {
            get { return _summarizeMode; }
            set { _summarizeMode = value; }
        }

        /// public propaty name  :  SummarizeStaYeMon
        /// <summary>集計対象年月日（開始）プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   集計対象年月日（開始）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime SummarizeStaYeMon
        {
            get { return _summarizeStaYeMon; }
            set { _summarizeStaYeMon = value; }
        }

        /// public propaty name  :  SummarizeEndYeMon
        /// <summary>集計対象年月日（終了）プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   集計対象年月日（終了）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime SummarizeEndYeMon
        {
            get { return _summarizeEndYeMon; }
            set { _summarizeEndYeMon = value; }
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

        /// public propaty name  :  ScheduleDateTime
        /// <summary>スケジュール日時プロパティ</summary>
        /// <value>集計実行日（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   スケジュール日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime ScheduleDateTime
        {
            get { return _scheduleDateTime; }
            set { _scheduleDateTime = value; }
        }

        /// public propaty name  :  IsSummarized
        /// <summary>集計完了日プロパティ</summary>
        /// <value>集計完了日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   集計完了日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime IsSummarized
        {
            get { return _isSummarized; }
            set { _isSummarized = value; }
        }

        /// public propaty name  :  IsDwhSummarized
        /// <summary>DWH集計完了日プロパティ</summary>
        /// <value>ＤＷＨ集計完了日（ﾃﾞｰﾀｳｴｱﾊｳｽ用集計に仕様する）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   DWH集計完了日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime IsDwhSummarized
        {
            get { return _isDwhSummarized; }
            set { _isDwhSummarized = value; }
        }


        /// <summary>
        /// 月次集計企業管理テーブルワークコンストラクタ
        /// </summary>
        /// <returns>MTtlSumCompWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   MTtlSumCompWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public MTtlSumCompWork()
        {
        }

    }
    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>MTtlSumCompWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   MTtlSumCompWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class MTtlSumCompWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   MTtlSumCompWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  MTtlSumCompWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is MTtlSumCompWork || graph is ArrayList || graph is MTtlSumCompWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(MTtlSumCompWork).FullName));

            if (graph != null && graph is MTtlSumCompWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.MTtlSumCompWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is MTtlSumCompWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((MTtlSumCompWork[])graph).Length;
            }
            else if (graph is MTtlSumCompWork)
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
            //対象パッケージ
            serInfo.MemberInfo.Add(typeof(string)); //PackageName
            //集計モード
            serInfo.MemberInfo.Add(typeof(Int32)); //SummarizeMode
            //集計対象年月日（開始）
            serInfo.MemberInfo.Add(typeof(Int32)); //SummarizeStaYeMon
            //集計対象年月日（終了）
            serInfo.MemberInfo.Add(typeof(Int32)); //SummarizeEndYeMon
            //計上年月
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesDate
            //スケジュール日時
            serInfo.MemberInfo.Add(typeof(Int64)); //ScheduleDateTime
            //集計完了日
            serInfo.MemberInfo.Add(typeof(Int32)); //IsSummarized
            //DWH集計完了日
            serInfo.MemberInfo.Add(typeof(Int32)); //IsDwhSummarized


            serInfo.Serialize(writer, serInfo);
            if (graph is MTtlSumCompWork)
            {
                MTtlSumCompWork temp = (MTtlSumCompWork)graph;

                SetMTtlSumCompWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is MTtlSumCompWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((MTtlSumCompWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (MTtlSumCompWork temp in lst)
                {
                    SetMTtlSumCompWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// MTtlSumCompWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 12;

        /// <summary>
        ///  MTtlSumCompWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   MTtlSumCompWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetMTtlSumCompWork(System.IO.BinaryWriter writer, MTtlSumCompWork temp)
        {
            //作成日時
            writer.Write((Int64)temp.CreateDateTime.Ticks);
            //更新日時
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
            //論理削除区分
            writer.Write(temp.LogicalDeleteCode);
            //企業コード
            writer.Write(temp.EnterpriseCode);
            //対象パッケージ
            writer.Write(temp.PackageName);
            //集計モード
            writer.Write(temp.SummarizeMode);
            //集計対象年月日（開始）
            writer.Write((Int64)temp.SummarizeStaYeMon.Ticks);
            //集計対象年月日（終了）
            writer.Write((Int64)temp.SummarizeEndYeMon.Ticks);
            //計上年月
            writer.Write((Int64)temp.AddUpYearMonth.Ticks);
            //スケジュール日時
            writer.Write((Int64)temp.ScheduleDateTime.Ticks);
            //集計完了日
            writer.Write((Int64)temp.IsSummarized.Ticks);
            //DWH集計完了日
            writer.Write((Int64)temp.IsDwhSummarized.Ticks);

        }

        /// <summary>
        ///  MTtlSumCompWorkインスタンス取得
        /// </summary>
        /// <returns>MTtlSumCompWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   MTtlSumCompWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private MTtlSumCompWork GetMTtlSumCompWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            MTtlSumCompWork temp = new MTtlSumCompWork();

            //作成日時
            temp.CreateDateTime = new DateTime(reader.ReadInt64());
            //更新日時
            temp.UpdateDateTime = new DateTime(reader.ReadInt64());
            //論理削除区分
            temp.LogicalDeleteCode = reader.ReadInt32();
            //企業コード
            temp.EnterpriseCode = reader.ReadString();
            //対象パッケージ
            temp.PackageName = reader.ReadString();
            //集計モード
            temp.SummarizeMode = reader.ReadInt32();
            //集計対象年月日（開始）
            temp.SummarizeStaYeMon = new DateTime(reader.ReadInt64());
            //集計対象年月日（終了）
            temp.SummarizeEndYeMon = new DateTime(reader.ReadInt64());
            //計上年月
            temp.AddUpYearMonth = new DateTime(reader.ReadInt64());
            //スケジュール日時
            temp.ScheduleDateTime = new DateTime(reader.ReadInt64());
            //集計完了日
            temp.IsSummarized = new DateTime(reader.ReadInt64());
            //DWH集計完了日
            temp.IsDwhSummarized = new DateTime(reader.ReadInt64());


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
        /// <returns>MTtlSumCompWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   MTtlSumCompWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                MTtlSumCompWork temp = GetMTtlSumCompWork(reader, serInfo);
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
                    retValue = (MTtlSumCompWork[])lst.ToArray(typeof(MTtlSumCompWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}

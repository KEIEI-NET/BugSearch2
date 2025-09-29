using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   NoTypeMngWork
    /// <summary>
    ///                      番号タイプ管理ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   番号タイプ管理ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/3/19</br>
    /// <br>Genarated Date   :   2008/05/29  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class NoTypeMngWork : IFileHeader
    {
        /// <summary>作成日時</summary>
        /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        private DateTime _createDateTime;

        /// <summary>更新日時</summary>
        /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        private DateTime _updateDateTime;

        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>GUID</summary>
        /// <remarks>共通ファイルヘッダ</remarks>
        private Guid _fileHeaderGuid;

        /// <summary>更新従業員コード</summary>
        /// <remarks>共通ファイルヘッダ</remarks>
        private string _updEmployeeCode = "";

        /// <summary>更新アセンブリID1</summary>
        /// <remarks>共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）</remarks>
        private string _updAssemblyId1 = "";

        /// <summary>更新アセンブリID2</summary>
        /// <remarks>共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）</remarks>
        private string _updAssemblyId2 = "";

        /// <summary>論理削除区分</summary>
        /// <remarks>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>番号コード</summary>
        /// <remarks>1:顧客ｺｰﾄﾞ,2:車両管理番号,･･･つづきあり(項目詳細)</remarks>
        private Int32 _noCode;

        /// <summary>番号名称</summary>
        private string _noName = "";

        /// <summary>番号項目型</summary>
        /// <remarks>0:数値 1:文字</remarks>
        private Int32 _noItemPatternCd;

        /// <summary>番号桁数</summary>
        private Int32 _noCharcterCount;

        /// <summary>番号連番桁数</summary>
        private Int32 _consNoCharcterCount;

        /// <summary>番号表示位置区分</summary>
        /// <remarks>0:右詰め 1:左詰め</remarks>
        private Int32 _noDispPositionDivCd;

        /// <summary>番号採番区分</summary>
        /// <remarks>0:採番無し 1:採番有り</remarks>
        private Int32 _numberingDivCd;

        /// <summary>番号採番タイプ</summary>
        /// <remarks>0:連番 1:番号管理用拠点コード2桁+Y1桁+M1桁+連番(残り桁数)</remarks>
        private Int32 _numberingTypeDivCd;

        /// <summary>番号採番範囲</summary>
        /// <remarks>0:企業通番(拠点括り無し) 1:企業通番(拠点括り有り) 2:拠点通番</remarks>
        private Int32 _numberingAmbitDivCd;

        /// <summary>番号リセットタイミング</summary>
        /// <remarks>0:設定終了番号 1:年 2:月 3:日</remarks>
        private Int32 _noResetTimingDivCd;


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

        /// public propaty name  :  FileHeaderGuid
        /// <summary>GUIDプロパティ</summary>
        /// <value>共通ファイルヘッダ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   GUIDプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Guid FileHeaderGuid
        {
            get { return _fileHeaderGuid; }
            set { _fileHeaderGuid = value; }
        }

        /// public propaty name  :  UpdEmployeeCode
        /// <summary>更新従業員コードプロパティ</summary>
        /// <value>共通ファイルヘッダ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdEmployeeCode
        {
            get { return _updEmployeeCode; }
            set { _updEmployeeCode = value; }
        }

        /// public propaty name  :  UpdAssemblyId1
        /// <summary>更新アセンブリID1プロパティ</summary>
        /// <value>共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新アセンブリID1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdAssemblyId1
        {
            get { return _updAssemblyId1; }
            set { _updAssemblyId1 = value; }
        }

        /// public propaty name  :  UpdAssemblyId2
        /// <summary>更新アセンブリID2プロパティ</summary>
        /// <value>共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新アセンブリID2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UpdAssemblyId2
        {
            get { return _updAssemblyId2; }
            set { _updAssemblyId2 = value; }
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

        /// public propaty name  :  NoCode
        /// <summary>番号コードプロパティ</summary>
        /// <value>1:顧客ｺｰﾄﾞ,2:車両管理番号,･･･つづきあり(項目詳細)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   番号コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 NoCode
        {
            get { return _noCode; }
            set { _noCode = value; }
        }

        /// public propaty name  :  NoName
        /// <summary>番号名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   番号名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string NoName
        {
            get { return _noName; }
            set { _noName = value; }
        }

        /// public propaty name  :  NoItemPatternCd
        /// <summary>番号項目型プロパティ</summary>
        /// <value>0:数値 1:文字</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   番号項目型プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 NoItemPatternCd
        {
            get { return _noItemPatternCd; }
            set { _noItemPatternCd = value; }
        }

        /// public propaty name  :  NoCharcterCount
        /// <summary>番号桁数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   番号桁数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 NoCharcterCount
        {
            get { return _noCharcterCount; }
            set { _noCharcterCount = value; }
        }

        /// public propaty name  :  ConsNoCharcterCount
        /// <summary>番号連番桁数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   番号連番桁数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ConsNoCharcterCount
        {
            get { return _consNoCharcterCount; }
            set { _consNoCharcterCount = value; }
        }

        /// public propaty name  :  NoDispPositionDivCd
        /// <summary>番号表示位置区分プロパティ</summary>
        /// <value>0:右詰め 1:左詰め</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   番号表示位置区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 NoDispPositionDivCd
        {
            get { return _noDispPositionDivCd; }
            set { _noDispPositionDivCd = value; }
        }

        /// public propaty name  :  NumberingDivCd
        /// <summary>番号採番区分プロパティ</summary>
        /// <value>0:採番無し 1:採番有り</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   番号採番区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 NumberingDivCd
        {
            get { return _numberingDivCd; }
            set { _numberingDivCd = value; }
        }

        /// public propaty name  :  NumberingTypeDivCd
        /// <summary>番号採番タイププロパティ</summary>
        /// <value>0:連番 1:番号管理用拠点コード2桁+Y1桁+M1桁+連番(残り桁数)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   番号採番タイププロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 NumberingTypeDivCd
        {
            get { return _numberingTypeDivCd; }
            set { _numberingTypeDivCd = value; }
        }

        /// public propaty name  :  NumberingAmbitDivCd
        /// <summary>番号採番範囲プロパティ</summary>
        /// <value>0:企業通番(拠点括り無し) 1:企業通番(拠点括り有り) 2:拠点通番</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   番号採番範囲プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 NumberingAmbitDivCd
        {
            get { return _numberingAmbitDivCd; }
            set { _numberingAmbitDivCd = value; }
        }

        /// public propaty name  :  NoResetTimingDivCd
        /// <summary>番号リセットタイミングプロパティ</summary>
        /// <value>0:設定終了番号 1:年 2:月 3:日</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   番号リセットタイミングプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 NoResetTimingDivCd
        {
            get { return _noResetTimingDivCd; }
            set { _noResetTimingDivCd = value; }
        }


        /// <summary>
        /// 番号タイプ管理ワークコンストラクタ
        /// </summary>
        /// <returns>NoTypeMngWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   NoTypeMngWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public NoTypeMngWork()
        {
        }

    }
    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>NoTypeMngWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   NoTypeMngWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class NoTypeMngWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   NoTypeMngWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  NoTypeMngWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is NoTypeMngWork || graph is ArrayList || graph is NoTypeMngWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(NoTypeMngWork).FullName));

            if (graph != null && graph is NoTypeMngWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.NoTypeMngWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is NoTypeMngWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((NoTypeMngWork[])graph).Length;
            }
            else if (graph is NoTypeMngWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //作成日時
            serInfo.MemberInfo.Add(typeof(Int64)); //CreateDateTime
            //更新日時
            serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTime
            //企業コード
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //GUID
            serInfo.MemberInfo.Add(typeof(byte[]));  //FileHeaderGuid
            //更新従業員コード
            serInfo.MemberInfo.Add(typeof(string)); //UpdEmployeeCode
            //更新アセンブリID1
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId1
            //更新アセンブリID2
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId2
            //論理削除区分
            serInfo.MemberInfo.Add(typeof(Int32)); //LogicalDeleteCode
            //番号コード
            serInfo.MemberInfo.Add(typeof(Int32)); //NoCode
            //番号名称
            serInfo.MemberInfo.Add(typeof(string)); //NoName
            //番号項目型
            serInfo.MemberInfo.Add(typeof(Int32)); //NoItemPatternCd
            //番号桁数
            serInfo.MemberInfo.Add(typeof(Int32)); //NoCharcterCount
            //番号連番桁数
            serInfo.MemberInfo.Add(typeof(Int32)); //ConsNoCharcterCount
            //番号表示位置区分
            serInfo.MemberInfo.Add(typeof(Int32)); //NoDispPositionDivCd
            //番号採番区分
            serInfo.MemberInfo.Add(typeof(Int32)); //NumberingDivCd
            //番号採番タイプ
            serInfo.MemberInfo.Add(typeof(Int32)); //NumberingTypeDivCd
            //番号採番範囲
            serInfo.MemberInfo.Add(typeof(Int32)); //NumberingAmbitDivCd
            //番号リセットタイミング
            serInfo.MemberInfo.Add(typeof(Int32)); //NoResetTimingDivCd


            serInfo.Serialize(writer, serInfo);
            if (graph is NoTypeMngWork)
            {
                NoTypeMngWork temp = (NoTypeMngWork)graph;

                SetNoTypeMngWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is NoTypeMngWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((NoTypeMngWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (NoTypeMngWork temp in lst)
                {
                    SetNoTypeMngWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// NoTypeMngWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 18;

        /// <summary>
        ///  NoTypeMngWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   NoTypeMngWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetNoTypeMngWork(System.IO.BinaryWriter writer, NoTypeMngWork temp)
        {
            //作成日時
            writer.Write((Int64)temp.CreateDateTime.Ticks);
            //更新日時
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
            //企業コード
            writer.Write(temp.EnterpriseCode);
            //GUID
            byte[] fileHeaderGuidArray = temp.FileHeaderGuid.ToByteArray();
            writer.Write(fileHeaderGuidArray.Length);
            writer.Write(temp.FileHeaderGuid.ToByteArray());
            //更新従業員コード
            writer.Write(temp.UpdEmployeeCode);
            //更新アセンブリID1
            writer.Write(temp.UpdAssemblyId1);
            //更新アセンブリID2
            writer.Write(temp.UpdAssemblyId2);
            //論理削除区分
            writer.Write(temp.LogicalDeleteCode);
            //番号コード
            writer.Write(temp.NoCode);
            //番号名称
            writer.Write(temp.NoName);
            //番号項目型
            writer.Write(temp.NoItemPatternCd);
            //番号桁数
            writer.Write(temp.NoCharcterCount);
            //番号連番桁数
            writer.Write(temp.ConsNoCharcterCount);
            //番号表示位置区分
            writer.Write(temp.NoDispPositionDivCd);
            //番号採番区分
            writer.Write(temp.NumberingDivCd);
            //番号採番タイプ
            writer.Write(temp.NumberingTypeDivCd);
            //番号採番範囲
            writer.Write(temp.NumberingAmbitDivCd);
            //番号リセットタイミング
            writer.Write(temp.NoResetTimingDivCd);

        }

        /// <summary>
        ///  NoTypeMngWorkインスタンス取得
        /// </summary>
        /// <returns>NoTypeMngWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   NoTypeMngWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private NoTypeMngWork GetNoTypeMngWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            NoTypeMngWork temp = new NoTypeMngWork();

            //作成日時
            temp.CreateDateTime = new DateTime(reader.ReadInt64());
            //更新日時
            temp.UpdateDateTime = new DateTime(reader.ReadInt64());
            //企業コード
            temp.EnterpriseCode = reader.ReadString();
            //GUID
            int lenOfFileHeaderGuidArray = reader.ReadInt32();
            byte[] fileHeaderGuidArray = reader.ReadBytes(lenOfFileHeaderGuidArray);
            temp.FileHeaderGuid = new Guid(fileHeaderGuidArray);
            //更新従業員コード
            temp.UpdEmployeeCode = reader.ReadString();
            //更新アセンブリID1
            temp.UpdAssemblyId1 = reader.ReadString();
            //更新アセンブリID2
            temp.UpdAssemblyId2 = reader.ReadString();
            //論理削除区分
            temp.LogicalDeleteCode = reader.ReadInt32();
            //番号コード
            temp.NoCode = reader.ReadInt32();
            //番号名称
            temp.NoName = reader.ReadString();
            //番号項目型
            temp.NoItemPatternCd = reader.ReadInt32();
            //番号桁数
            temp.NoCharcterCount = reader.ReadInt32();
            //番号連番桁数
            temp.ConsNoCharcterCount = reader.ReadInt32();
            //番号表示位置区分
            temp.NoDispPositionDivCd = reader.ReadInt32();
            //番号採番区分
            temp.NumberingDivCd = reader.ReadInt32();
            //番号採番タイプ
            temp.NumberingTypeDivCd = reader.ReadInt32();
            //番号採番範囲
            temp.NumberingAmbitDivCd = reader.ReadInt32();
            //番号リセットタイミング
            temp.NoResetTimingDivCd = reader.ReadInt32();


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
        /// <returns>NoTypeMngWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   NoTypeMngWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                NoTypeMngWork temp = GetNoTypeMngWork(reader, serInfo);
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
                    retValue = (NoTypeMngWork[])lst.ToArray(typeof(NoTypeMngWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}

using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   MenueStWork
    /// <summary>
    ///                      メニュー制御設定印刷ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   メニュー制御設定印刷ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2013/02/07</br>
    /// <br>Genarated Date   :   2013/02/07  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class MenueStWork
    {

        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>ロールグループコード</summary>
        private Int32 _roleGroupCode;

        /// <summary>ロールグループ名称</summary>
        private string _roleGroupName = "";

        /// <summary>カテゴリ</summary>
        private Int32 _roleCategoryId;

        /// <summary>サブカテゴリ</summary>
        private Int32 _roleCategorySubId;

        /// <summary>アイテム</summary>
        private Int32 _roleItemId;

        /// <summary>システム機能名称</summary>
        private string _systemName = "";

        /// <summary>従業員コード</summary>
        private string _employeeCode = "";

        /// <summary>従業員名称</summary>
        private string _employeeName = "";

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

        /// public propaty name  :  RoleGroupCode
        /// <summary>ロールグループコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ロールグループコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 RoleGroupCode
        {
            get { return _roleGroupCode; }
            set { _roleGroupCode = value; }
        }

        /// public propaty name  :  RoleGroupName
        /// <summary>ロールグループ名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ロールグループ名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string RoleGroupName
        {
            get { return _roleGroupName; }
            set { _roleGroupName = value; }
        }

        /// public propaty name  :  RoleCategoryId
        /// <summary>カテゴリプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   カテゴリプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 RoleCategoryId
        {
            get { return _roleCategoryId; }
            set { _roleCategoryId = value; }
        }

        /// public propaty name  :  RoleCategorySubId
        /// <summary>サブカテゴリプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   サブカテゴリプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 RoleCategorySubId
        {
            get { return _roleCategorySubId; }
            set { _roleCategorySubId = value; }
        }

        /// public propaty name  :  RoleItemId
        /// <summary>アイテムプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   アイテムプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 RoleItemId
        {
            get { return _roleItemId; }
            set { _roleItemId = value; }
        }

        /// public propaty name  :  SystemName
        /// <summary>システム機能名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   システム機能名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SystemName
        {
            get { return _systemName; }
            set { _systemName = value; }
        }

        /// public propaty name  :  EmployeeCode
        /// <summary>従業員コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EmployeeCode
        {
            get { return _employeeCode; }
            set { _employeeCode = value; }
        }

        /// public propaty name  :  EmployeeName
        /// <summary>従業員名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   従業員名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EmployeeName
        {
            get { return _employeeName; }
            set { _employeeName = value; }
        }

        /// <summary>
        /// メニュー制御設定印刷ワークコンストラクタ
        /// </summary>
        /// <returns>MenueStWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note             :   MenueStWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public MenueStWork()
        {
        }

    }


    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>MenueStWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note             :   MenueStWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class MenueStWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note             :   MenueStWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  MenueStWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is MenueStWork || graph is ArrayList || graph is MenueStWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(MenueStWork).FullName));

            if (graph != null && graph is MenueStWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.MenueStWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is MenueStWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((MenueStWork[])graph).Length;
            }
            else if (graph is MenueStWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;        //繰り返し数

            //企業コード
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //ロールグループコード
            serInfo.MemberInfo.Add(typeof(Int32));  //RoleGroupCode
            //ロールグループ名称
            serInfo.MemberInfo.Add(typeof(string)); //RoleGroupName
            //カテゴリ
            serInfo.MemberInfo.Add(typeof(Int32));  //RoleCategoryId
            //サブカテゴリ
            serInfo.MemberInfo.Add(typeof(Int32));  //RoleCategorySubId
            //アイテム
            serInfo.MemberInfo.Add(typeof(Int32));  //RoleItemId
            //システム機能名称
            serInfo.MemberInfo.Add(typeof(string)); //SystemName
            //従業員コード
            serInfo.MemberInfo.Add(typeof(string)); //EmployeeCode
            //従業員名称
            serInfo.MemberInfo.Add(typeof(string)); //EmployeeName

            serInfo.Serialize(writer, serInfo);
            if (graph is MenueStWork)
            {
                MenueStWork temp = (MenueStWork)graph;

                SetMenueStWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is MenueStWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((MenueStWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (MenueStWork temp in lst)
                {
                    SetMenueStWork(writer, temp);
                }

            }

        }


        /// <summary>
        /// MenueStWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 9;

        /// <summary>
        ///  MenueStWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note             :   MenueStWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetMenueStWork(System.IO.BinaryWriter writer, MenueStWork temp)
        {
            //企業コード
            writer.Write(temp.EnterpriseCode);
            //ロールグループコード
            writer.Write(temp.RoleGroupCode);
            //ロールグループ名称
            writer.Write(temp.RoleGroupName);
            //カテゴリ
            writer.Write(temp.RoleCategoryId);
            //サブカテゴリ
            writer.Write(temp.RoleCategorySubId);
            //アイテム
            writer.Write(temp.RoleItemId);
            //システム機能名称
            writer.Write(temp.SystemName);
            //従業員コード
            writer.Write(temp.EmployeeCode);
            //従業員名称
            writer.Write(temp.EmployeeName);
        }

        /// <summary>
        ///  MenueStWorkインスタンス取得
        /// </summary>
        /// <returns>MenueStWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note             :   MenueStWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private MenueStWork GetMenueStWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            MenueStWork temp = new MenueStWork();

            //企業コード
            temp.EnterpriseCode = reader.ReadString();
            //ロールグループコード
            temp.RoleGroupCode = reader.ReadInt32();
            //ロールグループ名称
            temp.RoleGroupName = reader.ReadString();
            //カテゴリ
            temp.RoleCategoryId = reader.ReadInt32();
            //サブカテゴリ
            temp.RoleCategorySubId = reader.ReadInt32();
            //アイテム
            temp.RoleItemId = reader.ReadInt32();
            //システム機能名称
            temp.SystemName = reader.ReadString();
            //従業員コード
            temp.EmployeeCode = reader.ReadString();
            //従業員名称
            temp.EmployeeName = reader.ReadString();

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
        /// <returns>MenueStWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note             :   MenueStWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                MenueStWork temp = GetMenueStWork(reader, serInfo);
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
                    retValue = (MenueStWork[])lst.ToArray(typeof(MenueStWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}

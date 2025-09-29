//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : ハンディターミナルログイン情報ワーク
// プログラム概要   : ハンディターミナルログイン情報ワークです
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11370006-00 作成担当 : 朱宝軍
// 作 成 日  2017/06/05  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  11370074-00 作成担当 : 譚洪
// 作 成 日  2017/08/11  修正内容 : ハンディターミナル二次開発の対応
//----------------------------------------------------------------------------//
// 管理番号  11570249-00 作成担当 : 岸
// 作 成 日  2020/04/08  修正内容 : ハンディ仕入れ時在庫登録対応
//----------------------------------------------------------------------------//

using System;
using System.Collections;

using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   HandyLoginInfoWork
	/// <summary>
    ///                      ハンディターミナルログイン情報ワーク
	/// </summary>
	/// <remarks>
    /// <br>note             :   ハンディターミナルログイン情報ワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2017/06/05</br>
	/// <br>Genarated Date   :   2017/06/05  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   譚洪</br>
    /// <br>Date             :   2017/08/11</br>
    /// <br>管理番号         :   11370074-00</br>
    /// <br>                 :   ハンディターミナル二次開発の対応（ハンディOP(仕入)、ハンディOP(社内)、仕入支払管理、ロール(循環棚卸)項目の追加）</br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class HandyLoginInfoWork
	{
		/// <summary>従業員コード</summary>
		private string _employeeCode = "";

		/// <summary>名称</summary>
		private string _name = "";

		/// <summary>所属拠点コード</summary>
		private string _belongSectionCode = "";

		/// <summary>所属拠点名</summary>
		private string _belongSectionName = "";

        /// <summary>拠点倉庫コード１</summary>
        private string _sectWarehouseCd1 = "";

		/// <summary>退職日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private Int32 _retirementDate;

		/// <summary>入社日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private Int32 _enterCompanyDate;

		/// <summary>権限レベル1</summary>
		/// <remarks>80:店長 70:店頭販売員(正社員) 60:店頭販売員(アルバイト) 40:バックヤード担当者 20:事務</remarks>
		private Int32 _authorityLevel1;

		/// <summary>権限レベル2</summary>
		/// <remarks>50:正社員 10:アルバイト</remarks>
		private Int32 _authorityLevel2;

        /// <summary>ハンディOP(仕入)</summary>
        /// <remarks>0:OFF(使用不可) 1:ON(使用可)</remarks>
        private Int32 _handySupOp;

        /// <summary>ハンディOP(社内)</summary>
        /// <remarks>0:OFF(使用不可) 1:ON(使用可)</remarks>
        private Int32 _handyHouOp;

        /// <summary>仕入支払管理</summary>
        /// <remarks>0:OFF(使用不可) 1:ON(使用可)</remarks>
        private Int32 _supPayManageOp;

        /// <summary>ロール(循環棚卸)</summary>
        /// <remarks>0:OFF(使用不可) 1:ON(使用可)</remarks>
        private Int32 _cycleCountRoll;

        // --- ADD 2020/04/08 ---------->>>>>
        /// <summary>ハンディ在庫登録オプション</summary>
        /// <remarks>0:OFF(使用不可) 1:ON(使用可)</remarks>
        private Int32 _handyZaikoRegistOp;
        // --- ADD 2020/04/08 ----------<<<<<

		/// public propaty name  :  EmployeeCode
		/// <summary>従業員コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   従業員コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EmployeeCode
		{
			get{return _employeeCode;}
			set{_employeeCode = value;}
		}

		/// public propaty name  :  Name
		/// <summary>名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Name
		{
			get{return _name;}
			set{_name = value;}
		}

		/// public propaty name  :  BelongSectionCode
		/// <summary>所属拠点コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   所属拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string BelongSectionCode
		{
			get{return _belongSectionCode;}
			set{_belongSectionCode = value;}
		}

		/// public propaty name  :  BelongSectionName
		/// <summary>所属拠点名プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   所属拠点名プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string BelongSectionName
		{
			get{return _belongSectionName;}
			set{_belongSectionName = value;}
		}

        /// public propaty name  :  SectWarehouseCd1
        /// <summary>拠点倉庫コード１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点倉庫コード１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectWarehouseCd1
        {
            get { return _sectWarehouseCd1; }
            set { _sectWarehouseCd1 = value; }
        }

		/// public propaty name  :  RetirementDate
		/// <summary>退職日プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   退職日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 RetirementDate
		{
			get{return _retirementDate;}
			set{_retirementDate = value;}
		}

		/// public propaty name  :  EnterCompanyDate
		/// <summary>入社日プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入社日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EnterCompanyDate
		{
			get{return _enterCompanyDate;}
			set{_enterCompanyDate = value;}
		}

		/// public propaty name  :  AuthorityLevel1
		/// <summary>権限レベル1プロパティ</summary>
		/// <value>80:店長 70:店頭販売員(正社員) 60:店頭販売員(アルバイト) 40:バックヤード担当者 20:事務</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   権限レベル1プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AuthorityLevel1
		{
			get{return _authorityLevel1;}
			set{_authorityLevel1 = value;}
		}

		/// public propaty name  :  AuthorityLevel2
		/// <summary>権限レベル2プロパティ</summary>
		/// <value>50:正社員 10:アルバイト</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   権限レベル2プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AuthorityLevel2
		{
			get{return _authorityLevel2;}
			set{_authorityLevel2 = value;}
		}

        /// public propaty name  :  HandySupOp
        /// <summary>ハンディOP(仕入)プロパティ</summary>
        /// <value>0:OFF(使用不可) 1:ON(使用可)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ハンディOP(仕入)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HandySupOp
        {
            get { return _handySupOp; }
            set { _handySupOp = value; }
        }

        /// public propaty name  :  HandyHouOp
        /// <summary>ハンディOP(社内)プロパティ</summary>
        /// <value>0:OFF(使用不可) 1:ON(使用可)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ハンディOP(社内)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HandyHouOp
        {
            get { return _handyHouOp; }
            set { _handyHouOp = value; }
        }

        /// public propaty name  :  SupPayManageOp
        /// <summary>仕入支払管理プロパティ</summary>
        /// <value>0:OFF(使用不可) 1:ON(使用可)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入支払管理プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SupPayManageOp
        {
            get { return _supPayManageOp; }
            set { _supPayManageOp = value; }
        }

        /// public propaty name  :  CycleCountRoll
        /// <summary>ロール(循環棚卸)プロパティ</summary>
        /// <value>0:OFF(使用不可) 1:ON(使用可)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ロール(循環棚卸)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CycleCountRoll
        {
            get { return _cycleCountRoll; }
            set { _cycleCountRoll = value; }
        }

        // --- ADD 2020/04/08 ---------->>>>>
        /// public propaty name  :  HandyZaikoRegistOp
        /// <summary>ハンディ在庫登録オプションプロパティ</summary>
        /// <value>0:OFF(使用不可) 1:ON(使用可)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ハンディ在庫登録オプションプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 HandyZaikoRegistOp
        {
            get { return _handyZaikoRegistOp; }
            set { _handyZaikoRegistOp = value; }

        }
        // --- ADD 2020/04/08 ----------<<<<<

		/// <summary>
        /// ハンディターミナルログイン情報ワークコンストラクタ
		/// </summary>
		/// <returns>HandyLoginInfoWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   HandyLoginInfoWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public HandyLoginInfoWork()
		{
		}

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシリアライザです。
    /// </summary>
    /// <returns>HandyLoginInfoWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   HandyLoginInfoWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class HandyLoginInfoWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   HandyLoginInfoWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  HandyLoginInfoWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is HandyLoginInfoWork || graph is ArrayList || graph is HandyLoginInfoWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(HandyLoginInfoWork).FullName));

            if (graph != null && graph is HandyLoginInfoWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.HandyLoginInfoWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is HandyLoginInfoWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((HandyLoginInfoWork[])graph).Length;
            }
            else if (graph is HandyLoginInfoWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //従業員コード
            serInfo.MemberInfo.Add(typeof(string)); //EmployeeCode
            //名称
            serInfo.MemberInfo.Add(typeof(string)); //Name
            //所属拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //BelongSectionCode
            //所属拠点名
            serInfo.MemberInfo.Add(typeof(string)); //BelongSectionName
            //拠点倉庫コード１
            serInfo.MemberInfo.Add(typeof(string)); //SectWarehouseCd1
            //退職日
            serInfo.MemberInfo.Add(typeof(Int32)); //RetirementDate
            //入社日
            serInfo.MemberInfo.Add(typeof(Int32)); //EnterCompanyDate
            //権限レベル1
            serInfo.MemberInfo.Add(typeof(Int32)); //AuthorityLevel1
            //権限レベル2
            serInfo.MemberInfo.Add(typeof(Int32)); //AuthorityLevel2
            //ハンディOP(仕入)
            serInfo.MemberInfo.Add(typeof(Int32)); //HandySupOp
            //ハンディOP(社内)
            serInfo.MemberInfo.Add(typeof(Int32)); //HandyHouOp
            //仕入支払管理
            serInfo.MemberInfo.Add(typeof(Int32)); //SupPayManageOp
            //ロール(循環棚卸)
            serInfo.MemberInfo.Add(typeof(Int32)); //CycleCountRoll
            // --- ADD 2020/04/08 ---------->>>>>
            //ハンディOP（在庫登録）
            serInfo.MemberInfo.Add(typeof(Int32)); //CycleCountRoll
            // --- ADD 2020/04/08 ----------<<<<<


            serInfo.Serialize(writer, serInfo);
            if (graph is HandyLoginInfoWork)
            {
                HandyLoginInfoWork temp = (HandyLoginInfoWork)graph;

                SetHandyLoginInfoWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is HandyLoginInfoWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((HandyLoginInfoWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (HandyLoginInfoWork temp in lst)
                {
                    SetHandyLoginInfoWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// HandyLoginInfoWorkメンバ数(publicプロパティ数)
        /// </summary>
        // --- ADD 2020/04/08 ---------->>>>>
        //private const int currentMemberCount = 13;
        private const int currentMemberCount = 14;
        // --- ADD 2020/04/08 ----------<<<<<

        /// <summary>
        ///  HandyLoginInfoWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   HandyLoginInfoWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetHandyLoginInfoWork(System.IO.BinaryWriter writer, HandyLoginInfoWork temp)
        {
            //従業員コード
            writer.Write(temp.EmployeeCode);
            //名称
            writer.Write(temp.Name);
            //所属拠点コード
            writer.Write(temp.BelongSectionCode);
            //所属拠点名
            writer.Write(temp.BelongSectionName);
            //拠点倉庫コード１
            writer.Write(temp.SectWarehouseCd1);
            //退職日
            writer.Write(temp.RetirementDate);
            //入社日
            writer.Write(temp.EnterCompanyDate);
            //権限レベル1
            writer.Write(temp.AuthorityLevel1);
            //権限レベル2
            writer.Write(temp.AuthorityLevel2);
            //ハンディOP(仕入)
            writer.Write(temp.HandySupOp);
            //ハンディOP(社内)
            writer.Write(temp.HandyHouOp);
            //仕入支払管理
            writer.Write(temp.SupPayManageOp);
            //ロール(循環棚卸)
            writer.Write(temp.CycleCountRoll);
            // --- ADD 2020/04/08 ---------->>>>>
            //ロール(循環棚卸)
            writer.Write(temp.HandyZaikoRegistOp);
            // --- ADD 2020/04/08 ----------<<<<<
        }

        /// <summary>
        ///  HandyLoginInfoWorkインスタンス取得
        /// </summary>
        /// <returns>HandyLoginInfoWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   HandyLoginInfoWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private HandyLoginInfoWork GetHandyLoginInfoWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            HandyLoginInfoWork temp = new HandyLoginInfoWork();

            //従業員コード
            temp.EmployeeCode = reader.ReadString();
            //名称
            temp.Name = reader.ReadString();
            //所属拠点コード
            temp.BelongSectionCode = reader.ReadString();
            //所属拠点名
            temp.BelongSectionName = reader.ReadString();
            //拠点倉庫コード１
            temp.SectWarehouseCd1 = reader.ReadString();
            //退職日
            temp.RetirementDate = reader.ReadInt32();
            //入社日
            temp.EnterCompanyDate = reader.ReadInt32();
            //権限レベル1
            temp.AuthorityLevel1 = reader.ReadInt32();
            //権限レベル2
            temp.AuthorityLevel2 = reader.ReadInt32();
            //ハンディOP(仕入)
            temp.HandySupOp = reader.ReadInt32();
            //ハンディOP(社内)
            temp.HandyHouOp = reader.ReadInt32();
            //仕入支払管理
            temp.SupPayManageOp = reader.ReadInt32();
            //ロール(循環棚卸)
            temp.CycleCountRoll = reader.ReadInt32();
            // --- ADD 2020/04/08 ---------->>>>>
            //ハンディOP（在庫登録）
            temp.HandyZaikoRegistOp = reader.ReadInt32();
            // --- ADD 2020/04/08 ----------<<<<<


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
        /// <returns>HandyLoginInfoWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   HandyLoginInfoWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                HandyLoginInfoWork temp = GetHandyLoginInfoWork(reader, serInfo);
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
                    retValue = (HandyLoginInfoWork[])lst.ToArray(typeof(HandyLoginInfoWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}

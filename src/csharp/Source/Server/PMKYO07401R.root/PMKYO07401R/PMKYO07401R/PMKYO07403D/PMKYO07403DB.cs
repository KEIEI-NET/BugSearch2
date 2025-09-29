//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : データ受信処理
// プログラム概要   : データセンターに対して追加・更新処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張莉莉
// 作 成 日  2011/07/21  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   ERInfoDataWork
	/// <summary>
	///                      エラー情報ワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   エラー情報ワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2011/07/29  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class ERInfoDataWork
	{
		/// <summary>伝票</summary>
		private string _erSlipNm = "";

		/// <summary>伝票番号</summary>
		private string _erSalesSlipNum = "";

		/// <summary>日付</summary>
		private Int32 _erDateTime;

		/// <summary>拠点コード</summary>
		private string _erSectionCode = "";

		/// <summary>拠点名称</summary>
		private string _erSectionNm = "";

		/// <summary>得意先/仕入先コード</summary>
		private Int32 _erCustCode;

		/// <summary>得意先/仕入先名称</summary>
		private string _erCustName = "";

		/// <summary>エラー情報</summary>
		private string _erInfo = "";


		/// public propaty name  :  ErSlipNm
		/// <summary>伝票プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string ErSlipNm
		{
			get { return _erSlipNm; }
			set { _erSlipNm = value; }
		}

		/// public propaty name  :  ErSalesSlipNum
		/// <summary>伝票番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string ErSalesSlipNum
		{
			get { return _erSalesSlipNum; }
			set { _erSalesSlipNum = value; }
		}

		/// public propaty name  :  ErDateTime
		/// <summary>日付プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   日付プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ErDateTime
		{
			get { return _erDateTime; }
			set { _erDateTime = value; }
		}

		/// public propaty name  :  ErSectionCode
		/// <summary>拠点コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string ErSectionCode
		{
			get { return _erSectionCode; }
			set { _erSectionCode = value; }
		}

		/// public propaty name  :  ErSectionNm
		/// <summary>拠点名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   拠点名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string ErSectionNm
		{
			get { return _erSectionNm; }
			set { _erSectionNm = value; }
		}

		/// public propaty name  :  ErCustCode
		/// <summary>得意先/仕入先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   得意先/仕入先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ErCustCode
		{
			get { return _erCustCode; }
			set { _erCustCode = value; }
		}

		/// public propaty name  :  ErCustName
		/// <summary>得意先/仕入先名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   得意先/仕入先名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string ErCustName
		{
			get { return _erCustName; }
			set { _erCustName = value; }
		}

		/// public propaty name  :  ErInfo
		/// <summary>エラー情報プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   エラー情報プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string ErInfo
		{
			get { return _erInfo; }
			set { _erInfo = value; }
		}


		/// <summary>
		/// エラー情報ワークコンストラクタ
		/// </summary>
		/// <returns>ERInfoDataWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ERInfoDataWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ERInfoDataWork()
		{
		}

	}

	/// <summary>
	///  Ver5.10.1.0用のカスタムシライアライザです。
	/// </summary>
	/// <returns>ERInfoDataWorkクラスのインスタンス(object)</returns>
	/// <remarks>
	/// <br>Note　　　　　　 :   ERInfoDataWorkクラスのカスタムシリアライザを定義します</br>
	/// <br>Programer        :   自動生成</br>
	/// </remarks>
	public class ERInfoDataWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
	{
		#region ICustomSerializationSurrogate メンバ

		/// <summary>
		///  Ver5.10.1.0用のカスタムシリアライザです
		/// </summary>
		/// <remarks>
		/// <br>Note　　　　　　 :   ERInfoDataWorkクラスのカスタムシリアライザを定義します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public void Serialize(System.IO.BinaryWriter writer, object graph)
		{
			// TODO:  ERInfoDataWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
			if (writer == null)
				throw new ArgumentNullException();

			if (graph != null && !(graph is ERInfoDataWork || graph is ArrayList || graph is ERInfoDataWork[]))
				throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(ERInfoDataWork).FullName));

			if (graph != null && graph is ERInfoDataWork)
			{
				Type t = graph.GetType();
				if (!CustomFormatterServices.NeedCustomSerialization(t))
					throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
			}

			//SerializationTypeInfo
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.ERInfoDataWork");

			//繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
			int occurrence = 0;     //一般にゼロの場合もありえます
			if (graph is ArrayList)
			{
				serInfo.RetTypeInfo = 0;
				occurrence = ((ArrayList)graph).Count;
			}
			else if (graph is ERInfoDataWork[])
			{
				serInfo.RetTypeInfo = 2;
				occurrence = ((ERInfoDataWork[])graph).Length;
			}
			else if (graph is ERInfoDataWork)
			{
				serInfo.RetTypeInfo = 1;
				occurrence = 1;
			}

			serInfo.Occurrence = occurrence;		 //繰り返し数	

			//伝票
			serInfo.MemberInfo.Add(typeof(string)); //ErSlipNm
			//伝票番号
			serInfo.MemberInfo.Add(typeof(string)); //ErSalesSlipNum
			//日付
			serInfo.MemberInfo.Add(typeof(Int32)); //ErDateTime
			//拠点コード
			serInfo.MemberInfo.Add(typeof(string)); //ErSectionCode
			//拠点名称
			serInfo.MemberInfo.Add(typeof(string)); //ErSectionNm
			//得意先/仕入先コード
			serInfo.MemberInfo.Add(typeof(Int32)); //ErCustCode
			//得意先/仕入先名称
			serInfo.MemberInfo.Add(typeof(string)); //ErCustName
			//エラー情報
			serInfo.MemberInfo.Add(typeof(string)); //ErInfo


			serInfo.Serialize(writer, serInfo);
			if (graph is ERInfoDataWork)
			{
				ERInfoDataWork temp = (ERInfoDataWork)graph;

				SetERInfoDataWork(writer, temp);
			}
			else
			{
				ArrayList lst = null;
				if (graph is ERInfoDataWork[])
				{
					lst = new ArrayList();
					lst.AddRange((ERInfoDataWork[])graph);
				}
				else
				{
					lst = (ArrayList)graph;
				}

				foreach (ERInfoDataWork temp in lst)
				{
					SetERInfoDataWork(writer, temp);
				}

			}


		}


		/// <summary>
		/// ERInfoDataWorkメンバ数(publicプロパティ数)
		/// </summary>
		private const int currentMemberCount = 8;

		/// <summary>
		///  ERInfoDataWorkインスタンス書き込み
		/// </summary>
		/// <remarks>
		/// <br>Note　　　　　　 :   ERInfoDataWorkのインスタンスを書き込み</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		private void SetERInfoDataWork(System.IO.BinaryWriter writer, ERInfoDataWork temp)
		{
			//伝票
			writer.Write(temp.ErSlipNm);
			//伝票番号
			writer.Write(temp.ErSalesSlipNum);
			//日付
			writer.Write(temp.ErDateTime);
			//拠点コード
			writer.Write(temp.ErSectionCode);
			//拠点名称
			writer.Write(temp.ErSectionNm);
			//得意先/仕入先コード
			writer.Write(temp.ErCustCode);
			//得意先/仕入先名称
			writer.Write(temp.ErCustName);
			//エラー情報
			writer.Write(temp.ErInfo);

		}

		/// <summary>
		///  ERInfoDataWorkインスタンス取得
		/// </summary>
		/// <returns>ERInfoDataWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ERInfoDataWorkのインスタンスを取得します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		private ERInfoDataWork GetERInfoDataWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
		{
			// V5.1.0.0なので不要ですが、V5.1.0.1以降では
			// serInfo.MemberInfo.Count < currentMemberCount
			// のケースについての配慮が必要になります。

			ERInfoDataWork temp = new ERInfoDataWork();

			//伝票
			temp.ErSlipNm = reader.ReadString();
			//伝票番号
			temp.ErSalesSlipNum = reader.ReadString();
			//日付
			temp.ErDateTime = reader.ReadInt32();
			//拠点コード
			temp.ErSectionCode = reader.ReadString();
			//拠点名称
			temp.ErSectionNm = reader.ReadString();
			//得意先/仕入先コード
			temp.ErCustCode = reader.ReadInt32();
			//得意先/仕入先名称
			temp.ErCustName = reader.ReadString();
			//エラー情報
			temp.ErInfo = reader.ReadString();


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
		/// <returns>ERInfoDataWorkクラスのインスタンス(object)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ERInfoDataWorkクラスのカスタムデシリアライザを定義します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public object Deserialize(System.IO.BinaryReader reader)
		{
			object retValue = null;
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
			ArrayList lst = new ArrayList();
			for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
			{
				ERInfoDataWork temp = GetERInfoDataWork(reader, serInfo);
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
					retValue = (ERInfoDataWork[])lst.ToArray(typeof(ERInfoDataWork));
					break;
			}
			return retValue;
		}

		#endregion
	}


}


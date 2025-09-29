using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   CtgyMdlLnkRetWork
	/// <summary>
	///                      類別車両情報抽出結果クラスワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   類別車両情報抽出結果クラスワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2006/10/16</br>
	/// <br>Genarated Date   :   2007/03/16  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class CtgyMdlLnkRetWork
	{
		/// <summary>型式指定番号</summary>
		private Int32 _modelDesignationNo;

		/// <summary>類別番号</summary>
		private Int32 _categoryNo;

		/// <summary>車両固有番号</summary>
		/// <remarks>ユニークな固定番号</remarks>
		private Int32 _carProperNo;

		/// <summary>フル型式固定番号</summary>
		private Int32 _fullModelFixedNo;


		/// public propaty name  :  ModelDesignationNo
		/// <summary>型式指定番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   型式指定番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ModelDesignationNo
		{
			get { return _modelDesignationNo; }
			set { _modelDesignationNo = value; }
		}

		/// public propaty name  :  CategoryNo
		/// <summary>類別番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   類別番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CategoryNo
		{
			get { return _categoryNo; }
			set { _categoryNo = value; }
		}

		/// public propaty name  :  CarProperNo
		/// <summary>車両固有番号プロパティ</summary>
		/// <value>ユニークな固定番号</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   車両固有番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CarProperNo
		{
			get { return _carProperNo; }
			set { _carProperNo = value; }
		}

		/// public propaty name  :  FullModelFixedNo
		/// <summary>フル型式固定番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   フル型式固定番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 FullModelFixedNo
		{
			get { return _fullModelFixedNo; }
			set { _fullModelFixedNo = value; }
		}


		/// <summary>
		/// 類別車両情報抽出結果クラスワークコンストラクタ
		/// </summary>
		/// <returns>CtgyMdlLnkRetWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CtgyMdlLnkRetWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public CtgyMdlLnkRetWork()
		{
		}

	}

	/// <summary>
	///  Ver5.10.1.0用のカスタムシライアライザです。
	/// </summary>
	/// <returns>CtgyMdlLnkRetWorkクラスのインスタンス(object)</returns>
	/// <remarks>
	/// <br>Note　　　　　　 :   CtgyMdlLnkRetWorkクラスのカスタムシリアライザを定義します</br>
	/// <br>Programer        :   自動生成</br>
	/// </remarks>
	public class CtgyMdlLnkRetWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
	{
		#region ICustomSerializationSurrogate メンバ

		/// <summary>
		///  Ver5.10.1.0用のカスタムシリアライザです
		/// </summary>
		/// <remarks>
		/// <br>Note　　　　　　 :   CtgyMdlLnkRetWorkクラスのカスタムシリアライザを定義します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public void Serialize(System.IO.BinaryWriter writer, object graph)
		{
			// TODO:  CtgyMdlLnkRetWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
			if (writer == null)
				throw new ArgumentNullException();

			if (graph != null && !(graph is CtgyMdlLnkRetWork || graph is ArrayList || graph is CtgyMdlLnkRetWork[]))
				throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(CtgyMdlLnkRetWork).FullName));

			if (graph != null && graph is CtgyMdlLnkRetWork)
			{
				Type t = graph.GetType();
				if (!CustomFormatterServices.NeedCustomSerialization(t))
					throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
			}

			//SerializationTypeInfo
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.CtgyMdlLnkRetWork");

			//繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
			int occurrence = 0;     //一般にゼロの場合もありえます
			if (graph is ArrayList)
			{
				serInfo.RetTypeInfo = 0;
				occurrence = ((ArrayList)graph).Count;
			}
			else if (graph is CtgyMdlLnkRetWork[])
			{
				serInfo.RetTypeInfo = 2;
				occurrence = ((CtgyMdlLnkRetWork[])graph).Length;
			}
			else if (graph is CtgyMdlLnkRetWork)
			{
				serInfo.RetTypeInfo = 1;
				occurrence = 1;
			}

			serInfo.Occurrence = occurrence;		 //繰り返し数	

			//型式指定番号
			serInfo.MemberInfo.Add(typeof(Int32)); //ModelDesignationNo
			//類別番号
			serInfo.MemberInfo.Add(typeof(Int32)); //CategoryNo
			//車両固有番号
			serInfo.MemberInfo.Add(typeof(Int32)); //CarProperNo
			//フル型式固定番号
			serInfo.MemberInfo.Add(typeof(Int32)); //FullModelFixedNo


			serInfo.Serialize(writer, serInfo);
			if (graph is CtgyMdlLnkRetWork)
			{
				CtgyMdlLnkRetWork temp = (CtgyMdlLnkRetWork)graph;

				SetCtgyMdlLnkRetWork(writer, temp);
			}
			else
			{
				ArrayList lst = null;
				if (graph is CtgyMdlLnkRetWork[])
				{
					lst = new ArrayList();
					lst.AddRange((CtgyMdlLnkRetWork[])graph);
				}
				else
				{
					lst = (ArrayList)graph;
				}

				foreach (CtgyMdlLnkRetWork temp in lst)
				{
					SetCtgyMdlLnkRetWork(writer, temp);
				}

			}


		}


		/// <summary>
		/// CtgyMdlLnkRetWorkメンバ数(publicプロパティ数)
		/// </summary>
		private const int currentMemberCount = 4;

		/// <summary>
		///  CtgyMdlLnkRetWorkインスタンス書き込み
		/// </summary>
		/// <remarks>
		/// <br>Note　　　　　　 :   CtgyMdlLnkRetWorkのインスタンスを書き込み</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		private void SetCtgyMdlLnkRetWork(System.IO.BinaryWriter writer, CtgyMdlLnkRetWork temp)
		{
			//型式指定番号
			writer.Write(temp.ModelDesignationNo);
			//類別番号
			writer.Write(temp.CategoryNo);
			//車両固有番号
			writer.Write(temp.CarProperNo);
			//フル型式固定番号
			writer.Write(temp.FullModelFixedNo);

		}

		/// <summary>
		///  CtgyMdlLnkRetWorkインスタンス取得
		/// </summary>
		/// <returns>CtgyMdlLnkRetWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CtgyMdlLnkRetWorkのインスタンスを取得します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		private CtgyMdlLnkRetWork GetCtgyMdlLnkRetWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
		{
			// V5.1.0.0なので不要ですが、V5.1.0.1以降では
			// serInfo.MemberInfo.Count < currentMemberCount
			// のケースについての配慮が必要になります。

			CtgyMdlLnkRetWork temp = new CtgyMdlLnkRetWork();

			//型式指定番号
			temp.ModelDesignationNo = reader.ReadInt32();
			//類別番号
			temp.CategoryNo = reader.ReadInt32();
			//車両固有番号
			temp.CarProperNo = reader.ReadInt32();
			//フル型式固定番号
			temp.FullModelFixedNo = reader.ReadInt32();


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
		/// <returns>CtgyMdlLnkRetWorkクラスのインスタンス(object)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CtgyMdlLnkRetWorkクラスのカスタムデシリアライザを定義します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public object Deserialize(System.IO.BinaryReader reader)
		{
			object retValue = null;
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
			ArrayList lst = new ArrayList();
			for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
			{
				CtgyMdlLnkRetWork temp = GetCtgyMdlLnkRetWork(reader, serInfo);
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
					retValue = (CtgyMdlLnkRetWork[])lst.ToArray(typeof(CtgyMdlLnkRetWork));
					break;
			}
			return retValue;
		}

		#endregion
	}

}

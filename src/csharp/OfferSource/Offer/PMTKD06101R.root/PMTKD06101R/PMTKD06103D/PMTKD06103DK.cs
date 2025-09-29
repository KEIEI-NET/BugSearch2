using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   CEqpDefDspRetWork
	/// <summary>
	///                      装備抽出結果クラスワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   装備抽出結果クラスワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2006/10/16</br>
	/// <br>Genarated Date   :   2007/03/09  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class CEqpDefDspRetWork
	{
		/// <summary>メーカーコード</summary>
		/// <remarks>1～899:提供分, 900～ユーザー登録</remarks>
		private Int32 _makerCode;

		/// <summary>車種コード</summary>
		/// <remarks>車名コード(翼) 1～899:提供分, 900～ユーザー登録</remarks>
		private Int32 _modelCode;

		/// <summary>車種サブコード</summary>
		/// <remarks>0～899:提供分,900～ﾕｰｻﾞｰ登録</remarks>
		private Int32 _modelSubCode;

		/// <summary>系統コード</summary>
		private Int32 _systematicCode;

		/// <summary>装備表示順位</summary>
		private Int32 _equipmentDispOrder;

		/// <summary>装備分類コード</summary>
		private Int32 _equipmentGenreCd;

		/// <summary>装備分類名称</summary>
		private string _equipmentGenreNm = "";

		/// <summary>装備コード</summary>
		private Int32 _equipmentCode;

		/// <summary>装備名称</summary>
		private string _equipmentName = "";

		/// <summary>装備略称</summary>
		private string _equipmentShortName = "";

		/// <summary>装備ICONコード</summary>
		private Int32 _equipmentIconCode;


		/// public propaty name  :  MakerCode
		/// <summary>メーカーコードプロパティ</summary>
		/// <value>1～899:提供分, 900～ユーザー登録</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   メーカーコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 MakerCode
		{
			get { return _makerCode; }
			set { _makerCode = value; }
		}

		/// public propaty name  :  ModelCode
		/// <summary>車種コードプロパティ</summary>
		/// <value>車名コード(翼) 1～899:提供分, 900～ユーザー登録</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   車種コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ModelCode
		{
			get { return _modelCode; }
			set { _modelCode = value; }
		}

		/// public propaty name  :  ModelSubCode
		/// <summary>車種サブコードプロパティ</summary>
		/// <value>0～899:提供分,900～ﾕｰｻﾞｰ登録</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   車種サブコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ModelSubCode
		{
			get { return _modelSubCode; }
			set { _modelSubCode = value; }
		}

		/// public propaty name  :  SystematicCode
		/// <summary>系統コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   系統コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SystematicCode
		{
			get { return _systematicCode; }
			set { _systematicCode = value; }
		}

		/// public propaty name  :  EquipmentDispOrder
		/// <summary>装備表示順位プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   装備表示順位プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EquipmentDispOrder
		{
			get { return _equipmentDispOrder; }
			set { _equipmentDispOrder = value; }
		}

		/// public propaty name  :  EquipmentGenreCd
		/// <summary>装備分類コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   装備分類コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EquipmentGenreCd
		{
			get { return _equipmentGenreCd; }
			set { _equipmentGenreCd = value; }
		}

		/// public propaty name  :  EquipmentGenreNm
		/// <summary>装備分類名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   装備分類名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EquipmentGenreNm
		{
			get { return _equipmentGenreNm; }
			set { _equipmentGenreNm = value; }
		}

		/// public propaty name  :  EquipmentCode
		/// <summary>装備コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   装備コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EquipmentCode
		{
			get { return _equipmentCode; }
			set { _equipmentCode = value; }
		}

		/// public propaty name  :  EquipmentName
		/// <summary>装備名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   装備名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EquipmentName
		{
			get { return _equipmentName; }
			set { _equipmentName = value; }
		}

		/// public propaty name  :  EquipmentShortName
		/// <summary>装備略称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   装備略称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EquipmentShortName
		{
			get { return _equipmentShortName; }
			set { _equipmentShortName = value; }
		}

		/// public propaty name  :  EquipmentIconCode
		/// <summary>装備ICONコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   装備ICONコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EquipmentIconCode
		{
			get { return _equipmentIconCode; }
			set { _equipmentIconCode = value; }
		}


		/// <summary>
		/// 装備抽出結果クラスワークコンストラクタ
		/// </summary>
		/// <returns>CEqpDefDspRetWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CEqpDefDspRetWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public CEqpDefDspRetWork()
		{
		}

	}

	/// <summary>
	///  Ver5.10.1.0用のカスタムシライアライザです。
	/// </summary>
	/// <returns>CEqpDefDspRetWorkクラスのインスタンス(object)</returns>
	/// <remarks>
	/// <br>Note　　　　　　 :   CEqpDefDspRetWorkクラスのカスタムシリアライザを定義します</br>
	/// <br>Programer        :   自動生成</br>
	/// </remarks>
	public class CEqpDefDspRetWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
	{
		#region ICustomSerializationSurrogate メンバ

		/// <summary>
		///  Ver5.10.1.0用のカスタムシリアライザです
		/// </summary>
		/// <remarks>
		/// <br>Note　　　　　　 :   CEqpDefDspRetWorkクラスのカスタムシリアライザを定義します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public void Serialize(System.IO.BinaryWriter writer, object graph)
		{
			// TODO:  CEqpDefDspRetWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
			if (writer == null)
				throw new ArgumentNullException();

			if (graph != null && !(graph is CEqpDefDspRetWork || graph is ArrayList || graph is CEqpDefDspRetWork[]))
				throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(CEqpDefDspRetWork).FullName));

			if (graph != null && graph is CEqpDefDspRetWork)
			{
				Type t = graph.GetType();
				if (!CustomFormatterServices.NeedCustomSerialization(t))
					throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
			}

			//SerializationTypeInfo
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.CEqpDefDspRetWork");

			//繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
			int occurrence = 0;     //一般にゼロの場合もありえます
			if (graph is ArrayList)
			{
				serInfo.RetTypeInfo = 0;
				occurrence = ((ArrayList)graph).Count;
			}
			else if (graph is CEqpDefDspRetWork[])
			{
				serInfo.RetTypeInfo = 2;
				occurrence = ((CEqpDefDspRetWork[])graph).Length;
			}
			else if (graph is CEqpDefDspRetWork)
			{
				serInfo.RetTypeInfo = 1;
				occurrence = 1;
			}

			serInfo.Occurrence = occurrence;		 //繰り返し数	

			//メーカーコード
			serInfo.MemberInfo.Add(typeof(Int32)); //MakerCode
			//車種コード
			serInfo.MemberInfo.Add(typeof(Int32)); //ModelCode
			//車種サブコード
			serInfo.MemberInfo.Add(typeof(Int32)); //ModelSubCode
			//系統コード
			serInfo.MemberInfo.Add(typeof(Int32)); //SystematicCode
			//装備表示順位
			serInfo.MemberInfo.Add(typeof(Int32)); //EquipmentDispOrder
			//装備分類コード
			serInfo.MemberInfo.Add(typeof(Int32)); //EquipmentGenreCd
			//装備分類名称
			serInfo.MemberInfo.Add(typeof(string)); //EquipmentGenreNm
			//装備コード
			serInfo.MemberInfo.Add(typeof(Int32)); //EquipmentCode
			//装備名称
			serInfo.MemberInfo.Add(typeof(string)); //EquipmentName
			//装備略称
			serInfo.MemberInfo.Add(typeof(string)); //EquipmentShortName
			//装備ICONコード
			serInfo.MemberInfo.Add(typeof(Int32)); //EquipmentIconCode


			serInfo.Serialize(writer, serInfo);
			if (graph is CEqpDefDspRetWork)
			{
				CEqpDefDspRetWork temp = (CEqpDefDspRetWork)graph;

				SetCEqpDefDspRetWork(writer, temp);
			}
			else
			{
				ArrayList lst = null;
				if (graph is CEqpDefDspRetWork[])
				{
					lst = new ArrayList();
					lst.AddRange((CEqpDefDspRetWork[])graph);
				}
				else
				{
					lst = (ArrayList)graph;
				}

				foreach (CEqpDefDspRetWork temp in lst)
				{
					SetCEqpDefDspRetWork(writer, temp);
				}

			}


		}


		/// <summary>
		/// CEqpDefDspRetWorkメンバ数(publicプロパティ数)
		/// </summary>
		private const int currentMemberCount = 11;

		/// <summary>
		///  CEqpDefDspRetWorkインスタンス書き込み
		/// </summary>
		/// <remarks>
		/// <br>Note　　　　　　 :   CEqpDefDspRetWorkのインスタンスを書き込み</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		private void SetCEqpDefDspRetWork(System.IO.BinaryWriter writer, CEqpDefDspRetWork temp)
		{
			//メーカーコード
			writer.Write(temp.MakerCode);
			//車種コード
			writer.Write(temp.ModelCode);
			//車種サブコード
			writer.Write(temp.ModelSubCode);
			//系統コード
			writer.Write(temp.SystematicCode);
			//装備表示順位
			writer.Write(temp.EquipmentDispOrder);
			//装備分類コード
			writer.Write(temp.EquipmentGenreCd);
			//装備分類名称
			writer.Write(temp.EquipmentGenreNm);
			//装備コード
			writer.Write(temp.EquipmentCode);
			//装備名称
			writer.Write(temp.EquipmentName);
			//装備略称
			writer.Write(temp.EquipmentShortName);
			//装備ICONコード
			writer.Write(temp.EquipmentIconCode);

		}

		/// <summary>
		///  CEqpDefDspRetWorkインスタンス取得
		/// </summary>
		/// <returns>CEqpDefDspRetWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CEqpDefDspRetWorkのインスタンスを取得します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		private CEqpDefDspRetWork GetCEqpDefDspRetWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
		{
			// V5.1.0.0なので不要ですが、V5.1.0.1以降では
			// serInfo.MemberInfo.Count < currentMemberCount
			// のケースについての配慮が必要になります。

			CEqpDefDspRetWork temp = new CEqpDefDspRetWork();

			//メーカーコード
			temp.MakerCode = reader.ReadInt32();
			//車種コード
			temp.ModelCode = reader.ReadInt32();
			//車種サブコード
			temp.ModelSubCode = reader.ReadInt32();
			//系統コード
			temp.SystematicCode = reader.ReadInt32();
			//装備表示順位
			temp.EquipmentDispOrder = reader.ReadInt32();
			//装備分類コード
			temp.EquipmentGenreCd = reader.ReadInt32();
			//装備分類名称
			temp.EquipmentGenreNm = reader.ReadString();
			//装備コード
			temp.EquipmentCode = reader.ReadInt32();
			//装備名称
			temp.EquipmentName = reader.ReadString();
			//装備略称
			temp.EquipmentShortName = reader.ReadString();
			//装備ICONコード
			temp.EquipmentIconCode = reader.ReadInt32();


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
		/// <returns>CEqpDefDspRetWorkクラスのインスタンス(object)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CEqpDefDspRetWorkクラスのカスタムデシリアライザを定義します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public object Deserialize(System.IO.BinaryReader reader)
		{
			object retValue = null;
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
			ArrayList lst = new ArrayList();
			for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
			{
				CEqpDefDspRetWork temp = GetCEqpDefDspRetWork(reader, serInfo);
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
					retValue = (CEqpDefDspRetWork[])lst.ToArray(typeof(CEqpDefDspRetWork));
					break;
			}
			return retValue;
		}

		#endregion
	}

}

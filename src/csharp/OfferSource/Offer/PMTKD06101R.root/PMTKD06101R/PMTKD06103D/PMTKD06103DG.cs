using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   CategoryEquipmentRetWork
	/// <summary>
	///                      装備部品区分ワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   装備部品区分ワークヘッダファイル</br>
	/// <br>Programmer       :   96137 久保田　信一</br>
	/// <br>Date             :   2005/4/4</br>
	/// <br>Genarated Date   :   2005/04/05  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class CategoryEquipmentRetWork
	{
		#region privateメンバ定義
		/// <summary>装備分類コード</summary>
		private Int32 _equipmentGenreCd = 0;

		/// <summary>装備分類名称</summary>
		private string _equipmentGenreNm = "";

		/// <summary>装備管理区分コード</summary>
		private Int32 _equipmentMngCode = 0;

		/// <summary>装備管理区分名称</summary>
		private string _equipmentMngName = "";

		/// <summary>装備コード</summary>
		private Int32 _equipmentCode = 0;

		/// <summary>装備表示順位</summary>
		private Int32 _equipmentDispOrder = 0;

		/// <summary>翼部品コード</summary>
		/// <remarks>1～99999:提供分,100000～ユーザー登録用</remarks>
		private Int32 _tbsPartsCode = 0;

		/// <summary>装備名称</summary>
		private string _equipmentName = "";

		/// <summary>装備略称</summary>
		private string _equipmentShortName = "";

		/// <summary>装備ICONコード</summary>
		private Int32 _equipmentIconCode = 0;

		/// <summary>装備単位コード</summary>
		private Int32 _equipmentUnitCode = 0;

		/// <summary>装備単位名称</summary>
		private string _equipmentUnitName = "";

		/// <summary>装備数量</summary>
		private Double _equipmentCnt = 0.0;

		/// <summary>装備コメント1</summary>
		private string _equipmentComment1 = "";

		/// <summary>装備コメント2</summary>
		private string _equipmentComment2 = "";

		#endregion

		#region publicプロパティ定義
		/// public propaty name  :  EquipmentGenreCd
		/// <summary>装備分類コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   装備分類コードプロパティ</br>
		/// <br>Programer        :   久保田　信一</br>
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
		/// <br>Programer        :   久保田　信一</br>
		/// </remarks>
		public string EquipmentGenreNm
		{
			get { return _equipmentGenreNm; }
			set { _equipmentGenreNm = value; }
		}

		/// public propaty name  :  EquipmentMngCode
		/// <summary>装備管理区分コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   装備管理区分コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EquipmentMngCode
		{
			get { return _equipmentMngCode; }
			set { _equipmentMngCode = value; }
		}

		/// public propaty name  :  EquipmentMngName
		/// <summary>装備管理区分名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   装備管理区分名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EquipmentMngName
		{
			get { return _equipmentMngName; }
			set { _equipmentMngName = value; }
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

		/// public propaty name  :  EquipmentDispOrder
		/// <summary>装備表示順位プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   装備コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EquipmentDispOrder
		{
			get { return _equipmentDispOrder; }
			set { _equipmentDispOrder = value; }
		}

		/// public propaty name  :  TbsPartsCode
		/// <summary>翼部品コードプロパティ</summary>
		/// <value>1～99999:提供分,100000～ユーザー登録用</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   翼部品コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 TbsPartsCode
		{
			get { return _tbsPartsCode; }
			set { _tbsPartsCode = value; }
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

		/// public propaty name  :  EquipmentUnitCode
		/// <summary>装備単位コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   装備単位コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EquipmentUnitCode
		{
			get { return _equipmentUnitCode; }
			set { _equipmentUnitCode = value; }
		}

		/// public propaty name  :  EquipmentUnitName
		/// <summary>装備単位名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   装備単位名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EquipmentUnitName
		{
			get { return _equipmentUnitName; }
			set { _equipmentUnitName = value; }
		}

		/// public propaty name  :  EquipmentCnt
		/// <summary>装備数量プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   装備数量プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double EquipmentCnt
		{
			get { return _equipmentCnt; }
			set { _equipmentCnt = value; }
		}

		/// public propaty name  :  EquipmentComment1
		/// <summary>装備コメント1プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   装備コメント1プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EquipmentComment1
		{
			get { return _equipmentComment1; }
			set { _equipmentComment1 = value; }
		}

		/// public propaty name  :  EquipmentComment2
		/// <summary>装備コメント2プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   装備コメント2プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EquipmentComment2
		{
			get { return _equipmentComment2; }
			set { _equipmentComment2 = value; }
		}

		#endregion

		/// <summary>
		/// 類別装備部品区分ワークコンストラクタ
		/// </summary>
		/// <returns>CategoryEquipmentRetWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CategoryEquipmentPartsWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   久保田　信一</br>
		/// </remarks>
		public CategoryEquipmentRetWork()
		{
		}

	}


	/// <summary>
	///  Ver5.10.1.0用のカスタムシライアライザです。
	/// </summary>
	/// <returns>CategoryEquipmentRetWorkクラスのインスタンス(object)</returns>
	/// <remarks>
	/// <br>Note　　　　　　 :   CategoryEquipmentRetWorkクラスのカスタムシリアライザを定義します</br>
	/// <br>Programer        :   自動生成</br>
	/// </remarks>
	public class CategoryEquipmentRetWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
	{
		#region ICustomSerializationSurrogate メンバ

		/// <summary>
		///  Ver5.10.1.0用のカスタムシリアライザです
		/// </summary>
		/// <remarks>
		/// <br>Note　　　　　　 :   CategoryEquipmentRetWorkクラスのカスタムシリアライザを定義します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public void Serialize(System.IO.BinaryWriter writer, object graph)
		{
			// TODO:  CategoryEquipmentRetWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
			if (writer == null)
				throw new ArgumentNullException();

			if (graph != null && !(graph is CategoryEquipmentRetWork || graph is ArrayList || graph is CategoryEquipmentRetWork[]))
				throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(CategoryEquipmentRetWork).FullName));

			if (graph != null && graph is CategoryEquipmentRetWork)
			{
				Type t = graph.GetType();
				if (!CustomFormatterServices.NeedCustomSerialization(t))
					throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
			}

			//SerializationTypeInfo
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.CategoryEquipmentRetWork");

			//繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
			int occurrence = 0;     //一般にゼロの場合もありえます
			if (graph is ArrayList)
			{
				serInfo.RetTypeInfo = 0;
				occurrence = ((ArrayList)graph).Count;
			}
			else if (graph is CategoryEquipmentRetWork[])
			{
				serInfo.RetTypeInfo = 2;
				occurrence = ((CategoryEquipmentRetWork[])graph).Length;
			}
			else if (graph is CategoryEquipmentRetWork)
			{
				serInfo.RetTypeInfo = 1;
				occurrence = 1;
			}

			serInfo.Occurrence = occurrence;		 //繰り返し数	

			//装備分類コード
			serInfo.MemberInfo.Add(typeof(Int32)); //EquipmentGenreCd
			//装備分類名称
			serInfo.MemberInfo.Add(typeof(string)); //EquipmentGenreNm
			//装備管理区分コード
			serInfo.MemberInfo.Add(typeof(Int32)); //EquipmentMngCode
			//装備管理区分名称
			serInfo.MemberInfo.Add(typeof(string)); //EquipmentMngName
			//装備コード
			serInfo.MemberInfo.Add(typeof(Int32)); //EquipmentCode
			//装備表示順位
			serInfo.MemberInfo.Add(typeof(Int32)); //EquipmentDispOrder
			//翼部品コード
			serInfo.MemberInfo.Add(typeof(Int32)); //TbsPartsCode
			//装備名称
			serInfo.MemberInfo.Add(typeof(string)); //EquipmentName
			//装備略称
			serInfo.MemberInfo.Add(typeof(string)); //EquipmentShortName
			//装備ICONコード
			serInfo.MemberInfo.Add(typeof(Int32)); //EquipmentIconCode
			//装備単位コード
			serInfo.MemberInfo.Add(typeof(Int32)); //EquipmentUnitCode
			//装備単位名称
			serInfo.MemberInfo.Add(typeof(string)); //EquipmentUnitName
			//装備数量
			serInfo.MemberInfo.Add(typeof(Double)); //EquipmentCnt
			//装備コメント1
			serInfo.MemberInfo.Add(typeof(string)); //EquipmentComment1
			//装備コメント2
			serInfo.MemberInfo.Add(typeof(string)); //EquipmentComment2


			serInfo.Serialize(writer, serInfo);
			if (graph is CategoryEquipmentRetWork)
			{
				CategoryEquipmentRetWork temp = (CategoryEquipmentRetWork)graph;

				SetCategoryEquipmentRetWork(writer, temp);
			}
			else
			{
				ArrayList lst = null;
				if (graph is CategoryEquipmentRetWork[])
				{
					lst = new ArrayList();
					lst.AddRange((CategoryEquipmentRetWork[])graph);
				}
				else
				{
					lst = (ArrayList)graph;
				}

				foreach (CategoryEquipmentRetWork temp in lst)
				{
					SetCategoryEquipmentRetWork(writer, temp);
				}

			}


		}


		/// <summary>
		/// CategoryEquipmentRetWorkメンバ数(publicプロパティ数)
		/// </summary>
		private const int currentMemberCount = 15;

		/// <summary>
		///  CategoryEquipmentRetWorkインスタンス書き込み
		/// </summary>
		/// <remarks>
		/// <br>Note　　　　　　 :   CategoryEquipmentRetWorkのインスタンスを書き込み</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		private void SetCategoryEquipmentRetWork(System.IO.BinaryWriter writer, CategoryEquipmentRetWork temp)
		{
			//装備分類コード
			writer.Write(temp.EquipmentGenreCd);
			//装備分類名称
			writer.Write(temp.EquipmentGenreNm);
			//装備管理区分コード
			writer.Write(temp.EquipmentMngCode);
			//装備管理区分名称
			writer.Write(temp.EquipmentMngName);
			//装備コード
			writer.Write(temp.EquipmentCode);
			//装備表示順位
			writer.Write(temp.EquipmentDispOrder);
			//翼部品コード
			writer.Write(temp.TbsPartsCode);
			//装備名称
			writer.Write(temp.EquipmentName);
			//装備略称
			writer.Write(temp.EquipmentShortName);
			//装備ICONコード
			writer.Write(temp.EquipmentIconCode);
			//装備単位コード
			writer.Write(temp.EquipmentUnitCode);
			//装備単位名称
			writer.Write(temp.EquipmentUnitName);
			//装備数量
			writer.Write(temp.EquipmentCnt);
			//装備コメント1
			writer.Write(temp.EquipmentComment1);
			//装備コメント2
			writer.Write(temp.EquipmentComment2);

		}

		/// <summary>
		///  CategoryEquipmentRetWorkインスタンス取得
		/// </summary>
		/// <returns>CategoryEquipmentRetWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CategoryEquipmentRetWorkのインスタンスを取得します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		private CategoryEquipmentRetWork GetCategoryEquipmentRetWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
		{
			// V5.1.0.0なので不要ですが、V5.1.0.1以降では
			// serInfo.MemberInfo.Count < currentMemberCount
			// のケースについての配慮が必要になります。

			CategoryEquipmentRetWork temp = new CategoryEquipmentRetWork();

			//装備分類コード
			temp.EquipmentGenreCd = reader.ReadInt32();
			//装備分類名称
			temp.EquipmentGenreNm = reader.ReadString();
			//装備管理区分コード
			temp.EquipmentMngCode = reader.ReadInt32();
			//装備管理区分名称
			temp.EquipmentMngName = reader.ReadString();
			//装備コード
			temp.EquipmentCode = reader.ReadInt32();
			//装備表示順位
			temp.EquipmentDispOrder = reader.ReadInt32();
			//翼部品コード
			temp.TbsPartsCode = reader.ReadInt32();
			//装備名称
			temp.EquipmentName = reader.ReadString();
			//装備略称
			temp.EquipmentShortName = reader.ReadString();
			//装備ICONコード
			temp.EquipmentIconCode = reader.ReadInt32();
			//装備単位コード
			temp.EquipmentUnitCode = reader.ReadInt32();
			//装備単位名称
			temp.EquipmentUnitName = reader.ReadString();
			//装備数量
			temp.EquipmentCnt = reader.ReadDouble();
			//装備コメント1
			temp.EquipmentComment1 = reader.ReadString();
			//装備コメント2
			temp.EquipmentComment2 = reader.ReadString();


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
		/// <returns>CategoryEquipmentRetWorkクラスのインスタンス(object)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   CategoryEquipmentRetWorkクラスのカスタムデシリアライザを定義します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public object Deserialize(System.IO.BinaryReader reader)
		{
			object retValue = null;
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
			ArrayList lst = new ArrayList();
			for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
			{
				CategoryEquipmentRetWork temp = GetCategoryEquipmentRetWork(reader, serInfo);
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
					retValue = (CategoryEquipmentRetWork[])lst.ToArray(typeof(CategoryEquipmentRetWork));
					break;
			}
			return retValue;
		}

		#endregion
	}
}

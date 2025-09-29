using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   UsrSetPartsRetWork
	/// <summary>
	///                      ユーザーセット抽出結果クラスワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   ユーザーセット抽出結果クラスワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2006/10/16</br>
	/// <br>Genarated Date   :   2007/06/05  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class UsrSetPartsRetWork
	{
		/// <summary>セット親メーカーコード</summary>
		private Int32 _setMainMakerCd;

		/// <summary>セット親品番</summary>
		/// <remarks>ハイフン付き</remarks>
		private string _setMainPartsNo = string.Empty;

		/// <summary>セット子メーカーコード</summary>
		private Int32 _setSubMakerCd;

		/// <summary>セット子品番</summary>
		/// <remarks>ハイフン付き</remarks>
		private string _setSubPartsNo = string.Empty;

		/// <summary>セット表示順位</summary>
		private Int32 _setDispOrder;

		/// <summary>セットQTY</summary>
		private Double _setQty;

		/// <summary>セット名称</summary>
		private string _setName = string.Empty;

		/// <summary>セット規格・特記事項</summary>
		private string _setSpecialNote = string.Empty;

		/// <summary>カタログ図番</summary>
		private string _catalogShapeNo = string.Empty;


		/// public property name  :  SetMainMakerCd
		/// <summary>セット親メーカーコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   セット親メーカーコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SetMainMakerCd
		{
			get { return _setMainMakerCd; }
			set { _setMainMakerCd = value; }
		}

		/// public property name  :  SetMainPartsNo
		/// <summary>セット親品番プロパティ</summary>
		/// <value>ハイフン付き</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   セット親品番プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SetMainPartsNo
		{
			get { return _setMainPartsNo; }
			set { _setMainPartsNo = value; }
		}

		/// public property name  :  SetSubMakerCd
		/// <summary>セット子メーカーコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   セット子メーカーコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SetSubMakerCd
		{
			get { return _setSubMakerCd; }
			set { _setSubMakerCd = value; }
		}

		/// public property name  :  SetSubPartsNo
		/// <summary>セット子品番プロパティ</summary>
		/// <value>ハイフン付き</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   セット子品番プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SetSubPartsNo
		{
			get { return _setSubPartsNo; }
			set { _setSubPartsNo = value; }
		}

		/// public property name  :  SetDispOrder
		/// <summary>セット表示順位プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   セット表示順位プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SetDispOrder
		{
			get { return _setDispOrder; }
			set { _setDispOrder = value; }
		}

		/// public property name  :  SetQty
		/// <summary>セットQTYプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   セットQTYプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double SetQty
		{
			get { return _setQty; }
			set { _setQty = value; }
		}

		/// public property name  :  SetName
		/// <summary>セット名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   セット名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SetName
		{
			get { return _setName; }
			set { _setName = value; }
		}

		/// public property name  :  SetSpecialNote
		/// <summary>セット規格・特記事項プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   セット規格・特記事項プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SetSpecialNote
		{
			get { return _setSpecialNote; }
			set { _setSpecialNote = value; }
		}

		/// public property name  :  CatalogShapeNo
		/// <summary>カタログ図番プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   カタログ図番プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CatalogShapeNo
		{
			get { return _catalogShapeNo; }
			set { _catalogShapeNo = value; }
		}


		/// <summary>
		/// ユーザーセット抽出結果クラスワークコンストラクタ
		/// </summary>
		/// <returns>UsrSetPartsRetWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   UsrSetPartsRetWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public UsrSetPartsRetWork()
		{
		}

	}
	/// <summary>
	///  Ver5.10.1.0用のカスタムシライアライザです。
	/// </summary>
	/// <returns>UsrSetPartsRetWorkクラスのインスタンス(object)</returns>
	/// <remarks>
	/// <br>Note　　　　　　 :   UsrSetPartsRetWorkクラスのカスタムシリアライザを定義します</br>
	/// <br>Programer        :   自動生成</br>
	/// </remarks>
	public class UsrSetPartsRetWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
	{
		#region ICustomSerializationSurrogate メンバ

		/// <summary>
		///  Ver5.10.1.0用のカスタムシリアライザです
		/// </summary>
		/// <remarks>
		/// <br>Note　　　　　　 :   UsrSetPartsRetWorkクラスのカスタムシリアライザを定義します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public void Serialize(System.IO.BinaryWriter writer, object graph)
		{
			// TODO:  UsrSetPartsRetWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
			if (writer == null)
				throw new ArgumentNullException();

			if (graph != null && !(graph is UsrSetPartsRetWork || graph is ArrayList || graph is UsrSetPartsRetWork[]))
				throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(UsrSetPartsRetWork).FullName));

			if (graph != null && graph is UsrSetPartsRetWork)
			{
				Type t = graph.GetType();
				if (!CustomFormatterServices.NeedCustomSerialization(t))
					throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
			}

			//SerializationTypeInfo
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.UsrSetPartsRetWork");

			//繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
			int occurrence = 0;     //一般にゼロの場合もありえます
			if (graph is ArrayList)
			{
				serInfo.RetTypeInfo = 0;
				occurrence = ((ArrayList)graph).Count;
			}
			else if (graph is UsrSetPartsRetWork[])
			{
				serInfo.RetTypeInfo = 2;
				occurrence = ((UsrSetPartsRetWork[])graph).Length;
			}
			else if (graph is UsrSetPartsRetWork)
			{
				serInfo.RetTypeInfo = 1;
				occurrence = 1;
			}

			serInfo.Occurrence = occurrence;		 //繰り返し数	

			//セット親メーカーコード
			serInfo.MemberInfo.Add(typeof(Int32)); //SetMainMakerCd
			//セット親品番
			serInfo.MemberInfo.Add(typeof(string)); //SetMainPartsNo
			//セット子メーカーコード
			serInfo.MemberInfo.Add(typeof(Int32)); //SetSubMakerCd
			//セット子品番
			serInfo.MemberInfo.Add(typeof(string)); //SetSubPartsNo
			//セット表示順位
			serInfo.MemberInfo.Add(typeof(Int32)); //SetDispOrder
			//セットQTY
			serInfo.MemberInfo.Add(typeof(Double)); //SetQty
			//セット名称
			serInfo.MemberInfo.Add(typeof(string)); //SetName
			//セット規格・特記事項
			serInfo.MemberInfo.Add(typeof(string)); //SetSpecialNote
			//カタログ図番
			serInfo.MemberInfo.Add(typeof(string)); //CatalogShapeNo


			serInfo.Serialize(writer, serInfo);
			if (graph is UsrSetPartsRetWork)
			{
				UsrSetPartsRetWork temp = (UsrSetPartsRetWork)graph;

				SetUsrSetPartsRetWork(writer, temp);
			}
			else
			{
				ArrayList lst = null;
				if (graph is UsrSetPartsRetWork[])
				{
					lst = new ArrayList();
					lst.AddRange((UsrSetPartsRetWork[])graph);
				}
				else
				{
					lst = (ArrayList)graph;
				}

				foreach (UsrSetPartsRetWork temp in lst)
				{
					SetUsrSetPartsRetWork(writer, temp);
				}

			}


		}


		/// <summary>
		/// UsrSetPartsRetWorkメンバ数(publicプロパティ数)
		/// </summary>
		private const int currentMemberCount = 9;

		/// <summary>
		///  UsrSetPartsRetWorkインスタンス書き込み
		/// </summary>
		/// <remarks>
		/// <br>Note　　　　　　 :   UsrSetPartsRetWorkのインスタンスを書き込み</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		private void SetUsrSetPartsRetWork(System.IO.BinaryWriter writer, UsrSetPartsRetWork temp)
		{
			//セット親メーカーコード
			writer.Write(temp.SetMainMakerCd);
			//セット親品番
			writer.Write(temp.SetMainPartsNo);
			//セット子メーカーコード
			writer.Write(temp.SetSubMakerCd);
			//セット子品番
			writer.Write(temp.SetSubPartsNo);
			//セット表示順位
			writer.Write(temp.SetDispOrder);
			//セットQTY
			writer.Write(temp.SetQty);
			//セット名称
			writer.Write(temp.SetName);
			//セット規格・特記事項
			writer.Write(temp.SetSpecialNote);
			//カタログ図番
			writer.Write(temp.CatalogShapeNo);

		}

		/// <summary>
		///  UsrSetPartsRetWorkインスタンス取得
		/// </summary>
		/// <returns>UsrSetPartsRetWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   UsrSetPartsRetWorkのインスタンスを取得します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		private UsrSetPartsRetWork GetUsrSetPartsRetWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
		{
			// V5.1.0.0なので不要ですが、V5.1.0.1以降では
			// serInfo.MemberInfo.Count < currentMemberCount
			// のケースについての配慮が必要になります。

			UsrSetPartsRetWork temp = new UsrSetPartsRetWork();

			//セット親メーカーコード
			temp.SetMainMakerCd = reader.ReadInt32();
			//セット親品番
			temp.SetMainPartsNo = reader.ReadString();
			//セット子メーカーコード
			temp.SetSubMakerCd = reader.ReadInt32();
			//セット子品番
			temp.SetSubPartsNo = reader.ReadString();
			//セット表示順位
			temp.SetDispOrder = reader.ReadInt32();
			//セットQTY
			temp.SetQty = reader.ReadDouble();
			//セット名称
			temp.SetName = reader.ReadString();
			//セット規格・特記事項
			temp.SetSpecialNote = reader.ReadString();
			//カタログ図番
			temp.CatalogShapeNo = reader.ReadString();


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
		/// <returns>UsrSetPartsRetWorkクラスのインスタンス(object)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   UsrSetPartsRetWorkクラスのカスタムデシリアライザを定義します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public object Deserialize(System.IO.BinaryReader reader)
		{
			object retValue = null;
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
			ArrayList lst = new ArrayList();
			for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
			{
				UsrSetPartsRetWork temp = GetUsrSetPartsRetWork(reader, serInfo);
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
					retValue = (UsrSetPartsRetWork[])lst.ToArray(typeof(UsrSetPartsRetWork));
					break;
			}
			return retValue;
		}

		#endregion
	}

}

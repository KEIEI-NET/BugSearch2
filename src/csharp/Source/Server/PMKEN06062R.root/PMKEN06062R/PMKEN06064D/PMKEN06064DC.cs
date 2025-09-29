using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   UsrJoinPartsRetWork
	/// <summary>
	///                      ユーザー結合抽出結果クラスワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   ユーザー結合抽出結果クラスワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2006/10/16</br>
	/// <br>Genarated Date   :   2007/06/05  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class UsrJoinPartsRetWork
	{
		/// <summary>結合表示順位</summary>
		/// <remarks>4,5,6,7,8,10,11が同一の結合が複数存在する場合の連番</remarks>
		private Int32 _joinDispOrder;

		/// <summary>結合元メーカーコード</summary>
		private Int32 _joinSourceMakerCode;

		/// <summary>結合元品番(－付き品番)</summary>
		/// <remarks>ハイフン付き</remarks>
		private string _joinSourPartsNoWithH = string.Empty;

		/// <summary>結合元品番(－無し品番)</summary>
		private string _joinSourPartsNoNoneH = string.Empty;

		/// <summary>結合先メーカーコード</summary>
		private Int32 _joinDestMakerCd;

		/// <summary>結合先品番(－付き品番)</summary>
		/// <remarks>ハイフン付き</remarks>
		private string _joinDestPartsNo = string.Empty;

		/// <summary>結合QTY</summary>
		private Double _joinQty;

		/// <summary>結合規格・特記事項</summary>
		private string _joinSpecialNote = string.Empty;

		/// <summary>結合データ提供日付</summary>
		/// <remarks>YYYYMMDD</remarks>
		private Int32 _joinOfferDate;


		/// public property name  :  JoinDispOrder
		/// <summary>結合表示順位プロパティ</summary>
		/// <value>4,5,6,7,8,10,11が同一の結合が複数存在する場合の連番</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   結合表示順位プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 JoinDispOrder
		{
			get { return _joinDispOrder; }
			set { _joinDispOrder = value; }
		}

		/// public property name  :  JoinSourceMakerCode
		/// <summary>結合元メーカーコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   結合元メーカーコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 JoinSourceMakerCode
		{
			get { return _joinSourceMakerCode; }
			set { _joinSourceMakerCode = value; }
		}

		/// public property name  :  JoinSourPartsNoWithH
		/// <summary>結合元品番(－付き品番)プロパティ</summary>
		/// <value>ハイフン付き</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   結合元品番(－付き品番)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string JoinSourPartsNoWithH
		{
			get { return _joinSourPartsNoWithH; }
			set { _joinSourPartsNoWithH = value; }
		}

		/// public property name  :  JoinSourPartsNoNoneH
		/// <summary>結合元品番(－無し品番)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   結合元品番(－無し品番)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string JoinSourPartsNoNoneH
		{
			get { return _joinSourPartsNoNoneH; }
			set { _joinSourPartsNoNoneH = value; }
		}

		/// public property name  :  JoinDestMakerCd
		/// <summary>結合先メーカーコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   結合先メーカーコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 JoinDestMakerCd
		{
			get { return _joinDestMakerCd; }
			set { _joinDestMakerCd = value; }
		}

		/// public property name  :  JoinDestPartsNo
		/// <summary>結合先品番(－付き品番)プロパティ</summary>
		/// <value>ハイフン付き</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   結合先品番(－付き品番)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string JoinDestPartsNo
		{
			get { return _joinDestPartsNo; }
			set { _joinDestPartsNo = value; }
		}

		/// public property name  :  JoinQty
		/// <summary>結合QTYプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   結合QTYプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double JoinQty
		{
			get { return _joinQty; }
			set { _joinQty = value; }
		}

		/// public property name  :  JoinSpecialNote
		/// <summary>結合規格・特記事項プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   結合規格・特記事項プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string JoinSpecialNote
		{
			get { return _joinSpecialNote; }
			set { _joinSpecialNote = value; }
		}

		/// public property name  :  JoinOfferDate
		/// <summary>結合データ提供日付プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   結合データ提供日付プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 JoinOfferDate
		{
			get { return _joinOfferDate; }
			set { _joinOfferDate = value; }
		}


		/// <summary>
		/// ユーザー結合抽出結果クラスワークコンストラクタ
		/// </summary>
		/// <returns>UsrJoinPartsRetWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   UsrJoinPartsRetWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public UsrJoinPartsRetWork()
		{
		}

	}

	/// <summary>
	///  Ver5.10.1.0用のカスタムシライアライザです。
	/// </summary>
	/// <returns>UsrJoinPartsRetWorkクラスのインスタンス(object)</returns>
	/// <remarks>
	/// <br>Note　　　　　　 :   UsrJoinPartsRetWorkクラスのカスタムシリアライザを定義します</br>
	/// <br>Programer        :   自動生成</br>
	/// </remarks>
	public class UsrJoinPartsRetWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
	{
		#region ICustomSerializationSurrogate メンバ

		/// <summary>
		///  Ver5.10.1.0用のカスタムシリアライザです
		/// </summary>
		/// <remarks>
		/// <br>Note　　　　　　 :   UsrJoinPartsRetWorkクラスのカスタムシリアライザを定義します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public void Serialize(System.IO.BinaryWriter writer, object graph)
		{
			// TODO:  UsrJoinPartsRetWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
			if (writer == null)
				throw new ArgumentNullException();

			if (graph != null && !(graph is UsrJoinPartsRetWork || graph is ArrayList || graph is UsrJoinPartsRetWork[]))
				throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(UsrJoinPartsRetWork).FullName));

			if (graph != null && graph is UsrJoinPartsRetWork)
			{
				Type t = graph.GetType();
				if (!CustomFormatterServices.NeedCustomSerialization(t))
					throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
			}

			//SerializationTypeInfo
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.UsrJoinPartsRetWork");

			//繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
			int occurrence = 0;     //一般にゼロの場合もありえます
			if (graph is ArrayList)
			{
				serInfo.RetTypeInfo = 0;
				occurrence = ((ArrayList)graph).Count;
			}
			else if (graph is UsrJoinPartsRetWork[])
			{
				serInfo.RetTypeInfo = 2;
				occurrence = ((UsrJoinPartsRetWork[])graph).Length;
			}
			else if (graph is UsrJoinPartsRetWork)
			{
				serInfo.RetTypeInfo = 1;
				occurrence = 1;
			}

			serInfo.Occurrence = occurrence;		 //繰り返し数	

			//結合表示順位
			serInfo.MemberInfo.Add(typeof(Int32)); //JoinDispOrder
			//結合元メーカーコード
			serInfo.MemberInfo.Add(typeof(Int32)); //JoinSourceMakerCode
			//結合元品番(－付き品番)
			serInfo.MemberInfo.Add(typeof(string)); //JoinSourPartsNoWithH
			//結合元品番(－無し品番)
			serInfo.MemberInfo.Add(typeof(string)); //JoinSourPartsNoNoneH
			//結合先メーカーコード
			serInfo.MemberInfo.Add(typeof(Int32)); //JoinDestMakerCd
			//結合先品番(－付き品番)
			serInfo.MemberInfo.Add(typeof(string)); //JoinDestPartsNo
			//結合QTY
			serInfo.MemberInfo.Add(typeof(Double)); //JoinQty
			//結合規格・特記事項
			serInfo.MemberInfo.Add(typeof(string)); //JoinSpecialNote
			//結合データ提供日付
			serInfo.MemberInfo.Add(typeof(Int32)); //JoinOfferDate


			serInfo.Serialize(writer, serInfo);
			if (graph is UsrJoinPartsRetWork)
			{
				UsrJoinPartsRetWork temp = (UsrJoinPartsRetWork)graph;

				SetUsrJoinPartsRetWork(writer, temp);
			}
			else
			{
				ArrayList lst = null;
				if (graph is UsrJoinPartsRetWork[])
				{
					lst = new ArrayList();
					lst.AddRange((UsrJoinPartsRetWork[])graph);
				}
				else
				{
					lst = (ArrayList)graph;
				}

				foreach (UsrJoinPartsRetWork temp in lst)
				{
					SetUsrJoinPartsRetWork(writer, temp);
				}

			}


		}


		/// <summary>
		/// UsrJoinPartsRetWorkメンバ数(publicプロパティ数)
		/// </summary>
		private const int currentMemberCount = 9;

		/// <summary>
		///  UsrJoinPartsRetWorkインスタンス書き込み
		/// </summary>
		/// <remarks>
		/// <br>Note　　　　　　 :   UsrJoinPartsRetWorkのインスタンスを書き込み</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		private void SetUsrJoinPartsRetWork(System.IO.BinaryWriter writer, UsrJoinPartsRetWork temp)
		{
			//結合表示順位
			writer.Write(temp.JoinDispOrder);
			//結合元メーカーコード
			writer.Write(temp.JoinSourceMakerCode);
			//結合元品番(－付き品番)
			writer.Write(temp.JoinSourPartsNoWithH);
			//結合元品番(－無し品番)
			writer.Write(temp.JoinSourPartsNoNoneH);
			//結合先メーカーコード
			writer.Write(temp.JoinDestMakerCd);
			//結合先品番(－付き品番)
			writer.Write(temp.JoinDestPartsNo);
			//結合QTY
			writer.Write(temp.JoinQty);
			//結合規格・特記事項
			writer.Write(temp.JoinSpecialNote);
			//結合データ提供日付
			writer.Write(temp.JoinOfferDate);

		}

		/// <summary>
		///  UsrJoinPartsRetWorkインスタンス取得
		/// </summary>
		/// <returns>UsrJoinPartsRetWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   UsrJoinPartsRetWorkのインスタンスを取得します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		private UsrJoinPartsRetWork GetUsrJoinPartsRetWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
		{
			// V5.1.0.0なので不要ですが、V5.1.0.1以降では
			// serInfo.MemberInfo.Count < currentMemberCount
			// のケースについての配慮が必要になります。

			UsrJoinPartsRetWork temp = new UsrJoinPartsRetWork();

			//結合表示順位
			temp.JoinDispOrder = reader.ReadInt32();
			//結合元メーカーコード
			temp.JoinSourceMakerCode = reader.ReadInt32();
			//結合元品番(－付き品番)
			temp.JoinSourPartsNoWithH = reader.ReadString();
			//結合元品番(－無し品番)
			temp.JoinSourPartsNoNoneH = reader.ReadString();
			//結合先メーカーコード
			temp.JoinDestMakerCd = reader.ReadInt32();
			//結合先品番(－付き品番)
			temp.JoinDestPartsNo = reader.ReadString();
			//結合QTY
			temp.JoinQty = reader.ReadDouble();
			//結合規格・特記事項
			temp.JoinSpecialNote = reader.ReadString();
			//結合データ提供日付
			temp.JoinOfferDate = reader.ReadInt32();


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
		/// <returns>UsrJoinPartsRetWorkクラスのインスタンス(object)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   UsrJoinPartsRetWorkクラスのカスタムデシリアライザを定義します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public object Deserialize(System.IO.BinaryReader reader)
		{
			object retValue = null;
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
			ArrayList lst = new ArrayList();
			for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
			{
				UsrJoinPartsRetWork temp = GetUsrJoinPartsRetWork(reader, serInfo);
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
					retValue = (UsrJoinPartsRetWork[])lst.ToArray(typeof(UsrJoinPartsRetWork));
					break;
			}
			return retValue;
		}

		#endregion
	}

}

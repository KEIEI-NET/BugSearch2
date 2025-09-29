using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;


namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   UsrPartsSubstRetWork
	/// <summary>
	///                      ユーザー代替抽出結果クラスワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   ユーザー代替抽出結果クラスワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2006/10/16</br>
	/// <br>Genarated Date   :   2007/04/12  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class UsrPartsSubstRetWork
	{
		/// <summary>メーカーコード</summary>
		private Int32 _makerCode;

		/// <summary>品番(-付品番)</summary>
		private string _prtsNoWithHyphen = string.Empty;

		/// <summary>代替順位</summary>
		private Int32 _substOrder;

		/// <summary>代替元メーカーコード</summary>
		private Int32 _substSorMakerCd;

		/// <summary>代替元品番(-付品番)</summary>
		private string _substSorPartsNo = string.Empty;

		/// <summary>代替先メーカーコード</summary>
		private Int32 _substDestMakerCd;

		/// <summary>代替先品番(-付品番)</summary>
		private string _substDestPartsNo = string.Empty;

		/// <summary>適用開始年月日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private Int32 _applyStDate;

		/// <summary>適用終了年月日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private Int32 _applyEdDate;


		/// public property name  :  MakerCode
		/// <summary>メーカーコードプロパティ</summary>
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

		/// public property name  :  PrtsNoWithHyphen
		/// <summary>品番(-付品番)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   品番(-付品番)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PrtsNoWithHyphen
		{
			get { return _prtsNoWithHyphen; }
			set { _prtsNoWithHyphen = value; }
		}

		/// public property name  :  SubstOrder
		/// <summary>代替順位プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   代替順位プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SubstOrder
		{
			get { return _substOrder; }
			set { _substOrder = value; }
		}

		/// public property name  :  SubstSorMakerCd
		/// <summary>代替元メーカーコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   代替元メーカーコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SubstSorMakerCd
		{
			get { return _substSorMakerCd; }
			set { _substSorMakerCd = value; }
		}

		/// public property name  :  SubstSorPartsNo
		/// <summary>代替元品番(-付品番)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   代替元品番(-付品番)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SubstSorPartsNo
		{
			get { return _substSorPartsNo; }
			set { _substSorPartsNo = value; }
		}

		/// public property name  :  SubstDestMakerCd
		/// <summary>代替先メーカーコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   代替先メーカーコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SubstDestMakerCd
		{
			get { return _substDestMakerCd; }
			set { _substDestMakerCd = value; }
		}

		/// public property name  :  SubstDestPartsNo
		/// <summary>代替先品番(-付品番)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   代替先品番(-付品番)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SubstDestPartsNo
		{
			get { return _substDestPartsNo; }
			set { _substDestPartsNo = value; }
		}

		/// public property name  :  ApplyStDate
		/// <summary>適用開始年月日プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   適用開始年月日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ApplyStDate
		{
			get { return _applyStDate; }
			set { _applyStDate = value; }
		}

		/// public property name  :  ApplyEdDate
		/// <summary>適用終了年月日プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   適用終了年月日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ApplyEdDate
		{
			get { return _applyEdDate; }
			set { _applyEdDate = value; }
		}

		/// <summary>
		/// ユーザー代替抽出結果クラスワークコンストラクタ
		/// </summary>
		/// <returns>UsrPartsSubstRetWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   UsrPartsSubstRetWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public UsrPartsSubstRetWork()
		{
		}

        /// <summary>
        /// ユーザー代替抽出結果クラスワークコンストラクタ
        /// </summary>
        /// <param name="srcObject">コピーするソースインスタンス</param>
        /// <returns>UsrPartsSubstRetWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   UsrPartsSubstRetWorkクラスのインスタンスのコピーを生成します</br>
        /// <br>Programer        :   30290</br>
        /// </remarks>
        public UsrPartsSubstRetWork(UsrPartsSubstRetWork srcObject)
        {
            _makerCode = srcObject.MakerCode;
            _prtsNoWithHyphen = srcObject.PrtsNoWithHyphen;
            _substOrder = srcObject.SubstOrder;
            
            _substSorMakerCd = srcObject.SubstSorMakerCd;
            _substSorPartsNo = srcObject.SubstSorPartsNo;

            _substDestMakerCd = srcObject.SubstDestMakerCd;
            _substDestPartsNo = srcObject.SubstDestPartsNo;

            _applyStDate = srcObject.ApplyStDate;
            _applyEdDate = srcObject.ApplyEdDate;
        }

	}

	/// <summary>
	///  Ver5.10.1.0用のカスタムシライアライザです。
	/// </summary>
	/// <returns>UsrPartsSubstRetWorkクラスのインスタンス(object)</returns>
	/// <remarks>
	/// <br>Note　　　　　　 :   UsrPartsSubstRetWorkクラスのカスタムシリアライザを定義します</br>
	/// <br>Programer        :   自動生成</br>
	/// </remarks>
	public class UsrPartsSubstRetWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
	{
		#region ICustomSerializationSurrogate メンバ

		/// <summary>
		///  Ver5.10.1.0用のカスタムシリアライザです
		/// </summary>
		/// <remarks>
		/// <br>Note　　　　　　 :   UsrPartsSubstRetWorkクラスのカスタムシリアライザを定義します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public void Serialize(System.IO.BinaryWriter writer, object graph)
		{
			// TODO:  UsrPartsSubstRetWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
			if (writer == null)
				throw new ArgumentNullException();

			if (graph != null && !(graph is UsrPartsSubstRetWork || graph is ArrayList || graph is UsrPartsSubstRetWork[]))
				throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(UsrPartsSubstRetWork).FullName));

			if (graph != null && graph is UsrPartsSubstRetWork)
			{
				Type t = graph.GetType();
				if (!CustomFormatterServices.NeedCustomSerialization(t))
					throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
			}

			//SerializationTypeInfo
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.UsrPartsSubstRetWork");

			//繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
			int occurrence = 0;     //一般にゼロの場合もありえます
			if (graph is ArrayList)
			{
				serInfo.RetTypeInfo = 0;
				occurrence = ((ArrayList)graph).Count;
			}
			else if (graph is UsrPartsSubstRetWork[])
			{
				serInfo.RetTypeInfo = 2;
				occurrence = ((UsrPartsSubstRetWork[])graph).Length;
			}
			else if (graph is UsrPartsSubstRetWork)
			{
				serInfo.RetTypeInfo = 1;
				occurrence = 1;
			}

			serInfo.Occurrence = occurrence;		 //繰り返し数	

			//メーカーコード
			serInfo.MemberInfo.Add(typeof(Int32)); //MakerCode
			//品番(-付品番)
			serInfo.MemberInfo.Add(typeof(string)); //PrtsNoWithHyphen
			//代替順位
			serInfo.MemberInfo.Add(typeof(Int32)); //SubstOrder
			//代替元メーカーコード
			serInfo.MemberInfo.Add(typeof(Int32)); //SubstSorMakerCd
			//代替元品番(-付品番)
			serInfo.MemberInfo.Add(typeof(string)); //SubstSorPartsNo
			//代替先メーカーコード
			serInfo.MemberInfo.Add(typeof(Int32)); //SubstDestMakerCd
			//代替先品番(-付品番)
			serInfo.MemberInfo.Add(typeof(string)); //SubstDestPartsNo
			//適用開始年月日
			serInfo.MemberInfo.Add(typeof(Int32)); //ApplyStDate
			//適用終了年月日
			serInfo.MemberInfo.Add(typeof(Int32)); //ApplyEdDate


			serInfo.Serialize(writer, serInfo);
			if (graph is UsrPartsSubstRetWork)
			{
				UsrPartsSubstRetWork temp = (UsrPartsSubstRetWork)graph;

				SetUsrPartsSubstRetWork(writer, temp);
			}
			else
			{
				ArrayList lst = null;
				if (graph is UsrPartsSubstRetWork[])
				{
					lst = new ArrayList();
					lst.AddRange((UsrPartsSubstRetWork[])graph);
				}
				else
				{
					lst = (ArrayList)graph;
				}

				foreach (UsrPartsSubstRetWork temp in lst)
				{
					SetUsrPartsSubstRetWork(writer, temp);
				}

			}


		}


		/// <summary>
		/// UsrPartsSubstRetWorkメンバ数(publicプロパティ数)
		/// </summary>
		private const int currentMemberCount = 9;

		/// <summary>
		///  UsrPartsSubstRetWorkインスタンス書き込み
		/// </summary>
		/// <remarks>
		/// <br>Note　　　　　　 :   UsrPartsSubstRetWorkのインスタンスを書き込み</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		private void SetUsrPartsSubstRetWork(System.IO.BinaryWriter writer, UsrPartsSubstRetWork temp)
		{
			//メーカーコード
			writer.Write(temp.MakerCode);
			//品番(-付品番)
			writer.Write(temp.PrtsNoWithHyphen);
			//代替順位
			writer.Write(temp.SubstOrder);
			//代替元メーカーコード
			writer.Write(temp.SubstSorMakerCd);
			//代替元品番(-付品番)
			writer.Write(temp.SubstSorPartsNo);
			//代替先メーカーコード
			writer.Write(temp.SubstDestMakerCd);
			//代替先品番(-付品番)
			writer.Write(temp.SubstDestPartsNo);
			//適用開始年月日
			writer.Write(temp.ApplyStDate);
			//適用終了年月日
			writer.Write(temp.ApplyEdDate);

		}

		/// <summary>
		///  UsrPartsSubstRetWorkインスタンス取得
		/// </summary>
		/// <returns>UsrPartsSubstRetWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   UsrPartsSubstRetWorkのインスタンスを取得します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		private UsrPartsSubstRetWork GetUsrPartsSubstRetWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
		{
			// V5.1.0.0なので不要ですが、V5.1.0.1以降では
			// serInfo.MemberInfo.Count < currentMemberCount
			// のケースについての配慮が必要になります。

			UsrPartsSubstRetWork temp = new UsrPartsSubstRetWork();

			//メーカーコード
			temp.MakerCode = reader.ReadInt32();
			//品番(-付品番)
			temp.PrtsNoWithHyphen = reader.ReadString();
			//代替順位
			temp.SubstOrder = reader.ReadInt32();
			//代替元メーカーコード
			temp.SubstSorMakerCd = reader.ReadInt32();
			//代替元品番(-付品番)
			temp.SubstSorPartsNo = reader.ReadString();
			//代替先メーカーコード
			temp.SubstDestMakerCd = reader.ReadInt32();
			//代替先品番(-付品番)
			temp.SubstDestPartsNo = reader.ReadString();
			//適用開始年月日
			temp.ApplyStDate = reader.ReadInt32();
			//適用終了年月日
			temp.ApplyEdDate = reader.ReadInt32();


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
		/// <returns>UsrPartsSubstRetWorkクラスのインスタンス(object)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   UsrPartsSubstRetWorkクラスのカスタムデシリアライザを定義します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public object Deserialize(System.IO.BinaryReader reader)
		{
			object retValue = null;
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
			ArrayList lst = new ArrayList();
			for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
			{
				UsrPartsSubstRetWork temp = GetUsrPartsSubstRetWork(reader, serInfo);
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
					retValue = (UsrPartsSubstRetWork[])lst.ToArray(typeof(UsrPartsSubstRetWork));
					break;
			}
			return retValue;
		}

		#endregion
	}

}

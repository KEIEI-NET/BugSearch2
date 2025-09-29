using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   AddressWork
	/// <summary>
	///                      住所ワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   住所ワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2005/03/07</br>
	/// <br>Genarated Date   :   2006/04/13  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   2006/4/7  水野　剛史</br>
	/// <br>                 :   共通ファイルヘッダ変更（項目削除）</br>
	/// <br>                 :   ・企業コード</br>
	/// <br>                 :   ・GUID</br>
	/// <br>                 :   ・更新従業員コード</br>
	/// <br>                 :   ・更新アセンブリID1</br>
	/// <br>                 :   ・更新アセンブリID2</br>
	/// <br>                 :   ・プライマリーキーの削除（インデックスのみ）</br>
	/// </remarks>
	[Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class AddressWork : IFileHeaderOffer, ICloneable
	{
		/// <summary>作成日時</summary>
		/// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
		private DateTime _createDateTime;

		/// <summary>更新日時</summary>
		/// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
		private DateTime _updateDateTime;

		/// <summary>論理削除区分</summary>
		/// <remarks>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</remarks>
		private Int32 _logicalDeleteCode;

		/// <summary>郵便番号</summary>
		private string _postNo = "";

		/// <summary>都道府県コード</summary>
		/// <remarks>都道府県市区群ｺｰﾄﾞの上2桁</remarks>
		private Int32 _addressCode1Upper;

		/// <summary>市区郡コード</summary>
		/// <remarks>都道府県市区群ｺｰﾄﾞの下3桁</remarks>
		private Int32 _addressCode1Lower;

		/// <summary>町村コード</summary>
		private Int32 _addressCode2;

		/// <summary>字コード</summary>
		private Int32 _addressCode3;

		/// <summary>旧郵便番号</summary>
		private string _oldPostNo = "";

		/// <summary>旧都道府県コード</summary>
		/// <remarks>都道府県市区群ｺｰﾄﾞの上2桁</remarks>
		private Int32 _oldAddressCode11;

		/// <summary>旧市区郡コード</summary>
		/// <remarks>都道府県市区群ｺｰﾄﾞの下3桁</remarks>
		private Int32 _oldAddressCode12;

		/// <summary>旧町村コード</summary>
		private Int32 _oldAddressCode2;

		/// <summary>旧字コード</summary>
		private Int32 _oldAddressCode3;

		/// <summary>住所名称</summary>
		private string _addressName = "";

		/// <summary>住所カナ</summary>
		private string _addressKana = "";

		/// <summary>住所連結コード1</summary>
		private Int32 _addrConnectCd1;

		/// <summary>分割住所名称1</summary>
		private string _divAddress1 = "";

		/// <summary>住所連結コード2</summary>
		private Int32 _addrConnectCd2;

		/// <summary>分割住所名称2</summary>
		private string _divAddress2 = "";

		/// <summary>住所連結コード3</summary>
		private Int32 _addrConnectCd3;

		/// <summary>分割住所名称3</summary>
		private string _divAddress3 = "";

		/// <summary>住所連結コード4</summary>
		private Int32 _addrConnectCd4;

		/// <summary>分割住所名称4</summary>
		private string _divAddress4 = "";

		/// <summary>住所連結コード5</summary>
		private Int32 _addrConnectCd5;

		/// <summary>分割住所名称5</summary>
		private string _divAddress5 = "";


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
			get{return _createDateTime;}
			set{_createDateTime = value;}
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
			get{return _updateDateTime;}
			set{_updateDateTime = value;}
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
			get{return _logicalDeleteCode;}
			set{_logicalDeleteCode = value;}
		}

		/// public propaty name  :  PostNo
		/// <summary>郵便番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   郵便番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PostNo
		{
			get{return _postNo;}
			set{_postNo = value;}
		}

		/// public propaty name  :  AddressCode1Upper
		/// <summary>都道府県コードプロパティ</summary>
		/// <value>都道府県市区群ｺｰﾄﾞの上2桁</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   都道府県コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AddressCode1Upper
		{
			get{return _addressCode1Upper;}
			set{_addressCode1Upper = value;}
		}

		/// public propaty name  :  AddressCode1Lower
		/// <summary>市区郡コードプロパティ</summary>
		/// <value>都道府県市区群ｺｰﾄﾞの下3桁</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   市区郡コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AddressCode1Lower
		{
			get{return _addressCode1Lower;}
			set{_addressCode1Lower = value;}
		}

		/// public propaty name  :  AddressCode2
		/// <summary>町村コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   町村コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AddressCode2
		{
			get{return _addressCode2;}
			set{_addressCode2 = value;}
		}

		/// public propaty name  :  AddressCode3
		/// <summary>字コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   字コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AddressCode3
		{
			get{return _addressCode3;}
			set{_addressCode3 = value;}
		}

		/// public propaty name  :  OldPostNo
		/// <summary>旧郵便番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   旧郵便番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string OldPostNo
		{
			get{return _oldPostNo;}
			set{_oldPostNo = value;}
		}

		/// public propaty name  :  OldAddressCode11
		/// <summary>旧都道府県コードプロパティ</summary>
		/// <value>都道府県市区群ｺｰﾄﾞの上2桁</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   旧都道府県コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 OldAddressCode11
		{
			get{return _oldAddressCode11;}
			set{_oldAddressCode11 = value;}
		}

		/// public propaty name  :  OldAddressCode12
		/// <summary>旧市区郡コードプロパティ</summary>
		/// <value>都道府県市区群ｺｰﾄﾞの下3桁</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   旧市区郡コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 OldAddressCode12
		{
			get{return _oldAddressCode12;}
			set{_oldAddressCode12 = value;}
		}

		/// public propaty name  :  OldAddressCode2
		/// <summary>旧町村コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   旧町村コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 OldAddressCode2
		{
			get{return _oldAddressCode2;}
			set{_oldAddressCode2 = value;}
		}

		/// public propaty name  :  OldAddressCode3
		/// <summary>旧字コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   旧字コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 OldAddressCode3
		{
			get{return _oldAddressCode3;}
			set{_oldAddressCode3 = value;}
		}

		/// public propaty name  :  AddressName
		/// <summary>住所名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   住所名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AddressName
		{
			get{return _addressName;}
			set{_addressName = value;}
		}

		/// public propaty name  :  AddressKana
		/// <summary>住所カナプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   住所カナプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AddressKana
		{
			get{return _addressKana;}
			set{_addressKana = value;}
		}

		/// public propaty name  :  AddrConnectCd1
		/// <summary>住所連結コード1プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   住所連結コード1プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AddrConnectCd1
		{
			get{return _addrConnectCd1;}
			set{_addrConnectCd1 = value;}
		}

		/// public propaty name  :  DivAddress1
		/// <summary>分割住所名称1プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   分割住所名称1プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string DivAddress1
		{
			get{return _divAddress1;}
			set{_divAddress1 = value;}
		}

		/// public propaty name  :  AddrConnectCd2
		/// <summary>住所連結コード2プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   住所連結コード2プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AddrConnectCd2
		{
			get{return _addrConnectCd2;}
			set{_addrConnectCd2 = value;}
		}

		/// public propaty name  :  DivAddress2
		/// <summary>分割住所名称2プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   分割住所名称2プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string DivAddress2
		{
			get{return _divAddress2;}
			set{_divAddress2 = value;}
		}

		/// public propaty name  :  AddrConnectCd3
		/// <summary>住所連結コード3プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   住所連結コード3プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AddrConnectCd3
		{
			get{return _addrConnectCd3;}
			set{_addrConnectCd3 = value;}
		}

		/// public propaty name  :  DivAddress3
		/// <summary>分割住所名称3プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   分割住所名称3プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string DivAddress3
		{
			get{return _divAddress3;}
			set{_divAddress3 = value;}
		}

		/// public propaty name  :  AddrConnectCd4
		/// <summary>住所連結コード4プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   住所連結コード4プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AddrConnectCd4
		{
			get{return _addrConnectCd4;}
			set{_addrConnectCd4 = value;}
		}

		/// public propaty name  :  DivAddress4
		/// <summary>分割住所名称4プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   分割住所名称4プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string DivAddress4
		{
			get{return _divAddress4;}
			set{_divAddress4 = value;}
		}

		/// public propaty name  :  AddrConnectCd5
		/// <summary>住所連結コード5プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   住所連結コード5プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AddrConnectCd5
		{
			get{return _addrConnectCd5;}
			set{_addrConnectCd5 = value;}
		}

		/// public propaty name  :  DivAddress5
		/// <summary>分割住所名称5プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   分割住所名称5プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string DivAddress5
		{
			get{return _divAddress5;}
			set{_divAddress5 = value;}
		}


		/// <summary>
		/// 住所ワークコンストラクタ
		/// </summary>
		/// <returns>AddressWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   AddressWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public AddressWork()
		{
		}
		
		#region ICloneable メンバ

        /// <summary>
        /// クローン生成
        /// </summary>
        /// <returns></returns>
		public object Clone()
		{
			return MemberwiseClone();
		}
		
		#endregion
		
	}

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>AddressWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   AddressWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class AddressWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   AddressWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  AddressWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is AddressWork || graph is ArrayList || graph is AddressWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(AddressWork).FullName));

            if (graph != null && graph is AddressWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.AddressWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is AddressWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((AddressWork[])graph).Length;
            }
            else if (graph is AddressWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //作成日時
            serInfo.MemberInfo.Add(typeof(Int64)); //CreateDateTime
            //更新日時
            serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTime
            //論理削除区分
            serInfo.MemberInfo.Add(typeof(Int32)); //LogicalDeleteCode
            //郵便番号
            serInfo.MemberInfo.Add(typeof(string)); //PostNo
            //都道府県コード
            serInfo.MemberInfo.Add(typeof(Int32)); //AddressCode1Upper
            //市区郡コード
            serInfo.MemberInfo.Add(typeof(Int32)); //AddressCode1Lower
            //町村コード
            serInfo.MemberInfo.Add(typeof(Int32)); //AddressCode2
            //字コード
            serInfo.MemberInfo.Add(typeof(Int32)); //AddressCode3
            //旧郵便番号
            serInfo.MemberInfo.Add(typeof(string)); //OldPostNo
            //旧都道府県コード
            serInfo.MemberInfo.Add(typeof(Int32)); //OldAddressCode11
            //旧市区郡コード
            serInfo.MemberInfo.Add(typeof(Int32)); //OldAddressCode12
            //旧町村コード
            serInfo.MemberInfo.Add(typeof(Int32)); //OldAddressCode2
            //旧字コード
            serInfo.MemberInfo.Add(typeof(Int32)); //OldAddressCode3
            //住所名称
            serInfo.MemberInfo.Add(typeof(string)); //AddressName
            //住所カナ
            serInfo.MemberInfo.Add(typeof(string)); //AddressKana
            //住所連結コード1
            serInfo.MemberInfo.Add(typeof(Int32)); //AddrConnectCd1
            //分割住所名称1
            serInfo.MemberInfo.Add(typeof(string)); //DivAddress1
            //住所連結コード2
            serInfo.MemberInfo.Add(typeof(Int32)); //AddrConnectCd2
            //分割住所名称2
            serInfo.MemberInfo.Add(typeof(string)); //DivAddress2
            //住所連結コード3
            serInfo.MemberInfo.Add(typeof(Int32)); //AddrConnectCd3
            //分割住所名称3
            serInfo.MemberInfo.Add(typeof(string)); //DivAddress3
            //住所連結コード4
            serInfo.MemberInfo.Add(typeof(Int32)); //AddrConnectCd4
            //分割住所名称4
            serInfo.MemberInfo.Add(typeof(string)); //DivAddress4
            //住所連結コード5
            serInfo.MemberInfo.Add(typeof(Int32)); //AddrConnectCd5
            //分割住所名称5
            serInfo.MemberInfo.Add(typeof(string)); //DivAddress5


            serInfo.Serialize(writer, serInfo);
            if (graph is AddressWork)
            {
                AddressWork temp = (AddressWork)graph;

                SetAddressWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is AddressWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((AddressWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (AddressWork temp in lst)
                {
                    SetAddressWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// AddressWorkメンバ数(publicプロパティ数)
        /// </summary>
        private const int currentMemberCount = 25;

        /// <summary>
        ///  AddressWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   AddressWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetAddressWork(System.IO.BinaryWriter writer, AddressWork temp)
        {
            //作成日時
            writer.Write((Int64)temp.CreateDateTime.Ticks);
            //更新日時
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
            //論理削除区分
            writer.Write(temp.LogicalDeleteCode);
            //郵便番号
            writer.Write(temp.PostNo);
            //都道府県コード
            writer.Write(temp.AddressCode1Upper);
            //市区郡コード
            writer.Write(temp.AddressCode1Lower);
            //町村コード
            writer.Write(temp.AddressCode2);
            //字コード
            writer.Write(temp.AddressCode3);
            //旧郵便番号
            writer.Write(temp.OldPostNo);
            //旧都道府県コード
            writer.Write(temp.OldAddressCode11);
            //旧市区郡コード
            writer.Write(temp.OldAddressCode12);
            //旧町村コード
            writer.Write(temp.OldAddressCode2);
            //旧字コード
            writer.Write(temp.OldAddressCode3);
            //住所名称
            writer.Write(temp.AddressName);
            //住所カナ
            writer.Write(temp.AddressKana);
            //住所連結コード1
            writer.Write(temp.AddrConnectCd1);
            //分割住所名称1
            writer.Write(temp.DivAddress1);
            //住所連結コード2
            writer.Write(temp.AddrConnectCd2);
            //分割住所名称2
            writer.Write(temp.DivAddress2);
            //住所連結コード3
            writer.Write(temp.AddrConnectCd3);
            //分割住所名称3
            writer.Write(temp.DivAddress3);
            //住所連結コード4
            writer.Write(temp.AddrConnectCd4);
            //分割住所名称4
            writer.Write(temp.DivAddress4);
            //住所連結コード5
            writer.Write(temp.AddrConnectCd5);
            //分割住所名称5
            writer.Write(temp.DivAddress5);

        }

        /// <summary>
        ///  AddressWorkインスタンス取得
        /// </summary>
        /// <returns>AddressWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   AddressWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private AddressWork GetAddressWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            AddressWork temp = new AddressWork();

            //作成日時
            temp.CreateDateTime = new DateTime(reader.ReadInt64());
            //更新日時
            temp.UpdateDateTime = new DateTime(reader.ReadInt64());
            //論理削除区分
            temp.LogicalDeleteCode = reader.ReadInt32();
            //郵便番号
            temp.PostNo = reader.ReadString();
            //都道府県コード
            temp.AddressCode1Upper = reader.ReadInt32();
            //市区郡コード
            temp.AddressCode1Lower = reader.ReadInt32();
            //町村コード
            temp.AddressCode2 = reader.ReadInt32();
            //字コード
            temp.AddressCode3 = reader.ReadInt32();
            //旧郵便番号
            temp.OldPostNo = reader.ReadString();
            //旧都道府県コード
            temp.OldAddressCode11 = reader.ReadInt32();
            //旧市区郡コード
            temp.OldAddressCode12 = reader.ReadInt32();
            //旧町村コード
            temp.OldAddressCode2 = reader.ReadInt32();
            //旧字コード
            temp.OldAddressCode3 = reader.ReadInt32();
            //住所名称
            temp.AddressName = reader.ReadString();
            //住所カナ
            temp.AddressKana = reader.ReadString();
            //住所連結コード1
            temp.AddrConnectCd1 = reader.ReadInt32();
            //分割住所名称1
            temp.DivAddress1 = reader.ReadString();
            //住所連結コード2
            temp.AddrConnectCd2 = reader.ReadInt32();
            //分割住所名称2
            temp.DivAddress2 = reader.ReadString();
            //住所連結コード3
            temp.AddrConnectCd3 = reader.ReadInt32();
            //分割住所名称3
            temp.DivAddress3 = reader.ReadString();
            //住所連結コード4
            temp.AddrConnectCd4 = reader.ReadInt32();
            //分割住所名称4
            temp.DivAddress4 = reader.ReadString();
            //住所連結コード5
            temp.AddrConnectCd5 = reader.ReadInt32();
            //分割住所名称5
            temp.DivAddress5 = reader.ReadString();


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
        /// <returns>AddressWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   AddressWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                AddressWork temp = GetAddressWork(reader, serInfo);
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
                    retValue = (AddressWork[])lst.ToArray(typeof(AddressWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}

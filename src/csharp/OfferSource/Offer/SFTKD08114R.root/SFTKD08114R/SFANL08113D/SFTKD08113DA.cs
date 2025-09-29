using System;
using System.Collections;

using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   PrtItemGrpWork
	/// <summary>
	///                      印字項目グループワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   印字項目グループワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2007/03/15</br>
	/// <br>Genarated Date   :   2007/10/12  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class PrtItemGrpWork : IFileHeaderOffer
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

		/// <summary>自由帳票項目グループコード</summary>
		private Int32 _freePrtPprItemGrpCd;

		/// <summary>自由帳票項目グループ名称</summary>
		private string _freePrtPprItemGrpNm = "";

		/// <summary>帳票使用区分</summary>
		/// <remarks>1:帳票,2:伝票,3:DM一覧表,4:DMはがき</remarks>
		private Int32 _printPaperUseDivcd;

		/// <summary>抽出プログラムID</summary>
		private string _extractionPgId = "";

		/// <summary>抽出プログラムクラスID</summary>
		/// <remarks>印刷プログラムID or テキスト出力プログラムID</remarks>
		private string _extractionPgClassId = "";

		/// <summary>出力プログラムID</summary>
		private string _outputPgId = "";

		/// <summary>出力プログラムクラスID</summary>
		private string _outputPgClassId = "";

		/// <summary>データ入力システム</summary>
		/// <remarks>0:共通,1:整備,2:鈑金,3:車販</remarks>
		private Int32 _dataInputSystem;

		/// <summary>リンク伝票データ入力システム</summary>
		/// <remarks>0:共通,1:整備,2:鈑金,3:車販</remarks>
		private Int32 _linkSlipDataInputSys;

		/// <summary>リンク伝票印刷種別</summary>
		private Int32 _linkSlipPrtKind;

		/// <summary>リンク伝票印刷設定用帳票ID</summary>
		private string _linkSlipPrtSetPprId = "";

		/// <summary>抽出拠点種別区分</summary>
		/// <remarks>0:使用しない 1:実績・請求 2:仕入・販売</remarks>
		private Int32 _extraSectionKindCd;

		/// <summary>抽出拠点選択有無</summary>
		/// <remarks>0:使用しない 1:使用する(複数選択) 2:使用する(単体選択)</remarks>
		private Int32 _extraSectionSelExist;

		/// <summary>改頁行数</summary>
		private Int32 _formFeedLineCount;

		/// <summary>改行文字数</summary>
		/// <remarks>※伝票で作業・部品名称の改行文字数</remarks>
		private Int32 _crCharCnt;

		/// <summary>自由帳票 特種用途区分</summary>
		/// <remarks>0:使用しない,1:案内文印刷タイプ,2:専用帳票,3:官製はがき</remarks>
		private Int32 _freePrtPprSpPrpseCd;


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
			get { return _createDateTime; }
			set { _createDateTime = value; }
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
			get { return _updateDateTime; }
			set { _updateDateTime = value; }
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
			get { return _logicalDeleteCode; }
			set { _logicalDeleteCode = value; }
		}

		/// public propaty name  :  FreePrtPprItemGrpCd
		/// <summary>自由帳票項目グループコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   自由帳票項目グループコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 FreePrtPprItemGrpCd
		{
			get { return _freePrtPprItemGrpCd; }
			set { _freePrtPprItemGrpCd = value; }
		}

		/// public propaty name  :  FreePrtPprItemGrpNm
		/// <summary>自由帳票項目グループ名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   自由帳票項目グループ名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string FreePrtPprItemGrpNm
		{
			get { return _freePrtPprItemGrpNm; }
			set { _freePrtPprItemGrpNm = value; }
		}

		/// public propaty name  :  PrintPaperUseDivcd
		/// <summary>帳票使用区分プロパティ</summary>
		/// <value>1:帳票,2:伝票,3:DM一覧表,4:DMはがき</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   帳票使用区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PrintPaperUseDivcd
		{
			get { return _printPaperUseDivcd; }
			set { _printPaperUseDivcd = value; }
		}

		/// public propaty name  :  ExtractionPgId
		/// <summary>抽出プログラムIDプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   抽出プログラムIDプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string ExtractionPgId
		{
			get { return _extractionPgId; }
			set { _extractionPgId = value; }
		}

		/// public propaty name  :  ExtractionPgClassId
		/// <summary>抽出プログラムクラスIDプロパティ</summary>
		/// <value>印刷プログラムID or テキスト出力プログラムID</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   抽出プログラムクラスIDプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string ExtractionPgClassId
		{
			get { return _extractionPgClassId; }
			set { _extractionPgClassId = value; }
		}

		/// public propaty name  :  OutputPgId
		/// <summary>出力プログラムIDプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   出力プログラムIDプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string OutputPgId
		{
			get { return _outputPgId; }
			set { _outputPgId = value; }
		}

		/// public propaty name  :  OutputPgClassId
		/// <summary>出力プログラムクラスIDプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   出力プログラムクラスIDプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string OutputPgClassId
		{
			get { return _outputPgClassId; }
			set { _outputPgClassId = value; }
		}

		/// public propaty name  :  DataInputSystem
		/// <summary>データ入力システムプロパティ</summary>
		/// <value>0:共通,1:整備,2:鈑金,3:車販</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   データ入力システムプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DataInputSystem
		{
			get { return _dataInputSystem; }
			set { _dataInputSystem = value; }
		}

		/// public propaty name  :  LinkSlipDataInputSys
		/// <summary>リンク伝票データ入力システムプロパティ</summary>
		/// <value>0:共通,1:整備,2:鈑金,3:車販</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   リンク伝票データ入力システムプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 LinkSlipDataInputSys
		{
			get { return _linkSlipDataInputSys; }
			set { _linkSlipDataInputSys = value; }
		}

		/// public propaty name  :  LinkSlipPrtKind
		/// <summary>リンク伝票印刷種別プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   リンク伝票印刷種別プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 LinkSlipPrtKind
		{
			get { return _linkSlipPrtKind; }
			set { _linkSlipPrtKind = value; }
		}

		/// public propaty name  :  LinkSlipPrtSetPprId
		/// <summary>リンク伝票印刷設定用帳票IDプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   リンク伝票印刷設定用帳票IDプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string LinkSlipPrtSetPprId
		{
			get { return _linkSlipPrtSetPprId; }
			set { _linkSlipPrtSetPprId = value; }
		}

		/// public propaty name  :  ExtraSectionKindCd
		/// <summary>抽出拠点種別区分プロパティ</summary>
		/// <value>0:使用しない 1:実績・請求 2:仕入・販売</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   抽出拠点種別区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ExtraSectionKindCd
		{
			get { return _extraSectionKindCd; }
			set { _extraSectionKindCd = value; }
		}

		/// public propaty name  :  ExtraSectionSelExist
		/// <summary>抽出拠点選択有無プロパティ</summary>
		/// <value>0:使用しない 1:使用する(複数選択) 2:使用する(単体選択)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   抽出拠点選択有無プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ExtraSectionSelExist
		{
			get { return _extraSectionSelExist; }
			set { _extraSectionSelExist = value; }
		}

		/// public propaty name  :  FormFeedLineCount
		/// <summary>改頁行数プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   改頁行数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 FormFeedLineCount
		{
			get { return _formFeedLineCount; }
			set { _formFeedLineCount = value; }
		}

		/// public propaty name  :  CrCharCnt
		/// <summary>改行文字数プロパティ</summary>
		/// <value>※伝票で作業・部品名称の改行文字数</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   改行文字数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CrCharCnt
		{
			get { return _crCharCnt; }
			set { _crCharCnt = value; }
		}

		/// public propaty name  :  FreePrtPprSpPrpseCd
		/// <summary>自由帳票 特種用途区分プロパティ</summary>
		/// <value>0:使用しない,1:案内文印刷タイプ,2:専用帳票,3:官製はがき</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   自由帳票 特種用途区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 FreePrtPprSpPrpseCd
		{
			get { return _freePrtPprSpPrpseCd; }
			set { _freePrtPprSpPrpseCd = value; }
		}


		/// <summary>
		/// 印字項目グループワークコンストラクタ
		/// </summary>
		/// <returns>PrtItemGrpWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   PrtItemGrpWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public PrtItemGrpWork()
		{
		}

	}

	/// <summary>
	///  Ver5.10.1.0用のカスタムシライアライザです。
	/// </summary>
	/// <returns>PrtItemGrpWorkクラスのインスタンス(object)</returns>
	/// <remarks>
	/// <br>Note　　　　　　 :   PrtItemGrpWorkクラスのカスタムシリアライザを定義します</br>
	/// <br>Programer        :   自動生成</br>
	/// </remarks>
	public class PrtItemGrpWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
	{
		#region ICustomSerializationSurrogate メンバ

		/// <summary>
		///  Ver5.10.1.0用のカスタムシリアライザです
		/// </summary>
		/// <remarks>
		/// <br>Note　　　　　　 :   PrtItemGrpWorkクラスのカスタムシリアライザを定義します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public void Serialize(System.IO.BinaryWriter writer, object graph)
		{
			// TODO:  PrtItemGrpWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
			if (writer == null)
				throw new ArgumentNullException();

			if (graph != null && !(graph is PrtItemGrpWork || graph is ArrayList || graph is PrtItemGrpWork[]))
				throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(PrtItemGrpWork).FullName));

			if (graph != null && graph is PrtItemGrpWork)
			{
				Type t = graph.GetType();
				if (!CustomFormatterServices.NeedCustomSerialization(t))
					throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
			}

			//SerializationTypeInfo
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.PrtItemGrpWork");

			//繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
			int occurrence = 0;     //一般にゼロの場合もありえます
			if (graph is ArrayList)
			{
				serInfo.RetTypeInfo = 0;
				occurrence = ((ArrayList)graph).Count;
			}
			else if (graph is PrtItemGrpWork[])
			{
				serInfo.RetTypeInfo = 2;
				occurrence = ((PrtItemGrpWork[])graph).Length;
			}
			else if (graph is PrtItemGrpWork)
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
			//自由帳票項目グループコード
			serInfo.MemberInfo.Add(typeof(Int32)); //FreePrtPprItemGrpCd
			//自由帳票項目グループ名称
			serInfo.MemberInfo.Add(typeof(string)); //FreePrtPprItemGrpNm
			//帳票使用区分
			serInfo.MemberInfo.Add(typeof(Int32)); //PrintPaperUseDivcd
			//抽出プログラムID
			serInfo.MemberInfo.Add(typeof(string)); //ExtractionPgId
			//抽出プログラムクラスID
			serInfo.MemberInfo.Add(typeof(string)); //ExtractionPgClassId
			//出力プログラムID
			serInfo.MemberInfo.Add(typeof(string)); //OutputPgId
			//出力プログラムクラスID
			serInfo.MemberInfo.Add(typeof(string)); //OutputPgClassId
			//データ入力システム
			serInfo.MemberInfo.Add(typeof(Int32)); //DataInputSystem
			//リンク伝票データ入力システム
			serInfo.MemberInfo.Add(typeof(Int32)); //LinkSlipDataInputSys
			//リンク伝票印刷種別
			serInfo.MemberInfo.Add(typeof(Int32)); //LinkSlipPrtKind
			//リンク伝票印刷設定用帳票ID
			serInfo.MemberInfo.Add(typeof(string)); //LinkSlipPrtSetPprId
			//抽出拠点種別区分
			serInfo.MemberInfo.Add(typeof(Int32)); //ExtraSectionKindCd
			//抽出拠点選択有無
			serInfo.MemberInfo.Add(typeof(Int32)); //ExtraSectionSelExist
			//改頁行数
			serInfo.MemberInfo.Add(typeof(Int32)); //FormFeedLineCount
			//改行文字数
			serInfo.MemberInfo.Add(typeof(Int32)); //CrCharCnt
			//自由帳票 特種用途区分
			serInfo.MemberInfo.Add(typeof(Int32)); //FreePrtPprSpPrpseCd


			serInfo.Serialize(writer, serInfo);
			if (graph is PrtItemGrpWork)
			{
				PrtItemGrpWork temp = (PrtItemGrpWork)graph;

				SetPrtItemGrpWork(writer, temp);
			}
			else
			{
				ArrayList lst = null;
				if (graph is PrtItemGrpWork[])
				{
					lst = new ArrayList();
					lst.AddRange((PrtItemGrpWork[])graph);
				}
				else
				{
					lst = (ArrayList)graph;
				}

				foreach (PrtItemGrpWork temp in lst)
				{
					SetPrtItemGrpWork(writer, temp);
				}

			}


		}


		/// <summary>
		/// PrtItemGrpWorkメンバ数(publicプロパティ数)
		/// </summary>
		private const int currentMemberCount = 19;

		/// <summary>
		///  PrtItemGrpWorkインスタンス書き込み
		/// </summary>
		/// <remarks>
		/// <br>Note　　　　　　 :   PrtItemGrpWorkのインスタンスを書き込み</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		private void SetPrtItemGrpWork(System.IO.BinaryWriter writer, PrtItemGrpWork temp)
		{
			//作成日時
			writer.Write((Int64)temp.CreateDateTime.Ticks);
			//更新日時
			writer.Write((Int64)temp.UpdateDateTime.Ticks);
			//論理削除区分
			writer.Write(temp.LogicalDeleteCode);
			//自由帳票項目グループコード
			writer.Write(temp.FreePrtPprItemGrpCd);
			//自由帳票項目グループ名称
			writer.Write(temp.FreePrtPprItemGrpNm);
			//帳票使用区分
			writer.Write(temp.PrintPaperUseDivcd);
			//抽出プログラムID
			writer.Write(temp.ExtractionPgId);
			//抽出プログラムクラスID
			writer.Write(temp.ExtractionPgClassId);
			//出力プログラムID
			writer.Write(temp.OutputPgId);
			//出力プログラムクラスID
			writer.Write(temp.OutputPgClassId);
			//データ入力システム
			writer.Write(temp.DataInputSystem);
			//リンク伝票データ入力システム
			writer.Write(temp.LinkSlipDataInputSys);
			//リンク伝票印刷種別
			writer.Write(temp.LinkSlipPrtKind);
			//リンク伝票印刷設定用帳票ID
			writer.Write(temp.LinkSlipPrtSetPprId);
			//抽出拠点種別区分
			writer.Write(temp.ExtraSectionKindCd);
			//抽出拠点選択有無
			writer.Write(temp.ExtraSectionSelExist);
			//改頁行数
			writer.Write(temp.FormFeedLineCount);
			//改行文字数
			writer.Write(temp.CrCharCnt);
			//自由帳票 特種用途区分
			writer.Write(temp.FreePrtPprSpPrpseCd);

		}

		/// <summary>
		///  PrtItemGrpWorkインスタンス取得
		/// </summary>
		/// <returns>PrtItemGrpWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   PrtItemGrpWorkのインスタンスを取得します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		private PrtItemGrpWork GetPrtItemGrpWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
		{
			// V5.1.0.0なので不要ですが、V5.1.0.1以降では
			// serInfo.MemberInfo.Count < currentMemberCount
			// のケースについての配慮が必要になります。

			PrtItemGrpWork temp = new PrtItemGrpWork();

			//作成日時
			temp.CreateDateTime = new DateTime(reader.ReadInt64());
			//更新日時
			temp.UpdateDateTime = new DateTime(reader.ReadInt64());
			//論理削除区分
			temp.LogicalDeleteCode = reader.ReadInt32();
			//自由帳票項目グループコード
			temp.FreePrtPprItemGrpCd = reader.ReadInt32();
			//自由帳票項目グループ名称
			temp.FreePrtPprItemGrpNm = reader.ReadString();
			//帳票使用区分
			temp.PrintPaperUseDivcd = reader.ReadInt32();
			//抽出プログラムID
			temp.ExtractionPgId = reader.ReadString();
			//抽出プログラムクラスID
			temp.ExtractionPgClassId = reader.ReadString();
			//出力プログラムID
			temp.OutputPgId = reader.ReadString();
			//出力プログラムクラスID
			temp.OutputPgClassId = reader.ReadString();
			//データ入力システム
			temp.DataInputSystem = reader.ReadInt32();
			//リンク伝票データ入力システム
			temp.LinkSlipDataInputSys = reader.ReadInt32();
			//リンク伝票印刷種別
			temp.LinkSlipPrtKind = reader.ReadInt32();
			//リンク伝票印刷設定用帳票ID
			temp.LinkSlipPrtSetPprId = reader.ReadString();
			//抽出拠点種別区分
			temp.ExtraSectionKindCd = reader.ReadInt32();
			//抽出拠点選択有無
			temp.ExtraSectionSelExist = reader.ReadInt32();
			//改頁行数
			temp.FormFeedLineCount = reader.ReadInt32();
			//改行文字数
			temp.CrCharCnt = reader.ReadInt32();
			//自由帳票 特種用途区分
			temp.FreePrtPprSpPrpseCd = reader.ReadInt32();


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
		/// <returns>PrtItemGrpWorkクラスのインスタンス(object)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   PrtItemGrpWorkクラスのカスタムデシリアライザを定義します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public object Deserialize(System.IO.BinaryReader reader)
		{
			object retValue = null;
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
			ArrayList lst = new ArrayList();
			for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
			{
				PrtItemGrpWork temp = GetPrtItemGrpWork(reader, serInfo);
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
					retValue = (PrtItemGrpWork[])lst.ToArray(typeof(PrtItemGrpWork));
					break;
			}
			return retValue;
		}

		#endregion
	}

}

using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   FPECndInitWork
	/// <summary>
	///                      自由帳票抽出条件初期値ワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   自由帳票抽出条件初期値ワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2007/10/10</br>
	/// <br>Genarated Date   :   2007/10/11  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class FPECndInitWork : IFileHeaderOffer
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

		/// <summary>自由帳票スキーマグループコード</summary>
		private Int32 _freePrtPprSchmGrpCd;

		/// <summary>自由帳票抽出条件枝番</summary>
		private Int32 _frePrtPprExtraCondCd;

		/// <summary>表示順位</summary>
		private Int32 _displayOrder;

		/// <summary>抽出開始コード（数値）</summary>
		private Int64 _stExtraNumCode;

		/// <summary>抽出終了コード（数値）</summary>
		private Int64 _edExtraNumCode;

		/// <summary>抽出開始コード（文字）</summary>
		private string _stExtraCharCode = "";

		/// <summary>抽出終了コード（文字）</summary>
		private string _edExtraCharCode = "";

		/// <summary>抽出開始日付（基準）</summary>
		/// <remarks>0:前々日,1:前日,2:本日,3:翌日,4:翌々日,5:日付指定</remarks>
		private Int32 _stExtraDateBaseCd;

		/// <summary>抽出開始日付（正負）</summary>
		/// <remarks>0:＋（プラス）,1:－（マイナス）</remarks>
		private Int32 _stExtraDateSignCd;

		/// <summary>抽出開始日付（数値）</summary>
		private Int32 _stExtraDateNum;

		/// <summary>抽出開始日付（単位）</summary>
		/// <remarks>0:日,1:週,2:月,3:年</remarks>
		private Int32 _stExtraDateUnitCd;

		/// <summary>抽出開始日付（日付）</summary>
		private Int32 _startExtraDate;

		/// <summary>抽出終了日付（基準）</summary>
		/// <remarks>0:前々日,1:前日,2:本日,3:翌日,4:翌々日,5:日付指定</remarks>
		private Int32 _edExtraDateBaseCd;

		/// <summary>抽出終了日付（正負）</summary>
		/// <remarks>0:＋（プラス）,1:－（マイナス）</remarks>
		private Int32 _edExtraDateSignCd;

		/// <summary>抽出終了日付（数値）</summary>
		private Int32 _edExtraDateNum;

		/// <summary>抽出終了日付（単位）</summary>
		/// <remarks>0:日,1:週,2:月,3:年</remarks>
		private Int32 _edExtraDateUnitCd;

		/// <summary>抽出終了日付（日付）</summary>
		private Int32 _endExtraDate;

		/// <summary>チェック項目コード1</summary>
		private Int32 _checkItemCode1;

		/// <summary>チェック項目コード2</summary>
		private Int32 _checkItemCode2;

		/// <summary>チェック項目コード3</summary>
		private Int32 _checkItemCode3;

		/// <summary>チェック項目コード4</summary>
		private Int32 _checkItemCode4;

		/// <summary>チェック項目コード5</summary>
		private Int32 _checkItemCode5;

		/// <summary>チェック項目コード6</summary>
		private Int32 _checkItemCode6;

		/// <summary>チェック項目コード7</summary>
		private Int32 _checkItemCode7;

		/// <summary>チェック項目コード8</summary>
		private Int32 _checkItemCode8;

		/// <summary>チェック項目コード9</summary>
		private Int32 _checkItemCode9;

		/// <summary>チェック項目コード10</summary>
		private Int32 _checkItemCode10;


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

		/// public propaty name  :  FreePrtPprSchmGrpCd
		/// <summary>自由帳票スキーマグループコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   自由帳票スキーマグループコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 FreePrtPprSchmGrpCd
		{
			get{return _freePrtPprSchmGrpCd;}
			set{_freePrtPprSchmGrpCd = value;}
		}

		/// public propaty name  :  FrePrtPprExtraCondCd
		/// <summary>自由帳票抽出条件枝番プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   自由帳票抽出条件枝番プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 FrePrtPprExtraCondCd
		{
			get{return _frePrtPprExtraCondCd;}
			set{_frePrtPprExtraCondCd = value;}
		}

		/// public propaty name  :  DisplayOrder
		/// <summary>表示順位プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   表示順位プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DisplayOrder
		{
			get{return _displayOrder;}
			set{_displayOrder = value;}
		}

		/// public propaty name  :  StExtraNumCode
		/// <summary>抽出開始コード（数値）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   抽出開始コード（数値）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 StExtraNumCode
		{
			get{return _stExtraNumCode;}
			set{_stExtraNumCode = value;}
		}

		/// public propaty name  :  EdExtraNumCode
		/// <summary>抽出終了コード（数値）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   抽出終了コード（数値）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 EdExtraNumCode
		{
			get{return _edExtraNumCode;}
			set{_edExtraNumCode = value;}
		}

		/// public propaty name  :  StExtraCharCode
		/// <summary>抽出開始コード（文字）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   抽出開始コード（文字）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string StExtraCharCode
		{
			get{return _stExtraCharCode;}
			set{_stExtraCharCode = value;}
		}

		/// public propaty name  :  EdExtraCharCode
		/// <summary>抽出終了コード（文字）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   抽出終了コード（文字）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EdExtraCharCode
		{
			get{return _edExtraCharCode;}
			set{_edExtraCharCode = value;}
		}

		/// public propaty name  :  StExtraDateBaseCd
		/// <summary>抽出開始日付（基準）プロパティ</summary>
		/// <value>0:前々日,1:前日,2:本日,3:翌日,4:翌々日,5:日付指定</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   抽出開始日付（基準）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StExtraDateBaseCd
		{
			get{return _stExtraDateBaseCd;}
			set{_stExtraDateBaseCd = value;}
		}

		/// public propaty name  :  StExtraDateSignCd
		/// <summary>抽出開始日付（正負）プロパティ</summary>
		/// <value>0:＋（プラス）,1:－（マイナス）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   抽出開始日付（正負）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StExtraDateSignCd
		{
			get{return _stExtraDateSignCd;}
			set{_stExtraDateSignCd = value;}
		}

		/// public propaty name  :  StExtraDateNum
		/// <summary>抽出開始日付（数値）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   抽出開始日付（数値）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StExtraDateNum
		{
			get{return _stExtraDateNum;}
			set{_stExtraDateNum = value;}
		}

		/// public propaty name  :  StExtraDateUnitCd
		/// <summary>抽出開始日付（単位）プロパティ</summary>
		/// <value>0:日,1:週,2:月,3:年</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   抽出開始日付（単位）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StExtraDateUnitCd
		{
			get{return _stExtraDateUnitCd;}
			set{_stExtraDateUnitCd = value;}
		}

		/// public propaty name  :  StartExtraDate
		/// <summary>抽出開始日付（日付）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   抽出開始日付（日付）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StartExtraDate
		{
			get{return _startExtraDate;}
			set{_startExtraDate = value;}
		}

		/// public propaty name  :  EdExtraDateBaseCd
		/// <summary>抽出終了日付（基準）プロパティ</summary>
		/// <value>0:前々日,1:前日,2:本日,3:翌日,4:翌々日,5:日付指定</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   抽出終了日付（基準）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EdExtraDateBaseCd
		{
			get{return _edExtraDateBaseCd;}
			set{_edExtraDateBaseCd = value;}
		}

		/// public propaty name  :  EdExtraDateSignCd
		/// <summary>抽出終了日付（正負）プロパティ</summary>
		/// <value>0:＋（プラス）,1:－（マイナス）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   抽出終了日付（正負）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EdExtraDateSignCd
		{
			get{return _edExtraDateSignCd;}
			set{_edExtraDateSignCd = value;}
		}

		/// public propaty name  :  EdExtraDateNum
		/// <summary>抽出終了日付（数値）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   抽出終了日付（数値）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EdExtraDateNum
		{
			get{return _edExtraDateNum;}
			set{_edExtraDateNum = value;}
		}

		/// public propaty name  :  EdExtraDateUnitCd
		/// <summary>抽出終了日付（単位）プロパティ</summary>
		/// <value>0:日,1:週,2:月,3:年</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   抽出終了日付（単位）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EdExtraDateUnitCd
		{
			get{return _edExtraDateUnitCd;}
			set{_edExtraDateUnitCd = value;}
		}

		/// public propaty name  :  EndExtraDate
		/// <summary>抽出終了日付（日付）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   抽出終了日付（日付）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EndExtraDate
		{
			get{return _endExtraDate;}
			set{_endExtraDate = value;}
		}

		/// public propaty name  :  CheckItemCode1
		/// <summary>チェック項目コード1プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   チェック項目コード1プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CheckItemCode1
		{
			get{return _checkItemCode1;}
			set{_checkItemCode1 = value;}
		}

		/// public propaty name  :  CheckItemCode2
		/// <summary>チェック項目コード2プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   チェック項目コード2プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CheckItemCode2
		{
			get{return _checkItemCode2;}
			set{_checkItemCode2 = value;}
		}

		/// public propaty name  :  CheckItemCode3
		/// <summary>チェック項目コード3プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   チェック項目コード3プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CheckItemCode3
		{
			get{return _checkItemCode3;}
			set{_checkItemCode3 = value;}
		}

		/// public propaty name  :  CheckItemCode4
		/// <summary>チェック項目コード4プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   チェック項目コード4プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CheckItemCode4
		{
			get{return _checkItemCode4;}
			set{_checkItemCode4 = value;}
		}

		/// public propaty name  :  CheckItemCode5
		/// <summary>チェック項目コード5プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   チェック項目コード5プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CheckItemCode5
		{
			get{return _checkItemCode5;}
			set{_checkItemCode5 = value;}
		}

		/// public propaty name  :  CheckItemCode6
		/// <summary>チェック項目コード6プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   チェック項目コード6プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CheckItemCode6
		{
			get{return _checkItemCode6;}
			set{_checkItemCode6 = value;}
		}

		/// public propaty name  :  CheckItemCode7
		/// <summary>チェック項目コード7プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   チェック項目コード7プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CheckItemCode7
		{
			get{return _checkItemCode7;}
			set{_checkItemCode7 = value;}
		}

		/// public propaty name  :  CheckItemCode8
		/// <summary>チェック項目コード8プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   チェック項目コード8プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CheckItemCode8
		{
			get{return _checkItemCode8;}
			set{_checkItemCode8 = value;}
		}

		/// public propaty name  :  CheckItemCode9
		/// <summary>チェック項目コード9プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   チェック項目コード9プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CheckItemCode9
		{
			get{return _checkItemCode9;}
			set{_checkItemCode9 = value;}
		}

		/// public propaty name  :  CheckItemCode10
		/// <summary>チェック項目コード10プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   チェック項目コード10プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CheckItemCode10
		{
			get{return _checkItemCode10;}
			set{_checkItemCode10 = value;}
		}


		/// <summary>
		/// 自由帳票抽出条件初期値ワークコンストラクタ
		/// </summary>
		/// <returns>FPECndInitWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   FPECndInitWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public FPECndInitWork()
		{
		}

	}

	/// <summary>
	///  Ver5.10.1.0用のカスタムシライアライザです。
	/// </summary>
	/// <returns>FPECndInitWorkクラスのインスタンス(object)</returns>
	/// <remarks>
	/// <br>Note　　　　　　 :   FPECndInitWorkクラスのカスタムシリアライザを定義します</br>
	/// <br>Programer        :   自動生成</br>
	/// </remarks>
	public class FPECndInitWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
	{
		#region ICustomSerializationSurrogate メンバ
		
		/// <summary>
		///  Ver5.10.1.0用のカスタムシリアライザです
		/// </summary>
		/// <remarks>
		/// <br>Note　　　　　　 :   FPECndInitWorkクラスのカスタムシリアライザを定義します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public void Serialize(System.IO.BinaryWriter writer, object graph)
		{
			// TODO:  FPECndInitWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
			if(  writer == null )
				throw new ArgumentNullException();

			if( graph != null && !( graph is FPECndInitWork || graph is ArrayList || graph is FPECndInitWork[]) )
				throw new ArgumentException( string.Format( "graphが{0}のインスタンスでありません", typeof(FPECndInitWork).FullName ) );

			if( graph != null && graph is FPECndInitWork )
			{
				Type t = graph.GetType();
				if( !CustomFormatterServices.NeedCustomSerialization( t ) )
					throw new ArgumentException( string.Format( "graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName ) );
			}

			//SerializationTypeInfo
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo( ", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.FPECndInitWork" );

			//繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
			int occurrence = 0;     //一般にゼロの場合もありえます
			if( graph is ArrayList )
			{
				serInfo.RetTypeInfo = 0;
				occurrence = ((ArrayList)graph).Count;
			}else if( graph is FPECndInitWork[] )
			{
				serInfo.RetTypeInfo = 2;
				occurrence = ((FPECndInitWork[])graph).Length;
			}
			else if( graph is FPECndInitWork )
			{
				serInfo.RetTypeInfo = 1;
				occurrence = 1;
			}

			serInfo.Occurrence = occurrence;		 //繰り返し数	

			//作成日時
			serInfo.MemberInfo.Add( typeof(Int64) ); //CreateDateTime
			//更新日時
			serInfo.MemberInfo.Add( typeof(Int64) ); //UpdateDateTime
			//論理削除区分
			serInfo.MemberInfo.Add( typeof(Int32) ); //LogicalDeleteCode
			//自由帳票スキーマグループコード
			serInfo.MemberInfo.Add( typeof(Int32) ); //FreePrtPprSchmGrpCd
			//自由帳票抽出条件枝番
			serInfo.MemberInfo.Add( typeof(Int32) ); //FrePrtPprExtraCondCd
			//表示順位
			serInfo.MemberInfo.Add( typeof(Int32) ); //DisplayOrder
			//抽出開始コード（数値）
			serInfo.MemberInfo.Add( typeof(Int64) ); //StExtraNumCode
			//抽出終了コード（数値）
			serInfo.MemberInfo.Add( typeof(Int64) ); //EdExtraNumCode
			//抽出開始コード（文字）
			serInfo.MemberInfo.Add( typeof(string) ); //StExtraCharCode
			//抽出終了コード（文字）
			serInfo.MemberInfo.Add( typeof(string) ); //EdExtraCharCode
			//抽出開始日付（基準）
			serInfo.MemberInfo.Add( typeof(Int32) ); //StExtraDateBaseCd
			//抽出開始日付（正負）
			serInfo.MemberInfo.Add( typeof(Int32) ); //StExtraDateSignCd
			//抽出開始日付（数値）
			serInfo.MemberInfo.Add( typeof(Int32) ); //StExtraDateNum
			//抽出開始日付（単位）
			serInfo.MemberInfo.Add( typeof(Int32) ); //StExtraDateUnitCd
			//抽出開始日付（日付）
			serInfo.MemberInfo.Add( typeof(Int32) ); //StartExtraDate
			//抽出終了日付（基準）
			serInfo.MemberInfo.Add( typeof(Int32) ); //EdExtraDateBaseCd
			//抽出終了日付（正負）
			serInfo.MemberInfo.Add( typeof(Int32) ); //EdExtraDateSignCd
			//抽出終了日付（数値）
			serInfo.MemberInfo.Add( typeof(Int32) ); //EdExtraDateNum
			//抽出終了日付（単位）
			serInfo.MemberInfo.Add( typeof(Int32) ); //EdExtraDateUnitCd
			//抽出終了日付（日付）
			serInfo.MemberInfo.Add( typeof(Int32) ); //EndExtraDate
			//チェック項目コード1
			serInfo.MemberInfo.Add( typeof(Int32) ); //CheckItemCode1
			//チェック項目コード2
			serInfo.MemberInfo.Add( typeof(Int32) ); //CheckItemCode2
			//チェック項目コード3
			serInfo.MemberInfo.Add( typeof(Int32) ); //CheckItemCode3
			//チェック項目コード4
			serInfo.MemberInfo.Add( typeof(Int32) ); //CheckItemCode4
			//チェック項目コード5
			serInfo.MemberInfo.Add( typeof(Int32) ); //CheckItemCode5
			//チェック項目コード6
			serInfo.MemberInfo.Add( typeof(Int32) ); //CheckItemCode6
			//チェック項目コード7
			serInfo.MemberInfo.Add( typeof(Int32) ); //CheckItemCode7
			//チェック項目コード8
			serInfo.MemberInfo.Add( typeof(Int32) ); //CheckItemCode8
			//チェック項目コード9
			serInfo.MemberInfo.Add( typeof(Int32) ); //CheckItemCode9
			//チェック項目コード10
			serInfo.MemberInfo.Add( typeof(Int32) ); //CheckItemCode10

				
			serInfo.Serialize( writer, serInfo );
			if( graph is FPECndInitWork )
			{
				FPECndInitWork temp = (FPECndInitWork)graph;

				SetFPECndInitWork(writer, temp);
			}
			else
			{
				ArrayList lst= null;
				if(graph is FPECndInitWork[])
				{
					lst = new ArrayList();
					lst.AddRange((FPECndInitWork[])graph);
				}
				else
				{
					lst = (ArrayList)graph;	
				}

				foreach(FPECndInitWork temp in lst)
				{
					SetFPECndInitWork(writer, temp);
				}

			}

			
		}


		/// <summary>
		/// FPECndInitWorkメンバ数(publicプロパティ数)
		/// </summary>
		private const int currentMemberCount = 30;
			
		/// <summary>
		///  FPECndInitWorkインスタンス書き込み
		/// </summary>
		/// <remarks>
		/// <br>Note　　　　　　 :   FPECndInitWorkのインスタンスを書き込み</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		private void SetFPECndInitWork( System.IO.BinaryWriter writer, FPECndInitWork temp )
		{
			//作成日時
			writer.Write( (Int64)temp.CreateDateTime.Ticks );
			//更新日時
			writer.Write( (Int64)temp.UpdateDateTime.Ticks );
			//論理削除区分
			writer.Write( temp.LogicalDeleteCode );
			//自由帳票スキーマグループコード
			writer.Write( temp.FreePrtPprSchmGrpCd );
			//自由帳票抽出条件枝番
			writer.Write( temp.FrePrtPprExtraCondCd );
			//表示順位
			writer.Write( temp.DisplayOrder );
			//抽出開始コード（数値）
			writer.Write( temp.StExtraNumCode );
			//抽出終了コード（数値）
			writer.Write( temp.EdExtraNumCode );
			//抽出開始コード（文字）
			writer.Write( temp.StExtraCharCode );
			//抽出終了コード（文字）
			writer.Write( temp.EdExtraCharCode );
			//抽出開始日付（基準）
			writer.Write( temp.StExtraDateBaseCd );
			//抽出開始日付（正負）
			writer.Write( temp.StExtraDateSignCd );
			//抽出開始日付（数値）
			writer.Write( temp.StExtraDateNum );
			//抽出開始日付（単位）
			writer.Write( temp.StExtraDateUnitCd );
			//抽出開始日付（日付）
			writer.Write( temp.StartExtraDate );
			//抽出終了日付（基準）
			writer.Write( temp.EdExtraDateBaseCd );
			//抽出終了日付（正負）
			writer.Write( temp.EdExtraDateSignCd );
			//抽出終了日付（数値）
			writer.Write( temp.EdExtraDateNum );
			//抽出終了日付（単位）
			writer.Write( temp.EdExtraDateUnitCd );
			//抽出終了日付（日付）
			writer.Write( temp.EndExtraDate );
			//チェック項目コード1
			writer.Write( temp.CheckItemCode1 );
			//チェック項目コード2
			writer.Write( temp.CheckItemCode2 );
			//チェック項目コード3
			writer.Write( temp.CheckItemCode3 );
			//チェック項目コード4
			writer.Write( temp.CheckItemCode4 );
			//チェック項目コード5
			writer.Write( temp.CheckItemCode5 );
			//チェック項目コード6
			writer.Write( temp.CheckItemCode6 );
			//チェック項目コード7
			writer.Write( temp.CheckItemCode7 );
			//チェック項目コード8
			writer.Write( temp.CheckItemCode8 );
			//チェック項目コード9
			writer.Write( temp.CheckItemCode9 );
			//チェック項目コード10
			writer.Write( temp.CheckItemCode10 );

		}

		/// <summary>
		///  FPECndInitWorkインスタンス取得
		/// </summary>
		/// <returns>FPECndInitWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   FPECndInitWorkのインスタンスを取得します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		private FPECndInitWork GetFPECndInitWork( System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo )
		{
			// V5.1.0.0なので不要ですが、V5.1.0.1以降では
			// serInfo.MemberInfo.Count < currentMemberCount
			// のケースについての配慮が必要になります。

			FPECndInitWork temp = new FPECndInitWork();

			//作成日時
			temp.CreateDateTime = new DateTime(reader.ReadInt64());
			//更新日時
			temp.UpdateDateTime = new DateTime(reader.ReadInt64());
			//論理削除区分
			temp.LogicalDeleteCode = reader.ReadInt32();
			//自由帳票スキーマグループコード
			temp.FreePrtPprSchmGrpCd = reader.ReadInt32();
			//自由帳票抽出条件枝番
			temp.FrePrtPprExtraCondCd = reader.ReadInt32();
			//表示順位
			temp.DisplayOrder = reader.ReadInt32();
			//抽出開始コード（数値）
			temp.StExtraNumCode = reader.ReadInt64();
			//抽出終了コード（数値）
			temp.EdExtraNumCode = reader.ReadInt64();
			//抽出開始コード（文字）
			temp.StExtraCharCode = reader.ReadString();
			//抽出終了コード（文字）
			temp.EdExtraCharCode = reader.ReadString();
			//抽出開始日付（基準）
			temp.StExtraDateBaseCd = reader.ReadInt32();
			//抽出開始日付（正負）
			temp.StExtraDateSignCd = reader.ReadInt32();
			//抽出開始日付（数値）
			temp.StExtraDateNum = reader.ReadInt32();
			//抽出開始日付（単位）
			temp.StExtraDateUnitCd = reader.ReadInt32();
			//抽出開始日付（日付）
			temp.StartExtraDate = reader.ReadInt32();
			//抽出終了日付（基準）
			temp.EdExtraDateBaseCd = reader.ReadInt32();
			//抽出終了日付（正負）
			temp.EdExtraDateSignCd = reader.ReadInt32();
			//抽出終了日付（数値）
			temp.EdExtraDateNum = reader.ReadInt32();
			//抽出終了日付（単位）
			temp.EdExtraDateUnitCd = reader.ReadInt32();
			//抽出終了日付（日付）
			temp.EndExtraDate = reader.ReadInt32();
			//チェック項目コード1
			temp.CheckItemCode1 = reader.ReadInt32();
			//チェック項目コード2
			temp.CheckItemCode2 = reader.ReadInt32();
			//チェック項目コード3
			temp.CheckItemCode3 = reader.ReadInt32();
			//チェック項目コード4
			temp.CheckItemCode4 = reader.ReadInt32();
			//チェック項目コード5
			temp.CheckItemCode5 = reader.ReadInt32();
			//チェック項目コード6
			temp.CheckItemCode6 = reader.ReadInt32();
			//チェック項目コード7
			temp.CheckItemCode7 = reader.ReadInt32();
			//チェック項目コード8
			temp.CheckItemCode8 = reader.ReadInt32();
			//チェック項目コード9
			temp.CheckItemCode9 = reader.ReadInt32();
			//チェック項目コード10
			temp.CheckItemCode10 = reader.ReadInt32();

				
			//以下は読み飛ばしです。このバージョンが想定する EmployeeWork型以降のバージョンの
			//データをデシリアライズする場合、シリアライズしたフォーマッタが記述した
			//型情報にしたがって、ストリームから情報を読み出します...といっても
			//読み出して捨てることになります。
			for( int k = currentMemberCount ; k < serInfo.MemberInfo.Count ; ++k )
			{
				//byte[],char[]をデシリアライズする直前に、そのlengthが
				//デシリアライズされているケースがある、byte[],char[]の
				//デシリアライズにはlengthが必要なのでint型のデータをデ
				//シリアライズした場合は、この値をこの変数に退避します。
				int optCount = 0;   
				object oMemberType = serInfo.MemberInfo[k];
				if( oMemberType is Type )
				{
					Type t = (Type)oMemberType;
					object oData = TypeDeserializer.DeserializePrimitiveType( reader, t, optCount );
					if( t.Equals( typeof(int) ) )
					{
						optCount = Convert.ToInt32(oData);
					}
					else
					{
						optCount = 0;
					}
				}
				else if( oMemberType is string )
				{
					Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate( (string)oMemberType );
					object userData = formatter.Deserialize( reader );  //読み飛ばし
				}
			}
			return temp;
		}

		/// <summary>
		///  Ver5.10.1.0用のカスタムデシリアライザです
		/// </summary>
		/// <returns>FPECndInitWorkクラスのインスタンス(object)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   FPECndInitWorkクラスのカスタムデシリアライザを定義します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public object Deserialize(System.IO.BinaryReader reader)
		{
			object retValue = null;
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject( reader );
			ArrayList lst = new ArrayList();
			for( int cnt = 0 ; cnt < serInfo.Occurrence ; ++cnt )
			{
				FPECndInitWork temp = GetFPECndInitWork( reader, serInfo );
				lst.Add( temp );
			}
			switch(serInfo.RetTypeInfo)
			{
				case 0:
					retValue = lst;
					break;
				case 1:
					retValue = lst[0];
					break;
				case 2:
					retValue = (FPECndInitWork[])lst.ToArray(typeof(FPECndInitWork));
					break;
			}
			return retValue;
		}

		#endregion
	}

}

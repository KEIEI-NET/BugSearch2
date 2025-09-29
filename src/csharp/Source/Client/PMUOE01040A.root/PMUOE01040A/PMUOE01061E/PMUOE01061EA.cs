using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   OrderLsthead
	/// <summary>
	///                      注文一覧クラス
	/// </summary>
	/// <remarks>
	/// <br>note             :   注文一覧クラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2009/05/27  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class OrderLsthead
	{
		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private String _enterpriseCode;

		/// <summary>拠点コード</summary>
		private String _sectionCode;

		/// <summary>UOE発注先コード</summary>
		private Int32 _uOESupplierCd;

		/// <summary>ＣＳＶ種別</summary>
		private Int32 _csvKnd;

		/// <summary>ＣＳＶファイル名</summary>
		private String _csvName;

		/// <summary>ＣＳＶフルパス名</summary>
		private String _csvFullPath;

		/// <summary>注文一覧明細クラス</summary>
		private ArrayList _lstDtl;

		/// <summary>更新結果</summary>
		/// <remarks>9:未処理(初期設定) 0:正常終了 1:前回請求日算出エラー 2:前回準備処理以前 3:取込済 -1:異常終了</remarks>
		private Int32 _updRsl;

		/// <summary>企業名称</summary>
		private string _enterpriseName = "";


		/// public propaty name  :  EnterpriseCode
		/// <summary>企業コードプロパティ</summary>
		/// <value>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   企業コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public String EnterpriseCode
		{
			get{return _enterpriseCode;}
			set{_enterpriseCode = value;}
		}

		/// public propaty name  :  SectionCode
		/// <summary>拠点コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public String SectionCode
		{
			get{return _sectionCode;}
			set{_sectionCode = value;}
		}

		/// public propaty name  :  UOESupplierCd
		/// <summary>UOE発注先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   UOE発注先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 UOESupplierCd
		{
			get{return _uOESupplierCd;}
			set{_uOESupplierCd = value;}
		}

		/// public propaty name  :  CsvKnd
		/// <summary>ＣＳＶ種別プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ＣＳＶ種別プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CsvKnd
		{
			get{return _csvKnd;}
			set{_csvKnd = value;}
		}

		/// public propaty name  :  CsvName
		/// <summary>ＣＳＶファイル名プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ＣＳＶファイル名プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public String CsvName
		{
			get{return _csvName;}
			set{_csvName = value;}
		}

		/// public propaty name  :  CsvFullPath
		/// <summary>ＣＳＶフルパス名プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ＣＳＶフルパス名プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public String CsvFullPath
		{
			get{return _csvFullPath;}
			set{_csvFullPath = value;}
		}

		/// public propaty name  :  LstDtl
		/// <summary>注文一覧明細クラスプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   注文一覧明細クラスプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList LstDtl
		{
			get{return _lstDtl;}
			set{_lstDtl = value;}
		}

		/// public propaty name  :  UpdRsl
		/// <summary>更新結果プロパティ</summary>
		/// <value>9:未処理(初期設定) 0:正常終了 1:前回請求日算出エラー 2:前回準備処理以前 3:取込済 -1:異常終了</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新結果プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 UpdRsl
		{
			get{return _updRsl;}
			set{_updRsl = value;}
		}

		/// public propaty name  :  EnterpriseName
		/// <summary>企業名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   企業名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EnterpriseName
		{
			get{return _enterpriseName;}
			set{_enterpriseName = value;}
		}


		/// <summary>
		/// 注文一覧クラスコンストラクタ
		/// </summary>
		/// <returns>OrderLstheadクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   OrderLstheadクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public OrderLsthead()
		{
		}

		/// <summary>
		/// 注文一覧クラスコンストラクタ
		/// </summary>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="sectionCode">拠点コード</param>
		/// <param name="uOESupplierCd">UOE発注先コード</param>
		/// <param name="csvKnd">ＣＳＶ種別</param>
		/// <param name="csvName">ＣＳＶファイル名</param>
		/// <param name="csvFullPath">ＣＳＶフルパス名</param>
		/// <param name="lstDtl">注文一覧明細クラス</param>
		/// <param name="updRsl">更新結果(9:未処理(初期設定) 0:正常終了 1:前回請求日算出エラー 2:前回準備処理以前 3:取込済 -1:異常終了)</param>
		/// <param name="enterpriseName">企業名称</param>
		/// <returns>OrderLstheadクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   OrderLstheadクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public OrderLsthead(String enterpriseCode,String sectionCode,Int32 uOESupplierCd,Int32 csvKnd,String csvName,String csvFullPath,ArrayList lstDtl,Int32 updRsl,string enterpriseName)
		{
			this._enterpriseCode = enterpriseCode;
			this._sectionCode = sectionCode;
			this._uOESupplierCd = uOESupplierCd;
			this._csvKnd = csvKnd;
			this._csvName = csvName;
			this._csvFullPath = csvFullPath;
			this._lstDtl = lstDtl;
			this._updRsl = updRsl;
			this._enterpriseName = enterpriseName;

		}

		/// <summary>
		/// 注文一覧クラス複製処理
		/// </summary>
		/// <returns>OrderLstheadクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいOrderLstheadクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public OrderLsthead Clone()
		{
			return new OrderLsthead(this._enterpriseCode,this._sectionCode,this._uOESupplierCd,this._csvKnd,this._csvName,this._csvFullPath,this._lstDtl,this._updRsl,this._enterpriseName);
		}

		/// <summary>
		/// 注文一覧クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のOrderLstheadクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   OrderLstheadクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(OrderLsthead target)
		{
			return ((this.EnterpriseCode == target.EnterpriseCode)
				 && (this.SectionCode == target.SectionCode)
				 && (this.UOESupplierCd == target.UOESupplierCd)
				 && (this.CsvKnd == target.CsvKnd)
				 && (this.CsvName == target.CsvName)
				 && (this.CsvFullPath == target.CsvFullPath)
				 && (this.LstDtl == target.LstDtl)
				 && (this.UpdRsl == target.UpdRsl)
				 && (this.EnterpriseName == target.EnterpriseName));
		}

		/// <summary>
		/// 注文一覧クラス比較処理
		/// </summary>
		/// <param name="orderLsthead1">
		///                    比較するOrderLstheadクラスのインスタンス
		/// </param>
		/// <param name="orderLsthead2">比較するOrderLstheadクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   OrderLstheadクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(OrderLsthead orderLsthead1, OrderLsthead orderLsthead2)
		{
			return ((orderLsthead1.EnterpriseCode == orderLsthead2.EnterpriseCode)
				 && (orderLsthead1.SectionCode == orderLsthead2.SectionCode)
				 && (orderLsthead1.UOESupplierCd == orderLsthead2.UOESupplierCd)
				 && (orderLsthead1.CsvKnd == orderLsthead2.CsvKnd)
				 && (orderLsthead1.CsvName == orderLsthead2.CsvName)
				 && (orderLsthead1.CsvFullPath == orderLsthead2.CsvFullPath)
				 && (orderLsthead1.LstDtl == orderLsthead2.LstDtl)
				 && (orderLsthead1.UpdRsl == orderLsthead2.UpdRsl)
				 && (orderLsthead1.EnterpriseName == orderLsthead2.EnterpriseName));
		}
		/// <summary>
		/// 注文一覧クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のOrderLstheadクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   OrderLstheadクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(OrderLsthead target)
		{
			ArrayList resList = new ArrayList();
			if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
			if(this.SectionCode != target.SectionCode)resList.Add("SectionCode");
			if(this.UOESupplierCd != target.UOESupplierCd)resList.Add("UOESupplierCd");
			if(this.CsvKnd != target.CsvKnd)resList.Add("CsvKnd");
			if(this.CsvName != target.CsvName)resList.Add("CsvName");
			if(this.CsvFullPath != target.CsvFullPath)resList.Add("CsvFullPath");
			if(this.LstDtl != target.LstDtl)resList.Add("LstDtl");
			if(this.UpdRsl != target.UpdRsl)resList.Add("UpdRsl");
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");

			return resList;
		}

		/// <summary>
		/// 注文一覧クラス比較処理
		/// </summary>
		/// <param name="orderLsthead1">比較するOrderLstheadクラスのインスタンス</param>
		/// <param name="orderLsthead2">比較するOrderLstheadクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   OrderLstheadクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(OrderLsthead orderLsthead1, OrderLsthead orderLsthead2)
		{
			ArrayList resList = new ArrayList();
			if(orderLsthead1.EnterpriseCode != orderLsthead2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(orderLsthead1.SectionCode != orderLsthead2.SectionCode)resList.Add("SectionCode");
			if(orderLsthead1.UOESupplierCd != orderLsthead2.UOESupplierCd)resList.Add("UOESupplierCd");
			if(orderLsthead1.CsvKnd != orderLsthead2.CsvKnd)resList.Add("CsvKnd");
			if(orderLsthead1.CsvName != orderLsthead2.CsvName)resList.Add("CsvName");
			if(orderLsthead1.CsvFullPath != orderLsthead2.CsvFullPath)resList.Add("CsvFullPath");
			if(orderLsthead1.LstDtl != orderLsthead2.LstDtl)resList.Add("LstDtl");
			if(orderLsthead1.UpdRsl != orderLsthead2.UpdRsl)resList.Add("UpdRsl");
			if(orderLsthead1.EnterpriseName != orderLsthead2.EnterpriseName)resList.Add("EnterpriseName");

			return resList;
		}
	}
}

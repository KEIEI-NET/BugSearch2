using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   BuyOutLsthead
	/// <summary>
	///                         クラス
	/// </summary>
	/// <remarks>
	/// <br>note             :   買上一覧クラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2009/05/27  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class BuyOutLsthead
	{
		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private String _enterpriseCode;

		/// <summary>拠点コード</summary>
		private String _sectionCode;

		/// <summary>UOE発注先コード</summary>
		private Int32 _uOESupplierCd;

		/// <summary>ＣＳＶ種別</summary>
		/// <remarks>0固定</remarks>
		private Int32 _csvKnd;

		/// <summary>担当者コード</summary>
		private String _stockAgentCode;

		/// <summary>担当者名称</summary>
		private String _stockAgentName;

		/// <summary>原価更新区分</summary>
		/// <remarks>0:なし 1:あり</remarks>
		private Int32 _costUpdtDiv;

		/// <summary>仕入データ作成区分</summary>
		/// <remarks>0:なし 1:あり</remarks>
		private Int32 _stcCreDiv;

		/// <summary>ＣＳＶファイル名</summary>
		private String _csvName;

		/// <summary>ＣＳＶフルパス名</summary>
		private String _csvFullPath;

		/// <summary>買上明細クラス</summary>
		private ArrayList _lstDtl;

		/// <summary>更新結果</summary>
		/// <remarks>9:未処理(初期設定) 0:正常終了 -1:エラー</remarks>
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
		/// <value>0固定</value>
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

		/// public propaty name  :  StockAgentCode
		/// <summary>担当者コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   担当者コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public String StockAgentCode
		{
			get{return _stockAgentCode;}
			set{_stockAgentCode = value;}
		}

		/// public propaty name  :  StockAgentName
		/// <summary>担当者名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   担当者名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public String StockAgentName
		{
			get{return _stockAgentName;}
			set{_stockAgentName = value;}
		}

		/// public propaty name  :  CostUpdtDiv
		/// <summary>原価更新区分プロパティ</summary>
		/// <value>0:なし 1:あり</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   原価更新区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CostUpdtDiv
		{
			get{return _costUpdtDiv;}
			set{_costUpdtDiv = value;}
		}

		/// public propaty name  :  StcCreDiv
		/// <summary>仕入データ作成区分プロパティ</summary>
		/// <value>0:なし 1:あり</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入データ作成区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StcCreDiv
		{
			get{return _stcCreDiv;}
			set{_stcCreDiv = value;}
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
		/// <summary>買上明細クラスプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   買上明細クラスプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList LstDtl
		{
			get{return _lstDtl;}
			set{_lstDtl = value;}
		}

		/// public propaty name  :  UpdRsl
		/// <summary>更新結果プロパティ</summary>
		/// <value>9:未処理(初期設定) 0:正常終了 -1:エラー</value>
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
		/// 買上一覧クラスコンストラクタ
		/// </summary>
		/// <returns>BuyOutLstheadクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   BuyOutLstheadクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public BuyOutLsthead()
		{
		}

		/// <summary>
		/// 買上一覧クラスコンストラクタ
		/// </summary>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="sectionCode">拠点コード</param>
		/// <param name="uOESupplierCd">UOE発注先コード</param>
		/// <param name="csvKnd">ＣＳＶ種別(0固定)</param>
		/// <param name="stockAgentCode">担当者コード</param>
		/// <param name="stockAgentName">担当者名称</param>
		/// <param name="costUpdtDiv">原価更新区分(0:なし 1:あり)</param>
		/// <param name="stcCreDiv">仕入データ作成区分(0:なし 1:あり)</param>
		/// <param name="csvName">ＣＳＶファイル名</param>
		/// <param name="csvFullPath">ＣＳＶフルパス名</param>
		/// <param name="lstDtl">買上明細クラス</param>
		/// <param name="updRsl">更新結果(9:未処理(初期設定) 0:正常終了 -1:エラー)</param>
		/// <param name="enterpriseName">企業名称</param>
		/// <returns>BuyOutLstheadクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   BuyOutLstheadクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public BuyOutLsthead(String enterpriseCode,String sectionCode,Int32 uOESupplierCd,Int32 csvKnd,String stockAgentCode,String stockAgentName,Int32 costUpdtDiv,Int32 stcCreDiv,String csvName,String csvFullPath,ArrayList lstDtl,Int32 updRsl,string enterpriseName)
		{
			this._enterpriseCode = enterpriseCode;
			this._sectionCode = sectionCode;
			this._uOESupplierCd = uOESupplierCd;
			this._csvKnd = csvKnd;
			this._stockAgentCode = stockAgentCode;
			this._stockAgentName = stockAgentName;
			this._costUpdtDiv = costUpdtDiv;
			this._stcCreDiv = stcCreDiv;
			this._csvName = csvName;
			this._csvFullPath = csvFullPath;
			this._lstDtl = lstDtl;
			this._updRsl = updRsl;
			this._enterpriseName = enterpriseName;

		}

		/// <summary>
		/// 買上一覧クラス複製処理
		/// </summary>
		/// <returns>BuyOutLstheadクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいBuyOutLstheadクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public BuyOutLsthead Clone()
		{
			return new BuyOutLsthead(this._enterpriseCode,this._sectionCode,this._uOESupplierCd,this._csvKnd,this._stockAgentCode,this._stockAgentName,this._costUpdtDiv,this._stcCreDiv,this._csvName,this._csvFullPath,this._lstDtl,this._updRsl,this._enterpriseName);
		}

		/// <summary>
		/// 買上一覧クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のBuyOutLstheadクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   BuyOutLstheadクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(BuyOutLsthead target)
		{
			return ((this.EnterpriseCode == target.EnterpriseCode)
				 && (this.SectionCode == target.SectionCode)
				 && (this.UOESupplierCd == target.UOESupplierCd)
				 && (this.CsvKnd == target.CsvKnd)
				 && (this.StockAgentCode == target.StockAgentCode)
				 && (this.StockAgentName == target.StockAgentName)
				 && (this.CostUpdtDiv == target.CostUpdtDiv)
				 && (this.StcCreDiv == target.StcCreDiv)
				 && (this.CsvName == target.CsvName)
				 && (this.CsvFullPath == target.CsvFullPath)
				 && (this.LstDtl == target.LstDtl)
				 && (this.UpdRsl == target.UpdRsl)
				 && (this.EnterpriseName == target.EnterpriseName));
		}

		/// <summary>
		/// 買上一覧クラス比較処理
		/// </summary>
		/// <param name="buyOutLsthead1">
		///                    比較するBuyOutLstheadクラスのインスタンス
		/// </param>
		/// <param name="buyOutLsthead2">比較するBuyOutLstheadクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   BuyOutLstheadクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(BuyOutLsthead buyOutLsthead1, BuyOutLsthead buyOutLsthead2)
		{
			return ((buyOutLsthead1.EnterpriseCode == buyOutLsthead2.EnterpriseCode)
				 && (buyOutLsthead1.SectionCode == buyOutLsthead2.SectionCode)
				 && (buyOutLsthead1.UOESupplierCd == buyOutLsthead2.UOESupplierCd)
				 && (buyOutLsthead1.CsvKnd == buyOutLsthead2.CsvKnd)
				 && (buyOutLsthead1.StockAgentCode == buyOutLsthead2.StockAgentCode)
				 && (buyOutLsthead1.StockAgentName == buyOutLsthead2.StockAgentName)
				 && (buyOutLsthead1.CostUpdtDiv == buyOutLsthead2.CostUpdtDiv)
				 && (buyOutLsthead1.StcCreDiv == buyOutLsthead2.StcCreDiv)
				 && (buyOutLsthead1.CsvName == buyOutLsthead2.CsvName)
				 && (buyOutLsthead1.CsvFullPath == buyOutLsthead2.CsvFullPath)
				 && (buyOutLsthead1.LstDtl == buyOutLsthead2.LstDtl)
				 && (buyOutLsthead1.UpdRsl == buyOutLsthead2.UpdRsl)
				 && (buyOutLsthead1.EnterpriseName == buyOutLsthead2.EnterpriseName));
		}
		/// <summary>
		/// 買上一覧クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のBuyOutLstheadクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   BuyOutLstheadクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(BuyOutLsthead target)
		{
			ArrayList resList = new ArrayList();
			if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
			if(this.SectionCode != target.SectionCode)resList.Add("SectionCode");
			if(this.UOESupplierCd != target.UOESupplierCd)resList.Add("UOESupplierCd");
			if(this.CsvKnd != target.CsvKnd)resList.Add("CsvKnd");
			if(this.StockAgentCode != target.StockAgentCode)resList.Add("StockAgentCode");
			if(this.StockAgentName != target.StockAgentName)resList.Add("StockAgentName");
			if(this.CostUpdtDiv != target.CostUpdtDiv)resList.Add("CostUpdtDiv");
			if(this.StcCreDiv != target.StcCreDiv)resList.Add("StcCreDiv");
			if(this.CsvName != target.CsvName)resList.Add("CsvName");
			if(this.CsvFullPath != target.CsvFullPath)resList.Add("CsvFullPath");
			if(this.LstDtl != target.LstDtl)resList.Add("LstDtl");
			if(this.UpdRsl != target.UpdRsl)resList.Add("UpdRsl");
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");

			return resList;
		}

		/// <summary>
		/// 買上一覧クラス比較処理
		/// </summary>
		/// <param name="buyOutLsthead1">比較するBuyOutLstheadクラスのインスタンス</param>
		/// <param name="buyOutLsthead2">比較するBuyOutLstheadクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   BuyOutLstheadクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(BuyOutLsthead buyOutLsthead1, BuyOutLsthead buyOutLsthead2)
		{
			ArrayList resList = new ArrayList();
			if(buyOutLsthead1.EnterpriseCode != buyOutLsthead2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(buyOutLsthead1.SectionCode != buyOutLsthead2.SectionCode)resList.Add("SectionCode");
			if(buyOutLsthead1.UOESupplierCd != buyOutLsthead2.UOESupplierCd)resList.Add("UOESupplierCd");
			if(buyOutLsthead1.CsvKnd != buyOutLsthead2.CsvKnd)resList.Add("CsvKnd");
			if(buyOutLsthead1.StockAgentCode != buyOutLsthead2.StockAgentCode)resList.Add("StockAgentCode");
			if(buyOutLsthead1.StockAgentName != buyOutLsthead2.StockAgentName)resList.Add("StockAgentName");
			if(buyOutLsthead1.CostUpdtDiv != buyOutLsthead2.CostUpdtDiv)resList.Add("CostUpdtDiv");
			if(buyOutLsthead1.StcCreDiv != buyOutLsthead2.StcCreDiv)resList.Add("StcCreDiv");
			if(buyOutLsthead1.CsvName != buyOutLsthead2.CsvName)resList.Add("CsvName");
			if(buyOutLsthead1.CsvFullPath != buyOutLsthead2.CsvFullPath)resList.Add("CsvFullPath");
			if(buyOutLsthead1.LstDtl != buyOutLsthead2.LstDtl)resList.Add("LstDtl");
			if(buyOutLsthead1.UpdRsl != buyOutLsthead2.UpdRsl)resList.Add("UpdRsl");
			if(buyOutLsthead1.EnterpriseName != buyOutLsthead2.EnterpriseName)resList.Add("EnterpriseName");

			return resList;
		}
	}
}

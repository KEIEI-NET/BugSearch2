//***************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 仕入返品予定一覧表
// プログラム概要   : 仕入返品予定一覧表 抽出情報クラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10806793-00 作成担当 : FSI高橋 文彰
// 作 成 日   2013/01/28 修正内容 : 新規作成 仕入返品予定機能対応
//----------------------------------------------------------------------------//
using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:   ExtrInfo_PMKAK02034E
	/// <summary>
	///                      仕入返品予定一覧表抽出条件クラス
	/// </summary>
	/// <remarks>
	/// <br>note             :   仕入返品予定一覧表抽出条件クラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// </remarks>
	public class ExtrInfo_PMKAK02034E
	{
		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";
		/// <summary>拠点コード</summary>
		private string[] _sectionCodes ;
        /// <summary>開始仕入先コード</summary>
        private Int32 _supplierCdSt;
        /// <summary>終了仕入先コード</summary>
        private Int32 _supplierCdEd;
		/// <summary>開始入力日付</summary>
		private Int32 _inputDaySt;
		/// <summary>終了入力日付</summary>
		private Int32 _inputDayEd;
		/// <summary>発行タイプ</summary>
		private Int32 _makeShowDiv;
		/// <summary>発行タイプ名称</summary>
		private string _makeShowDivName = "";
		/// <summary>出力指定</summary>
		private Int32 _slipDiv;
		/// <summary>出力指定名称</summary>
		private string _slipDivName = "";
        /// <summary>改頁</summary>
        private Int32 _newPageDiv;
        /// <summary>日付指定</summary>
        private Int32 _printDailyFooter;

		/// public propaty name  :  EnterpriseCode
		/// <summary>企業コードプロパティ</summary>
		/// <value>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   企業コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EnterpriseCode
		{
			get { return _enterpriseCode; }
			set { _enterpriseCode = value; }
		}

		/// public propaty name  :  SectionCodes
		/// <summary>拠点コードプロパティ</summary>
		/// <value>(配列)　全社指定は{""}</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string[] SectionCodes
		{
			get { return _sectionCodes; }
			set { _sectionCodes = value; }
		}


        /// public propaty name  :  CustomerCodeSt
        /// <summary>開始仕入先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始仕入先コードプロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public Int32 SupplierCdSt
        {
            get { return _supplierCdSt; }
            set { _supplierCdSt = value; }
        }

        /// public propaty name  :  CustomerCodeEd
        /// <summary>終了仕入先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了仕入先コードプロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public Int32 SupplierCdEd
        {
            get { return _supplierCdEd; }
            set { _supplierCdEd = value; }
        }

		/// public propaty name  :  InputDaySt
		/// <summary>開始入力日付プロパティ</summary>
		/// <value>YYYYMMDD (未入力は0)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   開始入力日付プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 InputDaySt
		{
			get { return _inputDaySt; }
			set { _inputDaySt = value; }
		}

		/// public propaty name  :  InputDayEd
		/// <summary>終了入力日付プロパティ</summary>
		/// <value>YYYYMMDD (未入力は0)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   終了入力日付プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 InputDayEd
		{
			get { return _inputDayEd; }
			set { _inputDayEd = value; }
		}

		/// public propaty name  :  MakeShowDiv
		/// <summary>発行タイププロパティ</summary>
		/// <value>0:通常,1:削除</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   発行タイププロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 MakeShowDiv
		{
			get { return _makeShowDiv; }
			set { _makeShowDiv = value; }
		}

		/// public propaty name  :  MakeShowDivName
		/// <summary>発行タイプ名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   発行タイプ名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string MakeShowDivName
		{
			get { return _makeShowDivName; }
			set { _makeShowDivName = value; }
		}

		/// public propaty name  :  SlipDiv
		/// <summary>出力指定プロパティ</summary>
		/// <value>0:返品予定のみ,1:返品済のみ,2:すべて</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   出力指定プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SlipDiv
		{
			get { return _slipDiv; }
			set { _slipDiv = value; }
		}

		/// public propaty name  :  SlipDivName
		/// <summary>出力指定名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   出力指定名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SlipDivName
		{
			get { return _slipDivName; }
			set { _slipDivName = value; }
		}

        /// public propaty name  :  NewPageDiv
        /// <summary>改頁区分プロパティ</summary>
        /// <value>0:拠点,1:仕入先,2:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   改頁区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 NewPageDiv
        {
            get { return _newPageDiv; }
            set { _newPageDiv = value; }
        }

        /// public propaty name  :  PrintDailyFooter
        /// <summary>日付指定プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   日付指定プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrintDailyFooter
        {
            get { return _printDailyFooter; }
            set { _printDailyFooter = value; }
        }

		/// <summary>
		/// 仕入返品予定一覧表抽出条件クラスワークコンストラクタ
		/// </summary>
		/// <returns>StockRetPlnParamWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   StockRetPlnParamWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ExtrInfo_PMKAK02034E()
		{
		}

		/// <summary>
		/// 仕入返品予定一覧表抽出条件クラスコンストラクタ
		/// </summary>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="sectionCodes">拠点コード((配列))</param>
        /// <param name="supplierCdSt">開始仕入先コード</param>
        /// <param name="supplierCdEd">終了仕入先コード</param>
		/// <param name="stockDateSt">開始仕入日付(YYYYMMDD)</param>
		/// <param name="stockDateEd">終了仕入日付(YYYYMMDD)</param>
		/// <param name="inputDaySt">開始入力日付</param>
		/// <param name="inputDayEd">終了入力日付</param>
		/// <param name="makeShowDiv">発行タイプ</param>
		/// <param name="slipDiv">出力指定</param>
        /// <param name="newPageDiv">改頁区分</param>
        /// <param name="printDailyFooter">日付指定区分</param>
		/// <returns>StockRetPlnParamWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ShipmentListCndtnクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        public ExtrInfo_PMKAK02034E(string enterpriseCode, string[] sectionCodes, Int32 makeShowDiv, Int32 slipDiv, Int32 inputDaySt, Int32 inputDayEd, Int32 newPageDiv, Int32 printDailyFooter)
        {
			this._enterpriseCode = enterpriseCode;
			this._sectionCodes = sectionCodes;
            this._supplierCdSt = SupplierCdSt;
            this._supplierCdEd = SupplierCdEd;
			this._inputDaySt = inputDaySt;
			this._inputDayEd = inputDayEd;
			this._slipDiv = slipDiv;
			this._makeShowDiv = makeShowDiv;
            this._newPageDiv = newPageDiv;
            this._printDailyFooter = printDailyFooter;
		}

		/// <summary>
		/// 仕入返品予定一覧表抽出条件クラス複製処理
		/// </summary>
		/// <returns>ShipmentListCndtnクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいShipmentListCndtnクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ExtrInfo_PMKAK02034E Clone()
		{
            return new ExtrInfo_PMKAK02034E(this._enterpriseCode, this._sectionCodes, this._makeShowDiv, this._slipDiv, this._inputDaySt, this._inputDayEd, this._newPageDiv, this._printDailyFooter);
        }

		/// <summary>
		/// 仕入返品予定一覧表抽出条件クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のShipmentListCndtnクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ShipmentListCndtnクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(ExtrInfo_PMKAK02034E target)
		{
			return ((this.EnterpriseCode == target.EnterpriseCode)
				 && (this.SectionCodes == target.SectionCodes)
                 && (this.SupplierCdSt == target.SupplierCdSt)
                 && (this.SupplierCdEd == target.SupplierCdEd)
				 && (this.InputDaySt == target.InputDaySt)
				 && (this.InputDayEd == target.InputDayEd)
				 && (this.MakeShowDiv == target.MakeShowDiv)
				 && (this.SlipDiv == target.SlipDiv)
                 && (this.NewPageDiv == target.NewPageDiv)
                 && (this.PrintDailyFooter == target.PrintDailyFooter)
				 );
		}

		/// <summary>
		/// 仕入返品予定一覧表抽出条件クラス比較処理
		/// </summary>
		/// <param name="shipmentListCndtn1">
		///                    比較するShipmentListCndtnクラスのインスタンス
		/// </param>
		/// <param name="shipmentListCndtn2">比較するShipmentListCndtnクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ShipmentListCndtnクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(ExtrInfo_PMKAK02034E shipmentListCndtn1, ExtrInfo_PMKAK02034E shipmentListCndtn2)
		{
			return ((shipmentListCndtn1.EnterpriseCode == shipmentListCndtn2.EnterpriseCode)
				 && (shipmentListCndtn1.SectionCodes == shipmentListCndtn2.SectionCodes)
                 && (shipmentListCndtn1.SupplierCdSt == shipmentListCndtn2.SupplierCdSt)
                 && (shipmentListCndtn1.SupplierCdEd == shipmentListCndtn2.SupplierCdEd)
				 && (shipmentListCndtn1.InputDaySt == shipmentListCndtn2.InputDaySt)
				 && (shipmentListCndtn1.InputDayEd == shipmentListCndtn2.InputDayEd)
				 && (shipmentListCndtn1.MakeShowDiv == shipmentListCndtn2.MakeShowDiv)
				 && (shipmentListCndtn1.SlipDiv == shipmentListCndtn2.SlipDiv)
                 && (shipmentListCndtn1.NewPageDiv == shipmentListCndtn2.NewPageDiv)
                 && (shipmentListCndtn1.PrintDailyFooter == shipmentListCndtn2.PrintDailyFooter)
				 );
		
		}
		/// <summary>
		/// 仕入返品予定一覧表抽出条件クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のShipmentListCndtnクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ShipmentListCndtnクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(ExtrInfo_PMKAK02034E target)
		{
			ArrayList resList = new ArrayList();
			if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
			if(this.SectionCodes != target.SectionCodes)resList.Add("SectionCodes");
            if (this.SupplierCdSt != target.SupplierCdSt) resList.Add("SupplierCdSt");
            if (this.SupplierCdEd != target.SupplierCdEd) resList.Add("SupplierCdEd");
			if (this.InputDaySt != target.InputDaySt) resList.Add("InputDaySt");
			if (this.InputDayEd != target.InputDayEd) resList.Add("InputDayEd");
			if (this.MakeShowDiv != target.MakeShowDiv) resList.Add("MakeShowDiv");
			if(this.SlipDiv != target.SlipDiv)resList.Add("SlipDiv");
            if (this.NewPageDiv != target.NewPageDiv) resList.Add("NewPageDiv");
            if (this.PrintDailyFooter != target.PrintDailyFooter) resList.Add("PrintDailyFooter");

			return resList;
		}

		/// <summary>
		/// 仕入返品予定一覧表抽出条件クラス比較処理
		/// </summary>
		/// <param name="shipmentListCndtn1">比較するShipmentListCndtnクラスのインスタンス</param>
		/// <param name="shipmentListCndtn2">比較するShipmentListCndtnクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   ShipmentListCndtnクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(ExtrInfo_PMKAK02034E shipmentListCndtn1, ExtrInfo_PMKAK02034E shipmentListCndtn2)
		{
			ArrayList resList = new ArrayList();
			if(shipmentListCndtn1.EnterpriseCode != shipmentListCndtn2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(shipmentListCndtn1.SectionCodes != shipmentListCndtn2.SectionCodes)resList.Add("SectionCodes");
            if (shipmentListCndtn1.SupplierCdSt != shipmentListCndtn2.SupplierCdSt) resList.Add("SupplierCdSt");
            if (shipmentListCndtn1.SupplierCdEd != shipmentListCndtn2.SupplierCdEd) resList.Add("SupplierCdEd");
			if(shipmentListCndtn1.MakeShowDiv != shipmentListCndtn2.MakeShowDiv)resList.Add("MakeShowDiv");
			if(shipmentListCndtn1.SlipDiv != shipmentListCndtn2.SlipDiv)resList.Add("SlipDiv");
			if (shipmentListCndtn1.InputDaySt != shipmentListCndtn2.InputDaySt) resList.Add("InputDaySt");
			if (shipmentListCndtn1.InputDayEd != shipmentListCndtn2.InputDayEd) resList.Add("InputDayEd");
            if (shipmentListCndtn1.NewPageDiv != shipmentListCndtn2.NewPageDiv) resList.Add("NewPageDiv");
            if (shipmentListCndtn1.PrintDailyFooter != shipmentListCndtn2.PrintDailyFooter) resList.Add("PrintDailyFooter");
			return resList;
		}
	}
}

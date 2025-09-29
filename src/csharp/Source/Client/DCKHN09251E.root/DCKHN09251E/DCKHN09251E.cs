using System;
using System.Collections.Generic;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008/12/08 G.Miyatsu ADD
    public class DictionaryList : Dictionary<int, object>
    {

    };
    //<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008/12/08 G.Miyatsu ADD

	/// public class name:   SlipOutputSet
    /// <summary>
	///                      伝票出力先設定マスタ
    /// </summary>
    /// <remarks>
	/// <br>note             :   伝票出力先設定マスタヘッダファイル</br>
    /// <br>Programmer       :   自動生成 / 30167 上野　弘貴</br>
    /// <br>Date             :   2007/12/10</br>
    /// <br>Genarated Date   :   2007/12/10  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   2007/12/19  30167 上野　弘貴</br>
	/// <br>				     伝票印刷設定マスタ紐づけ対応</br>
	/// <br>Update Note      :   2008/03/17  30167 上野　弘貴</br>
	/// <br>				     伝票印刷種別ワークシート, ボディ寸法図削除</br>
    /// <br>UpdateNote   : 2008/10/09 30462 行澤 仁美　バグ修正</br>
    /// <br>             : 2008/11/10       照田 貴志　バグ修正、仕様変更対応</br>
    /// <br>UpdateNote   : 2010/09/27 22018 鈴木 正臣　一般帳票も設定可能に変更。</br>
    /// </remarks>
    public class SlipOutputSet
    {
		/// <summary>作成日時</summary>
		/// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
		private DateTime _createDateTime;

		/// <summary>更新日時</summary>
		/// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
		private DateTime _updateDateTime;

		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>GUID</summary>
		/// <remarks>共通ファイルヘッダ</remarks>
		private Guid _fileHeaderGuid;

		/// <summary>更新従業員コード</summary>
		/// <remarks>共通ファイルヘッダ</remarks>
		private string _updEmployeeCode = "";

		/// <summary>更新アセンブリID1</summary>
		/// <remarks>共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）</remarks>
		private string _updAssemblyId1 = "";

		/// <summary>更新アセンブリID2</summary>
		/// <remarks>共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）</remarks>
		private string _updAssemblyId2 = "";

		/// <summary>論理削除区分</summary>
		/// <remarks>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</remarks>
		private Int32 _logicalDeleteCode;

        //--- DEL 2008/06/20 ---------->>>>>
        ///// <summary>拠点コード</summary>
        //private string _sectionCode = "";
        //--- DEL 2008/06/20 ----------<<<<<

        //--- ADD 2008/06/19 ---------->>>>>
        /// <summary>倉庫コード</summary>
        /// <remarks>倉庫毎/プリンタ別の貸出、納品書の時のみ使用</remarks>
        private string _warehouseCode = "";
        //--- ADD 2008/06/19 ----------<<<<<

		/// <summary>レジ番号</summary>
		/// <remarks>端末番号</remarks>
		private Int32 _cashRegisterNo;

		//----- h.ueno add---------- start 2007.12.19
		/// <summary>データ入力システム</summary>
		/// <remarks>0:共通,1:整備,2:鈑金,3:車販</remarks>
		private Int32 _dataInputSystem;
		//----- h.ueno add---------- end   2007.12.19

		/// <summary>伝票印刷種別</summary>
		/// <remarks>10:見積書,20:指示書（注文書）,21:承り書,30:納品書40:返品伝票,100:ワークシート,110:ボディ寸法図</remarks>
		private Int32 _slipPrtKind;

		/// <summary>伝票印刷設定用帳票ID</summary>
		/// <remarks>伝票印刷設定用</remarks>
		private string _slipPrtSetPaperId = "";

		/// <summary>プリンタ管理No</summary>
		private Int32 _printerMngNo;

		/*----------------------------------------------------------------------------------*/
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

		/// public propaty name  :  CreateDateTimeJpFormal
		/// <summary>作成日時 和暦プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   作成日時 和暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CreateDateTimeJpFormal
		{
			get { return TDateTime.DateTimeToString("GGYYMMDD", _createDateTime); }
			set { }
		}

		/// public propaty name  :  CreateDateTimeJpInFormal
		/// <summary>作成日時 和暦(略)プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   作成日時 和暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CreateDateTimeJpInFormal
		{
			get { return TDateTime.DateTimeToString("ggYY/MM/DD", _createDateTime); }
			set { }
		}

		/// public propaty name  :  CreateDateTimeAdFormal
		/// <summary>作成日時 西暦プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   作成日時 西暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CreateDateTimeAdFormal
		{
			get { return TDateTime.DateTimeToString("YYYY/MM/DD", _createDateTime); }
			set { }
		}

		/// public propaty name  :  CreateDateTimeAdInFormal
		/// <summary>作成日時 西暦(略)プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   作成日時 西暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CreateDateTimeAdInFormal
		{
			get { return TDateTime.DateTimeToString("YY/MM/DD", _createDateTime); }
			set { }
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

		/// public propaty name  :  UpdateDateTimeJpFormal
		/// <summary>更新日時 和暦プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新日時 和暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdateDateTimeJpFormal
		{
			get { return TDateTime.DateTimeToString("GGYYMMDD", _updateDateTime); }
			set { }
		}

		/// public propaty name  :  UpdateDateTimeJpInFormal
		/// <summary>更新日時 和暦(略)プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新日時 和暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdateDateTimeJpInFormal
		{
			get { return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDateTime); }
			set { }
		}

		/// public propaty name  :  UpdateDateTimeAdFormal
		/// <summary>更新日時 西暦プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新日時 西暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdateDateTimeAdFormal
		{
			get { return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDateTime); }
			set { }
		}

		/// public propaty name  :  UpdateDateTimeAdInFormal
		/// <summary>更新日時 西暦(略)プロパティ</summary>
		/// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新日時 西暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdateDateTimeAdInFormal
		{
			get { return TDateTime.DateTimeToString("YY/MM/DD", _updateDateTime); }
			set { }
		}

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
			get{return _enterpriseCode;}
			set{_enterpriseCode = value;}
		}

		/// public propaty name  :  FileHeaderGuid
		/// <summary>GUIDプロパティ</summary>
		/// <value>共通ファイルヘッダ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   GUIDプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Guid FileHeaderGuid
		{
			get{return _fileHeaderGuid;}
			set{_fileHeaderGuid = value;}
		}

		/// public propaty name  :  UpdEmployeeCode
		/// <summary>更新従業員コードプロパティ</summary>
		/// <value>共通ファイルヘッダ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新従業員コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdEmployeeCode
		{
			get{return _updEmployeeCode;}
			set{_updEmployeeCode = value;}
		}

		/// public propaty name  :  UpdAssemblyId1
		/// <summary>更新アセンブリID1プロパティ</summary>
		/// <value>共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新アセンブリID1プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdAssemblyId1
		{
			get{return _updAssemblyId1;}
			set{_updAssemblyId1 = value;}
		}

		/// public propaty name  :  UpdAssemblyId2
		/// <summary>更新アセンブリID2プロパティ</summary>
		/// <value>共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新アセンブリID2プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdAssemblyId2
		{
			get{return _updAssemblyId2;}
			set{_updAssemblyId2 = value;}
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

        //--- DEL 2008/06/20 ---------->>>>>
        ///// public propaty name  :  SectionCode
        ///// <summary>拠点コードプロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   拠点コードプロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public string SectionCode
        //{
        //    get{return _sectionCode;}
        //    set{_sectionCode = value;}
        //}
        //--- DEL 2008/06/20 ----------<<<<<

        //--- ADD 2008/06/19 ---------->>>>>
        /// public propaty name  :  WarehouseCode
        /// <summary>倉庫コードプロパティ</summary>
        /// <value>倉庫毎/プリンタ別の貸出、納品書の時のみ使用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   倉庫コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string WarehouseCode
        {
            get { return _warehouseCode; }
            set { _warehouseCode = value; }
        }
        //--- ADD 2008/06/19 ----------<<<<<

		/// public propaty name  :  CashRegisterNo
		/// <summary>レジ番号プロパティ</summary>
		/// <value>端末番号</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   レジ番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CashRegisterNo
		{
			get{return _cashRegisterNo;}
			set{_cashRegisterNo = value;}
		}

		//----- h.ueno add---------- start 2007.12.19
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
		//----- h.ueno add---------- end   2007.12.19

		/// public propaty name  :  SlipPrtKind
		/// <summary>伝票印刷種別プロパティ</summary>
		/// <value>10:見積書,20:指示書（注文書）,21:承り書,30:納品書40:返品伝票,100:ワークシート,110:ボディ寸法図</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票印刷種別プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SlipPrtKind
		{
			get{return _slipPrtKind;}
			set{_slipPrtKind = value;}
		}

		/// public propaty name  :  SlipPrtSetPaperId
		/// <summary>伝票印刷設定用帳票IDプロパティ</summary>
		/// <value>伝票印刷設定用</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票印刷設定用帳票IDプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SlipPrtSetPaperId
		{
			get{return _slipPrtSetPaperId;}
			set{_slipPrtSetPaperId = value;}
		}

		/// public propaty name  :  PrinterMngNo
		/// <summary>プリンタ管理Noプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   プリンタ管理Noプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PrinterMngNo
		{
			get{return _printerMngNo;}
			set{_printerMngNo = value;}
		}

		/// <summary>
		/// 伝票出力先設定コンストラクタ
		/// </summary>
		/// <returns>SlipOutputSetクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SlipOutputSetWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SlipOutputSet()
		{
		}

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 伝票出力先設定マスタコンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
        /// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
        /// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="logicalDeleteCode">論理削除区分</param>
		/// <param name="sectionCode">拠点コード</param>
        /// <param name="warehouseCode">倉庫コード(倉庫毎/プリンタ別の貸出、納品書の時のみ使用)</param>
        /// <param name="cashRegisterNo">レジ番号</param>
		/// <param name="dataInputSystem">データ入力システム(0:共通,1:整備,2:鈑金,3:車販)</param>
		/// <param name="slipPrtKind">伝票印刷種別</param>
		/// <param name="slipPrtSetPaperId">伝票印刷設定用帳票ID</param>
		/// <param name="printerMngNo">プリンタ管理No</param>
        /// <returns>SlipOutputSetクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SlipOutputSetクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SlipOutputSet(
			DateTime createDateTime,
			DateTime updateDateTime,
			string enterpriseCode,
			Guid fileHeaderGuid,
			string updEmployeeCode,
			string updAssemblyId1,
			string updAssemblyId2,
			Int32 logicalDeleteCode,
            //string sectionCode,        // DEL 2008/06/20
            //--- ADD 2008/06/19 ---------->>>>>
            string warehouseCode,
            //--- ADD 2008/06/19 ----------<<<<<
            Int32 cashRegisterNo,
			//----- h.ueno add---------- start 2007.12.19
			Int32 dataInputSystem,
			//----- h.ueno add---------- end   2007.12.19
			Int32 slipPrtKind,
			string slipPrtSetPaperId,
			Int32 printerMngNo)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            //this._sectionCode = sectionCode;              // DEL 2008/06/20
            //--- ADD 2008/06/19 ---------->>>>>
            this._warehouseCode = warehouseCode;
            //--- ADD 2008/06/19 ----------<<<<<
            this._cashRegisterNo = cashRegisterNo;
			//----- h.ueno add---------- start 2007.12.19
			this._dataInputSystem = dataInputSystem;
			//----- h.ueno add---------- end   2007.12.19
			this._slipPrtKind = slipPrtKind;
			this._slipPrtSetPaperId = slipPrtSetPaperId;
			this._printerMngNo = printerMngNo;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 伝票出力先設定マスタ複製処理
        /// </summary>
        /// <returns>SlipOutputSetクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいSlipOutputSetクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SlipOutputSet Clone()
        {
            return new SlipOutputSet(
				this._createDateTime,
				this._updateDateTime,
				this._enterpriseCode,
				this._fileHeaderGuid,
				this._updEmployeeCode,
				this._updAssemblyId1,
				this._updAssemblyId2,
				this._logicalDeleteCode,
                //this._sectionCode,         // DEL 2008/06/20
                //--- ADD 2008/06/19 ---------->>>>>
                this._warehouseCode,
                //--- ADD 2008/06/19 ----------<<<<<
                this._cashRegisterNo,
				//----- h.ueno add---------- start 2007.12.19
				this._dataInputSystem,
				//----- h.ueno add---------- end   2007.12.19
				this._slipPrtKind,
				this._slipPrtSetPaperId,
				this._printerMngNo);
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 伝票出力先設定マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のSlipOutputSetクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SlipOutputSetクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(SlipOutputSet target)
        {
            return ((this.CreateDateTime	== target.CreateDateTime)
                && (this.UpdateDateTime		== target.UpdateDateTime)
                && (this.EnterpriseCode		== target.EnterpriseCode)
                && (this.FileHeaderGuid		== target.FileHeaderGuid)
                && (this.UpdEmployeeCode	== target.UpdEmployeeCode)
                && (this.UpdAssemblyId1		== target.UpdAssemblyId1)
                && (this.UpdAssemblyId2		== target.UpdAssemblyId2)
                && (this.LogicalDeleteCode	== target.LogicalDeleteCode)
                //&& (this.SectionCode		== target.SectionCode)          // DEL 2008/06/20
                //--- ADD 2008/06/19 ---------->>>>>
                && (this.WarehouseCode      == target.WarehouseCode)
                //--- ADD 2008/06/19 ----------<<<<<
                && (this.CashRegisterNo == target.CashRegisterNo)
				//----- h.ueno add---------- start 2007.12.19
				&& (this.DataInputSystem	== target.DataInputSystem)
				//----- h.ueno add---------- end   2007.12.19
				&& (this.SlipPrtKind		== target.SlipPrtKind)
				&& (this.SlipPrtSetPaperId	== target.SlipPrtSetPaperId)
				&& (this.PrinterMngNo		== target.PrinterMngNo));
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 伝票出力先設定マスタ比較処理
        /// </summary>
        /// <param name="slipOutputSet1">
        ///                    比較するSlipOutputSetクラスのインスタンス
        /// </param>
        /// <param name="slipOutputSet2">比較するSlipOutputSetクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SlipOutputSetクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(SlipOutputSet slipOutputSet1, SlipOutputSet slipOutputSet2)
        {
            return ((slipOutputSet1.CreateDateTime		== slipOutputSet2.CreateDateTime)
				&& (slipOutputSet1.UpdateDateTime		== slipOutputSet2.UpdateDateTime)
				&& (slipOutputSet1.EnterpriseCode		== slipOutputSet2.EnterpriseCode)
				&& (slipOutputSet1.FileHeaderGuid		== slipOutputSet2.FileHeaderGuid)
				&& (slipOutputSet1.UpdEmployeeCode		== slipOutputSet2.UpdEmployeeCode)
				&& (slipOutputSet1.UpdAssemblyId1		== slipOutputSet2.UpdAssemblyId1)
				&& (slipOutputSet1.UpdAssemblyId2		== slipOutputSet2.UpdAssemblyId2)
				&& (slipOutputSet1.LogicalDeleteCode	== slipOutputSet2.LogicalDeleteCode)
                //&& (slipOutputSet1.SectionCode			== slipOutputSet2.SectionCode)      // DEL 2008/06/20
			    //--- ADD 2008/06/19 ---------->>>>>
                && (slipOutputSet1.WarehouseCode        == slipOutputSet2.WarehouseCode)
                //--- ADD 2008/06/19 ----------<<<<<
                && (slipOutputSet1.CashRegisterNo == slipOutputSet2.CashRegisterNo)
				//----- h.ueno add---------- start 2007.12.19
				&& (slipOutputSet1.DataInputSystem		== slipOutputSet2.DataInputSystem)
				//----- h.ueno add---------- end   2007.12.19			
				&& (slipOutputSet1.SlipPrtKind			== slipOutputSet2.SlipPrtKind)
				&& (slipOutputSet1.SlipPrtSetPaperId	== slipOutputSet2.SlipPrtSetPaperId)
				&& (slipOutputSet1.PrinterMngNo			== slipOutputSet2.PrinterMngNo));
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 伝票出力先設定マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のSlipOutputSetクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SlipOutputSetクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(SlipOutputSet target)
        {
            ArrayList resList = new ArrayList();
            if (this.CreateDateTime		!= target.CreateDateTime)		resList.Add("CreateDateTime");
            if (this.UpdateDateTime		!= target.UpdateDateTime)		resList.Add("UpdateDateTime");
            if (this.EnterpriseCode		!= target.EnterpriseCode)		resList.Add("EnterpriseCode");
            if (this.FileHeaderGuid		!= target.FileHeaderGuid)		resList.Add("FileHeaderGuid");
            if (this.UpdEmployeeCode	!= target.UpdEmployeeCode)		resList.Add("UpdEmployeeCode");
            if (this.UpdAssemblyId1		!= target.UpdAssemblyId1)		resList.Add("UpdAssemblyId1");
            if (this.UpdAssemblyId2		!= target.UpdAssemblyId2)		resList.Add("UpdAssemblyId2");
            if (this.LogicalDeleteCode	!= target.LogicalDeleteCode)	resList.Add("LogicalDeleteCode");
            //if (this.SectionCode		!= target.SectionCode)			resList.Add("SectionCode");         // DEL 2008/06/20
            //--- ADD 2008/06/19 ---------->>>>>
            if (this.WarehouseCode      != target.WarehouseCode)        resList.Add("WarehouseCode");
            //--- ADD 2008/06/19 ----------<<<<<
            if (this.CashRegisterNo != target.CashRegisterNo) resList.Add("CashRegisterNo");
			//----- h.ueno add---------- start 2007.12.19
			if (this.DataInputSystem	!= target.DataInputSystem)		resList.Add("DataInputSystem");			
			//----- h.ueno add---------- end   2007.12.19
			if (this.SlipPrtKind		!= target.SlipPrtKind)			resList.Add("SlipPrtKind");
			if (this.SlipPrtSetPaperId	!= target.SlipPrtSetPaperId)	resList.Add("SlipPrtSetPaperId");
			if (this.PrinterMngNo		!= target.PrinterMngNo)			resList.Add("PrinterMngNo");

            return resList;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 伝票出力先設定マスタ比較処理
        /// </summary>
        /// <param name="slipOutputSet1">比較するSlipOutputSetクラスのインスタンス</param>
        /// <param name="slipOutputSet2">比較するSlipOutputSetクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SlipOutputSetクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(SlipOutputSet slipOutputSet1, SlipOutputSet slipOutputSet2)
        {
            ArrayList resList = new ArrayList();
            if (slipOutputSet1.CreateDateTime		!= slipOutputSet2.CreateDateTime)		resList.Add("CreateDateTime");
            if (slipOutputSet1.UpdateDateTime		!= slipOutputSet2.UpdateDateTime)		resList.Add("UpdateDateTime");
            if (slipOutputSet1.EnterpriseCode		!= slipOutputSet2.EnterpriseCode)		resList.Add("EnterpriseCode");
            if (slipOutputSet1.FileHeaderGuid		!= slipOutputSet2.FileHeaderGuid)		resList.Add("FileHeaderGuid");
            if (slipOutputSet1.UpdEmployeeCode		!= slipOutputSet2.UpdEmployeeCode)		resList.Add("UpdEmployeeCode");
            if (slipOutputSet1.UpdAssemblyId1		!= slipOutputSet2.UpdAssemblyId1)		resList.Add("UpdAssemblyId1");
            if (slipOutputSet1.UpdAssemblyId2		!= slipOutputSet2.UpdAssemblyId2)		resList.Add("UpdAssemblyId2");
            if (slipOutputSet1.LogicalDeleteCode	!= slipOutputSet2.LogicalDeleteCode)	resList.Add("LogicalDeleteCode");
            //if (slipOutputSet1.SectionCode          != slipOutputSet2.SectionCode)          resList.Add("SectionCode");       // DEL 2008/06/20
            //--- ADD 2008/06/19 ---------->>>>>
            if (slipOutputSet1.WarehouseCode != slipOutputSet2.WarehouseCode) resList.Add("WarehouseCode");
            //--- ADD 2008/06/19 ----------<<<<<
            if (slipOutputSet1.CashRegisterNo != slipOutputSet2.CashRegisterNo) resList.Add("CashRegisterNo");
			//----- h.ueno add---------- start 2007.12.19
			if (slipOutputSet1.DataInputSystem		!= slipOutputSet2.DataInputSystem)		resList.Add("DataInputSystem");
			//----- h.ueno add---------- end   2007.12.19
			if (slipOutputSet1.SlipPrtKind			!= slipOutputSet2.SlipPrtKind)			resList.Add("SlipPrtKind");
			if (slipOutputSet1.SlipPrtSetPaperId	!= slipOutputSet2.SlipPrtSetPaperId)	resList.Add("SlipPrtSetPaperId");
			if (slipOutputSet1.PrinterMngNo			!= slipOutputSet2.PrinterMngNo)			resList.Add("PrinterMngNo");

            return resList;
        }

		//----- h.ueno add---------- start 2007.12.19
        /// <summary>データ入力システムリスト</summary>
        public static SortedList _dataInputSystemList;
        
        /// <summary>データ入力システムリスト（コンボボックス用）</summary>
        public static SortedList _dataInputSystemComboList;
        //----- h.ueno add---------- end   2007.12.19

		/// <summary>伝票印刷種別リスト</summary>
        //>>>>>>>>>>>>>>>>>>2008/12/08 G.Miyatsu DEL
        //public static SortedList _slipPrtKindList;
        //>>>>>>>>>>>>>>>>>>2008/12/08 G.Miyatsu ADD
        public static DictionaryList _slipPrtKindList;

		/// <summary>拠点コードリスト</summary>
		public static SortedList _sectionCodeList;

        //--- ADD 2008/06/20 --------->>>>>
        public static SortedList _warehouseCodeList;
        //--- ADD 2008/06/20 --------->>>>>

		/// <summary>伝票印刷設定用帳票IDリスト</summary>
		public static SortedList _slipPrtSetPaperIdList;
		
		/// <summary>プリンタ管理Noリスト</summary>
		public static SortedList _printerMngNoList;
		
		/// <summary>
		/// ソートリスト名称取得処理
		/// </summary>
		/// <param name="code">ソートリストコード</param>
		/// <returns>名称</returns>
		/// <remarks>
		/// <br>Note       : ソートリストコードからソートリスト名称を取得します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.12.10</br>
		/// </remarks>
        public static string GetSortedListNm(object code, DictionaryList sList)
        {
            string retStr = "";

            if (sList.ContainsKey((int)code))
            {
                retStr = sList[(int)code].ToString();
            }

            return retStr;
        }

        /// <summary>
        /// ソートリスト名称取得処理(string)
        /// </summary>
        /// <param name="code">ソートリストコード</param>
        /// <returns>名称</returns>
        /// <remarks>
        /// <br>Note       : string型のソートリストコードからソートリスト名称を取得します。</br>
        /// <br>Programmer : 30365 宮津　銀次郎</br>
        /// <br>Date       : 2008.12.08</br>
        /// </remarks>
        public static string GetSortedListNm(object code, SortedList sList)
        {
            string retStr = "";

            if (sList.ContainsKey(code))
            {
                retStr = sList[code].ToString();
            }
            return retStr;
        }


		//----- h.ueno add---------- start 2007.12.19
		/// <summary>
		/// データ入力システム＆伝票印刷種別関連チェック
		/// </summary>
		/// <param name="dataInputSystem">データ入力システム</param>
		/// <returns>チェック結果（true:関連有り, false:関連無し）</returns>
		/// <remarks>
		/// <br>Note	   : データ入力システムと伝票印刷種別の関連性をチェックする</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.12.19</br>
		/// </remarks>
		public static bool DataInputSystemSlipPrtKindCheck(int dataInputSystem, int slipPrtKind)
		{
			bool retBool = false;

			switch (dataInputSystem)
			{
				case 0:	// 共通
					{
						retBool = true;	// 全ての伝票印刷種別設定可
						break;
					}
				case 1:	// 整備
				case 2:	// 鈑金
					{
						switch (slipPrtKind)
						{
							case 10:	// 見積書
							case 20:	// 指示書
							case 21:	// 承り書
							case 30:	// 納品書
								{
									retBool = true;		// 設定可
									break;
								}
							default:	// 上記以外
								{
									retBool = false;	// 設定不可
									break;
								}
						}
						break;
					}
				case 3:	// 車販
					{
						switch (slipPrtKind)
						{
							case 10:	// 見積書
							case 20:	// 指示書
								{
									retBool = true;		// 設定可
									break;
								}
							default:	// 上記以外
								{
									retBool = false;	// 設定不可
									break;
								}
						}
						break;
					}
			}
			return retBool;
		}
		//----- h.ueno add---------- end   2007.12.19
		
		/// <summary>
		/// 静的コンストラクタ
		/// </summary>
		static SlipOutputSet()
		{
			//----- h.ueno add---------- start 2007.12.19
			_dataInputSystemList = MakeDataInputSystemList();
			//----- h.ueno add---------- end   2007.12.19

			_slipPrtKindList = MakeSlipPrtKindList();
		}

		/// <summary>
		/// 伝票印刷種別リスト生成
		/// </summary>
		/// <returns>伝票印刷種別リスト</returns>
		/// <remarks>
		/// <br>Note	   : 伝票印刷種別リストを生成します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.12.06</br>
		/// </remarks>
        #region [2008/12/08 G.Miyatsu DEL]
        //private static SortedList MakeSlipPrtKindList()
        //{
        //    SortedList retSortedList = new SortedList();
        #endregion
        private static DictionaryList MakeSlipPrtKindList()
        {
            DictionaryList retSortedList = new DictionaryList();
            retSortedList.Add(10, "見積書");
            /* --- ADD 2008/11/10 ------------------------------------------------------------>>>>>
            // DEL 2008/10/09 不具合対応[6429] ---------->>>>>
            //retSortedList.Add(20,  "指示書");
            //retSortedList.Add(21,  "承り書");
            // DEL 2008/10/09 不具合対応[6429] ----------<<<<<
            retSortedList.Add(30,  "納品書");
            //retSortedList.Add(40, "返品伝票");         // DEL 2008/10/09 不具合対応[6429]
            //----- h.ueno del ---------- start 2008.03.17
            //retSortedList.Add(100, "ワークシート");
            //retSortedList.Add(110, "ボディ寸法図");
            //----- h.ueno del ---------- end 2008.03.17
               --- DEL 2008/11/10 ------------------------------------------------------------<<<<< */
            // --- ADD 2008/11/10 ------------------------------------------------------------>>>>>
            retSortedList.Add(30, "売上伝票");          // 納品書→売上伝票に変更
            retSortedList.Add(120, "受注伝票");
            retSortedList.Add(130, "貸出伝票");
            retSortedList.Add(140, "見積伝票");
            retSortedList.Add(150, "在庫移動伝票");
            retSortedList.Add(160, "ＵＯＥ伝票");
            // --- ADD 2008/11/10 ------------------------------------------------------------<<<<<
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>2008/12/08 G.Miyatsu ADD
            retSortedList.Add(50, "合計請求書");
            retSortedList.Add(60, "明細請求書");
            retSortedList.Add(70, "伝票合計請求書");
            retSortedList.Add(80, "領収書");
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<2008/12/08 G.Miyatsu ADD
            // --- ADD m.suzuki 2010/09/27 ---------->>>>>
            retSortedList.Add( 99, "帳票" );
            // --- ADD m.suzuki 2010/09/27 ----------<<<<<
            return retSortedList;
		}

		//----- h.ueno add---------- start 2007.12.19
		/// <summary>
		/// データ入力システムリスト生成
		/// </summary>
		/// <returns>データ入力システムリスト</returns>
		/// <remarks>
		/// <br>Note	   : データ入力システムリストを生成します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.12.19</br>
		/// </remarks>
        private static SortedList MakeDataInputSystemList()
        {
            SortedList retSortedList = new SortedList();
            retSortedList.Add(0, "共通");
            retSortedList.Add(1, "整備");
            retSortedList.Add(2, "鈑金");
            retSortedList.Add(3, "車販");

            return retSortedList;
        }


		//----- h.ueno add---------- end   2007.12.19
    }
}

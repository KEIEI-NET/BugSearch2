using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   AcptAnOdrTtlSt
    /// <summary>
    ///                      受発注管理全体設定
    /// </summary>
    /// <remarks>
    /// <br>note             :   受発注管理全体設定ヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2007/12/11  (CSharp File Generated Date)</br>
    /// <br>UpdateNote       :   2008/06/06 30415 柴田 倫幸</br>
    /// <br>        	         ・データ項目の追加/削除による修正</br>    
    /// </remarks>
    public class AcptAnOdrTtlSt
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

        // --- ADD 2008/06/06 -------------------------------->>>>>
        /// <summary>拠点コード</summary>
        /// <remarks>オール０は全社</remarks>
        private string _sectionCode = "";
        // --- ADD 2008/06/06 --------------------------------<<<<< 

        /* --- DEL 2008/06/06 -------------------------------->>>>>
		/// <summary>発注番号構成</summary>
		/// <remarks>1.手入力 2.手入力（7桁）＋受注番号（下7桁）。。。</remarks>
		private Int32 _orderNumberCompo;
           --- DEL 2008/06/06 --------------------------------<<<<< */
        
		/// <summary>見積数反映区分</summary>
		/// <remarks>0:出荷数 1:受注数</remarks>
		private Int32 _estmCountReflectDiv;

		/// <summary>受注伝票発行区分</summary>
		/// <remarks>0:しない 1:する</remarks>
		private Int32 _acpOdrrSlipPrtDiv;

		/// <summary>ＦＡＸ発注区分</summary>
		/// <remarks>0:しない 1:する</remarks>
		private Int32 _faxOrderDiv;

        /* --- DEL 2008/06/06 -------------------------------->>>>>
		/// <summary>ドットクル発注区分</summary>
		/// <remarks>0:しない 1:する</remarks>
		private Int32 _dotKulOrderDiv;
           --- DEL 2008/06/06 --------------------------------<<<<< */


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

        // --- ADD 2008/06/06 -------------------------------->>>>>
        /// public propaty name  :  SectionCode
        /// <summary>拠点コードプロパティ</summary>
        /// <value>オール０は全社</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コードプロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }
        // --- ADD 2008/06/06 --------------------------------<<<<< 

        /* --- DEL 2008/06/06 -------------------------------->>>>>
		/// public propaty name  :  OrderNumberCompo
		/// <summary>発注番号構成プロパティ</summary>
		/// <value>1.手入力 2.手入力（7桁）＋受注番号（下7桁）。。。</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   発注番号構成プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 OrderNumberCompo
		{
			get{return _orderNumberCompo;}
			set{_orderNumberCompo = value;}
		}
           --- DEL 2008/06/06 --------------------------------<<<<< */
        

		/// public propaty name  :  EstmCountReflectDiv
		/// <summary>見積数反映区分プロパティ</summary>
		/// <value>0:出荷数 1:受注数</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   見積数反映区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EstmCountReflectDiv
		{
			get{return _estmCountReflectDiv;}
			set{_estmCountReflectDiv = value;}
		}

		/// public propaty name  :  AcpOdrrSlipPrtDiv
		/// <summary>受注伝票発行区分プロパティ</summary>
		/// <value>0:しない 1:する</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   受注伝票発行区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AcpOdrrSlipPrtDiv
		{
			get{return _acpOdrrSlipPrtDiv;}
			set{_acpOdrrSlipPrtDiv = value;}
		}

		/// public propaty name  :  FaxOrderDiv
		/// <summary>ＦＡＸ発注区分プロパティ</summary>
		/// <value>0:しない 1:する</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ＦＡＸ発注区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 FaxOrderDiv
		{
			get{return _faxOrderDiv;}
			set{_faxOrderDiv = value;}
		}

        /* --- DEL 2008/06/06 -------------------------------->>>>>
		/// public propaty name  :  DotKulOrderDiv
		/// <summary>ドットクル発注区分プロパティ</summary>
		/// <value>0:しない 1:する</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ドットクル発注区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DotKulOrderDiv
		{
			get{return _dotKulOrderDiv;}
			set{_dotKulOrderDiv = value;}
		}
           --- DEL 2008/06/06 --------------------------------<<<<< */
        

		/// <summary>
		/// 受発注管理全体設定コンストラクタ
		/// </summary>
		/// <returns>AcptAnOdrTtlStクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   AcptAnOdrTtlStクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public AcptAnOdrTtlSt()
		{
		}

		/// <summary>
		/// 受発注管理全体設定コンストラクタ
		/// </summary>
		/// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
		/// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
		/// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
		/// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
		/// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="estmCountReflectDiv">見積数反映区分</param>
        /// <param name="acpOdrrSlipPrtDiv">受注伝票発行区分</param>
        /// <param name="faxOrderDiv">ＦＡＸ発注区分</param>
		/// <returns>AcptAnOdrTtlStクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   AcptAnOdrTtlStクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public AcptAnOdrTtlSt(DateTime createDateTime,DateTime updateDateTime,string enterpriseCode,Guid fileHeaderGuid,string updEmployeeCode,string updAssemblyId1,string updAssemblyId2,Int32 logicalDeleteCode,string sectionCode,Int32 estmCountReflectDiv,Int32 acpOdrrSlipPrtDiv ,Int32 faxOrderDiv)
		{
			this.CreateDateTime = createDateTime;
			this.UpdateDateTime = updateDateTime;
			this._enterpriseCode = enterpriseCode;
			this._fileHeaderGuid = fileHeaderGuid;
			this._updEmployeeCode = updEmployeeCode;
			this._updAssemblyId1 = updAssemblyId1;
			this._updAssemblyId2 = updAssemblyId2;
			this._logicalDeleteCode = logicalDeleteCode;
            this._sectionCode = sectionCode;              // ADD 2008/06/06
            //this._orderNumberCompo = orderNumberCompo;  // DEL 2008/06/06
            this._estmCountReflectDiv = estmCountReflectDiv;
            this._acpOdrrSlipPrtDiv = acpOdrrSlipPrtDiv;
            this._faxOrderDiv = faxOrderDiv;
            //this._dotKulOrderDiv = dotKulOrderDiv;      // DEL 2008/06/06
		}

		/// <summary>
		/// 受発注管理全体設定複製処理
		/// </summary>
		/// <returns>AcptAnOdrTtlStクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいAcptAnOdrTtlStクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public AcptAnOdrTtlSt Clone()
		{
			return new AcptAnOdrTtlSt(this._createDateTime,this._updateDateTime,this._enterpriseCode,this._fileHeaderGuid,this._updEmployeeCode,this._updAssemblyId1,this._updAssemblyId2,this._logicalDeleteCode,this._sectionCode,this._estmCountReflectDiv,this._acpOdrrSlipPrtDiv,this._faxOrderDiv);
		}

		/// <summary>
		/// 受発注管理全体設定比較処理
		/// </summary>
		/// <param name="target">比較対象のAcptAnOdrTtlStクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   AcptAnOdrTtlStクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(AcptAnOdrTtlSt target)
		{
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.SectionCode == target.SectionCode)                  // ADD 2008/06/06
                //&& (this.OrderNumberCompo == target.OrderNumberCompo)       // DEL 2008/06/06
                 && (this.EstmCountReflectDiv == target.EstmCountReflectDiv)
                 && (this.AcpOdrrSlipPrtDiv == target.AcpOdrrSlipPrtDiv)
                 && (this.FaxOrderDiv == target.FaxOrderDiv)
                //&& (this.DotKulOrderDiv == target.DotKulOrderDiv)           // DEL 2008/06/06 
                 );
		}

		/// <summary>
		/// 受発注管理全体設定比較処理
		/// </summary>
		/// <param name="acptAnOdrTtlSt1">
		///                    比較するAcptAnOdrTtlStクラスのインスタンス
		/// </param>
		/// <param name="acptAnOdrTtlSt2">比較するAcptAnOdrTtlStクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   AcptAnOdrTtlStクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(AcptAnOdrTtlSt acptAnOdrTtlSt1, AcptAnOdrTtlSt acptAnOdrTtlSt2)
		{
			return ((acptAnOdrTtlSt1.CreateDateTime == acptAnOdrTtlSt2.CreateDateTime)
				 && (acptAnOdrTtlSt1.UpdateDateTime == acptAnOdrTtlSt2.UpdateDateTime)
				 && (acptAnOdrTtlSt1.EnterpriseCode == acptAnOdrTtlSt2.EnterpriseCode)
				 && (acptAnOdrTtlSt1.FileHeaderGuid == acptAnOdrTtlSt2.FileHeaderGuid)
				 && (acptAnOdrTtlSt1.UpdEmployeeCode == acptAnOdrTtlSt2.UpdEmployeeCode)
				 && (acptAnOdrTtlSt1.UpdAssemblyId1 == acptAnOdrTtlSt2.UpdAssemblyId1)
				 && (acptAnOdrTtlSt1.UpdAssemblyId2 == acptAnOdrTtlSt2.UpdAssemblyId2)
				 && (acptAnOdrTtlSt1.LogicalDeleteCode == acptAnOdrTtlSt2.LogicalDeleteCode)
                 && (acptAnOdrTtlSt1.SectionCode == acptAnOdrTtlSt2.SectionCode)                  // ADD 2008/06/06 
                 //&& (acptAnOdrTtlSt1.OrderNumberCompo == acptAnOdrTtlSt2.OrderNumberCompo)      // DEL 2008/06/06
                 && (acptAnOdrTtlSt1.EstmCountReflectDiv == acptAnOdrTtlSt2.EstmCountReflectDiv)
                 && (acptAnOdrTtlSt1.AcpOdrrSlipPrtDiv == acptAnOdrTtlSt2.AcpOdrrSlipPrtDiv)
                 && (acptAnOdrTtlSt1.FaxOrderDiv == acptAnOdrTtlSt2.FaxOrderDiv)
                //&& (acptAnOdrTtlSt1.DotKulOrderDiv == acptAnOdrTtlSt2.DotKulOrderDiv)           // DEL 2008/06/06
                 );
		}
		/// <summary>
		/// 受発注管理全体設定比較処理
		/// </summary>
		/// <param name="target">比較対象のAcptAnOdrTtlStクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   AcptAnOdrTtlStクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(AcptAnOdrTtlSt target)
		{
			ArrayList resList = new ArrayList();
            if (this.CreateDateTime != target.CreateDateTime) resList.Add("CreateDateTime");
            if (this.UpdateDateTime != target.UpdateDateTime) resList.Add("UpdateDateTime");
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.FileHeaderGuid != target.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (this.UpdEmployeeCode != target.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (this.UpdAssemblyId1 != target.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (this.UpdAssemblyId2 != target.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");                         // ADD 2008/06/06
            //if (this.OrderNumberCompo != target.OrderNumberCompo) resList.Add("OrderNumberCompo");        // DEL 2008/06/06
            if (this.EstmCountReflectDiv != target.EstmCountReflectDiv) resList.Add("EstmCountReflectDiv");
            if (this.AcpOdrrSlipPrtDiv != target.AcpOdrrSlipPrtDiv) resList.Add("AcpOdrrSlipPrtDiv");
            if (this.FaxOrderDiv != target.FaxOrderDiv) resList.Add("FaxOrderDiv");
            //if (this.DotKulOrderDiv != target.DotKulOrderDiv) resList.Add("DotKulOrderDiv");              // DEL 2008/06/06

			return resList;
		}

		/// <summary>
		/// 受発注管理全体設定比較処理
		/// </summary>
		/// <param name="acptAnOdrTtlSt1">比較するAcptAnOdrTtlStクラスのインスタンス</param>
		/// <param name="acptAnOdrTtlSt2">比較するAcptAnOdrTtlStクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   AcptAnOdrTtlStクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(AcptAnOdrTtlSt acptAnOdrTtlSt1, AcptAnOdrTtlSt acptAnOdrTtlSt2)
		{
			ArrayList resList = new ArrayList();
            if (acptAnOdrTtlSt1.CreateDateTime != acptAnOdrTtlSt2.CreateDateTime) resList.Add("CreateDateTime");
            if (acptAnOdrTtlSt1.UpdateDateTime != acptAnOdrTtlSt2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (acptAnOdrTtlSt1.EnterpriseCode != acptAnOdrTtlSt2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (acptAnOdrTtlSt1.FileHeaderGuid != acptAnOdrTtlSt2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (acptAnOdrTtlSt1.UpdEmployeeCode != acptAnOdrTtlSt2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (acptAnOdrTtlSt1.UpdAssemblyId1 != acptAnOdrTtlSt2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (acptAnOdrTtlSt1.UpdAssemblyId2 != acptAnOdrTtlSt2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (acptAnOdrTtlSt1.LogicalDeleteCode != acptAnOdrTtlSt2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (acptAnOdrTtlSt1.SectionCode != acptAnOdrTtlSt2.SectionCode) resList.Add("SectionCode");                          // ADD 2008/06/06
            //if (acptAnOdrTtlSt1.OrderNumberCompo != acptAnOdrTtlSt2.OrderNumberCompo) resList.Add("OrderNumberCompo");         // DEL 2008/06/06
            if (acptAnOdrTtlSt1.EstmCountReflectDiv != acptAnOdrTtlSt2.EstmCountReflectDiv) resList.Add("EstmCountReflectDiv");
            if (acptAnOdrTtlSt1.AcpOdrrSlipPrtDiv != acptAnOdrTtlSt2.AcpOdrrSlipPrtDiv) resList.Add("AcpOdrrSlipPrtDiv");
            if (acptAnOdrTtlSt1.FaxOrderDiv != acptAnOdrTtlSt2.FaxOrderDiv) resList.Add("FaxOrderDiv");
            //if (acptAnOdrTtlSt1.DotKulOrderDiv != acptAnOdrTtlSt2.DotKulOrderDiv) resList.Add("DotKulOrderDiv");               // DEL 2008/06/06

			return resList;
		}
	}
}

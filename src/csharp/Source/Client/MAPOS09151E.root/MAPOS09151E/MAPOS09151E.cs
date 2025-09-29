//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 端末管理設定マスタ
// プログラム概要   : 端末管理設定の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/06/05  修正内容 : SCMオプション対応
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   PosTerminalMg
	/// <summary>
	///                      端末管理マスタ
	/// </summary>
	/// <remarks>
	/// <br>note             :   端末管理マスタヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2007/06/11  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class PosTerminalMg
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

        /* --- DEL 2008/06/18 --------->>>>>
		/// <summary>拠点コード</summary>
		private string _sectionCode = "";
           --- DEL 2008/06/18 ---------<<<<<*/

		/// <summary>レジ番号</summary>
        /// <remarks>マシン番号</remarks>
        private Int32 _cashRegisterNo;

		/// <summary>POS/PC端末区分</summary>
		/// <remarks>1：POS端末使用、2：PC端末使用</remarks>
		private Int32 _posPCTermCd;

        // --- ADD 2008/06/18 ---------->>>>>
        /// <summary>使用言語区分</summary>
        private string _useLanguageDivCd = "";

        /// <summary>使用カルチャー区分</summary>
        private string _useCultureDivCd = "";
        // --- ADD 2008/06/18 ----------<<<<<

        // ADD 2009/06/05 ------>>>
        /// <summary>端末IPアドレス</summary>
        private string _machineIpAddr = "";

        /// <summary>端末名称</summary>
        private string _machineName = "";
        // ADD 2009/06/05 ------<<<

		/// <summary>企業名称</summary>
		private string _enterpriseName = "";

		/// <summary>更新従業員名称</summary>
		private string _updEmployeeName = "";


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
			get{return TDateTime.DateTimeToString("GGYYMMDD", _createDateTime);}
			set{}
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
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _createDateTime);}
			set{}
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
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _createDateTime);}
			set{}
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
			get{return TDateTime.DateTimeToString("YY/MM/DD", _createDateTime);}
			set{}
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
			get{return TDateTime.DateTimeToString("GGYYMMDD", _updateDateTime);}
			set{}
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
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDateTime);}
			set{}
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
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDateTime);}
			set{}
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
			get{return TDateTime.DateTimeToString("YY/MM/DD", _updateDateTime);}
			set{}
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

        /* --- DEL 2008/06/18 ---------->>>>>
		/// public propaty name  :  SectionCode
		/// <summary>拠点コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SectionCode
		{
			get{return _sectionCode;}
			set{_sectionCode = value;}
		}
           --- DEL 2008/06/18 ----------<<<<<*/

		/// public propaty name  :  CashRegisterNo
		/// <summary>レジ番号プロパティ</summary>
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

        // --- ADD 2008/06/17 ---------->>>>>
		/// public propaty name  :  PosPCTermCd
		/// <summary>POS/PC端末区分プロパティ</summary>
		/// <value>1：POS端末使用、2：PC端末使用</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   POS/PC端末区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PosPCTermCd
		{
			get{return _posPCTermCd;}
			set{_posPCTermCd = value;}
		}

        // --- ADD 2008/06/18 ---------->>>>>
        /// public propaty name  :  UseLanguageDivCd
        /// <summary>使用言語区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   使用言語区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UseLanguageDivCd
        {
            get { return _useLanguageDivCd; }
            set { _useLanguageDivCd = value; }
        }

        /// public propaty name  :  UseCultureDivCd
        /// <summary>使用カルチャー区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   使用カルチャー区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string UseCultureDivCd
        {
            get { return _useCultureDivCd; }
            set { _useCultureDivCd = value; }
        }
        // --- ADD 2008/06/18 ----------<<<<<

        // ADD 2009/06/05 ------>>>
        /// public propaty name  :  MachineIpAddr
        /// <summary>端末IPアドレスプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   端末IPアドレスプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MachineIpAddr
        {
            get { return _machineIpAddr; }
            set { _machineIpAddr = value; }
        }

        /// public propaty name  :  MachineIpAddr
        /// <summary>端末名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   端末名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MachineName
        {
            get { return _machineName; }
            set { _machineName = value; }
        }
        // ADD 2009/06/05 ------<<<
        
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

		/// public propaty name  :  UpdEmployeeName
		/// <summary>更新従業員名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新従業員名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdEmployeeName
		{
			get{return _updEmployeeName;}
			set{_updEmployeeName = value;}
		}


		/// <summary>
		/// 端末管理マスタコンストラクタ
		/// </summary>
		/// <returns>PosTerminalMgクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   PosTerminalMgクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public PosTerminalMg()
		{
		}

		/// <summary>
		/// 端末管理マスタコンストラクタ
		/// </summary>
		/// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
		/// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
		/// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
		/// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
		/// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="cashRegisterNo">レジ番号(マシン番号)</param>
        /// <param name="posPCTermCd">POS/PC端末区分(1：POS端末使用、2：PC端末使用)</param>
        /// <param name="useLanguageDivCd">使用言語区分</param>
        /// <param name="useCultureDivCd">使用カルチャー区分</param>
        /// <param name="machineIpAddr">端末IPアドレス</param>
        /// <param name="machineName">端末名称</param>
        /// <param name="enterpriseName">企業名称</param>
		/// <param name="updEmployeeName">更新従業員名称</param>
		/// <returns>PosTerminalMgクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   PosTerminalMgクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        //public PosTerminalMg(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 cashRegisterNo, Int32 posPCTermCd, string useLanguageDivCd, string useCultureDivCd, string enterpriseName, string updEmployeeName)
        public PosTerminalMg(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 cashRegisterNo, Int32 posPCTermCd, string useLanguageDivCd, string useCultureDivCd, string machineIpAddr, string machineName, string enterpriseName, string updEmployeeName)
        {
			this.CreateDateTime = createDateTime;
			this.UpdateDateTime = updateDateTime;
			this._enterpriseCode = enterpriseCode;
			this._fileHeaderGuid = fileHeaderGuid;
			this._updEmployeeCode = updEmployeeCode;
			this._updAssemblyId1 = updAssemblyId1;
			this._updAssemblyId2 = updAssemblyId2;
			this._logicalDeleteCode = logicalDeleteCode;
			//this._sectionCode = sectionCode;                  // DEL 2008/06/18
			this._cashRegisterNo = cashRegisterNo;
			this._posPCTermCd = posPCTermCd;
            this._useLanguageDivCd = useLanguageDivCd;
            this._useCultureDivCd = useCultureDivCd;
            this._machineIpAddr = machineIpAddr;    // ADD 2009/06/05
            this._machineName = machineName;        // ADD 2009/06/05
            this._enterpriseName = enterpriseName;
			this._updEmployeeName = updEmployeeName;

		}

		/// <summary>
		/// 端末管理マスタ複製処理
		/// </summary>
		/// <returns>PosTerminalMgクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいPosTerminalMgクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public PosTerminalMg Clone()
		{
            //return new PosTerminalMg(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._cashRegisterNo, this._posPCTermCd, this._useLanguageDivCd, this._useCultureDivCd, this._enterpriseName, this._updEmployeeName);
            return new PosTerminalMg(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._cashRegisterNo, this._posPCTermCd, this._useLanguageDivCd, this._useCultureDivCd, this._machineIpAddr, this._machineName, this._enterpriseName, this._updEmployeeName);
        }

		/// <summary>
		/// 端末管理マスタ比較処理
		/// </summary>
		/// <param name="target">比較対象のPosTerminalMgクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   PosTerminalMgクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(PosTerminalMg target)
		{
			return ((this.CreateDateTime == target.CreateDateTime)
				 && (this.UpdateDateTime == target.UpdateDateTime)
				 && (this.EnterpriseCode == target.EnterpriseCode)
				 && (this.FileHeaderGuid == target.FileHeaderGuid)
				 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
				 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
				 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
				 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
				 //&& (this.SectionCode == target.SectionCode)              // DEL 2008/06/18
				 && (this.CashRegisterNo == target.CashRegisterNo)
				 && (this.PosPCTermCd == target.PosPCTermCd)
                 && (this.UseLanguageDivCd == target.UseLanguageDivCd)
                 && (this.UseCultureDivCd == target.UseCultureDivCd)
                 && (this.MachineIpAddr == target.MachineIpAddr)    // ADD 2009/06/05
                 && (this.MachineName == target.MachineName)        // ADD 2009/06/05
                 && (this.EnterpriseName == target.EnterpriseName)
				 && (this.UpdEmployeeName == target.UpdEmployeeName));
		}

		/// <summary>
		/// 端末管理マスタ比較処理
		/// </summary>
		/// <param name="posTerminalMg1">
		///                    比較するPosTerminalMgクラスのインスタンス
		/// </param>
		/// <param name="posTerminalMg2">比較するPosTerminalMgクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   PosTerminalMgクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(PosTerminalMg posTerminalMg1, PosTerminalMg posTerminalMg2)
		{
			return ((posTerminalMg1.CreateDateTime == posTerminalMg2.CreateDateTime)
				 && (posTerminalMg1.UpdateDateTime == posTerminalMg2.UpdateDateTime)
				 && (posTerminalMg1.EnterpriseCode == posTerminalMg2.EnterpriseCode)
				 && (posTerminalMg1.FileHeaderGuid == posTerminalMg2.FileHeaderGuid)
				 && (posTerminalMg1.UpdEmployeeCode == posTerminalMg2.UpdEmployeeCode)
				 && (posTerminalMg1.UpdAssemblyId1 == posTerminalMg2.UpdAssemblyId1)
				 && (posTerminalMg1.UpdAssemblyId2 == posTerminalMg2.UpdAssemblyId2)
				 && (posTerminalMg1.LogicalDeleteCode == posTerminalMg2.LogicalDeleteCode)
				 //&& (posTerminalMg1.SectionCode == posTerminalMg2.SectionCode)            // DEL 2008/06/18
				 && (posTerminalMg1.CashRegisterNo == posTerminalMg2.CashRegisterNo)
				 && (posTerminalMg1.PosPCTermCd == posTerminalMg2.PosPCTermCd)
                 && (posTerminalMg1.UseLanguageDivCd == posTerminalMg2.UseLanguageDivCd)
                 && (posTerminalMg1.UseCultureDivCd == posTerminalMg2.UseCultureDivCd)
                 && (posTerminalMg1.MachineIpAddr == posTerminalMg2.MachineIpAddr)    // ADD 2009/06/05
                 && (posTerminalMg1.MachineName == posTerminalMg2.MachineName)        // ADD 2009/06/05
                 && (posTerminalMg1.EnterpriseName == posTerminalMg2.EnterpriseName)
				 && (posTerminalMg1.UpdEmployeeName == posTerminalMg2.UpdEmployeeName));
		}
		/// <summary>
		/// 端末管理マスタ比較処理
		/// </summary>
		/// <param name="target">比較対象のPosTerminalMgクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   PosTerminalMgクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(PosTerminalMg target)
		{
			ArrayList resList = new ArrayList();
			if(this.CreateDateTime != target.CreateDateTime)resList.Add("CreateDateTime");
			if(this.UpdateDateTime != target.UpdateDateTime)resList.Add("UpdateDateTime");
			if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
			if(this.FileHeaderGuid != target.FileHeaderGuid)resList.Add("FileHeaderGuid");
			if(this.UpdEmployeeCode != target.UpdEmployeeCode)resList.Add("UpdEmployeeCode");
			if(this.UpdAssemblyId1 != target.UpdAssemblyId1)resList.Add("UpdAssemblyId1");
			if(this.UpdAssemblyId2 != target.UpdAssemblyId2)resList.Add("UpdAssemblyId2");
			if(this.LogicalDeleteCode != target.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			//if(this.SectionCode != target.SectionCode)resList.Add("SectionCode");                     // DEL 2008/06/18
			if(this.CashRegisterNo != target.CashRegisterNo)resList.Add("CashRegisterNo");
			if(this.PosPCTermCd != target.PosPCTermCd)resList.Add("PosPCTermCd");
            if(this.UseLanguageDivCd != target.UseLanguageDivCd) resList.Add("UseLanguageDivCd");
            if(this.UseCultureDivCd != target.UseCultureDivCd) resList.Add("UseCultureDivCd");
            if (this.MachineIpAddr != target.MachineIpAddr) resList.Add("MachineIpAddr");   // ADD 2009/06/05
            if (this.MachineName != target.MachineName) resList.Add("MachineName");         // ADD 2009/06/05
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
			if(this.UpdEmployeeName != target.UpdEmployeeName)resList.Add("UpdEmployeeName");

			return resList;
		}

		/// <summary>
		/// 端末管理マスタ比較処理
		/// </summary>
		/// <param name="posTerminalMg1">比較するPosTerminalMgクラスのインスタンス</param>
		/// <param name="posTerminalMg2">比較するPosTerminalMgクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   PosTerminalMgクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(PosTerminalMg posTerminalMg1, PosTerminalMg posTerminalMg2)
		{
			ArrayList resList = new ArrayList();
			if(posTerminalMg1.CreateDateTime != posTerminalMg2.CreateDateTime)resList.Add("CreateDateTime");
			if(posTerminalMg1.UpdateDateTime != posTerminalMg2.UpdateDateTime)resList.Add("UpdateDateTime");
			if(posTerminalMg1.EnterpriseCode != posTerminalMg2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(posTerminalMg1.FileHeaderGuid != posTerminalMg2.FileHeaderGuid)resList.Add("FileHeaderGuid");
			if(posTerminalMg1.UpdEmployeeCode != posTerminalMg2.UpdEmployeeCode)resList.Add("UpdEmployeeCode");
			if(posTerminalMg1.UpdAssemblyId1 != posTerminalMg2.UpdAssemblyId1)resList.Add("UpdAssemblyId1");
			if(posTerminalMg1.UpdAssemblyId2 != posTerminalMg2.UpdAssemblyId2)resList.Add("UpdAssemblyId2");
			if(posTerminalMg1.LogicalDeleteCode != posTerminalMg2.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
            //if(posTerminalMg1.SectionCode != posTerminalMg2.SectionCode)resList.Add("SectionCode");                   // DEL 2008/06/18
			if(posTerminalMg1.CashRegisterNo != posTerminalMg2.CashRegisterNo)resList.Add("CashRegisterNo");
			if(posTerminalMg1.PosPCTermCd != posTerminalMg2.PosPCTermCd)resList.Add("PosPCTermCd");
            if(posTerminalMg1.UseLanguageDivCd != posTerminalMg2.UseLanguageDivCd) resList.Add("UseLanguageDivCd");
            if(posTerminalMg1.UseCultureDivCd != posTerminalMg2.UseCultureDivCd) resList.Add("UseCultureDivCd");
            if (posTerminalMg1.MachineIpAddr != posTerminalMg2.MachineIpAddr) resList.Add("MachineIpAddr");     // ADD 2009/06/05
            if (posTerminalMg1.MachineName != posTerminalMg2.MachineName) resList.Add("MachineName");           // ADD 2009/06/05
            if (posTerminalMg1.EnterpriseName != posTerminalMg2.EnterpriseName) resList.Add("EnterpriseName");
			if(posTerminalMg1.UpdEmployeeName != posTerminalMg2.UpdEmployeeName)resList.Add("UpdEmployeeName");

			return resList;
		}
	}
}

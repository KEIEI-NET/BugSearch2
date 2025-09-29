using System;
using System.Windows.Forms;
using System.Collections;
using System.Data;
using System.Text;
using System.Collections.Generic;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Text;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// 得意先画面アクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 得意先画面を操作する為のクラスです。</br>
    /// <br>Programmer : 22018 鈴木正臣</br>
    /// <br>Date       : 2208.04.30</br>
    /// <br>UpdateNote : 2008/12/16 30462 行澤仁美　バグ修正</br>
    /// <br>UpdateNote : 2009/03/06 30414 忍幸史　障害ID:12199対応[税率設定マスタはリアル表示に変更]</br>
    /// <br>UpdateNote : 2009/03/10 30414 忍幸史　障害ID:12253対応[初期表示は税率設定マスタより取得するよう変更]</br>
    /// <br>UpdateNote : 2009/12/02 30517 夏野 駿希　MANTIS:14272　表示対象項目にFAX番号追加</br>
    /// <br>UpdateNote : 2009/01/04 30531 大矢 睦美　MANTIS:14873  請求書タイプ毎の出力区分追加</br>
    /// </remarks>
	public class CustomerInputAcs
	{
		// ===================================================================================== //
		// 外部に提供する定数群
		// ===================================================================================== //
		# region public static readonly
        /// <summary>備考１</summary>
		public static readonly int NoteGd_DivCd_CUSTOMERNOTE1  = 1;			// 備考ガイドマスタ区分／得意先備考１
        /// <summary>備考２</summary>
        public static readonly int NoteGd_DivCd_CUSTOMERNOTE2 = 2;			// 備考ガイドマスタ区分／得意先備考２
        /// <summary>備考３</summary>
        public static readonly int NoteGd_DivCd_CUSTOMERNOTE3 = 3;			// 備考ガイドマスタ区分／得意先備考３
        /// <summary>備考４</summary>
        public static readonly int NoteGd_DivCd_CUSTOMERNOTE4 = 4;			// 備考ガイドマスタ区分／得意先備考４
        /// <summary>備考５</summary>
        public static readonly int NoteGd_DivCd_CUSTOMERNOTE5 = 5;			// 備考ガイドマスタ区分／得意先備考５
        /// <summary>備考６</summary>
        public static readonly int NoteGd_DivCd_CUSTOMERNOTE6 = 6;			// 備考ガイドマスタ区分／得意先備考６
        /// <summary>備考７</summary>
        public static readonly int NoteGd_DivCd_CUSTOMERNOTE7 = 7;			// 備考ガイドマスタ区分／得意先備考７
        /// <summary>備考８</summary>
        public static readonly int NoteGd_DivCd_CUSTOMERNOTE8 = 8;			// 備考ガイドマスタ区分／得意先備考８
        /// <summary>備考９</summary>
        public static readonly int NoteGd_DivCd_CUSTOMERNOTE9 = 9;			// 備考ガイドマスタ区分／得意先備考９
        /// <summary>備考１０</summary>
        public static readonly int NoteGd_DivCd_CUSTOMERNOTE10 = 10;		// 備考ガイドマスタ区分／得意先備考１０
		# endregion

		// ===================================================================================== //
		// スタティックな変数群
		// ===================================================================================== //
		#region Static Fields
		private static ArrayList _userGdHdListStc;
        // --- CHG 2009/03/24 残案件No.14対応------------------------------------------------------>>>>>
        //private static List<UserGdBd> _userGdBdListStc;
        /// <summary>ユーザーガイド(ボディ)リスト</summary>
        public static List<UserGdBd> _userGdBdListStc;
        // --- CHG 2009/03/24 残案件No.14対応------------------------------------------------------<<<<<
        private static AllDefSet _allDefSetStc;			// 全体初期値設定マスタ
		private static ArrayList _noteGuidHdListStc;
        private static ArrayList _salesProcMoneyStc;    // 売上金額処理区分
        private static Dictionary<string,AllDefSet> stc_allDefSetDic;     // 全体初期値設定マスタDictionary
        private static TaxRateSet stc_taxRateSet;   // 税率設定マスタ
        private static Dictionary<string, string> _sectionNameDic = null;              // 拠点名称ディクショナリ
		# endregion

		// ===================================================================================== //
		// プライベート変数
		// ===================================================================================== //
		# region Private Members
		private string _key = string.Empty;												// ユニークキー文字列
		private string _enterpriseCode = string.Empty;
		private string _loginSectionCode = string.Empty;									// ログイン拠点コード
		private AddressGuide _addressGuide = null;								// 住所ガイド
		private UserGuideAcs _userGuideAcs = null;								// ユーザーガイドマスタアクセスクラス
		private EmployeeAcs _employeeAcs = null;								// 従業員マスタアクセスクラス
		private CustomerInfoAcs _customerInfoAcs = null;						// 得意先情報アクセスクラス
		private UserGuideGuide _userGuideGuide = null;							// ユーザーガイドガイド
        private SalesProcMoneyAcs _salesProcMoneyAcs = null;                    // 売上金額処理区分アクセスクラス
        // --- CHG 2009/03/24 残案件No.14対応------------------------------------------------------>>>>>
        //private List<SalesProcMoneyKey> _salesProcMoneyCdList;                  // 売上金額処理クラスキーリスト
        /// <summary>売上金額処理キーリスト</summary>
        public List<SalesProcMoneyKey> _salesProcMoneyCdList;                  // 売上金額処理クラスキーリスト
        // --- CHG 2009/03/24 残案件No.14対応------------------------------------------------------<<<<<
        private SecInfoSetAcs _secInfoSetAcs = null;                            // 拠点アクセスクラス 
        private TaxRateSetAcs _taxRateSetAcs = null;                            // 税率設定マスタ
        private AllDefSetAcs _allDefSetAcs = null;                              // 全体初期値設定マスタ
        private WarehouseAcs _warehouseAcs = null;                              // 倉庫マスタアクセスクラス
		# endregion

        // ===================================================================================== //
        // Structure
        // ===================================================================================== //
        # region Struct
        /// <summary>
        /// 売上金額端数処理キー構造体
        /// </summary>
        // --- CHG 2009/03/24 残案件No.14対応------------------------------------------------------>>>>>
        //private struct SalesProcMoneyKey
        public struct SalesProcMoneyKey
        // --- CHG 2009/03/24 残案件No.14対応------------------------------------------------------<<<<<
        {
            //fractionProcCode

            private int _fracProcMoneyDiv;
            private int _fractionProcCode;

            /// <summary>端数処理区分</summary>
            public int FracProcMoneyDiv
            {
                get { return _fracProcMoneyDiv; }
                set { _fracProcMoneyDiv = value; }
            }
            /// <summary>端数処理コード</summary>
            public int FractionProcCode
            {
                get { return _fractionProcCode; }
                set { _fractionProcCode = value; }
            }
            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="fracProcMoneyDiv"></param>
            /// <param name="fractionProcCode"></param>
            public SalesProcMoneyKey( int fracProcMoneyDiv, int fractionProcCode )
            {
                this._fracProcMoneyDiv = fracProcMoneyDiv;
                this._fractionProcCode = fractionProcCode;
            }
        }
        # endregion

        // ===================================================================================== //
		// コンストラクタ
		// ===================================================================================== //
		# region Constructor
		/// <summary>
		/// 得意先入力用アクセスクラス デフォルトコンストラクタ
		/// </summary>
        public CustomerInputAcs() : this(string.Empty)
        {
        }

		/// <summary>
		/// 得意先入力用アクセスクラス デフォルトコンストラクタ
		/// </summary>
		/// <param name="key">ユニークキー文字列</param>
		public CustomerInputAcs(string key)
		{
			this._key = key;

			// 変数初期化
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
			this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            if (string.IsNullOrEmpty(key)) {
                this._customerInfoAcs = new CustomerInfoAcs();
            }
            else {
                this._customerInfoAcs = new CustomerInfoAcs(this._key);
            }
            this._userGuideAcs = new UserGuideAcs();
			this._addressGuide = new AddressGuide();
			this._employeeAcs = new EmployeeAcs();
			this._userGuideGuide = new UserGuideGuide();
            this._salesProcMoneyAcs = new SalesProcMoneyAcs();
            this._secInfoSetAcs = new SecInfoSetAcs();
            this._taxRateSetAcs = new TaxRateSetAcs();
            this._allDefSetAcs = new AllDefSetAcs();
            this._warehouseAcs = new WarehouseAcs();
		}
		# endregion

		// ===================================================================================== //
		// Static領域操作メソッド
		// ===================================================================================== //
		# region StaticMemory Control
        /// <summary>
        /// 拠点名称取得処理
        /// </summary>
        /// <param name="sectionCode"></param>
        /// <returns></returns>
        public string GetSectionName( string sectionCode )
        {
            if ( _sectionNameDic == null )
            {
                _sectionNameDic = new Dictionary<string, string>();
                SecInfoAcs acs = new SecInfoAcs();
                SecInfoSet[] sections = acs.SecInfoSetList;

                foreach ( SecInfoSet section in sections )
                {
                    if ( !_sectionNameDic.ContainsKey( section.SectionCode ) )
                    {
                        _sectionNameDic.Add( section.SectionCode, section.SectionGuideNm );
                    }
                }
            }

            if ( _sectionNameDic.ContainsKey( sectionCode ) )
            {
                return _sectionNameDic[sectionCode];
            }
            else
            {
                return string.Empty;
            }
        }
		/// <summary>
		/// Static情報の変更処理
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
        /// <param name="customerInfo">変更するデータ（戻り値として変更後のデータ）</param>
		/// <returns>STATUS[0:更新成功,1:更新せず終了]</returns>
		/// <remarks>
		/// <br>Note		: Staticなエリアに車輌情報を設定します。</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2208.04.30</br>
        /// </remarks>
		public int WriteStaticMemoryData(object sender, CustomerInfo customerInfo)
		{
			return this._customerInfoAcs.WriteStaticMemoryData(sender, customerInfo);
		}

		/// <summary>
		/// Static情報の取得処理
		/// </summary>
		/// <param name="customerInfo">取得するデータ</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="customerCode">得意先コード</param>
		/// <returns>STATUS[0:取得成功,1:取得せず終了]</returns>
		public int ReadStaticMemoryData(out CustomerInfo customerInfo, string enterpriseCode, int customerCode)
		{
			return this._customerInfoAcs.ReadStaticMemoryData(out customerInfo, enterpriseCode, customerCode);
		}

		/// <summary>
		/// StaticMemory初期化処理
		/// </summary>
		/// <param name="mode">モード[0:両方,1:MainStaticMemory,2:UndoStaticMemory]</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="customerCode">得意先コード</param>
		/// <param name="ownSectionCode">自拠点コード</param>
		/// <param name="customerInfo">得意先情報クラス</param>
		/// <returns>0:成功</returns>
		public int InitialStaticMemory(int mode, string enterpriseCode, int customerCode, string ownSectionCode, out CustomerInfo customerInfo)
		{
			CustomerInfo customerInfoBuff = new CustomerInfo();

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/29 DEL
            //// 全体初期値設定マスタ取得
            //this.ReadAllDefSet(enterpriseCode, this._loginSectionCode);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/29 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/29 ADD
            // 全体初期値設定マスタ取得
            _allDefSetStc = GetAllDefSet( this._enterpriseCode, this._loginSectionCode );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/29 ADD


			// 拠点

			// 初期値セット
			customerInfoBuff.EnterpriseCode = enterpriseCode;

			// 初期値セット
			customerInfoBuff.TotalDay = _allDefSetStc.DefDspCustTtlDay;				// 得意先締日
			customerInfoBuff.CollectMoneyDay = _allDefSetStc.DefDspCustClctMnyDay;	// 集金日
			customerInfoBuff.CollectMoneyCode = _allDefSetStc.DefDspClctMnyMonthCd;	// 集金月区分コード
			customerInfoBuff.CorporateDivCode = _allDefSetStc.IniDspPrslOrCorpCd;	// 個人・法人区分
			customerInfoBuff.DmOutCode = _allDefSetStc.InitDspDmDiv;				// 初期表示DM区分
			customerInfoBuff.BillOutputCode = _allDefSetStc.DefDspBillPrtDivCd;		// 初期表示請求書出力区分
			customerInfoBuff.HonorificTitle = "様";									// 敬称
			customerInfoBuff.MngSectionCode = ownSectionCode;						// 管理拠点コード
            customerInfoBuff.ClaimSectionCode = ownSectionCode;                     // 請求拠点コード
			customerInfoBuff.InpSectionCode = ownSectionCode;						// 入力拠点コード
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/29 DEL
            //customerInfoBuff.TotalAmountDispWayCd = 1;								// 総額表示方法区分
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/29 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/29 ADD
            customerInfoBuff.TotalAmountDispWayCd = _allDefSetStc.TotalAmountDispWayCd; // 総額表示方法区分
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/29 ADD
            customerInfoBuff.AccRecDivCd = 1; // 売掛区分 (1:売掛)
            //customerInfoBuff.CustomerAgentCd = LoginInfoAcquisition.Employee.EmployeeCode;  // 得意先担当者　　←　ログイン担当者をセット // 2010/12/06
            //customerInfoBuff.CustomerAgentNm = LoginInfoAcquisition.Employee.Name;          // 得意先担当者名　←　ログイン担当者をセット // 2010/12/06
            customerInfoBuff.CustomerAgentCd = string.Empty;  // ADD 2010/12/06
            customerInfoBuff.CustomerAgentNm = string.Empty;  // ADD 2010/12/06

            // --- ADD 2009/03/10 障害ID:12253対応------------------------------------------------------>>>>>
            // 消費税転嫁方式
            customerInfoBuff.ConsTaxLayMethod = GetConsTaxLayMethod(this._enterpriseCode, 0);
            // --- ADD 2009/03/10 障害ID:12253対応------------------------------------------------------<<<<<

            // 拠点名称セット
            customerInfoBuff.MngSectionName = GetSectionName( customerInfoBuff.MngSectionCode );
            customerInfoBuff.ClaimSectionName = GetSectionName( customerInfoBuff.ClaimSectionCode );
            customerInfoBuff.InpSectionName = GetSectionName( customerInfoBuff.InpSectionCode );

			// TEL表示名称設定処理
			this._customerInfoAcs.SetDspName(ref customerInfoBuff);

            // ADD 2008/12/16 不具合対応[9270] ---------->>>>>
            //優先倉庫の初期値設定
            customerInfoBuff.CustWarehouseCd = "";
            // ADD 2008/12/16 不具合対応[9270] ----------<<<<<

            // StaticMemory初期化情報保存処理
			this._customerInfoAcs.WriteInitStaticMemory(mode, customerInfoBuff);
			
			customerInfo = customerInfoBuff.Clone();
			return 0;
		}
		# endregion

		// ===================================================================================== //
		// 共通処理
		// ===================================================================================== //
		# region Common
		/// <summary>
		/// 住所情報戻り値クラス→得意先情報クラス格納処理
		/// </summary>
		/// <param name="adResult">住所情報戻り値クラス</param>
		/// <param name="customerInfo">得意先情報クラス</param>
		public void SetCustomerInfoOwnerAddressFromAddressGuideResult(AddressGuideResult adResult, ref CustomerInfo customerInfo)
		{
			customerInfo.PostNo = adResult.PostNo.TrimEnd();

			// 住所名称分割処理
			string address1;
			string address2;
			this.DivisionAddressName(30, adResult.AddressName, out address1, out address2);
			customerInfo.Address1 = address1.TrimEnd();
			customerInfo.Address3 = address2.TrimEnd();
		}

		/// <summary>
		/// 従業員クラス→得意先情報クラスの得意先担当情報格納処理
		/// </summary>
		/// <param name="employee">従業員クラス</param>
		/// <param name="customerInfo">得意先情報クラス</param>
		public void SetCustomerInfoAgentFromEmployee(Employee employee, ref CustomerInfo customerInfo)
		{
			customerInfo.CustomerAgentCd = employee.EmployeeCode;
			customerInfo.CustomerAgentNm = employee.Name;
		}
        /// <summary>
        /// 従業員クラス→得意先情報クラスの旧得意先担当情報格納処理
        /// </summary>
        /// <param name="employee">従業員クラス</param>
        /// <param name="customerInfo">得意先情報クラス</param>
        public void SetOldCustomerInfoAgentFromEmployee ( Employee employee, ref CustomerInfo customerInfo )
        {
            customerInfo.OldCustomerAgentCd = employee.EmployeeCode;
            customerInfo.OldCustomerAgentNm = employee.Name;
        }

		/// <summary>
		/// 従業員クラス→得意先情報クラスの集金担当情報格納処理
		/// </summary>
		/// <param name="employee">従業員クラス</param>
		/// <param name="customerInfo">得意先情報クラス</param>
		public void SetBillCollecterFromEmployee(Employee employee, ref CustomerInfo customerInfo)
		{
			customerInfo.BillCollecterCd = employee.EmployeeCode;
			customerInfo.BillCollecterNm = employee.Name;
		}

		/// <summary>
		/// 得意先情報クラス→得意先情報クラス（請求先情報）格納処理
		/// </summary>
		/// <param name="customerSource">格納元得意先情報クラス</param>
		/// <param name="customerInfo">格納先得意先情報クラス</param>
		public void SetCustomerInfoClaimInfoFromCustomerInfo(CustomerInfo customerSource, ref CustomerInfo customerInfo)
		{
			customerInfo.ClaimCode = customerSource.CustomerCode;
			customerInfo.ClaimName = customerSource.Name;
			customerInfo.ClaimName2 = customerSource.Name2;
            customerInfo.ClaimSnm = customerSource.CustomerSnm;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            customerInfo.TotalDay = customerSource.TotalDay;
            customerInfo.CollectMoneyCode = customerSource.CollectMoneyCode;
            customerInfo.CollectMoneyDay = customerSource.CollectMoneyDay;
            customerInfo.CollectCond = customerSource.CollectCond;
            customerInfo.CollectSight = customerSource.CollectSight;
            customerInfo.NTimeCalcStDate = customerSource.NTimeCalcStDate;
            customerInfo.TotalAmntDspWayRef = customerSource.TotalAmntDspWayRef;
            customerInfo.TotalAmountDispWayCd = customerSource.TotalAmountDispWayCd;
            customerInfo.CustCTaXLayRefCd = customerSource.CustCTaXLayRefCd;
            customerInfo.ConsTaxLayMethod = customerSource.ConsTaxLayMethod;
            customerInfo.DepoDelCode = customerSource.DepoDelCode;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/10 ADD
            customerInfo.SalesUnPrcFrcProcCd = customerSource.SalesUnPrcFrcProcCd;
            customerInfo.SalesMoneyFrcProcCd = customerSource.SalesMoneyFrcProcCd;
            customerInfo.SalesCnsTaxFrcProcCd = customerSource.SalesCnsTaxFrcProcCd;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/10 ADD
		}

		/// <summary>
		/// 得意先検索結果クラス→得意先情報クラス（請求先情報）格納処理
		/// </summary>
		/// <param name="customerSource">格納元得意先検索結果クラス</param>
		/// <param name="customerInfo">格納先得意先情報クラス</param>
		public void SetCustomerInfoClaimInfoFromCustomerInfo(CustomerSearchRet customerSource, ref CustomerInfo customerInfo)
		{
            customerInfo.ClaimCode = customerSource.CustomerCode;
            customerInfo.ClaimName = customerSource.Name;
            customerInfo.ClaimName2 = customerSource.Name2;
            customerInfo.ClaimSnm = customerSource.Snm;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            CustomerInfo custClaim;
            int status = this.GetCustomerInfoFromCustomerCode( ConstantManagement.LogicalMode.GetData0, customerSource.CustomerCode, out custClaim );
            if ( status == 0 )
            {
                customerInfo.TotalDay = custClaim.TotalDay;
                customerInfo.CollectMoneyCode = custClaim.CollectMoneyCode;
                customerInfo.CollectMoneyDay = custClaim.CollectMoneyDay;
                customerInfo.CollectCond = custClaim.CollectCond;
                customerInfo.CollectSight = custClaim.CollectSight;
                customerInfo.NTimeCalcStDate = custClaim.NTimeCalcStDate;
                customerInfo.TotalAmntDspWayRef = custClaim.TotalAmntDspWayRef;
                customerInfo.TotalAmountDispWayCd = custClaim.TotalAmountDispWayCd;
                customerInfo.CustCTaXLayRefCd = custClaim.CustCTaXLayRefCd;
                customerInfo.ConsTaxLayMethod = custClaim.ConsTaxLayMethod;
                customerInfo.DepoDelCode = custClaim.DepoDelCode;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/11/10 ADD
                customerInfo.SalesUnPrcFrcProcCd = custClaim.SalesUnPrcFrcProcCd;
                customerInfo.SalesMoneyFrcProcCd = custClaim.SalesMoneyFrcProcCd;
                customerInfo.SalesCnsTaxFrcProcCd = custClaim.SalesCnsTaxFrcProcCd;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/11/10 ADD
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
		}

		/// <summary>
		/// 得意先情報クラス（得意先情報）→得意先情報クラス（請求先情報）格納処理
		/// </summary>
		/// <param name="customerInfo">得意先情報クラス</param>
		public void CopyCustomerInfoClaimInfoFromCustomerInfo(ref CustomerInfo customerInfo)
		{
            customerInfo.ClaimCode = customerInfo.CustomerCode;
            customerInfo.ClaimName = customerInfo.Name;
            customerInfo.ClaimName2 = customerInfo.Name2;
            customerInfo.ClaimSnm = customerInfo.CustomerSnm;
		}

		/// <summary>
		/// 備考ガイドボディクラス→得意先情報クラス格納処理
		/// </summary>
		/// <param name="noteGuideDivCode">備考ガイド区分</param>
		/// <param name="noteGuidBd">備考ガイドボディクラス</param>
		/// <param name="customerInfo">得意先情報クラス</param>
		public void SetCustomerInfoFromNoteGuidBd(int noteGuideDivCode, NoteGuidBd noteGuidBd, ref CustomerInfo customerInfo)
		{
			// 桁数チェック
			if (noteGuidBd.NoteGuideName.Length > 20)
			{
				noteGuidBd.NoteGuideName = noteGuidBd.NoteGuideName.Remove(20, noteGuidBd.NoteGuideName.Length - 20);
			}

            // 備考セット
            switch ( noteGuideDivCode )
            {
                case 1:
                    customerInfo.Note1 = noteGuidBd.NoteGuideName;
                    break;
                case 2:
                    customerInfo.Note2 = noteGuidBd.NoteGuideName;
                    break;
                case 3:
                    customerInfo.Note3 = noteGuidBd.NoteGuideName;
                    break;
                case 4:
                    customerInfo.Note4 = noteGuidBd.NoteGuideName;
                    break;
                case 5:
                    customerInfo.Note5 = noteGuidBd.NoteGuideName;
                    break;
                case 6:
                    customerInfo.Note6 = noteGuidBd.NoteGuideName;
                    break;
                case 7:
                    customerInfo.Note7 = noteGuidBd.NoteGuideName;
                    break;
                case 8:
                    customerInfo.Note8 = noteGuidBd.NoteGuideName;
                    break;
                case 9:
                    customerInfo.Note9 = noteGuidBd.NoteGuideName;
                    break;
                case 10:
                    customerInfo.Note10 = noteGuidBd.NoteGuideName;
                    break;
                default:
                    break;
            }
		}

		/// <summary>
		/// 住所名称分割処理
		/// </summary>
		/// <param name="length">分割文字数</param>
		/// <param name="addressName">住所名称</param>
		/// <param name="addressName1">住所名称分割結果１</param>
		/// <param name="addressName2">住所名称分割結果２</param>
		private void DivisionAddressName(int length, string addressName, out string addressName1, out string addressName2)
		{
			addressName1 = addressName;
			addressName2 = string.Empty;

			if (addressName.Length > length)
			{
				addressName1 = addressName.Substring(0, length);
				addressName2 = addressName.Substring(length, addressName.Length - length);
			}
			else
			{
				return;
			}
		}

		/// <summary>
		/// 検索電話番号生成処理
		/// </summary>
        /// <param name="customerInfo">得意先情報クラス</param>
		/// <returns>検索電話番号</returns>
		public string CreateSearchTelNo(CustomerInfo customerInfo)
		{
			string searchTelNo = customerInfo.SearchTelNo;

			switch (customerInfo.MainContactCode)
			{
				case 0:
				{
					searchTelNo = this.CreateSearchTelNo(customerInfo.HomeTelNo);
					break;
				}
				case 1:
				{
					searchTelNo = this.CreateSearchTelNo(customerInfo.OfficeTelNo);
					break;
				}
				case 2:
				{
					searchTelNo = this.CreateSearchTelNo(customerInfo.PortableTelNo);
					break;
				}
				case 3:
				{
					searchTelNo = this.CreateSearchTelNo(customerInfo.HomeFaxNo);
					break;
				}
				case 4:
				{
					searchTelNo = this.CreateSearchTelNo(customerInfo.OfficeFaxNo);
					break;
				}
				case 5:
				{
					searchTelNo = this.CreateSearchTelNo(customerInfo.OthersTelNo);
					break;
				}
			}

			return searchTelNo;
		}

		/// <summary>
		/// 検索電話番号生成処理
		/// </summary>
        /// <param name="customerInfo">得意先情報クラス</param>
		/// <param name="targetContactCode">対象連絡先区分</param>
		/// <returns>検索電話番号</returns>
		public string CreateSearchTelNo(CustomerInfo customerInfo, int targetContactCode)
		{
			if (customerInfo.MainContactCode != targetContactCode) return customerInfo.SearchTelNo;

			return CreateSearchTelNo(customerInfo);
		}

		/// <summary>
		/// 検索電話番号生成処理
		/// </summary>
        /// <param name="telNo">得意先情報クラス</param>
		/// <returns>検索電話番号</returns>
		public string CreateSearchTelNo(string telNo)
		{
			if ((telNo == null) || (telNo == "")) return string.Empty;

			StringBuilder telNoBuff = new StringBuilder();

			for (int i = telNo.Length; i > 0; i--)
			{
				string no = telNo.Substring(i - 1, 1);

				// 数値以外の場合は処理終了
				System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"^[0-9]+$");
				if (!regex.IsMatch(no))
				{
					break;
				}

				telNoBuff.Insert(0, no);

				// 4文字になった時点で処理終了
				if (telNoBuff.Length == 4)
				{
					break;
				}
			}

			return telNoBuff.ToString();
		}
		# endregion

        // ===================================================================================== //
		// ＤＢデータ取得処理
		// ===================================================================================== //
		# region DataBase Control
		/// <summary>
		/// ユーザーガイドマスタヘッダ部リスト取得処理
		/// </summary>
		/// <returns>STATUS [0:取得 0以外:取得失敗]</returns>
		public int GetUserGdHdListToStatic()
		{
			if (_userGdHdListStc == null)
			{
				_userGdHdListStc = new ArrayList();
			}

			ArrayList userGdHdList = null;

			// ユーザーガイド（ヘッダ）情報全検索処理（論理削除除く）
			int status = this._userGuideAcs.SearchHeader(out userGdHdList);

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				_userGdHdListStc = (ArrayList)userGdHdList.Clone();
			}

			return status;
		}

		/// <summary>
		/// ユーザーガイドヘッダ名称取得処理
		/// </summary>
		/// <param name="guideDivCode">ユーザーガイド区分</param>
		/// <returns>ユーザーガイドヘッダ名称</returns>
		public string GetUserGdHd(int guideDivCode)
		{
			string userGdName = string.Empty;
			if (_userGdHdListStc == null)
			{
				return userGdName;
			}

			foreach (UserGdHd ugh in _userGdHdListStc)
			{
				if (ugh.UserGuideDivCd == guideDivCode)
				{
					userGdName = ugh.UserGuideDivNm;
					break;
				}
			}

			return userGdName;
		}

		/// <summary>
		/// ユーザーガイドマスタボディ部リスト取得処理
		/// </summary>
		/// <returns>STATUS [0:取得 0以外:取得失敗]</returns>
		public int GetUserGdBdListToStatic()
		{
			if (_userGdBdListStc == null)
			{
				_userGdBdListStc = new List<UserGdBd>();
			}
			else
			{
				return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}

			ArrayList userGdBdList = null;

			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

			try
			{
				// ユーザーガイド（ヘッダ）情報全検索処理（論理削除除く）
				status = this._userGuideAcs.SearchBody(out userGdBdList, this._enterpriseCode, UserGuideAcsData.MergeBodyData);

				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					_userGdBdListStc.AddRange((UserGdBd[])userGdBdList.ToArray(typeof(UserGdBd)));
				}
			}
			catch (Exception e)
			{
				TMsgDisp.Show(
					emErrorLevel.ERR_LEVEL_STOPDISP,
					this.ToString(),
					"ユーザーガイド（ヘッダ）情報の取得に失敗しました。" + "\r\n" + e.Message,
					-1,
					MessageBoxButtons.OK);

				status = -1;
			}


			return status;
		}

		/// <summary>
		/// ユーザーガイドマスタリスト取得処理
		/// </summary>
		/// <param name="guideDivCode">ユーザーガイド区分</param>
		/// <param name="retList">戻り値リスト</param>
		/// <returns>STATUS [0:取得 0以外:取得失敗]</returns>
		public int GetDivCodeBodyList(int guideDivCode, out ArrayList retList)
		{
			if (_userGdBdListStc == null)
			{
				// ユーザーガイドマスタボディ部リスト取得処理
				this.GetUserGdBdListToStatic();
			}

			retList = new ArrayList();

			foreach (UserGdBd ugb in _userGdBdListStc)
			{
                // --- ADD 2009/03/24 残案件No.14対応------------------------------------------------------>>>>>
                //if (ugb.UserGuideDivCd == guideDivCode)
                if ((ugb.UserGuideDivCd == guideDivCode) && (ugb.LogicalDeleteCode == 0))
                // --- ADD 2009/03/24 残案件No.14対応------------------------------------------------------<<<<<
                {
					ComboEditorItemCustomer comboEditorItem = new ComboEditorItemCustomer(ugb.GuideCode, ugb.GuideName);
					retList.Add(comboEditorItem);
				}
			}
			
			if (retList.Count > 0)
			{
				return 0;
			}
			else
			{
				return -1;
			}
		}

        /// <summary>
        /// 売上端数処理リスト取得処理（STATIC退避）
        /// </summary>
        /// <returns>STATUS [0:取得 0以外:取得失敗]</returns>
        public int GetSalesProcMoneyListToStatic ()
        {
            if ( _salesProcMoneyStc == null ) {
                _salesProcMoneyStc = new ArrayList();
            }
            else {
                return ( int ) ConstantManagement.DB_Status.ctDB_NORMAL;
            }

            ArrayList saleProcMoneyList = null;

            int status = ( int ) ConstantManagement.DB_Status.ctDB_EOF;

            try {

                // 売上金額処理
                status = this._salesProcMoneyAcs.SearchAll( out saleProcMoneyList, this._enterpriseCode );

                if ( status == ( int ) ConstantManagement.DB_Status.ctDB_NORMAL ) {
                    _salesProcMoneyStc.AddRange(saleProcMoneyList);
                }
                
            }
            catch ( Exception e ) {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOPDISP,
                    this.ToString(),
                    "売上端数処理情報の取得に失敗しました。" + "\r\n" + e.Message,
                    -1,
                    MessageBoxButtons.OK);

                status = -1;
            }

            return status;
        }
        /// <summary>
        /// 売上端数処理リスト取得処理
        /// </summary>
        /// <param name="retList">戻り値リスト</param>
        /// <param name="fracProcMoneyDiv">0:売上金額, 1:消費税, 2:売上単価</param>
        /// <returns>STATUS [0:取得 0以外:取得失敗]</returns>
        public int GetSalesProcMoneyList ( out ArrayList retList, int fracProcMoneyDiv )
        {
            if ( _salesProcMoneyStc == null ) {
                // 売上端数処理リスト取得処理
                this.GetSalesProcMoneyListToStatic();
            }

            retList = new ArrayList();
            Hashtable hash = new Hashtable();

            foreach ( SalesProcMoney salesProcMoney in _salesProcMoneyStc ) {
                // 端数処理対象金額区分(FracProcMoneyDiv)が指定された値と同じものだけ、retListに追加する。
                // 同一端数処理コードで上限金額違いのレコードも存在する為、
                // Hashで重複チェックする。
                if ( salesProcMoney.FracProcMoneyDiv == fracProcMoneyDiv ) {

                    // 重複チェック
                    if (hash.Contains( salesProcMoney.FractionProcCode ) ) continue;
                    hash.Add( salesProcMoney.FractionProcCode, salesProcMoney );

                    ComboEditorItemCustomer comboEditorItem = new ComboEditorItemCustomer(salesProcMoney.FractionProcCode, ( string ) salesProcMoney.FractionProcCode.ToString());
                    retList.Add(comboEditorItem);
                }
            }

            if ( retList.Count > 0 ) {
                return 0;
            }
            else {
                return -1;
            }
        }

		/// <summary>
		/// 備考ガイドマスタヘッダ部リスト取得処理
		/// </summary>
		/// <returns>STATUS [0:取得 0以外:取得失敗]</returns>
		public int GetNoteGuideHdListToStatic()
		{
			if (_noteGuidHdListStc == null)
			{
				_noteGuidHdListStc = new ArrayList();
			}

			ArrayList noteGuidHdList = null;
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			// 備考ガイド（ヘッダ）情報全検索処理（論理削除除く）
			NoteGuidAcs noteGuidAcs = new NoteGuidAcs();		// 備考ガイドマスタアクセスクラス

			try
			{
				status = noteGuidAcs.SearchHeader(out noteGuidHdList, this._enterpriseCode);
			}
			catch (System.Net.WebException e)
			{
				TMsgDisp.Show(
					emErrorLevel.ERR_LEVEL_STOPDISP,
					this.ToString(),
					"備考ガイド（ヘッダ）情報の取得に失敗しました。" + "\r\n" + e.Message,
					-1,
					MessageBoxButtons.OK);

				status = -1;
			}

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				_noteGuidHdListStc = (ArrayList)noteGuidHdList.Clone();
			}

			return status;
		}

		/// <summary>
		/// 備考ガイドヘッダ名称取得処理
		/// </summary>
		/// <param name="guideDivCode">ユーザーガイド区分</param>
		/// <returns>ユーザーガイドヘッダ名称</returns>
		public string GetNoteGuideHd(int guideDivCode)
		{
			string noteGuideName = string.Empty;
			if (_noteGuidHdListStc == null)
			{
				return noteGuideName;
			}

			foreach (NoteGuidHd ngh in _noteGuidHdListStc)
			{
				if (ngh.NoteGuideDivCode == guideDivCode)
				{
					noteGuideName = ngh.NoteGuideDivName;
					break;
				}
			}

			return noteGuideName;
		}

		/// <summary>
		/// 備考ガイドマスタリスト取得処理
		/// </summary>
		/// <param name="guideDivCode">ユーザーガイド区分</param>
		/// <param name="retList">戻り値リスト</param>
		/// <returns>STATUS [0:取得 0以外:取得失敗]</returns>
		public int GetDivCodeNoteGuideBodyList(int guideDivCode, out ArrayList retList)
		{
			NoteGuidBd noteGuidBd = new NoteGuidBd();

			ArrayList noteGuidBdList = null;
			retList = new ArrayList();

			// 備考ガイド区分指定備考ガイド（ボディ）情報検索処理（論理削除除く）
			NoteGuidAcs noteGuidAcs = new NoteGuidAcs();		// 備考ガイドマスタアクセスクラス
			int status = noteGuidAcs.SearchDivCodeBody(out noteGuidBdList, this._enterpriseCode, guideDivCode);

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				foreach (NoteGuidBd ngb in noteGuidBdList)
				{
					ComboEditorItemCustomer comboEditorItem = new ComboEditorItemCustomer(ngb.NoteGuideCode, ngb.NoteGuideName);
					retList.Add(comboEditorItem);
				}
			}

			if (retList.Count > 0)
			{
				return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			else
			{
				return -1;
			}
		}

		/// <summary>
		/// 住所ガイド表示処理(SFTKD00426U.DLL)
		/// </summary>
		/// <param name="agResult">住所情報戻り値クラス</param>
		/// <returns>STATUS [0:選択 0以外:未選択]</returns>
		public int ShowAddressGuide(out AddressGuideResult agResult)
		{
			return ShowAddressGuide(0, 0, 0, out agResult);
		}

		/// <summary>
		/// 住所ガイド表示処理(SFTKD00426U.DLL)
		/// </summary>
		/// <param name="addressCode1">住所コード１</param>
		/// <param name="addressCode2">住所コード２</param>
		/// <param name="addressCode3">住所コード３</param>
		/// <param name="agResult">住所情報戻り値クラス</param>
		/// <returns>STATUS [0:選択 0以外:未選択]</returns>
		public int ShowAddressGuide(int addressCode1, int addressCode2, int addressCode3, out AddressGuideResult agResult)
		{
			System.Windows.Forms.DialogResult result = this._addressGuide.ShowAddressGuide(addressCode1, addressCode2, addressCode3, out agResult);

			if ((result == DialogResult.OK) || (result == DialogResult.Yes))
			{
				return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			else
			{
				return -1;
			}
		}

		/// <summary>
		/// 住所検索処理(住所コードより)(SFTKD00426U.DLL)
		/// </summary>
		/// <param name="addressCode1">住所コード１</param>
		/// <param name="addressCode2">住所コード２</param>
		/// <param name="addressCode3">住所コード３</param>
		/// <param name="agResult">住所情報戻り値クラス</param>
		/// <returns>STATUS [0:取得完了 0以外:取得失敗]</returns>
		public int GetAddressFromAddressCode(int addressCode1,int addressCode2,int addressCode3, out AddressGuideResult agResult)
		{
			agResult = new AddressGuideResult();

			System.Windows.Forms.DialogResult result = this._addressGuide.SearchAddressFromAddressCode(addressCode1, addressCode2, addressCode3,ref agResult);

			if ((result == DialogResult.OK) || (result == DialogResult.Yes))
			{
				if (agResult.AddressName != "")
				{
					return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
				}
				else
				{
					return -1;
				}
			}
			else
			{
				return -1;
			}
		}

		/// <summary>
		/// 住所検索処理(郵便番号より)(SFTKD00426U.DLL)
		/// </summary>
		/// <param name="strPostNo">郵便番号</param>
		/// <param name="agResult">住所情報戻り値クラス</param>
		/// <returns>STATUS [0:取得完了 0以外:取得失敗]</returns>
		public int GetAddressFromPostNo(string strPostNo, out AddressGuideResult agResult)
		{
			System.Windows.Forms.DialogResult result = this._addressGuide.ShowPostNoSearchGuide(strPostNo, out agResult);

			if ((result == DialogResult.OK) || (result == DialogResult.Yes))
			{
				if (agResult.AddressName != "")
				{
					return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
				}
				else
				{
					return -1;
				}
			}
			else
			{
				return -1;
			}
		}

		/// <summary>
		/// 従業員ガイド表示処理(SFTOK09382A.DLL)
		/// </summary>
        /// <param name="employee">従業員クラス</param>
		/// <returns>STATUS [0:選択 0以外:未選択]</returns>
		public int ShowEmployeeGuide(out Employee employee)
		{
			int status = this._employeeAcs.ExecuteGuid(this._enterpriseCode, true, out employee);
			return status;
		}

		/// <summary>
		/// 従業員検索処理(SFTOK09382A.DLL)
		/// </summary>
		/// <param name="employeeCode">従業員コード</param>
		/// <param name="employee">従業員クラス</param>
		/// <returns>STATUS [0:取得完了 0以外:取得失敗]</returns>
		public int GetEmployeeFromEmployeeCode(string employeeCode, out Employee employee)
		{
			int status = this._employeeAcs.Read(out employee, this._enterpriseCode, employeeCode);
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 ADD
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/10 DEL
            //if ( employee.LogicalDeleteCode != 0 )
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/10 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/10 ADD
            if ( status == 0 && employee != null && employee.LogicalDeleteCode != 0 )
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/10 ADD
            {
                employee = null;
                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 ADD
			return status;
		}
        /// <summary>
        /// 売上金額端数処理ガイド表示
        /// </summary>
        /// <param name="salesProcMoney">売上金額端数処理クラス</param>
        /// <param name="fracProcMoneyDiv">売上金額端数処理区分(0:売上金額/1:消費税/2:売上単価)</param>
        /// <returns>STATUS [0:選択 0以外:未選択]</returns>
        public int ShowSalesProcMoneyGuide( out SalesProcMoney salesProcMoney, int fracProcMoneyDiv )
        {
            int status = this._salesProcMoneyAcs.ExecuteGuid( this._enterpriseCode, fracProcMoneyDiv, out salesProcMoney );
            return status;
        }
        /// <summary>
        /// 売上金額端数処理存在チェック
        /// </summary>
        /// <param name="fracProcMoneyDiv"></param>
        /// <param name="fractionProcCode"></param>
        /// <returns></returns>
        public bool ExistsSalesProcMoney( int fracProcMoneyDiv, int fractionProcCode )
        {
            if ( _salesProcMoneyCdList == null )
            {
                _salesProcMoneyCdList = new List<SalesProcMoneyKey>();

                ArrayList salesProcMoneyList;
                this._salesProcMoneyAcs.Search( out salesProcMoneyList, this._enterpriseCode );
                foreach ( object obj in salesProcMoneyList )
                {
                    if ( obj is SalesProcMoney )
                    {
                        SalesProcMoney salesProcMoney = (obj as SalesProcMoney);
                        _salesProcMoneyCdList.Add( new SalesProcMoneyKey( salesProcMoney.FracProcMoneyDiv, salesProcMoney.FractionProcCode ) );
                    }
                }
            }

            return _salesProcMoneyCdList.Contains( new SalesProcMoneyKey( fracProcMoneyDiv, fractionProcCode ) );
        }
        /// <summary>
        /// 拠点ガイド表示
        /// </summary>
        /// <param name="secInfoSet">拠点クラス</param>
        /// <returns>STATUS [0:選択 0以外:未選択]</returns>
        public int ShowSectionGuide( out SecInfoSet secInfoSet )
        {
            int status = this._secInfoSetAcs.ExecuteGuid( this._enterpriseCode, false, out secInfoSet );
            return status;
        }
        /// <summary>
        /// 拠点取得
        /// </summary>
        /// <param name="secInfoSet"></param>
        /// <param name="sectionCode"></param>
        /// <returns></returns>
        public int GetSectionFromSectionCode( out SecInfoSet secInfoSet, string sectionCode )
        {
            int status = this._secInfoSetAcs.Read( out secInfoSet, this._enterpriseCode, sectionCode );
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 ADD
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/31 DEL
            //if ( secInfoSet.LogicalDeleteCode != 0 )
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/31 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/31 ADD
            if ( status == 0 && secInfoSet != null && secInfoSet.LogicalDeleteCode != 0 )
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/31 ADD
            {
                secInfoSet = null;
                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 ADD
            return status;
        }
        /// <summary>
        /// 倉庫ガイド表示
        /// </summary>
        /// <param name="warehouse">(出力)倉庫</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns></returns>
        public int ShowWarehouseGuide( out Warehouse warehouse, string sectionCode )
        {
            int status = this._warehouseAcs.ExecuteGuid( out warehouse, this._enterpriseCode, sectionCode );
            return status;
        }
        /// <summary>
        /// 倉庫取得処理
        /// </summary>
        /// <param name="warehouse">(出力)倉庫</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="warehouseCode">倉庫コード</param>
        /// <returns></returns>
        public int GetWarehouseFromWarehouseCode( out Warehouse warehouse, string sectionCode, string warehouseCode)
        {
            int status = this._warehouseAcs.Read( out warehouse, this._enterpriseCode, sectionCode, warehouseCode );
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/08 ADD
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/31 DEL
            //if ( warehouse.LogicalDeleteCode != 0 )
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/31 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/31 ADD
            if ( status == 0 && warehouse != null && warehouse.LogicalDeleteCode != 0 )
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/31 ADD
            {
                warehouse = null;
                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/08 ADD
            return status;
        }
		/// <summary>
		/// 得意先検索処理（得意先コードより）
		/// </summary>
		/// <param name="customerCode">得意先コード</param>
		/// <param name="customerInfo">得意先情報クラス</param>
		/// <returns>STATUS [0:取得完了 0以外:取得失敗]</returns>
		public int GetCustomerInfoFromCustomerCode(int customerCode, out CustomerInfo customerInfo)
		{
			int status = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, this._enterpriseCode, customerCode, true, out customerInfo);
			return status;
		}
		/// <summary>
		/// 得意先検索処理（得意先コードより）
		/// </summary>
		/// <param name="logicalMode">論理削除区分</param>
		/// <param name="customerCode">得意先コード</param>
		/// <param name="customerInfo">得意先情報クラス</param>
		/// <returns>STATUS [0:取得完了 0以外:取得失敗]</returns>
		public int GetCustomerInfoFromCustomerCode(ConstantManagement.LogicalMode logicalMode, int customerCode, out CustomerInfo customerInfo)
		{
			int status = this._customerInfoAcs.ReadDBData(logicalMode, this._enterpriseCode, customerCode, true, out customerInfo);
			return status;
		}
		/// <summary>
		/// ユーザーガイドガイド表示処理(SFTKD00641U.DLL)
		/// </summary>
		/// <param name="userGuideDivCd">ユーザーガイド区分</param>
		/// <param name="userGdBd">ユーザーガイドボディクラス</param>
		/// <returns>STATUS [0:取得完了 0以外:取得失敗]</returns>
		public int ShowUserGuideGuide(int userGuideDivCd, out UserGdBd userGdBd)
		{
			userGdBd = new UserGdBd();

			System.Windows.Forms.DialogResult result = this._userGuideGuide.UserGuideGuideShow(userGuideDivCd, 0, this._enterpriseCode, ref userGdBd);

			if ((result == DialogResult.OK) || (result == DialogResult.Yes))
			{
				return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			else
			{
				return -1;
			}
		}
		/// <summary>
		/// 備考ガイドガイド表示処理(SFTOK09402A.DLL)
		/// </summary>
		/// <param name="noteGuideDivCode">備考ガイド区分</param>
		/// <param name="noteGuidBd">備考ガイドボディクラス</param>
		/// <returns>STATUS [0:取得完了 0以外:取得失敗]</returns>
		public int ShowNoteGuideGuide(int noteGuideDivCode, out NoteGuidBd noteGuidBd)
		{
			noteGuidBd = new NoteGuidBd();

			NoteGuidAcs noteGuidAcs = new NoteGuidAcs();

			int status =  noteGuidAcs.ExecuteGuide(out noteGuidBd, this._enterpriseCode, noteGuideDivCode);
			return status;
		}
		/// <summary>
		/// 顧客コード自動発番区分取得処理
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="sectionCode">拠点コード</param>
		/// <returns>顧客コード自動発番区分</returns>
		public int GetCustCdAutoNumbering(string enterpriseCode, string sectionCode)
		{
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //int status = this.ReadAllDefSet(enterpriseCode, sectionCode);

            //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //{
            //    return _allDefSetStc.CustCdAutoNumbering;
            //}
            //else
            //{
            //    return 0;
            //}
            return 0;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
		}

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/29 DEL
        ///// <summary>
        ///// 全体初期値設定マスタ取得処理
        ///// </summary>
        ///// <param name="enterpriseCode">企業コード</param>
        ///// <param name="sectionCode">拠点コード</param>
        ///// <returns>STATUS [0:成功 0以外:失敗]</returns>
        //private int ReadAllDefSet(string enterpriseCode, string sectionCode)
        //{
        //    if (_allDefSetStc == null)
        //    {
        //        _allDefSetStc = new AllDefSet();
        //    }
        //    else
        //    {
        //        if ((_allDefSetStc.SectionCode.Trim() != "") && (_allDefSetStc.SectionCode.Trim() == sectionCode.Trim()))
        //        {
        //            // すでに情報を取得してると判断する。
        //            return 0;
        //        }
        //    }

        //    AllDefSetAcs allDefSetAcs = new AllDefSetAcs();
        //    int status = allDefSetAcs.Read(out _allDefSetStc, enterpriseCode, sectionCode);

        //    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //    {
        //        _allDefSetStc = new AllDefSet();
        //    }

        //    return status;
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/29 DEL

        /// <summary>
        /// 全体設定取得処理
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="sectionCode"></param>
        /// <returns></returns>
        public AllDefSet GetAllDefSet( string enterpriseCode, string sectionCode )
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/29 ADD
            // Keyを調整
            sectionCode = sectionCode.TrimEnd();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/29 ADD

            if ( stc_allDefSetDic == null )
            {
                stc_allDefSetDic = new Dictionary<string, AllDefSet>();
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/29 ADD
                ArrayList retList;
                _allDefSetAcs.Search( out retList, enterpriseCode, AllDefSetAcs.SearchMode.Remote );
                if ( retList != null )
                {
                    foreach ( AllDefSet allDefSet in retList )
                    {
                        if ( allDefSet.LogicalDeleteCode != 0 ) continue;
                        stc_allDefSetDic.Add( allDefSet.SectionCode.TrimEnd(), allDefSet );
                    }
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/29 ADD
            }

            if (!stc_allDefSetDic.ContainsKey(sectionCode))
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/29 DEL
                //AllDefSet allDefSet;
                //int status = _allDefSetAcs.Read( out allDefSet, enterpriseCode, sectionCode, AllDefSetAcs.SearchMode.Remote );

                //if ( status == 0 )
                //{
                //}
                //else
                //{
                //    allDefSet = new AllDefSet();
                //}
                //stc_allDefSetDic.Add( sectionCode, allDefSet );
                //return allDefSet;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/29 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/29 ADD
                // 全社設定
                string ct_AllSection = "00";

                if ( !stc_allDefSetDic.ContainsKey( ct_AllSection ) )
                {
                    return new AllDefSet();
                }
                return stc_allDefSetDic[ct_AllSection];
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/29 ADD
            }
            return stc_allDefSetDic[sectionCode];
        }
        /// <summary>
        /// 全体設定の総額表示区分取得処理
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="sectionCode"></param>
        /// <returns></returns>
        public int GetTotalAmountDispWayCd( string enterpriseCode, string sectionCode )
        {
            AllDefSet allDefSet = GetAllDefSet( enterpriseCode, sectionCode );
            return allDefSet.TotalAmountDispWayCd;
        }

        /// <summary>
        /// 税率設定取得処理
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="taxRateCode"></param>
        /// <returns></returns>
        public TaxRateSet GetTaxRateSet( string enterpriseCode, int taxRateCode )
        {
            // --- CHG 2009/03/06 障害ID:12199対応------------------------------------------------------>>>>>
            //if ( stc_taxRateSet == null )
            //{
            //    TaxRateSet taxRateSet;
            //    int status = _taxRateSetAcs.Read( out taxRateSet, enterpriseCode, taxRateCode );
            //    if ( status == 0 )
            //    {
            //        stc_taxRateSet = taxRateSet;
            //    }
            //    else
            //    {
            //        stc_taxRateSet = new TaxRateSet();
            //    }
            //}

            TaxRateSet taxRateSet;
            int status = _taxRateSetAcs.Read(out taxRateSet, enterpriseCode, taxRateCode);
            if (status == 0)
            {
                stc_taxRateSet = taxRateSet;
            }
            else
            {
                stc_taxRateSet = new TaxRateSet();
            }
            // --- CHG 2009/03/06 障害ID:12199対応------------------------------------------------------<<<<<

            return stc_taxRateSet;
        }
        /// <summary>
        /// 税率設定の転嫁方式取得処理
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="taxRateCode"></param>
        /// <returns></returns>
        public int GetConsTaxLayMethod( string enterpriseCode, int taxRateCode )
        {
            TaxRateSet taxRateSet = GetTaxRateSet( enterpriseCode, taxRateCode );
            return taxRateSet.ConsTaxLayMethod;
        }
		# endregion
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/26 ADD
        /// <summary>
        /// 得意先マスタレコード→得意先検索レコードへの変換処理
        /// </summary>
        /// <param name="customerInfo"></param>
        /// <returns></returns>
        public static CustomerSearchRet CopyToCustomerSearchRetFromCustomerInfo( CustomerInfo customerInfo )
        {
            CustomerSearchRet searchRet = new CustomerSearchRet();

            searchRet.AcceptWholeSale = customerInfo.AcceptWholeSale;
            searchRet.Address1 = customerInfo.Address1;
            searchRet.Address3 = customerInfo.Address3;
            searchRet.Address4 = customerInfo.Address4;
            searchRet.CustomerCode = customerInfo.CustomerCode;
            searchRet.CustomerSubCode = customerInfo.CustomerSubCode;
            searchRet.EnterpriseCode = customerInfo.EnterpriseCode;
            searchRet.EnterpriseName = customerInfo.EnterpriseName;
            searchRet.HomeTelNo = customerInfo.HomeTelNo;
            searchRet.HonorificTitle = customerInfo.HonorificTitle;
            searchRet.Kana = customerInfo.Kana;
            searchRet.LogicalDeleteCode = customerInfo.LogicalDeleteCode;
            searchRet.MngSectionCode = customerInfo.MngSectionCode;
            searchRet.Name = customerInfo.Name;
            searchRet.Name2 = customerInfo.Name2;
            searchRet.OfficeTelNo = customerInfo.OfficeTelNo;
            searchRet.PortableTelNo = customerInfo.PortableTelNo;

            // 2009/12/02 Add >>>
            searchRet.HomeFaxNo = customerInfo.HomeFaxNo;
            searchRet.OfficeFaxNo = customerInfo.OfficeFaxNo;
            // 2009/12/02 Add <<<

            searchRet.PostNo = customerInfo.PostNo;
            searchRet.SearchTelNo = customerInfo.SearchTelNo;
            searchRet.Snm = customerInfo.CustomerSnm;
            searchRet.TotalDay = customerInfo.TotalDay;
            searchRet.UpdateDate = customerInfo.UpdateDateTime;

            return searchRet;
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/26 ADD
	}
}

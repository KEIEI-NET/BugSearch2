using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Data;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Xml.Serialization;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// 請求KINGETアクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note		: 得意先請求金額情報のアクセス制御を行います。</br>
	/// <br>Programmer	: 18023 樋口　政成</br>
	/// <br>Date		: 2005.07.21</br>
	/// <br>Update Note	: 2006.03.13 樋口　政成
	///						・例外通過プロパティを追加。</br>
	/// <br>Update Note	: 2006.09.06 樋口　政成
	///						・得意先分析コードによる抽出を追加。</br>
	/// <br></br>
	/// </remarks>
	public class KingetCustDmdPrcAcs
	{
		# region Constructor
		/// <summary>
		/// 請求KINGETアクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 請求KINGETアクセスクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 18023 樋口　政成</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		public KingetCustDmdPrcAcs()
		{
			// 2006.03.13 ADD START 樋口　政成
			this._throughException = false;
			// 2006.03.13 ADD END 樋口　政成

			try
			{
				// リモートオブジェクト取得
				this._iSeiKingetDB = (ISeiKingetDB)MediationSeiKingetDB.GetSeiKingetDB();
			}
			catch (Exception)
			{				
				//オフライン時はnullをセット
				this._iSeiKingetDB = null;
			}
		}
		# endregion

		#region Private Members
		/// <summary>リモートオブジェクト格納バッファ</summary>
		private ISeiKingetDB _iSeiKingetDB = null;
		// 2006.03.13 ADD START 樋口　政成
		/// <summary>例外通過</summary>
		/// <remarks>true:クラス内で例外を取得せず、そのまま通過します,false:クラス内で例外を取得します</remarks>
		private bool _throughException = false;
		// 2006.03.13 ADD END 樋口　政成
		#endregion
		
		#region Private Const
		private const string ALLSECCODE				= "000000";	// 全拠点コード
		private const int MAXCOUNT_CORPORATEDIVCODE	= 6;		// 個人・法人区分 最大件数
		#endregion
		
		#region Properties
		// 2006.03.13 ADD START 樋口　政成
		/// <summary>例外通過 プロパティ</summary>
		/// <value>true:クラス内で例外を取得せず、そのまま通過します,false:クラス内で例外を取得します</value>
		/// <remarks>
		/// <br>Note       : クラスが例外を取得するかしないかを設定します。</br>
		/// <br>Programmer : 18023 樋口　政成</br>
		/// <br>Date       : 2006.03.13</br>
		/// </remarks>
		public bool ThroughException
		{
			get{return this._throughException;}
			set{this._throughException = value;}
		}
		// 2006.03.13 ADD END 樋口　政成
		#endregion

		#region Public Members
		/// <summary>オンラインモードの列挙型です。</summary>
		public enum OnlineMode 
		{
			/// <summary>オフライン</summary>
			Offline,
			/// <summary>オンライン</summary>
			Online 
		}

		/// <summary>
		/// オンラインモード取得処理
		/// </summary>
		/// <returns>OnlineMode</returns>
		/// <remarks>
		/// <br>Note       : オンラインモードを取得します。</br>
		/// <br>Programmer : 18023 樋口　政成</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		public int GetOnlineMode()
		{
			if (this._iSeiKingetDB == null)
			{
				return (int)OnlineMode.Offline;
			}
			else
			{
				return (int)OnlineMode.Online;
			}
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// KINGET用得意先請求金額情報読み込み処理（日付指定）
		/// </summary>
		/// <param name="kingetCustDmdPrcWork">KINGET用得意先請求金額情報</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="addUpSecCode">計上拠点コード</param>
		/// <param name="customerCode">得意先コード</param>
		/// <param name="readDate">指定日付(YYYYMMDD)</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 指定された日付より計上日付を算出してKINGET用得意先請求金額情報を取得します。</br>
		/// <br>Programmer : 18023 樋口　政成</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		public int Read(out KingetCustDmdPrcWork kingetCustDmdPrcWork, string enterpriseCode,
			string addUpSecCode, int customerCode, int readDate)
		{
			return this.ReadDB(out kingetCustDmdPrcWork, enterpriseCode, addUpSecCode, customerCode, readDate);
		}
		
		/// <summary>
		/// KINGET用得意先請求金額情報検索処理（得意先元帳用）
		/// </summary>
		/// <param name="kingetCustDmdPrcList">KINGET用得意先請求金額情報リスト</param>
		/// <param name="dmdSalesWorkTable">請求売上情報テーブル(HashTable[計上日付]->ArrayList)</param>
		/// <param name="depsitMainWorkTable">入金情報テーブル(HashTable[計上日付]->ArrayList)</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="addUpSecCode">計上拠点コード(空白の場合は全社抽出)</param>
		/// <param name="customerCode">得意先コード</param>
		/// <param name="startAddUpYearMonth">計上年月（開始）(YYYYMM)</param>
		/// <param name="endAddUpYearMonth">計上年月（終了）(YYYYMM)</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : KINGET用得意先請求金額情報を読み込みます。</br>
		/// <br>Programmer : 18023 樋口　政成</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		public int Search(out ArrayList kingetCustDmdPrcList, out Hashtable dmdSalesWorkTable, out Hashtable depsitMainWorkTable,
			string enterpriseCode, string addUpSecCode, int customerCode, int startAddUpYearMonth, int endAddUpYearMonth)
		{
			SeiKingetParameter parameter = new SeiKingetParameter();
			parameter.EnterpriseCode		= enterpriseCode;
			parameter.IsSelectAllSection	= false;
			if (addUpSecCode == "")
			{
				parameter.IsSelectAllSection	= true;
			}
			else
			{
				parameter.AddUpSecCodeList.Add(addUpSecCode);
			}
			parameter.StartCustomerCode	= customerCode;
			parameter.EndCustomerCode		= customerCode;
			parameter.TotalDay				= 0;
			parameter.StartTotalDay		= 0;
			parameter.EndTotalDay			= 0;
			parameter.StartAddUpDate		= DateTime.MinValue;
			parameter.EndAddUpDate			= DateTime.MinValue;
			parameter.StartAddUpYearMonth	= startAddUpYearMonth;
			parameter.EndAddUpYearMonth	= endAddUpYearMonth;
			parameter.IsOutputZeroBlance	= true;
			parameter.IsOutputAllSecRec	= true;
			parameter.StartKana			= "";
			parameter.EndKana				= "";
			parameter.IsAllCorporateDivCode= true;
			parameter.IsJudgeBillOutputCode= false;
			parameter.EmployeeKind			= 0;
			parameter.StartEmployeeCode	= "";
			parameter.EndEmployeeCode		= "";
				
			return this.SearchDB(out kingetCustDmdPrcList, out dmdSalesWorkTable, out depsitMainWorkTable, parameter);
		}
		
		/// <summary>
		/// KINGET用得意先請求金額情報検索処理（元帳一括印刷用）
		/// </summary>
		/// <param name="kingetCustDmdPrcTable">KINGET用得意先請求金額情報テーブル(HashTable[得意先コード]->ArrayList)</param>
		/// <param name="dmdSalesWorkTable">請求売上情報テーブル(HashTable[請求先コード]->HashTable[計上日付]->ArrayList)</param>
		/// <param name="depsitMainWorkTable">入金情報テーブル(HashTable[得意先コード]->HashTable[計上日付]->ArrayList)</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="addUpSecCode">計上拠点コード(空白の場合は全社抽出)</param>
		/// <param name="startAddUpYearMonth">計上年月（開始）(YYYYMM)</param>
		/// <param name="endAddUpYearMonth">計上年月（終了）(YYYYMM)</param>
		/// <param name="startCustomerCode">得意先コード(開始)</param>
		/// <param name="endCustomerCode">得意先コード(終了)</param>
		/// <param name="startKana">得意先カナ(開始)</param>
		/// <param name="endKana">得意先カナ(終了)</param>
		/// <param name="corporateDivCodeList">個人・法人区分リスト</param>
		/// <param name="isOutputZeroBlance">残高０出力</param>
		/// <param name="isJudgeBillOutputCode">請求書出力区分判断(true:請求書出力区分を検索条件に入れる,false:請求書出力区分を検索条件に入れない)</param>
		/// <param name="employeeKind">従業員区分(0:得意先,1:集金)</param>
		/// <param name="startEmployeeCode">従業員コード(開始)</param>
		/// <param name="endEmployeeCode">従業員コード(終了)</param>
		/// <param name="startCustAnalysCodes">開始得意先分析コード配列(1～6)</param>
		/// <param name="endCustAnalysCodes">終了得意先分析コード配列(1～6)</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : KINGET用得意先請求金額情報を読み込みます。</br>
		/// <br>Programmer : 18023 樋口　政成</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		public int SearchMotoAll(out Hashtable kingetCustDmdPrcTable,out Hashtable dmdSalesWorkTable,out Hashtable depsitMainWorkTable,
			string enterpriseCode,string addUpSecCode,int startAddUpYearMonth,int endAddUpYearMonth,int startCustomerCode,int endCustomerCode,
			string startKana,string endKana,ArrayList corporateDivCodeList,bool isOutputZeroBlance,bool isJudgeBillOutputCode,int employeeKind,
			string startEmployeeCode, string endEmployeeCode, int[] startCustAnalysCodes, int[] endCustAnalysCodes)
		{
			SeiKingetParameter parameter = new SeiKingetParameter();
			parameter.EnterpriseCode		= enterpriseCode;
			parameter.IsSelectAllSection	= false;
			parameter.IsOutputAllSecRec	= false;
			if (addUpSecCode == "")
			{
				parameter.IsSelectAllSection	= true;
				parameter.IsOutputAllSecRec	= true;
			}
			else
			if (addUpSecCode == ALLSECCODE)
			{
				parameter.IsOutputAllSecRec	= true;
				parameter.AddUpSecCodeList.Add(addUpSecCode);
			}
			else
			{
				parameter.AddUpSecCodeList.Add(addUpSecCode);
			}
			parameter.StartCustomerCode	= startCustomerCode;
			parameter.EndCustomerCode		= endCustomerCode;
			parameter.TotalDay				= 0;
			parameter.StartTotalDay		= 0;
			parameter.EndTotalDay			= 0;
			parameter.StartAddUpDate		= DateTime.MinValue;
			parameter.EndAddUpDate			= DateTime.MinValue;
			parameter.StartAddUpYearMonth	= startAddUpYearMonth;
			parameter.EndAddUpYearMonth	= endAddUpYearMonth;
			parameter.IsOutputZeroBlance	= isOutputZeroBlance;
			parameter.StartKana			= startKana;
			parameter.EndKana				= endKana;
			parameter.IsAllCorporateDivCode= false;
			if (corporateDivCodeList != null)
			{
				// 全個人・法人区分
				if (corporateDivCodeList.Count == MAXCOUNT_CORPORATEDIVCODE)
				{
					parameter.IsAllCorporateDivCode = true;
					parameter.CorporateDivCodeList = (ArrayList)corporateDivCodeList.Clone();
				}
				else
				{
					parameter.CorporateDivCodeList = (ArrayList)corporateDivCodeList.Clone();
				}
			}
			parameter.IsJudgeBillOutputCode= isJudgeBillOutputCode;
			parameter.EmployeeKind			= employeeKind;
			parameter.StartEmployeeCode	= startEmployeeCode;
			parameter.EndEmployeeCode		= endEmployeeCode;

			// 2006.09.06 ADD START 樋口　政成
			// 抽出条件設定（得意先分析コード）
			SetParameterForCustAnalysCodes(parameter, startCustAnalysCodes, endCustAnalysCodes);
			// 2006.09.06 ADD END 樋口　政成

			return this.SearchMotoAllDB(out kingetCustDmdPrcTable, out dmdSalesWorkTable, out depsitMainWorkTable, parameter);
		}

		/// <summary>
		/// KINGET用得意先請求金額情報検索処理（請求一覧表・合計請求書用）
		/// </summary>
		/// <param name="kingetCustDmdPrcList">KINGET用得意先請求金額情報リスト</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="addUpSecCodeList">計上拠点コードリスト(nullまたはCount=0の場合は選択無し)</param>
		/// <param name="isSelectAllSection">全社選択(true:全社選択 false:各拠点選択)</param>
		/// <param name="isOutputAllSecRec">全拠点レコード出力(true:全拠点レコードを出力する。false:全拠点レコードを出力しない)</param>
		/// <param name="startTotalDay">締日(開始)(DD)</param>
		/// <param name="endTotalDay">締日(終了)(DD)</param>
		/// <param name="startAddUpDate">計上年月日(開始)(YYYYMMDD)</param>
		/// <param name="endAddUpDate">計上年月日(終了)(YYYYMMDD)</param>
		/// <param name="startCustomerCode">得意先コード(開始)</param>
		/// <param name="endCustomerCode">得意先コード(終了)</param>
		/// <param name="startKana">得意先カナ(開始)</param>
		/// <param name="endKana">得意先カナ(終了)</param>
		/// <param name="corporateDivCodeList">個人・法人区分リスト</param>
		/// <param name="isJudgeBillOutputCode">請求書出力区分判断(true:請求書出力区分を検索条件に入れる,false:請求書出力区分を検索条件に入れない)</param>
		/// <param name="employeeKind">従業員区分(0:得意先,1:集金)</param>
		/// <param name="startEmployeeCode">従業員コード(開始)</param>
		/// <param name="endEmployeeCode">従業員コード(終了)</param>
		/// <param name="startCustAnalysCodes">開始得意先分析コード配列(1～6)</param>
		/// <param name="endCustAnalysCodes">終了得意先分析コード配列(1～6)</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : KINGET用得意先請求金額情報を読み込みます。</br>
		/// <br>Programmer : 18023 樋口　政成</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		public int Search(out ArrayList kingetCustDmdPrcList,string enterpriseCode,ArrayList addUpSecCodeList,bool isSelectAllSection,
			bool isOutputAllSecRec,int startTotalDay,int endTotalDay,int startAddUpDate,int endAddUpDate,int startCustomerCode,int endCustomerCode,
			string startKana,string endKana,ArrayList corporateDivCodeList,bool isJudgeBillOutputCode,int employeeKind,
			string startEmployeeCode, string endEmployeeCode, int[] startCustAnalysCodes, int[] endCustAnalysCodes)
		{
			SeiKingetParameter parameter = new SeiKingetParameter();
			parameter.EnterpriseCode		= enterpriseCode;
			parameter.IsSelectAllSection	= isSelectAllSection;
			if ((addUpSecCodeList != null) && (addUpSecCodeList.Count > 0))
			{
				parameter.AddUpSecCodeList = (ArrayList)addUpSecCodeList.Clone();
			}
			parameter.StartCustomerCode	= startCustomerCode;
			parameter.EndCustomerCode		= endCustomerCode;
			parameter.TotalDay				= 0;
			parameter.StartTotalDay		= startTotalDay;
			parameter.EndTotalDay			= endTotalDay;
			parameter.StartAddUpDate		= TDateTime.LongDateToDateTime("YYYYMMDD", startAddUpDate);
			parameter.EndAddUpDate			= TDateTime.LongDateToDateTime("YYYYMMDD", endAddUpDate);
			parameter.StartAddUpYearMonth	= 0;
			parameter.EndAddUpYearMonth	= 0;
			parameter.IsOutputZeroBlance	= false;
			parameter.IsOutputAllSecRec	= isOutputAllSecRec;
			parameter.StartKana			= startKana;
			parameter.EndKana				= endKana;
			parameter.IsAllCorporateDivCode= false;
			if (corporateDivCodeList != null)
			{
				// 全個人・法人区分
				if (corporateDivCodeList.Count == MAXCOUNT_CORPORATEDIVCODE)
				{
					parameter.IsAllCorporateDivCode = true;
				}
				else
				{
					parameter.CorporateDivCodeList = (ArrayList)corporateDivCodeList.Clone();
				}
			}
			parameter.IsJudgeBillOutputCode= isJudgeBillOutputCode;
			parameter.EmployeeKind			= employeeKind;
			parameter.StartEmployeeCode	= startEmployeeCode;
			parameter.EndEmployeeCode		= endEmployeeCode;
				
			// 2006.09.06 ADD START 樋口　政成
			// 抽出条件設定（得意先分析コード）
			SetParameterForCustAnalysCodes(parameter, startCustAnalysCodes, endCustAnalysCodes);
			// 2006.09.06 ADD END 樋口　政成

			return this.SearchDB(out kingetCustDmdPrcList, parameter);
		}
		
		/// <summary>
		/// 明細情報検索処理（明細請求書用）
		/// </summary>
		/// <param name="dmdSalesWorkTable">請求売上情報テーブル(HashTable[請求先コード]->ArrayList)</param>
		/// <param name="depsitMainWorkTable">入金情報テーブル(HashTable[得意先コード]->ArrayList)</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="seiKingetDetailParameterList">明細検索パラメータリスト</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : KINGET用得意先請求金額情報を読み込みます。</br>
		/// <br>Programmer : 18023 樋口　政成</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		public int SearchDetails(out Hashtable dmdSalesWorkTable, out Hashtable depsitMainWorkTable, string enterpriseCode,
			ArrayList seiKingetDetailParameterList)
		{
			return this.SearchDetailDB(out dmdSalesWorkTable, out depsitMainWorkTable, enterpriseCode, seiKingetDetailParameterList);
		}
		#endregion

		# region Private Methods
		/// <summary>
		/// KINGET用得意先請求金額情報検索処理（日付指定）
		/// </summary>
		/// <param name="kingetCustDmdPrcWork">KINGET用得意先請求金額情報</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="addUpSecCode">計上拠点コード</param>
		/// <param name="customerCode">得意先コード</param>
		/// <param name="readDate">指定日付(YYYYMMDD)</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : KINGET用得意先請求金額情報を読み込みます。</br>
		/// <br>Programmer : 18023 樋口　政成</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		private int ReadDB(out KingetCustDmdPrcWork kingetCustDmdPrcWork, string enterpriseCode, string addUpSecCode, int customerCode, int readDate)
		{
			kingetCustDmdPrcWork = null;
			
			try
			{
				object objKingetCustDmdPrc = null;
				
				// 検索
				int status = this._iSeiKingetDB.Read(out objKingetCustDmdPrc, enterpriseCode, addUpSecCode, customerCode, readDate);
				if (status == 0)
				{
					if (objKingetCustDmdPrc != null)
					{
						kingetCustDmdPrcWork = (KingetCustDmdPrcWork)objKingetCustDmdPrc;
					}
				}
				
				return status;
			}
			catch (Exception e)
			{
				// 2006.03.13 ADD START 樋口　政成
				if (this._throughException)	throw(e);
				// 2006.03.13 ADD END 樋口　政成

				kingetCustDmdPrcWork = null;
				//オフライン時はnullをセット
				this._iSeiKingetDB = null;
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, "SFUKK01310A", e.Message, 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
				return -1;
			}
		}
		
		/// <summary>
		/// KINGET用得意先請求金額情報検索処理
		/// </summary>
		/// <param name="kingetCustDmdPrcList">KINGET用得意先請求金額情報リスト</param>
		/// <param name="parameter">KINSET用抽出条件クラス</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : KINGET用得意先請求金額情報を読み込みます。</br>
		/// <br>Programmer : 18023 樋口　政成</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		private int SearchDB(out ArrayList kingetCustDmdPrcList, SeiKingetParameter parameter)
		{
			kingetCustDmdPrcList = null;
			
			try
			{
				object objKingetCustDmdPrc = null;
				
				// 検索
				int status = this._iSeiKingetDB.Search(out objKingetCustDmdPrc, parameter);
				if (status == 0)
				{
					if (objKingetCustDmdPrc != null)
					{
						kingetCustDmdPrcList = objKingetCustDmdPrc as ArrayList;
					}
				}
				
				return status;
			}
			catch (Exception e)
			{
				kingetCustDmdPrcList = null;

				// 2006.03.13 ADD START 樋口　政成
				if (this._throughException)	throw(e);
				// 2006.03.13 ADD END 樋口　政成

				//オフライン時はnullをセット
				this._iSeiKingetDB = null;
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, "SFUKK01310A", e.Message, 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
				return -1;
			}
		}
		
		/// <summary>
		/// KINGET用得意先請求金額情報検索処理（得意先元帳用）
		/// </summary>
		/// <param name="kingetCustDmdPrcList">KINGET用得意先請求金額情報リスト</param>
		/// <param name="dmdSalesWorkTable">請求売上情報テーブル(HashTable[請求先コード]->ArrayList)</param>
		/// <param name="depsitMainWorkTable">入金情報テーブル(HashTable[得意先コード]->ArrayList)</param>
		/// <param name="parameter">KINSET用抽出条件クラス</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : KINGET用得意先請求金額情報を読み込みます。</br>
		/// <br>Programmer : 18023 樋口　政成</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		private int SearchDB(out ArrayList kingetCustDmdPrcList, out Hashtable dmdSalesWorkTable, out Hashtable depsitMainWorkTable, 
			SeiKingetParameter parameter)
		{
			kingetCustDmdPrcList = null;
			dmdSalesWorkTable = null;
			depsitMainWorkTable = null;

            // ↓ 20070518 18322 a
            kingetCustDmdPrcList = new ArrayList();
            dmdSalesWorkTable    = new Hashtable();
            depsitMainWorkTable  = new Hashtable();

            return 0;
            // ↑ 20070518 18322 a
			
            // ↓ 20070518 18322 d 使用していないので削除
            #region 入金入力では使用しないので削除
			//try
			//{
			//	object objKingetCustDmdPrc = null;
			//	object objDmdSalesWorkList = null;
			//	object objDepsitMainWorkList = null;
			//	
			//	// 検索
			//	int status = this._iSeiKingetDB.Search(out objKingetCustDmdPrc, out objDmdSalesWorkList, out objDepsitMainWorkList, parameter);
			//	if (status == 0)
			//	{
			//		if (objKingetCustDmdPrc != null)
			//		{
			//			kingetCustDmdPrcList = objKingetCustDmdPrc as ArrayList;
			//			
			//			ArrayList dmdSalesWorkList = null;
			//			ArrayList depsitMainWorkList = null;
			//			
			//			if (objDmdSalesWorkList != null)
			//			{
			//				dmdSalesWorkList = objDmdSalesWorkList as ArrayList;
			//			}
			//			
			//			if (objDepsitMainWorkList != null)
			//			{
			//				depsitMainWorkList = objDepsitMainWorkList as ArrayList;
			//			}
			//			
			//			dmdSalesWorkTable = new Hashtable();
			//			depsitMainWorkTable = new Hashtable();
			//			
			//			string sectionCode = "";
			//			int dmdSalesCounter = 0;
			//			int depsitMainCounter = 0;
			//			
			//			for (int ix = 0; ix < kingetCustDmdPrcList.Count; ix++)
			//			{
			//				KingetCustDmdPrcWork kingetCustDmdPrcWork = (KingetCustDmdPrcWork)kingetCustDmdPrcList[ix];
			//				
			//				if (ix == 0)
			//				{
			//					sectionCode = kingetCustDmdPrcWork.AddUpSecCode;
			//				}
			//				
			//				// 拠点が変われば処理を抜ける
			//				if (!sectionCode.Equals(kingetCustDmdPrcWork.AddUpSecCode))
			//				{
			//					break;
			//				}
			//										
			//				// 請求売上情報を、請求金額情報の計上日付をKEYとしたHashtableに変換
			//				if ((dmdSalesWorkList != null) && (dmdSalesWorkList.Count > 0) && (dmdSalesCounter < dmdSalesWorkList.Count))
			//				{
            //                    // ↓ 20070124 18322 c MA.NS用に変更
			//					//foreach (DmdSalesWork work in dmdSalesWorkList)
			//
            //                    foreach (SalesSlipWork work in dmdSalesWorkList)
            //                    // ↑ 20070124 18322 c
			//					{
			//						int workAddUpADate = TDateTime.DateTimeToLongDate("YYYYMMDD", work.AddUpADate);
			//						// 計上日付が締め日付範囲に入っている場合
			//						if ((workAddUpADate >= kingetCustDmdPrcWork.StartDateSpan) &&
			//							(workAddUpADate <= kingetCustDmdPrcWork.EndDateSpan))
			//						{
			//							int addUpDate = TDateTime.DateTimeToLongDate("YYYYMMDD", kingetCustDmdPrcWork.AddUpDate);
			//							// 計上日付
			//							if (!dmdSalesWorkTable.Contains(addUpDate))
			//							{
			//								dmdSalesWorkTable.Add(addUpDate, new ArrayList());
			//							}								
			//							ArrayList list = (ArrayList)dmdSalesWorkTable[addUpDate];
			//							list.Add(work.Clone());
			//							dmdSalesCounter++;
			//						}
			//					}
			//				}
			//				
			//				// 入金情報を、請求金額情報の計上日付をKEYとしたHashtableに変換
			//				if ((depsitMainWorkList != null) && (depsitMainWorkList.Count > 0) && (depsitMainCounter < depsitMainWorkList.Count))
			//				{
			//					foreach (DepsitMainWork work in depsitMainWorkList)
			//					{
			//						int workAddUpADate = TDateTime.DateTimeToLongDate("YYYYMMDD", work.AddUpADate);
			//						// 計上日付が締め日付範囲に入っている場合
			//						if ((workAddUpADate >= kingetCustDmdPrcWork.StartDateSpan) &&
			//							(workAddUpADate <= kingetCustDmdPrcWork.EndDateSpan))
			//						{
			//							int addUpDate = TDateTime.DateTimeToLongDate("YYYYMMDD", kingetCustDmdPrcWork.AddUpDate);
			//							// 計上日付
			//							if (!depsitMainWorkTable.Contains(addUpDate))
			//							{
			//								depsitMainWorkTable.Add(addUpDate, new ArrayList());
			//							}
			//							ArrayList list = (ArrayList)depsitMainWorkTable[addUpDate];
			//							list.Add(work.Clone());
			//							depsitMainCounter++;
			//						}
			//					}
			//				}
			//			}
			//		}
			//	}
			//	
			//	return status;
			//}
			//catch (Exception e)
			//{
			//	kingetCustDmdPrcList = null;
			//	dmdSalesWorkTable = null;
			//	depsitMainWorkTable = null;
            //
			//	// 2006.03.13 ADD START 樋口　政成
			//	if (this._throughException)	throw(e);
			//	// 2006.03.13 ADD END 樋口　政成
            //
			//	//オフライン時はnullをセット
			//	this._iSeiKingetDB = null;
			//	TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, "SFUKK01310A", e.Message, 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
			//	return -1;
			//}
			#endregion
			// ↑ 20070518 18322 d

		}
		
		/// <summary>
		/// KINGET用得意先請求金額情報検索処理（元帳一括印刷用）
		/// </summary>
		/// <param name="kingetCustDmdPrcTable">KINGET用得意先請求金額情報テーブル(HashTable[得意先コード]->ArrayList)</param>
		/// <param name="dmdSalesWorkTable">請求売上情報テーブル(HashTable[請求先コード]->HashTable[計上日付]->ArrayList)</param>
		/// <param name="depsitMainWorkTable">入金情報テーブル(HashTable[得意先コード]->HashTable[計上日付]->ArrayList)</param>
		/// <param name="parameter">KINSET用抽出条件クラス</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : KINGET用得意先請求金額情報を読み込みます。</br>
		/// <br>Programmer : 18023 樋口　政成</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		private int SearchMotoAllDB(out Hashtable kingetCustDmdPrcTable, out Hashtable dmdSalesWorkTable, out Hashtable depsitMainWorkTable,
			SeiKingetParameter parameter)
		{
			kingetCustDmdPrcTable	= null;
			dmdSalesWorkTable		= null;
			depsitMainWorkTable		= null;

            // ↓ 20070518 18322 a
            kingetCustDmdPrcTable = new Hashtable();
            dmdSalesWorkTable     = new Hashtable();
            depsitMainWorkTable   = new Hashtable();

            return 0;
			// ↑ 20070518 18322 a

            // ↓ 20070518 18322 d 入金入力では使用していないので削除
			#region 入金入力では使用しないので削除
			//try
			//{
			//	object objKingetCustDmdPrcList	= null;
			//	object objDmdSalesWorkList		= null;
			//	object objDepsitMainWorkList	= null;
			//	
			//	// 検索(元帳一括印刷用)
			//	int status = this._iSeiKingetDB.SearchMotoAll(out objKingetCustDmdPrcList, out objDmdSalesWorkList,
			//													out objDepsitMainWorkList, parameter);
			//	if (status == 0)
			//	{
			//		if (objKingetCustDmdPrcList != null)
			//		{
			//			ArrayList kingetCustDmdPrcList	= null;
			//			ArrayList dmdSalesWorkList		= null;
			//			ArrayList depsitMainWorkList	= null;
			//			
			//			if (objKingetCustDmdPrcList != null)
			//			{
			//				kingetCustDmdPrcList = objKingetCustDmdPrcList as ArrayList;
			//			}
			//			
			//			if (objDmdSalesWorkList != null)
			//			{
			//				dmdSalesWorkList = objDmdSalesWorkList as ArrayList;
			//			}
			//			
			//			if (objDepsitMainWorkList != null)
			//			{
			//				depsitMainWorkList = objDepsitMainWorkList as ArrayList;
			//			}
			//			
			//			kingetCustDmdPrcTable	= new Hashtable();
			//			dmdSalesWorkTable		= new Hashtable();
			//			depsitMainWorkTable		= new Hashtable();
			//			
			//			// KINGET用得意先請求金額情報
			//			foreach (KingetCustDmdPrcWork work in kingetCustDmdPrcList)
			//			{
			//				// 得意先コード
			//				if (!kingetCustDmdPrcTable.Contains(work.CustomerCode))
			//				{
			//					kingetCustDmdPrcTable.Add(work.CustomerCode, new ArrayList());
			//				}
			//				ArrayList list = (ArrayList)kingetCustDmdPrcTable[work.CustomerCode];
			//				list.Add(work.Clone());
			//			}
			//			
			//			int dmdSalesCounter = 0;
			//			int depsitMainCounter = 0;
			//			
			//			// 請求売上情報＆入金情報を、金額情報を元に集約
			//			for (int ix = 0; ix < kingetCustDmdPrcList.Count; ix++)
			//			{
			//				KingetCustDmdPrcWork kingetCustDmdPrcWork = (KingetCustDmdPrcWork)kingetCustDmdPrcList[ix];
			//				
			//				// 請求売上情報をHashtableに変換 (HashTable[請求先コード]->HashTable[計上日付]->ArrayList)
			//				if ((dmdSalesWorkList != null) && (dmdSalesWorkList.Count > 0) && (dmdSalesCounter < dmdSalesWorkList.Count))
			//				{
            //                    // ↓ 20070124 18322 c MA.NS用に変更
			//					//foreach (DmdSalesWork work in dmdSalesWorkList)
			//
            //                    foreach (SalesSlipWork work in dmdSalesWorkList)
            //                    // ↑ 20070124 18322 c
			//					{
			//						int workAddUpADate = TDateTime.DateTimeToLongDate("YYYYMMDD", work.AddUpADate);
			//						// 請求売上情報の請求先コード＝金額情報の得意先コード 且つ
			//						// 計上日付が締め日付範囲に入っている場合
			//						if ((work.ClaimCode == kingetCustDmdPrcWork.CustomerCode) &&
			//							(workAddUpADate >= kingetCustDmdPrcWork.StartDateSpan) &&
			//							(workAddUpADate <= kingetCustDmdPrcWork.EndDateSpan))
			//						{
			//							// 請求先コード
			//							if (!dmdSalesWorkTable.Contains(work.ClaimCode))
			//							{
			//								dmdSalesWorkTable.Add(work.ClaimCode, new Hashtable());
			//							}
			//							Hashtable table = (Hashtable)dmdSalesWorkTable[work.ClaimCode];
			//							
			//							// 計上日付
			//							int addUpDate = TDateTime.DateTimeToLongDate("YYYYMMDD", kingetCustDmdPrcWork.AddUpDate);
			//							if (!table.Contains(addUpDate))
			//							{
			//								table.Add(addUpDate, new ArrayList());
			//							}								
			//							ArrayList list = (ArrayList)table[addUpDate];
			//							list.Add(work.Clone());
			//							dmdSalesCounter++;
			//						}
			//					}
			//				}
			//				
			//				// 入金情報をHashtableに変換 (HashTable[得意先コード]->HashTable[計上日付]->ArrayList)
			//				if ((depsitMainWorkList != null) && (depsitMainWorkList.Count > 0) && (depsitMainCounter < depsitMainWorkList.Count))
			//				{
			//					foreach (DepsitMainWork work in depsitMainWorkList)
			//					{
			//						int workAddUpADate = TDateTime.DateTimeToLongDate("YYYYMMDD", work.AddUpADate);
			//						// 入金情報の得意先コード＝金額情報の得意先コード 且つ
			//						// 計上日付が締め日付範囲に入っている場合
			//						if ((work.CustomerCode == kingetCustDmdPrcWork.CustomerCode) &&
			//							(workAddUpADate >= kingetCustDmdPrcWork.StartDateSpan) &&
			//							(workAddUpADate <= kingetCustDmdPrcWork.EndDateSpan))
			//						{
			//							// 得意先コード
			//							if (!depsitMainWorkTable.Contains(work.CustomerCode))
			//							{
			//								depsitMainWorkTable.Add(work.CustomerCode, new Hashtable());
			//							}
			//							Hashtable table = (Hashtable)depsitMainWorkTable[work.CustomerCode];
			//							
			//							// 計上日付
			//							int addUpDate = TDateTime.DateTimeToLongDate("YYYYMMDD", kingetCustDmdPrcWork.AddUpDate);
			//							if (!table.Contains(addUpDate))
			//							{
			//								table.Add(addUpDate, new ArrayList());
			//							}
			//							ArrayList list = (ArrayList)table[addUpDate];
			//							list.Add(work.Clone());
			//							depsitMainCounter++;
			//						}
			//					}
			//				}
			//			}
			//		}
			//	}
			//	
			//	return status;
			//}
			//catch (Exception e)
			//{
			//	kingetCustDmdPrcTable = null;
			//	dmdSalesWorkTable = null;
			//	depsitMainWorkTable = null;
			//
			//	// 2006.03.13 ADD START 樋口　政成
			//	if (this._throughException)	throw(e);
			//	// 2006.03.13 ADD END 樋口　政成
			//
			//	//オフライン時はnullをセット
			//	this._iSeiKingetDB = null;
			//	TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, "SFUKK01310A", e.Message, 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
			//	return -1;
			//}
			#endregion
            // ↑ 20070518 18322 d
		}
		
		/// <summary>
		/// KINGET用得意先請求金額情報検索処理
		/// </summary>
		/// <param name="dmdSalesWorkTable">請求売上情報テーブル(HashTable[請求先コード]->ArrayList)</param>
		/// <param name="depsitMainWorkTable">入金情報テーブル(HashTable[得意先コード]->ArrayList)</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="seiKingetDetailParameterList">KINSET用抽出条件クラス</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : KINGET用得意先請求金額情報を読み込みます。</br>
		/// <br>Programmer : 18023 樋口　政成</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		private int SearchDetailDB(out Hashtable dmdSalesWorkTable, out Hashtable depsitMainWorkTable, string enterpriseCode,
			ArrayList seiKingetDetailParameterList)
		{
            // ↓ 20070518 18322 a
            dmdSalesWorkTable   = new Hashtable();
            depsitMainWorkTable = new Hashtable();

            return 0;
            // ↑ 20070518 18322 a

            // ↓ 20070518 18322 d 入金入力では使用しないので削除
			#region 入金入力では使用しないので削除
			//dmdSalesWorkTable = null;
			//depsitMainWorkTable = null;
            //
			//try
			//{
			//	object objDmdSalesWorkList = null;
			//	object objDepsitMainWorkList = null;
			//
			//	// 検索
			//	int status = this._iSeiKingetDB.SearchDetails(out objDmdSalesWorkList, out objDepsitMainWorkList, enterpriseCode, seiKingetDetailParameterList);
			//	if (status == 0)
			//	{
			//		// 請求売上情報を請求先コードをKEYとしたHashtableに変換
			//		dmdSalesWorkTable = new Hashtable();
			//		if (objDmdSalesWorkList != null)
			//		{
			//			ArrayList dmdSalesWorkList = objDmdSalesWorkList as ArrayList;
			//			// ArrayList→Hashtable
			//			if (dmdSalesWorkList.Count > 0)
			//			{
            //                // ↓ 20040124 18322 c MA.NS用に変更
			//				//foreach (DmdSalesWork work in dmdSalesWorkList)
			//
            //                foreach (SalesSlipWork work in dmdSalesWorkList)
            //                // ↑ 20040124 18322 c
			//				{
			//					// 請求先コード
			//					if (!dmdSalesWorkTable.Contains(work.ClaimCode))
			//					{
			//						dmdSalesWorkTable.Add(work.ClaimCode, new ArrayList());
			//					}
			//				
			//					ArrayList list = (ArrayList)dmdSalesWorkTable[work.ClaimCode];
			//					list.Add(work.Clone());
			//				}
			//			}						
			//		}
			//		
			//		// 入金情報を得意先コードをKEYとしたHashtableに変換
			//		depsitMainWorkTable = new Hashtable();
			//		if (objDepsitMainWorkList != null)
			//		{
			//			ArrayList depsitMainWorkList = objDepsitMainWorkList as ArrayList;
			//			// ArrayList→Hashtable
			//			if (depsitMainWorkList.Count > 0)
			//			{
			//				foreach (DepsitMainWork work in depsitMainWorkList)
			//				{
			//					// 得意先コード
			//					if (!depsitMainWorkTable.Contains(work.CustomerCode))
			//					{
			//						depsitMainWorkTable.Add(work.CustomerCode, new ArrayList());
			//					}
			//				
			//					ArrayList list = (ArrayList)depsitMainWorkTable[work.CustomerCode];
			//					list.Add(work.Clone());
			//				}
			//			}						
			//		}
			//	}
			//	
			//	return status;
			//}
			//catch (Exception e)
			//{
			//	dmdSalesWorkTable = null;
			//	depsitMainWorkTable = null;
			//
			//	// 2006.03.13 ADD START 樋口　政成
			//	if (this._throughException)	throw(e);
			//	// 2006.03.13 ADD END 樋口　政成
			//
			//	//オフライン時はnullをセット
			//	this._iSeiKingetDB = null;
			//	TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, "SFUKK01310A", e.Message, 0, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
			//	return -1;
			//}
			#endregion
            // ↑ 20070518 18322 d
		}		

		/// <summary>
		/// 抽出条件設定（得意先分析コード）
		/// </summary>
		/// <param name="parameter">抽出条件パラメータクラス</param>
		/// <param name="startCustAnalysCodes">開始得意先分析コード配列(1～6)</param>
		/// <param name="endCustAnalysCodes">終了得意先分析コード配列(1～6)</param>
		/// <remarks>
		/// <br>Note       : 検索パラメータに得意先分析コードの抽出条件を設定します。</br>
		/// <br>Programmer : 18023 樋口　政成</br>
		/// <br>Date       : 2006.09.06</br>
		/// </remarks>
		private void SetParameterForCustAnalysCodes(SeiKingetParameter parameter, int[] startCustAnalysCodes, int[] endCustAnalysCodes)
		{
			// 開始得意先分析コード
			if (startCustAnalysCodes != null)
			{
				if (startCustAnalysCodes.Length > 0) parameter.StartCustAnalysCode1	= startCustAnalysCodes[0];
				if (startCustAnalysCodes.Length > 1) parameter.StartCustAnalysCode2	= startCustAnalysCodes[1];
				if (startCustAnalysCodes.Length > 2) parameter.StartCustAnalysCode3	= startCustAnalysCodes[2];
				if (startCustAnalysCodes.Length > 3) parameter.StartCustAnalysCode4	= startCustAnalysCodes[3];
				if (startCustAnalysCodes.Length > 4) parameter.StartCustAnalysCode5	= startCustAnalysCodes[4];
				if (startCustAnalysCodes.Length > 5) parameter.StartCustAnalysCode6	= startCustAnalysCodes[5];
			}

			// 終了得意先分析コード
			if ((endCustAnalysCodes != null) && (endCustAnalysCodes.Length > 0))
			{
				if (endCustAnalysCodes.Length > 0) parameter.EndCustAnalysCode1	= endCustAnalysCodes[0];
				if (endCustAnalysCodes.Length > 1) parameter.EndCustAnalysCode2	= endCustAnalysCodes[1];
				if (endCustAnalysCodes.Length > 2) parameter.EndCustAnalysCode3	= endCustAnalysCodes[2];
				if (endCustAnalysCodes.Length > 3) parameter.EndCustAnalysCode4	= endCustAnalysCodes[3];
				if (endCustAnalysCodes.Length > 4) parameter.EndCustAnalysCode5	= endCustAnalysCodes[4];
				if (endCustAnalysCodes.Length > 5) parameter.EndCustAnalysCode6	= endCustAnalysCodes[5];
			}
		}
		# endregion
	}
}

using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Diagnostics;

using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using Broadleaf.Library;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Diagnostics;  //ADD 2008/07/10 M.Kubota

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// 請求KINGET抽出DBリモートオブジェクト
	/// </summary>
	/// <remarks>
	/// <br>Note       : 請求KINGET抽出の実データ操作を行うクラスです。</br>
	/// <br>Programmer : 18023 樋口　政成</br>
	/// <br>Date       : 2005.07.21</br>
	/// <br></br>
	/// <br>Update Note : 2006.04.21 樋口　政成</br>
	/// <br>			: データ取得項目に得意先マスタのFAX番号（自宅）、FAX番号（勤務先）、電話番号（その他）、</br>
	///	<br>			: 主連絡先区分を追加。</br>
	/// <br></br>
	/// <br>Update Note : 2006.05.31 樋口　政成</br>
	/// <br>			: 請求全体設定に前受金算定区分が追加されたことに伴う変更。KINSETのCalcModeプロパティへの設定追加</br>
	/// <br></br>
	/// <br>Update Note : 2006.08.21 樋口　政成</br>
	/// <br>				・従業員名称を従業員マスタより取得するように変更。</br>
	///	<br></br>
	/// <br>Update Note : 2006.08.22 樋口　政成</br>
	/// <br>				・テーブル暗号化対応。</br>
	///	<br></br>
	/// <br>Update Note : 2006.08.25 樋口　政成</br>
	/// <br>				・従業員コード範囲のクエリ文字列作成を修正。</br>
	///	<br></br>
	/// <br>Update Note : 2006.09.06 樋口　政成</br>
	/// <br>				・得意先分析コードによる抽出を追加。</br>
	///	<br></br>
	/// <br>Update Note : 2007.01.17 木村 武正</br>
	/// <br>				・MA.NS用に変更</br>
    ///	<br></br>
    /// <br>Update Note : 2007.03.27 木村 武正</br>
    /// <br>				・得意先請求(買掛)金額マスタの更新が準備処理で行う</br>
    /// <br>				  ようになり、金額マスタのレイアウトが変更されたため修正</br>
    ///	<br></br>
    /// <br>Update Note : 2007.12.21 山田 明友</br>
    /// <br>				・流通基幹対応</br>
    /// <br>				・使用されていないプライベートメソッドを全てコメントアウト</br>
    ///	<br></br>
    /// <br>Update Note : 2008.04.25 久保田 誠</br>
    /// <br>				・PM.NS対応</br>
    ///	<br></br>
    /// </remarks>
	[Serializable]
	//public class SeiKingetDB : RemoteDB, IRemoteDB, ISeiKingetDB           //DEL 2008/07/10 M.Kubota
    public class SeiKingetDB : RemoteWithAppLockDB, IRemoteDB, ISeiKingetDB  //ADD 2008/07/10 M.Kubota 
	{
		#region Constructor
		/// <summary>
		/// 請求KINGET抽出DBリモートオブジェクトクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : DBサーバーコネクション情報を取得します。</br>
		/// <br>Programmer : 18023 樋口　政成</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		public SeiKingetDB()
		{
		}
		#endregion

		#region Private Class
		/// <summary>
		/// 請求KINGETデータ格納クラス
		/// </summary>
		private class SeiKingetData
		{
			#region Constructor
			public SeiKingetData()
			{
			}
			#endregion

			#region Private Members
			/// <summary>請求売上情報取得フラグ</summary>
			private bool _getDmdSalesFlg = false;

			/// <summary>請求売上情報リスト</summary>
			private ArrayList _dmdSalesWorkList = null;

			/// <summary>入金情報リスト</summary>
			private ArrayList _depsitMainWorkList = null;

			/// <summary>諸費用残高調整区分コード</summary>
			private Int32 _minusVarCstBlAdjstCd = -1;

			/// <summary>諸費用残高調整フラグ</summary>
			private bool _adjustMinusVCst = false;
			
			// 2006.05.31 ADD START 樋口　政成
			/// <summary>前受金算定区分コード</summary>
			private Int32 _bfRmonCalcDivCd = 0;
			// 2006.05.31 ADD END 樋口　政成

            // ↓ 20070417 18322 d 締めスケジュール・請求売上・入金抽出は、MA.NSでは使用しないので削除
            //                    （代わりは請求準備処理のリモートが行う）
			///// <summary>締スケジュール抽出DBリモートオブジェクト</summary>
			//private CAddUpSMngGetInfDB _cAddUpSMngGetInfDB = null;		
            //
			///// <summary>請求売上抽出DBリモートオブジェクト</summary>
			//private KingetDmdSalesDB _dmdSalesDB = null;
            //
			///// <summary>入金抽出DBリモートオブジェクト</summary>
			//private KingetDepsitMainDB _depsitMainDB = null;
            // ↑ 20070417 18322 d
			#endregion

			#region Property
			/// <summary>請求売上情報リスト</summary>
			public ArrayList DmdSalesWorkList
			{
				get{return _dmdSalesWorkList;}
				set{_dmdSalesWorkList = value;}
			}

			/// <summary>入金情報リスト</summary>
			public ArrayList DepsitMainWorkList
			{
				get{return _depsitMainWorkList;}
				set{_depsitMainWorkList = value;}
			}

			/// <summary>請求売上情報取得フラグ</summary>
			public bool GetDmdSalesFlg
			{
				get{return _getDmdSalesFlg;}
				set{_getDmdSalesFlg = value;}
			}

			/// <summary>諸費用残高調整区分コード</summary>
			public Int32 MinusVarCstBlAdjstCd
			{
				get{return _minusVarCstBlAdjstCd;}
				set{_minusVarCstBlAdjstCd = value;}
			}

			/// <summary>諸費用残高調整フラグ</summary>
			public bool AdjustMinusVCst
			{
				get{return _adjustMinusVCst;}
				set{_adjustMinusVCst = value;}
			}

			// 2006.05.31 ADD START 樋口　政成
			/// <summary>前受金算定区分</summary>
			public Int32 BfRmonCalcDivCd
			{
				get{return _bfRmonCalcDivCd;}
				set{_bfRmonCalcDivCd = value;}
			}
			// 2006.05.31 ADD END 樋口　政成

            // ↓ 20070417 18322 d 締めスケジュール・請求売上・入金抽出は、MA.NSでは使用しないので削除
			///// <summary>締スケジュール抽出DBリモートオブジェクト</summary>
			//public CAddUpSMngGetInfDB CAddUpSMngGetInfDB
			//{
			//	get{return _cAddUpSMngGetInfDB;}
			//	set{_cAddUpSMngGetInfDB = value;}
			//}
            //
			///// <summary>請求売上抽出DBリモートオブジェクト</summary>
			//public KingetDmdSalesDB DmdSalesDB
			//{
			//	get{return _dmdSalesDB;}
			//	set{_dmdSalesDB = value;}
			//}
            //
			///// <summary>入金抽出DBリモートオブジェクト</summary>
			//public KingetDepsitMainDB DepsitMainDB
			//{
			//	get{return _depsitMainDB;}
			//	set{_depsitMainDB = value;}
			//}
            // ↑ 20070417 18322 d
			#endregion
		}
		#endregion
		
		#region Private Const
		/// <summary>全拠点コード</summary>
		private const string ALLSECCODE = "000000";

		/// <summary>従業員区分（集金担当）</summary>
		private const int EMPLOYEEKIND_BILLCOLLECTER = 1;

        # region --- 2008/04/25 M.Kubota ---
        # if false
        // ↓ 20070117 18322 c MA.NS用に変更
        #region SF得意先請求金額マスタSELECT文字列(コメントアウト)
        ///// <summary>得意先請求金額マスタSELECT文字列</summary>
        //private const string SELECT_CUSTDMDPRC = "SELECT"
		//	+" CUSTDMDPRCRF.FILEHEADERGUIDRF,CUSTDMDPRCRF.ENTERPRISECODERF,CUSTDMDPRCRF.ADDUPSECCODERF,CUSTDMDPRCRF.CUSTOMERCODERF"
		//	+",CUSTDMDPRCRF.ADDUPDATERF,CUSTDMDPRCRF.ADDUPYEARMONTHRF,CUSTDMDPRCRF.TLEDMDSLIPLGCTRF,CUSTDMDPRCRF.TLEDMDSLIPGECTRF"
		//	+",CUSTDMDPRCRF.TLEDMDDEBITNOTELGCTRF,CUSTDMDPRCRF.TLEDMDDEBITNOTEGECTRF,CUSTDMDPRCRF.TLEDMDSLIPLGCNTRF,CUSTDMDPRCRF.TLEDMDSLIPGECNTRF"
		//	+",CUSTDMDPRCRF.TLEDMDDEBITNOTELGCNTRF,CUSTDMDPRCRF.TLEDMDDEBITNOTEGECNTRF,CUSTDMDPRCRF.ACPODRTTLSALESDMDRF,CUSTDMDPRCRF.ACPODRDISCTTLDMDRF"
		//	+",CUSTDMDPRCRF.ACPODRTTLCONSTAXDMDRF,CUSTDMDPRCRF.DMDVARCSTRF,CUSTDMDPRCRF.TTLTAXTINDMDVARCSTRF,CUSTDMDPRCRF.TTLTAXFREEDMDVARCSTRF"
		//	+",CUSTDMDPRCRF.VARCST1TOTALDEMANDRF,CUSTDMDPRCRF.VARCST2TOTALDEMANDRF,CUSTDMDPRCRF.VARCST3TOTALDEMANDRF,CUSTDMDPRCRF.VARCST4TOTALDEMANDRF"
		//	+",CUSTDMDPRCRF.VARCST5TOTALDEMANDRF,CUSTDMDPRCRF.VARCST6TOTALDEMANDRF,CUSTDMDPRCRF.VARCST7TOTALDEMANDRF,CUSTDMDPRCRF.VARCST8TOTALDEMANDRF"
		//	+",CUSTDMDPRCRF.VARCST9TOTALDEMANDRF,CUSTDMDPRCRF.VARCST10TOTALDEMANDRF,CUSTDMDPRCRF.VARCST11TOTALDEMANDRF,CUSTDMDPRCRF.VARCST12TOTALDEMANDRF"
		//	+",CUSTDMDPRCRF.VARCST13TOTALDEMANDRF,CUSTDMDPRCRF.VARCST14TOTALDEMANDRF,CUSTDMDPRCRF.VARCST15TOTALDEMANDRF,CUSTDMDPRCRF.VARCST16TOTALDEMANDRF"
		//	+",CUSTDMDPRCRF.VARCST17TOTALDEMANDRF,CUSTDMDPRCRF.VARCST18TOTALDEMANDRF,CUSTDMDPRCRF.VARCST19TOTALDEMANDRF,CUSTDMDPRCRF.VARCST20TOTALDEMANDRF"
		//	+",CUSTDMDPRCRF.TTLDMDVARCSTCONSTAXRF,CUSTDMDPRCRF.ACPODRTTLLMBLDMDRF,CUSTDMDPRCRF.TTLLMVARCSTDMDBLNCERF,CUSTDMDPRCRF.BFCALTTLAODRDEPODMDRF"
		//	+",CUSTDMDPRCRF.BFCALTTLAODRDPDSDMDRF,CUSTDMDPRCRF.BFCALTTLAODRDPDMDRF,CUSTDMDPRCRF.BFCALTTLAODRDSDMDRF,CUSTDMDPRCRF.AFCALTTLAODRDEPODMDRF"
		//	+",CUSTDMDPRCRF.AFCALTTLVCSTDEPODMDRF,CUSTDMDPRCRF.AFCALTTLAODRDPDSDMDRF,CUSTDMDPRCRF.AFCALTTLVCSTDPDSDMDRF,CUSTDMDPRCRF.AFCALTTLAODRRMDMDRF"
		//	+",CUSTDMDPRCRF.AFCALTTLVCSTBFRMDMDRF,CUSTDMDPRCRF.AFCALTTLAODRRMDSDMDRF,CUSTDMDPRCRF.AFCALTTLVCSTRMDSDMDRF,CUSTDMDPRCRF.AFCALTTLAODRBLCFDMDRF"
		//	+",CUSTDMDPRCRF.AFCALTTLVCSTBLCFDMDRF,CUSTDMDPRCRF.AFCALTTLAODRBLDMDRF,CUSTDMDPRCRF.AFCALTTLVCSTBLDMDRF,CUSTDMDPRCRF.AFCALDEMANDPRICERF"
		//	+",CUSTDMDPRCRF.ACPODRTTL2TMBFBLDMDRF,CUSTDMDPRCRF.TTL2TMBFVARCSTDMDBLRF,CUSTDMDPRCRF.ACPODRTTL3TMBFBLDMDRF,CUSTDMDPRCRF.TTL3TMBFVARCSTDMDBLRF"
		//	+",CUSTDMDPRCRF.ADDUPDATELASTRECFLGRF"
		//	#region 2006.08.22 DEL 樋口　政成
		//	//+",CUSTOMERRF.NAMERF,CUSTOMERRF.NAME2RF,CUSTOMERRF.HONORIFICTITLERF,CUSTOMERRF.KANARF"
		//	//+",CUSTOMERRF.OUTPUTNAMECODERF,CUSTOMERRF.OUTPUTNAMERF,CUSTOMERRF.CORPORATEDIVCODERF,CUSTOMERRF.POSTNORF,CUSTOMERRF.ADDRESS1RF"
		//	//+",CUSTOMERRF.ADDRESS2RF,CUSTOMERRF.ADDRESS3RF,CUSTOMERRF.ADDRESS4RF,CUSTOMERRF.HOMETELNORF,CUSTOMERRF.OFFICETELNORF"
		//	//+",CUSTOMERRF.PORTABLETELNORF,CUSTOMERRF.TOTALDAYRF,CUSTOMERRF.COLLECTMONEYNAMERF,CUSTOMERRF.COLLECTMONEYDAYRF"
		//	//// 2006.04.21 ADD START 樋口　政成
		//	//+",CUSTOMERRF.HOMEFAXNORF,CUSTOMERRF.OFFICEFAXNORF,CUSTOMERRF.OTHERSTELNORF,CUSTOMERRF.MAINCONTACTCODERF"
		//	//// 2006.04.21 ADD END 樋口　政成
		//	#endregion
		//	// 2006.08.22 ADD START 樋口　政成
		//	+",CAST(DECRYPTBYKEY(CUSTOMERRF.NAMERF) AS NVARCHAR(30)) AS NAMERF,CAST(DECRYPTBYKEY(CUSTOMERRF.NAME2RF) AS NVARCHAR(30)) AS NAME2RF"
		//	+",CUSTOMERRF.HONORIFICTITLERF,CUSTOMERRF.KANARF,CUSTOMERRF.OUTPUTNAMECODERF,CUSTOMERRF.OUTPUTNAMERF,CUSTOMERRF.CORPORATEDIVCODERF"
		//	+",CAST(DECRYPTBYKEY(CUSTOMERRF.POSTNORF) AS NVARCHAR(10)) AS POSTNORF,CAST(DECRYPTBYKEY(CUSTOMERRF.ADDRESS1RF) AS NVARCHAR(30)) AS ADDRESS1RF,CUSTOMERRF.ADDRESS2RF"
		//	+",CAST(DECRYPTBYKEY(CUSTOMERRF.ADDRESS3RF) AS NVARCHAR(22)) AS ADDRESS3RF,CAST(DECRYPTBYKEY(CUSTOMERRF.ADDRESS4RF) AS NVARCHAR(30)) AS ADDRESS4RF"
		//	+",CAST(DECRYPTBYKEY(CUSTOMERRF.HOMETELNORF) AS NVARCHAR(16)) AS HOMETELNORF,CAST(DECRYPTBYKEY(CUSTOMERRF.OFFICETELNORF) AS NVARCHAR(16)) AS OFFICETELNORF"
		//	+",CAST(DECRYPTBYKEY(CUSTOMERRF.PORTABLETELNORF) AS NVARCHAR(16)) AS PORTABLETELNORF, CAST(DECRYPTBYKEY(CUSTOMERRF.HOMEFAXNORF) AS NVARCHAR(16)) AS HOMEFAXNORF"
		//	+",CAST(DECRYPTBYKEY(CUSTOMERRF.OFFICEFAXNORF) AS NVARCHAR(16)) AS OFFICEFAXNORF,CAST(DECRYPTBYKEY(CUSTOMERRF.OTHERSTELNORF) AS NVARCHAR(16)) AS OTHERSTELNORF"
		//	+",CUSTOMERRF.MAINCONTACTCODERF,CUSTOMERRF.TOTALDAYRF,CUSTOMERRF.COLLECTMONEYNAMERF,CUSTOMERRF.COLLECTMONEYDAYRF"
		//	// 2006.08.22 ADD END 樋口　政成
		//	#region 2006.08.21 DEL 樋口　政成
		//	//+",CUSTOMERRF.CUSTOMERAGENTCDRF,CUSTOMERRF.CUSTOMERAGENTNMRF,CUSTOMERRF.BILLCOLLECTERCDRF,CUSTOMERRF.BILLCOLLECTERNMRF"
		//	//+" FROM CUSTDMDPRCRF"
		//	//+" LEFT OUTER JOIN CUSTOMERRF ON CUSTOMERRF.ENTERPRISECODERF=CUSTDMDPRCRF.ENTERPRISECODERF AND CUSTOMERRF.CUSTOMERCODERF=CUSTDMDPRCRF.CUSTOMERCODERF";
		//	#endregion
		//	// 2006.08.21 ADD START 樋口　政成
		//	// 2006.09.06 ADD START 樋口　政成
		//	+",CUSTOMERRF.CUSTANALYSCODE1RF,CUSTOMERRF.CUSTANALYSCODE2RF,CUSTOMERRF.CUSTANALYSCODE3RF"
		//	+",CUSTOMERRF.CUSTANALYSCODE4RF,CUSTOMERRF.CUSTANALYSCODE5RF,CUSTOMERRF.CUSTANALYSCODE6RF"
		//	// 2006.09.06 ADD END 樋口　政成
		//	+",CUSTOMERRF.CUSTOMERAGENTCDRF,CUSTOMERRF.BILLCOLLECTERCDRF"
		//	+",EMP_CUSTOMERAGENT.NAMERF AS CUSTOMERAGENTNMRF,EMP_BILLCOLLECTER.NAMERF AS BILLCOLLECTERNMRF"
		//	+" FROM CUSTDMDPRCRF"
		//	+" LEFT OUTER JOIN CUSTOMERRF ON CUSTOMERRF.ENTERPRISECODERF=CUSTDMDPRCRF.ENTERPRISECODERF AND CUSTOMERRF.CUSTOMERCODERF=CUSTDMDPRCRF.CUSTOMERCODERF"
		//	+" LEFT OUTER JOIN EMPLOYEERF AS EMP_CUSTOMERAGENT ON EMP_CUSTOMERAGENT.ENTERPRISECODERF=CUSTOMERRF.ENTERPRISECODERF AND EMP_CUSTOMERAGENT.EMPLOYEECODERF=CUSTOMERRF.CUSTOMERAGENTCDRF"
		//	+" LEFT OUTER JOIN EMPLOYEERF AS EMP_BILLCOLLECTER ON EMP_BILLCOLLECTER.ENTERPRISECODERF=CUSTOMERRF.ENTERPRISECODERF AND EMP_BILLCOLLECTER.EMPLOYEECODERF=CUSTOMERRF.BILLCOLLECTERCDRF";
        //    // 2006.08.21 ADD END 樋口　政成
        #endregion

        // ↓ 2007.12.21 980081 d
        #region MA.NS 得意先請求金額マスタSELECT文字列 未使用のため削除
        ///// <summary>得意先請求金額マスタSELECT文字列</summary>
        //private const string SELECT_CUSTDMDPRC =
        //    "SELECT CUSTDMDPRCRF.FILEHEADERGUIDRF"          // 企業コード
        //        + ",CUSTDMDPRCRF.ENTERPRISECODERF"          // GUID
        //        + ",CUSTDMDPRCRF.ADDUPSECCODERF"            // 計上拠点コード
        //        + ",CUSTDMDPRCRF.CUSTOMERCODERF"            // 得意先コード
        //        + ",CUSTDMDPRCRF.CUSTOMERNAMERF"            // 得意先名称
        //        + ",CUSTDMDPRCRF.CUSTOMERNAME2RF"           // 得意先名称2
        //        + ",CUSTDMDPRCRF.ADDUPDATERF"               // 計上年月日
        //        + ",CUSTDMDPRCRF.ADDUPYEARMONTHRF"          // 計上年月
        //        + ",CUSTDMDPRCRF.LASTTIMEDEMANDRF"          // 前回請求金額
        //        + ",CUSTDMDPRCRF.THISTIMEDMDNRMLRF"         // 今回入金金額（通常入金）
        //        + ",CUSTDMDPRCRF.THISTIMEFEEDMDNRMLRF"      // 今回手数料額（通常入金）
        //        + ",CUSTDMDPRCRF.THISTIMEDISDMDNRMLRF"      // 今回値引額（通常入金）
        //        + ",CUSTDMDPRCRF.THISTIMERBTDMDNRMLRF"      // 今回リベート額（通常入金）
        //        + ",CUSTDMDPRCRF.THISTIMEDMDDEPORF"         // 今回入金金額（預り金）
        //        + ",CUSTDMDPRCRF.THISTIMEFEEDMDDEPORF"      // 今回手数料額（預り金）
        //        + ",CUSTDMDPRCRF.THISTIMEDISDMDDEPORF"      // 今回値引額（預り金）
        //        + ",CUSTDMDPRCRF.THISTIMERBTDMDDEPORF"      // 今回リベート額（預り金）
        //        + ",CUSTDMDPRCRF.THISTIMETTLBLCDMDRF"       // 今回繰越残高（請求計）
        //        + ",CUSTDMDPRCRF.THISTIMESALESRF"           // 今回売上金額
        //        + ",CUSTDMDPRCRF.THISSALESTAXRF"            // 今回売上消費税
        //        + ",CUSTDMDPRCRF.TTLINCDTBTTAXEXCRF"        // 支払インセンティブ額合計（税抜き）
        //        + ",CUSTDMDPRCRF.TTLINCDTBTTAXRF"           // 支払インセンティブ額合計（税）
        //        + ",CUSTDMDPRCRF.OFSTHISTIMESALESRF"        // 相殺後今回売上金額
        //        + ",CUSTDMDPRCRF.OFSTHISSALESTAXRF"         // 相殺後今回売上消費税
        //        + ",CUSTDMDPRCRF.ITDEDOFFSETOUTTAXRF"       // 相殺後外税対象額
        //        + ",CUSTDMDPRCRF.ITDEDOFFSETINTAXRF"        // 相殺後内税対象額
        //        + ",CUSTDMDPRCRF.ITDEDOFFSETTAXFREERF"      // 相殺後非課税対象額
        //        + ",CUSTDMDPRCRF.OFFSETOUTTAXRF"            // 相殺後外税消費税
        //        + ",CUSTDMDPRCRF.OFFSETINTAXRF"             // 相殺後内税消費税
        //        + ",CUSTDMDPRCRF.ITDEDSALESOUTTAXRF"        // 売上外税対象額
        //        + ",CUSTDMDPRCRF.ITDEDSALESINTAXRF"         // 売上内税対象額
        //        + ",CUSTDMDPRCRF.ITDEDSALESTAXFREERF"       // 売上非課税対象額
        //        + ",CUSTDMDPRCRF.SALESOUTTAXRF"             // 売上外税額
        //        + ",CUSTDMDPRCRF.SALESINTAXRF"              // 売上内税額
        //        + ",CUSTDMDPRCRF.ITDEDPAYMOUTTAXRF"         // 支払外税対象額
        //        + ",CUSTDMDPRCRF.ITDEDPAYMINTAXRF"          // 支払内税対象額
        //        + ",CUSTDMDPRCRF.ITDEDPAYMTAXFREERF"        // 支払非課税対象額
        //        + ",CUSTDMDPRCRF.PAYMENTOUTTAXRF"           // 支払外税消費税
        //        + ",CUSTDMDPRCRF.PAYMENTINTAXRF"            // 支払内税消費税
        //        + ",CUSTDMDPRCRF.CONSTAXLAYMETHODRF"        // 消費税転嫁方式
        //        + ",CUSTDMDPRCRF.CONSTAXRATERF"             // 消費税率
        //        + ",CUSTDMDPRCRF.FRACTIONPROCCDRF"          // 端数処理区分
        //        + ",CUSTDMDPRCRF.AFCALDEMANDPRICERF"        // 計算後請求金額
        //        + ",CUSTDMDPRCRF.ACPODRTTL2TMBFBLDMDRF"     // 受注2回前残高（請求計）
        //        + ",CUSTDMDPRCRF.ACPODRTTL3TMBFBLDMDRF"     // 受注3回前残高（請求計）
        //        + ",CUSTDMDPRCRF.CADDUPUPDEXECDATERF"       // 締次更新実行年月日
        //        + ",CUSTDMDPRCRF.DMDPROCNUMRF"              // 請求処理通版
        //        + ",CUSTDMDPRCRF.STARTCADDUPUPDDATERF"      // 締次更新開始年月日
        //        + ",CUSTDMDPRCRF.LASTCADDUPUPDDATERF"       // 前回締次更新年月日
        //        + ",CAST(DECRYPTBYKEY(CUSTOMERRF.NAMERF) AS NVARCHAR(30)) AS NAMERF"
        //        + ",CAST(DECRYPTBYKEY(CUSTOMERRF.NAME2RF) AS NVARCHAR(30)) AS NAME2RF"
        //        + ",CUSTOMERRF.HONORIFICTITLERF"
        //        + ",CUSTOMERRF.KANARF"
        //        + ",CUSTOMERRF.OUTPUTNAMECODERF"
        //        + ",CUSTOMERRF.OUTPUTNAMERF"
        //        + ",CUSTOMERRF.CORPORATEDIVCODERF"
        //        + ",CAST(DECRYPTBYKEY(CUSTOMERRF.POSTNORF) AS NVARCHAR(10)) AS POSTNORF"
        //        + ",CAST(DECRYPTBYKEY(CUSTOMERRF.ADDRESS1RF) AS NVARCHAR(30)) AS ADDRESS1RF"
        //        + ",CUSTOMERRF.ADDRESS2RF"
        //        + ",CAST(DECRYPTBYKEY(CUSTOMERRF.ADDRESS3RF) AS NVARCHAR(22)) AS ADDRESS3RF"
        //        + ",CAST(DECRYPTBYKEY(CUSTOMERRF.ADDRESS4RF) AS NVARCHAR(30)) AS ADDRESS4RF"
        //        + ",CAST(DECRYPTBYKEY(CUSTOMERRF.HOMETELNORF) AS NVARCHAR(16)) AS HOMETELNORF"
        //        + ",CAST(DECRYPTBYKEY(CUSTOMERRF.OFFICETELNORF) AS NVARCHAR(16)) AS OFFICETELNORF"
        //        + ",CAST(DECRYPTBYKEY(CUSTOMERRF.PORTABLETELNORF) AS NVARCHAR(16)) AS PORTABLETELNORF"
        //        + ",CAST(DECRYPTBYKEY(CUSTOMERRF.HOMEFAXNORF) AS NVARCHAR(16)) AS HOMEFAXNORF"
        //        + ",CAST(DECRYPTBYKEY(CUSTOMERRF.OFFICEFAXNORF) AS NVARCHAR(16)) AS OFFICEFAXNORF"
        //        + ",CAST(DECRYPTBYKEY(CUSTOMERRF.OTHERSTELNORF) AS NVARCHAR(16)) AS OTHERSTELNORF"
        //        + ",CUSTOMERRF.MAINCONTACTCODERF"
        //        + ",CUSTOMERRF.TOTALDAYRF"
        //        + ",CUSTOMERRF.COLLECTMONEYNAMERF"
        //        + ",CUSTOMERRF.COLLECTMONEYDAYRF"
        //        + ",CUSTOMERRF.CUSTANALYSCODE1RF"
        //        + ",CUSTOMERRF.CUSTANALYSCODE2RF"
        //        + ",CUSTOMERRF.CUSTANALYSCODE3RF"
        //        + ",CUSTOMERRF.CUSTANALYSCODE4RF"
        //        + ",CUSTOMERRF.CUSTANALYSCODE5RF"
        //        + ",CUSTOMERRF.CUSTANALYSCODE6RF"
        //        + ",CUSTOMERRF.CUSTOMERAGENTCDRF"
        //        + ",CUSTOMERRF.BILLCOLLECTERCDRF"
        //        + ",EMP_CUSTOMERAGENT.NAMERF AS CUSTOMERAGENTNMRF"
        //        + ",EMP_BILLCOLLECTER.NAMERF AS BILLCOLLECTERNMRF"
        //   + " FROM CUSTDMDPRCRF"
        //   + " LEFT OUTER JOIN CUSTOMERRF"
        //   + "              ON CUSTOMERRF.ENTERPRISECODERF=CUSTDMDPRCRF.ENTERPRISECODERF"
        //   + "             AND CUSTOMERRF.CUSTOMERCODERF=CUSTDMDPRCRF.CUSTOMERCODERF"
        //   + " LEFT OUTER JOIN EMPLOYEERF AS EMP_CUSTOMERAGENT"
        //   + "              ON EMP_CUSTOMERAGENT.ENTERPRISECODERF=CUSTOMERRF.ENTERPRISECODERF"
        //   + "             AND EMP_CUSTOMERAGENT.EMPLOYEECODERF=CUSTOMERRF.CUSTOMERAGENTCDRF"
        //   + " LEFT OUTER JOIN EMPLOYEERF AS EMP_BILLCOLLECTER"
        //   + "              ON EMP_BILLCOLLECTER.ENTERPRISECODERF=CUSTOMERRF.ENTERPRISECODERF"
        //   + "             AND EMP_BILLCOLLECTER.EMPLOYEECODERF=CUSTOMERRF.BILLCOLLECTERCDRF"
        //   ;
        // ↑ 2007.12.21 980081 d
        #endregion
        // ↑ 20070117 18322 c MA.NS用に変更

        // ↓ 2007.12.21 980081 c
        #region 旧レイアウト(コメントアウト)
        //// 2006.08.21 ADD START 樋口　政成
        ///// <summary>得意先マスタSELECT文字列</summary>
		//private const string SELECT_CUSTOMER = "SELECT"
		//	#region 2006.08.22 DEL 樋口　政成
		//	//+" CUSTOMERRF.CUSTOMERCODERF,CUSTOMERRF.NAMERF,CUSTOMERRF.NAME2RF,CUSTOMERRF.HONORIFICTITLERF,CUSTOMERRF.KANARF,CUSTOMERRF.OUTPUTNAMECODERF"
		//	//+",CUSTOMERRF.OUTPUTNAMERF,CUSTOMERRF.CORPORATEDIVCODERF,CUSTOMERRF.POSTNORF,CUSTOMERRF.ADDRESS1RF,CUSTOMERRF.ADDRESS2RF"
		//	//+",CUSTOMERRF.ADDRESS3RF,CUSTOMERRF.ADDRESS4RF,CUSTOMERRF.HOMETELNORF,CUSTOMERRF.OFFICETELNORF,CUSTOMERRF.PORTABLETELNORF"
		//	//+",CUSTOMERRF.HOMEFAXNORF,CUSTOMERRF.OFFICEFAXNORF,CUSTOMERRF.OTHERSTELNORF,CUSTOMERRF.MAINCONTACTCODERF"
		//	#endregion
		//	// 2006.08.22 ADD START 樋口　政成
		//	+" CUSTOMERRF.CUSTOMERCODERF"
		//	+",CAST(DECRYPTBYKEY(CUSTOMERRF.NAMERF) AS NVARCHAR(30)) AS NAMERF,CAST(DECRYPTBYKEY(CUSTOMERRF.NAME2RF) AS NVARCHAR(30)) AS NAME2RF"
		//	+",CUSTOMERRF.HONORIFICTITLERF,CUSTOMERRF.KANARF,CUSTOMERRF.OUTPUTNAMECODERF,CUSTOMERRF.OUTPUTNAMERF,CUSTOMERRF.CORPORATEDIVCODERF"
		//	+",CAST(DECRYPTBYKEY(CUSTOMERRF.POSTNORF) AS NVARCHAR(10)) AS POSTNORF,CAST(DECRYPTBYKEY(CUSTOMERRF.ADDRESS1RF) AS NVARCHAR(30)) AS ADDRESS1RF,CUSTOMERRF.ADDRESS2RF"
		//	+",CAST(DECRYPTBYKEY(CUSTOMERRF.ADDRESS3RF) AS NVARCHAR(22)) AS ADDRESS3RF,CAST(DECRYPTBYKEY(CUSTOMERRF.ADDRESS4RF) AS NVARCHAR(30)) AS ADDRESS4RF"
		//	+",CAST(DECRYPTBYKEY(CUSTOMERRF.HOMETELNORF) AS NVARCHAR(16)) AS HOMETELNORF,CAST(DECRYPTBYKEY(CUSTOMERRF.OFFICETELNORF) AS NVARCHAR(16)) AS OFFICETELNORF"
		//	+",CAST(DECRYPTBYKEY(CUSTOMERRF.PORTABLETELNORF) AS NVARCHAR(16)) AS PORTABLETELNORF, CAST(DECRYPTBYKEY(CUSTOMERRF.HOMEFAXNORF) AS NVARCHAR(16)) AS HOMEFAXNORF"
		//	+",CAST(DECRYPTBYKEY(CUSTOMERRF.OFFICEFAXNORF) AS NVARCHAR(16)) AS OFFICEFAXNORF,CAST(DECRYPTBYKEY(CUSTOMERRF.OTHERSTELNORF) AS NVARCHAR(16)) AS OTHERSTELNORF"
		//	+",CUSTOMERRF.MAINCONTACTCODERF,CUSTOMERRF.TOTALDAYRF,CUSTOMERRF.COLLECTMONEYNAMERF,CUSTOMERRF.COLLECTMONEYDAYRF"
		//	// 2006.08.22 ADD END 樋口　政成
		//	// 2006.09.06 ADD START 樋口　政成
		//	+",CUSTOMERRF.CUSTANALYSCODE1RF,CUSTOMERRF.CUSTANALYSCODE2RF,CUSTOMERRF.CUSTANALYSCODE3RF"
		//	+",CUSTOMERRF.CUSTANALYSCODE4RF,CUSTOMERRF.CUSTANALYSCODE5RF,CUSTOMERRF.CUSTANALYSCODE6RF"
		//	// 2006.09.06 ADD END 樋口　政成
		//	+",CUSTOMERRF.TOTALDAYRF,CUSTOMERRF.COLLECTMONEYNAMERF,CUSTOMERRF.COLLECTMONEYDAYRF"
		//	+",CUSTOMERRF.CUSTOMERAGENTCDRF,CUSTOMERRF.BILLCOLLECTERCDRF"
		//	+",EMP_CUSTOMERAGENT.NAMERF AS CUSTOMERAGENTNMRF,EMP_BILLCOLLECTER.NAMERF AS BILLCOLLECTERNMRF"
		//	+" FROM CUSTOMERRF"
		//	+" LEFT OUTER JOIN EMPLOYEERF AS EMP_CUSTOMERAGENT ON EMP_CUSTOMERAGENT.ENTERPRISECODERF=CUSTOMERRF.ENTERPRISECODERF AND EMP_CUSTOMERAGENT.EMPLOYEECODERF=CUSTOMERRF.CUSTOMERAGENTCDRF"
		//	+" LEFT OUTER JOIN EMPLOYEERF AS EMP_BILLCOLLECTER ON EMP_BILLCOLLECTER.ENTERPRISECODERF=CUSTOMERRF.ENTERPRISECODERF AND EMP_BILLCOLLECTER.EMPLOYEECODERF=CUSTOMERRF.BILLCOLLECTERCDRF";
		//// 2006.08.21 ADD END 樋口　政成
        #endregion
        /// <summary>得意先マスタSELECT文字列</summary>
        //private const string SELECT_CUSTOMER = "SELECT "
        //                                     + "CUSTOMERRF.CLAIMCODERF, "
        //                                     + "CAST(DECRYPTBYKEY(CUSTOMERRF.CLAIMNAMERF) AS NVARCHAR(30)) AS CLAIMNAMERF, "
        //                                     + "CAST(DECRYPTBYKEY(CUSTOMERRF.CLAIMNAME2RF) AS NVARCHAR(30)) AS CLAIMNAME2RF, "
        //                                     + "CAST(DECRYPTBYKEY(CUSTOMERRF.CLAIMSNMRF) AS NVARCHAR(20)) AS CLAIMSNMRF, "
        //                                     + "CUSTOMERRF.CUSTOMERCODERF, "
        //                                     + "CAST(DECRYPTBYKEY(CUSTOMERRF.NAMERF) AS NVARCHAR(30)) AS CUSTOMERNAMERF, "
        //                                     + "CAST(DECRYPTBYKEY(CUSTOMERRF.NAME2RF) AS NVARCHAR(30)) AS CUSTOMERNAME2RF, "
        //                                     + "CAST(DECRYPTBYKEY(CUSTOMERRF.CUSTOMERSNMRF) AS NVARCHAR(20)) AS CUSTOMERSNMRF, "
        //                                     + "CUSTOMERRF.HONORIFICTITLERF, "
        //                                     + "CUSTOMERRF.KANARF, "
        //                                     + "CUSTOMERRF.OUTPUTNAMECODERF, "
        //                                     + "CUSTOMERRF.OUTPUTNAMERF, "
        //                                     + "CUSTOMERRF.CORPORATEDIVCODERF, "
        //                                     + "CAST(DECRYPTBYKEY(CUSTOMERRF.POSTNORF) AS NVARCHAR(10)) AS POSTNORF, "
        //                                     + "CAST(DECRYPTBYKEY(CUSTOMERRF.ADDRESS1RF) AS NVARCHAR(30)) AS ADDRESS1RF, "
        //                                     + "CUSTOMERRF.ADDRESS2RF, "
        //                                     + "CAST(DECRYPTBYKEY(CUSTOMERRF.ADDRESS3RF) AS NVARCHAR(22)) AS ADDRESS3RF, "
        //                                     + "CAST(DECRYPTBYKEY(CUSTOMERRF.ADDRESS4RF) AS NVARCHAR(30)) AS ADDRESS4RF, "
        //                                     + "CAST(DECRYPTBYKEY(CUSTOMERRF.HOMETELNORF) AS NVARCHAR(16)) AS HOMETELNORF, "
        //                                     + "CAST(DECRYPTBYKEY(CUSTOMERRF.OFFICETELNORF) AS NVARCHAR(16)) AS OFFICETELNORF, "
        //                                     + "CAST(DECRYPTBYKEY(CUSTOMERRF.PORTABLETELNORF) AS NVARCHAR(16)) AS PORTABLETELNORF, "
        //                                     + "CAST(DECRYPTBYKEY(CUSTOMERRF.HOMEFAXNORF) AS NVARCHAR(16)) AS HOMEFAXNORF, "
        //                                     + "CAST(DECRYPTBYKEY(CUSTOMERRF.OFFICEFAXNORF) AS NVARCHAR(16)) AS OFFICEFAXNORF, "
        //                                     + "CAST(DECRYPTBYKEY(CUSTOMERRF.OTHERSTELNORF) AS NVARCHAR(16)) AS OTHERSTELNORF, "
        //                                     + "CUSTOMERRF.MAINCONTACTCODERF, "
        //                                     + "CUSTOMERRF.CUSTANALYSCODE1RF, "
        //                                     + "CUSTOMERRF.CUSTANALYSCODE2RF, "
        //                                     + "CUSTOMERRF.CUSTANALYSCODE3RF, "
        //                                     + "CUSTOMERRF.CUSTANALYSCODE4RF, "
        //                                     + "CUSTOMERRF.CUSTANALYSCODE5RF, "
        //                                     + "CUSTOMERRF.CUSTANALYSCODE6RF, "
        //                                     + "CUSTOMERRF.TOTALDAYRF, "
        //                                     + "CUSTOMERRF.COLLECTMONEYCODERF, "
        //                                     + "CUSTOMERRF.COLLECTMONEYNAMERF, "
        //                                     + "CUSTOMERRF.COLLECTMONEYDAYRF, "
        //                                     + "CUSTOMERRF.CUSTOMERAGENTCDRF, "
        //                                     + "CUSTOMERRF.CUSTOMERAGENTNMRF, "
        //                                     + "CUSTOMERRF.BILLCOLLECTERCDRF, "
        //                                     + "CUSTOMERRF.BILLCOLLECTERNMRF, "
        //                                     + "CUSTOMERRF.OLDCUSTOMERAGENTCDRF, "
        //                                     + "CUSTOMERRF.OLDCUSTOMERAGENTNMRF, "
        //                                     + "CUSTOMERRF.CUSTAGENTCHGDATERF "
        //                                     + "FROM CUSTOMERRF ";
        // ↑ 2007.12.21 980081 c
        # endif
        # endregion
        #endregion

        #region Public Methods

        #region 請求金額情報取得Read
        /// <summary>
		/// 請求金額情報取得処理(入金入力・得意先情報)
		/// </summary>
		/// <param name="objKingetCustDmdPrcWork">KINGET用得意先請求金額情報</param>
		/// <param name="enterpriceCode">企業コード</param>
		/// <param name="addUpSecCode">計上拠点コード</param>
		/// <param name="customerCode">得意先コード</param>
		/// <param name="readDate">取得日付</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 得意先請求金額マスタDBよりパラメータの条件でデータを取得し返します。</br>
		/// <br>Programmer : 18023 樋口　政成</br>
		/// <br>Date       : 2005.07.21</br>
		public int Read(out object objKingetCustDmdPrcWork, string enterpriceCode, string addUpSecCode,
			int customerCode, int readDate)
		{
			SeiKingetData kingetData = new SeiKingetData();
			
			return this.ReadProc(out objKingetCustDmdPrcWork, enterpriceCode, addUpSecCode, customerCode, readDate, ref kingetData);
		}
		#endregion
		
		#region 請求金額情報取得Search
		/// <summary>
		/// 請求金額情報取得処理[鑑のみ](請求一覧表・合計請求書)
		/// </summary>
		/// <param name="objKingetCustDmdPrcWorkList">KINGET用得意先請求金額情報リスト</param>
		/// <param name="objSeiKingetParameter">検索パラメータ</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 得意先請求金額マスタDBより検索パラメータの条件でデータを取得し返します。
		///					 また、対象範囲でデータが存在しない場合は仮想で作成した上で返します。</br>
		/// <br>Programmer : 18023 樋口　政成</br>
		/// <br>Date       : 2005.07.21</br>
		public int Search(out object objKingetCustDmdPrcWorkList, object objSeiKingetParameter)
		{
			SeiKingetData kingetData = new SeiKingetData();
			
			SeiKingetParameter parameter = (SeiKingetParameter)objSeiKingetParameter;
			
			return this.SearchProc(out objKingetCustDmdPrcWorkList, parameter, ref kingetData);
		}
		#endregion
		
		#region 請求金額情報取得（元帳）
		/// <summary>
		/// 請求金額情報取得処理[鑑＋明細](得意先元帳)
		/// </summary>
		/// <param name="objKingetCustDmdPrcWorkList">KINGET用得意先請求金額情報リスト</param>
		/// <param name="objDmdSalesWorkList">請求売上情報リスト</param>
		/// <param name="objDepsitMainWorkList">入金情報リスト</param>
		/// <param name="objSeiKingetParameter">検索パラメータ</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 得意先請求金額マスタDBより検索パラメータの条件でデータを取得し返します。
		///					 また、対象範囲でデータが存在しない場合は仮想で作成した上で返します。</br>
		/// <br>Programmer : 18023 樋口　政成</br>
		/// <br>Date       : 2005.07.21</br>
		public int Search(out object objKingetCustDmdPrcWorkList, out object objDmdSalesWorkList,
			out object objDepsitMainWorkList, object objSeiKingetParameter)
		{
			objKingetCustDmdPrcWorkList = null;
			objDmdSalesWorkList = null;
			objDepsitMainWorkList = null;
			
			SeiKingetData kingetData = new SeiKingetData();
			kingetData.GetDmdSalesFlg = true;			// 請求売上情報取得フラグ
			kingetData.DmdSalesWorkList = new ArrayList();
			kingetData.DepsitMainWorkList = new ArrayList();
			
			SeiKingetParameter parameter = (SeiKingetParameter)objSeiKingetParameter;
			
			int status =  this.SearchProc(out objKingetCustDmdPrcWorkList, parameter, ref kingetData);
			if (status != 0) return status;
			
			objDmdSalesWorkList = kingetData.DmdSalesWorkList;
			objDepsitMainWorkList = kingetData.DepsitMainWorkList;
			
			return status;
		}
		#endregion
		
		#region 請求金額情報取得（元帳一括）
		/// <summary>
		/// 請求金額情報取得処理(元帳一括印刷)
		/// </summary>
		/// <param name="objKingetCustDmdPrcWorkList">KINGET用得意先請求金額情報リスト</param>
		/// <param name="objDmdSalesWorkList">請求売上情報リスト</param>
		/// <param name="objDepsitMainWorkList">入金情報リスト</param>
		/// <param name="objSeiKingetParameter">検索パラメータ</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 得意先請求金額マスタDBより検索パラメータの条件でデータを取得し返します。
		///					 また、対象範囲でデータが存在しない場合は仮想で作成した上で返します。</br>
		/// <br>Programmer : 18023 樋口　政成</br>
		/// <br>Date       : 2005.07.21</br>
		public int SearchMotoAll(out object objKingetCustDmdPrcWorkList, out object objDmdSalesWorkList,
			out object objDepsitMainWorkList, object objSeiKingetParameter)
		{
			objKingetCustDmdPrcWorkList = null;
			objDmdSalesWorkList = null;
			objDepsitMainWorkList = null;
			
			SeiKingetData kingetData = new SeiKingetData();
			kingetData.GetDmdSalesFlg = true;			// 請求売上情報取得フラグ
			kingetData.DmdSalesWorkList = new ArrayList();
			kingetData.DepsitMainWorkList = new ArrayList();
			
			SeiKingetParameter parameter = (SeiKingetParameter)objSeiKingetParameter;
			
			int status =  this.SearchMotoAllProc(out objKingetCustDmdPrcWorkList, parameter, ref kingetData);
			if (status != 0) return status;
			
			objDmdSalesWorkList = kingetData.DmdSalesWorkList;
			objDepsitMainWorkList = kingetData.DepsitMainWorkList;
			
			return status;
		}
		#endregion
		
		#region 請求金額情報取得（明細）
		/// <summary>
		/// 請求金額明細情報取得処理(明細請求書)
		/// </summary>
		/// <param name="objDmdSalesWorkList">請求売上情報リスト</param>
		/// <param name="objDepsitMainWorkList">入金情報リスト</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="objSeiKingetDetailParameterList">明細検索パラメータリスト</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 明細検索パラメータリストの条件で請求売上データと入金データを取得し返します。</br>
		/// <br>Programmer : 18023 樋口　政成</br>
		/// <br>Date       : 2005.07.21</br>
		public int SearchDetails(out object objDmdSalesWorkList, out object objDepsitMainWorkList,	string enterpriseCode,
			object objSeiKingetDetailParameterList)
		{
			SeiKingetData kingetData = new SeiKingetData();
			
			return this.SearchDetailsProc(out objDmdSalesWorkList, out objDepsitMainWorkList, enterpriseCode, objSeiKingetDetailParameterList, ref kingetData);
		}
		#endregion
		
		#region 得意先請求合計残高チェック
		/// <summary>
		/// 得意先請求合計残高チェック処理
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="customerCode">得意先コード</param>
		/// <returns>0:請求合計残高＝０円もしくは取引無し, 1:請求合計残高≠０円</returns>
		/// <br>Note       : 指定得意先コードの得意先請求金額マスタの最終レコードの請求合計残高をチェックします。</br>
		/// <br>Programmer : 18023 樋口　政成</br>
		/// <br>Date       : 2005.07.21</br>
		public int CheckDemandPrice(string enterpriseCode, int customerCode)
		{
			SeiKingetData kingetData = new SeiKingetData();
			
			return this.CheckDemandPriceProc(enterpriseCode, customerCode);
		}
		#endregion

		#endregion

		#region Private Methods

        // ↓ 20070417 18322 d MA.NS用に処理を見直すため削除
        #region 請求金額情報取得処理（１件取得）（作り直す為、コメントアウト）
		///// <summary>
		///// 請求金額情報取得処理（１件取得）
		///// </summary>
		///// <param name="objKingetCustDmdPrcWork">KINGET用得意先請求金額情報</param>
		///// <param name="enterpriceCode">企業コード</param>
		///// <param name="addUpSecCode">計上拠点コード</param>
		///// <param name="customerCode">得意先コード</param>
		///// <param name="readDate">取得対象日付</param>
        ///// <param name="kingetData">請求KINGETデータ格納クラス</param>
        ///// <returns>STATUS</returns>
		///// <br>Note       : 得意先請求金額マスタDBよりパラメータの条件でデータを取得し返します。</br>
		///// <br>Programmer : 18023 樋口　政成</br>
		///// <br>Date       : 2005.07.21</br>
		//private int ReadProc(out object objKingetCustDmdPrcWork, string enterpriceCode, string addUpSecCode, int customerCode, int readDate, ref SeiKingetData kingetData)
		//{
		//	int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
		//
		//	objKingetCustDmdPrcWork = null;
		//	
		//	SortedList totalDayScheduleSortedList	= null;	// 締日スケジュール格納用ソートリスト
		//	SortedList customerScheduleSortedList	= null;	// 得意先スケジュール格納用ソートリスト
		//	SortedList addSecCodeSortedList			= null;	// 請求金額情報格納用ソートリスト
		//
		//	try
		//	{
		//		// コネクション文字列取得
		//		string connectionText = this.GetConnectionText();
		//		if (connectionText == "") return status;
		//		
		//		// SQL接続
		//		SqlConnection sqlConnection = null;
		//		using (sqlConnection = new SqlConnection(connectionText))
		//		{
		//			SqlEncryptInfo sqlEncryptInfo = null;	// 2006.08.22 ADD 樋口　政成
		//
		//			try
		//			{
		//				sqlConnection.Open();
		//
		//				sqlEncryptInfo = this.OpenSqlEncryptInfo(ref sqlConnection);	// 2006.08.22 ADD 樋口　政成
		//
		//				KingetCustDmdPrcWork kingetCustDmdPrcWork = new KingetCustDmdPrcWork();
		//			
		//				// 得意先情報取得
		//				int st = this.ReadCustomer(ref kingetCustDmdPrcWork, sqlConnection, enterpriceCode, customerCode);
		//				if (st != (int)ConstantManagement.DB_Status.ctDB_NORMAL)return st;
		//			
		//				totalDayScheduleSortedList = new SortedList();	// 締日スケジュール格納用ソートリスト
		//				customerScheduleSortedList = new SortedList();	// 得意先スケジュール格納用ソートリスト
		//			
		//				DateTime startScheduleDate	= DateTime.Today.AddYears(-10);
		//				DateTime endScheduleDate	= DateTime.Today;
		//				if (readDate != 0)
		//				{
		//					// 日が0の場合
		//					if ((readDate % 100) == 0)
		//					{
		//						readDate += kingetCustDmdPrcWork.TotalDay;
		//					}
		//					endScheduleDate = TDateTime.LongDateToDateTime("YYYYMMDD", readDate);
		//					endScheduleDate = endScheduleDate.AddMonths(1);
		//				}
		//
        //                // 得意先スケジュール取得
		//				st = this.GetScheduleByCustomerCode(ref customerScheduleSortedList, enterpriceCode, kingetCustDmdPrcWork.CustomerCode, 0,
		//					startScheduleDate, endScheduleDate, ref kingetData);
		//				if (st != (int)ConstantManagement.DB_Status.ctDB_NORMAL)return st;
		//			    
		//				int addUpDate = 0;
		//			    
		//				RetAddUpDateItemTypeDInf retAddUpDateItemTypeDInf = new RetAddUpDateItemTypeDInf();;
		//			    
		//				// 計上日付取得
		//				foreach (DictionaryEntry schedule in (SortedList)customerScheduleSortedList[kingetCustDmdPrcWork.CustomerCode])
		//				{
		//					if (readDate <= (int)schedule.Key)
		//					{
		//						addUpDate = (int)schedule.Key;
		//						retAddUpDateItemTypeDInf = (RetAddUpDateItemTypeDInf)schedule.Value;
		//						break;
		//					}
        //                }
		//			
		//				SeiKingetParameter parameter = new SeiKingetParameter();
		//				parameter.EnterpriseCode = enterpriceCode;
		//				parameter.AddUpSecCodeList.Add(addUpSecCode);
		//				parameter.IsAllCorporateDivCode = true;
		//				parameter.StartCustomerCode	= customerCode;
		//				parameter.EndCustomerCode	= customerCode;
		//				parameter.StartAddUpDate	= TDateTime.LongDateToDateTime("YYYYMMDD", addUpDate);
		//				parameter.EndAddUpDate		= TDateTime.LongDateToDateTime("YYYYMMDD", addUpDate);
		//			
		//				// 請求金額情報格納用ソートリスト
		//				addSecCodeSortedList = new SortedList();
		//			
		//				// 得意先請求金額マスタ検索（１）
		//				st = this.SelectCustDmdPrc1(ref addSecCodeSortedList, sqlConnection, parameter);
		//				if (st == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
		//				{
		//				}
		//				else
		//					if (st == (int)ConstantManagement.DB_Status.ctDB_EOF)
		//				{
		//					// 得意先請求金額マスタ検索（２）
		//					st = this.SelectCustDmdPrc2(ref addSecCodeSortedList, sqlConnection, parameter);
		//					if (st == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
		//					{
		//						// 仮想請求鑑生成
		//						st = this.CreateVirtualCustDmdPrc(ref addSecCodeSortedList, sqlConnection, totalDayScheduleSortedList, customerScheduleSortedList, parameter, ref kingetData);
		//						if (st != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
		//						{
		//							return st;
		//						}
		//					}
		//					else
		//						if (st == (int)ConstantManagement.DB_Status.ctDB_EOF)
		//					{
		//						// 残高０レコードを設定
		//						addSecCodeSortedList.Add(addUpSecCode, new SortedList());
		//						SortedList customerCodeList = (SortedList)addSecCodeSortedList[addUpSecCode];
		//						customerCodeList.Add(customerCode, new SortedList());
		//						SortedList addUpDateList = (SortedList)customerCodeList[customerCode];
		//					
		//						kingetCustDmdPrcWork.AddUpSecCode	= addUpSecCode;
		//						kingetCustDmdPrcWork.CustomerCode	= customerCode;
		//						kingetCustDmdPrcWork.AddUpDate		= retAddUpDateItemTypeDInf.CAddUpUpdDate;
        //                        // ↓ 20070117 18322 c MA.NS用に変更
		//						//kingetCustDmdPrcWork.AddUpYearMonth	= TDateTime.DateTimeToLongDate("YYYYMM", retAddUpDateItemTypeDInf.CAddUpUpdYearMonth);
		//
        //                        kingetCustDmdPrcWork.AddUpYearMonth = retAddUpDateItemTypeDInf.CAddUpUpdYearMonth;
        //                        // ↑ 20070117 18322 c
		//						kingetCustDmdPrcWork.StartDateSpan	= TDateTime.DateTimeToLongDate("YYYYMMDD", retAddUpDateItemTypeDInf.StartAddUpDate);
		//						kingetCustDmdPrcWork.EndDateSpan	= TDateTime.DateTimeToLongDate("YYYYMMDD", retAddUpDateItemTypeDInf.EndAddUpDate);
		//					
		//						addUpDateList.Add(addUpDate, kingetCustDmdPrcWork);
		//					}
		//					else
		//					{
		//						return st;
		//					}
		//				
		//				}
		//				else
		//				{
		//					return st;
		//				}
		//			
		//				// 請求金額情報格納用ソートリスト→ArrayList＆売上入金明細取得
		//				ArrayList list;
		//				st = this.CopyToArrayListFromSortedList(out list, addSecCodeSortedList, totalDayScheduleSortedList, customerScheduleSortedList, parameter, sqlConnection, ref kingetData);
		//				if ((st != (int)ConstantManagement.DB_Status.ctDB_NORMAL) &&
		//					(st != (int)ConstantManagement.DB_Status.ctDB_EOF))
		//				{
		//					return st;
		//				}
		//			
		//				if (list.Count > 0)
		//				{
		//					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
		//				}
		//			
		//				objKingetCustDmdPrcWork = (KingetCustDmdPrcWork)list[0];
		//			}
		//			finally
		//			{
		//				if ((sqlEncryptInfo != null) && (sqlEncryptInfo.IsOpen)) sqlEncryptInfo.CloseSymKey(ref sqlConnection);	// 2006.08.22 ADD 樋口　政成
		//				if (sqlConnection != null) sqlConnection.Close();
		//			}
		//		}
		//	}
		//	catch (SqlException ex) 
		//	{
		//		//基底クラスに例外を渡して処理してもらう
		//		status = base.WriteSQLErrorLog(ex);
		//	}
		//	finally
		//	{
		//		if (totalDayScheduleSortedList != null)
		//		{
		//			totalDayScheduleSortedList.Clear();
		//			totalDayScheduleSortedList = null;
		//		}
		//
		//		if (customerScheduleSortedList != null)
		//		{
		//			customerScheduleSortedList.Clear();
		//			customerScheduleSortedList = null;
		//		}
		//
		//		if (addSecCodeSortedList != null)
		//		{
		//			addSecCodeSortedList.Clear();
		//			addSecCodeSortedList = null;
		//		}
		//	}
		//
		//	return status;
		//}
        #endregion
        // ↑ 20070417 18322 d

        // ↓ 20070417 18322 a MA.NS用に作成
        /// <summary>
		/// 請求金額情報取得処理（１件取得）
		/// </summary>
		/// <param name="objKingetCustDmdPrcWork">KINGET用得意先請求金額情報</param>
		/// <param name="enterpriceCode">企業コード</param>
		/// <param name="addUpSecCode">計上拠点コード</param>
		/// <param name="customerCode">得意先コード</param>
		/// <param name="readDate">取得対象日付</param>
        /// <param name="kingetData">請求KINGETデータ格納クラス</param>
        /// <returns>STATUS</returns>
		/// <br>Note       : 得意先請求金額マスタDBよりパラメータの条件でデータを取得し返します。</br>
		/// <br>Programmer : 18322 木村 武正</br>
		/// <br>Date       : 2007.04.17</br>
		private int ReadProc(out object        objKingetCustDmdPrcWork
                            ,    string        enterpriceCode
                            ,    string        addUpSecCode
                            ,    int           customerCode
                            ,    int           readDate
                            ,ref SeiKingetData kingetData)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

			objKingetCustDmdPrcWork = null;
            
			try
			{
				// コネクション文字列取得
				string connectionText = this.GetConnectionText();
				if (connectionText == "") return status;
				
				// SQL接続
				SqlConnection sqlConnection = null;
				using (sqlConnection = new SqlConnection(connectionText))
				{
					//SqlEncryptInfo sqlEncryptInfo = null;  //DEL 2008/07/10 M.Kubota

					try
					{
						sqlConnection.Open();

						//sqlEncryptInfo = this.OpenSqlEncryptInfo(ref sqlConnection);  //DEL 2008/07/10 M.Kubota

						KingetCustDmdPrcWork kingetCustDmdPrcWork = new KingetCustDmdPrcWork();
					
                        //========================
						// 得意先情報取得
                        //========================
						int st = this.ReadCustomer(ref kingetCustDmdPrcWork, sqlConnection, enterpriceCode, customerCode);
						if (st != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            return st;
                        }

                        //======================================================
                        // 請求締め情報取得
                        //======================================================
                        CustDmdPrcDB custDmdPrcDB = new CustDmdPrcDB();

                        //------------------------
                        // 請求締め日取得
                        //------------------------
                        //DmdCAddUpHisWork dmdCAddUpHisWork = new DmdCAddUpHisWork();
                        //dmdCAddUpHisWork.EnterpriseCode = enterpriceCode;
                        //dmdCAddUpHisWork.AddUpSecCode = addUpSecCode;
                        //dmdCAddUpHisWork.CustomerCode = customerCode;
                        //st = custDmdPrcDB.ReadHis(ref dmdCAddUpHisWork, ref sqlConnection);
                        //if (st != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        //{
                        //    // 請求締め日取得失敗
                        //    return st;
                        //}

                        //======================================================
                        // 請求データ取得(請求準備処理でデータを作成する)
                        //======================================================
                        CustDmdPrcWork custDmdPrcWork = new CustDmdPrcWork();
                        string retMsg = "";

                        custDmdPrcWork.EnterpriseCode = enterpriceCode;
                        custDmdPrcWork.AddUpSecCode = addUpSecCode;
                        custDmdPrcWork.CustomerCode = customerCode;
                        custDmdPrcWork.AddUpDate = TDateTime.LongDateToDateTime(readDate);
                        //try
                        //{
                        //    DateTime _readDate = TDateTime.LongDateToDateTime(readDate);
                        //    if (DateTime.DaysInMonth(_readDate.Year, _readDate.Month) > kingetCustDmdPrcWork.TotalDay)
                        //    {
                        //        // 顧客の締め日が月末以前の場合
                        //        custDmdPrcWork.AddUpDate = TDateTime.LongDateToDateTime(_readDate.Year  * 10000 +
                        //                                                                _readDate.Month * 100   +
                        //                                                                kingetCustDmdPrcWork.TotalDay);
                        //    }
                        //    else
                        //    {
                        //        // 顧客の締め日が月末以降の場合
                        //        custDmdPrcWork.AddUpDate = TDateTime.LongDateToDateTime(_readDate.Year  * 10000 +
                        //                                                                _readDate.Month * 100 +
                        //                                                                DateTime.DaysInMonth(_readDate.Year, _readDate.Month));
                        //    }

                        //    if (TDateTime.DateTimeToLongDate(custDmdPrcWork.AddUpDate) < readDate)
                        //    {
                        //        // 取得対象日付以前に締め予定日がある場合は翌月
                        //        _readDate = custDmdPrcWork.AddUpDate.AddMonths(1);
                        //        if (DateTime.DaysInMonth(_readDate.Year, _readDate.Month) > kingetCustDmdPrcWork.TotalDay)
                        //        {
                        //            // 顧客の締め日が月末以前の場合
                        //            custDmdPrcWork.AddUpDate = TDateTime.LongDateToDateTime(_readDate.Year  * 10000 +
                        //                                                                    _readDate.Month * 100   +
                        //                                                                    kingetCustDmdPrcWork.TotalDay);
                        //        }
                        //        else
                        //        {
                        //            // 顧客の締め日が月末以降の場合
                        //            custDmdPrcWork.AddUpDate = TDateTime.LongDateToDateTime(_readDate.Year  * 10000 +
                        //                                                                    _readDate.Month * 100 +
                        //                                                                    DateTime.DaysInMonth(_readDate.Year, _readDate.Month));
                        //        }
                        //    }
                        //}
                        //catch (Exception)
                        //{
                        //    custDmdPrcWork.AddUpDate = TDateTime.LongDateToDateTime(TDateTime.GetLastDate(readDate));
                        //}

                        object paraObj = custDmdPrcWork;
                        st = custDmdPrcDB.ReadCustDmdPrc(ref paraObj, out retMsg);
                        if (st != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // 取得失敗
                            return st;
                        }
                        custDmdPrcWork = paraObj as CustDmdPrcWork;

                        //==================================
                        // 締め情報・請求データ設定
                        //==================================
                        this.SetKingetDmdPrcInfo(ref kingetCustDmdPrcWork, ref custDmdPrcWork);

						objKingetCustDmdPrcWork = kingetCustDmdPrcWork;

                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
					}
					finally
					{
                        //--- DEL 2008/07/10 M.Kubota --->>>
                        //if ((sqlEncryptInfo != null) && (sqlEncryptInfo.IsOpen))
                        //{
                        //    sqlEncryptInfo.CloseSymKey(ref sqlConnection);
                        //}
                        //--- DEL 2008/07/10 M.Kubota ---<<<
						if (sqlConnection != null)
                        {
                            sqlConnection.Close();
                        }
					}
				}
			}
			catch (SqlException ex) 
			{
				//基底クラスに例外を渡して処理してもらう
				//status = base.WriteSQLErrorLog(ex);  //DEL 2008/07/10 M.Kubota
                //--- ADD 2008/07/10 M.Kubota --->>>
                string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
                //--- ADD 2008/07/10 M.Kubota ---<<<
			}
			finally
			{
			}

			return status;
		}
        // ↑ 20070417 18322 a

        // ↓ 20070417 18322 d 作り直しの為、削除
        #region 請求金額情報取得処理（得意先元帳・請求一覧表・合計請求書）（全てコメントアウト）
		///// <summary>
		///// 請求金額情報取得処理（得意先元帳・請求一覧表・合計請求書）
		///// </summary>
		///// <param name="objKingetCustDmdPrcWorkList">KINGET用得意先請求金額情報リスト</param>
		///// <param name="parameter">検索パラメータ</param>
        ///// <param name="kingetData">請求KINGETデータ格納クラス</param>
        ///// <returns>STATUS</returns>
		///// <br>Note       : 得意先請求金額マスタDBより検索パラメータの条件でデータを取得し返します。
		/////					 また、対象範囲でデータが存在しない場合は仮想で作成した上で返します。</br>
		///// <br>Programmer : 18023 樋口　政成</br>
		///// <br>Date       : 2005.07.21</br>
		//private int SearchProc(out object objKingetCustDmdPrcWorkList, SeiKingetParameter parameter, ref SeiKingetData kingetData)
		//{
		//	int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
		//
		//	objKingetCustDmdPrcWorkList = null;
		//	
		//	SortedList totalDayScheduleSortedList	= null;	// 締日スケジュール格納用ソートリスト
		//	SortedList customerScheduleSortedList	= null;	// 得意先スケジュール格納用ソートリスト
		//	SortedList addSecCodeSortedList			= null;	// 請求金額情報格納用ソートリスト
		//
		//	try
		//	{
		//		// コネクション文字列取得
		//		string connectionText = this.GetConnectionText();
		//		if (connectionText == "") return status;
		//		
		//		// SQL接続
		//		SqlConnection sqlConnection = null;
		//		using (sqlConnection = new SqlConnection(connectionText))
		//		{
		//			SqlEncryptInfo sqlEncryptInfo = null;	// 2006.08.22 ADD 樋口　政成
		//
		//			try
		//			{
		//				sqlConnection.Open();
		//
		//				sqlEncryptInfo = this.OpenSqlEncryptInfo(ref sqlConnection);	// 2006.08.22 ADD 樋口　政成
		//
		//				totalDayScheduleSortedList = new SortedList();	// 締日スケジュール格納用ソートリスト
		//				customerScheduleSortedList = new SortedList();	// 得意先スケジュール格納用ソートリスト
		//		
		//				// スケジュール取得用日付作成
		//				DateTime startScheduleDate;
		//				DateTime endScheduleDate;
		//				this.MakeGetScheduleDate(out startScheduleDate, out endScheduleDate, parameter);
		//		
		//				int st = 4;
		//		
		//				// 得意先１件指定の場合
		//				if ((parameter.StartCustomerCode != 0) && (parameter.StartCustomerCode == parameter.EndCustomerCode))
		//				{
		//					// 得意先スケジュールリスト取得
		//					this.GetScheduleByCustomerCode(ref customerScheduleSortedList, parameter.EnterpriseCode, parameter.StartCustomerCode,
		//						0, startScheduleDate, endScheduleDate, ref kingetData);
		//				}
		//				else
		//				{
		//					// 得意先スケジュールリスト取得
		//					this.GetScheduleByCustomerCodeRange(ref customerScheduleSortedList, parameter.EnterpriseCode, parameter.StartCustomerCode,
		//						parameter.EndCustomerCode, startScheduleDate, endScheduleDate, ref kingetData);
		//		
		//					// 締日範囲
		//					if ((parameter.StartTotalDay > 0) || (parameter.EndTotalDay > 0))
		//					{
		//						st = this.GetScheduleByTotalDay(ref totalDayScheduleSortedList, parameter.EnterpriseCode, 0, endScheduleDate, ref kingetData);
		//					}
		//					else
		//					{
		//						st = this.GetScheduleByTotalDay(ref totalDayScheduleSortedList, parameter.EnterpriseCode, parameter.TotalDay, endScheduleDate, ref kingetData);
		//					}
		//					if (st != 0)return st;
		//				}
		//		
		//				// 請求金額情報格納用ソートリスト
		//				addSecCodeSortedList = new SortedList();
		//		
		//				// 得意先請求金額マスタ検索（１）
		//				st = this.SelectCustDmdPrc1(ref addSecCodeSortedList, sqlConnection, parameter);
		//				if ((st != (int)ConstantManagement.DB_Status.ctDB_NORMAL) &&
		//					(st != (int)ConstantManagement.DB_Status.ctDB_EOF))
		//				{
		//					return st;
		//				}
		//		
		//				// 得意先請求金額マスタ検索（２）
		//				st = this.SelectCustDmdPrc2(ref addSecCodeSortedList, sqlConnection, parameter);
		//				if ((st != (int)ConstantManagement.DB_Status.ctDB_NORMAL) &&
		//					(st != (int)ConstantManagement.DB_Status.ctDB_EOF))
		//				{
		//					return st;
		//				}
		//		
		//				// 仮想請求鑑生成
		//				st = this.CreateVirtualCustDmdPrc(ref addSecCodeSortedList, sqlConnection, totalDayScheduleSortedList, customerScheduleSortedList, parameter, ref kingetData);
		//				if (st != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
		//				{
		//					return st;
		//				}
		//		
		//				// 残高０出力
		//				if (parameter.IsOutputZeroBlance)
		//				{
		//					this.MakeZeroCustomer(ref addSecCodeSortedList, sqlConnection, totalDayScheduleSortedList, customerScheduleSortedList, parameter);
		//				}
		//		
		//				// 請求金額情報格納用ソートリスト→ArrayList＆売上入金明細取得
		//				ArrayList list;
		//				st = this.CopyToArrayListFromSortedList(out list, addSecCodeSortedList, totalDayScheduleSortedList, customerScheduleSortedList, parameter, sqlConnection, ref kingetData);
		//				if ((st != (int)ConstantManagement.DB_Status.ctDB_NORMAL) &&
		//					(st != (int)ConstantManagement.DB_Status.ctDB_EOF))
		//				{
		//					return st;
		//				}
		//		
		//				if (list.Count > 0)
		//				{
		//					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
		//				}
		//		
		//				objKingetCustDmdPrcWorkList = list;
		//			}
		//			finally
		//			{
		//				if ((sqlEncryptInfo != null) && (sqlEncryptInfo.IsOpen)) sqlEncryptInfo.CloseSymKey(ref sqlConnection);	// 2006.08.22 ADD 樋口　政成
		//				if (sqlConnection != null) sqlConnection.Close();
		//			}
		//		}
		//	}
		//	catch (SqlException ex) 
		//	{
		//		//基底クラスに例外を渡して処理してもらう
		//		status = base.WriteSQLErrorLog(ex);
		//	}
		//	finally
		//	{
		//		if (totalDayScheduleSortedList != null)
		//		{
		//			totalDayScheduleSortedList.Clear();
		//			totalDayScheduleSortedList = null;
		//		}
		//
		//		if (customerScheduleSortedList != null)
		//		{
		//			customerScheduleSortedList.Clear();
		//			customerScheduleSortedList = null;
		//		}
		//
		//		if (addSecCodeSortedList != null)
		//		{
		//			addSecCodeSortedList.Clear();
		//			addSecCodeSortedList = null;
		//		}
		//	}
		//
		//	return status;
		//}
        #endregion
        // ↑ 20070417 18322 d

        // ↓ 20070417 18322 a 請求金額情報取得処理（得意先元帳・請求一覧表・合計請求書）
		/// <summary>
		/// 請求金額情報取得処理（得意先元帳・請求一覧表・合計請求書）
		/// </summary>
		/// <param name="objKingetCustDmdPrcWorkList">KINGET用得意先請求金額情報リスト</param>
		/// <param name="parameter">検索パラメータ</param>
        /// <param name="kingetData">請求KINGETデータ格納クラス</param>
        /// <returns>STATUS</returns>
		/// <br>Note       : 得意先請求金額マスタDBより検索パラメータの条件でデータを取得し返します。
		///					 また、対象範囲でデータが存在しない場合は仮想で作成した上で返します。</br>
		/// <br>Programmer : 18322 木村 武正</br>
		/// <br>Date       : 2007.04.17</br>
		private int SearchProc(out object objKingetCustDmdPrcWorkList
                              ,    SeiKingetParameter parameter
                              ,ref SeiKingetData kingetData)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

			objKingetCustDmdPrcWorkList = null;
			
			try
			{
				// コネクション文字列取得
				string connectionText = this.GetConnectionText();
				if (connectionText == "") return status;
				
				// SQL接続
				SqlConnection sqlConnection = null;
				using (sqlConnection = new SqlConnection(connectionText))
				{
					//SqlEncryptInfo sqlEncryptInfo = null;  //DEL 2008/07/10 M.Kubota

					try
					{
						sqlConnection.Open();
						//sqlEncryptInfo = this.OpenSqlEncryptInfo(ref sqlConnection);  //DEL 2008/07/10 M.Kubota

                        // 
                        objKingetCustDmdPrcWorkList = new ArrayList();
                        status = (int)ConstantManagement.DB_Status.ctDB_EOF;
					}
					finally
					{
                        //--- DEL 2008/07/10 M.Kubota --->>>
                        //if ((sqlEncryptInfo != null) && (sqlEncryptInfo.IsOpen))
                        //{
                        //    sqlEncryptInfo.CloseSymKey(ref sqlConnection);
                        //}
                        //--- DEL 2008/07/10 M.Kubota ---<<<
						if (sqlConnection != null)
                        {
                            sqlConnection.Close();
                        }
					}
				}
			}
			catch (SqlException ex) 
			{
				//基底クラスに例外を渡して処理してもらう
				//status = base.WriteSQLErrorLog(ex);  //DEL 2008/07/10 M.Kubota
                //--- ADD 2008/07/10 M.Kubota --->>>
                string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
                //--- ADD 2008/07/10 M.Kubota ---<<<
			}
			finally
			{
			}

			return status;
		}
        // ↑ 20070417 18322 a

		
        // ↓ 20070417 18322 d 作り直しの為、削除
        #region 請求金額情報取得処理（元帳一括印刷用）（全てコメントアウト）
		///// <summary>
		///// 請求金額情報取得処理（元帳一括印刷用）
		///// </summary>
		///// <param name="objKingetCustDmdPrcWorkList">KINGET用得意先請求金額情報リスト</param>
		///// <param name="parameter">検索パラメータ</param>
        ///// <param name="kingetData">請求KINGETデータ格納クラス</param>
        ///// <returns>STATUS</returns>
		///// <br>Note       : 得意先請求金額マスタDBより検索パラメータの条件でデータを取得し返します。
		/////					 また、対象範囲でデータが存在しない場合は仮想で作成した上で返します。</br>
		///// <br>Programmer : 18023 樋口　政成</br>
		///// <br>Date       : 2005.07.21</br>
		//private int SearchMotoAllProc(out object objKingetCustDmdPrcWorkList, SeiKingetParameter parameter, ref SeiKingetData kingetData)
		//{
		//	int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
		//
		//	objKingetCustDmdPrcWorkList = null;
		//	
		//	SortedList totalDayScheduleSortedList	= null;	// 締日スケジュール格納用ソートリスト
		//	SortedList customerScheduleSortedList	= null;	// 得意先スケジュール格納用ソートリスト
		//	SortedList addSecCodeSortedList			= null;	// 請求金額情報格納用ソートリスト
		//
		//	try
		//	{
		//		// コネクション文字列取得
		//		string connectionText = this.GetConnectionText();
		//		if (connectionText == "") return status;
		//		
		//		// SQL接続
		//		SqlConnection sqlConnection = null;
		//		using (sqlConnection = new SqlConnection(connectionText))
		//		{
		//			SqlEncryptInfo sqlEncryptInfo = null;	// 2006.08.22 ADD 樋口　政成
		//
		//			try
		//			{
		//				sqlConnection.Open();
		//
		//				sqlEncryptInfo = this.OpenSqlEncryptInfo(ref sqlConnection);	// 2006.08.22 ADD 樋口　政成
		//
		//				totalDayScheduleSortedList = new SortedList();	// 締日スケジュール格納用ソートリスト
		//				customerScheduleSortedList = new SortedList();	// 得意先スケジュール格納用ソートリスト
		//		
		//				// 得意先スケジュール取得
		//				DateTime startScheduleDate;
		//				DateTime endScheduleDate;
		//				this.MakeGetScheduleDate(out startScheduleDate, out endScheduleDate, parameter);
		//		
		//				int st;
		//		
		//				// 得意先が１件指定の場合
		//				if ((parameter.StartCustomerCode != 0) && (parameter.StartCustomerCode == parameter.EndCustomerCode))
		//				{
		//					this.GetScheduleByCustomerCode(ref customerScheduleSortedList, parameter.EnterpriseCode, parameter.StartCustomerCode, 1,
		//						startScheduleDate, endScheduleDate, ref kingetData);
		//				}
		//				else
		//				{
		//					this.GetScheduleByCustomerCodeRange(ref customerScheduleSortedList, parameter.EnterpriseCode, parameter.StartCustomerCode,
		//						parameter.EndCustomerCode, startScheduleDate, endScheduleDate, ref kingetData);
		//				}
		//
		//				bool oneCustomerSchedule = false;
		//		
		//				// 得意先が１件指定 且つ 得意先スケジュール取得済の場合
		//				if ((parameter.StartCustomerCode != 0) && (parameter.StartCustomerCode == parameter.EndCustomerCode))
		//				{
		//					if (customerScheduleSortedList.Count > 0)
		//					{
		//						oneCustomerSchedule = true;
		//					}
		//				}
		//		
		//				if (!oneCustomerSchedule)
		//				{
		//					st = 4;
		//			
		//					// 締日スケジュール取得
		//					if ((parameter.StartTotalDay > 0) || (parameter.EndTotalDay > 0))
		//					{
		//						st = this.GetScheduleByTotalDay(ref totalDayScheduleSortedList, parameter.EnterpriseCode, 0, endScheduleDate, ref kingetData);
		//					}
		//					else
		//					{
		//						st = this.GetScheduleByTotalDay(ref totalDayScheduleSortedList, parameter.EnterpriseCode, parameter.TotalDay, endScheduleDate, ref kingetData);
		//					}
		//					if (st != 0)return st;
		//				}
		//		
		//				// 請求金額情報格納用ソートリスト
		//				addSecCodeSortedList = new SortedList();
		//		
		//				// 得意先請求金額マスタ検索（１）
		//				st = this.SelectCustDmdPrc1(ref addSecCodeSortedList, sqlConnection, parameter);
		//				if ((st != (int)ConstantManagement.DB_Status.ctDB_NORMAL) &&
		//					(st != (int)ConstantManagement.DB_Status.ctDB_EOF))
		//				{
		//					return st;
		//				}
		//		
		//				// 得意先請求金額マスタ検索（２）
		//				st = this.SelectCustDmdPrc2(ref addSecCodeSortedList, sqlConnection, parameter);
		//				if ((st != (int)ConstantManagement.DB_Status.ctDB_NORMAL) &&
		//					(st != (int)ConstantManagement.DB_Status.ctDB_EOF))
		//				{
		//					return st;
		//				}
		//		
		//				// 仮想請求鑑生成
		//				st = this.CreateVirtualCustDmdPrc(ref addSecCodeSortedList, sqlConnection, totalDayScheduleSortedList, customerScheduleSortedList, parameter, ref kingetData);
		//				if (st != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
		//				{
		//					return st;
		//				}
		//		
		//				// 残高０出力
		//				if (parameter.IsOutputZeroBlance)
		//				{
		//					this.MakeZeroCustomer(ref addSecCodeSortedList, sqlConnection, totalDayScheduleSortedList, customerScheduleSortedList, parameter);
		//				}
		//		
		//				// 請求金額情報格納用ソートリスト→ArrayList＆売上入金明細取得
		//				ArrayList list;
		//				st = this.CopyToArrayListFromSortedList(out list, addSecCodeSortedList, totalDayScheduleSortedList, customerScheduleSortedList, parameter, sqlConnection, ref kingetData);
		//				if ((st != (int)ConstantManagement.DB_Status.ctDB_NORMAL) &&
		//					(st != (int)ConstantManagement.DB_Status.ctDB_EOF))
		//				{
		//					return st;
		//				}
		//		
		//				if (list.Count > 0)
		//				{
		//					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
		//				}
		//		
		//				objKingetCustDmdPrcWorkList = list;
		//			}
		//			finally
		//			{
		//				if ((sqlEncryptInfo != null) && (sqlEncryptInfo.IsOpen)) sqlEncryptInfo.CloseSymKey(ref sqlConnection);	// 2006.08.22 ADD 樋口　政成
		//				if (sqlConnection != null) sqlConnection.Close();
		//			}
		//		}
		//	}
		//	catch (SqlException ex) 
		//	{
		//		//基底クラスに例外を渡して処理してもらう
		//		status = base.WriteSQLErrorLog(ex);
		//	}
		//	finally
		//	{
		//		if (totalDayScheduleSortedList != null)
		//		{
		//			totalDayScheduleSortedList.Clear();
		//			totalDayScheduleSortedList = null;
		//		}
		//
		//		if (customerScheduleSortedList != null)
		//		{
		//			customerScheduleSortedList.Clear();
		//			customerScheduleSortedList = null;
		//		}
		//
		//		if (addSecCodeSortedList != null)
		//		{
		//			addSecCodeSortedList.Clear();
		//			addSecCodeSortedList = null;
		//		}
		//	}
		//
		//	return status;
		//}
        #endregion
        // ↑ 20070417 18322 d

        // ↓ 20070417 18322 a 請求金額情報取得処理（元帳一括印刷用）
		/// <summary>
		/// 請求金額情報取得処理（元帳一括印刷用）
		/// </summary>
		/// <param name="objKingetCustDmdPrcWorkList">KINGET用得意先請求金額情報リスト</param>
		/// <param name="parameter">検索パラメータ</param>
        /// <param name="kingetData">請求KINGETデータ格納クラス</param>
        /// <returns>STATUS</returns>
		/// <br>Note       : 得意先請求金額マスタDBより検索パラメータの条件でデータを取得し返します。
		///					 また、対象範囲でデータが存在しない場合は仮想で作成した上で返します。</br>
		/// <br>Programmer : 18322 木村 武正</br>
		/// <br>Date       : 2007.04.17</br>
		private int SearchMotoAllProc(out object              objKingetCustDmdPrcWorkList
                                     ,    SeiKingetParameter  parameter
                                     ,ref SeiKingetData       kingetData)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

			objKingetCustDmdPrcWorkList = null;
			
			try
			{
				// コネクション文字列取得
				string connectionText = this.GetConnectionText();
				if (connectionText == "") return status;
				
				// SQL接続
				SqlConnection sqlConnection = null;
				using (sqlConnection = new SqlConnection(connectionText))
				{
					//SqlEncryptInfo sqlEncryptInfo = null;  //DEL 2008/07/10 M.Kubota

					try
					{
						sqlConnection.Open();

						//sqlEncryptInfo = this.OpenSqlEncryptInfo(ref sqlConnection);  //DEL 2008/07/10 M.Kubota

        				status = (int)ConstantManagement.DB_Status.ctDB_EOF;
				
						objKingetCustDmdPrcWorkList = new ArrayList();
					}
					finally
					{
                        //--- DEL 2008/07/10 M.Kubota --->>>
                        //if ((sqlEncryptInfo != null) && (sqlEncryptInfo.IsOpen))
                        //{
                        //    sqlEncryptInfo.CloseSymKey(ref sqlConnection);
                        //}
                        //--- DEL 2008/07/10 M.Kubota ---<<<
						if (sqlConnection != null)
                        {
                            sqlConnection.Close();
                        }
					}
				}
			}
			catch (SqlException ex) 
			{
				//基底クラスに例外を渡して処理してもらう
				//status = base.WriteSQLErrorLog(ex);  //DEL 2008/07/10 M.Kubota
                //--- ADD 2008/07/10 M.Kubota --->>>
                string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
                //--- ADD 2008/07/10 M.Kubota ---<<<
			}
			finally
			{
			}

			return status;
		}
        // ↑ 20070417 18322 a
		
        // ↓ 20070417 18322 d 作り直しの為、削除
        #region 請求金額明細情報取得処理（全てコメントアウト）
        ///// <summary>
		///// 請求金額明細情報取得処理
		///// </summary>
		///// <param name="objDmdSalesWorkList">請求売上情報リスト</param>
		///// <param name="objDepsitMainWorkList">入金情報リスト</param>
		///// <param name="enterpriseCode">企業コード</param>
		///// <param name="objSeiKingetDetailParameterList">明細検索パラメータリスト</param>
        ///// <param name="kingetData">請求KINGETデータ格納クラス</param>
        ///// <returns>STATUS</returns>
		///// <br>Note       : 明細検索パラメータリストの条件で請求売上データと入金データを取得し返します。</br>
		///// <br>Programmer : 18023 樋口　政成</br>
		///// <br>Date       : 2005.07.21</br>
		//private int SearchDetailsProc(out object objDmdSalesWorkList, out object objDepsitMainWorkList,	string enterpriseCode,
		//	object objSeiKingetDetailParameterList, ref SeiKingetData kingetData)
		//{
		//	int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
		//	
		//	objDmdSalesWorkList = null;
		//	objDepsitMainWorkList = null;
		//	
		//	SortedList totalDayScheduleSortedList	= null;	// 締日スケジュール格納用ソートリスト
		//	SortedList customerScheduleSortedList	= null;	// 得意先スケジュール格納用ソートリスト
		//
		//	try
		//	{
		//		ArrayList parameterList = (ArrayList)objSeiKingetDetailParameterList;
		//
		//		ArrayList addUpSecCodeList = new ArrayList();
		//
		//		totalDayScheduleSortedList = new SortedList();	// 締日スケジュール格納用ソートリスト
		//		customerScheduleSortedList = new SortedList();	// 得意先スケジュール格納用ソートリスト
		//
		//		// コネクション文字列取得
		//		string connectionText = this.GetConnectionText();
		//		if (connectionText == "") return status;
		//		
		//		using (SqlConnection sqlConnection = new SqlConnection(connectionText))
		//		{
		//			try
		//			{
		//				sqlConnection.Open();
		//
		//				//請求売上
		//				if (kingetData.DmdSalesDB == null){kingetData.DmdSalesDB = new KingetDmdSalesDB();}
		//				ArrayList allDmdSalesWorkList = new ArrayList();
		//				ArrayList dmdSalesWorkList = new ArrayList();
		//	
		//				foreach (SeiKingetDetailParameter detailParameter in parameterList)
		//				{
		//					int st = (int)ConstantManagement.DB_Status.ctDB_EOF;
		//		
		//					// 日付範囲が入っていない場合、スケジュールを参照する
		//					if ((detailParameter.StartDateSpan <= 0)||(detailParameter.EndDateSpan <= 0))
		//					{
		//						if (!customerScheduleSortedList.Contains(detailParameter.CustomerCode))
		//						{
		//							// 得意先スケジュール取得
		//							this.GetScheduleByCustomerCode(ref customerScheduleSortedList, enterpriseCode, detailParameter.CustomerCode, 1,
		//								DateTime.Today.AddYears(-10), TDateTime.LongDateToDateTime("YYYYMMDD", 20991231), ref kingetData);
		//						}
		//			
		//						if (!customerScheduleSortedList.Contains(detailParameter.CustomerCode))
		//						{
		//							// 締日スケジュールが取得されていない場合は取得する
		//							if ((totalDayScheduleSortedList == null) || (totalDayScheduleSortedList.Count == 0))
		//							{
		//								// スケジュール取得
		//								st = this.GetScheduleForDetail(ref totalDayScheduleSortedList, enterpriseCode, parameterList, ref kingetData);
		//								if (st == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
		//								{
		//								}
		//								else
		//									if (st == (int)ConstantManagement.DB_Status.ctDB_EOF)
		//								{
		//									continue;
		//								}
		//								else
		//								{
		//									return status;
		//								}
		//							}
		//						}
		//			
		//						// 締日が無い場合は得意先情報を取得
		//						if (detailParameter.TotalDay <= 0)
		//						{
		//							KingetCustDmdPrcWork kingetCustDmdPrcWork = new KingetCustDmdPrcWork();
		//		
		//							// 得意先情報取得
		//							st = this.ReadCustomer(ref kingetCustDmdPrcWork, sqlConnection, enterpriseCode, detailParameter.CustomerCode);
		//							if (st == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
		//							{
		//								detailParameter.TotalDay = kingetCustDmdPrcWork.TotalDay;
		//							}
		//							else
		//								if (st == (int)ConstantManagement.DB_Status.ctDB_EOF)
		//							{
		//								continue;
		//							}
		//							else
		//							{
		//								return st;
		//							}
		//						}
		//			
		//						// 明細取得用抽出日付範囲取得
		//						int startDateSpan;
		//						int endDateSpan;
		//						SeiKingetParameter seiKingetParameter = new SeiKingetParameter();
		//						seiKingetParameter.StartAddUpDate = TDateTime.LongDateToDateTime("YYYYMMDD", detailParameter.AddUpDate);
		//						seiKingetParameter.EndAddUpDate = TDateTime.LongDateToDateTime("YYYYMMDD", detailParameter.AddUpDate);
		//			
		//						// 得意先スケジュールが存在する場合
		//						if (customerScheduleSortedList.Contains(detailParameter.CustomerCode))
		//						{
		//							if (!this.GetDateSpanForDetailFromCustomerSchedule(out startDateSpan, out endDateSpan, detailParameter.CustomerCode, customerScheduleSortedList, seiKingetParameter))
		//							{
		//								continue;
		//							}
		//						}
		//						else
		//						{
		//							if (!this.GetDateSpanForDetailFromTotalDaySchedule(out startDateSpan, out endDateSpan, detailParameter.TotalDay, totalDayScheduleSortedList, seiKingetParameter))
		//							{
		//								continue;
		//							}
		//						}
		//						detailParameter.StartDateSpan = startDateSpan;
		//						detailParameter.EndDateSpan = endDateSpan;
		//					}
		//		
		//					addUpSecCodeList.Clear();
		//					if ((detailParameter.AddUpSecCode.Trim() != "") && (detailParameter.AddUpSecCode.Trim() != ALLSECCODE))
		//					{
		//						addUpSecCodeList.Add(detailParameter.AddUpSecCode);				
		//					}
		//					st = kingetData.DmdSalesDB.Search(out dmdSalesWorkList, enterpriseCode, addUpSecCodeList, detailParameter.CustomerCode,
		//						detailParameter.StartDateSpan, detailParameter.EndDateSpan, sqlConnection);
		//					if (st == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
		//					{
        //                        // ↓ 20070123 18322 c MA.NS用に変更
		//						//foreach (DmdSalesWork dmdSalesWork in dmdSalesWorkList)
		//						//{
		//						//	allDmdSalesWorkList.Add(dmdSalesWork);
		//						//}
		//
		//						foreach (SalesSlipWork salesSalesWork in dmdSalesWorkList)
		//						{
		//							allDmdSalesWorkList.Add(salesSalesWork);
		//						}
        //                        // ↑ 20070123 18322 c
		//					}
		//					else
		//						if (st == (int)ConstantManagement.DB_Status.ctDB_EOF)
		//					{
		//					}
		//					else
		//					{
		//						return st;
		//					}
		//				}
		//	
		//				//入金
		//				if (kingetData.DepsitMainDB == null){kingetData.DepsitMainDB = new KingetDepsitMainDB();}
		//				ArrayList allDepsitMainWorkList = new ArrayList();
		//				ArrayList depsitMainWorkList = new ArrayList();
		//	
		//				foreach (SeiKingetDetailParameter detailParameter in parameterList)
		//				{
		//					// 日付範囲が入っていない場合、次へ進む
		//					if ((detailParameter.StartDateSpan <= 0)||(detailParameter.EndDateSpan <= 0))
		//					{
		//						continue;
		//					}
		//			
		//					addUpSecCodeList.Clear();
		//					if ((detailParameter.AddUpSecCode.Trim() != "") && (detailParameter.AddUpSecCode.Trim() != ALLSECCODE))
		//					{
		//						addUpSecCodeList.Add(detailParameter.AddUpSecCode);
		//					}
		//					int st = kingetData.DepsitMainDB.Search(out depsitMainWorkList, enterpriseCode, addUpSecCodeList, detailParameter.CustomerCode,
		//						detailParameter.StartDateSpan, detailParameter.EndDateSpan, sqlConnection);
		//					if (st == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
		//					{
		//						foreach (DepsitMainWork depsitMainWork in depsitMainWorkList)
		//						{
		//							allDepsitMainWorkList.Add(depsitMainWork);
		//						}
		//					}
		//					else
		//						if (st == (int)ConstantManagement.DB_Status.ctDB_EOF)
		//					{
		//					}
		//					else
		//					{
		//						return st;
		//					}
		//				}
		//		
		//				if ((allDmdSalesWorkList.Count > 0) || (allDepsitMainWorkList.Count > 0))
		//				{
		//					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
		//				}
		//				objDmdSalesWorkList = allDmdSalesWorkList;
		//				objDepsitMainWorkList = allDepsitMainWorkList;
		//			}
		//			finally
		//			{
		//				if (sqlConnection != null) sqlConnection.Close();
		//			}
		//		}
		//	}
		//	catch (SqlException ex) 
		//	{
		//		//基底クラスに例外を渡して処理してもらう
		//		status = base.WriteSQLErrorLog(ex);
		//	}
		//	finally
		//	{
		//		if (totalDayScheduleSortedList != null)
		//		{
		//			totalDayScheduleSortedList.Clear();
		//			totalDayScheduleSortedList = null;
		//		}
		//
		//		if (customerScheduleSortedList != null)
		//		{
		//			customerScheduleSortedList.Clear();
		//			customerScheduleSortedList = null;
		//		}
		//	}
		//
		//	return status;
		//}
        #endregion
        // ↑ 20070417 18322 d

        // ↓ 20070417 18322 a 請求金額明細情報取得処理
        /// <summary>
		/// 請求金額明細情報取得処理
		/// </summary>
		/// <param name="objDmdSalesWorkList">請求売上情報リスト</param>
		/// <param name="objDepsitMainWorkList">入金情報リスト</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="objSeiKingetDetailParameterList">明細検索パラメータリスト</param>
        /// <param name="kingetData">請求KINGETデータ格納クラス</param>
        /// <returns>STATUS</returns>
		/// <br>Note       : 明細検索パラメータリストの条件で請求売上データと入金データを取得し返します。</br>
		/// <br>Programmer : 18322 木村 武正</br>
		/// <br>Date       : 2007.04.17</br>
		private int SearchDetailsProc(out object        objDmdSalesWorkList
                                     ,out object        objDepsitMainWorkList
                                     ,    string        enterpriseCode
                                     ,    object        objSeiKingetDetailParameterList
                                     ,ref SeiKingetData kingetData)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			
			objDmdSalesWorkList = null;
			objDepsitMainWorkList = null;
			
			try
			{
				// コネクション文字列取得
				string connectionText = this.GetConnectionText();
				if (connectionText == "") return status;
				
				using (SqlConnection sqlConnection = new SqlConnection(connectionText))
				{
					try
					{
						sqlConnection.Open();

						objDmdSalesWorkList = new ArrayList();
						objDepsitMainWorkList = new ArrayList();

                        status = (int)ConstantManagement.DB_Status.ctDB_EOF;
					}
					finally
					{
						if (sqlConnection != null)
                        {
                            sqlConnection.Close();
                        }
					}
				}
			}
			catch (SqlException ex) 
			{
				//基底クラスに例外を渡して処理してもらう
				//status = base.WriteSQLErrorLog(ex);  //DEL 2008/07/10 M.Kubota
                //--- ADD 2008/07/10 M.Kubota --->>>
                string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
                //--- ADD 2008/07/10 M.Kubota ---<<<
			}
			finally
			{
			}

			return status;
		}
        // ↑ 20070417 18322 a
		
		/// <summary>
		/// 得意先請求合計残高チェック処理
		/// </summary>
		/// <param name="enterpriceCode">企業コード</param>
		/// <param name="customerCode">得意先コード</param>
		/// <returns>0:請求合計残高＝０円もしくは取引無し, 1:請求合計残高≠０円</returns>
		/// <br>Note       : 指定得意先コードの得意先請求金額マスタの最終レコードの請求合計残高をチェックします。</br>
		/// <br>Programmer : 18023 樋口　政成</br>
		/// <br>Date       : 2005.07.21</br>
		private int CheckDemandPriceProc(string enterpriceCode, int customerCode)
		{
			int status = 1;

			try
			{
				// コネクション文字列取得
				string connectionText = this.GetConnectionText();
				if (connectionText == "") return status;
				
				// SQL接続
				using (SqlConnection sqlConnection = new SqlConnection(connectionText))
				{
					try
					{
						sqlConnection.Open();
				
						// 得意先請求金額マスタ最終レコード金額０円チェック
						int st = this.CheckCustDmdPrc_LastRecord(sqlConnection, enterpriceCode, customerCode);
						if ((st == (int)ConstantManagement.DB_Status.ctDB_NORMAL) ||
							(st == (int)ConstantManagement.DB_Status.ctDB_EOF))
						{
							status = 0;
						}
					}
					finally
					{
						if (sqlConnection != null) sqlConnection.Close();
					}

				}
			}
			catch (SqlException ex) 
			{
				//基底クラスに例外を渡して処理してもらう
				//status = base.WriteSQLErrorLog(ex);  //DEL 2008/07/10 M.Kubota
                //--- ADD 2008/07/10 M.Kubota --->>>
                string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
                //--- ADD 2008/07/10 M.Kubota ---<<<
			}

			return status;
		}
		
		/// <summary>
		/// 得意先情報取得処理
		/// </summary>
		/// <param name="kingetCustDmdPrcWork">KINGET用得意先請求金額情報</param>
		/// <param name="sqlConnection">SQLConnection</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="customerCode">得意先コード</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : 得意先マスタを検索し、KINGET用得意先請求金額情報に格納して返します。</br>
		/// <br>Programmer : 18023 樋口　政成</br>
		/// <br>Date       : 2005.07.21</br>		
		private int ReadCustomer(ref KingetCustDmdPrcWork kingetCustDmdPrcWork, SqlConnection sqlConnection,
			string enterpriseCode, int customerCode)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			
			#region 2006.08.21 DEL 樋口　政成
			//using (SqlCommand sqlCommand = new SqlCommand("SELECT"
			//    +" CUSTOMERRF.CUSTOMERCODERF,CUSTOMERRF.NAMERF,CUSTOMERRF.NAME2RF,CUSTOMERRF.HONORIFICTITLERF,CUSTOMERRF.KANARF,CUSTOMERRF.OUTPUTNAMECODERF"
			//    +",CUSTOMERRF.OUTPUTNAMERF,CUSTOMERRF.CORPORATEDIVCODERF,CUSTOMERRF.POSTNORF,CUSTOMERRF.ADDRESS1RF,CUSTOMERRF.ADDRESS2RF"
			//    +",CUSTOMERRF.ADDRESS3RF,CUSTOMERRF.ADDRESS4RF,CUSTOMERRF.HOMETELNORF,CUSTOMERRF.OFFICETELNORF,CUSTOMERRF.PORTABLETELNORF"
			//    // 2006.04.21 ADD START 樋口　政成
			//    +",CUSTOMERRF.HOMEFAXNORF,CUSTOMERRF.OFFICEFAXNORF,CUSTOMERRF.OTHERSTELNORF,CUSTOMERRF.MAINCONTACTCODERF"
			//    // 2006.04.21 ADD END 樋口　政成
			//    +",CUSTOMERRF.TOTALDAYRF,CUSTOMERRF.COLLECTMONEYNAMERF,CUSTOMERRF.COLLECTMONEYDAYRF"
			//    +",CUSTOMERRF.CUSTOMERAGENTCDRF,CUSTOMERRF.CUSTOMERAGENTNMRF,CUSTOMERRF.BILLCOLLECTERCDRF,CUSTOMERRF.BILLCOLLECTERNMRF"
			//    +" FROM CUSTOMERRF"
			//    +" WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE"
			//    +" AND CUSTOMERCODERF=@FINDCUSTOMERCODE"
			#endregion

            //--- ADD 2008/04/25 M.Kubota --->>>
            string errmsg = NSDebug.GetExecutingMethodName(new StackFrame());            

            # region [SELECT文]
            string sqlText = string.Empty;
            sqlText += "SELECT" + Environment.NewLine;
            sqlText += "  CUST.CUSTOMERCODERF" + Environment.NewLine;
            sqlText += " ,CUST.NAMERF AS CUSTOMERNAMERF" + Environment.NewLine;
            sqlText += " ,CUST.NAME2RF AS CUSTOMERNAME2RF" + Environment.NewLine;
            sqlText += " ,CUST.HONORIFICTITLERF" + Environment.NewLine;
            sqlText += " ,CUST.KANARF" + Environment.NewLine;
            sqlText += " ,CUST.CUSTOMERSNMRF" + Environment.NewLine;
            sqlText += " ,CUST.OUTPUTNAMECODERF" + Environment.NewLine;
            sqlText += " ,CUST.OUTPUTNAMERF" + Environment.NewLine;
            sqlText += " ,CUST.CORPORATEDIVCODERF" + Environment.NewLine;
            sqlText += " ,CUST.POSTNORF" + Environment.NewLine;
            sqlText += " ,CUST.ADDRESS1RF" + Environment.NewLine;
            sqlText += " ,CUST.ADDRESS3RF" + Environment.NewLine;
            sqlText += " ,CUST.ADDRESS4RF" + Environment.NewLine;
            sqlText += " ,CUST.HOMETELNORF" + Environment.NewLine;
            sqlText += " ,CUST.OFFICETELNORF" + Environment.NewLine;
            sqlText += " ,CUST.PORTABLETELNORF" + Environment.NewLine;
            sqlText += " ,CUST.HOMEFAXNORF" + Environment.NewLine;
            sqlText += " ,CUST.OFFICEFAXNORF" + Environment.NewLine;
            sqlText += " ,CUST.OTHERSTELNORF" + Environment.NewLine;
            sqlText += " ,CUST.MAINCONTACTCODERF" + Environment.NewLine;
            sqlText += " ,CUST.CUSTANALYSCODE1RF" + Environment.NewLine;
            sqlText += " ,CUST.CUSTANALYSCODE2RF" + Environment.NewLine;
            sqlText += " ,CUST.CUSTANALYSCODE3RF" + Environment.NewLine;
            sqlText += " ,CUST.CUSTANALYSCODE4RF" + Environment.NewLine;
            sqlText += " ,CUST.CUSTANALYSCODE5RF" + Environment.NewLine;
            sqlText += " ,CUST.CUSTANALYSCODE6RF" + Environment.NewLine;
            sqlText += " ,CUST.TOTALDAYRF" + Environment.NewLine;
            sqlText += " ,CUST.COLLECTMONEYCODERF" + Environment.NewLine;
            sqlText += " ,CUST.COLLECTMONEYNAMERF" + Environment.NewLine;
            sqlText += " ,CUST.COLLECTMONEYDAYRF" + Environment.NewLine;
            sqlText += " ,CUST.CLAIMCODERF" + Environment.NewLine;
            sqlText += " ,CUST.CUSTOMERAGENTCDRF" + Environment.NewLine;
            sqlText += " ,CUST.BILLCOLLECTERCDRF" + Environment.NewLine;
            sqlText += " ,BILL.NAMERF AS BILLCOLLECTERNMRF" + Environment.NewLine;
            sqlText += " ,CUST.OLDCUSTOMERAGENTCDRF" + Environment.NewLine;
            sqlText += " ,CUST.CUSTAGENTCHGDATERF" + Environment.NewLine;
            sqlText += " ,CLIM.NAMERF AS CLAIMNAMERF" + Environment.NewLine;
            sqlText += " ,CLIM.NAME2RF AS CLAIMNAME2RF" + Environment.NewLine;
            sqlText += " ,CLIM.CUSTOMERSNMRF AS CLAIMSNMRF" + Environment.NewLine;
            sqlText += " ,CAGT.NAMERF AS CUSTOMERAGENTNMRF" + Environment.NewLine;
            sqlText += " ,OAGT.NAMERF AS OLDCUSTOMERAGENTNMRF" + Environment.NewLine;
            sqlText += "FROM" + Environment.NewLine;
            sqlText += "  CUSTOMERRF AS CUST" + Environment.NewLine;
            sqlText += "  LEFT OUTER JOIN CUSTOMERRF AS CLIM" + Environment.NewLine;
            sqlText += "    ON  CUST.ENTERPRISECODERF = CLIM.ENTERPRISECODERF" + Environment.NewLine;
            sqlText += "    AND CUST.CLAIMCODERF = CLIM.CUSTOMERCODERF" + Environment.NewLine;
            sqlText += "  LEFT OUTER JOIN EMPLOYEERF AS CAGT" + Environment.NewLine;
            sqlText += "    ON  CUST.ENTERPRISECODERF = CAGT.ENTERPRISECODERF" + Environment.NewLine;
            sqlText += "    AND CUST.CUSTOMERAGENTCDRF = CAGT.EMPLOYEECODERF" + Environment.NewLine;
            sqlText += "  LEFT OUTER JOIN EMPLOYEERF AS OAGT" + Environment.NewLine;
            sqlText += "    ON  CUST.ENTERPRISECODERF = OAGT.ENTERPRISECODERF" + Environment.NewLine;
            sqlText += "    AND CUST.OLDCUSTOMERAGENTCDRF = OAGT.EMPLOYEECODERF" + Environment.NewLine;
            sqlText += "  LEFT OUTER JOIN EMPLOYEERF AS BILL" + Environment.NewLine;
            sqlText += "    ON  CUST.ENTERPRISECODERF = BILL.ENTERPRISECODERF" + Environment.NewLine;
            sqlText += "    AND CUST.BILLCOLLECTERCDRF = BILL.EMPLOYEECODERF" + Environment.NewLine;
            sqlText += "WHERE" + Environment.NewLine;
            sqlText += "  CUST.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
            sqlText += "  AND CUST.LOGICALDELETECODERF = @FINDLOGICALDELETECODE" + Environment.NewLine;
            sqlText += "  AND CUST.CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;
            # endregion            
            //--- ADD 2008/04/25 M.Kubota ---<<<
            
            //--- DEL 2008/04/25 M.Kubota --->>>
            // 2006.08.21 ADD START 樋口　政成
            //using (SqlCommand sqlCommand = new SqlCommand(SELECT_CUSTOMER
            //    +" WHERE CUSTOMERRF.ENTERPRISECODERF=@FINDENTERPRISECODE AND CUSTOMERRF.LOGICALDELETECODERF=@FINDLOGICALDELETECODE"
            //    +" AND CUSTOMERRF.CUSTOMERCODERF=@FINDCUSTOMERCODE"
			// 2006.08.21 ADD END 樋口　政成
            //		, sqlConnection))
            //--- DEL 2008/04/25 M.Kubota ---<<<

            try
            {

                using (SqlCommand sqlCommand = new SqlCommand(sqlText, sqlConnection))  //ADD 2008/04/25 M.Kubota
                {
                    SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
                    paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);

                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);

                    SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
                    paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(customerCode);

                    using (SqlDataReader myReader = sqlCommand.ExecuteReader())
                    {
                        try
                        {
                            while (myReader.Read())
                            {
                                this.SetKingetCustDmdPrcWorkFromCustomerDataReader(ref kingetCustDmdPrcWork, myReader);
                                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                                break;
                            }
                        }
                        finally
                        {
                            if (myReader != null) myReader.Close();
                        }
                    }
                }
            }
            //--- ADD 2008/07/10 M.Kubota --->>>
            catch (SqlException ex)
            {
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                base.WriteErrorLog(ex, errmsg, status);
            }
            //--- ADD 2008/07/10 M.Kubota ---<<<

			return status;
		}

        // ↓ 2007.12.21 980081 d
        #region 得意先情報検索処理 未使用のため削除
        ///// <summary>
        ///// 得意先情報検索処理
        ///// </summary>
        ///// <param name="customerTable">得意先情報テーブル(KINGET用得意先請求金額情報クラスとして)</param>
        ///// <param name="sqlConnection">SQLConnection</param>
        ///// <param name="parameter">検索パラメータ</param>
        ///// <returns>STATUS</returns>
        ///// <br>Note       : 得意先マスタを検索し、KINGET用得意先請求金額情報に格納して返します。</br>
        ///// <br>Programmer : 18023 樋口　政成</br>
        ///// <br>Date       : 2005.07.21</br>		
		//private int SearchCustomer(out Hashtable customerTable, SqlConnection sqlConnection, SeiKingetParameter parameter)
		//{
		//	int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
		//	
		//	customerTable = new Hashtable();
		//	
		//	#region 2006.08.21 DEL 樋口　政成
		//	//using (SqlCommand sqlCommand = new SqlCommand("SELECT"
		//	//    +" CUSTOMERRF.CUSTOMERCODERF,CUSTOMERRF.NAMERF,CUSTOMERRF.NAME2RF,CUSTOMERRF.HONORIFICTITLERF,CUSTOMERRF.KANARF,CUSTOMERRF.OUTPUTNAMECODERF"
		//	//    +",CUSTOMERRF.OUTPUTNAMERF,CUSTOMERRF.CORPORATEDIVCODERF,CUSTOMERRF.POSTNORF,CUSTOMERRF.ADDRESS1RF,CUSTOMERRF.ADDRESS2RF"
		//	//    +",CUSTOMERRF.ADDRESS3RF,CUSTOMERRF.ADDRESS4RF,CUSTOMERRF.HOMETELNORF,CUSTOMERRF.OFFICETELNORF,CUSTOMERRF.PORTABLETELNORF"
		//	//    // 2006.04.21 ADD START 樋口　政成
		//	//    +",CUSTOMERRF.HOMEFAXNORF,CUSTOMERRF.OFFICEFAXNORF,CUSTOMERRF.OTHERSTELNORF,CUSTOMERRF.MAINCONTACTCODERF"
		//	//    // 2006.04.21 ADD END 樋口　政成
		//	//    +",CUSTOMERRF.TOTALDAYRF,CUSTOMERRF.COLLECTMONEYNAMERF,CUSTOMERRF.COLLECTMONEYDAYRF"
		//	//    +",CUSTOMERRF.CUSTOMERAGENTCDRF,CUSTOMERRF.CUSTOMERAGENTNMRF,CUSTOMERRF.BILLCOLLECTERCDRF,CUSTOMERRF.BILLCOLLECTERNMRF"
		//	//    +" FROM CUSTOMERRF"
		//	//    +" WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE"
		//	#endregion
		//	using (SqlCommand sqlCommand = new SqlCommand(SELECT_CUSTOMER, sqlConnection))	// 2006.08.21 ADD 樋口　政成
		//	{
		//		// Where文の作成
		//		bool result = this.MakeWhereStringForSearchCustomer(sqlCommand, parameter);
		//		if (!result) return status;
        //
		//		using (SqlDataReader myReader = sqlCommand.ExecuteReader())
		//		{
		//			try
		//			{
		//				while (myReader.Read())
		//				{
		//					KingetCustDmdPrcWork kingetCustDmdPrcWork = new KingetCustDmdPrcWork();
		//					this.SetKingetCustDmdPrcWorkFromCustomerDataReader(kingetCustDmdPrcWork, myReader);
		//					customerTable.Add(kingetCustDmdPrcWork.CustomerCode, kingetCustDmdPrcWork);
		//					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
		//				}
		//			}
		//			finally
		//			{
		//				if (myReader != null) myReader.Close();
		//			}
		//		}
		//	}
		//	
		//	return status;
        //}
        #endregion
        // ↑ 2007.12.21 980081 d

        // ↓ 2007.12.21 980081 d
        #region Where文作成（得意先情報検索） 未使用のため削除
        ///// <summary>
		///// Where文作成（得意先情報検索）
		///// </summary>
		///// <param name="sqlCommand">SqlCommand</param>
		///// <param name="parameter">検索パラメータ</param>
		///// <returns>STATUS</returns>
		///// <br>Note       : 得意先マスタを検索するためのWhere文を作成します。</br>
		///// <br>Programmer : 18023 樋口　政成</br>
		///// <br>Date       : 2005.07.21</br>		
		//private bool MakeWhereStringForSearchCustomer(SqlCommand sqlCommand, SeiKingetParameter parameter)
		//{
		//	StringBuilder resultSB = new StringBuilder(" WHERE");
		//	
		//	// 企業コード
		//	resultSB.Append(" CUSTOMERRF.ENTERPRISECODERF=@FINDENTERPRISECODE");
		//	SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
		//	paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(parameter.EnterpriseCode);
        //
		//	// 論理削除区分
		//	resultSB.Append(" AND CUSTOMERRF.LOGICALDELETECODERF=@FINDLOGICALDELETECODE");
		//	SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
		//	paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
        //
		//	// 得意先コード
		//	resultSB.Append(this.MakeWhereStringCustomerCode(sqlCommand, parameter.StartCustomerCode, parameter.EndCustomerCode, "CUSTOMERRF"));
		//	
		//	// 締日
		//	resultSB.Append(this.MakeWhereStringTotalDay(sqlCommand, parameter.TotalDay, parameter.StartTotalDay, parameter.EndTotalDay, "CUSTOMERRF"));
        //
		//	// 得意先カナ
		//	resultSB.Append(this.MakeWhereStringKana(sqlCommand, parameter.StartKana, parameter.EndKana, "CUSTOMERRF"));
		//	
		//	// 従業員コード
		//	resultSB.Append(this.MakeWhereStringEmployeeCode(sqlCommand, parameter.EmployeeKind, parameter.StartEmployeeCode, parameter.EndEmployeeCode, "CUSTOMERRF"));
		//		
		//	// 請求書出力区分コード
		//	if (parameter.IsJudgeBillOutputCode)
		//	{
		//		resultSB.Append(" AND CUSTOMERRF.BILLOUTPUTCODERF=@FINDBILLOUTPUTCODE");
		//		SqlParameter paraBillOutputCode = sqlCommand.Parameters.Add("@FINDBILLOUTPUTCODE", SqlDbType.Int);
		//		paraBillOutputCode.Value = SqlDataMediator.SqlSetInt32(0);
		//	}
        //
		//	// 個人・法人区分
		//	string whereCorporateDivCode;
		//	if (!this.MakeWhereStringCorporateDivCode(out whereCorporateDivCode, parameter.CorporateDivCodeList, parameter.IsAllCorporateDivCode))
		//	{
		//		return false;
		//	}
		//	resultSB.Append(whereCorporateDivCode);
		//	
		//	// 得意先分析コード
		//	resultSB.Append(this.MakeWhereStringCustAnalysCode(sqlCommand, parameter, "CUSTOMERRF"));
		//	
		//	sqlCommand.CommandText += resultSB.ToString();
        //
		//	return true;
		//}
        #endregion
        // ↑ 2007.12.21 980081 d

        // ↓ 2007.12.21 980081 d
        #region 拠点情報検索処理 未使用のため削除
        ///// <summary>
        ///// 拠点情報検索処理
        ///// </summary>
        ///// <param name="sectionList">拠点情報ソートリスト</param>
        ///// <param name="sqlConnection">SQLConnection</param>
        ///// <param name="parameter">検索パラメータ</param>
        ///// <returns>STATUS</returns>
        ///// <br>Note       : 拠点情報設定マスタを検索し、拠点コードのリストとして返します。</br>
        ///// <br>Programmer : 18023 樋口　政成</br>
        ///// <br>Date       : 2005.07.21</br>		
		//private int SearchSection(out SortedList sectionList, SqlConnection sqlConnection, SeiKingetParameter parameter)
		//{
		//	int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
		//	
		//	sectionList = new SortedList();
		//	
		//	// 拠点コード
		//	string whereSectionCode;
		//	if (!this.MakeWhereStringSectionCode(out whereSectionCode, parameter.AddUpSecCodeList, parameter.IsSelectAllSection,
		//		parameter.IsOutputAllSecRec, "SECINFOSETRF", "SECTIONCODERF"))
		//	{
		//		return status;
		//	}
		//	
		//	using (SqlCommand sqlCommand = new SqlCommand("SELECT SECTIONCODERF FROM SECINFOSETRF"
		//			   +" WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND LOGICALDELETECODERF=@FINDLOGICALDELETECODE"
		//			   + whereSectionCode
		//			   , sqlConnection))
		//	{
		//		SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
		//		paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(parameter.EnterpriseCode);
        //
		//		SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
		//		paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
        //
		//		using (SqlDataReader myReader = sqlCommand.ExecuteReader())
		//		{
		//			try
		//			{
		//				while (myReader.Read())
		//				{
		//					string sectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
		//					sectionList.Add(sectionCode, null);
		//					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
		//				}
		//			}
		//			finally
		//			{
		//				if (myReader != null) myReader.Close();
		//			}
		//		}
		//	}
		//	
		//	return status;
        //}
        #endregion
        // ↑ 2007.12.21 980081 d

        // ↓ 20070417 18322 d 締めスケジュールは、MA.NSでは使用しないので削除
        #region 締日スケジュールリスト取得処理（全てコメントアウト）
        ///// <summary>
		///// 締日スケジュールリスト取得処理
		///// </summary>
		///// <param name="totalDayScheduleSortedList">スケジュール格納用ソートリスト</param>
		///// <param name="enterpriseCode">企業コード</param>
		///// <param name="totalDay">締日</param>
		///// <param name="endScheduleDate">スケジュール取得日付（終了）</param>
        ///// <param name="kingetData">請求KINGETデータ格納クラス</param>
        ///// <returns>STATUS</returns>
		///// <br>Note       : 締スケジュールリストを検索し、スケジュール格納用ソートリストを返します。</br>
		///// <br>Programmer : 18023 樋口　政成</br>
		///// <br>Date       : 2005.07.21</br>		
		//private int GetScheduleByTotalDay(ref SortedList totalDayScheduleSortedList, string enterpriseCode, int totalDay, DateTime endScheduleDate, ref SeiKingetData kingetData)
		//{
		//	int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
		//	
        //    if (kingetData.CAddUpSMngGetInfDB == null)
		//	{
		//		kingetData.CAddUpSMngGetInfDB = new CAddUpSMngGetInfDB();
		//	}
		//	
		//	SearchCAddUpSMngToDateRangeParm para = new SearchCAddUpSMngToDateRangeParm();
		//	para.EnterpriseCode = enterpriseCode;
		//	para.TotalDay		= totalDay;
		//	para.StartAddUpDate	= endScheduleDate.AddYears(-20);
		//	para.EndAddUpDate	= endScheduleDate;
		//	para.ExtraDivision	= SearchCAddUpSMngToDateRangeParm.EXTRADIVISION_OPERATINGYEAR;
		//	
		//	ArrayList schedules = new ArrayList();
		//	
		//	status = kingetData.CAddUpSMngGetInfDB.SearchTotalDayToDmdAddUpDateOnArrayListTypeDInf(para, ref schedules);
		//	if (status == 0)
		//	{
		//		if (schedules != null)
		//		{
		//			foreach (RetAddUpDateItemTypeDInf retAddUpDateItemTypeDInf in schedules)
		//			{
		//				// 締日
		//				if (!totalDayScheduleSortedList.Contains(retAddUpDateItemTypeDInf.TotalDay))
		//				{
		//					SortedList list = new SortedList();
		//					totalDayScheduleSortedList.Add(retAddUpDateItemTypeDInf.TotalDay, list);
		//				}
		//				
		//				SortedList scheduleDateList = (SortedList)totalDayScheduleSortedList[retAddUpDateItemTypeDInf.TotalDay];
		//				int cAddUpUpdDate = TDateTime.DateTimeToLongDate("YYYYMMDD", retAddUpDateItemTypeDInf.CAddUpUpdDate);
		//				
		//				// 計上日付
		//				if (!scheduleDateList.Contains(cAddUpUpdDate))
		//				{
		//					scheduleDateList.Add(cAddUpUpdDate, retAddUpDateItemTypeDInf);
		//				}
		//			}
		//		}
		//	}
		//	
		//	return status;
        //}
        #endregion
        // ↑ 20070417 18322 d

        // ↓ 20070417 18322 d 締めスケジュールは、MA.NSでは使用しないので削除
        #region 得意先スケジュールリスト取得処理（全てコメントアウト）
        ///// <summary>
		///// 得意先スケジュールリスト取得処理
		///// </summary>
		///// <param name="customerScheduleSortedList">得意先スケジュール格納用ソートリスト</param>
		///// <param name="enterpriseCode">企業コード</param>
		///// <param name="customerCode">得意先コード</param>
		///// <param name="selectionMode">選択方法(0:得意先スケジュールがなければ締日スケジュールを参照,1:得意先スケジュールのみ参照)</param>
		///// <param name="startScheduleDate">スケジュール取得日付（開始）</param>
		///// <param name="endScheduleDate">スケジュール取得日付（終了）</param>
        ///// <param name="kingetData">請求KINGETデータ格納クラス</param>
        ///// <returns>STATUS</returns>
		///// <br>Note       : 締スケジュールリストを検索し、スケジュール格納用ソートリストを返します。</br>
		///// <br>Programmer : 18023 樋口　政成</br>
		///// <br>Date       : 2005.07.21</br>		
		//private int GetScheduleByCustomerCode(ref SortedList customerScheduleSortedList, string enterpriseCode, int customerCode,
		//	int selectionMode, DateTime startScheduleDate, DateTime endScheduleDate, ref SeiKingetData kingetData)
		//{
		//	int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
		//	
		//	if (kingetData.CAddUpSMngGetInfDB == null)
		//	{
		//		kingetData.CAddUpSMngGetInfDB = new CAddUpSMngGetInfDB();
		//	}
		//	
		//	SearchCAddUpSMngToDateRangeParm para = new SearchCAddUpSMngToDateRangeParm();
		//	para.EnterpriseCode = enterpriseCode;
		//	para.TotalDay		= 0;
		//	para.StartAddUpDate	= startScheduleDate;
		//	para.EndAddUpDate	= endScheduleDate;
		//	para.ExtraDivision	= SearchCAddUpSMngToDateRangeParm.EXTRADIVISION_OPERATINGYEAR;
		//	
		//	ArrayList schedules = new ArrayList();
		//
		//	status = kingetData.CAddUpSMngGetInfDB.SearchTotalDayToDmdAddUpDateOnArrayListTypeDInf(para, customerCode, selectionMode, ref schedules);
		//
		//	if (status == 0)
		//	{
		//		if ((schedules != null) && (schedules.Count > 0))
		//		{
		//			// 得意先コード
		//			if (!customerScheduleSortedList.Contains(customerCode))
		//			{
		//				customerScheduleSortedList.Add(customerCode, new SortedList());
		//			}
		//			SortedList scheduleDateList = (SortedList)customerScheduleSortedList[customerCode];
		//	
		//			foreach (RetAddUpDateItemTypeDInf retAddUpDateItemTypeDInf in schedules)
		//			{
		//				int cAddUpUpdDate = TDateTime.DateTimeToLongDate("YYYYMMDD", retAddUpDateItemTypeDInf.CAddUpUpdDate);
		//				// 計上日付
		//				if (!scheduleDateList.Contains(cAddUpUpdDate))
		//				{
		//					scheduleDateList.Add(cAddUpUpdDate, retAddUpDateItemTypeDInf);
		//				}
		//			}
		//		}
		//	}
		//	
		//	return status;
		//}
        #endregion
        // ↑ 20070417 18322 d

        // ↓ 20070417 18322 d 締めスケジュールは、MA.NSでは使用しないので削除
        #region 得意先スケジュールリスト取得処理（全てコメントアウト）
		///// <summary>
		///// 得意先スケジュールリスト取得処理
		///// </summary>
		///// <param name="customerScheduleSortedList">得意先スケジュール格納用ソートリスト</param>
		///// <param name="enterpriseCode">企業コード</param>
		///// <param name="startCustomerCode">得意先コード(開始)</param>
		///// <param name="endCustomerCode">得意先コード(終了)</param>
		///// <param name="startScheduleDate">スケジュール取得日付（開始）</param>
		///// <param name="endScheduleDate">スケジュール取得日付（終了）</param>
		///// <param name="kingetData">請求KINGETデータ格納クラス</param>
		///// <returns>STATUS</returns>
		///// <br>Note       : 締スケジュールリストを検索し、スケジュール格納用ソートリストを返します。</br>
		///// <br>Programmer : 18023 樋口　政成</br>
		///// <br>Date       : 2005.07.21</br>		
		//private int GetScheduleByCustomerCodeRange(ref SortedList customerScheduleSortedList, string enterpriseCode, int startCustomerCode,
		//	int endCustomerCode, DateTime startScheduleDate, DateTime endScheduleDate, ref SeiKingetData kingetData)
		//{
		//	int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
		//	
		//	if (kingetData.CAddUpSMngGetInfDB == null)
		//	{
		//		kingetData.CAddUpSMngGetInfDB = new CAddUpSMngGetInfDB();
		//	}
		//	
		//	SearchCAddUpSMngToDateRangeParm para = new SearchCAddUpSMngToDateRangeParm();
		//	para.EnterpriseCode = enterpriseCode;
		//	para.TotalDay		= 0;
		//	para.StartAddUpDate	= startScheduleDate;
		//	para.EndAddUpDate	= endScheduleDate;
		//	para.ExtraDivision	= SearchCAddUpSMngToDateRangeParm.EXTRADIVISION_OPERATINGYEAR;
		//	
		//	Hashtable scheduleTable = new Hashtable();
		//
		//	status = kingetData.CAddUpSMngGetInfDB.SearchCustomerRangeToDmdAddUpDateInf(para, startCustomerCode, endCustomerCode, ref scheduleTable);
		//
		//	if (status == 0)
		//	{
		//		if ((scheduleTable != null) && (scheduleTable.Count > 0))
		//		{
		//			// 取得したスケジュールは、「Hashtable(KEY:得意先コード)->ArrayList」
		//			foreach (DictionaryEntry de in scheduleTable)
		//			{
		//				int customerCode = (int)de.Key;
		//				ArrayList list	 = (ArrayList)de.Value;
		//			
		//				// 得意先コード
		//				if (!customerScheduleSortedList.Contains(customerCode))
		//				{
		//					customerScheduleSortedList.Add(customerCode, new SortedList());
		//				}
		//				SortedList scheduleDateList = (SortedList)customerScheduleSortedList[customerCode];
		//		
		//				foreach (RetAddUpDateItemTypeDInf retAddUpDateItemTypeDInf in list)
		//				{
		//					int cAddUpUpdDate = TDateTime.DateTimeToLongDate("YYYYMMDD", retAddUpDateItemTypeDInf.CAddUpUpdDate);
		//					// 計上日付
		//					if (!scheduleDateList.Contains(cAddUpUpdDate))
		//					{
		//						scheduleDateList.Add(cAddUpUpdDate, retAddUpDateItemTypeDInf);
		//					}
		//				}
		//			}
		//		}
		//	}
		//	
		//	return status;
		//}
        #endregion
        // ↑ 20070417 18322 d
		
        // ↓ 20070417 18322 d 締めスケジュールは、MA.NSでは使用しないので削除
        #region 締日スケジュールリスト取得処理（全てコメントアウト）
		///// <summary>
		///// 締日スケジュールリスト取得処理
		///// </summary>
		///// <param name="totalDayScheduleSortedList">締日スケジュール格納用ソートリスト</param>
		///// <param name="enterpriseCode">企業コード</param>
		///// <param name="detailParameterList">明細検索パラメータリスト</param>
		///// <param name="kingetData">請求KINGETデータ格納クラス</param>
		///// <returns>STATUS</returns>
		///// <br>Note       : 締日スケジュールリストを検索し、締日スケジュール格納用ソートリストを返します。</br>
		///// <br>Programmer : 18023 樋口　政成</br>
		///// <br>Date       : 2005.07.21</br>		
		//private int GetScheduleForDetail(ref SortedList totalDayScheduleSortedList, string enterpriseCode, ArrayList detailParameterList, ref SeiKingetData kingetData)
		//{
		//	totalDayScheduleSortedList = new SortedList();
		//	
		//	int lastAddUpDate = 0;
		//	
		//	foreach (SeiKingetDetailParameter parameter in detailParameterList)
		//	{
		//		if (lastAddUpDate < parameter.AddUpDate)
		//		{
		//			lastAddUpDate = parameter.AddUpDate;
		//		}
		//	}
		//	
		//	// 締日スケジュール取得
		//	DateTime endScheduleDate = DateTime.Today;
		//	if (lastAddUpDate > 0)
		//	{
		//		endScheduleDate = TDateTime.LongDateToDateTime("YYYYMMDD", lastAddUpDate);
		//		endScheduleDate = endScheduleDate.AddMonths(1);
		//	}				
		//	return this.GetScheduleByTotalDay(ref totalDayScheduleSortedList, enterpriseCode, 0, endScheduleDate, ref kingetData);				
		//}
        #endregion
        // ↑ 20070417 18322 d

        // ↓ 2007.12.21 980081 d
        #region スケジュール取得用日付作成処理 未使用のため削除
        ///// <summary>
        ///// スケジュール取得用日付作成処理
        ///// </summary>
        ///// <param name="startScheduleDate">スケジュール取得用日付(開始)</param>
        ///// <param name="endScheduleDate">スケジュール取得用日付(終了)</param>
        ///// <param name="parameter">検索パラメータ</param>
        ///// <returns>STATUS</returns>
        ///// <br>Note       : スケジュール取得用日付を作成します。</br>
        ///// <br>Programmer : 18023 樋口　政成</br>
        ///// <br>Date       : 2005.07.21</br>
		//private void MakeGetScheduleDate(out DateTime startScheduleDate, out DateTime endScheduleDate, SeiKingetParameter parameter)
		//{
		//	// 開始
		//	if (parameter.StartAddUpYearMonth != 0)
		//	{
		//		startScheduleDate	= TDateTime.LongDateToDateTime("YYYYMMDD", parameter.StartAddUpYearMonth*100+1);
		//		startScheduleDate = startScheduleDate.AddYears(-10);
		//	}
		//	else
		//	if (parameter.StartAddUpDate != DateTime.MinValue)
		//	{
		//		startScheduleDate	= parameter.StartAddUpDate.AddYears(-10);
		//	}
		//	else
		//	{
		//		startScheduleDate	= DateTime.Today.AddYears(-10);
		//	}
		//	
		//	// 終了
		//	if (parameter.EndAddUpYearMonth != 0)
		//	{
		//		endScheduleDate = TDateTime.LongDateToDateTime("YYYYMMDD", parameter.EndAddUpYearMonth*100+1);
		//		endScheduleDate = endScheduleDate.AddMonths(1);
		//	}
		//	else
		//	if (parameter.EndAddUpDate != DateTime.MinValue)
		//	{
		//		endScheduleDate = parameter.EndAddUpDate.AddMonths(1);
		//	}
		//	else
		//	{
		//		endScheduleDate = DateTime.Today.AddMonths(1);
		//	}
        //}
        #endregion
        // ↑ 2007.12.21 980081 d

        #region 得意先請求金額マスタ読み込み（１）処理（全てコメントアウト）
        ///// <summary>
		///// 得意先請求金額マスタ読み込み（１）処理
		///// </summary>
		///// <param name="addSecCodeSortedList">請求金額情報格納用ソートリスト</param>
		///// <param name="sqlConnection">SQLConnection</param>
		///// <param name="enterpiseCode">企業コード</param>
		///// <param name="addUpSecCode">計上拠点コード</param>
		///// <param name="customerCode">得意先コード</param>
		///// <param name="addUpDate">計上日付(YYYYMMDD)</param>
		///// <returns>STATUS</returns>
		///// <br>Note       : 得意先請求金額マスタを検索し、請求金額情報格納用ソートリストを返します。</br>
		///// <br>Programmer : 18023 樋口　政成</br>
		///// <br>Date       : 2005.07.21</br>		
		//private int ReadCustDmdPrc1(ref SortedList addSecCodeSortedList, SqlConnection sqlConnection, string enterpiseCode,
		//    string addUpSecCode, int customerCode, int addUpDate)
		//{
		//    int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			
		//    using (SqlCommand sqlCommand = new SqlCommand(SELECT_CUSTDMDPRC
		//               +" WHERE CUSTDMDPRCRF.ENTERPRISECODERF=@FINDENTERPRISECODE AND CUSTDMDPRCRF.LOGICALDELETECODERF=@FINDLOGICALDELETECODE"
		//               +" AND CUSTDMDPRCRF.ADDUPSECCODERF=@FINDADDUPSECCODE AND CUSTDMDPRCRF.CUSTOMERCODERF=@FINDCUSTOMERCODE"
		//               +" AND CUSTDMDPRCRF.ADDUPDATERF=@FINDADDUPDATE"
		//               , sqlConnection))
		//    {
		//        SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
		//        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpiseCode);

		//        SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
		//        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);

		//        SqlParameter paraAddUpSecCode = sqlCommand.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);
		//        paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(addUpSecCode);

		//        SqlParameter paraCostomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODERF", SqlDbType.Int);
		//        paraCostomerCode.Value = SqlDataMediator.SqlSetInt32(customerCode);

		//        SqlParameter paraAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int);
		//        paraAddUpDate.Value = SqlDataMediator.SqlSetInt32(addUpDate);

		//        using (SqlDataReader myReader = sqlCommand.ExecuteReader())
		//        {
		//            try
		//            {
		//                this.SetListFromSQLReader(ref status, ref addSecCodeSortedList, myReader);
		//            }
		//            finally
		//            {
		//                if (myReader != null) myReader.Close();
		//            }
		//        }
		//    }
			
		//    return status;
        //}
        #endregion

        // ↓ 2007.12.21 980081 d
        #region 得意先請求金額マスタ検索（１）処理 未使用のため削除
        ///// <summary>
        ///// 得意先請求金額マスタ検索（１）処理
        ///// </summary>
        ///// <param name="addSecCodeSortedList">請求金額情報格納用ソートリスト</param>
        ///// <param name="sqlConnection">SQLConnection</param>
        ///// <param name="parameter">検索パラメータ</param>
        ///// <returns>STATUS</returns>
        ///// <br>Note       : 得意先請求金額マスタを検索し、請求金額情報格納用ソートリストを返します。</br>
        ///// <br>Programmer : 18023 樋口　政成</br>
        ///// <br>Date       : 2005.07.21</br>		
		//private int SelectCustDmdPrc1(ref SortedList addSecCodeSortedList, SqlConnection sqlConnection, SeiKingetParameter parameter)
		//{
		//	int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
		//	
		//	using (SqlCommand sqlCommand = new SqlCommand(SELECT_CUSTDMDPRC, sqlConnection))
		//	{
		//		// Where文の作成
		//		bool result = this.MakeWhereStringForSelectCustDmdPrc1(sqlCommand, parameter);
		//		if (!result) return status;
        //
		//		// OrderBy追加
		//		sqlCommand.CommandText += " ORDER BY CUSTDMDPRCRF.ADDUPSECCODERF,CUSTDMDPRCRF.CUSTOMERCODERF,CUSTDMDPRCRF.ADDUPDATERF";
        //
		//		using (SqlDataReader myReader = sqlCommand.ExecuteReader())
		//		{
		//			try
		//			{
		//				this.SetListFromSQLReader(ref status, ref addSecCodeSortedList, myReader);
		//			}
		//			finally
        //			{
        //				if (myReader != null) myReader.Close();
        //			}
        //		}
        //	}
        //	
        //	return status;
        //}
        #endregion
        // ↑ 2007.12.21 980081 d

        // ↓ 2007.12.21 980081 d
        #region 得意先請求金額マスタ検索（２）処理 未使用のため削除
        ///// <summary>
        ///// 得意先請求金額マスタ検索（２）処理
        ///// </summary>
        ///// <param name="addSecCodeSortedList">請求金額情報格納用ソートリスト</param>
        ///// <param name="sqlConnection">SQLConnection</param>
        ///// <param name="parameter">検索パラメータ</param>
        ///// <returns>STATUS</returns>
        ///// <br>Note       : 得意先請求金額マスタの指定日付以前の最終レコードを検索し、請求金額情報格納用ソートリストを返します。</br>
        ///// <br>Programmer : 18023 樋口　政成</br>
        ///// <br>Date       : 2005.07.21</br>		
		//private int SelectCustDmdPrc2(ref SortedList addSecCodeSortedList, SqlConnection sqlConnection, SeiKingetParameter parameter)
		//{
		//	int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
		//	
		//	using (SqlCommand sqlCommand = new SqlCommand(SELECT_CUSTDMDPRC, sqlConnection))
		//	{
		//		// Where文の作成
		//		bool result = this.MakeWhereStringForSelectCustDmdPrc2(sqlCommand, parameter);
		//		if (!result) return status;
        //
		//		// OrderBy追加
		//		sqlCommand.CommandText += " ORDER BY CUSTDMDPRCRF.ADDUPSECCODERF,CUSTDMDPRCRF.CUSTOMERCODERF,CUSTDMDPRCRF.ADDUPDATERF";
        //
		//		using (SqlDataReader myReader = sqlCommand.ExecuteReader())
		//		{
		//			try
		//			{
		//				this.SetListFromSQLReader(ref status, ref addSecCodeSortedList, myReader);
		//			}
		//			finally
		//			{
		//				if (myReader != null) myReader.Close();
		//			}
		//		}
		//	}
		//	
		//	return status;
        //}
        #endregion
        // ↑ 2007.12.21 980081 d

        // ↓ 2007.12.21 980081 d
        #region Where文作成（得意先請求金額マスタ検索１） 未使用のため削除
        ///// <summary>
        ///// Where文作成（得意先請求金額マスタ検索１）
        ///// </summary>
        ///// <param name="sqlCommand">SqlCommand</param>
        ///// <param name="parameter">検索パラメータ</param>
        ///// <returns>STATUS</returns>
        ///// <br>Note       : 得意先請求金額マスタを検索するためのWhere文を作成します。</br>
        ///// <br>Programmer : 18023 樋口　政成</br>
        ///// <br>Date       : 2005.07.21</br>		
		//private bool MakeWhereStringForSelectCustDmdPrc1(SqlCommand sqlCommand, SeiKingetParameter parameter)
		//{
		//	StringBuilder resultSB = new StringBuilder(" WHERE");
		//	
		//	// 企業コード
		//	resultSB.Append(" CUSTDMDPRCRF.ENTERPRISECODERF=@FINDENTERPRISECODE");
		//	SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
		//	paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(parameter.EnterpriseCode);
        //
		//	// 論理削除区分
		//	resultSB.Append(" AND CUSTDMDPRCRF.LOGICALDELETECODERF=@FINDLOGICALDELETECODE");
		//	SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
		//	paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
        //
		//	// 得意先マスタ論理削除(※請求は得意先が論理削除区分の絞込みを行う！！)
		//	resultSB.Append(" AND CUSTOMERRF.LOGICALDELETECODERF=@FINDCUSTOMERLOGICALDELETECODE");
		//	SqlParameter paraCustomerLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDCUSTOMERLOGICALDELETECODE", SqlDbType.Int);
		//	paraCustomerLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
        //
		//	// 計上日
		//	string whereAddUpdate = "";
		//	if (!this.MakeWhereStringAddUpdateNormal(sqlCommand, out whereAddUpdate, parameter))
		//	{
		//		return false;
		//	}
		//	resultSB.Append(whereAddUpdate);
        //
		//	// 計上拠点
		//	string whereAddSecCode;
		//	if (!this.MakeWhereStringSectionCode(out whereAddSecCode, parameter.AddUpSecCodeList, parameter.IsSelectAllSection, 
		//		parameter.IsOutputAllSecRec, "CUSTDMDPRCRF", "ADDUPSECCODERF"))
		//	{
		//		return false;
		//	}
		//	resultSB.Append(whereAddSecCode);
		//	
		//	// 得意先コード
		//	resultSB.Append(this.MakeWhereStringCustomerCode(sqlCommand, parameter.StartCustomerCode, parameter.EndCustomerCode, "CUSTOMERRF"));
		//	
		//	// 得意先カナ
		//	resultSB.Append(this.MakeWhereStringKana(sqlCommand, parameter.StartKana, parameter.EndKana, "CUSTOMERRF"));
		//	
		//	// 従業員コード
		//	resultSB.Append(this.MakeWhereStringEmployeeCode(sqlCommand, parameter.EmployeeKind, parameter.StartEmployeeCode, parameter.EndEmployeeCode, "CUSTOMERRF"));
        //
		//	// 締日
		//	resultSB.Append(this.MakeWhereStringTotalDay(sqlCommand, parameter.TotalDay, parameter.StartTotalDay, parameter.EndTotalDay, "CUSTOMERRF"));
	    //
		//	// 請求書出力区分コード
		//	if (parameter.IsJudgeBillOutputCode)
		//	{
		//		resultSB.Append(" AND CUSTOMERRF.BILLOUTPUTCODERF=@FINDBILLOUTPUTCODE");
		//		SqlParameter paraBillOutputCode = sqlCommand.Parameters.Add("@FINDBILLOUTPUTCODE", SqlDbType.Int);
		//		paraBillOutputCode.Value = SqlDataMediator.SqlSetInt32(0);
		//	}
        //
		//	// 個人・法人区分
		//	string whereCorporateDivCode;
		//	if (!this.MakeWhereStringCorporateDivCode(out whereCorporateDivCode, parameter.CorporateDivCodeList, parameter.IsAllCorporateDivCode))
		//	{
		//		return false;
		//	}
		//	resultSB.Append(whereCorporateDivCode);
		//
		//	// 得意先分析コード
		//	resultSB.Append(this.MakeWhereStringCustAnalysCode(sqlCommand, parameter, "CUSTOMERRF"));
		//	
		//	sqlCommand.CommandText += resultSB.ToString();
        //
		//	return true;
        //}
        #endregion
        // ↑ 2007.12.21 980081 d

        // ↓ 2007.12.21 980081 d
        #region Where文作成（得意先請求金額マスタ検索２） 未使用のため削除
        ///// <summary>
        ///// Where文作成（得意先請求金額マスタ検索２）
        ///// </summary>
        ///// <param name="sqlCommand">SqlCommand</param>
        ///// <param name="parameter">検索パラメータ</param>
        ///// <returns>STATUS</returns>
        ///// <br>Note       : 得意先請求金額マスタを検索するためのWhere文を作成します。</br>
        ///// <br>Programmer : 18023 樋口　政成</br>
        ///// <br>Date       : 2005.07.21</br>		
		//private bool MakeWhereStringForSelectCustDmdPrc2(SqlCommand sqlCommand, SeiKingetParameter parameter)
		//{
		//	StringBuilder resultSB = new StringBuilder(" WHERE");
		//	
		//	// 企業コード
		//	resultSB.Append(" CUSTDMDPRCRF.ENTERPRISECODERF=@FINDENTERPRISECODE");
		//	SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
		//	paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(parameter.EnterpriseCode);
        //
		//	// 論理削除区分
		//	resultSB.Append(" AND CUSTDMDPRCRF.LOGICALDELETECODERF=@FINDLOGICALDELETECODE");
		//	SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
		//	paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
        //
		//	// 得意先マスタ論理削除(※請求は得意先が論理削除区分の絞込みを行う！！)
		//	resultSB.Append(" AND CUSTOMERRF.LOGICALDELETECODERF=@FINDCUSTOMERLOGICALDELETECODE");
		//	SqlParameter paraCustomerLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDCUSTOMERLOGICALDELETECODE", SqlDbType.Int);
		//	paraCustomerLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);
        //
		//	// 計上日
		//	string whereAddUpdate = "";
		//	if (!this.MakeWhereStringAddUpdateLastRecord(sqlCommand, out whereAddUpdate, parameter))
		//	{
		//		return false;
		//	}
		//	resultSB.Append(whereAddUpdate);
        //
		//	// 計上拠点
		//	string whereAddSecCode;
		//	if (!this.MakeWhereStringSectionCode(out whereAddSecCode, parameter.AddUpSecCodeList, parameter.IsSelectAllSection, 
		//		parameter.IsOutputAllSecRec, "CUSTDMDPRCRF", "ADDUPSECCODERF"))
		//	{
		//		return false;
		//	}
		//	resultSB.Append(whereAddSecCode);
		//	
		//	// 得意先コード
		//	resultSB.Append(this.MakeWhereStringCustomerCode(sqlCommand, parameter.StartCustomerCode, parameter.EndCustomerCode, "CUSTOMERRF"));
		//	
		//	// 得意先カナ
		//	resultSB.Append(this.MakeWhereStringKana(sqlCommand, parameter.StartKana, parameter.EndKana, "CUSTOMERRF"));
		//	
		//	// 従業員コード
		//	resultSB.Append(this.MakeWhereStringEmployeeCode(sqlCommand, parameter.EmployeeKind, parameter.StartEmployeeCode, parameter.EndEmployeeCode, "CUSTOMERRF"));
        //
		//	// 締日
		//	resultSB.Append(this.MakeWhereStringTotalDay(sqlCommand, parameter.TotalDay, parameter.StartTotalDay, parameter.EndTotalDay, "CUSTOMERRF"));
	    //
		//	// 請求書出力区分コード
		//	if (parameter.IsJudgeBillOutputCode)
		//	{
		//		resultSB.Append(" AND CUSTOMERRF.BILLOUTPUTCODERF=@FINDBILLOUTPUTCODE");
		//		SqlParameter paraBillOutputCode = sqlCommand.Parameters.Add("@FINDBILLOUTPUTCODE", SqlDbType.Int);
		//		paraBillOutputCode.Value = SqlDataMediator.SqlSetInt32(0);
		//	}
        //
		//	// 個人・法人区分
		//	string whereCorporateDivCode;
		//	if (!this.MakeWhereStringCorporateDivCode(out whereCorporateDivCode, parameter.CorporateDivCodeList, parameter.IsAllCorporateDivCode))
		//	{
		//		return false;
		//	}
		//	resultSB.Append(whereCorporateDivCode);
		//
		//	// 得意先分析コード
		//	resultSB.Append(this.MakeWhereStringCustAnalysCode(sqlCommand, parameter, "CUSTOMERRF"));
		//	
		//	sqlCommand.CommandText += resultSB.ToString();
        //
		//	return true;
        //}
        #endregion
        // ↑ 2007.12.21 980081 d

		/// <summary>
		/// 得意先請求金額マスタ最終レコード金額０円チェック処理
		/// </summary>
		/// <param name="sqlConnection">SQLConnection</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="customerCode">得意先コード</param>
		/// <returns>0:最終レコード有＋請求金額＝０円, 1:最終レコード有＋請求金額≠０円, 9:最終レコード無</returns>
		/// <br>Note       : 得意先請求金額マスタの指定日付以前の最終レコードを検索し、請求金額情報格納用ソートリストを返します。</br>
		/// <br>Programmer : 18023 樋口　政成</br>
		/// <br>Date       : 2005.07.21</br>		
		private int CheckCustDmdPrc_LastRecord(SqlConnection sqlConnection, string enterpriseCode, int customerCode)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            // ↓ 2007.12.21 980081 c
            #region 旧レイアウト(コメントアウト)
            //// ↓ 20070327 18322 c 得意先請求金額マスタのレイアウトが変更になった為、修正
			////using (SqlCommand sqlCommand = new SqlCommand("SELECT AFCALDEMANDPRICERF FROM CUSTDMDPRCRF"
			////		   +" WHERE CUSTDMDPRCRF.ENTERPRISECODERF=@FINDENTERPRISECODE AND CUSTDMDPRCRF.LOGICALDELETECODERF=@FINDLOGICALDELETECODE"
			////		   +" AND CUSTDMDPRCRF.ADDUPDATELASTRECFLGRF=@FINDLASTFLG AND CUSTDMDPRCRF.CUSTOMERCODERF=@FINDCUSTOMERCODE"
			////		   +" AND CUSTDMDPRCRF.ADDUPSECCODERF=@FINDSECCODE"
			////		   , sqlConnection))
            //
            //string selectSql = "SELECT AFCALDEMANDPRICERF"
            //                 +  " FROM CUSTDMDPRCRF"
            //                 + " WHERE CUSTDMDPRCRF.ENTERPRISECODERF=@FINDENTERPRISECODE"
            //                 +   " AND CUSTDMDPRCRF.LOGICALDELETECODERF=@FINDLOGICALDELETECODE"
            //                 +   " AND CUSTDMDPRCRF.CUSTOMERCODERF=@FINDCUSTOMERCODE"
            //                 +   " AND CUSTDMDPRCRF.ADDUPSECCODERF=@FINDSECCODE"
            //                 ;
            //
			//using (SqlCommand sqlCommand = new SqlCommand(selectSql, sqlConnection))
            //// ↑ 20070327 18322 c
            #endregion
            string selectSql = "SELECT AFCALDEMANDPRICERF"
                             +  " FROM CUSTDMDPRCRF"
                             + " WHERE CUSTDMDPRCRF.ENTERPRISECODERF=@FINDENTERPRISECODE"
                             +   " AND CUSTDMDPRCRF.LOGICALDELETECODERF=@FINDLOGICALDELETECODE"
                             +   " AND CUSTDMDPRCRF.CLAIMCODERF=@FINDCUSTOMERCODE"
                             +   " AND CUSTDMDPRCRF.CUSTOMERCODERF=0"
                             +   " AND CUSTDMDPRCRF.ADDUPSECCODERF=@FINDSECCODE"
                             ;

			using (SqlCommand sqlCommand = new SqlCommand(selectSql, sqlConnection))
            // ↑ 2007.12.21 980081 c
			{
				SqlParameter paraEnterpriseCode2 = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
				paraEnterpriseCode2.Value = SqlDataMediator.SqlSetString(enterpriseCode);

				SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
				paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(0);

				SqlParameter paraLastFlg = sqlCommand.Parameters.Add("@FINDLASTFLG", SqlDbType.Int);
				paraLastFlg.Value = SqlDataMediator.SqlSetInt32(1);

				SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
				paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(customerCode);

				// 全拠点レコードのみを対象とする
				SqlParameter paraSecCode = sqlCommand.Parameters.Add("@FINDSECCODE", SqlDbType.NChar);
				paraSecCode.Value = SqlDataMediator.SqlSetString(ALLSECCODE);

				using (SqlDataReader myReader = sqlCommand.ExecuteReader())
				{
					try
					{
						while (myReader.Read())
						{
							Int64 demandPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("AFCALDEMANDPRICERF"));
							if (demandPrice == 0)
							{
								status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
							}
							else
							{
								status = 1;
							}
							break;
						}
					}
					finally
					{
						if (myReader != null) myReader.Close();
					}
				}
			}
			
			return status;
		}

        // ↓ 2007.12.21 980081 d
        #region WHERE文作成（得意先コード）処理 未使用のため削除
        ///// <summary>
        ///// WHERE文作成（得意先コード）処理
        ///// </summary>
        ///// <param name="sqlCommand">SqlCommand</param>
        ///// <param name="startCode">得意先コード（開始）</param>
        ///// <param name="endCode">得意先コード（終了）</param>
        ///// <param name="tableName">テーブル名称</param>
        ///// <returns>作成したWHERE文</returns>
        ///// <br>Note       : 得意先コードのWHERE文を作成して返します。</br>
        ///// <br>Programmer : 18023 樋口　政成</br>
        ///// <br>Date       : 2005.07.21</br>		
		//private string MakeWhereStringCustomerCode(SqlCommand sqlCommand, int startCode, int endCode, string tableName)
		//{
		//	StringBuilder whereCustomerCode = new StringBuilder();
        //
		//	if ((startCode > 0) || (endCode > 0))
		//	{
		//		if (startCode == endCode)
		//		{
		//			whereCustomerCode.Append(" AND " + tableName + ".CUSTOMERCODERF=@FINDCUSTOMERCODE");
		//			SqlParameter paraCustomerCode = sqlCommand.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);
		//			paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(startCode);
		//		}
		//		else
		//		{
		//			if (startCode > 0)
		//			{
		//				whereCustomerCode.Append(" AND " + tableName + ".CUSTOMERCODERF>=@FINDSTARTCUSTOMERCODE");
		//				SqlParameter paraStartCustomerCode = sqlCommand.Parameters.Add("@FINDSTARTCUSTOMERCODE", SqlDbType.Int);
		//				paraStartCustomerCode.Value = SqlDataMediator.SqlSetInt32(startCode);
		//			}
        //
		//			if ((endCode > 0) && (endCode != 999999999))
        //			{
        //				whereCustomerCode.Append(" AND " + tableName + ".CUSTOMERCODERF<=@FINDENDCUSTOMERCODE");
        //				SqlParameter paraEndCustomerCode = sqlCommand.Parameters.Add("@FINDENDCUSTOMERCODE", SqlDbType.Int);
        //				paraEndCustomerCode.Value = SqlDataMediator.SqlSetInt32(endCode);
        //			}
        //		}
        //	}
        //
        //	return whereCustomerCode.ToString();
        //}
        #endregion
        // ↑ 2007.12.21 980081 d

        // ↓ 2007.12.21 980081 d
        #region WHERE文作成（得意先カナ）処理 未使用のため削除
        ///// <summary>
        ///// WHERE文作成（得意先カナ）処理
        ///// </summary>
        ///// <param name="sqlCommand">SqlCommand</param>
        ///// <param name="startKana">得意先カナ（開始）</param>
        ///// <param name="endKana">得意先カナ（終了）</param>
        ///// <param name="tableName">テーブル名称</param>
        ///// <returns>作成したWHERE文</returns>
        ///// <br>Note       : 得意先カナのWHERE文を作成して返します。</br>
        ///// <br>Programmer : 18023 樋口　政成</br>
        ///// <br>Date       : 2005.07.21</br>		
		//private string MakeWhereStringKana(SqlCommand sqlCommand, string startKana, string endKana, string tableName)
		//{
		//	StringBuilder whereKana = new StringBuilder();
        //
		//	if ((startKana != string.Empty) && (startKana == endKana))
		//	{
		//		whereKana.Append(" AND " + tableName + ".KANARF LIKE @FINDSTARTKANA");
		//		SqlParameter paraStartKana = sqlCommand.Parameters.Add("@FINDSTARTKANA", SqlDbType.NVarChar);
		//		paraStartKana.Value = SqlDataMediator.SqlSetString(startKana + "%");
		//	}
		//	else
		//	{
		//		if (startKana != string.Empty)
		//		{
		//			//whereKana = " AND CUSTOMERRF.KANARF>='" + startKana + "'";
		//			whereKana.Append(" AND " + tableName + ".KANARF>=@FINDSTARTKANA");
		//			SqlParameter paraStartKana = sqlCommand.Parameters.Add("@FINDSTARTKANA", SqlDbType.NVarChar);
		//			paraStartKana.Value = SqlDataMediator.SqlSetString(startKana);
		//		}
        //
		//		if (endKana != string.Empty)
		//		{
        //			//whereKana += " AND CUSTOMERRF.KANARF<='" + this.StringAppendLength(endKana,'ン',30) + "'";
        //			whereKana.Append(" AND " + tableName + ".KANARF<=@FINDENDKANA");
        //			SqlParameter paraEndKana = sqlCommand.Parameters.Add("@FINDENDKANA", SqlDbType.NVarChar);
        //			paraEndKana.Value = SqlDataMediator.SqlSetString(this.StringAppendLength(endKana,'ン',30));
        //		}
        //	}
        //
        //	return whereKana.ToString();
        //}
        #endregion
        // ↑ 2007.12.21 980081 d

        // ↓ 2007.12.21 980081 d
        #region WHERE文作成（従業員コード）処理 未使用のため削除
        ///// <summary>
        ///// WHERE文作成（従業員コード）処理
        ///// </summary>
        ///// <param name="sqlCommand">SqlCommand</param>
        ///// <param name="employeeKind">従業員区分</param>
        ///// <param name="startEmployeeCode">従業員コード（開始）</param>
        ///// <param name="endEmployeeCode">従業員コード（終了）</param>
        ///// <param name="tableName">テーブル名称</param>
        ///// <returns>作成したWHERE文</returns>
        ///// <br>Note       : 従業員コードのWHERE文を作成して返します。</br>
        ///// <br>Programmer : 18023 樋口　政成</br>
        ///// <br>Date       : 2005.07.21</br>		
		//private string MakeWhereStringEmployeeCode(SqlCommand sqlCommand, int employeeKind, string startEmployeeCode, string endEmployeeCode, string tableName)
		//{
		//	if (employeeKind < 0) return string.Empty;
		//	
		//	StringBuilder whereEmployeeCode = new StringBuilder();
		//	
		//	string employeeKindName = tableName + ".CUSTOMERAGENTCDRF";
		//	// 従業員区分＝集金担当の場合
		//	if (employeeKind == EMPLOYEEKIND_BILLCOLLECTER)
		//	{
		//		employeeKindName = tableName + ".BILLCOLLECTERCDRF";
		//	}
        //
		//	if (startEmployeeCode != string.Empty)
		//	{
		//		//whereEmployeeCode.Append(" AND " + employeeKindName + ">='" + startEmployeeCode + "'");
		//		whereEmployeeCode.Append(" AND " + employeeKindName + ">=@FINDSTARTEMPLOYEECODE");
		//		SqlParameter paraStartEmployeeCode = sqlCommand.Parameters.Add("@FINDSTARTEMPLOYEECODE", SqlDbType.NChar);
		//		paraStartEmployeeCode.Value = SqlDataMediator.SqlSetString(startEmployeeCode);
		//	}
        //
		//	if (endEmployeeCode != string.Empty)
		//	{
		//		if (startEmployeeCode == string.Empty)
		//		{
		//			whereEmployeeCode.Append(" AND (" + employeeKindName + " IS NULL" +
		//									" OR " + employeeKindName + "<=@FINDENDEMPLOYEECODE)");
		//		}
		//		else
		//		{
		//			whereEmployeeCode.Append(" AND " + employeeKindName + "<=@FINDENDEMPLOYEECODE");
		//		}
		//		SqlParameter paraEndEmployeeCode = sqlCommand.Parameters.Add("@FINDENDEMPLOYEECODE", SqlDbType.NChar);
		//		paraEndEmployeeCode.Value = SqlDataMediator.SqlSetString(this.StringAppendLength(endEmployeeCode,'ン',9));
		//	}
        //
		//	return whereEmployeeCode.ToString();
        //}
        #endregion
        // ↑ 2007.12.21 980081 d

        // ↓ 2007.12.21 980081 d
        #region WHERE文作成（計上日）処理　＜※通常レコード取得時＞ 未使用のため削除
        ///// <summary>
        ///// WHERE文作成（計上日）処理　＜※通常レコード取得時＞
        ///// </summary>
        ///// <param name="sqlCommand">SqlCommand</param>
        ///// <param name="whereAddUpdate">計上日のWHERE文</param>
        ///// <param name="parameter">検索パラメータ</param>
        ///// <returns>true:正常取得,false:異常</returns>
        ///// <br>Note       : 計上日のWHERE文を作成して返します。戻り値がfalseの場合はSELECT対象無しとみなします。</br>
        ///// <br>Programmer : 18023 樋口　政成</br>
        ///// <br>Date       : 2005.07.21</br>		
		//private bool MakeWhereStringAddUpdateNormal(SqlCommand sqlCommand, out string whereAddUpdate, SeiKingetParameter parameter)
		//{
		//	whereAddUpdate = string.Empty;
        //
		//	StringBuilder whereAddUpdateBuilder = new StringBuilder();
        //
		//	if (((parameter.StartAddUpYearMonth > 0) || (parameter.EndAddUpYearMonth > 0)) &&
		//		(parameter.StartAddUpYearMonth <= parameter.EndAddUpYearMonth))
		//	{
		//		if (parameter.StartAddUpYearMonth == parameter.EndAddUpYearMonth)
		//		{
		//			whereAddUpdateBuilder.Append(" AND CUSTDMDPRCRF.ADDUPYEARMONTHRF=@FINDADDUPYEARMONTH");
		//			SqlParameter paraStartAddUpYearMonth = sqlCommand.Parameters.Add("@FINDADDUPYEARMONTH", SqlDbType.Int);
		//			paraStartAddUpYearMonth.Value = SqlDataMediator.SqlSetInt32(parameter.StartAddUpYearMonth);
		//		}
		//		else
		//		{
		//			if (parameter.StartAddUpYearMonth > 0)
		//			{
		//				whereAddUpdateBuilder.Append(" AND CUSTDMDPRCRF.ADDUPYEARMONTHRF>=@FINDSTARTADDUPYEARMONTH");
		//				SqlParameter paraStartAddUpYearMonth = sqlCommand.Parameters.Add("@FINDSTARTADDUPYEARMONTH", SqlDbType.Int);
		//				paraStartAddUpYearMonth.Value = SqlDataMediator.SqlSetInt32(parameter.StartAddUpYearMonth);
		//			}
        //
		//			if (parameter.EndAddUpYearMonth > 0)
		//			{
		//				whereAddUpdateBuilder.Append(" AND CUSTDMDPRCRF.ADDUPYEARMONTHRF<=@FINDENDADDUPYEARMONTH");
		//				SqlParameter paraEndAddUpYearMonth = sqlCommand.Parameters.Add("@FINDENDADDUPYEARMONTH", SqlDbType.Int);
		//				paraEndAddUpYearMonth.Value = SqlDataMediator.SqlSetInt32(parameter.EndAddUpYearMonth);
		//			}
		//		}
		//	}
		//	else if (parameter.StartAddUpDate <= parameter.EndAddUpDate)
		//	{
		//		int startDate = TDateTime.DateTimeToLongDate("YYYYMMDD", parameter.StartAddUpDate);
		//		int endDate = TDateTime.DateTimeToLongDate("YYYYMMDD", parameter.EndAddUpDate);
		//		if (startDate == endDate)
		//		{
		//			whereAddUpdateBuilder.Append(" AND CUSTDMDPRCRF.ADDUPDATERF=@FINDADDUPDATE");
		//			SqlParameter paraAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int);
		//			paraAddUpDate.Value = SqlDataMediator.SqlSetInt32(startDate);
		//		}
		//		else
		//		{
		//			whereAddUpdateBuilder.Append(" AND CUSTDMDPRCRF.ADDUPDATERF>=@FINDSTARTADDUPDATE"
		//										+" AND CUSTDMDPRCRF.ADDUPDATERF<=@FINDENDADDUPDATE");
		//			SqlParameter paraStartAddUpDate = sqlCommand.Parameters.Add("@FINDSTARTADDUPDATE", SqlDbType.Int);
		//			paraStartAddUpDate.Value = SqlDataMediator.SqlSetInt32(startDate);
		//			SqlParameter paraEndAddUpDate = sqlCommand.Parameters.Add("@FINDENDADDUPDATE", SqlDbType.Int);
		//			paraEndAddUpDate.Value = SqlDataMediator.SqlSetInt32(endDate);
		//		}
		//	}
		//	else
		//	{
		//		return false;
		//	}
        //
		//	whereAddUpdate = whereAddUpdateBuilder.ToString();
        //
		//	return true;
        //}
        #endregion
        // ↑ 2007.12.21 980081 d

        // ↓ 2007.12.21 980081 d
        #region WHERE文作成（計上日）処理　＜※最終レコード取得時＞ 未使用のため削除
        ///// <summary>
        ///// WHERE文作成（計上日）処理　＜※最終レコード取得時＞
        ///// </summary>
        ///// <param name="sqlCommand">SqlCommand</param>
        ///// <param name="whereAddUpdate">計上日のWHERE文</param>
        ///// <param name="parameter">検索パラメータ</param>
        ///// <returns>true:正常取得,false:異常</returns>
        ///// <br>Note       : 計上日のWHERE文を作成して返します。戻り値がfalseの場合はSELECT対象無しとみなします。</br>
        ///// <br>Programmer : 18023 樋口　政成</br>
        ///// <br>Date       : 2005.07.21</br>		
		//private bool MakeWhereStringAddUpdateLastRecord(SqlCommand sqlCommand, out string whereAddUpdate, SeiKingetParameter parameter)
		//{
		//	whereAddUpdate = string.Empty;
        //
		//	StringBuilder whereAddUpdateBuilder = new StringBuilder();
        //
		//	if (((parameter.StartAddUpYearMonth > 0) || (parameter.EndAddUpYearMonth > 0)) &&
		//		(parameter.StartAddUpYearMonth <= parameter.EndAddUpYearMonth))
		//	{
		//		if (parameter.StartAddUpYearMonth > 0)
		//		{
		//			whereAddUpdateBuilder.Append(" AND CUSTDMDPRCRF.ADDUPYEARMONTHRF<@FINDADDUPYEARMONTH");
		//			SqlParameter paraAddUpYearMonth = sqlCommand.Parameters.Add("@FINDADDUPYEARMONTH", SqlDbType.Int);
		//			paraAddUpYearMonth.Value = SqlDataMediator.SqlSetInt32(parameter.StartAddUpYearMonth);
		//		}
		//	}
		//	else if (parameter.StartAddUpDate <= parameter.EndAddUpDate)
		//	{
		//		whereAddUpdateBuilder.Append(" AND CUSTDMDPRCRF.ADDUPDATERF<@FINDADDUPDATE");
		//		SqlParameter paraAddUpDate = sqlCommand.Parameters.Add("@FINDADDUPDATE", SqlDbType.Int);
		//		paraAddUpDate.Value = SqlDataMediator.SqlSetInt32(TDateTime.DateTimeToLongDate("YYYYMMDD", parameter.StartAddUpDate));
		//	}
		//	else
		//	{
		//		return false;
		//	}
        //
		//	whereAddUpdate = whereAddUpdateBuilder.ToString();
        //
		//	return true;
        //}
        #endregion
        // ↑ 2007.12.21 980081 d

        // ↓ 2007.12.21 980081 d
        #region WHERE文作成（締日）処理 未使用のため削除
        ///// <summary>
        ///// WHERE文作成（締日）処理
        ///// </summary>
        ///// <param name="sqlCommand">SqlCommand</param>
        ///// <param name="totalDay">締日</param>
        ///// <param name="startTotalDay">締日（開始）</param>
        ///// <param name="endTotalDay">締日（終了）</param>
        ///// <param name="tableName">テーブル名称</param>
        ///// <returns>作成したWHERE文</returns>
        ///// <br>Note       : 締日のWHERE文を作成して返します。</br>
        ///// <br>Programmer : 18023 樋口　政成</br>
        ///// <br>Date       : 2005.07.21</br>
		//private string MakeWhereStringTotalDay(SqlCommand sqlCommand, int totalDay, int startTotalDay, int endTotalDay, string tableName)
		//{
		//	StringBuilder whereTotalDay = new StringBuilder();
        //
		//	if (totalDay > 0)
		//	{
		//		whereTotalDay.Append(" AND " + tableName + ".TOTALDAYRF=@FINDTOTALDAY");
		//		SqlParameter paraTotalDay = sqlCommand.Parameters.Add("@FINDTOTALDAY", SqlDbType.Int);
		//		paraTotalDay.Value = SqlDataMediator.SqlSetInt32(totalDay);
		//	}
		//	else
		//	if ((startTotalDay > 0) || (endTotalDay > 0))
		//	{
		//		if (startTotalDay == endTotalDay)
		//		{
		//			whereTotalDay.Append(" AND " + tableName + ".TOTALDAYRF=@FINDTOTALDAY");
		//			SqlParameter paraTotalDay = sqlCommand.Parameters.Add("@FINDTOTALDAY", SqlDbType.Int);
		//			paraTotalDay.Value = SqlDataMediator.SqlSetInt32(startTotalDay);
		//		}
		//		else
		//		{
		//			if (startTotalDay > endTotalDay)
		//			{
		//				int workDay = startTotalDay;
		//				startTotalDay = endTotalDay;
		//				endTotalDay = workDay;
		//			}
        //
		//			whereTotalDay.Append(" AND " + tableName + ".TOTALDAYRF>=@FINDSTARTTOTALDAY AND " + tableName + ".TOTALDAYRF<=@FINDENDTOTALDAY");
		//			SqlParameter paraStartTotalDay = sqlCommand.Parameters.Add("@FINDSTARTTOTALDAY", SqlDbType.Int);
		//			paraStartTotalDay.Value = SqlDataMediator.SqlSetInt32(startTotalDay);
		//			SqlParameter paraEndTotalDay = sqlCommand.Parameters.Add("@FINDENDTOTALDAY", SqlDbType.Int);
		//			paraEndTotalDay.Value = SqlDataMediator.SqlSetInt32(endTotalDay);
		//		}
		//	}
        //
		//	return whereTotalDay.ToString();
        //}
        #endregion
        // ↑ 2007.12.21 980081 d

        // ↓ 2007.12.21 980081 d
        #region WHERE文作成（個人・法人区分）処理 未使用のため削除
        ///// <summary>
        ///// WHERE文作成（個人・法人区分）処理
        ///// </summary>
        ///// <param name="whereCorporateDivCode">作成した個人・法人区分のWHERE文</param>
        ///// <param name="corporateDivCodeList">個人・法人区分リスト</param>
        ///// <param name="isAllCorporateDivCode">全個人・法人区分選択</param>
        ///// <returns>true:SELECTを行う,false:SELECTを行わない</returns>
        ///// <br>Note       : 計上拠点のWHERE文を作成して返します。戻り値がfalseの場合はSELECT対象無しとみなします。</br>
        ///// <br>Programmer : 18023 樋口　政成</br>
        ///// <br>Date       : 2005.07.21</br>		
		//private bool MakeWhereStringCorporateDivCode(out string whereCorporateDivCode, ArrayList corporateDivCodeList, bool isAllCorporateDivCode)
		//{
		//	whereCorporateDivCode = "";
		//	
		//	if (!isAllCorporateDivCode)
		//	{
		//		if (corporateDivCodeList.Count == 1)
		//		{
		//			whereCorporateDivCode = " AND CUSTOMERRF.CORPORATEDIVCODERF=" + corporateDivCodeList[0].ToString();
		//		}
		//		else
		//		if (corporateDivCodeList.Count > 0)
		//		{
		//			StringBuilder whereDivCode = new StringBuilder(" AND CUSTOMERRF.CORPORATEDIVCODERF IN (");
		//			for (int ix = 0; ix < corporateDivCodeList.Count; ix++)
		//			{
		//				if (ix != 0)
		//				{
		//					whereDivCode.Append(",");
		//				}
		//				whereDivCode.Append(corporateDivCodeList[ix].ToString());
		//			}					
		//			whereDivCode.Append(")");
		//			whereCorporateDivCode = whereDivCode.ToString();
		//		}
		//		else
		//		{
		//			return false;
		//		}
		//	}			
		//	
		//	return true;
        //}
        #endregion
        // ↑ 2007.12.21 980081 d

        // ↓ 2007.12.21 980081 d
        #region WHERE文作成（得意先分析コード）処理 未使用のため削除
        ///// <summary>
        ///// WHERE文作成（得意先分析コード）処理
        ///// </summary>
        ///// <param name="sqlCommand">SqlCommand</param>
        ///// <param name="parameter">検索パラメータ</param>
        ///// <param name="tableName">テーブル名称</param>
        ///// <returns>作成したWHERE文</returns>
        ///// <br>Note       : 得意先分析コードのWHERE文を作成して返します。</br>
        ///// <br>Programmer : 18023 樋口　政成</br>
        ///// <br>Date       : 2006.09.06</br>		
		//private string MakeWhereStringCustAnalysCode(SqlCommand sqlCommand, SeiKingetParameter parameter, string tableName)
		//{
		//	StringBuilder whereCustAnalysCode = new StringBuilder();
        //
		//	whereCustAnalysCode.Append(this.MakeWhereStringAnalysCodeRange(tableName, "CUSTANALYSCODE1RF", parameter.StartCustAnalysCode1, parameter.EndCustAnalysCode1));
		//	whereCustAnalysCode.Append(this.MakeWhereStringAnalysCodeRange(tableName, "CUSTANALYSCODE2RF", parameter.StartCustAnalysCode2, parameter.EndCustAnalysCode2));
		//	whereCustAnalysCode.Append(this.MakeWhereStringAnalysCodeRange(tableName, "CUSTANALYSCODE3RF", parameter.StartCustAnalysCode3, parameter.EndCustAnalysCode3));
		//	whereCustAnalysCode.Append(this.MakeWhereStringAnalysCodeRange(tableName, "CUSTANALYSCODE4RF", parameter.StartCustAnalysCode4, parameter.EndCustAnalysCode4));
		//	whereCustAnalysCode.Append(this.MakeWhereStringAnalysCodeRange(tableName, "CUSTANALYSCODE5RF", parameter.StartCustAnalysCode5, parameter.EndCustAnalysCode5));
		//	whereCustAnalysCode.Append(this.MakeWhereStringAnalysCodeRange(tableName, "CUSTANALYSCODE6RF", parameter.StartCustAnalysCode6, parameter.EndCustAnalysCode6));
        //
		//	return whereCustAnalysCode.ToString();
        //}
        #endregion
        // ↑ 2007.12.21 980081 d

        // ↓ 2007.12.21 980081 d
        #region WHERE文作成（得意先・車両分析コード範囲） 未使用のため削除
        ///// <summary>
        ///// WHERE文作成（得意先・車両分析コード範囲）
        ///// </summary>
        ///// <param name="tableName">テーブル名称</param>
        ///// <param name="colName">対象項目名称</param>
        ///// <param name="start">条件開始値</param>
        ///// <param name="end">条件終了値</param>
        ///// <returns>作成したWHERE文</returns>
		//private string MakeWhereStringAnalysCodeRange(string tableName, string colName, int start, int end)
		//{
		//	string whereString = string.Empty;
		//	if (start == end)
		//	{
		//		whereString = string.Format(" AND {0}.{1}={2}", tableName, colName, start);
		//	}
		//	else
        //	{
        //		if (start != 0)	whereString += string.Format(" AND {0}.{1}>={2}", tableName, colName, start);
        //		if (end != 999)	whereString += string.Format(" AND {0}.{1}<={2}", tableName, colName, end);
        //	}
        //	return whereString;
        //}
        #endregion
        // ↑ 2007.12.21 980081 d

        // ↓ 2007.12.21 980081 d
        #region WHERE文作成（拠点コード）処理 未使用のため削除
        ///// <summary>
        ///// WHERE文作成（拠点コード）処理
        ///// </summary>
        ///// <param name="whereAddSecCode">作成した計上拠点のWHERE文</param>
        ///// <param name="addUpSecCodeList">計上拠点選択リスト</param>
        ///// <param name="isSelectAllSection">全社選択</param>
        ///// <param name="isOutputAllSecRec">全拠点レコード出力</param>
        ///// <param name="tableName">テーブル名称</param>
        ///// <param name="ddName">項目名称</param>
        ///// <returns>true:SELECTを行う,false:SELECTを行わない</returns>
        ///// <br>Note       : 計上拠点のWHERE文を作成して返します。戻り値がfalseの場合はSELECT対象無しとみなします。</br>
        ///// <br>Programmer : 18023 樋口　政成</br>
        ///// <br>Date       : 2005.07.21</br>		
		//private bool MakeWhereStringSectionCode(out string whereAddSecCode, ArrayList addUpSecCodeList, bool isSelectAllSection,
		//	bool isOutputAllSecRec, string tableName, string ddName)
		//{
		//	whereAddSecCode = "";
		//	
		//	StringBuilder whereSectionCode = new StringBuilder();
		//	if (isSelectAllSection)			
		//	{
		//		// 全拠点レコードを出力しない場合
		//		if (!isOutputAllSecRec)
		//		{
		//			whereSectionCode.Append(" AND " + tableName + "." + ddName + "<>'" + ALLSECCODE + "'");
		//		}
		//	}
		//	else
		//	{
		//		if (addUpSecCodeList.Count > 0)
		//		{
		//			if (addUpSecCodeList.Count == 1)
		//			{
		//				whereSectionCode.Append(" AND " + tableName + "." + ddName + " = '" + addUpSecCodeList[0] + "'");
		//			}
		//			else
		//			{
		//				whereSectionCode.Append(" AND " + tableName + "." + ddName + " IN (");
		//				for (int ix = 0; ix < addUpSecCodeList.Count; ix++)
		//				{
		//					if (ix == 0)
		//					{
		//						// 全拠点レコードを出力する場合
		//						if (isOutputAllSecRec)
		//						{
		//							whereSectionCode.Append("'" + ALLSECCODE + "'");
		//							if ((string)addUpSecCodeList[ix] == ALLSECCODE)
		//							{
		//								continue;
		//							}
		//							whereSectionCode.Append(",");
		//						}
		//					}
		//					else
		//					{
		//						// 全拠点レコード出力＝true 且つ 拠点リストに全拠点コードが存在する場合
		//						if ((isOutputAllSecRec) && ((string)addUpSecCodeList[ix] == ALLSECCODE))
		//						{
		//							continue;
		//						}
		//						whereSectionCode.Append(",");
		//					}
		//					
		//					whereSectionCode.Append("'" + addUpSecCodeList[ix] + "'");
		//				}
		//				whereSectionCode.Append(")");
		//			}
		//		}
		//		else
		//		{
		//			// 全拠点レコードを出力する場合
		//			if (isOutputAllSecRec)
		//			{
		//				whereSectionCode.Append(" AND " + tableName + "." + ddName + "='" + ALLSECCODE + "'");
		//			}
		//			else
		//			{
		//				return false;
		//			}
		//		}
		//	}
		//	
		//	whereAddSecCode = whereSectionCode.ToString();
		//	return true;
        //}
        #endregion
        // ↑ 2007.12.21 980081 d

        // ↓ 2007.12.21 980081 d
        #region 請求金額情報リスト格納処理 未使用のため削除
        ///// <summary>
        ///// 請求金額情報リスト格納処理
        ///// </summary>
        ///// <param name="status">ステータス</param>
        ///// <param name="addSecCodeSortedList">格納用ソートリスト</param>
        ///// <param name="myReader">SQLDataReader</param>
        ///// <br>Note       : SQLDataReaderの情報を請求金額情報格納用ソートリストにセットします。</br>
        ///// <br>Programmer : 18023 樋口　政成</br>
        ///// <br>Date       : 2005.07.21</br>		
		//private void SetListFromSQLReader(ref int status, ref SortedList addSecCodeSortedList, SqlDataReader myReader)
		//{
		//	if (addSecCodeSortedList == null)
		//	{
		//		addSecCodeSortedList = new SortedList();
		//	}
		//	
		//	string addUpSecCode;
		//	int customerCode;
		//	int addUpDate;
		//		
		//	while (myReader.Read())
		//	{
		//		addUpSecCode	= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("ADDUPSECCODERF"	));
		//		customerCode	= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("CUSTOMERCODERF"	));
		//		addUpDate		= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("ADDUPDATERF"	));
		//			
		//		// 計上拠点リスト既存チェック
		//		if (!addSecCodeSortedList.Contains(addUpSecCode))
		//		{
		//			SortedList list1 = new SortedList();
		//			addSecCodeSortedList.Add(addUpSecCode, list1);
		//		}
		//			
		//		SortedList customerCodeList = (SortedList)addSecCodeSortedList[addUpSecCode];
        //
		//		// 計上拠点->得意先リスト既存チェック
		//		if (!customerCodeList.Contains(customerCode))
		//		{
		//			SortedList list2 = new SortedList();
		//			customerCodeList.Add(customerCode, list2);
		//		}
		//			
		//		SortedList addUpDateList = (SortedList)customerCodeList[customerCode];
        //
		//		KingetCustDmdPrcWork wkCustDmdPrcWork = null;
		//			
		//		// 計上拠点->得意先->計上日付リスト既存チェック
		//		if (!addUpDateList.Contains(addUpDate))
		//		{
		//			wkCustDmdPrcWork = new KingetCustDmdPrcWork();
		//			this.CopyToDataClassFromSelectData(ref wkCustDmdPrcWork, myReader);
		//			addUpDateList.Add(addUpDate, wkCustDmdPrcWork);
		//		}
		//		else
		//		{
        //			wkCustDmdPrcWork = (KingetCustDmdPrcWork)customerCodeList[addUpDate];
        //			this.CopyToDataClassFromSelectData(ref wkCustDmdPrcWork , myReader);
        //		}
        //		status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //	}
        //}
        #endregion
        // ↑ 2007.12.21 980081 d
        
		/// <summary>
		/// コネクション文字列取得処理
		/// </summary>
		/// <returns>コネクション文字列</returns>
		/// <br>Note       : コネクション文字列を取得して返します。</br>
		/// <br>Programmer : 18023 樋口　政成</br>
		/// <br>Date       : 2005.07.21</br>
		private string GetConnectionText()
		{
			//メソッド開始時にコネクション文字列を取得(SFCMN00615Cの定義からユーザーDB[IndexCode_UserDB]を指定してコネクション文字列を取得)
			SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
			string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
			if (connectionText == null) connectionText = "";
			return connectionText;
		}

        // ↓ 2007.12.21 980081 d
        #region オプション有無確認処理 未使用のため削除
        ///// <summary>
		///// オプション有無確認処理
		///// </summary>
		///// <param name="softwareCode">コード</param>
		///// <returns>true:有り,false:無し</returns>
		///// <br>Note       : 指定のソフトウェアコードのオプションが存在するかどうかを確認します。</br>
		///// <br>Programmer : 18023 樋口　政成</br>
		///// <br>Date       : 2006.02.21</br>		
		//private	bool CheckSoftwarePurchased(string softwareCode)
		//{
		//	bool exists = false;
		//	ServerLoginInfoAcquisition loginInfo = new ServerLoginInfoAcquisition();
		//	if ((int)loginInfo.SoftwarePurchasedCheckForCompany(softwareCode) > 0) exists = true;
		//	return exists;
        //}
        #endregion
        // ↑ 2007.12.21 980081 d

        // ↓ 20070417 18322 d 未使用の為削除
        #region 仮想請求鑑生成処理（全てコメントアウト）
        ///// <summary>
		///// 仮想請求鑑生成処理
		///// </summary>
		///// <param name="addSecCodeSortedList">請求金額情報格納用ソートリスト</param>
		///// <param name="sqlConnection">SQLConnection</param>
		///// <param name="totalDayScheduleSortedList">締日スケジュール格納用ソートリスト</param>
		///// <param name="customerScheduleSortedList">得意先スケジュール格納用ソートリスト</param>
		///// <param name="parameter">検索パラメータ</param>
		///// <param name="kingetData">請求KINGETデータ格納クラス</param>
		///// <returns>STATUS</returns>
		///// <br>Note       : スケジュール格納用ソートリストを元に仮想請求鑑を生成して請求金額情報格納用ソートリストにセットします。</br>
		///// <br>Programmer : 18023 樋口　政成</br>
		///// <br>Date       : 2005.07.21</br>		
		//private int CreateVirtualCustDmdPrc(ref SortedList addSecCodeSortedList, SqlConnection sqlConnection,
		//	SortedList totalDayScheduleSortedList, SortedList customerScheduleSortedList, SeiKingetParameter parameter, ref SeiKingetData kingetData)
		//{
		//	int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
		//	
		//	if (addSecCodeSortedList.Count == 0) return status;
		//
        //    // ↓ 20070117 18322 d
        //    #region MA.NSではKINSETクラスを使用しなくてもよさげなので削除
        //    //// KINSETクラス
		//	//Kinset kinset = new Kinset();
		//	//
		//	//// 諸費用別入金オプション有無確認
		//	//if (this.CheckSoftwarePurchased(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SeparatePayment))
		//	//{
		//	//	kinset.SetMode = 1;
        //    //}
        //    #endregion
        //    // ↑ 20070117 18322 d
		//
		//	int startDate;
		//	int endDate;
		//	
		//	// 計上拠点
		//	foreach (DictionaryEntry addSecCode in addSecCodeSortedList)
		//	{
		//		// 得意先コード
		//		foreach (DictionaryEntry customerCode in (SortedList)addSecCode.Value)
		//		{
		//			SortedList addUpDateList = (SortedList)customerCode.Value;
		//			int addUpDate = (int)addUpDateList.GetKey(addUpDateList.Count-1);
		//			int addUpYearMonth;
		//			
		//			KingetCustDmdPrcWork current = ((KingetCustDmdPrcWork)addUpDateList[addUpDate]).Clone();
		//			
		//			SortedList scheduleDateList;
		//			
		//			// 得意先スケジュールが存在する場合
		//			if (customerScheduleSortedList.Contains(current.CustomerCode))
		//			{
		//				// 抽出日付範囲取得(得意先スケジュールベース)
		//				if (!this.GetDateSpanFromCustomerSchedule(out startDate, out endDate, current.CustomerCode, customerScheduleSortedList, parameter))
		//				{
		//					break;
		//				}
		//				// スケジュール計上日付リストを取得
		//				scheduleDateList = (SortedList)customerScheduleSortedList[current.CustomerCode];
		//			}
		//			else
		//			{
		//				// 抽出日付範囲取得(締日スケジュールベース)
		//				if (!this.GetDateSpanFromTotalDaySchedule(out startDate, out endDate, current.TotalDay, totalDayScheduleSortedList, parameter))
		//				{
		//					break;
		//				}
		//				// スケジュール計上日付リストを取得
		//				scheduleDateList = (SortedList)totalDayScheduleSortedList[current.TotalDay];
		//			}
		//			
		//			// 計上日付≦終了日の場合、仮想請求鑑を作成する
		//			while (addUpDate <= endDate)
		//			{
		//				// スケジュールリストより次回計上日付を取得
		//				int index = scheduleDateList.IndexOfKey(addUpDate);
		//				index++;
		//				if (index >= scheduleDateList.Count)
		//				{
		//					break;
		//				}
		//				addUpDate		= (int)scheduleDateList.GetKey(index);
		//				addUpYearMonth	= TDateTime.DateTimeToLongDate("YYYYMM", ((RetAddUpDateItemTypeDInf)scheduleDateList.GetByIndex(index)).CAddUpUpdYearMonth);
		//				
		//				// 諸費用残高調整区分が取得されていない場合
		//				if (kingetData.MinusVarCstBlAdjstCd == -1)
		//				{
		//					int minusVarCstBlAdjstCd = -1;
		//					int bfRmonCalcDivCd		 = -1;	// 2006.05.31 ADD 樋口　政成
		//
		//					// 諸費用残高調整区分取得
		//					#region 2006.05.31 DEL 樋口　政成
		//					//status = ReadBillAllSt(ref minusVarCstBlAdjstCd, sqlConnection, parameter.EnterpriseCode);
		//					#endregion
		//					status = ReadBillAllSt(ref minusVarCstBlAdjstCd, ref bfRmonCalcDivCd, sqlConnection, parameter.EnterpriseCode);	// 2006.05.31 ADD 樋口　政成
		//					if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
		//					{
		//						if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
		//						{
		//							base.WriteErrorLog(null,"プログラムエラー。請求設定マスタが登録されていません");
		//						}
		//						return status;
		//					}
		//
		//					kingetData.MinusVarCstBlAdjstCd	= minusVarCstBlAdjstCd;
		//					kingetData.BfRmonCalcDivCd		= bfRmonCalcDivCd;		// 2006.05.31 ADD 樋口　政成
		//					
		//					if (kingetData.MinusVarCstBlAdjstCd != 0){kingetData.AdjustMinusVCst = true;}
		//				}
		//
        //                // ↓ 20070117 18322 c MA.NS用に変更
        //                #region SF KINSETを通して次回の仮想鑑を作成(コメントアウト)
        //                //// KINSETを通して次回の仮想鑑を作成
		//				//#region 2006.05.31 DEL 樋口　政成
		//				////current = this.GetVirtualCustDmdPrc(ref kinset, current, addUpDate, addUpYearMonth, kingetData.AdjustMinusVCst);
		//				//#endregion
        //                //current = this.GetVirtualCustDmdPrc(ref kinset, current, addUpDate, addUpYearMonth, kingetData);	// 2006.05.31 ADD 樋口　政成
        //                #endregion
		//
        //                // 次回の仮想鑑を作成
        //                current = this.GetVirtualCustDmdPrc(current, addUpDate, addUpYearMonth, kingetData);
        //                // ↑ 20070117 18322 c 
		//				
		//				// 開始日≦次回計上日付≦終了日の場合、仮想の請求金額情報を格納する
		//				if ((addUpDate >= startDate) && (addUpDate <= endDate))
		//				{
		//					if (!addUpDateList.Contains(addUpDate))
		//					{
		//						addUpDateList.Add(addUpDate, current.Clone());
		//					}
		//				}
		//			}
		//		}
		//	}
		//	return status;
		//}
        #endregion
        // ↑ 20070417 18322 d

        // ↓ 2007.12.21 980081 d
        #region 請求全体設定読込み処理 未使用のため削除
        ///// <summary>
        ///// 請求全体設定読込み処理
        ///// </summary>
        ///// <param name="minusVarCstBlAdjstCd">諸費用残高調整区分</param>
        ///// <param name="bfRmonCalcDivCd">前受金算定区分</param>
        ///// <param name="sqlConnection">SQLConnection</param>
        ///// <param name="enterpriseCode">企業コード</param>
        ///// <returns>STATUS</returns>
        ///// <remarks>
        ///// <br>Note       : 指定企業コードの請求設定を読み込み、諸費用残高調整区分を返します。</br>
        ///// <br>Programmer : 18023 樋口　政成</br>
        ///// <br>Date       : 2005.07.21</br>
        ///// </remarks>
		//#region 2006.05.31 DEL 樋口　政成
		////private int ReadBillAllSt(ref int minusVarCstBlAdjstCd, SqlConnection sqlConnection, string enterpriseCode)
		//#endregion
		//private int ReadBillAllSt(ref int minusVarCstBlAdjstCd, ref int bfRmonCalcDivCd, SqlConnection sqlConnection, string enterpriseCode)	// 2006.05.31 ADD 樋口　政成
		//{
		//	int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
		//	
		//	using (SqlCommand sqlCommand = new SqlCommand("SELECT"
		//		+" MINUSVARCSTBLADJSTCDRF"
		//		+",BFRMONCALCDIVCDRF"		// 2006.05.31 ADD 樋口　政成
		//		+" FROM BILLALLSTRF"
		//		+" WHERE ENTERPRISECODERF=@FINDENTERPRISECODE AND BILLALLSTCDRF=0"
		//		, sqlConnection))
		//	{
		//		SqlParameter findParaEnterpriseCode = sqlCommand.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);
		//		findParaEnterpriseCode.Value = SqlDataMediator.SqlSetString(enterpriseCode);
        //
		//		using (SqlDataReader myReader = sqlCommand.ExecuteReader())
		//		{
		//			try
		//			{
		//				if (myReader.Read())
		//				{
		//					minusVarCstBlAdjstCd	= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MINUSVARCSTBLADJSTCDRF"));
		//					bfRmonCalcDivCd			= SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BFRMONCALCDIVCDRF"		));	// 2006.05.31 ADD 樋口　政成
		//					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
		//				}
		//			}
		//			finally
		//			{
		//				if (myReader != null) myReader.Close();
		//			}
		//		}
		//	}
        //
		//	return status;
        //}
        #endregion
        // ↑ 2007.12.21 980081 d

        // ↓ 20070417 18322 d 未使用の為削除
        #region 残高０レコード作成処理（全てコメントアウト）
		///// <summary>
		///// 残高０レコード作成処理
		///// </summary>
		///// <param name="addSecCodeSortedList">請求金額情報格納用ソートリスト</param>
		///// <param name="sqlConnection">SQLConnection</param>
		///// <param name="totalDayScheduleSortedList">締日スケジュール格納用ソートリスト</param>
		///// <param name="customerScheduleSortedList">得意先スケジュール格納用ソートリスト</param>
		///// <param name="parameter">検索パラメータ</param>
		///// <br>Note       : 残高０の得意先を対象としてスケジュール格納用ソートリストを元に仮想請求鑑を生成して
		/////					 請求金額情報格納用ソートリストにセットします。</br>
		///// <br>Programmer : 18023 樋口　政成</br>
		///// <br>Date       : 2005.07.21</br>		
		//private void MakeZeroCustomer(ref SortedList addSecCodeSortedList, SqlConnection sqlConnection, SortedList totalDayScheduleSortedList,
		//	SortedList customerScheduleSortedList, SeiKingetParameter parameter)
		//{
		//	// 拠点情報取得
		//	SortedList sectionCodeList;
		//	int status = this.SearchSection(out sectionCodeList, sqlConnection, parameter);
		//	
		//	if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) ||
		//		(status == (int)ConstantManagement.DB_Status.ctDB_EOF))
		//	{
		//		// 全拠点レコード出力＝trueの場合は、全拠点コード分もレコードを作成
		//		if (parameter.IsOutputAllSecRec)
		//		{
		//			if (!sectionCodeList.Contains(ALLSECCODE))
		//			{
		//				sectionCodeList.Add(ALLSECCODE, null);
		//				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
		//			}
		//		}
		//	}
		//	
		//	if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
		//	{
		//		return;
		//	}
		//	
		//	
		//	// 得意先情報取得
		//	Hashtable customerTable;
		//	status = this.SearchCustomer(out customerTable, sqlConnection, parameter);
		//	if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
		//	{
		//		return;
		//	}
		//	
		//	// 拠点情報でループ
		//	foreach (DictionaryEntry de1 in sectionCodeList)
		//	{
		//		// 拠点コードが無い場合は追加
		//		string sectionCode = (string)de1.Key;
		//		if (!addSecCodeSortedList.Contains(sectionCode))
		//		{
		//			addSecCodeSortedList.Add(sectionCode, new SortedList());
		//		}
		//		
		//		SortedList setCustomerList = (SortedList)addSecCodeSortedList[sectionCode];
		//		
		//		// 得意先情報でループ
		//		foreach (DictionaryEntry de2 in customerTable)
		//		{
		//			int customerCode = (int)de2.Key;
		//			KingetCustDmdPrcWork current = ((KingetCustDmdPrcWork)de2.Value).Clone();
		//			
		//			if (current.TotalDay <= 0)
		//			{
		//				continue;
		//			}
		//			
		//			// 得意先コードが無い場合は追加
		//			if (!setCustomerList.Contains(customerCode))
		//			{
		//				setCustomerList.Add(customerCode, new SortedList());
		//			}
		//			
		//			SortedList addUpDateList = (SortedList)setCustomerList[customerCode];
		//			
		//			int startDate, endDate;
		//			SortedList scheduleDateList;
		//			
		//			// 得意先スケジュールが存在する場合
		//			if (customerScheduleSortedList.Contains(customerCode))
		//			{
		//				// 抽出日付範囲取得(得意先スケジュールベース)
		//				if (!this.GetDateSpanFromCustomerSchedule(out startDate, out endDate, customerCode, customerScheduleSortedList, parameter))
		//				{
		//					break;
		//				}
		//				// スケジュール計上日付リストを取得
		//				scheduleDateList = (SortedList)customerScheduleSortedList[customerCode];
		//			}
		//			else
		//			{
		//				// 抽出日付範囲取得(締日スケジュールベース)
		//				if (!this.GetDateSpanFromTotalDaySchedule(out startDate, out endDate, current.TotalDay, totalDayScheduleSortedList, parameter))
		//				{
		//					break;
		//				}
		//				// スケジュール計上日付リストを取得
		//				scheduleDateList = (SortedList)totalDayScheduleSortedList[current.TotalDay];
		//			}
		//			
		//			int addUpDate = startDate;
		//			
		//			// 計上日付≦終了日の場合、仮想請求鑑を作成する
		//			while (addUpDate <= endDate)
		//			{
		//				// 開始日≦次回計上日付≦終了日の場合、仮想の請求金額情報を格納する
		//				if ((addUpDate >= startDate) && (addUpDate <= endDate))
		//				{
		//					if (!addUpDateList.Contains(addUpDate))
		//					{
		//						// スケジュールリストより該当計上日付のデータを取得
		//						RetAddUpDateItemTypeDInf retAddUpDateItemTypeDInf = (RetAddUpDateItemTypeDInf)scheduleDateList[addUpDate];
		//						current.AddUpSecCode	= sectionCode;
		//						current.CustomerCode	= customerCode;
		//						current.AddUpDate		= retAddUpDateItemTypeDInf.CAddUpUpdDate;
		//
        //                        // ↓ 20070117 18322 c MA.NS用に変更
		//						//current.AddUpYearMonth	= TDateTime.DateTimeToLongDate("YYYYMM", retAddUpDateItemTypeDInf.CAddUpUpdYearMonth);
		//
        //                        current.AddUpYearMonth = retAddUpDateItemTypeDInf.CAddUpUpdYearMonth;
        //                        // ↑ 20070117 18322 c
		//						
		//						addUpDateList.Add(addUpDate, current.Clone());
		//					}
		//				}
		//				
		//				// スケジュールリストより次回計上日付を取得
		//				int index = scheduleDateList.IndexOfKey(addUpDate);
		//				index++;
		//				if (index >= scheduleDateList.Count)
		//				{
		//					break;
		//				}
		//				addUpDate = (int)scheduleDateList.GetKey(index);
		//			}
		//		}
		//	}
        //}
        #endregion
        // ↑ 20070417 18322 d


        // ↓ 20070117 18322 c MA.NS用に変更
        #region SF 仮想請求鑑生成処理インターフェース(コメントアウト)
        ///// <summary>
		///// 仮想請求鑑生成処理
		///// </summary>
		///// <param name="kinset">KINSETクラス</param>
		///// <param name="wkCustDmdPrcWork">算定元請求金額情報</param>
		///// <param name="addUpDate">計上日付</param>
		///// <param name="addUpYearMonth">計上年月</param>
		///// <param name="kingetData">諸費用残高調整区分</param>
		///// <br>Note       : スケジュール格納用ソートリストを元に仮想請求鑑を生成して請求金額情報格納用ソートリストにセットします。</br>
		///// <br>Programmer : 18023 樋口　政成</br>
		///// <br>Date       : 2005.07.21</br>
		//#region 2006.05.31 DEL 樋口　政成
		////private KingetCustDmdPrcWork GetVirtualCustDmdPrc(ref Kinset kinset, KingetCustDmdPrcWork wkCustDmdPrcWork,
		////    Int32 addUpDate, Int32 addUpYearMonth, bool adjustMinusVCst)
		//#endregion
		//private KingetCustDmdPrcWork GetVirtualCustDmdPrc(ref Kinset kinset, KingetCustDmdPrcWork wkCustDmdPrcWork,
		//	Int32 addUpDate, Int32 addUpYearMonth, SeiKingetData kingetData)			// 2006.05.31 ADD 樋口　政成
        #endregion

        // ↓ 2007.12.21 980081 d
        #region 仮想請求鑑生成処理 未使用のため削除
        ///// <summary>
        ///// 仮想請求鑑生成処理
        ///// </summary>
        ///// <param name="wkCustDmdPrcWork">算定元請求金額情報</param>
        ///// <param name="addUpDate">計上日付</param>
        ///// <param name="addUpYearMonth">計上年月</param>
        ///// <param name="kingetData">諸費用残高調整区分</param>
        ///// <br>Note       : スケジュール格納用ソートリストを元に仮想請求鑑を生成して請求金額情報格納用ソートリストにセットします。</br>
        ///// <br>Programmer : 18023 樋口　政成</br>
        ///// <br>Date       : 2005.07.21</br>
		//private KingetCustDmdPrcWork GetVirtualCustDmdPrc(KingetCustDmdPrcWork wkCustDmdPrcWork,
        //    			                                  Int32 addUpDate,
        //                                                  Int32 addUpYearMonth,
        //                                                  SeiKingetData kingetData)
        //// ↑ 20070117 18322 c
        //{
        //    // ↓ 20070117 18322 c MA.NS用に変更
        //    #region SF 仮想請求鑑生成処理（全てコメントアウト）
        //    //kinset.Clear();
		//	//kinset.AcpOdrTtlLMBl	= wkCustDmdPrcWork.AfCalTtlAOdrBlDmd;
		//	//kinset.TtlLMVarCstBlnce	= wkCustDmdPrcWork.AfCalTtlVCstBlDmd;
		//	//#region 2006.05.31 DEL 樋口　政成
		//	////kinset.AdjustMinusVCst	= adjustMinusVCst;
		//	//#endregion
		//	//// 2006.05.31 ADD START 樋口　政成
		//	//kinset.AdjustMinusVCst	= kingetData.AdjustMinusVCst;
		//	//kinset.CalcMode			= kingetData.BfRmonCalcDivCd;
		//	//// 2006.05.31 ADD END 樋口　政成
		//	//
		//	//kinset.Calculate();
		//	//
		//	//KingetCustDmdPrcWork kingetCustDmdPrcWork = wkCustDmdPrcWork.Clone();
		//	//
		//	//kingetCustDmdPrcWork.AddUpDate				= TDateTime.LongDateToDateTime("YYYYMMDD", addUpDate);
        //    //kingetCustDmdPrcWork.AddUpYearMonth         = addUpYearMonth;
		//	//
		//	//kingetCustDmdPrcWork.TleDmdSlipLgCt			= 0;
		//	//kingetCustDmdPrcWork.TleDmdSlipGeCt			= 0;
		//	//kingetCustDmdPrcWork.TleDmdDebitNoteLgCt	= 0;
		//	//kingetCustDmdPrcWork.TleDmdDebitNoteGeCt	= 0;
		//	//kingetCustDmdPrcWork.TleDmdSlipLgCnt		= 0;
		//	//kingetCustDmdPrcWork.TleDmdSlipGeCnt		= 0;
		//	//kingetCustDmdPrcWork.TleDmdDebitNoteLgCnt	= 0;
		//	//kingetCustDmdPrcWork.TleDmdDebitNoteGeCnt	= 0;
		//	//kingetCustDmdPrcWork.AcpOdrTtlSalesDmd		= 0;
		//	//kingetCustDmdPrcWork.AcpOdrDiscTtlDmd		= 0;
		//	//kingetCustDmdPrcWork.AcpOdrTtlConsTaxDmd	= 0;
		//	//kingetCustDmdPrcWork.DmdVarCst				= 0;
		//	//kingetCustDmdPrcWork.TtlTaxtinDmdVarCst		= 0;
		//	//kingetCustDmdPrcWork.TtlTaxFreeDmdVarCst	= 0;
		//	//kingetCustDmdPrcWork.VarCst1TotalDemand		= 0;
		//	//kingetCustDmdPrcWork.VarCst2TotalDemand		= 0;
		//	//kingetCustDmdPrcWork.VarCst3TotalDemand		= 0;
		//	//kingetCustDmdPrcWork.VarCst4TotalDemand		= 0;
		//	//kingetCustDmdPrcWork.VarCst5TotalDemand		= 0;
		//	//kingetCustDmdPrcWork.VarCst6TotalDemand		= 0;
		//	//kingetCustDmdPrcWork.VarCst7TotalDemand		= 0;
		//	//kingetCustDmdPrcWork.VarCst8TotalDemand		= 0;
		//	//kingetCustDmdPrcWork.VarCst9TotalDemand		= 0;
		//	//kingetCustDmdPrcWork.VarCst10TotalDemand	= 0;
		//	//kingetCustDmdPrcWork.VarCst11TotalDemand	= 0;
		//	//kingetCustDmdPrcWork.VarCst12TotalDemand	= 0;
		//	//kingetCustDmdPrcWork.VarCst13TotalDemand	= 0;
		//	//kingetCustDmdPrcWork.VarCst14TotalDemand	= 0;
		//	//kingetCustDmdPrcWork.VarCst15TotalDemand	= 0;
		//	//kingetCustDmdPrcWork.VarCst16TotalDemand	= 0;
		//	//kingetCustDmdPrcWork.VarCst17TotalDemand	= 0;
		//	//kingetCustDmdPrcWork.VarCst18TotalDemand	= 0;
		//	//kingetCustDmdPrcWork.VarCst19TotalDemand	= 0;
		//	//kingetCustDmdPrcWork.VarCst20TotalDemand	= 0;
		//	//kingetCustDmdPrcWork.TtlDmdVarCstConsTax	= 0;
		//	//
		//	//kingetCustDmdPrcWork.AcpOdrTtlLMBlDmd		= kinset.AcpOdrTtlLMBl		;
		//	//kingetCustDmdPrcWork.TtlLMVarCstDmdBlnce	= kinset.TtlLMVarCstBlnce	;
		//	//
		//	//kingetCustDmdPrcWork.BfCalTtlAOdrDepoDmd	= 0;
		//	//kingetCustDmdPrcWork.BfCalTtlAOdrDpDsDmd	= 0;
		//	//kingetCustDmdPrcWork.BfCalTtlAOdrDpDmd		= 0;
		//	//kingetCustDmdPrcWork.BfCalTtlAOdrDsDmd		= 0;
		//	//
		//	//kingetCustDmdPrcWork.AfCalTtlAOdrDepoDmd	= kinset.AfCalTtlAOdrDepo	;
		//	//kingetCustDmdPrcWork.AfCalTtlVCstDepoDmd	= kinset.AfCalTtlVCstDepo	;
		//	//kingetCustDmdPrcWork.AfCalTtlAOdrDpDsDmd	= kinset.AfCalTtlAOdrDpDs	;
		//	//kingetCustDmdPrcWork.AfCalTtlVCstDpDsDmd	= kinset.AfCalTtlVCstDpDs	;
		//	//kingetCustDmdPrcWork.AfCalTtlAOdrBlCFDmd	= kinset.AfCalTtlAOdrBlCF	;
		//	//kingetCustDmdPrcWork.AfCalTtlVCstBlCFDmd	= kinset.AfCalTtlVCstBlCF	;
		//	//kingetCustDmdPrcWork.AcpOdrTtlSalesDmd		= kinset.AcpOdrTtlSales		;
		//	//kingetCustDmdPrcWork.DmdVarCst				= kinset.TtlVarCst			;
		//	//kingetCustDmdPrcWork.AcpOdrTtlConsTaxDmd	= kinset.AcpOdrTtlConsTax	;
		//	//kingetCustDmdPrcWork.TtlDmdVarCstConsTax	= kinset.TtlVarCstConsTax	;
		//	//kingetCustDmdPrcWork.AfCalTtlAOdrRMDmd		= kinset.AfCalTtlAOdrRM		;
		//	//kingetCustDmdPrcWork.AfCalTtlVCstBfRMDmd	= kinset.AfCalTtlVCstBfRM	;
		//	//kingetCustDmdPrcWork.AfCalTtlAOdrRMDsDmd	= kinset.AfCalTtlAOdrRMDs	;
		//	//kingetCustDmdPrcWork.AfCalTtlVCstRMDsDmd	= kinset.AfCalTtlVCstRMDs	;
		//	//kingetCustDmdPrcWork.AfCalTtlAOdrBlDmd		= kinset.AfCalTtlAOdrBl		;
		//	//kingetCustDmdPrcWork.AfCalTtlVCstBlDmd		= kinset.AfCalTtlVCstBl		;
		//	//kingetCustDmdPrcWork.AfCalDemandPrice		= kinset.AfCalPrice			;
		//	//
		//	//kingetCustDmdPrcWork.AcpOdrTtl2TmBfBlDmd	= wkCustDmdPrcWork.AcpOdrTtlLMBlDmd		;
		//	//kingetCustDmdPrcWork.Ttl2TmBfVarCstDmdBl	= wkCustDmdPrcWork.TtlLMVarCstDmdBlnce	;
		//	//kingetCustDmdPrcWork.AcpOdrTtl3TmBfBlDmd	= wkCustDmdPrcWork.AcpOdrTtl2TmBfBlDmd	;
		//	//kingetCustDmdPrcWork.Ttl3TmBfVarCstDmdBl	= wkCustDmdPrcWork.Ttl2TmBfVarCstDmdBl;
        //    #endregion
        ////
        ////    #region MA.NS 仮想請求鑑生成処理
        //    KingetCustDmdPrcWork kingetCustDmdPrcWork = wkCustDmdPrcWork.Clone();
        //
        //    // 計上年月日
        //    kingetCustDmdPrcWork.AddUpDate = TDateTime.LongDateToDateTime("YYYYMMDD", addUpDate);
        //    // 計上年月
        //    kingetCustDmdPrcWork.AddUpYearMonth = TDateTime.LongDateToDateTime("YYYYMM", addUpYearMonth); ;
        //    // 前回請求金額
        //    kingetCustDmdPrcWork.LastTimeDemand = wkCustDmdPrcWork.AfCalDemandPrice;
        //
        //    // 今回入金金額（通常入金）
        //    kingetCustDmdPrcWork.ThisTimeDmdNrml = 0;
        //    // 今回手数料額（通常入金）
        //    kingetCustDmdPrcWork.ThisTimeFeeDmdNrml = 0;
        //    // 今回値引額（通常入金）
        //    kingetCustDmdPrcWork.ThisTimeDisDmdNrml = 0;
        //    // 今回リベート額（通常入金）
        //    kingetCustDmdPrcWork.ThisTimeRbtDmdNrml = 0;
        //    // 今回入金金額（預り金）
        //    kingetCustDmdPrcWork.ThisTimeDmdDepo = 0;
        //    // 今回手数料額（預り金）
        //    kingetCustDmdPrcWork.ThisTimeFeeDmdDepo = 0;
        //    // 今回値引額（預り金）
        //    kingetCustDmdPrcWork.ThisTimeDisDmdDepo = 0;
        //    // 今回リベート額（預り金）
        //    kingetCustDmdPrcWork.ThisTimeRbtDmdDepo = 0;
        //    // 今回繰越残高（請求計）
        //    kingetCustDmdPrcWork.ThisTimeTtlBlcDmd = 0;
        //    // 今回売上金額
        //    kingetCustDmdPrcWork.ThisTimeSales = 0;
        //    // 今回売上消費税
        //    kingetCustDmdPrcWork.ThisSalesTax = 0;
        //    // 支払インセンティブ額合計（税抜き）
        //    kingetCustDmdPrcWork.TtlIncDtbtTaxExc = 0;
        //    // 支払インセンティブ額合計（税）
        //    kingetCustDmdPrcWork.TtlIncDtbtTax = 0;
        //    // 相殺後今回売上金額
        //    kingetCustDmdPrcWork.OfsThisTimeSales = 0;
        //    // 相殺後今回売上消費税
        //    kingetCustDmdPrcWork.OfsThisSalesTax = 0;
        //    // 相殺後外税対象額
        //    kingetCustDmdPrcWork.ItdedOffsetOutTax = 0;
        //    // 相殺後内税対象額
        //    kingetCustDmdPrcWork.ItdedOffsetInTax = 0;
        //    // 相殺後非課税対象額
        //    kingetCustDmdPrcWork.ItdedOffsetTaxFree = 0;
        //    // 相殺後外税消費税
        //    kingetCustDmdPrcWork.OffsetOutTax = 0;
        //    // 相殺後内税消費税
        //    kingetCustDmdPrcWork.OffsetInTax = 0;
        //    // 売上外税対象額
        //    kingetCustDmdPrcWork.ItdedSalesOutTax = 0;
        //    // 売上内税対象額
        //    kingetCustDmdPrcWork.ItdedSalesInTax = 0;
        //    // 売上非課税対象額
        //    kingetCustDmdPrcWork.ItdedSalesTaxFree = 0;
        //    // 売上外税額
        //    kingetCustDmdPrcWork.SalesOutTax = 0;
        //    // 売上内税額
        //    kingetCustDmdPrcWork.SalesInTax = 0;
        //    // 支払外税対象額
        //    kingetCustDmdPrcWork.ItdedPaymOutTax = 0;
        //    // 支払内税対象額
        //    kingetCustDmdPrcWork.ItdedPaymInTax = 0;
        //    // 支払非課税対象額
        //    kingetCustDmdPrcWork.ItdedPaymTaxFree = 0;
        //    // 支払外税消費税
        //    kingetCustDmdPrcWork.PaymentOutTax = 0;
        //    // 支払内税消費税
        //    kingetCustDmdPrcWork.PaymentInTax = 0;
        //    // 消費税転嫁方式
        //    kingetCustDmdPrcWork.ConsTaxLayMethod = 0;
        //    
        //    // 消費税率
        //    kingetCustDmdPrcWork.ConsTaxRate = 0;
        //    // 端数処理区分
        //    kingetCustDmdPrcWork.FractionProcCd = 0;
        //    // 計算後請求金額
        //    kingetCustDmdPrcWork.AfCalDemandPrice = 0;
        //    
        //    // 受注2回前残高（請求計）
        //    kingetCustDmdPrcWork.AcpOdrTtl2TmBfBlDmd = wkCustDmdPrcWork.LastTimeDemand;
        //    // 受注3回前残高（請求計）
        //    kingetCustDmdPrcWork.AcpOdrTtl3TmBfBlDmd = wkCustDmdPrcWork.AcpOdrTtl2TmBfBlDmd;
        //    
        //    // 請求処理通番
        //    kingetCustDmdPrcWork.DmdProcNum = 0;
        //    // 締次更新開始年月日
        //    kingetCustDmdPrcWork.StartCAddUpUpdDate = DateTime.MinValue;
        //    // 前回締次更新年月日
        //    kingetCustDmdPrcWork.LastCAddUpUpdDate = DateTime.MinValue;
        //    
        //    // 今回入金計（通常入金）
        //    kingetCustDmdPrcWork.ThisTimeDmdNrmlTtl = kingetCustDmdPrcWork.ThisTimeDmdNrml
        //                                            + kingetCustDmdPrcWork.ThisTimeFeeDmdNrml
        //                                            + kingetCustDmdPrcWork.ThisTimeDisDmdNrml
        //                                            + kingetCustDmdPrcWork.ThisTimeRbtDmdNrml;
        //    // 今回入金計（預り金）
        //    kingetCustDmdPrcWork.ThisTimeDmdDepoTtl = kingetCustDmdPrcWork.ThisTimeDmdDepo
        //                                            + kingetCustDmdPrcWork.ThisTimeFeeDmdDepo
        //                                            + kingetCustDmdPrcWork.ThisTimeDisDmdDepo
        //                                            + kingetCustDmdPrcWork.ThisTimeRbtDmdDepo;
        //    // 今回入金計
        //    kingetCustDmdPrcWork.ThisTimeDmdTtl     = kingetCustDmdPrcWork.ThisTimeDmdNrmlTtl
        //                                            + kingetCustDmdPrcWork.ThisTimeDmdDepoTtl;
        //    #endregion
        //    // ↑ 20070117 18322 c
        //
        //    return kingetCustDmdPrcWork;
        //}
        #endregion
        // ↑ 2007.12.21 980081 d

        // ↓ 20070417 18322 d MA.NSではいらないと思われる為削除
        #region 請求金額情報格納用ソートリスト→ArrayList＆売上入金明細取得
        ///// <summary>
		///// 請求金額情報格納用ソートリスト→ArrayList＆売上入金明細取得
		///// </summary>
		///// <param name="list">請求金額情報リスト</param>
		///// <param name="addSecCodeSortedList">請求金額情報格納用ソートリスト</param>
		///// <param name="totalDayScheduleSortedList">締日スケジュール格納用ソートリスト</param>
		///// <param name="customerScheduleSortedList">得意先スケジュール格納用ソートリスト</param>
		///// <param name="parameter">検索パラメータ</param>
		///// <param name="sqlConnection">SQLConnection</param>
        ///// <param name="kingetData">請求KINGETデータ格納クラス</param>
        ///// <br>Note       : 請求金額情報格納用ソートリストをArrayListに変換します。</br>
		///// <br>Programmer : 18023 樋口　政成</br>
		///// <br>Date       : 2005.07.21</br>		
		//private int CopyToArrayListFromSortedList(out ArrayList list, SortedList addSecCodeSortedList, SortedList totalDayScheduleSortedList,
		//	SortedList customerScheduleSortedList, SeiKingetParameter parameter, SqlConnection sqlConnection, ref SeiKingetData kingetData)
		//{
		//	list = new ArrayList();
		//	int startDate;
		//	int endDate;
		//	
		//	Hashtable customerCodeTable = new Hashtable();
		//	
		//	// 計上拠点
		//	foreach (DictionaryEntry addSecCode in addSecCodeSortedList)
		//	{
		//		// 得意先コード
		//		foreach (DictionaryEntry customerCode in (SortedList)addSecCode.Value)
		//		{
		//			SortedList addUpDateList = (SortedList)customerCode.Value;
		//			if (addUpDateList.Count == 0)
		//			{
		//				continue;
		//			}
		//			KingetCustDmdPrcWork current = (KingetCustDmdPrcWork)addUpDateList[(int)addUpDateList.GetKey(0)];
		//			
		//			SortedList scheduleDateList;
		//			
		//			// 得意先スケジュールが存在する場合
		//			if (customerScheduleSortedList.Contains(current.CustomerCode))
		//			{
		//				// 抽出日付範囲取得(得意先スケジュールベース)
		//				if (!this.GetDateSpanFromCustomerSchedule(out startDate, out endDate, current.CustomerCode, customerScheduleSortedList, parameter))
		//				{
		//					break;
		//				}
		//				// スケジュール計上日付リストを取得
		//				scheduleDateList = (SortedList)customerScheduleSortedList[current.CustomerCode];
		//			}
		//			else
		//			{
		//				// 抽出日付範囲取得(締日スケジュールベース)
		//				if (!this.GetDateSpanFromTotalDaySchedule(out startDate, out endDate, current.TotalDay, totalDayScheduleSortedList, parameter))
		//				{
		//					break;
		//				}
		//				// スケジュール計上日付リストを取得
		//				scheduleDateList = (SortedList)totalDayScheduleSortedList[current.TotalDay];
		//			}
		//			
		//			// 計上日付
		//			foreach (DictionaryEntry addUpDate in (SortedList)customerCode.Value)
		//			{
		//				// 日付範囲内のみセットする
		//				if (((int)addUpDate.Key >= startDate) && ((int)addUpDate.Key <= endDate))
		//				{
		//					KingetCustDmdPrcWork kingetCustDmdPrcWork = (KingetCustDmdPrcWork)addUpDate.Value;
		//					int keyAddUpDate = TDateTime.DateTimeToLongDate("YYYYMMDD", kingetCustDmdPrcWork.AddUpDate);
		//					// 計上日付範囲をセットする
		//					if (scheduleDateList.Contains(keyAddUpDate))
		//					{
		//						RetAddUpDateItemTypeDInf retAddUpDateItemTypeDInf = (RetAddUpDateItemTypeDInf)scheduleDateList[keyAddUpDate];
		//						kingetCustDmdPrcWork.StartDateSpan	= TDateTime.DateTimeToLongDate("YYYYMMDD", retAddUpDateItemTypeDInf.StartAddUpDate);
		//						kingetCustDmdPrcWork.EndDateSpan	= TDateTime.DateTimeToLongDate("YYYYMMDD", retAddUpDateItemTypeDInf.EndAddUpDate);
		//					}
		//					list.Add(kingetCustDmdPrcWork);
		//				}
		//			}
		//			
		//			// 得意先コードを格納（一度、請求売上情報や入金情報を取得した得意先はここまで）
		//			if (customerCodeTable.Contains(customerCode.Key))
		//			{
		//				continue;
		//			}
		//			customerCodeTable.Add(customerCode.Key, null);
		//			
		//			// 得意先スケジュールが存在する場合
		//			if (customerScheduleSortedList.Contains(current.CustomerCode))
		//			{
		//				// 明細取得用抽出日付範囲取得
		//				if (!this.GetDateSpanForDetailFromCustomerSchedule(out startDate, out endDate, current.CustomerCode, customerScheduleSortedList, parameter))
		//				{
		//					break;
		//				}
		//			}
		//			else
		//			{
		//				// 明細取得用抽出日付範囲取得
		//				if (!this.GetDateSpanForDetailFromTotalDaySchedule(out startDate, out endDate, current.TotalDay, totalDayScheduleSortedList, parameter))
		//				{
		//					break;
		//				}
		//			}
		//			
		//			// 請求売上情報を取得する場合
		//			if (kingetData.GetDmdSalesFlg)
		//			{
		//				// 拠点リスト
		//				ArrayList addUpSecCodeList = (ArrayList)parameter.AddUpSecCodeList.Clone();
		//				
		//				// 全拠点コードを出力する場合は、請求売上・入金の拠点リストをクリア（全社分取得する）
		//				if (parameter.IsOutputAllSecRec)
		//				{
		//					addUpSecCodeList.Clear();
		//				}
		//				else
		//				{
		//					bool hasAllSec = false;
		//					foreach (string secCode in addUpSecCodeList)
		//					{
		//						if (secCode == ALLSECCODE)
		//						{
		//							hasAllSec = true;
		//							break;
		//						}
		//					}
		//					if (hasAllSec)	{addUpSecCodeList.Clear();}
		//				}
		//				
		//				// 請求売上情報抽出
		//				ArrayList dmdSalesWorkList;
		//				if (kingetData.DmdSalesDB == null)	{kingetData.DmdSalesDB = new KingetDmdSalesDB();}
		//				int code = (int)customerCode.Key;
		//				int status = kingetData.DmdSalesDB.Search(out dmdSalesWorkList, parameter.EnterpriseCode,
		//					addUpSecCodeList, code, startDate, endDate);
		//					
		//				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
		//				{
        //                    // ↓ 20070123 18322 c MA.NS用に変更
		//					//foreach (DmdSalesWork dmdSalesWork in dmdSalesWorkList)
		//					//{
		//					//	kingetData.DmdSalesWorkList.Add(dmdSalesWork);
		//					//}
		//
		//					foreach (SalesSlipWork salesSalesWork in dmdSalesWorkList)
		//					{
		//						kingetData.DmdSalesWorkList.Add(salesSalesWork);
		//					}
        //                    // ↑ 20070123 18322 c
		//				}
		//				else
		//				if (status == (int)ConstantManagement.DB_Status.ctDB_EOF)
		//				{
		//				}
		//				else
		//				{
		//					return status;
		//				}
		//				
		//				// 入金情報抽出
		//				ArrayList depsitMainWorkList;
		//				if (kingetData.DepsitMainDB == null) {kingetData.DepsitMainDB = new KingetDepsitMainDB();}
		//				code = (int)customerCode.Key;
		//				status = kingetData.DepsitMainDB.Search(out depsitMainWorkList, parameter.EnterpriseCode,
		//					addUpSecCodeList, code, startDate, endDate);
		//					
		//				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
		//				{
		//					foreach (DepsitMainWork depsitMainWork in depsitMainWorkList)
		//					{
		//						kingetData.DepsitMainWorkList.Add(depsitMainWork);
		//					}
		//				}
		//				else
		//				if (status == (int)ConstantManagement.DB_Status.ctDB_EOF)
		//				{
		//				}
		//				else
		//				{
		//					return status;
		//				}
		//			}
		//		}
		//	}
		//	return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //}
        #endregion

        // ↓ 2007.12.21 980081 d
        #region 抽出日付範囲取得(締日スケジュールベース) 未使用のため削除
        ///// <summary>
		///// 抽出日付範囲取得(締日スケジュールベース)
		///// </summary>
		///// <param name="startDate">開始日付</param>
		///// <param name="endDate">終了日付</param>
		///// <param name="totalDay">締日</param>
		///// <param name="totalDayScheduleSortedList">締日スケジュール格納用ソートリスト</param>
		///// <param name="parameter">検索パラメータ</param>
		///// <br>Note       : 締日スケジュールリストより指定範囲のスケジュールの開始日と終了日を返します。</br>
		///// <br>Programmer : 18023 樋口　政成</br>
		///// <br>Date       : 2005.07.21</br>		
		//private bool GetDateSpanFromTotalDaySchedule(out int startDate, out int endDate, int totalDay, SortedList totalDayScheduleSortedList,
		//	SeiKingetParameter parameter)
		//{
		//	// スケジュール計上日付リストを取得
		//	SortedList scheduleDateList = (SortedList)totalDayScheduleSortedList[totalDay];
		//	return this.GetDateSpan(out startDate, out endDate, scheduleDateList, parameter);
        //}
        #endregion
        // ↑ 2007.12.21 980081 d

        // ↓ 2007.12.21 980081 d
        #region 抽出日付範囲取得(得意先スケジュールベース) 未使用のため削除
        ///// <summary>
		///// 抽出日付範囲取得(得意先スケジュールベース)
		///// </summary>
		///// <param name="startDate">開始日付</param>
		///// <param name="endDate">終了日付</param>
		///// <param name="customerCode">得意先コード</param>
		///// <param name="customerScheduleSortedList">得意先スケジュール格納用ソートリスト</param>
		///// <param name="parameter">検索パラメータ</param>
		///// <br>Note       : 得意先スケジュールリストより指定範囲のスケジュールの開始日と終了日を返します。</br>
		///// <br>Programmer : 18023 樋口　政成</br>
		///// <br>Date       : 2005.07.21</br>		
		//private bool GetDateSpanFromCustomerSchedule(out int startDate, out int endDate, int customerCode, SortedList customerScheduleSortedList,
		//	SeiKingetParameter parameter)
		//{
		//	// スケジュール計上日付リストを取得
		//	SortedList scheduleDateList = (SortedList)customerScheduleSortedList[customerCode];
		//	return this.GetDateSpan(out startDate, out endDate, scheduleDateList, parameter);
        //}
        #endregion
        // ↑ 2007.12.21 980081 d

        // ↓ 2007.12.21 980081 d
        #region 抽出日付範囲取得(スケジュール計上日付リスト) 未使用のため削除
        ///// <summary>
        ///// 抽出日付範囲取得(スケジュール計上日付リスト)
        ///// </summary>
        ///// <param name="startDate">開始日付</param>
        ///// <param name="endDate">終了日付</param>
        ///// <param name="scheduleDateSortedList">スケジュール計上日付ソートリスト</param>
        ///// <param name="parameter">検索パラメータ</param>
        ///// <br>Note       : 指定範囲のスケジュールの開始日と終了日を返します。</br>
        ///// <br>Programmer : 18023 樋口　政成</br>
        ///// <br>Date       : 2005.07.21</br>		
		//private bool GetDateSpan(out int startDate, out int endDate, SortedList scheduleDateSortedList, SeiKingetParameter parameter)
		//{
		//	startDate = 0;
		//	endDate   = 0;
		//			
		//	// 計上年月
		//	if ((parameter.StartAddUpYearMonth > 100000) &&
		//		(parameter.EndAddUpYearMonth > 100000) &&
		//		(parameter.StartAddUpYearMonth <= parameter.EndAddUpYearMonth))
		//	{
		//		int paraStartDate	= parameter.StartAddUpYearMonth	* 100;
		//		int paraEndDate		= parameter.EndAddUpYearMonth	* 100;
		//				
		//		foreach (DictionaryEntry de in scheduleDateSortedList)
		//		{
		//			int totalYYYYMMDD = (int)de.Key;	// スケジュール締日
		//					
		//			if (startDate == 0)
		//			{
		//				// スケジュール締日(年月)≧パラメータ計上年月(開始)の場合
		//				if (totalYYYYMMDD >= paraStartDate)
		//				{
		//					startDate = totalYYYYMMDD;
		//				}
		//			}
		//					
		//			// スケジュール締日(年月)≦パラメータ計上年月(終了)の場合
		//			if (totalYYYYMMDD / 100 <= paraEndDate / 100)
		//			{
		//				endDate = totalYYYYMMDD;
		//			}
		//			else
		//			{
		//				break;
		//			}
		//		}
		//	}
		//	else
		//		// 計上日付
		//		if (parameter.StartAddUpDate <= parameter.EndAddUpDate)
		//	{
		//		int paraStartDate	= TDateTime.DateTimeToLongDate("YYYYMMDD", parameter.StartAddUpDate);
		//		int paraEndDate		= TDateTime.DateTimeToLongDate("YYYYMMDD", parameter.EndAddUpDate);
        //
		//		foreach (DictionaryEntry de in scheduleDateSortedList)
		//		{
		//			int totalYYYYMMDD = (int)de.Key;	// スケジュール締日
		//					
		//			if (startDate == 0)
		//			{
		//				// スケジュール締日≧パラメータ計上日付(開始)の場合
		//				if (totalYYYYMMDD >= paraStartDate)
		//				{
		//					startDate = totalYYYYMMDD;
		//				}
		//			}
		//					
		//			// スケジュール締日≦パラメータ計上日付(終了)の場合
		//			if (totalYYYYMMDD <= paraEndDate)
		//			{
		//				endDate = totalYYYYMMDD;
		//			}
		//			else
		//			{
		//				break;
		//			}
		//		}
		//	}
		//	else
		//	{
		//		// 日付の範囲指定がされていない場合は処理終了
		//		return false;
		//	}
		//	
		//	return true;
		//}
        #endregion
        // ↑ 2007.12.21 980081 d
		
        // ↓ 20070417 18322 d 未使用の為削除
        #region 明細用抽出日付範囲取得（全てコメントアウト）
		///// <summary>
		///// 明細用抽出日付範囲取得(締日スケジュールベース)
		///// </summary>
		///// <param name="startDate">開始日付</param>
		///// <param name="endDate">終了日付</param>
		///// <param name="totalDay">締日</param>
		///// <param name="totalDayScheduleSortedList">締日スケジュール格納用ソートリスト</param>
		///// <param name="parameter">検索パラメータ</param>
		///// <br>Note       : 指定範囲のスケジュールの開始日と終了日を返します。</br>
		///// <br>Programmer : 18023 樋口　政成</br>
		///// <br>Date       : 2005.07.21</br>		
		//private bool GetDateSpanForDetailFromTotalDaySchedule(out int startDate, out int endDate, int totalDay,
		//	SortedList totalDayScheduleSortedList, SeiKingetParameter parameter)
		//{
		//	// スケジュール計上日付リストを取得
		//	SortedList scheduleDateList = (SortedList)totalDayScheduleSortedList[totalDay];
		//	return this.GetDateSpanForDetail(out startDate, out endDate, scheduleDateList, parameter);
		//}

		///// <summary>
		///// 明細用抽出日付範囲取得(得意先スケジュールベース)
		///// </summary>
		///// <param name="startDate">開始日付</param>
		///// <param name="endDate">終了日付</param>
		///// <param name="customerCode">得意先コード</param>
		///// <param name="customerScheduleSortedList">得意先スケジュール格納用ソートリスト</param>
		///// <param name="parameter">検索パラメータ</param>
		///// <br>Note       : 指定範囲のスケジュールの開始日と終了日を返します。</br>
		///// <br>Programmer : 18023 樋口　政成</br>
		///// <br>Date       : 2005.07.21</br>		
		//private bool GetDateSpanForDetailFromCustomerSchedule(out int startDate, out int endDate, int customerCode,
		//	SortedList customerScheduleSortedList, SeiKingetParameter parameter)
		//{
		//	// スケジュール計上日付リストを取得
		//	SortedList scheduleDateList = (SortedList)customerScheduleSortedList[customerCode];
		//	return this.GetDateSpanForDetail(out startDate, out endDate, scheduleDateList, parameter);
		//}
        #endregion
        // ↑ 20070417 18322 d

        // ↓ 20070417 18322 d 未使用の為削除
        #region 明細用抽出日付範囲取得（全てコメントアウト）
		///// <summary>
		///// 明細用抽出日付範囲取得
		///// </summary>
		///// <param name="startDate">開始日付</param>
		///// <param name="endDate">終了日付</param>
		///// <param name="scheduleDateList">スケジュール計上日付ソートリスト</param>
		///// <param name="parameter">検索パラメータ</param>
		///// <br>Note       : 請求金額情報格納用ソートリストにセットします。</br>
		///// <br>Programmer : 18023 樋口　政成</br>
		///// <br>Date       : 2005.07.21</br>		
		//private bool GetDateSpanForDetail(out int startDate, out int endDate, SortedList scheduleDateList, SeiKingetParameter parameter)
		//{
		//	startDate = 0;
		//	endDate   = 0;
		//			
		//	// 計上年月
		//	if ((parameter.StartAddUpYearMonth > 100000) &&
		//		(parameter.EndAddUpYearMonth > 100000) &&
		//		(parameter.StartAddUpYearMonth <= parameter.EndAddUpYearMonth))
		//	{
		//		int paraStartDate	= parameter.StartAddUpYearMonth;
		//		int paraEndDate		= parameter.EndAddUpYearMonth;
		//				
		//		foreach (DictionaryEntry de in scheduleDateList)
		//		{
		//			RetAddUpDateItemTypeDInf retAddUpDateItemTypeDInf = (RetAddUpDateItemTypeDInf)de.Value;
		//			int totalYYYYMM = TDateTime.DateTimeToLongDate("YYYYMM", retAddUpDateItemTypeDInf.CAddUpUpdDate);
		//					
		//			if (startDate == 0)
		//			{
		//				// スケジュール締日(年月)≧パラメータ計上年月(開始)の場合
		//				if (totalYYYYMM >= paraStartDate)
		//				{
		//					// 締め範囲の開始日をセット
		//					startDate = TDateTime.DateTimeToLongDate("YYYYMMDD", retAddUpDateItemTypeDInf.StartAddUpDate);
		//				}
		//			}
		//					
		//			// スケジュール締日(年月)≦パラメータ計上年月(終了)の場合
		//			if (totalYYYYMM <= paraEndDate)
		//			{
		//				// 締め範囲の終了日をセット
		//				endDate = TDateTime.DateTimeToLongDate("YYYYMMDD", retAddUpDateItemTypeDInf.EndAddUpDate);
		//			}
		//			else
		//			{
		//				break;
		//			}
		//		}
		//	}
		//	else
		//	// 計上日付
		//	if (parameter.StartAddUpDate <= parameter.EndAddUpDate)
		//	{
		//		foreach (DictionaryEntry de in scheduleDateList)
		//		{
		//			RetAddUpDateItemTypeDInf retAddUpDateItemTypeDInf = (RetAddUpDateItemTypeDInf)de.Value;
		//					
		//			if (startDate == 0)
		//			{
		//				// スケジュール締日≧パラメータ計上日付(開始)の場合
		//				if (retAddUpDateItemTypeDInf.CAddUpUpdDate >= parameter.StartAddUpDate)
		//				{
		//					// 締め範囲の開始日をセット
		//					startDate = TDateTime.DateTimeToLongDate("YYYYMMDD", retAddUpDateItemTypeDInf.StartAddUpDate);
		//				}
		//			}
		//					
		//			// スケジュール締日≦パラメータ計上日付(終了)の場合
		//			if (retAddUpDateItemTypeDInf.CAddUpUpdDate <= parameter.EndAddUpDate)
		//			{
		//				// 締め範囲の終了日をセット
		//				endDate = TDateTime.DateTimeToLongDate("YYYYMMDD", retAddUpDateItemTypeDInf.EndAddUpDate);
		//			}
		//			else
		//			{
		//				break;
		//			}
		//		}
		//	}
		//	else
		//	{
		//		// 日付の範囲指定がされていない場合は処理終了
		//		return false;
		//	}
		//	
		//	return true;
		//}
        #endregion
        // ↑ 20070417 18322 d

        // ↓ 2007.12.21 980081 d
        #region SQLデータリーダー→得意先請求金額ワーク 未使用のため削除
        ///// <summary>
		///// SQLデータリーダー→得意先請求金額ワーク
		///// </summary>
		///// <param name="kingetCustDmdPrcWork">得意先請求金額ワーク</param>
		///// <param name="myReader">SQLデータリーダー</param>
		///// <returns>STATUS</returns>
		///// <br>Note       : SQLデータリーダーに保持している内容をKINGET用得意先請求金額マスタにコピーします。</br>
		///// <br>Programmer : 18023 樋口　政成</br>
		///// <br>Date       : 2005.07.21</br>		
		//private void CopyToDataClassFromSelectData(ref KingetCustDmdPrcWork kingetCustDmdPrcWork, SqlDataReader myReader)
        //{
        //    // ↓ 20070117 18322 c MA.NS用に変更
        //    #region SF KINGET用得意先請求金額クラスワークへデータ設定（コメントアウト）
        //    //kingetCustDmdPrcWork.FileHeaderGuid			= SqlDataMediator.SqlGetGuid	(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"		));
        //	//kingetCustDmdPrcWork.EnterpriseCode			= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("ENTERPRISECODERF"		));
        //	//kingetCustDmdPrcWork.AddUpSecCode			= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("ADDUPSECCODERF"			));
        //	//kingetCustDmdPrcWork.CustomerCode			= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("CUSTOMERCODERF"			));
        //	//kingetCustDmdPrcWork.AddUpDate				= SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPDATERF"));
        //	//kingetCustDmdPrcWork.AddUpYearMonth			= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("ADDUPYEARMONTHRF"		));
        //	//kingetCustDmdPrcWork.TleDmdSlipLgCt			= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("TLEDMDSLIPLGCTRF"		));
        //	//kingetCustDmdPrcWork.TleDmdSlipGeCt			= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("TLEDMDSLIPGECTRF"		));
        //	//kingetCustDmdPrcWork.TleDmdDebitNoteLgCt	= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("TLEDMDDEBITNOTELGCTRF"	));
        //	//kingetCustDmdPrcWork.TleDmdDebitNoteGeCt	= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("TLEDMDDEBITNOTEGECTRF"	));
        //	//kingetCustDmdPrcWork.TleDmdSlipLgCnt		= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("TLEDMDSLIPLGCNTRF"		));
        //	//kingetCustDmdPrcWork.TleDmdSlipGeCnt		= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("TLEDMDSLIPGECNTRF"		));
        //	//kingetCustDmdPrcWork.TleDmdDebitNoteLgCnt	= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("TLEDMDDEBITNOTELGCNTRF"	));
        //	//kingetCustDmdPrcWork.TleDmdDebitNoteGeCnt	= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("TLEDMDDEBITNOTEGECNTRF"	));
        //	//kingetCustDmdPrcWork.AcpOdrTtlSalesDmd		= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("ACPODRTTLSALESDMDRF"	));
        //	//kingetCustDmdPrcWork.AcpOdrDiscTtlDmd		= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("ACPODRDISCTTLDMDRF"		));
        //	//kingetCustDmdPrcWork.AcpOdrTtlConsTaxDmd	= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("ACPODRTTLCONSTAXDMDRF"	));
        //	//kingetCustDmdPrcWork.DmdVarCst				= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("DMDVARCSTRF"			));
        //	//kingetCustDmdPrcWork.TtlTaxtinDmdVarCst		= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("TTLTAXTINDMDVARCSTRF"	));
        //	//kingetCustDmdPrcWork.TtlTaxFreeDmdVarCst	= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("TTLTAXFREEDMDVARCSTRF"	));
        //	//kingetCustDmdPrcWork.VarCst1TotalDemand		= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("VARCST1TOTALDEMANDRF"	));
        //	//kingetCustDmdPrcWork.VarCst2TotalDemand		= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("VARCST2TOTALDEMANDRF"	));
        //	//kingetCustDmdPrcWork.VarCst3TotalDemand		= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("VARCST3TOTALDEMANDRF"	));
        //	//kingetCustDmdPrcWork.VarCst4TotalDemand		= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("VARCST4TOTALDEMANDRF"	));
        //	//kingetCustDmdPrcWork.VarCst5TotalDemand		= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("VARCST5TOTALDEMANDRF"	));
        //	//kingetCustDmdPrcWork.VarCst6TotalDemand		= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("VARCST6TOTALDEMANDRF"	));
        //	//kingetCustDmdPrcWork.VarCst7TotalDemand		= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("VARCST7TOTALDEMANDRF"	));
        //	//kingetCustDmdPrcWork.VarCst8TotalDemand		= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("VARCST8TOTALDEMANDRF"	));
        //	//kingetCustDmdPrcWork.VarCst9TotalDemand		= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("VARCST9TOTALDEMANDRF"	));
        //	//kingetCustDmdPrcWork.VarCst10TotalDemand	= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("VARCST10TOTALDEMANDRF"	));
        //	//kingetCustDmdPrcWork.VarCst11TotalDemand	= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("VARCST11TOTALDEMANDRF"	));
        //	//kingetCustDmdPrcWork.VarCst12TotalDemand	= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("VARCST12TOTALDEMANDRF"	));
        //	//kingetCustDmdPrcWork.VarCst13TotalDemand	= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("VARCST13TOTALDEMANDRF"	));
        //    //kingetCustDmdPrcWork.VarCst14TotalDemand	= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("VARCST14TOTALDEMANDRF"	));
        //    //kingetCustDmdPrcWork.VarCst15TotalDemand	= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("VARCST15TOTALDEMANDRF"	));
        //	//kingetCustDmdPrcWork.VarCst16TotalDemand	= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("VARCST16TOTALDEMANDRF"	));
        //	//kingetCustDmdPrcWork.VarCst17TotalDemand	= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("VARCST17TOTALDEMANDRF"	));
        //	//kingetCustDmdPrcWork.VarCst18TotalDemand	= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("VARCST18TOTALDEMANDRF"	));
        //	//kingetCustDmdPrcWork.VarCst19TotalDemand	= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("VARCST19TOTALDEMANDRF"	));
        //	//kingetCustDmdPrcWork.VarCst20TotalDemand	= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("VARCST20TOTALDEMANDRF"	));
        //	//kingetCustDmdPrcWork.TtlDmdVarCstConsTax	= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("TTLDMDVARCSTCONSTAXRF"	));
        //	//kingetCustDmdPrcWork.AcpOdrTtlLMBlDmd		= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("ACPODRTTLLMBLDMDRF"		));
        //	//kingetCustDmdPrcWork.TtlLMVarCstDmdBlnce	= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("TTLLMVARCSTDMDBLNCERF"	));
        //	//kingetCustDmdPrcWork.BfCalTtlAOdrDepoDmd	= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("BFCALTTLAODRDEPODMDRF"	));
        //	//kingetCustDmdPrcWork.BfCalTtlAOdrDpDsDmd	= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("BFCALTTLAODRDPDSDMDRF"	));
        //	//kingetCustDmdPrcWork.BfCalTtlAOdrDpDmd		= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("BFCALTTLAODRDPDMDRF"	));
        //	//kingetCustDmdPrcWork.BfCalTtlAOdrDsDmd		= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("BFCALTTLAODRDSDMDRF"	));
        //	//kingetCustDmdPrcWork.AfCalTtlAOdrDepoDmd	= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("AFCALTTLAODRDEPODMDRF"	));
        //	//kingetCustDmdPrcWork.AfCalTtlVCstDepoDmd	= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("AFCALTTLVCSTDEPODMDRF"	));
        //	//kingetCustDmdPrcWork.AfCalTtlAOdrDpDsDmd	= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("AFCALTTLAODRDPDSDMDRF"	));
        //	//kingetCustDmdPrcWork.AfCalTtlVCstDpDsDmd	= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("AFCALTTLVCSTDPDSDMDRF"	));
        //	//kingetCustDmdPrcWork.AfCalTtlAOdrRMDmd		= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("AFCALTTLAODRRMDMDRF"	));
        //	//kingetCustDmdPrcWork.AfCalTtlVCstBfRMDmd	= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("AFCALTTLVCSTBFRMDMDRF"	));
        //	//kingetCustDmdPrcWork.AfCalTtlAOdrRMDsDmd	= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("AFCALTTLAODRRMDSDMDRF"	));
        //	//kingetCustDmdPrcWork.AfCalTtlVCstRMDsDmd	= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("AFCALTTLVCSTRMDSDMDRF"	));
        //	//kingetCustDmdPrcWork.AfCalTtlAOdrBlCFDmd	= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("AFCALTTLAODRBLCFDMDRF"	));
        //	//kingetCustDmdPrcWork.AfCalTtlVCstBlCFDmd	= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("AFCALTTLVCSTBLCFDMDRF"	));
        //	//kingetCustDmdPrcWork.AfCalTtlAOdrBlDmd		= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("AFCALTTLAODRBLDMDRF"	));
        //	//kingetCustDmdPrcWork.AfCalTtlVCstBlDmd		= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("AFCALTTLVCSTBLDMDRF"	));
        //	//kingetCustDmdPrcWork.AfCalDemandPrice		= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("AFCALDEMANDPRICERF"		));
        //	//kingetCustDmdPrcWork.AcpOdrTtl2TmBfBlDmd	= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("ACPODRTTL2TMBFBLDMDRF"	));
        //	//kingetCustDmdPrcWork.Ttl2TmBfVarCstDmdBl	= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("TTL2TMBFVARCSTDMDBLRF"	));
        //	//kingetCustDmdPrcWork.AcpOdrTtl3TmBfBlDmd	= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("ACPODRTTL3TMBFBLDMDRF"	));
        //	//kingetCustDmdPrcWork.Ttl3TmBfVarCstDmdBl	= SqlDataMediator.SqlGetInt64	(myReader, myReader.GetOrdinal("TTL3TMBFVARCSTDMDBLRF"	));
        //	//kingetCustDmdPrcWork.AddUpDateLastRecFlg	= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("ADDUPDATELASTRECFLGRF"	));
        //	//kingetCustDmdPrcWork.Name					= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("NAMERF"					));
        //	//kingetCustDmdPrcWork.Name2					= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("NAME2RF"				));
        //	//kingetCustDmdPrcWork.HonorificTitle			= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("HONORIFICTITLERF"		));
        //	//kingetCustDmdPrcWork.Kana					= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("KANARF"					));
        //	//kingetCustDmdPrcWork.OutputNameCode			= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("OUTPUTNAMECODERF"		));
        //	//kingetCustDmdPrcWork.OutputName				= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("OUTPUTNAMERF"			));
        //	//kingetCustDmdPrcWork.CorporateDivCode		= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("CORPORATEDIVCODERF"		));
        //	//kingetCustDmdPrcWork.PostNo					= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("POSTNORF"				));
        //	//kingetCustDmdPrcWork.Address1				= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("ADDRESS1RF"				));
        //	//kingetCustDmdPrcWork.Address2				= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("ADDRESS2RF"				));
        //	//kingetCustDmdPrcWork.Address3				= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("ADDRESS3RF"				));
        //	//kingetCustDmdPrcWork.Address4				= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("ADDRESS4RF"				));
        //	//kingetCustDmdPrcWork.HomeTelNo				= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("HOMETELNORF"			));
        //	//kingetCustDmdPrcWork.OfficeTelNo			= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("OFFICETELNORF"			));
        //	//kingetCustDmdPrcWork.PortableTelNo			= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("PORTABLETELNORF"		));
        //	//// 2006.04.21 ADD START 樋口　政成
        //	//kingetCustDmdPrcWork.HomeFaxNo				= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("HOMEFAXNORF"			));
        //	//kingetCustDmdPrcWork.OfficeFaxNo			= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("OFFICEFAXNORF"			));
        //	//kingetCustDmdPrcWork.OthersTelNo			= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("OTHERSTELNORF"			));
        //	//kingetCustDmdPrcWork.MainContactCode		= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("MAINCONTACTCODERF"		));
        //	//// 2006.04.21 ADD END 樋口　政成
        //	//// 2006.09.06 ADD START 樋口　政成
        //	//kingetCustDmdPrcWork.CustAnalysCode1		= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("CUSTANALYSCODE1RF"		));
        //	//kingetCustDmdPrcWork.CustAnalysCode2		= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("CUSTANALYSCODE2RF"		));
        //	//kingetCustDmdPrcWork.CustAnalysCode3		= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("CUSTANALYSCODE3RF"		));
        //	//kingetCustDmdPrcWork.CustAnalysCode4		= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("CUSTANALYSCODE4RF"		));
        //	//kingetCustDmdPrcWork.CustAnalysCode5		= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("CUSTANALYSCODE5RF"		));
        //	//kingetCustDmdPrcWork.CustAnalysCode6		= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("CUSTANALYSCODE6RF"		));
        //	//// 2006.09.06 ADD END 樋口　政成
        //	//kingetCustDmdPrcWork.TotalDay				= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("TOTALDAYRF"				));
        //	//kingetCustDmdPrcWork.CollectMoneyName		= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("COLLECTMONEYNAMERF"		));
        //	//kingetCustDmdPrcWork.CollectMoneyDay		= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("COLLECTMONEYDAYRF"		));
        //	//kingetCustDmdPrcWork.CustomerAgentCd		= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("CUSTOMERAGENTCDRF"		));
        //	//kingetCustDmdPrcWork.CustomerAgentNm		= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("CUSTOMERAGENTNMRF"		));
        //	//kingetCustDmdPrcWork.BillCollecterCd		= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("BILLCOLLECTERCDRF"		));
        //	//kingetCustDmdPrcWork.BillCollecterNm		= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("BILLCOLLECTERNMRF"		));
        //    #endregion
        //
        //    #region MA.NS KINGET用得意先請求金額クラスワークへデータ設定
        //    // GUID
        //    kingetCustDmdPrcWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
        //    // 企業コード
        //    kingetCustDmdPrcWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
        //    // 計上拠点コード
        //    kingetCustDmdPrcWork.AddUpSecCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDUPSECCODERF"));
        //    // 得意先コード
        //    kingetCustDmdPrcWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
        //    // 得意先名称
        //    kingetCustDmdPrcWork.CustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAMERF"));
        //    // 得意先名称2
        //    kingetCustDmdPrcWork.CustomerName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAME2RF"));
        //    // 計上年月日
        //    kingetCustDmdPrcWork.AddUpDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPDATERF"));
        //    // 計上年月
        //    kingetCustDmdPrcWork.AddUpYearMonth = SqlDataMediator.SqlGetDateTimeFromYYYYMM(myReader, myReader.GetOrdinal("ADDUPYEARMONTHRF"));
        //    // 前回請求金額
        //    kingetCustDmdPrcWork.LastTimeDemand = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("LASTTIMEDEMANDRF"));
        //    // 今回入金金額（通常入金）
        //    kingetCustDmdPrcWork.ThisTimeDmdNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEDMDNRMLRF"));
        //    // 今回手数料額（通常入金）
        //    kingetCustDmdPrcWork.ThisTimeFeeDmdNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEFEEDMDNRMLRF"));
        //    // 今回値引額（通常入金）
        //    kingetCustDmdPrcWork.ThisTimeDisDmdNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEDISDMDNRMLRF"));
        //    // 今回リベート額（通常入金）
        //    kingetCustDmdPrcWork.ThisTimeRbtDmdNrml = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMERBTDMDNRMLRF"));
        //    // 今回入金金額（預り金）
        //    kingetCustDmdPrcWork.ThisTimeDmdDepo = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEDMDDEPORF"));
        //    // 今回手数料額（預り金）
        //    kingetCustDmdPrcWork.ThisTimeFeeDmdDepo = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEFEEDMDDEPORF"));
        //    // 今回値引額（預り金）
        //    kingetCustDmdPrcWork.ThisTimeDisDmdDepo = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMEDISDMDDEPORF"));
        //    // 今回リベート額（預り金）
        //    kingetCustDmdPrcWork.ThisTimeRbtDmdDepo = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMERBTDMDDEPORF"));
        //    // 今回繰越残高（請求計）
        //    kingetCustDmdPrcWork.ThisTimeTtlBlcDmd = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMETTLBLCDMDRF"));
        //    // 今回売上金額
        //    kingetCustDmdPrcWork.ThisTimeSales = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISTIMESALESRF"));
        //    // 今回売上消費税
        //    kingetCustDmdPrcWork.ThisSalesTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("THISSALESTAXRF"));
        //    // 支払インセンティブ額合計（税抜き）
        //    kingetCustDmdPrcWork.TtlIncDtbtTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLINCDTBTTAXEXCRF"));
        //    // 支払インセンティブ額合計（税）
        //    kingetCustDmdPrcWork.TtlIncDtbtTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLINCDTBTTAXRF"));
        //    // 相殺後今回売上金額
        //    kingetCustDmdPrcWork.OfsThisTimeSales = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFSTHISTIMESALESRF"));
        //    // 相殺後今回売上消費税
        //    kingetCustDmdPrcWork.OfsThisSalesTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFSTHISSALESTAXRF"));
        //    // 相殺後外税対象額
        //    kingetCustDmdPrcWork.ItdedOffsetOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDOFFSETOUTTAXRF"));
        //    // 相殺後内税対象額
        //    kingetCustDmdPrcWork.ItdedOffsetInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDOFFSETINTAXRF"));
        //    // 相殺後非課税対象額
        //    kingetCustDmdPrcWork.ItdedOffsetTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDOFFSETTAXFREERF"));
        //    // 相殺後外税消費税
        //    kingetCustDmdPrcWork.OffsetOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFFSETOUTTAXRF"));
        //    // 相殺後内税消費税
        //    kingetCustDmdPrcWork.OffsetInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("OFFSETINTAXRF"));
        //    // 売上外税対象額
        //    kingetCustDmdPrcWork.ItdedSalesOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESOUTTAXRF"));
        //    // 売上内税対象額
        //    kingetCustDmdPrcWork.ItdedSalesInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESINTAXRF"));
        //    // 売上非課税対象額
        //    kingetCustDmdPrcWork.ItdedSalesTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESTAXFREERF"));
        //    // 売上外税額
        //    kingetCustDmdPrcWork.SalesOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESOUTTAXRF"));
        //    // 売上内税額
        //    kingetCustDmdPrcWork.SalesInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESINTAXRF"));
        //    // 支払外税対象額
        //    kingetCustDmdPrcWork.ItdedPaymOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDPAYMOUTTAXRF"));
        //    // 支払内税対象額
        //    kingetCustDmdPrcWork.ItdedPaymInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDPAYMINTAXRF"));
        //    // 支払非課税対象額
        //    kingetCustDmdPrcWork.ItdedPaymTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDPAYMTAXFREERF"));
        //    // 支払外税消費税
        //    kingetCustDmdPrcWork.PaymentOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTOUTTAXRF"));
        //    // 支払内税消費税
        //    kingetCustDmdPrcWork.PaymentInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PAYMENTINTAXRF"));
        //    // 消費税転嫁方式
        //    kingetCustDmdPrcWork.ConsTaxLayMethod = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CONSTAXLAYMETHODRF"));
        //    // 消費税率
        //    kingetCustDmdPrcWork.ConsTaxRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("CONSTAXRATERF"));
        //    // 端数処理区分
        //    kingetCustDmdPrcWork.FractionProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACTIONPROCCDRF"));
        //    // 計算後請求金額
        //    kingetCustDmdPrcWork.AfCalDemandPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("AFCALDEMANDPRICERF"));
        //    // 受注2回前残高（請求計）
        //    kingetCustDmdPrcWork.AcpOdrTtl2TmBfBlDmd = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ACPODRTTL2TMBFBLDMDRF"));
        //    // 受注3回前残高（請求計）
        //    kingetCustDmdPrcWork.AcpOdrTtl3TmBfBlDmd = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ACPODRTTL3TMBFBLDMDRF"));
        //    // 締次更新実行年月日
        //    kingetCustDmdPrcWork.CAddUpUpdExecDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("CADDUPUPDEXECDATERF"));
        //    
        //    // 請求処理通番
        //    kingetCustDmdPrcWork.DmdProcNum = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DMDPROCNUMRF"));
        //    // 締次更新開始年月日
        //    kingetCustDmdPrcWork.StartCAddUpUpdDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STARTCADDUPUPDDATERF"));
        //    // 前回締次更新年月日
        //    kingetCustDmdPrcWork.LastCAddUpUpdDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("LASTCADDUPUPDDATERF"));
        //    
        //    // 今回入金計（通常入金）
        //    kingetCustDmdPrcWork.ThisTimeDmdNrmlTtl = kingetCustDmdPrcWork.ThisTimeDmdNrml
        //                                            + kingetCustDmdPrcWork.ThisTimeFeeDmdNrml
        //                                            + kingetCustDmdPrcWork.ThisTimeDisDmdNrml
        //                                            + kingetCustDmdPrcWork.ThisTimeRbtDmdNrml;
        //    // 今回入金計（預り金）
        //    kingetCustDmdPrcWork.ThisTimeDmdDepoTtl = kingetCustDmdPrcWork.ThisTimeDmdDepo
        //                                            + kingetCustDmdPrcWork.ThisTimeFeeDmdDepo
        //                                            + kingetCustDmdPrcWork.ThisTimeDisDmdDepo
        //                                            + kingetCustDmdPrcWork.ThisTimeRbtDmdDepo;
        //    // 今回入金計
        //    kingetCustDmdPrcWork.ThisTimeDmdTtl     = kingetCustDmdPrcWork.ThisTimeDmdNrmlTtl
        //                                            + kingetCustDmdPrcWork.ThisTimeDmdDepoTtl;
        //    
        //    // 名称
        //    kingetCustDmdPrcWork.Name = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAMERF"));
        //    // 名称２
        //    kingetCustDmdPrcWork.Name2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("NAME2RF"));
        //    // 敬称
        //    kingetCustDmdPrcWork.HonorificTitle = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("HONORIFICTITLERF"));
        //    // カナ
        //    kingetCustDmdPrcWork.Kana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("KANARF"));
        //    // 諸口コード
        //    kingetCustDmdPrcWork.OutputNameCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OUTPUTNAMECODERF"));
        //    // 諸口名称
        //    kingetCustDmdPrcWork.OutputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTPUTNAMERF"));
        //    // 個人・法人区分
        //    kingetCustDmdPrcWork.CorporateDivCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CORPORATEDIVCODERF"));
        //    // 郵便番号
        //    kingetCustDmdPrcWork.PostNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("POSTNORF"));
        //    // 住所１（都道府県市区郡・町村・字）
        //    kingetCustDmdPrcWork.Address1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS1RF"));
        //    // 住所２（丁目）
        //    kingetCustDmdPrcWork.Address2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDRESS2RF"));
        //    // 住所３（番地）
        //    kingetCustDmdPrcWork.Address3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS3RF"));
        //    // 住所４（アパート名称）
        //    kingetCustDmdPrcWork.Address4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS4RF"));
        //    // 電話番号（自宅）
        //    kingetCustDmdPrcWork.HomeTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("HOMETELNORF"));
        //    // 電話番号（勤務先）
        //    kingetCustDmdPrcWork.OfficeTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OFFICETELNORF"));
        //    // 電話番号（携帯）
        //    kingetCustDmdPrcWork.PortableTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PORTABLETELNORF"));
        //    // FAX番号（自宅）
        //    kingetCustDmdPrcWork.HomeFaxNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("HOMEFAXNORF"));
        //    // FAX番号（勤務先）
        //    kingetCustDmdPrcWork.OfficeFaxNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OFFICEFAXNORF"));
        //    // 電話番号（その他）
        //    kingetCustDmdPrcWork.OthersTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OTHERSTELNORF"));
        //    // 主連絡先区分
        //    kingetCustDmdPrcWork.MainContactCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAINCONTACTCODERF"));
        //    // 得意先分析コード１
        //    kingetCustDmdPrcWork.CustAnalysCode1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE1RF"));
        //    // 得意先分析コード２
        //    kingetCustDmdPrcWork.CustAnalysCode2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE2RF"));
        //    // 得意先分析コード３
        //    kingetCustDmdPrcWork.CustAnalysCode3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE3RF"));
        //    // 得意先分析コード４
        //    kingetCustDmdPrcWork.CustAnalysCode4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE4RF"));
        //    // 得意先分析コード５
        //    kingetCustDmdPrcWork.CustAnalysCode5 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE5RF"));
        //    // 得意先分析コード６
        //    kingetCustDmdPrcWork.CustAnalysCode6 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE6RF"));
        //    // 締日
        //    kingetCustDmdPrcWork.TotalDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALDAYRF"));
        //    // 集金月区分名称
        //    kingetCustDmdPrcWork.CollectMoneyName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COLLECTMONEYNAMERF"));
        //    // 集金日
        //    kingetCustDmdPrcWork.CollectMoneyDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTMONEYDAYRF"));
        //    // 顧客担当従業員コード
        //    kingetCustDmdPrcWork.CustomerAgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERAGENTCDRF"));
        //    // 顧客担当従業員名称
        //    kingetCustDmdPrcWork.CustomerAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERAGENTNMRF"));
        //    // 集金担当従業員コード
        //    kingetCustDmdPrcWork.BillCollecterCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BILLCOLLECTERCDRF"));
        //    // 集金担当従業員名称
        //    kingetCustDmdPrcWork.BillCollecterNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BILLCOLLECTERNMRF"));
        //    #endregion
        //    // ↑ 20070117 18322 c
        //}
        #endregion
        // ↑ 2007.12.21 980081 d

		/// <summary>
		/// SQLデータリーダー(得意先情報)→得意先請求金額ワーク
		/// </summary>
		/// <param name="kingetCustDmdPrcWork">得意先請求金額ワーク</param>
		/// <param name="myReader">SQLデータリーダー</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : SQLデータリーダーに保持している内容をKINGET用得意先請求金額マスタにコピーします。</br>
		/// <br>Programmer : 18023 樋口　政成</br>
		/// <br>Date       : 2005.07.21</br>		
		private void SetKingetCustDmdPrcWorkFromCustomerDataReader(ref KingetCustDmdPrcWork kingetCustDmdPrcWork, SqlDataReader myReader)
		{
            // ↓ 2007.12.21 980081 c
            #region 旧レイアウト(コメントアウト)
            //kingetCustDmdPrcWork.CustomerCode		= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("CUSTOMERCODERF"		));
			//kingetCustDmdPrcWork.Name				= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("NAMERF"				));
			//kingetCustDmdPrcWork.Name2				= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("NAME2RF"			));
			//kingetCustDmdPrcWork.HonorificTitle		= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("HONORIFICTITLERF"	));
			//kingetCustDmdPrcWork.Kana				= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("KANARF"				));
			//kingetCustDmdPrcWork.OutputNameCode		= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("OUTPUTNAMECODERF"	));
			//kingetCustDmdPrcWork.OutputName			= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("OUTPUTNAMERF"		));
			//kingetCustDmdPrcWork.CorporateDivCode	= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("CORPORATEDIVCODERF"	));
			//kingetCustDmdPrcWork.PostNo				= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("POSTNORF"			));
			//kingetCustDmdPrcWork.Address1			= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("ADDRESS1RF"			));
			//kingetCustDmdPrcWork.Address2			= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("ADDRESS2RF"			));
			//kingetCustDmdPrcWork.Address3			= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("ADDRESS3RF"			));
			//kingetCustDmdPrcWork.Address4			= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("ADDRESS4RF"			));
			//kingetCustDmdPrcWork.HomeTelNo			= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("HOMETELNORF"		));
			//kingetCustDmdPrcWork.OfficeTelNo		= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("OFFICETELNORF"		));
			//kingetCustDmdPrcWork.PortableTelNo		= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("PORTABLETELNORF"	));
			//// 2006.04.21 ADD START 樋口　政成
			//kingetCustDmdPrcWork.HomeFaxNo			= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("HOMEFAXNORF"		));
			//kingetCustDmdPrcWork.OfficeFaxNo		= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("OFFICEFAXNORF"		));
			//kingetCustDmdPrcWork.OthersTelNo		= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("OTHERSTELNORF"		));
			//kingetCustDmdPrcWork.MainContactCode	= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("MAINCONTACTCODERF"	));
			//// 2006.04.21 ADD END 樋口　政成
			//// 2006.09.06 ADD START 樋口　政成
			//kingetCustDmdPrcWork.CustAnalysCode1	= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("CUSTANALYSCODE1RF"	));
			//kingetCustDmdPrcWork.CustAnalysCode2	= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("CUSTANALYSCODE2RF"	));
			//kingetCustDmdPrcWork.CustAnalysCode3	= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("CUSTANALYSCODE3RF"	));
			//kingetCustDmdPrcWork.CustAnalysCode4	= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("CUSTANALYSCODE4RF"	));
			//kingetCustDmdPrcWork.CustAnalysCode5	= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("CUSTANALYSCODE5RF"	));
			//kingetCustDmdPrcWork.CustAnalysCode6	= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("CUSTANALYSCODE6RF"	));
			//// 2006.09.06 ADD END 樋口　政成
			//kingetCustDmdPrcWork.TotalDay			= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("TOTALDAYRF"			));
			//kingetCustDmdPrcWork.CollectMoneyName	= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("COLLECTMONEYNAMERF"	));
			//kingetCustDmdPrcWork.CollectMoneyDay	= SqlDataMediator.SqlGetInt32	(myReader, myReader.GetOrdinal("COLLECTMONEYDAYRF"	));
			//kingetCustDmdPrcWork.CustomerAgentCd	= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("CUSTOMERAGENTCDRF"	));
			//kingetCustDmdPrcWork.CustomerAgentNm	= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("CUSTOMERAGENTNMRF"	));
			//kingetCustDmdPrcWork.BillCollecterCd	= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("BILLCOLLECTERCDRF"	));
			//kingetCustDmdPrcWork.BillCollecterNm	= SqlDataMediator.SqlGetString	(myReader, myReader.GetOrdinal("BILLCOLLECTERNMRF"	));
            #endregion
            kingetCustDmdPrcWork.ClaimCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLAIMCODERF"));
            kingetCustDmdPrcWork.ClaimName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMNAMERF"));
            kingetCustDmdPrcWork.ClaimName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMNAME2RF"));
            kingetCustDmdPrcWork.ClaimSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMSNMRF"));
            kingetCustDmdPrcWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
            kingetCustDmdPrcWork.CustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAMERF"));
            kingetCustDmdPrcWork.CustomerName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAME2RF"));
            kingetCustDmdPrcWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
            kingetCustDmdPrcWork.HonorificTitle = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("HONORIFICTITLERF"));
            kingetCustDmdPrcWork.Kana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("KANARF"));
            kingetCustDmdPrcWork.OutputNameCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OUTPUTNAMECODERF"));
            kingetCustDmdPrcWork.OutputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTPUTNAMERF"));
            kingetCustDmdPrcWork.CorporateDivCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CORPORATEDIVCODERF"));
            kingetCustDmdPrcWork.PostNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("POSTNORF"));
            kingetCustDmdPrcWork.Address1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS1RF"));
            //kingetCustDmdPrcWork.Address2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDRESS2RF"));  //DEL 2008/04/25 M.Kubota
            kingetCustDmdPrcWork.Address3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS3RF"));
            kingetCustDmdPrcWork.Address4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESS4RF"));
            kingetCustDmdPrcWork.HomeTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("HOMETELNORF"));
            kingetCustDmdPrcWork.OfficeTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OFFICETELNORF"));
            kingetCustDmdPrcWork.PortableTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PORTABLETELNORF"));
            kingetCustDmdPrcWork.HomeFaxNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("HOMEFAXNORF"));
            kingetCustDmdPrcWork.OfficeFaxNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OFFICEFAXNORF"));
            kingetCustDmdPrcWork.OthersTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OTHERSTELNORF"));
            kingetCustDmdPrcWork.MainContactCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("MAINCONTACTCODERF"));
            kingetCustDmdPrcWork.CustAnalysCode1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE1RF"));
            kingetCustDmdPrcWork.CustAnalysCode2 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE2RF"));
            kingetCustDmdPrcWork.CustAnalysCode3 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE3RF"));
            kingetCustDmdPrcWork.CustAnalysCode4 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE4RF"));
            kingetCustDmdPrcWork.CustAnalysCode5 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE5RF"));
            kingetCustDmdPrcWork.CustAnalysCode6 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTANALYSCODE6RF"));
            kingetCustDmdPrcWork.TotalDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALDAYRF"));
            kingetCustDmdPrcWork.CollectMoneyCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTMONEYCODERF"));
            kingetCustDmdPrcWork.CollectMoneyName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("COLLECTMONEYNAMERF"));
            kingetCustDmdPrcWork.CollectMoneyDay = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COLLECTMONEYDAYRF"));
            kingetCustDmdPrcWork.CustomerAgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERAGENTCDRF"));
            kingetCustDmdPrcWork.CustomerAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERAGENTNMRF"));
            kingetCustDmdPrcWork.BillCollecterCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BILLCOLLECTERCDRF"));
            kingetCustDmdPrcWork.BillCollecterNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BILLCOLLECTERNMRF"));
            kingetCustDmdPrcWork.OldCustomerAgentCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OLDCUSTOMERAGENTCDRF"));
            kingetCustDmdPrcWork.OldCustomerAgentNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OLDCUSTOMERAGENTNMRF"));
            kingetCustDmdPrcWork.CustAgentChgDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("CUSTAGENTCHGDATERF"));
            // ↑ 2007.12.21 980081 c
		}


        /// <summary>
        /// 請求金額情報設定
        /// </summary>
        /// <param name="kingetCustDmdPrcWork">KINGET用得意先請求金額情報</param>
        /// <param name="custDmdPrcWork">請求情報</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : 請求情報の内容をKINGET用得意先請求金額情報に設定します。</br>
        /// <br>Programmer : 18322 木村 武正</br>
        /// <br>Date       : 2007.04.17</br>
        private void SetKingetDmdPrcInfo(ref KingetCustDmdPrcWork   kingetCustDmdPrcWork
                                        ,ref CustDmdPrcWork         custDmdPrcWork)
        {
            // 計上年月日
            kingetCustDmdPrcWork.AddUpDate      = custDmdPrcWork.AddUpDate;
            // 計上年月
            kingetCustDmdPrcWork.AddUpYearMonth = custDmdPrcWork.AddUpYearMonth;

            // ↓ 2007.12.21 980081 c
            #region 旧レイアウト(コメントアウト)
            //// 前回請求金額
            //kingetCustDmdPrcWork.LastTimeDemand = custDmdPrcWork.LastTimeDemand;
            //// 今回入金金額（通常入金）
            //kingetCustDmdPrcWork.ThisTimeDmdNrml = custDmdPrcWork.ThisTimeDmdNrml;
            //// 今回手数料額（通常入金）
            //kingetCustDmdPrcWork.ThisTimeFeeDmdNrml = custDmdPrcWork.ThisTimeFeeDmdNrml;
            //// 今回値引額（通常入金）
            //kingetCustDmdPrcWork.ThisTimeDisDmdNrml = custDmdPrcWork.ThisTimeDisDmdNrml;
            //// 今回リベート額（通常入金）
            //kingetCustDmdPrcWork.ThisTimeRbtDmdNrml = custDmdPrcWork.ThisTimeRbtDmdNrml;
            //// 今回入金金額（預り金）
            //kingetCustDmdPrcWork.ThisTimeDmdDepo = custDmdPrcWork.ThisTimeDmdDepo;
            //// 今回手数料額（預り金）
            //kingetCustDmdPrcWork.ThisTimeFeeDmdDepo = custDmdPrcWork.ThisTimeFeeDmdDepo;
            //// 今回値引額（預り金）
            //kingetCustDmdPrcWork.ThisTimeDisDmdDepo = custDmdPrcWork.ThisTimeDisDmdDepo;
            //// 今回リベート額（預り金）
            //kingetCustDmdPrcWork.ThisTimeRbtDmdDepo = custDmdPrcWork.ThisTimeRbtDmdDepo;
            //// 今回繰越残高（請求計）
            //kingetCustDmdPrcWork.ThisTimeTtlBlcDmd = custDmdPrcWork.ThisTimeTtlBlcDmd;
            //// 今回売上金額
            //kingetCustDmdPrcWork.ThisTimeSales = custDmdPrcWork.ThisTimeSales;
            //// 今回売上消費税
            //kingetCustDmdPrcWork.ThisSalesTax = custDmdPrcWork.ThisSalesTax;
            //// 支払インセンティブ額合計（税抜き）
            //kingetCustDmdPrcWork.TtlIncDtbtTaxExc = custDmdPrcWork.TtlIncDtbtTaxExc;
            //// 支払インセンティブ額合計（税）
            //kingetCustDmdPrcWork.TtlIncDtbtTax = custDmdPrcWork.TtlIncDtbtTax;
            //// 相殺後今回売上金額
            //kingetCustDmdPrcWork.OfsThisTimeSales = custDmdPrcWork.OfsThisTimeSales;
            //// 相殺後今回売上消費税
            //kingetCustDmdPrcWork.OfsThisSalesTax = custDmdPrcWork.OfsThisSalesTax;
            //// 相殺後外税対象額
            //kingetCustDmdPrcWork.ItdedOffsetOutTax = custDmdPrcWork.ItdedOffsetOutTax;
            //// 相殺後内税対象額
            //kingetCustDmdPrcWork.ItdedOffsetInTax = custDmdPrcWork.ItdedOffsetInTax;
            //// 相殺後非課税対象額
            //kingetCustDmdPrcWork.ItdedOffsetTaxFree = custDmdPrcWork.ItdedOffsetTaxFree;
            //// 相殺後外税消費税
            //kingetCustDmdPrcWork.OffsetOutTax = custDmdPrcWork.OffsetOutTax;
            //// 相殺後内税消費税
            //kingetCustDmdPrcWork.OffsetInTax = custDmdPrcWork.OffsetInTax;
            //// 売上外税対象額
            //kingetCustDmdPrcWork.ItdedSalesOutTax = custDmdPrcWork.ItdedSalesOutTax;
            //// 売上内税対象額
            //kingetCustDmdPrcWork.ItdedSalesInTax = custDmdPrcWork.ItdedSalesInTax;
            //// 売上非課税対象額
            //kingetCustDmdPrcWork.ItdedSalesTaxFree = custDmdPrcWork.ItdedSalesTaxFree;
            //// 売上外税額
            //kingetCustDmdPrcWork.SalesOutTax = custDmdPrcWork.SalesOutTax;
            //// 売上内税額
            //kingetCustDmdPrcWork.SalesInTax = custDmdPrcWork.SalesInTax;
            //// 支払外税対象額
            //kingetCustDmdPrcWork.ItdedPaymOutTax = custDmdPrcWork.ItdedPaymOutTax;
            //// 支払内税対象額
            //kingetCustDmdPrcWork.ItdedPaymInTax = custDmdPrcWork.ItdedPaymInTax;
            //// 支払非課税対象額
            //kingetCustDmdPrcWork.ItdedPaymTaxFree = custDmdPrcWork.ItdedPaymTaxFree;
            //// 支払外税消費税
            //kingetCustDmdPrcWork.PaymentOutTax = custDmdPrcWork.PaymentOutTax;
            //// 支払内税消費税
            //kingetCustDmdPrcWork.PaymentInTax = custDmdPrcWork.PaymentInTax;
            //// 消費税転嫁方式
            //kingetCustDmdPrcWork.ConsTaxLayMethod = custDmdPrcWork.ConsTaxLayMethod;
            //// 消費税率
            //kingetCustDmdPrcWork.ConsTaxRate = custDmdPrcWork.ConsTaxRate;
            //// 端数処理区分
            //kingetCustDmdPrcWork.FractionProcCd = custDmdPrcWork.FractionProcCd;
            //// 計算後請求金額
            //kingetCustDmdPrcWork.AfCalDemandPrice = custDmdPrcWork.AfCalDemandPrice;
            //// 受注2回前残高（請求計）
            //kingetCustDmdPrcWork.AcpOdrTtl2TmBfBlDmd = custDmdPrcWork.AcpOdrTtl2TmBfBlDmd;
            //// 受注3回前残高（請求計）
            //kingetCustDmdPrcWork.AcpOdrTtl3TmBfBlDmd = custDmdPrcWork.AcpOdrTtl3TmBfBlDmd;
            //// 締次更新実行年月日
            //kingetCustDmdPrcWork.CAddUpUpdExecDate = custDmdPrcWork.CAddUpUpdExecDate;
            //
            //// 請求処理通番
            //kingetCustDmdPrcWork.DmdProcNum = custDmdPrcWork.DmdProcNum;
            //// 締次更新開始年月日
            //kingetCustDmdPrcWork.StartCAddUpUpdDate = custDmdPrcWork.StartCAddUpUpdDate;
            //// 前回締次更新年月日
            //kingetCustDmdPrcWork.LastCAddUpUpdDate = custDmdPrcWork.LastCAddUpUpdDate;
            //
            //// 今回入金計（通常入金）
            //kingetCustDmdPrcWork.ThisTimeDmdNrmlTtl = kingetCustDmdPrcWork.ThisTimeDmdNrml
            //                                        + kingetCustDmdPrcWork.ThisTimeFeeDmdNrml
            //                                        + kingetCustDmdPrcWork.ThisTimeDisDmdNrml
            //                                        + kingetCustDmdPrcWork.ThisTimeRbtDmdNrml;
            //// 今回入金計（預り金）
            //kingetCustDmdPrcWork.ThisTimeDmdDepoTtl = kingetCustDmdPrcWork.ThisTimeDmdDepo
            //                                        + kingetCustDmdPrcWork.ThisTimeFeeDmdDepo
            //                                        + kingetCustDmdPrcWork.ThisTimeDisDmdDepo
            //                                        + kingetCustDmdPrcWork.ThisTimeRbtDmdDepo;
            //// 今回入金計
            //kingetCustDmdPrcWork.ThisTimeDmdTtl     = kingetCustDmdPrcWork.ThisTimeDmdNrmlTtl
            //                                        + kingetCustDmdPrcWork.ThisTimeDmdDepoTtl;
            #endregion
            kingetCustDmdPrcWork.LastTimeDemand = custDmdPrcWork.LastTimeDemand;
            kingetCustDmdPrcWork.ThisTimeFeeDmdNrml = custDmdPrcWork.ThisTimeFeeDmdNrml;
            kingetCustDmdPrcWork.ThisTimeDisDmdNrml = custDmdPrcWork.ThisTimeDisDmdNrml;
            kingetCustDmdPrcWork.ThisTimeDmdNrml = custDmdPrcWork.ThisTimeDmdNrml;
            kingetCustDmdPrcWork.ThisTimeTtlBlcDmd = custDmdPrcWork.ThisTimeTtlBlcDmd;
            kingetCustDmdPrcWork.OfsThisTimeSales = custDmdPrcWork.OfsThisTimeSales;
            kingetCustDmdPrcWork.OfsThisSalesTax = custDmdPrcWork.OfsThisSalesTax;
            kingetCustDmdPrcWork.ItdedOffsetOutTax = custDmdPrcWork.ItdedOffsetOutTax;
            kingetCustDmdPrcWork.ItdedOffsetInTax = custDmdPrcWork.ItdedOffsetInTax;
            kingetCustDmdPrcWork.ItdedOffsetTaxFree = custDmdPrcWork.ItdedOffsetTaxFree;
            kingetCustDmdPrcWork.OffsetOutTax = custDmdPrcWork.OffsetOutTax;
            kingetCustDmdPrcWork.OffsetInTax = custDmdPrcWork.OffsetInTax;
            kingetCustDmdPrcWork.ThisTimeSales = custDmdPrcWork.ThisTimeSales;
            kingetCustDmdPrcWork.ThisSalesTax = custDmdPrcWork.ThisSalesTax;
            kingetCustDmdPrcWork.ItdedSalesOutTax = custDmdPrcWork.ItdedSalesOutTax;
            kingetCustDmdPrcWork.ItdedSalesInTax = custDmdPrcWork.ItdedSalesInTax;
            kingetCustDmdPrcWork.ItdedSalesTaxFree = custDmdPrcWork.ItdedSalesTaxFree;
            kingetCustDmdPrcWork.SalesOutTax = custDmdPrcWork.SalesOutTax;
            kingetCustDmdPrcWork.SalesInTax = custDmdPrcWork.SalesInTax;
            kingetCustDmdPrcWork.ThisSalesPricRgds = custDmdPrcWork.ThisSalesPricRgds;
            kingetCustDmdPrcWork.ThisSalesPrcTaxRgds = custDmdPrcWork.ThisSalesPrcTaxRgds;
            kingetCustDmdPrcWork.TtlItdedRetOutTax = custDmdPrcWork.TtlItdedRetOutTax;
            kingetCustDmdPrcWork.TtlItdedRetInTax = custDmdPrcWork.TtlItdedRetInTax;
            kingetCustDmdPrcWork.TtlItdedRetTaxFree = custDmdPrcWork.TtlItdedRetTaxFree;
            kingetCustDmdPrcWork.TtlRetOuterTax = custDmdPrcWork.TtlRetOuterTax;
            kingetCustDmdPrcWork.TtlRetInnerTax = custDmdPrcWork.TtlRetInnerTax;
            kingetCustDmdPrcWork.ThisSalesPricDis = custDmdPrcWork.ThisSalesPricDis;
            kingetCustDmdPrcWork.ThisSalesPrcTaxDis = custDmdPrcWork.ThisSalesPrcTaxDis;
            kingetCustDmdPrcWork.TtlItdedDisOutTax = custDmdPrcWork.TtlItdedDisOutTax;
            kingetCustDmdPrcWork.TtlItdedDisInTax = custDmdPrcWork.TtlItdedDisInTax;
            kingetCustDmdPrcWork.TtlItdedDisTaxFree = custDmdPrcWork.TtlItdedDisTaxFree;
            kingetCustDmdPrcWork.TtlDisOuterTax = custDmdPrcWork.TtlDisOuterTax;
            kingetCustDmdPrcWork.TtlDisInnerTax = custDmdPrcWork.TtlDisInnerTax;
            //--- DEL 2008/04/25 M.Kubota --->>>            
            //kingetCustDmdPrcWork.ThisPayOffset = custDmdPrcWork.ThisPayOffset;
            //kingetCustDmdPrcWork.ThisPayOffsetTax = custDmdPrcWork.ThisPayOffsetTax;
            //kingetCustDmdPrcWork.ItdedPaymOutTax = custDmdPrcWork.ItdedPaymOutTax;
            //kingetCustDmdPrcWork.ItdedPaymInTax = custDmdPrcWork.ItdedPaymInTax;
            //kingetCustDmdPrcWork.ItdedPaymTaxFree = custDmdPrcWork.ItdedPaymTaxFree;
            //kingetCustDmdPrcWork.PaymentOutTax = custDmdPrcWork.PaymentOutTax;
            //kingetCustDmdPrcWork.PaymentInTax = custDmdPrcWork.PaymentInTax;
            //--- DEL 2008/04/25 M.Kubota ---<<<
            kingetCustDmdPrcWork.TaxAdjust = custDmdPrcWork.TaxAdjust;
            kingetCustDmdPrcWork.BalanceAdjust = custDmdPrcWork.BalanceAdjust;
            kingetCustDmdPrcWork.AfCalDemandPrice = custDmdPrcWork.AfCalDemandPrice;
            kingetCustDmdPrcWork.AcpOdrTtl2TmBfBlDmd = custDmdPrcWork.AcpOdrTtl2TmBfBlDmd;
            kingetCustDmdPrcWork.AcpOdrTtl3TmBfBlDmd = custDmdPrcWork.AcpOdrTtl3TmBfBlDmd;
            kingetCustDmdPrcWork.CAddUpUpdExecDate = custDmdPrcWork.CAddUpUpdExecDate;
            kingetCustDmdPrcWork.StartCAddUpUpdDate = custDmdPrcWork.StartCAddUpUpdDate;
            kingetCustDmdPrcWork.LastCAddUpUpdDate = custDmdPrcWork.LastCAddUpUpdDate;
            kingetCustDmdPrcWork.SalesSlipCount = custDmdPrcWork.SalesSlipCount;
            kingetCustDmdPrcWork.BillPrintDate = custDmdPrcWork.BillPrintDate;
            kingetCustDmdPrcWork.ExpectedDepositDate = custDmdPrcWork.ExpectedDepositDate;
            kingetCustDmdPrcWork.CollectCond = custDmdPrcWork.CollectCond;
            kingetCustDmdPrcWork.ConsTaxLayMethod = custDmdPrcWork.ConsTaxLayMethod;
            kingetCustDmdPrcWork.ConsTaxRate = custDmdPrcWork.ConsTaxRate;
            kingetCustDmdPrcWork.FractionProcCd = custDmdPrcWork.FractionProcCd;
            // ↑ 2007.12.21 980081 c

            // 期間の開始に計上年月日(相手先の請求締日)の次の日をセット
            if (custDmdPrcWork.StartCAddUpUpdDate == DateTime.MinValue)
            {
                // 締めを１度も行っていない場合
                kingetCustDmdPrcWork.StartDateSpan = TDateTime.DateTimeToLongDate(DateTime.MinValue);

                kingetCustDmdPrcWork.EndDateSpan = TDateTime.DateTimeToLongDate(custDmdPrcWork.AddUpDate);
            }
            else
            {
                // 前回に締めを行っている場合
                kingetCustDmdPrcWork.StartDateSpan = TDateTime.DateTimeToLongDate(custDmdPrcWork.StartCAddUpUpdDate);

                // 日付範囲（終了）
                if (DateTime.DaysInMonth(custDmdPrcWork.LastCAddUpUpdDate.Year, custDmdPrcWork.LastCAddUpUpdDate.Month) == custDmdPrcWork.LastCAddUpUpdDate.Day)
                {
                    // 前回月末で締め処理したときは、今回も月末にする。
                    DateTime dt = custDmdPrcWork.LastCAddUpUpdDate.AddMonths(1);
                    kingetCustDmdPrcWork.EndDateSpan  = TDateTime.DateTimeToLongDate(dt);
                    kingetCustDmdPrcWork.EndDateSpan = Convert.ToInt32(Math.Truncate(Convert.ToDouble(kingetCustDmdPrcWork.EndDateSpan / 100)));
                    kingetCustDmdPrcWork.EndDateSpan = kingetCustDmdPrcWork.EndDateSpan * 100;
                    kingetCustDmdPrcWork.EndDateSpan += DateTime.DaysInMonth(dt.Year, dt.Month);
                }
                else
                {
                    // 月末以外で締め処理
                    kingetCustDmdPrcWork.EndDateSpan = TDateTime.DateTimeToLongDate(custDmdPrcWork.LastCAddUpUpdDate.AddMonths(1));
                }
            }
        }


		/// <summary>
		/// 文字列追加処理
		/// </summary>
		/// <param name="target">対象文字列</param>
		/// <param name="value">付加文字</param>
		/// <param name="length">対象文字列の最大文字数</param>
		/// <returns>追加後文字列</returns>
		/// <br>Note       : 対象文字列に対して最大文字数に達するまで付加文字を追加します。</br>
		/// <br>Programmer : 18023 樋口　政成</br>
		/// <br>Date       : 2005.07.21</br>		
		private string StringAppendLength(string target, char value, int length)
		{
			System.Text.StringBuilder sb = new StringBuilder(target);
			for (int index = sb.Length; index < length; index++)
			{
				sb.Append(value);
			}
			return sb.ToString();
		}

        //--- DEL 2008/07/10 M.Kubota --->>>
        ///// <summary>
        ///// SQL暗号化情報クラス生成＆暗号化キーＯＰＥＮ
        ///// </summary>
        ///// <returns></returns>
        ///// <br>Note       : SQL暗号化情報クラスを生成し、暗号化キーをＯＰＥＮします。</br>
        ///// <br>Programmer : 18023 樋口　政成</br>
        ///// <br>Date       : 2006.08.22</br>
        //private SqlEncryptInfo OpenSqlEncryptInfo(ref SqlConnection sqlConnection)
        //{
        //    SqlEncryptInfo sqlEncryptInfo = new SqlEncryptInfo(ConstantManagement_SF_PRO.IndexCode_UserDB, new string[] {"CUSTOMERRF"});
        //    sqlEncryptInfo.OpenSymKey(ref sqlConnection);
        //    return sqlEncryptInfo;
        //}
        //--- DEL 2008/07/10 M.Kubota ---<<<

		#endregion
	}
}
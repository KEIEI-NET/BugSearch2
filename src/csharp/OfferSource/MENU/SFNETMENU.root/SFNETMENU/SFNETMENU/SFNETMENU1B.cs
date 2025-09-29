using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Management;
using System.Collections;
using Microsoft.Win32;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Threading;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using UBAU.Remoting;
using UBAU.Data;
using System.Collections.Generic;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// メニューサーバー情報クラス
    /// <br></br>
    /// <br>Update Note: 製品コード追加</br>
    /// <br>Programmer : 23002 上野 耕平</br>
    /// <br>Date       : 2008.04.04</br>
    /// <br></br>
    /// <br>Update Note: Felica対応（従業員ログイン）</br>
    /// <br>Programmer : 23002 上野 耕平</br>
    /// <br>Date       : 2008.11.14</br>
    /// <br></br>
    /// <br>Update Note: ヘルプページＵＲＬ取得方法変更（認証から取得）</br>
    /// <br>Programmer : 23002 上野 耕平</br>
    /// <br>Date       : 2008.12.09</br>
    /// <br></br>
    /// <br>Update Note: PM.NS対応 FeliCaログインオプションの組み込み</br>
    /// <br>Programmer : 22018 鈴木 正臣</br>
    /// <br>Date       : 2010/04/06</br>
    /// </summary>
	public class SfNetMenuServerInfo
	{
		#region コンスト定義(ｸﾗｲｱﾝﾄｻｰﾊﾞｰKEY)
		private const string _const_LocalAccessToken		= "LocalAccessToken";
		private const string _const_CompanyAuthInfoWork		= "CompanyAuthInfoWork";
		private const string _const_EmployeeAuthInfoWork	= "EmployeeAuthInfoWork";
		private const string _const_ClientAuthInfoWork		= "ClientAuthInfoWork";
		private const string _const_OnlineFlag				= "OnlineFlag";
        private const string _const_RequiredServerVersion   = "RequiredServerVersion";
		#endregion

		#region コンスト定義(その他)
		/// <summary>オフラインhtml格納フォルダ</summary>
		private const string _const_MenuOfflineDir			= "html";
		/// <summary>オフラインIndexファイル</summary>
		private const string _const_MenuOfflineIndex		= "SFNETMENUOFFLINEINDEX.html";
		#endregion

		#region プライベートメンバ　サーバー情報
		/// <summary>ローカルサーバーデフォルトポート</summary>
		private Int32 _pMCPortNo = 0;
		/// <summary>ローカルサーバードメイン</summary>
		private string _pMCDomain = "tcp://localhost:";
		#endregion

		#region プライベートメンバ　ログイン情報
		private CompanyAuthInfoWork _companyAuthInfoWork		= null;		//企業情報
		private EmployeeAuthInfoWork _employeeAuthInfoWork		= null;		//従業員情報
		private ClientAuthInfoWork _clientAuthInfoWork			= null;		//クライアント情報
        //private EmployeeLoginFormAF _employeeLoginForm			= null;		//従業員ログイン画面
        private EmployeeLoginFormEx _employeeLoginForm = null;		//従業員ログイン画面
		private string _version									= null;		//製品バージョン
		private string _versionPMC								= null;		//PMCバージョン
		private bool _onlineFlag								= false;	//オンラインフラグ
		private string _serverDomain							= null;		//従業員ログインサーバー接続用ドメイン
		private string _topPage									= null;		//トップメニューアドレス
		private string _companyLoginMutexKey					= null;		//企業ログインMutexキー
		private IRemoteService _remoteService					= null;		//製品管理クライアントサーバー		
		private ExclusionService _exclusionService				= null;		//企業ログインMutexチェック用		
		private event System.EventHandler _applicationReleased	= null;		//Menu破棄呼び出し用
        private Int32 _requiredServerVersion                    = -1;       //サーバーバージョン比較用

        // --- DEL m.suzuki 2010/04/06 ---------->>>>>
        //// 2008.12.09 UENO ADD STA
        //private string _helpPage                                = null;		//ヘルプページアドレス
        //// 2008.12.09 UENO ADD END
        // --- DEL m.suzuki 2010/04/06 ----------<<<<<
        // --- ADD m.suzuki 2009/00/00 ---------->>>>>
        private static Dictionary<string, object> _ServerVersionTable = null;
        // --- ADD m.suzuki 2009/00/00 ----------<<<<<

		#endregion

        #region プライベートメンバ アドオン情報
        //↓↓↓↓↓↓↓ 2007.03.23 ADD 上野 ↓↓↓↓↓↓↓↓
        private SfNetMenuAddOnInfo _sfNetMenuAddOnInfo = null;
        //↑↑↑↑↑↑↑ 2007.03.23 ADD 上野 ↑↑↑↑↑↑↑↑
        #endregion

        #region プロパティ
        /// <summary>
		/// ローカルサーバーデフォルトポート プロパティ
		/// </summary>
		public Int32 PMCPortNo
		{
			set{_pMCPortNo = value;}
			get{return _pMCPortNo ;}
		}
		
		/// <summary>
		/// ローカルサーバードメイン プロパティ
		/// </summary>
		public string PMCDomain
		{
			get{return _pMCDomain ;}
		}

		/// <summary>
		/// 製品バージョン プロパティ
		/// </summary>
		public string Version
		{
			get{return _version;}
		}

		/// <summary>
		/// オンラインフラグ プロパティ
		/// </summary>
		public bool OnlineFlag
		{
			get{return _onlineFlag ;}
		}

		/// <summary>
		/// オンラインText プロパティ
		/// </summary>
		public string OnlineText
		{
			get{ if(_onlineFlag) return "Online";
				 else			 return "Offline";}
		}


		/// <summary>
		/// ログインフラグ
		/// </summary>
		public bool LoginFlag
		{
			//ミューテックスの有無でログイン状態を戻す
			get{if (_employeeAuthInfoWork != null)	return true;
				else								return false;}
		}

		/// <summary>
		/// トップページアドレス
		/// </summary>
		public string TopPage
		{
			get{return _topPage;}
		}

		/// <summary>
		/// アクセスチケット
		/// </summary>
		public string AccessTicket
		{
			get{if (_companyAuthInfoWork != null)	return _companyAuthInfoWork.AccessTicket;
				else								return "";}
		}

		/// <summary>
		/// 企業ログイン情報
		/// </summary>
		public CompanyAuthInfoWork CompanyAuthInfoWork
		{
			get{return _companyAuthInfoWork;}
		}

		/// <summary>
		/// ログイン従業員名称
		/// </summary>
		public string EmployeeName
		{
			get
			{
				if (_employeeAuthInfoWork == null ||
					_employeeAuthInfoWork.EmployeeWork == null) return "未ログイン";
				else											return _employeeAuthInfoWork.EmployeeWork.Name;
			}
		}
        // 2008.04.04 UENO ADD STA
        /// <summary>
        /// 製品コード
        /// </summary>
        public string ProductCode
        {
            get
            {
                if( _companyAuthInfoWork != null && _companyAuthInfoWork.ProductInfoWork != null )
                    return _companyAuthInfoWork.ProductInfoWork.ProductCode;
                else
                    // --- UPD m.suzuki 2010/04/06 ---------->>>>>
                    //return "Superfrontman";
                    return "Partsman";
                    // --- UPD m.suzuki 2010/04/06 ----------<<<<<
            }
        }
        // 2008.04.04 UENO ADD END
		/// <summary>
		/// 製品名称
		/// </summary>
		public string ProductName
		{
			get
			{
				if (_companyAuthInfoWork != null && _companyAuthInfoWork.ProductInfoWork != null)	return _companyAuthInfoWork.ProductInfoWork.ProductName;
                // --- UPD m.suzuki 2010/04/06 ---------->>>>>
                //else																				return "Superfrontman";
				else																				return "Partsman";
                // --- UPD m.suzuki 2010/04/06 ----------<<<<<
			}
		}
		/// <summary>
		/// ログイン従業員コード
		/// </summary>
		public string EmployeeCode
		{
			get
			{
				if (_employeeAuthInfoWork == null ||
					_employeeAuthInfoWork.EmployeeWork == null) return "";
				else											return _employeeAuthInfoWork.EmployeeWork.EmployeeCode;
			}
		}

        /// <summary>
        /// RequiredServerVersion
        /// </summary>
        public Int32 RequiredServerVersion
        {
            get { return _requiredServerVersion; }
        }

        // --- DEL m.suzuki 2010/04/06 ---------->>>>>
        //// 2008.12.09 UENO ADD STA
        ///// <summary>
        ///// ヘルプページアドレス
        ///// </summary>
        //public string HelpPage
        //{
        //    get { return _helpPage; }
        //    set { _helpPage = value; }
        //}
        //// 2008.12.09 UENO ADD END
        // --- DEL m.suzuki 2010/04/06 ----------<<<<<
		#endregion


		/// <summary>
		/// コンストラクタ
		/// </summary>
		public SfNetMenuServerInfo()
		{
			//製品管理クライアントリモーティング接続用ポート番号取得
			_pMCPortNo	= GetPMCPorNo();
			//プロダクト配信バージョンを取得
			_version	= GetProductVersion(ConstantManagement_SF_PRO.ProductCode);
			_versionPMC	= GetProductVersion("PMC");
			//製品管理クライアントに企業ログイン情報を取得しにいく
			_remoteService = (IRemoteService)Activator.GetObject(typeof(IRemoteService),string.Format("{0}{1}/{2}",_pMCDomain,_pMCPortNo,UBAU.Remoting.ServiceName.Name));
        }

        #region パブリックメソッド（メニュー情報）
        /// <summary>
		/// 企業ログイン初期処理
		/// </summary>
		/// <remarks>製品管理クライアントから企業ログイン情報を取得します</remarks>
		/// <param rKeyName="ProcessId">プロセスID</param>
		/// <param rKeyName="retMsg">リターンメッセージ</param>
		/// <param rKeyName="eventHandler">企業ログオフイベントハンドラ</param>
		/// <returns>STATUS 0:企業従業員ログイン済み  4:企業ログイン済み  9:未企業ログイン</returns>
		public Int32 CompanyLoginInitial(Int32 ProcessId,out string retMsg,EventHandler eventHandler)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			retMsg = "";

            string[] keyData = { _const_LocalAccessToken, _const_CompanyAuthInfoWork, _const_EmployeeAuthInfoWork, _const_ClientAuthInfoWork, _const_RequiredServerVersion};
			Hashtable hash;
			string[] param;
			int remoteStatus = -1;
			try
			{
				remoteStatus = _remoteService.GetLoginInfo(ConstantManagement_SF_PRO.ProductCode,ProcessId,keyData,out param,out hash);
			}
			catch(Exception)
			{
				retMsg = "製品管理クライアントを起動し企業ログインを行ってください。";
				return status;
			}

			if (remoteStatus == 0)
			{
				//正常にログイン情報が取得出来なかった場合は
				if (param == null || param.Length == 0)
				{
					retMsg = "製品管理クライアントにて企業ログインを行ってください。";
					return status;
				}
				//パラメータ情報をクラスに展開
				try
				{
					GetPara(param);
				}
				catch(Exception ex)
				{
					retMsg = ex.Message;
					return status;
				}

				//企業情報がAccessTokenしか入っていない場合には企業情報をSF用クラスにコピーし保存
				//企業ログイン情報を取得
				LocalAccessToken	token					= null;
				byte[]				bCompanyAuthInfoWork	= null;
				byte[]				bEmployeeAuthInfoWork	= null;
				byte[]				bClientAuthInfoWork		= null;
                Int32               requiredServerVersion   = -1;
				if (hash.ContainsKey(_const_LocalAccessToken))		token					= hash[_const_LocalAccessToken]		as LocalAccessToken;
				if (hash.ContainsKey(_const_CompanyAuthInfoWork))	bCompanyAuthInfoWork	= hash[_const_CompanyAuthInfoWork]	as byte[];
				if (hash.ContainsKey(_const_EmployeeAuthInfoWork))	bEmployeeAuthInfoWork	= hash[_const_EmployeeAuthInfoWork]	as byte[];
				if (hash.ContainsKey(_const_ClientAuthInfoWork))	bClientAuthInfoWork		= hash[_const_ClientAuthInfoWork]	as byte[];
                if (hash.ContainsKey(_const_RequiredServerVersion)) requiredServerVersion   = (Int32)hash[_const_RequiredServerVersion];

				//正常にトークンが取得出来た場合
				if (token != null)
				{
					ArrayList setDataKey	= new ArrayList();
					ArrayList setDataValue	= new ArrayList();
					//トークンが取得出来たということは最低限企業認証は終了している（STATUS=4をセット）
					status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
					//企業情報が既に格納されている場合
					if (bCompanyAuthInfoWork != null)
					{
						//格納企業情報をコピー
						_companyAuthInfoWork = CustomFormatterDeSerialize(bCompanyAuthInfoWork,typeof(CompanyAuthInfoWork)) as CompanyAuthInfoWork;
						if (_companyAuthInfoWork == null)
						{
							throw new Exception( "企業ログイン情報構成にエラーが出ました。クライアント環境が不正です。",null);
						}
					}
					else 
					{
						//企業ログイン情報をTOKENから設定
						_companyAuthInfoWork = MakeCompanyAuthInfoWork(token);
						setDataKey.Add(_const_CompanyAuthInfoWork);
						object oCompanyAuthInfoWork = CustomFormatterSerialize(_companyAuthInfoWork);
						if (oCompanyAuthInfoWork != null) setDataValue.Add(oCompanyAuthInfoWork);
						else
						{
							throw new Exception( "企業ログイン情報構成にエラーが出ました。クライアント環境が不正です。",null);
						}
					}
					//従業員ログイン接続ドメイン取得
                    // --- UPD m.suzuki 2010/04/06 ---------->>>>>
                    //// 2008.12.09 UENO ADD STA
                    ////if (MakeServerDomain(_companyAuthInfoWork,_onlineFlag,out _serverDomain,out _topPage) != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    //if( MakeServerDomain(_companyAuthInfoWork, _onlineFlag, out _serverDomain, out _topPage, out _helpPage) != (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                    //// 2008.12.09 UENO ADD END
                    if (MakeServerDomain(_companyAuthInfoWork,_onlineFlag,out _serverDomain,out _topPage) != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    // --- UPD m.suzuki 2010/04/06 ----------<<<<<
					{
						retMsg = "企業認証情報からサーバー接続情報が取得出来ませんでした。";
						return status;
					}

					//従業員ログイン情報が取得出来た場合
					//従業員ログイン情報を設定
					if (bEmployeeAuthInfoWork != null)
					{
						_employeeAuthInfoWork = CustomFormatterDeSerialize(bEmployeeAuthInfoWork,typeof(EmployeeAuthInfoWork)) as EmployeeAuthInfoWork;
						if (_employeeAuthInfoWork == null)
						{
							throw new Exception( "従業員ログイン情報構成にエラーが出ました。クライアント環境が不正です。",null);
						}
						//従業員情報がログイン情報から取得出来る場合には従業員ログイン済み
						status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

						//従業員ログイン情報が取得出来た場合のみクライアント情報を取得
						if (bClientAuthInfoWork != null) 
						{
							_clientAuthInfoWork = CustomFormatterDeSerialize(bClientAuthInfoWork,typeof(ClientAuthInfoWork)) as ClientAuthInfoWork;
							if (_clientAuthInfoWork == null)
							{
								//取得出来ない場合（ありえないが再取得）
								_clientAuthInfoWork = MakeClientAuthInfoWork();
								setDataKey.Add(_const_ClientAuthInfoWork);
								object oClientAuthInfoWork = CustomFormatterSerialize(_clientAuthInfoWork);
								setDataValue.Add(oClientAuthInfoWork);
							}
						}
							//取得出来ない場合（ありえないが再取得）
						else
						{
							_clientAuthInfoWork = MakeClientAuthInfoWork();
							setDataKey.Add(_const_ClientAuthInfoWork);
							object oClientAuthInfoWork = CustomFormatterSerialize(_clientAuthInfoWork);
							setDataValue.Add(oClientAuthInfoWork);
						}
					}
                    //リモートサーバーバージョンが取得出来ない場合取得
                    if (requiredServerVersion == -1)
                    {
                        _requiredServerVersion = GetRequiredServerVersion();
                        //取得出来ない場合エラー
                        if (_requiredServerVersion == -1)
                        {
                            throw new Exception("クライアントが正しくインストールされていません。クライアント環境の確認を行ってください。", null);
                        }
                        else
                        {
                            setDataKey.Add(_const_RequiredServerVersion);
                            setDataValue.Add(_requiredServerVersion);
                        }
                    }
                    else _requiredServerVersion = requiredServerVersion;
                    //リモーティング送受信用バージョンとしてセット
                    if (_requiredServerVersion != -1) LoginInfoAcquisition.SetRequiredServerVersion(_requiredServerVersion);

					//初回取得した企業ログイン情報をワーククラスとしてサーバー登録
					if (setDataKey.Count > 0)
					{
						try
						{
							//オンラインフラグも合わせてセットする
							setDataKey.Add(_const_OnlineFlag);
							setDataValue.Add(_onlineFlag);

							//リモートサーバーへ書き込み
							_remoteService.SetData(_companyAuthInfoWork.AccessTicket,(string[])setDataKey.ToArray(typeof(string)),(object[])setDataValue.ToArray(typeof(object)));
						}
						catch(Exception ex)
						{
							retMsg = ex.Message;
							status = (int)ConstantManagement.DB_Status.ctDB_EOF;
							return status;
						}
					}
				}
				else
				{
					retMsg = "製品管理クライアントにて企業ログインを行ってください。";
				}
			}

			//企業ログイン済みの場合
			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL || status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
			{
				//ミューテックスチェックWaitをかけれなかった場合は企業ログインしてないものとみなす
				if (MutexStartCheck(out retMsg,_companyLoginMutexKey,eventHandler) != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					_companyAuthInfoWork	= null;
					_employeeAuthInfoWork	= null;
					_clientAuthInfoWork		= null;
					status = (int)ConstantManagement.DB_Status.ctDB_EOF;
				}
			}

			return status;
		}

		/// <summary>
		/// 従業員ログイン
		/// </summary>
		/// <param rKeyName="owner">ダイアログFormオーナー</param>
		/// <param rKeyName="retMsg">リターンメッセージ</param>
		/// <returns>成否</returns>
		public bool EmployeeLogin(System.Windows.Forms.IWin32Window owner,out string retMsg)
		{
			retMsg = "";

            // 2008.11.14 UENO ADD STA
			//従業員ログイン画面生成
            //if (_employeeLoginForm == null) _employeeLoginForm = new EmployeeLoginFormAF();
            // --- UPD m.suzuki 2010/04/06 ---------->>>>>
            //if( _employeeLoginForm == null && (int)Program._sfNetMenuServerInfo.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_FelicaAccessService) > 0 )
            if ( _employeeLoginForm == null && (int)Program._sfNetMenuServerInfo.SoftwarePurchasedCheckForCompany( ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_Felica ) > 0 )
            // --- UPD m.suzuki 2010/04/06 ----------<<<<<
            {
                _employeeLoginForm = new EmployeeLoginFormEx(true);
            }
            else if( _employeeLoginForm == null)
            {
                _employeeLoginForm = new EmployeeLoginFormEx(false);
            }
            // 2008.11.14 UENO ADD END

			//オフライン従業員ログイン情報取得
			EmployeeAuthInfoWork wkEmployeeAuthInfoWork = MakeLoginEmployeeAuthInfoWork(_onlineFlag,_companyAuthInfoWork);
			if (!_onlineFlag && wkEmployeeAuthInfoWork == null)
			{
				retMsg = "オンライン時に一度従業員ログインしてください。\r\n従業員ログイン実績の無い状態で、オフライン従業員ログインは出来ません。";
				return false;
			}

			//従業員ログイン画面表示
			if (_employeeLoginForm.ShowDialog(owner,_companyAuthInfoWork.AccessTicket,_serverDomain, _companyAuthInfoWork, ref wkEmployeeAuthInfoWork) != 0) return false;

			//オンライン時のログインではクライアントにログイン情報をローカル保存する
			if (_onlineFlag) MakeLoginDataEmployeeAuthInfoWork(_companyAuthInfoWork,wkEmployeeAuthInfoWork);

			//取得データサーバー登録用
			ArrayList setDataKey	= new ArrayList();
			ArrayList setDataValue	= new ArrayList();

			//従業員ログイン情報を設定
			_employeeAuthInfoWork = wkEmployeeAuthInfoWork;
			setDataKey.Add(_const_EmployeeAuthInfoWork);
			object oEmployeeAuthInfoWork = CustomFormatterSerialize(_employeeAuthInfoWork);
			if (oEmployeeAuthInfoWork != null) setDataValue.Add(oEmployeeAuthInfoWork);

			//クライアント情報を取得
			_clientAuthInfoWork = MakeClientAuthInfoWork();
			setDataKey.Add(_const_ClientAuthInfoWork);
			object oClientAuthInfoWork = CustomFormatterSerialize(_clientAuthInfoWork);
			if (oClientAuthInfoWork != null) setDataValue.Add(oClientAuthInfoWork);

			//どちらかがnullの場合には従業員ログイン不可
			if (oEmployeeAuthInfoWork == null || oClientAuthInfoWork == null)
			{
				return false;
			}

			//●製品管理クライアントへログイン情報をセット
			//取得した従業員ログイン情報をワーククラスとしてサーバー登録
			if (setDataKey.Count > 0)
			{
				_remoteService.SetData(_companyAuthInfoWork.AccessTicket,(string[])setDataKey.ToArray(typeof(string)),(object[])setDataValue.ToArray(typeof(object)));
				// --- UPD m.suzuki 2010/04/06 ---------->>>>>
                //string[] mutexSetKey = {"EmployeeLoginMutex"};
                string[] mutexSetKey = { @"Global\EmployeeLoginMutex" };
                // --- UPD m.suzuki 2010/04/06 ----------<<<<<
				_remoteService.SetMutex(_companyAuthInfoWork.AccessTicket,mutexSetKey);
			}


			return true;
		}

		/// <summary>
		/// 従業員ログオフ
		/// </summary>
		/// <returns>成否</returns>
		public void EmployeeLogoff()
		{
			//●ログイン情報破棄
			_employeeAuthInfoWork = null;
			_clientAuthInfoWork = null;
			//●製品管理クライアントからログイン情報をリリース
			//データサーバーリリース用
			ArrayList setDataKey	= new ArrayList();
			setDataKey.Add(_const_EmployeeAuthInfoWork);
			setDataKey.Add(_const_ClientAuthInfoWork);
			if (_remoteService != null)
			{
				_remoteService.ReleaseData(_companyAuthInfoWork.AccessTicket,(string[])setDataKey.ToArray(typeof(string)));
				// --- UPD m.suzuki 2010/04/06 ---------->>>>>
                //string[] mutexSetKey = {"EmployeeLoginMutex"};
                string[] mutexSetKey ={ @"Global\EmployeeLoginMutex" };
                // --- UPD m.suzuki 2010/04/06 ----------<<<<<
				_remoteService.ReleaseMutex(_companyAuthInfoWork.AccessTicket,mutexSetKey);
			}
        }

        #endregion

        #region プライベートメソッド（メニュー情報）
        /// <summary>
		/// オフライン従業員ログイン情報取得
		/// </summary>
		/// <param rKeyName="onlineFlag">オフラインフラグ</param>
		/// <param rKeyName="companyAuthInfoWork">企業ログイン情報</param>
		/// <returns>従業員ログイン情報</returns>
		private EmployeeAuthInfoWork MakeLoginEmployeeAuthInfoWork(bool onlineFlag, CompanyAuthInfoWork companyAuthInfoWork)
		{
			EmployeeAuthInfoWork result = null;
			if (!onlineFlag)
			{
				//オフラインの場合にはクライアントのオフライン従業員ログイン情報を取得しにいく
				OfflineDataSerializer offlineDataSerializer = new OfflineDataSerializer();
				string className = this.GetType().ToString();
				string[] keyList = {companyAuthInfoWork.EnterpriseInfoWork.EnterpriseCode};
				result = offlineDataSerializer.DeSerialize(className,keyList) as EmployeeAuthInfoWork;
			}
			return result;
		}

		/// <summary>
		/// 従業員ログイン情報キャッシュ保存
		/// </summary>
		/// <param rKeyName="companyAuthInfoWork">企業ログイン情報</param>
		/// <param rKeyName="employeeAuthInfoWork">従業員ログイン情報</param>
		private void MakeLoginDataEmployeeAuthInfoWork(CompanyAuthInfoWork companyAuthInfoWork,EmployeeAuthInfoWork employeeAuthInfoWork)
		{
			//オンラインの従業員ログイン時には従業員ログイン情報をクライアントへキャッシュする
			OfflineDataSerializer offlineDataSerializer = new OfflineDataSerializer();
			string className = this.GetType().ToString();
			string[] keyList = {companyAuthInfoWork.EnterpriseInfoWork.EnterpriseCode};
			offlineDataSerializer.Serialize(className,keyList,employeeAuthInfoWork);
		}

        /// <summary>
        /// クライアントバージョン取得
        /// </summary>
        /// <returns>クライアントバージョン</returns>
        private Int32 GetRequiredServerVersion()
        {
            // --- UPD m.suzuki 2010/04/06 ---------->>>>>
            //Int32 requiredServerVersion = -1;

            //// 操作するレジストリ・キーの名前
            //string rKeyName = @String.Format("SOFTWARE\\Broadleaf\\Product\\{0}", ConstantManagement_SF_PRO.ProductCode);
            //// 取得処理を行う対象となるレジストリの値の名前
            //string rGetValueName = "RequiredServerVersion";

            //// レジストリの取得
            //try
            //{
            //    // レジストリ・キーのパスを指定してレジストリを開く
            //    RegistryKey rKey = Registry.LocalMachine.OpenSubKey(rKeyName);

            //    // レジストリの値を取得
            //    requiredServerVersion = (Int32)rKey.GetValue(rGetValueName);

            //    // 開いたレジストリ・キーを閉じる
            //    rKey.Close();
            //}
            //catch (NullReferenceException)
            //{
            //    requiredServerVersion = -1;
            //}
            //return requiredServerVersion;

            int requiredServerVersion = -1;
            try
            {
                string registryValue = this.GetRegistryValue( ConstantManagement_SF_PRO.ProductCode, "RequiredServerVersion" );
                switch ( registryValue )
                {
                    case null:
                    case "":
                        return -1;
                }
                requiredServerVersion = Convert.ToInt32( registryValue );
            }
            catch ( Exception )
            {
                string name = string.Format( @"SOFTWARE\Broadleaf\Product\{0}", ConstantManagement_SF_PRO.ProductCode );
                string rGetValueName = "RequiredServerVersion";
                try
                {
                    RegistryKey rKey = Registry.LocalMachine.OpenSubKey( name );
                    requiredServerVersion = (int)rKey.GetValue( rGetValueName );
                    rKey.Close();
                }
                catch ( NullReferenceException )
                {
                    requiredServerVersion = -1;
                }
                return requiredServerVersion;
            }
            return requiredServerVersion;
            // --- UPD m.suzuki 2010/04/06 ----------<<<<<
        }

		/// <summary>
		/// マシンID取得
		/// </summary>
		/// <returns></returns>
		private string GetMachineUserId()
		{
			//DNSホスト名を取得
			string workstationID = Dns.GetHostName();
			//取得出来ない場合にはNetBios名を取得
			if (workstationID == null || workstationID == "") workstationID = Environment.MachineName;
			return workstationID;
		}

        // --- ADD m.suzuki 2010/04/06 ---------->>>>>
        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public int GetRequiredServerVersion( string target )
        {
            int num;
            try
            {
                string str = _ServerVersionTable[target].ToString();
                if ( str != null )
                {
                    return Convert.ToInt32( str );
                }
            }
            catch ( Exception )
            {
            }
            try
            {
                string registryValue = this.GetRegistryValue( string.Format( @"{0}\{1}", ConstantManagement_SF_PRO.ProductCode, target ), "RequiredServerVersion" );
                switch ( registryValue )
                {
                    case null:
                    case "":
                        return -1;
                }
                return Convert.ToInt32( registryValue );
            }
            catch ( Exception )
            {
                string name = string.Format( @"SOFTWARE\Broadleaf\Product\{0}\{1}", ConstantManagement_SF_PRO.ProductCode, target );
                string str4 = "RequiredServerVersion";
                try
                {
                    RegistryKey key = Registry.LocalMachine.OpenSubKey( name );
                    num = (int)key.GetValue( str4 );
                    key.Close();
                }
                catch ( NullReferenceException )
                {
                    num = -1;
                }
                return num;
            }
            return num;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        private ArrayList MakeRequestAllChildCompanyRelationWork( LocalAccessToken token )
        {
            ArrayList list = new ArrayList();
            if ( token == null )
            {
                return null;
            }
            CRWebService service = new CRWebService();
            AuthorizeIdentity authorizeIdentity = new AuthorizeIdentity();
            authorizeIdentity.AccessTicket = token.AccessTicket;
            authorizeIdentity.CompanyCode = token.Company.CompanyCode;
            authorizeIdentity.ProductCode = token.Product.ProductCode;
            foreach ( ChildCompanyIdentity identity2 in service.RequestAllChildCompanyRelationList( authorizeIdentity ) )
            {
                AllChildCompanyWork work = new AllChildCompanyWork();
                work.companyCode = identity2.CompanyIdentity.CompanyCode;
                work.companyName = identity2.CompanyIdentity.CompanyName;
                work.emailAddress = identity2.CompanyIdentity.EmailAddress;
                list.Add( work );
            }
            return list;
        }
        // --- ADD m.suzuki 2010/04/06 ----------<<<<<

	
		/// <summary>
		/// MACアドレス取得
		/// </summary>
		/// <returns>MACアドレス文字列</returns>
		private string GetMachineMacId()
		{
			try
			{
				//NICのMACアドレスの取得
				//WMIツリーからNICの情報を取得するクエリーを生成
				ManagementObjectSearcher nicQuery = new ManagementObjectSearcher("SELECT MacAddress FROM Win32_NetworkAdapterConfiguration WHERE MACAddress is not null");
				//クエリーよりNICのコレクションを取得
				ManagementObjectCollection nicCollection = nicQuery.Get();

				StringBuilder mac = new StringBuilder((int)(nicCollection.Count * 18));
				int counter = nicCollection.Count;
				foreach(ManagementObject mo in nicCollection)
				{				
					mac.Append(mo["MacAddress"].ToString());
					counter--;
					if (counter > 0) mac.Append(",");
				}
				if (mac.ToString().Length == 0) return "";
				else							return mac.ToString();
			}
			catch(Exception)
			{
				return "";
			}
		}

		/// <summary>
		/// 製品管理クライアントポート番号取得
		/// </summary>
		/// <returns></returns>
		private Int32 GetPMCPorNo()
		{
            // --- UPD m.suzuki 2010/04/06 ---------->>>>>
            //// 操作するレジストリ・キーの名前
            //string rKeyName = @"SOFTWARE\Broadleaf\Product\PMC";
            //// 取得処理を行う対象となるレジストリの値の名前
            //string rGetValueName = "PortID";

            //// レジストリの取得
            //try
            //{
            //    // レジストリ・キーのパスを指定してレジストリを開く
            //    RegistryKey rKey = Registry.LocalMachine.OpenSubKey(rKeyName);

            //    // レジストリの値を取得
            //    Int32 pMCPortNo2 = (Int32)rKey.GetValue(rGetValueName);

            //    // 開いたレジストリ・キーを閉じる
            //    rKey.Close();

            //    // 取得したレジストリの値を戻す
            //    return pMCPortNo2;
            //}
            //catch (NullReferenceException)
            //{
            //    return 0;
            //}

            int pMCPortNo;
            try
            {
                string registryValue = this.GetRegistryValue( "PMC", "PortID" );
                switch ( registryValue )
                {
                    case null:
                    case "":
                        return 0;
                }
                pMCPortNo = Convert.ToInt32( registryValue );
            }
            catch ( Exception )
            {
                string rKeyName = @"SOFTWARE\Broadleaf\Product\PMC";
                string rGetValueName = "PortID";
                try
                {
                    RegistryKey key = Registry.LocalMachine.OpenSubKey( rKeyName );
                    int pMCPortNo2 = (int)key.GetValue( rGetValueName );
                    key.Close();
                    pMCPortNo = pMCPortNo2;
                }
                catch ( NullReferenceException )
                {
                    pMCPortNo = 0;
                }
            }
            return pMCPortNo;
            // --- UPD m.suzuki 2010/04/06 ----------<<<<<
		}
        // --- ADD m.suzuki 2010/04/06 ---------->>>>>
        /// <summary>
        /// 
        /// </summary>
        /// <param rKeyName="productCode"></param>
        /// <param rKeyName="paraKey"></param>
        /// <returns></returns>
        private string GetRegistryValue( string productCode, string paraKey )
        {
            RegistryTargetProductInfo targetProductInfo = new RegistryTargetProductInfo();
            targetProductInfo.ProductCode = productCode;
            targetProductInfo.ApplicationType = ApplicationType.Client;
            targetProductInfo.TargetServiceName = string.Empty;
            Dictionary<string, object> registryInfo = ServiceFactory.GetInstance().GetRemoteService().GetRegistryInfo( targetProductInfo );
            if ( registryInfo.Count == 0 )
            {
                throw new Exception( "インストール情報の取得に失敗しました。正しくインストールが行われているかどうか確認してください" );
            }
            string str = registryInfo[paraKey].ToString();
            if ( str == null )
            {
                throw new Exception( "インストール情報の取得に失敗しました。正しくインストールが行われているかどうか確認してください" );
            }
            return str;
        }
        // --- ADD m.suzuki 2010/04/06 ----------<<<<<

		/// <summary>
		/// 製品バージョン取得
		/// </summary>
		/// <param rKeyName="productCode">プロダクトコード</param>
		/// <returns>バージョン</returns>
		private string GetProductVersion(string productCode)
		{
			// 操作するレジストリ・キーの名前
			string rKeyName = @"SOFTWARE\Broadleaf\Product\"+productCode;
			// 取得処理を行う対象となるレジストリの値の名前
			string rGetValueName = "CurrentVersion";

			// レジストリの取得
			try
			{
				// レジストリ・キーのパスを指定してレジストリを開く
				RegistryKey rKey = Registry.LocalMachine.OpenSubKey(rKeyName);

				// レジストリの値を取得
				string version = (string)rKey.GetValue(rGetValueName);

				// 開いたレジストリ・キーを閉じる
				rKey.Close();

				// 取得したレジストリの値を戻す
				if (version == null)	return "";
				else					return version;
			}
			catch (NullReferenceException)
			{
				return "";
			}
		}

		/// <summary>
		/// クライアント情報生成
		/// </summary>
		/// <returns></returns>
		private ClientAuthInfoWork MakeClientAuthInfoWork()
		{
			ClientAuthInfoWork clientAuthInfoWork = new ClientAuthInfoWork();
			clientAuthInfoWork.MachineUserId = GetMachineUserId();//ユーザーID
			clientAuthInfoWork.MachineMacAdd = GetMachineMacId(); //MACアドレス
			clientAuthInfoWork.SuperFrontmanVersion = _version;		//SuperFrontmanVersion
			clientAuthInfoWork.PMCVersion			= _versionPMC;	//ProductVersion
			return clientAuthInfoWork;
		}

		/// <summary>
		/// 企業認証情報取得
		/// </summary>
		/// <param rKeyName="token">取得認証情報</param>
		/// <returns>企業認証情報</returns>
		private CompanyAuthInfoWork MakeCompanyAuthInfoWork(LocalAccessToken token)
		{
			//企業情報が無い場合にはnullを戻す
			if (token == null) return null;

			//企業情報がある場合には企業ログイン情報を生成
			CompanyAuthInfoWork companyAuthInfoWork = new CompanyAuthInfoWork();
			companyAuthInfoWork.AccessTicket = token.AccessTicket;
			companyAuthInfoWork.LoginFlag = token.LoginFlag;
			companyAuthInfoWork.OnlineMode = true;
			//ログイン企業情報を取得
			companyAuthInfoWork.EnterpriseInfoWork = new EnterpriseInfoWork();
			companyAuthInfoWork.EnterpriseInfoWork.EnterpriseCode = token.Company.CompanyCode;
			companyAuthInfoWork.EnterpriseInfoWork.EnterpriseName = token.Company.CompanyName;
			companyAuthInfoWork.EnterpriseInfoWork.EnterpriseDescription = token.Company.CompanyDescription;
			//ログイン企業契約ソフトウェア情報を取得
			companyAuthInfoWork.ProductInfoWork = new ProductInfoWork();
			companyAuthInfoWork.ProductInfoWork.ProductCode = token.Product.ProductCode;
			companyAuthInfoWork.ProductInfoWork.ProductName = token.Product.ProductName;
			companyAuthInfoWork.ProductInfoWork.ProductDescription = token.Product.ProductDescription;
			//サービスコネクション情報
			if (token.Product.RemoteServiceInfoArray == null || token.Product.RemoteServiceInfoArray.Length == 0)
			{
				companyAuthInfoWork.ProductInfoWork.RemoteServiceInfoWorkArray = new RemoteServiceInfoWork[0];
			}
			else
			{
				companyAuthInfoWork.ProductInfoWork.RemoteServiceInfoWorkArray = new RemoteServiceInfoWork[token.Product.RemoteServiceInfoArray.Length];
				for(int i=0;i<token.Product.RemoteServiceInfoArray.Length;i++)
				{
					companyAuthInfoWork.ProductInfoWork.RemoteServiceInfoWorkArray[i] = new RemoteServiceInfoWork();
					companyAuthInfoWork.ProductInfoWork.RemoteServiceInfoWorkArray[i].ServiceCode		= token.Product.RemoteServiceInfoArray[i].ServiceCode;
					companyAuthInfoWork.ProductInfoWork.RemoteServiceInfoWorkArray[i].ServiceName		= token.Product.RemoteServiceInfoArray[i].ServiceName;
					companyAuthInfoWork.ProductInfoWork.RemoteServiceInfoWorkArray[i].ServiceTargetName	= token.Product.RemoteServiceInfoArray[i].ServiceTargetName;
					companyAuthInfoWork.ProductInfoWork.RemoteServiceInfoWorkArray[i].Protocol			= token.Product.RemoteServiceInfoArray[i].Protocol;
					companyAuthInfoWork.ProductInfoWork.RemoteServiceInfoWorkArray[i].Domain			= token.Product.RemoteServiceInfoArray[i].Domain;
					companyAuthInfoWork.ProductInfoWork.RemoteServiceInfoWorkArray[i].Port				= token.Product.RemoteServiceInfoArray[i].Port;
					companyAuthInfoWork.ProductInfoWork.RemoteServiceInfoWorkArray[i].IsLoginService	= token.Product.RemoteServiceInfoArray[i].IsLoginService;
					//コネクション情報
					if (token.Product.RemoteServiceInfoArray[i].ConnectionInfo == null || token.Product.RemoteServiceInfoArray[i].ConnectionInfo.Length == 0)
					{
						companyAuthInfoWork.ProductInfoWork.RemoteServiceInfoWorkArray[i].ConnectionInfoWorkArray = new ConnectionInfoWork[0];
					}
					else
					{
						companyAuthInfoWork.ProductInfoWork.RemoteServiceInfoWorkArray[i].ConnectionInfoWorkArray = new ConnectionInfoWork[token.Product.RemoteServiceInfoArray[i].ConnectionInfo.Length];
						for (int ii=0;ii<token.Product.RemoteServiceInfoArray[i].ConnectionInfo.Length;ii++)
						{
							companyAuthInfoWork.ProductInfoWork.RemoteServiceInfoWorkArray[i].ConnectionInfoWorkArray[ii] = new ConnectionInfoWork();
							companyAuthInfoWork.ProductInfoWork.RemoteServiceInfoWorkArray[i].ConnectionInfoWorkArray[ii].IndexCode			= token.Product.RemoteServiceInfoArray[i].ConnectionInfo[ii].IndexCode;
							companyAuthInfoWork.ProductInfoWork.RemoteServiceInfoWorkArray[i].ConnectionInfoWorkArray[ii].IndexName			= token.Product.RemoteServiceInfoArray[i].ConnectionInfo[ii].IndexName;
							companyAuthInfoWork.ProductInfoWork.RemoteServiceInfoWorkArray[i].ConnectionInfoWorkArray[ii].TypeCode			= token.Product.RemoteServiceInfoArray[i].ConnectionInfo[ii].TypeCode;
							companyAuthInfoWork.ProductInfoWork.RemoteServiceInfoWorkArray[i].ConnectionInfoWorkArray[ii].ConnectionText	= token.Product.RemoteServiceInfoArray[i].ConnectionInfo[ii].ConnectionText;
							companyAuthInfoWork.ProductInfoWork.RemoteServiceInfoWorkArray[i].ConnectionInfoWorkArray[ii].ConnectionName	= token.Product.RemoteServiceInfoArray[i].ConnectionInfo[ii].ConnectionName;
                            //暗号化情報
                            if (token.Product.RemoteServiceInfoArray[i].ConnectionInfo[ii].DBEncryptionInfo == null || token.Product.RemoteServiceInfoArray[i].ConnectionInfo[ii].DBEncryptionInfo.Length == 0)
                            {
                                companyAuthInfoWork.ProductInfoWork.RemoteServiceInfoWorkArray[i].ConnectionInfoWorkArray[ii].DBEncryptionInfoWorkArray = new DBEncryptionInfoWork[0];
                            }
                            else
                            {
                                companyAuthInfoWork.ProductInfoWork.RemoteServiceInfoWorkArray[i].ConnectionInfoWorkArray[ii].DBEncryptionInfoWorkArray = new DBEncryptionInfoWork[token.Product.RemoteServiceInfoArray[i].ConnectionInfo[ii].DBEncryptionInfo.Length];
                                for (int iii = 0; iii < token.Product.RemoteServiceInfoArray[i].ConnectionInfo[ii].DBEncryptionInfo.Length; iii++)
                                {
                                    companyAuthInfoWork.ProductInfoWork.RemoteServiceInfoWorkArray[i].ConnectionInfoWorkArray[ii].DBEncryptionInfoWorkArray[iii] = new DBEncryptionInfoWork();
                                    companyAuthInfoWork.ProductInfoWork.RemoteServiceInfoWorkArray[i].ConnectionInfoWorkArray[ii].DBEncryptionInfoWorkArray[iii].TableName = token.Product.RemoteServiceInfoArray[i].ConnectionInfo[ii].DBEncryptionInfo[iii].TableName;
                                    companyAuthInfoWork.ProductInfoWork.RemoteServiceInfoWorkArray[i].ConnectionInfoWorkArray[ii].DBEncryptionInfoWorkArray[iii].KeyName = token.Product.RemoteServiceInfoArray[i].ConnectionInfo[ii].DBEncryptionInfo[iii].KeyName;
                                    companyAuthInfoWork.ProductInfoWork.RemoteServiceInfoWorkArray[i].ConnectionInfoWorkArray[ii].DBEncryptionInfoWorkArray[iii].KeyPWD = token.Product.RemoteServiceInfoArray[i].ConnectionInfo[ii].DBEncryptionInfo[iii].KeyPWD;
                                }
                            }
						}
					}
				}
			}

			//ソフトウェア情報
			if (token.Product.SoftwareInfoArray == null || token.Product.SoftwareInfoArray.Length == 0)
			{
				companyAuthInfoWork.ProductInfoWork.SoftwareInfoWorkArray = new SoftwareInfoWork[0];
			}
			else
			{
				companyAuthInfoWork.ProductInfoWork.SoftwareInfoWorkArray = new SoftwareInfoWork[token.Product.SoftwareInfoArray.Length];
				for(int i=0;i<token.Product.SoftwareInfoArray.Length;i++)
				{
					companyAuthInfoWork.ProductInfoWork.SoftwareInfoWorkArray[i] = new SoftwareInfoWork();
					companyAuthInfoWork.ProductInfoWork.SoftwareInfoWorkArray[i].SoftwareCode = token.Product.SoftwareInfoArray[i].SoftwareCode;
					companyAuthInfoWork.ProductInfoWork.SoftwareInfoWorkArray[i].SoftwareName = token.Product.SoftwareInfoArray[i].SoftwareName;
					companyAuthInfoWork.ProductInfoWork.SoftwareInfoWorkArray[i].SoftwareType = token.Product.SoftwareInfoArray[i].SoftwareType;
					companyAuthInfoWork.ProductInfoWork.SoftwareInfoWorkArray[i].SoftwareDescription = token.Product.SoftwareInfoArray[i].SoftwareDescription;
					companyAuthInfoWork.ProductInfoWork.SoftwareInfoWorkArray[i].ProductCode = token.Product.SoftwareInfoArray[i].ProductCode;
					companyAuthInfoWork.ProductInfoWork.SoftwareInfoWorkArray[i].RemainingDays = token.Product.SoftwareInfoArray[i].RemainingDays;
					companyAuthInfoWork.ProductInfoWork.SoftwareInfoWorkArray[i].PurchaseStatus = (Int32)token.Product.SoftwareInfoArray[i].PurchaseStatus;
					companyAuthInfoWork.ProductInfoWork.SoftwareInfoWorkArray[i].IsUSBAccessPermitted = token.Product.SoftwareInfoArray[i].IsUSBAccessPermitted;
				}
			}
			//ロール情報
			if (token.Product.RoleInfoArray == null || token.Product.RoleInfoArray.Length == 0)
			{
				companyAuthInfoWork.ProductInfoWork.RoleInfoWorkArray = new RoleInfoWork[0];
			}
			else
			{
				companyAuthInfoWork.ProductInfoWork.RoleInfoWorkArray = new RoleInfoWork[token.Product.RoleInfoArray.Length];
				for(int i=0;i<token.Product.RoleInfoArray.Length;i++)
				{
					companyAuthInfoWork.ProductInfoWork.RoleInfoWorkArray[i] = new RoleInfoWork();
					companyAuthInfoWork.ProductInfoWork.RoleInfoWorkArray[i].RoleCode = token.Product.RoleInfoArray[i].RoleCode;
					companyAuthInfoWork.ProductInfoWork.RoleInfoWorkArray[i].RoleName = token.Product.RoleInfoArray[i].RoleName;
					companyAuthInfoWork.ProductInfoWork.RoleInfoWorkArray[i].RoleDescription = token.Product.RoleInfoArray[i].RoleDescription;
					if (token.Product.RoleInfoArray[i].FunctionInfoArray == null || token.Product.RoleInfoArray[i].FunctionInfoArray.Length == 0)
					{
						companyAuthInfoWork.ProductInfoWork.RoleInfoWorkArray[i].FunctionInfoWorkArray = new FunctionInfoWork[0];
					}
					else
					{
						companyAuthInfoWork.ProductInfoWork.RoleInfoWorkArray[i].FunctionInfoWorkArray = new FunctionInfoWork[token.Product.RoleInfoArray[i].FunctionInfoArray.Length];
						for(int ii=0;ii<token.Product.RoleInfoArray[i].FunctionInfoArray.Length;ii++)
						{
							companyAuthInfoWork.ProductInfoWork.RoleInfoWorkArray[i].FunctionInfoWorkArray[ii] = new FunctionInfoWork();
							companyAuthInfoWork.ProductInfoWork.RoleInfoWorkArray[i].FunctionInfoWorkArray[ii].FunctionCode = token.Product.RoleInfoArray[i].FunctionInfoArray[ii].FunctionCode;
							companyAuthInfoWork.ProductInfoWork.RoleInfoWorkArray[i].FunctionInfoWorkArray[ii].FunctionName = token.Product.RoleInfoArray[i].FunctionInfoArray[ii].FunctionName;
							companyAuthInfoWork.ProductInfoWork.RoleInfoWorkArray[i].FunctionInfoWorkArray[ii].FunctionDescription = token.Product.RoleInfoArray[i].FunctionInfoArray[ii].FunctionDescription;
						}
					}
				}
			}

			return companyAuthInfoWork;
		}

		/// <summary>
		/// 従業員ログイン/トップページ用サーバードメイン情報取得
		/// </summary>
		/// <param rKeyName="companyAuthInfoWork">企業ログイン情報</param>
		/// <param rKeyName="onlineFlag">オンラインフラグ</param>
		/// <param rKeyName="domain">従業員ログイン情報ドメイン</param>
		/// <param rKeyName="toppage">トップページアドレス</param>
        /// <param rKeyName="helppage">ヘルプページアドレス</param>
		/// <returns>status</returns>
        // --- UPD m.suzuki 2010/04/06 ---------->>>>>
        ////private int MakeServerDomain(CompanyAuthInfoWork companyAuthInfoWork,bool onlineFlag,out string domain,out string toppage)
        //private int MakeServerDomain(CompanyAuthInfoWork companyAuthInfoWork, bool onlineFlag, out string domain, out string toppage, out string helppage)
        private int MakeServerDomain( CompanyAuthInfoWork companyAuthInfoWork, bool onlineFlag, out string domain, out string toppage )
        // --- UPD m.suzuki 2010/04/06 ----------<<<<<
        {
			domain  = null;
			toppage = null;
            // --- DEL m.suzuki 2010/04/06 ---------->>>>>
            //// 2008.12.09 UENO ADD STA
            //helppage = null;
            //// 2008.12.09 UENO ADD END
            // --- DEL m.suzuki 2010/04/06 ----------<<<<<
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			if (companyAuthInfoWork == null ||
				companyAuthInfoWork.ProductInfoWork == null ||
				companyAuthInfoWork.ProductInfoWork.RemoteServiceInfoWorkArray == null ||
				companyAuthInfoWork.ProductInfoWork.RemoteServiceInfoWorkArray.Length == 0) return status;

			foreach(RemoteServiceInfoWork remoteServiceInfoWork in companyAuthInfoWork.ProductInfoWork.RemoteServiceInfoWorkArray)
			{
				if (remoteServiceInfoWork.ConnectionInfoWorkArray == null || remoteServiceInfoWork.ConnectionInfoWorkArray.Length == 0) continue;

				//ログインサービスフラグが立っている場合従業員ログイン接続APサーバーとしてドメインを戻す
				//※従業員ログインのドメインがあればステータス正常
				if (remoteServiceInfoWork.IsLoginService)
				{
					domain = string.Format("{0}://{1}:{2}",remoteServiceInfoWork.Protocol,remoteServiceInfoWork.Domain,remoteServiceInfoWork.Port);
					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
				}
				//トップページWEBのアドレスが取得出来たら
				else if (remoteServiceInfoWork.ServiceCode.Equals("TOPPAGE_WEB") )
				{
					toppage = string.Format("{0}://{1}:{2}",remoteServiceInfoWork.Protocol,remoteServiceInfoWork.Domain,remoteServiceInfoWork.Port);
					//パラメータ文字列取得
					if (remoteServiceInfoWork.ConnectionInfoWorkArray != null && remoteServiceInfoWork.ConnectionInfoWorkArray.Length > 0)
					{
						foreach(ConnectionInfoWork connectionInfoWork in remoteServiceInfoWork.ConnectionInfoWorkArray)
						{
                            if (connectionInfoWork.TypeCode.Equals("201")) toppage += LoginInfoAcquisition.Decrypt(connectionInfoWork.ConnectionText, companyAuthInfoWork);
						}
					}
				}
                // --- DEL m.suzuki 2010/04/06 ---------->>>>>
                //// 2008.12.09 UENO ADD STA
                ////ヘルプページWEBのアドレスが取得出来たら
                //else if( remoteServiceInfoWork.ServiceCode.Equals("HELP_WEB") )
                //{
                //    helppage = string.Format("{0}://{1}:{2}", remoteServiceInfoWork.Protocol, remoteServiceInfoWork.Domain, remoteServiceInfoWork.Port);
                //    //パラメータ文字列取得
                //    if( remoteServiceInfoWork.ConnectionInfoWorkArray != null && remoteServiceInfoWork.ConnectionInfoWorkArray.Length > 0 )
                //    {
                //        foreach( ConnectionInfoWork connectionInfoWork in remoteServiceInfoWork.ConnectionInfoWorkArray )
                //        {
                //            if( connectionInfoWork.TypeCode.Equals("201") ) helppage += LoginInfoAcquisition.Decrypt(connectionInfoWork.ConnectionText, companyAuthInfoWork);
                //        }
                //    }
                //}
                //// 2008.12.09 UENO ADD END
                // --- DEL m.suzuki 2010/04/06 ----------<<<<<
			}
			//もしオフラインの場合にはトップページアドレスは下記の物理ファイルとする
			if (!onlineFlag)
			{
				toppage = Path.Combine(Directory.GetCurrentDirectory()	,_const_MenuOfflineDir);
				toppage = Path.Combine(toppage							,_const_MenuOfflineIndex);
                
                // --- DEL m.suzuki 2010/04/06 ---------->>>>>
                //// 2008.12.09 UENO ADD STA
                //helppage = Path.Combine(Directory.GetCurrentDirectory(), _const_MenuOfflineDir);
                //helppage = Path.Combine(helppage                       , _const_MenuOfflineIndex);
                //// 2008.12.09 UENO ADD END
                // --- DEL m.suzuki 2010/04/06 ----------<<<<<
			}
			return status;
		}

		/// <summary>
		/// パラメータ取得
		/// </summary>
		/// <param rKeyName="param">パラメータ文字配列</param>
		private void GetPara(string[] param)
		{
			const int _paramCount = 2;

			//●パラメータチェック
			bool paramErrorFlag = true;
			//パラメータ数チェック
			if (param.Length != _paramCount)					paramErrorFlag = false;
				//第一パラメータチェック
			else if (!param[0].Trim().Equals(bool.FalseString) 
				&& !param[0].Trim().Equals(bool.TrueString))	paramErrorFlag = false;
				//第二パラメータチェック
            // --- UPD m.suzuki 2010/04/06 ---------->>>>>
			//else if (param[1] == null || param[1].Length != 36) paramErrorFlag = false;
            else if ( param[1] == null || (param[1].Length != 36 && param[1].Length != 43) ) paramErrorFlag = false;
            // --- UPD m.suzuki 2010/04/06 ----------<<<<<

            // --- DEL m.suzuki 2010/04/06 ---------->>>>>
            ////第二パラメータはGuid変換チェック
            //try
            //{
            //    Guid guid = new Guid( param[1] );
            //}
            //catch ( Exception ex )
            //{
            //    paramErrorFlag = false;
            //}
            // --- DEL m.suzuki 2010/04/06 ----------<<<<<


			//●正常インスタンス化チェック
			if(!paramErrorFlag)	throw new Exception("不正起動です。製品管理クライアントから起動してください。",null);


			//●メンバ展開
			//正常パラメータの場合にはクラスメンバを生成
			//①オンラインフラグ
			if (param[0].Trim().Equals(bool.FalseString)) _onlineFlag = false;
			else										  _onlineFlag = true ;
			//②　
			_companyLoginMutexKey	= param[1];
		}	

		/// <summary>
		/// カスタムシリアライズ
		/// </summary>
		/// <param rKeyName="data">シリアライズデータ</param>
		/// <returns>シリアライズ結果</returns>
		private byte[] CustomFormatterSerialize(object data)
		{
			byte[] result = null;

			MemoryStream mem = new MemoryStream();
			BinaryWriter writer = new BinaryWriter( mem, Encoding.UTF8 );								
			try
			{
				if (data is CompanyAuthInfoWork)
				{
					//企業情報
                    ICustomSerializationSurrogate formatterCompanyAuthInfoWork = CustomFormatterServices.GetSurrogate("Broadleaf.Application.Remoting.ParamData.CompanyAuthInfoWork, SFCMN00654D");
					formatterCompanyAuthInfoWork.Serialize( writer, data );
				}
				else if (data is EmployeeAuthInfoWork)
				{
					//従業員情報
                    ICustomSerializationSurrogate formatterEmployeeAuthInfoWork = CustomFormatterServices.GetSurrogate("Broadleaf.Application.Remoting.ParamData.EmployeeAuthInfoWork, SFCMN00664D");
					formatterEmployeeAuthInfoWork.Serialize( writer, data );
				}
				else if (data is ClientAuthInfoWork)
				{
					//クライアント情報
                    ICustomSerializationSurrogate formatterClientAuthInfoWork = CustomFormatterServices.GetSurrogate("Broadleaf.Application.Remoting.ParamData.ClientAuthInfoWork, SFCMN00694D");
					formatterClientAuthInfoWork.Serialize( writer, data );
				}
				else
				{
					result = null;
					data = null;
				}

				//対象オブジェクトの場合
				if (data != null)
				{
					mem.Seek( 0, SeekOrigin.Begin );
					result = new byte[mem.Length];
					mem.Read( result, 0, result.Length );
				}
			}
			catch(Exception)
			{
				result = null;
			}
			finally
			{				
				writer.Close();
				mem.Close();
			}
			return result;
		}

		/// <summary>
		/// カスタムデシリアライザ
		/// </summary>
		/// <param rKeyName="data">対象オブジェクト</param>
		/// <param rKeyName="type">デシリアライズタイプ</param>
		/// <returns>デシリアライズ結果</returns>
		private object CustomFormatterDeSerialize(byte[] data, Type type)
		{	
			object result = null;
			MemoryStream mem = new MemoryStream();
			mem.Write( data, 0, data.Length );
			mem.Seek( 0, SeekOrigin.Begin );
			BinaryReader reader = new BinaryReader( mem, System.Text.Encoding.UTF8 );
			try
			{
				if (type == typeof(CompanyAuthInfoWork))
				{
					//企業情報
                    ICustomSerializationSurrogate formatterCompanyAuthInfoWork = CustomFormatterServices.GetSurrogate("Broadleaf.Application.Remoting.ParamData.CompanyAuthInfoWork, SFCMN00654D");
					result = formatterCompanyAuthInfoWork.Deserialize( reader );
				}
				else if (type == typeof(EmployeeAuthInfoWork))
				{
					//従業員情報
                    ICustomSerializationSurrogate formatterEmployeeAuthInfoWork = CustomFormatterServices.GetSurrogate("Broadleaf.Application.Remoting.ParamData.EmployeeAuthInfoWork, SFCMN00664D");
					result = formatterEmployeeAuthInfoWork.Deserialize( reader );
				}
				else if (type == typeof(ClientAuthInfoWork))
				{
					//クライアント情報
                    ICustomSerializationSurrogate formatterClientAuthInfoWork = CustomFormatterServices.GetSurrogate("Broadleaf.Application.Remoting.ParamData.ClientAuthInfoWork, SFCMN00694D");
					result = formatterClientAuthInfoWork.Deserialize( reader );
				}
				else
				{
					result = null;
				}
			}
			catch(Exception)
			{
				result = null;
			}
			finally
			{
				reader.Close();
				mem.Close();
			}
			return result;
		}

		/// <summary>
		/// メインメニュー発行Mutexチェック
		/// </summary>
		/// <param rKeyName="returnMsg">起動不可メッセージ</param>
		/// <param rKeyName="rKey">Mutexキー</param>
		/// <param rKeyName="eventHandler">通知イベント</param>
		/// <returns>STATUS</returns>
		private int MutexStartCheck(out string returnMsg, string key, EventHandler eventHandler)
		{
			//戻り値初期化
			int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			returnMsg = "";

			//●パラメータチェック
			//起動パラメータ文字列チェック
			if ((key == null)||(key == ""))
			{
				returnMsg = "製品管理クライアントにて企業ログインを行ってください。";
				return status;
			}		

			//●Mutexチェック
			try
			{
				_exclusionService = new ExclusionService(key);
			}
			catch(Exception)
			{
				returnMsg = "別のWindowsユーザーでプログラムが起動中です。\r\n\r\n他のWindowsユーザーが起動しているプログラムを全て終了させてください。";
				return status;
			}

			//メインメニューが起動していない場合
			if(_exclusionService.ApplicationState == ExclusionService.State.NotRunning)
			{
				returnMsg = "製品管理クライアントにて企業ログインを行ってください。";
			}
				//メインメニューが起動中の場合(同名のMutexが起動中)
			else 
			{
				//ApplicationReleaseイベント接続
				_applicationReleased += eventHandler;

				//別スレッドでMutex監視
				_exclusionService.MutexReleased += new EventHandler(exclusionService_MutexReleased);
				_exclusionService.StartWaitMutexReleaseThread();
				//正常起動OKの戻り値をセット
				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			}

			//戻り値の設定
			return status;
		}

		/// <summary>
		/// Mutex開放時発生イベント
		/// </summary>
		/// <param rKeyName="sender"></param>
		/// <param rKeyName="e"></param>
		private void exclusionService_MutexReleased(object sender, EventArgs e)
		{
			//従業員ログオフした
			_exclusionService.Dispose();
			_exclusionService = null;

			//Applicationに通知
			_applicationReleased(sender, e);
		}

		/// <summary>
		/// Mutex破棄処理
		/// </summary>
		private void MutexEndCheck()
		{
			if (_exclusionService != null) 
			{
				_exclusionService.Dispose();
				_exclusionService = null;
			}
			if (_applicationReleased != null) _applicationReleased = null;
    }

        #endregion

        #region ソフトウェア契約確認(USB/企業）
        /// <summary>
        /// ソフトウェア契約確認(USB単位)
        /// </summary>
        /// <param rKeyName="softwareCode">ソフトウェアコード</param>
        /// <returns>ソフトウェア契約状態</returns>
        public Broadleaf.Application.Remoting.ParamData.PurchaseStatus SoftwarePurchasedCheckForUSB(string softwareCode)
        {
            int SoftwareType;
            return SoftwarePurchasedCheckForUSB(softwareCode, out SoftwareType);
        }

        /// <summary>
        /// ソフトウェア契約確認(USB単位)
        /// </summary>
        /// <param rKeyName="softwareCode">ソフトウェアコード</param>
        /// <param rKeyName="SoftwareType">ソフトウェアタイプ</param>
        /// <returns>ソフトウェア契約状態</returns>
        public Broadleaf.Application.Remoting.ParamData.PurchaseStatus SoftwarePurchasedCheckForUSB(string softwareCode, out int SoftwareType)
        {
            return SoftwarePurchasedCheckForUSB(softwareCode, out SoftwareType, _companyAuthInfoWork);
        }

        /// <summary>
        /// ソフトウェア契約確認(USB単位)
        /// </summary>
        /// <param rKeyName="softwareCode">ソフトウェアコード</param>
        /// <param rKeyName="SoftwareType">ソフトウェアタイプ</param>
        /// <param rKeyName="company">企業ログイン情報</param>
        /// <returns>ソフトウェア契約状態</returns>
        public Broadleaf.Application.Remoting.ParamData.PurchaseStatus SoftwarePurchasedCheckForUSB(string softwareCode, out int SoftwareType, object company)
        {
            SoftwareType = 0;

            //過去契約無しで初期化
            int status = (int)Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Uncontract;

            if( !( company is CompanyAuthInfoWork ) )
                return (Broadleaf.Application.Remoting.ParamData.PurchaseStatus)status;

            //企業ログイン情報取得
            CompanyAuthInfoWork companyAuthInfoWork = company as CompanyAuthInfoWork;

            if( companyAuthInfoWork == null ||
                companyAuthInfoWork.ProductInfoWork == null ||
                companyAuthInfoWork.ProductInfoWork.SoftwareInfoWorkArray == null )
                return (Broadleaf.Application.Remoting.ParamData.PurchaseStatus)status;

            foreach( SoftwareInfoWork softwareInfoWork in companyAuthInfoWork.ProductInfoWork.SoftwareInfoWorkArray )
            {
                //ソフトウェアコードチェック
                if( softwareCode == softwareInfoWork.SoftwareCode )
                {
                    //契約中でUSBが利用不可の場合は契約無しとする
                    if( softwareInfoWork.PurchaseStatus > 0 && !softwareInfoWork.IsUSBAccessPermitted )
                        status = (int)Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Uncontract;
                    else
                        status = softwareInfoWork.PurchaseStatus;
                    SoftwareType = softwareInfoWork.SoftwareType;
                    break;
                }
            }
            //戻り値を戻す
            return (Broadleaf.Application.Remoting.ParamData.PurchaseStatus)status;
        }

        /// <summary>
        /// ソフトウェア契約確認(企業単位)
        /// </summary>
        /// <param rKeyName="softwareCode">ソフトウェアコード</param>
        /// <returns>ソフトウェア契約状態</returns>
        public Broadleaf.Application.Remoting.ParamData.PurchaseStatus SoftwarePurchasedCheckForCompany(string softwareCode)
        {
            int SoftwareType;
            return SoftwarePurchasedCheckForCompany(softwareCode, out SoftwareType);
        }

        /// <summary>
        /// ソフトウェア契約確認(企業単位)
        /// </summary>
        /// <param rKeyName="softwareCode">ソフトウェアコード</param>
        /// <param rKeyName="SoftwareType">ソフトウェアタイプ</param>
        /// <returns>ソフトウェア契約状態</returns>
        public Broadleaf.Application.Remoting.ParamData.PurchaseStatus SoftwarePurchasedCheckForCompany(string softwareCode, out int SoftwareType)
        {
            return SoftwarePurchasedCheckForCompany(softwareCode, out SoftwareType, _companyAuthInfoWork);
        }

        /// <summary>
        /// ソフトウェア契約確認(企業単位)
        /// </summary>
        /// <param rKeyName="softwareCode">ソフトウェアコード</param>
        /// <param rKeyName="SoftwareType">ソフトウェアタイプ</param>
        /// <param rKeyName="company">企業ログイン情報</param>
        /// <returns>ソフトウェア契約状態</returns>
        public Broadleaf.Application.Remoting.ParamData.PurchaseStatus SoftwarePurchasedCheckForCompany(string softwareCode, out int SoftwareType, object company)
        {
            SoftwareType = 0;
            //過去契約無しで初期化
            int status = (int)Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Uncontract;

            if( !( company is CompanyAuthInfoWork ) )
                return (Broadleaf.Application.Remoting.ParamData.PurchaseStatus)status;

            //企業ログイン情報取得
            CompanyAuthInfoWork companyAuthInfoWork = company as CompanyAuthInfoWork;

            if( companyAuthInfoWork == null ||
                companyAuthInfoWork.ProductInfoWork == null ||
                companyAuthInfoWork.ProductInfoWork.SoftwareInfoWorkArray == null )
                return (Broadleaf.Application.Remoting.ParamData.PurchaseStatus)status;

            foreach( SoftwareInfoWork softwareInfoWork in companyAuthInfoWork.ProductInfoWork.SoftwareInfoWorkArray )
            {
                //ソフトウェアコードチェック
                if( softwareCode == softwareInfoWork.SoftwareCode )
                {
                    //USBの契約状態は無視してそのままの契約状態（会社の契約状態）を戻す
                    status = softwareInfoWork.PurchaseStatus;
                    SoftwareType = softwareInfoWork.SoftwareType;
                    break;
                }
            }
            //戻り値を戻す
            return (Broadleaf.Application.Remoting.ParamData.PurchaseStatus)status;
        }

        #endregion

        #region パブリックメソッド（アドオン情報）
        /// <summary>
        /// TOPメニューアドオン情報取得
        /// </summary>
        /// <param rKeyName="fileName"></param>
        /// <param rKeyName="rKey"></param>
        /// <returns></returns>
        public SfNetMenuAddOnInfo GetSfNetMenuAddOnInfo(string fileName, string[] key)
        {
            if( _sfNetMenuAddOnInfo == null )
            {
               _sfNetMenuAddOnInfo = LoadAddonConfig(fileName, key);
            }
            return _sfNetMenuAddOnInfo;
        }
        #endregion

        #region プライベートメソッド（アドオン情報）
        /// <summary>
        /// TOPメニューアドオン情報取得（実行部）
        /// </summary>
        /// <param rKeyName="fileName"></param>
        /// <param rKeyName="rKey"></param>
        /// <returns></returns>
        private SfNetMenuAddOnInfo LoadAddonConfig(string fileName, string[] key)
        {
            SfNetMenuAddOnInfo sfNetMenuAddOnInfo = null;

            if( File.Exists(fileName) )
            {
                try
                {
                    sfNetMenuAddOnInfo = Broadleaf.Application.Common.UserSettingController.DecryptionDeserializeUserSetting<SfNetMenuAddOnInfo>(fileName, key);
                }
                catch( Exception )
                {
                }
            }

            if( sfNetMenuAddOnInfo == null )
            {
                sfNetMenuAddOnInfo = new SfNetMenuAddOnInfo();
            }
            return sfNetMenuAddOnInfo;
        }
        #endregion
    }
}

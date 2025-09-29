using System;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Windows.Forms;
using System.Collections;
using Microsoft.Win32;
using System.Threading;
using System.Reflection;
using System.Collections.Generic;
using System.Globalization;
using System.Data;

using Broadleaf.Application.Common;

namespace Broadleaf.Windows.Forms
{
	

	/// <summary>
	///	アプリケーション二重起動管理クラス                                              
	/// </summary>
	/// <remarks> 
	/// <br>Note             :   二重起動をチェックします</br>
	/// <br>Programmer       :   鹿野 幸生</br>                           
	/// <br>Date             :   2005.07.08</br>                           
	/// <br>Update Note      :   2007.02.23</br>           
	/// </remarks>
	public class ExclusionService :IDisposable
	{
		/// <summary>ミューテックスオブジェクト</summary>
		/// <remarks>アプリケーション管理（排他制御）に使用されます</remarks>
		private System.Threading.Mutex mutex;

		/// <summary>起動管理</summary>
		private State _ApplicationState;

		/// <summary>
		/// ExclusionServiceクラスコンストラクタ
		/// </summary>
		/// <param name="MutexName">Mutex判別に使用されるアプリケーション毎の名称</param>
		/// <remarks>
		/// <br>Note　　　　　　 :   初期設定を行います</br>
		/// <br>Programmer       :   鹿野 幸生</br>                           
		/// <br>Date             :   2005.07.08</br>
		/// </remarks>
		public ExclusionService(string MutexName)
		{
			bool _NotRunning;

			//ミューテックスオブジェクトの生成
			mutex = new Mutex(true ,MutexName, out _NotRunning);

			//ミューテックスの状態を管理
			if(_NotRunning)
			{
				this._ApplicationState = State.NotRunning;
			}
			else
			{
				this._ApplicationState = State.Running;
			}
		}

		/// <summary>
		/// アプリケーション起動状態プロパティ
		/// </summary>
		/// <remarks>
		/// <br>Note　　　　　　 :   アプリケーション起動状態を取得します</br>
		/// <br>Programmer       :   鹿野 幸生</br>                           
		/// <br>Date             :   2005.07.08</br>
		/// </remarks>
		public State ApplicationState
		{
			get{return this._ApplicationState;}
		}

		/// <summary>
		/// ミューテックス開放イベントハンドラー
		/// </summary>
		/// <remarks>
		/// <br>Note　　　　　　 :   開放時のイベントに使用</br>
		/// <br>Programmer       :   鹿野 幸生</br>                           
		/// <br>Date             :   2005.07.08</br>
		/// </remarks>
		public event System.EventHandler MutexReleased;

		/// <summary>
		/// ミューテックス待機用スレッド
		/// </summary>
		/// <remarks>
		/// <br>Note　　　　　　 :   ミューテックス開放を待機するスレッド作成＋起動</br>
		/// <br>Programmer       :   鹿野 幸生</br>                           
		/// <br>Date             :   2005.07.04</br>
		/// </remarks>
		public void StartWaitMutexReleaseThread()
		{
			Thread hThread = new Thread(new ThreadStart(WaitForMutexRelease));
			hThread.IsBackground = true;
			hThread.Start();
		}

		/// <summary>
		/// 使用中のミューテックスの開放まで待機
		/// </summary>
		/// <remarks>
		/// <br>Note　　　　　　 :   ミューテックスの開放を待ち、解放後にイベントを投げます</br>
		/// <br>Programmer       :   鹿野 幸生</br>                           
		/// <br>Date             :   2005.07.08</br>
		/// </remarks>
		private void WaitForMutexRelease()
		{
            try
            {
                mutex.WaitOne();
            }
            catch (Exception)
            {
            }

			MutexReleased(true, null);
		}

		#region enumメンバー

		/// <summary>
		/// アプリケーション起動状態
		/// </summary>
		/// <remarks>
		/// <br>Note　　　　　　 :   Running = 起動中</br>
		/// <br>                 :   NotRunning = 起動なし</br>
		/// <br>Programmer       :   鹿野 幸生</br>                           
		/// <br>Date             :   2005.07.08</br>
		/// </remarks>
		public enum State
		{
			/// <summary>起動中</summary>
			Running,
			/// <summary>起動なし</summary>
			NotRunning
		}

		#endregion

		#region IDisposable Members

		/// <summary>
		/// ミューテクスオブジェクト終了処理
		/// </summary>
		/// <remarks>
		/// <br>Note　　　　　　 :   ミューテックスオブジェクトが生成されている場合は開放します</br>
		/// <br>                 :   その後、ミューテックスオブジェクトを閉じます</br>
		/// <br>Programmer       :   鹿野 幸生</br>                           
		/// <br>Date             :   2005.07.08</br>
		/// </remarks>
		public void Dispose()
		{
			//このミューテックスによりアプリケーションが起動された場合（ミューテックス生成時）
			if(this._ApplicationState == State.NotRunning)
			{
				mutex.ReleaseMutex();//ミューテクス開放
			}

			mutex.Close();//ミューテクス終了
		}

		#endregion
	}

    /// <summary>ログイン情報クラス</summary>
    /// <summary>
    /// AddRegsiterMenuApp
    /// </summary>
    /// <remarks>
    /// <br>Note       : 外部呼出し(メニュー呼び出し)用認証チェック・App登録クラス</br>
    /// <br>Programmer : 96203 鹿野　幸生</br>
    /// <br>Date       : 2006.09.04</br>
    /// <br></br>
    /// <br>Update Note: 200x.xx.xx ＸＸ  ＸＸ</br>
    /// </remarks>
    public class LoginInfoFromExt
    {
        private string _EnterpriseCode;
        private string _EnterpriseName;
        private string _EmployeeCode;
        private string _EmployeeName;
        private string _ProductCode;
        private bool   _OnlineMode;

        public LoginInfoFromExt()
        {
            _EnterpriseCode = "";
            _EnterpriseName = "";
            _EmployeeCode = "";
            _EmployeeName = "";
            _ProductCode = "";
            _OnlineMode = false;
        }

        /// <summary>企業コードプロパティ</summary>
        /// <value>企業コード</value>
        /// <remarks></remarks>
        public string EnterpriseCode
        {
            get { return _EnterpriseCode; }
            set { _EnterpriseCode = value; }
        }
        /// <summary>企業情報プロパティ</summary>
        /// <value>企業情報</value>
        /// <remarks></remarks>
        public string EnterpriseName
        {
            get { return _EnterpriseName; }
            set { _EnterpriseName = value; }
        }
        /// <summary>従業員コードプロパティ</summary>
        /// <value>従業員コード</value>
        /// <remarks></remarks>
        public string EmployeeCode
        {
            get { return _EmployeeCode; }
            set { _EmployeeCode = value; }
        }
        /// <summary>従業員名称プロパティ</summary>
        /// <value>従業員名称</value>
        /// <remarks></remarks>
        public string EmployeeName
        {
            get { return _EmployeeName; }
            set { _EmployeeName = value; }
        }
        /// <summary>製品コードプロパティ</summary>
        /// <value>製品コード</value>
        /// <remarks></remarks>
        public string ProductCode
        {
            get { return _ProductCode; }
            set { _ProductCode = value; }
        }
        /// <summary>オンラインモードプロパティ</summary>
        /// <value>オンラインモード</value>
        /// <remarks></remarks>
        public bool OnlienMode
        {
            get { return _OnlineMode; }
            set { _OnlineMode = value; }
        }


    }

    /// <summary>
    /// DirSettiingクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 設定ファイル格納ディレクトリ取得</br>
    /// <br>Programmer : 96203 鹿野　幸生</br>
    /// <br>Date       : 2006.09.04</br>
    /// <br></br>
    /// <br>Update Note: 200x.xx.xx ＸＸ  ＸＸ</br>
    /// </remarks>
    public class DirSettiing
    {
        public enum DirType
        {
            AppSettingDataDir,
            NavigationDataDir
        }
        
        private static Assembly SFCMN00505MOD;
        private static Type SFCMN00505MOD_ConstantManagement_ClientDirectory;
        private static string AppSettingDataDir = "";
        private static string NavigationDataDir = "";

        /// <summary>
        /// 設定ファイル格納ディレクトリ取得処理
        /// </summary>
        /// <param name="GetDirType">取得ディレクトリタイプ</param>
        /// <returns>取得文字列</returns>
        /// <remarks>
        /// <br>Note       :設定ファイル格納ディレクトリ取得</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.09.04</br>
        /// </remarks>
        public static string GetDirectory(DirType GetDirType)
        {
            try
            {
                //  SFCMN00505のクラスをインスタンス化
                if (AppSettingDataDir.Length == 0)
                {
                    SFCMN00505MOD = Assembly.LoadFrom("SFCMN00505C.dll");
                    SFCMN00505MOD_ConstantManagement_ClientDirectory = SFCMN00505MOD.GetType("Broadleaf.Application.Resources.ConstantManagement_ClientDirectory");
                    if (SFCMN00505MOD_ConstantManagement_ClientDirectory != null)
                    {
                        AppSettingDataDir = (string)SFCMN00505MOD_ConstantManagement_ClientDirectory.InvokeMember("MenuSettings_AppSettingData", BindingFlags.Public | BindingFlags.Static | BindingFlags.GetField | BindingFlags.GetProperty, null, null, null);
                        NavigationDataDir = (string)SFCMN00505MOD_ConstantManagement_ClientDirectory.InvokeMember("MenuSettings_NavigationData", BindingFlags.Public | BindingFlags.Static | BindingFlags.GetField | BindingFlags.GetProperty, null, null, null);
                    }
                }

                if (GetDirType == DirType.AppSettingDataDir)
                {
                    return AppSettingDataDir;
                }
                else
                {
                    return NavigationDataDir;
                }
            }
            catch (Exception)
            {
                return "";
            }

        }


    }


    /// <summary>
    /// AddRegsiterMenuApp
    /// </summary>
    /// <remarks>
    /// <br>Note       : 外部呼出し(メニュー呼び出し)用認証チェック・App登録クラス</br>
    /// <br>Programmer : 96203 鹿野　幸生</br>
    /// <br>Date       : 2006.09.04</br>
    /// <br></br>
    /// <br>Update Note: 2009.09.14  21024 佐々木　接続先情報取得処理の追加</br>
    /// </remarks>
    public class AddRegsiterMenuApp
    {
        private Assembly SFCMN00607MOD;
        private Type SFCMN00607MOD_ApplicationStartControl;
        private object Asc;
        private MethodInfo SFCMN00607MOD_StartApplication;
        private MethodInfo SFCMN00607MOD_EndApplication;

        private static Assembly SFCMN00651MOD;
        private Type SFCMN00651MOD_LoginInfoAcquisition;
        private object lia;
        private MethodInfo SFCMN00651MOD_GetConnectionInfo;
        private MethodInfo SFCMN00651MOD_SoftwarePurchasedCheckForCompany;
        private MethodInfo SFCMN00651MOD_SoftwarePurchasedCheckForUSB;
        // 2008.09.28 sugi -<<
        private MethodInfo SFCMN00651MOD_GetAPServiceTargetDomain;              //  2007.06.06  追加
        // 2008.09.28 sugi -<<
        // 2009.09.14 Add >>>
        //private MethodInfo SFCMN00651MOD_GetGetConnectionInfo;
        // 2009.09.14 Add <<<
        private PropertyInfo SFCMN00651MOD_OnlineFlag;
        private PropertyInfo SFCMN00651MOD_Employee;
        private PropertyInfo SFCMN00651MOD_EnterpriseCode;
        private PropertyInfo SFCMN00651MOD_EnterpriseName;
        private PropertyInfo SFCMN00651MOD_ProductCode;

        private Assembly SFTOK09381MOD;
        private Type SFTOK09381MOD_Employee;
        private object emp;
        private PropertyInfo SFTOK09381MOD_EmployeeCode;
        private PropertyInfo SFTOK09381MOD_EmployeeName;


        /// <summary>
        /// AddRegsiterMenuAppコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 外部呼出し(メニュー呼び出し)用認証チェック・App登録クラスコンストラクタ</br>
        /// <br>Programmer : 96203 鹿野　幸生</br>
        /// <br>Date       : 2006.09.04</br>
        /// </remarks>
        public AddRegsiterMenuApp()
        {

            try
            {
                // Get the type of MySimpleClass.
                SFCMN00607MOD = Assembly.LoadFrom("SFCMN00607C.dll");
                SFCMN00607MOD_ApplicationStartControl = SFCMN00607MOD.GetType("Broadleaf.Application.Common.ApplicationStartControl");
                if (SFCMN00607MOD_ApplicationStartControl != null)
                {
                    //  SFCMN00607のクラスをインスタンス化
                    Asc = (object)Activator.CreateInstance(SFCMN00607MOD_ApplicationStartControl);
                    SFCMN00607MOD_StartApplication = SFCMN00607MOD_ApplicationStartControl.GetMethod("StartApplication", BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
                    SFCMN00607MOD_EndApplication = SFCMN00607MOD_ApplicationStartControl.GetMethod("EndApplication", BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);

                }
                //  SFCMN00651のクラスをインスタンス化
                SFCMN00651MOD = Assembly.LoadFrom("SFCMN00651C.dll");
                SFCMN00651MOD_LoginInfoAcquisition = SFCMN00651MOD.GetType("Broadleaf.Application.Common.LoginInfoAcquisition");
                if (SFCMN00651MOD_LoginInfoAcquisition != null)
                {
                    lia = (object)Activator.CreateInstance(SFCMN00651MOD_LoginInfoAcquisition);
                    SFCMN00651MOD_OnlineFlag = SFCMN00651MOD_LoginInfoAcquisition.GetProperty("OnlineFlag", BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
                    SFCMN00651MOD_Employee = SFCMN00651MOD_LoginInfoAcquisition.GetProperty("Employee", BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
                    SFCMN00651MOD_EnterpriseCode = SFCMN00651MOD_LoginInfoAcquisition.GetProperty("EnterpriseCode", BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
                    SFCMN00651MOD_EnterpriseName = SFCMN00651MOD_LoginInfoAcquisition.GetProperty("EnterpriseName", BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
                    SFCMN00651MOD_ProductCode = SFCMN00651MOD_LoginInfoAcquisition.GetProperty("ProductCode", BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
                    SFCMN00651MOD_GetConnectionInfo = SFCMN00651MOD_LoginInfoAcquisition.GetMethod("GetConnectionInfo", BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
                    SFCMN00651MOD_SoftwarePurchasedCheckForCompany = SFCMN00651MOD_LoginInfoAcquisition.GetMethod("SoftwarePurchasedCheckForCompany", BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static, null, new Type[] { typeof(string)}, null);
                    SFCMN00651MOD_SoftwarePurchasedCheckForUSB = SFCMN00651MOD_LoginInfoAcquisition.GetMethod("SoftwarePurchasedCheckForUSB", BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static, null, new Type[] { typeof(string)}, null);
                    //2008.09.26 sugi --<<
                    SFCMN00651MOD_GetAPServiceTargetDomain = SFCMN00651MOD_LoginInfoAcquisition.GetMethod("GetAPServiceTargetDomain", BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static, null, new Type[] { typeof(string) }, null);              //  2007.06.06  追加
                    //2008.09.26 sugi --<<
                    // 2009.09.14 Add >>>
                    SFCMN00651MOD_GetConnectionInfo = SFCMN00651MOD_LoginInfoAcquisition.GetMethod("GetConnectionInfo", BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static, null, new Type[] { typeof(string), typeof(string) }, null);
                    // 2009.09.14 Add <<<

                    //        public string GetConnectionInfo(string serviceCode, string indexCode);
                    //        public static Broadleaf.Application.Remoting.ParamData.PurchaseStatus SoftwarePurchasedCheckForCompany(string softwareCode);
                    //        public static Broadleaf.Application.Remoting.ParamData.PurchaseStatus SoftwarePurchasedCheckForCompany(string softwareCode, out int SoftwareType);
                    //        public static Broadleaf.Application.Remoting.ParamData.PurchaseStatus SoftwarePurchasedCheckForCompany(string softwareCode, out int SoftwareType, object company);
                    //        public static Broadleaf.Application.Remoting.ParamData.PurchaseStatus SoftwarePurchasedCheckForUSB(string softwareCode);
                    //        public static Broadleaf.Application.Remoting.ParamData.PurchaseStatus SoftwarePurchasedCheckForUSB(string softwareCode, out int SoftwareType);
                    //        public static Broadleaf.Application.Remoting.ParamData.PurchaseStatus SoftwarePurchasedCheckForUSB(string softwareCode, out int SoftwareType, object company);
               
                }
                //  SFTOK09381のクラスをインスタンス化
                SFTOK09381MOD = Assembly.LoadFrom("SFTOK09381E.dll");
                SFTOK09381MOD_Employee = SFTOK09381MOD.GetType("Broadleaf.Application.UIData.Employee");
                if (SFTOK09381MOD_Employee != null)
                {
                    emp = (object)Activator.CreateInstance(SFTOK09381MOD_Employee);
                    SFTOK09381MOD_EmployeeCode = SFTOK09381MOD_Employee.GetProperty("EmployeeCode", BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
                    SFTOK09381MOD_EmployeeName = SFTOK09381MOD_Employee.GetProperty("Name", BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
                }
            }
            catch (Exception er)
            {
                //  引数エラーでアプリケーション終了
                SFNETMENU2Utilities.ShowMessage(SFNETMENU2Utilities.MessageDlgLevel.msgErrLevelError, "Init", "モジュールエラー", er.Message, "-991");
                System.Windows.Forms.Application.Exit();
            }

        }

        /// <summary>
        /// 起動処理
        /// </summary>
        /// <param name="sArgs">コマンドライン引数</param>
        /// <param name="errMsg">エラー発生時メッセージ文字列</param>
        /// <param name="eventHandler">エラー発生時起動イベント</param>
        /// <returns>次フォーム移動結果</returns>
        /// <remarks>
        /// <br>Note       :外部呼出し(主にメニュー)時に使用される</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.09.04</br>
        /// </remarks>
        public int Startup(ref string[] sArgs, out string errMsg, out LoginInfoFromExt loginInfo, EventHandler eventHandler)
        {
            errMsg = "";
            string AppName = "Partsman";  //  2008.04.22  変更 sugi
            int status;

            loginInfo = new LoginInfoFromExt();

            try
            {
                status = (int)SFCMN00607MOD_StartApplication.Invoke(Asc, BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static, null, new object[] { (object)errMsg, (object)sArgs, (object)AppName, (object)eventHandler }, null);
                if (status == 0)
                {
                    bool st = (bool)SFCMN00651MOD_OnlineFlag.GetValue(lia, null);
                    if (!st)
                    {
                        //  オフラインモード
                        status = 1;
                    }
                    try
                    {
                        //  ログイン情報を保存
                        emp = (object)SFCMN00651MOD_Employee.GetValue(lia, null);
                        loginInfo.EnterpriseCode = (string)SFCMN00651MOD_EnterpriseCode.GetValue(lia, null);
                        loginInfo.EnterpriseName = (string)SFCMN00651MOD_EnterpriseName.GetValue(lia, null);
                        loginInfo.ProductCode = (string)SFCMN00651MOD_ProductCode.GetValue(lia, null);
                        loginInfo.EmployeeCode = (string)SFTOK09381MOD_EmployeeCode.GetValue(emp, null);
                        loginInfo.EmployeeName = (string)SFTOK09381MOD_EmployeeName.GetValue(emp, null);
                        loginInfo.OnlienMode = (bool)SFCMN00651MOD_OnlineFlag.GetValue(lia, null);
                    }
                    catch (Exception ex)
                    {
                        errMsg = "エラーが発生しました。本機能はご使用できません。\n" + ex.Message;
                        status = -999;
                    }
                }
                 else
                 {
                     // エラー表示
                     if (errMsg.ToString().Length == 0)
                    {
                        errMsg = "エラーが発生しました。本機能はご使用できません。\n\nログインされましたか？";
                    }
                 }
            }
            catch (Exception er)
            {
                errMsg = "エラーが発生しました。本機能はご使用できません。\n" + er.Message;
                status = -999;
            }

            return status;

        }


        public int SoftwarePurchasedCheckForCompany(string SoftwareCode)
        {
            return (int)SFCMN00651MOD_SoftwarePurchasedCheckForCompany.Invoke(lia, BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static, null, new object[] { (object)SoftwareCode }, null);
        }
        public int SoftwarePurchasedCheckForUSB(string SoftwareCode)
        {
            return (int)SFCMN00651MOD_SoftwarePurchasedCheckForUSB.Invoke(lia, BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static, null, new object[] { (object)SoftwareCode }, null);
        }
        //2008.09.26 sugi --<<
        public string GetAPServiceTargetDomain(string ServiceCode)
        {
            return (string)SFCMN00651MOD_GetAPServiceTargetDomain.Invoke(lia, BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static, null, new object[] { (object)ServiceCode }, null);
        }
        //2008.09.26 sugi --<<
        // 2009.09.14 Add >>>
        public string GetConnectionInfo(string ServiceCode, string IndexCode)
        {
            return (string)SFCMN00651MOD_GetConnectionInfo.Invoke(lia, BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static, null, new object[] { (object)ServiceCode, (object)IndexCode }, null);
        }
        // 2009.09.14 Add <<<

        /// <summary>
        /// 起動処理
        /// </summary>
        /// <param name="sArgs">コマンドライン引数</param>
        /// <param name="errMsg">エラー発生時メッセージ文字列</param>
        /// <param name="eventHandler">エラー発生時起動イベント</param>
        /// <returns>次フォーム移動結果</returns>
        /// <remarks>
        /// <br>Note       :外部呼出し(主にメニュー)時に使用される</br>
        /// <br>Programmer  : 96203 鹿野　幸生</br>
        /// <br>Date        : 2006.09.04</br>
        /// </remarks>
        public void Fihisher()
        {
            try
            {
                SFCMN00607MOD_EndApplication.Invoke(Asc, BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static, null, null, null);
            }
            catch
            {
                
            }

        }

    }


    //  以下の内容はセキュリティの為、わざとコメントを書かない
    public class SystemCheck
    {

        private static ArrayList _arSystemCode = new ArrayList();

        public static int ClearSystemCode()
        {
            try
            {
                _arSystemCode.Clear();
                return (0);
            }
            catch
            {
                return (5);
            }

        }

        public static int AddSystemCode(string SystemCode)
        {
            try
            {
                _arSystemCode.AddRange(SystemCode.Split(','));
                return (0);
            }
            catch
            {
                return (5);
            }

        }

        // 0:単独で入っている、1:他のシステムと共に入っている、-1or-3：入ってない
        private static int CheckInstallSystem(string SystemCode)
        {
            try
            {
                bool bHit = false;
                //string TargetSystem;
                for (int i = 0; i < _arSystemCode.Count; i++)
                {
                    if (SystemCode == _arSystemCode[i].ToString())
                    {
                        //  システムが入ってないならNG
                        //if (Program.arm.SoftwarePurchasedCheckForUSB(SystemCode) == 0)  // DEL 2013/12/19
                        if (Program.arm.SoftwarePurchasedCheckForUSB(SystemCode) <= 0)  // ADD 2013/12/19
                        {
                            return (-1);
                        }
                        bHit = true;
                        break;
                    }
                }
                //  見つからなければこの時点でNG
                if (bHit == false)
                {
                    return (-3);
                }
                //  システムが入っているなら、単体かどうかを調べる
                for (int i = 0; i < _arSystemCode.Count; i++)
                {
                    if (SystemCode != _arSystemCode[i].ToString())
                    {
                        //if (Program.arm.SoftwarePurchasedCheckForUSB(_arSystemCode[i].ToString()) != 0)  // DEL 2013/12/19
                        if (Program.arm.SoftwarePurchasedCheckForUSB(_arSystemCode[i].ToString()) > 0)  // ADD 2013/12/19
                        {
                            //  その他のシステムが入っていれば、1
                            return (1);
                        }
                    }
                }
                //  単体ならゼロ
                return (0);
            }
            catch (Exception)
            {
                return (-9); 
            }
        }

        public static int CheckSystemPermissionFunction(DataRow chkRow)
        {
            try
            {
                //                                                          //  2006.09.29  削除
                /*
                string SoftwareCode = "";
                if (chkRow["SystemCode"].ToString().Length != 0)
                {
                    SoftwareCode = chkRow["SystemCode"].ToString();
                }

                string OptionCode = "";
                if (chkRow["OptionCode"].ToString().Length != 0)
                {
                    OptionCode = chkRow["OptionCode"].ToString();
                }
                else if (SoftwareCode.Length == 0)
                {
                    return 1;
                }

                string[] ChkCode;
                if (OptionCode.Length != 0)
                {
                    ChkCode = OptionCode.Split(new Char[] { ',' });
                }
                else if (SoftwareCode.Length != 0)
                {
                    ChkCode = SoftwareCode.Split(new Char[] { ',' });
                }
                else
                {
                    ChkCode = new string[] { "" };
                }

                int nRtnCd = 0;
                bool bAndEnable = false;                                     //  且つ条件う有無
                bool bPreConditionEnable = false;                            //  且つ条件有りで、最新のチェック結果
                bool bLessEnable = false;                                    //  レスオプション有無
                int i = 0;
                while (i < ChkCode.Length)
                {

                    //  レスオプションを判定
                    if (ChkCode[i].Substring(0, 1) == "-")
                    {
                        bLessEnable = true;
                        ChkCode[i] = ChkCode[i].Substring(1);
                    }
                    else
                    {
                        bLessEnable = false;
                    }
                    //  且つ条件のオプションを判定
                    if (ChkCode[i].Substring(0, 1) == "+")
                    {
                        bAndEnable = true;
                        ChkCode[i] = ChkCode[i].Substring(1);
                    }
                    else
                    {
                        bAndEnable = false;
                    }

                    if ((nRtnCd = Program.arm.SoftwarePurchasedCheckForUSB(ChkCode[i])) != 0)
                    {

                        //  レスオプションなら、オプション有りでNG(最優先チェック)
                        if (bLessEnable == true)
                        {
                            nRtnCd = 0;
                            break;

                        }

                        //  且つオプション無しなら、一個単位で判断
                        if ((bAndEnable == false) && (bPreConditionEnable == false))
                        {
                            break;
                        }
                        else
                        {
                            //  現在のオプションが且つ条件なら、結果をクリアして更に継続
                            if (bAndEnable == true)
                            {
                                nRtnCd = 0;
                                bPreConditionEnable = true;
                            }
                            else
                            {
                                //  現在のオプションが且つ条件で無いなら、OKとしてここで終了
                                bPreConditionEnable = false;
                                break;
                            }

                        }
                    }
                    else
                    {
                        //  レスオプションなら、
                        if (bLessEnable == true)
                        {
                            //  次のオプションチェック対象が有れば、判断はそちらの正否にゆだねる。そうでなければチェックOKとする
                            nRtnCd = 1;

                        }

                        //  且つ条件オプション有りなら
                        if (bAndEnable == true)
                        {
                            //  一つ前が且つ条件オプションで、且つオプション判定失敗ならこのセットの条件は不成立として、次の条件でトライする

                            //  今回も且つ条件なら、この次のオプションは最初から不成立だと分かっているので、飛ばす
                            for (int j = i+1; j < ChkCode.Length;j++)
                            {
                                if (ChkCode[j].Substring(0, 1) != "+")
                                {
                                    i = j;              //＋以外のが現れた次の項目から再スタート
                                    break;
                                }
                                if (j >= (ChkCode.Length - 1))
                                {
                                    i = ChkCode.Length;
                                }
                            }
                            //  フラグをリセット
                            bAndEnable = false;
                        }
                    }

                    i++;

                }
                return nRtnCd;
                */
                //                                                          //  2006.09.29  追加 VV
                string[] ChkCode;
                if (chkRow["SysOpCode"].ToString().Length != 0)
                {
                    ChkCode = chkRow["SysOpCode"].ToString().Split(new Char[] { ',' });
                }
                else
                {
                    return 1;
                }
                return (CheckSystemPermissionFunctionBody(ChkCode));
                //                                                          //  2006.09.29  追加 AA
            }
            catch (Exception)
            {
                return 0;
            }
        }

        //public static int CheckSystemPermissionFunction(string iSoftwareCode, string iOptionCode)         //  2006.09.29  変更
        public static int CheckSystemPermissionFunction(string iSysOpCode)
        {
            try
            {
                //                                                      //  2006.09.29  削除 
                /*                                          
                string SoftwareCode = "";
                if (iSoftwareCode.Trim().Length != 0)
                {
                    SoftwareCode = iSoftwareCode.Trim();
                }

                string OptionCode = "";
                if (iOptionCode.Trim().Length != 0)
                {
                    OptionCode = iOptionCode.Trim().ToString();
                }
                else if (SoftwareCode.Length == 0)
                {
                    return 1;
                }
                string[] ChkCode;
                if (OptionCode.Length != 0)
                {
                    ChkCode = OptionCode.Split(new Char[] { ',' });
                }
                else if (SoftwareCode.Length != 0)
                {
                    ChkCode = SoftwareCode.Split(new Char[] { ',' });
                }
                else
                {
                    ChkCode = new string[] { "" };
                }
                
                int nRtnCd = 0;
                bool bAndEnable = false;                                     //  且つ条件う有無
                bool bPreConditionEnable = false;                            //  且つ条件有りで、最新のチェック結果
                bool bLessEnable = false;                                    //  レスオプション有無
                int i = 0;
                while (i < ChkCode.Length)
                {

                    //  レスオプションを判定
                    if (ChkCode[i].Substring(0, 1) == "-")
                    {
                        bLessEnable = true;
                        ChkCode[i] = ChkCode[i].Substring(1);
                    }
                    else
                    {
                        bLessEnable = false;
                    }
                    //  且つ条件のオプションを判定
                    if (ChkCode[i].Substring(0, 1) == "+")
                    {
                        bAndEnable = true;
                        ChkCode[i] = ChkCode[i].Substring(1);
                    }
                    else
                    {
                        bAndEnable = false;
                    }

                    if ((nRtnCd = Program.arm.SoftwarePurchasedCheckForUSB(ChkCode[i])) != 0)
                    {
                        //  レスオプションなら、オプション有りでNG(最優先チェック)
                        if (bLessEnable == true)
                        {
                            nRtnCd = 0;
                            break;

                        }

                        //  且つオプション無しなら、一個単位で判断
                        if ((bAndEnable == false) && (bPreConditionEnable == false))
                        {
                            break;
                        }
                        else
                        {
                            //  現在のオプションが且つ条件なら、結果をクリアして更に継続
                            if (bAndEnable == true)
                            {
                                nRtnCd = 0;
                                bPreConditionEnable = true;
                            }
                            else
                            {
                                //  現在のオプションが且つ条件で無いなら、OKとしてここで終了
                                bPreConditionEnable = false;
                                break;
                            }

                        }
                    }
                    else
                    {
                        //  レスオプションなら、
                        if (bLessEnable == true)
                        {
                            //  次のオプションチェック対象が有れば、判断はそちらの正否にゆだねる。そうでなければチェックOKとする
                            nRtnCd = 1;

                        }

                        //  且つ条件オプション有りなら
                        if (bAndEnable == true)
                        {
                            //  一つ前が且つ条件オプションで、且つオプション判定失敗ならこのセットの条件は不成立として、次の条件でトライする

                            //  今回も且つ条件なら、この次のオプションは最初から不成立だと分かっているので、飛ばす
                            for (int j = i + 1; j < ChkCode.Length; j++)
                            {
                                if (ChkCode[j].Substring(0, 1) != "+")
                                {
                                    i = j;              //＋以外のが現れた次の項目から再スタート
                                    break;
                                }
                                if (j >= (ChkCode.Length - 1))
                                {
                                    i = ChkCode.Length;
                                }
                            }
                            //  フラグをリセット
                            bAndEnable = false;
                        }
                    }

                    i++;

                }
                return nRtnCd;
                */
                //                                                          //  2006.09.29  追加 VV
                string[] ChkCode;
                if (iSysOpCode.Length != 0)
                {
                    ChkCode = iSysOpCode.Split(new Char[] { ',' });
                }
                else
                {
                    return 1;
                }
                return (CheckSystemPermissionFunctionBody(ChkCode));
                //                                                          //  2006.09.29  追加 AA

            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static int CheckSystemPermissionFunctionBody(string[] ChkCode)
        {
            try
            {

                int nRtnCd = 0;
                bool bLessEnable = false;                                    //  レスオプション有無

                int i = 0;
                while (i < ChkCode.Length)
                {
                    //	且つ条件が有るかをチェックして、有る場合は分解して再帰処理
					if (ChkCode[i].IndexOf("&") > -1)
					{
                        bool bPermit = true;
                        string[] wkCheckCode = ChkCode[i].Split('&');
                        for (int j=0;j<wkCheckCode.Length;j++)
                        {
                            //  単体チェックを繰り返して、その間に条件不成立があればNG
                            if (CheckSystemPermissionFunctionBody(new string [] {wkCheckCode[j]}) == 0)
                            {
                                bPermit = false;
                                break;
                            }
                        }
                        //  全条件がOKなら表示可能
                        if (bPermit == true)
                        {
                            return (1);
                        }
                        else
                        {
                            i++;
                            continue;
                        }
			
					}

                    //  システム単体時に表示NG
                    if (ChkCode[i].Substring(0, 1) == "=")
                    {
                        if (CheckInstallSystem(ChkCode[i].Substring(1)) == 0)
                        {
                            return (0);
                        }
                        i++;
                        if (i >= ChkCode.Length)
                        {
                            return (1);
                        }
                        continue;
                    }

                    //  レスオプションを判定
                    if (ChkCode[i].Substring(0, 1) == "-")
                    {
                        bLessEnable = true;
                        ChkCode[i] = ChkCode[i].Substring(1);
                    }
                    else
                    {
                        bLessEnable = false;
                    }

                    //  システム単体時に表示OK
                    if (ChkCode[i].Substring(0, 1) == "*")
                    {
                        if (CheckInstallSystem(ChkCode[i].Substring(1)) == 0)
                            {
                            return (1);
                        }
                        i++;
                        if (i >= ChkCode.Length)
                        {
                            //return (1);                                       //  2007.02.23  変更
                            return (0);
                        }
                        continue;
                    }

                    //if ((nRtnCd = Program.arm.SoftwarePurchasedCheckForUSB(ChkCode[i])) != 0) // DEL 2013/12/19
                    if ((nRtnCd = Program.arm.SoftwarePurchasedCheckForUSB(ChkCode[i])) > 0)  // ADD 2013/12/19
                    {
                        //  レスオプションなら、オプション有りでNG(最優先チェック)
                        if (bLessEnable == true)
                        {
                            nRtnCd = 0;
                        }

                        break;
                    }
                    else
                    {
                        //オプションの受注期間期限切れの場合,マイナスのステータスとなるので戻り値を置換
                        nRtnCd = 0; // ADD 2013/12/19

                        //  レスオプションなら、
                        if (bLessEnable == true)
                        {
                            //  次のオプションチェック対象が有れば、判断はそちらの正否にゆだねる。そうでなければチェックOKとする
                            nRtnCd = 1;

                        }

                    }

                    i++;

                }
                return nRtnCd;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        /// <summary>
        /// ロールの確認
        /// </summary>
        /// <param name="targetString">権限</param>
        /// <param name="roleLevel">権限レベル</param>
        /// <returns>0:権限無し 1:権限有り</returns>
        public static int CheckUseEnable(string targetString, int roleLevel)
        {
            // 設定値と等しいか設定値より大きい場合
            if (targetString.IndexOf("<=") != -1)
            {
                targetString = targetString.Replace("<=", "");

                if (roleLevel <= Int32.Parse(targetString.Trim()))
                {
                    return 1;
                }
            }
            // 設定値と等しいか設定値より小さい場合
            else if (targetString.IndexOf(">=") != -1)
            {
                targetString = targetString.Replace(">=", "");

                if (roleLevel >= Int32.Parse(targetString.Trim()))
                {
                    return 1;
                }
            }
            // 設定値と等しくない場合
            else if (targetString.IndexOf("!=") != -1)
            {
                targetString = targetString.Replace("!=", "");

                if (roleLevel != Int32.Parse(targetString.Trim()))
                {
                    return 1;
                }
            }
            // 設定値より大きい条件
            else if (targetString.IndexOf("<") != -1)
            {
                targetString = targetString.Replace("<", "");

                if (roleLevel < Int32.Parse(targetString.Trim()))
                {
                    return 1;
                }
            }
            // 設定値より小さい条件
            else if (targetString.IndexOf(">") != -1)
            {
                targetString = targetString.Replace(">", "");

                if (roleLevel > Int32.Parse(targetString.Trim()))
                {
                    return 1;
                }
            }
            // 設定値と等しい条件
            else if (targetString.IndexOf("=") != -1)
            {
                targetString = targetString.Replace("=", "");

                if (roleLevel == Int32.Parse(targetString.Trim()))
                {
                    return 1;
                }
            }
            // 条件が指定されていないと判断
            else
            {
                return 1;
            }
            return 0;
        }

        /// <summary>
        /// カテゴリ利用権限チェック
        /// </summary>
        /// <param name="row">チェック対象レコード</param>
        /// <returns>true: 利用可能 false: 利用不可能</returns>
        public static bool CheckAuthority(DataRow row)
        {
            int checkResults1 = -1;
            int checkResults2 = -1;
            int checkResults3 = -1;
            int checkResults4 = -1;
            int checkResults5 = -1;
            int checkResults6 = -1;

            if (row["UseEnableDiv1"].ToString().Trim() != "")
            {
                checkResults1 = CheckUseEnable(row["UseEnableDiv1"].ToString().Trim(), LoginInfoAcquisition.Employee.AuthorityLevel1);
            }

            if (row["UseEnableDiv2"].ToString().Trim() != "")
            {
                checkResults2 = CheckUseEnable(row["UseEnableDiv2"].ToString().Trim(), LoginInfoAcquisition.Employee.AuthorityLevel1);
            }

            if (row["UseEnableDiv3"].ToString().Trim() != "")
            {
                checkResults3 = CheckUseEnable(row["UseEnableDiv3"].ToString().Trim(), LoginInfoAcquisition.Employee.AuthorityLevel1);
            }

            if (row["UseEnableDiv4"].ToString().Trim() != "")
            {
                checkResults4 = CheckUseEnable(row["UseEnableDiv4"].ToString().Trim(), LoginInfoAcquisition.Employee.AuthorityLevel2);
            }

            if (row["UseEnableDiv5"].ToString().Trim() != "")
            {
                checkResults5 = CheckUseEnable(row["UseEnableDiv5"].ToString().Trim(), LoginInfoAcquisition.Employee.AuthorityLevel2);
            }

            if (row["UseEnableDiv6"].ToString().Trim() != "")
            {
                checkResults6 = CheckUseEnable(row["UseEnableDiv6"].ToString().Trim(), LoginInfoAcquisition.Employee.AuthorityLevel2);
            }

            // チェック結果を確認

            // 条件が無かった場合もしくは条件が１つでも通る場合
            if ((checkResults1 == -1 && checkResults2 == -1 && checkResults3 == -1 &&
                checkResults4 == -1 && checkResults5 == -1 && checkResults6 == -1) ||
                (checkResults1 == 1 || checkResults2 == 1 || checkResults3 == 1 ||
                 checkResults4 == 1 || checkResults5 == 1 || checkResults6 == 1))
            {
                return true;
            }
            
            return false;
        }
    }


    /// <summary>
    /// SystemReportList
    /// </summary>
    /// <remarks>
    /// <br>Note       : 外部呼出し(メニュー呼び出し)システムレポートクラス</br>
    /// <br>Programmer : 96203 鹿野　幸生</br>
    /// <br>Date       : 2006.09.04</br>
    /// <br></br>
    /// <br>Update Note: 200x.xx.xx ＸＸ  ＸＸ</br>
    /// </remarks>
    public class SystemReportList
    {
        private Assembly SFMNUKN00201MOD;
        private Type SFMNUKN00201C_SystemReport;
        private string sPass = "gFeua";
        private object ssr;
        private MethodInfo SFMNUKN00201C_ReportSoftware;
        string errMsg = "";

        /// <summary>
        /// SystemReportListコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 外部呼出し(メニュー呼び出し)システムレポートクラス</br>
        /// <br>Programmer : 96203 鹿野　幸生</br>
        /// <br>Date       : 2006.09.04</br>
        /// </remarks>
        public SystemReportList()
        {

            try
            {
                // Get the type of MySimpleClass.
                SFMNUKN00201MOD = Assembly.LoadFrom("SFUKN00201C.dll");
                SFMNUKN00201C_SystemReport = SFMNUKN00201MOD.GetType("Broadleaf.Application.Common.SystemReport");
                if (SFMNUKN00201C_SystemReport != null)
                {
                    //  SFCMN00607のクラスをインスタンス化
                    ssr = (object)Activator.CreateInstance(SFMNUKN00201C_SystemReport);
                    SFMNUKN00201C_ReportSoftware = SFMNUKN00201C_SystemReport.GetMethod("ReportSoftware", BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);

                }
            }
            catch (Exception er)
            {
                //  引数エラーでアプリケーション終了
                SFNETMENU2Utilities.ShowMessage(SFNETMENU2Utilities.MessageDlgLevel.msgErrLevelError, "SystemReport", "システムレポート・モジュールエラー", er.Message, "-991");
            }

        }

        //public int ReportSoftware()                                   //  2006.09.29  変更
        public int ReportSoftware(string[] prodcuts)
        {
            errMsg = "";
            //string AppName = "SuperFrontman";                         //  2006.09.29  変更
            int status;

            try
            {
                status = (int)SFMNUKN00201C_ReportSoftware.Invoke(ssr, BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static, null, new object[] {(object)sPass }, null);
                if (status == 0)
                {

                }
                else
                {
                    // エラー表示
                    if (errMsg.ToString().Length == 0)
                    {
                        errMsg = "エラーが発生しました。";
                    }
                }
            }
            catch (Exception er)
            {
                errMsg = "エラーが発生しました。\n" + er.Message;
                status = -999;
            }

            return status;

        }
    }
}
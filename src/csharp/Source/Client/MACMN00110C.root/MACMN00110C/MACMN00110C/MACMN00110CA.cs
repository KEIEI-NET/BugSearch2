using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Runtime.InteropServices;
using System.IO;
using System.Threading;

using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;

namespace Broadleaf.Application.Common
{
	/// <summary>
	/// 操作履歴ログＩＯクラス
	/// </summary>
	/// <remarks>
    /// <br>---------------------------------------------------------------------------------------</br>
    /// <br>Note       : 操作履歴ログのＩ／Ｏを行うクラスです。</br>
    /// <br>Programmer : 18012 Y.Sasaki</br>
    /// <br>Date       : 2006.12.18</br>
    /// <br>---------------------------------------------------------------------------------------</br>
    /// <br>Note       : 項目追加(ﾛｸﾞｵﾍﾟﾚｰｼｮﾝ明細ｺｰﾄﾞ,権限ﾚﾍﾞﾙ1,権限ﾚﾍﾞﾙ2)</br>
    /// <br>           : 項目名変更(LogDataCreateDataTimeRF   → LogDataCreateDtTmRF</br>
    /// <br>           :            LogDataMsgContentsRF      → LogOprtnDataSummaryRF</br>
    /// <br>           :            LogDataObjBootProgramNmRF → LogDataObjBootPgNameRF)</br>
    /// <br>Programmer : 30005 木建　翼</br>
    /// <br>Date       : 2008.12.16</br>
    /// </remarks>
	public class OperationLogWriter 
	{
		//================================================================================
		//  コンストラクター
		//================================================================================
		#region コンストラクター
		/// <summary>
		/// 操作履歴ログＩＯクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 操作履歴ログＩＯクラスの新しいインスタンスを作成します。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2006.12.18</br>
		/// </remarks>
		public OperationLogWriter()
		{
			
			// ログイン情報の取得
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

			if (LoginInfoAcquisition.Employee != null)
			{
				this._loginEmployee = LoginInfoAcquisition.Employee.Clone();

				this._logDataAgentCd = this._loginEmployee.EmployeeCode;
				this._logDataAgentNm = this._loginEmployee.Name;
				this._loginSectionCd = this._loginEmployee.BelongSectionCode;

                // ↓↓↓2008.12.16 T-Kidate ADD
                this._authorityLevel1 = this._loginEmployee.AuthorityLevel1;
                this._authorityLevel2 = this._loginEmployee.AuthorityLevel2;
			}

			// 端末名の取得
			this._logDataMachineName = Environment.MachineName;

			// コマンドライン引数の取得
			gcmd = Environment.GetCommandLineArgs();
			
			try
			{
				this._isOnline = true;

				if (this._iOprtnHisLogDB == null)
				{
					this._iOprtnHisLogDB = (IOprtnHisLogDB)MediationOprtnHisLogDB.GetOprtnHisLogDB();
				}
			}
			catch (Exception)
			{
				this._iOprtnHisLogDB = null;
				this._isOnline = false;
			}
		}
		#endregion

		//================================================================================
		//  内部使用フィールド
		//================================================================================
		#region Private Fields
		/// <summary>
		/// コマンドライン
		/// </summary>
		private string[] gcmd;

		/// <summary>
		/// 操作ログデータリスト
		/// </summary>
		List<OprtnHisLog> _liOprtnHisLog;

		/// <summary>
		/// 操作ログデータリストサイズ
		/// </summary>
		int _byteSize = 0;

		/// <summary>
		/// 企業コード
		/// </summary>
		string _enterpriseCode = "";

		/// <summary>
		/// 従業員データクラス
		/// </summary>
		Employee _loginEmployee;

		/// <summary>
		/// ログイン拠点コード
		/// </summary>
		string _loginSectionCd = "";

		/// <summary>
		/// ログデータ端末名
		/// </summary>
		string _logDataMachineName = "";

		/// <summary>
		/// ログデータ担当者コード
		/// </summary>
		string _logDataAgentCd = "";

		/// <summary>
		/// ログデータ担当者名
		/// </summary>
		string _logDataAgentNm = "";

		/// <summary>
		/// ログデータ起動プログラム名
		/// </summary>
		string _logDataObjBootProgramNm = "";

		/// <summary>
		/// ログデータ対象アセンブリＩＤ
		/// </summary>
		string _logDataObjAssemblyID = "";

		/// <summary>
		/// ログデータ対象アセンブリ名称
		/// </summary>
		string _logDataObjAssemblyNm = "";

		/// <summary>
		/// ログデータ対象クラスID
		/// </summary>
		string _logDataObjClassID = "";

		/// <summary>
		/// ログデータシステムバージョン
		/// </summary>
		Version _logDataSystemVersion;

		/// <summary>
		/// オンラインフラグ
		/// </summary>
		private bool _isOnline = true;

		/// <summary>
		/// 一定周期登録用タイマー
		/// </summary>
		private Timer _writeTimer;

        // ↓↓↓2008.12.19 T-Kidate ADD
        private OperationLogParts _operationLogParts = null;

        // ↓↓↓2008.12.16 T-Kidate ADD
        /// <summary>
        /// 権限レベル１
        /// </summary>
        private int _authorityLevel1 = 0;

        // ↓↓↓2008.12.16 T-Kidate ADD
        /// <summary>
        /// 権限レベル２
        /// </summary>
        private int _authorityLevel2 = 0;
		#endregion

		//================================================================================
		//  内部使用フィールド
		//================================================================================
		#region Private Import Method
		/// <summary>
		/// 指定されたウィンドウのタイトルバーのテキストをバッファへコピーします。指定されたウィンドウがコントロールの場合は、コントロールのテキストをコピーします。ただし、他のアプリケーションのコントロールのテキストを取得することはできません。
		/// </summary>
		/// <param name="hWnd">ウィンドウ（ またはテキストを持つコントロール）のハンドルを指定します。</param>
		/// <param name="lpString">バッファへのポインタを指定します。このバッファにテキストが格納されます。</param>
		/// <param name="nMaxCount">バッファにコピーする文字の最大数を指定します。テキストのこのサイズを超える部分は、切り捨てられます。NULL 文字も数に含められます。</param>
		/// <returns>関数が成功すると、コピーされた文字列の文字数が返ります（ 終端の NULL 文字は含められません）。タイトルバーやテキストがない場合、タイトルバーが空の場合、および hWnd パラメータに指定したウィンドウハンドルまたはコントロールハンドルが無効な場合は 0 が返ります。</returns>
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern int GetWindowText(IntPtr hWnd, [Out] System.Text.StringBuilder lpString, int nMaxCount);
		#endregion

		//================================================================================
		//  内部使用定数
		//================================================================================
		#region Private Constant
		/// <summary>
		/// 格納フォルダ
		/// </summary>
		private string CT_OperationLog_Path = "Log\\Operation";

		/// <summary>
		/// リモート通信間隔(秒)
		/// </summary>
#if DEBUG
		private int CT_RemotingInterval = 60;
#else
		private int CT_RemotingInterval = 1800;
#endif

		/// <summary>
		/// メモリ上に保存する最大サイズ(2Mbyte)
		/// </summary>
		private int CT_Max_OnMemoryByteSize = 2097152;
		#endregion

		//================================================================================
		//  内部使用メンバ(リモートオブジェクト)
		//================================================================================
		#region Private Members(リモートオブジェクト)
		/// <summary>
		///  操作履歴ログＩＯリモートオブジェクト
		/// </summary>
		private IOprtnHisLogDB _iOprtnHisLogDB;
		#endregion

		//================================================================================
		//  外部提供列挙型
		//================================================================================
		#region Public Enum

		/// <summary>
		/// オペレーション列挙型
		/// </summary>
		public enum emOperation : int
		{
			/// <summary>
			/// 起動
			/// </summary>
			OPE_START = 0,

			/// <summary>
			/// ログイン
			/// </summary>
			OPE_LOGIN = 1,
			
			/// <summary>
			/// データ読み込み
			/// </summary>
			OPE_GET = 2,
			
			/// <summary>
			/// データ挿入
			/// </summary>
			OPE_INSERT = 3,
			
			/// <summary>
			/// データ更新
			/// </summary>
			OPE_UPDATE = 4,
			
			/// <summary>
			/// データ論理削除
			/// </summary>
			OPE_LOGICALDELETE = 5,
			
			/// <summary>
			/// データ削除
			/// </summary>
			OPE_DELETE = 6,
			
			/// <summary>
			/// 印刷
			/// </summary>
			OPE_PRINT = 7,
			
			/// <summary>
			/// テキスト出力
			/// </summary>
			OPE_TEXT = 8,
			
			/// <summary>
			/// 通信
			/// </summary>
			OPE_COMMT = 9,
			
			/// <summary>
			/// 呼出
			/// </summary>
			OPE_CALL = 10,
			
			/// <summary>
			/// 送信
			/// </summary>
			OPE_SEND = 11,
			
			/// <summary>
			/// 受信
			/// </summary>
			OPE_RECIEVE = 12,
			
			/// <summary>
			/// タイムアウト
			/// </summary>
			OPE_TIMEOUT = 13,
			
			/// <summary>
			/// 終了
			/// </summary>
			OPE_EXIT = 14
		}

		#endregion

		//================================================================================
		//  外部提供関数
		//================================================================================
		#region Public Methods
		/// <summary>
		/// 操作履歴ログ開始
		/// </summary>
		/// <param name="sender">操作対象オブジェクト</param>
		/// <remarks>
		/// <br>Note       : 操作履歴ログのトレースを開始します。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2007.06.07</br>
		/// </remarks>
		public void StartOperationLog(object sender)
		{
			// アセンブリ情報を取得します
			this.GetAssemblyInfo(sender);

			StartOperationLog(sender, this._logDataObjAssemblyID, this._logDataObjAssemblyNm, this._logDataObjClassID);
		}

		/// <summary>
		/// 操作履歴ログ開始
		/// </summary>
		/// <param name="sender">操作対象オブジェクト</param>
		/// <param name="assemblyId">操作対象アセンブリID</param>
		/// <param name="assemblyNm">操作対象アセンブリ名</param>
		/// <param name="classID">操作対象クラスID</param>
		/// <remarks>
		/// <br>Note       : 操作履歴ログのトレースを開始します。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2006.12.18</br>
		/// </remarks>
		public void StartOperationLog(object sender, string assemblyId, string assemblyNm, string classID)
		{
			this._byteSize = 0;
			this._liOprtnHisLog = new List<OprtnHisLog>();

			try
			{
				// オフラインデータを検索して内部バッファに保存する
				this.SearchOffline();
				
				// 起動プログラム名の取得
				this._logDataObjBootProgramNm = System.Diagnostics.Process.GetCurrentProcess().MainWindowTitle;
				if (this._logDataObjBootProgramNm == "")
				{
					if ((System.Windows.Forms.Application.OpenForms.Count > 0) &&
						(!System.Windows.Forms.Application.OpenForms[0].InvokeRequired))
					{
						this._logDataObjBootProgramNm = System.Windows.Forms.Application.OpenForms[0].Text;
					}
					else
					{
						IntPtr hWnd = System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle;
						if (hWnd != IntPtr.Zero)
						{
							System.Text.StringBuilder sb = new System.Text.StringBuilder();
							if ((GetWindowText(hWnd, sb, 0x1000) > 0) && (sb.Length > 0))
							{
								this._logDataObjBootProgramNm = sb.ToString();
							}
						}
					}
				}
				if (this._logDataObjBootProgramNm.Length > 32)
					this._logDataObjBootProgramNm = this._logDataObjBootProgramNm.Substring(0, 32);

				// ログデータ対象アセンブリID
				this._logDataObjAssemblyID = assemblyId;

				if (this._logDataObjAssemblyID.Equals(string.Empty))
					this._logDataObjAssemblyID = "Application";

				if (this._logDataObjAssemblyID.Length > 30)
					this._logDataObjAssemblyID = this._logDataObjAssemblyID.Substring(0, 30);
  
				// ログデータ対象アセンブリ名称
				this._logDataObjAssemblyNm = assemblyNm;

				if (this._logDataObjAssemblyNm.Length > 40)
					this._logDataObjAssemblyNm = this._logDataObjAssemblyNm.Substring(0, 40);

				// ログデータ対象クラスID
				this._logDataObjClassID = classID;

				if (this._logDataObjClassID.Length > 32)
					this._logDataObjClassID = this._logDataObjClassID.Substring(0, 32);

				
				// 操作履歴ログ出力
				this.WriteOperationLog(sender, 0, "", emOperation.OPE_START, 0, "プログラムを開始します。", "");

				// 一定間隔ごとに呼び出すメソッドをTimerCallbackとして登録 
				TimerCallback timerCallback = new TimerCallback(this.CallBackWrite);

				// 一定周期書込み用のタイマーを起動します。
				this._writeTimer = new Timer(timerCallback);

				// タイマー設定
				this.SetTimer(this._writeTimer);

                // ↓↓↓2008.12.19 T-Kidate ADD
                this._operationLogParts = new OperationLogParts();

#if DEBUG
				this.DebugLogWrite(0, "StartOperationLog");
#endif
			}
			catch (Exception)
			{
				
			}
			
		}

		/// <summary>
		/// 操作履歴ログ出力
		/// </summary>
		/// <param name="sender">操作対象オブジェクト</param>
		/// <param name="logDataKindCd">ログデータ種別区分コード[0:記録,1:エラー,9:システム]</param>
		/// <param name="procNm">処理名</param>
		/// <param name="operation">OperationLogWriter.OPEXXX</param>
		/// <param name="status">ログステータス</param>
		/// <param name="msg">ログメッセージ</param>
		/// <param name="keyData">ログオペレーションデータ</param>
		/// <remarks>
		/// <br>Note       : 操作履歴ログを出力します。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2006.12.18</br>
		/// </remarks>
		public void WriteOperationLog(object sender, int logDataKindCd, string procNm, emOperation operation, int status, string msg, string keyData)
		{
			OprtnHisLog oprtnHisLog = new OprtnHisLog();

			// 企業コード
			oprtnHisLog.EnterpriseCode = this._enterpriseCode;
			// ログデータ作成日時
			oprtnHisLog.LogDataCreateDtTm = TDateTime.GetSFDateNow();
			// ログデータGUID
			oprtnHisLog.LogDataGuid = Guid.NewGuid();
			// ログイン拠点コード
			oprtnHisLog.LoginSectionCd = this._loginSectionCd;
			// ログデータ種別区分コード
			oprtnHisLog.LogDataKindCd = logDataKindCd;
			// ログデータ端末名
			oprtnHisLog.LogDataMachineName = this._logDataMachineName;
			// ログデータ担当者コード
			oprtnHisLog.LogDataAgentCd = this._logDataAgentCd;
			// ログデータ担当者名
			oprtnHisLog.LogDataAgentNm = this._logDataAgentNm;
			// ログデータ対象起動プログラム名称
			oprtnHisLog.LogDataObjBootPgName = this._logDataObjBootProgramNm;
			// ログデータ対象アセンブリID
			oprtnHisLog.LogDataObjAssemblyID = this._logDataObjAssemblyID;
			// ログデータ対象アセンブリ名称
			oprtnHisLog.LogDataObjAssemblyNm = this._logDataObjAssemblyNm;
			// ログデータ対象クラスID
			oprtnHisLog.LogDataObjClassID = this._logDataObjClassID;
			// ログデータ対象処理名
			oprtnHisLog.LogDataObjProcNm = procNm;
			if (oprtnHisLog.LogDataObjProcNm.Length > 40)
				oprtnHisLog.LogDataObjProcNm = oprtnHisLog.LogDataObjProcNm.Substring(0, 40);
			
			// ログデータオペレーション
			oprtnHisLog.LogDataOperationCd = (int)operation;

			//// ログデータオペレーターデータ処理レベル
			//oprtnHisLog.LogOperaterDtProcLvl = this._logOperaterDtProcLvl;
            //// ログデータオペレーター機能処理レベル
            //oprtnHisLog.LogOperaterFuncLvl = this._logOperaterFuncLvl;
			
			// ログデータシステムバージョン
			if (this._logDataSystemVersion != null)
				oprtnHisLog.LogDataSystemVersion = this._logDataSystemVersion.ToString();
			
            // ログオペレーションステータス
			oprtnHisLog.LogOperationStatus = status;
			
			// ログデータメッセージ内容
			oprtnHisLog.LogOprtnDataSummary = msg;
			if (oprtnHisLog.LogOprtnDataSummary.Length > 80)
				oprtnHisLog.LogOprtnDataSummary = oprtnHisLog.LogOprtnDataSummary.Substring(0, 80);

			// ログオペレーションデータ
			oprtnHisLog.LogOperationData = keyData;
			if (oprtnHisLog.LogOperationData.Length > 80)
				oprtnHisLog.LogOperationData = oprtnHisLog.LogOperationData.Substring(0, 80);

			if (this._liOprtnHisLog == null)
				this._liOprtnHisLog = new List<OprtnHisLog>();

            // ↓↓↓2008.12.16 T-Kidate ADD
            // 権限レベル１
            oprtnHisLog.AuthorityLevel1 = this._authorityLevel1;
            // ↓↓↓2008.12.16 T-Kidate ADD
            // 権限レベル２
            oprtnHisLog.AuthorityLevel2 = this._authorityLevel2;

			// 操作ログデータリストに追加
			this._liOprtnHisLog.Add(oprtnHisLog);

			// サイズ設定
			this._byteSize += oprtnHisLog.GetSize();

			// ２Mを超えたらWriteする
			if (this._byteSize >= CT_Max_OnMemoryByteSize)
			{
				this.Write();
#if DEBUG
				this.DebugLogWrite(0, "Memory Over Write");
#endif
			}

		}

        /// <summary>
        /// 新規登録時 操作履歴ログ出力
        /// </summary>
        /// <param name="sender">呼出元オブジェクト</param>
        /// <param name="employee">従業員データクラス</param>
        /// <param name="classId">クラス名</param>
        /// <param name="status">処理ステータス</param>
        /// <param name="targetDataClass">登録データクラス</param>
        public void WriteInsertLogProc(object sender, Employee employee, string classId, int status, object targetDataClass)
        {
            // 操作履歴ログ部品インスタンス化
            if (this._operationLogParts == null) this._operationLogParts = new OperationLogParts();

            // 従業員クラス変換処理
            EmployeeWork employeeWork = this.CopyToEmploeeWorkFromEmployee(employee);

            // 操作履歴ログデータ生成
            OprtnHisLogWork oprtnHisLogWork = this._operationLogParts.CreateOperationLogWork(sender, 
                                                                                       employeeWork,
                                                                                       OperationLogParts.emOperation.OPE_INSERT, 
                                                                                       classId, 
                                                                                       status,    
                                                                                       targetDataClass);
            // 操作履歴ログデータ登録対象リストへ格納
            this._liOprtnHisLog.Add(this.CopyToOprtnHisLogFromOprtnHisLogWork(oprtnHisLogWork));
        }

        /// <summary>
        /// 更新時 操作履歴ログ出力
        /// </summary>
        /// <param name="sender">呼出元オブジェクト</param>
        /// <param name="employee">従業員データクラス</param>
        /// <param name="classId">クラス名</param>
        /// <param name="status">処理ステータス</param>
        /// <param name="targetDataClass">登録データクラス</param>
        public void WriteUpdateLogProc(object sender, Employee employee, string classId, int status, object targetDataClass)
        {
            // 操作履歴ログ部品インスタンス化
            if (this._operationLogParts == null) this._operationLogParts = new OperationLogParts();

            // 従業員クラス変換処理
            EmployeeWork employeeWork = this.CopyToEmploeeWorkFromEmployee(employee);

            // 操作履歴ログデータ生成
            OprtnHisLogWork oprtnHisLogWork = this._operationLogParts.CreateOperationLogWork(sender,
                                                                                       employeeWork,
                                                                                       OperationLogParts.emOperation.OPE_UPDATE,
                                                                                       classId,
                                                                                       status,
                                                                                       targetDataClass);
            // 操作履歴ログデータ登録対象リストへ格納
            this._liOprtnHisLog.Add(this.CopyToOprtnHisLogFromOprtnHisLogWork(oprtnHisLogWork));
        }

        /// <summary>
        /// 論理削除時 操作履歴ログ出力
        /// </summary>
        /// <param name="sender">呼出元オブジェクト</param>
        /// <param name="employee">従業員データクラス</param>
        /// <param name="classId">クラス名</param>
        /// <param name="status">処理ステータス</param>
        /// <param name="targetDataClass">登録データクラス</param>
        public void WriteLogicalDeleteLogProc(object sender, Employee employee, string classId, int status, object targetDataClass)
        {
            // 操作履歴ログ部品インスタンス化
            if (this._operationLogParts == null) this._operationLogParts = new OperationLogParts();

            // 従業員クラス変換処理
            EmployeeWork employeeWork = this.CopyToEmploeeWorkFromEmployee(employee);

            // 操作履歴ログデータ生成
            OprtnHisLogWork oprtnHisLogWork = this._operationLogParts.CreateOperationLogWork(sender,
                                                                                       employeeWork,
                                                                                       OperationLogParts.emOperation.OPE_LOGICALDELETE,
                                                                                       classId,
                                                                                       status,
                                                                                       targetDataClass);
            // 操作履歴ログデータ登録対象リストへ格納
            this._liOprtnHisLog.Add(this.CopyToOprtnHisLogFromOprtnHisLogWork(oprtnHisLogWork));
        }

        /// <summary>
        /// 削除時 操作履歴ログ出力
        /// </summary>
        /// <param name="sender">呼出元オブジェクト</param>
        /// <param name="employee">従業員データクラス</param>
        /// <param name="classId">クラス名</param>
        /// <param name="status">処理ステータス</param>
        /// <param name="targetDataClass">登録データクラス</param>
        public void WriteDeleteLogProc(object sender, Employee employee, string classId, int status, object targetDataClass)
        {
            // 操作履歴ログ部品インスタンス化
            if (this._operationLogParts == null) this._operationLogParts = new OperationLogParts();

            // 従業員クラス変換処理
            EmployeeWork employeeWork = this.CopyToEmploeeWorkFromEmployee(employee);

            // 操作履歴ログデータ生成
            OprtnHisLogWork oprtnHisLogWork = this._operationLogParts.CreateOperationLogWork(sender,
                                                                                       employeeWork,
                                                                                       OperationLogParts.emOperation.OPE_DELETE,
                                                                                       classId,
                                                                                       status,
                                                                                       targetDataClass);
            // 操作履歴ログデータ登録対象リストへ格納
            this._liOprtnHisLog.Add(this.CopyToOprtnHisLogFromOprtnHisLogWork(oprtnHisLogWork));
        }

        /// <summary>
        /// 復活時 操作履歴ログ出力
        /// </summary>
        /// <param name="sender">呼出元オブジェクト</param>
        /// <param name="employee">従業員データクラス</param>
        /// <param name="classId">クラス名</param>
        /// <param name="status">処理ステータス</param>
        /// <param name="targetDataClass">登録データクラス</param>
        public void WriteRevivalLogProc(object sender, Employee employee, string classId, int status, object targetDataClass)
        {
            // 今のところ新規登録時と同じ
            this.WriteInsertLogProc(sender, employee, classId, status, targetDataClass);
        }

		/// <summary>
		/// 操作履歴ログ終了
		/// </summary>
		/// <remarks>
		/// <br>Note       : 操作履歴ログのトレースを終了します。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2006.12.18</br>
		/// </remarks>
		public void ExitOperationLog(object sender)
		{
			try
			{
				// 操作履歴ログ出力
				this.WriteOperationLog(sender, 0, "", emOperation.OPE_EXIT, 0, "プログラムを終了します。", "");

				// 操作履歴ログ登録
				this.Write();
			}
			catch (Exception)
			{
			}
			finally
			{
				if (this._writeTimer != null)
					this._writeTimer.Dispose();
			}
		}

		/// <summary>
		/// 操作履歴ログ検索
		/// </summary>
		/// <param name="retList">>検索結果格納リスト</param>
		/// <param name="enterpriseCode">企業コード</param>
		/// <returns>ConstantManagement.DB_Status</returns>
		/// <remarks>
		/// <br>Note       : 操作履歴ログの検索を行います。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2006.12.18</br>
		/// </remarks>
		public int Search(out ArrayList retList, string enterpriseCode)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			retList = new ArrayList();

			try
			{
				object retobj = null;

				OprtnHisLogWork paraoprtnHisLogWork = new OprtnHisLogWork();
				paraoprtnHisLogWork.EnterpriseCode = enterpriseCode; 
				
				// リモーティングより取得
				status = this._iOprtnHisLogDB.Search(out retobj, paraoprtnHisLogWork, 0, ConstantManagement.LogicalMode.GetDataAll);

				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
						{
							ArrayList wkList = retobj as ArrayList;

							if (wkList != null && wkList.Count > 0)
							{
								retList = CopyToOprtnHisLogFromOprtnHisLogWork(wkList);

								status = (retList.Count != 0) ? (int)ConstantManagement.DB_Status.ctDB_NORMAL : (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
							}
							else
							{
								status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND; 
							}
							
							break;
						}
					default:
						break;
				}
			}
			catch (Exception)
			{
			}

			return status;
		}

		#endregion

		//================================================================================
		//  内部使用関数
		//================================================================================
		#region Private Methods

		/// <summary>
		/// タイマーの時間間隔設定
		/// </summary>
		/// <param name="target"></param>
		private void SetTimer(Timer target)
		{
			// 30分間隔で設定
			target.Change(TimeSpan.FromSeconds(CT_RemotingInterval), TimeSpan.FromSeconds(CT_RemotingInterval));
		}


		/// <summary>
		/// タイマーコールバック用操作履歴ログ登録
		/// </summary>
		/// <remarks>
		/// <br>Note       : 操作履歴ログの登録を行います。オフライン時はクライアントにローカル保存します。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2006.12.18</br>
		/// </remarks>
		private void CallBackWrite(object state)
		{
#if DEBUG
			this.DebugLogWrite(1, "CallBackWrite");
#endif

			
			this._writeTimer.Change(Timeout.Infinite, Timeout.Infinite);
			this.Write();
			this.SetTimer(this._writeTimer);
		}
		

		/// <summary>
		/// 操作履歴ログ登録
		/// </summary>
		/// <remarks>
		/// <br>Note       : 操作履歴ログの登録を行います。オフライン時はクライアントにローカル保存します。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2006.12.18</br>
		/// </remarks>
		private int Write()
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			
			// 操作履歴ログがないときは未処理
			if (this._liOprtnHisLog == null || this._liOprtnHisLog.Count == 0)
			{
				return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}

			ArrayList workList = CopyToOprtnHisLogWorkFromOprtnHisLog(this._liOprtnHisLog);
			object workobj = workList;

			try
			{
				if (LoginInfoAcquisition.OnlineFlag && this._isOnline)
				{
					// オンライン
					status = this._iOprtnHisLogDB.Write(ref workobj);
					switch (status)
					{
						case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
#if DEBUG
							this.DebugLogWrite(1, "Write");
#endif
							break;
						default:
							// エラーが発生した場合はオフライン保存を行う
							status = this.WriteOffline(workobj);
#if DEBUG
							this.DebugLogWrite(1, "WriteOffline");
#endif
							break;
					}
				}
				else
				{
					// オフライン
					status = this.WriteOffline(workobj);
				}
			}
			catch (Exception)
			{
				// エラーが発生した場合はオフライン保存を行う
				status = this.WriteOffline(workobj);

#if DEBUG
				this.DebugLogWrite(1, "WriteOffline");
#endif
			}
			finally
			{
				this._byteSize = 0;

				if (this._liOprtnHisLog != null)
				{
					lock (this._liOprtnHisLog)
					{
						this._liOprtnHisLog.Clear();
					}
				}
			}

			return status;
		}

		/// <summary>
		/// オフラインデータ検索処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : オフラインデータを検索します。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2006.12.18</br>
		/// </remarks>
		private void SearchOffline()
		{
			try
			{
				// ファイル一覧の取得
				string path = Path.Combine(Path.GetDirectoryName(this.gcmd[0]),CT_OperationLog_Path);
				string[] files = Directory.GetFiles(path, "*.log");

				if (files != null && files.Length > 0)
				{
					foreach (string file in files)
					{
						// デシリアライズ
						OprtnHisLogWork[] oprtnHisLogWorks = UserSettingController.DeserializeUserSetting<OprtnHisLogWork[]>(file);

						if (oprtnHisLogWorks != null)
						{
							foreach (OprtnHisLogWork work in oprtnHisLogWorks)
							{
								if (this._liOprtnHisLog == null)
									this._liOprtnHisLog = new List<OprtnHisLog>();

								this._liOprtnHisLog.Add(CopyToOprtnHisLogFromOprtnHisLogWork(work));
							}
							// 読込んだファイルは削除する
							File.Delete(file);
						}
					}
				}
			}
			catch (Exception)
			{
			}
		}

		/// <summary>
		/// 操作履歴ログオフラインデータ登録
		/// </summary>
		/// <param name="workobj">>対象オブジェクト</param>
		/// <remarks>
		/// <br>Note       : オフラインデータを登録します。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2006.12.18</br>
		/// </remarks>
		private int WriteOffline(object workobj)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

			try
			{
				if (workobj == null) return (int)ConstantManagement.DB_Status.ctDB_NORMAL;

				ArrayList workList = workobj as ArrayList;
				if (workList != null)
				{
					OprtnHisLogWork[] oprtnHisLogWorkArray = workList.ToArray(typeof(OprtnHisLogWork)) as OprtnHisLogWork[]; 

					string filePath = Path.Combine(Directory.GetCurrentDirectory(), CT_OperationLog_Path);
					string fileName = String.Format("Client{0}{1}.log",DateTime.Now.Ticks,Guid.NewGuid());

					// シリアライズ
					UserSettingController.SerializeUserSetting(oprtnHisLogWorkArray,
						Path.Combine(filePath, fileName));

					status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
				}
			}
			catch (Exception)
			{
			}

			return status;
		}
		
		/// <summary>
		/// アセンブリ情報取得
		/// </summary>
		/// <param name="targetObj">対象オブジェクト</param>
		/// <remarks>
		/// <br>Note       : アセンブリ情報を取得します。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2006.12.18</br>
		/// </remarks>
		private void GetAssemblyInfo(object targetObj)
		{
			try
			{
				if (targetObj != null)
				{
					Type type = targetObj.GetType();
					AssemblyName name = type.Assembly.GetName();

					if (name != null)
					{
						this._logDataObjAssemblyID = name.Name;
						this._logDataObjAssemblyNm = name.Name;
						this._logDataSystemVersion = name.Version;
					}

					if (type != null)
						this._logDataObjClassID = type.Name;
				}
			}
			catch (Exception)
			{
			}
		}

		/// <summary>
		/// クラスメンバーコピー処理（操作履歴ログデータリスト ⇒ 操作履歴ログデータワークリスト(ArrayList)）
		/// </summary>
		/// <param name="oprtnHisLogLst">操作履歴ログデータリスト</param>
		/// <returns>変換された操作履歴ログデータワークリスト</returns>
		/// <remarks>
		/// <br>Note       : クラスのメンバーコピーを行います。（操作履歴ログデータリスト ⇒ 操作履歴ログデータワークリスト(ArrayList)</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2006.12.18</br>
		/// </remarks>
		private ArrayList CopyToOprtnHisLogWorkFromOprtnHisLog(List<OprtnHisLog> oprtnHisLogLst)
		{
			ArrayList oprtnHisLogWorkList = null;

			if (oprtnHisLogLst != null)
			{
				oprtnHisLogWorkList = new ArrayList();

				foreach (OprtnHisLog oprtnHisLog in oprtnHisLogLst)
				{
					oprtnHisLogWorkList.Add(CopyToOprtnHisLogWorkFromOprtnHisLog(oprtnHisLog));
				}
			}

			return oprtnHisLogWorkList;
		}
		
		/// <summary>
		/// クラスメンバーコピー処理（操作履歴ログデータクラス ⇒ 操作履歴ログデータワーククラス）
		/// </summary>
		/// <param name="oprtnHisLog">操作履歴ログデータ</param>
		/// <returns>操作履歴ログデータワーク</returns>
		/// <remarks>
		/// <br>Note       : クラスのメンバーコピーを行います。（操作履歴ログデータクラス ⇒ 操作履歴ログデータワーククラス）</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2006.12.18</br>
		/// </remarks>
		private OprtnHisLogWork CopyToOprtnHisLogWorkFromOprtnHisLog(OprtnHisLog oprtnHisLog)
		{
			OprtnHisLogWork oprtnHisLogWork = null;

			if (oprtnHisLog != null)
			{
				oprtnHisLogWork = new OprtnHisLogWork();

				// 作成日時
				oprtnHisLogWork.CreateDateTime = oprtnHisLog.CreateDateTime;
				// 更新日時
				oprtnHisLogWork.UpdateDateTime = oprtnHisLog.UpdateDateTime;
				// 企業コード
				oprtnHisLogWork.EnterpriseCode = oprtnHisLog.EnterpriseCode;
				// GUID
				oprtnHisLogWork.FileHeaderGuid = oprtnHisLog.FileHeaderGuid;
				// 更新従業員コード
				oprtnHisLogWork.UpdEmployeeCode = oprtnHisLog.UpdEmployeeCode;
				// 更新アセンブリID1
				oprtnHisLogWork.UpdAssemblyId1 = oprtnHisLog.UpdAssemblyId1;
				// 更新アセンブリID2
				oprtnHisLogWork.UpdAssemblyId2 = oprtnHisLog.UpdAssemblyId2;
				// 論理削除区分
				oprtnHisLogWork.LogicalDeleteCode = oprtnHisLog.LogicalDeleteCode;
				// ログデータ作成日時
				oprtnHisLogWork.LogDataCreateDtTm = oprtnHisLog.LogDataCreateDtTm;
				// ログデータGUID
				oprtnHisLogWork.LogDataGuid = oprtnHisLog.LogDataGuid;
				// ログイン拠点コード
				oprtnHisLogWork.LoginSectionCd = oprtnHisLog.LoginSectionCd;
				// ログデータ種別区分コード
				oprtnHisLogWork.LogDataKindCd = oprtnHisLog.LogDataKindCd;
				
				// ログデータ端末名
				oprtnHisLogWork.LogDataMachineName = oprtnHisLog.LogDataMachineName;
				if (oprtnHisLogWork.LogDataMachineName.Length > 80)
					oprtnHisLogWork.LogDataMachineName = oprtnHisLogWork.LogDataMachineName.Substring(0, 80);

				// ログデータ担当者コード
				oprtnHisLogWork.LogDataAgentCd = oprtnHisLog.LogDataAgentCd;
				if (oprtnHisLogWork.LogDataAgentCd.Length > 9)
					oprtnHisLogWork.LogDataAgentCd = oprtnHisLogWork.LogDataAgentCd.Substring(0, 9);

				// ログデータ担当者名
				oprtnHisLogWork.LogDataAgentNm = oprtnHisLog.LogDataAgentNm;
				if (oprtnHisLogWork.LogDataAgentNm.Length > 30)
					oprtnHisLogWork.LogDataAgentNm = oprtnHisLogWork.LogDataAgentNm.Substring(0, 30);

				// ログデータ対象起動プログラム名称
				oprtnHisLogWork.LogDataObjBootPgName = oprtnHisLog.LogDataObjBootPgName;
				// ログデータ対象アセンブリID
				oprtnHisLogWork.LogDataObjAssemblyID = oprtnHisLog.LogDataObjAssemblyID;
				// ログデータ対象アセンブリ名称
				oprtnHisLogWork.LogDataObjAssemblyNm = oprtnHisLog.LogDataObjAssemblyNm;
				// ログデータ対象クラスID
				oprtnHisLogWork.LogDataObjClassID = oprtnHisLog.LogDataObjClassID;
				
				// ログデータ対象処理名
				oprtnHisLogWork.LogDataObjProcNm = oprtnHisLog.LogDataObjProcNm;
				if (oprtnHisLogWork.LogDataObjProcNm.Length > 40)
					oprtnHisLogWork.LogDataObjProcNm = oprtnHisLogWork.LogDataObjProcNm.Substring(0, 40);
				
				// ログデータオペレーションコード
				oprtnHisLogWork.LogDataOperationCd = oprtnHisLog.LogDataOperationCd;
				
				// ログデータオペレーターデータ処理レベル
				oprtnHisLogWork.LogOperaterDtProcLvl = oprtnHisLog.LogOperaterDtProcLvl;
				if (oprtnHisLogWork.LogOperaterDtProcLvl.Length > 4)
					oprtnHisLogWork.LogOperaterDtProcLvl = oprtnHisLogWork.LogOperaterDtProcLvl.Substring(0, 4);

				// ログデータオペレーター機能処理レベル
				oprtnHisLogWork.LogOperaterFuncLvl = oprtnHisLog.LogOperaterFuncLvl;
				if (oprtnHisLogWork.LogOperaterFuncLvl.Length > 4)
					oprtnHisLogWork.LogOperaterFuncLvl = oprtnHisLogWork.LogOperaterFuncLvl.Substring(0, 4);
				
				// ログデータシステムバージョン
				oprtnHisLogWork.LogDataSystemVersion = oprtnHisLog.LogDataSystemVersion;
				if (oprtnHisLogWork.LogDataSystemVersion.Length > 12)
					oprtnHisLogWork.LogDataSystemVersion = oprtnHisLogWork.LogDataSystemVersion.Substring(0, 12);

				// ログオペレーションステータス
                oprtnHisLogWork.LogOperationStatus = oprtnHisLog.LogOperationStatus;

				// ログデータメッセージ内容
				oprtnHisLogWork.LogOprtnDataSummary = oprtnHisLog.LogOprtnDataSummary;
				if (oprtnHisLogWork.LogOprtnDataSummary.Length > 80)
					oprtnHisLogWork.LogOprtnDataSummary = oprtnHisLogWork.LogOprtnDataSummary.Substring(0, 80);
				
				// ログオペレーションデータ
				oprtnHisLogWork.LogOperationData = oprtnHisLog.LogOperationData;
				if (oprtnHisLogWork.LogOperationData.Length > 80)
					oprtnHisLogWork.LogOperationData = oprtnHisLogWork.LogOperationData.Substring(0, 80);

                // ↓↓↓2008.12.16 T-Kidate ADD
                // 権限レベル１
                oprtnHisLogWork.AuthorityLevel1 = oprtnHisLog.AuthorityLevel1;
                // 権限レベル２
                oprtnHisLogWork.AuthorityLevel2 = oprtnHisLog.AuthorityLevel2;
			}

			return oprtnHisLogWork;
		}


		/// <summary>
		/// クラスメンバーコピー処理（ご提案シート明細ワークリスト⇒ご提案シート明細リスト(ArrayList)）
		/// </summary>
		/// <param name="prpShtDtlDWorkList">ご提案シート明細ワークリスト</param>
		/// <returns>変換されたご提案シート明細リスト</returns>
		/// <remarks>
		/// <br>Note       : クラスのメンバーコピーを行います。（ご提案シート明細ワークリスト⇒ご提案シート明細リスト(ArrayList)）</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2006.12.18</br>
		/// </remarks>
		private ArrayList CopyToOprtnHisLogFromOprtnHisLogWork(ArrayList oprtnHisLogWorkList)
		{
			// ご提案シート明細リスト
			ArrayList oprtnHisLogList = null;

			if (oprtnHisLogWorkList != null)
			{
				oprtnHisLogList = new ArrayList();

				foreach (OprtnHisLogWork oprtnHisLogWork in oprtnHisLogWorkList)
				{
					oprtnHisLogList.Add(CopyToOprtnHisLogFromOprtnHisLogWork(oprtnHisLogWork));
				}
			}

			return oprtnHisLogList;
		}
		
		
		/// <summary>
		/// クラスメンバーコピー処理（操作履歴ログデータワーククラス ⇒ 操作履歴ログデータクラス）
		/// </summary>
		/// <param name="oprtnHisLog">操作履歴ログデータワーク</param>
		/// <returns>操作履歴ログデータ</returns>
		/// <remarks>
		/// <br>Note       : クラスのメンバーコピーを行います。（操作履歴ログデータワーククラス ⇒ 操作履歴ログデータクラス）</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2006.12.18</br>
		/// </remarks>
		private OprtnHisLog CopyToOprtnHisLogFromOprtnHisLogWork(OprtnHisLogWork oprtnHisLogWork)
		{
			OprtnHisLog oprtnHisLog = null;

			if (oprtnHisLogWork != null)
			{
				oprtnHisLog = new OprtnHisLog();

				// 作成日時
				oprtnHisLog.CreateDateTime = oprtnHisLogWork.CreateDateTime;
				// 更新日時
				oprtnHisLog.UpdateDateTime = oprtnHisLogWork.UpdateDateTime;
				// 企業コード
				oprtnHisLog.EnterpriseCode = oprtnHisLogWork.EnterpriseCode;
				// GUID
				oprtnHisLog.FileHeaderGuid = oprtnHisLogWork.FileHeaderGuid;
				// 更新従業員コード
				oprtnHisLog.UpdEmployeeCode = oprtnHisLogWork.UpdEmployeeCode;
				// 更新アセンブリID1
				oprtnHisLog.UpdAssemblyId1 = oprtnHisLogWork.UpdAssemblyId1;
				// 更新アセンブリID2
				oprtnHisLog.UpdAssemblyId2 = oprtnHisLogWork.UpdAssemblyId2;
				// 論理削除区分
				oprtnHisLog.LogicalDeleteCode = oprtnHisLogWork.LogicalDeleteCode;
				// ログデータ作成日時
				oprtnHisLog.LogDataCreateDtTm = oprtnHisLogWork.LogDataCreateDtTm;
				// ログデータGUID
				oprtnHisLog.LogDataGuid = oprtnHisLogWork.LogDataGuid;
				// ログイン拠点コード
				oprtnHisLog.LoginSectionCd = oprtnHisLogWork.LoginSectionCd;
				// ログデータ種別区分コード
				oprtnHisLog.LogDataKindCd = oprtnHisLogWork.LogDataKindCd;
				// ログデータ端末名
				oprtnHisLog.LogDataMachineName = oprtnHisLogWork.LogDataMachineName;
				// ログデータ担当者コード
				oprtnHisLog.LogDataAgentCd = oprtnHisLogWork.LogDataAgentCd;
				// ログデータ担当者名
				oprtnHisLog.LogDataAgentNm = oprtnHisLogWork.LogDataAgentNm;
				// ログデータ対象起動プログラム名称
				oprtnHisLog.LogDataObjBootPgName = oprtnHisLogWork.LogDataObjBootPgName;
				// ログデータ対象アセンブリID
				oprtnHisLog.LogDataObjAssemblyID = oprtnHisLogWork.LogDataObjAssemblyID;
				// ログデータ対象アセンブリ名称
				oprtnHisLog.LogDataObjAssemblyNm = oprtnHisLogWork.LogDataObjAssemblyNm;
				// ログデータ対象クラスID
				oprtnHisLog.LogDataObjClassID = oprtnHisLogWork.LogDataObjClassID;
				// ログデータ対象処理名
				oprtnHisLog.LogDataObjProcNm = oprtnHisLogWork.LogDataObjProcNm;
				// ログデータオペレーションコード
				oprtnHisLog.LogDataOperationCd = oprtnHisLogWork.LogDataOperationCd;
				// ログデータオペレーターデータ処理レベル
				oprtnHisLog.LogOperaterDtProcLvl = oprtnHisLogWork.LogOperaterDtProcLvl;
				// ログデータオペレーター機能処理レベル
				oprtnHisLog.LogOperaterFuncLvl = oprtnHisLogWork.LogOperaterFuncLvl;
				// ログデータシステムバージョン
				oprtnHisLog.LogDataSystemVersion = oprtnHisLogWork.LogDataSystemVersion;
				// ログオペレーションステータス
                oprtnHisLog.LogOperationStatus = oprtnHisLogWork.LogOperationStatus;
				// ログデータメッセージ内容
				oprtnHisLog.LogOprtnDataSummary = oprtnHisLogWork.LogOprtnDataSummary;
				// ログオペレーションデータ
				oprtnHisLog.LogOperationData = oprtnHisLogWork.LogOperationData;
                // ↓↓↓2008.12.16 T-Kidate ADD
                // 権限レベル１
                oprtnHisLog.AuthorityLevel1 = oprtnHisLogWork.AuthorityLevel1;
                // 権限レベル２
                oprtnHisLog.AuthorityLevel2 = oprtnHisLogWork.AuthorityLevel2;
			}

			return oprtnHisLog;
		}

        /// <summary>
        /// 従業員データクラス→従業員ワークデータクラス
        /// </summary>
        /// <param name="employee">従業員データクラス</param>
        /// <returns>従業員ワークデータクラス</returns>
        private EmployeeWork CopyToEmploeeWorkFromEmployee(Employee employee)
        {
            EmployeeWork employeeWork = new EmployeeWork();

            employeeWork.CreateDateTime = employee.CreateDateTime;
            employeeWork.UpdateDateTime = employee.UpdateDateTime;
            employeeWork.EnterpriseCode = employee.EnterpriseCode;
            employeeWork.FileHeaderGuid = employee.FileHeaderGuid;
            employeeWork.UpdEmployeeCode = employee.UpdEmployeeCode;
            employeeWork.UpdAssemblyId1 = employee.UpdAssemblyId1;
            employeeWork.UpdAssemblyId2 = employee.UpdAssemblyId2;
            employeeWork.LogicalDeleteCode = employee.LogicalDeleteCode;
            employeeWork.EmployeeCode = employee.EmployeeCode;
            employeeWork.Name = employee.Name;
            employeeWork.Kana = employee.Kana;
            employeeWork.ShortName = employee.ShortName;
            employeeWork.SexCode = employee.SexCode;
            employeeWork.SexName = employee.SexName;
            employeeWork.Birthday = employee.Birthday;
            employeeWork.CompanyTelNo = employee.CompanyTelNo;
            employeeWork.PortableTelNo = employee.PortableTelNo;
            employeeWork.PostCode = employee.PostCode;
            employeeWork.BusinessCode = employee.BusinessCode;
            employeeWork.FrontMechaCode = employee.FrontMechaCode;
            employeeWork.InOutsideCompanyCode = employee.InOutsideCompanyCode;
            employeeWork.BelongSectionCode = employee.BelongSectionCode;
            employeeWork.LvrRtCstGeneral = employee.LvrRtCstGeneral;
            employeeWork.LvrRtCstCarInspect = employee.LvrRtCstCarInspect;
            employeeWork.LvrRtCstBodyPaint = employee.LvrRtCstBodyPaint;
            employeeWork.LvrRtCstBodyRepair = employee.LvrRtCstBodyRepair;
            employeeWork.LoginId = employee.LoginId;
            employeeWork.LoginPassword = employee.LoginPassword;
            employeeWork.UserAdminFlag = employee.UserAdminFlag;
            employeeWork.EnterCompanyDate = employee.EnterCompanyDate;
            employeeWork.RetirementDate = employee.RetirementDate;
            employeeWork.AuthorityLevel1 = employee.AuthorityLevel1;
            employeeWork.AuthorityLevel2 = employee.AuthorityLevel2;

            return employeeWork;
        }
		#endregion

#if DEBUG
		private DateTime _dtime_s, _dtime_e;
		private System.IO.FileStream	_fs = null;
		private System.IO.StreamWriter	_sw = null;
		
		private void DebugLogWrite(int mode, string msg)
		{
			this._fs = new System.IO.FileStream("MACMN00110C_Log.txt", System.IO.FileMode.Append, System.IO.FileAccess.Write, System.IO.FileShare.Write);
			this._sw = new System.IO.StreamWriter(this._fs,System.Text.Encoding.GetEncoding("shift_jis"));
			if (mode == 0)
			{

				this._dtime_s = DateTime.Now;
				TimeSpan ts = this._dtime_s.Subtract(this._dtime_s);
				string s = String.Format("{0,-20} {1,-5} ==> {2,-20} [0] {3} \n", 
					this._dtime_s, this._dtime_s.Millisecond, ts.ToString(), msg);
				this._sw.WriteLine( s );
//				System.Diagnostics.Debug.WriteLine( s );
			}
			else if (mode == 1)
			{
				this._dtime_e = DateTime.Now;
				TimeSpan ts = this._dtime_e.Subtract(this._dtime_s);
				string s = string.Format("{0,-20} {1,-5} ==> {2,-20} [1] {3} \n", 
					this._dtime_e, this._dtime_e.Millisecond, ts.ToString(), msg);
				
				this._sw.WriteLine( s );
//				System.Diagnostics.Debug.WriteLine( s );

				this._dtime_s = this._dtime_e;
			}
			else if (mode == 9)
			{
			}
			this._sw.Close();
			this._fs.Close();
		}
#endif


	}
}

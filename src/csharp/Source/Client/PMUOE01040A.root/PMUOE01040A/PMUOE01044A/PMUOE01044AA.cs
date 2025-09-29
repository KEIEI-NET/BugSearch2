//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 操作履歴ログデータアクセスクラス
// プログラム概要   : 操作履歴ログデータアクセスを行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10402071-00 作成担当 : 立花 裕輔
// 作 成 日  2008/05/26  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Common;

using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// 操作履歴ログデータアクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : ＵＯＥ発注先アクセスクラス</br>
	/// <br>Programmer : 96186 立花裕輔</br>
	/// <br>Date       : 2008.05.26</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// <br>2008.05.26 men 新規作成</br>
	/// </remarks>
	public partial class UoeOprtnHisLogAcs
	{
		// ===================================================================================== //
		// コンストラクタ
		// ===================================================================================== //
		# region Constructors
		public UoeOprtnHisLogAcs()
		{
			//企業コードを取得する
			_enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

			//ログイン拠点コード
			_loginSectionCd = LoginInfoAcquisition.Employee.BelongSectionCode;

            //起動プログラム名称
            _logDataObjBootProgramNm = Path.GetFileName(Environment.GetCommandLineArgs()[0]);

			//操作履歴ログ処理
			_oprtnHisLogList = new List<OprtnHisLog>();

			//操作履歴ログ リモートオブジェクト
			this._iOprtnHisLogDB = (IOprtnHisLogDB)MediationOprtnHisLogDB.GetOprtnHisLogDB();
		}
		/// <summary>
		/// アクセスクラス インスタンス取得処理
		/// </summary>
		/// <returns></returns>
		public static UoeOprtnHisLogAcs GetInstance()
		{
			if (_uoeOprtnHisLogAcs == null)
			{
				_uoeOprtnHisLogAcs = new UoeOprtnHisLogAcs();
			}

			return _uoeOprtnHisLogAcs;
		}

		# endregion

		// ===================================================================================== //
		// プライベート変数
		// ===================================================================================== //
		# region Private Members
		//アクセスクラス インスタンス
		private static UoeOprtnHisLogAcs _uoeOprtnHisLogAcs;

		//操作履歴ログデータリスト
		private List<OprtnHisLog> _oprtnHisLogList = new List<OprtnHisLog>();

		//企業コード
        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

		//ログイン拠点コード
        private string _loginSectionCd = LoginInfoAcquisition.Employee.BelongSectionCode;

		//端末名
		private string _logDataMachineName = "";

		//ログデータ担当者コード
		private string _logDataAgentCd = "";

		//ログデータ担当者名
		private string _logDataAgentNm = "";

		//起動プログラム名称
        private string _logDataObjBootProgramNm = "";

		//操作履歴ログ リモート
		private IOprtnHisLogDB _iOprtnHisLogDB = null;

		# endregion

		// ===================================================================================== //
		// デリゲート
		// ===================================================================================== //
		# region Delegate
		# endregion

		// ===================================================================================== //
		// イベント
		// ===================================================================================== //
		# region Event
		# endregion

		// ===================================================================================== //
		// プロパティ
		// ===================================================================================== //
		# region Properties
		/// <summary>
		/// 端末名
		/// </summary>
		public string LogDataMachineName
		{
			get { return this._logDataMachineName; }
			set { this._logDataMachineName = value; }
		}

		/// <summary>
		/// ログデータ担当者コード
		/// </summary>
		public string LogDataAgentCd
		{
			get { return this._logDataAgentCd; }
			set { this._logDataAgentCd = value; }
		}

		/// <summary>
		/// ログデータ担当者名
		/// </summary>
		public string LogDataAgentNm
		{
			get { return this._logDataAgentNm; }
			set { this._logDataAgentNm = value; }
		}
		# endregion

		// ===================================================================================== //
		// パブリックメソッド
		// ===================================================================================== //
		# region Public Methods
		# region 操作履歴ログデータの初期化処理
		/// <summary>
		/// 操作履歴ログデータの初期化処理
		/// </summary>
		public void OprtnHisLogInit()
		{
			if (_oprtnHisLogList == null )
			{
                _oprtnHisLogList = new List<OprtnHisLog>();
            }
            else
            {
				_oprtnHisLogList.Clear();
			}
		}
		# endregion

        # region 通信ログ書き込み
        /// <summary>
        /// 通信ログ書き込み
        /// </summary>
        /// <param name="logDataObjProcNm"></param>
        /// <param name="logDataOperationCd"></param>
        /// <param name="logDataMassage"></param>
        /// <param name="len"></param>
        public void log_update(object sender, string logDataObjProcNm, Int32 logDataOperationCd, byte[] logDataMassage, int len, Int32 uOESupplierCd)
        {
            log_update(sender, logDataObjProcNm, logDataOperationCd, logDataMassage, len, (int)EnumUoeConst.ctOprtnHisLogFlush.ct_OFF);
        }

        /// <summary>
        /// 通信ログ書き込み
        /// </summary>
        /// <param name="logDataObjProcNm">メソッド名</param>
        /// <param name="logDataOperationCd">ログデータオペレーションコード</param>
        /// <param name="logDataMassage">ログデータ</param>
        /// <param name="len"></param>
        /// <param name="mode">0:フラッシュなし 1:フラッシュあり</param>
        public void log_update(object sender, string logDataObjProcNm, Int32 logDataOperationCd, byte[] logDataMassage, int len, Int32 uOESupplierCd, int mode)
        {
            string logDataMassageString = changeHex(logDataMassage, len);

            try
            {
                Type type = sender.GetType();


                OprtnHisLog oprtnHisLog = new OprtnHisLog();

                //ログデータ種別区分コード
                //0:記録,1:エラー,9:システム,10:UOE(DSP) 11:UOE(通信)
                oprtnHisLog.LogDataKindCd = (Int32)EnumUoeConst.ctLogDataKindCd.ct_TERM;

                //ログデータ対象アセンブリID
                oprtnHisLog.LogDataObjAssemblyID = type.Assembly.GetName().Name;

                //ログを書き込んだアセンブリ名称
                oprtnHisLog.LogDataObjAssemblyNm = type.Assembly.GetName().Name;

                //ログデータ対象処理名
                //ログを書き込む際の処理名(メソッド名)
                oprtnHisLog.LogDataObjProcNm = logDataObjProcNm;

                //ログデータオペレーションコード
                //操作内容コード(0:起動,1:ログイン,2:データ読込,3:データ挿入,4:データ更新,5:データ論理削除,6:データ削除,7:印刷,8:テキスト出力,9:通信,10:呼出,11:送信,12:受信,13:タイムアウト,14:終了)
                oprtnHisLog.LogDataOperationCd = logDataOperationCd;

                //プログラムのバージョン情報のバージョン
                oprtnHisLog.LogDataSystemVersion = type.Assembly.GetName().Version.ToString();

                //ログオペレーションステータス
                oprtnHisLog.LogOperationStatus = 0;

                //ログデータメッセージ
                oprtnHisLog.LogDataMassage = logDataMassageString;

                //発注先コード
                oprtnHisLog.LogDataObjClassID = uOESupplierCd.ToString("d6");

                //ログオペレーションデータ
                oprtnHisLog.LogOperationData = "";

                //操作履歴ログデータの更新
                _uoeOprtnHisLogAcs.OprtnHisLogUpdt(oprtnHisLog, mode);
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// 通信ログフラッシュ処理
        /// </summary>
        public void log_update()
        {
            _uoeOprtnHisLogAcs.OprtnHisLogFlush();

        }
        # endregion

        # region ＤＳＰログ書き込み
        /// <summary>
        /// ＤＳＰログ書き込み
        /// </summary>
        /// <param name="logDataObjProcNm"></param>
        /// <param name="logDataOperationCd"></param>
        /// <param name="logOperationStatus"></param>
        /// <param name="logDataMassage"></param>
        public void logd_update(object sender, string logDataObjProcNm, string logDataObjAssemblyNm, Int32 logDataOperationCd, Int32 logOperationStatus, string logDataMassage, Int32 uOESupplierCd)
        {
            try
            {
                Type type = sender.GetType();

                System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();
                //バージョンの取得
                System.Version ver = asm.GetName().Version;

		        //ＤＳＰログクラス
		        OprtnHisLog _dipLog = new OprtnHisLog();

                //ログデータ種別区分コード
                //0:記録,1:エラー,9:システム,10:UOE(DSP) 11:UOE(通信)
                _dipLog.LogDataKindCd = (Int32)EnumUoeConst.ctLogDataKindCd.ct_DSP;

                //ログデータ対象アセンブリID
                _dipLog.LogDataObjAssemblyID = type.Assembly.GetName().Name;

                //ログを書き込んだアセンブリ名称
                _dipLog.LogDataObjAssemblyNm = logDataObjAssemblyNm;

                //ログデータ対象処理名
                //ログを書き込む際の処理名(メソッド名)
                _dipLog.LogDataObjProcNm = logDataObjProcNm;

                //ログデータオペレーションコード
                //操作内容コード(0:起動,1:ログイン,2:データ読込,3:データ挿入,4:データ更新,5:データ論理削除,6:データ削除,7:印刷,8:テキスト出力,9:通信,10:呼出,11:送信,12:受信,13:タイムアウト,14:終了)
                _dipLog.LogDataOperationCd = logDataOperationCd;

                //プログラムのバージョン情報のバージョン
                _dipLog.LogDataSystemVersion = type.Assembly.GetName().Version.ToString();

                //ログオペレーションステータス
                _dipLog.LogOperationStatus = logOperationStatus;

                //ログデータメッセージ
                _dipLog.LogDataMassage = logDataMassage;

                //発注先コード
                _dipLog.LogDataObjClassID = uOESupplierCd.ToString("d6");

                //ログオペレーションデータ
                _dipLog.LogOperationData = "";

                //操作履歴ログデータの更新
                _uoeOprtnHisLogAcs.OprtnHisLogUpdt(_dipLog, (int)EnumUoeConst.ctOprtnHisLogFlush.ct_ON);
            }
            catch (Exception)
            {
            }
        }
        # endregion
		# endregion

		// ===================================================================================== //
		// プライベートメソッド
		// ===================================================================================== //
		# region Private Methods
        # region 操作履歴ログデータのフラッシュ処理
        /// <summary>
        /// 操作履歴ログデータのフラッシュ処理
        /// </summary>
        private void OprtnHisLogFlush()
        {
            string message = "";
            OprtnHisLogFlush(out message);
        }

        /// <summary>
        /// 操作履歴ログデータのフラッシュ処理
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private int OprtnHisLogFlush(out string message)
        {


            int status = (int)EnumUoeConst.Status.ct_NORMAL;
            message = "";
            try
            {
                if (_oprtnHisLogList.Count > 0)
                {
                    status = OprtnHisLogWrite(_oprtnHisLogList, out message);
                    OprtnHisLogInit();
                }
            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
            }
            return (status);
        }
        # endregion

        # region 操作履歴ログデータの更新
        /// <summary>
        /// 操作履歴ログデータの更新
        /// </summary>
        /// <param name="oprtnHisLog"></param>
        /// <param name="mode"></param>
        private void OprtnHisLogUpdt(OprtnHisLog oprtnHisLog, int mode)
        {
            string message = "";

            OprtnHisLogUpdt(oprtnHisLog, mode, out message);
        }

        /// <summary>
        /// 操作履歴ログデータの更新
        /// </summary>
        /// <param name="oprtnHisLog"></param>
        /// <param name="mode"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        private int OprtnHisLogUpdt(OprtnHisLog oprtnHisLog, int mode, out string message)
        {
            int status = (int)EnumUoeConst.Status.ct_NORMAL;
            message = "";
            try
            {
                OprtnHisLog log = oprtnHisLog;

                //企業コード
                log.EnterpriseCode = _enterpriseCode;

                //日付
                log.LogDataCreateDateTime = DateTime.Now;

                //ログデータGUID
                log.LogDataGuid = Guid.NewGuid();

                //ログイン拠点コード
                log.LoginSectionCd = _loginSectionCd;

                //端末名
                log.LogDataMachineName = _logDataMachineName;

                //ログデータ担当者コード
                log.LogDataAgentCd = _logDataAgentCd;

                //ログデータ担当者名
                log.LogDataAgentNm = _logDataAgentNm;

                //起動プログラム名称
                log.LogDataObjBootProgramNm = _logDataObjBootProgramNm;

                _oprtnHisLogList.Add(log);
                if (mode == 1)
                {
                    status = OprtnHisLogFlush(out message);
                }
            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
            }
            return (status);
        }
        # endregion

        # region 通信ログ値の１６進変換
        /// <summary>
        /// 通信ログ値の１６進変換
        /// </summary>
        /// <param name="src"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        private string changeHex(byte[] src, int len)
        {
            string dst = "";

            try
            {
                for (int i = 0; i < len; i++)
                {
                    int srcInt = UoeCommonFnc.ToInt32FromByteNum(src[i]);
                    dst += String.Format("{0:X2}", srcInt);
                }
            }
            catch (Exception)
            {
                dst = "";
            }

            return (dst);
        }
        # endregion

		# region 操作履歴ログデータの更新
		/// <summary>
		/// 操作履歴ログデータの更新
		/// </summary>
		/// <param name="message"></param>
		/// <returns></returns>
		private int OprtnHisLogWrite(List<OprtnHisLog> list, out string message)
		{
			int status = (int)EnumUoeConst.Status.ct_NORMAL;
			message = "";
			try
			{
				//更新処理を実装
				ArrayList oprtnHisLogWorkList = new ArrayList(); 
				
				foreach(OprtnHisLog log in list)
				{
					OprtnHisLogWork oprtnHisLogWork = new OprtnHisLogWork();

					oprtnHisLogWork.CreateDateTime = log.CreateDateTime;	// 作成日時
					oprtnHisLogWork.UpdateDateTime = log.UpdateDateTime;	// 更新日時
					oprtnHisLogWork.EnterpriseCode = log.EnterpriseCode;	// 企業コード
					//oprtnHisLogWork.FileHeaderGuid = log.FileHeaderGuid;	// GUID
					oprtnHisLogWork.UpdEmployeeCode = log.UpdEmployeeCode;	// 更新従業員コード
					oprtnHisLogWork.UpdAssemblyId1 = log.UpdAssemblyId1;	// 更新アセンブリID1
					oprtnHisLogWork.UpdAssemblyId2 = log.UpdAssemblyId2;	// 更新アセンブリID2
					oprtnHisLogWork.LogicalDeleteCode = log.LogicalDeleteCode;	// 論理削除区分
					oprtnHisLogWork.LogDataCreateDateTime = log.LogDataCreateDateTime;	// ログデータ作成日時
					oprtnHisLogWork.LogDataGuid = log.LogDataGuid;	// ログデータGUID
					oprtnHisLogWork.LoginSectionCd = log.LoginSectionCd;	// ログイン拠点コード
					oprtnHisLogWork.LogDataKindCd = log.LogDataKindCd;	// ログデータ種別区分コード
					oprtnHisLogWork.LogDataMachineName = log.LogDataMachineName;	// ログデータ端末名
					oprtnHisLogWork.LogDataAgentCd = log.LogDataAgentCd;	// ログデータ担当者コード
					oprtnHisLogWork.LogDataAgentNm = log.LogDataAgentNm;	// ログデータ担当者名
					oprtnHisLogWork.LogDataObjBootProgramNm = log.LogDataObjBootProgramNm;	// ログデータ対象起動プログラム名称
					oprtnHisLogWork.LogDataObjAssemblyID = log.LogDataObjAssemblyID;	// ログデータ対象アセンブリID
					oprtnHisLogWork.LogDataObjAssemblyNm = log.LogDataObjAssemblyNm;	// ログデータ対象アセンブリ名称
					oprtnHisLogWork.LogDataObjClassID = log.LogDataObjClassID;	// (UOE発注先コード)ログデータ対象クラスID
					oprtnHisLogWork.LogDataObjProcNm = log.LogDataObjProcNm;	// ログデータ対象処理名
					oprtnHisLogWork.LogDataOperationCd = log.LogDataOperationCd;	// ログデータオペレーションコード
					oprtnHisLogWork.LogOperaterDtProcLvl = log.LogOperaterDtProcLvl;	// ログデータオペレーターデータ処理レベル
					oprtnHisLogWork.LogOperaterFuncLvl = log.LogOperaterFuncLvl;	// ログデータオペレーター機能処理レベル
					oprtnHisLogWork.LogDataSystemVersion = log.LogDataSystemVersion;	// ログデータシステムバージョン
					oprtnHisLogWork.LogOperationStatus = log.LogOperationStatus;	// ログオペレーションステータス

                    // ログデータメッセージ
                    string logDataMassage = log.LogDataMassage;
                    if (log.LogDataMassage.Length > 500)
                    {
                        logDataMassage = log.LogDataMassage.Substring(0, 500);
                    }
                    oprtnHisLogWork.LogDataMassage = logDataMassage;

                    // ログオペレーションデータ
                    string logOperationData = log.LogOperationData;
                    if (log.LogOperationData.Length > 80)
                    {
                        logOperationData = log.LogOperationData.Substring(0, 80);
                    }
                    oprtnHisLogWork.LogOperationData = logOperationData;

					oprtnHisLogWorkList.Add(oprtnHisLogWork);
				}

                object oprtnHisLogWorkListObject = oprtnHisLogWorkList;

                status = _iOprtnHisLogDB.Write(ref oprtnHisLogWorkListObject);
				if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					status = -1;
					message = "操作履歴ログの書き込みに失敗しまた。";
				}

			}
			catch (Exception ex)
			{
				status = -1;
				message = ex.Message;
			}
			return (status);
		}
		# endregion
		# endregion
	}
}

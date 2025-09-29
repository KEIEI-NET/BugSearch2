//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : ＵＯＥ送信編集アクセスクラス
// プログラム概要   : ＵＯＥ送信編集アクセスを行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10402071-00 作成担当 : 立花 裕輔
// 作 成 日  2008/05/26  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  10601191-00 作成担当 : 高峰
// 作 成 日  2010/05/07  修正内容 : PM1008 明治UOE-WEB対応に伴う仕様追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 葛中華
// 作 成 日  2011/10/25  修正内容 : PM1113A 卸NET-WEB対応仕様追加
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Controller;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// ＵＯＥ送信編集アクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : ＵＯＥ送信編集アクセスクラス</br>
	/// <br>Programmer : 96186 立花裕輔</br>
	/// <br>Date       : 2008.05.26</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// <br>2008.05.26 men 新規作成</br>
    /// <br>UpDate</br>
    /// <br>2010/05/07 高峰 PM1008 明治UOE-WEB対応に伴う仕様追加</br>
    /// <br>UpDate</br>
    /// <br>2011/10/25 葛中華 PM1113A 卸NET-WEB対応仕様追加</br>
	/// </remarks>
	public partial class UoeSndEditAcs
	{
		// ===================================================================================== //
		// コンストラクタ
		// ===================================================================================== //
		# region Constructors
		public UoeSndEditAcs()
		{
			//ＵＯＥ送受信ＪＮＬアクセスクラス
			_uoeSndRcvJnlAcs = UoeSndRcvJnlAcs.GetInstance();

            //操作履歴ログアクセスクラス
            _uoeOprtnHisLogAcs = UoeOprtnHisLogAcs.GetInstance();
            _uoeOprtnHisLogAcs.LogDataMachineName = _uoeSndRcvJnlAcs.cashRegisterNo.ToString("d3");

			//ＵＯＥ送信編集結果
			_uoeSndEditHedRstList = new List<UoeSndHed>();

			//ＵＯＥ送信編集（トヨタＰＤ４）アクセスクラス
			_uoeSndEdit0102Acs = new UoeSndEdit0102Acs();

			//ＵＯＥ送信編集（ニッサンＮパーツ）アクセスクラス
			_uoeSndEdit0202Acs = new UoeSndEdit0202Acs();

			//ＵＯＥ送信編集（三菱）アクセスクラス
			_uoeSndEdit0301Acs = new UoeSndEdit0301Acs();

			//ＵＯＥ送信編集（旧マツダ）アクセスクラス
			_uoeSndEdit0401Acs = new UoeSndEdit0401Acs();

			//ＵＯＥ送信編集（新マツダ）アクセスクラス
			_uoeSndEdit0402Acs = new UoeSndEdit0402Acs();

			//ＵＯＥ送信編集（ホンダ）アクセスクラス
			_uoeSndEdit0501Acs = new UoeSndEdit0501Acs();

			//ＵＯＥ送信編集（優良）アクセスクラス
			_uoeSndEdit1001Acs = new UoeSndEdit1001Acs();
		}
		# endregion

		// ===================================================================================== //
		// プライベート変数
		// ===================================================================================== //
		# region Private Members

		//ＵＯＥ送信編集結果
        private List<UoeSndHed> _uoeSndEditHedRstList = null;

		//ＵＯＥ送受信ＪＮＬアクセスクラス
        private UoeSndRcvJnlAcs _uoeSndRcvJnlAcs = null;

        //操作履歴ログアクセスクラス
        private UoeOprtnHisLogAcs _uoeOprtnHisLogAcs = null;

		//ＵＯＥ送信編集（トヨタＰＤ４）アクセスクラス
		private UoeSndEdit0102Acs _uoeSndEdit0102Acs = null;

		//ＵＯＥ送信編集（ニッサンＮパーツ）アクセスクラス
		private UoeSndEdit0202Acs _uoeSndEdit0202Acs = null;

		//ＵＯＥ送信編集（三菱）アクセスクラス
		private UoeSndEdit0301Acs _uoeSndEdit0301Acs = null;

		//ＵＯＥ送信編集（旧マツダ）アクセスクラス
		private UoeSndEdit0401Acs _uoeSndEdit0401Acs = null;

		//ＵＯＥ送信編集（新マツダ）アクセスクラス
		private UoeSndEdit0402Acs _uoeSndEdit0402Acs = null;

		//ＵＯＥ送信編集（ホンダ）アクセスクラス
		private UoeSndEdit0501Acs _uoeSndEdit0501Acs = null;

		//ＵＯＥ送信編集（優良）アクセスクラス
		private UoeSndEdit1001Acs _uoeSndEdit1001Acs = null;
		# endregion

		// ===================================================================================== //
		// 定数
		// ===================================================================================== //
		# region Const Members
		//エラーメッセージ
		private const string MESSAGE_ERROR01 = "業務区分のパラメータが違います。";

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
		# region ＵＯＥ送信編集結果
		/// <summary>
		/// ＵＯＥ送信編集結果
		/// </summary>
		public List<UoeSndHed> uoeSndEditHedRstList
		{
			get
			{
				return this._uoeSndEditHedRstList;
			}
			set
			{
				this._uoeSndEditHedRstList = value;
			}
		}
		# endregion

		# region ＵＯＥ送受信ＪＮＬデータセット
		/// <summary>
		/// ＵＯＥ送受信ＪＮＬデータセット
		/// </summary>
		public DataSet UoeJnlDataSet
		{
			get
			{
				return this._uoeSndRcvJnlAcs.UoeJnlDataSet;
			}
		}
		# endregion
		# endregion

		// ===================================================================================== //
		// パブリックメソッド
		// ===================================================================================== //
		# region Public Methods

		# region ＵＯＥ送信編集
		/// <summary>
		/// ＵＯＥ送信編集
		/// </summary>
		/// <param name="uoeSndEditSearchPara"></param>
		/// <returns></returns>
        /// <remarks>
        /// <br>Update Note : 2010/05/07 高峰</br>
        /// <br>              PM1008 明治UOE-WEB対応に伴う仕様追加</br>
        /// <br>Update Note : 2011/10/25 葛中華</br>
        /// <br>              PM1113A 卸NET-WEB対応仕様追加</br>
        /// </remarks>
		public int writeUOESNDEdit(UoeSndRcvCtlPara para, Dictionary<Int32, UOESupplier> uOESupplierDictionary, out List<UoeSndHed> list, out string message)
		{
			//変数の初期化
            string procNm = "writeUOESNDEdit";
            string asseNm = "";
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			message = "";
			list = new List<UoeSndHed>(); 

			try
			{
				//ＵＯＥ送信編集処理
				_uoeSndEditHedRstList = new List<UoeSndHed>();

				foreach (Int32 key in uOESupplierDictionary.Keys)
				{
					List<UoeSndDtl> uoeSndDtlList = new List<UoeSndDtl>();
					UOESupplier uOESupplier = uOESupplierDictionary[key];

                    asseNm = "送信編集";
                    logd_update(procNm, asseNm, (Int32)EnumUoeConst.ctLogDataOperationCd.ct_START, 0, "", uOESupplier.UOESupplierCd);

					switch (uOESupplier.CommAssemblyId)
					{
						//トヨタ
						case EnumUoeConst.ctCommAssemblyId_0102:
							{
								status = _uoeSndEdit0102Acs.writeUOESNDEdit0102(para.BusinessCode,
															para.SystemDivCd,
															uOESupplier,
															out uoeSndDtlList,
															out message);
                                break;
							}

						//ニッサン
						case EnumUoeConst.ctCommAssemblyId_0202:
							{
                                status = _uoeSndEdit0202Acs.writeUOESNDEdit0202(para.BusinessCode,
															para.SystemDivCd,
															uOESupplier,
															out uoeSndDtlList,
															out message);
                                break;
							}
						//ミツビシ
						case EnumUoeConst.ctCommAssemblyId_0301:
							{
                                status = _uoeSndEdit0301Acs.writeUOESNDEdit0301(para.BusinessCode,
															para.SystemDivCd,
															uOESupplier,
															out uoeSndDtlList,
															out message);
                                break;
							}
						//旧マツダ
						case EnumUoeConst.ctCommAssemblyId_0401:
							{
                                status = _uoeSndEdit0401Acs.writeUOESNDEdit0401(para.BusinessCode,
															para.SystemDivCd,
															uOESupplier,
															out uoeSndDtlList,
															out message);
                                break;
							}
						//新マツダ
						case EnumUoeConst.ctCommAssemblyId_0402:
							{
                                status = _uoeSndEdit0402Acs.writeUOESNDEdit0402(para.BusinessCode,
															para.SystemDivCd,
															uOESupplier,
															out uoeSndDtlList,
															out message);
                                break;
							}
						//ホンダ
						case EnumUoeConst.ctCommAssemblyId_0501:
							{
                                status = _uoeSndEdit0501Acs.writeUOESNDEdit0501(para.BusinessCode,
															para.SystemDivCd,
															uOESupplier,
															out uoeSndDtlList,
															out message);
                                break;
							}
                        // ---ADD 2010/05/07 ------------------>>>>>
                        // 優良メーカーWebの場合を追加 ※通常の優良メーカーと同じ処理を行う
                        case EnumUoeConst.ctCommAssemblyId_1004:
                        // ---ADD 2010/05/07 ------------------<<<<<
                        // ---ADD 2011/10/25 ------------------>>>>>
                        // 卸NET-WEB対応仕様追加
                        case EnumUoeConst.ctCommAssemblyId_1003:
                        // ---ADD 2011/10/25 ------------------<<<<<
						//優良メーカー
						case EnumUoeConst.ctCommAssemblyId_1001:
							{
                                status = _uoeSndEdit1001Acs.writeUOESNDEdit1001(para.BusinessCode,
															para.SystemDivCd,
															uOESupplier,
															out uoeSndDtlList,
															out message);
                                break;
							}
						default:
							{
								continue;
							}
					}

                    logd_update(procNm, asseNm, (Int32)EnumUoeConst.ctLogDataOperationCd.ct_END, status, message, uOESupplier.UOESupplierCd);

					//送信編集クラスの正常取得
					if (status == (int)EnumUoeConst.Status.ct_NORMAL)
					{
						//ＵＯＥ送信編集クラスの格納処理
						if (uoeSndDtlList.Count > 0)
						{
							//ＵＯＥ送信編集 Dtl部の格納処理
							UoeSndHed uoeSndHed = new UoeSndHed();
							uoeSndHed.UoeSndDtlList = new List<UoeSndDtl>();
							uoeSndHed.UOESupplierCd = uOESupplier.UOESupplierCd;
							uoeSndHed.BusinessCode = para.BusinessCode;
							uoeSndHed.CommAssemblyId = uOESupplier.CommAssemblyId;
							uoeSndHed.UoeSndDtlList = uoeSndDtlList;

							//ＵＯＥ送信編集 Hed部の格納処理
							_uoeSndEditHedRstList.Add(uoeSndHed);
						}
					}
					//送信編集クラスなし
					else if (status == (int)EnumUoeConst.Status.ct_NOT_FOUND)
					{
						continue;
					}
					//エラー値
					else
					{
						break;
					}

				}
				//戻値として送信編集結果を格納
				if(status == 0)
				{
					list = _uoeSndEditHedRstList;
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

		// ===================================================================================== //
		// プライベートメソッド
		// ===================================================================================== //
		# region Private Methods
        # region ＤＳＰログ書き込み
        /// <summary>
        /// ＤＳＰログ書き込み
        /// </summary>
        /// <param name="logDataObjProcNm"></param>
        /// <param name="logDataOperationCd"></param>
        /// <param name="logOperationStatus"></param>
        /// <param name="logDataMassage"></param>
        private void logd_update(string logDataObjProcNm, string logDataObjAssemblyNm, Int32 logDataOperationCd, Int32 logOperationStatus, string logDataMassage, Int32 uOESupplierCd)
        {
            _uoeOprtnHisLogAcs.logd_update(this, logDataObjProcNm, logDataObjAssemblyNm, logDataOperationCd, logOperationStatus, logDataMassage, uOESupplierCd);
        }
        # endregion
        # endregion
	}
}

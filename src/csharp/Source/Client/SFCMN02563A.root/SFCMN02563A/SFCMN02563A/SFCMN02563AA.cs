//****************************************************************************//
// システム         :  PM.NS
// プログラム名称   ： SCM企業連結データアクセスクラス
// プログラム概要   ： 
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 對馬 大輔
// 作 成 日  2011/05/25  修正内容 : 新規作成(PM用に修正)
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Web.Services;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// SCM企業連結データアクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note		: SCM企業連結データへのアクセス制御を行います。</br>
	/// <br>Programmer	: 30015 橋本　裕毅</br>
	/// <br>Date		: 2009.06.02</br>
    /// <br>Update Note : 2009.08.19 30015　橋本　裕毅</br>
	/// <br>            : １．ＮＳ問題対応報告票(20090819_1)</br>
	/// <br>            :  サービスを認証情報より取得するよう修正</br>
	/// <br>            :  Debugロジックの削除(削除内容は履歴を参照)</br>
	/// </remarks>
	public class ScmEpCnectAcs
	{
        private const string CT_ServiceName = "SFCMN02564AA.asmx"; // 2011/05/25
        
        #region Constructor
		public ScmEpCnectAcs()
		{
			_sbErrorMsg = new StringBuilder();
		}
		#endregion

		#region Private Members
		private StringBuilder _sbErrorMsg; // エラーメッセージ
		#endregion

		#region Protected Method
		/// <summary>
		/// SCM企業連結データ(SCM企業連結拠点データ)サービスプロキシ取得処理
		/// </summary>
		/// <returns>SCM企業連結データ(SCM企業連結拠点データ)データサービスプロキシ</returns>
		/// <remarks>
		/// <br>Note		: SCM企業連結データ(SCM企業連結拠点データ)のプロキシ情報を取得します。</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2009.06.02</br>
		/// </remarks>
		protected virtual SFCMN02564AServices GetSFCMN02564AServices()
		{
            //>>>2011/05/25
            //LoginInfoAcquisition loginInfObj = new LoginInfoAcquisition();

            //#region 2009.08.19 Hiroki Hashimoto Add
            //string wkStr1 = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_SCMAP);
            //string wkStr2 = loginInfObj.GetConnectionInfo(ConstantManagement_SF_PRO.ServerCode_SCMAP, ConstantManagement_SF_PRO.IndexCode_SCM_WebPath);

            //SFCMN02564AServices result = new SFCMN02564AServices(wkStr1 + wkStr2 + "SFCMN02564AA.asmx");
            //#endregion
            //#region 2009.08.19 Hiroki Hashimoto Del
            ////string wkStr1 = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_VXAP);
            ////string wkStr2 = loginInfObj.GetConnectionInfo(ConstantManagement_SF_PRO.ServerCode_VXAP, ConstantManagement_SF_PRO.IndexCode_VX_WebPath);

            //////SFCMN02564AServices result = new SFCMN02564AServices(wkStr1 + wkStr2 + "SFCMN02564AA.asmx");
            //#endregion

            //result.Timeout = 600000; //タイムアウト10分

            //return result;

            SFCMN02564AServices result = new SFCMN02564AServices(GetSCMWebServiceURLFromPMC() + CT_ServiceName); // 本番
            result.Timeout = 600000; //タイムアウト10分
            return result;
            //<<<2011/05/25
		}
		#endregion

        //>>>2011/05/25
        #region 認証情報よりSCM_ServiceのURL取得
        /// <summary>
        /// 認証情報よりSCM_ServiceのURL取得
        /// </summary>
        /// <returns></returns>
        private static string GetSCMWebServiceURLFromPMC()
        {
            string SCMWebServiceURL = string.Empty;
            try
            {

                SCMWebServiceURL = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_SCMAP);	// SCMWebサービスサーバー
                SCMWebServiceURL += LoginInfoAcquisition.GetConnectionInfo(ConstantManagement_SF_PRO.ServerCode_SCMAP, ConstantManagement_SF_PRO.IndexCode_SCM_WebPath);

                return SCMWebServiceURL;
            }
            //catch (Exception e)
            catch (Exception)
            {
                // 読み取りに失敗した場合は何もしない
                return string.Empty;
            }

        }
        #endregion
        //<<<2011/05/25

		#region Public Methods
		#region Read
		/// <summary>
		/// SCM企業連結データ読込処理
		/// </summary>
		/// <param name="cnectOriginalEpCd">連結元企業コード</param>
		/// <param name="cnectOtherEpCd">連結先企業コード</param>
		/// <param name="retScmEpCnect">SCM企業連結データクラス</param>
		/// <param name="msgDiv">メッセージ区分</param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>ステータス[ConstantManagement.DB_Status]</returns>
		/// <remarks>
		/// <br>Note		: SCM企業連結データの読込処理を行います。</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2009.06.02</br>
		/// </remarks>
		public int ReadScmEpCnect(string cnectOriginalEpCd, string cnectOtherEpCd, out ScmEpCnect retScmEpCnect, out bool msgDiv, out string errMsg)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			retScmEpCnect = new ScmEpCnect();
			msgDiv = false;
			errMsg = string.Empty;
			try
			{
				ScmEpCnectWork scmEpCnectWork;
				// SCM企業連結読み込み処理
				status = GetSFCMN02564AServices().ReadScmEpCnect(cnectOriginalEpCd, cnectOtherEpCd, out scmEpCnectWork, out msgDiv, out errMsg);

				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						// メンバーコピー
                        retScmEpCnect = SFCMN02563AC.CopyScmEpCnectWorkToScmEpCnect(scmEpCnectWork);
                        break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT:
					{
						if (msgDiv)
							_sbErrorMsg.AppendLine(errMsg);
						else
							_sbErrorMsg.AppendLine("SCM企業連結データの読込に失敗しました。");
						break;
					}
					default:
					{
						_sbErrorMsg.AppendLine("SCM企業連結データの読込に失敗しました。");
						break;
					}
				}
			}
			catch (Exception ex)
			{
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
				_sbErrorMsg.AppendLine("SCM企業連結データ読込処理にて例外が発生しました。");
				_sbErrorMsg.AppendLine(ex.Message);
			}

			errMsg = _sbErrorMsg.ToString();
			return status;
		}
		#endregion

		#region Search
        //>>>2011/05/25
        #region 削除
        ///// <summary>
        ///// SCM連結先企業データ検索処理
        ///// </summary>
        ///// <param name="cnectOriginalEpCd">連結元企業コード</param>
        ///// <param name="cmLogicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        ///// <param name="retScmEpCnectList">SCM企業連結データクラスリスト</param>
        ///// <param name="msgDiv">メッセージ区分</param>
        ///// <param name="errMsg">エラーメッセージ</param>
        ///// <returns>ステータス[ConstantManagement.DB_Status]</returns>
        ///// <remarks>
        ///// <br>Note		: SCM企業連結データの読込処理を行います。</br>
        ///// <br>Programmer	: 30015 橋本　裕毅</br>
        ///// <br>Date		: 2009.06.02</br>
        ///// </remarks>
        //public int SearchCnectOriginalEp(string cnectOriginalEpCd, ConstantManagement.LogicalMode cmLogicalMode, out List<ScmEpCnect> retScmEpCnectList, out bool msgDiv, out string errMsg)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

        //    retScmEpCnectList = new List<ScmEpCnect>();
        //    msgDiv = false;
        //    errMsg = string.Empty;
        //    try
        //    {
        //        ScmEpCnectWork[] scmEpCnectWorks;
        //        // SCM連結先企業データ検索処理
        //        status = GetSFCMN02564AServices().SearchCnectOtherEpFromEp(cnectOriginalEpCd, SFCMN02563AC.ConvertLogicalMode(cmLogicalMode), out scmEpCnectWorks, out msgDiv, out errMsg);

        //        switch (status)
        //        {
        //            case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
        //            {
        //                // メンバーコピー
        //                foreach (ScmEpCnectWork scmEpCnectWork in scmEpCnectWorks)
        //                {
        //                    retScmEpCnectList.Add(SFCMN02563AC.CopyScmEpCnectWorkToScmEpCnect(scmEpCnectWork));
        //                }
        //                break;
        //            }
        //            case (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT:
        //            {
        //                if (msgDiv)
        //                    _sbErrorMsg.AppendLine(errMsg);
        //                else
        //                    _sbErrorMsg.AppendLine("SCM連結先企業データの検索に失敗しました。");
        //                break;
        //            }
        //            default:
        //            {
        //                _sbErrorMsg.AppendLine("SCM連結先企業データの検索に失敗しました。");
        //                break;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //        _sbErrorMsg.AppendLine("SCM連結先企業データ検索処理にて例外が発生しました。");
        //        _sbErrorMsg.AppendLine(ex.Message);
        //    }

        //    errMsg = _sbErrorMsg.ToString();
        //    return status;
        //}

        #endregion

        /// <summary>
        /// SCM連結先企業データ検索処理
        /// </summary>
        /// <param name="cnectOriginalEpCd">連結元企業コード</param>
        /// <param name="cmLogicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="retScmEpCnectList">SCM企業連結データクラスリスト</param>
        /// <param name="msgDiv">メッセージ区分</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>ステータス[ConstantManagement.DB_Status]</returns>
        /// <remarks>
        /// <br>Note		: SCM企業連結データの読込処理を行います。</br>
        /// <br>Programmer	: 30015 橋本　裕毅</br>
        /// <br>Date		: 2009.06.02</br>
        /// </remarks>
        public int SearchCnectOriginalEp(string cnectOtherEpCd, ConstantManagement.LogicalMode cmLogicalMode, out List<ScmEpCnect> retScmEpCnectList, out bool msgDiv, out string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            retScmEpCnectList = new List<ScmEpCnect>();
            msgDiv = false;
            errMsg = string.Empty;
            try
            {
                ScmEpCnectWork[] scmEpCnectWorks;
                // SCM連結先企業データ検索処理
                status = GetSFCMN02564AServices().SearchCnectOriginalEpFromEp(cnectOtherEpCd, SFCMN02563AC.ConvertLogicalMode(cmLogicalMode), out scmEpCnectWorks, out msgDiv, out errMsg);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            // メンバーコピー
                            foreach (ScmEpCnectWork scmEpCnectWork in scmEpCnectWorks)
                            {
                                retScmEpCnectList.Add(SFCMN02563AC.CopyScmEpCnectWorkToScmEpCnect(scmEpCnectWork));
                            }
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT:
                        {
                            if (msgDiv)
                                _sbErrorMsg.AppendLine(errMsg);
                            else
                                _sbErrorMsg.AppendLine("SCM連結先企業データの検索に失敗しました。");
                            break;
                        }
                    default:
                        {
                            _sbErrorMsg.AppendLine("SCM連結先企業データの検索に失敗しました。");
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                _sbErrorMsg.AppendLine("SCM連結先企業データ検索処理にて例外が発生しました。");
                _sbErrorMsg.AppendLine(ex.Message);
            }

            errMsg = _sbErrorMsg.ToString();
            return status;
        }
        //<<<2011/05/25
        #endregion

		#region Write
		/// <summary>
		/// SCM企業連結データ登録・更新処理
		/// </summary>
		/// <param name="scmEpCnects">SCM企業連結データクラス配列</param>
		/// <param name="msgDiv">メッセージ区分</param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>ステータス[ConstantManagement.DB_Status]</returns>
		/// <remarks>
		/// <br>Note		: SCM企業連結データの登録・更新処理を行います。</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2009.06.02</br>
		/// </remarks>
		public int WriteScmEpCnect(ref ScmEpCnect[] scmEpCnects, out bool msgDiv, out string errMsg)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			msgDiv = false;
			errMsg = string.Empty;
			try
			{
				ScmEpCnectWork[] scmEpCnectWorks = new ScmEpCnectWork[scmEpCnects.Length];
				// メンバーコピー
				for(int ix = 0; ix != scmEpCnects.Length; ix++)
				{
					scmEpCnectWorks[ix] = SFCMN02563AC.CopyScmEpCnectToScmEpCnectWork(scmEpCnects[ix]);
				}

				// SCM連結先企業データ検索処理
				status = GetSFCMN02564AServices().WriteScmEpCnect(ref scmEpCnectWorks, out msgDiv, out errMsg);

				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						// メンバーコピー
						for(int iy = 0; iy != scmEpCnectWorks.Length; iy++)
						{
							scmEpCnects[iy] = SFCMN02563AC.CopyScmEpCnectWorkToScmEpCnect(scmEpCnectWorks[iy]);
						}
						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT:
					{
						if (msgDiv)
							_sbErrorMsg.AppendLine(errMsg);
						else
							_sbErrorMsg.AppendLine("SCM企業連結データの登録・更新に失敗しました。");
						break;
					}
					default:
					{
						_sbErrorMsg.AppendLine("SCM企業連結データの登録・更新に失敗しました。");
						break;
					}
				}
			}
			catch (Exception ex)
			{
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
				_sbErrorMsg.AppendLine("SCM企業連結データ登録・更新処理にて例外が発生しました。");
				_sbErrorMsg.AppendLine(ex.Message);
			}

			errMsg = _sbErrorMsg.ToString();
			return status;
		}
		#endregion

		#region LogicalDelete
		/// <summary>
		/// SCM企業連結データ論理削除処理
		/// </summary>
		/// <param name="scmEpCnects">SCM企業連結データクラス配列</param>
		/// <param name="msgDiv">メッセージ区分</param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>ステータス[ConstantManagement.DB_Status]</returns>
		/// <remarks>
		/// <br>Note		: SCM企業連結データの論理削除処理を行います。</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2009.06.02</br>
		/// </remarks>
		public int LogicalDeleteScmEpCnect(ref ScmEpCnect[] scmEpCnects, out bool msgDiv, out string errMsg)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			msgDiv = false;
			errMsg = string.Empty;
			try
			{
				ScmEpCnectWork[] scmEpCnectWorks = new ScmEpCnectWork[scmEpCnects.Length];
				// メンバーコピー
				for(int ix = 0; ix != scmEpCnects.Length; ix++)
				{
					scmEpCnectWorks[ix] = SFCMN02563AC.CopyScmEpCnectToScmEpCnectWork(scmEpCnects[ix]);
				}

				// SCM連結先企業データ検索処理
				status = GetSFCMN02564AServices().LogicalDeleteScmEpCnect(ref scmEpCnectWorks, out msgDiv, out errMsg);

				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						// メンバーコピー
						for(int iy = 0; iy != scmEpCnectWorks.Length; iy++)
						{
							scmEpCnects[iy] = SFCMN02563AC.CopyScmEpCnectWorkToScmEpCnect(scmEpCnectWorks[iy]);
						}
						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT:
					{
						if (msgDiv)
							_sbErrorMsg.AppendLine(errMsg);
						else
							_sbErrorMsg.AppendLine("SCM企業連結データの論理削除に失敗しました。");
						break;
					}
					default:
					{
						_sbErrorMsg.AppendLine("SCM企業連結データの論理削除に失敗しました。");
						break;
					}
				}
			}
			catch (Exception ex)
			{
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
				_sbErrorMsg.AppendLine("SCM企業連結データ論理削除処理にて例外が発生しました。");
				_sbErrorMsg.AppendLine(ex.Message);
			}

			errMsg = _sbErrorMsg.ToString();
			return status;
		}
		#endregion

		#region Delete
		/// <summary>
		/// SCM企業連結データ物理削除処理
		/// </summary>
		/// <param name="scmEpCnects">SCM企業連結データクラス配列</param>
		/// <param name="msgDiv">メッセージ区分</param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>ステータス[ConstantManagement.DB_Status]</returns>
		/// <remarks>
		/// <br>Note		: SCM企業連結データの物理削除処理を行います。</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2009.06.02</br>
		/// </remarks>
		public int DeleteScmEpCnect(ScmEpCnect scmEpCnect, out bool msgDiv, out string errMsg)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			msgDiv = false;
			errMsg = string.Empty;
			try
			{
				// メンバーコピー
				ScmEpCnectWork scmEpCnectWork = SFCMN02563AC.CopyScmEpCnectToScmEpCnectWork(scmEpCnect);

				// SCM連結先企業データ検索処理
				status = GetSFCMN02564AServices().DeleteScmEpCnect(scmEpCnectWork, out msgDiv, out errMsg);

				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT:
					{
						if (msgDiv)
							_sbErrorMsg.AppendLine(errMsg);
						else
							_sbErrorMsg.AppendLine("SCM企業連結データの物理削除に失敗しました。");
						break;
					}
					default:
					{
						_sbErrorMsg.AppendLine("SCM企業連結データの物理削除に失敗しました。");
						break;
					}
				}
			}
			catch (Exception ex)
			{
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
				_sbErrorMsg.AppendLine("SCM企業連結データ物理削除処理にて例外が発生しました。");
				_sbErrorMsg.AppendLine(ex.Message);
			}

			errMsg = _sbErrorMsg.ToString();
			return status;
		}
		#endregion

		#region Revival
		/// <summary>
		/// SCM企業連結データ論理削除復活処理
		/// </summary>
		/// <param name="scmEpCnects">SCM企業連結データクラス配列</param>
		/// <param name="msgDiv">メッセージ区分</param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>ステータス[ConstantManagement.DB_Status]</returns>
		/// <remarks>
		/// <br>Note		: SCM企業連結データの論理削除復活処理を行います。</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2009.06.02</br>
		/// </remarks>
		public int RevivalScmEpCnect(ref ScmEpCnect[] scmEpCnects, out bool msgDiv, out string errMsg)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			msgDiv = false;
			errMsg = string.Empty;
			try
			{
				ScmEpCnectWork[] scmEpCnectWorks = new ScmEpCnectWork[scmEpCnects.Length];
				// メンバーコピー
				for(int ix = 0; ix != scmEpCnects.Length; ix++)
				{
					scmEpCnectWorks[ix] = SFCMN02563AC.CopyScmEpCnectToScmEpCnectWork(scmEpCnects[ix]);
				}

				// SCM連結先企業データ検索処理
				status = GetSFCMN02564AServices().RevivalScmEpCnect(ref scmEpCnectWorks, out msgDiv, out errMsg);

				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						// メンバーコピー
						for(int iy = 0; iy != scmEpCnectWorks.Length; iy++)
						{
							scmEpCnects[iy] = SFCMN02563AC.CopyScmEpCnectWorkToScmEpCnect(scmEpCnectWorks[iy]);
						}
						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT:
					{
						if (msgDiv)
							_sbErrorMsg.AppendLine(errMsg);
						else
							_sbErrorMsg.AppendLine("SCM企業連結データの論理削除復活に失敗しました。");
						break;
					}
					default:
					{
						_sbErrorMsg.AppendLine("SCM企業連結データの論理削除復活に失敗しました。");
						break;
					}
				}
			}
			catch (Exception ex)
			{
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
				_sbErrorMsg.AppendLine("SCM企業連結データ論理削除復活処理にて例外が発生しました。");
				_sbErrorMsg.AppendLine(ex.Message);
			}

			errMsg = _sbErrorMsg.ToString();
			return status;
		}
		#endregion
		#endregion

	}
}

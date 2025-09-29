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
using Broadleaf.Application.Common;
using Broadleaf.Web.Services;
using Broadleaf.Application.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// SCM連結元拠点別設定データアクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note		: SCM連結元拠点別設定データへのアクセス制御を行います。</br>
	/// <br>Programmer	: 30015 橋本　裕毅</br>
	/// <br>Date		: 2011.05.26</br>
	/// <br></br>
	/// </remarks>
	public class ScmCnctSetAcs
	{
        private const string CT_ServiceName = "SFCMN02564AA.asmx"; // 2011/05/25

		#region Constructor
		/// <summary>
		/// SCM連結元拠点別設定データアクセスクラスコンストラクタ
		/// </summary>
		public ScmCnctSetAcs()
		{
		}
		#endregion

		#region Protected Method
		/// <summary>
		/// SCM連結元拠点別設定データサービスプロキシ取得処理
		/// </summary>
		/// <returns>SCM連結元拠点別設定データサービスプロキシ</returns>
		/// <remarks>
		/// <br>Note		: SCM連結元拠点別設定データのプロキシ情報を取得します。</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2011.05.26</br>
		/// </remarks>
		protected virtual SFCMN02564AServices GetSFCMN02564AServices()
		{
            //>>>2011/05/25
            //LoginInfoAcquisition loginInfObj = new LoginInfoAcquisition();
            //string wkStr1 = LoginInfoAcquisition.GetAPServiceTargetDomain(ConstantManagement_SF_PRO.ServerCode_SCMAP);
            //string wkStr2 = loginInfObj.GetConnectionInfo(ConstantManagement_SF_PRO.ServerCode_SCMAP, ConstantManagement_SF_PRO.IndexCode_SCM_WebPath);

            //SFCMN02564AServices result = new SFCMN02564AServices(wkStr1 + wkStr2 + "SFCMN02564AA.asmx");

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
		/// SCM連結元拠点別設定データ読込処理
		/// </summary>
		/// <param name="cnectOriginalEpCd">連結元企業コード</param>
		/// <param name="cnectOriginalSecCd">連結元拠点コード</param>
		/// <param name="retScmCnctSet">SCM連結元拠点別設定データクラス</param>
		/// <param name="msgDiv">メッセージ区分</param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>ステータス[ConstantManagement.DB_Status]</returns>
		/// <remarks>
		/// <br>Note		: SCM連結元拠点別設定データの読込処理を行います。</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2011.05.26</br>
		/// </remarks>
		public int ReadScmCnctSet(string cnectOriginalEpCd, string cnectOriginalSecCd, out ScmCnctSet retScmCnctSet, out bool msgDiv, out string errMsg)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			retScmCnctSet = new ScmCnctSet();
			msgDiv = false;
			errMsg = string.Empty;
			StringBuilder sbErrorMsg = new StringBuilder();

			try
			{
			    ScmCnctSetWork ScmCnctSetWork;
			    // SCM連結元拠点別設定データ読み込み処理
			    status = GetSFCMN02564AServices().ReadScmCnctSet(cnectOriginalEpCd, cnectOriginalSecCd, out ScmCnctSetWork, out msgDiv, out errMsg);

			    switch (status)
			    {
			        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
			        {
			            // メンバーコピー
			            retScmCnctSet = SFCMN02563AC.CopyScmCnctSetWorkToScmCnctSet(ScmCnctSetWork);
			            break;
			        }
			        case (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT:
			        {
			            if (msgDiv)
			                sbErrorMsg.AppendLine(errMsg);
			            else
			                sbErrorMsg.AppendLine("SCM連結元拠点別設定データの読込に失敗しました。");
			            break;
			        }
			        default:
			        {
			            sbErrorMsg.AppendLine("SCM連結元拠点別設定データの読込に失敗しました。");
			            break;
			        }
			    }
			}
			catch (Exception ex)
			{
			    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			    sbErrorMsg.AppendLine("SCM連結元拠点別設定データ読込処理にて例外が発生しました。");
			    sbErrorMsg.AppendLine(ex.Message);
			}

			errMsg = sbErrorMsg.ToString();
			return status;
		}
		#endregion

		#region Write
		/// <summary>
		/// SCM連結元拠点別設定データ登録・更新処理
		/// </summary>
		/// <param name="scmCnctSet">SCM連結元拠点別設定データクラス</param>
		/// <param name="msgDiv">メッセージ区分</param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>ステータス[ConstantManagement.DB_Status]</returns>
		/// <remarks>
		/// <br>Note		: SCM連結元拠点別設定データの登録・更新処理を行います。</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2011.05.26</br>
		/// </remarks>
		public int WriteScmCnctSet(ref ScmCnctSet scmCnctSet, out bool msgDiv, out string errMsg)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			msgDiv = false;
			errMsg = string.Empty;
			StringBuilder sbErrorMsg = new StringBuilder();

			try
			{
				ScmCnctSetWork scmCnctSetWork = new ScmCnctSetWork();
				// メンバーコピー
				scmCnctSetWork = SFCMN02563AC.CopyScmCnctSetToScmCnctSetWork(scmCnctSet);

				// SCM連結先企業データ検索処理
				status = GetSFCMN02564AServices().WriteScmCnctSet(ref scmCnctSetWork, out msgDiv, out errMsg);

				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						// メンバーコピー
						scmCnctSet = SFCMN02563AC.CopyScmCnctSetWorkToScmCnctSet(scmCnctSetWork);
						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT:
					{
						if (msgDiv)
							sbErrorMsg.AppendLine(errMsg);
						else
							sbErrorMsg.AppendLine("SCM連結元拠点別設定データの登録・更新に失敗しました。");
						break;
					}
					default:
					{
						sbErrorMsg.AppendLine("SCM連結元拠点別設定データの登録・更新に失敗しました。");
						break;
					}
				}
			}
			catch (Exception ex)
			{
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
				sbErrorMsg.AppendLine("SCM連結元拠点別設定データ登録・更新処理にて例外が発生しました。");
				sbErrorMsg.AppendLine(ex.Message);
			}

			errMsg = sbErrorMsg.ToString();
			return status;
		}
		#endregion
		#endregion
	}
}

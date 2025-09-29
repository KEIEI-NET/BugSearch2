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
// 管理番号              作成担当 : 30745　吉岡
// 更 新 日  2013/05/24  修正内容 : 2013/06/18配信予定　SCM№10533対応
//----------------------------------------------------------------------------//
// 管理番号：11070111-00 変更担当 : 18022 Ryo.
// 更 新 日：2014.09.10  変更内容 : FTC事業場対応
//----------------------------------------------------------------------------//
// 管理番号：11070111-00 変更担当 : 18022 Ryo.
// 更 新 日：2014.11.18  変更内容 : FTC事業場対応
//                                : ①企業・拠点連結設定－相手側SF拠点コードのリスト表示・選択
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30973　鹿庭
// 作 成 日  2014/12/19  修正内容 : SCM高速化 PMNS対応
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Web.Services;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using System.Collections;
using Broadleaf.Windows.Forms;
// ADD 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 --------->>>>>>>>>>>>>>>>>>>>>>>>>
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
// ADD 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// SCM企業拠点連結データアクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note		: SCM企業拠点連結データへのアクセス制御を行います。</br>
	/// <br>			: ガイド機能有りです。</br>
	/// <br>Programmer	: 30015 橋本　裕毅</br>
	/// <br>Date		: 2009.06.02</br>
	/// <br></br>
	/// <br>Update Note	: 2009.06.23 22024 寺坂誉志</br>
	/// <br>			: １．汎用ガイドの実装</br>
    /// <br>Update Note : 2009.08.19 30015　橋本　裕毅</br>
	/// <br>            : １．ＮＳ問題対応報告票(20090819_1)</br>
	/// <br>            :  サービスを認証情報より取得するよう修正</br>
	/// <br>            :  Debugロジックの削除(削除内容は履歴を参照)</br>
	/// </remarks>
	public class ScmEpScCntAcs : IGeneralGuideData
	{
        private const string CT_ServiceName = "SFCMN02564AA.asmx"; // 2011/05/25

		public ScmEpScCntAcs()
		{
			_sbErrorMsg = new StringBuilder();
		}

		#region Private Members
		private StringBuilder _sbErrorMsg; // エラーメッセージ
        // ADD 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>SCM企業連結設定　DBRemoteObjectインターフェース</summary>
        private IScmEpCnectDB _iScmEpCnectDB = null;
        // ADD 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
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
		/// SCM企業拠点連結データ読込処理
		/// </summary>
		/// <param name="cnectOriginalEpCd">連結元企業コード</param>
		/// <param name="cnectOriginalSecCd">連結元拠点コード</param>
		/// <param name="cnectOtherEpCd">連結先企業コード</param>
		/// <param name="cnectOtherSecCd">連結先拠点コード</param>
		/// <param name="retScmEpScCnt">SCM企業拠点連結データクラス</param>
		/// <param name="msgDiv">メッセージ区分</param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>ステータス[ConstantManagement.DB_Status]</returns>
		/// <remarks>
		/// <br>Note		: SCM企業拠点連結データの読込処理を行います。</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2009.06.02</br>
		/// </remarks>
		public int ReadScmEpScCnt(string cnectOriginalEpCd, string cnectOriginalSecCd, string cnectOtherEpCd, string cnectOtherSecCd, out ScmEpScCnt retScmEpScCnt, out bool msgDiv, out string errMsg)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			retScmEpScCnt = new ScmEpScCnt();
			msgDiv = false;
			errMsg = string.Empty;
			try
			{
                // UPD 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                #region 旧ソース
                //ScmEpScCntWork scmEpScCntWork;
                //// SCM企業拠点連結読み込み処理
                //status = GetSFCMN02564AServices().ReadScmEpScCnt(cnectOriginalEpCd, cnectOriginalSecCd, cnectOtherEpCd, cnectOtherSecCd, out scmEpScCntWork, out msgDiv, out errMsg);
                #endregion
                ScmEpScCntWork scmEpScCntWork = null;
                Broadleaf.Application.Remoting.ParamData.ScmEpScCntWork scmEpScCntWork2 = null;
                CreateIScmEpCnectDB();
                status = _iScmEpCnectDB.ReadScmEpScCnt(cnectOriginalEpCd, cnectOriginalSecCd, cnectOtherEpCd, cnectOtherSecCd, out scmEpScCntWork2, out msgDiv, out errMsg);
                // UPD 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
                        // UPD 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                        // メンバーコピー
						// retScmEpScCnt = SFCMN02563AC.CopyScmEpScCntWorkToScmEpScCnt(scmEpScCntWork);
                        retScmEpScCnt = SFCMN02563AC.CopyScmEpScCntWorkToScmEpScCnt(scmEpScCntWork2);
                        // UPD 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                        break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT:
					{
						if (msgDiv)
							_sbErrorMsg.AppendLine(errMsg);
						else
							_sbErrorMsg.AppendLine("SCM企業拠点連結データの読込に失敗しました。");
						break;
					}
					default:
					{
						_sbErrorMsg.AppendLine("SCM企業拠点連結データの読込に失敗しました。");
						break;
					}
				}
			}
			catch (Exception ex)
			{
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
				_sbErrorMsg.AppendLine("SCM企業拠点連結データ読込処理にて例外が発生しました。");
				_sbErrorMsg.AppendLine(ex.Message);
			}

			errMsg = _sbErrorMsg.ToString();
			return status;
		}
		#endregion

		#region Search
        #region SearchCnectOtherEpFromSc SCM連結先企業拠点データ検索処理
        /// <summary>
		/// SCM連結先企業拠点データ検索処理
		/// </summary>
		/// <param name="cnectOriginalEpCd">連結元企業コード</param>
		/// <param name="cmLogicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <param name="retScmEpScCntList">SCM企業拠点連結データリスト</param>
		/// <param name="msgDiv">メッセージ区分</param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>ステータス[ConstantManagement.DB_Status]</returns>
		/// <remarks>
		/// <br>Note		: SCM連結先企業拠点データ検索処理を行います。</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2009.06.02</br>
		/// </remarks>
		public int SearchCnectOtherEpFromSc(string cnectOriginalEpCd, ConstantManagement.LogicalMode cmLogicalMode, out List<ScmEpScCnt> retScmEpScCntList, out bool msgDiv, out string errMsg)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			retScmEpScCntList = new List<ScmEpScCnt>();
			msgDiv = false;
			errMsg = string.Empty;
			try
			{
                // UPD 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                #region 旧ソース
                //ScmEpScCntWork[] scmEpScCntWorks;
                //// SCM連結先企業データ検索処理
                //status = GetSFCMN02564AServices().SearchCnectOtherEpFromSc(cnectOriginalEpCd, SFCMN02563AC.ConvertLogicalMode(cmLogicalMode), out scmEpScCntWorks, out msgDiv, out errMsg);
                #endregion
                Broadleaf.Application.Remoting.ParamData.ScmEpScCntWork[] scmEpScCntWorks;
                CreateIScmEpCnectDB();
                status = _iScmEpCnectDB.SearchCnectOtherEpFromSc(cnectOriginalEpCd, cmLogicalMode, out scmEpScCntWorks, out msgDiv, out errMsg);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // メンバーコピー
                    foreach (Broadleaf.Application.Remoting.ParamData.ScmEpScCntWork scmEpScCntWork in scmEpScCntWorks)
                    {
                        retScmEpScCntList.Add(SFCMN02563AC.CopyScmEpScCntWorkToScmEpScCnt(scmEpScCntWork));
                    }
                }
                // UPD 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
                        // DEL 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                        #region 旧ソース
                        //// メンバーコピー
                        //foreach (ScmEpScCntWork scmEpScCntWork in scmEpScCntWorks)
                        //{
                        //    retScmEpScCntList.Add(SFCMN02563AC.CopyScmEpScCntWorkToScmEpScCnt(scmEpScCntWork));
                        //}
                        #endregion
                        // DEL 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT:
					{
						if (msgDiv)
							_sbErrorMsg.AppendLine(errMsg);
						else
							_sbErrorMsg.AppendLine("SCM連結先企業拠点データの検索に失敗しました。");
						break;
					}
					default:
					{
						_sbErrorMsg.AppendLine("SCM連結先企業拠点データの検索に失敗しました。");
						break;
					}
				}
			}
			catch (Exception ex)
			{
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
				_sbErrorMsg.AppendLine("SCM連結先企業拠点データ検索処理にて例外が発生しました。");
				_sbErrorMsg.AppendLine(ex.Message);
			}

			errMsg = _sbErrorMsg.ToString();
			return status;
        }
        #endregion

        #region SearchCnectOtherSec SCM連結先拠点データ検索処理
        /// <summary>
		/// SCM連結先拠点データ検索処理
		/// </summary>
		/// <param name="cnectOriginalEpCd">連結元企業コード</param>
		/// <param name="cnectOriginalSecCd">連結元拠点コード</param>
		/// <param name="cnectOtherEpCd">連結先企業コード</param>
		/// <param name="cmLogicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <param name="retScmEpScCntList">SCM企業拠点連結データリスト</param>
		/// <param name="msgDiv">メッセージ区分</param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>ステータス[ConstantManagement.DB_Status]</returns>
		/// <remarks>
		/// <br>Note		: SCM連結先拠点データ検索処理を行います。</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2009.06.02</br>
		/// </remarks>
		public int SearchCnectOtherSec(string cnectOriginalEpCd, string cnectOriginalSecCd, string cnectOtherEpCd, ConstantManagement.LogicalMode cmLogicalMode, out List<ScmEpScCnt> retScmEpScCntList, out bool msgDiv, out string errMsg)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			retScmEpScCntList = new List<ScmEpScCnt>();
			msgDiv = false;
			errMsg = string.Empty;
			try
			{
                // UPD 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                #region 旧ソース
                //ScmEpScCntWork[] scmEpScCntWorks;
                //// SCM連結先企業データ検索処理
                //status = GetSFCMN02564AServices().SearchCnectOtherSec(cnectOriginalEpCd, cnectOriginalSecCd, cnectOtherEpCd, SFCMN02563AC.ConvertLogicalMode(cmLogicalMode), out scmEpScCntWorks, out msgDiv, out errMsg);
                #endregion
                Broadleaf.Application.Remoting.ParamData.ScmEpScCntWork[] scmEpScCntWorks;
                // SCM連結先企業データ検索処理
                CreateIScmEpCnectDB();
                status = _iScmEpCnectDB.SearchCnectOtherSec(cnectOriginalEpCd, cnectOriginalSecCd, cnectOtherEpCd, cmLogicalMode, out scmEpScCntWorks, out msgDiv, out errMsg);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // メンバーコピー
                    foreach (Broadleaf.Application.Remoting.ParamData.ScmEpScCntWork scmEpScCntWork in scmEpScCntWorks)
                    {
                        retScmEpScCntList.Add(SFCMN02563AC.CopyScmEpScCntWorkToScmEpScCnt(scmEpScCntWork));
                    }
                }
                // UPD 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
                        // DEL 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                        #region 旧ソース
                        // メンバーコピー
                        //foreach (ScmEpScCntWork scmEpScCntWork in scmEpScCntWorks)
                        //{
                        //    retScmEpScCntList.Add(SFCMN02563AC.CopyScmEpScCntWorkToScmEpScCnt(scmEpScCntWork));
                        //}
                        #endregion
                        // DEL 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT:
					{
						if (msgDiv)
							_sbErrorMsg.AppendLine(errMsg);
						else
							_sbErrorMsg.AppendLine("SCM連結先拠点データの検索に失敗しました。");
						break;
					}
					default:
					{
						_sbErrorMsg.AppendLine("SCM連結先拠点データの検索に失敗しました。");
						break;
					}
				}
			}
			catch (Exception ex)
			{
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
				_sbErrorMsg.AppendLine("SCM連結先拠点データ検索処理にて例外が発生しました。");
				_sbErrorMsg.AppendLine(ex.Message);
			}

			errMsg = _sbErrorMsg.ToString();
			return status;
        }
        #endregion

        #region SearchSCMSection SCM拠点データ検索処理
        /// <summary>
		/// SCM拠点データ検索処理
		/// </summary>
		/// <param name="cnectOriginalEpCd">連結元企業コード</param>
		/// <param name="cnectOtherEpCd">連結先企業コード</param>
		/// <param name="cmLogicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <param name="retScmEpScCntList">SCM企業拠点連結データリスト</param>
		/// <param name="msgDiv">メッセージ区分</param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>ステータス[ConstantManagement.DB_Status]</returns>
		/// <remarks>
		/// <br>Note		: SCM拠点データ検索処理を行います。</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2009.06.02</br>
		/// </remarks>
		public int SearchSCMSection(string cnectOriginalEpCd, string cnectOtherEpCd, ConstantManagement.LogicalMode cmLogicalMode, out List<ScmEpScCnt> retScmEpScCntList, out bool msgDiv, out string errMsg)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			retScmEpScCntList = new List<ScmEpScCnt>();
			msgDiv = false;
			errMsg = string.Empty;
			try
			{
                // UPD 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                #region 旧ソース
                //ScmEpScCntWork[] scmEpScCntWorks;
                //// SCM連結先企業データ検索処理
                //status = GetSFCMN02564AServices().SearchScmEpScCnt(cnectOriginalEpCd, cnectOtherEpCd, SFCMN02563AC.ConvertLogicalMode(cmLogicalMode), out scmEpScCntWorks, out msgDiv, out errMsg);
                #endregion
                Broadleaf.Application.Remoting.ParamData.ScmEpScCntWork[] scmEpScCntWorks;
                CreateIScmEpCnectDB();
                status = _iScmEpCnectDB.SearchScmEpScCnt(cnectOriginalEpCd, cnectOtherEpCd, cmLogicalMode, out scmEpScCntWorks, out msgDiv, out errMsg);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // メンバーコピー
                    foreach (Broadleaf.Application.Remoting.ParamData.ScmEpScCntWork scmEpScCntWork in scmEpScCntWorks)
                    {
                        retScmEpScCntList.Add(SFCMN02563AC.CopyScmEpScCntWorkToScmEpScCnt(scmEpScCntWork));
                    }
                }
                // UPD 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
                        // DEL 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                        #region 旧ソース
                        //// メンバーコピー
                        //foreach (ScmEpScCntWork scmEpScCntWork in scmEpScCntWorks)
                        //{
                        //    retScmEpScCntList.Add(SFCMN02563AC.CopyScmEpScCntWorkToScmEpScCnt(scmEpScCntWork));
                        //}
                        #endregion
                        // DEL 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT:
					{
						if (msgDiv)
							_sbErrorMsg.AppendLine(errMsg);
						else
							_sbErrorMsg.AppendLine("SCM拠点データの検索に失敗しました。");
						break;
					}
					default:
					{
						_sbErrorMsg.AppendLine("SCM拠点データの検索に失敗しました。");
						break;
					}
				}
			}
			catch (Exception ex)
			{
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
				_sbErrorMsg.AppendLine("SCM拠点データ検索処理にて例外が発生しました。");
				_sbErrorMsg.AppendLine(ex.Message);
			}

			errMsg = _sbErrorMsg.ToString();
			return status;
        }
        #endregion

        #region SearchAll SCM拠点データ検索処理
        /// <summary>
		/// SCM拠点データ検索処理
		/// </summary>
		/// <param name="cnectOriginalEpCd">連結元企業コード</param>
		/// <param name="cnectOriginalSecCd">連結元拠点コード</param>
		/// <param name="cmLogicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
		/// <param name="retScmEpCnectList">SCM企業連結データリスト</param>
		/// <param name="retScmEpScCntList">SCM企業拠点連結データリスト</param>
		/// <param name="msgDiv">メッセージ区分</param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>ステータス[ConstantManagement.DB_Status]</returns>
		/// <remarks>
		/// <br>Note		: SCM企業拠点全件取得処理を行います。</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2009.06.02</br>
		/// </remarks>
		public int SearchAll(string cnectOriginalEpCd, string cnectOriginalSecCd, ConstantManagement.LogicalMode cmLogicalMode, out List<ScmEpCnect> retScmEpCnectList, out List<ScmEpScCnt> retScmEpScCntList, out bool msgDiv, out string errMsg)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			retScmEpCnectList = new List<ScmEpCnect>();
			retScmEpScCntList = new List<ScmEpScCnt>();
			msgDiv = false;
			errMsg = string.Empty;
			try
			{
                // UPD 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                #region 旧ソース
                //ScmEpCnectWork[] scmEpCnectWorks;
                //ScmEpScCntWork[] scmEpScCntWorks;

                //// SCM連結先企業データ検索処理
                //status = GetSFCMN02564AServices().SearchAll(cnectOriginalEpCd, cnectOriginalSecCd, SFCMN02563AC.ConvertLogicalMode(cmLogicalMode), out scmEpCnectWorks, out scmEpScCntWorks, out msgDiv, out errMsg);
                #endregion
                Broadleaf.Application.Remoting.ParamData.ScmEpCnectWork[] scmEpCnectWorks;
                Broadleaf.Application.Remoting.ParamData.ScmEpScCntWork[] scmEpScCntWorks;
                CreateIScmEpCnectDB();
                // SCM連結先企業データ検索処理
                status = _iScmEpCnectDB.SearchAll(cnectOriginalEpCd, cnectOriginalSecCd, cmLogicalMode, out scmEpCnectWorks, out scmEpScCntWorks, out msgDiv, out errMsg);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // メンバーコピー(企業連結)
                    foreach (Broadleaf.Application.Remoting.ParamData.ScmEpCnectWork scmEpCnectWork in scmEpCnectWorks)
                    {
                        retScmEpCnectList.Add(SFCMN02563AC.CopyScmEpCnectWorkToScmEpCnect(scmEpCnectWork));
                    }

                    // メンバーコピー(企業拠点連結)
                    foreach (Broadleaf.Application.Remoting.ParamData.ScmEpScCntWork scmEpScCntWork in scmEpScCntWorks)
                    {
                        retScmEpScCntList.Add(SFCMN02563AC.CopyScmEpScCntWorkToScmEpScCnt(scmEpScCntWork));
                    }
                }
                // UPD 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
                        // DEL 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                        #region 旧ソース
                        //// メンバーコピー(企業連結)
                        //foreach (ScmEpCnectWork scmEpCnectWork in scmEpCnectWorks)
                        //{
                        //    retScmEpCnectList.Add(SFCMN02563AC.CopyScmEpCnectWorkToScmEpCnect(scmEpCnectWork));
                        //}

                        //// メンバーコピー(企業拠点連結)
                        //foreach (ScmEpScCntWork scmEpScCntWork in scmEpScCntWorks)
                        //{
                        //    retScmEpScCntList.Add(SFCMN02563AC.CopyScmEpScCntWorkToScmEpScCnt(scmEpScCntWork));
                        //}
                        #endregion
                        // DEL 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT:
					{
						if (msgDiv)
							_sbErrorMsg.AppendLine(errMsg);
						else
							_sbErrorMsg.AppendLine("SCM拠点データの検索に失敗しました。");
						break;
					}
					default:
					{
						_sbErrorMsg.AppendLine("SCM拠点データの検索に失敗しました。");
						break;
					}
				}
			}
			catch (Exception ex)
			{
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
				_sbErrorMsg.AppendLine("SCM拠点データ検索処理にて例外が発生しました。");
				_sbErrorMsg.AppendLine(ex.Message);
			}

			errMsg = _sbErrorMsg.ToString();
			return status;
        }
        #endregion

        //>>>2011/05/25
        #region SearchCnectOriginalEpFromSc SCM連結先企業拠点データ検索処理
        /// <summary>
        /// SCM連結先企業拠点データ検索処理
        /// </summary>
        /// <param name="cnectOriginalEpCd">連結元企業コード</param>
        /// <param name="cmLogicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="retScmEpScCntList">SCM企業拠点連結データリスト</param>
        /// <param name="msgDiv">メッセージ区分</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>ステータス[ConstantManagement.DB_Status]</returns>
        /// <remarks>
        /// <br>Note		: SCM連結先企業拠点データ検索処理を行います。</br>
        /// <br>Programmer	: 30015 橋本　裕毅</br>
        /// <br>Date		: 2009.06.02</br>
        /// </remarks>
        public int SearchCnectOriginalEpFromSc(string cnectOtherEpCd, ConstantManagement.LogicalMode cmLogicalMode, out List<ScmEpScCnt> retScmEpScCntList, out bool msgDiv, out string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            retScmEpScCntList = new List<ScmEpScCnt>();
            msgDiv = false;
            errMsg = string.Empty;
            try
            {
                // UPD 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                #region 旧ソース
                //ScmEpScCntWork[] scmEpScCntWorks;
                //// SCM連結先企業データ検索処理
                //status = GetSFCMN02564AServices().SearchCnectOriginalEpFromSc(cnectOtherEpCd, SFCMN02563AC.ConvertLogicalMode(cmLogicalMode), out scmEpScCntWorks, out msgDiv, out errMsg);
                #endregion
                Broadleaf.Application.Remoting.ParamData.ScmEpScCntWork[] scmEpScCntWorks;
                // SCM連結先企業データ検索処理
                CreateIScmEpCnectDB();
                status = _iScmEpCnectDB.SearchCnectOriginalEpFromSc(cnectOtherEpCd, cmLogicalMode, out scmEpScCntWorks, out msgDiv, out errMsg);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // メンバーコピー
                    foreach (Broadleaf.Application.Remoting.ParamData.ScmEpScCntWork scmEpScCntWork in scmEpScCntWorks)
                    {
                        retScmEpScCntList.Add(SFCMN02563AC.CopyScmEpScCntWorkToScmEpScCnt(scmEpScCntWork));
                    }
                }
                // UPD 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            // DEL 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                            #region 旧ソース
                            //// メンバーコピー
                            //foreach (ScmEpScCntWork scmEpScCntWork in scmEpScCntWorks)
                            //{
                            //    retScmEpScCntList.Add(SFCMN02563AC.CopyScmEpScCntWorkToScmEpScCnt(scmEpScCntWork));
                            //}
                            #endregion
                            // DEL 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT:
                        {
                            if (msgDiv)
                                _sbErrorMsg.AppendLine(errMsg);
                            else
                                _sbErrorMsg.AppendLine("SCM連結先企業拠点データの検索に失敗しました。");
                            break;
                        }
                    default:
                        {
                            _sbErrorMsg.AppendLine("SCM連結先企業拠点データの検索に失敗しました。");
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                _sbErrorMsg.AppendLine("SCM連結先企業拠点データ検索処理にて例外が発生しました。");
                _sbErrorMsg.AppendLine(ex.Message);
            }

            errMsg = _sbErrorMsg.ToString();
            return status;
        }
        #endregion

        #region SearchCnectOriginalSec SCM連結先拠点データ検索処理
        /// <summary>
        /// SCM連結先拠点データ検索処理
        /// </summary>
        /// <param name="cnectOriginalEpCd">連結元企業コード</param>
        /// <param name="cnectOriginalSecCd">連結元拠点コード</param>
        /// <param name="cnectOtherEpCd">連結先企業コード</param>
        /// <param name="cmLogicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <param name="retScmEpScCntList">SCM企業拠点連結データリスト</param>
        /// <param name="msgDiv">メッセージ区分</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>ステータス[ConstantManagement.DB_Status]</returns>
        /// <remarks>
        /// <br>Note		: SCM連結先拠点データ検索処理を行います。</br>
        /// <br>Programmer	: 30015 橋本　裕毅</br>
        /// <br>Date		: 2009.06.02</br>
        /// </remarks>
        public int SearchCnectOriginalSec(string cnectOriginalEpCd, string cnectOtherEpCd, string cnectOtherSecCd, ConstantManagement.LogicalMode cmLogicalMode, out List<ScmEpScCnt> retScmEpScCntList, out bool msgDiv, out string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            retScmEpScCntList = new List<ScmEpScCnt>();
            msgDiv = false;
            errMsg = string.Empty;
            try
            {
                // UPD 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                #region 旧ソース
                //ScmEpScCntWork[] scmEpScCntWorks;
                //// SCM連結先企業データ検索処理
                //status = GetSFCMN02564AServices().SearchCnectOriginalSec(cnectOriginalEpCd, cnectOtherEpCd, cnectOtherSecCd, SFCMN02563AC.ConvertLogicalMode(cmLogicalMode), out scmEpScCntWorks, out msgDiv, out errMsg);
                #endregion
                Broadleaf.Application.Remoting.ParamData.ScmEpScCntWork[] scmEpScCntWorks;
                // SCM連結先企業データ検索処理
                CreateIScmEpCnectDB();
                status = _iScmEpCnectDB.SearchCnectOriginalSec(cnectOriginalEpCd, cnectOtherEpCd, cnectOtherSecCd, cmLogicalMode, out scmEpScCntWorks, out msgDiv, out errMsg);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // メンバーコピー
                    foreach (Broadleaf.Application.Remoting.ParamData.ScmEpScCntWork scmEpScCntWork in scmEpScCntWorks)
                    {
                        retScmEpScCntList.Add(SFCMN02563AC.CopyScmEpScCntWorkToScmEpScCnt(scmEpScCntWork));
                    }
                }

                // UPD 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            // DEL 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                            #region 旧ソース
                            //// メンバーコピー
                            //foreach (ScmEpScCntWork scmEpScCntWork in scmEpScCntWorks)
                            //{
                            //    retScmEpScCntList.Add(SFCMN02563AC.CopyScmEpScCntWorkToScmEpScCnt(scmEpScCntWork));
                            //}
                            #endregion
                            // DEL 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT:
                        {
                            if (msgDiv)
                                _sbErrorMsg.AppendLine(errMsg);
                            else
                                _sbErrorMsg.AppendLine("SCM連結先拠点データの検索に失敗しました。");
                            break;
                        }
                    default:
                        {
                            _sbErrorMsg.AppendLine("SCM連結先拠点データの検索に失敗しました。");
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                _sbErrorMsg.AppendLine("SCM連結先拠点データ検索処理にて例外が発生しました。");
                _sbErrorMsg.AppendLine(ex.Message);
            }

            errMsg = _sbErrorMsg.ToString();
            return status;
        }
        #endregion
        //<<<2011/05/25

        // 2014.09.10 ins by Ryo. > > > > >
        #region SearchCnectOrgEpFromScWithFTC SCM(PM側から見た)連結先企業拠点データ（＋ユーザーコード等のFTCで必要な情報）検索処理
        /// <summary>
        /// SCM連結先企業拠点データ検索処理
        /// </summary>
        /// <param name="cnectOriginalEpCd">連結元PM企業コード</param>
        /// <param name="cmLogicalMode">論理削除有無(0:正規データのみ, 1:削除データのみ, 2:保留データのみ, 3:完全削除データのみ, 4:全件, 5:正規データ＋削除データ, 6:正規データ＋削除データ＋保留データ)</param>
        /// <param name="retScmEpScCntList">SCM企業拠点連結データリスト</param>
        /// <param name="retOScmBPSCntList">提供側SCM事業場拠点連結データリスト</param>
        /// <param name="retOScmBPCntList">提供側SCM事業場連結データリスト</param>
        /// <param name="msgDiv">メッセージ区分</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>ステータス[ConstantManagement.DB_Status]</returns>
        /// <remarks>
        /// <br>Note		: SCM連結先企業拠点データ検索処理を行います。</br>
        /// <br>Programmer	: Ryo.</br>
        /// <br>Date		: 2014.09.10</br>
        /// </remarks>
        public int SearchCnectOrgEpFromScWithFTC(string cnectOtherEpCd, ConstantManagement.LogicalMode cmLogicalMode,
                                                 out List<ScmEpScCnt> retScmEpScCntList,
                                                 out List<OScmBPSCnt> retOScmBPSCntList,
                                                 out List<OScmBPCnt> retOScmBPCntList,
                                                 out bool msgDiv, out string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            retScmEpScCntList = new List<ScmEpScCnt>();
            retOScmBPSCntList = new List<OScmBPSCnt>();
            retOScmBPCntList = new List<OScmBPCnt>();

            msgDiv = false;
            errMsg = string.Empty;

            try
            {

                Broadleaf.Application.Remoting.ParamData.ScmEpScCntWork[] scmEpScCntWorks;
                Broadleaf.Application.Remoting.ParamData.OScmBPSCntWork[] oScmBPSCntWorks;
                Broadleaf.Application.Remoting.ParamData.OScmBPCntWork[] oScmBPCntWorks;

                // SCM連結先企業データ検索処理
                CreateIScmEpCnectDB();

                status = _iScmEpCnectDB.SearchCnectOrgEpFromScWithFTC(cnectOtherEpCd, cmLogicalMode, out scmEpScCntWorks, out oScmBPSCntWorks, out oScmBPCntWorks, out msgDiv, out errMsg); 

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // メンバーコピー (ScmEpScCntWork)
                    foreach (Broadleaf.Application.Remoting.ParamData.ScmEpScCntWork scmEpScCntWork in scmEpScCntWorks)
                    {
                        retScmEpScCntList.Add(SFCMN02563AC.CopyScmEpScCntWorkToScmEpScCnt(scmEpScCntWork));
                    }

                    // メンバーコピー (OScmBPSCntWork)
                    foreach (Broadleaf.Application.Remoting.ParamData.OScmBPSCntWork oScmBPSCntWork in oScmBPSCntWorks)
                    {
                        retOScmBPSCntList.Add(SFCMN02563AC.CopyOScmBPSCntWorkToOScmBPSCnt(oScmBPSCntWork));
                    }

                    // メンバーコピー (OScmBPCntWork)
                    foreach (Broadleaf.Application.Remoting.ParamData.OScmBPCntWork oScmBPCntWork in oScmBPCntWorks)
                    {
                        retOScmBPCntList.Add(SFCMN02563AC.CopyOScmBPCntWorkToOScmBPCnt(oScmBPCntWork));
                    }

                }
                // 2014.11.18 del by Ryo. -start- > > > > >
                //else if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                //{
                //    if (msgDiv)
                //    {
                //        _sbErrorMsg.AppendLine(errMsg);
                //    }
                //    else
                //    {
                //        _sbErrorMsg.AppendLine("SCM連結先企業拠点データの検索に失敗しました。");
                //    }
                //}
                //else
                //{
                //    _sbErrorMsg.AppendLine("SCM連結先企業拠点データの検索に失敗しました。");
                //}
                // 2014.11.18 del by Ryo. -e n d- < < < < <
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                _sbErrorMsg.AppendLine("SCM連結先企業拠点データ検索処理にて例外が発生しました。");
                _sbErrorMsg.AppendLine(ex.Message);
            }

            errMsg = _sbErrorMsg.ToString();
            return status;
        }
        #endregion

        #region GetSuperFrontmanSectionList 接続先(SuperFrontman)企業の拠点リスト取得
        /// <summary>
        /// 接続先(SuperFrontman)企業の拠点リスト取得
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="retCnectOrgNSSecInfoList">拠点コード・名称リスト</param>
        /// <param name="msgDiv">メッセージ区分</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>ステータス[ConstantManagement.DB_Status]</returns>
        /// <remarks>
        /// <br>Note		: SCM連結先企業拠点データ検索処理を行います。</br>
        /// <br>Programmer	: Ryo.</br>
        /// <br>Date		: 2014.09.10</br>
        /// </remarks>
        public int GetSuperFrontmanSectionList(string enterpriseCode, out List<CnectOrgNSSecInfo> retCnectOrgNSSecInfoList, out bool msgDiv, out string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            retCnectOrgNSSecInfoList = new List<CnectOrgNSSecInfo>();

            msgDiv = false;
            errMsg = string.Empty;

            Broadleaf.Application.Remoting.ParamData.CnectOrgNSSecInfoWork[] cnectOrgNSSecInfoWorks;

            try
            {
                // インスタンスが無かったら作る
                CreateIScmEpCnectDB();

                status = _iScmEpCnectDB.GetSuperFrontmanSectionList(enterpriseCode, out cnectOrgNSSecInfoWorks, out msgDiv, out errMsg);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // メンバーコピー (ScmEpScCntWork)
                    foreach (Broadleaf.Application.Remoting.ParamData.CnectOrgNSSecInfoWork cnectOrgNSSecInfoWork in cnectOrgNSSecInfoWorks)
                    {
                        retCnectOrgNSSecInfoList.Add(SFCMN02563AC.CopyCnectOrgNSSecInfoWorkToCnectOrgNSSecInfo(cnectOrgNSSecInfoWork));
                    }
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                {
                    if (msgDiv)
                    {
                        _sbErrorMsg.AppendLine(errMsg);
                    }
                    else
                    {
                        _sbErrorMsg.AppendLine("接続先(SuperFrontman)企業の拠点リスト取得に失敗しました。");
                    }
                }
                else
                {
                    _sbErrorMsg.AppendLine("接続先(SuperFrontman)企業の拠点リスト取得に失敗しました。");
                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                _sbErrorMsg.AppendLine("接続先(SuperFrontman)企業の拠点リスト取得処理にて例外が発生しました。");
                _sbErrorMsg.AppendLine(ex.Message);
            }

            errMsg = _sbErrorMsg.ToString();
            return status;
        }
        #endregion
        // 2014.09.10 ins by Ryo. < < < < <
		#endregion

		#region Write
        #region WriteScmEpScCnt SCM企業拠点連結データ登録・更新処理
        /// <summary>
		/// SCM企業拠点連結データ登録・更新処理
		/// </summary>
		/// <param name="scmEpScCnts">SCM企業拠点連結データクラス配列</param>
		/// <param name="msgDiv">メッセージ区分</param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>ステータス[ConstantManagement.DB_Status]</returns>
		/// <remarks>
		/// <br>Note		: SCM企業拠点連結データの登録・更新処理を行います。</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2009.06.02</br>
		/// </remarks>
		public int WriteScmEpScCnt(ref ScmEpScCnt[] scmEpScCnts, out bool msgDiv, out string errMsg)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			msgDiv = false;
			errMsg = string.Empty;
			try
			{
                // UPD 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                # region 旧ソース
                //ScmEpScCntWork[] scmEpScCntWorks = new ScmEpScCntWork[scmEpScCnts.Length];
                //// メンバーコピー
                //for(int ix = 0; ix != scmEpScCnts.Length; ix++)
                //{
                //    scmEpScCntWorks[ix] = SFCMN02563AC.CopyScmEpScCntToScmEpScCntWork(scmEpScCnts[ix]);
                //}
                //// SCM連結先企業データ検索処理
                //status = GetSFCMN02564AServices().WriteScmEpScCnt(ref scmEpScCntWorks, out msgDiv, out errMsg);
                #endregion
                Broadleaf.Application.Remoting.ParamData.ScmEpScCntWork[] scmEpScCntWorks = new Broadleaf.Application.Remoting.ParamData.ScmEpScCntWork[scmEpScCnts.Length];
                // メンバーコピー
                for (int ix = 0; ix != scmEpScCnts.Length; ix++)
                {
                    scmEpScCntWorks[ix] = SFCMN02563AC.CopyScmEpScCntToScmEpScCntWork2(scmEpScCnts[ix]);
                }
                CreateIScmEpCnectDB();
                // SCM連結先企業データ検索処理
                status = _iScmEpCnectDB.WriteScmEpScCnt(ref scmEpScCntWorks, out msgDiv, out errMsg);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // メンバーコピー
                    for (int iy = 0; iy != scmEpScCntWorks.Length; iy++)
                    {
                        scmEpScCnts[iy] = SFCMN02563AC.CopyScmEpScCntWorkToScmEpScCnt(scmEpScCntWorks[iy]);
                    }
                }

                // UPD 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
                        // DEL 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                        #region 旧ソース
                        //// メンバーコピー
                        //for (int iy = 0; iy != scmEpScCntWorks.Length; iy++)
                        //{
                        //    scmEpScCnts[iy] = SFCMN02563AC.CopyScmEpScCntWorkToScmEpScCnt(scmEpScCntWorks[iy]);
                        //}
                        #endregion
                        // DEL 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT:
					{
						if (msgDiv)
							_sbErrorMsg.AppendLine(errMsg);
						else
							_sbErrorMsg.AppendLine("SCM企業拠点連結データの登録・更新に失敗しました。");
						break;
					}
					default:
					{
						_sbErrorMsg.AppendLine("SCM企業拠点連結データの登録・更新に失敗しました。");
						break;
					}
				}
			}
			catch (Exception ex)
			{
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
				_sbErrorMsg.AppendLine("SCM企業拠点連結データ登録・更新処理にて例外が発生しました。");
				_sbErrorMsg.AppendLine(ex.Message);
			}

			errMsg = _sbErrorMsg.ToString();
			return status;
		}
		#endregion

        // 2014.09.10 ins by Ryo. -start- > > > > >
        #region WriteScmEpScCntWithFTC SCM企業拠点連結データ/提供側SCM事業場拠点連結データ/提供側SCM事業場連結データ 登録・更新処理
        /// <summary>
        /// SCM企業拠点連結データ/提供側SCM事業場拠点連結データ/提供側SCM事業場連結データ 登録・更新処理
        /// </summary>
        /// <param name="scmEpScCnt">SCM企業拠点連結データクラス配列</param>
        /// <param name="oScmBPSCnt">提供側SCM事業場拠点連結データクラス配列</param>
        /// <param name="oScmBPCnt">提供側SCM事業場連結データクラス配列</param>
        /// <param name="msgDiv">メッセージ区分</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>ステータス[ConstantManagement.DB_Status]</returns>
        /// <remarks>
        /// <br>Note		: SCM企業拠点連結データ/提供側SCM事業場拠点連結データ/提供側SCM事業場連結データの登録・更新処理を行います。</br>
        /// <br>Programmer	: Ryo.</br>
        /// <br>Date		: 2014.09.10</br>
        /// </remarks>
        public int WriteScmEpScCntWithFTC(ref ScmEpScCnt scmEpScCnt, ref OScmBPSCnt oScmBPSCnt, ref OScmBPCnt oScmBPCnt, out bool msgDiv, out string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            msgDiv = false;
            errMsg = string.Empty;

            try
            {
                Broadleaf.Application.Remoting.ParamData.ScmEpScCntWork scmEpScCntWork = new Broadleaf.Application.Remoting.ParamData.ScmEpScCntWork();
                Broadleaf.Application.Remoting.ParamData.OScmBPSCntWork oScmBPSCntWork = new Broadleaf.Application.Remoting.ParamData.OScmBPSCntWork();
                Broadleaf.Application.Remoting.ParamData.OScmBPCntWork  oScmBPCntWork  = new Broadleaf.Application.Remoting.ParamData.OScmBPCntWork();

                // メンバーコピー
                scmEpScCntWork = SFCMN02563AC.CopyScmEpScCntToScmEpScCntWork2(scmEpScCnt);
                oScmBPSCntWork = SFCMN02563AC.CopyOScmBPSCntToOScmBPSCntWork(oScmBPSCnt);
                oScmBPCntWork  = SFCMN02563AC.CopyOScmBPCntToOScmBPCntWork(oScmBPCnt);

                CreateIScmEpCnectDB();
                
                // SCM連結先企業データ検索処理
                status = _iScmEpCnectDB.WriteScmEpScCntWithFTC(ref scmEpScCntWork, ref oScmBPSCntWork, ref oScmBPCntWork, out msgDiv, out errMsg);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // メンバーコピー
                    scmEpScCnt = SFCMN02563AC.CopyScmEpScCntWorkToScmEpScCnt(scmEpScCntWork);
                    oScmBPSCnt = SFCMN02563AC.CopyOScmBPSCntWorkToOScmBPSCnt(oScmBPSCntWork);
                    oScmBPCnt  = SFCMN02563AC.CopyOScmBPCntWorkToOScmBPCnt(oScmBPCntWork);

                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                {
                    if (msgDiv)
                    {
                        _sbErrorMsg.AppendLine(errMsg);
                    }
                    else
                    {
                        _sbErrorMsg.AppendLine("SCM企業拠点連結データの登録・更新に失敗しました。");
                    }
                }
                else
                {
                    _sbErrorMsg.AppendLine("SCM企業拠点連結データの登録・更新に失敗しました。");
                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                _sbErrorMsg.AppendLine("SCM企業拠点連結データ登録・更新処理にて例外が発生しました。");
                _sbErrorMsg.AppendLine(ex.Message);
            }

            errMsg = _sbErrorMsg.ToString();
            return status;
        }
        #endregion
        // 2014.09.11 ins by Ryo. -e n d- < < < < <

        #endregion

        #region LogicalDelete
        /// <summary>
		/// SCM企業拠点連結データ論理削除処理
		/// </summary>
		/// <param name="scmEpScCnts">SCM企業拠点連結データクラス配列</param>
		/// <param name="msgDiv">メッセージ区分</param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>ステータス[ConstantManagement.DB_Status]</returns>
		/// <remarks>
		/// <br>Note		: SCM企業拠点連結データの論理削除処理を行います。</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2009.06.02</br>
		/// </remarks>
		public int LogicalDeleteScmEpScCnt(ref ScmEpScCnt[] scmEpScCnts, out bool msgDiv, out string errMsg)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			msgDiv = false;
			errMsg = string.Empty;
			try
			{
                // UPD 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                #region 旧ソース
                //ScmEpScCntWork[] scmEpScCntWorks = new ScmEpScCntWork[scmEpScCnts.Length];
                //// メンバーコピー
                //for (int ix = 0; ix != scmEpScCnts.Length; ix++)
                //{
                //    scmEpScCntWorks[ix] = SFCMN02563AC.CopyScmEpScCntToScmEpScCntWork(scmEpScCnts[ix]);
                //}

                //// SCM企業拠点連結データ論理削除処理
                //status = GetSFCMN02564AServices().LogicalDeleteScmEpScCnt(ref scmEpScCntWorks, out msgDiv, out errMsg);
                #endregion
                Broadleaf.Application.Remoting.ParamData.ScmEpScCntWork[] scmEpScCntWorks = new Broadleaf.Application.Remoting.ParamData.ScmEpScCntWork[scmEpScCnts.Length];
                // メンバーコピー
                for (int ix = 0; ix != scmEpScCnts.Length; ix++)
                {
                    scmEpScCntWorks[ix] = SFCMN02563AC.CopyScmEpScCntToScmEpScCntWork2(scmEpScCnts[ix]);
                }
                CreateIScmEpCnectDB();
                // SCM企業拠点連結データ論理削除処理
                status = _iScmEpCnectDB.LogicalDeleteScmEpScCnt(ref scmEpScCntWorks, out msgDiv, out errMsg);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // メンバーコピー
                    for (int iy = 0; iy != scmEpScCntWorks.Length; iy++)
                    {
                        scmEpScCnts[iy] = SFCMN02563AC.CopyScmEpScCntWorkToScmEpScCnt(scmEpScCntWorks[iy]);
                    }
                }
                // UPD 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
                        // DEL 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                        #region 旧ソース
                        //// メンバーコピー
                        //for (int iy = 0; iy != scmEpScCntWorks.Length; iy++)
                        //{
                        //    scmEpScCnts[iy] = SFCMN02563AC.CopyScmEpScCntWorkToScmEpScCnt(scmEpScCntWorks[iy]);
                        //}
                        #endregion
                        // DEL 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT:
					{
						if (msgDiv)
							_sbErrorMsg.AppendLine(errMsg);
						else
							_sbErrorMsg.AppendLine("SCM企業拠点連結データの論理削除に失敗しました。");
						break;
					}
					default:
					{
						_sbErrorMsg.AppendLine("SCM企業拠点連結データの論理削除に失敗しました。");
						break;
					}
				}
			}
			catch (Exception ex)
			{
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
				_sbErrorMsg.AppendLine("SCM企業拠点連結データ論理削除処理にて例外が発生しました。");
				_sbErrorMsg.AppendLine(ex.Message);
			}

			errMsg = _sbErrorMsg.ToString();
			return status;
		}
		#endregion

		#region Delete
		/// <summary>
		/// SCM企業拠点連結データ物理削除処理
		/// </summary>
		/// <param name="scmEpScCnt">SCM企業拠点連結データクラス配列</param>
		/// <param name="msgDiv">メッセージ区分</param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>ステータス[ConstantManagement.DB_Status]</returns>
		/// <remarks>
		/// <br>Note		: SCM企業拠点連結データの物理削除処理を行います。</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2009.06.02</br>
		/// </remarks>
		public int DeleteScmEpScCnt(ScmEpScCnt scmEpScCnt, out bool msgDiv, out string errMsg)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			msgDiv = false;
			errMsg = string.Empty;
			try
			{
                // UPD 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                #region 旧ソース
                //// メンバーコピー
                //ScmEpScCntWork scmEpScCntWork = SFCMN02563AC.CopyScmEpScCntToScmEpScCntWork(scmEpScCnt);

                //// SCM連結先企業データ検索処理
                //status = GetSFCMN02564AServices().DeleteScmEpScCnt(scmEpScCntWork, out msgDiv, out errMsg);
                // メンバーコピー
                Broadleaf.Application.Remoting.ParamData.ScmEpScCntWork scmEpScCntWork = SFCMN02563AC.CopyScmEpScCntToScmEpScCntWork2(scmEpScCnt);
                CreateIScmEpCnectDB();
                // SCM連結先企業データ検索処理
                status = _iScmEpCnectDB.DeleteScmEpScCnt(scmEpScCntWork, out msgDiv, out errMsg);
                #endregion
                // UPD 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

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
							_sbErrorMsg.AppendLine("SCM企業拠点連結データの物理削除に失敗しました。");
						break;
					}
					default:
					{
						_sbErrorMsg.AppendLine("SCM企業拠点連結データの物理削除に失敗しました。");
						break;
					}
				}
			}
			catch (Exception ex)
			{
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
				_sbErrorMsg.AppendLine("SCM企業拠点連結データ物理削除処理にて例外が発生しました。");
				_sbErrorMsg.AppendLine(ex.Message);
			}

			errMsg = _sbErrorMsg.ToString();
			return status;
		}
		#endregion

		#region Revival
		/// <summary>
		/// SCM企業拠点連結データ論理削除復活処理
		/// </summary>
		/// <param name="scmEpScCnts">SCM企業拠点連結データクラス配列</param>
		/// <param name="msgDiv">メッセージ区分</param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>ステータス[ConstantManagement.DB_Status]</returns>
		/// <remarks>
		/// <br>Note		: SCM企業拠点連結データの論理削除復活処理を行います。</br>
		/// <br>Programmer	: 30015 橋本　裕毅</br>
		/// <br>Date		: 2009.06.02</br>
		/// </remarks>
		public int RevivalScmEpScCnt(ref ScmEpScCnt[] scmEpScCnts, out bool msgDiv, out string errMsg)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			msgDiv = false;
			errMsg = string.Empty;
			try
			{
                // UPD 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                #region 旧ソース
                //ScmEpScCntWork[] scmEpScCntWorks = new ScmEpScCntWork[scmEpScCnts.Length];
                //// メンバーコピー
                //for (int ix = 0; ix != scmEpScCnts.Length; ix++)
                //{
                //    scmEpScCntWorks[ix] = SFCMN02563AC.CopyScmEpScCntToScmEpScCntWork(scmEpScCnts[ix]);
                //}

                //// SCM連結先企業データ検索処理
                //status = GetSFCMN02564AServices().RevivalScmEpScCnt(ref scmEpScCntWorks, out msgDiv, out errMsg);
                Broadleaf.Application.Remoting.ParamData.ScmEpScCntWork[] scmEpScCntWorks = new Broadleaf.Application.Remoting.ParamData.ScmEpScCntWork[scmEpScCnts.Length];
                // メンバーコピー
                for (int ix = 0; ix != scmEpScCnts.Length; ix++)
                {
                    scmEpScCntWorks[ix] = SFCMN02563AC.CopyScmEpScCntToScmEpScCntWork2(scmEpScCnts[ix]);
                }
                CreateIScmEpCnectDB();
                // SCM連結先企業データ検索処理
                status = _iScmEpCnectDB.RevivalScmEpScCnt(ref scmEpScCntWorks, out msgDiv, out errMsg);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // メンバーコピー
                    for (int iy = 0; iy != scmEpScCntWorks.Length; iy++)
                    {
                        scmEpScCnts[iy] = SFCMN02563AC.CopyScmEpScCntWorkToScmEpScCnt(scmEpScCntWorks[iy]);
                    }
                }
                #endregion
                // UPD 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
                        // DEL 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                        #region 旧ソース
                        //// メンバーコピー
                        //for (int iy = 0; iy != scmEpScCntWorks.Length; iy++)
                        //{
                        //    scmEpScCnts[iy] = SFCMN02563AC.CopyScmEpScCntWorkToScmEpScCnt(scmEpScCntWorks[iy]);
                        //}
                        #endregion
                        // DEL 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT:
					{
						if (msgDiv)
							_sbErrorMsg.AppendLine(errMsg);
						else
							_sbErrorMsg.AppendLine("SCM企業拠点連結データの論理削除復活に失敗しました。");
						break;
					}
					default:
					{
						_sbErrorMsg.AppendLine("SCM企業拠点連結データの論理削除復活に失敗しました。");
						break;
					}
				}
			}
			catch (Exception ex)
			{
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
				_sbErrorMsg.AppendLine("SCM企業拠点連結データ論理削除復活処理にて例外が発生しました。");
				_sbErrorMsg.AppendLine(ex.Message);
			}

			errMsg = _sbErrorMsg.ToString();
			return status;
		}
		#endregion
		#endregion

		#region ▼ガイド起動処理
		// SCM企業連結クラスリスト
		private static List<ScmEpCnect>	_scmEpCnectList;
		// SCM企業拠点連結クラスリスト
		private static List<ScmEpScCnt>	_scmEpScCntList;

		/// <summary>
		/// staticデータセット処理
		/// </summary>
		/// <param name="scmEpCnectList">SCM企業連結クラスリスト</param>
		/// <param name="scmEpScCntList">SCM企業拠点連結クラスリスト</param>
		/// <remarks>
		/// <br>Note		: static領域にデータをセットします。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2009.06.23</br>
		/// </remarks>
		public static void SetStaticData(List<ScmEpCnect> scmEpCnectList, List<ScmEpScCnt> scmEpScCntList)
		{
			_scmEpCnectList = scmEpCnectList;
			_scmEpScCntList = scmEpScCntList;
		}

		/// <summary>
		/// SCM企業拠点連結ガイド起動処理
		/// </summary>
		/// <param name="cnectOriginalEpCd">連結元企業コード</param>
		/// <param name="cnectOriginalSecCd">連結元拠点コード</param>
		/// <param name="discDivCd">識別区分[-1:条件指定無し,0:連結有効のみ,1:連結無効のみ]</param>
		/// <param name="scmEpCnect">SCM企業連結クラス</param>
		/// <param name="scmEpScCnt">SCM企業拠点連結クラス</param>
		/// <returns>STATUS[0:取得成功,1:キャンセル]</returns>
		/// <remarks>
		/// <br>Note		: SCM企業拠点連結ガイドを起動します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2009.06.23</br>
		/// </remarks>
		public int ExecuteGuid(string cnectOriginalEpCd, string cnectOriginalSecCd, int discDivCd, out ScmEpCnect scmEpCnect, out ScmEpScCnt scmEpScCnt)
		{
			int status = 1;

			scmEpCnect = new ScmEpCnect();
			scmEpScCnt = new ScmEpScCnt();

			TableGuideParent tableGuideParent = new TableGuideParent("SCMEPSCCNTGUIDEPARENT.XML");
			Hashtable inObj = new Hashtable();
			Hashtable retObj = new Hashtable();

			// 連結元企業コード
			inObj.Add("CnectOriginalEpCd", cnectOriginalEpCd);
			// 連結元拠点コード
			inObj.Add("CnectOriginalSecCd", cnectOriginalSecCd);
			// 識別区分
			inObj.Add("DiscDivCd", discDivCd);

			if (tableGuideParent.Execute(0, inObj, ref retObj))
			{
				scmEpCnect.CnectOtherEpCd		= retObj["CnectOtherEpCd"].ToString();
				scmEpCnect.CnectOtherEpNm		= retObj["CnectOtherEpNm"].ToString();

				scmEpScCnt.CnectOtherEpCd		= retObj["CnectOtherEpCd"].ToString();
				scmEpScCnt.CnectOtherSecCd		= retObj["CnectOtherSecCd"].ToString();
				scmEpScCnt.CnectOtherSecNm		= retObj["CnectOtherSecNm"].ToString();

				status = 0;
			}
			else
			{
				status = 1;
			}

			return status;
		}
		# endregion

		#region ▼IGeneralGuidData Method
		/// <summary>
		/// 汎用ガイドデータ取得(IGeneralGuidDataインターフェース実装)
		/// </summary>
		/// <param name="mode">モード</param>
		/// <param name="inParm">検索パラメータ</param>
		/// <param name="guideList">取得結果</param>
		/// <returns>STATUS[0:取得成功,-1:キャンセル,4:レコード無し]</returns>
		/// <remarks>
		/// <br>Note		: 汎用ガイド設定用データを取得します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2009.06.23</br>
		/// </remarks>
		public int GetGuideData(int mode, Hashtable inParm, ref System.Data.DataSet guideList)
		{
			int status = -1;
			string cnectOriginalEpCd	= string.Empty;
			string cnectOriginalSecCd	= string.Empty;
			int discDivCd = 0;

			// 連結元企業コード設定有り
			if (inParm.ContainsKey("CnectOriginalEpCd"))
				cnectOriginalEpCd = inParm["CnectOriginalEpCd"].ToString();
			else
				return status;

			// 連結元拠点コード設定有り
			if (inParm.ContainsKey("CnectOriginalSecCd"))
				cnectOriginalSecCd = inParm["CnectOriginalSecCd"].ToString();
			else
				return status;

			// 識別区分[0:連結有効,1:連結無効]
			if (inParm.ContainsKey("DiscDivCd"))
				int.TryParse(inParm["DiscDivCd"].ToString(), out discDivCd);
			else
				return status;

			if (_scmEpCnectList == null || _scmEpCnectList.Count == 0 ||
				_scmEpScCntList == null || _scmEpScCntList.Count == 0)
			{
				List<ScmEpCnect> scmEpCnectList;
				List<ScmEpScCnt> scmEpScCntList;
				bool msgDiv;
				string errMsg;
				status = SearchAll(cnectOriginalEpCd, cnectOriginalSecCd, ConstantManagement.LogicalMode.GetData0, out scmEpCnectList, out scmEpScCntList, out msgDiv, out errMsg);
				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						_scmEpCnectList = scmEpCnectList;
						_scmEpScCntList = scmEpScCntList;
						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_EOF:
					{
						status = 4;
						break;
					}
				}
			}
			else
			{
				status = 0;
			}

			if (status == 0)
			{
				System.Data.DataTable dt = guideList.Tables.Add();
				dt.Columns.Add("CnectOriginalEpCd",		typeof(string));
				dt.Columns.Add("CnectOriginalSecCd",	typeof(string));
				dt.Columns.Add("CnectOtherEpCd",		typeof(string));
				dt.Columns.Add("CnectOtherEpNm",		typeof(string));
				dt.Columns.Add("CnectOtherSecCd",		typeof(string));
				dt.Columns.Add("CnectOtherSecNm",		typeof(string));

				List<ScmEpCnect> scmEpCnectList;
				List<ScmEpScCnt> scmEpScCntList;
				if (discDivCd == 0 || discDivCd == 1)
				{
					// 識別区分でフィルタ
					scmEpCnectList = _scmEpCnectList.FindAll(
						delegate(ScmEpCnect scmEpCnect) { if (scmEpCnect.DiscDivCd == discDivCd) return true; else return false; }
					);

					// 識別区分でフィルタ
					scmEpScCntList = _scmEpScCntList.FindAll(
						delegate(ScmEpScCnt scmEpScCnt) { if (scmEpScCnt.DiscDivCd == discDivCd) return true; else return false; }
					);
				}
				else
				{
					scmEpCnectList = _scmEpCnectList;
					scmEpScCntList = _scmEpScCntList;
				}

				// データをセット
				foreach (ScmEpScCnt scmEpScCnt in scmEpScCntList)
				{
					ScmEpCnect scmEpCnect
						= scmEpCnectList.Find(
							delegate(ScmEpCnect wkScmEpCnect)
							{
								if (wkScmEpCnect.CnectOriginalEpCd == scmEpScCnt.CnectOriginalEpCd &&
									wkScmEpCnect.CnectOtherEpCd == scmEpScCnt.CnectOtherEpCd)
									return true;
								else
									return false;
							}
						);

					if (scmEpCnect != null && scmEpScCnt.CnectOriginalSecCd == cnectOriginalSecCd)
					{
						System.Data.DataRow dr = dt.NewRow();
						dr["CnectOriginalEpCd"]		= scmEpCnect.CnectOriginalEpCd;
						dr["CnectOriginalSecCd"]	= scmEpScCnt.CnectOriginalSecCd;
						dr["CnectOtherEpCd"]		= scmEpCnect.CnectOtherEpCd;
						dr["CnectOtherEpNm"]		= scmEpCnect.CnectOtherEpNm;
						dr["CnectOtherSecCd"]		= scmEpScCnt.CnectOtherSecCd;
						dr["CnectOtherSecNm"]		= scmEpScCnt.CnectOtherSecNm;
						dt.Rows.Add(dr);
					}
				}

				if (dt.Rows.Count == 0)
					status = 4;
			}

			return status;
		}
		#endregion

        // ADD 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 生成処理
        /// </summary>
        private void CreateIScmEpCnectDB()
        {
            if (_iScmEpCnectDB == null)
            {
                _iScmEpCnectDB = MediationGetScmEpCnectDB.GetScmEpCnectDB();
            }
        }
        // ADD 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        // ADD 2014/12/19 SCM高速化 PMNS対応 鹿庭  -------------->>>>>>>>>>>>>>>>>>
        #region サーバーIDアップロード済み区分更新(UpdatePMDBStatus)
        /// <summary>
        /// サーバーIDアップロード済み区分を更新します
        /// </summary>
        /// <param name="cnectOtherEpCd">連結先企業コード</param>
        /// <param name="cnectOtherSecCd">連結先拠点コードリスト</param>
        /// <param name="pmDBId">PMデータベースID</param>
        /// <param name="pmUploadDiv">PMアップロード区分 0:アップロードなし,1:アップロード済み</param>
        /// <param name="msgDiv">メッセージ区分</param>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        public int UpdatePMDBStatus(string cnectOtherEpCd, string cnectOtherSecCd, string pmDBId, int pmUploadDiv, out bool msgDiv, out string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            msgDiv = false;
            errMsg = string.Empty;
            try
            {
                CreateIScmEpCnectDB();

                // サーバーIDアップロード済み区分更新
                status = _iScmEpCnectDB.UpdatePMDBStatus(cnectOtherEpCd, cnectOtherSecCd, pmDBId, pmUploadDiv, 0, out msgDiv, out errMsg);

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
                                _sbErrorMsg.AppendLine("サーバーIDアップロード済み区分更新に失敗しました。");
                            break;
                        }
                    default:
                        {
                            _sbErrorMsg.AppendLine("サーバーIDアップロード済み区分更新に失敗しました。");
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                _sbErrorMsg.AppendLine("サーバーIDアップロード済み区分更新処理にて例外が発生しました。");
                _sbErrorMsg.AppendLine(ex.Message);
            }

            errMsg = _sbErrorMsg.ToString();

            if (!string.IsNullOrEmpty(errMsg)) msgDiv = true;

            return status;
        }
        #endregion
        // ADD 2014/12/19 SCM高速化 PMNS対応 鹿庭  --------------<<<<<<<<<<<<<<<<<<
    }
}

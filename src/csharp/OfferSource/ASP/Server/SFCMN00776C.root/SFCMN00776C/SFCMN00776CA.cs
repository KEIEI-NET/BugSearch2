using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Control;

namespace Broadleaf.Application.Common
{
	/// <summary>
	/// 変更PG案内検索部品
	/// </summary>
	/// <remarks>
	/// <br/>Note       : 変更案内サービス用  検索部品です。
	/// <br/>Programer  : 21027 須川  程志郎
	/// <br/>Date       : 2007.03.05
	/// <br/>
	/// <br/>UpdataNote : 2007.12.10  Kouguchi  新レイアウト対応
	/// </remarks>
	public class ChangeInfoSearchManager
	{
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public ChangeInfoSearchManager()
		{

		}

		// ロール取得用バージョン定数
		private const string ctCODE_GenerationCode = "2.0";


		#region Public Methods

        #region Del  2007.12.10  Kouguchi
        //#region ReadSvrMntInfo
        ///// <summary>
        ///// サーバーメンテナンス情報取得処理<br/>
        ///// アクセスチケットを指定して、ロール情報の自動設定を行います。
        ///// </summary>
        ///// <param name="ticket">アクセスチケット</param>
        ///// <param name="serverMainteConsNo">サーバーメンテナンス連番</param>
        ///// <param name="readData">取得データ</param>
        ///// <param name="errMsg">エラーメッセージ</param>
        ///// <returns>
        ///// 処理ステータス
        ///// <list type="bullet">
        ///// <item><description>0:正常終了</description></item>
        ///// <item><description>-99:ロール情報取得失敗</description></item>
        ///// <item><description>他:アクセスクラス処理ステータス</description></item>
        ///// </list>
        ///// </returns>
        //public int ReadSvrMntInfo(string ticket, int serverMainteConsNo, out SvrMntInfoWork readData, out string errMsg)
        //{
        //    // 読込み用パラメータ作成
        //    SvrMntInfoWork readParam = new SvrMntInfoWork();
        //    readParam.ServerMainteConsNo = serverMainteConsNo;

        //    // 読込み処理
        //    return this.ReadSvrMntInfoProc(ticket, true, readParam, out readData, out errMsg);
        //}
        //#endregion

        //#region ReadSvrMntInfoNoTicket
        ///// <summary>
        ///// サーバーメンテナンス情報取得処理
        ///// </summary>
        ///// <param name="productCode">パッケージ区分</param>
        ///// <param name="serverMainteConsNo">サーバーメンテナンス連番</param>
        ///// <param name="readData">取得データ</param>
        ///// <param name="errMsg">エラーメッセージ</param>
        ///// <returns>
        ///// 処理ステータス
        ///// <list type="bullet">
        ///// <item><description>0:正常終了</description></item>
        ///// <item><description>-99:ロール情報取得失敗</description></item>
        ///// <item><description>他:アクセスクラス処理ステータス</description></item>
        ///// </list>
        ///// </returns>
        //public int ReadSvrMntInfoNoTicket(string productCode, int serverMainteConsNo, out SvrMntInfoWork readData, out string errMsg)
        //{
        //    // 読込み用パラメータ作成
        //    SvrMntInfoWork readParam = new SvrMntInfoWork();
        //    readParam.ProductCode = productCode;
        //    readParam.ServerMainteConsNo = serverMainteConsNo;

        //    // 読込み処理
        //    return this.ReadSvrMntInfoProc(null, false, readParam, out readData, out errMsg);
        //}
        //#endregion

        //#region SearchSvrMntInfo
        ///// <summary>
        ///// サーバーメンテナンス情報検索処理<br/>
        ///// 指定されたサーバーメンテナンス区分の全レコードを取得します。<br/>
        ///// アクセスチケットを指定して、ロール情報の自動設定を行います。
        ///// </summary>
        ///// <param name="ticket">アクセスチケット</param>
        ///// <param name="serverMainteDivCd">サーバーメンテナンス区分[1:定期メンテナンス, 9:緊急メンテナンス, -1:両方]</param>
        ///// <param name="searchData">検索結果データ</param>
        ///// <param name="errMsg">エラーメッセージ</param>
        ///// <returns>
        ///// 処理ステータス
        ///// <list type="bullet">
        ///// <item><description>0:正常終了</description></item>
        ///// <item><description>-99:ロール情報取得失敗</description></item>
        ///// <item><description>他:アクセスクラス処理ステータス</description></item>
        ///// </list>
        ///// </returns>
        //public int SearchSvrMntInfo(string ticket, int serverMainteDivCd, out List<SvrMntInfoWork> searchData, out string errMsg)
        //{
        //    int totalCount = 0;

        //    // 検索用パラメータ作成
        //    SvrMntInfoWork searchParam = new SvrMntInfoWork();
        //    searchParam.ServerMainteDivCd = serverMainteDivCd;

        //    // 検索処理(件数指定無し)
        //    return this.SearchSvrMntInfoProc(ticket, true, searchParam, 0, 0, out totalCount, out searchData, out errMsg);
        //}
        //#endregion

        //#region SearchSvrMntInfoNoTicket
        ///// <summary>
        ///// サーバーメンテナンス情報検索処理<br/>
        ///// 指定されたサーバーメンテナンス区分の全レコードを取得します。
        ///// </summary>
        ///// <param name="productCode">パッケージ区分</param>
        ///// <param name="serverMainteDivCd">サーバーメンテナンス区分[1:定期メンテナンス, 9:緊急メンテナンス, -1:両方]</param>
        ///// <param name="searchData">検索結果データ</param>
        ///// <param name="errMsg">エラーメッセージ</param>
        ///// <returns>
        ///// 処理ステータス
        ///// <list type="bullet">
        ///// <item><description>0:正常終了</description></item>
        ///// <item><description>-99:ロール情報取得失敗</description></item>
        ///// <item><description>他:アクセスクラス処理ステータス</description></item>
        ///// </list>
        ///// </returns>
        //public int SearchSvrMntInfoNoTicket(string productCode, int serverMainteDivCd, out List<SvrMntInfoWork> searchData, out string errMsg)
        //{
        //    int totalCount = 0;

        //    // 検索用パラメータ作成
        //    SvrMntInfoWork searchParam = new SvrMntInfoWork();
        //    searchParam.ProductCode = productCode;
        //    searchParam.ServerMainteDivCd = serverMainteDivCd;

        //    // 検索処理(件数指定無し)
        //    return this.SearchSvrMntInfoProc(null, false, searchParam, 0, 0, out totalCount, out searchData, out errMsg);
        //}
        //#endregion

        //#region SearchSvrMntInfo
        ///// <summary>
        ///// サーバーメンテナンス情報検索処理<br/>
        ///// 指定されたサーバーメンテナンス区分のレコードを件数指定で取得します。<br/>
        ///// アクセスチケットを指定して、ロール情報の自動設定を行います。
        ///// </summary>
        ///// <param name="ticket">アクセスチケット</param>
        ///// <param name="serverMainteDivCd">サーバーメンテナンス区分[1:定期メンテナンス, 9:緊急メンテナンス, -1:両方]</param>
        ///// <param name="startIndex">検索開始インデックス</param>
        ///// <param name="searchCount">検索件数</param>
        ///// <param name="totalCount">検索結果最大件数</param>
        ///// <param name="searchData">検索結果データ</param>
        ///// <param name="errMsg">エラーメッセージ</param>
        ///// <returns>
        ///// 処理ステータス
        ///// <list type="bullet">
        ///// <item><description>0:正常終了</description></item>
        ///// <item><description>-99:ロール情報取得失敗</description></item>
        ///// <item><description>他:アクセスクラス処理ステータス</description></item>
        ///// </list>
        ///// </returns>
        //public int SearchSvrMntInfo(string ticket, int serverMainteDivCd, int startIndex, int searchCount, out int totalCount, out List<SvrMntInfoWork> searchData, out string errMsg)
        //{
        //    // 検索用パラメータ作成
        //    SvrMntInfoWork searchParam = new SvrMntInfoWork();
        //    searchParam.ServerMainteDivCd = serverMainteDivCd;

        //    // 検索処理
        //    return this.SearchSvrMntInfoProc(ticket, true, searchParam, startIndex, searchCount, out totalCount, out searchData, out errMsg);
        //}
        //#endregion

        //#region SearchSvrMntInfoNoTicket
        ///// <summary>
        ///// サーバーメンテナンス情報検索処理<br/>
        ///// 指定されたサーバーメンテナンス区分のレコードを件数指定で取得します。
        ///// </summary>
        ///// <param name="productCode">パッケージ区分</param>
        ///// <param name="serverMainteDivCd">サーバーメンテナンス区分[1:定期メンテナンス, 9:緊急メンテナンス, -1:両方]</param>
        ///// <param name="startIndex">検索開始インデックス</param>
        ///// <param name="searchCount">検索件数</param>
        ///// <param name="totalCount">検索結果最大件数</param>
        ///// <param name="searchData">検索結果データ</param>
        ///// <param name="errMsg">エラーメッセージ</param>
        ///// <returns>
        ///// 処理ステータス
        ///// <list type="bullet">
        ///// <item><description>0:正常終了</description></item>
        ///// <item><description>-99:ロール情報取得失敗</description></item>
        ///// <item><description>他:アクセスクラス処理ステータス</description></item>
        ///// </list>
        ///// </returns>
        //public int SearchSvrMntInfoNoTicket(string productCode, int serverMainteDivCd, int startIndex, int searchCount, out int totalCount, out List<SvrMntInfoWork> searchData, out string errMsg)
        //{
        //    // 検索用パラメータ作成
        //    SvrMntInfoWork searchParam = new SvrMntInfoWork();
        //    searchParam.ProductCode = productCode;
        //    searchParam.ServerMainteDivCd = serverMainteDivCd;

        //    // 検索処理
        //    return this.SearchSvrMntInfoProc(null, false, searchParam, startIndex, searchCount, out totalCount, out searchData, out errMsg);
        //}
        //#endregion
        #endregion


        #region SearchChangGidnc
        /// <summary>
		/// 変更案内情報検索処理<br/>
		/// 指定された配信バージョンの全レコードを取得します。<br/>
		/// アクセスチケットを指定して、ロール情報の自動設定を行います。
		/// </summary>
		/// <param name="ticket">アクセスチケット</param>
		/// <param name="multicastVersion">配信バージョン</param>
		/// <param name="searchData">検索結果データ</param>
		/// <param name="searchDetail">検索結果明細データ</param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>
		/// 処理ステータス
		/// <list type="bullet">
		/// <item><description>0:正常終了</description></item>
		/// <item><description>-99:ロール情報取得失敗</description></item>
		/// <item><description>他:アクセスクラス処理ステータス</description></item>
		/// </list>
		/// </returns>
		public int SearchChangGidnc(string ticket, string multicastVersion, out List<ChangGidncWork> searchData, out List<ChgGidncDtWork> searchDetail, out string errMsg)
		{
			int totalCount = 0;

			// 検索用パラメータ作成
			ChangGidncParaWork searchParam = new ChangGidncParaWork();
			searchParam.MulticastVersion = multicastVersion;	// 配信バーション
			searchParam.MulticastSystemDivCd = -1;				// 配信システム区分(-1:全て)

			// 検索処理
			return this.SearchChangGidncProc(ticket, true, searchParam, 0, 1, out totalCount, out searchData, out searchDetail, out errMsg);
		}
        #endregion

        #region SearchChangGidnc
        /// <summary>
		/// 変更案内情報検索処理<br/>
		/// 指定された条件のレコードを件数指定で取得します。<br/>
		/// アクセスチケットを指定して、ロール情報の自動設定を行います。
		/// </summary>
		/// <param name="ticket">アクセスチケット</param>
		/// <param name="searchParam">検索用パラメータ</param>
		/// <param name="startIndex">検索開始インデックス</param>
		/// <param name="searchCount">検索件数</param>
		/// <param name="totalCount">検索結果最大件数</param>
		/// <param name="searchData">検索結果データ</param>
		/// <param name="searchDetail">検索結果明細データ</param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>
		/// 処理ステータス
		/// <list type="bullet">
		/// <item><description>0:正常終了</description></item>
		/// <item><description>-99:ロール情報取得失敗</description></item>
		/// <item><description>他:アクセスクラス処理ステータス</description></item>
		/// </list>
		/// </returns>
		public int SearchChangGidnc(string ticket, ChangGidncParaWork searchParam, int startIndex, int searchCount, out int totalCount, out List<ChangGidncWork> searchData, out List<ChgGidncDtWork> searchDetail, out string errMsg)
		{
			return SearchChangGidncProc(ticket, true, searchParam, startIndex, searchCount, out totalCount, out searchData, out searchDetail, out errMsg);
        }
        #endregion

        #region SearchChangGidncNoTicket
        /// <summary>
		/// 変更案内情報検索処理<br/>
		/// 指定された条件のレコードを件数指定で取得します。
		/// </summary>
		/// <param name="searchParam">検索用パラメータ</param>
		/// <param name="startIndex">検索開始インデックス</param>
		/// <param name="searchCount">検索件数</param>
		/// <param name="totalCount">検索結果最大件数</param>
		/// <param name="searchData">検索結果データ</param>
		/// <param name="searchDetail">検索結果明細データ</param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>
		/// 処理ステータス
		/// <list type="bullet">
		/// <item><description>0:正常終了</description></item>
		/// <item><description>-99:ロール情報取得失敗</description></item>
		/// <item><description>他:アクセスクラス処理ステータス</description></item>
		/// </list>
		/// </returns>
		public int SearchChangGidncNoTicket(ChangGidncParaWork searchParam, int startIndex, int searchCount, out int totalCount, out List<ChangGidncWork> searchData, out List<ChgGidncDtWork> searchDetail, out string errMsg)
		{
			return SearchChangGidncProc(null, false, searchParam, startIndex, searchCount, out totalCount, out searchData, out searchDetail, out errMsg);
		}
		#endregion

        #endregion



		#region Private Methods

        #region Del  2007.12.10  Kouguchi
        //#region ReadSvrMntInfoProc
        ///// <summary>
        ///// サーバーメンテナンス情報取得処理
        ///// </summary>
        ///// <param name="ticket">アクセスチケット</param>
        ///// <param name="getRoleInf">ロール情報自動取得有無</param>
        ///// <param name="readParam">読込み用パラメータ</param>
        ///// <param name="readData">取得データ</param>
        ///// <param name="errMsg">エラーメッセージ</param>
        ///// <returns>処理ステータス
        ///// <list type="bullet">
        ///// <item><description>0:正常終了</description></item>
        ///// <item><description>-99:ロール情報取得失敗</description></item>
        ///// <item><description>他:アクセスクラス処理ステータス</description></item>
        ///// </list>
        ///// </returns>
        //private int ReadSvrMntInfoProc(string ticket, bool getRoleInf, SvrMntInfoWork readParam, out SvrMntInfoWork readData, out string errMsg)
        //{
        //    int status = 0;

        //    // ロール情報よりパラメータ設定
        //    if (getRoleInf)
        //    {
        //        status = this.GetRoleInfoForSvrMntInfo(ticket, ref readParam, out errMsg);
        //        if (status != 0)
        //        {
        //            readData = null;
        //            return status;
        //        }
        //    }

        //    // アクセスクラスRead
        //    ChangePgGuideDBAcs changePgGuideDBAcs = new ChangePgGuideDBAcs();
        //    status = changePgGuideDBAcs.ReadSvrMntInf(readParam, out readData, out errMsg);

        //    return status;
        //}
        //#endregion

        //#region SearchSvrMntInfoProc
        ///// <summary>
        ///// サーバーメンテナンス情報検索処理
        ///// </summary>
        ///// <param name="ticket">アクセスチケット</param>
        ///// <param name="getRoleInf">ロール情報自動取得有無</param>
        ///// <param name="searchParam">検索用パラメータ</param>
        ///// <param name="startIndex">検索開始インデックス</param>
        ///// <param name="searchCount">最大検索件数</param>
        ///// <param name="searchData">検索結果データ</param>
        ///// <param name="totalCount">検索結果最大件数</param>
        ///// <param name="errMsg">エラーメッセージ</param>
        ///// <returns>処理ステータス
        ///// <list type="bullet">
        ///// <item><description>0:正常終了</description></item>
        ///// <item><description>-99:ロール情報取得失敗</description></item>
        ///// <item><description>他:アクセスクラス処理ステータス</description></item>
        ///// </list>
        ///// </returns>
        //private int SearchSvrMntInfoProc(string ticket, bool getRoleInf, SvrMntInfoWork searchParam, int startIndex, int searchCount, out int totalCount, out List<SvrMntInfoWork> searchData, out string errMsg)
        //{
        //    int status = 0;

        //    // ロール情報よりパラメータ設定
        //    if (getRoleInf)
        //    {
        //        status = this.GetRoleInfoForSvrMntInfo(ticket, ref searchParam, out errMsg);
        //        if (status != 0)
        //        {
        //            totalCount = 0;
        //            searchData = null;
        //            return status;
        //        }
        //    }

        //    // アクセスクラスRead
        //    ChangePgGuideDBAcs changePgGuideDBAcs = new ChangePgGuideDBAcs();
        //    status = changePgGuideDBAcs.SearchSvrMntInf(out searchData, searchParam, startIndex, searchCount, out totalCount, out errMsg);

        //    return status;
        //}
        //#endregion

        //#region GetRoleInfoForSvrMntInfo
        ///// <summary>
        ///// ロール取得/パラメータ設定処理[サーバーメンテナンス情報用]
        ///// </summary>
        ///// <param name="ticket">アクセスチケット</param>
        ///// <param name="svrMntInfoParam">パラメータ</param>
        ///// <param name="errMsg">エラーメッセージ</param>
        ///// <returns>
        ///// 処理ステータス
        ///// <list type="bullet">
        ///// <item><description>0:正常終了</description></item>
        ///// <item><description>-99:ロール情報取得失敗</description></item>
        ///// </list>
        ///// </returns>
        //private int GetRoleInfoForSvrMntInfo(string ticket, ref SvrMntInfoWork svrMntInfoParam, out string errMsg)
        //{
        //    errMsg = "";

        //    if ((ticket == null) || (ticket == String.Empty))
        //    {
        //        errMsg = "アクセスチケットが設定されていません。";
        //        return -99;
        //    }

        //    // アクセスチケットよりロール情報取得
        //    ChangePgGuideRoleInfo roleInfoAcs = new ChangePgGuideRoleInfo();
        //    RoleInfo roleInfo = roleInfoAcs.ReadRoleInfo(ticket, ctCODE_GenerationCode);

        //    if (roleInfo == null)
        //    {
        //        errMsg = "ロール情報の取得に失敗しました。";
        //        return -99;
        //    }

        //    // ロール情報よりパラメータ作成
        //    svrMntInfoParam.ProductCode = roleInfo.ProductCode;		// パッケージ区分

        //    return 0;
        //}
        //#endregion
        #endregion


        #region SearchChangGidncProc
        /// <summary>
		/// 変更案内情報検索処理
		/// </summary>
		/// <param name="ticket">アクセスチケット</param>
		/// <param name="getRoleInf">ロール情報自動取得有無</param>
		/// <param name="searchParam">検索用パラメータ</param>
		/// <param name="startIndex">検索開始インデックス</param>
		/// <param name="searchCount">検索件数</param>
		/// <param name="totalCount">検索結果最大件数</param>
		/// <param name="searchData">検索結果データ</param>
		/// <param name="searchDetail">検索結果明細データ</param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>
		/// 処理ステータス
		/// <list type="bullet">
		/// <item><description>0:正常終了</description></item>
		/// <item><description>-99:ロール情報取得失敗</description></item>
		/// <item><description>他:アクセスクラス処理ステータス</description></item>
		/// </list>
		/// </returns>
		private int SearchChangGidncProc(string ticket, bool getRoleInf, ChangGidncParaWork searchParam, int startIndex, int searchCount, out int totalCount, out List<ChangGidncWork> searchData, out List<ChgGidncDtWork> searchDetail, out string errMsg)
		{
			int status = 0;

			// ロール情報よりパラメータ設定
			if (getRoleInf)
			{
				status = this.GetRoleInfoForChangGidnc(ticket, ref searchParam, out errMsg);
				if (status != 0)
				{
					totalCount = 0;
					searchData = null;
					searchDetail = null;
					return status;
				}
			}

			// アクセスクラスRead
			ChangePgGuideDBAcs changePgGuideDBAcs = new ChangePgGuideDBAcs();
			status = changePgGuideDBAcs.ChangGidnc(searchParam, out searchData, out searchDetail, startIndex, searchCount, out totalCount, out errMsg);

			return status;
        }
        #endregion

        #region GetRoleInfoForChangGidnc
        /// <summary>
		/// ロール取得/パラメータ設定処理
		/// </summary>
		/// <param name="ticket">アクセスチケット</param>
		/// <param name="changGidncParam">パラメータ</param>
		/// <param name="errMsg">エラーメッセージ</param>
		/// <returns>
		/// 処理ステータス
		/// <list type="bullet">
		/// <item><description>0:正常終了</description></item>
		/// <item><description>-99:ロール情報取得失敗</description></item>
		/// </list>
		/// </returns>
		private int GetRoleInfoForChangGidnc(string ticket, ref ChangGidncParaWork changGidncParam, out string errMsg)
		{
			errMsg = "";

			if ((ticket == null) || (ticket == String.Empty))
			{
				errMsg = "アクセスチケットが設定されていません。";
				return -99;
			}

			// アクセスチケットよりロール情報取得
			ChangePgGuideRoleInfo roleInfoAcs = new ChangePgGuideRoleInfo();
			RoleInfo roleInfo = roleInfoAcs.ReadRoleInfo(ticket, ctCODE_GenerationCode);

			if (roleInfo == null)
			{
				errMsg = "ロール情報の取得に失敗しました。";
				return -99;
			}

			// ロール情報よりパラメータ作成
			changGidncParam.ProductCode = roleInfo.ProductCode;					// パッケージ区分
			switch (roleInfo.IndividuallyCode)
			{
				case 0:		// 個別無し
					changGidncParam.McastOfferDivCd = 0;						// 配信提供区分(-1:マージ, 0:標準, 1:個別)
					break;
				case 1:		// グループ単位個別有り
					changGidncParam.McastOfferDivCd = -1;
					changGidncParam.UpdateGroupCode = roleInfo.IndividuallyGroupCode;				// 更新グループコード
					break;
				case 2:		// 企業単位個別有り
					changGidncParam.McastOfferDivCd = -1;
					changGidncParam.EnterpriseCode = roleInfo.IndividuallyEnterpriseCode;			// 企業コード
					break;
				case 3:		// グループ・企業単位個別有り
					changGidncParam.McastOfferDivCd = -1;
					changGidncParam.UpdateGroupCode = roleInfo.IndividuallyGroupCode;
					break;
			}

			changGidncParam.StdDate = Int64.Parse(String.Format("{0:yyyyMMddHHmm}", DateTime.Now));	// 公開基準日
			changGidncParam.OpenDtTmDiv = roleInfo.BroadleafFlag ? 1 : 2;							// 1:サポート公開日時,2:ユーザー公開日時

			return 0;
        }
        #endregion

        #endregion

    }
}

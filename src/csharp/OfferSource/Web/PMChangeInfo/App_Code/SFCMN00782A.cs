using System;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using System.Web.Services;
using System.Web.Services.Protocols;

using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;

/// <summary>
/// 変更PG案内案内通知Webサービス
/// </summary>
/// <remarks>
/// <br>Note       : 最新のプログラム配信案内・サーバーメンテナンス情報・緊急メンテナンス情報をクライアントに提供します。</br>
/// <br>Programmer : 23001 秋山　亮介</br>
/// <br>Date       : 2007.03.14</br>
/// <br>Update     : 2008.01.07  Kouguchi  新レイアウト対応</br>
/// </remarks>
//[WebService(Namespace = "http://tempuri.org/",                                                                              //Del 2008.01.07 Kouguchi
//	Description="この XML Web サービスは、最新のプログラム配信案内・サーバーメンテナンス情報・緊急メンテナンス情報を取得します。")]  //Del 2008.01.07 Kouguchi
[WebService(Namespace = "http://tempuri.org/",                                                                                                    //Add 2008.01.07 Kouguchi
	Description="この XML Web サービスは、最新のプログラム配信案内・定期メンテナンス情報・緊急メンテナンス情報・データメンテナンス情報・印字位置リリース情報を取得します。")]  //Add 2008.01.07 Kouguchi

[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]

public class SFCMN00782A : System.Web.Services.WebService
{

    public SFCMN00782A()
	{

        //デザインされたコンポーネントを使用する場合、次の行をコメントを解除してください 
        //InitializeComponent();

		// 変更PG案内検索部品インスタンス作成
		if( this._changeInfoSearchManager == null ) 
        {
			this._changeInfoSearchManager = new ChangeInfoSearchManager();
		}

		// ログ出力部品インスタンス作成
		if( this._changePgGuideLogOutPut == null ) 
        {
			this._changePgGuideLogOutPut = new ChangePgGuideLogOutPut();
		}
    }

	/// <summary>変更PG案内検索部品</summary>
	private ChangeInfoSearchManager _changeInfoSearchManager = null;
	/// <summary>ログ出力部品</summary>
	private ChangePgGuideLogOutPut  _changePgGuideLogOutPut  = null;


    [WebMethod]
    //public int SearchNewInfo( out PgMulcasGdWork pgMulcasGdWork, out SvrMntInfoWork svrMntInfoWork, out SvrMntInfoWork emergencyMainteInfo, PgMulcasGdParaWork pgMulcasGdParaWork )  //Del 2008.01.07 Kouguchi
    //public int SearchNewInfo( out ChangGidncWork changGidncWork1, out ChangGidncWork changGidncWork2, out ChangGidncWork changGidncWork3, ChangGidncWork changGidncWork4, ChangGidncParaWork changGidncParaWork )  //Add 2008.01.07 Kouguchi
    public int SearchNewInfo(ChangGidncParaWork changGidncParaWork, out ChangGidncWork changGidncWork1, out ChangGidncWork changGidncWork2, out ChangGidncWork changGidncWork3, out ChangGidncWork changGidncWork4, out ChangGidncWork changGidncWork5)  //Add 2008.01.07 Kouguchi
	{
		int status = ( int )ConstantManagement.DB_Status.ctDB_ERROR;

        //Del ↓↓↓ 2008.01.07 Kouguchi
        //pgMulcasGdWork      = null;
        //svrMntInfoWork      = null;
        //emergencyMainteInfo = null;
        //Del ↑↑↑ 2008.01.07 Kouguchi

        //Add ↓↓↓ 2008.01.07 Kouguchi
        changGidncWork1 = null;  //プログラム配信情報
        changGidncWork2 = null;  //定期メンテナンス情報
        changGidncWork3 = null;  //データメンテナンス情報
        changGidncWork4 = null;  //緊急サーバーメンテナンス情報
        changGidncWork5 = null;  //印字位置リリース情報
        //Add ↑↑↑ 2008.01.07 Kouguchi


		try 
        {
			string errorMessage = "";    // エラーメッセージ受け取り用

			// 最新 プログラム配信情報取得
			//status = this.ReadPgMulcasGd( out pgMulcasGdWork, out errorMessage, pgMulcasGdParaWork );
			status = this.ReadPgMulcasGd( out changGidncWork1, out errorMessage, changGidncParaWork );
			if( (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) ) 
            {
				return status;
			}
			// 最新 定期メンテナンス情報取得
			//status = this.ReadSvrMntInfo( out svrMntInfoWork, out errorMessage, pgMulcasGdParaWork );
			status = this.ReadSvrMntInfo( out changGidncWork2, out errorMessage, changGidncParaWork );
			if( (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) ) 
            {
				return status;
			}
			// 最新 データメンテナンス情報取得
			status = this.ReadDatMntInfo( out changGidncWork3, out errorMessage, changGidncParaWork );
			if( (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) ) 
            {
				return status;
			}
			// 最新 緊急サーバーメンテナンス情報取得
			//status = this.ReadEmergencySvrMntInfo( out emergencyMainteInfo, out errorMessage, pgMulcasGdParaWork );
			status = this.ReadEmergencySvrMntInfo( out changGidncWork4, out errorMessage, changGidncParaWork );
			if( (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) ) 
            {
				return status;
			}
            //// 最新 印字位置リリース情報取得
            //status = this.ReadPrintPositionInfo( out changGidncWork5, out errorMessage, changGidncParaWork );
            //if( (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) ) 
            //{
            //    return status;
            //}



			//if( (pgMulcasGdWork == null) && (svrMntInfoWork == null)  && (emergencyMainteInfo == null) )  //Del 2008.01.07
			if( (changGidncWork1 == null) && (changGidncWork2 == null) && (changGidncWork3 == null) && (changGidncWork4 == null) && (changGidncWork5 == null) )  //Add 2008.01.07 Kouguchi
            {
				status = ( int )ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			}
			else 
            {
				status = ( int )ConstantManagement.DB_Status.ctDB_NORMAL;
			}
		}
		catch( Exception ex )
		{
			status = -1;
			// ログを書き込み
			//this._changePgGuideLogOutPut.WriteLog( ChangePgGuideLogOutPut.MessageLevel.Error, pgMulcasGdParaWork.EnterpriseCode, "", ex );  //Del 2008.01.07 Kouguchi
			this._changePgGuideLogOutPut.WriteLog( ChangePgGuideLogOutPut.MessageLevel.Error, changGidncParaWork.EnterpriseCode, "", ex );  //Add 2008.01.07 Kouguchi
		}

changGidncParaWork.McastGidncCntntsCd=0;  //TEST
changGidncParaWork.McastGidncMainteCd=0;  //TEST
        
        return status;
    }



	/// <summary>
	/// プログラム配信案内読込処理
	/// </summary>
	/// <param name="changGidncWork">変更案内ワーククラス(プログラム配信案内)</param>
	/// <param name="errorMessage">エラーメッセージ</param>
	/// <param name="changGidncParaWork">変更案内データパラメータクラス</param>
	/// <returns>STATUS</returns>
	/// <remarks>
	/// <br>Note       : 最新のプログラム配信案内の取得を行います。</br>
	/// <br>Programmer : 23001 秋山　亮介</br>
	/// <br>Date       : 2007.03.14</br>
	/// </remarks>
	//private int ReadPgMulcasGd( out PgMulcasGdWork pgMulcasGdWork, out string errorMessage, PgMulcasGdParaWork pgMulcasGdParaWork )  //Del 2008.01.07 Kouguchi
	private int ReadPgMulcasGd( out ChangGidncWork changGidncWork, out string errorMessage, ChangGidncParaWork changGidncParaWork )  //Add 2008.01.07 Kouguchi
	{
		int status = ( int )ConstantManagement.DB_Status.ctDB_ERROR;

		//pgMulcasGdWork = null;  //Del 2008.01.07 Kouguchi
		changGidncWork = null;  //Add 2008.01.07 Kouguchi

		errorMessage   = "";

		try 
        {
            //List<PgMulcasGdWork> pgMulcasGdWorkList = null;    // プログラム配信案内ワーククラスリスト      //Del 2008.01.07 Kouguchi
            //List<PgMulcsGdDWork> pgMulcsGdDWorkList = null;    // プログラム配信案内明細ワーククラスリスト  //Del 2008.01.07 Kouguchi
			List<ChangGidncWork> changGidncWorkList = null;    // 変更案内ワーククラスリスト      //Add 2008.01.07 Kougcuhi
			List<ChgGidncDtWork> chgGidncDtWorkList = null;    // 変更案内明細ワーククラスリスト  //Add 2008.01.07 Kougcuhi

            int totalCount;

changGidncParaWork.McastGidncCntntsCd=1;  //TEST
changGidncParaWork.McastGidncMainteCd=0;  //TEST

			// 最新情報検索
			//status = this._changeInfoSearchManager.SearchPgMulcasGdNoTicket( pgMulcasGdParaWork, 0, 1, out totalCount, out pgMulcasGdWorkList, out pgMulcsGdDWorkList, out errorMessage );  //Del 2008.01.07 Kouguchi
			status = this._changeInfoSearchManager.SearchChangGidncNoTicket( changGidncParaWork, 0, 1, out totalCount, out changGidncWorkList, out chgGidncDtWorkList, out errorMessage );  //Add 2008.01.07 Kouguchi
			
            switch( status ) 
            {
				case ( int )ConstantManagement.DB_Status.ctDB_NORMAL:
				{
                    //Del ↓↓↓ 2008.01.07 Kouguchi
                    //if( pgMulcasGdWorkList.Count > 0 ) 
                    //{
                    //    pgMulcasGdWork = pgMulcasGdWorkList[ 0 ];
                    //}
                    //Del ↑↑↑ 2008.01.07 Kouguchi

                    //Add ↓↓↓ 2008.01.07 Kouguchi
					if( changGidncWorkList.Count > 0 ) 
                    {
						changGidncWork = changGidncWorkList[ 0 ];
					}
                    //Add ↑↑↑ 2008.01.07 Kouguchi

                    //if( pgMulcasGdWork == null )  //Del 2008.01.07 Kouguchi
                    if( changGidncWork == null )  //Add 2008.01.07 Kouguchi
                    {
						status = ( int )ConstantManagement.DB_Status.ctDB_NOT_FOUND;
					}
					break;
				}
				case ( int )ConstantManagement.DB_Status.ctDB_EOF:
				case ( int )ConstantManagement.DB_Status.ctDB_NOT_FOUND:
				{
					//pgMulcasGdWork = null;  //Del 2008.01.07 Kouguchi
					changGidncWork = null;  //Add 2008.01.07 Kouguchi
					status = ( int )ConstantManagement.DB_Status.ctDB_NOT_FOUND;
					break;
				}
				default:
				{
					//pgMulcasGdWork = null;  //Del 2008.01.07 Kouguchi
					changGidncWork = null;  //Add 2008.01.07 Kouguchi
					return status;
				}
			}
		}
		catch( Exception ex ) 
        {
			status = -1;
			// ログを書き込み
			//this._changePgGuideLogOutPut.WriteLog( ChangePgGuideLogOutPut.MessageLevel.Error, pgMulcasGdParaWork.EnterpriseCode, "", ex );  //Del 2008.01.07 Kouguchi
			this._changePgGuideLogOutPut.WriteLog( ChangePgGuideLogOutPut.MessageLevel.Error, changGidncParaWork.EnterpriseCode, "", ex );  //Add 2008.01.07 Kouguchi

            //pgMulcasGdWork = null;  //Del 2008.01.07 Kouguchi
    		changGidncWork = null;  //Add 2008.01.07 Kouguchi
			errorMessage = ex.Message;
		}

		return status;
	}
    


	/// <summary>
	/// 定期メンテナンス情報読込処理
	/// </summary>
	/// <param name="changGidncWork">変更案内ワーククラス(定期メンテナンス情報)</param>
	/// <param name="errorMessage">エラーメッセージ</param>
	/// <param name="changGidncParaWork">変更案内データパラメータクラス</param>
	/// <returns>STATUS</returns>
	/// <remarks>
	/// <br>Note       : 最新の定期メンテナンス情報の取得を行います。</br>
	/// <br>Programmer : 23001 秋山　亮介</br>
	/// <br>Date       : 2007.03.14</br>
	/// </remarks>
	//private int ReadSvrMntInfo( out SvrMntInfoWork svrMntInfoWork, out string errorMessage, PgMulcasGdParaWork pgMulcasGdParaWork )  //Del 2008.01.07 Kouguchi
	private int ReadSvrMntInfo( out ChangGidncWork changGidncWork, out string errorMessage, ChangGidncParaWork changGidncParaWork )  //Add 2008.01.07 Kouguchi
	{
		int status = ( int )ConstantManagement.DB_Status.ctDB_ERROR;

		//svrMntInfoWork = null;  //Del 2008.01.07 Kouguchi
		changGidncWork = null;  //Add 2008.01.07 Kouguchi

        errorMessage   = "";

		try 
        {
			//List<SvrMntInfoWork> svrMntInfoWorkList = null;    // サーバーメンテナンス情報ワークリスト  //Del 2008.01.07 Kouguchi
			List<ChangGidncWork> changGidncWorkList = null;    // 変更案内ワーククラスリスト      //Add 2008.01.07 Kougcuhi
			List<ChgGidncDtWork> chgGidncDtWorkList = null;    // 変更案内明細ワーククラスリスト  //Add 2008.01.07 Kougcuhi

            int totalCount = 0;

changGidncParaWork.McastGidncCntntsCd=2;  //TEST
changGidncParaWork.McastGidncMainteCd=1;  //TEST

			// 最新情報検索
			//status = this._changeInfoSearchManager.SearchSvrMntInfoNoTicket( pgMulcasGdParaWork.ProductCode, ( int )ConstantManagement_NS_MGD.ServerMainteDiv.Periodic, 0, 1, out totalCount, out svrMntInfoWorkList, out errorMessage );  //Del 2008.01.07 Kouguchi
			status = this._changeInfoSearchManager.SearchChangGidncNoTicket( changGidncParaWork, 0, 1, out totalCount, out changGidncWorkList, out chgGidncDtWorkList, out errorMessage );

            switch( status ) 
            {
				case ( int )ConstantManagement.DB_Status.ctDB_NORMAL:
				{
                    //Del ↓↓↓ 2008.01.07 Kouguchi
                    //if( svrMntInfoWorkList.Count > 0 ) 
                    //{
                    //    svrMntInfoWork = svrMntInfoWorkList[ 0 ];
                    //}
                    //Del ↑↑↑ 2008.01.07 Kouguchi

                    //Add ↓↓↓ 2008.01.07 Kouguchi
					if( changGidncWorkList.Count > 0 ) 
                    {
						changGidncWork = changGidncWorkList[ 0 ];
					}
                    //Add ↑↑↑ 2008.01.07 Kouguchi

					//if( svrMntInfoWork == null )  //Del 2008.01.07 Kouguchi
                    if( changGidncWork == null )  //Add 2008.01.07 Kouguchi
                    {
						status = ( int )ConstantManagement.DB_Status.ctDB_NOT_FOUND;
					}
					break;
				}
				case ( int )ConstantManagement.DB_Status.ctDB_EOF:
				case ( int )ConstantManagement.DB_Status.ctDB_NOT_FOUND:
				{
					//svrMntInfoWork = null;  //Del 2008.01.07 Kouguchi
					changGidncWork = null;  //Add 2008.01.07 Kouguchi
					status = ( int )ConstantManagement.DB_Status.ctDB_NOT_FOUND;
					break;
				}
				default:
				{
					//svrMntInfoWork = null;  //Del 2008.01.07 Kouguchi
					changGidncWork = null;  //Add 2008.01.07 Kouguchi
					return status;
				}
			}
		}
		catch( Exception ex ) 
        {
			status = -1;
			// ログを書き込み
			//this._changePgGuideLogOutPut.WriteLog( ChangePgGuideLogOutPut.MessageLevel.Error, pgMulcasGdParaWork.EnterpriseCode, "", ex );  //Del 2008.01.07 Kouguchi
			this._changePgGuideLogOutPut.WriteLog( ChangePgGuideLogOutPut.MessageLevel.Error, changGidncParaWork.EnterpriseCode, "", ex );  //Add 2008.01.07 Kouguchi

			//svrMntInfoWork = null;  //Del 2008.01.07 Kouguchi
    		changGidncWork = null;  //Add 2008.01.07 Kouguchi
			errorMessage = ex.Message;
		}

		return status;
	}



	/// <summary>
	/// データメンテナンス情報読込処理
	/// </summary>
	/// <param name="changGidncWork">変更案内ワーククラス(データメンテナンス情報)</param>
	/// <param name="errorMessage">エラーメッセージ</param>
	/// <param name="changGidncParaWork">変更案内データパラメータクラス</param>
	/// <returns>STATUS</returns>
	/// <remarks>
	/// <br>Note       : 最新のデータメンテナンス情報の取得を行います。</br>
	/// <br>Programmer : 90027 高口　勝</br>
	/// <br>Date       : 2008.01.07</br>
	/// </remarks>
	private int ReadDatMntInfo( out ChangGidncWork changGidncWork, out string errorMessage, ChangGidncParaWork changGidncParaWork )
	{
		int status = ( int )ConstantManagement.DB_Status.ctDB_ERROR;

		changGidncWork = null;

        errorMessage   = "";

		try 
        {
			List<ChangGidncWork> changGidncWorkList = null;    // 変更案内ワーククラスリスト
			List<ChgGidncDtWork> chgGidncDtWorkList = null;    // 変更案内明細ワーククラスリスト

            int totalCount = 0;

changGidncParaWork.McastGidncCntntsCd=2;  //TEST
changGidncParaWork.McastGidncMainteCd=2;  //TEST

			// 最新情報検索
			status = this._changeInfoSearchManager.SearchChangGidncNoTicket( changGidncParaWork, 0, 1, out totalCount, out changGidncWorkList, out chgGidncDtWorkList, out errorMessage );

            switch( status ) 
            {
				case ( int )ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					if( changGidncWorkList.Count > 0 ) 
                    {
						changGidncWork = changGidncWorkList[ 0 ];
					}

                    if( changGidncWork == null )
                    {
						status = ( int )ConstantManagement.DB_Status.ctDB_NOT_FOUND;
					}
					break;
				}
				case ( int )ConstantManagement.DB_Status.ctDB_EOF:
				case ( int )ConstantManagement.DB_Status.ctDB_NOT_FOUND:
				{
					changGidncWork = null;
					status = ( int )ConstantManagement.DB_Status.ctDB_NOT_FOUND;
					break;
				}
				default:
				{
					changGidncWork = null;
					return status;
				}
			}
		}
		catch( Exception ex ) 
        {
			status = -1;
			// ログを書き込み
			this._changePgGuideLogOutPut.WriteLog( ChangePgGuideLogOutPut.MessageLevel.Error, changGidncParaWork.EnterpriseCode, "", ex );

    		changGidncWork = null;
			errorMessage = ex.Message;
		}

		return status;
	}
    


	/// <summary>
	/// 緊急サーバーメンテナンス情報読込処理
	/// </summary>
	/// <param name="changGidncWork">変更案内ワーククラス(サーバーメンテナンス情報)</param>
	/// <param name="errorMessage">エラーメッセージ</param>
	/// <param name="pchangGidncParaWork">変更案内データパラメータクラス</param>
	/// <returns>STATUS</returns>
	/// <remarks>
	/// <br>Note       : 最新の緊急サーバーメンテナンス情報の取得を行います。</br>
	/// <br>Programmer : 23001 秋山　亮介</br>
	/// <br>Date       : 2007.03.14</br>
	/// </remarks>
	//private int ReadEmergencySvrMntInfo( out SvrMntInfoWork svrMntInfoWork, out string errorMessage, PgMulcasGdParaWork pgMulcasGdParaWork )  //Del 2008.01.07 Kouguchi
	private int ReadEmergencySvrMntInfo( out ChangGidncWork changGidncWork, out string errorMessage, ChangGidncParaWork changGidncParaWork )  //Add 2008.01.07 Kouguchi
	{
		int status = ( int )ConstantManagement.DB_Status.ctDB_ERROR;

		//svrMntInfoWork = null;  //Del 2008.01.07 Kouguchi
		changGidncWork = null;  //Add 2008.01.07 Kouguchi

        errorMessage   = "";


		try 
        {
			//List<SvrMntInfoWork> svrMntInfoWorkList = null;    // サーバーメンテナンス情報ワークリスト  //Del 2008.01.07 Kouguchi
			List<ChangGidncWork> changGidncWorkList = null;    // 変更案内ワーククラスリスト      //Add 2008.01.07 Kougcuhi
			List<ChgGidncDtWork> chgGidncDtWorkList = null;    // 変更案内明細ワーククラスリスト  //Add 2008.01.07 Kougcuhi

            int totalCount = 0;

changGidncParaWork.McastGidncCntntsCd=2;  //TEST
changGidncParaWork.McastGidncMainteCd=9;  //TEST

			// 最新情報検索
			//status = this._changeInfoSearchManager.SearchSvrMntInfoNoTicket( pgMulcasGdParaWork.ProductCode, ( int )ConstantManagement_NS_MGD.ServerMainteDiv.Emergency, 0, 1, out totalCount, out svrMntInfoWorkList, out errorMessage );  //Del 2008.01.07 Kouguchi
			status = this._changeInfoSearchManager.SearchChangGidncNoTicket( changGidncParaWork, 0, 1, out totalCount, out changGidncWorkList, out chgGidncDtWorkList, out errorMessage );  //Add 2008.01.07 Kouguchi

            switch( status ) 
            {
				case ( int )ConstantManagement.DB_Status.ctDB_NORMAL:
				{
                    //Del ↓↓↓ 2008.01.07 Kouguchi
                    //if( svrMntInfoWorkList.Count > 0 ) 
                    //{
                    //    // メンテナンスが終了していない場合
                    //    if( svrMntInfoWorkList[ 0 ].ServerMainteEdTime == 0 ) 
                    //    {
                    //        svrMntInfoWork = svrMntInfoWorkList[ 0 ];
                    //    }
                    //}
                    //Del ↑↑↑ 2008.01.07 Kouguchi

                    //Add ↓↓↓ 2008.01.07 Kouguchi
					if( changGidncWorkList.Count > 0 ) 
                    {
						// メンテナンスが終了していない場合
						if( changGidncWorkList[ 0 ].ServerMainteEdTime == 0 ) 
                        {
    						changGidncWork = changGidncWorkList[ 0 ];
						}
					}
                    //Add ↑↑↑ 2008.01.07 Kouguchi

					//if( svrMntInfoWork == null )   //Del 2008.01.07 Kouguchi
                    if( changGidncWork == null )  //Add 2008.01.07 Kouguchi
                    {
						status = ( int )ConstantManagement.DB_Status.ctDB_NOT_FOUND;
					}
					break;
				}
				case ( int )ConstantManagement.DB_Status.ctDB_EOF:
				case ( int )ConstantManagement.DB_Status.ctDB_NOT_FOUND:
				{
					//svrMntInfoWork = null;  //Del 2008.01.07 Kouguchi
					changGidncWork = null;  //Add 2008.01.07 Kouguchi
					status = ( int )ConstantManagement.DB_Status.ctDB_NOT_FOUND;
					break;
				}
				default:
				{
					//svrMntInfoWork = null;  //Del 2008.01.07 Kouguchi
					changGidncWork = null;  //Add 2008.01.07 Kouguchi
					return status;
				}
			}
		}
		catch( Exception ex ) 
        {
			status = -1;
			// ログを書き込み
			//this._changePgGuideLogOutPut.WriteLog( ChangePgGuideLogOutPut.MessageLevel.Error, pgMulcasGdParaWork.EnterpriseCode, "", ex );  //Del 2008.01.07 Kouguchi
			this._changePgGuideLogOutPut.WriteLog( ChangePgGuideLogOutPut.MessageLevel.Error, changGidncParaWork.EnterpriseCode, "", ex );  //Add 2008.01.07 Kouguchi

			//svrMntInfoWork = null;  //Del 2008.01.07 Kouguchi
    		changGidncWork = null;  //Add 2008.01.07 Kouguchi
			errorMessage = ex.Message;
		}

		return status;
	}
 
   
#if false
	/// <summary>
	/// 印字位置リリース情報読込処理
	/// </summary>
	/// <param name="changGidncWork">変更案内ワーククラス(印字位置リリース情報)</param>
	/// <param name="errorMessage">エラーメッセージ</param>
	/// <param name="changGidncParaWork">変更案内データパラメータクラス</param>
	/// <returns>STATUS</returns>
	/// <remarks>
	/// <br>Note       : 最新の印字位置リリース情報の取得を行います。</br>
	/// <br>Programmer : 90027 Kouguchi</br>
	/// <br>Date       : 2008.01.07</br>
	/// </remarks>
	private int ReadPrintPositionInfo( out ChangGidncWork changGidncWork, out string errorMessage, ChangGidncParaWork changGidncParaWork )
	{
		int status = ( int )ConstantManagement.DB_Status.ctDB_ERROR;

		changGidncWork = null;

        errorMessage   = "";

		try 
        {
			List<ChangGidncWork> changGidncWorkList = null;    // 変更案内ワーククラスリスト    
			List<ChgGidncDtWork> chgGidncDtWorkList = null;    // 変更案内明細ワーククラスリスト

            int totalCount = 0;

changGidncParaWork.McastGidncCntntsCd=3;  //TEST
changGidncParaWork.McastGidncMainteCd=0;  //TEST

			// 最新情報検索
			status = this._changeInfoSearchManager.SearchChangGidncNoTicket( changGidncParaWork, 0, 1, out totalCount, out changGidncWorkList, out chgGidncDtWorkList, out errorMessage );

            switch( status ) 
            {
				case ( int )ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					if( changGidncWorkList.Count > 0 ) 
                    {
						changGidncWork = changGidncWorkList[ 0 ];
					}

                    if( changGidncWork == null )
                    {
						status = ( int )ConstantManagement.DB_Status.ctDB_NOT_FOUND;
					}
					break;
				}
				case ( int )ConstantManagement.DB_Status.ctDB_EOF:
				case ( int )ConstantManagement.DB_Status.ctDB_NOT_FOUND:
				{
					changGidncWork = null;
					status = ( int )ConstantManagement.DB_Status.ctDB_NOT_FOUND;
					break;
				}
				default:
				{
					changGidncWork = null;
					return status;
				}
			}
		}
		catch( Exception ex ) 
        {
			status = -1;
			// ログを書き込み
			this._changePgGuideLogOutPut.WriteLog( ChangePgGuideLogOutPut.MessageLevel.Error, changGidncParaWork.EnterpriseCode, "", ex );

    		changGidncWork = null;
			errorMessage = ex.Message;
		}

		return status;
	}
#endif


}


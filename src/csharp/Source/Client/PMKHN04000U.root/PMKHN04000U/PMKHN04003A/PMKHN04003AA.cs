//**********************************************************************//
// システム         ：.NSシリーズ
// プログラム名称   ：得意先検索
// プログラム概要   ：得意先の検索を行う
// ---------------------------------------------------------------------//
//					Copyright(c) 2008 Broadleaf Co.,Ltd.				//
// =====================================================================//
// 履歴
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：22018 鈴木 正臣
// 修正日    2008/05/07     修正内容：新規作成
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30413 犬飼
// 修正日    2009/06/08     修正内容：SCMオプション項目追加
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30413 犬飼
// 修正日    2009/06/19     修正内容：SCMオプション項目追加
// ---------------------------------------------------------------------//
// 管理番号  10504551-00    作成担当：30517 夏野 駿希
// 修正日    2009/12/02     修正内容：MANTIS:14720 得意先名検索追加
//                                    MANTIS:14721 得意先検索結果の表示項目に自宅FAXと勤務先FAXを追加
// ---------------------------------------------------------------------//
// 管理番号  10601193-00    作成担当：21024 佐々木 健
// 修正日    2010/04/06     修正内容：オンライン種別区分 追加
// ---------------------------------------------------------------------//
// 管理番号  10601193-00    作成担当：30434 工藤 恵優
// 修正日    2010/06/26     修正内容：簡単問合せアカウントグループID 追加
// ---------------------------------------------------------------------//
// 管理番号  PM1012A        作成担当：朱 猛
// 修正日    2010/08/06     修正内容：電話番号検索追加と伴う修正
// ---------------------------------------------------------------------//
// 管理番号  PM1107C        作成担当：徐錦山
// 修正日    2011/07/22     修正内容：得意先略称表示列と検索追加(#826)
// ---------------------------------------------------------------------//
// 管理番号  PM1107C        作成担当：黄海霞
// 修正日    2011/08/19     修正内容：PCC自社用得意先ガイド追加 for #23705
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：22024 寺坂 誉志
// 修正日    2012.04.10     修正内容：顧客担当従業員名称 追加に伴う対応
// ---------------------------------------------------------------------//
using System;
using System.Collections;
using System.Data;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using System.Collections.Generic;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// 得意先車両検索テーブルアクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 得意先車両検索テーブルのアクセス制御を行います。</br>
	/// <br>Programmer : 22018 鈴木正臣</br>
	/// <br>Date       : 2007.02.13</br>
    /// <br>------------------------------------------------------------------------------------</br>
    /// <br>Update Note: 2009/12/02 30517 夏野 駿希</br>
    /// <br>             MANTIS:14720 得意先名検索追加</br>
    /// <br>             MANTIS:14721 得意先検索結果の表示項目に自宅FAXと勤務先FAXを追加</br>
    /// <br>------------------------------------------------------------------------------------</br>
	/// <br>------------------------------------------------------------------------------------</br>
	/// <br>Update Note: 2012.04.10 22024 寺坂 誉志</br>
	/// <br>             顧客担当従業員名称 追加に伴う対応</br>
	/// <br>------------------------------------------------------------------------------------</br>
	/// </remarks>
	public class CustomerSearchAcs
	{
		/// <summary>リモートオブジェクト格納バッファ</summary>
		private ICustomerSearchDB _iCustomerSearchDB = null;

		/// <summary>
		/// 得意先車両検索テーブルアクセスクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 得意先車両検索テーブルアクセスクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 22018 鈴木正臣</br>
		/// <br>Date       : 2007.02.13</br>
		/// <br></br>
		/// </remarks>
		public CustomerSearchAcs()
		{
			try
			{
				// リモートオブジェクト取得
				this._iCustomerSearchDB = (ICustomerSearchDB)MediationCustomerSearchDB.GetCustomerSearchDB();
			}
			catch (Exception)
			{				
				//オフライン時はnullをセット
				this._iCustomerSearchDB = null;
			}
		}

		/// <summary>オンラインモードの列挙型です。</summary>
		public enum OnlineMode 
		{
			/// <summary>オフライン</summary>
			Offline,
			/// <summary>オンライン</summary>
			Online 
		}

		/// <summary>
		/// オンラインモード取得処理
		/// </summary>
		/// <returns>OnlineMode</returns>
		/// <remarks>
		/// <br>Note       : オンラインモードを取得します。</br>
		/// <br>Programmer : 980079 鈴木正臣</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		public int GetOnlineMode()
		{
			if (this._iCustomerSearchDB == null)
			{
				return (int)OnlineMode.Offline;
			}
			else
			{
				return (int)OnlineMode.Online;
			}
		}

		/// <summary>
		/// 顧客全件検索
		/// </summary>
        /// <param name="retArray"></param>
        /// <param name="paraRec"></param>
		/// <returns></returns>
		public int Serch(out CustomerSearchRet[] retArray, CustomerSearchPara paraRec)
		{
			CustomerSearchParaWork customerSearchParaWork = new CustomerSearchParaWork();
			customerSearchParaWork = CopyToParamDataFromUIData(paraRec);

			customerSearchParaWork.EnterpriseCode = paraRec.EnterpriseCode;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/20 ADD
            if ( customerSearchParaWork.AcceptWholeSale == 0 )
            {
                customerSearchParaWork.AcceptWholeSale = -1;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/20 ADD
			
			object paraObj = customerSearchParaWork;
			object retObj;
			ArrayList retList = new ArrayList();
			ArrayList customerSearchRetList = new ArrayList();

            // --- DEL 2008/09/04 -------------------------------->>>>>
			// 得意先検索
            //int status = this._iCustomerSearchDB.Search( out retObj, ref paraObj, CustomerSearchReadMode.CustomerSearchMode_All, ConstantManagement.LogicalMode.GetData0 );
            // --- DEL 2008/09/04 --------------------------------<<<<<
            // --- ADD 2008/09/04 -------------------------------->>>>>
            // 得意先検索 (論理削除行も取得)
            int status = this._iCustomerSearchDB.Search(out retObj, ref paraObj, CustomerSearchReadMode.CustomerSearchMode_All, ConstantManagement.LogicalMode.GetData01);
            // --- ADD 2008/09/04 --------------------------------<<<<<

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				retList = retObj as ArrayList;

				if (retList == null)
				{
					status = (int)ConstantManagement.DB_Status.ctDB_EOF;
				}
				else
				{
                    //-----DEL PCC自社用得意先ガイド追加 for #23705 on 2011.08.19 ----->>>>>
                    //foreach (CustomerSearchRetWork retWork in retList)
                    //{
                    //    customerSearchRetList.Add(this.CopyToUIDataFromParamData(retWork));
                    //}
                    //-----DEL PCC自社用得意先ガイド追加 for #23705 on 2011.08.19 -----<<<<<
                    //-----ADD PCC自社用得意先ガイド追加 for #23705 on 2011.08.19 ----->>>>>
                    Hashtable pccCmpnyStHt = null;
                    //2:PCCマスメン用 PCC自社設定マスタに該当あり
                    if (customerSearchParaWork.PccuoeMode == 2)
                    {
                        //PCC自社設定マスタに該当あり
                        List<PccCmpnySt> pccCmpnyStList = null;
                        PccCmpnySt parsePccCmpnySt = new PccCmpnySt();
                        parsePccCmpnySt.InqOtherEpCd = customerSearchParaWork.EnterpriseCode;
                        parsePccCmpnySt.InqOtherSecCd = LoginInfoAcquisition.Employee.BelongSectionCode;
                        PccCmpnyStAcs pccCmpnyStAcs = new PccCmpnyStAcs();
                        //PCC自社設定マスタメンテ検索処理
                        status = pccCmpnyStAcs.Search(out pccCmpnyStList, parsePccCmpnySt, 0, ConstantManagement.LogicalMode.GetData0);
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            pccCmpnyStHt = new Hashtable();
                            foreach (PccCmpnySt pccCmpnyStRe in pccCmpnyStList)
                            {
                                if (!pccCmpnyStHt.ContainsKey(pccCmpnyStRe.PccCompanyCode))
                                {
                                    pccCmpnyStHt.Add(pccCmpnyStRe.PccCompanyCode, pccCmpnyStRe);
                                }
                            }
                        }
                        foreach (CustomerSearchRetWork retWork in retList)
                        {
                            if (pccCmpnyStHt == null || pccCmpnyStHt.Count == 0)
                            {
                                break;
                            }
                            else if (!pccCmpnyStHt.ContainsKey(retWork.CustomerCode))
                            {
                                continue;
                            }
                            customerSearchRetList.Add(this.CopyToUIDataFromParamData(retWork));
                        }
                    }
                    else
                    {
                        foreach (CustomerSearchRetWork retWork in retList)
                        {
                            customerSearchRetList.Add(this.CopyToUIDataFromParamData(retWork));
                        }
                    }
                    //----ADD PCC自社用得意先ガイド追加 for #23705 on 2011.08.19 -----<<<<<
				}
			}

			retArray = (CustomerSearchRet[])customerSearchRetList.ToArray(typeof(CustomerSearchRet));

			return status;
		}
		
		/// <summary>
		/// クラスメンバーコピー処理（得意先車両検索ワーククラス⇒得意先車両検索結果クラス）
		/// </summary>
		/// <param name="customerSearchWork">得意先車両検索ワーククラス</param>
		/// <returns>得意先車両検索結果クラス</returns>
		/// <remarks>
		/// <br>Note       : 得意先車両検索ワーククラスから得意先車両検索クラスへメンバーのコピーを行います。</br>
		/// <br>Programmer : 980079 鈴木正臣</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		private CustomerSearchRet CopyToUIDataFromParamData(CustomerSearchRetWork customerSearchWork)
		{
			CustomerSearchRet customerSearchRet = new CustomerSearchRet();

			// 得意先情報
			customerSearchRet.EnterpriseCode	= customerSearchWork.EnterpriseCode;
			customerSearchRet.CustomerCode		= customerSearchWork.CustomerCode;
			customerSearchRet.CustomerSubCode	= customerSearchWork.CustomerSubCode;
			customerSearchRet.Name				= customerSearchWork.Name;
			customerSearchRet.Name2				= customerSearchWork.Name2;
			customerSearchRet.HonorificTitle	= customerSearchWork.HonorificTitle;
			customerSearchRet.Kana				= customerSearchWork.Kana;
            customerSearchRet.Snm               = customerSearchWork.CustomerSnm;
			customerSearchRet.SearchTelNo		= customerSearchWork.SearchTelNo;
			customerSearchRet.HomeTelNo			= customerSearchWork.HomeTelNo;
			customerSearchRet.OfficeTelNo		= customerSearchWork.OfficeTelNo;
			customerSearchRet.PortableTelNo		= customerSearchWork.PortableTelNo;
	
			customerSearchRet.PostNo = customerSearchWork.PostNo;
			customerSearchRet.Address1 = customerSearchWork.Address1;
			customerSearchRet.Address3 = customerSearchWork.Address3;
			customerSearchRet.Address4 = customerSearchWork.Address4;
			customerSearchRet.TotalDay = customerSearchWork.TotalDay;
			customerSearchRet.LogicalDeleteCode = customerSearchWork.LogicalDeleteCode;
			customerSearchRet.AcceptWholeSale = customerSearchWork.AcceptWholeSale;
            customerSearchRet.MngSectionCode = customerSearchWork.MngSectionCode;

            // --- ADD 2008/09/04 -------------------------------->>>>>
            customerSearchRet.UpdateDate = customerSearchWork.UpdateDateTime;
            // --- ADD 2008/09/04 --------------------------------<<<<<
            // ADD 2009/06/08 ------>>>
            customerSearchRet.CustomerEpCode = customerSearchWork.CustomerEpCode;
            customerSearchRet.CustomerSecCode = customerSearchWork.CustomerSecCode;
            // ADD 2009/06/08 ------<<<
            // --- ADD 2009/06/19 -------------------------------->>>>>
            customerSearchRet.CustomerAgentCd = customerSearchWork.CustomerAgentCd;
            // --- ADD 2009/06/19 --------------------------------<<<<<
////////////////////////////////////////////// 2012.04.10 TERASAKA ADD STA //
			customerSearchRet.CustomerAgentNm = customerSearchWork.CustomerAgentNm;
// 2012.04.10 TERASAKA ADD END //////////////////////////////////////////////
            // --- ADD 2009/02/12 -------------------------------->>>>>
            customerSearchRet.CustomerSlipNoDiv = customerSearchWork.CustomerSlipNoDiv;
            // --- ADD 2009/02/12 --------------------------------<<<<<

            // 2009/12/02 Add >>>
            customerSearchRet.HomeFaxNo = customerSearchWork.HomeFaxNo;
            customerSearchRet.OfficeFaxNo = customerSearchWork.OfficeFaxNo;
            // 2009/12/02 Add <<<

            customerSearchRet.OnlineKindDiv = customerSearchWork.OnlineKindDiv; // 2010/04/06 Add

            // ADD 2010/06/26 SCM：IDExchangeサービスの変更に伴う対応 ---------->>>>>
            customerSearchRet.SimplInqAcntAcntGrId = customerSearchWork.SimplInqAcntAcntGrId;
            // ADD 2010/06/26 SCM：IDExchangeサービスの変更に伴う対応 ----------<<<<<

			return customerSearchRet;
		}


		/// <summary>
		/// クラスメンバーコピー処理（得意先車両検索条件クラス⇒得意先車両検索ワーククラス）
		/// </summary>
        /// <param name="customerSearchPara">得意先車両検索条件クラス</param>
		/// <returns>得意先車両検索ワーククラス</returns>
		/// <remarks>
		/// <br>Note       : 得意先車両検索条件クラスから得意先車両検索ワーククラスへメンバーのコピーを行います。</br>
		/// <br>Programmer : 95089 徳永 誠</br>
		/// <br>Date       : 2005.03.28</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: 2010/08/06 朱 猛</br>
        /// <br>             PM1012A:電話番号検索追加と伴う修正</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>------------------------------------------------------------------------------------</br>
        /// <br>Update Note: 2011/07/22 徐錦山</br>
        /// <br>             PM1107C:得意先略称表示列と検索追加(#826)</br>
        /// <br>------------------------------------------------------------------------------------</br>
		/// </remarks>
		private CustomerSearchParaWork CopyToParamDataFromUIData(CustomerSearchPara customerSearchPara)
		{
			CustomerSearchParaWork customerSearchParaWork = new CustomerSearchParaWork();

			customerSearchParaWork.EnterpriseCode = customerSearchPara.EnterpriseCode;
			customerSearchParaWork.CustomerCode = customerSearchPara.CustomerCode;
			customerSearchParaWork.CustomerSubCode = customerSearchPara.CustomerSubCode;
			customerSearchParaWork.Kana = customerSearchPara.Kana;
			customerSearchParaWork.SearchTelNo = customerSearchPara.SearchTelNo;
			customerSearchParaWork.CustomerSubCodeSearchType = customerSearchPara.CustomerSubCodeSearchType;
			customerSearchParaWork.KanaSearchType = customerSearchPara.KanaSearchType;
			customerSearchParaWork.CustAnalysCode1 = customerSearchPara.CustAnalysCode1;
			customerSearchParaWork.CustAnalysCode2 = customerSearchPara.CustAnalysCode2;
			customerSearchParaWork.CustAnalysCode3 = customerSearchPara.CustAnalysCode3;
			customerSearchParaWork.CustAnalysCode4 = customerSearchPara.CustAnalysCode4;
			customerSearchParaWork.CustAnalysCode5 = customerSearchPara.CustAnalysCode5;
			customerSearchParaWork.CustAnalysCode6 = customerSearchPara.CustAnalysCode6;
			customerSearchParaWork.CustomerAgentCd = customerSearchPara.CustomerAgentCd;
			customerSearchParaWork.BillCollecterCd = customerSearchPara.BillCollecterCd;
			customerSearchParaWork.AcceptWholeSale = customerSearchPara.AcceptWholeSale;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            customerSearchParaWork.MngSectionCode = customerSearchPara.MngSectionCode;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // 2009/12/02 Add >>>
            customerSearchParaWork.Name = customerSearchPara.Name;
            customerSearchParaWork.NameSearchType = customerSearchPara.NameSearchType;
            // 2009/12/02 Add <<<

            // ---ADD 2010/08/06-------------------->>>
            customerSearchParaWork.TelNum = customerSearchPara.TelNum;
            customerSearchParaWork.TelNumSearchType = customerSearchPara.TelNumSearchType;
            // ---ADD 2010/08/06--------------------<<<
            //-----ADD PCC自社用得意先ガイド追加 for #23705 on 2011.08.19 ----->>>>>
            customerSearchParaWork.PccuoeMode = customerSearchPara.PccuoeMode;
            //-----ADD PCC自社用得意先ガイド追加 for #23705 on 2011.08.19 -----<<<<<
            // 2011/7/22 XUJS ADD STA>>>>>>
            customerSearchParaWork.CustomerSnm = customerSearchPara.CustomerSnm;
            customerSearchParaWork.CustomerSnmSearchType = customerSearchPara.CustomerSnmSearchType;
            // 2011/7/22 XUJS ADD END<<<<<<

			return customerSearchParaWork;
		}
	}
}

using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Reflection;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Xml.Serialization;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 得意先別売上目標マスタアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note	   : 得意先別売上目標マスタへのアクセス制御を行います。</br>
    /// <br>Programmer : 30167 上野　弘貴</br>
    /// <br>Date	   : 2007.11.21</br>
    /// <br></br>
    /// </remarks>
    public class CustSalesTargetAcs
    {
        #region Public EnumerationTypes
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// オンラインモードの列挙型です。
        /// </summary>
        /// <remarks>
        /// <br>Note	   : </br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date	   : 2007.11.21</br>
        /// </remarks>
        public enum OnlineMode
        {
            /// <summary>オフライン</summary>
            Offline,
            /// <summary>オンライン</summary>
            Online
        }
        #endregion

        #region Private Member

        /// <summary>リモートオブジェクト格納バッファ</summary>
        private ICustSalesTargetDB _iCustSalesTargetDB = null;

        #endregion Private Member

        #region Constructor
        /// <summary>
        /// 目標マスタアクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note	   : リモートオブジェクトをインスタンス化します。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date	   : 2007.11.21</br>
        /// </remarks>
        public CustSalesTargetAcs()
        {
            // オンラインの場合
            if (LoginInfoAcquisition.OnlineFlag)
            {
                try
                {
                    // リモートオブジェクト取得
                    this._iCustSalesTargetDB = (ICustSalesTargetDB)MediationCustSalesTargetDB.GetCustSalesTargetDB();
                }
                catch (Exception)
                {
                    // オフライン時はnullをセット
                    this._iCustSalesTargetDB = null;
                }
            }
            else
            // オフラインの場合
            {
                // オフライン時はnullをセット
                this._iCustSalesTargetDB = null;
            }
        }
        #endregion Constructor

        #region Public Methods
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// オンラインモード取得処理
        /// </summary>
        /// <returns>OnlineMode</returns>
        /// <remarks>
        /// <br>Note	   : オンラインモードを取得します。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date	   : 2007.11.21</br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if (this._iCustSalesTargetDB == null)
            {
                return (int)OnlineMode.Offline;
            }
            else
            {
                return (int)OnlineMode.Online;
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 登録・更新処理
        /// </summary>
        /// <param name="custSalesTarget">UIデータクラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note	   : 登録・更新処理を行います。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date	   : 2007.11.21</br>
        /// </remarks>
        public int Write(ref List<CustSalesTarget> custSalesTargetList)
        {
			CustSalesTargetWork custSalesTargetWork;
			ArrayList paraList = new ArrayList();

			// UIデータクラス→ワーク
			foreach (CustSalesTarget custSalesTarget in custSalesTargetList)
			{
				custSalesTargetWork = CopyToCustSalesTargetWorkFromCustSalesTarget(custSalesTarget);
				paraList.Add(custSalesTargetWork);
			}

			object paraobj = paraList;

			int status = 0;
			try
			{
				// 書き込み処理
			    status = this._iCustSalesTargetDB.Write(ref paraobj);
				if (status != 0)
				{
					return (status);
				}

			    // ワーク→UIデータクラス
			    paraList = (ArrayList)paraobj;
			    CustSalesTarget custSalesTarget2;
			    custSalesTargetList.Clear();
			    foreach (CustSalesTargetWork custSalesTargetWork2 in paraList)
			    {
			        custSalesTarget2 = CopyToCustSalesTargetFromCustSalesTargetWork(custSalesTargetWork2);
			        custSalesTargetList.Add(custSalesTarget2);
			    }

                return (0);

			}
			catch (Exception ex)
			{
				// 通信エラーは-1を戻す
				string err = ex.Message;
				return (-1);
			}
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 削除処理
        /// </summary>
        /// <param name="custSalesTarget">UIデータクラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note	   : 削除処理を行います。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date	   : 2007.11.21</br>
        /// </remarks>
        public int Delete(List<CustSalesTarget> custSalesTargetList)
        {
			CustSalesTargetWork[] custSalesTargetWorkList;
			custSalesTargetWorkList = new CustSalesTargetWork[custSalesTargetList.Count];

			// UIデータクラス→ワーク
			for (int index = 0; index < custSalesTargetList.Count; index++)
			{
				custSalesTargetWorkList[index] = CopyToCustSalesTargetWorkFromCustSalesTarget(custSalesTargetList[index]);
			}

			// XMLへ変換し、文字列のバイナリ化
			byte[] parabyte = XmlByteSerializer.Serialize(custSalesTargetWorkList);

			int status = 0;
			try
			{
				// 削除処理
			    status = this._iCustSalesTargetDB.Delete(parabyte);
				if (status != 0)
				{
					return (status);
				}

			    return (0);
			}
			catch (Exception)
			{
				// 通信エラーは-1を戻す
				return (-1);
			}
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="retList">リスト</param>
        /// <param name="extrInfo">検索条件</param>
        /// <param name="logicalMode">論理削除区分</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note	   : 検索処理を行います。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date	   : 2007.11.21</br>
        /// </remarks>
        public int Search(
            out List<CustSalesTarget> retList,
            ExtrInfo_DCKHN09193EA extrInfo,
            ConstantManagement.LogicalMode logicalMode)
        {
            int status;

            retList = new List<CustSalesTarget>();

            if (!LoginInfoAcquisition.OnlineFlag)
            {
                return ((int)ConstantManagement.DB_Status.ctDB_OFFLINE);
            }
            else
            {
                try
                {
                    // パラメータ
					SearchCustSalesTargetParaWork searchCustSalesTargetParaWork = new SearchCustSalesTargetParaWork();
					searchCustSalesTargetParaWork.EnterpriseCode = extrInfo.EnterpriseCode;
					searchCustSalesTargetParaWork.SelectSectCd = extrInfo.SelectSectCd;
					searchCustSalesTargetParaWork.AllSecSelEpUnit = extrInfo.AllSecSelEpUnit;
					searchCustSalesTargetParaWork.AllSecSelSecUnit = extrInfo.AllSecSelSecUnit;
					searchCustSalesTargetParaWork.TargetSetCd = extrInfo.TargetSetCd;
					searchCustSalesTargetParaWork.TargetContrastCd = extrInfo.TargetContrastCd;
					searchCustSalesTargetParaWork.TargetDivideCode = extrInfo.TargetDivideCode;
					searchCustSalesTargetParaWork.TargetDivideName = extrInfo.TargetDivideName;
					searchCustSalesTargetParaWork.BusinessTypeCode = extrInfo.BusinessTypeCode;
					searchCustSalesTargetParaWork.SalesAreaCode = extrInfo.SalesAreaCode;
					searchCustSalesTargetParaWork.CustomerCode = extrInfo.CustomerCode;
					searchCustSalesTargetParaWork.StartApplyStaDate = extrInfo.ApplyStaDateSt;
					searchCustSalesTargetParaWork.EndApplyStaDate = extrInfo.ApplyStaDateEd;
					searchCustSalesTargetParaWork.StartApplyEndDate = extrInfo.ApplyEndDateSt;
					searchCustSalesTargetParaWork.EndApplyEndDate = extrInfo.ApplyEndDateEd;

					// 目標マスタ検索
					object objectCustSalesTargetWork = null;
					status = this._iCustSalesTargetDB.Search(out objectCustSalesTargetWork, searchCustSalesTargetParaWork, 0, logicalMode);
					if (status != 0)
					{
						return (status);
					}

					// パラメータが渡って来ているか確認
					ArrayList paraList = objectCustSalesTargetWork as ArrayList;
					if (paraList == null)
					{
						return ((int)ConstantManagement.DB_Status.ctDB_ERROR);
					}

					// データ変換
					foreach (CustSalesTargetWork custSalesTargetWork in paraList)
					{
						retList.Add(CopyToCustSalesTargetFromCustSalesTargetWork(custSalesTargetWork));
					}
                }
                catch (Exception ex)
                {
                    string err = ex.Message;
                    return ((int)ConstantManagement.DB_Status.ctDB_ERROR);
                }

                return ((int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NORMAL);

            }
        }

        #endregion

        # region Private Methods

		///*----------------------------------------------------------------------------------*/
		/// <summary>
		/// クラスメンバーコピー処理（目標マスタワーククラス⇒目標マスタクラス）
		/// </summary>
		/// <param name="custSalesTargetWork">目標マスタワーククラス</param>
		/// <returns>目標マスタクラス</returns>
		/// <remarks>
		/// <br>Note	   : 目標マスタワーククラスから目標マスタクラスへメンバーのコピーを行います。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date	   : 2007.11.21</br>
		/// </remarks>
		private CustSalesTarget CopyToCustSalesTargetFromCustSalesTargetWork(CustSalesTargetWork custSalesTargetWork)
		{
			CustSalesTarget custSalesTarget = new CustSalesTarget();

			custSalesTarget.CreateDateTime = custSalesTargetWork.CreateDateTime;
			custSalesTarget.UpdateDateTime = custSalesTargetWork.UpdateDateTime;
			custSalesTarget.EnterpriseCode = custSalesTargetWork.EnterpriseCode;
			custSalesTarget.FileHeaderGuid = custSalesTargetWork.FileHeaderGuid;
			custSalesTarget.UpdEmployeeCode = custSalesTargetWork.UpdEmployeeCode;
			custSalesTarget.UpdAssemblyId1 = custSalesTargetWork.UpdAssemblyId1;
			custSalesTarget.UpdAssemblyId2 = custSalesTargetWork.UpdAssemblyId2;
			custSalesTarget.LogicalDeleteCode = custSalesTargetWork.LogicalDeleteCode;

			custSalesTarget.SectionCode = custSalesTargetWork.SectionCode;
			custSalesTarget.TargetSetCd = custSalesTargetWork.TargetSetCd;
			custSalesTarget.TargetContrastCd = custSalesTargetWork.TargetContrastCd;
			custSalesTarget.TargetDivideCode = custSalesTargetWork.TargetDivideCode;
			custSalesTarget.TargetDivideName = custSalesTargetWork.TargetDivideName;
			custSalesTarget.BusinessTypeCode = custSalesTargetWork.BusinessTypeCode;
			custSalesTarget.SalesAreaCode = custSalesTargetWork.SalesAreaCode;
			custSalesTarget.CustomerCode = custSalesTargetWork.CustomerCode;
			custSalesTarget.ApplyStaDate = custSalesTargetWork.ApplyStaDate;
			custSalesTarget.ApplyEndDate = custSalesTargetWork.ApplyEndDate;
			custSalesTarget.SalesTargetMoney = custSalesTargetWork.SalesTargetMoney;
			custSalesTarget.SalesTargetProfit = custSalesTargetWork.SalesTargetProfit;
			custSalesTarget.SalesTargetCount = custSalesTargetWork.SalesTargetCount;

			return custSalesTarget;
		}

        ///*----------------------------------------------------------------------------------*/
        /// <summary>
        /// クラスメンバーコピー処理（目標マスタクラス⇒目標マスタワーククラス）
        /// </summary>
        /// <param name="custSalesTarget">目標マスタクラス</param>
        /// <returns>目標マスタクラス</returns>
        /// <remarks>
        /// <br>Note	   : 目標マスタクラスから目標マスタワーククラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date	   : 2007.11.21</br>
        /// </remarks>
		private CustSalesTargetWork CopyToCustSalesTargetWorkFromCustSalesTarget(CustSalesTarget custSalesTarget)
		{
			CustSalesTargetWork custSalesTargetWork = new CustSalesTargetWork();

			custSalesTargetWork.CreateDateTime = custSalesTarget.CreateDateTime;
			custSalesTargetWork.UpdateDateTime = custSalesTarget.UpdateDateTime;
			custSalesTargetWork.EnterpriseCode = custSalesTarget.EnterpriseCode;
			custSalesTargetWork.FileHeaderGuid = custSalesTarget.FileHeaderGuid;
			custSalesTargetWork.UpdEmployeeCode = custSalesTarget.UpdEmployeeCode;
			custSalesTargetWork.UpdAssemblyId1 = custSalesTarget.UpdAssemblyId1;
			custSalesTargetWork.UpdAssemblyId2 = custSalesTarget.UpdAssemblyId2;
			custSalesTargetWork.LogicalDeleteCode = custSalesTarget.LogicalDeleteCode;

			custSalesTargetWork.SectionCode = custSalesTarget.SectionCode;
			custSalesTargetWork.TargetSetCd = custSalesTarget.TargetSetCd;
			custSalesTargetWork.TargetContrastCd = custSalesTarget.TargetContrastCd;
			custSalesTargetWork.TargetDivideCode = custSalesTarget.TargetDivideCode;
			custSalesTargetWork.TargetDivideName = custSalesTarget.TargetDivideName;
			custSalesTargetWork.BusinessTypeCode = custSalesTarget.BusinessTypeCode;
			custSalesTargetWork.SalesAreaCode = custSalesTarget.SalesAreaCode;
			custSalesTargetWork.CustomerCode = custSalesTarget.CustomerCode;
			custSalesTargetWork.ApplyStaDate = custSalesTarget.ApplyStaDate;
			custSalesTargetWork.ApplyEndDate = custSalesTarget.ApplyEndDate;
			custSalesTargetWork.SalesTargetMoney = custSalesTarget.SalesTargetMoney;
			custSalesTargetWork.SalesTargetProfit = custSalesTarget.SalesTargetProfit;
			custSalesTargetWork.SalesTargetCount = custSalesTarget.SalesTargetCount;

			return custSalesTargetWork;
		}

        #endregion
    }
}

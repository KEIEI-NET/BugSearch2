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
    /// 従業員別売上目標マスタアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note	   : 従業員別売上目標マスタへのアクセス制御を行います。</br>
    /// <br>Programmer : NEPCO</br>
    /// <br>Date	   : 2007.05.08</br>
    /// <br></br>
    /// <br>UpdateNote: 2007.10.01 鈴木 正臣</br>
    /// <br>            流通.DC用に変更。（項目追加・削除）</br>
	/// <br>            2007.11.21 上野 弘貴</br>
	/// <br>            従業員別売上目標修正（項目追加・削除）</br>
    /// </remarks>
    public class EmpSalesTargetAcs
    {
        #region Public EnumerationTypes
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// オンラインモードの列挙型です。
        /// </summary>
        /// <remarks>
        /// <br>Note	   : </br>
        /// <br>Programmer : NEPCO</br>
        /// <br>Date	   : 2007.05.08</br>
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

        ///// <summary>リモートオブジェクト格納バッファ</summary>
        private IEmpSalesTargetDB _iEmpSalesTargetDB = null;

        #endregion Private Member

        #region Constructor
        /// <summary>
        /// 目標マスタアクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note	   : リモートオブジェクトをインスタンス化します。</br>
        /// <br>Programmer : NEPCO</br>
        /// <br>Date	   : 2007.05.08</br>
        /// </remarks>
        public EmpSalesTargetAcs()
        {
            // オンラインの場合
            if (LoginInfoAcquisition.OnlineFlag)
            {
                try
                {
                    // リモートオブジェクト取得
                    this._iEmpSalesTargetDB = (IEmpSalesTargetDB)MediationEmpSalesTargetDB.GetEmpSalesTargetDB();
                }
                catch (Exception)
                {
                    // オフライン時はnullをセット
                    this._iEmpSalesTargetDB = null;
                }
            }
            else
            // オフラインの場合
            {
                // オフライン時はnullをセット
                this._iEmpSalesTargetDB = null;
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
        /// <br>Programmer : NEPCO</br>
        /// <br>Date	   : 2007.05.08</br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if (this._iEmpSalesTargetDB == null)
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
        /// <param name="empSalesTarget">UIデータクラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note	   : 登録・更新処理を行います。</br>
        /// <br>Programmer : NEPCO</br>
        /// <br>Date	   : 2007.05.08</br>
        /// </remarks>
        public int Write(ref List<EmpSalesTarget> empSalesTargetList)
        {
            EmpSalesTargetWork empSalesTargetWork;
            ArrayList paraList = new ArrayList();

            // UIデータクラス→ワーク
            foreach (EmpSalesTarget empSalesTarget in empSalesTargetList)
            {
                empSalesTargetWork = CopyToEmpSalesTargetWorkFromEmpSalesTarget(empSalesTarget);
                paraList.Add(empSalesTargetWork);
            }

            object paraobj = paraList;

            int status = 0;
            try
            {
                // 書き込み処理
                status = this._iEmpSalesTargetDB.Write(ref paraobj);
                if (status != 0)
                {
                    return (status);
                }

                // ワーク→UIデータクラス
                paraList = (ArrayList)paraobj;
                EmpSalesTarget empSalesTarget2;
                empSalesTargetList.Clear();
                foreach (EmpSalesTargetWork empSalesTargetWork2 in paraList)
                {
                    empSalesTarget2 = CopyToEmpSalesTargetFromEmpSalesTargetWork(empSalesTargetWork2);
                    empSalesTargetList.Add(empSalesTarget2);
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
        /// <param name="empSalesTarget">UIデータクラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note	   : 削除処理を行います。</br>
        /// <br>Programmer : NEPCO</br>
        /// <br>Date	   : 2007.05.08</br>
        /// </remarks>
        public int Delete(List<EmpSalesTarget> empSalesTargetList)
        {
            EmpSalesTargetWork [] empSalesTargetWorkList;
            empSalesTargetWorkList = new EmpSalesTargetWork[empSalesTargetList.Count];

            // UIデータクラス→ワーク
            for (int index = 0; index < empSalesTargetList.Count; index++)
            {
                empSalesTargetWorkList[index] = CopyToEmpSalesTargetWorkFromEmpSalesTarget(empSalesTargetList[index]);
            }

            // XMLへ変換し、文字列のバイナリ化
            byte[] parabyte = XmlByteSerializer.Serialize(empSalesTargetWorkList);

            int status = 0;
            try
            {
                // 書き込み処理
                status = this._iEmpSalesTargetDB.Delete(parabyte);
                if (status != 0)
                {
                    return (status);
                }
                // static削除

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
        /// <br>Programmer : NEPCO</br>
        /// <br>Date	   : 2007.05.08</br>
        /// </remarks>
        public int Search(
            out List<EmpSalesTarget> retList,
            ExtrInfo_MAMOK09117EA extrInfo,
            ConstantManagement.LogicalMode logicalMode)
        {
            int status;

            retList = new List<EmpSalesTarget>();

            if (!LoginInfoAcquisition.OnlineFlag)
            {
                return ((int)ConstantManagement.DB_Status.ctDB_OFFLINE);
            }
            else
            {
                try
                {
                    // パラメータ
                    SearchEmpSalesTargetParaWork searchEmpSalesTargetParaWork = new SearchEmpSalesTargetParaWork();
                    searchEmpSalesTargetParaWork.EnterpriseCode = extrInfo.EnterpriseCode;
                    searchEmpSalesTargetParaWork.SelectSectCd = extrInfo.SelectSectCd;
                    searchEmpSalesTargetParaWork.AllSecSelEpUnit = extrInfo.AllSecSelEpUnit;
                    searchEmpSalesTargetParaWork.AllSecSelSecUnit = extrInfo.AllSecSelSecUnit;
                    searchEmpSalesTargetParaWork.TargetSetCd = extrInfo.TargetSetCd;
                    searchEmpSalesTargetParaWork.TargetContrastCd = extrInfo.TargetContrastCd;
                    searchEmpSalesTargetParaWork.TargetDivideCode = extrInfo.TargetDivideCode;
                    searchEmpSalesTargetParaWork.TargetDivideName = extrInfo.TargetDivideName;
                    searchEmpSalesTargetParaWork.StartApplyStaDate = extrInfo.ApplyStaDateSt;
                    searchEmpSalesTargetParaWork.EndApplyStaDate = extrInfo.ApplyStaDateEd;
                    searchEmpSalesTargetParaWork.StartApplyEndDate = extrInfo.ApplyEndDateSt;
                    searchEmpSalesTargetParaWork.EndApplyEndDate = extrInfo.ApplyEndDateEd;
                    searchEmpSalesTargetParaWork.EmployeeCode = extrInfo.EmployeeCode;
					//----- ueno add---------- start 2007.11.21
					searchEmpSalesTargetParaWork.EmployeeDivCd = extrInfo.EmployeeDivCd;
					//----- ueno add---------- end   2007.11.21
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                    searchEmpSalesTargetParaWork.SubSectionCode = extrInfo.SubSectionCode;
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.07 TOKUNAGA DEL START
                    //searchEmpSalesTargetParaWork.MinSectionCode = extrInfo.MinSectionCode;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.07 TOKUNAGA DEL END
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

                    // 目標マスタ検索
                    object objectEmpSalesTargetWork = null;
                    status = this._iEmpSalesTargetDB.Search(out objectEmpSalesTargetWork, searchEmpSalesTargetParaWork, 0, logicalMode);
                    if (status != 0)
                    {
                        return (status);
                    }

                    // パラメータが渡って来ているか確認
                    ArrayList paraList = objectEmpSalesTargetWork as ArrayList;
                    if (paraList == null)
                    {
                        return ((int)ConstantManagement.DB_Status.ctDB_ERROR);
                    }

                    // データ変換
                    foreach (EmpSalesTargetWork empSalesTargetWork in paraList)
                    {
//----- ueno add---------- start 2007.11.21
						// 目標対比区分が「0」の場合、従業員のみを設定する（「10:拠点」以外を設定）
						if ((extrInfo.TargetContrastCd == 0)&&(empSalesTargetWork.TargetContrastCd == 10))
						{
							continue;
						}
//----- ueno add---------- end   2007.11.21

                        retList.Add(CopyToEmpSalesTargetFromEmpSalesTargetWork(empSalesTargetWork));
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

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// クラスメンバーコピー処理（目標マスタワーククラス⇒目標マスタクラス）
        /// </summary>
        /// <param name="empSalesTargetWork">目標マスタワーククラス</param>
        /// <returns>目標マスタクラス</returns>
        /// <remarks>
        /// <br>Note	   : 目標マスタワーククラスから目標マスタクラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : NEPCO</br>
        /// <br>Date	   : 2007.05.08</br>
        /// </remarks>
        private EmpSalesTarget CopyToEmpSalesTargetFromEmpSalesTargetWork(EmpSalesTargetWork empSalesTargetWork)
        {
            EmpSalesTarget empSalesTarget = new EmpSalesTarget();

            empSalesTarget.CreateDateTime = empSalesTargetWork.CreateDateTime;
            empSalesTarget.UpdateDateTime = empSalesTargetWork.UpdateDateTime;
            empSalesTarget.EnterpriseCode = empSalesTargetWork.EnterpriseCode;
            empSalesTarget.FileHeaderGuid = empSalesTargetWork.FileHeaderGuid;
            empSalesTarget.UpdEmployeeCode = empSalesTargetWork.UpdEmployeeCode;
            empSalesTarget.UpdAssemblyId1 = empSalesTargetWork.UpdAssemblyId1;
            empSalesTarget.UpdAssemblyId2 = empSalesTargetWork.UpdAssemblyId2;
            empSalesTarget.LogicalDeleteCode = empSalesTargetWork.LogicalDeleteCode;

            empSalesTarget.SectionCode = empSalesTargetWork.SectionCode;
            empSalesTarget.TargetSetCd = empSalesTargetWork.TargetSetCd;
            empSalesTarget.TargetContrastCd = empSalesTargetWork.TargetContrastCd;
            empSalesTarget.TargetDivideCode = empSalesTargetWork.TargetDivideCode;
            empSalesTarget.TargetDivideName = empSalesTargetWork.TargetDivideName;
			//----- ueno add---------- start 2007.11.21
			empSalesTarget.EmployeeDivCd = empSalesTargetWork.EmployeeDivCd;
			//----- ueno add---------- end   2007.11.21
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            empSalesTarget.SubSectionCode = empSalesTargetWork.SubSectionCode;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.07 TOKUNAGA DEL START
            //empSalesTarget.MinSectionCode = empSalesTargetWork.MinSectionCode;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.07 TOKUNAGA DEL END
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            empSalesTarget.EmployeeCode = empSalesTargetWork.EmployeeCode;
            empSalesTarget.EmployeeName = empSalesTargetWork.EmployeeName;
            empSalesTarget.ApplyStaDate = empSalesTargetWork.ApplyStaDate;
            empSalesTarget.ApplyEndDate = empSalesTargetWork.ApplyEndDate;
            empSalesTarget.SalesTargetMoney = empSalesTargetWork.SalesTargetMoney;
            empSalesTarget.SalesTargetProfit = empSalesTargetWork.SalesTargetProfit;
            empSalesTarget.SalesTargetCount = empSalesTargetWork.SalesTargetCount;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //empSalesTarget.WeekdayRatio = empSalesTargetWork.WeekdayRatio;
            //empSalesTarget.SatSunRatio = empSalesTargetWork.SatSunRatio;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            return empSalesTarget;
        }

        ///*----------------------------------------------------------------------------------*/
        /// <summary>
        /// クラスメンバーコピー処理（目標マスタクラス⇒目標マスタワーククラス）
        /// </summary>
        /// <param name="empSalesTarget">目標マスタクラス</param>
        /// <returns>目標マスタクラス</returns>
        /// <remarks>
        /// <br>Note	   : 目標マスタクラスから目標マスタワーククラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : NEPCO</br>
        /// <br>Date	   : 2007.05.08</br>
        /// </remarks>
        private EmpSalesTargetWork CopyToEmpSalesTargetWorkFromEmpSalesTarget(EmpSalesTarget empSalesTarget)
        {
            EmpSalesTargetWork empSalesTargetWork = new EmpSalesTargetWork();

            empSalesTargetWork.CreateDateTime = empSalesTarget.CreateDateTime;
            empSalesTargetWork.UpdateDateTime = empSalesTarget.UpdateDateTime;
            empSalesTargetWork.EnterpriseCode = empSalesTarget.EnterpriseCode;
            empSalesTargetWork.FileHeaderGuid = empSalesTarget.FileHeaderGuid;
            empSalesTargetWork.UpdEmployeeCode = empSalesTarget.UpdEmployeeCode;
            empSalesTargetWork.UpdAssemblyId1 = empSalesTarget.UpdAssemblyId1;
            empSalesTargetWork.UpdAssemblyId2 = empSalesTarget.UpdAssemblyId2;
            empSalesTargetWork.LogicalDeleteCode = empSalesTarget.LogicalDeleteCode;

            empSalesTargetWork.SectionCode = empSalesTarget.SectionCode;
            empSalesTargetWork.TargetSetCd = empSalesTarget.TargetSetCd;
            empSalesTargetWork.TargetContrastCd = empSalesTarget.TargetContrastCd;
            empSalesTargetWork.TargetDivideCode = empSalesTarget.TargetDivideCode;
            empSalesTargetWork.TargetDivideName = empSalesTarget.TargetDivideName;
			//----- ueno add---------- start 2007.11.21
			empSalesTargetWork.EmployeeDivCd = empSalesTarget.EmployeeDivCd;
			//----- ueno add---------- end   2007.11.21
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            empSalesTargetWork.SubSectionCode = empSalesTarget.SubSectionCode;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.07 TOKUNAGA DEL START
            //empSalesTargetWork.MinSectionCode = empSalesTarget.MinSectionCode;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.07 TOKUNAGA DEL END
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            empSalesTargetWork.EmployeeCode = empSalesTarget.EmployeeCode;
            empSalesTargetWork.EmployeeName = empSalesTarget.EmployeeName;
            empSalesTargetWork.ApplyStaDate = empSalesTarget.ApplyStaDate;
            empSalesTargetWork.ApplyEndDate = empSalesTarget.ApplyEndDate;
            empSalesTargetWork.SalesTargetMoney = empSalesTarget.SalesTargetMoney;
            empSalesTargetWork.SalesTargetProfit = empSalesTarget.SalesTargetProfit;
            empSalesTargetWork.SalesTargetCount = empSalesTarget.SalesTargetCount;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //empSalesTargetWork.WeekdayRatio = empSalesTarget.WeekdayRatio;
            //empSalesTargetWork.SatSunRatio = empSalesTarget.SatSunRatio;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            return empSalesTargetWork;
        }

        #endregion
    }
}

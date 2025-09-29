using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Xml.Serialization;
using System.Runtime.Remoting;
using System.Data;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// PCC全体設定マスタ アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : PCC全体設定マスタテーブルのアクセス制御を行います。</br>
    /// <br>Programmer : 葉巧燕</br>
    /// <br>Date       : 2011.08.01</br>
    /// <br></br>
    /// </remarks>
    public class PccTtlStAcs
    {
        #region Private Member

        /// <summary>リモートオブジェクト格納バッファ</summary>
        //PCC全体設定マスタ
        private IPccTtlStDB _iPccTtlStDB = null;
        private SecInfoSetAcs _secInfoSetAcs = null;
        private EmployeeAcs _employeeAcs = null;       
        private Hashtable _secInfoSetTable = null;

        private UserGuideAcs _userGuideAcs = null;
        private Hashtable _userGdBdTb = null;
        #endregion

        #region Constructor

        /// <summary>
        ///PCC全体設定マスタテーブルアクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       :PCC全体設定マスタテーブルアクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 葉巧燕</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        public PccTtlStAcs()
        {
            try
            {
                // リモートオブジェクト取得
                this._iPccTtlStDB = (IPccTtlStDB)MediationPccTtlStDB.GetPccTtlStDB();
                _secInfoSetAcs = new SecInfoSetAcs();
                _employeeAcs = new EmployeeAcs();
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iPccTtlStDB = null;
            }
        }

        #endregion

        #region Public Methods
       
        /// <summary>
        /// オンラインモード取得処理
        /// </summary>
        /// <returns>OnlineMode</returns>
        /// <remarks>
        /// <br>Note       : オンラインモードを取得します。</br>
        /// <br>Programmer : 葉巧燕</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if (this._iPccTtlStDB == null)
            {
                return (int)ConstantManagement.OnlineMode.Offline;
            }
            else
            {
                return (int)ConstantManagement.OnlineMode.Online;
            }
        }
      
        /// <summary>
        ///PCC全体設定マスタ読み込み処理
        /// </summary>
        /// <param name="pccTtlSt">UOE自社オブジェクト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       :PCC全体設定情報を読み込みます。</br>
        /// <br>Programmer : 葉巧燕</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        public int Read(out  PccTtlSt pccTtlSt, string enterpriseCode)
        {
            try
            {
                // キー情報の設定
                pccTtlSt = null;
                PccTtlStWork pccTtlStWork = new PccTtlStWork();
                pccTtlStWork.EnterpriseCode = enterpriseCode;
            
                //PCC全体設定ワーカークラスをオブジェクトに設定
                object paraObj = pccTtlStWork as object;

                //UOE自社マスタ読み込み
                int status = this._iPccTtlStDB.Read(ref paraObj, 0);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 読み込み結果をUOE自社ワーカークラスに設定
                    PccTtlStWork wkPccTtlStWork = (PccTtlStWork)paraObj;
                    //PCC全体設定ワーカークラスからUOE自社クラスにコピー
                    pccTtlSt = CopyToPccTtlStFromPccTtlStWork(wkPccTtlStWork);
                }

                return status;
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iPccTtlStDB = null;
                //通信エラーは-1を戻す
                pccTtlSt = null;
                return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
        }
             
        /// <summary>
        ///PCC全体設定登録・更新処理
        /// </summary>
        /// <param name="pccTtlSt">UOE自社クラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       :PCC全体設定の登録・更新を行います。</br>
        /// <br>Programmer : 葉巧燕</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        public int Write(ref PccTtlSt pccTtlSt)
        {
            PccTtlStWork pccTtlStWork = new PccTtlStWork();
            ArrayList paraList = new ArrayList();

            //PCC全体設定クラスからUOE自社ワーククラスにメンバコピー
            pccTtlStWork = CopyToPccTtlStWorkFromPccTtlSt(pccTtlSt);

            //PCC全体設定の登録・更新情報を設定
            paraList.Add(pccTtlStWork);

            object paraObj = paraList;

            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            try
            {               
                //PCC全体設定書き込み
                status = this._iPccTtlStDB.Write(ref paraObj);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    paraList = (ArrayList)paraObj;

                    pccTtlSt = new PccTtlSt();

                    //PCC全体設定ワーククラスからUOE自社クラスにメンバコピー
                    pccTtlSt = this.CopyToPccTtlStFromPccTtlStWork((PccTtlStWork)paraList[0]);
                }
            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iPccTtlStDB = null;
                // 通信エラーは-1を戻す
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }

            return status;
        }
    
        /// <summary>
        ///PCC全体設定登録・更新処理
        /// </summary>
        /// <param name="pccTtlStList">UOE自社クラス</param>
        /// <param name="parsePccTtlSt">企業コード</param>
        /// <param name="retTotalCnt">件数</param>
        /// <param name="readMode"></param>
        /// <param name="readCnt">件数</param>
        /// <param name="logicalMode">論理削除区分</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       :PCC全体設定の登録・更新を行います。</br>
        /// <br>Programmer : 葉巧燕</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        public int Search(ref List<PccTtlSt> pccTtlStList, PccTtlSt parsePccTtlSt, out int retTotalCnt, int readMode, int readCnt, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            pccTtlStList = null;            
            Object objpccTtlStWorkList = null;
            PccTtlStWork parsePccTtlStWork = null;
            ArrayList pccTtlStWorkResultList = null;
            List<PccTtlStWork> pccTtlStWorkList = null;

            retTotalCnt = 0;                   
            parsePccTtlStWork = new PccTtlStWork();
            parsePccTtlStWork.EnterpriseCode = parsePccTtlSt.EnterpriseCode;
            parsePccTtlStWork.SectionCode = parsePccTtlSt.SectionCode;
            //拠点名称処理
            if (_secInfoSetAcs == null)
            {
                _secInfoSetAcs = new SecInfoSetAcs();
            }
            ArrayList secInfoSetList = null;
            status = _secInfoSetAcs.Search(out secInfoSetList, parsePccTtlSt.EnterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && secInfoSetList != null)
            {
                this._secInfoSetTable = new Hashtable();
                foreach (SecInfoSet secInfoSet in secInfoSetList)
                {
                    this._secInfoSetTable.Add(secInfoSet.SectionCode, secInfoSet.SectionGuideSnm);

                }
            }
            // ユーザーガイド設定の納品区分の取得
            SetDelivereds(parsePccTtlSt.EnterpriseCode);
                //検索処理
           status = _iPccTtlStDB.Search(ref objpccTtlStWorkList, parsePccTtlStWork, readMode, logicalMode);

           if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
           {
               return status;
           }
           //結果を戻す
           pccTtlStWorkResultList = objpccTtlStWorkList as ArrayList;

           if (pccTtlStWorkResultList != null)
           {
               pccTtlStWorkList = new List<PccTtlStWork>((PccTtlStWork[])pccTtlStWorkResultList.ToArray(typeof(PccTtlStWork)));
           }
           if (pccTtlStWorkList != null)
           {
               pccTtlStList = new List<PccTtlSt>();
               foreach (PccTtlStWork pccTtlStWork in pccTtlStWorkList)
               {
                   if (pccTtlStWork.EnterpriseCode == parsePccTtlSt.EnterpriseCode &&
                       ((parsePccTtlSt.SectionCode == "") || (pccTtlStWork.SectionCode.TrimEnd() == parsePccTtlSt.SectionCode.TrimEnd()) || (pccTtlStWork.SectionCode.TrimEnd() == "")))
                   {
                       PccTtlSt pccTtlSt = null;
                       pccTtlSt = CopyToPccTtlStFromPccTtlStWork(pccTtlStWork);
                       pccTtlStList.Add(pccTtlSt);
                   }
               }
           }
           
            return status;
        }
    
        /// <summary>
        ///PCC全体設定登録・更新処理
        /// </summary>
        /// <param name="pccTtlSt">UOE自社クラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       :PCC全体設定の登録・更新を行います。</br>
        /// <br>Programmer : 葉巧燕</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        public int LogicalDelete(ref PccTtlSt pccTtlSt) 
        {

            ArrayList paraList = new ArrayList();
            PccTtlStWork pccTtlStWork = new PccTtlStWork();

            //PCC全体設定クラスからUOE自社ワーククラスにメンバコピー
            pccTtlStWork = CopyToPccTtlStWorkFromPccTtlSt(pccTtlSt);

            paraList.Add(pccTtlStWork);

            Object objpccTtlStWorkList = paraList;
           
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
  
              
            // 論理削除処理
            status = _iPccTtlStDB.LogicalDelete(ref objpccTtlStWorkList);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {

                paraList = (ArrayList)objpccTtlStWorkList;

                pccTtlSt = new PccTtlSt();

                //PCC全体設定ワーククラスからUOE自社クラスにメンバコピー
                pccTtlSt = this.CopyToPccTtlStFromPccTtlStWork((PccTtlStWork)paraList[0]);

                return status;
            }               
            return status;
        }
    
        /// <summary>
        ///PCC全体設定登録・更新処理
        /// </summary>
        /// <param name="pccTtlSt">UOE自社クラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       :PCC全体設定の登録・更新を行います。</br>
        /// <br>Programmer : 葉巧燕</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        public int Delete(ref PccTtlSt pccTtlSt)
        {

            PccTtlStWork pccTtlStWork = new PccTtlStWork();

            ArrayList paraList = new ArrayList();

            //PCC全体設定クラスからUOE自社ワーククラスにメンバコピー
            pccTtlStWork = CopyToPccTtlStWorkFromPccTtlSt(pccTtlSt);

            paraList.Add(pccTtlStWork);

            Object objpccTtlStWorkList = paraList;

            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        
            //物理削除処理
            status = _iPccTtlStDB.Delete(ref objpccTtlStWorkList);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                paraList = (ArrayList)objpccTtlStWorkList;

                pccTtlSt = new PccTtlSt();

                //PCC全体設定ワーククラスからUOE自社クラスにメンバコピー
                pccTtlSt = this.CopyToPccTtlStFromPccTtlStWork((PccTtlStWork)paraList[0]);

                return status;
            }

            return status;
        }
    
        /// <summary>
        ///PCC全体設定登録・更新処理
        /// </summary>
        /// <param name="pccTtlSt">UOE自社クラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       :PCC全体設定の登録・更新を行います。</br>
        /// <br>Programmer : 葉巧燕</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        public int RevivalLogicalDelete(ref PccTtlSt pccTtlSt)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            PccTtlStWork pccTtlStWork = new PccTtlStWork();

            ArrayList paraList = new ArrayList();

            //PCC全体設定クラスからUOE自社ワーククラスにメンバコピー
            pccTtlStWork = CopyToPccTtlStWorkFromPccTtlSt(pccTtlSt);

            paraList.Add(pccTtlStWork);

            Object objpccTtlStWorkList = paraList;
          
            //復活処理
            status = _iPccTtlStDB.RevivalLogicalDelete(ref objpccTtlStWorkList);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                paraList = (ArrayList)objpccTtlStWorkList;

                pccTtlSt = new PccTtlSt();

                //PCC全体設定ワーククラスからUOE自社クラスにメンバコピー
                pccTtlSt = this.CopyToPccTtlStFromPccTtlStWork((PccTtlStWork)paraList[0]);

                return status;
            }       

            return status;
        }
      
        #endregion

        #region Private Methods

        /// <summary>
        /// クラスメンバーコピー処理（UOE自社ワーククラス⇒UOE自社クラス）
        /// </summary>
        /// <param name="pccTtlStWork">UOE自社ワーククラス</param>
        /// <returns>UOE自社クラス</returns>
        /// <remarks>
        /// <br>Note       :PCC全体設定ワーククラスからUOE自社クラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 葉巧燕</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        private PccTtlSt CopyToPccTtlStFromPccTtlStWork(PccTtlStWork pccTtlStWork)
        {
            PccTtlSt pccTtlSt = new PccTtlSt();
            pccTtlSt.CreateDateTime = pccTtlStWork.CreateDateTime;
            pccTtlSt.UpdateDateTime = pccTtlStWork.UpdateDateTime;
            pccTtlSt.EnterpriseCode = pccTtlStWork.EnterpriseCode;
            pccTtlSt.FileHeaderGuid = pccTtlStWork.FileHeaderGuid;
            pccTtlSt.UpdEmployeeCode = pccTtlStWork.UpdEmployeeCode;
            pccTtlSt.UpdAssemblyId1 = pccTtlStWork.UpdAssemblyId1;
            pccTtlSt.UpdAssemblyId2 = pccTtlStWork.UpdAssemblyId2;
            pccTtlSt.LogicalDeleteCode = pccTtlStWork.LogicalDeleteCode;
            //拠点コード
            pccTtlSt.SectionCode = pccTtlStWork.SectionCode;

            string sectionName = string.Empty;
            if (this._secInfoSetTable != null && this._secInfoSetTable.ContainsKey(pccTtlStWork.SectionCode))
            {
                sectionName = (string)this._secInfoSetTable[pccTtlStWork.SectionCode];
            }
            pccTtlSt.SectionName = sectionName;
            pccTtlSt.FrontEmployeeCd = pccTtlStWork.FrontEmployeeCd.Trim();                                
            pccTtlSt.DeliveredGoodsDiv = pccTtlStWork.DeliveredGoodsDiv;
            pccTtlSt.DeliveredGoodsNm = GetDeliveredName(pccTtlStWork.DeliveredGoodsDiv);
            pccTtlSt.SalesSlipPrtDiv = pccTtlStWork.SalesSlipPrtDiv;                      
            pccTtlSt.SalesSlipPrtNm = GetNameFromDiv(pccTtlStWork.SalesSlipPrtDiv); 
            pccTtlSt.AcpOdrrSlipPrtDiv = pccTtlStWork.AcpOdrrSlipPrtDiv;                  
            pccTtlSt.AcpOdrrSlipPrtNm = GetNameFromDiv(pccTtlStWork.AcpOdrrSlipPrtDiv);                    

            return pccTtlSt;
        }
     
        /// <summary>
        /// クラスメンバーコピー処理（UOE自社クラス⇒UOE自社ワーククラス）
        /// </summary>
        /// <param name="pccTtlSt">UOE自社ワーククラス</param>
        /// <returns>UOE自社クラス</returns>
        /// <remarks>
        /// <br>Note       :PCC全体設定クラスからUOE自社ワーククラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 葉巧燕</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        private PccTtlStWork CopyToPccTtlStWorkFromPccTtlSt(PccTtlSt pccTtlSt)
        {
            PccTtlStWork pccTtlStWork = new PccTtlStWork();

            pccTtlStWork.CreateDateTime = pccTtlSt.CreateDateTime;
            pccTtlStWork.UpdateDateTime = pccTtlSt.UpdateDateTime;
            pccTtlStWork.EnterpriseCode = pccTtlSt.EnterpriseCode;
            pccTtlStWork.FileHeaderGuid = pccTtlSt.FileHeaderGuid;
            pccTtlStWork.UpdEmployeeCode = pccTtlSt.UpdEmployeeCode;
            pccTtlStWork.UpdAssemblyId1 = pccTtlSt.UpdAssemblyId1;
            pccTtlStWork.UpdAssemblyId2 = pccTtlSt.UpdAssemblyId2;
            pccTtlStWork.LogicalDeleteCode = pccTtlSt.LogicalDeleteCode;
            pccTtlStWork.SectionCode = pccTtlSt.SectionCode;
            pccTtlStWork.SectionName = pccTtlSt.SectionName;            
            pccTtlStWork.FrontEmployeeCd = pccTtlSt.FrontEmployeeCd;                  
            pccTtlStWork.FrontEmployeeNm = pccTtlSt.FrontEmployeeNm;                 
            pccTtlStWork.DeliveredGoodsDiv = pccTtlSt.DeliveredGoodsDiv;             
            pccTtlStWork.SalesSlipPrtDiv = pccTtlSt.SalesSlipPrtDiv;                  
            pccTtlStWork.AcpOdrrSlipPrtDiv = pccTtlSt.AcpOdrrSlipPrtDiv;                          
            return pccTtlStWork;
        }      
      
        /// <summary>
        ///区分の名称の取得
        /// </summary>
        /// <param name="div">区分</param>
        /// <remarks>
        /// <br>Note		: 区分の名称の取得</br>
        /// <br>Programmer  : 葉巧燕</br>
        /// <br>Date        : 2011.08.01</br>
        /// </remarks>
        private string GetNameFromDiv(int div)
        {
            string name = string.Empty;
            switch (div)
            {
                case 0:
                    {
                        name = "しない";
                        break;
                    }
                case 1:
                    {
                        name = "する";
                        break;
                    }
            }
            return name;
        }
         
        /// <summary>
        /// クラスメンバーコピー処理（UOE自社ワーククラス⇒UOE自社クラス）
        /// </summary>
        /// <param name="guideRow">UOE自社ワーククラス</param>
        /// <param name="pccTtlSt">UOE自社ワーク</param>
        /// <returns>UOE自社クラス</returns>
        /// <remarks>
        /// <br>Note       :PCC全体設定ワーククラスからUOE自社クラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 葉巧燕</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        private void CopyToGuideRowFromSearchData(ref DataRow guideRow, PccTtlSt pccTtlSt)
        {
            # region [データからガイドにセット（自動生成）]
           
            # endregion
        }

        /// <summary>
        /// ユーザーガイド設定の納品区分の取得
        /// </summary>
        /// <remarks>
        /// <param name="enterpriseCode"> 企業コード</param>
        /// <br>Note       : ユーザーガイド設定の納品区分を取得します。</br>
        /// <br>Programmer : 葉巧燕</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        private void SetDelivereds(string enterpriseCode)
        {
            //ユーザーガイド設定の納品区分の取得
            ArrayList userGuidList = null;
            //納品区分の項目
            int userGuideDivCd = 48;
            if (this._userGuideAcs == null)
            {
                this._userGuideAcs = new UserGuideAcs();
            }
            this._userGuideAcs.SearchAllDivCodeBody(out userGuidList, enterpriseCode, userGuideDivCd, UserGuideAcsData.UserBodyData);
            _userGdBdTb = new Hashtable();
            if (userGuidList != null || userGuidList.Count > 0)
            {
                foreach (UserGdBd userGdBd in userGuidList)
                {
                    if (userGdBd.LogicalDeleteCode == 0)
                    {
                        if (!_userGdBdTb.ContainsKey(userGdBd.GuideCode))
                        {
                             _userGdBdTb.Add(userGdBd.GuideCode, userGdBd.GuideName);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 納品区分名称の取得
        /// </summary>
        /// <param name="deliveredGoodsDiv"> 納品区分</param>
        /// <remarks>
        /// <returns>納品区分名称</returns>
        /// <br>Note       : 納品区分名称を取得します。</br>
        /// <br>Programmer : 葉巧燕</br>
        /// <br>Date       : 2011.08.01</br>
        /// </remarks>
        private string GetDeliveredName(int deliveredGoodsDiv)
        {
            string deliveredName = string.Empty;
            if (this._userGdBdTb != null && this._userGdBdTb.ContainsKey(deliveredGoodsDiv))
            {
                deliveredName = (string)this._userGdBdTb[deliveredGoodsDiv];
            }
            return deliveredName;
        }
        #endregion
    }
}

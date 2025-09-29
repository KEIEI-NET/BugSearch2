//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : メールメッセージ設定処理
// プログラム概要   : メールメッセージ設定処理アクセスクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 黄海霞
// 作 成 日  2011.08.09  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using System.Runtime.Remoting;
using System.Collections;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// メールメッセージ設定処理アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : メールメッセージ設定処理ＵＩクラス</br>
    /// <br>Programmer : 黄海霞</br>
    /// <br>Date	   : 2011.08.09</br>
    /// </remarks>  
    public class PccMailDtAcs
    {
        /// <summary>
        /// リモートオブジェクトインターフェイス
        /// </summary>
        private IPccMailDtDB _iPccMailDtDB = null;

        #region ■ Constructor
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : メールメッセージ設定処理アクセスクラスの初期化を行う。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.09</br>
        /// </remarks>
        public PccMailDtAcs()
        {
            try
            {
                _iPccMailDtDB = MediationPccMailDtDB.GetPccMailDtDB();
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iPccMailDtDB = null;
            }
        }
        #endregion ■ Constructor

        #region ■ Public Method
        /// <summary>
        /// メールメッセージ設定処理登録、更新処理
        /// </summary>
        /// <param name="pccMailDtList">PCCメールデータリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : メールメッセージ設定処理登録、更新処理。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.09</br>
        /// </remarks>
        public int Write(ref  List<PccMailDt> pccMailDtList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            PccMailDtWork pccMailDtWork = null;
            ArrayList paraList = new ArrayList();
            foreach (PccMailDt pccMailDt in pccMailDtList)
            {
                pccMailDtWork = CopyToPccMailDtWorkFromPccMailDt(pccMailDt);

                // UOE自社の登録・更新情報を設定
                paraList.Add(pccMailDtWork);
            }
            object paraObj = paraList;
            try
            {
                
                //メールメッセージ設定処理登録、更新処理
                status = _iPccMailDtDB.Write(ref paraObj);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    paraList = (ArrayList)paraObj;
                    pccMailDtList = new List<PccMailDt>();
                    foreach (PccMailDtWork pccMailDtWorkResult in paraList)
                    {
                        PccMailDt pccMailDt = this.CopyToPccMailDtFromPccMailDtWork(pccMailDtWorkResult);
                        pccMailDtList.Add(pccMailDt);
                    }
                    return status;

                }
               

            }
            catch (Exception)
            {
                // オフライン時はnullをセット
                this._iPccMailDtDB = null;
                // 通信エラーは-1を戻す
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
          
            return status;
        }

        /// <summary>
        /// メールメッセージ設定検索処理
        /// </summary>
        /// <param name="pccMailDtDicDic">PCCメールデータリスト</param>
        /// <param name="parsePccMailDt">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : メールメッセージ設定検索処理。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.09</br>
        /// </remarks>
        public int Search(ref Dictionary<string, Dictionary<string ,PccMailDt>> pccMailDtDicDic, PccMailDt parsePccMailDt, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            pccMailDtDicDic = null;
            List<PccMailDt> pccMailList = null;
            status = Search(ref pccMailList, parsePccMailDt, readMode, logicalMode);
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status;
            }
            pccMailDtDicDic = new Dictionary<string, Dictionary<string, PccMailDt>>();
            string inqConditionFaPre = string.Empty;
            string inqConditionFa = string.Empty;
            string inqCondition = string.Empty;
            Dictionary<string, PccMailDt> pccMailDtDic = new Dictionary<string, PccMailDt>();
            foreach (PccMailDt pccMailDt in pccMailList)
            {
                inqConditionFa = pccMailDt.InqOriginalEpCd.Trim() + pccMailDt.InqOriginalSecCd.TrimEnd() //@@@@20230303
               + pccMailDt.InqOtherEpCd.TrimEnd() + pccMailDt.InqOtherSecCd.TrimEnd();
                inqCondition = pccMailDt.InqOriginalEpCd.Trim() + pccMailDt.InqOriginalSecCd.TrimEnd() //@@@@20230303
              + pccMailDt.InqOtherEpCd.TrimEnd() + pccMailDt.InqOtherSecCd.TrimEnd() + pccMailDt.UpdateDate + pccMailDt.UpdateTime;
                if (!inqConditionFaPre.Equals(inqConditionFa))
                {
                    if (!string.IsNullOrEmpty(inqConditionFaPre))
                    {
                        pccMailDtDicDic.Add(inqConditionFaPre, pccMailDtDic);
                    }
                    pccMailDtDic = new Dictionary<string, PccMailDt>();
                    pccMailDtDic.Add(inqCondition, pccMailDt);

                    inqConditionFaPre = inqConditionFa;
                }
                else
                {
                    pccMailDtDic.Add(inqCondition, pccMailDt);
                }
            }
            pccMailDtDicDic.Add(inqConditionFaPre, pccMailDtDic);



            return status;
        }

        /// <summary>
        /// メールメッセージ設定検索処理
        /// </summary>
        /// <param name="pccMailDtList">PCCメールデータリスト</param>
        /// <param name="parsePccMailDt">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : メールメッセージ設定検索処理。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.09</br>
        /// </remarks>
        public int Search(ref List<PccMailDt> pccMailDtList, PccMailDt parsePccMailDt, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            pccMailDtList = null;
            PccMailDtWork parsePccMailDtWork = null;
            Object objPccMailDtWorkList = null;
            ArrayList pccMailDtWorkListResultList = null;
            List<PccMailDtWork> pccMailDtWorkList = null;
            try
            {

                parsePccMailDtWork = CopyToPccMailDtWorkFromPccMailDt(parsePccMailDt);
                //メールメッセージ設定検索処理
                status = _iPccMailDtDB.Search(ref objPccMailDtWorkList, parsePccMailDtWork, readMode, logicalMode);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }

                //結果を戻す
                pccMailDtWorkListResultList = objPccMailDtWorkList as ArrayList;

                if (pccMailDtWorkListResultList != null)
                {
                    pccMailDtWorkList = new List<PccMailDtWork>((PccMailDtWork[])pccMailDtWorkListResultList.ToArray(typeof(PccMailDtWork)));
                }
                if (pccMailDtWorkList != null)
                {
                    pccMailDtList = new List<PccMailDt>();
                    foreach (PccMailDtWork pccMailDtWork in pccMailDtWorkList)
                    {
                        PccMailDt pccMailDt = CopyToPccMailDtFromPccMailDtWork(pccMailDtWork);
                        pccMailDtList.Add(pccMailDt);
                    }
                    
                }

            }
            catch (RemotingException)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }

            return status;
        }

        /// <summary>
        /// メールメッセージ設定検索処理
        /// </summary>
        /// <param name="pccMailDt">PCCメールデータリスト</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : メールメッセージ設定検索処理。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.09</br>
        /// </remarks>
        public int Read(ref PccMailDt pccMailDt, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            try
            {
            pccMailDt = null;
            PccMailDtWork pccMailDtWork = new PccMailDtWork();
          
            // UOE自社ワーカークラスをオブジェクトに設定
            object paraObj = pccMailDtWork as object;

          
                //メールメッセージ設定検索処理
              status = _iPccMailDtDB.Read(ref paraObj, readMode, logicalMode);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {


                    PccMailDtWork wkPccMailDtWork = (PccMailDtWork)paraObj;
                    // UOE自社ワーククラスからUOE自社クラスにメンバコピー
                    pccMailDt = this.CopyToPccMailDtFromPccMailDtWork(wkPccMailDtWork);

                    return status;
                }

               

            }
            catch (RemotingException)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }

            return status;
        }

        /// <summary>
        /// メールメッセージ設定論理削除処理
        /// </summary>
        /// <param name="pccMailDt">PCCメールデータリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : メールメッセージ設定論理削除処理。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.09</br>
        /// </remarks>
        public int LogicalDelete(ref PccMailDt pccMailDt)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            PccMailDtWork pccMailDtWork = new PccMailDtWork();

            ArrayList paraList = new ArrayList();
            // UOE自社の登録・更新情報を設定
            pccMailDtWork = CopyToPccMailDtWorkFromPccMailDt(pccMailDt);  
          
            paraList.Add(pccMailDtWork);
           
            Object objpccMailDtWorkList = paraList;
            
            try
            {
              

                //メールメッセージ設定論理削除処理
                status = _iPccMailDtDB.LogicalDelete(ref objpccMailDtWorkList);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    paraList = (ArrayList)objpccMailDtWorkList;

                    pccMailDt = new PccMailDt();

                    // UOE自社ワーククラスからUOE自社クラスにメンバコピー
                    pccMailDt = this.CopyToPccMailDtFromPccMailDtWork((PccMailDtWork)paraList[0]);

                    return status;
                }

             
            }
            catch (RemotingException)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }

            return status;
        }

        /// <summary>
        /// メールメッセージ設定物理削除処理
        /// </summary>
        /// <param name="pccMailDt">PCCメールデータリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : メールメッセージ設定物理削除処理。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.09</br>
        /// </remarks>
        public int Delete(ref PccMailDt pccMailDt)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            PccMailDtWork pccMailDtWork = new PccMailDtWork();

            
            ArrayList paraList = new ArrayList();

            // UOE自社の登録・更新情報を設定
            pccMailDtWork = CopyToPccMailDtWorkFromPccMailDt(pccMailDt);

            paraList.Add(pccMailDtWork);

            Object objpccMailDtWorkList = paraList;

            try
            {
                

                //メールメッセージ設定物理削除処理
                status = _iPccMailDtDB.Delete(ref objpccMailDtWorkList);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    paraList = (ArrayList)objpccMailDtWorkList;

                    pccMailDt = new PccMailDt();

                    // UOE自社ワーククラスからUOE自社クラスにメンバコピー
                    pccMailDt = this.CopyToPccMailDtFromPccMailDtWork((PccMailDtWork)paraList[0]);

                    return status;
                }

            }
            catch (RemotingException)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }

        /// <summary>
        /// メールメッセージ設定復活処理
        /// </summary>
        /// <param name="pccMailDtWorkList">PCCメールデータリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : メールメッセージ設定復活処理。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.09</br>
        /// </remarks>
        public int RevivalLogicalDelete(ref List<PccMailDtWork> pccMailDtWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            Object objPccMailDtWorkList = null;
            ArrayList pccMailDtWorkListResultList = null;

            try
            {
                if (pccMailDtWorkList != null)
                {
                    objPccMailDtWorkList = new ArrayList(pccMailDtWorkList.ToArray());
                }

                //メールメッセージ設定復活処理
                status = _iPccMailDtDB.RevivalLogicalDelete(ref objPccMailDtWorkList);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }

                //結果を戻す
                pccMailDtWorkListResultList = objPccMailDtWorkList as ArrayList;

                if (pccMailDtWorkListResultList != null)
                {
                    pccMailDtWorkList = new List<PccMailDtWork>((PccMailDtWork[])pccMailDtWorkListResultList.ToArray(typeof(PccMailDtWork)));
                }

            }
           catch (RemotingException)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }

            return status;
        }

        #endregion

        #region ■ Private Method
        /// <summary>
        ///  クラスメンバーコピー処理（UOE自社ワーククラス⇒UOE自社クラス）
        /// </summary>
        /// <param name="pccMailDt"></param>
        /// <returns>UOE自社クラス</returns>
        /// <remarks>
        /// <br>Note       : メールメッセージ設定復活処理。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.09</br>
        /// </remarks>
        private PccMailDtWork CopyToPccMailDtWorkFromPccMailDt(PccMailDt pccMailDt)
        {
            PccMailDtWork pccMailDtWork = new PccMailDtWork();
            pccMailDtWork.CreateDateTime = pccMailDt.CreateDateTime;
            pccMailDtWork.UpdateDateTime = pccMailDt.UpdateDateTime;
            pccMailDtWork.LogicalDeleteCode = pccMailDt.LogicalDeleteCode;
            pccMailDtWork.InqOriginalEpCd = pccMailDt.InqOriginalEpCd.Trim();//@@@@20230303
            pccMailDtWork.InqOriginalSecCd = pccMailDt.InqOriginalSecCd;
            pccMailDtWork.InqOtherEpCd = pccMailDt.InqOtherEpCd;
            pccMailDtWork.InqOtherSecCd = pccMailDt.InqOtherSecCd;
            pccMailDtWork.UpdateDate = pccMailDt.UpdateDate;
            pccMailDtWork.UpdateTime = pccMailDt.UpdateTime;
            pccMailDtWork.PccMailTitle = pccMailDt.PccMailTitle;
            pccMailDtWork.PccMailDocCnts = pccMailDt.PccMailDocCnts;
            pccMailDtWork.UpdateDateSt = pccMailDt.UpdateDateSt;
            pccMailDtWork.UpdateDateEd = pccMailDt.UpdateDateEd;
            return pccMailDtWork;
        }

        /// <summary>
        /// クラスメンバーコピー処理（UOE自社ワーククラス⇒UOE自社クラス）
        /// </summary>
        /// <param name="pccMailDtWork"></param>
        /// <returns>UOE自社クラス</returns>
        /// <remarks>
        /// <br>Note       : メールメッセージ設定復活処理。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.09</br>
        /// </remarks>
        private PccMailDt CopyToPccMailDtFromPccMailDtWork(PccMailDtWork pccMailDtWork)
        {
            PccMailDt pccMailDt = new PccMailDt();
            pccMailDt.CreateDateTime = pccMailDtWork.CreateDateTime;
            pccMailDt.UpdateDateTime = pccMailDtWork.UpdateDateTime;
            pccMailDt.LogicalDeleteCode = pccMailDtWork.LogicalDeleteCode;
            pccMailDt.InqOriginalEpCd = pccMailDtWork.InqOriginalEpCd.Trim();//@@@@20230303
            pccMailDt.InqOriginalSecCd = pccMailDtWork.InqOriginalSecCd;
            pccMailDt.InqOtherEpCd = pccMailDtWork.InqOtherEpCd;
            pccMailDt.InqOtherSecCd = pccMailDtWork.InqOtherSecCd;
            pccMailDt.UpdateDate = pccMailDtWork.UpdateDate;
            pccMailDt.UpdateTime = pccMailDtWork.UpdateTime;
            pccMailDt.PccMailTitle = pccMailDtWork.PccMailTitle;
            pccMailDt.PccMailDocCnts = pccMailDtWork.PccMailDocCnts;
            return pccMailDt;
        }
        #endregion
    }

}

//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : PCC自社設定マスタメンテ
// プログラム概要   : PCC自社設定マスタメンテアクセスクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 黄海霞
// 作 成 日  2011.08.04  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 湯上
// 修 正 日  2013/03/06  修正内容 : 2013/03/06配信　SCM障害№10342,10343対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 湯上
// 修 正 日  2013/09/13  修正内容 : SCM仕掛一覧№10571対応 参照倉庫コード追加
//----------------------------------------------------------------------------//
// 管理番号  11070147-00 作成担当 : 鄧潘ハン
// 作 成 日  2014/07/23  修正内容 : SCM仕掛一覧№10659の1現在庫数表示区分の追加     
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30746 高川 悟
// 修 正 日  2014/09/04  修正内容 : SCM仕掛一覧№10678対応　回答納期表示区分追加
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Collections;
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
    /// PCC自社設定マスタメンテアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : PCC自社設定マスタメンテＵＩクラス</br>
    /// <br>Programmer : 黄海霞</br>
    /// <br>Date	   : 2011.08.04</br>
    /// </remarks>  
    public class PccCmpnyStAcs
    {
        /// <summary>
        /// リモートオブジェクトインターフェイス
        /// </summary>
        private IPccCmpnyStDB _IPccCmpnyStDB = null;
        private CustomerInfoAcs _customerInfoAcs;
        //得意先
        private Hashtable _customerInfoTable;
        private const string CUSTOMEMPTY_BASE = "ベース設定";
        #region ■ Constructor
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : PCC自社設定マスタメンテアクセスクラスの初期化を行う。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.04</br>
        /// </remarks>
        public PccCmpnyStAcs()
        {
            _IPccCmpnyStDB = MediationPccCmpnyStDB.GetPccCmpnyStDB();
            _customerInfoAcs = new CustomerInfoAcs();
        }
        #endregion ■ Constructor

        /// <summary>
        /// PCC自社設定マスタメンテ登録、更新処理
        /// </summary>
        /// <param name="pccCmpnyStList">PCC自社設定データリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : PCC自社設定マスタメンテ登録、更新処理。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.04</br>
        /// </remarks>
        public int Write(ref List<PccCmpnySt> pccCmpnyStList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            Object objPccCmpnyStWorkList = null;
            ArrayList pccCmpnyStWorkResultList = null;

            try
            {
                if (pccCmpnyStList != null)
                {
                    this.CopyCmpnyStToWork(out pccCmpnyStWorkResultList, pccCmpnyStList);
                    objPccCmpnyStWorkList = pccCmpnyStWorkResultList as object;
                }

                //PCC自社設定マスタメンテ登録、更新処理
                status = _IPccCmpnyStDB.Write(ref objPccCmpnyStWorkList);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }

                //結果を戻す
                pccCmpnyStWorkResultList = objPccCmpnyStWorkList as ArrayList;

                if (pccCmpnyStWorkResultList != null)
                {
                    this.CopyWorkToCmpnySt(pccCmpnyStWorkResultList, out pccCmpnyStList);
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
        /// PCC自社設定マスタメンテ検索処理
        /// </summary>
        /// <param name="pccCmpnyStList">PCC自社設定データリスト</param>
        /// <param name="parsePccCmpnySt">検索パラメータ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : PCC自社設定マスタメンテ検索処理。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.04</br>
        /// </remarks>
        public int Search(out List<PccCmpnySt> pccCmpnyStList, PccCmpnySt parsePccCmpnySt, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            Object objPccCmpnyStWorkList = null;
            ArrayList pccCmpnyStWorkResultList = null;
            PccCmpnyStWork parsePccCmpnyStWork = null;
            pccCmpnyStList = null;
            try
            {
                if (parsePccCmpnySt != null)
                {
                    List<PccCmpnySt> pareCmpnyStWorkList = new List<PccCmpnySt>();
                    pareCmpnyStWorkList.Add(parsePccCmpnySt);
                    ArrayList parsePccCmpnyStWorkList = null;
                    this.CopyCmpnyStToWork(out parsePccCmpnyStWorkList, pareCmpnyStWorkList);
                    parsePccCmpnyStWork = parsePccCmpnyStWorkList[0] as PccCmpnyStWork;
                }
                else
                {
                    return status;
                }
                if (_customerInfoAcs == null)
                {
                    _customerInfoAcs = new CustomerInfoAcs();
                }
                List<CustomerInfo> customerInfoList = null;
                this._customerInfoTable = new Hashtable();
                CustomerInfo customerInfo0 = new CustomerInfo();
                customerInfo0.CustomerCode = 0;
                customerInfo0.CustomerSnm = CUSTOMEMPTY_BASE;
                this._customerInfoTable.Add(customerInfo0.CustomerCode, customerInfo0.CustomerSnm);
                
                status = _customerInfoAcs.Search(parsePccCmpnySt.InqOtherEpCd, true, true, out customerInfoList);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    foreach (CustomerInfo customerInfo in customerInfoList)
                    {
                        this._customerInfoTable.Add(customerInfo.CustomerCode, customerInfo.CustomerSnm);
                    }
                }
                //PCC自社設定マスタメンテ検索処理
                status = _IPccCmpnyStDB.Search(out objPccCmpnyStWorkList, parsePccCmpnyStWork, readMode, logicalMode);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }

                //結果を戻す
                pccCmpnyStWorkResultList = objPccCmpnyStWorkList as ArrayList;

                if (pccCmpnyStWorkResultList != null)
                {
                    this.CopyWorkToCmpnySt(pccCmpnyStWorkResultList, out pccCmpnyStList);
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
        /// PCC自社設定マスタメンテ検索処理
        /// </summary>
        /// <param name="pccCmpnySt">PCC自社設定データ</param>
        /// <param name="readMode">検索区分(現在未使用)</param>
        /// <param name="logicalMode">論理削除有無</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : PCC自社設定マスタメンテ検索処理。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.04</br>
        /// </remarks>
        public int Read(ref PccCmpnySt pccCmpnySt, int readMode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            Object objPccCmpnyStWork = null;
            PccCmpnyStWork wkPccCmpnyStWork = null;
            try
            {
                if (pccCmpnySt != null)
                {
                    wkPccCmpnyStWork = new PccCmpnyStWork();
                    //問合せ元企業コード
                    wkPccCmpnyStWork.InqOriginalEpCd = pccCmpnySt.InqOriginalEpCd.Trim();//@@@@20230303
                    //問合せ元拠点コード
                    wkPccCmpnyStWork.InqOriginalSecCd = pccCmpnySt.InqOriginalSecCd;
                    //問合せ先企業コード
                    wkPccCmpnyStWork.InqOtherEpCd = pccCmpnySt.InqOtherEpCd;
                    //問合せ先拠点コード
                    wkPccCmpnyStWork.InqOtherSecCd = pccCmpnySt.InqOtherSecCd;
                    //PCC自社コード
                    wkPccCmpnyStWork.PccCompanyCode = pccCmpnySt.PccCompanyCode;
                }
                objPccCmpnyStWork = wkPccCmpnyStWork;
                //PCC自社設定マスタメンテ検索処理
                status = _IPccCmpnyStDB.Read(ref objPccCmpnyStWork, readMode, logicalMode);


                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }

                //結果を戻す
                wkPccCmpnyStWork = objPccCmpnyStWork as PccCmpnyStWork;
                ArrayList pccCmpnyStWorkList = new ArrayList();
                pccCmpnyStWorkList.Add(wkPccCmpnyStWork);
                List<PccCmpnySt> pccCmpnyStList = null;
                this.CopyWorkToCmpnySt(pccCmpnyStWorkList, out pccCmpnyStList);
                pccCmpnySt = pccCmpnyStList[0];
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
        /// PCC自社設定マスタメンテ論理削除処理
        /// </summary>
        /// <param name="pccCmpnyStList">PCC自社設定データリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : PCC自社設定マスタメンテ論理削除処理。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.04</br>
        /// </remarks>
        public int LogicalDelete(ref List<PccCmpnySt> pccCmpnyStList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            Object objPccCmpnyStWorkList = null;
            ArrayList pccCmpnyStWorkResultList = null;

            try
            {
                if (pccCmpnyStList != null)
                {
                    this.CopyCmpnyStToWork(out pccCmpnyStWorkResultList, pccCmpnyStList);
                    objPccCmpnyStWorkList = pccCmpnyStWorkResultList as object;
                }

                //PCC自社設定マスタメンテ登録、更新処理
                status = _IPccCmpnyStDB.LogicalDelete(ref objPccCmpnyStWorkList);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }

                //結果を戻す
                pccCmpnyStWorkResultList = objPccCmpnyStWorkList as ArrayList;

                if (pccCmpnyStWorkResultList != null)
                {
                    this.CopyWorkToCmpnySt(pccCmpnyStWorkResultList, out pccCmpnyStList);
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
        /// PCC自社設定マスタメンテ物理削除処理
        /// </summary>
        /// <param name="pccCmpnyStList">PCC自社設定データリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : PCC自社設定マスタメンテ物理削除処理。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.04</br>
        /// </remarks>
        public int Delete(ref List<PccCmpnySt> pccCmpnyStList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            Object objPccCmpnyStWorkList = null;
            ArrayList pccCmpnyStWorkResultList = null;

            try
            {
                if (pccCmpnyStList != null)
                {
                    this.CopyCmpnyStToWork(out pccCmpnyStWorkResultList, pccCmpnyStList);
                    objPccCmpnyStWorkList = pccCmpnyStWorkResultList as object;
                }

                //PCC自社設定マスタメンテ登録、更新処理
                status = _IPccCmpnyStDB.Delete(ref objPccCmpnyStWorkList);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }

                //結果を戻す
                pccCmpnyStWorkResultList = objPccCmpnyStWorkList as ArrayList;

                if (pccCmpnyStWorkResultList != null)
                {
                    this.CopyWorkToCmpnySt(pccCmpnyStWorkResultList, out pccCmpnyStList);
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
        /// PCC自社設定マスタメンテ復活処理
        /// </summary>
        /// <param name="pccCmpnyStList">PCC自社設定データリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : PCC自社設定マスタメンテ復活処理。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.04</br>
        /// </remarks>
        public int RevivalLogicalDelete(ref List<PccCmpnySt> pccCmpnyStList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            Object objPccCmpnyStWorkList = null;
            ArrayList pccCmpnyStWorkResultList = null;

            try
            {
                if (pccCmpnyStList != null)
                {
                    this.CopyCmpnyStToWork(out pccCmpnyStWorkResultList, pccCmpnyStList);
                    objPccCmpnyStWorkList = pccCmpnyStWorkResultList as object;
                }

                //PCC自社設定マスタメンテ登録、更新処理
                status = _IPccCmpnyStDB.RevivalLogicalDelete(ref objPccCmpnyStWorkList);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }

                //結果を戻す
                pccCmpnyStWorkResultList = objPccCmpnyStWorkList as ArrayList;

                if (pccCmpnyStWorkResultList != null)
                {
                    this.CopyWorkToCmpnySt(pccCmpnyStWorkResultList, out pccCmpnyStList);
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

        #region Private Method
        /// <summary>
        /// PCC自社設定マスタメンテ転換処理
        /// </summary>
        /// <param name="pccCmpnyStWorkList">自社設定グループワークリスト</param>
        /// <param name="pccCmpnyStList">PCC自社設定データリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : PCC品目グループマスタメンテ転換処理。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.04</br>
        /// </remarks>
        private void CopyWorkToCmpnySt(ArrayList pccCmpnyStWorkList, out List<PccCmpnySt> pccCmpnyStList)
        {
            pccCmpnyStList = null;
            if (pccCmpnyStWorkList == null || pccCmpnyStWorkList.Count == 0)
            {
                return;
            }
            else
            {
                pccCmpnyStList = new List<PccCmpnySt>();
                foreach (PccCmpnyStWork wkPccCmpnyStWork in pccCmpnyStWorkList)
                {
                    PccCmpnySt pccCmpnySt = new PccCmpnySt();
                    //作成日時
                    pccCmpnySt.CreateDateTime = wkPccCmpnyStWork.CreateDateTime;
                    //更新日時
                    pccCmpnySt.UpdateDateTime = wkPccCmpnyStWork.UpdateDateTime;
                    //論理削除区分
                    pccCmpnySt.LogicalDeleteCode = wkPccCmpnyStWork.LogicalDeleteCode;
                    //問合せ元企業コード
                    pccCmpnySt.InqOriginalEpCd = wkPccCmpnyStWork.InqOriginalEpCd.Trim();//@@@@20230303
                    //問合せ元拠点コード
                    pccCmpnySt.InqOriginalSecCd = wkPccCmpnyStWork.InqOriginalSecCd;
                    //問合せ先企業コード
                    pccCmpnySt.InqOtherEpCd = wkPccCmpnyStWork.InqOtherEpCd;
                    //問合せ先拠点コード
                    pccCmpnySt.InqOtherSecCd = wkPccCmpnyStWork.InqOtherSecCd;
                    //PCC自社コード
                    pccCmpnySt.PccCompanyCode = wkPccCmpnyStWork.PccCompanyCode;
                    //PCC自社名称
                    string pccCompanyName = string.Empty;
                    if (this._customerInfoTable != null && this._customerInfoTable.ContainsKey(wkPccCmpnyStWork.PccCompanyCode))
                    {
                        pccCompanyName = this._customerInfoTable[wkPccCmpnyStWork.PccCompanyCode] as string;

                    }
                    pccCmpnySt.PccCompanyName = pccCompanyName;
                    //PCC倉庫コード
                    pccCmpnySt.PccWarehouseCd = wkPccCmpnyStWork.PccWarehouseCd;
                    //PCC優先倉庫コード1
                    pccCmpnySt.PccPriWarehouseCd1 = wkPccCmpnyStWork.PccPriWarehouseCd1;
                    //PCC優先倉庫コード2
                    pccCmpnySt.PccPriWarehouseCd2 = wkPccCmpnyStWork.PccPriWarehouseCd2;
                    //PCC優先倉庫コード3
                    pccCmpnySt.PccPriWarehouseCd3 = wkPccCmpnyStWork.PccPriWarehouseCd3;
                    //品番表示区分
                    pccCmpnySt.GoodsNoDspDiv = wkPccCmpnyStWork.GoodsNoDspDiv;
                    //品番表示名称
                    pccCmpnySt.GoodsNoDspDivName = getNameFromDiv(wkPccCmpnyStWork.GoodsNoDspDiv, 0);
                    //標準価格表示区分
                    pccCmpnySt.ListPrcDspDiv = wkPccCmpnyStWork.ListPrcDspDiv;
                    //標準価格表示名称
                    pccCmpnySt.ListPrcDspDivName = getNameFromDiv(wkPccCmpnyStWork.ListPrcDspDiv, 0);
                    //仕切価格表示区分
                    pccCmpnySt.CostDspDiv = wkPccCmpnyStWork.CostDspDiv;
                    //仕切価格表示名称
                    pccCmpnySt.CostDspDivName =  getNameFromDiv(wkPccCmpnyStWork.CostDspDiv, 0);
                    //棚番表示区分
                    pccCmpnySt.ShelfDspDiv = wkPccCmpnyStWork.ShelfDspDiv;
                    //棚番表示名称
                    pccCmpnySt.ShelfDspDivName =  getNameFromDiv(wkPccCmpnyStWork.ShelfDspDiv, 0);
                    //在庫表示区分
                    pccCmpnySt.StockDspDiv = wkPccCmpnyStWork.StockDspDiv;
                    //在庫表示名称
                    pccCmpnySt.StockDspDivName =  getNameFromDiv(wkPccCmpnyStWork.StockDspDiv, 0);
                    //コメント表示区分
                    pccCmpnySt.CommentDspDiv = wkPccCmpnyStWork.CommentDspDiv;
                    //コメント表示名称
                    pccCmpnySt.CommentDspDivName =  getNameFromDiv(wkPccCmpnyStWork.CommentDspDiv, 0);
                    //出荷数表示区分
                    pccCmpnySt.SpmtCntDspDiv = wkPccCmpnyStWork.SpmtCntDspDiv;
                    //出荷数表示名称
                    pccCmpnySt.SpmtCntDspDivName =  getNameFromDiv(wkPccCmpnyStWork.SpmtCntDspDiv, 0);
                    //受注数表示区分
                    pccCmpnySt.AcptCntDspDiv = wkPccCmpnyStWork.AcptCntDspDiv;
                    //受注数表示名称
                    pccCmpnySt.AcptCntDspDivName =  getNameFromDiv(wkPccCmpnyStWork.AcptCntDspDiv, 0);
                    //部品選択品番表示区分
                    pccCmpnySt.PrtSelGdNoDspDiv = wkPccCmpnyStWork.PrtSelGdNoDspDiv;
                    //部品選択品番表示名称
                    pccCmpnySt.PrtSelGdNoDspDivName =  getNameFromDiv(wkPccCmpnyStWork.PrtSelGdNoDspDiv, 0);
                    //部品選択標準価格表示区分
                    pccCmpnySt.PrtSelLsPrDspDiv = wkPccCmpnyStWork.PrtSelLsPrDspDiv;
                    //部品選択標準価格表示名称
                    pccCmpnySt.PrtSelLsPrDspDivName =  getNameFromDiv(wkPccCmpnyStWork.PrtSelLsPrDspDiv, 0);
                    //部品選択棚番表示区分
                    pccCmpnySt.PrtSelSelfDspDiv = wkPccCmpnyStWork.PrtSelSelfDspDiv;
                    //部品選択棚番表示名称
                    pccCmpnySt.PrtSelSelfDspDivName =  getNameFromDiv(wkPccCmpnyStWork.PrtSelSelfDspDiv, 0);
                    //部品選択在庫表示区分
                    pccCmpnySt.PrtSelStckDspDiv = wkPccCmpnyStWork.PrtSelStckDspDiv;
                    //部品選択在庫表示名称
                    pccCmpnySt.PrtSelStckDspDivName = getNameFromDiv(wkPccCmpnyStWork.PrtSelStckDspDiv, 0);
                    //在庫状況マーク1
                    pccCmpnySt.StckStMark1 = wkPccCmpnyStWork.StckStMark1;
                    //在庫状況マーク2
                    pccCmpnySt.StckStMark2 = wkPccCmpnyStWork.StckStMark2;
                    //在庫状況マーク3
                    pccCmpnySt.StckStMark3 = wkPccCmpnyStWork.StckStMark3;
                    //PCC発注先名称1
                    pccCmpnySt.PccSuplName1 = wkPccCmpnyStWork.PccSuplName1;
                    //PCC発注先名称2
                    pccCmpnySt.PccSuplName2 = wkPccCmpnyStWork.PccSuplName2;
                    //PCC発注先カナ名称
                    pccCmpnySt.PccSuplKana = wkPccCmpnyStWork.PccSuplKana;
                    //PCC発注先略称
                    pccCmpnySt.PccSuplSnm = wkPccCmpnyStWork.PccSuplSnm;
                    //PCC発注先郵便番号
                    pccCmpnySt.PccSuplPostNo = wkPccCmpnyStWork.PccSuplPostNo;
                    //PCC発注先住所1
                    pccCmpnySt.PccSuplAddr1 = wkPccCmpnyStWork.PccSuplAddr1;
                    //PCC発注先住所2
                    pccCmpnySt.PccSuplAddr2 = wkPccCmpnyStWork.PccSuplAddr2;
                    //PCC発注先住所3
                    pccCmpnySt.PccSuplAddr3 = wkPccCmpnyStWork.PccSuplAddr3;
                    //PCC発注先電話番号1
                    pccCmpnySt.PccSuplTelNo1 = wkPccCmpnyStWork.PccSuplTelNo1;
                    //PCC発注先電話番号2
                    pccCmpnySt.PccSuplTelNo2 = wkPccCmpnyStWork.PccSuplTelNo2;
                    //PCC発注先FAX番号
                    pccCmpnySt.PccSuplFaxNo = wkPccCmpnyStWork.PccSuplFaxNo;
                    //伝票発行区分（PCC）
                    pccCmpnySt.PccSlipPrtDiv = wkPccCmpnyStWork.PccSlipPrtDiv;
                    //伝票発行名称（PCC）
                    pccCmpnySt.PccSlipPrtDivName = getNameFromDiv(wkPccCmpnyStWork.PccSlipPrtDiv, 1);
                    //伝票再発行区分
                    pccCmpnySt.PccSlipRePrtDiv = wkPccCmpnyStWork.PccSlipRePrtDiv;
                    //伝票再発行名称
                    pccCmpnySt.PccSlipRePrtDivName = getNameFromDiv(wkPccCmpnyStWork.PccSlipRePrtDiv, 4);
                    //部品選択優良表示区分
                    pccCmpnySt.PrtSelPrmDspDiv = wkPccCmpnyStWork.PrtSelPrmDspDiv;
                    //部品選択優良表示名称
                    pccCmpnySt.PrtSelPrmDspDivName = getNameFromDiv(wkPccCmpnyStWork.PrtSelPrmDspDiv, 2);
                    //在庫状況表示区分
                    pccCmpnySt.StckStDspDiv = wkPccCmpnyStWork.StckStDspDiv;
                    //在庫状況表示名称
                    pccCmpnySt.StckStDspDivName = getNameFromDiv(wkPccCmpnyStWork.StckStDspDiv, 3);
                    //在庫コメント1
                    pccCmpnySt.StckStComment1 = wkPccCmpnyStWork.StckStComment1;
                    //在庫コメント2
                    pccCmpnySt.StckStComment2 = wkPccCmpnyStWork.StckStComment2;
                    //在庫コメント3
                    pccCmpnySt.StckStComment3 = wkPccCmpnyStWork.StckStComment3;

                    // ADD 2013/02/12 SCM障害№10342,10343対応 -------------------------------------------->>>>>
                    //倉庫表示区分(問合せ)
                    pccCmpnySt.WarehouseDspDiv = wkPccCmpnyStWork.WarehouseDspDiv;
                    //取消表示区分(問合せ)
                    pccCmpnySt.CancelDspDiv = wkPccCmpnyStWork.CancelDspDiv;
                    //品番表示区分(発注)
                    pccCmpnySt.GoodsNoDspDivOd = wkPccCmpnyStWork.GoodsNoDspDivOd;
                    //標準価格表示区分(発注)
                    pccCmpnySt.ListPrcDspDivOd = wkPccCmpnyStWork.ListPrcDspDivOd;
                    //仕切価格表示区分(発注)
                    pccCmpnySt.CostDspDivOd = wkPccCmpnyStWork.CostDspDivOd;
                    //棚番表示区分(発注)
                    pccCmpnySt.ShelfDspDivOd = wkPccCmpnyStWork.ShelfDspDivOd;
                    //在庫表示区分(発注)
                    pccCmpnySt.StockDspDivOd = wkPccCmpnyStWork.StockDspDivOd;
                    //コメント表示区分(発注)
                    pccCmpnySt.CommentDspDivOd = wkPccCmpnyStWork.CommentDspDivOd;
                    //出荷数表示区分(発注)
                    pccCmpnySt.SpmtCntDspDivOd = wkPccCmpnyStWork.SpmtCntDspDivOd;
                    //受注数表示区分(発注)
                    pccCmpnySt.AcptCntDspDivOd = wkPccCmpnyStWork.AcptCntDspDivOd;
                    //部品選択品番表示区分(発注)
                    pccCmpnySt.PrtSelGdNoDspDivOd = wkPccCmpnyStWork.PrtSelGdNoDspDivOd;
                    //部品選択標準価格表示区分(発注)
                    pccCmpnySt.PrtSelLsPrDspDivOd = wkPccCmpnyStWork.PrtSelLsPrDspDivOd;
                    //部品選択棚番表示区分(発注)
                    pccCmpnySt.PrtSelSelfDspDivOd = wkPccCmpnyStWork.PrtSelSelfDspDivOd;
                    //部品選択在庫表示区分(発注)
                    pccCmpnySt.PrtSelStckDspDivOd = wkPccCmpnyStWork.PrtSelStckDspDivOd;
                    //倉庫表示区分(発注)
                    pccCmpnySt.WarehouseDspDivOd = wkPccCmpnyStWork.WarehouseDspDivOd;
                    //取消表示区分(発注)
                    pccCmpnySt.CancelDspDivOd = wkPccCmpnyStWork.CancelDspDivOd;
                    //問合せ発注表示区分設定
                    pccCmpnySt.InqOdrDspDivSet = wkPccCmpnyStWork.InqOdrDspDivSet;

                    //倉庫表示区分名称(問合せ)
                    pccCmpnySt.WarehouseDspDivName = getNameFromDiv(wkPccCmpnyStWork.WarehouseDspDiv, 0);
                    //取消表示区分名称(問合せ)
                    pccCmpnySt.CancelDspDivName = getNameFromDiv(wkPccCmpnyStWork.CancelDspDiv, 0);
                    //品番表示区分名称(発注)
                    pccCmpnySt.GoodsNoDspDivOdName = getNameFromDiv(wkPccCmpnyStWork.GoodsNoDspDivOd, 0);
                    //標準価格表示区分名称(発注)
                    pccCmpnySt.ListPrcDspDivOdName = getNameFromDiv(wkPccCmpnyStWork.ListPrcDspDivOd, 0);
                    //仕切価格表示区分名称(発注)
                    pccCmpnySt.CostDspDivOdName = getNameFromDiv(wkPccCmpnyStWork.CostDspDivOd, 0);
                    //棚番表示区分名称(発注)
                    pccCmpnySt.ShelfDspDivOdName = getNameFromDiv(wkPccCmpnyStWork.ShelfDspDivOd, 0);
                    //在庫表示区分名称(発注)
                    pccCmpnySt.StockDspDivOdName = getNameFromDiv(wkPccCmpnyStWork.StockDspDivOd, 0);
                    //コメント表示区分名称(発注)
                    pccCmpnySt.CommentDspDivOdName = getNameFromDiv(wkPccCmpnyStWork.CommentDspDivOd, 0);
                    //出荷数表示区分名称(発注)
                    pccCmpnySt.SpmtCntDspDivOdName = getNameFromDiv(wkPccCmpnyStWork.SpmtCntDspDivOd, 0);
                    //受注数表示区分名称(発注)
                    pccCmpnySt.AcptCntDspDivOdName = getNameFromDiv(wkPccCmpnyStWork.AcptCntDspDivOd, 0);
                    //部品選択品番表示区分名称(発注)
                    pccCmpnySt.PrtSelGdNoDspDivOdName = getNameFromDiv(wkPccCmpnyStWork.PrtSelGdNoDspDivOd, 0);
                    //部品選択標準価格表示区分名称(発注)
                    pccCmpnySt.PrtSelLsPrDspDivOdName = getNameFromDiv(wkPccCmpnyStWork.PrtSelLsPrDspDivOd, 0);
                    //部品選択棚番表示区分名称(発注)
                    pccCmpnySt.PrtSelSelfDspDivOdName = getNameFromDiv(wkPccCmpnyStWork.PrtSelSelfDspDivOd, 0);
                    //部品選択在庫表示区分名称(発注)
                    pccCmpnySt.PrtSelStckDspDivOdName = getNameFromDiv(wkPccCmpnyStWork.PrtSelStckDspDivOd, 0);
                    //倉庫表示区分名称(発注)
                    pccCmpnySt.WarehouseDspDivOdName = getNameFromDiv(wkPccCmpnyStWork.WarehouseDspDivOd, 0);
                    //取消表示区分名称(発注)
                    pccCmpnySt.CancelDspDivOdName = getNameFromDiv(wkPccCmpnyStWork.CancelDspDivOd, 0);
                    //問合せ発注表示区分設定名称
                    pccCmpnySt.InqOdrDspDivSetName = getNameFromDiv(wkPccCmpnyStWork.InqOdrDspDivSet, 5);
                    // ADD 2013/02/12 SCM障害№10342,10343対応 --------------------------------------------<<<<<

                    // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------>>>>>
                    // PCC優先倉庫コード4
                    pccCmpnySt.PccPriWarehouseCd4 = wkPccCmpnyStWork.PccPriWarehouseCd4;
                    // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------<<<<<
                    // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 ----------------------->>>>>
                    //現在庫数表示区分(発注)
                    pccCmpnySt.PrsntStkCtDspDivOd = wkPccCmpnyStWork.PrsntStkCtDspDivOd;
                    //現在庫数表示区分(発注)名称
                    pccCmpnySt.PrsntStkCtDspDivOdName = getNameFromDiv(wkPccCmpnyStWork.PrsntStkCtDspDivOd, 6);
                    //現在庫数表示区分(問合せ)
                    pccCmpnySt.PrsntStkCtDspDiv = wkPccCmpnyStWork.PrsntStkCtDspDiv;
                    //現在庫数表示区分(問合せ)名称
                    pccCmpnySt.PrsntStkCtDspDivName = getNameFromDiv(wkPccCmpnyStWork.PrsntStkCtDspDiv, 6);
                    // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 -----------------------<<<<<
                    // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 -------------------->>>>>>>>>>
                    // 回答納期表示区分(問合せ)
                    pccCmpnySt.AnsDeliDtDspDiv = wkPccCmpnyStWork.AnsDeliDtDspDiv;
                    // 回答納期表示区分名称(問合せ)
                    pccCmpnySt.AnsDeliDtDspDivName = getNameFromDiv(wkPccCmpnyStWork.AnsDeliDtDspDiv, 0);
                    // 回答納期表示区分(発注)
                    pccCmpnySt.AnsDeliDtDspDivOd = wkPccCmpnyStWork.AnsDeliDtDspDivOd;
                    // 回答納期表示区分名称(発注)
                    pccCmpnySt.AnsDeliDtDspDivOdName = getNameFromDiv(wkPccCmpnyStWork.AnsDeliDtDspDivOd, 0);
                    // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 --------------------<<<<<<<<<<

                    pccCmpnyStList.Add(pccCmpnySt);
                }
            }
        }

        /// <summary>
        /// PCC自社設定マスタメンテ転換処理
        /// </summary>
        /// <param name="pccCmpnyStWorkList">PCC自社設定ワークリスト</param>
        /// <param name="pccCmpnyStList">PCC自社設定データリスト</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : PCC品目グループマスタメンテ転換処理。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.04</br>
        /// </remarks>
        private void CopyCmpnyStToWork(out ArrayList pccCmpnyStWorkList, List<PccCmpnySt> pccCmpnyStList)
        {
            pccCmpnyStWorkList = null;
            if (pccCmpnyStList == null || pccCmpnyStList.Count == 0)
            {
                return;
            }
            else
            {
                pccCmpnyStWorkList = new ArrayList();
                foreach (PccCmpnySt pccCmpnySt in pccCmpnyStList)
                {
                    PccCmpnyStWork wkPccCmpnyStWork = new PccCmpnyStWork();
                    //作成日時
                    wkPccCmpnyStWork.CreateDateTime = pccCmpnySt.CreateDateTime;
                    //更新日時
                    wkPccCmpnyStWork.UpdateDateTime = pccCmpnySt.UpdateDateTime;
                    //論理削除区分
                    wkPccCmpnyStWork.LogicalDeleteCode = pccCmpnySt.LogicalDeleteCode;
                    //問合せ元企業コード
                    wkPccCmpnyStWork.InqOriginalEpCd = pccCmpnySt.InqOriginalEpCd.Trim();//@@@@20230303
                    //問合せ元拠点コード
                    wkPccCmpnyStWork.InqOriginalSecCd = pccCmpnySt.InqOriginalSecCd;
                    //問合せ先企業コード
                    wkPccCmpnyStWork.InqOtherEpCd = pccCmpnySt.InqOtherEpCd;
                    //問合せ先拠点コード
                    wkPccCmpnyStWork.InqOtherSecCd = pccCmpnySt.InqOtherSecCd;
                    //PCC自社コード
                    wkPccCmpnyStWork.PccCompanyCode = pccCmpnySt.PccCompanyCode;
                    //PCC倉庫コード
                    wkPccCmpnyStWork.PccWarehouseCd = pccCmpnySt.PccWarehouseCd;
                    //PCC優先倉庫コード1
                    wkPccCmpnyStWork.PccPriWarehouseCd1 = pccCmpnySt.PccPriWarehouseCd1;
                    //PCC優先倉庫コード2
                    wkPccCmpnyStWork.PccPriWarehouseCd2 = pccCmpnySt.PccPriWarehouseCd2;
                    //PCC優先倉庫コード3
                    wkPccCmpnyStWork.PccPriWarehouseCd3 = pccCmpnySt.PccPriWarehouseCd3;
                    //品番表示区分
                    wkPccCmpnyStWork.GoodsNoDspDiv = pccCmpnySt.GoodsNoDspDiv;
                    //標準価格表示区分
                    wkPccCmpnyStWork.ListPrcDspDiv = pccCmpnySt.ListPrcDspDiv;
                    //仕切価格表示区分
                    wkPccCmpnyStWork.CostDspDiv = pccCmpnySt.CostDspDiv;
                    //棚番表示区分
                    wkPccCmpnyStWork.ShelfDspDiv = pccCmpnySt.ShelfDspDiv;
                    //在庫表示区分
                    wkPccCmpnyStWork.StockDspDiv = pccCmpnySt.StockDspDiv;
                    //コメント表示区分
                    wkPccCmpnyStWork.CommentDspDiv = pccCmpnySt.CommentDspDiv;
                    //出荷数表示区分
                    wkPccCmpnyStWork.SpmtCntDspDiv = pccCmpnySt.SpmtCntDspDiv;
                    //受注数表示区分
                    wkPccCmpnyStWork.AcptCntDspDiv = pccCmpnySt.AcptCntDspDiv;
                    //部品選択品番表示区分
                    wkPccCmpnyStWork.PrtSelGdNoDspDiv = pccCmpnySt.PrtSelGdNoDspDiv;
                    //部品選択標準価格表示区分
                    wkPccCmpnyStWork.PrtSelLsPrDspDiv = pccCmpnySt.PrtSelLsPrDspDiv;
                    //部品選択棚番表示区分
                    wkPccCmpnyStWork.PrtSelSelfDspDiv = pccCmpnySt.PrtSelSelfDspDiv;
                    //部品選択在庫表示区分
                    wkPccCmpnyStWork.PrtSelStckDspDiv = pccCmpnySt.PrtSelStckDspDiv;
                    //在庫状況マーク1
                    wkPccCmpnyStWork.StckStMark1 = pccCmpnySt.StckStMark1;
                    //在庫状況マーク2
                    wkPccCmpnyStWork.StckStMark2 = pccCmpnySt.StckStMark2;
                    //在庫状況マーク3
                    wkPccCmpnyStWork.StckStMark3 = pccCmpnySt.StckStMark3;
                    //PCC発注先名称1
                    wkPccCmpnyStWork.PccSuplName1 = pccCmpnySt.PccSuplName1;
                    //PCC発注先名称2
                    wkPccCmpnyStWork.PccSuplName2 = pccCmpnySt.PccSuplName2;
                    //PCC発注先カナ名称
                    wkPccCmpnyStWork.PccSuplKana = pccCmpnySt.PccSuplKana;
                    //PCC発注先略称
                    wkPccCmpnyStWork.PccSuplSnm = pccCmpnySt.PccSuplSnm;
                    //PCC発注先郵便番号
                    wkPccCmpnyStWork.PccSuplPostNo = pccCmpnySt.PccSuplPostNo;
                    //PCC発注先住所1
                    wkPccCmpnyStWork.PccSuplAddr1 = pccCmpnySt.PccSuplAddr1;
                    //PCC発注先住所2
                    wkPccCmpnyStWork.PccSuplAddr2 = pccCmpnySt.PccSuplAddr2;
                    //PCC発注先住所3
                    wkPccCmpnyStWork.PccSuplAddr3 = pccCmpnySt.PccSuplAddr3;
                    //PCC発注先電話番号1
                    wkPccCmpnyStWork.PccSuplTelNo1 = pccCmpnySt.PccSuplTelNo1;
                    //PCC発注先電話番号2
                    wkPccCmpnyStWork.PccSuplTelNo2 = pccCmpnySt.PccSuplTelNo2;
                    //PCC発注先FAX番号
                    wkPccCmpnyStWork.PccSuplFaxNo = pccCmpnySt.PccSuplFaxNo;
                    //伝票発行区分（PCC）
                    wkPccCmpnyStWork.PccSlipPrtDiv = pccCmpnySt.PccSlipPrtDiv;
                    //伝票再発行区分
                    wkPccCmpnyStWork.PccSlipRePrtDiv = pccCmpnySt.PccSlipRePrtDiv;
                    //部品選択優良表示区分
                    wkPccCmpnyStWork.PrtSelPrmDspDiv = pccCmpnySt.PrtSelPrmDspDiv;
                    //在庫状況表示区分
                    wkPccCmpnyStWork.StckStDspDiv = pccCmpnySt.StckStDspDiv;
                    //在庫コメント1
                    wkPccCmpnyStWork.StckStComment1 = pccCmpnySt.StckStComment1;
                    //在庫コメント2
                    wkPccCmpnyStWork.StckStComment2 = pccCmpnySt.StckStComment2;
                    //在庫コメント3
                    wkPccCmpnyStWork.StckStComment3 = pccCmpnySt.StckStComment3;

                    // ADD 2013/02/12 SCM障害№10342,10343対応 -------------------------------------------->>>>>
                    //倉庫表示区分(問合せ)
                    wkPccCmpnyStWork.WarehouseDspDiv = pccCmpnySt.WarehouseDspDiv;
                    //取消表示区分(問合せ)
                    wkPccCmpnyStWork.CancelDspDiv = pccCmpnySt.CancelDspDiv;
                    //品番表示区分(発注)
                    wkPccCmpnyStWork.GoodsNoDspDivOd = pccCmpnySt.GoodsNoDspDivOd;
                    //標準価格表示区分(発注)
                    wkPccCmpnyStWork.ListPrcDspDivOd = pccCmpnySt.ListPrcDspDivOd;
                    //仕切価格表示区分(発注)
                    wkPccCmpnyStWork.CostDspDivOd = pccCmpnySt.CostDspDivOd;
                    //棚番表示区分(発注)
                    wkPccCmpnyStWork.ShelfDspDivOd = pccCmpnySt.ShelfDspDivOd;
                    //在庫表示区分(発注)
                    wkPccCmpnyStWork.StockDspDivOd = pccCmpnySt.StockDspDivOd;
                    //コメント表示区分(発注)
                    wkPccCmpnyStWork.CommentDspDivOd = pccCmpnySt.CommentDspDivOd;
                    //出荷数表示区分(発注)
                    wkPccCmpnyStWork.SpmtCntDspDivOd = pccCmpnySt.SpmtCntDspDivOd;
                    //受注数表示区分(発注)
                    wkPccCmpnyStWork.AcptCntDspDivOd = pccCmpnySt.AcptCntDspDivOd;
                    //部品選択品番表示区分(発注)
                    wkPccCmpnyStWork.PrtSelGdNoDspDivOd = pccCmpnySt.PrtSelGdNoDspDivOd;
                    //部品選択標準価格表示区分(発注)
                    wkPccCmpnyStWork.PrtSelLsPrDspDivOd = pccCmpnySt.PrtSelLsPrDspDivOd;
                    //部品選択棚番表示区分(発注)
                    wkPccCmpnyStWork.PrtSelSelfDspDivOd = pccCmpnySt.PrtSelSelfDspDivOd;
                    //部品選択在庫表示区分(発注)
                    wkPccCmpnyStWork.PrtSelStckDspDivOd = pccCmpnySt.PrtSelStckDspDivOd;
                    //倉庫表示区分(発注)
                    wkPccCmpnyStWork.WarehouseDspDivOd = pccCmpnySt.WarehouseDspDivOd;
                    //取消表示区分(発注)
                    wkPccCmpnyStWork.CancelDspDivOd = pccCmpnySt.CancelDspDivOd;
                    //問合せ発注表示区分設定
                    wkPccCmpnyStWork.InqOdrDspDivSet = pccCmpnySt.InqOdrDspDivSet;
                    // ADD 2013/02/12 SCM障害№10342,10343対応 --------------------------------------------<<<<<

                    // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------>>>>>
                    //PCC優先倉庫コード4
                    wkPccCmpnyStWork.PccPriWarehouseCd4 = pccCmpnySt.PccPriWarehouseCd4;
                    // ADD 2013/09/13 SCM仕掛一覧№10571対応 ------------------------------------------<<<<<

                    // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 ----------------------->>>>>
                    //現在庫数表示区分(発注)
                    wkPccCmpnyStWork.PrsntStkCtDspDivOd = pccCmpnySt.PrsntStkCtDspDivOd;
                    //現在庫数表示区分(問合せ)
                    wkPccCmpnyStWork.PrsntStkCtDspDiv = pccCmpnySt.PrsntStkCtDspDiv;
                    // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 -----------------------<<<<<
                    // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 -------------------->>>>>>>>>>
                    // 回答納期表示区分(問合せ)
                    wkPccCmpnyStWork.AnsDeliDtDspDiv = pccCmpnySt.AnsDeliDtDspDiv;
                    // 回答納期表示区分(発注)
                    wkPccCmpnyStWork.AnsDeliDtDspDivOd = pccCmpnySt.AnsDeliDtDspDivOd;
                    // 2014/09/04 ADD TAKAGAWA SCM仕掛一覧№10678対応 --------------------<<<<<<<<<<

                    pccCmpnyStWorkList.Add(wkPccCmpnyStWork);
                }
            }

        }

        /// <summary>
        /// 区分から名称の取得処理
        /// </summary>
        /// <param name="div">区分</param>
        /// <param name="kind">種類(1:伝票発行区分（PCC）;2:部品選択優良表示区分;3:在庫状況表示区分;4:伝票再発行区分0:その他;)</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 区分から名称の取得処理を行う。</br>
        /// <br>Programmer : 黄海霞</br>
        /// <br>Date       : 2011.08.04</br>
        /// </remarks>
        private string getNameFromDiv(int div, int kind)
        {
            string name = string.Empty;
            switch (kind)
            {
                case 0:
                    {
                        switch (div)
                        {
                            case 0:
                                {
                                    name = "する";
                                    break;
                                }
                            case 1:
                                {
                                    name = "しない";
                                    break;
                                }
                        }
                      
                        break;
                    }
                //伝票発行区分（PCC）
                case 1:
                    {
                        switch (kind)
                        {
                            case 0:
                                {
                                    name = "しない";
                                    break;
                                }
                            case 1:
                                {
                                    name = "回答";
                                    break;
                                }
                            case 2:
                                {
                                    name = "ﾘﾓｰﾄ";
                                    break;
                                }
                            case 3:
                                {
                                    name = "両方";
                                    break;
                                }
                        }
                        break;
                    }
                //部品選択優良表示区分
                case 2:
                    {
                        switch (kind)
                        {
                            case 0:
                                {
                                    name = "全て";
                                    break;
                                }
                            case 1:
                                {
                                    name = "自社優先在庫";
                                    break;
                                }
                            case 2:
                                {
                                    name = "自社在庫";
                                    break;
                                }
                        }
                        break;
                    }
                case 3:
                    {
                        //在庫状況表示区分
                        switch (div)
                        {
                            case 0:
                                {
                                    name = "マーク";
                                    break;
                                }
                            case 1:
                                {
                                    name = "現在庫数";
                                    break;
                                }
                        }

                        break;
                    }
                case 4:
                    {
                        switch (div)
                        {
                            case 0:
                                {
                                    name = "する";
                                    break;
                                }
                            case 1:
                                {
                                    name = "しない";
                                    break;
                                }
                        }

                        break;
                    }
                // ADD 2013/02/12 SCM障害№10342,10343対応 -------------------------------------------->>>>>
                case 5:
                    {
                        switch (div)
                        {
                            case 0:
                                {
                                    name = "問合せ発注共通";
                                    break;
                                }
                            case 1:
                                {
                                    name = "問合せ発注個別";
                                    break;
                                }
                        }

                        break;
                    }
                // ADD 2013/02/12 SCM障害№10342,10343対応 --------------------------------------------<<<<<
                // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 ----------------------->>>>>
                case 6:
                    {
                        switch (div)
                        {
                            case 2:
                                {
                                    name = "数量・状況表示";
                                    break;
                                }
                            case 1:
                                {
                                    name = "状況表示";
                                    break;
                                }
                            case 0:
                                {
                                    name = "しない";
                                    break;
                                }
                        }

                        break;
                    }
                // ADD 2014/07/23 Redmine#43080の1現在庫数表示区分の追加 -----------------------<<<<<

            }
            return name;
        }
        #endregion

    }

}

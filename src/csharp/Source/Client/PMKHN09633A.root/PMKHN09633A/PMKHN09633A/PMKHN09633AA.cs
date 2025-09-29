//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : キャンペーン対象商品設定マスタ一括登録
// プログラム概要   : キャンペーン対象商品設定マスタ一括登録
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 鄧潘ハン
// 作 成 日  2011/05/20  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  10700008-00 作成担当 : 譚洪
// 修 正 日  2011/07/13  修正内容 : Redmine#22877 BLコード（開始）（終了）をやめて、単独指定に変更の修正
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Resources;
using System.Collections;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Common;
using System.Windows.Forms;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// キャンペーン対象商品設定マスタ一括登録 アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : キャンペーン対象商品設定マスタ一括登録 アクセスクラス</br>
    /// <br>Programmer : 鄧潘ハン</br>
    /// <br>Date       : 2011/05/20</br>
    /// <br>UpdateNote : 2011/07/13 譚洪 Redmine#22877 BLコード（開始）（終了）をやめて、単独指定に変更の修正</br>
    /// </remarks>
    public class CampaignGoodsStAcs
    {
        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region ■Private Members
        private static CampaignGoodsStAcs _rateQuoteInputAcs = null;
        private ICampaignLoginDB _campaignLoginDB = null;
        private GoodsAcs _goodsAcs = null;
        private CampaignLinkDataSet.CampaignLinkDataTable _campaignLinkDataTable;
        private CampaignLink _campaignLink = null;
       
        /// <summary>キャンペーン得意先リスト</summary>
        public ArrayList _precampaignLinkList = null;
        // 抽出中断フラグ
        private bool _extractCancelFlag;
        private IWin32Window _owner = null;
        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        private string _loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
        # endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region ■Constructor
        /// <summary>
        /// デフォルトコンストラクタ（Singletonデザインパターンを採用している為、privateとする）
        /// </summary>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/05/20</br>
        /// </remarks>
        private CampaignGoodsStAcs()
        {
            this._campaignLoginDB = MediationCampaignLoginDB.GetCampaignLoginDB();
            this._campaignLinkDataTable = new CampaignLinkDataSet.CampaignLinkDataTable();
            this._campaignLink = new CampaignLink();
            this._goodsAcs = new GoodsAcs();
            String retMessage = string.Empty;
            this._goodsAcs.IsLocalDBRead = false;
            this._goodsAcs.Owner = this._owner;
            this._goodsAcs.IsGetSupplier = true;
            this._goodsAcs.SearchInitial(this._enterpriseCode, this._loginSectionCode, out retMessage);

        }

        /// <summary>
        /// アクセスクラス インスタンス取得処理
        /// </summary>
        /// <returns>アクセスクラス インスタンス</returns>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/05/20</br>
        /// </remarks>
        public static CampaignGoodsStAcs GetInstance()
        {
            if (_rateQuoteInputAcs == null)
            {
                _rateQuoteInputAcs = new CampaignGoodsStAcs();
            }

            return _rateQuoteInputAcs;
        }
       

        #endregion

        // ===================================================================================== //
        // 属性
        // ===================================================================================== //
        # region ■Propertity
        /// <summary>
        /// UIデータ
        /// </summary>
        public CampaignLink CampaignLink
        {
            get { return this._campaignLink; }
        }

        /// <summary>
        /// テーブルプロパティ
        /// </summary>
        public CampaignLinkDataSet.CampaignLinkDataTable CampaignLinkDataTable
        {
            get { return _campaignLinkDataTable; }
        }

        /// <summary>
        /// 抽出中断フラグ
        /// </summary>
        public bool ExtractCancelFlag
        {
            get { return _extractCancelFlag; }
            set { _extractCancelFlag = value; }
        }
        #endregion

        // ===================================================================================== //
        // プライベートメソッド
        // ===================================================================================== //
        # region ■Private Methods

        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="campaignGoodsData">キャンペーン商品クラス</param>
        /// <param name="campaignLinkobjList">得意先のリスト</param>
        /// <param name="readCount">商品マスタの読込件数</param>
        /// <param name="addCount">キャンペーン管理マスタの追加件数(論理削除データを更新した場合も追加件数に加算する)</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : マスタ情報を検索します。</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/05/20</br>
        /// <br>UpdateNote : 2011/07/13 譚洪 Redmine#22877 BLコード（開始）（終了）をやめて、単独指定に変更の修正</br>
        /// </remarks>
        public int SearchData(CampaignGoodsData campaignGoodsData, ArrayList campaignLinkobjList, ref int readCount, ref int addCount)
        {
            int campaignLinkFlag = 1;

            string msg = "";

            // UIデータクラス→ワーク
            CampaignGoodsDataWork campaignGoodsDataWork = CopyToCampaignGoodsDataWorkFromCampaignGoodsData(campaignGoodsData);
            List<GoodsUnitData> goodsUnitDataList;
            PartsInfoDataSet partsInfoDataSet;

            // 抽出条件の作成
            GoodsCndtn goodsCndtn = new GoodsCndtn();
            goodsCndtn.EnterpriseCode =campaignGoodsData.EnterpriseCode ;
            goodsCndtn.GoodsMakerCd = campaignGoodsData.GoodsMakerCd;
            goodsCndtn.BLGoodsCode = campaignGoodsData.BLGoodsCode;  // ADD 2011/07/13 
            goodsCndtn.GoodsNo = campaignGoodsData.GoodsNoNoneHyphen;
            //goodsCndtn.GoodsNoSrchTyp = 1; // DEL 2011/07/13
            goodsCndtn.GoodsNoSrchTyp = 1;  // ADD 2011/07/13
            goodsCndtn.IsSettingSupplier = 1; 

            
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            int Flag = 0;
            try
            {
                ArrayList campaignGoodsDataWorkList = new ArrayList();
                object objcampaignGoodsDataWorkList = campaignGoodsDataWorkList as object;

                //ArrayList ptMkrPricePm =new ArrayList();   // DEL 2011/07/13 
                //object ptMkrPricePmobj = ptMkrPricePm as object;  // DEL 2011/07/13 

                ArrayList precampaignLinkWorkList = new ArrayList();
                ArrayList addcampaignLinkWorkList = new ArrayList();

                # region キャンペーン対象区分は１の場合、得意先のリストを生成する。

                if (campaignGoodsDataWork.CampaignObjDiv == 1)
                {
                    if (campaignLinkobjList == null)
                    {
                        addcampaignLinkWorkList = this._precampaignLinkList;
                    }
                    else
                    {
                        foreach (CampaignLinkWork campaignLink in campaignLinkobjList)
                        {
                            campaignLinkFlag = 1;
                            foreach (CampaignLinkWork precampaignLink in this._precampaignLinkList)
                            {
                                if (campaignLink.CustomerCode == precampaignLink.CustomerCode)
                                {
                                    campaignLinkFlag = 0;
                                    break;
                                }
                            }
                            if (campaignLinkFlag == 1 && campaignLinkobjList.Count>0)
                            {
                                campaignLink.LogicalDeleteCode = 1;
                            }
                            else
                            {
                                campaignLink.LogicalDeleteCode = 0;
                            }
                            precampaignLinkWorkList.Add(campaignLink);
                            addcampaignLinkWorkList.Add(campaignLink);
                        }

                        foreach (CampaignLinkWork precampaignLink in this._precampaignLinkList)
                        {
                            campaignLinkFlag = 1;
                            foreach (CampaignLinkWork addcampaignLink in precampaignLinkWorkList)
                            {
                                if (addcampaignLink.CustomerCode == precampaignLink.CustomerCode)
                                {
                                    campaignLinkFlag = 0;
                                    break;
                                }
                            }
                            if (campaignLinkFlag == 1)
                            {
                                addcampaignLinkWorkList.Add(precampaignLink);
                            }
                        }
                    }
                   
                }

                # endregion

                object objcampaignLinkList = addcampaignLinkWorkList as object;

                ArrayList campaignMngList = new ArrayList();
                object objcampaignMngList = campaignMngList as object;

                if (this._extractCancelFlag == true)
                {
                    return 0;
                }
                this._campaignLoginDB.Search(ref objcampaignGoodsDataWorkList, campaignGoodsDataWork);
                this._goodsAcs.SearchPartsOfNonGoodsNo(goodsCndtn, out partsInfoDataSet, out goodsUnitDataList, out msg);

                # region 商品マスタ(ユーザー)検索されたデータと部品価格マスタ(PM)(提供)検索されたデータは一括登録用のリストを作成する

                ArrayList campaignGoodsDataWorkListCom = objcampaignGoodsDataWorkList as ArrayList;
                //ArrayList ptMkrPricePmCom = ptMkrPricePmobj as ArrayList;  // DEL 2011/07/13 
                ArrayList campaignGoodsDataWorkLists = new ArrayList();

                foreach (GoodsUnitData goodsUnitData in goodsUnitDataList)
                {
                    GoodsUWork goodsUWorks = new GoodsUWork();

                    // ----- UPD 2011/07/13 ------- >>>>>>>>>
                    //if ((campaignGoodsData.BLGroupCodeSt == 0 && campaignGoodsData.BLGroupCodeEd == 0)
                    //    ||(campaignGoodsData.BLGroupCodeSt != 0 && campaignGoodsData.BLGroupCodeEd == 0 && goodsUnitData.BLGoodsCode >= campaignGoodsData.BLGroupCodeSt)
                    //    ||(campaignGoodsData.BLGroupCodeSt == 0 && campaignGoodsData.BLGroupCodeEd != 0 && goodsUnitData.BLGoodsCode <= campaignGoodsData.BLGroupCodeEd)
                    //    ||(campaignGoodsData.BLGroupCodeSt != 0 && campaignGoodsData.BLGroupCodeEd != 0 && goodsUnitData.BLGoodsCode <= campaignGoodsData.BLGroupCodeEd && goodsUnitData.BLGoodsCode >= campaignGoodsData.BLGroupCodeSt)
                    //  )
                    //{
                        goodsUWorks.GoodsNo = goodsUnitData.GoodsNo;
                        goodsUWorks.GoodsMakerCd = goodsUnitData.GoodsMakerCd;
                        campaignGoodsDataWorkLists.Add(goodsUWorks);
                    //}
                    // ----- UPD 2011/07/13 ------- <<<<<<<<<

                }

                foreach (GoodsUWork GoodsUWorks in campaignGoodsDataWorkListCom)
                {
                    Flag = -1;
                    //if (ptMkrPricePmCom.Count == 0)  // DEL 2011/07/13 
                    if (campaignGoodsDataWorkLists.Count == 0)  // ADD 2011/07/13 
                    {
                        campaignGoodsDataWorkLists = campaignGoodsDataWorkListCom;

                        break;
                    }
                    foreach (GoodsUnitData goodsUnitData in goodsUnitDataList)
                    {

                        if (goodsUnitData.GoodsNo == GoodsUWorks.GoodsNo)
                        {
                            Flag = 1;
                            break;
                        }

                    }
                    if (Flag == -1)
                    {
                        campaignGoodsDataWorkLists.Add(GoodsUWorks);
                    }

                }

                # endregion

                readCount = campaignGoodsDataWorkLists.Count;

                if (readCount > 0)
                {
                    status = 0;
                }
                else
                {
                    status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                }

                // 正常場合
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    
                    status = this._campaignLoginDB.Search(ref objcampaignMngList, campaignGoodsDataWork, 0);

                    ArrayList campaignMngLists = objcampaignMngList as ArrayList;
                    ArrayList addcampaignGoodsDataWorkList = new ArrayList();

                    foreach (GoodsUWork goodsUWork in campaignGoodsDataWorkLists)
                    {
                        Flag = -1;
                        if (campaignMngLists.Count == 0)
                        {
                            break;
                        }
                        foreach (CampaignObjGoodsStWork campaignMng in campaignMngLists)
                        {

                            if (goodsUWork.GoodsNo == campaignMng.GoodsNo)
                            {
                                if (campaignMng.LogicalDeleteCode == 1)
                                {
                                    goodsUWork.LogicalDeleteCode = 1;
                                    Flag = -1;
                                    break;

                                }
                                Flag = 1;
                                break;
                            }
                           
                        }
                        if (Flag == -1)
                        {
                            addcampaignGoodsDataWorkList.Add(goodsUWork);
                        }
                        
                    }

                    if (this._extractCancelFlag == true)
                    {
                        return 0;
                    }

                    if (campaignGoodsDataWorkLists.Count == 0 || campaignMngLists.Count == 0)
                    {
                        addCount = campaignGoodsDataWorkLists.Count;
                        if (addCount > 0)
                        {
                            object objcampaignGoodsDataWorkLists = campaignGoodsDataWorkLists as object;
                            status = this._campaignLoginDB.Write(objcampaignGoodsDataWorkLists, campaignGoodsDataWork, objcampaignLinkList);
                        }
                    }
                    else
                    {
                        addCount = addcampaignGoodsDataWorkList.Count;
                        if (addCount > 0)
                        {
                            object objcampaignGoodsDataWorkLists = addcampaignGoodsDataWorkList as object;
                            status = this._campaignLoginDB.Write(objcampaignGoodsDataWorkLists, campaignGoodsDataWork, objcampaignLinkList);
                        }
                    }
                    if (this._extractCancelFlag == true)
                    {
                        return 0;
                    }
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }

        /// <summary>
        /// キャンペーン設定データが読む
        /// </summary>
        /// <param name="campaignSt">キャンペーン設定のデータ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : キャンペーン設定データが読む。</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/05/20</br>
        /// </remarks>
        public int SearchCampaignSt(ref CampaignSt campaignSt)
        {
            // UIデータクラス→ワーク
            CampaignStWork campaignStWork = CopyToCampaignStWorkFromcampaignSt(campaignSt);

            ArrayList campaignStList = new ArrayList();
            object objcampaignStList = campaignStList as object;

            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            try
            {
                status = this._campaignLoginDB.SearchCampaignSt(ref objcampaignStList, campaignStWork);
            }
            catch (Exception ex)
            {
                ex.ToString();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            ArrayList campaignStLists=objcampaignStList as ArrayList;
            foreach (CampaignStWork work in campaignStLists)
            {
                campaignSt.CampaignObjDiv = work.CampaignObjDiv;
                campaignSt.CampaignName = work.CampaignName;
                campaignSt.ApplyEndDate = work.ApplyEndDate;
                campaignSt.ApplyStaDate = work.ApplyStaDate;
                campaignSt.SectionCode = work.SectionCode;
            }
             return status;
        }
      
        /// <summary>
        /// 得意先検索処理
        /// </summary>
        /// <param name="CampaignCode">キャンペーンコード</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 得意先検索処理を行います。</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/05/20</br>
        /// </remarks>
        public int SearchCustomer(int CampaignCode)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // 検索データクリア
            this._campaignLinkDataTable.Clear();

            try
            {
                // 検索条件
                CampaignLinkWork campaignLinkWork = new CampaignLinkWork();
                this._precampaignLinkList = new ArrayList();
                campaignLinkWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                campaignLinkWork.CampaignCode = CampaignCode;

                // 検索結果
                ArrayList campaignLinkList = new ArrayList();
                object objCampaignLinkList = campaignLinkList as object;

                status = this._campaignLoginDB.SearchCustomer(campaignLinkWork, ref objCampaignLinkList);

                // 正常場合
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    ArrayList resultList = objCampaignLinkList as ArrayList;

                    foreach (CampaignLinkWork work in resultList)
                    {
                        this._precampaignLinkList.Add(work);
                    }
                    status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }

        /// <summary>
        /// クラスメンバーコピー処理（キャンペーン対象得意先設定マスタワーククラス⇒キャンペーン対象得意先設定マスタRow）
        /// </summary>
        /// <param name="campaignLinkWork">キャンペーン対象得意先設定マスタワーククラス</param>
        /// <returns>キャンペーン対象得意先設定マスタRow</returns>
        /// <remarks>
        /// <br>Note       : キャンペーン対象得意先設定マスタワーククラス⇒キャンペーン対象得意先設定マスタRowへメンバーのコピーを行います。</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/05/20</br>
        /// </remarks>
        private CampaignLinkDataSet.CampaignLinkRow CopyToRowFromCampaignLinkWork(CampaignLinkWork campaignLinkWork)
        {
            CampaignLinkDataSet.CampaignLinkRow row = this._campaignLinkDataTable.NewCampaignLinkRow();
            row.CustomerCode = campaignLinkWork.CustomerCode.ToString("00000000");

            return row;
        }

        /// <summary>
        /// クラスメンバーコピー処理（キャンペーン名称設定クラス⇒キャンペーン名称設定マスタワーククラス）
        /// </summary>
        /// <param name="campaignSt">キャンペーン商品マスタワーククラス</param>
        /// <returns>キャンペーン名称設定マスタワーククラス</returns>
        /// <remarks>
        /// <br>Note       : クラスメンバーコピー処理（キャンペーン名称設定クラス⇒キャンペーン名称設定マスタワーククラス）</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/05/20</br>
        /// </remarks>
        private CampaignStWork CopyToCampaignStWorkFromcampaignSt(CampaignSt campaignSt)
        {
            CampaignStWork campaignStWork = new CampaignStWork();

            campaignStWork.EnterpriseCode = campaignSt.EnterpriseCode;
            campaignStWork.CampaignCode = campaignSt.CampaignCode;

            return campaignStWork;
        }


        /// <summary>
        /// クラスメンバーコピー処理（キャンペーン商品マスタワーククラス⇒キャンペーン商品クラス）
        /// </summary>
        /// <param name="campaignGoodsDataWork">キャンペーン商品マスタワーククラス</param>
        /// <returns>キャンペーン商品クラス</returns>
        /// <remarks>
        /// <br>Note       : キャンペーン商品マスタワーククラスからキャンペーン商品クラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/05/20</br>
        /// </remarks>
        private CampaignGoodsData CopyToCampaignGoodsDataFromCampaignGoodsDataWork(CampaignGoodsDataWork campaignGoodsDataWork)
        {
            CampaignGoodsData campaignGoodsData = new CampaignGoodsData();
            campaignGoodsData.GoodsNoNoneHyphen = campaignGoodsDataWork.GoodsNoNoneHyphen;
            campaignGoodsData.GoodsMakerCd = campaignGoodsDataWork.GoodsMakerCd;
            campaignGoodsData.EnterpriseCode = campaignGoodsDataWork.EnterpriseCode;

            return campaignGoodsData;
        }

        /// <summary>
        /// クラスメンバーコピー処理（キャンペーン商品クラス⇒キャンペーン商品ワーククラス）
        /// </summary>
        /// <param name="campaignGoodsData">キャンペーン商品クラス</param>
        /// <returns>キャンペーン商品ワーククラス</returns>
        /// <remarks>
        /// <br>Note       : キャンペーン商品クラスからキャンペーン商品ワーククラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 鄧潘ハン</br>
        /// <br>Date       : 2011/05/20</br>
        /// <br>UpdateNote : 2011/07/13 譚洪 Redmine#22877 BLコード（開始）（終了）をやめて、単独指定に変更の修正</br>
        /// </remarks>
        private CampaignGoodsDataWork CopyToCampaignGoodsDataWorkFromCampaignGoodsData(CampaignGoodsData campaignGoodsData)
        {
            CampaignGoodsDataWork campaignGoodsDataWork = new CampaignGoodsDataWork();

            campaignGoodsDataWork.GoodsNoNoneHyphen = campaignGoodsData.GoodsNoNoneHyphen;
            campaignGoodsDataWork.GoodsMakerCd = campaignGoodsData.GoodsMakerCd;
            campaignGoodsDataWork.EnterpriseCode = campaignGoodsData.EnterpriseCode;
            campaignGoodsDataWork.SectionCode = campaignGoodsData.SectionCode;
            campaignGoodsDataWork.ApplyStaDate = campaignGoodsData.ApplyStaDate;
            campaignGoodsDataWork.ApplyEndDate = campaignGoodsData.ApplyEndDate;
            // ----- UPD 2011/07/13 ------- >>>>>>>>>
            //campaignGoodsDataWork.BLGroupCodeSt = campaignGoodsData.BLGroupCodeSt;
            campaignGoodsDataWork.BLGroupCodeSt = campaignGoodsData.BLGoodsCode;
            // ----- UPD 2011/07/13 ------- <<<<<<<<<
            campaignGoodsDataWork.BLGroupCodeEd = campaignGoodsData.BLGroupCodeEd;
            campaignGoodsDataWork.CampaignCode = campaignGoodsData.CampaignCode;
            campaignGoodsDataWork.CampaignName = campaignGoodsData.CampaignName;
            campaignGoodsDataWork.CampaignObjDiv = campaignGoodsData.CampaignObjDiv;
           
            return campaignGoodsDataWork;
        }

        # endregion
       
    }
}
//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : キャンペーン対象商品設定マスタ一括削除
// プログラム概要   : キャンペーン対象商品設定マスタ一括削除
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 作 成 日  2011/04/26  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  10700008-00 作成担当 : 譚洪
// 修 正 日  2011/07/28  修正内容 : Redmine#23278 商品マスタを登録していない場合、提供データの純正品番、優良品番の名称が表示されないの対応
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// キャンペーン対象商品設定マスタ一括削除アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : なし。</br>
    /// <br>Programmer : 李占川</br>
    /// <br>Date       : 2011/04/26</br>
    /// <br>Update Note: 2011/07/28 Redmine#23278 商品マスタを登録していない場合、提供データの純正品番、優良品番の名称が表示されないの対応</br>
    /// </remarks>
    public class CampaignGoodsStAcs
    {
        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region ■Constructor
        /// <summary>
        /// デフォルトコンストラクタ（Singletonデザインパターンを採用している為、privateとする）
        /// </summary>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private CampaignGoodsStAcs()
        {
            _campaignGoodsData = new CampaignGoodsData();
            _campaignGoodsDataDel = _campaignGoodsData;
            _campaignGoodsDataTable = new CampaignGoodsDataSet.CampaignGoodsDataTable();

            this._campaignGoodsStDB = MediationCampaignGoodsStDB.GetCampaignGoodsStDB();

            // ----- ADD 2011/07/12 ------- >>>>>>>>>
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._loginWorker = LoginInfoAcquisition.Employee.Clone();
            this._ownSectionCode = this._loginWorker.BelongSectionCode;

            this._goodsAcs = new GoodsAcs();
            String retMessage = string.Empty;
            this._goodsAcs.IsLocalDBRead = false;
            this._goodsAcs.Owner = this._owner;
            this._goodsAcs.IsGetSupplier = true;
            this._goodsAcs.SearchInitial(this._enterpriseCode, this._ownSectionCode, out retMessage);
            // ----- ADD 2011/07/12 ------- <<<<<<<<<
        }

        /// <summary>
        /// アクセスクラス インスタンス取得処理
        /// </summary>
        /// <returns>アクセスクラス インスタンス</returns>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        public static CampaignGoodsStAcs GetInstance()
        {
            if (_campaignGoodsStAcs == null)
            {
                _campaignGoodsStAcs = new CampaignGoodsStAcs();
            }

            return _campaignGoodsStAcs;
        }
        #endregion

        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region ■Private Members
        private static CampaignGoodsStAcs _campaignGoodsStAcs = null;
        private CampaignGoodsData _campaignGoodsData = null;
        private CampaignGoodsData _campaignGoodsDataDel = null;
        private CampaignGoodsDataSet.CampaignGoodsDataTable _campaignGoodsDataTable;
        private ICampaignGoodsStDB _campaignGoodsStDB = null;
        private ArrayList campaignGoodsList = null;
        // ADD 2011/07/28 --- >>>>
        private GoodsAcs _goodsAcs = null;   
        private IWin32Window _owner = null;
        // 企業コード
        private string _enterpriseCode = "";
        private Employee _loginWorker = null;
        // 自拠点コード
        private string _ownSectionCode = "";
        // ADD 2011/07/28 --- <<<<
        #endregion

        // ===================================================================================== //
        // 属性
        // ===================================================================================== //
        # region ■Propertity
        /// <summary>
        /// UIデータ
        /// </summary>
        public CampaignGoodsData CampaignGoodsData
        {
            get { return this._campaignGoodsData; }
        }

        /// <summary>
        /// テーブルプロパティ
        /// </summary>
        public CampaignGoodsDataSet.CampaignGoodsDataTable CampaignGoodsDataTable
        {
            get { return _campaignGoodsDataTable; }
        }
        #endregion


        // ===================================================================================== //
        // プライベートメソッド
        // ===================================================================================== //
        # region ■Private Methods

        /// <summary>
        /// 検索データ初期インスタンス生成処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        public void CreateCampaignGoodsInitialData()
        {
            CampaignGoodsData campaignGoodsData = new CampaignGoodsData();

            // 拠点初期値
            campaignGoodsData.SectionCode = "00";
            campaignGoodsData.SectionName = "全社";
            campaignGoodsData.GoodsMakerCd = 0;
            campaignGoodsData.HeaderGoodsNo = "";

            this.CacheCampaignGoodsData(campaignGoodsData);
        }

        /// <summary>
        /// 検索データキャッシュ処理
        /// </summary>
        /// <param name="source">売上データインスタンス</param>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        public void CacheCampaignGoodsData(CampaignGoodsData source)
        {
            this._campaignGoodsData = source.Clone();
        }

        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="errMsg">エラーmessage</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : マスタ情報を検索します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        public int SearchData(out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            errMsg = string.Empty;

            // 検索データクリア
            this._campaignGoodsDataTable.Clear();

            try
            {
                // 検索条件
                CampaignGoodsDataWork campaignGoodsDataWork = this.CopyToCampaignGoodsDataWorkCampaignGoodsData(this._campaignGoodsData);
                campaignGoodsDataWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;

                // 検索結果
                campaignGoodsList = new ArrayList();
                object objCampaignGoodsList = (object)campaignGoodsList;

                status = this._campaignGoodsStDB.Search(campaignGoodsDataWork, ref objCampaignGoodsList);

                campaignGoodsList = objCampaignGoodsList as ArrayList;

                // 正常場合
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    ArrayList resultList = objCampaignGoodsList as ArrayList;

                    foreach (CampaignMngStWork work in resultList)
                    {
                        CampaignGoodsDataSet.CampaignGoodsRow row = this._campaignGoodsDataTable.NewCampaignGoodsRow();
                        row = this.CopyToRowFromCampaignMngStWork(work);

                        this._campaignGoodsDataTable.AddCampaignGoodsRow(row);
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
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                errMsg = ex.Message;
            }

            return status;
        }

        /// <summary>
        /// 削除処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        public int DeleteData(ref string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            this._campaignGoodsDataDel = this._campaignGoodsData.Clone();
            // 件数クリア
            this._campaignGoodsDataDel.GoodsStCount = 0;
            this._campaignGoodsDataDel.NameStCount = 0;
            this._campaignGoodsDataDel.CustomStCount = 0;
            this._campaignGoodsDataDel.TargetStCount = 0;

            try
            {
                // 削除条件
                CampaignGoodsDataWork campaignGoodsDataWork = this.CopyToCampaignGoodsDataWorkCampaignGoodsData(this._campaignGoodsDataDel);
               
                campaignGoodsDataWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;

                ArrayList objDeleteList = new ArrayList();
                objDeleteList.Add(campaignGoodsDataWork);
                object objDeletePara = (object)objDeleteList;

                status = this._campaignGoodsStDB.DeleteAll(this.campaignGoodsList, ref objDeletePara);

                // 正常場合
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (objDeletePara != null)
                    {
                        ArrayList deleteParaList = objDeletePara as ArrayList;
                        CampaignGoodsDataWork campaignGoodsDataWorkRes = new CampaignGoodsDataWork();
                        if (deleteParaList != null && deleteParaList.Count > 0)
                        {
                            campaignGoodsDataWorkRes = (CampaignGoodsDataWork)deleteParaList[0];
                            this._campaignGoodsDataDel.GoodsStCount = campaignGoodsDataWorkRes.GoodsStCount;
                            this._campaignGoodsDataDel.NameStCount = campaignGoodsDataWorkRes.NameStCount;
                            this._campaignGoodsDataDel.CustomStCount = campaignGoodsDataWorkRes.CustomStCount;
                            this._campaignGoodsDataDel.TargetStCount = campaignGoodsDataWorkRes.TargetStCount;

                            this._campaignGoodsData = this._campaignGoodsDataDel.Clone();
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        }
                        else
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                        }
                    }
                    else
                    {
                        status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                    }

                }

            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                errMsg = ex.Message;
            }

            return status;
        }

        /// <summary>
        /// クラスメンバーコピー処理（キャンペーン管理クラス⇒キャンペーン管理ワーククラス）
        /// </summary>
        /// <param name="campaignGoodsData">キャンペーン管理クラス</param>
        /// <returns>CampaignGoodsDataWork</returns>
        /// <remarks>
        /// <br>Note       : キャンペーン管理クラスからキャンペーン管理ワーククラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private CampaignGoodsDataWork CopyToCampaignGoodsDataWorkCampaignGoodsData(CampaignGoodsData campaignGoodsData)
        {
            CampaignGoodsDataWork campaignGoodsDataWork = new CampaignGoodsDataWork();

            campaignGoodsDataWork.SectionCode = campaignGoodsData.SectionCode;
            campaignGoodsDataWork.GoodsMakerCd = campaignGoodsData.GoodsMakerCd;
            campaignGoodsDataWork.HeaderGoodsNo = campaignGoodsData.HeaderGoodsNo;

            return campaignGoodsDataWork;
        }

        /// <summary>
        /// クラスメンバーコピー処理（キャンペーン管理マスタワーククラス⇒キャンペーン管理マスタRow）
        /// </summary>
        /// <param name="campaignMngStWork">キャンペーン管理マスタワーククラス</param>
        /// <returns>キャンペーン管理マスタRow</returns>
        /// <remarks>
        /// <br>Note       : キャンペーン管理マスタワーククラスからキャンペーン管理マスタRowへメンバーのコピーを行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/04/26</br>
        /// <br>Update Note: 2011/07/28 Redmine#23278 商品マスタを登録していない場合、提供データの純正品番、優良品番の名称が表示されないの対応</br>
        /// </remarks>
        private CampaignGoodsDataSet.CampaignGoodsRow CopyToRowFromCampaignMngStWork(CampaignMngStWork campaignMngStWork)
        {
            CampaignGoodsDataSet.CampaignGoodsRow row = this._campaignGoodsDataTable.NewCampaignGoodsRow();

            if (campaignMngStWork.CampaignCode == 0)
            {
                row.CampaignCode = string.Empty;
            }
            else
            {
                row.CampaignCode = campaignMngStWork.CampaignCode.ToString("000000");
            }
            row.CampaignName = this.SubStringLength(campaignMngStWork.CampaignName, 20);
            if (campaignMngStWork.SectionCode.Trim() == "00")
            {
                row.SectionCode = "00";
                row.SectionName = "全社";
            }
            else
            {
                row.SectionCode = campaignMngStWork.SectionCode.Trim();
                row.SectionName = this.SubStringLength(campaignMngStWork.SectionName, 10);
            }
            string kindName = string.Empty;
            switch(campaignMngStWork.CampaignSettingKind)
            {
                case 1:
                    kindName = "ﾒｰｶｰ+品番";
                    break;
                case 2:
                    kindName = "ﾒｰｶｰ+BLｺｰﾄﾞ";
                    break;
                case 3:
                    kindName = "ﾒｰｶｰ+ｸﾞﾙｰﾌﾟ";
                    break;
                case 4:
                    kindName = "ﾒｰｶｰ";
                    break;
                case 5:
                    kindName = "BLｺｰﾄﾞ";
                    break;
                case 6:
                    kindName = "販売区分";
                    break;
            }
            row.CampaignSettingKind = campaignMngStWork.CampaignSettingKind;
            row.CampaignSettingKindNm = kindName;
            row.GoodsMakerCd = campaignMngStWork.GoodsMakerCd;
            row.GoodsMakerNm = this.SubStringLength(campaignMngStWork.GoodsMakerNm, 10);
            row.GoodsNo = this.SubStringLength(campaignMngStWork.GoodsNo, 24);

            // ----- ADD 2011/07/28 ------- >>>>>>>
            if (string.IsNullOrEmpty(campaignMngStWork.GoodsName))
            {
                List<GoodsUnitData> goodsUnitDataList;
                PartsInfoDataSet partsInfoDataSet;
                string msg = string.Empty;

                // 抽出条件の作成
                GoodsCndtn goodsCndtn = new GoodsCndtn();
                goodsCndtn.EnterpriseCode = this._enterpriseCode;
                goodsCndtn.GoodsMakerCd = campaignMngStWork.GoodsMakerCd;
                goodsCndtn.GoodsNo = campaignMngStWork.GoodsNo;
                goodsCndtn.IsSettingSupplier = 1;

                this._goodsAcs.SearchPartsOfNonGoodsNo(goodsCndtn, out partsInfoDataSet, out goodsUnitDataList, out msg);

                foreach (GoodsUnitData goodsUnitData in goodsUnitDataList)
                {
                    if (goodsUnitData.LogicalDeleteCode == 0)
                    {
                        // 商品名称
                        row.GoodsName = this.SubStringLength(goodsUnitData.GoodsName, 40);
                    }
                }
            }
            else
            {
                // 商品名称
                row.GoodsName = this.SubStringLength(campaignMngStWork.GoodsName, 40);
            }
            // ----- ADD 2011/07/28 ------- <<<<<<<<<

            // row.GoodsName = this.SubStringLength(campaignMngStWork.GoodsName, 40);  // -DEL 2011/07/28

            if (campaignMngStWork.CustomerCode == 0)
            {
                row.CustomerCode = string.Empty;
            }
            else
            {
                row.CustomerCode = campaignMngStWork.CustomerCode.ToString("00000000");
            }
            row.CustomerName = this.SubStringLength(campaignMngStWork.CustomerName, 10);
            row.DiscountRate = campaignMngStWork.DiscountRate;
            row.RateVal = campaignMngStWork.RateVal;
            row.PriceFl = campaignMngStWork.PriceFl;
            row.PriceStartDate = this.IntToDateTimeStr(campaignMngStWork.PriceStartDate);
            row.PriceEndDate = this.IntToDateTimeStr(campaignMngStWork.PriceEndDate);
            // 売価区分==0:無し
            if (campaignMngStWork.SalesPriceSetDiv == 0)
            {
                row.CustomerCode = string.Empty;
                row.CustomerName = string.Empty;
                row.DiscountRate = 0;
                row.RateVal = 0;
                row.PriceFl = 0;
                row.PriceStartDate = string.Empty;
                row.PriceEndDate = string.Empty;
            }
            return row;
        }
        #endregion

        # region ■ セル値変換
        /// <summary>
        /// 表示項目の桁の処理
        /// </summary>
        /// <param name="str">項目</param>
        /// <param name="length">桁</param>
        /// <returns>処理した項目</returns>
        /// <remarks>
        /// <br>Note       : 表示項目の桁の処理を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private string SubStringLength(string str, int length)
        {
            string subStr = str;

            if (str.Length > length)
            {
                subStr = str.Substring(0, length);
            }

            return subStr;
        }

        /// <summary>
        /// Conver int to string(YYYY/MM/DD)
        /// </summary>
        /// <param name="intDate"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : Conver int to stringの処理を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private string IntToDateTimeStr(int intDate)
        {
            if (intDate == 0)
            {
                return string.Empty;
            }
            string strDate = intDate.ToString();
            strDate = strDate.Insert(4, "-");
            strDate = strDate.Insert(7, "-");
            DateTime date = Convert.ToDateTime(strDate);

            return date.ToShortDateString();
        }
        # endregion
    }
}

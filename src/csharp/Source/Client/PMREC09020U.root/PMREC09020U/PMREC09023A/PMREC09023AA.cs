//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : お買得商品設定マスタ
// プログラム概要   : お買得商品設定マスタを行う
//----------------------------------------------------------------------------//
//                (c)Copyright 2015 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 脇田 靖之
// 作 成 日  2015/02/20  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 脇田 靖之
// 更 新 日  2015/03/03  修正内容 : RedMine#307 保存された得意先別設定を開くと、
//                                              グループ名が表示されない
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 脇田 靖之
// 更 新 日  2015/03/09  修正内容 : RedMine#343 得意先個別設定でユーザー登録のグループを
//                                              選択すると存在しないエラー
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 小栗 大介
// 更 新 日  2015/03/13  修正内容 : 品証RedMine#3151 得意先個別設定でユーザー登録のグループを
//                                                   選択すると存在しないエラー
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 脇田 靖之
// 更 新 日  2015/03/16  修正内容 : RedMine#371 離島価格UP率を設定した場合、
//                                              お買得マスタのメーカー価格に適用される
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 脇田 靖之
// 更 新 日  2015/03/23  修正内容 : 品証Redmine#3158 課題管理表№37
//                                  公開区分チェックをはずした状態であれば仮登録できるように対応
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 脇田 靖之
// 更 新 日  2015/03/25  修正内容 : メーカー価格取得方法修正
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 脇田 靖之
// 更 新 日  2015/03/26  修正内容 : 品証Redmine#3247
//                                  PM商品マスタ(ユーザー登録)から取得したメーカー価格に対して離島設定が反映される
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.Data;

using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// お買得商品設定マスタ アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : お買得商品設定マスタ アクセスクラス</br>
    /// <br>Programmer : 脇田 靖之</br>
    /// <br>Date       : 2015/02/20</br>
    /// </remarks>
    public class RecBgnGdsAcs
    {
        #region Private Member
        private static CampaignObjGoodsStAcs _campaignObjGoodsStAcs = null;

        private RecBgnGdsDataSet _dataSet;
        private RecBgnGdsDataSet.RecBgnGdsDataTable _recBgnGdsDataTable;
        private RecBgnGdsDataSet.RecBgnCustDataTable _recBgnCustDataTable;

        private Dictionary<Guid, RecBgnGds> _prevRecBgnGdsDic = new Dictionary<Guid, RecBgnGds>();
        private Dictionary<Guid, RecBgnCust> _prevRecBgnCustDic = new Dictionary<Guid, RecBgnCust>();
        private Dictionary<int, RecBgnGdsCustInfo> _RecBgnGdsCustInfoDic = new Dictionary<int, RecBgnGdsCustInfo>();


        private AllDefSet _allDefSet; // 全体初期値設定マスタ情報

        private IRecBgnGdsDB _iRecBgnGdsDB = null;
        private Calculator _calculator = null;
        private RecBgnGrpAcs _recBgnGrpAcs = null;

        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        private string _loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

        /// <summary>処理結果状況</summary>
        private string _statusOfResult = string.Empty;

        private MakerAcs _makerAcs = null;              // メーカーアクセスクラス
        private SecInfoAcs _secInfoAcs = null;          // 拠点情報アクセスクラス

        /// <summary>DCKHN09092A)BLコード</summary>
        private BLGoodsCdAcs _blGoodsCdAcs;

        /// <summary>PMKHN09062A)BLグループ</summary>
        private BLGroupUAcs _blGroupUAcs;

        /// <summary>SFCMN09062A)ユーザーガイド</summary>
        private UserGuideAcs _userGuideAcs;

        /// <summary>PMKHN09012A)得意先</summary>
        private CustomerInfoAcs _customerInfoAcs;

        /// <summary>MAKHN04112A)BLコード・品番検索</summary>
        private GoodsAcs _goodsAcs;

        /// <summary> SCM企業連結データアクセスクラス </summary>
        private ScmEpScCntAcs _scmEpScCntAcs;

        /// <summary> 離島価格データアクセスクラス </summary>
        private IsolIslandPrcAcs _isolIslandPrcAcs = null;

        private IWin32Window _owner = null;

        private Dictionary<int, MakerUMnt> _makerUMntDic = new Dictionary<int, MakerUMnt>();            // メーカーマスタディクショナリー
        private Dictionary<string, SecInfoSet> _secInfoSetDic = new Dictionary<string, SecInfoSet>();   // 拠点情報ディクショナリー
        private Dictionary<int, BLGoodsCdUMnt> _blGoodsCdDic = new Dictionary<int, BLGoodsCdUMnt>();    // BLコードマスタディクショナリー
        private Dictionary<int, BLGroupU> _blGroupDic = new Dictionary<int, BLGroupU>();                // BLグループマスタディクショナリー
        private Dictionary<int, UserGdBd> _userGdBdDic = new Dictionary<int, UserGdBd>();               // ユーザーガイドディクショナリー
        private Dictionary<int, CustomerInfo> _customerDic = new Dictionary<int, CustomerInfo>();       // 得意先ディクショナリー
        private List<CustomerSearchRet> _customerSearchRetList = new List<CustomerSearchRet>();         // 得意先リスト（お買得商品グループガイド用）
        private Dictionary<int, RecBgnGds> _recBgnGdsDic = new Dictionary<int, RecBgnGds>();            // お買得商品設定マスタディクショナリー
        private List<RecBgnGrpRet> _recBgnGrpWorkList = new List<RecBgnGrpRet>();                       // お買得商品グループ設定マスタリスト

        private List<ScmEpScCnt> _scmEpScCntList = new List<ScmEpScCnt>();   // SCM企業連結データリスト
        private List<RecBgnGds> _recBgnGdsList = new List<RecBgnGds>();

        //true:削除指定区分=1、false:削除指定区分=0
        private bool _deleteSearchMode = false;

        /// <summary>// true:ローカル参照 false:サーバー参照</summary>
        public static readonly bool ctIsLocalDBRead = false;

        private RecBgnGds _newRecBgnGdsObj = new RecBgnGds(); // 新規行の場合用

        private Thread _masterAcsThread;    // マスタデータ取得スレッド
        private Thread _goodsAcsThread;     // 商品データ取得スレッド

        /// <summary>全社設定</summary>
        private const string ALL_SECTION_CODE = "00";
        private const string ALL_SECTION_NAME = "全社共通";
        #endregion

        #region プロパティ
        /// <summary>
        /// マスタデータ取得スレッドプロパティ
        /// </summary>
        public Thread MasterAcsThread
        {
            get { return this._masterAcsThread; }
        }

        /// <summary>
        /// 商品データ取得スレッドプロパティ
        /// </summary>
        public Thread GoodsAcsThread
        {
            get { return this._goodsAcsThread; }
        }

        /// <summary>
        /// グリッドテーブルプロパティ
        /// </summary>
        public RecBgnGdsDataSet.RecBgnGdsDataTable RecBgnGdsDataTable
        {
            get { return this._recBgnGdsDataTable; }
        }

        /// <summary>
        /// グリッドテーブルプロパティ
        /// </summary>
        public RecBgnGdsDataSet.RecBgnCustDataTable RecBgnCustDataTable
        {
            get { return this._recBgnCustDataTable; }
        }

        /// <summary>
        /// お買得商品設定ディクショナリープロパティ
        /// </summary>
        public Dictionary<Guid, RecBgnGds> PrevRecBgnGdsDic
        {
            get { return this._prevRecBgnGdsDic; }
        }

        /// <summary>
        /// お買得商品得意先個別設定ディクショナリープロパティ
        /// </summary>
        public Dictionary<Guid, RecBgnCust> PrevRecBgnCustDic
        {
            get { return this._prevRecBgnCustDic; }
        }

        /// <summary>
        /// お買得商品設定-得意先個別設定関連ディクショナリープロパティ
        /// </summary>
        public Dictionary<int, RecBgnGdsCustInfo> RecBgnGdsCustInfoDic
        {
            get { return this._RecBgnGdsCustInfoDic; }
        }

        /// <summary>
        /// メーカーマスタディクショナリープロパティ
        /// </summary>
        public Dictionary<int, MakerUMnt> MakerUMntDic
        {
            get { return this._makerUMntDic; }
        }

        /// <summary>
        /// ＢＬコードマスタディクショナリープロパティ
        /// </summary>
        public Dictionary<int, BLGoodsCdUMnt> BLGoodsCdDic
        {
            get { return this._blGoodsCdDic; }
        }

        /// <summary>
        /// ＢＬグルプマスタディクショナリープロパティ
        /// </summary>
        public Dictionary<int, BLGroupU> BLGroupDic
        {
            get { return this._blGroupDic; }
        }

        /// <summary>
        /// 販売区分ディクショナリープロパティ
        /// </summary>
        public Dictionary<int, UserGdBd> UserGdBdDic
        {
            get { return this._userGdBdDic; }
        }

        /// <summary>
        /// 削除指定区分プロパティ
        /// </summary>
        public bool DeleteSearchMode
        {
            get { return this._deleteSearchMode; }
        }

        /// <summary>
        /// 拠点情報マスタディクショナリープロパティ
        /// </summary>
        public Dictionary<string, SecInfoSet> SecInfoSetDic
        {
            get { return this._secInfoSetDic; }
        }

        /// <summary>
        /// 得意先マスタディクショナリープロパティ
        /// </summary>
        public Dictionary<int, CustomerInfo> CustomerDic
        {
            get { return this._customerDic; }
        }

        /// <summary>
        /// 得意先マスタディクショナリープロパティ
        /// </summary>
        public List<CustomerSearchRet> CustomerSearchRetList
        {
            get { return this._customerSearchRetList; }
        }

        /// <summary>
        /// お買得商品設定ディクショナリープロパティ
        /// </summary>
        public Dictionary<int, RecBgnGds> RecBgnGdsDic
        {
            get { return this._recBgnGdsDic; }
        }

        /// <summary>
        /// お買得商品設定ディクショナリープロパティ
        /// </summary>
        public List<RecBgnGds> RecBgnGdsList
        {
            get { return this._recBgnGdsList; }
        }

        /// <summary>
        /// SCM企業連結データリストプロパティ
        /// </summary>
        public List<ScmEpScCnt> ScmEpScCntList
        {
            get { return this._scmEpScCntList; }
        }

        /// <summary>
        /// 商品アクセスクラスプロパティ
        /// </summary>
        public GoodsAcs GoodsAcsClass
        {
            get { return this._goodsAcs; }
        }

        /// <summary>
        /// 処理結果状況を取得します。<br/>
        /// (GetRatePriceOfRecBgnGds()を呼出し時に変化します)
        /// </summary>
        public string StatusOfResult
        {
            get { return _statusOfResult; }
        }

        /// <summary>
        /// お買得商品設定プロパティ、新規行の場合用
        /// </summary>
        public RecBgnGds NewRecBgnGdsObj
        {
            get { return _newRecBgnGdsObj; }
            set { _newRecBgnGdsObj = value; }
        }

        /// <summary>
        /// お買得商品設定マスタ 価格算出アクセスクラスプロパティ
        /// </summary>
        public Calculator Calculator
        {
            get { return this._calculator; }
        }

        /// <summary>
        /// 全体初期値設定マスタ プロパティ
        /// </summary>
        public AllDefSet AllDefSet
        {
            get { return this._allDefSet; }
        }
        #endregion

        #region ●その他補助メソッド
        /// <summary>
        /// 比較関数
        /// </summary>
        /// <typeparam name="T">型指定</typeparam>
        /// <param name="condition">条件</param>
        /// <param name="valueOnTrue">Trueの時の値</param>
        /// <param name="valueOnFalse">Falseの時の値</param>
        /// <returns>条件により選択された値</returns>
        /// <remarks>
        /// <br>Note       : お買得商品設定マスタ アクセスクラス</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        static public T diverge<T>(bool condition, T valueOnTrue, T valueOnFalse)
        {
            if (condition)
            {
                return valueOnTrue;
            }
            else
            {
                return valueOnFalse;
            }
        }
        #endregion

        # region Constroctors
        /// <summary>
        /// 入力明細入力コントロールクラス デフォルトコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 入力明細入力コントロールクラス デフォルトを行うコントロールクラスです。</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        public RecBgnGdsAcs()
        {
            this._dataSet = new RecBgnGdsDataSet();
            this._recBgnGdsDataTable = this._dataSet.RecBgnGds;
            this._recBgnCustDataTable = this._dataSet.RecBgnCust;
            this._makerAcs = new MakerAcs();
            this._secInfoAcs = new SecInfoAcs();
            this._blGoodsCdAcs = new BLGoodsCdAcs();
            this._blGroupUAcs = new BLGroupUAcs();
            this._userGuideAcs = new UserGuideAcs();
            this._scmEpScCntAcs = new ScmEpScCntAcs();
            this._customerInfoAcs = new CustomerInfoAcs();
            this._iRecBgnGdsDB = (IRecBgnGdsDB)MediationRecBgnGdsDB.GetRecBgnGdsDB();
            this._calculator = new Calculator();
            this._recBgnGrpAcs = new RecBgnGrpAcs();
            this._isolIslandPrcAcs = new IsolIslandPrcAcs(); // ADDD 2015/02/27 修正②
        }
        #endregion

        #region Public Method
        /// <summary>
        /// キャンペーン対象商品設定アクセスクラス インスタンス取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : キャンペーン対象商品設定アクセスクラス インスタンス取得処理</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        public static CampaignObjGoodsStAcs GetInstance()
        {
            if (_campaignObjGoodsStAcs == null)
            {
                _campaignObjGoodsStAcs = new CampaignObjGoodsStAcs();
            }

            return _campaignObjGoodsStAcs;
        }

        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="recBgnGdsSearchPara">検索条件クラス</param>
        /// <param name="count">count</param>
        /// <param name="msg">エラーメッセージ</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 検索処理を行います。</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        public int Search(RecBgnGdsSearchPara recBgnGdsSearchPara, out int count, out string msg)
        {
            int status = 0;
            count = 0;
            msg = string.Empty;
            ArrayList recBgnGdsList = null;
            ArrayList recBgnCustList = null;

            RecBgnGdsSearchParaWork recBgnGdsSearchParaWork = this.CopyToRecBgnGdsSearchParaWorkFromRecBgnGdsSearchPara(recBgnGdsSearchPara);

            try
            {
                if (recBgnGdsSearchPara.DeleteFlag == 0)
                {
                    status = this.SearchPrc(out recBgnGdsList, out recBgnCustList, recBgnGdsSearchParaWork, ConstantManagement.LogicalMode.GetData0, out count, ref msg);
                }
                else
                {
                    status = this.SearchPrc(out recBgnGdsList, out recBgnCustList, recBgnGdsSearchParaWork, ConstantManagement.LogicalMode.GetData1, out count, ref msg);
                }
            }
            catch (Exception ex)
            {
                msg = ex.ToString();
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            Dictionary<string, string> ss = new Dictionary<string, string>();

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (recBgnGdsSearchPara.DeleteFlag == 0)
                {
                    this._deleteSearchMode = false;
                }
                else
                {
                    this._deleteSearchMode = true;
                }

                if (recBgnGdsList != null && recBgnGdsList.Count > 0)
                {
                    this.SettingDetailRowAfterSearch(recBgnGdsList, recBgnCustList);
                }
            }
            //---------ADD 2015/03/13 小栗 -------->>>>>>
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                //該当ない場合、得意先別ディクショナリをクリア
                _RecBgnGdsCustInfoDic.Clear();
            }
            //---------ADD 2015/03/13 小栗 --------<<<<<<

            return status;
        }

        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="retArray">ｷｬﾝﾍﾟｰﾝ対象商品設定ﾏｽﾀデータ</param>
        /// <param name="recBgnGdsSearchPara">検索条件クラス</param>
        /// <param name="logicalMode">論理削除モード</param>
        /// <param name="count">count</param>
        /// <param name="msg">エラーメッセージ</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 検索処理を行います。</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        public int SearchPrc(out ArrayList retGdsArray, out ArrayList retCustArray, RecBgnGdsSearchParaWork recBgnGdsSearchParaWork, ConstantManagement.LogicalMode logicalMode, out int count, ref string msg)
        {
            int status = 0;
            count = 0;
            try
            {
                ArrayList recBgnGdsList = null;
                ArrayList recBgnCustList = null;
                object retObj = recBgnGdsList as object;
                object retCustobj = recBgnCustList as object;

                object paraObj = recBgnGdsSearchParaWork as object;
                status = this._iRecBgnGdsDB.Search(out retObj, out retCustobj, paraObj, logicalMode, out count, ref msg);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    retGdsArray = retObj as ArrayList;
                    retCustArray = retCustobj as ArrayList;
                }
                else
                {
                    retGdsArray = null;
                    retCustArray = null;
                }
            }
            catch (Exception ex)
            {
                retGdsArray = null;
                retCustArray = null;
                msg = ex.ToString();
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        /// <summary>
        /// 明細データテーブルの初期設定を行います。
        /// </summary>
        /// <param name="defaultRowCount">初期行数</param>
        /// <remarks>
        /// <br>Note       : 明細データテーブルの初期設定を行います。</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        public void DetailRowInitialSetting(int defaultRowCount)
        {
            this.RecBgnGdsDataTable.BeginLoadData();
            this.RecBgnGdsDataTable.Clear();
            this._deleteSearchMode = false;

            for (int i = 1; i <= defaultRowCount; i++)
            {
                RecBgnGdsDataSet.RecBgnGdsRow row = this.RecBgnGdsDataTable.NewRecBgnGdsRow();
                row.RowNo = i;
                row.FilterGuid = Guid.Empty;
                row.UpdateTime = DateTime.MinValue.ToString("yy/MM/dd");
                row.InqOtherEpCd = this._enterpriseCode;
                row.InqOtherSecCd = ALL_SECTION_CODE;
                row.InqOtherSecNm = ALL_SECTION_NAME;
                row.DisplayDivCode = 1;
                row.ApplyStaDate = string.Empty;
                row.ApplyEndDate = string.Empty;

                this.RecBgnGdsDataTable.AddRecBgnGdsRow(row);
            }
            this.CopyToRecBgnGdsFromDetailRow((RecBgnGdsDataSet.RecBgnGdsRow)this._recBgnGdsDataTable.Rows[this._recBgnGdsDataTable.Count - 1], ref this._newRecBgnGdsObj);
            this.RecBgnGdsDataTable.EndLoadData();
        }

        /// <summary>
        /// 保存処理
        /// </summary>
        /// <param name="deleteList">削除リスト</param>
        /// <param name="updateList">登録・更新リスト</param>
        /// <param name="campaignObjGoodsSt">エラーオブジェクト</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 保存処理を行います。</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        public int SaveProc(List<RecBgnGds> deleteList, List<RecBgnGds> updateList, List<RecBgnCust> updateCustList, out RecBgnGds recBgnGds)
        {
            int status = 0;
            recBgnGds = null;

            ArrayList GdsDelList = new ArrayList();
            ArrayList GdsUpdList = new ArrayList();
            ArrayList CustUpdList = new ArrayList();

            ArrayList IsolUpdList = new ArrayList();

            // お買得商品
            RecBgnGdsPMWork recBgnGdsPMWork = null;
            foreach (RecBgnGds recBgn in deleteList)
            {
                recBgnGdsPMWork = this.CopyToRecBgnGdsPMWorkFromRecBgnGds(recBgn);
                GdsDelList.Add(recBgnGdsPMWork);
            }
            foreach (RecBgnGds recBgn in updateList)
            {
                recBgnGdsPMWork = this.CopyToRecBgnGdsPMWorkFromRecBgnGds(recBgn);
                GdsUpdList.Add(recBgnGdsPMWork);
            }

            // お買得商品得意先個別
            RecBgnCustPMWork recBgnCustPMWork = null;
            foreach (RecBgnCust recCust in updateCustList)
            {
                recBgnCustPMWork = this.CopyToRecBgnCustPMWorkFromRecBgnCust(recCust);
                CustUpdList.Add(recBgnCustPMWork);
            }

            // 離島価格
            // --- UPD 2015/02/27 修正② ------------------------------>>>>>
            //IsolIslandPrc isolIslandPrc = null;
            //foreach (RecBgnGds recBgn in updateList)
            //{
            //    status = this._isolIslandPrcAcs.Read(out isolIslandPrc, this._enterpriseCode, recBgn.GoodsMakerCd);
            //    IsolUpdList.Add(isolIslandPrc);
            //}
            PmIsolPrcWork pmIsolPrcWork = null;
            List<IsolIslandPrc> isolIslandPrcList = new List<IsolIslandPrc>();
            status = this._isolIslandPrcAcs.Search(out isolIslandPrcList, this._enterpriseCode); //離島価格マスタ読込
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                foreach (IsolIslandPrc isolIslandPrc in isolIslandPrcList)
                {
                    foreach (RecBgnGds recBgn in updateList)
                    {
                        if (isolIslandPrc.MakerCode == recBgn.GoodsMakerCd)
                        {
                            pmIsolPrcWork = new PmIsolPrcWork();
                            pmIsolPrcWork.CreateDateTime = isolIslandPrc.CreateDateTime;
                            pmIsolPrcWork.EnterpriseCode = isolIslandPrc.EnterpriseCode;
                            pmIsolPrcWork.ListPriceUpRate = isolIslandPrc.UpRate;
                            pmIsolPrcWork.LogicalDeleteCode  = isolIslandPrc.LogicalDeleteCode;
                            pmIsolPrcWork.MakerCode          = isolIslandPrc.MakerCode;
                            pmIsolPrcWork.PMFractionProcCd   = isolIslandPrc.FractionProcCd;
                            pmIsolPrcWork.PMFractionProcUnit = isolIslandPrc.FractionProcUnit;
                            pmIsolPrcWork.SectionCode        = isolIslandPrc.SectionCode;
                            pmIsolPrcWork.UpdateDateTime     = isolIslandPrc.UpdateDateTime;
                            pmIsolPrcWork.UpperLimitPrice    = isolIslandPrc.UpperLimitPrice;


                            IsolUpdList.Add(pmIsolPrcWork);
                            break;
                        }
                    }
                }
            }
            // --- UPD 2015/02/27 修正② ------------------------------<<<<<

            object paraGdsDelObj = GdsDelList as object;
            object paraGdsUpdObj = GdsUpdList as object;
            object paraCustUpdObj = CustUpdList as object;

            object paraIsolUpdObj = IsolUpdList as object;

            if (this._deleteSearchMode == false)
            {
                object errorObj = null;
                status = this._iRecBgnGdsDB.DeleteAndWrite(paraGdsDelObj, ref paraGdsUpdObj, ref paraCustUpdObj, ref paraIsolUpdObj, out errorObj);
                if (errorObj != null)
                {
                    RecBgnGdsPMWork errorWork = errorObj as RecBgnGdsPMWork;
                    recBgnGds = this.CopyToRecBgnGdsFromRecBgnGdsPMWork(errorWork);
                }
            }
            else
            {
                status = this._iRecBgnGdsDB.DeleteAndRevival(paraGdsDelObj, ref paraGdsUpdObj);
            }

            return status;
        }

        /// <summary>
        /// 商品検索
        /// </summary>
        /// <returns>ステータス 0：正常終了 0以外：異常終了 </returns>
        // --- UPD 2015/03/25 Y.Wakita ---------->>>>>
        //public int SearchPartsFromGoodsNo(string goodsNo, int goodsMakerCd, out GoodsUnitData goodsUnitData, out string msg)
        public int SearchPartsFromGoodsNo(
            string goodsNo, 
            int goodsMakerCd, 
            out GoodsUnitData goodsUnitData, 
            out PartsInfoDataSet partsInfoDataSet,
            out Dictionary<Calculator.GoodsInfoKey, List<GoodsPrice>> mkrSuggestRtPricList,
            out Dictionary<Calculator.GoodsInfoKey, List<GoodsPrice>> mkrSuggestRtPricUList, 
            out string msg)
        // --- UPD 2015/03/25 Y.Wakita ----------<<<<<
        {
            int status = -1;
            List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>();
            bool samePartsNoWindowDiv = true;   // ADD 2015/03/25 Y.Wakita

            GoodsCndtn cndtn = new GoodsCndtn();
            cndtn.EnterpriseCode = this._enterpriseCode;
            // --- UPD 2015/03/16 Y.Wakita Redmine#371 ---------->>>>>
            //cndtn.SectionCode = this._loginSectionCode;
            cndtn.SectionCode = ALL_SECTION_CODE;
            // --- UPD 2015/03/16 Y.Wakita Redmine#371 ----------<<<<<
            cndtn.GoodsKindCode = 9;
            cndtn.GoodsNo = goodsNo.Trim();

            goodsUnitData = null;
            // --- ADD 2015/03/25 Y.Wakita ---------->>>>>
            mkrSuggestRtPricList = null;
            mkrSuggestRtPricUList = null;
            // --- ADD 2015/03/25 Y.Wakita ----------<<<<<

            if (goodsMakerCd != 0)
            {
                cndtn.GoodsMakerCd = goodsMakerCd;
                samePartsNoWindowDiv = false;   // ADD 2015/03/25 Y.Wakita
            }

            // --- UPD 2015/03/25 Y.Wakita ---------->>>>>
            //status = this.GoodsAcsClass.SearchPartsFromGoodsNoNonVariousSearch(cndtn, out goodsUnitDataList, out msg);
            status = this.GoodsAcsClass.SearchPartsFromGoodsNoNonVariousSearch(cndtn, samePartsNoWindowDiv, out goodsUnitDataList, out partsInfoDataSet, out msg);
            // --- UPD 2015/03/25 Y.Wakita ----------<<<<<
            // --- ADD 2015/03/25 Y.Wakita ---------->>>>>
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                Calculator.GetOfrPriceDataList(partsInfoDataSet, goodsUnitDataList, out mkrSuggestRtPricList, out mkrSuggestRtPricUList);
            }
            // --- ADD 2015/03/25 Y.Wakita ----------<<<<<
            // --- DEL 2015/03/25 Y.Wakita ---------->>>>>
            //if (goodsUnitDataList.Count == 0 && status != -1)
            //{
            //    cndtn.SectionCode = ALL_SECTION_CODE;
            //    status = this.GoodsAcsClass.SearchPartsFromGoodsNoNonVariousSearch(cndtn, out goodsUnitDataList, out msg);
            //}
            // --- DEL 2015/03/25 Y.Wakita ----------<<<<<
            if (goodsUnitDataList.Count > 0)
            {
                goodsUnitData = goodsUnitDataList[0];
            }

            return status;
        }

        /// <summary>
        /// 得意先個別設定データからリスト作成
        /// </summary>
        public void SetGdsToCust2(List<RecBgnGds> updateList, out List<RecBgnCust> updateCustList)
        {
            List<RecBgnCust> uList = new List<RecBgnCust>();
            RecBgnCust recBgnCust = new RecBgnCust();
            RecBgnCust recBgnCustUPD = new RecBgnCust();

            int custRowNo = 1;

            for (int i = 0; i < updateList.Count; i++)
            {
                int rowNo = updateList[i].RowIndex;
                RecBgnGdsCustInfo recBgnGdsCustInfo = null;
                if (this.RecBgnGdsCustInfoDic.ContainsKey(rowNo))
                {
                    recBgnGdsCustInfo = this.RecBgnGdsCustInfoDic[rowNo];

                    if (recBgnGdsCustInfo.recBgnCust.Count != 0)
                    {
                        foreach (RecBgnGdsDataSet.RecBgnCustRow RecBgnCustRow in recBgnGdsCustInfo.recBgnCust)
                        {
                            recBgnCust = new RecBgnCust();
                            this.CopyToRecBgnCustFromDetailRow(RecBgnCustRow, ref recBgnCust);

                            recBgnCustUPD = recBgnCust.Clone();
                            recBgnCustUPD.RowIndex = custRowNo;

                            recBgnCustUPD.LogicalDeleteCode = 0;
                            recBgnCustUPD.GoodsNo = updateList[i].GoodsNo;
                            recBgnCustUPD.GoodsMakerCd = updateList[i].GoodsMakerCd;
                            recBgnCustUPD.GoodsApplyStaDate = updateList[i].ApplyStaDate;

                            uList.Add(recBgnCustUPD);

                            custRowNo += 1;
                        }
                    }
                }
            }

            updateCustList = uList;
        }

        #endregion

        #region Private Method
        /// <summary>
        /// 検索処理後、明細行追加処理
        /// </summary>
        /// <param name="retList">0:登録・更新、1:完全削除と復活</param>
        /// <remarks>
        /// <br>Note       : 検索処理後、明細行追加処理を行います。</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private void SettingDetailRowAfterSearch(ArrayList retGdsList, ArrayList retCustList)
        {
            //関連Dic削除
            _RecBgnGdsCustInfoDic.Clear();

            // お買得商品得意先個別設定
            this._recBgnCustDataTable.BeginLoadData();
            this._recBgnCustDataTable.Clear();
            RecBgnCust recBgnCust = null;
            for (int i = 1; i <= retCustList.Count; i++)
            {
                recBgnCust = this.CopyToRecBgnCustFromRecBgnCustPMWork((RecBgnCustPMWork)retCustList[i - 1]);
                RecBgnGdsDataSet.RecBgnCustRow row = this._recBgnCustDataTable.NewRecBgnCustRow();
                row.RowNo = i;
                this.CopyToDetailRowFromRecBgnCust(ref row, recBgnCust);

                this._recBgnCustDataTable.AddRecBgnCustRow(row);
                this._prevRecBgnCustDic.Add(row.FilterGuid, recBgnCust);
            }
            this._recBgnCustDataTable.EndLoadData();

            // お買得商品設定
            this.RecBgnGdsDataTable.BeginLoadData();
            this._recBgnGdsDataTable.Clear();
            RecBgnGds recBgnGds = null;

            List<RecBgnGdsPMWork> retGdsListWork = new List<RecBgnGdsPMWork>((RecBgnGdsPMWork[])retGdsList.ToArray(typeof(RecBgnGdsPMWork)));
            // 拠点、ﾒｰｶｰ、品番、公開開始日順にソート
            retGdsListWork.Sort(new RecBgnGdsAsComparer());

            // 登録済行の追加
            for (int i = 1; i <= retGdsList.Count; i++)
            {
                recBgnGds = this.CopyToRecBgnGdsFromRecBgnGdsPMWork(retGdsListWork[i - 1]);
                RecBgnGdsDataSet.RecBgnGdsRow row = this._recBgnGdsDataTable.NewRecBgnGdsRow();
                row.RowNo = i;
                this.CopyToDetailRowFromRecBgnGds(ref row, recBgnGds);

                // 得意先別設定をセットする
                this.SetGdsToCust(ref row);

                this._recBgnGdsDataTable.AddRecBgnGdsRow(row);
                this._prevRecBgnGdsDic.Add(row.FilterGuid, recBgnGds);
            }

            if (this._deleteSearchMode == false)
            {
                // 新規行の追加
                RecBgnGdsDataSet.RecBgnGdsRow newRow = this._recBgnGdsDataTable.NewRecBgnGdsRow();
                newRow.RowNo = retGdsList.Count + 1;
                newRow.FilterGuid = Guid.Empty;
                newRow.UpdateTime = DateTime.MinValue.ToString("yy/MM/dd");
                newRow.InqOtherEpCd = this._enterpriseCode;
                newRow.GoodsName = string.Empty;
                newRow.GoodsComment = string.Empty;
                newRow.DisplayDivCode = 1;
                newRow.ApplyStaDate = string.Empty;
                newRow.ApplyEndDate = string.Empty;

                this._recBgnGdsDataTable.AddRecBgnGdsRow(newRow);
            }

            this.RecBgnGdsDataTable.EndLoadData();
        }

        /// <summary>
        /// 得意先個別設定関連のデータ設定
        /// </summary>
        private void SetGdsToCust(ref RecBgnGdsDataSet.RecBgnGdsRow newRow)
        {
            // 親子関係
            RecBgnGdsCustInfo recBgnGdsCustInfo = new RecBgnGdsCustInfo();
            recBgnGdsCustInfo.recBgnGdsRow = newRow;

            DataRow[] res = this._recBgnCustDataTable.Select("InqOtherEpCd = '" + newRow.InqOtherEpCd + "'" +
                " AND InqOtherSecCd = '" + newRow.InqOtherSecCd + "'" +
                " AND GoodsNo = '" + newRow.GoodsNo + "'" +
                " AND GoodsMakerCode = " + (Int32)newRow.GoodsMakerCode +
                " AND GoodsApplyStaDate = '" + newRow.ApplyStaDate.Replace("/", "") + "'");

            RecBgnGdsDataSet.RecBgnCustDataTable _recBgnCustDataTableWk = new RecBgnGdsDataSet.RecBgnCustDataTable();

            int rowNo = 1;
            foreach (RecBgnGdsDataSet.RecBgnCustRow RecBgnCustRow in res)
            {
                _recBgnCustDataTableWk.BeginLoadData();
                RecBgnGdsDataSet.RecBgnCustRow row = _recBgnCustDataTableWk.NewRecBgnCustRow();

                row.ItemArray = RecBgnCustRow.ItemArray;
                row.RowNo = rowNo;

                _recBgnCustDataTableWk.AddRecBgnCustRow(row);
                _recBgnCustDataTableWk.EndLoadData();

                rowNo = rowNo + 1;
            }

            recBgnGdsCustInfo.recBgnCust = _recBgnCustDataTableWk;
            this._RecBgnGdsCustInfoDic.Add(newRow.RowNo, recBgnGdsCustInfo);
            if (res.Length > 0)
            {
                newRow.RecBgnCust = "有";
            }
        }

        /// <summary>
        /// 明細行ー＞お買得商品設定マスタ
        /// </summary>
        /// <param name="row">明細行</param>
        /// <param name="RecBgnGds">お買得商品設定マスタ</param>
        /// <remarks>
        /// <br>Note       : 明細行ー＞お買得商品設定マスタ</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private void CopyToDetailRowFromRecBgnGds(ref RecBgnGdsDataSet.RecBgnGdsRow row, RecBgnGds recBgnGds)
        {
            row.UpdateTime = recBgnGds.UpdateDateTime.Date.ToString("yy/MM/dd"); //削除日
            row.FilterGuid = Guid.NewGuid();

            row.InqOtherEpCd = recBgnGds.InqOtherEpCd;                                  // 問合せ先企業コード
            row.InqOtherSecCd = recBgnGds.InqOtherSecCd.Trim().PadLeft(2, '0');         // 問合せ先拠点コード
            if (recBgnGds.InqOtherSecCd.Trim() == ALL_SECTION_CODE)
                row.InqOtherSecNm = ALL_SECTION_NAME;       //拠点名
            else
                row.InqOtherSecNm = this.GetSectionName(recBgnGds.InqOtherSecCd.Trim());    //拠点名
            row.GoodsMakerCode = recBgnGds.GoodsMakerCd;        // ﾒｰｶｰ
            row.GoodsMakerName = recBgnGds.GoodsMakerNm;        // ﾒｰｶｰ名
            row.GoodsNo = recBgnGds.GoodsNo;                    // 品番
            row.GoodsName = recBgnGds.GoodsName;                // 品名
            row.BLGroupCode = recBgnGds.BLGroupCode;            // BLグループコード
            row.BLGoodsCode = recBgnGds.BLGoodsCode;            // BL商品コード
            row.GoodsComment = recBgnGds.GoodsComment;          // 商品コメント
            row.MkrSuggestRtPric = recBgnGds.MkrSuggestRtPric;  // ﾒｰｶｰ希望小売価格
            row.ListPrice = recBgnGds.ListPrice;                // 定価
            row.UnitCalcRate = recBgnGds.UnitCalcRate;          // 単価算出掛率
            row.UnitPrice = recBgnGds.UnitPrice;                // 売単価
            row.ApplyStaDate = recBgnGds.ApplyStaDate.ToString("0000/00/00");          // 適用開始日
            // --- ADD 2015/03/23 Y.Wakita ---------->>>>>
            if (recBgnGds.ApplyEndDate != 0)
            // --- ADD 2015/03/23 Y.Wakita ----------<<<<<
            row.ApplyEndDate = recBgnGds.ApplyEndDate.ToString("0000/00/00");          // 適用終了日
            row.ModelFitDiv = recBgnGds.ModelFitDiv;            // 適合車種区分
            row.CustRateGrpCode = recBgnGds.CustRateGrpCode;    // 得意先掛率グループコード
            row.DisplayDivCode = recBgnGds.DisplayDivCode;      // 表示区分
            row.BrgnGoodsGrpCode = recBgnGds.BrgnGoodsGrpCode;  // お買得商品グループコード
            row.BrgnGoodsGrpName = GetRecBgnGrpName(string.Empty, string.Empty, recBgnGds.BrgnGoodsGrpCode);    // お買得商品グループ名
            row.GoodsImage = recBgnGds.GoodsImage;              // 商品画像
            row.RowDevelopFlg = 1;

            // 商品検索
            string msg = string.Empty;
            GoodsUnitData goodsUnitData = new GoodsUnitData();
            // --- ADD 2015/03/25 Y.Wakita ---------->>>>>
            PartsInfoDataSet partsInfoDataSet = new PartsInfoDataSet();
            Dictionary<Calculator.GoodsInfoKey, List<GoodsPrice>> mkrSuggestRtPricList = new Dictionary<Calculator.GoodsInfoKey, List<GoodsPrice>>();
            Dictionary<Calculator.GoodsInfoKey, List<GoodsPrice>> mkrSuggestRtPricUList = new Dictionary<Calculator.GoodsInfoKey, List<GoodsPrice>>();
            // --- ADD 2015/03/25 Y.Wakita ----------<<<<<

            // --- UPD 2015/03/25 Y.Wakita ---------->>>>>
            //int status = this.SearchPartsFromGoodsNo(row.GoodsNo, row.GoodsMakerCode, out goodsUnitData, out msg);
            int status = this.SearchPartsFromGoodsNo(row.GoodsNo, row.GoodsMakerCode, out goodsUnitData, out partsInfoDataSet, out mkrSuggestRtPricList, out mkrSuggestRtPricUList, out msg);
            // --- UPD 2015/03/25 Y.Wakita ----------<<<<<

            if (goodsUnitData != null)
            {
                if (goodsUnitData.LogicalDeleteCode == 0)
                {
                    // 商品情報
                    row.goodsUnitData = goodsUnitData;
                    // --- ADD 2015/03/25 Y.Wakita ---------->>>>>
                    row.mkrSuggestRtPricList = mkrSuggestRtPricList;
                    row.mkrSuggestRtPricUList = mkrSuggestRtPricUList;
                    // --- ADD 2015/03/25 Y.Wakita ----------<<<<<

                }
            }
        }

        /// <summary>
        /// お買得商品設定マスター＞明細行
        /// </summary>
        /// <param name="row">明細行</param>
        /// <param name="RecBgnGds">お買得商品得意先個別設定マスタ</param>
        /// <remarks>
        /// <br>Note       : お買得商品設定マスター＞明細行</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        public void CopyToRecBgnCustFromDetailRow(RecBgnGdsDataSet.RecBgnCustRow row, ref RecBgnCust recBgnCust)
        {
            if (recBgnCust == null)
            {
                recBgnCust = new RecBgnCust();
            }

            recBgnCust.InqOriginalEpCd = row.InqOriginalEpCd;                               // 問合せ先企業コード
            recBgnCust.InqOriginalSecCd = row.InqOriginalSecCd.ToString().PadLeft(2, '0');  // 問合せ先拠点コード
            recBgnCust.InqOtherEpCd = row.InqOtherEpCd;                                     // 問合せ先企業コード
            recBgnCust.InqOtherSecCd = row.InqOtherSecCd.ToString().PadLeft(2, '0');        // 問合せ先拠点コード
            recBgnCust.GoodsNo = row.GoodsNo;                                               // 商品番号
            recBgnCust.GoodsMakerCd = row.GoodsMakerCode;                            // 商品メーカーコード
            recBgnCust.GoodsApplyStaDate = row.GoodsApplyStaDate;                    // 商品適用開始日
            recBgnCust.CustomerCode = int.Parse(row.CustomerCode);                   // 得意先コード
            recBgnCust.MngSectionCode = row.MngSectionCode;                          // 管理拠点コード
            recBgnCust.MkrSuggestRtPric = row.MkrSuggestRtPric;                      // ﾒｰｶｰ希望小売価格
            recBgnCust.ListPrice = row.ListPrice;                                    // 定価
            recBgnCust.UnitCalcRate = row.UnitCalcRate;                              // 単価算出掛率
            recBgnCust.UnitPrice = row.UnitPrice;                                    // 単価

            int startDate = 0;  // 適用開始日
            if (!row.ApplyStaDate.Replace("/", "").Equals(string.Empty)) startDate = int.Parse(row.ApplyStaDate.Replace("/", ""));
            recBgnCust.ApplyStaDate = startDate;
            int endDate = 0;    // 適用終了日
            if (!row.ApplyEndDate.Replace("/", "").Equals(string.Empty)) endDate = int.Parse(row.ApplyEndDate.Replace("/", ""));
            recBgnCust.ApplyEndDate = endDate;
            recBgnCust.DisplayDivCode = row.DisplayDivCode;
            recBgnCust.BrgnGoodsGrpCode = row.BrgnGoodsGrpCode;  // お買得商品グループコード
        }

        /// <summary>
        /// お買得商品設定マスター＞明細行
        /// </summary>
        /// <param name="row">明細行</param>
        /// <param name="RecBgnGds">お買得商品設定マスタ</param>
        /// <remarks>
        /// <br>Note       : お買得商品設定マスター＞明細行</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        public void CopyToRecBgnGdsFromDetailRow(RecBgnGdsDataSet.RecBgnGdsRow row, ref RecBgnGds recBgnGds)
        {
            if (recBgnGds == null)
            {
                recBgnGds = new RecBgnGds();
            }
            recBgnGds.InqOtherEpCd = row.InqOtherEpCd;                              // 問合せ先企業コード
            recBgnGds.InqOtherSecCd = row.InqOtherSecCd.ToString().PadLeft(2, '0'); // 問合せ先拠点コード
            recBgnGds.GoodsNo = row.GoodsNo;                                        // 商品番号
            recBgnGds.GoodsMakerCd = row.GoodsMakerCode;                            // 商品メーカーコード
            recBgnGds.GoodsMakerNm = row.GoodsMakerName;                            // 商品メーカー名称
            if (row.IsGoodsNameNull())
                recBgnGds.GoodsName = string.Empty;                                 // 商品名称
            else
                recBgnGds.GoodsName = row.GoodsName;                                // 商品名称
            recBgnGds.BLGroupCode = row.BLGroupCode;                                // BLグループコード
            recBgnGds.BLGoodsCode = row.BLGoodsCode;                                // BL商品コード
            if (row.IsGoodsCommentNull())
                recBgnGds.GoodsComment = string.Empty;                              // 商品コメント
            else
                recBgnGds.GoodsComment = row.GoodsComment;                          // 商品コメント
            recBgnGds.MkrSuggestRtPric = row.MkrSuggestRtPric;                      // ﾒｰｶｰ希望小売価格
            recBgnGds.ListPrice = row.ListPrice;                                    // 定価
            recBgnGds.UnitCalcRate = row.UnitCalcRate;                              // 単価算出掛率
            recBgnGds.UnitPrice = row.UnitPrice;                                    // 単価

            int startDate = 0;  // 公開開始日
            if (!row.ApplyStaDate.Replace("/", "").Equals(string.Empty)) startDate = int.Parse(row.ApplyStaDate.Replace("/", ""));
            recBgnGds.ApplyStaDate = startDate;
            int endDate = 0;    // 公開終了日
            if (!row.ApplyEndDate.Replace("/", "").Equals(string.Empty)) endDate = int.Parse(row.ApplyEndDate.Replace("/", ""));
            recBgnGds.ApplyEndDate = endDate;

            recBgnGds.ModelFitDiv = row.ModelFitDiv;            // 適合車種区分
            recBgnGds.CustRateGrpCode = 0;                      // 得意先掛率グループコード
            recBgnGds.DisplayDivCode = row.DisplayDivCode;      // 表示区分
            recBgnGds.BrgnGoodsGrpCode = row.BrgnGoodsGrpCode;  // お買得商品グループコード
            if (row.IsGoodsImageNull())                         // 商品画像
                recBgnGds.GoodsImage = new Byte[0];
            else
                recBgnGds.GoodsImage = row.GoodsImage;          // 商品画像
            recBgnGds.RowIndex = row.RowNo;
        }

        /// <summary>
        /// お買得商品設定マスタ比較処理
        /// </summary>
        /// <param name="recBgnGds1">お買得商品設定マスタ</param>
        /// <param name="recBgnGds2">お買得商品設定マスタ</param>
        /// <returns>true:不同、false:同じ</returns>
        /// <remarks>
        /// <br>Note       : お買得商品設定マスタ比較処理</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        public bool Compare(RecBgnGds recBgnGds1, RecBgnGds recBgnGds2)
        {
            if (recBgnGds1.GoodsName != recBgnGds2.GoodsName
                || recBgnGds1.GoodsComment != recBgnGds2.GoodsComment
                || recBgnGds1.GoodsImage != recBgnGds2.GoodsImage
                || recBgnGds1.BrgnGoodsGrpCode != recBgnGds2.BrgnGoodsGrpCode
                || recBgnGds1.DisplayDivCode != recBgnGds2.DisplayDivCode
                || recBgnGds1.ApplyStaDate != recBgnGds2.ApplyStaDate
                || recBgnGds1.ApplyEndDate != recBgnGds2.ApplyEndDate
                || recBgnGds1.MkrSuggestRtPric != recBgnGds2.MkrSuggestRtPric   // ADD 2015/03/25 Y.Wakita
                || recBgnGds1.ListPrice != recBgnGds2.ListPrice                 // ADD 2015/03/25 Y.Wakita
                || recBgnGds1.UnitCalcRate != recBgnGds2.UnitCalcRate
                || recBgnGds1.UnitPrice != recBgnGds2.UnitPrice)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// お買得商品設定マスタ比較処理
        /// </summary>
        /// <param name="recBgnGds1">お買得商品設定マスタ</param>
        /// <param name="recBgnGds2">お買得商品設定マスタ</param>
        /// <returns>true:不同、false:同じ</returns>
        /// <remarks>
        /// <br>Note       : お買得商品設定マスタ比較処理</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        public bool CompareKey(RecBgnGds recBgnGds1, RecBgnGds recBgnGds2)
        {
            if (recBgnGds1.InqOtherSecCd != recBgnGds2.InqOtherSecCd
             || recBgnGds1.GoodsNo != recBgnGds2.GoodsNo 
             || recBgnGds1.GoodsMakerCd != recBgnGds2.GoodsMakerCd 
             || recBgnGds1.ApplyStaDate != recBgnGds2.ApplyStaDate)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 抽出条件比較処理
        /// </summary>
        /// <param name="recBgnGdsSearchPara1">抽出条件1</param>
        /// <param name="recBgnGdsSearchPara2">抽出条件2</param>
        /// <returns>true:同、false:不同</returns>
        /// <remarks>
        /// <br>Note       : 抽出条件比較処理</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        public bool CompareRecBgnGdsSearchPara(RecBgnGdsSearchPara recBgnGdsSearchPara1, RecBgnGdsSearchPara recBgnGdsSearchPara2)
        {
            //検索条件が変更なしの場合は検索しない
            if (recBgnGdsSearchPara1.InqOtherSecCd == recBgnGdsSearchPara2.InqOtherSecCd
                && recBgnGdsSearchPara1.GoodsMakerCdSt == recBgnGdsSearchPara2.GoodsMakerCdSt
                && recBgnGdsSearchPara1.GoodsMakerCdEd == recBgnGdsSearchPara2.GoodsMakerCdEd
                && recBgnGdsSearchPara1.GoodsNo.Trim() == recBgnGdsSearchPara2.GoodsNo.Trim()
                && recBgnGdsSearchPara1.ApplyDateSt == recBgnGdsSearchPara2.ApplyDateSt
                && recBgnGdsSearchPara1.ApplyDateEd == recBgnGdsSearchPara2.ApplyDateEd
                && recBgnGdsSearchPara1.DeleteFlag == recBgnGdsSearchPara2.DeleteFlag)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 新規行の判断処理
        /// </summary>
        /// <param name="row">新規行</param>
        /// <returns>true:不同、false:同じ</returns>
        /// <remarks>
        /// <br>Note       : 新規行の判断処理</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        public bool IsRowUpdate(RecBgnGdsDataSet.RecBgnGdsRow row)
        {
            int startDate = 0;
            if (!row.ApplyStaDate.Equals(string.Empty)) startDate = int.Parse(row.ApplyStaDate.Trim().Replace("/", ""));
            int endDate = 0;
            if (!row.ApplyEndDate.Equals(string.Empty)) endDate = int.Parse(row.ApplyEndDate.Trim().Replace("/", ""));

            if (row.GoodsNo.Trim() != this._newRecBgnGdsObj.GoodsNo.Trim()
                || row.GoodsName.Trim() != this._newRecBgnGdsObj.GoodsName.Trim()
                || row.GoodsMakerCode != this._newRecBgnGdsObj.GoodsMakerCd
                || row.GoodsComment != this._newRecBgnGdsObj.GoodsComment
                || startDate != this._newRecBgnGdsObj.ApplyStaDate
                || endDate != this._newRecBgnGdsObj.ApplyEndDate
                || row.UnitPrice != this._newRecBgnGdsObj.UnitPrice
                || row.IsGoodsImageNull() != true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// マスタデータ取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : マスタデータ取得処理</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        public void LoadMstData()
        {
            this._masterAcsThread = new Thread(new ThreadStart(MasterThreadProc));   // マスタデータ取得スレッド
            this._goodsAcsThread = new Thread(new ThreadStart(GoodsThreadProc));   // 商品データ取得スレッド
            this._goodsAcsThread.Start();
            this._masterAcsThread.Start();
        }

        /// <summary>
        /// マスタデータ取得スレッド
        /// </summary>
        /// <remarks>
        /// <br>Note       : マスタデータ取得スレッド</br>
        /// <br>Programmer : 許雁波</br>
        /// <br>Date       : 2011/08/12</br>
        /// </remarks>
        public void MasterThreadProc()
        {
            this.LoadMakerUMnt();//メーカーマスタの読み込み

            this.LoadBlCodeMst();//BLマスタの読み込み

            this.LoadBlGroupMst();//BLグループマスタの読み込み

            this.CacheUserGd();//ユーザーガイドマスタの読み込み

            this.ReadSecInfoSet();//拠点マスタの読み込み

            this.GetCustomerSearchRetList();//得意先マスタの読み込み

            this.LoadScmEpScCnt();//SCM企業連結データの読み込み

            this.LoadRecBgnGds();//お買得商品設定マスタの読み込み

            this.LoadRecBgnGrp();//お買得商品グループ設定マスタの読み込み

            this.LoadAllDefSet(); //全体初期値設定マスタの読み込み
        }

        /// <summary>
        /// 商品データ取得スレッド
        /// </summary>
        /// <remarks>
        /// <br>Note       : 商品データ取得スレッド</br>
        /// <br>Programmer : 許雁波</br>
        /// <br>Date       : 2011/08/12</br>
        /// </remarks>
        public void GoodsThreadProc()
        {
            // 商品アクセスクラス初期処理(キャッシュなし)
            string retMessage;
            this._goodsAcs = new GoodsAcs();
            this._goodsAcs.IsLocalDBRead = false;
            this._goodsAcs.Owner = this._owner;
            this._goodsAcs.IsGetSupplier = true;
            this._goodsAcs.SearchInitial(this._enterpriseCode, this._loginSectionCode, out retMessage);
        }

        /// <summary>
        /// BlCodeマスタデータ取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : BlCodeマスタデータ取得処理</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private void LoadBlCodeMst()
        {
            this._blGoodsCdDic = new Dictionary<int, BLGoodsCdUMnt>();

            try
            {
                ArrayList retList;

                int status = _blGoodsCdAcs.SearchAll(out retList, this._enterpriseCode);

                if (status == 0)
                {
                    foreach (BLGoodsCdUMnt blGoodsCdUMnt in retList)
                    {
                        if (blGoodsCdUMnt.LogicalDeleteCode != 0)
                        {
                            continue;
                        }

                        this._blGoodsCdDic.Add(blGoodsCdUMnt.BLGoodsCode, blGoodsCdUMnt);
                    }
                }
            }
            catch
            {

                this._blGoodsCdDic = new Dictionary<int, BLGoodsCdUMnt>();
            }
        }

        /// <summary>
        /// Blグループマスタデータ取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : Blグループマスタデータ取得処理</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private void LoadBlGroupMst()
        {
            this._blGroupDic = new Dictionary<int, BLGroupU>();

            try
            {
                ArrayList retList;

                int status = this._blGroupUAcs.SearchAll(out retList, this._enterpriseCode);

                if (status == 0)
                {
                    foreach (BLGroupU bLGroupU in retList)
                    {
                        if (bLGroupU.LogicalDeleteCode != 0)
                        {
                            continue;
                        }

                        this._blGroupDic.Add(bLGroupU.BLGroupCode, bLGroupU);
                    }
                }
            }
            catch
            {

                this._blGroupDic = new Dictionary<int, BLGroupU>();
            }
        }

        /// <summary>
        /// UserGdマスタデータ取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : UserGdマスタデータ取得処理</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private void CacheUserGd()
        {
            this._userGdBdDic = new Dictionary<int, UserGdBd>();

            try
            {
                ArrayList userGdBdList;

                int status = this._userGuideAcs.SearchDivCodeBody(out userGdBdList, this._enterpriseCode, 71, UserGuideAcsData.UserBodyData);

                if (status == 0)
                {
                    foreach (UserGdBd userGdBd in userGdBdList)
                    {
                        if (userGdBd.LogicalDeleteCode != 0)
                        {
                            continue;
                        }

                        this._userGdBdDic.Add(userGdBd.GuideCode, userGdBd);
                    }
                }
            }
            catch
            {
                this._userGdBdDic = new Dictionary<int, UserGdBd>();
            }
        }

        /// <summary>
        /// メーカーマスタ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : メーカーマスタ読込処理を行います。</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private void LoadMakerUMnt()
        {
            this._makerUMntDic = new Dictionary<int, MakerUMnt>();

            try
            {
                ArrayList retList;

                int status = this._makerAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (MakerUMnt makerUMnt in retList)
                    {
                        if (makerUMnt.LogicalDeleteCode != 0)
                        {
                            continue;
                        }

                        this._makerUMntDic.Add(makerUMnt.GoodsMakerCd, makerUMnt);
                    }
                }
            }
            catch
            {
                this._makerUMntDic = new Dictionary<int, MakerUMnt>();
            }
        }

        /// <summary>
        /// 拠点情報マスタ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 拠点情報マスタ読込処理</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private void ReadSecInfoSet()
        {
            this._secInfoSetDic = new Dictionary<string, SecInfoSet>();

            foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
            {
                if (secInfoSet.LogicalDeleteCode == 0)
                {
                    this._secInfoSetDic.Add(secInfoSet.SectionCode.Trim().PadLeft(2, '0'), secInfoSet);
                }
            }
        }

        /// <summary>
        /// 得意先マスタ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 得意先マスタ読込処理</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private void GetCustomerSearchRetList()
        {
            this._customerDic = new Dictionary<int, CustomerInfo>();

            try
            {
                List<CustomerInfo> customerInfoList;

                int status = this._customerInfoAcs.Search(this._enterpriseCode, false, false, out customerInfoList);

                if (status == 0)
                {
                    foreach (CustomerInfo customerInfo in customerInfoList)
                    {
                        if (customerInfo.LogicalDeleteCode != 0)
                        {
                            // 論理削除されている場合
                            continue;
                        }
                        this._customerSearchRetList.Add(CopytoCustomerSearchRetFromCustmorInfo(customerInfo));
                        this._customerDic.Add(customerInfo.CustomerCode, customerInfo);
                    }
                }
            }
            catch
            {
                this._customerDic = new Dictionary<int, CustomerInfo>();
            }
        }


        private CustomerSearchRet CopytoCustomerSearchRetFromCustmorInfo(CustomerInfo customerInfo)
        {
            CustomerSearchRet customerSearchRet = new CustomerSearchRet();
            customerSearchRet.AcceptWholeSale = customerInfo.AcceptWholeSale;
            customerSearchRet.Address1 = customerInfo.Address1;
            customerSearchRet.Address3 = customerInfo.Address3;
            customerSearchRet.Address4 = customerInfo.Address4;
            customerSearchRet.CustomerAgentCd = customerInfo.CustomerAgentCd;
            customerSearchRet.CustomerAgentNm = customerInfo.CustomerAgentNm;
            customerSearchRet.CustomerCode = customerInfo.CustomerCode;
            customerSearchRet.CustomerEpCode = customerInfo.CustomerEpCode;
            customerSearchRet.CustomerSecCode = customerInfo.CustomerSecCode;
            customerSearchRet.CustomerSlipNoDiv = customerInfo.CustomerSlipNoDiv;
            customerSearchRet.CustomerSubCode = customerInfo.CustomerSubCode;
            customerSearchRet.EnterpriseCode = customerInfo.EnterpriseCode;
            customerSearchRet.EnterpriseName = customerInfo.EnterpriseName;
            customerSearchRet.HomeFaxNo = customerInfo.HomeFaxNo;
            customerSearchRet.HomeTelNo = customerInfo.HomeTelNo;
            customerSearchRet.HonorificTitle = customerInfo.HonorificTitle;
            customerSearchRet.Kana = customerInfo.Kana;
            customerSearchRet.LogicalDeleteCode = customerInfo.LogicalDeleteCode;
            customerSearchRet.MngSectionCode = customerInfo.MngSectionCode;
            customerSearchRet.Name = customerInfo.Name;
            customerSearchRet.Name2 = customerInfo.Name2;
            customerSearchRet.OfficeFaxNo = customerInfo.OfficeFaxNo;
            customerSearchRet.OfficeTelNo = customerInfo.OfficeTelNo;
            customerSearchRet.OnlineKindDiv = customerInfo.OnlineKindDiv;
            customerSearchRet.PortableTelNo = customerInfo.PortableTelNo;
            customerSearchRet.PostNo = customerInfo.PostNo;
            customerSearchRet.SearchTelNo = customerInfo.SearchTelNo;
            customerSearchRet.SimplInqAcntAcntGrId = customerInfo.SimplInqAcntAcntGrId;
            customerSearchRet.Snm = customerInfo.CustomerSnm;
            customerSearchRet.TotalDay = customerInfo.TotalDay;
            customerSearchRet.UpdateDate = customerInfo.UpdateDateTime;


            return customerSearchRet;
        }

        /// <summary>
        /// SCM企業連結データ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : SCM企業連結データ読込処理を行います。</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        public void LoadScmEpScCnt()
        {
            try
            {
                bool msgDiv;
                string errMsg;
                List<ScmEpScCnt> scmEpScCntList;

                int status = this._scmEpScCntAcs.SearchCnectOriginalEpFromSc(this._enterpriseCode, ConstantManagement.LogicalMode.GetData01, out scmEpScCntList, out msgDiv, out errMsg);
                if (status == 0)
                {
                    this._scmEpScCntList = scmEpScCntList;
                }
            }
            catch
            {
                this._scmEpScCntList = new List<ScmEpScCnt>();
            }
        }

        /// <summary>
        /// お買得商品設定マスタ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : お買得商品設定マスタ読込処理を行います。</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private void LoadRecBgnGds()
        {
            this._recBgnGdsList = new List<RecBgnGds>();

            try
            {
                ArrayList retList = new ArrayList();
                object retObj = retList as object;
                object retCustObj = retList as object;

                string msg = string.Empty;

                int status = this._iRecBgnGdsDB.Search(out retObj, out retCustObj, this._enterpriseCode, ConstantManagement.LogicalMode.GetData01, ref msg);
                if (status == 0)
                {
                    retList = retObj as ArrayList;
                    RecBgnGds recBgnGds;
                    foreach (RecBgnGdsPMWork recBgnGdsWork in retList)
                    {
                        recBgnGds = CopyToRecBgnGdsFromRecBgnGdsPMWork(recBgnGdsWork);
                        this._recBgnGdsList.Add(recBgnGds);
                    }
                }
            }
            catch
            {
                this._recBgnGdsList = new List<RecBgnGds>();
            }
        }

        /// <summary>
        /// お買得商品グループ設定マスタ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : お買得商品グループ設定マスタ読込処理を行います。</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private void LoadRecBgnGrp()
        {

            this._recBgnGrpWorkList = new List<RecBgnGrpRet>(); 

            try
            {
                RecBgnGrpRet[] ret = null;
                ArrayList retList = new ArrayList();
                RecBgnGrpPara para = new RecBgnGrpPara();
                // --- UPD 2015/03/09 Y.Wakita Redmine#343 ---------->>>>>
                //int status = this._recBgnGrpAcs.Search(out ret, para);
                int status = this._recBgnGrpAcs.Search(out ret, this._enterpriseCode);
                // --- UPD 2015/03/09 Y.Wakita Redmine#343 ----------<<<<<
                if (status == 0)
                {
                    retList.AddRange(ret);
                    foreach (RecBgnGrpRet recBgnGrop in retList)
                    {
                        if (recBgnGrop.LogicalDeleteCode != 0)
                        {
                            continue;
                        }

                        this._recBgnGrpWorkList.Add(recBgnGrop);
                    }
                }
            }
            catch
            {
                this._recBgnGrpWorkList = new List<RecBgnGrpRet>();
            }
        }

        /// <summary>
        /// 全体初期値設定マスタを取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 全体初期値設定マスタの取得を行います。</br>
        /// <br>Programmer : 宮本 利明</br>
        /// <br>Date       : 2015/02/26</br>
        /// </remarks>
        private void LoadAllDefSet()
        {
            this._allDefSet = new AllDefSet();

            try
            {
                int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
                AllDefSetAcs allDefSetAcs = new AllDefSetAcs();
                AllDefSetAcs.SearchMode allDefSetSearchMode = AllDefSetAcs.SearchMode.Remote;
                ArrayList retAllDefSetList;
                status = allDefSetAcs.Search(out retAllDefSetList, this._enterpriseCode, allDefSetSearchMode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ログイン担当者の所属拠点もしくは全社設定を取得
                    this._allDefSet = this.GetAllDefSetFromList(LoginInfoAcquisition.Employee.BelongSectionCode, retAllDefSetList);
                }
                else
                {
                    this._allDefSet = null;
                }
            }
            catch
            {
                this._allDefSet = new AllDefSet();
            }
        }
        /// <summary>
        /// 全体初期値設定マスタのリスト中から、指定した拠点で使用する設定を取得します。(拠点コードが無ければ全社設定）
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="allDefSetArrayList">全体初期値設定マスタオブジェクトリスト</param>
        /// <returns>全体初期値設定マスタオブジェクト</returns>
        /// <remarks>
        /// <br>Programmer : 宮本 利明</br>
        /// <br>Date       : 2015/02/26</br>
        /// </remarks>
        private AllDefSet GetAllDefSetFromList(string sectionCode, ArrayList allDefSetArrayList)
        {
            AllDefSet allSecAllDefSet = null;

            foreach (AllDefSet allDefSet in allDefSetArrayList)
            {
                if (allDefSet.SectionCode.Trim() == sectionCode.Trim())
                {
                    return allDefSet;
                }
                else if (allDefSet.SectionCode.Trim() == ALL_SECTION_CODE)
                {
                    allSecAllDefSet = allDefSet;
                }
            }

            return allSecAllDefSet;
        }
        /// <summary>
        /// RecBgnGdsSearchPara->RecBgnGdsSearchParaWork
        /// </summary>
        /// <param name="searchCondition">検索条件</param>
        /// <returns>検索条件</returns>
        /// <remarks>
        /// <br>Note       : RecBgnGdsSearchPara->RecBgnGdsSearchParaWork</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private RecBgnGdsSearchParaWork CopyToRecBgnGdsSearchParaWorkFromRecBgnGdsSearchPara(RecBgnGdsSearchPara recBgnGdsSearchPara)
        {
            RecBgnGdsSearchParaWork recBgnGdsSearchParaWork = new RecBgnGdsSearchParaWork();

            recBgnGdsSearchParaWork.InqOtherEpCd = recBgnGdsSearchPara.InqOtherEpCd;        // 問合せ先企業コード
            recBgnGdsSearchParaWork.InqOtherSecCd = recBgnGdsSearchPara.InqOtherSecCd;      // 問合せ先拠点コード
            recBgnGdsSearchParaWork.GoodsMakerCdSt = recBgnGdsSearchPara.GoodsMakerCdSt;    // 商品メーカーコード（開始）
            recBgnGdsSearchParaWork.GoodsMakerCdEd = recBgnGdsSearchPara.GoodsMakerCdEd;    // 商品メーカーコード（終了）
            recBgnGdsSearchParaWork.ApplyDateSt = recBgnGdsSearchPara.ApplyDateSt;          // 公開日（開始）
            recBgnGdsSearchParaWork.ApplyDateEd = recBgnGdsSearchPara.ApplyDateEd;          // 公開日（終了）
            recBgnGdsSearchParaWork.GoodsNo = recBgnGdsSearchPara.GoodsNo;                  // 商品番号
            recBgnGdsSearchParaWork.DeleteFlag = recBgnGdsSearchPara.DeleteFlag;            // 削除区分

            return recBgnGdsSearchParaWork;
        }

        #region お買得商品設定
        /// <summary>
        /// RecBgnGdsPMWork->RecBgnGds
        /// </summary>
        /// <param name="RecBgnGdsPMWork">お買得商品設定ワーク</param>
        /// <returns>お買得商品設定</returns>
        /// <remarks>
        /// <br>Note       : RecBgnGdsWork->RecBgnGds</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private RecBgnGds CopyToRecBgnGdsFromRecBgnGdsPMWork(RecBgnGdsPMWork recBgnGdsPMWork)
        {
            RecBgnGds recBgnGds = new RecBgnGds();

            recBgnGds.CreateDateTime = recBgnGdsPMWork.CreateDateTime;        // 作成日時
            recBgnGds.UpdateDateTime = recBgnGdsPMWork.UpdateDateTime;        // 更新日時
            recBgnGds.LogicalDeleteCode = recBgnGdsPMWork.LogicalDeleteCode;  // 論理削除区分
            recBgnGds.InqOtherEpCd = recBgnGdsPMWork.InqOtherEpCd;            // 問合せ先企業コード
            recBgnGds.InqOtherSecCd = recBgnGdsPMWork.InqOtherSecCd;          // 問合せ先拠点コード
            recBgnGds.GoodsNo = recBgnGdsPMWork.GoodsNo;                      // 商品番号
            recBgnGds.GoodsMakerCd = recBgnGdsPMWork.GoodsMakerCd;            // 商品メーカーコード
            recBgnGds.GoodsMakerNm = recBgnGdsPMWork.GoodsMakerNm;            // 商品メーカー名称
            recBgnGds.GoodsName = recBgnGdsPMWork.GoodsName;                  // 商品名称
            recBgnGds.BLGroupCode = recBgnGdsPMWork.BLGroupCode;              // BLグループコード
            recBgnGds.BLGoodsCode = recBgnGdsPMWork.BLGoodsCode;              // BL商品コード
            recBgnGds.GoodsComment = recBgnGdsPMWork.GoodsComment;            // 商品コメント
            recBgnGds.MkrSuggestRtPric = recBgnGdsPMWork.MkrSuggestRtPric;    // ﾒｰｶｰ希望小売価格
            recBgnGds.ListPrice = recBgnGdsPMWork.ListPrice;                  // 定価
            recBgnGds.UnitCalcRate = recBgnGdsPMWork.UnitCalcRate;            // 単価算出掛率
            recBgnGds.UnitPrice = recBgnGdsPMWork.UnitPrice;                  // 単価
            recBgnGds.ApplyStaDate = recBgnGdsPMWork.ApplyStaDate;            // 適用開始日
            recBgnGds.ApplyEndDate = recBgnGdsPMWork.ApplyEndDate;            // 適用終了日
            recBgnGds.ModelFitDiv = recBgnGdsPMWork.ModelFitDiv;              // 適合車種区分
            recBgnGds.CustRateGrpCode = recBgnGdsPMWork.CustRateGrpCode;      // 得意先掛率グループコード
            if (recBgnGdsPMWork.DisplayDivCode == 0)
                recBgnGds.DisplayDivCode = 1;        // 表示区分
            else
                recBgnGds.DisplayDivCode = 0;        // 表示区分
            recBgnGds.BrgnGoodsGrpCode = recBgnGdsPMWork.BrgnGoodsGrpCode;    // お買得商品グループコード
            recBgnGds.GoodsImage = recBgnGdsPMWork.GoodsImage;                // 商品画像

            return recBgnGds;
        }

        /// <summary>
        /// RecBgnGds->RecBgnGdsPMWork
        /// </summary>
        /// <param name="RecBgnGdsWork">お買得商品設定</param>
        /// <returns>お買得商品設定ワーク</returns>
        /// <remarks>
        /// <br>Note       : RecBgnGds->RecBgnGdsWork</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private RecBgnGdsPMWork CopyToRecBgnGdsPMWorkFromRecBgnGds(RecBgnGds recBgnGds)
        {
            RecBgnGdsPMWork recBgnGdsPMWork = new RecBgnGdsPMWork();

            recBgnGdsPMWork.CreateDateTime = recBgnGds.CreateDateTime;        // 作成日時
            recBgnGdsPMWork.UpdateDateTime = recBgnGds.UpdateDateTime;        // 更新日時
            recBgnGdsPMWork.LogicalDeleteCode = recBgnGds.LogicalDeleteCode;  // 論理削除区分
            recBgnGdsPMWork.InqOtherEpCd = recBgnGds.InqOtherEpCd;            // 問合せ先企業コード
            recBgnGdsPMWork.InqOtherSecCd = recBgnGds.InqOtherSecCd;          // 問合せ先拠点コード
            recBgnGdsPMWork.GoodsNo = recBgnGds.GoodsNo;                      // 商品番号
            recBgnGdsPMWork.GoodsMakerCd = recBgnGds.GoodsMakerCd;            // 商品メーカーコード
            recBgnGdsPMWork.GoodsMakerNm = recBgnGds.GoodsMakerNm;            // 商品メーカー名称
            recBgnGdsPMWork.GoodsName = recBgnGds.GoodsName;                  // 商品名称
            recBgnGdsPMWork.BLGroupCode = recBgnGds.BLGroupCode;              // BLグループコード
            recBgnGdsPMWork.BLGoodsCode = recBgnGds.BLGoodsCode;              // BL商品コード
            recBgnGdsPMWork.GoodsComment = recBgnGds.GoodsComment;            // 商品コメント
            recBgnGdsPMWork.MkrSuggestRtPric = recBgnGds.MkrSuggestRtPric;    // ﾒｰｶｰ希望小売価格
            recBgnGdsPMWork.ListPrice = recBgnGds.ListPrice;                  // 定価
            recBgnGdsPMWork.UnitCalcRate = recBgnGds.UnitCalcRate;            // 単価算出掛率
            recBgnGdsPMWork.UnitPrice = recBgnGds.UnitPrice;                  // 単価
            recBgnGdsPMWork.ApplyStaDate = recBgnGds.ApplyStaDate;            // 適用開始日
            recBgnGdsPMWork.ApplyEndDate = recBgnGds.ApplyEndDate;            // 適用終了日
            recBgnGdsPMWork.ModelFitDiv = recBgnGds.ModelFitDiv;              // 適合車種区分
            recBgnGdsPMWork.CustRateGrpCode = recBgnGds.CustRateGrpCode;      // 得意先掛率グループコード
            if (recBgnGds.DisplayDivCode == 0)
                recBgnGdsPMWork.DisplayDivCode = 1;        // 表示区分
            else
                recBgnGdsPMWork.DisplayDivCode = 0;        // 表示区分
            recBgnGdsPMWork.BrgnGoodsGrpCode = recBgnGds.BrgnGoodsGrpCode;    // お買得商品グループコード
            if (recBgnGds.GoodsImage != null)
                recBgnGdsPMWork.GoodsImage = recBgnGds.GoodsImage;            // 商品画像
            else
                recBgnGdsPMWork.GoodsImage = new Byte[0];

            return recBgnGdsPMWork;
        }
        #endregion

        #region お買得商品得意先個別設定
        /// <summary>
        /// RecBgnCustPMWork->RecBgnCust
        /// </summary>
        /// <param name="RecBgnCustPMWork">お買得商品得意先個別設定ワーク</param>
        /// <returns>お買得商品得意先個別設定</returns>
        /// <remarks>
        /// <br>Note       : RecBgnCustPMWork->RecBgnCust</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private void CopyToDetailRowFromRecBgnCust(ref RecBgnGdsDataSet.RecBgnCustRow row, RecBgnCust recBgnCust)
        {
            row.UpdateTime = recBgnCust.UpdateDateTime.Date.ToString("yy/MM/dd"); //削除日
            row.FilterGuid = Guid.NewGuid();

            row.InqOriginalEpCd = recBgnCust.InqOriginalEpCd;      // 問合せ元企業コード
            row.InqOriginalSecCd = recBgnCust.InqOriginalSecCd;    // 問合せ元拠点コード
            row.InqOtherEpCd = recBgnCust.InqOtherEpCd;            // 問合せ先企業コード
            row.InqOtherSecCd = recBgnCust.InqOtherSecCd;          // 問合せ先拠点コード
            row.GoodsNo = recBgnCust.GoodsNo;                      // 商品番号
            row.GoodsMakerCode = recBgnCust.GoodsMakerCd;          // 商品メーカーコード
            row.GoodsApplyStaDate = recBgnCust.GoodsApplyStaDate;  // 商品適用開始日
            row.CustomerCode = recBgnCust.CustomerCode.ToString().PadLeft(8, '0');          // 得意先コード
            row.CustomerName = this.GetCustomerName(recBgnCust.CustomerCode);    // 得意先名;
            row.MngSectionCode = recBgnCust.MngSectionCode;        // 管理拠点コード
            row.MkrSuggestRtPric = recBgnCust.MkrSuggestRtPric;    // ﾒｰｶｰ希望小売価格
            row.ListPrice = recBgnCust.ListPrice;                  // 定価
            row.UnitCalcRate = recBgnCust.UnitCalcRate;            // 単価算出掛率
            row.UnitPrice = recBgnCust.UnitPrice;                  // 単価

            string startDate = string.Empty;                                                                    // 適用開始日
            if (recBgnCust.ApplyStaDate != 0) startDate = recBgnCust.ApplyStaDate.ToString("0000/00/00");
            row.ApplyStaDate = startDate;
            string endDate = string.Empty;                                                                      // 適用終了日
            if (recBgnCust.ApplyEndDate != 0) endDate = recBgnCust.ApplyEndDate.ToString("0000/00/00");
            row.ApplyEndDate = endDate;
            row.DisplayDivCode = recBgnCust.DisplayDivCode;
            row.BrgnGoodsGrpCode = recBgnCust.BrgnGoodsGrpCode;    // お買得商品グループコード
            // --- ADD 2015/03/03 Y.Wakita Redmine#307 ---------->>>>>
            row.BrgnGoodsGrpName = GetRecBgnGrpName(string.Empty, string.Empty, recBgnCust.BrgnGoodsGrpCode);    // お買得商品グループ名
            // --- ADD 2015/03/03 Y.Wakita Redmine#307 ----------<<<<<
            row.RowDevelopFlg = 1;
        }

        /// <summary>
        /// RecBgnGdsPMWork->RecBgnGds
        /// </summary>
        /// <param name="RecBgnGdsPMWork">お買得商品設定ワーク</param>
        /// <returns>お買得商品設定</returns>
        /// <remarks>
        /// <br>Note       : RecBgnGdsWork->RecBgnGds</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private RecBgnCust CopyToRecBgnCustFromRecBgnCustPMWork(RecBgnCustPMWork recBgnCustPMWork)
        {
            RecBgnCust recBgnCust = new RecBgnCust();

            recBgnCust.CreateDateTime = recBgnCustPMWork.CreateDateTime;        // 作成日時
            recBgnCust.UpdateDateTime = recBgnCustPMWork.UpdateDateTime;        // 更新日時
            recBgnCust.LogicalDeleteCode = recBgnCustPMWork.LogicalDeleteCode;  // 論理削除区分
            recBgnCust.InqOriginalEpCd = recBgnCustPMWork.InqOriginalEpCd;      // 問合せ元企業コード
            recBgnCust.InqOriginalSecCd = recBgnCustPMWork.InqOriginalSecCd;    // 問合せ元拠点コード
            recBgnCust.InqOtherEpCd = recBgnCustPMWork.InqOtherEpCd;            // 問合せ先企業コード
            recBgnCust.InqOtherSecCd = recBgnCustPMWork.InqOtherSecCd;          // 問合せ先拠点コード
            recBgnCust.GoodsNo = recBgnCustPMWork.GoodsNo;                      // 商品番号
            recBgnCust.GoodsMakerCd = recBgnCustPMWork.GoodsMakerCd;            // 商品メーカーコード
            recBgnCust.GoodsApplyStaDate = recBgnCustPMWork.GoodsApplyStaDate;  // 商品適用開始日
            recBgnCust.CustomerCode = recBgnCustPMWork.CustomerCode;            // 得意先コード
            recBgnCust.MngSectionCode = recBgnCustPMWork.MngSectionCode;        // 管理拠点コード
            recBgnCust.MkrSuggestRtPric = recBgnCustPMWork.MkrSuggestRtPric;    // ﾒｰｶｰ希望小売価格
            recBgnCust.ListPrice = recBgnCustPMWork.ListPrice;                  // 定価
            recBgnCust.UnitCalcRate = recBgnCustPMWork.UnitCalcRate;            // 単価算出掛率
            recBgnCust.UnitPrice = recBgnCustPMWork.UnitPrice;                  // 単価
            recBgnCust.ApplyStaDate = recBgnCustPMWork.ApplyStaDate;            // 適用開始日
            recBgnCust.ApplyEndDate = recBgnCustPMWork.ApplyEndDate;            // 適用終了日
            if (recBgnCustPMWork.DisplayDivCode == 0)
                recBgnCust.DisplayDivCode = 1;        // 表示区分
            else
                recBgnCust.DisplayDivCode = 0;        // 表示区分
            recBgnCust.BrgnGoodsGrpCode = recBgnCustPMWork.BrgnGoodsGrpCode;    // お買得商品グループコード

            return recBgnCust;
        }

        /// <summary>
        /// RecBgnGds->RecBgnCustPMWork
        /// </summary>
        /// <param name="RecBgnCustPMWork">お買得商品得意先個別設定</param>
        /// <returns>お買得商品得意先個別設定ワーク</returns>
        /// <remarks>
        /// <br>Note       : recBgnCust->RecBgnCustPMWork</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private RecBgnCustPMWork CopyToRecBgnCustPMWorkFromRecBgnCust(RecBgnCust recBgnCust)
        {
            RecBgnCustPMWork recBgnCustPMWork = new RecBgnCustPMWork();

            recBgnCustPMWork.CreateDateTime = recBgnCust.CreateDateTime;        // 作成日時
            recBgnCustPMWork.UpdateDateTime = recBgnCust.UpdateDateTime;        // 更新日時
            recBgnCustPMWork.LogicalDeleteCode = recBgnCust.LogicalDeleteCode;  // 論理削除区分
            recBgnCustPMWork.InqOriginalEpCd = recBgnCust.InqOriginalEpCd;      // 問合せ元企業コード
            recBgnCustPMWork.InqOriginalSecCd = recBgnCust.InqOriginalSecCd;    // 問合せ元拠点コード
            recBgnCustPMWork.InqOtherEpCd = recBgnCust.InqOtherEpCd;            // 問合せ先企業コード
            recBgnCustPMWork.InqOtherSecCd = recBgnCust.InqOtherSecCd;          // 問合せ先拠点コード
            recBgnCustPMWork.GoodsNo = recBgnCust.GoodsNo;                      // 商品番号
            recBgnCustPMWork.GoodsMakerCd = recBgnCust.GoodsMakerCd;            // 商品メーカーコード
            recBgnCustPMWork.GoodsApplyStaDate = recBgnCust.GoodsApplyStaDate;  // 商品適用開始日
            recBgnCustPMWork.CustomerCode = recBgnCust.CustomerCode;            // 得意先コード
            recBgnCustPMWork.MngSectionCode = recBgnCust.MngSectionCode;        // 管理拠点コード
            recBgnCustPMWork.MkrSuggestRtPric = recBgnCust.MkrSuggestRtPric;    // ﾒｰｶｰ希望小売価格
            recBgnCustPMWork.ListPrice = recBgnCust.ListPrice;                  // 定価
            recBgnCustPMWork.UnitCalcRate = recBgnCust.UnitCalcRate;            // 単価算出掛率
            recBgnCustPMWork.UnitPrice = recBgnCust.UnitPrice;                  // 単価
            recBgnCustPMWork.ApplyStaDate = recBgnCust.ApplyStaDate;            // 適用開始日
            recBgnCustPMWork.ApplyEndDate = recBgnCust.ApplyEndDate;            // 適用終了日
            if (recBgnCust.DisplayDivCode == 0)
                recBgnCustPMWork.DisplayDivCode = 1;        // 表示区分
            else
                recBgnCustPMWork.DisplayDivCode = 0;        // 表示区分
            recBgnCustPMWork.BrgnGoodsGrpCode = recBgnCust.BrgnGoodsGrpCode;    // お買得商品グループコード

            return recBgnCustPMWork;
        }
        #endregion


        #endregion

        /// <summary>
        /// 拠点チェック処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="chkFlg">必須チェック区分(ture:有,false:無)</param>
        /// <remarks>
        /// <br>Note       : グリッドセルアプデト後発生イベント</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        public bool CheckSection(string sectionCode, bool chkFlg, out string errMsg, out SecInfoSet retSecInfoSet)
        {
            retSecInfoSet = null;

            bool bRet = true;
            errMsg = string.Empty;

            Int32 chkSectionCode = 0;
            Int32.TryParse(sectionCode, out chkSectionCode);
            if (chkSectionCode == 0)
            {
                if (chkFlg)
                {
                    bRet = false;
                    errMsg = "拠点コードを入力して下さい。";
                }
            }
            else
            {
                if (this._secInfoSetDic.ContainsKey(sectionCode.Trim().PadLeft(2, '0')))
                {
                    retSecInfoSet = this._secInfoSetDic[sectionCode.Trim().PadLeft(2, '0')];
                }
                if (retSecInfoSet == null)
                {
                    bRet = false;
                    errMsg = "拠点が存在しません。";
                }
            }
            return bRet;
        }

        /// <summary>
        /// 得意先チェック処理
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="chkFlg">必須チェック区分(ture:有,false:無)</param>
        /// <remarks>
        /// <br>Note       : グリッドセルアプデト後発生イベント</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        public bool CheckCustomer(int customerCode, bool chkFlg, out string errMsg)
        {
            bool bRet = true;
            errMsg = string.Empty;

            if (customerCode == 0)
            {
                if (chkFlg)
                {
                    bRet = false;
                    errMsg = "得意先コードを入力して下さい。";
                }
            }
            else
            {
                CustomerInfo customerInfo = null;
                if (this._customerDic.ContainsKey(customerCode))
                {
                    customerInfo = this._customerDic[customerCode];
                }
                if (customerInfo == null)
                {
                    bRet = false;
                    errMsg = "得意先が存在しません。";
                }
                else
                {
                    bRet = false;
                    errMsg = "連携している得意先ではありません。";

                    if (customerInfo.OnlineKindDiv == 0       //オンライン種別区分
                     || customerInfo.CustomerEpCode == null   //得意先企業コード
                     || customerInfo.CustomerSecCode == null) //得意先拠点コード
                    {
                        return bRet;
                    }
                    else
                    {
                        foreach (ScmEpScCnt scmEpScCnt in this._scmEpScCntList)
                        {
                            if ((scmEpScCnt.CnectOriginalEpCd == customerInfo.CustomerEpCode)
                             && (scmEpScCnt.CnectOriginalSecCd == customerInfo.CustomerSecCode))
                            {
                                bRet = true;
                                errMsg = string.Empty;
                                break;
                            }
                        }
                    }
                }
            }
            return bRet;
        }

        /// <summary>
        /// お買得商品グループチェック処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="chkFlg">必須チェック区分(ture:有,false:無)</param>
        /// <remarks>
        /// <br>Note       : グリッドセルアプデト後発生イベント</br>
        /// <br>Programmer : 宮本利明</br>
        /// <br>Date       : 2015/01/20</br>
        /// </remarks>
        public bool CheckRecBgnGrp(string inqOriginalEpCd, string inqOriginalSecCd, short brgnGoodsGrpCode, bool chkFlg, out string errMsg)
        {

            bool bRet = true;
            errMsg = string.Empty;

            if (brgnGoodsGrpCode == 0)
            {
                //if (chkFlg)
                //{
                //    bRet = false;
                //    errMsg = "お買得商品グループコードを入力して下さい。";
                //}
            }
            else
            {
                RecBgnGrpRet recBgnGrpRet = null;

                if (brgnGoodsGrpCode >= 9000 && brgnGoodsGrpCode <= 9999)
                {
                    // リストから検索
                    recBgnGrpRet = this._recBgnGrpWorkList.Find(
                                            delegate(RecBgnGrpRet mst)
                                            {
                                                return mst.BrgnGoodsGrpCode == brgnGoodsGrpCode ? true : false;
                                            });
                }
                else
                {
                    // リストから検索
                    recBgnGrpRet = this._recBgnGrpWorkList.Find(
                                            delegate(RecBgnGrpRet mst)
                                            {
                                                return mst.InqOriginalEpCd == inqOriginalEpCd && mst.InqOriginalSecCd == inqOriginalSecCd && mst.BrgnGoodsGrpCode == brgnGoodsGrpCode ? true : false;
                                            });
                }
                if (recBgnGrpRet == null)
                {
                    bRet = false;
                    errMsg = "お買得商品グループが存在しません。";
                }
            }
            return bRet;
        }
        
        /// <summary>
        /// 拠点名取得
        /// </summary>
        /// <param name="SectionCode">拠点コード</param>
        public string GetSectionName(string sectionCode)
        {
            string sName = string.Empty;
            SecInfoSet secInfoSet = null;
            if (this._secInfoSetDic.ContainsKey(sectionCode))
            {
                secInfoSet = this._secInfoSetDic[sectionCode];
            }
            if (secInfoSet != null)
            {
                sName = secInfoSet.SectionGuideNm;
            }
            return sName;
        }

        /// <summary>
        /// 得意先名取得
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        public string GetCustomerName(int customerCode)
        {
            string sName = string.Empty;
            CustomerInfo customerInfo = null;
            if (this._customerDic.ContainsKey(customerCode))
            {
                customerInfo = this._customerDic[customerCode];
            }
            if (customerInfo != null)
            {
                sName = customerInfo.CustomerSnm;
            }
            return sName;
        }

        /// <summary>
        /// お買得商品グループ名取得
        /// </summary>
        /// <param name="inqOriginalEpCd">問合せ元企業コード</param>
        /// <param name="inqOriginalSecCd">問合せ元拠点コード</param>
        /// <returns></returns>
        public string GetRecBgnGrpName(string inqOriginalEpCd, string inqOriginalSecCd, short brgnGoodsGrpCode)
        {
            string sName = string.Empty;
            RecBgnGrpRet recBgnGrpRet = null;

            if (brgnGoodsGrpCode >= 9000 && brgnGoodsGrpCode <= 9999)
            {
                // リストから検索
                recBgnGrpRet = this._recBgnGrpWorkList.Find(
                                        delegate(RecBgnGrpRet mst)
                                        {
                                            return mst.BrgnGoodsGrpCode == brgnGoodsGrpCode ? true : false;
                                        });
            }
            else
            {
                // リストから検索
                recBgnGrpRet = this._recBgnGrpWorkList.Find(
                                        delegate(RecBgnGrpRet mst)
                                        {
                                            return mst.InqOriginalEpCd == inqOriginalEpCd && mst.InqOriginalSecCd == inqOriginalSecCd && mst.BrgnGoodsGrpCode == brgnGoodsGrpCode ? true : false;
                                        });
            }
            if (recBgnGrpRet != null)
                sName = recBgnGrpRet.BrgnGoodsGrpTitle;

            return sName;
        }


        #region 部品／用品フラグ取得
        /// <summary>
        ///  部品／用品フラグ取得
        /// </summary>
        /// <param name="goodsUnitData">部品情報</param>
        /// <param name="retPartsFlag">部品／用品フラグ 1:提供部品 0:提供部品以外</param>
        /// <returns>ステータス</returns>
        // --- UPD 2015/03/26 Y.Wakita ---------->>>>>
        //public int GetPartsArticleInfo(GoodsUnitData goodsUnitData, out int retPartsFlag)
        public int GetPartsArticleInfo(GoodsUnitData goodsUnitData, bool uPricDiv, out int retPartsFlag)
        // --- UPD 2015/03/26 Y.Wakita ----------<<<<<
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            retPartsFlag = 0;

            // 部品情報が空の時は処理終了
            if (goodsUnitData == null) return status;

            switch (goodsUnitData.OfferKubun)
            {
                case 0: // ユーザー登録
                    retPartsFlag = 0;
                    status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                    break;
                case 1: // 提供純正編集
                case 2: // 提供優良編集
                case 3: // 提供純正
                case 4: // 提供優良
                    retPartsFlag = 1;
                    // --- ADD 2015/03/26 Y.Wakita ---------->>>>>
                    if (uPricDiv) retPartsFlag = 2;
                    // --- ADD 2015/03/26 Y.Wakita ----------<<<<<
                    status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                    break;
                default:
                    break;
            }

            return status;
        }
        #endregion

        //****************************************************************************//
        // 公開開始日、公開終了日一覧取得で間借り
        #region 開始日、終了日一覧取得
        /// <summary>
        /// 開始日、終了日データクラス
        /// </summary>
        public class StartEndDate
        {
            /// <summary>開始日</summary>
            private DateTime _startDate;

            /// <summary>終了日</summary>
            private DateTime _endDate;

            /// <summary>開始日プロパティ</summary>
            public DateTime StartDate
            {
                get { return _startDate; }
                set { _startDate = value; }
            }

            /// <summary>公開終了日プロパティ</summary>
            public DateTime EndDate
            {
                get { return _endDate; }
                set { _endDate = value; }
            }
        }

        /// <summary>
        ///  部品／用品フラグ取得
        /// </summary>
        /// <param name="openStartDate">公開開始日</param>
        /// <param name="openEndDate">公開終了日</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="partsInfo">部品情報</param>
        /// <param name="goodsUnitData">商品情報</param>
        /// <param name="startDate">開始日</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="retOpenStartEndDateList">公開開始日、公開終了日一覧</param>
        /// <returns>ステータス</returns>
        // --- UPD 2015/03/25 Y.Wakita ---------->>>>>
        //public int GetOpenStartEndDateList(
        //    DateTime openStartDate,
        //    DateTime openEndDate,
        //    int customerCode,
        //    string sectionCode,
        //    GoodsUnitData goodsUnitData,
        //    out List<StartEndDate> retOpenStartEndDateList)
        public int GetOpenStartEndDateList(
            DateTime openStartDate,
            DateTime openEndDate,
            int customerCode,
            string sectionCode,
            GoodsUnitData goodsUnitData,
            Dictionary<Calculator.GoodsInfoKey, List<GoodsPrice>> mkrSuggestRtPricList,
            Dictionary<Calculator.GoodsInfoKey, List<GoodsPrice>> mkrSuggestRtPricUList,
            out List<StartEndDate> retOpenStartEndDateList)
        // --- UPD 2015/03/25 Y.Wakita ----------<<<<<
        {

            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            try
            {
                retOpenStartEndDateList = new List<StartEndDate>();
                // 引数チェック
                if (goodsUnitData == null || customerCode == 0 || string.IsNullOrEmpty(sectionCode))
                {
                    return status;
                }

                // 日付のチェック
                if (openStartDate == DateTime.MinValue || openEndDate == DateTime.MinValue)
                {
                    return status;
                }

                // 商品マスタ価格範囲取得処理
                List<DateTime> goodsPriceRengeList = null;
                // --- UPD 2015/03/25 Y.Wakita ---------->>>>>
                //GetGoodsPriceRengeList(
                //    ref openStartDate, ref openEndDate, ref goodsUnitData, out goodsPriceRengeList);
                GetGoodsPriceRengeList(
                    ref openStartDate, ref openEndDate, ref goodsUnitData, ref mkrSuggestRtPricList, ref mkrSuggestRtPricUList, out goodsPriceRengeList);
                // --- UPD 2015/03/25 Y.Wakita ----------<<<<<

                // キャンペーン管理情報取得処理
                List<StartEndDate> campaignMngInfoList = null;
                status = GetCampaignMngInfoList(
                    ref openStartDate, ref openEndDate, ref customerCode, ref goodsUnitData, ref sectionCode, out campaignMngInfoList);
                //if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL) return status;

                // 価格変動開始日作成
                List<StartEndDate> costFluctuationList = null;
                CreateCostFluctuationList(ref openStartDate, ref openEndDate, ref campaignMngInfoList, out costFluctuationList);

                // 価格変動一覧結合
                retOpenStartEndDateList = null;
                MergeCostFluctuationList(ref openStartDate, ref openEndDate, ref goodsPriceRengeList, ref costFluctuationList, out retOpenStartEndDateList);
            }
            catch (Exception ex)
            {
                string msg = ex.ToString();
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

                retOpenStartEndDateList = new List<StartEndDate>();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        /// <summary>
        ///  商品マスタ価格範囲取得
        /// </summary>
        /// <param name="openStartDate">公開開始日</param>
        /// <param name="openEndDate">公開終了日</param>
        /// <param name="partsInfo">部品情報</param>
        /// <param name="goodsUnitData">商品情報</param>
        /// <param name="startDate">開始日</param>
        /// <param name="goodsPriceRengeList">公開開始日、公開終了日一覧</param>
        /// <returns>ステータス</returns>
        // --- UPD 2015/03/25 Y.Wakita ---------->>>>>
        //private void GetGoodsPriceRengeList(
        //    ref DateTime openStartDate,
        //    ref DateTime openEndDate,
        //    ref GoodsUnitData goodsUnitData,
        //    out List<DateTime> retGoodsPriceRengeList)
        private void GetGoodsPriceRengeList(
            ref DateTime openStartDate,
            ref DateTime openEndDate,
            ref GoodsUnitData goodsUnitData,
            ref Dictionary<Calculator.GoodsInfoKey, List<GoodsPrice>> mkrSuggestRtPricList,
            ref Dictionary<Calculator.GoodsInfoKey, List<GoodsPrice>> mkrSuggestRtPricUList,
            out List<DateTime> retGoodsPriceRengeList)
        // --- UPD 2015/03/25 Y.Wakita ----------<<<<<
        {
            retGoodsPriceRengeList = new List<DateTime>();
            int findResult = -1;

            if (goodsUnitData == null) return;

            DateTime tempDate;

            // 定価一覧取得
            if (goodsUnitData.GoodsPriceList != null)
            {
                foreach (GoodsPrice priceData in goodsUnitData.GoodsPriceList)
                {
                    tempDate = priceData.PriceStartDate;
                    if (tempDate < openStartDate)
                    {
                        // 公開開始日以前のデータは破棄する
                        continue;
                    }
                    else if (openEndDate < tempDate)
                    {
                        // 公開終了日以降のデータは破棄する
                        continue;
                    }

                    findResult = retGoodsPriceRengeList.IndexOf(tempDate);
                    // 開始日が未登録の場合のみ登録する
                    if (findResult == -1) retGoodsPriceRengeList.Add(tempDate);
                }
            }
            // --- DEL 2015/03/25 Y.Wakita ---------->>>>>
            #region 削除
            //// メーカー希望小売価格一覧取得
            //if (goodsUnitData.MkrSuggestRtPricList != null)
            //{
            //    foreach (GoodsPrice priceData in goodsUnitData.MkrSuggestRtPricList)
            //    {
            //        tempDate = priceData.PriceStartDate;
            //        if (tempDate < openStartDate)
            //        {
            //            // 公開開始日以前のデータは破棄する
            //            continue;
            //        }
            //        else if (openEndDate < tempDate)
            //        {
            //            // 公開終了日以降のデータは破棄する
            //            continue;
            //        }

            //        findResult = retGoodsPriceRengeList.IndexOf(tempDate);
            //        // 開始日が未登録の場合のみ登録する
            //        if (findResult == -1) retGoodsPriceRengeList.Add(tempDate);
            //    }
            //}
            #endregion
            // --- DEL 2015/03/25 Y.Wakita ----------<<<<<
            // --- ADD 2015/03/25 Y.Wakita ---------->>>>>
            // メーカー希望小売価格取得
            if (mkrSuggestRtPricList != null && mkrSuggestRtPricList.Count != 0)
            {
                Calculator.GoodsInfoKey goodsInfoKey = new Calculator.GoodsInfoKey(goodsUnitData.GoodsNo, goodsUnitData.GoodsMakerCd);
                if (mkrSuggestRtPricList.ContainsKey(goodsInfoKey))
                {
                    //// メーカー希望小売価格リストより基準日に該当する価格情報取得
                    List<GoodsPrice> _mkrSuggestRtPricList = mkrSuggestRtPricList[goodsInfoKey];
                    foreach (GoodsPrice priceData in _mkrSuggestRtPricList)
                    {
                        tempDate = priceData.PriceStartDate;
                        if (tempDate < openStartDate)
                        {
                            // 公開開始日以前のデータは破棄する
                            continue;
                        }
                        else if (openEndDate < tempDate)
                        {
                            // 公開終了日以降のデータは破棄する
                            continue;
                        }

                        findResult = retGoodsPriceRengeList.IndexOf(tempDate);
                        // 開始日が未登録の場合のみ登録する
                        if (findResult == -1) retGoodsPriceRengeList.Add(tempDate);
                    }
                }
            }
            // --- ADD 2015/03/25 Y.Wakita ----------<<<<<

            // 開始日でソート
            retGoodsPriceRengeList.Sort(delegate(DateTime x, DateTime y)
                {
                    return DateTime.Compare(x, y);
                }
            );
        }

        /// <summary>
        ///  キャンペーン管理情報取得
        /// </summary>
        /// <param name="openStartDate">公開開始日</param>
        /// <param name="openEndDate">公開終了日</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="partsInfo">部品情報</param>
        /// <param name="goodsUnitData">商品情報</param>
        /// <param name="startDate">開始日</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="retCampaignMngInfoList">キャンペーン価格開始日、価格終了日一覧</param>
        /// <returns>ステータス</returns>
        private int GetCampaignMngInfoList(
            ref DateTime openStartDate,
            ref DateTime openEndDate,
            ref int customerCode,
            ref GoodsUnitData goodsUnitData,
            ref string sectionCode,
            out List<StartEndDate> retCampaignMngInfoList)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            retCampaignMngInfoList = new List<StartEndDate>();

            List<CampaignObjGoodsSt> campaignMngList = null;
            CampaignObjGoodsStAcs campaignObjGoodsStAcs = CampaignObjGoodsStAcs.GetInstance();
            List<CampaignObjGoodsSt> campaignItemList = new List<CampaignObjGoodsSt>();

            status = campaignObjGoodsStAcs.Search(out campaignMngList, this._enterpriseCode, ConstantManagement.LogicalMode.GetData0);

            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL) return status;

            if (campaignMngList != null)
            {
                foreach (CampaignObjGoodsSt data in campaignMngList)
                {

                    // // キャンペーン種別による分岐
                    switch (data.CampaignSettingKind)
                    {
                        case 1: // 1:ﾒｰｶｰ+品番
                            if (data.GoodsMakerCd == goodsUnitData.GoodsMakerCd
                                && data.GoodsNo.Trim().Equals(goodsUnitData.GoodsNo.Trim()))
                            {
                                // 適用キャンペーン情報として保存
                                campaignItemList.Add(data);
                            }
                            break;
                        case 2: // 2:ﾒｰｶｰ+BL
                            if (data.GoodsMakerCd == goodsUnitData.GoodsMakerCd
                                 && (data.BLGoodsCode == goodsUnitData.BLGoodsCode))
                            {
                                // 適用キャンペーン情報として保存
                                campaignItemList.Add(data);
                            }
                            break;
                        case 3: // 3:ﾒｰｶｰ+ｸﾞﾙｰﾌﾟ
                            if (data.GoodsMakerCd == goodsUnitData.GoodsMakerCd
                                 && (data.BLGroupCode == goodsUnitData.BLGroupCode))
                            {
                                // 適用キャンペーン情報として保存
                                campaignItemList.Add(data);
                            }
                            break;
                        case 4: // 4:ﾒｰｶｰ
                            if (data.GoodsMakerCd == goodsUnitData.GoodsMakerCd)
                            {
                                // 適用キャンペーン情報として保存
                                campaignItemList.Add(data);
                            }
                            break;
                        case 5: // 5:BLｺｰﾄﾞ
                            if (data.BLGoodsCode == goodsUnitData.BLGoodsCode)
                            {
                                // 適用キャンペーン情報として保存
                                campaignItemList.Add(data);
                            }
                            break;
                        default: // その他は登録対象としない
                            break;
                    }
                }

                if (campaignItemList.Count == 0)
                {
                    // 対象キャンペーン情報がない場合、処理終了
                    return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                }

                // 売価優先設定取得
                CampaignPrcPrStAcs campaignPrcPrStAcs = new CampaignPrcPrStAcs();
                ArrayList campaignPrcPrStAcsList = null;
                CampaignPrcPrSt sectionPrcPrSt = null;
                CampaignPrcPrSt allSectionPrcPrSt = null;

                status = campaignPrcPrStAcs.SearchAll(out campaignPrcPrStAcsList, this._enterpriseCode);
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL) return status;

                foreach (CampaignPrcPrSt campaignPrcPrSt in campaignPrcPrStAcsList)
                {
                    if (campaignPrcPrSt.LogicalDeleteCode == 1) continue;

                    // 自拠点の売価優先設定取得
                    if (campaignPrcPrSt.SectionCode.Trim().Equals(sectionCode.Trim())) sectionPrcPrSt = campaignPrcPrSt;
                    // 全拠点の売価優先設定取得
                    if (campaignPrcPrSt.SectionCode.Trim().Equals(ALL_SECTION_CODE)) allSectionPrcPrSt = campaignPrcPrSt;
                }

                // 自拠点の売価優先設定取得がない場合、共通の設定を使用
                if (sectionPrcPrSt == null) sectionPrcPrSt = allSectionPrcPrSt;

                if (sectionPrcPrSt == null)
                {
                    // 共通の設定もない場合、デフォルトの設定を使用
                    // デフォルトの優先順位　1:ﾒｰｶｰ+品番,2:ﾒｰｶｰ+BL,3:ﾒｰｶｰ+ｸﾞﾙｰﾌﾟ,4:ﾒｰｶｰ,5:BLｺｰﾄ
                    sectionPrcPrSt = new CampaignPrcPrSt();
                    sectionPrcPrSt.PrioritySettingCd1 = 1;
                    sectionPrcPrSt.PrioritySettingCd2 = 2;
                    sectionPrcPrSt.PrioritySettingCd3 = 3;
                    sectionPrcPrSt.PrioritySettingCd4 = 4;
                    sectionPrcPrSt.PrioritySettingCd5 = 5;
                }

                // キャンペーン情報ソート
                campaignItemList.Sort(delegate(CampaignObjGoodsSt x, CampaignObjGoodsSt y)
                    {
                        int compareResult = x.CampaignSettingKind.CompareTo(y.CampaignSettingKind);
                        // キャンペーン設定種別比較
                        if (compareResult != 0)
                        {
                            if (sectionPrcPrSt.PrioritySettingCd1 == x.CampaignSettingKind) return -1;
                            if (sectionPrcPrSt.PrioritySettingCd1 == y.CampaignSettingKind) return 1;
                            if (sectionPrcPrSt.PrioritySettingCd2 == x.CampaignSettingKind) return -1;
                            if (sectionPrcPrSt.PrioritySettingCd2 == y.CampaignSettingKind) return 1;
                            if (sectionPrcPrSt.PrioritySettingCd3 == x.CampaignSettingKind) return -1;
                            if (sectionPrcPrSt.PrioritySettingCd3 == y.CampaignSettingKind) return 1;
                            if (sectionPrcPrSt.PrioritySettingCd4 == x.CampaignSettingKind) return -1;
                            if (sectionPrcPrSt.PrioritySettingCd4 == y.CampaignSettingKind) return 1;
                            if (sectionPrcPrSt.PrioritySettingCd5 == x.CampaignSettingKind) return -1;
                            if (sectionPrcPrSt.PrioritySettingCd5 == y.CampaignSettingKind) return 1;
                            if (sectionPrcPrSt.PrioritySettingCd6 == x.CampaignSettingKind) return -1;
                            if (sectionPrcPrSt.PrioritySettingCd6 == y.CampaignSettingKind) return 1;
                        }
                        else
                        {
                            // 拠点コード比較
                            compareResult = y.SectionCode.Trim().CompareTo(x.SectionCode.Trim());
                            if (compareResult != 0)
                            {
                                // 共通の場合優先度を下げる
                                if (x.SectionCode.Trim().Equals(ALL_SECTION_CODE)) return 1;
                            }
                            else
                            {
                                // 得意先比較
                                compareResult = y.CustomerCode.CompareTo(x.CustomerCode);
                                if (compareResult != 0)
                                {
                                    // 共通の場合優先度を下げる
                                    if (x.SectionCode.Trim().Equals("00000000")) return 1;
                                }
                                else
                                {
                                    // 価格開始日比較
                                    compareResult = x.PriceStartDate.CompareTo(y.PriceStartDate);
                                }
                            }
                        }
                        // 比較結果返却
                        return compareResult;
                    }
                );

                StartEndDate addData;
                DateTime dt;
                foreach (CampaignObjGoodsSt campaignObjGoodsSt in campaignItemList)
                {

                    if (campaignObjGoodsStAcs.CampaignStDic == null || campaignObjGoodsStAcs.CampaignStDic.Count == 0)
                    {
                        campaignObjGoodsStAcs.LoadCampaignSt();
                    }

                    bool searchFlg = true;
                    if (campaignObjGoodsStAcs.CampaignStDic.ContainsKey(campaignObjGoodsSt.CampaignCode))
                    {
                        Dictionary<int, CampaignSt> campaignStDic = campaignObjGoodsStAcs.CampaignStDic;
                        CampaignSt campaignSt = campaignStDic[campaignObjGoodsSt.CampaignCode];

                        // キャンペーン対象得意先設定を参照
                        if (campaignSt.CampaignObjDiv == 0)
                        {
                            // キャンペーン対象区分："全得意先" //なし。
                        }
                        else if (campaignSt.CampaignObjDiv == 1)
                        {
                            // キャンペーン対象区分："対象得意先"
                            ArrayList retList;
                            CampaignLinkAcs campaignLinkAcs = new CampaignLinkAcs();

                            status = campaignLinkAcs.SearchDetail(out retList, this._enterpriseCode, campaignSt.CampaignCode);

                            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL) return status;

                            foreach (CampaignLink campaignLink in retList)
                            {
                                if (campaignLink.LogicalDeleteCode != 0)
                                {
                                    continue;
                                }

                                if (campaignLink.CustomerCode != customerCode)
                                {
                                    // キャンペーン関連の得意先と一致しない
                                    searchFlg = false;
                                    break;
                                }
                            }
                        }
                    }
                    if (searchFlg)
                    {
                        addData = new StartEndDate();
                        if (DateTime.TryParseExact(campaignObjGoodsSt.PriceStartDate.ToString(), "yyyyMMdd", null, System.Globalization.DateTimeStyles.None, out dt))
                        {
                            addData.StartDate = dt;
                            if (DateTime.TryParseExact(campaignObjGoodsSt.PriceEndDate.ToString(), "yyyyMMdd", null, System.Globalization.DateTimeStyles.None, out dt))
                            {
                                addData.EndDate = dt;
                                retCampaignMngInfoList.Add(addData);
                            }
                        }
                    }
                }
            }

            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        }

        /// <summary>
        ///  キャンペーン価格範囲取得
        /// </summary>
        /// <param name="openStartDate">公開開始日</param>
        /// <param name="openEndDate">公開終了日</param>
        /// <param name="campaignMngInfoList">適用キャンペーン毎の開始終了日情報</param>
        /// <param name="campaignPriceFromToList">サマリした開始終了日情報</param>
        private void CreateCostFluctuationList(
            ref DateTime openStartDate,
            ref DateTime openEndDate,
            ref List<StartEndDate> campaignMngInfoList,
            out List<StartEndDate> campaignPriceFromToList)
        {
            campaignPriceFromToList = new List<StartEndDate>();

            StartEndDate checkData;

            // 適用キャンペーンがない場合は、初期値として入力した公開開始日・公開終了日を返却する。
            if (campaignMngInfoList.Count == 0)
            {
                checkData = new StartEndDate();
                checkData.StartDate = openStartDate;
                checkData.EndDate = openEndDate;
                campaignPriceFromToList.Add(checkData);
                return;
            }

            foreach (StartEndDate campaignMngInfo in campaignMngInfoList)
            {

                // キャンペーン価格開始日が、公開終了日より後の場合は除外
                if (campaignMngInfo.StartDate > openEndDate) continue;
                // キャンペーン価格終了日が、公開開始日より前の場合は除外
                if (campaignMngInfo.EndDate < openStartDate) continue;

                // キャンペーン価格開始日が公開開始日より前の場合は公開開始日をキャンペーン価格開始日に変更する
                if (campaignMngInfo.StartDate < openStartDate) campaignMngInfo.StartDate = openStartDate;
                // キャンペーン価格終了日が公開終了日より後の場合は公開終了日をキャンペーン価格終了日とする
                if (campaignMngInfo.EndDate > openEndDate) campaignMngInfo.EndDate = openEndDate;

                DateTime startDate = DateTime.MinValue;
                DateTime lastDate = DateTime.MinValue;

                bool isOK = false;

                DateTime i = campaignMngInfo.StartDate;
                while (i <= campaignMngInfo.EndDate)
                {
                    // 日毎にキャンペーン期間設定可能かを判定
                    isOK = CanAddCampaignTerm(campaignPriceFromToList, i);

                    if (isOK)
                    {
                        // 開始日を設定
                        if (startDate == DateTime.MinValue)
                        {
                            startDate = i;
                        }
                        // 設定可能な最終日を退避
                        lastDate = i;
                    }
                    else
                    {
                        // キャンペーン設定不可の場合は最終設定可能日を設定してキャンペーン期間を追加
                        if (startDate != DateTime.MinValue)
                        {
                            // 追加
                            StartEndDate andDate = new StartEndDate();
                            andDate.StartDate = startDate;
                            andDate.EndDate = lastDate;
                            campaignPriceFromToList.Add(andDate);

                            // 初期化
                            startDate = DateTime.MinValue;
                            lastDate = DateTime.MinValue;
                        }
                    }

                    // 翌日
                    i = i.AddDays(1);
                }

                if (isOK)
                {
                    // 最終データの追加
                    StartEndDate andDate = new StartEndDate();
                    andDate.StartDate = startDate;
                    andDate.EndDate = lastDate;
                    campaignPriceFromToList.Add(andDate);
                }
            }

            // 開始日でソート
            campaignPriceFromToList.Sort(delegate(StartEndDate x, StartEndDate y)
                {
                    return DateTime.Compare(x.StartDate, y.StartDate);
                }
            );
        }

        /// <summary>
        /// キャンペーン追加可能日かチェック
        /// </summary>
        /// <param name="campaignPriceFromToList">チェック対象リスト</param>
        /// <param name="checkDate">チェック対象日</param>
        /// <returns>true:可 false:不可</returns>
        private bool CanAddCampaignTerm(List<StartEndDate> campaignPriceFromToList, DateTime checkDate)
        {
            foreach (StartEndDate campaingPriceFromTo in campaignPriceFromToList)
            {
                if ((campaingPriceFromTo.StartDate <= checkDate) && (checkDate <= campaingPriceFromTo.EndDate)) return false;
            }
            return true;
        }

        /// <summary>
        ///  価格変動一覧結合
        /// </summary>
        /// <param name="openStartDate">公開開始日</param>
        /// <param name="openEndDate">公開終了日</param>
        /// <param name="goodsPriceRengeList">商品マスタ開始日リスト</param>
        /// <param name="campaignPriceFromToList">キャンペーン価格期間リスト</param>
        /// <param name="retOpenStartEndDateList">公開期間リスト</param>
        private void MergeCostFluctuationList(
            ref DateTime openStartDate,
            ref DateTime openEndDate,
            ref List<DateTime> goodsPriceRengeList,
            ref List<StartEndDate> campaignPriceFromToList,
            out List<StartEndDate> retOpenStartEndDateList)
        {
            // ●キャンペーン価格期間リストの調整
            if (campaignPriceFromToList.Count > 0)
            {
                DateTime campaignFirstDate = campaignPriceFromToList[0].StartDate;
                DateTime campaignEndDate = campaignPriceFromToList[campaignPriceFromToList.Count - 1].EndDate;

                // 公開開始日からキャンペーン価格開始日までの期間を追加する
                if (openStartDate < campaignFirstDate)
                {
                    // 公開開始日から先頭データの開始日-1日のデータを追加する
                    StartEndDate dummyDate = new StartEndDate();
                    dummyDate.StartDate = openStartDate;
                    dummyDate.EndDate = campaignFirstDate.AddDays(-1);
                    campaignPriceFromToList.Add(dummyDate);
                }

                // キャンペーン価格終了日から公開終了日までの期間を追加する
                if (openEndDate > campaignEndDate)
                {
                    // 公開開始日から先頭データの開始日-1日のデータを追加する
                    StartEndDate dummyDate = new StartEndDate();
                    dummyDate.StartDate = campaignEndDate.AddDays(1);
                    dummyDate.EndDate = openEndDate;
                    campaignPriceFromToList.Add(dummyDate);
                }

                // キャンペーン価格期間リストを開始日でソート
                campaignPriceFromToList.Sort(delegate(StartEndDate x, StartEndDate y) { return DateTime.Compare(x.StartDate, y.StartDate); });
            }
            else
            {
                // キャンペーン価格期間リストがない場合はダミー期間を作成
                // 公開開始日から先頭データの開始日-1日のデータを追加する
                StartEndDate dummyDate = new StartEndDate();
                dummyDate.StartDate = openStartDate;
                dummyDate.EndDate = openEndDate;
                campaignPriceFromToList.Add(dummyDate);
            }

            // ●空白期間に開始終了を設定
            List<StartEndDate> retTempList = new List<StartEndDate>();
            DateTime oldStartdate = DateTime.MinValue;
            DateTime oldEnddate = DateTime.MinValue;
            foreach (StartEndDate retStartEndDate in campaignPriceFromToList)
            {
                // 1件目は読み飛ばす
                if (oldStartdate != DateTime.MinValue)
                {
                    if (oldEnddate.AddDays(1) != retStartEndDate.StartDate)
                    {
                        // 追加
                        StartEndDate addStartEndDate = new StartEndDate();
                        addStartEndDate.StartDate = oldEnddate.AddDays(1);
                        addStartEndDate.EndDate = retStartEndDate.StartDate.AddDays(-1);
                        retTempList.Add(addStartEndDate);
                    }
                }
                retTempList.Add(retStartEndDate);
                // 期間を保管
                oldStartdate = retStartEndDate.StartDate;
                oldEnddate = retStartEndDate.EndDate;
            }

            // サマリ期間リストを開始日でソート
            retTempList.Sort(delegate(StartEndDate x, StartEndDate y) { return DateTime.Compare(x.StartDate, y.StartDate); });

            // ●キャンペーンと商品の期間をサマリする
            retOpenStartEndDateList = new List<StartEndDate>();
            foreach (StartEndDate campaignPriceFromTo in retTempList)
            {
                bool addFlg = false;
                DateTime nowStartDate = campaignPriceFromTo.StartDate;
                foreach (DateTime goodsStartDate in goodsPriceRengeList)
                {
                    DateTime firstStartDate = DateTime.MinValue;
                    DateTime firstEndDate = DateTime.MinValue;
                    DateTime secondStartDate = DateTime.MinValue;
                    DateTime secondEndDate = DateTime.MinValue;

                    // キャンペーン開始翌日以降に商品価格開始の場合
                    if (nowStartDate < goodsStartDate)
                    {
                        // キャンペーン価格終了当日
                        if (goodsStartDate == campaignPriceFromTo.EndDate)
                        {
                            firstStartDate = nowStartDate;
                            firstEndDate = goodsStartDate.AddDays(-1);
                            secondStartDate = goodsStartDate;
                            secondEndDate = campaignPriceFromTo.EndDate;
                            addFlg = true;
                        }
                        // キャンペーン価格終了前日以前
                        else if (goodsStartDate < campaignPriceFromTo.EndDate)
                        {
                            firstStartDate = nowStartDate;
                            firstEndDate = goodsStartDate.AddDays(-1);
                            secondStartDate = goodsStartDate;
                            secondEndDate = campaignPriceFromTo.EndDate;
                            addFlg = true;
                        }
                    }

                    // 分割期間を作成
                    if (addFlg)
                    {
                        // リスト最後尾（開始日が一番遅い）期間を削除
                        if (retOpenStartEndDateList.Count > 0) retOpenStartEndDateList.Remove(retOpenStartEndDateList[retTempList.Count - 1]);

                        // 分割データを作成(前半)
                        StartEndDate firstDate = new StartEndDate();
                        firstDate.StartDate = firstStartDate;
                        firstDate.EndDate = firstEndDate;
                        retOpenStartEndDateList.Add(firstDate);

                        // 後部
                        StartEndDate secondDate = new StartEndDate();
                        secondDate.StartDate = secondStartDate;
                        secondDate.EndDate = secondEndDate;
                        retOpenStartEndDateList.Add(secondDate);

                        // 前半の終了翌日（次回開始日）を退避
                        nowStartDate = firstEndDate.AddDays(1);
                    }
                }
                // 分割無の場合はキャンペーン期間を設定
                if (addFlg != true) retOpenStartEndDateList.Add(campaignPriceFromTo);
            }

            // 開始日でソート
            retOpenStartEndDateList.Sort(delegate(StartEndDate x, StartEndDate y) { return DateTime.Compare(x.StartDate, y.StartDate); });
        }

        #endregion

    }

    /// <summary>
    /// お買得商品設定データ比較クラス(拠点(昇順)、メーカー(昇順)、品番(昇順)、公開開始日(昇順))
    /// </summary>
    public class RecBgnGdsAsComparer : Comparer<RecBgnGdsPMWork>
    {
        /// <summary>
        /// 比較処理
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public override int Compare(RecBgnGdsPMWork x, RecBgnGdsPMWork y)
        {
            int result = 0;

            // 拠点
            result = x.InqOtherSecCd.CompareTo(y.InqOtherSecCd);
            if (result != 0) return result;

            // メーカー
            result = x.GoodsMakerCd.CompareTo(y.GoodsMakerCd);
            if (result != 0) return result;

            // 品番
            result = x.GoodsNo.CompareTo(y.GoodsNo);
            if (result != 0) return result;

            // 公開開始日
            result = x.ApplyStaDate.CompareTo(y.ApplyStaDate);

            return result;
        }
    }

    /// <summary>
    /// 得意先別設定情報用クラス
    /// </summary>
    public class RecBgnGdsCustInfo
    {
        public RecBgnGdsDataSet.RecBgnGdsRow recBgnGdsRow;
        public RecBgnGdsDataSet.RecBgnCustDataTable recBgnCust;
    }


}
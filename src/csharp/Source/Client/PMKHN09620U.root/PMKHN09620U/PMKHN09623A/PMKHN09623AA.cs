//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : キャンペーン対象商品設定マスタ
// プログラム概要   : キャンペーン対象商品設定マスタを行う
//----------------------------------------------------------------------------//
//                (c)Copyright 2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10701342-00 作成担当 : 曹文傑
// 作 成 日  2011/04/26  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  10700008-00 作成担当 : 譚洪
// 修 正 日  2011/07/07  修正内容 : Redmine#22810 明細”メーカー名称”から”カナ名称”に変更の対応
//----------------------------------------------------------------------------//
// 管理番号  10700008-00 作成担当 : 曹文傑
// 修 正 日  2011/07/14  修正内容 : Redmine#22984 最終行の情報がデータ登録されない
//----------------------------------------------------------------------------//
// 管理番号  10700008-00 作成担当 : 曹文傑
// 修 正 日  2011/07/14  修正内容 : Redmine#23004 キャンペーン対象商品設定マスタの日付範囲チェックエラー対応
//----------------------------------------------------------------------------//
// 管理番号  10700008-00 作成担当 : 譚洪
// 修 正 日  2011/07/22  修正内容 : Redmine#23119 ①優良設定マスタを設定後に最新情報取得を実行しても、再取得されない事が問題ありますの対応
//                                                ②検索時の表示時間が他のＰＧと比較して遅いの対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 許雁波
// 修 正 日  2011/08/12  修正内容 : Redmine#23556 初期化ロードは並べて処理して、時間が減少するように修正する
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 西 毅
// 修 正 日  2012/04/12  修正内容 : 売価優先設定の取得方法変更（速度改良）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 吉岡　孝憲
// 修 正 日  2013/01/18  修正内容 : 2013/03/13配信　SCM障害№10475対応 速度改善
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 吉岡　孝憲
// 修 正 日  2013/02/13  修正内容 : 2013/03/06配信　SCM障害№10478対応 
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 陳健
// 修 正 日  2014/03/20  修正内容 : Redmine#42174 更新日Column追加の対応
//----------------------------------------------------------------------------//
// 管理番号  11070076-00 作成担当 : 30744 湯上 千加子
// 修 正 日  2014/05/08  修正内容 : PM-SCM速度改良 フェーズ２対応
//                                : 01.商品検索アクセスクラス補正処理プロパティ対応
//                                : 02.得意先掛率グループマスタ取得改良対応（回答判定時）
//                                : 03.変更前単価計算呼出回数改良対応
//                                : 04.キャンペーン売価設定マスタ取得改良対応
//                                : 05.得意先マスタ（伝票管理）取得改良対応
//                                : 06.得意先マスタ取得改良対応（金額計算クラス）
//                                : 07.得意先マスタ取得改良対応（金額計算クラス・キャンペーン対応）
//                                : 08.売上データ生成時のシステム日付取得対応
//                                : 09.得意先掛率グループマスタ取得改良対応（売上データ生成時）
//                                : 10.単価計算呼出回数改良
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 脇田 靖之
// 修 正 日  2015/02/12  修正内容 : システムテスト障害対応 RedMine#145
//                                  売価優先設定の適用がおかしい追加対応
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using System.Diagnostics;
using System.Threading;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// キャンペーン対象商品設定マスタ アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : キャンペーン対象商品設定マスタ アクセスクラス</br>
    /// <br>Programmer : 曹文傑</br>
    /// <br>Date       : 2011/04/26</br>
    /// <br>UpdateNote : 2011/07/07 譚洪 Redmine#22810 明細”メーカー名称”から”カナ名称”に変更の対応</br>
    /// <br>UpdateNote : 2011/07/14 曹文傑 Redmine#22984 最終行の情報がデータ登録されない</br>
    /// <br>UpdateNote : 2011/07/15 曹文傑 Redmine#23004 キャンペーン対象商品設定マスタの日付範囲チェックエラー対応</br>
    /// <br>UpdateNote : 2011/07/22 譚洪 Redmine#23119 ①優良設定マスタを設定後に最新情報取得を実行しても、再取得されない事が問題ありますの対応</br>
    /// <br>　　　　　　　　　　　　　　　　　　　　　　②検索時の表示時間が他のＰＧと比較して遅いの対応</br>
    /// </remarks>
    public class CampaignObjGoodsStAcs
    {
        #region Private Member
        private static CampaignObjGoodsStAcs _campaignObjGoodsStAcs = null;

        private CampaignMngDataSet _dataSet;
        private CampaignMngDataSet.CampaignMngDataTable _campaignMngDataTable;
        private Dictionary<Guid, CampaignObjGoodsSt> _prevCampaignMngDic = new Dictionary<Guid, CampaignObjGoodsSt>();
        private ICampaignObjGoodsStDB _iCampaignObjGoodsStDB = null;

        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        private string _loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

        /// <summary>処理結果状況</summary>
        private string _statusOfResult = string.Empty;
        /// <summary>キャンペーン売価率、売価額取得処理で使用されたキャンペーン関連設定データ</summary>
        private ArrayList _usedCampaignLinkList = null;
        //2012/04/12 T.Nishi ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        private ArrayList _campaignPrcPrStList = null;
        //2012/04/12 T.Nishi ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        private MakerAcs _makerAcs = null;					// メーカーアクセスクラス
        private SecInfoAcs _secInfoAcs = null;                     // 拠点情報アクセスクラス

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

        private CampaignStAcs _campaignStAcs = null;
        private CampaignLinkAcs _campaignLinkAcs = null;
        private CampaignPrcPrStAcs _campaignPrcPrStAcs = null;

        private IWin32Window _owner = null;

        private Dictionary<int, MakerUMnt> _makerUMntDic = new Dictionary<int, MakerUMnt>();    // メーカーマスタディクショナリー
        private Dictionary<string, SecInfoSet> _secInfoSetDic = new Dictionary<string, SecInfoSet>();// 拠点情報ディクショナリー

        private Dictionary<int, BLGoodsCdUMnt> _blGoodsCdDic = new Dictionary<int, BLGoodsCdUMnt>();    // BLコードマスタディクショナリー
        private Dictionary<int, BLGroupU> _blGroupDic = new Dictionary<int, BLGroupU>();    // BLグループマスタディクショナリー
        private Dictionary<int, UserGdBd> _userGdBdDic = new Dictionary<int, UserGdBd>();    // ユーザーガイドディクショナリー
        private Dictionary<int, CustomerInfo> _customerDic = new Dictionary<int, CustomerInfo>();    // 得意先ディクショナリー

        private Dictionary<int, CampaignSt> _campaignStDic = new Dictionary<int, CampaignSt>();
        private List<CampaignLink> _campaignLinkList = new List<CampaignLink>();
        private List<CampaignObjGoodsSt> _campaignMngList = new List<CampaignObjGoodsSt>();

        // キャンペーン対象商品設定データリスト
        private List<CampaignObjGoodsSt> _campaignObjGoodsStList = null;

        //true:削除指定区分=1、false:削除指定区分=0
        private bool _deleteSearchMode = false;

        /// <summary>// true:ローカル参照 false:サーバー参照</summary>
        public static readonly bool ctIsLocalDBRead = false;

        private CampaignObjGoodsSt _newCampaignObj = new CampaignObjGoodsSt(); // 新規行の場合用 // ADD 2011/07/14

        private Thread _masterAcsThread;   // マスタデータ取得スレッド  // ADD Redmine#23556 2011/08/12
        private Thread _goodsAcsThread;   // 商品データ取得スレッド     // ADD Redmine#23556 2011/08/12

        // ADD 2013/01/18 T.Yoshioka 2013/03/13配信予定 SCM障害№10475 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        CampaignPrcPrSt campaignPrcPrSt = null;
        bool first = true;
        // ADD 2013/01/18 T.Yoshioka 2013/03/13配信予定 SCM障害№10475 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        #endregion

        #region プロパティ
        // ------------- ADD Redmine#23556 2011/08/12 --------------->>>>>
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
        // ------------- ADD Redmine#23556 2011/08/12 ---------------<<<<<
        /// <summary>
        /// グリッドテーブルプロパティ
        /// </summary>
        public CampaignMngDataSet.CampaignMngDataTable CampaignMngDataTable
        {
            get { return this._campaignMngDataTable; }
        }

        /// <summary>
        /// キャンペーン対象商品設定ディクショナリープロパティ
        /// </summary>
        public Dictionary<Guid, CampaignObjGoodsSt> PrevCampaignMngDic
        {
            get { return this._prevCampaignMngDic; }
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
        /// キャンペーン設定ディクショナリープロパティ
        /// </summary>
        public Dictionary<int, CampaignSt> CampaignStDic
        {
            get { return this._campaignStDic; }
        }

        /// <summary>
        /// キャンペーン関連ディクショナリープロパティ
        /// </summary>
        public List<CampaignLink> CampaignLinkList
        {
            get { return this._campaignLinkList; }
        }

        /// <summary>
        /// キャンペーン対象商品設定ディクショナリープロパティ
        /// </summary>
        public List<CampaignObjGoodsSt> CampaignMngList
        {
            get { return this._campaignMngList; }
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
        /// (GetRatePriceOfCampaignMng()を呼出し時に変化します)
        /// </summary>
        public string StatusOfResult
        {
            get { return _statusOfResult; }
        }

        /// <summary>
        /// キャンペーン売価率、売価額取得処理で使用されたキャンペーン関連設定データを取得します。<br/>
        /// （キャンペーン設定.CampaignObjDiv == 1 でリモートアクセスします）
        /// </summary>
        public ArrayList UsedCampaignLinkList
        {
            get { return _usedCampaignLinkList; }
        }

        // ---ADD 2011/07/14--------------->>>>>
        /// <summary>
        /// キャンペーン対象商品設定プロパティ、新規行の場合用
        /// </summary>
        public CampaignObjGoodsSt NewCampaignObj
        {
            get { return _newCampaignObj; }
            set { _newCampaignObj = value; }
        }
        // ---ADD 2011/07/14---------------<<<<<
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
        /// <br>Note       : キャンペーン対象商品設定マスタ アクセスクラス</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
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
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        public CampaignObjGoodsStAcs()
        {
            this._dataSet = new CampaignMngDataSet();
            this._campaignMngDataTable = this._dataSet.CampaignMng;
            this._makerAcs = new MakerAcs();
            this._secInfoAcs = new SecInfoAcs();
            this._blGoodsCdAcs = new BLGoodsCdAcs();
            this._blGroupUAcs = new BLGroupUAcs();
            this._userGuideAcs = new UserGuideAcs();
            this._campaignStAcs = new CampaignStAcs();
            this._customerInfoAcs = new CustomerInfoAcs();
            this._campaignLinkAcs = new CampaignLinkAcs();
            this._iCampaignObjGoodsStDB = (ICampaignObjGoodsStDB)MediationCampaignObjGoodsStDB.GetCampaignObjGoodsStDB();

            // ---------- DEL Redmine#23556 2011/08/12 ------------------->>>>>
            //#region ●商品アクセスクラス初期処理(キャッシュなし)
            //string retMessage;
            //this._goodsAcs = new GoodsAcs();
            //this._goodsAcs.IsLocalDBRead = false;
            //this._goodsAcs.Owner = this._owner;
            //this._goodsAcs.IsGetSupplier = true;
            //this._goodsAcs.SearchInitial(this._enterpriseCode, this._loginSectionCode, out retMessage);
            //#endregion
            // ---------- DEL Redmine#23556 2011/08/12 -------------------<<<<<
        }
        #endregion

        #region Public Method
        /// <summary>
        /// キャンペーン対象商品設定アクセスクラス インスタンス取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : キャンペーン対象商品設定アクセスクラス インスタンス取得処理</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
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
        /// <param name="searchCondition">検索条件クラス</param>
        /// <param name="count">count</param>
        /// <param name="msg">エラーメッセージ</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 検索処理を行います。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        public int Search(SearchCondition searchCondition, out int count, out string msg)
        {
            int status = 0;
            count = 0;
            msg = string.Empty;
            ArrayList campaignMngList = null;
            SearchConditionWork searchConditionWork  = this.CopyToSearchConditionWorkFromSearchCondition(searchCondition);

            try
            {
                if (searchCondition.DeleteFlag == 0)
                {
                    status = this.SearchPrc(out campaignMngList, searchConditionWork, ConstantManagement.LogicalMode.GetData0, out count, ref msg);
                }
                else
                {
                    status = this.SearchPrc(out campaignMngList, searchConditionWork, ConstantManagement.LogicalMode.GetData1, out count, ref msg);
                }
            }
            catch (Exception ex)
            {
                msg = ex.ToString();
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }


            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (searchCondition.DeleteFlag == 0)
                {
                    this._deleteSearchMode = false;
                }
                else
                {
                    this._deleteSearchMode = true;
                }

                if (campaignMngList != null && campaignMngList.Count > 0)
                {
                    this.SettingDetailRowAfterSearch(campaignMngList);
                }
            }
            return status;
        }

        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="retArray">ｷｬﾝﾍﾟｰﾝ対象商品設定ﾏｽﾀデータ</param>
        /// <param name="searchConditionWork">検索条件クラス</param>
        /// <param name="logicalMode">論理削除モード</param>
        /// <param name="count">count</param>
        /// <param name="msg">エラーメッセージ</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 検索処理を行います。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        public int SearchPrc(out ArrayList retArray, SearchConditionWork searchConditionWork, ConstantManagement.LogicalMode logicalMode, out int count, ref string msg)
        {
            int status = 0;
            count = 0;
            try
            {
                ArrayList campaignMngList = null;
                object retObj = campaignMngList as object;

                object paraObj = searchConditionWork as object;
                status = this._iCampaignObjGoodsStDB.Search(out retObj, paraObj, 0, logicalMode, out count, ref msg);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    retArray = retObj as ArrayList;
                }
                else
                {
                    retArray = null;
                }
            }
            catch (Exception ex)
            {
                retArray = null;
                msg = ex.ToString();
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        /// <summary>
        /// 検索処理
        /// </summary>
        /// <param name="retArray">ｷｬﾝﾍﾟｰﾝ対象商品設定ﾏｽﾀデータ</param>
        /// <param name="campaignObjGoodsSt">検索条件クラス</param>
        /// <param name="msg">エラーメッセージ</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : 検索処理を行います。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        public int Read(out ArrayList retArray, CampaignObjGoodsSt campaignObjGoodsSt, ref string msg)
        {
            int status = 0;
            try
            {
                ArrayList campaignMngList = null;
                object retObj = campaignMngList as object;

                CampaignObjGoodsStWork campaignObjGoodsStWork  = this.CopyToCampaignMngWorkFromCampaignMng(campaignObjGoodsSt);
                object paraObj = campaignObjGoodsStWork as object;

                status = this._iCampaignObjGoodsStDB.Read(out retObj, paraObj, ref msg);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    retArray = retObj as ArrayList;
                }
                else
                {
                    retArray = null;
                }
            }
            catch (Exception ex)
            {
                retArray = null;
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
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// <br>UpdateNote : 2011/07/14 曹文傑 Redmine#22984 最終行の情報がデータ登録されない</br>
        /// </remarks>
        public void DetailRowInitialSetting(int defaultRowCount)
        {
            this.CampaignMngDataTable.BeginLoadData();
            this.CampaignMngDataTable.Clear();
            this._deleteSearchMode = false;

            for (int i = 1; i <= defaultRowCount; i++)
            {
                CampaignMngDataSet.CampaignMngRow row = this.CampaignMngDataTable.NewCampaignMngRow();
                row.RowNo = i;
                row.FilterGuid = Guid.Empty;
                row.GoodsName = "";
                row.UpdateTime = DateTime.MinValue.ToString("yy/MM/dd");

                this.CampaignMngDataTable.AddCampaignMngRow(row);
            }
            this.CopyToCampaignMngFromDetailRow((CampaignMngDataSet.CampaignMngRow)this._campaignMngDataTable.Rows[this._campaignMngDataTable.Count - 1], ref this._newCampaignObj); // ADD 2011/07/14
            this.CampaignMngDataTable.EndLoadData();
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
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        public int SaveProc(List<CampaignObjGoodsSt> deleteList, List<CampaignObjGoodsSt> updateList, out CampaignObjGoodsSt campaignObjGoodsSt)
        {
            int status = 0;
            campaignObjGoodsSt = null;
            ArrayList delList = new ArrayList();
            ArrayList UpdList = new ArrayList();
            CampaignObjGoodsStWork campaignObjGoodsStWork = null;
            foreach (CampaignObjGoodsSt campaignMng in deleteList)
            {
                campaignObjGoodsStWork = this.CopyToCampaignMngWorkFromCampaignMng(campaignMng);
                delList.Add(campaignObjGoodsStWork);
            }
            foreach (CampaignObjGoodsSt campaignMng in updateList)
            {
                campaignObjGoodsStWork = this.CopyToCampaignMngWorkFromCampaignMng(campaignMng);
                UpdList.Add(campaignObjGoodsStWork);
            }

            object paraDelObj = delList as object;
            object paraUpdObj = UpdList as object;
            if (this._deleteSearchMode == false)
            {
                object errorObj = null;
                status = this._iCampaignObjGoodsStDB.DeleteAndWrite(paraDelObj, ref paraUpdObj, out errorObj);
                if (errorObj != null)
                {
                    CampaignObjGoodsStWork errorWork = errorObj as CampaignObjGoodsStWork;
                    campaignObjGoodsSt = this.CopyToCampaignMngFromCampaignMngWork(errorWork);
                }
            }
            else
            {
                status = this._iCampaignObjGoodsStDB.DeleteAndRevival(paraDelObj, ref paraUpdObj);
            }

            return status;
        }
        #endregion

        #region Private Method
        /// <summary>
        /// 検索処理後、明細行追加処理
        /// </summary>
        /// <param name="retList">0:登録・更新、1:完全削除と復活</param>
        /// <remarks>
        /// <br>Note       : 検索処理後、明細行追加処理を行います。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void SettingDetailRowAfterSearch(ArrayList retList)
        {
            this.CampaignMngDataTable.BeginLoadData();
            this._campaignMngDataTable.Clear();
            CampaignObjGoodsSt campaignObjGoodsSt = null;

            // 登録済行の追加
            for (int i = 1; i <= retList.Count; i++)
            {
                campaignObjGoodsSt = this.CopyToCampaignMngFromCampaignMngWork((CampaignObjGoodsStWork)retList[i - 1]);
                CampaignMngDataSet.CampaignMngRow row = this._campaignMngDataTable.NewCampaignMngRow();
                row.RowNo = i;
                this.CopyToDetailRowFromCampaignMng(ref row, campaignObjGoodsSt);

                this._campaignMngDataTable.AddCampaignMngRow(row);
                this._prevCampaignMngDic.Add(row.FilterGuid, campaignObjGoodsSt);
            }

            if (this._deleteSearchMode == false)
            {
                // 新規行の追加
                CampaignMngDataSet.CampaignMngRow newRow = this._campaignMngDataTable.NewCampaignMngRow();
                newRow.RowNo = retList.Count + 1;
                newRow.FilterGuid = Guid.Empty;
                newRow.GoodsName = "";
                newRow.UpdateTime = DateTime.MinValue.ToString("yy/MM/dd");
                this._campaignMngDataTable.AddCampaignMngRow(newRow);
            }

            this.CampaignMngDataTable.EndLoadData();
        }

        /// <summary>
        /// 明細行ー＞キャンペーン対象商品設定マスタ
        /// </summary>
        /// <param name="row">明細行</param>
        /// <param name="campaignMng">キャンペーン対象商品設定マスタ</param>
        /// <remarks>
        /// <br>Note       : 明細行ー＞キャンペーン対象商品設定マスタ</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// <br>UpdateNote  : 2011/07/07 譚洪 Redmine#22810 明細”メーカー名称”から”カナ名称”に変更の対応</br>
        /// <br>UpdateNote  : 2011/07/22 譚洪 Redmine#23119 検索時の表示時間が他のＰＧと比較して遅いの対応</br>
        /// </remarks>
        private void CopyToDetailRowFromCampaignMng(ref CampaignMngDataSet.CampaignMngRow row, CampaignObjGoodsSt campaignMng)
        {
            row.UpdateTime = campaignMng.UpdateDateTime.Date.ToString("yy/MM/dd"); //削除日
            // ADD 陳健 2014/03/20 ---------------------------------------->>>>>
            row.UpdateTime2 = campaignMng.UpdateDateTime.Date.ToString("yyyy/MM/dd");
            // ADD 陳健 2014/03/20 ----------------------------------------<<<<<
            row.FilterGuid = Guid.NewGuid();
            row.SectionCode = campaignMng.SectionCode.Trim().PadLeft(2, '0'); //拠点

            row.SalesPriceSetDiv = campaignMng.SalesPriceSetDiv; // 売価区分
            if (campaignMng.SalesPriceSetDiv == 1)
            {
                row.CustomerCode = campaignMng.CustomerCode.ToString().PadLeft(8, '0'); //得意先
                row.DiscountRate = campaignMng.DiscountRate; //値引率
                row.PriceFl = campaignMng.PriceFl; //売価額
                row.RateVal = campaignMng.RateVal; //売価率
                row.PriceStartDate = campaignMng.PriceStartDate; //価格開始日
                row.PriceEndDate = campaignMng.PriceEndDate; //価格終了日
            }
            else
            {
                row.CustomerCode = string.Empty;
                row.DiscountRate = 0;
                row.PriceFl = 0;
                row.RateVal = 0;
                row.PriceStartDate = 0;
                row.PriceEndDate = 0;
            }

            row.CampaignSettingKind = campaignMng.CampaignSettingKind; //設定種別
            if (campaignMng.CampaignSettingKind == 6)
            {
                // 販売区分
                row.SalesCode = campaignMng.SalesCode.ToString().PadLeft(4, '0');

                row.GoodsMakerCode = 0;
                row.GoodsMakerName = string.Empty;
                row.GoodsNo = string.Empty;
                row.BLGoodsCode = 0;
                row.GoodsName = string.Empty;
                row.BLGroupCode = 0;
            }

            if (campaignMng.CampaignSettingKind == 5)
            {
                // BLｺｰﾄﾞ
                row.BLGoodsCode = campaignMng.BLGoodsCode;
                // 品名
                BLGoodsCdUMnt bLGoodsCdUMnt = null;
                if (this.BLGoodsCdDic.ContainsKey(campaignMng.BLGoodsCode))
                {
                    bLGoodsCdUMnt = this.BLGoodsCdDic[campaignMng.BLGoodsCode];
                }
                if (bLGoodsCdUMnt != null)
                {
                    row.GoodsName = bLGoodsCdUMnt.BLGoodsHalfName;
                }
                else
                {
                    row.GoodsName = string.Empty;
                }


                row.SalesCode = string.Empty;
                row.GoodsMakerCode = 0;
                row.GoodsMakerName = string.Empty;
                row.GoodsNo = string.Empty;
                row.BLGroupCode = 0;
            }

            if (campaignMng.CampaignSettingKind == 4)
            {
                // ﾒｰｶｰ
                row.GoodsMakerCode = campaignMng.GoodsMakerCd;
                // ﾒｰｶｰ名
                if (this.MakerUMntDic.ContainsKey(campaignMng.GoodsMakerCd))
                {
                    MakerUMnt makerUMnt = this.MakerUMntDic[campaignMng.GoodsMakerCd];
                    //row.GoodsMakerName = makerUMnt.MakerName;  // DEL 2011/07/07 
                    row.GoodsMakerName = makerUMnt.MakerKanaName;  // ADD 2011/07/07 
                }
                else
                {
                    row.GoodsMakerName = string.Empty;
                }


                row.SalesCode = string.Empty;
                row.GoodsNo = string.Empty;
                row.BLGoodsCode = 0;
                row.GoodsName = string.Empty;
                row.BLGroupCode = 0;
            }

            if (campaignMng.CampaignSettingKind == 3)
            {
                // ﾒｰｶｰ
                row.GoodsMakerCode = campaignMng.GoodsMakerCd;
                // ﾒｰｶｰ名
                if (this.MakerUMntDic.ContainsKey(campaignMng.GoodsMakerCd))
                {
                    MakerUMnt makerUMnt = this.MakerUMntDic[campaignMng.GoodsMakerCd];
                    //row.GoodsMakerName = makerUMnt.MakerName; // DEL 2011/07/07 
                    row.GoodsMakerName = makerUMnt.MakerKanaName; // ADD 2011/07/07 
                }
                else
                {
                    row.GoodsMakerName = string.Empty;
                }
                // ｸﾞﾙｰﾌﾟ
                row.BLGroupCode = campaignMng.BLGroupCode;


                row.SalesCode = string.Empty;
                row.GoodsNo = string.Empty;
                row.BLGoodsCode = 0;
                row.GoodsName = string.Empty;
            }

            if (campaignMng.CampaignSettingKind == 2)
            {
                // ﾒｰｶｰ
                row.GoodsMakerCode = campaignMng.GoodsMakerCd;
                // ﾒｰｶｰ名
                if (this.MakerUMntDic.ContainsKey(campaignMng.GoodsMakerCd))
                {
                    MakerUMnt makerUMnt = this.MakerUMntDic[campaignMng.GoodsMakerCd];
                    //row.GoodsMakerName = makerUMnt.MakerName;  // DEL 2011/07/07 
                    row.GoodsMakerName = makerUMnt.MakerKanaName;  // ADD 2011/07/07 
                }
                else
                {
                    row.GoodsMakerName = string.Empty;
                }

                // BLｺｰﾄﾞ
                row.BLGoodsCode = campaignMng.BLGoodsCode;
                // 品名
                BLGoodsCdUMnt bLGoodsCdUMnt = null;
                if (this.BLGoodsCdDic.ContainsKey(campaignMng.BLGoodsCode))
                {
                    bLGoodsCdUMnt = this.BLGoodsCdDic[campaignMng.BLGoodsCode];
                }
                if (bLGoodsCdUMnt != null)
                {
                    row.GoodsName = bLGoodsCdUMnt.BLGoodsHalfName;
                }
                else
                {
                    row.GoodsName = string.Empty;
                }


                row.SalesCode = string.Empty;
                row.GoodsNo = string.Empty;
                row.BLGroupCode = 0; 
            }

            if (campaignMng.CampaignSettingKind == 1)
            {
                // ﾒｰｶｰ
                row.GoodsMakerCode = campaignMng.GoodsMakerCd;
                // ﾒｰｶｰ名
                if (this.MakerUMntDic.ContainsKey(campaignMng.GoodsMakerCd))
                {
                    MakerUMnt makerUMnt = this.MakerUMntDic[campaignMng.GoodsMakerCd];
                    //row.GoodsMakerName = makerUMnt.MakerName;  // DEL 2011/07/07 
                    row.GoodsMakerName = makerUMnt.MakerKanaName;    // ADD 2011/07/07 
                }
                else
                {
                    row.GoodsMakerName = string.Empty;
                }

                // 品番
                row.GoodsNo = campaignMng.GoodsNo;
                // 品名
                if (campaignMng.GoodsNameKana.Trim() == string.Empty)
                {
                    if (campaignMng.GoodsNo.Trim() != string.Empty)
                    {
                        List<GoodsUnitData> goodsDate;
                        GoodsCndtn cndtn = new GoodsCndtn();
                        cndtn.EnterpriseCode = this._enterpriseCode;
                        if (campaignMng.GoodsMakerCd != 0)
                        {
                            cndtn.GoodsMakerCd = campaignMng.GoodsMakerCd;
                        }
                        cndtn.GoodsNo = campaignMng.GoodsNo.Trim();
                        cndtn.GoodsKindCode = 9;
                        // --- UPD 2011/07/22 ----->>>>>
                        cndtn.IsSettingSupplier = 1;
                        PartsInfoDataSet partsInfoDataSet;
                        string msg = string.Empty;
                        //if (this._goodsAcs.SearchPartsFromGoodsNoNonVariousSearch(cndtn, out goodsDate, out msg) == 0)
                        if (this._goodsAcs.SearchPartsOfNonGoodsNo(cndtn, out partsInfoDataSet, out goodsDate, out msg) == 0)
                        // --- UPD 2011/07/22 -----<<<<<
                        {
                            if (goodsDate.Count > 0)
                            {
                                row.GoodsName = goodsDate[0].GoodsNameKana;
                            }
                        }
                        else
                        {
                            row.GoodsName = string.Empty;
                        }
                    }
                    else
                    {
                        row.GoodsName = string.Empty;
                    }
                }
                else
                {
                    row.GoodsName = campaignMng.GoodsNameKana;
                }


                row.SalesCode = string.Empty;
                row.BLGoodsCode = 0;
                row.BLGroupCode = 0;
            }

            row.CampaignCode = campaignMng.CampaignCode; //ｺｰﾄﾞ
            if (this.CampaignStDic.ContainsKey(campaignMng.CampaignCode)) //名称
            {
                CampaignSt campaignSt = this.CampaignStDic[campaignMng.CampaignCode];
                row.CampaignName = campaignSt.CampaignName;
            }
            else
            {
                row.CampaignName = string.Empty;
            }
        }

        /// <summary>
        /// キャンペーン対象商品設定マスター＞明細行
        /// </summary>
        /// <param name="row">明細行</param>
        /// <param name="campaignMng">キャンペーン対象商品設定マスタ</param>
        /// <remarks>
        /// <br>Note       : キャンペーン対象商品設定マスター＞明細行</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// <br>UpdateNote : 2011/07/14 曹文傑 Redmine#22984 最終行の情報がデータ登録されない</br>
        /// <br>UpdateNote : 2011/07/15 曹文傑 Redmine#23004 キャンペーン対象商品設定マスタの日付範囲チェックエラー対応</br>
        /// </remarks>
        public void CopyToCampaignMngFromDetailRow(CampaignMngDataSet.CampaignMngRow row, ref CampaignObjGoodsSt campaignMng)
        {
            // ---ADD 2011/07/14-------------->>>>>
            if (campaignMng == null)
            {
                campaignMng = new CampaignObjGoodsSt();
            }
            // ---ADD 2011/07/14--------------<<<<<
            campaignMng.EnterpriseCode = this._enterpriseCode; // ADD 2011/07/15
            campaignMng.SectionCode = row.SectionCode.ToString().PadLeft(2, '0');
            campaignMng.BLGoodsCode = row.BLGoodsCode;
            campaignMng.GoodsMakerCd = row.GoodsMakerCode;
            campaignMng.GoodsNo = row.GoodsNo;
            campaignMng.CampaignCode = row.CampaignCode;
            campaignMng.PriceFl = row.PriceFl;
            campaignMng.RateVal = row.RateVal;
            campaignMng.BLGroupCode = row.BLGroupCode;
            if (row.SalesCode.Trim() == string.Empty)
            {
                campaignMng.SalesCode = 0;
            }
            else
            {
                campaignMng.SalesCode = Convert.ToInt32(row.SalesCode);
            }
            campaignMng.CampaignSettingKind = row.CampaignSettingKind;
            campaignMng.SalesPriceSetDiv = row.SalesPriceSetDiv;
            if (row.CustomerCode.Trim() == string.Empty)
            {
                campaignMng.CustomerCode = 0;
            }
            else
            {
                campaignMng.CustomerCode = Convert.ToInt32(row.CustomerCode);
            }
            campaignMng.DiscountRate= row.DiscountRate;
            campaignMng.PriceStartDate = row.PriceStartDate;
            campaignMng.PriceEndDate = row.PriceEndDate;

            campaignMng.RowIndex = row.RowNo;
        }

        /// <summary>
        /// キャンペーン対象商品設定マスタ比較処理
        /// </summary>
        /// <param name="campaignMng1">キャンペーン対象商品設定マスタ</param>
        /// <param name="campaignMng2">キャンペーン対象商品設定マスタ</param>
        /// <returns>true:不同、false:同じ</returns>
        /// <remarks>
        /// <br>Note       : キャンペーン対象商品設定マスタ比較処理</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        public bool Compare(CampaignObjGoodsSt campaignMng1, CampaignObjGoodsSt campaignMng2)
        {
            if (campaignMng1.PriceEndDate != campaignMng2.PriceEndDate
                || campaignMng1.PriceStartDate != campaignMng2.PriceStartDate
                || campaignMng1.CustomerCode != campaignMng2.CustomerCode
                || campaignMng1.DiscountRate != campaignMng2.DiscountRate
                || campaignMng1.SalesPriceSetDiv != campaignMng2.SalesPriceSetDiv
                || campaignMng1.SalesCode != campaignMng2.SalesCode
                || campaignMng1.BLGroupCode != campaignMng2.BLGroupCode
                || campaignMng1.RateVal != campaignMng2.RateVal
                || campaignMng1.PriceFl != campaignMng2.PriceFl
                || campaignMng1.GoodsNo.Trim() != campaignMng2.GoodsNo.Trim()
                || campaignMng1.GoodsMakerCd != campaignMng2.GoodsMakerCd
                || campaignMng1.BLGoodsCode != campaignMng2.BLGoodsCode
                || campaignMng1.SectionCode.Trim().PadLeft(2, '0') != campaignMng2.SectionCode.Trim().PadLeft(2, '0'))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// キャンペーン対象商品設定マスタ比較処理
        /// </summary>
        /// <param name="campaignMng1">キャンペーン対象商品設定マスタ</param>
        /// <param name="campaignMng2">キャンペーン対象商品設定マスタ</param>
        /// <returns>true:不同、false:同じ</returns>
        /// <remarks>
        /// <br>Note       : キャンペーン対象商品設定マスタ比較処理</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        public bool CompareKey(CampaignObjGoodsSt campaignMng1, CampaignObjGoodsSt campaignMng2)
        {
            if (campaignMng1.PriceEndDate != campaignMng2.PriceEndDate
                || campaignMng1.PriceStartDate != campaignMng2.PriceStartDate
                || campaignMng1.CustomerCode != campaignMng2.CustomerCode
                || campaignMng1.SalesPriceSetDiv != campaignMng2.SalesPriceSetDiv
                || campaignMng1.SalesCode != campaignMng2.SalesCode
                || campaignMng1.BLGroupCode != campaignMng2.BLGroupCode
                || campaignMng1.GoodsNo.Trim() != campaignMng2.GoodsNo.Trim()
                || campaignMng1.GoodsMakerCd != campaignMng2.GoodsMakerCd
                || campaignMng1.BLGoodsCode != campaignMng2.BLGoodsCode
                || campaignMng1.SectionCode.Trim().PadLeft(2, '0') != campaignMng2.SectionCode.Trim().PadLeft(2, '0'))
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
        /// <param name="searchCondition1">抽出条件1</param>
        /// <param name="searchCondition2">抽出条件2</param>
        /// <returns>true:同、false:不同</returns>
        /// <remarks>
        /// <br>Note       : 抽出条件比較処理</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        public bool CompareSearchCondition(SearchCondition searchCondition1, SearchCondition searchCondition2)
        {
            //検索条件が変更なしの場合は検索しない
            if (searchCondition1.CampaignCode == searchCondition2.CampaignCode
                && searchCondition1.SectionCode.Trim().PadLeft(2, '0') == searchCondition2.SectionCode.Trim().PadLeft(2, '0')
                && searchCondition1.SalesCodeSt == searchCondition2.SalesCodeSt
                && searchCondition1.SalesCodeEd == searchCondition2.SalesCodeEd
                && searchCondition1.BLGoodsCodeSt == searchCondition2.BLGoodsCodeSt
                && searchCondition1.BLGoodsCodeEd == searchCondition2.BLGoodsCodeEd
                && searchCondition1.BLGroupCodeSt == searchCondition2.BLGroupCodeSt
                && searchCondition1.BLGroupCodeEd == searchCondition2.BLGroupCodeEd
                && searchCondition1.DeleteFlag == searchCondition2.DeleteFlag
                && searchCondition1.DiscountRate == searchCondition2.DiscountRate
                && searchCondition1.DiscountRateDiv == searchCondition2.DiscountRateDiv
                && searchCondition1.EnterpriseCode == searchCondition2.EnterpriseCode
                && searchCondition1.GoodsMakerCdSt == searchCondition2.GoodsMakerCdSt
                && searchCondition1.GoodsMakerCdEd == searchCondition2.GoodsMakerCdEd
                && searchCondition1.GoodsNo.Trim() == searchCondition2.GoodsNo.Trim()
                && searchCondition1.PriceFl == searchCondition2.PriceFl
                && searchCondition1.PriceFlDiv == searchCondition2.PriceFlDiv
                && searchCondition1.RateVal == searchCondition2.RateVal
                && searchCondition1.RateValDiv == searchCondition2.RateValDiv)
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
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// <br>UpdateNote : 2011/07/14 曹文傑 Redmine#22984 最終行の情報がデータ登録されない</br>
        /// </remarks>
        public bool IsRowUpdate(CampaignMngDataSet.CampaignMngRow row)
        {
            // ---UPD 2011/07/14--------------->>>>>
            //if (row.CampaignCode != 0
            //    || row.SectionCode != "00"
            //    || row.CampaignSettingKind != 1
            //    || row.GoodsMakerCode != 0
            //    || row.GoodsNo != string.Empty
            //    || row.BLGoodsCode != 0
            //    || row.BLGroupCode != 0
            //    || row.SalesCode.Trim() != string.Empty
            //    || row.SalesPriceSetDiv != 0
            //    || row.CustomerCode.Trim() != string.Empty
            //    || row.DiscountRate != 0
            //    || row.RateVal != 0
            //    || row.PriceFl != 0
            //    || row.PriceStartDate != 0
            //    || row.PriceEndDate != 0)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}

            if (row.CampaignCode != this._newCampaignObj.CampaignCode
                || row.SectionCode.PadLeft(2, '0') != this._newCampaignObj.SectionCode.ToString().PadLeft(2, '0')
                || row.CampaignSettingKind != this._newCampaignObj.CampaignSettingKind
                || row.GoodsMakerCode != this._newCampaignObj.GoodsMakerCd
                || row.GoodsNo.Trim() != this._newCampaignObj.GoodsNo.Trim()
                || row.BLGoodsCode != this._newCampaignObj.BLGoodsCode
                || row.BLGroupCode != this._newCampaignObj.BLGroupCode
                || row.SalesCode.Trim().PadLeft(4, '0') != this._newCampaignObj.SalesCode.ToString().PadLeft(4, '0')
                || row.SalesPriceSetDiv != this._newCampaignObj.SalesPriceSetDiv
                || row.CustomerCode.Trim().PadLeft(8, '0') != this._newCampaignObj.CustomerCode.ToString().PadLeft(8, '0')
                || row.DiscountRate != this._newCampaignObj.DiscountRate
                || row.RateVal != this._newCampaignObj.RateVal
                || row.PriceFl != this._newCampaignObj.PriceFl
                || row.PriceStartDate != this._newCampaignObj.PriceStartDate
                || row.PriceEndDate != this._newCampaignObj.PriceEndDate)
            {
                return true;
            }
            else
            {
                return false;
            }
            // ---UPD 2011/07/14---------------<<<<<
        }

        /// <summary>
        /// マスタデータ取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : マスタデータ取得処理</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// <br>UpdateNote : 2011/07/22 譚洪 Redmine#23119 優良設定マスタを設定後に最新情報取得を実行しても、再取得されない事が問題ありますの対応</br>
        /// </remarks>
        public void LoadMstData()
        {
            // ---------------- UPD Redmine#23556 2011/08/12 --------------------->>>>>
            //this.LoadMakerUMnt();

            //this.LoadBlCodeMst();

            //this.LoadBlGroupMst();

            //this.CacheUserGd();

            //this.ReadSecInfoSet();
            
            //this.GetCustomerDic();
            
            //this.LoadCampaignSt();

            //this.LoadCampaignLink();

            //// --- ADD 2011/07/22 ---- >>>>>>>>>
            //#region ●商品アクセスクラス初期処理(キャッシュなし)
            //string retMessage;
            //this._goodsAcs = new GoodsAcs();
            //this._goodsAcs.IsLocalDBRead = false;
            //this._goodsAcs.Owner = this._owner;
            //this._goodsAcs.IsGetSupplier = true;
            //this._goodsAcs.SearchInitial(this._enterpriseCode, this._loginSectionCode, out retMessage);
            //#endregion
            //// --- ADD 2011/07/22 ---- <<<<<<<<<

            this._masterAcsThread = new Thread(new ThreadStart(MasterThreadProc));   // マスタデータ取得スレッド
            this._goodsAcsThread = new Thread(new ThreadStart(GoodsThreadProc));   // 商品データ取得スレッド
            this._goodsAcsThread.Start();
            this._masterAcsThread.Start();
            // ---------------- UPD Redmine#23556 2011/08/12 ---------------------<<<<<
        }

        // ---------------- ADD Redmine#23556 2011/08/12 --------------------->>>>>
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

            this.GetCustomerDic();//得意先マスタの読み込み

            this.LoadCampaignSt();//キャンペーン管理マスタの読み込み

            this.LoadCampaignLink();//キャンペーン関連マスタの読み込み
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
        // ---------------- ADD Redmine#23556 2011/08/12 ---------------------<<<<<

        /// <summary>
        /// BlCodeマスタデータ取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : BlCodeマスタデータ取得処理</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
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
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
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
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
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
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
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
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
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
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void GetCustomerDic()
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
                            continue;
                        }

                        this._customerDic.Add(customerInfo.CustomerCode, customerInfo);
                    }
                }
            }
            catch
            {
                this._customerDic = new Dictionary<int, CustomerInfo>();
            }
        }

        /// <summary>
        /// キャンペーン設定マスタ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : キャンペーン設定マスタ読込処理を行います。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        public void LoadCampaignSt()
        {
            this._campaignStDic = new Dictionary<int, CampaignSt>();

            try
            {
                ArrayList retList;

                int status = this._campaignStAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (CampaignSt campaignSt in retList)
                    {
                        this._campaignStDic.Add(campaignSt.CampaignCode, campaignSt);
                    }
                }
            }
            catch
            {
                this._campaignStDic = new Dictionary<int, CampaignSt>();
            }
        }

        /// <summary>
        /// キャンペーン関連マスタ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : キャンペーン関連マスタ読込処理を行います。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void LoadCampaignLink()
        {
            this._campaignLinkList = new List<CampaignLink>();

            try
            {
                ArrayList retList;

                int status = this._campaignLinkAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (CampaignLink campaignLink in retList)
                    {
                        this._campaignLinkList.Add(campaignLink);
                    }
                }
            }
            catch
            {
                this._campaignLinkList = new List<CampaignLink>();
            }
        }

        /// <summary>
        /// キャンペーン対象商品設定マスタ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : キャンペーン対象商品設定マスタ読込処理を行います。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void LoadCampaignMng()
        {
            this._campaignMngList = new List<CampaignObjGoodsSt>();

            try
            {
                ArrayList retList = new ArrayList();
                object retObj = retList as object;
                string msg = string.Empty;
                int status = this._iCampaignObjGoodsStDB.Search(out retObj, this._enterpriseCode, 0, ConstantManagement.LogicalMode.GetData01, ref msg);
                if (status == 0)
                {
                    retList = retObj as ArrayList;
                    CampaignObjGoodsSt campaignObjGoodsSt;
                    foreach (CampaignObjGoodsStWork campaignObjGoodsStWork in retList)
                    {
                        campaignObjGoodsSt = CopyToCampaignMngFromCampaignMngWork(campaignObjGoodsStWork);
                        this._campaignMngList.Add(campaignObjGoodsSt);
                    }
                }
            }
            catch
            {
                this._campaignMngList = new List<CampaignObjGoodsSt>();
            }
        }

        /// <summary>
        /// SearchCondition->SearchConditionWork
        /// </summary>
        /// <param name="searchCondition">検索条件</param>
        /// <returns>検索条件</returns>
        /// <remarks>
        /// <br>Note       : SearchCondition->SearchConditionWork</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private SearchConditionWork CopyToSearchConditionWorkFromSearchCondition(SearchCondition searchCondition)
        {
            SearchConditionWork searchConditionWork = new SearchConditionWork();

            searchConditionWork.EnterpriseCode = searchCondition.EnterpriseCode;
            searchConditionWork.CampaignCode = searchCondition.CampaignCode;
            searchConditionWork.SectionCode = searchCondition.SectionCode;
            searchConditionWork.GoodsMakerCdSt = searchCondition.GoodsMakerCdSt;
            searchConditionWork.GoodsMakerCdEd = searchCondition.GoodsMakerCdEd;
            searchConditionWork.BLGoodsCodeSt = searchCondition.BLGoodsCodeSt;
            searchConditionWork.BLGoodsCodeEd = searchCondition.BLGoodsCodeEd;
            searchConditionWork.BLGroupCodeSt = searchCondition.BLGroupCodeSt;
            searchConditionWork.BLGroupCodeEd = searchCondition.BLGroupCodeEd;
            searchConditionWork.SalesCodeSt = searchCondition.SalesCodeSt;
            searchConditionWork.SalesCodeEd = searchCondition.SalesCodeEd;
            searchConditionWork.GoodsNo = searchCondition.GoodsNo;
            searchConditionWork.DeleteFlag = searchCondition.DeleteFlag;
            searchConditionWork.DiscountRate = searchCondition.DiscountRate;
            searchConditionWork.DiscountRateDiv = searchCondition.DiscountRateDiv;
            searchConditionWork.RateVal = searchCondition.RateVal;
            searchConditionWork.RateValDiv = searchCondition.RateValDiv;
            searchConditionWork.PriceFl = searchCondition.PriceFl;
            searchConditionWork.PriceFlDiv = searchCondition.PriceFlDiv;

            return searchConditionWork;
        }

        /// <summary>
        /// CampaignMngWork->CampaignMng
        /// </summary>
        /// <param name="campaignObjGoodsStWork">キャンペーン対象商品設定ワーク</param>
        /// <returns>キャンペーン対象商品設定</returns>
        /// <remarks>
        /// <br>Note       : CampaignMngWork->CampaignMng</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private CampaignObjGoodsSt CopyToCampaignMngFromCampaignMngWork(CampaignObjGoodsStWork campaignObjGoodsStWork)
        {
            CampaignObjGoodsSt campaignObjGoodsSt = new CampaignObjGoodsSt();

            campaignObjGoodsSt.CreateDateTime = campaignObjGoodsStWork.CreateDateTime;
            campaignObjGoodsSt.UpdateDateTime = campaignObjGoodsStWork.UpdateDateTime;
            campaignObjGoodsSt.EnterpriseCode = campaignObjGoodsStWork.EnterpriseCode;
            campaignObjGoodsSt.FileHeaderGuid = campaignObjGoodsStWork.FileHeaderGuid;
            campaignObjGoodsSt.UpdEmployeeCode = campaignObjGoodsStWork.UpdEmployeeCode;
            campaignObjGoodsSt.UpdAssemblyId1 = campaignObjGoodsStWork.UpdAssemblyId1;
            campaignObjGoodsSt.UpdAssemblyId2 = campaignObjGoodsStWork.UpdAssemblyId2;
            campaignObjGoodsSt.LogicalDeleteCode = campaignObjGoodsStWork.LogicalDeleteCode;
            campaignObjGoodsSt.SectionCode = campaignObjGoodsStWork.SectionCode;
            campaignObjGoodsSt.GoodsMGroup = campaignObjGoodsStWork.GoodsMGroup;
            campaignObjGoodsSt.BLGoodsCode = campaignObjGoodsStWork.BLGoodsCode;
            campaignObjGoodsSt.GoodsMakerCd = campaignObjGoodsStWork.GoodsMakerCd;
            campaignObjGoodsSt.GoodsNo = campaignObjGoodsStWork.GoodsNo;
            campaignObjGoodsSt.SalesTargetMoney = campaignObjGoodsStWork.SalesTargetMoney;
            campaignObjGoodsSt.SalesTargetProfit = campaignObjGoodsStWork.SalesTargetProfit;
            campaignObjGoodsSt.SalesTargetCount = campaignObjGoodsStWork.SalesTargetCount;
            campaignObjGoodsSt.CampaignCode = campaignObjGoodsStWork.CampaignCode;
            campaignObjGoodsSt.PriceFl = campaignObjGoodsStWork.PriceFl;
            campaignObjGoodsSt.RateVal = campaignObjGoodsStWork.RateVal;
            campaignObjGoodsSt.BLGroupCode = campaignObjGoodsStWork.BLGroupCode;
            campaignObjGoodsSt.SalesCode = campaignObjGoodsStWork.SalesCode;
            campaignObjGoodsSt.CampaignSettingKind = campaignObjGoodsStWork.CampaignSettingKind;
            campaignObjGoodsSt.SalesPriceSetDiv = campaignObjGoodsStWork.SalesPriceSetDiv;
            campaignObjGoodsSt.CustomerCode = campaignObjGoodsStWork.CustomerCode;
            campaignObjGoodsSt.PriceStartDate = campaignObjGoodsStWork.PriceStartDate;
            campaignObjGoodsSt.PriceEndDate = campaignObjGoodsStWork.PriceEndDate;
            campaignObjGoodsSt.DiscountRate = campaignObjGoodsStWork.DiscountRate;
            campaignObjGoodsSt.GoodsNameKana = campaignObjGoodsStWork.GoodsNameKana;
            campaignObjGoodsSt.RowIndex = campaignObjGoodsStWork.RowIndex;

            return campaignObjGoodsSt;
        }

        /// <summary>
        /// CampaignMng->CampaignMngWork
        /// </summary>
        /// <param name="campaignObjGoodsSt">キャンペーン対象商品設定</param>
        /// <returns>キャンペーン対象商品設定ワーク</returns>
        /// <remarks>
        /// <br>Note       : CampaignMng->CampaignMngWork</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private CampaignObjGoodsStWork CopyToCampaignMngWorkFromCampaignMng(CampaignObjGoodsSt campaignObjGoodsSt)
        {
            CampaignObjGoodsStWork campaignObjGoodsStWork = new CampaignObjGoodsStWork();

            campaignObjGoodsStWork.CreateDateTime = campaignObjGoodsSt.CreateDateTime;
            campaignObjGoodsStWork.UpdateDateTime = campaignObjGoodsSt.UpdateDateTime;
            campaignObjGoodsStWork.EnterpriseCode = campaignObjGoodsSt.EnterpriseCode;
            campaignObjGoodsStWork.FileHeaderGuid = campaignObjGoodsSt.FileHeaderGuid;
            campaignObjGoodsStWork.UpdEmployeeCode = campaignObjGoodsSt.UpdEmployeeCode;
            campaignObjGoodsStWork.UpdAssemblyId1 = campaignObjGoodsSt.UpdAssemblyId1;
            campaignObjGoodsStWork.UpdAssemblyId2 = campaignObjGoodsSt.UpdAssemblyId2;
            campaignObjGoodsStWork.LogicalDeleteCode = campaignObjGoodsSt.LogicalDeleteCode;
            campaignObjGoodsStWork.SectionCode = campaignObjGoodsSt.SectionCode;
            campaignObjGoodsStWork.GoodsMGroup = campaignObjGoodsSt.GoodsMGroup;
            campaignObjGoodsStWork.BLGoodsCode = campaignObjGoodsSt.BLGoodsCode;
            campaignObjGoodsStWork.GoodsMakerCd = campaignObjGoodsSt.GoodsMakerCd;
            campaignObjGoodsStWork.GoodsNo = campaignObjGoodsSt.GoodsNo;
            campaignObjGoodsStWork.SalesTargetMoney = campaignObjGoodsSt.SalesTargetMoney;
            campaignObjGoodsStWork.SalesTargetProfit = campaignObjGoodsSt.SalesTargetProfit;
            campaignObjGoodsStWork.SalesTargetCount = campaignObjGoodsSt.SalesTargetCount;
            campaignObjGoodsStWork.CampaignCode = campaignObjGoodsSt.CampaignCode;
            campaignObjGoodsStWork.PriceFl = campaignObjGoodsSt.PriceFl;
            campaignObjGoodsStWork.RateVal = campaignObjGoodsSt.RateVal;
            campaignObjGoodsStWork.BLGroupCode = campaignObjGoodsSt.BLGroupCode;
            campaignObjGoodsStWork.SalesCode = campaignObjGoodsSt.SalesCode;
            campaignObjGoodsStWork.CampaignSettingKind = campaignObjGoodsSt.CampaignSettingKind;
            campaignObjGoodsStWork.SalesPriceSetDiv = campaignObjGoodsSt.SalesPriceSetDiv;
            campaignObjGoodsStWork.CustomerCode = campaignObjGoodsSt.CustomerCode;
            campaignObjGoodsStWork.PriceStartDate = campaignObjGoodsSt.PriceStartDate;
            campaignObjGoodsStWork.PriceEndDate = campaignObjGoodsSt.PriceEndDate;
            campaignObjGoodsStWork.DiscountRate = campaignObjGoodsSt.DiscountRate;
            campaignObjGoodsStWork.RowIndex = campaignObjGoodsSt.RowIndex;

            return campaignObjGoodsStWork;
        }

        #region キャンペーン売価率、売価額取得処理
        /// <summary>
        /// キャンペーン売価率、売価額取得処理
        /// </summary>
        /// <param name="campaignObjGoodsSt">抽出結果キャンペーン対象商品設定データ</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="goodsMakerCd">メーカーコード</param>
        /// <param name="blGroupCode">グループコード</param>
        /// <param name="blGoodsCode">BLコード</param>
        /// <param name="salesCode">販売区分</param>
        /// <param name="goodsNo">品番</param>
        /// <param name="applyDate">適用日</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : キャンペーン売価率、売価額取得の取得を行います。
        ///                  抽出条件からキャンペーン売価率、売価額取得処理が設定されているキャンペーン対象商品設定データを返します。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        public int GetRatePriceOfCampaignMng(out CampaignObjGoodsSt campaignObjGoodsSt, string enterpriseCode, string sectionCode, int customerCode,
                                             int goodsMakerCd, int blGroupCode, int blGoodsCode, int salesCode, string goodsNo, DateTime applyDate)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            CampaignObjGoodsSt readCampaignObjGoodsSt = new CampaignObjGoodsSt();
            // 適用日
            int applyDateTime = 0;
            int.TryParse(applyDate.Date.ToString("yyyyMMdd"), out applyDateTime);

            // 引数よりキャンペーン売価優先設定マスタ情報を取得

            // UPD 2013/01/18 T.Yoshioka 2013/03/13配信予定 SCM障害№10475 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            //CampaignPrcPrSt campaignPrcPrSt = null;
            //this.GetCampaignPrcPrSt(out campaignPrcPrSt, enterpriseCode, sectionCode);
            if (first)
            {
                this.GetCampaignPrcPrSt(out campaignPrcPrSt, enterpriseCode, sectionCode);
                first = false;
            }
            // UPD 2013/01/18 T.Yoshioka 2013/03/13配信予定 SCM障害№10475 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

            if (this._campaignObjGoodsStList == null)
            {
                List<CampaignObjGoodsSt> retList = null;
                // キャンペーン対象商品設定マスタの全検索
                status = this.Search(out retList, enterpriseCode, ConstantManagement.LogicalMode.GetData01);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ADD 2014/05/08 PM-SCM速度改良 フェーズ２№04.キャンペーン売価設定マスタ取得改良対応 -------------------------------------->>>>>
                    if (status == (int)ConstantManagement.DB_Status.ctDB_EOF)
                    {
                        // 該当データなしの時
                        this._campaignObjGoodsStList = new List<CampaignObjGoodsSt>();
                    }
                    // ADD 2014/05/08 PM-SCM速度改良 フェーズ２№04.キャンペーン売価設定マスタ取得改良対応 --------------------------------------<<<<<

                    // 全検索で失敗
                    readCampaignObjGoodsSt = null;
                    campaignObjGoodsSt = null;

                    _statusOfResult = "キャンペーン対象商品設定マスタの全検索で失敗";

                    return status;
                }

                //キャンペーン対象商品設定データのキャッシュ化
                this._campaignObjGoodsStList = new List<CampaignObjGoodsSt>();

                foreach (CampaignObjGoodsSt campaignObjGoods in retList)
                {
                    if (campaignObjGoods.LogicalDeleteCode != 0)
                    {
                        continue;
                    }

                    this._campaignObjGoodsStList.Add(campaignObjGoods);
                }
            }
            // ADD 2014/05/08 PM-SCM速度改良 フェーズ２№04.キャンペーン売価設定マスタ取得改良対応 -------------------------------------->>>>>
            else if (this._campaignObjGoodsStList != null && this._campaignObjGoodsStList.Count == 0)
            {
                readCampaignObjGoodsSt = null;
                campaignObjGoodsSt = null;
                _statusOfResult = "該当データなし";
                return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
           }
           // ADD 2014/05/08 PM-SCM速度改良 フェーズ２№04.キャンペーン売価設定マスタ取得改良対応 --------------------------------------<<<<<


            // キャンペーン対象商品設定マスタテーブル対象判定
            List<CampaignObjGoodsSt> campaignList = new List<CampaignObjGoodsSt>();
            if (campaignPrcPrSt != null)
            {
                for (int i = 1; i <= 6; i++)
                {
                    if (campaignList.Count > 0)
                    {
                        break;
                    }

                    switch (i)
                    {
                        case 1:
                            {
                                if (campaignPrcPrSt.PrioritySettingCd1 != 0)
                                {
                                    foreach (CampaignObjGoodsSt campaignObjGoods in this._campaignObjGoodsStList)
                                    {
                                        if (campaignObjGoods.CampaignSettingKind == campaignPrcPrSt.PrioritySettingCd1)
                                        {
                                            switch (campaignPrcPrSt.PrioritySettingCd1)
                                            {
                                                //1：ﾒｰｶｰ+品番
                                                case 1:
                                                    {
                                                        if (campaignObjGoods.GoodsMakerCd == goodsMakerCd && campaignObjGoods.GoodsNo.Trim() == goodsNo.Trim())
                                                        {
                                                            this.DetermineDate(ref campaignList, campaignObjGoods, sectionCode, enterpriseCode, applyDateTime, customerCode);
                                                        }
                                                        break;
                                                    }
                                                //2：ﾒｰｶｰ+BLｺｰﾄﾞ
                                                case 2:
                                                    {
                                                        if (campaignObjGoods.GoodsMakerCd == goodsMakerCd && campaignObjGoods.BLGoodsCode == blGoodsCode)
                                                        {
                                                            this.DetermineDate(ref campaignList, campaignObjGoods, sectionCode, enterpriseCode, applyDateTime, customerCode);
                                                        }
                                                        break;
                                                    }
                                                //3：ﾒｰｶｰ+ｸﾞﾙｰﾌﾟ
                                                case 3:
                                                    {
                                                        if (campaignObjGoods.GoodsMakerCd == goodsMakerCd && campaignObjGoods.BLGroupCode == blGroupCode)
                                                        {
                                                            this.DetermineDate(ref campaignList, campaignObjGoods, sectionCode, enterpriseCode, applyDateTime, customerCode);
                                                        }
                                                        break;
                                                    }
                                                //4：ﾒｰｶｰ
                                                case 4:
                                                    {
                                                        if (campaignObjGoods.GoodsMakerCd == goodsMakerCd)
                                                        {
                                                            this.DetermineDate(ref campaignList, campaignObjGoods, sectionCode, enterpriseCode, applyDateTime, customerCode);
                                                        }
                                                        break;
                                                    }
                                                //5：BLｺｰﾄﾞ
                                                case 5:
                                                    {
                                                        if (campaignObjGoods.BLGoodsCode == blGoodsCode)
                                                        {
                                                            this.DetermineDate(ref campaignList, campaignObjGoods, sectionCode, enterpriseCode, applyDateTime, customerCode);
                                                        }
                                                        break;
                                                    }
                                                //6：販売区分
                                                case 6:
                                                    {
                                                        if (campaignObjGoods.SalesCode == salesCode)
                                                        {
                                                            this.DetermineDate(ref campaignList, campaignObjGoods, sectionCode, enterpriseCode, applyDateTime, customerCode);
                                                        }
                                                        break;
                                                    }
                                            }
                                        }
                                    }
                                }
                                break;
                            }
                        case 2:
                            {
                                if (campaignPrcPrSt.PrioritySettingCd2 != 0)
                                {
                                    foreach (CampaignObjGoodsSt campaignObjGoods in this._campaignObjGoodsStList)
                                    {
                                        if (campaignObjGoods.CampaignSettingKind == campaignPrcPrSt.PrioritySettingCd2)
                                        {
                                            switch (campaignPrcPrSt.PrioritySettingCd2)
                                            {
                                                //1：ﾒｰｶｰ+品番
                                                case 1:
                                                    {
                                                        if (campaignObjGoods.GoodsMakerCd == goodsMakerCd && campaignObjGoods.GoodsNo.Trim() == goodsNo.Trim())
                                                        {
                                                            this.DetermineDate(ref campaignList, campaignObjGoods, sectionCode, enterpriseCode, applyDateTime, customerCode);
                                                        }
                                                        break;
                                                    }
                                                //2：ﾒｰｶｰ+BLｺｰﾄﾞ
                                                case 2:
                                                    {
                                                        if (campaignObjGoods.GoodsMakerCd == goodsMakerCd && campaignObjGoods.BLGoodsCode == blGoodsCode)
                                                        {
                                                            this.DetermineDate(ref campaignList, campaignObjGoods, sectionCode, enterpriseCode, applyDateTime, customerCode);
                                                        }
                                                        break;
                                                    }
                                                //3：ﾒｰｶｰ+ｸﾞﾙｰﾌﾟ
                                                case 3:
                                                    {
                                                        if (campaignObjGoods.GoodsMakerCd == goodsMakerCd && campaignObjGoods.BLGroupCode == blGroupCode)
                                                        {
                                                            this.DetermineDate(ref campaignList, campaignObjGoods, sectionCode, enterpriseCode, applyDateTime, customerCode);
                                                        }
                                                        break;
                                                    }
                                                //4：ﾒｰｶｰ
                                                case 4:
                                                    {
                                                        if (campaignObjGoods.GoodsMakerCd == goodsMakerCd)
                                                        {
                                                            this.DetermineDate(ref campaignList, campaignObjGoods, sectionCode, enterpriseCode, applyDateTime, customerCode);
                                                        }
                                                        break;
                                                    }
                                                //5：BLｺｰﾄﾞ
                                                case 5:
                                                    {
                                                        if (campaignObjGoods.BLGoodsCode == blGoodsCode)
                                                        {
                                                            this.DetermineDate(ref campaignList, campaignObjGoods, sectionCode, enterpriseCode, applyDateTime, customerCode);
                                                        }
                                                        break;
                                                    }
                                                //6：販売区分
                                                case 6:
                                                    {
                                                        if (campaignObjGoods.SalesCode == salesCode)
                                                        {
                                                            this.DetermineDate(ref campaignList, campaignObjGoods, sectionCode, enterpriseCode, applyDateTime, customerCode);
                                                        }
                                                        break;
                                                    }
                                            }
                                        }
                                    }
                                }
                                break;
                            }
                        case 3:
                            {
                                if (campaignPrcPrSt.PrioritySettingCd3 != 0)
                                {
                                    foreach (CampaignObjGoodsSt campaignObjGoods in this._campaignObjGoodsStList)
                                    {
                                        if (campaignObjGoods.CampaignSettingKind == campaignPrcPrSt.PrioritySettingCd3)
                                        {
                                            switch (campaignPrcPrSt.PrioritySettingCd3)
                                            {
                                                //1：ﾒｰｶｰ+品番
                                                case 1:
                                                    {
                                                        if (campaignObjGoods.GoodsMakerCd == goodsMakerCd && campaignObjGoods.GoodsNo.Trim() == goodsNo.Trim())
                                                        {
                                                            this.DetermineDate(ref campaignList, campaignObjGoods, sectionCode, enterpriseCode, applyDateTime, customerCode);
                                                        }
                                                        break;
                                                    }
                                                //2：ﾒｰｶｰ+BLｺｰﾄﾞ
                                                case 2:
                                                    {
                                                        if (campaignObjGoods.GoodsMakerCd == goodsMakerCd && campaignObjGoods.BLGoodsCode == blGoodsCode)
                                                        {
                                                            this.DetermineDate(ref campaignList, campaignObjGoods, sectionCode, enterpriseCode, applyDateTime, customerCode);
                                                        }
                                                        break;
                                                    }
                                                //3：ﾒｰｶｰ+ｸﾞﾙｰﾌﾟ
                                                case 3:
                                                    {
                                                        if (campaignObjGoods.GoodsMakerCd == goodsMakerCd && campaignObjGoods.BLGroupCode == blGroupCode)
                                                        {
                                                            this.DetermineDate(ref campaignList, campaignObjGoods, sectionCode, enterpriseCode, applyDateTime, customerCode);
                                                        }
                                                        break;
                                                    }
                                                //4：ﾒｰｶｰ
                                                case 4:
                                                    {
                                                        if (campaignObjGoods.GoodsMakerCd == goodsMakerCd)
                                                        {
                                                            this.DetermineDate(ref campaignList, campaignObjGoods, sectionCode, enterpriseCode, applyDateTime, customerCode);
                                                        }
                                                        break;
                                                    }
                                                //5：BLｺｰﾄﾞ
                                                case 5:
                                                    {
                                                        if (campaignObjGoods.BLGoodsCode == blGoodsCode)
                                                        {
                                                            this.DetermineDate(ref campaignList, campaignObjGoods, sectionCode, enterpriseCode, applyDateTime, customerCode);
                                                        }
                                                        break;
                                                    }
                                                //6：販売区分
                                                case 6:
                                                    {
                                                        if (campaignObjGoods.SalesCode == salesCode)
                                                        {
                                                            this.DetermineDate(ref campaignList, campaignObjGoods, sectionCode, enterpriseCode, applyDateTime, customerCode);
                                                        }
                                                        break;
                                                    }
                                            }
                                        }
                                    }
                                }
                                break;
                            }
                        case 4:
                            {
                                if (campaignPrcPrSt.PrioritySettingCd4 != 0)
                                {
                                    foreach (CampaignObjGoodsSt campaignObjGoods in this._campaignObjGoodsStList)
                                    {
                                        if (campaignObjGoods.CampaignSettingKind == campaignPrcPrSt.PrioritySettingCd4)
                                        {
                                            switch (campaignPrcPrSt.PrioritySettingCd4)
                                            {
                                                //1：ﾒｰｶｰ+品番
                                                case 1:
                                                    {
                                                        if (campaignObjGoods.GoodsMakerCd == goodsMakerCd && campaignObjGoods.GoodsNo.Trim() == goodsNo.Trim())
                                                        {
                                                            this.DetermineDate(ref campaignList, campaignObjGoods, sectionCode, enterpriseCode, applyDateTime, customerCode);
                                                        }
                                                        break;
                                                    }
                                                //2：ﾒｰｶｰ+BLｺｰﾄﾞ
                                                case 2:
                                                    {
                                                        if (campaignObjGoods.GoodsMakerCd == goodsMakerCd && campaignObjGoods.BLGoodsCode == blGoodsCode)
                                                        {
                                                            this.DetermineDate(ref campaignList, campaignObjGoods, sectionCode, enterpriseCode, applyDateTime, customerCode);
                                                        }
                                                        break;
                                                    }
                                                //3：ﾒｰｶｰ+ｸﾞﾙｰﾌﾟ
                                                case 3:
                                                    {
                                                        if (campaignObjGoods.GoodsMakerCd == goodsMakerCd && campaignObjGoods.BLGroupCode == blGroupCode)
                                                        {
                                                            this.DetermineDate(ref campaignList, campaignObjGoods, sectionCode, enterpriseCode, applyDateTime, customerCode);
                                                        }
                                                        break;
                                                    }
                                                //4：ﾒｰｶｰ
                                                case 4:
                                                    {
                                                        if (campaignObjGoods.GoodsMakerCd == goodsMakerCd)
                                                        {
                                                            this.DetermineDate(ref campaignList, campaignObjGoods, sectionCode, enterpriseCode, applyDateTime, customerCode);
                                                        }
                                                        break;
                                                    }
                                                //5：BLｺｰﾄﾞ
                                                case 5:
                                                    {
                                                        if (campaignObjGoods.BLGoodsCode == blGoodsCode)
                                                        {
                                                            this.DetermineDate(ref campaignList, campaignObjGoods, sectionCode, enterpriseCode, applyDateTime, customerCode);
                                                        }
                                                        break;
                                                    }
                                                //6：販売区分
                                                case 6:
                                                    {
                                                        if (campaignObjGoods.SalesCode == salesCode)
                                                        {
                                                            this.DetermineDate(ref campaignList, campaignObjGoods, sectionCode, enterpriseCode, applyDateTime, customerCode);
                                                        }
                                                        break;
                                                    }
                                            }
                                        }
                                    }
                                }
                                break;
                            }
                        case 5:
                            {
                                if (campaignPrcPrSt.PrioritySettingCd5 != 0)
                                {
                                    foreach (CampaignObjGoodsSt campaignObjGoods in this._campaignObjGoodsStList)
                                    {
                                        if (campaignObjGoods.CampaignSettingKind == campaignPrcPrSt.PrioritySettingCd5)
                                        {
                                            switch (campaignPrcPrSt.PrioritySettingCd5)
                                            {
                                                //1：ﾒｰｶｰ+品番
                                                case 1:
                                                    {
                                                        if (campaignObjGoods.GoodsMakerCd == goodsMakerCd && campaignObjGoods.GoodsNo.Trim() == goodsNo.Trim())
                                                        {
                                                            this.DetermineDate(ref campaignList, campaignObjGoods, sectionCode, enterpriseCode, applyDateTime, customerCode);
                                                        }
                                                        break;
                                                    }
                                                //2：ﾒｰｶｰ+BLｺｰﾄﾞ
                                                case 2:
                                                    {
                                                        if (campaignObjGoods.GoodsMakerCd == goodsMakerCd && campaignObjGoods.BLGoodsCode == blGoodsCode)
                                                        {
                                                            this.DetermineDate(ref campaignList, campaignObjGoods, sectionCode, enterpriseCode, applyDateTime, customerCode);
                                                        }
                                                        break;
                                                    }
                                                //3：ﾒｰｶｰ+ｸﾞﾙｰﾌﾟ
                                                case 3:
                                                    {
                                                        if (campaignObjGoods.GoodsMakerCd == goodsMakerCd && campaignObjGoods.BLGroupCode == blGroupCode)
                                                        {
                                                            this.DetermineDate(ref campaignList, campaignObjGoods, sectionCode, enterpriseCode, applyDateTime, customerCode);
                                                        }
                                                        break;
                                                    }
                                                //4：ﾒｰｶｰ
                                                case 4:
                                                    {
                                                        if (campaignObjGoods.GoodsMakerCd == goodsMakerCd)
                                                        {
                                                            this.DetermineDate(ref campaignList, campaignObjGoods, sectionCode, enterpriseCode, applyDateTime, customerCode);
                                                        }
                                                        break;
                                                    }
                                                //5：BLｺｰﾄﾞ
                                                case 5:
                                                    {
                                                        if (campaignObjGoods.BLGoodsCode == blGoodsCode)
                                                        {
                                                            this.DetermineDate(ref campaignList, campaignObjGoods, sectionCode, enterpriseCode, applyDateTime, customerCode);
                                                        }
                                                        break;
                                                    }
                                                //6：販売区分
                                                case 6:
                                                    {
                                                        if (campaignObjGoods.SalesCode == salesCode)
                                                        {
                                                            this.DetermineDate(ref campaignList, campaignObjGoods, sectionCode, enterpriseCode, applyDateTime, customerCode);
                                                        }
                                                        break;
                                                    }
                                            }
                                        }
                                    }
                                }
                                break;
                            }
                        case 6:
                            {
                                if (campaignPrcPrSt.PrioritySettingCd6 != 0)
                                {
                                    foreach (CampaignObjGoodsSt campaignObjGoods in this._campaignObjGoodsStList)
                                    {
                                        if (campaignObjGoods.CampaignSettingKind == campaignPrcPrSt.PrioritySettingCd6)
                                        {
                                            switch (campaignPrcPrSt.PrioritySettingCd6)
                                            {
                                                //1：ﾒｰｶｰ+品番
                                                case 1:
                                                    {
                                                        if (campaignObjGoods.GoodsMakerCd == goodsMakerCd && campaignObjGoods.GoodsNo.Trim() == goodsNo.Trim())
                                                        {
                                                            this.DetermineDate(ref campaignList, campaignObjGoods, sectionCode, enterpriseCode, applyDateTime, customerCode);
                                                        }
                                                        break;
                                                    }
                                                //2：ﾒｰｶｰ+BLｺｰﾄﾞ
                                                case 2:
                                                    {
                                                        if (campaignObjGoods.GoodsMakerCd == goodsMakerCd && campaignObjGoods.BLGoodsCode == blGoodsCode)
                                                        {
                                                            this.DetermineDate(ref campaignList, campaignObjGoods, sectionCode, enterpriseCode, applyDateTime, customerCode);
                                                        }
                                                        break;
                                                    }
                                                //3：ﾒｰｶｰ+ｸﾞﾙｰﾌﾟ
                                                case 3:
                                                    {
                                                        if (campaignObjGoods.GoodsMakerCd == goodsMakerCd && campaignObjGoods.BLGroupCode == blGroupCode)
                                                        {
                                                            this.DetermineDate(ref campaignList, campaignObjGoods, sectionCode, enterpriseCode, applyDateTime, customerCode);
                                                        }
                                                        break;
                                                    }
                                                //4：ﾒｰｶｰ
                                                case 4:
                                                    {
                                                        if (campaignObjGoods.GoodsMakerCd == goodsMakerCd)
                                                        {
                                                            this.DetermineDate(ref campaignList, campaignObjGoods, sectionCode, enterpriseCode, applyDateTime, customerCode);
                                                        }
                                                        break;
                                                    }
                                                //5：BLｺｰﾄﾞ
                                                case 5:
                                                    {
                                                        if (campaignObjGoods.BLGoodsCode == blGoodsCode)
                                                        {
                                                            this.DetermineDate(ref campaignList, campaignObjGoods, sectionCode, enterpriseCode, applyDateTime, customerCode);
                                                        }
                                                        break;
                                                    }
                                                //6：販売区分
                                                case 6:
                                                    {
                                                        if (campaignObjGoods.SalesCode == salesCode)
                                                        {
                                                            this.DetermineDate(ref campaignList, campaignObjGoods, sectionCode, enterpriseCode, applyDateTime, customerCode);
                                                        }
                                                        break;
                                                    }
                                            }
                                        }
                                    }
                                }
                                break;
                            }
                    }
                }
            }
            // 未設定時は設定種別区分の昇順とする
            else
            {
                for (int i = 1; i <= 6; i++)
                {
                    if (campaignList.Count > 0)
                    {
                        break;
                    }

                    switch (i)
                    {
                        case 1:
                            {
                                foreach (CampaignObjGoodsSt campaignObjGoods in this._campaignObjGoodsStList)
                                {
                                    //1：ﾒｰｶｰ+品番
                                    if (campaignObjGoods.CampaignSettingKind == 1)
                                    {
                                        if (campaignObjGoods.GoodsMakerCd == goodsMakerCd && campaignObjGoods.GoodsNo.Trim() == goodsNo.Trim())
                                        {
                                            this.DetermineDate(ref campaignList, campaignObjGoods, sectionCode, enterpriseCode, applyDateTime, customerCode);
                                        }
                                    }
                                }
                                break;
                            }
                        case 2:
                            {
                                foreach (CampaignObjGoodsSt campaignObjGoods in this._campaignObjGoodsStList)
                                {
                                    //2：ﾒｰｶｰ+BLｺｰﾄﾞ
                                    if (campaignObjGoods.CampaignSettingKind == 2)
                                    {
                                        if (campaignObjGoods.GoodsMakerCd == goodsMakerCd && campaignObjGoods.BLGoodsCode == blGoodsCode)
                                        {
                                            this.DetermineDate(ref campaignList, campaignObjGoods, sectionCode, enterpriseCode, applyDateTime, customerCode);
                                        }
                                    }
                                }
                                break;
                            }
                        case 3:
                            {
                                foreach (CampaignObjGoodsSt campaignObjGoods in this._campaignObjGoodsStList)
                                {
                                    //3：ﾒｰｶｰ+ｸﾞﾙｰﾌﾟ
                                    if (campaignObjGoods.CampaignSettingKind == 3)
                                    {
                                        if (campaignObjGoods.GoodsMakerCd == goodsMakerCd && campaignObjGoods.BLGroupCode == blGroupCode)
                                        {
                                            this.DetermineDate(ref campaignList, campaignObjGoods, sectionCode, enterpriseCode, applyDateTime, customerCode);
                                        }
                                    }
                                }
                                break;
                            }
                        case 4:
                            {
                                foreach (CampaignObjGoodsSt campaignObjGoods in this._campaignObjGoodsStList)
                                {
                                    //4：ﾒｰｶｰ
                                    if (campaignObjGoods.CampaignSettingKind == 4)
                                    {
                                        if (campaignObjGoods.GoodsMakerCd == goodsMakerCd)
                                        {
                                            this.DetermineDate(ref campaignList, campaignObjGoods, sectionCode, enterpriseCode, applyDateTime, customerCode);
                                        }
                                    }
                                }
                                break;
                            }
                        case 5:
                            {
                                foreach (CampaignObjGoodsSt campaignObjGoods in this._campaignObjGoodsStList)
                                {
                                    //5：BLｺｰﾄﾞ
                                    if (campaignObjGoods.CampaignSettingKind == 5)
                                    {
                                        if (campaignObjGoods.BLGoodsCode == blGoodsCode)
                                        {
                                            this.DetermineDate(ref campaignList, campaignObjGoods, sectionCode, enterpriseCode, applyDateTime, customerCode);
                                        }
                                    }
                                }
                                break;
                            }
                        case 6:
                            {
                                foreach (CampaignObjGoodsSt campaignObjGoods in this._campaignObjGoodsStList)
                                {
                                    //6：販売区分
                                    if (campaignObjGoods.CampaignSettingKind == 6)
                                    {
                                        if (campaignObjGoods.SalesCode == salesCode)
                                        {
                                            this.DetermineDate(ref campaignList, campaignObjGoods, sectionCode, enterpriseCode, applyDateTime, customerCode);
                                        }
                                    }
                                }
                                break;
                            }
                    }
                }
            }

            if (campaignList.Count > 0)
            {
                if (campaignList.Count == 1)
                {
                    readCampaignObjGoodsSt = campaignList[0];
                }
                else
                {
                    bool getFlg1 = false;
                    bool getFlg2 = false;
                    bool getFlg3 = false;
                    foreach (CampaignObjGoodsSt campaignObjGoods in campaignList)
                    {
                        if (campaignObjGoods.SectionCode.Trim() == sectionCode.Trim()
                            && campaignObjGoods.CustomerCode == customerCode)
                        {
                            readCampaignObjGoodsSt = campaignObjGoods;
                            getFlg1 = true;
                            break;
                        }
                        // 拠点コード、得意先コードが一致しない場合「拠点：00、得意先：00000000」を対象とする
                        if (!getFlg1)
                        {
                            if (campaignObjGoods.SectionCode.Trim() == sectionCode.Trim()
                                && campaignObjGoods.CustomerCode == 0)
                            {
                                readCampaignObjGoodsSt = campaignObjGoods;
                                getFlg2 = true;
                            }
                            if (!getFlg2)
                            {
                                if (campaignObjGoods.SectionCode.Trim() == "00"
                                    && campaignObjGoods.CustomerCode == customerCode)
                                {
                                    readCampaignObjGoodsSt = campaignObjGoods;
                                    getFlg3 = true;
                                }
                                if (!getFlg3)
                                {
                                    if (campaignObjGoods.SectionCode.Trim() == "00"
                                        && campaignObjGoods.CustomerCode == 0)
                                    {
                                        readCampaignObjGoodsSt = campaignObjGoods;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            if (readCampaignObjGoodsSt != null)
            {
                if (this._campaignStDic == null || this._campaignStDic.Count == 0)
                {
                    this.LoadCampaignSt();
                }

                if (this._campaignStDic.ContainsKey(readCampaignObjGoodsSt.CampaignCode))
                {
                    CampaignSt campaignSt = this._campaignStDic[readCampaignObjGoodsSt.CampaignCode];
                    if (campaignSt.LogicalDeleteCode == 0)
                    {
                        // 適用日が範囲内か
                        if ((campaignSt.ApplyStaDate > applyDate) ||
                            (campaignSt.ApplyEndDate < applyDate))
                        {
                            // 適用開始日前、または適用終了日後の場合は処理終了
                            readCampaignObjGoodsSt = null;
                            campaignObjGoodsSt = null;

                            _statusOfResult = "適用日が範囲外";

                            return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                        }

                        if (campaignSt.CampaignObjDiv == 0)
                        {
                            // キャンペーン対象区分："全得意先" //なし。
                        }
                        else if (campaignSt.CampaignObjDiv == 1)
                        {
                            // キャンペーン対象区分："対象得意先"
                            ArrayList retList;
                            CampaignLinkAcs campaignLinkAcs = new CampaignLinkAcs();

                            status = campaignLinkAcs.SearchDetail(out retList, enterpriseCode, campaignSt.CampaignCode);

                            // 調査用に保持
                            _usedCampaignLinkList = retList;

                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                // 該当するキャンペーン関連マスタが無いので処理終了
                                readCampaignObjGoodsSt = null;
                                campaignObjGoodsSt = null;

                                _statusOfResult = "該当するキャンペーン関連マスタが無い";

                                return status;
                            }
                            else if ((retList == null) || (retList.Count == 0))
                            {
                                // 検索結果が0件の場合も処理終了
                                readCampaignObjGoodsSt = null;
                                campaignObjGoodsSt = null;

                                _statusOfResult = "キャンペーン関連マスタの検索結果が0件";

                                return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                            }

                            bool searchFlg = false;
                            foreach (CampaignLink campaignLink in retList)
                            {
                                if (campaignLink.LogicalDeleteCode != 0)
                                {
                                    continue;
                                }

                                if (campaignLink.CustomerCode == customerCode)
                                {
                                    // キャンペーン関連の得意先と一致
                                    searchFlg = true;
                                    break;
                                }
                            }

                            if (!searchFlg)
                            {
                                // キャンペーン関連に該当得意先が無いので処理終了
                                readCampaignObjGoodsSt = null;
                                campaignObjGoodsSt = null;

                                _statusOfResult = "キャンペーン関連に該当得意先が無い";

                                return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                            }
                        }
                        else
                        {
                            // キャンペーン対象区分："中止"
                            readCampaignObjGoodsSt = null;
                            campaignObjGoodsSt = null;

                            _statusOfResult = "キャンペーン対象区分：「中止」";

                            return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                        }
                    }
                    else
                    {
                        // 該当するキャンペーンコードが無いので処理終了
                        readCampaignObjGoodsSt = null;
                        campaignObjGoodsSt = null;

                        _statusOfResult = "該当するキャンペーンコードが無い";

                        return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }
                }
                else
                {
                    // 該当するキャンペーンコードが無いので処理終了
                    readCampaignObjGoodsSt = null;
                    campaignObjGoodsSt = null;

                    _statusOfResult = "該当するキャンペーンコードが無い";

                    return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }

            // キャンペーン対象
            if (readCampaignObjGoodsSt != null)
            {
                campaignObjGoodsSt = readCampaignObjGoodsSt.Clone();
            }
            else
            {
                campaignObjGoodsSt = null;
            }

            if (campaignObjGoodsSt.SectionCode.Trim().PadLeft(2, '0') == sectionCode.Trim().PadLeft(2, '0'))
            {
                _statusOfResult = "キャンペーン対象商品設定情報を特定できました。";
            }
            else
            {
                _statusOfResult = "全社設定で再検索";
            }

            return 0;
        }

        /// <summary>
        /// 引数よりキャンペーン売価優先設定マスタ情報を取得。
        /// </summary>
        /// <param name="campaignPrcPrSt">売価優先設定マスタ情報</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 引数よりキャンペーン売価優先設定マスタ情報を取得。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void GetCampaignPrcPrSt(out CampaignPrcPrSt campaignPrcPrSt, string enterpriseCode, string sectionCode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            if (this._campaignPrcPrStAcs == null)
            {
                this._campaignPrcPrStAcs = new CampaignPrcPrStAcs();
            }

            int sectionCd = 0;
            int.TryParse(sectionCode, out sectionCd);
            //2012/04/12 T.Nishi UPD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //status = this._campaignPrcPrStAcs.Read(out campaignPrcPrSt, enterpriseCode, sectionCode);
            CampaignPrcPrSt campaignPrcPrStRead = new CampaignPrcPrSt();
            if (_campaignPrcPrStList == null)
            {
                status = this._campaignPrcPrStAcs.SearchAll(out _campaignPrcPrStList, enterpriseCode);
            }
            foreach (CampaignPrcPrSt campaignPrcPr in this._campaignPrcPrStList)
            {
                // --- ADD 2015/02/12 Y.Wakita Redmine#145 ---------->>>>>
                if (campaignPrcPr.LogicalDeleteCode != 0) continue;
                // --- ADD 2015/02/12 Y.Wakita Redmine#145 ----------<<<<<

                // UPD 2013/02/13 T.Yoshioka 2013/03/06配信予定 SCM障害№10478 キャンペーン障害 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                // if (campaignPrcPr.SectionCode.Trim() == sectionCode)
                if (campaignPrcPr.SectionCode.Trim() == sectionCode.Trim())
                // UPD 2013/02/13 T.Yoshioka 2013/03/06配信予定 SCM障害№10478 キャンペーン障害 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                {
                    campaignPrcPrStRead.PrioritySettingCd1 = campaignPrcPr.PrioritySettingCd1;
                    campaignPrcPrStRead.PrioritySettingCd2 = campaignPrcPr.PrioritySettingCd2;
                    campaignPrcPrStRead.PrioritySettingCd3 = campaignPrcPr.PrioritySettingCd3;
                    campaignPrcPrStRead.PrioritySettingCd4 = campaignPrcPr.PrioritySettingCd4;
                    campaignPrcPrStRead.PrioritySettingCd5 = campaignPrcPr.PrioritySettingCd5;
                    campaignPrcPrStRead.PrioritySettingCd6 = campaignPrcPr.PrioritySettingCd6;
                    break;
                }
                if (campaignPrcPr.SectionCode.Trim() == "00")
                {
                    campaignPrcPrStRead.PrioritySettingCd1 = campaignPrcPr.PrioritySettingCd1;
                    campaignPrcPrStRead.PrioritySettingCd2 = campaignPrcPr.PrioritySettingCd2;
                    campaignPrcPrStRead.PrioritySettingCd3 = campaignPrcPr.PrioritySettingCd3;
                    campaignPrcPrStRead.PrioritySettingCd4 = campaignPrcPr.PrioritySettingCd4;
                    campaignPrcPrStRead.PrioritySettingCd5 = campaignPrcPr.PrioritySettingCd5;
                    campaignPrcPrStRead.PrioritySettingCd6 = campaignPrcPr.PrioritySettingCd6;
                }

            }

            campaignPrcPrSt = campaignPrcPrStRead;
            //2012/04/12 T.Nishi UPD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            if (status == 0)
            {
                if (campaignPrcPrSt != null)
                {
                    if (campaignPrcPrSt.LogicalDeleteCode != 0)
                    {
                        status = -1;
                    }
                }
            }

            if (status == 0)
            {
                if (campaignPrcPrSt != null)
                {
                    if (campaignPrcPrSt.PrioritySettingCd1 == 0
                        && campaignPrcPrSt.PrioritySettingCd2 == 0
                        && campaignPrcPrSt.PrioritySettingCd3 == 0
                        && campaignPrcPrSt.PrioritySettingCd4 == 0
                        && campaignPrcPrSt.PrioritySettingCd5 == 0
                        && campaignPrcPrSt.PrioritySettingCd6 == 0)
                    {
                        campaignPrcPrSt = null;
                    }
                }
                else
                {
                    campaignPrcPrSt = null;
                }
            }
            else
            {
                if (sectionCd != 0)
                {
                    // 引数の拠点に一致するレコードが存在しない場合は、00全社レコードを使用する。
                    campaignPrcPrSt = null;
                    status = this._campaignPrcPrStAcs.Read(out campaignPrcPrSt, enterpriseCode, "00");
                    if (status == 0)
                    {
                        if (campaignPrcPrSt != null)
                        {
                            if (campaignPrcPrSt.LogicalDeleteCode != 0)
                            {
                                campaignPrcPrSt = null;
                                return;
                            }

                            if (campaignPrcPrSt.PrioritySettingCd1 == 0
                                && campaignPrcPrSt.PrioritySettingCd2 == 0
                                && campaignPrcPrSt.PrioritySettingCd3 == 0
                                && campaignPrcPrSt.PrioritySettingCd4 == 0
                                && campaignPrcPrSt.PrioritySettingCd5 == 0
                                && campaignPrcPrSt.PrioritySettingCd6 == 0)
                            {
                                campaignPrcPrSt = null;
                            }
                        }
                        else
                        {
                            campaignPrcPrSt = null;
                        }
                    }
                    else
                    {
                        campaignPrcPrSt = null;
                    }
                }
                else
                {
                    campaignPrcPrSt = null;
                }
            }
        }

        /// <summary>
        /// キャンペーン対象商品設定マスタ複数検索処理（論理削除含まない）キャンペーン対象商品設定マスメン以外用
        /// </summary>
        /// <param name="retList">キャンペーン対象商品設定オブジェクトリスト</param>
        /// <param name="enterpriseCode">enterpriseCode</param>
        /// <param name="logicalMode">logicalMode</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : キャンペーン対象商品設定マスタリストの条件に一致したデータを検索します。論理削除データは抽出対象外</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        public int Search(out List<CampaignObjGoodsSt> retList, string enterpriseCode, ConstantManagement.LogicalMode logicalMode)
        {
            // 検索
            ArrayList retWorkList;
            int status = this.SearchProc(out retWorkList, enterpriseCode, logicalMode);

            // 結果格納
            retList = new List<CampaignObjGoodsSt>();
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && retWorkList != null)
            {
                foreach (object obj in retWorkList)
                {
                    if (obj is CampaignObjGoodsStWork)
                    {
                        CampaignObjGoodsStWork retWork = (obj as CampaignObjGoodsStWork);

                        // 値をセット
                        CampaignObjGoodsSt campaignObjGoodsSt = CopyToCampaignMngFromCampaignMngWork(retWork);
                        retList.Add(campaignObjGoodsSt);
                    }
                }
            }

            if (retList.Count == 0)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            }

            return status;
        }
        /// <summary>
        /// 検索処理メイン（論理削除含む）
        /// </summary>
        /// <param name="retWorkList">読込結果テーブル</param>
        /// <param name="enterpriseCode">enterpriseCode</param>
        /// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : キャンペーン対象商品設定マスタの複数検索処理を行います。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private int SearchProc(out ArrayList retWorkList, string enterpriseCode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retWorkList = null;
            string msg = string.Empty;

            try
            {
                //ArrayList paraList = new ArrayList();
                //==========================================
                // キャンペーン対象商品設定マスタ読み込み
                //==========================================

                // リモート戻りリスト
                object campaignMngWorkList = null;
                // キャンペーン対象商品設定マスタ検索
                status = this._iCampaignObjGoodsStDB.Search(out campaignMngWorkList, enterpriseCode, 0, logicalMode, ref msg);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    retWorkList = (ArrayList)campaignMngWorkList;
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return status;
        }


        /// <summary>
        /// キャンペーン対象商品設定マスタテーブル対象判定
        /// </summary>
        /// <remarks>
        /// <br>Note       : キャンペーン対象商品設定マスタテーブル対象判定。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/04/26</br>
        /// </remarks>
        private void DetermineDate(ref List<CampaignObjGoodsSt> campaignList, CampaignObjGoodsSt campaignObjGoodsSt, string sectionCode, string enterpriseCode, int applyDateTime, int customerCode)
        {
            if (campaignObjGoodsSt.EnterpriseCode.Trim() == enterpriseCode.Trim()
                && campaignObjGoodsSt.SalesPriceSetDiv == 1
                && campaignObjGoodsSt.PriceStartDate <= applyDateTime
                && applyDateTime <= campaignObjGoodsSt.PriceEndDate)
            {
                if (campaignObjGoodsSt.SectionCode.Trim().PadLeft(2, '0') != sectionCode.Trim().PadLeft(2, '0')
                    || campaignObjGoodsSt.CustomerCode != customerCode)
                {
                    if (campaignObjGoodsSt.SectionCode.Trim().PadLeft(2, '0') == "00"
                        && campaignObjGoodsSt.CustomerCode == customerCode)
                    {
                        campaignList.Add(campaignObjGoodsSt);
                    }
                    else if (campaignObjGoodsSt.SectionCode.Trim().PadLeft(2, '0') == sectionCode.Trim().PadLeft(2, '0')
                         && campaignObjGoodsSt.CustomerCode == 0)
                    {
                        campaignList.Add(campaignObjGoodsSt);
                    }
                    else if (campaignObjGoodsSt.SectionCode.Trim().PadLeft(2, '0') == "00"
                        && campaignObjGoodsSt.CustomerCode == 0)
                    {
                        campaignList.Add(campaignObjGoodsSt);
                    }
                }
                else
                {
                    campaignList.Add(campaignObjGoodsSt);
                }
            }
        }
        #endregion

        #endregion
    }
}

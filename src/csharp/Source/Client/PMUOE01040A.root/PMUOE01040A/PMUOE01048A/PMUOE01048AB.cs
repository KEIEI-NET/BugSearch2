//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : 売上・仕入データアクセスクラス
// プログラム概要   : 売上・仕入データアクセスを行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10402071-00 作成担当 : 立花 裕輔
// 作 成 日  2008/05/26  修正内容 : 新規作成
//           2009/07/10  修正内容 : 96186 立花 裕輔 SCM対応
//----------------------------------------------------------------------------//
// 管理番号  10505089-00 作成担当 : 21024 佐々木 健
// 作 成 日  2009/09/24  修正内容 : 車両管理対応（車両備考のセットの追加）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : gaoyh
// 作 成 日  2010/04/27  修正内容 : 受注マスタ（車両）自由検索型式固定番号配列の追加対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30517 夏野 駿希
// 作 成 日  2010/07/05  修正内容 : Mantis.15654　SCMではない得意先で送信処理をした場合でもSCM送信画面が表示されてしまう件の修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21112 久保田 誠
// 作 成 日  2011/05/30  修正内容 : SCM受注データなどのテーブルレイアウト対応
//----------------------------------------------------------------------------//
// 管理番号  XXXXXXXX-00 作成担当 : 長内 数馬
// 作 成 日  2011/10/27  修正内容 : 22008 長内 数馬 伝票明細追加情報セット不具合の修正(伝票印刷順の不具合)
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 高峰
// 作 成 日  2011/10/27  修正内容 : Redmine#26275 UOE仕入データ作成処理　回答データに伝票番号がセットされていないデータについての対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 高峰
// 作 成 日  2011/11/03  修正内容 : Redmine#26394 ＵＯＥ送信処理／売上データの自動入金区分が不正にセットされる件の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30517 夏野 駿希
// 作 成 日  2012/01/16  修正内容 : SCM改良・特記事項対応
//----------------------------------------------------------------------------//
// 管理番号  10707327-00 作成担当 : 鄧潘ハ
// 作 成 日  2012/02/10  修正内容 : 2012/03/28配信分、Redmine#28406 発注送信後のデータ作成不具合についての対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2012/12/06  修正内容 : SCM障害№10447対応
//----------------------------------------------------------------------------//
// 管理番号  10806793-00 作成担当 : 凌小青
// 作 成 日  2013/02/27  修正内容 : 2013/03/13配信分　
//　　　　　　　　　　　　　　　　　Redmine#33797の＃17対応
//----------------------------------------------------------------------------//
// 管理番号  10900269-00 作成担当 : FSI厚川 宏
// 修 正 日  2013/03/21  修正内容 : SPK車台番号文字列対応に伴う国産/外車区分の追加
//----------------------------------------------------------------------------//
// 管理番号  10902175-00 作成担当 : 宮本 利明
// 修 正 日  2013/06/24  修正内容 : タブレット対応
//----------------------------------------------------------------------------//
// 管理番号  10902175-00 作成担当 : 脇田 靖之
// 作 成 日  2013/07/10  修正内容 : 仕掛一覧№2046
//                                  SFから発注でBOが分納で返答された場合、回答が返らない不具合の対応
//----------------------------------------------------------------------------//
// 管理番号  10902175-00 作成担当 : 脇田 靖之
// 作 成 日  2013/07/31  修正内容 : 仕掛一覧№2046
//                                  システムテスト障害対応
//----------------------------------------------------------------------------//
// 管理番号  10902175-00 作成担当 : 脇田 靖之
// 作 成 日  2013/08/02  修正内容 : 仕掛一覧№2046
//                                  システムテスト障害対応 No.24
//----------------------------------------------------------------------------//
// 管理番号  10902175-00 作成担当 : 宮本 利明
// 修 正 日  2013/06/14  修正内容 : システムテスト障害対応
//             ①№46  SCM受注データ(車両情報)の設定項目に入庫予定日・車両管理コードを追加
//             ②№48  SCM受注データの設定項目にタブレット使用区分・車両管理コードを追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 吉岡 
// 作 成 日  2013/10/16  修正内容 : VSS[019](2013/06/18配信) システムテスト障害№52
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 湯上 
// 作 成 日  2013/11/01  修正内容 : 201311xx配信予定分 システムテスト障害№16対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 湯上 
// 作 成 日  2014/06/04  修正内容 : SCM仕掛一覧№10659対応
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 30744 湯上 千加子 
// 作 成 日  2014/12/19  修正内容 : SCM高速化 PMNS対応
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 30744 湯上 千加子 
// 作 成 日  2015/01/30  修正内容 : SCM高速化 生産年式、車台番号対応
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 30745 吉岡
// 修 正 日  2015/02/10  修正内容 : SCM高速化 回答納期区分対応
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 31126 下口
// 修 正 日  2015/02/23  修正内容 : SCM高速化 Ｃ向け種別特記対応
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 30744 湯上
// 修 正 日  2015/07/06  修正内容 : 商品保証課Redmine#4234対応 
//                                  SCM受注データの売上データ生成時、自動回答方式未設定の障害を対応
//                                  受注データよりコピーする処理に項目追加
//----------------------------------------------------------------------------//
// 管理番号  11470007-00 作成担当 : 譚洪
// 修 正 日  2018/04/16  修正内容 : SFからの問合せ・発注のデータに新BLコード、新BLサブコード項目追加
//----------------------------------------------------------------------------//
// 管理番号  11670305-00 作成担当 : 陳艶丹
// 作 成 日  2020/11/20  修正内容 : PMKOBETSU-4097 TSPインライン機能追加対応
//----------------------------------------------------------------------------//
// 管理番号  11670305-00 作成担当 : 呉元嘯
// 作 成 日  2020/12/21  修正内容 : PMKOBETSU-4097 TSPインライン機能追加対応
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Windows.Forms;

using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Windows.Forms;
using System.IO;// ADD 陳艶丹 2020/11/20 PMKOBETSU-4097の対応
using System.Diagnostics;// ADD 陳艶丹 2020/11/20 PMKOBETSU-4097の対応

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 売上・仕入データアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上・仕入データアクセスクラス</br>
    /// <br>Programmer : 96186 立花 裕輔</br>
    /// <br>Date       : 2007.09.10</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2007.09.10 立花 裕輔 新規作成</br>
    /// <br>UpdateNote : 2018/04/16 譚洪</br>
    /// <br>管理番号   : 11470007-00</br>
    /// <br>           : SFからの問合せ・発注のデータに新BLコード、新BLサブコード項目を追加する。</br>
    /// <br>Update Note: 2020/11/20 陳艶丹</br>
    /// <br>管理番号   : 11670305-00</br>
    /// <br>           : PMKOBETSU-4097 TSPインライン機能追加対応</br>
    /// <br>Update Note: 2020/12/21 呉元嘯</br>
    /// <br>管理番号   : 11670305-00</br>
    /// <br>           : PMKOBETSU-4097 TSPインライン機能追加対応</br>
    /// </remarks>
    public partial class UOESalesStockDataAcs
    {
        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region Constructor
        /// <summary>
        /// デフォルトコンストラクタ（Singletonデザインパターンを採用している為、privateとする）
        /// </summary>
        public UOESalesStockDataAcs()
        {
            // 変数初期化
            this._uoeSndRcvCtlInitAcs = UoeSndRcvCtlInitAcs.GetInstance();

            //ＵＯＥ送受信ＪＮＬアクセスクラス
            this._uoeSndRcvJnlAcs = UoeSndRcvJnlAcs.GetInstance();

            this._iIOWriteControlDB = (IIOWriteControlDB)MediationIOWriteControlDB.GetIOWriteControlDB();
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            this._customerInfoAcs = new CustomerInfoAcs();

            // 車輌管理マスタのDictionary
            this._acceptOdrCarDictionary = new Dictionary<string, AcceptOdrCarWork>();

            // 2009/07/10 START >>>>>>
            // SCM受注データのDictionary
            this._sCMAcOdrDataDictionary = new Dictionary<string, SCMAcOdrDataWork>();

            // SCM受注データ（車両情報）のDictionary
            this._sCMAcOdrDtCarDictionary = new Dictionary<string, SCMAcOdrDtCarWork>();

            // SCM受注明細データ（回答）のDictionary
            this._sCMAcOdrDtlAsDictionary = new Dictionary<string, SCMAcOdrDtlAsWork>();
            // 2009/07/10 END   <<<<<<

            // 2010/07/05 Add SCMの得意先がいるか判断 >>>
            this.scmFlg = false;
            // 2010/07/05 Add <<<
        }
        # endregion

        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region Private Members
        private UoeSndRcvCtlInitAcs _uoeSndRcvCtlInitAcs;

        //ＵＯＥ送受信ＪＮＬアクセスクラス
        private UoeSndRcvJnlAcs _uoeSndRcvJnlAcs = null;

        private IIOWriteControlDB _iIOWriteControlDB;
        private string _enterpriseCode;
        private string _loginSectionCode;
        private CustomerInfoAcs _customerInfoAcs;
        private int _supplierSlipDelDiv;

        // 車輌管理マスタのDictionary
        //  受注番号(AcceptAnOrderNo)+受注ステータス(AcptAnOdrStatus)
        private Dictionary<string, AcceptOdrCarWork> _acceptOdrCarDictionary;

        // 2009/07/10 START >>>>>>

        // SCM受注データのDictionary
        //  受注ステータス+売上伝票番号
        private Dictionary<string, SCMAcOdrDataWork> _sCMAcOdrDataDictionary;

        // SCM受注データ（車両情報）のDictionary
        //  受注ステータス+売上伝票番号
        private Dictionary<string, SCMAcOdrDtCarWork> _sCMAcOdrDtCarDictionary;

        // SCM受注明細データ（回答）のDictionary
        //  受注ステータス+売上伝票番号+売上行番号
        private Dictionary<string, SCMAcOdrDtlAsWork> _sCMAcOdrDtlAsDictionary;

        // 2009/07/10 END   <<<<<<

        // 2010/07/05 Add SCMの得意先がいるか判断 >>>
        public bool scmFlg = false;
        // 2010/07/05 Add <<<

        // ---ADD 陳艶丹 2020/11/20 PMKOBETSU-4097の対応 ------>>>>
        // ＵＯＥ送信制御条件クラス
        private UoeSndRcvCtlPara uoeSndRcvCtlPara = null;
        // TSPオプション
        private int opt_TSP;
        // TSP連携マスタ設定
        private ArrayList TspCprtStWorkList = new ArrayList();
        // ---ADD 陳艶丹 2020/11/20 PMKOBETSU-4097の対応 ------<<<<
        # endregion

        // ===================================================================================== //
        // イベント
        // ===================================================================================== //
        # region Events
        # endregion

        // ===================================================================================== //
        // 列挙体
        // ===================================================================================== //
        # region Enums
        /// <summary>
        /// リモート参照用パラメータ設定処理
        /// </summary>
        public enum OptWorkSettingType : int
        {
            /// <summary>登録</summary>
            Write = 0,
            /// <summary>読込</summary>
            Read = 1,
            /// <summary>削除</summary>
            Delete = 2,
        }
        #endregion

        // ===================================================================================== //
        // プロパティ
        // ===================================================================================== //
        # region Properties
        # region 送受信ＪＮＬ＜DataSet＞
        /// <summary>
        /// 送受信ＪＮＬ＜DataSet＞
        /// </summary>
        public DataSet UoeJnlDataSet
        {
            get { return this._uoeSndRcvJnlAcs.UoeJnlDataSet; }
        }
        # endregion

        # region 送受信ＪＮＬ(発注)＜DataTable＞
        /// <summary>
        /// 送受信ＪＮＬ(発注)＜DataTable＞
        /// </summary>
        public DataTable OrderTable
        {
            get { return UoeJnlDataSet.Tables[OrderSndRcvJnlSchema.CT_OrderSndRcvJnlDataTable]; }
        }
        # endregion

        # region 仕入データ＜DataTable＞
        /// <summary>
        /// 仕入データ＜DataTable＞
        /// </summary>
        public DataTable StockSlipTable
        {
            get { return this.UoeJnlDataSet.Tables[StockSlipSchema.CT_StockSlipDataTable]; }
        }
        # endregion

        # region 仕入明細＜DataTable＞
        /// <summary>
        /// 仕入明細＜DataTable＞
        /// </summary>
        public DataTable StockDetailTable
        {
            get { return this.UoeJnlDataSet.Tables[StockDetailSchema.CT_StockDetailDataTable]; }
        }
        # endregion

        # region 売上データ＜DataTable＞
        /// <summary>
        /// 売上データ＜DataTable＞
        /// </summary>
        public DataTable SalesSlipTable
        {
            get { return this.UoeJnlDataSet.Tables[SalesSlipSchema.CT_SalesSlipDataTable]; }
        }
        # endregion

        # region 売上明細＜DataTable＞
        /// <summary>
        /// 売上明細＜DataTable＞
        /// </summary>
        public DataTable SalesDetailTable
        {
            get { return this.UoeJnlDataSet.Tables[SalesDetailSchema.CT_SalesDetailDataTable]; }
        }
        # endregion

        # region 受注データ＜DataTable＞
        /// <summary>
        /// 受注データ＜DataTable＞
        /// </summary>
        public DataTable AcptSlipTable
        {
            get { return this.UoeJnlDataSet.Tables[SalesSlipSchema.CT_AcptSlipDataTable]; }
        }
        # endregion

        # region 受注明細＜DataTable＞
        /// <summary>
        /// 受注明細＜DataTable＞
        /// </summary>
        public DataTable AcptDetailTable
        {
            get { return this.UoeJnlDataSet.Tables[SalesDetailSchema.CT_AcptDetailDataTable]; }
        }
        # endregion

        # region Uoe仕入データ＜DataTable＞
        /// <summary>
        /// Uoe仕入データ＜DataTable＞
        /// </summary>
        public DataTable UoeStockSlipTable
        {
            get { return this.UoeJnlDataSet.Tables[StockSlipSchema.CT_UoeStockSlipDataTable]; }
        }
        # endregion

        # region Uoe仕入明細＜DataTable＞
        /// <summary>
        /// Uoe仕入明細＜DataTable＞
        /// </summary>
        public DataTable UoeStockDetailTable
        {
            get { return this.UoeJnlDataSet.Tables[StockDetailSchema.CT_UoeStockDetailDataTable]; }
        }
        # endregion

        # region 仕入伝票削除区分
        /// <summary>仕入伝票削除区分</summary>
        public int SupplierSlipDelDiv
        {
            set { this._supplierSlipDelDiv = value; }
            get { return this._supplierSlipDelDiv; }
        }
        # endregion

        // ---ADD 陳艶丹 2020/11/20 PMKOBETSU-4097の対応 ------>>>>
        /// <summary>ＵＯＥ送信制御条件</summary>
        public UoeSndRcvCtlPara UoeSndRcvCtlPara
        {
            set { this.uoeSndRcvCtlPara = value; }
            get { return this.uoeSndRcvCtlPara; }
        }

        /// <summary>
        /// TSPオプション
        /// </summary>
        public int Opt_TSP
        {
            get { return this.opt_TSP; }
            set { this.opt_TSP = value; }
        }
        // ---ADD 陳艶丹 2020/11/20 PMKOBETSU-4097の対応 ------<<<<
        # endregion

        // ===================================================================================== //
        // DBデータアクセス処理
        // ===================================================================================== //
        # region DataBase Access Methods
        # region ●売上仕入情報データセット
        # region 売上情報データセット
        /// <summary>
        /// 売上情報データセット
        /// </summary>
        /// <param name="paraList">売上情報データセット</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        /// <br>Update Note: 2013/02/27 凌小青</br>
        /// <br>            Redmine#33797の＃17対応</br>
        private int GetSsalesDBPara(ref CustomSerializeArrayList paraList, out string message)
        {
            //------------------------------------------------------------------------------------
            // データセット方法
            //------------------------------------------------------------------------------------
            //      --CustomSerializeArrayList      売上リスト
            //          --SalesSlipWork             売上データオブジェクト
            //          --ArrayList                 売上明細リスト
            //              --SalesDetailWork       売上明細データオブジェクト
            //          --DepsitDataWork            入金データオブジェクト
            //          --DepositAlwWork            入金引当データオブジェクト
            //          --ArrayList                 伝票明細追加情報リスト
            //              --SlipDetailAddInfoWork 伝票明細追加情報オブジェクト
            // 2009/07/10 START >>>>>>
            //          --SCMAcOdrDataWork          SCM受注データ
            //          --SCMAcOdrDtCarWork         SCM受注データ（車両情報）リスト
            //          --ArrayList<SCMAcOdrDtlAsWork>  SCM受注明細データ（回答）リスト
            // 2009/07/10 END   <<<<<<
            //------------------------------------------------------------------------------------
            int status = (int)EnumUoeConst.Status.ct_NORMAL;
            message = String.Empty;
            
            try
            {
                //-----------------------------------------------------------
                // 売上データDataViewの作成
                //-----------------------------------------------------------
                # region 売上データDataViewの作成
                Int32 acptAnOdrStatus = 30;   //10:見積,20:受注,30:売上,40:出荷（受注ステータス）

                string rowFilterText = "";
                // UOE自社設定ﾏｽﾀのﾒｰｶｰﾌｫﾛｰ計上区分が受注の場合には、ＥＯ伝票・メーカーフォロー伝票対象外
                if (_uoeSndRcvJnlAcs.uOESetting.MakerFollowAddUpDiv != (int)EnumUoeConst.ctMakerFollowAddUpDiv.ct_Order)
                {
                    rowFilterText = string.Format("{0} = {1} AND {2} <> {3} AND {4} <> {5}",
                                                    SalesSlipSchema.ct_Col_AcptAnOdrStatus, acptAnOdrStatus,
                                                    SalesSlipSchema.ct_Col_TotalCnt, 0,
                                                    SalesSlipSchema.ct_Col_SlipCd, (int)UoeSales.ctSlipCd.ct_Zero);
                }
                else
                {
                    rowFilterText = string.Format("{0} = {1} AND {2} <> {3} AND {4} <> {5} AND {6} <> {7} AND {8} <> {9}",
                                                    SalesSlipSchema.ct_Col_AcptAnOdrStatus, acptAnOdrStatus,
                                                    SalesSlipSchema.ct_Col_TotalCnt, 0,
                                                    SalesSlipSchema.ct_Col_SlipCd, (int)UoeSales.ctSlipCd.ct_EO,
                                                    SalesSlipSchema.ct_Col_SlipCd, (int)UoeSales.ctSlipCd.ct_Maker,
                                                    SalesSlipSchema.ct_Col_SlipCd, (int)UoeSales.ctSlipCd.ct_Zero);
                }

                string sortText = string.Format("{0}, {1}",
                                                SalesSlipSchema.ct_Col_AcptAnOdrStatus,
                                                SalesSlipSchema.ct_Col_TempSalesSlipNum);
                DataView viewSalesSlip = new DataView(SalesSlipTable);
                viewSalesSlip.Sort = sortText;
                viewSalesSlip.RowFilter = rowFilterText;

                if (viewSalesSlip == null) return (status);
                if (viewSalesSlip.Count == 0) return (status);
                # endregion

                int slipDtlRegOrder = 0;    //伝票・明細の登録順位を設定  // ADD 2011/10/27
                // --- ADD 2013/07/31 Y.Wakita ---------->>>>>
                int viewSalesSlipCnt = viewSalesSlip.Count;
                bool divisionFlg = false; // 分納無し

                // UOE自社マスタ設定：伝票出力形態が「3:確認伝票・ﾌｫﾛｰ伝票(合算）」「6:確認伝票(ｾﾞﾛ明細印字なし)・ﾌｫﾛｰ伝票（合算）」以外
                if (!((_uoeSndRcvJnlAcs.uOESetting.SlipOutputDivCd == 3) || (_uoeSndRcvJnlAcs.uOESetting.SlipOutputDivCd == 6)))
                {
                    foreach (DataRowView rowUoeSalesSlip in viewSalesSlip)
                    {
                        // 拠点があるか判定
                        string tempSalesSlipNum = (string)rowUoeSalesSlip[SalesSlipSchema.ct_Col_TempSalesSlipNum];
                        string tempSalesSlipNumKey = tempSalesSlipNum.Substring(tempSalesSlipNum.Length - 1);
                        if (tempSalesSlipNumKey == "0")
                        {
                            divisionFlg = true; // 分納有り
                        }
                    }
                }
                // --- ADD 2013/07/31 Y.Wakita ----------<<<<<
                foreach (DataRowView rowUoeSalesSlip in viewSalesSlip)
                {
                    string tempSalesSlipNum = (string)rowUoeSalesSlip[SalesSlipSchema.ct_Col_TempSalesSlipNum];
                    // --- ADD 2013/07/10 Y.Wakita ---------->>>>>
                    string tempSalesSlipNumKey = tempSalesSlipNum.Substring(tempSalesSlipNum.Length - 1);
                    // --- ADD 2013/07/10 Y.Wakita ----------<<<<<

                    //-----------------------------------------------------------
                    // 売上データクラスの取得
                    //-----------------------------------------------------------
                    # region 売上データクラスの取得
                    SalesSlipWork salesSlipWork = _uoeSndRcvJnlAcs.CreateSalesSlipWorkFromSchema(rowUoeSalesSlip.Row);
                    # endregion

                    //------------------------------------------------------
                    // 売上明細データに行番号を設定
                    //------------------------------------------------------
                    # region 売上明細データに行番号を設定
                    _uoeSndRcvJnlAcs.SetRowNoFromSalesDetail(
                                                    salesSlipWork.AcptAnOdrStatus,
                                                    tempSalesSlipNum,
                                                    1,
                                                    out message
                                                    );
                    # endregion

                    //-----------------------------------------------------------
                    // 売上明細クラスの取得
                    //-----------------------------------------------------------
                    # region 売上明細クラスの取得
                    ArrayList salesDetailWorkAry = _uoeSndRcvJnlAcs.SearchSalesDetailDataTable(
                                                    SalesDetailTable,
                                                    salesSlipWork.AcptAnOdrStatus,
                                                    tempSalesSlipNum,
                                                    1
                                                    );
                    if (salesDetailWorkAry == null) continue;
                    if (salesDetailWorkAry.Count == 0) continue;

                    salesSlipWork.DetailRowCount = salesDetailWorkAry.Count;    //売上データクラスの明細行数を設定
                    # endregion

                    //-----------------------------------------------------------
                    // 伝票明細追加情報の作成
                    //-----------------------------------------------------------
                    # region 伝票明細追加情報の作成
                    long depositAllowance = 0;  //入金引当額
                    //int slipDtlRegOrder = 0;    //伝票・明細の登録順位を設定  // DEL 2011/10/27

                    ArrayList slipDetailAddInfoWorkAry = new ArrayList();
                    ArrayList carManagementWorkAry = new ArrayList();

                    foreach (SalesDetailWork salesDetailWork in salesDetailWorkAry)
                    {
                        CarManagementWork carManagementWork = null;
                        Guid guid = GetCarManagementWork(salesDetailWork.AcceptAnOrderNo, 20, out carManagementWork);

                        if (carManagementWork != null)
                        {
                            carManagementWorkAry.Add(carManagementWork);
                        }

                        slipDtlRegOrder++;
                        SlipDetailAddInfoWork slipDetailAddInfoWork = new SlipDetailAddInfoWork();

                        slipDetailAddInfoWork.DtlRelationGuid = salesDetailWork.DtlRelationGuid;
                        slipDetailAddInfoWork.GoodsEntryDiv = 0;
                        slipDetailAddInfoWork.GoodsOfferDate = DateTime.MinValue;
                        slipDetailAddInfoWork.PriceUpdateDiv = 0;
                        slipDetailAddInfoWork.PriceStartDate = DateTime.MinValue;
                        slipDetailAddInfoWork.PriceOfferDate = DateTime.MinValue;
                        slipDetailAddInfoWork.CarRelationGuid = guid;
                        slipDetailAddInfoWork.SlipDtlRegOrder = slipDtlRegOrder;
                        slipDetailAddInfoWork.AddUpRemDiv = 0;

                        slipDetailAddInfoWorkAry.Add(slipDetailAddInfoWork);

                        //入金引当額の算出
                        //depositAllowance += slipDetailAddInfoWork.SalesMoneyTaxInc;
                    }
                    # endregion

                    //入金データの作成
                    //売上全体設定ﾏｽﾀの自動入金区分が"1:する"の場合に入金ﾃﾞｰﾀの作成を行う
                    //受注ﾃﾞｰﾀ上の伝票区分が現金売上時、
                    DepsitDataWork depsitDataWork = new DepsitDataWork();
                    DepositAlwWork depositAlwWork = new DepositAlwWork();

                    //-----------------------------------------------------------
                    // 対象金額算出
                    //-----------------------------------------------------------
                    long totalPrice = salesSlipWork.SalesTotalTaxInc;
                    if (salesSlipWork.TotalAmountDispWayCd == (int)SalesSlipInputAcs.TotalAmountDispWayCd.NoTotalAmount)
                    {
                        // 総額表示しない
                        switch (salesSlipWork.ConsTaxLayMethod)
                        {
                            case 0: // 伝票転嫁
                            case 1: // 明細転嫁
                                break;
                            case 2: // 請求親
                            case 3: // 請求子
                            case 9: // 非課税
                                // 総合計
                                totalPrice = salesSlipWork.ItdedSalesInTax + salesSlipWork.ItdedSalesOutTax + salesSlipWork.SalSubttlSubToTaxFre +
                                             salesSlipWork.ItdedSalesDisOutTax + salesSlipWork.ItdedSalesDisInTax + salesSlipWork.ItdedSalesDisTaxFre +
                                             salesSlipWork.SalAmntConsTaxInclu + salesSlipWork.SalesDisTtlTaxInclu;
                                break;
                        }
                    }

                    //-----------------------------------------------------------
                    // 売上データの設定
                    //-----------------------------------------------------------
                    # region 売上データの設定
                    //salesSlipWork.AutoDepositCd = (int)EnumUoeConst.ctAutoDepositCd.ct_Yes; // DEL 2011/11/03
                    salesSlipWork.AutoDepositCd = _uoeSndRcvJnlAcs.salesTtlSt.AutoDepositCd; // ADD 2011/11/03
                    salesSlipWork.DepositAlwcBlnce = totalPrice; // 入金引当残高
                    salesSlipWork.DepositAllowanceTtl = 0; // 入金引当合計額
                    salesSlipWork.AutoDepositNoteDiv = _uoeSndRcvJnlAcs.salesTtlSt.AutoDepositNoteDiv;// 自動入金備考区分(0:売上伝票番号 1:売上伝票備考 2:無し) // ADD BY 凌小青 on 2013/02/27  Redmine#33797の＃17対応
                    # endregion

                    // 2009/07/10 START >>>>>>
                    //-----------------------------------------------------------
                    // 受注情報の取得
                    //-----------------------------------------------------------
                    # region 受注情報の取得
                    // 受注明細データの取得
                    SalesDetailWork salesDetailTemp = (SalesDetailWork)salesDetailWorkAry[0];
                    SalesDetailWork acptDetailWork = _uoeSndRcvJnlAcs.ReadSalesDetailDataTable(
                                                            salesDetailTemp.AcptAnOdrStatusSrc,
                                                            salesDetailTemp.SalesSlipDtlNumSrc);

                    // 受注データの取得
                    SalesSlipWork acptSlipWork = _uoeSndRcvJnlAcs.ReadAcptSlipDataTable(
                                                            acptDetailWork.AcptAnOdrStatus,
                                                            acptDetailWork.SalesSlipNum);

                    int scmAcptAnOdrStatus = acptSlipWork.AcptAnOdrStatus;
                    string scmSalesSlipNum = acptSlipWork.SalesSlipNum;
                    # endregion

                    //-----------------------------------------------------------
                    // SCM受注データ の設定
                    //-----------------------------------------------------------
                    # region SCM受注データの設定
                    //SCMAcOdrDataWork sCMAcOdrDataWork = GetSCMAcOdrDataWork(scmAcptAnOdrStatus, scmSalesSlipNum);              //DEL 2011/05/30
                    SCMAcOdrDataWork sCMAcOdrDataWork = GetSCMAcOdrDataWork(scmAcptAnOdrStatus, scmSalesSlipNum, acptSlipWork);  //ADD 2011/05/30

                    // DEL 2013/11/01 201311xx配信予定分 システムテスト障害№16対応 -------------------------------->>>>>
                    //// ADD 2013/10/16 吉岡 2013/99/99配信 VSS[019] システムテスト障害一覧 №52 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                    //// SCM受注データ 金額の補正
                    //sCMAcOdrDataWork.SalesTotalTaxInc = salesSlipWork.SalesTotalTaxInc;
                    //sCMAcOdrDataWork.SalesSubtotalTax = salesSlipWork.SalesSubtotalTax;
                    //// ADD 2013/10/16 吉岡 2013/99/99配信 VSS[019] システムテスト障害一覧 №52 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                    // DEL 2013/11/01 201311xx配信予定分 システムテスト障害№16対応 --------------------------------<<<<<

                    // --- DEL 2013/07/31 Y.Wakita ---------->>>>>
                    //// --- ADD 2013/07/10 Y.Wakita ---------->>>>>
                    //if ((sCMAcOdrDataWork.InquiryNumber != 0) && (tempSalesSlipNumKey != "0"))
                    //{
                    //    sCMAcOdrDataWork.InquiryNumber = 0;
                    //}
                    //// --- ADD 2013/07/10 Y.Wakita ----------<<<<<
                    // --- DEL 2013/07/31 Y.Wakita ----------<<<<<

                    // --- ADD 2013/08/02 Y.Wakita ---------->>>>>
                    if (sCMAcOdrDataWork != null)
                    {
                    // --- ADD 2013/08/02 Y.Wakita ----------<<<<<
                        // ADD 2013/11/01 201311xx配信予定分 システムテスト障害№16対応 -------------------------------->>>>>
                        // SCM受注データ 金額の補正
                        sCMAcOdrDataWork.SalesTotalTaxInc = salesSlipWork.SalesTotalTaxInc;
                        sCMAcOdrDataWork.SalesSubtotalTax = salesSlipWork.SalesSubtotalTax;
                        // ADD 2013/11/01 201311xx配信予定分 システムテスト障害№16対応 --------------------------------<<<<<
                        // --- ADD 2013/07/31 Y.Wakita ---------->>>>>
                        // UOE自社マスタ設定：伝票出力形態が「3:確認伝票・ﾌｫﾛｰ伝票(合算）」「6:確認伝票(ｾﾞﾛ明細印字なし)・ﾌｫﾛｰ伝票（合算）」以外
                        if (!((_uoeSndRcvJnlAcs.uOESetting.SlipOutputDivCd == 3) || (_uoeSndRcvJnlAcs.uOESetting.SlipOutputDivCd == 6)))
                        {
                            if ((sCMAcOdrDataWork.InquiryNumber != 0) && (tempSalesSlipNumKey != "0") && (1 != viewSalesSlipCnt) && (divisionFlg))
                            {
                                sCMAcOdrDataWork.InquiryNumber = 0;
                            }
                        }
                        // --- ADD 2013/07/31 Y.Wakita ----------<<<<<
                    // --- ADD 2013/08/02 Y.Wakita ---------->>>>>
                    }
                    // --- ADD 2013/08/02 Y.Wakita ----------<<<<<
                    # endregion

                    //-----------------------------------------------------------
                    // SCM受注データ（車両情報） の設定
                    //-----------------------------------------------------------
                    # region SCM受注データ（車両情報）の設定
                    SCMAcOdrDtCarWork sCMAcOdrDtCarWork = GetSCMAcOdrDtCarWork(scmAcptAnOdrStatus, scmSalesSlipNum);
                    // --- DEL 2013/07/31 Y.Wakita ---------->>>>>
                    //// --- ADD 2013/07/10 Y.Wakita ---------->>>>>
                    //if ((sCMAcOdrDtCarWork.InquiryNumber != 0) && (tempSalesSlipNumKey != "0"))
                    //{
                    //    sCMAcOdrDtCarWork.InquiryNumber = 0;
                    //}
                    //// --- ADD 2013/07/10 Y.Wakita ----------<<<<<
                    // --- DEL 2013/07/31 Y.Wakita ----------<<<<<

                    // --- ADD 2013/08/02 Y.Wakita ---------->>>>>
                    if (sCMAcOdrDtCarWork != null)
                    {
                    // --- ADD 2013/08/02 Y.Wakita ----------<<<<<
                        // --- ADD 2013/07/31 Y.Wakita ---------->>>>>
                        // UOE自社マスタ設定：伝票出力形態が「3:確認伝票・ﾌｫﾛｰ伝票(合算）」「6:確認伝票(ｾﾞﾛ明細印字なし)・ﾌｫﾛｰ伝票（合算）」以外
                        if (!((_uoeSndRcvJnlAcs.uOESetting.SlipOutputDivCd == 3) || (_uoeSndRcvJnlAcs.uOESetting.SlipOutputDivCd == 6)))
                        {
                            if ((sCMAcOdrDtCarWork.InquiryNumber != 0) && (tempSalesSlipNumKey != "0") && (1 != viewSalesSlipCnt) && (divisionFlg))
                            {
                                sCMAcOdrDtCarWork.InquiryNumber = 0;
                            }
                        }
                        // --- ADD 2013/07/31 Y.Wakita ----------<<<<<
                    // --- ADD 2013/08/02 Y.Wakita ---------->>>>>
                    }
                    // --- ADD 2013/08/02 Y.Wakita ----------<<<<<
                    # endregion

                    //-----------------------------------------------------------
                    // SCM受注明細データ（回答） の設定
                    //-----------------------------------------------------------
                    # region SCM受注明細データ（回答） の設定
                    ArrayList sCMAcOdrDtlAsWorkAry = new ArrayList();
                    foreach (SalesDetailWork salesDetailWork in salesDetailWorkAry)
                    {
                        // 受注明細データの取得
                        SalesDetailWork acptDetailTemp = _uoeSndRcvJnlAcs.ReadSalesDetailDataTable(
                                                                salesDetailWork.AcptAnOdrStatusSrc,
                                                                salesDetailWork.SalesSlipDtlNumSrc);

                        SCMAcOdrDtlAsWork sCMAcOdrDtlAsWork = GetSCMAcOdrDtlAsWork(scmAcptAnOdrStatus, scmSalesSlipNum, acptDetailTemp.SalesRowNo, salesDetailWork);
                        if (sCMAcOdrDtlAsWork == null) continue;

                        // --- DEL 2013/07/31 Y.Wakita ---------->>>>>
                        //// --- ADD 2013/07/10 Y.Wakita ---------->>>>>
                        //if ((sCMAcOdrDtlAsWork.InquiryNumber != 0) && (tempSalesSlipNumKey != "0"))
                        //{
                        //    sCMAcOdrDtlAsWork.InquiryNumber = 0;
                        //    sCMAcOdrDtlAsWork.InqRowNumber = sCMAcOdrDtlAsWork.InqRowNumber * -1;
                        //}
                        //// --- ADD 2013/07/10 Y.Wakita ----------<<<<<
                        // --- DEL 2013/07/31 Y.Wakita ----------<<<<<

                        // --- ADD 2013/08/02 Y.Wakita ---------->>>>>
                        if (sCMAcOdrDtlAsWork != null)
                        {
                        // --- ADD 2013/08/02 Y.Wakita ----------<<<<<
                            // --- ADD 2013/07/31 Y.Wakita ---------->>>>>
                            // UOE自社マスタ設定：伝票出力形態が「3:確認伝票・ﾌｫﾛｰ伝票(合算）」「6:確認伝票(ｾﾞﾛ明細印字なし)・ﾌｫﾛｰ伝票（合算）」以外
                            if (!((_uoeSndRcvJnlAcs.uOESetting.SlipOutputDivCd == 3) || (_uoeSndRcvJnlAcs.uOESetting.SlipOutputDivCd == 6)))
                            {
                                if ((sCMAcOdrDtlAsWork.InquiryNumber != 0) && (tempSalesSlipNumKey != "0") && (1 != viewSalesSlipCnt) && (divisionFlg))
                                {
                                    sCMAcOdrDtlAsWork.InquiryNumber = 0;
                                    sCMAcOdrDtlAsWork.InqRowNumber = sCMAcOdrDtlAsWork.InqRowNumber * -1;
                                }
                            }
                            // --- ADD 2013/07/31 Y.Wakita ----------<<<<<
                        // --- ADD 2013/08/02 Y.Wakita ---------->>>>>
                        }
                        // --- ADD 2013/08/02 Y.Wakita ----------<<<<<

                        sCMAcOdrDtlAsWorkAry.Add(sCMAcOdrDtlAsWork);
                    }
                    # endregion
                    // 2009/07/10 END   <<<<<<

                    if((_uoeSndRcvJnlAcs.salesTtlSt.AutoDepositCd == (int)EnumUoeConst.ctAutoDepositCd.ct_Yes)
                    && (salesSlipWork.AccRecDivCd == 0))
                    {
                        //-----------------------------------------------------------
                        // 入金データの作成
                        //-----------------------------------------------------------
                        # region 入金データの作成
                        # region 請求先情報取得
                        // 請求先情報取得
                        CustomerInfo claim;
                        status = this._customerInfoAcs.ReadDBData(
                                                            this._enterpriseCode,
                                                            salesSlipWork.ClaimCode,
                                                            true,
                                                            out claim);
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            claim = new CustomerInfo();
                        }
                        # endregion

                        //入金データの作成
                        depsitDataWork.ClaimName = claim.Name;      //請求先名称
                        depsitDataWork.ClaimName2 = claim.Name2;    //請求先名称2
                        depsitDataWork.DepositRowNo1 = 1;           //入金行番号１
                        depsitDataWork.MoneyKindCode1 = this._uoeSndRcvCtlInitAcs.GetSalesTtlSt().AutoDepoKindCode; //金種コード１(現金 限定)
                        depsitDataWork.MoneyKindName1 = this._uoeSndRcvCtlInitAcs.GetSalesTtlSt().AutoDepoKindName; //金種名称１
                        depsitDataWork.MoneyKindDiv1 = this._uoeSndRcvCtlInitAcs.GetSalesTtlSt().AutoDepoKindDivCd; //金種区分１
                        # endregion

                        //-----------------------------------------------------------
                        // 入金引当データの作成
                        //-----------------------------------------------------------
                        # region 入金引当データの作成
                        //入金引当データの作成
                        depositAlwWork.InputDepositSecCd = salesSlipWork.SalesInpSecCd;     //入金入力拠点コード
                        depositAlwWork.AddUpSecCode = _loginSectionCode;                    //計上拠点コード
                        depositAlwWork.AcptAnOdrStatus = 30;                                //受注ステータス
                        depositAlwWork.SalesSlipNum = String.Empty;                         //売上伝票番号
                        depositAlwWork.ReconcileDate = DateTime.Now;                        //消込み日
                        depositAlwWork.ReconcileAddUpDate = salesSlipWork.SalesDate;        //消込み計上日
                        depositAlwWork.DepositSlipNo = 0;                                   //入金伝票番号
                        depositAlwWork.DepositAllowance = depositAllowance;                 //入金引当額
                        depositAlwWork.DepositAgentCode = salesSlipWork.SalesEmployeeCd;    //入金担当者コード
                        depositAlwWork.DepositAgentNm = salesSlipWork.SalesEmployeeNm;      //入金担当者コード
                        depositAlwWork.CustomerCode = salesSlipWork.CustomerCode;           //得意先コード
                        depositAlwWork.CustomerName = salesSlipWork.CustomerName;           //得意先名称
                        depositAlwWork.CustomerName2 = salesSlipWork.CustomerName2;         //得意先名称2
                        depositAlwWork.DebitNoteOffSetCd = 0;                               //赤伝相殺区分
                        # endregion
                    }
                    //-----------------------------------------------------------
                    // 売上グループクラスの作成
                    //-----------------------------------------------------------
                    # region 売上グループクラスの作成
                    CustomSerializeArrayList grpAry = new CustomSerializeArrayList();
                    grpAry.Add(salesSlipWork);
                    grpAry.Add(salesDetailWorkAry);

                    if ((_uoeSndRcvJnlAcs.salesTtlSt.AutoDepositCd == (int)EnumUoeConst.ctAutoDepositCd.ct_Yes)
                    &&  (salesSlipWork.AccRecDivCd == 0))
                    {
                        grpAry.Add(depsitDataWork);
                        grpAry.Add(depositAlwWork);
                    }

                    grpAry.Add(slipDetailAddInfoWorkAry);

                    if (carManagementWorkAry.Count > 0)
                    {
                        grpAry.Add(carManagementWorkAry);
                    }

                    // 2009/07/10 START >>>>>>
                    // SCM受注データ
                    if (sCMAcOdrDataWork != null)
                    {
                        grpAry.Add(sCMAcOdrDataWork);
                    }

                    // SCM受注データ（車両情報）
                    if (sCMAcOdrDtCarWork != null)
                    {
                        grpAry.Add(sCMAcOdrDtCarWork);
                    }

                    // SCM受注明細データ（回答）リスト
                    if (sCMAcOdrDtlAsWorkAry != null)
                    {
                        if (sCMAcOdrDtlAsWorkAry.Count > 0)
                        {
                            grpAry.Add(sCMAcOdrDtlAsWorkAry);
                        }
                    }
                    // 2009/07/10 END   <<<<<<

                    paraList.Add(grpAry);
                    # endregion
                }
            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
            }
            return (status);

        }
        # endregion

        # region 仕入情報データセット
        /// <summary>
        /// 仕入情報データセット
        /// </summary>
        /// <param name="paraList">売上情報データセット</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        /// <br>UpdateNote : 2011/10/29 高峰 Redmine#26275 UOE仕入データ作成処理　回答データに伝票番号がセットされていないデータについて</br>
        private int GetStockDBPara(ref CustomSerializeArrayList paraList, out string message)
        {
            //------------------------------------------------------------------------------------
            // データセット方法
            //------------------------------------------------------------------------------------
            //      --CustomSerializeArrayList      仕入リスト
            //          --StockSlipWork             仕入データオブジェクト
            //          --ArrayList                 仕入明細リスト
            //              --StockDetailWork       仕入明細データオブジェクト
            //          --ArrayList                 伝票明細追加情報リスト
            //              --SlipDetailAddInfoWork 伝票明細追加情報オブジェクト
            //------------------------------------------------------------------------------------
            int status = (int)EnumUoeConst.Status.ct_NORMAL;
            message = String.Empty;

            try
            {
                //-----------------------------------------------------------
                // 仕入データDataViewの作成
                //-----------------------------------------------------------
                # region 仕入データDataViewの作成
                Int32 supplierFormal = 0;   //0:仕入,1:入荷,2:発注　（受注ステータス）
                string rowFilterText = string.Format("{0} = {1}",
                                                StockSlipSchema.ct_Col_SupplierFormal, supplierFormal);
                string sortText = string.Format("{0}, {1}",
                                                StockSlipSchema.ct_Col_SupplierFormal,
                                                StockSlipSchema.ct_Col_CommonSlipNo
                                                );
                DataView viewUoeStockSlip = new DataView(UoeStockSlipTable);
                viewUoeStockSlip.Sort = sortText;
                viewUoeStockSlip.RowFilter = rowFilterText;

                if (viewUoeStockSlip == null) return (status);
                if (viewUoeStockSlip.Count == 0) return (status);
                # endregion

                int slipDtlRegOrder = 0;    //伝票・明細の登録順位を設定  // ADD 2011/10/27

                foreach (DataRowView rowUoeStockSlip in viewUoeStockSlip)
                {
                    //-----------------------------------------------------------
                    // 仕入データクラスの取得
                    //-----------------------------------------------------------
                    # region 仕入データクラスの取得
                    StockSlipWork stockSlipWork = _uoeSndRcvJnlAcs.CreateStockSlipWorkFromSchema(rowUoeStockSlip.Row);
                    # endregion

                    //-----------------------------------------------------------
                    // 仕入明細クラスの取得
                    //-----------------------------------------------------------
                    # region 仕入明細クラスの取得
                    string commonSlipNo = (string)rowUoeStockSlip[StockSlipSchema.ct_Col_CommonSlipNo];
                    ArrayList stockDetailWorkAry = _uoeSndRcvJnlAcs.SearchStockDetailDataTable(
                                                    UoeStockDetailTable,
                                                    stockSlipWork.SupplierFormal,
                                                    commonSlipNo);
                    if (stockDetailWorkAry == null) continue;
                    if (stockDetailWorkAry.Count == 0) continue;
                    # endregion

                    //-----------------------------------------------------------
                    // 伝票明細追加情報の作成
                    //-----------------------------------------------------------
                    # region 伝票明細追加情報の作成
                    //int slipDtlRegOrder = 0;    //伝票・明細の登録順位を設定  // DEL 2011/10/27
                    ArrayList slipDetailAddInfoWorkAry = new ArrayList();

                    foreach(StockDetailWork stockDetailWork in stockDetailWorkAry)
                    {
                        slipDtlRegOrder++;
                        SlipDetailAddInfoWork slipDetailAddInfoWork = new SlipDetailAddInfoWork();

                        slipDetailAddInfoWork.DtlRelationGuid = stockDetailWork.DtlRelationGuid;
                        slipDetailAddInfoWork.GoodsEntryDiv = 0;
                        slipDetailAddInfoWork.GoodsOfferDate = DateTime.MinValue;
                        slipDetailAddInfoWork.PriceUpdateDiv = 0;
                        slipDetailAddInfoWork.PriceStartDate = DateTime.MinValue;
                        slipDetailAddInfoWork.PriceOfferDate = DateTime.MinValue;
                        slipDetailAddInfoWork.CarRelationGuid = Guid.Empty;
                        slipDetailAddInfoWork.SlipDtlRegOrder = slipDtlRegOrder;
                        slipDetailAddInfoWork.AddUpRemDiv = 0;

                        slipDetailAddInfoWorkAry.Add(slipDetailAddInfoWork);
                    }
                    # endregion

                    //-----------------------------------------------------------
                    // 仕入情報(CustomSerializeArrayList)の作成
                    //-----------------------------------------------------------
                    # region 仕入情報(CustomSerializeArrayList)の作成
                    if (!string.IsNullOrEmpty(stockSlipWork.PartySaleSlipNum)) // ADD 2011/10/29
                    { // ADD 2011/10/29
                    CustomSerializeArrayList grpAry = new CustomSerializeArrayList();
                    grpAry.Add(stockSlipWork);
                    grpAry.Add(stockDetailWorkAry);
                    grpAry.Add(slipDetailAddInfoWorkAry);

                    paraList.Add(grpAry);
                    } // ADD 2011/10/29
                    # endregion
                }
            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
            }
            return (status);
        }
        # endregion
        # endregion

        #region ●受注データ取得処理
        /// <summary>
        /// 受注データ取得処理
        /// </summary>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>0:正常 0以外:エラー</returns>
        public int GetAcptProc(out string message)
        {
            //------------------------------------------------------------------------------------
            // データ設定
            //------------------------------------------------------------------------------------
            //  CustomSerializeArrayList            統合リスト
            //      --IOWriteMAHNBReadWork          READ用抽出条件クラス
            //      --iOWriteCtrlOptWork            売上・仕入制御オプション
            //------------------------------------------------------------------------------------
            // データ取得
            //------------------------------------------------------------------------------------
            //  CustomSerializeArrayList            統合リスト
            //      --CustomSerializeArrayList      売上リスト
            //          --SalesSlipWork             売上データオブジェクト
            //          --ArrayList                 売上明細リスト
            //              --SalesDetailWork       売上明細データオブジェクト
            //          --ArrayList                 受注マスタ（車両）リスト
            //              --AcceptOdrCarWork      受注マスタ（車両）
            // 2009/07/10 START >>>>>>
            //          --SCMAcOdrDataWork              SCM受注データ
            //          --ArrayList<SCMAcOdrDtlAsWork>  SCM受注明細データ（回答）リスト
            //          --SCMAcOdrDtCarWork             SCM受注データ（車両情報）
            // 2009/07/10 END   <<<<<<
            //------------------------------------------------------------------------------------

            //変数の初期化
            int status = (int)EnumUoeConst.Status.ct_NORMAL;
            message = "";
            // 2010/07/05 Add SCMの得意先がいるか判断 >>>
            this.scmFlg = false;
            // 2010/07/05 Add <<<

            try
            {
                CustomSerializeArrayList paraList = new CustomSerializeArrayList();         // 統合リスト

                //------------------------------------------------------
                // リモート参照用パラメータ
                //------------------------------------------------------
                # region リモート参照用パラメータ
                IOWriteCtrlOptWork iOWriteCtrlOptWork = new IOWriteCtrlOptWork();                // リモート参照用パラメータ
                this.SettingIOWriteCtrlOptWork(OptWorkSettingType.Read, out iOWriteCtrlOptWork); // リモート参照用パラメータ設定処理
                paraList.Add(iOWriteCtrlOptWork);
                # endregion

                //------------------------------------------------------
                // READ用抽出条件クラス
                //------------------------------------------------------
                # region 送受信JNLのDataViewの作成
                //送受信JNLのDataViewの作成
                //データ送信区分「9:正常終了」
                //システム区分 0:手入力 1:伝発 2:検索
                string rowFilterText = string.Format("{0} = {1} AND {2} = {3}",
                                                OrderSndRcvJnlSchema.ct_Col_DataSendCode, (int)EnumUoeConst.ctDataSendCode.ct_OK,
                                                OrderSndRcvJnlSchema.ct_Col_SystemDivCd, (int)EnumUoeConst.ctSystemDivCd.ct_Slip);

                //ソート：オンライン番号・オンライン行番号
                string sortText = string.Format("{0}, {1}",
                                                OrderSndRcvJnlSchema.ct_Col_OnlineNo,
                                                OrderSndRcvJnlSchema.ct_Col_OnlineRowNo);

                DataView viewOrder = new DataView(OrderTable);
                viewOrder.Sort = sortText;
                viewOrder.RowFilter = rowFilterText;

                if (viewOrder == null) return (-1);
                if (viewOrder.Count == 0) return (-1);
                # endregion

                # region READ用条件クラスの取得
                Dictionary<string, string> salesSlipNumDictionary = new Dictionary<string, string>();

                //READ用条件クラスの取得
                foreach (DataRowView rowOrder in viewOrder)
                {
                    string salesSlipNum = (string)rowOrder[OrderSndRcvJnlSchema.ct_Col_SalesSlipNum];
                    if (salesSlipNumDictionary.ContainsKey(salesSlipNum) == true)
                    {
                        continue;
                    }
                    else
                    {
                        salesSlipNumDictionary.Add(salesSlipNum, salesSlipNum);
                    }

                    IOWriteMAHNBReadWork iOWriteMAHNBReadWork = new IOWriteMAHNBReadWork();

                    iOWriteMAHNBReadWork.AcptAnOdrStatus = 20;
                    iOWriteMAHNBReadWork.DebitNoteDiv = 0;
                    iOWriteMAHNBReadWork.EnterpriseCode = (string)rowOrder[OrderSndRcvJnlSchema.ct_Col_EnterpriseCode];
                    iOWriteMAHNBReadWork.SalesGoodsCd = 0;
                    iOWriteMAHNBReadWork.SalesSlipCd = 0;
                    iOWriteMAHNBReadWork.SalesSlipNum = salesSlipNum;

                    paraList.Add(iOWriteMAHNBReadWork);
                }
                # endregion

                //------------------------------------------------------
                // 取得処理
                //------------------------------------------------------
                # region 取得処理
                // 保存用変数初期化
                object paraObj = (object)paraList;
                object retObj = null;

                //取得処理
                status = _iIOWriteControlDB.ReadMore(ref paraObj, out retObj);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return(status);
                }
                #endregion

                //------------------------------------------------------
                // 取得後処理
                //------------------------------------------------------
                # region 取得後処理
                #region データ分割
                //データ分割
                ArrayList salesGrpAry = new ArrayList();// 売上データ(伝票リスト情報)
                ArrayList acptGrpAry = new ArrayList(); // 受注データ(伝票リスト情報)
                ArrayList stockGrpAry = new ArrayList();// 仕入データ(伝票リスト情報)
                DivisionSalesSlipCustomSerializeArrayList.DivisionCustomSerializeArrayListForWriting(
                                                                (CustomSerializeArrayList)retObj,
                                                                out salesGrpAry,
                                                                out acptGrpAry,
                                                                out stockGrpAry);

                #endregion

                #region 受注情報リストパラメータ戻し
                // 受注情報リストパラメータ戻し
                status = SetAcptDBPara(acptGrpAry, out message);
                #endregion
                #endregion
            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
            }
            return (status);
        }
        # endregion

        # region ●売上仕入情報データ再設定
        # region 受注情報再設定
        /// <summary>
        /// 受注情報再設定
        /// </summary>
        /// <param name="salesGrpAry">受注情報</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        /// <br>Update Note: 2012/02/10 鄧潘ハン</br>
        /// <br>管理番号   : 10707327-00 2012/03/28配信分</br>
        /// <br>             Redmine#28406 発注送信後のデータ作成不具合についての対応</br>
        private int SetAcptDBPara(ArrayList acceptGrpAry, out string message)
        {
            //------------------------------------------------------------------------------------
            // データセット方法
            //------------------------------------------------------------------------------------
            //      --ArrayList                     売上リスト
            //          --SalesSlipWork             売上データオブジェクト
            //          --ArrayList                 売上明細リスト
            //              --SalesDetailWork       売上明細データオブジェクト
            //          --ArrayList                 受注マスタ（車両）リスト
            //              --AcceptOdrCarWork      受注マスタ（車両）オブジェクト
            // 2009/07/10 START >>>>>>
            //          --SCMAcOdrDataWork              SCM受注データ
            //          --ArrayList<SCMAcOdrDtlAsWork>  SCM受注明細データ（回答）リスト
            //          --SCMAcOdrDtCarWork             SCM受注データ（車両情報）
            // 2009/07/10 END   <<<<<<
            //------------------------------------------------------------------------------------
            //変数の初期化
            int status = (int)EnumUoeConst.Status.ct_NORMAL;
            message = string.Empty;

            try
            {
                SalesSlipWork salesSlipWork = new SalesSlipWork();  //売上データオブジェクト
                ArrayList salesDetailWorkAry = new ArrayList();     //売上明細リスト
                ArrayList acceptOdrCarWorkArray = new ArrayList();  //受注マスタ（車両）オブジェクト

                // 2009/07/10 START >>>>>>
                SCMAcOdrDataWork sCMAcOdrDataWork = null;     //SCM受注データオブジェクト
                SCMAcOdrDtCarWork sCMAcOdrDtCarWork = null;  //SCM受注データ（車両情報）オブジェクト
                ArrayList sCMAcOdrDtlAsWorkArray = null;             //SCM受注明細データ（回答）リスト

                //Dictionary初期化処理
                _acceptOdrCarDictionary.Clear();
                _sCMAcOdrDataDictionary.Clear();
                _sCMAcOdrDtCarDictionary.Clear();
                _sCMAcOdrDtlAsDictionary.Clear();
                // 2009/07/10 END   <<<<<<

                foreach (ArrayList dtl in acceptGrpAry)
                {
                    #region 元データ分解
                    //------------------------------------------------------
                    // 元データ分解
                    //------------------------------------------------------
                    foreach (object obj in dtl)
                    {
                        if (obj is SalesSlipWork)
                        {
                            salesSlipWork = (SalesSlipWork)obj;
                        }
                        // 2009/07/10 START >>>>>>
                        // SCM受注データ
                        else if (obj is SCMAcOdrDataWork)
                        {
                            sCMAcOdrDataWork = (SCMAcOdrDataWork)obj;
                        }
                        // SCM受注データ（車両情報）
                        else if (obj is SCMAcOdrDtCarWork)
                        {
                            sCMAcOdrDtCarWork = (SCMAcOdrDtCarWork)obj;
                        }
                        // 2009/07/10 END   <<<<<<
                        else if (obj is ArrayList)
                        {
                            ArrayList list = (ArrayList)obj;
                            //---ADD 鄧潘ハン 2012/02/10 Redmine#28406------>>>>>
                            if (list[0].GetType() == typeof(AddUpOrgSalesDetailWork))
                            {
                                continue;
                            }
                            //売上明細
                            else if (list[0] is SalesDetailWork)
                            //---ADD 鄧潘ハン 2012/02/10 Redmine#28406------<<<<<
                            //---DEL 鄧潘ハン 2012/02/10 Redmine#28406------>>>>>
                            //売上明細
                            //if (list[0] is SalesDetailWork)
                            //---DEL 鄧潘ハン 2012/02/10 Redmine#28406------<<<<<
                            {
                                salesDetailWorkAry = list;
                            }
                            //受注マスタ（車両）
                            else if (list[0] is AcceptOdrCarWork)
                            {
                                acceptOdrCarWorkArray = list;
                            }
                            // 2009/07/10 START >>>>>>
                            //SCM受注明細データ（回答）
                            else if (list[0] is SCMAcOdrDtlAsWork)
                            {
                                sCMAcOdrDtlAsWorkArray = list;
                            }
                            // 2009/07/10 END   <<<<<<
                        }
                    }
                    #endregion

                    #region 受注明細テーブル格納
                    //------------------------------------------------------
                    // 受注明細テーブル格納
                    //------------------------------------------------------
                    status = _uoeSndRcvJnlAcs.InsertAcptDtlTblFromSalesDetailAry(salesDetailWorkAry, out message);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return (status);
                    }
                    #endregion

                    #region 受注データテーブル格納
                    //------------------------------------------------------
                    // 受注データテーブル格納
                    //------------------------------------------------------
                    status = _uoeSndRcvJnlAcs.InsertAcptTblFromSalesSlipWork(salesSlipWork, out message);
                    #endregion

                    #region 車輌管理マスタ格納
                    //------------------------------------------------------
                    // 車輌管理マスタ格納
                    //------------------------------------------------------
                    // 2009/07/10 START >>>>>>
                    //_acceptOdrCarDictionary.Clear();
                    // 2009/07/10 END   <<<<<<

                    foreach (AcceptOdrCarWork acceptOdrCarWork in acceptOdrCarWorkArray)
                    {
                        SetAcceptOdrCarWork(acceptOdrCarWork);
                    }
                    #endregion

                    // 2009/07/10 START >>>>>>
                    //------------------------------------------------------
                    // SCM受注データ格納
                    //------------------------------------------------------
                    #region SCM受注データ格納
                    if (sCMAcOdrDataWork != null)
                    {
                        SetSCMAcOdrDataWork(sCMAcOdrDataWork);
                        // 2010/07/05 Add >>>
                        this.scmFlg = true;
                        // 2010/07/05 Add <<<
                    }
                    #endregion

                    //------------------------------------------------------
                    // SCM受注データ（車両情報）格納
                    //------------------------------------------------------
                    #region SCM受注データ（車両情報）格納
                    if (sCMAcOdrDtCarWork != null)
                    {
                        SetSCMAcOdrDtCarWork(sCMAcOdrDtCarWork);
                        // 2010/07/05 Add >>>
                        this.scmFlg = true;
                        // 2010/07/05 Add <<<
                    }
                    #endregion

                    //------------------------------------------------------
                    // SCM受注明細データ（回答）格納
                    //------------------------------------------------------
                    #region SCM受注明細データ（回答）格納
                    if (sCMAcOdrDtlAsWorkArray != null)
                    {
                        foreach (SCMAcOdrDtlAsWork sCMAcOdrDtlAsWork in sCMAcOdrDtlAsWorkArray)
                        {
                            SetSCMAcOdrDtlAsWork(sCMAcOdrDtlAsWork);
                            // 2010/07/05 Add >>>
                            this.scmFlg = true;
                            // 2010/07/05 Add <<<
                        }
                    }
                    #endregion
                    // 2009/07/10 END   <<<<<<
                }
            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
            }
            return (status);
        }
        # endregion

        // 2009/07/10 START >>>>>>
        # region SCM受注データの設定
        /// <summary>
        /// SCM受注データの設定
        /// </summary>
        /// <param name="sCMAcOdrDataWork">SCM受注データオブジェクト</param>
        private void SetSCMAcOdrDataWork(SCMAcOdrDataWork sCMAcOdrDataWork)
        {
            string keyNo = sCMAcOdrDataWork.AcptAnOdrStatus.ToString("d2") + sCMAcOdrDataWork.SalesSlipNum;

            if (_sCMAcOdrDataDictionary.ContainsKey(keyNo) != true)
            {
                _sCMAcOdrDataDictionary.Add(keyNo, sCMAcOdrDataWork);
            }
        }
        # endregion

        # region SCM受注データの取得
        /// <summary>
        /// SCM受注データの取得
        /// </summary>
        /// <param name="acptAnOdrStatus">受注ステータス</param>
        /// <param name="salesSlipNum">売上伝票番号</param>
        /// <returns>SCM受注データオブジェクト</returns>
        private SCMAcOdrDataWork GetSCMAcOdrDataWorkDictionary(int acptAnOdrStatus, string salesSlipNum)
        {
            SCMAcOdrDataWork sCMAcOdrDataWork = null;
            try
            {
                string keyNo = acptAnOdrStatus.ToString("d2") + salesSlipNum;
                if (_sCMAcOdrDataDictionary.ContainsKey(keyNo) == true)
                {
                    sCMAcOdrDataWork = SCMAcOdrDataWorkClone(_sCMAcOdrDataDictionary[keyNo]);
                }
            }
            catch (Exception)
            {
                sCMAcOdrDataWork = null;
            }
            return (sCMAcOdrDataWork);
        }

        /// <summary>
        ///SCM受注データ clone
        /// </summary>
        /// <param name="sCMAcOdrDtCarWork">SCM受注データ</param>
        /// <returns>SCM受注データ</returns>
        private SCMAcOdrDataWork SCMAcOdrDataWorkClone(SCMAcOdrDataWork src)
        {
            SCMAcOdrDataWork dst = new SCMAcOdrDataWork();
            try
            {
                dst.AcptAnOdrStatus = src.AcptAnOdrStatus;
                dst.AnsEmployeeCd = src.AnsEmployeeCd;
                dst.AnsEmployeeNm = src.AnsEmployeeNm;
                dst.AnswerCreateDiv = src.AnswerCreateDiv;
                dst.AnswerDivCd = src.AnswerDivCd;
                dst.AppendingFile = src.AppendingFile;
                dst.AppendingFileNm = src.AppendingFileNm;
                dst.CreateDateTime = src.CreateDateTime;
                dst.CustomerCode = src.CustomerCode;
                dst.EnterpriseCode = src.EnterpriseCode;
                dst.FileHeaderGuid = src.FileHeaderGuid;
                dst.InqEmployeeCd = src.InqEmployeeCd;
                dst.InqEmployeeNm = src.InqEmployeeNm;
                dst.InqOrdAnsDivCd = src.InqOrdAnsDivCd;
                dst.InqOrdDivCd = src.InqOrdDivCd;
                dst.InqOrdNote = src.InqOrdNote;
                dst.InqOriginalEpCd = src.InqOriginalEpCd.Trim();//@@@@20230303
                dst.InqOriginalSecCd = src.InqOriginalSecCd;
                dst.InqOtherEpCd = src.InqOtherEpCd;
                dst.InqOtherSecCd = src.InqOtherSecCd;
                dst.InquiryDate = src.InquiryDate;
                dst.InquiryNumber = src.InquiryNumber;
                dst.JudgementDate = src.JudgementDate;
                dst.LogicalDeleteCode = src.LogicalDeleteCode;
                dst.ReceiveDateTime = src.ReceiveDateTime;
                dst.SalesSlipNum = src.SalesSlipNum;
                dst.SalesSubtotalTax = src.SalesSubtotalTax;
                dst.SalesTotalTaxInc = src.SalesTotalTaxInc;
                dst.UpdAssemblyId1 = src.UpdAssemblyId1;
                dst.UpdAssemblyId2 = src.UpdAssemblyId2;
                dst.UpdateDate = src.UpdateDate;
                dst.UpdateDateTime = src.UpdateDateTime;
                dst.UpdateTime = src.UpdateTime;
                dst.UpdEmployeeCode = src.UpdEmployeeCode;
                dst.SfPmCprtInstSlipNo = src.SfPmCprtInstSlipNo;  //ADD 2011/05/30
                // ADD 2012/12/06 2012/12/12配信予定 SCM障害№10447対応 ----------------------------------->>>>>
                dst.AcceptOrOrderKind = src.AcceptOrOrderKind;
                // ADD 2012/12/06 2012/12/12配信予定 SCM障害№10447対応 -----------------------------------<<<<<
                // ADD 2013/06/24 T.Miyamoto ------------------------------>>>>>
                dst.TabUseDiv = src.TabUseDiv;   //タブレット使用区分
                // ADD 2013/06/24 T.Miyamoto ------------------------------<<<<<
                // ADD 2013/06/14② T.Miyamoto ------------------------------>>>>>
                dst.CarMngCode = src.CarMngCode; //車両管理コード
                // ADD 2013/06/14② T.Miyamoto ------------------------------<<<<<
                // ADD 2015/07/06 商品保証課Redmine#4234対応 ------------------------------>>>>>
                dst.AutoAnsMthd = src.AutoAnsMthd;      // 自動回答方式区分
                dst.CancelDiv = src.CancelDiv;          // キャンセル区分
                dst.CMTCooprtDiv = src.CMTCooprtDiv;    //CMT連携区分
                // ADD 2015/07/06 商品保証課Redmine#4234対応 ------------------------------<<<<<
            }
            catch (Exception)
            {
                dst = null;
            }
            return (dst);
        }

        /// SCM受注データの算出
        /// </summary>
        /// <param name="acptAnOdrStatus">受注ステータス</param>
        /// <param name="salesSlipNum">売上伝票番号</param>
        /// <param name="acptSlipWork">受注データ</param>
        /// <returns>SCM受注データオブジェクト</returns>
        //private SCMAcOdrDataWork GetSCMAcOdrDataWork(int acptAnOdrStatus, string salesSlipNum)                              //DEL 2011/05/30
        private SCMAcOdrDataWork GetSCMAcOdrDataWork(int acptAnOdrStatus, string salesSlipNum, SalesSlipWork acptSlipWork)　　//ADD 2011/05/30
        {
            SCMAcOdrDataWork sCMAcOdrDataWork = null;

            try
            {
                sCMAcOdrDataWork = GetSCMAcOdrDataWorkDictionary(acptAnOdrStatus, salesSlipNum);
                if (sCMAcOdrDataWork != null)
                {
                    //ヘッダー部
                    sCMAcOdrDataWork.CreateDateTime = DateTime.MinValue;
                    sCMAcOdrDataWork.UpdateDateTime = DateTime.MinValue;
                    sCMAcOdrDataWork.FileHeaderGuid = Guid.Empty;
                    sCMAcOdrDataWork.UpdEmployeeCode = String.Empty;
                    sCMAcOdrDataWork.UpdAssemblyId1 = String.Empty;
                    sCMAcOdrDataWork.UpdAssemblyId2 = String.Empty;
                    sCMAcOdrDataWork.LogicalDeleteCode = 0;

                    //更新年月日
                    //DateTime nowDateTime = DateTime.Now;
                    DateTime nowDateTime = DateTime.MinValue;

                    sCMAcOdrDataWork.UpdateDate = nowDateTime;

                    //更新時分秒ミリ秒(HHMMSSXXX)
                    //sCMAcOdrDataWork.UpdateTime = (nowDateTime.Hour * 10000000)
                    //                            + (nowDateTime.Minute * 100000)
                    //                            + (nowDateTime.Second * 1000)
                    //                            + nowDateTime.Millisecond;
                    sCMAcOdrDataWork.UpdateTime = 0;

                    //受注ステータス
                    sCMAcOdrDataWork.AcptAnOdrStatus = 30;  //30:売上

                    //売上伝票番号
                    sCMAcOdrDataWork.SalesSlipNum = String.Empty;

                    //--- ADD 2011/05/30 ------------------------------------------->>>
                    //SF-PM連携指示書番号
                    sCMAcOdrDataWork.SfPmCprtInstSlipNo = acptSlipWork.PartySaleSlipNum;

                    // 問合せ・発注備考
                    sCMAcOdrDataWork.InqOrdNote = acptSlipWork.SlipNote;
                    //--- ADD 2011/05/30 -------------------------------------------<<<
                }
            }
            catch (Exception)
            {
                sCMAcOdrDataWork = null;
            }
            return (sCMAcOdrDataWork);
        }
        # endregion

        # region SCM受注データ（車両情報）の設定
        /// <summary>
        /// SCM受注データ（車両情報）の設定
        /// </summary>
        /// <param name="sCMAcOdrDtCarWork">SCM受注データ（車両情報）オブジェクト</param>
        private void SetSCMAcOdrDtCarWork(SCMAcOdrDtCarWork sCMAcOdrDtCarWork)
        {
            string keyNo = sCMAcOdrDtCarWork.AcptAnOdrStatus.ToString("d2") + sCMAcOdrDtCarWork.SalesSlipNum;

            if (_sCMAcOdrDtCarDictionary.ContainsKey(keyNo) != true)
            {
                _sCMAcOdrDtCarDictionary.Add(keyNo, sCMAcOdrDtCarWork);
            }
        }
        # endregion

        # region SCM受注データ（車両情報）の取得
        /// <summary>
        /// SCM受注データ（車両情報）の取得
        /// </summary>
        /// <param name="acptAnOdrStatus">受注ステータス</param>
        /// <param name="salesSlipNum">売上伝票番号</param>
        /// <returns>SCM受注データ（車両情報）オブジェクト</returns>
        private SCMAcOdrDtCarWork GetSCMAcOdrDtCarWorkDictionary(int acptAnOdrStatus, string salesSlipNum)
        {
            SCMAcOdrDtCarWork sCMAcOdrDtCarWork = null;
            try
            {
                string keyNo = acptAnOdrStatus.ToString("d2") + salesSlipNum;
                if (_sCMAcOdrDtCarDictionary.ContainsKey(keyNo) == true)
                {
                    sCMAcOdrDtCarWork = SCMAcOdrDtCarWorkClone(_sCMAcOdrDtCarDictionary[keyNo]);
                }
            }
            catch (Exception)
            {
                sCMAcOdrDtCarWork = null;
            }
            return (sCMAcOdrDtCarWork);
        }

        /// <summary>
        ///SCM受注データ（車両情報） clone
        /// </summary>
        /// <param name="sCMAcOdrDtCarWork">SCM受注データ</param>
        /// <returns>SCM受注データ</returns>
        private SCMAcOdrDtCarWork SCMAcOdrDtCarWorkClone(SCMAcOdrDtCarWork src)
        {
            SCMAcOdrDtCarWork dst = new SCMAcOdrDtCarWork();
            try
            {
                dst.AcptAnOdrStatus = src.AcptAnOdrStatus;
                dst.CarInspectCertModel = src.CarInspectCertModel;
                dst.CarProperNo = src.CarProperNo;
                dst.CategoryNo = src.CategoryNo;
                dst.ChassisNo = src.ChassisNo;
                dst.ColorName1 = src.ColorName1;
                dst.Comment = src.Comment;
                dst.CreateDateTime = src.CreateDateTime;
                dst.EnterpriseCode = src.EnterpriseCode;
                dst.EquipObj = src.EquipObj;
                dst.FileHeaderGuid = src.FileHeaderGuid;
                dst.FrameModel = src.FrameModel;
                dst.FrameNo = src.FrameNo;
                dst.FullModel = src.FullModel;
                dst.InqOriginalEpCd = src.InqOriginalEpCd.Trim();//@@@@20230303
                dst.InqOriginalSecCd = src.InqOriginalSecCd;
                dst.InquiryNumber = src.InquiryNumber;
                dst.LogicalDeleteCode = src.LogicalDeleteCode;
                dst.MakerCode = src.MakerCode;
                dst.Mileage = src.Mileage;
                dst.ModelCode = src.ModelCode;
                dst.ModelDesignationNo = src.ModelDesignationNo;
                dst.ModelName = src.ModelName;
                dst.ModelSubCode = src.ModelSubCode;
                dst.NumberPlate1Code = src.NumberPlate1Code;
                dst.NumberPlate1Name = src.NumberPlate1Name;
                dst.NumberPlate2 = src.NumberPlate2;
                dst.NumberPlate3 = src.NumberPlate3;
                dst.NumberPlate4 = src.NumberPlate4;
                dst.ProduceTypeOfYearNum = src.ProduceTypeOfYearNum;
                dst.RpColorCode = src.RpColorCode;
                dst.SalesSlipNum = src.SalesSlipNum;
                dst.TrimCode = src.TrimCode;
                dst.TrimName = src.TrimName;
                dst.UpdAssemblyId1 = src.UpdAssemblyId1;
                dst.UpdAssemblyId2 = src.UpdAssemblyId2;
                dst.UpdateDateTime = src.UpdateDateTime;
                dst.UpdEmployeeCode = src.UpdEmployeeCode;
                // ADD 2013/06/14① T.Miyamoto ------------------------------>>>>>
                dst.CarMngCode = src.CarMngCode;                     //車両管理コード
                dst.ExpectedCeDate = src.ExpectedCeDate;             //入庫予定日
                // ADD 2013/06/14① T.Miyamoto ------------------------------<<<<<
            }
            catch (Exception)
            {
                dst = null;
            }
            return (dst);
        }

        /// <summary>
        /// SCM受注データ（車両情報）の算出
        /// </summary>
        /// <param name="acptAnOdrStatus">受注ステータス</param>
        /// <param name="salesSlipNum">売上伝票番号</param>
        /// <returns>SCM受注データ（車両情報）オブジェクト</returns>
        private SCMAcOdrDtCarWork GetSCMAcOdrDtCarWork(int acptAnOdrStatus, string salesSlipNum)
        {
            SCMAcOdrDtCarWork sCMAcOdrDtCarWork = null;
            try
            {
                sCMAcOdrDtCarWork = GetSCMAcOdrDtCarWorkDictionary(acptAnOdrStatus, salesSlipNum);

                if (sCMAcOdrDtCarWork != null)
                {
                    //ヘッダー部
                    sCMAcOdrDtCarWork.CreateDateTime = DateTime.MinValue;
                    sCMAcOdrDtCarWork.UpdateDateTime = DateTime.MinValue;
                    sCMAcOdrDtCarWork.FileHeaderGuid = Guid.Empty;
                    sCMAcOdrDtCarWork.UpdEmployeeCode = String.Empty;
                    sCMAcOdrDtCarWork.UpdAssemblyId1 = String.Empty;
                    sCMAcOdrDtCarWork.UpdAssemblyId2 = String.Empty;
                    sCMAcOdrDtCarWork.LogicalDeleteCode = 0;

                    //受注ステータス
                    sCMAcOdrDtCarWork.AcptAnOdrStatus = 30;  //30:売上

                    //売上伝票番号
                    sCMAcOdrDtCarWork.SalesSlipNum = String.Empty;
                }
            }
            catch (Exception)
            {
                sCMAcOdrDtCarWork = null;
            }
            return (sCMAcOdrDtCarWork);
        }
        # endregion

        # region SCM受注明細データ（回答）の設定
        /// <summary>
        /// SCM受注明細データ（回答）の設定
        /// </summary>
        /// <param name="sCMAcOdrDtlAsWork">SCM受注明細データ（回答）オブジェクト</param>
        private void SetSCMAcOdrDtlAsWork(SCMAcOdrDtlAsWork sCMAcOdrDtlAsWork)
        {
            string keyNo = sCMAcOdrDtlAsWork.AcptAnOdrStatus.ToString("d2") + sCMAcOdrDtlAsWork.SalesSlipNum + sCMAcOdrDtlAsWork.SalesRowNo.ToString("d4");

            if (_sCMAcOdrDtlAsDictionary.ContainsKey(keyNo) != true)
            {
                _sCMAcOdrDtlAsDictionary.Add(keyNo, sCMAcOdrDtlAsWork);
            }
        }
        # endregion

        # region SCM受注明細データ（回答）の取得
        /// <summary>
        /// SCM受注明細データ（回答）の取得
        /// </summary>
        /// <param name="acptAnOdrStatus">受注ステータス</param>
        /// <param name="salesSlipNum">売上伝票番号</param>
        /// <param name="salesRowNo">売上伝票行番号</param>
        /// <returns>SCM受注明細データ（回答）オブジェクト</returns>
        private SCMAcOdrDtlAsWork GetSCMAcOdrDtlAsWorkDictionary(int acptAnOdrStatus, string salesSlipNum, int salesRowNo)
        {
            SCMAcOdrDtlAsWork sCMAcOdrDtlAsWork = null;
            try
            {
                string keyNo = acptAnOdrStatus.ToString("d2") + salesSlipNum + salesRowNo.ToString("d4");
                if (_sCMAcOdrDtlAsDictionary.ContainsKey(keyNo) == true)
                {
                    sCMAcOdrDtlAsWork = SCMAcOdrDtlAsWorkClone(_sCMAcOdrDtlAsDictionary[keyNo]);
                }
            }
            catch (Exception)
            {
                sCMAcOdrDtlAsWork = null;
            }
            return (sCMAcOdrDtlAsWork);
        }

        /// <summary>
        /// SCM受注明細データ（回答） clone
        /// </summary>
        /// <param name="sCMAcOdrDtlAsWork"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Update Note: 2018/04/16 譚洪</br>
        /// <br>管理番号   : 11470007-00</br>
        /// <br>           : SFからの問合せ・発注のデータに新BLコード、新BLサブコード項目を追加する。</br>
        /// </remarks>
        private SCMAcOdrDtlAsWork SCMAcOdrDtlAsWorkClone(SCMAcOdrDtlAsWork src)
        {
            SCMAcOdrDtlAsWork dst = new SCMAcOdrDtlAsWork();
            try
            {
                dst.AcptAnOdrStatus = src.AcptAnOdrStatus;
                dst.AdditionalDivCd = src.AdditionalDivCd;
                dst.AnsGoodsName = src.AnsGoodsName;
                dst.AnsPureGoodsNo = src.AnsPureGoodsNo;
                dst.AnswerDeliveryDate = src.AnswerDeliveryDate;
                dst.AnswerLimitDate = src.AnswerLimitDate;
                dst.AppendingFileDtl = src.AppendingFileDtl;
                dst.AppendingFileNmDtl = src.AppendingFileNmDtl;
                dst.BLGoodsCode = src.BLGoodsCode;
                dst.BLGoodsDrCode = src.BLGoodsDrCode;
                dst.CampaignCode = src.CampaignCode;
                dst.CommentDtl = src.CommentDtl;
                dst.CorrectDivCD = src.CorrectDivCD;
                dst.CreateDateTime = src.CreateDateTime;
                dst.DeliGdsCmpltDueDate = src.DeliGdsCmpltDueDate;
                dst.DeliveredGoodsCount = src.DeliveredGoodsCount;
                dst.DeliveredGoodsDiv = src.DeliveredGoodsDiv;
                dst.DelivrdGdsConfCd = src.DelivrdGdsConfCd;
                dst.DisplayOrder = src.DisplayOrder;
                dst.EnterpriseCode = src.EnterpriseCode;
                dst.FileHeaderGuid = src.FileHeaderGuid;
                dst.GoodsAddInfo = src.GoodsAddInfo;
                dst.GoodsDivCd = src.GoodsDivCd;
                dst.GoodsMakerCd = src.GoodsMakerCd;
                dst.GoodsMakerNm = src.GoodsMakerNm;
                dst.GoodsMngNo = src.GoodsMngNo;
                dst.GoodsNo = src.GoodsNo;
                dst.GoodsShape = src.GoodsShape;
                dst.HandleDivCode = src.HandleDivCode;
                dst.InqGoodsName = src.InqGoodsName;
                dst.InqOrdDivCd = src.InqOrdDivCd;
                dst.InqOrgDtlDiscGuid = src.InqOrgDtlDiscGuid;
                dst.InqOriginalEpCd = src.InqOriginalEpCd.Trim();//@@@@20230303
                dst.InqOriginalSecCd = src.InqOriginalSecCd;
                dst.InqOthDtlDiscGuid = src.InqOthDtlDiscGuid;
                dst.InqOtherEpCd = src.InqOtherEpCd;
                dst.InqOtherSecCd = src.InqOtherSecCd;
                dst.InqPureGoodsNo = src.InqPureGoodsNo;
                dst.InqRowNumber = src.InqRowNumber;
                dst.InqRowNumDerivedNo = src.InqRowNumDerivedNo;
                dst.InquiryNumber = src.InquiryNumber;
                dst.ListPrice = src.ListPrice;
                dst.LogicalDeleteCode = src.LogicalDeleteCode;
                dst.PureGoodsMakerCd = src.PureGoodsMakerCd;
                dst.RecyclePrtKindCode = src.RecyclePrtKindCode;
                dst.RecyclePrtKindName = src.RecyclePrtKindName;
                dst.RoughRate = src.RoughRate;
                dst.RoughRrofit = src.RoughRrofit;
                dst.SalesOrderCount = src.SalesOrderCount;
                dst.SalesRowNo = src.SalesRowNo;
                dst.SalesSlipNum = src.SalesSlipNum;
                dst.ShelfNo = src.ShelfNo;
                dst.StockDiv = src.StockDiv;
                dst.UnitPrice = src.UnitPrice;
                dst.UpdAssemblyId1 = src.UpdAssemblyId1;
                dst.UpdAssemblyId2 = src.UpdAssemblyId2;
                dst.UpdateDate = src.UpdateDate;
                dst.UpdateDateTime = src.UpdateDateTime;
                dst.UpdateTime = src.UpdateTime;
                dst.UpdEmployeeCode = src.UpdEmployeeCode;
                //--- ADD 2011/05/30 --------->>>
                dst.WarehouseCode = src.WarehouseCode;
                dst.WarehouseName = src.WarehouseName;
                dst.WarehouseShelfNo = src.WarehouseShelfNo;
                //--- ADD 2011/05/30 ---------<<<

                // 2012/01/16 Add >>>
                dst.GoodsSpecialNote = src.GoodsSpecialNote;
                // 2012/01/16 Add <<<

                // ADD 2014/06/04 SCM仕掛一覧№10659対応 ------------------------------------------------------->>>>>
                dst.PrmSetDtlNo2 = src.PrmSetDtlNo2;
                dst.PrmSetDtlName2 = src.PrmSetDtlName2;
                dst.StockStatusDiv = src.StockStatusDiv;
                // ADD 2014/06/04 SCM仕掛一覧№10659対応 -------------------------------------------------------<<<<<

                // ADD 2014/12/19 SCM高速化 PMNS対応 --------------------------------->>>>>
                dst.RentDiv = src.RentDiv;
                dst.MkrSuggestRtPric = src.MkrSuggestRtPric;
                dst.OpenPriceDiv = src.OpenPriceDiv;
                // ADD 2014/12/19 SCM高速化 PMNS対応 ---------------------------------<<<<<

                // ADD 2015/01/30 SCM高速化 生産年式、車台番号対応 ----------------------------->>>>>
                dst.ModelPrtsAdptYm = src.ModelPrtsAdptYm;
                dst.ModelPrtsAblsYm = src.ModelPrtsAblsYm;
                dst.ModelPrtsAdptFrameNo = src.ModelPrtsAdptFrameNo;
                dst.ModelPrtsAblsFrameNo = src.ModelPrtsAblsFrameNo;
                // ADD 2015/01/30 SCM高速化 生産年式、車台番号対応 -----------------------------<<<<<

                // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                dst.AnsDeliDateDiv = src.AnsDeliDateDiv;
                // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

                // ADD 2015/02/23 下口 SCM高速化 Ｃ向け種別特記対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                dst.GoodsSpecialNtForFac = src.GoodsSpecialNtForFac;
                dst.GoodsSpecialNtForCOw = src.GoodsSpecialNtForCOw;
                dst.PrmSetDtlName2ForFac = src.PrmSetDtlName2ForFac;
                dst.PrmSetDtlName2ForCOw = src.PrmSetDtlName2ForCOw;
                // ADD 2015/02/23 下口 SCM高速化 Ｃ向け種別特記対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

                // ADD 2015/07/06 商品保証課Redmine#4234対応 ------------------------------>>>>>
                dst.AccRecConsTax = src.AccRecConsTax;                      // 売掛消費税
                dst.AutoEstimatePartsCd = src.AutoEstimatePartsCd;          // 自動見積部品コード
                dst.BgnGoodsDiv = src.BgnGoodsDiv;                          // お買得商品選択区分
                dst.CancelCndtinDiv = src.CancelCndtinDiv;                  // キャンセル状態区分
                dst.ConsTaxRate = src.ConsTaxRate;                          // 消費税税率
                dst.DataInputSystem = src.DataInputSystem;                  // データ入力システム
                dst.DtlTakeinDivCd = src.DtlTakeinDivCd;                    // 明細取込区分
                dst.PmMainMngPrsntCount = src.PmMainMngPrsntCount;          // PM主管現在個数
                dst.PmMainMngShelfNo = src.PmMainMngShelfNo;                // PM主管棚番
                dst.PmMainMngWarehouseCd = src.PmMainMngWarehouseCd;        // PM主管倉庫コード
                dst.PmMainMngWarehouseName = src.PmMainMngWarehouseName;    // PM主管倉庫名称
                dst.PmPrsntCount = src.PmPrsntCount;                        // PM現在庫数
                dst.PMSalesDate = src.PMSalesDate;                          // PM売上日
                dst.PSMngNo = src.PSMngNo;                                  // PS管理番号
                dst.SalesMoneyTaxExc = src.SalesMoneyTaxExc;                // 売上金額（税抜き）
                dst.SalesMoneyTaxInc = src.SalesMoneyTaxInc;                // 売上金額（税込み）
                dst.SalesTotalTaxExc = src.SalesTotalTaxExc;                // 売上伝票合計（税抜）
                dst.SalesTotalTaxInc = src.SalesTotalTaxInc;                // 売上伝票合計（税込）
                dst.ScmConsTaxLayMethod = src.ScmConsTaxLayMethod;          // SCM消費税転嫁方式
                dst.ScmFractionProcCd = src.ScmFractionProcCd;              // SCM端数処理区分
                dst.SetPartsMainSubNo = src.SetPartsMainSubNo;              // セット部品親子番号
                dst.SetPartsMkrCd = src.SetPartsMkrCd;                      // セット部品メーカーコード
                dst.SetPartsNumber = src.SetPartsNumber;                    // セット部品番号
                dst.SuppSlpPrtTime = src.SuppSlpPrtTime;                    // 仕入先伝票発行時刻
                // ADD 2015/07/06 商品保証課Redmine#4234対応 ------------------------------<<<<<

                // ADD 2018/04/16 譚洪 新BLコード対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                dst.InqBlUtyPtThCd = src.InqBlUtyPtThCd;   // 問発BL統一部品コード(スリーコード版)
                dst.InqBlUtyPtSbCd = src.InqBlUtyPtSbCd;   // 問発BL統一部品サブコード
                dst.AnsBlUtyPtThCd = src.AnsBlUtyPtThCd;   // 回答BL統一部品コード(スリーコード版)
                dst.AnsBlUtyPtSbCd = src.AnsBlUtyPtSbCd;   // 回答BL統一部品サブコード
                dst.AnsBLGoodsCode = src.AnsBLGoodsCode;   // 回答BL商品コード
                dst.AnsBLGoodsDrCode = src.AnsBLGoodsDrCode;   // 回答BL商品コード枝番
                // ADD 2018/04/16 譚洪 新BLコード対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

            }
            catch (Exception)
            {
                dst = null;
            }
            return (dst);
        }

        /// <summary>
        /// SCM受注明細データ（回答）の算出
        /// </summary>
        /// <param name="acptAnOdrStatus">受注ステータス</param>
        /// <param name="salesSlipNum">売上伝票番号</param>
        /// <param name="salesRowNo">売上伝票行番号</param>
        /// <param name="salesRowNo">売上明細データオブジェクト</param>
        /// <returns>SCM受注明細データ（回答）オブジェクト</returns>
        private SCMAcOdrDtlAsWork GetSCMAcOdrDtlAsWork(int scmAcptAnOdrStatus, string smcSalesSlipNum, int scmSalesRowNo, SalesDetailWork salesDetailWork)
        {
            SCMAcOdrDtlAsWork sCMAcOdrDtlAsWork = null;
            try
            {

                sCMAcOdrDtlAsWork = GetSCMAcOdrDtlAsWorkDictionary(scmAcptAnOdrStatus, smcSalesSlipNum, scmSalesRowNo);
                if (sCMAcOdrDtlAsWork != null)
                {
                    //ヘッダー部
                    sCMAcOdrDtlAsWork.CreateDateTime = DateTime.MinValue;
                    sCMAcOdrDtlAsWork.UpdateDateTime = DateTime.MinValue;
                    sCMAcOdrDtlAsWork.FileHeaderGuid = Guid.Empty;
                    sCMAcOdrDtlAsWork.UpdEmployeeCode = String.Empty;
                    sCMAcOdrDtlAsWork.UpdAssemblyId1 = String.Empty;
                    sCMAcOdrDtlAsWork.UpdAssemblyId2 = String.Empty;
                    sCMAcOdrDtlAsWork.LogicalDeleteCode = 0;

                    //更新年月日
                    //DateTime nowDateTime = DateTime.Now;
                    DateTime nowDateTime = DateTime.MinValue;
                    sCMAcOdrDtlAsWork.UpdateDate = nowDateTime;

                    //更新時分秒ミリ秒(HHMMSSXXX)
                    //sCMAcOdrDtlAsWork.UpdateTime = (nowDateTime.Hour * 10000000)
                    //                            + (nowDateTime.Minute * 100000)
                    //                            + (nowDateTime.Second * 1000)
                    //                            + nowDateTime.Millisecond;
                    sCMAcOdrDtlAsWork.UpdateTime = 0;

                    //回答商品名
                    sCMAcOdrDtlAsWork.AnsGoodsName = salesDetailWork.GoodsName;

                    //納品数
                    sCMAcOdrDtlAsWork.DeliveredGoodsCount = salesDetailWork.ShipmentCnt;

                    //回答純正商品番号
                    sCMAcOdrDtlAsWork.AnsPureGoodsNo = salesDetailWork.GoodsNo;

                    //定価
                    sCMAcOdrDtlAsWork.ListPrice = (Int64)salesDetailWork.ListPriceTaxExcFl;

                    //単価
                    sCMAcOdrDtlAsWork.UnitPrice = (Int64)salesDetailWork.SalesUnPrcTaxExcFl;

                    //受注ステータス
                    sCMAcOdrDtlAsWork.AcptAnOdrStatus = 30;  //30:売上

                    //売上伝票番号
                    sCMAcOdrDtlAsWork.SalesSlipNum = String.Empty;

                    //売上行番号
                    sCMAcOdrDtlAsWork.SalesRowNo = salesDetailWork.SalesRowNo;

                    //--- ADD 2011/05/30 ----------------------------------------------->>>
                    // PM倉庫コード
                    sCMAcOdrDtlAsWork.WarehouseCode = salesDetailWork.WarehouseCode;

                    // PM倉庫名称
                    sCMAcOdrDtlAsWork.WarehouseName = salesDetailWork.WarehouseName;

                    // PM棚番
                    sCMAcOdrDtlAsWork.WarehouseShelfNo = salesDetailWork.WarehouseShelfNo;

                    // 備考(明細)
                    sCMAcOdrDtlAsWork.CommentDtl = salesDetailWork.DtlNote;
                    //--- ADD 2011/05/30 ----------------------------------------------->>>

                    // 2012/01/16 Add >>>
                    sCMAcOdrDtlAsWork.GoodsSpecialNote = salesDetailWork.GoodsSpecialNote;
                    // 2012/01/16 Add <<<

                }
            }
            catch (Exception)
            {
                sCMAcOdrDtlAsWork = null;
            }
            return (sCMAcOdrDtlAsWork);
        }
        # endregion
        // 2009/07/10 END   <<<<<<

        # region 受注マスタ（車両）の取得
        /// <summary>
        /// 受注マスタ（車両）の取得
        /// </summary>
        /// <param name="acceptAnOrderNo">受注番号</param>
        /// <param name="acptAnOdrStatus">(売上明細)受注ステータス</param>
        /// <returns>受注マスタ（車両）オブジェクト</returns>
        private AcceptOdrCarWork GetAcceptOdrCarWork(Int32 acceptAnOrderNo, Int32 acptAnOdrStatus)
        {
            AcceptOdrCarWork acceptOdrCarWork = null;

            //変換前：10:見積,20:受注,30:売上,40:出荷,70:指示書,80:クレーム,99:一時保管  
            //変換後：1:見積 2:発注 3:受注 4:入荷 5:出荷 6:仕入 7:売上 8:返品 9:入金 10:支払
            switch (acptAnOdrStatus)
            {
                case 10:
                    acptAnOdrStatus = 1;
                    break;
                case 20:
                    acptAnOdrStatus = 3;
                    break;
                case 30:
                    acptAnOdrStatus = 7;
                    break;
                case 40:
                    acptAnOdrStatus = 5;
                    break;
            }

            string keyNo = acceptAnOrderNo.ToString("d9") + acptAnOdrStatus.ToString("d2");
            if (_acceptOdrCarDictionary.ContainsKey(keyNo) == true)
            {
                acceptOdrCarWork = _acceptOdrCarDictionary[keyNo];
            }
            return (acceptOdrCarWork);
        }
        # endregion

        # region 受注マスタ（車両）の設定
        /// <summary>
        /// 受注マスタ（車両）の設定
        /// </summary>
        /// <param name="acceptOdrCarWork">受注マスタ（車両）オブジェクト</param>
        private void SetAcceptOdrCarWork(AcceptOdrCarWork acceptOdrCarWork)
        {
            string keyNo = acceptOdrCarWork.AcceptAnOrderNo.ToString("d9") + acceptOdrCarWork.AcptAnOdrStatus.ToString("d2");

            if (_acceptOdrCarDictionary.ContainsKey(keyNo) != true)
            {
                _acceptOdrCarDictionary.Add(keyNo, acceptOdrCarWork);
            }
        }
        # endregion

        # region 車輌管理マスタの取得
        /// <summary>
        /// 車輌管理マスタの取得
        /// </summary>
        /// <param name="acceptAnOrderNo">受注番号</param>
        /// <param name="acptAnOdrStatus">受注ステータス</param>
        /// <param name="carManagementWork">車輌管理マスタ オブジェクト</param>
        /// <returns>Guid</returns>
        /// <br>Update Note: SPK車台番号文字列対応に伴う国産/外車区分の追加</br>
        /// <br>Programmer : FSI厚川 宏</br>
        /// <br>Date       : 2013/03/21</br>
        private Guid GetCarManagementWork(Int32 acceptAnOrderNo, Int32 acptAnOdrStatus, out CarManagementWork carManagementWork)
        {
            carManagementWork = null;
            Guid guid = Guid.Empty;

            try
            {
                //-----------------------------------------------------------
                // 受注マスタ（車両）の取得
                //-----------------------------------------------------------
                # region 受注マスタ（車両）の取得
                AcceptOdrCarWork acceptOdrCarWork = GetAcceptOdrCarWork(acceptAnOrderNo, acptAnOdrStatus);
                if (acceptOdrCarWork == null)
                {
                    return (guid);
                }
                # endregion

                //-----------------------------------------------------------
                // 受注マスタ（車両）→ 車輌管理マスタ
                //-----------------------------------------------------------
                # region 受注マスタ（車両）→ 車輌管理マスタ
                carManagementWork = new CarManagementWork();
                //carManagementWork.CreateDateTime = acceptOdrCarWork.CreateDateTime; // 作成日時
                //carManagementWork.UpdateDateTime = acceptOdrCarWork.UpdateDateTime; // 更新日時
                carManagementWork.EnterpriseCode = acceptOdrCarWork.EnterpriseCode; // 企業コード
                //carManagementWork.FileHeaderGuid = acceptOdrCarWork.FileHeaderGuid; // GUID
                //carManagementWork.UpdEmployeeCode = acceptOdrCarWork.UpdEmployeeCode; // 更新従業員コード
                //carManagementWork.UpdAssemblyId1 = acceptOdrCarWork.UpdAssemblyId1; // 更新アセンブリID1
                //carManagementWork.UpdAssemblyId2 = acceptOdrCarWork.UpdAssemblyId2; // 更新アセンブリID2
                //carManagementWork.LogicalDeleteCode = acceptOdrCarWork.LogicalDeleteCode; // 論理削除区分
                //carManagementWork.CustomerCode = acceptOdrCarWork.CustomerCode; // 得意先コード
                carManagementWork.CarMngNo = acceptOdrCarWork.CarMngNo; // 車両管理番号
                carManagementWork.CarMngCode = acceptOdrCarWork.CarMngCode; // 車輌管理コード
                carManagementWork.NumberPlate1Code = acceptOdrCarWork.NumberPlate1Code; // 陸運事務所番号
                carManagementWork.NumberPlate1Name = acceptOdrCarWork.NumberPlate1Name; // 陸運事務局名称
                carManagementWork.NumberPlate2 = acceptOdrCarWork.NumberPlate2; // 車両登録番号（種別）
                carManagementWork.NumberPlate3 = acceptOdrCarWork.NumberPlate3; // 車両登録番号（カナ）
                carManagementWork.NumberPlate4 = acceptOdrCarWork.NumberPlate4; // 車両登録番号（プレート番号）
                //carManagementWork.EntryDate = acceptOdrCarWork.EntryDate; // 登録年月日
                carManagementWork.FirstEntryDate = acceptOdrCarWork.FirstEntryDate; // 初年度
                carManagementWork.MakerCode = acceptOdrCarWork.MakerCode; // メーカーコード
                carManagementWork.MakerFullName = acceptOdrCarWork.MakerFullName; // メーカー全角名称
                carManagementWork.MakerHalfName = acceptOdrCarWork.MakerHalfName; // メーカー半角名称
                carManagementWork.ModelCode = acceptOdrCarWork.ModelCode; // 車種コード
                carManagementWork.ModelSubCode = acceptOdrCarWork.ModelSubCode; // 車種サブコード
                carManagementWork.ModelFullName = acceptOdrCarWork.ModelFullName; // 車種全角名称
                carManagementWork.ModelHalfName = acceptOdrCarWork.ModelHalfName; // 車種半角名称
                //carManagementWork.SystematicCode = acceptOdrCarWork.SystematicCode; // 系統コード
                //carManagementWork.SystematicName = acceptOdrCarWork.SystematicName; // 系統名称
                //carManagementWork.ProduceTypeOfYearCd = acceptOdrCarWork.ProduceTypeOfYearCd; // 生産年式コード
                //carManagementWork.ProduceTypeOfYearNm = acceptOdrCarWork.ProduceTypeOfYearNm; // 生産年式名称
                //carManagementWork.StProduceTypeOfYear = acceptOdrCarWork.StProduceTypeOfYear; // 開始生産年式
                //carManagementWork.EdProduceTypeOfYear = acceptOdrCarWork.EdProduceTypeOfYear; // 終了生産年式
                //carManagementWork.DoorCount = acceptOdrCarWork.DoorCount; // ドア数
                //carManagementWork.BodyNameCode = acceptOdrCarWork.BodyNameCode; // ボディー名コード
                //carManagementWork.BodyName = acceptOdrCarWork.BodyName; // ボディー名称
                carManagementWork.ExhaustGasSign = acceptOdrCarWork.ExhaustGasSign; // 排ガス記号
                carManagementWork.SeriesModel = acceptOdrCarWork.SeriesModel; // シリーズ型式
                carManagementWork.CategorySignModel = acceptOdrCarWork.CategorySignModel; // 型式（類別記号）
                carManagementWork.FullModel = acceptOdrCarWork.FullModel; // 型式（フル型）
                carManagementWork.ModelDesignationNo = acceptOdrCarWork.ModelDesignationNo; // 型式指定番号
                carManagementWork.CategoryNo = acceptOdrCarWork.CategoryNo; // 類別番号
                carManagementWork.FrameModel = acceptOdrCarWork.FrameModel; // 車台型式
                carManagementWork.FrameNo = acceptOdrCarWork.FrameNo; // 車台番号
                carManagementWork.SearchFrameNo = acceptOdrCarWork.SearchFrameNo; // 車台番号（検索用）
                //carManagementWork.StProduceFrameNo = acceptOdrCarWork.StProduceFrameNo; // 生産車台番号開始
                //carManagementWork.EdProduceFrameNo = acceptOdrCarWork.EdProduceFrameNo; // 生産車台番号終了
                //carManagementWork.EngineModel = acceptOdrCarWork.EngineModel; // 原動機型式（エンジン）
                //carManagementWork.ModelGradeNm = acceptOdrCarWork.ModelGradeNm; // 型式グレード名称
                carManagementWork.EngineModelNm = acceptOdrCarWork.EngineModelNm; // エンジン型式名称
                //carManagementWork.EngineDisplaceNm = acceptOdrCarWork.EngineDisplaceNm; // 排気量名称
                //carManagementWork.EDivNm = acceptOdrCarWork.EDivNm; // E区分名称
                //carManagementWork.TransmissionNm = acceptOdrCarWork.TransmissionNm; // ミッション名称
                //carManagementWork.ShiftNm = acceptOdrCarWork.ShiftNm; // シフト名称
                //carManagementWork.WheelDriveMethodNm = acceptOdrCarWork.WheelDriveMethodNm; // 駆動方式名称
                //carManagementWork.AddiCarSpec1 = acceptOdrCarWork.AddiCarSpec1; // 追加諸元1
                //carManagementWork.AddiCarSpec2 = acceptOdrCarWork.AddiCarSpec2; // 追加諸元2
                //carManagementWork.AddiCarSpec3 = acceptOdrCarWork.AddiCarSpec3; // 追加諸元3
                //carManagementWork.AddiCarSpec4 = acceptOdrCarWork.AddiCarSpec4; // 追加諸元4
                //carManagementWork.AddiCarSpec5 = acceptOdrCarWork.AddiCarSpec5; // 追加諸元5
                //carManagementWork.AddiCarSpec6 = acceptOdrCarWork.AddiCarSpec6; // 追加諸元6
                //carManagementWork.AddiCarSpecTitle1 = acceptOdrCarWork.AddiCarSpecTitle1; // 追加諸元タイトル1
                //carManagementWork.AddiCarSpecTitle2 = acceptOdrCarWork.AddiCarSpecTitle2; // 追加諸元タイトル2
                //carManagementWork.AddiCarSpecTitle3 = acceptOdrCarWork.AddiCarSpecTitle3; // 追加諸元タイトル3
                //carManagementWork.AddiCarSpecTitle4 = acceptOdrCarWork.AddiCarSpecTitle4; // 追加諸元タイトル4
                //carManagementWork.AddiCarSpecTitle5 = acceptOdrCarWork.AddiCarSpecTitle5; // 追加諸元タイトル5
                //carManagementWork.AddiCarSpecTitle6 = acceptOdrCarWork.AddiCarSpecTitle6; // 追加諸元タイトル6
                carManagementWork.RelevanceModel = acceptOdrCarWork.RelevanceModel; // 関連型式
                carManagementWork.SubCarNmCd = acceptOdrCarWork.SubCarNmCd; // サブ車名コード
                carManagementWork.ModelGradeSname = acceptOdrCarWork.ModelGradeSname; // 型式グレード略称
                //carManagementWork.BlockIllustrationCd = acceptOdrCarWork.BlockIllustrationCd; // ブロックイラストコード
                //carManagementWork.ThreeDIllustNo = acceptOdrCarWork.ThreeDIllustNo; // 3DイラストNo
                //carManagementWork.PartsDataOfferFlag = acceptOdrCarWork.PartsDataOfferFlag; // 部品データ提供フラグ
                //carManagementWork.InspectMaturityDate = acceptOdrCarWork.InspectMaturityDate; // 車検満期日
                //carManagementWork.LTimeCiMatDate = acceptOdrCarWork.LTimeCiMatDate; // 前回車検満期日
                //carManagementWork.CarInspectYear = acceptOdrCarWork.CarInspectYear; // 車検期間
                carManagementWork.Mileage = acceptOdrCarWork.Mileage; // 車両走行距離
                //carManagementWork.CarNo = acceptOdrCarWork.CarNo; // 号車
                carManagementWork.ColorCode = acceptOdrCarWork.ColorCode; // カラーコード
                carManagementWork.ColorName1 = acceptOdrCarWork.ColorName1; // カラー名称1
                carManagementWork.TrimCode = acceptOdrCarWork.TrimCode; // トリムコード
                carManagementWork.TrimName = acceptOdrCarWork.TrimName; // トリム名称
                carManagementWork.FullModelFixedNoAry = acceptOdrCarWork.FullModelFixedNoAry; // フル型式固定番号配列
                // 2009/10/14 Add >>>
                carManagementWork.CarNote = acceptOdrCarWork.CarNote;   // 車輌備考
                // 2009/10/14 Add <<<
                carManagementWork.CategoryObjAry = acceptOdrCarWork.CategoryObjAry; // 装備オブジェクト配列
                carManagementWork.FreeSrchMdlFxdNoAry = acceptOdrCarWork.FreeSrchMdlFxdNoAry; // 自由検索型式固定番号配列 // ADD 2010/04/27
                carManagementWork.DomesticForeignCode = acceptOdrCarWork.DomesticForeignCode; // 国産/外車区分 // ADD 2013/03/21

                // CarRelationGuidの設定
                guid = Guid.NewGuid();
                carManagementWork.CarRelationGuid = guid;
                # endregion

            }
            catch (Exception)
            {
                guid = Guid.Empty;
                carManagementWork = null;
            }
            return (guid);
        }
        # endregion

        # region 売上情報再設定
        /// <summary>
        /// 売上情報再設定
        /// </summary>
        /// <param name="salesGrpAry">売上情報</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        private int SetSalesDBPara(ArrayList salesGrpAry, out string message)
        {
            //------------------------------------------------------------------------------------
            // データセット方法
            //------------------------------------------------------------------------------------
            //      --ArrayList                     売上リスト
            //          --SalesSlipWork             売上データオブジェクト
            //          --ArrayList                 売上明細リスト
            //              --SalesDetailWork       売上明細データオブジェクト
            //          --DepsitDataWork            入金データオブジェクト
            //          --DepositAlwWork            入金引当データオブジェクト
            //          --ArrayList                 伝票明細追加情報リスト
            //              --SlipDetailAddInfoWork 伝票明細追加情報オブジェクト
            //------------------------------------------------------------------------------------
            //変数の初期化
            int status = (int)EnumUoeConst.Status.ct_NORMAL;
            message = string.Empty;

            try
            {
                SalesSlipWork salesSlipWork = new SalesSlipWork();  //売上データオブジェクト
                ArrayList salesDetailWorkAry = new ArrayList();     //売上明細リスト

                foreach (ArrayList dtl in salesGrpAry)
                {
                    #region 元データ分解
                    //------------------------------------------------------
                    // 元データ分解
                    //------------------------------------------------------
                    foreach (object obj in dtl)
                    {
                        if (obj is SalesSlipWork)
                        {
                            salesSlipWork = (SalesSlipWork)obj;
                        }
                        else if (obj is ArrayList)
                        {
                            ArrayList list = (ArrayList)obj;
                            if (list[0] is AddUpOrgSalesDetailWork)
                            {
                            }
                            else if (list[0] is SalesDetailWork)
                            {
                                salesDetailWorkAry = list;
                            }
                        }
                    }
                    #endregion

                    #region 売上明細テーブル格納
                    //------------------------------------------------------
                    // 売上明細テーブル格納
                    //------------------------------------------------------
                    status = _uoeSndRcvJnlAcs.UpdateTableFromSalesDetailList(SalesDetailTable, salesDetailWorkAry, out message);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return (status);
                    }
                    #endregion

                    #region 売上データテーブル格納
                    //------------------------------------------------------
                    // 売上データテーブル格納
                    //------------------------------------------------------
                    string tempSalesSlipNum = _uoeSndRcvJnlAcs.GetTempSalesSlipNumFromSalesDetailWork(SalesDetailTable, (SalesDetailWork)salesDetailWorkAry[0]);
                    status = _uoeSndRcvJnlAcs.UpdateTableFromSalesSlipWork(SalesSlipTable, salesSlipWork, tempSalesSlipNum, out message);
                    #endregion
                }
            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
            }
            return (status);
        }
        # endregion

        # region 仕入情報データ再設定
        /// <summary>
        /// 仕入情報データ再設定
        /// </summary>
        /// <param name="stockGrpAry">仕入情報オブジェクト</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        private int SetStockDBPara(ArrayList stockGrpAry, out string message)
        {
            //------------------------------------------------------------------------------------
            // データセット方法
            //------------------------------------------------------------------------------------
            //      --ArrayList                     仕入リスト
            //          --StockSlipWork             仕入データオブジェクト
            //          --ArrayList                 仕入明細リスト
            //              --StockDetailWork       仕入明細データオブジェクト
            //          --ArrayList                 伝票明細追加情報リスト
            //              --SlipDetailAddInfoWork 伝票明細追加情報オブジェクト
            //------------------------------------------------------------------------------------
            //変数の初期化
            int status = (int)EnumUoeConst.Status.ct_NORMAL;
            message = string.Empty;

            try
            {
                StockSlipWork stockSlipWork = new StockSlipWork();  //仕入データオブジェクト
                ArrayList stockDetailWorkAry = new ArrayList();     //仕入明細リスト

                foreach (ArrayList dtl in stockGrpAry)
                {
                    #region 元データ分解
                    //------------------------------------------------------
                    // 元データ分解
                    //------------------------------------------------------
                    foreach (object obj in dtl)
                    {
                        if (obj is StockSlipWork)
                        {
                            stockSlipWork = (StockSlipWork)obj;
                        }
                        else if (obj is ArrayList)
                        {
                            ArrayList list = (ArrayList)obj;
                            if (list[0] is AddUpOrgStockDetailWork)
                            {
                            }
                            else if (list[0] is StockDetailWork)
                            {
                                stockDetailWorkAry = list;
                            }
                        }
                    }
                    #endregion

                    #region 仕入明細テーブル格納
                    //------------------------------------------------------
                    // 仕入明細テーブル格納
                    //------------------------------------------------------
                    status = _uoeSndRcvJnlAcs.UpdateTableFromStockDetailList(UoeStockDetailTable, stockDetailWorkAry, out message);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return (status);
                    }
                    #endregion

                    #region 仕入データテーブル格納
                    //------------------------------------------------------
                    // 仕入データテーブル格納
                    //------------------------------------------------------
                    StockDetailWork stockDetailWork = (StockDetailWork)stockDetailWorkAry[0];
                    string commonSlipNo = "";

                    status = _uoeSndRcvJnlAcs.ReadStockDetailWork(UoeStockDetailTable, stockDetailWork.SupplierFormal, stockDetailWork.DtlRelationGuid, out stockDetailWork, out commonSlipNo, out message);
                    if ((status == (int)EnumUoeConst.Status.ct_NORMAL) && (commonSlipNo != ""))
                    {
                        status = _uoeSndRcvJnlAcs.UpdateTableFromStockSlipWork(UoeStockSlipTable, stockSlipWork, commonSlipNo, out message);
                    }
                    #endregion
                }
            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
            }
            return (status);
        }
        # endregion
        # endregion

        #region ●売上・仕入データ保存
        /// <summary>
        /// 売上・仕入データ保存
        /// </summary>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        public int SaveDBData(out string message)
        {
            //------------------------------------------------------------------------------------
            // データセット方法
            //------------------------------------------------------------------------------------
            //  CustomSerializeArrayList            統合リスト
            //      --CustomSerializeArrayList      売上リスト
            //          --SalesSlipWork             売上データオブジェクト
            //          --ArrayList                 売上明細リスト
            //              --SalesDetailWork       売上明細データオブジェクト
            //          --DepsitDataWork            入金データオブジェクト
            //          --DepositAlwWork            入金引当データオブジェクト
            //          --ArrayList                 伝票明細追加情報リスト
            //              --SlipDetailAddInfoWork 伝票明細追加情報オブジェクト
            //      --CustomSerializeArrayList      仕入リスト
            //          --StockSlipWork             仕入データオブジェクト
            //          --ArrayList                 仕入明細リスト
            //              --StockDetailWork       仕入明細データオブジェクト
            //          --ArrayList                 伝票明細追加情報リスト
            //              --SlipDetailAddInfoWork 伝票明細追加情報オブジェクト
            //      --iOWriteCtrlOptWork            売上・仕入制御オプション
            //------------------------------------------------------------------------------------

            //変数の初期化
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = string.Empty;
            try
            {
                #region ●リモート参照用パラメータ
                CustomSerializeArrayList paraList = new CustomSerializeArrayList();         // 統合リスト
                //------------------------------------------------------
                // 売上情報リストパラメータ設定
                //------------------------------------------------------
                # region 売上情報リストパラメータ設定
                status = GetSsalesDBPara(ref paraList, out message);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return (status);
                }
                # endregion

                //------------------------------------------------------
                // 仕入情報リストパラメータ設定
                //------------------------------------------------------
                # region 仕入情報リストパラメータ設定
                status = GetStockDBPara(ref paraList, out message);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return (status);
                }
                # endregion

                //------------------------------------------------------
                // リモート参照用パラメータ
                //------------------------------------------------------
                # region リモート参照用パラメータ
                if (paraList.Count == 0)
                {
                    return (status);
                }
                IOWriteCtrlOptWork iOWriteCtrlOptWork = new IOWriteCtrlOptWork();                   // リモート参照用パラメータ
                this.SettingIOWriteCtrlOptWork(OptWorkSettingType.Write, out iOWriteCtrlOptWork); // リモート参照用パラメータ設定処理
                paraList.Add(iOWriteCtrlOptWork);
                #endregion
                #endregion

                #region ●更新処理
                //------------------------------------------------------
                // 更新処理
                //------------------------------------------------------
                // 保存用変数初期化
                string retItemInfo = string.Empty;
                object paraObj = (object)paraList;

                // 更新処理
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                do
                {
                    status = this._iIOWriteControlDB.Write(ref paraObj, out message, out retItemInfo);
                    if ((status == 850) || (status == 851) || (status == 852))
                    {
                        TMsgDisp.Show(
                            //this,
                            emErrorLevel.ERR_LEVEL_STOP,
                            "",
                            "シェアチェックエラー（拠点ロック）です。\r"
                            + "締処理か、処理が込み合っているためタイムアウトしました。\r"
                            + "再試行するか、しばらく待ってから再度処理を行ってください。\r",
                            status,
                            MessageBoxButtons.OK);
                    }
                }while ((status == 850) || (status == 851) || (status == 852));

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return(status);
                }
                #endregion

                // ---ADD 陳艶丹 2020/11/20 PMKOBETSU-4097の対応 ------>>>>
                // TSPインラインオプションが立っている時、且つ、システム区分 1:伝発
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && 
                    this.opt_TSP == (int)Broadleaf.Application.Controller.UOEOrderDtlAcs.Option.ON &&
                    this.uoeSndRcvCtlPara.SystemDivCd == (int)EnumUoeConst.ctSystemDivCd.ct_Slip)
                {
                    if (TspCprtStWorkList != null && TspCprtStWorkList.Count == 0)
                    {
                        // TSP連携マスタ設定情報
                        TspCprtStAcs tspCprtStAcs = new TspCprtStAcs();
                        TspCprtStWork tspCprtStWork = new TspCprtStWork();
                        try
                        {
                            // 企業コード
                            tspCprtStWork.EnterpriseCode = this._enterpriseCode;
                            // TSP連携マスタ設定情報取得
                            int statusTsp = tspCprtStAcs.Search(tspCprtStWork, out this.TspCprtStWorkList);
                            if (statusTsp != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                LogWrite("SaveDBData", "TSP連携マスタ設定情報取得に失敗しました。");
                            }
                        }
                        catch (Exception ex)
                        {
                            LogWrite("SaveDBData", "TSP連携マスタ設定情報取得に失敗しました、" + ex.Message.ToString());
                        }
                    }
                    // TSP連携マスタ設定情報設定ある場合
                    if (TspCprtStWorkList != null && TspCprtStWorkList.Count > 0)
                    {
                        bool tspCustomerCode = false;
                        SalesSlipWork salesSlip = new SalesSlipWork();
                        int tspSendCode = -1;
                        for (int i = 0; i < paraList.Count; i++)
                        {
                            if ((object)paraList[i] is CustomSerializeArrayList)
                            {
                                CustomSerializeArrayList list = (CustomSerializeArrayList)paraList[i];
                                foreach (object obj in list)
                                {
                                    if (obj is SalesSlipWork)
                                    {
                                        // 売上伝票データ取得
                                        salesSlip = (SalesSlipWork)obj;
                                        // 得意先コードが設定するの判断
                                        foreach (TspCprtStWork tspWork in TspCprtStWorkList)
                                        {
                                            if (tspWork.CustomerCode == salesSlip.CustomerCode && !salesSlip.PartySaleSlipNum.Equals(string.Empty))
                                            {
                                                tspCustomerCode = true;
                                                tspSendCode = tspWork.SendCode;
                                                break;
                                            }
                                        }
                                    }

                                    if (tspCustomerCode)
                                    {
                                        break;
                                    }
                                }
                            }
                            if (tspCustomerCode)
                            {
                                break;
                            }
                        }

                        if (tspCustomerCode)
                        {
                            WriteTspSdRvDataAcs tspAcs = new WriteTspSdRvDataAcs();
                            try
                            {
                                // ---UPD 呉元嘯 2020/12/21 PMKOBETSU-4097の対応 ------>>>>
                                //bool tspFlg = tspAcs.GetTspSdRvData((CustomSerializeArrayList)paraObj, 1, this.TspCprtStWorkList);
                                // ---UPD 呉元嘯 2020/12/21 PMKOBETSU-4097の対応 ------<<<<
                                bool dataFlg = false;
                                bool tspFlg = tspAcs.GetTspSdRvData((CustomSerializeArrayList)paraObj, 1, this.TspCprtStWorkList, out dataFlg);
                                if (!tspFlg)
                                {
                                    LogWrite("SaveDBData", "TSP送信データ作成に失敗しました、\\Log\\TSP送信データ作成\\PMTSP01201A.Logを確認してください。");
                                }
                                else
                                {
                                    // ---ADD 呉元嘯 2020/12/21 PMKOBETSU-4097の対応 ------>>>>
                                    if (!dataFlg)
                                    {
                                         LogWrite("SaveDBData", "TSP送信対象ではない。");
                                    }
                                    else
                                    {
                                    // ---ADD 呉元嘯 2020/12/21 PMKOBETSU-4097の対応 ------<<<<
                                        LogWrite("SaveDBData", "TSP送信データを作成しました。");
                                        if (tspSendCode == 0)
                                        {
                                            //起動時パラメータ
                                            string param = Environment.GetCommandLineArgs()[1] + " " +
                                                           Environment.GetCommandLineArgs()[2];
                                            // 送信区分は「0：自動」
                                            // TSP.NS自動送信処理
                                            Process.Start("PMTSP01100U.EXE", param + " /A");
                                        }
                                    }// ADD 呉元嘯 2020/12/21 PMKOBETSU-4097の対応
                                }
                            }
                            catch (Exception ex)
                            {
                                LogWrite("SaveDBData", "TSP送信データ作成に失敗しました、" + ex.Message.ToString());
                            }
                        }
                    }
                }
                // ---ADD 陳艶丹 2020/11/20 PMKOBETSU-4097の対応 ------<<<<

                #region ●更新後処理
                //------------------------------------------------------
                // 更新後処理
                //------------------------------------------------------
                #region データ分割
                //データ分割
                ArrayList salesGrpAry = new ArrayList();// 売上データ(伝票リスト情報)
                ArrayList acptGrpAry = new ArrayList(); // 受注データ(伝票リスト情報)
                ArrayList stockGrpAry = new ArrayList();// 仕入データ(伝票リスト情報)
                DivisionSalesSlipCustomSerializeArrayList.DivisionCustomSerializeArrayListForWriting(
                                                                (CustomSerializeArrayList)paraObj,
                                                                out salesGrpAry,
                                                                out acptGrpAry,
                                                                out stockGrpAry);
                #endregion

                //------------------------------------------------------
                // 売上情報リストパラメータ戻し
                //------------------------------------------------------
                #region 売上情報リストパラメータ戻し
                status = SetSalesDBPara(salesGrpAry, out message);
                if (status != (int)EnumUoeConst.Status.ct_NORMAL)
                {
                    return (status);
                }
                #endregion

                //------------------------------------------------------
                // 仕入情報リストパラメータ戻し
                //------------------------------------------------------
                #region 仕入情報リストパラメータ戻し
                SetStockDBPara(stockGrpAry, out message);
                #endregion

                #endregion
            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
            }
            return(status);
        }
        # endregion

        # region ●リモート参照用パラメータ設定処理
        /// <summary>
        /// リモート参照用パラメータ設定処理
        /// </summary>
        /// <param name="optWorkSettinType"></param>
        /// <param name="iOWriteCtrlOptWork"></param>
        private void SettingIOWriteCtrlOptWork(OptWorkSettingType optWorkSettinType, out IOWriteCtrlOptWork iOWriteCtrlOptWork)
        {
            iOWriteCtrlOptWork = new IOWriteCtrlOptWork();
            iOWriteCtrlOptWork.CtrlStartingPoint = (int)IOWriteCtrlOptCtrlStartingPoint.Sales;                        // 制御起点(0:売上 1:仕入 2:仕入売上同時計上)
            iOWriteCtrlOptWork.AcpOdrrAddUpRemDiv = this._uoeSndRcvCtlInitAcs.GetSalesTtlSt().AcpOdrrAddUpRemDiv;     // 受注データ計上残区分
            iOWriteCtrlOptWork.ShipmAddUpRemDiv = this._uoeSndRcvCtlInitAcs.GetSalesTtlSt().ShipmAddUpRemDiv;         // 出荷データ計上残区分
            iOWriteCtrlOptWork.EstimateAddUpRemDiv = this._uoeSndRcvCtlInitAcs.GetSalesTtlSt().EstmateAddUpRemDiv;    // 見積データ計上残区分
            iOWriteCtrlOptWork.RetGoodsStockEtyDiv = this._uoeSndRcvCtlInitAcs.GetSalesTtlSt().RetGoodsStockEtyDiv;   // 返品時在庫登録区分
            iOWriteCtrlOptWork.RemainCntMngDiv = this._uoeSndRcvCtlInitAcs.GetAllDefSet().RemainCntMngDiv;            // 残数管理区分
            iOWriteCtrlOptWork.SupplierSlipDelDiv = this._uoeSndRcvCtlInitAcs.GetSalesTtlSt().SupplierSlipDelDiv;     // 仕入伝票削除区分
            iOWriteCtrlOptWork.CarMngDivCd = 0;                                                                       // 車両管理マスタ登録区分(0:登録しない 1:登録する)
            switch (optWorkSettinType)
            {
                case OptWorkSettingType.Write:
                    break;
                case OptWorkSettingType.Read:
                    break;
                case OptWorkSettingType.Delete:
                    if (this._uoeSndRcvCtlInitAcs.GetSalesTtlSt().SupplierSlipDelDiv == 1)
                    {
                        iOWriteCtrlOptWork.SupplierSlipDelDiv = this._supplierSlipDelDiv; // 仕入伝票削除区分
                    }
                    break;
            }
        }
        # endregion

        // ---ADD 陳艶丹 2020/11/20 PMKOBETSU-4097の対応 ------>>>>
        #region
        /// <summary>
        /// ログ出力処理
        /// </summary>
        /// <param name="methodName">メソッド名</param>
        /// <param name="pMsg">エラーメッセージ</param>
        /// <remarks>
        /// <br>Note       : エラーログを書きます。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/11/20</br>
        /// </remarks>
        public void LogWrite(string methodName, string pMsg)
        {
            System.IO.FileStream fs;										// ファイルストリーム
            System.IO.StreamWriter sw;										// ストリームwriter
            // Logフォルダー
            string logFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "Log");
            if (!Directory.Exists(logFolderPath))
            {
                // Logフォルダーが存在しない場合、作成する
                Directory.CreateDirectory(logFolderPath);
            }
            // ログファイル
            string logFilePath = Path.Combine(logFolderPath, "TSP送信データ作成");
            if (!Directory.Exists(logFilePath))
            {
                // Logフォルダーが存在しない場合、作成する
                Directory.CreateDirectory(logFilePath);
            }
            string logFilePathName = Path.Combine(logFilePath, "PMUOE01040A.Log");
            fs = new FileStream(logFilePathName, FileMode.Append, FileAccess.Write, FileShare.Write);
            sw = new System.IO.StreamWriter(fs, System.Text.Encoding.GetEncoding("shift_jis"));
            string log = string.Format("{0},{1},{2}", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), methodName, pMsg);
            sw.WriteLine(log);
            if (sw != null)
                sw.Close();
            if (fs != null)
                fs.Close();
        }
        # endregion
        // ---ADD 陳艶丹 2020/11/20 PMKOBETSU-4097の対応 ------<<<<
        # endregion
    }
}
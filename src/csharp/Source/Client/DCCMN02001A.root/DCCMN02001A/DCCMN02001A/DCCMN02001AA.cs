using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Collections;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 伝票印刷アクセスクラス
    /// </summary>
    /// <remarks>
    /// Note       : 伝票印刷部品用のアクセスクラスです<br />
    /// Programmer : 22018 鈴木 正臣<br />                                   
    /// Date       : 2007.12.27<br />                                      
    /// <br />
    /// Update Note: 2008.05.29 鈴木 正臣<br />
    ///                ①PM.NS向け変更。<br />
    ///                　（※リモート処理一本化とＵＩクラスとの機能分担見直しに伴い、全体的に大幅な変更）<br />
    /// Update Note: 2009.08.13  20056 對馬 大輔</br>
    ///            : サーバーへ配置するクライアントアセンブリ対応</br>
    ///            : ①サービス起動時の端末設定取得メソッド追加</br>
    /// Update Note: 2009.09.08 鈴木 正臣<br />
    ///                ①全体初期表示設定の取得で全社設定が取得出来ない不具合の修正<br />
    /// Update Note: 2010/03/04 大矢 睦美<br/>
    ///            :   税率設定、売上金額処理区分設定取得
    /// Update Note: 2010/03/31 大矢 睦美<br/>
    ///            :   Mantis【14813】全体初期設定取得
    /// Update Note: 2010/03/30　21024　佐々木 健<br/>
    ///            : SCM対応として、2008.08.13分の組み込み（2010/03/30で検索してください）
    /// Update Note: 2010/05/14 鈴木 正臣<br/>
    ///            :   サブレポート機能の追加。（森川個別対応の為、追加）
    /// Update Note: 2010/05/18 大矢 睦美<br/>
    ///            :   森川部品個別対応
    /// Update Note: 2010/06/04 鈴木 正臣<br />
    ///                成果物統合<br />
    ///                　ＳＣＭ 2009.08.13 の組込<br />
    ///                　ＳＣＭ 2010/03/30 の組込<br />
    /// Update Note: 2011/07/29 豆昌紅<br/>
    ///            :   自動回答区分(SCM)追加
    /// Update Note: 2010/08/09  周正雨</br>
    ///            : PCCUOE </br>
    ///            : リモート伝票発行</br>
    ///            :   自動回答区分(SCM)追加
    /// Update Note: 2013/06/17  zhubj</br>
    ///            : Redmine #36594</br>
    ///            : №10542 SCM</br>
    /// Update Note: 2013/07/28  zhubj</br>
    ///            : Redmine #36594</br>
    ///            : №10542 SCM NO.10の対応</br>
    /// Update Note: 2014/10/27 wangf <br />
    /// 管理番号   : 11070149-00<br />
    ///            : Redmine#43854「移動伝票出力先区分」よりプリンタ検索<br />
    /// </remarks>
    public class SlipPrintAcs
    {
        # region [private const]
        // 拠点ゼロ
        private const string ct_SectionZero = "00";
        // 倉庫ゼロ
        private const string ct_WarehouseZero = "0000";
        // 得意先ゼロ
        private const int ct_CustomerZero = 0;
        // レジ番号ゼロ
        private const int ct_CashRegisterZero = 0;
        // --- ADD  大矢睦美  2010/03/04 ---------->>>>>
        private const int ct_TaxRateCodeZero = 0;
        // --- ADD  大矢睦美  2010/03/04 ----------<<<<<

        # endregion

        # region [private fields]
        // 企業コード
        private string _enterpriseCode;
        // 拠点コード(ログイン担当者所属拠点)
        private string _loginSectionCode;
        // 復号化済み自由帳票印字位置設定キーリスト
        private Dictionary<string, bool> _decryptedFrePrtPSetDic;
        // 端末設定
        private PosTerminalMg _posTerminalMg;
        // プリンタ設定アクセスクラス
        private PrtManageAcs _prtManageAcs;
        // 伝票印刷設定リスト（全件）
        private List<SlipPrtSetWork> _slipPrtSetWorkList;
        // 得意先マスタ伝票管理（伝票タイプ管理マスタ）リスト
        private List<CustSlipMngWork> _custSlipMngWorkList;
        // 伝票出力先設定リスト
        private List<SlipOutputSetWork> _slipOutputSetWorkList;
        // 自由帳票印刷位置設定リスト
        private List<FrePrtPSetWork> _frePrtPSetWorkList;
        // 売上全体設定リスト
        private List<SalesTtlStWork> _salesTtlStWorkList;
        // 全体初期表示設定リスト
        private List<AllDefSetWork> _allDefSetWorkList;
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/31 ADD
        // 在庫管理全体設定リスト
        private List<StockMngTtlStWork> _stockMngTtlStWorkList;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/31 ADD
        // --- ADD  大矢睦美  2010/03/04 ---------->>>>>
        //税率設定リスト
        private List<TaxRateSetWork> _taxRateSetWorkList;
        //売上金額処理区分設定リスト
        private List<SalesProcMoneyWork> _salesProcMoneyList;
        // --- ADD  大矢睦美  2010/03/04 ----------<<<<<
        // --- ADD  大矢睦美  2010/05/18 ---------->>>>>
        //UOEガイド名称設定
        private List<UOEGuideNameWork> _uoeGuideNameWorkList;
        // --- ADD  大矢睦美  2010/05/18 ----------<<<<<

        // 伝票印刷アクセスクラス・ステータス
        private SlipAcsStatus _slipAcsState;
        // add by zhouzy for PCCUOEリモート伝票発行 20110811 begin
        /// <summary>
        /// リモート伝票発行するか
        /// </summary>
        private bool _IsRmSlpPrt;
        /// <summary>
        /// リモート伝票発行設定マスタ
        /// </summary>
        private RmSlpPrtStWork _rmSlpPrtStWork = null;
        /// <summary>
        /// リモート伝発設定マスタ
        /// </summary>
        private List<RmSlpPrtStWork> _rmSlpPrtStWorkList = null; 
        // add by zhouzy for PCCUOEリモート伝票発行 20110811  end
        # endregion

        # region [public propaties]
        /// <summary>
        /// 伝票印刷アクセスクラス・ステータス
        /// </summary>
        public SlipAcsStatus SlipAcsState
        {
            get { return _slipAcsState; }
        }
        // add by zhouzy for PCCUOEリモート伝票発行 20110811 begin
        /// <summary>
        /// リモート伝票発行プロパティ
        /// </summary>
        public bool IsRmSlpPrt
        {
            get { return this._IsRmSlpPrt; }
            set { this._IsRmSlpPrt = value; }
        }
        /// <summary>
        /// リモート伝票発行設定マスタプロパティ
        /// </summary>
        public RmSlpPrtStWork RmSlpPrtStWork
        {
            get { return this._rmSlpPrtStWork; }
            set { this._rmSlpPrtStWork = value; }
        }
        /// <summary>
        /// リモート伝発設定マスタプロパティ
        /// </summary>
        public List<RmSlpPrtStWork> RmSlpPrtStWorkList
        {
            get { return this._rmSlpPrtStWorkList; }
            set { this._rmSlpPrtStWorkList = value; }
        }
        // add by zhouzy for PCCUOEリモート伝票発行 20110811  end

        // --------------- ADD END 2013/07/28 zhubj FOR Redmine #36594--------<<<<
        /// <summary>ＰＭ側印刷伝票分割フラグ</summary>
        /// <summary>印刷伝票分割表示：true、その他：false</summary>
        public bool IsPrintSplit
        {
            get { return false; }
        }
        // --------------- ADD END 2013/07/28 zhubj FOR Redmine #36594--------<<<<
        # endregion

        # region [コンストラクタ]
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public SlipPrintAcs( string enterpriseCode, string loginSectionCode )
       {
            _enterpriseCode = enterpriseCode;
            _loginSectionCode = loginSectionCode;
            _prtManageAcs = new PrtManageAcs();

            _slipAcsState = SlipAcsStatus.Normal;                        
        }
        # endregion

        # region [Search]
        # region [Search売上]

        // 2010/03/30 Add >>>
        /// <summary>
        /// 初期検索（売上伝票）
        /// </summary>
        /// <param name="paraWork"></param>
        /// <param name="printDataList"></param>
        /// <returns></returns>
        public int InitialSearchFrePSalesSlip( FrePSalesSlipParaWork paraWork, ref List<List<ArrayList>> printDataList )
        {
            return this.InitialSearchFrePSalesSlip( paraWork, ref printDataList, 0 );
        }
        // 2010/03/30 Add <<<

        /// <summary>
        /// 初期検索（売上伝票）
        /// </summary>
        /// <param name="paraWork"></param>
        /// <param name="printDataList"></param>
        /// <returns></returns>      
        // 2010/03/30 >>>
        //public int InitialSearchFrePSalesSlip( FrePSalesSlipParaWork paraWork, ref List<List<ArrayList>> printDataList )
        public int InitialSearchFrePSalesSlip( FrePSalesSlipParaWork paraWork, ref List<List<ArrayList>> printDataList, int isService )
        // 2010/03/30 <<<
        {
            //// 企業コード退避
            //_enterpriseCode = paraWork.EnterpriseCode;

            // 復号化済み自由帳票印字位置設定ディクショナリ初期化
            _decryptedFrePrtPSetDic = new Dictionary<string, bool>();
            
            // 端末設定取得
            // 2010/03/30 >>>
            //int status = GetPosTerminalMg( out _posTerminalMg, _enterpriseCode );

            int status = 0;
            if ( isService == 0 )
            {
                status = GetPosTerminalMg( out _posTerminalMg, _enterpriseCode );
            }
            else
            {
                status = GetPosTerminalMgServer( out _posTerminalMg, _enterpriseCode );
            }
            // 2010/03/30 <<<
            if ( status != 0 )
            {
                _slipAcsState = SlipAcsStatus.Error_NoTerminalMg;
                return status;
            }

            // ユーザーDB検索処理
            List<ArrayList> printData = null;
            List<object> masterList = null;
            status = SearchFrePSalesSlip( paraWork, ref printData, ref masterList );
            if ( status != 0 )
            {
                _slipAcsState = SlipAcsStatus.Error_SearchSlip;
                return status;
            }

            // マスタリスト展開
            # region [マスタリスト展開]
            for ( int index = 0; index < masterList.Count; index++ )
            {
                if ( masterList[index] is SlipPrtSetWork[] )
                {
                    // 伝票印刷設定リスト生成
                    _slipPrtSetWorkList = new List<SlipPrtSetWork>( (SlipPrtSetWork[])masterList[index] );
                }
                else if ( masterList[index] is FrePrtPSetWork[] )
                {
                    // 自由帳票印字位置設定リスト生成
                    _frePrtPSetWorkList = new List<FrePrtPSetWork>( (FrePrtPSetWork[])masterList[index] );
                }
                else if ( masterList[index] is CustSlipMngWork[] )
                {
                    // 得意先マスタ伝票管理（伝票タイプ管理マスタ）リスト生成
                    _custSlipMngWorkList = new List<CustSlipMngWork>( (CustSlipMngWork[])masterList[index] );
                }
                else if ( masterList[index] is SlipOutputSetWork[] )
                {
                    // 伝票出力先設定リスト作成
                    _slipOutputSetWorkList = new List<SlipOutputSetWork>( (SlipOutputSetWork[])masterList[index] );
                }
                else if ( masterList[index] is SalesTtlStWork[] )
                {
                    // 売上全体設定リスト作成
                    _salesTtlStWorkList = new List<SalesTtlStWork>( (SalesTtlStWork[])masterList[index] );
                }
                else if ( masterList[index] is AllDefSetWork[] )
                {
                    // 全体初期表示設定リスト作成
                    _allDefSetWorkList = new List<AllDefSetWork>( (AllDefSetWork[])masterList[index] );
                }
                // --- ADD  大矢睦美  2010/03/04 ---------->>>>>
                else if (masterList[index] is TaxRateSetWork[])
                {
                    //税率設定リスト作成
                    _taxRateSetWorkList = new List<TaxRateSetWork>((TaxRateSetWork[])masterList[index]);
                }
                else if (masterList[index] is SalesProcMoneyWork[])
                {
                    //売上金額処理区分設定リスト作成
                    _salesProcMoneyList = new List<SalesProcMoneyWork>((SalesProcMoneyWork[])masterList[index]);
                }
                // --- ADD  大矢睦美  2010/03/04 ----------<<<<<
                // --- ADD  大矢睦美  2010/05/18 ---------->>>>>
                else if (masterList[index] is UOEGuideNameWork[])
                {
                    //UOEガイド名称設定リスト作成
                    _uoeGuideNameWorkList = new List<UOEGuideNameWork>((UOEGuideNameWork[])masterList[index]);
                }
                // --- ADD  大矢睦美  2010/05/18 ----------<<<<<
            }
            // add by zhouzy for PCCUOEリモート伝票発行 20110811 begin
            //リモート伝票発行の場合
            if (this._IsRmSlpPrt) {
                RmSlpPrtStWork rmSlpPrtStWorkParam = new RmSlpPrtStWork();
                rmSlpPrtStWorkParam.InqOtherEpCd=this._enterpriseCode;
                IRmSlpPrtStDB iRmSlpPrtStDB;
                iRmSlpPrtStDB = MediationRmSlpPrtStDB.GetRmSlpPrtStDB();
                object rmSlpPrtStWorkObj;

                _rmSlpPrtStWorkList = null;
                try
                {
                    //指定された条件のリモート伝発設定マスタマスタ情報LISTを戻します
                    status = iRmSlpPrtStDB.Search(out rmSlpPrtStWorkObj, rmSlpPrtStWorkParam, 0, ConstantManagement.LogicalMode.GetData0);
                    //結果を戻す
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }
                    ArrayList rmSlpPrtStWorkArrayList = rmSlpPrtStWorkObj as ArrayList;
                    _rmSlpPrtStWorkList = new List<RmSlpPrtStWork>();
                    if (null != rmSlpPrtStWorkArrayList && rmSlpPrtStWorkArrayList.Count > 0)
                    {
                        for (int i = 0; i < rmSlpPrtStWorkArrayList.Count; i++)
                        {
                            _rmSlpPrtStWorkList.Add((RmSlpPrtStWork)rmSlpPrtStWorkArrayList[i]);
                        }
                        
                    }
                }
                catch(Exception e) {
                    return -1;
                }
            }
            // add by zhouzy for PCCUOEリモート伝票発行 20110811  end
            # endregion

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/01 DEL
            //// 返却データ編集①提供DB検索・適用処理
            //ReflectSalesSlipOfferSet( ref printData );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/01 DEL

            // 返却データ編集②印刷先プリンタ確定
            ReflectSalesSlipOutputPrinterSet( ref printData );


            // 返却データ編集③Key別分別 (同一受注ステータス、同一プリンタでまとめる)
            # region [Key別分別]
            Dictionary<SalesSlipListKey, List<ArrayList>> slipListDic = new Dictionary<SalesSlipListKey, List<ArrayList>>();
            Dictionary<RmSalesSlipListKey, List<ArrayList>> rmSlipListDic = new Dictionary<RmSalesSlipListKey, List<ArrayList>>();//ADD 2013/06/17 zhubj FOR Redmine #36594
            for ( int index = 0; index < printData.Count; index++ )
            {
                # region DEL 2013/06/17 zhubj FOR Redmine #36594
                //// キー生成
                //SalesSlipListKey key = new SalesSlipListKey( (printData[index][0]) as FrePSalesSlipWork );
                //if ( !slipListDic.ContainsKey( key ) )
                //{
                //    // 新リスト追加
                //    slipListDic.Add( key, new List<ArrayList>() );
                //}
                //// リストに追加
                //slipListDic[key].Add( printData[index] );
                # endregion

                // --------------- ADD START 2013/06/17 zhubj FOR Redmine #36594-------->>>>
                if (this._IsRmSlpPrt)
                {
                    // キー生成
                    RmSalesSlipListKey key = new RmSalesSlipListKey((printData[index][0]) as FrePSalesSlipWork);

                    if (!rmSlipListDic.ContainsKey(key))
                    {
                        // 新リスト追加
                        rmSlipListDic.Add(key, new List<ArrayList>());
                    }
                    // リストに追加
                    rmSlipListDic[key].Add(printData[index]);
                }
                else
                {
                    // キー生成
                    SalesSlipListKey key = new SalesSlipListKey((printData[index][0]) as FrePSalesSlipWork);

                    if (!slipListDic.ContainsKey(key))
                    {
                        // 新リスト追加
                        slipListDic.Add(key, new List<ArrayList>());
                    }
                    // リストに追加
                    slipListDic[key].Add(printData[index]);
                }
                // --------------- ADD END 2013/06/17 zhubj FOR Redmine #36594--------<<<<
            }
            // ディクショナリからリストに移行
            printDataList = new List<List<ArrayList>>();
            # region DEL 2013/06/17 zhubj FOR Redmine #36594
            //foreach ( List<ArrayList> slipList in slipListDic.Values )
            //{
            //    printDataList.Add( slipList );
            //}
            #endregion
            // --------------- ADD START 2013/06/17 zhubj FOR Redmine #36594-------->>>>
            if (this._IsRmSlpPrt)
            {
                foreach (List<ArrayList> slipList in rmSlipListDic.Values)
                {
                    printDataList.Add(slipList);
                }
            }
            else
            {
                foreach (List<ArrayList> slipList in slipListDic.Values)
                {
                    printDataList.Add(slipList);
                }
            }
            // --------------- ADD END 2013/06/17 zhubj FOR Redmine #36594--------<<<<
            # endregion

            return status;
        }

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/01 DEL
        # region //DEL
        ///// <summary>
        ///// 提供データ検索・適用処理
        ///// </summary>
        ///// <param name="printData"></param>
        //private void ReflectSalesSlipOfferSet( ref List<ArrayList> printData )
        //{
        //    //************************************************************************
        //    // メモ：
        //    //   ・伝票データを走査して、必要な提供データ検索情報を収集します。
        //    //   ・全データをリスト化してリモートに渡すことで、１回のリモート呼び出しで、
        //    //   　必要な全提供データ抽出を実現します。
        //    // 　・リモート終了後、伝票データに対して適用する必要がありますが、
        //    //  　 予め適用伝票・明細それぞれのリストを生成しておき、
        //    //   　対象のレコードのみを更新する事で高速化を図ります。
        //    //************************************************************************

        //    // 提供リモートパラメータ
        //    CustomSerializeArrayList offerWorkList = new CustomSerializeArrayList();
            
        //    // 提供ＢＬコード検索リスト
        //    List<TbsPartsCodeWork> selectTbsPartsCodeList = new List<TbsPartsCodeWork>();
        //    // 提供部品メーカー検索リスト
        //    List<PMakerNmWork> selectPMakerNmWorkList = new List<PMakerNmWork>();


        //    // 適用対象レコードキー（現在は提供データを結合するのは明細のみです）
        //    //List<int> refOfferSlipKeyList = new List<int>();
        //    List<RefOfferDetailKey> refOfferDetailKeyList = new List<RefOfferDetailKey>();


        //    //-----------------------------------------------------------
        //    // 検索キー取得
        //    //-----------------------------------------------------------
        //    # region [検索キー取得]
        //    for ( int slipIndex = 0; slipIndex < printData.Count; slipIndex++ )
        //    {
        //        //// 売上伝票データ
        //        //FrePSalesSlipWork slip = (FrePSalesSlipWork)(printData[slipIndex][0]);

        //        // 売上明細データList
        //        List<FrePSalesDetailWork> detailList = (List<FrePSalesDetailWork>)(printData[slipIndex][1]);
        //        for ( int detailIndex = 0; detailIndex < detailList.Count; detailIndex++ )
        //        {
        //            FrePSalesDetailWork detail = detailList[detailIndex];

        //            // ＢＬコード名称チェック
        //            # region [提供ＢＬ]
        //            if ( detail.BLGOODSCDURF_BLGOODSCODERF == 0 )
        //            {
        //                // 検索キーリストに追加
        //                TbsPartsCodeWork tbsPartsCodeWork = new TbsPartsCodeWork();
        //                tbsPartsCodeWork.TbsPartsCode = detail.SALESDETAILRF_BLGOODSCODERF;
        //                selectTbsPartsCodeList.Add( tbsPartsCodeWork );

        //                // 適用キーに追加
        //                if ( !refOfferDetailKeyList.Contains( new RefOfferDetailKey( slipIndex, detailIndex ) ) )
        //                {
        //                    refOfferDetailKeyList.Add( new RefOfferDetailKey( slipIndex, detailIndex ) );
        //                }
        //            }
        //            # endregion

        //            // 部品メーカー名称チェック
        //            # region [提供部品メーカー(部品)]
        //            if ( detail.MAKGDS_GOODSMAKERCDRF == 0 )
        //            {
        //                // 検索キーリストに追加
        //                PMakerNmWork pMakerNmWork = new PMakerNmWork();
        //                pMakerNmWork.PartsMakerCode = detail.SALESDETAILRF_GOODSMAKERCDRF;
        //                selectPMakerNmWorkList.Add( pMakerNmWork );

        //                // 適用キーに追加
        //                if ( !refOfferDetailKeyList.Contains( new RefOfferDetailKey( slipIndex, detailIndex ) ) )
        //                {
        //                    refOfferDetailKeyList.Add( new RefOfferDetailKey( slipIndex, detailIndex ) );
        //                }
        //            }
        //            # endregion

        //            // 一式メーカー名称チェック
        //            # region [提供部品メーカー(一式)]
        //            if ( detail.MAKCMP_GOODSMAKERCDRF == 0 )
        //            {
        //                // 検索キーリストに追加
        //                PMakerNmWork pMakerNmWork = new PMakerNmWork();
        //                pMakerNmWork.PartsMakerCode = detail.SALESDETAILRF_CMPLTGOODSMAKERCDRF;
        //                selectPMakerNmWorkList.Add( pMakerNmWork );

        //                // 適用キーに追加
        //                if ( !refOfferDetailKeyList.Contains( new RefOfferDetailKey( slipIndex, detailIndex ) ) )
        //                {
        //                    refOfferDetailKeyList.Add( new RefOfferDetailKey( slipIndex, detailIndex ) );
        //                }
        //            }
        //            # endregion
        //        }
        //    }

        //    // 提供ＢＬコード検索リスト
        //    if ( selectTbsPartsCodeList.Count > 0 )
        //    {
        //        offerWorkList.Add( selectTbsPartsCodeList.ToArray() );
        //    }
        //    // 提供部品メーカー検索リスト
        //    if ( selectPMakerNmWorkList.Count > 0 )
        //    {
        //        offerWorkList.Add( selectPMakerNmWorkList.ToArray() );
        //    }

        //    # endregion

        //    // 提供検索が不要ならばここで終了
        //    if ( offerWorkList.Count == 0 ) return;

        //    //-----------------------------------------------------------
        //    // 検索
        //    //-----------------------------------------------------------
        //    // リモートオブジェクト取得
        //    IFrePSalesSlipOfferDB iFrePSalesSlipOfferDB = MediationFrePSalesSlipOfferDB.GetFrePSalesSlipOfferDB();

        //    bool msgDiv;
        //    string errMsg;
        //    object retObj = offerWorkList;
        //    int status = iFrePSalesSlipOfferDB.SearchFrePSalesSlipOffer( ref retObj, out msgDiv, out errMsg );
        //    if ( status != 0 || retObj == null || ( retObj as CustomSerializeArrayList ).Count == 0 )
        //    {
        //        // 検索失敗or該当なしならここで終了
        //        return;
        //    }

        //    // 検索結果ディクショナリ生成
        //    Dictionary<int, TbsPartsCodeWork> tbsPartsCodeWorkDic = new Dictionary<int, TbsPartsCodeWork>();
        //    Dictionary<int, PMakerNmWork> pMakerNmWorkDic = new Dictionary<int, PMakerNmWork>();

        //    # region [検索結果ディクショナリ生成]
        //    foreach ( object obj in (retObj as CustomSerializeArrayList) )
        //    {
        //        if ( obj is TbsPartsCodeWork[] )
        //        {
        //            foreach ( TbsPartsCodeWork work in (obj as TbsPartsCodeWork[]) )
        //            {
        //                if ( !tbsPartsCodeWorkDic.ContainsKey( work.TbsPartsCode ) )
        //                {
        //                    tbsPartsCodeWorkDic.Add( work.TbsPartsCode, work );
        //                }
        //            }
        //        }
        //        else if ( obj is PMakerNmWork[] )
        //        {
        //            foreach ( PMakerNmWork work in (obj as PMakerNmWork[]) )
        //            {
        //                if ( !pMakerNmWorkDic.ContainsKey( work.PartsMakerCode ) )
        //                {
        //                    pMakerNmWorkDic.Add( work.PartsMakerCode, work );
        //                }
        //            }
        //        }
        //    }
        //    # endregion

        //    //-----------------------------------------------------------
        //    // 一括適用
        //    //-----------------------------------------------------------
        //    # region [一括適用]
        //    //foreach ( int slipIndex in refOfferSlipKeyList )
        //    //{
        //    //    // 売上伝票データ
        //    //    FrePSalesSlipWork slip = (FrePSalesSlipWork)(printData[slipIndex][0]);
        //    //}

        //    // 売上明細データList
        //    foreach ( RefOfferDetailKey refKey in refOfferDetailKeyList )
        //    {
        //        FrePSalesDetailWork detail = ((List<FrePSalesDetailWork>)(((ArrayList)printData[refKey.SlipIndex])[1]))[refKey.DetailIndex];

        //        // ＢＬコード名称
        //        # region [提供ＢＬ]
        //        if ( detail.BLGOODSCDURF_BLGOODSCODERF == 0 )
        //        {
        //            if ( tbsPartsCodeWorkDic.ContainsKey( detail.SALESDETAILRF_BLGOODSCODERF ) )
        //            {
        //                detail.SALESDETAILRF_BLGOODSFULLNAMERF = tbsPartsCodeWorkDic[detail.SALESDETAILRF_BLGOODSCODERF].TbsPartsFullName;
        //            }
        //        }
        //        # endregion

        //        // 部品メーカー名称
        //        # region [提供部品メーカー(部品)]
        //        if ( detail.MAKGDS_GOODSMAKERCDRF == 0 )
        //        {
        //            if ( pMakerNmWorkDic.ContainsKey( detail.SALESDETAILRF_GOODSMAKERCDRF ) )
        //            {
        //                detail.MAKGDS_MAKERKANANAMERF = pMakerNmWorkDic[detail.SALESDETAILRF_GOODSMAKERCDRF].PartsMakerHalfName;
        //                detail.MAKGDS_MAKERSHORTNAMERF = pMakerNmWorkDic[detail.SALESDETAILRF_GOODSMAKERCDRF].PartsMakerFullName;
        //            }
        //        }
        //        # endregion

        //        // 一式メーカー名称
        //        # region [提供部品メーカー(一式)]
        //        if ( detail.MAKCMP_GOODSMAKERCDRF == 0 )
        //        {
        //            if ( pMakerNmWorkDic.ContainsKey( detail.SALESDETAILRF_CMPLTGOODSMAKERCDRF ) )
        //            {
        //                detail.MAKCMP_MAKERKANANAMERF = pMakerNmWorkDic[detail.SALESDETAILRF_CMPLTGOODSMAKERCDRF].PartsMakerHalfName;
        //                detail.MAKCMP_MAKERSHORTNAMERF = pMakerNmWorkDic[detail.SALESDETAILRF_CMPLTGOODSMAKERCDRF].PartsMakerFullName;
        //            }
        //        }
        //        # endregion
        //    }
        //    # endregion
        //}

        //# region [提供データ適用明細キー]
        ///// <summary>
        ///// 提供データ適用明細キー
        ///// </summary>
        //private struct RefOfferDetailKey
        //{
        //    /// <summary>伝票index</summary>
        //    private int _slipIndex;
        //    /// <summary>明細index</summary>
        //    private int _detailIndex;
        //    /// <summary>
        //    /// 伝票index
        //    /// </summary>
        //    public int SlipIndex
        //    {
        //        get { return _slipIndex; }
        //        set { _slipIndex = value; }
        //    }
        //    /// <summary>
        //    /// 明細index
        //    /// </summary>
        //    public int DetailIndex
        //    {
        //        get { return _detailIndex; }
        //        set { _detailIndex = value; }
        //    }
        //    /// <summary>
        //    /// コンストラクタ
        //    /// </summary>
        //    /// <param name="slipIndex">伝票index</param>
        //    /// <param name="detailIndex">明細index</param>
        //    public RefOfferDetailKey( int slipIndex, int detailIndex )
        //    {
        //        _slipIndex = slipIndex;
        //        _detailIndex = detailIndex;
        //    }
        //}
        //# endregion
        
        # endregion
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/01 DEL


        /// <summary>
        /// 印刷先プリンタ反映処理
        /// </summary>
        /// <param name="printData"></param>
        private void ReflectSalesSlipOutputPrinterSet( ref List<ArrayList> printData )
        {
            // add by zhouzy for PCCUOEリモート伝票発行 20110811 begin
            if (!this._IsRmSlpPrt)
            {
                //リモート伝票発行の場合、リモート伝発設定マスタのデータを保存する
                _rmSlpPrtStWorkList = new List<RmSlpPrtStWork>();
            }
            // add by zhouzy for PCCUOEリモート伝票発行 20110811  end

            for ( int index = 0; index < printData.Count; index++ )
            {
                try
                {
                    // 売上伝票データ
                    FrePSalesSlipWork slip = (FrePSalesSlipWork)(printData[index][0]);
                    // 売上明細データ１行目
                    FrePSalesDetailWork detail1 = (FrePSalesDetailWork)((printData[index][1] as List<FrePSalesDetailWork>)[0]);

                    int slipKind = 30;
                    //10:見積,20:受注,30:売上,40:出荷
                    switch ( slip.SALESSLIPRF_ACPTANODRSTATUSRF )
                    {
                        case 10:
                            slipKind = 140;
                            break;
                        case 20:
                            slipKind = 120;
                            break;
                        case 40:
                            slipKind = 130;
                            break;
                        case 30:
                        default:
                            slipKind = 30;
                            break;
                    }

                    // デフォルト伝票タイプ取得
                    // modified by zhouzy for PCCUOEリモート伝票発行 20110811 begin
                    CustSlipMngWork custSlipMngWork = null;
                    if (!this._IsRmSlpPrt)
                    {
                        //通常の場合
                        custSlipMngWork = GetSlipPrintTypeDefault(slipKind, slip);
                        if (custSlipMngWork == null) continue;
                        // 伝票印刷用帳票ＩＤセット
                        slip.HADD_SLIPPRTSETPAPERIDRF = custSlipMngWork.SlipPrtSetPaperId;
                    }
                    else {
                        //リモート伝票発行の場合
                        _rmSlpPrtStWork = GetRemoteSlipPrintTypeDefault(slipKind, slip);
                        if (_rmSlpPrtStWork == null) continue;
                        // 伝票印刷用帳票ＩＤセット
                        slip.HADD_SLIPPRTSETPAPERIDRF = _rmSlpPrtStWork.SlipPrtSetPaperId;
                    }
                    // modified by zhouzy for PCCUOEリモート伝票発行 20110811  end

                    // デフォルトプリンタ取得
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/02 DEL
                    //SlipOutputSetWork slipOutputSetWork = GetSlipOutputSetDefault( slipKind, custSlipMngWork.SlipPrtSetPaperId, _posTerminalMg.CashRegisterNo, slip, detail1 );
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/02 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/02 ADD
                    //SlipCreateProcessRF	0:入力順 1:在庫別 2:倉庫別 3:出力先別 (4:明細行別?)
                    SalesTtlStWork salesTtlSt = GetSalesTtlSt();
                    bool eachWarehouseSetEnable = ((salesTtlSt != null) && (salesTtlSt.SlipCreateProcess == 3));

                    // modified by zhouzy for PCCUOEリモート伝票発行 20110811 begin
                    SlipOutputSetWork slipOutputSetWork;
                    if (!this._IsRmSlpPrt)
                    {
                        //通常の場合
                        slipOutputSetWork = GetSlipOutputSetDefault(slipKind, custSlipMngWork.SlipPrtSetPaperId, _posTerminalMg.CashRegisterNo, slip, detail1, eachWarehouseSetEnable);
                    }
                    else {
                        //リモート伝票発行の場合
                        slipOutputSetWork = GetSlipOutputSetDefault(slipKind, _rmSlpPrtStWork.SlipPrtSetPaperId, _posTerminalMg.CashRegisterNo, slip, detail1, eachWarehouseSetEnable);
                     }
                    // modified by zhouzy for PCCUOEリモート伝票発行 20110811  end
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/02 ADD
                    if ( slipOutputSetWork == null ) continue;
                    // プリンタ管理№セット
                    slip.HADD_PRINTERMNGNORF = slipOutputSetWork.PrinterMngNo;
                }
                catch
                { 
                }
            }
        }
        /// <summary>
        /// 売上伝票データ取得処理
        /// </summary>
        /// <param name="paraWork"></param>
        /// <param name="printData">印刷データリストリスト</param>
        /// <param name="masterList">関連マスタ配列リスト</param>
        /// <returns></returns>
        private int SearchFrePSalesSlip( FrePSalesSlipParaWork paraWork, ref List<ArrayList> printData, ref List<object> masterList )
        {
            // リモート取得
            IFrePSalesSlipDB iFrePSalesSlipDB = (IFrePSalesSlipDB)MediationFrePSalesSlipDB.GetFrePSalesSlipDB();

            // 自由帳票（売上伝票）リモート呼び出し
            object retObj;
            object mstList;
            bool msgDiv;
            string errMsg;
            //int status = iFrePSalesSlipDB.Search( XmlByteSerializer.Serialize( paraWork ), out retObj, out mstList, out msgDiv, out errMsg );
            int status = iFrePSalesSlipDB.Search( paraWork, out retObj, out mstList, out msgDiv, out errMsg );

            if ( status == 0 )
            {
                // 返却パラメータセット
                printData = new List<ArrayList>( (ArrayList[])(retObj as CustomSerializeArrayList).ToArray( typeof( ArrayList ) ) );
                masterList = new List<object>( (mstList as CustomSerializeArrayList).ToArray() );
            }
            return status;
        }
        # endregion

        # region [Search見積書]
        /// <summary>
        /// 初期検索（見積書）
        /// </summary>
        /// <param name="paraWork"></param>
        /// <param name="customerCode"></param>
        /// <param name="printData"></param>
        /// <returns></returns>
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/01 DEL
        //public int InitialSearchFrePEstFm( FrePEstFmParaWork paraWork, ref List<ArrayList> printData )
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/01 DEL
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/01 ADD
        public int InitialSearchFrePEstFm( FrePEstFmParaWork paraWork, int customerCode, ref List<ArrayList> printData )
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/01 ADD
        {
            //// 企業コード退避
            //_enterpriseCode = paraWork.EnterpriseCode;

            // 復号化済み自由帳票印字位置設定ディクショナリ初期化
            _decryptedFrePrtPSetDic = new Dictionary<string, bool>();

            // 端末設定取得
            int status = GetPosTerminalMg( out _posTerminalMg, _enterpriseCode );
            if ( status != 0 )
            {
                _slipAcsState = SlipAcsStatus.Error_NoTerminalMg;
                return status;
            }

            // ユーザーDB検索処理
            List<object> masterList = null;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/01 DEL
            //status = SearchFrePEstFm( paraWork, ref printData, ref masterList );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/01 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/01 ADD
            status = SearchFrePEstFm( paraWork, customerCode, ref printData, ref masterList );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/01 ADD
            if ( status != 0 )
            {
                _slipAcsState = SlipAcsStatus.Error_SearchSlip;
                return status;
            }

            // マスタリスト展開
            # region [マスタリスト展開]
            for ( int index = 0; index < masterList.Count; index++ )
            {
                if ( masterList[index] is SlipPrtSetWork[] )
                {
                    // 伝票印刷設定リスト生成
                    _slipPrtSetWorkList = new List<SlipPrtSetWork>( (SlipPrtSetWork[])masterList[index] );
                }
                else if ( masterList[index] is FrePrtPSetWork[] )
                {
                    // 自由帳票印字位置設定リスト生成
                    _frePrtPSetWorkList = new List<FrePrtPSetWork>( (FrePrtPSetWork[])masterList[index] );
                }
                else if ( masterList[index] is CustSlipMngWork[] )
                {
                    // 得意先マスタ伝票管理（伝票タイプ管理マスタ）リスト生成
                    _custSlipMngWorkList = new List<CustSlipMngWork>( (CustSlipMngWork[])masterList[index] );
                }
                else if ( masterList[index] is SlipOutputSetWork[] )
                {
                    // 伝票出力先設定リスト作成
                    _slipOutputSetWorkList = new List<SlipOutputSetWork>( (SlipOutputSetWork[])masterList[index] );
                }
                else if ( masterList[index] is SalesTtlStWork[] )
                {
                    // 売上全体設定リスト作成
                    _salesTtlStWorkList = new List<SalesTtlStWork>( (SalesTtlStWork[])masterList[index] );
                }
                else if ( masterList[index] is AllDefSetWork[] )
                {
                    // 全体初期表示設定
                    _allDefSetWorkList = new List<AllDefSetWork>( (AllDefSetWork[])masterList[index] );
                }
            }
            # endregion


            FrePSalesSlipWork frePSalesSlipWork = null;
            if ( printData != null && printData.Count > 0 )
            {
                foreach ( ArrayList list in printData )
                {
                    foreach ( object retObj in list )
                    {
                        if ( retObj is FrePSalesSlipWork )
                        {
                            frePSalesSlipWork = (retObj as FrePSalesSlipWork);
                        }
                    }
                }
            }

            if ( frePSalesSlipWork != null )
            {
                // 返却データ編集②印刷先プリンタ確定
                ReflectSalesSlipOutputPrinterSetForEstFm( ref frePSalesSlipWork );
            }
            return status;
        }

        /// <summary>
        /// 印刷先プリンタ反映処理
        /// </summary>
        /// <param name="frePSalesSlipWork"></param>
        private void ReflectSalesSlipOutputPrinterSetForEstFm( ref FrePSalesSlipWork frePSalesSlipWork )
        {
            try
            {
                // 10:見積書
                int slipKind = 10;

                // デフォルト伝票タイプ取得
                CustSlipMngWork custSlipMngWork = GetSlipPrintTypeDefaultForEstFm( slipKind, frePSalesSlipWork );
                if ( custSlipMngWork == null ) return;
                // 伝票印刷用帳票ＩＤセット
                frePSalesSlipWork.HADD_SLIPPRTSETPAPERIDRF = custSlipMngWork.SlipPrtSetPaperId;

                // デフォルトプリンタ取得
                SlipOutputSetWork slipOutputSetWork = GetSlipOutputSetDefaultForEstFm( slipKind, custSlipMngWork.SlipPrtSetPaperId, _posTerminalMg.CashRegisterNo, frePSalesSlipWork );
                if ( slipOutputSetWork == null ) return;
                // プリンタ管理№セット
                frePSalesSlipWork.HADD_PRINTERMNGNORF = slipOutputSetWork.PrinterMngNo;
            }
            catch
            {
            }
        }
        /// <summary>
        /// 見積書関連データ取得処理
        /// </summary>
        /// <param name="paraWork"></param>
        /// <param name="customerCode"></param>
        /// <param name="printData">印刷データリストリスト</param>
        /// <param name="masterList">関連マスタ配列リスト</param>
        /// <returns></returns>
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/01 DEL
        //private int SearchFrePEstFm( FrePEstFmParaWork paraWork, ref List<ArrayList> printData, ref List<object> masterList )
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/01 DEL
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/01 ADD
        private int SearchFrePEstFm( FrePEstFmParaWork paraWork, int customerCode, ref List<ArrayList> printData, ref List<object> masterList )
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/01 ADD
        {
            // リモート取得
            IFrePSalesSlipDB iFrePSalesSlipDB = (IFrePSalesSlipDB)MediationFrePSalesSlipDB.GetFrePSalesSlipDB();

            // 自由帳票（売上伝票）リモート見積書用メソッド呼び出し
            object retObj;
            object mstList;
            bool msgDiv;
            string errMsg;
            //int status = iFrePSalesSlipDB.SearchForEstFm( XmlByteSerializer.Serialize( paraWork ), out retObj, out mstList, out msgDiv, out errMsg );
            int status = iFrePSalesSlipDB.SearchForEstFm( paraWork, out retObj, out mstList, out msgDiv, out errMsg );

            if ( status == 0 )
            {
                // 返却パラメータセット
                //printData = new List<ArrayList>( (ArrayList[])(retObj as CustomSerializeArrayList).ToArray( typeof( ArrayList ) ) );
                FrePSalesSlipWork slipWork = (FrePSalesSlipWork)((retObj as CustomSerializeArrayList)[0]);
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/01 ADD
                slipWork.SALESSLIPRF_CUSTOMERCODERF = customerCode;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/01 ADD
                ArrayList aList = new ArrayList();
                aList.Add( slipWork );

                printData = new List<ArrayList>();
                printData.Add( aList );
                masterList = new List<object>( (mstList as CustomSerializeArrayList).ToArray() );
            }
            return status;
        }
        # endregion

        # region [Search在庫移動]
        /// <summary>
        /// 初期検索（在庫移動伝票）
        /// </summary>
        /// <param name="paraWork"></param>
        /// <param name="printDataList"></param>
        /// <returns></returns>
        public int InitialSearchFrePStockMoveSlip( FrePStockMoveSlipParaWork paraWork, ref List<List<ArrayList>> printDataList )
        {
            // 復号化済み自由帳票印字位置設定ディクショナリ初期化
            _decryptedFrePrtPSetDic = new Dictionary<string, bool>();

            // 端末設定取得
            int status = GetPosTerminalMg( out _posTerminalMg, _enterpriseCode );
            if ( status != 0 )
            {
                _slipAcsState = SlipAcsStatus.Error_NoTerminalMg;
                return status;
            }

            // ユーザーDB検索処理
            List<ArrayList> printData = null;
            List<object> masterList = null;
            status = SearchFrePStockMoveSlip( paraWork, ref printData, ref masterList );
            if ( status != 0 )
            {
                _slipAcsState = SlipAcsStatus.Error_SearchSlip;
                return status;
            }


            // マスタリスト展開
            # region [マスタリスト展開]
            for ( int index = 0; index < masterList.Count; index++ )
            {
                if ( masterList[index] is SlipPrtSetWork[] )
                {
                    // 伝票印刷設定リスト生成
                    _slipPrtSetWorkList = new List<SlipPrtSetWork>( (SlipPrtSetWork[])masterList[index] );
                }
                else if ( masterList[index] is FrePrtPSetWork[] )
                {
                    // 自由帳票印字位置設定リスト生成
                    _frePrtPSetWorkList = new List<FrePrtPSetWork>( (FrePrtPSetWork[])masterList[index] );
                }
                else if ( masterList[index] is CustSlipMngWork[] )
                {
                    // 得意先マスタ伝票管理（伝票タイプ管理マスタ）リスト生成
                    _custSlipMngWorkList = new List<CustSlipMngWork>( (CustSlipMngWork[])masterList[index] );
                }
                else if ( masterList[index] is SlipOutputSetWork[] )
                {
                    // 伝票出力先設定リスト作成
                    _slipOutputSetWorkList = new List<SlipOutputSetWork>( (SlipOutputSetWork[])masterList[index] );
                }
                else if ( masterList[index] is StockMngTtlStWork[] )
                {
                    // 在庫管理全体設定リスト作成
                    _stockMngTtlStWorkList = new List<StockMngTtlStWork>( (StockMngTtlStWork[])masterList[index] );
                }
                // --- ADD  大矢睦美  2010/03/31 ---------->>>>>
                else if ( masterList[index] is AllDefSetWork[] )
                {
                    //全体初期表示設定リスト作成
                    _allDefSetWorkList = new List<AllDefSetWork>( (AllDefSetWork[])masterList[index] );
                }
                // --- ADD  大矢睦美  2010/03/31 ----------<<<<<
            }
            # endregion

            // 返却データ編集①印刷先プリンタ確定
            ReflectStockMoveSlipOutputPrinterSet( ref printData );

            // 返却データ編集②Key別分別 (同一受注ステータス、同一プリンタでまとめる)
            # region [Key別分別]
            Dictionary<StockMoveSlipListKey, List<ArrayList>> slipListDic = new Dictionary<StockMoveSlipListKey, List<ArrayList>>();
            for ( int index = 0; index < printData.Count; index++ )
            {
                // キー生成
                StockMoveSlipListKey key = new StockMoveSlipListKey( (printData[index][0]) as FrePStockMoveSlipWork );
                if ( !slipListDic.ContainsKey( key ) )
                {
                    // 新リスト追加
                    slipListDic.Add( key, new List<ArrayList>() );
                }
                // リストに追加
                slipListDic[key].Add( printData[index] );
            }
            // ディクショナリからリストに移行
            printDataList = new List<List<ArrayList>>();
            foreach ( List<ArrayList> slipList in slipListDic.Values )
            {
                printDataList.Add( slipList );
            }
            # endregion

            return status;
        }
        /// <summary>
        /// 印刷先プリンタ反映処理
        /// </summary>
        /// <param name="printData"></param>
        private void ReflectStockMoveSlipOutputPrinterSet( ref List<ArrayList> printData )
        {
            for ( int index = 0; index < printData.Count; index++ )
            {
                try
                {
                    // 在庫移動伝票データ
                    FrePStockMoveSlipWork slip = (FrePStockMoveSlipWork)(printData[index][0]);
                    // 在庫移動明細データ１行目
                    FrePStockMoveDetailWork detail1 = (FrePStockMoveDetailWork)((printData[index][1] as List<FrePStockMoveDetailWork>)[0]);

                    //int slipKind;
                    //if ( slip.SALESSLIPRF_ACPTANODRSTATUSRF == 10 )
                    //{
                    //    slipKind = 10;  // 10:見積書
                    //}
                    //else
                    //{
                    //    slipKind = 30;  // 30:納品書
                    //}
                    int slipKind = 150; // 150:在庫移動

                    // デフォルト伝票タイプ取得
                    CustSlipMngWork custSlipMngWork = GetSlipPrintTypeDefault( slipKind, slip );
                    if ( custSlipMngWork == null ) continue;
                    // 伝票印刷用帳票ＩＤセット
                    slip.HADD_SLIPPRTSETPAPERIDRF = custSlipMngWork.SlipPrtSetPaperId;


                    // デフォルトプリンタ取得
                    SlipOutputSetWork slipOutputSetWork = GetSlipOutputSetDefault( slipKind, custSlipMngWork.SlipPrtSetPaperId, _posTerminalMg.CashRegisterNo, slip, detail1 );
                    if ( slipOutputSetWork == null ) continue;
                    // プリンタ管理№セット
                    slip.HADD_PRINTERMNGNORF = slipOutputSetWork.PrinterMngNo;
                }
                catch
                {
                }
            }
        }
        /// <summary>
        /// 在庫移動伝票データ取得処理
        /// </summary>
        /// <param name="paraWork"></param>
        /// <param name="printData">印刷データリストリスト</param>
        /// <param name="masterList">関連マスタ配列リスト</param>
        /// <returns></returns>
        private int SearchFrePStockMoveSlip( FrePStockMoveSlipParaWork paraWork, ref List<ArrayList> printData, ref List<object> masterList )
        {
            // リモート取得
            IFrePStockMoveSlipDB iFrePStockMoveSlipDB = (IFrePStockMoveSlipDB)MediationFrePStockMoveSlipDB.GetFrePStockMoveSlipDB();

            // 自由帳票（在庫移動伝票）リモート呼び出し
            object retObj;
            object mstList;
            bool msgDiv;
            string errMsg;
            int status = iFrePStockMoveSlipDB.Search( XmlByteSerializer.Serialize( paraWork ), out retObj, out mstList, out msgDiv, out errMsg );

            if ( status == 0 )
            {
                // 返却パラメータセット
                printData = new List<ArrayList>( (ArrayList[])(retObj as CustomSerializeArrayList).ToArray( typeof( ArrayList ) ) );
                masterList = new List<object>( (mstList as CustomSerializeArrayList).ToArray() );
            }
            return status;
        }
        # endregion

        # region [SearchＵＯＥ伝票]
        /// <summary>
        /// 初期検索（UOE伝票）
        /// </summary>
        /// <param name="paraWork"></param>
        /// <param name="printDataList"></param>
        /// <returns></returns>
        public int InitialSearchFrePUOESlip( FrePUOESlipParaWork paraWork, ref List<List<ArrayList>> printDataList, List<UoeSales> uoeSalesList )
        {
            //// 企業コード退避
            //_enterpriseCode = paraWork.EnterpriseCode;

            // 復号化済み自由帳票印字位置設定ディクショナリ初期化
            _decryptedFrePrtPSetDic = new Dictionary<string, bool>();

            // 端末設定取得
            int status = GetPosTerminalMg( out _posTerminalMg, _enterpriseCode );
            if ( status != 0 )
            {
                _slipAcsState = SlipAcsStatus.Error_NoTerminalMg;
                return status;
            }

            // ユーザーDB検索処理
            List<ArrayList> printData = null;
            List<object> masterList = null;
            status = SearchFrePUOESlip( paraWork, ref printData, ref masterList );
            if ( status != 0 )
            {
                _slipAcsState = SlipAcsStatus.Error_SearchSlip;
                return status;
            }

            // マスタリスト展開
            # region [マスタリスト展開]
            for ( int index = 0; index < masterList.Count; index++ )
            {
                if ( masterList[index] is SlipPrtSetWork[] )
                {
                    // 伝票印刷設定リスト生成
                    _slipPrtSetWorkList = new List<SlipPrtSetWork>( (SlipPrtSetWork[])masterList[index] );
                }
                else if ( masterList[index] is FrePrtPSetWork[] )
                {
                    // 自由帳票印字位置設定リスト生成
                    _frePrtPSetWorkList = new List<FrePrtPSetWork>( (FrePrtPSetWork[])masterList[index] );
                }
                else if ( masterList[index] is CustSlipMngWork[] )
                {
                    // 得意先マスタ伝票管理（伝票タイプ管理マスタ）リスト生成
                    _custSlipMngWorkList = new List<CustSlipMngWork>( (CustSlipMngWork[])masterList[index] );
                }
                else if ( masterList[index] is SlipOutputSetWork[] )
                {
                    // 伝票出力先設定リスト作成
                    _slipOutputSetWorkList = new List<SlipOutputSetWork>( (SlipOutputSetWork[])masterList[index] );
                }
                else if ( masterList[index] is SalesTtlStWork[] )
                {
                    // 売上全体設定リスト作成
                    _salesTtlStWorkList = new List<SalesTtlStWork>( (SalesTtlStWork[])masterList[index] );
                }
                else if ( masterList[index] is AllDefSetWork[] )
                { 
                    // 全体初期表示設定リスト作成
                    _allDefSetWorkList = new List<AllDefSetWork>( (AllDefSetWork[])masterList[index] );
                }
                // --- ADD  大矢睦美  2010/05/18 ---------->>>>>
                else if ( masterList[index] is UOEGuideNameWork[] )
                {
                    //UOEガイド名称設定リスト作成
                    _uoeGuideNameWorkList = new List<UOEGuideNameWork>( (UOEGuideNameWork[])masterList[index] );
                }
                // --- ADD  大矢睦美  2010/05/18 ----------<<<<<
            }
            # endregion

            // 返却データ編集①印刷先プリンタ確定
            ReflectUOESlipOutputPrinterSet( ref printData );

            // 返却データ編集②UOE補足情報追加
            # region [補足情報追加]
            for ( int index = 0; index < printData.Count; index++ )
            {
                if ( uoeSalesList.Count > index )
                {
                    printData[index].Add( uoeSalesList[index] );
                }
            }
            # endregion

            // 返却データ編集③Key別分別 (同一受注ステータス、同一プリンタでまとめる)
            # region [Key別分別]
            Dictionary<SalesSlipListKey, List<ArrayList>> slipListDic = new Dictionary<SalesSlipListKey, List<ArrayList>>();
            for ( int index = 0; index < printData.Count; index++ )
            {
                // キー生成
                SalesSlipListKey key = new SalesSlipListKey( (printData[index][0]) as FrePSalesSlipWork );
                if ( !slipListDic.ContainsKey( key ) )
                {
                    // 新リスト追加
                    slipListDic.Add( key, new List<ArrayList>() );
                }
                // リストに追加
                slipListDic[key].Add( printData[index] );
            }
            // ディクショナリからリストに移行
            printDataList = new List<List<ArrayList>>();
            foreach ( List<ArrayList> slipList in slipListDic.Values )
            {
                printDataList.Add( slipList );
            }
            # endregion

            return status;
        }

        /// <summary>
        /// 印刷先プリンタ反映処理（UOE伝票用）
        /// </summary>
        /// <param name="printData"></param>
        private void ReflectUOESlipOutputPrinterSet( ref List<ArrayList> printData )
        {
            for ( int index = 0; index < printData.Count; index++ )
            {
                try
                {
                    // UOE伝票データ
                    FrePSalesSlipWork slip = (FrePSalesSlipWork)(printData[index][0]);
                    // 売上明細データ１行目
                    FrePSalesDetailWork detail1 = (FrePSalesDetailWork)((printData[index][1] as List<FrePSalesDetailWork>)[0]);

                    //160:ＵＯＥ伝票
                    int slipKind = 160;

                    // デフォルト伝票タイプ取得
                    CustSlipMngWork custSlipMngWork = GetSlipPrintTypeDefault( slipKind, slip );
                    if ( custSlipMngWork == null ) continue;
                    // 伝票印刷用帳票ＩＤセット
                    slip.HADD_SLIPPRTSETPAPERIDRF = custSlipMngWork.SlipPrtSetPaperId;

                    // デフォルトプリンタ取得
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/02 DEL
                    //SlipOutputSetWork slipOutputSetWork = GetSlipOutputSetDefault( slipKind, custSlipMngWork.SlipPrtSetPaperId, _posTerminalMg.CashRegisterNo, slip, detail1 );
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/02 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/02 ADD
                    //SlipCreateProcessRF	0:入力順 1:在庫別 2:倉庫別 3:出力先別 (4:明細行別?)
                    SalesTtlStWork salesTtlSt = GetSalesTtlSt();
                    bool eachWarehouseSetEnable = ((salesTtlSt != null) && (salesTtlSt.SlipCreateProcess == 3));
                    SlipOutputSetWork slipOutputSetWork = GetSlipOutputSetDefault( slipKind, custSlipMngWork.SlipPrtSetPaperId, _posTerminalMg.CashRegisterNo, slip, detail1, eachWarehouseSetEnable );
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/02 ADD

                    if ( slipOutputSetWork == null ) continue;
                    // プリンタ管理№セット
                    slip.HADD_PRINTERMNGNORF = slipOutputSetWork.PrinterMngNo;
                }
                catch
                {
                }
            }
        }
        /// <summary>
        /// UOE伝票データ取得処理
        /// </summary>
        /// <param name="paraWork"></param>
        /// <param name="printData">印刷データリストリスト</param>
        /// <param name="masterList">関連マスタ配列リスト</param>
        /// <returns></returns>
        private int SearchFrePUOESlip( FrePUOESlipParaWork paraWork, ref List<ArrayList> printData, ref List<object> masterList )
        {
            //// リモート取得
            //IFrePSalesSlipDB iFrePSalesSlipDB = (IFrePSalesSlipDB)MediationFrePSalesSlipDB.GetFrePSalesSlipDB();

            ////// 自由帳票（UOE伝票）リモート呼び出し
            //object retObj;
            //object mstList;
            //bool msgDiv;
            //string errMsg;
            //int status = iFrePSalesSlipDB.Search( XmlByteSerializer.Serialize( paraWork ), out retObj, out mstList, out msgDiv, out errMsg );

            //if ( status == 0 )
            //{
            //    // 返却パラメータセット
            //    printData = new List<ArrayList>( (ArrayList[])(retObj as CustomSerializeArrayList).ToArray( typeof( ArrayList ) ) );
            //    masterList = new List<object>( (mstList as CustomSerializeArrayList).ToArray() );
            //}
            //return status;

            // リモート取得
            IFrePSalesSlipDB iFrePSalesSlipDB = (IFrePSalesSlipDB)MediationFrePSalesSlipDB.GetFrePSalesSlipDB();

            // 自由帳票（UOE伝票）リモート呼び出し
            object retObj;
            object mstList;
            bool msgDiv;
            string errMsg;
            int status = iFrePSalesSlipDB.SearchForUOE( paraWork, out retObj, out mstList, out msgDiv, out errMsg );

            if ( status == 0 )
            {
                // 返却パラメータセット
                printData = new List<ArrayList>( (ArrayList[])(retObj as CustomSerializeArrayList).ToArray( typeof( ArrayList ) ) );
                masterList = new List<object>( (mstList as CustomSerializeArrayList).ToArray() );
            }

            return 0;
            //return status;
        }
        /// <summary>
        /// UOE伝票用 データ移行処理（売上伝票work→自由帳票売上伝票work）
        /// </summary>
        /// <param name="salesSlipWork"></param>
        /// <returns></returns>
        public static FrePSalesSlipWork CopyToFrePSalesSlipWorkFromSalesSlip( SalesSlipWork salesSlipWork )
        {
            FrePSalesSlipWork frePSalesSlipWork = new FrePSalesSlipWork();

            # region [copy]
            frePSalesSlipWork.SALESSLIPRF_ACPTANODRSTATUSRF = salesSlipWork.AcptAnOdrStatus; // 受注ステータス
            frePSalesSlipWork.SALESSLIPRF_SALESSLIPNUMRF = salesSlipWork.SalesSlipNum; // 売上伝票番号
            frePSalesSlipWork.SALESSLIPRF_SECTIONCODERF = salesSlipWork.SectionCode; // 拠点コード
            frePSalesSlipWork.SALESSLIPRF_SUBSECTIONCODERF = salesSlipWork.SubSectionCode; // 部門コード
            frePSalesSlipWork.SALESSLIPRF_DEBITNOTEDIVRF = salesSlipWork.DebitNoteDiv; // 赤伝区分
            frePSalesSlipWork.SALESSLIPRF_DEBITNLNKSALESSLNUMRF = salesSlipWork.DebitNLnkSalesSlNum; // 赤黒連結売上伝票番号
            frePSalesSlipWork.SALESSLIPRF_SALESSLIPCDRF = salesSlipWork.SalesSlipCd; // 売上伝票区分
            frePSalesSlipWork.SALESSLIPRF_SALESGOODSCDRF = salesSlipWork.SalesGoodsCd; // 売上商品区分
            frePSalesSlipWork.SALESSLIPRF_ACCRECDIVCDRF = salesSlipWork.AccRecDivCd; // 売掛区分
            frePSalesSlipWork.SALESSLIPRF_SEARCHSLIPDATERF = ToLongDate( salesSlipWork.SearchSlipDate ); // 伝票検索日付
            frePSalesSlipWork.SALESSLIPRF_SHIPMENTDAYRF = ToLongDate( salesSlipWork.ShipmentDay ); // 出荷日付
            frePSalesSlipWork.SALESSLIPRF_SALESDATERF = ToLongDate( salesSlipWork.SalesDate ); // 売上日付
            frePSalesSlipWork.SALESSLIPRF_ADDUPADATERF = ToLongDate( salesSlipWork.AddUpADate ); // 計上日付
            frePSalesSlipWork.SALESSLIPRF_DELAYPAYMENTDIVRF = salesSlipWork.DelayPaymentDiv; // 来勘区分
            frePSalesSlipWork.SALESSLIPRF_ESTIMATEFORMNORF = salesSlipWork.EstimateFormNo; // 見積書番号
            frePSalesSlipWork.SALESSLIPRF_ESTIMATEDIVIDERF = salesSlipWork.EstimateDivide; // 見積区分
            frePSalesSlipWork.SALESSLIPRF_SALESINPUTCODERF = salesSlipWork.SalesInputCode; // 売上入力者コード
            frePSalesSlipWork.SALESSLIPRF_SALESINPUTNAMERF = salesSlipWork.SalesInputName; // 売上入力者名称
            frePSalesSlipWork.SALESSLIPRF_FRONTEMPLOYEECDRF = salesSlipWork.FrontEmployeeCd; // 受付従業員コード
            frePSalesSlipWork.SALESSLIPRF_FRONTEMPLOYEENMRF = salesSlipWork.FrontEmployeeNm; // 受付従業員名称
            frePSalesSlipWork.SALESSLIPRF_SALESEMPLOYEECDRF = salesSlipWork.SalesEmployeeCd; // 販売従業員コード
            frePSalesSlipWork.SALESSLIPRF_SALESEMPLOYEENMRF = salesSlipWork.SalesEmployeeNm; // 販売従業員名称
            frePSalesSlipWork.SALESSLIPRF_TOTALAMOUNTDISPWAYCDRF = salesSlipWork.TotalAmountDispWayCd; // 総額表示方法区分
            frePSalesSlipWork.SALESSLIPRF_TTLAMNTDISPRATEAPYRF = salesSlipWork.TtlAmntDispRateApy; // 総額表示掛率適用区分
            frePSalesSlipWork.SALESSLIPRF_SALESTOTALTAXINCRF = salesSlipWork.SalesTotalTaxInc; // 売上伝票合計（税込み）
            frePSalesSlipWork.SALESSLIPRF_SALESTOTALTAXEXCRF = salesSlipWork.SalesTotalTaxExc; // 売上伝票合計（税抜き）
            frePSalesSlipWork.SALESSLIPRF_SALESSUBTOTALTAXINCRF = salesSlipWork.SalesSubtotalTaxInc; // 売上小計（税込み）
            frePSalesSlipWork.SALESSLIPRF_SALESSUBTOTALTAXEXCRF = salesSlipWork.SalesSubtotalTaxExc; // 売上小計（税抜き）
            frePSalesSlipWork.SALESSLIPRF_SALESSUBTOTALTAXRF = salesSlipWork.SalesSubtotalTax; // 売上小計（税）
            frePSalesSlipWork.SALESSLIPRF_ITDEDSALESOUTTAXRF = salesSlipWork.ItdedSalesOutTax; // 売上外税対象額
            frePSalesSlipWork.SALESSLIPRF_ITDEDSALESINTAXRF = salesSlipWork.ItdedSalesInTax; // 売上内税対象額
            frePSalesSlipWork.SALESSLIPRF_SALSUBTTLSUBTOTAXFRERF = salesSlipWork.SalSubttlSubToTaxFre; // 売上小計非課税対象額
            frePSalesSlipWork.SALESSLIPRF_SALAMNTCONSTAXINCLURF = salesSlipWork.SalAmntConsTaxInclu; // 売上金額消費税額（内税）
            frePSalesSlipWork.SALESSLIPRF_SALESDISTTLTAXEXCRF = salesSlipWork.SalesDisTtlTaxExc; // 売上値引金額計（税抜き）
            frePSalesSlipWork.SALESSLIPRF_ITDEDSALESDISOUTTAXRF = salesSlipWork.ItdedSalesDisOutTax; // 売上値引外税対象額合計
            frePSalesSlipWork.SALESSLIPRF_ITDEDSALESDISINTAXRF = salesSlipWork.ItdedSalesDisInTax; // 売上値引内税対象額合計
            frePSalesSlipWork.SALESSLIPRF_SALESDISOUTTAXRF = salesSlipWork.SalesDisOutTax; // 売上値引消費税額（外税）
            frePSalesSlipWork.SALESSLIPRF_SALESDISTTLTAXINCLURF = salesSlipWork.SalesDisTtlTaxInclu; // 売上値引消費税額（内税）
            frePSalesSlipWork.SALESSLIPRF_TOTALCOSTRF = salesSlipWork.TotalCost; // 原価金額計
            frePSalesSlipWork.SALESSLIPRF_CONSTAXLAYMETHODRF = salesSlipWork.ConsTaxLayMethod; // 消費税転嫁方式
            frePSalesSlipWork.SALESSLIPRF_CONSTAXRATERF = salesSlipWork.ConsTaxRate; // 消費税税率
            frePSalesSlipWork.SALESSLIPRF_FRACTIONPROCCDRF = salesSlipWork.FractionProcCd; // 端数処理区分
            frePSalesSlipWork.SALESSLIPRF_ACCRECCONSTAXRF = salesSlipWork.AccRecConsTax; // 売掛消費税
            frePSalesSlipWork.SALESSLIPRF_AUTODEPOSITCDRF = salesSlipWork.AutoDepositCd; // 自動入金区分
            frePSalesSlipWork.SALESSLIPRF_AUTODEPOSITSLIPNORF = salesSlipWork.AutoDepositSlipNo; // 自動入金伝票番号
            frePSalesSlipWork.SALESSLIPRF_DEPOSITALLOWANCETTLRF = salesSlipWork.DepositAllowanceTtl; // 入金引当合計額
            frePSalesSlipWork.SALESSLIPRF_DEPOSITALWCBLNCERF = salesSlipWork.DepositAlwcBlnce; // 入金引当残高
            frePSalesSlipWork.SALESSLIPRF_CLAIMCODERF = salesSlipWork.ClaimCode; // 請求先コード
            frePSalesSlipWork.SALESSLIPRF_CLAIMSNMRF = salesSlipWork.ClaimSnm; // 請求先略称
            frePSalesSlipWork.SALESSLIPRF_CUSTOMERCODERF = salesSlipWork.CustomerCode; // 得意先コード
            frePSalesSlipWork.SALESSLIPRF_CUSTOMERNAMERF = salesSlipWork.CustomerName; // 得意先名称
            frePSalesSlipWork.SALESSLIPRF_CUSTOMERNAME2RF = salesSlipWork.CustomerName2; // 得意先名称2
            frePSalesSlipWork.SALESSLIPRF_CUSTOMERSNMRF = salesSlipWork.CustomerSnm; // 得意先略称
            frePSalesSlipWork.SALESSLIPRF_HONORIFICTITLERF = salesSlipWork.HonorificTitle; // 敬称
            frePSalesSlipWork.SALESSLIPRF_ADDRESSEECODERF = salesSlipWork.AddresseeCode; // 納品先コード
            frePSalesSlipWork.SALESSLIPRF_ADDRESSEENAMERF = salesSlipWork.AddresseeName; // 納品先名称
            frePSalesSlipWork.SALESSLIPRF_ADDRESSEENAME2RF = salesSlipWork.AddresseeName2; // 納品先名称2
            frePSalesSlipWork.SALESSLIPRF_ADDRESSEEPOSTNORF = salesSlipWork.AddresseePostNo; // 納品先郵便番号
            frePSalesSlipWork.SALESSLIPRF_ADDRESSEEADDR1RF = salesSlipWork.AddresseeAddr1; // 納品先住所1(都道府県市区郡・町村・字)
            frePSalesSlipWork.SALESSLIPRF_ADDRESSEEADDR3RF = salesSlipWork.AddresseeAddr3; // 納品先住所3(番地)
            frePSalesSlipWork.SALESSLIPRF_ADDRESSEEADDR4RF = salesSlipWork.AddresseeAddr4; // 納品先住所4(アパート名称)
            frePSalesSlipWork.SALESSLIPRF_ADDRESSEETELNORF = salesSlipWork.AddresseeTelNo; // 納品先電話番号
            frePSalesSlipWork.SALESSLIPRF_ADDRESSEEFAXNORF = salesSlipWork.AddresseeFaxNo; // 納品先FAX番号
            frePSalesSlipWork.SALESSLIPRF_PARTYSALESLIPNUMRF = salesSlipWork.PartySaleSlipNum; // 相手先伝票番号
            frePSalesSlipWork.SALESSLIPRF_SLIPNOTERF = salesSlipWork.SlipNote; // 伝票備考
            frePSalesSlipWork.SALESSLIPRF_SLIPNOTE2RF = salesSlipWork.SlipNote2; // 伝票備考２
            frePSalesSlipWork.SALESSLIPRF_RETGOODSREASONDIVRF = salesSlipWork.RetGoodsReasonDiv; // 返品理由コード
            frePSalesSlipWork.SALESSLIPRF_RETGOODSREASONRF = salesSlipWork.RetGoodsReason; // 返品理由
            frePSalesSlipWork.SALESSLIPRF_REGIPROCDATERF = ToLongDate( salesSlipWork.RegiProcDate ); // レジ処理日
            frePSalesSlipWork.SALESSLIPRF_CASHREGISTERNORF = salesSlipWork.CashRegisterNo; // レジ番号
            frePSalesSlipWork.SALESSLIPRF_POSRECEIPTNORF = salesSlipWork.PosReceiptNo; // POSレシート番号
            frePSalesSlipWork.SALESSLIPRF_DETAILROWCOUNTRF = salesSlipWork.DetailRowCount; // 明細行数
            frePSalesSlipWork.SALESSLIPRF_EDISENDDATERF = ToLongDate( salesSlipWork.EdiSendDate ); // ＥＤＩ送信日
            frePSalesSlipWork.SALESSLIPRF_EDITAKEINDATERF = ToLongDate( salesSlipWork.EdiTakeInDate ); // ＥＤＩ取込日
            frePSalesSlipWork.SALESSLIPRF_UOEREMARK1RF = salesSlipWork.UoeRemark1; // ＵＯＥリマーク１
            frePSalesSlipWork.SALESSLIPRF_UOEREMARK2RF = salesSlipWork.UoeRemark2; // ＵＯＥリマーク２
            frePSalesSlipWork.SALESSLIPRF_SLIPPRINTFINISHCDRF = salesSlipWork.SlipPrintFinishCd; // 伝票発行済区分
            frePSalesSlipWork.SALESSLIPRF_SALESSLIPPRINTDATERF = ToLongDate( salesSlipWork.SalesSlipPrintDate ); // 売上伝票発行日
            frePSalesSlipWork.SALESSLIPRF_BUSINESSTYPECODERF = salesSlipWork.BusinessTypeCode; // 業種コード
            frePSalesSlipWork.SALESSLIPRF_BUSINESSTYPENAMERF = salesSlipWork.BusinessTypeName; // 業種名称
            frePSalesSlipWork.SALESSLIPRF_ORDERNUMBERRF = salesSlipWork.OrderNumber; // 発注番号
            frePSalesSlipWork.SALESSLIPRF_DELIVEREDGOODSDIVRF = salesSlipWork.DeliveredGoodsDiv; // 納品区分
            frePSalesSlipWork.SALESSLIPRF_DELIVEREDGOODSDIVNMRF = salesSlipWork.DeliveredGoodsDivNm; // 納品区分名称
            frePSalesSlipWork.SALESSLIPRF_SALESAREACODERF = salesSlipWork.SalesAreaCode; // 販売エリアコード
            frePSalesSlipWork.SALESSLIPRF_SALESAREANAMERF = salesSlipWork.SalesAreaName; // 販売エリア名称
            frePSalesSlipWork.SALESSLIPRF_STOCKGOODSTTLTAXEXCRF = salesSlipWork.StockGoodsTtlTaxExc; // 在庫商品合計金額（税抜）
            frePSalesSlipWork.SALESSLIPRF_PUREGOODSTTLTAXEXCRF = salesSlipWork.PureGoodsTtlTaxExc; // 純正商品合計金額（税抜）
            frePSalesSlipWork.SALESSLIPRF_LISTPRICEPRINTDIVRF = salesSlipWork.ListPricePrintDiv; // 定価印刷区分
            frePSalesSlipWork.SALESSLIPRF_ERANAMEDISPCD1RF = salesSlipWork.EraNameDispCd1; // 元号表示区分１
            frePSalesSlipWork.SALESSLIPRF_ESTIMATAXDIVCDRF = salesSlipWork.EstimaTaxDivCd; // 見積消費税区分
            frePSalesSlipWork.SALESSLIPRF_ESTIMATEFORMPRTCDRF = salesSlipWork.EstimateFormPrtCd; // 見積書印刷区分
            frePSalesSlipWork.SALESSLIPRF_ESTIMATESUBJECTRF = salesSlipWork.EstimateSubject; // 見積件名
            frePSalesSlipWork.SALESSLIPRF_FOOTNOTES1RF = salesSlipWork.Footnotes1; // 脚注１
            frePSalesSlipWork.SALESSLIPRF_FOOTNOTES2RF = salesSlipWork.Footnotes2; // 脚注２
            frePSalesSlipWork.SALESSLIPRF_ESTIMATETITLE1RF = salesSlipWork.EstimateTitle1; // 見積タイトル１
            frePSalesSlipWork.SALESSLIPRF_ESTIMATETITLE2RF = salesSlipWork.EstimateTitle2; // 見積タイトル２
            frePSalesSlipWork.SALESSLIPRF_ESTIMATETITLE3RF = salesSlipWork.EstimateTitle3; // 見積タイトル３
            frePSalesSlipWork.SALESSLIPRF_ESTIMATETITLE4RF = salesSlipWork.EstimateTitle4; // 見積タイトル４
            frePSalesSlipWork.SALESSLIPRF_ESTIMATETITLE5RF = salesSlipWork.EstimateTitle5; // 見積タイトル５
            frePSalesSlipWork.SALESSLIPRF_ESTIMATENOTE1RF = salesSlipWork.EstimateNote1; // 見積備考１
            frePSalesSlipWork.SALESSLIPRF_ESTIMATENOTE2RF = salesSlipWork.EstimateNote2; // 見積備考２
            frePSalesSlipWork.SALESSLIPRF_ESTIMATENOTE3RF = salesSlipWork.EstimateNote3; // 見積備考３
            frePSalesSlipWork.SALESSLIPRF_ESTIMATENOTE4RF = salesSlipWork.EstimateNote4; // 見積備考４
            frePSalesSlipWork.SALESSLIPRF_ESTIMATENOTE5RF = salesSlipWork.EstimateNote5; // 見積備考５
            frePSalesSlipWork.SALESSLIPRF_SLIPNOTE3RF = salesSlipWork.SlipNote3; // 伝票備考３
            frePSalesSlipWork.SALESSLIPRF_RESULTSADDUPSECCDRF = salesSlipWork.ResultsAddUpSecCd; // 実績計上拠点コード
            # endregion

            return frePSalesSlipWork;
        }
        /// <summary>
        /// UOE伝票用 データ移行処理（売上明細work→自由帳票売上明細work）
        /// </summary>
        /// <param name="salesDetailWork"></param>
        /// <returns></returns>
        public static FrePSalesDetailWork CopyToFrePSalesDetailWorkFromSalesDetail( SalesDetailWork salesDetailWork )
        {
            FrePSalesDetailWork frePSalesDetailWork = new FrePSalesDetailWork();

            # region [copy]
            frePSalesDetailWork.SALESDETAILRF_ACPTANODRSTATUSRF = salesDetailWork.AcptAnOdrStatus; // 受注ステータス
            frePSalesDetailWork.SALESDETAILRF_SALESSLIPNUMRF = salesDetailWork.SalesSlipNum; // 売上伝票番号
            frePSalesDetailWork.SALESDETAILRF_ACCEPTANORDERNORF = salesDetailWork.AcceptAnOrderNo; // 受注番号
            frePSalesDetailWork.SALESDETAILRF_SALESROWNORF = salesDetailWork.SalesRowNo; // 売上行番号
            frePSalesDetailWork.SALESDETAILRF_SALESDATERF = ToLongDate( salesDetailWork.SalesDate ); // 売上日付
            frePSalesDetailWork.SALESDETAILRF_COMMONSEQNORF = salesDetailWork.CommonSeqNo; // 共通通番
            frePSalesDetailWork.SALESDETAILRF_SALESSLIPDTLNUMRF = salesDetailWork.SalesSlipDtlNum; // 売上明細通番
            frePSalesDetailWork.SALESDETAILRF_ACPTANODRSTATUSSRCRF = salesDetailWork.AcptAnOdrStatusSrc; // 受注ステータス（元）
            frePSalesDetailWork.SALESDETAILRF_SALESSLIPDTLNUMSRCRF = salesDetailWork.SalesSlipDtlNumSrc; // 売上明細通番（元）
            frePSalesDetailWork.SALESDETAILRF_SUPPLIERFORMALSYNCRF = salesDetailWork.SupplierFormalSync; // 仕入形式（同時）
            frePSalesDetailWork.SALESDETAILRF_STOCKSLIPDTLNUMSYNCRF = salesDetailWork.StockSlipDtlNumSync; // 仕入明細通番（同時）
            frePSalesDetailWork.SALESDETAILRF_SALESSLIPCDDTLRF = salesDetailWork.SalesSlipCdDtl; // 売上伝票区分（明細）
            frePSalesDetailWork.SALESDETAILRF_DELIGDSCMPLTDUEDATERF = ToLongDate( salesDetailWork.DeliGdsCmpltDueDate ); // 納品完了予定日
            frePSalesDetailWork.SALESDETAILRF_GOODSKINDCODERF = salesDetailWork.GoodsKindCode; // 商品属性
            frePSalesDetailWork.SALESDETAILRF_GOODSMAKERCDRF = salesDetailWork.GoodsMakerCd; // 商品メーカーコード
            frePSalesDetailWork.SALESDETAILRF_MAKERNAMERF = salesDetailWork.MakerName; // メーカー名称
            frePSalesDetailWork.SALESDETAILRF_GOODSNORF = salesDetailWork.GoodsNo; // 商品番号
            frePSalesDetailWork.SALESDETAILRF_GOODSNAMERF = salesDetailWork.GoodsName; // 商品名称
            frePSalesDetailWork.SALESDETAILRF_BLGOODSCODERF = salesDetailWork.BLGoodsCode; // BL商品コード
            frePSalesDetailWork.SALESDETAILRF_BLGOODSFULLNAMERF = salesDetailWork.BLGoodsFullName; // BL商品コード名称（全角）
            frePSalesDetailWork.SALESDETAILRF_ENTERPRISEGANRECODERF = salesDetailWork.EnterpriseGanreCode; // 自社分類コード
            frePSalesDetailWork.SALESDETAILRF_ENTERPRISEGANRENAMERF = salesDetailWork.EnterpriseGanreName; // 自社分類名称
            frePSalesDetailWork.SALESDETAILRF_WAREHOUSECODERF = salesDetailWork.WarehouseCode; // 倉庫コード
            frePSalesDetailWork.SALESDETAILRF_WAREHOUSENAMERF = salesDetailWork.WarehouseName; // 倉庫名称
            frePSalesDetailWork.SALESDETAILRF_WAREHOUSESHELFNORF = salesDetailWork.WarehouseShelfNo; // 倉庫棚番
            frePSalesDetailWork.SALESDETAILRF_SALESORDERDIVCDRF = salesDetailWork.SalesOrderDivCd; // 売上在庫取寄せ区分
            frePSalesDetailWork.SALESDETAILRF_OPENPRICEDIVRF = salesDetailWork.OpenPriceDiv; // オープン価格区分
            frePSalesDetailWork.SALESDETAILRF_GOODSRATERANKRF = salesDetailWork.GoodsRateRank; // 商品掛率ランク
            frePSalesDetailWork.SALESDETAILRF_CUSTRATEGRPCODERF = salesDetailWork.CustRateGrpCode; // 得意先掛率グループコード
            frePSalesDetailWork.SALESDETAILRF_LISTPRICERATERF = salesDetailWork.ListPriceRate; // 定価率
            frePSalesDetailWork.SALESDETAILRF_LISTPRICETAXINCFLRF = salesDetailWork.ListPriceTaxIncFl; // 定価（税込，浮動）
            frePSalesDetailWork.SALESDETAILRF_LISTPRICETAXEXCFLRF = salesDetailWork.ListPriceTaxExcFl; // 定価（税抜，浮動）
            frePSalesDetailWork.SALESDETAILRF_LISTPRICECHNGCDRF = salesDetailWork.ListPriceChngCd; // 定価変更区分
            frePSalesDetailWork.SALESDETAILRF_SALESRATERF = salesDetailWork.SalesRate; // 売価率
            frePSalesDetailWork.SALESDETAILRF_SALESUNPRCTAXINCFLRF = salesDetailWork.SalesUnPrcTaxIncFl; // 売上単価（税込，浮動）
            frePSalesDetailWork.SALESDETAILRF_SALESUNPRCTAXEXCFLRF = salesDetailWork.SalesUnPrcTaxExcFl; // 売上単価（税抜，浮動）
            frePSalesDetailWork.SALESDETAILRF_COSTRATERF = salesDetailWork.CostRate; // 原価率
            frePSalesDetailWork.SALESDETAILRF_SALESUNITCOSTRF = salesDetailWork.SalesUnitCost; // 原価単価
            frePSalesDetailWork.SALESDETAILRF_SHIPMENTCNTRF = salesDetailWork.ShipmentCnt; // 出荷数
            frePSalesDetailWork.SALESDETAILRF_ACCEPTANORDERCNTRF = salesDetailWork.AcceptAnOrderCnt; // 受注数量
            frePSalesDetailWork.SALESDETAILRF_ACPTANODRADJUSTCNTRF = salesDetailWork.AcptAnOdrAdjustCnt; // 受注調整数
            frePSalesDetailWork.SALESDETAILRF_ACPTANODRREMAINCNTRF = salesDetailWork.AcptAnOdrRemainCnt; // 受注残数
            frePSalesDetailWork.SALESDETAILRF_REMAINCNTUPDDATERF = ToLongDate( salesDetailWork.RemainCntUpdDate ); // 残数更新日
            frePSalesDetailWork.SALESDETAILRF_SALESMONEYTAXINCRF = salesDetailWork.SalesMoneyTaxInc; // 売上金額（税込み）
            frePSalesDetailWork.SALESDETAILRF_SALESMONEYTAXEXCRF = salesDetailWork.SalesMoneyTaxExc; // 売上金額（税抜き）
            frePSalesDetailWork.SALESDETAILRF_COSTRF = salesDetailWork.Cost; // 原価
            frePSalesDetailWork.SALESDETAILRF_GRSPROFITCHKDIVRF = salesDetailWork.GrsProfitChkDiv; // 粗利チェック区分
            frePSalesDetailWork.SALESDETAILRF_SALESGOODSCDRF = salesDetailWork.SalesGoodsCd; // 売上商品区分
            frePSalesDetailWork.SALESDETAILRF_TAXATIONDIVCDRF = salesDetailWork.TaxationDivCd; // 課税区分
            frePSalesDetailWork.SALESDETAILRF_PARTYSLIPNUMDTLRF = salesDetailWork.PartySlipNumDtl; // 相手先伝票番号（明細）
            frePSalesDetailWork.SALESDETAILRF_DTLNOTERF = salesDetailWork.DtlNote; // 明細備考
            frePSalesDetailWork.SALESDETAILRF_SUPPLIERCDRF = salesDetailWork.SupplierCd; // 仕入先コード
            frePSalesDetailWork.SALESDETAILRF_SUPPLIERSNMRF = salesDetailWork.SupplierSnm; // 仕入先略称
            frePSalesDetailWork.SALESDETAILRF_ORDERNUMBERRF = salesDetailWork.OrderNumber; // 発注番号
            frePSalesDetailWork.SALESDETAILRF_SLIPMEMO1RF = salesDetailWork.SlipMemo1; // 伝票メモ１
            frePSalesDetailWork.SALESDETAILRF_SLIPMEMO2RF = salesDetailWork.SlipMemo2; // 伝票メモ２
            frePSalesDetailWork.SALESDETAILRF_SLIPMEMO3RF = salesDetailWork.SlipMemo3; // 伝票メモ３
            frePSalesDetailWork.SALESDETAILRF_INSIDEMEMO1RF = salesDetailWork.InsideMemo1; // 社内メモ１
            frePSalesDetailWork.SALESDETAILRF_INSIDEMEMO2RF = salesDetailWork.InsideMemo2; // 社内メモ２
            frePSalesDetailWork.SALESDETAILRF_INSIDEMEMO3RF = salesDetailWork.InsideMemo3; // 社内メモ３
            frePSalesDetailWork.SALESDETAILRF_BFLISTPRICERF = salesDetailWork.BfListPrice; // 変更前定価
            frePSalesDetailWork.SALESDETAILRF_BFSALESUNITPRICERF = salesDetailWork.BfSalesUnitPrice; // 変更前売価
            frePSalesDetailWork.SALESDETAILRF_BFUNITCOSTRF = salesDetailWork.BfUnitCost; // 変更前原価
            frePSalesDetailWork.SALESDETAILRF_CMPLTSALESROWNORF = salesDetailWork.CmpltSalesRowNo; // 一式明細番号
            frePSalesDetailWork.SALESDETAILRF_CMPLTGOODSMAKERCDRF = salesDetailWork.CmpltGoodsMakerCd; // メーカーコード（一式）
            frePSalesDetailWork.SALESDETAILRF_CMPLTMAKERNAMERF = salesDetailWork.CmpltMakerName; // メーカー名称（一式）
            frePSalesDetailWork.SALESDETAILRF_CMPLTGOODSNAMERF = salesDetailWork.CmpltGoodsName; // 商品名称（一式）
            frePSalesDetailWork.SALESDETAILRF_CMPLTSHIPMENTCNTRF = salesDetailWork.CmpltShipmentCnt; // 数量（一式）
            frePSalesDetailWork.SALESDETAILRF_CMPLTSALESUNPRCFLRF = salesDetailWork.CmpltSalesUnPrcFl; // 売上単価（一式）
            frePSalesDetailWork.SALESDETAILRF_CMPLTSALESMONEYRF = salesDetailWork.CmpltSalesMoney; // 売上金額（一式）
            frePSalesDetailWork.SALESDETAILRF_CMPLTSALESUNITCOSTRF = salesDetailWork.CmpltSalesUnitCost; // 原価単価（一式）
            frePSalesDetailWork.SALESDETAILRF_CMPLTCOSTRF = salesDetailWork.CmpltCost; // 原価金額（一式）
            frePSalesDetailWork.SALESDETAILRF_CMPLTPARTYSALSLNUMRF = salesDetailWork.CmpltPartySalSlNum; // 相手先伝票番号（一式）
            frePSalesDetailWork.SALESDETAILRF_CMPLTNOTERF = salesDetailWork.CmpltNote; // 一式備考
            frePSalesDetailWork.SALESDETAILRF_PRTBLGOODSCODERF = salesDetailWork.PrtBLGoodsCode; // BL商品コード（印刷）
            frePSalesDetailWork.SALESDETAILRF_PRTBLGOODSNAMERF = salesDetailWork.PrtBLGoodsName; // BL商品コード名称（印刷）
            frePSalesDetailWork.SALESDETAILRF_PRTGOODSNORF = salesDetailWork.PrtGoodsNo; // 印刷用品番
            frePSalesDetailWork.SALESDETAILRF_PRTMAKERCODERF = salesDetailWork.PrtMakerCode; // 印刷用メーカーコード
            frePSalesDetailWork.SALESDETAILRF_PRTMAKERNAMERF = salesDetailWork.PrtMakerName; // 印刷用メーカー名称
            frePSalesDetailWork.SALESDETAILRF_GOODSLGROUPRF = salesDetailWork.GoodsLGroup; // 商品大分類コード
            frePSalesDetailWork.SALESDETAILRF_GOODSLGROUPNAMERF = salesDetailWork.GoodsLGroupName; // 商品大分類名称
            frePSalesDetailWork.SALESDETAILRF_GOODSMGROUPRF = salesDetailWork.GoodsMGroup; // 商品中分類コード
            frePSalesDetailWork.SALESDETAILRF_GOODSMGROUPNAMERF = salesDetailWork.GoodsMGroupName; // 商品中分類名称
            frePSalesDetailWork.SALESDETAILRF_BLGROUPCODERF = salesDetailWork.BLGroupCode; // BLグループコード
            frePSalesDetailWork.SALESDETAILRF_BLGROUPNAMERF = salesDetailWork.BLGroupName; // BLグループコード名称
            frePSalesDetailWork.SALESDETAILRF_SALESCODERF = salesDetailWork.SalesCode; // 販売区分コード
            frePSalesDetailWork.SALESDETAILRF_SALESCDNMRF = salesDetailWork.SalesCdNm; // 販売区分名称
            frePSalesDetailWork.SALESDETAILRF_GOODSNAMEKANARF = salesDetailWork.GoodsNameKana; // 商品名称カナ
            frePSalesDetailWork.SALESDETAILRF_AUTOANSWERDIVSCMRF = salesDetailWork.AutoAnswerDivSCM; // 自動回答区分(SCM)// ADD 2011/07/29
            # endregion

            return frePSalesDetailWork;
        }
        /// <summary>
        /// 日付変換処理
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        private static int ToLongDate( DateTime date )
        {
            if ( date == DateTime.MinValue )
            {
                return 0;
            }
            else
            {
                try
                {
                    return (date.Year * 10000) + (date.Month * 100) + date.Day;
                }
                catch
                {
                    return 0;
                }
            }
        }
        # endregion
        # endregion

        # region [マスタ取得]

        # region [伝票印刷設定取得]

        # region [伝票印刷設定取得・売上用]
        /// <summary>
        /// デフォルト伝票印刷用帳票ＩＤ取得処理（売上用）
        /// </summary>
        /// <param name="slipKind"></param>
        /// <param name="slipWork"></param>
        /// <returns></returns>
        private CustSlipMngWork GetSlipPrintTypeDefault( int slipKind, FrePSalesSlipWork slipWork )
        {
            CustSlipMngWork custSlipMngWork = null;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/01 ADD
            if ( slipWork.SALESSLIPRF_CUSTOMERCODERF != 0 )
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/01 ADD
            {
                // 得意先毎[拠点=0]
                custSlipMngWork = FindCustSlipMngWork( _enterpriseCode, ct_SectionZero, slipWork.SALESSLIPRF_CUSTOMERCODERF, slipKind );
                if ( custSlipMngWork == null )
                {
                    // ※このテーブルのデータセット仕様が不安定なので、拠点＝"0"も検索する
                    custSlipMngWork = FindCustSlipMngWork( _enterpriseCode, "0", slipWork.SALESSLIPRF_CUSTOMERCODERF, slipKind );
                }
            }

            // 拠点毎[得意先=0]
            if ( custSlipMngWork == null )
            {
                custSlipMngWork = FindCustSlipMngWork( _enterpriseCode, _loginSectionCode, ct_CustomerZero, slipKind );
            }

            // 全社設定[拠点=0,得意先=0]
            if ( custSlipMngWork == null )
            {
                custSlipMngWork = FindCustSlipMngWork( _enterpriseCode, ct_SectionZero, ct_CustomerZero, slipKind );
                if ( custSlipMngWork == null )
                {
                    // ※このテーブルのデータセット仕様が不安定なので、拠点＝"0"も検索する
                    custSlipMngWork = FindCustSlipMngWork( _enterpriseCode, "0", ct_CustomerZero, slipKind );
                }
            }
            return custSlipMngWork;
        }

        // add by zhouzy for PCCUOEリモート伝票発行 20110811 begin
        /// <summary>
        /// デフォルト伝票印刷用帳票ＩＤ取得処理（売上リモート伝票発行用）
        /// </summary>
        /// <param name="slipKind">伝票種別</param>
        /// <param name="slipWork">売上伝票データ</param>
        /// <returns>デフォルト伝票印刷用帳票ＩＤ</returns>
        private RmSlpPrtStWork GetRemoteSlipPrintTypeDefault(int slipKind, FrePSalesSlipWork slipWork)
        {
            RmSlpPrtStWork rmSlpPrtStWork = null;

            if (slipWork.SALESSLIPRF_CUSTOMERCODERF != 0)
            {
                // 得意先毎[拠点=0]
                rmSlpPrtStWork = FindRmSlpPrtStWork(_enterpriseCode, _loginSectionCode, slipWork.SALESSLIPRF_CUSTOMERCODERF, slipKind);
            }
            return rmSlpPrtStWork;
        }
        // add by zhouzy for PCCUOEリモート伝票発行 20110811  end

        /// <summary>
        /// デフォルトの伝票出力先設定取得（売上用）
        /// </summary>
        /// <param name="slipPrtKind">伝票種別</param>
        /// <param name="slipPrtSetPaperId">伝票印刷用帳票ＩＤ</param>
        /// <param name="cashRegisterNo">レジ番号</param>
        /// <param name="slipWork">売上伝票データ</param>
        /// <param name="detailWork">売上明細データ</param>
        /// <param name="eachWarehouseSetEnable">倉庫毎設定有効区分</param>
        /// <returns>伝票出力先設定work</returns>
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/02 DEL
        //private SlipOutputSetWork GetSlipOutputSetDefault( int slipPrtKind, string slipPrtSetPaperId, int cashRegisterNo, FrePSalesSlipWork slipWork, FrePSalesDetailWork detailWork )
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/02 DEL
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/02 ADD
        private SlipOutputSetWork GetSlipOutputSetDefault( int slipPrtKind, string slipPrtSetPaperId, int cashRegisterNo, FrePSalesSlipWork slipWork, FrePSalesDetailWork detailWork, bool eachWarehouseSetEnable )
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/02 ADD
        {
            SlipOutputSetWork slipOutputSetWork = null;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/02 ADD
            if ( eachWarehouseSetEnable )
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/02 ADD
            {
                // 倉庫毎（倉庫＋レジ）[拠点=0]
                slipOutputSetWork = FindSlipOutputSetWork( _enterpriseCode, ct_SectionZero, cashRegisterNo, detailWork.SALESDETAILRF_WAREHOUSECODERF, slipPrtKind, slipPrtSetPaperId );
            }

            // レジ毎[拠点=0,倉庫=0]
            if ( slipOutputSetWork == null )
            {
                slipOutputSetWork = FindSlipOutputSetWork( _enterpriseCode, ct_SectionZero, cashRegisterNo, ct_WarehouseZero, slipPrtKind, slipPrtSetPaperId );
            }

            // 拠点毎[倉庫=0,レジ=0]
            if ( slipOutputSetWork == null )
            {
                slipOutputSetWork = FindSlipOutputSetWork( _enterpriseCode, _loginSectionCode, ct_CashRegisterZero, ct_WarehouseZero, slipPrtKind, slipPrtSetPaperId );
            }

            // 全社設定[拠点=0,倉庫=0,レジ=0]
            if ( slipOutputSetWork == null )
            {
                slipOutputSetWork = FindSlipOutputSetWork( _enterpriseCode, ct_SectionZero, ct_CashRegisterZero, ct_WarehouseZero, slipPrtKind, slipPrtSetPaperId );
            }
            return slipOutputSetWork;
        }
        # endregion

        # region [伝票印刷設定取得・見積書用]
        /// <summary>
        /// デフォルト伝票印刷用帳票ＩＤ取得処理（見積書用）
        /// </summary>
        /// <param name="slipKind"></param>
        /// <param name="slipWork"></param>
        /// <returns></returns>
        private CustSlipMngWork GetSlipPrintTypeDefaultForEstFm( int slipKind, FrePSalesSlipWork slipWork )
        {
            CustSlipMngWork custSlipMngWork = null;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/01 ADD
            if ( slipWork.SALESSLIPRF_CUSTOMERCODERF != 0 )
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/01 ADD
            {
                // 得意先毎[拠点=0]
                custSlipMngWork = FindCustSlipMngWork( _enterpriseCode, ct_SectionZero, slipWork.SALESSLIPRF_CUSTOMERCODERF, slipKind );
                if ( custSlipMngWork == null )
                {
                    // ※このテーブルのデータセット仕様が不安定なので、拠点＝"0"も検索する
                    custSlipMngWork = FindCustSlipMngWork( _enterpriseCode, "0", slipWork.SALESSLIPRF_CUSTOMERCODERF, slipKind );
                }
            }

            // 拠点毎[得意先=0]
            if ( custSlipMngWork == null )
            {
                custSlipMngWork = FindCustSlipMngWork( _enterpriseCode, _loginSectionCode, ct_CustomerZero, slipKind );
            }

            // 全社設定[拠点=0,得意先=0]
            if ( custSlipMngWork == null )
            {
                custSlipMngWork = FindCustSlipMngWork( _enterpriseCode, ct_SectionZero, ct_CustomerZero, slipKind );
                if ( custSlipMngWork == null )
                {
                    // ※このテーブルのデータセット仕様が不安定なので、拠点＝"0"も検索する
                    custSlipMngWork = FindCustSlipMngWork( _enterpriseCode, "0", ct_CustomerZero, slipKind );
                }
            }
            return custSlipMngWork;
        }
        /// <summary>
        /// デフォルトの伝票出力先設定取得（見積書用）
        /// </summary>
        /// <param name="slipPrtKind">伝票種別</param>
        /// <param name="slipPrtSetPaperId">伝票印刷用帳票ＩＤ</param>
        /// <param name="cashRegisterNo">レジ番号</param>
        /// <param name="slipWork">見積書ヘッダデータ</param>
        /// <returns>伝票出力先設定work</returns>
        private SlipOutputSetWork GetSlipOutputSetDefaultForEstFm( int slipPrtKind, string slipPrtSetPaperId, int cashRegisterNo, FrePSalesSlipWork slipWork )
        {
            SlipOutputSetWork slipOutputSetWork = null;

            //// 倉庫毎（倉庫＋レジ）[拠点=0]
            //slipOutputSetWork = FindSlipOutputSetWork( _enterpriseCode, ct_SectionZero, cashRegisterNo, detailWork.SALESDETAILRF_WAREHOUSECODERF, slipPrtKind, slipPrtSetPaperId );

            // レジ毎[拠点=0,倉庫=0]
            //if ( slipOutputSetWork == null )
            //{
                slipOutputSetWork = FindSlipOutputSetWork( _enterpriseCode, ct_SectionZero, cashRegisterNo, ct_WarehouseZero, slipPrtKind, slipPrtSetPaperId );
            //}

            // 拠点毎[倉庫=0,レジ=0]
            if ( slipOutputSetWork == null )
            {
                slipOutputSetWork = FindSlipOutputSetWork( _enterpriseCode, _loginSectionCode, ct_CashRegisterZero, ct_WarehouseZero, slipPrtKind, slipPrtSetPaperId );
            }

            // 全社設定[拠点=0,倉庫=0,レジ=0]
            if ( slipOutputSetWork == null )
            {
                slipOutputSetWork = FindSlipOutputSetWork( _enterpriseCode, ct_SectionZero, ct_CashRegisterZero, ct_WarehouseZero, slipPrtKind, slipPrtSetPaperId );
            }
            return slipOutputSetWork;
        }
        # endregion

        # region [伝票印刷設定取得・在庫移動用]
        /// <summary>
        /// デフォルト伝票印刷用帳票ＩＤ取得処理（在庫移動用）
        /// </summary>
        /// <param name="slipKind"></param>
        /// <param name="slipWork"></param>
        /// <returns></returns>
        private CustSlipMngWork GetSlipPrintTypeDefault( int slipKind, FrePStockMoveSlipWork slipWork )
        {
            CustSlipMngWork custSlipMngWork = null;

            //// 得意先毎[拠点=0]
            //custSlipMngWork = FindCustSlipMngWork( _enterpriseCode, ct_SectionZero, slipWork.SALESSLIPRF_CUSTOMERCODERF, slipKind );
            //if ( custSlipMngWork == null )
            //{
            //    // ※このテーブルのデータセット仕様が不安定なので、拠点＝"0"も検索する
            //    custSlipMngWork = FindCustSlipMngWork( _enterpriseCode, "0", slipWork.SALESSLIPRF_CUSTOMERCODERF, slipKind );
            //}

            // 拠点毎[得意先=0]
            if ( custSlipMngWork == null )
            {
                custSlipMngWork = FindCustSlipMngWork( _enterpriseCode, _loginSectionCode, ct_CustomerZero, slipKind );
            }

            // 全社設定[拠点=0,得意先=0]
            if ( custSlipMngWork == null )
            {
                custSlipMngWork = FindCustSlipMngWork( _enterpriseCode, ct_SectionZero, ct_CustomerZero, slipKind );
                if ( custSlipMngWork == null )
                {
                    // ※このテーブルのデータセット仕様が不安定なので、拠点＝"0"も検索する
                    custSlipMngWork = FindCustSlipMngWork( _enterpriseCode, "0", ct_CustomerZero, slipKind );
                }
            }
            return custSlipMngWork;
        }
        /// <summary>
        /// デフォルトの伝票出力先設定取得（在庫移動用）
        /// </summary>
        /// <param name="slipPrtKind">伝票種別</param>
        /// <param name="slipPrtSetPaperId">伝票印刷用帳票ＩＤ</param>
        /// <param name="cashRegisterNo">レジ番号</param>
        /// <param name="slipWork">売上伝票データ</param>
        /// <param name="detailWork">売上明細データ</param>
        /// <returns>伝票出力先設定work</returns>
        /// <br>Update Note: 2014/10/27 wangf </br>
        /// <br>管理番号   : 11070149-00</br>
        /// <br>           : Redmine#43854「移動伝票出力先区分」よりプリンタ検索</br>
        private SlipOutputSetWork GetSlipOutputSetDefault( int slipPrtKind, string slipPrtSetPaperId, int cashRegisterNo, FrePStockMoveSlipWork slipWork, FrePStockMoveDetailWork detailWork )
        {
            SlipOutputSetWork slipOutputSetWork = null;
            // ------------ADD wangf 2014/10/27 FOR Redmine#43854 「移動伝票出力先区分」よりプリンタ検索--------->>>>
            // 移動伝票出力先区分取得
            int moveSlipOutPutDiv = 0;
            StockMngTtlStWork stockMngTtlStWork = this.GetStockMngTtlSt();
            if (stockMngTtlStWork != null)
            {
                moveSlipOutPutDiv = stockMngTtlStWork.MoveSlipOutPutDiv;
            }
            // 「移動伝票出力先区分」により在庫コードか出庫コードか選択
            string enterWareHCode = moveSlipOutPutDiv == 0 ? slipWork.MOVH_AFENTERWAREHCODERF : slipWork.MOVH_BFENTERWAREHCODERF;
            // ------------ADD wangf 2014/10/27 FOR Redmine#43854 「移動伝票出力先区分」よりプリンタ検索---------<<<<

            // 倉庫毎（倉庫＋レジ）[拠点=0] （※移動先倉庫により制御）
            //slipOutputSetWork = FindSlipOutputSetWork( _enterpriseCode, ct_SectionZero, cashRegisterNo, slipWork.MOVH_AFENTERWAREHCODERF, slipPrtKind, slipPrtSetPaperId ); // DEL wangf 2014/10/27 FOR Redmine#43854 「移動伝票出力先区分」よりプリンタ検索
            slipOutputSetWork = FindSlipOutputSetWork(_enterpriseCode, ct_SectionZero, cashRegisterNo, enterWareHCode, slipPrtKind, slipPrtSetPaperId); // ADD wangf 2014/10/27 FOR Redmine#43854 「移動伝票出力先区分」よりプリンタ検索

            // レジ毎[拠点=0,倉庫=0]
            if ( slipOutputSetWork == null )
            {
                slipOutputSetWork = FindSlipOutputSetWork( _enterpriseCode, ct_SectionZero, cashRegisterNo, ct_WarehouseZero, slipPrtKind, slipPrtSetPaperId );
            }

            // 拠点毎[倉庫=0,レジ=0]
            if ( slipOutputSetWork == null )
            {
                slipOutputSetWork = FindSlipOutputSetWork( _enterpriseCode, _loginSectionCode, ct_CashRegisterZero, ct_WarehouseZero, slipPrtKind, slipPrtSetPaperId );
            }

            // 全社設定[拠点=0,倉庫=0,レジ=0]
            if ( slipOutputSetWork == null )
            {
                slipOutputSetWork = FindSlipOutputSetWork( _enterpriseCode, ct_SectionZero, ct_CashRegisterZero, ct_WarehouseZero, slipPrtKind, slipPrtSetPaperId );
            }
            return slipOutputSetWork;
        }
        # endregion

        # region [伝票印刷設定取得・共通]
        /// <summary>
        /// 伝票タイプ名称リスト取得処理
        /// </summary>
        /// <param name="slipKind"></param>
        /// <param name="printData"></param>
        /// <param name="defaultPrtTypeIndex"></param>
        /// <param name="defaultPrinterMngNo"></param>
        /// <returns></returns>
        public Dictionary<int, string> GetSlipPrintTypeList( int slipKind, List<ArrayList> printData, out int defaultPrtTypeIndex, out int defaultPrinterMngNo  )
        {
            // 出力パラメータ初期化
            defaultPrtTypeIndex = 0;
            defaultPrinterMngNo = 0;

            // 新規ディクショナリ
            Dictionary<int, string> retDic = new Dictionary<int, string>();

            try
            {
                string defaultSlipPrtSetPaperId = string.Empty;

                # region [印刷種別毎の情報取得]
                switch ( slipKind )
                {
                    //----------------------------------------------------------
                    // 10:見積書
                    //----------------------------------------------------------
                    case 10:
                        {
                            FrePEstFmHead slipWork = (printData[0][0] as FrePEstFmHead);
                            // デフォルトの伝票印刷用帳票ＩＤを取得
                            defaultSlipPrtSetPaperId = slipWork.HADD_SLIPPRTSETPAPERIDRF;
                            // デフォルトのプリンタ管理№を取得
                            defaultPrinterMngNo = slipWork.HADD_PRINTERMNGNORF;
                        }
                        break;
                    //----------------------------------------------------------
                    // 40:仕入返品伝票
                    //----------------------------------------------------------
                    case 40:
                        {

                        }
                        break;
                    //----------------------------------------------------------
                    // 150:在庫移動伝票
                    //----------------------------------------------------------
                    case 150:
                        {
                            FrePStockMoveSlipWork slipWork = (printData[0][0] as FrePStockMoveSlipWork);
                            // デフォルトの伝票印刷用帳票ＩＤを取得
                            defaultSlipPrtSetPaperId = slipWork.HADD_SLIPPRTSETPAPERIDRF;
                            // デフォルトのプリンタ管理№を取得
                            defaultPrinterMngNo = slipWork.HADD_PRINTERMNGNORF;
                        }
                        break;
                    //----------------------------------------------------------
                    // 160:ＵＯＥ伝票
                    //----------------------------------------------------------
                    case 160:
                        {
                            FrePSalesSlipWork slipWork = (printData[0][0] as FrePSalesSlipWork);
                            // デフォルトの伝票印刷用帳票ＩＤを取得
                            defaultSlipPrtSetPaperId = slipWork.HADD_SLIPPRTSETPAPERIDRF;
                            // デフォルトのプリンタ管理№を取得
                            defaultPrinterMngNo = slipWork.HADD_PRINTERMNGNORF;
                        }
                        break;
                    //----------------------------------------------------------
                    // 売上・受注・出荷・見積伝票
                    //----------------------------------------------------------
                    default:
                        {
                            FrePSalesSlipWork slipWork = (printData[0][0] as FrePSalesSlipWork);
                            // デフォルトの伝票印刷用帳票ＩＤを取得
                            defaultSlipPrtSetPaperId = slipWork.HADD_SLIPPRTSETPAPERIDRF;
                            // デフォルトのプリンタ管理№を取得
                            defaultPrinterMngNo = slipWork.HADD_PRINTERMNGNORF;
                        }
                        break;
                }
                # endregion

                // 伝票印刷設定リストから該当レコードのみをディクショナリに追加する
                if ( _slipPrtSetWorkList != null )
                {
                    for ( int index = 0; index < _slipPrtSetWorkList.Count; index++ )
                    {
                        SlipPrtSetWork slipPrtSetWork = _slipPrtSetWorkList[index];
                        if ( slipPrtSetWork.SlipPrtKind == slipKind )
                        {
                            // 条件に該当するレコードをディクショナリに追加する。
                            retDic.Add( index, slipPrtSetWork.SlipComment );

                            // デフォルトＩＤと一致したらindexを退避
                            if ( slipPrtSetWork.SlipPrtSetPaperId == defaultSlipPrtSetPaperId )
                            {
                                defaultPrtTypeIndex = index;
                            }
                        }
                    }
                }

            }
            catch
            {
            }

            return retDic;
        }
        /// <summary>
        /// 選択中 伝票印刷設定 取得処理
        /// </summary>
        /// <param name="selectedIndex"></param>
        /// <returns></returns>
        public SlipPrtSetWork GetSlipPrtSetWork( int selectedIndex )
        {
            return _slipPrtSetWorkList[selectedIndex];
        }
        /// <summary>
        /// デフォルト伝票印刷用帳票ＩＤ取得処理
        /// </summary>
        /// <param name="slipKind"></param>
        /// <param name="printData"></param>
        /// <returns>伝票印刷用帳票ＩＤ（SlipPrtSetPaperId）</returns>
        private string GetSlipPrintTypeDefault( int slipKind, List<ArrayList> printData )
        {
            FrePSalesSlipWork slipWork = (FrePSalesSlipWork)printData[0][0];
            CustSlipMngWork custSlipMngWork = GetSlipPrintTypeDefault( slipKind, slipWork );

            if ( custSlipMngWork != null )
            {
                return custSlipMngWork.SlipPrtSetPaperId;
            }
            else
            {
                return string.Empty;
            }
        }
        /// <summary>
        /// 得意先マスタ伝票管理（伝票タイプ管理マスタ）Find処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="slipPrtKind">伝票印刷種別</param>
        /// <returns></returns>
        private CustSlipMngWork FindCustSlipMngWork( string enterpriseCode, string sectionCode, int customerCode, int slipPrtKind )
        {
            if ( _custSlipMngWorkList == null ) return null;

            return _custSlipMngWorkList.Find(
                        delegate( CustSlipMngWork custSlipMngWork )
                        {
                            return (custSlipMngWork.EnterpriseCode == enterpriseCode)
                                    && ((custSlipMngWork.SectionCode.Trim() == sectionCode.Trim()) || ((sectionCode.Trim() == ct_SectionZero) && (custSlipMngWork.SectionCode.Trim() == string.Empty)))
                                    && (custSlipMngWork.CustomerCode == customerCode)
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/02 ADD
                                    && (custSlipMngWork.LogicalDeleteCode == 0)
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/02 ADD
                                    && (custSlipMngWork.SlipPrtKind == slipPrtKind);
                        });
        }
        // add by zhouzy for PCCUOEリモート伝票発行 20110811 begin
        /// <summary>
        /// リモート伝票発行設定Find処理(リモート伝票発行)
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="slipPrtKind">伝票印刷種別</param>
        /// <returns>リモート伝票発行設定情報</returns>
        private RmSlpPrtStWork FindRmSlpPrtStWork(string enterpriseCode, string sectionCode, int customerCode, int slipPrtKind)
        {
            if (_rmSlpPrtStWorkList == null) return null;

            return _rmSlpPrtStWorkList.Find(
                        delegate(RmSlpPrtStWork rmSlpPrtStWork)
                        {
                            return (rmSlpPrtStWork.InqOtherEpCd == enterpriseCode)
                                    && ((rmSlpPrtStWork.InqOtherSecCd.Trim() == sectionCode.Trim()) || ((sectionCode.Trim() == ct_SectionZero) && (rmSlpPrtStWork.InqOtherSecCd.Trim() == string.Empty)))
                                    && (rmSlpPrtStWork.PccCompanyCode == customerCode)
                                    && (rmSlpPrtStWork.LogicalDeleteCode == 0)
                                    && (rmSlpPrtStWork.SlipPrtKind == slipPrtKind);
                        });
        }
        // add by zhouzy for PCCUOEリモート伝票発行 20110811  end
        /// <summary>
        /// 伝票出力先マスタFind処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="cashRegisterNo">レジ番号</param>
        /// <param name="warehouseCode">倉庫コード</param>
        /// <param name="slipPrtKind">伝票印刷種別</param>
        /// <param name="slipPrtSetPaperId">伝票印刷用帳票ＩＤ</param>
        /// <returns></returns>
        private SlipOutputSetWork FindSlipOutputSetWork( string enterpriseCode, string sectionCode, int cashRegisterNo, string warehouseCode, int slipPrtKind, string slipPrtSetPaperId )
        {
            if ( _slipOutputSetWorkList == null ) return null;

            return _slipOutputSetWorkList.Find(
                        delegate( SlipOutputSetWork slipOutputSetWork )
                        {
                            return (slipOutputSetWork.EnterpriseCode == enterpriseCode)
                                //&& (slipOutputSetWork.SectionCode == sectionCode)
                                    && (slipOutputSetWork.CashRegisterNo == cashRegisterNo)
                                    && ((slipOutputSetWork.WarehouseCode.Trim() == warehouseCode.Trim()) || ((warehouseCode.Trim() == ct_WarehouseZero) && (slipOutputSetWork.WarehouseCode.Trim() == string.Empty)))
                                    && (slipOutputSetWork.SlipPrtKind == slipPrtKind)
                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/02 ADD
                                    && (slipOutputSetWork.LogicalDeleteCode == 0)
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/02 ADD
                                    && (slipOutputSetWork.SlipPrtSetPaperId == slipPrtSetPaperId);
                        } );
        }
        # endregion

        # endregion

        # region [自由帳票印字位置設定取得]
        /// <summary>
        /// 自由帳票印字位置設定 取得処理
        /// </summary>
        /// <param name="slipPrtSet"></param>
        /// <returns></returns>
        /// <remarks>伝票印刷設定と結びつく自由帳票印字位置設定を取得します。該当がなければnullを返します。</remarks>
        public FrePrtPSetWork GetFrePrtPSet( SlipPrtSetWork slipPrtSet )
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/19 DEL
            //if ( slipPrtSet == null || _frePrtPSetWorkList == null || _frePrtPSetWorkList.Count <= 0 ) return null;

            //// 読み込みキー取得
            //string outputFormFileName;
            //int userPrtPprIdDerivNo;
            //GetFrePrtPSetReadKey( slipPrtSet, out outputFormFileName, out userPrtPprIdDerivNo );

            //// 条件に合致するレコードを取得
            //FrePrtPSetWork retWork = 
            //    _frePrtPSetWorkList.Find(
            //            delegate( FrePrtPSetWork frePrtPSetWork)
            //            {
            //                return ((frePrtPSetWork.OutputFormFileName == outputFormFileName)
            //                        && (frePrtPSetWork.UserPrtPprIdDerivNo == userPrtPprIdDerivNo));
            //            } );

            //if ( retWork != null && !_decryptedFrePrtPSetDic.ContainsKey( slipPrtSet.SlipPrtSetPaperId ) )
            //{
            //    // 印字位置データを復号化する
            //    //（※注意：retWork更新は_frePrtPSetWorkListの該当レコード更新を意味します）
            //    FrePrtSettingController.DecryptPrintPosClassData( retWork );
            //    // 復号化済みディクショナリに追加する
            //    _decryptedFrePrtPSetDic.Add( slipPrtSet.SlipPrtSetPaperId, true );
            //}
            //return retWork;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/19 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/19 ADD
            if ( slipPrtSet == null || _frePrtPSetWorkList == null || _frePrtPSetWorkList.Count <= 0 ) return null;

            // 条件に合致するレコードを取得
            FrePrtPSetWork retWork =
                _frePrtPSetWorkList.Find(
                        delegate( FrePrtPSetWork frePrtPSetWork )
                        {
                            return (frePrtPSetWork.OutputFormFileName == slipPrtSet.OutputFormFileName);
                        } );

            if ( retWork != null && !_decryptedFrePrtPSetDic.ContainsKey( retWork.OutputFormFileName ) )
            {
                // 印字位置データを復号化する
                //（※注意：retWork更新は_frePrtPSetWorkListの該当レコード更新を意味します）
                FrePrtSettingController.DecryptPrintPosClassData( retWork );
                // 復号化済みディクショナリに追加する
                _decryptedFrePrtPSetDic.Add( retWork.OutputFormFileName, true );
            }
            return retWork;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/19 ADD
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/02/19 DEL
        ///// <summary>
        ///// 自由帳票印字位置設定 読み込みキー情報取得
        ///// </summary>
        ///// <param name="slipPrtSetWork"></param>
        ///// <param name="outputFormFileName"></param>
        ///// <param name="userPrtPprIdDerivNo"></param>
        //private void GetFrePrtPSetReadKey( SlipPrtSetWork slipPrtSetWork, out string outputFormFileName, out int userPrtPprIdDerivNo )
        //{
        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/31 DEL
        //    //outputFormFileName = slipPrtSetWork.OutputFormFileName;
        //    //userPrtPprIdDerivNo = 0;

        //    //if ( slipPrtSetWork.SlipPrtSetPaperId.StartsWith( slipPrtSetWork.OutputFormFileName ) )
        //    //{
        //    //    string derivNoText = slipPrtSetWork.SlipPrtSetPaperId.Substring( slipPrtSetWork.OutputFormFileName.Length, slipPrtSetWork.SlipPrtSetPaperId.Length - slipPrtSetWork.OutputFormFileName.Length );
        //    //    try
        //    //    {
        //    //        userPrtPprIdDerivNo = Int32.Parse( derivNoText );
        //    //    }
        //    //    catch
        //    //    {
        //    //        userPrtPprIdDerivNo = 0;
        //    //    }
        //    //}
        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/31 DEL
        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/31 ADD
        //    outputFormFileName = slipPrtSetWork.OutputFormFileName;
        //    try
        //    {
        //        userPrtPprIdDerivNo = Int32.Parse( slipPrtSetWork.SpecialPurpose2 );
        //    }
        //    catch
        //    {
        //        userPrtPprIdDerivNo = 0;
        //    }
        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/31 ADD
        //}
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/02/19 DEL
        // --- ADD m.suzuki 2010/05/14 ---------->>>>>
        /// <summary>
        /// 自由帳票印字位置設定ディクショナリ取得
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, FrePrtPSetWork> GetFrePrtPSetDic()
        {
            Dictionary<string, FrePrtPSetWork> dic = new Dictionary<string, FrePrtPSetWork>();

            foreach ( FrePrtPSetWork frePrtPSet in _frePrtPSetWorkList )
            {
                if ( !dic.ContainsKey( frePrtPSet.OutputFormFileName.Trim() ) )
                {
                    dic.Add( frePrtPSet.OutputFormFileName.Trim(), frePrtPSet );
                }
            }

            return dic;
        }
        /// <summary>
        /// 復号化済み自由帳票印字位置設定ディクショナリ取得
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, bool> GetDecryptedFrePrtPSetDic()
        {
            if ( _decryptedFrePrtPSetDic == null )
            {
                return new Dictionary<string, bool>();
            }
            return _decryptedFrePrtPSetDic;
        }
        // --- ADD m.suzuki 2010/05/14 ----------<<<<<
        # endregion

        # region [プリンタ設定取得]
        /// <summary>
        /// プリンタ設定　全取得
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <returns></returns>
        /// <remarks>※プリンタ管理設定はローカルＸＭＬを読み込みます。</remarks>
        public List<PrtManage> SearchAllPrtManage(string enterpriseCode)
        {
            List<PrtManage> prtManageList = new List<PrtManage>();

            ArrayList retList;
            _prtManageAcs.SearchAll( out retList, enterpriseCode );

            foreach ( PrtManage prtManage in retList )
            {
                if ( prtManage.LogicalDeleteCode == 0 )
                {
                    prtManageList.Add( prtManage );
                }
            }

            return prtManageList;
        }
        # endregion

        # region [端末設定取得]
        /// <summary>
        /// 端末設定取得処理
        /// </summary>
        /// <param name="posTerminalMg">POS端末管理設定</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns></returns>
        private int GetPosTerminalMg( out PosTerminalMg posTerminalMg, string enterpriseCode )
        {
            PosTerminalMgAcs acs = new PosTerminalMgAcs();
            return acs.Search( out posTerminalMg, enterpriseCode );
        }
        // 2010/03/30 >>>
        /// <summary>
        /// 端末設定取得処理
        /// </summary>
        /// <param name="posTerminalMg">POS端末管理設定</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns></returns>
        private int GetPosTerminalMgServer( out PosTerminalMg posTerminalMg, string enterpriseCode )
        {
            PosTerminalMgAcs acs = new PosTerminalMgAcs();
            ArrayList al = new ArrayList();
            posTerminalMg = new PosTerminalMg();

            int st = acs.SearchServer( out al, enterpriseCode );

            // 起動端末のマシン名に一致するレコード取得
            foreach ( PosTerminalMg pos in al )
            {
                if ( Environment.MachineName == pos.MachineName )
                {
                    posTerminalMg = pos;
                }
            }

            return st;
        }
        // 2010/03/30 <<<
        # endregion

        # region [売上全体設定取得]
        /// <summary>
        /// 売上全体設定取得処理
        /// </summary>
        /// <returns></returns>
        public SalesTtlStWork GetSalesTtlSt()
        {
            // 拠点毎
            SalesTtlStWork retWork = FindSalesTtlSt( _loginSectionCode );
            if ( retWork == null )
            {
                // 全社設定[拠点=0]
                retWork = FindSalesTtlSt( ct_SectionZero );
            }

            return retWork;
        }
        /// <summary>
        /// 売上全体設定Find処理
        /// </summary>
        /// <param name="sectionCode"></param>
        /// <returns></returns>
        private SalesTtlStWork FindSalesTtlSt( string sectionCode )
        {
            if ( _salesTtlStWorkList == null ) return null;

            // 拠点コードが一致するレコードを返す
            return _salesTtlStWorkList.Find(
                    delegate( SalesTtlStWork salesTtlStWork )
                    {
                        return (salesTtlStWork.SectionCode == sectionCode);
                    } );
        }
        # endregion

        # region [全体初期表示設定取得]
        /// <summary>
        /// 全体初期表示設定取得処理
        /// </summary>
        /// <returns></returns>
        public AllDefSetWork GetAllDefSet()
        {
            // 拠点毎
            AllDefSetWork retWork = FindAllDefSet( _loginSectionCode );
            if ( retWork == null )
            {
                // 全社設定[拠点=0]
                retWork = FindAllDefSet( ct_SectionZero );
            }

            return retWork;
        }
        /// <summary>
        /// 全体初期表示設定Find処理
        /// </summary>
        /// <param name="sectionCode"></param>
        /// <returns></returns>
        private AllDefSetWork FindAllDefSet( string sectionCode )
        {
            if ( _allDefSetWorkList == null ) return null;

            // 拠点コードが一致するレコードを返す
            return _allDefSetWorkList.Find(
                    delegate( AllDefSetWork allDefSetWork )
                    {
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/09/08 DEL
                        //return (allDefSetWork.SectionCode == sectionCode);
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/09/08 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/09/08 ADD
                        return (allDefSetWork.SectionCode.Trim() == sectionCode.Trim());
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/09/08 ADD
                    } );
        }
        # endregion

        # region [在庫管理全体設定取得]
        /// <summary>
        /// 在庫管理全体設定取得処理
        /// </summary>
        /// <returns></returns>
        public StockMngTtlStWork GetStockMngTtlSt()
        {
            // 拠点毎
            StockMngTtlStWork retWork = FindStockMngTtlSt( _loginSectionCode );
            if ( retWork == null )
            {
                // 全社設定[拠点=0]
                retWork = FindStockMngTtlSt( ct_SectionZero );
            }
            return retWork;
        }
        /// <summary>
        /// 在庫管理全体設定Find処理
        /// </summary>
        /// <param name="sectionCode"></param>
        /// <returns></returns>
        /// <br>Update Note: 2014/10/27 wangf </br>
        /// <br>管理番号   : 11070149-00</br>
        /// <br>           : Redmine#43854「移動伝票出力先区分」よりプリンタ検索</br>
        private StockMngTtlStWork FindStockMngTtlSt( string sectionCode )
        {
            if ( _stockMngTtlStWorkList == null ) return null;

            // 拠点コードが一致するレコードを返す
            return _stockMngTtlStWorkList.Find(
                    delegate( StockMngTtlStWork stockMngTtlStWork )
                    {
                        //return (stockMngTtlStWork.SectionCode == sectionCode); // DEL wangf 2014/10/27 FOR Redmine#43854 「移動伝票出力先区分」よりプリンタ検索
                        return (stockMngTtlStWork.SectionCode.Trim() == sectionCode.Trim()); // ADD wangf 2014/10/27 FOR Redmine#43854 「移動伝票出力先区分」よりプリンタ検索
                    } );
        }
        # endregion

        // --- ADD  大矢睦美  2010/03/04 ---------->>>>>
        #region [税率設定取得]
        /// <summary>
        /// 税率設定取得処理
        /// </summary>
        /// <returns></returns>
        public TaxRateSetWork GetTaxRateSet()
        {
            //TaxRateSetWork taxRate = FindTaxRateSet( _taxRateCode );
            //return taxRate;
            return FindTaxRateSet(ct_TaxRateCodeZero);
        }
        /// <summary>
        /// 税率設定Find処理
        /// </summary>
        /// <param name="taxRateCode"></param>
        /// <returns></returns>
        private TaxRateSetWork FindTaxRateSet(Int32 taxRateCode)
        {
            if (_taxRateSetWorkList == null) return null;

            //税率コードが「0:一般消費税」と一致するレコードを返す
            return _taxRateSetWorkList.Find(
                   delegate(TaxRateSetWork taxRateSetWork)
                   {
                       return (taxRateSetWork.TaxRateCode == taxRateCode);
                   }
                );
        }
        #endregion

        #region [売上金額処理区分設定取得]
        /// <summary>
        /// 売上金額処理区分設定取得
        /// </summary>
        /// <returns></returns>
        public List<SalesProcMoneyWork> GetSalesProcMoney()
        {
            return _salesProcMoneyList;
        }

        #endregion
        // --- ADD  大矢睦美  2010/03/04 ----------<<<<<
        // --- ADD  大矢睦美  2010/05/18 ---------->>>>>
        #region[UOEガイド名称設定]
        /// <summary>
        /// UOEガイド名称設定取得処理
        /// </summary>
        /// <returns></returns>
        public UOEGuideNameWork GetUOEGuideName()
        {
            // 拠点毎
            UOEGuideNameWork retwork = FindUOEGuideName(_loginSectionCode);
            if (retwork == null)
            {
                // 全体設定[拠点=0]
                retwork = FindUOEGuideName(ct_SectionZero);
            }

            return retwork;
        }
        /// <summary>
        /// UOEガイド名称Find処理
        /// </summary>
        /// <param name="sectionCode"></param>
        /// <returns></returns>
        private UOEGuideNameWork FindUOEGuideName(string sectionCode)
        {
            if (_uoeGuideNameWorkList == null) return null;

            // 拠点コードが一致するレコードを返す
            return _uoeGuideNameWorkList.Find(
                delegate(UOEGuideNameWork uoeGuideNmWork)
                {
                    return (uoeGuideNmWork.SectionCode == sectionCode);
                } );
        }
        #endregion
        // --- ADD  大矢睦美  2010/05/18 ----------<<<<<

        # endregion

        # region [伝票リスト振分KEY定義]
        // --------------- ADD START 2013/06/17 zhubj FOR Redmine #36594-------->>>>
        # region [売上リモート伝票リスト振分KEY]
        /// <summary>
        /// 売上伝票リスト振分KEY
        /// </summary>
        private struct RmSalesSlipListKey
        {
            /// <summary>受注ステータス</summary>
            private int _acptAnOdrStatus;
            /// <summary>プリンタ管理№</summary>
            private int _printerMngNo;
            /// <summary>売上伝票番号</summary>
            private string _salesSlipNum;

            /// <summary>
            /// 売上伝票番号
            /// </summary>
            public string SalesSlipNum
            {
                get { return _salesSlipNum; }
                set { _salesSlipNum = value; }
            }

            /// <summary>
            /// 受注ステータス
            /// </summary>
            public int AcptAnOdrStatus
            {
                get { return _acptAnOdrStatus; }
                set { _acptAnOdrStatus = value; }
            }
            /// <summary>
            /// プリンタ管理№
            /// </summary>
            public int PrinterMngNo
            {
                get { return _printerMngNo; }
                set { _printerMngNo = value; }
            }
            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="acptAnOdrStatus">受注ステータス</param>
            /// <param name="printerMngNo">プリンタ管理№</param>
            /// <param name="salesSlipNum">売上伝票番号</param>
            public RmSalesSlipListKey(int acptAnOdrStatus, int printerMngNo, string salesSlipNum)
            {
                _acptAnOdrStatus = acptAnOdrStatus;
                _printerMngNo = printerMngNo;
                _salesSlipNum = salesSlipNum;
            }
            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="frePSalesSlipWork"></param>
            public RmSalesSlipListKey(FrePSalesSlipWork frePSalesSlipWork)
            {
                _acptAnOdrStatus = frePSalesSlipWork.SALESSLIPRF_ACPTANODRSTATUSRF;
                _printerMngNo = frePSalesSlipWork.HADD_PRINTERMNGNORF;
                _salesSlipNum = frePSalesSlipWork.SALESSLIPRF_SALESSLIPNUMRF;
            }
        }
        # endregion
        // --------------- ADD END 2013/06/17 zhubj FOR Redmine #36594--------<<<<

        # region [売上伝票リスト振分KEY]
        /// <summary>
        /// 売上伝票リスト振分KEY
        /// </summary>
        private struct SalesSlipListKey
        {
            /// <summary>受注ステータス</summary>
            private int _acptAnOdrStatus;
            /// <summary>プリンタ管理№</summary>
            private int _printerMngNo;
            /// <summary>
            /// 受注ステータス
            /// </summary>
            public int AcptAnOdrStatus
            {
                get { return _acptAnOdrStatus; }
                set { _acptAnOdrStatus = value; }
            }
            /// <summary>
            /// プリンタ管理№
            /// </summary>
            public int PrinterMngNo
            {
                get { return _printerMngNo; }
                set { _printerMngNo = value; }
            }
            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="acptAnOdrStatus">受注ステータス</param>
            /// <param name="printerMngNo">プリンタ管理№</param>
            public SalesSlipListKey( int acptAnOdrStatus, int printerMngNo )
            {
                _acptAnOdrStatus = acptAnOdrStatus;
                _printerMngNo = printerMngNo;
            }
            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="frePSalesSlipWork"></param>
            public SalesSlipListKey( FrePSalesSlipWork frePSalesSlipWork )
            {
                _acptAnOdrStatus = frePSalesSlipWork.SALESSLIPRF_ACPTANODRSTATUSRF;
                _printerMngNo = frePSalesSlipWork.HADD_PRINTERMNGNORF;
            }
        }
        # endregion

        # region [見積書リスト振分KEY]
        /// <summary>
        /// 見積書リスト振分KEY
        /// </summary>
        private struct EstFmListKey
        {
            /// <summary>プリンタ管理№</summary>
            private int _printerMngNo;
            /// <summary>
            /// プリンタ管理№
            /// </summary>
            public int PrinterMngNo
            {
                get { return _printerMngNo; }
                set { _printerMngNo = value; }
            }
            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="printerMngNo">プリンタ管理№</param>
            public EstFmListKey( int printerMngNo )
            {
                _printerMngNo = printerMngNo;
            }
            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="frePEstFmHead"></param>
            public EstFmListKey( FrePEstFmHead frePEstFmHead )
            {
                _printerMngNo = frePEstFmHead.HADD_PRINTERMNGNORF;
            }
        }
        # endregion

        # region [在庫移動伝票リスト振分KEY]
        /// <summary>
        /// 在庫移動伝票リスト振分KEY
        /// </summary>
        private struct StockMoveSlipListKey
        {
            /// <summary>移動形式</summary>
            private int _stockMoveFormal;
            /// <summary>プリンタ管理№</summary>
            private int _printerMngNo;
            /// <summary>
            /// 受注ステータス
            /// </summary>
            public int StockMoveFormal
            {
                get { return _stockMoveFormal; }
                set { _stockMoveFormal = value; }
            }
            /// <summary>
            /// プリンタ管理№
            /// </summary>
            public int PrinterMngNo
            {
                get { return _printerMngNo; }
                set { _printerMngNo = value; }
            }
            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="acptAnOdrStatus">移動形式</param>
            /// <param name="printerMngNo">プリンタ管理№</param>
            public StockMoveSlipListKey( int stockMoveFormal, int printerMngNo )
            {
                _stockMoveFormal = stockMoveFormal;
                _printerMngNo = printerMngNo;
            }
            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="frePSalesSlipWork"></param>
            public StockMoveSlipListKey( FrePStockMoveSlipWork frePStockMoveSlipWork )
            {
                _stockMoveFormal = frePStockMoveSlipWork.MOVH_STOCKMOVEFORMALRF;
                _printerMngNo = frePStockMoveSlipWork.HADD_PRINTERMNGNORF;
            }
        }
        # endregion
        # endregion

        # region [伝票印刷アクセスクラス・ステータスenum]
        /// <summary>
        /// 伝票印刷アクセスクラス・ステータス
        /// </summary>
        public enum SlipAcsStatus
        {
            /// <summary>正常</summary>
            Normal = 0,
            /// <summary>端末設定なしエラー</summary>
            Error_NoTerminalMg = 1,
            /// <summary>伝票情報抽出エラー</summary>
            Error_SearchSlip = 2,
        }
        # endregion
    }
}

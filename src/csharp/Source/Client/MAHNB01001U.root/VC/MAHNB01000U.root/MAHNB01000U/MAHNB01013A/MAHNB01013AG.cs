using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.IO;
using System.Windows.Forms;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 売上入力用初期値取得アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 売上入力の初期値取得データ制御を行います。</br>
    /// <br>Update Note : 2010/05/30 20056 對馬 大輔 </br>
    /// <br>              成果物統合(６次改良＋７次改良＋自由検索＋SCM)</br>
    /// <br>Update Note : 2010/06/26 李占川 </br>
    /// <br>              BLコード変換処理のロジックの削除</br>
    /// <br>Update Note : 2010/07/29 20056 對馬 大輔 </br>
    /// <br>              表示区分マスタが特定タイミングに取得できない件の対応(初期取得マスタ最終時にリストがnullの場合、再取得する)</br>
    /// <br>Update Note : 2011/09/27 20056 對馬 大輔</br>
    /// <br>              在庫数表示区分を参照し、現在庫数の表示制御を行う</br>
    /// <br>Update Note : 2012/02/07  2012/03/28配信分　#28284 liusy</br>
    /// <br>              起動時のマスタ取得処理内に得意先掛率グループの取得処理を追加する</br>
    /// <br>Update Note: 2012/11/13 宮本 利明</br>
    /// <br>管理番号   : 10801804-00 №1668</br>
    /// <br>             売上過去日付制御を個別オプション化（イスコまたはオプションありで日付制御）</br>
    /// <br>Update Note: 2012/12/21 宮本 利明</br>
    /// <br>管理番号   : 10801804-00</br>
    /// <br>             山形部品オプション対応</br>
    /// <br>Update Note: K2013/09/20 宮本 利明</br>
    /// <br>             ㈱フタバオプション対応（個別）</br>
    /// <br>Update Note: 2013/05/09 西 毅</br>
    /// <br>管理番号   : 10902175-00 仕掛一覧№935(#30784) </br>
    /// <br>             売上全体設定のＢＬコード枝番区分が「枝番あり」で設定する時、画面起動する後、ＢＬコード検索できない</br>
    /// <br>Update Note: K2014/01/22 譚洪</br>
    /// <br>管理番号   : 10970602-00</br>
    /// <br>             登戸個別特販区分の変更対応</br>
    /// <br>Update Note: K2014/02/17 鄧潘ハン</br>
    /// <br>管理番号   : 10970602-00</br>
    /// <br>             ＵＳＢ登戸個別オプションＯＮ ＡＮＤ 特販管理マスタの個別</br>
    /// <br>             アセンブリが動作環境に存在する場合 ⇒オプションＯＮの対応</br>
    /// <br>Update Note: K2015/04/01 高騁 </br>
    /// <br>管理番号   : 11100713-00</br>
    /// <br>           : 森川部品個別依頼の改良作業全拠点在庫情報一覧機能追加</br>
    /// <br>Update Note: K2015/04/29 黄興貴</br>
    /// <br>管理番号   : 11100543-00 富士ジーワイ商事㈱ UOE取込対応</br>
    /// <br>Update Note: K2015/06/18 紀飛</br>
    /// <br>管理番号   : 11101427-00 ㈱メイゴ　WebUOE発注回答取込対応</br>
    /// <br>Update Note: K2016/11/01 譚洪</br>
    /// <br>管理番号   : 11202099-00 売上伝票入力から外部PGを起動して売単価を算出の対応</br>
    /// <br>             ㈱コーエイオプション（個別）</br>
    /// <br>Update Note: K2016/12/14  時シン</br>
    /// <br>管理番号   : 11202330-00</br>
    /// <br>           : 山形部品様 伝票修正での仕入先、販売区分、売上日変更時に価格・売価を変更しない対応</br>
    /// <br>Update Note: K2016/12/26 譚洪</br>
    /// <br>管理番号   : 11270116-00 売上伝票入力パッケージ出荷用ソースのマージ</br>
    /// <br>             ㈱福田部品オプション（個別）</br>
    /// <br>Update Note: K2016/12/30 譚洪</br>
    /// <br>管理番号   : 11202452-00</br>
    /// <br>             水野商工様個別変更内容をPM.NSにて実現するため、第二売価の対応行います。</br>
    /// <br>Update Note: 2020/11/20 陳艶丹</br>
    /// <br>管理番号   : 11670305-00</br>
    /// <br>           : PMKOBETSU-4097 TSPインライン機能追加対応</br>
    /// <br>Update Note: 2022/01/05 陳艶丹</br>
    /// <br>管理番号   : 11800082-00</br>
    /// <br>           : PMKOBETSU-4148 メーカー名と仕入先名チェック追加</br> 
    /// </remarks>
    public class DelphiGetSalesSlipInputInitDataAcs
    {
        # region ■コンストラクタ
        /// <summary>
        /// デフォルトコンストラクタ（Singletonデザインパターンを採用している為、privateとする）
        /// </summary>
        private DelphiGetSalesSlipInputInitDataAcs()
        {
            this._salesSlipInputInitDataAcs = SalesSlipInputInitDataAcs.GetInstance();
            this._delphiSalesSlipInputInitDataAcs = DelphiSalesSlipInputInitDataAcs.GetInstance();
            this._delphiSalesSlipInputInitDataSecondAcs = DelphiSalesSlipInputInitDataSecondAcs.GetInstance();
            this._delphiSalesSlipInputInitDataThirdAcs = DelphiSalesSlipInputInitDataThirdAcs.GetInstance();
            this._delphiSalesSlipInputInitDataFourthAcs = DelphiSalesSlipInputInitDataFourthAcs.GetInstance();
            this._delphiSalesSlipInputInitDataFifthAcs = DelphiSalesSlipInputInitDataFifthAcs.GetInstance();
            this._delphiSalesSlipInputInitDataSixthAcs = DelphiSalesSlipInputInitDataSixthAcs.GetInstance();
            this._delphiSalesSlipInputInitDataSeventhAcs = DelphiSalesSlipInputInitDataSeventhAcs.GetInstance();
            this._delphiSalesSlipInputInitDataEighthAcs = DelphiSalesSlipInputInitDataEighthAcs.GetInstance();
            this._delphiSalesSlipInputInitDataNinthAcs = DelphiSalesSlipInputInitDataNinthAcs.GetInstance();
            this._delphiSalesSlipInputInitDataTenthAcs = DelphiSalesSlipInputInitDataTenthAcs.GetInstance();
        }

        /// <summary>
        /// 売上入力用初期値取得アクセスクラス インスタンス取得処理
        /// </summary>
        public static DelphiGetSalesSlipInputInitDataAcs GetInstance()
        {
            if (_delphiGetSalesSlipInputInitDataAcs == null)
            {
                _delphiGetSalesSlipInputInitDataAcs = new DelphiGetSalesSlipInputInitDataAcs();
            }
            return _delphiGetSalesSlipInputInitDataAcs;
        }
        # endregion

        #region ■プライベート変数
        private SalesSlipInputInitDataAcs _salesSlipInputInitDataAcs;
        private static DelphiGetSalesSlipInputInitDataAcs _delphiGetSalesSlipInputInitDataAcs;
        private DelphiSalesSlipInputInitDataAcs _delphiSalesSlipInputInitDataAcs;
        private DelphiSalesSlipInputInitDataSecondAcs _delphiSalesSlipInputInitDataSecondAcs;
        private DelphiSalesSlipInputInitDataThirdAcs _delphiSalesSlipInputInitDataThirdAcs;
        private DelphiSalesSlipInputInitDataFourthAcs _delphiSalesSlipInputInitDataFourthAcs;
        private DelphiSalesSlipInputInitDataFifthAcs _delphiSalesSlipInputInitDataFifthAcs;
        private DelphiSalesSlipInputInitDataSixthAcs _delphiSalesSlipInputInitDataSixthAcs;
        private DelphiSalesSlipInputInitDataSeventhAcs _delphiSalesSlipInputInitDataSeventhAcs;
        private DelphiSalesSlipInputInitDataEighthAcs _delphiSalesSlipInputInitDataEighthAcs;
        private DelphiSalesSlipInputInitDataNinthAcs _delphiSalesSlipInputInitDataNinthAcs;
        private DelphiSalesSlipInputInitDataTenthAcs _delphiSalesSlipInputInitDataTenthAcs;

        #endregion

        # region ■パブリックメソッド
        /// <summary>
        /// 売上入力で使用する初期データをＤＢより取得します。
        /// </summary>
        public void GetInitData()
        {
            //// 一番のスレート
            this._salesSlipInputInitDataAcs.SetMakerUMntList(_delphiSalesSlipInputInitDataAcs.GetMakerUMntList());
            this._salesSlipInputInitDataAcs.SetBlGoodsCdUMntList(_delphiSalesSlipInputInitDataAcs.GetBlGoodsCdUMntList());
            this._salesSlipInputInitDataAcs.SetGoodsAcs(_delphiSalesSlipInputInitDataAcs.GetGoodsAcs());
            this._salesSlipInputInitDataAcs.SetDisplayDivList(_delphiSalesSlipInputInitDataAcs.GetDisplayDivList()); // 2010/07/29
            this._salesSlipInputInitDataAcs.SetAllCustRateGroupList(_delphiSalesSlipInputInitDataAcs.GetCustRateGroupList()); //add by liusy 2012/02/07 #28284
            //2013/05/09 T.Nishi
            this._salesSlipInputInitDataAcs.SetTbsPartsCodeList(_delphiSalesSlipInputInitDataAcs.GetTbsPartsCodeList()); 
            //2013/05/09 T.Nishi
            // --- ADD 2022/01/05 陳艶丹 PMKOBETSU-4148 メーカー名と仕入先名チェック追加 --->>>>>
            //仕入先マスタ
            this._salesSlipInputInitDataAcs.SetSupplierList(_delphiSalesSlipInputInitDataSecondAcs.GetSupplierList());
            // --- ADD 2022/01/05 陳艶丹 PMKOBETSU-4148 メーカー名と仕入先名チェック追加 ---<<<<<
 
            //// 二番のスレート
            this._salesSlipInputInitDataAcs.SetUoeSetting(_delphiSalesSlipInputInitDataSecondAcs.GetUoeSetting());
            this._salesSlipInputInitDataAcs.SetTaxRateSet(_delphiSalesSlipInputInitDataSecondAcs.GetTaxRateSet(), _delphiSalesSlipInputInitDataEighthAcs.GetTaxRate());
            this._salesSlipInputInitDataAcs.SetPosTerminalMg(_delphiSalesSlipInputInitDataSecondAcs.GetPosTerminalMg());
            this._salesSlipInputInitDataAcs.SetEmployeeInfo(_delphiSalesSlipInputInitDataSecondAcs.GetEmployeeList(), _delphiSalesSlipInputInitDataSecondAcs.GetEmployeeDtlList());
            // --- UPD T.Miyamoto 2012/11/13 ---------->>>>>
            ////>>>2010/05/30
            ////this._salesSlipInputInitDataAcs.SetOptInfo(_delphiSalesSlipInputInitDataSecondAcs.GetOptCarMng(),
            ////    _delphiSalesSlipInputInitDataSecondAcs.GetOptFreeSearch(), _delphiSalesSlipInputInitDataSecondAcs.GetOptPCC(),
            ////    _delphiSalesSlipInputInitDataSecondAcs.GetOpt_RCLink(), _delphiSalesSlipInputInitDataSecondAcs.GetOptUOE(),
            ////    _delphiSalesSlipInputInitDataSecondAcs.GetOptStockingPayment());
            //this._salesSlipInputInitDataAcs.SetOptInfo(_delphiSalesSlipInputInitDataSecondAcs.GetOptCarMng(),
            //    _delphiSalesSlipInputInitDataSecondAcs.GetOptFreeSearch(), _delphiSalesSlipInputInitDataSecondAcs.GetOptPCC(),
            //    _delphiSalesSlipInputInitDataSecondAcs.GetOpt_RCLink(), _delphiSalesSlipInputInitDataSecondAcs.GetOptUOE(),
            //    _delphiSalesSlipInputInitDataSecondAcs.GetOptStockingPayment(),
            //    _delphiSalesSlipInputInitDataSecondAcs.GetOptSCM(),
            //    _delphiSalesSlipInputInitDataSecondAcs.GetOptQRMail());
            ////<<<2010/05/30
            this._salesSlipInputInitDataAcs.SetOptInfo(_delphiSalesSlipInputInitDataSecondAcs.GetOptCarMng(),
                _delphiSalesSlipInputInitDataSecondAcs.GetOptFreeSearch(), _delphiSalesSlipInputInitDataSecondAcs.GetOptPCC(),
                _delphiSalesSlipInputInitDataSecondAcs.GetOpt_RCLink(), _delphiSalesSlipInputInitDataSecondAcs.GetOptUOE(),
                _delphiSalesSlipInputInitDataSecondAcs.GetOptPermitForKoei(), // ADD 譚洪 K2016/11/01 外部PG売価算出対応_㈱コーエイ
                _delphiSalesSlipInputInitDataSecondAcs.GetOptFukudaCustom(), // ADD 譚洪 K2016/12/26 ㈱福田部品
                _delphiSalesSlipInputInitDataSecondAcs.GetOptStockingPayment(),
                _delphiSalesSlipInputInitDataSecondAcs.GetOptSCM(),
                _delphiSalesSlipInputInitDataSecondAcs.GetOptQRMail(),
                _delphiSalesSlipInputInitDataSecondAcs.GetOptDateCtrl(),
                _delphiSalesSlipInputInitDataSecondAcs.GetOptNoBuTo(),
                _delphiSalesSlipInputInitDataSecondAcs.GetOptForFuJi(),// ADD K2015/04/29 黄興貴 富士ジーワイ商事㈱
                _delphiSalesSlipInputInitDataSecondAcs.GetOptForMeiGo(),// ADD K2015/06/18 紀飛 ㈱メイゴ WebUOE発注回答取込
                _delphiSalesSlipInputInitDataSecondAcs.GetOptForMizuno2ndSellPriceCtl(),   // ADD K2016/12/30 譚洪 水野商工㈱
                // ---ADD 鄧潘ハン K2014/02/17--------------->>>>>
                _delphiSalesSlipInputInitDataSecondAcs.MyMethodNobuto,
                //　_delphiSalesSlipInputInitDataSecondAcs.ObjNobuto　// DEL K2015/04/01 高騁 森川部品個別依頼
                // ---ADD 鄧潘ハン K2014/02/17---------------<<<<<
                _delphiSalesSlipInputInitDataSecondAcs.GetOptYamagataCustom(),  //  ADD 時シン K2016/12/14 山形部品様 伝票修正での仕入先、販売区分、売上日変更時に価格・売価を変更しない対応
                // --- ADD K2015/04/01 高騁 森川部品個別依頼 ---------->>>>>
                _delphiSalesSlipInputInitDataSecondAcs.ObjNobuto,
                // ---UPD 陳艶丹 2020/11/20 PMKOBETSU-4097の対応 ------>>>>
                _delphiSalesSlipInputInitDataSecondAcs.GetOptMoriKawa(),
                // --- UPD 陳艶丹 2022/04/26 PMKOBETSU-4208 電子帳簿対応--->>>>>
                //_delphiSalesSlipInputInitDataSecondAcs.GetOptTSP()
                _delphiSalesSlipInputInitDataSecondAcs.GetOptTSP(),
                _delphiSalesSlipInputInitDataSecondAcs.GetOptEBooks()
                // --- UPD 陳艶丹 2022/04/26 PMKOBETSU-4208 電子帳簿対応---<<<<<
                // ---UPD 陳艶丹 2020/11/20 PMKOBETSU-4097の対応 ------<<<<
                // --- ADD K2015/04/01 高騁 森川部品個別依頼 ----------<<<<<
                ); // ADD 譚洪 K2014/01/22
            // --- UPD T.Miyamoto 2012/11/13 ---------->>>>>
            // --- ADD 2012/12/21 T.Miyamoto ------------------------------>>>>>
            this._salesSlipInputInitDataAcs.SetYamagataOptInfo(_delphiSalesSlipInputInitDataSecondAcs.GetOptStockEntCtrl()
                                                             , _delphiSalesSlipInputInitDataSecondAcs.GetOptStockDateCtrl()
                                                             , _delphiSalesSlipInputInitDataSecondAcs.GetOptSalesCostCtrl()
                                                              );
            // --- ADD 2012/12/21 T.Miyamoto ------------------------------<<<<<
            // --- ADD K2013/09/20 T.Miyamoto ------------------------------>>>>>
            this._salesSlipInputInitDataAcs.SetFutabaOptInfo(_delphiSalesSlipInputInitDataSecondAcs.GetOptFutabaSlipPrtCtl()
                                                            , _delphiSalesSlipInputInitDataSecondAcs.GetOptFutabaWarehAlloc()
                                                            , _delphiSalesSlipInputInitDataSecondAcs.GetOptFutabaUOECtl()
                                                            , _delphiSalesSlipInputInitDataSecondAcs.GetOptFutabaOutSlipCtl()
                                                            );

            this._salesSlipInputInitDataAcs.Opt_BLPRefWarehouse = _delphiSalesSlipInputInitDataThirdAcs.Opt_BLPRefWarehouse();
            // --- ADD K2013/09/20 T.Miyamoto ------------------------------<<<<<

            //>>>2010/05/30
            //this._salesSlipInputInitDataAcs.SetTbsPartsCdChgWorkList(_delphiSalesSlipInputInitDataSecondAcs.GetTbsPartsCdChgWorkList()); // 2010/06/26
            //<<<2010/05/30

            //// 三番のスレート
            this._salesSlipInputInitDataAcs.SetAcptAnOdrTtlSt(_delphiSalesSlipInputInitDataThirdAcs.GetAcptAnOdrTtlSt());
            this._salesSlipInputInitDataAcs.SetSalesTtlSt(_delphiSalesSlipInputInitDataThirdAcs.GetSalesTtlSt());
            this._salesSlipInputInitDataAcs.SetEstimateDefSet(_delphiSalesSlipInputInitDataThirdAcs.GetEstimateDefSet());
            this._salesSlipInputInitDataAcs.SetStockTtlSt(_delphiSalesSlipInputInitDataThirdAcs.GetStockTtlSt());
            this._salesSlipInputInitDataAcs.SetAllDefSet(_delphiSalesSlipInputInitDataThirdAcs.GetAllDefSet());
            this._salesSlipInputInitDataAcs.SetInputMode(_delphiSalesSlipInputInitDataThirdAcs.GetAllDefSet().GoodsNoInpDiv);
            this._salesSlipInputInitDataAcs.SetCompanyInf(_delphiSalesSlipInputInitDataThirdAcs.GetCompanyInf());
            this._salesSlipInputInitDataAcs.SetSlipPrtSetList(_delphiSalesSlipInputInitDataThirdAcs.GetSlipPrtSetList());
            this._salesSlipInputInitDataAcs.SetCustSlipMngList(_delphiSalesSlipInputInitDataThirdAcs.GetCustSlipMngList());
            this._salesSlipInputInitDataAcs.SetUoeGuideNameList(_delphiSalesSlipInputInitDataThirdAcs.GetUoeGuideNameList());
            this._salesSlipInputInitDataAcs.SetSubSectionList(_delphiSalesSlipInputInitDataThirdAcs.GetSubSectionList());
            this._salesSlipInputInitDataAcs.SetRateProtyMngList(_delphiSalesSlipInputInitDataThirdAcs.GetRateProtyMngList());
            this._salesSlipInputInitDataAcs.SetSalesProcMoneyList(_delphiSalesSlipInputInitDataThirdAcs.GetSalesProcMoneyList());
            this._salesSlipInputInitDataAcs.SetStockProcMoneyList(_delphiSalesSlipInputInitDataThirdAcs.GetStockProcMoneyList());
            this._salesSlipInputInitDataAcs.SetUserGdBdList(_delphiSalesSlipInputInitDataThirdAcs.GetUserGdBdList());
            this._salesSlipInputInitDataAcs.Opt_CarMng = _delphiSalesSlipInputInitDataThirdAcs.OptCarMng();
            this._salesSlipInputInitDataAcs.Opt_StockingPayment = _delphiSalesSlipInputInitDataThirdAcs.OptStockingPayment();
            //>>>2010/05/30
            this._salesSlipInputInitDataAcs.SetSCMTtlSt(_delphiSalesSlipInputInitDataThirdAcs.GetScmTtlSt());
            this._salesSlipInputInitDataAcs.SetSCMDeliDateStList(_delphiSalesSlipInputInitDataThirdAcs.GetScmDeliDateStList());
            //this._salesSlipInputInitDataAcs.SetTbsPartsCdChgWorkList(_delphiSalesSlipInputInitDataThirdAcs.GetTbsPartsCdChgWorkList()); // DEL 2010/06/26
            //<<<2010/05/30
            this._salesSlipInputInitDataAcs.SetStockMngTtlSt(_delphiSalesSlipInputInitDataThirdAcs.GetStockMngTtlSt()); // 2011/09/27
            
            
            //if (_delphiSalesSlipInputInitDataSecondAcs.GetTaxRateSet() == null)
            //{
            //    MessageBox.Show("ERR");
            //}
            //else
            //{
            //    MessageBox.Show(_delphiSalesSlipInputInitDataThirdAcs.GetUserGdBdList().Count.ToString());
            //}



            //this._salesSlipInputInitDataAcs.SetUserGuideAcs(_delphiSalesSlipInputInitDataThirdAcs.GetUserGuideAcs());
            //// 四番のスレート
            //this._salesSlipInputInitDataAcs.SetWarehouseList(_delphiSalesSlipInputInitDataFourthAcs.GetWarehouseList());
            //// 五番のスレート
            //// 六番のスレート
            //this._salesSlipInputInitDataAcs.SetDisplayDivList(_delphiSalesSlipInputInitDataSixthAcs.GetDisplayDivList());
            //this._salesSlipInputInitDataAcs.SetNoteGuidList(_delphiSalesSlipInputInitDataSixthAcs.GetNoteGuidList());
            //// 七番のスレート
            //this._salesSlipInputInitDataAcs.Opt_CarMng = _delphiSalesSlipInputInitDataSeventhAcs.GetOpt_CarMng();

            //this._salesSlipInputInitDataAcs.SetAllCustRateGroupList(_delphiSalesSlipInputInitDataAcs.GetAllCustRateGroupList());

            //// 八番のスレート

            //// 九番のスレート

            //// 十番のスレート

        }
        #endregion

    }
}

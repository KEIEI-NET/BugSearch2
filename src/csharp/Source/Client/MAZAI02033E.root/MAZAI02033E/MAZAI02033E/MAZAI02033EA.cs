//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 在庫移動確認表
// プログラム概要   : 在庫移動確認表の印刷を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2008/10/02  修正内容 : バグ修正、仕様変更対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 照田 貴志
// 修 正 日  2009/03/10  修正内容 : 不具合対応[12213]
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 修 正 日  2009/06/11  修正内容 : 移動データ拠点管理対応
//----------------------------------------------------------------------------//

using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   StockMoveListCndtn
    /// <summary>
    ///                      在庫・倉庫移動確認表抽出条件クラス
    /// </summary>
    /// <remarks>
    /// <br>note             :   在庫・倉庫移動確認表抽出条件クラスヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2007/09/11  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/10/02 照田 貴志　バグ修正、仕様変更対応</br>
    /// <br>                 :   2009/03/10 照田 貴志　不具合対応[12213]</br>
    /// <br>　           　　　　※発行タイプ「全て」を削除、「出庫」→「未入荷」、「入庫」→「入荷済」にそれぞれ変更</br>
    /// <br>Update Note      : 　2012/11/21 脇田 靖之　仕様変更対応</br>
    /// <br>　           　　　　※発行タイプ「出庫」追加</br>
    /// </remarks>
    public class StockMoveCndtn
    {
        #region ■ Private Member
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>主入出荷拠点コード</summary>
        private string[] _bfAfSectionCd = new string[0];

        /// <summary>主開始入出荷倉庫コード</summary>
        private string _st_MainBfAfEnterWarehCd = "";

        /// <summary>主終了入出荷倉庫コード</summary>
        private string _ed_MainBfAfEnterWarehCd = "";

        //--- DEL 2008/08/12 ---------->>>>>
        ///// <summary>処理区分</summary>
        ///// <remarks>0:未出荷,1:出荷済,2:未入荷,3:入荷済(倉庫移動の場合は1:出荷,3:入荷とする)</remarks>
        //private ShipmentArrivalDivState _shipmentArrivalDiv;
        //--- DEL 2008/08/12 ----------<<<<<

        /// <summary>在庫移動形式</summary>
        /// <remarks>0:在庫移動,1:倉庫移動</remarks>
        private StockMoveFormalDivState _stockMoveFormalDiv;

        /// <summary>開始伝票日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _st_ShipArrivalDate = DateTime.MinValue;

        /// <summary>終了伝票日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _ed_ShipArrivalDate = DateTime.MaxValue;

        /// <summary>開始入力日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _st_CreateDate = DateTime.MinValue;

        /// <summary>終了入力日付</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _ed_CreateDate = DateTime.MaxValue;

        /// <summary>開始入出荷拠点コード</summary>
        private string _st_ShipArrivalSectionCd = "";

        /// <summary>終了入出荷拠点コード</summary>
        private string _ed_ShipArrivalSectionCd = "";

        /// <summary>開始入出荷倉庫コード</summary>
        private string _st_ShipArrivalEnterWarehCd = "";

        /// <summary>終了入出荷倉庫コード</summary>
        private string _ed_ShipArrivalEnterWarehCd = "";

        //--- DEL 2008/08/12 ---------->>>>>
        ///// <summary>開始在庫移動伝票番号</summary>
        //private Int32 _st_StockMoveSlipNo;

        ///// <summary>終了在庫移動伝票番号</summary>
        //private Int32 _ed_StockMoveSlipNo;

        ///// <summary>開始商品メーカーコード</summary>
        //private Int32 _st_GoodsMakerCd;

        ///// <summary>終了商品メーカーコード</summary>
        //private Int32 _ed_GoodsMakerCd;

        ///// <summary>開始商品番号</summary>
        //private string _st_GoodsNo = "";

        ///// <summary>終了商品番号</summary>
        //private string _ed_GoodsNo = "";

        ///// <summary>開始更新拠点コード</summary>
        //private string _st_UpdateSecCd = "";

        ///// <summary>終了更新拠点コード</summary>
        //private string _ed_UpdateSecCd = "";
        //--- DEL 2008/08/12 ----------<<<<<

        /// <summary>開始在庫移動入力従業員コード</summary>
        private string _st_StockMvEmpCode = "";

        /// <summary>終了在庫移動入力従業員コード</summary>
        private string _ed_StockMvEmpCode = "";

        //--- DEL 2008/08/12 ---------->>>>>
        ///// <summary>開始出荷担当従業員コード</summary>
        //private string _st_ShipAgentCd = "";

        ///// <summary>終了出荷担当従業員コード</summary>
        //private string _ed_ShipAgentCd = "";

        ///// <summary>開始引取担当従業員コード</summary>
        //private string _st_ReceiveAgentCd = "";

        ///// <summary>終了引取担当従業員コード</summary>
        //private string _ed_ReceiveAgentCd = "";
        //--- DEL 2008/08/12 ----------<<<<<

        /// <summary>在庫区分</summary>
        /// <remarks>0:自社、1:受託</remarks>
        private Int32 _stockDiv = -1;

        /// <summary>開始仕入先コード</summary>
        private Int32 _st_CustomerCode = 0;

        /// <summary>終了仕入先コード</summary>
        private Int32 _ed_CustomerCode = 999999999;

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";

        //--- ADD 2008/08/12 ---------->>>>>
        /// <summary>発行タイプ</summary>
        //private PrintTypeDivState _printType = 0; // DEL 2009/06/11
        private Int32 _printType = 0; // ADD 2009/06/11
        /// <summary>出力指定</summary>
        private OutputDesignatDivState _outputDesignat = 0;
        /// <summary>金額指定</summary>
        private PriceDesignatDivState _priceDesignat = 0;
        /// <summary>帳票タイプ区分</summary>
        /// <remarks>設定コードと同じ</remarks>
        private int _printDiv;
        //--- ADD 2008/08/12 ----------<<<<<

        // ADD 2009/06/11 ------>>>
        /// <summary>在庫移動確定区分</summary>
        /// <remarks>1:入荷確定あり,2:入荷確定なし</remarks>
        private Int32 _stockMoveFixCode;
        // ADD 2009/06/11 ------<<<
        
        #endregion

        #region ■ Private Member (自動生成以外)
        private bool _isOptSection;
        //--- ADD 2008.08.12 ---------->>>>>
        /// <summary>改頁</summary>
        private NewPageDivState _newPage = 0;
        /// <summary>出力順</summary>
        private OutputOrderDivState _outputOrder = 0;
        //--- ADD 2008.08.12 ---------->>>>>
        #endregion

        #region ■ Public Const (自動生成分以外)
        /// <summary>共通 日付フォーマット</summary>
        //public const string ct_DateFomat = "YYYY/MM/DD";  // DEL 2008.08.12
        public const string ct_DateFomat = "YY/MM/DD";      // ADD 2008.08.12

        /// <summary>共通 全て コード</summary>
        public const int ct_All_Code = -1;
        /// <summary>共通 全て 名称</summary>
        public const string ct_All_Name = "全て";

        // 処理区分 ------------------------------------------------------------------
        /// <summary>処理区分 未出荷</summary>
        public const string ct_ShipmentArrivalDiv_UnShipment = "未出荷";
        /// <summary>処理区分 出荷済</summary>
        public const string ct_ShipmentArrivalDiv_Shipment = "出荷済";
        /// <summary>処理区分 未入荷</summary>
        public const string ct_ShipmentArrivalDiv_UnArrival = "未入荷";
        /// <summary>処理区分 入荷済</summary>
        public const string ct_ShipmentArrivalDiv_Arrival = "入荷済";

        // 帳票区分 -----------------------------------------------------------------
        /// <summary>帳票区分 在庫移動確認表</summary>
        public const string ct_StockMoveFormalDiv_StockMove = "在庫移動確認表";
        /// <summary>帳票区分 倉庫移動確認表</summary>
        public const string ct_StockMoveFormalDiv_WareHouseMove = "倉庫移動確認表";

        // 拠点タイトル -----------------------------------------------------------------
        /// <summary>拠点タイトル 製造番号</summary>
        public const string ct_SectionTitle_Before = "移動元";
        /// <summary>拠点タイトル 商品</summary>
        public const string ct_SectionTitle_After = "移動先";
        #endregion

        #region ■ Public Propaty
        /// public propaty name  :  EnterpriseCode
        /// <summary>企業コードプロパティ</summary>
        /// <value>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   企業コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// public propaty name  :  BfAfSectionCd
        /// <summary>主入出荷拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   主入出荷拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string[] BfAfSectionCd
        {
            get { return _bfAfSectionCd; }
            set { _bfAfSectionCd = value; }
        }

        /// public propaty name  :  St_MainBfAfEnterWarehCd
        /// <summary>主開始入出荷倉庫コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   主開始入出荷倉庫コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string St_MainBfAfEnterWarehCd
        {
            get { return _st_MainBfAfEnterWarehCd; }
            set { _st_MainBfAfEnterWarehCd = value; }
        }

        /// public propaty name  :  Ed_MainBfAfEnterWarehCd
        /// <summary>主終了入出荷倉庫コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   主終了入出荷倉庫コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Ed_MainBfAfEnterWarehCd
        {
            get { return _ed_MainBfAfEnterWarehCd; }
            set { _ed_MainBfAfEnterWarehCd = value; }
        }

        //--- DEL 2008/08/12 ---------->>>>>
        ///// public propaty name  :  ShipmentArrivalDiv
        ///// <summary>処理区分プロパティ</summary>
        ///// <value>0:未出荷,1:出荷済,2:未入荷,3:入荷済(倉庫移動の場合は1:出荷,3:入荷とする)</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   処理区分プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public ShipmentArrivalDivState ShipmentArrivalDiv
        //{
        //    get { return _shipmentArrivalDiv; }
        //    set { _shipmentArrivalDiv = value; }
        //}
        //--- DEL 2008/08/12 ----------<<<<<

        /// public propaty name  :  StockMoveFormalDiv
        /// <summary>在庫移動形式プロパティ</summary>
        /// <value>0:在庫移動,1:倉庫移動</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫移動形式プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public StockMoveFormalDivState StockMoveFormalDiv
        {
            get { return _stockMoveFormalDiv; }
            set { _stockMoveFormalDiv = value; }
        }

        /// public propaty name  :  St_ShipArrivalDate
        /// <summary>開始伝票日付プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始伝票日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime St_ShipArrivalDate
        {
            get { return _st_ShipArrivalDate; }
            set { _st_ShipArrivalDate = value; }
        }

        /// public propaty name  :  Ed_ShipArrivalDate
        /// <summary>終了伝票日付プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了伝票日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime Ed_ShipArrivalDate
        {
            get { return _ed_ShipArrivalDate; }
            set { _ed_ShipArrivalDate = value; }
        }

        /// public propaty name  :  St_CreateDate
        /// <summary>開始入力日付プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始入力日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime St_CreateDate
        {
            get { return _st_CreateDate; }
            set { _st_CreateDate = value; }
        }

        /// public propaty name  :  Ed_CreateDate
        /// <summary>終了入力日付プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了入力日付プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime Ed_CreateDate
        {
            get { return _ed_CreateDate; }
            set { _ed_CreateDate = value; }
        }

        /// public propaty name  :  St_ShipArrivalSectionCd
        /// <summary>開始入出荷拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始入出荷拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string St_ShipArrivalSectionCd
        {
            get { return _st_ShipArrivalSectionCd; }
            set { _st_ShipArrivalSectionCd = value; }
        }

        /// public propaty name  :  Ed_ShipArrivalSectionCd
        /// <summary>終了入出荷拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了入出荷拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Ed_ShipArrivalSectionCd
        {
            get { return _ed_ShipArrivalSectionCd; }
            set { _ed_ShipArrivalSectionCd = value; }
        }

        /// public propaty name  :  St_ShipArrivalEnterWarehCd
        /// <summary>開始入出荷倉庫コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始入出荷倉庫コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string St_ShipArrivalEnterWarehCd
        {
            get { return _st_ShipArrivalEnterWarehCd; }
            set { _st_ShipArrivalEnterWarehCd = value; }
        }

        /// public propaty name  :  Ed_ShipArrivalEnterWarehCd
        /// <summary>終了入出荷倉庫コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了入出荷倉庫コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Ed_ShipArrivalEnterWarehCd
        {
            get { return _ed_ShipArrivalEnterWarehCd; }
            set { _ed_ShipArrivalEnterWarehCd = value; }
        }

        //--- DEL 2008/08/12 ---------->>>>>
        ///// public propaty name  :  St_StockMoveSlipNo
        ///// <summary>開始在庫移動伝票番号プロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   開始在庫移動伝票番号プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public Int32 St_StockMoveSlipNo
        //{
        //    get { return _st_StockMoveSlipNo; }
        //    set { _st_StockMoveSlipNo = value; }
        //}

        ///// public propaty name  :  Ed_StockMoveSlipNo
        ///// <summary>終了在庫移動伝票番号プロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   終了在庫移動伝票番号プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public Int32 Ed_StockMoveSlipNo
        //{
        //    get { return _ed_StockMoveSlipNo; }
        //    set { _ed_StockMoveSlipNo = value; }
        //}

        ///// public propaty name  :  St_GoodsMakerCd
        ///// <summary>開始商品メーカーコードプロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   開始商品メーカーコードプロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public Int32 St_GoodsMakerCd
        //{
        //    get { return _st_GoodsMakerCd; }
        //    set { _st_GoodsMakerCd = value; }
        //}

        ///// public propaty name  :  Ed_GoodsMakerCd
        ///// <summary>終了商品メーカーコードプロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   終了商品メーカーコードプロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public Int32 Ed_GoodsMakerCd
        //{
        //    get { return _ed_GoodsMakerCd; }
        //    set { _ed_GoodsMakerCd = value; }
        //}

        ///// public propaty name  :  St_GoodsNo
        ///// <summary>開始商品番号プロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   開始商品番号プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public string St_GoodsNo
        //{
        //    get { return _st_GoodsNo; }
        //    set { _st_GoodsNo = value; }
        //}

        ///// public propaty name  :  Ed_GoodsNo
        ///// <summary>終了商品番号プロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   終了商品番号プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public string Ed_GoodsNo
        //{
        //    get { return _ed_GoodsNo; }
        //    set { _ed_GoodsNo = value; }
        //}

        ///// public propaty name  :  St_UpdateSecCd
        ///// <summary>開始更新拠点コードプロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   開始更新拠点コードプロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public string St_UpdateSecCd
        //{
        //    get { return _st_UpdateSecCd; }
        //    set { _st_UpdateSecCd = value; }
        //}

        ///// public propaty name  :  Ed_UpdateSecCd
        ///// <summary>終了更新拠点コードプロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   終了更新拠点コードプロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public string Ed_UpdateSecCd
        //{
        //    get { return _ed_UpdateSecCd; }
        //    set { _ed_UpdateSecCd = value; }
        //}
        //--- DEL 2008/08/12 ----------<<<<<

        /// public propaty name  :  St_StockMvEmpCode
        /// <summary>開始在庫移動入力従業員コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始在庫移動入力従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string St_StockMvEmpCode
        {
            get { return _st_StockMvEmpCode; }
            set { _st_StockMvEmpCode = value; }
        }

        /// public propaty name  :  Ed_StockMvEmpCode
        /// <summary>終了在庫移動入力従業員コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了在庫移動入力従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Ed_StockMvEmpCode
        {
            get { return _ed_StockMvEmpCode; }
            set { _ed_StockMvEmpCode = value; }
        }

        //--- DEL 2008/08/12 ---------->>>>>
        ///// public propaty name  :  St_ShipAgentCd
        ///// <summary>開始出荷担当従業員コードプロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   開始出荷担当従業員コードプロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public string St_ShipAgentCd
        //{
        //    get { return _st_ShipAgentCd; }
        //    set { _st_ShipAgentCd = value; }
        //}

        ///// public propaty name  :  Ed_ShipAgentCd
        ///// <summary>終了出荷担当従業員コードプロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   終了出荷担当従業員コードプロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public string Ed_ShipAgentCd
        //{
        //    get { return _ed_ShipAgentCd; }
        //    set { _ed_ShipAgentCd = value; }
        //}

        ///// public propaty name  :  St_ReceiveAgentCd
        ///// <summary>開始引取担当従業員コードプロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   開始引取担当従業員コードプロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public string St_ReceiveAgentCd
        //{
        //    get { return _st_ReceiveAgentCd; }
        //    set { _st_ReceiveAgentCd = value; }
        //}

        ///// public propaty name  :  Ed_ReceiveAgentCd
        ///// <summary>終了引取担当従業員コードプロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   終了引取担当従業員コードプロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public string Ed_ReceiveAgentCd
        //{
        //    get { return _ed_ReceiveAgentCd; }
        //    set { _ed_ReceiveAgentCd = value; }
        //}
        //--- DEL 2008/08/12 ----------<<<<<

        /// public propaty name  :  StockDiv
        /// <summary>在庫区分プロパティ</summary>
        /// <value>0:自社、1:受託</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockDiv
        {
            get { return _stockDiv; }
            set { _stockDiv = value; }
        }

        /// public propaty name  :  St_CustomerCode
        /// <summary>開始仕入先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   開始仕入先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 St_CustomerCode
        {
            get { return _st_CustomerCode; }
            set { _st_CustomerCode = value; }
        }

        /// public propaty name  :  Ed_CustomerCode
        /// <summary>終了仕入先コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   終了仕入先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 Ed_CustomerCode
        {
            get { return _ed_CustomerCode; }
            set { _ed_CustomerCode = value; }
        }

        /// public propaty name  :  EnterpriseName
        /// <summary>企業名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   企業名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EnterpriseName
        {
            get { return _enterpriseName; }
            set { _enterpriseName = value; }
        }

        //--- ADD 2008/08/12 ---------->>>>>
        /// public propaty name  :  PrintType
        /// <summary>発行タイププロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発行タイププロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        //public PrintTypeDivState PrintType
        public Int32 PrintType
        {
            get { return _printType; }
            set { _printType = value; }
        }
        /// public propaty name  :  OutputDesignat
        /// <summary>出力指定プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出力指定プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public OutputDesignatDivState OutputDesignat
        {
            get { return _outputDesignat; }
            set { _outputDesignat = value; }
        }
        /// public propaty name  :  PriceDesignat
        /// <summary>金額指定プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   金額指定プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public PriceDesignatDivState PriceDesignat
        {
            get { return _priceDesignat; }
            set { _priceDesignat = value; }
        }
        /// public propaty name  :  PriceDesignat
        /// <summary>改頁プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   改頁プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public NewPageDivState NewPage
        {
            get { return _newPage; }
            set { _newPage = value; }
        }
        /// public propaty name  :  PriceDesignat
        /// <summary>出力順プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出力順プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public OutputOrderDivState OutputOrder
        {
            get { return _outputOrder; }
            set { _outputOrder = value; }
        }
        /// public propaty name  :  PrintDiv
        /// <summary>帳票タイプ区分プロパティ</summary>
        /// <value>設定の用途コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   帳票タイプ区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public int PrintDiv
        {
            get { return _printDiv; }
            set { _printDiv = value; }
        }
        //--- ADD 2008/08/12 ----------<<<<<

        // ADD 2009/06/11 ------>>>
        /// public propaty name  :  StockMoveFixCode
        /// <summary>在庫移動確定区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   在庫移動確定区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 StockMoveFixCode
        {
            get { return _stockMoveFixCode; }
            set { _stockMoveFixCode = value; }
        }
        // ADD 2009/06/11 ------<<<
        
        #endregion

        #region ■ Public Propaty (自動生成分以外)
        /// public propaty name  :  ShipmentArrivalDivName
        /// <summary>拠点オプション区分</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点オプション区分プロパティ</br>
        /// <br>Programer        :   </br>
        /// </remarks>
        public bool IsOptSection
        {
            get { return this._isOptSection; }
            set { this._isOptSection = value; }
        }
        /// public propaty name  :  ShipmentArrivalDivName
        /// <summary>全拠点拠点選択区分</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   全拠点拠点選択区分プロパティ</br>
        /// <br>Programer        :   </br>
        /// </remarks>
        public bool IsSelectAllSection
        {
			get
			{
				bool isSelAlSec = false;
                if ( ( this._bfAfSectionCd.Length == 1 ) && ( this._bfAfSectionCd[0].CompareTo("0") == 0 ) )
				{
					isSelAlSec = true;
				}
				return isSelAlSec;
			}
		}

        //--- DEL 2008/08/12 ---------->>>>>
        ///// public propaty name  :  ShipmentArrivalDivName
        ///// <summary>処理区分名称</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   処理区分プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public string ShipmentArrivalDivName
        //{
        //    get
        //    {
        //        string shipmentArrivalDivName = "";

        //        switch ( this._shipmentArrivalDiv ) {
        //            case ShipmentArrivalDivState.UnShipment:
        //                shipmentArrivalDivName = ct_ShipmentArrivalDiv_UnShipment;
        //                break;
        //            case ShipmentArrivalDivState.Shipment:
        //                shipmentArrivalDivName = ct_ShipmentArrivalDiv_Shipment;
        //                break;
        //            case ShipmentArrivalDivState.UnArrival:
        //                shipmentArrivalDivName = ct_ShipmentArrivalDiv_UnArrival;
        //                break;
        //            case ShipmentArrivalDivState.Arrival:
        //                shipmentArrivalDivName = ct_ShipmentArrivalDiv_Arrival;
        //                break;
        //            default:
        //                break;
        //        }
        //        return shipmentArrivalDivName;
        //    }
        //}

        ///// public propaty name  :  StockMoveFormalDivName
        ///// <summary>在庫移動形式名称プロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   在庫移動形式名称プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public string StockMoveFormalDivName
        //{
        //    get
        //    {
        //        string stockMoveFormalDivName = "";
        //        switch ( this._stockMoveFormalDiv ) {
        //            case StockMoveFormalDivState.StockMove:
        //                stockMoveFormalDivName = ct_StockMoveFormalDiv_StockMove;
        //                break;
        //            case StockMoveFormalDivState.WareHouseMove:
        //                stockMoveFormalDivName = ct_StockMoveFormalDiv_WareHouseMove;
        //                break;
        //            default:
        //                break;
        //        }
        //        return stockMoveFormalDivName;
        //    }
        //}

        ///// public propaty name  :  MainSecTitle
        ///// <summary>主拠点タイトルプロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   主拠点タイトルプロパティ</br>
        ///// <br>Programer        :   22013 kubo</br>
        ///// </remarks>
        //public string MainExtractTitle
        //{
        //    get
        //    {
        //        string mainExtractTitle = "";
        //        switch ( this._shipmentArrivalDiv ) {
        //            case ShipmentArrivalDivState.UnShipment:
        //            case ShipmentArrivalDivState.Shipment:
        //                mainExtractTitle = ct_SectionTitle_Before;	// 移動元
        //                break;
        //            case ShipmentArrivalDivState.UnArrival:
        //            case ShipmentArrivalDivState.Arrival:
        //                mainExtractTitle = ct_SectionTitle_After;	// 移動先
        //                break;
        //        }
        //        return mainExtractTitle;
        //    }
        //}

        ///// public propaty name  :  ExtractSecTitle
        ///// <summary>抽出拠点タイトルプロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   抽出拠点タイトルプロパティ</br>
        ///// <br>Programer        :   22013 kubo</br>
        ///// </remarks>
        //public string ExtractTitle
        //{
        //    get
        //    {
        //        string extractTitle = "";
        //        switch ( this._shipmentArrivalDiv ) {
        //            case ShipmentArrivalDivState.UnShipment:
        //            case ShipmentArrivalDivState.Shipment:
        //                extractTitle = ct_SectionTitle_After;	// 移動先
        //                break;
        //            case ShipmentArrivalDivState.UnArrival:
        //            case ShipmentArrivalDivState.Arrival:
        //                extractTitle = ct_SectionTitle_Before;	// 移動元
        //                break;
        //        }
        //        return extractTitle;
        //    }
        //}

        ///// public propaty name  :  ExtractDateTitle
        ///// <summary>抽出日付タイトルプロパティ</summary>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   抽出日付タイトルプロパティ</br>
        ///// <br>Programer        :   22013 kubo</br>
        ///// </remarks>
        //public string ExtractDateTitle
        //{
        //    get
        //    {
        //        string extractDateTitle = "";
        //        switch ( this._shipmentArrivalDiv ) {
        //            case ShipmentArrivalDivState.UnShipment:
        //                extractDateTitle = "出荷予定日";
        //                break;
        //            case ShipmentArrivalDivState.Shipment:
        //            case ShipmentArrivalDivState.UnArrival:
        //                extractDateTitle = "出荷日";
        //                break;
        //            case ShipmentArrivalDivState.Arrival:
        //                extractDateTitle = "入荷日";
        //                break;
        //        }
        //        return extractDateTitle;
        //    }
        //}

        /// public propaty name  :  PrintTypeTitle
        /// <summary>発行タイプタイトルプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   発行タイプタイトルプロパティ</br>
        /// <br>Programer        :   30416 長沼 賢二</br>
        /// </remarks>
        public string PrintTypeTitle
        {
            get
            {
                string extractDateTitle = "";
                // DEL 2009/06/11 ------>>>
                //switch (this._printType)
                //{
                //    case PrintTypeDivState.PrintTypeBf:
                //        //extractDateTitle = "出庫";        //DEL 2009/03/10 不具合対応[12213]
                //        extractDateTitle = "未入荷";        //ADD 2009/03/10 不具合対応[12213]
                //        break;
                //    case PrintTypeDivState.PrintTypeAf:
                //        //extractDateTitle = "入庫";        //DEL 2009/03/10 不具合対応[12213]
                //        extractDateTitle = "入荷済";        //ADD 2009/03/10 不具合対応[12213]
                //        break;
                //    /* ---DEL 2009/03/10 不具合対応[12213] --------------->>>>>
                //    case PrintTypeDivState.PrintTypeAll:
                //        extractDateTitle = "全て";
                //        break;
                //       ---DEL 2009/03/10 不具合対応[12213] ---------------<<<<< */
                //}
                // DEL 2009/06/11 ------<<<

                // ADD 2009/06/11 ------>>>
                if (this._stockMoveFixCode == 1)
                {
                    // 在庫移動確定区分：入荷確定あり
                    switch (this._printType)
                    {
                        case 0:
                            extractDateTitle = "未入荷";
                            break;
                        case 1:
                            extractDateTitle = "入荷済";
                            break;
                        // --- ADD 2012/11/21 Y.Wakita ---------->>>>>
                        case 2:
                            extractDateTitle = "出庫";
                            break;
                        // --- ADD 2012/11/21 Y.Wakita ----------<<<<<
                    }
                }
                else if (this._stockMoveFixCode == 2)
                {
                    // 在庫移動確定区分：入荷確定なし
                    switch (this._printType)
                    {
                        case -1:
                            extractDateTitle = "全て";
                            break;
                        case 0:
                            extractDateTitle = "出庫";
                            break;
                        case 1:
                            extractDateTitle = "入庫";
                            break;
                    }
                }
                // ADD 2009/06/11 ------<<<
                
                return extractDateTitle;
            }
        }
        /// public propaty name  :  OutputDesignatTitle
        /// <summary>出力指定タイトルプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出力指定タイトルプロパティ</br>
        /// <br>Programer        :   30416 長沼 賢二</br>
        /// </remarks>
        public string OutputDesignatTitle
        {
            get
            {
                string extractDateTitle = "";
                switch (this._outputDesignat)
                {
                    case OutputDesignatDivState.Nonoutput:
                        extractDateTitle = "未出力分";
                        break;
                    case OutputDesignatDivState.OutputFin:
                        extractDateTitle = "出力済分";
                        break;
                    case OutputDesignatDivState.All:
                        extractDateTitle = "全て";
                        break;
                }
                return extractDateTitle;
            }
        }
        /// public propaty name  :  PriceDesignatTitle
        /// <summary>金額指定タイトルプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   金額指定タイトルプロパティ</br>
        /// <br>Programer        :   30416 長沼 賢二</br>
        /// </remarks>
        public string PriceDesignatTitle
        {
            get
            {
                string extractDateTitle = "";
                switch (this._priceDesignat)
                {
                    case PriceDesignatDivState.StockUnitPriceAndMovePrice:
                        extractDateTitle = "原価＆移動額";
                        break;
                    case PriceDesignatDivState.StockUnitPrice:
                        extractDateTitle = "原価";
                        break;
                    case PriceDesignatDivState.MovePrice:
                        extractDateTitle = "移動額";
                        break;
                    case PriceDesignatDivState.None:
                        extractDateTitle = "無し";
                        break;
                }
                return extractDateTitle;
            }
        }
        //--- ADD 2008/08/12 ----------<<<<<

        /// <summary>
        /// GrossPrintDivダミー
        /// </summary>
        public int GrossPrintDiv
        {
            get { return 0; }
        }

        #endregion

        #region ■ Public Enum
        #region ◆ 処理区分列挙体
        /// <summary> 処理区分列挙体 </summary>
        public enum ShipmentArrivalDivState
        {
            /// <summary> 未出荷 </summary>
            UnShipment = 0,
            /// <summary> 出荷済 </summary>
            Shipment = 1,
            /// <summary> 未入荷 </summary>
            UnArrival = 2,
            /// <summary> 入荷済</summary>
            Arrival = 3
        }
        #endregion

        //--- ADD 2008/08/12 ---------->>>>>
        // DEL 2009/06/11 ------>>>
        #region ◆ 発行タイプ列挙体
        ///// <summary> 発行タイプ列挙体 </summary>
        //public enum PrintTypeDivState
        //{
        //    /// <summary> 出庫 </summary>
        //    PrintTypeBf = 0,
        //    /// <summary> 入庫 </summary>
        //    PrintTypeAf = 1,
        //    /// <summary> 全て</summary>
        //    //PrintTypeAll = 2          //DEL 2008/10/02 パラメータシート内容との不一致
        //    PrintTypeAll = -1           //ADD 2008/10/02
        //}
        #endregion
        // DEL 2009/06/11 ------<<<
        
        #region ◆ 出力指定列挙体
        /// <summary> 出力指定列挙体 </summary>
        public enum OutputDesignatDivState
        {
            /// <summary> 未出力分 </summary>
            Nonoutput = 0,
            /// <summary> 出力済分 </summary>
            OutputFin = 1,
            /// <summary> 全て</summary>
            All = -1
        }
        #endregion

        #region ◆ 金額指定列挙体
        /// <summary> 金額指定列挙体 </summary>
        public enum PriceDesignatDivState
        {
            /// <summary> 未出力分 </summary>
            StockUnitPriceAndMovePrice = 0,
            /// <summary> 出力済分 </summary>
            StockUnitPrice = 1,
            /// <summary> 全て</summary>
            MovePrice = 2,
            /// <summary> 全て</summary>
            None = 3
        }
        #endregion

        #region ◆ 改頁列挙体
        /// <summary> 改頁列挙体 </summary>
        public enum NewPageDivState
        {
            /// <summary> 拠点 </summary>
            Section = 0,
            /// <summary> 倉庫 </summary>
            Warehouse = 1,
            /// <summary> しない</summary>
            None = 2,
        }
        #endregion

        #region ◆ 出力順列挙体
        /// <summary> 出力順列挙体 </summary>
        public enum OutputOrderDivState
        {
            /// <summary> 対象日順 </summary>
            ShipArrivalDate = 0,
            /// <summary> 入力日順 </summary>
            CreateDate = 1,
            /// <summary> 相手倉庫順</summary>
            Warehouse = 2,
        }
        #endregion
        //--- ADD 2008/08/12 ----------<<<<<

        #region ◆ 帳票区分列挙体
        /// <summary> 帳票区分列挙体 </summary>
        public enum StockMoveFormalDivState
        {
            /// <summary> 在庫移動確認表 </summary>
            StockMove = 1,
            /// <summary> 倉庫移動確認表 </summary>
            WareHouseMove = 2
        }
        #endregion
        #endregion ■ Public Enum

        #region ■ Constructor
        /// <summary>
        /// ワークコンストラクタ
        /// </summary>
        /// <returns>StockMoveCndtnクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   StockMoveCndtnクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public StockMoveCndtn ()
        {
        }
        #endregion ■ Constructor
    }
}

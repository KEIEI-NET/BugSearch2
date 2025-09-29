//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 抽出条件詳細画面
// プログラム概要   : 抽出条件詳細画面
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李亜博
// 作 成 日  2012/07/25  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 李亜博
// 作 成 日  2012/10/16  修正内容 : 拠点管理ログ参照ツール不具合の対応
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;
using System.Collections;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;

namespace Broadleaf.Windows.Forms
{
    ///<summary>
    /// 抽出条件詳細画面
    /// </summary>
    /// <remarks>
    /// <br>Note       : 抽出条件詳細画面</br>
    /// <br>Programmer : 李亜博</br>
    /// <br>Date       : 2012/07/25</br>
    /// <br>Update     : </br>
    /// <br>Update Note: 2012/10/16 李亜博</br>
    ///	<br>			 Redmine#31026 拠点管理ログ参照ツール不具合の対応</br>
    /// </remarks>
    public partial class PMKYO09501UB : Form
    {
        #region ■ Constructor ■
        /// <summary>
        /// 抽出条件詳細画面 コンストラクタ
        /// </summary>
        /// <param name="sndRcvHisTableWork">送受信履歴ログデータワーク</param>
        /// <param name="searchEtrResultList">送受信抽出条件履歴ログデータワークリスト</param>
        /// <remarks>
        /// <br>Note       : コンストラクタ</br>
        /// <br>Programmer : 李亜博</br>
        /// <br>Date       : 2012/07/25</br>
        /// </remarks>
        public PMKYO09501UB(SndRcvHisTableWork sndRcvHisTableWork, object searchEtrResultList)
        {
            InitializeComponent();

            // 変数初期化
            _detailsTable = new DataTable();
            _searchEtrResultList = searchEtrResultList;
            _sndRcvHisTableWork = sndRcvHisTableWork;
            this.Text = getTitleName();

            // ボタン変数初期化
            this._imageList16 = IconResourceManagement.ImageList16;
            this._closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)this.tToolsManager_MainMenu.Tools["ButtonTool_Close"];
            this._ｌoginTitleLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)this.tToolsManager_MainMenu.Tools["LabelTool_LoginTitle"];
        }
        #endregion ■ Constructor ■

        #region ■ Const Memebers ■
        private const String GET_DATA_TYPE = "抽出データ";
        private const String START_CONDITION1 = "開始条件１";
        private const String END_CONDITION1 = "終了条件１";

        private const String START_CONDITION2 = "開始条件２";
        private const String END_CONDITION2 = "終了条件２";

        private const String START_CONDITION3 = "開始条件３";
        private const String END_CONDITION3 = "終了条件３";

        private const String START_CONDITION4 = "開始条件４";
        private const String END_CONDITION4 = "終了条件４";

        private const String START_CONDITION5 = "開始条件５";
        private const String END_CONDITION5 = "終了条件５";

        private const String START_CONDITION6 = "開始条件６";
        private const String END_CONDITION6 = "終了条件６";

        private const String START_CONDITION7 = "開始条件７";
        private const String END_CONDITION7 = "終了条件７";

        private const String START_CONDITION8 = "開始条件８";
        private const String END_CONDITION8 = "終了条件８";

        private const String START_CONDITION9 = "開始条件９";
        private const String END_CONDITION9 = "終了条件９";

        private const String START_CONDITION10 = "開始条件１０";
        private const String END_CONDITION10 = "終了条件１０";

        private const String CustomerRF = "得意先マスタ";
        private const String GoodsURF = "商品マスタ";
        private const String StockRF = "在庫マスタ";
        private const String SupplierRF = "仕入先マスタ";
        private const String RateRF = "掛率マスタ";

        private const String SalesSlipRF = "売上データ";
        private const String SalesSlipRF1 = "売上明細データ";
        private const String SalesSlipRF2 = "受注マスタ";
        private const String SalesSlipRF3 = "受注マスタ（車両）";
        private const String SalesHistoryRF = "売上履歴データ";
        private const String SalesHistoryRF1 = "売上履歴明細データ";
        private const String DepsitMainRF = "入金データ";
        private const String DepsitMainRF1 = "入金明細データ";
        private const String StockSlipRF = "仕入データ";
        private const String StockSlipRF1 = "仕入明細データ";
        private const String StockSlipRF2 = "受注マスタ";
        private const String StockSlipHistRF = "仕入履歴データ";
        private const String StockSlipHistRF1 = "仕入履歴明細データ";
        private const String PaymentSlpRF = "支払伝票マスタ";
        private const String PaymentSlpRF1 = "支払明細データ";
        private const String StockAdjustRF = "在庫調整データ";
        private const String StockAdjustDtlRF = "在庫調整明細データ";
        private const String StockMoveRF = "在庫移動データ";
        private const String DepositAlwRF = "入金引当マスタ";
        private const String RcvDraftDataRF = "受取手形データ";
        private const String PayDraftDataRF = "支払手形データ";

        // --- DEL 李亜博 2012/10/16 for Redmine#31026---------->>>>>
        //private const String MasterSend = "抽出条件詳細(マスタ送信)";
        //private const String MasterReceive = "抽出条件詳細(マスタ受信)";
        //private const String DataSend = "抽出条件詳細(データ送信)";
        //private const String DataReceive = "抽出条件詳細(データ受信)";
        // --- DEL 李亜博 2012/10/16 for Redmine#31026----------<<<<<
        // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
        private const String MasterSendStart = "抽出条件詳細(マスタ送信（開始）)";
        private const String MasterSendEnd = "抽出条件詳細(マスタ送信（終了）)";
        private const String MasterSendUpd = "抽出条件詳細(マスタ送信（送受信履歴更新）)";
        private const String MasterReceiveStart = "抽出条件詳細(マスタ受信（開始）)";
        private const String MasterReceiveEnd = "抽出条件詳細(マスタ受信（終了）)";
        private const String MasterReceiveUpd = "抽出条件詳細(マスタ受信（送受信履歴更新）)";
        private const String DataSendStart = "抽出条件詳細(データ送信（開始）)";
        private const String DataSendEnd = "抽出条件詳細(データ送信（終了）)";
        private const String DataSendUpd = "抽出条件詳細(データ送信（送受信履歴更新）)";
        private const String DataReceiveStart = "抽出条件詳細(データ受信（開始）)";
        private const String DataReceiveEnd = "抽出条件詳細(データ受信（終了）)";
        private const String DataReceiveUpd = "抽出条件詳細(データ受信（送受信履歴更新）)";

        private const string MST_SECINFOSET = "拠点設定マスタ";
        private const string MST_SUBSECTION = "部門設定マスタ";
        private const string MST_WAREHOUSE = "倉庫設定マスタ";
        private const string MST_EMPLOYEE = "従業員設定マスタ";
        private const string MST_USERGDAREADIVU = "ユーザーガイドマスタ(販売エリア区分）";
        private const string MST_USERGDBUSDIVU = "ユーザーガイドマスタ（業務区分）";
        private const string MST_USERGDCATEU = "ユーザーガイドマスタ（業種）";
        private const string MST_USERGDBUSU = "ユーザーガイドマスタ（職種）";
        private const string MST_USERGDGOODSDIVU = "ユーザーガイドマスタ（商品区分）";
        private const string MST_USERGDCUSGROUPU = "ユーザーガイドマスタ（得意先掛率グループ）";
        private const string MST_USERGDBANKU = "ユーザーガイドマスタ（銀行）";
        private const string MST_USERGDPRIDIVU = "ユーザーガイドマスタ（価格区分）";
        private const string MST_USERGDDELIDIVU = "ユーザーガイドマスタ（納品区分）";
        private const string MST_USERGDGOODSBIGU = "ユーザーガイドマスタ（商品大分類）";
        private const string MST_USERGDBUYDIVU = "ユーザーガイドマスタ（販売区分）";
        private const string MST_USERGDSTOCKDIVOU = "ユーザーガイドマスタ（在庫管理区分１）";
        private const string MST_USERGDSTOCKDIVTU = "ユーザーガイドマスタ（在庫管理区分２）";
        private const string MST_USERGDRETURNREAU = "ユーザーガイドマスタ（返品理由）";
        private const string MST_RATEPROTYMNG = "掛率優先管理マスタ";
        private const string MST_RATE = "掛率マスタ";
        private const string MST_SALESTARGET = "売上目標設定マスタ";
        private const string MST_CUSTOME = "得意先マスタ";
        private const string MST_SUPPLIER = "仕入先マスタ";
        private const string MST_JOINPARTSU = "結合マスタ";
        private const string MST_GOODSSET = "セットマスタ";
        private const string MST_TBOSEARCHU = "ＴＢＯマスタ";
        private const string MST_MODELNAMEU = "車種マスタ";
        private const string MST_BLGOODSCDU = "ＢＬコードマスタ";
        private const string MST_MAKERU = "メーカーマスタ";
        private const string MST_GOODSMGROUPU = "商品中分類マスタ";
        private const string MST_BLGROUPU = "グループコードマスタ";
        private const string MST_BLCODEGUIDE = "BLコードガイドマスタ";
        private const string MST_GOODSU = "商品マスタ";
        private const string MST_STOCK = "在庫マスタ";
        private const string MST_PARTSSUBSTU = "代替マスタ";
        private const string MST_PARTSPOSCODEU = "部位マスタ";

        private const string MST_ID_SECINFOSET = "SecInfoSetRF";
        private const string MST_ID_SUBSECTION = "SubSectionRF";
        private const string MST_ID_WAREHOUSE = "WarehouseRF";
        private const string MST_ID_EMPLOYEE = "EmployeeRF";
        private const string MST_ID_EMPLOYEEDTL = "EmployeeDtlRF";
        private const string MST_ID_USERGDU = "UserGdBdURF";
        private const string MST_ID_RATEPROTYMNG = "RateProtyMngRF";
        private const string MST_ID_RATE = "RateRF";
        private const string MST_ID_CUSTSALESTARGET = "CustSalesTargetRF";
        private const string MST_ID_EMPSALESTARGET = "EmpSalesTargetRF";
        private const string MST_ID_GCDSALESTARGET = "GcdSalesTargetRF";
        private const string MST_ID_CUSTOMECHA = "CustomerChangeRF";
        private const string MST_ID_CUSTOME = "CustomerRF";
        private const string MST_ID_CUSTOMEGROUP = "CustRateGroupRF";
        private const string MST_ID_CUSTOMESLIPMNG = "CustSlipMngRF";
        private const string MST_ID_CUSTOMESLIPNO = "CustSlipNoSetRF";
        private const string MST_ID_SUPPLIER = "SupplierRF";
        private const string MST_ID_JOINPARTSU = "JoinPartsURF";
        private const string MST_ID_GOODSSET = "GoodsSetRF";
        private const string MST_ID_TBOSEARCHU = "TBOSearchURF";
        private const string MST_ID_MODELNAMEU = "ModelNameURF";
        private const string MST_ID_BLGOODSCDU = "BLGoodsCdURF";
        private const string MST_ID_MAKERU = "MakerURF";
        private const string MST_ID_GOODSMGROUPU = "GoodsMGroupURF";
        private const string MST_ID_BLGROUPU = "BLGroupURF";
        private const string MST_ID_BLCODEGUIDE = "BLCodeGuideRF";
        private const string MST_ID_GOODSUMNG = "GoodsMngRF";
        private const string MST_ID_GOODSUPRI = "GoodsPriceURF";
        private const string MST_ID_GOODSU = "GoodsURF";
        private const string MST_ID_GOODSUISO = "IsolIslandPrcRF";
        private const string MST_ID_STOCK = "StockRF";
        private const string MST_ID_PARTSSUBSTU = "PartsSubstURF";
        private const string MST_ID_PARTSPOSCODEU = "PartsPosCodeURF";
        // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
        
        #endregion ■ Const Memebers ■

        #region ■ Private Field ■
        /// <summary>
        /// 抽出条件詳細グッリド
        /// </summary>
        private DataTable _detailsTable;
        private object _searchEtrResultList;
        private SndRcvHisTableWork _sndRcvHisTableWork;
        private string _loginName;
        private ImageList _imageList16 = null;
        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;
        private Infragistics.Win.UltraWinToolbars.LabelTool _ｌoginTitleLabel;
        #endregion ■ Private Field ■


        #region ■ Event ■
        /// <summary>
        /// ツールバークリックイベント
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">ToolClickEventArgs</param>
        /// <remarks>
        /// <br>Note       : ツールバークリックイベント</br>
        /// <br>Programmer : 李亜博</br>
        /// <br>Date       : 2012/07/25</br>
        /// </remarks>
        private void tToolsManager_MainMenu_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                // 画面の終了
                case "ButtonTool_Close":
                    {
                        //画面閉じる。
                        this.Close();
                    }
                    break;
            }
        }

        /// <summary>
        /// 画面ロードイベント
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">EventArgs</param>
        /// <remarks>
        /// <br>Note       : 画面ロードイベント</br>
        /// <br>Programmer : 李亜博</br>
        /// <br>Date       : 2012/07/25</br>
        /// <br>Update Note: 2012/10/16 李亜博</br>
        ///	<br>			 Redmine#31026 拠点管理ログ参照ツール不具合の対応</br>
        /// </remarks>
        private void PMKYO09501UB_Load(object sender, EventArgs e)
        {
            //this.DataSetColumnConstruction(this._sndRcvHisTableWork.Kind);//DEL 2012/10/16 李亜博 for redmine#31026
            this.DataSetColumnConstruction(this._sndRcvHisTableWork.Kind,this._sndRcvHisTableWork.SndLogExtraCondDiv);//ADD 2012/10/16 李亜博 for redmine#31026
            this.ButtonInitialSetting();
            //this.SetColumnStyle(this._sndRcvHisTableWork.Kind);//DEL 2012/10/16 李亜博 for redmine#31026
            this.SetColumnStyle(this._sndRcvHisTableWork.Kind, this._sndRcvHisTableWork.SndLogExtraCondDiv);//ADD 2012/10/16 李亜博 for redmine#31026

            // 詳細情報を表示する
            this.DetailShow();
        }
        #endregion ■ Event ■

        #region ■ Private Method ■

        /// <summary>
        /// 画面フォーム名
        /// </summary>
        /// <returns>画面フォーム名</returns>
        /// <remarks>
        /// <br>Note       : 画面フォーム名</br>
        /// <br>Programmer : 李亜博</br>
        /// <br>Date       : 2012/07/25</br>
        /// <br>Update Note: 2012/10/16 李亜博</br>
        ///	<br>			 Redmine#31026 拠点管理ログ参照ツール不具合の対応</br>
        /// </remarks>
        private string getTitleName()
        {
            string titleName = "";
            // --- DEL 李亜博 2012/10/16 for Redmine#31026---------->>>>>
            //if (this._sndRcvHisTableWork.Kind == 0 && this._sndRcvHisTableWork.SendOrReceiveDivCd == 0)
            //{
            //    titleName = DataSend;
            //    this.Size = new System.Drawing.Size(320, 580);

            //}
            //else if (this._sndRcvHisTableWork.Kind == 0 && this._sndRcvHisTableWork.SendOrReceiveDivCd == 1)
            //{
            //    titleName = DataReceive;
            //    this.Size = new System.Drawing.Size(320, 580);
            //}
            //else if (this._sndRcvHisTableWork.Kind == 1 && this._sndRcvHisTableWork.SendOrReceiveDivCd == 0)
            //{
            //    titleName = MasterSend;
            //}
            //else if (this._sndRcvHisTableWork.Kind == 1 && this._sndRcvHisTableWork.SendOrReceiveDivCd == 1)
            //{
            //    titleName = MasterReceive;
            //}
            // --- DEL 李亜博 2012/10/16 for Redmine#31026----------<<<<<
            // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
            if (this._sndRcvHisTableWork.Kind == 0)
            {
                if (this._sndRcvHisTableWork.SendOrReceiveDivCd == 0)
                {
                    titleName = DataSendStart;
                }
                else if (this._sndRcvHisTableWork.SendOrReceiveDivCd == 1)
                {
                    titleName =DataSendEnd;
                }
                else if (this._sndRcvHisTableWork.SendOrReceiveDivCd == 2)
                {
                    titleName = DataSendUpd;
                }
                else if (this._sndRcvHisTableWork.SendOrReceiveDivCd == 3)
                {
                    titleName = DataReceiveStart;
                }
                else if (this._sndRcvHisTableWork.SendOrReceiveDivCd == 4)
                {
                    titleName = DataReceiveEnd;
                }
                else if (this._sndRcvHisTableWork.SendOrReceiveDivCd == 5)
                {
                    titleName = DataReceiveUpd;
                }

                this.Size = new System.Drawing.Size(340, 620);
            }
            else if (this._sndRcvHisTableWork.Kind == 1)
            {
                if (this._sndRcvHisTableWork.SendOrReceiveDivCd == 0)
                {
                    titleName = MasterSendStart;
                }
                else if (this._sndRcvHisTableWork.SendOrReceiveDivCd == 1)
                {
                    titleName = MasterSendEnd;
                }
                else if (this._sndRcvHisTableWork.SendOrReceiveDivCd == 2)
                {
                    titleName = MasterSendUpd;
                }
                else if (this._sndRcvHisTableWork.SendOrReceiveDivCd == 3)
                {
                    titleName = MasterReceiveStart;
                }
                else if (this._sndRcvHisTableWork.SendOrReceiveDivCd == 4)
                {
                    titleName = MasterReceiveEnd;
                }
                else if (this._sndRcvHisTableWork.SendOrReceiveDivCd == 5)
                {
                    titleName = MasterReceiveUpd;
                }
                //差分
                if (this._sndRcvHisTableWork.SndLogExtraCondDiv == 0)
                {
                    this.Size = new System.Drawing.Size(340, 620);
                }
            }
            // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
            return titleName;
        }
        /// <summary>
        /// データセット列情報構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : データセット列情報構築処理です</br>
        /// <br>Programmer : 李亜博</br>
        /// <br>Date       : 2012/07/25</br>
        /// <br>Update Note: 2012/10/16 李亜博</br>
        ///	<br>			 Redmine#31026 拠点管理ログ参照ツール不具合の対応</br>
        /// </remarks>
        //private void DataSetColumnConstruction(int kind)//DEL 2012/10/16 李亜博 for redmine#31026
        private void DataSetColumnConstruction(int kind, int sndLogExtraCondDiv)//ADD 2012/10/16 李亜博 for redmine#31026
        {
            //if (kind == 0)//DEL 2012/10/16 李亜博 for redmine#31026
            if (kind == 0 || (kind == 1 && sndLogExtraCondDiv == 0))//ADD 2012/10/16 李亜博 for redmine#31026
            {
                this._detailsTable.Columns.Add(GET_DATA_TYPE, typeof(string));

            }
            //else if (kind == 1)//DEL 2012/10/16 李亜博 for redmine#31026
            else if (kind == 1 && sndLogExtraCondDiv == 1)//ADD 2012/10/16 李亜博 for redmine#31026
            {
                this._detailsTable.Columns.Add(GET_DATA_TYPE, typeof(string));
                this._detailsTable.Columns.Add(START_CONDITION1, typeof(string));
                this._detailsTable.Columns.Add(END_CONDITION1, typeof(string));

                this._detailsTable.Columns.Add(START_CONDITION2, typeof(string));
                this._detailsTable.Columns.Add(END_CONDITION2, typeof(string));

                this._detailsTable.Columns.Add(START_CONDITION3, typeof(string));
                this._detailsTable.Columns.Add(END_CONDITION3, typeof(string));

                this._detailsTable.Columns.Add(START_CONDITION4, typeof(string));
                this._detailsTable.Columns.Add(END_CONDITION4, typeof(string));

                this._detailsTable.Columns.Add(START_CONDITION5, typeof(string));
                this._detailsTable.Columns.Add(END_CONDITION5, typeof(string));

                this._detailsTable.Columns.Add(START_CONDITION6, typeof(string));
                this._detailsTable.Columns.Add(END_CONDITION6, typeof(string));

                this._detailsTable.Columns.Add(START_CONDITION7, typeof(string));
                this._detailsTable.Columns.Add(END_CONDITION7, typeof(string));

                this._detailsTable.Columns.Add(START_CONDITION8, typeof(string));
                this._detailsTable.Columns.Add(END_CONDITION8, typeof(string));

                this._detailsTable.Columns.Add(START_CONDITION9, typeof(string));
                this._detailsTable.Columns.Add(END_CONDITION9, typeof(string));

                this._detailsTable.Columns.Add(START_CONDITION10, typeof(string));
                this._detailsTable.Columns.Add(END_CONDITION10, typeof(string));
            }
            this.uGrid_Details.DataSource = _detailsTable;
        }

        /// <summary>
        /// レコードの列のスタイルの設定
        /// </summary>
        /// <remarks>
        /// <br>Note       : レコードの列のスタイルの設定</br>
        /// <br>Programmer : 李亜博</br>
        /// <br>Date       : 2012/07/25</br>
        /// <br>Update Note: 2012/10/16 李亜博</br>
        ///	<br>			 Redmine#31026 拠点管理ログ参照ツール不具合の対応</br>
        /// </remarks>
        //private void SetColumnStyle(int kind)//DEL 2012/10/16 李亜博 for redmine#31026
        private void SetColumnStyle(int kind, int sndLogExtraCondDiv)//ADD 2012/10/16 李亜博 for redmine#31026
        {

            Infragistics.Win.UltraWinGrid.ColumnsCollection Columns = this.uGrid_Details.DisplayLayout.Bands[0].Columns;

            //if (kind == 0)//DEL 2012/10/16 李亜博 for redmine#31026
            if (kind == 0 || (kind == 1 && sndLogExtraCondDiv == 0))//ADD 2012/10/16 李亜博 for redmine#31026
            {
                // 表示幅設定
                //Columns[this._detailsTable.Columns[GET_DATA_TYPE].ColumnName].Width = 150;//DEL 2012/10/16 李亜博 for redmine#31026
                Columns[this._detailsTable.Columns[GET_DATA_TYPE].ColumnName].Width = 240;//ADD 2012/10/16 李亜博 for redmine#31026

                // 入力許可設定
                Columns[this._detailsTable.Columns[GET_DATA_TYPE].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            }
            //else if (kind == 1)//DEL 2012/10/16 李亜博 for redmine#31026
            else if (kind == 1 && sndLogExtraCondDiv == 1)//ADD 2012/10/16 李亜博 for redmine#31026
            {
                // 表示幅設定
                Columns[this._detailsTable.Columns[GET_DATA_TYPE].ColumnName].Width = 110;
                Columns[this._detailsTable.Columns[START_CONDITION1].ColumnName].Width = 100;
                Columns[this._detailsTable.Columns[END_CONDITION1].ColumnName].Width = 100;

                Columns[this._detailsTable.Columns[START_CONDITION2].ColumnName].Width = 100;
                Columns[this._detailsTable.Columns[END_CONDITION2].ColumnName].Width = 100;

                Columns[this._detailsTable.Columns[START_CONDITION3].ColumnName].Width = 100;
                Columns[this._detailsTable.Columns[END_CONDITION3].ColumnName].Width = 100;

                Columns[this._detailsTable.Columns[START_CONDITION4].ColumnName].Width = 100;
                Columns[this._detailsTable.Columns[END_CONDITION4].ColumnName].Width = 100;

                Columns[this._detailsTable.Columns[START_CONDITION5].ColumnName].Width = 100;
                Columns[this._detailsTable.Columns[END_CONDITION5].ColumnName].Width = 100;

                Columns[this._detailsTable.Columns[START_CONDITION6].ColumnName].Width = 100;
                Columns[this._detailsTable.Columns[END_CONDITION6].ColumnName].Width = 100;

                Columns[this._detailsTable.Columns[START_CONDITION7].ColumnName].Width = 100;
                Columns[this._detailsTable.Columns[END_CONDITION7].ColumnName].Width = 100;

                Columns[this._detailsTable.Columns[START_CONDITION8].ColumnName].Width = 100;
                Columns[this._detailsTable.Columns[END_CONDITION8].ColumnName].Width = 100;

                Columns[this._detailsTable.Columns[START_CONDITION9].ColumnName].Width = 100;
                Columns[this._detailsTable.Columns[END_CONDITION9].ColumnName].Width = 100;

                Columns[this._detailsTable.Columns[START_CONDITION10].ColumnName].Width = 100;
                Columns[this._detailsTable.Columns[END_CONDITION10].ColumnName].Width = 100;

                // 入力許可設定
                Columns[this._detailsTable.Columns[GET_DATA_TYPE].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                Columns[this._detailsTable.Columns[START_CONDITION1].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                Columns[this._detailsTable.Columns[END_CONDITION1].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

                Columns[this._detailsTable.Columns[START_CONDITION2].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                Columns[this._detailsTable.Columns[END_CONDITION2].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

                Columns[this._detailsTable.Columns[START_CONDITION3].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                Columns[this._detailsTable.Columns[END_CONDITION3].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

                Columns[this._detailsTable.Columns[START_CONDITION4].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                Columns[this._detailsTable.Columns[END_CONDITION4].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

                Columns[this._detailsTable.Columns[START_CONDITION5].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                Columns[this._detailsTable.Columns[END_CONDITION5].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

                Columns[this._detailsTable.Columns[START_CONDITION6].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                Columns[this._detailsTable.Columns[END_CONDITION6].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

                Columns[this._detailsTable.Columns[START_CONDITION7].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                Columns[this._detailsTable.Columns[END_CONDITION7].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

                Columns[this._detailsTable.Columns[START_CONDITION8].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                Columns[this._detailsTable.Columns[END_CONDITION8].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

                Columns[this._detailsTable.Columns[START_CONDITION9].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                Columns[this._detailsTable.Columns[END_CONDITION9].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;

                Columns[this._detailsTable.Columns[START_CONDITION10].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
                Columns[this._detailsTable.Columns[END_CONDITION10].ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            }

        }

        /// <summary>
        /// ボタン初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : ボタン初期設定処理です。</br>
        /// <br>Programmer : 李亜博</br>
        /// <br>Date       : 2012/07/25</br>
        /// </remarks>
        private void ButtonInitialSetting()
        {
            this._loginName = LoginInfoAcquisition.Employee.Name;
            this.tToolsManager_MainMenu.ImageListSmall = this._imageList16;
            this._closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            this._ｌoginTitleLabel.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;


            // ログイン担当者の設定
            Infragistics.Win.UltraWinToolbars.LabelTool loginNameLabel = (Infragistics.Win.UltraWinToolbars.LabelTool)tToolsManager_MainMenu.Tools["LabelTool_LoginName"];
            loginNameLabel.SharedProps.Caption = _loginName;
        }

        /// <summary>
        /// 詳細情報を表示する
        /// </summary>
        /// <remarks>
        /// <br>Note       : 詳細情報を表示する</br>
        /// <br>Programmer : 李亜博</br>
        /// <br>Date       : 2012/07/25</br>
        /// <br>Update Note: 2012/10/16 李亜博</br>
        ///	<br>			 Redmine#31026 拠点管理ログ参照ツール不具合の対応</br>
        /// </remarks>
        private void DetailShow()
        {
            //データ
            if (this._sndRcvHisTableWork.Kind == 0)
            {
                string[] fileId = this._sndRcvHisTableWork.SndRcvFileID.Split(',');
                DataRow row = null;

                foreach (string FileId in fileId)
                {
                    row = this._detailsTable.NewRow();

                    // --- DEL 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                    //if ("SalesSlipRF".Equals(FileId))
                    //{
                    //    // 売上データ、売上明細データ、受注マスタ、受注マスタ（車両）
                    //    row[this._detailsTable.Columns[GET_DATA_TYPE]] = SalesSlipRF;
                    //    this._detailsTable.Rows.Add(row);

                    //    row = this._detailsTable.NewRow();
                    //    row[this._detailsTable.Columns[GET_DATA_TYPE]] = SalesSlipRF1;
                    //    this._detailsTable.Rows.Add(row);

                    //    row = this._detailsTable.NewRow();
                    //    row[this._detailsTable.Columns[GET_DATA_TYPE]] = SalesSlipRF2;
                    //    this._detailsTable.Rows.Add(row);

                    //    row = this._detailsTable.NewRow();
                    //    row[this._detailsTable.Columns[GET_DATA_TYPE]] = SalesSlipRF3;
                    //    this._detailsTable.Rows.Add(row);
                    //}
                    //else if ("SalesHistoryRF".Equals(FileId))
                    //{
                    //    // 売上履歴データ、売上履歴明細データ
                    //    row[this._detailsTable.Columns[GET_DATA_TYPE]] = SalesHistoryRF;
                    //    this._detailsTable.Rows.Add(row);

                    //    row = this._detailsTable.NewRow();
                    //    row[this._detailsTable.Columns[GET_DATA_TYPE]] = SalesHistoryRF1;
                    //    this._detailsTable.Rows.Add(row);

                    //}
                    //else if ("DepsitMainRF".Equals(FileId))
                    //{
                    //    // 入金データ、入金明細データ
                    //    row[this._detailsTable.Columns[GET_DATA_TYPE]] = DepsitMainRF;
                    //    this._detailsTable.Rows.Add(row);

                    //    row = this._detailsTable.NewRow();
                    //    row[this._detailsTable.Columns[GET_DATA_TYPE]] = DepsitMainRF1;
                    //    this._detailsTable.Rows.Add(row);
                    //}
                    //else if ("StockSlipRF".Equals(FileId))
                    //{
                    //    // 仕入データ、仕入明細データ、受注マスタ
                    //    row[this._detailsTable.Columns[GET_DATA_TYPE]] = StockSlipRF;
                    //    this._detailsTable.Rows.Add(row);

                    //    row = this._detailsTable.NewRow();
                    //    row[this._detailsTable.Columns[GET_DATA_TYPE]] = StockSlipRF1;
                    //    this._detailsTable.Rows.Add(row);

                    //    row = this._detailsTable.NewRow();
                    //    row[this._detailsTable.Columns[GET_DATA_TYPE]] = StockSlipRF2;
                    //    this._detailsTable.Rows.Add(row);

                    //}
                    //else if ("StockSlipHistRF".Equals(FileId))
                    //{
                    //    // 仕入履歴データ、仕入履歴明細データ
                    //    row[this._detailsTable.Columns[GET_DATA_TYPE]] = StockSlipHistRF;
                    //    this._detailsTable.Rows.Add(row);

                    //    row = this._detailsTable.NewRow();
                    //    row[this._detailsTable.Columns[GET_DATA_TYPE]] = StockSlipHistRF1;
                    //    this._detailsTable.Rows.Add(row);

                    //}
                    //else if ("PaymentSlpRF".Equals(FileId))
                    //{
                    //    // 支払伝票マスタ、支払明細データ
                    //    row[this._detailsTable.Columns[GET_DATA_TYPE]] = PaymentSlpRF;
                    //    this._detailsTable.Rows.Add(row);

                    //    row = this._detailsTable.NewRow();
                    //    row[this._detailsTable.Columns[GET_DATA_TYPE]] = PaymentSlpRF1;
                    //    this._detailsTable.Rows.Add(row);

                    //}
                    // --- DEL 李亜博 2012/10/16 for Redmine#31026----------<<<<<
                    // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                    if ("SalesSlipRF".Equals(FileId))
                    {
                        // 売上データ
                        row[this._detailsTable.Columns[GET_DATA_TYPE]] = SalesSlipRF;
                        this._detailsTable.Rows.Add(row);
                    }else if("SalesDetailRF".Equals(FileId))
                    {
                        // 売上明細データ
                        row = this._detailsTable.NewRow();
                        row[this._detailsTable.Columns[GET_DATA_TYPE]] = SalesSlipRF1;
                        this._detailsTable.Rows.Add(row);
                    }
                    else if ("AcceptOdrRF".Equals(FileId))
                    {
                        // 受注マスタ
                        row = this._detailsTable.NewRow();
                        row[this._detailsTable.Columns[GET_DATA_TYPE]] = SalesSlipRF2;
                        this._detailsTable.Rows.Add(row);
                    }
                    else if ("AcceptOdrCarRF".Equals(FileId))
                    {
                        // 受注マスタ（車両）
                        row = this._detailsTable.NewRow();
                        row[this._detailsTable.Columns[GET_DATA_TYPE]] = SalesSlipRF3;
                        this._detailsTable.Rows.Add(row);
                    }
                    else if ("SalesHistoryRF".Equals(FileId))
                    {
                        // 売上履歴データ
                        row[this._detailsTable.Columns[GET_DATA_TYPE]] = SalesHistoryRF;
                        this._detailsTable.Rows.Add(row);
                    }
                    else if ("SalesHistDtlRF".Equals(FileId))
                    {
                        // 売上履歴明細データ
                        row = this._detailsTable.NewRow();
                        row[this._detailsTable.Columns[GET_DATA_TYPE]] = SalesHistoryRF1;
                        this._detailsTable.Rows.Add(row);

                    }
                    else if ("DepsitMainRF".Equals(FileId))
                    {
                        // 入金データ
                        row[this._detailsTable.Columns[GET_DATA_TYPE]] = DepsitMainRF;
                        this._detailsTable.Rows.Add(row);
                    }
                    else if ("DepsitDtlRF".Equals(FileId))
                    {
                        // 入金明細データ
                        row = this._detailsTable.NewRow();
                        row[this._detailsTable.Columns[GET_DATA_TYPE]] = DepsitMainRF1;
                        this._detailsTable.Rows.Add(row);
                    }
                    else if ("StockSlipRF".Equals(FileId))
                    {
                        // 仕入データ
                        row[this._detailsTable.Columns[GET_DATA_TYPE]] = StockSlipRF;
                        this._detailsTable.Rows.Add(row);
                    }
                    else if ("StockDetailRF".Equals(FileId))
                    {
                        // 仕入明細データ
                        row = this._detailsTable.NewRow();
                        row[this._detailsTable.Columns[GET_DATA_TYPE]] = StockSlipRF1;
                        this._detailsTable.Rows.Add(row);
                    }
                    else if ("StockSlipHistRF".Equals(FileId))
                    {
                        // 仕入履歴データ
                        row[this._detailsTable.Columns[GET_DATA_TYPE]] = StockSlipHistRF;
                        this._detailsTable.Rows.Add(row);
                    }
                    else if ("StockSlHistDtlRF".Equals(FileId))
                    {
                        // 仕入履歴明細データ
                        row = this._detailsTable.NewRow();
                        row[this._detailsTable.Columns[GET_DATA_TYPE]] = StockSlipHistRF1;
                        this._detailsTable.Rows.Add(row);
                    }
                    else if ("PaymentSlpRF".Equals(FileId))
                    {
                        // 支払伝票マスタ
                        row[this._detailsTable.Columns[GET_DATA_TYPE]] = PaymentSlpRF;
                        this._detailsTable.Rows.Add(row);
                    }
                    else if ("PaymentDtlRF".Equals(FileId))
                    {
                        // 支払明細データ
                        row = this._detailsTable.NewRow();
                        row[this._detailsTable.Columns[GET_DATA_TYPE]] = PaymentSlpRF1;
                        this._detailsTable.Rows.Add(row);
                    }
                    // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
                    else if ("StockAdjustRF".Equals(FileId))
                    {
                        // 在庫調整データ
                        row[this._detailsTable.Columns[GET_DATA_TYPE]] = StockAdjustRF;
                        this._detailsTable.Rows.Add(row);
                    }
                    else if ("StockAdjustDtlRF".Equals(FileId))
                    {
                        // 在庫調整明細データ
                        row[this._detailsTable.Columns[GET_DATA_TYPE]] = StockAdjustDtlRF;
                        this._detailsTable.Rows.Add(row);
                    }
                    else if ("StockMoveRF".Equals(FileId))
                    {
                        // 在庫移動データ
                        row[this._detailsTable.Columns[GET_DATA_TYPE]] = StockMoveRF;
                        this._detailsTable.Rows.Add(row);
                    }
                    else if ("DepositAlwRF".Equals(FileId))
                    {
                        // 入金引当マスタ
                        row[this._detailsTable.Columns[GET_DATA_TYPE]] = DepositAlwRF;
                        this._detailsTable.Rows.Add(row);
                    }
                    else if ("RcvDraftDataRF".Equals(FileId))
                    {
                        // 受取手形データ
                        row[this._detailsTable.Columns[GET_DATA_TYPE]] = RcvDraftDataRF;
                        this._detailsTable.Rows.Add(row);
                    }
                    else if ("PayDraftDataRF".Equals(FileId))
                    {
                        // 支払手形データ
                        row[this._detailsTable.Columns[GET_DATA_TYPE]] = PayDraftDataRF;
                        this._detailsTable.Rows.Add(row);
                    }
                }
            }
            //マスタ
            else if (this._sndRcvHisTableWork.Kind == 1)
            {
                // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                //条件
                if (this._sndRcvHisTableWork.SndLogExtraCondDiv == 1)
                {
                // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
                    ArrayList resultList = this._searchEtrResultList as ArrayList;
                    SndRcvEtrWork work = null;
                    DataRow row = null;

                    if (resultList != null)
                    {
                        int sndRcvHisConsNo = this._sndRcvHisTableWork.SndRcvHisConsNo;  // 送受信履歴ログ送信番号
                        string sectionCode = this._sndRcvHisTableWork.SectionCode;       //拠点コード
                        string enterpriseCode = this._sndRcvHisTableWork.EnterpriseCode; //企業コード

                        for (int i = 0; i < resultList.Count; i++)
                        {
                            if (resultList[i].GetType() == typeof(SndRcvEtrWork))
                            {
                                work = resultList[i] as SndRcvEtrWork;
                                if (work.SndRcvHisConsNo == sndRcvHisConsNo && work.EnterpriseCode.Trim().Equals(enterpriseCode.Trim()) && work.SectionCode.Trim().Equals(sectionCode.Trim()))
                                {
                                    row = this._detailsTable.NewRow();
                                    row[this._detailsTable.Columns[START_CONDITION1]] = work.StartCond1;
                                    row[this._detailsTable.Columns[END_CONDITION1]] = work.EndCond1;
                                    row[this._detailsTable.Columns[START_CONDITION2]] = work.StartCond2;
                                    row[this._detailsTable.Columns[END_CONDITION2]] = work.EndCond2;
                                    row[this._detailsTable.Columns[START_CONDITION3]] = work.StartCond3;
                                    row[this._detailsTable.Columns[END_CONDITION3]] = work.EndCond3;
                                    row[this._detailsTable.Columns[START_CONDITION4]] = work.StartCond4;
                                    row[this._detailsTable.Columns[END_CONDITION4]] = work.EndCond4;
                                    row[this._detailsTable.Columns[START_CONDITION5]] = work.StartCond5;
                                    row[this._detailsTable.Columns[END_CONDITION5]] = work.EndCond5;
                                    row[this._detailsTable.Columns[START_CONDITION6]] = work.StartCond6;
                                    row[this._detailsTable.Columns[END_CONDITION6]] = work.EndCond6;
                                    row[this._detailsTable.Columns[START_CONDITION7]] = work.StartCond7;
                                    row[this._detailsTable.Columns[END_CONDITION7]] = work.EndCond7;
                                    row[this._detailsTable.Columns[START_CONDITION8]] = work.StartCond8;
                                    row[this._detailsTable.Columns[END_CONDITION8]] = work.EndCond8;
                                    row[this._detailsTable.Columns[START_CONDITION9]] = work.StartCond9;
                                    row[this._detailsTable.Columns[END_CONDITION9]] = work.EndCond9;
                                    row[this._detailsTable.Columns[START_CONDITION10]] = work.StartCond10;
                                    row[this._detailsTable.Columns[END_CONDITION10]] = work.EndCond10;

                                    if ("CustomerRF".Equals(work.FileId))
                                    {
                                        row[this._detailsTable.Columns[GET_DATA_TYPE]] = CustomerRF;
                                    }
                                    else if ("GoodsURF".Equals(work.FileId))
                                    {
                                        row[this._detailsTable.Columns[GET_DATA_TYPE]] = GoodsURF;
                                    }
                                    else if ("StockRF".Equals(work.FileId))
                                    {
                                        row[this._detailsTable.Columns[GET_DATA_TYPE]] = StockRF;
                                    }
                                    else if ("SupplierRF".Equals(work.FileId))
                                    {
                                        row[this._detailsTable.Columns[GET_DATA_TYPE]] = SupplierRF;
                                    }
                                    else if ("RateRF".Equals(work.FileId))
                                    {
                                        row[this._detailsTable.Columns[GET_DATA_TYPE]] = RateRF;
                                    }
                                    this._detailsTable.Rows.Add(row);
                                }
                            }
                        }
                    }
                    // --- ADD 李亜博 2012/10/16 for Redmine#31026---------->>>>>
                }
                else if (this._sndRcvHisTableWork.SndLogExtraCondDiv == 0)
                {
                    string[] fileId = this._sndRcvHisTableWork.SndRcvFileID.Split(',');
                    DataRow row = null;
                    string tempUserGuideDivCd = null;
                    foreach (string FileId in fileId)
                    {
                        row = this._detailsTable.NewRow();

                        if (FileId.Length >= 11 && MST_ID_USERGDU.Equals(FileId.Substring(0, 11)))
                        {
                            tempUserGuideDivCd = FileId.Substring(11);

                            // ユーザーガイドマスタ(販売エリア区分）
                            if (tempUserGuideDivCd.Equals("21"))
                            {
                                row[this._detailsTable.Columns[GET_DATA_TYPE]] = MST_USERGDAREADIVU;
                                this._detailsTable.Rows.Add(row);
                            }
                            // ユーザーガイドマスタ（業務区分）
                            else if (tempUserGuideDivCd.Equals("31"))
                            {
                                row[this._detailsTable.Columns[GET_DATA_TYPE]] = MST_USERGDBUSDIVU;
                                this._detailsTable.Rows.Add(row);
                            }
                            // ユーザーガイドマスタ（業種）
                            else if (tempUserGuideDivCd.Equals("33"))
                            {
                                row[this._detailsTable.Columns[GET_DATA_TYPE]] = MST_USERGDCATEU;
                                this._detailsTable.Rows.Add(row);
                            }
                            // ユーザーガイドマスタ（職種）
                            else if (tempUserGuideDivCd.Equals("34"))
                            {
                                row[this._detailsTable.Columns[GET_DATA_TYPE]] = MST_USERGDBUSU;
                                this._detailsTable.Rows.Add(row);
                            }
                            // ユーザーガイドマスタ（商品区分）
                            else if (tempUserGuideDivCd.Equals("41"))
                            {
                                row[this._detailsTable.Columns[GET_DATA_TYPE]] = MST_USERGDGOODSDIVU;
                                this._detailsTable.Rows.Add(row);
                            }
                            // ユーザーガイドマスタ（得意先掛率グループ）
                            else if (tempUserGuideDivCd.Equals("43"))
                            {
                                row[this._detailsTable.Columns[GET_DATA_TYPE]] = MST_USERGDCUSGROUPU;
                                this._detailsTable.Rows.Add(row);
                            }
                            // ユーザーガイドマスタ（銀行）
                            else if (tempUserGuideDivCd.Equals("46"))
                            {
                                row[this._detailsTable.Columns[GET_DATA_TYPE]] = MST_USERGDBANKU;
                                this._detailsTable.Rows.Add(row);
                            }
                            // ユーザーガイドマスタ（価格区分）
                            else if (tempUserGuideDivCd.Equals("47"))
                            {
                                row[this._detailsTable.Columns[GET_DATA_TYPE]] = MST_USERGDPRIDIVU;
                                this._detailsTable.Rows.Add(row);
                            }
                            // ユーザーガイドマスタ（納品区分）
                            else if (tempUserGuideDivCd.Equals("48"))
                            {
                                row[this._detailsTable.Columns[GET_DATA_TYPE]] = MST_USERGDDELIDIVU;
                                this._detailsTable.Rows.Add(row);
                            }
                            // ユーザーガイドマスタ（商品大分類）
                            else if (tempUserGuideDivCd.Equals("70"))
                            {
                                row[this._detailsTable.Columns[GET_DATA_TYPE]] = MST_USERGDGOODSBIGU;
                                this._detailsTable.Rows.Add(row);
                            }
                            // ユーザーガイドマスタ（販売区分）
                            else if (tempUserGuideDivCd.Equals("71"))
                            {
                                row[this._detailsTable.Columns[GET_DATA_TYPE]] = MST_USERGDBUYDIVU;
                                this._detailsTable.Rows.Add(row);
                            }
                            // ユーザーガイドマスタ（在庫管理区分１）
                            else if (tempUserGuideDivCd.Equals("72"))
                            {
                                row[this._detailsTable.Columns[GET_DATA_TYPE]] = MST_USERGDSTOCKDIVOU;
                                this._detailsTable.Rows.Add(row);
                            }
                            // ユーザーガイドマスタ（在庫管理区分２）
                            else if (tempUserGuideDivCd.Equals("73"))
                            {
                                row[this._detailsTable.Columns[GET_DATA_TYPE]] = MST_USERGDSTOCKDIVTU;
                                this._detailsTable.Rows.Add(row);
                            }
                            // ユーザーガイドマスタ（返品理由）
                            else if (tempUserGuideDivCd.Equals("91"))
                            {
                                row[this._detailsTable.Columns[GET_DATA_TYPE]] = MST_USERGDRETURNREAU;
                                this._detailsTable.Rows.Add(row);
                            }
                        }
                        else if (MST_ID_SECINFOSET.Equals(FileId))
                        {
                            // 拠点設定マスタ
                            row[this._detailsTable.Columns[GET_DATA_TYPE]] = MST_SECINFOSET;
                            this._detailsTable.Rows.Add(row);
                        }
                        else if (MST_ID_SUBSECTION.Equals(FileId))
                        {
                            //部門設定マスタ
                            row[this._detailsTable.Columns[GET_DATA_TYPE]] = MST_SUBSECTION;
                            this._detailsTable.Rows.Add(row);
                        }
                        else if (MST_ID_WAREHOUSE.Equals(FileId))
                        {
                            //倉庫設定マスタ
                            row[this._detailsTable.Columns[GET_DATA_TYPE]] = MST_WAREHOUSE;
                            this._detailsTable.Rows.Add(row);
                        }
                        else if (MST_ID_EMPLOYEE.Equals(FileId)||MST_ID_EMPLOYEEDTL.Equals(FileId))
                        {
                            //従業員マスタ、従業員詳細マスタ
                            row[this._detailsTable.Columns[GET_DATA_TYPE]] = MST_EMPLOYEE;
                            this._detailsTable.Rows.Add(row);
                        }
                        else if (MST_ID_CUSTOME.Equals(FileId) || MST_ID_CUSTOMECHA.Equals(FileId) || MST_ID_CUSTOMESLIPMNG.Equals(FileId) || MST_ID_CUSTOMEGROUP.Equals(FileId) || MST_ID_CUSTOMESLIPNO.Equals(FileId))
                        {
                            //得意先マスタ、得意先マスタ(変動情報)、得意先マスタ（伝票管理）、得意先マスタ（掛率グループ）、得意先マスタ(伝票番号)
                            row[this._detailsTable.Columns[GET_DATA_TYPE]] = MST_CUSTOME;
                            this._detailsTable.Rows.Add(row);
                        }
                        else if (MST_ID_SUPPLIER.Equals(FileId))
                        {
                            //仕入先マスタ
                            row[this._detailsTable.Columns[GET_DATA_TYPE]] = MST_SUPPLIER;
                            this._detailsTable.Rows.Add(row);
                        }
                        else if (MST_ID_MAKERU.Equals(FileId))
                        {
                            //メーカーマスタ（ユーザー登録分）
                            row[this._detailsTable.Columns[GET_DATA_TYPE]] = MST_MAKERU;
                            this._detailsTable.Rows.Add(row);
                        }
                        else if (MST_ID_BLGOODSCDU.Equals(FileId))
                        {
                            //BL商品コードマスタ（ユーザー登録分）
                            row[this._detailsTable.Columns[GET_DATA_TYPE]] = MST_BLGOODSCDU;
                            this._detailsTable.Rows.Add(row);
                        }
                        else if (MST_ID_GOODSU.Equals(FileId) || MST_ID_GOODSUPRI.Equals(FileId) || MST_ID_GOODSUMNG.Equals(FileId) || MST_ID_GOODSUISO.Equals(FileId))
                        {
                            //商品マスタ（ユーザー登録分）、価格マスタ（ユーザー登録）、商品管理情報マスタ、離島価格マスタ
                            row[this._detailsTable.Columns[GET_DATA_TYPE]] = MST_GOODSU;
                            this._detailsTable.Rows.Add(row);
                        }
                        else if (MST_ID_STOCK.Equals(FileId))
                        {
                            //在庫マスタ
                            row[this._detailsTable.Columns[GET_DATA_TYPE]] = MST_STOCK;
                            this._detailsTable.Rows.Add(row);
                        }
                        else if (MST_ID_RATEPROTYMNG.Equals(FileId))
                        {
                            //掛率優先管理マスタ
                            row[this._detailsTable.Columns[GET_DATA_TYPE]] = MST_RATEPROTYMNG;
                            this._detailsTable.Rows.Add(row);
                        }
                        else if (MST_ID_RATE.Equals(FileId))
                        {
                            //掛率マスタ
                            row[this._detailsTable.Columns[GET_DATA_TYPE]] = MST_RATE;
                            this._detailsTable.Rows.Add(row);
                        }
                        else if (MST_ID_GOODSSET.Equals(FileId))
                        {
                            //商品セットマスタ
                            row[this._detailsTable.Columns[GET_DATA_TYPE]] = MST_GOODSSET;
                            this._detailsTable.Rows.Add(row);
                        }
                        else if (MST_ID_PARTSSUBSTU.Equals(FileId))
                        {
                            //部品代替マスタ（ユーザー登録分）
                            row[this._detailsTable.Columns[GET_DATA_TYPE]] = MST_PARTSSUBSTU;
                            this._detailsTable.Rows.Add(row);
                        }
                        else if (MST_ID_EMPSALESTARGET.Equals(FileId))
                        {
                            //従業員別売上目標設定マスタ
                            row[this._detailsTable.Columns[GET_DATA_TYPE]] = MST_SALESTARGET;
                            this._detailsTable.Rows.Add(row);
                        }
                        else if (MST_ID_CUSTSALESTARGET.Equals(FileId) || MST_ID_GCDSALESTARGET.Equals(FileId))
                        {
                            //得意先別売上目標設定マスタ、商品別売上目標設定マスタ
                            row[this._detailsTable.Columns[GET_DATA_TYPE]] = MST_SALESTARGET;
                            this._detailsTable.Rows.Add(row);
                        }
                        else if (MST_ID_GOODSMGROUPU.Equals(FileId))
                        {
                            //商品中分類マスタ（ユーザー登録分）
                            row[this._detailsTable.Columns[GET_DATA_TYPE]] = MST_GOODSMGROUPU;
                            this._detailsTable.Rows.Add(row);
                        }
                        else if (MST_ID_BLGROUPU.Equals(FileId))
                        {
                            //BLグループマスタ（ユーザー登録分）
                            row[this._detailsTable.Columns[GET_DATA_TYPE]] = MST_BLGROUPU;
                            this._detailsTable.Rows.Add(row);
                        }
                        else if (MST_ID_JOINPARTSU.Equals(FileId))
                        {
                            //結合マスタ（ユーザー登録分）
                            row[this._detailsTable.Columns[GET_DATA_TYPE]] = MST_JOINPARTSU;
                            this._detailsTable.Rows.Add(row);
                        }
                        else if (MST_ID_TBOSEARCHU.Equals(FileId))
                        {
                            //TBO検索マスタ（ユーザー登録）
                            row[this._detailsTable.Columns[GET_DATA_TYPE]] = MST_TBOSEARCHU;
                            this._detailsTable.Rows.Add(row);
                        }
                        else if (MST_ID_PARTSPOSCODEU.Equals(FileId))
                        {
                            //部位コードマスタ（ユーザー登録）
                            row[this._detailsTable.Columns[GET_DATA_TYPE]] = MST_PARTSPOSCODEU;
                            this._detailsTable.Rows.Add(row);
                        }
                        else if (MST_ID_BLCODEGUIDE.Equals(FileId))
                        {
                            //BLコードガイドマスタ
                            row[this._detailsTable.Columns[GET_DATA_TYPE]] = MST_BLCODEGUIDE;
                            this._detailsTable.Rows.Add(row);
                        }
                        else if (MST_ID_MODELNAMEU.Equals(FileId))
                        {
                            //車種名称マスタ
                            row[this._detailsTable.Columns[GET_DATA_TYPE]] = MST_MODELNAMEU;
                            this._detailsTable.Rows.Add(row);
                        }
                    }
                }
                   // --- ADD 李亜博 2012/10/16 for Redmine#31026----------<<<<<
            }
        }
        #endregion ■ Private Method ■
    }
}
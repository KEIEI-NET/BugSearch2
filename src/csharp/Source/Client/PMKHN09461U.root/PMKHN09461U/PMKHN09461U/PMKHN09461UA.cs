//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 単品売価設定一括登録・修正
// プログラム概要   : 掛率マスタの単品設定分を対象に、複数件一括で登録・修正、一括削除、引用登録を行う。
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 作 成 日  2010/08/04  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 曹文傑
// 修 正 日  2010/09/06  修正内容 : #14238対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 修 正 日  2010/09/26  修正内容 : Redmine#14182の速度ＵＰ対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 凌小青
// 修 正 日  2011/11/02  修正内容 : Redmine#26319の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 凌小青
// 修 正 日  2011/11/22  修正内容 : Redmine#7744の対応
//----------------------------------------------------------------------------//
// 管理番号  11000127-00 作成担当 : gaocheng
// 修 正 日  2014/09/02  修正内容 : Redmine#43368単品売価一括修正対応
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Globarization;

using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using Infragistics.Win.Misc;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 単品売価設定一括登録・修正UIクラス
    /// </summary>
    /// <remarks>
    /// <br>Note        : 単品売価設定一括登録・修正UIフォームクラス</br>
    /// <br>Programmer  : 李占川</br>
    /// <br>Date        : 2010/08/04</br>
    /// <br>Update Note : 2010/09/06 曹文傑 #14238対応</br>
    /// </remarks>
    public partial class PMKHN09461UA : Form
    {
        #region ■ Constants

        // アセンブリID
        private const string ASSEMBLY_ID = "PMKHN09461U";

        // 画面状態保存用ファイル名
        private const string XML_FILE_INITIAL_DATA = "PMKHN09461U.dat";

        private const string ctGUIDE_NAME_SectionGuide = "SectionGuide";
        private const string ctGUIDE_NAME_GoodsMakerGuide = "GoodsMakerGuide";
        private const string ctGUIDE_NAME_BLGoodsGuide = "BLGoodsGuide";
        private const string ctGUIDE_NAME_BLGloupGuide = "BLGloupGuide";

        // グリッド列
        public const string COLUMN_NO = "No";
        public const string COLUMN_GOODSNO = "GoodsNo";
        public const string COLUMN_GOODSNAME = "GoodsName";
        public const string COLUMN_MAKERCODE = "MakerCode";
        public const string COLUMN_BLCODE = "BlCode";
        public const string COLUMN_BLGROUPCODE = "blGroupCode";
        public const string COLUMN_SUPPLIERCODE = "SupplierCode";
        public const string COLUMN_PRICEFL = "PriceFl";   // 標準価格
        public const string COLUMN_SUPPLIERPRICE = "SupplierPrice";   // 仕入原価

        public const string COLUMN_MAKERNAME = "MakerName";

        public const string COLUMN_SALERATE1 = "SaleRate1";
        public const string COLUMN_SALERATE2 = "SaleRate2";
        public const string COLUMN_SALERATE3 = "SaleRate3";
        public const string COLUMN_SALERATE4 = "SaleRate4";
        public const string COLUMN_SALERATE5 = "SaleRate5";
        public const string COLUMN_SALERATE6 = "SaleRate6";
        public const string COLUMN_SALERATE7 = "SaleRate7";
        public const string COLUMN_SALERATE8 = "SaleRate8";
        public const string COLUMN_SALERATE9 = "SaleRate9";
        public const string COLUMN_SALERATE10 = "SaleRate10";
        public const string COLUMN_SALERATE11 = "SaleRate11";
        public const string COLUMN_SALERATE12 = "SaleRate12";
        public const string COLUMN_SALERATE13 = "SaleRate13";
        public const string COLUMN_SALERATE14 = "SaleRate14";
        public const string COLUMN_SALERATE15 = "SaleRate15";
        public const string COLUMN_SALERATE16 = "SaleRate16";
        public const string COLUMN_SALERATE17 = "SaleRate17";
        public const string COLUMN_SALERATE18 = "SaleRate18";
        public const string COLUMN_SALERATE19 = "SaleRate19";
        public const string COLUMN_SALERATE20 = "SaleRate20";
        public const string COLUMN_SALERATE21 = "SaleRate21";

        public const int COLINDEX_SALERATE_ST = 9;
        public const int COLINDEX_SALERATE_ED = 29;

        private const string FORMAT = "N";
        private const string FORMAT_NUM = "###,###";
        private const string DETAIL_TITLE_1 = "売価額";
        private const string DETAIL_TITLE_2 = "売価率";
        private const string DETAIL_TITLE_3 = "ユーザー価格";
        private const string DETAIL_TITLE_4 = "価格ＵＰ率";
        private const string DETAIL_TITLE_5 = "原価ＵＰ率";
        private const string DETAIL_TITLE_6 = "粗利確保率";

        #endregion ■ Constants

        #region ■ Private Members

        private ControlScreenSkin _controlScreenSkin;

        private string _enterpriseCode;

        private SecInfoAcs _secInfoAcs;                                 // 拠点情報アクセスクラス
        private SecInfoSetAcs _secInfoSetAcs;                           // 拠点情報設定アクセスクラス
        private MakerAcs _makerAcs;                                     // メーカーアクセスクラス
        private BLGoodsCdAcs _blGoodsCdAcs;                             // BLアクセスクラス
        private BLGroupUAcs _blGroupUAcs;                               // BLグループアクセスクラス
        private CustomerSearchAcs _customerSearchAcs;                   // 得意先情報アクセスクラス
        private UserGuideAcs _userGuideAcs;                             // ユーザーガイドアクセスクラス
        private GoodsRateSetUpdateAcs _goodsRateSetUpdateAcs;           // 単品売価設定一括登録・修正アクセスクラス
        private PMKHN09461UC _pMKHN09461UC;
        private PMKHN09461UD _pMKHN09461UD;
        private PMKHN09461UB _pMKHN09461UB;

        private Infragistics.Win.UltraWinToolbars.ButtonTool _closeButton;				// 終了ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _saveButton;				// 保存ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _guideButton;				// ガイドボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _searchButton;		        // 検索ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _rateGRefButton;		    // 掛率Ｇ引用ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _customerRefButton;		// 得意先引用ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _renewalButton;		    // 最新情報ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _showChangeButton;		    // 表示切替ボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _undoButton;		        // クリアボタン
        private Infragistics.Win.UltraWinToolbars.ButtonTool _allDeleteButton;		    // 一括削除ボタン

        private Dictionary<string, string> _guideEnableControlDictionary = new Dictionary<string, string>();

        // グリッド設定制御クラス
        private GridStateController _gridStateController;

        private Dictionary<string, SecInfoSet> _secInfoSetDic;
        private Dictionary<int, MakerUMnt> _makerDic;
        private Dictionary<int, BLGoodsCdUMnt> _blGoodsCdUMntDic;
        private Dictionary<int, BLGroupU> _blGroupUDic;
        private Dictionary<int, CustomerSearchRet> _customerSearchRetDic;
        private Dictionary<int, string> _custRateGrpDic;

        private TNedit[] _tNedit_CustomerCode;
        private TNedit[] _tNedit_CustRateGrpCode;

        private int _objectDiv;
        private string _searchSectionCode;
        private int _targetDivide;
        private bool _unSetting;
        private Dictionary<int, int> _targetDic = new Dictionary<int, int>();
        private List<GoodsRateSetSearchResult> _logicDelRateList;
        private List<GoodsRateSetSearchResult> _displayList;
        private List<GoodsRateSetSearchResult> _ratedisplayList;

        private GoodsRateSetSearchParam _extrInfo;

        private bool _closeFlg;

        private int _panel3Height = 187;

        // 掛率マスタデータのデータセット
        private DataSet _rateDataSet = null;

        // データテーブルのclone
        DataTable _dataTableClone = new DataTable();

        /// <summary>中断ダイアログ</summary>
        private SFCMN00299CA _processingDialog = null;

        // 前回の拠点コード
        private string _prevSectionCode = null;
        // 前回のBLコード
        private int _prevBLGoodsCode = 0;
        // 前回のBLグループコード
        private int _prevBLGroupCode = 0;
        // 前回のメーカーコード
        private int _prevMakerCode = 0;

        private string _tNedit_CustomerCodeName = null;

        // 得意先コード・得意先掛率グループコードリスト
        private List<int> _keyList = new List<int>();

        private int _startIndex = 9;

        // --- ADD 2010/08/30 ---------------------------------->>>>>
        // フォーカス制御用
        TNedit _preCtrl = null;
        // 得意先コードチェック用
        private CustomerInputAcs _customerInputAcs = null;
        // 検索要否チェック用
        private bool searchFlag = false;
        // --- ADD 2010/08/30 ----------------------------------<<<<<

        #endregion ■ Private Members


        #region ■ Constructor
        /// <summary>
        /// 単品売価設定一括登録・修正UIクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note        : 掛率マスタ一括修正・登録UIフォームクラスのインスタンスを生成します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        public PMKHN09461UA()
        {
            InitializeComponent();

            this._controlScreenSkin = new ControlScreenSkin();

            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            this._secInfoAcs = new SecInfoAcs();
            this._secInfoSetAcs = new SecInfoSetAcs();
            this._blGoodsCdAcs = new BLGoodsCdAcs();
            this._makerAcs = new MakerAcs();
            this._blGroupUAcs = new BLGroupUAcs();
            this._customerSearchAcs = new CustomerSearchAcs();
            this._userGuideAcs = new UserGuideAcs();
            this._goodsRateSetUpdateAcs = new GoodsRateSetUpdateAcs();

            this._gridStateController = new GridStateController();

            this._rateDataSet = new DataSet();

            // --- ADD 2010/08/30 ---------------------------------->>>>>
            this._customerInputAcs = new CustomerInputAcs();
            // --- ADD 2010/08/30 ----------------------------------<<<<<

            // マスタ読込
            ReadSecInfoSet();
            ReadMakerUMnt();
            ReadCustomerSearchRet();
            ReadCustRateGrp();

            // 画面初期設定
            SetInitialSetting();

            // 画面クリア
            ClearScreen();
        }

        #endregion ■ Constructor


        #region ■ Private Methods

        #region XML操作
        /// <summary>
        /// ＸＭＬデータの読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 画面状態保持用のＸＭＬの読込処理を行います。</br>
        /// <br>Programmer	: 李占川</br>
        /// <br>Date		: 2010/08/04</br>
        /// </remarks>
        private void LoadStateXmlData()
        {
            int status = this._gridStateController.LoadGridState(XML_FILE_INITIAL_DATA, ref this.uGrid_Details);
            if (status == 0)
            {
                GridStateController.GridStateInfo gridStateInfo = this._gridStateController.GetGridStateInfo(ref this.uGrid_Details);
                if (gridStateInfo != null)
                {
                    // フォントサイズ
                    this.tComboEditor_GridFontSize.Value = (int)gridStateInfo.FontSize;
                    // 列の自動調整
                    this.uCheckEditor_AutoFillToColumn.Checked = gridStateInfo.AutoFit;
                }
                else
                {
                    status = 4;
                }
            }
            if (status != 0)
            {
                // フォントサイズ
                this.tComboEditor_GridFontSize.Value = 11;
                // 列の自動調整
                this.uCheckEditor_AutoFillToColumn.Checked = false;
            }
        }

        /// <summary>
        /// ＸＭＬデータの保存処理
        /// </summary>
        /// <remarks>
        /// <br>Note		: 画面状態保持用のＸＭＬの保存処理を行います。</br>
        /// <br>Programmer	: 李占川</br>
        /// <br>Date		: 2010/08/04</br>
        /// </remarks>
        public void SaveStateXmlData()
        {
            // ADD 2010/08/27  ---------->>>>>
            if (this.uCheckEditor_AutoFillToColumn.Checked)
            {
                this.uGrid_Details.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
            }
            else
            {
                this.uGrid_Details.DisplayLayout.AutoFitStyle = AutoFitStyle.None;
            }
            // グリッド情報を保存
            this._gridStateController.SaveGridState(XML_FILE_INITIAL_DATA, ref this.uGrid_Details);
            // ADD 2010/08/27  ----------<<<<<
        }
        #endregion XML操作

        #region マスタ読込
        /// <summary>
        /// 拠点情報マスタ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 拠点情報マスタを読み込み、バッファに保持します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private void ReadSecInfoSet()
        {
            this._secInfoSetDic = new Dictionary<string, SecInfoSet>();
            this._secInfoAcs.ResetSectionInfo();

            foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
            {
                if (secInfoSet.LogicalDeleteCode == 0)
                {
                    this._secInfoSetDic.Add(secInfoSet.SectionCode.Trim(), secInfoSet);
                }
            }
        }

        /// <summary>
        /// メーカーマスタ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : メーカーマスタを読み込み、バッファに保持します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private void ReadMakerUMnt()
        {
            this._makerDic = new Dictionary<int, MakerUMnt>();

            try
            {
                ArrayList retList;

                int status = this._makerAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (MakerUMnt makerUMnt in retList)
                    {
                        if (makerUMnt.LogicalDeleteCode == 0)
                        {
                            this._makerDic.Add(makerUMnt.GoodsMakerCd, makerUMnt);
                        }
                    }
                }
            }
            catch
            {
                this._makerDic = new Dictionary<int, MakerUMnt>();
            }
        }

        /// <summary>
        /// 得意先マスタ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 得意先マスタを読み込み、バッファに保持します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private void ReadCustomerSearchRet()
        {
            this._customerSearchRetDic = new Dictionary<int, CustomerSearchRet>();

            try
            {
                CustomerSearchRet[] retArray;

                CustomerSearchPara para = new CustomerSearchPara();
                para.EnterpriseCode = this._enterpriseCode;

                int status = this._customerSearchAcs.Serch(out retArray, para);
                if (status == 0)
                {
                    foreach (CustomerSearchRet ret in retArray)
                    {
                        if (ret.LogicalDeleteCode == 0)
                        {
                            this._customerSearchRetDic.Add(ret.CustomerCode, ret);
                        }
                    }
                }
            }
            catch
            {
                this._customerSearchRetDic = new Dictionary<int, CustomerSearchRet>();
            }
        }

        /// <summary>
        /// ユーザーガイドマスタ(得意先掛率Ｇ)読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : ユーザーガイドマスタを読み込み、バッファに保持します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private void ReadCustRateGrp()
        {
            this._custRateGrpDic = new Dictionary<int, string>();

            try
            {
                ArrayList retList;

                int status = this._userGuideAcs.SearchAllDivCodeBody(out retList, this._enterpriseCode,
                                                                     43, UserGuideAcsData.UserBodyData);
                if (status == 0)
                {
                    foreach (UserGdBd userGdBd in retList)
                    {
                        if (userGdBd.LogicalDeleteCode == 0)
                        {
                            this._custRateGrpDic.Add(userGdBd.GuideCode, userGdBd.GuideName.Trim());
                        }
                    }
                }
            }
            catch
            {
                this._custRateGrpDic = new Dictionary<int, string>();
            }
        }

        /// <summary>
        /// BLコードマスタ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : BLコードマスタを読み込み、バッファに保持します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private void ReadBLGoodsCdUMnt()
        {
            int status = 0;

            this._blGoodsCdUMntDic = new Dictionary<int, BLGoodsCdUMnt>();

            try
            {
                ArrayList retList;

                status = this._blGoodsCdAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (BLGoodsCdUMnt blGoodsCdUMnt in retList)
                    {
                        if (blGoodsCdUMnt.LogicalDeleteCode == 0)
                        {
                            this._blGoodsCdUMntDic.Add(blGoodsCdUMnt.BLGoodsCode, blGoodsCdUMnt);
                        }
                    }
                }
            }
            catch
            {
                this._blGoodsCdUMntDic = new Dictionary<int, BLGoodsCdUMnt>();
            }
        }

        /// <summary>
        /// グループコードマスタ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : グループコードマスタを読み込み、バッファに保持します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private void ReadBLGroupU()
        {
            this._blGroupUDic = new Dictionary<int, BLGroupU>();

            try
            {
                ArrayList retList;

                int status = this._blGroupUAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (BLGroupU blGroupU in retList)
                    {
                        //-----ADD 2010/08/30---------->>>>>
                        if (blGroupU.LogicalDeleteCode == 0)
                        {
                        //-----ADD 2010/08/30----------<<<<<
                            this._blGroupUDic.Add(blGroupU.BLGroupCode, blGroupU);
                        //-----ADD 2010/08/30---------->>>>>
                        }
                        //-----ADD 2010/08/30----------<<<<<
                    }
                }
            }
            catch
            {
                this._blGroupUDic = new Dictionary<int, BLGroupU>();
            }
        }
        #endregion マスタ読込

        #region 名称取得
        /// <summary>
        /// 拠点略称取得処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>拠点名</returns>
        /// <remarks>
        /// <br>Note        : 拠点コードに該当する拠点略称を取得します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private string GetSectionName(string sectionCode)
        {
            sectionCode = sectionCode.Trim().PadLeft(2, '0');

            if (sectionCode == "00")
            {
                return "全社";
            }

            if (this._secInfoSetDic.ContainsKey(sectionCode))
            {
                return this._secInfoSetDic[sectionCode].SectionGuideSnm.Trim();
            }

            return "";
        }

        /// <summary>
        /// メーカー名取得処理
        /// </summary>
        /// <param name="makerCode">メーカーコード</param>
        /// <returns>メーカー名</returns>
        /// <remarks>
        /// <br>Note        : メーカーコードに該当する名称を取得します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private string GetMakerName(int makerCode)
        {
            if (this._makerDic.ContainsKey(makerCode))
            {
                return this._makerDic[makerCode].MakerName.Trim();
            }

            return "";
        }

        /// <summary>
        /// ＢＬコード名取得処理
        /// </summary>
        /// <param name="blGoodsCode">ＢＬコード</param>
        /// <returns>ＢＬコード名</returns>
        /// <remarks>
        /// <br>Note        : ＢＬコードに該当する名称を取得します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private string GetBLGoodsName(int blGoodsCode)
        {
            if (this._blGoodsCdUMntDic == null)
            {
                // BLコードマスタ読込処理
                ReadBLGoodsCdUMnt();
            }

            if (this._blGoodsCdUMntDic.ContainsKey(blGoodsCode))
            {
                return this._blGoodsCdUMntDic[blGoodsCode].BLGoodsHalfName;
            }

            return "";
        }

        /// <summary>
        /// ＢＬコード名取得処理
        /// </summary>
        /// <param name="makerCode">ＢＬコード</param>
        /// <returns>ＢＬコード名</returns>
        /// <remarks>
        /// <br>Note        : ＢＬコードに該当する名称を取得します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private string GetBLGroupName(int blGroupCode)
        {
            if (this._blGroupUDic == null)
            {
                // グループコードマスタ読込処理
                ReadBLGroupU();
            }

            if (this._blGroupUDic.ContainsKey(blGroupCode))
            {
                return this._blGroupUDic[blGroupCode].BLGroupName;
            }

            return "";
        }

        /// <summary>
        /// 得意先略称取得処理
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <returns>得意先略称</returns>
        /// <remarks>
        /// <br>Note        : 得意先コードに該当する得意先略称を取得します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private string GetCustomerSnm(int customerCode)
        {
            if (this._customerSearchRetDic.ContainsKey(customerCode))
            {
                return this._customerSearchRetDic[customerCode].Snm.Trim();
            }

            return "";
        }

        /// <summary>
        /// 得意先掛率Ｇ名称取得処理
        /// </summary>
        /// <param name="custRateGrpCode">得意先掛率Ｇコード</param>
        /// <returns>得意先掛率Ｇ名称</returns>
        /// <remarks>
        /// <br>Note        : 得意先掛率Ｇコードに該当する得意先掛率Ｇ名称を取得します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private string GetCustRateGrpName(int custRateGrpCode)
        {
            if (this._custRateGrpDic.ContainsKey(custRateGrpCode))
            {
                return (string)this._custRateGrpDic[custRateGrpCode];
            }

            return "";
        }
        #endregion 名称取得

        #region マスタ存在チェック
        /// <summary>
        /// 得意先存在チェック処理
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <returns>true：OK、false：NG</returns>
        /// <remarks>
        /// <br>Note       : 得意先が存在するかチェックします。</br>
        /// <br></br>
        /// </remarks>
        private bool CheckCustomer(int customerCode)
        {
            bool check = false;

            try
            {
                if (this._customerSearchRetDic.ContainsKey(customerCode))
                {
                    check = true;
                }
            }
            catch
            {
                check = false;
            }

            return check;
        }
        #endregion マスタ存在チェック

        #region 初期設定
        /// <summary>
        /// 画面初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 画面情報の初期設定を行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private void SetInitialSetting()
        {
            //---------------------------------
            // コントロール配列化
            //---------------------------------
            this._tNedit_CustomerCode = new TNedit[21];
            this._tNedit_CustomerCode[0] = this.tNedit_CustomerCode1;
            this._tNedit_CustomerCode[1] = this.tNedit_CustomerCode2;
            this._tNedit_CustomerCode[2] = this.tNedit_CustomerCode3;
            this._tNedit_CustomerCode[3] = this.tNedit_CustomerCode4;
            this._tNedit_CustomerCode[4] = this.tNedit_CustomerCode5;
            this._tNedit_CustomerCode[5] = this.tNedit_CustomerCode6;
            this._tNedit_CustomerCode[6] = this.tNedit_CustomerCode7;
            this._tNedit_CustomerCode[7] = this.tNedit_CustomerCode8;
            this._tNedit_CustomerCode[8] = this.tNedit_CustomerCode9;
            this._tNedit_CustomerCode[9] = this.tNedit_CustomerCode10;
            this._tNedit_CustomerCode[10] = this.tNedit_CustomerCode11;
            this._tNedit_CustomerCode[11] = this.tNedit_CustomerCode12;
            this._tNedit_CustomerCode[12] = this.tNedit_CustomerCode13;
            this._tNedit_CustomerCode[13] = this.tNedit_CustomerCode14;
            this._tNedit_CustomerCode[14] = this.tNedit_CustomerCode15;
            this._tNedit_CustomerCode[15] = this.tNedit_CustomerCode16;
            this._tNedit_CustomerCode[16] = this.tNedit_CustomerCode17;
            this._tNedit_CustomerCode[17] = this.tNedit_CustomerCode18;
            this._tNedit_CustomerCode[18] = this.tNedit_CustomerCode19;
            this._tNedit_CustomerCode[19] = this.tNedit_CustomerCode20;
            this._tNedit_CustomerCode[20] = this.tNedit_CustomerCode21;

            this._tNedit_CustRateGrpCode = new TNedit[21];
            this._tNedit_CustRateGrpCode[0] = this.tNedit_CustRateGrpCode1;
            this._tNedit_CustRateGrpCode[1] = this.tNedit_CustRateGrpCode2;
            this._tNedit_CustRateGrpCode[2] = this.tNedit_CustRateGrpCode3;
            this._tNedit_CustRateGrpCode[3] = this.tNedit_CustRateGrpCode4;
            this._tNedit_CustRateGrpCode[4] = this.tNedit_CustRateGrpCode5;
            this._tNedit_CustRateGrpCode[5] = this.tNedit_CustRateGrpCode6;
            this._tNedit_CustRateGrpCode[6] = this.tNedit_CustRateGrpCode7;
            this._tNedit_CustRateGrpCode[7] = this.tNedit_CustRateGrpCode8;
            this._tNedit_CustRateGrpCode[8] = this.tNedit_CustRateGrpCode9;
            this._tNedit_CustRateGrpCode[9] = this.tNedit_CustRateGrpCode10;
            this._tNedit_CustRateGrpCode[10] = this.tNedit_CustRateGrpCode11;
            this._tNedit_CustRateGrpCode[11] = this.tNedit_CustRateGrpCode12;
            this._tNedit_CustRateGrpCode[12] = this.tNedit_CustRateGrpCode13;
            this._tNedit_CustRateGrpCode[13] = this.tNedit_CustRateGrpCode14;
            this._tNedit_CustRateGrpCode[14] = this.tNedit_CustRateGrpCode15;
            this._tNedit_CustRateGrpCode[15] = this.tNedit_CustRateGrpCode16;
            this._tNedit_CustRateGrpCode[16] = this.tNedit_CustRateGrpCode17;
            this._tNedit_CustRateGrpCode[17] = this.tNedit_CustRateGrpCode18;
            this._tNedit_CustRateGrpCode[18] = this.tNedit_CustRateGrpCode19;
            this._tNedit_CustRateGrpCode[19] = this.tNedit_CustRateGrpCode20;
            this._tNedit_CustRateGrpCode[20] = this.tNedit_CustRateGrpCode21;

            //---------------------------------
            // 画面スキンファイルの読込(デフォルトスキン指定)
            //---------------------------------
            // スキン変更除外設定
            List<string> excCtrlNm = new List<string>();
            excCtrlNm.Add(this.Standard_UGroupBox.Name);
            excCtrlNm.Add(this.Standard_UGroupBox2.Name);
            this._controlScreenSkin.SetExceptionCtrl(excCtrlNm);

            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);

            // コントロールサイズ設定
            this.tEdit_SectionCodeAllowZero.Size = new Size(59, 24);
            this.tEdit_SectionName.Size = new Size(175, 24);
            this.tEdit_GoodsNo.Size = new Size(268, 24);
            this.tNedit_GoodsMakerCd.Size = new Size(59, 24);
            this.tEdit_MakerName.Size = new Size(175, 24);
            this.tNedit_BLGoodsCode.Size = new Size(59, 24);
            this.tEdit_BLGoodsName.Size = new Size(175, 24);
            this.tNedit_BLGloupCode.Size = new Size(59, 24);
            this.tEdit_BLGloupName.Size = new Size(175, 24);

            for (int index = 0; index < this._tNedit_CustomerCode.Length; index++)
            {
                this._tNedit_CustomerCode[index].Size = new Size(76, 24);
                this._tNedit_CustRateGrpCode[index].Size = new Size(76, 24);
            }

            //---------------------------------
            // アイコン設定
            //---------------------------------
            this.tToolbarsManager_MainMenu.ImageListSmall = IconResourceManagement.ImageList16;
            LabelTool labelTool;
            labelTool = (LabelTool)this.tToolbarsManager_MainMenu.Tools["Section_LabelTool"];
            labelTool.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BASE;
            labelTool = (LabelTool)this.tToolbarsManager_MainMenu.Tools["LoginCaption_LabelTool"];
            labelTool.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;
            _closeButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"];
            _closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            _saveButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Save"];
            _saveButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
            _searchButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Search"];
            _searchButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;
            _rateGRefButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_RateGRef"];
            _rateGRefButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SLIPCOPY;
            _customerRefButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_CustomerRef"];
            _customerRefButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SLIPCOPY;
            _guideButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"];
            _guideButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.GUIDE;
            _renewalButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Renewal"];
            _renewalButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.RENEWAL;
            _showChangeButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_ShowChange"];
            _showChangeButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.INDICATIONCHANGE;
            _undoButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Undo"];
            _undoButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;
            _allDeleteButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_AllDelete"];
            _allDeleteButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DELETE;

            // 拠点名
            ToolBase sectionName = tToolbarsManager_MainMenu.Tools["SectionName_LabelTool"];
            if (sectionName != null && LoginInfoAcquisition.Employee != null)
            {
                sectionName.SharedProps.Caption = GetSectionName(LoginInfoAcquisition.Employee.BelongSectionCode);
            }

            // ログイン名
            ToolBase loginName = tToolbarsManager_MainMenu.Tools["LoginName_LabelTool"];
            if (loginName != null && LoginInfoAcquisition.Employee != null)
            {
                loginName.SharedProps.Caption = LoginInfoAcquisition.Employee.Name.Trim();
            }

            ImageList imageList16 = IconResourceManagement.ImageList16;
            this.SectionGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.MakerGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.BLGoodsCdGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.BLGroupGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];

            //---------------------------------
            // グリッド設定
            //---------------------------------
            CreateGrid(ref this.uGrid_Details);
            // --- ADD 2010/08/27 ---------->>>>>
            // グリッド列幅設定
            SetColumnWidth(ref this.uGrid_Details);
            // --- ADD 2010/08/27 ----------<<<<<
        }
        #endregion 初期設定

        #region クリア処理
        /// <summary>
        /// 画面情報クリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 画面情報をクリアします。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private void ClearScreen()
        {
            uLabel_SaleRate.Text = DETAIL_TITLE_1; // ADD 2010/08/27
            _startIndex = 9;// ADD 2010/08/27

            // 対象区分
            this.tComboEditor_ObjectDiv.Value = 0;

            // 拠点コード
            this.tEdit_SectionCodeAllowZero.DataText = "00";
            this.tEdit_SectionName.DataText = "全社";
            _prevSectionCode = "00";

            // 品番
            this.tEdit_GoodsNo.Clear();

            // メーカーコード
            this.tNedit_GoodsMakerCd.Clear();
            this.tEdit_MakerName.Clear();
            _prevMakerCode = 0;

            // ＢＬコード
            this.tNedit_BLGoodsCode.Clear();
            this.tEdit_BLGoodsName.Clear();
            _prevBLGoodsCode = 0;

            // グループコード
            this.tNedit_BLGloupCode.Clear();
            this.tEdit_BLGloupName.Clear();
            _prevBLGroupCode = 0;

            // 区分
            this.tComboEditor_TargetDivide.Value = 1;

            // 未設定区分
            this.uCheckEditor_unSetting.Checked = false;

            // 得意先コード
            for (int index = 0; index < this._tNedit_CustomerCode.Length; index++)
            {
                this._tNedit_CustomerCode[index].Clear();
                this._tNedit_CustRateGrpCode[index].Clear();
            }

            // スクロールポジション初期化
            this.uGrid_Details.DisplayLayout.ColScrollRegions.Clear();

            // グリッドクリア
            ClearGrid();

            // フォーカス設定
            this.tComboEditor_ObjectDiv.Focus();
            _guideButton.SharedProps.Enabled = false;
        }

        /// <summary>
        /// グリッド初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : グリッドを初期化を行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private void ClearGrid()
        {
            this._targetDic = new Dictionary<int, int>();
            this._displayList = new List<GoodsRateSetSearchResult>();
            this._ratedisplayList = new List<GoodsRateSetSearchResult>();
            this._logicDelRateList = new List<GoodsRateSetSearchResult>();


            // グリッド作成処理
            CreateGrid(ref this.uGrid_Details);
        }
        #endregion クリア処理

        #region 保存
        /// <summary>
        /// 保存処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 保存処理を行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private int Save()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // 画面情報取得
            ArrayList saveList;
            ArrayList deleteList;
            GetUpdateList(out saveList, out deleteList);

            // 画面情報チェック
            string errMsg = "";

            try
            {
                if (this.uGrid_Details.Rows.Count == 0)
                {
                    errMsg = "保存対象データが存在しません。";
                    this.tComboEditor_ObjectDiv.Focus();
                    _guideButton.SharedProps.Enabled = false;
                    return (status);
                }
                if ((saveList.Count == 0) && (deleteList.Count == 0))
                {
                    errMsg = "保存対象データが存在しません。";
                    this.uGrid_Details.Rows[0].Cells[_startIndex].Activate();
                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                    return (status);
                }
            }
            finally
            {
                if (errMsg.Length > 0)
                {
                    ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                   errMsg,
                                   0,
                                   MessageBoxButtons.OK,
                                   MessageBoxDefaultButton.Button1);
                }
            }

            // 保存処理
            if (deleteList.Count > 0 || saveList.Count > 0)
            {
                status = this._goodsRateSetUpdateAcs.Save(ref deleteList, ref saveList, out errMsg);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                        {
                            if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE)
                            {
                                errMsg = "既に他端末より更新されています。";
                            }
                            else
                            {
                                errMsg = "既に他端末より削除されています。";
                            }

                            ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                           "Save",
                                           errMsg,
                                           status,
                                           MessageBoxButtons.OK);

                            this.tComboEditor_ObjectDiv.Focus();
                            _guideButton.SharedProps.Enabled = false;
                            return (status);
                        }
                    default:
                        {
                            ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                           "Save",
                                           "保存処理に失敗しました。",
                                           status,
                                           MessageBoxButtons.OK);

                            this.tComboEditor_ObjectDiv.Focus();
                            _guideButton.SharedProps.Enabled = false;
                            return (status);
                        }
                }
            }

            // 登録完了ダイアログ表示
            SaveCompletionDialog dialog = new SaveCompletionDialog();
            dialog.ShowDialog(2);

            // 再検索
            this.Search();
            // 色を黒を戻す
            uGrid_Details_AfterExitEditMode(null, null);

            return (status);
        }
        #endregion 保存

        /// <summary>得意先掛率グループの指定なし</summary>
        private const int ALL_CUST_RATE_GRP_CODE = -1;  

        #region 検索
        /// <summary>
        /// 検索処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 検索処理を行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private int Search()
        {
            // グリッドクリア
            ClearGrid();

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            _goodsRateSetUpdateAcs.ExtractCancelFlag = false;

            // 検索条件入力チェック
            bool bStatus = CheckSearchCondition();
            if (!bStatus)
            {
                return -1;
            }

            // 登録・修正対象コード取得
            this._targetDic = new Dictionary<int, int>();
            if ((int)this.tComboEditor_TargetDivide.Value == 0)
            {
                int custRateGrpCode;
                if (this.uCheckEditor_unSetting.Checked)
                {
                    this._targetDic.Add(ALL_CUST_RATE_GRP_CODE, ALL_CUST_RATE_GRP_CODE);
                }

                // 得意先掛率Ｇ
                for (int index = 0; index < this._tNedit_CustRateGrpCode.Length; index++)
                {
                    if (this._tNedit_CustRateGrpCode[index].DataText.Trim() == "")
                    {
                        continue;
                    }

                    custRateGrpCode = this._tNedit_CustRateGrpCode[index].GetInt();

                    if (!this._targetDic.ContainsKey(custRateGrpCode))
                    {
                        this._targetDic.Add(custRateGrpCode, custRateGrpCode);
                    }
                }
            }
            else
            {
                int customerCode;

                // 得意先
                for (int index = 0; index < this._tNedit_CustomerCode.Length; index++)
                {
                    customerCode = this._tNedit_CustomerCode[index].GetInt();

                    if (customerCode != 0)
                    {
                        if (!this._targetDic.ContainsKey(customerCode))
                        {
                            this._targetDic.Add(customerCode, customerCode);
                        }
                    }
                }
            }
            _keyList = new List<int>();
            foreach (int code in this._targetDic.Keys)
            {
                _keyList.Add(code);
            }

            // 検索条件格納
            SetExtrInfo(out this._extrInfo);

            // 抽出中画面部品のインスタンスを作成
            _processingDialog = new SFCMN00299CA();
            SFCMN00299CA msgForm = _processingDialog;
            msgForm.Title = "抽出処理";
            msgForm.Message = "現在、データ抽出中です。(ESCで中断します)";
            msgForm.DispCancelButton = true;
            msgForm.CancelButtonClick += new EventHandler(processingDialog_CancelButtonClick);

            List<GoodsRateSetSearchResult> rateSearchResultList = null;

            try
            {
                msgForm.Show();

                // 検索処理
                if (_goodsRateSetUpdateAcs.ExtractCancelFlag == false)
                {
                    status = this._goodsRateSetUpdateAcs.Search(out rateSearchResultList, this._extrInfo);
                }

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // [売価額]のデータを表示する
                    uLabel_SaleRate.Text = DETAIL_TITLE_1;
                    // グリッド表示リスト取得
                    GetDisplayList(rateSearchResultList);

                    // グリッドデータ設定
                    CreateGrid(ref this.uGrid_Details);

                    // 全展開ボタン押下可
                    this.uGrid_Details.ActiveRow = null;

                    if (this.uGrid_Details.Rows.Count == 0)
                    {
                        msgForm.Close();
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                       "検索条件に該当するデータが存在しません。",
                                       status,
                                       MessageBoxButtons.OK,
                                       MessageBoxDefaultButton.Button1);

                        // グリッドクリア
                        ClearGrid();

                        return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }

                    return (status);
                }
            }
            finally
            {
                msgForm.Close();
            }

            if (_goodsRateSetUpdateAcs.ExtractCancelFlag == true)
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_INFO, this.Name,
                    "処理を中断しました。",
                    status, MessageBoxButtons.OK);
                return (status);
            }
            _goodsRateSetUpdateAcs.ExtractCancelFlag = false;

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                       "検索条件に該当するデータが存在しません。",
                                       status,
                                       MessageBoxButtons.OK,
                                       MessageBoxDefaultButton.Button1);

                        // グリッドクリア
                        ClearGrid();

                        return (status);
                    }
                default:
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                       "Search",
                                       "検索処理に失敗しました。",
                                       status,
                                       MessageBoxButtons.OK);

                        // グリッドクリア
                        ClearGrid();

                        return (status);
                    }
            }
        }

        /// <summary>
        /// 中断ボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void processingDialog_CancelButtonClick(object sender, EventArgs e)
        {
            // 抽出キャンセル
            CancelExtract();
        }
        /// <summary>
        /// 抽出キャンセル
        /// </summary>
        private void CancelExtract()
        {
            // 抽出キャンセル
            _goodsRateSetUpdateAcs.ExtractCancelFlag = true;
            if (_processingDialog != null)
            {
                _processingDialog.Message = "中断します。";
            }
        }

        /// <summary>
        /// 検索条件設定処理
        /// </summary>
        /// <param name="para">検索条件</param>
        /// <remarks>
        /// <br>Note        : 画面情報から検索条件を設定します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2010/08/04</br>
        /// <br>Update Note : 2010/08/31 楊明俊 #14019の２の対応。</br>
        /// </remarks>
        private void SetExtrInfo(out GoodsRateSetSearchParam para)
        {
            //-----ADD 2010/08/30---------->>>>>
            string fileName = "";
            if (this._extrInfo != null)
            {
                fileName = this._extrInfo.FileName;
            }
            //-----ADD 2010/08/30----------<<<<<

            para = new GoodsRateSetSearchParam();

            // 企業コード
            para.EnterpriseCode = this._enterpriseCode;

            // 対象区分
            para.ObjectDiv = this.tComboEditor_ObjectDiv.SelectedItem.DataValue.ToString();

            // 拠点
            if ((this.tEdit_SectionCodeAllowZero.DataText.Trim() == "") ||
                (this.tEdit_SectionCodeAllowZero.DataText.Trim().PadLeft(2, '0') == "00"))
            {
                // 全社指定
                para.SectionCode = new string[1];
                para.SectionCode[0] = "00";
            }
            else
            {
                para.SectionCode = new string[1];
                para.SectionCode[0] = this.tEdit_SectionCodeAllowZero.DataText.Trim().PadLeft(2, '0');
            }

            // 品番
            para.GoodsNo = this.tEdit_GoodsNo.Text;

            // メーカー
            para.GoodsMakerCd = this.tNedit_GoodsMakerCd.GetInt();
            // BLコード
            para.BlGoodsCode = this.tNedit_BLGoodsCode.GetInt();
            //　グループコード
            para.BlGroupCode = this.tNedit_BLGloupCode.GetInt();

            if ((int)this.tComboEditor_TargetDivide.Value == 0)
            {
                // 得意先掛率Ｇ
                para.CustRateGrpCode = new int[this._targetDic.Keys.Count];
                if (this.uCheckEditor_unSetting.Checked)
                {
                    // FIXME:得意先掛率グループコード=-1は検索条件に入れない
                    if (null != _targetDic.Keys && _targetDic.Keys.Count > 0)
                        para.CustRateGrpCode = new int[this._targetDic.Keys.Count - 1];
                }

                int index = 0;
                bool hasFlg = false;
                foreach (int key in this._targetDic.Keys)
                {
                    if (this.uCheckEditor_unSetting.Checked && key < 0)
                    {
                        continue;   // FIXME:得意先掛率グループコード=-1は検索条件に入れない
                    }
                    para.CustRateGrpCode[index] = key;
                    index++;
                    hasFlg = true;
                }
                if (!hasFlg)
                    para.CustRateGrpCode = null;

            }
            else
            {
                // 得意先
                para.CustomerCode = new int[this._targetDic.Keys.Count];

                int index = 0;
                foreach (int key in this._targetDic.Keys)
                {
                    para.CustomerCode[index] = key;
                    index++;
                }
            }

            // ログイン拠点
            para.PrmSectionCode = new string[1];
            para.PrmSectionCode[0] = LoginInfoAcquisition.Employee.BelongSectionCode;

            // バッファに保持
            this._objectDiv = (int)this.tComboEditor_ObjectDiv.Value;
            this._targetDivide = (int)this.tComboEditor_TargetDivide.Value;
            this._searchSectionCode = this.tEdit_SectionCodeAllowZero.DataText.Trim().PadLeft(2, '0');
            // 未設定
            this._unSetting = uCheckEditor_unSetting.Checked;
            para.UnSettingFlg = this._unSetting;

            //-----ADD 2010/08/30---------->>>>>
            if (!string.IsNullOrEmpty(fileName))
            {
                para.FileName = fileName;
            }
            //-----ADD 2010/08/30----------<<<<<
        }
        #endregion 検索

        # region ガイド起動処理
        /// <summary>
        /// ガイド起動処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : ガイド起動処理を行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private void ExecuteGuide()
        {
            // ガイド起動処理
            bool flag = false;
            foreach (Control ctrl in ultraExpandableGroupBoxPanel1.Controls)
            {
                if (ctrl.ContainsFocus)
                {
                    switch (ctrl.Name)
                    {

                        // 拠点
                        case "tEdit_SectionCodeAllowZero":
                            {
                                this.SectionGuide_Button_Click(this.tEdit_SectionCodeAllowZero, new EventArgs());
                                flag = true;
                                break;
                            }
                        // メーカー
                        case "tNedit_GoodsMakerCd":
                            {
                                this.MakerGuide_Button_Click(this.tNedit_GoodsMakerCd, new EventArgs());
                                flag = true;
                                break;
                            }
                            // BL商品コード
                        case "tNedit_BLGoodsCode":
                            {
                                this.BLGoodsCdGuide_Button_Click(this.tNedit_BLGoodsCode, new EventArgs());
                                flag = true;
                                break;
                            }
                        // BLグループコード
                        case "tNedit_BLGloupCode":
                            {
                                this.BLGroupGuide_Button_Click(this.tNedit_BLGloupCode, new EventArgs());
                                flag = true;
                                break;
                            }
                    }
                    if (flag)
                    {
                        break;
                    }
                }
            }
            // 得意先掛け率Gガイド
            flag = false;
            foreach (Control ctrl in panel_CustRateGrp.Controls)
            {
                if (ctrl.ContainsFocus)
                {
                    try
                    {
                        this.Cursor = Cursors.WaitCursor;

                        int status;

                        UserGdHd userGdHd;
                        UserGdBd userGdBd;

                        status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 43);
                        if (status == 0)
                        {
                            TNedit control = (TNedit)(this.GetType().GetField(ctrl.Name, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase).GetValue(this));
                            control.DataText = userGdBd.GuideCode.ToString("0000");
                            // --- ADD 2010/08/30 ---------------------------------->>>>>
                            // フォーカス制御
                            this._preCtrl = (TNedit)ctrl;
                            if (!"tNedit_CustRateGrpCode21".Equals(ctrl.Name))
                            {
                                string strOldId = ctrl.Name.Replace("tNedit_CustRateGrpCode", "");
                                int nextId = int.Parse(strOldId) + 1;
                                string strNextCtrlName = "tNedit_CustRateGrpCode" + nextId.ToString();
                                TNedit nextControl = (TNedit)(this.GetType().GetField(strNextCtrlName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase).GetValue(this));
                                nextControl.Focus();
                            }
                            else
                            {
                                // 画面情報比較
                                bool bStatus = CompareScreen();
                                if (!bStatus)
                                {
                                    return;
                                }

                                // 検索処理
                                Search();
                            }
                            // --- ADD 2010/08/30 ----------------------------------<<<<<
                        }
                        // --- ADD 2010/08/30 ---------------------------------->>>>>
                        else
                        {
                            this._preCtrl = (TNedit)ctrl;
                            this._preCtrl.Focus();
                            this._preCtrl.SelectAll();
                        }
                        // --- ADD 2010/08/30 ----------------------------------<<<<<
                        flag = true;
                    }
                    finally
                    {
                        this.Cursor = Cursors.Default;
                    }
                }
                if (flag)
                {
                    break;
                }
            }
            // 得意先ガイド
            flag = false;
            foreach (Control ctrl in panel_Customer.Controls)
            {
                if (ctrl.ContainsFocus)
                {
                    this._tNedit_CustomerCodeName = ctrl.Name;
                    try
                    {
                        this.Cursor = Cursors.WaitCursor;

                        PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);

                        customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
                        // --- UPD 2010/08/30 ---------------------------------->>>>>
                        //customerSearchForm.ShowDialog(this);
                        DialogResult result = customerSearchForm.ShowDialog(this);
                        // --- UPD 2010/08/30 ---------------------------------->>>>>
                        flag = true;
                        // --- ADD 2010/08/30 ---------------------------------->>>>>
                        if ((int)result == 1)
                        {
                            // フォーカス制御
                            this._preCtrl = (TNedit)ctrl;
                            if (!"tNedit_CustomerCode21".Equals(ctrl.Name) && !"".Equals(ctrl.Text))
                            {
                                string strOldId = ctrl.Name.Replace("tNedit_CustomerCode", "");
                                int nextId = int.Parse(strOldId) + 1;
                                string strNextCtrlName = "tNedit_CustomerCode" + nextId.ToString();
                                TNedit nextControl = (TNedit)(this.GetType().GetField(strNextCtrlName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase).GetValue(this));
                                nextControl.Focus();
                            }
                            else if ("tNedit_CustomerCode21".Equals(ctrl.Name) && !"".Equals(ctrl.Text))
                            {
                                // 画面情報比較
                                bool bStatus = CompareScreen();
                                if (!bStatus)
                                {
                                    return;
                                }

                                // 検索処理
                                Search();
                            }
                        }
                        else
                        {
                            this._preCtrl = (TNedit)ctrl;
                            this._preCtrl.Focus();
                            this._preCtrl.SelectAll();
                        }
                        // --- ADD 2010/08/30 ----------------------------------<<<<<
                    }
                    finally
                    {
                        this.Cursor = Cursors.Default;
                    }
                }
                if (flag)
                {
                    break;
                }
            }
        }

        /// <summary>
        /// 得意先選択時発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="customerSearchRet">得意先検索戻り値クラス</param>
        /// <remarks>
        /// <br>Note       : 得意先選択時に発生します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/08/04</br>
        /// </remarks>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null)
            {
                return;
            }

            // 得意先コード設定
            TNedit control = (TNedit)(this.GetType().GetField(this._tNedit_CustomerCodeName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase).GetValue(this));
            control.SetInt(customerSearchRet.CustomerCode);
        }
        # endregion　ガイド起動処理

        #region データ取得
        /// <summary>
        /// グリッド表示リスト取得処理
        /// </summary>
        /// <param name="rateSearchResultList">掛率マスタ検索結果リスト</param>
        /// <remarks>
        /// <br>Note        : グリッドに表示するリストを取得します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private void GetDisplayList(List<GoodsRateSetSearchResult> rateSearchResultList)
        {

            // UPD 2010/09/26 --- >>>
            // 重複しているデータがある場合は、最小ロット数のデータを取得
            //Dictionary<string, GoodsRateSetSearchResult> parentDic = new Dictionary<string, GoodsRateSetSearchResult>();
            //foreach (GoodsRateSetSearchResult rateSearchResult in rateSearchResultList)
            //{
            //    if ((0 == _objectDiv && 0 == rateSearchResult.GoodsLogicalDeleteCode)
            //        || (1 == _objectDiv && 0 == rateSearchResult.LogicalDeleteCode))
            //    {
            //        string key = MakeParentKey(rateSearchResult);
            //        if (!parentDic.ContainsKey(key))
            //        {
            //            parentDic.Add(key, rateSearchResult.Clone());
            //        }
            //        else
            //        {
            //            if (rateSearchResult.LotCount < parentDic[key].LotCount)
            //            {
            //                parentDic[key] = rateSearchResult.Clone();
            //            }
            //        }
            //    }
            //}

            //_displayList = new List<GoodsRateSetSearchResult>();

            //foreach (GoodsRateSetSearchResult result in parentDic.Values)
            //{
            //    this._displayList.Add(result.Clone());
            //}

            this._displayList = rateSearchResultList;

            //Dictionary<string, GoodsRateSetSearchResult> childDic = new Dictionary<string, GoodsRateSetSearchResult>();
            //foreach (GoodsRateSetSearchResult rateSearchResult in rateSearchResultList)
            //{
            //    if (0 == rateSearchResult.GoodsLogicalDeleteCode && 0 == rateSearchResult.LogicalDeleteCode)
            //    {
            //        string key = MakeRateKey(rateSearchResult);
            //        if (!childDic.ContainsKey(key))
            //        {
            //            childDic.Add(key, rateSearchResult.Clone());
            //        }
            //        else
            //        {
            //            if (rateSearchResult.LotCount < childDic[key].LotCount)
            //            {
            //                childDic[key] = rateSearchResult.Clone();
            //            }
            //        }
            //    }
            //}

            //_ratedisplayList = new List<GoodsRateSetSearchResult>();

            //foreach (GoodsRateSetSearchResult result in childDic.Values)
            //{
            //    this._ratedisplayList.Add(result.Clone());
            //}

            //// 論理削除のデータ（掛率マスタを復旧するため）
            //Dictionary<string, GoodsRateSetSearchResult> deleteDic = new Dictionary<string, GoodsRateSetSearchResult>();
            //foreach (GoodsRateSetSearchResult rateSearchResult in rateSearchResultList)
            //{
            //    if (1 == rateSearchResult.LogicalDeleteCode)
            //    {
            //        string key = MakeRateKey(rateSearchResult);
            //        if (!deleteDic.ContainsKey(key))
            //        {
            //            deleteDic.Add(key, rateSearchResult.Clone());
            //        }
            //        else
            //        {
            //            if (rateSearchResult.LotCount < deleteDic[key].LotCount)
            //            {
            //                deleteDic[key] = rateSearchResult.Clone();
            //            }
            //        }
            //    }
            //}


            Dictionary<string, GoodsRateSetSearchResult> childDic = new Dictionary<string, GoodsRateSetSearchResult>();

            // 論理削除のデータ（掛率マスタを復旧するため）
            Dictionary<string, GoodsRateSetSearchResult> deleteDic = new Dictionary<string, GoodsRateSetSearchResult>();

            foreach (GoodsRateSetSearchResult rateSearchResult in rateSearchResultList)
            {
                if (1 == rateSearchResult.LogicalDeleteCode)
                {
                    string key = MakeRateKey(rateSearchResult);
                    if (!deleteDic.ContainsKey(key))
                    {
                        deleteDic.Add(key, rateSearchResult.Clone());
                    }
                    else
                    {
                        if (rateSearchResult.LotCount < deleteDic[key].LotCount)
                        {
                            deleteDic[key] = rateSearchResult.Clone();
                        }
                    }
                }
                else if (0 == rateSearchResult.GoodsLogicalDeleteCode && 0 == rateSearchResult.LogicalDeleteCode)
                {
                    string key = MakeRateKey(rateSearchResult);
                    if (!childDic.ContainsKey(key))
                    {
                        childDic.Add(key, rateSearchResult.Clone());
                    }
                    else
                    {
                        if (rateSearchResult.LotCount < childDic[key].LotCount)
                        {
                            childDic[key] = rateSearchResult.Clone();
                        }
                    }
                }
            }


            _logicDelRateList = new List<GoodsRateSetSearchResult>();

            _ratedisplayList = new List<GoodsRateSetSearchResult>();

            foreach (GoodsRateSetSearchResult result in childDic.Values)
            {
                this._ratedisplayList.Add(result.Clone());
            }

            foreach (GoodsRateSetSearchResult result in deleteDic.Values)
            {
                this._logicDelRateList.Add(result.Clone());
            }
            // UPD 2010/09/26 --- <<<

        }

        /// <summary>
        /// 更新データ取得処理
        /// </summary>
        /// <param name="saveList">保存リスト</param>
        /// <param name="deleteList">削除リスト</param>
        /// <remarks>
        /// <br>Note        : 更新データを取得します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private void GetUpdateList(out ArrayList saveList, out ArrayList deleteList)
        {
            string key;

            saveList = new ArrayList();
            deleteList = new ArrayList();

            this.uGrid_Details.ActiveCell = null;

            for (int rowIndex = 0; rowIndex < this.uGrid_Details.Rows.Count; rowIndex++)
            {
                List<GoodsRateSetSearchResult> resultList;

                CellsCollection cells = this.uGrid_Details.Rows[rowIndex].Cells;

                DataRow originalDr = this._dataTableClone.Select(COLUMN_NO + " ='"
                    + cells[COLUMN_NO].Value.ToString() + "'")[0];

                key = MakeKey(StrObjToInt(cells[COLUMN_MAKERCODE].Value), StrObjToInt(cells[COLUMN_BLCODE].Value),
                    StrObjToInt(cells[COLUMN_BLGROUPCODE].Value), StrObjToInt(cells[COLUMN_SUPPLIERCODE].Value),
                    cells[COLUMN_GOODSNO].Value.ToString());

                resultList = this._ratedisplayList.FindAll(delegate(GoodsRateSetSearchResult target)
                {
                    if (key.Equals(MakeKey(target.GoodsMakerCd, target.BLGoodsCode, target.BLGroupCode, target.GoodsSupplierCd, target.GoodsNo)))
                    {
                        return (true);
                    }
                    else
                    {
                        return (false);
                    }
                });

                List<GoodsRateSetSearchResult> resultListUnitPrice = new List<GoodsRateSetSearchResult>();

                // 売価
                foreach (int code in this._targetDic.Keys)
                {
                    // 売価額
                    double oldCode1 = DoubleObjToDouble(originalDr[code.ToString() + "title1"]);
                    double newCode1 = DoubleObjToDouble(cells[code.ToString() + "title1"].Value);
                    // 売価率
                    double oldCode2 = DoubleObjToDouble(originalDr[code.ToString() + "title2"]);
                    double newCode2 = DoubleObjToDouble(cells[code.ToString() + "title2"].Value);
                    // ユーザー価格
                    double oldCode3 = DoubleObjToDouble(originalDr[code.ToString() + "title3"]);
                    double newCode3 = DoubleObjToDouble(cells[code.ToString() + "title3"].Value);
                    // 価格ＵＰ率
                    double oldCode4 = DoubleObjToDouble(originalDr[code.ToString() + "title4"]);
                    double newCode4 = DoubleObjToDouble(cells[code.ToString() + "title4"].Value);
                    // 原価ＵＰ率
                    double oldCode5 = DoubleObjToDouble(originalDr[code.ToString() + "title5"]);
                    double newCode5 = DoubleObjToDouble(cells[code.ToString() + "title5"].Value);
                    // 粗利確保率
                    double oldCode6 = DoubleObjToDouble(originalDr[code.ToString() + "title6"]);
                    double newCode6 = DoubleObjToDouble(cells[code.ToString() + "title6"].Value);

                    double[] oldValues = new double[] { oldCode1, oldCode2, oldCode3, oldCode4, oldCode5, oldCode6 };
                    double[] newValues = new double[] { newCode1, newCode2, newCode3, newCode4, newCode5, newCode6 };

                    if (oldCode1 != newCode1 || oldCode2 != newCode2 || oldCode3 != newCode3
                        || oldCode4 != newCode4 || oldCode5 != newCode5 || oldCode6 != newCode6)
                    {
                        Rate updateRate = new Rate();

                        resultListUnitPrice = resultList.FindAll(delegate(GoodsRateSetSearchResult target)
                            {
                                if (0 == _targetDivide)
                                {
                                    // FIXME:得意先掛率グループ"指定なし"
                                    if (code < 0)
                                    {
                                        return IsAllCustRateGrpCode(target);
                                    }
                                    else
                                    {
                                        if (target.CustRateGrpCode == code && !IsAllCustRateGrpCode(target))
                                            return (true);
                                        else
                                            return (false);
                                    }
                                }
                                else
                                {
                                    // FIXME:得意先掛率グループ"指定なし"
                                    if (code < 0)
                                    {
                                        return IsAllCustRateGrpCode(target);
                                    }
                                    if (target.CustomerCode == code)
                                        return (true);
                                    else
                                        return (false);
                                }
                            });
                        // データ追加
                        if (null == resultListUnitPrice || resultListUnitPrice.Count == 0
                            || 1 == resultListUnitPrice.Count)
                        {
                            List<Rate> updateRateList = new List<Rate>();
                            updateRateList = CreateRateForUpdate(cells, code, oldValues, newValues, null);
                            saveList.AddRange(updateRateList);
                        }

                        foreach (GoodsRateSetSearchResult result in resultListUnitPrice)
                        {
                            List<Rate> updateRateList = new List<Rate>();
                            updateRateList = CreateRateForUpdate(cells, code, oldValues, newValues, result);

                            saveList.AddRange(updateRateList);
                        }

                    }
                }
            }
        }

        /// <summary>
        /// 得意先掛率グループが"指定なし"のデータであるか判断します。
        /// </summary>
        /// <param name="rateSearchResult">検索したデータ</param>
        /// <returns>
        /// <c>true</c> :得意先掛率グループが"指定なし"のデータです。<br/>
        /// <c>false</c>:得意先掛率グループが"指定なし"のデータではありません。
        /// </returns>
        private static bool IsAllCustRateGrpCode(GoodsRateSetSearchResult rateSearchResult)
        {
            string unitRateSetDivCd = rateSearchResult.UnitRateSetDivCd.Trim();
            return unitRateSetDivCd.Equals("16A") || unitRateSetDivCd.Equals("36A");
        }

        /// <summary>
        /// FIXME:対象とする得意先掛率グループコードに存在するか判断します。
        /// </summary>
        /// <param name="custRateGrpCodeKey"></param>
        /// <returns></returns>
        private bool ExistsCustRateGrpCodeInTargetDic(int custRateGrpCode)
        {
            foreach (int custRateGrpCodeKey in this._targetDic.Keys)
            {
                if (custRateGrpCodeKey.Equals(custRateGrpCode))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 掛率マスタ作成処理
        /// </summary>
        /// <param name="cells">セル</param>
        /// <param name="code">得意先コード・得意先掛率グループコード</param>
        /// <param name="oldValues">変更前のセル値</param>
        /// <param name="newValues">変更後のセル値</param>
        /// <param name="result">GoodsRateSetSearchResult</param>
        /// <returns>掛率マスタ</returns>
        /// <remarks>
        /// <br>Note        : 掛率マスタを新規作成します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private List<Rate> CreateRateForUpdate(CellsCollection cells, int code, double[] oldValues, double[] newValues, GoodsRateSetSearchResult result)
        {
            // 固定値のものだけセット
            List<Rate> updateRateList = new List<Rate>();
            Rate updateRate = new Rate();
            Rate updateRateClone = new Rate();

            // 掛率マスタについてデータがないの場合
            if (null == result)
            {
                Rate deleteRate = null;
                // 変更前：「売価額・売価率・原価UP率・粗利確保率」全て＝0
                // 変更後：「売価額・売価率・原価UP率・粗利確保率」いずれか≠0
                if (!(0 != oldValues[0] || 0 != oldValues[1] || 0 != oldValues[4] || 0 != oldValues[5])
                        && (0 != newValues[0] || 0 != newValues[1] || 0 != newValues[4] || 0 != newValues[5]))
                {
                    // 既存の論理削除のデータがあるか
                    this.HasLogicDelRecord(cells, "1", code, out deleteRate);
                    if (null == deleteRate)
                    {
                        // 単価種類
                        updateRate.UnitPriceKind = "1";
                        CreateRateForUpdateByUnitPrice(cells, code, newValues, ref updateRate);
                        updateRateList.Add(updateRate);
                    }
                    // 既存の論理削除のデータがあるの場合、掛率マスタを復旧する。
                    else
                    {
                        deleteRate.LogicalDeleteCode = 0;

                        // 価格（浮動） 「画面の売価額」
                        deleteRate.PriceFl = newValues[0];
                        // 掛率 「画面の売価率」
                        deleteRate.RateVal = newValues[1];
                        // UP率 「画面の原価UP率」
                        deleteRate.UpRate = newValues[4];
                        // 粗利確保率 「画面の粗利確保率」
                        deleteRate.GrsProfitSecureRate = newValues[5];
                        updateRateList.Add(deleteRate);
                    }
                }
                // 変更前：「ﾕｰｻﾞｰ定価・定価UP率」全て＝0
                // 変更後：「ﾕｰｻﾞｰ定価・定価UP率」いずれか≠0
                if (!(0 != oldValues[2] || 0 != oldValues[3]) && (0 != newValues[2] || 0 != newValues[3]))
                {
                    // 既存の論理削除のデータがあるか
                    this.HasLogicDelRecord(cells, "3", code, out deleteRate);
                    if (null == deleteRate)
                    {
                        // 単価種類
                        updateRateClone = updateRate.Clone();
                        updateRateClone.UnitPriceKind = "3";
                        CreateRateForUpdateByUnitPrice(cells, code, newValues, ref updateRateClone);
                        updateRateList.Add(updateRateClone);
                    }
                    else
                    {
                        deleteRate.LogicalDeleteCode = 0;

                        // 価格（浮動）「画面のユーザー定価」
                        deleteRate.PriceFl = newValues[2];
                        // 掛率 「0」	
                        deleteRate.RateVal = 0;
                        // UP率 「画面の定価UP率」
                        deleteRate.UpRate = newValues[3];
                        // 粗利確保率 「0」	
                        deleteRate.GrsProfitSecureRate = 0;
                        updateRateList.Add(deleteRate);

                    }

                }
            }

            // 掛率マスタについてデータがあるの場合
            if (null != result)
            {
                updateRate = CopyToRateFromRateSearchResult(result);

                if ("1".Equals(result.UnitPriceKind))
                {
                    // 変更前、変更後も：「売価額・売価率・原価UP率・粗利確保率」いずれか≠0
                    if ((0 != oldValues[0] || 0 != oldValues[1] || 0 != oldValues[4] || 0 != oldValues[5]) &&
                        (0 != newValues[0] || 0 != newValues[1] || 0 != newValues[4] || 0 != newValues[5]) &&
                        (oldValues[0] != newValues[0] || oldValues[1] != newValues[1]
                         || oldValues[4] != newValues[4] || oldValues[5] != newValues[5]))
                    {
                        // 価格（浮動） 「画面の売価額」
                        updateRate.PriceFl = newValues[0];
                        // 掛率 「画面の売価率」
                        updateRate.RateVal = newValues[1];
                        // UP率 「画面の原価UP率」
                        updateRate.UpRate = newValues[4];
                        // 粗利確保率 「画面の粗利確保率」
                        updateRate.GrsProfitSecureRate = newValues[5];
                        updateRateList.Add(updateRate);
                    }

                    // 変更前：「売価額・売価率・原価UP率・粗利確保率」いずれか≠0
                    // 変更後：「売価額・売価率・原価UP率・粗利確保率」全て＝0
                    if ((0 != oldValues[0] || 0 != oldValues[1] || 0 != oldValues[4] || 0 != oldValues[5]) &&
                        !(0 != newValues[0] || 0 != newValues[1] || 0 != newValues[4] || 0 != newValues[5]))
                    {
                        updateRate.LogicalDeleteCode = 1;
                        updateRateList.Add(updateRate);
                    }
                }
                else
                {
                    // 変更前、変更後も：「ﾕｰｻﾞｰ定価・定価UP率」いずれか≠0
                    if ((0 != oldValues[2] || 0 != oldValues[3]) &&
                        (0 != newValues[2] || 0 != newValues[3]) &&
                        (oldValues[2] != newValues[2] || oldValues[3] != newValues[3]))
                    {

                        // 価格（浮動）「画面のユーザー定価」
                        updateRate.PriceFl = newValues[2];
                        // 掛率 「0」	
                        updateRate.RateVal = 0;
                        // UP率 「画面の定価UP率」
                        updateRate.UpRate = newValues[3];
                        // 粗利確保率 「0」	
                        updateRate.GrsProfitSecureRate = 0;
                        updateRateList.Add(updateRate);
                    }
                    // 変更前：「ﾕｰｻﾞｰ定価・定価UP率」いずれか≠0
                    // 変更後：「ﾕｰｻﾞｰ定価・定価UP率」全て＝0
                    if ((0 != oldValues[2] || 0 != oldValues[3]) &&
                        !(0 != newValues[2] || 0 != newValues[3]))
                    {
                        updateRate.LogicalDeleteCode = 1;
                        updateRateList.Add(updateRate);
                    }
                }
            }

            return updateRateList;
        }

        /// <summary>
        /// 掛率マスタ作成処理
        /// </summary>
        /// <param name="cells">セル</param>
        /// <param name="code">得意先コード・得意先掛率グループコード</param>
        /// <param name="newValues">変更後のセル値</param>
        /// <param name="result">GoodsRateSetSearchResult</param>
        /// <remarks>
        /// <br>Note        : 掛率マスタを新規作成します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private void CreateRateForUpdateByUnitPrice(CellsCollection cells, int code, double[] newValues, ref Rate updateRate)
        {

            updateRate.EnterpriseCode = this._enterpriseCode;
            // 拠点コード		
            updateRate.SectionCode = this._searchSectionCode;

            // 掛率設定区分（商品）
            updateRate.RateMngGoodsCd = "A";
            // 掛率設定名称（商品）
            updateRate.RateMngGoodsNm = "ﾒｰｶｰ＋品番";
            // 商品メーカーコード
            updateRate.GoodsMakerCd = StrObjToInt(cells[COLUMN_MAKERCODE].Value);
            // 商品番号
            updateRate.GoodsNo = cells[COLUMN_GOODSNO].Value.ToString().Trim();
            // 商品掛率ランク
            updateRate.GoodsRateRank = string.Empty;
            // 商品掛率グループコード
            updateRate.GoodsRateGrpCode = 0;
            // BLグループコード
            updateRate.BLGroupCode = 0;
            // BL商品コード
            updateRate.BLGoodsCode = 0;
            if (0 == _targetDivide)
                if (0 <= code)
                    // 得意先掛率グループコード
                    updateRate.CustRateGrpCode = code;
                else
                    updateRate.CustRateGrpCode = 0;
            else
                // 得意先コード
                updateRate.CustomerCode = code;
            //仕入先コード
            updateRate.SupplierCd = 0;
            // ロット数
            updateRate.LotCount = 9999999.99;

            if ("1".Equals(updateRate.UnitPriceKind))
            {
                if (1 == _targetDivide)
                {
                    // 単価掛率設定区分
                    updateRate.UnitRateSetDivCd = "12A";
                    // 掛率設定区分
                    updateRate.RateSettingDivide = "2A";
                    // 掛率設定区分（得意先）		
                    updateRate.RateMngCustCd = "2";
                    // 掛率設定名称（得意先）		
                    updateRate.RateMngCustNm = "得意先";
                }
                else if (0 == _targetDivide && 0 <= code)
                {
                    // 単価掛率設定区分
                    updateRate.UnitRateSetDivCd = "14A";
                    // 掛率設定区分
                    updateRate.RateSettingDivide = "4A";
                    // 掛率設定区分（得意先）	
                    updateRate.RateMngCustCd = "4";
                    // 掛率設定名称（得意先）		
                    updateRate.RateMngCustNm = "得意先掛率G";
                }
                else if (0 == _targetDivide && 0 > code)
                {
                    // 単価掛率設定区分
                    updateRate.UnitRateSetDivCd = "16A";
                    // 掛率設定区分
                    updateRate.RateSettingDivide = "6A";
                    // 掛率設定区分（得意先）	
                    updateRate.RateMngCustCd = "6";
                    updateRate.RateMngCustNm = "指定なし";

                }
            }
            else if ("3".Equals(updateRate.UnitPriceKind))
            {
                if (1 == _targetDivide)
                {
                    // 単価掛率設定区分
                    updateRate.UnitRateSetDivCd = "32A";
                    // 掛率設定区分
                    updateRate.RateSettingDivide = "2A";
                    // 掛率設定区分（得意先）		
                    updateRate.RateMngCustCd = "2";
                    // 掛率設定名称（得意先）		
                    updateRate.RateMngCustNm = "得意先";
                }
                else if (0 == _targetDivide && 0 <= code)
                {
                    // 単価掛率設定区分
                    updateRate.UnitRateSetDivCd = "34A";
                    // 掛率設定区分
                    updateRate.RateSettingDivide = "4A";
                    // 掛率設定区分（得意先）	
                    updateRate.RateMngCustCd = "4";
                    // 掛率設定名称（得意先）		
                    updateRate.RateMngCustNm = "得意先掛率G";
                }
                else if (0 == _targetDivide && 0 > code)
                {
                    // 単価掛率設定区分
                    updateRate.UnitRateSetDivCd = "36A";
                    // 掛率設定区分
                    updateRate.RateSettingDivide = "6A";
                    // 掛率設定区分（得意先）	
                    updateRate.RateMngCustCd = "6";
                    updateRate.RateMngCustNm = "指定なし";
                }
            }

            if ("1".Equals(updateRate.UnitPriceKind))
            {
                // 価格（浮動） 「画面の売価額」
                updateRate.PriceFl = newValues[0];
                // 掛率 「画面の売価率」
                updateRate.RateVal = newValues[1];
                // UP率 「画面の原価UP率」
                updateRate.UpRate = newValues[4];
                // 粗利確保率 「画面の粗利確保率」
                updateRate.GrsProfitSecureRate = newValues[5];
                // 単価端数処理単位
                updateRate.UnPrcFracProcUnit = 0;
                // 単価端数処理区分
                updateRate.UnPrcFracProcDiv = 0;
            }
            else if ("3".Equals(updateRate.UnitPriceKind))
            {
                // 価格（浮動）「画面のユーザー定価」
                updateRate.PriceFl = newValues[2];
                // 掛率 「0」	
                updateRate.RateVal = 0;
                // UP率 「画面の定価UP率」
                updateRate.UpRate = newValues[3];
                // 粗利確保率 「0」	
                updateRate.GrsProfitSecureRate = 0;
                // 単価端数処理単位
                updateRate.UnPrcFracProcUnit = 1;
                // 単価端数処理区分
                updateRate.UnPrcFracProcDiv = 2;
            }
        }

        /// <summary>
        /// 論理削除のデータを取得する
        /// </summary>
        /// <param name="rateSearchResult">掛率マスタ検索結果</param>
        /// <returns>Key</returns>
        /// <remarks>
        /// <br>Note        : Keyを作成します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private void HasLogicDelRecord(CellsCollection cells, string unitPriceKind, int code, out Rate deleteRate)
        {
            deleteRate = null;
            GoodsRateSetSearchResult deleteResult = _logicDelRateList.Find(delegate(GoodsRateSetSearchResult target)
            {
                if (0 == _targetDivide)
                {
                    if (-1 == code)
                    {
                        if (target.CustRateGrpCode == 0 && target.CustomerCode == 0
                            && target.UnitPriceKind == unitPriceKind
                            && target.GoodsMakerCd == StrObjToInt(cells[COLUMN_MAKERCODE].Value)
                            && target.BLGoodsCode == StrObjToInt(cells[COLUMN_BLCODE].Value)
                            && target.BLGroupCode == StrObjToInt(cells[COLUMN_BLGROUPCODE].Value)
                            && target.GoodsSupplierCd == StrObjToInt(cells[COLUMN_SUPPLIERCODE].Value)
                            && target.GoodsNo == cells[COLUMN_GOODSNO].Value.ToString()
                            && "6A".Equals(target.RateSettingDivide.Trim())) // ADD 2010/08/27
                            return (true);
                        else
                            return (false);
                    }
                    else
                    {
                        if (target.CustRateGrpCode == code && target.UnitPriceKind == unitPriceKind
                            && target.GoodsMakerCd == StrObjToInt(cells[COLUMN_MAKERCODE].Value)
                            && target.BLGoodsCode == StrObjToInt(cells[COLUMN_BLCODE].Value)
                            && target.BLGroupCode == StrObjToInt(cells[COLUMN_BLGROUPCODE].Value)
                            && target.GoodsSupplierCd == StrObjToInt(cells[COLUMN_SUPPLIERCODE].Value)
                            && target.GoodsNo == cells[COLUMN_GOODSNO].Value.ToString())
                            return (true);
                        else
                            return (false);
                    }
                }
                else
                {
                    if (target.CustomerCode == code && target.UnitPriceKind == unitPriceKind
                        && target.GoodsMakerCd == StrObjToInt(cells[COLUMN_MAKERCODE].Value)
                        && target.BLGoodsCode == StrObjToInt(cells[COLUMN_BLCODE].Value)
                        && target.BLGroupCode == StrObjToInt(cells[COLUMN_BLGROUPCODE].Value)
                        && target.GoodsSupplierCd == StrObjToInt(cells[COLUMN_SUPPLIERCODE].Value)
                        && target.GoodsNo == cells[COLUMN_GOODSNO].Value.ToString())
                        return (true);
                    else
                        return (false);
                }
            });
            if (null != deleteResult)
                deleteRate = CopyToRateFromRateSearchResult(deleteResult);
        }

        /// <summary>
        /// クラスメンバコピー処理
        /// </summary>
        /// <param name="result">掛率マスタ検索結果</param>
        /// <returns>掛率マスタ</returns>
        /// <remarks>
        /// <br>Note        : 掛率マスタ検索結果から掛率マスタを作成します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private Rate CopyToRateFromRateSearchResult(GoodsRateSetSearchResult result)
        {
            Rate newRate = new Rate();

            newRate.CreateDateTime = result.CreateDateTime;
            newRate.UpdateDateTime = result.UpdateDateTime;
            newRate.EnterpriseCode = result.EnterpriseCode;
            newRate.FileHeaderGuid = result.FileHeaderGuid;
            newRate.UpdEmployeeCode = result.UpdEmployeeCode;
            newRate.UpdAssemblyId1 = result.UpdAssemblyId1;
            newRate.UpdAssemblyId2 = result.UpdAssemblyId2;
            newRate.LogicalDeleteCode = result.LogicalDeleteCode;
            newRate.SectionCode = result.SectionCode;
            newRate.UnitRateSetDivCd = result.UnitRateSetDivCd;
            newRate.UnitPriceKind = result.UnitPriceKind;
            newRate.RateSettingDivide = result.RateSettingDivide;
            newRate.RateMngGoodsCd = result.RateMngGoodsCd;
            newRate.RateMngGoodsNm = result.RateMngGoodsNm;
            newRate.RateMngCustCd = result.RateMngCustCd;
            newRate.RateMngCustNm = result.RateMngCustNm;
            newRate.GoodsMakerCd = result.GoodsMakerCd;
            newRate.GoodsNo = result.GoodsNo;
            newRate.GoodsRateRank = result.GoodsRateRank;
            newRate.GoodsRateGrpCode = result.GoodsRateGrpCode;
            newRate.BLGroupCode = result.RatebLGroupCode;
            newRate.BLGoodsCode = result.RatebLGoodsCode;
            newRate.CustomerCode = result.CustomerCode;
            newRate.CustRateGrpCode = result.CustRateGrpCode;
            newRate.SupplierCd = result.SupplierCd;
            newRate.LotCount = result.LotCount;
            newRate.PriceFl = result.PriceFl;
            newRate.RateVal = result.RateVal;
            newRate.UpRate = result.UpRate;
            newRate.GrsProfitSecureRate = result.GrsProfitSecureRate;
            newRate.UnPrcFracProcUnit = result.UnPrcFracProcUnit;
            newRate.UnPrcFracProcDiv = result.UnPrcFracProcDiv;

            return newRate;
        }
        #endregion データ取得

        #region チェック処理
        /// <summary>
        /// 検索条件チェック処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : 検索条件をチェックします。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private bool CheckSearchCondition()
        {
            string errMsg = "";

            try
            {
                // 拠点
                if (this.tEdit_SectionCodeAllowZero.DataText.Trim() == "")
                {
                    errMsg = "拠点を入力してください。";
                    this.tEdit_SectionCodeAllowZero.Focus();
                    _guideButton.SharedProps.Enabled = true;
                    return (false);
                }

                string sectionCode = this.tEdit_SectionCodeAllowZero.DataText.Trim();

                if (GetSectionName(sectionCode) == "")
                {
                    errMsg = "マスタに登録されていません。";
                    this.tEdit_SectionCodeAllowZero.Focus();
                    _guideButton.SharedProps.Enabled = true;
                    return (false);
                }


                bool inputFlg = false;

                if ((int)this.tComboEditor_TargetDivide.Value == 0)
                {
                    // 得意先掛率Ｇ
                    for (int index = 0; index < this._tNedit_CustRateGrpCode.Length; index++)
                    {
                        if (this._tNedit_CustRateGrpCode[index].DataText.Trim() != "")
                        {
                            int custRateGrpCode = this._tNedit_CustRateGrpCode[index].GetInt();

                            if (GetCustRateGrpName(custRateGrpCode) == "")
                            {
                                // --- UPD 2010/09/01 ---------------->>>>>
                                //errMsg = "マスタに登録されていません。";
                                errMsg = "得意先掛率グループが存在しません。";
                                // --- UPD 2010/09/01 ----------------<<<<<
                                this._tNedit_CustRateGrpCode[index].Focus();
                                _guideButton.SharedProps.Enabled = true;
                                return (false);
                            }

                            inputFlg = true;
                        }
                    }


                    // 得意先掛率グループの入力が無く、未設定チェックもない場合
                    if (!inputFlg) inputFlg = this.uCheckEditor_unSetting.Checked;
                    if (inputFlg == false)
                    {
                        errMsg = "得意先掛率Ｇを入力してください。";
                        this._tNedit_CustRateGrpCode[0].Focus();
                        _guideButton.SharedProps.Enabled = true;
                        return (false);
                    }
                }
                else
                {
                    // 得意先
                    for (int index = 0; index < this._tNedit_CustomerCode.Length; index++)
                    {
                        if (this._tNedit_CustomerCode[index].GetInt() != 0)
                        {
                            int customerCode = this._tNedit_CustomerCode[index].GetInt();

                            if (!CheckCustomer(customerCode))
                            {
                                // --- UPD 2010/09/01 ---------------->>>>>
                                //errMsg = "マスタに登録されていません。";
                                errMsg = "得意先が存在しません。";
                                // --- UPD 2010/09/01 ----------------<<<<<
                                this._tNedit_CustomerCode[index].Focus();
                                _guideButton.SharedProps.Enabled = true;
                                return (false);
                            }

                            inputFlg = true;
                        }
                    }

                    if (inputFlg == false)
                    {
                        errMsg = "得意先を入力してください。";
                        this._tNedit_CustomerCode[0].Focus();
                        _guideButton.SharedProps.Enabled = true;
                        return (false);
                    }
                }
            }
            finally
            {
                if (errMsg.Length > 0)
                {
                    ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                   errMsg,
                                   0,
                                   MessageBoxButtons.OK,
                                   MessageBoxDefaultButton.Button1);
                }
            }

            return (true);
        }

        /// <summary>
        /// 数値入力チェック処理
        /// </summary>
        /// <param name="keta">桁数(マイナス符号を含まず)</param>
        /// <param name="priod">小数点以下桁数</param>
        /// <param name="prevVal">現在の文字列</param>
        /// <param name="key">入力されたキー値</param>
        /// <param name="selstart">カーソル位置</param>
        /// <param name="sellength">選択文字長</param>
        /// <param name="minusFlg">マイナス入力可？</param>
        /// <returns>true=入力可,false=入力不可</returns>
        /// <remarks>
        /// <br>Note        : 数値の入力チェックを行います。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private bool KeyPressNumCheck(int keta, int priod, string prevVal, char key, int selstart, int sellength, Boolean minusFlg)
        {
            // 制御キーが押された？
            if (Char.IsControl(key))
            {
                return true;
            }
            // 数値以外は、ＮＧ
            if (!Char.IsDigit(key))
            {
                // 小数点または、マイナス以外
                if ((key != '.') && (key != '-'))
                {
                    return false;
                }
            }

            // キーが押されたと仮定した場合の文字列を生成する。
            string strResult = "";
            if (sellength > 0)
            {
                strResult = prevVal.Substring(0, selstart) + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));
            }
            else
            {
                strResult = prevVal;
            }

            // マイナスのチェック
            if (key == '-')
            {
                if ((minusFlg == false) || (selstart > 0) || (strResult.IndexOf('-') != -1))
                {
                    return false;
                }
            }

            // 小数点のチェック
            if (key == '.')
            {
                if ((priod <= 0) || (strResult.IndexOf('.') != -1))
                {
                    return false;
                }
            }
            // キーが押された結果の文字列を生成する。
            strResult = prevVal.Substring(0, selstart)
                + key
                + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));

            // 桁数チェック！
            if (strResult.Length > keta)
            {
                if (strResult[0] == '-')
                {
                    if (strResult.Length > (keta + 1))
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            // 小数点以下のチェック
            if (priod > 0)
            {
                // 小数点の位置決定
                int _pointPos = strResult.IndexOf('.');

                // 整数部に入力可能な桁数を決定！
                int _Rketa = (strResult[0] == '-') ? keta - priod : keta - priod - 1;
                // 整数部の桁数をチェック
                if (_pointPos != -1)
                {
                    if (_pointPos > _Rketa)
                    {
                        return false;
                    }
                }
                else
                {
                    if (strResult.Length > _Rketa)
                    {
                        return false;
                    }
                }

                // 小数部の桁数をチェック
                if (_pointPos != -1)
                {
                    // 小数部の桁数を計算
                    int _priketa = strResult.Length - _pointPos - 1;
                    if (priod < _priketa)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 数値入力チェック処理2
        /// </summary>
        /// <param name="keta">桁数(マイナス符号を含まず)</param>
        /// <param name="priod">小数点以下桁数</param>
        /// <param name="prevVal">現在の文字列</param>
        /// <param name="key">入力されたキー値</param>
        /// <param name="selstart">カーソル位置</param>
        /// <param name="sellength">選択文字長</param>
        /// <param name="minusFlg">マイナス入力可？</param>
        /// <returns>true=入力可,false=入力不可</returns>
        /// <remarks>
        /// <br>Note        : 数値の入力チェックを行います。</br>
        /// <br>Programmer  : 朱猛</br>
        /// <br>Date        : 2010/08/31</br>
        /// </remarks>
        private bool KeyPressNumCheck2(int keta, int priod, string prevVal, char key, int selstart, int sellength, Boolean minusFlg)
        {
            // 制御キーが押された？
            if (Char.IsControl(key))
            {
                return true;
            }
            // 数値以外は、ＮＧ
            if (!Char.IsDigit(key))
            {
                // 小数点または、マイナス以外
                if ((key != '.') && (key != '-'))
                {
                    return false;
                }
            }

            // キーが押されたと仮定した場合の文字列を生成する。
            string strResult = "";
            if (sellength > 0)
            {
                strResult = prevVal.Substring(0, selstart) + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));
            }
            else
            {
                strResult = prevVal;
            }

            // マイナスのチェック
            if (key == '-')
            {
                return false;
            }

            // 小数点のチェック
            if (key == '.')
            {
                return false;
            }
            // キーが押された結果の文字列を生成する。
            strResult = prevVal.Substring(0, selstart)
                + key
                + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));

            // 桁数チェック！
            if (strResult.Length > keta)
            {
                if (strResult[0] == '-')
                {
                    if (strResult.Length > (keta + 1))
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            // 小数点以下のチェック
            if (priod > 0)
            {
                // 小数点の位置決定
                int _pointPos = strResult.IndexOf('.');

                // 整数部に入力可能な桁数を決定！
                int _Rketa = (strResult[0] == '-') ? keta - priod : keta - priod - 1;
                // 整数部の桁数をチェック
                if (_pointPos != -1)
                {
                    if (_pointPos > _Rketa)
                    {
                        return false;
                    }
                }
                else
                {
                    if (strResult.Length > _Rketa)
                    {
                        return false;
                    }
                }

                // 小数部の桁数をチェック
                if (_pointPos != -1)
                {
                    // 小数部の桁数を計算
                    int _priketa = strResult.Length - _pointPos - 1;
                    if (priod < _priketa)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 画面情報比較処理
        /// </summary>
        /// <returns>ステータス(True:処理続行　False:処理中断)</returns>
        /// <remarks>
        /// <br>Note        : 画面情報を比較し、変更されている場合はメッセージを表示します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        public bool CompareScreen()
        {
            if (this._closeFlg)
            {
                return (true);
            }

            // 画面情報比較
            if (!CompareOriginalScreen())
            {
                DialogResult res = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                                                  "",
                                                  0,
                                                  MessageBoxButtons.YesNoCancel,
                                                  MessageBoxDefaultButton.Button1);

                switch (res)
                {
                    case DialogResult.Yes:
                        {
                            // 保存処理
                            int status = Save();
                            if (status != 0)
                            {
                                return (false);
                            }
                            break;
                        }
                    case DialogResult.No:
                        {
                            break;
                        }
                    case DialogResult.Cancel:
                        {
                            return (false);
                        }
                }
            }

            return (true);
        }

        /// <summary>
        /// 画面情報比較処理
        /// </summary>
        /// <returns>ステータス(True:変更なし　False:変更あり)</returns>
        /// <remarks>
        /// <br>Note        : 画面情報を比較し、変更されている場合はメッセージを表示します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private bool CompareOriginalScreen()
        {
            if (this.uGrid_Details.Rows.Count > 0)
            {
                return (false);
            }

            return (true);
        }

        #endregion チェック処理

        #region グリッド設定
        /// <summary>
        /// グリッド作成処理
        /// </summary>
        /// <param name="uGrid">グリッド</param>
        /// <param name="displayList">表示データリスト</param>
        /// <remarks>
        /// <br>Note        : グリッドの列を作成します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        public void CreateGrid(ref UltraGrid uGrid)
        {
            DataTable dataTable = new DataTable();

            // No
            dataTable.Columns.Add(COLUMN_NO, typeof(int));
            // 品番
            dataTable.Columns.Add(COLUMN_GOODSNO, typeof(string));
            // 品名
            dataTable.Columns.Add(COLUMN_GOODSNAME, typeof(string));
            // メーカーコード
            dataTable.Columns.Add(COLUMN_MAKERCODE, typeof(string));
            // ＢＬコード
            dataTable.Columns.Add(COLUMN_BLCODE, typeof(string));
            // グループコード
            dataTable.Columns.Add(COLUMN_BLGROUPCODE, typeof(string));
            // 仕入先
            dataTable.Columns.Add(COLUMN_SUPPLIERCODE, typeof(string));
            // 標準価格
            dataTable.Columns.Add(COLUMN_PRICEFL, typeof(double));
            // 仕入原価
            dataTable.Columns.Add(COLUMN_SUPPLIERPRICE, typeof(double));

            // 売価率
            if ((this._displayList == null) || (this._displayList.Count == 0))
            {
                dataTable.Columns.Add(COLUMN_SALERATE1, typeof(double));
                dataTable.Columns.Add(COLUMN_SALERATE2, typeof(double));
                dataTable.Columns.Add(COLUMN_SALERATE3, typeof(double));
                dataTable.Columns.Add(COLUMN_SALERATE4, typeof(double));
                dataTable.Columns.Add(COLUMN_SALERATE5, typeof(double));
                dataTable.Columns.Add(COLUMN_SALERATE6, typeof(double));
                dataTable.Columns.Add(COLUMN_SALERATE7, typeof(double));
                dataTable.Columns.Add(COLUMN_SALERATE8, typeof(double));
                dataTable.Columns.Add(COLUMN_SALERATE9, typeof(double));
                dataTable.Columns.Add(COLUMN_SALERATE10, typeof(double));
                dataTable.Columns.Add(COLUMN_SALERATE11, typeof(double));
                dataTable.Columns.Add(COLUMN_SALERATE12, typeof(double));
                dataTable.Columns.Add(COLUMN_SALERATE13, typeof(double));
                dataTable.Columns.Add(COLUMN_SALERATE14, typeof(double));
                dataTable.Columns.Add(COLUMN_SALERATE15, typeof(double));
                dataTable.Columns.Add(COLUMN_SALERATE16, typeof(double));
                dataTable.Columns.Add(COLUMN_SALERATE17, typeof(double));
                dataTable.Columns.Add(COLUMN_SALERATE18, typeof(double));
                dataTable.Columns.Add(COLUMN_SALERATE19, typeof(double));
                dataTable.Columns.Add(COLUMN_SALERATE20, typeof(double));
                dataTable.Columns.Add(COLUMN_SALERATE21, typeof(double));
            }
            else
            {
                foreach (int key in this._targetDic.Keys)
                {
                    dataTable.Columns.Add(key.ToString() + "title1", typeof(double));
                    dataTable.Columns.Add(key.ToString() + "title2", typeof(double));
                    dataTable.Columns.Add(key.ToString() + "title3", typeof(double));
                    dataTable.Columns.Add(key.ToString() + "title4", typeof(double));
                    dataTable.Columns.Add(key.ToString() + "title5", typeof(double));
                    dataTable.Columns.Add(key.ToString() + "title6", typeof(double));
                }
            }

            uGrid.DataSource = dataTable;

            // グリッドスタイル設定
            SetGridLayout(ref uGrid);

            // データが無い場合
            if ((this._displayList == null) || (this._displayList.Count == 0))
            {
                return;
            }
            dataTable.AcceptChanges();

            List<GoodsRateSetSearchResult> targetList;

            this.uGrid_Details.BeginUpdate();

            try
            {
                _dataTableClone = dataTable.Copy();

                //-----------ADD BY 凌小青 on 2011/11/02 for Redmine#26319--------------->>>>>>>>>>
                int tempCount = this._displayList.Count;
                bool flag = false;
                for (int index = 0; index < tempCount; index++)
                {
                    for (int i = 0; i < tempCount - 1; i++)
                    {
                        if (this._displayList.Count == index + 1 || this._displayList.Count == index)
                        {
                            flag = true;
                            break;
                        }
                        GoodsRateSetSearchResult result1 = (GoodsRateSetSearchResult)this._displayList[index];
                        GoodsRateSetSearchResult result2 = (GoodsRateSetSearchResult)this._displayList[index + 1];
                        //if (result1.GoodsNo.Equals(result2.GoodsNo)) DEL BY gaocheng on 2014/09/02 for Redmine#43368
                        if (result1.GoodsNo.Equals(result2.GoodsNo) && result1.GoodsMakerCd.Equals(result2.GoodsMakerCd)) // ADD BY gaocheng on 2014/09/02 for Redmine#43368
                        {
                            this._displayList.Remove(this._displayList[index]);
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (flag)
                    {
                        break;
                    }
                }
                //-----------ADD BY 凌小青 on 2011/11/02 for Redmine#26319---------------<<<<<<<<<<<<
                for (int index = 0; index < this._displayList.Count; index++)
                {
                    // 行追加
                    DataRow row = _dataTableClone.NewRow();
                    uGrid.DisplayLayout.Bands[0].AddNew();

                    CellsCollection cells = uGrid.Rows[index].Cells;

                    GoodsRateSetSearchResult result = (GoodsRateSetSearchResult)this._displayList[index];

                    // No
                    cells[COLUMN_NO].Value = index + 1;
                    row[COLUMN_NO] = index + 1;

                    // 品番
                    cells[COLUMN_GOODSNO].Value = result.GoodsNo;
                    row[COLUMN_GOODSNO] = result.GoodsNo;
                    // 品名
                    cells[COLUMN_GOODSNAME].Value = result.BLGoodsHalfName;
                    row[COLUMN_GOODSNAME] = result.BLGoodsHalfName;
                    // メーカー
                    cells[COLUMN_MAKERCODE].Value = result.GoodsMakerCd.ToString("0000");
                    row[COLUMN_MAKERCODE] = result.GoodsMakerCd.ToString("0000");
                    // BLコード
                    cells[COLUMN_BLCODE].Value = result.BLGoodsCode.ToString("00000");
                    row[COLUMN_BLCODE] = result.BLGoodsCode.ToString("00000");
                    // グループコード
                    cells[COLUMN_BLGROUPCODE].Value = result.BLGroupCode.ToString("00000");
                    row[COLUMN_BLGROUPCODE] = result.BLGroupCode.ToString("00000");
                    // 仕入先
                    cells[COLUMN_SUPPLIERCODE].Value = result.GoodsSupplierCd.ToString("000000");
                    row[COLUMN_SUPPLIERCODE] = result.GoodsSupplierCd.ToString("000000");
                    // 標準価格
                    cells[COLUMN_PRICEFL].Value = result.ListPrice.ToString(FORMAT);
                    row[COLUMN_PRICEFL] = result.ListPrice.ToString(FORMAT);
                    // 仕入原価
                    cells[COLUMN_SUPPLIERPRICE].Value = result.SalesUnitCost.ToString(FORMAT);
                    row[COLUMN_SUPPLIERPRICE] = result.SalesUnitCost.ToString(FORMAT);


                    targetList = this._ratedisplayList.FindAll(delegate(GoodsRateSetSearchResult target)
                    {
                        if (MakeKey(result.GoodsMakerCd, result.BLGoodsCode, result.BLGroupCode, result.GoodsSupplierCd, result.GoodsNo).Equals(
                            MakeKey(target.GoodsMakerCd, target.BLGoodsCode, target.BLGroupCode, target.GoodsSupplierCd, target.GoodsNo)))
                        {
                            return (true);
                        }
                        else
                        {
                            return (false);
                        }
                    });

                    // 単価種類によって、リストを作成する
                    if (0 == _targetDivide)
                    {
                        targetList.Sort(delegate(GoodsRateSetSearchResult x, GoodsRateSetSearchResult y)
                            {
                                int compare = x.CustRateGrpCode - y.CustRateGrpCode;
                                if (compare == 0) compare = x.UnitPriceKind.CompareTo(y.UnitPriceKind);
                                return compare;
                            });
                    }
                    else
                    {
                        targetList.Sort(delegate(GoodsRateSetSearchResult x, GoodsRateSetSearchResult y)
                            {
                                int compare = x.CustomerCode - y.CustomerCode;
                                if (compare == 0) compare = x.UnitPriceKind.CompareTo(y.UnitPriceKind);
                                return compare;
                            });
 
                    }

                    // 同じキー（品番＋メーカーコード＋BLコード + グループコード + 仕入先コード +  得意先コード/得意先掛率グループコード）
                    // の場合、違い単価種類によって、レコードを別々で設定する
                    for (int columnIndex = 0; columnIndex < targetList.Count; columnIndex++)
                    {
                        GoodsRateSetSearchResult rate = (GoodsRateSetSearchResult)targetList[columnIndex];
                        SetCellRateVal(ref cells, rate, ref row, index);
                    }

                    _dataTableClone.Rows.Add(row);
                }
            }
            finally
            {
                this.uGrid_Details.EndUpdate();
            }
        }

        /// <summary>
        /// 掛率マスタについてのセルの設定
        /// </summary>
        /// <remarks>
        /// <br>Note        : 掛率マスタについてのセルの設定を行う</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private void SetCellRateVal(ref CellsCollection cells, GoodsRateSetSearchResult rate, ref DataRow row, int index)
        {
            // 単価種類
            string unitPriceKindCode = rate.UnitPriceKind;
            // 掛率設定区分
            string rateSettingDivide = rate.RateSettingDivide;

            if (0 == _targetDivide)
            {
                switch (unitPriceKindCode)
                {
                    // 売価設定
                    case "1":

                        // 売価率
                        if (rate.RateVal != 0)
                        {
                            // ALL column
                            if (IsAllCustRateGrpCode(rate))
                            {
                                if (ExistsCustRateGrpCodeInTargetDic(ALL_CUST_RATE_GRP_CODE))
                                {
                                    cells[ALL_CUST_RATE_GRP_CODE.ToString() + "title2"].Value = rate.RateVal.ToString(FORMAT);
                                    row[ALL_CUST_RATE_GRP_CODE.ToString() + "title2"] = rate.RateVal.ToString(FORMAT);
                                }
                            }
                            else
                            {
                                if (ExistsCustRateGrpCodeInTargetDic(rate.CustRateGrpCode))
                                {
                                    cells[rate.CustRateGrpCode.ToString() + "title2"].Value = rate.RateVal.ToString(FORMAT);
                                    row[rate.CustRateGrpCode.ToString() + "title2"] = rate.RateVal.ToString(FORMAT);
                                }
                            }
                        }

                        // 売価額
                        if (RateAcs.IsGoodsNoSetting(rateSettingDivide))
                        {
                            // 単品設定のときのみ設定
                            if (rate.PriceFl != 0)
                            {
                                // ALL column
                                if (IsAllCustRateGrpCode(rate))
                                {
                                    if (ExistsCustRateGrpCodeInTargetDic(ALL_CUST_RATE_GRP_CODE))
                                    {
                                        cells[ALL_CUST_RATE_GRP_CODE + "title1"].Value = rate.PriceFl.ToString(FORMAT);
                                        row[ALL_CUST_RATE_GRP_CODE + "title1"] = rate.PriceFl.ToString(FORMAT);
                                    }
                                }
                                else
                                {
                                    if (ExistsCustRateGrpCodeInTargetDic(rate.CustRateGrpCode))
                                    {
                                        cells[rate.CustRateGrpCode.ToString() + "title1"].Value = rate.PriceFl.ToString(FORMAT);
                                        row[rate.CustRateGrpCode.ToString() + "title1"] = rate.PriceFl.ToString(FORMAT);
                                    }
                                }
                            }
                        }

                        string cellStr = null;
                        if (IsAllCustRateGrpCode(rate))
                        {
                            if (ExistsCustRateGrpCodeInTargetDic(ALL_CUST_RATE_GRP_CODE))
                            {
                                cellStr = ALL_CUST_RATE_GRP_CODE.ToString();
                            }
                        }
                        else
                        {

                            if (ExistsCustRateGrpCodeInTargetDic(rate.CustRateGrpCode))
                            {
                                cellStr = rate.CustRateGrpCode.ToString();
                            }

                        }

                        if (!string.IsNullOrEmpty(cellStr))
                        {
                            // 売価額
                            double sellPrice = DoubleObjToDouble(cells[cellStr + "title1"].Value);
                            // 売価率
                            double sellRate = DoubleObjToDouble(cells[cellStr + "title2"].Value);
                            // 検索した掛率マスタが「売価額」≠0の場合、「売価額」又は「売価率」項目の背景色を「薄紫」へ変更する。
                            if (0 != sellPrice)
                            {
                                // --- UPD 2010/08/27 ---------->>>>>
                                //cells[cellStr + "title1"].Appearance.BackColor = Color.MediumPurple;
                                //cells[cellStr + "title2"].Appearance.BackColor = Color.MediumPurple;
                                cells[cellStr + "title1"].Appearance.BackColor = Color.Pink;
                                cells[cellStr + "title2"].Appearance.BackColor = Color.Pink;
                                // --- UPD 2010/08/27 ----------<<<<<
                            }
                            // 検索した掛率マスタが「売価額」＝0で且つ「売価率」≠0の場合、「売価額」又は「売価率」項目の背景色を「薄緑」へ変更する。
                            else if (0 == sellPrice && 0 != sellRate)
                            {
                                cells[cellStr + "title1"].Appearance.BackColor = Color.PaleGreen;
                                cells[cellStr + "title2"].Appearance.BackColor = Color.PaleGreen;
                            }
                            else
                            {
                                if (0 == index % 2)
                                {
                                    cells[cellStr + "title1"].Appearance.BackColor = Color.White;
                                    cells[cellStr + "title2"].Appearance.BackColor = Color.White;
                                }
                                else
                                {
                                    cells[cellStr + "title1"].Appearance.BackColor = Color.Lavender;
                                    cells[cellStr + "title2"].Appearance.BackColor = Color.Lavender;
                                }
                            }
                        }

                        // 原価ＵＰ率
                        if (rate.UpRate != 0)
                        {
                            // ALL column
                            if (IsAllCustRateGrpCode(rate))
                            {
                                if (ExistsCustRateGrpCodeInTargetDic(ALL_CUST_RATE_GRP_CODE))
                                {
                                    cells[ALL_CUST_RATE_GRP_CODE.ToString() + "title5"].Value = rate.UpRate.ToString(FORMAT);
                                    row[ALL_CUST_RATE_GRP_CODE.ToString() + "title5"] = rate.UpRate.ToString(FORMAT);
                                }
                            }
                            else
                            {
                                if (ExistsCustRateGrpCodeInTargetDic(rate.CustRateGrpCode))
                                {
                                    cells[rate.CustRateGrpCode.ToString() + "title5"].Value = rate.UpRate.ToString(FORMAT);
                                    row[rate.CustRateGrpCode.ToString() + "title5"] = rate.UpRate.ToString(FORMAT);
                                }
                            }
                        }

                        // 粗利確保率
                        if (rate.GrsProfitSecureRate != 0)
                        {
                            // ALL column
                            if (IsAllCustRateGrpCode(rate))
                            {
                                if (ExistsCustRateGrpCodeInTargetDic(ALL_CUST_RATE_GRP_CODE))
                                {
                                    cells[ALL_CUST_RATE_GRP_CODE.ToString() + "title6"].Value = rate.GrsProfitSecureRate.ToString(FORMAT);
                                    row[ALL_CUST_RATE_GRP_CODE.ToString() + "title6"] = rate.GrsProfitSecureRate.ToString(FORMAT);
                                }
                            }
                            else
                            {
                                if (ExistsCustRateGrpCodeInTargetDic(rate.CustRateGrpCode))
                                {
                                    cells[rate.CustRateGrpCode.ToString() + "title6"].Value = rate.GrsProfitSecureRate.ToString(FORMAT);
                                    row[rate.CustRateGrpCode.ToString() + "title6"] = rate.GrsProfitSecureRate.ToString(FORMAT);
                                }
                            }
                        }
                        break;
                    // 価格設定
                    case "3":

                        // 価格ＵＰ率
                        if (rate.UpRate != 0)
                        {
                            // ALL column
                            if (IsAllCustRateGrpCode(rate))
                            {
                                if (ExistsCustRateGrpCodeInTargetDic(ALL_CUST_RATE_GRP_CODE))
                                {
                                    cells[ALL_CUST_RATE_GRP_CODE.ToString() + "title4"].Value = rate.UpRate.ToString(FORMAT);
                                    row[ALL_CUST_RATE_GRP_CODE.ToString() + "title4"] = rate.UpRate.ToString(FORMAT);
                                }
                            }
                            else
                            {
                                if (ExistsCustRateGrpCodeInTargetDic(rate.CustRateGrpCode))
                                {
                                    cells[rate.CustRateGrpCode.ToString() + "title4"].Value = rate.UpRate.ToString(FORMAT);
                                    row[rate.CustRateGrpCode.ToString() + "title4"] = rate.UpRate.ToString(FORMAT);
                                }
                            }
                        }

                        // ユーザー価格
                        if (RateAcs.IsGoodsNoSetting(rateSettingDivide))
                        {
                            // 単品設定のときのみ設定
                            if (rate.PriceFl != 0)
                            {
                                // ALL column
                                if (IsAllCustRateGrpCode(rate))
                                {
                                    if (ExistsCustRateGrpCodeInTargetDic(ALL_CUST_RATE_GRP_CODE))
                                    {
                                        cells[ALL_CUST_RATE_GRP_CODE.ToString() + "title3"].Value = rate.PriceFl.ToString(FORMAT_NUM);
                                        row[ALL_CUST_RATE_GRP_CODE.ToString() + "title3"] = rate.PriceFl.ToString(FORMAT_NUM);
                                    }
                                }
                                else
                                {
                                    if (ExistsCustRateGrpCodeInTargetDic(rate.CustRateGrpCode))
                                    {
                                        cells[rate.CustRateGrpCode.ToString() + "title3"].Value = rate.PriceFl.ToString(FORMAT_NUM);
                                        row[rate.CustRateGrpCode.ToString() + "title3"] = rate.PriceFl.ToString(FORMAT_NUM);
                                    }
                                }
                            }
                        }
                        break;
                }
            }
            else
            {
                if (this._targetDic.ContainsKey(rate.CustomerCode))
                {
                    switch (unitPriceKindCode)
                    {
                        // 売価設定
                        case "1":

                            // 売価率
                            if (rate.RateVal != 0)
                            {
                                cells[rate.CustomerCode.ToString() + "title2"].Value = rate.RateVal.ToString(FORMAT);
                                row[rate.CustomerCode.ToString() + "title2"] = rate.RateVal.ToString(FORMAT);

                            }

                            // 売価額
                            if (RateAcs.IsGoodsNoSetting(rateSettingDivide))
                            {
                                // 単品設定のときのみ設定
                                if (rate.PriceFl != 0)
                                {
                                    cells[rate.CustomerCode.ToString() + "title1"].Value = rate.PriceFl.ToString(FORMAT);
                                    row[rate.CustomerCode.ToString() + "title1"] = rate.PriceFl.ToString(FORMAT);
                                }
                            }

                            // 売価額
                            double sellPrice = DoubleObjToDouble(cells[rate.CustomerCode.ToString() + "title1"].Value);
                            // 売価率
                            double sellRate = DoubleObjToDouble(cells[rate.CustomerCode.ToString() + "title2"].Value);
                            // 検索した掛率マスタが「売価額」≠0の場合、「売価額」又は「売価率」項目の背景色を「薄紫」へ変更する。
                            if (0 != sellPrice)
                            {
                                // --- UPD 2010/08/27 ---------->>>>>
                                //cells[rate.CustomerCode.ToString() + "title1"].Appearance.BackColor = Color.MediumPurple;
                                //cells[rate.CustomerCode.ToString() + "title2"].Appearance.BackColor = Color.MediumPurple;
                                cells[rate.CustomerCode.ToString() + "title1"].Appearance.BackColor = Color.Pink;
                                cells[rate.CustomerCode.ToString() + "title2"].Appearance.BackColor = Color.Pink;
                                // --- UPD 2010/08/27 ---------->>>>>
                            }
                            // 検索した掛率マスタが「売価額」＝0で且つ「売価率」≠0の場合、「売価額」又は「売価率」項目の背景色を「薄緑」へ変更する。
                            else if (0 == sellPrice && 0 != sellRate)
                            {
                                cells[rate.CustomerCode.ToString() + "title1"].Appearance.BackColor = Color.PaleGreen;
                                cells[rate.CustomerCode.ToString() + "title2"].Appearance.BackColor = Color.PaleGreen;
                            }
                            else
                            {
                                if (0 == index % 2)
                                {
                                    cells[rate.CustomerCode.ToString() + "title1"].Appearance.BackColor = Color.White;
                                    cells[rate.CustomerCode.ToString() + "title2"].Appearance.BackColor = Color.White;
                                }
                                else
                                {
                                    cells[rate.CustomerCode.ToString() + "title1"].Appearance.BackColor = Color.Lavender;
                                    cells[rate.CustomerCode.ToString() + "title2"].Appearance.BackColor = Color.Lavender;
                                }
                            }

                            // 原価ＵＰ率
                            if (rate.UpRate != 0)
                            {
                                cells[rate.CustomerCode.ToString() + "title5"].Value = rate.UpRate.ToString(FORMAT);
                                row[rate.CustomerCode.ToString() + "title5"] = rate.UpRate.ToString(FORMAT);
                            }

                            // 粗利確保率
                            if (rate.GrsProfitSecureRate != 0)
                            {
                                cells[rate.CustomerCode.ToString() + "title6"].Value = rate.GrsProfitSecureRate.ToString(FORMAT);
                                row[rate.CustomerCode.ToString() + "title6"] = rate.GrsProfitSecureRate.ToString(FORMAT);
                            }
                            break;
                        // 価格設定
                        case "3":

                            // 価格ＵＰ率
                            if (rate.UpRate != 0)
                            {
                                cells[rate.CustomerCode.ToString() + "title4"].Value = rate.UpRate.ToString(FORMAT);
                                row[rate.CustomerCode.ToString() + "title4"] = rate.UpRate.ToString(FORMAT);
                            }

                            // ユーザー価格
                            if (RateAcs.IsGoodsNoSetting(rateSettingDivide))
                            {
                                // 単品設定のときのみ設定
                                if (rate.PriceFl != 0)
                                {
                                    cells[rate.CustomerCode.ToString() + "title3"].Value = rate.PriceFl.ToString(FORMAT_NUM);
                                    row[rate.CustomerCode.ToString() + "title3"] = rate.PriceFl.ToString(FORMAT_NUM);
                                }
                            }
                            break;
                    }
                }

            }
        }   

        /// <summary>
        /// グリッドスタイル設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : グリッドのスタイルを設定します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private void SetGridLayout(ref UltraGrid uGrid)
        {
            try
            {
                uGrid.BeginUpdate();

                ColumnsCollection columns = uGrid.DisplayLayout.Bands[0].Columns;

                // セルスタイル
                for (int index = 0; index < columns.Count; index++)
                {
                    columns[index].CellAppearance.BackColorDisabled = Color.White;
                    columns[index].CellAppearance.BackColorDisabled2 = Color.White;
                }
                uGrid.DisplayLayout.Override.AllowColSizing = Infragistics.Win.UltraWinGrid.AllowColSizing.Free; // ADD 2010/08/27

                // No
                columns[COLUMN_NO].Header.Caption = "No.";
                columns[COLUMN_NO].Header.Fixed = true;
                columns[COLUMN_NO].CellAppearance.BackColor = Color.FromArgb(89, 135, 214);
                columns[COLUMN_NO].CellAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
                columns[COLUMN_NO].CellAppearance.BackColorDisabled = Color.FromArgb(89, 135, 214);
                columns[COLUMN_NO].CellAppearance.BackColorDisabled2 = Color.FromArgb(7, 59, 150);
                columns[COLUMN_NO].CellAppearance.BackGradientStyle = GradientStyle.Vertical;
                columns[COLUMN_NO].CellAppearance.ForeColor = Color.White;
                columns[COLUMN_NO].CellAppearance.ForeColorDisabled = Color.White;
                columns[COLUMN_NO].CellAppearance.TextHAlign = HAlign.Right;
                columns[COLUMN_NO].CellActivation = Activation.Disabled;

                // 品番
                columns[COLUMN_GOODSNO].Header.Caption = "品番";
                columns[COLUMN_GOODSNO].Header.Fixed = true;
                columns[COLUMN_GOODSNO].CellAppearance.TextHAlign = HAlign.Left;
                columns[COLUMN_GOODSNO].CellActivation = Activation.NoEdit;

                // 品名
                columns[COLUMN_GOODSNAME].Header.Caption = "品名";
                //columns[COLUMN_GOODSNAME].Header.Fixed = true; // DEL 2010/08/27
                columns[COLUMN_GOODSNAME].CellAppearance.TextHAlign = HAlign.Left;
                columns[COLUMN_GOODSNAME].CellActivation = Activation.NoEdit;

                // メーカーコード
                columns[COLUMN_MAKERCODE].Header.Caption = "ﾒｰｶｰ";
                //columns[COLUMN_MAKERCODE].Header.Fixed = true; // DEL 2010/08/27
                columns[COLUMN_MAKERCODE].CellAppearance.TextHAlign = HAlign.Right;
                columns[COLUMN_MAKERCODE].CellActivation = Activation.NoEdit;

                // ＢＬコード
                columns[COLUMN_BLCODE].Header.Caption = "BLｺｰﾄﾞ";
                //columns[COLUMN_BLCODE].Header.Fixed = true; // DEL 2010/08/27
                columns[COLUMN_BLCODE].CellAppearance.TextHAlign = HAlign.Right;
                columns[COLUMN_BLCODE].CellActivation = Activation.NoEdit;

                // グループコード
                columns[COLUMN_BLGROUPCODE].Header.Caption = "ｸﾞﾙｰﾌﾟｺｰﾄﾞ";
                //columns[COLUMN_BLGROUPCODE].Header.Fixed = true; // DEL 2010/08/27
                columns[COLUMN_BLGROUPCODE].CellAppearance.TextHAlign = HAlign.Right;
                columns[COLUMN_BLGROUPCODE].CellActivation = Activation.NoEdit;

                // 仕入先
                columns[COLUMN_SUPPLIERCODE].Header.Caption = "仕入先";
                //columns[COLUMN_SUPPLIERCODE].Header.Fixed = true; // DEL 2010/08/27
                columns[COLUMN_SUPPLIERCODE].CellAppearance.TextHAlign = HAlign.Right;
                columns[COLUMN_SUPPLIERCODE].CellActivation = Activation.NoEdit;

                // 標準価格
                columns[COLUMN_PRICEFL].Header.Caption = "標準価格";
                //columns[COLUMN_PRICEFL].Header.Fixed = true; // DEL 2010/08/27
                columns[COLUMN_PRICEFL].Format = FORMAT;
                columns[COLUMN_PRICEFL].CellAppearance.TextHAlign = HAlign.Right;
                columns[COLUMN_PRICEFL].CellActivation = Activation.NoEdit;

                // 仕入原価
                columns[COLUMN_SUPPLIERPRICE].Header.Caption = "仕入原価";
                //columns[COLUMN_SUPPLIERPRICE].Header.Fixed = true; // DEL 2010/08/27
                columns[COLUMN_SUPPLIERPRICE].Format = FORMAT;
                columns[COLUMN_SUPPLIERPRICE].CellAppearance.TextHAlign = HAlign.Right;
                columns[COLUMN_SUPPLIERPRICE].CellActivation = Activation.NoEdit;


                // 売価率
                if ((this._displayList == null) || (this._displayList.Count == 0))
                {
                    for (int index = _startIndex; index <= COLINDEX_SALERATE_ED; index++)
                    {
                        columns[index].Header.Caption = "";
                        columns[index].Format = FORMAT;
                        columns[index].CellAppearance.TextHAlign = HAlign.Right;
                        columns[index].CellActivation = Activation.AllowEdit;
                    }
                }
                else
                {
                    for (int i = 1; i < 7; i++)
                    {
                        foreach (int key in this._targetDic.Keys)
                        {
                            if (this._targetDivide == 0)
                            {
                                columns[key.ToString() + "title" + i].Header.Caption = ((int)this._targetDic[key]).ToString("0000");
                                if (((int)this._targetDic[key]) < 0) 
                                    columns[key.ToString() + "title" + i].Header.Caption = "ALL";
                            }
                            else
                            {
                                columns[key.ToString() + "title" + i].Header.Caption = ((int)this._targetDic[key]).ToString("00000000");
                            }
                            columns[key.ToString() + "title" + i].Format = FORMAT;
                            columns[key.ToString() + "title" + i].CellAppearance.TextHAlign = HAlign.Right;
                            columns[key.ToString() + "title" + i].CellActivation = Activation.AllowEdit;
                            columns[key.ToString() + "title" + i].Hidden = true;

                            if (DETAIL_TITLE_1.Equals(uLabel_SaleRate.Text))
                                columns[key.ToString() + "title1"].Hidden = false;
                            else if (DETAIL_TITLE_2.Equals(uLabel_SaleRate.Text))
                                columns[key.ToString() + "title2"].Hidden = false;
                            else if (DETAIL_TITLE_3.Equals(uLabel_SaleRate.Text))
                            {
                                columns[key.ToString() + "title3"].Hidden = false;
                                // --- ADD 2010/08/31 ---------------------------------->>>>>
                                columns[key.ToString() + "title3"].Format = FORMAT_NUM;
                                // --- ADD 2010/08/31 ----------------------------------<<<<<
                            }
                            else if (DETAIL_TITLE_4.Equals(uLabel_SaleRate.Text))
                                columns[key.ToString() + "title4"].Hidden = false;
                            else if (DETAIL_TITLE_5.Equals(uLabel_SaleRate.Text))
                                columns[key.ToString() + "title5"].Hidden = false;
                            else if (DETAIL_TITLE_6.Equals(uLabel_SaleRate.Text))
                                columns[key.ToString() + "title6"].Hidden = false;
                        }
                    }

                }

                // --- DEL 2010/08/27 ---------->>>>>
                //// グリッド列幅設定
                //SetColumnWidth(ref uGrid);
                // --- DEL 2010/08/27 ----------<<<<<
            }
            finally
            {
                uGrid.EndUpdate();
            }
        }

        /// <summary>
        /// グリッド列幅設定処理
        /// </summary>
        /// <param name="uGrid">グリッド</param>
        /// <remarks>
        /// <br>Note        : グリッドの列幅を設定します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private void SetColumnWidth(ref UltraGrid uGrid)
        {
            ColumnsCollection columns = uGrid.DisplayLayout.Bands[0].Columns;

            // No
            columns[COLUMN_NO].Width = 45;
            // 品番
            columns[COLUMN_GOODSNO].Width = 190;
            // 品名
            columns[COLUMN_GOODSNAME].Width = 190;
            // メーカーコード
            columns[COLUMN_MAKERCODE].Width = 45;
            // ＢＬコード
            columns[COLUMN_BLCODE].Width = 55;
            // グループコード
            columns[COLUMN_BLGROUPCODE].Width = 80;
            // 仕入先
            columns[COLUMN_SUPPLIERCODE].Width = 60;
            // 標準価格
            columns[COLUMN_PRICEFL].Width = 120;
            // 仕入原価
            columns[COLUMN_SUPPLIERPRICE].Width = 120;

            // 売価率
            if ((this._displayList == null) || (this._displayList.Count == 0))
            {
                for (int index = _startIndex; index <= COLINDEX_SALERATE_ED; index++)
                {
                    columns[index].Width = 120;
                }
            }
            else
            {
                string title = "";
                if (DETAIL_TITLE_1.Equals(uLabel_SaleRate.Text))
                    title = "title1";
                else if (DETAIL_TITLE_2.Equals(uLabel_SaleRate.Text))
                    title = "title2";
                else if (DETAIL_TITLE_3.Equals(uLabel_SaleRate.Text))
                    title = "title3";
                else if (DETAIL_TITLE_4.Equals(uLabel_SaleRate.Text))
                    title = "title4";
                else if (DETAIL_TITLE_5.Equals(uLabel_SaleRate.Text))
                    title = "title5";
                else if (DETAIL_TITLE_6.Equals(uLabel_SaleRate.Text))
                    title = "title6";

                foreach (int key in this._targetDic.Keys)
                {
                    columns[key.ToString() + title].Width = 120;
                }
            }
        }
        #endregion グリッド設定

        #region セル値変換
        /// <summary>
        /// セル値変換処理
        /// </summary>
        /// <param name="cellValue">セル値</param>
        /// <returns>Int型</returns>
        /// <remarks>
        /// <br>Note        : セル値をInt型に変換します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        public int IntObjToInt(object cellValue)
        {
            if ((cellValue == DBNull.Value) || (cellValue == null) || (cellValue.ToString() == ""))
            {
                return 0;
            }
            else
            {
                return (int)cellValue;
            }
        }

        /// <summary>
        /// セル値変換処理
        /// </summary>
        /// <param name="cellValue">セル値</param>
        /// <returns>String型</returns>
        /// <remarks>
        /// <br>Note        : セル値をString型に変換します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        public int StrObjToInt(object cellValue)
        {
            if ((cellValue == DBNull.Value) || (cellValue == null) || (cellValue.ToString() == ""))
            {
                return 0;
            }
            else
            {
                return int.Parse((string)cellValue);
            }
        }

        /// <summary>
        /// セル値変換処理
        /// </summary>
        /// <param name="cellValue">セル値</param>
        /// <returns>Double型</returns>
        /// <remarks>
        /// <br>Note        : セル値をDouble型に変換します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        public double DoubleObjToDouble(object cellValue)
        {
            if ((cellValue == DBNull.Value) || (cellValue == null) || (cellValue.ToString() == ""))
            {
                return 0;
            }
            else
            {
                return (double)cellValue;
            }
        }
        #endregion セル値変換

        #region Key作成
        /// <summary>
        /// Key作成処理
        /// </summary>
        /// <param name="result">掛率マスタ検索結果</param>
        /// <returns>Key</returns>
        /// <remarks>
        /// <br>Note        : Keyを作成します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private string MakeParentKey(GoodsRateSetSearchResult result)
        {
            // 品番＋メーカーコード＋BLコード + グループコード + 仕入先コード
            string key = result.GoodsMakerCd.ToString("0000") + "\\" +
                         result.BLGoodsCode.ToString("00000") + "\\" +
                         result.BLGroupCode.ToString("00000") + "\\" +
                         result.GoodsSupplierCd.ToString("000000") + "\\" +
                         result.GoodsNo;

            return key;
        }

        /// <summary>
        /// Key作成処理
        /// </summary>
        /// <param name="goodsMakerCd">商品メーカーコード</param>
        /// <param name="bLGoodsCode">商品番号</param>
        /// <param name="bLGroupCode">BLグループコード</param>
        /// <param name="goodsSupplierCd">仕入先コード</param>
        /// <param name="goodsNo">品番</param>
        /// <returns>Key</returns>
        /// <remarks>
        /// <br>Note        : Keyを作成します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private string MakeKey(int goodsMakerCd, int bLGoodsCode, int bLGroupCode, int goodsSupplierCd, string goodsNo)
        {
            // 品番＋メーカーコード＋BLコード + グループコード + 仕入先コード
            string key = goodsMakerCd.ToString("0000") + "\\" +
                         bLGoodsCode.ToString("00000") + "\\" +
                         bLGroupCode.ToString("00000") + "\\" +
                         goodsSupplierCd.ToString("000000") + "\\" +
                         goodsNo;

            return key;
        }

        /// <summary>
        /// Key作成処理
        /// </summary>
        /// <param name="rateSearchResult">掛率マスタ検索結果</param>
        /// <returns>Key</returns>
        /// <remarks>
        /// <br>Note        : Keyを作成します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private string MakeRateKey(GoodsRateSetSearchResult result)
        {
            int custCode = 0;
            if (0 == _targetDivide)
            {
                custCode = result.CustRateGrpCode;
            }
            else
            {
                custCode = result.CustomerCode;
            }

            // 品番＋メーカーコード＋BLコード + グループコード + 仕入先コード + 単価種別 + 得意先コード/得意先掛率グループコード
            string key = result.GoodsMakerCd.ToString("0000") + "\\" +
                         result.BLGoodsCode.ToString("00000") + "\\" +
                         result.BLGroupCode.ToString("00000") + "\\" +
                         result.GoodsSupplierCd.ToString("000000") + "\\" +
                         custCode.ToString("00000000") + "\\" +
                         result.UnitPriceKind + "\\" +
                         result.RateSettingDivide + "\\" +
                         result.GoodsNo;
            return key;
        }
        #endregion Key作成

        #region メッセージボックス表示
        /// <summary>
        /// メッセージボックス表示処理
        /// </summary>
        /// <param name="errLevel">エラーレベル</param>
        /// <param name="message">表示するメッセージ</param>
        /// <param name="status">ステータス値</param>
        /// <param name="msgButton">表示するボタン</param>
        /// <param name="defaultButton">初期表示ボタン</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : メッセージボックスを表示します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private DialogResult ShowMessageBox(emErrorLevel errLevel, string message, int status, MessageBoxButtons msgButton, MessageBoxDefaultButton defaultButton)
        {
            DialogResult dialogResult;
            dialogResult = TMsgDisp.Show(this,                              // 親ウィンドウフォーム
                                         errLevel,                          // エラーレベル
                                         ASSEMBLY_ID,                        // アセンブリID
                                         message,                           // 表示するメッセージ
                                         status,                            // ステータス値
                                         msgButton,                         // 表示するボタン
                                         defaultButton);                    // 初期表示ボタン
            return dialogResult;
        }

        /// <summary>
        /// メッセージボックス表示処理
        /// </summary>
        /// <param name="errLevel">エラーレベル</param>
        /// <param name="methodName">処理名称</param>
        /// <param name="message">表示するメッセージ</param>
        /// <param name="status">ステータス値</param>
        /// <param name="msgButton">表示するボタン</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : メッセージボックスを表示します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private DialogResult ShowMessageBox(emErrorLevel errLevel, string methodName, string message, int status, MessageBoxButtons msgButton)
        {
            DialogResult dialogResult;
            dialogResult = TMsgDisp.Show(this, 						        // 親ウィンドウフォーム
                                         errLevel,			                // エラーレベル
                                         this.Name,						    // プログラム名称
                                         ASSEMBLY_ID, 		  　　		    // アセンブリID
                                         methodName,						// 処理名称
                                         "",					            // オペレーション
                                         message,	                        // 表示するメッセージ
                                         status,							// ステータス値
                                         this._goodsRateSetUpdateAcs,	    // エラーが発生したオブジェクト
                                         msgButton,         			  	// 表示するボタン
                                         MessageBoxDefaultButton.Button1);	// 初期表示ボタン

            return dialogResult;
        }
        #endregion メッセージボックス表示
        #endregion ■ Private Methods


        #region ■ Control Events

        /// <summary>
        /// Load イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : フォームがLoadされた時に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private void PMKHN09461UA_Load(object sender, EventArgs e)
        {
            this.uGrid_Details.ActiveRow = null;

            this.Initial_Timer.Enabled = true;

            //this.Form1_Top_Panel6.Size = new Size(750, 23); // DEL 2010/08/27
            //this.Form1_Top_Panel6.Size = new Size(520, 23); // ADD 2010/08/27  //DEL BY 凌小青 on 2011/11/22 for Redmine#7744
            this.Form1_Top_Panel6.Size = new Size(490, 23);   //ADD BY 凌小青 on 2011/11/22 for Redmine#7744
        }

        /// <summary>
        /// ToolClick イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : ツールバーがクリックされた時に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private void tToolbarsManager_MainMenu_ToolClick(object sender, ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case "ButtonTool_Close":
                    {
                        // 画面情報比較
                        bool bStatus = CompareScreen();
                        if (!bStatus)
                        {
                            return;
                        }

                        this._closeFlg = true;

                        // 終了処理
                        Close();
                        break;
                    }
                case "ButtonTool_Save":
                    {
                        // 保存処理
                        Save();
                        //-----ADD 2010/09/01---------->>>>>
                        if (this.uGrid_Details.Rows.Count > 0)
                        {
                            for (int i = 0; i < this.uGrid_Details.Rows[0].Cells.Count; i++)
                            {
                                if (this.uGrid_Details.Rows[0].Cells[i].Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                                && this.uGrid_Details.Rows[0].Cells[i].Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit)
                                {
                                    this.uGrid_Details.Rows[0].Cells[i].Activate();
                                    this._startIndex = i;
                                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                    this._guideButton.SharedProps.Enabled = false;
                                    break;
                                }
                            }
                        }
                        //-----ADD 2010/09/01----------<<<<<
                        break;
                    }
                case "ButtonTool_Search":
                    {
                        // 画面情報比較
                        bool bStatus = CompareScreen();
                        if (!bStatus)
                        {
                            return;
                        }

                        // 検索処理
                        Search();

                        //-----ADD 2010/08/30---------->>>>>
                        if (this.uGrid_Details.Rows.Count > 0)
                        {
                            this.uGrid_Details.Focus();
                            //-----UPD 2010/09/01---------->>>>>
                            //this.uGrid_Details.Rows[0].Cells[this._startIndex].Activate();
                            //this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            //this._guideButton.SharedProps.Enabled = false;
                            for (int i = 0; i < this.uGrid_Details.Rows[0].Cells.Count; i++)
                            {
                                if (this.uGrid_Details.Rows[0].Cells[i].Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit
                                && this.uGrid_Details.Rows[0].Cells[i].Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit)
                                {
                                    this.uGrid_Details.Rows[0].Cells[i].Activate();
                                    this._startIndex = i;
                                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                                    this._guideButton.SharedProps.Enabled = false;
                                    break;
                                }
                            }
                            //-----UPD 2010/09/01----------<<<<<
                        }
                        //-----ADD 2010/08/30----------<<<<<
                        break;
                    }
                case "ButtonTool_RateGRef":
                    {
                        // 掛率Ｇ引用
                        // 検索条件格納

                        SetExtrInfo(out this._extrInfo);
                        _pMKHN09461UD = new PMKHN09461UD(this._extrInfo);
                        DialogResult result = _pMKHN09461UD.ShowDialog(this);

                        if (result == DialogResult.OK)
                        {
                            if (this.uGrid_Details.Rows.Count == 0) return;
                            // 再検索
                            this.Search();
                            // 色を黒を戻す
                            uGrid_Details_AfterExitEditMode(null, null);
                        }
                        break;
                    }
                case "ButtonTool_CustomerRef":
                    {
                        // 得意先引用
                        SetExtrInfo(out this._extrInfo);
                        _pMKHN09461UC = new PMKHN09461UC(this._extrInfo);
                        DialogResult result = _pMKHN09461UC.ShowDialog(this);

                        if (result == DialogResult.OK)
                        {
                            if (this.uGrid_Details.Rows.Count == 0) return;
                            // 再検索
                            this.Search();
                            // 色を黒を戻す
                            uGrid_Details_AfterExitEditMode(null, null);
                        }

                        break;
                    }
                case "ButtonTool_Guide":
                    {
                        // ガイド起動処理
                        this.ExecuteGuide();

                        break;
                    }
                case "ButtonTool_Renewal":
                    {
                        // マスタ読込
                        ReadSecInfoSet();
                        ReadMakerUMnt();
                        ReadCustomerSearchRet();
                        ReadCustRateGrp();
                        // --- ADD 2010/08/27 ---------->>>>>
                        this._goodsRateSetUpdateAcs.RenewalSearchInitial();
                        // --- ADD 2010/08/27 ----------<<<<<

                        ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                   "最新情報を取得しました。",
                                   0,
                                   MessageBoxButtons.OK,
                                   MessageBoxDefaultButton.Button1);
                        break;
                    }
                case "ButtonTool_ShowChange":
                    {
                        // 表示切替
                        if (DETAIL_TITLE_1.Equals(uLabel_SaleRate.Text))
                        {
                            uLabel_SaleRate.Text = DETAIL_TITLE_2;
                            this._startIndex = COLINDEX_SALERATE_ST + 1;
                        }
                        else if (DETAIL_TITLE_2.Equals(uLabel_SaleRate.Text))
                        {
                            uLabel_SaleRate.Text = DETAIL_TITLE_3;
                            this._startIndex = COLINDEX_SALERATE_ST + 2;
                        }
                        else if (DETAIL_TITLE_3.Equals(uLabel_SaleRate.Text))
                        {
                            uLabel_SaleRate.Text = DETAIL_TITLE_4;
                            this._startIndex = COLINDEX_SALERATE_ST + 3;
                        }
                        else if (DETAIL_TITLE_4.Equals(uLabel_SaleRate.Text))
                        {
                            uLabel_SaleRate.Text = DETAIL_TITLE_5;                            
                            this._startIndex = COLINDEX_SALERATE_ST + 4;
                        }
                        else if (DETAIL_TITLE_5.Equals(uLabel_SaleRate.Text))
                        {
                            uLabel_SaleRate.Text = DETAIL_TITLE_6;
                            this._startIndex = COLINDEX_SALERATE_ST + 5;
                        }
                        else if (DETAIL_TITLE_6.Equals(uLabel_SaleRate.Text))
                        {
                            uLabel_SaleRate.Text = DETAIL_TITLE_1;
                            this._startIndex = COLINDEX_SALERATE_ST;
                        }

                        // グリッドデータ設定
                        SetGridLayout(ref this.uGrid_Details);

                        ChangeRateFocus(); // ADD 2010/08/27

                        break;
                    }
                case "ButtonTool_Undo":
                    {
                        // 画面情報比較
                        bool bStatus = CompareScreen();
                        if (!bStatus)
                        {
                            return;
                        }

                        // クリア処理
                        ClearScreen();
                        break;
                    }
                case "ButtonTool_AllDelete":
                    {
                        // 一括削除
                        // 検索条件格納
                        SetExtrInfo(out this._extrInfo);
                        _pMKHN09461UB = new PMKHN09461UB(this._extrInfo);
                        DialogResult result = _pMKHN09461UB.ShowDialog(this);

                        if (result == DialogResult.OK)
                        {
                            if (this.uGrid_Details.Rows.Count == 0) return;
                            // 再検索
                            this.Search();
                            // 色を黒を戻す
                            uGrid_Details_AfterExitEditMode(null, null);
                        }
                        break;
                    }
            }
        }

        // ---ADD 2010/08/27-------------------->>>
        /// <summary>
        /// 切替時は、フォーカスを設定する
        /// </summary>
        /// <remarks>
        /// <br>Note        : 切替時は、フォーカスを設定する。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2010/08/27</br>
        /// </remarks>
        private void ChangeRateFocus()
        {
            int rowIndex;
            int colIndex;

            if (this.uGrid_Details.ActiveCell != null)
            {
                rowIndex = this.uGrid_Details.ActiveCell.Row.Index;
                colIndex = this.uGrid_Details.ActiveCell.Column.Index;

                if (colIndex >= COLINDEX_SALERATE_ST)
                {
                    if ((colIndex - (COLINDEX_SALERATE_ST + 5)) % 6 == 0)
                    {
                        this.uGrid_Details.Rows[rowIndex].Cells[colIndex - 5].Activate();
                        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                    }
                    else
                    {
                        this.uGrid_Details.Rows[rowIndex].Cells[colIndex + 1].Activate();
                        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                    }
                }
            }
        }
        // ---ADD 2010/08/27--------------------<<<

        /// <summary>
        /// Button_Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : 拠点ガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private void SectionGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                SecInfoSet secInfoSet;

                int status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, true, out secInfoSet);
                if (status == 0)
                {
                    if (secInfoSet.SectionCode.Trim() != this._prevSectionCode)
                    {
                        this._prevSectionCode = secInfoSet.SectionCode.Trim();
                        this.tEdit_SectionCodeAllowZero.DataText = secInfoSet.SectionCode.Trim();
                        this.tEdit_SectionName.DataText = GetSectionName(secInfoSet.SectionCode.Trim());

                        // フォーカス設定
                        this.tEdit_GoodsNo.Focus();
                        _guideButton.SharedProps.Enabled = false;
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Button_Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : メーカーガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private void MakerGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                MakerUMnt makerUMnt;

                int status = this._makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);
                if (status == 0)
                {
                    if (makerUMnt.GoodsMakerCd != this._prevMakerCode)
                    {
                        this._prevMakerCode = makerUMnt.GoodsMakerCd;
                        this.tNedit_GoodsMakerCd.SetInt(makerUMnt.GoodsMakerCd);
                        this.tEdit_MakerName.DataText = GetMakerName(makerUMnt.GoodsMakerCd);

                        // フォーカス設定
                        this.tNedit_BLGoodsCode.Focus();
                        _guideButton.SharedProps.Enabled = true;
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Button_Click イベント(ＢＬコードガイド)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : ＢＬコードガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private void BLGoodsCdGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;
                BLGoodsCdUMnt blGoodsCdUMnt = null;

                // BLコードガイド表示
                status = this._blGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out blGoodsCdUMnt);
                if (status == 0)
                {
                    if (blGoodsCdUMnt.BLGoodsCode != this._prevBLGoodsCode)
                    {
                        this._prevBLGoodsCode = blGoodsCdUMnt.BLGoodsCode;

                        // BLコード
                        this.tNedit_BLGoodsCode.SetInt(blGoodsCdUMnt.BLGoodsCode);
                        // ＢＬコード名
                        this.tEdit_BLGoodsName.DataText = blGoodsCdUMnt.BLGoodsHalfName;

                        this.tNedit_BLGloupCode.Focus();
                        _guideButton.SharedProps.Enabled = true;
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Button_Click イベント(グループコードガイド)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : グループコードガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private void BLGroupGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;
                BLGroupU blGroupU = new BLGroupU();

                // BLグループガイド表示
                status = this._blGroupUAcs.ExecuteGuid(this._enterpriseCode, out blGroupU);
                if (status == 0)
                {
                    if (blGroupU.BLGroupCode != this._prevBLGroupCode)
                    {
                        this._prevBLGroupCode = blGroupU.BLGroupCode;

                        // BLグループコード
                        this.tNedit_BLGloupCode.SetInt(blGroupU.BLGroupCode);
                        // グループコード名
                        this.tEdit_BLGloupName.DataText = blGroupU.BLGroupName;

                        this.tComboEditor_TargetDivide.Focus();
                        _guideButton.SharedProps.Enabled = false;
                    }
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }


        /// <summary>
        /// ExpandedStateChanged イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : 展開ステータスが変更された時に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private void Standard_UGroupBox_ExpandedStateChanged(object sender, EventArgs e)
        {
            Size topSize = new Size();

            topSize.Width = this.Form1_Top_Panel.Size.Width;
            topSize.Height = 48;

            if ((this.Standard_UGroupBox.Expanded == true) || (this.Standard_UGroupBox2.Expanded == true))
            {
                topSize.Height = 210;
                Form1_Top_Panel3.Height = _panel3Height;
            }
            else
            {
                topSize.Height = 48;
                Form1_Top_Panel3.Height = _panel3Height - 162;
            }

            this.Form1_Top_Panel.Size = topSize;
        }

        /// <summary>
        /// KeyDown イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : グリッドアクティブ時にKeyを押された時に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private void uGrid_Details_KeyDown(object sender, KeyEventArgs e)
        {
            UltraGrid uGrid = (UltraGrid)sender;

            if (uGrid.ActiveCell == null)
            {
                return;
            }

            int rowIndex = uGrid.ActiveCell.Row.Index;
            int colIndex = uGrid.ActiveCell.Column.Index;
            string colKey = uGrid.ActiveCell.Column.Key;


            switch (e.KeyCode)
            {
                case Keys.Up:
                    {
                        if (rowIndex == 0)
                        {
                            // ADD 2010/08/27 --- >>>>>
                            this.tNedit_BLGloupCode.Focus();
                            this.tNedit_BLGloupCode.SelectAll();
                            uGrid.Rows[0].Activated = false;
                            // ADD 2010/08/27 --- <<<<<
                            // --- ADD 2010/08/30 ---------------------------------->>>>>
                            this._guideButton.SharedProps.Enabled = true;
                            // --- ADD 2010/08/30 ----------------------------------<<<<<
                        }
                        else
                        {
                            e.Handled = true;
                            for (int i = rowIndex - 1; i >= 0; i--)
                            {
                                if (!uGrid.Rows[i].Hidden)
                                {
                                    uGrid.Rows[i].Cells[colIndex].Activate();
                                    uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                    break;
                                }
                            }
                        }
                        break;
                    }
                case Keys.Down:
                    {
                        e.Handled = true;

                        if (rowIndex != uGrid.Rows.Count - 1)
                        {
                            for (int i = rowIndex + 1; i < uGrid.Rows.Count; i++)
                            {
                                if (!uGrid.Rows[i].Hidden)
                                {
                                    uGrid.Rows[i].Cells[colIndex].Activate();
                                    uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                    break;
                                }
                            }
                        }
                        break;
                    }
                case Keys.Left:
                    {
                        if (uGrid.ActiveCell.IsInEditMode)
                        {
                            if (uGrid.ActiveCell.SelStart == 0)
                            {
                                if ((rowIndex == 0) && (colKey == COLUMN_SUPPLIERPRICE))
                                {
                                    e.Handled = true;
                                }
                                //-----UPD 2010/08/30---------->>>>>
                                else if (colIndex == _startIndex)
                                //else if (colKey == COLUMN_SUPPLIERPRICE)
                                //-----UPD 2010/08/30----------<<<<<
                                {
                                    e.Handled = true;
                                    //-----UPD 2010/09/01---------->>>>>
                                    //for (int i = rowIndex - 1; i >= 0; i--)
                                    //{
                                    //    if (!uGrid.Rows[i].Hidden)
                                    //    {
                                    //        uGrid.Rows[i].Cells[_startIndex + (this._targetDic.Keys.Count - 1) * 6].Activate();
                                    //        uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                    //        break;
                                    //    }
                                    //}
                                    //-----UPD 2010/09/01---------->>>>>
                                }
                                else
                                {
                                    e.Handled = true;
                                    if (colIndex > this._startIndex)
                                    {
                                        uGrid.Rows[rowIndex].Cells[colIndex - 1 * 6].Activate();
                                    }
                                    else
                                    {
                                        uGrid.Rows[rowIndex].Cells[colIndex - (this._startIndex - 8)].Activate();
                                    }
                                    uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                }
                            }
                        }
                        //-----ADD 2010/08/30---------->>>>>
                        else
                        {
                            if (colIndex == 1)
                            {
                                e.Handled = true;
                                if (rowIndex != 0)
                                {
                                    uGrid.Rows[rowIndex - 1].Cells[_startIndex + (this._targetDic.Keys.Count - 1) * 6].Activate();
                                    uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                    break;
                                }
                            }
                        }
                        //-----ADD 2010/08/30----------<<<<<
                        break;
                    }
                case Keys.Right:
                    {
                        // UPD 2010/08/27 ---- >>>>>
                        if (uGrid.ActiveCell.IsInEditMode)
                        {
                            if (uGrid.ActiveCell.SelStart >= uGrid.ActiveCell.Text.Length)
                            {
                                if ((rowIndex == uGrid.Rows.Count - 1) && (colIndex == _startIndex + (this._targetDic.Keys.Count - 1) * 6))
                                {
                                    e.Handled = true;
                                }
                                else if (colIndex == _startIndex + (this._targetDic.Keys.Count - 1) * 6)
                                {
                                    e.Handled = true;
                                    //for (int i = rowIndex + 1; i < uGrid.Rows.Count; i++)
                                    //{
                                    //    if (!uGrid.Rows[i].Hidden)
                                    //    {
                                    //        uGrid.Rows[i].Cells[_startIndex].Activate();
                                    //        uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                    //        break;
                                    //    }
                                    //}
                                }
                                else
                                {
                                    e.Handled = true;
                                    //-----ADD 2010/08/30---------->>>>>
                                    //uGrid.Rows[rowIndex].Cells[colIndex + 1].Activate();
                                    uGrid.Rows[rowIndex].Cells[colIndex + 6].Activate();
                                    //-----ADD 2010/08/30----------<<<<<
                                    uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                }
                            }
                        }
                        //-----ADD 2010/08/30---------->>>>>
                        else
                        {
                            if (colIndex == 8)
                            {
                                e.Handled = true;
                                uGrid.Rows[rowIndex].Cells[_startIndex].Activate();
                                uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                break;
                            }
                        }
                        //-----ADD 2010/08/30----------<<<<<
                        // UPD 2010/08/27 ---- <<<<<<<
                        break;
                    }
            }

        }

        /// <summary>
        /// KeyPress イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : グリッドアクティブ時にKeyを押された時に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private void uGrid_Details_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.uGrid_Details.ActiveCell == null)
            {
                return;
            }

            UltraGridCell cell = this.uGrid_Details.ActiveCell;

            // 編集できるのは仕入率と売価率のみ
            if (cell.IsInEditMode)
            {
                //-----ADD 2010/08/31---------->>>>>
                if (uLabel_SaleRate.Text == DETAIL_TITLE_3)
                {
                    if (!KeyPressNumCheck2(9, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
                //-----ADD 2010/08/31----------<<<<<
                // ZZZZZZZZ9.99
                //-----UPD 2010/08/31---------->>>>>
                //if (uLabel_SaleRate.Text == DETAIL_TITLE_1 || uLabel_SaleRate.Text == DETAIL_TITLE_3)
                else if (uLabel_SaleRate.Text == DETAIL_TITLE_1)
                //-----UPD 2010/08/31----------<<<<<
                {
                    if (!KeyPressNumCheck(12, 2, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }
                // ZZ9.99
                else if (uLabel_SaleRate.Text == DETAIL_TITLE_2 || uLabel_SaleRate.Text == DETAIL_TITLE_4
                     || uLabel_SaleRate.Text == DETAIL_TITLE_5)
                {
                    if (!KeyPressNumCheck(6, 2, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    {
                        e.Handled = true;
                        return;
                    }

                }
                // Z9.99
                else
                {
                    if (!KeyPressNumCheck(5, 2, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                    {
                        e.Handled = true;
                        return;
                    }
                }

            }
        }

        /// <summary>
        /// AfterCellActivate イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : セルがアクティブ化した時に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private void uGrid_Details_AfterCellActivate(object sender, EventArgs e)
        {
            this.uGrid_Details.Rows[this.uGrid_Details.ActiveCell.Row.Index].Selected = false;
        }

        /// <summary>
        /// AfterExitEditMode イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : 編集モードが終了した時に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private void uGrid_Details_AfterExitEditMode(object sender, EventArgs e)
        {
            if (this.uGrid_Details.ActiveCell == null)
            {
                return;
            }

            // 入力値取得
            double rate = DoubleObjToDouble(this.uGrid_Details.ActiveCell.Value);

            // 0は空白表示
            if (rate == 0)
            {
                this.uGrid_Details.ActiveCell.Value = DBNull.Value;
            }

            // 検索実行後、「一番左の項目値」を基準に、異なる値を入力した場合に文字色を「赤色」へ変更する。
            //　また、同じ値を入力した場合は文字色を元に戻す。
            for (int rowIndex = 0; rowIndex < this.uGrid_Details.Rows.Count; rowIndex++)
            {

                CellsCollection cells = this.uGrid_Details.Rows[rowIndex].Cells;
                DataRow originalDr = this._dataTableClone.Select(COLUMN_NO + " ='"
                    + cells[COLUMN_NO].Value.ToString() + "'")[0];

                int codeLeft = 0;
                for (int keyIndex = 0; keyIndex < _keyList.Count; keyIndex++)
                {
                    codeLeft = _keyList[0];

                    int code = _keyList[keyIndex];

                    // 売価額
                    for (int i = 1; i < 7; i++)
                    {
                        double oldCode1 = DoubleObjToDouble(originalDr[code.ToString() + "title" + i]);
                        double newCode1 = DoubleObjToDouble(cells[code.ToString() + "title" + i].Value);

                        double newCodeLeft = DoubleObjToDouble(cells[codeLeft.ToString() + "title" + i].Value);
                        if (oldCode1 != newCode1 && newCode1 != newCodeLeft)
                        {
                            cells[code.ToString() + "title" + i].Appearance.ForeColor = Color.Red;
                        }
                        else
                        {
                            cells[code.ToString() + "title" + i].Appearance.ForeColor = Color.Black;
                        }
                    }

                }
            }
        }

        /// <summary>
        /// Tick イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : 一定間隔が過ぎる度に時に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            // フォーカス設定
            this.tComboEditor_ObjectDiv.Focus();
            // ---ADD 2010/08/27-------------------->>>
            // XMLデータ読込
            LoadStateXmlData();
            // ---ADD 2010/08/27--------------------<<<

            // グリッドのアクティブ行を削除
            this.uGrid_Details.ActiveRow = null;

            this.Initial_Timer.Enabled = false;
        }

        /// <summary>
        /// ValueChanged イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : フォントサイズコンボボックスの値が変更された時に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private void tComboEditor_GridFontSize_ValueChanged(object sender, EventArgs e)
        {
            if (this.tComboEditor_GridFontSize.Value == null)
            {
                this.uGrid_Details.DisplayLayout.Appearance.FontData.SizeInPoints = (int)11;
                this.Form1_Top_Panel3.Size = new Size(595, 187);
                this.Form1_Top_Panel5.Size = new Size(595, 23);
                this.uLabel_SaleRate.Size = new Size(177, 23);
                this.uLabel_SaleRate.Appearance.FontData.SizeInPoints = 11;
            }
            else
            {
                this.uGrid_Details.DisplayLayout.Appearance.FontData.SizeInPoints = (int)this.tComboEditor_GridFontSize.Value;
                this.uLabel_SaleRate.Appearance.FontData.SizeInPoints = (int)this.tComboEditor_GridFontSize.Value;
                switch ((int)this.tComboEditor_GridFontSize.Value)
                {
                    case 6:
                        {
                            this.Form1_Top_Panel3.Size = new Size(595, 195);
                            this.Form1_Top_Panel5.Size = new Size(595, 15);
                            this.uLabel_SaleRate.Size = new Size(177, 15);
                            break;
                        }
                    case 8:
                        {
                            this.Form1_Top_Panel3.Size = new Size(595, 192);
                            this.Form1_Top_Panel5.Size = new Size(595, 18);
                            this.uLabel_SaleRate.Size = new Size(177, 18);
                            break;
                        }
                    case 9:
                        {
                            this.Form1_Top_Panel3.Size = new Size(595, 190);
                            this.Form1_Top_Panel5.Size = new Size(595, 20);
                            this.uLabel_SaleRate.Size = new Size(177, 20);
                            break;
                        }
                    case 10:
                        {
                            this.Form1_Top_Panel3.Size = new Size(595, 189);
                            this.Form1_Top_Panel5.Size = new Size(595, 21);
                            this.uLabel_SaleRate.Size = new Size(177, 21);
                            break;
                        }
                    case 11:
                        {
                            this.Form1_Top_Panel3.Size = new Size(595, 187);
                            this.Form1_Top_Panel5.Size = new Size(595, 23);
                            this.uLabel_SaleRate.Size = new Size(177, 23);
                            break;
                        }
                    case 12:
                        {
                            this.Form1_Top_Panel3.Size = new Size(595, 186);
                            this.Form1_Top_Panel5.Size = new Size(595, 24);
                            this.uLabel_SaleRate.Size = new Size(177, 24);
                            break;
                        }
                    case 14:
                        {
                            this.Form1_Top_Panel3.Size = new Size(595, 183);
                            this.Form1_Top_Panel5.Size = new Size(595, 27);
                            this.uLabel_SaleRate.Size = new Size(177, 27);
                            break;
                        }
                }
            }

            this._panel3Height = this.Form1_Top_Panel3.Height;
        }

        /// <summary>
        /// ValueChanged イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : 対象区分コンボボックスの値が変更された時に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private void tComboEditor_TargetDivide_ValueChanged(object sender, EventArgs e)
        {
            if (this.tComboEditor_TargetDivide.Value == null)
            {
                this.tComboEditor_TargetDivide.Value = 0;
            }

            if ((int)this.tComboEditor_TargetDivide.Value == 0)
            {
                // 得意先掛率Ｇ
                this.panel_Customer.Visible = false;
                this.panel_Customer.Size = new Size(573, 1);
                this.panel_Customer.Location = new Point(10, 34);

                this.panel_CustRateGrp.Size = new Size(573, 88);
                this.panel_CustRateGrp.Location = new Point(10, 36);
                this.panel_CustRateGrp.Visible = true;

                this.uCheckEditor_unSetting.Visible = true;
            }
            else
            {
                // 得意先
                this.panel_CustRateGrp.Visible = false;
                this.panel_CustRateGrp.Size = new Size(573, 1);
                this.panel_CustRateGrp.Location = new Point(10, 34);

                this.panel_Customer.Size = new Size(573, 88);
                this.panel_Customer.Location = new Point(10, 36);
                this.panel_Customer.Visible = true;

                this.uCheckEditor_unSetting.Visible = false;
            }
        }

        /// <summary>
        /// Leave イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : 得意先掛率Ｇからフォーカスが離れた時に発生します。</br>
        /// <br>Programmer  : 李占川</br>
        /// <br>Date        : 2010/08/04</br>
        /// </remarks>
        private void tNedit_CustRateGrpCode_Leave(object sender, EventArgs e)
        {
            TNedit tNedit = (TNedit)sender;

            if (tNedit.DataText.Trim() == "")
            {
                return;
            }

            int custRateGrpCode = tNedit.GetInt();

            tNedit.DataText = custRateGrpCode.ToString("0000");
        }

        /// <summary>
        /// ChangeFocus イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : コントロールのフォーカスが変更された時に発生します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2010/08/04</br>
        /// <br>Update Note: 2010/09/06 曹文傑 #14238対応</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            // ガイド有効/無効の設定
            bool flag = false;
            switch (e.NextCtrl.Name)
            {
                // 拠点
                case "tEdit_SectionCodeAllowZero":
                // メーカー
                case "tNedit_GoodsMakerCd":
                // BL商品コード
                case "tNedit_BLGoodsCode":
                // BLグループコード
                case "tNedit_BLGloupCode":
                    {
                        flag = true;
                        break;
                    }
            }
            // 得意先掛率G/得意先
            if (panel_CustRateGrp.Contains(e.NextCtrl) || panel_Customer.Contains(e.NextCtrl))
            {
                flag = true;
            }

            // ガイド有効の地域からガイドツールバーにフォーカス移動した場合はガイド有効にする
            if ("_Form1_Toolbars_Dock_Area_Top".Equals(e.NextCtrl.Name))
            {
                switch (e.PrevCtrl.Name)
                {
                    // 拠点
                    case "tEdit_SectionCodeAllowZero":
                    // メーカー
                    case "tNedit_GoodsMakerCd":
                    // BL商品コード
                    case "tNedit_BLGoodsCode":
                    // BLグループコード
                    case "tNedit_BLGloupCode":
                        {
                            flag = true;
                            break;
                        }
                }
                // 得意先掛率G/得意先
                if (panel_CustRateGrp.Contains(e.PrevCtrl) || panel_Customer.Contains(e.PrevCtrl))
                {
                    flag = true;
                }
            }

            this._guideButton.SharedProps.Enabled = flag;

            // --- ADD 2010/08/30 ---------------------------------->>>>>
            #region 得意先コードと得意先掛率Ｇの入力で、チェックを行う
            switch (e.PrevCtrl.Name)
            {
                case "tNedit_CustomerCode1":
                case "tNedit_CustomerCode2":
                case "tNedit_CustomerCode3":
                case "tNedit_CustomerCode4":
                case "tNedit_CustomerCode5":
                case "tNedit_CustomerCode6":
                case "tNedit_CustomerCode7":
                case "tNedit_CustomerCode8":
                case "tNedit_CustomerCode9":
                case "tNedit_CustomerCode10":
                case "tNedit_CustomerCode11":
                case "tNedit_CustomerCode12":
                case "tNedit_CustomerCode13":
                case "tNedit_CustomerCode14":
                case "tNedit_CustomerCode15":
                case "tNedit_CustomerCode16":
                case "tNedit_CustomerCode17":
                case "tNedit_CustomerCode18":
                case "tNedit_CustomerCode19":
                case "tNedit_CustomerCode20":
                case "tNedit_CustomerCode21":
                    {
                        TNedit control = (TNedit)(this.GetType().GetField(e.PrevCtrl.Name, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase).GetValue(this));

                        if (!string.IsNullOrEmpty(control.Text))
                        {
                            int customerCd = control.GetInt();
                            CustomerInfo customerInfo = null;
                            // 得意先検索処理（得意先コードより）
                            int status = this._customerInputAcs.GetCustomerInfoFromCustomerCode(ConstantManagement.LogicalMode.GetDataAll, customerCd, out customerInfo);

                            if (customerInfo != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && customerInfo.LogicalDeleteCode == 0)
                            {
                                control.DataText = customerCd.ToString();
                                this.searchFlag = true;
                            }
                            else
                            {
                                // --- ADD 2010/08/31 ---------------------------------->>>>>
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "得意先が存在しません。",
                                    -1,
                                    MessageBoxButtons.OK);
                                // --- ADD 2010/08/31 ----------------------------------<<<<<
                                control.DataText = string.Empty;
                                e.NextCtrl = control;
                                this.searchFlag = false;
                            }
                        }
                        else
                        {
                            this.searchFlag = true;
                        }
                        
                        break;
                    }
                case "tNedit_CustRateGrpCode1":
                case "tNedit_CustRateGrpCode2":
                case "tNedit_CustRateGrpCode3":
                case "tNedit_CustRateGrpCode4":
                case "tNedit_CustRateGrpCode5":
                case "tNedit_CustRateGrpCode6":
                case "tNedit_CustRateGrpCode7":
                case "tNedit_CustRateGrpCode8":
                case "tNedit_CustRateGrpCode9":
                case "tNedit_CustRateGrpCode10":
                case "tNedit_CustRateGrpCode11":
                case "tNedit_CustRateGrpCode12":
                case "tNedit_CustRateGrpCode13":
                case "tNedit_CustRateGrpCode14":
                case "tNedit_CustRateGrpCode15":
                case "tNedit_CustRateGrpCode16":
                case "tNedit_CustRateGrpCode17":
                case "tNedit_CustRateGrpCode18":
                case "tNedit_CustRateGrpCode19":
                case "tNedit_CustRateGrpCode20":
                case "tNedit_CustRateGrpCode21":
                    {
                        TNedit control = (TNedit)(this.GetType().GetField(e.PrevCtrl.Name, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase).GetValue(this));

                        if (!string.IsNullOrEmpty(control.Text))
                        {
                            int customerGpCd = control.GetInt();
                            if (control.Text.IndexOf(customerGpCd.ToString()) >= 0)
                            {
                                UserGdBd userGdBd = null;
                                UserGuideAcsData acsDataType = UserGuideAcsData.UserBodyData;
                                int status = this._userGuideAcs.ReadBody(out userGdBd, this._enterpriseCode, 43, customerGpCd, ref acsDataType);

                                if (userGdBd != null && status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && userGdBd.LogicalDeleteCode == 0)
                                {
                                    control.DataText = customerGpCd.ToString();
                                    this.searchFlag = true;
                                }
                                else
                                {
                                    // --- ADD 2010/08/31 ---------------------------------->>>>>
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "得意先掛率グループが存在しません。",
                                        -1,
                                        MessageBoxButtons.OK);
                                    // --- ADD 2010/08/31 ----------------------------------<<<<<
                                    control.DataText = string.Empty;
                                    e.NextCtrl = control;
                                    this.searchFlag = false;
                                }
                            }
                            else
                            {
                                control.DataText = string.Empty;
                                e.NextCtrl = control;
                            }
                        }
                        else
                        {
                            this.searchFlag = true;
                        }

                        break;
                    }
            }
            #endregion
            // --- ADD 2010/08/30 ----------------------------------<<<<<

            switch (e.PrevCtrl.Name)
            {
                // 対象区分
                case "tComboEditor_ObjectDiv":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // フォーカス移動
                                e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                                _guideButton.SharedProps.Enabled = true;
                            }

                            //-----ADD 2010/09/06---------->>>>>
                            if (e.Key == Keys.Right)
                            {
                                e.NextCtrl = this.tComboEditor_TargetDivide;
                            }
                            //-----ADD 2010/09/06----------<<<<<
                        }
                        else
                        {
                            //-----UPD 2010/09/06---------->>>>>
                            //if (e.Key == Keys.Tab)
                            if (e.Key == Keys.Tab || e.Key == Keys.Return)
                            //-----UPD 2010/09/06----------<<<<<
                            {
                                // フォーカス移動
                                e.NextCtrl = e.PrevCtrl;
                                _guideButton.SharedProps.Enabled = false;
                            }
                        }

                        break;
                    }
                // 拠点コード
                case "tEdit_SectionCodeAllowZero":
                    {
                        string sectionCode = "";
                        if (this.tEdit_SectionCodeAllowZero.DataText.Trim() == string.Empty)
                        {
                            _prevSectionCode = "00";
                            sectionCode = "00";
                        }
                        else
                        {
                            sectionCode = this.tEdit_SectionCodeAllowZero.DataText.Trim();
                        }

                        string sectionName = GetSectionName(sectionCode).Trim();

                        // マスタに存在しない場合
                        bool hasFlg = false;
                        if (string.IsNullOrEmpty(sectionName))
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "拠点が存在しません。",
                                -1,
                                MessageBoxButtons.OK);
                            this.tEdit_SectionCodeAllowZero.Text = _prevSectionCode;
                            hasFlg = false;
                        }
                        else
                        {
                            // 該当するデータが存在した場合
                            this.tEdit_SectionName.DataText = sectionName;
                            hasFlg = true;
                            _prevSectionCode = sectionCode;

                        }

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tEdit_SectionName.DataText.Trim() != "")
                                {
                                    // フォーカス移動
                                    if (hasFlg)
                                    {
                                        e.NextCtrl = this.tEdit_GoodsNo;
                                        _guideButton.SharedProps.Enabled = false;
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                                        this.tEdit_SectionCodeAllowZero.SelectAll();
                                        _guideButton.SharedProps.Enabled = true;
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                // フォーカス移動
                                e.NextCtrl = this.tComboEditor_ObjectDiv;
                                _guideButton.SharedProps.Enabled = false;
                            }
                        }
                        break;
                    }
                // 品番
                case "tEdit_GoodsNo":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                // フォーカス移動
                                e.NextCtrl = this.tNedit_GoodsMakerCd;
                                _guideButton.SharedProps.Enabled = true;
                            }
                        }
                        //-----DEL 2010/09/06---------->>>>>
                        //else
                        //{
                        //    if (e.Key == Keys.Tab)
                        //    {
                        //        // フォーカス移動
                        //        if (this.tEdit_SectionName.DataText.Trim() != "")
                        //        {
                        //            e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                        //            _guideButton.SharedProps.Enabled = true;
                        //        }
                        //    }
                        //}
                        //-----DEL 2010/09/06----------<<<<<
                        break;
                    }
                // メーカーコード
                case "tNedit_GoodsMakerCd":
                    {
                        if (this.tNedit_GoodsMakerCd.DataText == string.Empty)
                        {
                            _prevMakerCode = 0;
                            this.tEdit_MakerName.DataText = "";
                            return;
                        }

                        int makerCode = this.tNedit_GoodsMakerCd.GetInt();

                        string makerName = GetMakerName(makerCode);

                        // マスタに存在しない場合
                        bool hasFlg = false;
                        if (string.IsNullOrEmpty(makerName))
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "メーカーコードが存在しません。",
                                -1,
                                MessageBoxButtons.OK);
                            this.tNedit_GoodsMakerCd.SetInt(_prevMakerCode);
                            hasFlg = false;
                        }
                        else
                        {
                            // 該当するデータが存在した場合
                            this.tEdit_MakerName.DataText = makerName;
                            hasFlg = true;
                            _prevMakerCode = makerCode;
                        }

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tEdit_MakerName.DataText.Trim() != "")
                                {
                                    // フォーカス移動
                                    if (hasFlg)
                                    {
                                        e.NextCtrl = this.tNedit_BLGoodsCode;
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.tNedit_GoodsMakerCd;
                                        this.tNedit_GoodsMakerCd.SelectAll();
                                    }
                                    _guideButton.SharedProps.Enabled = true;
                                }
                                else
                                {
                                    e.NextCtrl = null;
                                }
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                // フォーカス移動
                                e.NextCtrl = this.tEdit_GoodsNo;
                            }
                        }
                        break;
                    }
                // メーカーガイド
                case "MakerGuide_Button":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tNedit_BLGoodsCode;
                                _guideButton.SharedProps.Enabled = true;
                            }
                        }
                        break;
                    }
                // ＢＬコード
                case "tNedit_BLGoodsCode":
                    {
                        // 入力しない
                        if (this.tNedit_BLGoodsCode.DataText == string.Empty)
                        {
                            this._prevBLGoodsCode = 0;
                            this.tEdit_BLGoodsName.DataText = "";
                            return;
                        }
                        // メーカーコード取得
                        int bLGoodsCode = this.tNedit_BLGoodsCode.GetInt();
                        string blGoodsName = this.GetBLGoodsName(bLGoodsCode);

                        bool hasFlg = false;
                        if (string.IsNullOrEmpty(blGoodsName))
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "ＢＬコードが存在しません。",
                                -1,
                                MessageBoxButtons.OK);
                            this.tNedit_BLGoodsCode.SetInt(_prevBLGoodsCode);
                            hasFlg = false;
                        }
                        else
                        {
                            hasFlg = true;
                            this.tEdit_BLGoodsName.DataText = blGoodsName;
                            _prevBLGoodsCode = bLGoodsCode;
                        }

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tEdit_BLGoodsName.DataText.Trim() != "")
                                {
                                    // フォーカス移動
                                    if (hasFlg)
                                    {
                                        e.NextCtrl = this.tNedit_BLGloupCode;
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.tNedit_BLGoodsCode;
                                        this.tNedit_BLGoodsCode.SelectAll();
                                    }
                                    _guideButton.SharedProps.Enabled = true;
                                }
                                else
                                {
                                    e.NextCtrl = null;
                                }
                            }
                        }
                        //-----DEL 2010/09/06---------->>>>>
                        //else
                        //{
                        //    if (e.Key == Keys.Tab)
                        //    {
                        //        if (tEdit_MakerName.DataText.Trim() != "")
                        //        {
                        //            // フォーカス移動
                        //            e.NextCtrl = this.tNedit_GoodsMakerCd;
                        //            _guideButton.SharedProps.Enabled = true;
                        //        }
                        //    }
                        //}
                        //-----DEL 2010/09/06----------<<<<<
                        break;
                    }
                // ＢＬコードガイド
                case "BLGoodsCdGuide_Button":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tNedit_BLGloupCode;
                                _guideButton.SharedProps.Enabled = true;
                            }

                            //-----ADD 2010/09/06---------->>>>>
                            if (e.Key == Keys.Right)
                            {
                                e.NextCtrl = null;
                                _guideButton.SharedProps.Enabled = false;
                            }
                            //-----ADD 2010/09/06----------<<<<<
                        }

                        break;
                    }
                // グループコード
                case "tNedit_BLGloupCode":
                    {
                        // 入力しない
                        if (this.tNedit_BLGloupCode.DataText == string.Empty)
                        {
                            this._prevBLGroupCode = 0;
                            this.tEdit_BLGloupName.DataText = "";
                            break;
                        }

                        // グループコード取得
                        int groupCode = this.tNedit_BLGloupCode.GetInt();
                        string groupName = this.GetBLGroupName(groupCode);

                        bool hasFlg = false;
                        if (string.IsNullOrEmpty(groupName))
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_INFO,
                                this.Name,
                                "グループコードが存在しません。",
                                -1,
                                MessageBoxButtons.OK);
                            this.tNedit_BLGloupCode.SetInt(_prevBLGroupCode);
                            hasFlg = false;
                        }
                        else
                        {
                            this.tEdit_BLGloupName.DataText = groupName;
                            hasFlg = true;
                            _prevBLGroupCode = groupCode;
                        }

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tEdit_BLGloupName.DataText.Trim() != "")
                                {
                                    // フォーカス移動
                                    if (hasFlg)
                                    {
                                        e.NextCtrl = this.tComboEditor_TargetDivide;
                                        _guideButton.SharedProps.Enabled = false;
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.tNedit_BLGloupCode;
                                        this.tNedit_BLGloupCode.SelectAll();
                                        _guideButton.SharedProps.Enabled = true;
                                    }
                                }
                                else
                                {
                                    e.NextCtrl = null;
                                }
                            }
                        }
                        //-----DEL 2010/09/06---------->>>>>
                        //else
                        //{
                        //    if (e.Key == Keys.Tab)
                        //    {
                        //        if (tEdit_BLGoodsName.DataText.Trim() != "")
                        //        {
                        //            // フォーカス移動
                        //            e.NextCtrl = this.tNedit_BLGoodsCode;
                        //            _guideButton.SharedProps.Enabled = true;
                        //        }
                        //    }
                        //}
                        //-----DEL 2010/09/06----------<<<<<
                        break;
                    }
                // グループコードガイド
                case "BLGroupGuide_Button":
                    {

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                e.NextCtrl = this.tComboEditor_TargetDivide;
                                _guideButton.SharedProps.Enabled = false;
                            }

                            //-----ADD 2010/09/06---------->>>>>
                            if (e.Key == Keys.Right)
                            {
                                e.NextCtrl = null;
                                _guideButton.SharedProps.Enabled = false;
                            }
                            //-----ADD 2010/09/06----------<<<<<
                        }

                        break;
                    }
                // 対象区分
                case "tComboEditor_TargetDivide":
                    {
                        if (e.ShiftKey == true)
                        {
                            if (e.Key == Keys.Tab)
                            {
                                // フォーカス移動
                                //-----UPD 2010/09/06---------->>>>>
                                //if (this.tEdit_BLGloupName.DataText.Trim() != "")
                                //{
                                //    e.NextCtrl = this.tNedit_BLGloupCode;
                                //    _guideButton.SharedProps.Enabled = true;
                                //}
                                //else
                                //{
                                //e.NextCtrl = this.BLGroupGuide_Button;
                                //_guideButton.SharedProps.Enabled = false;
                                //}
                                e.NextCtrl = this.BLGroupGuide_Button;
                                _guideButton.SharedProps.Enabled = false;
                                //-----UPD 2010/09/06----------<<<<<
                            }
                        }
                        //-----ADD 2010/09/06---------->>>>>
                        else
                        {
                            if (e.Key == Keys.Right)
                            {
                                if (this.uCheckEditor_unSetting.Enabled)
                                {
                                    e.NextCtrl = this.uCheckEditor_unSetting;
                                }
                                else
                                {
                                    e.NextCtrl = null;
                                }
                                _guideButton.SharedProps.Enabled = false;
                            }
                        }
                        //-----ADD 2010/09/06----------<<<<<
                        break;
                    }
                // 得意先掛率Ｇコード21、得意先コード21
                case "tNedit_CustRateGrpCode21":
                case "tNedit_CustomerCode21":
                    {
                        if (e.ShiftKey == false)
                        {
                            // --- UPD 2010/08/31 ---------------------------------->>>>>
                            //if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            if (((e.Key == Keys.Enter) || (e.Key == Keys.Tab)) && this.searchFlag)
                            // --- UPD 2010/08/31 ----------------------------------<<<<<
                            {
                                // 検索処理
                                Search();

                            }
                        }
                        break;
                    }
                // グリッド
                case "uGrid_Details":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                int rowIndex;
                                int colIndex;

                                if (this.uGrid_Details.ActiveCell != null)
                                {
                                    rowIndex = this.uGrid_Details.ActiveCell.Row.Index;
                                    colIndex = this.uGrid_Details.ActiveCell.Column.Index;
                                }
                                else if (this.uGrid_Details.ActiveRow != null)
                                {
                                    e.NextCtrl = null;
                                    _guideButton.SharedProps.Enabled = false;
                                    this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index].Cells[this._startIndex].Activate();
                                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                    return;
                                }
                                else
                                {
                                    if (this.uGrid_Details.Rows.Count == 0)
                                    {
                                        if (Standard_UGroupBox.Expanded == true)
                                        {
                                            e.NextCtrl = this.tComboEditor_ObjectDiv;
                                            _guideButton.SharedProps.Enabled = false;
                                        }
                                        else if (Standard_UGroupBox2.Expanded == true)
                                        {
                                            e.NextCtrl = tComboEditor_TargetDivide;
                                            _guideButton.SharedProps.Enabled = false;
                                        }
                                        else
                                        {
                                            e.NextCtrl = e.PrevCtrl;
                                        }
                                        return;
                                    }
                                    else
                                    {
                                        e.NextCtrl = null;
                                        _guideButton.SharedProps.Enabled = false;
                                        this.uGrid_Details.Rows[0].Cells[this._startIndex].Activate();
                                        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                        return;
                                    }
                                }

                                e.NextCtrl = null;
                                _guideButton.SharedProps.Enabled = false;

                                if (colIndex < 8)
                                {
                                    // 仕入率にフォーカス
                                    this.uGrid_Details.Rows[rowIndex].Cells[this._startIndex].Activate();
                                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                    return;
                                }
                                else if (colIndex == this._startIndex + (this._targetDic.Count - 1) * 6)
                                {
                                    if (rowIndex == this.uGrid_Details.Rows.Count - 1) 
                                    {
                                        // フォーカス移動なし
                                        this.uGrid_Details.Rows[rowIndex].Cells[colIndex].Activate();
                                        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                        return;
                                    }
                                    else
                                    {
                                        // 表示されている行の得意先コード１にフォーカス
                                        for (int i = rowIndex + 1; i < this.uGrid_Details.Rows.Count; i++)
                                        {
                                            if (!this.uGrid_Details.Rows[i].Hidden)
                                            {
                                                this.uGrid_Details.Rows[i].Cells[this._startIndex].Activate();
                                                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                                break;
                                            }
                                        }
                                        return;
                                    }
                                }
                                else
                                {
                                    this.uGrid_Details.PerformAction(UltraGridAction.NextCellByTab);
                                }
                            }
                        }
                        else
                        {
                            // UPD 2010/08/27 ---- >>>>>
                            if (e.Key == Keys.Tab || e.Key == Keys.Enter)
                            {

                                int rowIndex = 0;
                                int colIndex = 0;

                                if (this.uGrid_Details.ActiveCell != null)
                                {
                                    rowIndex = this.uGrid_Details.ActiveCell.Row.Index;
                                    colIndex = this.uGrid_Details.ActiveCell.Column.Index;
                                }
                                else if (this.uGrid_Details.ActiveRow != null)
                                {
                                    rowIndex = this.uGrid_Details.ActiveRow.Index;
                                    colIndex = 8;
                                }
                                else
                                {
                                    if (this.uGrid_Details.Rows.Count == 0)
                                    {
                                        if (Standard_UGroupBox2.Expanded == true)
                                        {
                                            if ((int)this.tComboEditor_TargetDivide.Value == 0)
                                            {
                                                // 得意先掛率Ｇ
                                                e.NextCtrl = this.tNedit_CustRateGrpCode21;
                                                _guideButton.SharedProps.Enabled = true;
                                            }
                                            else
                                            {
                                                // 得意先
                                                e.NextCtrl = this.tNedit_CustomerCode21;
                                                _guideButton.SharedProps.Enabled = true;
                                            }
                                        }
                                        else if (Standard_UGroupBox.Expanded == true)
                                        {
                                            if (this.tEdit_MakerName.DataText.Trim() != "")
                                            {
                                                e.NextCtrl = this.tNedit_GoodsMakerCd;
                                                _guideButton.SharedProps.Enabled = true;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.MakerGuide_Button;
                                                _guideButton.SharedProps.Enabled = false;
                                            }
                                        }
                                        else
                                        {
                                            e.NextCtrl = e.PrevCtrl;
                                        }
                                        return;
                                    }
                                    else
                                    {
                                        return;
                                    }
                                }

                                e.NextCtrl = null;
                                _guideButton.SharedProps.Enabled = false;

                                //if (colIndex <= 8)
                                //{
                                //    if (rowIndex == 0)
                                //    {
                                //    }
                                //    else
                                //    {
                                //        // 表示されている行の掛率Ｇにフォーカス
                                //        for (int i = rowIndex - 1; i >= 0; i--)
                                //        {
                                //            if (!this.uGrid_Details.Rows[i].Hidden)
                                //            {
                                //                this.uGrid_Details.Rows[i].Cells[this._startIndex + (this._targetDic.Count - 1) * 6].Activate();
                                //                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                //                break;
                                //            }
                                //        }
                                //    }
                                //}
                                //else
                                //{
                                //if (rowIndex == 0)
                                //{

                                    //this.tNedit_BLGloupCode.Focus();
                                    //this.tNedit_BLGloupCode.SelectAll();
                                    //this.uGrid_Details.Rows[0].Activated = false;

                                    //this._guideButton.SharedProps.Enabled = true;

                                //}
                                //else
                                //{
                                if (!MoveNextAllowEditCell(false))
                                {
                                    if (Standard_UGroupBox2.Expanded == true)
                                    {
                                        if ((int)this.tComboEditor_TargetDivide.Value == 0)
                                        {
                                            // 得意先掛率Ｇ
                                            e.NextCtrl = this.tNedit_CustRateGrpCode21;
                                            this.uGrid_Details.Rows[0].Activated = false;
                                            _guideButton.SharedProps.Enabled = true;
                                        }
                                        else
                                        {
                                            // 得意先
                                            e.NextCtrl = this.tNedit_CustomerCode21;
                                            this.uGrid_Details.Rows[0].Activated = false;
                                            _guideButton.SharedProps.Enabled = true;
                                        }
                                    }
                                    else if (Standard_UGroupBox.Expanded == true)
                                    {
                                        if (this.tEdit_MakerName.DataText.Trim() != "")
                                        {
                                            e.NextCtrl = this.tNedit_GoodsMakerCd;
                                            this.uGrid_Details.Rows[0].Activated = false;
                                            _guideButton.SharedProps.Enabled = true;
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.MakerGuide_Button;
                                            this.uGrid_Details.Rows[0].Activated = false;
                                            _guideButton.SharedProps.Enabled = false;
                                        }
                                    }
                                    else
                                    {
                                        e.NextCtrl = e.PrevCtrl;
                                    }
                                    return;
                                }
                                //}

                                    //this.uGrid_Details.PerformAction(UltraGridAction.PrevCellByTab);
                                //}
                            }
                            // UPD 2010/08/27 ---- <<<<<
                        }
                        break;
                    }
                //-----ADD 2010/09/06---------->>>>>
                    //未設定
                case "uCheckEditor_unSetting":
                    {
                        if (e.ShiftKey == false)
                        {
                            if (e.Key == Keys.Right)
                            {
                                e.NextCtrl = null;
                                _guideButton.SharedProps.Enabled = false;
                            }
                        }
                        break;
                    }
                //-----ADD 2010/09/06---------->>>>>
            }

            if (e.NextCtrl == null)
            {
                return;
            }

            switch (e.NextCtrl.Name)
            {
                // グリッド
                case "uGrid_Details":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab) || (e.Key == Keys.Down))
                            {
                                if (this.uGrid_Details.Rows.Count == 0)
                                {
                                    e.NextCtrl = e.PrevCtrl;
                                    // --- UPD 2010/08/30 ---------------------------------->>>>>
                                    //if ("tNedit_BLGloupCode".Equals(e.PrevCtrl.Name))
                                    if ("tNedit_BLGloupCode".Equals(e.PrevCtrl.Name) || panel_CustRateGrp.Contains(e.PrevCtrl) || panel_Customer.Contains(e.PrevCtrl))
                                    {
                                        _guideButton.SharedProps.Enabled = true;
                                    }
                                    // --- UPD 2010/08/30 ----------------------------------<<<<<
                                    // --- ADD 2010/08/31 ----------------------------------<<<<<
                                    if (this.tNedit_CustomerCode1.Focused)
                                    {
                                        e.NextCtrl = this.tNedit_CustomerCode1;
                                    }
                                    else if (this.tNedit_CustRateGrpCode1.Focused)
                                    {
                                        e.NextCtrl = this.tNedit_CustRateGrpCode1;
                                    }
                                    // --- ADD 2010/08/31 ---------------------------------->>>>>
                                }
                                else
                                {
                                    e.NextCtrl = null;
                                    this.uGrid_Details.Rows[0].Cells[_startIndex].Activate();
                                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                }
                            }
                            else if (e.Key == Keys.Up)
                            {
                                if (this.uGrid_Details.Rows.Count == 0)
                                {
                                    if ((Standard_UGroupBox.Expanded == false) &&
                                        (Standard_UGroupBox2.Expanded == false))
                                    {
                                        e.NextCtrl = e.PrevCtrl;
                                    }
                                    else if (Standard_UGroupBox.Expanded == true)
                                    {
                                        e.NextCtrl = this.tNedit_GoodsMakerCd;
                                        _guideButton.SharedProps.Enabled = true;
                                    }
                                    else
                                    {
                                        if ((int)this.tComboEditor_TargetDivide.Value == 0)
                                        {
                                            // 得意先掛率Ｇ
                                            e.NextCtrl = this.tNedit_CustRateGrpCode15;
                                            _guideButton.SharedProps.Enabled = true;
                                        }
                                        else
                                        {
                                            // 得意先
                                            e.NextCtrl = this.tNedit_CustomerCode15;
                                            _guideButton.SharedProps.Enabled = true;
                                        }
                                    }
                                }
                                else
                                {
                                    e.NextCtrl = null;
                                    this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[_startIndex].Activate();
                                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                }
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                if (this.uGrid_Details.Rows.Count == 0)
                                {
                                }
                                else
                                {
                                    e.NextCtrl = null;
                                    this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[_startIndex + (this._targetDic.Keys.Count - 1)].Activate();
                                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                }
                            }
                        }
                        break;
                    }
            }
        }
        // ADD 2010/08/27 ---- >>>>>
        /// <summary>
        /// 次入力可能セル移動処理
        /// </summary>
        /// <param name="activeCellCheck">true:ActiveCellが入力可能の場合はNextに移動させない false:ActiveCellに関係なくNextに移動させる</param>
        /// <returns>true:セル移動完了 false:セル移動失敗</returns>
        /// <remarks>
        /// <br>Note       : 次入力可能セル移動を処理します。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2010/08/27</br>
        /// </remarks>
        private bool MoveNextAllowEditCell(bool activeCellCheck)
        {
            this.uGrid_Details.SuspendLayout();
            bool moved = false;
            bool performActionResult = false;

            if ((activeCellCheck) && (this.uGrid_Details.ActiveCell != null))
            {
                if ((!this.uGrid_Details.ActiveCell.Column.Hidden) &&
                    (this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                    (this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                {
                    moved = true;
                }
            }

            while (!moved)
            {
                performActionResult = this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCell);

                if (performActionResult)
                {
                    if ((this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                        (this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                    {
                        moved = true;
                    }
                    else
                    {
                        moved = false;
                    }
                }
                else
                {
                    break;
                }
            }

            if (moved)
            {
                this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
            }

            this.uGrid_Details.ResumeLayout();
            return performActionResult;
        }
        // ADD 2010/08/27 ---- <<<<<
        #endregion ■ Control Events

    }
}
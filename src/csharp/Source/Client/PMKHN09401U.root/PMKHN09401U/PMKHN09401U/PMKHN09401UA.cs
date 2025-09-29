//**********************************************************************//
// システム         ：.NSシリーズ
// プログラム名称   ：掛率マスタ一括登録・修正
// プログラム概要   ：掛率マスタの登録・修正をを一括で行う
// ---------------------------------------------------------------------//
//					Copyright(c) 2008 Broadleaf Co.,Ltd.				//
// =====================================================================//
// 履歴
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30414 忍 幸史
// 修正日    2009/01/19     修正内容：新規作成
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30413 犬飼
// 修正日    2009/06/19     修正内容：Mantis【13570】フォーカス制御を修正
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30413 犬飼
// 修 正 日  2009/06/29     修正内容：MANTIS【13351】対応
//----------------------------------------------------------------------//
// 管理番号                 作成担当：30413 犬飼
// 修正日    2009/06/30     修正内容：Mantis【13672】フォーカス制御を修正
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30434 犬飼
// 修正日    2009/12/01     修正内容：得意先掛率グループ改良
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30517 夏野 駿希
// 修正日    2010/01/19     修正内容：Mantis:14899　全社指定の場合ログイン拠点で抽出される件の修正
//                                    Mantis:14909　複数の得意先掛率Gに値がある場合、検索すると1つしか表示されない件の修正
//                                    Mantis:14925　保存ボタンの動きに不正がある件の修正
//                                    Mantis:14933　得意先掛率グループコード=0のデータの保存が行えない件の修正
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30517 夏野 駿希
// 修正日    2010/05/14     修正内容：Mantis:15391　得意先掛率Ｇコード『0000』をメンテ対象とし、仕入率が設定されている場合、
//                                                  売価率『0000』が空白で保存すると仕入率が削除される不具合の修正
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：PM1012C 朱 猛
// 修正日    2010/08/10     修正内容：キーボード操作の改良を行う
// ---------------------------------------------------------------------//
// 管理番号  10901273-00    作成担当 : 李占川
// 修 正 日  2013/04/15     修正内容 : 2013/05/15配信分 Redmine#35352
//                                     メニューのファイルのリストの修正。「PMKHN09300UA.designer.cs」のみを修正する
//----------------------------------------------------------------------------//
// 管理番号                 作成担当 : liuyu
// 修 正 日  2013/07/08     修正内容 : Redmine#37884
//                                     掛率マスタ一括登録修正既存障害の対応依頼
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
    /// 掛率マスタ一括修正・登録UIクラス
    /// </summary>
    /// <remarks>
    /// <br>Note        : 掛率マスタ一括修正・登録UIフォームクラス</br>
    /// <br>Programmer  : 30414 忍 幸史</br>
    /// <br>Date        : 2009/01/19</br>
    /// <br>UpdateNote  : キーボード操作の改良を行う</br>
    /// <br>Programmer  : PM1012C 朱 猛</br>
    /// <br>Date        : 2010/08/10</br>
    /// <br>UpdateNote  : 2013/04/15 李占川</br>
    /// <br>管理番号    : 10901273-00 2013/05/15配信分 </br>
    /// <br>            : Redmine#35352 メニューのファイルのリストの修正。「PMKHN09300UA.designer.cs」のみを修正する</br>
    /// <br>UpdateNote  : Redmine#37884 掛率マスタ一括登録修正既存障害の対応依頼</br>
    /// <br>Programmer  : liuyu</br>
    /// <br>Date        : 2013/07/08</br>
    /// </remarks>
    public partial class PMKHN09401UA : Form
    {
        #region ■ Constants

        // アセンブリID
        private const string ASSEMBLY_ID = "PMKHN09401U";

        // 画面状態保存用ファイル名
        private const string XML_FILE_INITIAL_DATA = "PMKHN09401U.dat";

        // グリッド列
        public const string COLUMN_NO = "No";
        public const string COLUMN_GOODSRATEGRPCODE = "GoodsRateGrpCode";
        public const string COLUMN_BLCD = "Blcd";
        public const string COLUMN_NAME = "Name";
        public const string COLUMN_MAKERCODE = "MakerCode";
        public const string COLUMN_MAKERNAME = "MakerName";
        public const string COLUMN_SUPPLIERCODE = "SupplierCode";
        public const string COLUMN_COSTRATE = "CostRate";
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
        public const string COLUMN_PARENTDIV = "ParentDiv";
        public const string COLUMN_EXPANDFLG = "ExpandFlg";
        public const string COLUMN_GOODSRATEGRPCODE_HIDE = "GoodsRateGrpCodeClone";

        public const int COLINDEX_SALERATE_ST = 8;
        public const int COLINDEX_SALERATE_ED = 28;

        private const string FORMAT = "N";

        #endregion ■ Constants


        #region ■ Private Members

        private ControlScreenSkin _controlScreenSkin;

        private string _enterpriseCode;

        private SecInfoAcs _secInfoAcs;                                 // 拠点情報アクセスクラス
        private SecInfoSetAcs _secInfoSetAcs;                           // 拠点情報設定アクセスクラス
        private SupplierAcs _supplierAcs;                               // 仕入先アクセスクラス
        private MakerAcs _makerAcs;                                     // メーカーアクセスクラス
        private GoodsGroupUAcs _goodsGroupUAcs;                         // 商品掛率Ｇアクセスクラス
        private CustomerSearchAcs _customerSearchAcs;                   // 得意先情報アクセスクラス
        private UserGuideAcs _userGuideAcs;                             // ユーザーガイドアクセスクラス
        private RatePackageUpdateAcs _ratePackageUpdateAcs;             // 掛率マスタ一括修正・登録アクセスクラス

        // グリッド設定制御クラス
        private GridStateController _gridStateController;

        private Dictionary<string, SecInfoSet> _secInfoSetDic;
        private Dictionary<int, Supplier> _supplierDic;
        private Dictionary<int, MakerUMnt> _makerDic;
        private Dictionary<int, GoodsGroupU> _goodsGroupUDic;
        private Dictionary<int, CustomerSearchRet> _customerSearchRetDic;
        private Dictionary<int, string> _custRateGrpDic;

        private TNedit[] _tNedit_CustomerCode;
        private TNedit[] _tNedit_CustRateGrpCode;

        private string _searchSectionCode;
        private int _targetDivide;
        private Dictionary<int, int> _targetDic = new Dictionary<int,int>();
        private List<RateSearchResult> _parentList;
        private List<RateSearchResult> _childList;
        private List<RateSearchResult> _displayList;
        private Dictionary<int, ArrayList> _parentChildIndexDic;
        // 2010/01/19 Add >>>
        // 掛率取得用のリスト
        private List<RateSearchResult> _parentRateValList;
        private List<RateSearchResult> _childRateValList;
        // 2010/01/19 Add <<<

        private RateSearchParam _extrInfo;

        private bool _prevAllExpand;
        private bool _closeFlg;

        // ---ADD 2010/08/10-------------------->>>
        private object _preComboEditorValue = null;
        private string _tNedit_CustomerCodeName = null;
        // ---ADD 2010/08/10--------------------<<<

        // --- ADD 2010/08/31 ---------------------------------->>>>>
        // フォーカス制御用
        TNedit _preCtrl = null;
        // 得意先コードチェック用
        private CustomerInputAcs _customerInputAcs = null;
        // 前回のコード
        private string _prevCode = null;
        private bool searchFlag = false;
        // --- ADD 2010/08/31 ----------------------------------<<<<<

        #endregion ■ Private Members


        #region ■ Constructor

        /// <summary>
        /// 掛率マスタ一括修正・登録UIクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note        : 掛率マスタ一括修正・登録UIフォームクラスのインスタンスを生成します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2009/01/19</br>
        /// </remarks>
        public PMKHN09401UA()
		{
			InitializeComponent();
            
            this._controlScreenSkin = new ControlScreenSkin();
            
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            this._secInfoAcs = new SecInfoAcs();
            this._secInfoSetAcs = new SecInfoSetAcs();
            this._supplierAcs = new SupplierAcs();
            this._makerAcs = new MakerAcs();
            this._goodsGroupUAcs = new GoodsGroupUAcs();
            this._customerSearchAcs = new CustomerSearchAcs();
            this._userGuideAcs = new UserGuideAcs();
            this._ratePackageUpdateAcs = new RatePackageUpdateAcs();

            this._gridStateController = new GridStateController();

            // --- ADD 2010/08/31 ----------------------------------<<<<<
            // 得意先コードチェック用
            this._customerInputAcs = new CustomerInputAcs();
            this._prevCode = this.tEdit_SectionCodeAllowZero.Text;
            // --- ADD 2010/08/31 ----------------------------------<<<<<

            // マスタ読込
            ReadSecInfoSet();
            ReadSupplier();
            ReadMakerUMnt();
            ReadGoodsGroupU();
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
        /// <br>Programmer	: 30414 忍 幸史</br>
        /// <br>Date		: 2009/01/19</br>
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
        /// <br>Programmer	: 30414 忍 幸史</br>
        /// <br>Date		: 2009/01/19</br>
        /// </remarks>
        public void SaveStateXmlData()
        {
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
        }
        #endregion XML操作

        #region マスタ読込
        /// <summary>
        /// 拠点情報マスタ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 拠点情報マスタを読み込み、バッファに保持します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2009/01/19</br>
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
        /// 仕入先マスタ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 仕入先マスタを読み込み、バッファに保持します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2009/01/19</br>
        /// </remarks>
        private void ReadSupplier()
        {
            this._supplierDic = new Dictionary<int, Supplier>();

            try
            {
                ArrayList retList;

                int status = this._supplierAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (Supplier supplier in retList)
                    {
                        if (supplier.LogicalDeleteCode == 0)
                        {
                            this._supplierDic.Add(supplier.SupplierCd, supplier);
                        }
                    }
                }
            }
            catch
            {
                this._supplierDic = new Dictionary<int, Supplier>();
            }
        }

        /// <summary>
        /// メーカーマスタ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : メーカーマスタを読み込み、バッファに保持します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2009/01/19</br>
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
        /// 商品掛率Ｇマスタ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 商品掛率Ｇマスタを読み込み、バッファに保持します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2009/01/19</br>
        /// </remarks>
        private void ReadGoodsGroupU()
        {
            this._goodsGroupUDic = new Dictionary<int,GoodsGroupU>();

            try
            {
                ArrayList retList;

                int status = this._goodsGroupUAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (GoodsGroupU goodsGroupU in retList)
                    {
                        if (goodsGroupU.LogicalDeleteCode == 0)
                        {
                            this._goodsGroupUDic.Add(goodsGroupU.GoodsMGroup, goodsGroupU);
                        }
                    }
                }
            }
            catch
            {
                this._goodsGroupUDic = new Dictionary<int, GoodsGroupU>();
            }
        }

        /// <summary>
        /// 得意先マスタ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 得意先マスタを読み込み、バッファに保持します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2009/01/19</br>
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
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2009/01/19</br>
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

        #endregion マスタ読込

        #region 名称取得
        /// <summary>
        /// 拠点略称取得処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>拠点名</returns>
        /// <remarks>
        /// <br>Note        : 拠点コードに該当する拠点略称を取得します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2009/01/19</br>
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
        /// 仕入先略称取得処理
        /// </summary>
        /// <param name="supplierCode">仕入先コード</param>
        /// <returns>略称</returns>
        /// <remarks>
        /// <br>Note        : 仕入先コードに該当する略称を取得します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2009/01/19</br>
        /// </remarks>
        private string GetSupplierName(int supplierCode)
        {
            if (this._supplierDic.ContainsKey(supplierCode))
            {
                return this._supplierDic[supplierCode].SupplierSnm.Trim();
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
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2009/01/19</br>
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
        /// 商品掛率Ｇ名称取得処理
        /// </summary>
        /// <param name="makerCode">商品掛率Ｇコード</param>
        /// <returns>商品掛率Ｇ名称</returns>
        /// <remarks>
        /// <br>Note        : 商品掛率Ｇコードに該当する名称を取得します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2009/01/19</br>
        /// </remarks>
        private string GetGoodsGroupName(int goodsGroupCode)
        {
            if (this._goodsGroupUDic.ContainsKey(goodsGroupCode))
            {
                return this._goodsGroupUDic[goodsGroupCode].GoodsMGroupName.Trim();
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
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2009/01/19</br>
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
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2009/01/19</br>
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

        // ADD 2009/06/29 ------>>>
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

        /// <summary>
        /// 仕入先存在チェック処理
        /// </summary>
        /// <param name="supplierCode">仕入先コード</param>
        /// <returns>true：OK、false：NG</returns>
        /// <remarks>
        /// <br>Note       : 仕入先が存在するかチェックします。</br>
        /// <br></br>
        /// </remarks>
        private bool CheckSupplier(int supplierCode)
        {
            bool check = false;

            try
            {
                if (this._supplierDic.ContainsKey(supplierCode))
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
        // ADD 2009/06/29 ------<<<

        #region 初期設定
        /// <summary>
        /// 画面初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 画面情報の初期設定を行います。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2009/01/19</br>
        /// <br>UpdateNote  : キーボード操作の改良を行う。</br>
        /// <br>Programmer  : PM1012C 朱 猛</br>
        /// <br>Date        : 2010/08/10</br>
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
            this.tEdit_SectionCodeAllowZero.Size = new Size(28, 24);
            this.tEdit_SectionName.Size = new Size(175, 24);
            this.tNedit_SupplierCd.Size = new Size(59, 24);
            this.tEdit_SupplierName.Size = new Size(175, 24);
            this.tNedit_GoodsMGroup.Size = new Size(59, 24);
            this.tEdit_GoodsRateGrpName.Size = new Size(175, 24);
            this.tNedit_GoodsMakerCd.Size = new Size(59, 24);
            this.tEdit_MakerName.Size = new Size(175, 24);

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
            ButtonTool workButton;
            workButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Close"];
            workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
            workButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Save"];
            workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
            workButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Search"];
            workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SEARCH;
            workButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Undo"];
            workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.ALLCANCEL;
            workButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Renewal"];
            workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.RENEWAL;
            // ---ADD 2010/08/10-------------------->>>
            workButton = (ButtonTool)this.tToolbarsManager_MainMenu.Tools["ButtonTool_Guide"];
            workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.GUIDE;
            // ---ADD 2010/08/10--------------------<<<

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
            this.SupplierGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.GoodsRateGrpGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.MakerGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];

            //---------------------------------
            // グリッド設定
            //---------------------------------
            CreateGrid(ref this.uGrid_Details);
        }
        #endregion 初期設定

        #region クリア処理
        /// <summary>
        /// 画面情報クリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 画面情報をクリアします。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2009/01/19</br>
        /// </remarks>
        private void ClearScreen()
        {
            // 拠点コード
            this.tEdit_SectionCodeAllowZero.DataText = "00";
            this.tEdit_SectionName.DataText = "全社";
            // 仕入先コード
            this.tNedit_SupplierCd.Clear();
            this.tEdit_SupplierName.Clear();
            // 商品掛率Ｇコード
            this.tNedit_GoodsMGroup.Clear();
            this.tEdit_GoodsRateGrpName.Clear();
            // メーカーコード
            this.tNedit_GoodsMakerCd.Clear();
            this.tEdit_MakerName.Clear();
            // 対象区分
            this.tComboEditor_TargetDivide.Value = 0;

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
            this.tEdit_SectionCodeAllowZero.Focus();
            // ---ADD 2010/08/10-------------------->>>
            ((ButtonTool)this.tToolbarsManager_MainMenu.Tools[15]).SharedProps.Enabled = true;
            // ---ADD 2010/08/10--------------------<<<
        }

        /// <summary>
        /// グリッド初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : グリッドを初期化を行います。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2009/01/19</br>
        /// </remarks>
        private void ClearGrid()
        {
            this._targetDic = new Dictionary<int, int>();
            this._displayList = new List<RateSearchResult>();
            this._parentList = new List<RateSearchResult>();
            this._childList = new List<RateSearchResult>();
            this._parentChildIndexDic = new Dictionary<int, ArrayList>();

            this._prevAllExpand = false;

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
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2009/01/19</br>
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
                    this.tEdit_SectionCodeAllowZero.Focus();
                    // ---ADD 2010/08/10-------------------->>>
                    ((ButtonTool)this.tToolbarsManager_MainMenu.Tools[15]).SharedProps.Enabled = true;
                    // ---ADD 2010/08/10--------------------<<<
                    return (status);
                }
                if ((saveList.Count == 0) && (deleteList.Count == 0))
                {
                    errMsg = "保存対象データが存在しません。";
                    this.uGrid_Details.Rows[0].Cells[COLUMN_COSTRATE].Activate();
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

            try
            {
                // TODO:削除処理
                if (deleteList.Count > 0)
                {
                    status = this._ratePackageUpdateAcs.Delete(deleteList);
                    switch (status)
                    {
                        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                            {
                                break;
                            }
                        case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                        case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                            {
                                if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)
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

                                this.tEdit_SectionCodeAllowZero.Focus();
                                // ---ADD 2010/08/10-------------------->>>
                                ((ButtonTool)this.tToolbarsManager_MainMenu.Tools[15]).SharedProps.Enabled = true;
                                // ---ADD 2010/08/10--------------------<<<
                                return (status);
                            }
                        default:
                            {
                                ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                               "Save",
                                               "保存処理に失敗しました。",
                                               status,
                                               MessageBoxButtons.OK);

                                this.tEdit_SectionCodeAllowZero.Focus();
                                // ---ADD 2010/08/10-------------------->>>
                                ((ButtonTool)this.tToolbarsManager_MainMenu.Tools[15]).SharedProps.Enabled = true;
                                // ---ADD 2010/08/10--------------------<<<
                                return (status);
                            }
                    }
                }

                // TODO:更新処理
                if (saveList.Count > 0)
                {
                    status = this._ratePackageUpdateAcs.Write(saveList);
                    switch (status)
                    {
                        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                            {
                                break;
                            }
                        case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                        case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                            {
                                if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)
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

                                this.tEdit_SectionCodeAllowZero.Focus();
                                // ---ADD 2010/08/10-------------------->>>
                                ((ButtonTool)this.tToolbarsManager_MainMenu.Tools[15]).SharedProps.Enabled = true;
                                // ---ADD 2010/08/10--------------------<<<
                                return (status);
                            }
                        default:
                            {
                                ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                           "Save",
                                           "保存処理に失敗しました。",
                                           status,
                                           MessageBoxButtons.OK);

                                this.tEdit_SectionCodeAllowZero.Focus();
                                // ---ADD 2010/08/10-------------------->>>
                                ((ButtonTool)this.tToolbarsManager_MainMenu.Tools[15]).SharedProps.Enabled = true;
                                // ---ADD 2010/08/10--------------------<<<
                                return (status);
                            }
                    }
                }

                // 再検索
                List<RateSearchResult> rateSearchResultList;
                status = this._ratePackageUpdateAcs.Search(out rateSearchResultList, this._extrInfo);
                if (status == 0)
                {
                    // グリッド表示リスト取得
                    GetDisplayList(rateSearchResultList);
                }

                // 登録完了ダイアログ表示
                SaveCompletionDialog dialog = new SaveCompletionDialog();
                dialog.ShowDialog(2);
            }
            catch
            {
            }

            return (status);
        }
        #endregion 保存

        // ADD 2009/12/01 3次分対応 得意先掛率グループ改良 ---------->>>>>
        /// <summary>得意先掛率グループの指定なし</summary>
        private const int ALL_CUST_RATE_GRP_CODE = -1;  // FIXME:得意先掛率グループコード
        // ADD 2009/12/01 3次分対応 得意先掛率グループ改良 ----------<<<<<

        #region 検索
        /// <summary>
        /// 検索処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 検索処理を行います。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2009/01/19</br>
        /// </remarks>
        private int Search()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

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

                // FIXME:得意先掛率Ｇ
                // ADD 2009/12/01 3次分対応 得意先掛率グループ改良 ---------->>>>>
                if (this.chkSearchingAll.Checked)
                {
                    this._targetDic.Add(ALL_CUST_RATE_GRP_CODE, ALL_CUST_RATE_GRP_CODE);
                }
                // ADD 2009/12/01 3次分対応 得意先掛率グループ改良 ----------<<<<<
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

            // 検索条件格納
            SetExtrInfo(out this._extrInfo);

            // 抽出中画面部品のインスタンスを作成
            SFCMN00299CA msgForm = new SFCMN00299CA();
            msgForm.Title = "抽出中";
            msgForm.Message = "掛率マスタの抽出中です。";

            List<RateSearchResult> rateSearchResultList;

            try
            {
                msgForm.Show();

                // TODO:検索処理
                status = this._ratePackageUpdateAcs.Search(out rateSearchResultList, this._extrInfo);
                if (status == 0)
                {
                    // グリッド表示リスト取得
                    GetDisplayList(rateSearchResultList);

                    // グリッドデータ設定
                    CreateGrid(ref this.uGrid_Details);

                    // グリッド行カラー設定
                    SetRowColor(ref this.uGrid_Details);

                    // 全展開ボタン押下可
                    this.uGrid_Details.ActiveRow = null;
                    this.AllExpand_Button.Enabled = true;
                    this.AllExpand_Button.Focus();
                    // ---ADD 2010/08/10-------------------->>>
                    ((ButtonTool)this.tToolbarsManager_MainMenu.Tools[15]).SharedProps.Enabled = false;
                    // ---ADD 2010/08/10--------------------<<<

                    // 検索後は子明細は非展開
                    this._prevAllExpand = true;
                    AllExpand_Button_Click(this.AllExpand_Button, new EventArgs());

                    return (status);
                }
            }
            finally
            {
                msgForm.Close();
            }

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
        /// 検索条件設定処理
        /// </summary>
        /// <param name="para">検索条件</param>
        /// <remarks>
        /// <br>Note        : 画面情報から検索条件を設定します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2009/01/19</br>
        /// </remarks>
        private void SetExtrInfo(out RateSearchParam para)
        {
            para = new RateSearchParam();

            // 企業コード
            para.EnterpriseCode = this._enterpriseCode;

            // 拠点
            if ((this.tEdit_SectionCodeAllowZero.DataText.Trim() == "") ||
                (this.tEdit_SectionCodeAllowZero.DataText.Trim().PadLeft(2, '0') == "00"))
            {
                // 全社指定
                // 2010/01/19 全社指定の場合はNullではなく00をセット >>>
                //para.SectionCode = null;
                para.SectionCode = new string[1];
                para.SectionCode[0] = "00";
                // 2010/01/19 <<<
            }
            else
            {
                para.SectionCode = new string[1];
                para.SectionCode[0] = this.tEdit_SectionCodeAllowZero.DataText.Trim().PadLeft(2, '0');
            }

            // 仕入先
            para.SupplierCd = this.tNedit_SupplierCd.GetInt();

            // 商品掛率Ｇ
            para.GoodsRateGrpCode = this.tNedit_GoodsMGroup.GetInt();

            // メーカー
            para.GoodsMakerCd = this.tNedit_GoodsMakerCd.GetInt();

            if ((int)this.tComboEditor_TargetDivide.Value == 0)
            {
                // 得意先掛率Ｇ
                para.CustRateGrpCode = new int[this._targetDic.Keys.Count];
                // ADD 2009/12/01 3次分対応 得意先掛率グループ改良 ---------->>>>>
                if (this.chkSearchingAll.Checked)
                {
                    // FIXME:得意先掛率グループコード=-1は検索条件に入れない
                    para.CustRateGrpCode = new int[this._targetDic.Keys.Count - 1];
                }
                // ADD 2009/12/01 3次分対応 得意先掛率グループ改良 ----------<<<<<

                int index = 0;
                foreach (int key in this._targetDic.Keys)
                {
                    // ADD 2009/12/01 3次分対応 得意先掛率グループ改良 ---------->>>>>
                    if (this.chkSearchingAll.Checked && key < 0)
                    {
                        #region ボツ
                        //if (para.CustRateGrpCode.Length < this._targetDic.Keys.Count)
                        //{
                        //    para.CustRateGrpCode = new int[this._targetDic.Keys.Count];
                        //    para.CustRateGrpCode[index] = 0;
                        //    index++;
                        //}
                        #endregion
                        continue;   // FIXME:得意先掛率グループコード=-1は検索条件に入れない
                    }
                    // ADD 2009/12/01 3次分対応 得意先掛率グループ改良 ----------<<<<<

                    para.CustRateGrpCode[index] = key;
                    index++;
                }

                // ADD 2009/12/01 3次分対応 得意先掛率グループ改良 ---------->>>>>
                // HACK:得意先掛率グループコード(=-1)：指定なし分
                if (para.CustRateGrpCode.Length > this._targetDic.Keys.Count)
                {
                    // this._targetDic の先頭に"指定なし"を追加しているので 0 番目
                    para.CustRateGrpCode[0] = ALL_CUST_RATE_GRP_CODE;
                }
                // ADD 2009/12/01 3次分対応 得意先掛率グループ改良 ----------<<<<<
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
            this._targetDivide = (int)this.tComboEditor_TargetDivide.Value;
            this._searchSectionCode = this.tEdit_SectionCodeAllowZero.DataText.Trim().PadLeft(2, '0');
        }
        #endregion 検索

        #region データ取得
        /// <summary>
        /// グリッド表示リスト取得処理
        /// </summary>
        /// <param name="rateSearchResultList">掛率マスタ検索結果リスト</param>
        /// <remarks>
        /// <br>Note        : グリッドに表示するリストを取得します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2009/01/19</br>
        /// </remarks>
        private void GetDisplayList(List<RateSearchResult> rateSearchResultList)
        {
            this._parentList = new List<RateSearchResult>();
            this._childList = new List<RateSearchResult>();
            this._displayList = new List<RateSearchResult>();

            // 2010/01/19 Add >>>
            this._parentRateValList = new List<RateSearchResult>();
            this._childRateValList = new List<RateSearchResult>();
            // 2010/01/19 Add <<<

            //---------------------------
            // 親データ取得
            //---------------------------
            this._parentList = rateSearchResultList.FindAll(delegate(RateSearchResult target)
            {
                if (target.PrmTbsPartsCode == 0)
                {
                    return (true);
                }
                else
                {
                    return (false);
                }
            });
            // 重複しているデータがある場合は、最小ロット数のデータを取得
            Dictionary<string, RateSearchResult> parentDic = new Dictionary<string, RateSearchResult>();
            foreach (RateSearchResult result in this._parentList)
            {
                string key = MakeParentKey(result);
                if (!parentDic.ContainsKey(key))
                {
                    parentDic.Add(key, result.Clone());
                }
                else
                {
                    if (result.LotCount < parentDic[key].LotCount)
                    {
                        parentDic[key] = result.Clone();
                    }
                }
            }
            this._parentRateValList = this._parentList; // 2010/01/19 Add 掛率取得用に親データ退避
            this._parentList = new List<RateSearchResult>();
            foreach (RateSearchResult result in parentDic.Values)
            {
                this._parentList.Add(result.Clone());
            }

            //---------------------------
            // 子データ取得
            //---------------------------
            this._childList = rateSearchResultList.FindAll(delegate(RateSearchResult target)
            {
                if (target.PrmTbsPartsCode != 0)
                {
                    return (true);
                }
                else
                {
                    return (false);
                }
            });
            // 重複しているデータがある場合は、最小ロット数のデータを取得
            Dictionary<string, RateSearchResult> childDic = new Dictionary<string, RateSearchResult>();
            foreach (RateSearchResult result in this._childList)
            {
                string key = MakeChildKey(result);
                if (!childDic.ContainsKey(key))
                {
                    childDic.Add(key, result.Clone());
                }
                else
                {
                    if (result.LotCount < childDic[key].LotCount)
                    {
                        childDic[key] = result.Clone();
                    }
                }
            }
            this._childRateValList = this._childList; // 2010/01/19 Add 掛率取得用に子データ退避
            this._childList = new List<RateSearchResult>();
            foreach (RateSearchResult result in childDic.Values)
            {
                this._childList.Add(result.Clone());
            }

            //---------------------------
            // 表示リスト取得(親)
            //---------------------------
            Dictionary<string, RateSearchResult> parentDispList = new Dictionary<string, RateSearchResult>();
            foreach (RateSearchResult parentResult in this._parentList)
            {
                string key = MakeParentKey(parentResult);

                if (parentDispList.ContainsKey(key))
                {
                    continue;
                }

                // 表示リストに追加
                parentDispList.Add(key, parentResult);
            }

            //---------------------------
            // 表示リスト取得(親子)
            //---------------------------
            Dictionary<string, RateSearchResult> childDispDic = new Dictionary<string, RateSearchResult>();
            this._parentChildIndexDic = new Dictionary<int, ArrayList>();
            ArrayList childIndexList;

            int parentIndex = 0;

            foreach (string key in parentDispList.Keys)
            {
                childIndexList = new ArrayList();

                // 親を追加
                this._displayList.Add(((RateSearchResult)parentDispList[key]).Clone());

                // 親に関連付く子を取得
                List<RateSearchResult> childDispList = this._childList.FindAll(delegate(RateSearchResult target)
                {
                    if (key == MakeParentKey(target))
                    {
                        return (true);
                    }
                    else
                    {
                        return (false);
                    }
                });

                // 子を追加
                int childIndex = parentIndex + 1;
                if (childDispList != null)
                {
                    foreach (RateSearchResult result in childDispList)
                    {
                        string childKey = MakeChildKey(result);

                        if (childDispDic.ContainsKey(childKey))
                        {
                            continue;
                        }
                        childDispDic.Add(childKey, result.Clone());

                        this._displayList.Add(result.Clone());

                        childIndexList.Add(childIndex);
                        childIndex++;
                    }

                    this._parentChildIndexDic.Add(parentIndex, childIndexList);

                    parentIndex = childIndex;
                }
                else
                {
                    this._parentChildIndexDic.Add(parentIndex, null);

                    parentIndex++;
                }
            }
        }

        /// <summary>
        /// 更新データ取得処理
        /// </summary>
        /// <param name="saveList">保存リスト</param>
        /// <param name="deleteList">削除リスト</param>
        /// <remarks>
        /// <br>Note        : 更新データを取得します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2009/01/19</br>
        /// </remarks>
        private void GetUpdateList(out ArrayList saveList, out ArrayList deleteList)
        {
            saveList = new ArrayList();
            deleteList = new ArrayList();

            string key;
            List<RateSearchResult> resultList;

            Rate updateRate = new Rate();

            this.uGrid_Details.ActiveCell = null;

            for (int rowIndex = 0; rowIndex < this.uGrid_Details.Rows.Count; rowIndex++)
            {
                CellsCollection cells = this.uGrid_Details.Rows[rowIndex].Cells;

                // 親子区分
                int parentDiv = IntObjToInt(cells[COLUMN_PARENTDIV].Value);
                if (parentDiv == 0)
                {
                    //----------------
                    // 親明細
                    //----------------

                    key = MakeParentKey(StrObjToInt(cells[COLUMN_GOODSRATEGRPCODE].Value),
                                        StrObjToInt(cells[COLUMN_MAKERCODE].Value),
                                        StrObjToInt(cells[COLUMN_SUPPLIERCODE].Value));

                    // 2010/01/19 >>>
                    //resultList = this._parentList.FindAll(delegate(RateSearchResult target)
                    resultList = this._parentRateValList.FindAll(delegate(RateSearchResult target)
                    // 2010/01/19 <<<
                    {
                        if (key == MakeParentKey(target))
                        {
                            // 2010/01/19 Add >>>
                            // HACK:単価掛率設定区分の設定が無い場合、新規
                            if (string.IsNullOrEmpty(target.UnitRateSetDivCd.Trim())) return false;
                            // 2010/01/19 Add <<<
                            return (true);
                        }
                        else
                        {
                            return (false);
                        }
                    });
                }
                else
                {
                    //----------------
                    // 子明細
                    //----------------

                    key = MakeChildKey(StrObjToInt(cells[COLUMN_GOODSRATEGRPCODE_HIDE].Value),
                                       StrObjToInt(cells[COLUMN_BLCD].Value),
                                       StrObjToInt(cells[COLUMN_MAKERCODE].Value),
                                       StrObjToInt(cells[COLUMN_SUPPLIERCODE].Value));

                    // 2010/01/19 >>>
                    //resultList = this._childList.FindAll(delegate(RateSearchResult target)
                    resultList = this._childRateValList.FindAll(delegate(RateSearchResult target)
                    // 2010/01/19 <<<
                    {
                        if (key == MakeChildKey(target))
                        {
                            // 2010/01/19 Add >>>
                            // HACK:単価掛率設定区分の設定が無い場合、新規
                            if (string.IsNullOrEmpty(target.UnitRateSetDivCd.Trim())) return false;
                            // 2010/01/19 Add <<<
                            return (true);
                        }
                        else
                        {
                            return (false);
                        }
                    });
                }

                if (resultList == null)
                {
                    continue;
                }

                // 仕入率チェック
                RateSearchResult result = resultList.Find(delegate(RateSearchResult target)
                {
                    if (target.UnitPriceKind == "2")
                    {
                        return (true);
                    }
                    else
                    {
                        return (false);
                    }
                });

                if (result != null)
                {
                    if (DoubleObjToDouble(cells[COLUMN_COSTRATE].Value) == 0)
                    {
                        //if (result.FileHeaderGuid != Guid.Empty) // DEL 2013/07/08 掛率マスタ一括登録修正既存障害の対応依頼
                        if (result.FileHeaderGuid != Guid.Empty && result.LogicalDeleteCode == 0) // ADD 2013/07/08 掛率マスタ一括登録修正既存障害の対応依頼
                        {
                            // データ削除
                            updateRate = CopyToRateFromRateSearchResult(result.Clone());
                            deleteList.Add(updateRate.Clone());
                        }
                    }
                    else
                    {
                        // データ更新
                        // 2010/01/19 Add 変更がない場合は更新用リストに追加しない >>>
                        if (result.RateVal != DoubleObjToDouble(cells[COLUMN_COSTRATE].Value))
                        {
                            // 2010/01/19 Add <<<
                            updateRate = CopyToRateFromRateSearchResult(result.Clone());
                            updateRate.RateVal = DoubleObjToDouble(cells[COLUMN_COSTRATE].Value);
                            saveList.Add(updateRate.Clone());
                        }   // 2010/01/19 Add
                    }
                }
                else
                {
                    if (DoubleObjToDouble(cells[COLUMN_COSTRATE].Value) != 0)
                    {
                        // データ追加
                        updateRate = CreateRate();
                        
                        if (parentDiv == 0)
                        {
                            updateRate.UnitRateSetDivCd = "25F";
                            updateRate.RateSettingDivide = "5F";
                            updateRate.RateMngGoodsCd = "F";
                            updateRate.RateMngGoodsNm = "ﾒｰｶｰ+商品掛率G";
                            updateRate.GoodsRateGrpCode = StrObjToInt(cells[COLUMN_GOODSRATEGRPCODE].Value);
                        }
                        else
                        {
                            updateRate.UnitRateSetDivCd = "25D";
                            updateRate.RateSettingDivide = "5D";
                            updateRate.RateMngGoodsCd = "D";
                            updateRate.RateMngGoodsNm = "ﾒｰｶｰ+BLｺｰﾄﾞ";
                            updateRate.BLGoodsCode = StrObjToInt(cells[COLUMN_BLCD].Value);
                        }
                        updateRate.UnitPriceKind = "2";
                        updateRate.RateMngCustCd = "5";
                        updateRate.RateMngCustNm = "仕入先";
                        updateRate.GoodsMakerCd = StrObjToInt(cells[COLUMN_MAKERCODE].Value);
                        updateRate.SupplierCd = StrObjToInt(cells[COLUMN_SUPPLIERCODE].Value);
                        updateRate.RateVal = DoubleObjToDouble(cells[COLUMN_COSTRATE].Value);

                        saveList.Add(updateRate.Clone());
                    }
                }

                // 売価率チェック
                foreach (int code in this._targetDic.Keys)
                {
                    if (this._targetDivide == 0)
                    {
                        result = resultList.Find(delegate(RateSearchResult target)
                        {
                            // 2010/05/14 Add >>>
                            if (target.UnitPriceKind != "1")
                                return false;
                            // 2010/05/14 Add <<<

                            // ADD 2009/12/01 3次分対応 得意先掛率グループ改良 ---------->>>>>
                            // FIXME:得意先掛率グループ"指定なし"
                            if (code < 0)
                            {
                                return IsAllCustRateGrpCode(target);
                            }
                            // ADD 2009/12/01 3次分対応 得意先掛率グループ改良 ----------<<<<<
                            //if (target.CustRateGrpCode == code) // DEL 2013/07/08 掛率マスタ一括登録修正既存障害の対応依頼
                            if (target.CustRateGrpCode == code && !IsAllCustRateGrpCode(target)) // ADD 2013/07/08 掛率マスタ一括登録修正既存障害の対応依頼
                            {
                                return (true);
                            }
                            else
                            {
                                return (false);
                            }
                        });
                    }
                    else
                    {
                        result = resultList.Find(delegate(RateSearchResult target)
                        {
                            // 2010/05/14 Add >>>
                            if (target.UnitPriceKind != "1")
                                return false;
                            // 2010/05/14 Add <<<

                            // ADD 2009/12/01 3次分対応 得意先掛率グループ改良 ---------->>>>>
                            // FIXME:得意先掛率グループ"指定なし"
                            if (code < 0)
                            {
                                return IsAllCustRateGrpCode(target);
                            }
                            // ADD 2009/12/01 3次分対応 得意先掛率グループ改良 ----------<<<<<
                            //if (target.CustomerCode == code) // DEL 2013/07/08 掛率マスタ一括登録修正既存障害の対応依頼
                            if (target.CustomerCode == code && !IsAllCustRateGrpCode(target)) // ADD 2013/07/08 掛率マスタ一括登録修正既存障害の対応依頼
                            {
                                return (true);
                            }
                            else
                            {
                                return (false);
                            }
                        });
                    }

                    if (result != null)
                    {
                        if (DoubleObjToDouble(cells[code.ToString()].Value) == 0)
                        {
                            // DEL 2013/07/08 掛率マスタ一括登録修正既存障害の対応依頼 ---------->>>>>
                            //if (result.FileHeaderGuid != Guid.Empty)
                            //{
                            //    // データ削除
                            //    updateRate = CopyToRateFromRateSearchResult(result.Clone());
                            //    deleteList.Add(updateRate.Clone());
                         
                            //}
                            // DEL 2013/07/08 掛率マスタ一括登録修正既存障害の対応依頼 ----------<<<<<
                            // ADD 2013/07/08 掛率マスタ一括登録修正既存障害の対応依頼 ---------->>>>>
                            if (result.FileHeaderGuid != Guid.Empty && result.LogicalDeleteCode == 0 && result.RateVal != DoubleObjToDouble(cells[code.ToString()].Value))
                            {
                                // 原価ＵＰ率、粗利確保率もない場合
                                if (result.UpRate == 0 && result.GrsProfitSecureRate == 0)
                                {
                                    // データ削除
                                    updateRate = CopyToRateFromRateSearchResult(result.Clone());
                                    deleteList.Add(updateRate.Clone());
                                }
                                // 原価ＵＰ率、粗利確保率がある場合
                                else
                                {
                                    // データ更新
                                    updateRate = CopyToRateFromRateSearchResult(result.Clone());
                                    updateRate.RateVal = DoubleObjToDouble(cells[code.ToString()].Value);
                                    saveList.Add(updateRate.Clone());
                                }
                            }
                            // ADD 2013/07/08 掛率マスタ一括登録修正既存障害の対応依頼 ----------<<<<<
                        }
                        else
                        {
                            // データ更新
                            // 2010/01/19 Add 変更がない場合は更新用リストに追加しない >>>
                            if (result.RateVal != DoubleObjToDouble(cells[code.ToString()].Value))
                            {
                                // 2010/01/19 Add <<<
                                updateRate = CopyToRateFromRateSearchResult(result.Clone());
                                updateRate.RateVal = DoubleObjToDouble(cells[code.ToString()].Value);
                                saveList.Add(updateRate.Clone());
                            }   // 2010/01/19 Add
                        }
                    }
                    else
                    {
                        if (DoubleObjToDouble(cells[code.ToString()].Value) != 0)
                        {
                            // HACK:データ追加
                            updateRate = CreateRate();

                            if (parentDiv == 0)
                            {
                                if (this._targetDivide == 0)
                                {
                                    // DEL 2009/12/01 3次分対応 得意先掛率グループ改良 ---------->>>>>
                                    //updateRate.UnitRateSetDivCd = "13F";
                                    //updateRate.RateSettingDivide = "3F";
                                    //updateRate.RateMngCustCd = "3";
                                    //updateRate.RateMngCustNm = "得意先掛率G+仕入先";
                                    //updateRate.CustRateGrpCode = code;
                                    // DEL 2009/12/01 3次分対応 得意先掛率グループ改良 ----------<<<<<
                                    // ADD 2009/12/01 3次分対応 得意先掛率グループ改良 ---------->>>>>
                                    // FIXME:13F または 15F
                                    updateRate.UnitRateSetDivCd = code >= 0 ? "13F" : "15F";
                                    updateRate.RateSettingDivide = code >= 0 ? "3F" : "5F";
                                    updateRate.RateMngCustCd = code >= 0 ? "3" : "5";
                                    updateRate.RateMngCustNm = code >= 0 ? "得意先掛率G+仕入先" : "仕入先";
                                    updateRate.CustRateGrpCode = code >= 0 ? code : 0;
                                    // ADD 2009/12/01 3次分対応 得意先掛率グループ改良 ----------<<<<<
                                }
                                else
                                {
                                    updateRate.UnitRateSetDivCd = "11F";
                                    updateRate.RateSettingDivide = "1F";
                                    updateRate.RateMngCustCd = "1";
                                    updateRate.RateMngCustNm = "得意先+仕入先";
                                    updateRate.CustomerCode = code;
                                }
                                updateRate.RateMngGoodsCd = "F";
                                updateRate.RateMngGoodsNm = "ﾒｰｶｰ+商品掛率G";
                                updateRate.GoodsRateGrpCode = StrObjToInt(cells[COLUMN_GOODSRATEGRPCODE].Value);
                            }
                            else
                            {
                                if (this._targetDivide == 0)
                                {
                                    // DEL 2009/12/01 3次分対応 得意先掛率グループ改良 ---------->>>>>
                                    //updateRate.UnitRateSetDivCd = "13D";
                                    //updateRate.RateSettingDivide = "3D";
                                    //updateRate.RateMngCustCd = "3";
                                    //updateRate.RateMngCustNm = "得意先掛率G+仕入先";
                                    //updateRate.CustRateGrpCode = code;
                                    // DEL 2009/12/01 3次分対応 得意先掛率グループ改良 ----------<<<<<
                                    // ADD 2009/12/01 3次分対応 得意先掛率グループ改良 ---------->>>>>
                                    // FIXME:13D または 15D
                                    updateRate.UnitRateSetDivCd = code >= 0 ? "13D" : "15D";
                                    updateRate.RateSettingDivide = code >= 0 ? "3D" : "5D";
                                    updateRate.RateMngCustCd = code >= 0 ? "3" : "5";
                                    updateRate.RateMngCustNm = code >= 0 ? "得意先掛率G+仕入先" : "仕入先";
                                    updateRate.CustRateGrpCode = code >= 0 ? code : 0;
                                    // ADD 2009/12/01 3次分対応 得意先掛率グループ改良 ----------<<<<<
                                }
                                else
                                {
                                    updateRate.UnitRateSetDivCd = "11D";
                                    updateRate.RateSettingDivide = "1D";
                                    updateRate.RateMngCustCd = "1";
                                    updateRate.RateMngCustNm = "得意先+仕入先";
                                    updateRate.CustomerCode = code;
                                }
                                updateRate.RateMngGoodsCd = "D";
                                updateRate.RateMngGoodsNm = "ﾒｰｶｰ+BLｺｰﾄﾞ";
                                updateRate.BLGoodsCode = StrObjToInt(cells[COLUMN_BLCD].Value);
                            }
                            updateRate.UnitPriceKind = "1";
                            updateRate.GoodsMakerCd = StrObjToInt(cells[COLUMN_MAKERCODE].Value);
                            updateRate.SupplierCd = StrObjToInt(cells[COLUMN_SUPPLIERCODE].Value);
                            updateRate.RateVal = DoubleObjToDouble(cells[code.ToString()].Value);

                            saveList.Add(updateRate.Clone());
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 掛率マスタ作成処理
        /// </summary>
        /// <returns>掛率マスタ</returns>
        /// <remarks>
        /// <br>Note        : 掛率マスタを新規作成します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2009/01/19</br>
        /// </remarks>
        private Rate CreateRate()
        {
            // 固定値のものだけセット
            Rate newRate = new Rate();
            
            newRate.EnterpriseCode = this._enterpriseCode;
            newRate.SectionCode = this._searchSectionCode;
            newRate.LotCount = 9999999.99;
            newRate.UnPrcFracProcUnit = 0;
            newRate.UnPrcFracProcDiv = 0;

            return newRate;
        }

        /// <summary>
        /// クラスメンバコピー処理
        /// </summary>
        /// <param name="result">掛率マスタ検索結果</param>
        /// <returns>掛率マスタ</returns>
        /// <remarks>
        /// <br>Note        : 掛率マスタ検索結果から掛率マスタを作成します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2009/01/19</br>
        /// </remarks>
        private Rate CopyToRateFromRateSearchResult(RateSearchResult result)
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
            newRate.BLGroupCode = result.BLGroupCode;
            newRate.BLGoodsCode = result.BLGoodsCode;
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
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2009/01/19</br>
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
                    // ---ADD 2010/08/10-------------------->>>
                    ((ButtonTool)this.tToolbarsManager_MainMenu.Tools[15]).SharedProps.Enabled = true;
                    // ---ADD 2010/08/10--------------------<<<
                    return (false);
                }

                string sectionCode = this.tEdit_SectionCodeAllowZero.DataText.Trim();

                if (GetSectionName(sectionCode) == "")
                {
                    errMsg = "マスタに登録されていません。";
                    this.tEdit_SectionCodeAllowZero.Focus();
                    // ---ADD 2010/08/10-------------------->>>
                    ((ButtonTool)this.tToolbarsManager_MainMenu.Tools[15]).SharedProps.Enabled = true;
                    // ---ADD 2010/08/10--------------------<<<
                    return (false);
                }

                // 仕入先
                if (this.tNedit_SupplierCd.GetInt() == 0)
                {
                    errMsg = "仕入先を入力してください。";
                    this.tNedit_SupplierCd.Focus();
                    // ---ADD 2010/08/10-------------------->>>
                    ((ButtonTool)this.tToolbarsManager_MainMenu.Tools[15]).SharedProps.Enabled = true;
                    // ---ADD 2010/08/10--------------------<<<
                    return (false);
                }

                int supplierCode = this.tNedit_SupplierCd.GetInt();

                //if (GetSupplierName(supplierCode) == "")  // DEL 2009/06/29
                if (!CheckSupplier(supplierCode))   // ADD 2009/06/29
                {
                    errMsg = "マスタに登録されていません。";
                    this.tNedit_SupplierCd.Focus();
                    // ---ADD 2010/08/10-------------------->>>
                    ((ButtonTool)this.tToolbarsManager_MainMenu.Tools[15]).SharedProps.Enabled = true;
                    // ---ADD 2010/08/10--------------------<<<
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
                                errMsg = "マスタに登録されていません。";
                                this._tNedit_CustRateGrpCode[index].Focus();
                                // ---ADD 2010/08/10-------------------->>>
                                ((ButtonTool)this.tToolbarsManager_MainMenu.Tools[15]).SharedProps.Enabled = true;
                                // ---ADD 2010/08/10--------------------<<<
                                return (false);
                            }

                            inputFlg = true;
                        }
                    }

                    // ADD 2009/12/01 3次分対応 得意先掛率グループ改良 ---------->>>>>
                    // TODO:得意先掛率グループの入力が無く、未設定チェックもない場合
                    if (!inputFlg) inputFlg = this.chkSearchingAll.Checked;
                    // ADD 2009/12/01 3次分対応 得意先掛率グループ改良 ----------<<<<<

                    if (inputFlg == false)
                    {
                        errMsg = "得意先掛率Ｇを入力してください。";
                        this._tNedit_CustRateGrpCode[0].Focus();
                        // ---ADD 2010/08/10-------------------->>>
                        ((ButtonTool)this.tToolbarsManager_MainMenu.Tools[15]).SharedProps.Enabled = true;
                        // ---ADD 2010/08/10--------------------<<<
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

                            //if (GetCustomerSnm(customerCode) == "")   // DEL 2009/06/29
                            if (!CheckCustomer(customerCode))   // ADD 2009/06/29
                            {
                                errMsg = "マスタに登録されていません。";
                                this._tNedit_CustomerCode[index].Focus();
                                // ---ADD 2010/08/10-------------------->>>
                                ((ButtonTool)this.tToolbarsManager_MainMenu.Tools[15]).SharedProps.Enabled = true;
                                // ---ADD 2010/08/10--------------------<<<
                                return (false);
                            }

                            inputFlg = true;
                        }
                    }

                    if (inputFlg == false)
                    {
                        errMsg = "得意先を入力してください。";
                        this._tNedit_CustomerCode[0].Focus();
                        // ---ADD 2010/08/10-------------------->>>
                        ((ButtonTool)this.tToolbarsManager_MainMenu.Tools[15]).SharedProps.Enabled = true;
                        // ---ADD 2010/08/10--------------------<<<
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
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2009/01/19</br>
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
        /// 画面情報比較処理
        /// </summary>
        /// <returns>ステータス(True:処理続行　False:処理中断)</returns>
        /// <remarks>
        /// <br>Note        : 画面情報を比較し、変更されている場合はメッセージを表示します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2009/01/19</br>
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
                                //this.uGrid_Details.ActiveCell = this._activeCell;
                                //this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
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
                            //this.uGrid_Details.ActiveCell = this._activeCell;
                            //this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
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
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2009/01/19</br>
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
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2009/01/19</br>
        /// </remarks>
        public void CreateGrid(ref UltraGrid uGrid)
        {
            DataTable dataTable = new DataTable();

            // No
            dataTable.Columns.Add(COLUMN_NO, typeof(int));
            // 商掛Ｇ
            dataTable.Columns.Add(COLUMN_GOODSRATEGRPCODE, typeof(string));
            // BLCD
            dataTable.Columns.Add(COLUMN_BLCD, typeof(string));
            // 名称
            dataTable.Columns.Add(COLUMN_NAME, typeof(string));
            // メーカーコード
            dataTable.Columns.Add(COLUMN_MAKERCODE, typeof(string));
            // メーカー名
            dataTable.Columns.Add(COLUMN_MAKERNAME, typeof(string));
            // 仕入先
            dataTable.Columns.Add(COLUMN_SUPPLIERCODE, typeof(string));
            // 仕入率
            dataTable.Columns.Add(COLUMN_COSTRATE, typeof(double));
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
                    dataTable.Columns.Add(key.ToString(), typeof(double));
                }
            }
            // 親子区分
            dataTable.Columns.Add(COLUMN_PARENTDIV, typeof(int));
            // 展開フラグ
            dataTable.Columns.Add(COLUMN_EXPANDFLG, typeof(bool));
            // 商品掛率グループコード(内部保持用)
            dataTable.Columns.Add(COLUMN_GOODSRATEGRPCODE_HIDE, typeof(string));

            uGrid.DataSource = dataTable;

            // グリッドスタイル設定
            SetGridLayout(ref uGrid);

            // データが無い場合
            if ((this._displayList == null) || (this._displayList.Count == 0))
            {
                return;
            }

            List<RateSearchResult> targetList;

            this.uGrid_Details.BeginUpdate();

            try
            {
                for (int index = 0; index < this._displayList.Count; index++)
                {
                    // 行追加
                    uGrid.DisplayLayout.Bands[0].AddNew();

                    CellsCollection cells = uGrid.Rows[index].Cells;

                    RateSearchResult result = (RateSearchResult)this._displayList[index];

                    // No
                    cells[COLUMN_NO].Value = index + 1;

                    if (result.PrmTbsPartsCode == 0)
                    {
                        // 商掛Ｇ
                        cells[COLUMN_GOODSRATEGRPCODE].Value = result.PrmGoodsMGroup.ToString("0000");
                        // BLCD
                        cells[COLUMN_BLCD].Value = DBNull.Value;
                        // 名称
                        cells[COLUMN_NAME].Value = GetGoodsGroupName(result.PrmGoodsMGroup);
                        // 親子区分
                        cells[COLUMN_PARENTDIV].Value = 0;

                        // 2010/01/19 >>>
                        //targetList = this._parentList.FindAll(delegate(RateSearchResult target)
                        targetList = this._parentRateValList.FindAll(delegate(RateSearchResult target)
                        // 2010/01/19 <<<
                        {
                            if (MakeParentKey(result) == MakeParentKey(target))
                            {
                                return (true);
                            }
                            else
                            {
                                return (false);
                            }
                        });
                    }
                    else
                    {
                        // 商掛Ｇ
                        cells[COLUMN_GOODSRATEGRPCODE].Value = DBNull.Value;
                        // BLCD
                        cells[COLUMN_BLCD].Value = result.PrmTbsPartsCode.ToString("00000");
                        // 名称
                        cells[COLUMN_NAME].Value = result.BLGoodsHalfName.Trim();
                        // 親子区分
                        cells[COLUMN_PARENTDIV].Value = 1;

                        // 2010/01/19 >>>
                        //targetList = this._childList.FindAll(delegate(RateSearchResult target)
                        targetList = this._childRateValList.FindAll(delegate(RateSearchResult target)
                        // 2010/01/19 <<<
                        {
                            if (MakeChildKey(result) == MakeChildKey(target))
                            {
                                return (true);
                            }
                            else
                            {
                                return (false);
                            }
                        });
                    }
                    // メーカー
                    cells[COLUMN_MAKERCODE].Value = result.PrmPartsMakerCd.ToString("0000");
                    cells[COLUMN_MAKERNAME].Value = result.MakerName.Trim();
                    // 仕入先
                    cells[COLUMN_SUPPLIERCODE].Value = result.GoodsSupplierCd.ToString("000000");

                    if (targetList != null)
                    {
                        // ADD 2013/07/08 掛率マスタ一括登録修正既存障害の対応依頼 ---------->>>>>
                        // 重複しているデータがある場合は、最小ロット数のデータを取得
                        GetLowLottargetList(ref targetList);
                        // ADD 2013/07/08 掛率マスタ一括登録修正既存障害の対応依頼 ----------<<<<<

                        foreach (RateSearchResult target in targetList)
                        {
                            if (target.UnitPriceKind == "1")
                            {
                                // 売価率
                                if (this._targetDivide == 0)
                                {
                                    // FIXME:得意先掛率Ｇ
                                    // DEL 2009/12/01 3次分対応 得意先掛率グループ改良 ---------->>>>>
                                    // cells[target.CustRateGrpCode.ToString()].Value = target.RateVal;
                                    // DEL 2009/12/01 3次分対応 得意先掛率グループ改良 ----------<<<<<
                                    // ADD 2009/12/01 3次分対応 得意先掛率グループ改良 ---------->>>>>
                                    if (IsAllCustRateGrpCode(target))
                                    {
                                        if (ExistsCustRateGrpCodeInTargetDic(ALL_CUST_RATE_GRP_CODE))
                                        {
                                            //cells[ALL_CUST_RATE_GRP_CODE.ToString()].Value = target.RateVal; // DEL 2013/07/08 掛率マスタ一括登録修正既存障害の対応依頼
                                            // ADD 2013/07/08 掛率マスタ一括登録修正既存障害の対応依頼 ---------->>>>>
                                            // 論理利削除データの売掛率が空白入力不可の状態になります
                                            if (target.LogicalDeleteCode == 1)
                                            {
                                                cells[ALL_CUST_RATE_GRP_CODE.ToString()].Activation = Activation.Disabled;
                                                cells[ALL_CUST_RATE_GRP_CODE.ToString()].Appearance.BackColorDisabled = Color.Gainsboro;
                                                continue;
                                            }
                                            // 非正規データ表示しない
                                            else if (target.LogicalDeleteCode != 0)
                                            {
                                                continue;
                                            }
                                            else
                                            {
                                                if (target.RateVal != 0)
                                                {
                                                    cells[ALL_CUST_RATE_GRP_CODE.ToString()].Value = target.RateVal;
                                                }
                                            }
                                            // ADD 2013/07/08 掛率マスタ一括登録修正既存障害の対応依頼 ----------<<<<<
                                        }
                                    }
                                    else
                                    {
                                        if (ExistsCustRateGrpCodeInTargetDic(target.CustRateGrpCode))
                                        {
                                            //cells[target.CustRateGrpCode.ToString()].Value = target.RateVal; // DEL 2013/07/08 掛率マスタ一括登録修正既存障害の対応依頼
                                            // ADD 2013/07/08 掛率マスタ一括登録修正既存障害の対応依頼 ---------->>>>>
                                            // 論理利削除データの売掛率が空白入力不可の状態になります
                                            if (target.LogicalDeleteCode == 1)
                                            {
                                                cells[target.CustRateGrpCode.ToString()].Activation = Activation.Disabled;
                                                cells[target.CustRateGrpCode.ToString()].Appearance.BackColorDisabled = Color.Gainsboro;
                                                continue;
                                            }
                                            // 非正規データ表示しない
                                            else if (target.LogicalDeleteCode != 0)
                                            {
                                                continue;
                                            }
                                            else
                                            {
                                                if (target.RateVal != 0)
                                                {
                                                    cells[target.CustRateGrpCode.ToString()].Value = target.RateVal;
                                                }
                                            }
                                            // ADD 2013/07/08 掛率マスタ一括登録修正既存障害の対応依頼 ----------<<<<<
                                        }
                                    }
                                    // ADD 2009/12/01 3次分対応 得意先掛率グループ改良 ----------<<<<<
                                }
                                else
                                {
                                    // 得意先
                                    //cells[target.CustomerCode.ToString()].Value = target.RateVal; // DEL 2013/07/08 掛率マスタ一括登録修正既存障害の対応依頼
                                    // ADD 2013/07/08 掛率マスタ一括登録修正既存障害の対応依頼 ---------->>>>>
                                    // 論理利削除データの売掛率が空白入力不可の状態になります
                                    if (target.LogicalDeleteCode == 1)
                                    {
                                        cells[target.CustomerCode.ToString()].Activation = Activation.Disabled;
                                        cells[target.CustomerCode.ToString()].Appearance.BackColorDisabled = Color.Gainsboro;
                                        continue;
                                    }
                                    // 非正規データ表示しない
                                    else if (target.LogicalDeleteCode != 0)
                                    {
                                        continue;
                                    }
                                    else
                                    {
                                        if (target.RateVal != 0)
                                        {
                                            cells[target.CustomerCode.ToString()].Value = target.RateVal;
                                        }
                                    }
                                    // ADD 2009/12/01 3次分対応 得意先掛率グループ改良 ----------<<<<<
                                }
                            }
                            else if (target.UnitPriceKind == "2")
                            {
                                // 仕入率
                                //cells[COLUMN_COSTRATE].Value = target.RateVal; // DEL 2013/07/08 掛率マスタ一括登録修正既存障害の対応依頼
                                // ADD 2013/07/08 掛率マスタ一括登録修正既存障害の対応依頼 ---------->>>>>
                                // 論理利削除データの仕入率が空白入力不可の状態になります
                                if (target.LogicalDeleteCode == 1)
                                {
                                    cells[COLUMN_COSTRATE].Activation = Activation.Disabled;
                                    cells[COLUMN_COSTRATE].Appearance.BackColorDisabled = Color.Gainsboro;
                                    continue;
                                }
                                // 非正規データ表示しない
                                else if (target.LogicalDeleteCode != 0)
                                {
                                    continue;
                                }
                                else
                                {
                                    cells[COLUMN_COSTRATE].Value = target.RateVal;
                                }
                                // ADD 2009/12/01 3次分対応 得意先掛率グループ改良 ----------<<<<<
                            }
                        }
                    }

                    // 展開フラグ
                    cells[COLUMN_EXPANDFLG].Value = false;

                    // 商品掛率グループコード(内部保持用)
                    cells[COLUMN_GOODSRATEGRPCODE_HIDE].Value = result.PrmGoodsMGroup.ToString("0000");
                }
            }
            finally
            {
                this.uGrid_Details.EndUpdate();
            }
        }

        // ADD 2013/07/08 掛率マスタ一括登録修正既存障害の対応依頼 ---------->>>>>
        /// <summary>
        /// 重複しているデータがある場合は、最小ロット数のデータを取得
        /// </summary>
        /// <param name="targetList">データリスト</param>
        /// <remarks>
        /// <br>Note        : 重複しているデータがある場合は、最小ロット数のデータを取得します。</br>
        /// <br>Programmer  : liuyu</br>
        /// <br>Date        : 2013/07/08</br>
        /// </remarks>
        private void GetLowLottargetList(ref List<RateSearchResult> targetList)
        {
            // 重複しているデータがある場合は、最小ロット数のデータを取得
            Dictionary<string, RateSearchResult> targetDic = new Dictionary<string, RateSearchResult>();
            foreach (RateSearchResult tmpresult in targetList)
            {
                string key = string.Empty;
                if (tmpresult.UnitPriceKind == "1")
                {
                    // 売価率
                    if (this._targetDivide == 0)
                    {
                        if (IsAllCustRateGrpCode(tmpresult))
                        {
                            key = "ALL" + tmpresult.CustRateGrpCode.ToString();
                        }
                        else
                        {
                            key = tmpresult.CustRateGrpCode.ToString();
                        }
                    }
                    // 得意先
                    else
                    {
                        key = tmpresult.CustomerCode.ToString();
                    }
                }
                // 仕入率
                else if (tmpresult.UnitPriceKind == "2")
                {
                    key = "CostRate";
                }
                if (!targetDic.ContainsKey(key))
                {
                    targetDic.Add(key, tmpresult.Clone());
                }
                else
                {
                    if (tmpresult.LotCount < targetDic[key].LotCount)
                    {
                        targetDic[key] = tmpresult.Clone();
                    }
                }
            }
            targetList = new List<RateSearchResult>();
            foreach (RateSearchResult tmpresult in targetDic.Values)
            {
                targetList.Add(tmpresult.Clone());
            }
        }

        /// <summary>
        /// PreCell取得処理
        /// </summary>
        /// <param name="rowIndex">選択行</param>
        /// <param name="colIndex">選択列</param>
        /// <remarks>
        /// <br>Note        : 現在アクティブなセルを基準に、先のセルの取得を行います。</br>
        /// <br>Programmer  : liuyu</br>
        /// <br>Date        : 2013/07/08</br>
        /// </remarks>
        private void GetPreCell(int rowIndex,int colIndex)
        {
            for (int i = rowIndex; i >= 0; i--)
            {
                if (!this.uGrid_Details.Rows[i].Hidden)
                {
                    if (i == rowIndex)
                    {
                        for (int j = colIndex - 1; j >= 7; j--)
                        {
                            if (!uGrid_Details.Rows[i].Cells[j].Column.Hidden
                                    && uGrid_Details.Rows[i].Cells[j].Activation == Activation.AllowEdit
                                    && uGrid_Details.Rows[i].Cells[j].Column.CellActivation == Activation.AllowEdit)
                            {
                                uGrid_Details.Rows[i].Cells[j].Activate();
                                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                return;
                            }
                        }
                    }
                    else
                    {
                        for (int j = COLINDEX_SALERATE_ST + this._targetDic.Count - 1; j >= 7; j--)
                        {
                            if (!uGrid_Details.Rows[i].Cells[j].Column.Hidden
                                    && uGrid_Details.Rows[i].Cells[j].Activation == Activation.AllowEdit
                                    && uGrid_Details.Rows[i].Cells[j].Column.CellActivation == Activation.AllowEdit)
                            {
                                uGrid_Details.Rows[i].Cells[j].Activate();
                                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                return;
                            }
                        }
                    }
                }
                if (i == 0)
                {
                    this.AllExpand_Button.Focus();
                }
            }
        }

        /// <summary>
        /// NextCell取得処理
        /// </summary>
        /// <param name="rowIndex">選択行</param>
        /// <param name="colIndex">選択列</param>
        /// <remarks>
        /// <br>Note        : 現在アクティブなセルを基準に、次のセルの取得を行います。</br>
        /// <br>Programmer  : liuyu</br>
        /// <br>Date        : 2013/07/08</br>
        /// </remarks>
        private void GetNextCell(int rowIndex, int colIndex)
        {
            for (int i = rowIndex; i < this.uGrid_Details.Rows.Count; i++)
            {
                if (!this.uGrid_Details.Rows[i].Hidden)
                {
                    if (i == rowIndex)
                    {
                        for (int j = colIndex + 1; j < COLINDEX_SALERATE_ST + this._targetDic.Count; j++)
                        {
                            if (!uGrid_Details.Rows[i].Cells[j].Column.Hidden
                               && uGrid_Details.Rows[i].Cells[j].Activation == Activation.AllowEdit
                               && uGrid_Details.Rows[i].Cells[j].Column.CellActivation == Activation.AllowEdit)
                            {
                                uGrid_Details.Rows[i].Cells[j].Activate();
                                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                return;
                            }
                        }
                    }
                    else
                    {
                        for (int j = 7; j < COLINDEX_SALERATE_ST + this._targetDic.Count; j++)
                        {
                            if (!uGrid_Details.Rows[i].Cells[j].Column.Hidden
                               && uGrid_Details.Rows[i].Cells[j].Activation == Activation.AllowEdit
                               && uGrid_Details.Rows[i].Cells[j].Column.CellActivation == Activation.AllowEdit)
                            {
                                uGrid_Details.Rows[i].Cells[j].Activate();
                                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                return;
                            }
                        }
                    }
                }
            }                         
      
        }
        // ADD 2013/07/08 掛率マスタ一括登録修正既存障害の対応依頼 ----------<<<<<


        // ADD 2009/12/01 3次分対応 得意先掛率グループ改良 ---------->>>>>
        /// <summary>
        /// 得意先掛率グループが"指定なし"のデータであるか判断します。
        /// </summary>
        /// <param name="rateSearchResult">検索したデータ</param>
        /// <returns>
        /// <c>true</c> :得意先掛率グループが"指定なし"のデータです。<br/>
        /// <c>false</c>:得意先掛率グループが"指定なし"のデータではありません。
        /// </returns>
        private static bool IsAllCustRateGrpCode(RateSearchResult rateSearchResult)
        {
            string unitRateSetDivCd = rateSearchResult.UnitRateSetDivCd.Trim();
            return unitRateSetDivCd.Equals("15F") || unitRateSetDivCd.Equals("15D");
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
        // ADD 2009/12/01 3次分対応 得意先掛率グループ改良 ----------<<<<<

        /// <summary>
        /// グリッドスタイル設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : グリッドのスタイルを設定します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2009/01/19</br>
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

                // 商掛Ｇ
                columns[COLUMN_GOODSRATEGRPCODE].Header.Caption = "商掛G";
                columns[COLUMN_GOODSRATEGRPCODE].Header.Fixed = true;
                columns[COLUMN_GOODSRATEGRPCODE].CellAppearance.TextHAlign = HAlign.Right;
                columns[COLUMN_GOODSRATEGRPCODE].CellActivation = Activation.NoEdit;

                // BLCD
                columns[COLUMN_BLCD].Header.Caption = "BLCD";
                columns[COLUMN_BLCD].Header.Fixed = true;
                columns[COLUMN_BLCD].CellAppearance.TextHAlign = HAlign.Right;
                columns[COLUMN_BLCD].CellActivation = Activation.NoEdit;

                // 名称
                columns[COLUMN_NAME].Header.Caption = "名称";
                columns[COLUMN_NAME].Header.Fixed = true;
                columns[COLUMN_NAME].CellAppearance.TextHAlign = HAlign.Left;
                columns[COLUMN_NAME].CellActivation = Activation.NoEdit;

                // メーカーコード
                columns[COLUMN_MAKERCODE].Header.Caption = "ﾒｰｶｰ";
                columns[COLUMN_MAKERCODE].Header.Fixed = true;
                columns[COLUMN_MAKERCODE].CellAppearance.TextHAlign = HAlign.Right;
                columns[COLUMN_MAKERCODE].CellActivation = Activation.NoEdit;

                // メーカー名
                columns[COLUMN_MAKERNAME].Header.Caption = "ﾒｰｶｰ名";
                columns[COLUMN_MAKERNAME].Header.Fixed = true;
                columns[COLUMN_MAKERNAME].CellAppearance.TextHAlign = HAlign.Left;
                columns[COLUMN_MAKERNAME].CellActivation = Activation.NoEdit;

                // 仕入先
                columns[COLUMN_SUPPLIERCODE].Header.Caption = "仕入先";
                columns[COLUMN_SUPPLIERCODE].Header.Fixed = true;
                columns[COLUMN_SUPPLIERCODE].CellAppearance.TextHAlign = HAlign.Right;
                columns[COLUMN_SUPPLIERCODE].CellActivation = Activation.NoEdit;

                // 仕入率
                columns[COLUMN_COSTRATE].Header.Caption = "仕入率";
                columns[COLUMN_COSTRATE].Header.Fixed = true;
                columns[COLUMN_COSTRATE].Format = FORMAT;
                columns[COLUMN_COSTRATE].CellAppearance.TextHAlign = HAlign.Right;
                columns[COLUMN_COSTRATE].CellActivation = Activation.AllowEdit;

                // 売価率
                if ((this._displayList == null) || (this._displayList.Count == 0))
                {
                    for (int index = COLINDEX_SALERATE_ST; index <= COLINDEX_SALERATE_ED; index++)
                    {
                        columns[index].Header.Caption = "";
                        columns[index].Format = FORMAT;
                        columns[index].CellAppearance.TextHAlign = HAlign.Right;
                        columns[index].CellActivation = Activation.AllowEdit;
                    }
                }
                else
                {
                    foreach (int key in this._targetDic.Keys)
                    {
                        if (this._targetDivide == 0)
                        {
                            columns[key.ToString()].Header.Caption = ((int)this._targetDic[key]).ToString("0000");

                            // ADD 2009/12/01 3次分対応 得意先掛率グループ改良 ---------->>>>>
                            if (((int)this._targetDic[key]) < 0) columns[key.ToString()].Header.Caption = "ALL";   // HACK:"ALL"
                            // ADD 2009/12/01 3次分対応 得意先掛率グループ改良 ----------<<<<<
                        }
                        else
                        {
                            columns[key.ToString()].Header.Caption = ((int)this._targetDic[key]).ToString("00000000");
                        }
                        columns[key.ToString()].Format = FORMAT;
                        columns[key.ToString()].CellAppearance.TextHAlign = HAlign.Right;
                        columns[key.ToString()].CellActivation = Activation.AllowEdit;
                    }
                }

                // 親子区分
                columns[COLUMN_PARENTDIV].Header.Caption = "";
                columns[COLUMN_PARENTDIV].Hidden = true;

                // 展開フラグ
                columns[COLUMN_EXPANDFLG].Header.Caption = "";
                columns[COLUMN_EXPANDFLG].Hidden = true;

                // 商品掛率グループコード(内部保持用)
                columns[COLUMN_GOODSRATEGRPCODE_HIDE].Header.Caption = "";
                columns[COLUMN_GOODSRATEGRPCODE_HIDE].Hidden = true;

                // グリッド列幅設定
                SetColumnWidth(ref uGrid);
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
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2009/01/19</br>
        /// </remarks>
        private void SetColumnWidth(ref UltraGrid uGrid)
        {
            ColumnsCollection columns = uGrid.DisplayLayout.Bands[0].Columns;

            // No
            columns[COLUMN_NO].Width = 45;
            // 商掛Ｇ
            columns[COLUMN_GOODSRATEGRPCODE].Width = 50;
            // BLCD
            columns[COLUMN_BLCD].Width = 50;
            // 名称
            columns[COLUMN_NAME].Width = 165;
            // メーカーコード
            columns[COLUMN_MAKERCODE].Width = 50;
            // メーカー名
            columns[COLUMN_MAKERNAME].Width = 165;
            // 仕入先
            columns[COLUMN_SUPPLIERCODE].Width = 70;
            // 仕入率
            columns[COLUMN_COSTRATE].Width = 90;
            // 売価率
            if ((this._displayList == null) || (this._displayList.Count == 0))
            {
                for (int index = COLINDEX_SALERATE_ST; index <= COLINDEX_SALERATE_ED; index++)
                {
                    columns[index].Width = 90;
                }
            }
            else
            {
                foreach (int key in this._targetDic.Keys)
                {
                    columns[key.ToString()].Width = 90;
                }
            }
        }

        /// <summary>
        /// グリッド行カラー設定処理
        /// </summary>
        /// <param name="uGrid">グリッド</param>
        /// <remarks>
        /// <br>Note        : グリッドの行カラーを設定します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2009/01/19</br>
        /// </remarks>
        public void SetRowColor(ref UltraGrid uGrid)
        {
            Color cellColor;

            for (int rowIndex = 0; rowIndex < uGrid.Rows.Count; rowIndex++)
            {
                CellsCollection cells = uGrid.Rows[rowIndex].Cells;

                // 親子区分
                int parentDiv = IntObjToInt(cells[COLUMN_PARENTDIV].Value);

                if (parentDiv == 0)
                {
                    // Key作成
                    string key = MakeParentKey(StrObjToInt(cells[COLUMN_GOODSRATEGRPCODE].Value),
                                               StrObjToInt(cells[COLUMN_MAKERCODE].Value),
                                               StrObjToInt(cells[COLUMN_SUPPLIERCODE].Value));

                    // 子が存在するかどうかチェック
                    //List<RateSearchResult> childList = this._childList.FindAll(delegate(RateSearchResult target) // DEL 2013/07/08 掛率マスタ一括登録修正既存障害の対応依頼
                    List<RateSearchResult> childList = this._childRateValList.FindAll(delegate(RateSearchResult target) // ADD 2013/07/08 掛率マスタ一括登録修正既存障害の対応依頼
                    {
                        if (key == MakeParentKey(target))
                        {
                            return (true);
                        }
                        else
                        {
                            return (false);
                        }
                    });

                    bool existFlg = false;

                    if ((childList == null) || (childList.Count == 0))
                    {
                        existFlg = false;
                    }
                    else
                    {
                        // ADD 2013/07/08 掛率マスタ一括登録修正既存障害の対応依頼 ---------->>>>>
                        // 重複しているデータがある場合は、最小ロット数のデータを取得
                        GetLowLottargetList(ref childList);
                        // ADD 2013/07/08 掛率マスタ一括登録修正既存障害の対応依頼 ----------<<<<<
                        foreach (RateSearchResult result in childList)
                        {
                            // ADD 2013/07/08 掛率マスタ一括登録修正既存障害の対応依頼 ---------->>>>>
                            if (result.UnitPriceKind == "1")
                            {
                                if (this._targetDivide == 0)
                                {
                                    if (IsAllCustRateGrpCode(result)
                                        && !ExistsCustRateGrpCodeInTargetDic(ALL_CUST_RATE_GRP_CODE))
                                    {
                                        continue;
                                    }
                                    else if (!IsAllCustRateGrpCode(result)
                                            && !ExistsCustRateGrpCodeInTargetDic(result.CustRateGrpCode))
                                    {
                                        continue;
                                    }
                                }
                            }
                            // ADD 2013/07/08 掛率マスタ一括登録修正既存障害の対応依頼 ----------<<<<<
                            if (result.RateVal != 0)
                            {
                                existFlg = true;
                                break;
                            }
                        }
                    }

                    if (existFlg)
                    {
                        // 子明細に率が存在する場合
                        cellColor = Color.Pink;
                    }
                    else
                    {
                        // 子明細に率が存在しない場合
                        cellColor = Color.White;
                    }
                }
                else
                {
                    cellColor = Color.Lavender;
                }

                for (int colIndex = 1; colIndex < cells.Count; colIndex++)
                {
                    cells[colIndex].Appearance.BackColor = cellColor;
                    cells[colIndex].Appearance.BackColor2 = cellColor;
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
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2009/01/19</br>
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
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2009/01/19</br>
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
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2009/01/19</br>
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

        /// <summary>
        /// セル値変換処理
        /// </summary>
        /// <param name="cellValue">セル値</param>
        /// <returns>Bool型</returns>
        /// <remarks>
        /// <br>Note        : セル値をBool型に変換します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2009/01/19</br>
        /// </remarks>
        public bool BoolObjToBool(object cellValue)
        {
            if ((cellValue == DBNull.Value) || (cellValue == null) || (cellValue.ToString() == ""))
            {
                return (false);
            }
            else
            {
                return (bool)cellValue;
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
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2009/01/19</br>
        /// </remarks>
        private string MakeParentKey(RateSearchResult result)
        {
            // 商品中分類コード＋部品メーカーコード＋仕入先コード
            string key = result.PrmGoodsMGroup.ToString("0000") +
                         result.PrmPartsMakerCd.ToString("0000") +
                         result.GoodsSupplierCd.ToString("000000");

            return key;
        }

        /// <summary>
        /// Key作成処理
        /// </summary>
        /// <param name="goodsMGroup">商品中分類コード</param>
        /// <param name="makerCode">部品メーカーコード</param>
        /// <param name="supplierCode"><仕入先コード/param>
        /// <returns>Key</returns>
        /// <remarks>
        /// <br>Note        : Keyを作成します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2009/01/19</br>
        /// </remarks>
        private string MakeParentKey(int goodsMGroup, int makerCode, int supplierCode)
        {
            // 商品中分類コード＋部品メーカーコード＋仕入先コード
            string key = goodsMGroup.ToString("0000") +
                         makerCode.ToString("0000") +
                         supplierCode.ToString("000000");

            return key;
        }

        /// <summary>
        /// Key作成処理
        /// </summary>
        /// <param name="result">掛率マスタ検索結果</param>
        /// <returns>Key</returns>
        /// <remarks>
        /// <br>Note        : Keyを作成します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2009/01/19</br>
        /// </remarks>
        private string MakeChildKey(RateSearchResult result)
        {
            // 商品中分類コード＋BLコード＋部品メーカーコード＋仕入先コード
            string key = result.PrmGoodsMGroup.ToString("0000") +
                         result.PrmTbsPartsCode.ToString("00000") +
                         result.PrmPartsMakerCd.ToString("0000") +
                         result.GoodsSupplierCd.ToString("000000");

            return key;
        }

        /// <summary>
        /// Key作成処理
        /// </summary>
        /// <param name="goodsMGroup">商品中分類コード</param>
        /// <param name="blGoodsCode">BLコード</param>
        /// <param name="makerCode">部品メーカーコード</param>
        /// <param name="supplierCode">仕入先コード</param>
        /// <returns>Key</returns>
        /// <remarks>
        /// <br>Note        : Keyを作成します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2009/01/19</br>
        /// </remarks>
        private string MakeChildKey(int goodsMGroup, int blGoodsCode, int makerCode, int supplierCode)
        {
            // 商品中分類コード＋部品メーカーコード＋仕入先コード
            string key = goodsMGroup.ToString("0000") +
                         blGoodsCode.ToString("00000") +
                         makerCode.ToString("0000") +
                         supplierCode.ToString("000000");

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
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2009/01/19</br>
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
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2009/01/19</br>
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
                                         this._ratePackageUpdateAcs,	    // エラーが発生したオブジェクト
                                         msgButton,         			  	// 表示するボタン
                                         MessageBoxDefaultButton.Button1);	// 初期表示ボタン

            return dialogResult;
        }
        #endregion メッセージボックス表示

        // ---ADD 2010/08/10-------------------->>>
        /// <summary>
        /// リスト項目をコードからでも入力可能へ変更
        /// </summary>
        /// <param name="name"></param>
        private void setTComboEditorByName(string name)
        {
            TComboEditor control = (TComboEditor)(this.GetType().GetField(name, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase).GetValue(this));

            bool inputErrorFlg = true;
            foreach (Infragistics.Win.ValueListItem item in control.Items)
            {
                if (item.DataValue == control.Value)
                {
                    inputErrorFlg = false;
                    break;
                }
            }

            if (inputErrorFlg)
            {
                control.Value = this._preComboEditorValue;
            }
            else
            {
                this._preComboEditorValue = control.Value;
            }
        }
        // ---ADD 2010/08/10--------------------<<<

        #endregion ■ Private Methods


        #region ■ Control Events

        /// <summary>
        /// Load イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : フォームがLoadされた時に発生します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2009/01/19</br>
        /// </remarks>
        private void PMKHN09401UA_Load(object sender, EventArgs e)
        {
            this.uGrid_Details.ActiveRow = null;

            this.Initial_Timer.Enabled = true;
        }

        /// <summary>
        /// ToolClick イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : ツールバーがクリックされた時に発生します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2009/01/19</br>
        /// <br>UpdateNote  : キーボード操作の改良を行う。</br>
        /// <br>Programmer  : PM1012C 朱 猛</br>
        /// <br>Date        : 2010/08/10</br>
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
                case "ButtonTool_Renewal":
                    {
                        // マスタ読込
                        ReadSecInfoSet();
                        ReadSupplier();
                        ReadMakerUMnt();
                        ReadGoodsGroupU();
                        ReadCustomerSearchRet();
                        ReadCustRateGrp();

                        ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                   "最新情報を取得しました。",
                                   0,
                                   MessageBoxButtons.OK,
                                   MessageBoxDefaultButton.Button1);
                        break;
                    }
                // ---ADD 2010/08/10-------------------->>>
                case "ButtonTool_Guide":
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
                                            this.SectionGuide_Button_Click(this.tEdit_SectionCodeAllowZero,new EventArgs());
                                            flag = true;
                                            break;
                                        }
                                    // 仕入先
                                    case "tNedit_SupplierCd":
                                        {
                                            this.SupplierGuide_Button_Click(this.tNedit_SupplierCd, new EventArgs());
                                            flag = true;
                                            break;
                                        }
                                    // 商品掛率Ｇ
                                    case "tNedit_GoodsMGroup":
                                        {
                                            this.GoodsRateGrpGuide_Button_Click(this.tNedit_GoodsMGroup, new EventArgs());
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
                                        // --- ADD 2010/08/31 ---------------------------------->>>>>
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
                                        // --- ADD 2010/08/31 ----------------------------------<<<<<
                                    }
                                    // --- ADD 2010/08/31 ---------------------------------->>>>>
                                    else
                                    {
                                        this._preCtrl = (TNedit)ctrl;
                                        this._preCtrl.Focus();
                                        this._preCtrl.SelectAll();
                                    }
                                    // --- ADD 2010/08/31 ----------------------------------<<<<<
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
                                    // --- DEL 2010/08/31 ---------------------------------->>>>>
                                    //customerSearchForm.ShowDialog(this);
                                    // --- DEL 2010/08/31 ----------------------------------<<<<<
                                    // --- ADD 2010/08/31 ---------------------------------->>>>>
                                    DialogResult result = customerSearchForm.ShowDialog(this);
                                    // --- ADD 2010/08/31 ----------------------------------<<<<<
                                    flag = true;
                                    // --- ADD 2010/08/31 ---------------------------------->>>>>
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
                                    // --- ADD 2010/08/31 ----------------------------------<<<<<
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
                        break;
                    }
                // ---ADD 2010/08/10--------------------<<<
            }
        }

        /// <summary>
        /// 得意先選択時発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="customerSearchRet">得意先検索戻り値クラス</param>
        /// <remarks>
        /// <br>Note       : 得意先選択時に発生します。</br>
        /// <br>Programmer : PM1012C 朱　猛</br>
        /// <br>Date       : 2010/08/10</br>
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

        /// <summary>
        /// Button_Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : 拠点ガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2009/01/19</br>
        /// <br>UpdateNote  : キーボード操作の改良を行う。</br>
        /// <br>Programmer  : PM1012C 朱 猛</br>
        /// <br>Date        : 2010/08/10</br>
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
                    this.tEdit_SectionCodeAllowZero.DataText = secInfoSet.SectionCode.Trim();
                    this.tEdit_SectionName.DataText = GetSectionName(secInfoSet.SectionCode.Trim());

                    // フォーカス設定
                    this.tNedit_SupplierCd.Focus();
                    // ---ADD 2010/08/10-------------------->>>
                    ((ButtonTool)this.tToolbarsManager_MainMenu.Tools[15]).SharedProps.Enabled = true;
                    // ---ADD 2010/08/10--------------------<<<
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
        /// <br>Note        : 仕入先ガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2009/01/19</br>
        /// <br>UpdateNote  : キーボード操作の改良を行う。</br>
        /// <br>Programmer  : PM1012C 朱 猛</br>
        /// <br>Date        : 2010/08/10</br>
        /// </remarks>
        private void SupplierGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                Supplier supplier;

                int status = this._supplierAcs.ExecuteGuid(out supplier, this._enterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode.Trim());
                if (status == 0)
                {
                    this.tNedit_SupplierCd.SetInt(supplier.SupplierCd);
                    this.tEdit_SupplierName.DataText = GetSupplierName(supplier.SupplierCd);

                    // フォーカス設定
                    this.tNedit_GoodsMGroup.Focus();
                    // ---ADD 2010/08/10-------------------->>>
                    ((ButtonTool)this.tToolbarsManager_MainMenu.Tools[15]).SharedProps.Enabled = true;
                    // ---ADD 2010/08/10--------------------<<<
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
        /// <br>Note        : 商品掛率Ｇガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2009/01/19</br>
        /// <br>UpdateNote  : キーボード操作の改良を行う。</br>
        /// <br>Programmer  : PM1012C 朱 猛</br>
        /// <br>Date        : 2010/08/10</br>
        /// </remarks>
        private void GoodsRateGrpGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                GoodsGroupU goodsGroupU;

                int status = this._goodsGroupUAcs.ExecuteGuid(this._enterpriseCode, out goodsGroupU, false);
                if (status == 0)
                {
                    this.tNedit_GoodsMGroup.SetInt(goodsGroupU.GoodsMGroup);
                    this.tEdit_GoodsRateGrpName.DataText = GetGoodsGroupName(goodsGroupU.GoodsMGroup);

                    // フォーカス設定
                    this.tNedit_GoodsMakerCd.Focus();
                    // ---ADD 2010/08/10-------------------->>>
                    ((ButtonTool)this.tToolbarsManager_MainMenu.Tools[15]).SharedProps.Enabled = true;
                    // ---ADD 2010/08/10--------------------<<<
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
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2009/01/19</br>
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
                    this.tNedit_GoodsMakerCd.SetInt(makerUMnt.GoodsMakerCd);
                    this.tEdit_MakerName.DataText = GetMakerName(makerUMnt.GoodsMakerCd);

                    // フォーカス設定
                    this.tComboEditor_TargetDivide.Focus();
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
        /// <br>Note        : 展開ボタンがクリックされた時に発生します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2009/01/19</br>
        /// </remarks>
        private void Expand_Button_Click(object sender, EventArgs e)
        {
            int rowIndex;

            if (this.uGrid_Details.ActiveCell != null)
            {
                rowIndex = this.uGrid_Details.ActiveCell.Row.Index;
            }
            else if (this.uGrid_Details.ActiveRow != null)
            {
                rowIndex = this.uGrid_Details.ActiveRow.Index;
            }
            else if ((this.uGrid_Details.Selected.Rows != null) &&
                (this.uGrid_Details.Selected.Rows.Count > 0))
            {
                rowIndex = this.uGrid_Details.Selected.Rows[0].Index;
            }
            else
            {
                return;
            }

            CellsCollection cells = this.uGrid_Details.Rows[rowIndex].Cells;

            int parentRowIndex = 0;

            ArrayList childIndexList = null;

            if (IntObjToInt(cells[COLUMN_PARENTDIV].Value) == 0)
            {
                // 親明細

                parentRowIndex = rowIndex;
            }
            else
            {
                // 子明細
                foreach (int parentIndex in this._parentChildIndexDic.Keys)
                {
                    childIndexList = (ArrayList)this._parentChildIndexDic[parentIndex];

                    if (childIndexList.Contains(rowIndex))
                    {
                        parentRowIndex = parentIndex;
                        break;
                    }
                }
            }

            if (this._parentChildIndexDic.ContainsKey(parentRowIndex))
            {
                childIndexList = (ArrayList)this._parentChildIndexDic[parentRowIndex];
            }

            if (childIndexList != null)
            {
                bool expandFlg = BoolObjToBool(cells[COLUMN_EXPANDFLG].Value);
                if (expandFlg)
                {
                    // 圧縮
                    foreach (int childIndex in childIndexList)
                    {
                        this.uGrid_Details.Rows[childIndex].Hidden = true;
                        this.uGrid_Details.Rows[childIndex].Cells[COLUMN_EXPANDFLG].Value = false;
                    }
                    this.uGrid_Details.Rows[parentRowIndex].Cells[COLUMN_EXPANDFLG].Value = false;
                }
                else
                {
                    // 展開
                    foreach (int childIndex in childIndexList)
                    {
                        this.uGrid_Details.Rows[childIndex].Hidden = false;
                        this.uGrid_Details.Rows[childIndex].Cells[COLUMN_EXPANDFLG].Value = true;
                    }
                    this.uGrid_Details.Rows[parentRowIndex].Cells[COLUMN_EXPANDFLG].Value = true;
                }
            }

            this.uGrid_Details.UpdateData();

            // フォーカス設定
            this.uGrid_Details.ActiveRow = null;
            this.Expand_Button.Focus();
        }

        /// <summary>
        /// Button_Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : 全展開ボタンがクリックされた時に発生します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2009/01/19</br>
        /// </remarks>
        private void AllExpand_Button_Click(object sender, EventArgs e)
        {
            foreach (int parentRowIndex in this._parentChildIndexDic.Keys)
            {
                this.uGrid_Details.Rows[parentRowIndex].Cells[COLUMN_EXPANDFLG].Value = !this._prevAllExpand;

                // 子明細行インデックスリスト取得
                ArrayList childRowIndexList = (ArrayList)this._parentChildIndexDic[parentRowIndex];

                if (childRowIndexList == null)
                {
                    continue;
                }

                foreach (int childRowIndex in childRowIndexList)
                {
                    this.uGrid_Details.Rows[childRowIndex].Hidden = this._prevAllExpand;
                    this.uGrid_Details.Rows[childRowIndex].Cells[COLUMN_EXPANDFLG].Value = !this._prevAllExpand;
                }
            }

            this.uGrid_Details.UpdateData();

            this._prevAllExpand = !this._prevAllExpand;

            // フォーカス設定
            this.uGrid_Details.ActiveRow = null;
            this.AllExpand_Button.Focus();
        }

        /// <summary>
        /// ExpandedStateChanged イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : 展開ステータスが変更された時に発生します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2009/01/19</br>
        /// </remarks>
        private void Standard_UGroupBox_ExpandedStateChanged(object sender, EventArgs e)
        {
            Size topSize = new Size();

            topSize.Width = this.Form1_Top_Panel.Size.Width;
            topSize.Height = 25;

            if ((this.Standard_UGroupBox.Expanded == true) || (this.Standard_UGroupBox2.Expanded == true))
            {
                topSize.Height = 150;
            }
            else
            {
                topSize.Height = 25;
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
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2009/01/19</br>
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
                            this.AllExpand_Button.Focus();
                        }
                        else
                        {
                            e.Handled = true;
                            // DEL 2009/06/19 ------>>>
                            //uGrid.Rows[rowIndex - 1].Cells[colIndex].Activate();
                            //uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            // DEL 2009/06/19 ------<<<

                            // ADD 2009/06/19 ------>>>
                            for (int i = rowIndex - 1; i >= 0; i--)
                            {
                                if (!uGrid.Rows[i].Hidden)
                                {
                                    #region DEL 2013/07/08 掛率マスタ一括登録修正既存障害の対応依頼
                                    //uGrid.Rows[i].Cells[colIndex].Activate();
                                    //uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                    //break;
                                    #endregion
                                    // ADD 2013/07/08 掛率マスタ一括登録修正既存障害の対応依頼 ---------->>>>>
                                    if (uGrid.Rows[i].Cells[colIndex].Activation == Activation.AllowEdit)
                                    {
                                        uGrid.Rows[i].Cells[colIndex].Activate();
                                        uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                        break;
                                    }
                                    // ADD 2013/07/08 掛率マスタ一括登録修正既存障害の対応依頼 ----------<<<<<
                                }
                                // ADD 2013/07/08 掛率マスタ一括登録修正既存障害の対応依頼 ---------->>>>>
                                if (i == 0)
                                {
                                    this.AllExpand_Button.Focus();
                                }
                                // ADD 2013/07/08 掛率マスタ一括登録修正既存障害の対応依頼 ----------<<<<<
                            }
                            // ADD 2009/06/19 ------<<<
                        }
                        break;
                    }
                case Keys.Down:
                    {
                        e.Handled = true;

                        if (rowIndex != uGrid.Rows.Count - 1)
                        {
                            // DEL 2009/06/19 ------>>>
                            //uGrid.Rows[rowIndex + 1].Cells[colIndex].Activate();
                            //uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            // DEL 2009/06/19 ------<<<

                            // ADD 2009/06/19 ------>>>
                            for (int i = rowIndex + 1; i < uGrid.Rows.Count; i++)
                            {
                                if (!uGrid.Rows[i].Hidden)
                                {
                                    #region DEL 2013/07/08 掛率マスタ一括登録修正既存障害の対応依頼
                                    //uGrid.Rows[i].Cells[colIndex].Activate();
                                    //uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                    //break;
                                    #endregion

                                    // ADD 2013/07/08 掛率マスタ一括登録修正既存障害の対応依頼 ---------->>>>>
                                    if (uGrid.Rows[i].Cells[colIndex].Activation == Activation.AllowEdit)
                                    {
                                        uGrid.Rows[i].Cells[colIndex].Activate();
                                        uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                        break;
                                    }
                                    // ADD 2013/07/08 掛率マスタ一括登録修正既存障害の対応依頼 ----------<<<<<
                                }
                            }
                            // ADD 2009/06/19 ------<<<
                        }
                        break;
                    }
                case Keys.Left:
                    {
                        if (uGrid.ActiveCell.IsInEditMode)
                        {
                            if (uGrid.ActiveCell.SelStart == 0)
                            {
                                if ((rowIndex == 0) && (colKey == COLUMN_COSTRATE))
                                {
                                    e.Handled = true;
                                }
                                // ADD 2013/07/08 掛率マスタ一括登録修正既存障害の対応依頼 ---------->>>>>
                                else
                                {
                                    e.Handled = true;
                                    GetPreCell(rowIndex, colIndex);
                                }
                                // ADD 2013/07/08 掛率マスタ一括登録修正既存障害の対応依頼 ----------<<<<<
                                #region DEL 2013/07/08 掛率マスタ一括登録修正既存障害の対応依頼
                                //else if (colKey == COLUMN_COSTRATE)
                                //{
                                //    e.Handled = true;
                                //    // DEL 2009/06/19 ------>>>
                                //    //uGrid.Rows[rowIndex - 1].Cells[COLINDEX_SALERATE_ST + this._targetDic.Keys.Count - 1].Activate();
                                //    //uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                //    // DEL 2009/06/19 ------<<<
                            
                                //    // ADD 2009/06/19 ------>>>
                                //    for (int i = rowIndex - 1; i >= 0; i--)
                                //    {
                                //        if (!uGrid.Rows[i].Hidden)
                                //        {
                                //            uGrid.Rows[i].Cells[COLINDEX_SALERATE_ST + this._targetDic.Keys.Count - 1].Activate();
                                //            uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                //            break;
                                //        }
                                //    }
                                //    // ADD 2009/06/19 ------<<<
                                //}
                                //else
                                //{
                                //    e.Handled = true;
                                //    uGrid.Rows[rowIndex].Cells[colIndex - 1].Activate();
                                //    uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                //}
                                #endregion
                            }
                        }
                        break;
                    }
                case Keys.Right:
                    {
                        if (uGrid.ActiveCell.IsInEditMode)
                        {
                            if (uGrid.ActiveCell.SelStart >= uGrid.ActiveCell.Text.Length)
                            {
                                if ((rowIndex == uGrid.Rows.Count - 1) && (colIndex == COLINDEX_SALERATE_ST + this._targetDic.Keys.Count - 1))
                                {
                                    e.Handled = true;
                                }
                                // ADD 2013/07/08 掛率マスタ一括登録修正既存障害の対応依頼 ---------->>>>>
                                else
                                {
                                    e.Handled = true;

                                    GetNextCell(rowIndex, colIndex);
                                }
                                // ADD 2013/07/08 掛率マスタ一括登録修正既存障害の対応依頼 ----------<<<<<
                                #region DEL 2013/07/08 掛率マスタ一括登録修正既存障害の対応依頼
                                //else if (colIndex == COLINDEX_SALERATE_ST + this._targetDic.Keys.Count - 1)
                                //{
                                //    e.Handled = true;
                                //    // DEL 2009/06/19 ------>>>
                                //    //uGrid.Rows[rowIndex + 1].Cells[COLUMN_COSTRATE].Activate();
                                //    //uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                //    // DEL 2009/06/19 ------<<<
                            
                                //    // ADD 2009/06/19 ------>>>
                                //    for (int i = rowIndex + 1; i < uGrid.Rows.Count; i++)
                                //    {
                                //        if (!uGrid.Rows[i].Hidden)
                                //        {
                                //            uGrid.Rows[i].Cells[COLUMN_COSTRATE].Activate();
                                //            uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                //            break;
                                //        }
                                //    }
                                //    // ADD 2009/06/19 ------<<<
                                //}
                                //else
                                //{
                                //    e.Handled = true;
                                //    uGrid.Rows[rowIndex].Cells[colIndex + 1].Activate();
                                //    uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                //}
                                #endregion
                            }
                        }
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
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2009/01/19</br>
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
                // ZZ9.99
                if (!KeyPressNumCheck(6, 2, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                {
                    e.Handled = true;
                    return;
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
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2009/01/19</br>
        /// </remarks>
        private void uGrid_Details_AfterCellActivate(object sender, EventArgs e)
        {
            this.uGrid_Details.Rows[this.uGrid_Details.ActiveCell.Row.Index].Selected = false;
        }

        /// <summary>
        /// AfterRowActivate イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : 行がアクティブ化した時に発生します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2009/01/19</br>
        /// </remarks>
        private void uGrid_Details_AfterRowActivate(object sender, EventArgs e)
        {
            CellsCollection cells = this.uGrid_Details.ActiveRow.Cells;

            bool existFlg;

            // 親子区分
            int parentDiv = IntObjToInt(cells[COLUMN_PARENTDIV].Value);
            if (parentDiv == 0)
            {
                // Key作成
                string key = MakeParentKey(StrObjToInt(cells[COLUMN_GOODSRATEGRPCODE].Value),
                                           StrObjToInt(cells[COLUMN_MAKERCODE].Value),
                                           StrObjToInt(cells[COLUMN_SUPPLIERCODE].Value));

                // 子が存在するかどうかチェック
                existFlg = this._childList.Exists(delegate(RateSearchResult target)
                {
                    if (key == MakeParentKey(target))
                    {
                        return (true);
                    }
                    else
                    {
                        return (false);
                    }
                });
            }
            else
            {
                existFlg = true;
            }

            this.Expand_Button.Enabled = existFlg;
        }

        /// <summary>
        /// AfterExitEditMode イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : 編集モードが終了した時に発生します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2009/01/19</br>
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
        }

        /// <summary>
        /// Tick イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : 一定間隔が過ぎる度に時に発生します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2009/01/19</br>
        /// <br>UpdateNote  : キーボード操作の改良を行う。</br>
        /// <br>Programmer  : PM1012C 朱 猛</br>
        /// <br>Date        : 2010/08/10</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            // フォーカス設定
            this.tEdit_SectionCodeAllowZero.Focus();
            // ---ADD 2010/08/10-------------------->>>
            ((ButtonTool)this.tToolbarsManager_MainMenu.Tools[15]).SharedProps.Enabled = true;
            // ---ADD 2010/08/10--------------------<<<

            // XMLデータ読込
            LoadStateXmlData();

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
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2009/01/19</br>
        /// </remarks>
        private void tComboEditor_GridFontSize_ValueChanged(object sender, EventArgs e)
        {
            if (this.tComboEditor_GridFontSize.Value == null)
            {
                this.uGrid_Details.DisplayLayout.Appearance.FontData.SizeInPoints = (int)11;
                this.Form1_Top_Panel5.Size = new Size(295, 23);
                this.uLabel_SaleRate.Size = new Size(295, 23);
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
                            this.Form1_Top_Panel5.Size = new Size(295, 31);
                            this.uLabel_SaleRate.Size = new Size(295, 15);
                            break;
                        }
                    case 8:
                        {
                            this.Form1_Top_Panel5.Size = new Size(295, 28);
                            this.uLabel_SaleRate.Size = new Size(295, 18);
                            break;
                        }
                    case 9:
                        {
                            this.Form1_Top_Panel5.Size = new Size(295, 26);
                            this.uLabel_SaleRate.Size = new Size(295, 20);
                            break;
                        }
                    case 10:
                        {
                            this.Form1_Top_Panel5.Size = new Size(295, 25);
                            this.uLabel_SaleRate.Size = new Size(295, 21);
                            break;
                        }
                    case 11:
                        {
                            this.Form1_Top_Panel5.Size = new Size(295, 23);
                            this.uLabel_SaleRate.Size = new Size(295, 23);
                            break;
                        }
                    case 12:
                        {
                            this.Form1_Top_Panel5.Size = new Size(295, 22);
                            this.uLabel_SaleRate.Size = new Size(295, 24);
                            break;
                        }
                    case 14:
                        {
                            this.Form1_Top_Panel5.Size = new Size(295, 19);
                            this.uLabel_SaleRate.Size = new Size(295, 27);
                            break;
                        }
                }
            }
        }

        /// <summary>
        /// ValueChanged イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : 対象区分コンボボックスの値が変更された時に発生します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2009/01/19</br>
        /// <br>UpdateNote  : キーボード操作の改良を行う。</br>
        /// <br>Programmer  : PM1012C 朱 猛</br>
        /// <br>Date        : 2010/08/10</br>
        /// </remarks>
        private void tComboEditor_TargetDivide_ValueChanged(object sender, EventArgs e)
        {
            if (this.tComboEditor_TargetDivide.Value == null)
            {
                this.tComboEditor_TargetDivide.Value = 0;
            }

            // ---UPD 2010/08/10-------------------->>>
            //if ((int)this.tComboEditor_TargetDivide.Value == 0)
            if ("0".Equals(this.tComboEditor_TargetDivide.Value.ToString()))
            // ---UPD 2010/08/10--------------------<<<
            {
                // 得意先掛率Ｇ
                this.panel_Customer.Visible = false;
                this.panel_Customer.Size = new Size(573, 1);
                this.panel_Customer.Location = new Point(10, 34);

                this.panel_CustRateGrp.Size = new Size(573, 88);
                this.panel_CustRateGrp.Location = new Point(10, 36);
                this.panel_CustRateGrp.Visible = true;

                // ADD 2009/12/01 3次分対応 得意先掛率グループ改良 ---------->>>>>
                // HACK:得意先掛率グループ：未設定
                this.chkSearchingAll.Visible = true;
                // ADD 2009/12/01 3次分対応 得意先掛率グループ改良 ----------<<<<<
            }
            // ---UPD 2010/08/10-------------------->>>
            //else
            else if ("1".Equals(this.tComboEditor_TargetDivide.Value.ToString()))
            // ---UPD 2010/08/10--------------------<<<
            {
                // 得意先
                this.panel_CustRateGrp.Visible = false;
                this.panel_CustRateGrp.Size = new Size(573, 1);
                this.panel_CustRateGrp.Location = new Point(10, 34);

                this.panel_Customer.Size = new Size(573, 88);
                this.panel_Customer.Location = new Point(10, 36);
                this.panel_Customer.Visible = true;

                // ADD 2009/12/01 3次分対応 得意先掛率グループ改良 ---------->>>>>
                // HACK:得意先掛率グループ：未設定
                this.chkSearchingAll.Visible = false;
                // ADD 2009/12/01 3次分対応 得意先掛率グループ改良 ----------<<<<<
            }
            // ---ADD 2010/08/10-------------------->>>
            else
            {
            }
            // ---ADD 2010/08/10--------------------<<<
        }

        /// <summary>
        /// Leave イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : 得意先掛率Ｇからフォーカスが離れた時に発生します。</br>
        /// <br>Programmer  : 30414 忍 幸史</br>
        /// <br>Date        : 2009/01/19</br>
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
        /// <br>Programmer : 30414 忍 幸史</br>
        /// <br>Date       : 2009/01/19</br>
        /// <br>UpdateNote  : キーボード操作の改良を行う。</br>
        /// <br>Programmer  : PM1012C 朱 猛</br>
        /// <br>Date        : 2010/08/10</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

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
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "指定された条件で得意先コードは存在しませんでした。",
                                    -1,
                                    MessageBoxButtons.OK);
                                control.DataText = _prevCode;
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
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_INFO,
                                        this.Name,
                                        "指定された条件で得意先掛率Ｇコードは存在しませんでした。",
                                        -1,
                                        MessageBoxButtons.OK);
                                    control.DataText = _prevCode;
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

            // ---ADD 2010/08/10-------------------->>>
            // ガイド有効/無効の設定
            bool flag = false;
            switch (e.NextCtrl.Name)
            {
                // 拠点
                case "tEdit_SectionCodeAllowZero":
                // 仕入先
                case "tNedit_SupplierCd":
                // 商品掛率Ｇ
                case "tNedit_GoodsMGroup":
                // メーカー
                case "tNedit_GoodsMakerCd":
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
                    // 仕入先
                    case "tNedit_SupplierCd":
                    // 商品掛率Ｇ
                    case "tNedit_GoodsMGroup":
                    // メーカー
                    case "tNedit_GoodsMakerCd":
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

            ((ButtonTool)this.tToolbarsManager_MainMenu.Tools[15]).SharedProps.Enabled = flag;
            // ---ADD 2010/08/10--------------------<<<

            switch (e.PrevCtrl.Name)
            {
                // 拠点コード
                case "tEdit_SectionCodeAllowZero":
                    {
                        string sectionCode = this.tEdit_SectionCodeAllowZero.DataText.Trim();
                        // --- DEL 2010/08/30 ---------------------------------->>>>>
                        //this.tEdit_SectionName.DataText = GetSectionName(sectionCode);
                        // --- DEL 2010/08/30 ---------------------------------->>>>>
                        // --- ADD 2010/08/30 ---------------------------------->>>>>
                        bool hasFlg = false;
                        if (!string.IsNullOrEmpty(sectionCode))
                        {
                            // 拠点名称を取る
                            string sectionName = GetSectionName(sectionCode);

                            // マスタに存在しない場合
                            if (string.IsNullOrEmpty(sectionName))
                            {
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "指定された条件で拠点コードは存在しませんでした。",
                                    -1,
                                    MessageBoxButtons.OK);
                                this.tEdit_SectionCodeAllowZero.Text = _prevCode;
                            }
                            else
                            {
                                // 該当するデータが存在した場合
                                this.tEdit_SectionName.DataText = sectionName;
                                _prevCode = sectionCode;
                                hasFlg = true;
                            }
                        }
                        else
                        {
                            this.tEdit_SectionName.DataText = string.Empty;
                        }
                        // --- ADD 2010/08/30 ----------------------------------<<<<<

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tEdit_SectionName.DataText.Trim() != "")
                                {
                                    // フォーカス移動
                                    e.NextCtrl = this.tNedit_SupplierCd;
                                    // ---ADD 2010/08/10-------------------->>>
                                    ((ButtonTool)this.tToolbarsManager_MainMenu.Tools[15]).SharedProps.Enabled = true;
                                    // ---ADD 2010/08/10--------------------<<<

                                    // --- ADD 2010/08/30 ---------------------------------->>>>>
                                    if (!hasFlg)
                                    {
                                        e.NextCtrl = this.SectionGuide_Button;
                                    }
                                    // --- ADD 2010/08/30 ----------------------------------<<<<<
                                }
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                // フォーカス移動
                                e.NextCtrl = e.PrevCtrl;
                                // ---ADD 2010/08/10-------------------->>>
                                ((ButtonTool)this.tToolbarsManager_MainMenu.Tools[15]).SharedProps.Enabled = true;
                                // ---ADD 2010/08/10--------------------<<<
                            }
                        }
                        break;
                    }
                // 仕入先コード
                case "tNedit_SupplierCd":
                    {
                        int supplierCode = this.tNedit_SupplierCd.GetInt();
                        // --- DEL 2010/08/30 ---------------------------------->>>>>
                        //this.tEdit_SupplierName.DataText = GetSupplierName(supplierCode);
                        // --- DEL 2010/08/30 ---------------------------------->>>>>
                        // --- ADD 2010/08/30 ---------------------------------->>>>>
                        bool hasFlg = false;
                        if (!string.IsNullOrEmpty(this.tNedit_SupplierCd.Text))
                        {
                            // 仕入先名称を取る
                            string supplierName = GetSupplierName(supplierCode);

                            // マスタに存在しない場合
                            if (string.IsNullOrEmpty(supplierName))
                            {
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "指定された条件で仕入先コードは存在しませんでした。",
                                    -1,
                                    MessageBoxButtons.OK);
                                this.tNedit_SupplierCd.Text = _prevCode;
                            }
                            else
                            {
                                // 該当するデータが存在した場合
                                this.tEdit_SupplierName.DataText = supplierName;
                                _prevCode = supplierCode.ToString();
                                hasFlg = true;
                            }
                        }
                        else
                        {
                            this.tEdit_SupplierName.DataText = string.Empty;
                        }
                        // --- ADD 2010/08/30 ----------------------------------<<<<<

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                //if (this.tEdit_SupplierName.DataText.Trim() != "")    // DEL 2009/06/29
                                if (CheckSupplier(supplierCode))    // ADD 2009/06/29
                                {
                                    // フォーカス移動
                                    e.NextCtrl = this.tNedit_GoodsMGroup;
                                    // ---ADD 2010/08/10-------------------->>>
                                    ((ButtonTool)this.tToolbarsManager_MainMenu.Tools[15]).SharedProps.Enabled = true;
                                    // ---ADD 2010/08/10--------------------<<<

                                    // --- ADD 2010/08/30 ---------------------------------->>>>>
                                    if (!hasFlg)
                                    {
                                        e.NextCtrl = this.SupplierGuide_Button;
                                    }
                                    // --- ADD 2010/08/30 ----------------------------------<<<<<
                                }
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                // フォーカス移動
                                if (this.tEdit_SectionName.DataText.Trim() != "")
                                {
                                    e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                                    // ---ADD 2010/08/10-------------------->>>
                                    ((ButtonTool)this.tToolbarsManager_MainMenu.Tools[15]).SharedProps.Enabled = true;
                                    // ---ADD 2010/08/10--------------------<<<
                                }
                            }
                        }
                        break;
                    }
                // 商品掛率Ｇコード
                case "tNedit_GoodsMGroup":
                    {
                        int goodsGroupCode = this.tNedit_GoodsMGroup.GetInt();
                        // --- DEL 2010/08/30 ---------------------------------->>>>>
                        //this.tEdit_GoodsRateGrpName.DataText = GetGoodsGroupName(goodsGroupCode);
                        // --- DEL 2010/08/30 ---------------------------------->>>>>
                        // --- ADD 2010/08/30 ---------------------------------->>>>>
                        bool hasFlg = false;
                        if (!string.IsNullOrEmpty(this.tNedit_GoodsMGroup.Text))
                        {
                            // 商品掛率Ｇ名称を取る
                            string goodsGroupName = GetGoodsGroupName(goodsGroupCode);

                            // マスタに存在しない場合
                            if (string.IsNullOrEmpty(goodsGroupName))
                            {
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "指定された条件で商品掛率Ｇコードは存在しませんでした。",
                                    -1,
                                    MessageBoxButtons.OK);
                                this.tNedit_GoodsMGroup.Text = _prevCode;
                            }
                            else
                            {
                                // 該当するデータが存在した場合
                                this.tEdit_GoodsRateGrpName.DataText = goodsGroupName;
                                _prevCode = goodsGroupCode.ToString();
                                hasFlg = true;
                            }
                        }
                        else
                        {
                            this.tEdit_GoodsRateGrpName.DataText = string.Empty;
                        }
                        // --- ADD 2010/08/30 ----------------------------------<<<<<

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tEdit_GoodsRateGrpName.DataText.Trim() != "")
                                {
                                    // フォーカス移動
                                    e.NextCtrl = this.tNedit_GoodsMakerCd;
                                    // ---ADD 2010/08/10-------------------->>>
                                    ((ButtonTool)this.tToolbarsManager_MainMenu.Tools[15]).SharedProps.Enabled = true;
                                    // ---ADD 2010/08/10--------------------<<<

                                    // --- ADD 2010/08/30 ---------------------------------->>>>>
                                    if (!hasFlg)
                                    {
                                        e.NextCtrl = this.GoodsRateGrpGuide_Button;
                                    }
                                    // --- ADD 2010/08/30 ----------------------------------<<<<<
                                }
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                // フォーカス移動
                                if (this.tEdit_SupplierName.DataText.Trim() != "")
                                {
                                    e.NextCtrl = this.tNedit_SupplierCd;
                                    // ---ADD 2010/08/10-------------------->>>
                                    ((ButtonTool)this.tToolbarsManager_MainMenu.Tools[15]).SharedProps.Enabled = true;
                                    // ---ADD 2010/08/10--------------------<<<
                                }
                            }
                        }
                        break;
                    }
                // メーカーコード
                case "tNedit_GoodsMakerCd":
                    {
                        int makerCode = this.tNedit_GoodsMakerCd.GetInt();
                        // --- DEL 2010/08/30 ---------------------------------->>>>>
                        //this.tEdit_MakerName.DataText = GetMakerName(makerCode);
                        // --- DEL 2010/08/30 ---------------------------------->>>>>
                        // --- ADD 2010/08/30 ---------------------------------->>>>>
                        bool hasFlg = false;
                        if (!string.IsNullOrEmpty(this.tNedit_GoodsMakerCd.Text))
                        {
                            // メーカー名称を取る
                            string makerName = GetMakerName(makerCode);

                            // マスタに存在しない場合
                            if (string.IsNullOrEmpty(makerName))
                            {
                                TMsgDisp.Show(
                                    this,
                                    emErrorLevel.ERR_LEVEL_INFO,
                                    this.Name,
                                    "指定された条件でメーカーコードは存在しませんでした。",
                                    -1,
                                    MessageBoxButtons.OK);
                                this.tNedit_GoodsMakerCd.Text = _prevCode;
                            }
                            else
                            {
                                // 該当するデータが存在した場合
                                this.tEdit_MakerName.DataText = makerName;
                                _prevCode = makerCode.ToString();
                                hasFlg = true;
                            }
                        }
                        else
                        {
                            this.tEdit_MakerName.DataText = string.Empty;
                        }
                        // --- ADD 2010/08/30 ----------------------------------<<<<<

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                            {
                                if (this.tEdit_MakerName.DataText.Trim() != "")
                                {
                                    // フォーカス移動
                                    e.NextCtrl = this.tComboEditor_TargetDivide;
                                    // ---ADD 2010/08/10-------------------->>>
                                    ((ButtonTool)this.tToolbarsManager_MainMenu.Tools[15]).SharedProps.Enabled = false;
                                    // ---ADD 2010/08/10--------------------<<<

                                    // --- ADD 2010/08/30 ---------------------------------->>>>>
                                    if (!hasFlg)
                                    {
                                        e.NextCtrl = this.MakerGuide_Button;
                                    }
                                    // --- ADD 2010/08/30 ----------------------------------<<<<<
                                }
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                // フォーカス移動
                                if (this.tEdit_GoodsRateGrpName.DataText.Trim() != "")
                                {
                                    e.NextCtrl = this.tNedit_GoodsMGroup;
                                    // ---ADD 2010/08/10-------------------->>>
                                    ((ButtonTool)this.tToolbarsManager_MainMenu.Tools[15]).SharedProps.Enabled = true;
                                    // ---ADD 2010/08/10--------------------<<<
                                }
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
                                e.NextCtrl = this.tComboEditor_TargetDivide;
                                // ---ADD 2010/08/10-------------------->>>
                                ((ButtonTool)this.tToolbarsManager_MainMenu.Tools[15]).SharedProps.Enabled = false;
                                // ---ADD 2010/08/10--------------------<<<
                            }
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
                                if (this.tEdit_MakerName.DataText.Trim() != "")
                                {
                                    e.NextCtrl = this.tNedit_GoodsMakerCd;
                                    // ---ADD 2010/08/10-------------------->>>
                                    ((ButtonTool)this.tToolbarsManager_MainMenu.Tools[15]).SharedProps.Enabled = true;
                                    // ---ADD 2010/08/10--------------------<<<
                                }
                                else
                                {
                                    e.NextCtrl = this.MakerGuide_Button;
                                    // ---ADD 2010/08/10-------------------->>>
                                    ((ButtonTool)this.tToolbarsManager_MainMenu.Tools[15]).SharedProps.Enabled = false;
                                    // ---ADD 2010/08/10--------------------<<<
                                }
                            }
                        }
                        // ---ADD 2010/08/10-------------------->>>
                        // リスト項目をコードからでも入力可能へ変更
                        this.setTComboEditorByName(e.PrevCtrl.Name);
                        if (e.PrevCtrl is TComboEditor)
                        {
                            this._preComboEditorValue = ((TComboEditor)e.PrevCtrl).Value;
                        }
                        // ---ADD 2010/08/10--------------------<<<
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

                                e.NextCtrl = this.AllExpand_Button;
                            }
                        }
                        break;
                    }
                // 展開ボタン
                case "Expand_Button":
                    {
                        if (e.ShiftKey == true)
                        {
                            if (e.Key == Keys.Tab)
                            {
                                if ((Standard_UGroupBox.Expanded == false) &&
                                    (Standard_UGroupBox2.Expanded == false))
                                {
                                    e.NextCtrl = e.PrevCtrl;
                                }
                                else if (Standard_UGroupBox2.Expanded == true)
                                {
                                    if ((int)this.tComboEditor_TargetDivide.Value == 0)
                                    {
                                        // 得意先掛率Ｇ
                                        e.NextCtrl = this.tNedit_CustRateGrpCode21;
                                        // ---ADD 2010/08/10-------------------->>>
                                        ((ButtonTool)this.tToolbarsManager_MainMenu.Tools[15]).SharedProps.Enabled = true;
                                        // ---ADD 2010/08/10--------------------<<<
                                    }
                                    else
                                    {
                                        // 得意先
                                        e.NextCtrl = this.tNedit_CustomerCode21;
                                        // ---ADD 2010/08/10-------------------->>>
                                        ((ButtonTool)this.tToolbarsManager_MainMenu.Tools[15]).SharedProps.Enabled = true;
                                        // ---ADD 2010/08/10--------------------<<<
                                    }
                                }
                                else
                                {
                                    if (this.tEdit_MakerName.DataText.Trim() != "")
                                    {
                                        e.NextCtrl = this.tNedit_GoodsMakerCd;
                                        // ---ADD 2010/08/10-------------------->>>
                                        ((ButtonTool)this.tToolbarsManager_MainMenu.Tools[15]).SharedProps.Enabled = true;
                                        // ---ADD 2010/08/10--------------------<<<
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.MakerGuide_Button;
                                        // ---ADD 2010/08/10-------------------->>>
                                        ((ButtonTool)this.tToolbarsManager_MainMenu.Tools[15]).SharedProps.Enabled = false;
                                        // ---ADD 2010/08/10--------------------<<<
                                    }
                                }
                            }
                        }
                        break;
                    }
                // 全展開ボタン
                case "AllExpand_Button":
                    {
                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                            {
                                //e.NextCtrl = this.uGrid_Details;// DEL 2013/07/08 掛率マスタ一括登録修正既存障害の対応依頼
                                // ADD 2013/07/08 掛率マスタ一括登録修正既存障害の対応依頼 ---------->>>>>
                                e.NextCtrl = null;
                                GetNextCell(0, 0);
                                // ADD 2013/07/08 掛率マスタ一括登録修正既存障害の対応依頼 ----------<<<<<
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
                            {
                                if (this.Expand_Button.Enabled == false)
                                {
                                    if ((Standard_UGroupBox.Expanded == false) &&
                                        (Standard_UGroupBox2.Expanded == false))
                                    {
                                        e.NextCtrl = e.PrevCtrl;
                                    }
                                    else if (Standard_UGroupBox2.Expanded == true)
                                    {
                                        if ((int)this.tComboEditor_TargetDivide.Value == 0)
                                        {
                                            // 得意先掛率Ｇ
                                            e.NextCtrl = this.tNedit_CustRateGrpCode21;
                                            // ---ADD 2010/08/10-------------------->>>
                                            ((ButtonTool)this.tToolbarsManager_MainMenu.Tools[15]).SharedProps.Enabled = true;
                                            // ---ADD 2010/08/10--------------------<<<
                                        }
                                        else
                                        {
                                            // 得意先
                                            e.NextCtrl = this.tNedit_CustomerCode21;
                                            // ---ADD 2010/08/10-------------------->>>
                                            ((ButtonTool)this.tToolbarsManager_MainMenu.Tools[15]).SharedProps.Enabled = true;
                                            // ---ADD 2010/08/10--------------------<<<
                                        }
                                    }
                                    else
                                    {
                                        if (this.tEdit_MakerName.DataText.Trim() != "")
                                        {
                                            e.NextCtrl = this.tNedit_GoodsMakerCd;
                                            // ---ADD 2010/08/10-------------------->>>
                                            ((ButtonTool)this.tToolbarsManager_MainMenu.Tools[15]).SharedProps.Enabled = true;
                                            // ---ADD 2010/08/10--------------------<<<
                                        }
                                        else
                                        {
                                            e.NextCtrl = this.MakerGuide_Button;
                                            // ---ADD 2010/08/10-------------------->>>
                                            ((ButtonTool)this.tToolbarsManager_MainMenu.Tools[15]).SharedProps.Enabled = false;
                                            // ---ADD 2010/08/10--------------------<<<
                                        }
                                    }
                                }
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
                                    // ---ADD 2010/08/10-------------------->>>
                                    ((ButtonTool)this.tToolbarsManager_MainMenu.Tools[15]).SharedProps.Enabled = false;
                                    // ---ADD 2010/08/10--------------------<<<
                                    this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index].Cells[COLUMN_COSTRATE].Activate();
                                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                    return;
                                }
                                else
                                {
                                    if (this.uGrid_Details.Rows.Count == 0)
                                    {
                                        if (Standard_UGroupBox.Expanded == true)
                                        {
                                            e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                                            // ---ADD 2010/08/10-------------------->>>
                                            ((ButtonTool)this.tToolbarsManager_MainMenu.Tools[15]).SharedProps.Enabled = true;
                                            // ---ADD 2010/08/10--------------------<<<
                                        }
                                        else if (Standard_UGroupBox2.Expanded == true)
                                        {
                                            e.NextCtrl = tComboEditor_TargetDivide;
                                            // ---ADD 2010/08/10-------------------->>>
                                            ((ButtonTool)this.tToolbarsManager_MainMenu.Tools[15]).SharedProps.Enabled = false;
                                            // ---ADD 2010/08/10--------------------<<<
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
                                        // ---ADD 2010/08/10-------------------->>>
                                        ((ButtonTool)this.tToolbarsManager_MainMenu.Tools[15]).SharedProps.Enabled = false;
                                        // ---ADD 2010/08/10--------------------<<<
                                        this.uGrid_Details.Rows[0].Cells[COLUMN_COSTRATE].Activate();
                                        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                        return;
                                    }
                                }

                                e.NextCtrl = null;
                                // ---ADD 2010/08/10-------------------->>>
                                ((ButtonTool)this.tToolbarsManager_MainMenu.Tools[15]).SharedProps.Enabled = false;
                                // ---ADD 2010/08/10--------------------<<<

                                if (colIndex < 7)
                                {
                                    // 仕入率にフォーカス
                                    this.uGrid_Details.Rows[rowIndex].Cells[COLUMN_COSTRATE].Activate();
                                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                    return;
                                }
                                else if (colIndex == COLINDEX_SALERATE_ST + this._targetDic.Count - 1)
                                {
                                    //if (rowIndex == this.uGrid_Details.Rows.VisibleRowCount - 1)  // DEL 2009/06/19
                                    //if (rowIndex == this.uGrid_Details.Rows.VisibleRowCount)    // ADD 2009/06/19 // DEL 2009/06/30
                                    if (rowIndex == this.uGrid_Details.Rows.Count - 1)    // ADD 2009/06/30
                                    {
                                        // フォーカス移動なし
                                        this.uGrid_Details.Rows[rowIndex].Cells[colIndex].Activate();
                                        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                        return;
                                    }
                                    // DEL 2009/06/30 ------>>>
                                    ////else if (rowIndex >= this.uGrid_Details.Rows.VisibleRowCount - 1) // DEL 2009/06/19
                                    //else if (rowIndex >= this.uGrid_Details.Rows.VisibleRowCount)   // ADD 2009/06/19
                                    //{
                                    //    e.NextCtrl = null;
                                    //    this.uGrid_Details.PerformAction(UltraGridAction.ExitEditMode);
                                    //    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                    //    return;
                                    //}
                                    // DEL 2009/06/30 ------<<<
                                    else
                                    {
                                        // DEL 2009/06/19 ------>>>
                                        //// 1行下の仕入率にフォーカス
                                        //this.uGrid_Details.Rows[rowIndex + 1].Cells[COLUMN_COSTRATE].Activate();
                                        //this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                        // DEL 2009/06/19 ------<<<
                            
                                        // ADD 2009/06/19 ------>>>
                                        // 表示されている行の仕入率にフォーカス
                                        #region DEL 2013/07/08 掛率マスタ一括登録修正既存障害の対応依頼
                                        //for (int i = rowIndex + 1; i < this.uGrid_Details.Rows.Count; i++)
                                        //{
                                        //    if (!this.uGrid_Details.Rows[i].Hidden)
                                        //    {
                                        //        this.uGrid_Details.Rows[i].Cells[COLUMN_COSTRATE].Activate();
                                        //        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                        //        break;
                                        //    }
                                        //}
                                        #endregion
                                        GetNextCell(rowIndex, colIndex);// ADD 2013/07/08 掛率マスタ一括登録修正既存障害の対応依頼
                                        // ADD 2009/06/19 ------<<<
                                        return;
                                    }
                                }
                                else
                                {
                                    //this.uGrid_Details.PerformAction(UltraGridAction.NextCellByTab); DEL DEL 2013/07/08 掛率マスタ一括登録修正既存障害の対応依頼
                                    GetNextCell(rowIndex, colIndex);// ADD 2013/07/08 掛率マスタ一括登録修正既存障害の対応依頼
                                }
                            }
                        }
                        else
                        {
                            if (e.Key == Keys.Tab)
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
                                    rowIndex = this.uGrid_Details.ActiveRow.Index;
                                    colIndex = 7;
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
                                                // ---ADD 2010/08/10-------------------->>>
                                                ((ButtonTool)this.tToolbarsManager_MainMenu.Tools[15]).SharedProps.Enabled = true;
                                                // ---ADD 2010/08/10--------------------<<<
                                            }
                                            else
                                            {
                                                // 得意先
                                                e.NextCtrl = this.tNedit_CustomerCode21;
                                                // ---ADD 2010/08/10-------------------->>>
                                                ((ButtonTool)this.tToolbarsManager_MainMenu.Tools[15]).SharedProps.Enabled = true;
                                                // ---ADD 2010/08/10--------------------<<<
                                            }
                                        }
                                        else if (Standard_UGroupBox.Expanded == true)
                                        {
                                            if (this.tEdit_MakerName.DataText.Trim() != "")
                                            {
                                                e.NextCtrl = this.tNedit_GoodsMakerCd;
                                                // ---ADD 2010/08/10-------------------->>>
                                                ((ButtonTool)this.tToolbarsManager_MainMenu.Tools[15]).SharedProps.Enabled = true;
                                                // ---ADD 2010/08/10--------------------<<<
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.MakerGuide_Button;
                                                // ---ADD 2010/08/10-------------------->>>
                                                ((ButtonTool)this.tToolbarsManager_MainMenu.Tools[15]).SharedProps.Enabled = false;
                                                // ---ADD 2010/08/10--------------------<<<
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
                                        e.NextCtrl = this.AllExpand_Button;
                                        return;
                                    }
                                }

                                e.NextCtrl = null;
                                // ---ADD 2010/08/10-------------------->>>
                                ((ButtonTool)this.tToolbarsManager_MainMenu.Tools[15]).SharedProps.Enabled = false;
                                // ---ADD 2010/08/10--------------------<<<

                                if (colIndex <= 7)
                                {
                                    if (rowIndex == 0)
                                    {
                                        e.NextCtrl = this.AllExpand_Button;
                                    }
                                    else
                                    {
                                        // DEL 2009/06/19 ------>>>
                                        //this.uGrid_Details.Rows[rowIndex - 1].Cells[COLINDEX_SALERATE_ST + this._targetDic.Count - 1].Activate();
                                        //this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                        // DEL 2009/06/19 ------<<<
                            
                                        // ADD 2009/06/19 ------>>>
                                        // 表示されている行の掛率Ｇにフォーカス
                                        #region DEL 2013/07/08 掛率マスタ一括登録修正既存障害の対応依頼
                                        //for (int i = rowIndex - 1; i >= 0; i--)
                                        //{
                                        //    if (!this.uGrid_Details.Rows[i].Hidden)
                                        //    {
                                        //        this.uGrid_Details.Rows[i].Cells[COLINDEX_SALERATE_ST + this._targetDic.Count - 1].Activate();
                                        //        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                        //        break;
                                        //    }
                                        //}
                                        #endregion
                                        GetPreCell(rowIndex, colIndex);// ADD 2013/07/08 掛率マスタ一括登録修正既存障害の対応依頼
                                        // ADD 2009/06/19 ------<<<
                                    }
                                }
                                else
                                {
                                    //this.uGrid_Details.PerformAction(UltraGridAction.PrevCellByTab);// DEL 2013/07/08 掛率マスタ一括登録修正既存障害の対応依頼
                                    GetPreCell(rowIndex, colIndex);// ADD 2013/07/08 掛率マスタ一括登録修正既存障害の対応依頼
                                }
                                //if ((rowIndex == 0) && (colIndex == 7))
                                //{
                                //    e.NextCtrl = this.AllExpand_Button;
                                //}
                                //else
                                //{
                                //    this.uGrid_Details.PerformAction(UltraGridAction.PrevCellByTab);
                                //}
                            }
                        }
                        break;
                    }
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
                                    // --- ADD 2010/08/31 ---------------------------------->>>>>
                                    if ("tNedit_GoodsMakerCd".Equals(e.PrevCtrl.Name) || panel_CustRateGrp.Contains(e.PrevCtrl) || panel_Customer.Contains(e.PrevCtrl))
                                    {
                                        ((ButtonTool)this.tToolbarsManager_MainMenu.Tools[15]).SharedProps.Enabled = true;
                                    }
                                    // --- ADD 2010/08/31 ----------------------------------<<<<<
                                }
                                else
                                {
                                    e.NextCtrl = null;
                                    #region DEL 2013/07/08 掛率マスタ一括登録修正既存障害の対応依頼
                                    //this.uGrid_Details.Rows[0].Cells[COLUMN_COSTRATE].Activate();
                                    //this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                    #endregion
                                    GetNextCell(0, 0);// ADD 2013/07/08 掛率マスタ一括登録修正既存障害の対応依頼
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
                                        // ---ADD 2010/08/10-------------------->>>
                                        ((ButtonTool)this.tToolbarsManager_MainMenu.Tools[15]).SharedProps.Enabled = true;
                                        // ---ADD 2010/08/10--------------------<<<
                                    }
                                    else
                                    {
                                        if ((int)this.tComboEditor_TargetDivide.Value == 0)
                                        {
                                            // 得意先掛率Ｇ
                                            e.NextCtrl = this.tNedit_CustRateGrpCode15;
                                            // ---ADD 2010/08/10-------------------->>>
                                            ((ButtonTool)this.tToolbarsManager_MainMenu.Tools[15]).SharedProps.Enabled = true;
                                            // ---ADD 2010/08/10--------------------<<<
                                        }
                                        else
                                        {
                                            // 得意先
                                            e.NextCtrl = this.tNedit_CustomerCode15;
                                            // ---ADD 2010/08/10-------------------->>>
                                            ((ButtonTool)this.tToolbarsManager_MainMenu.Tools[15]).SharedProps.Enabled = true;
                                            // ---ADD 2010/08/10--------------------<<<
                                        }
                                    }
                                }
                                else
                                {
                                    e.NextCtrl = null;
                                    this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[COLUMN_COSTRATE].Activate();
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
                                    if (this.Expand_Button.Enabled == false)
                                    {
                                        if ((Standard_UGroupBox.Expanded == false) &&
                                            (Standard_UGroupBox2.Expanded == false))
                                        {
                                            e.NextCtrl = e.PrevCtrl;
                                        }
                                        else if (Standard_UGroupBox2.Expanded == true)
                                        {
                                            if ((int)this.tComboEditor_TargetDivide.Value == 0)
                                            {
                                                // 得意先掛率Ｇ
                                                e.NextCtrl = this.tNedit_CustRateGrpCode21;
                                                // ---ADD 2010/08/10-------------------->>>
                                                ((ButtonTool)this.tToolbarsManager_MainMenu.Tools[15]).SharedProps.Enabled = true;
                                                // ---ADD 2010/08/10--------------------<<<
                                            }
                                            else
                                            {
                                                // 得意先
                                                e.NextCtrl = this.tNedit_CustomerCode21;
                                                // ---ADD 2010/08/10-------------------->>>
                                                ((ButtonTool)this.tToolbarsManager_MainMenu.Tools[15]).SharedProps.Enabled = true;
                                                // ---ADD 2010/08/10--------------------<<<
                                            }
                                        }
                                        else
                                        {
                                            if (this.tEdit_MakerName.DataText.Trim() != "")
                                            {
                                                e.NextCtrl = this.tNedit_GoodsMakerCd;
                                                // ---ADD 2010/08/10-------------------->>>
                                                ((ButtonTool)this.tToolbarsManager_MainMenu.Tools[15]).SharedProps.Enabled = true;
                                                // ---ADD 2010/08/10--------------------<<<
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.MakerGuide_Button;
                                                // ---ADD 2010/08/10-------------------->>>
                                                ((ButtonTool)this.tToolbarsManager_MainMenu.Tools[15]).SharedProps.Enabled = false;
                                                // ---ADD 2010/08/10--------------------<<<
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    e.NextCtrl = null;
                                    this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[COLINDEX_SALERATE_ST + this._targetDic.Keys.Count - 1].Activate();
                                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                }
                            }
                        }
                        break;
                    }
            }

            // --- ADD 2010/08/30 ---------------------------------->>>>>
            if (e.NextCtrl != null)
            {
                switch (e.NextCtrl.Name)
                {
                    case "tEdit_SectionCodeAllowZero":
                        {
                            if (((TEdit)e.NextCtrl).Value == null)
                            {
                                this._prevCode = string.Empty;
                            }
                            else
                            {
                                this._prevCode = ((TEdit)e.NextCtrl).Value.ToString();
                            }
                            break;
                        }
                    case "tNedit_GoodsMakerCd":
                    case "tNedit_SupplierCd":
                    case "tNedit_GoodsMGroup":
                        {
                            if (((TNedit)e.NextCtrl).Value == null)
                            {
                                this._prevCode = string.Empty;
                            }
                            else
                            {
                                this._prevCode = ((TNedit)e.NextCtrl).Value.ToString();
                            }
                            break;
                        }
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
                            TNedit control = (TNedit)(this.GetType().GetField(e.NextCtrl.Name, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase).GetValue(this));
                            this._prevCode = control.Text;
                            break;
                        }
                }
            }
            // --- ADD 2010/08/30 ----------------------------------<<<<<
        }

        // ---ADD 2010/08/10-------------------->>>
        /// <summary>
        /// KeyDown イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : キー押下された時に発生します。</br>
        /// <br>Programmer : PM1012C 朱 猛</br>
        /// <br>Date       : 2010/08/10</br>
        /// </remarks>
        private void PMKHN09401UA_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                // 展開
                case Keys.F11:
                    {
                        Expand_Button_Click(this.Expand_Button, new EventArgs());
                        break;
                    }
                // 全展開
                case Keys.F12:
                    {
                        AllExpand_Button_Click(this.AllExpand_Button, new EventArgs());
                        break;
                    }
            }

        }
        // ---ADD 2010/08/10--------------------<<<


        #endregion ■ Control Events
    }
}
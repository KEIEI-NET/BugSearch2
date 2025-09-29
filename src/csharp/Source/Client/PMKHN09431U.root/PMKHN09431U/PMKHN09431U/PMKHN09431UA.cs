//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 売価一括修正
// プログラム概要   : 売価一括修正を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張凱
// 作 成 日  2009/04/14  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 修 正 日  2009/07/09  修正内容 : PVCS#323 項目名称の変更 
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張凱
// 修 正 日  2009/09/03  修正内容 : PVCS#427 明細部のクリア処理の変更 
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤
// 修 正 日  2009/11/30  修正内容 : 得意先掛率グループ改良 
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30531　大矢睦美
// 修 正 日  2010/04/20  修正内容 : 得意先掛率G未設定のとき、修正・更新できるよう修正 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using System.Collections;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 売価一括修正UIクラス
    /// </summary>
    /// <remarks>
    /// <br>Note        : 売価一括修正UIフォームクラス</br>
    /// <br>Programmer  : 張凱</br>
    /// <br>Date        : 2009/04/01</br>
    /// </remarks>
    public partial class PMKHN09431UA : Form
    {
        #region ■ Constants

        // アセンブリID
        private const string ASSEMBLY_ID = "PMKHN09431U";

        // 画面状態保存用ファイル名
        private const string XML_FILE_INITIAL_DATA = "PMKHN09431U.dat";

        // グリッド列
        private const string COLUMN_NO = "No";
        private const string COLUMN_GOODSNO = "GoodsNo";
        private const string COLUMN_PRICEFL = "PriceFl";
        private const string COLUMN_USERPRICEFL = "UserPriceFl";
        private const string COLUMN_RATEVAL = "RateVal";
        private const string COLUMN_GOODSMAKERCD = "GoodsMakerCd";
        private const string COLUMN_SALERATE1 = "SaleRate1";
        private const string COLUMN_SALERATE2 = "SaleRate2";
        private const string COLUMN_SALERATE3 = "SaleRate3";
        private const string COLUMN_SALERATE4 = "SaleRate4";
        private const string COLUMN_SALERATE5 = "SaleRate5";
        private const string COLUMN_SALERATE6 = "SaleRate6";
        private const string COLUMN_SALERATE7 = "SaleRate7";
        private const string COLUMN_SALERATE8 = "SaleRate8";
        private const string COLUMN_SALERATE9 = "SaleRate9";
        private const string COLUMN_SALERATE10 = "SaleRate10";
        private const string COLUMN_SALERATE11 = "SaleRate11";
        private const string COLUMN_SALERATE12 = "SaleRate12";
        private const string COLUMN_SALERATE13 = "SaleRate13";
        private const string COLUMN_SALERATE14 = "SaleRate14";
        private const string COLUMN_SALERATE15 = "SaleRate15";
        private const string COLUMN_SALERATE16 = "SaleRate16";
        private const string COLUMN_SALERATE17 = "SaleRate17";
        private const string COLUMN_SALERATE18 = "SaleRate18";
        private const string COLUMN_SALERATE19 = "SaleRate19";
        private const string COLUMN_SALERATE20 = "SaleRate20";
        private const string COLUMN_SALERATE21 = "SaleRate21";

        private const int COLINDEX_SALERATE_ST = 6;
        private const int COLINDEX_SALERATE_ED = 26;

        private const string FORMAT = "#,##0.00;-#,##0.00;''";
        private const string FORMAT_NO = "#,##0;-#,##0;''";

        #endregion ■ Constants

        #region ■ Private Members

        private ControlScreenSkin _controlScreenSkin;

        private string _enterpriseCode;

        private SecInfoAcs _secInfoAcs;                                 // 拠点情報アクセスクラス
        private SecInfoSetAcs _secInfoSetAcs;                           // 拠点情報設定アクセスクラス
        private MakerAcs _makerAcs;                                     // メーカーアクセスクラス
        private BLGoodsCdAcs _blGoodsCdAcs;                             // BLコードガイドアクセスクラス
        private UserGuideAcs _userGuideAcs;                             // ユーザーガイドアクセスクラス
        private SaleRateUpdateAcs _saleRateUpdateAcs;                //売価一括修正アクセスクラス

        // グリッド設定制御クラス
        private GridStateController _gridStateController;

        private Dictionary<string, SecInfoSet> _secInfoSetDic;
        private Dictionary<int, MakerUMnt> _makerDic;
        private Dictionary<int, BLGoodsCdUMnt> _bLGoodsCdDic;
        private Dictionary<int, string> _custRateGrpDic;

        private TNedit[] _tNedit_CustRateGrpCode;

        private Dictionary<int, int> _targetDic = new Dictionary<int, int>();

        private SalesRateSearchParam _extrInfo;

        private List<GoodsUnitData> _goodDisplayList;
        private List<Rate> _rateDisplayList;
        private List<Rate> _userRateDisplayList;
        private List<Rate> _rateDisplayListClone;

        // 抽出条件前回入力値(更新有無チェック用)
        private int _tmpGoodsMakerCd;
        private string _tmpSectionCode;
        private int _tmpBLGoodsCode;

        private string _searchSectionCode;

        DataTable _dataTableClone = new DataTable();

        private int _xml_static = 0;

        #endregion ■ Private Members

        #region ■ Constructor
        /// <summary>
        /// 売価一括修正UIクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note        : 売価一括修正UIフォームクラスのインスタンスを生成します。</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2009/04/01</br>
        /// </remarks>
        public PMKHN09431UA()
        {
            InitializeComponent();

            this._controlScreenSkin = new ControlScreenSkin();

            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            this._secInfoAcs = new SecInfoAcs();
            this._secInfoSetAcs = new SecInfoSetAcs();
            this._makerAcs = new MakerAcs();
            this._blGoodsCdAcs = new BLGoodsCdAcs();
            this._userGuideAcs = new UserGuideAcs();
            this._saleRateUpdateAcs = new SaleRateUpdateAcs();
            this._gridStateController = new GridStateController();

            // マスタ読込
            ReadSecInfoSet();
            ReadMakerUMnt();
            ReadBLGoodsCdUMnt();
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
        /// <br>Programmer	: 張凱</br>
        /// <br>Date		: 2009/04/01</br>
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
        /// <br>Programmer	: 張凱</br>
        /// <br>Date		: 2009/04/01</br>
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
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2009/04/01</br>
        /// </remarks>
        private void ReadSecInfoSet()
        {
            this._secInfoSetDic = new Dictionary<string, SecInfoSet>();

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
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2009/04/01</br>
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
        /// BLコードマスタ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : BLコードマスタを読み込み、バッファに保持します。</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2009/04/01</br>
        /// </remarks>
        private void ReadBLGoodsCdUMnt()
        {
            this._bLGoodsCdDic = new Dictionary<int, BLGoodsCdUMnt>();

            try
            {
                ArrayList retList;

                int status = this._blGoodsCdAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (BLGoodsCdUMnt bLGoodsCdUMnt in retList)
                    {
                        if (bLGoodsCdUMnt.LogicalDeleteCode == 0)
                        {
                            this._bLGoodsCdDic.Add(bLGoodsCdUMnt.BLGoodsCode, bLGoodsCdUMnt);
                        }
                    }
                }
            }
            catch
            {
                this._bLGoodsCdDic = new Dictionary<int, BLGoodsCdUMnt>();
            }
        }

        /// <summary>
        /// ユーザーガイドマスタ(得意先掛率Ｇ)読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : ユーザーガイドマスタを読み込み、バッファに保持します。</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2009/04/01</br>
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
                        this._custRateGrpDic.Add(userGdBd.GuideCode, userGdBd.GuideName.Trim());
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
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2009/04/01</br>
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
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2009/04/01</br>
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
        /// <param name="bLGoodsCode">メーカーコード</param>
        /// <returns>ＢＬコード名</returns>
        /// <remarks>
        /// <br>Note        : ＢＬコードに該当する名称を取得します。</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2009/04/01</br>
        /// </remarks>
        private string GetBLGoodsName(int bLGoodsCode)
        {
            if (this._bLGoodsCdDic.ContainsKey(bLGoodsCode))
            {
                return this._bLGoodsCdDic[bLGoodsCode].BLGoodsFullName.Trim();
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
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2009/04/01</br>
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

        #region チェック処理
        /// <summary>
        /// 検索条件チェック処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note        : 検索条件をチェックします。</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2009/04/01</br>
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
                    return (false);
                }

                // メーカーコード
                if (this.tNedit_GoodsMakerCd.GetInt() == 0)
                {
                    errMsg = "メーカーコードを入力してください。";
                    this.tNedit_GoodsMakerCd.Focus();
                    return (false);
                }

                bool inputFlg = false;

                // 得意先掛率Ｇ
                for (int index = 0; index < this._tNedit_CustRateGrpCode.Length; index++)
                {
                    if (this._tNedit_CustRateGrpCode[index].DataText.Trim() != "")
                    {
                        int custRateGrpCode = this._tNedit_CustRateGrpCode[index].GetInt();

                        if (GetCustRateGrpName(custRateGrpCode) == "")
                        {
                            errMsg = "指定された条件で得意先掛率Gは存在しませんでした。";
                            this._tNedit_CustRateGrpCode[index].Focus();
                            return (false);
                        }

                        inputFlg = true;
                    }
                }

                // ADD 2009/11/30 3次分対応 得意先掛率グループ改良 ---------->>>>>
                // TODO:得意先掛率グループの入力が無く、未設定チェックもない場合
                if (!inputFlg) inputFlg = this.chkSearchingAll.Checked;
                // ADD 2009/11/30 3次分対応 得意先掛率グループ改良 ----------<<<<<

                if (inputFlg == false)
                {
                    errMsg = "得意先掛率Ｇを入力してください。";
                    this.tNedit_CustRateGrpCode1.Focus();
                    return (false);
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
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2009/04/01</br>
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
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2009/04/01</br>
        /// </remarks>
        public bool CompareScreen()
        {
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
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2009/04/01</br>
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

        #region 初期設定
        /// <summary>
        /// 画面初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 画面情報の初期設定を行います。</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2009/04/01</br>
        /// </remarks>
        private void SetInitialSetting()
        {
            //---------------------------------
            // コントロール配列化
            //---------------------------------

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
            for (int index = 0; index < this._tNedit_CustRateGrpCode.Length; index++)
            {
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
            this.BLGoodsGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.MakerGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];

            //---------------------------------
            // グリッド設定
            //---------------------------------

            int status = this._gridStateController.LoadGridState(XML_FILE_INITIAL_DATA);

            _xml_static = status;

            CreateGrid(ref this.uGrid_Details);

        }

        #endregion 初期設定

        #region 保存
        /// <summary>
        /// TODO:保存処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 保存処理を行います。</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2009/04/01</br>
        /// </remarks>
        private int Save()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // 画面情報取得
            ArrayList updateList;
            ArrayList deleteList;

            GetUpdateList(out updateList, out deleteList);

            // 画面情報チェック
            string errMsg = "";

            try
            {
                if (this.uGrid_Details.Rows.Count == 0)
                {
                    errMsg = "保存対象データが存在しません。";
                    this.tEdit_SectionCodeAllowZero.Focus();
                    return (status);
                }
                if ((updateList.Count == 0) && (deleteList.Count == 0))
                {
                    errMsg = "保存対象データが存在しません。";
                    this.uGrid_Details.Rows[0].Cells[COLUMN_RATEVAL].Activate();
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
            if (deleteList.Count > 0 || updateList.Count > 0)
            {
                status = this._saleRateUpdateAcs.Save(ref deleteList, ref updateList, out errMsg);
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

                            this.tEdit_SectionCodeAllowZero.Focus();
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
                            return (status);
                        }
                }
            }

            // --- DEL 2009/09/03 ---------->>>>> 
            // 再検索
            //List<GoodsUnitData> goodsSearchResultList;
            //List<Rate> rateSearchResultList = new List<Rate>();
            //List<Rate> userRateSearchResultLis = new List<Rate>();

            //// 商品マスタ検索処理
            //status = this._saleRateUpdateAcs.Search(out goodsSearchResultList, this._extrInfo, out errMsg);

            //if (status == 0 && goodsSearchResultList.Count != 0)
            //{
            //    // 掛率マスタ.売価検索処理
            //    status = this._saleRateUpdateAcs.Search(out rateSearchResultList, out userRateSearchResultLis, goodsSearchResultList, this._extrInfo, out errMsg);
            //}

            //if (status == 0)
            //{
            //    // グリッド表示リスト取得
            //    GetDisplayList(goodsSearchResultList, rateSearchResultList, userRateSearchResultLis);

            //    // グリッドデータ設定
            //    CreateGrid(ref this.uGrid_Details);
            //}

            //this.uGrid_Details.ActiveRow = null;

            //this.tEdit_SectionCodeAllowZero.Focus();
            //--- DEL 2009/09/03 ----------<<<<<

            // 登録完了ダイアログ表示
            SaveCompletionDialog dialog = new SaveCompletionDialog();
            dialog.ShowDialog(2);

            return (status);
        }

        #endregion 保存

        #region 検索
        /// <summary>
        /// 検索処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 検索処理を行います。</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2009/04/01</br>
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

            int custRateGrpCode;

            TNedit[] CustRateGrpCode = new TNedit[21];
            CustRateGrpCode = this._tNedit_CustRateGrpCode;

            for (int i = 0; i < CustRateGrpCode.Length; i++)
            {
                for (int j = i; j < CustRateGrpCode.Length; j++)
                {
                    if (CustRateGrpCode[i].GetInt() >= CustRateGrpCode[j].GetInt())
                    {
                        TNedit x = CustRateGrpCode[i];
                        CustRateGrpCode[i] = CustRateGrpCode[j];
                        CustRateGrpCode[j] = x;
                    }
                }
            }

            // TODO:得意先掛率Ｇ
            // ADD 2009/11/30 3次分対応 得意先掛率グループ改良 ---------->>>>>
            if (this.chkSearchingAll.Checked)
            {
                this._targetDic.Add(SaleRateUpdateAcs.ALL_CUST_RATE_GRP_CODE, SaleRateUpdateAcs.ALL_CUST_RATE_GRP_CODE);
            }
            // ADD 2009/11/30 3次分対応 得意先掛率グループ改良 ----------<<<<<
            for (int index = 0; index < CustRateGrpCode.Length; index++)
            {
                if (CustRateGrpCode[index].DataText.Trim() == "")
                {
                    continue;
                }

                custRateGrpCode = CustRateGrpCode[index].GetInt();

                if (!this._targetDic.ContainsKey(custRateGrpCode))
                {
                    this._targetDic.Add(custRateGrpCode, custRateGrpCode);
                }
            }

            // 検索条件格納
            SetExtrInfo(out this._extrInfo);

            // 抽出中画面部品のインスタンスを作成
            SFCMN00299CA msgForm = new SFCMN00299CA();
            msgForm.Title = "抽出中";
            msgForm.Message = "商品マスタの抽出中です。";


            List<GoodsUnitData> goodsSearchResultList;
            List<Rate> rateSearchResultList = new List<Rate>();
            List<Rate> userRateSearchResultLis = new List<Rate>();

            try
            {
                msgForm.Show();

                string errMsg;

                _saleRateUpdateAcs.GoodsPriceUList = new ArrayList();

                // TODO:商品マスタ検索処理
                status = this._saleRateUpdateAcs.Search(out goodsSearchResultList, this._extrInfo, out errMsg);

                if (status == 0 && goodsSearchResultList.Count != 0)
                {
                    // TODO:掛率マスタ.売価検索処理
                    status = this._saleRateUpdateAcs.Search(out rateSearchResultList, out userRateSearchResultLis, goodsSearchResultList, this._extrInfo, out errMsg);
                }

                if (goodsSearchResultList.Count != 0)
                {
                    _xml_static = 0;

                    // グリッド表示リスト取得
                    GetDisplayList(goodsSearchResultList, rateSearchResultList, userRateSearchResultLis);

                    // グリッドデータ設定
                    CreateGrid(ref this.uGrid_Details);

                    this.uGrid_Details.ActiveRow = null;

                    this.Replace_Button.Enabled = true;

                    this.Replace_Button.Focus();

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
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2009/04/01</br>
        /// </remarks>
        private void SetExtrInfo(out SalesRateSearchParam para)
        {
            para = new SalesRateSearchParam();

            // 企業コード
            para.EnterpriseCode = this._enterpriseCode;

            // 拠点
            if ((this.tEdit_SectionCodeAllowZero.DataText.Trim() == "") ||
                (this.tEdit_SectionCodeAllowZero.DataText.Trim().PadLeft(2, '0') == "00"))
            {
                // 全社指定
                para.SectionCode = string.Empty;
            }
            else
            {
                para.SectionCode = this.tEdit_SectionCodeAllowZero.DataText.Trim().PadLeft(2, '0');
            }

            // BL商品コード
            para.BLGoodsCode = this.tNedit_BLGoodsCode.GetInt();

            // メーカー
            para.GoodsMakerCd = this.tNedit_GoodsMakerCd.GetInt();

            // 得意先掛率Ｇ
            // DEL 2009/11/30 3次分対応 得意先掛率グループ改良 ---------->>>>>
            //para.CustRateGrpCode = new int[this._targetDic.Keys.Count];
            // DEL 2009/11/30 3次分対応 得意先掛率グループ改良 ----------<<<<<
            // ADD 2009/11/30 3次分対応 得意先掛率グループ改良 ---------->>>>>
            if (!this.chkSearchingAll.Checked)
            {
                para.CustRateGrpCode = new int[this._targetDic.Keys.Count];
            }
            else
            {
                para.CustRateGrpCode = new int[this._targetDic.Keys.Count + 1];
            }
            // ADD 2009/11/30 3次分対応 得意先掛率グループ改良 ----------<<<<<

            int index = 0;
            foreach (int key in this._targetDic.Keys)
            {
                para.CustRateGrpCode[index] = key;
                index++;
            }

            // ADD 2009/11/30 3次分対応 得意先掛率グループ改良 ---------->>>>>
            // TODO:得意先掛率グループコード(=-1)：指定なし分
            if (para.CustRateGrpCode.Length > this._targetDic.Keys.Count)
            {
                // this._targetDic の先頭に"指定なし"を追加しているので 0 番目
                para.CustRateGrpCode[0] = SaleRateUpdateAcs.ALL_CUST_RATE_GRP_CODE;
            }
            // ADD 2009/11/30 3次分対応 得意先掛率グループ改良 ----------<<<<<

            // ログイン拠点
            para.PrmSectionCode = new string[1];
            para.PrmSectionCode[0] = LoginInfoAcquisition.Employee.BelongSectionCode;

            this._searchSectionCode = this.tEdit_SectionCodeAllowZero.DataText.Trim().PadLeft(2, '0');
        }

        #endregion 検索

        #region データ取得
        /// <summary>
        /// グリッド表示リスト取得処理
        /// </summary>
        /// <param name="goodsSearchResultList">掛率マスタ検索結果リスト</param>
        /// <param name="rateSearchResultList">掛率マスタ検索パラーメタ</param>
        /// <param name="userRateSearchResultLis">掛率マスタ検索パラーメタ</param>
        /// <remarks>
        /// <br>Note        : グリッドに表示するリストを取得します。</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2009/04/01</br>
        /// </remarks>
        private void GetDisplayList(List<GoodsUnitData> goodsSearchResultList, List<Rate> rateSearchResultList, List<Rate> userRateSearchResultLis)
        {
            this._goodDisplayList = new List<GoodsUnitData>();

            foreach (GoodsUnitData goodsUnitData in goodsSearchResultList)
            {
                this._goodDisplayList.Add(goodsUnitData);
            }

            _rateDisplayListClone = new List<Rate>();

            _rateDisplayListClone = rateSearchResultList;

            // 重複しているデータがある場合は、最小ロット数のデータを取得
            Dictionary<string, Rate> parentDic = new Dictionary<string, Rate>();
            foreach (Rate rateSearchResult in rateSearchResultList)
            {
                string key = MakeRateKey(rateSearchResult);
                if (!parentDic.ContainsKey(key))
                {
                    parentDic.Add(key, rateSearchResult.Clone());
                }
                else
                {
                    if (rateSearchResult.LotCount < parentDic[key].LotCount)
                    {
                        parentDic[key] = rateSearchResult.Clone();
                    }
                }
            }

            _rateDisplayList = new List<Rate>();

            foreach (Rate result in parentDic.Values)
            {
                this._rateDisplayList.Add(result.Clone());
            }

            // 重複しているデータがある場合
            Dictionary<string, Rate> childDic = new Dictionary<string, Rate>();
            foreach (Rate userRateSearchResult in userRateSearchResultLis)
            {
                string key = MakeKey(userRateSearchResult);
                if (!childDic.ContainsKey(key))
                {
                    childDic.Add(key, userRateSearchResult.Clone());
                }
            }

            _userRateDisplayList = new List<Rate>();

            foreach (Rate useresult in childDic.Values)
            {
                this._userRateDisplayList.Add(useresult.Clone());
            }

        }

        /// <summary>
        /// 更新データ取得処理
        /// </summary>
        /// <param name="saveList">保存リスト</param>
        /// <param name="deleteList">削除リスト</param>
        /// <remarks>
        /// <br>Note        : 更新データを取得します。</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2009/04/07</br>
        /// </remarks>
        private void GetUpdateList(out ArrayList saveList, out ArrayList deleteList)
        {
            string key;

            saveList = new ArrayList();
            deleteList = new ArrayList();

            this.uGrid_Details.ActiveCell = null;

            for (int rowIndex = 0; rowIndex < this.uGrid_Details.Rows.Count; rowIndex++)
            {
                List<Rate> resultList;

                CellsCollection cells = this.uGrid_Details.Rows[rowIndex].Cells;

                DataRow originalDr = this._dataTableClone.Select(COLUMN_NO + " ='"
                    + cells[COLUMN_NO].Value.ToString() + "'")[0];

                key = MakeKey(StrObjToInt(cells[COLUMN_GOODSMAKERCD].Value), cells[COLUMN_GOODSNO].Value.ToString().Trim(), this._searchSectionCode);

                resultList = this._rateDisplayList.FindAll(delegate(Rate target)
                {
                    if (key.Equals(MakeKey(target.GoodsMakerCd, target.GoodsNo, target.SectionCode)))
                    {
                        return (true);
                    }
                    else
                    {
                        return (false);
                    }
                });

                Rate result = new Rate();

                // 売価
                foreach (int code in this._targetDic.Keys)
                {
                    double olddata = Convert.ToDouble(originalDr[code.ToString()]);
                    double newdata = Convert.ToDouble(cells[code.ToString()].Value);
                    if (newdata != olddata)
                    {
                        Rate updateRate = new Rate();

                        result = resultList.Find(delegate(Rate target)
                            {
                                if (target.CustRateGrpCode == code)
                                {
                                    return (true);
                                }
                                else
                                {
                                    return (false);
                                }
                            });

                        if (result == null && 0 != DoubleObjToDouble(cells[code.ToString()].Value))
                        {
                            // TODO:データ追加
                            #region 新規データ追加
                            updateRate.EnterpriseCode = this._enterpriseCode;
                            updateRate.SectionCode = this._searchSectionCode;
                            updateRate.LotCount = 9999999.99;
                            updateRate.UnPrcFracProcUnit = 0;
                            updateRate.UnPrcFracProcDiv = 0;

                            // DEL 2009/11/30 3次分対応 得意先掛率グループ改良 ---------->>>>>
                            //updateRate.UnitRateSetDivCd = "14A";
                            //updateRate.RateSettingDivide = "4A";
                            //updateRate.RateMngCustCd = "4";
                            //updateRate.RateMngCustNm = "得意先掛率グループ";
                            // DEL 2009/11/30 3次分対応 得意先掛率グループ改良 ----------<<<<<
                            // ADD 2009/11/30 3次分対応 得意先掛率グループ改良 ---------->>>>>
                            updateRate.UnitRateSetDivCd = code >= 0 ? "14A" : "16A";
                            updateRate.RateSettingDivide = code >= 0 ? "4A" : "6A";
                            updateRate.RateMngCustCd = code >= 0 ? "4" : "6";
                            updateRate.RateMngCustNm = code >= 0 ? "得意先掛率グループ" : "指定なし";
                            // ADD 2009/11/30 3次分対応 得意先掛率グループ改良 ----------<<<<<

                            // --- DEL  大矢睦美  2010/04/20 ---------->>>>>
                            //updateRate.CustRateGrpCode = code;
                            // --- DEL  大矢睦美  2010/04/20 ----------<<<<<
                            // --- ADD  大矢睦美  2010/04/20 ---------->>>>>
                            if (code == -1)
                            {
                                updateRate.CustRateGrpCode = 0;
                            }
                            else
                            {
                                updateRate.CustRateGrpCode = code;
                            }
                            // --- ADD  大矢睦美  2010/04/20 ----------<<<<<
                            updateRate.RateMngGoodsCd = "A";
                            updateRate.RateMngGoodsNm = "ﾒｰｶｰ＋品番";
                            updateRate.BLGoodsCode = 0;
                            updateRate.UnitPriceKind = "1";
                            updateRate.GoodsMakerCd = StrObjToInt(cells[COLUMN_GOODSMAKERCD].Value);
                            updateRate.GoodsNo = cells[COLUMN_GOODSNO].Value.ToString().Trim();
                            updateRate.SupplierCd = 0;
                            updateRate.RateVal = 0;
                            updateRate.GoodsRateRank = string.Empty;
                            updateRate.PriceFl = DoubleObjToDouble(cells[code.ToString()].Value);
                            saveList.Add(updateRate.Clone());

                            #endregion 新規データ追加
                        }
                        else if (result != null)
                        {
                            string ratekey = MakeRateKey(result);
                            List<Rate> rateresultList = new List<Rate>();

                            rateresultList = this._rateDisplayListClone.FindAll(delegate(Rate target)
                            {
                                if (ratekey.Equals(MakeRateKey(target)))
                                {
                                    return (true);
                                }
                                else
                                {
                                    return (false);
                                }
                            });

                            foreach (Rate rateresult in rateresultList)
                            {
                                if (rateresult.LogicalDeleteCode == 0 || DoubleObjToDouble(cells[code.ToString()].Value) != 0)
                                {
                                    #region 削除データ追加

                                    updateRate.EnterpriseCode = this._enterpriseCode;
                                    updateRate.SectionCode = this._searchSectionCode;

                                    // DEL 2009/11/30 3次分対応 得意先掛率グループ改良 ---------->>>>>
                                    //updateRate.UnitRateSetDivCd = "14A";
                                    // DEL 2009/11/30 3次分対応 得意先掛率グループ改良 ----------<<<<<
                                    // ADD 2009/11/30 3次分対応 得意先掛率グループ改良 ---------->>>>>
                                    updateRate.UnitRateSetDivCd = result.UnitRateSetDivCd;
                                    // ADD 2009/11/30 3次分対応 得意先掛率グループ改良 ----------<<<<<

                                    updateRate.GoodsRateGrpCode = result.GoodsRateGrpCode;
                                    updateRate.GoodsRateRank = result.GoodsRateRank;
                                    updateRate.BLGroupCode = result.BLGroupCode;
                                    updateRate.BLGoodsCode = result.BLGoodsCode;
                                    updateRate.CustomerCode = result.CustomerCode;
                                    updateRate.GoodsMakerCd = StrObjToInt(cells[COLUMN_GOODSMAKERCD].Value);
                                    updateRate.GoodsNo = cells[COLUMN_GOODSNO].Value.ToString().Trim();
                                    // --- DEL  大矢睦美  2010/04/20 ---------->>>>>
                                    //updateRate.CustRateGrpCode = code;
                                    // --- DEL  大矢睦美  2010/04/20 ----------<<<<<
                                    // --- ADD  大矢睦美  2010/04/20 ---------->>>>>
                                    if (code == -1)
                                    {
                                        updateRate.CustRateGrpCode = 0;
                                    }
                                    else
                                    {
                                        updateRate.CustRateGrpCode = code;
                                    }
                                    // --- ADD  大矢睦美  2010/04/20 ----------<<<<<
                                    updateRate.SupplierCd = result.SupplierCd;
                                    updateRate.LotCount = rateresult.LotCount;
                                    updateRate.UpdateDateTime = rateresult.UpdateDateTime;

                                    deleteList.Add(updateRate.Clone());

                                    #endregion 削除データ追加
                                }
                            }
                            if (0 != DoubleObjToDouble(cells[code.ToString()].Value))
                            {
                                #region 新規データ追加

                                // TODO:データ追加
                                updateRate.EnterpriseCode = this._enterpriseCode;
                                updateRate.SectionCode = this._searchSectionCode;

                                // DEL 2009/11/30 3次分対応 得意先掛率グループ改良 ---------->>>>>
                                //updateRate.UnitRateSetDivCd = "14A";
                                //updateRate.RateSettingDivide = "4A";
                                //updateRate.RateMngCustCd = "4";
                                // DEL 2009/11/30 3次分対応 得意先掛率グループ改良 ----------<<<<<
                                // ADD 2009/11/30 3次分対応 得意先掛率グループ改良 ---------->>>>>
                                updateRate.UnitRateSetDivCd = code >= 0 ? "14A" : "16A";
                                updateRate.RateSettingDivide = code >= 0 ? "4A" : "6A";
                                updateRate.RateMngCustCd = code >= 0 ? "4" : "6";
                                // ADD 2009/11/30 3次分対応 得意先掛率グループ改良 ----------<<<<<

                                updateRate.RateMngGoodsCd = "A";
                                updateRate.GoodsRateGrpCode = 0;
                                updateRate.GoodsRateRank = string.Empty;
                                updateRate.BLGroupCode = 0;
                                updateRate.BLGoodsCode = 0;
                                updateRate.CustomerCode = 0;
                                updateRate.GoodsMakerCd = StrObjToInt(cells[COLUMN_GOODSMAKERCD].Value);
                                updateRate.LotCount = 9999999.99;
                                updateRate.UnPrcFracProcUnit = 0;
                                updateRate.UnPrcFracProcDiv = 0;

                                // DEL 2009/11/30 3次分対応 得意先掛率グループ改良 ---------->>>>>
                                //updateRate.RateMngCustNm = "得意先掛率グループ";
                                // DEL 2009/11/30 3次分対応 得意先掛率グループ改良 ----------<<<<<
                                // ADD 2009/11/30 3次分対応 得意先掛率グループ改良 ---------->>>>>
                                updateRate.RateMngCustNm = code >= 0 ? "得意先掛率グループ" : "指定なし";
                                // ADD 2009/11/30 3次分対応 得意先掛率グループ改良 ----------<<<<<

                                updateRate.RateMngGoodsNm = "ﾒｰｶｰ＋品番";
                                updateRate.BLGoodsCode = 0;
                                updateRate.UnitPriceKind = "1";
                                updateRate.SupplierCd = 0;
                                updateRate.RateVal = 0;
                                updateRate.GoodsRateRank = string.Empty;
                                // --- DEL  大矢睦美  2010/04/20 ---------->>>>>
                                //updateRate.CustRateGrpCode = code;
                                // --- DEL  大矢睦美  2010/04/20 ----------<<<<<
                                // --- ADD  大矢睦美  2010/04/20 ---------->>>>>
                                if (code == -1)
                                {
                                    updateRate.CustRateGrpCode = 0;
                                }
                                else
                                {
                                    updateRate.CustRateGrpCode = code;
                                }
                                // --- ADD  大矢睦美  2010/04/20 ----------<<<<<
                                updateRate.SupplierCd = 0;
                                updateRate.PriceFl = DoubleObjToDouble(cells[code.ToString()].Value);
                                updateRate.UpdateDateTime = DateTime.MinValue;

                                saveList.Add(updateRate.Clone());

                                #endregion 新規データ追加
                            }
                        }
                    }
                }
            }
        }

        #endregion データ取得

        #region セル値変換
        /// <summary>
        /// セル値変換処理
        /// </summary>
        /// <param name="cellValue">セル値</param>
        /// <returns>String型</returns>
        /// <remarks>
        /// <br>Note        : セル値をString型に変換します。</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2009/04/01</br>
        /// </remarks>
        public int StrObjToInt(object cellValue)
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
        /// <returns>Double型</returns>
        /// <remarks>
        /// <br>Note        : セル値をDouble型に変換します。</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2009/04/01</br>
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

        #region クリア処理
        /// <summary>
        /// 画面情報クリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : 画面情報をクリアします。</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2009/04/01</br>
        /// </remarks>
        private void ClearScreen()
        {
            // 拠点コード
            this.tEdit_SectionCodeAllowZero.DataText = "00";
            this.tEdit_SectionName.DataText = "全社";
            this._tmpSectionCode = "00";
            // メーカーコード
            this.tNedit_GoodsMakerCd.Clear();
            this.tEdit_MakerName.Clear();
            _tmpGoodsMakerCd = 0;
            // BLコード
            this.tNedit_BLGoodsCode.Clear();
            this.tEdit_BLGoodsName.Clear();
            _tmpBLGoodsCode = 0;

            // 得意先掛率G
            for (int index = 0; index < this._tNedit_CustRateGrpCode.Length; index++)
            {
                this._tNedit_CustRateGrpCode[index].Clear();
            }

            // スクロールポジション初期化
            this.uGrid_Details.DisplayLayout.ColScrollRegions.Clear();

            // グリッドクリア
            ClearGrid();

            // フォーカス設定
            this.tEdit_SectionCodeAllowZero.Focus();
        }

        /// <summary>
        /// グリッド初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : グリッドを初期化を行います。</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2009/04/07</br>
        /// </remarks>
        private void ClearGrid()
        {
            this._targetDic = new Dictionary<int, int>();
            this._goodDisplayList = new List<GoodsUnitData>();
            this._rateDisplayList = new List<Rate>();
            this._userRateDisplayList = new List<Rate>();
            this._rateDisplayListClone = new List<Rate>();

            // グリッド作成処理
            CreateGrid(ref this.uGrid_Details);
        }

        #endregion クリア処理

        #region グリッド設定
        /// <summary>
        /// TODO:グリッド作成処理
        /// </summary>
        /// <param name="uGrid">グリッド</param>
        /// <remarks>
        /// <br>Note        : グリッドの列を作成します。</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2009/04/07</br>
        /// </remarks>
        public void CreateGrid(ref UltraGrid uGrid)
        {
            DataTable dataTable = new DataTable();

            // No
            dataTable.Columns.Add(COLUMN_NO, typeof(int));
            // 品番
            dataTable.Columns.Add(COLUMN_GOODSNO, typeof(string));
            // 定価
            dataTable.Columns.Add(COLUMN_PRICEFL, typeof(double));
            // ユーザー定価
            dataTable.Columns.Add(COLUMN_USERPRICEFL, typeof(double));
            // 仕入原価
            dataTable.Columns.Add(COLUMN_RATEVAL, typeof(double));
            //メーカーコード
            dataTable.Columns.Add(COLUMN_GOODSMAKERCD, typeof(int));
            if ((this._goodDisplayList == null) || (this._goodDisplayList.Count == 0))
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
                    dataTable.Columns[key.ToString()].DefaultValue = 0;
                }
            }

            uGrid.DataSource = dataTable;

            // グリッドスタイル設定
            SetGridLayout(ref uGrid);

            // データが無い場合
            if ((this._goodDisplayList == null) || (this._goodDisplayList.Count == 0))
            {
                return;
            }

            dataTable.AcceptChanges();

            try
            {
                List<Rate> targetList;

                List<Rate> usertargetList;

                // 仕入原価検索
                this._saleRateUpdateAcs.SearchGoodsPriceU(_goodDisplayList, _searchSectionCode);

                for (int index = 0; index < this._goodDisplayList.Count; index++)
                {
                    // 行追加
                    DataRow row = dataTable.NewRow();

                    GoodsUnitData goodsresult = (GoodsUnitData)this._goodDisplayList[index];

                    // No
                    row[COLUMN_NO] = index + 1;

                    //品番
                    row[COLUMN_GOODSNO] = goodsresult.GoodsNo;

                    //価格
                    if (goodsresult.GoodsPriceList != null && goodsresult.GoodsPriceList.Count != 0)
                    {
                        row[COLUMN_PRICEFL] = GetListPrice(goodsresult.GoodsPriceList);
                    }

                    //ユーザー定価
                    usertargetList = this._userRateDisplayList.FindAll(delegate(Rate usertarget)
                    {
                        if (MakeKey(goodsresult.GoodsMakerCd, goodsresult.GoodsNo, this._searchSectionCode).Equals(MakeKey(usertarget.GoodsMakerCd, usertarget.GoodsNo, usertarget.SectionCode)))
                        {
                            return (true);
                        }
                        else
                        {
                            return (false);
                        }
                    });

                    if (usertargetList != null && usertargetList.Count != 0)
                    {
                        row[COLUMN_USERPRICEFL] = usertargetList[0].PriceFl;
                    }

                    //仕入原価
                    row[COLUMN_RATEVAL] = _saleRateUpdateAcs.GetStockUnitPrice(goodsresult);

                    //商品メーカーコード
                    row[COLUMN_GOODSMAKERCD] = goodsresult.GoodsMakerCd;

                    targetList = this._rateDisplayList.FindAll(delegate(Rate target)
                    {
                        if (MakeKey(goodsresult.GoodsMakerCd, goodsresult.GoodsNo, this._searchSectionCode).Equals(MakeKey(target.GoodsMakerCd, target.GoodsNo, target.SectionCode)))
                        {
                            return (true);
                        }
                        else
                        {
                            return (false);
                        }
                    });

                    //売価
                    foreach (Rate rate in targetList)
                    {
                        if (this._targetDic.ContainsKey(rate.CustRateGrpCode))
                        {
                            // 得意先掛率Ｇ
                            if (rate.PriceFl != 0 && rate.LogicalDeleteCode == 0)
                            {
                                row[rate.CustRateGrpCode.ToString()] = rate.PriceFl;
                            }
                        }
                    }

                    dataTable.Rows.Add(row);
                }
            }
            finally
            {
                _dataTableClone = dataTable.Copy();
            }

        }

        /// <summary>
        /// グリッドスタイル設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : グリッドのスタイルを設定します。</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2009/04/07</br>
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

                // 品番
                columns[COLUMN_GOODSNO].Header.Caption = "品番";
                columns[COLUMN_GOODSNO].Header.Fixed = true;
                columns[COLUMN_GOODSNO].CellAppearance.TextHAlign = HAlign.Left;
                columns[COLUMN_GOODSNO].CellActivation = Activation.NoEdit;

                // 定価
                //columns[COLUMN_PRICEFL].Header.Caption = "定価"; // DEL 2009/07/09
                columns[COLUMN_PRICEFL].Header.Caption = "価格"; // ADD 2009/07/09
                columns[COLUMN_PRICEFL].Header.Fixed = true;
                columns[COLUMN_PRICEFL].CellAppearance.TextHAlign = HAlign.Right;
                columns[COLUMN_PRICEFL].CellActivation = Activation.NoEdit;
                columns[COLUMN_PRICEFL].Format = FORMAT_NO;

                if (_xml_static != 0)
                {
                    columns[COLUMN_PRICEFL].Hidden = false;
                }

                // ユーザー定価
                //columns[COLUMN_USERPRICEFL].Header.Caption = "ユーザー定価";  // ADD 2009/07/09
                columns[COLUMN_USERPRICEFL].Header.Caption = "ユーザー価格";  // ADD 2009/07/09
                columns[COLUMN_USERPRICEFL].Header.Fixed = true;
                columns[COLUMN_USERPRICEFL].CellAppearance.TextHAlign = HAlign.Right;
                columns[COLUMN_USERPRICEFL].CellActivation = Activation.NoEdit;
                columns[COLUMN_USERPRICEFL].Format = FORMAT_NO;

                if (_xml_static != 0)
                {
                    columns[COLUMN_USERPRICEFL].Hidden = true;
                }

                // 仕入原価
                columns[COLUMN_RATEVAL].Header.Caption = "仕入原価";
                columns[COLUMN_RATEVAL].Header.Fixed = true;
                columns[COLUMN_RATEVAL].CellAppearance.TextHAlign = HAlign.Right;
                columns[COLUMN_RATEVAL].CellActivation = Activation.NoEdit;
                columns[COLUMN_RATEVAL].Format = FORMAT;

                // 商品メーカーコード
                columns[COLUMN_GOODSMAKERCD].Header.Caption = "商品メーカーコード";
                columns[COLUMN_GOODSMAKERCD].Hidden = true;
                columns[COLUMN_GOODSMAKERCD].Header.Fixed = true;
                columns[COLUMN_GOODSMAKERCD].CellAppearance.TextHAlign = HAlign.Right;
                columns[COLUMN_GOODSMAKERCD].CellActivation = Activation.NoEdit;

                // 売価
                if ((this._goodDisplayList == null) || (this._goodDisplayList.Count == 0))
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
                        columns[key.ToString()].Header.Caption = ((int)this._targetDic[key]).ToString("0000");
                        
                        // ADD 2009/11/30 3次分対応 得意先掛率グループ改良 ---------->>>>>
                        if (((int)this._targetDic[key]) < 0) columns[key.ToString()].Header.Caption = "ALL";   // HACK:"ALL"
                        // ADD 2009/11/30 3次分対応 得意先掛率グループ改良 ----------<<<<<

                        columns[key.ToString()].Format = FORMAT;
                        columns[key.ToString()].CellAppearance.TextHAlign = HAlign.Right;
                        columns[key.ToString()].CellActivation = Activation.AllowEdit;
                    }
                }

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
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2009/04/07</br>
        /// </remarks>
        private void SetColumnWidth(ref UltraGrid uGrid)
        {
            ColumnsCollection columns = uGrid.DisplayLayout.Bands[0].Columns;

            // No
            columns[COLUMN_NO].Width = 45;
            // 品番
            columns[COLUMN_GOODSNO].Width = 275;
            // 定価
            columns[COLUMN_PRICEFL].Width = 120;
            // ユーザー定価
            columns[COLUMN_USERPRICEFL].Width = 120;
            // 仕入原価
            columns[COLUMN_RATEVAL].Width = 120;
            // 売価
            if ((this._goodDisplayList == null) || (this._goodDisplayList.Count == 0))
            {
                for (int index = COLINDEX_SALERATE_ST; index <= COLINDEX_SALERATE_ED; index++)
                {
                    columns[index].Width = 110;
                }
            }
            else
            {
                foreach (int key in this._targetDic.Keys)
                {
                    columns[key.ToString()].Width = 110;
                }
            }
        }

        /// <summary>
        /// 価格検索
        /// </summary>
        /// <remarks>
        /// <br>Note       : なし。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009/06/01</br>
        /// </remarks>
        public double GetListPrice(List<GoodsPrice> goodsPriceList)
        {
            double listprice = 0;
            DateTime time = DateTime.Now;

            foreach (GoodsPrice goodsPrice in goodsPriceList)
            {
                if (goodsPrice.PriceStartDate.CompareTo(time) <= 0)
                {
                    listprice = goodsPrice.ListPrice;

                    return listprice;
                }
            }

            return listprice;
        }

        #endregion グリッド設定

        #region Key作成
        /// <summary>
        /// Key作成処理
        /// </summary>
        /// <param name="rateSearchResult">掛率マスタ検索結果</param>
        /// <returns>Key</returns>
        /// <remarks>
        /// <br>Note        : Keyを作成します。</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2009/04/07</br>
        /// </remarks>
        private string MakeKey(Rate rateSearchResult)
        {
            // 拠点コード＋単価掛率設定区分＋商品メーカーコード+商品番号
            string key = rateSearchResult.SectionCode +
                         rateSearchResult.UnitRateSetDivCd +
                         rateSearchResult.GoodsMakerCd +
                         rateSearchResult.GoodsNo;


            return key;
        }

        /// <summary>
        /// Key作成処理
        /// </summary>
        /// <param name="goodsMakerCd">商品メーカーコード</param>
        /// <param name="goodsNo">商品番号</param>
        /// <param name="SectionCode">拠点</param>
        /// <returns>Key</returns>
        /// <remarks>
        /// <br>Note        : Keyを作成します。</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2009/04/07</br>
        /// </remarks>
        private string MakeKey(int goodsMakerCd, string goodsNo, string SectionCode)
        {
            // 商品メーカーコード＋商品番号
            string key = goodsMakerCd.ToString("000000") + goodsNo + SectionCode;

            return key;
        }

        /// <summary>
        /// Key作成処理
        /// </summary>
        /// <param name="rateSearchResult">掛率マスタ検索結果</param>
        /// <returns>Key</returns>
        /// <remarks>
        /// <br>Note        : Keyを作成します。</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2009/04/07</br>
        /// </remarks>
        private string MakeRateKey(Rate rateSearchResult)
        {
            // 拠点コード＋単価掛率設定区分＋商品メーカーコード+商品番号+得意先掛率グループコード
            string key = rateSearchResult.SectionCode +
                         rateSearchResult.UnitRateSetDivCd +
                         rateSearchResult.GoodsMakerCd +
                         rateSearchResult.GoodsNo +
                         rateSearchResult.CustRateGrpCode;


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
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009/04/07</br>
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
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009/04/07</br>
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
                                         this._saleRateUpdateAcs,	        // エラーが発生したオブジェクト
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
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2009/04/07</br>
        /// </remarks>
        private void PMKHN09431UA_Load(object sender, EventArgs e)
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
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2009/04/07</br>
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

                        // 終了処理
                        Close();
                        break;
                    }
                case "ButtonTool_Save":
                    {
                        // 保存処理
                        Save();

                        // クリア処理
                        ClearScreen();
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
            }
        }

        /// <summary>
        /// Button_Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : 拠点ガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2009/04/07</br>
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
                    // 設定値を保存
                    this._tmpSectionCode = secInfoSet.SectionCode.Trim();
                    // フォーカス設定
                    this.tNedit_GoodsMakerCd.Focus();
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
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2009/04/07</br>
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
                    // 設定値を保存
                    this._tmpGoodsMakerCd = makerUMnt.GoodsMakerCd;
                    // フォーカス設定
                    this.tNedit_BLGoodsCode.Focus();
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
        /// <br>Note        : ＢＬコードガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2009/04/07</br>
        /// </remarks>
        private void BLGoodsGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                BLGoodsCdUMnt bLGoodsCdUMnt;

                int status = this._blGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out bLGoodsCdUMnt);
                if (status == 0)
                {
                    this.tNedit_BLGoodsCode.SetInt(bLGoodsCdUMnt.BLGoodsCode);
                    this.tEdit_BLGoodsName.DataText = GetBLGoodsName(bLGoodsCdUMnt.BLGoodsCode);
                    // 設定値を保存
                    this._tmpBLGoodsCode = bLGoodsCdUMnt.BLGoodsCode;
                    // フォーカス設定
                    this.tNedit_CustRateGrpCode1.Focus();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// KeyPress イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : グリッドアクティブ時にKeyを押された時に発生します。</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2009/04/07</br>
        /// </remarks>
        private void uGrid_Details_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.uGrid_Details.ActiveCell == null)
            {
                return;
            }

            UltraGridCell cell = this.uGrid_Details.ActiveCell;

            // 編集できるのは売価のみ
            if (cell.IsInEditMode)
            {
                if (!KeyPressNumCheck(10, 2, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                {
                    e.Handled = true;
                    return;
                }
            }
        }

        /// <summary>
        /// KeyDown イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : グリッドアクティブ時にKeyを押された時に発生します。</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2009/04/07</br>
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
                            this.Replace_Button.Focus();
                        }
                        else
                        {
                            e.Handled = true;
                            uGrid.Rows[rowIndex - 1].Cells[colIndex].Activate();
                            uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        break;
                    }
                case Keys.Down:
                    {
                        e.Handled = true;

                        if (rowIndex != uGrid.Rows.Count - 1)
                        {
                            uGrid.Rows[rowIndex + 1].Cells[colIndex].Activate();
                            uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        break;
                    }
                case Keys.Left:
                    {
                        if (uGrid.ActiveCell.IsInEditMode)
                        {
                            if (uGrid.ActiveCell.SelStart == 0)
                            {
                                if ((rowIndex == 0) && (colIndex == COLINDEX_SALERATE_ST))
                                {
                                    e.Handled = true;
                                }
                                else if (colIndex == COLINDEX_SALERATE_ST)
                                {
                                    e.Handled = true;
                                    uGrid.Rows[rowIndex - 1].Cells[COLINDEX_SALERATE_ST + this._targetDic.Keys.Count - 1].Activate();
                                    uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                }
                                else
                                {
                                    e.Handled = true;
                                    uGrid.Rows[rowIndex].Cells[colIndex - 1].Activate();
                                    uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                }
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
                                else if (colIndex == COLINDEX_SALERATE_ST + this._targetDic.Keys.Count - 1)
                                {
                                    e.Handled = true;
                                    uGrid.Rows[rowIndex + 1].Cells[COLINDEX_SALERATE_ST].Activate();
                                    uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                }
                                else
                                {
                                    e.Handled = true;
                                    uGrid.Rows[rowIndex].Cells[colIndex + 1].Activate();
                                    uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                }
                            }
                        }
                        break;
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
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2009/04/07</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            // フォーカス設定
            this.tEdit_SectionCodeAllowZero.Focus();

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
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2009/04/07</br>
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
        /// Leave イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : 得意先掛率Ｇからフォーカスが離れた時に発生します。</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2009/04/07</br>
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
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009/04/07</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            switch (e.PrevCtrl.Name)
            {
                // 拠点コード
                case "tEdit_SectionCodeAllowZero":
                    {
                        #region 拠点コード
                        // 入力無し
                        if (string.IsNullOrEmpty(this.tEdit_SectionCodeAllowZero.Text.Trim()))
                        {
                            // 設定値保存、名称のクリア
                            this._tmpSectionCode = string.Empty;
                            this.tEdit_SectionName.Text = string.Empty;

                            break;
                        }

                        // 入力変更なし
                        if (this.tEdit_SectionCodeAllowZero.DataText.Trim().Equals(this._tmpSectionCode))
                        {
                            if (e.ShiftKey == false)
                            {
                                if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right)
                                {
                                    // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                                    e.NextCtrl = this.tNedit_GoodsMakerCd;
                                }
                            }
                            else
                            {
                                if (e.Key == Keys.Tab)
                                {
                                    // フォーカス移動
                                    e.NextCtrl = e.PrevCtrl;
                                }
                            }

                            break;
                        }
                        else
                        {
                            // 拠点コード取得
                            string sectionCode = this.tEdit_SectionCodeAllowZero.DataText.Trim();

                            if (!string.IsNullOrEmpty(GetSectionName(sectionCode)))
                            {
                                // 結果を画面に設定
                                //this.tEdit_SectionCodeAllowZero.DataText = sectionCode;
                                this.tEdit_SectionName.Text = GetSectionName(sectionCode);

                                // 設定値を保存
                                this._tmpSectionCode = sectionCode;
                            }
                            else
                            {
                                // 前回入力値を設定
                                this.tEdit_SectionCodeAllowZero.DataText = _tmpSectionCode;

                                // 該当なし
                                TMsgDisp.Show(this, 												// 親ウィンドウフォーム
                                                emErrorLevel.ERR_LEVEL_INFO, 						// エラーレベル
                                                this.Name,											// アセンブリID
                                                "指定された条件で拠点コードは存在しませんでした。", // 表示するメッセージ
                                                -1,													// ステータス値
                                                MessageBoxButtons.OK);								// 表示するボタン
                                // ↓ 2009.07.01 liuyang add
                                e.NextCtrl = e.PrevCtrl;
                                // ↑ 2009.07.01 liuyang 

                                return;
                            }

                            if (e.ShiftKey == false)
                            {
                                if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right)
                                {
                                    // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                                    e.NextCtrl = this.tNedit_GoodsMakerCd;
                                }
                            }
                            else
                            {
                                if (e.Key == Keys.Tab)
                                {
                                    // フォーカス移動
                                    e.NextCtrl = e.PrevCtrl;
                                }
                            }
                        }
                        break;

                        #endregion
                    }
                // メーカーコード
                case "tNedit_GoodsMakerCd":
                    {
                        #region メーカーコード

                        // 入力無し
                        if (this.tNedit_GoodsMakerCd.GetInt() == 0)
                        {
                            // 設定値保存、名称のクリア
                            this._tmpGoodsMakerCd = 0;
                            this.tEdit_MakerName.Text = string.Empty;

                            if (e.ShiftKey == false)
                            {
                                if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right)
                                {
                                    // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                                    if (string.IsNullOrEmpty(tNedit_GoodsMakerCd.Text.Trim()))
                                    {
                                        e.NextCtrl = this.MakerGuide_Button;
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.tNedit_BLGoodsCode;
                                    }
                                }
                            }
                            else
                            {
                                if (e.Key == Keys.Tab)
                                {
                                    // フォーカス移動
                                    if (this.tEdit_SectionCodeAllowZero.Text.Trim() != "")
                                    {
                                        e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                                    }
                                }
                            }

                            break;
                        }

                        // 入力変更なし
                        if (this.tNedit_GoodsMakerCd.GetInt() == this._tmpGoodsMakerCd)
                        {
                            if (e.ShiftKey == false)
                            {
                                if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right)
                                {
                                    // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                                    e.NextCtrl = this.tNedit_BLGoodsCode;
                                }
                            }
                            else
                            {
                                if (e.Key == Keys.Tab)
                                {
                                    // フォーカス移動
                                    if (this.tEdit_SectionCodeAllowZero.Text.Trim() != "")
                                    {
                                        e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                                    }
                                }
                            }

                            break;
                        }
                        else
                        {
                            int makerCd = this.tNedit_GoodsMakerCd.GetInt();
                            if (!string.IsNullOrEmpty(GetMakerName(makerCd)))
                            {
                                // 結果を画面に設定
                                this.tNedit_GoodsMakerCd.SetInt(makerCd);
                                this.tEdit_MakerName.Text = GetMakerName(makerCd);

                                // 設定値を保存
                                this._tmpGoodsMakerCd = makerCd;
                            }
                            else
                            {
                                // 前回入力値を設定
                                this.tNedit_GoodsMakerCd.SetInt(this._tmpGoodsMakerCd);

                                // 該当なし
                                TMsgDisp.Show(this, 												// 親ウィンドウフォーム
                                                emErrorLevel.ERR_LEVEL_INFO, 						// エラーレベル
                                                this.Name,											// アセンブリID
                                                "指定された条件でメーカーコードは存在しませんでした。", // 表示するメッセージ
                                                -1,													// ステータス値
                                                MessageBoxButtons.OK);								// 表示するボタン
                                // ↓ 2009.07.01 liuyang add
                                e.NextCtrl = e.PrevCtrl;
                                // ↑ 2009.07.01 liuyang 
                                
                                return;
                            }

                            if (e.ShiftKey == false)
                            {
                                if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right)
                                {
                                    // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                                    e.NextCtrl = this.tNedit_BLGoodsCode;
                                }
                            }
                            else
                            {
                                if (e.Key == Keys.Tab)
                                {
                                    // フォーカス移動
                                    if (this.tEdit_SectionCodeAllowZero.Text.Trim() != "")
                                    {
                                        e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                                    }
                                }
                            }
                        }

                        break;

                        #endregion
                    }
                // ＢＬコード
                case "tNedit_BLGoodsCode":
                    {

                        #region ＢＬコード

                        // 入力無し
                        if (this.tNedit_BLGoodsCode.GetInt() == 0)
                        {
                            // 設定値保存、名称のクリア
                            this._tmpBLGoodsCode = 0;
                            this.tEdit_BLGoodsName.Text = string.Empty;

                            if (e.ShiftKey == false)
                            {
                                if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right)
                                {
                                    // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                                    if (string.IsNullOrEmpty(tNedit_BLGoodsCode.Text.Trim()))
                                    {
                                        e.NextCtrl = this.BLGoodsGuide_Button;
                                    }
                                    else
                                    {
                                        e.NextCtrl = this.tNedit_CustRateGrpCode1;
                                    }
                                }
                            }
                            else
                            {
                                if (e.Key == Keys.Tab)
                                {
                                    // フォーカス移動
                                    if (this.tNedit_GoodsMakerCd.Text.Trim() != "")
                                    {
                                        e.NextCtrl = this.tNedit_GoodsMakerCd;
                                    }
                                }
                            }

                            break;
                        }

                        // 入力変更なし
                        if (this.tNedit_BLGoodsCode.GetInt() == this._tmpBLGoodsCode)
                        {
                            if (e.ShiftKey == false)
                            {
                                if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right)
                                {
                                    // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                                    e.NextCtrl = this.tNedit_CustRateGrpCode1;
                                }
                            }
                            else
                            {
                                if (e.Key == Keys.Tab)
                                {
                                    // フォーカス移動
                                    if (this.tNedit_GoodsMakerCd.Text.Trim() != "")
                                    {
                                        e.NextCtrl = this.tNedit_GoodsMakerCd;
                                    }
                                }
                            }

                            break;
                        }
                        else
                        {
                            int bLGoodsCd = this.tNedit_BLGoodsCode.GetInt();
                            if (!string.IsNullOrEmpty(GetBLGoodsName(bLGoodsCd)))
                            {
                                // 結果を画面に設定
                                this.tNedit_BLGoodsCode.SetInt(bLGoodsCd);
                                this.tEdit_BLGoodsName.Text = GetBLGoodsName(bLGoodsCd);

                                // 設定値を保存
                                this._tmpBLGoodsCode = bLGoodsCd;
                            }
                            else
                            {
                                // 前回入力値を設定
                                this.tNedit_BLGoodsCode.SetInt(this._tmpBLGoodsCode);

                                // 該当なし
                                TMsgDisp.Show(this, 												// 親ウィンドウフォーム
                                                emErrorLevel.ERR_LEVEL_INFO, 						// エラーレベル
                                                this.Name,											// アセンブリID
                                                "指定された条件でＢＬコードは存在しませんでした。", // 表示するメッセージ
                                                -1,													// ステータス値
                                                MessageBoxButtons.OK);								// 表示するボタン

                                // ↓ 2009.07.01 liuyang add
                                e.NextCtrl = e.PrevCtrl;
                                // ↑ 2009.07.01 liuyang 

                                return;
                            }

                            if (e.ShiftKey == false)
                            {
                                if (e.Key == Keys.Return || e.Key == Keys.Tab || e.Key == Keys.Right)
                                {
                                    // 入力あり＆Tab遷移＆次がガイドボタンの場合、ガイドボタンは飛ばす
                                    e.NextCtrl = this.tNedit_CustRateGrpCode1;
                                }
                            }
                            else
                            {
                                if (e.Key == Keys.Tab)
                                {
                                    // フォーカス移動
                                    if (this.tNedit_GoodsMakerCd.Text.Trim() != "")
                                    {
                                        e.NextCtrl = this.tNedit_GoodsMakerCd;
                                    }
                                }
                            }
                        }

                        break;

                        #endregion
                    }
                // 得意先掛率Ｇコード1
                case "tNedit_CustRateGrpCode1":
                    {
                        if (e.ShiftKey == true)
                        {
                            if (e.Key == Keys.Tab)
                            {
                                // フォーカス移動
                                if (this.tNedit_BLGoodsCode.Text.Trim() != "")
                                {
                                    e.NextCtrl = this.tNedit_BLGoodsCode;
                                }
                            }
                        }
                        break;
                    }

                // グリッド
                case "uGrid_Details":
                    {
                        #region グリッド

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
                                    this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index].Cells[6].Activate();
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
                                        }
                                        else if (Standard_UGroupBox2.Expanded == true)
                                        {
                                            e.NextCtrl = tNedit_CustRateGrpCode1;
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
                                        this.uGrid_Details.Rows[0].Cells[6].Activate();
                                        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                        return;
                                    }
                                }

                                e.NextCtrl = null;

                                if (colIndex < 5)
                                {
                                    // にフォーカス
                                    this.uGrid_Details.Rows[rowIndex].Cells[6].Activate();
                                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                    return;
                                }
                                else if (colIndex == COLINDEX_SALERATE_ST + this._targetDic.Count - 1)
                                {
                                    if (rowIndex == this.uGrid_Details.Rows.VisibleRowCount - 1)
                                    {
                                        // フォーカス移動なし
                                        //this.uGrid_Details.Rows[rowIndex].Cells[colIndex].Activate();
                                        this.tEdit_SectionCodeAllowZero.Focus();
                                        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                        return;
                                    }
                                    else if (rowIndex >= this.uGrid_Details.Rows.VisibleRowCount - 1)
                                    {
                                        e.NextCtrl = null;
                                        this.uGrid_Details.PerformAction(UltraGridAction.ExitEditMode);
                                        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                        return;
                                    }
                                    else
                                    {
                                        // 1行下の仕入率にフォーカス
                                        this.uGrid_Details.Rows[rowIndex + 1].Cells[6].Activate();
                                        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
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
                                            // 得意先掛率Ｇ
                                            e.NextCtrl = this.tNedit_CustRateGrpCode21;
                                        }
                                        else if (Standard_UGroupBox.Expanded == true)
                                        {
                                            if (this.tEdit_MakerName.DataText.Trim() != "")
                                            {
                                                e.NextCtrl = this.tNedit_GoodsMakerCd;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.MakerGuide_Button;
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
                                        e.NextCtrl = this.Replace_Button;
                                        return;
                                    }
                                }

                                e.NextCtrl = null;

                                if (colIndex <= 6)
                                {
                                    if (rowIndex == 0)
                                    {
                                        e.NextCtrl = this.Replace_Button;
                                    }
                                    else
                                    {
                                        this.uGrid_Details.Rows[rowIndex - 1].Cells[COLINDEX_SALERATE_ST + this._targetDic.Count - 1].Activate();
                                        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                    }
                                }
                                else
                                {
                                    this.uGrid_Details.PerformAction(UltraGridAction.PrevCellByTab);
                                }
                            }
                        }
                        break;

                        #endregion

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
                        #region グリッド

                        if (e.ShiftKey == false)
                        {
                            if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab) || (e.Key == Keys.Down))
                            {
                                if (this.uGrid_Details.Rows.Count == 0)
                                {
                                    e.NextCtrl = this.tEdit_SectionCodeAllowZero;
                                }
                                else
                                {
                                    e.NextCtrl = null;
                                    this.uGrid_Details.Rows[0].Cells[6].Activate();
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
                                    }
                                    else
                                    {
                                        // 得意先掛率Ｇ
                                        e.NextCtrl = this.tNedit_CustRateGrpCode21;
                                    }
                                }
                                else
                                {
                                    e.NextCtrl = null;
                                    this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[6].Activate();
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
                                    if (this.Replace_Button.Enabled == false)
                                    {
                                        if ((Standard_UGroupBox.Expanded == false) &&
                                            (Standard_UGroupBox2.Expanded == false))
                                        {
                                            e.NextCtrl = e.PrevCtrl;
                                        }
                                        else if (Standard_UGroupBox2.Expanded == true)
                                        {
                                            // 得意先掛率Ｇ
                                            e.NextCtrl = this.tNedit_CustRateGrpCode21;
                                        }
                                        else
                                        {
                                            if (this.tEdit_MakerName.DataText.Trim() != "")
                                            {
                                                e.NextCtrl = this.tNedit_GoodsMakerCd;
                                            }
                                            else
                                            {
                                                e.NextCtrl = this.MakerGuide_Button;
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

                        #endregion
                    }
            }
        }

        /// <summary>
        /// AfterExitEditMode イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : 編集モードが終了した時に発生します。</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2009/04/07</br>
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
                this.uGrid_Details.ActiveCell.Value = 0;
            }
        }

        /// <summary>
        /// BeforeCellDeactivate イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : 編集モードが終了した時に発生します。</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2009/04/07</br>
        /// </remarks>
        private void uGrid_Details_BeforeCellDeactivate(object sender, CancelEventArgs e)
        {
            UltraGridRow dr;

            for (int i = 0; i < this.uGrid_Details.Rows.Count; i++)
            {
                dr = this.uGrid_Details.Rows[i];

                this.SetGridColorRow(dr);
            }
        }

        /// <summary>
        /// 各データの状態に応じた背景色を設定
        /// </summary>
        /// <remarks>
        /// <br>更新行：赤</br>
        /// <br>在庫登録されている商品：ピンク</br>
        /// </remarks>
        private void SetGridColorRow(UltraGridRow dr)
        {
            DataRow originalDr = this._dataTableClone.Select(COLUMN_NO + " ='"
                + dr.Cells[COLUMN_NO].Value.ToString() + "'")[0];

            for (int j = 6; j < dr.Cells.Count; j++)
            {
                double newdata = 0.0;
                if (!(dr.Cells[j].Value is System.DBNull))
                {
                    newdata = (double)dr.Cells[j].Value;
                }
                double olddata = (double)originalDr[j];

                if (newdata != olddata)
                {
                    dr.Cells[j].Appearance.BackColor = Color.Red;
                    dr.Cells[j].Appearance.BackColor2 = Color.Red;
                    dr.Cells[j].Appearance.BackColorDisabled = Color.Red;
                    dr.Cells[j].Appearance.BackColorDisabled2 = Color.Red;
                }
                else
                {
                    dr.Cells[j].Appearance.BackColor = Color.Empty;
                    dr.Cells[j].Appearance.BackColor2 = Color.Empty;
                    dr.Cells[j].Appearance.BackColorDisabled = Color.Empty;
                    dr.Cells[j].Appearance.BackColorDisabled2 = Color.Empty;
                }
            }
        }

        /// <summary>
        /// Button_Click イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : 表示切替ボタンがクリックされた時に発生します。</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2009/04/07</br>
        /// </remarks>
        private void Replace_Button_Click(object sender, EventArgs e)
        {
            // すべての列の表示非表示設定
            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_Details.DisplayLayout.Bands[0];

            if (editBand == null) return;

            // 指定行の全ての列に対して設定を行う。
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns)
            {
                if (col.Key == COLUMN_USERPRICEFL)
                {
                    if (col.Hidden == false)
                    {
                        col.Hidden = true;
                    }
                    else
                    {
                        col.Hidden = false;
                    }
                }
                if (col.Key == COLUMN_PRICEFL)
                {
                    if (col.Hidden == false)
                    {
                        col.Hidden = true;
                    }
                    else
                    {
                        col.Hidden = false;
                    }
                }
            }
        }

        /// <summary>
        /// ExpandedStateChanged イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : 展開ステータスが変更された時に発生します。</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2009/04/07</br>
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
        /// Leave イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : 表示切替ボタンがクリックされた時に発生します。</br>
        /// <br>Programmer  : 張凱</br>
        /// <br>Date        : 2009/04/07</br>
        /// </remarks>
        private void panel_Detail_Leave(object sender, EventArgs e)
        {
            this.uGrid_Details.ActiveCell = null;
            this.uGrid_Details.ActiveRow = null;
            this.uGrid_Details.Selected.Rows.Clear();

            UltraGridRow dr;

            for (int i = 0; i < this.uGrid_Details.Rows.Count; i++)
            {
                dr = this.uGrid_Details.Rows[i];

                this.SetGridColorRow(dr);
            }
        }

        #endregion ■ Control Events
    }
}
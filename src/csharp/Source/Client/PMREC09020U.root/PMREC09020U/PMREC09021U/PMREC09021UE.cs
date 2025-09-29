//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : お買得商品個別設定マスタ
// プログラム概要   : お買得商品設定マスタ・お買得商品個別設定を行う
//----------------------------------------------------------------------------//
//                (c)Copyright 2015 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 脇田 靖之
// 作 成 日  2015/02/20  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 脇田 靖之
// 更 新 日  2015/03/10  修正内容 : RedMine#351 売単価の桁数に制限がかかっていない
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 脇田 靖之
// 更 新 日  2015/03/11  修正内容 : 売価率変更時に標準価格も変更になる
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 小栗 大介
// 更 新 日  2015/03/13  修正内容 : 売単価を必須入力に変更
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 脇田 靖之
// 更 新 日  2015/03/16  修正内容 : 要望 公開区分をOFFにした場合に非活性項目の値をクリアしない
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 脇田 靖之
// 更 新 日  2015/03/25  修正内容 : メーカー価格取得方法修正
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 脇田 靖之
// 更 新 日  2015/03/26  修正内容 : 品証Redmine#3247
//                                  PM商品マスタ(ユーザー登録)から取得したメーカー価格に対して離島設定が反映される
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 脇田 靖之
// 更 新 日  2015/04/08  修正内容 : 品証Redmine#3435
//                                  お買得商品の得意先個別設定選択ガイドで得意先選択後、
//                                  「戻る」を選択してもガイドの選択状態が個別設定画面に反映される。
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Globalization; // 日付チェック

using Infragistics.Win.UltraWinToolbars;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Resources;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// お買得商品個別設定マスタ 明細コントロールクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : お買得商品個別設定マスタ 明細コントロールクラス</br>
    /// <br>Programmer : 脇田 靖之</br>
    /// <br>Date       : 2015/02/20</br>
    /// </remarks>
    public partial class PMREC09021UE : UserControl
    {

        #region クラス

        # region [グリッドセル結合判定クラス]
        /// <summary>
        /// グリッドセル結合判定クラス(カスタマイズ)
        /// </summary>
        public class CustomMergedCellEvaluator : Infragistics.Win.UltraWinGrid.IMergedCellEvaluator
        {
            /// <summary>結合条件セルリスト</summary>
            private List<string> _joinColList;
            /// <summary>
            /// 結合条件セルリスト
            /// </summary>
            public List<string> JoinColList
            {
                get { return _joinColList; }
                set { _joinColList = value; }
            }

            /// <summary>
            /// コンストラクタ
            /// </summary>
            public CustomMergedCellEvaluator()
            {
                _joinColList = new List<string>();
            }
            /// <summary>
            /// コンストラクタ
            /// </summary>
            public CustomMergedCellEvaluator(params string[] joinCols)
            {
                _joinColList = new List<string>(joinCols);
            }

            /// <summary>
            /// セル結合判定処理
            /// </summary>
            /// <param name="row1"></param>
            /// <param name="row2"></param>
            /// <param name="column"></param>
            /// <returns></returns>
            public bool ShouldCellsBeMerged(Infragistics.Win.UltraWinGrid.UltraGridRow row1, Infragistics.Win.UltraWinGrid.UltraGridRow row2, Infragistics.Win.UltraWinGrid.UltraGridColumn column)
            {
                foreach (string joinColName in JoinColList)
                {
                    if (!EqualCellValue(row1, row2, joinColName)) return false;
                }
                return true;
            }
            /// <summary>
            /// セルValue比較処理
            /// </summary>
            /// <param name="row1"></param>
            /// <param name="row2"></param>
            /// <param name="columnName"></param>
            /// <returns></returns>
            private bool EqualCellValue(Infragistics.Win.UltraWinGrid.UltraGridRow row1, Infragistics.Win.UltraWinGrid.UltraGridRow row2, string columnName)
            {
                return ((row1.Cells[columnName].Value.ToString().Trim() == row2.Cells[columnName].Value.ToString().Trim()));
            }
        }

        ///// <summary>
        ///// 連携拠点表示非表示
        ///// </summary>
        //public void InqOtherSecHidden(bool hidden)
        //{
        //    Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_Details.DisplayLayout.Bands[0];
        //    if (editBand == null) return;

        //    editBand.Columns[this._RecBgnCustDataTable.InqOtherSecCdColumn.ColumnName].Hidden = hidden;		// 連携拠点
        //}

        # endregion

        # region [ColumnInfo]
        /// <summary>
        /// ColumnInfo
        /// </summary>
        [Serializable]
        public struct ColumnInfo
        {
            /// <summary>列名</summary>
            private string _columnName;

            /// <summary>幅</summary>
            private int _width;

            /// <summary>
            /// 列名
            /// </summary>
            public string ColumnName
            {
                get { return _columnName; }
                set { _columnName = value; }
            }

            /// <summary>
            /// 幅
            /// </summary>
            public int Width
            {
                get { return _width; }
                set { _width = value; }
            }

            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="columnName">列名</param>
            /// <param name="width">幅</param>
            public ColumnInfo(string columnName, int width)
            {
                _columnName = columnName;
                _width = width;
            }
        }
        # endregion

        #region お買得商品設定マスタ用グリッド設定クラス

        /// <summary>
        /// お買得商品設定マスタ用グリッド設定クラス
        /// </summary>
        /// <remarks>
        /// <br>Note       : お買得商品設定マスタ用グリッド設定クラス</br>
        /// <br>Programmer : </br>
        /// <br>Date       : </br>
        /// <br></br>
        /// </remarks>
        [Serializable]
        public class RecBgnCustUserSet
        {
            #region Private Member

            // 出力形式
            private int _outputStyle;

            // 明細グリッドカラムリスト
            private List<ColumnInfo> _detailColumnsList;

            // 明細グリッド自動サイズ調整
            private bool _autoAdjustDetail;

            #endregion

            # region constractors
            /// <summary>
            /// お買得商品設定マスタ用グリッド設定クラス
            /// </summary>
            public RecBgnCustUserSet()
            {

            }
            # endregion

            #region Public Methods
            /// <summary>出力型式</summary>
            public int OutputStyle
            {
                get { return this._outputStyle; }
                set { this._outputStyle = value; }
            }

            /// <summary>明細グリッドカラムリスト</summary>
            public List<ColumnInfo> DetailColumnsList
            {
                get { return this._detailColumnsList; }
                set { this._detailColumnsList = value; }
            }

            /// <summary>明細グリッド自動サイズ調整</summary>
            public bool AutoAdjustDetail
            {
                get { return _autoAdjustDetail; }
                set { _autoAdjustDetail = value; }
            }
            #endregion
        }

        #endregion

        #endregion

        # region Private Members

        #region 定数

        /// <summary>ツールバー:行削除</summary>
        private const string TOOLBAR_ROWDELETEBUTTON_KEY = "ButtonTool_RowDelete";						// 行削除
        /// <summary>全社設定:拠点コード'00'</summary>
        private const string ALL_SECTION_CODE = "00";
        /// <summary>全社設定:拠点名'全社'</summary>
        private const string ALL_SECTION_NAME = "全社";
        /// <summary>設定XMLファイル名</summary>
        private const string XML_FILE_NAME = "PMREC09020U_Construction.XML";

        #endregion

        #region 変数

        private RecBgnGdsDataSet.RecBgnGdsRow _recBgnGdsRow;
        private RecBgnGdsDataSet.RecBgnCustDataTable _recBgnCustDataTable;
        private RecBgnGdsDataSet.RecBgnCustTmpDataTable _recBgnCustTmpDataTable;
        private RecBgnGdsDataSet.SecCusSetDataTable _secCusSetDataTable;
        private GoodsUnitData _swGoodsUnitData;
        // --- ADD 2015/03/25 Y.Wakita ---------->>>>>
        private Dictionary<Calculator.GoodsInfoKey, List<GoodsPrice>> _swMkrSuggestRtPricList;
        private Dictionary<Calculator.GoodsInfoKey, List<GoodsPrice>> _swMkrSuggestRtPricUList;
        // --- ADD 2015/03/25 Y.Wakita ----------<<<<<
        private Calculator _calculator = null;

        private ButtonTextCustomizableMessageBox _imageMsg = new ButtonTextCustomizableMessageBox();

        private static readonly Color ct_DISABLE_COLOR = Color.Gainsboro;
        private static readonly Color ct_DISABLE_FONT_COLOR = Color.Black;
        private static readonly Color ct_READONLY_CELL_COLOR = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));

        /// <summary> 企業コード</summary>
        private string _enterpriseCode = string.Empty;
        /// <summary> ログイン拠点</summary>
        private string _loginSectionCode = string.Empty;
        /// <summary> 得意先情報</summary>
        private string _swCustomerInfo = string.Empty;
        /// <summary> お買得商品ｸﾞﾙｰﾌﾟ情報</summary>
        private short _swRecBgnGrpInfo = 0;

        /// <summary> お買得商品設定マスタアクセスクラス</summary>
        private RecBgnGdsAcs _recBgnGdsAcs = null;
        /// <summary> SCM企業連結データアクセスクラス</summary>
        private ScmEpScCntAcs _scmEpScCntAcs;
        /// <summary> 拠点マスタアクセスクラス</summary>
        private SecInfoSetAcs _secInfoSetAcs;
        /// <summary> ユーザーガイドアクセスクラス</summary>
        private UserGuideAcs _userGuideAcs;

        /// <summary> ユーザー設定</summary>
        private RecBgnCustUserSet _userSetting;
        /// <summary> 拠点マスタリスト</summary>
        private List<SecInfoSet> _secInfoSetList;

        /// <summary> 得意先検索結果</summary>
        private CustomerSearchRet _customerSearchRet = null;
        /// <summary> お買得商品グループ検索結果</summary>
        private RecBgnGrpRet _recBgnGrpRet = null;

        /// <summary> 名称取得</summary>
        private bool isUnMatched = false;

        #endregion

        #endregion

        #region EventHandlers

        /// <summary>ガイドボタン イベントハンドラ</summary>
        internal event SetGuidButtonEventHandler SetGuidButton;
        /// <summary>ガイドボタン イベントハンドラ・デリゲート</summary>
        internal delegate void SetGuidButtonEventHandler(Boolean enable);

        #endregion

        #region Public プロパティ

        /// <summary>
        /// お買得商品設定マスタ アクセスクラスプロパティ
        /// </summary>
        public RecBgnGdsAcs RecBgnGdsAcs
        {
            get { return this._recBgnGdsAcs; }
        }

        /// <summary>
        /// お買得商品設定マスタ 価格算出アクセスクラスプロパティ
        /// </summary>
        public Calculator Calculator
        {
            get { return this._calculator; }
        }

        /// <summary>
        /// ユーザのプロパティ
        /// </summary>
        public RecBgnCustUserSet UserSetting
        {
            get { return this._userSetting; }
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
        public PMREC09021UE(RecBgnGdsCustInfo recBgnGdsCustInfo)
        {
            InitializeComponent();

            // TODO パラメータ変更
            this._recBgnGdsRow = recBgnGdsCustInfo.recBgnGdsRow;
            this._recBgnCustDataTable = (RecBgnGdsDataSet.RecBgnCustDataTable)recBgnGdsCustInfo.recBgnCust.Copy();
            this._swGoodsUnitData = (GoodsUnitData)recBgnGdsCustInfo.recBgnGdsRow.goodsUnitData;
            // --- ADD 2015/03/25 Y.Wakita ---------->>>>>
            this._swMkrSuggestRtPricList = (Dictionary<Calculator.GoodsInfoKey, List<GoodsPrice>>)recBgnGdsCustInfo.recBgnGdsRow.mkrSuggestRtPricList;
            this._swMkrSuggestRtPricUList = (Dictionary<Calculator.GoodsInfoKey, List<GoodsPrice>>)recBgnGdsCustInfo.recBgnGdsRow.mkrSuggestRtPricUList;
            // --- ADD 2015/03/25 Y.Wakita ----------<<<<<
            this._recBgnCustTmpDataTable = new RecBgnGdsDataSet.RecBgnCustTmpDataTable();
            this._secCusSetDataTable = new RecBgnGdsDataSet.SecCusSetDataTable();
            
            // 企業コード
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

            this._recBgnGdsAcs = new RecBgnGdsAcs();
            this._secInfoSetAcs = new SecInfoSetAcs();
            this._userGuideAcs = new UserGuideAcs();

            this._userSetting = new RecBgnCustUserSet();
            this._scmEpScCntAcs = new ScmEpScCntAcs();
            this._secInfoSetList = new List<SecInfoSet>();
            this._calculator = new Calculator();

        }
        #endregion

        #region Public Methods

        #region グリッドカラム情報

        /// <summary>
        /// グリッドカラム情報の保存
        /// </summary>
        /// <param name="fontSize">fontSize</param>
        /// <param name="autoFillToGrid">autoFillToGrid</param>
        public void SaveSettings(int fontSize, bool autoFillToGrid)
        {
            // 明細グリッド
            List<ColumnInfo> detailColumnsList;
            this.SaveGridColumnsSetting(uGrid_Details, out detailColumnsList);
            this._userSetting.DetailColumnsList = detailColumnsList;
            this._userSetting.OutputStyle = fontSize;
            this._userSetting.AutoAdjustDetail = autoFillToGrid;
        }

        /// <summary>
        /// グリッドカラム情報の読み込み
        /// </summary>
        public void LoadSettings()
        {
            this.LoadGridColumnsSetting(ref uGrid_Details, this._userSetting.DetailColumnsList);
        }

        /// <summary>
        /// グリッドカラム情報の保存
        /// </summary>
        /// <param name="targetGrid"></param>
        /// <param name="settingList"></param>
        private void SaveGridColumnsSetting(Infragistics.Win.UltraWinGrid.UltraGrid targetGrid, out List<ColumnInfo> settingList)
        {
            settingList = new List<ColumnInfo>();
            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn in targetGrid.DisplayLayout.Bands[0].Columns)
            {
                settingList.Add(new ColumnInfo(ultraGridColumn.Key, ultraGridColumn.Width));
            }
        }

        #endregion

        #region チェック処理

        /// <summary>
        /// 返却データ有無
        /// </summary>
        /// <returns>true:有 false:無</returns>
        public bool IsUpdated()
        {
            foreach (RecBgnGdsDataSet.RecBgnCustRow row in this._recBgnCustDataTable.Rows)
            {
                if (row.RowDevelopFlg == 1 && (row.RowState == DataRowState.Added || row.RowState == DataRowState.Modified))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 保存前チェック処理
        /// </summary>
        /// <param name="deleteList">削除リスト</param>
        /// <param name="updateList">更新リスト</param>
        /// <returns>bool</returns>
        /// <remarks>
        /// <br>Note       : 保存前チェック処理を行います。</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        public bool CheckSaveDate(out RecBgnGdsDataSet.RecBgnCustDataTable recBgnCustDataTable)
        {
            recBgnCustDataTable = null;

            #region 必須チェック

            foreach (RecBgnGdsDataSet.RecBgnCustRow row in this._recBgnCustDataTable.Rows)
            {

                //行番号を取得
                int rowIndex = row.RowNo;

                // 得意先コードを入力チェック
                if (row.RowDevelopFlg != 0 && row.CustomerCode.Trim().Equals(string.Empty))
                {
                    TMsgDisp.Show(
                         this,
                         emErrorLevel.ERR_LEVEL_EXCLAMATION,
                         this.Name,
                         "得意先コードを入力して下さい。",
                         0,
                         MessageBoxButtons.OK);
                    if (rowIndex >= 0 && rowIndex < this.uGrid_Details.Rows.Count)
                    {
                        this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnCustDataTable.CustomerCodeColumn.ColumnName].Activate();
                        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                    }
                    return false;
                }

                // お買得商品グループコード
                if (row.RowDevelopFlg != 0 && row.DisplayDivCode !=0 && row.BrgnGoodsGrpCode == 0)
                {
                    TMsgDisp.Show(
                         this,
                         emErrorLevel.ERR_LEVEL_EXCLAMATION,
                         this.Name,
                         "お買得商品グループコードを入力して下さい。",
                         0,
                         MessageBoxButtons.OK);
                    if (rowIndex >= 0 && rowIndex < this.uGrid_Details.Rows.Count)
                    {
                        this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnCustDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Activate();
                        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                    }
                    return false;
                }

                //---------ADD 2015/03/13 小栗--------->>>>>>
                // 売単価を入力チェック
                if (row.RowDevelopFlg != 0 && row.DisplayDivCode != 0 && row.UnitPrice == 0)
                {
                    TMsgDisp.Show(
                         this,
                         emErrorLevel.ERR_LEVEL_EXCLAMATION,
                         this.Name,
                         "売単価を入力して下さい。",
                         0,
                         MessageBoxButtons.OK);
                    if (rowIndex >= 0 && rowIndex < this.uGrid_Details.Rows.Count)
                    {
                        this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnCustDataTable.UnitPriceColumn.ColumnName].Activate();
                        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                    }
                    return false;
                }
                //---------ADD 2015/03/13 小栗---------<<<<<<
            }
            #endregion

            #region 重複チェック
            foreach (RecBgnGdsDataSet.RecBgnCustRow bgn in this._recBgnCustDataTable.Rows)
            {

                //行番号を取得
                int rowIndex = bgn.RowNo;
                
                // 変換
                RecBgnCust recBgnCust= null;
                this.CopyToRecBgnCustFromDetailRow(bgn, ref recBgnCust);

                int flag = 0;
                string errorMsg = string.Empty;

                #region 重複レコードの存在チェック
                flag = 0;
                foreach (RecBgnGdsDataSet.RecBgnCustRow row in this._recBgnCustDataTable.Rows)
                {
                    if (row.RowNo == bgn.RowNo) continue;

                    if (recBgnCust.InqOriginalEpCd == row.InqOriginalEpCd
                        && recBgnCust.InqOriginalSecCd == row.InqOriginalSecCd
                        && recBgnCust.InqOtherEpCd == row.InqOtherEpCd
                        && recBgnCust.InqOtherSecCd.ToString().PadLeft(2, '0') == row.InqOtherSecCd.ToString().PadLeft(2, '0'))
                    {
                        errorMsg = "公開日：" + recBgnCust.ApplyStaDate.ToString().PadLeft(6, '0')
                               + "～" + recBgnCust.ApplyEndDate.ToString().PadLeft(6, '0')
                               + "、得意先：" + recBgnCust.CustomerCode.ToString().PadLeft(8, '0');

                        int startDate = 0;
                        if (!row.ApplyStaDate.Trim().Equals(string.Empty)) startDate = int.Parse(row.ApplyStaDate.Trim().Replace("/", ""));
                        int endDate = 0;
                        if (!row.ApplyEndDate.Trim().Equals(string.Empty)) endDate = int.Parse(row.ApplyEndDate.Trim().Replace("/", ""));

                        if ((startDate <= recBgnCust.ApplyStaDate
                            && recBgnCust.ApplyStaDate <= endDate)
                            || (startDate <= recBgnCust.ApplyEndDate
                            && recBgnCust.ApplyEndDate <= endDate))
                        {
                            flag++;
                        }
                    }
                    if (flag > 1)
                    {
                        TMsgDisp.Show(
                             this,
                             emErrorLevel.ERR_LEVEL_EXCLAMATION,
                             this.Name,
                             "同一得意先の設定が既に登録されています。" + "\r\n" +
                             errorMsg,
                             0,
                             MessageBoxButtons.OK);

                        if (rowIndex >= 0 && rowIndex < this.uGrid_Details.Rows.Count)
                        {
                            this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnCustDataTable.CustomerCodeColumn.ColumnName].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        return false;
                    }
                }
                #endregion
            }
            #endregion

            recBgnCustDataTable = this._recBgnCustDataTable;
            return true;
        }

        /// <summary>
        /// DOWN前チェック処理
        /// </summary>
        /// <returns>bool</returns>
        /// <remarks>
        /// <br>Note       : 保存前チェック処理を行います。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2011/07/06</br>
        /// </remarks>
        public bool CheckDateForDown()
        {
            RecBgnCust recBgnCust = new RecBgnCust();
            this.CopyToRecBgnCustFromDetailRow((RecBgnGdsDataSet.RecBgnCustRow)this._recBgnCustDataTable.Rows[this._recBgnCustDataTable.Count - 1], ref recBgnCust);

            // 得意先コードを入力チェック
            if (recBgnCust.CustomerCode == 0)
            {
                return false;
            }
            return true;
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
        /// <br>Note        : 数値入力チェック処理</br>
        /// <br>Programmer  : 脇田 靖之</br>
        /// <br>Date        : 2015/02/20</br>
        /// </remarks>
        public bool KeyPressNumCheck(int keta, int priod, string prevVal, char key, int selstart, int sellength, Boolean minusFlg)
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
            string _strResult = string.Empty;
            if (sellength > 0)
            {
                _strResult = prevVal.Substring(0, selstart) + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));
            }
            else
            {
                _strResult = prevVal;
            }

            // マイナスのチェック
            if (key == '-')
            {
                if ((minusFlg == false) || (selstart > 0) || (_strResult.IndexOf('-') != -1))
                {
                    return false;
                }
            }

            // 小数点のチェック
            if (key == '.')
            {
                if ((priod <= 0) || (_strResult.IndexOf('.') != -1))
                {
                    return false;
                }
            }
            // キーが押された結果の文字列を生成する。
            _strResult = prevVal.Substring(0, selstart)
                + key
                + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));

            // 桁数チェック！
            if (_strResult.Length > keta)
            {
                if (_strResult[0] == '-')
                {
                    if (_strResult.Length > (keta + 1))
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
                int _pointPos = _strResult.IndexOf('.');

                // 整数部に入力可能な桁数を決定！
                int _Rketa = RecBgnGdsAcs.diverge<int>(_strResult[0] == '-', keta - priod, keta - priod - 1);
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
                    if (_strResult.Length > _Rketa)
                    {
                        return false;
                    }
                }

                // 小数部の桁数をチェック
                if (_pointPos != -1)
                {
                    // 小数部の桁数を計算
                    int _priketa = _strResult.Length - _pointPos - 1;
                    if (priod < _priketa)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 日付入力チェック処理
        /// </summary>
        /// <param name="keta">桁数(スラッシュ符号を含まず)</param>
        /// <param name="prevVal">現在の文字列</param>
        /// <param name="key">入力されたキー値</param>
        /// <param name="selstart">カーソル位置</param>
        /// <param name="sellength">選択文字長</param>
        /// <remarks>
        /// <br>Note        : 日付入力チェック処理</br>
        /// <br>Programmer  : 鹿庭 一郎</br>
        /// <br>Date        : 2015/02/09</br>
        /// </remarks>
        public bool KeyPressDateCheck(int keta, string prevVal, char key, int selstart, int sellength)
        {
            // 制御キーが押された？
            if (Char.IsControl(key))
            {
                return true;
            }
            // 数値以外は、ＮＧ
            if (!Char.IsDigit(key))
            {
                // スラッシュ以外
                if (key != '/') return false;
            }

            // キーが押されたと仮定した場合の文字列を生成する。
            string _strResult = string.Empty;
            if (sellength > 0)
            {
                _strResult = prevVal.Substring(0, selstart) + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));
            }
            else
            {
                _strResult = prevVal;
            }

            // キーが押された結果の文字列を生成する。
            _strResult = prevVal.Substring(0, selstart)
                + key
                + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));

            // 桁数チェック！
            if (_strResult.Length > keta)
            {
                if (_strResult[0] == '/')
                {
                    if (_strResult.Length > (keta + 1))
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        #endregion

        #region グリッド

        /// <summary>
        /// ReturnKey押下処理(グリッド内)
        /// </summary>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : ReturnKey押下処理を行います。</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        public void ReturnKeyDown(ref ChangeFocusEventArgs e)
        {
            if ((this.uGrid_Details.ActiveCell == null) && (this.uGrid_Details.ActiveRow == null))
            {
                this.uGrid_Details.Rows[0].Cells[this._recBgnCustDataTable.CustomerCodeColumn.ColumnName].Activate();
            }

            string columnKey;
            int rowIndex;

            if (this.uGrid_Details.ActiveCell != null)
            {
                columnKey = this.uGrid_Details.ActiveCell.Column.Key;
                rowIndex = this.uGrid_Details.ActiveCell.Row.Index;
            }
            else
            {
                columnKey = this._recBgnCustDataTable.CustomerCodeColumn.ColumnName;
                rowIndex = this.uGrid_Details.ActiveRow.Index;
            }

            e.NextCtrl = null;

            //if (this.uGrid_Details.ActiveRow != null)
            //{
            //    if (this.uGrid_Details.ActiveRow.Selected)
            //    {
            //        this.uGrid_Details.ActiveRow.Cells[this._recBgnCustDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Activate();
            //        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
            //        return;
            //    }
            //}

            this.uGrid_Details.PerformAction(UltraGridAction.ExitEditMode);

            // 入力エラー時は移動させない
            if (isUnMatched)
            {
                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                isUnMatched = false;
                    return;
                }

            MoveNextAllowEditCell(false);

        }

        /// <summary>
        /// ShiftKey押下処理(グリッド内)
        /// </summary>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : ShiftKey押下処理を行います。</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        public void ShiftKeyDown(ref ChangeFocusEventArgs e)
        {
            if ((this.uGrid_Details.ActiveCell == null) && (this.uGrid_Details.ActiveRow == null))
            {
                this.uGrid_Details.Rows[0].Cells[this._recBgnCustDataTable.CustomerCodeColumn.ColumnName].Activate();
            }

            string columnKey;
            int rowIndex;

            if (this.uGrid_Details.ActiveCell != null)
            {
                columnKey = this.uGrid_Details.ActiveCell.Column.Key;
                rowIndex = this.uGrid_Details.ActiveCell.Row.Index;
            }
            else
            {
                columnKey = this._recBgnCustDataTable.CustomerCodeColumn.ColumnName;
                rowIndex = this.uGrid_Details.ActiveRow.Index;
            }

            e.NextCtrl = null;

            if (this.uGrid_Details.ActiveRow != null)
            {
                if (this.uGrid_Details.ActiveRow.Selected)
                {
                    if (this.uGrid_Details.ActiveRow.Index > 0)
                    {
                        if (this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index - 1].Cells[this._recBgnCustDataTable.ApplyStaDateColumn.ColumnName].Activation == Activation.AllowEdit)
                        {
                            this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index - 1].Cells[this._recBgnCustDataTable.ApplyStaDateColumn.ColumnName].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        else
                        {
                            this.uGrid_Details.Rows[this.uGrid_Details.ActiveRow.Index - 1].Cells[this._recBgnCustDataTable.DisplayDivCodeColumn.ColumnName].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        }
                    }
                    return;
                }
            }

            this.uGrid_Details.PerformAction(UltraGridAction.ExitEditMode);

            MovePreAllowEditCell(false);
        }

        /// <summary>
        /// 明細部アクッチブキーを取得
        /// </summary>
        /// <param name="rowIndex">行番号</param>
        /// <remarks>
        /// <br>Note       : 明細部アクッチブキーを取得を行います。</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        public string GetFocusColumnKey(out int rowIndex, out RecBgnGdsDataSet.RecBgnCustRow dataRow)
        {
            if (this.uGrid_Details.ActiveCell == null)
            {
                rowIndex = -1;
                dataRow = null;
                return string.Empty;
            }

            rowIndex = this.uGrid_Details.ActiveCell.Row.Index;
            dataRow = (RecBgnGdsDataSet.RecBgnCustRow)this._recBgnCustDataTable.Rows[rowIndex];
            return this.uGrid_Details.ActiveCell.Column.Key;
        }

        #endregion ReturnKeyDown

        #region ガイド
        /// <summary>
        /// ガイドボタン設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : ガイドボタン設定処理を行います。</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        public void SetGridGuid()
        {
            if (this.uGrid_Details.ActiveCell != null)
            {
                switch (this.uGrid_Details.ActiveCell.Column.Key)
                {
                    case "CustomerCode":
                    case "BrgnGoodsGrpCode": 
                        {
                            if (this.uGrid_Details.ActiveCell.Activation == Activation.AllowEdit)
                            {
                                this.SetGuidButton(true);
                            }
                            else
                            {
                                this.SetGuidButton(false);
                            }
                            break;
                        }
                    default:
                        {
                            this.SetGuidButton(false);
                            break;
                        }
                }
            }
            else
            {
                this.SetGuidButton(false);
            }
        }

        #endregion

        #endregion

        #region Private Methods

        #region ControlEvents

        #region フォーム

        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note	   : フォームが読み込まれた時に発生します。</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private void PMREC09021UE_Load(object sender, EventArgs e)
        {
            // データソースとしてデータビューを指定
            this.uGrid_Details.DataSource = this._recBgnCustDataTable;

            // 初期化
            this.Init(false);

            #region 子画面用追加
            // 拠点情報のキャッシュ
            ArrayList list = new ArrayList();
            this._secInfoSetAcs.Search(out list, this._enterpriseCode);
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].GetType().Equals(typeof(SecInfoSet)))
                {
                    this._secInfoSetList.Add((SecInfoSet)list[i]);
                }
            }
            #endregion
        }

        #endregion

        #region Toolbar
        /// <summary>
        /// ツールバークリックイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note	   : フォームが読み込まれた時に発生します。</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private void tToolbarsManager_MainMenu_ToolClick(object sender, ToolClickEventArgs e)
        {
            switch (e.Tool.Key)
            {
                // 行削除
                case TOOLBAR_ROWDELETEBUTTON_KEY:
                    {
                        this.uButton_RowDelete_Click(sender, new EventArgs());
                        break;
                    }
            }
        }

        #endregion

        #region ボタン


        /// <summary>
        /// 行削除
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        private void DeleteRow(RecBgnGdsDataSet.RecBgnCustRow row)
        {

            // 行クリア
            this._recBgnCustDataTable.Rows.Remove(row);
            this.AddNewRow();
            AcceptChangesRecBgnCustDataRow();
            this._recBgnCustTmpDataTable.AcceptChanges();

        }
        
        /// <summary>
        /// 行削除（同一得意先行一括削除）
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        private void DeleteRow(string customerCode)
        {
            // 確定行は同一得意先行を全て削除する
            if (!customerCode.Equals(string.Empty))
            {
                DataRow[] rows = this._recBgnCustDataTable.Select("CustomerCode = '" + customerCode + "'");
                for (int i = 0; i < rows.Length; i++)
                {
                    _recBgnCustDataTable.Rows.Remove(rows[i]);
                }
                this._recBgnCustTmpDataTable.AcceptChanges();
                AcceptChangesRecBgnCustDataRow();

            }

        }
        
        /// <summary>
        /// 行削除処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : 行削除処理を行います。</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private void uButton_RowDelete_Click(object sender, EventArgs e)
        {
            if (this.uGrid_Details.ActiveRow == null) return;

            DialogResult dialogResult = TMsgDisp.Show(this
                                                     , emErrorLevel.ERR_LEVEL_QUESTION
                                                     , this.Name
                                                     , "明細をクリアしてもよろしいですか？"
                                                     , 0
                                                     , MessageBoxButtons.YesNo
                                                     , MessageBoxDefaultButton.Button1);

            if (dialogResult == DialogResult.Yes)
            {
                this.Cursor = Cursors.WaitCursor;
                this.uGrid_Details.BeginUpdate();

                // アクティブ行情報
                int activeRowIndex = this.uGrid_Details.ActiveRow.Index;
                RecBgnGdsDataSet.RecBgnCustRow row = (RecBgnGdsDataSet.RecBgnCustRow)this._recBgnCustDataTable.Rows[activeRowIndex];

                // 未確定の新規行はクリアする
                if (row.RowDevelopFlg == 0)
                {
                    DeleteRow(row);
                    this.uGrid_Details.EndUpdate();
                    this.Cursor = Cursors.Default;
                    return;
                }

                // 確定行は同一得意先を一括削除する
                DeleteRow(row.CustomerCode);

                this.uGrid_Details.EndUpdate();
                this.Cursor = Cursors.Default;

                // ------------------------------------------
                // Activeにする行を特定
                int rowIndex = 0;
                if (activeRowIndex < this._recBgnCustDataTable.Rows.Count - 1)
                {
                    rowIndex = activeRowIndex;
                }
                else
                {
                    rowIndex = this._recBgnCustDataTable.Rows.Count - 1;
                }
                if (rowIndex < 0) rowIndex = 0;

                // 新規行は得意先、既存は表示区分をアクティブ
                RecBgnGdsDataSet.RecBgnCustRow updateRow = (RecBgnGdsDataSet.RecBgnCustRow)this._recBgnCustDataTable.Rows[rowIndex];
                if (updateRow.RowDevelopFlg == 0)
                {
                    this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnCustDataTable.CustomerCodeColumn.ColumnName].Activate();
                }
                else
                {
                    this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnCustDataTable.DisplayDivCodeColumn.ColumnName].Activate();
                }
            }
            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
        }

        #endregion

        #region Grid
        /// <summary>
        /// 明細初期化イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note	   : 明細初期化イベントします。</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private void uGrid_Details_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            this.uGrid_Details.BeginUpdate();

            // グリッド列初期設定処理
            this.InitialSettingGridCol();

            this.uGrid_Details.EndUpdate();
        }

        /// <summary>
        /// セルのデータチェック処理
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <returns/>
        /// <remarks>
        /// <br>Note       : セルのデータチェック処理。</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private void uGrid_Details_CellDataError(object sender, CellDataErrorEventArgs e)
        {
            if (this.uGrid_Details.ActiveCell != null)
            {
                // 数値項目の場合
                if ((this.uGrid_Details.ActiveCell.Column.DataType == typeof(Int16)) ||
                    (this.uGrid_Details.ActiveCell.Column.DataType == typeof(Int32)) ||
                    (this.uGrid_Details.ActiveCell.Column.DataType == typeof(Int64)) ||
                    (this.uGrid_Details.ActiveCell.Column.DataType == typeof(double)))
                {
                    Infragistics.Win.EmbeddableEditorBase editorBase = this.uGrid_Details.ActiveCell.EditorResolved;

                    // 未入力は0にする				
                    if (editorBase.CurrentEditText.Trim() == "")
                    {
                        //editorBase.Value = 0;				// 0をセット
                        //this.uGrid_Details.ActiveCell.Value = 0;
                    }
                    // 数値項目に「-」or「.」だけしか入ってなかったら駄目です				
                    else if ((editorBase.CurrentEditText.Trim() == "-")
                          || (editorBase.CurrentEditText.Trim() == ".")
                          || (editorBase.CurrentEditText.Trim() == "-."))
                    {
                        editorBase.Value = this.uGrid_Details.ActiveCell.Value;				// 前回値をセット
                    }
                    // 通常入力				
                    else
                    {
                        try
                        {
                            editorBase.Value = Convert.ChangeType(editorBase.CurrentEditText.Trim(), this.uGrid_Details.ActiveCell.Column.DataType);
                            this.uGrid_Details.ActiveCell.Value = editorBase.Value;
                        }
                        catch
                        {
                            editorBase.Value = 0;				// 0をセット
                            this.uGrid_Details.ActiveCell.Value = 0;
                        }
                    }
                    e.RaiseErrorEvent = false;			// エラーイベントは発生させない
                    e.RestoreOriginalValue = false;		// セルの値を元に戻さない	
                    e.StayInEditMode = false;			// 編集モードは抜ける
                }
            }
        }

        /// <summary>
        /// グリッドセルアクティブ後発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note        : グリッドセルアクティブ後発生イベント</br>
        /// <br>Programmer  : 脇田 靖之</br>
        /// <br>Date        : 2015/02/20</br>
        /// </remarks>
        private void uGrid_Details_AfterCellActivate(object sender, EventArgs e)
        {
            this.SetGridGuid();

            //// 部品情報プレビュー表示
            //this.GoodsInfoPreview(this.uGrid_Details.ActiveRow.Index);
        }

        /// <summary>
        /// グリッドセルアクティブ前発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note        : グリッドセルアクティブ前発生イベント</br>
        /// <br>Programmer  : 脇田 靖之</br>
        /// <br>Date        : 2015/02/20</br>
        /// </remarks>
        private void uGrid_Details_BeforeCellActivate(object sender, CancelableCellEventArgs e)
        {
            if (e.Cell == null) return;
            UltraGridCell cell = e.Cell;

            // その他 IMEを無効
            this.uGrid_Details.ImeMode = System.Windows.Forms.ImeMode.Disable;

            // 得意先コード
            if (cell.Column.Key == this._recBgnCustDataTable.CustomerCodeColumn.ColumnName)
            {
                this._swCustomerInfo = e.Cell.Value.ToString().PadLeft(8, '0');
            }
            // お買得商品グループコード
            else if (cell.Column.Key == this._recBgnCustDataTable.BrgnGoodsGrpCodeColumn.ColumnName)
            {
                this._swRecBgnGrpInfo = (Int16)e.Cell.Value;
            }
        }

        /// <summary>
        /// KeyDown イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note        : グリッドアクティブ時にKeyを押された時に発生します。</br>
        /// <br>Programmer  : 脇田 靖之</br>
        /// <br>Date        : 2015/02/20</br>
        /// </remarks>
        private void uGrid_Details_KeyDown(object sender, KeyEventArgs e)
        {

            if (this.uGrid_Details.ActiveCell == null)
            {
                return;
            }

            int rowIndex = this.uGrid_Details.ActiveCell.Row.Index;
            string columnKey = this.uGrid_Details.ActiveCell.Column.Key;

            if (this.uGrid_Details.ActiveCell.IsInEditMode)
            {
                if (this.uGrid_Details.ActiveCell.Editor != null)
                {
                    if (e.KeyCode == Keys.Left && this.uGrid_Details.ActiveCell.SelStart != 0)
                    {
                        return;
                    }
                    if (e.KeyCode == Keys.Right && this.uGrid_Details.ActiveCell.SelStart < this.uGrid_Details.ActiveCell.Text.Length)
                    {
                        return;
                    }
                }
            }

            switch (e.KeyCode)
            {
                case Keys.Up:
                    {
                        if (rowIndex == 0)
                        {
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            e.Handled = true;
                        }
                        else
                        {
                            e.Handled = true;
                            this.uGrid_Details.Rows[rowIndex - 1].Cells[columnKey].Activate();
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        break;
                    }
                case Keys.Down:
                case Keys.Return:
                    {
                        this.uGrid_Details.PerformAction(UltraGridAction.ExitEditMode);

                        if (rowIndex == this.uGrid_Details.Rows.Count - 1)
                        {
                            e.Handled = true;
                            if (CheckDateForDown())
                            {
                                // 明細展開処理
                                if (this.BgnDataDeployment() == true)
                                {
                                    this.AddNewRow();

                                    this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnCustDataTable.UnitCalcRateColumn.ColumnName].Activation = Activation.AllowEdit;
                                    this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnCustDataTable.UnitCalcRateColumn.ColumnName].Activate();
                                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                }
                                else
                                {
                                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                    break;
                                }
                            }
                        }
                        else
                        {
                            e.Handled = true;
                            this.uGrid_Details.Rows[rowIndex + 1].Cells[columnKey].Activate();
                        }
                        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        break;
                    }
                case Keys.Left:
                    {
                        this.uGrid_Details.PerformAction(UltraGridAction.ExitEditMode);

                        // 得意先の場合
                        if (columnKey == this._recBgnCustDataTable.CustomerCodeColumn.ColumnName)
                        {
                            // 左端から次行左端に移動させない
                            if (this.uGrid_Details.ActiveCell.Column.Header.VisiblePosition == 1)
                            {
                                e.Handled = true;
                            }
                            else
                            {
                                e.Handled = true;
                                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                break;
                            }
                        }
                        else
                        {
                            // 次セル取得
                            string columnName = columnKey;
                            // 次セル取得
                            int targetColumnIndex = GetNextColumnIndexByTab(1, rowIndex, columnName);

                            if (targetColumnIndex != -1)
                            {
                                this.uGrid_Details.Rows[rowIndex].Cells[targetColumnIndex].Activate();
                            }
                            else
                            {
                                columnName = this._recBgnCustDataTable.ApplyStaDateColumn.ColumnName;
                                this.uGrid_Details.Rows[rowIndex - 1].Cells[columnName].Activate();
                            }
                        }

                        e.Handled = true;
                        this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        break;
                    }
                case Keys.Right:
                    {
                        if (columnKey == this._recBgnCustDataTable.UpdateTimeColumn.ColumnName)
                        {
                            // なし。
                        }
                        else if (columnKey == this._recBgnCustDataTable.UnitPriceColumn.ColumnName)
                        {
                            // 右端のVisiblePositionを取得
                            int lastPosition = this.GetGridLastPosition(this.uGrid_Details);

                            // 右端から次行左端に移動させない
                            if (this.uGrid_Details.ActiveCell.Column.Header.VisiblePosition == lastPosition)
                            {
                                e.Handled = true;
                            }
                        }
                        else
                        {
                            this.uGrid_Details.PerformAction(UltraGridAction.ExitEditMode);

                            // 次セル取得
                            string columnName = columnKey;
                            // 次セル取得
                            int targetColumnIndex = GetNextColumnIndexByTab(0, rowIndex, columnName);

                            if (targetColumnIndex != -1)
                            {
                                //if (focusFlg)
                                //{
                                this.uGrid_Details.Rows[rowIndex].Cells[targetColumnIndex].Activate();
                                //}
                            }
                            else
                            {
                                if (rowIndex < this.uGrid_Details.Rows.Count - 1)
                                {
                                    // 改行
                                    columnName = this._recBgnCustDataTable.CustomerCodeColumn.ColumnName;
                                    this.uGrid_Details.Rows[rowIndex + 1].Cells[columnName].Activate();
                                }
                                else
                                {
                                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                    return;
                                }
                            }

                            e.Handled = true;
                            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                        }
                        break;
                    }
            }

        }

        /// <summary>
        /// グリッド内の最後のVisiblePosition取得
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        private int GetGridLastPosition(Infragistics.Win.UltraWinGrid.UltraGrid grid)
        {
            if (grid.ActiveRow == null) return 0;

            int colCount = 0;
            for (int index = 0; index < grid.ActiveRow.Cells.Count; index++)
            {
                if (grid.ActiveRow.Cells[index].Column.Hidden == false)
                {
                    if (colCount < grid.ActiveRow.Cells[index].Column.Header.VisiblePosition)
                    {
                        colCount = grid.ActiveRow.Cells[index].Column.Header.VisiblePosition;
                    }
                }
            }
            return colCount;
        }

        /// <summary>
        /// グリッド内の最前のVisiblePosition取得
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        private int GetGridFirstPosition(Infragistics.Win.UltraWinGrid.UltraGrid grid)
        {
            if (grid.ActiveRow == null) return 0;

            int colCount = 5;
            for (int index = 0; index < grid.ActiveRow.Cells.Count; index++)
            {
                if (grid.ActiveRow.Cells[index].Column.Hidden == false)
                {
                    if (colCount > grid.ActiveRow.Cells[index].Column.Header.VisiblePosition)
                    {
                        colCount = grid.ActiveRow.Cells[index].Column.Header.VisiblePosition;
                    }
                }
            }
            return colCount;
        }

        /// <summary>
        /// グリッドセルアプデト後発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note        : グリッドセルアプデト後発生イベント</br>
        /// <br>Programmer  : 脇田 靖之</br>
        /// <br>Date        : 2015/02/20</br>
        /// </remarks>
        private void uGrid_Details_AfterCellUpdate(object sender, CellEventArgs e)
        {
            if (e.Cell == null) return;
            UltraGridCell cell = e.Cell;
            UltraGridRow row = e.Cell.Row;
            

            this.uGrid_Details.AfterCellUpdate -= this.uGrid_Details_AfterCellUpdate;

            // 得意先
            if (cell.Column.Key == this._recBgnCustDataTable.CustomerCodeColumn.ColumnName)
            {
                int inputValue = 0;

                // 入力値を取得
                Int32.TryParse(cell.Value.ToString(), out inputValue);

                if (inputValue != 0)
                {
                    string errMsg = string.Empty;

                    // 入力値を取得
                    Int32.TryParse(cell.Value.ToString(), out inputValue);
                    if (this._recBgnGdsAcs.CheckCustomer(inputValue, true, out errMsg))
                    {
                        CustomerInfo customerInfo = this._recBgnGdsAcs.CustomerDic[inputValue];
                        this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnCustDataTable.CustomerCodeColumn.ColumnName].Value = inputValue.ToString().PadLeft(8, '0');    // 得意先コード
                        this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnCustDataTable.CustomerNameColumn.ColumnName].Value = customerInfo.CustomerSnm;                 // 得意先名
                        this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnCustDataTable.InqOriginalEpCdColumn.ColumnName].Value = customerInfo.CustomerEpCode;           // 問合せ元企業コード
                        this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnCustDataTable.InqOriginalSecCdColumn.ColumnName].Value = customerInfo.CustomerSecCode;         // 問合せ元拠点コード
                        this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnCustDataTable.MngSectionCodeColumn.ColumnName].Value = customerInfo.MngSectionCode;            // 管理拠点
                        this._swCustomerInfo = inputValue.ToString().PadLeft(8, '0');
                    }
                    else
                    {
                        TMsgDisp.Show(this
                                     , emErrorLevel.ERR_LEVEL_EXCLAMATION
                                     , this.Name
                                     , errMsg
                                     , 0
                                     , MessageBoxButtons.OK);

                        this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnCustDataTable.CustomerCodeColumn.ColumnName].Value = this._swCustomerInfo.ToString().PadLeft(8, '0');
                        isUnMatched = true;
                    }
                }
                else
                {
                    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnCustDataTable.CustomerCodeColumn.ColumnName].Value = string.Empty;     // 得意先コード
                    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnCustDataTable.CustomerNameColumn.ColumnName].Value = string.Empty;     // 得意先名
                    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnCustDataTable.InqOriginalEpCdColumn.ColumnName].Value = string.Empty;  // 問合せ元企業コード
                    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnCustDataTable.InqOriginalSecCdColumn.ColumnName].Value = string.Empty; // 問合せ元拠点コード
                    this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnCustDataTable.MngSectionCodeColumn.ColumnName].Value = string.Empty;   // 管理拠点
                    this._swCustomerInfo = string.Empty;
                }
            }

            // お買得商品グル―プ
            if (cell.Column.Key == this._recBgnCustDataTable.BrgnGoodsGrpCodeColumn.ColumnName)
            {
                short gdsGrpCode = 0;
                short.TryParse(cell.Value.ToString(), out gdsGrpCode);

                // 公開する場合のみ
                if (this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._recBgnCustDataTable.DisplayDivCodeColumn.ColumnName].Text != "0")
                {

                    // 入力値を取得
                    if (!cell.Value.ToString().Trim().Equals(string.Empty))
                    {
                        string errMsg = string.Empty;

                        RecBgnGdsDataSet.RecBgnCustRow dataRow = (RecBgnGdsDataSet.RecBgnCustRow)this._recBgnCustDataTable.Rows[cell.Row.Index];

                        if (this._recBgnGdsAcs.CheckRecBgnGrp(dataRow.InqOriginalEpCd, dataRow.InqOriginalSecCd, gdsGrpCode, true, out errMsg))
                        {
                            string recBgnGrpName = this._recBgnGdsAcs.GetRecBgnGrpName(dataRow.InqOriginalEpCd, dataRow.InqOriginalSecCd, gdsGrpCode);

                            this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnCustDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Value = gdsGrpCode;
                            this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnCustDataTable.BrgnGoodsGrpNameColumn.ColumnName].Value = recBgnGrpName;
                            this._swRecBgnGrpInfo = gdsGrpCode;
                        }
                        else
                        {
                            TMsgDisp.Show(this
                                         , emErrorLevel.ERR_LEVEL_EXCLAMATION
                                         , this.Name
                                         , errMsg
                                         , 0
                                         , MessageBoxButtons.OK);

                            this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnCustDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Value = this._swRecBgnGrpInfo;
                            this.isUnMatched = true;
                        }
                    }
                    else
                    {
                        this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnCustDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Value = 0;
                        this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnCustDataTable.BrgnGoodsGrpNameColumn.ColumnName].Value = string.Empty;
                        this._swRecBgnGrpInfo = 0;
                    }
                }
            }

            // 売価率
            if (cell.Column.Key == this._recBgnCustDataTable.UnitCalcRateColumn.ColumnName)
            {

                double inputValue = 0.0;
                double.TryParse(cell.Value.ToString(), out inputValue);

                RecBgnGdsDataSet.RecBgnCustRow dataRow = (RecBgnGdsDataSet.RecBgnCustRow)this._recBgnCustDataTable.Rows[row.Index];
                if (dataRow.RowDevelopFlg==0) return;

                // 公開する場合のみ
                if (this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._recBgnCustDataTable.DisplayDivCodeColumn.ColumnName].Text != "0")
                {
                    // 得意先と売価率の入力時に売価計算
                    if (inputValue != 0
                        && !dataRow.CustomerCode.Trim().Equals(string.Empty))
                    {

                        string sectionCode = dataRow.MngSectionCode;                            // 管理拠点
                        int customerCode = int.Parse(dataRow.CustomerCode);                     // 得意先
                        long mkrSuggestRtPric = dataRow.MkrSuggestRtPric;                       // メーカー希望価格
                        DateTime startTime = DateTime.Parse(this._recBgnGdsRow.ApplyStaDate);   // 開始日
                        double listPrice = 0;                                                   // 定価
                        double unitPrice = 0;                                                   // 売価

                        // 価格計算
                        this._calculator.GetUnitPriceFromRate(sectionCode, customerCode, mkrSuggestRtPric, inputValue, this._swGoodsUnitData, startTime, out listPrice, out unitPrice);

                        //this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnCustDataTable.ListPriceColumn.ColumnName].Value = (long)listPrice;     // 定価    // DEL 2015/03/11 Y.Wakita
                        this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnCustDataTable.UnitPriceColumn.ColumnName].Value = (long)unitPrice;     // 売価

                    }
                    else
                    {
                        if (!dataRow.CustomerCode.Trim().Equals(string.Empty))
                        {
                            string sectionCode = dataRow.MngSectionCode;                            // 拠点
                            int customerCode = int.Parse(dataRow.CustomerCode);                     // 得意先
                            long mkrSuggestRtPric = dataRow.MkrSuggestRtPric;                       // メーカー希望価格
                            DateTime startTime = DateTime.Parse(this._recBgnGdsRow.ApplyStaDate);   // 開始日
                            long listPrice = 0;                                                   // 定価
                            long unitPrice = 0;                                                   // 売価
                            bool uPricDiv = false;  // ADD 2015/03/26 Y.Wakita

                            // 取り直し
                            // --- UPD 2015/03/25 Y.Wakita ---------->>>>>
                            //this._calculator.GetUnitPrice(customerCode
                            //                           , this._swGoodsUnitData
                            //                           , startTime
                            //                           , dataRow.MngSectionCode
                            //                           , out mkrSuggestRtPric
                            //                           , out listPrice
                            //                           , out unitPrice);
                            this._calculator.GetUnitPrice(customerCode
                                                       , this._swGoodsUnitData
                                                       , startTime
                                                       , dataRow.MngSectionCode
                                                       , this._swMkrSuggestRtPricList
                                                       , this._swMkrSuggestRtPricUList
                                                       , out uPricDiv   // ADD 2015/03/26 Y.Wakita
                                                       , out mkrSuggestRtPric
                                                       , out listPrice
                                                       , out unitPrice);
                            // --- UPD 2015/03/25 Y.Wakita ----------<<<<<

                            //this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnCustDataTable.ListPriceColumn.ColumnName].Value = (long)listPrice;     // 定価    // DEL 2015/03/11 Y.Wakita
                            this.uGrid_Details.Rows[cell.Row.Index].Cells[this._recBgnCustDataTable.UnitPriceColumn.ColumnName].Value = (long)unitPrice;     // 売価
                        }
                    }
                }
            }

            this.uGrid_Details.AfterCellUpdate += this.uGrid_Details_AfterCellUpdate;
        }

        /// <summary>
        /// グリッドセルKeyPress発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータクラス</param>
        /// <remarks>
        /// <br>Note        : グリッドセルKeyPress発生イベント</br>
        /// <br>Programmer  : 脇田 靖之</br>
        /// <br>Date        : 2015/02/20</br>
        /// </remarks>
        private void uGrid_Details_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.uGrid_Details.ActiveCell == null) return;
            UltraGridCell cell = this.uGrid_Details.ActiveCell;

            if (!cell.IsInEditMode) return;

            //----------------------------------------------
            // ActiveCellが得意先の場合
            //----------------------------------------------
            else if (cell.Column.Key == this._recBgnCustDataTable.CustomerCodeColumn.ColumnName)
            {
                if (!this.KeyPressNumCheck(8, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                {
                    e.Handled = true;
                    return;
                }
            }
            //----------------------------------------------
            // ActiveCellがお買得商品グループコードの場合
            //----------------------------------------------
            else if (cell.Column.Key == this._recBgnCustDataTable.BrgnGoodsGrpCodeColumn.ColumnName)
            {
                if (!this.KeyPressNumCheck(4, 0, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                {
                    e.Handled = true;
                    return;
                }
            }
            //----------------------------------------------
            // ActiveCellが売価率の場合
            //----------------------------------------------
            else if (cell.Column.Key == this._recBgnCustDataTable.UnitCalcRateColumn.ColumnName)
            {
                if (!this.KeyPressNumCheck(6, 2, cell.Text, e.KeyChar, cell.SelStart, cell.SelLength, false))
                {
                    e.Handled = true;
                    return;
                }
            }
        }

        #endregion

        #endregion

        /// <summary>
        /// お買得商品個別設定マスター＞明細行
        /// </summary>
        /// <param name="row">明細行</param>
        /// <param name="RecBgnGds">お買得商品設定マスタ</param>
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
            recBgnCust.InqOriginalEpCd = row.InqOriginalEpCd;      // 問合せ元企業コード
            recBgnCust.InqOriginalSecCd = row.InqOriginalSecCd;    // 問合せ元拠点コード
            recBgnCust.InqOtherEpCd = row.InqOtherEpCd;            // 問合せ先企業コード
            recBgnCust.InqOtherSecCd = row.InqOtherSecCd.ToString().PadLeft(2, '0');   // 問合せ先拠点コード
            if (row.CustomerCode.Trim() == string.Empty)            // 得意先コード
            {
                recBgnCust.CustomerCode = 0;
            }
            else
            {
                recBgnCust.CustomerCode = Convert.ToInt32(row.CustomerCode);
            }
            recBgnCust.MngSectionCode = row.MngSectionCode;         // 管理拠点コード
            recBgnCust.GoodsNo = row.GoodsNo;                       // 商品番号
            recBgnCust.GoodsMakerCd = row.GoodsMakerCode;           // 商品メーカーコード
            recBgnCust.GoodsApplyStaDate = row.GoodsApplyStaDate;   // 商品適用開始日
            recBgnCust.MkrSuggestRtPric = row.MkrSuggestRtPric;     // ﾒｰｶｰ希望小売価格
            recBgnCust.ListPrice = row.ListPrice;                   // 定価
            recBgnCust.UnitCalcRate = row.UnitCalcRate;             // 単価算出掛率
            recBgnCust.UnitPrice = row.UnitPrice;                   // 単価
            recBgnCust.BrgnGoodsGrpCode = row.BrgnGoodsGrpCode;     // お買得商品グループコード
            int startDate = 0;                                      // 公開開始日
            if (!row.ApplyStaDate.Replace("/", "").Equals(string.Empty)) startDate = int.Parse(row.ApplyStaDate.Replace("/", ""));
            recBgnCust.ApplyStaDate = startDate;
            int endDate = 0;                                        // 公開終了日
            if (!row.ApplyEndDate.Replace("/", "").Equals(string.Empty)) endDate = int.Parse(row.ApplyEndDate.Replace("/", ""));
            recBgnCust.ApplyEndDate = endDate;
            recBgnCust.RowIndex = row.RowNo;
        }
        
        /// <summary>
        /// 日付チェック処理
        /// </summary>
        /// <param name="sChkDate"></param>
        /// <returns></returns>
        private bool CheckDateValue(ref string sChkDate)
        {
            string cellValue = sChkDate;
            string nowString = DateTime.Now.Date.ToString("yyyyMMdd");
            int n = sChkDate.Length - sChkDate.Replace("/", "").Length;
            string format = "yyyy/M/d";

            // スラッシュなし
            switch (n)
            {
                case 0:
                    switch (sChkDate.Length)
                    {
                        case 1: // 日のみ入力
                            cellValue = nowString.Substring(0, 6) + "0" + cellValue;
                            cellValue = cellValue.Insert(4, "/");
                            cellValue = cellValue.Insert(7, "/");
                            break;
                        case 3: // 月・日のみ入力
                            cellValue = nowString.Substring(0, 4) + "0" + cellValue;
                            cellValue = cellValue.Insert(4, "/");
                            cellValue = cellValue.Insert(7, "/");
                            break;
                        case 0:
                        case 5:
                        case 7:
                            break;
                        default:
                            cellValue = nowString.Substring(0, 8 - cellValue.Length) + cellValue;
                            cellValue = cellValue.Insert(4, "/");
                            cellValue = cellValue.Insert(7, "/");
                            break;
                    }
                    break;
                case 1:
                    cellValue = nowString.Substring(0, 4) + cellValue;
                    cellValue = cellValue.Insert(4, "/");
                    break;

                case 2:
                    if (cellValue.Split('/')[0].Length < 3) format = "y/M/d";
                    break;
            }

            DateTime parseDate;
            if (!DateTime.TryParseExact(cellValue, format, null, DateTimeStyles.AllowLeadingWhite | DateTimeStyles.AllowTrailingWhite | DateTimeStyles.AllowInnerWhite, out parseDate))
            {
                return false;
            }
            sChkDate = parseDate.ToString("yyyy/MM/dd");
            return true;
        }

        #region Grid
        
        /// <summary>
        /// 画面初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note	   : 画面初期化処理します。</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        internal void Init(bool settingGrid)
        {
            
            // 明細データテーブル初期処理
            this.AcceptChangesRecBgnCustDataRow();

            // グリッド背景色初期化
            AllCellNoEdit(0);

            // グリッド行初期設定
            this.AddNewRow();

            // グリッド入力不可列背景色設定
            this.SetReadOnlyColumnSettings();

            if (settingGrid)
            {
                this.uGrid_Details.DisplayLayout.Bands[0].Columns[this._recBgnCustDataTable.UpdateTimeColumn.ColumnName].Hidden = true;
            }

        }

        /// <summary>
        /// 個別設定データをコミットする
        /// </summary>
        /// <remarks>RowStateをすべてUnchangedにする</remarks>
        private void AcceptChangesRecBgnCustDataRow()
        {
            int rowNo = 0;
            foreach (RecBgnGdsDataSet.RecBgnCustRow row in this._recBgnCustDataTable)
            {
                rowNo++;
                row.RowNo = rowNo;
            }
        }

        /// <summary>
        /// 最終入力行を削除する
        /// </summary>
        /// <remarks></remarks>
        public RecBgnGdsDataSet.RecBgnCustDataTable GetResultRecBgnCust()
        {

            DataRow[] rows = this._recBgnCustDataTable.Select("RowDevelopFlg = 0");
            for (int i = 0; i < rows.Length; i++)
            {
                if (rows[i].RowState != DataRowState.Deleted)
                {
                    rows[i].Delete();
                }
            }
            this._recBgnCustDataTable.AcceptChanges();

            return this._recBgnCustDataTable;

        }

        /// <summary>
        /// グリッド明細部初期化処理
        /// </summary>
        /// <remarks>
        /// <br>Note	   : 明細部初期化処理します。</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private void InitialSettingGridCol()
        {
            Infragistics.Win.UltraWinGrid.UltraGridBand editBand = this.uGrid_Details.DisplayLayout.Bands[0];
            if (editBand == null) return;

            foreach (Infragistics.Win.UltraWinGrid.UltraGridColumn col in editBand.Columns)
            {
                // 全ての列をいったん非表示にする。
                col.Hidden = true;
                col.Header.Fixed = false;

                // 「No列」以外の全てのセルのDiabledColorを設定する。
                if (col.Key != this._recBgnCustDataTable.RowNoColumn.ColumnName)
                {
                    col.CellAppearance.BackColorDisabled = ct_DISABLE_COLOR;
                    col.CellAppearance.ForeColorDisabled = ct_DISABLE_FONT_COLOR;
                }
            }

            #region ●表示幅設定
            editBand.Columns[this._recBgnCustDataTable.RowNoColumn.ColumnName].Width = 40;		        // №
            editBand.Columns[this._recBgnCustDataTable.UpdateTimeColumn.ColumnName].Width = 80;		    // 削除日
            //------------------------------------------------------------------------------------------------------
            editBand.Columns[this._recBgnCustDataTable.CustomerCodeColumn.ColumnName].Width = 65;		// 得意先
            editBand.Columns[this._recBgnCustDataTable.CustomerNameColumn.ColumnName].Width = 100;		// 得意先名
            editBand.Columns[this._recBgnCustDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Width = 65;	// お買得商品グループコード
            editBand.Columns[this._recBgnCustDataTable.BrgnGoodsGrpNameColumn.ColumnName].Width = 100;	// お買得商品グループ名
            editBand.Columns[this._recBgnCustDataTable.DisplayDivCodeColumn.ColumnName].Width = 50;		// 表示区分
            editBand.Columns[this._recBgnCustDataTable.ApplyStaDateColumn.ColumnName].Width = 75;		// 公開開始日
            editBand.Columns[this._recBgnCustDataTable.ApplyEndDateColumn.ColumnName].Width = 75;		// 公開終了日
            editBand.Columns[this._recBgnCustDataTable.MkrSuggestRtPricColumn.ColumnName].Width = 130;  // ﾒｰｶｰ希望小売価格
            editBand.Columns[this._recBgnCustDataTable.ListPriceColumn.ColumnName].Width = 130;			// 標準価格
            editBand.Columns[this._recBgnCustDataTable.UnitCalcRateColumn.ColumnName].Width = 50;		// 単価算出掛率
            editBand.Columns[this._recBgnCustDataTable.UnitPriceColumn.ColumnName].Width = 130;			// 売単価
            #endregion

            #region ●固定列設定
            //editBand.Columns[this._recBgnCustDataTable.RowNoColumn.ColumnName].Header.Fixed = true;		            // №
            //editBand.Columns[this._recBgnCustDataTable.RowNoColumn.ColumnName].Header.FixedHeaderIndicator = FixedHeaderIndicator.None;		            // №
            editBand.Columns[this._recBgnCustDataTable.RowNoColumn.ColumnName].Header.Fixed = false;	// №
            #endregion

            #region ●CellAppearance設定
            editBand.Columns[this._recBgnCustDataTable.RowNoColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;               // №
            editBand.Columns[this._recBgnCustDataTable.UpdateTimeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;			// 削除日
            editBand.Columns[this._recBgnCustDataTable.CustomerCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;		// 得意先
            editBand.Columns[this._recBgnCustDataTable.CustomerNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;		    // 得意名
            editBand.Columns[this._recBgnCustDataTable.BrgnGoodsGrpCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;	// お買得商品グループコード
            editBand.Columns[this._recBgnCustDataTable.BrgnGoodsGrpNameColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;		// お買得商品グループコード名
            editBand.Columns[this._recBgnCustDataTable.DisplayDivCodeColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;		// 表示区分
            editBand.Columns[this._recBgnCustDataTable.ApplyStaDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;			// 公開開始日
            editBand.Columns[this._recBgnCustDataTable.ApplyEndDateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;			// 公開終了日
            editBand.Columns[this._recBgnCustDataTable.MkrSuggestRtPricColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;    // ﾒｰｶｰ希望小売価格
            editBand.Columns[this._recBgnCustDataTable.ListPriceColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;           // 標準価格
            editBand.Columns[this._recBgnCustDataTable.UnitCalcRateColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;		// 売価率
            editBand.Columns[this._recBgnCustDataTable.UnitPriceColumn.ColumnName].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;			// 売単価

            editBand.Columns[this._recBgnCustDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor;
            editBand.Columns[this._recBgnCustDataTable.RowNoColumn.ColumnName].CellAppearance.BackColor2 = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackColor2;
            //editBand.Columns[this._recBgnCustDataTable.RowNoColumn.ColumnName].CellAppearance.BackGradientStyle = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.BackGradientStyle;
            editBand.Columns[this._recBgnCustDataTable.RowNoColumn.ColumnName].CellAppearance.BackGradientStyle = GradientStyle.Vertical;
            //editBand.Columns[this._recBgnCustDataTable.RowNoColumn.ColumnName].CellAppearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
            editBand.Columns[this._recBgnCustDataTable.RowNoColumn.ColumnName].CellAppearance.ForeColor = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.ForeColor;
            //editBand.Columns[this._recBgnCustDataTable.RowNoColumn.ColumnName].CellAppearance.ForeColorDisabled = this.uGrid_Details.DisplayLayout.Override.HeaderAppearance.ForeColor;
            #endregion

            #region ●入力許可設定
            //editBand.Columns[this._recBgnCustDataTable.RowNoColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.Disabled;		        // №
            editBand.Columns[this._recBgnCustDataTable.RowNoColumn.ColumnName].CellActivation = Activation.NoEdit;
            editBand.Columns[this._recBgnCustDataTable.UpdateTimeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;			// 削除日
            editBand.Columns[this._recBgnCustDataTable.CustomerCodeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit; 		// 得意先
            editBand.Columns[this._recBgnCustDataTable.CustomerNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;         // 得意先名
            editBand.Columns[this._recBgnCustDataTable.BrgnGoodsGrpCodeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit; 	// お買得商品グループコード
            editBand.Columns[this._recBgnCustDataTable.BrgnGoodsGrpNameColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;     // お買得商品グループ名
            editBand.Columns[this._recBgnCustDataTable.DisplayDivCodeColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;    // 表示区分
            editBand.Columns[this._recBgnCustDataTable.ApplyStaDateColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit; 		// 公開開始日
            editBand.Columns[this._recBgnCustDataTable.ApplyEndDateColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit; 		// 公開終了日
            editBand.Columns[this._recBgnCustDataTable.MkrSuggestRtPricColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;     // ﾒｰｶｰ希望小売価格
            editBand.Columns[this._recBgnCustDataTable.ListPriceColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;            // 標準価格
            editBand.Columns[this._recBgnCustDataTable.UnitCalcRateColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit; 		// 売価率
            editBand.Columns[this._recBgnCustDataTable.UnitPriceColumn.ColumnName].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit; 		// 売単価
            #endregion

            #region ●Style設定
            editBand.Columns[this._recBgnCustDataTable.UpdateTimeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;        // 削除日
            editBand.Columns[this._recBgnCustDataTable.CustomerCodeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;      // 得意先
            editBand.Columns[this._recBgnCustDataTable.CustomerNameColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;      // 得意先名
            editBand.Columns[this._recBgnCustDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;  // お買得商品グループコード
            editBand.Columns[this._recBgnCustDataTable.BrgnGoodsGrpNameColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;  // お買得商品グループ名
            editBand.Columns[this._recBgnCustDataTable.DisplayDivCodeColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;// 表示区分
            editBand.Columns[this._recBgnCustDataTable.ApplyStaDateColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;      // 公開開始日
            editBand.Columns[this._recBgnCustDataTable.ApplyEndDateColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;      // 公開終了日
            editBand.Columns[this._recBgnCustDataTable.MkrSuggestRtPricColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;  // ﾒｰｶｰ希望小売価格
            editBand.Columns[this._recBgnCustDataTable.ListPriceColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;         // 標準価格
            editBand.Columns[this._recBgnCustDataTable.UnitCalcRateColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;      // 単価算出掛率
            editBand.Columns[this._recBgnCustDataTable.UnitCalcRateColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;      // 売価率
            editBand.Columns[this._recBgnCustDataTable.UnitPriceColumn.ColumnName].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;         // 売単価
            #endregion

            #region ●フォーマット設定
            string decimalFormat = "#,##0;-#,##0;''";
            string doubleFormat = "##0.#0;-##0.#0;''";
            string codeFormat2 = "#0;-#0;''";
            string codeFormat3 = "#00000000;-#00000000;''";

            editBand.Columns[this._recBgnCustDataTable.CustomerCodeColumn.ColumnName].Format = codeFormat3;		    // 得意先
            editBand.Columns[this._recBgnCustDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Format = codeFormat2;		// お買得商品グループコード
            editBand.Columns[this._recBgnCustDataTable.MkrSuggestRtPricColumn.ColumnName].Format = decimalFormat;	// ﾒｰｶｰ希望小売価格
            editBand.Columns[this._recBgnCustDataTable.ListPriceColumn.ColumnName].Format = decimalFormat;			// 標準価格
            editBand.Columns[this._recBgnCustDataTable.UnitCalcRateColumn.ColumnName].Format = doubleFormat;		// 売価率
            editBand.Columns[this._recBgnCustDataTable.UnitPriceColumn.ColumnName].Format = decimalFormat;			// 売単価
            #endregion

            #region ●MaxLength設定
            editBand.Columns[this._recBgnCustDataTable.CustomerCodeColumn.ColumnName].MaxLength = 8;		        // 得意先
            editBand.Columns[this._recBgnCustDataTable.BrgnGoodsGrpCodeColumn.ColumnName].MaxLength = 4;		    // お買得商品グループコード
            editBand.Columns[this._recBgnCustDataTable.ApplyStaDateColumn.ColumnName].MaxLength = 10;		        // 公開開始日
            editBand.Columns[this._recBgnCustDataTable.ApplyEndDateColumn.ColumnName].MaxLength = 10;               // 公開終了日
            editBand.Columns[this._recBgnCustDataTable.UnitCalcRateColumn.ColumnName].MaxLength = 6;                // 売価率
            // --- UPD 2015/03/09 Y.Wakita Redmine#351 ---------->>>>>
            //editBand.Columns[this._recBgnCustDataTable.UnitPriceColumn.ColumnName].MaxLength = 17;			        // 売単価 
            editBand.Columns[this._recBgnCustDataTable.UnitPriceColumn.ColumnName].MaxLength = 7;			        // 売単価 
            // --- UPD 2015/03/09 Y.Wakita Redmine#351 ----------<<<<<
            #endregion

            #region ●グリッド列表示非表示設定処理
            editBand.Columns[this._recBgnCustDataTable.RowNoColumn.ColumnName].Hidden = false;		        // №
            editBand.Columns[this._recBgnCustDataTable.UpdateTimeColumn.ColumnName].Hidden = true;		    // 削除日
            editBand.Columns[this._recBgnCustDataTable.GoodsMakerCodeColumn.ColumnName].Hidden = true;		// ﾒｰｶｰ
            editBand.Columns[this._recBgnCustDataTable.GoodsNoColumn.ColumnName].Hidden = true;	            // 品番
            editBand.Columns[this._recBgnCustDataTable.GoodsApplyStaDateColumn.ColumnName].Hidden = true;	// 商品適用開始日
            editBand.Columns[this._recBgnCustDataTable.CustomerCodeColumn.ColumnName].Hidden = false;		// 得意先
            editBand.Columns[this._recBgnCustDataTable.CustomerNameColumn.ColumnName].Hidden = false;		// 得意先名
            editBand.Columns[this._recBgnCustDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Hidden = false;	// お買得商品グループコード
            editBand.Columns[this._recBgnCustDataTable.BrgnGoodsGrpNameColumn.ColumnName].Hidden = false;	// お買得商品グループ名
            editBand.Columns[this._recBgnCustDataTable.DisplayDivCodeColumn.ColumnName].Hidden = false;		// 表示区分
            editBand.Columns[this._recBgnCustDataTable.ApplyStaDateColumn.ColumnName].Hidden = false;		// 公開開始日
            editBand.Columns[this._recBgnCustDataTable.ApplyEndDateColumn.ColumnName].Hidden = false;		// 公開終了日
            editBand.Columns[this._recBgnCustDataTable.MkrSuggestRtPricColumn.ColumnName].Hidden = false;   // ﾒｰｶｰ希望小売価格
            editBand.Columns[this._recBgnCustDataTable.ListPriceColumn.ColumnName].Hidden = false;			// 標準価格
            editBand.Columns[this._recBgnCustDataTable.UnitCalcRateColumn.ColumnName].Hidden = false;       // 単価算出掛率
            editBand.Columns[this._recBgnCustDataTable.UnitPriceColumn.ColumnName].Hidden = false;			// 売単価
            #endregion

            #region ●グリッド列ソート設定処理
            editBand.Columns[this._recBgnCustDataTable.RowNoColumn.ColumnName].SortIndicator = SortIndicator.Disabled;              // №
            editBand.Columns[this._recBgnCustDataTable.UpdateTimeColumn.ColumnName].SortIndicator = SortIndicator.Disabled;         // 削除日
            editBand.Columns[this._recBgnCustDataTable.CustomerCodeColumn.ColumnName].SortIndicator = SortIndicator.Disabled;		// 得意先
            editBand.Columns[this._recBgnCustDataTable.CustomerNameColumn.ColumnName].SortIndicator = SortIndicator.Disabled;		// 得意先名
            editBand.Columns[this._recBgnCustDataTable.BrgnGoodsGrpCodeColumn.ColumnName].SortIndicator = SortIndicator.Disabled;	// お買得商品グループコード
            editBand.Columns[this._recBgnCustDataTable.BrgnGoodsGrpNameColumn.ColumnName].SortIndicator = SortIndicator.Disabled;	// お買得商品グループ名
            editBand.Columns[this._recBgnCustDataTable.DisplayDivCodeColumn.ColumnName].SortIndicator = SortIndicator.Disabled;		// 表示区分
            editBand.Columns[this._recBgnCustDataTable.ApplyStaDateColumn.ColumnName].SortIndicator = SortIndicator.Disabled;		// 公開開始日
            editBand.Columns[this._recBgnCustDataTable.ApplyEndDateColumn.ColumnName].SortIndicator = SortIndicator.Disabled;		// 公開終了日
            editBand.Columns[this._recBgnCustDataTable.MkrSuggestRtPricColumn.ColumnName].SortIndicator = SortIndicator.Disabled;   // ﾒｰｶｰ希望小売価格
            editBand.Columns[this._recBgnCustDataTable.ListPriceColumn.ColumnName].SortIndicator = SortIndicator.Disabled;			// 標準価格
            editBand.Columns[this._recBgnCustDataTable.UnitCalcRateColumn.ColumnName].SortIndicator = SortIndicator.Disabled;		// 売価率
            editBand.Columns[this._recBgnCustDataTable.UnitPriceColumn.ColumnName].SortIndicator = SortIndicator.Disabled;			// 売単価
            #endregion

            try
            {
                this.uGrid_Details.BeginUpdate();
                ColumnsCollection columns = this.uGrid_Details.DisplayLayout.Bands[0].Columns;

                # region [セル結合設定]
                List<string> colNameList = new List<string>(new string[] 
                                            { 
                                                this._recBgnCustDataTable.UpdateTimeColumn.ColumnName,
                                                this._recBgnCustDataTable.CustomerCodeColumn.ColumnName,
                                                this._recBgnCustDataTable.CustomerNameColumn.ColumnName,
                                                this._recBgnCustDataTable.BrgnGoodsGrpCodeColumn.ColumnName,
                                                this._recBgnCustDataTable.BrgnGoodsGrpNameColumn.ColumnName,
                                                this._recBgnCustDataTable.MkrSuggestRtPricColumn.ColumnName,
                                                this._recBgnCustDataTable.ListPriceColumn.ColumnName,
                                            });
                Infragistics.Win.Appearance margedCellAppearance = new Infragistics.Win.Appearance();

                for (int index = 0; index < colNameList.Count; index++)
                {
                    string colName = colNameList[index];

                    // CellAppearanceを強制的に統一する（行№は除く）
                    if (!columns[colName].Key.Trim().Equals(this._recBgnCustDataTable.RowNoColumn.ColumnName.Trim()))
                    {
                        columns[colName].MergedCellAppearance = margedCellAppearance;
                        columns[colName].CellAppearance.TextVAlign = VAlign.Top;
                    }
                    // セル結合設定
                    columns[colName].MergedCellStyle = Infragistics.Win.UltraWinGrid.MergedCellStyle.Always;
                    columns[colName].MergedCellEvaluationType = Infragistics.Win.UltraWinGrid.MergedCellEvaluationType.MergeSameValue;
                    columns[colName].MergedCellContentArea = Infragistics.Win.UltraWinGrid.MergedCellContentArea.VisibleRect;
                }

                // セル結合設定詳細（親列を判定に含める）
                // 得意先
                columns[this._recBgnCustDataTable.CustomerCodeColumn.ColumnName].MergedCellEvaluator
                    = new CustomMergedCellEvaluator(this._recBgnCustDataTable.CustomerCodeColumn.ColumnName);

                // 得意先名：得意先 | 得意先名
                columns[this._recBgnCustDataTable.CustomerNameColumn.ColumnName].MergedCellEvaluator
                    = new CustomMergedCellEvaluator(this._recBgnCustDataTable.CustomerCodeColumn.ColumnName,
                                                    this._recBgnCustDataTable.CustomerNameColumn.ColumnName);

                // ｸﾞﾙｰﾌﾟ  ：得意先 | 得意先名 | ｸﾞﾙｰﾌﾟ
                columns[this._recBgnCustDataTable.BrgnGoodsGrpCodeColumn.ColumnName].MergedCellEvaluator
                    = new CustomMergedCellEvaluator(this._recBgnCustDataTable.CustomerCodeColumn.ColumnName,
                                                    this._recBgnCustDataTable.CustomerNameColumn.ColumnName,
                                                    this._recBgnCustDataTable.BrgnGoodsGrpCodeColumn.ColumnName);

                // ｸﾞﾙｰﾌﾟ名：得意先名 | ｸﾞﾙｰﾌﾟ | ｸﾞﾙｰﾌﾟ名
                columns[this._recBgnCustDataTable.BrgnGoodsGrpNameColumn.ColumnName].MergedCellEvaluator
                    = new CustomMergedCellEvaluator(this._recBgnCustDataTable.CustomerCodeColumn.ColumnName,
                                                    this._recBgnCustDataTable.CustomerNameColumn.ColumnName,
                                                    this._recBgnCustDataTable.BrgnGoodsGrpCodeColumn.ColumnName,
                                                    this._recBgnCustDataTable.BrgnGoodsGrpNameColumn.ColumnName);

                // ﾒｰｶｰ価格：得意先 | 得意先名 | ﾒｰｶｰ価格
                columns[this._recBgnCustDataTable.MkrSuggestRtPricColumn.ColumnName].MergedCellEvaluator
                    = new CustomMergedCellEvaluator(this._recBgnCustDataTable.CustomerCodeColumn.ColumnName,
                                                    this._recBgnCustDataTable.CustomerNameColumn.ColumnName,
                                                    this._recBgnCustDataTable.MkrSuggestRtPricColumn.ColumnName);

                // 標準価格：得意先 | 得意先名 | 標準価格
                columns[this._recBgnCustDataTable.ListPriceColumn.ColumnName].MergedCellEvaluator
                    = new CustomMergedCellEvaluator(this._recBgnCustDataTable.CustomerCodeColumn.ColumnName,
                                                    this._recBgnCustDataTable.CustomerNameColumn.ColumnName,
                                                    this._recBgnCustDataTable.ListPriceColumn.ColumnName);

                # endregion
            }
            finally
            {
                this.uGrid_Details.EndUpdate();
            }
        }

        /// <summary>
        /// お買得商品個別設定マスタ DataTableに新規行を追加する
        /// </summary>
        private void AddNewRow()
        {

            this._recBgnCustDataTable.BeginLoadData();
            RecBgnGdsDataSet.RecBgnCustRow newRow = this._recBgnCustDataTable.NewRecBgnCustRow();

            // 既定値設定
            newRow.RowNo = this.uGrid_Details.Rows.Count + 1;
            newRow.FilterGuid = Guid.Empty;
            newRow.UpdateTime = DateTime.MinValue.ToString("yy/MM/dd");

            newRow.InqOtherEpCd = this._recBgnGdsRow.InqOtherEpCd;              // 問合せ先企業コード
            newRow.InqOtherSecCd = this._recBgnGdsRow.InqOtherSecCd;            // 問合せ先拠点コード
            newRow.GoodsNo = this._recBgnGdsRow.GoodsNo;                        // 商品番号
            newRow.GoodsMakerCode = this._recBgnGdsRow.GoodsMakerCode;          // 商品メーカーコード
            newRow.GoodsApplyStaDate = (int.Parse(this._swGoodsUnitData.OfferDate.ToString("yyyyMMdd")));   // 商品適用開始日
            newRow.DisplayDivCode = 1;                                                                   // 表示区分
            newRow.UnitCalcRate = 0;
            newRow.UnitPrice = 0;
            newRow.MkrSuggestRtPric = 0;

            // 行追加
            this._recBgnCustDataTable.AddRecBgnCustRow(newRow);
            this._recBgnCustDataTable.EndLoadData();

            // 背景色
            SetReadOnlyColumnSettings();

            uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._recBgnCustDataTable.CustomerCodeColumn.ColumnName].Activation = Activation.AllowEdit;
            uGrid_Details.Rows[this.uGrid_Details.Rows.Count - 1].Cells[this._recBgnCustDataTable.CustomerCodeColumn.ColumnName].Activate();
            this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
            this._recBgnCustDataTable.AcceptChanges();

        }

        /// <summary>
        /// グリッドカラム情報の読み込み
        /// </summary>
        /// <param name="targetGrid"></param>
        /// <param name="settingList"></param>
        private void LoadGridColumnsSetting(ref Infragistics.Win.UltraWinGrid.UltraGrid targetGrid, List<ColumnInfo> settingList)
        {
            if (settingList == null || settingList.Count == 0) return;

            targetGrid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.None;
            foreach (ColumnInfo columnInfo in settingList)
            {
                try
                {
                    Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn = targetGrid.DisplayLayout.Bands[0].Columns[columnInfo.ColumnName];
                    ultraGridColumn.Width = columnInfo.Width;
                }
                catch
                {
                }
            }
        }

        /// <summary>
        /// グリッド列不可入力色設定
        /// </summary>
        /// <remarks>
        /// <br>Note	   : グリッド列不可入力色設定します。</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        internal void SetReadOnlyColumnSettings()
        {
            // 明細無の場合は何もしない
            if (this.uGrid_Details == null || this.uGrid_Details.Rows.Count < 1) return;

            // 得意先名・お買得商品グループ名・公開開始日・公開終了日・ﾒｰｶｰ希望小売価格・標準価格に設定
            UltraGridRow row = this.uGrid_Details.Rows[this.uGrid_Details.Rows.Count-1];
            foreach (UltraGridCell cell in row.Cells)
            {
                if (cell.Column.Key == this._recBgnCustDataTable.CustomerNameColumn.ColumnName
                 || cell.Column.Key == this._recBgnCustDataTable.BrgnGoodsGrpNameColumn.ColumnName
                 || cell.Column.Key == this._recBgnCustDataTable.ApplyStaDateColumn.ColumnName
                 || cell.Column.Key == this._recBgnCustDataTable.ApplyEndDateColumn.ColumnName
                 || cell.Column.Key == this._recBgnCustDataTable.MkrSuggestRtPricColumn.ColumnName
                 || cell.Column.Key == this._recBgnCustDataTable.ListPriceColumn.ColumnName)
                {
                    cell.Activation = Activation.NoEdit;
                    cell.Appearance.BackColor = ct_READONLY_CELL_COLOR;
                }
            }
        }


        /// <summary>
        /// グリッド 全項目入力不可能セル設定処理
        /// </summary>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private void AllCellNoEdit(int mode)
        {
            foreach (UltraGridRow row in this.uGrid_Details.Rows)
            {
                if (mode == 1)
                {
                    if ((Guid)row.Cells[this._recBgnCustDataTable.FilterGuidColumn.ColumnName].Value == Guid.Empty)
                    {
                        continue;
                    }
                }
                foreach (UltraGridCell cell in row.Cells)
                {
                    if (cell.Column.Key != this._recBgnCustDataTable.RowNoColumn.ColumnName)
                    {
                        // 行番号以外を非活性
                        cell.Appearance.BackColor = ct_DISABLE_COLOR;
                        cell.Appearance.BackColor2 = ct_DISABLE_COLOR;
                        cell.Activation = Activation.NoEdit;

                        // 表示区分は常に活性
                        if (cell.Column.Key == this._recBgnCustDataTable.DisplayDivCodeColumn.ColumnName)
                        {
                            cell.Activation = Activation.AllowEdit;
                            cell.Appearance.BackColor = Color.Empty;
                            cell.Appearance.BackColor2 = Color.Empty;
                            cell.Appearance.BackColorDisabled = Color.Empty;
                            cell.Appearance.BackColorDisabled2 = Color.Empty;
                        }
                        // お買得商品グループコード・売価率・売単価は表示区分が「公開する」場合に活性
                        else if (cell.Column.Key == this._recBgnCustDataTable.DisplayDivCodeColumn.ColumnName
                            || cell.Column.Key == this._recBgnCustDataTable.BrgnGoodsGrpCodeColumn.ColumnName
                            || cell.Column.Key == this._recBgnCustDataTable.UnitCalcRateColumn.ColumnName
                            || cell.Column.Key == this._recBgnCustDataTable.UnitPriceColumn.ColumnName)
                        {
                            if (row.Cells[this._recBgnCustDataTable.DisplayDivCodeColumn.ColumnName].Text != "0")
                            {
                                cell.Activation = Activation.AllowEdit;
                                cell.Appearance.BackColor = Color.Empty;
                                cell.Appearance.BackColor2 = Color.Empty;
                                cell.Appearance.BackColorDisabled = Color.Empty;
                                cell.Appearance.BackColorDisabled2 = Color.Empty;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// グリッド Nextフォーカス取得処理
        /// </summary>
        /// <param name="mode">モード(0:Tab;1;Shift + Tab)</param>
        /// <param name="rowIndex">行番号</param>
        /// <param name="columnKey">columnKey</param>
        /// <returns>columnIndex</returns>
        /// <remarks>
        /// <br>Note        : グリッドNextフォーカス取得を行います。</br>
        /// <br>Programmer  : 脇田 靖之</br>
        /// <br>Date        : 2015/02/20</br>
        /// </remarks>
        private int GetNextColumnIndexByTab(int mode, int rowIndex, string columnKey)
        {
            int columnIndex = -1;
            switch (mode)
            {
                case 0:
                    #region Tab

                    // 得意先
                    if (columnKey == this._recBgnCustDataTable.CustomerCodeColumn.ColumnName)
                    {
                        // 得意先名
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnCustDataTable.CustomerNameColumn.ColumnName].Column.Index;
                    }
                    // 得意先名
                    else if (columnKey == this._recBgnCustDataTable.CustomerNameColumn.ColumnName)
                    {
                        // 公開開始日
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnCustDataTable.ApplyStaDateColumn.ColumnName].Column.Index;
                    }
                    // 公開開始日
                    else if (columnKey == this._recBgnCustDataTable.ApplyStaDateColumn.ColumnName)
                    {
                        // 公開終了日
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnCustDataTable.ApplyEndDateColumn.ColumnName].Column.Index;
                    }
                    // 公開終了日
                    else if (columnKey == this._recBgnCustDataTable.ApplyEndDateColumn.ColumnName)
                    {
                        // 公開区分
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnCustDataTable.DisplayDivCodeColumn.ColumnName].Column.Index;
                    }
                    // 公開区分
                    else if (columnKey == this._recBgnCustDataTable.DisplayDivCodeColumn.ColumnName)
                    {
                        // お買得商品グループコード
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnCustDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Column.Index;
                    }
                    // お買得商品グループコード
                    else if (columnKey == this._recBgnCustDataTable.BrgnGoodsGrpCodeColumn.ColumnName)
                    {
                        // お買得商品グループ名
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnCustDataTable.BrgnGoodsGrpNameColumn.ColumnName].Column.Index;
                    }
                    // お買得商品グループ名
                    else if (columnKey == this._recBgnCustDataTable.BrgnGoodsGrpNameColumn.ColumnName)
                    {
                        // ﾒｰｶｰ希望小売価格
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnCustDataTable.MkrSuggestRtPricColumn.ColumnName].Column.Index;
                    }
                    // ﾒｰｶｰ希望小売価格
                    else if (columnKey == this._recBgnCustDataTable.MkrSuggestRtPricColumn.ColumnName)
                    {
                        // 標準価格
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnCustDataTable.ListPriceColumn.ColumnName].Column.Index;
                    }
                    // 標準価格
                    else if (columnKey == this._recBgnCustDataTable.ListPriceColumn.ColumnName)
                    {
                        // 売価率
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnCustDataTable.UnitCalcRateColumn.ColumnName].Column.Index;
                    }
                    // 売価率
                    else if (columnKey == this._recBgnCustDataTable.UnitCalcRateColumn.ColumnName)
                    {
                        // 単価算出掛率
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnCustDataTable.UnitPriceColumn.ColumnName].Column.Index;
                    }
                    // 単価算出掛率
                    else if (columnKey == this._recBgnCustDataTable.UnitPriceColumn.ColumnName)
                    {
                        columnIndex = -1;
                    }
                    
                    
                    break;
                    #endregion Tab
                case 1:
                    #region Shift + Tab

                    // 得意先
                    if (columnKey == this._recBgnCustDataTable.CustomerCodeColumn.ColumnName)
                    {
                        columnIndex = -1;
                    }
                    // 得意先名
                    else if (columnKey == this._recBgnCustDataTable.CustomerNameColumn.ColumnName)
                    {
                        // 得意先コード
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnCustDataTable.CustomerCodeColumn.ColumnName].Column.Index;
                    }
                    // 公開開始日
                    else if (columnKey == this._recBgnCustDataTable.ApplyStaDateColumn.ColumnName)
                    {
                        // 得意名
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnCustDataTable.CustomerNameColumn.ColumnName].Column.Index;
                    }
                    // 公開終了日
                    else if (columnKey == this._recBgnCustDataTable.ApplyEndDateColumn.ColumnName)
                    {
                        // 公開開始日
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnCustDataTable.ApplyStaDateColumn.ColumnName].Column.Index;
                    }
                    // 公開区分
                    else if (columnKey == this._recBgnCustDataTable.DisplayDivCodeColumn.ColumnName)
                    {
                        // 公開終了日
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnCustDataTable.ApplyEndDateColumn.ColumnName].Column.Index;
                    }
                    // お買得商品グループコード
                    else if (columnKey == this._recBgnCustDataTable.BrgnGoodsGrpCodeColumn.ColumnName)
                    {
                        // 公開区分
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnCustDataTable.DisplayDivCodeColumn.ColumnName].Column.Index;
                    }
                    // お買得商品グループ名
                    else if (columnKey == this._recBgnCustDataTable.BrgnGoodsGrpNameColumn.ColumnName)
                    {
                        // お買得商品グループコード
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnCustDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Column.Index;
                    }
                    // ﾒｰｶｰ希望小売価格
                    else if (columnKey == this._recBgnCustDataTable.MkrSuggestRtPricColumn.ColumnName)
                    {
                        // お買得商品グループ名
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnCustDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Column.Index;
                    }
                    // 標準価格
                    else if (columnKey == this._recBgnCustDataTable.ListPriceColumn.ColumnName)
                    {
                        // ﾒｰｶｰ希望小売価格
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnCustDataTable.MkrSuggestRtPricColumn.ColumnName].Column.Index;
                    }
                    // 単価算出掛率
                    else if (columnKey == this._recBgnCustDataTable.UnitCalcRateColumn.ColumnName)
                    {
                        // 標準価格
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnCustDataTable.ListPriceColumn.ColumnName].Column.Index;
                    }
                    // 単価
                    else if (columnKey == this._recBgnCustDataTable.UnitPriceColumn.ColumnName)
                    {
                        // 単価算出掛率
                        columnIndex = this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnCustDataTable.UnitCalcRateColumn.ColumnName].Column.Index;
                    }


                    break;
                    #endregion Shift + Tab
            }

            return columnIndex;
        }
        
        /// <summary>
        /// グリッド 次入力可能セル移動処理
        /// </summary>
        /// <param name="activeCellCheck">true:ActiveCellが入力可能の場合はNextに移動させない false:ActiveCellに関係なくNextに移動させる</param>
        /// <returns>true:セル移動完了 false:セル移動失敗</returns>
        /// <remarks>
        /// <br>Note       : 次入力可能セル移動処理を行います。</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private bool MoveNextAllowEditCell(bool isActiveCellStop)
        {
            bool isMoved = false;   // 移動状態
            bool isResult = false;  // PerformActionResult

            try
            {
                int rowIndex = this.uGrid_Details.ActiveCell.Row.Index;

                // 更新開始（描画ストップ）
                this.uGrid_Details.BeginUpdate();

                // ActiveCellが入力可能の場合はNextに移動させない
                if ((isActiveCellStop) && (this.uGrid_Details.ActiveCell != null))
                {
                    if ((!this.uGrid_Details.ActiveCell.Column.Hidden) &&
                        (this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                        (this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                    {
                        isMoved = true;
                    }
                }

                // Nextに移動させる
                while (!isMoved)
                {
                    if (this.uGrid_Details.ActiveRow.Index == this._recBgnCustDataTable.Count - 1)
                    {
                        
                        if (this.uGrid_Details.ActiveCell == null) break;

                        // 得意先
                        if (this._recBgnCustDataTable.CustomerCodeColumn.ColumnName.Equals(this.uGrid_Details.ActiveCell.Column.Key))
                        {
                            // 明細展開処理
                            if (this.BgnDataDeployment() == true)
                            {
                                this.AddNewRow();
                                isMoved = true;

                                this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnCustDataTable.DisplayDivCodeColumn.ColumnName].Activation = Activation.AllowEdit;
                                this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnCustDataTable.DisplayDivCodeColumn.ColumnName].Activate();
                                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                            }
                            else
                            {
                                this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                                break;
                            }
                            return true;
                        }
                    }

                    isResult = this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell);
                    if (isResult)
                    {
                        if ((this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                            (this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                        {
                            isMoved = true;
                        }
                        else
                        {
                            isMoved = false;
                        }
                    }
                    else
                    {
                        break;
                    }
                }

                // 移動後のセル設定
                if (isMoved)
                {
                    // Activeセルを編集モードにする
                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                }
            }
            finally
            {
                // 更新終了（描画再開）
                this.uGrid_Details.EndUpdate();
            }

            return isResult;
        }

        /// <summary>
        /// グリッド 前入力可能セル移動処理
        /// </summary>
        /// <param name="isActiveCellStop">true:ActiveCellが入力可能の場合はNextに移動させない false:ActiveCellに関係なくNextに移動させる</param>
        /// <returns>true:セル移動完了 false:セル移動失敗</returns>
        /// <remarks>
        /// <br>Note       : 前入力可能セル移動処理を行います。</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private bool MovePreAllowEditCell(bool isActiveCellStop)
        {
            bool isMoved = false;   // 移動状態
            bool isResult = false;  // PerformActionResult

            try
            {
                // 更新開始（描画ストップ）
                this.uGrid_Details.BeginUpdate();

                // ActiveCellが入力可能の場合はNextに移動させない
                if ((isActiveCellStop) && (this.uGrid_Details.ActiveCell != null))
                {
                    if ((!this.uGrid_Details.ActiveCell.Column.Hidden) &&
                        (this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                        (this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                    {
                        isMoved = true;
                    }
                }

                // Nextに移動させる
                while (!isMoved)
                {
                    isResult = this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCell);

                    if (isResult)
                    {
                        if ((this.uGrid_Details.ActiveCell.Activation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit) &&
                            (this.uGrid_Details.ActiveCell.Column.CellActivation == Infragistics.Win.UltraWinGrid.Activation.AllowEdit))
                        {
                            isMoved = true;
                        }
                        else
                        {
                            isMoved = false;
                        }
                    }
                    else
                    {
                        break;
                    }
                }

                // 移動後のセル設定
                if (isMoved)
                {
                    // Activeセルを編集モードにする
                    this.uGrid_Details.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                }
            }
            finally
            {
                // 更新終了（描画再開）
                this.uGrid_Details.EndUpdate();
            }

            return isResult;
        }
        #endregion

        #region ガイド


        /// <summary>
        /// お買得商品グループガイド起動
        /// </summary>
        /// <param name="rowIndex">行番号</param>
        /// <remarks>
        /// <br>Note	   : お買得商品グループガイド起動</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        internal void SetGdsGrpCodeGuide(int rowIndex, int customerCode)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // お買得商品グループガイド
                PMREC09030UA recBgnGrpSearchForm = new PMREC09030UA(PMREC09030UA.GUIDETYPE_NORMAL, customerCode, new ArrayList(this._recBgnGdsAcs.CustomerSearchRetList));
                recBgnGrpSearchForm.RecBgnGrpSelect += new PMREC09030UA.RecBgnGrpSelectEventHandler(this.RecBgnGrpSearchForm_RecBgnGrpSelect);
                recBgnGrpSearchForm.ShowDialog(this);

                if (this._recBgnGrpRet != null)
                {
                    // お買得商品グループ
                    this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnCustDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Value = this._recBgnGrpRet.BrgnGoodsGrpCode.ToString().PadLeft(4, '0');

                    MoveNextAllowEditCell(false);
                    this._customerSearchRet = null;
                }
                else
                {
                    this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnCustDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Activate();
                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// お買得商品グループ選択時発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="customerSearchRet">お買得商品グループ検索戻り値クラス</param>
        /// <remarks>
        /// <br>Note        : お買得商品グループ選択時に発生します。</br>
        /// <br>Programmer	: 脇田 靖之</br>
        /// <br>Date		: 2015/02/20</br>
        /// </remarks>
        private void RecBgnGrpSearchForm_RecBgnGrpSelect(object sender, RecBgnGrpRet recBgnGrpRet)
        {
            if (recBgnGrpRet == null)
            {
                this._recBgnGrpRet = null;
                return;
            }
            this._recBgnGrpRet = recBgnGrpRet;
        }
        
        /// <summary>
        /// 得意先コードガイド起動
        /// </summary>
        /// <param name="rowIndex">行番号</param>
        /// <remarks>
        /// <br>Note	   : 得意先コードガイド起動。</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        internal void SetCustomerCodeGuide(int rowIndex)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // 得意先ガイド
                PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);

                customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
                customerSearchForm.ShowDialog(this);

                if (this._customerSearchRet != null)
                {
                    // 得意先コード
                    this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnCustDataTable.CustomerCodeColumn.ColumnName].Value = this._customerSearchRet.CustomerCode.ToString().PadLeft(8, '0');

                    MoveNextAllowEditCell(false);
                    this._customerSearchRet = null;
                }
                else
                {
                    this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnCustDataTable.CustomerCodeColumn.ColumnName].Activate();
                    this.uGrid_Details.PerformAction(UltraGridAction.EnterEditMode);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// 得意先選択時発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="customerSearchRet">得意先検索戻り値クラス</param>
        /// <remarks>
        /// <br>Note        : 得意先選択時に発生します。</br>
        /// <br>Programmer	: 脇田 靖之</br>
        /// <br>Date		: 2015/02/20</br>
        /// </remarks>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null)
            {
                this._customerSearchRet = null;
                return;
            }
            this._customerSearchRet = customerSearchRet;
        }

        #endregion

        #region 明細展開処理

        /// <summary>
        /// 明細展開処理
        /// </summary>
        private bool BgnDataDeployment()
        {
            string sectionCode = string.Empty;
            string errorMsg = string.Empty;
            string date = string.Empty;

            int customerCode = 0;
            int rowIndex = this.uGrid_Details.ActiveRow.Index;
            int rowNo = this._recBgnCustDataTable[rowIndex].RowNo;

            int status = 0;
            bool chkStatus = false;

            // 拠点
            sectionCode = this._recBgnGdsRow.InqOtherSecCd;

            // 得意先
            if (this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnCustDataTable.CustomerCodeColumn.ColumnName].Value.ToString() != string.Empty)
                customerCode = int.Parse(this.uGrid_Details.Rows[rowIndex].Cells[this._recBgnCustDataTable.CustomerCodeColumn.ColumnName].Value.ToString().Trim());

            // テンポラリ情報クリア
            this._recBgnCustTmpDataTable.Clear();

            // 拠点・得意先選択データテーブルの設定 // お買得商品グループコード
            this.SetSecCusSetDataTable(customerCode, sectionCode);

            switch (_secCusSetDataTable.Count)
            {
                case 0:
                    // 0件の場合 エラー
                    TMsgDisp.Show(this
                                 , emErrorLevel.ERR_LEVEL_EXCLAMATION
                                 , this.Name
                                 , "連携している得意先ではありません。"
                                 , 0
                                 , MessageBoxButtons.OK);

                    return false;
                //break;
                case 1:
                    // 1件の場合 選択画面表示無し
                    break;
                default:
                    // 2件以上の場合 選択画面表示

                    PMREC09021UC salesSlipNumInputDialog = new PMREC09021UC(this._secCusSetDataTable);

                    // -- 子画面選択行データのみ残っています。
                    this._secCusSetDataTable = salesSlipNumInputDialog.SecCusSetDataTable;
                    DialogResult dialogResult = salesSlipNumInputDialog.ShowDialog();

                    salesSlipNumInputDialog.Close();

                    // --- ADD 2015/04/08 Y.Wakita Redmine#3435 ---------->>>>>
                    if (dialogResult == DialogResult.Cancel) return false;
                    // --- ADD 2015/04/08 Y.Wakita Redmine#3435 ----------<<<<<

                    break;
            }

            DateTime startDate = DateTime.Parse(this._recBgnGdsRow.ApplyStaDate);   // 公開開始日
            DateTime endDate = DateTime.Parse(this._recBgnGdsRow.ApplyEndDate);     // 公開終了日

            List<RecBgnGdsAcs.StartEndDate> retOpenStartEndDateList;
            foreach (RecBgnGdsDataSet.SecCusSetRow row in this._secCusSetDataTable.Rows)
            {
                if (this._recBgnGdsRow.InqOtherSecCd.Trim() == "00")
                    row.SectionCode = this._recBgnGdsRow.InqOtherSecCd.Trim();

                // 得意先
                customerCode = int.Parse(row.CustomerCode);

                // 管理拠点拠点
                sectionCode = row.MngSectionCode;

                // 範囲取得
                // --- UPD 2015/03/25 Y.Wakita ---------->>>>>
                //status = RecBgnGdsAcs.GetOpenStartEndDateList(startDate, endDate, customerCode, sectionCode, this._swGoodsUnitData, out retOpenStartEndDateList);
                status = RecBgnGdsAcs.GetOpenStartEndDateList(startDate, endDate, customerCode, sectionCode, this._swGoodsUnitData, this._swMkrSuggestRtPricList, this._swMkrSuggestRtPricUList, out retOpenStartEndDateList);
                // --- UPD 2015/03/25 Y.Wakita ----------<<<<<

                // テンポラリ情報作成
                // --- UPD 2015/03/25 Y.Wakita ---------->>>>>
                //this.AddToRecBgnCustTmpFromRecBgnCust(this._recBgnCustDataTable[rowIndex], row, retOpenStartEndDateList, _swGoodsUnitData);
                this.AddToRecBgnCustTmpFromRecBgnCust(this._recBgnCustDataTable[rowIndex], row, retOpenStartEndDateList, _swGoodsUnitData, this._swMkrSuggestRtPricList, this._swMkrSuggestRtPricUList);
                // --- UPD 2015/03/25 Y.Wakita ----------<<<<<
            }

            // 画面反映チェック
            chkStatus = this.AddToRecBgnCustCheck(rowNo, out errorMsg);
            if (errorMsg != string.Empty)
            {
                TMsgDisp.Show(
                     this,
                     emErrorLevel.ERR_LEVEL_EXCLAMATION,
                     this.Name,
                     "同一の設定が既に登録されています。" + "\r\n" +
                     errorMsg,
                     0,
                     MessageBoxButtons.OK);
            }

            if (chkStatus == true)
            {
                // テンポラリより画面に反映
                this.AddToRecBgnCustFromRecBgnCustTmp(this._recBgnCustTmpDataTable, rowIndex, rowNo);

                // 全項目使用不可
                this.AllCellNoEdit(0);
            }
            this._recBgnCustTmpDataTable.Clear();

            return chkStatus;
        }

        /// <summary>
        /// 拠点得意先画面表示用データテーブルの設定
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="sectionCode">拠点コード</param>
        private void SetSecCusSetDataTable(int customerCode, string sectionCode)
        {

            List<ScmEpScCnt> scmEpScCntList = new List<ScmEpScCnt>();
            _secCusSetDataTable.Clear();

            // SCM企業連結データの取得 検索条件：ログイン企業コード
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            if (this._recBgnGdsAcs.ScmEpScCntList.Count == 0)
            {
                status = this.SearchCnectOriginalEpFromSc(ref scmEpScCntList);
            }
            else
            {
                scmEpScCntList = this._recBgnGdsAcs.ScmEpScCntList;
            }

            if (status.Equals((int)ConstantManagement.DB_Status.ctDB_NORMAL))
            {
                foreach (ScmEpScCnt wk in scmEpScCntList)
                {
                    #region SCM企業連結データの絞込み

                    if (!wk.LogicalDeleteCode.Equals(0)) continue;                              // 論理削除：有効以外
                    if (wk.DiscDivCd.Equals(1)) continue;                                       // 連結無効
                    if (wk.ScmCommMethod.Equals(0) && wk.PccUoeCommMethod.Equals(0)) continue;  // 通信方式が無効

                    if (!this._secInfoSetList.Exists(delegate(SecInfoSet sec)
                                                        {
                                                            return (sec.SectionCode.Trim().Equals(wk.CnectOtherSecCd.Trim()));
                                                        }
                                                        )
                        ) continue; // 拠点マスタに存在しない


                    // 全社では無い場合、拠点で絞込み
                    if (!sectionCode.Equals(ALL_SECTION_CODE))
                    {
                        if (!sectionCode.Equals(wk.CnectOtherSecCd.Trim())) continue;
                    }

                    // 得意先が設定済みであれば、得意先に設定してあるSF拠点での絞込み
                    if (customerCode > 0)
                    {
                        // オンライン種別区分、得意先企業コード、得意先拠点コードの判定
                        if (!(this._recBgnGdsAcs.CustomerDic[customerCode].OnlineKindDiv == 10  // 10:SCM
                            && this._recBgnGdsAcs.CustomerDic[customerCode].CustomerEpCode.Trim().Equals(wk.CnectOriginalEpCd.Trim())
                            && this._recBgnGdsAcs.CustomerDic[customerCode].CustomerSecCode.Trim().Equals(wk.CnectOriginalSecCd.Trim())
                            ))
                        {

                            continue;
                        }
                    }
                    #endregion SCM企業連結データの絞込み

                    // 得意先指定有無
                    if (customerCode > 0)
                    {
                        // 得意先追加有無チェック
                        DataRow[] rows = this._secCusSetDataTable.Select("CustomerCode = '" + customerCode.ToString().PadLeft(8, '0') + "'");
                        if (rows.Length == 0)
                        {
                            // 得意先コードの指定がある場合は該当の得意先情報を取得し行追加する
                            RecBgnGdsDataSet.SecCusSetRow row = _secCusSetDataTable.NewSecCusSetRow();
                            row.CustomerCode = customerCode.ToString().PadLeft(8, '0');
                            row.CustomerName = ((CustomerInfo)this._recBgnGdsAcs.CustomerDic[customerCode]).CustomerSnm.Trim();
                            row.SectionCode = wk.CnectOtherSecCd;
                            row.SectionName = wk.CnectOtherSecNm;
                            row.CnectOriginalEpCd = wk.CnectOriginalEpCd;
                            row.CnectOriginalSecCd = wk.CnectOriginalSecCd;
                            row.MngSectionCode = ((CustomerInfo)this._recBgnGdsAcs.CustomerDic[customerCode]).MngSectionCode.Trim(); // 管理拠点コード
                            _secCusSetDataTable.AddSecCusSetRow(row);
                        }
                    }
                    else
                    {
                        // 得意先コードの指定がない場合は対象（オンライン情報が同一であれば、複数の得意先）の得意先情報を取得し行追加する
                        foreach (CustomerInfo customerInfo in this._recBgnGdsAcs.CustomerDic.Values)
                        {
                            if (customerInfo.OnlineKindDiv == 10  // 10:SCM
                             && customerInfo.CustomerEpCode.Trim().Equals(wk.CnectOriginalEpCd.Trim())
                             && customerInfo.CustomerSecCode.Trim().Equals(wk.CnectOriginalSecCd.Trim()))
                            {
                                // 得意先追加有無チェック
                                DataRow[] rows = this._secCusSetDataTable.Select("CustomerCode = '" + ((CustomerInfo)this._recBgnGdsAcs.CustomerDic[customerInfo.CustomerCode]).CustomerCode.ToString().PadLeft(8, '0') + "'");
                                if (rows.Length == 0)
                                {
                                    RecBgnGdsDataSet.SecCusSetRow row = _secCusSetDataTable.NewSecCusSetRow();
                                    row.CustomerCode = ((CustomerInfo)this._recBgnGdsAcs.CustomerDic[customerInfo.CustomerCode]).CustomerCode.ToString().PadLeft(8, '0');
                                    row.CustomerName = ((CustomerInfo)this._recBgnGdsAcs.CustomerDic[customerInfo.CustomerCode]).CustomerSnm.Trim();
                                    row.SectionCode = wk.CnectOtherSecCd;
                                    row.SectionName = wk.CnectOtherSecNm;
                                    row.CnectOriginalEpCd = wk.CnectOriginalEpCd;
                                    row.CnectOriginalSecCd = wk.CnectOriginalSecCd;
                                    row.MngSectionCode = ((CustomerInfo)this._recBgnGdsAcs.CustomerDic[customerInfo.CustomerCode]).MngSectionCode.Trim(); // 管理拠点コード
                                    _secCusSetDataTable.AddSecCusSetRow(row);
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// SCM企業連結データ検索
        /// （検索時のエラーメッセージの出力制御）
        /// </summary>
        /// <param name="scmEpScCntList">SCM企業連結データリスト</param>
        /// <returns>ステータス 0：正常終了 0以外：異常終了 </returns>
        private int SearchCnectOriginalEpFromSc(ref List<ScmEpScCnt> scmEpScCntList)
        {
            int status = -1;
            const string ctASSEMBLY_ID = "PMREC09021U";
            const string ctASSEMBLY_NAME = "お買得商品設定マスタ";
            List<ScmEpCnect> scmEpCnectList = new List<ScmEpCnect>();

            try
            {
                bool msgDiv;
                string errMsg;

                status = this._scmEpScCntAcs.SearchCnectOriginalEpFromSc(this._enterpriseCode, ConstantManagement.LogicalMode.GetData01, out scmEpScCntList, out msgDiv, out errMsg);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        {
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT:
                        {
                            string message = "SCM企業連結データの読込みにてタイムアウトが発生しました。";
                            if (msgDiv)
                            {
                                message = message + Environment.NewLine + Environment.NewLine + "*詳細 = " + errMsg;
                            }

                            TMsgDisp.Show(
                                this,								// 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
                                ctASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                                ctASSEMBLY_NAME,					// プログラム名称
                                "Search",							// 処理名称
                                TMsgDisp.OPE_GET,					// オペレーション
                                message,							// サーバーからのメッセージを表示
                                status,								// ステータス値
                                this._scmEpScCntAcs,				// エラーが発生したオブジェクト
                                MessageBoxButtons.OK,				// 表示するボタン
                                MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                            break;
                        }
                    default:
                        {
                            // サーチ
                            TMsgDisp.Show(
                                this,	        						 // 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_STOPDISP,         // エラーレベル
                                ctASSEMBLY_ID,			          		 // アセンブリＩＤまたはクラスＩＤ
                                ctASSEMBLY_NAME,				         // プログラム名称
                                "Search",				        		 // 処理名称
                                TMsgDisp.OPE_GET,        				 // オペレーション
                                "企業連結データの検索に失敗しました。",  // 表示するメッセージ
                                status,								     // ステータス値
                                this._scmEpScCntAcs,         			 // エラーが発生したオブジェクト
                                MessageBoxButtons.OK,		        	 // 表示するボタン
                                MessageBoxDefaultButton.Button1);        // 初期表示ボタン
                            break;
                        }
                }

            }
            catch (Exception ex)
            {
                string message = "企業連結データ検索処理にて例外が発生しました。" + Environment.NewLine + ex.Message;
                TMsgDisp.Show(
                    this,									// 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_STOPDISP,		// エラーレベル
                    ctASSEMBLY_ID,							// アセンブリＩＤまたはクラスＩＤ
                    ctASSEMBLY_NAME,						// プログラム名称
                    "Search",								// 処理名称
                    TMsgDisp.OPE_GET,						// オペレーション
                    message,								// 表示するメッセージ
                    status,									// ステータス値
                     this._scmEpScCntAcs,					// エラーが発生したオブジェクト
                    MessageBoxButtons.OK,					// 表示するボタン
                    MessageBoxDefaultButton.Button1);		// 初期表示ボタン
            }

            return status;
        }

        /// <summary>
        /// RecBgnGds->RecBgnGdsTmp
        /// </summary>
        /// <param name="RecBgnGdsWork">お買得商品設定</param>
        /// <returns>お買得商品設定TEMP</returns>
        /// <remarks>
        /// <br>Note       : RecBgnGds->RecBgnGdsTmp</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        // --- UPD 2015/03/25 Y.Wakita ---------->>>>>
        //private void AddToRecBgnCustTmpFromRecBgnCust(RecBgnGdsDataSet.RecBgnCustRow recBgnCust
        //                                        , RecBgnGdsDataSet.SecCusSetRow secCusSetRow
        //                                        , List<RecBgnGdsAcs.StartEndDate> retOpenStartEndDateList
        //                                        , GoodsUnitData goodsUnitData)
        private void AddToRecBgnCustTmpFromRecBgnCust(RecBgnGdsDataSet.RecBgnCustRow recBgnCust
                                                , RecBgnGdsDataSet.SecCusSetRow secCusSetRow
                                                , List<RecBgnGdsAcs.StartEndDate> retOpenStartEndDateList
                                                , GoodsUnitData goodsUnitData
                                                , Dictionary<Calculator.GoodsInfoKey, List<GoodsPrice>> mkrSuggestRtPricList
                                                , Dictionary<Calculator.GoodsInfoKey, List<GoodsPrice>> mkrSuggestRtPricUList)
        // --- UPD 2015/03/25 Y.Wakita ----------<<<<<
        {
            bool status = true;
            foreach (RecBgnGdsAcs.StartEndDate list in retOpenStartEndDateList)
            {
                status = true;
                foreach (RecBgnGdsDataSet.RecBgnCustTmpRow recBgnCustTmp in this._recBgnCustTmpDataTable)
                {
                    // 重複チェック
                    if ((recBgnCustTmp.InqOriginalEpCd == secCusSetRow.CnectOriginalEpCd)
                     && (recBgnCustTmp.InqOriginalSecCd == secCusSetRow.CnectOriginalSecCd)
                     && (recBgnCustTmp.InqOtherEpCd == this._enterpriseCode)
                     && (recBgnCustTmp.InqOtherSecCd.Trim() == secCusSetRow.SectionCode.Trim()))
                    {
                        if ((recBgnCustTmp.ApplyStaDate <= int.Parse(list.StartDate.ToString("yyyyMMdd"))
                          && int.Parse(list.StartDate.ToString("yyyyMMdd")) <= recBgnCustTmp.ApplyEndDate)
                         || (recBgnCustTmp.ApplyStaDate <= int.Parse(list.EndDate.ToString("yyyyMMdd"))
                          && int.Parse(list.EndDate.ToString("yyyyMMdd")) <= recBgnCustTmp.ApplyEndDate))
                        {
                            status = false;
                            break;
                        }
                    }
                }

                // エラーの場合、追加しない
                if (status == false) continue;

                long wkMkrSuggestRtPric = 0;
                long wkListPrice = 0;
                long wkUnitPrice = 0;
                bool uPricDiv = false;  // ADD 2015/03/26 Y.Wakita

                // 価格取得
                // --- UPD 2015/03/25 Y.Wakita ---------->>>>>
                //Calculator.GetUnitPrice(int.Parse(secCusSetRow.CustomerCode)
                //                           , goodsUnitData
                //                           , list.StartDate
                //                           , secCusSetRow.MngSectionCode
                //                           , out wkMkrSuggestRtPric
                //                           , out wkListPrice
                //                           , out wkUnitPrice);
                Calculator.GetUnitPrice(int.Parse(secCusSetRow.CustomerCode)
                                           , goodsUnitData
                                           , list.StartDate
                                           , secCusSetRow.MngSectionCode
                                           , mkrSuggestRtPricList
                                           , mkrSuggestRtPricUList
                                           , out uPricDiv   // ADD 2015/03/26 Y.Wakita
                                           , out wkMkrSuggestRtPric
                                           , out wkListPrice
                                           , out wkUnitPrice);
                // --- UPD 2015/03/25 Y.Wakita ----------<<<<<

                this._recBgnCustTmpDataTable.BeginLoadData();
                RecBgnGdsDataSet.RecBgnCustTmpRow newRow = this._recBgnCustTmpDataTable.NewRecBgnCustTmpRow();

                newRow.RowNo = this._recBgnCustTmpDataTable.Count + 1;
                // ---------- 共通項目 ----------
                newRow.FilterGuid = recBgnCust.FilterGuid;
                newRow.UpdateTime = recBgnCust.UpdateTime;
                newRow.RowDeleteFlg = recBgnCust.RowDeleteFlg;
                // ---------- 設定項目 ----------
                newRow.InqOriginalEpCd = secCusSetRow.CnectOriginalEpCd;                            // 問合せ元企業コード
                newRow.InqOriginalSecCd = secCusSetRow.CnectOriginalSecCd;                          // 問合せ元拠点コード
                newRow.InqOtherEpCd = this._enterpriseCode;                                         // 問合せ先企業コード
                newRow.InqOtherSecCd = secCusSetRow.SectionCode;                                    // 問合せ先拠点コード
                newRow.CustomerCode = secCusSetRow.CustomerCode.ToString().PadLeft(8, '0');         // 得意先コード
                //newRow.BrgnGoodsGrpCode = 0;                                                        // お買得商品グループコード
                newRow.BrgnGoodsGrpCode = this._recBgnGdsRow.BrgnGoodsGrpCode;                      // お買得商品グループコード
                newRow.GoodsNo = this._recBgnGdsRow.GoodsNo;
                newRow.GoodsMakerCode = this._recBgnGdsRow.GoodsMakerCode;
                newRow.GoodsApplyStaDate = int.Parse(this._swGoodsUnitData.OfferDate.ToString("yyyyMMdd"));     
                newRow.DisplayDivCode = 1;                                                          // 表示区分
                newRow.MngSectionCode = secCusSetRow.MngSectionCode;                                // 管理拠点コード
                newRow.MkrSuggestRtPric = wkMkrSuggestRtPric;                                       // メーカー希望小売価格
                newRow.ListPrice = wkListPrice;                                                     // 定価
                newRow.UnitCalcRate = 0;                                                            // 売価率
                newRow.UnitPrice = wkUnitPrice;                                                     // 単価
                newRow.ApplyStaDate = int.Parse(list.StartDate.ToString("yyyyMMdd"));               // 適用開始日
                newRow.ApplyEndDate = int.Parse(list.EndDate.ToString("yyyyMMdd"));                 // 適用終了日

                this._recBgnCustTmpDataTable.AddRecBgnCustTmpRow(newRow);
                this._recBgnCustTmpDataTable.EndLoadData();
            }

        }

        #endregion

        #endregion

        #region シリアライズ・デシリアライズ
        /// <summary>
        /// お買得商品用ユーザー設定シリアライズ処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : お買得商品用ユーザー設定のシリアライズを行います。</br>
        /// <br>Programmer : </br>
        /// <br>Date       : </br>
        /// </remarks>
        public void Serialize()
        {
            try
            {
                UserSettingController.SerializeUserSetting(_userSetting, Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }

        }

        /// <summary>
        /// お買得商品用ユーザー設定デシリアライズ処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : お買得商品用ユーザー設定クラスをデシリアライズします。</br>
        /// <br>Programmer : </br>
        /// <br>Date       : </br>
        /// </remarks>
        public void Deserialize()
        {
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME)))
            {
                try
                {
                    this._userSetting = UserSettingController.DeserializeUserSetting<RecBgnCustUserSet>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME));
                }
                catch
                {
                    this._userSetting = new RecBgnCustUserSet();
                }
            }
        }

        #endregion

        #region チェック処理
        /// <summary>
        /// RecBgnGdsTmp->RecBgnGds
        /// </summary>
        /// <param name="RecBgnGds">お買得商品個別設定</param>
        /// <returns>お買得商品設定</returns>
        /// <remarks>
        /// <br>Note       : RecBgnGdsTmp->RecBgnGds</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private bool AddToRecBgnCustCheck(int rowNo, out string errorMsg)
        {
            bool status = true;

            int errorCount = 0;
            errorMsg = string.Empty;

            foreach (RecBgnGdsDataSet.RecBgnCustTmpRow recBgnGdsTmp in this._recBgnCustTmpDataTable)
            {
                recBgnGdsTmp.ErrorDiv = 0;
                foreach (RecBgnGdsDataSet.RecBgnCustRow recBgnCust in this._recBgnCustDataTable)
                {
                    if (recBgnCust.FilterGuid == Guid.Empty && recBgnCust.RowDeleteFlg == 1) continue;

                    if (recBgnCust.RowNo == rowNo) continue;

                    // 重複チェック
                    if ((recBgnCust.InqOriginalEpCd == recBgnGdsTmp.InqOriginalEpCd)
                     && (recBgnCust.InqOriginalSecCd == recBgnGdsTmp.InqOriginalSecCd)
                     && (recBgnCust.InqOtherEpCd == recBgnGdsTmp.InqOtherEpCd)
                     && (recBgnCust.InqOtherSecCd.Trim() == recBgnGdsTmp.InqOtherSecCd.Trim())
                     )
                    {
                        int startDate = 0;
                        if (!recBgnCust.ApplyStaDate.Trim().Equals(string.Empty)) startDate = int.Parse(recBgnCust.ApplyStaDate.Trim().Replace("/", ""));
                        int endDate = 0;
                        if (!recBgnCust.ApplyEndDate.Trim().Equals(string.Empty)) endDate = int.Parse(recBgnCust.ApplyEndDate.Trim().Replace("/", ""));

                        if ((startDate <= recBgnGdsTmp.ApplyStaDate
                           && recBgnGdsTmp.ApplyStaDate <= endDate)
                           || (startDate <= recBgnGdsTmp.ApplyEndDate
                           && recBgnGdsTmp.ApplyEndDate <= endDate))
                        {

                            // キー項目が重複している場合
                            errorMsg += "公開日：" + recBgnCust.ApplyStaDate.ToString().PadLeft(6, '0')
                                    + "～" + recBgnCust.ApplyEndDate.ToString().PadLeft(6, '0')
                                    + "、得意先：" + recBgnCust.CustomerCode.ToString().PadLeft(8, '0')
                                    + "\r\n";
                            recBgnGdsTmp.ErrorDiv = 1;
                            errorCount += 1;
                        }
                    }
                }
            }

            if (this._recBgnCustTmpDataTable.Count == errorCount)
            {
                // 展開データが全て重複
                status = false;
            }

            return status;
        }

        /// <summary>
        /// RecBgnGdsTmp->RecBgnGds
        /// </summary>
        /// <param name="RecBgnGds">お買得商品設定</param>
        /// <returns>お買得商品設定</returns>
        /// <remarks>
        /// <br>Note       : RecBgnGdsTmp->RecBgnGds</br>
        /// <br>Programmer : 脇田 靖之</br>
        /// <br>Date       : 2015/02/20</br>
        /// </remarks>
        private void AddToRecBgnCustFromRecBgnCustTmp(RecBgnGdsDataSet.RecBgnCustTmpDataTable RecBgnCustTmp, int rowIndex, int rowNo)
        {
            // 元データ削除
            this._recBgnCustDataTable.Rows[rowIndex].Delete();
            this._recBgnCustDataTable.AcceptChanges();

            foreach (RecBgnGdsDataSet.RecBgnCustTmpRow recBgnCustTmp in RecBgnCustTmp)
            {
                if (recBgnCustTmp.ErrorDiv == 1) continue;   // 重複エラーの場合

                this._recBgnCustDataTable.BeginLoadData();
                RecBgnGdsDataSet.RecBgnCustRow newRow = this._recBgnCustDataTable.NewRecBgnCustRow();

                // ---------- 共通項目 ----------
                newRow.RowNo = rowNo;
                newRow.FilterGuid = recBgnCustTmp.FilterGuid;
                newRow.UpdateTime = recBgnCustTmp.UpdateTime;
                newRow.RowDeleteFlg = recBgnCustTmp.RowDeleteFlg;
                newRow.InqOriginalEpCd = recBgnCustTmp.InqOriginalEpCd;                                             // 問合せ元企業コード
                newRow.InqOriginalSecCd = recBgnCustTmp.InqOriginalSecCd;                                           // 問合せ元拠点コード
                newRow.InqOtherEpCd = recBgnCustTmp.InqOtherEpCd;                                                   // 問合せ先企業コード
                newRow.InqOtherSecCd = recBgnCustTmp.InqOtherSecCd;                                                 // 問合せ先拠点コード 
                // ---------- 共通項目 ----------
                newRow.CustomerCode = recBgnCustTmp.CustomerCode.ToString().PadLeft(8, '0');                        // 得意先コード
                newRow.BrgnGoodsGrpCode = recBgnCustTmp.BrgnGoodsGrpCode;                                           // お買得商品グル―プコード
                newRow.BrgnGoodsGrpName = this._recBgnGdsRow.BrgnGoodsGrpName;                                      // お買得商品グル―プ名
                newRow.GoodsNo = recBgnCustTmp.GoodsNo;                                                             // 品番
                newRow.GoodsMakerCode = recBgnCustTmp.GoodsMakerCode;                                               // メーカー
                newRow.GoodsApplyStaDate = recBgnCustTmp.GoodsApplyStaDate;                                         // 商品適用開始日
                newRow.MngSectionCode = recBgnCustTmp.MngSectionCode;                                               // 管理拠点
                newRow.DisplayDivCode = recBgnCustTmp.DisplayDivCode;                                               // 表示区分
                newRow.MkrSuggestRtPric = recBgnCustTmp.MkrSuggestRtPric;                                           // メーカー希望小売価格
                newRow.ListPrice = recBgnCustTmp.ListPrice;                                                         // 定価
                newRow.UnitCalcRate = recBgnCustTmp.UnitCalcRate;                                                   // 売価率
                newRow.UnitPrice = recBgnCustTmp.UnitPrice;                                                         // 単価
                string startDate = string.Empty;                                                                    // 適用開始日
                if (recBgnCustTmp.ApplyStaDate != 0) startDate = recBgnCustTmp.ApplyStaDate.ToString("0000/00/00");
                newRow.ApplyStaDate = startDate;
                string endDate = string.Empty;                                                                      // 適用終了日
                if (recBgnCustTmp.ApplyEndDate != 0) endDate = recBgnCustTmp.ApplyEndDate.ToString("0000/00/00");
                newRow.ApplyEndDate = endDate;
                // ---------- 名称取得項目 ----------
                newRow.CustomerName = this._recBgnGdsAcs.GetCustomerName(int.Parse(recBgnCustTmp.CustomerCode));    // 得意先名

                newRow.RowDevelopFlg = 1;
                this._recBgnCustDataTable.AddRecBgnCustRow(newRow);
                this._recBgnCustDataTable.EndLoadData();

                rowNo += 1;
            }
            this._recBgnCustDataTable.AcceptChanges();
        }
        #endregion


        /// <summary>
        /// グリッド セル変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uGrid_Details_CellChange(object sender, CellEventArgs e)
        {
            if (e.Cell == null) return;

            // 公開区分
            if (e.Cell.Column.Key == this._recBgnCustDataTable.DisplayDivCodeColumn.ColumnName)
            {

                // 未確定行は判定しない
                RecBgnGdsDataSet.RecBgnCustRow row = (RecBgnGdsDataSet.RecBgnCustRow)this._recBgnCustDataTable.Rows[e.Cell.Row.Index];
                if (row.RowDevelopFlg == 0) return;
                
                // 未公開時はお買得商品グループ・価格の値をクリアし入力不可
                List<UltraGridCell> cellList = new List<UltraGridCell>();
                cellList.Add(this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._recBgnCustDataTable.BrgnGoodsGrpCodeColumn.ColumnName]);   // お買得商品グループコード
                cellList.Add(this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._recBgnCustDataTable.UnitCalcRateColumn.ColumnName]);       // 売価率
                cellList.Add(this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._recBgnCustDataTable.UnitPriceColumn.ColumnName]);          // 売単価


                // 活性・非活性切替
                foreach (UltraGridCell cell in cellList)
                {
                    if (e.Cell.Text != "0")
                    {
                        cell.Appearance.BackColor = Color.Empty;
                        cell.Appearance.BackColor2 = Color.Empty;
                        cell.Activation = Activation.AllowEdit;
                    }
                    else
                    {
                        cell.Appearance.BackColor = ct_DISABLE_COLOR;
                        cell.Appearance.BackColor2 = ct_DISABLE_COLOR;
                        cell.Activation = Activation.NoEdit;
                    }
                }

                // --- DEL 2015/03/16 Y.Wakita 要望 ---------->>>>>
                //// セル値を更新
                //if (e.Cell.Text != "0")
                //{
                //    // 公開時は再計算
                //    RecBgnGdsDataSet.RecBgnCustRow dataRow = (RecBgnGdsDataSet.RecBgnCustRow)this._recBgnCustDataTable.Rows[e.Cell.Row.Index];
                //    DateTime startDate = DateTime.Parse(dataRow.ApplyEndDate);
                //    long mkrSuggestRtPric = 0;
                //    long listPrice = 0;
                //    long unitPrice = 0;
                //    this._calculator.GetUnitPrice(int.Parse(dataRow.CustomerCode)
                //                               , this._swGoodsUnitData
                //                               , startDate
                //                               , dataRow.MngSectionCode
                //                               , out mkrSuggestRtPric
                //                               , out listPrice
                //                               , out unitPrice);

                //    this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._recBgnCustDataTable.MkrSuggestRtPricColumn.ColumnName].Value = mkrSuggestRtPric;  // メーカー希望小売価格
                //    this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._recBgnCustDataTable.ListPriceColumn.ColumnName].Value = listPrice;                // 定価
                //    this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._recBgnCustDataTable.UnitPriceColumn.ColumnName].Value = unitPrice;                // 売価

                //    // お買得商品グループコードの指定がない場合は引き継いだコード、名称を使用する
                //    if (int.Parse(this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._recBgnCustDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Value.ToString()) == 0)
                //    {
                //        this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._recBgnCustDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Value = this._recBgnGdsRow.BrgnGoodsGrpCode;
                //        this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._recBgnCustDataTable.BrgnGoodsGrpNameColumn.ColumnName].Value = this._recBgnGdsRow.BrgnGoodsGrpName;
                //    }

                //}
                //else
                //{
                //    // 非公開時はクリア
                //    this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._recBgnCustDataTable.BrgnGoodsGrpCodeColumn.ColumnName].Value = 0;                 // お買得商品グループコード
                //    this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._recBgnCustDataTable.BrgnGoodsGrpNameColumn.ColumnName].Value = string.Empty;      // お買得商品グループ名
                //    this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._recBgnCustDataTable.MkrSuggestRtPricColumn.ColumnName].Value = 0;                 // メーカー希望小売価格
                //    this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._recBgnCustDataTable.ListPriceColumn.ColumnName].Value = 0;                        // 定価
                //    this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._recBgnCustDataTable.UnitCalcRateColumn.ColumnName].Value = 0;                     // 売価率
                //    this.uGrid_Details.Rows[e.Cell.Row.Index].Cells[this._recBgnCustDataTable.UnitPriceColumn.ColumnName].Value = 0;                        // 売単価
                
                //}
                // --- DEL 2015/03/16 Y.Wakita 要望 ----------<<<<<
            }
        }
    }

}

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.Misc;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;


namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 
    /// </summary>
    public class GridFormBase : Form
	{
        // ===================================================================================== //
        // プロテクティッド定数
        // ===================================================================================== //
        #region protected constant
        //自由帳票グループ用
        /// <summary>作成日付</summary>
        protected const string CT_FREE_PPR_CRDT = "CREATE_DATETIME";   //作成日付
        /// <summary>更新日付</summary>
        protected const string CT_FREE_PPR_UPDT = "UPDATE_DATETIME";   //更新日付
        /// <summary>GUID</summary>
        protected const string CT_FREE_PPR_GUID = "FileHeaderGuid";    //GUID
        /// <summary>テーブルタイトル</summary>
        protected const string CT_FREE_PPR_GR = "FREE_SHEET_GR";     //テーブルタイトル
        /// <summary>グループ名称</summary>
        protected const string CT_FREE_PPR_GrNm = "グループ名称";      //グループ名称
        /// <summary>グループコード</summary>
        protected const string CT_FREE_PPR_GrCd = "グループコード";    //グループコード
        
        //自由帳票印刷対象用
        /// <summary>テーブルタイトル</summary>
        protected const string CT_FREE_PPR_PRT = "FREE_SHEET_PRT";       //テーブルタイトル
        /// <summary>振替コード</summary>
        protected const string CT_FREE_PPR_TrsCd = "TransferCode";       //振替コード
        /// <summary>表示順位</summary>
        protected const string CT_FREE_PPR_DspOdr = "表示順位";          //表示順位
        /// <summary>出力名称</summary>
        protected const string CT_FREE_PPR_PrtNm = "帳票名称";       //出力名称
        /// <summary>出力ファイル名</summary>
        protected const string CT_FREE_PPR_OFrmFilNm = "OutPutFrmFilNm"; //出力ファイル名
        /// <summary>ユーザー帳票ID枝番号</summary>
        protected const string CT_FREE_PPR_DerivNo = "UPrtPprIDDerivNo"; //ユーザー帳票ID枝番号
        /// <summary>最終印刷日時</summary>
        protected const string CT_FREE_PPR_LstPrtDt = "最終印刷日時";    //最終印刷日時
        /// <summary>ユーザーコメント</summary>
        protected const string CT_FREE_PPR_USRComment = "コメント";      //ユーザーコメント

        //帳票選択
        /// <summary>テーブルタイトル</summary>
        protected const string CT_FREE_PPR_SLCT = "FREE_PPR_SLCT";       //テーブルタイトル

        //共通
        /// <summary>RowADD</summary>
        protected const string CT_ROW_ADD = "RowADD";
        /// <summary>RowDelete</summary>
        protected const string CT_ROW_DELETE = "RowDelete";
        /// <summary>SFANL08201U</summary>
        protected const string PGID = "SFANL08201U";
        #endregion

        // ===================================================================================== //
        // 内部使用関数
        // ===================================================================================== //
        #region protected methods

        #region 画面初期設定

        #region ツールバーの設定
        /// <summary>
        /// ツールバー設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note		:	ツールバーの設定を行います。</br>
        /// <br>Programmer	:	22011 柏原　頼人</br>
        /// <br>Date		:	2007.03.26</br>
        /// </remarks>
        protected void SetToolbarAppearance(UltraToolbarsManager ultraToolbarsManager)
        {
            // ツールバーにアイコン設定
            ultraToolbarsManager.ImageListSmall = IconResourceManagement.ImageList24;

            // 追加へのアイコン設定
            Infragistics.Win.UltraWinToolbars.ButtonTool selectButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)ultraToolbarsManager.Tools[CT_ROW_ADD];
            if (selectButton != null) selectButton.SharedProps.AppearancesSmall.Appearance.Image = Size24_Index.ROWINSERT;

            // 削除へのアイコン設定
            Infragistics.Win.UltraWinToolbars.ButtonTool closeButton = (Infragistics.Win.UltraWinToolbars.ButtonTool)ultraToolbarsManager.Tools[CT_ROW_DELETE];
            if (closeButton != null) closeButton.SharedProps.AppearancesSmall.Appearance.Image = Size24_Index.DELETE;

            // ツールバーをカスタマイズ不可にする
            ultraToolbarsManager.ToolbarSettings.AllowCustomize = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbarsManager.ToolbarSettings.AllowDockBottom = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbarsManager.ToolbarSettings.AllowDockLeft = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbarsManager.ToolbarSettings.AllowDockRight = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbarsManager.ToolbarSettings.AllowDockTop = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbarsManager.ToolbarSettings.AllowFloating = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbarsManager.ToolbarSettings.AllowHiding = Infragistics.Win.DefaultableBoolean.False;
        }
        #endregion

        #region UltraGridのUI設定を変更するメソッド
        /// <summary>
        /// UltraGridの配色を仕様通りに設定する
        /// </summary>
        /// <param name="ugTarget"></param>
        protected void setGridAppearance(Infragistics.Win.UltraWinGrid.UltraGrid ugTarget)
        {
            //タイトルの外観
            ugTarget.DisplayLayout.Override.HeaderAppearance.BackColor = Color.FromArgb(89, 135, 214);
            ugTarget.DisplayLayout.Override.HeaderAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            ugTarget.DisplayLayout.Override.HeaderAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            ugTarget.DisplayLayout.Override.HeaderAppearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            ugTarget.DisplayLayout.Override.HeaderAppearance.ForeColor = Color.White;

            //背景色を設定
            ugTarget.DisplayLayout.Appearance.BackColor = Color.White;

            //文字をカラムに入るように設定する
            ugTarget.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;

            //行セレクタの設定
            ugTarget.DisplayLayout.Override.RowSelectorAppearance.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            ugTarget.DisplayLayout.Override.RowSelectorAppearance.BackColor = Color.FromArgb(89, 135, 214);
            ugTarget.DisplayLayout.Override.RowSelectorAppearance.BackColor2 = Color.FromArgb(7, 59, 150);
            ugTarget.DisplayLayout.Override.RowSelectorAppearance.ForeColor = Color.White;

            //インジゲータ非表示
            ugTarget.DisplayLayout.Override.FixedHeaderIndicator = Infragistics.Win.UltraWinGrid.FixedHeaderIndicator.None;

            //分割領域非表示
            ugTarget.DisplayLayout.MaxColScrollRegions = 1;
            ugTarget.DisplayLayout.MaxRowScrollRegions = 1;

            //交互に行の色を変える
            ugTarget.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.FromArgb(192, 192, 255);

            //垂直スクロールバーのみ許可
            ugTarget.DisplayLayout.Scrollbars = Scrollbars.Vertical;

            //アクティブ行の外観を変える
            ugTarget.DisplayLayout.Override.ActiveRowAppearance.ForeColor = Color.Black;
            ugTarget.DisplayLayout.Override.ActiveRowAppearance.BackColor = Color.FromArgb(251, 230, 148);
            ugTarget.DisplayLayout.Override.ActiveRowAppearance.BackColor2 = Color.FromArgb(238, 149, 21);
            ugTarget.DisplayLayout.Override.ActiveRowAppearance.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;

            //最終行が一番上までいかないようにする
            ugTarget.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
        }


        /// <summary>
        /// UltraGridの挙動を設定する
        /// </summary>
        /// <param name="ugTarget"></param>
        protected void setGridBehavior(Infragistics.Win.UltraWinGrid.UltraGrid ugTarget)
        {
            //列幅の自動調整
            ugTarget.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;

            //行の追加不可
            ugTarget.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;

            //行の削除不可
            ugTarget.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;

            // 列の移動不可
            ugTarget.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed;

            // 列の交換不可
            ugTarget.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed;

            // フィルタの使用不可
            ugTarget.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.False;

            //選択方法を行選択に設定。
            ugTarget.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;

            //+列選択不可にすることでヘッダをクリックしても何も起こらない
            ugTarget.DisplayLayout.Override.SelectTypeCol = SelectType.None;

            //一行のみ選択可能にする
            ugTarget.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.Single;

            //スクロール中にもいまどこが見えている状態なのかがわかるようにする
            ugTarget.DisplayLayout.ScrollStyle = ScrollStyle.Immediate;

            //IME無効
            ugTarget.ImeMode = ImeMode.Disable;

            //ドラッグしても他のアイテムに移動しないようにする
            ugTarget.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.SingleAutoDrag;

        }
        #endregion

        #region 排他制御処理
        /// <summary>
        ///	排他制御処理
        /// </summary>
        /// <remarks>
        /// <br>Programmer		:	22011 柏原 頼人</br>
        /// <br>Note            :   ＤＢに排他制御が掛かっていた際にメッセージを表示しUI画面を閉じる</br>
        /// <br>Date			:	2007.04.13</br>
        /// </remarks>
        protected bool ExclusiveControl(int Status)
        {
            // 既に更新が掛かっていたとき
            if (Status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE)
            {
                TMsgDisp.Show(Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    PGID, "既に他端末より更新されています", 0, MessageBoxButtons.OK);
                return false;
            }
            // 既に削除されていたとき
            if (Status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)
            {
                TMsgDisp.Show(Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    PGID, "既に他端末で削除されています", 0, MessageBoxButtons.OK);
                return false;
            }
            return true;
        }
        #endregion

        #endregion

        #endregion

    }
}

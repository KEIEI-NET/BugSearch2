//****************************************************************************//
// システム         : プリンタ設定マスタ（サーバ用）
// プログラム名称   : プリンタ設定マスタ（サーバ用）ビュー
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2009/09/16  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Application.UIData.Other;
using Broadleaf.Application.UIData.Util;
using Broadleaf.Windows.Forms.Other;

namespace Broadleaf.Windows.Forms
{
    using ControllerType= ServerPrinterSettingController;
    using DataSetType   = ServerPrinterSettingDataSet;
    using DataTableType = ServerPrinterSettingDataSet.SrvPrtStDataTable;
    using DataRowType   = ServerPrinterSettingDataSet.SrvPrtStRow;
    using RecordType    = PrtManage;

    /// <summary>
    /// プリンタ設定マスタ（サーバ用）ビュークラス
    /// </summary>
    public sealed class ServerPrinterSettingView : ServerConfigurationView
    {
        /// <summary>名称</summary>
        private const string MY_NAME = "プリンタ設定マスタ(サーバ用)";  // LITERAL:

        #region <具象メンバ>

        /// <summary>具体的なコントローラ</summary>
        private ControllerType _myController;
        /// <summary>具体的なコントローラを取得します。</summary>
        private ControllerType MyController
        {
            get
            {
                if (_myController == null)
                {
                    _myController = new ControllerType();
                }
                return _myController;
            }
        }

        /// <summary>
        /// 具体的な表示テーブルを取得します。
        /// </summary>
        private DataTableType MyViewTable
        {
            get { return MyController.DBEntity.SrvPrtSt; }
        }

        #endregion // </具象メンバ>

        #region <Constructor>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        public ServerPrinterSettingView() : base()
        {
            Caption += MY_NAME;
        }

        #endregion // </Constructor>

        #region <Override>

        /// <summary>
        /// サーバ構成設定コントローラを生成します。
        /// </summary>
        /// <returns>プリンタ設定マスタ（サーバ用）のコントローラ</returns>
        protected override IServerConfigurationController CreateController()
        {
            return MyController;
        }

        #region <表示設定>

        /// <summary>
        /// 隠すカラム名のリストを生成します。
        /// </summary>
        /// <returns>隠すカラム名のリスト</returns>
        protected override List<string> CreateHideColumnNameList()
        {
            List<string> hideColumnNameList = new List<string>();
            {
                hideColumnNameList.Add(MyViewTable.CreateDateTimeColumn.ColumnName);    // 作成日時
                hideColumnNameList.Add(MyViewTable.UpdateDateTimeColumn.ColumnName);    // 更新日時
                hideColumnNameList.Add(MyViewTable.EnterpriseCodeColumn.ColumnName);    // 企業コード
                hideColumnNameList.Add(MyViewTable.GUIDColumn.ColumnName);              // GUID
                hideColumnNameList.Add(MyViewTable.UpdEmployeeCpdeColumn.ColumnName);   // 更新従業員コード
                hideColumnNameList.Add(MyViewTable.UpdAssemblyId1Column.ColumnName);    // 更新アセンブリID1
                hideColumnNameList.Add(MyViewTable.UpdAssemblyId2Column.ColumnName);    // 更新アセンブリID2
                hideColumnNameList.Add(MyViewTable.LogicalDeleteCodeColumn.ColumnName); // 論理削除区分
                hideColumnNameList.Add(MyViewTable.PrinterKindColumn.ColumnName);       // プリンタ種別

                if (!VisiblesDeletedData)
                {
                    hideColumnNameList.Add(MyViewTable.DeletedDateColumn.ColumnName);   // 削除日
                }
            }
            return hideColumnNameList;
        }

        /// <summary>
        /// 削除日カラムであるか判断します。
        /// </summary>
        /// <param name="columnName">カラム名</param>
        /// <returns>
        /// <c>true</c> :削除日カラムです。<br/>
        /// <c>false</c>:削除日カラムではありません。
        /// </returns>
        protected override bool IsDeletedDateColumn(string columnName)
        {
            return columnName.Equals(MyViewTable.DeletedDateColumn.ColumnName);
        }

        #endregion // </表示設定>

        /// <summary>
        /// 新規登録します。
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        protected override void OnNew(object sender, NewEventArgs e)
        {
            ShowDataInputDialog(PrtManageForm.EditMode.New);
        }

        /// <summary>
        /// 削除します。
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        protected override void OnDelete(object sender, DeleteEventArgs e)
        {
            RecordType foundRecord = MyController.Find(SelectedPrinterMngNo);
            if (foundRecord == null) return;

            if (EntityUtil.Deleted(foundRecord))
            {
                MessageBox.Show(
                    "選択中のデータは既に削除されています。",   // LITERAL:
                    Caption,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation
                );
                return;
            }

            DialogResult result = MessageBox.Show(
                "選択している行を削除しますか？",   // LITERAL:
                Caption,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2
            );
            if (result.Equals(DialogResult.Yes))
            {
                MyController.DoingRecord = foundRecord;
                MyController.DeleteRecord();
            }
        }

        /// <summary>
        /// 修正します。
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        protected override void OnEdit(object sender, EditEventArgs e)
        {
            ShowDataInputDialog(PrtManageForm.EditMode.Update);
        }

        #endregion // </Override>

        /// <summary>
        /// 選択されているのプリンタ管理Noを取得します。
        /// </summary>
        private int SelectedPrinterMngNo
        {
            get
            {
                try
                {
                    if (GridDB.Rows.Count > 0 && GridDB.SelectedRows.Count > 0)
                    {
                        return (int)GridDB.SelectedRows[0].Cells[MyViewTable.PrinterMngNoColumn.ColumnName].Value;
                    }
                    return ServerPrinterSettingController.NULL_PRINTER_MNG_NO;
                }
                catch (InvalidCastException)
                {
                    // 空白の行をダブルクリックした場合
                    return ServerPrinterSettingController.NULL_PRINTER_MNG_NO;
                }
                catch (NullReferenceException)
                {
                    // 空白の行を選択していた場合
                    return ServerPrinterSettingController.NULL_PRINTER_MNG_NO;
                }
            }
        }

        /// <summary>
        /// データの入力ダイアログを表示します。
        /// </summary>
        /// <param name="editMode">編集モード</param>
        private void ShowDataInputDialog(PrtManageForm.EditMode editMode)
        {
            // プリンタ管理Noが不定の場合、強制的に新規モードに設定
            if (SelectedPrinterMngNo.Equals(ServerPrinterSettingController.NULL_PRINTER_MNG_NO))
            {
                editMode = PrtManageForm.EditMode.New;
            }

            MyController.SetDoingRecord(SelectedPrinterMngNo);

            PrtManageForm dataInputForm = new PrtManageForm(MyController, editMode);
            {
                dataInputForm.ShowDialog(this);
            }
        }
    }
}

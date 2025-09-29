//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 掛率マスタインポート・エクスポートMDI子画面インターフェース
// プログラム概要   : 掛率マスタインポート・エクスポートMDI子画面インターフェース
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  ********-** 作成担当 : FSI菅原 庸平
// 作 成 日  2013/06/12  修正内容 : サポートツール対応、新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Windows.Forms;
using Broadleaf.Application.UIData;


namespace Broadleaf.Application.Common
{
    public delegate void ParentToolbarSettingEventHandler(object sender);

    public delegate void ExecCsvConvertEventHandler(object sender, ref int? result);
    
    /// <summary>
    /// インポート・エクスポートMDI子画面メイン画面インターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : </br>
    /// <br>Programmer : FSI菅原 庸平</br>
    /// <br>Date       : 2013/06/12</br>
    /// <br></br>
    /// </remarks>
    public interface ICSVExportConditionInpType
    {
        // Events
        event ParentToolbarSettingEventHandler ParentToolbarSettingEvent;
        event ExecCsvConvertEventHandler ExecCsvConvertEvent;

        // Methods
        int Extract(ref object parameter);
        int GetCSVInfo(ref object parameter);
        bool ExportBeforeCheck();
        void Show(object parameter);
        void GetBindDataSet(ref System.Data.DataSet bindDataSet, ref string tableName);
        void AfterExportSuccess();
    }

    /// <summary>
    /// インポート・エクスポートMDI子画面条件入力メイン画面インターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : </br>
    /// <br>Programmer : 菅原 庸平</br>
    /// <br>Date       : 2013/06/12</br>
    /// <br></br>
    /// </remarks>
    public interface ICSVImportConditionInpType
    {
        // Events
        event ParentToolbarSettingEventHandler ParentToolbarSettingEvent;

        // Methods
        void Show(object parameter);
        bool IsUseBaseCheck();
        string ImportFileName();
        bool ImportBeforeCheck();
        bool ItemCntCheck(int csvDataRowCnt);
        void CheckErrEvent();
        int Import(object csvDataList);
    }
}

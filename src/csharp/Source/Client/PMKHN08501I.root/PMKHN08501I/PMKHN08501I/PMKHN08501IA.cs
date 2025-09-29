using System;
using System.Windows.Forms;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Common
{
	#region ◆　マスタエクスポート・インポートMDI子画面インターフェース
	/// <summary>
	/// マスタエクスポート・インポートMDI子画面インターフェース
	/// </summary>
	/// <remarks>
	/// <br>Note       : </br>
	/// <br>Programmer : 30462 行澤 仁美</br>
	/// <br>Date       : 2008.10.24</br>
    /// <br>Update Note: 2009/05/12 李占川</br>
    /// <br>             エクスポート.インポートの追加</br>
	/// <br></br>
	/// </remarks>
	public interface IDemandTbsMDIChild
	{
		/// <summary>
		/// Control.Show メソッドのオーバーロード
		/// </summary>
		/// <param name="parameter">パラメータオブジェクト</param>
		void Show(object parameter);
	}
	#endregion
    
	#region ◆　マスタエクスポート・インポートMDI子画面条件入力メイン画面インターフェース
	/// <summary>
	/// マスタエクスポート・インポートMDI子画面条件入力メイン画面インターフェース
	/// </summary>
	/// <remarks>
	/// <br>Note       : </br>
	/// <br>Programmer : 30462 行澤 仁美</br>
	/// <br>Date       : 2008.10.24</br>
	/// <br></br>
	/// </remarks>
	public interface IDemandTbsMDIChildMain
	{
		/// <summary>
		/// Control.Show メソッドのオーバーロード
		/// </summary>
		/// <param name="parameter">パラメータオブジェクト</param>
		void Show(object parameter);
		
		/// <summary>
		/// 画面入力チェック処理
		/// </summary>
		/// <returns>[true:OK,false:NG]</returns>
		/// <remarks>
		/// <br>Note       : 画面の入力チェックを行います。
		/// <br>Programer  : 30462 行澤 仁美</br>
		/// <br>Date       : 2008.10.24</br>
		/// </remarks>
		bool ScreenInputCheck();
        
		/// <summary>
		/// データ抽出処理
		/// </summary>
		/// <param name="printKind">帳票種類[1:請求一覧,2:合計請求書,3:明細請求書]</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 画面の入力チェックを行います。
		/// <br>Programer  : 30462 行澤 仁美</br>
		/// <br>Date       : 2008.10.24</br>
		/// </remarks>
		int ExtractData(int printKind);

		/// <summary>
		/// 印刷処理
		/// </summary>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 印刷処理を行います。
		/// <br>Programer  : 30462 行澤 仁美</br>
		/// <br>Date       : 2008.10.24</br>
		/// </remarks>
        int Print(ref object parameter);
	
		/// <summary>
		/// 印刷書類変更処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 印刷書類変更時の処理を行います。
		/// <br>Programer  : 30462 行澤 仁美</br>
		/// <br>Date       : 2008.10.24</br>
		/// </remarks>
		void ChangePrintType(int printType);
	}
	#endregion
	
	#region ◆　マスタエクスポート・インポート印刷ActiveReportTypeインターフェース
	/// <summary>
	/// マスタエクスポート・インポート印刷ActiveReportTypeインターフェース
	/// </summary>
	/// <remarks>
	/// <br>Note       : </br>
	/// <br>Programmer : 30462 行澤 仁美</br>
	/// <br>Date       : 2008.10.24</br>
	/// <br></br>
	/// </remarks>
	public interface IDemandPrintActiveReportType
	{
		/// <summary>
		/// 印刷タイトル
		/// </summary>
		string Title
		{
			set;
		}
		
		/// <summary>
		/// 印刷情報パラメータプロパティ
		/// </summary>
		SFCMN06002C PrintInfo
		{
			get;
			set;
		}
		
		/// <summary>
		/// 印刷用初期設定情報設定
		/// </summary>
		/// <param name="conditionInfo">設定情報オブジェクト</param>
		/// <param name="message">エラーメッセージ</param>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : 印刷に必要な初期設定情報を設定します。
		/// <br>Programer  : 30462 行澤 仁美</br>
		/// <br>Date       : 2008.10.24</br>
		/// </remarks>
		int SetPrintConditionIno(object conditionInfo,out string message);
		
		/// <summary>
		/// 印刷用情報設定処理
		/// </summary>
		/// <param name="demandRelatedData">印刷用情報オブジェクト</param>
		/// <param name="message">エラーメッセージ</param>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : 直接バインドしない印刷時に必要な情報を設定します。
		/// <br>Programer  : 30462 行澤 仁美</br>
		/// <br>Date       : 2008.10.24</br>
		/// </remarks>
		int SetPrintRelatedData(object demandRelatedData,out string message);
	}
	#endregion


    public interface IPrintConditionInpType
    {
        // Events
        event ParentToolbarSettingEventHandler ParentToolbarSettingEvent;

        // Methods
        int Extract(ref object parameter);
        int Print(ref object parameter);
        bool PrintBeforeCheck();
        void Show(object parameter);
        void GetBindDataSet(ref System.Data.DataSet bindDataSet, ref string tableName);
        void SetGridStyle(ref Infragistics.Win.UltraWinGrid.UltraGrid UGrid);
        bool DataCheck();

        // Properties
        bool CanExtract { get; }
        bool CanPdf { get; }
        bool CanPrint { get; }
        bool VisibledExtractButton { get; }
        bool VisibledPdfButton { get; }
        bool VisibledPrintButton { get; }
    }


    public interface IPrintConditionInpTypePdfCareer
    {
        // Properties
        string PrintKey { get; }
        string PrintName { get; }
    }

    public interface IChartExtract
    {
        // Methods
        int GetChartInfo(object sender, object parameter, out ChartInfo chartInfo, out string msg);
        int GetDrillDownChartInfo(object sender, object parameter, out ChartInfo chartInfo, out string msg);
        int MakeChartData(object sender, object parameter, out string msg);
        int ShowCondition(object sender, object parameter);

        // Properties
        ChartParamater ChartParamater { get; set; }
    }


    public class ChartParamater
    {
        // Fields
        private bool _isCondtnButton;
        private bool _isDrillDown;
        private string _paramater;

        // Methods
        public ChartParamater()
        {
        }

        // Properties
        public bool IsCondtnButton
        {
            get
            {
                return this._isCondtnButton;
            }
            set
            {
                this._isCondtnButton = value;
            }
        }


        public bool IsDrillDown
        {
            get
            {
                return this._isDrillDown;
            }
            set
            {
                this._isDrillDown = value;
            }
        }

        public string Paramater
        {
            get
            {
                return this._paramater;
            }
            set
            {
                this._paramater = value;
            }
        }
 
    }



	#region ◆　デリゲート
	public delegate void SelectedPdfNodeEventHandler(string key, string printName, string pdfpath);

    public delegate void ParentToolbarSettingEventHandler(object sender);

	#endregion

    // --- ADD 2009/05/12 ------------------------------->>>>>
    /// <summary>
    /// マスタエクスポート・インポートMDI子画面（エクスポート）条件入力メイン画面インターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : </br>
    /// <br>Programmer : 李占川</br>
    /// <br>Date       : 2009.05.14</br>
    /// <br></br>
    /// </remarks>
    public interface IExportConditionInpType
    {
        // Events
        event ParentToolbarSettingEventHandler ParentToolbarSettingEvent;

        // Methods
        int Extract(ref object parameter);
        int GetCSVInfo(ref object parameter);
        bool ExportBeforeCheck();
        void Show(object parameter);
        void GetBindDataSet(ref System.Data.DataSet bindDataSet, ref string tableName);
        void AfterExportSuccess();
    }

    /// <summary>
    /// マスタエクスポート・インポートMDI子画面（インポート）条件入力メイン画面インターフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : </br>
    /// <br>Programmer : 李占川</br>
    /// <br>Date       : 2009.05.14</br>
    /// <br></br>
    /// </remarks>
    public interface IImportConditionInpType
    {
        // Events
        event ParentToolbarSettingEventHandler ParentToolbarSettingEvent;

        // Methods
        void Show(object parameter);
        bool IsUseBaseCheck();
        string ImportFileName();
        bool ImportBeforeCheck();
        void CheckErrEvent();
        int Import(object csvDataList);
    }
    // --- ADD 2009/05/12 ------------------------------<<<<<
}

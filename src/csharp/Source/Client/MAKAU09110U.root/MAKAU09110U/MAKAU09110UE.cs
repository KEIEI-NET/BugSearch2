using System;
using System.Collections;
using Broadleaf.Application.UIData;

namespace Broadleaf.Windows.Forms
{
	# region Delegate
	/// <summary>画面非表示イベント用デリゲート</summary>
	/// <param name="sender">イベントのソース</param>
	/// <param name="me">画面非表示イベントパラメータクラス<see cref="MasterMaintenanceUnDisplayingEventArgs"/></param>
	public delegate void MasterMaintenanceAccDmdTypeUnDisplayingEventHandler(object sender, MasterMaintenanceUnDisplayingEventArgs me);
	# endregion

	/// **********************************************************************
	/// public class name:	MAKAU09110UE
	///						MAKAU09110U.DLL                                    
	/// <summary>
	///						マスタメンテナンス得意先実績修正用インターフェイス
	/// </summary>
	/// ----------------------------------------------------------------------
	/// <remarks> 
	/// <br>note			:	マスタメンテナンス得意先実績修正用配列タイプのインターフェイスです。</br>
	/// <br>note			:	※ マスタメンテからを流用しました。</br>
    /// <br>Programmer      : 30154 安藤　昌仁</br>
    /// <br>Date            : 2007.04.18</br>
    /// </remarks>
	/// **********************************************************************
	public interface IMasterMaintenanceAccDmdType
	{
		# region Events
		/// <summary>画面非表示イベント</summary>
		/// <remarks>マスタメンテナンス得意先実績修正タイプの画面非表示イベントです。</remarks>
		event MasterMaintenanceAccDmdTypeUnDisplayingEventHandler UnDisplaying;
		# endregion

		# region Properties
		/// <summary>印刷可能設定プロパティ</summary>
		/// <value>印刷可能かどうかの設定を取得します。</value>
		bool CanPrint
		{
			get;
		}

		/// <summary>新規登録可能設定プロパティ</summary>
		/// <value>新規登録が可能かどうかの設定を取得します。</value>
		bool CanNew
		{
			get;
		}

		/// <summary>削除可能設定プロパティ</summary>
		/// <value>削除が可能かどうかの設定を取得します。</value>
		bool CanDelete
		{
			get;
		}

		/// <summary>画面終了設定プロパティ</summary>
		/// <value>画面クローズを許可するかどうかの設定を取得または設定します。</value>
		/// <remarks>falseの場合は、画面を閉じる際、CloseではなくHide(非表示)を実行します。</remarks>
		bool CanClose
		{
			get;
			set;
		}

		/// <summary>グリッドのデフォルト表示位置プロパティ</summary>
		/// <value>グリッドのデフォルト表示位置を取得します。</value>
		MGridDisplayLayout DefaultGridDisplayLayout
		{
			get;
		}

		/// <summary>操作対象データテーブル名称プロパティ</summary>
		/// <value>捜査対象データのテーブル名称を取得または設定します。</value>
		string TargetTableName
		{
			get;
			set;
		}

		/// <summary>拠点コードプロパティ</summary>
		/// <value>選択した拠点コードを取得または設定します。</value>
		string SectionCodeData
		{
			get;
			set;
		}
		
		/// <summary>得意先コードプロパティ</summary>
		/// <value>選択した得意先コードを取得または設定します。</value>
		int TargetCustomerCode
		{
			get;
			set;
		}

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        /// <summary>請求先コードプロパティ</summary>
        /// <value>選択した請求先コードを取得または設定します。</value>
        int TargetClaimCode
        {
            get;
            set;
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

		/// <summary>拠点情報表示可能設定プロパティ</summary>
		/// <value>拠点情報表示可能かどうかの設定を取得します。</value>
		bool Opt_SectionInfo
		{
			get;
		}
		/// <summary>自拠点拠点情報設定プロパティ</summary>
		/// <value>自拠点拠点情報設定を取得します。</value>
		string GetCompanySectionCode
		{
			get;
		}

		/// <summary>本社機能フラグプロパティ</summary>
		/// <value>本社機能フラグを取得します。</value>
		bool GetMainOfficeFuncMode
		{
			get;
		}
		# endregion

		# region Methods
		/// <summary>
		/// 論理削除データ抽出可能設定リスト取得処理
		/// </summary>
		/// <returns>論理削除データ抽出可能設定リスト</returns>
		/// <remarks>
		/// <br>Note       : 論理削除データの抽出が可能かどうかの設定を配列で取得します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		bool[] GetCanLogicalDeleteDataExtractionList();

		/// <summary>
		/// グリッドタイトルリスト取得処理
		/// </summary>
		/// <returns>グリッドタイトルリスト</returns>
		/// <remarks>
		/// <br>Note       : グリッドのタイトルを配列で取得します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		string[] GetGridTitleList();

		/// <summary>
		/// グリッドアイコンリスト取得処理
		/// </summary>
		/// <returns>グリッドアイコンリスト</returns>
		/// <remarks>
		/// <br>Note       : グリッドのアイコンを配列で取得します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		System.Drawing.Image[] GetGridIconList();

		/// <summary>
		/// グリッド列のサイズの自動調整のデフォルト値リスト取得処理
		/// </summary>
		/// <returns>グリッド列のサイズの自動調整のデフォルト値リスト</returns>
		/// <remarks>
		/// <br>Note       : グリッド列のサイズの自動調整チェックボックスのチェック有無のデフォルト値を配列で取得します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		bool[] GetDefaultAutoFillToGridColumnList();

		/// <summary>
		/// データテーブルの選択データインデックスリスト設定処理
		/// </summary>
		/// <param name="indexList">データテーブルの選択データインデックスリスト</param>
		/// <remarks>
		/// <br>Note       : データテーブルの選択データインデックスリストを設定します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		void SetDataIndexList(int[] indexList);


		/// <summary>
		/// 新規ボタンの有効設定リスト取得処理
		/// </summary>
		/// <returns>新規ボタンの有効設定リスト</returns>
		/// <remarks>
		/// <br>Note       : 新規ボタンの有効設定リストを取得します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		bool[] GetNewButtonEnabledList();

		/// <summary>
		/// 修正ボタンの有効設定リスト取得処理
		/// </summary>
		/// <returns>修正ボタンの有効設定リスト</returns>
		/// <remarks>
		/// <br>Note       : 修正ボタンの有効設定リストを取得します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		bool[] GetModifyButtonEnabledList();

		/// <summary>
		/// 削除ボタンの有効設定リスト取得処理
		/// </summary>
		/// <returns>削除ボタンの有効設定リスト</returns>
		/// <remarks>
		/// <br>Note       : 削除ボタンの有効設定リストを取得します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		bool[] GetDeleteButtonEnabledList();

		/// <summary>
		/// バインドデータセット取得処理
		/// </summary>
		/// <param name="bindDataSet">グリッド用データセット</param>
		/// <param name="tableName">データテーブル名称</param>
		/// <remarks>
		/// <br>Note       : グリッドにバインドさせるデータセットを取得します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		void GetBindDataSet(ref System.Data.DataSet bindDataSet, ref string[] tableName);
			
		/// <summary>
		/// 得意先データ検索処理
		/// </summary>
		/// <param name="totalCount">全該当件数</param>
		/// <param name="readCount">抽出対象件数</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 先頭から指定件数分のデータを検索します。また、全該当件数を取得することができます。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		int CustomerData_Search(ref int totalCount, int readCount);

		/// <summary>
		/// 指定得意先情報取得処理
		/// </summary>
        /// <param name="customerRet">得意先情報</param>
		/// <param name="customerCode">得意先コード</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 指定した得意先情報を検索します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		int ReadCustomerData(out CustomerSearchRet customerRet, int customerCode);

		/// <summary>
		/// 拠点情報検索処理
		/// </summary>
		/// <param name="retSecInfSetList">拠点情報配列格納</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 拠点情報を全て取得し、ArrayListにて結果を返します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		int SecInf_Search(out ArrayList retSecInfSetList);


		/// <summary>
		/// 請求金額情報データ検索処理
		/// </summary>
        /// <param name="claimCode">請求先コード</param>
		/// <param name="customerCode">得意先コード</param>
		/// <param name="addUpSecCode">拠点コード</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 指定した得意先・拠点の請求金額情報データを検索します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        //int DmdRec_Data_Search(int customerCode,string addUpSecCode);
        int DmdRec_Data_Search ( int claimCode, int customerCode, string addUpSecCode, int TargetDivType );
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

		/// <summary>
		/// 売掛金額情報データ検索処理
		/// </summary>
        /// <param name="claimCode">請求先コード</param>
		/// <param name="customerCode">得意先コード</param>
		/// <param name="addUpSecCode">拠点コード</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 指定した得意先・拠点の売掛金額情報データを検索します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        //int AccRec_Data_Search(int customerCode,string addUpSecCode);
        int AccRec_Data_Search(int claimCode, int customerCode, string addUpSecCode, int TargetDivType);
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
		
		/// <summary>
		/// 請求鑑の列名取得処理
		/// </summary>
		/// <param name="LABELList">鑑に使用する列名</param>
		/// <remarks>
		/// <br>Note       : 鑑に使用する列名を返します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		void  ReadTabelData_claim_panelSet( out string[] LABELList);

		/// <summary>
		/// Label表示用の金額カンマ編集
		/// </summary>
		/// <param name="val">金額</param>
		/// <param name="checkMode">編集文字数制限 true：ﾁｪｯｸする false:ﾁｪｯｸしない</param>
		/// <returns>金額文字対応結果</returns>
		/// <remarks>
		/// <br>Note       : Labelに表示する金額のカンマ編集を行います。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		string Claim_panelDataFormat(Int64 val , bool checkMode);
		
		/// <summary>
		/// データ削除処理
		/// </summary>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 選択中のデータを削除します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		int Delete();

		/// <summary>
		/// 印刷処理
		/// </summary>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 印刷処理を実行します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		int Print();

		/// <summary>
		/// グリッド列外観情報取得処理
		/// </summary>
		/// <returns>グリッド列外観情報格納Hashtable</returns>
		/// <remarks>
		/// <br>Note       : 各列の外見を設定するクラスを格納したHashtableを取得します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		void GetAppearanceTable(out System.Collections.Hashtable[] appearanceTable);

		/// <summary>
		/// グリッド列外観情報取得処理
		/// </summary>
		/// <returns>グリッド列外観情報格納Hashtable</returns>
		/// <remarks>
		/// <br>Note       : 各列の外見を設定するクラスを格納したHashtableを取得します。</br>
        /// <br>Programmer : 30154 安藤　昌仁</br>
        /// <br>Date       : 2007.04.18</br>
        /// </remarks>
		void GetDisPlayDisplayLayoutTable(ref Infragistics.Win.UltraWinGrid.UltraGrid targetGrid,string TABLE_NAME);
	

		# endregion
	}


}

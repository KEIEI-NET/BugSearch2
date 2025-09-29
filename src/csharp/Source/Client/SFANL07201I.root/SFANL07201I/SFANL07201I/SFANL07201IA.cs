using System;

namespace Broadleaf.Application.Common
{
	#region ◆　帳票業務(条件入力タイプ)共通インターフェース
	/// <summary>
	/// 帳票業務(条件入力タイプ)共通インターフェース
	/// </summary>
	/// <remarks>
	/// <br>Note       : 帳票業務(条件入力タイプ)の共通インターフェースです。</br>
	/// <br>Programmer : 18012 Y.Sasaki</br>
	/// <br>Date       : 2006.01.16</br>
	/// <br>Update Note: 2006.09.01 Y.Sasaki</br>
	/// <br>           : １.テキスト出力インタフェースの追加</br>
	/// </remarks>
	public interface IPrintConditionInpType
	{
		#region evrnt
		/// <summary>
		/// ツールバーボタン制御イベント
		/// </summary>
		/// <remarks>
		/// <br>Note       : フレームのボタン有効無効制御をしたい場合に発生させます。</br>
		/// <br>Programer  : 18012 Y.Sasaki</br>
		/// <br>Date       : 2006.01.16</br>
		/// </remarks>
		event ParentToolbarSettingEventHandler ParentToolbarSettingEvent;
		#endregion
        
		#region property
		/// <summary>印刷ボタン有効無効設定プロパティ</summary>
		/// <value>[True:有効,False:無効]</value>
		/// <remarks>印刷を許可するかどうかの設定を取得します。</remarks>
		bool CanPrint{get;}
        
		/// <summary>抽出ボタン有効無効設定プロパティ</summary>
		/// <value>[True:有効,False:無効]</value>
		/// <remarks>抽出を許可するかどうかの設定を取得します。</remarks>
		bool CanExtract{get;}

		/// <summary>PDFボタン有効無効設定プロパティ</summary>
		/// <value>[True:有効,False:無効]</value>
		/// <remarks>PDFボタンを許可するかどうかの設定を取得します。</remarks>
		bool CanPdf{get;}
        
		/// <summary>印刷ボタン表示設定プロパティ</summary>
		/// <value>[True:表示,False:非表示]</value>
		/// <remarks>印刷ボタンを表示するかどうかの設定を取得します。</remarks>
		bool VisibledPrintButton{get;}
        
		/// <summary>抽出ボタン表示設定プロパティ</summary>
		/// <value>[True:表示,False:非表示]</value>
		/// <remarks>抽出ボタンを表示するかどうかの設定を取得します。</remarks>
		bool VisibledExtractButton{get;}
		
		/// <summary>PDF出力ボタン表示設定プロパティ</summary>
		/// <value>[True:表示,False:非表示]</value>
		/// <remarks>PDF出力ボタンを表示するかどうかの設定を取得します。</remarks>
		bool VisibledPdfButton{get;}
		#endregion
        
		#region methods		
		/// <summary>
		/// 画面表示処理
		/// </summary>
		/// <param name="parameter">パラメータオブジェクト</param>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : object型の引数を受け取り、コントロールをユーザーに対して表示します。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.01.16</br>
		/// </remarks>
		void Show(object parameter);
    
		/// <summary>
		/// 印刷前入力チェック
		/// </summary>
		/// <param></param>
		/// <returns>[True:OK,False:NG]</returns>
		/// <remarks>
		/// <br>Note       : 印刷前の画面条件の入力チェックを行います。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.01.16</br>
		/// </remarks>
		bool PrintBeforeCheck();
    
		/// <summary>
		/// 印刷処理
		/// </summary>
		/// <param name="parameter">印刷情報パラメータ</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 印刷処理を行います。
		/// <br>Programer  : 18012 Y.Sasaki</br>
		/// <br>Date       : 2006.01.16</br>
		/// </remarks>
		int Print(ref object parameter);
		
		/// <summary>
		/// 抽出処理
		/// </summary>
		/// <param name="parameter">印刷情報パラメータ</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 抽出処理を行います。
		///                : 抽出処理が存在する場合などに実装して下さい。</br>
		/// <br>Programer  : 18012 Y.Sasaki</br>
		/// <br>Date       : 2006.01.16</br>
		/// </remarks>
		int Extract(ref object parameter);
		#endregion
	}
	#endregion
	
	#region ◆　帳票業務(条件入力タイプ)拠点選択インターフェース
	/// <summary>
	/// 帳票業務(条件入力タイプ)拠点選択インターフェース
	/// </summary>
	/// <remarks>
	/// <br>Note       : 拠点選択がある場合の共通インターフェースです。</br>
	/// <br>Programmer : 18012 Y.Sasaki</br>
	/// <br>Date       : 2006.01.17</br>
	/// <br>Update Note: 2006.03.22 Y.Sasaki</br>
	/// <br>           : １.拠点OP有無プロパティ追加</br>
	/// <br>           : ２.本社機能有無プロパティ追加 </br>
	/// </remarks>
	public interface IPrintConditionInpTypeSelectedSection
	{
		#region property
		/// <summary>計上拠点選択表示設定プロパティ</summary>
		/// <value>[True:表示,False:非表示]</value>
		/// <remarks>計上拠点を選択するかどうかの設定を取得します。</remarks>
		bool VisibledSelectAddUpCd{get;}
		
		/// <summary>拠点オプションプロパティ</summary>
		/// <value>[True:拠点OP有,False:拠点OP無]</value>
		/// <remarks>拠点オプション有無を設定します。</remarks>
		bool IsOptSection{get; set;}
		
		/// <summary>本社機能プロパティ</summary>
		/// <value>[True:本社機能,False:拠点機能]</value>
		/// <remarks>本社機能を設定します。</remarks>
		bool IsMainOfficeFunc{get; set;}

//		/// <summary>「全社」表示プロパティ</summary>
//		/// <value>[True:表示,False:非表示]</value>
//		/// <remarks>拠点リスト内に「全社」を表示・非表示を取得します。</remarks>
//		bool IsSectionALL{get;}
		#endregion

		#region methods		
		/// <summary>
		/// 初期拠点選択表示チェック処理
		/// </summary>
		/// <param name="isDefaultState">デフォルト表示状態</param>
		/// <returns>[True:表示,False:非表示]</returns>
		/// <remarks>
		/// <br>Note       : 拠点選択スライダーの表示有無を判定します。</br>
		///                : 拠点オプション、本社機能以外の個別の表示有無判定を行います。
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.01.17</br>
		/// </remarks>
		bool InitVisibleCheckSection(bool isDefaultState);
		
		/// <summary>
		/// 初期選択計上拠点設定処理
		/// </summary>
		/// <param name="addUpCd">計上拠点[1:実績 2:請求]</param>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : 初期選択情報を設定します。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.01.19</br>
		/// </remarks>
		void InitSelectAddUpCd(int addUpCd);

		/// <summary>
		/// 初期拠点設定処理
		/// </summary>
		/// <param name="sectionCodeLst">選択拠点リスト</param>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : 初期選択情報を設定します。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.01.19</br>
		/// </remarks>
		void InitSelectSection(string[] sectionCodeLst);
		
		/// <summary>
		/// 計上拠点選択処理
		/// </summary>
		/// <param name="addUpCd">計上拠点[1:実績 2:請求]</param>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : 計上拠点の選択状態変更時に処理します。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.01.17</br>
		/// </remarks>
		void SelectedAddUpCd(int addUpCd);
		
		/// <summary>
		/// 拠点選択処理
		/// </summary>
		/// <param name="sectionCode">拠点コード</param>
		/// <param name="checkState">選択状態</param>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : 拠点情報の選択状態変更時に処理します。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.01.17</br>
		/// </remarks>
		void CheckedSection(string sectionCode, System.Windows.Forms.CheckState checkState);
		#endregion
	}
	#endregion

	#region ◆　帳票業務(条件入力タイプ)カスタム拠点種類選択インターフェース
	/// <summary>
	/// 帳票業務(条件入力タイプ)カスタム拠点種類選択インターフェース
	/// </summary>
	/// <remarks>
	/// <br>Note       : 制御拠点に表示される内容をカスタマイズしたい場合のインターフェースです。</br>
	/// <br>Programmer : 18012 Y.Sasaki</br>
	/// <br>Date       : 2006.03.28</br>
	/// </remarks>
	public interface IPrintConditionInpTypeCustomSelectSectionKind
	{
		#region property
		/// <summary>タイトルプロパティ</summary>
		/// <remarks>表示するタイトルを取得します。</remarks>
		string Title{get;}
		
		
		/// <summary>制御拠点種類リスト</summary>
		/// <value>拠点種類クラスリスト</value>
		SectionKind[] CustomSectionKindList{get;}
		#endregion
	}
	
	#region ◆　拠点種類クラス
	/// <summary>
	/// 拠点種類クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 拠点種類のクラスです。</br>
	/// <br>Programmer : 18012 Y.Sasaki</br>
	/// <br>Date       : 2006.03.28</br>
	/// </remarks>
	public class SectionKind
	{
		#region Private Members
		private int _ctrlFuncCode;
		private string _ctrlFuncName = "";
		#endregion
	
		#region Constructor
		/// <summary>
		/// 拠点種類クラスコンストラクタ
		/// </summary>
		public SectionKind()
		{
		}
		
		/// <summary>
		/// 拠点種類クラスコンストラクタ
		/// </summary>
		/// <param name="CtrlFuncCode">制御機能コード</param>
		/// <param name="CtrlFuncName">制御拠点コード</param>
		/// <remarks>
		/// <br>Note       : 拠点種類のクラスです。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2006.03.28</br>
		/// </remarks>
		public SectionKind(int ctrlFuncCode, string ctrlFuncName)
		{
			this._ctrlFuncCode = ctrlFuncCode;
			this._ctrlFuncName = ctrlFuncName;
		}
		#endregion
	
		#region Propertys
		/// <summary>制御機能コード</summary>
		public int CtrlFuncCode
		{
			get{ return this._ctrlFuncCode; }
			set{ this._ctrlFuncCode = value;}
		}
	
		/// <summary>制御機能名称</summary>
		public string CtrlFuncName
		{
			get{ return this._ctrlFuncName; }
			set{ this._ctrlFuncName = value;}
		}
		#endregion
	}
	#endregion
	
	#endregion

	#region ◆　帳票業務(条件入力タイプ)システム選択インターフェース
	/// <summary>
	/// 帳票業務(条件入力タイプ)システム選択インターフェース
	/// </summary>
	/// <remarks>
	/// <br>Note       : システム選択がある場合の共通インターフェースです。</br>
	/// <br>Programmer : 18012 Y.Sasaki</br>
	/// <br>Date       : 2006.01.17</br>
	/// <br></br>
	/// </remarks>
	public interface IPrintConditionInpTypeSelectedSystem
	{
		#region property
//		/// <summary>「全システム」表示プロパティ</summary>
//		/// <value>[True:表示,False:非表示]</value>
//		/// <remarks>システムリスト内に「全システム」を表示・非表示を取得します。</remarks>
//		bool IsSystemALL{get;}
		#endregion
		
		#region methods		
		/// <summary>
		/// 初期システム選択表示チェック処理
		/// </summary>
		/// <param name="isDefaultState">デフォルト表示状態</param>
		/// <returns>[True:表示,False:非表示]</returns>
		/// <remarks>
		/// <br>Note       : システム選択スライダーの表示有無を判定します。</br>
		///                : 導入システム以外の個別の表示有無判定を行います。
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.01.17</br>
		/// </remarks>
		bool InitVisibleCheckSystem(bool isDefaultState);
		
		/// <summary>
		/// 初期選択システム設定処理
		/// </summary>
		/// <param name="sysCodeLst">選択システムリスト</param>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : 初期選択システム情報を設定します。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.01.19</br>
		/// </remarks>
		void InitSelectSystem(int[] sysCodeLst);
		
		/// <summary>
		/// システム選択処理
		/// </summary>
		/// <param name="sysCode">システムコード</param>
		/// <param name="checkState">選択状態</param>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : システムの選択状態変更時に処理します。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.01.17</br>
		/// </remarks>
		void CheckedSystem(int sysCode, System.Windows.Forms.CheckState checkState);
		#endregion
	}
	#endregion
	
	#region ◆　帳票業務(条件入力タイプ)PDF出力履歴インターフェース
	/// <summary>
	/// 帳票業務(条件入力タイプ)PDF出力履歴インターフェース
	/// </summary>
	/// <remarks>
	/// <br>Note       : PDF出力履歴がある場合の共通インターフェースです。</br>
	/// <br>Programmer : 18012 Y.Sasaki</br>
	/// <br>Date       : 2006.01.17</br>
	/// <br></br>
	/// </remarks>
	public interface IPrintConditionInpTypePdfCareer
	{
		#region property
		/// <summary>帳票KEYプロパティ</summary>
		/// <remarks>帳票の出力履歴取得用のKEY値を取得します。</remarks>
		string PrintKey{get;}
		
		/// <summary>帳票名プロパティ</summary>
		/// <remarks>帳票名を取得します。</remarks>
		string PrintName{get;}
		#endregion

		#region methods		
		#endregion
	}
	#endregion

	#region ◆　帳票業務(条件入力タイプ)抽出条件取得・設定インタフェース
	/// <summary>
	/// 帳票業務(条件入力タイプ)抽出条件取得インタフェース
	/// </summary>
	/// <remarks>
	/// <br>Note       : 帳票業務(条件入力タイプ)の抽出条件取得インターフェースです。</br>
	/// <br> １. 抽出条件クラスが ExtractionCondtnUI を継承している場合、このインタフェースを</br>
	/// <br>     実装する事でフレーム側で　ExtractionCondtnUI が設定されます。</br>
	/// <br>Programmer : 18012 Y.Sasaki</br>
	/// <br>Date       : 2006.03.27</br>
	/// <br></br>
	/// </remarks>
	public interface IPrintConditionInpTypeCondition
	{
		object ObjExtract{get;}
	}
	#endregion
	
	#region ◆　帳票業務(条件入力タイプ)抽出条件管理インターフェース
	/// <summary>
	/// 帳票業務(条件入力タイプ)抽出条件管理インターフェース
	/// </summary>
	/// <remarks>
	/// <br>Note       : 抽出条件を管理する場合のインターフェースです。</br>
	/// <br>Programmer : 18012 Y.Sasaki</br>
	/// <br>Date       : 2006.03.24</br>
	/// <br></br>
	/// </remarks>
	public interface IPrintConditionInpTypeConditionCtrl : IPrintConditionInpTypeCondition 
	{
		#region property
		/// <summary>抽出条件保存フラグ[T: 保存, F: 未保存]</summary>
		/// <remarks>抽出条を保存するかどうかを取得します。</remarks>
		bool IsConditionSave{get;}
		
		/// <summary>抽出条件型プロパティ</summary>
		/// <remarks>抽出条件クラスのTypeを取得します。</remarks>
		Type ObjType{get;}
		#endregion
	
		#region methods
		/// <summary>
		/// 前回抽出条件設定処理
		/// </summary>
		/// <param name="target">抽出条件クラス(前回抽出条件が存在しない場合: null)</param>
		/// <remarks>
		/// <br>Note       : 抽出条件を画面に設定します。</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2006.03.24</br>
		/// </remarks>
		void SetExtractCondition(object target);
		#endregion
	}
	#endregion　

	#region ◆　ツールバーボタン制御デリゲート
	/// <summary>
	/// ツールバーボタン制御
	/// </summary>
	/// <param name="sender"></param>
	/// <remarks>
	/// <br>Note       : 
	/// <br>Programer  : 18012 Y.Sasaki</br>
	/// <br>Date       : 2006.01.16</br>
	/// </remarks>
	public delegate void ParentToolbarSettingEventHandler(object sender);
	#endregion

	// >>>>> 2006.09.01 Y.Sasaki ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
	#region ◆　帳票業務(条件入力タイプ)テキスト出力インタフェース
	/// <summary>
	/// 帳票業務(条件入力タイプ)テキスト出力インタフェース
	/// </summary>
	/// <remarks>
	/// <br>Note       : テキスト出力がある場合の共通インターフェースです。</br>
	/// <br>Programmer : 18012 Y.Sasaki</br>
	/// <br>Date       : 2006.09.01</br>
	/// <br></br>
	/// </remarks>
	public interface IPrintConditionInpTypeTextOutPut
	{
		/// <summary>テキスト出力ボタン有効無効設定プロパティ</summary>
		/// <value>[True:有効,False:無効]</value>
		/// <remarks>テキスト出力ボタンを許可するかどうかの設定を取得します。</remarks>
		bool CanTextOutPut { get;}

		/// <summary>
		/// テキスト出力処理
		/// </summary>
		/// <param name="parameter">印刷情報パラメータ</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : テキスト出力処理を行います。
		/// <br>Programer  : 18012 Y.Sasaki</br>
		/// <br>Date       : 2006.09.01</br>
		/// </remarks>
		int OutPutText(ref object parameter);
	}
	#endregion
	// <<<<< 2006.09.01 Y.Sasaki ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //

    // >>>>> 2008.11.12 Y.Shinobu ADD START>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> //
    #region ◆　帳票業務(条件入力タイプ)実行インタフェース
    /// <summary>
    /// 帳票業務(条件入力タイプ)実行インタフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 更新処理がある場合の共通インターフェースです。</br>
    /// <br>Programmer : 30414 Y.Shinobu</br>
    /// <br>Date       : 2008.11.12</br>
    /// <br></br>
    /// </remarks>
    public interface IPrintConditionInpTypeUpdate
    {
        /// <summary>実行ボタン有効無効設定プロパティ</summary>
        /// <value>[True:有効,False:無効]</value>
        /// <remarks>実行ボタンを許可するかどうかの設定を取得します。</remarks>
        bool CanUpdate { get;}

        /// <summary>
        /// 実行処理
        /// </summary>
        /// <param name="parameter">印刷情報パラメータ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 更新処理を行います。
        //// <br>Programmer : 30414 Y.Shinobu</br>
        /// <br>Date       : 2008.11.12</br>
        /// </remarks>
        int Update(ref object parameter);
    }
    #endregion
    // <<<<< 2008.11.12 Y.Shinobu ADD END  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< //

    // --- 2010/08/16 ---------->>>>>
    /// <summary>
    /// ParentToolbarGuideSettingEventHandler
    /// </summary>
    /// <param name="sender"></param>
    public delegate void ParentToolbarGuideSettingEventHandler(bool enabled);

    /// <summary>
    /// ParentPrint
    /// </summary>
    /// <br>Note       : プリント用</br>
    /// <br>Programmer : 高峰</br>
    /// <br>Date       : 2010/08/26</br>
    public delegate void ParentPrint();

    #region ◆　F5：ガイドのインタフェース
    /// <summary>
    /// F5：ガイドのインタフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : F5：ガイドのインタフェースです。</br>
    /// <br>Programmer : 高峰</br>
    /// <br>Date       : 2010/08/16</br>
    /// <br></br>
    /// </remarks>
    public interface IPrintConditionInpTypeGuidExecuter
    {
        /// <summary>
        /// ガイドの表示非表示の設定
        /// </summary>
        event ParentToolbarGuideSettingEventHandler ParentToolbarGuideSettingEvent;

        // --- ADD 2010/08/26 ---------->>>>>
        /// <summary>
        /// プリント
        /// </summary>
        event ParentPrint ParentPrintCall;
        // --- ADD 2010/08/26 ----------<<<<<

        /// <summary>
        /// ガイド処理を実行する
        /// </summary>
        void ExcuteGuide(object sender, EventArgs e);
    }
    #endregion

    // --- 2010/08/16 ----------<<<<<

    // --- ADD licb K2014/03/10 FOR 信越自動車商会個別開発 テキスト出力機能を追加する --- >>>>>
    #region テキスト出力ボタンを制御
    /// <summary>
    /// TextOutControl
    /// </summary>
    /// <br>Note       : 信越テキスト出力ボタン制御用</br>
    /// <br>Programmer : licb</br>
    /// <br>Date       : K2014/03/10</br>
    public delegate void TextOutControl();

    /// <summary>
    /// 信越用のインタフェース
    /// </summary>
    /// <remarks>
    /// <br>Note       : 信越用のインタフェースです。</br>
    /// <br>Programmer : licb</br>
    /// <br>Date       : K2014/03/10</br>
    /// <br></br>
    /// </remarks>
    public interface IPrintConditionInpTypeTextOutControl
    {

        /// <summary>
        /// 制御用イベント
        /// </summary>
        event TextOutControl TextOutControlCall;
    }
    #endregion テキスト出力ボタンを制御
    // --- ADD licb K2014/03/10 FRO 信越自動車商会個別開発 テキスト出力機能を追加する --- <<<<<

}
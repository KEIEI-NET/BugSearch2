//****************************************************************************//
// システム         :  PM.NS
// プログラム名称   ： SCM企業・拠点連結設定ＵＩクラス
// プログラム概要   ： 
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 對馬 大輔
// 作 成 日  2011/05/25  修正内容 : 拠点名称をListへ変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30745　吉岡
// 更 新 日  2013/05/24  修正内容 : 2013/06/18配信予定　SCM№10533対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 脇田 靖之
// 更 新 日  2013/06/11  修正内容 : 編集モードが「削除モード」の場合、
//                                 「完全削除(D)」ボタンを非表示へ変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 脇田 靖之
// 更 新 日  2013/06/14  修正内容 : ①優先表示システムのコントロールを
//                                    ”RadioButton”から”UltraOptionSet”へ変更
//                                  ②優先表示システム「新規部品」を初期値に設定
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 更 新 日  2013/11/21  修正内容 : 商品保証課Redmine#674対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 更 新 日  2013/11/28  修正内容 : 商品保証課Redmine#711対応
//----------------------------------------------------------------------------//
// 管理番号：11070111-00 変更担当 : 18022 Ryo.
// 更 新 日：2014.09.11  変更内容 : FTC事業場対応
//                                : ①企業連結は、自動的に取り込まれる為、[新規(N)]不可
//                                : ②連結拠点は、OCEANのユーザーコード・名称を設定することで
//                                :   実際の事業場を登録できるように改良
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 31065 豊沢 憲弘
// 更 新 日  2014/11/18  修正内容 : SCM仕掛一覧No.10696対応
//----------------------------------------------------------------------------//
// 管理番号：11070111-00 変更担当 : 18022 Ryo.
// 更 新 日：2014.11.18  変更内容 : FTC事業場対応
//                                : ①企業・拠点連結設定－相手側SF拠点コードのリスト表示・選択
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Library.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

// SFCMN00001U...ｺﾝﾎﾟｰﾈﾝﾄ
// SFCMN00002C...TDateTime
// SFCMN00006C...ConstantManagement
// SFCMN00008C...ﾎﾞﾀﾝ画像関連
//×SFCMN00011I...HFileHeader
// SFCMN00013C...TStrConv
// SFCMN00036C
// SFCMN00039C...入力ｷｰﾁｪｯｸ
// SFCMN00212I
// SFCMN00615C...ｵﾌﾟｼｮﾝｺｰﾄﾞ
// SFCMN00651C...ﾛｸﾞｲﾝ情報取得
// SFCMN00654D...ｵﾌﾟｼｮﾝ取得ﾃﾞｰﾀｸﾗｽ
// SFCMN00660U...ﾊﾟｽﾜｰﾄﾞ確認画面

// SFCMN09003I...ﾏｽﾀﾒﾝﾃ用
// SFCMN09004C...ﾏｽﾀﾒﾝﾃ用
// SFKTN01210A..拠点情報SecInfoAcsｱｸｾｽｸﾗｽ
// SFKTN09001E...拠点情報SecInfoSet

namespace Broadleaf.Windows.Forms
{
	/// **********************************************************************
	/// <summary>
	/// SCM設定　ＵＩクラス
	/// </summary>
	/// ----------------------------------------------------------------------
	/// <remarks>
	/// <br>Note		: SCM企業・拠点連結を行います。
	///					  IMasterMaintenanceArrayTypeを実装しています。</br>   
	/// <br>Programmer	: 95094  大塚　たえ子</br>
	/// <br>Date		: 2009.05.22</br>
	/// <br></br>
	/// <br>Update Note : 2009.07.15 22024　寺坂　誉志</br>
	/// <br>			: １．構造を大幅に変更(コメント無しで修正)</br>
    /// <br>Update Note : 2011.07.21 duzg</br>
    /// <br>			: パスワード入力確認画面を追加する</br>
    /// <br>Update Note : 2011.08.12 x_zhuxk</br>
    /// <br>			: PCCUOE</br>
    /// <br>Update Note : 2011.10.13 呉軍</br>
    /// <br>			: Redmine#25912:１．更新モードで自社情報の拠点コードが存在しない場合、メッセージを表示するように修正</br>
	/// </remarks>
	/// **********************************************************************
	public partial class SFCMN02561UA : Form, IMasterMaintenanceArrayType
	{
		// ===================================================================================== //
		// コンストラクタ
		// ===================================================================================== //
		# region Constructor
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public SFCMN02561UA()
		{
			InitializeComponent();

			// データセット列情報構築処理
			DataSetColumnConstruction();

			this._scmEpCnectAcs				= new ScmEpCnectAcs();
			this._scmEpScCntAcs				= new ScmEpScCntAcs();
			this._secInfoAcs				= new SecInfoAcs();

			// フレームが使用するプロパティ
			this._canPrint					= false;
			this._canClose					= true;
			this._canNew					= true;
			this._canDelete					= true;
			this._canSpecificationSearch	= false;
			this._defaultGridDisplayLayout	= MGridDisplayLayout.Vertical;

			// 論理削除データ抽出フラグを設定する
			this._canMainLogicalDeleteDataExtraction	= true;
			this._canDetailsLogicalDeleteDataExtraction	= true;

			// 自動幅調整を設定する
			this._defaultAutoFillToMainGridColumn		= true;
			this._defaultAutoFillToDetailsGridColumn	= true;

			//　Gridタイトル名称
			this._mainGridTitle		= "連結企業";
			this._detailsGridTitle	= "連結拠点";

			this._targetTableName	= string.Empty;
			this._mainGridIcon		= null;
			this._detailsGridIcon	= null;

			//　企業コードを取得する
			this._enterpriseCode	= LoginInfoAcquisition.EnterpriseCode.TrimEnd();
			this._enterpriseName	= LoginInfoAcquisition.EnterpriseName.TrimEnd();
			this._companySecCode	= string.Empty;
			
            // Grid表示用テーブル
			this._scmEpCnectTable	= new Dictionary<string,ScmEpCnect>();
			this._scmEpScCntTable	= new Dictionary<string,ScmEpScCnt>();
            // 2014.09.11 ins by Ryo. -start- > > > > >
            // 提供側SCM事業場拠点連結マスタ
            this._oScmBPSCntTable = new Dictionary<string, OScmBPSCnt>();
            // 提供側SCM事業場連結マスタ
            this._oScmBPCntTable = new Dictionary<string, OScmBPCnt>();
            // 接続先NS拠点情報リスト
            this._cnectOrgNSSecInfoList = new List<CnectOrgNSSecInfo>() ;
            // 2014.09.11 ins by Ryo. -e n d- < < < < <

			//パスワード区分
			this._passWordview		= false;

			//GridIndexバッファ（メインフレーム最小化対応）
			this._mainDataIndex		= -1;
			this._detailsDataIndex	= -1;

			this._mainIndexBuf		= -2;
			this._detailsIndexBuf	= -2;
			this._targetTableBuf	= string.Empty;

            //SCMオプションチェック
            #region 旧ソース
            //_passWordview = true;// Del 2011.07.21 duzg for パスワード入力確認画面追加
            //if ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_SCM) > 0)
            //{
            //    // ﾊﾟｽﾜｰﾄﾞDLLCALL
            //    SFCMN00660UA passWordGuide = new SFCMN00660UA();
            //    string returnCode;
            //    string returnMessage;

            //    SFCMN00660UA.CheckPasswordResult result = passWordGuide.ShowPassConfirmDialog(SFCMN00660UA.PassWordTypes.OneTimePassOKNG, string.Empty, string.Empty, out returnCode, out returnMessage);
            //    if (result == SFCMN00660UA.CheckPasswordResult.Return_OK)
            //    {
            //        _passWordview = true;
            //    }
            //    else
            //    {
            //        _passWordview = false;

            //        string message = "パスワードが一致しませんでした。"
            //            + Environment.NewLine
            //            + Environment.NewLine
            //            + "参照モードで起動します。";
            //        TMsgDisp.Show(
            //            this, 								// 親ウィンドウフォーム
            //            emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
            //            ctASSEMBLY_ID, 						// アセンブリＩＤまたはクラスＩＤ
            //            message, 							// 表示するメッセージ
            //            0, 									// ステータス値
            //            MessageBoxButtons.OK);				// 表示するボタン
            //    }
            //}
            // --- Add 2011.07.21 duzg for パスワード入力確認画面追加 --->>>
            #endregion
            if ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_SCM) > 0)
            {
                // ﾊﾟｽﾜｰﾄﾞDLLCALL
                SFCMN00660UA passWordGuide = new SFCMN00660UA();
                string returnCode;
                string returnMessage;

                SFCMN00660UA.CheckPasswordResult result = passWordGuide.ShowPassConfirmDialog(SFCMN00660UA.PassWordTypes.OneTimePassOKNG, string.Empty, string.Empty, out returnCode, out returnMessage);
                
                string message = "パスワードが一致しませんでした。"
                        + Environment.NewLine
                        + Environment.NewLine
                        + "参照モードで起動します。";

#if DEBUG
                result = SFCMN00660UA.CheckPasswordResult.Return_OK;
#endif

                if (result == SFCMN00660UA.CheckPasswordResult.Return_OK)
                {
                    _passWordview = true;
                }
                else if (result == SFCMN00660UA.CheckPasswordResult.Return_NG)
                {
                    _passWordview = false;
                    TMsgDispMsg(message);
                }
                else
                {
                    message = "参照モードで起動します。";
                    TMsgDispMsg(message);
                }
            }

            // --- Add 2011.07.21 duzg for パスワード入力確認画面追加 ---<<<
		}

		#endregion

		// ===================================================================================== //
		// プライベートメンバー
		// ===================================================================================== //
		#region Private Menbers
		// アクセスクラス
		private ScmEpCnectAcs		_scmEpCnectAcs;	// SCM企業連結アクセスクラス
		private ScmEpScCntAcs		_scmEpScCntAcs;	// SCM企業拠点連結アクセスクラス
		private SecInfoAcs			_secInfoAcs;	// 拠点管理アクセスクラス

		// 企業コード
		private string				_enterpriseCode;
		private string				_enterpriseName;
		private string				_companySecCode;

        // 作業ハッシュテーブル
		private Dictionary<string, ScmEpCnect>	_scmEpCnectTable;
		private Dictionary<string, ScmEpScCnt>	_scmEpScCntTable;
        // 2014.09.11 ins by Ryo. -start- > > > > >
        // 提供側SCM事業場拠点連結マスタ
        private Dictionary<string, OScmBPSCnt> _oScmBPSCntTable;
        // 提供側SCM事業場連結マスタ
        private Dictionary<string, OScmBPCnt> _oScmBPCntTable;
        // 接続先NS拠点情報リスト
        private List<CnectOrgNSSecInfo> _cnectOrgNSSecInfoList;
        // 2014.09.11 ins by Ryo. -e n d- < < < < <

		// _GridIndexバッファ（メインフレーム最小化対応）
		private int					_mainIndexBuf;
		private int					_detailsIndexBuf;
		private string				_targetTableBuf;

		//パスワード区分
		private bool				_passWordview;

		// プロパティ用
		private bool				_canPrint;
		private bool				_canClose;
		private bool				_canNew;
		private bool				_canDelete;

		private string				_targetTableName;
		private int					_mainDataIndex;
		private int					_detailsDataIndex;
		private string				_mainGridTitle;
		private string				_detailsGridTitle;
		private Image				_mainGridIcon;
		private Image				_detailsGridIcon;

		private MGridDisplayLayout	_defaultGridDisplayLayout;

		private bool				_canMainLogicalDeleteDataExtraction;
		private bool				_canDetailsLogicalDeleteDataExtraction;
		private bool				_canSpecificationSearch;
		private bool				_defaultAutoFillToMainGridColumn;
		private bool				_defaultAutoFillToDetailsGridColumn;

		#endregion

		// ===================================================================================== //
		// 定数定義
		// ===================================================================================== //
		#region const 定義
		// フレームのView用Grid列のKEY情報 (ヘッダのタイトル部となります)
		//左側グリッド
		private const string ct_A_DELETEDIV			= "削除";
		private const string ct_A_DELETE_DATE		= "削除日";
		private const string ct_A_CNECTORGEPCD		= "相手企業コード";
		private const string ct_A_CNECTORGEPNM		= "相手企業名称";
		private const string ct_A_DISCDIVCD			= "種別区分";
		private const string ct_A_DISCDIVCDNM		= "種別";
		private const string ct_A_CNECTOTHEREPNM	= "自社名称";
		private const string ct_SCMEPCNECT_TABLE	= "ScmEpCnectTable";

		//右側グリッド
		private const string ct_B_DELETEDIV			= "削除";
		private const string ct_B_DELETE_DATE		= "削除日";
		private const string ct_B_CNECTORGEPCD		= "相手企業コード";
		private const string ct_B_CNECTORGEPNM		= "相手企業名称";
		private const string ct_B_CNECTORGSECCD		= "相手拠点コード";
		private const string ct_B_CNECTORGSECNM		= "相手拠点名称";
		private const string ct_B_DISCDIVCD			= "種別区分";
		private const string ct_B_DISCDIVCDNM		= "種別";
		private const string ct_B_CNECTOTHERSECNM	= "拠点名称";
		private const string ct_B_CNECTOTHERSECCD	= "拠点コード";
		private const string ct_SCMEPSCCNT_TABLE	= "ScmEpScCntTable";

		// 編集モード
		private const string INSERT_MODE		= "新規モード";
		private const string UPDATE_MODE		= "更新モード";
		private const string DELETE_MODE		= "削除モード";
		private const string REFER_MODE			= "参照モード";

		private const string ctASSEMBLY_ID		= "SFCMN02561U";
		private const string ctASSEMBLY_NAME	= "企業・拠点連結設定";

		#endregion

		// ===================================================================================== //
		// イベント
		// ===================================================================================== //
		# region Events
		/// <summary>
		/// 画面非表示イベント
		/// 画面が非表示状態になった際に発生します。
		/// </summary>
		public event MasterMaintenanceArrayTypeUnDisplayingEventHandler UnDisplaying;

		# endregion

		// ===================================================================================== //
		// public　プロパティ
		// ===================================================================================== //
		# region Properties
		/// <summary>
		/// 印刷可能かどうかの設定を取得します。
		/// </summary>
		public bool CanPrint
		{
			get { return this._canPrint; }
		}

		/// <summary>画面終了設定プロパティ</summary>
		/// <value>画面クローズを許可するかどうかの設定を取得または設定します。</value>
		/// <remarks>falseの場合は、画面を閉じる際、CloseではなくHide(非表示)を実行します。</remarks>
		public bool CanClose
		{
			get { return this._canClose; }
			set { this._canClose = value; }
		}

		/// <summary>新規登録可能設定プロパティ</summary>
		/// <value>新規登録が可能かどうかの設定を取得します。</value>
		public bool CanNew
		{
			get { return this._canNew; }
		}

		/// <summary>削除可能設定プロパティ</summary>
		/// <value>削除が可能かどうかの設定を取得します。</value>
		public bool CanDelete
		{
			get { return this._canDelete; }
		}

		/// <summary>グリッドのデフォルト表示位置プロパティ</summary>
		/// <value>グリッドのデフォルト表示位置を取得します。</value>
		public MGridDisplayLayout DefaultGridDisplayLayout
		{
			get { return this._defaultGridDisplayLayout; }
		}

		/// <summary>操作対象データテーブル名称プロパティ</summary>
		/// <value>操作対象データのテーブル名称を取得または設定します。</value>
		public string TargetTableName
		{
			get { return this._targetTableName; }
			set { this._targetTableName = value; }
		}

		/// <summary>メイン側の論理削除データ抽出可能設定プロパティ</summary>
		/// <value>メイン側の論理削除データの抽出が可能かどうかの設定を取得します。</value>
		public bool CanMainLogicalDeleteDataExtraction
		{
			get { return this._canMainLogicalDeleteDataExtraction; }
		}

		/// <summary>明細側の論理削除データ抽出可能設定プロパティ</summary>
		/// <value>明細側の論理削除データの抽出が可能かどうかの設定を取得します。</value>
		public bool CanDetailsLogicalDeleteDataExtraction
		{
			get { return this._canDetailsLogicalDeleteDataExtraction; }
		}

		/// <summary>データセットの選択データインデックスプロパティ</summary>
		/// <value>データセットの選択データインデックスを取得または設定します。</value>
		public int MainDataIndex
		{
			get { return this._mainDataIndex; }
			set { this._mainDataIndex = value; }
		}

		/// <summary>データセットの選択データインデックスプロパティ</summary>
		/// <value>データセットの選択データインデックスを取得または設定します。</value>
		public int DetailsDataIndex
		{
			get { return this._detailsDataIndex; }
			set { this._detailsDataIndex = value; }
		}

		/// <summary>メイングリッド列のサイズの自動調整のデフォルト値プロパティ</summary>
		/// <value>メイングリッド列のサイズの自動調整チェックボックスのチェック有無のデフォルト値を取得します。</value>
		public bool DefaultAutoFillToMainGridColumn
		{
			get { return this._defaultAutoFillToMainGridColumn; }
		}

		/// <summary>明細グリッド列のサイズの自動調整のデフォルト値プロパティ</summary>
		/// <value>明細グリッド列のサイズの自動調整チェックボックスのチェック有無のデフォルト値を取得します。</value>
		public bool DefaultAutoFillToDetailsGridColumn
		{
			get { return this._defaultAutoFillToDetailsGridColumn; }
		}

		/// <summary>件数指定抽出可能設定プロパティ</summary>
		/// <value>件数指定抽出を可能とするかどうかの設定を取得または設定します。</value>
		public bool CanSpecificationSearch
		{
			get { return this._canSpecificationSearch; }
		}

		# endregion

		// ===================================================================================== //
		// Public　メソッド
		// ===================================================================================== //
		#region Public Methods
		/// <summary>
		///  論理削除データ抽出可能設定リスト取得
		/// </summary>
		/// <returns>論理削除可否設定リスト</returns>
		/// <remarks>
		/// <br>Note		: 論理削除データ抽出の可・不可をリストにて取得</br>
		/// <br>Programmer	: 95094  大塚　たえ子</br>
		/// <br>Date		: 2009.05.22</br>
		/// </remarks>
		public bool[] GetCanLogicalDeleteDataExtractionList()
		{
			bool[] blRet = new bool[2];
			blRet[0] = true;
            // UPD 2013/11/21 商品保証課Redmine#674対応 ------------------------>>>>>
            //blRet[1] = true;
            blRet[1] = false;
            // UPD 2013/11/21 商品保証課Redmine#674対応 ------------------------<<<<<
            return blRet;
		}

		/// <summary>
		/// 自動列幅調整設定リスト取得
		/// </summary>
		/// <returns>自動列幅調整有無リスト</returns>
		/// <remarks>
		/// <br>Note		: 自動列幅調整の有無をリストにて取得</br>
		/// <br>Programmer	: 95094  大塚　たえ子</br>
		/// <br>Date		: 2009.05.22</br>
		/// </remarks>
		public bool[] GetDefaultAutoFillToGridColumnList()
		{
			bool[] blRet = new bool[2];
			blRet[0] = true;
			blRet[1] = true;
			return blRet;
		}

		/// <summary>
		/// 新規ボタン表示設定リスト取得
		/// </summary>
		/// <returns>新規ボタン表示有無設定リスト</returns>
		/// <remarks>
		/// <br>Note		: 新規ボタンの表示の有無設定をリストにて取得します</br>
		/// <br>Programmer	: 95094  大塚　たえ子</br>
		/// <br>Date		: 2009.05.22</br>
		/// </remarks>
		public bool[] GetNewButtonEnabledList()
		{
            if (this._passWordview == true)
            {
                // 2014.09.11 change by Ryo. -start- > > > > >
                // 企業連結 － [新規(N)]　押下不可
                // 企業連結 － [新規(N)]　押下 可

                //return new bool[2] { true, true };
                return new bool[2] { false, true };
                
                // 2014.09.11 change by Ryo. -e n d- < < < < <
            }
            else
            {
                return new bool[2] { false, false };
            }
		}

		/// <summary>
		/// 削除ボタン表示設定リスト取得
		/// </summary>
		/// <returns>削除ボタン表示有無設定リスト</returns>
		/// <remarks>
		/// <br>Note		: 削除ボタンの表示の有無設定をリストにて取得します</br>
		/// <br>Programmer	: 95094  大塚　たえ子</br>
		/// <br>Date		: 2009.05.22</br>
		/// </remarks>
		public bool[] GetDeleteButtonEnabledList()
		{
			if (this._passWordview == true)
				return new bool[2] { true, true };
			else
				return new bool[2] { false, false };
		}

		/// <summary>
		/// 修正ボタン表示設定リスト取得
		/// </summary>
		/// <returns>修正ボタン表示有無設定リスト</returns>
		/// <remarks>
		/// <br>Note		: 修正ボタンの表示の有無設定をリストにて取得します</br>
		/// <br>Programmer	: 95094  大塚　たえ子</br>
		/// <br>Date		: 2009.05.22</br>
		/// </remarks>
		public bool[] GetModifyButtonEnabledList()
		{
			bool[] blRet = new bool[2];
			blRet[0] = true;
			blRet[1] = true;
			return blRet;
		}

		/// <summary>
		/// 各テーブルタイトル取得
		/// </summary>
		/// <returns>各テーブルタイトル</returns>
		/// <remarks>
		/// <br>Note		: 各テーブル内容を表示するグリッドのタイトルを取得する</br>
		/// <br>Programmer	: 95094  大塚　たえ子</br>
		/// <br>Date		: 2009.05.22</br>
		/// </remarks>
		public string[] GetGridTitleList()
		{
			string[] strRet = new string[2];
			strRet[0] = this._mainGridTitle;
			strRet[1] = this._detailsGridTitle;
			return strRet;
		}

		/// <summary>
		///  各テーブル表示アイコン取得
		/// </summary>
		/// <returns>各テーブル表示アイコン</returns>
		/// <remarks>
		/// <br>Note		: 各テーブル内容を表示するグリッドのアイコンを取得する</br>
		/// <br>Programmer	: 95094  大塚　たえ子</br>
		/// <br>Date		: 2009.05.22</br>
		/// </remarks>
		public Image[] GetGridIconList()
		{
			Image[] objRet = new Image[2];
			objRet[0] = this._mainGridIcon;
			objRet[1] = this._detailsGridIcon;
			return objRet;
		}

		/// <summary>
		///	テーブルの選択データインデックスリスト設定処理
		/// </summary>
		/// <param name="indexList">データテーブルの選択データインデックスリスト</param>
		/// <remarks>
		/// <br>Note		:	データテーブルの選択データインデックスを設定します</br>
		/// <br>Programmer	: 95094  大塚　たえ子</br>
		/// <br>Date		: 2009.05.22</br>
		/// </remarks>
		public void SetDataIndexList(int[] indexList)
		{
			this._mainDataIndex = indexList[0];
			this._detailsDataIndex = indexList[1];
		}

		/// <summary>
		/// メインデータ検索処理
		/// </summary>
		/// <param name="totalCount">全該当件数</param>
		/// <param name="readCount">抽出対象件数</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: 先頭から指定件数分のデータを検索し、抽出結果を展開したDataSetと全該当件数を返します。</br>
		/// <br>Programmer	: 95094  大塚　たえ子</br>
		/// <br>Date		: 2009.05.22</br>
		/// </remarks>
		public int Search(ref int totalCount, int readCount)
		{
			int status = 0;
			this._scmEpCnectTable.Clear();

			try
			{
				List<ScmEpCnect> ScmEpCnectList;
				bool msgDiv;
				string errMsg;
				status = this._scmEpCnectAcs.SearchCnectOriginalEp(this._enterpriseCode, ConstantManagement.LogicalMode.GetData01, out ScmEpCnectList, out msgDiv, out errMsg);
				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						int index = 0;
						foreach (ScmEpCnect wkScmEpCnect in ScmEpCnectList)
						{
						    // UPD 2014/11/18 豊沢 SCM仕掛一覧No.10696 ---------->>>>>>>>>>
							//if (this._scmEpCnectTable.ContainsKey(wkScmEpCnect.CnectOtherEpCd) == false)
                            if (this._scmEpCnectTable.ContainsKey(wkScmEpCnect.CnectOriginalEpCd) == false)
						    // UPD 2014/11/18 豊沢 SCM仕掛一覧No.10696 ----------<<<<<<<<<<
							{
								ScmEpCnectToDataSet(wkScmEpCnect, index);
								++index;
							}
						}

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
							this._scmEpCnectAcs,				// エラーが発生したオブジェクト
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
							this._scmEpCnectAcs,         			 // エラーが発生したオブジェクト
							MessageBoxButtons.OK,		        	 // 表示するボタン
							MessageBoxDefaultButton.Button1);        // 初期表示ボタン
						break;
					}
				}

			}
			catch (Exception ex)
			{
				string message = "検索処理にて例外が発生しました。" + Environment.NewLine + ex.Message;
				TMsgDisp.Show(
					this,									// 親ウィンドウフォーム
					emErrorLevel.ERR_LEVEL_STOPDISP,		// エラーレベル
					ctASSEMBLY_ID,							// アセンブリＩＤまたはクラスＩＤ
					ctASSEMBLY_NAME,						// プログラム名称
					"Search",								// 処理名称
					TMsgDisp.OPE_GET,						// オペレーション
					message,								// 表示するメッセージ
					status,									// ステータス値
					 this._scmEpCnectAcs,					// エラーが発生したオブジェクト
					MessageBoxButtons.OK,					// 表示するボタン
					MessageBoxDefaultButton.Button1);		// 初期表示ボタン
			}

			return status;
		}

		/// <summary>
		/// メインネクストデータ検索処理
		/// </summary>
		/// <param name="readCount">抽出対象件数</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: 指定した件数分のネクストデータを検索します。(未実装)</br>
		/// <br>Programmer	: 95094  大塚　たえ子</br>
		/// <br>Date		: 2009.05.22</br>
		/// </remarks>
		public int SearchNext(int readCount)
		{
			int status = 0;

			return status;
		}

		/// <summary>
		///  明細データ検索処理
		/// </summary>
		/// <param name="totalCount">全該当件数</param>
		/// <param name="readCount">抽出対象件数</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: 先頭から指定件数分のデータを検索し、抽出結果を展開したDataSetと全該当件数を返します。</br>
		/// <br>Programmer	: 95094  大塚　たえ子</br>
		/// <br>Date		: 2009.05.22</br>
		/// </remarks>
		public int DetailsDataSearch(ref int totalCount, int readCount)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			try
			{
				this._bind_DataSet.Tables[ct_SCMEPSCCNT_TABLE].Rows.Clear();

				if (this._scmEpScCntTable.Count == 0)
				{
					// 拠点連結情報取得
					List<ScmEpScCnt> scmEpScCntList;
					bool msgDiv = false;
					string errMsg = string.Empty;

                    // 2014.09.11 change by Ryo. -start- > > > > >
                    //status = this._scmEpScCntAcs.SearchCnectOriginalEpFromSc(this._enterpriseCode, ConstantManagement.LogicalMode.GetData01, out scmEpScCntList, out msgDiv, out errMsg);

                    List<OScmBPSCnt> oScmBPSCntList;
                    List<OScmBPCnt> oScmBPCntList;
                    
                    status = this._scmEpScCntAcs.SearchCnectOrgEpFromScWithFTC(this._enterpriseCode, ConstantManagement.LogicalMode.GetData01, out scmEpScCntList, out oScmBPSCntList, out oScmBPCntList, out msgDiv, out errMsg);
                    // 2014.09.11 change by Ryo. -e n d- < < < < <

                    switch (status)
					{
						case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
						{
							foreach (ScmEpScCnt scmEpScCnt in scmEpScCntList)
								this._scmEpScCntTable.Add(MakeScmEpScCntTableContainsKey(scmEpScCnt), scmEpScCnt);
                            
                            // 2014.09.11 ins by Ryo. -start- > > > > >
                            foreach (OScmBPSCnt oScmBPSCnt in oScmBPSCntList)
                            {
                                if (this._oScmBPSCntTable.ContainsKey(MakeOScmBPSCntTableContainsKey(oScmBPSCnt)) == true)
                                {
                                    this._oScmBPSCntTable.Remove(MakeOScmBPSCntTableContainsKey(oScmBPSCnt));
                                }
                                this._oScmBPSCntTable.Add(MakeOScmBPSCntTableContainsKey(oScmBPSCnt), oScmBPSCnt);
                            }
                            foreach (OScmBPCnt oScmBPCnt in oScmBPCntList)
                            {
                                if (this._oScmBPCntTable.ContainsKey(MakeOScmBPCntTableContainsKey(oScmBPCnt)) == true)
                                {
                                    this._oScmBPCntTable.Remove(MakeOScmBPCntTableContainsKey(oScmBPCnt));
                                }
                                this._oScmBPCntTable.Add(MakeOScmBPCntTableContainsKey(oScmBPCnt), oScmBPCnt);
                            }
                            // 2014.09.11 ins by Ryo. -e n d- < < < < <
							break;
						}
						case (int)ConstantManagement.DB_Status.ctDB_EOF:
						{
							break;
						}
						case (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT:
						{
							string message = "SCM企業拠点連結データの読込みにてタイムアウトが発生しました。";
							if (msgDiv)
							{
								message = message + Environment.NewLine + Environment.NewLine + "*詳細 = " + errMsg;
							}

							TMsgDisp.Show(
								this,								// 親ウィンドウフォーム
								emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
								ctASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
								ctASSEMBLY_NAME,					// プログラム名称
								"DetailsDataSearch",				// 処理名称
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
								this,							               // 親ウィンドウフォーム
								emErrorLevel.ERR_LEVEL_STOPDISP,	           // エラーレベル
								ctASSEMBLY_ID,			            		   // アセンブリＩＤまたはクラスＩＤ
								ctASSEMBLY_NAME,					           // プログラム名称
								"DetailsDataSearch",				           // 処理名称
								TMsgDisp.OPE_GET,					           // オペレーション
								"企業・拠点連結データの検索に失敗しました。",  // 表示するメッセージ
								status,								           // ステータス値
								this._scmEpScCntAcs,				           // エラーが発生したオブジェクト
								MessageBoxButtons.OK,				           // 表示するボタン
								MessageBoxDefaultButton.Button1);              // 初期表示ボタン
							break;
						}
					}
				}

				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					// maint_Gridの選択拠点
					string cnectOriginalEpCd = this._bind_DataSet.Tables[ct_SCMEPCNECT_TABLE].Rows[this._mainDataIndex][ct_A_CNECTORGEPCD].ToString();

					List<ScmEpScCnt> scmEpScCntList = new List<ScmEpScCnt>(this._scmEpScCntTable.Values);

					int index = 0;
					foreach (ScmEpScCnt wkScmEpScCnt in scmEpScCntList)
					{
						if (wkScmEpScCnt.CnectOriginalEpCd.TrimEnd() == cnectOriginalEpCd.TrimEnd())
						{
							ScmEpScCntToDataSet(wkScmEpScCnt, index, false);
							++index;
						}
					}
				}
			}
			catch (Exception ex)
			{
				string message = "明細の検索処理にて例外が発生しました。" + Environment.NewLine + ex.Message;
				TMsgDisp.Show(
					this,								// 親ウィンドウフォーム
					emErrorLevel.ERR_LEVEL_STOPDISP,	// エラーレベル
					ctASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
					ctASSEMBLY_NAME,					// プログラム名称
					"DetailsDataSearch",				// 処理名称
					TMsgDisp.OPE_GET,					// オペレーション
					message,							// 表示するメッセージ
					status,								// ステータス値
					 this._scmEpScCntAcs,				// エラーが発生したオブジェクト
					MessageBoxButtons.OK,				// 表示するボタン
					MessageBoxDefaultButton.Button1);	// 初期表示ボタン
			}

			return status;
		}

		/// <summary>
		/// 明細ネクストデータ検索処理
		/// </summary>
		/// <param name="readCount">抽出対象件数</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: 指定した件数分のネクストデータを検索します。(未実装)</br>
		/// <br>Programmer	: 95094  大塚　たえ子</br>
		/// <br>Date		: 2009.05.22</br>
		/// </remarks>
		public int DetailsDataSearchNext(int readCount)
		{
			int status = 0;

			return status;
		}

		/// <summary>
		/// データ削除処理
		/// </summary>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: 選択中のデータを削除します。</br>
		/// <br>Programmer	: 95094  大塚　たえ子</br>
		/// <br>Date		: 2009.05.22</br>
		/// </remarks>
		public int Delete()
		{
			int status = 0;

			// 連結企業
			if (this._targetTableName == ct_SCMEPCNECT_TABLE)
			{
				// 連結企業コード取得
				string keyCode = this._bind_DataSet.Tables[ct_SCMEPCNECT_TABLE].Rows[this._mainDataIndex][ct_A_CNECTORGEPCD].ToString();
				ScmEpCnect scmEpCnect = this._scmEpCnectTable[keyCode];
				
				// 削除LogicalDelete
				bool msgDiv;
				string errMsg;
				ScmEpCnect[] scmEpCnects = new ScmEpCnect[1] { scmEpCnect };
				status = this._scmEpCnectAcs.LogicalDeleteScmEpCnect(ref scmEpCnects, out msgDiv, out errMsg);

				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						ScmEpCnectToDataSet(scmEpCnects[0], this._mainDataIndex);

						List<ScmEpScCnt> scmEpScCntList;
						status = this._scmEpScCntAcs.SearchSCMSection(this._enterpriseCode, scmEpCnects[0].CnectOtherEpCd, ConstantManagement.LogicalMode.GetData01, out scmEpScCntList, out msgDiv, out errMsg);
						if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
						{
							for (int ix = 0; ix != scmEpScCntList.Count; ix++)
								ScmEpScCntToDataSet(scmEpScCntList[ix], ix, true);
						}
						else
						{
							this._scmEpScCntTable.Clear();

							int totalCount = 0;
							DetailsDataSearch(ref totalCount, 0);
						}
						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
					case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
					{
						ExclusiveTransaction(status);
						return status;
					}
					default:
					{
						TMsgDisp.Show(
							this								// 親ウィンドウフォーム
							, emErrorLevel.ERR_LEVEL_STOPDISP	// エラーレベル
							, ctASSEMBLY_ID						// アセンブリIDまたはクラスID
							, ctASSEMBLY_NAME					// プログラム名称
							, "Delete"							// 処理名称
							, TMsgDisp.OPE_UPDATE				// オペレーション
							, "削除に失敗しました。"				// 表示するメッセージ
							, status							// ステータス
							, this._scmEpCnectAcs				// エラーが発生したオブジェクト
							, MessageBoxButtons.OK				// 表示するボタン
							, MessageBoxDefaultButton.Button1);	// 初期表示ボタン
						return status;
					}
				}
			}
            // 連結企業拠点
            else
			{
				ScmEpScCnt scmEpScCntkey = new ScmEpScCnt();

				MakeScmEpScCntKeyFormRowIndex(ref scmEpScCntkey, this._detailsDataIndex, this._targetTableName);

				ScmEpScCnt scmEpScCnt = this._scmEpScCntTable[MakeScmEpScCntTableContainsKey(scmEpScCntkey)];

				bool msgDiv;
				string errMsg;
				ScmEpScCnt[] scmEpScCnts = new ScmEpScCnt[1] { scmEpScCnt };
				status = this._scmEpScCntAcs.LogicalDeleteScmEpScCnt(ref scmEpScCnts, out msgDiv, out errMsg);

				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						ScmEpScCntToDataSet(scmEpScCnts[0], this._detailsDataIndex, true);
						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
					case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
					{
						ExclusiveTransaction(status);
						return status;
					}
					default:
					{
						TMsgDisp.Show(
							this								// 親ウィンドウフォーム
							, emErrorLevel.ERR_LEVEL_STOPDISP	// エラーレベル
							, ctASSEMBLY_ID						// アセンブリIDまたはクラスID
							, ctASSEMBLY_NAME					// プログラム名称
							, "Delete"							// 処理名称
							, TMsgDisp.OPE_UPDATE				// オペレーション
							, "削除に失敗しました。"				// 表示するメッセージ
							, status							// ステータス
							, this._scmEpScCntAcs				// エラーが発生したオブジェクト
							, MessageBoxButtons.OK				// 表示するボタン
							, MessageBoxDefaultButton.Button1);	// 初期表示ボタン
						return status;
					}
				}

			}

			return status;
		}

		/// <summary>
		/// グリッド列外観情報取得処理
		/// </summary>
		/// <returns>グリッド列外観情報格納Hashtable</returns>
		/// <remarks>
		/// <br>Note		: 各列の外見を設定するクラスを格納したHashtableを取得します。</br>
		/// <br>Programmer	: 95094  大塚　たえ子</br>
		/// <br>Date		: 2009.05.22</br>
		/// </remarks>
		public void GetAppearanceTable(out Hashtable[] appearanceTable)
		{
			appearanceTable = new Hashtable[2];

			Hashtable main_Table = new Hashtable();

			main_Table.Add(ct_A_DELETE_DATE,		new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, string.Empty, Color.Red));
			main_Table.Add(ct_A_DELETEDIV,			new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, string.Empty, Color.Black));
			main_Table.Add(ct_A_CNECTORGEPCD,		new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, string.Empty, Color.Black));
			main_Table.Add(ct_A_CNECTORGEPNM,		new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, string.Empty, Color.Black));
			main_Table.Add(ct_A_DISCDIVCDNM,		new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, string.Empty, Color.Black));
			main_Table.Add(ct_A_DISCDIVCD,			new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, string.Empty, Color.Black));
            main_Table.Add(ct_A_CNECTOTHEREPNM,     new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, string.Empty, Color.Black));

			appearanceTable[0] = main_Table;

			// サブグリッドの列外観情報設定
			Hashtable sub_Table = new Hashtable();

			sub_Table.Add(ct_B_DELETE_DATE,			new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, string.Empty, Color.Red));
			sub_Table.Add(ct_B_DELETEDIV,			new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, string.Empty, Color.Black));
			sub_Table.Add(ct_A_CNECTORGEPCD,		new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, string.Empty, Color.Black));
			sub_Table.Add(ct_A_CNECTORGEPNM,		new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, string.Empty, Color.Black));
			sub_Table.Add(ct_B_CNECTORGSECCD,		new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, string.Empty, Color.Black));
			sub_Table.Add(ct_B_CNECTORGSECNM,		new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, string.Empty, Color.Black));
			sub_Table.Add(ct_B_DISCDIVCDNM,			new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, string.Empty, Color.Black));
			sub_Table.Add(ct_B_DISCDIVCD,			new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, string.Empty, Color.Black));
			sub_Table.Add(ct_B_CNECTOTHERSECCD, 	new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, string.Empty, Color.Black));
			sub_Table.Add(ct_B_CNECTOTHERSECNM, 	new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, string.Empty, Color.Black));

			appearanceTable[1] = sub_Table;
		}

		/// <summary>
		/// バインドデータセット取得処理
		/// </summary>
		/// <param name="bindDataSet"></param>
		/// <param name="TableName"></param>
		/// <remarks>
		/// <br>Note		: グリッドにバインドさせるデータセットを取得します。</br>
		/// <br>Programmer	: 95094  大塚　たえ子</br>
		/// <br>Date		: 2009.05.22</br>
		/// </remarks>
		public void GetBindDataSet(ref DataSet bindDataSet, ref string[] TableName)
		{
			bindDataSet = this._bind_DataSet;

			// テーブル名取得
			string[] strRet = new string[2];
			strRet[0] = ct_SCMEPCNECT_TABLE;
			strRet[1] = ct_SCMEPSCCNT_TABLE;

			TableName = strRet;
		}

		/// <summary>
		/// 印刷処理
		/// </summary>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: 印刷処理を実行します。</br>
		/// <br>Programmer	: 95094  大塚　たえ子</br>
		/// <br>Date		: 2009.05.22</br>
		/// </remarks>
		public int Print()
		{
			// 印刷用アセンブリをロードする（未実装）
			return 0;
		}
		#endregion

		#region Control Events

		// ===================================================================================== //
		// 画面イベント
		// ===================================================================================== //
		#region 画面イベント

		/// **********************************************************************
		/// <summary>
		/// Form.Load イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>Note　　　 : ユーザーがフォームを読み込むときに発生します。</br>
		/// <br>Programmer	: 95094  大塚　たえ子</br>
		/// <br>Date		: 2009.05.22</br>
		/// </remarks>
		/// **********************************************************************
		private void SFCMN02561UA_Load(object sender, System.EventArgs e)
		{
			// 画面初期設定処理
			ScreenInitialSetting();
		}

		/// **********************************************************************
		/// <summary>
		/// Control.VisibleChanged イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>Note　　　 : フォームの表示状態が変わったときに発生します。</br>
		/// <br>Programmer	: 95094  大塚　たえ子</br>
		/// <br>Date		: 2009.05.22</br>
		/// </remarks>
		/// **********************************************************************
		private void SFCMN02561UA_VisibleChanged(object sender, System.EventArgs e)
		{
			if (this.Visible == false)
			{
				this.Owner.Activate();
				return;
			}

			if (_mainDataIndex == _mainIndexBuf &&
				_detailsIndexBuf == _detailsDataIndex &&
				_targetTableBuf == _targetTableName)
				return;

			//画面クリア処理
			ScreenClear();

			//タイマーOn
			Initial_Timer.Enabled = true;
		}

		/// **********************************************************************
		/// <summary>
		/// Form.Closing イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">キャンセルできるイベントのデータを提供するクラス</param>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>Note		: フォームを閉じる前に、ユーザーがフォームを閉じようとしたときに発生します。</br>
		/// <br>Programmer	: 95094  大塚　たえ子</br>
		/// <br>Date		: 2009.05.22</br>
		/// </remarks>
		/// **********************************************************************
		private void SFCMN02561UA_FormClosing(object sender, FormClosingEventArgs e)
		{
			// 最小化判定フラグの初期化
			this._mainIndexBuf	  = -2;
			this._detailsIndexBuf = -2;
			this._targetTableBuf  = string.Empty;

			// 画面クリア処理
			ScreenClear();

			// CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルして
			// フォームを非表示化する。（フォームの「×」をクリックされた場合の対応です。）
			if (CanClose == false)
			{
				e.Cancel = true;
				this.Hide();
			}
		}

		/// **********************************************************************
		/// <summary>
		/// Timer.Tick イベント(Initial_Timer)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>Note		: 指定された間隔の時間が経過したときに発生します。
		///					  この処理は、システムが提供するスレッド プール
		///					  スレッドで実行されます。</br>
		/// <br>Programmer	: 95094  大塚　たえ子</br>
		/// <br>Date		: 2009.05.22</br>
		/// </remarks>
		/// **********************************************************************
		private void Initial_Timer_Tick(object sender, EventArgs e)
		{
			// タイマーOff
			Initial_Timer.Enabled = false;
			// 画面再構築処理
			ScreenReconstruction();
		}

		#endregion

		// ===================================================================================== //
		// コントロールイベント
		// ===================================================================================== //
		#region コントロールイベント

		/// **********************************************************************
		/// <summary>
		/// Close_Button_Click
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>Note		: 閉じるボタンを選択したときに発生します。</br>
		/// <br>Programmer	: 95094  大塚　たえ子</br>
		/// <br>Date		: 2009.05.22</br>
		/// </remarks>
		/// **********************************************************************
		private void Close_Button_Click(object sender, EventArgs e)
		{
			this.Close_Button.Focus();
			
			string message = string.Empty;
			bool changeDataflg = false;

			// 変更が存在しているかチェック
            // ADD 2013/11/21 2013/12/04配信予定ｼｽﾃﾑﾃｽﾄ障害№23対応 -------------------->>>>>
            // 参照モード以外の時
            if (this.Mode_Label.Text != REFER_MODE)
            {
            // ADD 2013/11/21 2013/12/04配信予定ｼｽﾃﾑﾃｽﾄ障害№23対応 --------------------<<<<<
                if (this._targetTableName == ct_SCMEPCNECT_TABLE)
                    changeDataflg = IsChangeDataA();
                else
                    changeDataflg = IsChangeDataB();
            } // ADD 2013/11/21 2013/12/04配信予定ｼｽﾃﾑﾃｽﾄ障害№23対応

			// 画面情報が変更されていた場合は、保存確認メッセージを表示する
			if (changeDataflg == true)
			{
				DialogResult res = TMsgDisp.Show(this,	// 親ウィンドウフォーム
					emErrorLevel.ERR_LEVEL_SAVECONFIRM,	// エラーレベル
					ctASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
					null,								// 表示するメッセージ
					0,									// ステータス値
					MessageBoxButtons.YesNoCancel);		// 表示するボタン

				switch (res)
				{
					case DialogResult.Yes:
					{
						// 全画面に反映する処理
						bool retStatus;
						if (this._targetTableName == ct_SCMEPCNECT_TABLE)
							retStatus = SaveScmEpCnect();
						else
							retStatus = SaveScmEpScCnt();

						if (retStatus == false)
							return;
						break;
					}
					case DialogResult.No:
					{
						break;
					}
					default:
					{
						return;
					}
				}
			}

			// 画面非表示イベント
			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.Cancel);
				UnDisplaying(this, me);
			}

			this.DialogResult = DialogResult.Cancel;

			// 最小化判定フラグの初期化
			this._mainIndexBuf		= -2;
			this._detailsIndexBuf	= -2;
			this._targetTableBuf	= string.Empty;

			ScreenClear();

			// CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルして
			// フォームを非表示化する。
			if (CanClose == true)
				this.Close();
			else
				this.Hide();
		}

		/// **********************************************************************
		/// <summary>
		/// Delete_Button_Click
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>Note		: 削除ボタンを選択したときに発生します。</br>
		/// <br>Programmer	: 95094  大塚　たえ子</br>
		/// <br>Date		: 2009.05.22</br>
		/// </remarks>
		/// **********************************************************************
		private void Delete_Button_Click(object sender, EventArgs e)
		{
			this.Delete_Button.Focus();

			if (DeleteProc() != true) return;

			// 画面非表示イベント
			if (this.UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me
					= new MasterMaintenanceUnDisplayingEventArgs(DialogResult.Cancel);
				UnDisplaying(this, me);
			}

			this.DialogResult = DialogResult.OK;

			this._mainIndexBuf		= -2;
			this._detailsIndexBuf	= -2;
			this._targetTableBuf	= string.Empty;

			// CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルして
			// フォームを非表示化する。
			if (CanClose == true)
				this.Close();
			else
				this.Hide();
		}

		/// **********************************************************************
		/// <summary>
		/// Revival_Button_Click
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>Note		: 復活ボタンを選択したときに発生します。</br>
		/// <br>Programmer	: 22024  寺坂　誉志</br>
		/// <br>Date		: 2009.07.15</br>
		/// </remarks>
		/// **********************************************************************
		private void Revival_Button_Click(object sender, EventArgs e)
		{
			this.Revival_Button.Focus();

			if (RevivalProc() != true) return;

			// 画面非表示イベント
			if (this.UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me
					= new MasterMaintenanceUnDisplayingEventArgs(DialogResult.Cancel);
				UnDisplaying(this, me);
			}

			this.DialogResult = DialogResult.OK;

			this._mainIndexBuf		= -2;
			this._detailsIndexBuf	= -2;
			this._targetTableBuf	= string.Empty;

			// CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルして
			// フォームを非表示化する。
			if (CanClose == true)
				this.Close();
			else
				this.Hide();
		}

		/// **********************************************************************
		/// <summary>
		/// Save_Button_Click
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>Note		: 保存ボタンを選択したときに発生します。</br>
		/// <br>Programmer	: 95094  大塚　たえ子</br>
		/// <br>Date		: 2009.05.22</br>
		/// </remarks>
		/// **********************************************************************
		private void Save_Button_Click(object sender, EventArgs e)
		{
			this.Save_Button.Focus();

			if (this._targetTableName == ct_SCMEPCNECT_TABLE)
			{
				if (SaveScmEpCnect() == true)
				{
					if (this.Mode_Label.Text == INSERT_MODE)
					{
						this._mainDataIndex = -1;

						this.Initial_Timer.Enabled = true;
					}
					else
					{
						if (UnDisplaying != null)
						{
							MasterMaintenanceUnDisplayingEventArgs me
								= new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
							UnDisplaying(this, me);
						}

						this.DialogResult = DialogResult.OK;

						this._mainIndexBuf		= -2;
						this._detailsIndexBuf	= -2;
						this._targetTableBuf	= string.Empty;

						// CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルして
						// フォームを非表示化する。
						if (CanClose == true)
							this.Close();
						else
							this.Hide();
					}
				}
			}
			else
			{
				if (SaveScmEpScCnt() == true)
				{
					if (this.Mode_Label.Text == INSERT_MODE)
					{
						this._detailsDataIndex = -1;

						this.Initial_Timer.Enabled = true;
					}
					else
					{
						if (UnDisplaying != null)
						{
							MasterMaintenanceUnDisplayingEventArgs me
								= new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
							UnDisplaying(this, me);
						}

						this.DialogResult = DialogResult.OK;

						this._mainIndexBuf		= -2;
						this._detailsIndexBuf	= -2;
						this._targetTableBuf	= string.Empty;

						// CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルして
						// フォームを非表示化する。
						if (CanClose == true)
							this.Close();
						else
							this.Hide();
					}
				}
			}
		}

		/// **********************************************************************
		/// <summary>
		/// OriginalScCd_tComboEditor_SelectionChangeCommitted
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>Note		: 選択が変更された後に発生します。</br>
		/// <br>Programmer	: 22024  寺坂　誉志</br>
		/// <br>Date		: 2009.07.15</br>
		/// </remarks>
		/// **********************************************************************
		private void OriginalScCd_tComboEditor_SelectionChangeCommitted(object sender, EventArgs e)
		{
            //this.OtherScNm_tEdit.Text = this.OtherScCd_tComboEditor.Text.TrimEnd();  // 2014.09.11 del by Ryo.

            // 2014.09.11 ins by Ryo. -start- > > > > >
			foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
			{
				if (secInfoSet.SectionCode.TrimEnd() == this.OtherScCd_tComboEditor.Value.ToString().TrimEnd())
				{
                    this.OtherScNm_tEdit.Text = secInfoSet.SectionGuideNm;
                    break;
                }
			}
            // 2014.09.11 ins by Ryo. -e n d- < < < < <
        }

		#endregion

		#endregion

		// ===================================================================================== //
		// Private　メソッド
		// ===================================================================================== //
		# region Private Methods

		# region データ展開処理

		/// **********************************************************************
		/// Module name		:	ScmEpCnectToDataSe
		/// <summary>
		/// 連結企業オブジェクトデータセット展開処理
		/// </summary>
		/// <param name="scmEpCnect">連結企業オブジェクト</param>
		/// <param name="index">データセットへ展開するインデックス</param>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>Note        : 連結企業クラスをデータセットに格納します。</br>
		/// <br>Programmer	: 95094  大塚　たえ子</br>
		/// <br>Date		: 2009.05.22</br>
		/// </remarks>
		/// **********************************************************************
		private void ScmEpCnectToDataSet(ScmEpCnect scmEpCnect, int index)
		{
			DataRow dataRow;
			if (index < 0 || this._bind_DataSet.Tables[ct_SCMEPCNECT_TABLE].Rows.Count <= index)
			{
				// 新規と判断して、行を追加する
				dataRow = this._bind_DataSet.Tables[ct_SCMEPCNECT_TABLE].NewRow();
				this._bind_DataSet.Tables[ct_SCMEPCNECT_TABLE].Rows.Add(dataRow);
			}
			else
			{
				dataRow = this._bind_DataSet.Tables[ct_SCMEPCNECT_TABLE].Rows[index];
			}

			if (scmEpCnect.LogicalDeleteCode == 0)
				dataRow[ct_A_DELETE_DATE] = string.Empty;
			else
				dataRow[ct_A_DELETE_DATE] = scmEpCnect.UpdateDateTimeJpInFormal;

			dataRow[ct_A_CNECTORGEPCD] = scmEpCnect.CnectOriginalEpCd;
			dataRow[ct_A_CNECTORGEPNM] = scmEpCnect.CnectOriginalEpNm;

			dataRow[ct_A_CNECTOTHEREPNM] = scmEpCnect.CnectOtherEpNm;
			if (scmEpCnect.DiscDivCd == 0)
				dataRow[ct_A_DISCDIVCDNM] = "有効";
			else
				dataRow[ct_A_DISCDIVCDNM] = "無効";
			dataRow[ct_A_DISCDIVCD] = scmEpCnect.DiscDivCd;

			if (this._scmEpCnectTable.ContainsKey(scmEpCnect.CnectOriginalEpCd) == true)
			{
				this._scmEpCnectTable.Remove(scmEpCnect.CnectOriginalEpCd);
			}
			this._scmEpCnectTable.Add(scmEpCnect.CnectOriginalEpCd, scmEpCnect);
		}

		/// **********************************************************************
		/// Module name		:	ScmEpCnectToDataSe
		/// <summary>
		/// 連結企業・拠点オブジェクトデータセット展開処理
		/// </summary>
		/// <param name="scmEpScCnt">連結企業拠点オブジェクト</param>
		/// <param name="index">データセットへ展開するインデックス</param>
		/// <param name="updateCache">キャッシュの更新フラグ</param>
		/// <remarks>
		/// ----------------------------------------------------------------------
		/// <br>Note        : 連結企業・拠点クラスをデータセットに格納します。</br>
		/// <br>Programmer	: 95094  大塚　たえ子</br>
		/// <br>Date		: 2009.05.22</br>
		/// </remarks>
		/// **********************************************************************
		private void ScmEpScCntToDataSet(ScmEpScCnt scmEpScCnt, int index, bool updateCache)
		{
			DataRow dataRow;
			if (index < 0 || this._bind_DataSet.Tables[ct_SCMEPSCCNT_TABLE].Rows.Count <= index)
			{
				// 新規と判断して、行を追加する
				dataRow = this._bind_DataSet.Tables[ct_SCMEPSCCNT_TABLE].NewRow();
				this._bind_DataSet.Tables[ct_SCMEPSCCNT_TABLE].Rows.Add(dataRow);
			}
			else
			{
				dataRow = this._bind_DataSet.Tables[ct_SCMEPSCCNT_TABLE].Rows[index];
			}

			if (scmEpScCnt.LogicalDeleteCode == 0)
				dataRow[ct_B_DELETE_DATE] = string.Empty;
			else
				dataRow[ct_B_DELETE_DATE] = scmEpScCnt.UpdateDateTimeJpInFormal;

			dataRow[ct_B_CNECTORGEPCD] = scmEpScCnt.CnectOriginalEpCd;
			dataRow[ct_B_CNECTORGSECCD] = scmEpScCnt.CnectOriginalSecCd;
			dataRow[ct_B_CNECTORGSECNM] = scmEpScCnt.CnectOriginalSecNm;

			dataRow[ct_B_CNECTOTHERSECCD] = scmEpScCnt.CnectOtherSecCd;
			dataRow[ct_B_CNECTOTHERSECNM] = scmEpScCnt.CnectOtherSecNm;

			if (scmEpScCnt.DiscDivCd == 0)
				dataRow[ct_B_DISCDIVCDNM] = "有効";
			else
				dataRow[ct_B_DISCDIVCDNM] = "無効";
			dataRow[ct_B_DISCDIVCD] = scmEpScCnt.DiscDivCd;

			if (updateCache == true)
			{
				if (this._scmEpScCntTable.ContainsKey(MakeScmEpScCntTableContainsKey(scmEpScCnt)) == true)
				{
					this._scmEpScCntTable.Remove(MakeScmEpScCntTableContainsKey(scmEpScCnt));
				}
				this._scmEpScCntTable.Add(MakeScmEpScCntTableContainsKey(scmEpScCnt), scmEpScCnt);
			}
		}

		#endregion

		#region データセット列情報構築処理

		/// **********************************************************************
		/// Module name		:	 DataSetColumnConstruction
		/// <summary>
		/// データセット列情報構築処理
		/// </summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>Note		: データセットの列情報を構築します。
		///					 データセットの列情報がフレームのビュー用グリッドの列になります</br>
		/// <br>Programmer	: 95094  大塚　たえ子</br>
		/// <br>Date		: 2009.05.22</br>
		/// </remarks>
		/// **********************************************************************
		private void DataSetColumnConstruction()
		{
			//マスタメンテ親画面用
			DataTable ScmEpCnectTable = new DataTable(ct_SCMEPCNECT_TABLE);
			DataTable ScmEpScCntTable = new DataTable(ct_SCMEPSCCNT_TABLE);

			// Addを行う順番が、列の表示順位となります。
			ScmEpCnectTable.Columns.Add(ct_A_DELETE_DATE,     typeof(string));
			ScmEpCnectTable.Columns.Add(ct_A_DELETEDIV,       typeof(int));
			ScmEpCnectTable.Columns.Add(ct_A_CNECTORGEPCD,    typeof(string));
			ScmEpCnectTable.Columns.Add(ct_A_CNECTORGEPNM,    typeof(string));
			ScmEpCnectTable.Columns.Add(ct_A_DISCDIVCD,       typeof(int));
			ScmEpCnectTable.Columns.Add(ct_A_DISCDIVCDNM,     typeof(string));
			ScmEpCnectTable.Columns.Add(ct_A_CNECTOTHEREPNM,  typeof(string));

			ScmEpScCntTable.Columns.Add(ct_B_DELETE_DATE,     typeof(string));
			ScmEpScCntTable.Columns.Add(ct_B_DELETEDIV,       typeof(int));
			ScmEpScCntTable.Columns.Add(ct_B_CNECTOTHERSECCD, typeof(string));
			ScmEpScCntTable.Columns.Add(ct_B_CNECTOTHERSECNM, typeof(string));
			ScmEpScCntTable.Columns.Add(ct_B_CNECTORGEPCD,    typeof(string));
			ScmEpScCntTable.Columns.Add(ct_B_CNECTORGEPNM,    typeof(string));
			ScmEpScCntTable.Columns.Add(ct_B_CNECTORGSECCD,   typeof(string));
			ScmEpScCntTable.Columns.Add(ct_B_CNECTORGSECNM,   typeof(string));
			ScmEpScCntTable.Columns.Add(ct_B_DISCDIVCD,       typeof(int));
			ScmEpScCntTable.Columns.Add(ct_B_DISCDIVCDNM,     typeof(string));

			this._bind_DataSet.Tables.Add(ScmEpCnectTable);
			this._bind_DataSet.Tables.Add(ScmEpScCntTable);
		}

		#endregion

		// ===================================================================================== //
		// コンボボックス設定関連
		// ===================================================================================== //
		# region コンボボックス設定関連

		/// **********************************************************************
		/// Module name		:	 ComboEditorItemSet
		/// <summary>
		///  コンボボックスのアイテム設定
		/// </summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>Note		: コンボボックスのItem設定を行います。。</br>
		/// <br>Programmer	: 95094  大塚　たえ子</br>
		/// <br>Date		: 2009.05.22</br>
		/// </remarks>								   
		/// **********************************************************************
		private void ComboEditorItemSet()
		{
			this.OtherScCd_tComboEditor.Items.Clear();

			// 拠点情報取得
			foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
			{
				if (secInfoSet.SectionCode.TrimEnd() == "0")
				{
					this.OtherScCd_tComboEditor.Items.Add("0", "未登録");
				}
				else
				{
                    //this.OtherScCd_tComboEditor.Items.Add(secInfoSet.SectionCode, secInfoSet.SectionGuideNm.TrimEnd());                                            // 2014.09.11 del by Ryo.
                    this.OtherScCd_tComboEditor.Items.Add(secInfoSet.SectionCode, (secInfoSet.SectionCode).TrimEnd() + "：" + secInfoSet.SectionGuideNm.TrimEnd());  // 2014.09.11 ins by Ryo.
				}
			}
			SecInfoSet compSecInfoSet = new SecInfoSet();

			//自拠点取得
			compSecInfoSet = this._secInfoAcs.SecInfoSet;
			if (compSecInfoSet != null)
			{
				this._companySecCode = compSecInfoSet.SectionCode;
			}
		}

		# endregion

		// ===================================================================================== //
		// アイコン設定処理
		// ===================================================================================== //
		#region アイコン設定処理

		/// **********************************************************************
		/// Module name		:	 IconImageSetting
		/// <summary>
		///	アイコン設定処理
		/// </summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>Note		: アイコンの設定を行います。</br>
		/// <br>Programmer	: 95094  大塚　たえ子</br>
		/// <br>Date		: 2009.05.22</br>
		/// </remarks>
		/// **********************************************************************
		private void IconImageSetting()
		{
			this.Close_Button.Appearance.Image		= IconResourceManagement.ImageList24.Images[(int)Size24_Index.CLOSE];
			this.Save_Button.Appearance.Image		= IconResourceManagement.ImageList24.Images[(int)Size24_Index.SAVE];
			this.Revival_Button.Appearance.Image	= IconResourceManagement.ImageList24.Images[(int)Size24_Index.REVIVAL];
			this.Delete_Button.Appearance.Image		= IconResourceManagement.ImageList24.Images[(int)Size24_Index.DELETE];
		}

		#endregion

		// ===================================================================================== //
		//  画面処理
		// ===================================================================================== //
		#region 画面処理

		/// **********************************************************************
		/// Module name		:	 ScreenInitialSetting
		/// <summary>
		/// 画面初期設定処理
		/// </summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>Note        : 画面の初期設定を行います。</br>
		/// <br>Programmer	: 95094  大塚　たえ子</br>
		/// <br>Date		: 2009.05.22</br>
		/// </remarks>								   
		/// **********************************************************************
		private void ScreenInitialSetting()
		{
			// アイコン設定処理
			IconImageSetting();

			// コンボボックスの設定
			ComboEditorItemSet();
		}

		/// **********************************************************************
		/// Module name		:	 ScreenReconstruction
		/// <summary>
		/// 画面再構築処理
		/// </summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>Note        : モードに基づいて画面を再構築します。</br>
		/// <br>Programmer	: 95094  大塚　たえ子</br>
		/// <br>Date		: 2009.05.22</br>
		/// </remarks>
		/// **********************************************************************
		private void ScreenReconstruction()
		{
			Control focusControl = this.OriginalEpCd_tEdit;   // フォーカスセットコントロール

			ScmEpCnect scmEpCnect = null;
			ScmEpScCnt scmEpScCnt = null;

            // 連結企業設定 (左のグリッド)
            if (this._targetTableName == ct_SCMEPCNECT_TABLE)
			{
				if (this._mainDataIndex >= 0)
				{
					string keyCode = this._bind_DataSet.Tables[this._targetTableName].Rows[this._mainDataIndex][ct_A_CNECTORGEPCD].ToString();
					scmEpCnect = _scmEpCnectTable[keyCode];
					if (this._passWordview == true)
					{
						if (scmEpCnect.LogicalDeleteCode != 0)
							this.Mode_Label.Text = DELETE_MODE;
						else
							this.Mode_Label.Text = UPDATE_MODE;
					}
					else
					{
						this.Mode_Label.Text = REFER_MODE;
					}
				}
				else
				{
					if (this._passWordview == true)
						this.Mode_Label.Text = INSERT_MODE;
					else
						this.Mode_Label.Text = REFER_MODE;
				}

				// 画面の位置調整
				this.OriginalSc_panel.Visible	= false;
				this.OtherSc_panel.Visible		= false;

                this.OtherEp_panel.Height = 96;  // 2014.09.11 ins by Ryo.

                this.OriginalEp_ultraGroupBox.Height = this.OriginalEp_panel.Height + 22;
				this.OtherEp_ultraGroupBox.Height		= this.OtherEp_panel.Height + 22;

				this.OtherEp_ultraGroupBox.Top	= this.OriginalEp_ultraGroupBox.Top + this.OriginalEp_ultraGroupBox.Height + 6;

                // this.Height = 509 - (this.OriginalSc_panel.Height + this.OtherSc_panel.Height);//DEL BY x_zhuxk 2011.08.12
                // UPD 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                // this.Height = 509 - (this.OriginalSc_panel.Height + this.OtherSc_panel.Height) + 40;// ADD BY x_zhuxk ON 2011.08.12
                this.Height = 533 - (this.OriginalSc_panel.Height + this.OtherSc_panel.Height) + 40;
                // UPD 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

                this.EpDiscDivCd_tComboEditor.Visible = true;  // 2014.09.11 ins by Ryo.

				// 入力制御
				switch (this.Mode_Label.Text)
				{
					case INSERT_MODE:
					{
						this.OriginalEpCd_tEdit.Enabled			= true;
						this.OriginalEpNm_tEdit.Enabled			= true;
						this.OtherEpCd_tEdit.Enabled			= false;
						this.OtherEpNm_tEdit.Enabled			= true;
						this.EpDiscDivCd_tComboEditor.Enabled	= true;
                        this.SCM_ultraCheckEditor.Enabled       = false; //ADD BY x_zhuxk ON 2011.08.12
                        this.PCC_UOC_ultraCheckEditor.Enabled   = false; //ADD BY x_zhuxk ON 2011.08.12
                        // ADD 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                        this.RC_ultraCheckEditor.Enabled = false;   // 部品問合せ・発注（RCオプション）
                        // --- DEL 2013/06/14 Y.Wakita ---------->>>>>
                        //this.radioButton_New.Enabled = false;       // 新品部品
                        //this.radioButton_RC.Enabled = false;        // リサイクル
                        // --- DEL 2013/06/14 Y.Wakita ----------<<<<<
                        // ADD 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                        // --- ADD 2013/06/14 Y.Wakita ---------->>>>>
                        // UPD 2013/11/28 商品保証課Redmine#711対応 --------------------------->>>>>
                        //this.uOptionSet_PrDispSystem.Enabled = false;
                        //this.ultraLabel_New.Visible = true;         // 新品部品(ラベル)
                        //this.ultraLabel_Rc.Visible = true;          // リサイクル(ラベル)
                        this.ultraLabel_DisplayOrder.Visible = false;
                        this.uOptionSet_PrDispSystem.Visible = false;
                        this.uOptionSet_PrDispSystem.Enabled = false;
                        this.ultraLabel_New.Visible = false;         // 新品部品(ラベル)
                        this.ultraLabel_Rc.Visible = false;          // リサイクル(ラベル)
                        // UPD 2013/11/28 商品保証課Redmine#711対応 ---------------------------<<<<<
                        // --- ADD 2013/06/14 Y.Wakita ----------<<<<<

                        // UPD 2014/11/18 豊沢 SCM仕掛一覧No.10696 ---------->>>>>>>>>>
						//focusControl = this.OriginalEpNm_tEdit;
                        focusControl = this.OriginalEpCd_tEdit;
                        // UPD 2014/11/18 豊沢 SCM仕掛一覧No.10696 ----------<<<<<<<<<<
						break;
					}
					case UPDATE_MODE:
					{
						this.OriginalEpCd_tEdit.Enabled			= false;
						this.OriginalEpNm_tEdit.Enabled			= true;
						this.OtherEpCd_tEdit.Enabled			= false;
						this.OtherEpNm_tEdit.Enabled			= true;
						this.EpDiscDivCd_tComboEditor.Enabled	= true;
                        this.SCM_ultraCheckEditor.Enabled = false; //ADD BY x_zhuxk ON 2011.08.12
                        this.PCC_UOC_ultraCheckEditor.Enabled = false; //ADD BY x_zhuxk ON 2011.08.12
                        // ADD 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                        this.RC_ultraCheckEditor.Enabled = false;   // 部品問合せ・発注（RCオプション）
                        // --- DEL 2013/06/14 Y.Wakita ---------->>>>>
                        //this.radioButton_New.Enabled = false;       // 新品部品
                        //this.radioButton_RC.Enabled = false;        // リサイクル
                        // --- DEL 2013/06/14 Y.Wakita ----------<<<<<
                        // ADD 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                        // --- ADD 2013/06/14 Y.Wakita ---------->>>>>
                        // UPD 2013/11/28 商品保証課Redmine#711対応 --------------------------->>>>>
                        //this.uOptionSet_PrDispSystem.Enabled = false;
                        //this.ultraLabel_New.Visible = true;         // 新品部品(ラベル)
                        //this.ultraLabel_Rc.Visible = true;          // リサイクル(ラベル)
                        this.ultraLabel_DisplayOrder.Visible = false;
                        this.uOptionSet_PrDispSystem.Visible = false;
                        this.uOptionSet_PrDispSystem.Enabled = false;
                        this.ultraLabel_New.Visible = false;         // 新品部品(ラベル)
                        this.ultraLabel_Rc.Visible = false;          // リサイクル(ラベル)
                        // UPD 2013/11/28 商品保証課Redmine#711対応 ---------------------------<<<<<
                        // --- ADD 2013/06/14 Y.Wakita ----------<<<<<

						focusControl = this.OriginalEpNm_tEdit;
						break;
					}
					default:
					{
						this.OriginalEpCd_tEdit.Enabled			= false;
						this.OriginalEpNm_tEdit.Enabled			= false;
						this.OtherEpCd_tEdit.Enabled			= false;
						this.OtherEpNm_tEdit.Enabled			= false;
						this.EpDiscDivCd_tComboEditor.Enabled	= false;
                        this.SCM_ultraCheckEditor.Enabled       = false; //ADD BY x_zhuxk ON 2011.08.12
                        this.PCC_UOC_ultraCheckEditor.Enabled   = false; //ADD BY x_zhuxk ON 2011.08.12
                        // ADD 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                        this.RC_ultraCheckEditor.Enabled = false;   // 部品問合せ・発注（RCオプション）
                        // --- DEL 2013/06/14 Y.Wakita ---------->>>>>
                        //this.radioButton_New.Enabled = false;       // 新品部品
                        //this.radioButton_RC.Enabled = false;        // リサイクル
                        // --- DEL 2013/06/14 Y.Wakita ----------<<<<<
                        // ADD 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                        // --- ADD 2013/06/14 Y.Wakita ---------->>>>>
                        // UPD 2013/11/28 商品保証課Redmine#711対応 --------------------------->>>>>
                        //this.uOptionSet_PrDispSystem.Enabled = false;
                        //this.ultraLabel_New.Visible = true;         // 新品部品(ラベル)
                        //this.ultraLabel_Rc.Visible = true;          // リサイクル(ラベル)
                        this.ultraLabel_DisplayOrder.Visible = false;
                        this.uOptionSet_PrDispSystem.Visible = false;
                        this.uOptionSet_PrDispSystem.Enabled = false;
                        this.ultraLabel_New.Visible = false;         // 新品部品(ラベル)
                        this.ultraLabel_Rc.Visible = false;          // リサイクル(ラベル)
                        // UPD 2013/11/28 商品保証課Redmine#711対応 ---------------------------<<<<<
                        // --- ADD 2013/06/14 Y.Wakita ----------<<<<<

						focusControl = this.Close_Button;
						break;
					}
				}
			}
            // 連結拠点設定 (右のグリッド)
            else
			{
				string keyCode = this._bind_DataSet.Tables[ct_SCMEPCNECT_TABLE].Rows[this._mainDataIndex][ct_A_CNECTORGEPCD].ToString();
				scmEpCnect = _scmEpCnectTable[keyCode];

				if (this._detailsDataIndex >= 0)
				{
					scmEpScCnt = new ScmEpScCnt();
					MakeScmEpScCntKeyFormRowIndex(ref scmEpScCnt, this._detailsDataIndex, this._targetTableName);
					scmEpScCnt = _scmEpScCntTable[MakeScmEpScCntTableContainsKey(scmEpScCnt)];
					if (this._passWordview == true)
					{
						if (scmEpScCnt.LogicalDeleteCode != 0)
							this.Mode_Label.Text = DELETE_MODE;
						else
							this.Mode_Label.Text = UPDATE_MODE;
					}
					else
					{
						this.Mode_Label.Text = REFER_MODE;
					}
				}
				else
				{
					if (this._passWordview == true)
						this.Mode_Label.Text = INSERT_MODE;
					else
						this.Mode_Label.Text = REFER_MODE;
				}

				// 画面の位置調整
				this.OriginalSc_panel.Visible	= true;
				this.OtherSc_panel.Visible		= true;

                this.OtherEp_panel.Height = 66;  // 2014.09.11 ins by Ryo.

                this.OriginalEp_ultraGroupBox.Height	= this.OriginalEp_panel.Height + this.OriginalSc_panel.Height + 22;
				this.OtherEp_ultraGroupBox.Height		= this.OtherEp_panel.Height + this.OtherSc_panel.Height + 22;

				this.OtherEp_ultraGroupBox.Top	= this.OriginalEp_ultraGroupBox.Top + this.OriginalEp_ultraGroupBox.Height + 6;

               // this.Height = 509; //DEL BY x_zhuxk 2011.08.12
                // UPD 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                // this.Height = 549; // ADD BY x_zhuxk ON 2011.08.12
                //this.Height = 574;  // 2014.09.11 del by Ryo.
                this.Height = 544;    // 2014.09.11 ins by Ryo.
                // UPD 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

				// 入力制御
				this.OriginalEpCd_tEdit.Enabled	      = false;
				this.OriginalEpNm_tEdit.Enabled		  = false;
				this.OtherEpCd_tEdit.Enabled		  = false;
				this.OtherEpNm_tEdit.Enabled		  = false;

                this.EpDiscDivCd_tComboEditor.Enabled = false;
                this.EpDiscDivCd_tComboEditor.Visible = false;  // 2014.09.11 ins by Ryo.

				switch (this.Mode_Label.Text)
				{
					case INSERT_MODE:
					{
						this.OtherScCd_tComboEditor.Enabled	    = true;

                        this.OriginalScNm_tEdit.Enabled         = true;
                        this.OriginalScCd_tEdit.Enabled		    = true;
                        this.OriginalScCd_tComboEditor.Enabled  = true;  // 2014.11.18 ins by Ryo.

                        this.OtherScNm_tEdit.Enabled            = true;
						this.ScDiscDivCd_tComboEditor.Enabled	= true;
                        this.SCM_ultraCheckEditor.Enabled       = true; //ADD BY x_zhuxk ON 2011.08.12
                        this.PCC_UOC_ultraCheckEditor.Enabled   = true; //ADD BY x_zhuxk ON 2011.08.12
                        this.OriginalUserCd_tComboEditor.Enabled = true;  // 2014.09.10 ins by Ryo.
                        this.OtherUserCd_tComboEditor.Enabled    = true;  // 2014.09.10 ins by Ryo.
                        this.AddNewUser_ultraButton.Enabled      = true;  // 2014.09.10 ins by Ryo.
                        // ADD 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                        this.RC_ultraCheckEditor.Enabled = true;   // 部品問合せ・発注（RCオプション）
                        // --- DEL 2013/06/14 Y.Wakita ---------->>>>>
                        //this.radioButton_New.Enabled = true;       // 新品部品
                        //this.radioButton_RC.Enabled = true;        // リサイクル
                        // --- DEL 2013/06/14 Y.Wakita ----------<<<<<
                        // ADD 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                        // --- ADD 2013/06/14 Y.Wakita ---------->>>>>
                        this.uOptionSet_PrDispSystem.Enabled = true;
                        // DEL 2013/11/28 商品保証課Redmine#711対応 --------------------------->>>>>
                        //this.ultraLabel_New.Visible = false;        // 新品部品(ラベル)
                        //this.ultraLabel_Rc.Visible = false;         // リサイクル(ラベル)
                        // DEL 2013/11/28 商品保証課Redmine#711対応 ---------------------------<<<<<
                        // --- ADD 2013/06/14 Y.Wakita ----------<<<<<

						focusControl = this.OtherScCd_tComboEditor;
						break;
					}
					case UPDATE_MODE:
					{
                        this.OtherScCd_tComboEditor.Enabled     = false;

                        this.OriginalScNm_tEdit.Enabled         = true;
                        this.OriginalScCd_tEdit.Enabled         = false;
                        this.OriginalScCd_tComboEditor.Enabled  = false;  // 2014.11.18 ins by Ryo.

                        this.OtherScNm_tEdit.Enabled            = true;
						this.ScDiscDivCd_tComboEditor.Enabled	= true;
                        this.SCM_ultraCheckEditor.Enabled       = true; //ADD BY x_zhuxk ON 2011.08.12
                        this.PCC_UOC_ultraCheckEditor.Enabled   = true; //ADD BY x_zhuxk ON 2011.08.12
                        this.OriginalUserCd_tComboEditor.Enabled = true;  // 2014.09.10 ins by Ryo.
                        this.OtherUserCd_tComboEditor.Enabled    = true;  // 2014.09.10 ins by Ryo.
                        this.AddNewUser_ultraButton.Enabled      = true;  // 2014.09.10 ins by Ryo.
                        // ADD 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                        this.RC_ultraCheckEditor.Enabled = true;   // 部品問合せ・発注（RCオプション）
                        // --- DEL 2013/06/14 Y.Wakita ---------->>>>>
                        //this.radioButton_New.Enabled = true;       // 新品部品
                        //this.radioButton_RC.Enabled = true;        // リサイクル
                        // --- DEL 2013/06/14 Y.Wakita ----------<<<<<
                        // ADD 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                        // --- ADD 2013/06/14 Y.Wakita ---------->>>>>
                        this.uOptionSet_PrDispSystem.Enabled = true;
                        // DEL 2013/11/28 商品保証課Redmine#711対応 --------------------------->>>>>
                        //this.ultraLabel_New.Visible = false;        // 新品部品(ラベル)
                        //this.ultraLabel_Rc.Visible = false;         // リサイクル(ラベル)
                        // DEL 2013/11/28 商品保証課Redmine#711対応 ---------------------------<<<<<
                        // --- ADD 2013/06/14 Y.Wakita ----------<<<<<

                        focusControl = this.OriginalScNm_tEdit;
                        
						break;
					}
					default:
					{
						this.OtherScCd_tComboEditor.Enabled	    = false;

                        this.OriginalScNm_tEdit.Enabled         = false;
                        this.OriginalScCd_tEdit.Enabled         = false;
                        this.OriginalScCd_tComboEditor.Enabled  = false;  // 2014.11.18 ins by Ryo.

                        this.OtherScNm_tEdit.Enabled            = false;
						this.ScDiscDivCd_tComboEditor.Enabled	= false;
                        this.SCM_ultraCheckEditor.Enabled       = false; //ADD BY x_zhuxk ON 2011.08.12
                        this.PCC_UOC_ultraCheckEditor.Enabled   = false; //ADD BY x_zhuxk ON 2011.08.12
                        this.OriginalUserCd_tComboEditor.Enabled = false;  // 2014.09.10 ins by Ryo.
                        this.OtherUserCd_tComboEditor.Enabled    = false;  // 2014.09.10 ins by Ryo.
                        this.AddNewUser_ultraButton.Enabled      = false;  // 2014.09.10 ins by Ryo.
                        // ADD 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                        this.RC_ultraCheckEditor.Enabled = false;   // 部品問合せ・発注（RCオプション）
                        // --- DEL 2013/06/14 Y.Wakita ---------->>>>>
                        //this.radioButton_New.Enabled = false;       // 新品部品
                        //this.radioButton_RC.Enabled = false;        // リサイクル
                        // --- DEL 2013/06/14 Y.Wakita ----------<<<<<
                        // ADD 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                        // --- ADD 2013/06/14 Y.Wakita ---------->>>>>
                        this.uOptionSet_PrDispSystem.Enabled = false;
                        // DEL 2013/11/28 商品保証課Redmine#711対応 --------------------------->>>>>
                        //this.ultraLabel_New.Visible = true;         // 新品部品(ラベル)
                        //this.ultraLabel_Rc.Visible = true;          // リサイクル(ラベル)
                        // DEL 2013/11/28 商品保証課Redmine#711対応 ---------------------------<<<<<
                        // --- ADD 2013/06/14 Y.Wakita ----------<<<<<

						focusControl = this.Close_Button;
						break;
					}
				}
			}

			// ボタンの入力制御
			switch (this.Mode_Label.Text)
			{
				case DELETE_MODE:
				{
					this.Save_Button.Visible	= false;
					this.Revival_Button.Visible	= true;
                    // --- UPD 2013/06/11 Y.Wakita ---------->>>>>
                    //this.Delete_Button.Visible = true;
                    this.Delete_Button.Visible = false;
                    // --- UPD 2013/06/11 Y.Wakita ----------<<<<<
                    break;
				}
				case REFER_MODE:
				{
					this.Save_Button.Visible	= false;
					this.Revival_Button.Visible	= false;
					this.Delete_Button.Visible	= false;
					break;
				}
				default:
				{
					this.Save_Button.Visible	= true;
					this.Revival_Button.Visible	= false;
					this.Delete_Button.Visible	= false;
					break;
				}
			}

			// SCM企業連結マスタの表示
			if (scmEpCnect == null)
				scmEpCnect = CreateNewScmEpCnect();
			ScmEpCnectToDisp(scmEpCnect);

			// SCM企業拠点連結マスタの表示
			if (this._targetTableName == ct_SCMEPSCCNT_TABLE)
			{
				if (scmEpScCnt == null)
					scmEpScCnt = CreateNewScmEpScCnt();
				ScmEpScCntToDisp(scmEpScCnt);

                // --------------- ADD START 2011.10.13 呉軍 FOR Redmine#25912 -------->>>>
                if (this.OtherScCd_tComboEditor.Value == null)
                {
                    string message = "指定された拠点は存在しません。\r\n登録を行った端末にて正しい拠点コードを設定してください。";
                    TMsgDisp.Show(
                        this, 								// 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                        ctASSEMBLY_ID, 						// アセンブリＩＤ
                        message, 							// 表示するメッセージ
                        0, 									// ステータス値
                        MessageBoxButtons.OK);				// 表示するボタン
                }
                // --------------- ADD END 2011.10.13 呉軍 FOR Redmine#25912 ----------<<<<
			
			}

			//_GridIndexバッファ保持
			this._mainIndexBuf		= this._mainDataIndex;
			this._detailsIndexBuf	= this._detailsDataIndex;
			this._targetTableBuf	= this._targetTableName;

            // ADD 2013/11/28 商品保証課Redmine#711対応 --------------------------->>>>>
            // 優先表示システムはPMオプション･RCオプションがONの時のみ表示
            if ((this.SCM_ultraCheckEditor.Checked && this.RC_ultraCheckEditor.Checked) ||
                (this.PCC_UOC_ultraCheckEditor.Checked && this.RC_ultraCheckEditor.Checked)
            )
            {
                this.uOptionSet_PrDispSystem.Visible = true;
                this.ultraLabel_DisplayOrder.Visible = true;
                this.ultraLabel_New.Visible = true;
                this.ultraLabel_Rc.Visible = true;
            }
            else
            {
                this.uOptionSet_PrDispSystem.Visible = false;
                this.ultraLabel_DisplayOrder.Visible = false;
                this.ultraLabel_New.Visible = false;
                this.ultraLabel_Rc.Visible = false;
            }

            // ADD 2013/11/28 商品保証課Redmine#711対応 ---------------------------<<<<<

			// モード・その他のデータ状態による項目の表示・非表示
			focusControl.Focus();

			if (focusControl is TEdit) ((TEdit)focusControl).SelectAll();
		}

		/// **********************************************************************
		/// Module name		:	 ScreenClear
		/// <summary>
		/// 画面クリア処理
		/// </summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>Note        : 画面をクリアします。</br>
		/// <br>Programmer	: 95094  大塚　たえ子</br>
		/// <br>Date		: 2009.05.22</br>
		/// </remarks>
		/// **********************************************************************
		private void ScreenClear()
		{
			// 企業情報セット
			this.OriginalEpCd_tEdit.Text			= string.Empty;
			//自社企業名称
            this.OriginalEpNm_tEdit.Text            = string.Empty;
			//連結企業コード
            this.OtherEpCd_tEdit.Text               = _enterpriseCode;
			//連結企業名称
			this.OtherEpNm_tEdit.Text				= _enterpriseName;
			//種別区分
			this.EpDiscDivCd_tComboEditor.Value		= 0;
			//自社拠点基準(自社企業コード)
			this.OtherScCd_tComboEditor.Value	    = _secInfoAcs.SecInfoSet.SectionCode;
            // 自社拠点名称
            this.OriginalScNm_tEdit.Text			= string.Empty;
			// 連結企業拠点コード
            this.OriginalScCd_tEdit.Text			= string.Empty;
            // 連結企業拠点名称
            this.OtherScNm_tEdit.Text               = string.Empty;

            // 2014.11.18 ins by Ryo. -start- > > > > >
            // 接続先 .NS拠点コード/名称
            this.OriginalScCd_tComboEditor.Items.Clear();
            this.OriginalScCd_tComboEditor.Value = null;
            // 2014.11.18 ins by Ryo. -e n d- < < < < <

            // 2014.09.11 ins by Ryo. -start- > > > > >
            // 接続先 ユーザーコード/名称
            this.OriginalUserCd_tComboEditor.Items.Clear();
            this.OriginalUserCd_tComboEditor.Value = null;
            // 自社情報 ユーザーコード/名称
            this.OtherUserCd_tComboEditor.Items.Clear();
            this.OtherUserCd_tComboEditor.Value = null;
            // 2014.09.11 ins by Ryo. -e n d- < < < < <

			// 種別区分
			this.ScDiscDivCd_tComboEditor.Value		= 0;
            this.SCM_ultraCheckEditor.Checked       = false;  // ADD BY x_zhuxk ON 2011.08.12
            this.PCC_UOC_ultraCheckEditor.Checked   = false;  // ADD BY x_zhuxk ON 2011.08.12
            // ADD 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            this.RC_ultraCheckEditor.Checked = false;   // 部品問合せ・発注（RCオプション）
            // 優先表示システム
            // --- UPD 2013/06/14 Y.Wakita ---------->>>>>
            //this.radioButton_New.Checked = false;        // 新品部品
            //this.radioButton_RC.Checked = false;        // リサイクル
            this.uOptionSet_PrDispSystem.CheckedIndex = 0;
            // --- UPD 2013/06/14 Y.Wakita ----------<<<<<
            // ADD 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

		}

		/// **********************************************************************
		/// Module name		:	 CreateNewScmEpCnect
		/// <summary>
		/// SCM企業連結マスタ作成処理
		/// </summary>
		/// <returns>SCM企業連結マスタ</returns>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>Note		: SCM企業連結マスタの新規インスタンスを作成します。</br>
		/// <br>Programmer	: 22024  寺坂　誉志</br>
		/// <br>Date		: 2009.07.15</br>
		/// </remarks>
		/// **********************************************************************
		private ScmEpCnect CreateNewScmEpCnect()
		{
			ScmEpCnect scmEpCnect = new ScmEpCnect();
			scmEpCnect.CnectOtherEpCd	= this._enterpriseCode;
			scmEpCnect.CnectOtherEpNm	= this._enterpriseName;

			return scmEpCnect;
		}

		/// **********************************************************************
		/// Module name		:	 CreateNewScmEpScCnt
		/// <summary>
		/// SCM企業拠点連結マスタ作成処理
		/// </summary>
		/// <returns>SCM企業拠点連結マスタ</returns>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>Note		: SCM企業拠点連結マスタの新規インスタンスを作成します。</br>
		/// <br>Programmer	: 22024  寺坂　誉志</br>
		/// <br>Date		: 2009.07.15</br>
		/// </remarks>
		/// **********************************************************************
		private ScmEpScCnt CreateNewScmEpScCnt()
		{
			ScmEpScCnt scmEpScCnt = new ScmEpScCnt();
            scmEpScCnt.CnectOriginalEpCd = this._bind_DataSet.Tables[ct_SCMEPCNECT_TABLE].Rows[this._mainDataIndex][ct_A_CNECTORGEPCD].ToString();
			scmEpScCnt.CnectOtherSecCd	= this._secInfoAcs.SecInfoSet.SectionCode;
			scmEpScCnt.CnectOtherSecNm	= this._secInfoAcs.SecInfoSet.SectionGuideNm;
            scmEpScCnt.CnectOtherEpCd = this._enterpriseCode; 
			
			return scmEpScCnt;
		}

        // 2014.09.11 ins by Ryo. -start- > > > > >
        /// **********************************************************************
        /// Module name    : CreateNewOScmBPSCnt
        /// <summary>
        /// 提供側SCM事業場拠点連結マスタ作成処理
        /// </summary>
        /// <returns>提供側SCM事業場拠点連結マスタ作成処理</returns>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note       : 提供側SCM事業場拠点連結マスタの新規インスタンスを作成します。</br>
        /// <br>Programmer : Ryo.</br>
        /// <br>Date       : 2014.09.11</br>
        /// </remarks>
        /// **********************************************************************
        private OScmBPSCnt CreateNewOScmBPSCnt()
        {
            OScmBPSCnt oScmBPSCnt = new OScmBPSCnt();

            //oScmBPSCnt.CreateDateTime
            //oScmBPSCnt.UpdateDateTime
            //oScmBPSCnt.LogicalDeleteCode
            // 自社情報 (PM側)
            oScmBPSCnt.CnectOtherEpCd = this._enterpriseCode;
            oScmBPSCnt.CnectOtherSecCd = this._secInfoAcs.SecInfoSet.SectionCode;
            //oScmBPSCnt.ContractantCode
            //oScmBPSCnt.FTCCustomerCode
            // 接続先   (SF側)
            oScmBPSCnt.CnectOriginalEpCd = this._bind_DataSet.Tables[ct_SCMEPCNECT_TABLE].Rows[this._mainDataIndex][ct_A_CNECTORGEPCD].ToString();
            //oScmBPSCnt.CnectOriginalSecCd
            //oScmBPSCnt.TransContractantCd
            //oScmBPSCnt.TransCustomerCd

            return oScmBPSCnt;
        }
        // 2014.09.11 ins by Ryo. -e n d- < < < < <

		/// **********************************************************************
		/// Module name		:	 ScmEpCnectToDisp
		/// <summary>
		/// SCM企業連結マスタ→画面展開処理
		/// </summary>
		/// <returns>SCM企業連結マスタ</returns>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>Note		: SCM企業連結マスタを画面に展開します。</br>
		/// <br>Programmer	: 22024  寺坂　誉志</br>
		/// <br>Date		: 2009.07.15</br>
		/// </remarks>
		/// **********************************************************************
		private void ScmEpCnectToDisp(ScmEpCnect scmEpCnect)
		{
			// 企業情報セット
			this.OriginalEpCd_tEdit.Text		= scmEpCnect.CnectOriginalEpCd;
			// 自社企業名称
			this.OriginalEpNm_tEdit.Text		= scmEpCnect.CnectOriginalEpNm;
			// 連結企業コード
			this.OtherEpCd_tEdit.Text			= scmEpCnect.CnectOtherEpCd;
			// 連結企業名称
			this.OtherEpNm_tEdit.Text			= scmEpCnect.CnectOtherEpNm;
			// 種別区分
			this.EpDiscDivCd_tComboEditor.Value	= scmEpCnect.DiscDivCd;
		}

		/// **********************************************************************
		/// Module name		:	 ScmEpScCntToDisp
		/// <summary>
		/// SCM企業拠点連結マスタ→画面展開処理
		/// </summary>
		/// <returns>SCM企業拠点連結マスタ</returns>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>Note		: SCM企業拠点連結マスタを画面に展開します。</br>
		/// <br>Programmer	: 22024  寺坂　誉志</br>
		/// <br>Date		: 2009.07.15</br>
		/// </remarks>
		/// **********************************************************************
		private void ScmEpScCntToDisp(ScmEpScCnt scmEpScCnt)
		{
            // 連結先拠点名称
            this.OriginalScNm_tEdit.Text = scmEpScCnt.CnectOriginalSecNm;

            // 連結先拠点コード
			this.OriginalScCd_tEdit.Text = scmEpScCnt.CnectOriginalSecCd;

            // 2014.11.18 ins by Ryo. -start- > > > > >

            List<CnectOrgNSSecInfo> retCnectOrgNSSecInfoList;

            bool msgDiv = false;
            string errMsg = string.Empty;
            bool isExistSec = false;

            int status = this._scmEpScCntAcs.GetSuperFrontmanSectionList(scmEpScCnt.CnectOriginalEpCd, out retCnectOrgNSSecInfoList, out msgDiv, out errMsg);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                foreach (CnectOrgNSSecInfo cnectOrgNSSecInfo in retCnectOrgNSSecInfoList)
                {
                    this._cnectOrgNSSecInfoList.Add(cnectOrgNSSecInfo);

                    this.OriginalScCd_tComboEditor.Items.Add(cnectOrgNSSecInfo.CnectOriginalSecCd, cnectOrgNSSecInfo.CnectOriginalSecCd + "：" + cnectOrgNSSecInfo.CnectOriginalSecGNm);
                    if ((cnectOrgNSSecInfo.CnectOriginalSecCd).TrimEnd() == (scmEpScCnt.CnectOriginalSecCd).TrimEnd())
                    {
                        isExistSec = true;
                    }
                        
                }
                // 新規
                if (scmEpScCnt.CnectOriginalSecCd.Trim() == string.Empty)
                {
                    isExistSec = true;
                }
            }

            if (isExistSec == true)
            {
                this.OriginalScCd_tComboEditor.Value = scmEpScCnt.CnectOriginalSecCd;

                this.OriginalScCd_ultraLabel.Text = " .NS拠点コード/名称";
                this.OriginalScCd_tComboEditor.Visible = true;
                this.OriginalScCd_tEdit.Visible = false;
            }
            else
            {
                this.OriginalScCd_ultraLabel.Text = " .NS拠点コード";
                this.OriginalScCd_tComboEditor.Visible = false;
                this.OriginalScCd_tEdit.Visible = true;
            }
            // 2014.11.18 ins by Ryo. -e n d- < < < < <

            // 2014.09.11 ins by Ryo. -start- > > > > >
            // 提供側SCM事業場連結マスタからユーザーコードリストの設定
            bool IsExists = false;
            foreach (OScmBPCnt oScmBPCnt in this._oScmBPCntTable.Values)
            {
                // 連結先ユーザーコード・名称
                if (scmEpScCnt.CnectOriginalEpCd == oScmBPCnt.CnectOriginalEpCd)
                {
                    Infragistics.Win.ValueListItem valueListItem = new Infragistics.Win.ValueListItem();

                    string transBlUserCode = oScmBPCnt.TransBLUserCode1.TrimEnd() + "-" + oScmBPCnt.TransBLUserCode2.TrimEnd();

                    valueListItem.DataValue = transBlUserCode;
                    valueListItem.DisplayText = transBlUserCode + "：" + oScmBPCnt.TransContractantNm + " " + oScmBPCnt.TransCustomerNm;

                    IsExists = false;

                    for (int iCnt = 0; iCnt < this.OriginalUserCd_tComboEditor.Items.Count; iCnt++)
                    {
                        if ((this.OriginalUserCd_tComboEditor.Items[iCnt].DataValue).ToString() == (valueListItem.DataValue).ToString())
                        {
                            IsExists = true;
                            break;
                        }
                    }

                    if (IsExists == false)
                    {
                        this.OriginalUserCd_tComboEditor.Items.Add(valueListItem);
                    }

                }

                // 連結元ユーザーコード・名称
                if (scmEpScCnt.CnectOtherEpCd == oScmBPCnt.CnectOtherEpCd)
                {
                    string blUserCode = oScmBPCnt.BLUserCode1.TrimEnd() + "-" + oScmBPCnt.BLUserCode2.TrimEnd();

                    Infragistics.Win.ValueListItem valueListItem = new Infragistics.Win.ValueListItem();

                    valueListItem.DataValue = blUserCode;
                    valueListItem.DisplayText = blUserCode + "：" + oScmBPCnt.ContractantName + " " + oScmBPCnt.FTCCustomerName;

                    IsExists = false;

                    for (int iCnt = 0; iCnt < this.OtherUserCd_tComboEditor.Items.Count; iCnt++)
                    {
                        if ((this.OtherUserCd_tComboEditor.Items[iCnt].DataValue).ToString() == (valueListItem.DataValue).ToString())
                        {
                            IsExists = true;
                            break;
                        }
                    }

                    if (IsExists == false)
                    {
                        this.OtherUserCd_tComboEditor.Items.Add(valueListItem);
                    }
                }
            }

            // コンボボックスから該当するユーザーコード・名称を選択する。
            foreach (OScmBPSCnt oScmBPSCnt in this._oScmBPSCntTable.Values)
            {
                if ((oScmBPSCnt.CnectOtherEpCd == scmEpScCnt.CnectOtherEpCd) &&
                    (oScmBPSCnt.CnectOtherSecCd == scmEpScCnt.CnectOtherSecCd) &&
                    (oScmBPSCnt.CnectOriginalEpCd == scmEpScCnt.CnectOriginalEpCd) &&
                    (oScmBPSCnt.CnectOriginalSecCd == scmEpScCnt.CnectOriginalSecCd))
                {

                    // 連結元ユーザーコード
                    foreach (OScmBPCnt oScmBPCnt in this._oScmBPCntTable.Values)
                    {
                        if ((oScmBPCnt.ContractantCode == oScmBPSCnt.ContractantCode) &&
                            (oScmBPCnt.FTCCustomerCode == oScmBPSCnt.FTCCustomerCode))
                        {
                            this.OtherUserCd_tComboEditor.Value = oScmBPCnt.BLUserCode1.TrimEnd() + "-" + oScmBPCnt.BLUserCode2.TrimEnd();
                            break;
                        }
                    }
                    // 連結先ユーザーコード
                    foreach (OScmBPCnt oScmBPCnt in this._oScmBPCntTable.Values)
                    {
                        if ((oScmBPCnt.TransContractantCd == oScmBPSCnt.TransContractantCd) &&
                            (oScmBPCnt.TransCustomerCd == oScmBPSCnt.TransCustomerCd))
                        {
                            this.OriginalUserCd_tComboEditor.Value = oScmBPCnt.TransBLUserCode1.TrimEnd() + "-" + oScmBPCnt.TransBLUserCode2.TrimEnd();
                            break;
                        }
                    }
                    break;
                }
            }
            // 2014.09.11 ins by Ryo. -e n d- < < < < <

            // 自拠点(自社企業コード)
            this.OtherScCd_tComboEditor.Value   = scmEpScCnt.CnectOtherSecCd;
            // 自拠点名称
            this.OtherScNm_tEdit.Text			= scmEpScCnt.CnectOtherSecNm;
			// 種別区分
			this.ScDiscDivCd_tComboEditor.Value	= scmEpScCnt.DiscDivCd;
            // ADD BY x_zhuxk ON 2011.08.12 STR
            // 通信方式(SCM)
            if (scmEpScCnt.ScmCommMethod == 0)
            {
                this.SCM_ultraCheckEditor.Checked = false;
            }
            else
            {
                this.SCM_ultraCheckEditor.Checked = true;
            }
            // 通信方式(PCC-UOE)
            if (scmEpScCnt.PccUoeCommMethod == 0)
            {
                this.PCC_UOC_ultraCheckEditor.Checked = false;
            }
            else
            {
                this.PCC_UOC_ultraCheckEditor.Checked = true;
            }
            // ADD BY x_zhuxk ON 2011.08.12 END
            // ADD 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            // 通信方式(部品問合せ・発注（RCオプション))
            if (scmEpScCnt.RcScmCommMethod == 0)
            {
                this.RC_ultraCheckEditor.Checked = false;
            }
            else
            {
                this.RC_ultraCheckEditor.Checked = true;
            }
            // 優先表示システム 10:新品部品(PMを優先表示)　11：リサイクル部品(RCを優先表示)
            // --- DEL 2013/06/14 Y.Wakita ---------->>>>>
            //if (scmEpScCnt.PrDispSystem == 10)
            //{
            //    this.radioButton_New.Checked = true;
            //    this.radioButton_RC.Checked = false;
            //}
            //else if (scmEpScCnt.PrDispSystem == 11)
            //{
            //    this.radioButton_New.Checked = false;
            //    this.radioButton_RC.Checked = true;
            //}
            //else
            //{
            //    this.radioButton_New.Checked = false;
            //    this.radioButton_RC.Checked = false;
            //}
            // --- DEL 2013/06/14 Y.Wakita ----------<<<<<
            // --- ADD 2013/06/14 Y.Wakita ---------->>>>>
            if (scmEpScCnt.PrDispSystem == 10 || scmEpScCnt.PrDispSystem == 11)
                this.uOptionSet_PrDispSystem.Value = scmEpScCnt.PrDispSystem;
            // --- ADD 2013/06/14 Y.Wakita ----------<<<<<
            // ADD 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
		}

		/// **********************************************************************
		/// Module name		:	 DispToScmEpCnect
		/// <summary>
		/// 画面情報→連結企業クラス格納処理
		/// </summary>
		/// <param name="scmEpCnect">連結企業クラス</param>
		/// ----------------------------------------------------------------------
		/// <remarks> 
		/// <br>Note        : 画面情報から連結企業オブジェクトクラスにデータを格納します。</br>
		/// <br>Programmer	: 95094  大塚　たえ子</br>
		/// <br>Date		: 2009.05.22</br>
		/// </remarks>
		/// **********************************************************************
		private void DispToScmEpCnect(ref ScmEpCnect scmEpCnect)
		{
            //連結先企業コード
            scmEpCnect.CnectOriginalEpCd    = this.OriginalEpCd_tEdit.Text;
            //連結先企業名称
			scmEpCnect.CnectOriginalEpNm	= this.OriginalEpNm_tEdit.Text;
			//自社企業コード
			scmEpCnect.CnectOtherEpCd		= this.OtherEpCd_tEdit.Text;
			//自社企業名称
			scmEpCnect.CnectOtherEpNm		= this.OtherEpNm_tEdit.Text;
			//種別区分
			scmEpCnect.DiscDivCd			= (int)this.EpDiscDivCd_tComboEditor.Value;
		}

		/// **********************************************************************
		/// Module name		:	 DispToScmEpScCnt
		/// <summary>
		/// 画面情報→連結企業拠点クラス格納処理
		/// </summary>
		/// <param name="scmEpScCnt">連結企業拠点クラス</param>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>Note        : 画面情報から連結企業拠点オブジェクトクラスにデータを格納します。</br>
		/// <br>Programmer	: 95094  大塚　たえ子</br>
		/// <br>Date		: 2009.05.22</br>
		/// </remarks>
		/// **********************************************************************
		private void DispToScmEpScCnt(ref ScmEpScCnt scmEpScCnt)
		{
			// 自社拠点基準(自社企業コード)
            // --------------- ADD START 2011.10.13 呉軍 FOR Redmine#25912 -------->>>>
            if (this.OtherScCd_tComboEditor.Value != null)
            {
                // --------------- ADD END 2011.10.13 呉軍 FOR Redmine#25912 ----------<<<<
                scmEpScCnt.CnectOtherSecCd = this.OtherScCd_tComboEditor.Value.ToString();
            }  // ADD 2011.10.13 呉軍 FOR Redmine#25912
			// 自社拠点名称
            scmEpScCnt.CnectOtherSecNm = this.OtherScNm_tEdit.Text;
            
            // 連結先企業基準（連結企業コード）
			scmEpScCnt.CnectOriginalEpCd		= this.OriginalEpCd_tEdit.Text;

            // 連結企業拠点コード
            scmEpScCnt.CnectOriginalSecCd		= this.OriginalScCd_tEdit.Text;
            // 2014.11.18 ins by Ryo. -start- > > > > >
            if ((this.OriginalScCd_tComboEditor.Visible == true) && (this.OriginalScCd_tComboEditor.Value != null))
            {
                scmEpScCnt.CnectOriginalSecCd = this.OriginalScCd_tComboEditor.Value.ToString();
            }
            // 2014.11.18 ins by Ryo. -e n d- < < < < <

            // 連結企業拠点名称
            scmEpScCnt.CnectOriginalSecNm		= this.OriginalScNm_tEdit.Text;

			//種別区分
			scmEpScCnt.DiscDivCd			= (int)this.ScDiscDivCd_tComboEditor.Value;
            // ADD BY x_zhuxk ON 2011.08.12 STR
            // 通信方式(SCM)
            if (this.SCM_ultraCheckEditor.Checked == false)
            {
                scmEpScCnt.ScmCommMethod = 0;
            }
            else
            {
                scmEpScCnt.ScmCommMethod = 1;
            }
            // 通信方式(PCC-UOE)
            if (this.PCC_UOC_ultraCheckEditor.Checked == false)
            {
                scmEpScCnt.PccUoeCommMethod = 0;
            }
            else
            {
                scmEpScCnt.PccUoeCommMethod = 1;
            }
            // ADD BY x_zhuxk ON 2011.08.12 END
            // ADD 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            // 通信方式(部品問合せ・発注（RCオプション))
            if (this.RC_ultraCheckEditor.Checked)
            {
                scmEpScCnt.RcScmCommMethod = 1;
            }
            else
            {
                scmEpScCnt.RcScmCommMethod = 0;
            }
            // 優先表示システム 10:新品部品(PMを優先表示)　11：リサイクル部品(RCを優先表示)
            // --- DEL 2013/06/14 Y.Wakita ---------->>>>>
            //if (this.radioButton_New.Checked)
            //{
            //    scmEpScCnt.PrDispSystem = 10;
            //}
            //else if (this.radioButton_RC.Checked)
            //{
            //    scmEpScCnt.PrDispSystem = 11;
            //}
            //else
            //{
            //    scmEpScCnt.PrDispSystem = 0;
            //}
            // --- DEL 2013/06/14 Y.Wakita ----------<<<<<
            // ADD 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            // --- ADD 2013/06/14 Y.Wakita ---------->>>>>
            if (this.uOptionSet_PrDispSystem.CheckedItem.DataValue != null)
                scmEpScCnt.PrDispSystem = (short)(int)this.uOptionSet_PrDispSystem.CheckedItem.DataValue;
            // --- ADD 2013/06/14 Y.Wakita ----------<<<<<
        }

        // 2014.09.11 ins by Ryo. -start- > > > > >
        /// **********************************************************************
        /// Module name    : DispToOScmBPSCnt
        /// <summary>
        /// 画面情報 → 提供側SCM事業場拠点連結クラス格納処理
        /// </summary>
        /// <param name="oScmBPSCnt">連結企業拠点クラス</param>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note       : 画面情報から提供側SCM事業場拠点連結オブジェクトクラスにデータを格納します。</br>
        /// <br>Programmer : Ryo.</br>
        /// <br>Date       : 2014.09.11</br>
        /// </remarks>
        /// **********************************************************************
        private void DispToOScmBPSCnt(ref OScmBPSCnt oScmBPSCnt)
        {
            //oScmBPSCnt.CreateDateTime
            //oScmBPSCnt.UpdateDateTime
            //oScmBPSCnt.LogicalDeleteCode
            
            oScmBPSCnt.CnectOtherEpCd = this._enterpriseCode;

            if (this.OtherScCd_tComboEditor.Value != null)
            {
                oScmBPSCnt.CnectOtherSecCd = this.OtherScCd_tComboEditor.Value.ToString();
            }
            
            oScmBPSCnt.CnectOriginalEpCd = this.OriginalEpCd_tEdit.Text;

            // 連結企業拠点コード
            oScmBPSCnt.CnectOriginalSecCd = this.OriginalScCd_tEdit.Text;
            // 2014.11.18 ins by Ryo. -start- > > > > >
            if ((this.OriginalScCd_tComboEditor.Visible == true) && (this.OriginalScCd_tComboEditor.Value != null))
            {
                oScmBPSCnt.CnectOriginalSecCd = this.OriginalScCd_tComboEditor.Value.ToString();
            }
            // 2014.11.18 ins by Ryo. -e n d- < < < < <

            if ((this.OtherUserCd_tComboEditor.Value != null) && 
                (this.OriginalUserCd_tComboEditor.Value != null))
            {
                
                string keyCode = this.OtherUserCd_tComboEditor.Value.ToString() + "-" + oScmBPSCnt.CnectOtherEpCd + "-"  
                               + this.OriginalUserCd_tComboEditor.Value.ToString() + "-" + oScmBPSCnt.CnectOriginalEpCd;

                if (this._oScmBPCntTable.ContainsKey(keyCode) == true)
                {
                    oScmBPSCnt.ContractantCode = this._oScmBPCntTable[keyCode].ContractantCode;
                    oScmBPSCnt.FTCCustomerCode = this._oScmBPCntTable[keyCode].FTCCustomerCode;
                    oScmBPSCnt.TransContractantCd = this._oScmBPCntTable[keyCode].TransContractantCd;
                    oScmBPSCnt.TransCustomerCd = this._oScmBPCntTable[keyCode].TransCustomerCd;
                }
                else
                {

                    foreach (OScmBPCnt oScmBPCnt in this._oScmBPCntTable.Values)
                    {
                        string blUserCode = oScmBPCnt.BLUserCode1.TrimEnd() + "-" + oScmBPCnt.BLUserCode2.TrimEnd();

                        if (blUserCode == this.OtherUserCd_tComboEditor.Value.ToString())
                        {
                            oScmBPSCnt.ContractantCode = oScmBPCnt.ContractantCode;
                            oScmBPSCnt.FTCCustomerCode = oScmBPCnt.FTCCustomerCode;
                            break;
                        }
                    }

                    foreach (OScmBPCnt oScmBPCnt in this._oScmBPCntTable.Values)
                    {
                        string transBlUserCode = oScmBPCnt.TransBLUserCode1.TrimEnd() + "-" + oScmBPCnt.TransBLUserCode2.TrimEnd();

                        if (transBlUserCode == this.OriginalUserCd_tComboEditor.Value.ToString())
                        {
                            oScmBPSCnt.TransContractantCd = oScmBPCnt.TransContractantCd;
                            oScmBPSCnt.TransCustomerCd = oScmBPCnt.TransCustomerCd;
                            break;
                        }
                    }
                }
            }
        }

        /// **********************************************************************
        /// Module name    : DispToOScmBPCnt
        /// <summary>
        /// 画面情報 → 提供側SCM事業場連結クラス格納処理
        /// </summary>
        /// <param name="oScmBPCnt">提供側SCM事業場連結クラス</param>
        /// <param name="oScmBPSCnt">提供側SCM事業場拠点連結クラス</param>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note       : 画面情報から提供側SCM事業場拠点連結オブジェクトクラスにデータを格納します。</br>
        /// <br>Programmer : Ryo.</br>
        /// <br>Date       : 2014.09.11</br>
        /// </remarks>
        /// **********************************************************************
        private void DispToOScmBPCnt(ref OScmBPCnt oScmBPCnt, OScmBPSCnt oScmBPSCnt)
        {
            if ((this.OtherUserCd_tComboEditor.Value != null) && (this.OriginalUserCd_tComboEditor.Value != null))
            {
                string keyCode = this.OtherUserCd_tComboEditor.Value.ToString() + "-" + oScmBPSCnt.CnectOtherEpCd + "-"
                               + this.OriginalUserCd_tComboEditor.Value.ToString() + "-" + oScmBPSCnt.CnectOriginalEpCd;

                if (this._oScmBPCntTable.ContainsKey(keyCode) == true)
                {
                    oScmBPCnt = this._oScmBPCntTable[keyCode];
                }
                else
                {
                    oScmBPCnt.LogicalDeleteCode = 0;

                    foreach (OScmBPCnt wOScmBPCnt in this._oScmBPCntTable.Values)
                    {
                        string blUserCode = wOScmBPCnt.BLUserCode1.TrimEnd() + "-" + wOScmBPCnt.BLUserCode2.TrimEnd();

                        if (blUserCode == this.OtherUserCd_tComboEditor.Value.ToString())
                        {
                            oScmBPCnt.ContractantCode = wOScmBPCnt.ContractantCode;
                            oScmBPCnt.FTCCustomerCode = wOScmBPCnt.FTCCustomerCode;
                            oScmBPCnt.BLUserCode1     = wOScmBPCnt.BLUserCode1;
                            oScmBPCnt.BLUserCode2     = wOScmBPCnt.BLUserCode2;
                            oScmBPCnt.CnectOtherEpCd  = wOScmBPCnt.CnectOtherEpCd;
                            oScmBPCnt.ContractantName = wOScmBPCnt.ContractantName;
                            oScmBPCnt.FTCCustomerName = wOScmBPCnt.FTCCustomerName;
                            break;
                        }
                    }

                    foreach (OScmBPCnt wOScmBPCnt in this._oScmBPCntTable.Values)
                    {
                        string transBlUserCode = wOScmBPCnt.TransBLUserCode1.TrimEnd() + "-" + wOScmBPCnt.TransBLUserCode2.TrimEnd();

                        if (transBlUserCode == this.OriginalUserCd_tComboEditor.Value.ToString())
                        {
                            oScmBPCnt.TransContractantCd = wOScmBPCnt.TransContractantCd;
                            oScmBPCnt.TransCustomerCd    = wOScmBPCnt.TransCustomerCd;
                            oScmBPCnt.TransBLUserCode1   = wOScmBPCnt.TransBLUserCode1;
                            oScmBPCnt.TransBLUserCode2   = wOScmBPCnt.TransBLUserCode2;
                            oScmBPCnt.CnectOriginalEpCd  = wOScmBPCnt.CnectOriginalEpCd;
                            oScmBPCnt.TransContractantNm = wOScmBPCnt.TransContractantNm;
                            oScmBPCnt.TransCustomerNm    = wOScmBPCnt.TransCustomerNm;
                            break;
                        }
                    }

                    oScmBPCnt.CooprtDataUpdateDiv = 1;

                }
            }
        }
        // 2014.09.11 ins by Ryo. -e n d- < < < < <

		/// **********************************************************************
		/// Module name		:	 akeScmEpScCntKeyFormRowIndex
		/// <summary>
		/// bind_DataSetから連結企業拠点情報取得処理
		/// </summary>
		/// <param name="retScmEpScCnt">連結企業拠点クラス</param>
		/// <param name="dataIndex">行インデックス</param>
		/// <param name="targetTableName">参照テーブル名称</param>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>Note		: bind_DataSetテーブル情報から該当Indexの情報を連結企業拠点クラスにセットして返します。</br>
		/// <br>Programmer	: 95094  大塚　たえ子</br>
		/// <br>Date		: 2009.05.22</br>
		/// </remarks>
		/// **********************************************************************
		private void MakeScmEpScCntKeyFormRowIndex(ref  ScmEpScCnt retScmEpScCnt, int dataIndex, string targetTableName)
		{
			//画面よりキー情報取得
            retScmEpScCnt.CnectOriginalEpCd = this._bind_DataSet.Tables[targetTableName].Rows[dataIndex][ct_B_CNECTORGEPCD].ToString().TrimEnd();
            retScmEpScCnt.CnectOriginalSecCd = this._bind_DataSet.Tables[targetTableName].Rows[dataIndex][ct_B_CNECTORGSECCD].ToString().TrimEnd();
            retScmEpScCnt.CnectOtherEpCd = this._enterpriseCode;
            retScmEpScCnt.CnectOtherSecCd = this._bind_DataSet.Tables[targetTableName].Rows[dataIndex][ct_B_CNECTOTHERSECCD].ToString().TrimEnd(); 
		}

		/// **********************************************************************
		/// Module name		:	 MakeScmEpScCntTableContainsKey
		/// <summary>
		/// キー名称作成処理
		/// </summary>
		/// <param name="scmEpScCnt"></param>
		/// <returns></returns>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>Note		: 連結企業拠点のデーブル用のキー作成を行います。</br>
		/// <br>Programmer	: 95094  大塚　たえ子</br>
		/// <br>Date		: 2009.05.22</br>
		/// </remarks>
		/// **********************************************************************
		private string MakeScmEpScCntTableContainsKey(ScmEpScCnt scmEpScCnt)
		{
			string makeKey = scmEpScCnt.CnectOriginalEpCd.TrimEnd() + "-" + scmEpScCnt.CnectOriginalSecCd.TrimEnd() + "-" + scmEpScCnt.CnectOtherEpCd.TrimEnd() + "-" + scmEpScCnt.CnectOtherSecCd.TrimEnd();
			return makeKey;
		}

        // 2014.09.11 ins by Ryo. -start- > > > > >
        /// **********************************************************************
        /// Module name    : MakeOScmBPSCntTableContainsKey
        /// <summary>
        /// Dictionary Key 作成処理
        /// </summary>
        /// <param name="oScmBPSCnt"></param>
        /// <returns></returns>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note       : 提供側SCM事業場拠点連結Table用のKey作成を行います。</br>
        /// <br>Programmer : Ryo.</br>
        /// <br>Date       : 2014.09.11</br>
        /// </remarks>
        /// **********************************************************************
        private string MakeOScmBPSCntTableContainsKey(OScmBPSCnt oScmBPSCnt)
        {
            string makeKey = oScmBPSCnt.CnectOriginalEpCd.TrimEnd() + "-" + oScmBPSCnt.CnectOriginalSecCd.TrimEnd() + "-" + oScmBPSCnt.CnectOtherEpCd.TrimEnd() + "-" + oScmBPSCnt.CnectOtherSecCd.TrimEnd();
            return makeKey;
        }

        /// **********************************************************************
        /// Module name    : MakeOScmBPCntTableContainsKey
        /// <summary>
        /// Dictionary Key 作成処理
        /// </summary>
        /// <param name="oScmBPCnt"></param>
        /// <returns></returns>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note       : 提供側SCM事業場連結Table用のKey作成を行います。</br>
        /// <br>Programmer : Ryo.</br>
        /// <br>Date       : 2014.09.11</br>
        /// </remarks>
        /// **********************************************************************
        public static string MakeOScmBPCntTableContainsKey(OScmBPCnt oScmBPCnt)
        {
            string makeKey = oScmBPCnt.BLUserCode1.TrimEnd() + "-" + oScmBPCnt.BLUserCode2.TrimEnd() + "-" + oScmBPCnt.CnectOtherEpCd.TrimEnd() + "-"
                           + oScmBPCnt.TransBLUserCode1.TrimEnd() + "-" + oScmBPCnt.TransBLUserCode2.TrimEnd() + "-" + oScmBPCnt.CnectOriginalEpCd.TrimEnd();
            return makeKey;
        }
        // 2014.09.11 ins by Ryo. -e n d- < < < < <

		#endregion

		// ===================================================================================== //
		//  画面変更・入力必須チェック処理
		// ===================================================================================== //
		#region 画面変更・入力必須チェック処理

		/// **********************************************************************
		/// Module name		:	 IsChangeDataA
		/// <summary>
		/// 画面入力情報変更チェック処理
		/// </summary>
		/// <returns>変更チェック結果（true:変更有り／false:変更無し）</returns>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>Note		: 画面入力情報の変更チェックを行います。</br>
		/// <br>Programmer	: 22024  寺坂　誉志</br>
		/// <br>Date		: 2009.07.15</br>
		/// </remarks>
		/// **********************************************************************
		private bool IsChangeDataA()
		{
			bool changeDataflg = false;

			ScmEpCnect originScmEpCnect;
			ScmEpCnect nowScmEpCnect;
			if (this._mainDataIndex >= 0)
			{
				string keyCode = _bind_DataSet.Tables[this._targetTableName].Rows[this._mainDataIndex][ct_A_CNECTORGEPCD].ToString();
				originScmEpCnect = this._scmEpCnectTable[keyCode];
			}
			else
			{
				originScmEpCnect = CreateNewScmEpCnect();
			}

			nowScmEpCnect = originScmEpCnect.Clone();
			DispToScmEpCnect(ref nowScmEpCnect);

			if (originScmEpCnect.Equals(nowScmEpCnect) == false)
				changeDataflg = true;

			return changeDataflg;
		}

		/// **********************************************************************
		/// Module name		:	 IsChangeDataB
		/// <summary>
		/// 画面入力情報変更チェック処理
		/// </summary>
		/// <returns>変更チェック結果（true:変更有り／false:変更無し）</returns>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>Note		: 画面入力情報の変更チェックを行います。</br>
		/// <br>Programmer	: 22024  寺坂　誉志</br>
		/// <br>Date		: 2009.07.15</br>
		/// </remarks>
		/// **********************************************************************
		private bool IsChangeDataB()
		{
			bool changeDataflg = false;

			ScmEpScCnt originScmEpScCnt;
			ScmEpScCnt nowScmEpScCnt;

            // 2014.09.11 ins by Ryo. -start- > > > > >
            OScmBPSCnt orgOScmBPSCnt;
            OScmBPSCnt nowOScmBPSCnt;
            // 2014.09.11 ins by Ryo. -e n d- < < < < <
            
            if (this._detailsDataIndex >= 0)
			{
				ScmEpScCnt scmEpScCnt = new ScmEpScCnt();
				MakeScmEpScCntKeyFormRowIndex(ref scmEpScCnt, this._detailsDataIndex, this._targetTableName);
				string keyCode = MakeScmEpScCntTableContainsKey(scmEpScCnt);

				originScmEpScCnt = this._scmEpScCntTable[keyCode];

                // 2014.09.11 ins by Ryo. -start- > > > > >
                if (this._oScmBPSCntTable.ContainsKey(keyCode) == true)
                {
                    orgOScmBPSCnt = this._oScmBPSCntTable[keyCode];
                }
                else
                {
                    orgOScmBPSCnt = CreateNewOScmBPSCnt();
                }
                // 2014.09.11 ins by Ryo. -e n d- < < < < <
			}
			else
			{
				originScmEpScCnt = CreateNewScmEpScCnt();
                orgOScmBPSCnt = CreateNewOScmBPSCnt();  // 2014.09.11 ins by Ryo.
            }

			nowScmEpScCnt = originScmEpScCnt.Clone();
			DispToScmEpScCnt(ref nowScmEpScCnt);

            // 2014.09.11 ins by Ryo. -start- > > > > >
            nowOScmBPSCnt = orgOScmBPSCnt.Clone();
            DispToOScmBPSCnt(ref nowOScmBPSCnt);
            // 2014.09.11 ins by Ryo. -e n d- < < < < <

            // UPD 2013/11/28 商品保証課Redmine#711対応 -------------------------->>>>>
            //if (originScmEpScCnt.Equals(nowScmEpScCnt) == false)
            //    changeDataflg = true;

            ArrayList compAList = originScmEpScCnt.Compare(nowScmEpScCnt);
            if (compAList.Count != 0)
            {
                // データベースに優先表示システムはゼロ及び画面にデータが変更されませんの場合
                if (compAList.Count == 1 && compAList.Contains("PrDispSystem") && nowScmEpScCnt.PrDispSystem == 10 && originScmEpScCnt.PrDispSystem == 0)
                {
                    changeDataflg = false;
                }
                else
                {
                    changeDataflg = true;
                }
            }
            // UPD 2013/11/28 商品保証課Redmine#711対応 --------------------------<<<<<

            // 2014.09.11 ins by Ryo. -start- > > > > >
            if (orgOScmBPSCnt.Equals(nowOScmBPSCnt) == false)
            {
                changeDataflg = true;
            }
            // 2014.09.11 ins by Ryo. -e n d- < < < < <

			return changeDataflg;
		}

		/// **********************************************************************
		/// Module name		:	 ScreenDataCheckA
		/// <summary>
		/// 画面入力情報不正チェック処理
		/// </summary>
		/// <param name="control">不正対象コントロール</param>
		/// <param name="message">メッセージ</param>
		/// <returns>NGデータチェック結果（true:OK／false:NG）</returns>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>Note        : 画面入力情報の不正チェックを行います。</br>
		/// <br>Programmer	: 95094  大塚　たえ子</br>
		/// <br>Date		: 2009.05.22</br>
		/// </remarks>
		/// **********************************************************************
		private bool ScreenDataCheckA(ref Control control, ref string message)
		{
			bool result = true;

			// 入力チェック
			if (this.OriginalEpNm_tEdit.Text.TrimEnd() == string.Empty)
			{
				control = this.OriginalEpNm_tEdit;
				message = this.OriginalEpNm_ultraLabel.Text + "の入力を行ってください。";
				result = false;
			}
			else if (this.OtherEpCd_tEdit.Text.TrimEnd() == string.Empty)
			{
				control = this.OtherEpCd_tEdit;
				message = this.OtherEpCd_ultraLabel.Text + "の入力を行ってください。";
				result = false;
			}
			else if (this.OtherEpNm_tEdit.Text.TrimEnd() == string.Empty)
			{
				control = this.OtherEpNm_tEdit;
				message = this.OtherEpNm_ultraLabel.Text + "の入力を行ってください。";
				result = false;
			}

			if (result == false) return result;

			if (Mode_Label.Text == INSERT_MODE)
			{
                // UPD 2014/11/18 豊沢 SCM仕掛一覧No.10696 ---------->>>>>>>>>>
				//if (this.OtherEpCd_tEdit.Text.TrimEnd() != string.Empty)
				//{
				//	DataRow[] dataRows = this._bind_DataSet.Tables[ct_SCMEPCNECT_TABLE].Select(ct_A_CNECTORGEPCD + "=" + this.OtherEpCd_tEdit.Text.TrimEnd());

				//	if (dataRows.Length > 0)
				//	{
				//		control = this.OtherEpCd_tEdit;
				//		message = this.OtherEpCd_ultraLabel.Text + "が重複しています。";
				//		result = false;
				//	}
				//}
                if (this.OriginalEpCd_tEdit.Text.TrimEnd() != string.Empty)
				{
                    DataRow[] dataRows = this._bind_DataSet.Tables[ct_SCMEPCNECT_TABLE].Select(ct_A_CNECTORGEPCD + "='" + this.OriginalEpCd_tEdit.Text.TrimEnd() + "'");

					if (dataRows.Length > 0)
					{
                        control = this.OriginalEpCd_tEdit;
                        message = this.OriginalEpCd_ultraLabel.Text + "が重複しています。";
						result = false;
					}
				}
                // UPD 2014/11/18 豊沢 SCM仕掛一覧No.10696 ----------<<<<<<<<<<
			}

			return result;
		}

		/// **********************************************************************
		/// Module name		:	 ScreenDataCheckB
		/// <summary>
		/// 画面入力情報不正チェック処理
		/// </summary>
		/// <param name="control">不正対象コントロール</param>
		/// <param name="message">メッセージ</param>
		/// <returns>NGデータチェック結果（true:OK／false:NG）</returns>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>Note        : 画面入力情報の不正チェックを行います。</br>
		/// <br>Programmer	: 95094  大塚　たえ子</br>
		/// <br>Date		: 2009.05.22</br>
		/// </remarks>
		/// **********************************************************************
		private bool ScreenDataCheckB(ref Control control, ref string message)
		{
			bool result = true;

            if (this.OriginalScNm_tEdit.Text == string.Empty)
            {
            	control = this.OriginalScNm_tEdit;
            	message = this.OriginalScNm_ultraLabel.Text + "の入力を行ってください。";
            	result = false;
            }
			//else if (this.OriginalScCd_tEdit.Text == string.Empty)  // 2014.11.18 del by Ryo.
			else if ((this.OriginalScCd_tEdit.Text == string.Empty) &&   // 2014.11.18 ins by Ryo.
                     (this.OriginalScCd_tEdit.Visible == true)        )  // 2014.11.18 ins by Ryo. 
			{
				control = this.OriginalScCd_tEdit;
                //message = this.OtherScCd_ultraLabel.Text + "の入力を行ってください。";   // 2014.09.11 del by Ryo.
                message = this.OriginalScCd_ultraLabel.Text + "の入力を行ってください。";  // 2014.09.11 ins by Ryo.
                result = false;
			}
            // 2014.11.18 ins by Ryo. -start- > > > > >
            else if ((this.OriginalScCd_tComboEditor.Text.TrimEnd() == string.Empty) &&
                     (this.OriginalScCd_tComboEditor.Visible == true)                  )
            {
                control = this.OriginalScCd_tComboEditor;
                message = this.OriginalScCd_ultraLabel.Text + "の選択を行ってください。";
                result = false;
            }
            // 2014.11.18 ins by Ryo. -e n d- < < < < <
            else if (this.OtherScNm_tEdit.Text == string.Empty)
            {
                control = this.OtherScNm_tEdit;
                message = this.OtherScNm_ultraLabel.Text + "の入力を行ってください。";
                result = false;
            }

            // --- DEL 2013/06/14 Y.Wakita ---------->>>>>
            //// ADD 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            //else if (this.radioButton_New.Checked.Equals(false) && this.radioButton_RC.Checked.Equals(false))
            //{
            //    // 優先表示システムが未設定
            //    control = this.radioButton_New;
            //    message = this.ultraLabel_DisplayOrder.Text + "の入力を行ってください。";
            //    result = false;
            //}
            //// ADD 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            // --- DEL 2013/06/14 Y.Wakita ----------<<<<<

            // 2014.09.11 ins by Ryo. -start- > > > > >
            // 接続先  ユーザーコード/名称
            else if ((this.OriginalUserCd_tComboEditor.Text.TrimEnd() == string.Empty) && 
                     (this.OriginalUserCd_tComboEditor.Items.Count > 0))
            {
                control = this.OriginalUserCd_tComboEditor;
                message = this.OriginalUserCd_ultraLabel.Text + "の選択を行ってください。";
                result = false;
            }
            // 自社接続先  ユーザーコード/名称
            else if ((this.OtherUserCd_tComboEditor.Text.TrimEnd() == string.Empty) &&
                     (this.OtherUserCd_tComboEditor.Items.Count > 0))
            {
                control = this.OtherUserCd_tComboEditor;
                message = this.OtherUserCd_ultraLabel.Text + "の選択を行ってください。";
                result = false;
            }
            // 2014.09.11 ins by Ryo. -e n d- < < < < <

			if (result == false) return result;

            // --------------- ADD START 2011.10.13 呉軍 FOR Redmine#25912 -------->>>>
            if (Mode_Label.Text == UPDATE_MODE)
            {
                if (this.OtherScCd_tComboEditor.Value == null)
                {
                    control = this.Save_Button;
                    message = "指定された拠点は存在しません。\r\n登録を行った端末にて正しい拠点コードを設定してください。";
                    result = false;
                    return result;
                }
            }
            // --------------- ADD END 2011.10.13 呉軍 FOR Redmine#25912 ----------<<<<

			if (Mode_Label.Text == INSERT_MODE)
			{
                //if (this.OriginalScCd_tEdit.Text.TrimEnd() != string.Empty)     // 2014.11.18 del by Ryo.
                if ((this.OriginalScCd_tEdit.Text.TrimEnd() != string.Empty) &&   // 2014.11.18 ins by Ryo.
                    (this.OriginalScCd_tEdit.Visible == true)                  )  // 2014.11.18 ins by Ryo. 
                {
					string filter = string.Format("{0}='{1}' AND {2}='{3}'",
						ct_B_CNECTOTHERSECCD,
						this.OtherScCd_tComboEditor.Value.ToString(),
						ct_B_CNECTORGSECCD,
						this.OriginalScCd_tEdit.Text);
            
					DataRow[] dataRows = this._bind_DataSet.Tables[ct_SCMEPSCCNT_TABLE].Select(filter);
					if (dataRows.Length > 0)
					{
                        control = this.OriginalScCd_tEdit;
                        //message = this.OtherScCd_ultraLabel.Text + "が重複しています。";
                        message = this.OriginalScCd_ultraLabel.Text + "が重複しています。";

                        result = false;
					}
				}

                // 2014.11.18 ins by Ryo. -start- > > > > >
                if ((this.OriginalScCd_tComboEditor.Text.TrimEnd() != string.Empty) &&
                   (this.OriginalScCd_tComboEditor.Visible == true)                   )
                {
                    string filter = string.Format("{0}='{1}' AND {2}='{3}'",
                        ct_B_CNECTOTHERSECCD,
                        this.OtherScCd_tComboEditor.Value.ToString(),
                        ct_B_CNECTORGSECCD,
                        this.OriginalScCd_tComboEditor.Value.ToString());

                    DataRow[] dataRows = this._bind_DataSet.Tables[ct_SCMEPSCCNT_TABLE].Select(filter);
                    if (dataRows.Length > 0)
                    {
                        control = this.OriginalScCd_tComboEditor;
                        message = this.OtherScCd_ultraLabel.Text + "が重複しています。";

                        result = false;
                    }
                }
                // 2014.11.18 ins by Ryo. -e n d- < < < < <
            
            }

			return result;
		}

		#endregion

		// ===================================================================================== //
		//  保存処理
		// ===================================================================================== //
		#region 保存処理

		/// **********************************************************************
		/// Module name		:	 SaveScmEpCnect
		/// <summary>
		/// 保存処理（連結企業）
		/// </summary>
		/// <returns>登録結果（true:OK／false:NG）</returns>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>Note     　 : 連結企業の登録を行います。</br>
		/// <br>Programmer	: 95094  大塚　たえ子</br>
		/// <br>Date		: 2009.05.22</br>
		/// </remarks>
		/// **********************************************************************
		private bool SaveScmEpCnect()
		{
			Save_Button.Focus();

			Control control = null;
			int status;
			string message = string.Empty;

			if (!ScreenDataCheckA(ref control, ref message))
			{
				// 入力チェック
				TMsgDisp.Show(
					this, 								// 親ウィンドウフォーム
					emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
					ctASSEMBLY_ID, 						// アセンブリＩＤまたはクラスＩＤ
					message, 							// 表示するメッセージ
					0, 									// ステータス値
					MessageBoxButtons.OK);				// 表示するボタン
				control.Focus();
				return false;
			}

			if (IsChangeDataA() == false) return true;
			
			//画面情報→クラス格納処理
			ScmEpCnect scmEpCnect = null;
			if (this._mainDataIndex >= 0)
			{
				string keyCode = this._bind_DataSet.Tables[ct_SCMEPCNECT_TABLE].Rows[this._mainDataIndex][ct_A_CNECTORGEPCD].ToString();
				scmEpCnect = this._scmEpCnectTable[keyCode].Clone();
			}
			else
			{
				scmEpCnect = CreateNewScmEpCnect();
			}

			DispToScmEpCnect(ref scmEpCnect);

			ScmEpCnect[] scmEpCnects = new ScmEpCnect[1] { scmEpCnect };

			bool msgDiv = false;
			string errMsg = string.Empty;
			status = this._scmEpCnectAcs.WriteScmEpCnect(ref scmEpCnects, out msgDiv, out errMsg);
			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				ScmEpCnectToDataSet(scmEpCnects[0], this._mainDataIndex);
			}

			return SaveErrorMessage(status, msgDiv, errMsg, "SaveScmEpCnect");
		}

		/// **********************************************************************
		/// Module name		:	 SaveScmEpScCnt
		/// <summary>
		/// 保存処理（連結企業拠点）
		/// </summary>
		/// <returns>登録結果（true:OK／false:NG）</returns>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>Note     　 : 連結企業拠点の登録を行います。</br>
		/// <br>Programmer	: 95094  大塚　たえ子</br>
		/// <br>Date		: 2009.05.22</br>
		/// </remarks>
		/// **********************************************************************
		private bool SaveScmEpScCnt()
		{
			Save_Button.Focus();

			Control control = null;
			string message = string.Empty;

			if (!ScreenDataCheckB(ref control, ref message))
			{
				// 入力チェック
				TMsgDisp.Show(
					this, 								// 親ウィンドウフォーム
					emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
					ctASSEMBLY_ID, 						// アセンブリＩＤまたはクラスＩＤ
					message, 							// 表示するメッセージ
					0, 									// ステータス値
					MessageBoxButtons.OK);				// 表示するボタン
				control.Focus();
				return false;
			}

			if (IsChangeDataB() == false) return true;

			// 画面情報→クラス格納処理
			ScmEpScCnt scmEpScCnt = null;
            OScmBPSCnt oScmBPSCnt = null;           // 2014.09.11 ins by Ryo.
            OScmBPCnt oScmBPCnt = new OScmBPCnt();  // 2014.09.11 ins by Ryo.

			if (this._detailsDataIndex >= 0)
			{
				scmEpScCnt = new ScmEpScCnt();
				MakeScmEpScCntKeyFormRowIndex(ref scmEpScCnt, this._detailsDataIndex, this._targetTableName);

				string keyCode = MakeScmEpScCntTableContainsKey(scmEpScCnt);
				scmEpScCnt = this._scmEpScCntTable[keyCode].Clone();

                // 2014.09.11 ins by Ryo. -start- > > > > >
                if (this._oScmBPSCntTable.ContainsKey(keyCode) == true)
                {
                    oScmBPSCnt = this._oScmBPSCntTable[keyCode];
                }
                else
                {
                    oScmBPSCnt = CreateNewOScmBPSCnt();
                }
                // 2014.09.11 ins by Ryo. -e n d- < < < < <
			}
			else
			{
				scmEpScCnt = CreateNewScmEpScCnt();
                oScmBPSCnt = CreateNewOScmBPSCnt();  // 2014.09.11 ins by Ryo.
			}

			DispToScmEpScCnt(ref scmEpScCnt);
            //ScmEpScCnt[] scmEpScCnts = new ScmEpScCnt[1] { scmEpScCnt };  // 2014.09.11 del by Ryo.

            // 2014.09.11 ins by Ryo. -start- > > > > >
            // 提供側SCM事業場拠点連結データ
            DispToOScmBPSCnt(ref oScmBPSCnt);
            // 提供側SCM事業場連結データ
            DispToOScmBPCnt(ref oScmBPCnt, oScmBPSCnt);
            // 2014.09.11 ins by Ryo. -e n d- < < < < <

			bool msgDiv = false;
			string errMsg = string.Empty;

            bool IsInsFTCCustomer = (oScmBPCnt.FTCCustomerCode == 0);

            //int status = this._scmEpScCntAcs.WriteScmEpScCnt(ref scmEpScCnts, out msgDiv, out errMsg);  // 2014.09.11 del by Ryo.
            int status = this._scmEpScCntAcs.WriteScmEpScCntWithFTC(ref scmEpScCnt, ref oScmBPSCnt, ref oScmBPCnt, out msgDiv, out errMsg);  // 2014.09.11 ins by Ryo.

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
                //ScmEpScCntToDataSet(scmEpScCnts[0], this._detailsDataIndex, true);  // 2014.09.11 del by Ryo.
                ScmEpScCntToDataSet(scmEpScCnt, this._detailsDataIndex, true);        // 2014.09.11 ins by Ryo.

                // 2014.09.11 ins by Ryo. -start- > > > > >
                if (this._oScmBPSCntTable.ContainsKey(MakeOScmBPSCntTableContainsKey(oScmBPSCnt)) == true)
                {
                    this._oScmBPSCntTable.Remove(MakeOScmBPSCntTableContainsKey(oScmBPSCnt));
                }
                this._oScmBPSCntTable.Add(MakeOScmBPSCntTableContainsKey(oScmBPSCnt), oScmBPSCnt);

                if (this._oScmBPCntTable.ContainsKey(MakeOScmBPCntTableContainsKey(oScmBPCnt)) == true)
                {
                    this._oScmBPCntTable.Remove(MakeOScmBPCntTableContainsKey(oScmBPCnt));
                }
                this._oScmBPCntTable.Add(MakeOScmBPCntTableContainsKey(oScmBPCnt), oScmBPCnt);
                // 2014.09.11 ins by Ryo. -e n d- < < < < <
                // 2014.11.18 ins by Ryo. -start- > > > > >
                if (IsInsFTCCustomer == true)
                {
                    foreach (OScmBPCnt oScmBPCntRec in this._oScmBPCntTable.Values)
                    {
                        if ((oScmBPCntRec.CnectOtherEpCd == oScmBPCnt.CnectOtherEpCd) &&
                            (oScmBPCntRec.BLUserCode1 == oScmBPCnt.BLUserCode1) &&
                            (oScmBPCntRec.BLUserCode2 == oScmBPCnt.BLUserCode2) &&
                            (oScmBPCntRec.ContractantCode == oScmBPCnt.ContractantCode)) 
                        {
                            oScmBPCntRec.FTCCustomerCode = oScmBPCnt.FTCCustomerCode;
                        }
                    }
                }
                // 2014.11.18 ins by Ryo. -e n d- < < < < <
			}

			return SaveErrorMessage(status, msgDiv, errMsg, "SaveScmEpScCnt");
		}

		/// **********************************************************************
		/// Module name		:	 SaveErrorMessage
		/// <summary>
		/// 保存時のエラーメッセージ対応
		/// </summary>
		/// <param name="status">保存時ステータス</param>
		/// <param name="msgDiv">メッセージ有無</param>
		/// <param name="errMsg">メッセージ</param>
		/// <param name="methodName">保存処理メソッド名称</param>
		/// <returns>bool</returns>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>Note     　 : 連結企業拠点の登録を行います。</br>
		/// <br>Programmer	: 95094  大塚　たえ子</br>
		/// <br>Date		: 2009.05.22</br>
		/// </remarks>
		/// **********************************************************************
		private bool SaveErrorMessage(int status, bool msgDiv, string errMsg, string methodName)
		{
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
				{
					// コード重複
					TMsgDisp.Show(
						this, 								// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_INFO, 		// エラーレベル
						ctASSEMBLY_ID, 						// アセンブリＩＤまたはクラスＩＤ
						"このコードは既に使用されています。",	// 表示するメッセージ
						0, 									// ステータス値
						MessageBoxButtons.OK);				// 表示するボタン
					return false;
				}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					// 排他処理
					ExclusiveTransaction(status);

					if (UnDisplaying != null)
					{
						MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
						UnDisplaying(this, me);
					}

					this.DialogResult = DialogResult.Cancel;

					this._mainIndexBuf		= -2;
					this._detailsIndexBuf	= -2;
					this._targetTableBuf	= string.Empty;

					if (CanClose == true)
						this.Close();
					else
						this.Hide();

					return false;
				}
				case (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT:
				{
					string message = "データの書込みにてタイムアウトが発生しました。";
					if (msgDiv)
						message = message + Environment.NewLine + Environment.NewLine + "*詳細 = " + errMsg;

					TMsgDisp.Show(
						emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
						ctASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
						ctASSEMBLY_NAME,					// プログラム名称
						"Search", 							// 処理名称
						TMsgDisp.OPE_UPDATE,				// オペレーション
						message,							// サーバーからのメッセージを表示
						status,								// ステータス値
						this._scmEpCnectAcs,				// エラーが発生したオブジェクト
						MessageBoxButtons.OK,				// 表示するボタン
						MessageBoxDefaultButton.Button1);	// 初期表示ボタン
					break;
				}
				default:
				{
					// 登録失敗
					TMsgDisp.Show(
						this, 								// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_STOPDISP, 	// エラーレベル
						ctASSEMBLY_ID, 						// アセンブリＩＤまたはクラスＩＤ
						ctASSEMBLY_NAME,					// プログラム名称
						methodName,							// 処理名称
						TMsgDisp.OPE_UPDATE,				// オペレーション
						"登録に失敗しました。",				// 表示するメッセージ
						status,								// ステータス値
						this._scmEpCnectAcs,				// エラーが発生したオブジェクト
						MessageBoxButtons.OK,				// 表示するボタン
						MessageBoxDefaultButton.Button1);	// 初期表示ボタン

					if (UnDisplaying != null)
					{
						MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
						UnDisplaying(this, me);
					}

					this.DialogResult = DialogResult.Cancel;

					this._mainIndexBuf		= -2;
					this._detailsIndexBuf	= -2;
					this._targetTableBuf	= string.Empty;

					if (CanClose == true)
						this.Close();
					else
						this.Hide();

					return false;
				}
			}
			return true;
		}


		/// **********************************************************************
		/// Module name		:	 ExclusiveTransaction
		/// <summary>
		/// 排他処理
		/// </summary>
		/// <param name="status">ステータス</param>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>Note     　 : データ更新時の排他処理を行います。</br>
		/// <br>Programmer	: 95094  大塚　たえ子</br>
		/// <br>Date		: 2009.05.22</br>
		/// </remarks>
		/// **********************************************************************
		private void ExclusiveTransaction(int status)
		{
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				{
					// 他端末更新
					TMsgDisp.Show(
						this, 								// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
						"SFZAI09200U", 						// アセンブリＩＤまたはクラスＩＤ
						"既に他端末より更新されています。", // 表示するメッセージ
						0, 									// ステータス値
						MessageBoxButtons.OK);				// 表示するボタン
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					// 他端末削除
					TMsgDisp.Show(
						this, 								// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
						"SFZAI09200U", 						// アセンブリＩＤまたはクラスＩＤ
						"既に他端末より削除されています。", // 表示するメッセージ
						0, 									// ステータス値
						MessageBoxButtons.OK);				// 表示するボタン
					break;
				}
			}
		}

		#endregion

		// ===================================================================================== //
		//  復活処理
		// ===================================================================================== //
		#region 復活処理

		/// **********************************************************************
		/// Module name		:	 RevivalProc
		/// <summary>
		/// 復活処理処理
		/// </summary>
		/// <returns>復活結果（true:OK／false:NG）</returns>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>Note     　 : 連結企業、連結企業拠点の復活を行います。</br>
		/// <br>Programmer	: 22024  寺坂　誉志</br>
		/// <br>Date		: 2009.07.15</br>
		/// </remarks>
		/// **********************************************************************
		private bool RevivalProc()
		{
			bool result = false;

			// 連結企業
			if (this._targetTableName == ct_SCMEPCNECT_TABLE)
			{
				// 連結企業コード取得
				string keyCode = this._bind_DataSet.Tables[ct_SCMEPCNECT_TABLE].Rows[this._mainDataIndex][ct_A_CNECTORGEPCD].ToString();
				ScmEpCnect scmEpCnect = this._scmEpCnectTable[keyCode];

				// 削除LogicalDelete
				bool msgDiv;
				string errMsg;
				ScmEpCnect[] scmEpCnects = new ScmEpCnect[1] { scmEpCnect };
				int status = this._scmEpCnectAcs.RevivalScmEpCnect(ref scmEpCnects, out msgDiv, out errMsg);
				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						ScmEpCnectToDataSet(scmEpCnects[0], this._mainDataIndex);
						result = true;
						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
					case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
					{
						ExclusiveTransaction(status);
						break;
					}
					default:
					{
						TMsgDisp.Show(this						// 親ウィンドウフォーム
							, emErrorLevel.ERR_LEVEL_STOPDISP	// エラーレベル
							, ctASSEMBLY_ID						// アセンブリIDまたはクラスID
							, ctASSEMBLY_NAME					// プログラム名称
							, "RevivalProc"						// 処理名称
							, TMsgDisp.OPE_UPDATE				// オペレーション
							, "復活に失敗しました。"				// 表示するメッセージ
							, status							// ステータス
							, this._scmEpCnectAcs				// エラーが発生したオブジェクト
							, MessageBoxButtons.OK				// 表示するボタン
							, MessageBoxDefaultButton.Button1);	// 初期表示ボタン
						break;
					}
				}
			}
			else
			{
				//連結企業拠点
				ScmEpScCnt scmEpScCntkey = new ScmEpScCnt();

				MakeScmEpScCntKeyFormRowIndex(ref scmEpScCntkey, this._detailsDataIndex, this._targetTableName);
				ScmEpScCnt scmEpScCnt = this._scmEpScCntTable[MakeScmEpScCntTableContainsKey(scmEpScCntkey)];

				bool msgDiv;
				string errMsg;
				ScmEpScCnt[] scmEpScCnts = new ScmEpScCnt[1] { scmEpScCnt };
				int status = this._scmEpScCntAcs.RevivalScmEpScCnt(ref scmEpScCnts, out msgDiv, out errMsg);
				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						ScmEpScCntToDataSet(scmEpScCnts[0], this._detailsDataIndex, true);
						result = true;
						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
					case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
					{
						ExclusiveTransaction(status);
						break;
					}
					default:
					{
						TMsgDisp.Show(this						// 親ウィンドウフォーム
							, emErrorLevel.ERR_LEVEL_STOPDISP	// エラーレベル
							, ctASSEMBLY_ID						// アセンブリIDまたはクラスID
							, ctASSEMBLY_NAME					// プログラム名称
							, "RevivalProc"						// 処理名称
							, TMsgDisp.OPE_UPDATE				// オペレーション
							, "復活に失敗しました。"				// 表示するメッセージ
							, status							// ステータス
							, this._scmEpCnectAcs				// エラーが発生したオブジェクト
							, MessageBoxButtons.OK				// 表示するボタン
							, MessageBoxDefaultButton.Button1);	// 初期表示ボタン
						break;
					}
				}

			}

			return result;
		}

		#endregion

		// ===================================================================================== //
		//  完全削除処理
		// ===================================================================================== //
		#region 完全削除処理

		/// **********************************************************************
		/// Module name		:	 DeleteProc
		/// <summary>
		/// 完全削除処理処理
		/// </summary>
		/// <returns>完全削除結果（true:OK／false:NG）</returns>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>Note     　 : 連結企業、連結企業拠点の完全削除を行います。</br>
		/// <br>Programmer	: 22024  寺坂　誉志</br>
		/// <br>Date		: 2009.07.15</br>
		/// </remarks>
		/// **********************************************************************
		private bool DeleteProc()
		{
			bool result = false;

			// 完全削除確認
			string message = "データを削除します。\r\nよろしいですか？";
			DialogResult dlgRet = TMsgDisp.Show(
				this,								// 親ウィンドウフォーム
				emErrorLevel.ERR_LEVEL_QUESTION,	// エラーレベル
				ctASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
				message.ToString(),					// 表示するメッセージ 
				0,									// ステータス値
				MessageBoxButtons.YesNo);			// 表示するボタン
			if (dlgRet != DialogResult.Yes)
				return false;

			if (this._targetTableName == ct_SCMEPCNECT_TABLE)
			{
				string keyCode = this._bind_DataSet.Tables[this._targetTableName].Rows[this._mainDataIndex][ct_A_CNECTORGEPCD].ToString();
				ScmEpCnect scmEpCnect = this._scmEpCnectTable[keyCode];

				bool msgDiv;
				string errMsg;
				int status = _scmEpCnectAcs.DeleteScmEpCnect(scmEpCnect, out msgDiv, out errMsg);
				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						for (int ix = 0; ix != this._bind_DataSet.Tables[ct_SCMEPSCCNT_TABLE].Rows.Count; ix++)
						{
							ScmEpScCnt scmEpScCnt = new ScmEpScCnt();
							MakeScmEpScCntKeyFormRowIndex(ref scmEpScCnt, ix, ct_SCMEPSCCNT_TABLE);
							this._scmEpScCntTable.Remove(MakeScmEpScCntTableContainsKey(scmEpScCnt));
						}
						this._bind_DataSet.Tables[ct_SCMEPSCCNT_TABLE].Rows.Clear();

						this._scmEpCnectTable.Remove(keyCode);
						this._bind_DataSet.Tables[this._targetTableName].Rows.RemoveAt(this._mainDataIndex);

						result = true;
						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
					case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
					{
						ExclusiveTransaction(status);
						break;
					}
					default:
					{
						TMsgDisp.Show(this						// 親ウィンドウフォーム
							, emErrorLevel.ERR_LEVEL_STOPDISP	// エラーレベル
							, ctASSEMBLY_ID						// アセンブリIDまたはクラスID
							, ctASSEMBLY_NAME					// プログラム名称
							, "Delete"							// 処理名称
							, TMsgDisp.OPE_DELETE				// オペレーション
							, "削除に失敗しました。"				// 表示するメッセージ
							, status							// ステータス
							, this._scmEpCnectAcs				// エラーが発生したオブジェクト
							, MessageBoxButtons.OK				// 表示するボタン
							, MessageBoxDefaultButton.Button1);	// 初期表示ボタン
						break;
					}
				}
			}
			else
			{
				ScmEpScCnt scmEpScCnt = new ScmEpScCnt();
				MakeScmEpScCntKeyFormRowIndex(ref scmEpScCnt, this._detailsDataIndex, this._targetTableName);
				string keyCode = MakeScmEpScCntTableContainsKey(scmEpScCnt);
				scmEpScCnt = this._scmEpScCntTable[keyCode];

				bool msgDiv;
				string errMsg;
				int status = _scmEpScCntAcs.DeleteScmEpScCnt(scmEpScCnt, out msgDiv, out errMsg);
				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						this._scmEpScCntTable.Remove(keyCode);
						this._bind_DataSet.Tables[this._targetTableName].Rows.RemoveAt(this._detailsDataIndex);

						result = true;
						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
					case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
					{
						ExclusiveTransaction(status);
						break;
					}
					default:
					{
						TMsgDisp.Show(this						// 親ウィンドウフォーム
							, emErrorLevel.ERR_LEVEL_STOPDISP	// エラーレベル
							, ctASSEMBLY_ID						// アセンブリIDまたはクラスID
							, ctASSEMBLY_NAME					// プログラム名称
							, "Delete"							// 処理名称
							, TMsgDisp.OPE_DELETE				// オペレーション
							, "削除に失敗しました。"				// 表示するメッセージ
							, status							// ステータス
							, this._scmEpCnectAcs				// エラーが発生したオブジェクト
							, MessageBoxButtons.OK				// 表示するボタン
							, MessageBoxDefaultButton.Button1);	// 初期表示ボタン
						break;
					}
				}
			}

			return result;
		}

		#endregion

        // --- Add 2011.07.21 duzg for パスワード入力確認画面追加 --->>>
        /// <summary>
        /// 指定したメッセージをポップアップする
        /// </summary>
        /// <param name="msg">メッセージ</param>
        /// <remarks>
        /// <br>Note        : ポップアップ処理を行います。</br>
        /// <br>Programmer  : duzg</br>
        /// <br>Date        : 2011.07.21</br>
        /// </remarks>
        private void TMsgDispMsg(string msg)
        {
            TMsgDisp.Show(
                this, 								// 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                ctASSEMBLY_ID, 						// アセンブリＩＤまたはクラスＩＤ
                msg, 							// 表示するメッセージ
                0, 									// ステータス値
                MessageBoxButtons.OK);				// 表示するボタン
        }

        // ADD 2013/11/28 商品保証課Redmine#711対応 --------------------------------------->>>>>
        /// <summary>
        ///  アローキーコントロール処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            // 優先表示システム
            if (e.NextCtrl == this.uOptionSet_PrDispSystem)
            {
                if (e.PrevCtrl == this.Close_Button || e.PrevCtrl == this.Save_Button)
                    this.uOptionSet_PrDispSystem.FocusedIndex = 1;
                else
                    this.uOptionSet_PrDispSystem.FocusedIndex = 0;
            }
            // 優先表示システム
            if (e.PrevCtrl == this.uOptionSet_PrDispSystem)
            {
                if (e.Key == Keys.Up)
                {
                    e.NextCtrl = this.SCM_ultraCheckEditor;
                }
                else if (e.Key == Keys.Right)
                {
                    e.NextCtrl = this.Save_Button;
                }
            }
            // 保存ボタン
            if (e.PrevCtrl == this.Save_Button)
            {
                if (e.Key == Keys.Left)
                {

                    e.NextCtrl = this.uOptionSet_PrDispSystem;
                }
                else if (e.Key == Keys.Up)
                {
                    this.uOptionSet_PrDispSystem.FocusedIndex = 1;
                }
            }
        }

        /// <summary>
        ///  通信方式チェックボックス変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SCM_ultraCheckEditor_CheckedChanged(object sender, EventArgs e)
        {
            if ((this.SCM_ultraCheckEditor.Checked && this.RC_ultraCheckEditor.Checked) ||
                (this.PCC_UOC_ultraCheckEditor.Checked && this.RC_ultraCheckEditor.Checked)
            )
            {
                // 優先表示システムはPMオプション･RCオプションがチェック済の時のみ表示
                this.uOptionSet_PrDispSystem.Visible = true;
                this.ultraLabel_DisplayOrder.Visible = true;
                this.ultraLabel_New.Visible = true;
                this.ultraLabel_Rc.Visible = true;

                switch (Mode_Label.Text)
                {
                    case INSERT_MODE:
                    case UPDATE_MODE:
                        this.uOptionSet_PrDispSystem.Enabled = true;
                        break;
                    default:
                        this.uOptionSet_PrDispSystem.Enabled = false;
                        break;
                }

            }
            else
            {
                this.uOptionSet_PrDispSystem.Visible = false;
                this.uOptionSet_PrDispSystem.Enabled = false;
                this.ultraLabel_DisplayOrder.Visible = false;
                this.ultraLabel_New.Visible = false;
                this.ultraLabel_Rc.Visible = false;
            }
        }
        // ADD 2013/11/28 商品保証課Redmine#711対応 ---------------------------------------<<<<<

        // 2014.09.11 ins by Ryo. -start- > > > > >
        private void AddNewUser_ultraButton_Click(object sender, EventArgs e)
        {
            string userCode = string.Empty;
            string userName = string.Empty;

            SFCMN02561UB sfcmn02561UB = new SFCMN02561UB();

            sfcmn02561UB.ShowDialog(this, this.OtherEpCd_tEdit.Text, this.OtherEpNm_tEdit.Text, this.OriginalEpCd_tEdit.Text, ref this._oScmBPCntTable, ref userCode, ref userName);

            if (sfcmn02561UB.DialogResult != DialogResult.OK)
            {
                return;
            }

            Infragistics.Win.ValueListItem valueListItem = new Infragistics.Win.ValueListItem();
            valueListItem.DataValue = userCode;
            valueListItem.DisplayText = userCode + "：" + userName;

            this.OtherUserCd_tComboEditor.Items.Add(valueListItem);
            this.OtherUserCd_tComboEditor.Value = userCode;

        }
        // 2014.09.11 ins by Ryo. -e n d- < < < < <

        // --- Add 2011.07.21 duzg for パスワード入力確認画面追加 ---<<<
        // --- DEL 2013/06/14 Y.Wakita ---------->>>>>
        //// ADD 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        //// 優先表示システムのラジオボタンについて
        //// 　ラジオボタンのTextプロパティを使用すると、
        //// 　Enabled=falseにした際に表示色が変わってしまうので、
        //// 　ラベルを追加している
        //private void ultraLabel_New_Click(object sender, EventArgs e)
        //{
        //    this.radioButton_New.PerformClick();
        //}
        //private void ultraLabel_Rc_Click(object sender, EventArgs e)
        //{
        //    this.radioButton_RC.PerformClick();
        //}
        //// ADD 2013/05/24 吉岡 2013/06/18配信 SCM障害№10533 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        // --- DEL 2013/06/14 Y.Wakita ----------<<<<<

		#endregion
	}
}

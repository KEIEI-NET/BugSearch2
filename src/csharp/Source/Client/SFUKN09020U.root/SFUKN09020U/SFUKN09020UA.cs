using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 自社名称設定フォームクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 自社名称の設定を行うクラスです。</br>
	/// <br>Programmer : 23001 秋山　亮介</br>
	/// <br>Date       : 2005.09.09</br>
	/// <br>Update Note: 2005.09.22 23001 秋山　亮介</br>
	/// <br>                        メッセージボックス表示部品の組込み</br>
	/// <br>Update Note: 2005.10.18 23001 秋山　亮介</br>
	/// <br>                        ガイド選択確定時に次の項目へフォーカスを移動するように修正</br>
	/// <br>Update Note: 2005.10.19 23001 秋山　亮介</br>
	/// <br>                        フォーム非表示時にメインフレームをアクティブにするように修正</br>
	/// <br>Update Note: 2005.11.01 23001 秋山　亮介</br>
	/// <br>                        品管障害対応 (管理No.000273-01)</br>
	/// <br>                        排他による保存不可時に存在しない画像をロードしようとしてst=04が出るのを修正</br>
	/// <br>Update Note: 2005.11.04 23001 秋山　亮介</br>
	/// <br>                        品管障害対応 (管理No.000273-02)</br>
	/// <br>                        別端末で画像保存時に、キャッシュの影響で異なる画像が表示されているのを修正</br>
	/// <br>Update Note: 2006.03.14 23010 中村　仁</br>
	/// <br>                        項目の追加を行います</br>
	/// <br>Update Note: 2006.05.19 23010 中村　仁</br>
	/// <br>                        住所ガイドから30文字を超える住所が戻ってきた際に、分割して住所１、住所３に表示させるように修正</br>
    /// <br>Update Note: 2007.05.17 20031 古賀　小百合</br>
    /// <br>                        画像登録機能削除、画像情報コード追加</br>
    /// <br>                        郵便番号検索ボタン(未実装)を非表示に変更</br>
    /// <br>Update Note: 2007.05.27 20031 古賀　小百合</br>
    /// <br>                        住所の「丁目」表示を非表示に変更</br>
    /// <br>Update Note: 2007.07.13 20031 古賀　小百合</br>
    /// <br>                        電話番号タイトルと電話番号表記を変更</br>
    /// <br>Update Note: 2008/06/04 30414 忍　幸史</br>
    /// <br>                        「住所2」削除</br>
    /// </remarks>
	public class SFUKN09020UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
	{
		#region Private Members (Component)
		private System.Data.DataSet Bind_DataSet;
		private System.Windows.Forms.Timer Initial_Timer;
		private Infragistics.Win.Misc.UltraLabel Mode_Label;
		private Infragistics.Win.Misc.UltraButton Delete_Button;
		private Infragistics.Win.Misc.UltraButton Revive_Button;
		private Infragistics.Win.Misc.UltraButton Ok_Button;
		private Infragistics.Win.Misc.UltraButton Cancel_Button;
		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
		private Infragistics.Win.Misc.UltraLabel CompanyNameCd_Title_Label;
		private Infragistics.Win.Misc.UltraLabel CompanyName1_Title_Label;
		private Infragistics.Win.Misc.UltraLabel PostNo_Title_Label;
		private Infragistics.Win.Misc.UltraLabel CompanyName2_Title_Label;
		private Infragistics.Win.Misc.UltraLabel Address_Title_Label;
		private Infragistics.Win.Misc.UltraLabel CompanyTel1Title_Title_Label;
		private Infragistics.Win.Misc.UltraLabel CompanyTel2Title_Title_Label;
		private Infragistics.Win.Misc.UltraLabel CompanyTel3Title_Title_Label;
		private Infragistics.Win.Misc.UltraLabel TransferGuidance_Title_Label;
		private Infragistics.Win.Misc.UltraLabel AccountNoInfo1_Title_Label;
		private Infragistics.Win.Misc.UltraLabel AccountNoInfo2_Title_Label;
		private Infragistics.Win.Misc.UltraLabel AccountNoInfo3_Title_Label;
		private Infragistics.Win.Misc.UltraLabel CompanySetNote_Title_Label;
		private Broadleaf.Library.Windows.Forms.TNedit CompanyNameCd_tNedit;
		private Broadleaf.Library.Windows.Forms.TEdit CompanyName1_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit CompanyName2_tEdit;
		private Infragistics.Win.Misc.UltraLabel ultraLabel17;
		private Broadleaf.Library.Windows.Forms.TEdit PostNoMark_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit PostNo_tEdit;
		private Infragistics.Win.Misc.UltraLabel PostNo_Border_Label;
		private Broadleaf.Library.Windows.Forms.TEdit Address1_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit Address3_tEdit;
        private Broadleaf.Library.Windows.Forms.TEdit Address4_tEdit;
		private Infragistics.Win.Misc.UltraLabel ultraLabel2;
		private Infragistics.Win.Misc.UltraLabel ultraLabel3;
		private Infragistics.Win.Misc.UltraLabel ultraLabel4;
		private Infragistics.Win.Misc.UltraButton AddressGuide_Button;
		private Infragistics.Win.Misc.UltraLabel CompanyPr_Title_Label;
		private Broadleaf.Library.Windows.Forms.TEdit CompanyTelTitle1_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit CompanyTelTitle2_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit CompanyTelTitle3_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit CompanyTelNo1_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit CompanyTelNo2_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit CompanyTelNo3_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit TransferGuidance_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit AccountNoInfo1_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit AccountNoInfo2_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit AccountNoInfo3_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit CompanySetNote1_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit CompanySetNote2_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit CompanyPr_tEdit;
		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
        private Infragistics.Win.Misc.UltraLabel ImageInfoCode_Title_Label;
		private System.Windows.Forms.OpenFileDialog TakeInImage_OpenFileDialog;
		private Broadleaf.Library.Windows.Forms.TEdit CompanyUrl_tEdit;
		private Infragistics.Win.Misc.UltraLabel CompanyUrl_Title_Label;
		private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		private Infragistics.Win.Misc.UltraLabel ultraLabel6;
		private Broadleaf.Library.Windows.Forms.TEdit CompanyPr2_tEdit;
		private Infragistics.Win.Misc.UltraLabel ImageCommentForPrt1_Title_Label;
		private Broadleaf.Library.Windows.Forms.TEdit ImageCommentForPrt1_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit ImageCommentForPrt2_tEdit;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private TComboEditor ImageInfoCode_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel CompanyTel1_Title_Label;
        private Infragistics.Win.Misc.UltraLabel CompanyTel2_Title_Label;
        private Infragistics.Win.Misc.UltraLabel CompanyTel3_Title_Label;
        private Infragistics.Win.Misc.UltraButton Renewal_Button;
		private System.ComponentModel.IContainer components;
		#endregion

		#region Constructor
		/// <summary>
		/// 自社名称設定フォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 自社名称設定フォームクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		public SFUKN09020UA()
		{
			InitializeComponent();

			// データセット列情報構築処理
			DataSetColumnConstruction();

			// プロパティ初期値
			this._canClose							= false;	// 閉じる機能（デフォルトtrue固定）
			this._canDelete							= true;		// 削除機能
			this._canLogicalDeleteDataExtraction	= true;		// 論理削除データ表示機能
			this._canNew							= true;		// 新規作成機能
			this._canPrint							= false;	// 印刷機能
			this._canSpecificationSearch			= false;	// 件数指定検索機能
			this._defaultAutoFillToColumn			= false;	// 列サイズ自動調整機能

            # region 2007.05.17  S.Koga  DEL
            // 画像管理マスタ関連
            //this._imageGroup						= null;					// 画像グループクラス
            //this._imgManage							= null;					// 画像管理クラス
            # endregion
            // 2007.05.17  S.Koga  add ----------------------------------------
            this._imageInfoAcs = new ImageInfoAcs();
            this.ImageInfoDS = new DataSet();
            // ----------------------------------------------------------------

            // 自社画像転送クラスインスタンス作成
            //this._SFUKN09020UB                      = new SFUKN09020UB();
			// タイムアウトを10分(600秒)に設定
            //this._SFUKN09020UB.TimeOut              = 600;
// 2006.08.18 AKIYAMA DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//			this._imageImgAcs						= new ImageImgAcs();	// 画像管理マスタアクセスクラス
//			// 画像ファイル送受信完了イベント
//			this._imageImgAcs.FileReceived			+= new EventHandler( this.ImageImgAcs_FileReceived );
//			this._imageImgAcs.FileSended			+= new EventHandler( this.ImageImgAcs_FileSended );
// 2006.08.18 AKIYAMA DEL <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

			// 企業コード取得
			this._enterpriseCode					= LoginInfoAcquisition.EnterpriseCode;	// 企業コード

			// 初期化
			this._dataIndex							= -1;
			this._companyNmAcs						= new CompanyNmAcs();
			this._logicalDeleteMode					= 0;
			this._companyNmTable					= new Hashtable();
			this._changeFlg							= false;

			this._changeTakeInImage					= false;
// 2006.08.18 AKIYAMA DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//			this._imageTransferring					= false;
//
//			this._waitWindow						= null;
// 2006.08.18 AKIYAMA DEL <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

			// _GridIndexバッファ（メインフレーム最小化対応）
			this._indexBuf							= -2;
		}
		#endregion

		#region Private Members
		private CompanyNmAcs	_companyNmAcs;						// 自社名称アクセスクラス
		private string			_enterpriseCode;					// 企業コード
		private int				_logicalDeleteMode;					// モード
		private Hashtable		_companyNmTable;					// 自社名称テーブル
		private bool			_changeFlg = false;					// コード変更フラグ

		// 画像管理マスタ関連
// 2006.08.18 AKIYAMA DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//		private ImageImgAcs		_imageImgAcs;						// 画像管理マスタアクセスクラス
        // 2006.08.18 AKIYAMA DEL <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
        # region 2007.05.17  S.Koga  DEL
        //private ImageGroup		_imageGroup;						// 画像グループオブジェクト
        //private ImgManage		_imgManage;							// 画像管理オブジェクト
        # endregion
        // 2007.05.17  S.Koga  add --------------------------------------------
        // 画像情報アクセスクラス
        private ImageInfoAcs _imageInfoAcs = null;
        // 画像情報取得用DataSet
        private DataSet ImageInfoDS = null;
        // --------------------------------------------------------------------

        private const int SYSTEMDIV_CD			= 0;			// システム区分
		private const int IMAGEUSESYSTEM_CODE	= 10;			// 画像使用システム区分

		private bool			_changeTakeInImage;					// 取込画像変更フラグ
// 2006.08.18 AKIYAMA ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
		// 自社画像転送クラス
        //private SFUKN09020UB    _SFUKN09020UB   = null;
// 2006.08.18 AKIYAMA ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
// 2006.08.18 AKIYAMA DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//		private bool			_imageTransferring;					// 画像転送中フラグ
//
//		private SFUKN09020UB	_waitWindow = null;					// お待ちください窓
//		private readonly object _syncObject = new object();			//ロックに使用するオブジェクト
// 2006.08.18 AKIYAMA DEL <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

		// 比較用clone
		private CompanyNm		_companyNmClone;

		// _GridIndexバッファ（メインフレーム最小化対応）
		private int				_indexBuf;

		// プロパティ用
		private bool	_canClose;
		private bool	_canDelete;
		private bool	_canLogicalDeleteDataExtraction;
		private bool	_canNew;
		private bool	_canPrint;
		private bool	_canSpecificationSearch;
		private int		_dataIndex;
		private bool	_defaultAutoFillToColumn;

        // 2009.03.23 30413 犬飼 新規モードからモード変更対応 >>>>>>START
        // モードフラグ(true：コード、false：コード以外)
        private bool _modeFlg = false;
        // 2009.03.23 30413 犬飼 新規モードからモード変更対応 <<<<<<END

		// FrameのView用Grid列のKEY情報（ヘッダのタイトル部となります。）
		private const string DELETE_DATE				= "削除日";
		private const string COMPANYNAMECD_TITLE		= "コード";
		private const string COMPANYNAME_TITLE			= "自社名称";
		private const string POSTNO_TITLE				= "郵便番号";
		private const string ADDRESS_TITLE				= "住所";
		private const string COMPANYTELNO1_TITLE		= "電話番号１";
		private const string COMPANYTELNO2_TITLE		= "電話番号２";
		private const string COMPANYTELNO3_TITLE		= "電話番号３";
		private const string TRANSFERGUIDANCE_TITLE		= "銀行振込案内文";
		private const string ACCOUNTNOINFO1_TITLE		= "銀行口座１";
		private const string ACCOUNTNOINFO2_TITLE		= "銀行口座２";
		private const string ACCOUNTNOINFO3_TITLE		= "銀行口座３";
		private const string COMPANYSETNOTE1_TITLE		= "自社設定摘要１";
		private const string COMPANYSETNOTE2_TITLE		= "自社設定摘要２";
		private const string COMPANYPR_TITLE			= "自社ＰＲ文１";
		private const string COMPANYPR2_TITLE			= "自社ＰＲ文２";
        // 2007.05.17  S.Koga  ADD --------------------------------------------
        private const string IMAGEINFODIV_TITLE         = "画像情報区分";
        private const string IMAGEINFOCODE_TITLE        = "画像情報コード";
        // --------------------------------------------------------------------
        private const string COMPANYURL_TITLE = "自社ＵＲＬ";
		private const string IMAGECOMMENTFORPRT1_TITLE	= "画像印字用コメント１";
		private const string IMAGECOMMENTFORPRT2_TITLE	= "画像印字用コメント２";
		private const string GUID_TITLE					= "GUID";
		private const string COMPANYNM_TABLE			= "COMPANYNM";				// テーブル名

        // 2007.05.17  S.Koga  ADD --------------------------------------------
        // 画像情報区分(10:自社画像 固定)
        private const int IMAGEINFODIV_DATA = 10;
        // --------------------------------------------------------------------
	
		
		// 編集モード
		private const string INSERT_MODE				= "新規モード";
		private const string UPDATE_MODE				= "更新モード";
		private const string DELETE_MODE				= "削除モード";
		#endregion

		#region Dispose
		/// <summary>
		/// 使用されているリソースに後処理を実行します。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		#endregion

		#region Windows フォーム デザイナで生成されたコード 
		/// <summary>
		/// デザイナ サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディタで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("住所ガイド", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance49 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance50 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance51 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance52 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance53 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance54 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance55 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance56 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance57 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance58 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance60 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance61 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance80 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance78 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance79 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance77 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance74 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance75 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance76 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance73 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance71 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance72 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance69 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance70 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance68 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance65 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance66 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance67 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance62 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance63 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance64 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SFUKN09020UA));
            this.Bind_DataSet = new System.Data.DataSet();
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.AddressGuide_Button = new Infragistics.Win.Misc.UltraButton();
            this.Delete_Button = new Infragistics.Win.Misc.UltraButton();
            this.Revive_Button = new Infragistics.Win.Misc.UltraButton();
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.CompanyNameCd_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CompanyName1_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.PostNo_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CompanyName2_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Address_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CompanyTel1Title_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CompanyTel2Title_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CompanyTel3Title_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.TransferGuidance_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.AccountNoInfo1_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.AccountNoInfo2_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.AccountNoInfo3_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CompanySetNote_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CompanyPr_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CompanyNameCd_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.CompanyName1_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.CompanyName2_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel17 = new Infragistics.Win.Misc.UltraLabel();
            this.PostNoMark_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.PostNo_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.PostNo_Border_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Address1_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.Address3_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.Address4_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.CompanyTelTitle1_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.CompanyTelTitle2_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.CompanyTelTitle3_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.CompanyTelNo1_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.CompanyTelNo2_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.CompanyTelNo3_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.TransferGuidance_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.AccountNoInfo1_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.AccountNoInfo2_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.AccountNoInfo3_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.CompanySetNote1_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.CompanySetNote2_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.CompanyPr_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.ImageInfoCode_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.TakeInImage_OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.CompanyUrl_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.CompanyUrl_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CompanyPr2_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.ImageCommentForPrt1_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ImageCommentForPrt1_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ImageCommentForPrt2_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.ImageInfoCode_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.CompanyTel1_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CompanyTel2_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.CompanyTel3_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Renewal_Button = new Infragistics.Win.Misc.UltraButton();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyNameCd_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyName1_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyName2_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PostNoMark_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PostNo_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Address1_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Address3_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Address4_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyTelTitle1_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyTelTitle2_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyTelTitle3_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyTelNo1_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyTelNo2_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyTelNo3_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TransferGuidance_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AccountNoInfo1_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AccountNoInfo2_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AccountNoInfo3_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanySetNote1_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanySetNote2_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyPr_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyUrl_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyPr2_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageCommentForPrt1_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageCommentForPrt2_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageInfoCode_tComboEditor)).BeginInit();
            this.SuspendLayout();
            // 
            // Bind_DataSet
            // 
            this.Bind_DataSet.DataSetName = "NewDataSet";
            this.Bind_DataSet.Locale = new System.Globalization.CultureInfo("ja-JP");
            // 
            // Initial_Timer
            // 
            this.Initial_Timer.Interval = 1;
            this.Initial_Timer.Tick += new System.EventHandler(this.Initial_Timer_Tick);
            // 
            // Mode_Label
            // 
            appearance1.ForeColor = System.Drawing.Color.White;
            appearance1.TextHAlignAsString = "Center";
            appearance1.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance1;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.Location = new System.Drawing.Point(579, 5);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(100, 23);
            this.Mode_Label.TabIndex = 58;
            this.Mode_Label.Text = "更新モード";
            // 
            // AddressGuide_Button
            // 
            this.AddressGuide_Button.Location = new System.Drawing.Point(301, 148);
            this.AddressGuide_Button.Name = "AddressGuide_Button";
            this.AddressGuide_Button.Size = new System.Drawing.Size(25, 24);
            this.AddressGuide_Button.TabIndex = 7;
            this.AddressGuide_Button.Text = "?";
            ultraToolTipInfo1.ToolTipText = "住所ガイド";
            this.ultraToolTipManager1.SetUltraToolTip(this.AddressGuide_Button, ultraToolTipInfo1);
            this.AddressGuide_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.AddressGuide_Button.Visible = false;
            // 
            // Delete_Button
            // 
            this.Delete_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Delete_Button.Location = new System.Drawing.Point(175, 626);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(125, 34);
            this.Delete_Button.TabIndex = 28;
            this.Delete_Button.Text = "完全削除(&D)";
            this.Delete_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // Revive_Button
            // 
            this.Revive_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Revive_Button.Location = new System.Drawing.Point(300, 626);
            this.Revive_Button.Name = "Revive_Button";
            this.Revive_Button.Size = new System.Drawing.Size(125, 34);
            this.Revive_Button.TabIndex = 29;
            this.Revive_Button.Text = "復活(&R)";
            this.Revive_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Revive_Button.Click += new System.EventHandler(this.Revive_Button_Click);
            // 
            // Ok_Button
            // 
            this.Ok_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Ok_Button.Location = new System.Drawing.Point(425, 626);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 30;
            this.Ok_Button.Text = "保存(&S)";
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(550, 626);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 31;
            this.Cancel_Button.Text = "閉じる(&X)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 669);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(684, 23);
            this.ultraStatusBar1.TabIndex = 59;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // CompanyNameCd_Title_Label
            // 
            appearance2.TextVAlignAsString = "Middle";
            this.CompanyNameCd_Title_Label.Appearance = appearance2;
            this.CompanyNameCd_Title_Label.Location = new System.Drawing.Point(20, 8);
            this.CompanyNameCd_Title_Label.Name = "CompanyNameCd_Title_Label";
            this.CompanyNameCd_Title_Label.Size = new System.Drawing.Size(125, 23);
            this.CompanyNameCd_Title_Label.TabIndex = 34;
            this.CompanyNameCd_Title_Label.Text = "自社名称コード";
            // 
            // CompanyName1_Title_Label
            // 
            appearance3.TextVAlignAsString = "Middle";
            this.CompanyName1_Title_Label.Appearance = appearance3;
            this.CompanyName1_Title_Label.Location = new System.Drawing.Point(20, 60);
            this.CompanyName1_Title_Label.Name = "CompanyName1_Title_Label";
            this.CompanyName1_Title_Label.Size = new System.Drawing.Size(125, 23);
            this.CompanyName1_Title_Label.TabIndex = 36;
            this.CompanyName1_Title_Label.Text = "自社名称１";
            // 
            // PostNo_Title_Label
            // 
            appearance4.TextVAlignAsString = "Middle";
            this.PostNo_Title_Label.Appearance = appearance4;
            this.PostNo_Title_Label.Location = new System.Drawing.Point(20, 148);
            this.PostNo_Title_Label.Name = "PostNo_Title_Label";
            this.PostNo_Title_Label.Size = new System.Drawing.Size(125, 23);
            this.PostNo_Title_Label.TabIndex = 40;
            this.PostNo_Title_Label.Text = "郵便番号";
            // 
            // CompanyName2_Title_Label
            // 
            appearance5.TextVAlignAsString = "Middle";
            this.CompanyName2_Title_Label.Appearance = appearance5;
            this.CompanyName2_Title_Label.Location = new System.Drawing.Point(20, 86);
            this.CompanyName2_Title_Label.Name = "CompanyName2_Title_Label";
            this.CompanyName2_Title_Label.Size = new System.Drawing.Size(125, 23);
            this.CompanyName2_Title_Label.TabIndex = 37;
            this.CompanyName2_Title_Label.Text = "自社名称２";
            // 
            // Address_Title_Label
            // 
            appearance6.TextVAlignAsString = "Middle";
            this.Address_Title_Label.Appearance = appearance6;
            this.Address_Title_Label.Location = new System.Drawing.Point(20, 174);
            this.Address_Title_Label.Name = "Address_Title_Label";
            this.Address_Title_Label.Size = new System.Drawing.Size(125, 23);
            this.Address_Title_Label.TabIndex = 41;
            this.Address_Title_Label.Text = "住所";
            // 
            // CompanyTel1Title_Title_Label
            // 
            appearance7.TextVAlignAsString = "Middle";
            this.CompanyTel1Title_Title_Label.Appearance = appearance7;
            this.CompanyTel1Title_Title_Label.Location = new System.Drawing.Point(20, 252);
            this.CompanyTel1Title_Title_Label.Name = "CompanyTel1Title_Title_Label";
            this.CompanyTel1Title_Title_Label.Size = new System.Drawing.Size(145, 23);
            this.CompanyTel1Title_Title_Label.TabIndex = 42;
            this.CompanyTel1Title_Title_Label.Text = "電話番号１タイトル";
            // 
            // CompanyTel2Title_Title_Label
            // 
            appearance8.TextVAlignAsString = "Middle";
            this.CompanyTel2Title_Title_Label.Appearance = appearance8;
            this.CompanyTel2Title_Title_Label.Location = new System.Drawing.Point(20, 278);
            this.CompanyTel2Title_Title_Label.Name = "CompanyTel2Title_Title_Label";
            this.CompanyTel2Title_Title_Label.Size = new System.Drawing.Size(145, 23);
            this.CompanyTel2Title_Title_Label.TabIndex = 43;
            this.CompanyTel2Title_Title_Label.Text = "電話番号２タイトル";
            // 
            // CompanyTel3Title_Title_Label
            // 
            appearance9.TextVAlignAsString = "Middle";
            this.CompanyTel3Title_Title_Label.Appearance = appearance9;
            this.CompanyTel3Title_Title_Label.Location = new System.Drawing.Point(20, 304);
            this.CompanyTel3Title_Title_Label.Name = "CompanyTel3Title_Title_Label";
            this.CompanyTel3Title_Title_Label.Size = new System.Drawing.Size(145, 23);
            this.CompanyTel3Title_Title_Label.TabIndex = 44;
            this.CompanyTel3Title_Title_Label.Text = "電話番号３タイトル";
            // 
            // TransferGuidance_Title_Label
            // 
            appearance10.TextVAlignAsString = "Middle";
            this.TransferGuidance_Title_Label.Appearance = appearance10;
            this.TransferGuidance_Title_Label.Location = new System.Drawing.Point(20, 392);
            this.TransferGuidance_Title_Label.Name = "TransferGuidance_Title_Label";
            this.TransferGuidance_Title_Label.Size = new System.Drawing.Size(125, 23);
            this.TransferGuidance_Title_Label.TabIndex = 46;
            this.TransferGuidance_Title_Label.Text = "銀行振込案内文";
            // 
            // AccountNoInfo1_Title_Label
            // 
            appearance11.TextVAlignAsString = "Middle";
            this.AccountNoInfo1_Title_Label.Appearance = appearance11;
            this.AccountNoInfo1_Title_Label.Location = new System.Drawing.Point(20, 418);
            this.AccountNoInfo1_Title_Label.Name = "AccountNoInfo1_Title_Label";
            this.AccountNoInfo1_Title_Label.Size = new System.Drawing.Size(125, 23);
            this.AccountNoInfo1_Title_Label.TabIndex = 47;
            this.AccountNoInfo1_Title_Label.Text = "銀行口座１";
            // 
            // AccountNoInfo2_Title_Label
            // 
            appearance12.TextVAlignAsString = "Middle";
            this.AccountNoInfo2_Title_Label.Appearance = appearance12;
            this.AccountNoInfo2_Title_Label.Location = new System.Drawing.Point(20, 444);
            this.AccountNoInfo2_Title_Label.Name = "AccountNoInfo2_Title_Label";
            this.AccountNoInfo2_Title_Label.Size = new System.Drawing.Size(125, 23);
            this.AccountNoInfo2_Title_Label.TabIndex = 48;
            this.AccountNoInfo2_Title_Label.Text = "銀行口座２";
            // 
            // AccountNoInfo3_Title_Label
            // 
            appearance13.TextVAlignAsString = "Middle";
            this.AccountNoInfo3_Title_Label.Appearance = appearance13;
            this.AccountNoInfo3_Title_Label.Location = new System.Drawing.Point(20, 470);
            this.AccountNoInfo3_Title_Label.Name = "AccountNoInfo3_Title_Label";
            this.AccountNoInfo3_Title_Label.Size = new System.Drawing.Size(125, 23);
            this.AccountNoInfo3_Title_Label.TabIndex = 49;
            this.AccountNoInfo3_Title_Label.Text = "銀行口座３";
            // 
            // CompanySetNote_Title_Label
            // 
            appearance14.TextVAlignAsString = "Middle";
            this.CompanySetNote_Title_Label.Appearance = appearance14;
            this.CompanySetNote_Title_Label.Location = new System.Drawing.Point(20, 330);
            this.CompanySetNote_Title_Label.Name = "CompanySetNote_Title_Label";
            this.CompanySetNote_Title_Label.Size = new System.Drawing.Size(125, 23);
            this.CompanySetNote_Title_Label.TabIndex = 50;
            this.CompanySetNote_Title_Label.Text = "摘要";
            // 
            // CompanyPr_Title_Label
            // 
            appearance15.TextVAlignAsString = "Middle";
            this.CompanyPr_Title_Label.Appearance = appearance15;
            this.CompanyPr_Title_Label.Location = new System.Drawing.Point(20, 34);
            this.CompanyPr_Title_Label.Name = "CompanyPr_Title_Label";
            this.CompanyPr_Title_Label.Size = new System.Drawing.Size(125, 23);
            this.CompanyPr_Title_Label.TabIndex = 35;
            this.CompanyPr_Title_Label.Text = "自社ＰＲ文１";
            // 
            // CompanyNameCd_tNedit
            // 
            appearance16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance16.ForeColor = System.Drawing.Color.Black;
            appearance16.TextHAlignAsString = "Right";
            appearance16.TextVAlignAsString = "Middle";
            this.CompanyNameCd_tNedit.ActiveAppearance = appearance16;
            appearance17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance17.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance17.ForeColor = System.Drawing.Color.Black;
            appearance17.ForeColorDisabled = System.Drawing.Color.Black;
            appearance17.TextHAlignAsString = "Right";
            appearance17.TextVAlignAsString = "Middle";
            this.CompanyNameCd_tNedit.Appearance = appearance17;
            this.CompanyNameCd_tNedit.AutoSelect = true;
            this.CompanyNameCd_tNedit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.CompanyNameCd_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.CompanyNameCd_tNedit.DataText = "";
            this.CompanyNameCd_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CompanyNameCd_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.CompanyNameCd_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.CompanyNameCd_tNedit.Location = new System.Drawing.Point(171, 8);
            this.CompanyNameCd_tNedit.MaxLength = 4;
            this.CompanyNameCd_tNedit.Name = "CompanyNameCd_tNedit";
            this.CompanyNameCd_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.CompanyNameCd_tNedit.Size = new System.Drawing.Size(44, 24);
            this.CompanyNameCd_tNedit.TabIndex = 0;
            // 
            // CompanyName1_tEdit
            // 
            appearance18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance18.ForeColor = System.Drawing.Color.Black;
            appearance18.TextVAlignAsString = "Middle";
            this.CompanyName1_tEdit.ActiveAppearance = appearance18;
            appearance19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance19.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance19.ForeColor = System.Drawing.Color.Black;
            appearance19.ForeColorDisabled = System.Drawing.Color.Black;
            appearance19.TextVAlignAsString = "Middle";
            this.CompanyName1_tEdit.Appearance = appearance19;
            this.CompanyName1_tEdit.AutoSelect = true;
            this.CompanyName1_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.CompanyName1_tEdit.DataText = "";
            this.CompanyName1_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CompanyName1_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.CompanyName1_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.CompanyName1_tEdit.Location = new System.Drawing.Point(171, 60);
            this.CompanyName1_tEdit.MaxLength = 20;
            this.CompanyName1_tEdit.Name = "CompanyName1_tEdit";
            this.CompanyName1_tEdit.Size = new System.Drawing.Size(337, 24);
            this.CompanyName1_tEdit.TabIndex = 2;
            // 
            // CompanyName2_tEdit
            // 
            appearance20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance20.ForeColor = System.Drawing.Color.Black;
            appearance20.TextVAlignAsString = "Middle";
            this.CompanyName2_tEdit.ActiveAppearance = appearance20;
            appearance21.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance21.ForeColor = System.Drawing.Color.Black;
            appearance21.ForeColorDisabled = System.Drawing.Color.Black;
            appearance21.TextVAlignAsString = "Middle";
            this.CompanyName2_tEdit.Appearance = appearance21;
            this.CompanyName2_tEdit.AutoSelect = true;
            this.CompanyName2_tEdit.DataText = "";
            this.CompanyName2_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CompanyName2_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.CompanyName2_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.CompanyName2_tEdit.Location = new System.Drawing.Point(171, 86);
            this.CompanyName2_tEdit.MaxLength = 20;
            this.CompanyName2_tEdit.Name = "CompanyName2_tEdit";
            this.CompanyName2_tEdit.Size = new System.Drawing.Size(337, 24);
            this.CompanyName2_tEdit.TabIndex = 3;
            // 
            // ultraLabel17
            // 
            this.ultraLabel17.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel17.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.ultraLabel17.Location = new System.Drawing.Point(10, 141);
            this.ultraLabel17.Name = "ultraLabel17";
            this.ultraLabel17.Size = new System.Drawing.Size(665, 3);
            this.ultraLabel17.TabIndex = 39;
            // 
            // PostNoMark_tEdit
            // 
            this.PostNoMark_tEdit.ActiveAppearance = appearance22;
            appearance23.BackColor = System.Drawing.Color.White;
            appearance23.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance23.ForeColor = System.Drawing.Color.Black;
            appearance23.ForeColorDisabled = System.Drawing.Color.Black;
            appearance23.TextVAlignAsString = "Middle";
            this.PostNoMark_tEdit.Appearance = appearance23;
            this.PostNoMark_tEdit.AutoSelect = true;
            this.PostNoMark_tEdit.BackColor = System.Drawing.Color.White;
            this.PostNoMark_tEdit.DataText = "〒";
            this.PostNoMark_tEdit.Enabled = false;
            this.PostNoMark_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.PostNoMark_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.PostNoMark_tEdit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.PostNoMark_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.PostNoMark_tEdit.Location = new System.Drawing.Point(171, 148);
            this.PostNoMark_tEdit.MaxLength = 12;
            this.PostNoMark_tEdit.Name = "PostNoMark_tEdit";
            this.PostNoMark_tEdit.Size = new System.Drawing.Size(37, 24);
            this.PostNoMark_tEdit.TabIndex = 5;
            this.PostNoMark_tEdit.TabStop = false;
            this.PostNoMark_tEdit.Text = "〒";
            // 
            // PostNo_tEdit
            // 
            appearance24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance24.ForeColor = System.Drawing.Color.Black;
            appearance24.TextVAlignAsString = "Middle";
            this.PostNo_tEdit.ActiveAppearance = appearance24;
            appearance25.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance25.ForeColor = System.Drawing.Color.Black;
            appearance25.ForeColorDisabled = System.Drawing.Color.Black;
            appearance25.TextVAlignAsString = "Middle";
            this.PostNo_tEdit.Appearance = appearance25;
            this.PostNo_tEdit.AutoSelect = true;
            this.PostNo_tEdit.DataText = "";
            this.PostNo_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.PostNo_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 10, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
            this.PostNo_tEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.PostNo_tEdit.Location = new System.Drawing.Point(206, 148);
            this.PostNo_tEdit.MaxLength = 10;
            this.PostNo_tEdit.Name = "PostNo_tEdit";
            this.PostNo_tEdit.Size = new System.Drawing.Size(92, 24);
            this.PostNo_tEdit.TabIndex = 5;
            this.PostNo_tEdit.ValueChanged += new System.EventHandler(this.PostNo_tEdit_ValueChanged);
            this.PostNo_tEdit.Leave += new System.EventHandler(this.PostNo_tEdit_Leave);
            this.PostNo_tEdit.Enter += new System.EventHandler(this.PostNo_tEdit_Enter);
            this.PostNo_tEdit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PostNo_tEdit_KeyDown);
            // 
            // PostNo_Border_Label
            // 
            appearance26.BackColor = System.Drawing.Color.White;
            appearance26.BackColorDisabled = System.Drawing.SystemColors.Control;
            this.PostNo_Border_Label.Appearance = appearance26;
            this.PostNo_Border_Label.Location = new System.Drawing.Point(206, 149);
            this.PostNo_Border_Label.Name = "PostNo_Border_Label";
            this.PostNo_Border_Label.Size = new System.Drawing.Size(3, 22);
            this.PostNo_Border_Label.TabIndex = 6;
            // 
            // Address1_tEdit
            // 
            appearance27.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance27.ForeColor = System.Drawing.Color.Black;
            appearance27.TextVAlignAsString = "Middle";
            this.Address1_tEdit.ActiveAppearance = appearance27;
            appearance28.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance28.ForeColor = System.Drawing.Color.Black;
            appearance28.ForeColorDisabled = System.Drawing.Color.Black;
            appearance28.TextVAlignAsString = "Middle";
            this.Address1_tEdit.Appearance = appearance28;
            this.Address1_tEdit.AutoSelect = true;
            this.Address1_tEdit.DataText = "";
            this.Address1_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.Address1_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.Address1_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.Address1_tEdit.Location = new System.Drawing.Point(171, 174);
            this.Address1_tEdit.MaxLength = 30;
            this.Address1_tEdit.Name = "Address1_tEdit";
            this.Address1_tEdit.Size = new System.Drawing.Size(496, 24);
            this.Address1_tEdit.TabIndex = 8;
            // 
            // Address3_tEdit
            // 
            appearance29.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance29.ForeColor = System.Drawing.Color.Black;
            appearance29.TextVAlignAsString = "Middle";
            this.Address3_tEdit.ActiveAppearance = appearance29;
            appearance30.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance30.ForeColor = System.Drawing.Color.Black;
            appearance30.ForeColorDisabled = System.Drawing.Color.Black;
            appearance30.TextVAlignAsString = "Middle";
            this.Address3_tEdit.Appearance = appearance30;
            this.Address3_tEdit.AutoSelect = true;
            this.Address3_tEdit.DataText = "";
            this.Address3_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.Address3_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 22, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.Address3_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.Address3_tEdit.Location = new System.Drawing.Point(171, 200);
            this.Address3_tEdit.MaxLength = 22;
            this.Address3_tEdit.Name = "Address3_tEdit";
            this.Address3_tEdit.Size = new System.Drawing.Size(469, 24);
            this.Address3_tEdit.TabIndex = 10;
            // 
            // Address4_tEdit
            // 
            appearance31.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance31.ForeColor = System.Drawing.Color.Black;
            appearance31.TextVAlignAsString = "Middle";
            this.Address4_tEdit.ActiveAppearance = appearance31;
            appearance32.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance32.ForeColor = System.Drawing.Color.Black;
            appearance32.ForeColorDisabled = System.Drawing.Color.Black;
            appearance32.TextVAlignAsString = "Middle";
            this.Address4_tEdit.Appearance = appearance32;
            this.Address4_tEdit.AutoSelect = true;
            this.Address4_tEdit.DataText = "";
            this.Address4_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.Address4_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.Address4_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.Address4_tEdit.Location = new System.Drawing.Point(171, 226);
            this.Address4_tEdit.MaxLength = 30;
            this.Address4_tEdit.Name = "Address4_tEdit";
            this.Address4_tEdit.Size = new System.Drawing.Size(496, 24);
            this.Address4_tEdit.TabIndex = 11;
            // 
            // ultraLabel2
            // 
            appearance35.TextVAlignAsString = "Middle";
            this.ultraLabel2.Appearance = appearance35;
            this.ultraLabel2.Location = new System.Drawing.Point(211, 200);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(43, 23);
            this.ultraLabel2.TabIndex = 57;
            this.ultraLabel2.Text = "丁目";
            this.ultraLabel2.Visible = false;
            // 
            // CompanyTelTitle1_tEdit
            // 
            appearance36.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance36.ForeColor = System.Drawing.Color.Black;
            appearance36.TextVAlignAsString = "Middle";
            this.CompanyTelTitle1_tEdit.ActiveAppearance = appearance36;
            appearance37.BackColorDisabled2 = System.Drawing.SystemColors.Control;
            appearance37.ForeColor = System.Drawing.Color.Black;
            appearance37.ForeColorDisabled = System.Drawing.Color.Black;
            appearance37.TextVAlignAsString = "Middle";
            this.CompanyTelTitle1_tEdit.Appearance = appearance37;
            this.CompanyTelTitle1_tEdit.AutoSelect = true;
            this.CompanyTelTitle1_tEdit.DataText = "";
            this.CompanyTelTitle1_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CompanyTelTitle1_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.CompanyTelTitle1_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.CompanyTelTitle1_tEdit.Location = new System.Drawing.Point(171, 252);
            this.CompanyTelTitle1_tEdit.MaxLength = 6;
            this.CompanyTelTitle1_tEdit.Name = "CompanyTelTitle1_tEdit";
            this.CompanyTelTitle1_tEdit.Size = new System.Drawing.Size(115, 24);
            this.CompanyTelTitle1_tEdit.TabIndex = 12;
            // 
            // CompanyTelTitle2_tEdit
            // 
            appearance38.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance38.ForeColor = System.Drawing.Color.Black;
            appearance38.TextVAlignAsString = "Middle";
            this.CompanyTelTitle2_tEdit.ActiveAppearance = appearance38;
            appearance39.BackColorDisabled2 = System.Drawing.SystemColors.Control;
            appearance39.ForeColor = System.Drawing.Color.Black;
            appearance39.ForeColorDisabled = System.Drawing.Color.Black;
            appearance39.TextVAlignAsString = "Middle";
            this.CompanyTelTitle2_tEdit.Appearance = appearance39;
            this.CompanyTelTitle2_tEdit.AutoSelect = true;
            this.CompanyTelTitle2_tEdit.DataText = "";
            this.CompanyTelTitle2_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CompanyTelTitle2_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.CompanyTelTitle2_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.CompanyTelTitle2_tEdit.Location = new System.Drawing.Point(171, 278);
            this.CompanyTelTitle2_tEdit.MaxLength = 6;
            this.CompanyTelTitle2_tEdit.Name = "CompanyTelTitle2_tEdit";
            this.CompanyTelTitle2_tEdit.Size = new System.Drawing.Size(115, 24);
            this.CompanyTelTitle2_tEdit.TabIndex = 14;
            // 
            // CompanyTelTitle3_tEdit
            // 
            appearance40.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance40.ForeColor = System.Drawing.Color.Black;
            appearance40.TextVAlignAsString = "Middle";
            this.CompanyTelTitle3_tEdit.ActiveAppearance = appearance40;
            appearance41.BackColorDisabled2 = System.Drawing.SystemColors.Control;
            appearance41.ForeColor = System.Drawing.Color.Black;
            appearance41.ForeColorDisabled = System.Drawing.Color.Black;
            appearance41.TextVAlignAsString = "Middle";
            this.CompanyTelTitle3_tEdit.Appearance = appearance41;
            this.CompanyTelTitle3_tEdit.AutoSelect = true;
            this.CompanyTelTitle3_tEdit.DataText = "";
            this.CompanyTelTitle3_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CompanyTelTitle3_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.CompanyTelTitle3_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.CompanyTelTitle3_tEdit.Location = new System.Drawing.Point(171, 304);
            this.CompanyTelTitle3_tEdit.MaxLength = 6;
            this.CompanyTelTitle3_tEdit.Name = "CompanyTelTitle3_tEdit";
            this.CompanyTelTitle3_tEdit.Size = new System.Drawing.Size(115, 24);
            this.CompanyTelTitle3_tEdit.TabIndex = 16;
            // 
            // CompanyTelNo1_tEdit
            // 
            appearance42.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance42.ForeColor = System.Drawing.Color.Black;
            appearance42.TextVAlignAsString = "Middle";
            this.CompanyTelNo1_tEdit.ActiveAppearance = appearance42;
            appearance43.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance43.ForeColor = System.Drawing.Color.Black;
            appearance43.ForeColorDisabled = System.Drawing.Color.Black;
            appearance43.TextVAlignAsString = "Middle";
            this.CompanyTelNo1_tEdit.Appearance = appearance43;
            this.CompanyTelNo1_tEdit.AutoSelect = true;
            this.CompanyTelNo1_tEdit.DataText = "";
            this.CompanyTelNo1_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CompanyTelNo1_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 16, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
            this.CompanyTelNo1_tEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.CompanyTelNo1_tEdit.Location = new System.Drawing.Point(411, 252);
            this.CompanyTelNo1_tEdit.MaxLength = 16;
            this.CompanyTelNo1_tEdit.Name = "CompanyTelNo1_tEdit";
            this.CompanyTelNo1_tEdit.Size = new System.Drawing.Size(139, 24);
            this.CompanyTelNo1_tEdit.TabIndex = 13;
            // 
            // CompanyTelNo2_tEdit
            // 
            appearance44.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance44.ForeColor = System.Drawing.Color.Black;
            appearance44.TextVAlignAsString = "Middle";
            this.CompanyTelNo2_tEdit.ActiveAppearance = appearance44;
            appearance45.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance45.ForeColor = System.Drawing.Color.Black;
            appearance45.ForeColorDisabled = System.Drawing.Color.Black;
            appearance45.TextVAlignAsString = "Middle";
            this.CompanyTelNo2_tEdit.Appearance = appearance45;
            this.CompanyTelNo2_tEdit.AutoSelect = true;
            this.CompanyTelNo2_tEdit.DataText = "";
            this.CompanyTelNo2_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CompanyTelNo2_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 16, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
            this.CompanyTelNo2_tEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.CompanyTelNo2_tEdit.Location = new System.Drawing.Point(411, 278);
            this.CompanyTelNo2_tEdit.MaxLength = 16;
            this.CompanyTelNo2_tEdit.Name = "CompanyTelNo2_tEdit";
            this.CompanyTelNo2_tEdit.Size = new System.Drawing.Size(139, 24);
            this.CompanyTelNo2_tEdit.TabIndex = 15;
            // 
            // CompanyTelNo3_tEdit
            // 
            appearance46.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance46.ForeColor = System.Drawing.Color.Black;
            appearance46.TextVAlignAsString = "Middle";
            this.CompanyTelNo3_tEdit.ActiveAppearance = appearance46;
            appearance47.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance47.ForeColor = System.Drawing.Color.Black;
            appearance47.ForeColorDisabled = System.Drawing.Color.Black;
            appearance47.TextVAlignAsString = "Middle";
            this.CompanyTelNo3_tEdit.Appearance = appearance47;
            this.CompanyTelNo3_tEdit.AutoSelect = true;
            this.CompanyTelNo3_tEdit.DataText = "";
            this.CompanyTelNo3_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CompanyTelNo3_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 16, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, true, false, true, true, true));
            this.CompanyTelNo3_tEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.CompanyTelNo3_tEdit.Location = new System.Drawing.Point(411, 304);
            this.CompanyTelNo3_tEdit.MaxLength = 16;
            this.CompanyTelNo3_tEdit.Name = "CompanyTelNo3_tEdit";
            this.CompanyTelNo3_tEdit.Size = new System.Drawing.Size(139, 24);
            this.CompanyTelNo3_tEdit.TabIndex = 17;
            // 
            // ultraLabel3
            // 
            this.ultraLabel3.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel3.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.ultraLabel3.Location = new System.Drawing.Point(10, 385);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(665, 3);
            this.ultraLabel3.TabIndex = 45;
            // 
            // TransferGuidance_tEdit
            // 
            appearance48.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance48.ForeColor = System.Drawing.Color.Black;
            appearance48.TextVAlignAsString = "Middle";
            this.TransferGuidance_tEdit.ActiveAppearance = appearance48;
            appearance49.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance49.ForeColor = System.Drawing.Color.Black;
            appearance49.ForeColorDisabled = System.Drawing.Color.Black;
            appearance49.TextVAlignAsString = "Middle";
            this.TransferGuidance_tEdit.Appearance = appearance49;
            this.TransferGuidance_tEdit.AutoSelect = true;
            this.TransferGuidance_tEdit.DataText = "";
            this.TransferGuidance_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.TransferGuidance_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.TransferGuidance_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.TransferGuidance_tEdit.Location = new System.Drawing.Point(171, 392);
            this.TransferGuidance_tEdit.MaxLength = 20;
            this.TransferGuidance_tEdit.Name = "TransferGuidance_tEdit";
            this.TransferGuidance_tEdit.Size = new System.Drawing.Size(337, 24);
            this.TransferGuidance_tEdit.TabIndex = 20;
            // 
            // AccountNoInfo1_tEdit
            // 
            appearance50.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance50.ForeColor = System.Drawing.Color.Black;
            appearance50.TextVAlignAsString = "Middle";
            this.AccountNoInfo1_tEdit.ActiveAppearance = appearance50;
            appearance51.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance51.ForeColor = System.Drawing.Color.Black;
            appearance51.ForeColorDisabled = System.Drawing.Color.Black;
            appearance51.TextVAlignAsString = "Middle";
            this.AccountNoInfo1_tEdit.Appearance = appearance51;
            this.AccountNoInfo1_tEdit.AutoSelect = true;
            this.AccountNoInfo1_tEdit.DataText = "";
            this.AccountNoInfo1_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.AccountNoInfo1_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.AccountNoInfo1_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.AccountNoInfo1_tEdit.Location = new System.Drawing.Point(171, 418);
            this.AccountNoInfo1_tEdit.MaxLength = 30;
            this.AccountNoInfo1_tEdit.Name = "AccountNoInfo1_tEdit";
            this.AccountNoInfo1_tEdit.Size = new System.Drawing.Size(496, 24);
            this.AccountNoInfo1_tEdit.TabIndex = 21;
            // 
            // AccountNoInfo2_tEdit
            // 
            appearance52.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance52.ForeColor = System.Drawing.Color.Black;
            appearance52.TextVAlignAsString = "Middle";
            this.AccountNoInfo2_tEdit.ActiveAppearance = appearance52;
            appearance53.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance53.ForeColor = System.Drawing.Color.Black;
            appearance53.ForeColorDisabled = System.Drawing.Color.Black;
            appearance53.TextVAlignAsString = "Middle";
            this.AccountNoInfo2_tEdit.Appearance = appearance53;
            this.AccountNoInfo2_tEdit.AutoSelect = true;
            this.AccountNoInfo2_tEdit.DataText = "";
            this.AccountNoInfo2_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.AccountNoInfo2_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.AccountNoInfo2_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.AccountNoInfo2_tEdit.Location = new System.Drawing.Point(171, 444);
            this.AccountNoInfo2_tEdit.MaxLength = 30;
            this.AccountNoInfo2_tEdit.Name = "AccountNoInfo2_tEdit";
            this.AccountNoInfo2_tEdit.Size = new System.Drawing.Size(496, 24);
            this.AccountNoInfo2_tEdit.TabIndex = 22;
            // 
            // AccountNoInfo3_tEdit
            // 
            appearance54.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance54.ForeColor = System.Drawing.Color.Black;
            appearance54.TextVAlignAsString = "Middle";
            this.AccountNoInfo3_tEdit.ActiveAppearance = appearance54;
            appearance55.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance55.ForeColor = System.Drawing.Color.Black;
            appearance55.ForeColorDisabled = System.Drawing.Color.Black;
            appearance55.TextVAlignAsString = "Middle";
            this.AccountNoInfo3_tEdit.Appearance = appearance55;
            this.AccountNoInfo3_tEdit.AutoSelect = true;
            this.AccountNoInfo3_tEdit.DataText = "";
            this.AccountNoInfo3_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.AccountNoInfo3_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.AccountNoInfo3_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.AccountNoInfo3_tEdit.Location = new System.Drawing.Point(171, 470);
            this.AccountNoInfo3_tEdit.MaxLength = 30;
            this.AccountNoInfo3_tEdit.Name = "AccountNoInfo3_tEdit";
            this.AccountNoInfo3_tEdit.Size = new System.Drawing.Size(496, 24);
            this.AccountNoInfo3_tEdit.TabIndex = 23;
            // 
            // CompanySetNote1_tEdit
            // 
            appearance56.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance56.ForeColor = System.Drawing.Color.Black;
            appearance56.TextVAlignAsString = "Middle";
            this.CompanySetNote1_tEdit.ActiveAppearance = appearance56;
            appearance57.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance57.ForeColor = System.Drawing.Color.Black;
            appearance57.ForeColorDisabled = System.Drawing.Color.Black;
            appearance57.TextVAlignAsString = "Middle";
            this.CompanySetNote1_tEdit.Appearance = appearance57;
            this.CompanySetNote1_tEdit.AutoSelect = true;
            this.CompanySetNote1_tEdit.DataText = "";
            this.CompanySetNote1_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CompanySetNote1_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.CompanySetNote1_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.CompanySetNote1_tEdit.Location = new System.Drawing.Point(171, 330);
            this.CompanySetNote1_tEdit.MaxLength = 20;
            this.CompanySetNote1_tEdit.Name = "CompanySetNote1_tEdit";
            this.CompanySetNote1_tEdit.Size = new System.Drawing.Size(337, 24);
            this.CompanySetNote1_tEdit.TabIndex = 18;
            // 
            // CompanySetNote2_tEdit
            // 
            appearance58.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance58.ForeColor = System.Drawing.Color.Black;
            appearance58.TextVAlignAsString = "Middle";
            this.CompanySetNote2_tEdit.ActiveAppearance = appearance58;
            appearance59.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance59.ForeColor = System.Drawing.Color.Black;
            appearance59.ForeColorDisabled = System.Drawing.Color.Black;
            appearance59.TextVAlignAsString = "Middle";
            this.CompanySetNote2_tEdit.Appearance = appearance59;
            this.CompanySetNote2_tEdit.AutoSelect = true;
            this.CompanySetNote2_tEdit.DataText = "";
            this.CompanySetNote2_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CompanySetNote2_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.CompanySetNote2_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.CompanySetNote2_tEdit.Location = new System.Drawing.Point(171, 356);
            this.CompanySetNote2_tEdit.MaxLength = 20;
            this.CompanySetNote2_tEdit.Name = "CompanySetNote2_tEdit";
            this.CompanySetNote2_tEdit.Size = new System.Drawing.Size(337, 24);
            this.CompanySetNote2_tEdit.TabIndex = 19;
            // 
            // ultraLabel4
            // 
            this.ultraLabel4.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel4.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.ultraLabel4.Location = new System.Drawing.Point(10, 499);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(665, 3);
            this.ultraLabel4.TabIndex = 51;
            // 
            // CompanyPr_tEdit
            // 
            appearance60.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance60.ForeColor = System.Drawing.Color.Black;
            appearance60.TextVAlignAsString = "Middle";
            this.CompanyPr_tEdit.ActiveAppearance = appearance60;
            appearance61.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance61.ForeColor = System.Drawing.Color.Black;
            appearance61.ForeColorDisabled = System.Drawing.Color.Black;
            appearance61.TextVAlignAsString = "Middle";
            this.CompanyPr_tEdit.Appearance = appearance61;
            this.CompanyPr_tEdit.AutoSelect = true;
            this.CompanyPr_tEdit.DataText = "";
            this.CompanyPr_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CompanyPr_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.CompanyPr_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.CompanyPr_tEdit.Location = new System.Drawing.Point(171, 34);
            this.CompanyPr_tEdit.MaxLength = 20;
            this.CompanyPr_tEdit.Name = "CompanyPr_tEdit";
            this.CompanyPr_tEdit.Size = new System.Drawing.Size(337, 24);
            this.CompanyPr_tEdit.TabIndex = 1;
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // ImageInfoCode_Title_Label
            // 
            appearance80.TextVAlignAsString = "Middle";
            this.ImageInfoCode_Title_Label.Appearance = appearance80;
            this.ImageInfoCode_Title_Label.Location = new System.Drawing.Point(20, 532);
            this.ImageInfoCode_Title_Label.Name = "ImageInfoCode_Title_Label";
            this.ImageInfoCode_Title_Label.Size = new System.Drawing.Size(125, 23);
            this.ImageInfoCode_Title_Label.TabIndex = 53;
            this.ImageInfoCode_Title_Label.Text = "画像情報";
            // 
            // TakeInImage_OpenFileDialog
            // 
            this.TakeInImage_OpenFileDialog.Filter = "画像ファイル(*.bmp;*.jpg;*.jpeg)|*.bmp;*.jpg;*.jpeg";
            this.TakeInImage_OpenFileDialog.RestoreDirectory = true;
            this.TakeInImage_OpenFileDialog.Title = "自社画像選択";
            // 
            // CompanyUrl_tEdit
            // 
            appearance78.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance78.ForeColor = System.Drawing.Color.Black;
            appearance78.TextVAlignAsString = "Middle";
            this.CompanyUrl_tEdit.ActiveAppearance = appearance78;
            appearance79.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance79.ForeColor = System.Drawing.Color.Black;
            appearance79.ForeColorDisabled = System.Drawing.Color.Black;
            appearance79.TextVAlignAsString = "Middle";
            this.CompanyUrl_tEdit.Appearance = appearance79;
            this.CompanyUrl_tEdit.AutoSelect = true;
            this.CompanyUrl_tEdit.DataText = "";
            this.CompanyUrl_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CompanyUrl_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 300, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.CompanyUrl_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.CompanyUrl_tEdit.Location = new System.Drawing.Point(171, 506);
            this.CompanyUrl_tEdit.MaxLength = 300;
            this.CompanyUrl_tEdit.Name = "CompanyUrl_tEdit";
            this.CompanyUrl_tEdit.Size = new System.Drawing.Size(469, 24);
            this.CompanyUrl_tEdit.TabIndex = 24;
            // 
            // CompanyUrl_Title_Label
            // 
            appearance77.TextVAlignAsString = "Middle";
            this.CompanyUrl_Title_Label.Appearance = appearance77;
            this.CompanyUrl_Title_Label.Location = new System.Drawing.Point(20, 506);
            this.CompanyUrl_Title_Label.Name = "CompanyUrl_Title_Label";
            this.CompanyUrl_Title_Label.Size = new System.Drawing.Size(125, 23);
            this.CompanyUrl_Title_Label.TabIndex = 52;
            this.CompanyUrl_Title_Label.Text = "自社ＵＲＬ";
            // 
            // CompanyPr2_tEdit
            // 
            appearance74.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance74.ForeColor = System.Drawing.Color.Black;
            appearance74.TextVAlignAsString = "Middle";
            this.CompanyPr2_tEdit.ActiveAppearance = appearance74;
            appearance75.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance75.ForeColor = System.Drawing.Color.Black;
            appearance75.ForeColorDisabled = System.Drawing.Color.Black;
            appearance75.TextVAlignAsString = "Middle";
            this.CompanyPr2_tEdit.Appearance = appearance75;
            this.CompanyPr2_tEdit.AutoSelect = true;
            this.CompanyPr2_tEdit.DataText = "";
            this.CompanyPr2_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CompanyPr2_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.CompanyPr2_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.CompanyPr2_tEdit.Location = new System.Drawing.Point(171, 112);
            this.CompanyPr2_tEdit.MaxLength = 20;
            this.CompanyPr2_tEdit.Name = "CompanyPr2_tEdit";
            this.CompanyPr2_tEdit.Size = new System.Drawing.Size(337, 24);
            this.CompanyPr2_tEdit.TabIndex = 4;
            // 
            // ultraLabel1
            // 
            appearance76.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance76;
            this.ultraLabel1.Location = new System.Drawing.Point(20, 112);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(125, 23);
            this.ultraLabel1.TabIndex = 38;
            this.ultraLabel1.Text = "自社ＰＲ文２";
            // 
            // ImageCommentForPrt1_Title_Label
            // 
            appearance73.TextVAlignAsString = "Middle";
            this.ImageCommentForPrt1_Title_Label.Appearance = appearance73;
            this.ImageCommentForPrt1_Title_Label.Location = new System.Drawing.Point(20, 558);
            this.ImageCommentForPrt1_Title_Label.Name = "ImageCommentForPrt1_Title_Label";
            this.ImageCommentForPrt1_Title_Label.Size = new System.Drawing.Size(145, 23);
            this.ImageCommentForPrt1_Title_Label.TabIndex = 56;
            this.ImageCommentForPrt1_Title_Label.Text = "画像印字用コメント";
            // 
            // ImageCommentForPrt1_tEdit
            // 
            appearance71.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance71.ForeColor = System.Drawing.Color.Black;
            appearance71.TextVAlignAsString = "Middle";
            this.ImageCommentForPrt1_tEdit.ActiveAppearance = appearance71;
            appearance72.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance72.ForeColor = System.Drawing.Color.Black;
            appearance72.ForeColorDisabled = System.Drawing.Color.Black;
            appearance72.TextVAlignAsString = "Middle";
            this.ImageCommentForPrt1_tEdit.Appearance = appearance72;
            this.ImageCommentForPrt1_tEdit.AutoSelect = true;
            this.ImageCommentForPrt1_tEdit.DataText = "";
            this.ImageCommentForPrt1_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.ImageCommentForPrt1_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.ImageCommentForPrt1_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.ImageCommentForPrt1_tEdit.Location = new System.Drawing.Point(171, 558);
            this.ImageCommentForPrt1_tEdit.MaxLength = 20;
            this.ImageCommentForPrt1_tEdit.Name = "ImageCommentForPrt1_tEdit";
            this.ImageCommentForPrt1_tEdit.Size = new System.Drawing.Size(337, 24);
            this.ImageCommentForPrt1_tEdit.TabIndex = 26;
            // 
            // ImageCommentForPrt2_tEdit
            // 
            appearance69.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance69.ForeColor = System.Drawing.Color.Black;
            appearance69.TextVAlignAsString = "Middle";
            this.ImageCommentForPrt2_tEdit.ActiveAppearance = appearance69;
            appearance70.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance70.ForeColor = System.Drawing.Color.Black;
            appearance70.ForeColorDisabled = System.Drawing.Color.Black;
            appearance70.TextVAlignAsString = "Middle";
            this.ImageCommentForPrt2_tEdit.Appearance = appearance70;
            this.ImageCommentForPrt2_tEdit.AutoSelect = true;
            this.ImageCommentForPrt2_tEdit.DataText = "";
            this.ImageCommentForPrt2_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.ImageCommentForPrt2_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.ImageCommentForPrt2_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.ImageCommentForPrt2_tEdit.Location = new System.Drawing.Point(171, 584);
            this.ImageCommentForPrt2_tEdit.MaxLength = 20;
            this.ImageCommentForPrt2_tEdit.Name = "ImageCommentForPrt2_tEdit";
            this.ImageCommentForPrt2_tEdit.Size = new System.Drawing.Size(337, 24);
            this.ImageCommentForPrt2_tEdit.TabIndex = 27;
            // 
            // ultraLabel6
            // 
            appearance68.ForeColor = System.Drawing.Color.Red;
            appearance68.TextVAlignAsString = "Middle";
            this.ultraLabel6.Appearance = appearance68;
            this.ultraLabel6.Location = new System.Drawing.Point(514, 558);
            this.ultraLabel6.Name = "ultraLabel6";
            this.ultraLabel6.Size = new System.Drawing.Size(153, 54);
            this.ultraLabel6.TabIndex = 55;
            this.ultraLabel6.Text = "※伝票で自社画像を使用する際に印字されます。";
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            this.ultraToolTipManager1.DisplayStyle = Infragistics.Win.ToolTipDisplayStyle.Standard;
            // 
            // ImageInfoCode_tComboEditor
            // 
            appearance65.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance65.ForeColor = System.Drawing.Color.Black;
            appearance65.ForeColorDisabled = System.Drawing.Color.Black;
            appearance65.TextVAlignAsString = "Middle";
            this.ImageInfoCode_tComboEditor.ActiveAppearance = appearance65;
            appearance66.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance66.ForeColor = System.Drawing.Color.Black;
            appearance66.ForeColorDisabled = System.Drawing.Color.Black;
            appearance66.TextVAlignAsString = "Middle";
            this.ImageInfoCode_tComboEditor.Appearance = appearance66;
            this.ImageInfoCode_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.ImageInfoCode_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance67.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance67.ForeColor = System.Drawing.Color.Black;
            appearance67.ForeColorDisabled = System.Drawing.Color.Black;
            this.ImageInfoCode_tComboEditor.ItemAppearance = appearance67;
            this.ImageInfoCode_tComboEditor.Location = new System.Drawing.Point(171, 532);
            this.ImageInfoCode_tComboEditor.Name = "ImageInfoCode_tComboEditor";
            this.ImageInfoCode_tComboEditor.Size = new System.Drawing.Size(337, 24);
            this.ImageInfoCode_tComboEditor.TabIndex = 25;
            // 
            // CompanyTel1_Title_Label
            // 
            appearance62.TextVAlignAsString = "Middle";
            this.CompanyTel1_Title_Label.Appearance = appearance62;
            this.CompanyTel1_Title_Label.Location = new System.Drawing.Point(318, 252);
            this.CompanyTel1_Title_Label.Name = "CompanyTel1_Title_Label";
            this.CompanyTel1_Title_Label.Size = new System.Drawing.Size(87, 23);
            this.CompanyTel1_Title_Label.TabIndex = 60;
            this.CompanyTel1_Title_Label.Text = "電話番号１";
            // 
            // CompanyTel2_Title_Label
            // 
            appearance63.TextVAlignAsString = "Middle";
            this.CompanyTel2_Title_Label.Appearance = appearance63;
            this.CompanyTel2_Title_Label.Location = new System.Drawing.Point(318, 278);
            this.CompanyTel2_Title_Label.Name = "CompanyTel2_Title_Label";
            this.CompanyTel2_Title_Label.Size = new System.Drawing.Size(87, 23);
            this.CompanyTel2_Title_Label.TabIndex = 61;
            this.CompanyTel2_Title_Label.Text = "電話番号２";
            // 
            // CompanyTel3_Title_Label
            // 
            appearance64.TextVAlignAsString = "Middle";
            this.CompanyTel3_Title_Label.Appearance = appearance64;
            this.CompanyTel3_Title_Label.Location = new System.Drawing.Point(318, 304);
            this.CompanyTel3_Title_Label.Name = "CompanyTel3_Title_Label";
            this.CompanyTel3_Title_Label.Size = new System.Drawing.Size(87, 23);
            this.CompanyTel3_Title_Label.TabIndex = 62;
            this.CompanyTel3_Title_Label.Text = "電話番号３";
            // 
            // Renewal_Button
            // 
            this.Renewal_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Renewal_Button.Location = new System.Drawing.Point(300, 626);
            this.Renewal_Button.Name = "Renewal_Button";
            this.Renewal_Button.Size = new System.Drawing.Size(125, 34);
            this.Renewal_Button.TabIndex = 29;
            this.Renewal_Button.Text = "最新情報(&I)";
            this.Renewal_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Renewal_Button.Click += new System.EventHandler(this.Renewal_Button_Click);
            // 
            // SFUKN09020UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(684, 692);
            this.Controls.Add(this.Renewal_Button);
            this.Controls.Add(this.CompanyTel1_Title_Label);
            this.Controls.Add(this.CompanyTel2_Title_Label);
            this.Controls.Add(this.CompanyTel3_Title_Label);
            this.Controls.Add(this.ImageInfoCode_tComboEditor);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this.ultraLabel6);
            this.Controls.Add(this.ImageCommentForPrt2_tEdit);
            this.Controls.Add(this.ImageCommentForPrt1_tEdit);
            this.Controls.Add(this.ImageCommentForPrt1_Title_Label);
            this.Controls.Add(this.CompanyPr2_tEdit);
            this.Controls.Add(this.ultraLabel1);
            this.Controls.Add(this.PostNo_Border_Label);
            this.Controls.Add(this.CompanyUrl_Title_Label);
            this.Controls.Add(this.CompanyUrl_tEdit);
            this.Controls.Add(this.CompanyTelNo1_tEdit);
            this.Controls.Add(this.CompanyTelTitle3_tEdit);
            this.Controls.Add(this.CompanyTelTitle2_tEdit);
            this.Controls.Add(this.CompanyTelTitle1_tEdit);
            this.Controls.Add(this.Address1_tEdit);
            this.Controls.Add(this.PostNo_tEdit);
            this.Controls.Add(this.PostNoMark_tEdit);
            this.Controls.Add(this.CompanyName2_tEdit);
            this.Controls.Add(this.CompanyName1_tEdit);
            this.Controls.Add(this.CompanyNameCd_tNedit);
            this.Controls.Add(this.Address3_tEdit);
            this.Controls.Add(this.Address4_tEdit);
            this.Controls.Add(this.CompanyTelNo2_tEdit);
            this.Controls.Add(this.CompanyTelNo3_tEdit);
            this.Controls.Add(this.TransferGuidance_tEdit);
            this.Controls.Add(this.AccountNoInfo1_tEdit);
            this.Controls.Add(this.AccountNoInfo2_tEdit);
            this.Controls.Add(this.AccountNoInfo3_tEdit);
            this.Controls.Add(this.CompanySetNote1_tEdit);
            this.Controls.Add(this.CompanySetNote2_tEdit);
            this.Controls.Add(this.CompanyPr_tEdit);
            this.Controls.Add(this.ImageInfoCode_Title_Label);
            this.Controls.Add(this.ultraLabel3);
            this.Controls.Add(this.ultraLabel2);
            this.Controls.Add(this.ultraLabel17);
            this.Controls.Add(this.CompanyNameCd_Title_Label);
            this.Controls.Add(this.Delete_Button);
            this.Controls.Add(this.Revive_Button);
            this.Controls.Add(this.Ok_Button);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.AddressGuide_Button);
            this.Controls.Add(this.Mode_Label);
            this.Controls.Add(this.CompanyName1_Title_Label);
            this.Controls.Add(this.PostNo_Title_Label);
            this.Controls.Add(this.CompanyName2_Title_Label);
            this.Controls.Add(this.Address_Title_Label);
            this.Controls.Add(this.CompanyTel1Title_Title_Label);
            this.Controls.Add(this.CompanyTel2Title_Title_Label);
            this.Controls.Add(this.CompanyTel3Title_Title_Label);
            this.Controls.Add(this.TransferGuidance_Title_Label);
            this.Controls.Add(this.AccountNoInfo1_Title_Label);
            this.Controls.Add(this.AccountNoInfo2_Title_Label);
            this.Controls.Add(this.AccountNoInfo3_Title_Label);
            this.Controls.Add(this.CompanySetNote_Title_Label);
            this.Controls.Add(this.CompanyPr_Title_Label);
            this.Controls.Add(this.ultraLabel4);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SFUKN09020UA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "自社名称設定";
            this.Load += new System.EventHandler(this.SFUKN09020UA_Load);
            this.VisibleChanged += new System.EventHandler(this.SFUKN09020UA_VisibleChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.SFUKN09020UA_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyNameCd_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyName1_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyName2_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PostNoMark_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PostNo_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Address1_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Address3_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Address4_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyTelTitle1_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyTelTitle2_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyTelTitle3_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyTelNo1_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyTelNo2_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyTelNo3_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TransferGuidance_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AccountNoInfo1_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AccountNoInfo2_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AccountNoInfo3_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanySetNote1_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanySetNote2_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyPr_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyUrl_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyPr2_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageCommentForPrt1_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageCommentForPrt2_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageInfoCode_tComboEditor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		#region Main
		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main() 
		{
			System.Windows.Forms.Application.Run(new SFUKN09020UA());
		}
		#endregion

		#region Events
		/// <summary>画面非表示イベント</summary>
		/// <remarks>画面が非表示状態になった時に発生します。</remarks>
		public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;
		#endregion

		#region Properties
		/// <summary>画面終了設定プロパティ</summary>
		/// <value>画面クローズを許可するかどうかの設定を取得または設定します。</value>
		/// <remarks>falseの場合は、画面を閉じる際、CloseではなくHide(非表示)を実行します。</remarks>
		public bool CanClose
		{
			get {
				return this._canClose;
			}
			set {
				this._canClose = value;
			}
		}

		/// <summary>削除可能設定プロパティ</summary>
		/// <value>削除が可能かどうかの設定を取得します。</value>
		public bool CanDelete
		{
			get {
				return this._canDelete;
			}
		}

		/// <summary>論理削除データ抽出可能設定プロパティ</summary>
		/// <value>論理削除データの抽出が可能かどうかの設定を取得します。</value>
		public bool CanLogicalDeleteDataExtraction
		{
			get {
				return this._canLogicalDeleteDataExtraction;
			}
		}

		/// <summary>新規作成可能設定プロパティ</summary>
		/// <value>新規作成が可能かどうかの設定を取得します。</value>
		public bool CanNew
		{
			get {
				return this._canNew;
			}
		}

		/// <summary>印刷可能設定プロパティ</summary>
		/// <value>印刷が可能かどうかの設定を取得します。</value>
		public bool CanPrint
		{
			get {
				return this._canPrint;
			}
		}

		/// <summary>件数指定抽出可能設定プロパティ</summary>
		/// <value>件数指定抽出が可能かどうかの設定を取得します。</value>
		public bool CanSpecificationSearch
		{
			get {
				return this._canSpecificationSearch;
			}
		}

		/// <summary>データセットの選択データインデックスプロパティ</summary>
		/// <value>データセットの選択データインデックスを取得または設定します。</value>
		public int DataIndex
		{
			get {
				return this._dataIndex;
			}
			set {
				this._dataIndex = value;
			}
		}

		/// <summary>列のサイズの自動調整のデフォルト値プロパティ</summary>
		/// <value>列のサイズの自動調整チェックボックスのチェック有無のデフォルト値を取得します。</value>
		public bool DefaultAutoFillToColumn
		{
			get {
				return this._defaultAutoFillToColumn;
			}
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// グリッド列外観情報取得処理
		/// </summary>
		/// <returns>グリッド列外観情報格納Hashtable</returns>
		/// <remarks>
		/// <br>Note       : グリッドの各列の外見を設定するクラスを格納したHashtableを取得します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		public Hashtable GetAppearanceTable()
		{
			Hashtable appearanceTable = new Hashtable();

			// 削除日
			appearanceTable.Add( DELETE_DATE, 
				new GridColAppearance( MGridColDispType.DeletionDataBoth, 
				ContentAlignment.MiddleLeft, "", Color.Red ) );
			// コード
			appearanceTable.Add( COMPANYNAMECD_TITLE, 
				new GridColAppearance( MGridColDispType.Both, 
				ContentAlignment.MiddleRight, "", Color.Black ) );
			// 自社名称
			appearanceTable.Add( COMPANYNAME_TITLE, 
				new GridColAppearance( MGridColDispType.Both, 
				ContentAlignment.MiddleLeft, "", Color.Black ) );
			// 郵便番号
			appearanceTable.Add( POSTNO_TITLE, 
				new GridColAppearance( MGridColDispType.Both, 
				ContentAlignment.MiddleLeft, "", Color.Black ) );
			// 住所
			appearanceTable.Add( ADDRESS_TITLE, 
				new GridColAppearance( MGridColDispType.Both, 
				ContentAlignment.MiddleLeft, "", Color.Black ) );
			// 電話番号１
			appearanceTable.Add( COMPANYTELNO1_TITLE, 
				new GridColAppearance( MGridColDispType.Both, 
				ContentAlignment.MiddleLeft, "", Color.Black ) );
			// 電話番号２
			appearanceTable.Add( COMPANYTELNO2_TITLE, 
				new GridColAppearance( MGridColDispType.DetailsOnly, 
				ContentAlignment.MiddleLeft, "", Color.Black ) );
			// 電話番号３
			appearanceTable.Add( COMPANYTELNO3_TITLE, 
				new GridColAppearance( MGridColDispType.DetailsOnly, 
				ContentAlignment.MiddleLeft, "", Color.Black ) );
			// 銀行振込案内文
			appearanceTable.Add( TRANSFERGUIDANCE_TITLE, 
				new GridColAppearance( MGridColDispType.DetailsOnly, 
				ContentAlignment.MiddleLeft, "", Color.Black ) );
			// 銀行口座１
			appearanceTable.Add( ACCOUNTNOINFO1_TITLE, 
				new GridColAppearance( MGridColDispType.DetailsOnly, 
				ContentAlignment.MiddleLeft, "", Color.Black ) );
			// 銀行口座２
			appearanceTable.Add( ACCOUNTNOINFO2_TITLE, 
				new GridColAppearance( MGridColDispType.DetailsOnly, 
				ContentAlignment.MiddleLeft, "", Color.Black ) );
			// 銀行口座３
			appearanceTable.Add( ACCOUNTNOINFO3_TITLE, 
				new GridColAppearance( MGridColDispType.DetailsOnly, 
				ContentAlignment.MiddleLeft, "", Color.Black ) );
			// 自社設定摘要１
			appearanceTable.Add( COMPANYSETNOTE1_TITLE, 
				new GridColAppearance( MGridColDispType.DetailsOnly, 
				ContentAlignment.MiddleLeft, "", Color.Black ) );
			// 自社設定摘要２
			appearanceTable.Add( COMPANYSETNOTE2_TITLE, 
				new GridColAppearance( MGridColDispType.DetailsOnly, 
				ContentAlignment.MiddleLeft, "", Color.Black ) );
			// 自社ＰＲ文
			appearanceTable.Add( COMPANYPR_TITLE, 
				new GridColAppearance( MGridColDispType.DetailsOnly, 
				ContentAlignment.MiddleLeft, "", Color.Black ) );
			// 自社ＰＲ文２
			appearanceTable.Add( COMPANYPR2_TITLE, 
				new GridColAppearance( MGridColDispType.DetailsOnly, 
				ContentAlignment.MiddleLeft, "", Color.Black ) );
            // 2007.05.17  S.Koga  ADD ----------------------------------------
            // 画像情報区分
            appearanceTable.Add(IMAGEINFODIV_TITLE,
                new GridColAppearance(MGridColDispType.DetailsOnly,
                ContentAlignment.MiddleRight, "", Color.Black));
            // 画像情報コード
            appearanceTable.Add(IMAGEINFOCODE_TITLE,
                new GridColAppearance(MGridColDispType.DetailsOnly,
                ContentAlignment.MiddleRight, "", Color.Black));
            // ----------------------------------------------------------------
			// 自社URL文
			appearanceTable.Add( COMPANYURL_TITLE, 
				new GridColAppearance( MGridColDispType.DetailsOnly, 
				ContentAlignment.MiddleLeft, "", Color.Black ) );
			// GUID
			appearanceTable.Add( GUID_TITLE, 
				new GridColAppearance( MGridColDispType.None, 
				ContentAlignment.MiddleLeft, "", Color.Black ) );
			// 画像印字用コメント１
			appearanceTable.Add( IMAGECOMMENTFORPRT1_TITLE, 
				new GridColAppearance( MGridColDispType.DetailsOnly, 
				ContentAlignment.MiddleLeft, "", Color.Black ) );
			// 画像印字用コメント２
			appearanceTable.Add( IMAGECOMMENTFORPRT2_TITLE, 
				new GridColAppearance( MGridColDispType.DetailsOnly, 
				ContentAlignment.MiddleLeft, "", Color.Black ) );

			return appearanceTable;
		}

		/// <summary>
		/// バインドデータセット取得処理
		/// </summary>
		/// <param name="bindDataSet">グリッド用データセット</param>
		/// <param name="tableName">テーブル名</param>
		/// <remarks>
		/// <br>Note       : グリッドにバインドさせるデータセットを取得します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		public void GetBindDataSet( ref DataSet bindDataSet, ref string tableName )
		{
			bindDataSet	= this.Bind_DataSet;
			tableName	= COMPANYNM_TABLE;
		}

		/// <summary>
		/// データ検索処理
		/// </summary>
		/// <param name="totalCnt">全該当件数</param>
		/// <param name="readCnt">抽出対象件数</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : データを検索し、抽出結果を展開したデータセットと全該当件数を返します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		public int Search( ref int totalCnt, int readCnt )
		{
			return SearchCompanyNm( ref totalCnt, readCnt );
		}

		/// <summary>
		/// ネクストデータ検索処理
		/// </summary>
		/// <param name="readCnt">抽出対象件数</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 指定件数分のネクストデータを検索します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		public int SearchNext( int readCnt )
		{
			// 未実装
			return ( int )ConstantManagement.DB_Status.ctDB_EOF;
		}

		/// <summary>
		/// データ削除処理
		/// </summary>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 選択中のデータを削除します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		public int Delete()
		{
			return LogicalDelete();
		}

		/// <summary>
		/// 印刷処理
		/// </summary>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 印刷処理を実行します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		public int Print()
		{
			// 印刷用アセンブリをロードする（未実装）
			return 0;
		}
		#endregion

		#region Private Methods
		/// <summary>
		/// データ検索処理
		/// </summary>
		/// <param name="totalCnt">全該当件数</param>
		/// <param name="readCnt">抽出対象件数</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : データを検索し、抽出結果を展開したデータセットと全該当件数を返します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		private int SearchCompanyNm( ref int totalCnt, int readCnt )
		{
			int status = 0;
			ArrayList companyNms = null;

			// 抽出対象件数が0件の場合は全件抽出を実行する
			status = this._companyNmAcs.SearchAll( out companyNms, this._enterpriseCode );
			switch( status ) {
				case ( int )ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					int index = 0;
					foreach( CompanyNm companyNm in companyNms ) {
						if( this._companyNmTable.ContainsKey( companyNm.FileHeaderGuid ) == false ) {
							CompanyNmToDataSet( companyNm.Clone(), index );
							index++;
						}
					}

					break;
				}
				case ( int )ConstantManagement.DB_Status.ctDB_EOF:
				{
					break;
				}
				default:
				{
					// サーチ
					TMsgDisp.Show( 
						this, 								// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
						"SFUKN09020U", 						// アセンブリＩＤまたはクラスＩＤ
						"自社名称設定", 					// プログラム名称
						"SearchCompanyNm", 					// 処理名称
						TMsgDisp.OPE_GET, 					// オペレーション
						"読み込みに失敗しました。", 		// 表示するメッセージ
						status, 							// ステータス値
						this._companyNmAcs, 				// エラーが発生したオブジェクト
						MessageBoxButtons.OK, 				// 表示するボタン
						MessageBoxDefaultButton.Button1 );	// 初期表示ボタン

					break;
				}
			}
			
			totalCnt = companyNms.Count;

			return status;
		}

		/// <summary>
		/// 自社名称オブジェクト展開処理
		/// </summary>
		/// <param name="companyNm">自社名称オブジェクト</param>
		/// <param name="index">データセットへ展開するインデックス</param>
		/// <remarks>
		/// <br>Note       : 自社名称クラスをDataSetに格納します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		private void CompanyNmToDataSet( CompanyNm companyNm, int index )
		{
			if( ( index < 0 ) || ( index >= this.Bind_DataSet.Tables[ COMPANYNM_TABLE ].Rows.Count ) ) {
				// 新規と判断し、行を追加する。
				DataRow dataRow = this.Bind_DataSet.Tables[ COMPANYNM_TABLE ].NewRow();
				this.Bind_DataSet.Tables[ COMPANYNM_TABLE ].Rows.Add( dataRow );

				// indexを最終行番号にする
				index = this.Bind_DataSet.Tables[ COMPANYNM_TABLE ].Rows.Count - 1;
			}

			// 削除日
			if( companyNm.LogicalDeleteCode == 0 ) {
				this.Bind_DataSet.Tables[ COMPANYNM_TABLE ].Rows[ index ][ DELETE_DATE ] = "";
			}
			else {
				this.Bind_DataSet.Tables[ COMPANYNM_TABLE ].Rows[ index ][ DELETE_DATE ] = companyNm.UpdateDateTimeJpInFormal;
			}

			// 自社名称コード
			this.Bind_DataSet.Tables[ COMPANYNM_TABLE ].Rows[ index ][ COMPANYNAMECD_TITLE ]	= companyNm.CompanyNameCd;
			// 自社名称
			this.Bind_DataSet.Tables[ COMPANYNM_TABLE ].Rows[ index ][ COMPANYNAME_TITLE ]		= companyNm.CompanyName1 + "　" + companyNm.CompanyName2;
			// 郵便番号
			this.Bind_DataSet.Tables[ COMPANYNM_TABLE ].Rows[ index ][ POSTNO_TITLE ]			= companyNm.PostNo;
			string address = "";
			address += companyNm.Address1;
            # region 2007.05.27  S.Koga  DEL
            // 住所２（丁目）あり
            //if( companyNm.Address2 > 0 ) {
            //    address += companyNm.Address2.ToString() + "丁目";
            //}
            # endregion
            address += companyNm.Address3 + "　" + companyNm.Address4;
			// 住所
			this.Bind_DataSet.Tables[ COMPANYNM_TABLE ].Rows[ index ][ ADDRESS_TITLE ]			= address;
			// 電話番号１
			this.Bind_DataSet.Tables[ COMPANYNM_TABLE ].Rows[ index ][ COMPANYTELNO1_TITLE ]	= companyNm.CompanyTelTitle1 + " " + companyNm.CompanyTelNo1;
			// 電話番号２
			this.Bind_DataSet.Tables[ COMPANYNM_TABLE ].Rows[ index ][ COMPANYTELNO2_TITLE ]	= companyNm.CompanyTelTitle2 + " " + companyNm.CompanyTelNo2;
			// 電話番号３
			this.Bind_DataSet.Tables[ COMPANYNM_TABLE ].Rows[ index ][ COMPANYTELNO3_TITLE ]	= companyNm.CompanyTelTitle3 + " " + companyNm.CompanyTelNo3;
			// 銀行振込案内文
			this.Bind_DataSet.Tables[ COMPANYNM_TABLE ].Rows[ index ][ TRANSFERGUIDANCE_TITLE ]	= companyNm.TransferGuidance;
			// 銀行口座１
			this.Bind_DataSet.Tables[ COMPANYNM_TABLE ].Rows[ index ][ ACCOUNTNOINFO1_TITLE ]	= companyNm.AccountNoInfo1;
			// 銀行口座２
			this.Bind_DataSet.Tables[ COMPANYNM_TABLE ].Rows[ index ][ ACCOUNTNOINFO2_TITLE ]	= companyNm.AccountNoInfo2;
			// 銀行口座３
			this.Bind_DataSet.Tables[ COMPANYNM_TABLE ].Rows[ index ][ ACCOUNTNOINFO3_TITLE ]	= companyNm.AccountNoInfo3;
			// 自社設定摘要１
			this.Bind_DataSet.Tables[ COMPANYNM_TABLE ].Rows[ index ][ COMPANYSETNOTE1_TITLE ]	= companyNm.CompanySetNote1;
			// 自社設定摘要２
			this.Bind_DataSet.Tables[ COMPANYNM_TABLE ].Rows[ index ][ COMPANYSETNOTE2_TITLE ]	= companyNm.CompanySetNote2;
			// 自社ＰＲ文
			this.Bind_DataSet.Tables[ COMPANYNM_TABLE ].Rows[ index ][ COMPANYPR_TITLE ]		= companyNm.CompanyPr;
			// 自社ＰＲ文２
			this.Bind_DataSet.Tables[ COMPANYNM_TABLE ].Rows[ index ][ COMPANYPR2_TITLE ]		= companyNm.CompanyPrSentence2;
            // 2007.05.17  S.Koga  ADD ----------------------------------------
            // 画像情報区分
            this.Bind_DataSet.Tables[ COMPANYNM_TABLE ].Rows[ index ][ IMAGEINFODIV_TITLE ]     = companyNm.ImageInfoDiv;
            // 画像情報コード
            this.Bind_DataSet.Tables[ COMPANYNM_TABLE ].Rows[ index ][ IMAGEINFOCODE_TITLE ]    = companyNm.ImageInfoCode;
            // ----------------------------------------------------------------
			// 自社ＵＲＬ
			this.Bind_DataSet.Tables[ COMPANYNM_TABLE ].Rows[ index ][ COMPANYURL_TITLE ]   = companyNm.CompanyUrl;
			// 画像印字用コメント１
			this.Bind_DataSet.Tables[ COMPANYNM_TABLE ].Rows[ index ][ IMAGECOMMENTFORPRT1_TITLE ]	= companyNm.ImageCommentForPrt1;
			// 画像印字用コメント２
			this.Bind_DataSet.Tables[ COMPANYNM_TABLE ].Rows[ index ][ IMAGECOMMENTFORPRT2_TITLE ]	= companyNm.ImageCommentForPrt2;
			// GUID
			this.Bind_DataSet.Tables[ COMPANYNM_TABLE ].Rows[ index ][ GUID_TITLE ] = companyNm.FileHeaderGuid;

			if( this._companyNmTable.ContainsKey( companyNm.FileHeaderGuid ) == true ) {
				this._companyNmTable.Remove( companyNm.FileHeaderGuid );
			}
			this._companyNmTable.Add( companyNm.FileHeaderGuid, companyNm );

		}

		/// <summary>
		/// データセット列情報構築処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : データセットの列情報を構築します。
		///                  データセットの列情報がフレームのビュー用グリッドの列になります。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2005.09.09</br>
		/// </remarks>
		private void DataSetColumnConstruction()
		{
			DataTable companyNmTable = new DataTable( COMPANYNM_TABLE );
			companyNmTable.Columns.Add( DELETE_DATE, typeof( string ) );
			companyNmTable.Columns.Add( COMPANYNAMECD_TITLE, typeof( int ) );
			companyNmTable.Columns.Add( COMPANYNAME_TITLE, typeof( string ) );
			companyNmTable.Columns.Add( POSTNO_TITLE, typeof( string ) );
			companyNmTable.Columns.Add( ADDRESS_TITLE, typeof( string ) );
			companyNmTable.Columns.Add( COMPANYTELNO1_TITLE, typeof( string ) );
			companyNmTable.Columns.Add( COMPANYTELNO2_TITLE, typeof( string ) );
			companyNmTable.Columns.Add( COMPANYTELNO3_TITLE, typeof( string ) );
			companyNmTable.Columns.Add( TRANSFERGUIDANCE_TITLE, typeof( string ) );
			companyNmTable.Columns.Add( ACCOUNTNOINFO1_TITLE, typeof( string ) );
			companyNmTable.Columns.Add( ACCOUNTNOINFO2_TITLE, typeof( string ) );
			companyNmTable.Columns.Add( ACCOUNTNOINFO3_TITLE, typeof( string ) );
			companyNmTable.Columns.Add( COMPANYSETNOTE1_TITLE, typeof( string ) );
			companyNmTable.Columns.Add( COMPANYSETNOTE2_TITLE, typeof( string ) );
			companyNmTable.Columns.Add( COMPANYPR_TITLE, typeof( string ) );
			companyNmTable.Columns.Add( COMPANYPR2_TITLE, typeof( string ) );
            // 2007.05.17  S.Koga  ADD ----------------------------------------
            companyNmTable.Columns.Add( IMAGEINFODIV_TITLE, typeof( int ) );
            companyNmTable.Columns.Add( IMAGEINFOCODE_TITLE, typeof( int ) );
            // ----------------------------------------------------------------
			companyNmTable.Columns.Add( COMPANYURL_TITLE, typeof( string ) );
			companyNmTable.Columns.Add( IMAGECOMMENTFORPRT1_TITLE, typeof( string ) );
			companyNmTable.Columns.Add( IMAGECOMMENTFORPRT2_TITLE, typeof( string ) );
			companyNmTable.Columns.Add( GUID_TITLE, typeof( Guid ) );

			this.Bind_DataSet.Tables.Add( companyNmTable );
		}

		/// <summary>
		/// 画面初期設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 画面の初期設定を行います。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2005.09.12</br>
		/// </remarks>
		private void ScreenInitialSetting()
		{
			// ボタン配置
			int CANCELBUTTONLOCATION_X	= this.Cancel_Button.Location.X;
			int OKBUTTONLOCATION_X		= this.Ok_Button.Location.X;
			int DELETEBUTTONLOCATION_X	= this.Revive_Button.Location.X;
			int BUTTONLOCATION_Y		= this.Cancel_Button.Location.Y;
			this.Cancel_Button.Location		= new System.Drawing.Point( CANCELBUTTONLOCATION_X, BUTTONLOCATION_Y );
			this.Ok_Button.Location			= new System.Drawing.Point( OKBUTTONLOCATION_X, BUTTONLOCATION_Y );
			this.Revive_Button.Location		= new System.Drawing.Point( OKBUTTONLOCATION_X, BUTTONLOCATION_Y );
			this.Delete_Button.Location		= new System.Drawing.Point( DELETEBUTTONLOCATION_X, BUTTONLOCATION_Y );
            this.ImageInfoCode_tComboEditor.Items.Clear();
            // 2007.05.17  S.Koga  add ----------------------------------------
            GetImageInfoCode(IMAGEINFODIV_DATA);
            // ----------------------------------------------------------------

        }

        // 2007.05.17  S.Koga  add --------------------------------------------
        private void GetImageInfoCode(int imageInfoCode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            int totalcount = 0;
            status = this._imageInfoAcs.Search(out totalcount, this._enterpriseCode, imageInfoCode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && (totalcount > 0))
            {
                ImageInfoDS = this._imageInfoAcs.BindDataSet;
                DataTable imageDT = ImageInfoDS.Tables[ImageInfoAcs.TBL_IMAGEINFO_TITLE];
                this.ImageInfoCode_tComboEditor.MaxLength = imageDT.DefaultView.Count + 1;
                this.ImageInfoCode_tComboEditor.Items.Add(0, " ");
                for (int i = 0; i < imageDT.DefaultView.Count; i++)
                {
                    DataRow imageDR = imageDT.DefaultView[i].Row;
                    // --- CHG 2008/11/06 --------------------------------------------------------------------->>>>>
                    //this.ImageInfoCode_tComboEditor.Items.Add((int)imageDR[ImageInfoAcs.COL_IMAGEINFOCODE_TITLE], (string)imageDR[ImageInfoAcs.COL_IMAGEINFONAME_TITLE]);
                    this.ImageInfoCode_tComboEditor.Items.Add(int.Parse((string)imageDR[ImageInfoAcs.COL_IMAGEINFOCODE_TITLE]), (string)imageDR[ImageInfoAcs.COL_IMAGEINFONAME_TITLE]);
                    // --- CHG 2008/11/06 ---------------------------------------------------------------------<<<<<
                }
            }
            else
            {
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    SetErrorMessage(status);
                // 空白をセット
                this.ImageInfoCode_tComboEditor.MaxLength = 1;
                this.ImageInfoCode_tComboEditor.Items.Add(0, " ");
            }
        }

        private void SetErrorMessage(int errorCode)
        {
            switch (errorCode)
            {
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        // 画像情報が登録されていないためそのまま終了
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    {
                        TMsgDisp.Show(
                            this, 									// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,		// エラーレベル
                            "MAKHN09632A", 							// アセンブリＩＤまたはクラスＩＤ
                            "画像情報が取得できません。",           // 表示するメッセージ
                            errorCode, 								// ステータス値
                            MessageBoxButtons.OK);					// 表示するボタン
                        break;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this, 								// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
                            "MAKHN09632A", 						// アセンブリＩＤまたはクラスＩＤ
                            "自社名称設定", 					// プログラム名称
                            "SetErrorMessage", 					// 処理名称
                            TMsgDisp.OPE_LOAD,   				// オペレーション
                            "画像情報取得に失敗しました。",     // 表示するメッセージ
                            errorCode, 							// ステータス値
                            this._imageInfoAcs, 				// エラーが発生したオブジェクト
                            MessageBoxButtons.OK, 				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン
                        CloseForm(DialogResult.Cancel);
                        break;
                    }
            }
        }
        // --------------------------------------------------------------------

        /// <summary>
        /// 画面クリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面をクリアします。</br>
        /// <br>Programmer : 23001 秋山　亮介</br>
        /// <br>Date       : 2005.09.12</br>
        /// </remarks>
        private void ScreenClear()
		{
			this.CompanyNameCd_tNedit.Clear();		// 自社名称コード
			this.CompanyName1_tEdit.Clear();		// 自社名称１
			this.CompanyName2_tEdit.Clear();		// 自社名称２
			this.PostNo_tEdit.Clear();				// 郵便番号
			this.Address1_tEdit.Clear();			// 住所１
            //this.Address2_tNedit.Clear();			// 住所２  // DEL 2008/06/04
			this.Address3_tEdit.Clear();			// 住所３
			this.Address4_tEdit.Clear();			// 住所４
			this.CompanyTelTitle1_tEdit.Clear();	// 自社電話番号タイトル１
			this.CompanyTelTitle2_tEdit.Clear();	// 自社電話番号タイトル２
			this.CompanyTelTitle3_tEdit.Clear();	// 自社電話番号タイトル３
			this.CompanyTelNo1_tEdit.Clear();		// 自社電話番号１
			this.CompanyTelNo2_tEdit.Clear();		// 自社電話番号２
			this.CompanyTelNo3_tEdit.Clear();		// 自社電話番号３
			this.TransferGuidance_tEdit.Clear();	// 銀行振込案内文
			this.AccountNoInfo1_tEdit.Clear();		// 銀行口座１
			this.AccountNoInfo2_tEdit.Clear();		// 銀行口座２
			this.AccountNoInfo3_tEdit.Clear();		// 銀行口座３
			this.CompanySetNote1_tEdit.Clear();		// 自社設定摘要１
			this.CompanySetNote2_tEdit.Clear();		// 自社設定摘要２
			this.CompanyPr_tEdit.Clear();			// 自社ＰＲ文
            // 2007.05.17  S.Koga  ADD ----------------------------------------
            this.ImageInfoCode_tComboEditor.SelectedIndex = 0;  // 画像情報コード
            // ----------------------------------------------------------------
			this.CompanyUrl_tEdit.Clear();			// 自社URL文
			this.CompanyPr2_tEdit.Clear();          // 自社PR文２
			this.ImageCommentForPrt1_tEdit.Clear(); // 画像印字用コメント１
			this.ImageCommentForPrt2_tEdit.Clear(); // 画像印字用コメント２
            # region 2007.05.17  S.Koga  DEL
            //this.Image_tEdit.Clear();	// 取込画像パス

            //this.TakeInImage_GuideButton.Enabled = false;
            //this.TakeInImageDelete_Button.Enabled = false;
			// 画像表示ピクチャーボックス
            //this.TakeInImage_UltraPictureBox.Image = null;
            //this._imageGroup		= null;
            //this._imgManage			= null;
            # endregion
            this._changeTakeInImage	= false;
// 2006.08.18 AKIYAMA DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//			this._imageTransferring	= false;
//
//			// 転送中窓をnullで初期化
//			this._waitWindow = null;
// 2006.08.18 AKIYAMA DEL <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

			this._changeFlg = false;
		}

		/// <summary>
		/// 画面再構築処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : モードに基づいて画面を再構築します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2005.09.12</br>
		/// </remarks>
		private void ScreenReconstruction()
		{
			if( this._dataIndex < 0 ) {
				// 新規モード
				this._logicalDeleteMode = -1;

				CompanyNm newCompanyNm		= new CompanyNm();
				// 自社名称オブジェクトを画面に展開
				CompanyNmToScreen( newCompanyNm );

                # region 2007.05.17  S.Koga  DEL
                //TakeInImageToScreen( newCompanyNm );
                # endregion

                // クローン作成
				this._companyNmClone = newCompanyNm.Clone();
				DispToCompanyNm( ref this._companyNmClone );
                this.ImageInfoCode_tComboEditor.NullText = "";
			}
			else {
				Guid guid = ( Guid )this.Bind_DataSet.Tables[ COMPANYNM_TABLE ].Rows[ this._dataIndex ][ GUID_TITLE ];
				CompanyNm companyNm = ( CompanyNm )this._companyNmTable[ guid ];

				// 自社名称オブジェクトを画面に展開
				CompanyNmToScreen( companyNm );

                # region 2007.05.17  S.Koga  DEL
                //TakeInImageToScreen( companyNm );
                # endregion

                if ( companyNm.LogicalDeleteCode == 0 ) {
					// 更新モード
					this._logicalDeleteMode = 0;

					// クローン作成
					this._companyNmClone = companyNm.Clone();
					DispToCompanyNm( ref this._companyNmClone );
				}
				else {
					// 削除モード
					this._logicalDeleteMode = 1;
				}
			}
			// _GridIndexバッファ保持（メインフレーム最小化対応）
			this._indexBuf = this._dataIndex;

			ScreenInputPermissionControl();
		}

		/// <summary>
		/// 画面入力許可制御処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 画面の入力許可を制御します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2005.09.12</br>
		/// </remarks>
		private void ScreenInputPermissionControl()
		{
            switch (this._logicalDeleteMode)
            {
				case -1:
				{
					// 新規モード
					this.Mode_Label.Text		= INSERT_MODE;

					// ボタンの表示
                    this.Ok_Button.Visible = true;
                    this.Renewal_Button.Visible = true;
					this.Cancel_Button.Visible		= true;
					this.Revive_Button.Visible		= false;
					this.Delete_Button.Visible		= false;

					// コントロールの表示設定
					ScreenInputPermissionControl( true );

					// 郵便番号マークの背景色設定
					this.PostNoMark_tEdit.Appearance.BackColorDisabled = System.Drawing.Color.White;

					// 初期フォーカスをセット
					this.CompanyNameCd_tNedit.Focus();
					this.CompanyNameCd_tNedit.SelectAll();

					break;
				}
				case 1:
				{
					// 削除モード
					this.Mode_Label.Text		= DELETE_MODE;

					// ボタンの表示
                    this.Ok_Button.Visible = false;
                    this.Renewal_Button.Visible = false;
					this.Cancel_Button.Visible		= true;
					this.Revive_Button.Visible		= true;
					this.Delete_Button.Visible		= true;

					// コントロールの表示設定
					ScreenInputPermissionControl( false );

					// 郵便番号マークの背景色設定
					this.PostNoMark_tEdit.Appearance.BackColorDisabled = System.Drawing.SystemColors.Control;

					// 初期フォーカスをセット
					this.Delete_Button.Focus();

					break;
				}
				default:
				{
					// 更新モード
					this.Mode_Label.Text		= UPDATE_MODE;

					// ボタンの表示
                    this.Ok_Button.Visible = true;
                    this.Renewal_Button.Visible = true;
					this.Cancel_Button.Visible		= true;
					this.Revive_Button.Visible		= false;
					this.Delete_Button.Visible		= false;

					// コントロールの表示設定
					ScreenInputPermissionControl( true );
					this.CompanyNameCd_tNedit.Enabled	= false;

					// 郵便番号マークの背景色設定
					this.PostNoMark_tEdit.Appearance.BackColorDisabled = System.Drawing.Color.White;

					// 初期フォーカスをセット
					this.CompanyPr_tEdit.Focus();
					this.CompanyPr_tEdit.SelectAll();

					break;
				}
			}
		}
		
		/// <summary>
		/// 画面入力許可制御処理
		/// </summary>
		/// <param name="enabled">入力許可設定値</param>
		/// <remarks>
		/// <br>Note       : 画面の入力許可を制御します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2005.09.12</br>
		/// </remarks>
		void ScreenInputPermissionControl( bool enabled )
		{
			this.CompanyNameCd_tNedit.Enabled		= enabled;	// 自社名称コード
			this.CompanyName1_tEdit.Enabled			= enabled;	// 自社名称１
			this.CompanyName2_tEdit.Enabled			= enabled;	// 自社名称２
			this.PostNo_tEdit.Enabled				= enabled;	// 郵便番号
			this.PostNo_Border_Label.Enabled		= enabled;	// 郵便番号ボーダー隠蔽用ラベル
			this.AddressGuide_Button.Enabled		= enabled;	// 住所ガイドボタン
			this.Address1_tEdit.Enabled				= enabled;	// 住所１
            //this.Address2_tNedit.Enabled			= enabled;	// 住所２  // DEL 2008/06/04
			this.Address3_tEdit.Enabled				= enabled;	// 住所３
			this.Address4_tEdit.Enabled				= enabled;	// 住所４
			this.CompanyTelTitle1_tEdit.Enabled		= enabled;	// 自社電話番号タイトル１
			this.CompanyTelTitle2_tEdit.Enabled		= enabled;	// 自社電話番号タイトル２
			this.CompanyTelTitle3_tEdit.Enabled		= enabled;	// 自社電話番号タイトル３
			this.CompanyTelNo1_tEdit.Enabled		= enabled;	// 自社電話番号１
			this.CompanyTelNo2_tEdit.Enabled		= enabled;	// 自社電話番号２
			this.CompanyTelNo3_tEdit.Enabled		= enabled;	// 自社電話番号３
			this.TransferGuidance_tEdit.Enabled		= enabled;	// 銀行振込案内文
			this.AccountNoInfo1_tEdit.Enabled		= enabled;	// 銀行口座１
			this.AccountNoInfo2_tEdit.Enabled		= enabled;	// 銀行口座２
			this.AccountNoInfo3_tEdit.Enabled		= enabled;	// 銀行口座３
			this.CompanySetNote1_tEdit.Enabled		= enabled;	// 自社設定摘要１
			this.CompanySetNote2_tEdit.Enabled		= enabled;	// 自社設定摘要２
			this.CompanyPr_tEdit.Enabled			= enabled;	// 自社ＰＲ文
            // 2007.05.17  S.Koga  ADD ----------------------------------------
            this.ImageInfoCode_tComboEditor.Enabled = enabled;  // 画像情報コード
            // ----------------------------------------------------------------
			this.CompanyUrl_tEdit.Enabled			= enabled;	// 自社URL文
			this.CompanyPr2_tEdit.Enabled           = enabled;  // 自社PR文２
			this.ImageCommentForPrt1_tEdit.Enabled  = enabled;  // 画像印字用コメント１
			this.ImageCommentForPrt2_tEdit.Enabled  = enabled;  // 画像印字用コメント２
            # region 2007.05.17  S.Koga  DEL
            //this.TakeInImage_GuideButton.Enabled	= enabled;	// 自社画像選択ボタン
            //this.TakeInImageDelete_Button.Enabled	= enabled;	// 自社画像削除ボタン
            # endregion

        }

		/// <summary>
		/// 自社名称クラス画面展開処理
		/// </summary>
		/// <param name="companyNm">自社名称オブジェクト</param>
		/// <remarks>
		/// <br>Note       : 自社名称オブジェクトから画面にデータを展開します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2005.09.12</br>
		/// </remarks>
		private void CompanyNmToScreen( CompanyNm companyNm )
		{
			
			if( companyNm.CompanyNameCd == 0 ) {
				this.CompanyNameCd_tNedit.Clear();									// 自社名称コード
			}
			else {
				this.CompanyNameCd_tNedit.SetInt( companyNm.CompanyNameCd );		// 自社名称コード
			}
			this.CompanyName1_tEdit.DataText		= companyNm.CompanyName1;		// 自社名称１
			this.CompanyName2_tEdit.DataText		= companyNm.CompanyName2;		// 自社名称２
			this.PostNo_tEdit.DataText				= companyNm.PostNo;				// 郵便番号
			this.Address1_tEdit.DataText			= companyNm.Address1;			// 住所１
            // 2007.05.27  S.Koga  amend --------------------------------------
            //this.Address2_tNedit.SetInt( companyNm.Address2 );						// 住所２
            //this.Address2_tNedit.SetInt(0);  // DEL 2008/06/04
            // ----------------------------------------------------------------
			this.Address3_tEdit.DataText			= companyNm.Address3;			// 住所３
			this.Address4_tEdit.DataText			= companyNm.Address4;			// 住所４
			this.CompanyTelTitle1_tEdit.DataText	= companyNm.CompanyTelTitle1;	// 自社電話番号タイトル１
			this.CompanyTelTitle2_tEdit.DataText	= companyNm.CompanyTelTitle2;	// 自社電話番号タイトル２
			this.CompanyTelTitle3_tEdit.DataText	= companyNm.CompanyTelTitle3;	// 自社電話番号タイトル３
			this.CompanyTelNo1_tEdit.DataText		= companyNm.CompanyTelNo1;		// 自社電話番号１
			this.CompanyTelNo2_tEdit.DataText		= companyNm.CompanyTelNo2;		// 自社電話番号２
			this.CompanyTelNo3_tEdit.DataText		= companyNm.CompanyTelNo3;		// 自社電話番号３
			this.TransferGuidance_tEdit.DataText	= companyNm.TransferGuidance;	// 銀行振込案内文
			this.AccountNoInfo1_tEdit.DataText		= companyNm.AccountNoInfo1;		// 銀行口座１
			this.AccountNoInfo2_tEdit.DataText		= companyNm.AccountNoInfo2;		// 銀行口座２
			this.AccountNoInfo3_tEdit.DataText		= companyNm.AccountNoInfo3;		// 銀行口座３
			this.CompanySetNote1_tEdit.DataText		= companyNm.CompanySetNote1;	// 自社設定摘要１
			this.CompanySetNote2_tEdit.DataText		= companyNm.CompanySetNote2;	// 自社設定摘要２
			this.CompanyPr_tEdit.DataText			= companyNm.CompanyPr;			// 自社ＰＲ文
            // 2007.05.17  S.Koga  ADD ----------------------------------------
            this.ImageInfoCode_tComboEditor.Value = (object)companyNm.ImageInfoCode;   // 画像情報コード
            // ----------------------------------------------------------------
			this.CompanyUrl_tEdit.DataText			= companyNm.CompanyUrl;			// 自社URL文
			this.CompanyPr2_tEdit.DataText          = companyNm.CompanyPrSentence2;  // 自社PR文２
			this.ImageCommentForPrt1_tEdit.DataText = companyNm.ImageCommentForPrt1;  // 画像印字用コメント１
			this.ImageCommentForPrt2_tEdit.DataText = companyNm.ImageCommentForPrt2;  // 画像印字用コメント２
		}

		/// <summary>
		/// 自社名称クラス格納処理
		/// </summary>
		/// <param name="companyNm">自社名称オブジェクト</param>
		/// <remarks>
		/// <br>Note       : 画面情報から自社名称オブジェクトにデータを格納します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2005.09.12</br>
		/// </remarks>
		private void DispToCompanyNm( ref CompanyNm companyNm )
		{
			if( companyNm == null ) {
				companyNm = new CompanyNm();
			}

			companyNm.EnterpriseCode	= this._enterpriseCode;					// 企業コード
			companyNm.CompanyNameCd		= this.CompanyNameCd_tNedit.GetInt();	// 自社名称コード
			companyNm.CompanyName1		= this.CompanyName1_tEdit.DataText;		// 自社名称１
			companyNm.CompanyName2		= this.CompanyName2_tEdit.DataText;		// 自社名称２
			companyNm.PostNo			= this.PostNo_tEdit.DataText;			// 郵便番号
			companyNm.Address1			= this.Address1_tEdit.DataText;			// 住所１
            //companyNm.Address2			= this.Address2_tNedit.GetInt();		// 住所２  // DEL 2008/06/04
			companyNm.Address3			= this.Address3_tEdit.DataText;			// 住所３
			companyNm.Address4			= this.Address4_tEdit.DataText;			// 住所４
			companyNm.CompanyTelTitle1	= this.CompanyTelTitle1_tEdit.DataText;	// 自社電話番号タイトル１
			companyNm.CompanyTelTitle2	= this.CompanyTelTitle2_tEdit.DataText;	// 自社電話番号タイトル２
			companyNm.CompanyTelTitle3	= this.CompanyTelTitle3_tEdit.DataText;	// 自社電話番号タイトル３
			companyNm.CompanyTelNo1		= this.CompanyTelNo1_tEdit.DataText;	// 自社電話番号１
			companyNm.CompanyTelNo2		= this.CompanyTelNo2_tEdit.DataText;	// 自社電話番号２
			companyNm.CompanyTelNo3		= this.CompanyTelNo3_tEdit.DataText;	// 自社電話番号３
			companyNm.TransferGuidance	= this.TransferGuidance_tEdit.DataText;	// 銀行振込案内文
			companyNm.AccountNoInfo1	= this.AccountNoInfo1_tEdit.DataText;	// 銀行口座１
			companyNm.AccountNoInfo2	= this.AccountNoInfo2_tEdit.DataText;	// 銀行口座２
			companyNm.AccountNoInfo3	= this.AccountNoInfo3_tEdit.DataText;	// 銀行口座３
			companyNm.CompanySetNote1	= this.CompanySetNote1_tEdit.DataText;	// 自社設定摘要１
			companyNm.CompanySetNote2	= this.CompanySetNote2_tEdit.DataText;	// 自社設定摘要２
			companyNm.CompanyPr			= this.CompanyPr_tEdit.DataText;		// 自社ＰＲ文
            // 2007.05.17  S.Koga  ADD ----------------------------------------
            companyNm.ImageInfoDiv      = IMAGEINFODIV_DATA;                    // 画像情報区分
            if(this.ImageInfoCode_tComboEditor.SelectedItem != null)
                companyNm.ImageInfoCode     = (int)this.ImageInfoCode_tComboEditor.SelectedItem.DataValue;   // 画像情報コード
            // ----------------------------------------------------------------
			companyNm.CompanyUrl		= this.CompanyUrl_tEdit.DataText;		// 自社URL文
			companyNm.CompanyPrSentence2 = this.CompanyPr2_tEdit.DataText;  // 自社PR文２
			companyNm.ImageCommentForPrt1 = this.ImageCommentForPrt1_tEdit.DataText;  // 画像印字用コメント１
			companyNm.ImageCommentForPrt2 = this.ImageCommentForPrt2_tEdit.DataText;  // 画像印字用コメント２

            # region 2007.05.17  S.Koga  DEL
            //if ( companyNm.TakeInImageGroupCd == Guid.Empty ) 
            //{
            //    if( this.TakeInImage_UltraPictureBox.Image != null ) {
            //        companyNm.TakeInImageGroupCd = Guid.NewGuid();
            //    }
            //}
            //else {
            //    if( this.TakeInImage_UltraPictureBox.Image == null ) {
            //        companyNm.TakeInImageGroupCd = Guid.Empty;
            //    }
            //}
            # endregion
        }

        # region 2007.05.17  S.Koga  DEL
        ///// <summary>
        ///// 取込画像表示処理
        ///// </summary>
        ///// <param name="companyNm">自社名称オブジェクト</param>
        ///// <remarks>
        ///// <br>Note       : 取込画像を取得して表示を行います。（実際の表示処理は画像データ受信完了イベントの中で行われます。）</br>
        ///// <br>Programmer : 23001 秋山　亮介</br>
        ///// <br>Date       : 2005.10.11</br>
        ///// </remarks>
        //private void TakeInImageToScreen( CompanyNm companyNm )
        //{
        //    if( this._dataIndex < 0 ) {
        //        companyNm.TakeInImageGroupCd = Guid.Empty;
        //    }
        //    else {
        //        if( companyNm.TakeInImageGroupCd != Guid.Empty ) {
        //            int status = ReadImageData( this._enterpriseCode, companyNm.TakeInImageGroupCd );
        //            if( status != 0 ) {
        //                companyNm.TakeInImageGroupCd = Guid.Empty;
        //            }
        //        }
        //    }
        //}
        # endregion

        /// <summary>
		/// 自社名称保存処理
		/// </summary>
		/// <returns>結果</returns>
		/// <remarks>
		/// <br>Note       : 自社名称の保存を行います。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2005.09.12</br>
		/// </remarks>
		private bool SaveProc()
		{
			bool result = false;

			// 入力チェック
			Control control = null;
			string message = null;
			if( !ScreenDataCheck( ref control, ref message ) ) {
				// 入力チェック
				TMsgDisp.Show( 
					this, 								// 親ウィンドウフォーム
					emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
					"SFUKN09020U", 						// アセンブリＩＤまたはクラスＩＤ
					message, 							// 表示するメッセージ
					0, 									// ステータス値
					MessageBoxButtons.OK );				// 表示するボタン
				control.Focus();
				if( control is TNedit ) {
					( ( TNedit )control ).SelectAll();
				}
				else if( control is TEdit ) {
					( ( TEdit )control ).SelectAll();
				}
				return result;
			}

			CompanyNm companyNm = null;
			if( this._dataIndex >= 0 ) {
				Guid guid = ( Guid )this.Bind_DataSet.Tables[ COMPANYNM_TABLE ].Rows[ this._dataIndex ][ GUID_TITLE ];
///////////////////////////////////////////////////////////////////// 2005.11.01 AKIYAMA ADD STA //
				// 品管障害対応 (管理No.000273-01)
				companyNm = ( ( CompanyNm )this._companyNmTable[ guid ] ).Clone();
// 2005.11.01 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////// 2005.11.01 AKIYAMA DEL STA //
//				companyNm = ( CompanyNm )this._companyNmTable[ guid ];
// 2005.11.01 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////
			}
			DispToCompanyNm( ref companyNm );

			int status = this._companyNmAcs.Write( ref companyNm );
			switch( status ) {
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                {
                    # region 2007.05.17  S.Koga  DEL
                        // 画像管理マスタへ保存
                    //if( companyNm.TakeInImageGroupCd != Guid.Empty ) {
                    //    if( this._changeTakeInImage == true ) {
                    //        status = SaveImageData( this._enterpriseCode, companyNm.TakeInImageGroupCd );
                    //    }
                    //}
					// 画像管理マスタから削除
//                    else {
//                        if( this._imageGroup != null ) {
//// 2006.08.18 AKIYAMA ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//                            this._SFUKN09020UB.Delete( this._imageGroup );
//// 2006.08.18 AKIYAMA ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
//// 2006.08.18 AKIYAMA DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
////							this._imageImgAcs.Delete( this._imageGroup );
//// 2006.08.18 AKIYAMA DEL <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
//                        }
//                    }
                        # endregion
                    // VIEWのデータセットを更新
					CompanyNmToDataSet( companyNm.Clone(), this._dataIndex );
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
				{
					// コード重複
					TMsgDisp.Show( 
						this, 									// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_INFO, 			// エラーレベル
						"SFUKN09020U", 							// アセンブリＩＤまたはクラスＩＤ
						"このコードは既に使用されています。", 	// 表示するメッセージ
						0, 										// ステータス値
						MessageBoxButtons.OK );					// 表示するボタン
					this.CompanyNameCd_tNedit.Focus();
					this.CompanyNameCd_tNedit.SelectAll();
					return result;
				}
				// 排他制御
				case ( int )ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case ( int )ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					ExclusiveTransaction( status, true );
					return result;
				}
				default:
				{
					// 登録失敗
					TMsgDisp.Show( 
						this, 								// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
						"SFUKN09020U", 						// アセンブリＩＤまたはクラスＩＤ
						"自社名称設定", 					// プログラム名称
						"SaveProc", 						// 処理名称
						TMsgDisp.OPE_UPDATE, 				// オペレーション
						"登録に失敗しました。", 			// 表示するメッセージ
						status, 							// ステータス値
						this._companyNmAcs, 				// エラーが発生したオブジェクト
						MessageBoxButtons.OK, 				// 表示するボタン
						MessageBoxDefaultButton.Button1 );	// 初期表示ボタン
					CloseForm( DialogResult.Cancel );
					return result;
				}
			}

			result = true;
			return result;
		}

        /// <summary>
		/// 画面入力情報不正チェック処理
		/// </summary>
		/// <param name="control">不正対象コントロール</param>
		/// <param name="message">メッセージ</param>
		/// <returns>チェック結果(true:OK／false:NG)</returns>
		/// <remarks>
		/// <br>Note       : 画面入力の不正チェックを行います。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2005.09.12</br>
		/// </remarks>
		private bool ScreenDataCheck( ref Control control, ref string message )
		{
			bool result = true;

			// 自社名称コード
			if( this.CompanyNameCd_tNedit.GetInt() == 0 ) {
				message = this.CompanyNameCd_Title_Label.Text + "を入力してください。";
				control = this.CompanyNameCd_tNedit;
				result = false;
			}
			// 自社名称
			else if( this.CompanyName1_tEdit.DataText.TrimEnd() == "" ) {
				message = this.CompanyName1_Title_Label.Text + "を入力してください。";
				control = this.CompanyName1_tEdit;
				result = false;
			}

			return result;
		}

		/// <summary>
		/// 自社名称オブジェクト論理削除処理
		/// </summary>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 自社名称オブジェクトの論理削除を行います。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2005.09.12</br>
		/// </remarks>
		private int LogicalDelete()
		{
			int status = 0;

			if( ( this._dataIndex < 0 ) || 
				( this._dataIndex >= this.Bind_DataSet.Tables[ COMPANYNM_TABLE ].Rows.Count  ) ) {
				return -1;
			}

			// 情報取得
			Guid guid = ( Guid )this.Bind_DataSet.Tables[ COMPANYNM_TABLE ].Rows[ this._dataIndex ][ GUID_TITLE ];
			CompanyNm companyNm = ( ( CompanyNm )this._companyNmTable[ guid ] ).Clone();

			// 自社名称が存在していない
			if( companyNm == null ) {
				return -1;
			}

			status = this._companyNmAcs.LogicalDelete( ref companyNm );
			switch( status ) {
				case ( int )ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					CompanyNmToDataSet( companyNm.Clone(), this._dataIndex );
					break;
				}
				// 排他制御
				case ( int )ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case ( int )ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					ExclusiveTransaction( status, false );
					return status;
				}
///////////////////////////////////////////////////////////////////// 2005.12.09 AKIYAMA ADD STA //
				// 拠点設定で使用中
				case -2:
				{
					TMsgDisp.Show( 
						this, 									// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_EXCLAMATION,		// エラーレベル
						"SFUKN09020U", 							// アセンブリＩＤまたはクラスＩＤ
						// 表示するメッセージ
						"このレコードは拠点設定で使用されているため削除できません。", 
						status, 								// ステータス値
						MessageBoxButtons.OK );					// 表示するボタン
					return status;
				}
// 2005.12.09 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////
				default:
				{
						// 論理削除
						TMsgDisp.Show( 
							this, 								// 親ウィンドウフォーム
							emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
							"SFUKN09020U", 						// アセンブリＩＤまたはクラスＩＤ
							"自社名称設定", 					// プログラム名称
							"LogicalDelete", 					// 処理名称
							TMsgDisp.OPE_HIDE, 					// オペレーション
							"削除に失敗しました。", 			// 表示するメッセージ
							status, 							// ステータス値
							this._companyNmAcs, 				// エラーが発生したオブジェクト
							MessageBoxButtons.OK, 				// 表示するボタン
							MessageBoxDefaultButton.Button1 );	// 初期表示ボタン

					return status;
				}
			}
			return status;
		}

		/// <summary>
		/// 自社名称オブジェクト論理削除復活処理
		/// </summary>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 自社名称オブジェクトの論理削除復活を行います。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2005.09.12</br>
		/// </remarks>
		private int Revival()
		{
			int status = 0;

			if( ( this._dataIndex < 0 ) || 
				( this._dataIndex >= this.Bind_DataSet.Tables[ COMPANYNM_TABLE ].Rows.Count  ) ) {
				return -1;
			}

			// 情報取得
			Guid guid = ( Guid )this.Bind_DataSet.Tables[ COMPANYNM_TABLE ].Rows[ this._dataIndex ][ GUID_TITLE ];
			CompanyNm companyNm = ( ( CompanyNm )this._companyNmTable[ guid ] ).Clone();

			// 自社名称が存在していない
			if( companyNm == null ) {
				return -1;
			}

			status = this._companyNmAcs.Revival( ref companyNm );
			switch( status ) {
				case ( int )ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					CompanyNmToDataSet( companyNm.Clone(), this._dataIndex );
					break;
				}
				// 排他制御
				case ( int )ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case ( int )ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					ExclusiveTransaction( status, true );
					return status;
				}
				default:
				{
					// 復活失敗
					TMsgDisp.Show( 
						this, 								// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
						"SFUKN09020U", 						// アセンブリＩＤまたはクラスＩＤ
						"自社名称設定", 					// プログラム名称
						"Revival", 							// 処理名称
						TMsgDisp.OPE_UPDATE, 				// オペレーション
						"復活に失敗しました。", 			// 表示するメッセージ
						status, 							// ステータス値
						this._companyNmAcs, 				// エラーが発生したオブジェクト
						MessageBoxButtons.OK, 				// 表示するボタン
						MessageBoxDefaultButton.Button1 );	// 初期表示ボタン
					CloseForm( DialogResult.Cancel );
					return status;
				}
			}
			return status;
		}

		/// <summary>
		/// 自社名称オブジェクト完全削除処理
		/// </summary>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : 自社名称オブジェクトの完全削除を行います。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2005.09.12</br>
		/// </remarks>
		private int PhysicalDelete()
		{
			int status = 0;

			if( ( this._dataIndex < 0 ) || 
				( this._dataIndex >= this.Bind_DataSet.Tables[ COMPANYNM_TABLE ].Rows.Count  ) ) {
				return -1;
			}

			// 情報取得
			Guid guid = ( Guid )this.Bind_DataSet.Tables[ COMPANYNM_TABLE ].Rows[ this._dataIndex ][ GUID_TITLE ];
			CompanyNm companyNm = ( CompanyNm )this._companyNmTable[ guid ];

			// 自社名称が存在していない
			if( companyNm == null ) {
				return -1;
			}

			status = this._companyNmAcs.Delete( companyNm );
			switch( status ) {
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                {
                    # region 2007.05.17  S.Koga  DEL
                        // 画像管理マスタから削除
                    //if( ( companyNm.TakeInImageGroupCd != Guid.Empty ) && ( this._imageGroup != null ) ) {
// 2006.08.18 AKIYAMA ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
                        //this._SFUKN09020UB.Delete( this._imageGroup );
// 2006.08.18 AKIYAMA ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
// 2006.08.18 AKIYAMA DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//						this._imageImgAcs.Delete( this._imageGroup );
// 2006.08.18 AKIYAMA DEL <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
                    //}
                        # endregion
                    // ハッシュテーブルからデータを削除
					this._companyNmTable.Remove( ( Guid )this.Bind_DataSet.Tables[ COMPANYNM_TABLE ].Rows[ this._dataIndex][ GUID_TITLE ] );
					// データセットからデータを削除
					this.Bind_DataSet.Tables[ COMPANYNM_TABLE ].Rows[ this._dataIndex].Delete();
					break;
				}
				// 排他制御
				case ( int )ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case ( int )ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					ExclusiveTransaction( status, true );
					return status;
				}
				default:
				{
					// 物理削除
					TMsgDisp.Show( 
						this, 								// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
						"SFUKN09020U", 						// アセンブリＩＤまたはクラスＩＤ
						"自社名称設定", 					// プログラム名称
						"PhysicalDelete", 					// 処理名称
						TMsgDisp.OPE_DELETE, 				// オペレーション
						"削除に失敗しました。", 			// 表示するメッセージ
						status, 							// ステータス値
						this._companyNmAcs, 				// エラーが発生したオブジェクト
						MessageBoxButtons.OK, 				// 表示するボタン
						MessageBoxDefaultButton.Button1 );	// 初期表示ボタン
					CloseForm( DialogResult.Cancel );
					return status;
				}
			}
			return status;
		}

		/// <summary>
		/// 排他処理
		/// </summary>
		/// <param name="status">STATUS</param>
		/// <param name="hide">非表示フラグ(true: 非表示にする, false: 非表示にしない)</param>
		/// <remarks>
		/// <br>Note       : 排他処理を行います</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2005.09.12</br>
		/// </remarks>
		private void ExclusiveTransaction( int status, bool hide )
		{
			switch( status ) {
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				{
					// 他端末更新
					TMsgDisp.Show( 
						this, 								// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
						"SFUKN09020U", 						// アセンブリＩＤまたはクラスＩＤ
						"既に他端末より更新されています。", // 表示するメッセージ
						0, 									// ステータス値
						MessageBoxButtons.OK );				// 表示するボタン
					if( hide == true ) {
						CloseForm( DialogResult.Cancel );
					}
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					// 他端末削除
					TMsgDisp.Show( 
						this, 								// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
						"SFUKN09020U", 						// アセンブリＩＤまたはクラスＩＤ
						"既に他端末より削除されています。", // 表示するメッセージ
						0, 									// ステータス値
						MessageBoxButtons.OK );				// 表示するボタン
					if( hide == true ) {
						CloseForm( DialogResult.Cancel );
					}
					break;
				}
			}
		}

		/// <summary>
		/// フォームクローズ処理）
		/// </summary>
		/// <param name="dialogResult">ダイアログ結果</param>
		/// <remarks>
		/// <br>Note       : フォームを閉じます。その際画面クローズイベント等の発生を行います。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2005.09.12</br>
		/// </remarks>
		private void CloseForm( DialogResult dialogResult )
		{
			// 画面非表示イベント
			if ( UnDisplaying != null ) {
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs( dialogResult );
				UnDisplaying( this, me );
			}

			this.DialogResult = dialogResult;

			// _GridIndexバッファ初期化（メインフレーム最小化対応）
			this._indexBuf = -2;
			
			// CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルして
			// フォームを非表示化する。
			if( this._canClose == true ) {
				this.Close();
			}
			else {
				this.Hide();
			}
		}

		/// <summary>
		/// 郵便番号変更処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 郵便番号にあわせて表示されている住所１の変更を行います。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2005.09.12</br>
		/// </remarks>
		private void PostNoChange()
		{
			AddressGuide addressGuide			= new AddressGuide();
			AddressGuideResult addrGuideResult	= null;
			string postNo = this.PostNo_tEdit.DataText.TrimEnd();

			// 住所マスタ読込み
			DialogResult result = addressGuide.ShowPostNoSearchGuide( postNo, out addrGuideResult );
			if( ( result == DialogResult.OK ) && 
				( addrGuideResult.PostNo != "" ) && 
				( addrGuideResult.AddressName != "" ) ) {
				// 郵便番号
				this.PostNo_tEdit.DataText		= addrGuideResult.PostNo;

// 2006.05.19 AKIYAMA ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
				// 住所１
				this.SetAddress1( addrGuideResult.AddressName );
// 2006.05.19 AKIYAMA ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
// 2006.05.19 AKIYAMA DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//				this.Address1_tEdit.DataText	= addrGuideResult.AddressName;
// 2006.05.19 AKIYAMA DEL <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
			}
		}

// 2006.05.19 AKIYAMA ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
		/// <summary>
		/// 住所１格納処理
		/// </summary>
		/// <param name="address1">格納対象住所１</param>
		/// <remarks>
		/// <br>Note       : 住所１を画面に表示します。文字数が長い時は分割して、住所３に格納します。</br>
		/// </remarks>
		private void SetAddress1( string address1 )
		{
			// 住所１の文字数が30を超える時は、分割して住所３へ格納
			if( address1.Length > 30 ) {
				string wkAddress3 = "";

				// 住所１(先頭から30文字までを格納)
				this.Address1_tEdit.DataText     = address1.Substring( 0, 30 );
				// 住所３(31文字目から末尾まで)
				wkAddress3                       = address1.Substring( 30, address1.Length - 30 );

				// 住所３にも入りきらない場合(住所３が22文字を超える場合)
				if( wkAddress3.Length > 22 ) {
					// 住所３(先頭から22文字までを格納)
					this.Address3_tEdit.DataText = wkAddress3.Substring( 0, 22 );
					// 住所４(23文字目から30文字分。)
					this.Address3_tEdit.DataText = wkAddress3.Substring( 22, Math.Min( wkAddress3.Length - 22, 30 ) );
				}
				else {
					// 住所３
					this.Address3_tEdit.DataText = wkAddress3;
				}
			}
			else {
				// 住所１
				this.Address1_tEdit.DataText     = address1;
			}
		}
// 2006.05.19 AKIYAMA ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
		#endregion

		#region Control Events
		/// <summary>
		/// Form.Load イベント(SFUKN09020UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : ユーザがフォームを読み込むときに発生します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2005.09.12</br>
		/// </remarks>
		private void SFUKN09020UA_Load(object sender, System.EventArgs e)
		{
			// アイコンリソース管理クラスを使用して、アイコンを表示する
			ImageList imageList24 = IconResourceManagement.ImageList24;
			ImageList imageList16 = IconResourceManagement.ImageList16;

            this.Ok_Button.ImageList = imageList24;
            this.Renewal_Button.ImageList = imageList16;
			this.Cancel_Button.ImageList						= imageList24;
			this.Revive_Button.ImageList						= imageList24;
			this.Delete_Button.ImageList						= imageList24;
			this.AddressGuide_Button.ImageList					= imageList16;
            # region 2007.05.17  S.Koga  DEL
            //this.TakeInImage_GuideButton.ImageList				= imageList16;
            # endregion

            this.Ok_Button.Appearance.Image = Size24_Index.SAVE;	// 保存ボタン
            this.Renewal_Button.Appearance.Image = Size16_Index.RENEWAL;	// 最新情報ボタン
			this.Cancel_Button.Appearance.Image					= Size24_Index.CLOSE;	// 閉じるボタン
			this.Revive_Button.Appearance.Image					= Size24_Index.REVIVAL;	// 復活ボタン
			this.Delete_Button.Appearance.Image					= Size24_Index.DELETE;	// 完全削除ボタン
			this.AddressGuide_Button.Appearance.Image			= Size16_Index.STAR1;	// 住所ガイドボタン
            # region 2007.05.17  S.Koga  DEL
            //this.TakeInImage_GuideButton.Appearance.Image		= Size16_Index.STAR1;	// 自社画像ガイドボタン
            # endregion

            // 画面を構築
			ScreenInitialSetting();
		}

		/// <summary>
		/// Form.Closing イベント(SFUKN09020UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">キャンセルできるイベントのデータを提供するクラス</param>
		/// <remarks>
		/// <br>Note       : フォームを閉じる前に、ユーザーがフォームを閉じようとしたときに発生します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2005.09.12</br>
		/// </remarks>
		private void SFUKN09020UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			// _GridIndexバッファ初期化（メインフレーム最小化対応）
			this._indexBuf = -2;

			if( this._canClose == false ) {
				e.Cancel = true;
				this.Hide();
				return;
			}
		}

		/// <summary>
		/// Form.VisibleChanged イベント(SFUKN09020UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : フォームの表示状態が変わったときに発生します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2005.09.12</br>
		/// </remarks>
		private void SFUKN09020UA_VisibleChanged(object sender, System.EventArgs e)
		{
			if( this.Visible == false ) {
///////////////////////////////////////////////////////////////////// 2005.10.19 AKIYAMA ADD STA //
				this.Owner.Activate();
// 2005.10.19 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////
				return;
			}

			// _GridIndexバッファ（メインフレーム最小化対応）
			// ターゲットレコード(Index)が変わっていなかった場合以下の処理をキャンセルする
			if( this._indexBuf == this._dataIndex ) {
				return;
			}

			this.Initial_Timer.Enabled = true;
			ScreenClear();
		}

		/// <summary>
		/// Timer.Tick イベント(Initial_Timer)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note        : 指定された間隔の時間が経過したときに発生します。
		///                   この処理は、システムが提供するスレッド プール
		///	                  スレッドで実行されます。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2005.09.12</br>
		/// </remarks>
		private void Initial_Timer_Tick(object sender, System.EventArgs e)
		{
			this.Initial_Timer.Enabled = false;
		
			ScreenReconstruction();
		}

		/// <summary>
		/// Control.Click イベント(Ok_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : 保存ボタンコントロールがクリックされたときに発生します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2005.09.12</br>
		/// </remarks>
		private void Ok_Button_Click(object sender, System.EventArgs e)
		{
			if( !SaveProc() ) {			// 登録
				return;
			}

			if( UnDisplaying != null ) {
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs( DialogResult.OK );
				UnDisplaying( this, me );
			}

			// 新規モードの場合は画面を終了せずに連続入力を可能とする
			if ( this.Mode_Label.Text == INSERT_MODE )
			{
				ScreenClear();

				// 新規モード
				this._logicalDeleteMode = -1;

				CompanyNm newCompanyNm		= new CompanyNm();
				// 自社名称オブジェクトを画面に展開
				CompanyNmToScreen( newCompanyNm );

                # region 2007.05.17  S.Koga  DEL
                //TakeInImageToScreen( newCompanyNm );
                # endregion

                // クローン作成
				this._companyNmClone = newCompanyNm.Clone();
				DispToCompanyNm( ref this._companyNmClone );

				// _GridIndexバッファ保持
				this._indexBuf = this._dataIndex;

				ScreenInputPermissionControl();
			}
			else {
				this.DialogResult = DialogResult.OK;

				// _GridIndexバッファ初期化（メインフレーム最小化対応）
				this._indexBuf = -2;

				if( this._canClose == true ) {
					this.Close();
				}
				else {
					this.Hide();
				}
			}
		}

		/// <summary>
		/// Control.Click イベント(Cancel_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : 閉じるボタンコントロールがクリックされたときに発生します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2005.09.12</br>
		/// </remarks>
		private void Cancel_Button_Click(object sender, System.EventArgs e)
		{
			// 削除モード・参照モード以外の場合は保存確認処理を行う
			if( this.Mode_Label.Text != DELETE_MODE ) {
				// 現在の画面情報を取得する
				CompanyNm compareCompanyNm = new CompanyNm();
				compareCompanyNm = this._companyNmClone.Clone();
				DispToCompanyNm( ref compareCompanyNm );

				// 最初に取得した画面情報と比較
				if( !( this._companyNmClone.Equals( compareCompanyNm ) ) || ( this._changeTakeInImage == true ) ) {
					// 画面情報が変更されていた場合は、保存確認メッセージを表示する
					// 保存確認
					DialogResult res = TMsgDisp.Show( 
						this, 								// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_SAVECONFIRM, // エラーレベル
						"SFUKN09020U", 						// アセンブリＩＤまたはクラスＩＤ
						null, 								// 表示するメッセージ
						0, 									// ステータス値
						MessageBoxButtons.YesNoCancel );	// 表示するボタン
					switch( res ) {
						case DialogResult.Yes:
						{
							if ( !SaveProc() ) {
								return;
							}
							break;
						}
						case DialogResult.No:
						{
							break;
						}
						default:
						{
							// 2009.03.23 30413 犬飼 新規モードからモード変更対応 >>>>>>START
                            //this.Cancel_Button.Focus();
                            if (_modeFlg)
                            {
                                CompanyNameCd_tNedit.Focus();
                                _modeFlg = false;
                            }
                            else
                            {
                                this.Cancel_Button.Focus();
                            }
                            // 2009.03.23 30413 犬飼 新規モードからモード変更対応 <<<<<<END
							return;
						}
					}
				}
			}

			if ( UnDisplaying != null ) {
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs( DialogResult.Cancel );
				UnDisplaying( this, me );
			}

			this.DialogResult = DialogResult.Cancel;

			// _GridIndexバッファ初期化（メインフレーム最小化対応）
			this._indexBuf = -2;

			if ( this._canClose ) {
				this.Close();
			}
			else {
				this.Hide();
			}
		}

		/// <summary>
		/// Control.Click イベント(Revive_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : 復活ボタンコントロールがクリックされたときに発生します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2005.09.12</br>
		/// </remarks>
		private void Revive_Button_Click(object sender, System.EventArgs e)
		{
			if( Revival() != 0 ) {
				return;
			}

			if( UnDisplaying != null ) {
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs( DialogResult.OK );
				UnDisplaying( this, me );
			}

			this.DialogResult = DialogResult.OK;

			// _GridIndexバッファ初期化（メインフレーム最小化対応）
			this._indexBuf = -2;

			if( this._canClose == true ) {
				this.Close();
			}
			else {
				this.Hide();
			}
		}

		/// <summary>
		/// Control.Click イベント(Delete_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : 完全削除ボタンコントロールがクリックされたときに発生します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2005.09.12</br>
		/// </remarks>
		private void Delete_Button_Click(object sender, System.EventArgs e)
		{
			// 完全削除確認
			DialogResult result = TMsgDisp.Show( 
				this, 								// 親ウィンドウフォーム
				emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
				"SFUKN09020U", 						// アセンブリＩＤまたはクラスＩＤ
				"データを削除します。" + "\r\n" + 
				"よろしいですか？", 				// 表示するメッセージ
				0, 									// ステータス値
				MessageBoxButtons.OKCancel, 		// 表示するボタン
				MessageBoxDefaultButton.Button2 );	// 初期表示ボタン

			if( result == DialogResult.OK ) {
				if( PhysicalDelete() != 0 ) {
					return;
				}
            }
            else
            {
				this.Delete_Button.Focus();
                return;
            }

			if( UnDisplaying != null ) {
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs( DialogResult.OK );
				UnDisplaying( this, me );
			}

            this.DialogResult = DialogResult.OK;

			// _GridIndexバッファ初期化（メインフレーム最小化対応）
			this._indexBuf = -2;

			if( this._canClose == true ) {
				this.Close();
			}
			else {
				this.Hide();
			}
		}

		/// <summary>
		/// Control.Click イベント(AddressGuide_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : 住所ガイドボタンコントロールがクリックされたときに発生します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2005.09.12</br>
		/// </remarks>
		private void AddressGuide_Button_Click(object sender, System.EventArgs e)
		{
			AddressGuide addressGuide			= new AddressGuide();
			AddressGuideResult addrGuideResult	= null;
			DialogResult result = addressGuide.ShowAddressGuide( out addrGuideResult );

			if( ( result == DialogResult.OK ) && 
				( addrGuideResult.AddressName != "" ) ) {
// 2006.05.19 AKIYAMA ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
				// 住所１
				this.SetAddress1( addrGuideResult.AddressName );
// 2006.05.19 AKIYAMA ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
// 2006.05.19 AKIYAMA DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//				this.Address1_tEdit.DataText	= addrGuideResult.AddressName;
// 2006.05.19 AKIYAMA DEL <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

				this.PostNo_tEdit.DataText		= addrGuideResult.PostNo;
///////////////////////////////////////////////////////////////////// 2005.10.18 AKIYAMA ADD STA //
				// 拠点選択時はフォーカスを次へ移動
				this.SelectNextControl( ( Control )sender, true, true, true, true );
// 2005.10.18 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////
			}
			else {
///////////////////////////////////////////////////////////////////// 2005.10.18 AKIYAMA ADD STA //
				( ( Control )sender ).Focus();
// 2005.10.18 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////
			}
		}

		/// <summary>
		/// Control.Enter イベント(PostNo_tEdit)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : コントロールがフォーカスを得たときに発生します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2005.09.12</br>
		/// </remarks>
		private void PostNo_tEdit_Enter(object sender, System.EventArgs e)
		{
			this._changeFlg = false;
		}

		/// <summary>
		/// Control.KeyDown イベント(PostNo_tEdit)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : コントロールでキーが押されたときに発生します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2005.09.12</br>
		/// </remarks>
		private void PostNo_tEdit_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
///////////////////////////////////////////////////////////////////// 2006.01.10 AKIYAMA DEL STA //
//			if( ( e.ToString() != "" ) && 
//				( e.KeyValue != 37 ) && 	// 「←」キー
//				( e.KeyValue != 39 ) ) {	// 「→」キー
//				this._changeFlg = true;
//			}					
// 2006.01.10 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////
		}

///////////////////////////////////////////////////////////////////// 2006.01.10 AKIYAMA ADD STA //
		/// <summary>
		/// TEdit.ValueChanged イベント(PostNo_tEdit)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : 値が変更されたときに発生します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2005.09.12</br>
		/// </remarks>
		private void PostNo_tEdit_ValueChanged(object sender, System.EventArgs e)
		{
			if( this.PostNo_tEdit.Modified == true ) {
				this._changeFlg = true;
			}
		}
// 2006.01.10 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////

		/// <summary>
		/// Control.Leave イベント(PostNo_tEdit)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : コントロールがフォーカスを失ったときに発生します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2005.09.12</br>
		/// </remarks>
		private void PostNo_tEdit_Leave(object sender, System.EventArgs e)
		{
			if( this._changeFlg == true ) {
				PostNoChange();
			}
        }

        // --- ADD 2008/06/04 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// tArrowKeyControlChangeFocusイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: コントロールのフォーカスが変わるタイミングで発生します。</br>
        /// <br>Programmer	: 30414　忍　幸史</br>
        /// <br>Date		: 2008/06/04</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            // 2009.03.23 30413 犬飼 新規モードからモード変更対応 >>>>>>START
            _modeFlg = false;
            // 2009.03.23 30413 犬飼 新規モードからモード変更対応 <<<<<<END

            switch (e.PrevCtrl.Name)
            {
                case "CompanyNameCd_tNedit":    // 2009.03.23 新規モードからモード変更対応
                    {
                        // 自社名称コード
                        if (e.NextCtrl.Name == "Cancel_Button")
                        {
                            // 遷移先が閉じるボタン
                            _modeFlg = true;
                        }
                        else if (this._dataIndex < 0)
                        {
                            if (ModeChangeProc())
                            {
                                e.NextCtrl = CompanyNameCd_tNedit;
                            }
                        }
                        break;
                    }
                case "Address4_tEdit":
                    // 住所４にフォーカスがある場合
                    if (e.Key == Keys.Down)
                    {
                        // 電話番号１タイトルにフォーカスを移します
                        e.NextCtrl = CompanyTelTitle1_tEdit;
                    }
                    break;
                case "Cancel_Button":
                    // 閉じるボタンにフォーカスがある場合
                    if (e.Key == Keys.Up)
                    {
                        // 画像印字用コメントにフォーカスを移します
                        e.NextCtrl = ImageCommentForPrt2_tEdit;
                    }
                    break;
                default:
                    break;
            }
        }

        private void Renewal_Button_Click(object sender, EventArgs e)
        {
            ImageInfoCode_tComboEditor.Items.Clear();
            GetImageInfoCode(IMAGEINFODIV_DATA);

            TMsgDisp.Show(this, 								// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          "SFUKN09020U",						    // アセンブリＩＤまたはクラスＩＤ
                          "最新情報を取得しました。", 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
        }
        // --- ADD 2008/06/04 ---------------------------------------------------------------------<<<<<

        // 2009.03.23 30413 犬飼 新規モードからモード変更対応 >>>>>>START
        /// <summary>
        /// モード変更処理
        /// </summary>
        private bool ModeChangeProc()
        {
            // 自社名称コード
            int compCd = CompanyNameCd_tNedit.GetInt();

            for (int i = 0; i < this.Bind_DataSet.Tables[COMPANYNM_TABLE].Rows.Count; i++)
            {
                // データセットと比較
                int dsCompCd = (int)this.Bind_DataSet.Tables[COMPANYNM_TABLE].Rows[i][COMPANYNAMECD_TITLE];
                if (compCd == dsCompCd)
                {
                    // 入力コードがデータセットに存在する場合
                    if ((string)this.Bind_DataSet.Tables[COMPANYNM_TABLE].Rows[i][DELETE_DATE] != "")
                    {
                        // 論理削除
                        TMsgDisp.Show(this, 					// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          "SFUKN09020U",						// アセンブリＩＤまたはクラスＩＤ
                          "入力されたコードの自社名称設定情報は既に削除されています。", 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
                        // 自社名称コードのクリア
                        CompanyNameCd_tNedit.Clear();
                        return true;
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_INFO,            // エラーレベル
                        "SFUKN09020U",                          // アセンブリＩＤまたはクラスＩＤ
                        "入力されたコードの自社名称設定情報が既に登録されています。\n編集を行いますか？",   // 表示するメッセージ
                        0,                                      // ステータス値
                        MessageBoxButtons.YesNo);               // 表示するボタン
                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                // 画面再描画
                                this._dataIndex = i;
                                ScreenClear();
                                ScreenReconstruction();
                                break;
                            }
                        case DialogResult.No:
                            {
                                // 自社名称コードのクリア
                                CompanyNameCd_tNedit.Clear();
                                break;
                            }
                    }
                    return true;
                }
            }
            return false;
        }
        // 2009.03.23 30413 犬飼 新規モードからモード変更対応 <<<<<<END
        
        # region 2007.05.17  S.Koga  DEL
//        /// <summary>
//        /// Control.Click イベント(TakeInImage_GuideButton)
//        /// </summary>
//        /// <param name="sender">対象オブジェクト</param>
//        /// <param name="e">イベントパラメータ</param>
//        /// <remarks>
//        /// <br>Note       : 取込画像選択ガイドボタンコントロールがクリックされたときに発生します。</br>
//        /// <br>Programmer : 23001 秋山　亮介</br>
//        /// <br>Date       : 2005.10.04</br>
//        /// </remarks>
//        private void TakeInImage_GuideButton_Click(object sender, System.EventArgs e)
//        {
//            // 開いて表示
//            this.TakeInImage_OpenFileDialog.FileName = this.Image_tEdit.DataText;
//            DialogResult result = this.TakeInImage_OpenFileDialog.ShowDialog();
//            if( result == DialogResult.OK ) {
//                this.Image_tEdit.DataText = this.TakeInImage_OpenFileDialog.FileName;
//                this.TakeInImage_UltraPictureBox.Image = Image.FromFile( this.TakeInImage_OpenFileDialog.FileName );
//                this._changeTakeInImage = true;
/////////////////////////////////////////////////////////////////////// 2005.10.24 AKIYAMA ADD STA //
//                // 拠点選択時はフォーカスを次へ移動
//                this.SelectNextControl( ( Control )sender, true, true, true, true );
//// 2005.10.24 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////
//            }
/////////////////////////////////////////////////////////////////////// 2005.10.24 AKIYAMA ADD STA //
//            else {
//                ( ( Control )sender ).Focus();
//            }
//// 2005.10.24 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////
        //        }

        ///// <summary>
        ///// Control.Click イベント(TakeInImageDelete_Button)
        ///// </summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="e">イベントパラメータ</param>
        ///// <remarks>
        ///// <br>Note       : 取込画像削除ガイドボタンコントロールがクリックされたときに発生します。</br>
        ///// <br>Programmer : 23001 秋山　亮介</br>
        ///// <br>Date       : 2005.10.04</br>
        ///// </remarks>
        //private void TakeInImageDelete_Button_Click(object sender, System.EventArgs e)
        //{
        //    this.TakeInImage_UltraPictureBox.Image = null;
        //    this.Image_tEdit.Clear();
        //}
        # endregion

// 2006.08.18 AKIYAMA DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//		/// <summary>
//		/// Timer.Tick イベント(Wait_Timer)
//		/// </summary>
//		/// <param name="sender">対象オブジェクト</param>
//		/// <param name="e">イベントパラメータ</param>
//		/// <remarks>
//		/// <br>Note        : 画像転送中窓監視タイマー</br>
//		/// <br>Programmer : 23001 秋山　亮介</br>
//		/// <br>Date       : 2005.09.12</br>
//		/// </remarks>
//		private void Wait_Timer_Tick(object sender, System.EventArgs e)
//		{
//			lock( this._syncObject ) {
//				// 既に画像転送中窓が非表示
//				if( this._waitWindow == null ) {
//					this.Wait_Timer.Enabled = false;
//					return;
//				}
//				if( ( this._imageTransferring == false ) && 
//					( this._waitWindow.Visible == true ) ) {
//					this._waitWindow.CloseDialog( 0 );
//					this._waitWindow = null;
//					this.Wait_Timer.Enabled = false;
//				}
//			}
//		}
// 2006.08.18 AKIYAMA DEL <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

		#endregion

		#region 画像管理マスタ関連

        # region 2007.05.17  S.Koga  DEL
        ///// <summary>
        ///// 画像読込処理
        ///// </summary>
        ///// <param name="enterpriseCode">企業コード</param>
        ///// <param name="takeInImageGroupCd">取込画像グループコード</param>
        ///// <returns>STATUS</returns>
        ///// <remarks>
        ///// <br>Note       : 画像管理マスタから画像の読み込みを行います</br>
        ///// <br>Programmer : 23001 秋山　亮介</br>
        ///// <br>Date       : 2005.10.04</br>
        ///// </remarks>
        //private int ReadImageData( string enterpriseCode, Guid takeInImageGroupCd )
        //{
        //    int status = 0;

        //    if( takeInImageGroupCd != Guid.Empty ) {

        //        Image      image      = null;
        //        ImgManage  imgManage  = null;
        //        ImageGroup imageGroup = null;

        //        status = this._SFUKN09020UB.ReadImage( out image, out imageGroup, out imgManage, this._enterpriseCode, takeInImageGroupCd );

        //        switch( status ) {
        //            case ( int )ConstantManagement.DB_Status.ctDB_NORMAL:
        //            {
        //                this._imageGroup = imageGroup;
        //                this._imgManage  = imgManage;

        //                // サムネール表示を更新する
        //                if( image != null ) {
        //                    this.TakeInImage_UltraPictureBox.Image = image;

        //                    if( ( this._imageGroup != null ) && ( this._companyNmClone != null ) ) {
        //                        this._companyNmClone.TakeInImageGroupCd = this._imageGroup.TakeInImageGroupCd;
        //                    }
        //                }
        //                break;
        //            }
        //            case ( int )ConstantManagement.DB_Status.ctDB_EOF:
        //            case ( int )ConstantManagement.DB_Status.ctDB_NOT_FOUND:
        //            {
        //                break;
        //            }
        //            default:
        //            {
        //                // サーチ
        //                TMsgDisp.Show( 
        //                    this, 										// 親ウィンドウフォーム
        //                    emErrorLevel.ERR_LEVEL_STOP, 				// エラーレベル
        //                    "SFUKN09020U", 								// アセンブリＩＤまたはクラスＩＤ
        //                    "自社名称設定", 							// プログラム名称
        //                    "ReadImageData", 							// 処理名称
        //                    TMsgDisp.OPE_GET, 							// オペレーション
        //                    "画像管理マスタの取得に失敗しました。", 	// 表示するメッセージ
        //                    status, 									// ステータス値
        //                    this._SFUKN09020UB, 						// エラーが発生したオブジェクト
        //                    MessageBoxButtons.OK, 						// 表示するボタン
        //                    MessageBoxDefaultButton.Button1 );			// 初期表示ボタン
        //                break;
        //            }
        //        }
        //    }

        //    return status;
        //}

        ///// <summary>
        ///// 画像保存処理
        ///// </summary>
        ///// <param name="enterpriseCode">企業コード</param>
        ///// <param name="takeInImageGroupCd">取込画像グループコード</param>
        ///// <returns>STATUS</returns>
        ///// <remarks>
        ///// <br>Note       : 画像管理マスタへ画像の保存を行います</br>
        ///// <br>Programmer : 23001 秋山　亮介</br>
        ///// <br>Date       : 2005.10.04</br>
        ///// </remarks>
        //private int SaveImageData( string enterpriseCode, Guid takeInImageGroupCd )
        //{
        //    int status = 0;

        //    // 取込イメージ取得
        //    Image takeInImage	= this.TakeInImage_UltraPictureBox.Image as Image;
        //    if( takeInImage == null ) {
        //        status = -1;
        //        return status;
        //    }

        //    status = this._SFUKN09020UB.SaveImage( this._enterpriseCode, takeInImageGroupCd, 
        //        takeInImage, ref this._imageGroup, ref this._imgManage );

        //    if( status != 0 ) {
        //        // 登録失敗
        //        TMsgDisp.Show( 
        //            this, 										// 親ウィンドウフォーム
        //            emErrorLevel.ERR_LEVEL_STOP, 				// エラーレベル
        //            "SFUKN09020U", 								// アセンブリＩＤまたはクラスＩＤ
        //            "自社名称設定", 							// プログラム名称
        //            "SaveImageData", 							// 処理名称
        //            TMsgDisp.OPE_UPDATE, 						// オペレーション
        //            "画像管理マスタの登録に失敗しました。", 	// 表示するメッセージ
        //            status, 									// ステータス値
        //            this._SFUKN09020UB, 						// エラーが発生したオブジェクト
        //            MessageBoxButtons.OK, 						// 表示するボタン
        //            MessageBoxDefaultButton.Button1 );			// 初期表示ボタン
        //    }

        //    return status;
        //}
        # endregion

        // 2006.08.18 AKIYAMA DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//		/// <summary>
//		/// 画像受信完了処理
//		/// </summary>
//		/// <param name="sender">画像管理マスタ配列(ImgManage[])</param>
//		/// <param name="e">イベントパラメータクラス</param>
//		/// <remarks>
//		/// <br>Note       : 画像の受信が完了したタイミングで、画像管理マスタクラス配列を受け取ります。
//		///					 取得した画像管理マスタクラス配列情報を元に、フリーメモ情報を画面に表示します。</br>
//		/// <br>Programmer : 23001 秋山　亮介</br>
//		/// <br>Date       : 2005.10.04</br>
//		/// </remarks>
//		private void ImageImgAcs_FileReceived( object sender, EventArgs e )
//		{
//
//			// アップロード中窓クローズ（画像転送中フラグOFF）
//			WaitWindowClose( 0 );
//
//			ImgManage[] imgManageArray = sender as ImgManage[];
//
//			if( ( imgManageArray == null ) || ( imgManageArray.Length == 0 ) ) {
//				return;
//			}
//
//			// 画像管理マスタ情報を取得する（１レコードのみ）
//			this._imgManage = imgManageArray[ 0 ];
//
//			// サムネール表示を更新する
//			if( ( this._imgManage != null ) && ( this._imgManage.TakeInImage != null ) ) {
//				this.TakeInImage_UltraPictureBox.Image = this._imgManage.TakeInImage;
//				if( ( this._imageGroup != null ) && ( this._companyNmClone != null ) ) {
//					this._companyNmClone.TakeInImageGroupCd = this._imageGroup.TakeInImageGroupCd;
//				}
//			}
//		}
//
//		/// <summary>
//		/// 画像送信完了処理
//		/// </summary>
//		/// <param name="sender">ステータス(Int32)</param>
//		/// <param name="e">イベントパラメータクラス</param>
//		/// <remarks>
//		/// <br>Note       : 画像送信が完了した時点で、ステータスを受け取ります。</br>
//		/// <br>Programmer : 23001 秋山　亮介</br>
//		/// <br>Date       : 2005.10.04</br>
//		/// </remarks>
//		private	void ImageImgAcs_FileSended(object sender, EventArgs e)
//		{
//			int status = -1;
//
//			// アップロード中窓クローズ（画像転送中フラグOFF）
//			WaitWindowClose( 0 );
//			
//			if (sender is Int32)
//			{
//				status = Convert.ToInt32(sender);
//
//				switch( status ) {
//					case ( int )ConstantManagement.DB_Status.ctDB_NORMAL:
//					{
//						break;
//					}
//					default:
//					{
//						TMsgDisp.Show( 
//							this, 								// 親ウィンドウフォーム
//							emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
//							"SFUKN09020U", 						// アセンブリＩＤまたはクラスＩＤ
//							"自社名称設定", 					// プログラム名称
//							"ImageImgAcs_FileSended", 			// 処理名称
//							TMsgDisp.OPE_SEND, 					// オペレーション
//							"自社画像の送信に失敗しました。", 	// 表示するメッセージ
//							status, 							// ステータス値
//							this._imageImgAcs, 					// エラーが発生したオブジェクト
//							MessageBoxButtons.OK, 				// 表示するボタン
//							MessageBoxDefaultButton.Button1 );	// 初期表示ボタン
//						return;
//					}
//				}
//			}
//		}
//
//		/// <summary>
//		/// 画像読込処理
//		/// </summary>
//		/// <param name="enterpriseCode">企業コード</param>
//		/// <param name="takeInImageGroupCd">取込画像グループコード</param>
//		/// <returns>STATUS</returns>
//		/// <remarks>
//		/// <br>Note       : 画像管理マスタから画像の読み込みを行います</br>
//		/// <br>Programmer : 23001 秋山　亮介</br>
//		/// <br>Date       : 2005.10.04</br>
//		/// </remarks>
//		private int ReadImageData( string enterpriseCode, Guid takeInImageGroupCd )
//		{
//			int status = 0;
//
//			if( takeInImageGroupCd != Guid.Empty ) {
//				// 画像グループマスタ＆画像管理マスタ検索処理
//				ImageGroup[] imageGroupArray;
//				ImgManage[] imgManageArray;
//
//				// 転送中メッセージ窓のインスタンスを生成（画像転送中フラグON）
//				WaitWindowCreate();
//
//				status = this._imageImgAcs.Search( out imageGroupArray, out imgManageArray, enterpriseCode, takeInImageGroupCd, SYSTEMDIV_CD, IMAGEUSESYSTEM_CODE, true );
//
//				switch( status ) {
//					case ( int )ConstantManagement.DB_Status.ctDB_NORMAL:
//					{
//						// ダウンロード中のメッセージを表示
//						WaitWindowShow( 0 );
//
//						if( ( imageGroupArray != null ) && ( imageGroupArray.Length > 0 ) ) {
//							this._imageGroup = imageGroupArray[ 0 ];
//						}
//
//						if( ( imgManageArray != null ) && ( imgManageArray.Length > 0 ) ) {
//							this._imgManage = imgManageArray[ 0 ];
//						}
//
//						break;
//					}
//					case ( int )ConstantManagement.DB_Status.ctDB_EOF:
//					case ( int )ConstantManagement.DB_Status.ctDB_NOT_FOUND:
//					{
//						// アップロード中窓クローズ（画像転送中フラグOFF）
//						WaitWindowClose( 0 );
//						break;
//					}
//					default:
//					{
//						// アップロード中窓クローズ（画像転送中フラグOFF）
//						WaitWindowClose( -1 );
//						// サーチ
//						TMsgDisp.Show( 
//							this, 										// 親ウィンドウフォーム
//							emErrorLevel.ERR_LEVEL_STOP, 				// エラーレベル
//							"SFUKN09020U", 								// アセンブリＩＤまたはクラスＩＤ
//							"自社名称設定", 							// プログラム名称
//							"ReadImageData", 							// 処理名称
//							TMsgDisp.OPE_GET, 							// オペレーション
//							"画像管理マスタの取得に失敗しました。", 	// 表示するメッセージ
//							status, 									// ステータス値
//							this._imageImgAcs, 							// エラーが発生したオブジェクト
//							MessageBoxButtons.OK, 						// 表示するボタン
//							MessageBoxDefaultButton.Button1 );			// 初期表示ボタン
//						return status;
//					}
//				}
//			}
//
//			return status;
//		}
//
//		/// <summary>
//		/// 画像保存処理
//		/// </summary>
//		/// <param name="enterpriseCode">企業コード</param>
//		/// <param name="takeInImageGroupCd">取込画像グループコード</param>
//		/// <returns>STATUS</returns>
//		/// <remarks>
//		/// <br>Note       : 画像管理マスタへ画像の保存を行います</br>
//		/// <br>Programmer : 23001 秋山　亮介</br>
//		/// <br>Date       : 2005.10.04</br>
//		/// </remarks>
//		private int SaveImageData( string enterpriseCode, Guid takeInImageGroupCd )
//		{
//			int status = 0;
//
//			// 取込イメージ取得
//			Image takeInImage	= this.TakeInImage_UltraPictureBox.Image as Image;
//			if( takeInImage == null ) {
//				status = -1;
//				return status;
//			}
//			// サムネール
////			Image thmnailImage	= takeInImage.GetThumbnailImage( 
////				Convert.ToInt32( takeInImage.Width / 10 ), 
////				Convert.ToInt32( takeInImage.Height / 10 ), 
////				new Image.GetThumbnailImageAbort( this.GetThumbnailAbort ), 
////				IntPtr.Zero );
//
//			byte[] takeInImageBinaryData	= ImageImgAcs.ImageToBinary( takeInImage, System.Drawing.Imaging.ImageFormat.Png );
////			byte[] thmnailImageBinaryData	= ImageImgAcs.ImageToBinary( thmnailImage, System.Drawing.Imaging.ImageFormat.Png );
//
//			// 画像管理マスタワーククラス生成
/////////////////////////////////////////////////////////////////////// 2005.11.04 AKIYAMA ADD STA //
//			// 品管障害対応 (管理No.000273-02)
//			if( this._imgManage != null ) {
//				this._imageImgAcs.DeleteImage( this._imgManage, enterpriseCode );
//			}
//			this._imgManage = new ImgManage();
//			this._imgManage.EnterpriseCode			= enterpriseCode;
//			this._imgManage.TakeInImageCode = Guid.NewGuid();
//// 2005.11.04 AKIYAMA ADD END /////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////// 2005.11.04 AKIYAMA DEL STA //
////			if( this._imgManage == null ) {
////				this._imgManage = new ImgManage();
////			}
////			this._imgManage.EnterpriseCode			= enterpriseCode;
////			if( this._imgManage.TakeInImageCode == Guid.Empty ) {
////				this._imgManage.TakeInImageCode = Guid.NewGuid();
////			}
//// 2005.11.04 AKIYAMA DEL END /////////////////////////////////////////////////////////////////////
//			this._imgManage.TakeInImageDispName		= "自社名称設定_自社画像";
//			this._imgManage.TakeInImageFileType		= ImageImgAcs.ImageFormatToString( System.Drawing.Imaging.ImageFormat.Png );
//			this._imgManage.TakeInImageColorCnt		= ImageImgAcs.PixelFormatToInt32( takeInImage.PixelFormat );
//			this._imgManage.TakeInImageWidth		= takeInImage.Width;
//			this._imgManage.TakeInImageHeight		= takeInImage.Height;
//			this._imgManage.TakeInImageFileSize		= takeInImageBinaryData.Length;
//			this._imgManage.TakeInImageFileUrl		= 
//				this._imgManage.TakeInImageCode.ToString() + "." + this._imgManage.TakeInImageFileType;
//			this._imgManage.TakeInImageDispOrder	= 1;
//			this._imgManage.TakeInImage				= takeInImage;
//			this._imgManage.TakeInImageDateTime		= TDateTime.GetSFDateNow();
//
//			this._imgManage.ThmnailImageFileType	= "";
//			this._imgManage.ThmnailImageColorCnt	= 0;
//			this._imgManage.ThmnailImageWidth		= 0;
//			this._imgManage.ThmnailImageHeight		= 0;
//			this._imgManage.ThmnailImageFileSize	= 0;
//			this._imgManage.ThmnailImage			= null;
//			this._imgManage.ThmnailImageFileUrl		= "";
//			this._imgManage.FreeMemoCmpDtSavePlc	= "";
//			this._imgManage.FreeMemoData			= null;
//
//			// 画像グループクラス生成
//			if( this._imageGroup == null ) {
//				this._imageGroup = new ImageGroup();
//			}
//			this._imageGroup.EnterpriseCode		= enterpriseCode;
//			this._imageGroup.TakeInImageGroupCd	= takeInImageGroupCd;
//			this._imageGroup.TakeInImageCode	= this._imgManage.TakeInImageCode;
//			this._imageGroup.SystemDivCd		= SYSTEMDIV_CD;
//			this._imageGroup.ImageUseSystemCode	= IMAGEUSESYSTEM_CODE;
//
//			// アクセスクラスパラメータ設定
//			ImageGroup[] imageGroupArray = new ImageGroup[ 1 ];
//			imageGroupArray[ 0 ] = this._imageGroup;
//
//			ImgManage[] imgManageArray = new ImgManage[ 1 ];
//			imgManageArray[ 0 ] = this._imgManage;
//
//			// 転送中メッセージ窓のインスタンスを生成（画像転送中フラグON）
//			WaitWindowCreate();
//
//			// 画像グループマスタ＆画像管理マスタ登録処理
//			status = this._imageImgAcs.Write( ref imageGroupArray, ref imgManageArray, enterpriseCode, true );
//
//			if( status == 0 ) {
//				// アップロード中メッセージ表示
//				WaitWindowShow( 1 );
//			}
//			else {
//				// アップロード中窓クローズ（画像転送中フラグOFF）
//				WaitWindowClose( -1 );
//
//				// 登録失敗
//				TMsgDisp.Show( 
//					this, 										// 親ウィンドウフォーム
//					emErrorLevel.ERR_LEVEL_STOP, 				// エラーレベル
//					"SFUKN09020U", 								// アセンブリＩＤまたはクラスＩＤ
//					"自社名称設定", 							// プログラム名称
//					"SaveImageData", 							// 処理名称
//					TMsgDisp.OPE_UPDATE, 						// オペレーション
//					"画像管理マスタの登録に失敗しました。", 	// 表示するメッセージ
//					status, 									// ステータス値
//					this._imageImgAcs, 							// エラーが発生したオブジェクト
//					MessageBoxButtons.OK, 						// 表示するボタン
//					MessageBoxDefaultButton.Button1 );			// 初期表示ボタン
//			}
//
//			return status;
//		}
//
//		/// <summary>
//		/// サムネイル画像作成中断処理
//		/// </summary>
//		/// <returns>false</returns>
//		/// <remarks>
//		/// <br>Note       : サムネイル画像作成中に失敗した場合の処理です。</br>
//		/// <br>Programmer : 23001 秋山　亮介</br>
//		/// <br>Date       : 2005.10.04</br>
//		/// </remarks>
//		private bool GetThumbnailAbort()
//		{
//			return false;
//		}
//
//		/// <summary>
//		/// 画像転送中窓インスタンス生成（画像転送中フラグON）
//		/// </summary>
//		/// <remarks>
//		/// <br>Note       : 自社画像転送中窓のインスタンスを生成します。</br>
//		/// <br>Programmer : 23001 秋山　亮介</br>
//		/// <br>Date       : 2005.11.14</br>
//		/// </remarks>
//		private void WaitWindowCreate()
//		{
//			lock( this._syncObject ) {
//				// 画像転送中フラグをON
//				this._imageTransferring = true;
//				//窓が無い場合
//				if( ( this._waitWindow == null ) || 
//					( this._waitWindow.IsDisposed ) ) {
//					this._waitWindow = new SFUKN09020UB();
//				}
//				this._waitWindow.Icon = this.Icon;
//				// 監視タイマーをONに
//				this.Wait_Timer.Enabled = true;
//			}
//		}
//
//		/// <summary>
//		/// 画像転送中窓表示関数
//		/// </summary>
//		/// <remarks>
//		/// <br>Note       : お待ちください窓を表示します。</br>
//		/// <br>Programmer : 23001 秋山　亮介</br>
//		/// <br>Date       : 2005.11.11</br>
//		/// </remarks>
//		private void WaitWindowShow( int transferMode )
//		{
//			lock( this._syncObject ) {
//				// 既に転送完了のとき
//				if( this._waitWindow == null ) {
//					return;
//				}
//			}
//			this._waitWindow.ShowDialog( transferMode );
////			this._waitWindow.Refresh();
//		}
//		
//		/// <summary>
//		/// 画像転送中窓閉じる関数（画像転送中フラグOFF）
//		/// </summary>
//		/// <remarks>
//		/// <br>Note       : お待ちください窓を閉じます。</br>
//		/// <br>Programmer : 23001 秋山　亮介</br>
//		/// <br>Date       : 2005.11.11</br>
//		/// </remarks>
//		private void WaitWindowClose( int status )
//		{
//			// ロック
//			lock( this._syncObject ) {
//				this._imageTransferring = false;
//				if( this._waitWindow != null )
//				{
//					this._waitWindow.CloseDialog( status );
//					this._waitWindow = null;
//					this.Wait_Timer.Enabled = false;
//				}
//			}
//		}
// 2006.08.18 AKIYAMA DEL <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

		#endregion
	}
}

using System;
using System.IO;
using System.Xml;
using System.Data;
using System.Text;
using System.Drawing;
using System.Threading;
using System.Reflection;
using System.Collections;
using System.Drawing.Imaging;
using System.Collections.Generic;

using ar=DataDynamics.ActiveReports;

using Broadleaf.Library.Text;
using Broadleaf.Xml.Serialization;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// 自由帳票印字位置設定アクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note		: 自由帳票印字位置設定へのアクセス制御を行います。</br>
	/// <br>			: 外部から各データへのアクセスはプロパティを通じて行います。</br>
	/// <br>			: 尚、本クラスから直接リモートクラスをCallする事はありません。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2007.05.10</br>
	/// <br></br>
	/// <br>Update Note : 2008.05.22 22018 鈴木正臣</br>
    /// <br>            : ①PM.NS対応</br>
	/// </remarks>
	public class FrePrtPosAcs
	{
		#region Enum
		/// <summary>自由帳票保存モード</summary>
		public enum FreeSheet_SaveMode
		{
			/// <summary>新規登録</summary>
			NewWrite,
			/// <summary>上書き保存</summary>
			OverWrite,
		}
		#endregion

		#region Const
		private const string ctExtendXML = ".xml";
		// 自由帳票プロパティ表示情報ファイル名
		private const string ctARCtrlPropertyDispInfo_FileNm		= "SFANL08105U_DispInfo";
		// 印字項目グループ表示名称ファイル名
		private const string ctPrtItemGroupingDispTitle_FileName	= "SFANL08105U_ItemTitle";
		// 自由帳票プロパティ表示情報Dictionary作成用
		/// <summary>TextBox</summary>
		public const string TBL_TEXTBOX	= "TextBox";
		/// <summary>Label</summary>
		public const string TBL_LABEL	= "Label";
		/// <summary>Picture</summary>
		public const string TBL_PICTURE	= "Picture";
		/// <summary>Shape</summary>
		public const string TBL_SHAPE	= "Shape";
		/// <summary>Line</summary>
		public const string TBL_LINE	= "Line";
		/// <summary>Barcode</summary>
		public const string TBL_BARCODE	= "Barcode";
		#endregion

		#region PrivateMember
		// --------------------------------------------------------
		// ☆☆☆ 各種アクセスクラス ☆☆☆
		// --------------------------------------------------------
		// 印字位置設定系アクセスクラス
		private FrePrtPSetAcs			_frePrtPSetAcs;
		// 印字項目設定系アクセスクラス
		private PrtItemGrpAcs			_prtItemSetAcs;
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 DEL
        //// ローカルデータアクセスクラス
        //private FrePrtPosLocalAcs		_localDataAcs;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 DEL
        //// DM案内文設定アクセスクラス
        //private DmGuideSntAcs			_dmGuideSntAcs;
        //// DMプログラム管理アクセスクラス
        //private DmPgMngAcs				_dmPgMngAcs;

		// --------------------------------------------------------
		// ☆☆☆ バックアップ情報 ☆☆☆
		// --------------------------------------------------------
		// 自由帳票印字位置設定マスタ
		private FrePrtPSet				_buf_frePrtPSet;
		// 自由帳票抽出条件設定マスタ
		private List<FrePprECnd>		_buf_frePprECndList;
		// 自由帳票ソート順位マスタ
		private List<FrePprSrtO>		_buf_frePprSrtOList;
		// 画像グループマスタ
		private ImageGroup				_buf_imageGroup;
		// 画像管理マスタ
		private ImgManage				_buf_imgManage;

		// --------------------------------------------------------
		// ☆☆☆ 起動時に取得する情報 ☆☆☆
		// --------------------------------------------------------
		// 印字項目グループマスタ
		private List<PrtItemGrpWork>	_prtItemGrpList;
		// 印字項目グループ表示名称
		private List<PrtItemGroupingDispTitle> _prtItemGroupingDispTitle;
		// 自由帳票管理オプションフラグ
		private bool					_freeSheetMngOpt;

		// --------------------------------------------------------
		// ☆☆☆ レポートの編集対象が確定した時点で取得する情報 ☆☆☆
		// --------------------------------------------------------
		// 印字項目設定マスタ
		private List<PrtItemSetWork>	_prtItemSetList;
		// 自由帳票印字位置設定マスタ
		private FrePrtPSet				_frePrtPSet;
		// 自由帳票抽出条件設定マスタ
		private List<FrePprECnd>		_frePprECndList;
		// 自由帳票抽出条件明細マスタ
		private List<FrePExCndD>		_frePExCndDList;
		// 自由帳票ソート順位マスタ
		private List<FrePprSrtO>		_frePprSrtOList;
		// 画像グループマスタ
		private ImageGroup				_imageGroup;
		// 画像管理マスタ
		private ImgManage				_imgManage;
		// 自由帳票プロパティ表示情報
		private List<ARCtrlPropertyDispInfo> _aRCtrlDispList;

		// --------------------------------------------------------
		// ☆☆☆ その他ワーク変数 ☆☆☆
		// --------------------------------------------------------
		// エラーメッセージ
		private string					_errorStr;
		// 伝票種別LIST
		private List<int>				_slipPrtKindList;
		// 透かし画像制御部品
		private SFANL08235CF			_watermarkCmnCtrl;
		#endregion

		#region Property
		/// <summary>エラーメッセージ</summary>
		/// <remarks>読み取り専用</remarks>
		public string ErrorMessage
		{
			get { return _errorStr; }
		}

		/// <summary>自由帳票管理オプションフラグ</summary>
		/// <remarks>読み取り専用</remarks>
		public bool FreeSheetMngOpt
		{
			get { return _freeSheetMngOpt; }
		}

		/// <summary>印字項目グループマスタ</summary>
		/// <remarks>読み取り専用</remarks>
		public List<PrtItemGrpWork> PrtItemGrpList
		{
			get {
				if (_prtItemGrpList != null)
					return _prtItemGrpList;
				else
					return new List<PrtItemGrpWork>();
			}
		}

		/// <summary>自由帳票印字項目設定マスタ</summary>
		/// <remarks>読み取り専用</remarks>
		public List<PrtItemSetWork> PrtItemSetList
		{
			get { return _prtItemSetList; }
		}

		/// <summary>自由帳票印字位置設定マスタ</summary>
		public FrePrtPSet FrePrtPSet
		{
			get { return _frePrtPSet; }
			set { _frePrtPSet = value; }
		}

		/// <summary>自由帳票抽出条件設定マスタ</summary>
		public List<FrePprECnd> FrePprECndList
		{
			get { return _frePprECndList; }
			set { _frePprECndList = value; }
		}

		/// <summary>自由帳票抽出条件明細マスタ</summary>
		/// <remarks>読み取り専用</remarks>
		public List<FrePExCndD> FrePExCndDList
		{
			get {
				if (_frePExCndDList != null)
					return _frePExCndDList;
				else
					return new List<FrePExCndD>();
			}
		}

		/// <summary>自由帳票ソート順位マスタ</summary>
		public List<FrePprSrtO> FrePprSrtOList
		{
			get { return _frePprSrtOList; }
			set { _frePprSrtOList = value; }
		}

		/// <summary>自由帳票プロパティ表示情報</summary>
		/// <remarks>読み取り専用</remarks>
		public List<ARCtrlPropertyDispInfo> ARCtrlPropertyDispInfo
		{
			get {
				if (_aRCtrlDispList != null)
					return _aRCtrlDispList;
				else
					return new List<ARCtrlPropertyDispInfo>();
			}
		}

		/// <summary>印字項目グループ表示名称</summary>
		/// <remarks>読み取り専用</remarks>
		public List<PrtItemGroupingDispTitle> PrtItemGroupingDispTitle
		{
			get {
				if (_prtItemGroupingDispTitle != null)
					return _prtItemGroupingDispTitle;
				else
					return new List<PrtItemGroupingDispTitle>();
			}
		}

		/// <summary>透かし画像</summary>
		/// <remarks>読み取り専用</remarks>
		public Image WaterMark
		{
			get {
				if (_imgManage != null)
					return _imgManage.TakeInImage;
				else
					return null;
			}
		}

		/// <summary>伝票種別LIST</summary>
		public List<int> SlipPrtKindList
		{
			set { _slipPrtKindList = value; }
		}
		#endregion

		#region Constructor
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public FrePrtPosAcs()
		{
			try
			{
				_frePrtPSetAcs		= new FrePrtPSetAcs();
				_prtItemSetAcs		= new PrtItemGrpAcs();
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 DEL
                //_localDataAcs		= new FrePrtPosLocalAcs();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 DEL
				_watermarkCmnCtrl	= new SFANL08235CF();

				// 自由帳票管理オプションの有無をチェック
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki　保留・対応必要  615C
                //PurchaseStatus status
                //    = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_FreeSheetgMng);
                PurchaseStatus status
                = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB( ConstantManagement_SF_PRO.SoftwareCode_PAC_PM );
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki　保留・対応必要　615C
				if (status >= PurchaseStatus.Contract)
					_freeSheetMngOpt = true;

			}
			catch
			{
				_frePrtPSetAcs		= null;
				_prtItemSetAcs		= null;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 DEL
                //_localDataAcs		= null;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 DEL
				_watermarkCmnCtrl	= null;
			}
		}
		#endregion

		#region PublicMethod
		/// <summary>
		/// 初期処理
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: 初期処理を行います。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.05.10</br>
		/// </remarks>
		public int Initialize(string enterpriseCode)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			try
			{
				// ログ出力（リモート版）
				_frePrtPSetAcs.WriteLog(enterpriseCode, LoginInfoAcquisition.Employee.EmployeeCode, "FrePrtPos Edit Start");

				// 印字項目グループLIST取得
				List<PrtItemGrpWork> prtItemGrpList;
				status = _prtItemSetAcs.SearchPrtItemGrpWork(out prtItemGrpList);
				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						_prtItemGrpList = prtItemGrpList;
						break;
					}
					default:
					{
						_errorStr = _prtItemSetAcs.ErrorMessage;
						break;
					}
				}

				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					// 抽出条件明細LIST取得
					List<FrePExCndD> frePExCndDList;
					status = _frePrtPSetAcs.SearchFrePExCndDList(enterpriseCode, out frePExCndDList);
					switch (status)
					{
						case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
						{
							_frePExCndDList = frePExCndDList;
							break;
						}
						case (int)ConstantManagement.DB_Status.ctDB_EOF:
						{
							status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
							break;
						}
						default:
						{
							_errorStr = _prtItemSetAcs.ErrorMessage;
							break;
						}
					}
				}
			}
			catch (Exception ex)
			{
				_errorStr = "初期処理にて例外が発生しました。" + Environment.NewLine + ex.Message;
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			return status;
		}

		/// <summary>
		/// 終了ログ出力処理
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="message">メッセージ</param>
		/// <remarks>
		/// <br>Note		: 編集終了時のログを出力します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.05.10</br>
		/// </remarks>
		public void WriteLog(string enterpriseCode, string message)
		{
			// ログ出力（リモート版）
			_frePrtPSetAcs.WriteLog(enterpriseCode, LoginInfoAcquisition.Employee.EmployeeCode, message);
		}

		/// <summary>
		/// 自由帳票印字位置設定情報読込処理
		/// </summary>
		/// <param name="frePrtPSet">自由帳票印字位置設定マスタ</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: 指定された印字位置情報を取得します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.05.10</br>
		/// </remarks>
		public int ReadReportInfo(FrePrtPSet frePrtPSet)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			try
			{
				// 更新チェックの為退避
				DateTime updateDateTime = frePrtPSet.UpdateDateTime;

				PrtItemGrpWork prtItemGrpWork = _prtItemGrpList.Find(
					delegate(PrtItemGrpWork prtItemGrp)
					{
						if (prtItemGrp.FreePrtPprItemGrpCd == frePrtPSet.FreePrtPprItemGrpCd)
							return true;
						else
							return false;
					}
				);

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/19 DEL
                //// ローカルデータの取得
                //bool isExistLclData = false;
                //FrePrtPSet frePrtPSetClone = frePrtPSet.Clone();
                //List<FrePprECnd> frePprECndList;
                //List<FrePprSrtO> frePprSrtOList;
                //List<FPSortInitWork> fPSortInitList = new List<FPSortInitWork>();
                //status = _localDataAcs.ReadLocalFrePrtPSet(ref frePrtPSetClone, out frePprECndList, out frePprSrtOList);
                //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //{
                //    isExistLclData = true;

                //    // 更新日付が等しい場合はローカルデータを使用
                //    if (!updateDateTime.Equals(frePrtPSetClone.UpdateDateTime))
                //        status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                //    else
                //        frePrtPSet = frePrtPSetClone;
                //}

                //// ローカルデータが古い或いは取得出来ない場合はリモーティング
                //if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //{
                //    status = _frePrtPSetAcs.ReadDBFrePrtPSet(ref frePrtPSet, out frePprECndList, out frePprSrtOList);
                //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //    {
                //        // ローカルデータが取得出来ない時のみローカル保存
                //        if (!isExistLclData)
                //            _localDataAcs.WriteLocalFrePrtPSet(frePrtPSet, frePprECndList, frePprSrtOList);
                //    }
                //    else
                //    {
                //        _errorStr = _frePrtPSetAcs.ErrorMessage;
                //    }
                //}
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/19 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/19 ADD
                FrePrtPSet frePrtPSetClone = frePrtPSet.Clone();
                List<FrePprECnd> frePprECndList;
                List<FrePprSrtO> frePprSrtOList;
                List<FPSortInitWork> fPSortInitList = new List<FPSortInitWork>();

                status = _frePrtPSetAcs.ReadDBFrePrtPSet( ref frePrtPSet, out frePprECndList, out frePprSrtOList );
                
                if ( status != (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                {
                    _errorStr = _frePrtPSetAcs.ErrorMessage;
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/19 ADD


				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					// 印字項目設定検索処理
					status = SearchPrtItemSet(prtItemGrpWork, out fPSortInitList);
					if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
					{
						// -------------------------------------------------
						// 自由帳票印字位置設定
						// -------------------------------------------------
						_frePrtPSet = frePrtPSet;

						// -------------------------------------------------
						// 自由帳票抽出条件
						// -------------------------------------------------
						// 印字項目設定より抽出条件設定を作成
						List<FrePprECnd> wkFrePprECndList
							= CreateFrePprECndFromPrtItemSet(frePrtPSet.EnterpriseCode, frePrtPSet.OutputFormFileName, frePrtPSet.UserPrtPprIdDerivNo);
						// 既存の抽出条件設定と、↑で作成した抽出条件設定をマージ
						_frePprECndList = MergeFrePprECnd(wkFrePprECndList, frePprECndList);

						// -------------------------------------------------
						// 自由帳票ソート順位
						// -------------------------------------------------
						// 印字項目設定よりソート順位を作成
						List<FrePprSrtO> wkFrePprSrtOList
							= CreateFrePprSrtO(frePrtPSet.EnterpriseCode, frePrtPSet.OutputFormFileName, frePrtPSet.UserPrtPprIdDerivNo, fPSortInitList);
						// 既存のソート順位と、↑で作成したソート順位をマージ
						_frePprSrtOList = MergeFrePprSrtO(wkFrePprSrtOList, frePprSrtOList);

						// -------------------------------------------------
						// その他
						// -------------------------------------------------
						// 透かし画像情報をクリア
						_imageGroup = null;
						_imgManage = null;
						// 透かし画像の取得
						SearchImage();

						// ActiveReport表示プロパティ設定取得
						_aRCtrlDispList = GetDispPropertyList();

						// バッファにコピー
						CopyPrtPosDataToBuffer();

						// ログ出力（リモート版）
						_frePrtPSetAcs.WriteLog(frePrtPSet.EnterpriseCode, LoginInfoAcquisition.Employee.EmployeeCode, "FrePrtPos Edit ReadReportInfo");
					}
				}
			}
			catch (Exception ex)
			{
				_errorStr = "自由帳票印字位置設定情報読込処理にて例外が発生しました。" + Environment.NewLine + ex.Message;
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			return status;
		}

		/// <summary>
		/// 自由帳票印字位置設定保存処理
		/// </summary>
		/// <param name="saveMode">自由帳票保存モード</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: 指定された印字位置設定を登録します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.05.10</br>
		/// </remarks>
		public int WriteDBFrePrtPSet(FreeSheet_SaveMode saveMode)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			try
			{
				List<FrePprECnd> writeFrePprECndList = null;
				List<FrePprSrtO> writeFrePprSrtOList = null;

				bool isNewWrite = false;
				switch (saveMode)
				{
					case FreeSheet_SaveMode.NewWrite:
					{
						isNewWrite = true;

                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 DEL
                        //// 枝番はリモートで取得
                        //int userPrtPprIdDerivNo = _frePrtPSetAcs.GetUserPrtPprIdDerivNo(_frePrtPSet.EnterpriseCode, _frePrtPSet.OutputFormFileName);
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 ADD
                        // 枝番はゼロ固定
                        int userPrtPprIdDerivNo = 0;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 ADD

						// 更新日付をクリアする（排他対策）
						_frePrtPSet.UpdateDateTime = DateTime.MinValue;
						// 枝番を採番
						_frePrtPSet.UserPrtPprIdDerivNo = userPrtPprIdDerivNo;

						if (_frePprECndList != null)
						{
							foreach (FrePprECnd frePprECnd in _frePprECndList)
							{
								// 更新日付をクリアする（排他対策）
								frePprECnd.UpdateDateTime = DateTime.MinValue;
								// 枝番を採番
								frePprECnd.UserPrtPprIdDerivNo = userPrtPprIdDerivNo;
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/21 ADD
                                // 帳票ＩＤ書き換え(名前を付けて保存対策)
                                frePprECnd.OutputFormFileName = _frePrtPSet.OutputFormFileName;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/21 ADD
							}
						}
						if (_frePprSrtOList != null)
						{
							foreach (FrePprSrtO frePprSrtO in _frePprSrtOList)
							{
								// 更新日付をクリアする（排他対策）
								frePprSrtO.UpdateDateTime = DateTime.MinValue;
								// 枝番を採番
								frePprSrtO.UserPrtPprIdDerivNo = userPrtPprIdDerivNo;
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/21 ADD
                                // 帳票ＩＤ書き換え(名前を付けて保存対策)
                                frePprSrtO.OutputFormFileName = _frePrtPSet.OutputFormFileName;
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/21 ADD
							}
						}

						// 新規なので全データリモーティング
						writeFrePprECndList = _frePprECndList;
						writeFrePprSrtOList = _frePprSrtOList;
						break;
					}
					default:
					{
						// 更新されたデータのみリモーティング
						if (IsFrePprECndListChanged()) writeFrePprECndList = _frePprECndList;
						if (IsFrePprSrtOListChanged()) writeFrePprSrtOList = _frePprSrtOList;
						break;
					}
				}

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 DEL
                //if (isNewWrite && _frePrtPSet.PrintPaperUseDivcd == 2)
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/05 ADD
                if ( _frePrtPSet.PrintPaperUseDivcd == 2 && _slipPrtKindList != null && _slipPrtKindList.Count > 0 )
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/05 ADD
				{
					// 伝票の新規登録時は伝票印刷設定の登録も行う
					List<SlipPrtSetWork> slipPrtSetList = FrePrtPSetAcs.CreateSlipPrtSet(_slipPrtKindList, _frePrtPSet, _prtItemGrpList);
					//status = _frePrtPSetAcs.WriteDBFrePrtPSet(ref _frePrtPSet, ref writeFrePprECndList, ref writeFrePprSrtOList, slipPrtSetList, isNewWrite);
                    status = _frePrtPSetAcs.WriteDBFrePrtPSet( ref _frePrtPSet, ref writeFrePprECndList, ref writeFrePprSrtOList, slipPrtSetList, null, isNewWrite );
				}
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/11 ADD
                //else if ( isNewWrite && _frePrtPSet.PrintPaperUseDivcd == 5 )
                else if ( _frePrtPSet.PrintPaperUseDivcd == 5 && _slipPrtKindList != null && _slipPrtKindList.Count > 0 )
                {
                    // 請求書の新規登録時は請求書印刷パターン設定の登録も行う
                    List<DmdPrtPtnWork> dmdPrtPtnList = FrePrtPSetAcs.CreateDmdPrtPtnList( _frePrtPSet, _prtItemGrpList );
                    status = _frePrtPSetAcs.WriteDBFrePrtPSet( ref _frePrtPSet, ref writeFrePprECndList, ref writeFrePprSrtOList, null, dmdPrtPtnList, isNewWrite );
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/11 ADD
                else
                {
                    status = _frePrtPSetAcs.WriteDBFrePrtPSet( ref _frePrtPSet, ref writeFrePprECndList, ref writeFrePprSrtOList, isNewWrite );
                }
				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						// 画像データの更新
						UpdateImage();

						// バッファにコピー
						CopyPrtPosDataToBuffer();

                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 DEL
                        //// ローカルデータ保存
                        //status = _localDataAcs.WriteLocalFrePrtPSet(_frePrtPSet, _frePprECndList, _frePprSrtOList);
                        //if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        //    _errorStr = _localDataAcs.ErrorMessage;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 DEL
						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
					{
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 DEL
                        //// 重複の場合は後で再登録してもらうメッセージ
                        //if (isNewWrite)
                        //    _errorStr = _frePrtPSetAcs.ErrorMessage + Environment.NewLine + "しばらくしてから再度保存してください。";
                        //else
                        //    _errorStr = _frePrtPSetAcs.ErrorMessage;
                        //break;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 DEL
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 ADD
                        if ( isNewWrite )
                        {
                            _errorStr = string.Format( "帳票ＩＤ={0}は既に登録されています。", _frePrtPSet.OutputFormFileName );
                        }
                        else
                        {
                            _errorStr = _frePrtPSetAcs.ErrorMessage;
                        }
                        break;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 ADD
					}
					default:
					{
						_errorStr = _frePrtPSetAcs.ErrorMessage;
						break;
					}
				}
			}
			catch (Exception ex)
			{
				_errorStr = "自由帳票印字位置設定保存処理にて例外が発生しました。" + Environment.NewLine + ex.Message;
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			return status;
		}

		/// <summary>
		/// 新規データ作成処理
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
        /// <param name="prtFormId">帳票ID</param>
		/// <param name="displayName">出力名称</param>
		/// <param name="prtItemGrpWork">印字項目グループ</param>
		/// <remarks>
		/// <br>Note		: 新規データを作成します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.05.10</br>
		/// </remarks>
		// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 DEL
        //public int CreateNewData(string enterpriseCode, string displayName, PrtItemGrpWork prtItemGrpWork)
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 DEL
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 ADD
        public int CreateNewData( string enterpriseCode, string prtFormId, string displayName, PrtItemGrpWork prtItemGrpWork )
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 ADD
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			try
			{
				// 印字項目設定を取得
				List<FPSortInitWork> fPSortInitList;
				status = SearchPrtItemSet(prtItemGrpWork, out fPSortInitList);
				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					// -------------------------------------------------
					// 自由帳票印字位置設定
					// -------------------------------------------------
					// 渡されたデータより自由帳票印字位置設定を生成
					_frePrtPSet = CreateFrePrtPSetFromPrtItemGrp(prtItemGrpWork, enterpriseCode, prtFormId, displayName, prtItemGrpWork.FormFeedLineCount, prtItemGrpWork.CrCharCnt, null);


					// -------------------------------------------------
					// 自由帳票抽出条件
					// -------------------------------------------------
					// 印字項目設定より抽出条件を生成
					List<FrePprECnd> frePprECndList
						= CreateFrePprECndFromPrtItemSet(_frePrtPSet.EnterpriseCode, _frePrtPSet.OutputFormFileName, _frePrtPSet.UserPrtPprIdDerivNo);

					// 表示順位ASC,必須抽出条件区分DESC,自由帳票抽出条件枝番ASC順でソート
					frePprECndList.Sort(new FrePprECndCompare());

					// 抽出条件の表示順位を採番
					int displayOrder = 1;
					foreach (FrePprECnd frePprECnd in frePprECndList)
					{
						if (frePprECnd.NecessaryExtraCondCd == 1)
							frePprECnd.DisplayOrder = displayOrder++;
					}
					_frePprECndList = frePprECndList;


					// -------------------------------------------------
					// 自由帳票ソート順位
					// -------------------------------------------------
					// 印字項目設定よりソート順位を生成
					List<FrePprSrtO> frePprSrtOList
						= CreateFrePprSrtO(_frePrtPSet.EnterpriseCode, _frePrtPSet.OutputFormFileName, _frePrtPSet.UserPrtPprIdDerivNo, fPSortInitList);
					_frePprSrtOList = frePprSrtOList;


					// -------------------------------------------------
					// その他
					// -------------------------------------------------
					// ActiveReport表示プロパティ設定取得
					_aRCtrlDispList = GetDispPropertyList();

					// 透かし画像情報をクリア
					_imageGroup	= null;
					_imgManage	= null;

					// バッファにコピー
					CopyPrtPosDataToBuffer();
				}

				// ログ出力（リモート版）
				_frePrtPSetAcs.WriteLog(enterpriseCode, LoginInfoAcquisition.Employee.EmployeeCode, "FrePrtPos Edit CreateNewData");
			}
			catch (Exception ex)
			{
				_errorStr = "新規データ作成処理にて例外が発生しました。" + Environment.NewLine + ex.Message;
				status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			}

			return status;
		}

		/// <summary>
		/// 新規データ作成処理（既存帳票参照新規）
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="frePrtGuideSearchRet">自由帳票ガイド検索結果クラス</param>
		/// <remarks>
		/// <br>Note		: 新規データを作成します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.05.10</br>
		/// </remarks>
		public int CreateNewData(string enterpriseCode, FrePrtGuideSearchRet frePrtGuideSearchRet)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			try
			{
				PrtItemGrpWork prtItemGrpWork = _prtItemGrpList.Find(
					delegate(PrtItemGrpWork prtItemGrp)
					{
						if (prtItemGrp.FreePrtPprItemGrpCd == frePrtGuideSearchRet.FreePrtPprItemGrpCd)
							return true;
						else
							return false;
					}
				);

				if (prtItemGrpWork != null)
				{
					FPprSchmGrWork fPprSchmGrWork = DBAndXMLDataMergeParts.CopyPropertyInClass<FPprSchmGrWork>(frePrtGuideSearchRet);

					List<FPprSchmCvWork> fPprSchmCvList;
					List<FPSortInitWork> fPSortInitList;
					List<FPECndInitWork> fPECndInitList;
					status = SearchPrtItemSetWithFPprSchmCv(prtItemGrpWork, fPprSchmGrWork, out fPprSchmCvList, out fPSortInitList, out fPECndInitList);
					if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
					{
						SFANL08132CG cnv = new SFANL08132CG();
						string errMsg = string.Empty;
						ar.ActiveReport3 rpt = null;

                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki　保留・対応必要　SFANL08132C ソース入手して、ActiveReports3でリコンパイル
                        //// 特殊コンバート使用区分(0:無,1:マクロ,2:フォントのみ)
                        //if (frePrtGuideSearchRet.SpecialConvtUseDivCd != 0)
                        //{
                        //    List<DmGuideSnt> dmGuideSntList;
                        //    DmPgMng dmPgMng;
                        //    // DM特殊コンバート用データ取得処理
                        //    status = SearchDMSpecialConvData(enterpriseCode, frePrtGuideSearchRet, out dmGuideSntList, out dmPgMng, out errMsg);

                        //    // DM案内文コンバート処理
                        //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        //        rpt = cnv.CvtExistingDMGuidanceLayout(frePrtGuideSearchRet.OutputFormFileName, frePrtGuideSearchRet.OutputFileClassId, _prtItemSetList, fPprSchmCvList, dmGuideSntList, dmPgMng.EffectiveMacroSign, frePrtGuideSearchRet.SpecialConvtUseDivCd, out errMsg);
                        //}
                        //else
                        //{
                        //    // 既存レイアウトコンバート処理
                        //    rpt = cnv.CvtExistingLayout(frePrtGuideSearchRet.OutputFormFileName, frePrtGuideSearchRet.OutputFileClassId, _prtItemSetList, fPprSchmCvList, out errMsg);
                        //}

                       
                        //status = (int)ConstantManagement.DB_Status.ctDB_EOF;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki　保留・対応必要　SFANL08132C ソース入手して、ActiveReports3でリコンパイル
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/06/12 ADD
                        if ( frePrtGuideSearchRet.SpecialConvtUseDivCd != 0 )
                        {
                        }
                        else
                        {
                            // 既存レイアウトコンバート処理
                            rpt = cnv.CvtExistingLayout(frePrtGuideSearchRet.OutputFormFileName, frePrtGuideSearchRet.OutputFileClassId, _prtItemSetList, fPprSchmCvList, out errMsg);
                        }
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/06/12 ADD


						if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && rpt != null && string.IsNullOrEmpty(errMsg))
						{
							// デフォルトの余白設定
							rpt.PageSettings.Margins.Top	= ar.ActiveReport3.CmToInch((float)fPprSchmGrWork.TopMargin);
							rpt.PageSettings.Margins.Bottom = ar.ActiveReport3.CmToInch((float)fPprSchmGrWork.BottomMargin);
							rpt.PageSettings.Margins.Left	= ar.ActiveReport3.CmToInch((float)fPprSchmGrWork.LeftMargin);
							rpt.PageSettings.Margins.Right	= ar.ActiveReport3.CmToInch((float)fPprSchmGrWork.RightMargin);

							// Streamに保存
							MemoryStream stream = new MemoryStream();
							rpt.SaveLayout(stream);


							// -------------------------------------------------
							// 自由帳票印字位置設定
							// -------------------------------------------------
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 DEL
                            //_frePrtPSet = CreateFrePrtPSetFromPrtItemGrp(prtItemGrpWork, enterpriseCode, frePrtGuideSearchRet.DisplayName, frePrtGuideSearchRet.FormFeedLineCount, frePrtGuideSearchRet.CrCharCnt, stream.ToArray());
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 DEL
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 ADD
                            _frePrtPSet = CreateFrePrtPSetFromPrtItemGrp( prtItemGrpWork, enterpriseCode, frePrtGuideSearchRet.OutputFormFileName, frePrtGuideSearchRet.DisplayName, frePrtGuideSearchRet.FormFeedLineCount, frePrtGuideSearchRet.CrCharCnt, stream.ToArray() );
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 ADD
							// オプションコードをセットする
							_frePrtPSet.OptionCode = frePrtGuideSearchRet.OptionCode;


							// -------------------------------------------------
							// 自由帳票抽出条件
							// -------------------------------------------------
							// 印字項目設定より抽出条件を生成
							List<FrePprECnd> frePprECndList
								= CreateFrePprECndFromPrtItemSet(_frePrtPSet.EnterpriseCode, _frePrtPSet.OutputFormFileName, _frePrtPSet.UserPrtPprIdDerivNo);

							// 初期値設定マスタをマージ
							MergeFrePprECnd(frePprECndList, fPECndInitList);

							// 表示順位ASC,必須抽出条件区分DESC,自由帳票抽出条件枝番ASC順でソート
							frePprECndList.Sort(new FrePprECndCompare());

							// 抽出条件の表示順位を採番
							int displayOrder = 1;
							foreach (FrePprECnd frePprECnd in frePprECndList)
							{
								if (frePprECnd.NecessaryExtraCondCd == 1)
									frePprECnd.DisplayOrder = displayOrder;
								
								displayOrder++;
							}
							_frePprECndList = frePprECndList;


							// -------------------------------------------------
							// 自由帳票ソート順位
							// -------------------------------------------------
							// 印字項目設定よりソート順位を生成
							List<FrePprSrtO> frePprSrtOList
								= CreateFrePprSrtO(_frePrtPSet.EnterpriseCode, _frePrtPSet.OutputFormFileName, _frePrtPSet.UserPrtPprIdDerivNo, fPSortInitList);
							_frePprSrtOList = frePprSrtOList;


							// -------------------------------------------------
							// その他
							// -------------------------------------------------
							// ActiveReport表示プロパティ設定取得
							_aRCtrlDispList = GetDispPropertyList();

							// 透かし画像情報をクリア
							_imageGroup	= null;
							_imgManage	= null;

							// バッファにコピー
							CopyPrtPosDataToBuffer();
						}
						else
						{
							_errorStr = "既存データのコンバート処理に失敗しました。" + Environment.NewLine + errMsg;
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
						}
					}

					// ログ出力（リモート版）
					_frePrtPSetAcs.WriteLog(enterpriseCode, LoginInfoAcquisition.Employee.EmployeeCode, "FrePrtPos Edit CreateNewData");
				}
				else
				{
					_errorStr = "該当する印字項目グループがありません。";
					status = (int)ConstantManagement.DB_Status.ctDB_EOF;
				}
			}
			catch (Exception ex)
			{
				_errorStr = "新規データ作成処理（既存レイアウト）にて例外が発生しました。" + Environment.NewLine + ex.Message;
				status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			}

			return status;
		}

		/// <summary>
		/// データ変更チェック処理
		/// </summary>
		/// <returns>チェック結果</returns>
		/// <remarks>
		/// <br>Note		: データが変更されていないかチェックします。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.05.10</br>
		/// </remarks>
		public bool CheckDataChange()
		{
			// 自由帳票印字位置設定のチェック
			if (_frePrtPSet != null && _buf_frePrtPSet != null)
			{
				if (!_buf_frePrtPSet.Equals(_frePrtPSet))
					return true;

				// 印字位置データの比較
				if (!_frePrtPSet.EqualsPrintPosClassData(_buf_frePrtPSet.PrintPosClassData))
					return true;
			}

			if (IsFrePprECndListChanged())
				return true;

			if (IsFrePprSrtOListChanged())
				return true;

			return false;
		}

		/// <summary>
		/// 新規画像データセット処理
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="image">画像データ</param>
		/// <remarks>
		/// <br>Note		: 新規画像データを画像管理マスタで保持します。</br>
		/// <br>			: ※nullをセットした場合画像の削除となります。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.05.10</br>
		/// </remarks>
		public void SetNewImageData(string enterpriseCode, Image image)
		{
            //if (image != null)
            //{
            //    _watermarkCmnCtrl.CreateNewWatermarkImgManage(enterpriseCode, image, out _imageGroup, out _imgManage);
            //    _frePrtPSet.TakeInImageGroupCd	= _imageGroup.TakeInImageGroupCd;
            //}
            //else
            //{
            //    _imageGroup	= null;
            //    _imgManage	= null;
            //    _frePrtPSet.TakeInImageGroupCd	= Guid.Empty;
            //}
		}

		/// <summary>
		/// 印字位置情報バッファ退避処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: 現在展開している印字位置情報をバッファに退避します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.05.10</br>
		/// </remarks>
		public void CopyPrtPosDataToBuffer()
		{
			if (_frePrtPSet != null)
				_buf_frePrtPSet = _frePrtPSet.Clone();

			if (_frePprECndList != null)
			{
				_buf_frePprECndList = new List<FrePprECnd>();
				foreach (FrePprECnd frePprECnd in _frePprECndList)
					_buf_frePprECndList.Add(frePprECnd.Clone());
			}

			if (_frePprSrtOList != null)
			{
				_buf_frePprSrtOList = new List<FrePprSrtO>();
				foreach (FrePprSrtO frePprSrtO in _frePprSrtOList)
					_buf_frePprSrtOList.Add(frePprSrtO.Clone());
			}

			if (_imageGroup != null)
				_buf_imageGroup = _imageGroup.Clone();

			if (_imgManage != null)
			{
				_buf_imgManage = _imgManage.Clone();
				if (_imgManage.TakeInImage != null)
					_buf_imgManage.TakeInImage = (Image)_imgManage.TakeInImage.Clone();
			}
		}
		#endregion

		#region PrivateMethod
		/// <summary>
		/// 印字項目設定検索処理
		/// </summary>
		/// <param name="prtItemGrpWork">印字項目グループマスタ</param>
		/// <param name="fPSortInitList">自由帳票ソート順位初期値マスタリスト</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: 指定された印字項目設定を取得します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.05.10</br>
		/// </remarks>
		private int SearchPrtItemSet(PrtItemGrpWork prtItemGrpWork, out List<FPSortInitWork> fPSortInitList)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

			fPSortInitList = new List<FPSortInitWork>();

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 DEL
            //// -------------------------------------------------
            //// ローカルデータ取得（印字項目系）
            //// -------------------------------------------------
            //// 更新チェックの為退避
            //DateTime updateDateTime = prtItemGrpWork.UpdateDateTime;

            //PrtItemGrpWork wkPrtItemGrpWork;
            //status = _localDataAcs.ReadLocalPrtItemGrpWork(prtItemGrpWork.FreePrtPprItemGrpCd, out wkPrtItemGrpWork, out _prtItemSetList, out fPSortInitList);
            //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //{
            //    // 更新日付が異なる場合は無いも同然
            //    if (!updateDateTime.Equals(wkPrtItemGrpWork.UpdateDateTime))
            //        status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 DEL

			// -------------------------------------------------
			// リモート処理
			// -------------------------------------------------
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 DEL
            //// ローカルデータが古い或いは取得出来ない場合はリモーティング
            //if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //{
            //    status = _prtItemSetAcs.SearchPrtItemSetWork(prtItemGrpWork.FreePrtPprItemGrpCd, out _prtItemSetList, out fPSortInitList);
            //    if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            //        // 取得データをローカル保存
            //        _localDataAcs.WriteLocalPrtItemGrpWork( prtItemGrpWork, _prtItemSetList, fPSortInitList );
            //    else
            //        _errorStr = _prtItemSetAcs.ErrorMessage;
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 ADD
            status = _prtItemSetAcs.SearchPrtItemSetWork( prtItemGrpWork.FreePrtPprItemGrpCd, out _prtItemSetList, out fPSortInitList );
            if ( status != (int)ConstantManagement.DB_Status.ctDB_NORMAL )
            {
                _errorStr = _prtItemSetAcs.ErrorMessage;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 ADD

			// 印字項目グルーピング情報取得
			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				// 未導入オプションデータ削除処理
				RemoveUnContactData(_prtItemSetList);

				_prtItemGroupingDispTitle = GetDispItemTitleList();
			}

			return status;
		}

		/// <summary>
		/// 印字項目設定検索処理
		/// </summary>
		/// <param name="prtItemGrpWork">印字項目グループマスタ</param>
		/// <param name="fPprSchmGrWork">自由帳票スキーマグループマスタ</param>
		/// <param name="fPprSchmCvList">自由帳票スキーマコンバートマスタリスト</param>
		/// <param name="fPSortInitList">自由帳票ソート順位初期値マスタリスト</param>
		/// <param name="fPECndInitList">自由帳票抽出条件初期値マスタリスト</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: 指定された印字項目設定を取得します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.05.10</br>
		/// </remarks>
		private int SearchPrtItemSetWithFPprSchmCv(PrtItemGrpWork prtItemGrpWork, FPprSchmGrWork fPprSchmGrWork, out List<FPprSchmCvWork> fPprSchmCvList, out List<FPSortInitWork> fPSortInitList, out List<FPECndInitWork> fPECndInitList)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 DEL
            //bool isExistLclPrtItemGrp = false;
            //bool isExistLclFPprSchmGr = false;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 DEL
			fPprSchmCvList = new List<FPprSchmCvWork>();
			fPSortInitList = new List<FPSortInitWork>();
			fPECndInitList = new List<FPECndInitWork>();

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 DEL
            //// -------------------------------------------------
            //// ローカルデータ取得（印字項目系）
            //// -------------------------------------------------
            //// 更新チェックの為退避
            //DateTime updateDateTime = prtItemGrpWork.UpdateDateTime;

            //PrtItemGrpWork wkPrtItemGrpWork;
            //status = _localDataAcs.ReadLocalPrtItemGrpWork(prtItemGrpWork.FreePrtPprItemGrpCd, out wkPrtItemGrpWork, out _prtItemSetList, out fPSortInitList);
            //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //{
            //    // 更新日付が異なる場合は無いも同然
            //    if (updateDateTime.Equals(wkPrtItemGrpWork.UpdateDateTime))
            //        isExistLclPrtItemGrp = true;
            //}

            //// -------------------------------------------------
            //// ローカルデータ取得（自由帳票スキーマ系）
            //// -------------------------------------------------
            //// 更新チェックの為退避
            //updateDateTime = fPprSchmGrWork.UpdateDateTime;

            //FPprSchmGrWork wkFPprSchmGrWork;
            //status = _localDataAcs.ReadLocalFPprSchmGrWork(fPprSchmGrWork.FreePrtPprSchmGrpCd, out wkFPprSchmGrWork, out fPprSchmCvList, out fPSortInitList, out fPECndInitList);
            //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //{
            //    // 更新日付が異なる場合は無いも同然
            //    if (updateDateTime.Equals(wkFPprSchmGrWork.UpdateDateTime))
            //        isExistLclFPprSchmGr = true;
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 DEL

			// -------------------------------------------------
			// リモート処理
			// -------------------------------------------------
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 DEL
            //if (!isExistLclPrtItemGrp && !isExistLclFPprSchmGr)
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 DEL
			{
				List<FPSortInitWork> wkFPSortInitList;
				List<FPECndInitWork> wkFPECndInitList;
				status = _prtItemSetAcs.SearchPrtItemSetWithFPprSchmCv(prtItemGrpWork.FreePrtPprItemGrpCd, fPprSchmGrWork.FreePrtPprSchmGrpCd, out _prtItemSetList, out fPprSchmCvList, out wkFPSortInitList, out wkFPECndInitList);
				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					// 自由帳票スキーマ系
					fPSortInitList = wkFPSortInitList.FindAll(
							delegate(FPSortInitWork fPSortInit)
							{
								if (fPSortInit.FreePrtPprSchmGrpCd == fPprSchmGrWork.FreePrtPprSchmGrpCd)
									return true;
								else
									return false;
							}
						);

					fPECndInitList = wkFPECndInitList.FindAll(
							delegate(FPECndInitWork fPECndInit)
							{
								if (fPECndInit.FreePrtPprSchmGrpCd == fPprSchmGrWork.FreePrtPprSchmGrpCd)
									return true;
								else
									return false;
							}
						);
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 DEL
                    //// 取得データをローカル保存（印字項目）
                    //_localDataAcs.WriteLocalFPprSchmGrWork(fPprSchmGrWork, fPprSchmCvList, fPSortInitList, fPECndInitList);
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 DEL

					// 印字項目系
					List<FPSortInitWork> writeFPSortInit = wkFPSortInitList.FindAll(
							delegate(FPSortInitWork fPSortInit)
							{
								if (fPSortInit.FreePrtPprSchmGrpCd == 0)
									return true;
								else
									return false;
							}
						);
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 DEL
                    //// 取得データをローカル保存（印字項目）
                    //_localDataAcs.WriteLocalPrtItemGrpWork(prtItemGrpWork, _prtItemSetList, writeFPSortInit);
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 DEL
				}
				else
				{
					_errorStr = _prtItemSetAcs.ErrorMessage;
				}
			}
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 DEL
            //else if (!isExistLclPrtItemGrp)
            //{
            //    status = _prtItemSetAcs.SearchPrtItemSetWork(prtItemGrpWork.FreePrtPprItemGrpCd, out _prtItemSetList, out fPSortInitList);
            //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //    {
            //        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 DEL
            //        //// 取得データをローカル保存（印字項目）
            //        //_localDataAcs.WriteLocalPrtItemGrpWork(prtItemGrpWork, _prtItemSetList, fPSortInitList);
            //        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 DEL
            //    }
            //    else
            //    {
            //        _errorStr = _prtItemSetAcs.ErrorMessage;
            //    }
            //}
            //else if (!isExistLclFPprSchmGr)
            //{
            //    FPprSchmGrAcs fPprSchmGrAcs = new FPprSchmGrAcs();
            //    status = fPprSchmGrAcs.SearchFPprSchmCv(prtItemGrpWork.FreePrtPprItemGrpCd, new int[] { fPprSchmGrWork.FreePrtPprSchmGrpCd });
            //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //    {
            //        fPprSchmCvList = fPprSchmGrAcs.FPprSchmCvWorkList;
            //        if (fPprSchmGrAcs.FPSortInitWorkList != null)
            //            fPSortInitList = fPprSchmGrAcs.FPSortInitWorkList;
            //        if (fPprSchmGrAcs.FPECndInitWorkList != null)
            //            fPECndInitList = fPprSchmGrAcs.FPECndInitWorkList;

            //        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 DEL
            //        //// 取得データをローカル保存（自由帳票スキーマ）
            //        //_localDataAcs.WriteLocalFPprSchmGrWork(fPprSchmGrWork, fPprSchmCvList, fPSortInitList, fPECndInitList);
            //        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 DEL
            //    }
            //    else
            //    {
            //        _errorStr = fPprSchmGrAcs.ErrorMessage;
            //    }
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 DEL

			// 印字項目グルーピング情報取得
			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				// 未導入オプションデータ削除処理
				RemoveUnContactData(_prtItemSetList);

				_prtItemGroupingDispTitle = GetDispItemTitleList();
			}

			return status;
		}

        ///// <summary>
        ///// DM特殊コンバート用データ取得処理
        ///// </summary>
        ///// <param name="enterpriseCode">企業コード</param>
        ///// <param name="frePrtGuideSearchRet">自由帳票ガイド検索結果</param>
        ///// <param name="dmGuideSntList">DM案内文設定マスタリスト</param>
        ///// <param name="dmPgMng">DMプログラム管理マスタリスト</param>
        ///// <param name="errMsg">エラーメッセージ</param>
        ///// <returns>ステータス</returns>
        ///// <remarks>
        ///// <br>Note		: DM案内文関係のデータを取得します。</br>
        ///// <br>Programmer	: 22024 寺坂　誉志</br>
        ///// <br>Date		: 2007.05.10</br>
        ///// </remarks>
        //private int SearchDMSpecialConvData(string enterpriseCode, FrePrtGuideSearchRet frePrtGuideSearchRet, out List<DmGuideSnt> dmGuideSntList, out DmPgMng dmPgMng, out string errMsg)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //    errMsg			= string.Empty;
        //    dmGuideSntList	= new List<DmGuideSnt>();
        //    dmPgMng			= null;

        //    // -------------------------------------------------
        //    // DM案内文設定
        //    // -------------------------------------------------
        //    if (_dmGuideSntAcs == null) _dmGuideSntAcs = new DmGuideSntAcs();

        //    ArrayList wkList;
        //    status = _dmGuideSntAcs.DetailsSearch(out wkList, enterpriseCode, frePrtGuideSearchRet.PgId, frePrtGuideSearchRet.DmNo);
        //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //    {
        //        dmGuideSntList = DBAndXMLDataMergeParts.CopyProperty<DmGuideSnt>(wkList);
        //        if (dmGuideSntList.Count > 0)
        //        {
        //            if (dmGuideSntList[0].LogicalDeleteCode != 0)
        //            {
        //                status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
        //                errMsg = "既に他端末よりDM案内文設定が削除されています。";
        //            }
        //        }
        //    }
        //    else
        //        errMsg = "DM案内文設定の検索に失敗しました。";

        //    // -------------------------------------------------
        //    // DMプログラム管理
        //    // -------------------------------------------------
        //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //    {
        //        if (_dmPgMngAcs == null) _dmPgMngAcs = new DmPgMngAcs();

        //        status = _dmPgMngAcs.Read(out dmPgMng, enterpriseCode, frePrtGuideSearchRet.PgId, frePrtGuideSearchRet.PgSequenceNo);
        //        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //            errMsg = "DMプログラム管理の読込に失敗しました。";
        //    }

        //    return status;
        //}

		/// <summary>
		/// 画像更新処理
		/// </summary>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: 指定された画像を画像サーバーへ送信します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.05.10</br>
		/// </remarks>
		private void UpdateImage()
		{
            //if (_buf_frePrtPSet.TakeInImageGroupCd != _frePrtPSet.TakeInImageGroupCd)
            //{
            //    // 以前に画像を設定していた場合は、削除する
            //    if (_buf_frePrtPSet.TakeInImageGroupCd != null && _buf_frePrtPSet.TakeInImageGroupCd != Guid.Empty)
            //        _watermarkCmnCtrl.DeleteWatermark(_buf_imageGroup);

            //    if (_imageGroup != null && _imgManage != null)
            //        _watermarkCmnCtrl.WriteWatermarkImage(ref _imageGroup, ref _imgManage);
            //}
		}

		/// <summary>
		/// 画像検索処理
		/// </summary>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: 指定された画像を画像サーバーより取得します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.05.10</br>
		/// </remarks>
		private void SearchImage()
		{
            //if (_frePrtPSet.TakeInImageGroupCd != null && _frePrtPSet.TakeInImageGroupCd != Guid.Empty)
            //{
            //    int status = _watermarkCmnCtrl.GetWatermarkImage(_frePrtPSet.EnterpriseCode, _frePrtPSet.TakeInImageGroupCd);
            //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //    {
            //        _imageGroup	= _watermarkCmnCtrl.ImageGroup;
            //        _imgManage	= _watermarkCmnCtrl.ImgManage;
            //    }
            //}
		}

		/// <summary>
		/// 自由帳票プロパティ表示情報取得処理
		/// </summary>
		/// <returns>自由帳票プロパティ表示情報Dictionary</returns>
		/// <remarks>
		/// <br>Note		: 自由帳票プロパティ表示情報の全件取得行います。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.05.10</br>
		/// </remarks>
		private List<ARCtrlPropertyDispInfo> GetDispPropertyList()
		{
			// 帳票使用区分に応じたファイル名を生成
			string fileNm = ctARCtrlPropertyDispInfo_FileNm + ctExtendXML;

			List<ARCtrlPropertyDispInfo> aRCtrlDispList;
			if (File.Exists(fileNm))
				aRCtrlDispList = (List<ARCtrlPropertyDispInfo>)XmlByteSerializer.Deserialize(fileNm, typeof(List<ARCtrlPropertyDispInfo>));
			else
				aRCtrlDispList = new List<ARCtrlPropertyDispInfo>();

			if (!_freeSheetMngOpt)
			{
				// 管理者権限が無い場合は一部プロパティ変更設定を不可とする
				aRCtrlDispList = aRCtrlDispList.FindAll(
					delegate(ARCtrlPropertyDispInfo dispInfo)
					{
						if (dispInfo.UserAdminFlag == 0)
							return true;
						else
							return false;
					}
				);
			}

			return aRCtrlDispList;
		}

		/// <summary>
		/// 印字項目グループ表示名称取得処理
		/// </summary>
		/// <returns>印字項目グループ表示名称LIST</returns>
		/// <remarks>
		/// <br>Note		: 印字項目グループ表示名称の全件取得行います。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.05.10</br>
		/// </remarks>
		private List<PrtItemGroupingDispTitle> GetDispItemTitleList()
		{
			List<PrtItemGroupingDispTitle> prtItemGroupingDispTitleList = new List<PrtItemGroupingDispTitle>();

			string fileNm = ctPrtItemGroupingDispTitle_FileName + ctExtendXML;
			if (File.Exists(fileNm))
				prtItemGroupingDispTitleList = (List<PrtItemGroupingDispTitle>)XmlByteSerializer.Deserialize(fileNm, typeof(List<PrtItemGroupingDispTitle>));
			else
				prtItemGroupingDispTitleList = new List<PrtItemGroupingDispTitle>();

			return prtItemGroupingDispTitleList;
		}

		/// <summary>
		/// 自由帳票抽出条件設定マスタマージ処理
		/// </summary>
		/// <param name="frePprECndList">自由帳票抽出条件設定マスタ</param>
		/// <param name="fPECndInitList">自由帳票抽出条件初期値マスタ</param>
		/// <remarks>
		/// <br>Note		: 自由帳票抽出条件設定と自由帳票抽出条件初期値のマージ処理を行います。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.05.10</br>
		/// </remarks>
		private void MergeFrePprECnd(List<FrePprECnd> frePprECndList, List<FPECndInitWork> fPECndInitList)
		{
			// 初期値設定マスタをマージ
			if (frePprECndList != null && frePprECndList.Count > 0 && fPECndInitList != null)
			{
				foreach (FrePprECnd frePprECnd in frePprECndList)
				{
					FPECndInitWork fPECndInit = fPECndInitList.Find(
							delegate(FPECndInitWork fPECndInitWork)
							{
								if (fPECndInitWork.FrePrtPprExtraCondCd == frePprECnd.FrePrtPprExtraCondCd)
									return true;
								else
									return false;
							}
						);
					if (fPECndInit != null)
					{
						frePprECnd.DisplayOrder			= fPECndInit.DisplayOrder;
						frePprECnd.StExtraNumCode		= fPECndInit.StExtraNumCode;
						frePprECnd.EdExtraNumCode		= fPECndInit.EdExtraNumCode;
						frePprECnd.StExtraCharCode		= fPECndInit.StExtraCharCode;
						frePprECnd.EdExtraCharCode		= fPECndInit.EdExtraCharCode;
						frePprECnd.StExtraDateBaseCd	= fPECndInit.StExtraDateBaseCd;
						frePprECnd.StExtraDateSignCd	= fPECndInit.StExtraDateSignCd;
						frePprECnd.StExtraDateNum		= fPECndInit.StExtraDateNum;
						frePprECnd.StExtraDateUnitCd	= fPECndInit.StExtraDateUnitCd;
						frePprECnd.StartExtraDate		= fPECndInit.StartExtraDate;
						frePprECnd.EdExtraDateBaseCd	= fPECndInit.EdExtraDateBaseCd;
						frePprECnd.EdExtraDateSignCd	= fPECndInit.EdExtraDateSignCd;
						frePprECnd.EdExtraDateNum		= fPECndInit.EdExtraDateNum;
						frePprECnd.EdExtraDateUnitCd	= fPECndInit.EdExtraDateUnitCd;
						frePprECnd.EndExtraDate			= fPECndInit.EndExtraDate;
						frePprECnd.CheckItemCode1		= fPECndInit.CheckItemCode1;
						frePprECnd.CheckItemCode2		= fPECndInit.CheckItemCode2;
						frePprECnd.CheckItemCode3		= fPECndInit.CheckItemCode3;
						frePprECnd.CheckItemCode4		= fPECndInit.CheckItemCode4;
						frePprECnd.CheckItemCode5		= fPECndInit.CheckItemCode5;
						frePprECnd.CheckItemCode6		= fPECndInit.CheckItemCode6;
						frePprECnd.CheckItemCode7		= fPECndInit.CheckItemCode7;
						frePprECnd.CheckItemCode8		= fPECndInit.CheckItemCode8;
						frePprECnd.CheckItemCode9		= fPECndInit.CheckItemCode9;
						frePprECnd.CheckItemCode10		= fPECndInit.CheckItemCode10;
					}
				}
			}
		}

		/// <summary>
		/// 自由帳票抽出条件設定マスタマージ処理
		/// </summary>
		/// <param name="baseFrePprECndList">マージ対象自由帳票抽出条件設定マスタ</param>
		/// <param name="overWriteFrePprECndList">上書き対象自由帳票抽出条件設定マスタ</param>
		/// <returns>マージ済み自由帳票抽出条件設定マスタ</returns>
		/// <remarks>
		/// <br>Note		: 印字項目設定よりCreateしたデータと既存データのマージ処理を行います。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.05.10</br>
		/// </remarks>
		private List<FrePprECnd> MergeFrePprECnd(List<FrePprECnd> baseFrePprECndList, List<FrePprECnd> overWriteFrePprECndList)
		{
			if (overWriteFrePprECndList == null) overWriteFrePprECndList = new List<FrePprECnd>();

			int maxDisplayOrder = 1;
			List<FrePprECnd> retList = new List<FrePprECnd>();
			foreach (FrePprECnd baseFrePprECnd in baseFrePprECndList)
			{
				int listIndex = overWriteFrePprECndList.FindIndex(
					delegate(FrePprECnd frePprECnd)
					{
						if ((baseFrePprECnd.EnterpriseCode			== frePprECnd.EnterpriseCode) &&
							(baseFrePprECnd.OutputFormFileName		== frePprECnd.OutputFormFileName) &&
							(baseFrePprECnd.UserPrtPprIdDerivNo		== frePprECnd.UserPrtPprIdDerivNo) &&
							(baseFrePprECnd.FrePrtPprExtraCondCd	== frePprECnd.FrePrtPprExtraCondCd))
							return true;
						else
							return false;
					});
				if (listIndex >= 0)
				{
					retList.Add(overWriteFrePprECndList[listIndex]);
					maxDisplayOrder = Math.Max(maxDisplayOrder, overWriteFrePprECndList[listIndex].DisplayOrder);
				}
				else
				{
					retList.Add(baseFrePprECnd);
					if (baseFrePprECnd.DisplayOrder < 999)
						maxDisplayOrder = Math.Max(maxDisplayOrder, baseFrePprECnd.DisplayOrder);
				}
			}

			foreach (FrePprECnd frePprECnd in retList)
			{
				if (frePprECnd.NecessaryExtraCondCd == 1 && frePprECnd.DisplayOrder == 999)
					frePprECnd.DisplayOrder = ++maxDisplayOrder;
			}

			return retList;
		}

		/// <summary>
		/// 自由帳票印字位置設定マスタ作成処理
		/// </summary>
		/// <param name="prtItemGrp">印字項目グループマスタ</param>
		/// <param name="enterpriseCode">企業コード</param>
        /// <param name="prtFormId"></param>
		/// <param name="displayName"></param>
		/// <param name="formFeedLineCount"></param>
		/// <param name="crCharCnt"></param>
		/// <param name="printPosClassData"></param>
		/// <returns>自由帳票印字位置設定</returns>
		/// <remarks>
		/// <br>Note		: 印字項目グループより自由帳票印字項目設定をCreateします。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.05.10</br>
		/// </remarks>
		// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 DEL
        //private FrePrtPSet CreateFrePrtPSetFromPrtItemGrp(PrtItemGrpWork prtItemGrp, string enterpriseCode, string displayName, int formFeedLineCount, int crCharCnt, byte[] printPosClassData)
		// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 DEL
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 ADD
        private FrePrtPSet CreateFrePrtPSetFromPrtItemGrp( PrtItemGrpWork prtItemGrp, string enterpriseCode, string prtFormId, string displayName, int formFeedLineCount, int crCharCnt, byte[] printPosClassData )
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 ADD
        {
			FrePrtPSet frePrtPSet = new FrePrtPSet();

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 DEL
            //// 伝票印刷設定マスタに登録する際にキーとなるSlipPrtSetPaperIdが24桁の為
            //// OutputFormFileNameに設定する内容も24桁までとする
            //frePrtPSet.OutputFormFileName	= string.Format("{0:D4}_{1}", prtItemGrp.FreePrtPprItemGrpCd, enterpriseCode);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/04 ADD
            frePrtPSet.OutputFormFileName = prtFormId;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/04 ADD
			frePrtPSet.EnterpriseCode		= enterpriseCode;
			frePrtPSet.DisplayName			= displayName;
			frePrtPSet.FreePrtPprItemGrpCd	= prtItemGrp.FreePrtPprItemGrpCd;
			frePrtPSet.PrintPaperUseDivcd	= prtItemGrp.PrintPaperUseDivcd;
			frePrtPSet.ExtractionPgId		= prtItemGrp.ExtractionPgId;
			frePrtPSet.ExtractionPgClassId	= prtItemGrp.ExtractionPgClassId;
			frePrtPSet.OutputPgId			= prtItemGrp.OutputPgId;
			frePrtPSet.OutputPgClassId		= prtItemGrp.OutputPgClassId;
			frePrtPSet.DataInputSystem		= prtItemGrp.DataInputSystem;
			frePrtPSet.ExtraSectionKindCd	= prtItemGrp.ExtraSectionKindCd;
			frePrtPSet.ExtraSectionSelExist = prtItemGrp.ExtraSectionSelExist;
			frePrtPSet.FormFeedLineCount	= formFeedLineCount;
			frePrtPSet.CrCharCnt			= crCharCnt;
			frePrtPSet.FreePrtPprSpPrpseCd	= prtItemGrp.FreePrtPprSpPrpseCd;
			frePrtPSet.PrintPosClassData	= printPosClassData;

			if (prtItemGrp.PrintPaperUseDivcd == 1)
				frePrtPSet.PrintPaperDivCd	= prtItemGrp.FreePrtPprItemGrpCd;

			return frePrtPSet;
		}

		/// <summary>
		/// 自由帳票抽出条件設定マスタ作成処理
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="outputFormFileName">出力ファイル名</param>
		/// <param name="userPrtPprIdDerivNo">ユーザー帳票ID枝番号</param>
		/// <returns>自由帳票抽出条件設定マスタリスト</returns>
		/// <remarks>
		/// <br>Note		: 自由帳票印字項目設定より自由帳票抽出条件設定をCreateします。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.05.10</br>
		/// </remarks>
		private List<FrePprECnd> CreateFrePprECndFromPrtItemSet(string enterpriseCode, string outputFormFileName, int userPrtPprIdDerivNo)
		{
			List<FrePprECnd> frePprECndList = new List<FrePprECnd>();
			foreach (PrtItemSetWork prtItemSet in _prtItemSetList)
			{
				if (prtItemSet.ExtraConditionDivCd != 0)
				{
					FrePprECnd frePprECnd = new FrePprECnd();
					frePprECnd.EnterpriseCode		= enterpriseCode;					// 企業コード
					frePprECnd.OutputFormFileName	= outputFormFileName;				// 出力ファイル名
					frePprECnd.UserPrtPprIdDerivNo	= userPrtPprIdDerivNo;				// ユーザー帳票ID枝番号
					frePprECnd.FrePrtPprExtraCondCd = prtItemSet.FreePrtPaperItemCd;	// 自由帳票抽出条件枝番
					frePprECnd.ExtraConditionDivCd	= prtItemSet.ExtraConditionDivCd;	// 抽出条件区分
					frePprECnd.ExtraConditionTypeCd	= prtItemSet.ExtraConditionTypeCd;	// 抽出条件タイプ
					frePprECnd.ExtraConditionTitle	= prtItemSet.FreePrtPaperItemNm;	// 抽出条件タイトル
					frePprECnd.DDName				= prtItemSet.DDName;				// DD名称
					frePprECnd.DDCharCnt			= prtItemSet.DDCharCnt;				// DD桁数
					frePprECnd.ExtraCondDetailGrpCd = prtItemSet.ExtraCondDetailGrpCd;	// 抽出条件明細グループコード
					frePprECnd.StExtraDateBaseCd	= 2;								// 抽出開始日付（基準）
					frePprECnd.EdExtraDateBaseCd	= 2;								// 抽出終了日付（基準）
					frePprECnd.DisplayOrder			= 999;
					frePprECnd.NecessaryExtraCondCd = prtItemSet.NecessaryExtraCondCd;	// 必須抽出条件区分
					frePprECnd.FileNm				= prtItemSet.FileNm;				// ファイル名称
					frePprECnd.InputCharCnt			= prtItemSet.InputCharCnt;			// 入力桁数
					frePprECndList.Add(frePprECnd);
				}
			}

			return frePprECndList;
		}

		/// <summary>
		/// 自由帳票ソート順位マスタマージ処理
		/// </summary>
		/// <param name="baseFrePprSrtOList">マージ対象自由帳票ソート順位LIST</param>
		/// <param name="overWriteFrePprSrtOList">上書き対象自由帳票ソート順位LIST</param>
		/// <returns>マージ済み自由帳票ソート順位LIST</returns>
		/// <remarks>
		/// <br>Note		: 自由帳票印字項目設定よりCreateしたデータと既存データのマージ処理を行います。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.05.10</br>
		/// </remarks>
		private List<FrePprSrtO> MergeFrePprSrtO(List<FrePprSrtO> baseFrePprSrtOList, List<FrePprSrtO> overWriteFrePprSrtOList)
		{
			if (overWriteFrePprSrtOList == null) overWriteFrePprSrtOList = new List<FrePprSrtO>();
			List<FrePprSrtO> retList = new List<FrePprSrtO>();
			foreach (FrePprSrtO baseFrePprSrtO in baseFrePprSrtOList)
			{
				FrePprSrtO findFrePprSrtO = overWriteFrePprSrtOList.Find(
					delegate(FrePprSrtO frePprSrtO)
					{
						if ((baseFrePprSrtO.EnterpriseCode		== frePprSrtO.EnterpriseCode) &&
							(baseFrePprSrtO.OutputFormFileName	== frePprSrtO.OutputFormFileName) &&
							(baseFrePprSrtO.UserPrtPprIdDerivNo	== frePprSrtO.UserPrtPprIdDerivNo) &&
							(baseFrePprSrtO.SortingOrderCode	== frePprSrtO.SortingOrderCode))
							return true;
						else
							return false;
					}
				);

				if (findFrePprSrtO != null)
					retList.Add(findFrePprSrtO);
				else
					retList.Add(baseFrePprSrtO);
			}

			return retList;
		}

		/// <summary>
		/// 自由帳票ソート順位マスタ作成処理
		/// </summary>
		/// <param name="enterpriseCode">企業コード</param>
		/// <param name="outputFormFileName">出力ファイル名</param>
		/// <param name="userPrtPprIdDerivNo">ユーザー帳票ID枝番号</param>
		/// <param name="fPSortInitList">自由帳票ソート順位初期値マスタリスト</param>
		/// <returns>自由帳票ソート順位LIST</returns>
		/// <remarks>
		/// <br>Note		: 自由帳票印字項目設定より自由帳票ソート順位をCreateします。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.05.10</br>
		/// </remarks>
		private List<FrePprSrtO> CreateFrePprSrtO(string enterpriseCode, string outputFormFileName, int userPrtPprIdDerivNo, List<FPSortInitWork> fPSortInitList)
		{
			List<FrePprSrtO> frePprSrtOList = new List<FrePprSrtO>();
			foreach (FPSortInitWork fPSortInit in fPSortInitList)
			{
				FrePprSrtO frePprSrtO = new FrePprSrtO();
				frePprSrtO.EnterpriseCode		= enterpriseCode;					// 企業コード
				frePprSrtO.OutputFormFileName	= outputFormFileName;				// 出力ファイル名
				frePprSrtO.UserPrtPprIdDerivNo	= userPrtPprIdDerivNo;				// ユーザー帳票ID枝番号
				frePprSrtO.SortingOrderCode		= fPSortInit.SortingOrderCode;		// ソート順位コード
				frePprSrtO.SortingOrder			= fPSortInit.SortingOrder;			// ソート順位
				frePprSrtO.FreePrtPaperItemNm	= fPSortInit.FreePrtPaperItemNm;	// 自由帳票項目名称
				frePprSrtO.DDName				= fPSortInit.DDName;				// DD名称
				frePprSrtO.FileNm				= fPSortInit.FileNm;				// ファイル名称
				frePprSrtO.SortingOrderDivCd	= fPSortInit.SortingOrderDivCd;		// 昇順降順区分
				frePprSrtOList.Add(frePprSrtO);
			}

			return frePprSrtOList;
		}

		/// <summary>
		/// 自由帳票抽出条件LIST変更チェック処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: 自由帳票抽出条件データが変更されていないかチェックします。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.05.10</br>
		/// </remarks>
		private bool IsFrePprECndListChanged()
		{
			// 自由帳票抽出条件設定のチェック
			if (_frePprECndList != null && _buf_frePprECndList != null)
			{
				// LIST内の件数が変更されているか
				if (_frePprECndList.Count != _buf_frePprECndList.Count)
					return true;

				// LIST内のデータが変更されているか
				foreach (FrePprECnd buf_frePprECnd in _buf_frePprECndList)
				{
					FrePprECnd findFrePprECnd = _frePprECndList.Find(
						delegate(FrePprECnd frePprECnd)
						{
							if ((buf_frePprECnd.EnterpriseCode == frePprECnd.EnterpriseCode) &&
								(buf_frePprECnd.OutputFormFileName == frePprECnd.OutputFormFileName) &&
								(buf_frePprECnd.UserPrtPprIdDerivNo == frePprECnd.UserPrtPprIdDerivNo) &&
								(buf_frePprECnd.FrePrtPprExtraCondCd == frePprECnd.FrePrtPprExtraCondCd))
							{
								return true;
							}
							else
							{
								return false;
							}
						}
					);

////////////////////////////////////////////// 2008.03.19 TERASAKA DEL STA //
//					if (findFrePprECnd == null || !findFrePprECnd.Equals(buf_frePprECnd))
// 2008.03.19 TERASAKA DEL END //////////////////////////////////////////////
////////////////////////////////////////////// 2008.03.19 TERASAKA ADD STA //
					if (findFrePprECnd == null || !findFrePprECnd.EqualsWithoutSystemDate(buf_frePprECnd))
// 2008.03.19 TERASAKA ADD END //////////////////////////////////////////////
						return true;
				}
			}

			return false;
		}

		/// <summary>
		/// 自由帳票ソート順位LIST変更チェック処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: 自由帳票ソート順位データが変更されていないかチェックします。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.05.10</br>
		/// </remarks>
		private bool IsFrePprSrtOListChanged()
		{
			// 自由帳票抽出条件設定のチェック
			if (_frePprSrtOList != null && _buf_frePprSrtOList != null)
			{
				// LIST内のデータが変更されているか
				foreach (FrePprSrtO buf_frePprSrtO in _buf_frePprSrtOList)
				{
					FrePprSrtO findFrePprSrtO = _frePprSrtOList.Find(
						delegate(FrePprSrtO frePprSrtO)
						{
							if ((buf_frePprSrtO.EnterpriseCode == frePprSrtO.EnterpriseCode) &&
								(buf_frePprSrtO.OutputFormFileName == frePprSrtO.OutputFormFileName) &&
								(buf_frePprSrtO.UserPrtPprIdDerivNo == frePprSrtO.UserPrtPprIdDerivNo) &&
								(buf_frePprSrtO.SortingOrderCode == frePprSrtO.SortingOrderCode))
							{
								return true;
							}
							else
							{
								return false;
							}
						}
					);

					if (findFrePprSrtO == null || !findFrePprSrtO.Equals(buf_frePprSrtO))
						return true;
				}
			}

			return false;
		}

		/// <summary>
		/// 未導入オプションデータ削除処理
		/// </summary>
		/// <param name="prtItemSetList">印字項目設定LIST</param>
		/// <remarks>
		/// <br>Note		: 印字項目設定LIST内のオプションチェックを行います。</br>
		/// <br>			: 未導入のオプション用項目はLISTより削除します。</br>
		/// <br>Programmer	: 22024 寺坂　誉志</br>
		/// <br>Date		: 2007.05.10</br>
		/// </remarks>
		private void RemoveUnContactData(List<PrtItemSetWork> prtItemSetList)
		{
			for (int ix = 0 ; ix != prtItemSetList.Count ; ix++)
			{
				PurchaseStatus status = PurchaseStatus.Uncontract;
				// 導入システムのチェック
				switch (prtItemSetList[ix].SystemDivCd)
				{
					case 1: status = LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_PAC_SF); break;
					case 2: status = LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_PAC_BK); break;
					case 3: status = LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_PAC_CS); break;
					default: status = PurchaseStatus.Contract; break;
				}

				if (status < PurchaseStatus.Contract)
				{
					prtItemSetList.Remove(prtItemSetList[ix]);
					ix--;
				}
				else
				{
					// オプションコードのチェック
					if (!string.IsNullOrEmpty(prtItemSetList[ix].OptionCode))
					{
						status = LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(prtItemSetList[ix].OptionCode);
						if (status < PurchaseStatus.Contract)
						{
							prtItemSetList.Remove(prtItemSetList[ix]);
							ix--;
						}
					}
				}
			}
		}
		#endregion
	}

	/// <summary>
	/// 印字項目設定比較クラス
	/// </summary>
	/// <remarks>
	/// <br>Note		: 印字項目設定をソートする際に使用するCompareクラスです。</br>
	/// <br>Programmer	: 22024 寺坂　誉志</br>
	/// <br>Date		: 2007.05.10</br>
	/// <br></br>
	/// <br>UpdateNote	: </br>
	/// </remarks>
	internal class FrePprECndCompare : IComparer<FrePprECnd>
	{
		#region PublicMethod
		/// <summary>
		/// 比較処理
		/// </summary>
		/// <param name="x">比較対象1</param>
		/// <param name="y">比較対象2</param>
		/// <returns>比較結果</returns>
		public int Compare(FrePprECnd x, FrePprECnd y)
		{
			int retCompare = 0;
			retCompare = x.DisplayOrder - y.DisplayOrder;
			if (retCompare == 0)
			{
				retCompare = y.NecessaryExtraCondCd - x.NecessaryExtraCondCd;
				if (retCompare == 0)
				{
					retCompare = x.FrePrtPprExtraCondCd - y.FrePrtPprExtraCondCd;
				}
			}
			return retCompare;
		}
		#endregion
	}
}

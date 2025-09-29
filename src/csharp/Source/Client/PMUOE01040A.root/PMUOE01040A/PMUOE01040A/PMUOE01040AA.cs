//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : ＵＯＥ送受信制御アクセスクラス
// プログラム概要   : ＵＯＥ送受信制御を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10402071-00 作成担当 : 立花 裕輔
// 作 成 日  2008/05/26  修正内容 : 新規作成
//           2009/05/25  修正内容 : ホンダ UOE WEB対応
//           2009/07/10  修正内容 : 96186 立花 裕輔 SCM対応
//----------------------------------------------------------------------------//
// 管理番号  10504551-00 作成担当 : 21024 佐々木 健
// 作 成 日  2009/09/24  修正内容 : 送信処理で明細削除できるように修正(MANTIS[0014303])
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : xuxh
// 修 正 日  2009/12/29  修正内容 :【要件No.2】																																							
//	                                発注先にトヨタを指定時には、リマーク２の入力は不可とする（連携時、ﾘﾏｰｸ2に連携番号として使用する為）																																							
//	                                仕入明細（発注データ）の作成を行い通信は行わない様にする																																							
//                       修正内容 :【要件No.3】
//                                  発注先の入力制御（トヨタは入力不可とする）を行う
//                                  トヨタ電子カタログで使用する送信・受信データの保存場所を設定する
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 修 正 日  2010/01/22  修正内容 : redmine#2554 進捗更新用メッセージ画面の追加																																																																												
//----------------------------------------------------------------------------//
// 管理番号  10601190-00 作成担当 : 楊明俊
// 作 成 日  2010/03/08  修正内容 : PM1006 
//                                  UOE発注先が「日産」の場合、UOE発注データのみを作成し、通信は行わないように修正
//----------------------------------------------------------------------------//
// 管理番号  10601191-00 作成担当 : gaoyh
// 作 成 日  2010/04/26  修正内容 : PM1007C 三菱UOE-WEB対応に伴う仕様追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30517 夏野 駿希
// 作 成 日  2010/07/05  修正内容 : Mantis.15654　SCMではない得意先で送信処理をした場合でもSCM送信画面が表示されてしまう件の修正
//----------------------------------------------------------------------------//
// 管理番号 10607734-00  作成担当 : liyp
// 作 成 日  2011/01/06  修正内容 : 通信を必要とするか判定するメソッドにWeb-UOEを追加
//----------------------------------------------------------------------------//
// 管理番号 10607734-00  作成担当 : 朱 猛
// 作 成 日  2011/01/30  修正内容 : UOE自動化改良
//----------------------------------------------------------------------------//
// 管理番号  10607734-01 作成担当 : liyp
// 作 成 日  2011/03/01  修正内容 : 業務区分は「発注」（固定）に制御する
//----------------------------------------------------------------------------//
// 管理番号  10702591-00 作成担当 : 施炳中
// 作 成 日  2011/05/10  修正内容 : 通信を必要とするか判定するメソッドにマツダWebUOEを追加
//----------------------------------------------------------------------------//
// 管理番号  10707327-00 作成担当 : 鄧潘ハ
// 作 成 日  2012/02/10  修正内容 : 2012/03/28配信分、Redmine#28406 発注送信後のデータ作成不具合についての対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2012/10/17  修正内容 : SCM障害対応 SCM連携未送信データ取得条件を修正 №10414
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : wangl2
// 修 正 日  2013/04/03  修正内容 : Redmine#35210の対応 「UOE手入力発注」で連番が全て "1" でエラーになる（№1802） 
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 脇田 靖之
// 作 成 日  2013/06/21  修正内容 : SCM障害対応 BLPリモート伝票が発行されない障害の修正
//----------------------------------------------------------------------------//
// 管理番号  10902931-00 作成担当 : 譚洪
// 作 成 日  2013/08/15  修正内容 : 発注処理(自動)処理の追加
//----------------------------------------------------------------------------//
// 管理番号  10902931-00 作成担当 : 譚洪
// 作 成 日  2014/03/24  修正内容 : 複数拠点の発注情報再取得の対応
//----------------------------------------------------------------------------//
// 管理番号  11001634-00  作成担当 : 鄧潘ハン
// 作 成 日  K2014/05/26  修正内容 : 自動発注エラーメッセージを出さないように修正とエラーログの更新
//----------------------------------------------------------------------------//
// 管理番号  11400910-00  作成担当 : 田建委
// 作 成 日  2018/07/26   修正内容 : Redmine#49725 UOE発注データ削除処理対応
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Windows.Forms;
using Broadleaf.Application.Remoting.ParamData;

// 2009/07/10 START >>>>>>
using System.IO;
using System.Diagnostics;
using Broadleaf.Application.Resources;
// 2009/07/10 END   <<<<<<

using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Threading; 
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Common;
using Broadleaf.Windows.Forms;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;

namespace Broadleaf.Application.Controller
{
  	/// <summary>
	/// ＵＯＥ送受信制御アクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : ＵＯＥ送受信制御アクセスクラス</br>
	/// <br>Programmer : 96186 立花裕輔</br>
	/// <br>Date       : 2008.05.26</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// <br>2008.05.26 men 新規作成</br>
    /// <br>Update Note  : 2009/05/25 96186 立花 裕輔</br>
    /// <br>              ・ホンダ UOE WEB対応</br>
    /// <br>Update Note  : 2009/09/24 21024 佐々木 健</br>
    /// <br>              ・送信処理で明細削除できるように修正(MANTIS[0014303])</br>
     /// <br>Update Note  : 2009/12/29 xuxh</br>
    /// <br>              ・【要件No.2】と【要件No.3】の修正</br>
    /// <br>UpdateNote    : 2010/01/22 李占川</br>
    /// <br>                redmine#2554 進捗更新用メッセージ画面の追加</br>
    /// <br>UpdateNote    : 2010/03/08 楊明俊</br>
    /// <br>                PM1006 UOE発注先が「日産」の場合、UOE発注データのみを作成し、通信は行わないように修正</br>
    /// <br>Update Note: 2011/03/01 liyp</br>
    /// <br>             業務区分は「発注」（固定）に制御する</br>
    /// <br>Update Note: 2011/05/10 施炳中</br>
    /// <br>             通信を必要とするか判定するメソッドにマツダWebUOEを追加</br>
    /// <br>Update Note: 2013/04/3 wangl2</br>
    /// <br>             「UOE手入力発注」で連番が全て "1" でエラーになる（№1802）</br>
    /// <br>Update Note: 2013/08/15 譚洪</br>
    /// <br>             発注処理(自動)処理の追加</br>
    /// <br>Update Note: K2014/05/26 鄧潘ハン</br>
    /// <br>             自動発注エラーメッセージを出さないように修正とエラーログの更新</br>
    /// <br>Update Note: 2014/09/16 30744 湯上 千加子</br>
    /// <br>             SCM仕掛一覧№10677対応</br>
    /// <br>Update Note: 2018/07/26 田建委</br>
    /// <br>             Redmine#49725 UOE発注データ削除処理対応</br>
    /// </remarks>
	public partial class UoeSndRcvCtlAcs
	{
		// ===================================================================================== //
		// コンストラクタ
		// ===================================================================================== //
		# region Constructors
		public UoeSndRcvCtlAcs()
		{
            //企業コードを取得する
            _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            //ＵＯＥ送受信制御初期化アクセスクラス
            _uoeSndRcvCtlInitAcs = UoeSndRcvCtlInitAcs.GetInstance();

			//ＵＯＥ送受信ＪＮＬアクセスクラス
			_uoeSndRcvJnlAcs = UoeSndRcvJnlAcs.GetInstance();

			//操作履歴ログアクセスクラス
			_uoeOprtnHisLogAcs = UoeOprtnHisLogAcs.GetInstance();
            _uoeOprtnHisLogAcs.LogDataMachineName = _uoeSndRcvJnlAcs.cashRegisterNo.ToString("d3");

            // ---- ADD 2013/08/15 譚洪 ---- >>>>>
            //OPT-CPM0110：フタバUOEオプション（個別）
            fuTaBaPs = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_FutabaUOECtl);
            if (fuTaBaPs == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                this._opt_FuTaBa = (int)Option.ON;
            }
            else
            {
                this._opt_FuTaBa = (int)Option.OFF;
            }
            // ---- ADD 2013/08/15 譚洪 ---- <<<<<

			//ＵＯＥ発注データアクセスクラス
            _uOEOrderDtlAcs = UOEOrderDtlAcs.GetInstance();

            // 2009/05/25 START >>>>>>
            //ＵＯＥ発注情報アクセスクラス
            _uoeOrderInfoAcs = UoeOrderInfoAcs.GetInstance();

            //回答データ更新アクセスクラス
            _uOEAnswerAcs = UOEAnswerAcs.GetInstance();

            //締日算出モジュールアクセスクラス
            _totalDayCalculator = TotalDayCalculator.GetInstance();
            // 2009/05/25 END   <<<<<<

            // 2009/07/10 START >>>>>>
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(
                         ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_SCM);
            // 2009/07/10 END   <<<<<<

            // --- ADD 2010/01/22 ---------->>>>>
            // デフォルト進捗更新イベントハンドラを設定
            UpdateProgress += new OnUpdateProgress(DefaultUpdateProgress);
            // --- ADD 2010/01/22 ----------<<<<<

		}
		# endregion

		// ===================================================================================== //
		// プライベート変数
		// ===================================================================================== //
		# region Private Members
        // ---- ADD 2013/08/15 譚洪 ---- >>>>>
        // ---DEL K2014/05/26 鄧潘ハン Redmine 42571 --------------------------------------->>>>>
        //Thread中、拠点関係
        //private const string SECTIONNAMESOLT = "SECTIONNAMESOLT";
        //private LocalDataStoreSlot sectionNameSolt = null;
        // ---DEL K2014/05/26 鄧潘ハン Redmine 42571 ---------------------------------------<<<<<
        //Thread中、メッセージ関係
        private const string MSGSHOWSOLT = "MSGSHOWSOLT";
        private LocalDataStoreSlot msgShowSolt = null;
        // ---DEL K2014/05/26 鄧潘ハン Redmine 42571 --------------------------------------->>>>>
        //Thread中、発注先名称関係
        //private const string UOESUPPLIERNAMESOLT = "UOESUPPLIERNAMESOLT";
        //private LocalDataStoreSlot uoeSupplierNameSolt = null;

        // --- ADD 2018/07/26 田建委 Redmine#49725 UOE発注データ削除処理対応 -------------------->>>>>
        // 保存月数の値設定用ファイルパス
        private string SaveMonthSetting = "PMUOE01040A_UserSetting.XML";
        // --- ADD 2018/07/26 田建委 Redmine#49725 UOE発注データ削除処理対応 --------------------<<<<<

        //PMCMN00900UA _pmCMN00900UA = null;
        // ---DEL K2014/05/26 鄧潘ハン Redmine 42571 ---------------------------------------<<<<<

        #region ■列挙体
        /// <summary>
        /// オプション有効有無
        /// </summary>
        public enum Option : int
        {
            /// <summary>無効ユーザ</summary>
            OFF = 0,
            /// <summary>有効ユーザ</summary>
            ON = 1,
        }
        #endregion

        /// <summary>テキスト出力オプション情報</summary>
        private int _opt_FuTaBa;//OPT-CPM0110：フタバUOEオプション（個別）

        //専用USB用
        Broadleaf.Application.Remoting.ParamData.PurchaseStatus fuTaBaPs;
        // ---- ADD 2013/08/15 譚洪 ---- <<<<<

		# region アクセスクラス
        //ＵＯＥ送受信制御初期化アクセスクラス
        private UoeSndRcvCtlInitAcs _uoeSndRcvCtlInitAcs = null;

		//ＵＯＥ発注データアクセスクラス
		private UOEOrderDtlAcs _uOEOrderDtlAcs = null;

		//ＵＯＥ送受信ＪＮＬアクセスクラス
		private UoeSndRcvJnlAcs _uoeSndRcvJnlAcs = null;

		//操作履歴ログアクセスクラス
		private UoeOprtnHisLogAcs _uoeOprtnHisLogAcs = null;

		//ＵＯＥ送信編集アクセスクラス
		private UoeSndEditAcs _uoeSndEditAcs = null;

		//ＵＯＥ受信編集アクセスクラス
		public UoeRcvEditAcs _uoeRcvEditAcs = null;

		//回答データ更新アクセスクラス
		public UOEAnswerAcs _uOEAnswerAcs = null;

        //売上・仕入データアクセスクラス
        public UOESalesStockAcs _uOESalesStockAcs = null;

        //ＵＯＥ送受信用ダイアログクラス
        private UoeSndRcvDialog _uoeSndRcvDialog = null;

        // 2009/05/25 START >>>>>>
        //ＵＯＥ発注情報アクセスクラス
        private UoeOrderInfoAcs _uoeOrderInfoAcs = null;

        // 締日算出モジュール
        private TotalDayCalculator _totalDayCalculator = null;
        // 2009/05/25 END   <<<<<<

        // 2009/07/10 START >>>>>>
        Broadleaf.Application.Remoting.ParamData.PurchaseStatus ps;
        // 2009/07/10 END   <<<<<<
        # endregion

		# region 条件クラス
        //企業コード
        private string _enterpriseCode = "";

		//ＵＯＥ送信制御条件クラス
		private UoeSndRcvCtlPara _uoeSndRcvCtlPara = null;

		//発注先Dictionary
		private Dictionary<Int32, UOESupplier> _uOESupplierDictionary = new Dictionary<int,UOESupplier>();

		# endregion

		# region 結果クラス
        private List<UOEOrderDtlWork> _uOEOrderDtlWorkList = null;  //UOE発注ワークリスト
        private List<StockDetailWork> _stockDetailWorkList = null;  //仕入明細ワークリスト
        private List<UOEOrderDtlWork> _deleteUOEOrderDTLWorkList = null;    // 削除用UOE発注ワークリスト    // 2009/09/24 Add

		//ＵＯＥ送信編集結果
		private List<UoeSndHed> _uoeSndHedList = null;

		//ＵＯＥ送信ヘッダークラス
		private UoeSndHed _uoeSndHed = new UoeSndHed();

		//ＵＯＥ送信明細クラス
		private UoeSndDtl _uoeSndDtl = new UoeSndDtl();

		//ＵＯＥ受信ヘッダークラス
		private UoeRecHed _uoeRecHed = new UoeRecHed();

		//ＵＯＥ発注先マスタクラス
		private UOESupplier _uOESupplier = new UOESupplier();

        // UOE売上伝票クラス
        private List<UoeSales> _uoeSalesList = null;

		# endregion

		# endregion

		// ===================================================================================== //
		// 定数
		// ===================================================================================== //
		# region Const Members
		# endregion

		// ===================================================================================== //
		// デリゲート
		// ===================================================================================== //
		# region Delegate
		# endregion

		// ===================================================================================== //
		// イベント
		// ===================================================================================== //
		# region Event
		# endregion

		// ===================================================================================== //
		// プロパティ
		// ===================================================================================== //
		# region Properties
        # region 送受信ＪＮＬ＜DataSet＞
        /// <summary>
        /// 送受信ＪＮＬ＜DataSet＞
        /// </summary>
        public DataSet UoeJnlDataSet
        {
            get { return this._uoeSndRcvJnlAcs.UoeJnlDataSet; }
        }
        # endregion

        # region 送受信ＪＮＬ(発注)＜DataTable＞
        /// <summary>
        /// 送受信ＪＮＬ(発注)＜DataTable＞
        /// </summary>
        public DataTable OrderTable
        {
            get { return this.UoeJnlDataSet.Tables[OrderSndRcvJnlSchema.CT_OrderSndRcvJnlDataTable]; }
        }
        # endregion

        # region 仕入明細＜DataTable＞
        /// <summary>
        /// 仕入明細＜DataTable＞
        /// </summary>
        public DataTable StockDetailTable
        {
            get { return this.UoeJnlDataSet.Tables[StockDetailSchema.CT_StockDetailDataTable]; }
        }
        # endregion

        // 2009/05/25 START >>>>>>
        # region 仕入データ＜DataTable＞
        /// <summary>
        /// 仕入データ＜DataTable＞
        /// </summary>
        public DataTable StockSlipTable
        {
            get { return this.UoeJnlDataSet.Tables[StockSlipSchema.CT_StockSlipDataTable]; }
        }
        # endregion

        # region UOE発注＜DataTable＞
        /// <summary>
        /// UOE発注＜DataTable＞
        /// </summary>
        public DataTable UOEOrderDtlTable
        {
            get { return this.UoeJnlDataSet.Tables[UOEOrderDtlSchema.CT_UOEOrderDtlDataTable]; }
        }
        # endregion
        // 2009/05/25 END   <<<<<<

		# endregion

		// ===================================================================================== //
		// パブリックメソッド
		// ===================================================================================== //
		# region Public Methods
        # region ＵＯＥ送受信制御
        /// <summary>
        /// ＵＯＥ送受信制御
        /// </summary>
        /// <param name="para">ＵＯＥ送受信制御パラメータ</param>
        /// <param name="uOEOrderDtlWorklist">UOE発注データリスト</param>
        /// <param name="stockDetailWorkList">仕入明細データリスト</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        public int UoeSndRcvCtl(UoeSndRcvCtlPara para, List<UOEOrderDtlWork> uOEOrderDtlWorkList, List<StockDetailWork> stockDetailWorkList, out string message)
		{
			//変数の初期化
			int status = (int)EnumUoeConst.Status.ct_NORMAL;
			message = "";

			try
			{
				//ＵＯＥ送受信条件抽出クラスの保存
				_uoeSndRcvCtlPara = para;
                _uOEOrderDtlWorkList = uOEOrderDtlWorkList;
                _stockDetailWorkList = stockDetailWorkList;

                // ---- ADD 2013/08/15 譚洪 ---- >>>>>
                if (this._opt_FuTaBa == (int)Option.ON)
                {
                    msgShowSolt = Thread.GetNamedDataSlot(MSGSHOWSOLT);
                    if (Thread.GetData(msgShowSolt) != null)
                    {
                        _uoeSndRcvJnlAcs = new UoeSndRcvJnlAcs();
                        _uoeSndRcvJnlAcs = UoeSndRcvJnlAcs.GetInstance();
                        //操作履歴ログアクセスクラス
                        _uoeOprtnHisLogAcs = UoeOprtnHisLogAcs.GetInstance();
                        _uoeOprtnHisLogAcs.LogDataMachineName = _uoeSndRcvJnlAcs.cashRegisterNo.ToString("d3");
                    } 
                }
                // ---- ADD 2013/08/15 譚洪 ---- <<<<<

				//ＵＯＥ送受信制御初期化
				if ((status = UoeSndRcvCtlInit(out message)) != (int)EnumUoeConst.Status.ct_NORMAL)
				{
					return (status);
				}

				//ＵＯＥ送受信制御メイン
				status = UoeSndRcvCtlMain(out message);
			}
			catch (Exception ex)
			{
				status = -1;
				message = ex.Message;
                // ---ADD K2014/05/26 鄧潘ハン Redmine 42571 --------------------------------------->>>>>
                //フタバUSB専用
                if (this._opt_FuTaBa == (int)Option.ON && Thread.GetData(msgShowSolt) != null)
                {
                    message = "【UOE発注エラー】" + message + "ST=" + status.ToString()
                    + "【復旧方法】送信処理を実行して下さい。";
                }
                // ---ADD K2014/05/26 鄧潘ハン Redmine 42571 ---------------------------------------<<<<<
			}
			return (status);
		}

        // 2009/09/24 Add >>>
        /// <summary>
        /// ＵＯＥ送受信制御（発注取消機能付き）
        /// </summary>
        /// <param name="para">ＵＯＥ送受信制御パラメータ</param>
        /// <param name="uOEOrderDtlWorkList">UOE発注データリスト</param>
        /// <param name="stockDetailWorkList">仕入明細データリスト</param>
        /// <param name="deleteUOEOrderDtlWorkList">取消用UOE発注データリスト</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        public int UoeSndRcvCtl(UoeSndRcvCtlPara para, List<UOEOrderDtlWork> uOEOrderDtlWorkList, List<StockDetailWork> stockDetailWorkList, List<UOEOrderDtlWork> deleteUOEOrderDtlWorkList, out string message)
        {
            _deleteUOEOrderDTLWorkList = deleteUOEOrderDtlWorkList;

            // 既存のメソッドを使用する。
            return this.UoeSndRcvCtl(para, uOEOrderDtlWorkList, stockDetailWorkList, out message);
        }
        // 2009/09/24 Add <<<

        // ---------------------------- ADD 2009/12/29 xuxh -------------------------------->>>>>
        /// <summary>
        /// 送受信(通信)が可能であるか判断する
        /// </summary>
        /// <param name="uoeSupplier">ＵＯＥ発注先</param>
        /// <returns></returns>
        /// UOE発注先が以下の場合、送受信(通信)できません
        /// ①ホンダe-Parts
        /// ②トヨタ電子カタログ
        /// ③日産Web-UOE
        /// <remarks>
        /// <br>UpdateNote : 2010/03/08 楊明俊 UOE発注先が「日産」の場合、UOE発注データのみを作成し、通信は行わないように修正</br>
        /// </remarks>
        public static bool CanSendAndReceive(UOESupplier uoeSupplier)
        {
            if (uoeSupplier == null) return false;
            // ---UPD 2010/03/08 ---------------------------------------->>>>>
            //switch (uoeSupplier.CommAssemblyId)
            //{
            //    case EnumUoeConst.ctCommAssemblyId_0502:
            //        return false; // ホンダe-Parts
            //    case EnumUoeConst.ctCommAssemblyId_0103:
            //        return false; // トヨタ電子カタログ
            //    default:
            //        return true;
            //}
            return !IsUoeWeb(uoeSupplier.CommAssemblyId);
            // ---UPD 2010/03/08 ----------------------------------------<<<<<
        }

        // ---------------------------- ADD 2009/12/29 xuxh --------------------------------<<<<<
        // ---ADD 2010/03/08 ---------------------------------------->>>>>
        /// <summary>
        /// 通信アセンブリIDがUOE(web)であるの判断
        /// </summary>
        /// <param name="commAssemblyId">通信アセンブリID</param>
        /// <returns>
        /// 通信アセンブリIDが以下の場合、UOE(web)であるか判断します。
        /// ①ホンダe-Parts
        /// ②トヨタ電子カタログ
        /// ③日産Web-UOE
        /// </returns>
        /// <remarks>
        /// <br>Note       : 通信アセンブリIDがUOE(web)であるを判断します。</br>
        /// <br>Programmer : 楊明俊</br>
        /// <br>Date       : 2010/03/08</br>
        /// <br>UpdateNote : 2011/01/06 liyp </br>
        /// <br>            通信を必要とするか判定するメソッドにWeb-UOEを追加</br>
        /// <br>UpdateNote : 2011/01/30 朱 猛 </br>
        /// <br>            UOE自動化改良</br>
        /// <br>Update Note: 2011/03/01 liyp</br>
        /// <br>             業務区分は「発注」（固定）に制御する</br>
        /// <br>Update Note: 2011/05/10 施炳中</br>
        /// <br>             通信を必要とするか判定するメソッドにマツダWebUOEを追加</br>
        /// </remarks>
        public static bool IsUoeWeb(String commAssemblyId)
        {
            switch (commAssemblyId)
            {
                case EnumUoeConst.ctCommAssemblyId_0502:
                    return true; // ホンダe-Parts
                case EnumUoeConst.ctCommAssemblyId_0103:
                    return true; // トヨタ電子カタログ
                case EnumUoeConst.ctCommAssemblyId_0203:
                    return true; // 日産web-UOE
                // ---ADD 2010/04/26 gaoyh ---------------------------------------->>>>>
                case EnumUoeConst.ctCommAssemblyId_0302:
                    return true; // 三菱web-UOE
                // ---ADD 2010/04/26 gaoyh ----------------------------------------<<<<<
                // ---ADD 2011/01/06 liyp ---------------------------------------->>>>>
                case EnumUoeConst.ctCommAssemblyId_0204:
                	return true;
                case EnumUoeConst.ctCommAssemblyId_0303:
                	return true;
                // ---ADD 2011/01/06 liyp ----------------------------------------<<<<<
                // ---ADD 2011/01/30 朱 猛 ---------------------------------------->>>>>
                case EnumUoeConst.ctCommAssemblyId_0104:
                    return true; // トヨタ自動処理
                // ---ADD 2011/01/30 朱 猛 ----------------------------------------<<<<<
                // ---ADD 2011/03/01 liyp ----------------------------------------->>>>>
                case EnumUoeConst.ctCommAssemblyId_0205:
                    return true;
                case EnumUoeConst.ctCommAssemblyId_0206:
                    return true;
                // ---ADD 2011/03/01 liyp -----------------------------------------<<<<<
                // ---ADD 2011/05/10  ----------------------------------------->>>>>
                case EnumUoeConst.ctCommAssemblyId_0403:
                    return true;
                // ---ADD 2011/05/10  -----------------------------------------<<<<<
                default:
                    return false;
            }
        }
        // ---ADD 2010/03/08 ----------------------------------------<<<<<
		# endregion

        // ------------- ADD 譚洪 2014/03/24 -------- >>>>>>>>
        # region 新拠点の場合、キャッシュー情報を再取得する
        /// <summary>
        /// 新拠点の場合、キャッシュー情報を再取得する
        /// </summary>
        /// <returns></returns>
        public void UoeSndRcvCtlAcsForMoreSection()
        {
            _uoeSndRcvJnlAcs.UoeSndRcvJnlAcsForMoreSection();
        }
        #endregion
        // ------------- ADD 譚洪　2014/03/24 -------- <<<<<<<<<<

        # endregion

        // ===================================================================================== //
		// プライベートメソッド
		// ===================================================================================== //
		# region Private Methods

		# region ＵＯＥ送受信制御初期化
		/// <summary>
		/// ＵＯＥ送受信制御初期化
		/// </summary>
		/// <param name="message"></param>
		/// <returns></returns>
		private int UoeSndRcvCtlInit(out string message)
		{
			//変数の初期化
			int status = (int)EnumUoeConst.Status.ct_NORMAL;
			message = "";

			try
			{
				//ＵＯＥ送信編集結果
				if (_uoeSndHedList == null)
				{
					_uoeSndHedList = new List<UoeSndHed>();
				}
				else
				{
					_uoeSndHedList.Clear();
				}

				//発注先Dictionary
				if (_uOESupplierDictionary == null)
				{
					_uOESupplierDictionary = new Dictionary<int, UOESupplier>();
				}
				else
				{
					_uOESupplierDictionary.Clear();
				}
                //データテーブルの初期化
                _uoeSndRcvJnlAcs.SchemaClear();
			}
			catch (Exception ex)
			{
				status = -1;
				message = ex.Message;

                // ---ADD K2014/05/26 鄧潘ハン Redmine 42571 --------------------------------------->>>>>
                //フタバUSB専用
                if (this._opt_FuTaBa == (int)Option.ON && Thread.GetData(msgShowSolt) != null)
                {
                    message = "【UOE発注エラー】" + message + "ST=" + status.ToString()
                    + "【復旧方法】送信処理を実行して下さい。";
                }
                // ---ADD K2014/05/26 鄧潘ハン Redmine 42571 ---------------------------------------<<<<<
			}
			return (status);
		}
		# endregion

		# region 処理対象のＵＯＥ発注先情報を保存
		/// <summary>
		/// 処理対象のＵＯＥ発注先情報を保存
		/// </summary>
		/// <param name="cd"></param>
		/// <returns></returns>
		private bool GetUoeSupplierDictionary(int cd)
		{
			bool status = false;

			if (_uOESupplierDictionary.ContainsKey(cd) != true)
			{
				UOESupplier uOESupplier = _uoeSndRcvJnlAcs.SearchUOESupplier(cd);
				if (uOESupplier != null)
				{
					_uOESupplierDictionary.Add(cd, uOESupplier);
				}
				status = true;
			}
			return status;
		}
		# endregion

        # region ＵＯＥ発注行番号の最大値取得
        /// <summary>
        /// ＵＯＥ発注行番号の最大値取得
        /// </summary>
        /// <param name="commAssemblyId">通信アセンブリＩＤ</param>
        /// <param name="businessCode">業務区分</param>
        /// <returns>ＵＯＥ発注行番号の最大値</returns>
        private int GetMaxOrderRowNo(string commAssemblyId, int businessCode)
        {
            int maxOrderRowNo = 0;

            //発注
            if(businessCode == (int)EnumUoeConst.TerminalDiv.ct_Order)
            {
                switch (commAssemblyId)
                {
                    case EnumUoeConst.ctCommAssemblyId_0102://トヨタ
                        maxOrderRowNo = 3;
                        break;
	                case EnumUoeConst.ctCommAssemblyId_0202://ニッサン
                        maxOrderRowNo = 4;
                        break;
	                case EnumUoeConst.ctCommAssemblyId_0301://ミツビシ
                        maxOrderRowNo = 3;
                        break;
	                case EnumUoeConst.ctCommAssemblyId_0401://旧マツダ
                        maxOrderRowNo = 6;
                        break;
	                case EnumUoeConst.ctCommAssemblyId_0402://新マツダ
                        maxOrderRowNo = 6;
                        break;
                    case EnumUoeConst.ctCommAssemblyId_0501://ホンダ
                        maxOrderRowNo = 10;
                        break;
                    default:                                //優良メーカー
                        maxOrderRowNo = 5;
                        break;
                }
            }
            //見積
            else if(businessCode == (int)EnumUoeConst.TerminalDiv.ct_Estmt)
            {
                switch (commAssemblyId)
                {
                    case EnumUoeConst.ctCommAssemblyId_0102://トヨタ
                    case EnumUoeConst.ctCommAssemblyId_0202://ニッサン
                    case EnumUoeConst.ctCommAssemblyId_0301://ミツビシ
                    case EnumUoeConst.ctCommAssemblyId_0401://旧マツダ
                    case EnumUoeConst.ctCommAssemblyId_0402://新マツダ
                    case EnumUoeConst.ctCommAssemblyId_0501://ホンダ
                        maxOrderRowNo = 10;
                        break;
                    default:                                //優良メーカー
                        maxOrderRowNo = 0;
                        break;
                }
            }
            //在庫
            else if(businessCode == (int)EnumUoeConst.TerminalDiv.ct_Stock)
            {
                switch (commAssemblyId)
                {
                    case EnumUoeConst.ctCommAssemblyId_0102://トヨタ
                        maxOrderRowNo = 6;
                        break;
	                case EnumUoeConst.ctCommAssemblyId_0202://ニッサン
                        maxOrderRowNo = 5;
                        break;
	                case EnumUoeConst.ctCommAssemblyId_0301://ミツビシ
                        maxOrderRowNo = 6;
                        break;
	                case EnumUoeConst.ctCommAssemblyId_0401://旧マツダ
                        maxOrderRowNo = 15;
                        break;
	                case EnumUoeConst.ctCommAssemblyId_0402://新マツダ
                        maxOrderRowNo = 5;
                        break;
                    case EnumUoeConst.ctCommAssemblyId_0501://ホンダ
                        maxOrderRowNo = 15;
                        break;
                    default:                                //優良メーカー
                        maxOrderRowNo = 5;
                        break;
                }
            }
            return (maxOrderRowNo);
        }
        #endregion

		# region ＵＯＥ送受信制御メイン

        // --- ADD 2010/01/22 ---------->>>>>
        #region 進捗更新
        /// <summary>
        /// 送受信の進捗列挙型
        /// </summary>
        public enum SendAndReceiveProgress : int
        {
            /// <summary>なし</summary>
            None,
            /// <summary>メイン処理開始</summary>
            BeginMain,

            /// <summary>DBの更新が完了</summary>
            DoneUpdateDB,

            /// <summary>メイン処理完了</summary>
            DoneMain
        }

        /// <summary>
        /// 進捗更新イベントパラメータ
        /// </summary>
        public class UpdateProgressEventArgs : EventArgs
        {
            /// <summary>進捗状態</summary>
            private SendAndReceiveProgress _progressState;
            /// <summary>進捗状態を取得または設定します。</summary>
            public SendAndReceiveProgress ProgressState
            {
                get { return _progressState; }
                set { _progressState = value; }
            }

            /// <summary>メッセージ</summary>
            private string _message;
            /// <summary>メッセージを取得または設定します。</summary>
            public string Message
            {
                get { return _message; }
                set { _message = value; }
            }

            /// <summary>
            /// デフォルトコンストラクタ
            /// </summary>
            public UpdateProgressEventArgs() : this(SendAndReceiveProgress.None, string.Empty) { }

            /// <summary>
            /// カスタムコンストラクタ
            /// </summary>
            /// <param name="progressState">進捗状態</param>
            /// <param name="message">メッセージ</param>
            public UpdateProgressEventArgs(
                SendAndReceiveProgress progressState,
                string message
            )
                : base()
            {
                _message = message;
                _progressState = progressState;
            }

            /// <summary>
            /// 進捗を設定します。
            /// </summary>
            /// <param name="progressState">進捗状態</param>
            /// <param name="message">メッセージ</param>
            public void SetProgress(SendAndReceiveProgress progressState, string message)
            {
                ProgressState = progressState;
                Message = message;
            }
        }

        /// <summary>
        /// 進捗更新イベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        public delegate void OnUpdateProgress(object sender, UpdateProgressEventArgs e);

        /// <summary>
        /// デフォルト進捗更新イベントハンドラ
        /// </summary>
        /// <param name="sender">イベントソース</param>
        /// <param name="e">イベントパラメータ</param>
        private static void DefaultUpdateProgress(object sender, UpdateProgressEventArgs e)
        {
            // 何もしない
        }

        /// <summary>進捗更新イベント</summary>
        public event OnUpdateProgress UpdateProgress;

        #endregion  進捗更新
        // --- ADD 2010/01/22 ----------<<<<<

		/// <summary>
		/// ＵＯＥ送受信制御メイン
		/// </summary>
		/// <param name="message"></param>
		/// <returns></returns>
        /// <remarks>
        /// <br>UpdateNote : 2010/01/22 李占川</br>
        /// <br>             redmine#2554 進捗更新用メッセージ画面の追加</br>
        /// <br>Update Note: 2012/02/10 鄧潘ハン</br>
        /// <br>管理番号   : 10707327-00 2012/03/28配信分</br>
        /// <br>             Redmine#28406 発注送信後のデータ作成不具合についての対応</br>
        /// <br>Update Note: 2018/07/26 田建委</br>
        /// <br>管理番号   : 11400910-00</br>
        /// <br>             Redmine#49725 UOE発注データ削除処理対応</br>
        /// </remarks>
		private int UoeSndRcvCtlMain(out string message)
		{
            // ---- ADD 2013/08/15 譚洪 --- >>>>>
            string msgBak = string.Empty;
            //int statusBak = 0;// DEL K2014/05/26 鄧潘ハン Redmine 42571;
            //フタバUSB専用
            if (this._opt_FuTaBa == (int)Option.ON)
            {
                msgShowSolt = Thread.GetNamedDataSlot(MSGSHOWSOLT);
                //this._pmCMN00900UA = new PMCMN00900UA();// DEL K2014/05/26 鄧潘ハン Redmine 42571
            }
            // ---- ADD 2013/08/15 譚洪 --- <<<<<

            // --- ADD 2010/01/22 ---------->>>>>
            // 進捗更新用
            UpdateProgressEventArgs progressInfo = new UpdateProgressEventArgs(
                SendAndReceiveProgress.BeginMain,
                "UOE送受信制御メイン処理開始"
            );
            UpdateProgress(this, progressInfo);
            // --- ADD 2010/01/22 ----------<<<<<

			//変数の初期化
            string procNm = "UoeSndRcvCtlMain";
            string asseNm = "";
			int status = (int)EnumUoeConst.Status.ct_NORMAL;
			message = "";

            try
            {
                // 2009/09/24 Add >>>
                //-----------------------------------------------------------
                // 発注取消リストが設定されている場合に、発注取消を行う
                //-----------------------------------------------------------
                #region 発注取消
                if (this._deleteUOEOrderDTLWorkList != null && this._deleteUOEOrderDTLWorkList.Count > 0)
                {
                    asseNm = "発注データ削除";
                    logd_update(procNm, asseNm, (Int32)EnumUoeConst.ctLogDataOperationCd.ct_START, 0, "");
                    status = this._uOEOrderDtlAcs.Delete(this._deleteUOEOrderDTLWorkList, out message);
                    logd_update(procNm, asseNm, (Int32)EnumUoeConst.ctLogDataOperationCd.ct_END, 0, "");
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }
                }

                // 発注対象が無い場合は処理を終了する。
                if (this._stockDetailWorkList == null || this._stockDetailWorkList.Count == 0)
                {
                    return (int)EnumUoeConst.Status.ct_NORMAL;
                }
                #endregion
                // 2009/09/24 Add <<<

                //-----------------------------------------------------------
                // 仕入明細データの不正データを削除
                //-----------------------------------------------------------
                # region ＵＯＥ発注データに発注番号・発注行番号を付加
                for (int i = 0; i < _stockDetailWorkList.Count; i++)
                {
                    //仕入担当者名称
                    if (_stockDetailWorkList[i].StockAgentName.Length > 16)
                    {
                        string strRemove = _stockDetailWorkList[i].StockAgentName.Remove(16);
                        _stockDetailWorkList[i].StockAgentName = strRemove;
                    }

                    //仕入入力者名称
                    if (_stockDetailWorkList[i].StockInputName.Length > 16)
                    {
                        string strRemove = _stockDetailWorkList[i].StockInputName.Remove(16);
                        _stockDetailWorkList[i].StockInputName = strRemove;
                    }
                }
                #endregion

                //-----------------------------------------------------------
                // ＵＯＥ発注データに発注番号・発注行番号を付加
                //-----------------------------------------------------------
                # region ＵＯＥ発注データに発注番号・発注行番号を付加
                # region （発注用）ＵＯＥ発注データに発注番号・発注行番号を付加
                if (_uoeSndRcvCtlPara.BusinessCode == (int)EnumUoeConst.TerminalDiv.ct_Order)
                {
                    //処理中フラグの設定・ＵＯＥ発注先一覧の取得
                    DateTime dateTimeNow = DateTime.Now;

                    for (int i = 0; i < _uOEOrderDtlWorkList.Count; i++)
                    {
                        //受信日付（ReceiveDateRF）にシステム日付をセット
                        _uOEOrderDtlWorkList[i].ReceiveDate = dateTimeNow;

                        //回答埋め込みデータの場合
                        if (_uOEOrderDtlWorkList[i].DataSendCode == (int)EnumUoeConst.ctDataSendCode.ct_Insert)
                        {
                            //送信フラグ「9:正常終了」を設定
                            _uOEOrderDtlWorkList[i].DataSendCode = (int)EnumUoeConst.ctDataSendCode.ct_OK;

                            //復旧フラグ「9:正常終了」を設定
                            _uOEOrderDtlWorkList[i].DataRecoverDiv = (int)EnumUoeConst.ctDataRecoverDiv.ct_NO;
                        }
                        //未処理データの場合
                        else
                        {
                            //送信フラグ「1:処理中」を設定
                            _uOEOrderDtlWorkList[i].DataSendCode = (int)EnumUoeConst.ctDataSendCode.ct_Process;

                            //復旧フラグ「0:処理中」を設定
                            _uOEOrderDtlWorkList[i].DataRecoverDiv = (int)EnumUoeConst.ctDataRecoverDiv.ct_NonProcess;
                        }

                        //更新対象のＵＯＥ発注先一覧の取得
                        GetUoeSupplierDictionary(_uOEOrderDtlWorkList[i].UOESupplierCd);
                    }

                    if ((status = _uOEOrderDtlAcs.WriteUOEOrderDtl(
                            ref _uOEOrderDtlWorkList,
                            ref _stockDetailWorkList,
                            out message)) != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // ---- DEL 2013/08/15 譚洪 --- >>>>>
                        //TMsgDisp.Show(
                        //    //this,
                        //    emErrorLevel.ERR_LEVEL_STOP,
                        //    asseNm,
                        //    message,
                        //    status,
                        //    MessageBoxButtons.OK);
                        // ---- DEL 2013/08/15 譚洪 --- <<<<<

                        // ---- ADD 2013/08/15 譚洪 --- >>>>>
                         //フタバUSB専用
                        if (this._opt_FuTaBa == (int)Option.ON)
                        {
                        
                            // ---DEL K2014/05/26 鄧潘ハン Redmine 42571 --------------------------------------->>>>>
                            ////Thread中、拠点情報を取得
                            //sectionNameSolt = Thread.GetNamedDataSlot(SECTIONNAMESOLT);
                            //string sectionNameStr = string.Empty;
                        
                            //if (Thread.GetData(sectionNameSolt) != null)
                            //{
                            //    sectionNameStr = (string)Thread.GetData(sectionNameSolt);
                            //}
                            ////Thread中、発注先情報を取得
                            //uoeSupplierNameSolt = Thread.GetNamedDataSlot(UOESUPPLIERNAMESOLT);
                            //string uoeSupplierNameStr = string.Empty;
                            //if (Thread.GetData(uoeSupplierNameSolt) != null)
                            //{
                            //    uoeSupplierNameStr = (string)Thread.GetData(uoeSupplierNameSolt);
                            //}
                            // ---DEL K2014/05/26 鄧潘ハン Redmine 42571 ---------------------------------------<<<<<
                            //発注処理(手動)である場合
                            if (Thread.GetData(msgShowSolt) == null || (Thread.GetData(msgShowSolt) != null && (Int32)Thread.GetData(msgShowSolt) == 2))
                            {
                                TMsgDisp.Show(
                                    //this,
                                    emErrorLevel.ERR_LEVEL_STOP,
                                    asseNm,
                                    message,
                                    status,
                                    MessageBoxButtons.OK);
                            }
                            else
                            {
                                //発注処理(自動)である場合
                                // ---DEL K2014/05/26 鄧潘ハン Redmine 42571 --------------------------------------->>>>>
                                //message = message + " \r\n "
                                //    + " \r\n"
                                //    + "UOE発注ログ表示を確認して下さい。 \r\n"
                                //    + " \r\n"
                                //    + "発注先：" + uoeSupplierNameStr
                                //    + " \r\n"
                                //    + "拠点：" + sectionNameStr;
                                //_pmCMN00900UA.ErrorMsgShow(message);
                                // ---DEL K2014/05/26 鄧潘ハン Redmine 42571 ---------------------------------------<<<<<
                            }

                            // ---ADD K2014/05/26 鄧潘ハン Redmine 42571 --------------------------------------->>>>>
                            if (Thread.GetData(msgShowSolt) != null)
                            {
                                if (message.IndexOf("シェアチェックエラー") >= 0)
                                {
                                    message = "【UOE発注データ更新エラー】シェアチェックエラー、送信準備処理に失敗しました。ST="
                                        + status.ToString() + "【復旧方法】送信処理を実行して下さい。";
                                }
                                else
                                {
                                    message = "【UOE発注データ更新エラー】送信準備処理に失敗しました。ST="
                                        + status.ToString() + "【復旧方法】送信処理を実行して下さい。";
                                }
                            }
                            // ---ADD K2014/05/26 鄧潘ハン Redmine 42571 ---------------------------------------<<<<<
                        }
                        else
                        {
                            TMsgDisp.Show(
                                //this,
                                emErrorLevel.ERR_LEVEL_STOP,
                                asseNm,
                                message,
                                status,
                                MessageBoxButtons.OK);
                        
                        }
                        // ---- ADD 2013/08/15 譚洪 --- <<<<<

                        return (status);
                    }
                }
                #endregion

                # region （見積・在庫用）ＵＯＥ発注データに発注番号・発注行番号を付加
                //ＵＯＥ発注データクラスにUOE発注番号・行番号を設定する -------------------------------------------
                if ((_uoeSndRcvCtlPara.BusinessCode == (int)EnumUoeConst.TerminalDiv.ct_Estmt)
                || (_uoeSndRcvCtlPara.BusinessCode == (int)EnumUoeConst.TerminalDiv.ct_Stock))
                {
                    # region _uOEOrderDtlWorkListを発注先単位に並び替える
                    if (_uoeSndRcvCtlPara.SystemDivCd != (int)EnumUoeConst.ctSystemDivCd.ct_Input)
                    {
                        UOESupplierCdComparer rc = new UOESupplierCdComparer();
                        _uOEOrderDtlWorkList.Sort(rc);
                    }
                    #endregion
                    # region UOE発注番号・行番号を設定
                    //UOE発注番号 UOE発注行番号の初期化
                    int uOESalesOrderNo = 1;                        //UOE発注番号
                    int uOESalesOrderRowNo = 1;                     //UOE発注行番号
                    int savUOESupplierCd = _uOEOrderDtlWorkList[0].UOESupplierCd;//UOE発注先コード
                    int maxOrderRowNo = GetMaxOrderRowNo(_uOEOrderDtlWorkList[0].CommAssemblyId, _uoeSndRcvCtlPara.BusinessCode); ;

                    for (int i = 0; i < _uOEOrderDtlWorkList.Count; i++)
                    {
                        //更新対象のＵＯＥ発注先一覧の取得
                        GetUoeSupplierDictionary(_uOEOrderDtlWorkList[i].UOESupplierCd);

                        //発注先が変わった場合
                        if (savUOESupplierCd != _uOEOrderDtlWorkList[i].UOESupplierCd)
                        {
                            savUOESupplierCd = _uOEOrderDtlWorkList[i].UOESupplierCd;
                            maxOrderRowNo = GetMaxOrderRowNo(_uOEOrderDtlWorkList[i].CommAssemblyId, _uoeSndRcvCtlPara.BusinessCode);
                            uOESalesOrderNo++;
                            uOESalesOrderRowNo = 1;
                        }
                        //UOE発注番号 UOE発注行番号の設定処理
                        if (uOESalesOrderRowNo > maxOrderRowNo)
                        {
                            uOESalesOrderNo++;
                            uOESalesOrderRowNo = 1;
                        }

                        //UOE発注番号 UOE発注行番号の設定処理
                        _uOEOrderDtlWorkList[i].UOESalesOrderNo = uOESalesOrderNo;
                        _uOEOrderDtlWorkList[i].UOESalesOrderRowNo = uOESalesOrderRowNo;
                        uOESalesOrderRowNo++;
                    }
                    #endregion

                    #region ADD 2013/04/3 Redmine#35210 wangl2 for No.1802の対応

                    ArrayList uOEOrderDtlWorkList = new ArrayList();
                    foreach (UOEOrderDtlWork wk in _uOEOrderDtlWorkList)
                    {
                        uOEOrderDtlWorkList.Add(wk);
                    }
                    IIOWriteUOEOdrDtlDB iIOWriteUOEOdrDtlDB = (IIOWriteUOEOdrDtlDB)MediationIOWriteUOEOdrDtlDB.GetIOWriteUOEOdrDtlDB();
                    // UOE発注データの追加、更新
                    status = iIOWriteUOEOdrDtlDB.WriteUOESalesOrderNo(ref uOEOrderDtlWorkList);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        _uOEOrderDtlWorkList = new List<UOEOrderDtlWork>();
                        foreach (UOEOrderDtlWork wk in uOEOrderDtlWorkList)
                        {
                            _uOEOrderDtlWorkList.Add(wk);
                        }
                    }
                    #endregion
                }
                #endregion
                # endregion

                //-----------------------------------------------------------
                // 送受信ＪＮＬテーブル・ＵＯＥ発注データテーブル・仕入明細テーブルの作成
                //-----------------------------------------------------------
                # region 送受信ＪＮＬテーブル・ＵＯＥ発注データテーブル・仕入明細テーブルの作成
                //ＵＯＥ発注データ→ＵＯＥ発注データテーブルの作成 ------------------------------------------------
                status = _uoeSndRcvJnlAcs.ToDataTableFromUOEOrderDtlList(_uOEOrderDtlWorkList, out message);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {

                    // ---ADD K2014/05/26 鄧潘ハン Redmine 42571 --------------------------------------->>>>>
                    //フタバUSB専用
                    if (this._opt_FuTaBa == (int)Option.ON && Thread.GetData(msgShowSolt) != null)
                    { 
                        message = "【送信前編集エラー】送信準備処理に失敗しました。ST="+status.ToString()
                        +"【復旧方法】発注送信エラーリストから送信データの解除を行い、復旧処理から再発注、又は回答埋込を実行して下さい。";
                    }
                    // ---ADD K2014/05/26 鄧潘ハン Redmine 42571 ---------------------------------------<<<<<
                    return (status);
                }

                //仕入明細→仕入明細テーブルの作成 ----------------------------------------------------------------
                if (_uoeSndRcvCtlPara.BusinessCode == (int)EnumUoeConst.TerminalDiv.ct_Order)
                {
                    foreach (StockDetailWork stockDetailWork in _stockDetailWorkList)
                    {
                        status = _uoeSndRcvJnlAcs.InsertTableFromStockDetailWork(StockDetailTable, stockDetailWork, "", 0, out message);
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // ---ADD K2014/05/26 鄧潘ハン Redmine 42571 --------------------------------------->>>>>
                            //フタバUSB専用
                            if (this._opt_FuTaBa == (int)Option.ON && Thread.GetData(msgShowSolt) != null)
                            {
                                message = "【送信前編集エラー】送信準備処理に失敗しました。ST=" + status.ToString()
                                + "【復旧方法】発注送信エラーリストから送信データの解除を行い、復旧処理から再発注、又は回答埋込を実行して下さい。";
                            }
                            // ---ADD K2014/05/26 鄧潘ハン Redmine 42571 ---------------------------------------<<<<<
                            return (status);
                        }
                    }

                    //仕入明細テーブルに共通伝票番号・共通伝票行番号を設定
                    int supplierFormal = _stockDetailWorkList[0].SupplierFormal;
                    foreach (UOEOrderDtlWork uOEOrderDtlWork in _uOEOrderDtlWorkList)
                    {
                        status = _uoeSndRcvJnlAcs.UpdateTableFromStockDetailWork(
                                                                StockDetailTable,
                                                                supplierFormal,
                                                                uOEOrderDtlWork.DtlRelationGuid,
                                                                uOEOrderDtlWork.UOESalesOrderNo.ToString("d9"),
                                                                uOEOrderDtlWork.UOESalesOrderRowNo,
                                                                out message);
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // ---ADD K2014/05/26 鄧潘ハン Redmine 42571 --------------------------------------->>>>>
                            //フタバUSB専用
                            if (this._opt_FuTaBa == (int)Option.ON && Thread.GetData(msgShowSolt) != null)
                            {
                                message = "【送信前編集エラー】送信準備処理に失敗しました。ST=" + status.ToString()
                                + "【復旧方法】発注送信エラーリストから送信データの解除を行い、復旧処理から再発注、又は回答埋込を実行して下さい。";
                            }
                            // ---ADD K2014/05/26 鄧潘ハン Redmine 42571 ---------------------------------------<<<<<
                            return (status);
                        }
                    }
                }

                //ＵＯＥ発注データ→送受信ＪＮＬテーブルの作成 ----------------------------------------------------
                //業務区分
                switch (_uoeSndRcvCtlPara.BusinessCode)
                {
                    case (int)EnumUoeConst.TerminalDiv.ct_Order:	//発注
                        status = _uoeSndRcvJnlAcs.orderJnlFromDtlWrite(_uOEOrderDtlWorkList, out message);
                        break;
                    case (int)EnumUoeConst.TerminalDiv.ct_Estmt:	//見積
                        status = _uoeSndRcvJnlAcs.estmtJnlFromDtlWrite(_uOEOrderDtlWorkList, out message);
                        break;
                    case (int)EnumUoeConst.TerminalDiv.ct_Stock:	//在庫確認
                        status = _uoeSndRcvJnlAcs.stockJnlFromDtlWrite(_uOEOrderDtlWorkList, out message);
                        break;
                    case (int)EnumUoeConst.TerminalDiv.ct_Cancel:	//取消処理
                        status = _uOEOrderDtlAcs.Delete(_uOEOrderDtlWorkList, out message);
                        return (status);
                }
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ---ADD K2014/05/26 鄧潘ハン Redmine 42571 --------------------------------------->>>>>
                    //フタバUSB専用
                    if (this._opt_FuTaBa == (int)Option.ON && Thread.GetData(msgShowSolt) != null)
                    {
                        message = "【送信前編集エラー】送信準備処理に失敗しました。ST=" + status.ToString()
                        + "【復旧方法】発注送信エラーリストから送信データの解除を行い、復旧処理から再発注、又は回答埋込を実行して下さい。";
                    }
                    // ---ADD K2014/05/26 鄧潘ハン Redmine 42571 ---------------------------------------<<<<<
                    return (status);
                }
                #endregion

                //-----------------------------------------------------------
                // 送信編集
                //-----------------------------------------------------------
                # region 送信編集
                //送信編集 ----------------------------------------------------------------------------------------
                if ((status = UoeSndEditCall(out message)) != (int)EnumUoeConst.Status.ct_NORMAL)
                {
                    // ---ADD K2014/05/26 鄧潘ハン Redmine 42571 --------------------------------------->>>>>
                    //フタバUSB専用
                    if (this._opt_FuTaBa == (int)Option.ON && Thread.GetData(msgShowSolt) != null)
                    {
                        message = "【送信前編集エラー】送信準備処理に失敗しました。ST=" + status.ToString()
                        + "【復旧方法】発注送信エラーリストから送信データの解除を行い、復旧処理から再発注、又は回答埋込を実行して下さい。";
                    }
                    // ---ADD K2014/05/26 鄧潘ハン Redmine 42571 ---------------------------------------<<<<<
                    return (status);
                }
                #endregion

                //-----------------------------------------------------------
                // 送受信処理＆受信編集
                //-----------------------------------------------------------
                # region 送受信処理＆受信編集
                if ((status = UoeSndRcvCall(out message)) != (int)EnumUoeConst.Status.ct_NORMAL)
                {
                    //return (status);
                }

                // ---DEL K2014/05/26 鄧潘ハン Redmine 42571 --------------------------------------->>>>>
                // ---- ADD 2013/08/15 譚洪 --- >>>>>
                //フタバUSB専用
                //if (this._opt_FuTaBa == (int)Option.ON && Thread.GetData(msgShowSolt) != null)
                //{
                //    msgBak = message;
                //    statusBak = status;
                //}
                // ---- DEL 2013/08/15 譚洪 --- <<<<<
                // ---DEL K2014/05/26 鄧潘ハン Redmine 42571 ---------------------------------------<<<<<
                // ---ADD K2014/05/26 鄧潘ハン Redmine 42571 --------------------------------------->>>>>
                //フタバUSB専用
                if (this._opt_FuTaBa == (int)Option.ON && Thread.GetData(msgShowSolt) != null)
                {
                    msgBak = message;
                }
                // ---ADD K2014/05/26 鄧潘ハン Redmine 42571 ---------------------------------------<<<<<

                status = (int)EnumUoeConst.Status.ct_NORMAL;
                message = "";
                #endregion

                //-----------------------------------------------------------
                // 回答データ更新処理
                //-----------------------------------------------------------
                # region 回答データ更新処理
                if (_uoeSndRcvCtlPara.BusinessCode == (int)(EnumUoeConst.TerminalDiv.ct_Order))
                {
                    if (_uOEAnswerAcs == null)
                    {
                        _uOEAnswerAcs = new UOEAnswerAcs();
                    }

                    asseNm = "発注データ更新";
                    logd_update(procNm, asseNm, (Int32)EnumUoeConst.ctLogDataOperationCd.ct_START, 0, "");

                    foreach (Int32 key in _uOESupplierDictionary.Keys)
                    {
                        # region ＵＯＥ発注先マスタの取得
                        // ＵＯＥ発注先マスタの取得
                        UOESupplier uOESupplier = _uOESupplierDictionary[key];
                        if (uOESupplier == null) continue;
                        # endregion

                        // 発注データ更新処理
                        status = _uOEAnswerAcs.UpDtAnswer(uOESupplier, out message);
                        if (status != (int)EnumUoeConst.Status.ct_NORMAL)
                        {
                            break;
                        }
                    }

                    logd_update(procNm, asseNm, (Int32)EnumUoeConst.ctLogDataOperationCd.ct_END, status, message);
                    // ---ADD K2014/05/26 鄧潘ハン Redmine 42571 --------------------------------------->>>>>
                    if (status == (int)EnumUoeConst.Status.ct_NORMAL && this._opt_FuTaBa == (int)Option.ON && Thread.GetData(msgShowSolt) != null)
                    {
                        message = msgBak;
                    }
                    // ---ADD K2014/05/26 鄧潘ハン Redmine 42571 ---------------------------------------<<<<<
                    if (status != (int)EnumUoeConst.Status.ct_NORMAL)
                    {
                        // ---- ADD 2013/08/15 譚洪 --- >>>>>
                        //フタバUSB専用
                        if (this._opt_FuTaBa == (int)Option.ON)
                        {
                            // ---DEL K2014/05/26 鄧潘ハン Redmine 42571 --------------------------------------->>>>>
                            //if ((Thread.GetData(msgShowSolt) != null && (Int32)Thread.GetData(msgShowSolt) != 2))
                            //{
                            //    //前回メッセージがある場合
                            //    if (string.IsNullOrEmpty(msgBak))
                            //    {
                            //        //Thread中、拠点情報を取得
                            //        sectionNameSolt = Thread.GetNamedDataSlot(SECTIONNAMESOLT);
                            //        string sectionNameStr = string.Empty;
                            //        if (Thread.GetData(sectionNameSolt) != null)
                            //        {
                            //            sectionNameStr = (string)Thread.GetData(sectionNameSolt);
                            //        }

                            //        //Thread中、発注情報を取得
                            //        uoeSupplierNameSolt = Thread.GetNamedDataSlot(UOESUPPLIERNAMESOLT);
                            //        string uoeSupplierNameStr = string.Empty;
                            //        if (Thread.GetData(uoeSupplierNameSolt) != null)
                            //        {
                            //            uoeSupplierNameStr = (string)Thread.GetData(uoeSupplierNameSolt);
                            //        }

                            //        message = "\r\n"
                            //        + "回答データが更新失敗しました。 \r\n"
                            //        + " \r\n"
                            //        + "UOE発注ログ表示を確認して下さい。 \r\n"
                            //        + " \r\n"
                            //        + "発注先：" + uoeSupplierNameStr
                            //        + " \r\n"
                            //        + "拠点：" + sectionNameStr;
                            //        _pmCMN00900UA.ErrorMsgShow(message);

                            //        msgBak = message;
                            //        statusBak = 1001;
                            //        status = 1001;
                            //    }
                            //}
                            //else
                            //{
                            //    statusBak = 1001;
                            //    status = 1001;
                            //}
                            // ---DEL K2014/05/26 鄧潘ハン Redmine 42571 ---------------------------------------<<<<<
                            // ---ADD K2014/05/26 鄧潘ハン Redmine 42571 --------------------------------------->>>>>
                            if (Thread.GetData(msgShowSolt) != null)
                            {
                                if (message.IndexOf("シェアチェックエラー") >= 0)
                                {
                                    message = "【UOE発注データ更新エラー】シェアチェックエラー、回答データ更新処理に失敗しました。ST="
                                        + status.ToString() + "【復旧方法】発注送信エラーリストから送信データの解除を行い、復旧処理から再発注、又は回答埋込を実行して下さい。";
                                }
                                else
                                    {
                                    message = "【UOE発注データ更新エラー】回答データ更新処理に失敗しました。ST="
                                        + status.ToString() + "【復旧方法】発注送信エラーリストから送信データの解除を行い、復旧処理から再発注、又は回答埋込を実行して下さい。";
                                    }
                            }
                            // ---ADD K2014/05/26 鄧潘ハン Redmine 42571 ---------------------------------------<<<<<



                        }
                        // ---- ADD 2013/08/15 譚洪 --- <<<<<

                        return (status);
                    }
                }
                # endregion

                //-----------------------------------------------------------
                // 売上・仕入データ作成処理
                //-----------------------------------------------------------
                # region 売上・仕入データ作成処理
                //売上・仕入データ作成処理
                _uoeSalesList = null;
                if ((_uoeSndRcvCtlPara.BusinessCode == (int)(EnumUoeConst.TerminalDiv.ct_Order))
                && ((_uoeSndRcvCtlPara.SystemDivCd == (int)EnumUoeConst.ctSystemDivCd.ct_Slip)
                  || (_uoeSndRcvCtlPara.SystemDivCd == (int)EnumUoeConst.ctSystemDivCd.ct_Input)
                  || (_uoeSndRcvCtlPara.SystemDivCd == (int)EnumUoeConst.ctSystemDivCd.ct_Search)))
                {
                    if (_uOESalesStockAcs == null)
                    {
                        _uOESalesStockAcs = new UOESalesStockAcs();
                    }

                    asseNm = "売上・仕入データ作成";
                    logd_update(procNm, asseNm, (Int32)EnumUoeConst.ctLogDataOperationCd.ct_START, 0, "");

                    status = _uOESalesStockAcs.UpDtSalesStock(_uoeSndRcvCtlPara, out _uoeSalesList, out message);

                    logd_update(procNm, asseNm, (Int32)EnumUoeConst.ctLogDataOperationCd.ct_END, status, message);

                    if (status != (int)EnumUoeConst.Status.ct_NORMAL)
                    {
                        //---ADD 鄧潘ハン 2012/02/10 Redmine#28406------>>>>>
                        if (_uOEOrderDtlWorkList[0].UpdAssemblyId1 == "PMUOE01001U:8.10.1.0")
                        {
                            TMsgDisp.Show(
                                //this,
                            emErrorLevel.ERR_LEVEL_STOP,
                            asseNm,
                            message,
                            status,
                            MessageBoxButtons.OK);
                            return (status);
                        }
                        else
                        {
                            return (status);
                        }
                        //---ADD 鄧潘ハン 2012/02/10 Redmine#28406------<<<<<
                    }
                }
                #endregion

                // --- DEL 2013/06/21 Y.Wakita ---------->>>>>
                ////-----------------------------------------------------------
                //// ＵＯＥ伝票印刷呼び出し
                ////-----------------------------------------------------------
                //# region ＵＯＥ伝票印刷呼び出し
                //if ((_uoeSndRcvCtlPara.BusinessCode == (int)EnumUoeConst.TerminalDiv.ct_Order)
                //&& (_uoeSndRcvCtlPara.SystemDivCd == (int)EnumUoeConst.ctSystemDivCd.ct_Slip)
                //&& (_uoeSalesList != null))
                //{
                //    if (_uoeSalesList.Count > 0)
                //    {
                //        // UOE伝票印刷条件セット
                //        UOESlipPrintCndtn slipPrintCndtn = new UOESlipPrintCndtn();
                //        slipPrintCndtn.EnterpriseCode = _enterpriseCode;
                //        slipPrintCndtn.UOESalesList = _uoeSalesList;

                //        // 伝票印刷
                //        DCCMN02000UA printDisp = new DCCMN02000UA();
                //        printDisp.ShowDialog(slipPrintCndtn, true);
                //    }
                //}
                //#endregion
                // --- DEL 2013/06/21 Y.Wakita ----------<<<<<

                // 2009/07/10 START >>>>>>
                //-----------------------------------------------------------
                // ＳＣＭ回答送信処理
                //-----------------------------------------------------------
                # region ＳＣＭ回答送信処理
                if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
                {
                    // 2010/07/30 Add >>>
                    if (_uOESalesStockAcs != null)
                    {
                        // 2010/07/30 Add <<<
                        // 2010/07/05 Add >>>
                        if (_uOESalesStockAcs.scmFlg)
                        {
                            // 2010/07/05 Add <<<
                            if ((_uoeSndRcvCtlPara.BusinessCode == (int)EnumUoeConst.TerminalDiv.ct_Order)
                            && (_uoeSndRcvCtlPara.SystemDivCd == (int)EnumUoeConst.ctSystemDivCd.ct_Slip))
                            {
                                // ADD 2012/10/17 湯上 SCM障害対応 №10414------------------------------->>>>>
                                List<string> salesSlipNumList = new List<string>();
                                foreach (DataRow salesSlipRow in _uOESalesStockAcs.SalesSlipTable.Rows)
                                {
                                    if (salesSlipRow[SalesSlipSchema.ct_Col_SalesSlipNum].ToString().Trim().Length != 0)
                                    {
                                        salesSlipNumList.Add(salesSlipRow[SalesSlipSchema.ct_Col_SalesSlipNum].ToString().Trim());
                                    }
                                }
                                // ADD 2012/10/17 湯上 SCM障害対応 №10414-------------------------------<<<<<
                                //起動時パス
                                string directoryName = Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]);

                                if (directoryName.Length > 0)
                                {
                                    if (directoryName[directoryName.Length - 1] != '\\')
                                    {
                                        directoryName = directoryName + "\\";
                                    }
                                }
                                string startInfoFileName = directoryName + "PMSCM01100U.EXE";

                                //起動時パラメータ
                                string param = Environment.GetCommandLineArgs()[1] + " " +
                                               Environment.GetCommandLineArgs()[2];

                                // ADD 2012/10/17 湯上 SCM障害対応 №10414------------------------------->>>>>
                                string salesSlipNum = string.Empty;
                                // 回答送信処理時に対象となる売上伝票番号リストをパラメータにセットする
                                if (salesSlipNumList != null && salesSlipNumList.Count != 0)
                                {
                                    for (int i = 0; i < salesSlipNumList.Count; i++)
                                    {
                                        if (i != 0)
                                        {
                                            salesSlipNum += ",";
                                        }
                                        salesSlipNum += salesSlipNumList[i].ToString();
                                    }
                                    // ADD 2014/09/16 SCM仕掛一覧№10677対応 ------------------------------------->>>>>
                                    Process p = Process.Start(startInfoFileName, param + " /A" + " 0:0:" + salesSlipNum);
                                    p.WaitForExit();
                                    // ADD 2014/09/16 SCM仕掛一覧№10677対応 -------------------------------------<<<<<
                                }
                                // ADD 2012/10/17 湯上 SCM障害対応 №10414-------------------------------<<<<<

                                // --- UPD 2013/06/21 Y.Wakita ---------->>>>>
                                //// UPD 2012/10/17 湯上 SCM障害対応 №10414------------------------------->>>>>
                                ////Process.Start(startInfoFileName, param + " /A");
                                //Process.Start(startInfoFileName, param + " /A" + " 0:0:" + salesSlipNum);
                                //// UPD 2012/10/17 湯上 SCM障害対応 №10414-------------------------------<<<<<
                                // DEL 2014/09/16 SCM仕掛一覧№10677対応 ------------------------------------->>>>>
                                //Process p = Process.Start(startInfoFileName, param + " /A" + " 0:0:" + salesSlipNum);
                                //p.WaitForExit();
                                // DEL 2014/09/16 SCM仕掛一覧№10677対応 -------------------------------------<<<<<
                                // --- UPD 2013/06/21 Y.Wakita ----------<<<<<

                            }
                        }   // 2010/07/05 Add
                    }   // 2010/07/30 Add
                }
                # endregion
                // 2009/07/10 END   <<<<<<

                // --- ADD 2013/06/21 Y.Wakita ---------->>>>>
                //-----------------------------------------------------------
                // ＵＯＥ伝票印刷呼び出し
                //-----------------------------------------------------------
                # region ＵＯＥ伝票印刷呼び出し
                if ((_uoeSndRcvCtlPara.BusinessCode == (int)EnumUoeConst.TerminalDiv.ct_Order)
                && (_uoeSndRcvCtlPara.SystemDivCd == (int)EnumUoeConst.ctSystemDivCd.ct_Slip)
                && (_uoeSalesList != null))
                {
                    if (_uoeSalesList.Count > 0)
                    {
                        // UOE伝票印刷条件セット
                        UOESlipPrintCndtn slipPrintCndtn = new UOESlipPrintCndtn();
                        slipPrintCndtn.EnterpriseCode = _enterpriseCode;
                        slipPrintCndtn.UOESalesList = _uoeSalesList;

                        // 伝票印刷
                        DCCMN02000UA printDisp = new DCCMN02000UA();
                        printDisp.ShowDialog(slipPrintCndtn, true);
                    }
                }
                #endregion
                // --- ADD 2013/06/21 Y.Wakita ----------<<<<<

                // --- ADD 2010/01/22 ---------->>>>>
                // DBの更新が完了
                progressInfo.SetProgress(SendAndReceiveProgress.DoneUpdateDB, "DBの更新が完了しました。");
                UpdateProgress(this, progressInfo);
                // --- ADD 2010/01/22 ----------<<<<<

                //-----------------------------------------------------------
                // 結果表示処理
                //-----------------------------------------------------------
                # region 結果表示処理
                # region UOE発注先コードの一覧取得
                //UOE発注先コードの一覧取得
                List<int> uOESupplierCdList = new List<int>();
                foreach (UoeSndHed uoeSndHed in _uoeSndHedList)
                {
                    uOESupplierCdList.Add(uoeSndHed.UOESupplierCd);
                }
                # endregion

                # region 通信結果表示
                //通信結果表示
                List<OrderSndRcvJnl> _orderSndRcvJnlList = _uoeSndRcvJnlAcs.GetOrderSndRcvJnlList(uOESupplierCdList);

                if (_uoeSndRcvCtlPara.BusinessCode == (int)(EnumUoeConst.TerminalDiv.ct_Order))
                {
                    asseNm = "通信結果表示";
                    logd_update(procNm, asseNm, (Int32)EnumUoeConst.ctLogDataOperationCd.ct_START, 0, "");

                    UoeSndRcvResultAcs uoeSndRcvResultAcs = new UoeSndRcvResultAcs(_orderSndRcvJnlList);

                    // ---- ADD 2013/08/15 譚洪 --- >>>>>
                    //フタバUSB専用ではない、
                    //発注処理(手動)と発注処理(自動)ではない
                    //発注処理(手動)である場合
                    if (this._opt_FuTaBa == (int)Option.OFF 
                        || Thread.GetData(msgShowSolt) == null 
                        || (Thread.GetData(msgShowSolt) != null && (Int32)Thread.GetData(msgShowSolt) == 2))
                    {
                        uoeSndRcvResultAcs.ShowDialog();
                    }
                    // ---- ADD 2013/08/15 譚洪 --- <<<<<

                    //uoeSndRcvResultAcs.ShowDialog(); // DEL 2013/08/15 譚洪

                    logd_update(procNm, asseNm, (Int32)EnumUoeConst.ctLogDataOperationCd.ct_END, 0, "");
                }
                # endregion

                # region 発注回答表示
                //発注回答表示
                _orderSndRcvJnlList = _uoeSndRcvJnlAcs.GetOrderSndRcvJnlList(uOESupplierCdList, (int)EnumUoeConst.ctDataRecoverDiv.ct_NO);

                if ((_uoeSndRcvCtlPara.BusinessCode == (int)(EnumUoeConst.TerminalDiv.ct_Order))
                && (_orderSndRcvJnlList != null))
                {
                    if (_orderSndRcvJnlList.Count > 0)
                    {
                        asseNm = "発注回答表示";
                        logd_update(procNm, asseNm, (Int32)EnumUoeConst.ctLogDataOperationCd.ct_START, 0, "");

                        // ---- DEL 2013/08/15 譚洪 --- >>>>>
                        //PMUOE04102UA pMUOE04102UA = new PMUOE04102UA(_orderSndRcvJnlList);
                        //pMUOE04102UA.ShowDialog();
                        // ---- DEL 2013/08/15 譚洪 --- <<<<<

                        // ---- ADD 2013/08/15 譚洪 --- >>>>>
                        //フタバUSB専用ではない
                        //発注処理(手動)と発注処理(自動)ではない
                        //発注処理(手動)である場合
                        if (this._opt_FuTaBa == (int)Option.OFF
                            || Thread.GetData(msgShowSolt) == null
                            || (Thread.GetData(msgShowSolt) != null && (Int32)Thread.GetData(msgShowSolt) == 2))
                        {
                            PMUOE04102UA pMUOE04102UA = new PMUOE04102UA(_orderSndRcvJnlList);
                            pMUOE04102UA.ShowDialog();
                        }
                        // ---- ADD 2013/08/15 譚洪 --- <<<<<

                        logd_update(procNm, asseNm, (Int32)EnumUoeConst.ctLogDataOperationCd.ct_END, 0, "");
                    }
                }
                # endregion

                # region 見積回答表示
                //見積回答表示
                List<EstmtSndRcvJnl> _estmtSndRcvJnlList = _uoeSndRcvJnlAcs.GetEstmtSndRcvJnlList(uOESupplierCdList, (int)EnumUoeConst.ctDataRecoverDiv.ct_NO);
                if ((_uoeSndRcvCtlPara.BusinessCode == (int)(EnumUoeConst.TerminalDiv.ct_Estmt))
                && (_estmtSndRcvJnlList != null))
                {
                    if (_estmtSndRcvJnlList.Count > 0)
                    {
                        asseNm = "見積回答表示";
                        logd_update(procNm, asseNm, (Int32)EnumUoeConst.ctLogDataOperationCd.ct_START, 0, "");
                        PMUOE04111UA pMUOE04111UA = new PMUOE04111UA(_estmtSndRcvJnlList);
                        pMUOE04111UA.ShowDialog();

                        logd_update(procNm, asseNm, (Int32)EnumUoeConst.ctLogDataOperationCd.ct_END, 0, "");
                    }
                }
                # endregion

                # region 在庫回答表示
                //在庫回答表示
                List<StockSndRcvJnl> _stockSndRcvJnlList = _uoeSndRcvJnlAcs.GetStockSndRcvJnlList(uOESupplierCdList, (int)EnumUoeConst.ctDataRecoverDiv.ct_NO);
                if ((_uoeSndRcvCtlPara.BusinessCode == (int)(EnumUoeConst.TerminalDiv.ct_Stock))
                && (_stockSndRcvJnlList != null))
                {
                    if (_stockSndRcvJnlList.Count > 0)
                    {
                        asseNm = "在庫回答表示";
                        logd_update(procNm, asseNm, (Int32)EnumUoeConst.ctLogDataOperationCd.ct_START, 0, "");
                        PMUOE04121UA pMUOE04121UA = new PMUOE04121UA(_stockSndRcvJnlList);
                        pMUOE04121UA.ShowDialog();

                        logd_update(procNm, asseNm, (Int32)EnumUoeConst.ctLogDataOperationCd.ct_END, 0, "");
                    }
                }
                # endregion
                # endregion

                // --- ADD 2018/07/26 田建委 Redmine#49725 UOE発注データ削除処理対応 -------------------->>>>>
                // 過去のUOE発注データの削除を行う
                this.DeleteUoeOrderData();
                // --- ADD 2018/07/26 田建委 Redmine#49725 UOE発注データ削除処理対応 --------------------<<<<<
            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
                // ---DEL K2014/05/26 鄧潘ハン Redmine 42571 --------------------------------------->>>>>
                //TMsgDisp.Show(
                //    //this,
                //    emErrorLevel.ERR_LEVEL_STOP,
                //    asseNm,
                //    message,
                //    status,
                //    MessageBoxButtons.OK);
                // ---DEL K2014/05/26 鄧潘ハン Redmine 42571 ---------------------------------------<<<<<

                // ---ADD K2014/05/26 鄧潘ハン Redmine 42571 --------------------------------------->>>>>
                if(this._opt_FuTaBa == (int)Option.ON)
                {
                    //卸商発注処理(自動)ではない
                     if(!(Thread.GetData(msgShowSolt) != null
                         && (Int32)Thread.GetData(msgShowSolt) == 1))

                     {
                            TMsgDisp.Show(
                            //this,
                            emErrorLevel.ERR_LEVEL_STOP,
                            asseNm,
                            message,
                            status,
                            MessageBoxButtons.OK);
                     
                     }

                     if (Thread.GetData(msgShowSolt) != null)
                     {
                         message = "【UOE発注エラー】" + message + "ST=" + status.ToString();
                     }
                }
                else
                {
                TMsgDisp.Show(
                    //this,
                    emErrorLevel.ERR_LEVEL_STOP,
                    asseNm,
                    message,
                    status,
                    MessageBoxButtons.OK);
                
                }
                // ---ADD K2014/05/26 鄧潘ハン Redmine 42571 ---------------------------------------<<<<<

            }
            // --- ADD 2010/01/22 ---------->>>>>
            finally
            {
                // ---DEL K2014/05/26 鄧潘ハン Redmine 42571 --------------------------------------->>>>>
                // ---- ADD 2013/08/15 譚洪 --- >>>>>
                //フタバUSB専用
                //if (this._opt_FuTaBa == (int)Option.ON && Thread.GetData(msgShowSolt) != null && !string.IsNullOrEmpty(msgBak))
                //{
                //    message = msgBak;
                //    status = statusBak;
                //}
                // ---- ADD 2013/08/15 譚洪 --- <<<<<
                // ---DEL K2014/05/26 鄧潘ハン Redmine 42571 ---------------------------------------<<<<<

                progressInfo.SetProgress(SendAndReceiveProgress.DoneMain, "UOE送受信制御メイン処理完了");
                UpdateProgress(this, progressInfo);
            }
            // --- ADD 2010/01/22 ----------<<<<<

			return (status);
		}

        // --- ADD 2018/07/26 田建委 Redmine#49725 UOE発注データ削除処理対応 -------------------->>>>>
        /// <summary>
        /// UOE発注データ削除処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : UOE発注データ削除処理を行う。</br>
        /// <br>Programmer  : 田建委</br>
        /// <br>Date        : 2018/07/26</br>
        /// </remarks>
        private void DeleteUoeOrderData()
        {
            // xmlファイルから保存月数の取得
            RetentionMonthsInfo info = new RetentionMonthsInfo();
            info = this.ReadXml();
            // UOE発注データの削除日の取得
            if (info.RetentionMonths > 0)
            {
                string baseDate = DateTime.Now.AddMonths(-1 * info.RetentionMonths).ToString("yyyyMMdd");
                int inputDay;
                int delcnt;
                Int32.TryParse(baseDate, out inputDay);
                // リモートオブジェクト
                IUOEOrderDtlDB uOEOrderDtlDB = MediationUOEOrderDtlDB.GetUOEOrderDtlDB();
                uOEOrderDtlDB.DeleteForce(_enterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode.Trim(), inputDay, out delcnt);
            }
        }
       
        /// <summary>
        /// UOE発注データの保存月数読込処理
        /// </summary>
        /// <returns> UOE発注データの保存月数</returns>
        /// <remarks>
        /// <br>Note        : UOE発注データの保存月数を取得する。</br>
        /// <br>Programmer  : 田建委</br>
        /// <br>Date        : 2018/07/26</br>
        /// </remarks>
        private RetentionMonthsInfo ReadXml()
        {
            RetentionMonthsInfo info = null;

            if (UserSettingController.ExistUserSetting(System.IO.Path.Combine(ConstantManagement_ClientDirectory.UISettings, SaveMonthSetting)))
            {
                try
                {
                    // XMLから抽出条件アイテムクラス配列にデシリアライズする
                    info = UserSettingController.DeserializeUserSetting<RetentionMonthsInfo>(System.IO.Path.Combine(ConstantManagement_ClientDirectory.UISettings, SaveMonthSetting));
                }
                catch (InvalidOperationException)
                {
                    if (info == null)
                    {
                        info = new RetentionMonthsInfo(0);
                    }
                }
            }
            else
            {
                info = new RetentionMonthsInfo(0);
            }

            return info;
        }
        // --- ADD 2018/07/26 田建委 Redmine#49725 UOE発注データ削除処理対応 --------------------<<<<<
        
		# endregion

        # region UOE発注先コード比較
        /// <summary>
        /// UOE発注先コード比較
        /// </summary>
        public class UOESupplierCdComparer : IComparer<UOEOrderDtlWork>
        {
            public int Compare(UOEOrderDtlWork x, UOEOrderDtlWork y)
            {
                return (x.UOESupplierCd - y.UOESupplierCd);
            }
        }
		# endregion

		# region ＵＯＥ送信編集呼び出し
		/// <summary>
		/// ＵＯＥ送信編集呼び出し
		/// </summary>
		/// <param name="message"></param>
		/// <returns></returns>
		private int UoeSndEditCall(out string message)
		{
			//変数の初期化
			int status = (int)EnumUoeConst.Status.ct_NORMAL;
			message = "";

			try
			{
				//ＵＯＥ送信編集アクセスクラス
				if (_uoeSndEditAcs == null)
				{
					_uoeSndEditAcs = new UoeSndEditAcs();
				}

				//ＵＯＥ送信編集結果
				if (_uoeSndHedList == null)
				{
					_uoeSndHedList = new List<UoeSndHed>();
				}
				else
				{
					_uoeSndHedList.Clear();
				}

				if ((status = _uoeSndEditAcs.writeUOESNDEdit(
												_uoeSndRcvCtlPara,
												_uOESupplierDictionary,
												out _uoeSndHedList,
												out message)) != (int)EnumUoeConst.Status.ct_NORMAL)
				{
					return (status);
				}
			}
			catch (Exception ex)
			{
				status = -1;
				message = ex.Message;
			}
			return (status);
		}
		# endregion

		# region ＵＯＥ送受信処理呼び出し
        // HACK:▼卸商仕入受信処理
        /// <summary>
        /// 仕入要求電文の送受信を行い、受信テキストを送受信JNLに登録します。
        /// </summary>
        /// <remarks>
        /// 卸商仕入受信処理にて使用
        /// </remarks>
        /// <param name="uoeSndRcvCtlPara">UOE送信制御条件</param>
        /// <param name="uoeSndHedList">UOE送信編集結果</param>
        /// <param name="receivingUOESupplier">卸商仕入受信処理のUOE発注先種別</param>
        /// <param name="receivedUoeRecHed">受信したUOE受信結果(ヘッダー)</param>
        /// <param name="errorMessage">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        public int ReceiveUOEStockRequestTextAndInsertJNL(
            UoeSndRcvCtlPara uoeSndRcvCtlPara,
            List<UoeSndHed> uoeSndHedList,
            EnumUoeConst.ReceivingUOESupplier receivingUOESupplier,
            out UoeRecHed receivedUoeRecHed,
            out string errorMessage
        )
        {
            _uoeSndRcvCtlPara = uoeSndRcvCtlPara;
            _uoeSndHedList = uoeSndHedList;

            receivedUoeRecHed = null;
            int status = UoeSndRcvCall(out receivedUoeRecHed, true, out errorMessage);

            return status;
        }

        /// <summary>
        /// ＵＯＥ送受信処理呼び出し
        /// </summary>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        private int UoeSndRcvCall(out string message)
        {
            UoeRecHed receivedUoeRecHed = null;
            return UoeSndRcvCall(out receivedUoeRecHed, false, out message);
        }
        // HACK:▲

		/// <summary>
		/// ＵＯＥ送受信処理呼び出し
		/// </summary>
        /// <param name="uoeRecHed">受信したUOE受信結果(ヘッダー)</param>
        /// <param name="processStockSlipDtRecvDiv">仕入受信モード true:仕入受信処理 false:通常処理</param>
        /// <param name="message">エラーメッセージ</param>
		/// <returns>ステータス</returns>
        private int UoeSndRcvCall(out UoeRecHed uoeRecHed, bool processStockSlipDtRecvDiv, out string message)
		{
			//変数の初期化
            string procNm = "UoeSndRcvCall";
            string asseNm = "";
            
            int status = (int)EnumUoeConst.Status.ct_NORMAL;
			message = "";
            uoeRecHed = null;

            msgShowSolt = Thread.GetNamedDataSlot(MSGSHOWSOLT);// ADD 2013/08/15 譚洪

			try
            {
                if (_uoeSndRcvDialog == null)
                {
                    _uoeSndRcvDialog = UoeSndRcvDialog.GetInstance();
                }

				//ＵＯＥ受信編集アクセスクラス
				if (_uoeRcvEditAcs == null)
				{
					_uoeRcvEditAcs = new UoeRcvEditAcs();
				}

                foreach (UoeSndHed uoeSndHed in _uoeSndHedList)
                {
                    # region ＵＯＥ発注先マスタの取得
                    // ＵＯＥ発注先マスタの取得 ----------------------------------------------------------------------------------
                    UOESupplier uOESupplier = _uoeSndRcvJnlAcs.SearchUOESupplier(uoeSndHed.UOESupplierCd);
                    if (uOESupplier == null) continue;
                	# endregion

                    # region ＵＯＥ送受信処理
                    // ＵＯＥ送受信処理 ------------------------------------------------------------------------------------------
                    asseNm = "送受信処理";
                    logd_update(procNm, asseNm, (Int32)EnumUoeConst.ctLogDataOperationCd.ct_START, 0, "", uoeSndHed.UOESupplierCd);

                    status = _uoeSndRcvDialog.ShowDialog(uoeSndHed, out uoeRecHed, processStockSlipDtRecvDiv, out message);
                    logd_update(procNm, asseNm, (Int32)EnumUoeConst.ctLogDataOperationCd.ct_END, status, message, uoeSndHed.UOESupplierCd);
                    if (status != (int)EnumUoeConst.Status.ct_NORMAL)
                    {
                        // ---- DEL 2013/08/15 譚洪 --- >>>>>
                        //TMsgDisp.Show(
                        //    //this,
                        //    emErrorLevel.ERR_LEVEL_STOP,
                        //    asseNm,
                        //    message,
                        //    status,
                        //    MessageBoxButtons.OK);
                        // ---- DEL 2013/08/15 譚洪 --- <<<<<

                        // ---- ADD 2013/08/15 譚洪 --- >>>>>
                        //フタバUSB専用
                        if (this._opt_FuTaBa == (int)Option.ON)
                        {
                            // ---DEL K2014/05/26 鄧潘ハン Redmine 42571 --------------------------------------->>>>>
                            //Thread中、拠点情報を取得
                            //sectionNameSolt = Thread.GetNamedDataSlot(SECTIONNAMESOLT);
                            //string sectionNameStr = string.Empty;
                            //if (Thread.GetData(sectionNameSolt) != null)
                            //{
                            //    sectionNameStr = (string)Thread.GetData(sectionNameSolt);
                            //}
                            ////Thread中、発注先情報を取得
                            //uoeSupplierNameSolt = Thread.GetNamedDataSlot(UOESUPPLIERNAMESOLT);
                            //string uoeSupplierNameStr = string.Empty;
                            //if (Thread.GetData(uoeSupplierNameSolt) != null)
                            //{
                            //    uoeSupplierNameStr = (string)Thread.GetData(uoeSupplierNameSolt);
                            //}
                            // ---DEL K2014/05/26 鄧潘ハン Redmine 42571 ---------------------------------------<<<<<
                            //Thread中、メッセージ情報がない場合
                            if (Thread.GetData(msgShowSolt) == null 
                                || (Thread.GetData(msgShowSolt) != null && (Int32)Thread.GetData(msgShowSolt) == 2)
                                || (Thread.GetData(msgShowSolt) != null && (Int32)Thread.GetData(msgShowSolt) == 4))
                            {
                                TMsgDisp.Show(
                                    //this,
                                    emErrorLevel.ERR_LEVEL_STOP,
                                    asseNm,
                                    message,
                                    status,
                                    MessageBoxButtons.OK);
                            }
                            else
                            {
                                // ---DEL K2014/05/26 鄧潘ハン Redmine 42571 --------------------------------------->>>>>
                                //message = message + " \r\n "
                                //    + " \r\n"
                                //    + "UOE発注ログ表示を確認して下さい。 \r\n"
                                //    + " \r\n"
                                //    + "発注先：" + uoeSupplierNameStr
                                //    + " \r\n"
                                //    + "拠点：" + sectionNameStr;
                                //if (this._pmCMN00900UA == null)
                                //{
                                //    this._pmCMN00900UA = new PMCMN00900UA();
                                //}
                                //this._pmCMN00900UA.ErrorMsgShow(message);
                                // ---DEL K2014/05/26 鄧潘ハン Redmine 42571 ---------------------------------------<<<<<
                            }
                        }
                        else
                        {
                            TMsgDisp.Show(
                                //this,
                                emErrorLevel.ERR_LEVEL_STOP,
                                asseNm,
                                message,
                                status,
                                MessageBoxButtons.OK);
                        }
                        // ---- ADD 2013/08/15 譚洪 --- <<<<<
                    }
                    # endregion

                    // ---- ADD 2013/08/15 譚洪 --- >>>>>
                    string msgBak = string.Empty;
                    int statusBak = 0;
                    //フタバUSB専用
                    if (this._opt_FuTaBa == (int)Option.ON)
                    {
                        if (Thread.GetData(msgShowSolt) != null)
                        {
                            msgBak = message;
                            statusBak = status;
                        }
                    }
                    // ---- ADD 2013/08/15 譚洪 --- <<<<<

                    # region ＵＯＥ受信編集処理
                    // ＵＯＥ受信編集処理 -----------------------------------------------------------------------------------------
					int systemDivCd = _uoeSndRcvCtlPara.SystemDivCd;
                    asseNm = "受信編集";
                    logd_update(procNm, asseNm, (Int32)EnumUoeConst.ctLogDataOperationCd.ct_START, 0, "", uoeSndHed.UOESupplierCd);

					switch (uoeSndHed.BusinessCode)
					{
						//ＵＯＥ受信編集＜発注＞
						case (int)EnumUoeConst.TerminalDiv.ct_Order:
							status = _uoeRcvEditAcs.UoeRecEditOrder(systemDivCd,
																	uoeSndHed,
																	uoeRecHed,
																	out message);
                            break;

						//ＵＯＥ受信編集＜見積＞
						case (int)EnumUoeConst.TerminalDiv.ct_Estmt:
							status = _uoeRcvEditAcs.UoeRecEditEstmt(systemDivCd,
																	uoeSndHed,
																	uoeRecHed,
																	out message);
							break;
						//ＵＯＥ受信編集＜在庫＞
						case (int)EnumUoeConst.TerminalDiv.ct_Stock:
							status = _uoeRcvEditAcs.UoeRecEditStock(systemDivCd,
																	uoeSndHed,
																	uoeRecHed,
																	out message);
							break;
					}

                    logd_update(procNm, asseNm, (Int32)EnumUoeConst.ctLogDataOperationCd.ct_END, status, message, uoeSndHed.UOESupplierCd);

                    // ---- ADD 2013/08/15 譚洪 --- >>>>>
                    //フタバUSB専用
                    if (this._opt_FuTaBa == (int)Option.ON && Thread.GetData(msgShowSolt) != null)
                    {
                        //message = msgBak;// DEL K2014/05/26 鄧潘ハン Redmine 42571
                        // ---ADD K2014/05/26 鄧潘ハン Redmine 42571 --------------------------------------->>>>>
                        if (statusBak != (int)EnumUoeConst.Status.ct_NORMAL)
                        {
                            message = "【送信エラー】" + msgBak + " ST=" + statusBak.ToString()
                            + "【復旧方法】復旧処理から再発注、又は回答埋込処理を実行して下さい。";
                        status = statusBak;
                    }
                        else if (status != (int)EnumUoeConst.Status.ct_NORMAL)
                        {
                            message = "【受信編集エラー】受信編集処理に失敗しました。ST=" + status.ToString();
                        }
                        // ---ADD K2014/05/26 鄧潘ハン Redmine 42571 ---------------------------------------<<<<<
                        //status = statusBak; //DEL K2014/05/26 鄧潘ハン Redmine 42571
                    }
                    // ---- ADD 2013/08/15 譚洪 --- <<<<<

					if(status != (int)EnumUoeConst.Status.ct_NORMAL)
					{
						return(status);
					}
                	# endregion
				}
			}
			catch (Exception ex)
			{
                uoeRecHed = null;
				status = -1;
				message = ex.Message;
			}
			return (status);
		}
		# endregion

        # region ＤＳＰログ書き込み
        /// <summary>
        /// ＤＳＰログ書き込み
        /// </summary>
        /// <param name="logDataObjProcNm"></param>
        /// <param name="logDataOperationCd"></param>
        /// <param name="logOperationStatus"></param>
        /// <param name="logDataMassage"></param>
        private void logd_update(string logDataObjProcNm, string logDataObjAssemblyNm, Int32 logDataOperationCd, Int32 logOperationStatus, string logDataMassage)
        {
            _uoeOprtnHisLogAcs.logd_update(this, logDataObjProcNm, logDataObjAssemblyNm, logDataOperationCd, logOperationStatus, logDataMassage, 0);
        }
        # endregion

        # region ＤＳＰログ書き込み
        /// <summary>
        /// ＤＳＰログ書き込み
        /// </summary>
        /// <param name="logDataObjProcNm"></param>
        /// <param name="logDataOperationCd"></param>
        /// <param name="logOperationStatus"></param>
        /// <param name="logDataMassage"></param>
        private void logd_update(string logDataObjProcNm, string logDataObjAssemblyNm, Int32 logDataOperationCd, Int32 logOperationStatus, string logDataMassage, Int32 uOESupplierCd)
        {
            _uoeOprtnHisLogAcs.logd_update(this, logDataObjProcNm, logDataObjAssemblyNm, logDataOperationCd, logOperationStatus, logDataMassage, uOESupplierCd);
        }
        # endregion


        # endregion

       
	}

    #region XML
    // --- ADD 2018/07/26 田建委 Redmine#49725 UOE発注データ削除処理対応 -------------------->>>>>
    /// public class name:   RetentionMonthsInfo
    /// <summary>
    /// 保存月数の値設定
    /// </summary>
    /// <remarks>
    /// <br>note             :  保存月数の値設定ファイル</br>
    /// <br>Programmer       :  田建委</br>
    /// <br>Date             :  2018/07/26</br>
    /// </remarks>
    [Serializable]
    public class RetentionMonthsInfo
    {
        /// <summary>保存月数の値設定</summary>
        private Int32 _retentionMonths;

        /// public propaty name  :  RetentionMonths
        /// <summary>保存月数の値設定プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   保存月数の値設定プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 RetentionMonths
        {
            get { return _retentionMonths; }
            set { _retentionMonths = value; }
        }

        /// <summary>
        /// 保存月数の値設定コンストラクタ
        /// </summary>
        /// <returns>RetentionMonthsInfoクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :  RetentionMonthsInfoクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :  自動生成</br>
        /// </remarks>
        public RetentionMonthsInfo()
        {

        }

        /// <summary>
        /// 保存月数の値設定コンストラクタ
        /// </summary>
        /// <returns>RetentionMonthsInfoクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :  RetentionMonthsInfoクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :  自動生成</br>
        /// </remarks>
        public RetentionMonthsInfo(int retentionMonths)
        {
            _retentionMonths = retentionMonths;
        }
    }
    // --- ADD 2018/07/26 田建委 Redmine#49725 UOE発注データ削除処理対応 --------------------<<<<<
    #endregion
}

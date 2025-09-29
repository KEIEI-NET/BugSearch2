//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : UOE通信結果表示アクセスクラス
// プログラム概要   : UOE通信結果表示アクセスを行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10402071-00 作成担当 : 照田 貴志
// 作 成 日  2008/12/13  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号  10902931-00 作成担当 : 譚洪
// 作 成 日  2013/08/15  修正内容 : 発注処理(自動)処理の追加
//----------------------------------------------------------------------------//
// 管理番号  11001634-00 作成担当 : 鄧潘ハン
// 作 成 日  K2014/07/03 修正内容 : エラーメッセージの例外エラー対応
//----------------------------------------------------------------------------//
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Windows.Forms;
using Broadleaf.Library.Text;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Common;
using System.Threading;
using Broadleaf.Windows.Forms;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// UOE通信結果表示アクセスクラス
	/// </summary>
	/// <remarks>
    /// <br>Note       : UOE通信結果表示アクセスクラス</br>
	/// <br>Programmer : 照田 貴志</br>
	/// <br>Date       : 2008/12/13</br>
    /// <br>UpdateNote : 2009/01/20 照田 貴志　不具合対応[10043]</br>
    /// <br>             2009/01/22 照田 貴志　不具合対応[10346]</br>
    /// <br>             2009/02/04 照田 貴志　不具合対応[10977]</br>
	/// </remarks>
	public partial class UoeSndRcvResultAcs
	{
        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        // 定数
        private string ERRORMESSAGE_DATASENDCODE1 = "その他エラー";
        private string ERRORMESSAGE_DATASENDCODE2 = "送信エラー";
        private string ERRORMESSAGE_DATASENDCODE3 = "受信エラー";
        // HashTable関連
        private Hashtable _uoeSupplierHTable = null;                                        // UOE発注先情報HashTable(key：UOE発注先コード)
        private Hashtable _dataSendName = null;                                             // エラー内容HashTable(key：送信フラグ)
        // List<OrderSndRcvJnl>関連
        private List<OrderSndRcvJnl> _orderSndRcvJnlList = null;                            // 送受信JNLリスト
        private List<OrderSndRcvJnl> _orderSndRcvJnlErrorList = null;                       // 送受信JNLエラーリスト(帳票印字用)
        // エラーメッセージ関連
        private SortedList<int, OrderSndRcvJnl> _sndRcvErrorUOESupplierList = null;         // 送受信エラーUOE発注先リスト(key：UOE発注先コード)
        private List<string> _sndRcvErrorMessageList = null;                                // 送受信エラーメッセージ(画面表示用)
        private List<string> _stockErrorMessageList = null;                                 // 仕入データ作成エラーメッセージ(画面表示用)
        private List<string> _changeColorStringList = null;                                 // 色変更する文字列リスト
        //その他
        private UoeSndRcvJnlAcs _uoeSndRcvJnlAcs = null;                                    // UOE送受信JNLアクセスクラス
        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;               // 企業コード
        private string _loginSectionCd = LoginInfoAcquisition.Employee.BelongSectionCode;   // ログイン拠点コード

        // ---- ADD 2013/08/15 譚洪 ---- >>>>>
        //Thread中、メッセージ関係
        private const string MSGSHOWSOLT = "MSGSHOWSOLT";
        private LocalDataStoreSlot msgShowSolt = null;
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


        // ===================================================================================== //
        // プロパティ
        // ===================================================================================== //
        // ▼プライベートプロパティ
        /// <summary>UOE自社設定マスタ</summary>
        private UOESetting uOESetting { get { return this._uoeSndRcvJnlAcs.uOESetting; } }
        /// <summary>UOE発注先マスタ</summary>
        private UOESupplierAcs uOESupplierAcs { get { return this._uoeSndRcvJnlAcs.uOESupplierAcs; } }

		// ===================================================================================== //
		// コンストラクタ
		// ===================================================================================== //
		# region ▼Constructors
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="orderSndRcvJnlList">送受信JNLリスト</param>
		public UoeSndRcvResultAcs(List<OrderSndRcvJnl> orderSndRcvJnlList)
		{
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

            // UOE送受信JNLアクセスクラスインスタンス化
            this._uoeSndRcvJnlAcs = UoeSndRcvJnlAcs.GetInstance();

            // 企業コードを取得する
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

			// ログイン拠点コード
            this._loginSectionCd = LoginInfoAcquisition.Employee.BelongSectionCode;

            // 送受信JNL
            this._orderSndRcvJnlList = orderSndRcvJnlList;

            // エラー内容取得
            this.CreateDataSendNameHTable();
            
            // UOE発注先情報取得
            this.CreateUOESupplierHTable();

            // 各種インスタンス作成
            this._orderSndRcvJnlErrorList = new List<OrderSndRcvJnl>();
            this._sndRcvErrorMessageList = new List<string>();
            this._stockErrorMessageList = new List<string>();
            this._sndRcvErrorUOESupplierList = new SortedList<int, OrderSndRcvJnl>();
            this._changeColorStringList = new List<string>();
        }
		# endregion

        // ===================================================================================== //
        // パブリックメソッド
        // ===================================================================================== //
        #region ▼ShowDialog(ダイアログ表示)
        /// <summary>
        /// ダイアログ表示
        /// </summary>
        public void ShowDialog()
        {
            // エラーがある場合にフォームを表示
            if (this.ErrorIsExists())
            {
                List<string> errorMessageList = new List<string>();     // 画面表示用エラーメッセージ

                // ---ADD K2014/07/03 鄧潘ハン Redmine 42977  --------------------------------------->>>>>
                //フタバUSB専用:Option.ON
                if (this._opt_FuTaBa == (int)Option.ON)
                {
                    //メッセージを取得
                    msgShowSolt = Thread.GetNamedDataSlot(MSGSHOWSOLT);
                }
                // ---ADD K2014/07/03 鄧潘ハン Redmine 42977  ---------------------------------------<<<<<

                // 送受信エラー追加
                errorMessageList = this._sndRcvErrorMessageList;
                if (errorMessageList.Count != 0)
                {
                    errorMessageList.Add("");
                }
                // 仕入データ作成エラー追加
                foreach (string item in this._stockErrorMessageList)
                {
                    errorMessageList.Add(item);
                }

                // フォーム表示
                UoeSndRcvResultDialog uoeSndRcvResultDialog = new UoeSndRcvResultDialog(this._orderSndRcvJnlErrorList       // 送受信エラーリスト(帳票用)
                                                                                        , errorMessageList                  // エラーメッセージリスト(画面表示用)
                                                                                        , this._changeColorStringList);     // 色変更する文字列リスト
                //uoeSndRcvResultDialog.ShowDialog(); // DEL 2013/08/15 譚洪

                // ---- ADD 2013/08/15 譚洪 --- >>>>>
                //フタバ専用USBではない
                //発注処理(手動)と発注処理(自動)ではない
                //発注処理(手動)である場合
                if (this._opt_FuTaBa == (int)Option.OFF
                     || Thread.GetData(msgShowSolt) == null
                     || (Thread.GetData(msgShowSolt) != null && (Int32)Thread.GetData(msgShowSolt) == 2))
                {
                    uoeSndRcvResultDialog.ShowDialog();
                }
                // ---- ADD 2013/08/15 譚洪 --- <<<<<
            }
        }
        #endregion

        // ===================================================================================== //
        // プライベートメソッド
        // ===================================================================================== //
        // HashTable作成関連
        #region ▼CreateDataSendNameHTable(エラー内容HashTable作成)
        /// <summary>
        /// エラー内容HashTable作成
        /// </summary>
        /// <remarks>
        /// <br>Note       : エラー内容HashTable(key：送信フラグ)を作成します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/12/13</br>
        /// </remarks>
        private void CreateDataSendNameHTable()
        {
            this._dataSendName = new Hashtable();
            this._dataSendName[1] = ERRORMESSAGE_DATASENDCODE1;
            this._dataSendName[2] = ERRORMESSAGE_DATASENDCODE2;
            this._dataSendName[3] = ERRORMESSAGE_DATASENDCODE3;
        }
        #endregion

        #region ▼CreateUOESupplierHTable(UOE発注先情報HashTable作成)
        /// <summary>
        /// UOE発注先情報HashTable作成
        /// </summary>
        /// <remarks>
        /// <br>Note       : UOE発注先HashTable(key：UOE発注先コード)を作成します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/12/13</br>
        /// </remarks>
        private void CreateUOESupplierHTable()
        {
            this._uoeSupplierHTable = new Hashtable();

            ArrayList arrayList = null;
            int status = this.uOESupplierAcs.Search(out arrayList, this._enterpriseCode, this._loginSectionCd);
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return;
            }

            // HashTableに格納
            UOESupplier uoeSupplier = null;
            for (int i = 0; i <= arrayList.Count - 1; i++)
            {
                uoeSupplier = (UOESupplier)arrayList[i];
                this._uoeSupplierHTable[uoeSupplier.UOESupplierCd] = uoeSupplier;
            }
        }
        # endregion

        // エラーメッセージ作成メイン
        #region ▼ErrorIsExists(エラー有無判定)
        /// <summary>
        /// エラー有無判定
        /// </summary>
        /// <returns>True：エラー有り、False：エラー無し</returns>
        /// <remarks>
        /// <br>Note       : 送受信JNLリストからエラーとなった情報を抜き出し、エラーメッセージを作成します。</br>
        /// <br>             ※送受信エラーメッセージについては最初、エラーとなったUOE発注先を貯め込み、後でまとめてメッセージの作成を行います</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/12/13</br>
        /// </remarks>
        private bool ErrorIsExists()
        {
            OrderSndRcvJnl orderSndRcvJnl = null;
            for (int i = 0; i <= this._orderSndRcvJnlList.Count - 1; i++)
            {
                orderSndRcvJnl = this._orderSndRcvJnlList[i];
                if (this.CheckSndRcvError(orderSndRcvJnl))
                {
                    // 送受信JNLエラー(帳票用)リストに追加
                    this._orderSndRcvJnlErrorList.Add(orderSndRcvJnl);

                    // エラーとなったUOE発注先情報を保持
                    this.AddSndRcvErrorUOESupplierList(orderSndRcvJnl);
                    continue;
                }
                if (this.CheckStockError(orderSndRcvJnl))
                {
                    // 仕入データ作成エラーメッセージ取得
                    this.AddStockErrorMessageList();
                    continue;
                }
            }

            // 送受信エラーメッセージ取得
            if (this._sndRcvErrorUOESupplierList.Count != 0)
            {
                this.AddSndRcvErrorMessageList();
            }

            if ((this._sndRcvErrorMessageList.Count == 0) && (this._stockErrorMessageList.Count == 0))
            {
                return false;
            }

            return true;
        }
        #endregion

        // 送受信エラーメッセージ作成関連
        #region ▼CheckSndRcvError(送受信エラー判定)
        /// <summary>
        /// 送受信エラー判定
        /// </summary>
        /// <param name="orderSndRcvJnl">送受信JNL</param>
        /// <returns>True：送受信エラー、False：その他</returns>
        /// <remarks>
        /// <br>Note       : 送受信エラー対象かどうか判定を行います。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/12/13</br>
        /// </remarks>
        private bool CheckSndRcvError(OrderSndRcvJnl orderSndRcvJnl)
        {
            // 送信フラグが「9：正常終了」以外の場合は対象とする
            if (orderSndRcvJnl.DataSendCode != 9)
            {
                return true;
            }
            return false;
        }
        #endregion

        #region ▼AddSndRcvErrorUOESupplierList(送受信エラーとなったUOE発注先情報取得)
        /// <summary>
        /// 送受信エラーとなったUOE発注先情報取得
        /// </summary>
        /// <param name="orderSndRcvJnl">送受信JNL</param>
        /// <remarks>
        /// <br>Note       : 送受信エラーとなったUOE発注先を保持します。</br>
        /// <br>             ※エラーとなったUOE発注先がすでに保持されている場合、送信フラグの表示優先順が高い方を新たに保持します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/12/13</br>
        /// </remarks>
        private void AddSndRcvErrorUOESupplierList(OrderSndRcvJnl orderSndRcvJnl)
        {
            // 対応するエラー内容が無い
            if (this._dataSendName.ContainsKey(orderSndRcvJnl.DataSendCode) == false)
            {
                return;
            }

            // UOE発注先がすでに登録されている場合
            if (this._sndRcvErrorUOESupplierList.ContainsKey(orderSndRcvJnl.UOESupplierCd))
            {
                // 登録されているデータと比較して優先度の高い方を再登録
                this._sndRcvErrorUOESupplierList[orderSndRcvJnl.UOESupplierCd] = this.CheckDataSendCodePriority(orderSndRcvJnl);
            }
            else
            {
                this._sndRcvErrorUOESupplierList.Add(orderSndRcvJnl.UOESupplierCd, orderSndRcvJnl);
            }
        }
        /// <summary>
        /// 優先順位チェック
        /// </summary>
        /// <param name="newData">送受信JNL</param>
        /// <returns>優先順位の高いデータ</returns>
        /// <remarks>
        /// <br>Note       : エラーとなったUOE発注先がすでに保持されている場合、優先順をチェックして優先順の高いものを新たに保持します。</br>
        /// <br>             ※優先順・・・送信フラグ3(受信エラー) ＞ 送信フラグ2(送信エラー) ＞ 送信フラグ1(その他エラー)</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/12/13</br>
        /// </remarks>
        private OrderSndRcvJnl CheckDataSendCodePriority(OrderSndRcvJnl newData)
        {
            // 現在格納されているUOE発注先情報取得
            OrderSndRcvJnl oldData = (OrderSndRcvJnl)this._sndRcvErrorUOESupplierList[newData.UOESupplierCd];

            // 比較して新しいデータのほうが優先度が高ければ交換
            if (oldData.DataSendCode < newData.DataSendCode)
            {
                return newData;
            }
            else
            {
                return oldData;
            }
        }
        #endregion

        #region ▼AddSndRcvErrorMessageList(送受信エラーメッセージ取得)
        /// <summary>
        /// 送受信エラーメッセージ取得
        /// </summary>
        /// <remarks>
        /// <br>Note       : エラーとなったUOE発注先を元に送受信エラーメッセージを作成します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/12/13</br>
        /// </remarks>
        private void AddSndRcvErrorMessageList()
        {
            this._sndRcvErrorMessageList.Add("○送受信処理");
            this._sndRcvErrorMessageList.Add("　回線エラーが発生しました。");
            this._sndRcvErrorMessageList.Add("　復旧処理を行って下さい。");
            this._sndRcvErrorMessageList.Add("");
            this._sndRcvErrorMessageList.Add(" 【通信結果】");

            //色変更する文字列
            this._changeColorStringList.Add(this._sndRcvErrorMessageList[1]);
            this._changeColorStringList.Add(this._sndRcvErrorMessageList[2]);

            // 送受信エラーとなったUOE発注先情報を元にエラーメッセージ編集
            foreach (OrderSndRcvJnl orderSndRcvJnl in this._sndRcvErrorUOESupplierList.Values)
            {
                this._sndRcvErrorMessageList.Add(this.MakeUOESupplierMessage(orderSndRcvJnl));
            }
        }
        /// <summary>
        /// UOE発注先に関するエラーメッセージを編集
        /// </summary>
        /// <param name="orderSndRcvJnl">送受信JNL</param>
        /// <returns>編集したエラーメッセージ</returns>
        /// <remarks>
        /// <br>Note       : 通信結果の各発注先に対して開始位置を揃えて見栄えを良くします。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/12/13</br>
        /// </remarks>
        private string MakeUOESupplierMessage(OrderSndRcvJnl orderSndRcvJnl)
        {
            StringBuilder SB = new StringBuilder();
            SB.Append("　");
            //SB.Append(orderSndRcvJnl.UOESupplierName);                      // UOE発注先名        //DEL 2009/01/22 不具合対応[10346]
            // ---ADD 2009/01/22 不具合対応[10346] ------------------------------------------>>>>>
            // UOE発注先名
            if (orderSndRcvJnl.UOESupplierName.Length > 12)
            {
                SB.Append(orderSndRcvJnl.UOESupplierName.Substring(0, 12));
            }
            else
            {
                SB.Append(orderSndRcvJnl.UOESupplierName);
            }
            // ---ADD 2009/01/22 不具合対応[10346] ------------------------------------------<<<<<

            int editAreaByte = 32;
            int targetByte = TStrConv.SizeCountSJIS(SB.ToString());

            // 32バイトで足りない場合は8バイト追加
            if (targetByte >= editAreaByte)
            {
                editAreaByte = editAreaByte + 8;
            }

            // 文字が揃うようにスペースを埋める
            for (int i = 1; i <= (editAreaByte - targetByte); i++)
            {
                SB.Append(" ");
            }

            SB.Append(this._dataSendName[orderSndRcvJnl.DataSendCode]);     // エラー内容

            return SB.ToString();
        }
        #endregion

        // 仕入データ作成エラーメッセージ作成関連
        #region ▼CheckStockError(仕入データ作成エラー判定)
        /// <summary>
        /// 仕入データ作成エラー判定
        /// </summary>
        /// <param name="orderSndRcvJnl">送受信JNL</param>
        /// <returns>True：仕入データ作成エラー、False：その他</returns>
        /// <remarks>
        /// <br>Note       : 仕入データ作成エラー対象かどうか判定を行います。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/12/13</br>
        /// </remarks>
        private bool CheckStockError(OrderSndRcvJnl orderSndRcvJnl)
        {
            // 送信フラグが「9：正常終了」以外の場合は対象外とする
            if (orderSndRcvJnl.DataSendCode != 9)
            {
                return false;
            }

            // UOE発注先マスタに登録されていない場合は対象外とする
            if (this._uoeSupplierHTable.ContainsKey(orderSndRcvJnl.UOESupplierCd) == false)
            {
                return false;
            }

            // 受信状況(受信有無区分)が「1:あり」で仕入データ受信区分(仕入有無区分)が「1:受信有」の場合は対象外とする
            UOESupplier uoeSupplier = (UOESupplier)this._uoeSupplierHTable[orderSndRcvJnl.UOESupplierCd];
            if ((uoeSupplier.ReceiveCondition == 1) && (uoeSupplier.StockSlipDtRecvDiv == 1))
            {
                return false;
            }

            // ---ADD 2009/01/20 不具合対応[10043] ------------------------------------------------------------->>>>>
            // 取寄品（倉庫ｺｰﾄﾞがｾﾞﾛ）以外の場合は対象外とする
            if ((string.IsNullOrEmpty(orderSndRcvJnl.WarehouseCode) == false) && (orderSndRcvJnl.WarehouseCode != "0"))
            {
                return false;
            }
            // ---ADD 2009/01/20 不具合対応[10043] -------------------------------------------------------------<<<<<

            // 数量があり、伝票番号が無い(拠点、BO1、BO2、BO3)
            /* ---DEL 2009/02/04 不具合対応[10977] ------------------------------------------------------------->>>>>
            if (((orderSndRcvJnl.UOESectOutGoodsCnt != 0) && (string.IsNullOrEmpty(orderSndRcvJnl.UOESectionSlipNo)))
            || ((orderSndRcvJnl.BOShipmentCnt1 != 0) && (string.IsNullOrEmpty(orderSndRcvJnl.BOSlipNo1)))
            || ((orderSndRcvJnl.BOShipmentCnt2 != 0) && (string.IsNullOrEmpty(orderSndRcvJnl.BOSlipNo2)))
            || ((orderSndRcvJnl.BOShipmentCnt3 != 0) && (string.IsNullOrEmpty(orderSndRcvJnl.BOSlipNo3))))
               ---DEL 2009/02/04 不具合対応[10977] -------------------------------------------------------------<<<<< */
            // ---ADD 2009/02/04 不具合対応[10977] ------------------------------------------------------------->>>>>
            if (((orderSndRcvJnl.UOESectOutGoodsCnt != 0) && (string.IsNullOrEmpty(orderSndRcvJnl.UOESectionSlipNo.Trim())))
            || ((orderSndRcvJnl.BOShipmentCnt1 != 0) && (string.IsNullOrEmpty(orderSndRcvJnl.BOSlipNo1.Trim())))
            || ((orderSndRcvJnl.BOShipmentCnt2 != 0) && (string.IsNullOrEmpty(orderSndRcvJnl.BOSlipNo2.Trim())))
            || ((orderSndRcvJnl.BOShipmentCnt3 != 0) && (string.IsNullOrEmpty(orderSndRcvJnl.BOSlipNo3.Trim()))))
            // ---ADD 2009/02/04 不具合対応[10977] -------------------------------------------------------------<<<<<
            {
                return true;
            }

            // UOE自社設定マスタのメーカーフォロー計上区分が「0：売上」の場合
            if (uOESetting.MakerFollowAddUpDiv == 0)
            {
                // 数量がある(メーカーフォロー、EO)
                if ((orderSndRcvJnl.MakerFollowCnt != 0) || (orderSndRcvJnl.EOAlwcCount != 0))
                {
                    return true;
                }
            }

            return false;
        }
        #endregion

        #region ▼AddStockErrorMessageList(仕入データ作成エラーメッセージ取得)
        /// <summary>
        /// 仕入データ作成エラーメッセージ取得
        /// </summary>
        /// <remarks>
        /// <br>Note       : 仕入データ作成エラーメッセージを作成します。</br>
        /// <br>Programmer : 照田 貴志</br>
        /// <br>Date       : 2008/12/13</br>
        /// </remarks>
        private void AddStockErrorMessageList()
        {
            // 文言が同じなので最初の1回のみ
            if (this._stockErrorMessageList.Count != 0)
            {
                return;
            }

            this._stockErrorMessageList.Add("○仕入データ作成処理");
            this._stockErrorMessageList.Add("　仕入データ作成エラーが発生しています。");
            this._stockErrorMessageList.Add("　仕入アンマッチリストを出力して下さい。");

            // 色変更する文字列を設定
            this._changeColorStringList.Add(this._stockErrorMessageList[1]);
            this._changeColorStringList.Add(this._stockErrorMessageList[2]);
        }
        #endregion
    }
}

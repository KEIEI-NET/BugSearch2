//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : ＵＯＥ送信編集（優良）アクセスクラス
// プログラム概要   : ＵＯＥ送信編集（優良）アクセスを行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10402071-00 作成担当 : 立花 裕輔
// 作 成 日  2008/05/26  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// ＵＯＥ送信編集（優良）アクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : ＵＯＥ送信編集（優良）アクセスクラス</br>
	/// <br>Programmer : 96186 立花裕輔</br>
	/// <br>Date       : 2008.05.26</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// <br>2008.05.26 men 新規作成</br>
	/// </remarks>
	public partial class UoeSndEdit1001Acs
	{
		// ===================================================================================== //
		// コンストラクタ
		// ===================================================================================== //
		# region Constructors
		public UoeSndEdit1001Acs()
		{
			//ＵＯＥ送受信ＪＮＬアクセスクラス
			_uoeSndRcvJnlAcs = UoeSndRcvJnlAcs.GetInstance();
		}
		# endregion

		// ===================================================================================== //
		// プライベート変数
		// ===================================================================================== //
		# region Private Members
		//ＵＯＥ送受信ＪＮＬアクセスクラス
		private UoeSndRcvJnlAcs _uoeSndRcvJnlAcs;

		//ＵＯＥ送信編集結果
		private List<UoeSndDtl> _uoeSndDtlList = new List<UoeSndDtl>();

		//発注先情報クラス
		private UOESupplier	_uOESupplier;

		//システム区分 0:手入力 1:伝発 2:検索 3:一括
		private int _systemDivCd;

		//ＵＯＥ送受信ＪＮＬ（発注）ＶＩＥＷ
		private DataView _orderView = new DataView();

		//ＵＯＥ送受信ＪＮＬ（見積）ＶＩＥＷ
		private DataView _estmtView = new DataView();

		//ＵＯＥ送受信ＪＮＬ（在確）ＶＩＥＷ
		private DataView _stockView = new DataView();

		# endregion

		// ===================================================================================== //
		// 定数
		// ===================================================================================== //
		# region Const Members
		//Sort
		public const string ctSortUpper = " ASC";   // 昇順出力
		public const string ctSortDownO = " DESC";  // 降順出力

		//企業コード 発注先コード 発注番号 発注行番号
		public const string ctSortOrder = "EnterpriseCode, UOESupplierCd, UOESalesOrderNo, UOESalesOrderRowNo";
		public const string ctSortEstmt = "EnterpriseCode, UOESupplierCd, UOESalesOrderNo, UOESalesOrderRowNo";
		public const string ctSortStock = "EnterpriseCode, UOESupplierCd, UOESalesOrderNo, UOESalesOrderRowNo";

		//エラーメッセージ
		private const string MESSAGE_ERROR01 = "業務区分のパラメータが違います。";
		private const string MESSAGE_ERROR02 = "送受信ＪＮＬ＜発注＞（優良）が見つかりません。";
		private const string MESSAGE_ERROR03 = "送受信ＪＮＬ＜見積＞（優良）が見つかりません。";
		private const string MESSAGE_ERROR04 = "送受信ＪＮＬ＜在庫＞（優良）が見つかりません。";

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
		# region ＵＯＥ発注先情報クラス
		/// <summary>
		/// ＵＯＥ発注先情報クラス
		/// </summary>
		public UOESupplier uOESupplier
		{
			get
			{
				return this._uOESupplier;
			}
			set
			{
				this._uOESupplier = value;
			}
		}
		# endregion

		# region ＜DataSet＞
		/// <summary>
		/// ＵＯＥ送受信ＪＮＬデータセット
		/// </summary>
		public DataSet UoeJnlDataSet
		{
			get
			{
				return this._uoeSndRcvJnlAcs.UoeJnlDataSet;
			}
		}
		# endregion

		# region ＜DataTable＞
		# region 発注＜DataTable＞
		/// <summary>
		/// 発注＜DataTable＞
		/// </summary>
		public DataTable OrderTable
		{
			get { return UoeJnlDataSet.Tables[OrderSndRcvJnlSchema.CT_OrderSndRcvJnlDataTable]; }
		}
		# endregion

		# region 見積＜DataTable＞
		/// <summary>
		/// 見積＜DataTable＞
		/// </summary>
		public DataTable EstmtTable
		{
			get { return UoeJnlDataSet.Tables[EstmtSndRcvJnlSchema.CT_EstmtSndRcvJnlDataTable]; }
		}
		# endregion

		# region 在庫＜DataTable＞
		/// <summary>
		/// 在庫＜DataTable＞
		/// </summary>
		public DataTable StockTable
		{
			get { return UoeJnlDataSet.Tables[StockSndRcvJnlSchema.CT_StockSndRcvJnlDataTable]; }
		}
		# endregion
		# endregion

		# region ＜DataView＞
		# region 発注＜DataView＞
		/// <summary>
		/// 発注＜DataTable＞
		/// </summary>
		public DataView OrderView
		{
			get { return this._orderView; }
		}
		# endregion

		# region 見積＜DataView＞
		/// <summary>
		/// 見積＜DataTable＞
		/// </summary>
		public DataView EstmtView
		{
			get { return this._estmtView; }
		}
		# endregion

		# region 在庫＜DataView＞
		/// <summary>
		/// 在庫＜DataTable＞
		/// </summary>
		public DataView StockView
		{
			get { return this._stockView; }
		}
		# endregion
		# endregion
		# endregion

		// ===================================================================================== //
		// パブリックメソッド
		// ===================================================================================== //
		# region Public Methods

		# region ＵＯＥ送信編集（優良）
		/// <summary>
		/// ＵＯＥ送信編集（優良）
		/// </summary>
		/// <param name="uoeSndEditSearchPara"></param>
		/// <returns></returns>
		public int writeUOESNDEdit1001(Int32 businessCode, int systemDivCd, UOESupplier uOESupplier, out List<UoeSndDtl> list, out string message)
		{
			//変数の初期化
			int status = (int)EnumUoeConst.Status.ct_NORMAL;
			message = "";

			//ＵＯＥ送信編集結果クラスの初期化
			list = new List<UoeSndDtl>();
			_uoeSndDtlList = new List<UoeSndDtl>();

			try
			{
				//発注先情報の保存
				_uOESupplier = uOESupplier;

				//システム区分の保存
				_systemDivCd = systemDivCd;

				//リモート処理の呼び出し、データーテーブルへの格納
				switch (businessCode)
				{
					//発注
					case (int)EnumUoeConst.TerminalDiv.ct_Order:
						{
							status = writeUOESNDEditOrder1001(out _uoeSndDtlList, out message);
							break;
						}
					//見積
					case (int)EnumUoeConst.TerminalDiv.ct_Estmt:
						{
							break;
						}
					//在庫
					case (int)EnumUoeConst.TerminalDiv.ct_Stock:
						{
							status = writeUOESNDEditAlloc1001(out _uoeSndDtlList, out message);
							break;
						}
					//その他
					default:
						{
							message = MESSAGE_ERROR01;
							break;
						}
				}
				if ((status == (int)EnumUoeConst.Status.ct_NORMAL)
				&& (_uoeSndDtlList.Count > 0))
				{
					list = _uoeSndDtlList;
				}
			}
			catch (Exception ex)
			{
				status = (int)EnumUoeConst.Status.ct_ERROR;
				message = ex.Message;
			}
			return (status);
		}
		# endregion

		# region ＵＯＥ送信電文作成＜開局/閉局＞（優良）
		/// <summary>
		/// ＵＯＥ送信電文作成＜開局/閉局＞（優良）
		/// </summary>
		public class TelegramEditOpenClose1001
		{
			# region 電文領域クラス
			/// <summary>
			/// 開局・閉局電文領域
			/// </summary>
			private class DN_KAI
			{
				public byte[] dbkb = new byte[2];		//処理区分
				public byte[] tcd = new byte[7];		//端末側コード
				public byte[] hcd = new byte[7];		//ホストコード
				public byte[] pass = new byte[6];		//パスワード
				public byte[] ymd = new byte[6];		//送信日付
				public byte[] hms = new byte[6];		//送信時刻
				public byte[] res = new byte[2];		//結果
				public byte[] hkb = new byte[1];		//発注区分
				public byte[] exten = new byte[32];		//メッセージ
				public byte[] dummy = new byte[1979];	// ﾗｲﾝ       dummy             

				/// <summary>
				/// コンストラクター
				/// </summary>
				public DN_KAI()
				{
					Clear();
				}

				/// <summary>
				/// 初期化
				/// </summary>
				public void Clear()
				{
					UoeCommonFnc.MemSet(ref dbkb, 0x20, dbkb.Length);	//処理区分
					UoeCommonFnc.MemSet(ref tcd, 0x20, tcd.Length);		//端末側コード
					UoeCommonFnc.MemSet(ref hcd, 0x20, hcd.Length);		//ホストコード
					UoeCommonFnc.MemSet(ref pass, 0x20, pass.Length);	//パスワード
					UoeCommonFnc.MemSet(ref ymd, 0x20, ymd.Length);		//送信日付
					UoeCommonFnc.MemSet(ref hms, 0x20, hms.Length);		//送信時刻
					UoeCommonFnc.MemSet(ref res, 0x20, res.Length);		//結果
					UoeCommonFnc.MemSet(ref hkb, 0x20, hkb.Length);		//発注区分
					UoeCommonFnc.MemSet(ref exten, 0x20, exten.Length);	//メッセージ
					UoeCommonFnc.MemSet(ref dummy, 0x20, dummy.Length);	//dummy
				}
			}
			# endregion

			# region Const Members
            private const Int32 ctSndTelegramLen = 69; //送信電文サイズ
            # endregion

			# region Private Members
			private DN_KAI dn_kai = new DN_KAI();
            private UOESupplier _uOESupplier = null;
			# endregion

			# region Constructors
			/// <summary>
			/// コンストラクタ
			/// </summary>
			public TelegramEditOpenClose1001()
			{
				Clear();
			}
			# endregion

			# region Properties
            # region UOE発注先クラス
            /// <summary>
            /// UOE発注先クラス
            /// </summary>
            public UOESupplier uOESupplier
            {
                get
                {
                    return this._uOESupplier;
                }
                set
                {
                    this._uOESupplier = value;
                }
            }
            # endregion

            # region 送信サイズ
            /// <summary>
            /// 送信サイズ
            /// </summary>
            public Int32 SndTelegramLen
            {
                get
                {
                    return ctSndTelegramLen;
                }
            }
            # endregion
            # endregion

			# region Public Methods
			# region データ初期化処理
			/// <summary>
			/// データ初期化処理
			/// </summary>
			public void Clear()
			{
				dn_kai.Clear();
			}
			# endregion

			# region データ編集処理
			/// <summary>
			/// データ編集処理
			/// </summary>
			/// <param name="dr"></param>
			/// <param name="mode"></param>
            public byte[] Telegram(int systemDivCd, int openMode)
			{
				//クリア処理
				Clear();

				//処理区分
				//開局
				if (openMode == (int)EnumUoeConst.OpenMode.ct_OPEN)
				{
					dn_kai.dbkb[0] = 0x30;
					dn_kai.dbkb[1] = 0x31;
				}
				//閉局
				else
				{
					dn_kai.dbkb[0] = 0x39;
					dn_kai.dbkb[1] = 0x30;
				}

				//端末側コード
				UoeCommonFnc.MemCopy(ref dn_kai.tcd, uOESupplier.UOETerminalCd, dn_kai.tcd.Length);
				
				//ホストコード
				UoeCommonFnc.MemCopy(ref dn_kai.hcd, uOESupplier.UOEHostCode, dn_kai.hcd.Length);
				
				//パスワード
				UoeCommonFnc.MemCopy(ref dn_kai.pass, uOESupplier.UOEConnectPassword, dn_kai.pass.Length);
				
				//送信日付
                

				UoeCommonFnc.MemCopy(ref dn_kai.ymd,
                                    String.Format("{0:D2}{1:D2}{2:D2}",
										(DateTime.Now.Year % 100),
                                        DateTime.Now.Month,
                                        DateTime.Now.Day),
									dn_kai.ymd.Length);
				
				//送信時刻
				UoeCommonFnc.MemCopy(ref dn_kai.hms,
                                    String.Format("{0:D2}{1:D2}{2:D2}",
                                        DateTime.Now.Hour,
                                        DateTime.Now.Minute,
                                        DateTime.Now.Second),
									dn_kai.hms.Length);
				
				//結果
				//開局
				if (openMode == (int)EnumUoeConst.OpenMode.ct_OPEN)
				{
					UoeCommonFnc.MemSet(ref dn_kai.res, 0x30, dn_kai.res.Length);
				}
				//閉局
				else
				{
					UoeCommonFnc.MemSet(ref dn_kai.res, 0x20, dn_kai.res.Length);
				}

				//発注区分
				//開局
				if (openMode == (int)EnumUoeConst.OpenMode.ct_OPEN)
				{
					//1:手入力、検索 3:在庫一括、9:伝発
					switch(systemDivCd)
					{
                        case (int)EnumUoeConst.ctSystemDivCd.ct_Input://手入力
                        case (int)EnumUoeConst.ctSystemDivCd.ct_Search://検索
							dn_kai.hkb[0] = 0x31;
							break;
                        case (int)EnumUoeConst.ctSystemDivCd.ct_Slip://伝発
							dn_kai.hkb[0] = 0x39;
							break;
						default://一括
							dn_kai.hkb[0] = 0x33;
							break;
					}
				}
				//閉局
				else
				{
					dn_kai.hkb[0] = 0x20;
				}

				//メッセージ
				UoeCommonFnc.MemSet(ref dn_kai.exten, 0x20, dn_kai.exten.Length);

				//データ作成処理
				return (ToByteArray());
			}

            // HACK:▼卸商仕入受信処理
            /// <summary>
            /// データ編集処理（卸商仕入受信処理の仕入要求）
            /// </summary>
            /// <remarks>
            /// 電文の構造は開局/閉局と同じです。
            /// </remarks>
            /// <param name="receivingUOESupplier">卸商仕入受信処理のUOE発注先種別</param>
            /// <returns>送信電文(JIS)</returns>
            public byte[] Telegram(EnumUoeConst.ReceivingUOESupplier receivingUOESupplier)
            {
                const string SPACE = " ";
                const byte SPACE_CODE = 0x20;

                // クリア処理
                Clear();

                // 電文区分/処理区分
                dn_kai.dbkb[0] = 0x36;
                dn_kai.dbkb[1] = 0x30;

                // 端末側コード
                UoeCommonFnc.MemCopy(ref dn_kai.tcd, uOESupplier.UOETerminalCd, dn_kai.tcd.Length);

                // ホストコード
                string hostCode = uOESupplier.UOEHostCode;
                if (receivingUOESupplier.Equals(EnumUoeConst.ReceivingUOESupplier.Meiji))
                {
                    hostCode = SPACE;   // 明治時はスペース
                }
                UoeCommonFnc.MemCopy(ref dn_kai.hcd, hostCode, dn_kai.hcd.Length);

                // パスワード
                string password = uOESupplier.UOEConnectPassword;
                if (receivingUOESupplier.Equals(EnumUoeConst.ReceivingUOESupplier.Meiji))
                {
                    password = SPACE;   // 明治時はスペース
                }
                UoeCommonFnc.MemCopy(ref dn_kai.pass, password, dn_kai.pass.Length);

                // 送信日付
                UoeCommonFnc.MemCopy(ref dn_kai.ymd, SPACE, dn_kai.ymd.Length);

                // 送信時刻
                UoeCommonFnc.MemCopy(ref dn_kai.hms, SPACE, dn_kai.hms.Length);

                // 結果
                UoeCommonFnc.MemSet(ref dn_kai.res, SPACE_CODE, dn_kai.res.Length);

                // 発注区分
                dn_kai.hkb[0] = SPACE_CODE;

                // メッセージ
                UoeCommonFnc.MemSet(ref dn_kai.exten, SPACE_CODE, dn_kai.exten.Length);

                // データ作成処理
                return ToByteArray();
            }
            // HACK:▲

			# endregion
			# endregion

			# region private Methods
			# region バイト型配列に変換
			/// <summary>
			/// バイト型配列に変換
			/// </summary>
			/// <returns></returns>
			public byte[] ToByteArray()
			{
				MemoryStream ms = new MemoryStream();

				ms.Write(dn_kai.dbkb, 0, dn_kai.dbkb.Length);	//処理区分
				ms.Write(dn_kai.tcd, 0, dn_kai.tcd.Length);		//端末側コード
				ms.Write(dn_kai.hcd, 0, dn_kai.hcd.Length);		//ホストコード
				ms.Write(dn_kai.pass, 0, dn_kai.pass.Length);	//パスワード
				ms.Write(dn_kai.ymd, 0, dn_kai.ymd.Length);		//送信日付
				ms.Write(dn_kai.hms, 0, dn_kai.hms.Length);		//送信時刻
				ms.Write(dn_kai.res, 0, dn_kai.res.Length);		//結果
				ms.Write(dn_kai.hkb, 0, dn_kai.hkb.Length);		//発注区分
				ms.Write(dn_kai.exten, 0, dn_kai.exten.Length);	//メッセージ
				ms.Write(dn_kai.dummy, 0, dn_kai.dummy.Length);	//dummy

				byte[] toByteArray = ms.ToArray();
				ms.Close();
				return (toByteArray);
			}
			# endregion

			# endregion
		}
		# endregion

		# endregion

		// ===================================================================================== //
		// プライベートメソッド
		// ===================================================================================== //
		# region Private Methods
		# region ソートクエリ作成処理
		/// <summary>
		/// ソートクエリ作成処理
		/// </summary>
		/// <param name="para"></param>
		/// <returns></returns>
		private string GetSortQuerry(int businessCode)
		{
			string sortQuerry = "";

			switch (businessCode)
			{
				//発注
				case (int)EnumUoeConst.TerminalDiv.ct_Order:
					{
						sortQuerry = ctSortOrder;
						break;
					}
				//見積
				case (int)EnumUoeConst.TerminalDiv.ct_Estmt:
					{
						sortQuerry = ctSortEstmt;
						break;
					}
				//在庫
				case (int)EnumUoeConst.TerminalDiv.ct_Stock:
					{
						sortQuerry = ctSortStock;
						break;
					}
			}
			sortQuerry += ctSortUpper;
			return (sortQuerry);
		}
		# endregion

		# region フィルタークエリ作成処理
        /// <summary>
        /// フィルタークエリ作成処理
        /// </summary>
        /// <param name="businessCode">業務区分</param>
        /// <param name="cd">発注先コード</param>
        /// <returns>フィルタークエリ</returns>
        private string GetRowFilterQuerry(int businessCode, Int32 cd)
        {
            string rowFilterQuerry = "";

            switch (businessCode)
            {
                //発注
                case (int)EnumUoeConst.TerminalDiv.ct_Order:
                    {
                        rowFilterQuerry = string.Format("{0} = {1} AND {2} = {3}",
                            OrderSndRcvJnlSchema.ct_Col_UOESupplierCd, cd,
                            OrderSndRcvJnlSchema.ct_Col_DataSendCode, (int)EnumUoeConst.ctDataSendCode.ct_Process);
                        break;
                    }
                //見積
                case (int)EnumUoeConst.TerminalDiv.ct_Estmt:
                    {
                        rowFilterQuerry = "UOESupplierCd = " + cd;
                        break;
                    }
                //在庫
                case (int)EnumUoeConst.TerminalDiv.ct_Stock:
                    {
                        rowFilterQuerry = "UOESupplierCd = " + cd;
                        break;
                    }
            }
            return (rowFilterQuerry);
        }
        # endregion
		# endregion

	}
}

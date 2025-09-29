//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : ＵＯＥ送信編集（新マツダ）アクセスクラス
// プログラム概要   : ＵＯＥ送信編集（新マツダ）アクセスを行う
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
	/// ＵＯＥ送信編集（新マツダ）アクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : ＵＯＥ送信編集（新マツダ）アクセスクラス</br>
	/// <br>Programmer : 96186 立花裕輔</br>
	/// <br>Date       : 2008.05.26</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// <br>2008.05.26 men 新規作成</br>
	/// </remarks>
	public partial class UoeSndEdit0402Acs
	{
		// ===================================================================================== //
		// コンストラクタ
		// ===================================================================================== //
		# region Constructors
		public UoeSndEdit0402Acs()
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

		//システム区分 0:手入力 1:伝発 2:検索 3：一括 4：補充
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
		private const string MESSAGE_ERROR02 = "送受信ＪＮＬ＜発注＞（新マツダ）が見つかりません。";
		private const string MESSAGE_ERROR03 = "送受信ＪＮＬ＜見積＞（新マツダ）が見つかりません。";
		private const string MESSAGE_ERROR04 = "送受信ＪＮＬ＜在庫＞（新マツダ）が見つかりません。";

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

		# region ＵＯＥ送信編集（新マツダ）
		/// <summary>
		/// ＵＯＥ送信編集（新マツダ）
		/// </summary>
		/// <param name="uoeSndEditSearchPara"></param>
		/// <returns></returns>
		public int writeUOESNDEdit0402(Int32 businessCode, int systemDivCd, UOESupplier uOESupplier, out List<UoeSndDtl> list, out string message)
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
							status = writeUOESNDEditOrder0402(out _uoeSndDtlList, out message);
							break;
						}
					//見積
					case (int)EnumUoeConst.TerminalDiv.ct_Estmt:
						{
							status = writeUOESNDEditEstm0402(out _uoeSndDtlList, out message);
							break;
						}
					//在庫
					case (int)EnumUoeConst.TerminalDiv.ct_Stock:
						{
							status = writeUOESNDEditAlloc0402(out _uoeSndDtlList, out message);
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

		# region ＵＯＥ送信電文作成＜開局/閉局＞（新マツダ）
		/// <summary>
		/// ＵＯＥ送信電文作成＜開局/閉局＞（新マツダ）
		/// </summary>
		public class TelegramEditOpenClose0402
		{
			# region ＰＭ７ソース
												//-- 電文領域...開局 閉局要求 --
			//struct	DN_KAI {				// 69 + 1924 = 2048ﾊﾞｲﾄ       
			//	char	jh;						// ﾍｯﾀﾞ TTC  情報区分         
			//	char	ts[2];					//           ﾃｷｽﾄｼｰｹﾝｽ        
			//	char	lg[2];					//           ﾃｷｽﾄ長           
			//	char	dbkb;					//           電文区分         
			//	char	res;					//           処理結果         
			//	char	aite[7];				//           相手ｾﾝﾀｰ確認ｺｰﾄﾞ 
			//	char	toho[7];				//           当方ｾﾝﾀｰ確認ｺｰﾄﾞ 
			//	char	ymdhms[6];				//           通信年月日時分秒 
			//	char	pass[6];				//           ﾊﾟｽﾜｰﾄﾞ          
			//	char	apid;					//           ｱﾌﾟﾘｹｰｼｮﾝID      
			//	char	mode;					//           モード           
			//	char	exten[34];				//           拡張ｴﾘｱ          
			//	char	dummy[1979];			// ﾗｲﾝ       dummy            
			//};
			# endregion

			# region 電文領域クラス
			/// <summary>
			/// 開局・閉局電文領域
			/// </summary>
			private class DN_KAI
			{
				public byte[] jh = new byte[1];			// ﾍｯﾀﾞ TTC  情報区分          
				public byte[] ts = new byte[2];			//           ﾃｷｽﾄｼｰｹﾝｽ         
				public byte[] lg = new byte[2];			//           ﾃｷｽﾄ長            
				public byte[] dbkb = new byte[1];		//           電文区分          
				public byte[] res = new byte[1];		//           処理結果          
				public byte[] aite = new byte[7];		//           相手ｾﾝﾀｰ確認ｺｰﾄﾞ  
				public byte[] toho = new byte[7];		//           当方ｾﾝﾀｰ確認ｺｰﾄﾞ  
				public byte[] ymdhms = new byte[6];		//           通信年月日時分秒  
				public byte[] pass = new byte[6];		//           ﾊﾟｽﾜｰﾄﾞ           
				public byte[] apid = new byte[1];		//           ｱﾌﾟﾘｹｰｼｮﾝID       
				public byte[] mode = new byte[1];		//           モード            
				public byte[] exten = new byte[34];		//           拡張ｴﾘｱ           
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
					UoeCommonFnc.MemSet(ref jh, 0x20, jh.Length);		// ﾍｯﾀﾞ TTC  情報区分          
					UoeCommonFnc.MemSet(ref ts, 0x20, ts.Length);		//           ﾃｷｽﾄｼｰｹﾝｽ         
					UoeCommonFnc.MemSet(ref lg, 0x20, lg.Length);		//           ﾃｷｽﾄ長            
					UoeCommonFnc.MemSet(ref dbkb, 0x20, dbkb.Length);	//           電文区分          
					UoeCommonFnc.MemSet(ref res, 0x20, res.Length);		//           処理結果          
					UoeCommonFnc.MemSet(ref aite, 0x20, aite.Length);	//           相手ｾﾝﾀｰ確認ｺｰﾄﾞ  
					UoeCommonFnc.MemSet(ref toho, 0x20, toho.Length);	//           当方ｾﾝﾀｰ確認ｺｰﾄﾞ  
					UoeCommonFnc.MemSet(ref ymdhms, 0x20, ymdhms.Length);//           通信年月日時分秒  
					UoeCommonFnc.MemSet(ref pass, 0x20, pass.Length);	//           ﾊﾟｽﾜｰﾄﾞ           
					UoeCommonFnc.MemSet(ref apid, 0x20, apid.Length);	//           ｱﾌﾟﾘｹｰｼｮﾝID       
					UoeCommonFnc.MemSet(ref mode, 0x20, mode.Length);	//           モード            
					UoeCommonFnc.MemSet(ref exten, 0x20, exten.Length);	//           拡張ｴﾘｱ           
					UoeCommonFnc.MemSet(ref dummy, 0x20, dummy.Length);	// ﾗｲﾝ       dummy             
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
			public TelegramEditOpenClose0402()
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
			public byte[] Telegram(int openMode)
			{
				//クリア処理
				Clear();

				//データ編集処理
				// ﾍｯﾀﾞ TTC  情報区分
				dn_kai.jh[0] = 0x10;

				//テキストシーケンス
				UoeCommonFnc.MemSet(ref dn_kai.ts, 0x00, dn_kai.ts.Length);

				//ﾃｷｽﾄ長
				dn_kai.lg[0] = 0x00;
				dn_kai.lg[1] = 0x45;

				//電文区分
				//開局
				if (openMode == (int)EnumUoeConst.OpenMode.ct_OPEN)
				{
					dn_kai.dbkb[0] = 0x00;
				}
				//閉局
				else
				{
					dn_kai.dbkb[0] = 0x02;
				}

				//処理結果
				dn_kai.res[0] = 0x00;

				//相手ｾﾝﾀｰ確認ｺｰﾄﾞ
				UoeCommonFnc.MemCopy(ref dn_kai.aite, "UOE2   ", dn_kai.aite.Length);

				//当方ｾﾝﾀｰ確認ｺｰﾄﾞ
                UoeCommonFnc.MemCopy(ref dn_kai.toho, uOESupplier.UOETerminalCd, dn_kai.toho.Length);

				//通信年月日時分秒
                dn_kai.ymdhms[0] = UoeCommonFnc.ToByteFromInt32(DateTime.Now.Year % 100);   //年
                dn_kai.ymdhms[1] = UoeCommonFnc.ToByteFromInt32(DateTime.Now.Month);	    //月
                dn_kai.ymdhms[2] = UoeCommonFnc.ToByteFromInt32(DateTime.Now.Day);	        //日
                dn_kai.ymdhms[3] = UoeCommonFnc.ToByteFromInt32(DateTime.Now.Hour);	        //時
                dn_kai.ymdhms[4] = UoeCommonFnc.ToByteFromInt32(DateTime.Now.Minute);       //分
                dn_kai.ymdhms[5] = UoeCommonFnc.ToByteFromInt32(DateTime.Now.Second);       //秒

				//ﾊﾟｽﾜｰﾄﾞ
				UoeCommonFnc.MemCopy(ref dn_kai.pass, uOESupplier.UOEConnectPassword, 3);

				//ｱﾌﾟﾘｹｰｼｮﾝID
				UoeCommonFnc.MemCopy(ref dn_kai.apid, "C", dn_kai.apid.Length);

				//モード
				UoeCommonFnc.MemCopy(ref dn_kai.mode, "C", dn_kai.mode.Length);

				//拡張ｴﾘｱ
				UoeCommonFnc.MemSet(ref dn_kai.exten, 0x00, dn_kai.exten.Length);

				//データ作成処理
				return (ToByteArray());
			}
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

				ms.Write(dn_kai.jh, 0, dn_kai.jh.Length);			/* ﾍｯﾀﾞ TTC  情報区分          */
				ms.Write(dn_kai.ts, 0, dn_kai.ts.Length);			/*           ﾃｷｽﾄｼｰｹﾝｽ         */
				ms.Write(dn_kai.lg, 0, dn_kai.lg.Length);			/*           ﾃｷｽﾄ長            */
				ms.Write(dn_kai.dbkb, 0, dn_kai.dbkb.Length);		/*           電文区分          */
				ms.Write(dn_kai.res, 0, dn_kai.res.Length);			/*           処理結果          */
				ms.Write(dn_kai.aite, 0, dn_kai.aite.Length);		/*           相手ｾﾝﾀｰ確認ｺｰﾄﾞ  */
				ms.Write(dn_kai.toho, 0, dn_kai.toho.Length);		/*           当方ｾﾝﾀｰ確認ｺｰﾄﾞ  */
				ms.Write(dn_kai.ymdhms, 0, dn_kai.ymdhms.Length);	/*           通信年月日時分秒  */
				ms.Write(dn_kai.pass, 0, dn_kai.pass.Length);		/*           ﾊﾟｽﾜｰﾄﾞ           */
				ms.Write(dn_kai.apid, 0, dn_kai.apid.Length);		/*           ｱﾌﾟﾘｹｰｼｮﾝID       */
				ms.Write(dn_kai.mode, 0, dn_kai.mode.Length);		/*           モード            */
				ms.Write(dn_kai.exten, 0, dn_kai.exten.Length);		/*           拡張ｴﾘｱ           */
				ms.Write(dn_kai.dummy, 0, dn_kai.dummy.Length);		/* ﾗｲﾝ       dummy             */

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

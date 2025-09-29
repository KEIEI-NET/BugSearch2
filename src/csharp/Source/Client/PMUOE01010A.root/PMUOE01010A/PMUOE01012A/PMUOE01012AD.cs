//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : ＵＯＥ送信編集＜在庫＞（日産Ｎパーツ）アクセスクラス
// プログラム概要   : ＵＯＥ送信編集＜在庫＞（日産Ｎパーツ）アクセスを行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10402071-00 作成担当 : 立花 裕輔
// 作 成 日  2008/05/26  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// ＵＯＥ送信編集＜在庫＞（日産Ｎパーツ）アクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : ＵＯＥ送信編集＜在庫＞（日産Ｎパーツ）アクセスクラス</br>
	/// <br>Programmer : 96186 立花裕輔</br>
	/// <br>Date       : 2008.05.26</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// <br>2008.05.26 men 新規作成</br>
	/// </remarks>
	public partial class UoeSndEdit0202Acs
	{
		// ===================================================================================== //
		// プライベートメソッド
		// ===================================================================================== //
		# region Private Methods

		# region ＵＯＥ送信編集＜在庫＞（日産Ｎパーツ）
		/// <summary>
		/// ＵＯＥ送信編集＜在庫＞（日産Ｎパーツ）
		/// </summary>
		/// <param name="_uoeSndEditRst"></param>
		/// <param name="message"></param>
		/// <returns></returns>
		private int writeUOESNDEditAlloc0202(out List<UoeSndDtl> list, out string message)
		{
			//変数の初期化
			int status = (int)EnumUoeConst.Status.ct_NORMAL;
			int maxCount = 0;
			message = "";
			list = new List<UoeSndDtl>();
			List<UoeSndDtl> _list = new List<UoeSndDtl>();

			try
			{
				//データテーブル処理
				_stockView = new DataView();
				_stockView.Table = StockTable;
				_stockView.Sort = GetSortQuerry((int)EnumUoeConst.TerminalDiv.ct_Stock);
                _stockView.RowFilter = GetRowFilterQuerry((int)EnumUoeConst.TerminalDiv.ct_Stock,uOESupplier.UOESupplierCd);
				maxCount = _stockView.Count;

				if (maxCount == 0)
				{
					return (status);
				}

				//結果格納処理
				TelegramEditAlloc0202 telegramEditAlloc0202 = new TelegramEditAlloc0202();
                telegramEditAlloc0202.uOESupplier = uOESupplier;
                telegramEditAlloc0202.Seq = 1;

				UoeSndDtl uoeSndDtl = new UoeSndDtl();
				Int32 headerSet = 0;	//ヘッダー部設定フラグ 0:設定する 1:設定しない

				//＜開局電文作成＞
				TelegramEditOpenClose0202 telegramEditOpenClose0202 = new TelegramEditOpenClose0202();
                telegramEditOpenClose0202.uOESupplier = uOESupplier;
                
                //ＵＯＥ送信編集結果クラスの初期化
				uoeSndDtl = new UoeSndDtl();
				uoeSndDtl.UOESalesOrderRowNo = new List<int>();

				//送信電文(JIS)
				uoeSndDtl.SndTelegram = telegramEditOpenClose0202.Telegram((int)EnumUoeConst.OpenMode.ct_OPEN);
                uoeSndDtl.SndTelegramLen = telegramEditOpenClose0202.SndTelegramLen;

				//発注番号
				uoeSndDtl.UOESalesOrderNo = 0;
                _list.Add(uoeSndDtl);

				//＜在庫電文作成＞
				for (int i = 0; i < maxCount; i++)
				{
                    DataRow dr = StockView[i].Row;

					//電文生成領域にデータが存在
					//発注番号が変更された
					if ((headerSet != 0)
					&& (uoeSndDtl.UOESalesOrderNo != (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOESalesOrderNo]))
					{
						uoeSndDtl.SndTelegram = telegramEditAlloc0202.ToByteArray();
                        uoeSndDtl.SndTelegramLen = telegramEditAlloc0202.SndTelegramLen;
                        _list.Add(uoeSndDtl);
						headerSet = 0;
						telegramEditAlloc0202.Seq += 1;
					}
					//＜ヘッダー部設定処理＞
					if (headerSet == 0)
					{
						headerSet = 1;

						//電文明細クラスのクリア
						telegramEditAlloc0202.Clear();

						//ＵＯＥ送信編集結果クラスの初期化
						uoeSndDtl = new UoeSndDtl();

						//発注番号
						uoeSndDtl.UOESalesOrderNo = (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOESalesOrderNo];

						//行番号
						uoeSndDtl.UOESalesOrderRowNo = new List<int>();
						//送信電文(JIS)
						uoeSndDtl.SndTelegram = null;
					}

					//＜明細部設定処理＞
					//行番号
					uoeSndDtl.UOESalesOrderRowNo.Add((int)dr[StockSndRcvJnlSchema.ct_Col_UOESalesOrderRowNo]);

					//送信電文(JIS)
					telegramEditAlloc0202.Telegram(dr);
				}
				//電文生成領域にデータが存在
				if (headerSet != 0)
				{
					uoeSndDtl.SndTelegram = telegramEditAlloc0202.ToByteArray();
                    uoeSndDtl.SndTelegramLen = telegramEditAlloc0202.SndTelegramLen;
                    _list.Add(uoeSndDtl);
					headerSet = 0;
				}

				//＜閉局電文作成＞
				//ＵＯＥ送信編集結果クラスの初期化
				uoeSndDtl = new UoeSndDtl();
				uoeSndDtl.UOESalesOrderRowNo = new List<int>();

				//送信電文(JIS)
				uoeSndDtl.SndTelegram = telegramEditOpenClose0202.Telegram((int)EnumUoeConst.OpenMode.ct_CLOSE);
                uoeSndDtl.SndTelegramLen = telegramEditOpenClose0202.SndTelegramLen;

				//発注番号
				uoeSndDtl.UOESalesOrderNo = 0;
                _list.Add(uoeSndDtl);

				if ((status == (int)EnumUoeConst.Status.ct_NORMAL)
				&& (_list.Count > 0))
				{
					list = _list;
				}
			}
			catch (Exception ex)
			{
				message = ex.Message;
			}


			return status;
		}
		# endregion

		# region ＵＯＥ送信電文作成＜在庫＞（日産Ｎパーツ）
		/// <summary>
		/// ＵＯＥ送信電文作成＜在庫＞（日産Ｎパーツ）
		/// </summary>
		public class TelegramEditAlloc0202
		{
			# region ＰＭ７ソース
			///*-- 電文領域...本体...在確 -------------------------------------------*/
			//										/*-- 電文領域...ﾗｲﾝ...在確 ----*/
			//struct	LN_Z {						/* 15ﾊﾞｲﾄ                      */
			//	char	hb[12];						/* ﾗｲﾝ      品番               */
			//};

			//struct	DN_ZAI {					/* 64 + 60 +1924 = 2048ﾊﾞｲﾄ   */
			//	char	jh         ;				/* TTC   情報区分			  */
			//	char	ts     [ 2];		        /*       ﾃｷｽﾄｼｰｹﾝｽ		  	  */
			//	char	lg     [ 2];	   	    	/* 		 ﾃｷｽﾄ長				  */
			//	char	dbkb       ;				/* ﾍｯﾄﾞ  電文区分			  */
			//	char	res        ;				/*       処理結果			  */
			//	char	toikb      ;				/*       問い合わせ・応答区分 */
			//	char	gyoid  [12];				/*       業務ID			      */
			//	char	pass   [ 6];				/*       業務ﾊﾟｽﾜｰﾄﾞ		  */
			//	char	vers   [ 3];				/*       端末PGﾊﾞｰｼﾞｮﾝ		  */
			//	char	keikb      ;				/*       継続区分			  */
			//	char	trid   [ 3];				/*       取引ID			      */
			//	char	exten  [15];				/*       拡張エリア			  */
			//	char	syocd  [ 2];				/* 処理コード				  */
			//	char	wsuser [ 6];				/* 端末対応ﾕｰｻﾞｰｺｰﾄﾞ		  */
			//	char	urikyo [ 3];				/* 売上拠点					  */
			//	struct	LN_Z  z[ 5];				/* ﾗｲﾝ       15 * 4 =  75ﾊﾞｲﾄ */
			//	char	dummy[1929];			/* DUMMY			          */
			//};
			# endregion

			# region Const Members
			private const Int32 ctBufLen = 5;		//明細バッファサイズ
			private const Int32 ctDetailLen = 5;	//明細行数
            private const Int32 ctSndTelegramLen = 123; //送信電文サイズ
			# endregion

			# region Private Members
			//在庫電文
			private byte[] jh = new byte[1];				/* TTC   情報区分			  */
			private byte[] ts = new byte[2];		        /*       ﾃｷｽﾄｼｰｹﾝｽ		  	  */
			private byte[] lg = new byte[2];	   	    	/* 		 ﾃｷｽﾄ長				  */

			private byte[] dbkb = new byte[1];				/* ﾍｯﾄﾞ  電文区分			  */
			private byte[] res = new byte[1];				/*       処理結果			  */
			private byte[] toikb = new byte[1];				/*       問い合わせ・応答区分 */
			private byte[] gyoid = new byte[12];			/*       業務ID			      */
			private byte[] pass = new byte[6];				/*       業務ﾊﾟｽﾜｰﾄﾞ		  */
			private byte[] vers = new byte[3];				/*       端末PGﾊﾞｰｼﾞｮﾝ		  */
			private byte[] keikb = new byte[1];				/*       継続区分			  */
			private byte[] trid = new byte[3];				/*       取引ID			      */
			private byte[] exten = new byte[15];			/*       拡張エリア			  */
			private byte[] syocd = new byte[2];				/* 処理コード				  */
			private byte[] wsuser = new byte[6];			/* 端末対応ﾕｰｻﾞｰｺｰﾄﾞ		  */
			private byte[] urikyo = new byte[3];			/* 売上拠点					  */

			private byte[][] hb = new byte[ctBufLen][];		/* ﾗｲﾝ      品番              */

			private byte[] dummy = new byte[1929];			/* DUMMY			          */

			//変数
			private Int32 _seq = 1;
			private Int32 _ln = 0;
            private UOESupplier _uOESupplier = null;
            # endregion

			# region Constructors
			/// <summary>
			/// コンストラクタ
			/// </summary>
			public TelegramEditAlloc0202()
			{
				for (int i = 0; i < ctBufLen; i++)
				{
					hb[i] = new byte[12];	//品番
				}
				_seq = 1;
				Clear();
			}
			# endregion

			# region Properties
			# region SEQ番号
			public Int32 Seq
			{
				get
				{
					return this._seq;
				}
				set
				{
					this._seq = value;
				}
			}
			# endregion

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
				_ln = 0;

				//ＴＴＣ
				UoeCommonFnc.MemSet(ref jh, 0x20, jh.Length);				/* TTC   情報区分			  */
				UoeCommonFnc.MemSet(ref ts, 0x20, ts.Length);		        /*       ﾃｷｽﾄｼｰｹﾝｽ		  	  */
				UoeCommonFnc.MemSet(ref lg, 0x20, lg.Length);	   	    	/* 		 ﾃｷｽﾄ長				  */
				
				UoeCommonFnc.MemSet(ref dbkb, 0x20, dbkb.Length);			/* ﾍｯﾄﾞ  電文区分			  */
				UoeCommonFnc.MemSet(ref res, 0x20, res.Length);				/*       処理結果			  */
				UoeCommonFnc.MemSet(ref toikb, 0x20, toikb.Length);			/*       問い合わせ・応答区分 */
				UoeCommonFnc.MemSet(ref gyoid, 0x20, gyoid.Length);			/*       業務ID			      */
				UoeCommonFnc.MemSet(ref pass, 0x20, pass.Length);			/*       業務ﾊﾟｽﾜｰﾄﾞ		  */
				UoeCommonFnc.MemSet(ref vers, 0x20, vers.Length);			/*       端末PGﾊﾞｰｼﾞｮﾝ		  */
				UoeCommonFnc.MemSet(ref keikb, 0x20, keikb.Length);			/*       継続区分			  */
				UoeCommonFnc.MemSet(ref trid, 0x20, trid.Length);			/*       取引ID			      */
				UoeCommonFnc.MemSet(ref exten, 0x20, exten.Length);			/*       拡張エリア			  */
				UoeCommonFnc.MemSet(ref syocd, 0x20, syocd.Length);			/* 処理コード				  */
				UoeCommonFnc.MemSet(ref wsuser, 0x20, wsuser.Length);		/* 端末対応ﾕｰｻﾞｰｺｰﾄﾞ		  */
				UoeCommonFnc.MemSet(ref urikyo, 0x20, urikyo.Length);		/* 売上拠点					  */

				//明細部
				for (int i = 0; i < ctBufLen; i++)
				{
					UoeCommonFnc.MemSet(ref hb[i], 0x20, hb[i].Length);		/* ﾗｲﾝ      品番               */
				}

				//dummy
				UoeCommonFnc.MemSet(ref dummy, 0x20, dummy.Length);			/* DUMMY			          */
			}
			# endregion

			# region データ編集処理
			/// <summary>
			/// データ編集処理
			/// </summary>
			/// <param name="sec"></param>
			/// <param name="ln"></param>
			/// <param name="dr"></param>
			public void Telegram(DataRow dr)
			{
				//ＴＴＣ部 業務ヘッダー部 ヘッダー部作成
				if (_ln == 0)
				{

					# region ＜ＴＴＣ＞
					//ＴＴＣ
					/* TTC   情報区分			  */
					jh[0] = 0x11;

					/*       ﾃｷｽﾄｼｰｹﾝｽ		  	  */
					byte[] bBuf = UoeCommonFnc.ToByteAryFromInt32(_seq);

					ts[0] = bBuf[2];
					ts[1] = bBuf[3];

					/* 		 ﾃｷｽﾄ長				  */
					lg[0] = 0x00;
					lg[1] = 0x7b;
					# endregion

					# region ＜業務ヘッダー部＞
					//＜業務ヘッダー部＞
					/* ﾍｯﾄﾞ  電文区分			  */
					dbkb[0] = 0x60;

					/*       処理結果			  */
					res[0] = 0x00;

					/*       問い合わせ・応答区分 */
					UoeCommonFnc.MemCopy(ref toikb, "1", toikb.Length);

					/*       業務ID			      */
					UoeCommonFnc.MemSet(ref gyoid, 0x20, gyoid.Length);

					/*       業務ﾊﾟｽﾜｰﾄﾞ		  */
					UoeCommonFnc.MemSet(ref pass, 0x20, pass.Length);

					/*       端末PGﾊﾞｰｼﾞｮﾝ		  */
					UoeCommonFnc.MemSet(ref vers, 0x20, vers.Length);

					/*       継続区分			  */
					UoeCommonFnc.MemCopy(ref keikb, "N", keikb.Length);

					/*       取引ID			      */
					UoeCommonFnc.MemSet(ref trid, 0x20, trid.Length);

					/*       拡張エリア			  */
					UoeCommonFnc.MemSet(ref exten, 0x00, exten.Length);

					/* 処理コード				  */
					UoeCommonFnc.MemCopy(ref syocd, "Z2", syocd.Length);

					/* 端末対応ﾕｰｻﾞｰｺｰﾄﾞ		  */
					UoeCommonFnc.MemCopy(ref wsuser, (string)uOESupplier.UOEConnectUserId, wsuser.Length);

					/* 売上拠点					  */
					UoeCommonFnc.MemCopy(ref urikyo, uOESupplier.UOESalSectCd, urikyo.Length);
					# endregion
				}

				# region ＜明細部＞
				//＜明細部＞
				if (_ln < ctDetailLen)
				{
					//品番
					UoeCommonFnc.MemCopy(ref hb[_ln], (string)dr[StockSndRcvJnlSchema.ct_Col_GoodsNoNoneHyphen], hb[_ln].Length);

					//明細数インクリメント
					_ln++;
				}
				# endregion
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

				//ＴＴＣ
				ms.Write(jh, 0, jh.Length);				/* TTC   情報区分			  */
				ms.Write(ts, 0, ts.Length);		        /*       ﾃｷｽﾄｼｰｹﾝｽ		  	  */
				ms.Write(lg, 0, lg.Length);	   	    	/* 		 ﾃｷｽﾄ長				  */

				ms.Write(dbkb, 0, dbkb.Length);			/* ﾍｯﾄﾞ  電文区分			  */
				ms.Write(res, 0, res.Length);			/*       処理結果			  */
				ms.Write(toikb, 0, toikb.Length);		/*       問い合わせ・応答区分 */
				ms.Write(gyoid, 0, gyoid.Length);		/*       業務ID			      */
				ms.Write(pass, 0, pass.Length);			/*       業務ﾊﾟｽﾜｰﾄﾞ		  */
				ms.Write(vers, 0, vers.Length);			/*       端末PGﾊﾞｰｼﾞｮﾝ		  */
				ms.Write(keikb, 0, keikb.Length);		/*       継続区分			  */
				ms.Write(trid, 0, trid.Length);			/*       取引ID			      */
				ms.Write(exten, 0, exten.Length);		/*       拡張エリア			  */
				ms.Write(syocd, 0, syocd.Length);		/* 処理コード				  */
				ms.Write(wsuser, 0, wsuser.Length);		/* 端末対応ﾕｰｻﾞｰｺｰﾄﾞ		  */
				ms.Write(urikyo, 0, urikyo.Length);		/* 売上拠点					  */

				//明細部
				for (int i = 0; i < ctBufLen; i++)
				{
					ms.Write(hb[i], 0, hb[i].Length);/* ﾗｲﾝ      品番              */
				}

				//dummy
				ms.Write(dummy, 0, dummy.Length);	/* DUMMY			          */

				byte[] toByteArray = ms.ToArray();
				ms.Close();
				return (toByteArray);
			}
			# endregion

			# endregion
		}
		# endregion


		# endregion


	}
}

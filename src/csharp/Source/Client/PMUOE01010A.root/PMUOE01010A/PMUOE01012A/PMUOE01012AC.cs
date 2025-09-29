//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : ＵＯＥ送信編集＜見積＞（日産Ｎパーツ）アクセスクラス
// プログラム概要   : ＵＯＥ送信編集＜見積＞（日産Ｎパーツ）アクセスを行う
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
	/// ＵＯＥ送信編集＜見積＞（日産Ｎパーツ）アクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : ＵＯＥ送信編集＜見積＞（日産Ｎパーツ）アクセスクラス</br>
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

		# region ＵＯＥ送信編集＜見積＞（日産Ｎパーツ）
		/// <summary>
		/// ＵＯＥ送信編集＜見積＞（日産Ｎパーツ）
		/// </summary>
		/// <param name="_uoeSndEditRst"></param>
		/// <param name="message"></param>
		/// <returns></returns>
		private int writeUOESNDEditEstm0202(out List<UoeSndDtl> list, out string message)
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
				_estmtView = new DataView();
				_estmtView.Table = EstmtTable;
				_estmtView.Sort = GetSortQuerry((int)EnumUoeConst.TerminalDiv.ct_Estmt);
                _estmtView.RowFilter = GetRowFilterQuerry((int)EnumUoeConst.TerminalDiv.ct_Estmt,uOESupplier.UOESupplierCd);
				maxCount = _estmtView.Count;

				if (maxCount == 0)
				{
					return (status);
				}

				//結果格納処理
				TelegramEditEstm0202 telegramEditEstm0202 = new TelegramEditEstm0202();
                telegramEditEstm0202.uOESupplier = uOESupplier;	
				telegramEditEstm0202.Seq = 1;

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

				//＜見積電文作成＞
				for (int i = 0; i < maxCount; i++)
				{
					DataRow dr = EstmtView[i].Row;

					//電文生成領域にデータが存在
					//発注番号が変更された
					if ((headerSet != 0)
					&& (uoeSndDtl.UOESalesOrderNo != (Int32)dr[EstmtSndRcvJnlSchema.ct_Col_UOESalesOrderNo]))
					{
						uoeSndDtl.SndTelegram = telegramEditEstm0202.ToByteArray();
                        uoeSndDtl.SndTelegramLen = telegramEditEstm0202.SndTelegramLen;
                        _list.Add(uoeSndDtl);
						headerSet = 0;
						telegramEditEstm0202.Seq += 1;
					}
					//＜ヘッダー部設定処理＞
					if (headerSet == 0)
					{
						headerSet = 1;

						//電文明細クラスのクリア
						telegramEditEstm0202.Clear();

						//ＵＯＥ送信編集結果クラスの初期化
						uoeSndDtl = new UoeSndDtl();

						//発注番号
						uoeSndDtl.UOESalesOrderNo = (Int32)dr[EstmtSndRcvJnlSchema.ct_Col_UOESalesOrderNo];

						//行番号
						uoeSndDtl.UOESalesOrderRowNo = new List<int>();
						//送信電文(JIS)
						uoeSndDtl.SndTelegram = null;
					}

					//＜明細部設定処理＞
					//行番号
					uoeSndDtl.UOESalesOrderRowNo.Add((int)dr[EstmtSndRcvJnlSchema.ct_Col_UOESalesOrderRowNo]);

					//送信電文(JIS)
					telegramEditEstm0202.Telegram(dr);
				}
				//電文生成領域にデータが存在
				if (headerSet != 0)
				{
					uoeSndDtl.SndTelegram = telegramEditEstm0202.ToByteArray();
                    uoeSndDtl.SndTelegramLen = telegramEditEstm0202.SndTelegramLen;
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

		# region ＵＯＥ送信電文作成＜見積＞（日産Ｎパーツ）
		/// <summary>
		/// ＵＯＥ送信電文作成＜見積＞（日産Ｎパーツ）
		/// </summary>
		public class TelegramEditEstm0202
		{
			# region ＰＭ７ソース
			///*-- 電文領域...本体...見積 -------------------------------------------*/
			//										/*-- 電文領域...ﾗｲﾝ...見積 ----*/
			//struct	LN_M {							/* 15ﾊﾞｲﾄ                      */
			//	char	hb[12];						/* ﾗｲﾝ      品番               */
			//	char	msu[3];						/*          数量               */
			//};

			//struct	DN_MIT {						/* 87+150+1811 = 2048ﾊﾞｲﾄ     */
			//	char	jh         ;			    /* TTC   情報区分	          */
			//	char	ts     [ 2];		        /*       ﾃｷｽﾄｼｰｹﾝｽ		  	  */
			//	char	lg     [ 2];	   	    	/* 		 ﾃｷｽﾄ長				  */
			//	char	dbkb       ;			    /* ﾍｯﾄﾞ  電文区分			  */
			//	char	res        ;			    /*       処理結果	          */
			//	char	toikb      ;			    /*       問い合わせ・応答区分 */
			//	char	gyoid  [12];			    /*       業務ID	              */
			//	char	pass   [ 6];				/*       業務ﾊﾟｽﾜｰﾄﾞ	      */
			//	char	vers   [ 3];				/*       端末PGﾊﾞｰｼﾞｮﾝ		  */
			//	char	keikb      ;			    /*       継続区分	          */
			//	char	trid   [ 3];			    /*       取引ID	              */
			//	char	exten  [15];			    /*       拡張エリア	          */
			//	char	syocd  [ 2];			    /*       処理コード	          */
			//	char	wsuser [ 6];			    /*       端末対応ﾕｰｻﾞｰｺｰﾄﾞ	  */
			//	char	urikyo [ 3];			    /*       売上拠点			  */
			//	char	usercd [ 6];			    /*       ﾕｰｻﾞｰｺｰﾄﾞ			  */
			//	char	reto   [ 3];			    /*       ﾚｰﾄ			      */
			//	char	senc       ;			    /*       選択ｺｰﾄﾞ			  */
			//	char	rem    [10];			    /*       コメント			  */
			//	struct	LN_M  m[10];				/* ﾗｲﾝ       18*10=180ﾊﾞｲﾄ    */
			//	char	dummy[1819];				/* DUMMY			          */
			//};
			# endregion

			# region Const Members
			private const Int32 ctBufLen = 10;		//明細バッファサイズ
			private const Int32 ctDetailLen = 10;	//明細行数
            private const Int32 ctSndTelegramLen = 233; //送信電文サイズ
			# endregion

			# region Private Members
			//見積電文
			private byte[] jh = new byte[1];			/* TTC   情報区分	          */
			private byte[] ts = new byte[2];		    /*       ﾃｷｽﾄｼｰｹﾝｽ		  	  */
			private byte[] lg = new byte[2];	   	    /* 		 ﾃｷｽﾄ長				  */

			private byte[] dbkb = new byte[1];			/* ﾍｯﾄﾞ  電文区分			  */
			private byte[] res = new byte[1];			/*       処理結果	          */
			private byte[] toikb = new byte[1];			/*       問い合わせ・応答区分 */
			private byte[] gyoid = new byte[12];		/*       業務ID	              */
			private byte[] pass = new byte[6];			/*      業務ﾊﾟｽﾜｰﾄﾞ		      */
			private byte[] vers = new byte[3];			/*       端末PGﾊﾞｰｼﾞｮﾝ		  */
			private byte[] keikb = new byte[1];			/*       継続区分	          */
			private byte[] trid = new byte[3];			/*       取引ID	              */
			private byte[] exten = new byte[15];		/*       拡張エリア	          */

			private byte[] syocd = new byte[2];			/*       処理コード	          */
			private byte[] wsuser = new byte[6];		/*       端末対応ﾕｰｻﾞｰｺｰﾄﾞ	  */
			private byte[] urikyo = new byte[3];		/*       売上拠点			  */

			private byte[] usercd = new byte[6];		/*       ﾕｰｻﾞｰｺｰﾄﾞ			  */
			private byte[] reto = new byte[3];			/*       ﾚｰﾄ			      */
			private byte[] senc = new byte[1];			/*       選択ｺｰﾄﾞ			  */
			private byte[] rem = new byte[10];			/*       コメント			  */

			private byte[][] hb = new byte[ctBufLen][];	/* ﾗｲﾝ      品番              */
			private byte[][] msu = new byte[ctBufLen][];/*          数量              */

			private byte[] dummy = new byte[1819];		/* DUMMY			          */

			//変数
			private Int32 _seq = 1;
			private Int32 _ln = 0;
            private UOESupplier _uOESupplier = null;
            # endregion

			# region Constructors
			/// <summary>
			/// コンストラクタ
			/// </summary>
			public TelegramEditEstm0202()
			{
				for (int i = 0; i < ctBufLen; i++)
				{
					hb[i] = new byte[12];	//品番
					msu[i] = new byte[3];	//数量
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
				UoeCommonFnc.MemSet(ref jh, 0x20, jh.Length);			    /* TTC   情報区分	          */
				UoeCommonFnc.MemSet(ref ts, 0x20, ts.Length);		        /*       ﾃｷｽﾄｼｰｹﾝｽ		  	  */
				UoeCommonFnc.MemSet(ref lg, 0x20, lg.Length);	   	    	/* 		 ﾃｷｽﾄ長				  */

				//業務ヘッダー部
				UoeCommonFnc.MemSet(ref dbkb, 0x20, dbkb.Length);			/* ﾍｯﾄﾞ  電文区分			  */
				UoeCommonFnc.MemSet(ref res, 0x20, res.Length);			    /*       処理結果	          */
				UoeCommonFnc.MemSet(ref toikb, 0x20, toikb.Length);			/*       問い合わせ・応答区分 */
				UoeCommonFnc.MemSet(ref gyoid, 0x20, gyoid.Length);			/*       業務ID	              */
				UoeCommonFnc.MemSet(ref pass, 0x20, pass.Length);			/*       業務ﾊﾟｽﾜｰﾄﾞ	      */
				UoeCommonFnc.MemSet(ref vers, 0x20, vers.Length);			/*       端末PGﾊﾞｰｼﾞｮﾝ		  */
				UoeCommonFnc.MemSet(ref keikb, 0x20, keikb.Length);			/*       継続区分	          */
				UoeCommonFnc.MemSet(ref trid, 0x20, trid.Length);			/*       取引ID	              */
				UoeCommonFnc.MemSet(ref exten, 0x20, exten.Length);			/*       拡張エリア	          */
				UoeCommonFnc.MemSet(ref syocd, 0x20, syocd.Length);			/*       処理コード	          */

				UoeCommonFnc.MemSet(ref wsuser, 0x20, wsuser.Length);		/*       端末対応ﾕｰｻﾞｰｺｰﾄﾞ	  */
				UoeCommonFnc.MemSet(ref urikyo, 0x20, urikyo.Length);		/*       売上拠点			  */

				//ヘッダー部
				UoeCommonFnc.MemSet(ref usercd, 0x20, usercd.Length);		/*       ﾕｰｻﾞｰｺｰﾄﾞ			  */
				UoeCommonFnc.MemSet(ref reto, 0x20, reto.Length);			/*       ﾚｰﾄ			      */
				UoeCommonFnc.MemSet(ref senc, 0x20, senc.Length);			/*       選択ｺｰﾄﾞ			  */
				UoeCommonFnc.MemSet(ref rem, 0x20, rem.Length);			    /*       コメント			  */

				//明細部
				for (int i = 0; i < ctBufLen; i++)
				{
					UoeCommonFnc.MemSet(ref hb[i], 0x20, hb[i].Length);		/* ﾗｲﾝ      品番               */
					UoeCommonFnc.MemSet(ref msu[i], 0x20, msu[i].Length);	/*          数量               */
				}

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
					# region ＜ＴＴＣ部＞
					//ＴＴＣ
					/* TTC   情報区分	          */
					jh[0] = 0x11;

					/*       ﾃｷｽﾄｼｰｹﾝｽ		  	  */
					byte[] bBuf = UoeCommonFnc.ToByteAryFromInt32(_seq);

					ts[0] = bBuf[2];
					ts[1] = bBuf[3];
					
					/* 		 ﾃｷｽﾄ長				  */
					lg[0] = 0x00;
					lg[1] = 0xe9;
					# endregion

					# region ＜業務ヘッダー部＞
					//業務ヘッダー部
					/* ﾍｯﾄﾞ  電文区分			  */
					dbkb[0] = 0x60;

					/*       処理結果	          */
					res[0] = 0x00;

					/*       問い合わせ・応答区分 */
					UoeCommonFnc.MemCopy(ref toikb, "1", toikb.Length);

					/*       業務ID	              */
					UoeCommonFnc.MemSet(ref gyoid, 0x20, gyoid.Length);

					/*       業務ﾊﾟｽﾜｰﾄﾞ	      */
					UoeCommonFnc.MemSet(ref pass, 0x20, pass.Length);

					/*       端末PGﾊﾞｰｼﾞｮﾝ		  */
					UoeCommonFnc.MemSet(ref vers, 0x20, vers.Length);

					/*       継続区分	          */
					UoeCommonFnc.MemCopy(ref keikb, "S", keikb.Length);

					/*       取引ID	              */
					UoeCommonFnc.MemSet(ref trid, 0x20, trid.Length);

					/*       拡張エリア	          */
					UoeCommonFnc.MemSet(ref exten, 0x00, exten.Length);

					/*       処理コード	          */
					UoeCommonFnc.MemCopy(ref syocd, "N3", syocd.Length);

					/*       端末対応ﾕｰｻﾞｰｺｰﾄﾞ	  */
					UoeCommonFnc.MemCopy(ref wsuser, (string)uOESupplier.UOEConnectUserId, wsuser.Length);

					/*       売上拠点			  */
					UoeCommonFnc.MemCopy(ref urikyo, uOESupplier.UOESalSectCd, urikyo.Length);
					# endregion

					# region ＜ヘッダー部＞
					//ヘッダー部
					/*       ﾕｰｻﾞｰｺｰﾄﾞ			  */
					UoeCommonFnc.MemCopy(ref usercd, (string)uOESupplier.UOEConnectUserId, usercd.Length);
					
					/*       ﾚｰﾄ			      */
					UoeCommonFnc.MemCopy(ref reto, UoeCommonFnc.GetUnderString((string)dr[EstmtSndRcvJnlSchema.ct_Col_EstimateRate], reto.Length), reto.Length);

					/*       選択ｺｰﾄﾞ			  */
                    senc[0] = 0x31;

					/*       コメント			  */
					UoeCommonFnc.MemCopy(ref rem, (string)dr[EstmtSndRcvJnlSchema.ct_Col_UoeRemark1], rem.Length);
					# endregion

				}

				# region ＜明細部＞
				//＜明細部＞
				if (_ln < ctDetailLen)
				{
					//品番
					UoeCommonFnc.MemCopy(ref hb[_ln], (string)dr[EstmtSndRcvJnlSchema.ct_Col_GoodsNoNoneHyphen], hb[_ln].Length);

					//数量
					double hsuDouble = (double)dr[EstmtSndRcvJnlSchema.ct_Col_AcceptAnOrderCnt];
                    UoeCommonFnc.MemCopy(ref msu[_ln], String.Format("{0:d3}", (int)hsuDouble), msu[_ln].Length);

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
				ms.Write(jh, 0, jh.Length);			    /* TTC   情報区分	          */
				ms.Write(ts, 0, ts.Length);		        /*       ﾃｷｽﾄｼｰｹﾝｽ		  	  */
				ms.Write(lg, 0, lg.Length);	   	    	/* 		 ﾃｷｽﾄ長				  */

				//業務ヘッダー部
				ms.Write(dbkb, 0, dbkb.Length);			/* ﾍｯﾄﾞ  電文区分			  */
				ms.Write(res, 0, res.Length);			/*       処理結果	          */
				ms.Write(toikb, 0, toikb.Length);		/*       問い合わせ・応答区分 */
				ms.Write(gyoid, 0, gyoid.Length);		/*       業務ID	              */
				ms.Write(pass, 0, pass.Length);			/*       業務ﾊﾟｽﾜｰﾄﾞ	      */
				ms.Write(vers, 0, vers.Length);			/*       端末PGﾊﾞｰｼﾞｮﾝ		  */
				ms.Write(keikb, 0, keikb.Length);		/*       継続区分	          */
				ms.Write(trid, 0, trid.Length);			/*       取引ID	              */
				ms.Write(exten, 0, exten.Length);		/*       拡張エリア	          */
				ms.Write(syocd, 0, syocd.Length);		/*       処理コード	          */

				ms.Write(wsuser, 0, wsuser.Length);		/*       端末対応ﾕｰｻﾞｰｺｰﾄﾞ	  */
				ms.Write(urikyo, 0, urikyo.Length);		/*       売上拠点			  */

				//ヘッダー部
				ms.Write(usercd, 0, usercd.Length);		/*       ﾕｰｻﾞｰｺｰﾄﾞ			  */
				ms.Write(reto, 0, reto.Length);			/*       ﾚｰﾄ			      */
				ms.Write(senc, 0, senc.Length);			/*       選択ｺｰﾄﾞ			  */
				ms.Write(rem, 0, rem.Length);			/*       コメント			  */

				//明細部
				for (int i = 0; i < ctBufLen; i++)
				{
					ms.Write(hb[i], 0, hb[i].Length);	/* ﾗｲﾝ      品番               */
					ms.Write(msu[i], 0, msu[i].Length);	/*          数量               */
				}

				ms.Write(dummy, 0, dummy.Length);		/* DUMMY			          */


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

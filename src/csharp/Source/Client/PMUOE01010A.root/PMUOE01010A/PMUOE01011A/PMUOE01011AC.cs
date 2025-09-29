//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : ＵＯＥ送信編集＜見積＞（トヨタＰＤ４）アクセスクラス
// プログラム概要   : ＵＯＥ送信編集＜見積＞（トヨタＰＤ４）アクセスを行う
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

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// ＵＯＥ送信編集＜見積＞（トヨタＰＤ４）アクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : ＵＯＥ送信編集＜見積＞（トヨタＰＤ４）アクセスクラス</br>
	/// <br>Programmer : 96186 立花裕輔</br>
	/// <br>Date       : 2008.05.26</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// <br>2008.05.26 men 新規作成</br>
	/// </remarks>
	public partial class UoeSndEdit0102Acs
	{
		// ===================================================================================== //
		// プライベートメソッド
		// ===================================================================================== //
		# region Private Methods

		# region ＵＯＥ送信編集＜見積＞（トヨタＰＤ４）
		/// <summary>
		/// ＵＯＥ送信編集＜見積＞（トヨタＰＤ４）
		/// </summary>
		/// <param name="_uoeSndEditRst"></param>
		/// <param name="message"></param>
		/// <returns></returns>
		private int writeUOESNDEditEstm0102(out List<UoeSndDtl> list, out string message)
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
                _estmtView.RowFilter = GetRowFilterQuerry((int)EnumUoeConst.TerminalDiv.ct_Estmt, uOESupplier.UOESupplierCd);
				maxCount = _estmtView.Count;

				if (maxCount == 0)
				{
					return (status);
				}

				//結果格納処理
				TelegramEditEstm0102 telegramEditEstm0102 = new TelegramEditEstm0102();
                telegramEditEstm0102.uOESupplier = uOESupplier;
				telegramEditEstm0102.Seq = 1;

				UoeSndDtl uoeSndDtl = new UoeSndDtl();
				Int32 headerSet = 0;	//ヘッダー部設定フラグ 0:設定する 1:設定しない
				for (int i = 0; i < maxCount; i++)
				{
					DataRow dr = EstmtView[i].Row;

					//電文生成領域にデータが存在
					//発注番号が変更された
					if ((headerSet != 0)
					&& (uoeSndDtl.UOESalesOrderNo != (Int32)dr[EstmtSndRcvJnlSchema.ct_Col_UOESalesOrderNo]))
					{
						uoeSndDtl.SndTelegram = telegramEditEstm0102.ToByteArray(0);
                        uoeSndDtl.SndTelegramLen = telegramEditEstm0102.SndTelegramLen;
						_list.Add(uoeSndDtl);
						headerSet = 0;
						telegramEditEstm0102.Seq += 1;
					}
					//＜ヘッダー部設定処理＞
					if (headerSet == 0)
					{
						headerSet = 1;

						//電文明細クラスのクリア
						telegramEditEstm0102.Clear();

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
					telegramEditEstm0102.Telegram(dr);
				}
				//電文生成領域にデータが存在
				if (headerSet != 0)
				{
					uoeSndDtl.SndTelegram = telegramEditEstm0102.ToByteArray(1);
                    uoeSndDtl.SndTelegramLen = telegramEditEstm0102.SndTelegramLen;
                    _list.Add(uoeSndDtl);
					headerSet = 0;
				}

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

		# region ＵＯＥ送信電文作成＜見積＞（トヨタＰＤ４）
		/// <summary>
		/// ＵＯＥ送信電文作成＜見積＞（トヨタＰＤ４）
		/// </summary>
		public class TelegramEditEstm0102
		{
			# region ＰＭ７ソース
			//									/*-- 電文領域...ﾗｲﾝ...見積 --*/
			//struct	LN_M {					/* 17ﾊﾞｲﾄ                     */
			//	char	hb[12];					/* ﾗｲﾝ      品番              */
			//	char	hsu[5];					/*          数量              */
			//};

			//									/*-- 電文領域...本体...見積 --*/
			//struct	DN_M {					/* 65 + 340 + 1643 = 2048ﾊﾞｲﾄ */
			//	char	jh;						/* ﾍｯﾀﾞ TTC  情報区分         */
			//	char	ts[2];					/*           ﾃｷｽﾄｼｰｹﾝｽ        */
			//	char	lg[2];					/*           ﾃｷｽﾄ長           */
			//	char	tr[3];					/*      ID   ﾄﾗﾝｻﾞｸｼｮﾝｺｰﾄﾞ    */
			//	char	res;					/*           処理結果         */
			//	char	seq[3];					/*           seq番号          */
			//	char	acd[7];					/*           相手先ｺｰﾄﾞ       */
			//	char	tcd[7];					/*           当方ｺｰﾄﾞ         */
			//	char	dttm[6];				/*           日付･時刻        */
			//	char	pass[6];				/*           ﾊﾟｽﾜｰﾄﾞ          */
			//	char	kflg;					/*           継続ﾌﾗｸﾞ         */
			//	char	rem3[12];				/*      ﾍｯﾄﾞ ﾘﾏｰｸ3            */
			//	char	retok;					/*      	 ﾚｰﾄ区分          */
			//	char	reto[4];				/*           ﾚｰﾄ              */
			//	char	senc;					/*           選択ｺｰﾄﾞ         */
			//	char	remk[8];				/*           ﾘﾏｰｸ             */
			//
			//	struct	LN_M	ln_m[20];		/* ﾗｲﾝ       17*20=340ﾊﾞｲﾄ    */
			//	char	dummy[1643];			/* ﾗｲﾝ       dummy            */
			//};
			# endregion

			# region Const Members
			private const Int32 ctBufLen = 20;		//明細バッファサイズ
			private const Int32 ctDetailLen = 10;	//明細行数
            private const Int32 ctSndTelegramLen = 235; //送信電文サイズ
            # endregion

			# region Private Members
			//見積電文
			private byte[] jh = new byte[1];		/* ﾍｯﾀﾞ TTC  情報区分         */
			private byte[] ts = new byte[2];		/*           ﾃｷｽﾄｼｰｹﾝｽ        */
			private byte[] lg = new byte[2];		/*           ﾃｷｽﾄ長           */

			private byte[] tr = new byte[3];		/*      ID   ﾄﾗﾝｻﾞｸｼｮﾝｺｰﾄﾞ    */
			private byte[] res = new byte[1];		/*           処理結果         */
			private byte[] seq = new byte[3];		/*           seq番号          */
			private byte[] acd = new byte[7];		/*           相手先ｺｰﾄﾞ       */
			private byte[] tcd = new byte[7];		/*           当方ｺｰﾄﾞ         */
			private byte[] dttm = new byte[6];		/*           日付･時刻        */
			private byte[] pass = new byte[6];		/*           ﾊﾟｽﾜｰﾄﾞ          */
			private byte[] kflg = new byte[1];		/*           継続ﾌﾗｸﾞ         */

			private byte[] rem3 = new byte[12];		/*      ﾍｯﾄﾞ ﾘﾏｰｸ3            */
			private byte[] retok = new byte[1];		/*      	 ﾚｰﾄ区分          */
			private byte[] reto = new byte[4];		/*           ﾚｰﾄ              */
			private byte[] senc = new byte[1];		/*           選択ｺｰﾄﾞ         */
			private byte[] remk = new byte[8];		/*           ﾘﾏｰｸ             */

			private byte[][] hb = new byte[ctBufLen][];	/* ﾗｲﾝ      品番              */
			private byte[][] hsu = new byte[ctBufLen][];/*          数量              */

			private byte[] dummy = new byte[1643];	/* ﾗｲﾝ       dummy            */


			//変数
			private Int32 _seq = 1;
			private Int32 _ln = 0;

            private UOESupplier _uOESupplier = null;
            # endregion

			# region Constructors
			/// <summary>
			/// コンストラクタ
			/// </summary>
			public TelegramEditEstm0102()
			{
				for (int i = 0; i < ctBufLen; i++)
				{
					hb[i] = new byte[12];	//品番
					hsu[i] = new byte[5];	//数量
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
				UoeCommonFnc.MemSet(ref jh, 0x20, jh.Length);			/* ﾍｯﾀﾞ TTC  情報区分         */
				UoeCommonFnc.MemSet(ref ts, 0x20, ts.Length);			/*           ﾃｷｽﾄｼｰｹﾝｽ        */
				UoeCommonFnc.MemSet(ref lg, 0x20, lg.Length);			/*           ﾃｷｽﾄ長           */

				//業務ヘッダー部
				UoeCommonFnc.MemSet(ref tr, 0x20, tr.Length);			/*      ID   ﾄﾗﾝｻﾞｸｼｮﾝｺｰﾄﾞ    */
				UoeCommonFnc.MemSet(ref res, 0x20, res.Length);			/*           処理結果         */
				UoeCommonFnc.MemSet(ref seq, 0x20, seq.Length);			/*           seq番号          */
				UoeCommonFnc.MemSet(ref acd, 0x20, acd.Length);			/*           相手先ｺｰﾄﾞ       */
				UoeCommonFnc.MemSet(ref tcd, 0x20, tcd.Length);			/*           当方ｺｰﾄﾞ         */
				UoeCommonFnc.MemSet(ref dttm, 0x20, dttm.Length);		/*           日付･時刻        */
				UoeCommonFnc.MemSet(ref pass, 0x20, pass.Length);		/*           ﾊﾟｽﾜｰﾄﾞ          */
				UoeCommonFnc.MemSet(ref kflg, 0x20, kflg.Length);		/*           継続ﾌﾗｸﾞ         */

				//ヘッダー部
				UoeCommonFnc.MemSet(ref rem3, 0x20, rem3.Length);		/*      ﾍｯﾄﾞ ﾘﾏｰｸ3            */
				UoeCommonFnc.MemSet(ref retok, 0x20, retok.Length);		/*      	 ﾚｰﾄ区分          */
				UoeCommonFnc.MemSet(ref reto, 0x20, reto.Length);		/*           ﾚｰﾄ              */
				UoeCommonFnc.MemSet(ref senc, 0x20, senc.Length);		/*           選択ｺｰﾄﾞ         */
				UoeCommonFnc.MemSet(ref remk, 0x20, remk.Length);		/*           ﾘﾏｰｸ             */

				//明細部
				for (int i = 0; i < ctBufLen; i++)
				{
					UoeCommonFnc.MemSet(ref hb[i], 0x20, hb[i].Length);		//品番
					UoeCommonFnc.MemSet(ref hsu[i], 0x20, hsu[i].Length);	//数量
				}
				//dummy
				UoeCommonFnc.MemSet(ref dummy, 0x20, dummy.Length);		//dummy
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
					//＜ＴＴＣ＞
					//情報区分
					jh[0] = 0x31;

					//テキストシーケンス
					UoeCommonFnc.MemSet(ref ts, 0x00, ts.Length);

					//テキスト長
					lg[0] = 0x00;
					lg[1] = 0xeb;
					# endregion

					# region ＜業務ヘッダー部＞
					//＜業務ヘッダー部＞
					//トランザクションコード
					UoeCommonFnc.MemCopy(ref tr, "C40", tr.Length);

					//処理結果
					res[0] = 0x00;

					//SEQ番号
                    UoeCommonFnc.MemCopy(ref seq, String.Format("{0:D3}", _seq), seq.Length);

					//相手先コード
					UoeCommonFnc.MemSet(ref acd, 0x30, acd.Length);

					//当方コード
                    UoeCommonFnc.MemCopy(ref tcd, uOESupplier.UOETerminalCd, tcd.Length);

					//日付･時刻
					UoeCommonFnc.MemSet(ref dttm, 0x00, dttm.Length);

					//パスワード
					UoeCommonFnc.MemCopy(ref pass, uOESupplier.UOEConnectPassword, pass.Length);

					//継続フラグ
					kflg[0] = 0x30;
					# endregion

					# region ＜ヘッダー部＞
					//＜ヘッダー部＞
					//ﾘﾏｰｸ3
					UoeCommonFnc.MemSet(ref rem3, 0x00, rem3.Length);
					rem3[0] = UoeCommonFnc.ToByteFromInt32(DateTime.Now.Day);		//日
                    rem3[1] = UoeCommonFnc.ToByteFromInt32(DateTime.Now.Hour);	//時
                    rem3[2] = UoeCommonFnc.ToByteFromInt32(DateTime.Now.Minute);	//分
                    rem3[3] = UoeCommonFnc.ToByteFromInt32(DateTime.Now.Second);	//秒

					//ﾚｰﾄ区分 
					UoeCommonFnc.MemCopy(ref retok, (string)dr[EstmtSndRcvJnlSchema.ct_Col_EstimateRate], retok.Length);

					//ﾚｰﾄ
                    string retoString = UoeCommonFnc.GetRemove((string)dr[EstmtSndRcvJnlSchema.ct_Col_EstimateRate], 0, 1);
                    UoeCommonFnc.MemCopy(ref reto, retoString, reto.Length);

					//選択ｺｰﾄﾞ
                    senc[0] = 0x31;

					//ﾘﾏｰｸ
					UoeCommonFnc.MemCopy(ref remk, (string)dr[EstmtSndRcvJnlSchema.ct_Col_UoeRemark1], remk.Length);
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
                    UoeCommonFnc.MemCopy(ref hsu[_ln], String.Format("{0:D5}", (int)hsuDouble), hsu[_ln].Length);

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
			public byte[] ToByteArray(int cd)
			{
				//継続なし
				if (cd == 1)
				{
					kflg[0] = 0x31;
				}
				//継続あり
				else
				{
					kflg[0] = 0x30;
				}

				MemoryStream ms = new MemoryStream();

				//ＴＴＣ
				ms.Write(jh, 0, jh.Length);			/* ﾍｯﾀﾞ TTC  情報区分         */
				ms.Write(ts, 0, ts.Length);			/*           ﾃｷｽﾄｼｰｹﾝｽ        */
				ms.Write(lg, 0, lg.Length);			/*           ﾃｷｽﾄ長           */

				//業務ヘッダー部
				ms.Write(tr, 0, tr.Length);			/*      ID   ﾄﾗﾝｻﾞｸｼｮﾝｺｰﾄﾞ    */
				ms.Write(res, 0, res.Length);		/*           処理結果         */
				ms.Write(seq, 0, seq.Length);		/*           seq番号          */
				ms.Write(acd, 0, acd.Length);		/*           相手先ｺｰﾄﾞ       */
				ms.Write(tcd, 0, tcd.Length);		/*           当方ｺｰﾄﾞ         */
				ms.Write(dttm, 0, dttm.Length);		/*           日付･時刻        */
				ms.Write(pass, 0, pass.Length);		/*           ﾊﾟｽﾜｰﾄﾞ          */
				ms.Write(kflg, 0, kflg.Length);		/*           継続ﾌﾗｸﾞ         */

				//ヘッダー部
				ms.Write(rem3, 0, rem3.Length);		/*      ﾍｯﾄﾞ ﾘﾏｰｸ3            */
				ms.Write(retok, 0, retok.Length);	/*      	 ﾚｰﾄ区分          */
				ms.Write(reto, 0, reto.Length);		/*           ﾚｰﾄ              */
				ms.Write(senc, 0, senc.Length);		/*           選択ｺｰﾄﾞ         */
				ms.Write(remk, 0, remk.Length);		/*           ﾘﾏｰｸ             */

				//明細部
				for (int i = 0; i < ctBufLen; i++)
				{
					ms.Write(hb[i], 0, hb[i].Length);	//品番
					ms.Write(hsu[i], 0, hsu[i].Length);	//数量
				}
				//dummy
				ms.Write(dummy, 0, dummy.Length);		//dummy

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

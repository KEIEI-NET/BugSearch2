//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : ＵＯＥ送信編集＜在庫＞（トヨタＰＤ４）アクセスクラス
// プログラム概要   : ＵＯＥ送信編集＜在庫＞（トヨタＰＤ４）アクセスを行う
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
	/// ＵＯＥ送信編集＜在庫＞（トヨタＰＤ４）アクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : ＵＯＥ送信編集＜在庫＞（トヨタＰＤ４）アクセスクラス</br>
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

		# region ＵＯＥ送信編集＜在庫＞（トヨタＰＤ４）
		/// <summary>
		/// ＵＯＥ送信編集＜在庫＞（トヨタＰＤ４）
		/// </summary>
		/// <param name="_uoeSndEditRst"></param>
		/// <param name="message"></param>
		/// <returns></returns>
		private int writeUOESNDEditAlloc0102(out List<UoeSndDtl> list, out string message)
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
                _stockView.RowFilter = GetRowFilterQuerry((int)EnumUoeConst.TerminalDiv.ct_Stock, uOESupplier.UOESupplierCd);
				maxCount = _stockView.Count;

				if (maxCount == 0)
				{
					return (status);
				}

				//結果格納処理
				TelegramEditAlloc0102 telegramEditAlloc0102 = new TelegramEditAlloc0102();
                telegramEditAlloc0102.uOESupplier = uOESupplier;
				telegramEditAlloc0102.Seq = 1;

				UoeSndDtl uoeSndDtl = new UoeSndDtl();
				Int32 headerSet = 0;	//ヘッダー部設定フラグ 0:設定する 1:設定しない
				for (int i = 0; i < maxCount; i++)
				{
                    DataRow dr = StockView[i].Row;

					//電文生成領域にデータが存在
					//発注番号が変更された
					if ((headerSet != 0)
					&& (uoeSndDtl.UOESalesOrderNo != (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOESalesOrderNo]))
					{
						uoeSndDtl.SndTelegram = telegramEditAlloc0102.ToByteArray(0);
                        uoeSndDtl.SndTelegramLen = telegramEditAlloc0102.SndTelegramLen;
                        _list.Add(uoeSndDtl);
						headerSet = 0;
						telegramEditAlloc0102.Seq += 1;
					}
					//＜ヘッダー部設定処理＞
					if (headerSet == 0)
					{
						headerSet = 1;

						//電文明細クラスのクリア
						telegramEditAlloc0102.Clear();

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
					telegramEditAlloc0102.Telegram(dr);
				}
				//電文生成領域にデータが存在
				if (headerSet != 0)
				{
					uoeSndDtl.SndTelegram = telegramEditAlloc0102.ToByteArray(1);
                    uoeSndDtl.SndTelegramLen = telegramEditAlloc0102.SndTelegramLen;
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

		# region ＵＯＥ送信電文作成＜在庫＞（トヨタＰＤ４）
		/// <summary>
		/// ＵＯＥ送信電文作成＜在庫＞（トヨタＰＤ４）
		/// </summary>
		public class TelegramEditAlloc0102
		{
			# region ＰＭ７ソース
			//						/*-- 電文領域...ﾗｲﾝ...在確 --*/
			//struct	LN_Z {						/* 12ﾊﾞｲﾄ                     */
			//	char	hb[12];					/* ﾗｲﾝ      品番              */
			//};

			//						/*-- 電文領域...本体...在確 --*/
			//struct	DN_Z {						/* 39 + 240 + 1769 = 2048ﾊﾞｲﾄ   */
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
			//	char	rem3[12];		 		/*           ﾘﾏｰｸ3            */
			//	struct	LN_Z	ln_z[20];		/* ﾗｲﾝ       12 * 20= 240ﾊﾞｲﾄ */
			//	char	dummy[1757];			/* ﾗｲﾝ       dummy            */
			//};
			# endregion

			# region Const Members
			private const Int32 ctBufLen = 20;		//明細バッファサイズ
			private const Int32 ctDetailLen = 6;	//明細行数
            private const Int32 ctSndTelegramLen = 123; //送信電文サイズ
            # endregion

			# region Private Members
			//在庫電文

			private byte[] jh = new byte[1];		/* ﾍｯﾀﾞ TTC  情報区分         */
			private byte[] ts = new byte[2];		/*           ﾃｷｽﾄｼｰｹﾝｽ        */
			private byte[] lg = new byte[2];		/*           ﾃｷｽﾄ長           */

			private byte[] tr = new byte[3];		/*      ID   ﾄﾗﾝｻﾞｸｼｮﾝｺｰﾄﾞ    */
			private byte[] res = new byte[1];		/*           処理結果         */
			private byte[] seq = new byte[3];		/*           seq番号          */
			private byte[] acd = new byte[7];		/*           相手先ｺｰﾄﾞ       */
			private byte[] tcd = new byte[7];		/*           当方ｺｰﾄﾞ         */
			private byte[] dttm = new byte[6];		/*           時刻 		      */
			private byte[] pass = new byte[6];		/*           ﾊﾟｽﾜｰﾄﾞ          */
			private byte[] kflg = new byte[1];		/*           継続ﾌﾗｸﾞ         */

			private byte[] rem3 = new byte[12];		/*      ﾍｯﾄﾞ ﾘﾏｰｸ3            */

			private byte[][] hb = new byte[ctBufLen][];	/* ﾗｲﾝ      品番              */

			private byte[] dummy = new byte[1757];	/* ﾗｲﾝ       dummy            */

			//変数
			private Int32 _seq = 1;
			private Int32 _ln = 0;

            private UOESupplier _uOESupplier = null;
            # endregion

			# region Constructors
			/// <summary>
			/// コンストラクタ
			/// </summary>
			public TelegramEditAlloc0102()
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
				UoeCommonFnc.MemSet(ref jh, 0x20, jh.Length);			//情報区分
				UoeCommonFnc.MemSet(ref ts, 0x20, ts.Length);			//テキストシーケンス
				UoeCommonFnc.MemSet(ref lg, 0x20, lg.Length);			//テキスト長

				//業務ヘッダー部
				UoeCommonFnc.MemSet(ref tr, 0x20, tr.Length);			//トランザクションコード
				UoeCommonFnc.MemSet(ref res, 0x20, res.Length);			//処理結果
				UoeCommonFnc.MemSet(ref seq, 0x20, seq.Length);			//SEQ番号
				UoeCommonFnc.MemSet(ref acd, 0x20, acd.Length);			//相手先コード
				UoeCommonFnc.MemSet(ref tcd, 0x20, tcd.Length);			//当方コード
				UoeCommonFnc.MemSet(ref dttm, 0x20, dttm.Length);		//時刻
				UoeCommonFnc.MemSet(ref pass, 0x20, pass.Length);		//パスワード
				UoeCommonFnc.MemSet(ref kflg, 0x20, kflg.Length);		//継続フラグ

				//ヘッダー部
				UoeCommonFnc.MemSet(ref rem3, 0x20, rem3.Length);		//リマーク３

				//明細部
				for (int i = 0; i < ctBufLen; i++)
				{
					UoeCommonFnc.MemSet(ref hb[i], 0x20, hb[i].Length);	//品番
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
					lg[1] = 0x7b;
					# endregion

					# region ＜業務ヘッダー部＞
					//＜業務ヘッダー部＞
					//トランザクションコード
					UoeCommonFnc.MemCopy(ref tr, "I78", tr.Length);

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
                    rem3[1] = UoeCommonFnc.ToByteFromInt32(DateTime.Now.Hour);	    //時
                    rem3[2] = UoeCommonFnc.ToByteFromInt32(DateTime.Now.Minute);	//分
                    rem3[3] = UoeCommonFnc.ToByteFromInt32(DateTime.Now.Second);	//秒
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
				ms.Write(jh, 0, jh.Length);				//情報区分
				ms.Write(ts, 0, ts.Length);				//テキストシーケンス
				ms.Write(lg, 0, lg.Length);				//テキスト長

				//業務ヘッダー部
				ms.Write(tr, 0, tr.Length);				//トランザクションコード
				ms.Write(res, 0, res.Length);			//処理結果
				ms.Write(seq, 0, seq.Length);			//SEQ番号
				ms.Write(acd, 0, acd.Length);			//相手先コード
				ms.Write(tcd, 0, tcd.Length);			//当方コード
				ms.Write(dttm, 0, dttm.Length);			//時刻
				ms.Write(pass, 0, pass.Length);			//パスワード
				ms.Write(kflg, 0, kflg.Length);			//継続フラグ

				//ヘッダー部
				ms.Write(rem3, 0, rem3.Length);			//リマーク３

				//明細部
				for (int i = 0; i < ctBufLen; i++)
				{
					ms.Write(hb[i], 0, hb[i].Length);	//品番
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

//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : ＵＯＥ送信編集＜発注＞（日産Ｎパーツ）アクセスクラス
// プログラム概要   : ＵＯＥ送信編集＜発注＞（日産Ｎパーツ）アクセスを行う
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
	/// ＵＯＥ送信編集＜発注＞（日産Ｎパーツ）アクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : ＵＯＥ送信編集＜発注＞（日産Ｎパーツ）アクセスクラス</br>
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

		# region ＵＯＥ送信編集＜発注＞（日産Ｎパーツ）
		/// <summary>
		/// ＵＯＥ送信編集＜発注＞（日産Ｎパーツ）
		/// </summary>
		/// <param name="uoeSndDtl"></param>
		/// <param name="message"></param>
		/// <returns></returns>
		private int writeUOESNDEditOrder0202(out List<UoeSndDtl> list, out string message)
		{
			//変数の初期化
			int status = (int)EnumUoeConst.Status.ct_NORMAL;
			int maxCount = 0;
			message = "";
			list = new List<UoeSndDtl>();
			List<UoeSndDtl>  _list = new List<UoeSndDtl>();

			try
			{
				//データテーブル処理
				_orderView = new DataView();
				_orderView.Table = OrderTable;
				_orderView.Sort = GetSortQuerry((int)EnumUoeConst.TerminalDiv.ct_Order);
                _orderView.RowFilter = GetRowFilterQuerry((int)EnumUoeConst.TerminalDiv.ct_Order,uOESupplier.UOESupplierCd);
				maxCount = _orderView.Count;

				if (maxCount == 0)
				{
					return (status);
				}

				//結果格納処理
				TelegramEditOrder0202 telegramEditOrder0202 = new TelegramEditOrder0202();
                telegramEditOrder0202.uOESupplier = uOESupplier;
				telegramEditOrder0202.Seq = 1;

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

				//＜発注電文作成＞
				for (int i = 0; i < maxCount; i++)
				{
					DataRow dr = OrderView[i].Row;

					//電文生成領域にデータが存在
					//発注番号が変更された
					if ((headerSet != 0)
					&& (uoeSndDtl.UOESalesOrderNo != (Int32)dr[OrderSndRcvJnlSchema.ct_Col_UOESalesOrderNo]))
					{
						uoeSndDtl.SndTelegram = telegramEditOrder0202.ToByteArray();
                        uoeSndDtl.SndTelegramLen = telegramEditOrder0202.SndTelegramLen;
						_list.Add(uoeSndDtl);
						headerSet = 0;
						telegramEditOrder0202.Seq += 1;
					}
					//＜ヘッダー部設定処理＞
					if (headerSet == 0)
					{
						headerSet = 1;

						//電文明細クラスのクリア
						telegramEditOrder0202.Clear();

						//ＵＯＥ送信編集結果クラスの初期化
						uoeSndDtl = new UoeSndDtl();

						//発注番号
						uoeSndDtl.UOESalesOrderNo = (Int32)dr[OrderSndRcvJnlSchema.ct_Col_UOESalesOrderNo];

						//行番号
						uoeSndDtl.UOESalesOrderRowNo = new List<int>();
						//送信電文(JIS)
						uoeSndDtl.SndTelegram = null;
					}

					//＜明細部設定処理＞
					//行番号
					uoeSndDtl.UOESalesOrderRowNo.Add((int)dr[OrderSndRcvJnlSchema.ct_Col_UOESalesOrderRowNo]);

					//送信電文(JIS)
					telegramEditOrder0202.Telegram(dr);
				}
				//電文生成領域にデータが存在
				if (headerSet != 0)
				{
					uoeSndDtl.SndTelegram = telegramEditOrder0202.ToByteArray();
                    uoeSndDtl.SndTelegramLen = telegramEditOrder0202.SndTelegramLen;
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
				status = (int)EnumUoeConst.Status.ct_ERROR;
			}

			return status;
		}
		# endregion

		# region ＵＯＥ送信電文作成＜発注＞（日産Ｎパーツ）
		/// <summary>
		/// ＵＯＥ送信電文作成＜発注＞（日産Ｎパーツ）
		/// </summary>
		public class TelegramEditOrder0202
		{
			# region ＰＭ７ソース
			///*-- 電文領域...本体...発注 -------------------------------------------*/
			//										/*-- 電文領域...ﾗｲﾝ...発注 ----*/
			//struct	LN_H {							/* 18ﾊﾞｲﾄ                      */
			//	char	hb[12];						/* ﾗｲﾝ      部品番号           */
			//	char	hasu[5];					/*          数量               */
			//	char	bo;							/*          B/O区分            */
			//};

			//struct	DN_HAC 							/*                             */
			//	{
			//	char	jh;							/* ﾍｯﾀﾞ TTC  情報区分          */
			//	char	ts    [ 2];					/*           ﾃｷｽﾄｼｰｹﾝｽ         */
			//	char	lg    [ 2];					/*           ﾃｷｽﾄ長            */
			//	char	dbkb;						/*           電文区分          */
			//	char	res;						/*           処理結果          */
			//	char	toikb;						/*           問合せ応答区分    */
			//	char	gyoid [12];					/*           業務ID            */
			//	char	pass  [ 6];					/*           ﾊﾟｽﾜｰﾄﾞ           */
			//	char	vers  [ 3];					/*           ﾊﾞｰｼﾞｮﾝ番号       */
			//	char	keikb;						/*           継続区分          */
			//	char	hikid [ 3];					/*           引当ID            */
			//	char	exten [15];					/*           拡張ｴﾘｱ           */
			//	char	syocd [ 2];					/*           処理ｺｰﾄﾞ          */
			//	char	wsuser[ 6];					/*           端末対応ﾕｰｻﾞｰｺｰﾄﾞ */
			//	char	wsseq [ 2];					/*           端末SEQﾞ          */
			//	char	dhms  [ 8];					/*           送信時刻 DDHHMMSS */
			//	char	saikb [ 6];					/*           再送区分          */
			//	char	urikyo[ 3];					/*           売上拠点          */
			//	char	usercd[ 6];					/*      ﾍｯﾄﾞ ﾕｰｻﾞｰｺｰﾄﾞ         */
			//	char	toricd[ 6];					/*           取引先ｺｰﾄﾞ        */
			//	char	nhkb;						/*           納品区分          */
			//	char	irai  [ 2];					/*           依頼者コード      */
			//	char	sitkyo[ 3];					/*           指定拠点          */
			//	char	bin   [ 1];					/*           便                */
			//	char	rem1   [10];				/*           ﾘﾏｰｸ1             */
			//	char	rem2   [10];				/*           ﾘﾏｰｸ2             */
			//	struct	LN_H	ln_h[4];			/* ﾗｲﾝ                         */
			//	char	lstkb;						/* 最終電文区分                */
			//	char	dummy[1861];				/* ﾗｲﾝ       dummy             */
			//};
			# endregion

			# region Const Members
			private const Int32 ctBufLen = 4;		//明細バッファサイズ
			private const Int32 ctDetailLen = 4;	//明細行数
            private const Int32 ctSndTelegramLen = 191; //送信電文サイズ
			# endregion

			# region Private Members
			//発注電文
			private byte[] jh = new byte[1];				/* ﾍｯﾀﾞ TTC  情報区分          */
			private byte[] ts = new byte[2];				/*           ﾃｷｽﾄｼｰｹﾝｽ         */
			private byte[] lg = new byte[2];				/*           ﾃｷｽﾄ長            */
			private byte[] dbkb = new byte[1];				/*           電文区分          */
			private byte[] res = new byte[1];				/*           処理結果          */
			private byte[] toikb = new byte[1];				/*           問合せ応答区分    */
			private byte[] gyoid = new byte[12];			/*           業務ID            */
			private byte[] pass = new byte[6];				/*           ﾊﾟｽﾜｰﾄﾞ           */
			private byte[] vers = new byte[3];				/*           ﾊﾞｰｼﾞｮﾝ番号       */
			private byte[] keikb = new byte[1];				/*           継続区分          */
			private byte[] hikid = new byte[3];				/*           引当ID            */
			private byte[] exten = new byte[15];			/*           拡張ｴﾘｱ           */

			private byte[] syocd = new byte[2];				/*           処理ｺｰﾄﾞ          */
			private byte[] wsuser = new byte[6];			/*           端末対応ﾕｰｻﾞｰｺｰﾄﾞ */
			private byte[] wsseq = new byte[2];				/*           端末SEQﾞ          */
			private byte[] dhms = new byte[8];				/*           送信時刻 DDHHMMSS */
			private byte[] saikb = new byte[6];				/*           再送区分          */
			private byte[] urikyo = new byte[3];			/*           売上拠点          */

			private byte[] usercd = new byte[6];			/*      ﾍｯﾄﾞ ﾕｰｻﾞｰｺｰﾄﾞ         */
			private byte[] toricd = new byte[6];			/*           取引先ｺｰﾄﾞ        */
			private byte[] nhkb = new byte[1];				/*           納品区分          */
			private byte[] irai = new byte[2];				/*           依頼者コード      */
			private byte[] sitkyo = new byte[3];			/*           指定拠点          */
			private byte[] bin = new byte[1];				/*           便                */
			private byte[] rem1 = new byte[10];				/*           ﾘﾏｰｸ1             */
			private byte[] rem2 = new byte[10];				/*           ﾘﾏｰｸ2             */

			private byte[][] hb = new byte[ctBufLen][];		/* ﾗｲﾝ      部品番号           */
			private byte[][] hasu = new byte[ctBufLen][];	/*          数量               */
			private byte[][] bo = new byte[ctBufLen][];		/*          B/O区分            */

			private byte[] lstkb = new byte[1];				/* 最終電文区分                */
			private byte[] dummy = new byte[1861];			/* ﾗｲﾝ       dummy             */

			//変数
			private Int32 _seq = 1;
			private Int32 _ln = 0;

            private UOESupplier _uOESupplier = null;
            # endregion

			# region Constructors
			/// <summary>
			/// コンストラクタ
			/// </summary>
			public TelegramEditOrder0202()
			{
				for (int i = 0; i < ctBufLen; i++)
				{
					hb[i] = new byte[12];	//品番
					hasu[i] = new byte[5];	//数量
					bo[i] = new byte[1];	//ﾌｫﾛｰｺｰﾄﾞ
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
				UoeCommonFnc.MemSet(ref jh, 0x20, jh.Length);			/* ﾍｯﾀﾞ TTC  情報区分          */
				UoeCommonFnc.MemSet(ref ts, 0x20, ts.Length);			/*           ﾃｷｽﾄｼｰｹﾝｽ         */
				UoeCommonFnc.MemSet(ref lg, 0x20, lg.Length);			/*           ﾃｷｽﾄ長            */
				UoeCommonFnc.MemSet(ref dbkb, 0x20, dbkb.Length);		/*           電文区分          */
				UoeCommonFnc.MemSet(ref res, 0x20, res.Length);			/*           処理結果          */
				UoeCommonFnc.MemSet(ref toikb, 0x20, toikb.Length);		/*           問合せ応答区分    */
				UoeCommonFnc.MemSet(ref gyoid, 0x20, gyoid.Length);		/*           業務ID            */
				UoeCommonFnc.MemSet(ref pass, 0x20, pass.Length);		/*           ﾊﾟｽﾜｰﾄﾞ           */
				UoeCommonFnc.MemSet(ref vers, 0x20, vers.Length);		/*           ﾊﾞｰｼﾞｮﾝ番号       */
				UoeCommonFnc.MemSet(ref keikb, 0x20, keikb.Length);		/*           継続区分          */
				UoeCommonFnc.MemSet(ref hikid, 0x20, hikid.Length);		/*           引当ID            */
				UoeCommonFnc.MemSet(ref exten, 0x20, exten.Length);		/*           拡張ｴﾘｱ           */

				//業務ヘッダー部
				UoeCommonFnc.MemSet(ref syocd, 0x20, syocd.Length);		/*           処理ｺｰﾄﾞ          */
				UoeCommonFnc.MemSet(ref wsuser, 0x20, wsuser.Length);	/*           端末対応ﾕｰｻﾞｰｺｰﾄﾞ */
				UoeCommonFnc.MemSet(ref wsseq, 0x20, wsseq.Length);		/*           端末SEQﾞ          */
				UoeCommonFnc.MemSet(ref dhms, 0x20, dhms.Length);		/*           送信時刻 DDHHMMSS */
				UoeCommonFnc.MemSet(ref saikb, 0x20, saikb.Length);		/*           再送区分          */
				UoeCommonFnc.MemSet(ref urikyo, 0x20, urikyo.Length);	/*           売上拠点          */

				//ヘッダー部
				UoeCommonFnc.MemSet(ref usercd, 0x20, usercd.Length);	/*      ﾍｯﾄﾞ ﾕｰｻﾞｰｺｰﾄﾞ         */
				UoeCommonFnc.MemSet(ref toricd, 0x20, toricd.Length);	/*           取引先ｺｰﾄﾞ        */
				UoeCommonFnc.MemSet(ref nhkb, 0x20, nhkb.Length);		/*           納品区分          */
				UoeCommonFnc.MemSet(ref irai, 0x20, irai.Length);		/*           依頼者コード      */
				UoeCommonFnc.MemSet(ref sitkyo, 0x20, sitkyo.Length);	/*           指定拠点          */
				UoeCommonFnc.MemSet(ref bin, 0x20, bin.Length);			/*           便                */
				UoeCommonFnc.MemSet(ref rem1, 0x20, rem1.Length);		/*           ﾘﾏｰｸ1             */
				UoeCommonFnc.MemSet(ref rem2, 0x20, rem2.Length);		/*           ﾘﾏｰｸ2             */

				//明細部
				for (int i = 0; i < ctBufLen; i++)
				{
					UoeCommonFnc.MemSet(ref hb[i], 0x20, hb[i].Length);		/* ﾗｲﾝ      部品番号           */
					UoeCommonFnc.MemSet(ref hasu[i], 0x20, hasu[i].Length);	/*          数量               */
					UoeCommonFnc.MemSet(ref bo[i], 0x20, bo[i].Length);		/*          B/O区分            */
				}
				UoeCommonFnc.MemSet(ref lstkb, 0x20, lstkb.Length);		/* 最終電文区分                */

				//dummy
				UoeCommonFnc.MemSet(ref dummy, 0x20, dummy.Length);		/* ﾗｲﾝ       dummy             */
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
					//ＴＴＣ部
					// ﾍｯﾀﾞ TTC  情報区分
					jh[0] = 0x11;

					// ﾃｷｽﾄｼｰｹﾝｽ
					byte[] bBuf = UoeCommonFnc.ToByteAryFromInt32(_seq);

					ts[0] = bBuf[2];
					ts[1] = bBuf[3];

					// ﾃｷｽﾄ長
					lg[0] = 0x00;
					lg[1] = 0xbf;

					// 電文区分
					dbkb[0] = 0x60;

					// 処理結果
					res[0] = 0x00;

					// 問合せ応答区分
					UoeCommonFnc.MemCopy(ref toikb, "1", toikb.Length);

					// 業務ID
					UoeCommonFnc.MemSet(ref gyoid, 0x20, gyoid.Length);

					// ﾊﾟｽﾜｰﾄﾞ
					UoeCommonFnc.MemSet(ref pass, 0x20, pass.Length);

					// ﾊﾞｰｼﾞｮﾝ番号
					UoeCommonFnc.MemSet(ref vers, 0x20, vers.Length);

					// 継続区分
					UoeCommonFnc.MemCopy(ref keikb, "N", keikb.Length);

					// 引当ID
					UoeCommonFnc.MemSet(ref hikid, 0x20, hikid.Length);

					// 拡張ｴﾘｱ
					UoeCommonFnc.MemSet(ref exten, 0x20, exten.Length);
					# endregion

					# region ＜業務ヘッダー部＞
					//業務ヘッダー部
					// 処理ｺｰﾄﾞ
					UoeCommonFnc.MemCopy(ref syocd, "Z1", syocd.Length);

					// 端末対応ﾕｰｻﾞｰｺｰﾄﾞ
                    UoeCommonFnc.MemCopy(ref wsuser, uOESupplier.UOETerminalCd, wsuser.Length);
					
					// 端末SEQ
					UoeCommonFnc.MemCopy(ref wsseq, "01", wsseq.Length);

					// 送信時刻 DDHHMMSS
					byte[] dhmsByte = UoeCommonFnc.GetByteAryDateTime();
					UoeCommonFnc.MemCopy(ref dhms, ref dhmsByte, dhms.Length);

					// 再送区分
					UoeCommonFnc.MemSet(ref saikb, 0x20, saikb.Length);

					// 売上拠点
					UoeCommonFnc.MemCopy(ref urikyo, uOESupplier.UOESalSectCd, urikyo.Length);
					# endregion

					# region ＜ヘッダー部＞
					// ヘッダー部
					// ﾍｯﾄﾞ ﾕｰｻﾞｰｺｰﾄﾞ
                    UoeCommonFnc.MemCopy(ref usercd, uOESupplier.UOETerminalCd, usercd.Length);

					// 取引先ｺｰﾄﾞ
                    UoeCommonFnc.MemCopy(ref toricd, (string)dr[OrderSndRcvJnlSchema.ct_Col_UOECheckCode], toricd.Length);

					// 納品区分
                    UoeCommonFnc.MemCopy(ref nhkb, (string)dr[OrderSndRcvJnlSchema.ct_Col_UOEDeliGoodsDiv], nhkb.Length);

					// 依頼者コード
                    UoeCommonFnc.MemCopy(ref irai, UoeCommonFnc.GetUnderString((string)dr[OrderSndRcvJnlSchema.ct_Col_EmployeeCode], irai.Length), irai.Length);

					// 指定拠点
					UoeCommonFnc.MemCopy(ref sitkyo, UoeCommonFnc.GetUpperString((string)dr[OrderSndRcvJnlSchema.ct_Col_UOEResvdSection], sitkyo.Length), sitkyo.Length);

					// 便
					UoeCommonFnc.MemSet(ref bin, 0x20, bin.Length);

					// ﾘﾏｰｸ1
					UoeCommonFnc.MemCopy(ref rem1, (string)dr[OrderSndRcvJnlSchema.ct_Col_UoeRemark1], rem1.Length);

					// ﾘﾏｰｸ2
					UoeCommonFnc.MemCopy(ref rem2, (string)dr[OrderSndRcvJnlSchema.ct_Col_UoeRemark2], rem2.Length);

					// 最終電文区分
					UoeCommonFnc.MemSet(ref lstkb, 0x20, lstkb.Length);
					# endregion
				}

				# region ＜明細部＞
				//＜明細部＞
				if (_ln < ctDetailLen)
				{
					//品番
					UoeCommonFnc.MemCopy(ref hb[_ln], (string)dr[OrderSndRcvJnlSchema.ct_Col_GoodsNoNoneHyphen], hb[_ln].Length);

					//数量
					double hsuDouble = (double)dr[OrderSndRcvJnlSchema.ct_Col_AcceptAnOrderCnt];
                    UoeCommonFnc.MemCopy(ref hasu[_ln], String.Format("{0:D5}", (int)hsuDouble), hasu[_ln].Length);

					//フォローコード
					UoeCommonFnc.MemCopy(ref bo[_ln], (string)dr[OrderSndRcvJnlSchema.ct_Col_BoCode], bo[_ln].Length);

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
				ms.Write(jh, 0, jh.Length);			/* ﾍｯﾀﾞ TTC  情報区分          */
				ms.Write(ts, 0, ts.Length);			/*           ﾃｷｽﾄｼｰｹﾝｽ         */
				ms.Write(lg, 0, lg.Length);			/*           ﾃｷｽﾄ長            */
				ms.Write(dbkb, 0, dbkb.Length);		/*           電文区分          */
				ms.Write(res, 0, res.Length);		/*           処理結果          */
				ms.Write(toikb, 0, toikb.Length);	/*           問合せ応答区分    */
				ms.Write(gyoid, 0, gyoid.Length);	/*           業務ID            */
				ms.Write(pass, 0, pass.Length);		/*           ﾊﾟｽﾜｰﾄﾞ           */
				ms.Write(vers, 0, vers.Length);		/*           ﾊﾞｰｼﾞｮﾝ番号       */
				ms.Write(keikb, 0, keikb.Length);	/*           継続区分          */
				ms.Write(hikid, 0, hikid.Length);	/*           引当ID            */
				ms.Write(exten, 0, exten.Length);	/*           拡張ｴﾘｱ           */

				//業務ヘッダー部
				ms.Write(syocd, 0, syocd.Length);	/*           処理ｺｰﾄﾞ          */
				ms.Write(wsuser, 0, wsuser.Length);	/*           端末対応ﾕｰｻﾞｰｺｰﾄﾞ */
				ms.Write(wsseq, 0, wsseq.Length);	/*           端末SEQﾞ          */
				ms.Write(dhms, 0, dhms.Length);		/*           送信時刻 DDHHMMSS */
				ms.Write(saikb, 0, saikb.Length);	/*           再送区分          */
				ms.Write(urikyo, 0, urikyo.Length);	/*           売上拠点          */

				//ヘッダー部
				ms.Write(usercd, 0, usercd.Length);	/*      ﾍｯﾄﾞ ﾕｰｻﾞｰｺｰﾄﾞ         */
				ms.Write(toricd, 0, toricd.Length);	/*           取引先ｺｰﾄﾞ        */
				ms.Write(nhkb, 0, nhkb.Length);		/*           納品区分          */
				ms.Write(irai, 0, irai.Length);		/*           依頼者コード      */
				ms.Write(sitkyo, 0, sitkyo.Length);	/*           指定拠点          */
				ms.Write(bin, 0, bin.Length);		/*           便                */
				ms.Write(rem1, 0, rem1.Length);		/*           ﾘﾏｰｸ1             */
				ms.Write(rem2, 0, rem2.Length);		/*           ﾘﾏｰｸ2             */

				//明細部
				for (int i = 0; i < ctBufLen; i++)
				{
					ms.Write(hb[i], 0, hb[i].Length);		/* ﾗｲﾝ      部品番号           */
					ms.Write(hasu[i], 0, hasu[i].Length);	/*          数量               */
					ms.Write(bo[i], 0, bo[i].Length);		/*          B/O区分            */
				}
				ms.Write(lstkb, 0, lstkb.Length);	/* 最終電文区分                */

				//dummy
				ms.Write(dummy, 0, dummy.Length);	/* ﾗｲﾝ       dummy             */

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

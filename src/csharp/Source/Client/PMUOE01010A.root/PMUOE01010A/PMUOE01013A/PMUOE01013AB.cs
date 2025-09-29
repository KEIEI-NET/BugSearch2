//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : ＵＯＥ送信編集＜発注＞（ミツビシ）アクセスクラス
// プログラム概要   : ＵＯＥ送信編集＜発注＞（ミツビシ）アクセスを行う
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
	/// ＵＯＥ送信編集＜発注＞（ミツビシ）アクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : ＵＯＥ送信編集＜発注＞（ミツビシ）アクセスクラス</br>
	/// <br>Programmer : 96186 立花裕輔</br>
	/// <br>Date       : 2008.05.26</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// <br>2008.05.26 men 新規作成</br>
	/// </remarks>
	public partial class UoeSndEdit0301Acs
	{
		// ===================================================================================== //
		// プライベートメソッド
		// ===================================================================================== //
		# region Private Methods

		# region ＵＯＥ送信編集＜発注＞（ミツビシ）
		/// <summary>
		/// ＵＯＥ送信編集＜発注＞（ミツビシ）
		/// </summary>
		/// <param name="uoeSndDtl"></param>
		/// <param name="message"></param>
		/// <returns></returns>
		private int writeUOESNDEditOrder0301(out List<UoeSndDtl> list, out string message)
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
				TelegramEditOrder0301 telegramEditOrder0301 = new TelegramEditOrder0301();
                telegramEditOrder0301.uOESupplier = uOESupplier;	
				telegramEditOrder0301.Seq = 1;

				UoeSndDtl uoeSndDtl = new UoeSndDtl();
				Int32 headerSet = 0;	//ヘッダー部設定フラグ 0:設定する 1:設定しない

				//＜開局電文作成＞
				TelegramEditOpenClose0301 telegramEditOpenClose0301 = new TelegramEditOpenClose0301();
                telegramEditOpenClose0301.uOESupplier = uOESupplier;

				//ＵＯＥ送信編集結果クラスの初期化
				uoeSndDtl = new UoeSndDtl();
				uoeSndDtl.UOESalesOrderRowNo = new List<int>();

				//送信電文(JIS)
				uoeSndDtl.SndTelegram = telegramEditOpenClose0301.Telegram((int)EnumUoeConst.OpenMode.ct_OPEN);
                uoeSndDtl.SndTelegramLen = telegramEditOpenClose0301.SndTelegramLen;

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
						uoeSndDtl.SndTelegram = telegramEditOrder0301.ToByteArray();
                        uoeSndDtl.SndTelegramLen = telegramEditOrder0301.SndTelegramLen;
                        _list.Add(uoeSndDtl);
						headerSet = 0;
						telegramEditOrder0301.Seq += 1;
					}
					//＜ヘッダー部設定処理＞
					if (headerSet == 0)
					{
						headerSet = 1;

						//電文明細クラスのクリア
						telegramEditOrder0301.Clear();

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
					telegramEditOrder0301.Telegram(dr);
				}
				//電文生成領域にデータが存在
				if (headerSet != 0)
				{
					uoeSndDtl.SndTelegram = telegramEditOrder0301.ToByteArray();
                    uoeSndDtl.SndTelegramLen = telegramEditOrder0301.SndTelegramLen;
                    _list.Add(uoeSndDtl);
					headerSet = 0;
				}

				//＜閉局電文作成＞
				//ＵＯＥ送信編集結果クラスの初期化
				uoeSndDtl = new UoeSndDtl();
				uoeSndDtl.UOESalesOrderRowNo = new List<int>();

				//送信電文(JIS)
				uoeSndDtl.SndTelegram = telegramEditOpenClose0301.Telegram((int)EnumUoeConst.OpenMode.ct_CLOSE);
                uoeSndDtl.SndTelegramLen = telegramEditOpenClose0301.SndTelegramLen;

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

		# region ＵＯＥ送信電文作成＜発注＞（ミツビシ）
		/// <summary>
		/// ＵＯＥ送信電文作成＜発注＞（ミツビシ）
		/// </summary>
		public class TelegramEditOrder0301
		{
			# region ＰＭ７ソース
			///*-- 電文領域...本体...発注 -------------------------------------------*/
			//									//-- 電文領域...ﾗｲﾝ...発注 --
			//struct	LN_H {					// 18ﾊﾞｲﾄ                     
			//	char	hb[10];					// ﾗｲﾝ      部品番号          
			//	char	hasu[4];				//          数量              
			//	char	bo;						//          B/O区分           
			//	char	exten[3];				//          拡張ｴﾘｱ           
			//};

												//-- 電文領域...本体...発注 --
			//struct	DN_H {						// 97 + 54 +1897 = 2048       
			//	char	jh;						// ﾍｯﾀﾞ TTC  情報区分         
			//	char	ts[2];					//           ﾃｷｽﾄｼｰｹﾝｽ        
			//	char	lg[2];					//           ﾃｷｽﾄ長           
			//	char	dbkb;					//           電文区分         
			//	char	res;					//           処理結果         
			//	char	toikb;					//           問合せ応答区分   
			//	char	gyoid[12];				//           業務ID           
			//	char	pass[6];				//           ﾊﾟｽﾜｰﾄﾞ          
			//	char	vers[3];				//           ﾊﾞｰｼﾞｮﾝ番号      
			//	char	keikb;					//           継続区分         
			//	char	hikid[3];				//           取引ID           
			//	char	exten[15];				//           拡張ｴﾘｱ          
			//
			//	char	errcd;					//     ﾍｯﾄﾞ1 エラーコード     
			//	char	keiflg;					//           継続フラグ       
			//	char	seqno[3];				//           ｼｰｹﾝｽNO          
			//	char	inpymd[4];				//           入力日付時間     
			//	char	ukeymd[8];				//           受付日付時間     
			//	char	nhkb;					//     ﾍｯﾄﾞ2 納品区分		  
			//	char	rem[8];					//           ﾘﾏｰｸ             
			//	char	sitkyo[2];				//           指定拠点         
			//	char	kinkb;					//           緊急区分         
			//	char	hdexten[20];			//           拡張ｴﾘｱ          
			//	struct	LN_H	ln_h[3];		// ﾗｲﾝ       18*3=54ﾊﾞｲﾄ      
			//	char	dummy[1897];			// ﾗｲﾝ       dummy            
			//};
			# endregion

			# region Const Members
			private const Int32 ctBufLen = 3;		//明細バッファサイズ
			private const Int32 ctDetailLen = 3;	//明細行数
            private const Int32 ctSndTelegramLen = 151; //送信電文サイズ
			# endregion

			# region 電文領域クラス
			/// <summary>
			/// 発注電文領域＜ライン＞
			/// </summary>
			private class LN_H
			{									// 18ﾊﾞｲﾄ                     
				public byte[] hb = new byte[10];	// ﾗｲﾝ      部品番号
				public byte[] hasu = new byte[4];	//          数量
				public byte[] bo = new byte[1];		//          B/O区分
				public byte[] exten = new byte[3];	//          拡張ｴﾘｱ

				public LN_H()
				{
					Clear();
				}
				public void Clear()
				{
					UoeCommonFnc.MemSet(ref hb, 0x20, hb.Length);		// ﾗｲﾝ      部品番号           
					UoeCommonFnc.MemSet(ref hasu, 0x20, hasu.Length);	//          数量               
					UoeCommonFnc.MemSet(ref bo, 0x20, bo.Length);		//          B/O区分            
					UoeCommonFnc.MemSet(ref exten, 0x20, exten.Length);	//          拡張ｴﾘｱ
				}
			}

			/// <summary>
			/// 発注電文領域＜本体＞
			/// </summary>
			private class DN_H
			{
				public byte[] jh = new byte[1];			// ﾍｯﾀﾞ TTC  情報区分          
				public byte[] ts = new byte[2];			//           ﾃｷｽﾄｼｰｹﾝｽ         
				public byte[] lg = new byte[2];			//           ﾃｷｽﾄ長            
				public byte[] dbkb = new byte[1];		//           電文区分          
				public byte[] res = new byte[1];		//           処理結果          
				public byte[] toikb = new byte[1];		//           問合せ応答区分    
				public byte[] gyoid = new byte[12];		//           業務ID            
				public byte[] pass = new byte[6];		//           ﾊﾟｽﾜｰﾄﾞ           
				public byte[] vers = new byte[3];		//           ﾊﾞｰｼﾞｮﾝ番号       
				public byte[] keikb = new byte[1];		//           継続区分          
				public byte[] hikid = new byte[3];		//           引当ID            
				public byte[] exten = new byte[15];		//           拡張ｴﾘｱ           

				public byte[] errcd = new byte[1];		//     ﾍｯﾄﾞ1 エラーコード     
				public byte[] keiflg = new byte[1];		//           継続フラグ       
				public byte[] seqno = new byte[3];		//           ｼｰｹﾝｽNO          
				public byte[] inpymd = new byte[4];		//           入力日付時間     
				public byte[] ukeymd = new byte[8];		//           受付日付時間     
				public byte[] nhkb = new byte[1];		//     ﾍｯﾄﾞ2 納品区分		  
				public byte[] rem = new byte[8];		//           ﾘﾏｰｸ             
				public byte[] sitkyo = new byte[2];		//           指定拠点         
				public byte[] kinkb = new byte[1];		//           緊急区分         
				public byte[] hdexten = new byte[20];	//           拡張ｴﾘｱ          
				public LN_H[] ln_h = new LN_H[ctBufLen];// ﾗｲﾝ       14*10=140ﾊﾞｲﾄ
				public byte[] dummy = new byte[1897];	// ﾗｲﾝ       dummy             

				/// <summary>
				/// コンストラクター
				/// </summary>
				public DN_H()
				{
					Clear();
				}

				/// <summary>
				/// 初期化
				/// </summary>
				public void Clear()
				{
					//ＴＴＣ
					UoeCommonFnc.MemSet(ref jh, 0x20, jh.Length);			// ﾍｯﾀﾞ TTC  情報区分          
					UoeCommonFnc.MemSet(ref ts, 0x20, ts.Length);			//           ﾃｷｽﾄｼｰｹﾝｽ         
					UoeCommonFnc.MemSet(ref lg, 0x20, lg.Length);			//           ﾃｷｽﾄ長            
					UoeCommonFnc.MemSet(ref dbkb, 0x20, dbkb.Length);		//           電文区分          
					UoeCommonFnc.MemSet(ref res, 0x20, res.Length);			//           処理結果          
					UoeCommonFnc.MemSet(ref toikb, 0x20, toikb.Length);		//           問合せ応答区分    
					UoeCommonFnc.MemSet(ref gyoid, 0x20, gyoid.Length);		//           業務ID            
					UoeCommonFnc.MemSet(ref pass, 0x20, pass.Length);		//           ﾊﾟｽﾜｰﾄﾞ           
					UoeCommonFnc.MemSet(ref vers, 0x20, vers.Length);		//           ﾊﾞｰｼﾞｮﾝ番号       
					UoeCommonFnc.MemSet(ref keikb, 0x20, keikb.Length);		//           継続区分          
					UoeCommonFnc.MemSet(ref hikid, 0x20, hikid.Length);		//           引当ID            
					UoeCommonFnc.MemSet(ref exten, 0x20, exten.Length);		//           拡張ｴﾘｱ           

					//ヘッダー部
					UoeCommonFnc.MemSet(ref errcd, 0x20, errcd.Length);		//     ﾍｯﾄﾞ1 エラーコード     
					UoeCommonFnc.MemSet(ref keiflg, 0x20, keiflg.Length);	//           継続フラグ       
					UoeCommonFnc.MemSet(ref seqno, 0x20, seqno.Length);		//           ｼｰｹﾝｽNO          
					UoeCommonFnc.MemSet(ref inpymd, 0x20, inpymd.Length);	//           入力日付時間     
					UoeCommonFnc.MemSet(ref ukeymd, 0x20, ukeymd.Length);	//           受付日付時間     
					UoeCommonFnc.MemSet(ref nhkb, 0x20, nhkb.Length);		//     ﾍｯﾄﾞ2 納品区分		  
					UoeCommonFnc.MemSet(ref rem, 0x20, rem.Length);			//           ﾘﾏｰｸ             
					UoeCommonFnc.MemSet(ref sitkyo, 0x20, sitkyo.Length);	//           指定拠点         
					UoeCommonFnc.MemSet(ref kinkb, 0x20, kinkb.Length);		//           緊急区分         
					UoeCommonFnc.MemSet(ref hdexten, 0x20, hdexten.Length);	//           拡張ｴﾘｱ          

					//明細部
					for (int i = 0; i < ctBufLen; i++)
					{
                        if (ln_h[i] == null)
                        {
                            ln_h[i] = new LN_H();
                        }
                        else
                        {
                            ln_h[i].Clear();
                        }
                    }
					UoeCommonFnc.MemSet(ref dummy, 0x20, dummy.Length);
				}
			}
			# endregion

			# region Private Members
			//変数
			private Int32 _seq = 1;
			private Int32 _ln = 0;

			private DN_H dn_h = new DN_H();

            private UOESupplier _uOESupplier = null;
            # endregion

			# region Constructors
			/// <summary>
			/// コンストラクタ
			/// </summary>
			public TelegramEditOrder0301()
			{
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
				dn_h.Clear();
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
					dn_h.jh[0] = 0x11;

					//ﾃｷｽﾄｼｰｹﾝｽ
					byte[] bBuf = UoeCommonFnc.ToByteAryFromInt32(_seq);

					dn_h.ts[0] = bBuf[2];
					dn_h.ts[1] = bBuf[3];

					//ﾃｷｽﾄ長
					dn_h.lg[0] = 0x00;
					dn_h.lg[1] = 0x97;

					//電文区分
					dn_h.dbkb[0] = 0x60;

					//処理結果
					dn_h.res[0] = 0x00;

					//問合せ応答区分
					UoeCommonFnc.MemCopy(ref dn_h.toikb, "1", dn_h.toikb.Length);

					//業務ID
					UoeCommonFnc.MemSet(ref dn_h.gyoid, 0x20, dn_h.gyoid.Length);
					UoeCommonFnc.MemCopy(ref dn_h.gyoid, "UOE1", 4);

					//ﾊﾟｽﾜｰﾄﾞ
					UoeCommonFnc.MemSet(ref dn_h.pass, 0x20, dn_h.pass.Length);

					//ﾊﾞｰｼﾞｮﾝ番号
					UoeCommonFnc.MemSet(ref dn_h.vers, 0x20, dn_h.vers.Length);

					//継続区分
					UoeCommonFnc.MemCopy(ref dn_h.keikb, "N", 1);

					//引当ID
					UoeCommonFnc.MemSet(ref dn_h.hikid, 0x20, dn_h.hikid.Length);

					//拡張ｴﾘｱ
					UoeCommonFnc.MemSet(ref dn_h.exten, 0x00, dn_h.exten.Length);
					# endregion

					# region ＜ヘッダー部＞
					//ヘッダー部

					
					//ｴﾗｰｺｰﾄﾞ
					dn_h.errcd[0] = 0x00;

					//継続ﾌﾗｸﾞ
					UoeCommonFnc.MemCopy(ref dn_h.keiflg, "1", 1);

					//ｼｰｹﾝｽNO
                    UoeCommonFnc.MemCopy(ref dn_h.seqno, String.Format("{0:D3}", _seq), 3);

					//入力日付
					dn_h.inpymd[0] = UoeCommonFnc.ToByteFromInt32(DateTime.Now.Day);	//日
                    dn_h.inpymd[1] = UoeCommonFnc.ToByteFromInt32(DateTime.Now.Hour);	//時
                    dn_h.inpymd[2] = UoeCommonFnc.ToByteFromInt32(DateTime.Now.Minute);//分
                    dn_h.inpymd[3] = UoeCommonFnc.ToByteFromInt32(DateTime.Now.Second);//秒

					//受付日付
					UoeCommonFnc.MemSet(ref dn_h.ukeymd, 0x20, dn_h.ukeymd.Length);

					//納品区分
                    UoeCommonFnc.MemCopy(ref dn_h.nhkb, (string)dr[OrderSndRcvJnlSchema.ct_Col_UOEDeliGoodsDiv], dn_h.nhkb.Length);

					//ﾘﾏｰｸ1
					UoeCommonFnc.MemCopy(ref dn_h.rem, (string)dr[OrderSndRcvJnlSchema.ct_Col_UoeRemark1], dn_h.rem.Length);

					//指定拠点
					UoeCommonFnc.MemCopy(ref dn_h.sitkyo, (string)dr[OrderSndRcvJnlSchema.ct_Col_UOEResvdSection], 1, dn_h.sitkyo.Length);

					//緊急区分
					UoeCommonFnc.MemCopy(ref dn_h.kinkb, uOESupplier.EmergencyDiv, dn_h.kinkb.Length);

					//拡張ｴﾘｱ
					UoeCommonFnc.MemSet(ref dn_h.hdexten, 0x20, dn_h.hdexten.Length);
					# endregion
				}

				# region ＜明細部＞
				//＜明細部＞
				if (_ln < ctDetailLen)
				{
					//品番
					UoeCommonFnc.MemCopy(ref dn_h.ln_h[_ln].hb, (string)dr[OrderSndRcvJnlSchema.ct_Col_GoodsNoNoneHyphen], dn_h.ln_h[_ln].hb.Length);

					//数量
					double hsuDouble = (double)dr[OrderSndRcvJnlSchema.ct_Col_AcceptAnOrderCnt];
                    UoeCommonFnc.MemCopy(ref dn_h.ln_h[_ln].hasu, String.Format("{0:D4}", (int)hsuDouble), dn_h.ln_h[_ln].hasu.Length);

					//B/O区分
					UoeCommonFnc.MemCopy(ref dn_h.ln_h[_ln].bo, (string)dr[OrderSndRcvJnlSchema.ct_Col_BoCode], dn_h.ln_h[_ln].bo.Length);

					//拡張ｴﾘｱ
					UoeCommonFnc.MemSet(ref dn_h.ln_h[_ln].exten, 0x20, dn_h.ln_h[_ln].exten.Length);

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
				ms.Write(dn_h.jh, 0, dn_h.jh.Length);			// ﾍｯﾀﾞ TTC  情報区分          
				ms.Write(dn_h.ts, 0, dn_h.ts.Length);			//           ﾃｷｽﾄｼｰｹﾝｽ         
				ms.Write(dn_h.lg, 0, dn_h.lg.Length);			//           ﾃｷｽﾄ長            
				ms.Write(dn_h.dbkb, 0, dn_h.dbkb.Length);		//           電文区分          
				ms.Write(dn_h.res, 0, dn_h.res.Length);		//           処理結果          
				ms.Write(dn_h.toikb, 0, dn_h.toikb.Length);	//           問合せ応答区分    
				ms.Write(dn_h.gyoid, 0, dn_h.gyoid.Length);	//           業務ID            
				ms.Write(dn_h.pass, 0, dn_h.pass.Length);		//           ﾊﾟｽﾜｰﾄﾞ           
				ms.Write(dn_h.vers, 0, dn_h.vers.Length);		//           ﾊﾞｰｼﾞｮﾝ番号       
				ms.Write(dn_h.keikb, 0, dn_h.keikb.Length);	//           継続区分          
				ms.Write(dn_h.hikid, 0, dn_h.hikid.Length);	//           引当ID            
				ms.Write(dn_h.exten, 0, dn_h.exten.Length);	//           拡張ｴﾘｱ           

				//ヘッダー部
				ms.Write(dn_h.errcd, 0, dn_h.errcd.Length);	//     ﾍｯﾄﾞ1 エラーコード     
				ms.Write(dn_h.keiflg, 0, dn_h.keiflg.Length);	//           継続フラグ       
				ms.Write(dn_h.seqno, 0, dn_h.seqno.Length);	//           ｼｰｹﾝｽNO          
				ms.Write(dn_h.inpymd, 0, dn_h.inpymd.Length);	//           入力日付時間     
				ms.Write(dn_h.ukeymd, 0, dn_h.ukeymd.Length);	//           受付日付時間     
				ms.Write(dn_h.nhkb, 0, dn_h.nhkb.Length);		//     ﾍｯﾄﾞ2 納品区分		  
				ms.Write(dn_h.rem, 0, dn_h.rem.Length);		//           ﾘﾏｰｸ             
				ms.Write(dn_h.sitkyo, 0, dn_h.sitkyo.Length);	//           指定拠点         
				ms.Write(dn_h.kinkb, 0, dn_h.kinkb.Length);	//           緊急区分         
				ms.Write(dn_h.hdexten, 0, dn_h.hdexten.Length);//           拡張ｴﾘｱ          

				//明細部
				for (int i = 0; i < ctBufLen; i++)
				{
					ms.Write(dn_h.ln_h[i].hb, 0, dn_h.ln_h[i].hb.Length);		// ﾗｲﾝ      部品番号           */
					ms.Write(dn_h.ln_h[i].hasu, 0, dn_h.ln_h[i].hasu.Length);	//          数量               */
					ms.Write(dn_h.ln_h[i].bo, 0, dn_h.ln_h[i].bo.Length);		//          B/O区分            */
					ms.Write(dn_h.ln_h[i].exten, 0, dn_h.ln_h[i].exten.Length);//          拡張ｴﾘｱ
				}

				//dummy
				ms.Write(dn_h.dummy, 0, dn_h.dummy.Length);	/* ﾗｲﾝ       dummy             */

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

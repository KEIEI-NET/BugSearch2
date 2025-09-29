//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : ＵＯＥ送信編集＜在庫＞（新マツダ）アクセスクラス
// プログラム概要   : ＵＯＥ送信編集＜在庫＞（新マツダ）アクセスを行う
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
	/// ＵＯＥ送信編集＜在庫＞（新マツダ）アクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : ＵＯＥ送信編集＜在庫＞（新マツダ）アクセスクラス</br>
	/// <br>Programmer : 96186 立花裕輔</br>
	/// <br>Date       : 2008.05.26</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// <br>2008.05.26 men 新規作成</br>
	/// </remarks>
	public partial class UoeSndEdit0402Acs
	{
		// ===================================================================================== //
		// プライベートメソッド
		// ===================================================================================== //
		# region Private Methods

		# region ＵＯＥ送信編集＜在庫＞（新マツダ）
		/// <summary>
		/// ＵＯＥ送信編集＜在庫＞（新マツダ）
		/// </summary>
		/// <param name="_uoeSndEditRst"></param>
		/// <param name="message"></param>
		/// <returns></returns>
		private int writeUOESNDEditAlloc0402(out List<UoeSndDtl> list, out string message)
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
				TelegramEditAlloc0402 telegramEditAlloc0402 = new TelegramEditAlloc0402();
                telegramEditAlloc0402.uOESupplier = uOESupplier;
				telegramEditAlloc0402.Seq = 1;

				UoeSndDtl uoeSndDtl = new UoeSndDtl();
				Int32 headerSet = 0;	//ヘッダー部設定フラグ 0:設定する 1:設定しない

				//＜開局電文作成＞
				TelegramEditOpenClose0402 telegramEditOpenClose0402 = new TelegramEditOpenClose0402();
                telegramEditOpenClose0402.uOESupplier = uOESupplier;

				//ＵＯＥ送信編集結果クラスの初期化
				uoeSndDtl = new UoeSndDtl();
				uoeSndDtl.UOESalesOrderRowNo = new List<int>();

				//送信電文(JIS)
				uoeSndDtl.SndTelegram = telegramEditOpenClose0402.Telegram((int)EnumUoeConst.OpenMode.ct_OPEN);
                uoeSndDtl.SndTelegramLen = telegramEditOpenClose0402.SndTelegramLen;

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
						uoeSndDtl.SndTelegram = telegramEditAlloc0402.ToByteArray();
                        uoeSndDtl.SndTelegramLen = telegramEditAlloc0402.SndTelegramLen;
                        _list.Add(uoeSndDtl);
						headerSet = 0;
						telegramEditAlloc0402.Seq += 1;
					}
					//＜ヘッダー部設定処理＞
					if (headerSet == 0)
					{
						headerSet = 1;

						//電文明細クラスのクリア
						telegramEditAlloc0402.Clear();

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
					telegramEditAlloc0402.Telegram(dr);
				}
				//電文生成領域にデータが存在
				if (headerSet != 0)
				{
					uoeSndDtl.SndTelegram = telegramEditAlloc0402.ToByteArray();
                    uoeSndDtl.SndTelegramLen = telegramEditAlloc0402.SndTelegramLen;
                    _list.Add(uoeSndDtl);
					headerSet = 0;
				}

				//＜閉局電文作成＞
				//ＵＯＥ送信編集結果クラスの初期化
				uoeSndDtl = new UoeSndDtl();
				uoeSndDtl.UOESalesOrderRowNo = new List<int>();

				//送信電文(JIS)
				uoeSndDtl.SndTelegram = telegramEditOpenClose0402.Telegram((int)EnumUoeConst.OpenMode.ct_CLOSE);
                uoeSndDtl.SndTelegramLen = telegramEditOpenClose0402.SndTelegramLen;

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

		# region ＵＯＥ送信電文作成＜在庫＞（新マツダ）
		/// <summary>
		/// ＵＯＥ送信電文作成＜在庫＞（新マツダ）
		/// </summary>
		public class TelegramEditAlloc0402
		{
			# region ＰＭ７ソース
			//									//-- 電文領域...ﾗｲﾝ...在確 ---
			//struct	LN_Z {					// 24ﾊﾞｲﾄ                     
			//	char	hb[24];					// ﾗｲﾝ      部品番号          
			//};
			//									//-- 電文領域...本体...在確 --
			//struct	DN_Z {					// 65 + 120+1863 = 2048ﾊﾞｲﾄ   
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
			//	char	kekka;					//     ﾍｯﾄﾞ1 業務処理結果     
			//	char	keiflg;					//           継続フラグ       
			//	char	seqno[3];				//           ｼｰｹﾝｽNO          
			//	char	inpymd[4];				//           入力日付時間     
			//	char	ukeymd[8];				//           受付日付時間     
			//	struct	LN_Z	ln_z[5];		// ﾗｲﾝ       24*5=120ﾊﾞｲﾄ     
			//	char	dummy[1863];			// ﾗｲﾝ       dummy            
			//};
			# endregion

			# region 電文領域クラス
			/// <summary>
			/// 在庫電文領域＜ライン＞
			/// </summary>
			private class LN_Z
			{
				public byte[] hb = new byte[24];				// ﾗｲﾝ      部品番号          

				public LN_Z()
				{
					Clear();
				}
				public void Clear()
				{
					UoeCommonFnc.MemSet(ref hb, 0x20, hb.Length);				// ﾗｲﾝ      部品番号          
				}
			}

			/// <summary>
			/// 在庫電文領域＜本体＞
			/// </summary>
			private class DN_Z
			{
				public byte[] jh = new byte[1];					// ﾍｯﾀﾞ TTC  情報区分         
				public byte[] ts = new byte[2];					//           ﾃｷｽﾄｼｰｹﾝｽ        
				public byte[] lg = new byte[2];					//           ﾃｷｽﾄ長           
				public byte[] dbkb = new byte[1];				//           電文区分         
				public byte[] res = new byte[1];				//           処理結果         
				public byte[] toikb = new byte[1];				//           問合せ応答区分   
				public byte[] gyoid = new byte[12];				//           業務ID           
				public byte[] pass = new byte[6];				//           ﾊﾟｽﾜｰﾄﾞ          
				public byte[] vers = new byte[3];				//           ﾊﾞｰｼﾞｮﾝ番号      
				public byte[] keikb = new byte[1];				//           継続区分         
				public byte[] hikid = new byte[3];				//           取引ID           
				public byte[] exten = new byte[15];				//           拡張ｴﾘｱ          
				public byte[] kekka = new byte[1];				//     ﾍｯﾄﾞ1 業務処理結果     
				public byte[] keiflg = new byte[1];				//           継続フラグ       
				public byte[] seqno = new byte[3];				//           ｼｰｹﾝｽNO          
				public byte[] inpymd = new byte[4];				//           入力日付時間     
				public byte[] ukeymd = new byte[8];				//           受付日付時間     
				public LN_Z[] ln_z = new LN_Z[ctBufLen];		// ﾗｲﾝ       24*5=120ﾊﾞｲﾄ     
				public byte[] dummy = new byte[1863];			// ﾗｲﾝ       dummy            
	
				/// <summary>
				/// コンストラクター
				/// </summary>
				public DN_Z()
				{
					Clear();
				}

				/// <summary>
				/// 初期化
				/// </summary>
				public void Clear()
				{
					UoeCommonFnc.MemSet(ref jh, 0x20, jh.Length);				// ﾍｯﾀﾞ TTC  情報区分         
					UoeCommonFnc.MemSet(ref ts, 0x20, ts.Length);				//           ﾃｷｽﾄｼｰｹﾝｽ        
					UoeCommonFnc.MemSet(ref lg, 0x20, lg.Length);				//           ﾃｷｽﾄ長           
					UoeCommonFnc.MemSet(ref dbkb, 0x20, dbkb.Length);			//           電文区分         
					UoeCommonFnc.MemSet(ref res, 0x20, res.Length);				//           処理結果         
					UoeCommonFnc.MemSet(ref toikb, 0x20, toikb.Length);			//           問合せ応答区分   
					UoeCommonFnc.MemSet(ref gyoid, 0x20, gyoid.Length);			//           業務ID           
					UoeCommonFnc.MemSet(ref pass, 0x20, pass.Length);			//           ﾊﾟｽﾜｰﾄﾞ          
					UoeCommonFnc.MemSet(ref vers, 0x20, vers.Length);			//           ﾊﾞｰｼﾞｮﾝ番号      
					UoeCommonFnc.MemSet(ref keikb, 0x20, keikb.Length);			//           継続区分         
					UoeCommonFnc.MemSet(ref hikid, 0x20, hikid.Length);			//           取引ID           
					UoeCommonFnc.MemSet(ref exten, 0x20, exten.Length);			//           拡張ｴﾘｱ          
					UoeCommonFnc.MemSet(ref kekka, 0x20, kekka.Length);			//     ﾍｯﾄﾞ1 業務処理結果     
					UoeCommonFnc.MemSet(ref keiflg, 0x20, keiflg.Length);		//           継続フラグ       
					UoeCommonFnc.MemSet(ref seqno, 0x20, seqno.Length);			//           ｼｰｹﾝｽNO          
					UoeCommonFnc.MemSet(ref inpymd, 0x20, inpymd.Length);		//           入力日付時間     
					UoeCommonFnc.MemSet(ref ukeymd, 0x20, ukeymd.Length);		//           受付日付時間     

					//明細部
					for (int i = 0; i < ctBufLen; i++)
					{
                        if (ln_z[i] == null)
                        {
                            ln_z[i] = new LN_Z();
                        }
                        else
                        {
                            ln_z[i].Clear();
                        }
                    }
					//dummy
					UoeCommonFnc.MemSet(ref dummy, 0x20, dummy.Length);			// ﾗｲﾝ       dummy            

				}
			}
			# endregion


			# region Const Members
			private const Int32 ctBufLen = 5;		//明細バッファサイズ
			private const Int32 ctDetailLen = 5;	//明細行数
            private const Int32 ctSndTelegramLen = 185; //送信電文サイズ
			# endregion

			# region Private Members
			//在庫電文

			//変数
			private Int32 _seq = 1;
			private Int32 _ln = 0;
			private DN_Z dn_z = new DN_Z();
            private UOESupplier _uOESupplier = null;
			# endregion

			# region Constructors
			/// <summary>
			/// コンストラクタ
			/// </summary>
			public TelegramEditAlloc0402()
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
				dn_z.Clear();
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
					// TTC   情報区分
					dn_z.jh[0] = 0x11;

					//ﾃｷｽﾄｼｰｹﾝｽ
					byte[] bBuf = UoeCommonFnc.ToByteAryFromInt32(_seq);

					dn_z.ts[0] = bBuf[2];
					dn_z.ts[1] = bBuf[3];

					//ﾃｷｽﾄ長
					dn_z.lg[0] = 0x00;
					dn_z.lg[1] = 0xb9;
					# endregion

					# region ＜業務ヘッダー部＞
					//＜業務ヘッダー部＞
					//ﾍｯﾄﾞ  電文区分
					dn_z.dbkb[0] = 0x60;

					//処理結果
					dn_z.res[0] = 0x00;

					//問い合わせ・応答区分
					UoeCommonFnc.MemCopy(ref dn_z.toikb, "1", dn_z.toikb.Length);

					//業務ID
					UoeCommonFnc.MemSet(ref dn_z.gyoid, 0x20, dn_z.gyoid.Length);
					UoeCommonFnc.MemCopy(ref dn_z.gyoid, "UOE3", 4);

					//ﾊﾟｽﾜｰﾄﾞ
					UoeCommonFnc.MemSet(ref dn_z.pass, 0x20, dn_z.pass.Length);

					//ﾊﾞｰｼﾞｮﾝ番号
					UoeCommonFnc.MemSet(ref dn_z.vers, 0x20, dn_z.vers.Length);

					//継続区分
					UoeCommonFnc.MemCopy(ref dn_z.keikb, "N", 1);

					//引当ID
					UoeCommonFnc.MemSet(ref dn_z.hikid, 0x20, dn_z.hikid.Length);

					//拡張ｴﾘｱ
					UoeCommonFnc.MemSet(ref dn_z.exten, 0x00, dn_z.exten.Length);

					//処理結果
					dn_z.kekka[0] = 0x00;

					//継続ﾌﾗｸﾞ
					UoeCommonFnc.MemCopy(ref dn_z.keiflg, "0", 1);

					//ｼｰｹﾝｽNO
                    UoeCommonFnc.MemCopy(ref dn_z.seqno, String.Format("{0:D3}", _seq), dn_z.seqno.Length);

					//入力日付
					dn_z.inpymd[0] = UoeCommonFnc.ToByteFromInt32(DateTime.Now.Day);	//日
					dn_z.inpymd[1] = UoeCommonFnc.ToByteFromInt32(DateTime.Now.Hour);	//時
					dn_z.inpymd[2] = UoeCommonFnc.ToByteFromInt32(DateTime.Now.Minute);//分
					dn_z.inpymd[3] = UoeCommonFnc.ToByteFromInt32(DateTime.Now.Second);//秒

					//受付日付
					UoeCommonFnc.MemSet(ref dn_z.ukeymd, 0x20, dn_z.ukeymd.Length);
					# endregion
				}

				# region ＜明細部＞
				//＜明細部＞
				if (_ln < ctDetailLen)
				{
					//品番
					UoeCommonFnc.MemCopy(ref dn_z.ln_z[_ln].hb, (string)dr[StockSndRcvJnlSchema.ct_Col_GoodsNoNoneHyphen], dn_z.ln_z[_ln].hb.Length);

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

				ms.Write(dn_z.jh, 0, dn_z.jh.Length);			// ﾍｯﾀﾞ TTC  情報区分         
				ms.Write(dn_z.ts, 0, dn_z.ts.Length);			//           ﾃｷｽﾄｼｰｹﾝｽ        
				ms.Write(dn_z.lg, 0, dn_z.lg.Length);			//           ﾃｷｽﾄ長           
				ms.Write(dn_z.dbkb, 0, dn_z.dbkb.Length);		//           電文区分         
				ms.Write(dn_z.res, 0, dn_z.res.Length);			//           処理結果         
				ms.Write(dn_z.toikb, 0, dn_z.toikb.Length);		//           問合せ応答区分   
				ms.Write(dn_z.gyoid, 0, dn_z.gyoid.Length);		//           業務ID           
				ms.Write(dn_z.pass, 0, dn_z.pass.Length);		//           ﾊﾟｽﾜｰﾄﾞ          
				ms.Write(dn_z.vers, 0, dn_z.vers.Length);		//           ﾊﾞｰｼﾞｮﾝ番号      
				ms.Write(dn_z.keikb, 0, dn_z.keikb.Length);		//           継続区分         
				ms.Write(dn_z.hikid, 0, dn_z.hikid.Length);		//           取引ID           
				ms.Write(dn_z.exten, 0, dn_z.exten.Length);		//           拡張ｴﾘｱ          
				ms.Write(dn_z.kekka, 0, dn_z.kekka.Length);		//     ﾍｯﾄﾞ1 業務処理結果     
				ms.Write(dn_z.keiflg, 0, dn_z.keiflg.Length);	//           継続フラグ       
				ms.Write(dn_z.seqno, 0, dn_z.seqno.Length);		//           ｼｰｹﾝｽNO          
				ms.Write(dn_z.inpymd, 0, dn_z.inpymd.Length);	//           入力日付時間     
				ms.Write(dn_z.ukeymd, 0, dn_z.ukeymd.Length);	//           受付日付時間     

				//明細部
				for (int i = 0; i < ctBufLen; i++)
				{
					ms.Write(dn_z.ln_z[i].hb, 0, dn_z.ln_z[i].hb.Length);	// ﾗｲﾝ      部品番号          
				}

				//dummy
				ms.Write(dn_z.dummy, 0, dn_z.dummy.Length);		// ﾗｲﾝ       dummy            

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

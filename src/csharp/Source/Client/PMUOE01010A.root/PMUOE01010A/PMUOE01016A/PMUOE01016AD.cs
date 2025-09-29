//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : ＵＯＥ送信編集＜在庫＞（ホンダ）アクセスクラス
// プログラム概要   : ＵＯＥ送信編集＜在庫＞（ホンダ）アクセスを行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10501071-00 作成担当 : 立花 裕輔
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
	/// ＵＯＥ送信編集＜在庫＞（ホンダ）アクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : ＵＯＥ送信編集＜在庫＞（ホンダ）アクセスクラス</br>
	/// <br>Programmer : 96186 立花裕輔</br>
	/// <br>Date       : 2008.05.26</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// <br>2008.05.26 men 新規作成</br>
	/// </remarks>
	public partial class UoeSndEdit0501Acs
	{
		// ===================================================================================== //
		// プライベートメソッド
		// ===================================================================================== //
		# region Private Methods

		# region ＵＯＥ送信編集＜在庫＞（ホンダ）
		/// <summary>
		/// ＵＯＥ送信編集＜在庫＞（ホンダ）
		/// </summary>
		/// <param name="_uoeSndEditRst"></param>
		/// <param name="message"></param>
		/// <returns></returns>
		private int writeUOESNDEditAlloc0501(out List<UoeSndDtl> list, out string message)
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
				TelegramEditAlloc0501 telegramEditAlloc0501 = new TelegramEditAlloc0501();
                telegramEditAlloc0501.uOESupplier = uOESupplier;
				telegramEditAlloc0501.Seq = 1;

				UoeSndDtl uoeSndDtl = new UoeSndDtl();
				Int32 headerSet = 0;	//ヘッダー部設定フラグ 0:設定する 1:設定しない

				//＜在庫電文作成＞
				for (int i = 0; i < maxCount; i++)
				{
                    DataRow dr = StockView[i].Row;

					//電文生成領域にデータが存在
					//発注番号が変更された
					if ((headerSet != 0)
					&& (uoeSndDtl.UOESalesOrderNo != (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOESalesOrderNo]))
					{
						uoeSndDtl.SndTelegram = telegramEditAlloc0501.ToByteArray(0);
                        uoeSndDtl.SndTelegramLen = telegramEditAlloc0501.SndTelegramLen;
                        _list.Add(uoeSndDtl);
						headerSet = 0;
						telegramEditAlloc0501.Seq += 1;
					}
					//＜ヘッダー部設定処理＞
					if (headerSet == 0)
					{
						headerSet = 1;

						//電文明細クラスのクリア
						telegramEditAlloc0501.Clear();

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
					telegramEditAlloc0501.Telegram(dr);
				}
				//電文生成領域にデータが存在
				if (headerSet != 0)
				{
					uoeSndDtl.SndTelegram = telegramEditAlloc0501.ToByteArray(1);
                    uoeSndDtl.SndTelegramLen = telegramEditAlloc0501.SndTelegramLen;
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

		# region ＵＯＥ送信電文作成＜在庫＞（ホンダ）
		/// <summary>
		/// ＵＯＥ送信電文作成＜在庫＞（ホンダ）
		/// </summary>
		public class TelegramEditAlloc0501
		{
			# region ＰＭ７ソース
			//									//-- 電文領域...ﾗｲﾝ...在確 --
			//struct	LN_Z {						// 13ﾊﾞｲﾄ                     
			//	char	hb[13];					// ﾗｲﾝ      品番              
			//};
			//									//-- 電文領域...本体...在確 --
			//struct	DN_Z {						// 57 +260 +1731 = 2048ﾊﾞｲﾄ   
			//	char	id[4];					// ﾍｯﾀﾞ TTC  TRN ID	          
			//	char	sp1[5];					//           空白	          
			//	char	ctl[8];					//           制御部           
			//	char	fkb[2];					//           負担区分	      
			//	char	hbcd[9];				//           販売店ｺｰﾄﾞ       
			//	char	goki[1];				//           号機	          
			//	char	pass[6];				//           ﾊﾟｽﾜｰﾄﾞ          
			//	char	rsno[1];				//           ﾘﾘｰｽNO       	  
			//	char	kera[8];				//           拡張ｴﾘｱ  	      
			//	char	seqn[2];				//           seq番号          
			//	char	yksu[2];				//           有効件数　       
			//	char	seq[3];					//           seq番号          
			//	char	dttm[6];				//           日付･時刻        
			//	char	kflg[1];				//           継続ﾌﾗｸﾞ         
			//	struct	LN_Z	ln_z[20];		// ﾗｲﾝ       15*20=300ﾊﾞｲﾄ    
			//	char	dummy[1730];			// ﾗｲﾝ       dummy            
			//};
			# endregion

			# region 電文領域クラス
			/// <summary>
			/// 在庫電文領域＜ライン＞
			/// </summary>
			private class LN_Z
			{
				public byte[] hb = new byte[13];				// ﾗｲﾝ      品番              

				public LN_Z()
				{
					Clear();
				}
				public void Clear()
				{
					UoeCommonFnc.MemSet(ref hb, 0x20, hb.Length);				// ﾗｲﾝ      品番              
				}
			}

			/// <summary>
			/// 在庫電文領域＜本体＞
			/// </summary>
			private class DN_Z
			{
				public byte[] id = new byte[4];					// ﾍｯﾀﾞ TTC  TRN ID	          
				public byte[] sp1 = new byte[5];				//           空白	          
				public byte[] ctl = new byte[8];				//           制御部           
				public byte[] fkb = new byte[2];				//           負担区分	      
				public byte[] hbcd = new byte[9];				//           販売店ｺｰﾄﾞ       
				public byte[] goki = new byte[1];				//           号機	          
				public byte[] pass = new byte[6];				//           ﾊﾟｽﾜｰﾄﾞ          
				public byte[] rsno = new byte[1];				//           ﾘﾘｰｽNO       	  
				public byte[] kera = new byte[8];				//           拡張ｴﾘｱ  	      
				public byte[] seqn = new byte[2];				//           seq番号          
				public byte[] yksu = new byte[2];				//           有効件数       
				public byte[] seq = new byte[3];				//           seq番号          
				public byte[] dttm = new byte[6];				//           日付･時刻        
				public byte[] kflg = new byte[1];				//           継続ﾌﾗｸﾞ         
				public LN_Z[] ln_z = new LN_Z[ctBufLen];		// ﾗｲﾝ       15*20=300ﾊﾞｲﾄ    
				public byte[] dummy = new byte[1730];			// ﾗｲﾝ       dummy            
	
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
					UoeCommonFnc.MemSet(ref id, 0x20, id.Length);				// ﾍｯﾀﾞ TTC  TRN ID	          
					UoeCommonFnc.MemSet(ref sp1, 0x20, sp1.Length);				//           空白	          
					UoeCommonFnc.MemSet(ref ctl, 0x20, ctl.Length);				//           制御部           
					UoeCommonFnc.MemSet(ref fkb, 0x20, fkb.Length);				//           負担区分	      
					UoeCommonFnc.MemSet(ref hbcd, 0x20, hbcd.Length);			//           販売店ｺｰﾄﾞ       
					UoeCommonFnc.MemSet(ref goki, 0x20, goki.Length);			//           号機	          
					UoeCommonFnc.MemSet(ref pass, 0x20, pass.Length);			//           ﾊﾟｽﾜｰﾄﾞ          
					UoeCommonFnc.MemSet(ref rsno, 0x20, rsno.Length);			//           ﾘﾘｰｽNO       	  
					UoeCommonFnc.MemSet(ref kera, 0x20, kera.Length);			//           拡張ｴﾘｱ  	      
					UoeCommonFnc.MemSet(ref seqn, 0x20, seqn.Length);			//           seq番号          
					UoeCommonFnc.MemSet(ref yksu, 0x20, yksu.Length);			//           有効件数       
					UoeCommonFnc.MemSet(ref seq, 0x20, seq.Length);				//           seq番号          
					UoeCommonFnc.MemSet(ref dttm, 0x20, dttm.Length);			//           日付･時刻        
					UoeCommonFnc.MemSet(ref kflg, 0x20, kflg.Length);			//           継続ﾌﾗｸﾞ         

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
			private const Int32 ctBufLen = 20;		//明細バッファサイズ
			private const Int32 ctDetailLen = 20;	//明細行数
            private const Int32 ctSndTelegramLen = 252; //送信電文サイズ
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
			public TelegramEditAlloc0501()
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
					//トランザクションＩＤ テストモードの判定
					if(uOESupplier.UOETestMode.Trim() == "9")
					{
						UoeCommonFnc.MemCopy(ref  dn_z.id, "PT81", dn_z.id.Length );
					}
					else
					{
						UoeCommonFnc.MemCopy(ref  dn_z.id, "PL81", dn_z.id.Length );
					}

					//空白
					UoeCommonFnc.MemSet(ref dn_z.sp1, 0x20, dn_z.sp1.Length );

					//制御部
					UoeCommonFnc.MemSet(ref dn_z.ctl, 0x20, dn_z.ctl.Length );
					UoeCommonFnc.MemCopy(ref  dn_z.ctl, "HT11", 4 );

					//負担区分
					dn_z.fkb[0] = 0x30 ;
					dn_z.fkb[1] = 0x32 ;

					/* 販売店ｺｰﾄﾞ    */
					UoeCommonFnc.MemCopy(ref dn_z.hbcd, uOESupplier.UOEConnectUserId, dn_z.hbcd.Length );

					//号機
					UoeCommonFnc.MemCopy(ref dn_z.goki, uOESupplier.instrumentNo, 1);

					//パスワード
					UoeCommonFnc.MemCopy(ref dn_z.pass, uOESupplier.UOEConnectPassword,  dn_z.pass.Length );

					//リリースＮｏ．
					dn_z.rsno[0] = 0x31 ;

					//拡張エリア
					UoeCommonFnc.MemSet(ref dn_z.kera, 0x20, dn_z.kera.Length );
				
					//ＳＥＱＮｏ．
					dn_z.seqn[0] = 0x30 ;
					dn_z.seqn[1] = 0x31 ;

					//ＳＥＱ
                    UoeCommonFnc.MemCopy(ref dn_z.seq, String.Format("{0:D3}", _seq), dn_z.seq.Length);

					//年月・日時・分秒
					dn_z.dttm[0] = UoeCommonFnc.ToByteFromInt32(DateTime.Now.Year % 100);	//年
					dn_z.dttm[1] = UoeCommonFnc.ToByteFromInt32(DateTime.Now.Month);	//月
					dn_z.dttm[2] = UoeCommonFnc.ToByteFromInt32(DateTime.Now.Day);	//日
					dn_z.dttm[3] = UoeCommonFnc.ToByteFromInt32(DateTime.Now.Hour);	//時
					dn_z.dttm[4] = UoeCommonFnc.ToByteFromInt32(DateTime.Now.Minute);	//分
					dn_z.dttm[5] = UoeCommonFnc.ToByteFromInt32(DateTime.Now.Second);	//秒

					//継続フラグ
					dn_z.kflg[0] = 0x30;						/* 継続ﾌﾗｸﾞ    */
				}

				//有効件数
                UoeCommonFnc.MemCopy(ref dn_z.yksu, String.Format("{0:D2}", _ln + 1), dn_z.yksu.Length);

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
			public byte[] ToByteArray(int kflg)
			{
				//継続なし
				if (kflg == 1)
				{
					//dn_z.kflg[0] = 0x31;
                    dn_z.kflg[0] = 0x30;
                }
				//継続あり
				else
				{
					dn_z.kflg[0] = 0x30;
				}
				MemoryStream ms = new MemoryStream();

				ms.Write(dn_z.id, 0, dn_z.id.Length);				// ﾍｯﾀﾞ TTC  TRN ID	          
				ms.Write(dn_z.sp1, 0, dn_z.sp1.Length);				//           空白	          
				ms.Write(dn_z.ctl, 0, dn_z.ctl.Length);				//           制御部           
				ms.Write(dn_z.fkb, 0, dn_z.fkb.Length);				//           負担区分	      
				ms.Write(dn_z.hbcd, 0, dn_z.hbcd.Length);			//           販売店ｺｰﾄﾞ       
				ms.Write(dn_z.goki, 0, dn_z.goki.Length);			//           号機	          
				ms.Write(dn_z.pass, 0, dn_z.pass.Length);			//           ﾊﾟｽﾜｰﾄﾞ          
				ms.Write(dn_z.rsno, 0, dn_z.rsno.Length);			//           ﾘﾘｰｽNO       	  
				ms.Write(dn_z.kera, 0, dn_z.kera.Length);			//           拡張ｴﾘｱ  	      
				ms.Write(dn_z.seqn, 0, dn_z.seqn.Length);			//           seq番号          
				ms.Write(dn_z.yksu, 0, dn_z.yksu.Length);			//           有効件数       
				ms.Write(dn_z.seq, 0, dn_z.seq.Length);				//           seq番号          
				ms.Write(dn_z.dttm, 0, dn_z.dttm.Length);			//           日付･時刻        
				ms.Write(dn_z.kflg, 0, dn_z.kflg.Length);			//           継続ﾌﾗｸﾞ         

				//明細部
				for (int i = 0; i < ctBufLen; i++)
				{
					ms.Write(dn_z.ln_z[i].hb, 0, dn_z.ln_z[i].hb.Length);				// ﾗｲﾝ      品番              
				}

				//dummy
				ms.Write(dn_z.dummy, 0, dn_z.dummy.Length);			// ﾗｲﾝ       dummy            

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

//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : ＵＯＥ送信編集＜見積＞（ホンダ）アクセスクラス
// プログラム概要   : ＵＯＥ送信編集＜見積＞（ホンダ）アクセスを行う
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
	/// ＵＯＥ送信編集＜見積＞（ホンダ）アクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : ＵＯＥ送信編集＜見積＞（ホンダ）アクセスクラス</br>
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

		# region ＵＯＥ送信編集＜見積＞（ホンダ）
		/// <summary>
		/// ＵＯＥ送信編集＜見積＞（ホンダ）
		/// </summary>
		/// <param name="_uoeSndEditRst"></param>
		/// <param name="message"></param>
		/// <returns></returns>
		private int writeUOESNDEditEstm0501(out List<UoeSndDtl> list, out string message)
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
				TelegramEditEstm0501 telegramEditEstm0501 = new TelegramEditEstm0501();
                telegramEditEstm0501.uOESupplier = uOESupplier;
				telegramEditEstm0501.Seq = 1;

				UoeSndDtl uoeSndDtl = new UoeSndDtl();
				Int32 headerSet = 0;	//ヘッダー部設定フラグ 0:設定する 1:設定しない

				//＜見積電文作成＞
				for (int i = 0; i < maxCount; i++)
				{
					DataRow dr = EstmtView[i].Row;

					//電文生成領域にデータが存在
					//発注番号が変更された
					if ((headerSet != 0)
					&& (uoeSndDtl.UOESalesOrderNo != (Int32)dr[EstmtSndRcvJnlSchema.ct_Col_UOESalesOrderNo]))
					{
						uoeSndDtl.SndTelegram = telegramEditEstm0501.ToByteArray(0);
                        uoeSndDtl.SndTelegramLen = telegramEditEstm0501.SndTelegramLen;
						_list.Add(uoeSndDtl);
						headerSet = 0;
						telegramEditEstm0501.Seq += 1;
					}
					//＜ヘッダー部設定処理＞
					if (headerSet == 0)
					{
						headerSet = 1;

						//電文明細クラスのクリア
						telegramEditEstm0501.Clear();

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
					telegramEditEstm0501.Telegram(dr);
				}
				//電文生成領域にデータが存在
				if (headerSet != 0)
				{
					uoeSndDtl.SndTelegram = telegramEditEstm0501.ToByteArray(1);
                    uoeSndDtl.SndTelegramLen = telegramEditEstm0501.SndTelegramLen;
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

		# region ＵＯＥ送信電文作成＜見積＞（ホンダ）
		/// <summary>
		/// ＵＯＥ送信電文作成＜見積＞（ホンダ）
		/// </summary>
		public class TelegramEditEstm0501
		{
			# region ＰＭ７ソース
			//									//-- 電文領域...ﾗｲﾝ...見積 --
			//struct	LN_M {						// 13ﾊﾞｲﾄ                     
			//	char	hb[13];					// ﾗｲﾝ      品番              
			//};
			//									//-- 電文領域...本体...見積 --
			//struct	DN_M {						// 57 +260 +1731 = 2048ﾊﾞｲﾄ   
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
			//	struct	LN_M	ln_m[20];		// ﾗｲﾝ       13*20=260ﾊﾞｲﾄ    
			//	char	dummy[1730];			// ﾗｲﾝ       dummy            
			//};
			# endregion

			# region 電文領域クラス
			/// <summary>
			/// 見積電文領域＜ライン＞
			/// </summary>
			private class LN_M
			{
				public byte[] hb = new byte[13];				// ﾗｲﾝ      品番              

				public LN_M()
				{
					Clear();
				}
				public void Clear()
				{
					UoeCommonFnc.MemSet(ref hb, 0x20, hb.Length);				// ﾗｲﾝ      品番              
				}
			}

			/// <summary>
			/// 見積電文領域＜本体＞
			/// </summary>
			private class DN_M
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
				public LN_M[] ln_m = new LN_M[ctBufLen];		// ﾗｲﾝ       13*20=260ﾊﾞｲﾄ    
				public byte[] dummy = new byte[1730];			// ﾗｲﾝ       dummy            

				/// <summary>
				/// コンストラクター
				/// </summary>
				public DN_M()
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
                        if (ln_m[i] == null)
                        {
                            ln_m[i] = new LN_M();
                        }
                        else
                        {
                            ln_m[i].Clear();
                        }
                    }
					UoeCommonFnc.MemSet(ref dummy, 0x20, dummy.Length);			// ﾗｲﾝ       dummy            
				}
			}
			# endregion


			# region Const Members
			private const Int32 ctBufLen = 20;		//明細バッファサイズ
			private const Int32 ctDetailLen = 20;	//明細行数
            private const Int32 ctSndTelegramLen = 187; //送信電文サイズ
			# endregion

			# region Private Members
			//変数
			private Int32 _seq = 1;
			private Int32 _ln = 0;
			private DN_M dn_m = new DN_M();
            private UOESupplier _uOESupplier = null;
			# endregion

			# region Constructors
			/// <summary>
			/// コンストラクタ
			/// </summary>
			public TelegramEditEstm0501()
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
				dn_m.Clear();
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
						UoeCommonFnc.MemCopy(ref  dn_m.id, "PT8D", dn_m.id.Length );
					}
					else
					{
						UoeCommonFnc.MemCopy(ref  dn_m.id, "PL8D", dn_m.id.Length );
					}

					//空白
					UoeCommonFnc.MemSet(ref dn_m.sp1, 0x20, dn_m.sp1.Length );

					//制御部
					UoeCommonFnc.MemSet(ref dn_m.ctl, 0x20, dn_m.ctl.Length );
					UoeCommonFnc.MemCopy(ref  dn_m.ctl, "HT11", 4 );

					//負担区分
					dn_m.fkb[0] = 0x30 ;
					dn_m.fkb[1] = 0x32 ;

					/* 販売店ｺｰﾄﾞ    */
					UoeCommonFnc.MemCopy(ref dn_m.hbcd, uOESupplier.UOEConnectUserId, dn_m.hbcd.Length );

					//号機
					UoeCommonFnc.MemCopy(ref dn_m.goki, uOESupplier.instrumentNo, 1);

					//パスワード
					UoeCommonFnc.MemCopy(ref dn_m.pass, uOESupplier.UOEConnectPassword,  dn_m.pass.Length );

					//リリースＮｏ．
					dn_m.rsno[0] = 0x31 ;

					//拡張エリア
					UoeCommonFnc.MemSet(ref dn_m.kera, 0x20, dn_m.kera.Length );
				
					//ＳＥＱＮｏ．
					dn_m.seqn[0] = 0x30 ;
					dn_m.seqn[1] = 0x31 ;

					//ＳＥＱ
                    UoeCommonFnc.MemCopy(ref dn_m.seq, String.Format("{0:D3}", _seq), dn_m.seq.Length);

					//年月・日時・分秒
					dn_m.dttm[0] = UoeCommonFnc.ToByteFromInt32(DateTime.Now.Year % 100);   //年
					dn_m.dttm[1] = UoeCommonFnc.ToByteFromInt32(DateTime.Now.Month);	    //月
					dn_m.dttm[2] = UoeCommonFnc.ToByteFromInt32(DateTime.Now.Day);	        //日
					dn_m.dttm[3] = UoeCommonFnc.ToByteFromInt32(DateTime.Now.Hour);	        //時
					dn_m.dttm[4] = UoeCommonFnc.ToByteFromInt32(DateTime.Now.Minute);	    //分
					dn_m.dttm[5] = UoeCommonFnc.ToByteFromInt32(DateTime.Now.Second);	    //秒

					//継続フラグ
					dn_m.kflg[0] = 0x30;						/* 継続ﾌﾗｸﾞ    */
				}

				//有効件数
                UoeCommonFnc.MemCopy(ref dn_m.yksu, String.Format("{0:D2}", _ln + 1), dn_m.yksu.Length);

				# region ＜明細部＞
				//＜明細部＞
				if (_ln < ctDetailLen)
				{
					//品番
					UoeCommonFnc.MemCopy(ref dn_m.ln_m[_ln].hb, (string)dr[EstmtSndRcvJnlSchema.ct_Col_GoodsNoNoneHyphen], dn_m.ln_m[_ln].hb.Length);

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
					dn_m.kflg[0] = 0x31;
				}
				//継続あり
				else
				{
					dn_m.kflg[0] = 0x30;
				}
				MemoryStream ms = new MemoryStream();

				ms.Write(dn_m.id, 0, dn_m.id.Length);				// ﾍｯﾀﾞ TTC  TRN ID	          
				ms.Write(dn_m.sp1, 0, dn_m.sp1.Length);				//           空白	          
				ms.Write(dn_m.ctl, 0, dn_m.ctl.Length);				//           制御部           
				ms.Write(dn_m.fkb, 0, dn_m.fkb.Length);				//           負担区分	      
				ms.Write(dn_m.hbcd, 0, dn_m.hbcd.Length);			//           販売店ｺｰﾄﾞ       
				ms.Write(dn_m.goki, 0, dn_m.goki.Length);			//           号機	          
				ms.Write(dn_m.pass, 0, dn_m.pass.Length);			//           ﾊﾟｽﾜｰﾄﾞ          
				ms.Write(dn_m.rsno, 0, dn_m.rsno.Length);			//           ﾘﾘｰｽNO       	  
				ms.Write(dn_m.kera, 0, dn_m.kera.Length);			//           拡張ｴﾘｱ  	      
				ms.Write(dn_m.seqn, 0, dn_m.seqn.Length);			//           seq番号          
				ms.Write(dn_m.yksu, 0, dn_m.yksu.Length);			//           有効件数       
				ms.Write(dn_m.seq, 0, dn_m.seq.Length);				//           seq番号          
				ms.Write(dn_m.dttm, 0, dn_m.dttm.Length);			//           日付･時刻        
				ms.Write(dn_m.kflg, 0, dn_m.kflg.Length);			//           継続ﾌﾗｸﾞ         

				//明細部
				for (int i = 0; i < ctBufLen; i++)
				{
					ms.Write(dn_m.ln_m[i].hb, 0, dn_m.ln_m[i].hb.Length);				// ﾗｲﾝ      品番              
				}

				ms.Write(dn_m.dummy, 0, dn_m.dummy.Length);			// ﾗｲﾝ       dummy            

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

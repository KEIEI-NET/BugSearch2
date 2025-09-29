//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : ＵＯＥ送信編集＜発注＞（ホンダ）アクセスクラス
// プログラム概要   : ＵＯＥ送信編集＜発注＞（ホンダ）アクセスを行う
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
	/// ＵＯＥ送信編集＜発注＞（ホンダ）アクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : ＵＯＥ送信編集＜発注＞（ホンダ）アクセスクラス</br>
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

		# region ＵＯＥ送信編集＜発注＞（ホンダ）
		/// <summary>
		/// ＵＯＥ送信編集＜発注＞（ホンダ）
		/// </summary>
		/// <param name="uoeSndDtl">送信編集クラス</param>
		/// <param name="message">メッセージ</param>
		/// <returns></returns>
		private int writeUOESNDEditOrder0501(out List<UoeSndDtl> list, out string message)
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
				TelegramEditOrder0501 telegramEditOrder0501 = new TelegramEditOrder0501();
                telegramEditOrder0501.uOESupplier = uOESupplier;
				telegramEditOrder0501.Seq = 1;

				UoeSndDtl uoeSndDtl = new UoeSndDtl();
				Int32 headerSet = 0;	//ヘッダー部設定フラグ 0:設定する 1:設定しない

				//＜発注電文作成＞
				for (int i = 0; i < maxCount; i++)
				{
					DataRow dr = OrderView[i].Row;

					//電文生成領域にデータが存在
					//発注番号が変更された
					if ((headerSet != 0)
					&& (uoeSndDtl.UOESalesOrderNo != (Int32)dr[OrderSndRcvJnlSchema.ct_Col_UOESalesOrderNo]))
					{
						uoeSndDtl.SndTelegram = telegramEditOrder0501.ToByteArray(0);
                        uoeSndDtl.SndTelegramLen = telegramEditOrder0501.SndTelegramLen;
						_list.Add(uoeSndDtl);
						headerSet = 0;
						telegramEditOrder0501.Seq += 1;
					}
					//＜ヘッダー部設定処理＞
					if (headerSet == 0)
					{
						headerSet = 1;

						//電文明細クラスのクリア
						telegramEditOrder0501.Clear();

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
					telegramEditOrder0501.Telegram(dr);
				}
				//電文生成領域にデータが存在
				if (headerSet != 0)
				{
					uoeSndDtl.SndTelegram = telegramEditOrder0501.ToByteArray(1);
                    uoeSndDtl.SndTelegramLen = telegramEditOrder0501.SndTelegramLen;
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
				status = (int)EnumUoeConst.Status.ct_ERROR;
			}

			return status;
		}
		# endregion

		# region ＵＯＥ送信電文作成＜発注＞（ホンダ）
		/// <summary>
		/// ＵＯＥ送信電文作成＜発注＞（ホンダ）
		/// </summary>
		public class TelegramEditOrder0501
		{
			# region ＰＭ７ソース
			//struct	LN_H {						// 17ﾊﾞｲﾄ                     
			//	char	hb[13];					//          品番              
			//	char	hsu[3];					//          数量              
			//	char	bo[1];					//          引当ﾏｰｸ           
			//};
			//									//-- 電文領域...本体...発注 --
			//struct	DN_H {						// 84 +340 +1624 = 2048       
			//	char	id[4];					// ﾍｯﾀﾞ TTC  TRN ID	          
			//	char	sp1[5];					//           空白	          
			//	char	ctl[8];					//           制御部           
			//	char	fkb[2];					//           負担区分	      
			//	char	hbcd[9];				//           販売店ｺｰﾄﾞ       
			//	char	goki[1];				//           号機	          
			//	char	pass[6];				//           ﾊﾟｽﾜｰﾄﾞ          
			//	char	rsno[1];				//           ﾘﾘｰｽNO       	  
			//	char	sfg[1];					//           再送ﾌﾗｸﾞ         
			//	char	kera[7];				//           拡張ｴﾘｱ  	      
			//	char	seqn[2];				//           seq番号          
			//	char	yksu[2];				//           有効件数　       
			//	char	seq[3];					//           seq番号          
			//	char	dttm[6];				//           日付･時刻        
			//	char	kflg[1];				//           継続ﾌﾗｸﾞ         
			//	char	item[5];				//           ｱｲﾃﾑ	          
			//	char	sp2[3];					//           空白	          
			//	char	nhkb[1];				//           納品区分         
			//	char	rem[15];				//           ﾘﾏｰｸ             
			//	char	hkb[2];					//           発注区分	      
			//	struct	LN_H	ln_h[20];		// ﾗｲﾝ       17*20=340ﾊﾞｲﾄ    
			//	char	dummy[1624];			// ﾗｲﾝ       dummy            
			//};
			# endregion

			# region Const Members
			private const Int32 ctBufLen = 20;		//明細バッファサイズ
			private const Int32 ctDetailLen = 20;	//明細行数
			private const Int32 ctSndTelegramLen = 254; //送信電文サイズ
            # endregion

			# region 電文領域クラス
			/// <summary>
			/// 発注電文領域＜ライン＞
			/// </summary>
			private class LN_H
			{
				public byte[] hb = new byte[13];				//          品番              
				public byte[] hsu = new byte[3];				//          数量              
				public byte[] bo = new byte[1];					//          引当ﾏｰｸ           

				public LN_H()
				{
					Clear();
				}
				public void Clear()
				{
					UoeCommonFnc.MemSet(ref hb, 0x20, hb.Length);				//          品番              
					UoeCommonFnc.MemSet(ref hsu, 0x20, hsu.Length);				//          数量              
					UoeCommonFnc.MemSet(ref bo, 0x20, bo.Length);				//          引当ﾏｰｸ           
				}
			}

			/// <summary>
			/// 発注電文領域＜本体＞
			/// </summary>
			private class DN_H
			{
				public byte[] id = new byte[4];					// ﾍｯﾀﾞ TTC  TRN ID	          
				public byte[] sp1 = new byte[5];				//           空白	          
				public byte[] ctl = new byte[8];				//           制御部           
				public byte[] fkb = new byte[2];				//           負担区分	      
				public byte[] hbcd = new byte[9];				//           販売店ｺｰﾄﾞ       
				public byte[] goki = new byte[1];				//           号機	          
				public byte[] pass = new byte[6];				//           ﾊﾟｽﾜｰﾄﾞ          
				public byte[] rsno = new byte[1];				//           ﾘﾘｰｽNO       	  
				public byte[] sfg = new byte[1];				//           再送ﾌﾗｸﾞ         
				public byte[] kera = new byte[7];				//           拡張ｴﾘｱ  	      
				public byte[] seqn = new byte[2];				//           seq番号          
				public byte[] yksu = new byte[2];				//           有効件数       
				public byte[] seq = new byte[3];				//           seq番号          
				public byte[] dttm = new byte[6];				//           日付･時刻        
				public byte[] kflg = new byte[1];				//           継続ﾌﾗｸﾞ         
				public byte[] item = new byte[5];				//           ｱｲﾃﾑ	          
				public byte[] sp2 = new byte[3];				//           空白	          
				public byte[] nhkb = new byte[1];				//           納品区分         
				public byte[] rem = new byte[15];				//           ﾘﾏｰｸ             
				public byte[] hkb = new byte[2];				//           発注区分	      
				public LN_H[] ln_h = new LN_H[ctBufLen];		// ﾗｲﾝ       17*20=340ﾊﾞｲﾄ    
				public byte[] dummy = new byte[1624];			// ﾗｲﾝ       dummy	      

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
					UoeCommonFnc.MemSet(ref id, 0x20, id.Length);				// ﾍｯﾀﾞ TTC  TRN ID	          
					UoeCommonFnc.MemSet(ref sp1, 0x20, sp1.Length);				//           空白	          
					UoeCommonFnc.MemSet(ref ctl, 0x20, ctl.Length);				//           制御部           
					UoeCommonFnc.MemSet(ref fkb, 0x20, fkb.Length);				//           負担区分	      
					UoeCommonFnc.MemSet(ref hbcd, 0x20, hbcd.Length);			//           販売店ｺｰﾄﾞ       
					UoeCommonFnc.MemSet(ref goki, 0x20, goki.Length);			//           号機	          
					UoeCommonFnc.MemSet(ref pass, 0x20, pass.Length);			//           ﾊﾟｽﾜｰﾄﾞ          
					UoeCommonFnc.MemSet(ref rsno, 0x20, rsno.Length);			//           ﾘﾘｰｽNO       	  
					UoeCommonFnc.MemSet(ref sfg, 0x20, sfg.Length);				//           再送ﾌﾗｸﾞ         
					UoeCommonFnc.MemSet(ref kera, 0x20, kera.Length);			//           拡張ｴﾘｱ  	      
					UoeCommonFnc.MemSet(ref seqn, 0x20, seqn.Length);			//           seq番号          
					UoeCommonFnc.MemSet(ref yksu, 0x20, yksu.Length);			//           有効件数       
					UoeCommonFnc.MemSet(ref seq, 0x20, seq.Length);				//           seq番号          
					UoeCommonFnc.MemSet(ref dttm, 0x20, dttm.Length);			//           日付･時刻        
					UoeCommonFnc.MemSet(ref kflg, 0x20, kflg.Length);			//           継続ﾌﾗｸﾞ         
					UoeCommonFnc.MemSet(ref item, 0x20, item.Length);			//           ｱｲﾃﾑ	          
					UoeCommonFnc.MemSet(ref sp2, 0x20, sp2.Length);				//           空白	          
					UoeCommonFnc.MemSet(ref nhkb, 0x20, nhkb.Length);			//           納品区分         
					UoeCommonFnc.MemSet(ref rem, 0x20, rem.Length);				//           ﾘﾏｰｸ             
					UoeCommonFnc.MemSet(ref hkb, 0x20, hkb.Length);				//           発注区分	      

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
					UoeCommonFnc.MemSet(ref dummy, 0x20, dummy.Length);			// ﾗｲﾝ       dummy            
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
			public TelegramEditOrder0501()
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
			/// <param name="dr">DataRow</param>
			public void Telegram(DataRow dr)
			{
				//ＴＴＣ部 業務ヘッダー部 ヘッダー部作成
				if (_ln == 0)
				{
					//トランザクションＩＤ テストモードの判定
					if(uOESupplier.UOETestMode.Trim() == "9")
					{
						UoeCommonFnc.MemCopy(ref dn_h.id, "PT3A", dn_h.id.Length );//TRｺｰﾄﾞ
					}
					else
					{
						UoeCommonFnc.MemCopy(ref dn_h.id, "PL3A", dn_h.id.Length );//TRｺｰﾄﾞ
					}

					//空白
					UoeCommonFnc.MemSet(ref dn_h.sp1, 0x20, dn_h.sp1.Length );

					//制御部
					UoeCommonFnc.MemSet(ref dn_h.ctl, 0x20, dn_h.ctl.Length );

					//制御部
					UoeCommonFnc.MemCopy(ref dn_h.ctl, "HT11", 4 );

					//負担区分
					dn_h.fkb[0] = 0x30 ;						
					dn_h.fkb[1] = 0x32 ;

					//販売店ｺｰﾄﾞ
					UoeCommonFnc.MemCopy(ref dn_h.hbcd, uOESupplier.UOEConnectUserId, dn_h.hbcd.Length );

					//号機
					UoeCommonFnc.MemCopy(ref dn_h.goki, uOESupplier.instrumentNo, 1);
				
					//パスワード
					UoeCommonFnc.MemCopy(ref dn_h.pass, uOESupplier.UOEConnectPassword,  dn_h.pass.Length );

					//リリースＮｏ．
					dn_h.rsno[0] = 0x31 ;

					//再送フラグ
					dn_h.sfg[0] = 0x30 ;

					//拡張エリア
					UoeCommonFnc.MemSet(ref dn_h.kera, 0x20, dn_h.kera.Length );
				
					//ＳＥＱＮｏ．
					dn_h.seqn[0] = 0x30 ;
					dn_h.seqn[1] = 0x31 ;

					//ＳＥＱ
                    UoeCommonFnc.MemCopy(ref dn_h.seq, String.Format("{0:D3}", _seq), dn_h.seq.Length);

					//年月・日時・分秒
					dn_h.dttm[0] = UoeCommonFnc.ToByteFromInt32(DateTime.Now.Year % 100);	//年
					dn_h.dttm[1] = UoeCommonFnc.ToByteFromInt32(DateTime.Now.Month);	    //月
					dn_h.dttm[2] = UoeCommonFnc.ToByteFromInt32(DateTime.Now.Day);	        //日
					dn_h.dttm[3] = UoeCommonFnc.ToByteFromInt32(DateTime.Now.Hour);	        //時
					dn_h.dttm[4] = UoeCommonFnc.ToByteFromInt32(DateTime.Now.Minute);	    //分
					dn_h.dttm[5] = UoeCommonFnc.ToByteFromInt32(DateTime.Now.Second);	    //秒

					//継続フラグ
					dn_h.kflg[0] = 0x30;
	
					//アイテム
                    String uOEItemCd = uOESupplier.UOEItemCd.Trim();
                    UoeCommonFnc.MemCopy(ref dn_h.item, uOEItemCd, uOEItemCd.Length);

					//空白
					UoeCommonFnc.MemSet(ref dn_h.sp2, 0x20, dn_h.sp2.Length );
				
					//納品区分
                    UoeCommonFnc.MemCopy(ref dn_h.nhkb, (string)dr[OrderSndRcvJnlSchema.ct_Col_UOEDeliGoodsDiv], dn_h.nhkb.Length);				

                    //ﾘﾏｰｸ
					UoeCommonFnc.MemCopy(ref dn_h.rem, (string)dr[OrderSndRcvJnlSchema.ct_Col_UoeRemark1], dn_h.rem.Length);

					//発注区分
					//dn_h.hkb[0] = (char)uoejla.PM1521;
					UoeCommonFnc.MemSet(ref dn_h.hkb, 0x20, dn_h.hkb.Length);
				}


				# region ＜明細部＞
				//＜明細部＞
				if (_ln < ctDetailLen)
				{
					//部品番号
					UoeCommonFnc.MemCopy(ref dn_h.ln_h[_ln].hb, (string)dr[OrderSndRcvJnlSchema.ct_Col_GoodsNoNoneHyphen], dn_h.ln_h[_ln].hb.Length);

					//数量
					double hsuDouble = (double)dr[OrderSndRcvJnlSchema.ct_Col_AcceptAnOrderCnt];
                    UoeCommonFnc.MemCopy(ref dn_h.ln_h[_ln].hsu, String.Format("{0:D3}", (int)hsuDouble), dn_h.ln_h[_ln].hsu.Length);
					
					//引当マーク
					UoeCommonFnc.MemCopy(ref dn_h.ln_h[_ln].bo, (string)dr[OrderSndRcvJnlSchema.ct_Col_BoCode], dn_h.ln_h[_ln].bo.Length);

					//明細数インクリメント
					_ln++;
         
				}

                //有効件数
                UoeCommonFnc.MemCopy(ref dn_h.yksu, String.Format("{0:D2}", _ln), dn_h.yksu.Length);

                # endregion
			}
			# endregion
			# endregion

			# region private Methods
			# region バイト型配列に変換
			/// <summary>
			/// バイト型配列に変換
			/// </summary>
			/// <returns>バイト型配列</returns>
			public byte[] ToByteArray(int kflg)
			{
				//継続なし
				if(kflg == 1)
				{
					dn_h.kflg[0] = 0x31;
				}
				//継続あり
				else
				{
					dn_h.kflg[0] = 0x30;
				}

				MemoryStream ms = new MemoryStream();

				ms.Write(dn_h.id, 0, dn_h.id.Length);				// ﾍｯﾀﾞ TTC  TRN ID	          
				ms.Write(dn_h.sp1, 0, dn_h.sp1.Length);				//           空白	          
				ms.Write(dn_h.ctl, 0, dn_h.ctl.Length);				//           制御部           
				ms.Write(dn_h.fkb, 0, dn_h.fkb.Length);				//           負担区分	      
				ms.Write(dn_h.hbcd, 0, dn_h.hbcd.Length);			//           販売店ｺｰﾄﾞ       
				ms.Write(dn_h.goki, 0, dn_h.goki.Length);			//           号機	          
				ms.Write(dn_h.pass, 0, dn_h.pass.Length);			//           ﾊﾟｽﾜｰﾄﾞ          
				ms.Write(dn_h.rsno, 0, dn_h.rsno.Length);			//           ﾘﾘｰｽNO       	  
				ms.Write(dn_h.sfg, 0, dn_h.sfg.Length);				//           再送ﾌﾗｸﾞ         
				ms.Write(dn_h.kera, 0, dn_h.kera.Length);			//           拡張ｴﾘｱ  	      
				ms.Write(dn_h.seqn, 0, dn_h.seqn.Length);			//           seq番号          
				ms.Write(dn_h.yksu, 0, dn_h.yksu.Length);			//           有効件数       
				ms.Write(dn_h.seq, 0, dn_h.seq.Length);				//           seq番号          
				ms.Write(dn_h.dttm, 0, dn_h.dttm.Length);			//           日付･時刻        
				ms.Write(dn_h.kflg, 0, dn_h.kflg.Length);			//           継続ﾌﾗｸﾞ         
				ms.Write(dn_h.item, 0, dn_h.item.Length);			//           ｱｲﾃﾑ	          
				ms.Write(dn_h.sp2, 0, dn_h.sp2.Length);				//           空白	          
				ms.Write(dn_h.nhkb, 0, dn_h.nhkb.Length);			//           納品区分         
				ms.Write(dn_h.rem, 0, dn_h.rem.Length);				//           ﾘﾏｰｸ             
				ms.Write(dn_h.hkb, 0, dn_h.hkb.Length);				//           発注区分	      

				//明細部
				for (int i = 0; i < ctBufLen; i++)
				{
					ms.Write(dn_h.ln_h[i].hb, 0, dn_h.ln_h[i].hb.Length);				//          品番              
					ms.Write(dn_h.ln_h[i].hsu, 0, dn_h.ln_h[i].hsu.Length);				//          数量              
					ms.Write(dn_h.ln_h[i].bo, 0, dn_h.ln_h[i].bo.Length);				//          引当ﾏｰｸ           
				}

				//dummy
				ms.Write(dn_h.dummy, 0, dn_h.dummy.Length);			// ﾗｲﾝ       dummy            

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

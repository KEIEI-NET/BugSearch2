//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : ＵＯＥ送信編集＜発注＞（優良）アクセスクラス
// プログラム概要   : ＵＯＥ送信編集＜発注＞（優良）アクセスを行う
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
	/// ＵＯＥ送信編集＜発注＞（優良）アクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : ＵＯＥ送信編集＜発注＞（優良）アクセスクラス</br>
	/// <br>Programmer : 96186 立花裕輔</br>
	/// <br>Date       : 2008.05.26</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// <br>2008.05.26 men 新規作成</br>
	/// </remarks>
	public partial class UoeSndEdit1001Acs
	{
		// ===================================================================================== //
		// プライベートメソッド
		// ===================================================================================== //
		# region Private Methods

		# region ＵＯＥ送信編集＜発注＞（優良）
		/// <summary>
		/// ＵＯＥ送信編集＜発注＞（優良）
		/// </summary>
		/// <param name="uoeSndDtl">送信編集クラス</param>
		/// <param name="message">メッセージ</param>
		/// <returns></returns>
		private int writeUOESNDEditOrder1001(out List<UoeSndDtl> list, out string message)
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
				TelegramEditOrder1001 telegramEditOrder1001 = new TelegramEditOrder1001();
                telegramEditOrder1001.uOESupplier = uOESupplier;
				telegramEditOrder1001.Seq = 1;

				UoeSndDtl uoeSndDtl = new UoeSndDtl();
				Int32 headerSet = 0;	//ヘッダー部設定フラグ 0:設定する 1:設定しない

				//＜開局電文作成＞
				TelegramEditOpenClose1001 telegramEditOpenClose1001 = new TelegramEditOpenClose1001();
                telegramEditOpenClose1001.uOESupplier = uOESupplier;

				//ＵＯＥ送信編集結果クラスの初期化
				uoeSndDtl = new UoeSndDtl();
				uoeSndDtl.UOESalesOrderRowNo = new List<int>();

				//送信電文(JIS)
				uoeSndDtl.SndTelegram = telegramEditOpenClose1001.Telegram(_systemDivCd, (int)EnumUoeConst.OpenMode.ct_OPEN);
                uoeSndDtl.SndTelegramLen = telegramEditOpenClose1001.SndTelegramLen;

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
						uoeSndDtl.SndTelegram = telegramEditOrder1001.ToByteArray();
                        uoeSndDtl.SndTelegramLen = telegramEditOrder1001.SndTelegramLen;
                        _list.Add(uoeSndDtl);
						headerSet = 0;
						telegramEditOrder1001.Seq += 1;
					}
					//＜ヘッダー部設定処理＞
					if (headerSet == 0)
					{
						headerSet = 1;

						//電文明細クラスのクリア
						telegramEditOrder1001.Clear();

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
					telegramEditOrder1001.Telegram(dr);
				}
				//電文生成領域にデータが存在
				if (headerSet != 0)
				{
					uoeSndDtl.SndTelegram = telegramEditOrder1001.ToByteArray();
                    uoeSndDtl.SndTelegramLen = telegramEditOrder1001.SndTelegramLen;
                    _list.Add(uoeSndDtl);
					headerSet = 0;
				}

				//＜閉局電文作成＞
				//ＵＯＥ送信編集結果クラスの初期化
				uoeSndDtl = new UoeSndDtl();
				uoeSndDtl.UOESalesOrderRowNo = new List<int>();

				//送信電文(JIS)
				uoeSndDtl.SndTelegram = telegramEditOpenClose1001.Telegram(_systemDivCd, (int)EnumUoeConst.OpenMode.ct_CLOSE);
                uoeSndDtl.SndTelegramLen = telegramEditOpenClose1001.SndTelegramLen;

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

		# region ＵＯＥ送信電文作成＜発注＞（優良）
		/// <summary>
		/// ＵＯＥ送信電文作成＜発注＞（優良）
		/// </summary>
		public class TelegramEditOrder1001
		{
			# region ＰＭ７ソース
			//									//-- 電文領域...ﾗｲﾝ...発注 ---
			//struct	LN_H {						// 43ﾊﾞｲﾄ                     
			//	char	hb[20];					// ﾗｲﾝ      品番              
			//	char	mkcd[4];				//          ﾒｰｶｰｺｰﾄﾞ          
			//	char	bncd[4];				//          分類ｺｰﾄﾞ          
			//	char	hsu[3];					//          数量              
			//	char	bo[1];					//          B/Oｺｰﾄﾞ           
			//	char	ybc[1];					//          予備ｺｰﾄﾞ          
			//	char	chkcd[10];				//          ﾁｪｯｸｺｰﾄﾞ          
			//};
			//
			//									//-- 電文領域...本体...発注 --
			//struct	DN_H {						// 32 +860 +1156 = 2048       
			//	char	dkb[1];					// ﾍｯﾀﾞ      電文区分         
			//	char	sykb[1];				//           処理区分         
			//	char	tcd[7];					//           端末側コード     
			//	char	dtno[6];				//           電文問合せ番号   
			//	char	sbsu[1];				//           送信部品数       
			//	char	rem[10];				//           ﾘﾏｰｸ	          
			//	char	nhkb[1];				//           納品区分         
			//	char	kyo[3];					//           指定拠点         
			//	char	ybkb1[1];			 	//           予備区分１       
			//	char	ybkb2[1];			 	//           予備区分２       
			//	struct	LN_H	ln_h[20];		// ﾗｲﾝ       43*20=860ﾊﾞｲﾄ    
			//	char	dummy[1156];			// ﾗｲﾝ       dummy            
			//};
			# endregion

			# region Const Members
			private const Int32 ctBufLen = 6;		//明細バッファサイズ
			private const Int32 ctDetailLen = 6;	//明細行数
            //private const Int32 ctSndTelegramLen = 247; //送信電文サイズ
            private const Int32 ctSndTelegramLen = 256; //送信電文サイズ
            # endregion

			# region 電文領域クラス
			/// <summary>
			/// 発注電文領域＜ライン＞
			/// </summary>
			private class LN_H
			{
				public byte[] hb = new byte[20];		// ﾗｲﾝ      品番              
				public byte[] mkcd = new byte[4];		//          ﾒｰｶｰｺｰﾄﾞ          
				public byte[] bncd = new byte[4];		//          分類ｺｰﾄﾞ          
				public byte[] hsu = new byte[3];		//          数量              
				public byte[] bo = new byte[1];			//          B/Oｺｰﾄﾞ           
				public byte[] ybc = new byte[1];		//          予備ｺｰﾄﾞ          
				public byte[] chkcd = new byte[10];		//          ﾁｪｯｸｺｰﾄﾞ          

				public LN_H()
				{
					Clear();
				}
				public void Clear()
				{
					UoeCommonFnc.MemSet(ref hb, 0x20, hb.Length);				// ﾗｲﾝ      品番              
					UoeCommonFnc.MemSet(ref mkcd, 0x20, mkcd.Length);			//          ﾒｰｶｰｺｰﾄﾞ          
					UoeCommonFnc.MemSet(ref bncd, 0x20, bncd.Length);			//          分類ｺｰﾄﾞ          
					UoeCommonFnc.MemSet(ref hsu, 0x20, hsu.Length);				//          数量              
					UoeCommonFnc.MemSet(ref bo, 0x20, bo.Length);				//          B/Oｺｰﾄﾞ           
					UoeCommonFnc.MemSet(ref ybc, 0x20, ybc.Length);				//          予備ｺｰﾄﾞ          
					UoeCommonFnc.MemSet(ref chkcd, 0x20, chkcd.Length);			//          ﾁｪｯｸｺｰﾄﾞ          
				}
			}

			/// <summary>
			/// 発注電文領域＜本体＞
			/// </summary>
			private class DN_H
			{
				public byte[] dkb = new byte[1];		// ﾍｯﾀﾞ      電文区分         
				public byte[] sykb = new byte[1];		//           処理区分         
				public byte[] tcd = new byte[7];		//           端末側コード     
				public byte[] dtno = new byte[6];		//           電文問合せ番号   
				public byte[] sbsu = new byte[1];		//           送信部品数       
				public byte[] rem = new byte[10];		//           ﾘﾏｰｸ	          
				public byte[] nhkb = new byte[1];		//           納品区分         
				public byte[] kyo = new byte[3];		//           指定拠点         
				public byte[] ybkb1 = new byte[1];		//           予備区分１       
				public byte[] ybkb2 = new byte[1];		//           予備区分２       
				public LN_H[] ln_h = new LN_H[20];		// ﾗｲﾝ       43*20=860ﾊﾞｲﾄ    
				public byte[] dummy = new byte[1156];	// ﾗｲﾝ       dummy            

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
					UoeCommonFnc.MemSet(ref dkb, 0x20, dkb.Length);				// ﾍｯﾀﾞ      電文区分         
					UoeCommonFnc.MemSet(ref sykb, 0x20, sykb.Length);			//           処理区分         
					UoeCommonFnc.MemSet(ref tcd, 0x20, tcd.Length);				//           端末側コード     
					UoeCommonFnc.MemSet(ref dtno, 0x20, dtno.Length);			//           電文問合せ番号   
					UoeCommonFnc.MemSet(ref sbsu, 0x20, sbsu.Length);			//           送信部品数       
					UoeCommonFnc.MemSet(ref rem, 0x20, rem.Length);				//           ﾘﾏｰｸ	          
					UoeCommonFnc.MemSet(ref nhkb, 0x20, nhkb.Length);			//           納品区分         
					UoeCommonFnc.MemSet(ref kyo, 0x20, kyo.Length);				//           指定拠点         
					UoeCommonFnc.MemSet(ref ybkb1, 0x20, ybkb1.Length);			//           予備区分１       
					UoeCommonFnc.MemSet(ref ybkb2, 0x20, ybkb2.Length);			//           予備区分２       

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
			public TelegramEditOrder1001()
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
					//電文区分
					dn_h.dkb[0] = 0x31;
					
					//処理区分
					dn_h.sykb[0] = 0x30;

					//端末側コード
					UoeCommonFnc.MemCopy(ref dn_h.tcd, uOESupplier.UOETerminalCd, dn_h.tcd.Length);

					//電文問合せ番号
                    UoeCommonFnc.MemCopy(ref dn_h.dtno, String.Format("{0:D6}", (Int32)dr[OrderSndRcvJnlSchema.ct_Col_UOESalesOrderNo]), dn_h.dtno.Length);
					
					//リマーク
					UoeCommonFnc.MemCopy(ref dn_h.rem, (string)dr[OrderSndRcvJnlSchema.ct_Col_UoeRemark1], dn_h.rem.Length);

					//納品区分
                    UoeCommonFnc.MemCopy(ref dn_h.nhkb, (string)dr[OrderSndRcvJnlSchema.ct_Col_UOEDeliGoodsDiv], dn_h.nhkb.Length);

					//指定拠点					
					UoeCommonFnc.MemCopy(ref dn_h.kyo, (string)dr[OrderSndRcvJnlSchema.ct_Col_UOEResvdSection], dn_h.kyo.Length);

					//予備区分１
					dn_h.ybkb1[0] = 0x20;

					//予備区分２
					dn_h.ybkb2[0] = 0x20;
				}

				//送信部品数
                UoeCommonFnc.MemCopy(ref dn_h.sbsu, String.Format("{0,1}", _ln + 1), 1);

				# region ＜明細部＞
				//＜明細部＞
				if (_ln < ctDetailLen)
				{
					//品番
					UoeCommonFnc.MemCopy(ref dn_h.ln_h[_ln].hb, (string)dr[OrderSndRcvJnlSchema.ct_Col_GoodsNo], dn_h.ln_h[_ln].hb.Length);

					//メーカーコード
                    UoeCommonFnc.MemCopy(ref  dn_h.ln_h[_ln].mkcd, String.Format("{0:D4}", (int)dr[OrderSndRcvJnlSchema.ct_Col_GoodsMakerCd]), 4);
			
					//分類コード
					UoeCommonFnc.MemSet(ref dn_h.ln_h[_ln].bncd, 0x20, dn_h.ln_h[_ln].bncd.Length);
					
					//数量
					double hsuDouble = (double)dr[OrderSndRcvJnlSchema.ct_Col_AcceptAnOrderCnt];
                    UoeCommonFnc.MemCopy(ref dn_h.ln_h[_ln].hsu, String.Format("{0:D3}", (int)hsuDouble), dn_h.ln_h[_ln].hsu.Length);
					
					//Ｂ／Ｏコード
					UoeCommonFnc.MemCopy(ref dn_h.ln_h[_ln].bo, (string)dr[OrderSndRcvJnlSchema.ct_Col_BoCode], dn_h.ln_h[_ln].bo.Length);

					//予備コード
					UoeCommonFnc.MemSet(ref dn_h.ln_h[_ln].ybc, 0x20, dn_h.ln_h[_ln].ybc.Length);

					//チェックコード
                    string warehouseCode = (string)dr[OrderSndRcvJnlSchema.ct_Col_WarehouseCode];       //倉庫
                    string warehouseShelfNo = (string)dr[OrderSndRcvJnlSchema.ct_Col_WarehouseShelfNo]; //棚番
                    string chkcdString = "";

                    switch( uOESupplier.CheckCodeDiv )
					{
                        // 0:倉庫(4)+棚番(6)
                        case 0:
                            chkcdString = UoeCommonFnc.GetSubstring(warehouseCode, 0, 4)
                                        + UoeCommonFnc.GetSubstring(warehouseShelfNo, 0, 6);
                            UoeCommonFnc.MemCopy(ref dn_h.ln_h[_ln].chkcd, chkcdString, 10);
							 break;
                        // 1:倉庫(2)+棚番(8)
                        case 1:
                            chkcdString = UoeCommonFnc.GetSubstring(warehouseCode, 0, 2)
                                        + UoeCommonFnc.GetSubstring(warehouseShelfNo, 0, 6);
                            UoeCommonFnc.MemCopy(ref dn_h.ln_h[_ln].chkcd, chkcdString, 10);
						    break;
					    // 2:棚番のみ
						case 2:
                            chkcdString = warehouseShelfNo;
                            UoeCommonFnc.MemCopy(ref dn_h.ln_h[_ln].chkcd, chkcdString, 8);
							break;
					}

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
			/// <returns>バイト型配列</returns>
			public byte[] ToByteArray()
			{
				MemoryStream ms = new MemoryStream();

				ms.Write(dn_h.dkb, 0, dn_h.dkb.Length);				// ﾍｯﾀﾞ      電文区分         
				ms.Write(dn_h.sykb, 0, dn_h.sykb.Length);			//           処理区分         
				ms.Write(dn_h.tcd, 0, dn_h.tcd.Length);				//           端末側コード     
				ms.Write(dn_h.dtno, 0, dn_h.dtno.Length);			//           電文問合せ番号   
				ms.Write(dn_h.sbsu, 0, dn_h.sbsu.Length);			//           送信部品数       
				ms.Write(dn_h.rem, 0, dn_h.rem.Length);				//           ﾘﾏｰｸ	          
				ms.Write(dn_h.nhkb, 0, dn_h.nhkb.Length);			//           納品区分         
				ms.Write(dn_h.kyo, 0, dn_h.kyo.Length);				//           指定拠点         
				ms.Write(dn_h.ybkb1, 0, dn_h.ybkb1.Length);			//           予備区分１       
				ms.Write(dn_h.ybkb2, 0, dn_h.ybkb2.Length);			//           予備区分２       

				//明細部
				for (int i = 0; i < ctBufLen; i++)
				{
					ms.Write(dn_h.ln_h[i].hb, 0, dn_h.ln_h[i].hb.Length);				// ﾗｲﾝ      品番              
					ms.Write(dn_h.ln_h[i].mkcd, 0, dn_h.ln_h[i].mkcd.Length);			//          ﾒｰｶｰｺｰﾄﾞ          
					ms.Write(dn_h.ln_h[i].bncd, 0, dn_h.ln_h[i].bncd.Length);			//          分類ｺｰﾄﾞ          
					ms.Write(dn_h.ln_h[i].hsu, 0, dn_h.ln_h[i].hsu.Length);				//          数量              
					ms.Write(dn_h.ln_h[i].bo, 0, dn_h.ln_h[i].bo.Length);				//          B/Oｺｰﾄﾞ           
					ms.Write(dn_h.ln_h[i].ybc, 0, dn_h.ln_h[i].ybc.Length);				//          予備ｺｰﾄﾞ          
					ms.Write(dn_h.ln_h[i].chkcd, 0, dn_h.ln_h[i].chkcd.Length);			//          ﾁｪｯｸｺｰﾄﾞ          
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

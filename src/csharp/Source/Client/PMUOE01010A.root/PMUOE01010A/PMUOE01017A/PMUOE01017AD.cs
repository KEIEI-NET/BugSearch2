//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : ＵＯＥ送信編集＜在庫＞（優良）アクセスクラス
// プログラム概要   : ＵＯＥ送信編集＜在庫＞（優良）アクセスを行う
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
	/// ＵＯＥ送信編集＜在庫＞（優良）アクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : ＵＯＥ送信編集＜在庫＞（優良）アクセスクラス</br>
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

		# region ＵＯＥ送信編集＜在庫＞（優良）
		/// <summary>
		/// ＵＯＥ送信編集＜在庫＞（優良）
		/// </summary>
		/// <param name="_uoeSndEditRst"></param>
		/// <param name="message"></param>
		/// <returns></returns>
		private int writeUOESNDEditAlloc1001(out List<UoeSndDtl> list, out string message)
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
				TelegramEditAlloc1001 telegramEditAlloc1001 = new TelegramEditAlloc1001();
                telegramEditAlloc1001.uOESupplier = uOESupplier;
				telegramEditAlloc1001.Seq = 1;

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

				//＜在庫電文作成＞
				for (int i = 0; i < maxCount; i++)
				{
                    DataRow dr = StockView[i].Row;

					//電文生成領域にデータが存在
					//発注番号が変更された
					if ((headerSet != 0)
					&& (uoeSndDtl.UOESalesOrderNo != (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOESalesOrderNo]))
					{
						uoeSndDtl.SndTelegram = telegramEditAlloc1001.ToByteArray();
                        uoeSndDtl.SndTelegramLen = telegramEditAlloc1001.SndTelegramLen;
                        _list.Add(uoeSndDtl);
						headerSet = 0;
						telegramEditAlloc1001.Seq += 1;
					}
					//＜ヘッダー部設定処理＞
					if (headerSet == 0)
					{
						headerSet = 1;

						//電文明細クラスのクリア
						telegramEditAlloc1001.Clear();

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
					telegramEditAlloc1001.Telegram(dr);
				}
				//電文生成領域にデータが存在
				if (headerSet != 0)
				{
					uoeSndDtl.SndTelegram = telegramEditAlloc1001.ToByteArray();
                    uoeSndDtl.SndTelegramLen = telegramEditAlloc1001.SndTelegramLen;
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
			}


			return status;
		}
		# endregion

		# region ＵＯＥ送信電文作成＜在庫＞（優良）
		/// <summary>
		/// ＵＯＥ送信電文作成＜在庫＞（優良）
		/// </summary>
		public class TelegramEditAlloc1001
		{
			# region ＰＭ７ソース
			//									//-- 電文領域...ﾗｲﾝ...在確 --
			//struct	LN_Z {						// 43ﾊﾞｲﾄ                     
			//	char	hb[20];					// ﾗｲﾝ      品番              
			//	char	mkcd[4];				//          ﾒｰｶｰｺｰﾄﾞ          
			//	char	bncd[4];				//          分類ｺｰﾄﾞ          
			//	char	hsu[3];					//          数量              
			//	char	bo[1];					//          B/Oｺｰﾄﾞ           
			//	char	ybc[1];					//          予備ｺｰﾄﾞ          
			//	char	chkcd[10];				//          ﾁｪｯｸｺｰﾄﾞ          
			//};
			//
			//									//-- 電文領域...本体...在確 --
			//struct	DN_Z {						// 43 +860 +1156 = 2048ﾊﾞｲﾄ   
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
			//	struct	LN_Z	ln_z[20];		// ﾗｲﾝ       43*20=860ﾊﾞｲﾄ    
			//	char	dummy[1156];			// ﾗｲﾝ       dummy            
			//};
			# endregion

			# region 電文領域クラス
			/// <summary>
			/// 在庫電文領域＜ライン＞
			/// </summary>
			private class LN_Z
			{
				public byte[] hb = new byte[20];		// ﾗｲﾝ      品番              
				public byte[] mkcd = new byte[4];		//          ﾒｰｶｰｺｰﾄﾞ          
				public byte[] bncd = new byte[4];		//          分類ｺｰﾄﾞ          
				public byte[] hsu = new byte[3];		//          数量              
				public byte[] bo = new byte[1];			//          B/Oｺｰﾄﾞ           
				public byte[] ybc = new byte[1];		//          予備ｺｰﾄﾞ          
				public byte[] chkcd = new byte[10];		//          ﾁｪｯｸｺｰﾄﾞ          

				public LN_Z()
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
			/// 在庫電文領域＜本体＞
			/// </summary>
			private class DN_Z
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
				public LN_Z[] ln_z = new LN_Z[20];		// ﾗｲﾝ       43*20=860ﾊﾞｲﾄ    
				public byte[] dummy = new byte[1156];	// ﾗｲﾝ       dummy            
	
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
            //private const Int32 ctSndTelegramLen = 247; //送信電文サイズ
            private const Int32 ctSndTelegramLen = 256; //送信電文サイズ
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
			public TelegramEditAlloc1001()
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
					//電文区分
					dn_z.dkb[0] = 0x34;

					//処理区分
					dn_z.sykb[0] = 0x30;

					//端末側コード
					UoeCommonFnc.MemCopy(ref dn_z.tcd, uOESupplier.UOETerminalCd, dn_z.tcd.Length);

					//電文問合せ番号
                    UoeCommonFnc.MemCopy(ref dn_z.dtno, String.Format("{0:D6}", (Int32)dr[StockSndRcvJnlSchema.ct_Col_UOESalesOrderNo]), dn_z.dtno.Length);

					//リマーク
					UoeCommonFnc.MemCopy(ref dn_z.rem, (string)dr[StockSndRcvJnlSchema.ct_Col_UoeRemark1], dn_z.rem.Length);

					//納品区分
					dn_z.nhkb[0] = 0x20;

					//指定拠点					
					UoeCommonFnc.MemSet(ref dn_z.kyo, 0x20, dn_z.kyo.Length);

					//予備区分１
					dn_z.ybkb1[0] = 0x20;

					//予備区分２
					dn_z.ybkb2[0] = 0x20;
				}

				//送信部品数
                UoeCommonFnc.MemCopy(ref dn_z.sbsu, String.Format("{0:D1}", _ln + 1), 1);

				# region ＜明細部＞
				//＜明細部＞
				if (_ln < ctDetailLen)
				{
					//品番
					UoeCommonFnc.MemCopy(ref dn_z.ln_z[_ln].hb, (string)dr[StockSndRcvJnlSchema.ct_Col_GoodsNo], dn_z.ln_z[_ln].hb.Length);

					//メーカーコード
                    UoeCommonFnc.MemCopy(ref  dn_z.ln_z[_ln].mkcd, String.Format("{0:D4}", (int)dr[StockSndRcvJnlSchema.ct_Col_GoodsMakerCd]), 4);

					//分類コード
					UoeCommonFnc.MemSet(ref dn_z.ln_z[_ln].bncd, 0x20, dn_z.ln_z[_ln].bncd.Length);

					//数量
					double hsuDouble = (double)dr[StockSndRcvJnlSchema.ct_Col_AcceptAnOrderCnt];
                    UoeCommonFnc.MemCopy(ref dn_z.ln_z[_ln].hsu, String.Format("{0:D3}", (int)hsuDouble), dn_z.ln_z[_ln].hsu.Length);

					//Ｂ／Ｏコード
					UoeCommonFnc.MemSet(ref dn_z.ln_z[_ln].bo, 0x20, dn_z.ln_z[_ln].bo.Length);

					//予備コード
					UoeCommonFnc.MemSet(ref dn_z.ln_z[_ln].ybc, 0x20, dn_z.ln_z[_ln].ybc.Length);

					//チェックコード
					UoeCommonFnc.MemSet(ref dn_z.ln_z[_ln].chkcd, 0x20, dn_z.ln_z[_ln].chkcd.Length);

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

				ms.Write(dn_z.dkb, 0, dn_z.dkb.Length);				// ﾍｯﾀﾞ      電文区分         
				ms.Write(dn_z.sykb, 0, dn_z.sykb.Length);			//           処理区分         
				ms.Write(dn_z.tcd, 0, dn_z.tcd.Length);				//           端末側コード     
				ms.Write(dn_z.dtno, 0, dn_z.dtno.Length);			//           電文問合せ番号   
				ms.Write(dn_z.sbsu, 0, dn_z.sbsu.Length);			//           送信部品数       
				ms.Write(dn_z.rem, 0, dn_z.rem.Length);				//           ﾘﾏｰｸ	          
				ms.Write(dn_z.nhkb, 0, dn_z.nhkb.Length);			//           納品区分         
				ms.Write(dn_z.kyo, 0, dn_z.kyo.Length);				//           指定拠点         
				ms.Write(dn_z.ybkb1, 0, dn_z.ybkb1.Length);			//           予備区分１       
				ms.Write(dn_z.ybkb2, 0, dn_z.ybkb2.Length);			//           予備区分２       

				//明細部
				for (int i = 0; i < ctBufLen; i++)
				{
					ms.Write(dn_z.ln_z[i].hb, 0, dn_z.ln_z[i].hb.Length);				// ﾗｲﾝ      品番              
					ms.Write(dn_z.ln_z[i].mkcd, 0, dn_z.ln_z[i].mkcd.Length);			//          ﾒｰｶｰｺｰﾄﾞ          
					ms.Write(dn_z.ln_z[i].bncd, 0, dn_z.ln_z[i].bncd.Length);			//          分類ｺｰﾄﾞ          
					ms.Write(dn_z.ln_z[i].hsu, 0, dn_z.ln_z[i].hsu.Length);				//          数量              
					ms.Write(dn_z.ln_z[i].bo, 0, dn_z.ln_z[i].bo.Length);				//          B/Oｺｰﾄﾞ           
					ms.Write(dn_z.ln_z[i].ybc, 0, dn_z.ln_z[i].ybc.Length);				//          予備ｺｰﾄﾞ          
					ms.Write(dn_z.ln_z[i].chkcd, 0, dn_z.ln_z[i].chkcd.Length);			//          ﾁｪｯｸｺｰﾄﾞ          
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

//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : ＵＯＥ受信編集＜在庫＞（三菱）アクセスクラス
// プログラム概要   : ＵＯＥ受信編集＜在庫＞（三菱）を行う
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
using System.IO;
using System.Runtime.InteropServices;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// ＵＯＥ受信編集＜在庫＞（三菱）アクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : ＵＯＥ受信編集＜在庫＞（三菱）アクセスクラス</br>
	/// <br>Programmer : 96186 立花裕輔</br>
	/// <br>Date       : 2008.05.26</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// <br>2008.05.26 men 新規作成</br>
	/// </remarks>
	public partial class UoeRecEdit0301Acs
	{
		// ===================================================================================== //
		// プライベートメソッド
		// ===================================================================================== //
		# region Private Methods

		# region ＵＯＥ受信編集＜在庫＞（三菱）
		/// <summary>
		/// ＵＯＥ受信編集＜在庫＞（三菱）
		/// </summary>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        private int GetJnlStock0301(out string message)
		{
			//変数の初期化
			int status = (int)EnumUoeConst.Status.ct_NORMAL;
			message = "";

			try
			{
                //-----------------------------------------------------------
                // ＪＮＬ更新処理
                //-----------------------------------------------------------
                if (uoeRecHed != null)
                {
                    TelegramJnlStock0301 telegramJnlStock0301 = new TelegramJnlStock0301();

                    //ＪＮＬ更新処理
                    foreach (UoeRecDtl dtl in uoeRecDtlList)
                    {
                        telegramJnlStock0301.Telegram(_uoeRecHed.UOESupplierCd, dtl);
                    }
                }

                //-----------------------------------------------------------
                // 送受信ＪＮＬ＜送信フラグ・復旧フラグ＞の更新
                //   送信フラグ (更新前)1:処理中 → (更新後)2:送信エラー
                //   復旧フラグ (更新前)0:未処理 → (更新後)1:復旧対象
                //-----------------------------------------------------------
                _uoeSndRcvJnlAcs.JnlOrderTblFlgUpdt(_uoeSndHed.UOESupplierCd,
                    (int)EnumUoeConst.ctDataSendCode.ct_Process,		//1:処理中
                    (int)EnumUoeConst.ctDataRecoverDiv.ct_NonProcess,	//0:未処理
                    (int)EnumUoeConst.ctDataSendCode.ct_SndNG,			//2:送信エラー
                    (int)EnumUoeConst.ctDataRecoverDiv.ct_YES);			//9:復旧対象
            }
			catch (Exception ex)
			{
				status = -1;
				message = ex.Message;
			}
			return (status);
		}
		# endregion

		# region ＵＯＥ受信電文作成＜在庫＞（三菱）
		/// <summary>
		/// ＵＯＥ受信電文作成＜在庫＞（三菱）
		/// </summary>
		public class TelegramJnlStock0301 : UoeRecEdit0301Acs
		{
			# region ＰＭ７ソース
			//ヘッダー部
			//struct	HEAD{
			//	char	jkbn[1] ;					/* 情報区分						*/
			//	short	seq_no ;					/* テキストシーケンス番号		*/
			//	short	text_len ;					/* テキスト長					*/
			//	char	dkbn[1] ;					/* 電文区分						*/
			//	char	kekka[1] ;					/* 処理結果						*/
			//	char	tokbn[1] ;					/* 問合せ／応答区分				*/
			//	char	g_id[12] ;					/* 業務ＩＤ						*/
			//	char	g_pass[6] ;					/* 業務パスワード				*/
			//	char	prog_ver[3] ;				/* 端末プログラムバージョン番号	*/
			//	char	kkbn[1] ;					/* 継続区分						*/
			//	char	h_id[3] ;					/* 取引ＩＤ						*/
			//	char	ext[15] ;					/* 拡張エリア					*/
			//	char	gsk[1] ;					/* 業務処理結果					*/
			//	char	gsf[1] ;					/* 業務継続フラグ				*/
			//	char	seq[3] ;					/* シーケンスＮＯ				*/
			//	char	bymd[4] ;					/* 端末入力日付・時間			*/
			//	char	ymdhms[8] ;					/* ホスト日付・時間				*/
			//};
			//
			//struct	ZAIKO{
			//	struct	HEAD	head ;
			//	char	syamei[20] ;				/* 会社名						*/
			//	struct	ZKYO	zkyo[31] ;			/* 拠点名						*/
			//	struct	ZDATA	zdata[6] ;			/* ライン項目１～６				*/
			//};
			//
			//struct	ZKYO{
			//	char	kyo[6] ;					/* 拠点名						*/
			//};
			
			//明細部
			//struct	ZDATA{
			//	char	khb[10] ;					/* 部品番号						*/
			//	char	knm[20] ;					/* 品名							*/
			//	char	lp[7] ;						/* Ｌ／Ｐ						*/
			//	char	zsu00[5] ;					/* 本庫在庫数					*/
			//	char	gokan1[1] ;					/* 代替区分						*/
			//	char	newhb[10] ;					/* 新部品番号					*/
			//	struct	ZKSU	zksu[31] ;			/* 拠点在庫数					*/
			//	char	lemsg[10] ;					/* エラーメッセージ				*/
			//};
			//
			//struct	ZKSU{
			//	char	zsu[3] ;					/* 拠点在庫数					*/
			//};
			# endregion

			# region Const Members
			private const Int32 ctBufLen = 6;		//明細バッファサイズ
			private DN_Z dn_z = new DN_Z();
			# endregion

			# region Private Members
			//変数
			private Int32 _detailMax = 0;
			private DN_Z dn_m = new DN_Z(); 
			# endregion

			# region 電文領域クラス
			/// <summary>
			/// 在庫電文領域＜ライン＞
			/// </summary>
			private class LN_Z
			{
				public byte[]	khb = new byte[10] ;					// 部品番号						
				public byte[]	knm = new byte[20] ;					// 品名							
				public byte[]	lp = new byte[7] ;						// Ｌ／Ｐ						
				public byte[]	zsu00 = new byte[5] ;					// 本庫在庫数					
				public byte[]	gokan1 = new byte[1] ;					// 代替区分						
				public byte[]	newhb = new byte[10] ;					// 新部品番号					
				public byte[][]	zsu = new byte[31][] ;					// 拠点在庫数					
				public byte[]	lemsg = new byte[10] ;					// エラーメッセージ				

				public LN_Z()
				{
					for (int j = 0; j < 31; j++)
					{
						zsu[j] = new byte[3];					//          拠点在庫数02-32   
					}
					Clear(0x00);
				}
				public void Clear(byte cd)
				{
					UoeCommonFnc.MemSet(ref khb, cd, khb.Length);				// 部品番号						
					UoeCommonFnc.MemSet(ref knm, cd, knm.Length);				// 品名							
					UoeCommonFnc.MemSet(ref lp, cd, lp.Length);					// Ｌ／Ｐ						
					UoeCommonFnc.MemSet(ref zsu00, cd, zsu00.Length);			// 本庫在庫数					
					UoeCommonFnc.MemSet(ref gokan1, cd, gokan1.Length);			// 代替区分						
					UoeCommonFnc.MemSet(ref newhb, cd, newhb.Length);			// 新部品番号					
					UoeCommonFnc.MemSet(ref lemsg, cd, lemsg.Length);			// エラーメッセージ				

					for (int j = 0; j < 31; j++)
					{
						UoeCommonFnc.MemSet(ref zsu[j], cd, zsu[j].Length);	//拠点在庫数   
					}
				}
			}

			/// <summary>
			/// 在庫電文領域＜本体＞
			/// </summary>
			private class DN_Z
			{
				public byte[]	jkbn = new byte[1] ;					// 情報区分						
				public byte[]	seq_no = new byte[2] ;					// テキストシーケンス番号		
				public byte[]	text_len = new byte[2] ;				// テキスト長					
				public byte[]	dkbn = new byte[1] ;					// 電文区分						
				public byte[]	kekka = new byte[1] ;					// 処理結果						
				public byte[]	tokbn = new byte[1] ;					// 問合せ／応答区分				
				public byte[]	g_id = new byte[12] ;					// 業務ＩＤ						
				public byte[]	g_pass = new byte[6] ;					// 業務パスワード				
				public byte[]	prog_ver = new byte[3] ;				// 端末プログラムバージョン番号	
				public byte[]	kkbn = new byte[1] ;					// 継続区分						
				public byte[]	h_id = new byte[3] ;					// 取引ＩＤ						
				public byte[]	ext = new byte[15] ;					// 拡張エリア					
				public byte[]	gsk = new byte[1] ;						// 業務処理結果					
				public byte[]	gsf = new byte[1] ;						// 業務継続フラグ				
				public byte[]	seq = new byte[3] ;						// シーケンスＮＯ				
				public byte[]	bymd = new byte[4] ;					// 端末入力日付・時間			
				public byte[]	ymdhms = new byte[8] ;					// ホスト日付・時間				
				public byte[]	syamei = new byte[20] ;					// 会社名						
				public byte[][]	kyo = new byte[31][];					// 拠点名

				public LN_Z[] ln_z = new LN_Z[ctBufLen];// ﾗｲﾝ

				/// <summary>	
				/// コンストラクター
				/// </summary>
				public DN_Z()
				{
					for (int j = 0; j < 31; j++)
					{
						kyo[j] = new byte[6];							// 拠点名   
					}
					Clear(0x00);
				}

				public void Clear(byte cd)
				{
					UoeCommonFnc.MemSet(ref jkbn, cd, jkbn.Length);				// 情報区分						
					UoeCommonFnc.MemSet(ref seq_no, cd, seq_no.Length);			// テキストシーケンス番号		
					UoeCommonFnc.MemSet(ref text_len, cd, text_len.Length);		// テキスト長					
					UoeCommonFnc.MemSet(ref dkbn, cd, dkbn.Length);				// 電文区分						
					UoeCommonFnc.MemSet(ref kekka, cd, kekka.Length);			// 処理結果						
					UoeCommonFnc.MemSet(ref tokbn, cd, tokbn.Length);			// 問合せ／応答区分				
					UoeCommonFnc.MemSet(ref g_id, cd, g_id.Length);				// 業務ＩＤ						
					UoeCommonFnc.MemSet(ref g_pass, cd, g_pass.Length);			// 業務パスワード				
					UoeCommonFnc.MemSet(ref prog_ver, cd, prog_ver.Length);		// 端末プログラムバージョン番号	
					UoeCommonFnc.MemSet(ref kkbn, cd, kkbn.Length);				// 継続区分						
					UoeCommonFnc.MemSet(ref h_id, cd, h_id.Length);				// 取引ＩＤ						
					UoeCommonFnc.MemSet(ref ext, cd, ext.Length);				// 拡張エリア					
					UoeCommonFnc.MemSet(ref gsk, cd, gsk.Length);				// 業務処理結果					
					UoeCommonFnc.MemSet(ref gsf, cd, gsf.Length);				// 業務継続フラグ				
					UoeCommonFnc.MemSet(ref seq, cd, seq.Length);				// シーケンスＮＯ				
					UoeCommonFnc.MemSet(ref bymd, cd, bymd.Length);				// 端末入力日付・時間			
					UoeCommonFnc.MemSet(ref ymdhms, cd, ymdhms.Length);			// ホスト日付・時間				
					UoeCommonFnc.MemSet(ref syamei, cd, syamei.Length);			// 会社名						

					for (int j = 0; j < 31; j++)
					{
						UoeCommonFnc.MemSet(ref kyo[j], cd, kyo[j].Length);		// 拠点名  
					}

					//明細部
					for (int i = 0; i < ctBufLen; i++)
					{
                        if (ln_z[i] == null)
                        {
                            ln_z[i] = new LN_Z();
                        }
                        else
                        {
                            ln_z[i].Clear(0x00);
                        }
                    }
				}
			}
			# endregion

			# region Constructors
			/// <summary>
			/// コンストラクタ
			/// </summary>
			public TelegramJnlStock0301()
			{
				Clear(0x00);
			}
			# endregion

			# region Properties
			# region 明細行数
			public Int32 detailMax
			{
				get
				{
					return this._detailMax;
				}
				set
				{
					this._detailMax = value;
				}
			}
			# endregion
			# endregion

			# region Public Methods
			# region データ初期化処理
			/// <summary>
			/// データ初期化処理
			/// </summary>
			public void Clear(byte cd)
			{
				_detailMax = 0;
				dn_z.Clear(0x00);
			}
			# endregion

			# region データ編集処理
			/// <summary>
			/// データ編集処理
			/// </summary>
			/// <param name="dtl"></param>
			/// <param name="jnl"></param>
			public void Telegram(Int32 uOESupplierCd, UoeRecDtl dtl)
			{
                //開局・閉局電文のスキップ処理
                if ((dtl.UOESalesOrderNo == 0) && (dtl.UOESalesOrderRowNo.Count == 0)) return;

                //バイト型配列に変換
				FromByteArray(dtl.RecTelegram);

				//電文の行数取得
				_detailMax = dtl.UOESalesOrderRowNo.Count;

				for (int i = 0; i < _detailMax; i++)
				{
					//取得＜送受信JNL-DATATABLE→送受信JNL-CLASS＞
					DataRow dataRow = _uoeSndRcvJnlAcs.JnlStockTblRead(
													uOESupplierCd,
													dtl.UOESalesOrderNo,
													dtl.UOESalesOrderRowNo[i]);
					if (dataRow == null)
					{
						continue;
					}

					//データ送信区分
                    dataRow[StockSndRcvJnlSchema.ct_Col_DataSendCode] = dtl.DataSendCode;

					//データ復旧区分
					dataRow[StockSndRcvJnlSchema.ct_Col_DataRecoverDiv] = dtl.DataRecoverDiv;


					//受信日付(YYYYMMDD)
					int int32Yymmdd = UoeCommonFnc.atobs(dn_z.ymdhms, 0, 4) * 100;

					//電文自体にに日付がセットされている
					if (int32Yymmdd != 0)
					{
						int lwk = TDateTime.DateTimeToLongDate(DateTime.Now);		//yyyymmdd
						lwk /= 1000000;	// yy
						lwk *= 1000000;	// yy000000

						dataRow[StockSndRcvJnlSchema.ct_Col_ReceiveDate] = TDateTime.LongDateToDateTime(int32Yymmdd + lwk);
					}
					//電文自体にに日付がセットされていない
					else
					{
						dataRow[StockSndRcvJnlSchema.ct_Col_ReceiveDate] = DateTime.Now;
					}

					//受信時刻(HHMM)
					dataRow[StockSndRcvJnlSchema.ct_Col_ReceiveTime] = UoeCommonFnc.atobs(dn_z.ymdhms, 4, 4) * 100;

					//回答電文エラー処理
					if (dn_z.kekka[0] == 0x99)
					{
						string errMessage = GetHeadErrorMassage(dn_z.kekka[0]);

						//ヘッドエラーメッセージ
						dataRow[StockSndRcvJnlSchema.ct_Col_HeadErrorMassage] = errMessage;

						//品名
						dataRow[StockSndRcvJnlSchema.ct_Col_AnswerPartsName] = errMessage;

						continue;
					}

					//代替有無チェック＆セット
					int sw = 0;	//0:代替なし 1:代替あり

					//代替ﾏｰｸ
					//代替あり
					if ((dn_z.ln_z[i].gokan1[0] != 0x00)
					&& (dn_z.ln_z[i].gokan1[0] != 0x20)
					&& (dn_z.ln_z[i].gokan1[0] != 0x30))
					{
                        dataRow[StockSndRcvJnlSchema.ct_Col_UOESubstCode] = UoeCommonFnc.ToStringFromByteStrAry(dn_z.ln_z[i].gokan1);
						sw = 1;
					}
					else
					{
						string goodsNoString = (string)dataRow[StockSndRcvJnlSchema.ct_Col_GoodsNo];
						string khbString = UoeCommonFnc.ToStringFromByteStrAry(dn_z.ln_z[i].khb);

						//代替あり
                        if (goodsNoString.Trim() != khbString.Trim())
						{
							dataRow[StockSndRcvJnlSchema.ct_Col_UOESubstCode] = "01";
							sw = 1;
						}
						//代替なし
						else
						{
							dataRow[StockSndRcvJnlSchema.ct_Col_UOESubstCode] = "";
							sw = 0;
						}
					}

					//代替なし
					if (sw == 0)
					{
						//回答品番
						dataRow[StockSndRcvJnlSchema.ct_Col_AnswerPartsNo] = UoeCommonFnc.ToStringFromByteStrAry(dn_z.ln_z[i].khb);

						//回答品名
						dataRow[StockSndRcvJnlSchema.ct_Col_AnswerPartsName] = UoeCommonFnc.ToStringFromByteStrAry(dn_z.ln_z[i].knm);
					}
					//代替あり
					else
					{
						//代替品番
                        dataRow[StockSndRcvJnlSchema.ct_Col_SubstPartsNo] = UoeCommonFnc.ToStringFromByteStrAry(dn_z.ln_z[i].newhb);

						//回答品番
						dataRow[StockSndRcvJnlSchema.ct_Col_AnswerPartsNo] = UoeCommonFnc.ToStringFromByteStrAry(dn_z.ln_z[i].khb);

						//回答品名
						dataRow[StockSndRcvJnlSchema.ct_Col_AnswerPartsName] = UoeCommonFnc.ToStringFromByteStrAry(dn_z.ln_z[i].knm);
					}

					// 定価(Ｌ／Ｐ)
                    dataRow[StockSndRcvJnlSchema.ct_Col_AnswerListPrice] = UoeCommonFnc.ToDoubleFromByteStrAry(dn_z.ln_z[i].lp);

					// UOE拠点在庫数１(本庫在庫数)
                    dataRow[StockSndRcvJnlSchema.ct_Col_HeadQtrsStock] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].zsu00);

					// 拠点在庫数(1～31)
                    dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock1] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].zsu[0]);
                    dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock2] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].zsu[1]);

					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock3] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].zsu[2]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock4] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].zsu[3]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock5] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].zsu[4]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock6] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].zsu[5]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock7] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].zsu[6]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock8] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].zsu[7]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock9] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].zsu[8]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock10] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].zsu[9]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock11] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].zsu[10]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock12] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].zsu[11]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock13] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].zsu[12]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock14] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].zsu[13]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock15] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].zsu[14]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock16] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].zsu[15]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock17] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].zsu[16]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock18] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].zsu[17]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock19] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].zsu[18]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock20] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].zsu[19]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock21] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].zsu[20]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock22] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].zsu[21]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock23] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].zsu[22]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock24] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].zsu[23]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock25] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].zsu[24]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock26] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].zsu[25]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock27] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].zsu[26]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock28] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].zsu[27]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock29] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].zsu[28]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock30] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].zsu[29]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock31] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].zsu[30]);

					// エラーメッセージ
					dataRow[StockSndRcvJnlSchema.ct_Col_LineErrorMassage] = UoeCommonFnc.ToStringFromByteStrAry(dn_z.ln_z[i].lemsg);
				}
			}
			# endregion

			# endregion

			# region private Methods

			# region バイト型配列に変換
			/// <summary>
			/// バイト型配列に変換
			/// </summary>
			/// <returns></returns>
			private void FromByteArray(byte[] line)
			{
				_detailMax = 0;
				MemoryStream ms = new MemoryStream();
				ms.Write(line, 0, line.Length);
                ms.Seek(0, SeekOrigin.Begin);

				ms.Read(dn_z.jkbn, 0, dn_z.jkbn.Length);        // 情報区分						
				ms.Read(dn_z.seq_no, 0, dn_z.seq_no.Length);    // テキストシーケンス番号		
				ms.Read(dn_z.text_len, 0, dn_z.text_len.Length);// テキスト長					
				ms.Read(dn_z.dkbn, 0, dn_z.dkbn.Length);        // 電文区分						
				ms.Read(dn_z.kekka, 0, dn_z.kekka.Length);      // 処理結果						
				ms.Read(dn_z.tokbn, 0, dn_z.tokbn.Length);      // 問合せ／応答区分				
				ms.Read(dn_z.g_id, 0, dn_z.g_id.Length);        // 業務ＩＤ						
				ms.Read(dn_z.g_pass, 0, dn_z.g_pass.Length);    // 業務パスワード				
				ms.Read(dn_z.prog_ver, 0, dn_z.prog_ver.Length);// 端末プログラムバージョン番号	
				ms.Read(dn_z.kkbn, 0, dn_z.kkbn.Length);        // 継続区分						
				ms.Read(dn_z.h_id, 0, dn_z.h_id.Length);        // 取引ＩＤ						
				ms.Read(dn_z.ext, 0, dn_z.ext.Length);          // 拡張エリア					
				ms.Read(dn_z.gsk, 0, dn_z.gsk.Length);          // 業務処理結果					
				ms.Read(dn_z.gsf, 0, dn_z.gsf.Length);          // 業務継続フラグ				
				ms.Read(dn_z.seq, 0, dn_z.seq.Length);          // シーケンスＮＯ				
				ms.Read(dn_z.bymd, 0, dn_z.bymd.Length);        // 端末入力日付・時間			
				ms.Read(dn_z.ymdhms, 0, dn_z.ymdhms.Length);    // ホスト日付・時間				
				ms.Read(dn_z.syamei, 0, dn_z.syamei.Length);    // 会社名						

				for (int i = 0; i < dn_z.kyo.Length; i++)
				{
					ms.Read(dn_z.kyo[i], 0, dn_z.kyo[i].Length);// 拠点名
				}

				//明細部
				for (int i = 0; i < ctBufLen; i++)
				{
					ms.Read(dn_z.ln_z[i].khb, 0, dn_z.ln_z[i].khb.Length);      // 部品番号						
					ms.Read(dn_z.ln_z[i].knm, 0, dn_z.ln_z[i].knm.Length);      // 品名							
					ms.Read(dn_z.ln_z[i].lp, 0, dn_z.ln_z[i].lp.Length);        // Ｌ／Ｐ						
					ms.Read(dn_z.ln_z[i].zsu00, 0, dn_z.ln_z[i].zsu00.Length);  // 本庫在庫数					
					ms.Read(dn_z.ln_z[i].gokan1, 0, dn_z.ln_z[i].gokan1.Length);// 代替区分						
					ms.Read(dn_z.ln_z[i].newhb, 0, dn_z.ln_z[i].newhb.Length);  // 新部品番号					

					for (int j = 0; j < 31; j++)
					{
						ms.Read(dn_z.ln_z[i].zsu[j], 0, dn_z.ln_z[i].zsu[j].Length); // 拠点在庫数   
					}
                    ms.Read(dn_z.ln_z[i].lemsg, 0, dn_z.ln_z[i].lemsg.Length);  // エラーメッセージ				
                }

				ms.Close();
			}
			# endregion

			# region ヘッドエラーメッセージの取得
			/// <summary>
			/// ヘッドエラーメッセージの取得
			/// </summary>
			/// <param name="cd"></param>
			/// <returns></returns>
			private string GetHeadErrorMassage(byte cd)
			{
				string str = "";

				switch (cd)
				{
					case 0x99:						//-- "ｿﾉﾀｴﾗｰ" --
					default:
						str = MSG_ELS;
						break;
				}
				return (str);
			}
			# endregion

			# endregion
		}
		# endregion

		# endregion


	}
}

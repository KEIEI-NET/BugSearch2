//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : ＵＯＥ受信編集＜見積＞（新マツダ）アクセスクラス
// プログラム概要   : ＵＯＥ受信編集＜見積＞（新マツダ）を行う
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
	/// ＵＯＥ受信編集＜見積＞（新マツダ）アクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : ＵＯＥ受信編集＜見積＞（新マツダ）アクセスクラス</br>
	/// <br>Programmer : 96186 立花裕輔</br>
	/// <br>Date       : 2008.05.26</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// <br>2008.05.26 men 新規作成</br>
	/// </remarks>
	public partial class UoeRecEdit0402Acs
	{
		// ===================================================================================== //
		// プライベートメソッド
		// ===================================================================================== //

		# region Private Methods

		# region ＵＯＥ受信編集＜見積＞（新マツダ）
		/// <summary>
		/// ＵＯＥ受信編集＜見積＞（新マツダ）
		/// </summary>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        private int GetJnlEstmt0402(out string message)
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
                    TelegramJnlEstmt0402 telegramJnlEstmt0402 = new TelegramJnlEstmt0402();
                    foreach (UoeRecDtl dtl in uoeRecDtlList)
                    {
                        telegramJnlEstmt0402.Telegram(_uoeRecHed.UOESupplierCd, dtl);
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

		# region ＵＯＥ受信電文作成＜見積＞（新マツダ）
		/// <summary>
		/// ＵＯＥ受信電文作成＜見積＞（新マツダ）
		/// </summary>
		public class TelegramJnlEstmt0402 : UoeRecEdit0402Acs
		{
			# region ＰＭ７ソース
			///********************** 回答受信電文 共通部 構造体 **********************/
			//typedef struct	{
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
			//} HEAD ;
			//
			///************************ 見積回答受信電文構造体 ************************/
			//typedef struct	{
			//	char	khb[24] ;					/* 部品番号						*/
			//	char	msu[5] ;					/* 数量							*/
			//	char	knm[20] ;					/* 品名／新部番					*/
			//	char	mtan[7] ;					/* 見積単価						*/
			//	ZAI1	zai2[3] ;					/* 在庫情報	　構造体(1)～(3)	*/
			//	char	tkbn[1] ;					/* 価格建区分					*/
			//	char	gokan[2] ;					/* 互換性コード					*/
			//	char	sktan[7] ;					/* 仕切単価						*/
			//	char	ermsg[8];					/* コメント						*/
			//} MDATA ;
			//
			//typedef struct	{						/* 見積回答電文					*/
			//	HEAD	head ;
			//	char	retok[1] ;					/* レート区分					*/
			//	char	reto[4] ;					/* レートコード					*/
			//	char	senc[1] ;					/* 選択コード					*/
			//	char	remk[10] ;					/* リマーク						*/
			//	char	mimny[9] ;					/* 見積金額合計					*/
			//	char	simny[9] ;					/* 仕切金額合計					*/
			//	MDATA	mdata[10] ;					/* ライン項目１～１０			*/
			//} MITU ;
			//
			///********************** 見積ヘッドエラー電文構造体 **********************/
			//typedef struct	{
			//	HEAD	head ;
			//	char	retok[1] ;					/* レート区分					*/
			//	char	reto[4] ;					/* レートコード					*/
			//	char	senc[1] ;					/* 選択コード					*/
			//	char	remk[10] ;					/* リマーク						*/
			//	char	ermsg[20] ;					/* エラーメッセージ				*/
			//	char	khb[24] ;					/* 部番							*/
			//	char	msu[5] ;					/* 数量							*/
			//} MERR ;
			# endregion

			# region Const Members
			private const Int32 ctBufLen = 10;		//明細バッファサイズ
			# endregion

			# region Private Members
			//変数
			private Int32 _detailMax = 0;
			private MITU mitu = new MITU(); 
			# endregion

			# region 電文領域クラス
			/// <summary>
			/// 見積エラー電文
			/// </summary>
			private class MERR
			{
				public byte[] ermsg = new byte[20];					// エラーメッセージ				
				public byte[] khb = new byte[24];					// 部番							
				public byte[] msu = new byte[5];					// 数量							
		
				public MERR()
				{
					Clear(0x00);
				}

				public void Clear(byte cd)
				{
					UoeCommonFnc.MemSet(ref ermsg, cd, ermsg.Length);	// エラーメッセージ				
					UoeCommonFnc.MemSet(ref khb, cd, khb.Length);		// 部番							
					UoeCommonFnc.MemSet(ref msu, cd, msu.Length);		// 数量							
				}
			}

			/// <summary>
			/// 在庫情報
			/// </summary>
			private class ZAIM
			{
				public byte[] kcd = new byte[2];						// 拠点コード					
				public byte[] zsu = new byte[2];						// 在庫数						

				public ZAIM()
				{
					Clear(0x00);
				}

				public void Clear(byte cd)
				{
					UoeCommonFnc.MemSet(ref kcd, cd, kcd.Length);		// 拠点コード					
					UoeCommonFnc.MemSet(ref zsu, cd, zsu.Length);		// 在庫数						
				}
			}

			/// <summary>
			/// 見積明細
			/// </summary>
			private class MDATA
			{
				public byte[] khb = new byte[24];					// 部品番号						
				public byte[] msu = new byte[5];					// 数量							
				public byte[] knm = new byte[20];					// 品名／新部番					
				public byte[] mtan = new byte[7];					// 見積単価						
				public ZAIM[] zaim = new ZAIM[3];					// 在庫情報	構造体(1)～(3)	
				public byte[] tkbn = new byte[1];					// 価格建区分					
				public byte[] gokan = new byte[2];					// 互換性コード					
				public byte[] sktan = new byte[7];					// 仕切単価						
				public byte[] ermsg = new byte[8];					// コメント						

				public MDATA()
				{
					Clear(0x00);
				}

				public void Clear(byte cd)
				{
					UoeCommonFnc.MemSet(ref khb, cd, khb.Length);		// 部品番号						
					UoeCommonFnc.MemSet(ref msu, cd, msu.Length);		// 数量							
					UoeCommonFnc.MemSet(ref knm, cd, knm.Length);		// 品名／新部番					
					UoeCommonFnc.MemSet(ref mtan, cd, mtan.Length);		// 見積単価						

					for(int i=0;i<zaim.Length; i++)
					{
                        if (zaim[i] == null)
                        {
                            zaim[i] = new ZAIM();
                        }
                        else
                        {
                            zaim[i].Clear(0x00);
                        }
					}

					UoeCommonFnc.MemSet(ref tkbn, cd, tkbn.Length);		// 価格建区分					
					UoeCommonFnc.MemSet(ref gokan, cd, gokan.Length);	// 互換性コード					
					UoeCommonFnc.MemSet(ref sktan, cd, sktan.Length);	// 仕切単価						
					UoeCommonFnc.MemSet(ref ermsg, cd, ermsg.Length);	// コメント						
				}
			}

			/// <summary>
			/// 見積明細
			/// </summary>
			private class MITU2
			{
				public byte[] mimny = new byte[9];						// 見積金額合計					
				public byte[] simny = new byte[9];						// 仕切金額合計					
				public MDATA[] mdata = new MDATA[10];					// ライン項目１～１０			

				public MITU2()
				{
					Clear(0x00);
				}

				public void Clear(byte cd)
				{
					UoeCommonFnc.MemSet(ref mimny, cd, mimny.Length);	// 見積金額合計					
					UoeCommonFnc.MemSet(ref simny, cd, simny.Length);	// 仕切金額合計
				
					for(int i=0;i<mdata.Length; i++)
					{
                        if (mdata[i] == null)
                        {
                            mdata[i] = new MDATA();
                        }
                        else
                        {
                            mdata[i].Clear(0x00);
                        }
                    }
				}
			}


			/// <summary>
			/// 見積ヘッダー
			/// </summary>
			private class MITU
			{
				public byte[] jkbn = new byte[1];					// 情報区分						
				public byte[] seq_no = new byte[2];					// テキストシーケンス番号		
				public byte[] text_len = new byte[2];				// テキスト長					
				public byte[] dkbn = new byte[1];					// 電文区分						
				public byte[] kekka = new byte[1];					// 処理結果						
				public byte[] tokbn = new byte[1];					// 問合せ／応答区分				
				public byte[] g_id = new byte[12];					// 業務ＩＤ						
				public byte[] g_pass = new byte[6];					// 業務パスワード				
				public byte[] prog_ver = new byte[3];				// 端末プログラムバージョン番号	
				public byte[] kkbn = new byte[1];					// 継続区分						
				public byte[] h_id = new byte[3];					// 取引ＩＤ						
				public byte[] ext = new byte[15];					// 拡張エリア					
				public byte[] gsk = new byte[1];					// 業務処理結果					
				public byte[] gsf = new byte[1];					// 業務継続フラグ				
				public byte[] seq = new byte[3];					// シーケンスＮＯ				
				public byte[] bymd = new byte[4];					// 端末入力日付・時間			
				public byte[] ymdhms = new byte[8];					// ホスト日付・時間				

				public byte[] retok = new byte[1];					// レート区分					
				public byte[] reto = new byte[4];					// レートコード					
				public byte[] senc = new byte[1];					// 選択コード					
				public byte[] remk = new byte[10];					// リマーク						

				public MITU2 mitu2 = new MITU2();					//見積項目
				public MERR merr = new MERR();						//エラー

				public MITU()
				{
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

					UoeCommonFnc.MemSet(ref retok, cd, retok.Length);			// レート区分					
					UoeCommonFnc.MemSet(ref reto, cd, reto.Length);				// レートコード					
					UoeCommonFnc.MemSet(ref senc, cd, senc.Length);				// 選択コード					
					UoeCommonFnc.MemSet(ref remk, cd, remk.Length);				// リマーク						

					mitu2.Clear(0x00);
					merr.Clear(0x00);
				}
			}
			# endregion

			# region Constructors
			/// <summary>
			/// コンストラクタ
			/// </summary>
			public TelegramJnlEstmt0402()
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
				mitu.Clear(0x00);
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
					DataRow dataRow = _uoeSndRcvJnlAcs.JnlEstmtTblRead(
													uOESupplierCd,
													dtl.UOESalesOrderNo,
													dtl.UOESalesOrderRowNo[i]);
					if (dataRow == null)
					{
						continue;
					}

					//データ送信区分
                    dataRow[EstmtSndRcvJnlSchema.ct_Col_DataSendCode] = dtl.DataSendCode;

					//データ復旧区分
					dataRow[EstmtSndRcvJnlSchema.ct_Col_DataRecoverDiv] = dtl.DataRecoverDiv;
	
					//受信日付(YYYYMMDD)
					int int32Yymmdd = UoeCommonFnc.atobs(mitu.ymdhms, 0, 4) * 100;

					//電文自体にに日付がセットされている
					if (int32Yymmdd != 0)
					{
						int lwk = TDateTime.DateTimeToLongDate(DateTime.Now);		//yyyymmdd
						lwk /= 1000000;	// yy
						lwk *= 1000000;	// yy000000

						dataRow[EstmtSndRcvJnlSchema.ct_Col_ReceiveDate] = TDateTime.LongDateToDateTime(int32Yymmdd + lwk);
					}
					//電文自体にに日付がセットされていない
					else
					{
						dataRow[EstmtSndRcvJnlSchema.ct_Col_ReceiveDate] = DateTime.Now;
					}

					//受信時刻(HHMM)
					dataRow[EstmtSndRcvJnlSchema.ct_Col_ReceiveTime] = UoeCommonFnc.atobs(mitu.ymdhms, 4, 4) * 100;

					// 回答電文エラーチェック
					if ( (mitu.kekka[0] != 0x00)
					||	 (mitu.gsk[0] != 0x00) )
					{
						string errMessage = "";

						if (mitu.kekka[0] == 0x01)
						{
							errMessage = UoeCommonFnc.ToStringFromByteStrAry(mitu.merr.ermsg);
						}
						else
						{
							errMessage = GetHeadErrorMassage(mitu.kekka[0]);
						}

						//ヘッドエラーメッセージ
						dataRow[EstmtSndRcvJnlSchema.ct_Col_HeadErrorMassage] = errMessage;

						//品名
						dataRow[EstmtSndRcvJnlSchema.ct_Col_AnswerPartsName] = errMessage;

						continue;
					}

					// 見積レート
					dataRow[EstmtSndRcvJnlSchema.ct_Col_EstimateRate] = UoeCommonFnc.ToStringFromByteStrAry(mitu.retok)
																	  + UoeCommonFnc.ToStringFromByteStrAry(mitu.reto);

					// 選択コード
					dataRow[EstmtSndRcvJnlSchema.ct_Col_SelectCode] = UoeCommonFnc.ToStringFromByteStrAry(mitu.senc);

					// 互換性コード
					dataRow[EstmtSndRcvJnlSchema.ct_Col_UOESubstCode] = UoeCommonFnc.ToStringFromByteStrAry(mitu.mitu2.mdata[i].gokan);
					
					// UOE価格コード(価格建区分)
					dataRow[EstmtSndRcvJnlSchema.ct_Col_UOEPriceCode] = UoeCommonFnc.ToStringFromByteStrAry(mitu.mitu2.mdata[i].tkbn);

					// 数量
					dataRow[EstmtSndRcvJnlSchema.ct_Col_AcceptAnOrderCnt] = UoeCommonFnc.ToDoubleFromByteStrAry(mitu.mitu2.mdata[i].msu);

					// 代替品番
					if((mitu.mitu2.mdata[i].gokan[0] != 0x00)
					&& (mitu.mitu2.mdata[i].gokan[0] != 0x20)
					&& (mitu.mitu2.mdata[i].gokan[0] != 0x30))
					{
						dataRow[EstmtSndRcvJnlSchema.ct_Col_SubstPartsNo] = UoeCommonFnc.ToStringFromByteStrAry(mitu.mitu2.mdata[i].knm);
					}

					// 回答品番
					dataRow[EstmtSndRcvJnlSchema.ct_Col_AnswerPartsNo] = UoeCommonFnc.ToStringFromByteStrAry(mitu.mitu2.mdata[i].khb); 

					// 回答品名
					dataRow[EstmtSndRcvJnlSchema.ct_Col_AnswerPartsName] = UoeCommonFnc.ToStringFromByteStrAry(mitu.mitu2.mdata[i].knm);

					// 売上単価（税抜，浮動）(見積単価)
					dataRow[EstmtSndRcvJnlSchema.ct_Col_SalesUnPrcTaxExcFl] = UoeCommonFnc.ToDoubleFromByteStrAry(mitu.mitu2.mdata[i].mtan);
					
					// 摘要（定価）
                    dataRow[EstmtSndRcvJnlSchema.ct_Col_AnswerListPrice] = UoeCommonFnc.ToDoubleFromByteStrAry(mitu.mitu2.mdata[i].mtan);
                    
                    //在庫情報セット
					for (int ix=0; ix < 3; ix++ )
					{
						//在庫数
						string zsuString = UoeCommonFnc.ToStringFromByteStrAry(mitu.mitu2.mdata[i].zaim[ix].zsu);
                        int zsu = UoeCommonFnc.ToInt32FromString(zsuString.Trim());

						//拠点コード
						string kcd = "0" + UoeCommonFnc.ToStringFromByteStrAry(mitu.mitu2.mdata[i].zaim[ix].kcd);

						switch( ix )
						{
							// 拠点在庫数
							case 0:
								//UOE拠点コード１
								dataRow[EstmtSndRcvJnlSchema.ct_Col_UOESectionCode1] = kcd;
							
								//UOE拠点在庫数１
								dataRow[EstmtSndRcvJnlSchema.ct_Col_UOESectionStock1] = zsu;
								break;
							// センター在庫数
							case 1:
								//UOE拠点コード１
								dataRow[EstmtSndRcvJnlSchema.ct_Col_UOESectionCode2] = kcd;
							
								//UOE拠点在庫数１
								dataRow[EstmtSndRcvJnlSchema.ct_Col_UOESectionStock2] = zsu;
								break;
							// メーカー在庫数
							case 2:
								//UOE拠点コード１
								dataRow[EstmtSndRcvJnlSchema.ct_Col_UOESectionCode3] = kcd;

								//UOE拠点在庫数１
								dataRow[EstmtSndRcvJnlSchema.ct_Col_UOESectionStock3] = zsu;
								break;
							default:
								break;
						}
					}

					// 原価単価(仕切単価)
                    dataRow[EstmtSndRcvJnlSchema.ct_Col_AnswerSalesUnitCost] = UoeCommonFnc.ToDoubleFromByteStrAry(mitu.mitu2.mdata[i].sktan);

					// コメント
					dataRow[EstmtSndRcvJnlSchema.ct_Col_LineErrorMassage] = UoeCommonFnc.ToStringFromByteStrAry(mitu.mitu2.mdata[i].ermsg);
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

				ms.Read(mitu.jkbn, 0, mitu.jkbn.Length); // 情報区分						
				ms.Read(mitu.seq_no, 0, mitu.seq_no.Length); // テキストシーケンス番号		
				ms.Read(mitu.text_len, 0, mitu.text_len.Length); // テキスト長					
				ms.Read(mitu.dkbn, 0, mitu.dkbn.Length); // 電文区分						
				ms.Read(mitu.kekka, 0, mitu.kekka.Length); // 処理結果						
				ms.Read(mitu.tokbn, 0, mitu.tokbn.Length); // 問合せ／応答区分				
				ms.Read(mitu.g_id, 0, mitu.g_id.Length); // 業務ＩＤ						
				ms.Read(mitu.g_pass, 0, mitu.g_pass.Length); // 業務パスワード				
				ms.Read(mitu.prog_ver, 0, mitu.prog_ver.Length); // 端末プログラムバージョン番号	
				ms.Read(mitu.kkbn, 0, mitu.kkbn.Length); // 継続区分						
				ms.Read(mitu.h_id, 0, mitu.h_id.Length); // 取引ＩＤ						
				ms.Read(mitu.ext, 0, mitu.ext.Length); // 拡張エリア					
				ms.Read(mitu.gsk, 0, mitu.gsk.Length); // 業務処理結果					
				ms.Read(mitu.gsf, 0, mitu.gsf.Length); // 業務継続フラグ				
				ms.Read(mitu.seq, 0, mitu.seq.Length); // シーケンスＮＯ				
				ms.Read(mitu.bymd, 0, mitu.bymd.Length); // 端末入力日付・時間			
				ms.Read(mitu.ymdhms, 0, mitu.ymdhms.Length); // ホスト日付・時間				

				ms.Read(mitu.retok, 0, mitu.retok.Length); // レート区分					
				ms.Read(mitu.reto, 0, mitu.reto.Length); // レートコード					
				ms.Read(mitu.senc, 0, mitu.senc.Length); // 選択コード					
				ms.Read(mitu.remk, 0, mitu.remk.Length); // リマーク						
				
				//エラー部
                if ((mitu.kekka[0] != 0x00)
                || (mitu.gsk[0] != 0x00))
                {
                    MERR Merr = mitu.merr;

                    ms.Read(Merr.ermsg, 0, Merr.ermsg.Length); // エラーメッセージ				
                    ms.Read(Merr.khb, 0, Merr.khb.Length); // 部番							
                    ms.Read(Merr.msu, 0, Merr.msu.Length); // 数量							
                }
                //明細部
                else
                {
                    MITU2 Mitu2 = mitu.mitu2;

                    ms.Read(Mitu2.mimny, 0, Mitu2.mimny.Length); // 見積金額合計					
                    ms.Read(Mitu2.simny, 0, Mitu2.simny.Length); // 仕切金額合計					

                    // ライン項目１～１０
                    for (int i = 0; i < Mitu2.mdata.Length; i++)
                    {
                        MDATA Mdata = mitu.mitu2.mdata[i];

                        ms.Read(Mdata.khb, 0, Mdata.khb.Length); // 部品番号						
                        ms.Read(Mdata.msu, 0, Mdata.msu.Length); // 数量							
                        ms.Read(Mdata.knm, 0, Mdata.knm.Length); // 品名／新部番					
                        ms.Read(Mdata.mtan, 0, Mdata.mtan.Length); // 見積単価						

                        for (int j = 0; j < Mdata.zaim.Length; j++)
                        {
                            ZAIM Zaim = mitu.mitu2.mdata[i].zaim[j];

                            ms.Read(Zaim.kcd, 0, Zaim.kcd.Length); // 拠点コード					
                            ms.Read(Zaim.zsu, 0, Zaim.zsu.Length); // 在庫数						
                        }

                        ms.Read(Mdata.tkbn, 0, Mdata.tkbn.Length); // 価格建区分					
                        ms.Read(Mdata.gokan, 0, Mdata.gokan.Length); // 互換性コード					
                        ms.Read(Mdata.sktan, 0, Mdata.sktan.Length); // 仕切単価						
                        ms.Read(Mdata.ermsg, 0, Mdata.ermsg.Length); // コメント
                    }
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
					case 0x88:						//-- "ｼﾞｶﾝｶﾞｲｴﾗｰ" --
						str = MSG_RUS;
						break;
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

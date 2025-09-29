//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : ＵＯＥ受信編集＜見積＞（旧マツダ）アクセスクラス
// プログラム概要   : ＵＯＥ受信編集＜見積＞（旧マツダ）を行う
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
	/// ＵＯＥ受信編集＜見積＞（旧マツダ）アクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : ＵＯＥ受信編集＜見積＞（旧マツダ）アクセスクラス</br>
	/// <br>Programmer : 96186 立花裕輔</br>
	/// <br>Date       : 2008.05.26</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// <br>2008.05.26 men 新規作成</br>
	/// </remarks>
	public partial class UoeRecEdit0401Acs
	{
		// ===================================================================================== //
		// プライベートメソッド
		// ===================================================================================== //
		# region Private Methods

		# region ＵＯＥ受信編集＜見積＞（旧マツダ）
		/// <summary>
		/// ＵＯＥ受信編集＜見積＞（旧マツダ）
		/// </summary>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        private int GetJnlEstmt0401(out string message)
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
                    TelegramJnlEstmt0401 telegramJnlEstmt0401 = new TelegramJnlEstmt0401();

                    //ＪＮＬ更新処理
                    foreach (UoeRecDtl dtl in uoeRecDtlList)
                    {
                        telegramJnlEstmt0401.Telegram(_uoeRecHed.UOESupplierCd, dtl);
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

		# region ＵＯＥ受信電文作成＜見積＞（旧マツダ）
		/// <summary>
		/// ＵＯＥ受信電文作成＜見積＞（旧マツダ）
		/// </summary>
		public class TelegramJnlEstmt0401 : UoeRecEdit0401Acs
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
			//	char	hzumu[1] ;					/* 本庫在庫表示					*/
			//	char	szumu[1] ;					/* 支店在庫表示					*/
			//	char	mkzsu[2] ;					/* 拠点在庫表示					*/
			//	char	tkbn[1] ;					/* 定価建区分					*/
			//	char	gokan[2] ;					/* 互換性コード					*/
			//	char	sktan[7] ;					/* 仕切単価						*/
			//	char	ermsg[8];					/* コメント						*/
			//} MDATA ;
			//
			//typedef struct	{
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
			private DN_M dn_m = new DN_M(); 
			# endregion

			# region 電文領域クラス
			/// <summary>
			/// エラー電文領域
			/// </summary>
			private class ER_M
			{
				public byte[] ermsg = new byte[20];		// エラーメッセージ				
				public byte[] khb = new byte[24];		// 部番							
				public byte[] hasu = new byte[5];		// 注文数						
				public byte[] bo = new byte[1];			// ＢＯ区分						

				public ER_M()
				{
					Clear(0x00);
				}
				public void Clear(byte cd)
				{
					UoeCommonFnc.MemSet(ref ermsg, cd, ermsg.Length);	// エラーメッセージ				
					UoeCommonFnc.MemSet(ref khb, cd, khb.Length);		// 部番							
					UoeCommonFnc.MemSet(ref hasu, cd, hasu.Length);		// 注文数						
					UoeCommonFnc.MemSet(ref bo, cd, bo.Length);			// ＢＯ区分						
				}
			}

			/// <summary>
			/// 見積電文領域＜ライン２＞
			/// </summary>
			private class LN2_M
			{
				public byte[] khb = new byte[24];		// 部品番号						
				public byte[] msu = new byte[5];			// 数量							
				public byte[] knm = new byte[20];		// 品名／新部番					
				public byte[] mtan = new byte[7];		// 見積単価						
				public byte[] hzumu = new byte[1];		// 本庫在庫表示					
				public byte[] szumu = new byte[1];		// 支店在庫表示					
				public byte[] mkzsu = new byte[2];		// 拠点在庫表示					
				public byte[] tkbn = new byte[1];		// 定価建区分					
				public byte[] gokan = new byte[2];		// 互換性コード					
				public byte[] sktan = new byte[7];		// 仕切単価						
				public byte[] ermsg = new byte[8];		// コメント						

				public LN2_M()
				{
					Clear(0x00);
				}
				public void Clear(byte cd)
				{
					UoeCommonFnc.MemSet(ref khb, cd, khb.Length);		// 部品番号						
					UoeCommonFnc.MemSet(ref msu, cd, msu.Length);		// 数量							
					UoeCommonFnc.MemSet(ref knm, cd, knm.Length);		// 品名／新部番					
					UoeCommonFnc.MemSet(ref mtan, cd, mtan.Length);		// 見積単価						
					UoeCommonFnc.MemSet(ref hzumu, cd, hzumu.Length);	// 本庫在庫表示					
					UoeCommonFnc.MemSet(ref szumu, cd, szumu.Length);	// 支店在庫表示					
					UoeCommonFnc.MemSet(ref mkzsu, cd, mkzsu.Length);	// 拠点在庫表示					
					UoeCommonFnc.MemSet(ref tkbn, cd, tkbn.Length);		// 定価建区分					
					UoeCommonFnc.MemSet(ref gokan, cd, gokan.Length);	// 互換性コード					
					UoeCommonFnc.MemSet(ref sktan, cd, sktan.Length);	// 仕切単価						
					UoeCommonFnc.MemSet(ref ermsg, cd, ermsg.Length);	// コメント						
				}
			}


			/// <summary>
			/// 見積電文領域＜ライン＞
			/// </summary>
			private class LN_M
			{
				public byte[] mimny = new byte[9];		// 見積金額合計					
				public byte[] simny = new byte[9];		// 仕切金額合計					
				public LN2_M[] ln2_m = new LN2_M[10];		// ライン項目１～１０			

				public LN_M()
				{
					Clear(0x00);
				}
				public void Clear(byte cd)
				{
					UoeCommonFnc.MemSet(ref mimny, cd, mimny.Length);	// 見積金額合計					
					UoeCommonFnc.MemSet(ref simny, cd, simny.Length);	// 仕切金額合計					

					for (int i = 0; i < ln2_m.Length; i++)
					{
                        if (ln2_m[i] == null)
                        {
                            ln2_m[i] = new LN2_M();
                        }
                        else
                        {
                            ln2_m[i].Clear(0x00);
                        }
                    }
				}
			}

			/// <summary>
			/// 見積電文領域＜本体＞
			/// </summary>
			private class DN_M
			{
				public byte[] jkbn = new byte[1];		// 情報区分						
				public byte[] seq_no = new byte[2];		// テキストシーケンス番号		
				public byte[] text_len = new byte[2];	// テキスト長					
				public byte[] dkbn = new byte[1];		// 電文区分						
				public byte[] kekka = new byte[1];		// 処理結果						
				public byte[] tokbn = new byte[1];		// 問合せ／応答区分				
				public byte[] g_id = new byte[12];		// 業務ＩＤ						
				public byte[] g_pass = new byte[6];		// 業務パスワード				
				public byte[] prog_ver = new byte[3];	// 端末プログラムバージョン番号	
				public byte[] kkbn = new byte[1];		// 継続区分						
				public byte[] h_id = new byte[3];		// 取引ＩＤ						
				public byte[] ext = new byte[15];		// 拡張エリア					
				public byte[] gsk = new byte[1];		// 業務処理結果					
				public byte[] gsf = new byte[1];		// 業務継続フラグ				
				public byte[] seq = new byte[3];		// シーケンスＮＯ				
				public byte[] bymd = new byte[4];		// 端末入力日付・時間			
				public byte[] ymdhms = new byte[8];		// ホスト日付・時間				

				public byte[] retok = new byte[1];		// レート区分					
				public byte[] reto = new byte[4];		// レートコード					
				public byte[] senc = new byte[1];		// 選択コード					
				public byte[] remk = new byte[10];		// リマーク						

				public LN_M ln_m = new LN_M();			// 明細部
				public ER_M er_m = new ER_M();			// エラー部

				/// <summary>	
				/// コンストラクター
				/// </summary>
				public DN_M()
				{
					Clear(0x00);
				}

				public void Clear(byte cd)
				{
					UoeCommonFnc.MemSet(ref jkbn, cd, jkbn.Length);			// 情報区分						
					UoeCommonFnc.MemSet(ref seq_no, cd, seq_no.Length);		// テキストシーケンス番号		
					UoeCommonFnc.MemSet(ref text_len, cd, text_len.Length);	// テキスト長					
					UoeCommonFnc.MemSet(ref dkbn, cd, dkbn.Length);			// 電文区分						
					UoeCommonFnc.MemSet(ref kekka, cd, kekka.Length);		// 処理結果						
					UoeCommonFnc.MemSet(ref tokbn, cd, tokbn.Length);		// 問合せ／応答区分				
					UoeCommonFnc.MemSet(ref g_id, cd, g_id.Length);			// 業務ＩＤ						
					UoeCommonFnc.MemSet(ref g_pass, cd, g_pass.Length);		// 業務パスワード				
					UoeCommonFnc.MemSet(ref prog_ver, cd, prog_ver.Length);	// 端末プログラムバージョン番号	
					UoeCommonFnc.MemSet(ref kkbn, cd, kkbn.Length);			// 継続区分						
					UoeCommonFnc.MemSet(ref h_id, cd, h_id.Length);			// 取引ＩＤ						
					UoeCommonFnc.MemSet(ref ext, cd, ext.Length);			// 拡張エリア					
					UoeCommonFnc.MemSet(ref gsk, cd, gsk.Length);			// 業務処理結果					
					UoeCommonFnc.MemSet(ref gsf, cd, gsf.Length);			// 業務継続フラグ				
					UoeCommonFnc.MemSet(ref seq, cd, seq.Length);			// シーケンスＮＯ				
					UoeCommonFnc.MemSet(ref bymd, cd, bymd.Length);			// 端末入力日付・時間			
					UoeCommonFnc.MemSet(ref ymdhms, cd, ymdhms.Length);		// ホスト日付・時間				

					UoeCommonFnc.MemSet(ref retok, cd, retok.Length);		// レート区分					
					UoeCommonFnc.MemSet(ref reto, cd, reto.Length);			// レートコード					
					UoeCommonFnc.MemSet(ref senc, cd, senc.Length);			// 選択コード					
					UoeCommonFnc.MemSet(ref remk, cd, remk.Length);			// リマーク						

					//明細部
					ln_m.Clear(0x00);

					//エラー部
					er_m.Clear(0x00);
				}
			}
			# endregion



			# region Constructors
			/// <summary>
			/// コンストラクタ
			/// </summary>
			public TelegramJnlEstmt0401()
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

			# region エラー部
			/// <summary>
			/// エラー部
			/// </summary>
			private ER_M Er_m
			{
				get
				{
					return dn_m.er_m;
				}
				set
				{
					this.dn_m.er_m = value;
				}
			}
			# endregion

			# region 明細部
			/// <summary>
			/// 明細部
			/// </summary>
			private LN_M Ln_m
			{
				get
				{
					return dn_m.ln_m;
				}
				set
				{
					this.dn_m.ln_m = value;
				}
			}
			# endregion

			# region 明細部２
			/// <summary>
			/// 明細部２
			/// </summary>
			private LN2_M[] Ln2_m
			{
				get
				{
					return dn_m.ln_m.ln2_m;
				}
				set
				{
					this.dn_m.ln_m.ln2_m = value;
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
				dn_m.Clear(0x00);
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
					int int32Yymmdd = UoeCommonFnc.atobs(dn_m.ymdhms, 0, 4) * 100;

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
					dataRow[EstmtSndRcvJnlSchema.ct_Col_ReceiveTime] = UoeCommonFnc.atobs(dn_m.ymdhms, 4, 4) * 100;

										/* 回答電文エラーチェック	*/
					if ( (dn_m.kekka[0] != 0x00)
					||	 (dn_m.gsk[0] != 0x00) )
					{
						string errMessage = "";

						if (dn_m.kekka[0] == 0x01)
						{
							errMessage = UoeCommonFnc.ToStringFromByteStrAry(dn_m.er_m.ermsg);

						}
						else
						{
							errMessage = GetHeadErrorMassage(dn_m.kekka[0]);
						}

						//ヘッドエラーメッセージ
						dataRow[EstmtSndRcvJnlSchema.ct_Col_HeadErrorMassage] = errMessage;

						//品名
						dataRow[EstmtSndRcvJnlSchema.ct_Col_AnswerPartsName] = errMessage;

						continue;
					}

					//見積レート
					dataRow[EstmtSndRcvJnlSchema.ct_Col_EstimateRate] = UoeCommonFnc.ToStringFromByteStrAry(dn_m.reto);

					// 選択コード
					dataRow[EstmtSndRcvJnlSchema.ct_Col_SelectCode] = UoeCommonFnc.ToStringFromByteStrAry(dn_m.senc);

					// 互換性コード
					dataRow[EstmtSndRcvJnlSchema.ct_Col_UOESubstCode] = UoeCommonFnc.ToStringFromByteStrAry(dn_m.ln_m.ln2_m[i].gokan);

					
					//UOE価格コード(価格建区分)
					dataRow[EstmtSndRcvJnlSchema.ct_Col_UOEPriceCode] = UoeCommonFnc.ToStringFromByteStrAry(dn_m.ln_m.ln2_m[i].tkbn);
					
					// 数量
					dataRow[EstmtSndRcvJnlSchema.ct_Col_AcceptAnOrderCnt] = UoeCommonFnc.ToDoubleFromByteStrAry(dn_m.ln_m.ln2_m[i].msu);

					//代替品番
					if ((dn_m.ln_m.ln2_m[i].gokan[0] != 0x00)
					&& (dn_m.ln_m.ln2_m[i].gokan[0] != 0x20)
					&& (dn_m.ln_m.ln2_m[i].gokan[0] != 0x30))
					{
						dataRow[EstmtSndRcvJnlSchema.ct_Col_SubstPartsNo] = UoeCommonFnc.ToStringFromByteStrAry(dn_m.ln_m.ln2_m[i].knm);
					}

					//回答品番
					dataRow[EstmtSndRcvJnlSchema.ct_Col_AnswerPartsNo] = UoeCommonFnc.ToStringFromByteStrAry(dn_m.ln_m.ln2_m[i].khb); 

					//回答品名
					dataRow[EstmtSndRcvJnlSchema.ct_Col_AnswerPartsName] = UoeCommonFnc.ToStringFromByteStrAry(dn_m.ln_m.ln2_m[i].knm);

                    //回答原価単価
                    dataRow[EstmtSndRcvJnlSchema.ct_Col_AnswerSalesUnitCost] = UoeCommonFnc.ToDoubleFromByteStrAry(dn_m.ln_m.ln2_m[i].sktan);

					// 摘要（定価）
                    dataRow[EstmtSndRcvJnlSchema.ct_Col_AnswerListPrice] = UoeCommonFnc.ToDoubleFromByteStrAry(dn_m.ln_m.ln2_m[i].mtan);

					//代替マーク
					//uoejlb.PM1599[0] = 'N' ;
					//if ( recv_str.den.mitu.mdata[ii].hzumu[0] == 'Y' )
					//	uoejlb.PM1599[0] = 'Y' ;
					//if ( recv_str.den.mitu.mdata[ii].szumu[0] == 'Y' )
					//	uoejlb.PM1599[0] = 'Y' ;

					// 本社在庫表示
					dataRow[EstmtSndRcvJnlSchema.ct_Col_HeadQtrsStock] = UoeCommonFnc.ToStringFromByteStrAry(dn_m.ln_m.ln2_m[i].hzumu);

					// 支店在庫表示
					dataRow[EstmtSndRcvJnlSchema.ct_Col_SectionStock] = UoeCommonFnc.ToStringFromByteStrAry(dn_m.ln_m.ln2_m[i].szumu);

					// 拠点在庫表示
					dataRow[EstmtSndRcvJnlSchema.ct_Col_BranchStock] = UoeCommonFnc.ToStringFromByteStrAry(dn_m.ln_m.ln2_m[i].mkzsu);

					// コメント
					dataRow[EstmtSndRcvJnlSchema.ct_Col_LineErrorMassage] = UoeCommonFnc.ToStringFromByteStrAry(dn_m.ln_m.ln2_m[i].ermsg);
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

				ms.Read(dn_m.jkbn, 0, dn_m.jkbn.Length); // 情報区分						
				ms.Read(dn_m.seq_no, 0, dn_m.seq_no.Length); // テキストシーケンス番号		
				ms.Read(dn_m.text_len, 0, dn_m.text_len.Length); // テキスト長					
				ms.Read(dn_m.dkbn, 0, dn_m.dkbn.Length); // 電文区分						
				ms.Read(dn_m.kekka, 0, dn_m.kekka.Length); // 処理結果						
				ms.Read(dn_m.tokbn, 0, dn_m.tokbn.Length); // 問合せ／応答区分				
				ms.Read(dn_m.g_id, 0, dn_m.g_id.Length); // 業務ＩＤ						
				ms.Read(dn_m.g_pass, 0, dn_m.g_pass.Length); // 業務パスワード				
				ms.Read(dn_m.prog_ver, 0, dn_m.prog_ver.Length); // 端末プログラムバージョン番号	
				ms.Read(dn_m.kkbn, 0, dn_m.kkbn.Length); // 継続区分						
				ms.Read(dn_m.h_id, 0, dn_m.h_id.Length); // 取引ＩＤ						
				ms.Read(dn_m.ext, 0, dn_m.ext.Length); // 拡張エリア					
				ms.Read(dn_m.gsk, 0, dn_m.gsk.Length); // 業務処理結果					
				ms.Read(dn_m.gsf, 0, dn_m.gsf.Length); // 業務継続フラグ				
				ms.Read(dn_m.seq, 0, dn_m.seq.Length); // シーケンスＮＯ				
				ms.Read(dn_m.bymd, 0, dn_m.bymd.Length); // 端末入力日付・時間			
				ms.Read(dn_m.ymdhms, 0, dn_m.ymdhms.Length); // ホスト日付・時間				

				ms.Read(dn_m.retok, 0, dn_m.retok.Length); // レート区分					
				ms.Read(dn_m.reto, 0, dn_m.reto.Length); // レートコード					
				ms.Read(dn_m.senc, 0, dn_m.senc.Length); // 選択コード					
				ms.Read(dn_m.remk, 0, dn_m.remk.Length); // リマーク						

				//エラー部
				if ((dn_m.kekka[0] != 0x00)
				|| (dn_m.gsk[0] != 0x00))
				{
					ms.Read(Er_m.ermsg, 0, Er_m.ermsg.Length); // エラーメッセージ				
					ms.Read(Er_m.khb, 0, Er_m.khb.Length); // 部番							
					ms.Read(Er_m.hasu, 0, Er_m.hasu.Length); // 注文数						
					ms.Read(Er_m.bo, 0, Er_m.bo.Length); // ＢＯ区分						
				}
				//明細部
				else
				{
					ms.Read(Ln_m.mimny, 0, Ln_m.mimny.Length); // 見積金額合計					
					ms.Read(Ln_m.simny, 0, Ln_m.simny.Length); // 仕切金額合計					

					for (int i = 0; i < ctBufLen; i++)
					{
						ms.Read(Ln2_m[i].khb, 0, Ln2_m[i].khb.Length); 		// 部品番号						
						ms.Read(Ln2_m[i].msu, 0, Ln2_m[i].msu.Length); 		// 数量							
						ms.Read(Ln2_m[i].knm, 0, Ln2_m[i].knm.Length); 	// 品名／新部番					
						ms.Read(Ln2_m[i].mtan, 0, Ln2_m[i].mtan.Length); 	// 見積単価						
						ms.Read(Ln2_m[i].hzumu, 0, Ln2_m[i].hzumu.Length); // 本庫在庫表示					
						ms.Read(Ln2_m[i].szumu, 0, Ln2_m[i].szumu.Length); // 支店在庫表示					
						ms.Read(Ln2_m[i].mkzsu, 0, Ln2_m[i].mkzsu.Length); // 拠点在庫表示					
						ms.Read(Ln2_m[i].tkbn, 0, Ln2_m[i].tkbn.Length); 		// 定価建区分					
						ms.Read(Ln2_m[i].gokan, 0, Ln2_m[i].gokan.Length); // 互換性コード					
						ms.Read(Ln2_m[i].sktan, 0, Ln2_m[i].sktan.Length); // 仕切単価						
						ms.Read(Ln2_m[i].ermsg, 0, Ln2_m[i].ermsg.Length); // コメント						
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

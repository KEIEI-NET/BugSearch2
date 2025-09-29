//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : ＵＯＥ受信編集＜発注＞（新マツダ）アクセスクラス
// プログラム概要   : ＵＯＥ受信編集＜発注＞（新マツダ）を行う
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
	/// ＵＯＥ受信編集＜発注＞（新マツダ）アクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : ＵＯＥ受信編集（新マツダ）アクセスクラス</br>
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

		# region ＵＯＥ受信編集＜発注＞（新マツダ）
		/// <summary>
		/// ＵＯＥ受信編集＜発注＞（新マツダ）
		/// </summary>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        private int GetJnlOrder0402(out string message)
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
                    _uOESupplier = _uoeSndRcvJnlAcs.SearchUOESupplier(_uoeRecHed.UOESupplierCd);

                    TelegramJnlOrder0402 telegramJnlOrder0402 = new TelegramJnlOrder0402();

                    //ＪＮＬ更新処理
                    foreach (UoeRecDtl dtl in uoeRecDtlList)
                    {
                        telegramJnlOrder0402.Telegram(_uOESupplier, dtl);
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

		# region ＵＯＥ受信電文作成＜発注＞（新マツダ）
		/// <summary>
		/// ＵＯＥ受信電文作成＜発注＞（新マツダ）
		/// </summary>
		public class TelegramJnlOrder0402 : UoeRecEdit0402Acs
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
			//typedef struct	{
			//	char	khb[24] ;					/* 品番							*/
			//	char	hasu[5] ;					/* 注文数						*/
			//	char	syk_max[5] ;				/* 出荷数合計					*/
			//	char	mksu[5] ;					/* ＢＯ数						*/
			//	char	bo[1] ;						/* ＢＯ区分						*/
			//	char	knm[20] ;					/* 部品名						*/
			//	char	bhb[24] ;					/* 部品番号（注文）				*/
			//	char	gokan[2] ;					/* 互換性コード					*/
			//	char	sktan[7] ;					/* 仕切り単価					*/
			//	char	teika[7] ;					/* 希望小売価格					*/
			//	SYK		syk[3] ;					/* 出荷情報	　構造体			*/
			//	ZAI1	zai1[7] ;					/* 在庫情報	　構造体			*/
			//	char	ermsg[15] ;					/* コメント						*/
			//	char	l_ext[3] ;					/* ライン拡張エリア				*/
			//} HDATA ;
			//
			//typedef struct	{						/* 発注回答電文					*/
			//	HEAD	head ;
			//	char	nhkb[1] ;					/* 納品区分						*/
			//	char	rem1[20] ;					/* リマーク						*/
			//	char	kyoten[2] ;					/* 指定拠点						*/
			//	char	head_ext[10] ;				/* ヘッド拡張エリア				*/
			//	HDATA	hdata[6] ;					/* ライン項目１～６				*/
			//} HATYU ;
			//
			///********************** 発注ヘッドエラー電文構造体 **********************/
			//typedef struct	{
			//	HEAD	head ;
			//	char	nhkb[1] ;					/* 納品区分						*/
			//	char	rem1[20] ;					/* リマーク						*/
			//	char	kyoten[2] ;					/* 指定拠点						*/
			//	char	head_ext[10] ;				/* ヘッド拡張エリア				*/
			//	char	ermsg[20] ;					/* エラーメッセージ				*/
			//	char	khb[24] ;					/* 部番							*/
			//	char	hasu[5] ;					/* 注文数						*/
			//	char	bo[1] ;						/* ＢＯ区分						*/
			//} HERR ;
			# endregion

			# region Const Members
			private const Int32 ctBufLen = 6;		//明細バッファサイズ
			# endregion

			# region 電文領域クラス
			/// <summary>
			/// 発注エラー電文
			/// </summary>
			private class HERR
			{
				public byte[]	ermsg = new byte[20] ;					// エラーメッセージ				
				public byte[]	khb = new byte[24] ;					// 部番							
				public byte[]	hasu = new byte[5] ;					// 注文数						
				public byte[]	bo = new byte[1] ;						// ＢＯ区分		
				
				public HERR()
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
			/// 出荷情報 １～３
			/// </summary>
			private class SYK
			{
				public byte[]	kcd = new byte[2];						// 拠点コード					
				public byte[]	dno = new byte[7];						// 伝票Ｎｏ．					
				public byte[]	ssu = new byte[5];						// 出荷数						
				public byte[]	zsu = new byte[2];						// 在庫数						
				
				public SYK()
				{
					Clear(0x00);
				}
				
				public void Clear(byte cd)
				{
					UoeCommonFnc.MemSet(ref kcd, cd, kcd.Length);		// 拠点コード					
					UoeCommonFnc.MemSet(ref dno, cd, dno.Length);		// 伝票Ｎｏ．					
					UoeCommonFnc.MemSet(ref ssu, cd, ssu.Length);		// 出荷数						
					UoeCommonFnc.MemSet(ref zsu, cd, zsu.Length);		// 在庫数						
				}
			}

			/// <summary>
			/// 在庫情報
			/// </summary>
			private class ZAIH
			{
				public byte[]	kcd = new byte[2];						// 拠点コード					
				public byte[]	zsu = new byte[2];						// 在庫数						
				
				public ZAIH()
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
			/// 発注明細
			/// </summary>
			private class HDATA
			{
				public byte[]	khb = new byte[24] ;				// 品番							
				public byte[]	hasu = new byte[5] ;				// 注文数						
				public byte[]	syk_max = new byte[5] ;				// 出荷数合計					
				public byte[]	mksu = new byte[5] ;				// ＢＯ数						
				public byte[]	bo = new byte[1] ;					// ＢＯ区分						
				public byte[]	knm = new byte[20] ;				// 部品名						
				public byte[]	bhb = new byte[24] ;				// 部品番号（注文）				
				public byte[]	gokan = new byte[2] ;				// 互換性コード					
				public byte[]	sktan = new byte[7] ;				// 仕切り単価					
				public byte[]	teika = new byte[7] ;				// 希望小売価格					
				public SYK[]	syk = new SYK[3] ;					// 出荷情報	構造体			
				public ZAIH[]	zaih = new ZAIH[7] ;				// 在庫情報	構造体			
				public byte[]	ermsg = new byte[15] ;				// コメント						
				public byte[]	l_ext = new byte[3] ;				// ライン拡張エリア				
				
				public HDATA()
				{
					Clear(0x00);
				}
				
				public void Clear(byte cd)
				{
					UoeCommonFnc.MemSet(ref khb, cd, khb.Length);			// 品番							
					UoeCommonFnc.MemSet(ref hasu, cd, hasu.Length);			// 注文数						
					UoeCommonFnc.MemSet(ref syk_max, cd, syk_max.Length);	// 出荷数合計					
					UoeCommonFnc.MemSet(ref mksu, cd, mksu.Length);			// ＢＯ数						
					UoeCommonFnc.MemSet(ref bo, cd, bo.Length);				// ＢＯ区分						
					UoeCommonFnc.MemSet(ref knm, cd, knm.Length);			// 部品名						
					UoeCommonFnc.MemSet(ref bhb, cd, bhb.Length);			// 部品番号（注文）				
					UoeCommonFnc.MemSet(ref gokan, cd, gokan.Length);		// 互換性コード					
					UoeCommonFnc.MemSet(ref sktan, cd, sktan.Length);		// 仕切り単価					
					UoeCommonFnc.MemSet(ref teika, cd, teika.Length);		// 希望小売価格					

					for(int i=0;i<syk.Length; i++)
					{
                        if (syk[i] == null)
                        {
                            syk[i] = new SYK();
                        }
                        else
                        {
                            syk[i].Clear(0x00);
                        }
                    }
					for(int i=0;i<zaih.Length; i++)
					{
                        if (zaih[i] == null)
                        {
                            zaih[i] = new ZAIH();
                        }
                        else
                        {
                            zaih[i].Clear(0x00);
                        }
					}

					UoeCommonFnc.MemSet(ref ermsg, cd, ermsg.Length);		// コメント						
					UoeCommonFnc.MemSet(ref l_ext, cd, l_ext.Length);		// ライン拡張エリア				
				}
			}

			/// <summary>
			/// 発注ヘッダー
			/// </summary>
			private class HATYU
			{
				public byte[]	jkbn = new byte[1] ;			// 情報区分						
				public byte[]	seq_no = new byte[2] ;			// テキストシーケンス番号		
				public byte[]	text_len = new byte[2] ;		// テキスト長					
				public byte[]	dkbn = new byte[1] ;			// 電文区分						
				public byte[]	kekka = new byte[1] ;			// 処理結果						
				public byte[]	tokbn = new byte[1] ;			// 問合せ／応答区分				
				public byte[]	g_id = new byte[12] ;			// 業務ＩＤ						
				public byte[]	g_pass = new byte[6] ;			// 業務パスワード				
				public byte[]	prog_ver = new byte[3] ;		// 端末プログラムバージョン番号	
				public byte[]	kkbn = new byte[1] ;			// 継続区分						
				public byte[]	h_id = new byte[3] ;			// 取引ＩＤ						
				public byte[]	ext = new byte[15] ;			// 拡張エリア					
				public byte[]	gsk = new byte[1] ;				// 業務処理結果					
				public byte[]	gsf = new byte[1] ;				// 業務継続フラグ				
				public byte[]	seq = new byte[3] ;				// シーケンスＮＯ				
				public byte[]	bymd = new byte[4] ;			// 端末入力日付・時間			
				public byte[]	ymdhms = new byte[8] ;			// ホスト日付・時間				

				public byte[]	nhkb = new byte[1] ;			// 納品区分						
				public byte[]	rem1 = new byte[20] ;			// リマーク						
				public byte[]	kyoten = new byte[2] ;			// 指定拠点						
				public byte[]	head_ext = new byte[10] ;		// ヘッド拡張エリア				

				public HDATA[]	hdata = new HDATA[6] ;			// 発注ライン項目１～６				
				public HERR herr = new HERR();					// 発注エラー
				
				public HATYU()
				{
					Clear(0x00);
				}

				public void Clear(byte cd)
				{
					UoeCommonFnc.MemSet(ref jkbn, cd, jkbn.Length);					// 情報区分						
					UoeCommonFnc.MemSet(ref seq_no, cd, seq_no.Length);				// テキストシーケンス番号		
					UoeCommonFnc.MemSet(ref text_len, cd, text_len.Length);			// テキスト長					
					UoeCommonFnc.MemSet(ref dkbn, cd, dkbn.Length);					// 電文区分						
					UoeCommonFnc.MemSet(ref kekka, cd, kekka.Length);				// 処理結果						
					UoeCommonFnc.MemSet(ref tokbn, cd, tokbn.Length);				// 問合せ／応答区分				
					UoeCommonFnc.MemSet(ref g_id, cd, g_id.Length);					// 業務ＩＤ						
					UoeCommonFnc.MemSet(ref g_pass, cd, g_pass.Length);				// 業務パスワード				
					UoeCommonFnc.MemSet(ref prog_ver, cd, prog_ver.Length);			// 端末プログラムバージョン番号	
					UoeCommonFnc.MemSet(ref kkbn, cd, kkbn.Length);					// 継続区分						
					UoeCommonFnc.MemSet(ref h_id, cd, h_id.Length);					// 取引ＩＤ						
					UoeCommonFnc.MemSet(ref ext, cd, ext.Length);					// 拡張エリア					
					UoeCommonFnc.MemSet(ref gsk, cd, gsk.Length);					// 業務処理結果					
					UoeCommonFnc.MemSet(ref gsf, cd, gsf.Length);					// 業務継続フラグ				
					UoeCommonFnc.MemSet(ref seq, cd, seq.Length);					// シーケンスＮＯ				
					UoeCommonFnc.MemSet(ref bymd, cd, bymd.Length);					// 端末入力日付・時間			
					UoeCommonFnc.MemSet(ref ymdhms, cd, ymdhms.Length);				// ホスト日付・時間				

					UoeCommonFnc.MemSet(ref nhkb, cd, nhkb.Length);					// 納品区分						
					UoeCommonFnc.MemSet(ref rem1, cd, rem1.Length);					// リマーク						
					UoeCommonFnc.MemSet(ref kyoten, cd, kyoten.Length);				// 指定拠点						
					UoeCommonFnc.MemSet(ref head_ext, cd, head_ext.Length);			// ヘッド拡張エリア				

					for(int i=0;i<hdata.Length; i++)
					{
                        if (hdata[i] == null)
                        {
                            hdata[i] = new HDATA();
                        }
                        else
                        {
                            hdata[i].Clear(0x00);
                        }
					}

					herr.Clear(0x00);
				}
			}
			# endregion

			# region Private Members
			//変数
			private Int32 _detailMax = 0;
			private HATYU hatyu = new HATYU(); 
			# endregion

			# region Constructors
			/// <summary>
			/// コンストラクタ
			/// </summary>
			public TelegramJnlOrder0402()
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

				hatyu.Clear(0x00);
			}
			# endregion

			# region データ編集処理
			/// <summary>
			/// データ編集処理
			/// </summary>
			/// <param name="dtl"></param>
			/// <param name="jnl"></param>
			public void Telegram(UOESupplier uOESupplier, UoeRecDtl dtl)
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
					DataRow dataRow = _uoeSndRcvJnlAcs.JnlOrderTblRead(
                                                    uOESupplier.UOESupplierCd,
													dtl.UOESalesOrderNo,
													dtl.UOESalesOrderRowNo[i]);
					if (dataRow == null)
					{
						continue;
					}

					//データ送信区分
                    dataRow[OrderSndRcvJnlSchema.ct_Col_DataSendCode] = dtl.DataSendCode;

					//データ復旧区分
					dataRow[OrderSndRcvJnlSchema.ct_Col_DataRecoverDiv] = dtl.DataRecoverDiv;


					//受信日付(YYYYMMDD)
    				dataRow[OrderSndRcvJnlSchema.ct_Col_ReceiveDate] = DateTime.Now;

					//受信時刻(HHMM)
                    dataRow[OrderSndRcvJnlSchema.ct_Col_ReceiveTime] = TDateTime.DateTimeToLongDate("HHMMSS", DateTime.Now);

					/* 回答電文エラーチェック	*/
					if ( ( hatyu.kekka[0] != 0x00 )
					||	 ( hatyu.gsk[0] != 0x00 ) )
					{
						string errMessage = "";

						if (hatyu.gsk[0] == 0x01)
						{
							errMessage = UoeCommonFnc.ToStringFromByteStrAry(hatyu.herr.ermsg);
						}
						else
						{
							errMessage = GetHeadErrorMassage(hatyu.kekka[0]);
						}
						//ヘッドエラーメッセージ
						dataRow[OrderSndRcvJnlSchema.ct_Col_HeadErrorMassage] = errMessage;

						//品名
						dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerPartsName] = errMessage;
						
						continue;
					}

					// 納品区分
                    dataRow[OrderSndRcvJnlSchema.ct_Col_UOEDeliGoodsDiv] = UoeCommonFnc.ToStringFromByteStrAry(hatyu.nhkb);

					// リマーク
					dataRow[OrderSndRcvJnlSchema.ct_Col_UoeRemark1] = UoeCommonFnc.ToStringFromByteStrAry(hatyu.rem1);

					// 指定拠点
					dataRow[OrderSndRcvJnlSchema.ct_Col_UOEResvdSection] = UoeCommonFnc.ToStringFromByteStrAry(hatyu.kyoten);

					//代替有無チェック＆セット
					//代替なし
					if ((hatyu.hdata[i].gokan[0] == 0x00)
					|| (hatyu.hdata[i].gokan[0] == 0x20)
					|| (hatyu.hdata[i].gokan[0] == 0x30))
					{
						//回答品番
						dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerPartsNo] = UoeCommonFnc.ToStringFromByteStrAry(hatyu.hdata[i].khb);

						//回答品名
						dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerPartsName] = UoeCommonFnc.ToStringFromByteStrAry(hatyu.hdata[i].knm);
					}
					//代替あり
					else
					{
						//代替区分
						dataRow[OrderSndRcvJnlSchema.ct_Col_UOESubstMark] = UoeCommonFnc.ToStringFromByteStrAry(hatyu.hdata[i].gokan);

						//代替品番
						dataRow[OrderSndRcvJnlSchema.ct_Col_SubstPartsNo] = UoeCommonFnc.ToStringFromByteStrAry(hatyu.hdata[i].khb);

						//回答品番
						dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerPartsNo] = UoeCommonFnc.ToStringFromByteStrAry(hatyu.hdata[i].bhb);

						//回答品名
						dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerPartsName] = UoeCommonFnc.ToStringFromByteStrAry(hatyu.hdata[i].knm);
					}
					
					//数量(注文数)
					dataRow[OrderSndRcvJnlSchema.ct_Col_AcceptAnOrderCnt] = UoeCommonFnc.ToDoubleFromByteStrAry(hatyu.hdata[i].hasu);

					//BO区分
					dataRow[OrderSndRcvJnlSchema.ct_Col_BoCode] = UoeCommonFnc.ToStringFromByteStrAry(hatyu.hdata[i].bo);

					//原価単価（仕切り単価）
                    dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerSalesUnitCost] = UoeCommonFnc.ToDoubleFromByteStrAry(hatyu.hdata[i].sktan);

					// 適用（定価） Ｌ／Ｐ
                    dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerListPrice] = UoeCommonFnc.ToDoubleFromByteStrAry(hatyu.hdata[i].teika);

					// メーカーフォロー数
					dataRow[OrderSndRcvJnlSchema.ct_Col_MakerFollowCnt] = UoeCommonFnc.ToInt32FromByteStrAry(hatyu.hdata[i].mksu);

					// 出荷情報(伝票、出荷数、在庫数)
					//vhatsu_kyo( ii );	/* 伝票、出荷数、在庫数ｾｯﾄ	*/

					int hFlg = 0;	// 本部     0:未設定 1:設定済
					int sFlg = 0;	// サブ本部 0:未設定 1:設定済

					for (int ix=0; ix < hatyu.hdata[i].syk.Length; ix++ )
					{
						string kcd = UoeCommonFnc.ToStringFromByteStrAry(hatyu.hdata[i].syk[ix].kcd);	//拠点コード
						string dno = UoeCommonFnc.ToStringFromByteStrAry(hatyu.hdata[i].syk[ix].dno);	//伝票Ｎｏ．
						int ssu = UoeCommonFnc.ToInt32FromByteStrAry(hatyu.hdata[i].syk[ix].ssu);		//出荷数
						int zsu = UoeCommonFnc.ToInt32FromByteStrAry(hatyu.hdata[i].syk[ix].zsu);		//在庫数

						if( kcd.Trim() == "" ) 
						{
							continue;
						}

						//kcd = "0" + kcd;

						//発注先マスタの担当拠点と同一の場合
                        if (uOESupplier.MazdaSectionCode.Trim() == kcd.Trim())
						{
							dataRow[OrderSndRcvJnlSchema.ct_Col_MazdaUOEShipSectCd1] = kcd;	//拠点コード
							dataRow[OrderSndRcvJnlSchema.ct_Col_UOESectionSlipNo] = dno;	//伝票Ｎｏ．
							dataRow[OrderSndRcvJnlSchema.ct_Col_UOESectOutGoodsCnt] = ssu;	//出荷数
							dataRow[OrderSndRcvJnlSchema.ct_Col_UOESectStockCnt] = zsu;		//在庫数
						}

						// サブ本部
						else if ( sFlg == 0 )
						{
							sFlg = 1;	// サブ本部セット済み

							dataRow[OrderSndRcvJnlSchema.ct_Col_MazdaUOEShipSectCd2] = kcd;	//拠点コード
							dataRow[OrderSndRcvJnlSchema.ct_Col_BOSlipNo1] = dno;			//伝票Ｎｏ．
							dataRow[OrderSndRcvJnlSchema.ct_Col_BOShipmentCnt1] = ssu;		//出荷数
							dataRow[OrderSndRcvJnlSchema.ct_Col_BOStockCount1] = zsu;		//在庫数
						}

						// 本部
						else if ( hFlg == 0 )
						{
							hFlg = 1;	// 本部セット済み

							dataRow[OrderSndRcvJnlSchema.ct_Col_MazdaUOEShipSectCd3] = kcd;	//拠点コード
							dataRow[OrderSndRcvJnlSchema.ct_Col_BOSlipNo2] = dno;			//伝票Ｎｏ．
							dataRow[OrderSndRcvJnlSchema.ct_Col_BOShipmentCnt2] = ssu;		//出荷数
							dataRow[OrderSndRcvJnlSchema.ct_Col_BOStockCount2] = zsu;		//在庫数
						}
					}

					// 在庫（拠点ｺｰﾄﾞ）	１－７セット
					for (int j=0; j < 7; j++)
					{
						string kcd = UoeCommonFnc.ToStringFromByteStrAry(hatyu.hdata[i].zaih[j].kcd);
						if(kcd == "  ")
						{
							continue;
						}

						switch(j)
						{
							case 0:
								dataRow[OrderSndRcvJnlSchema.ct_Col_MazdaUOESectCd1] = kcd;
								break;
							case 1:
								dataRow[OrderSndRcvJnlSchema.ct_Col_MazdaUOESectCd2] = kcd;
								break;
							case 2:
								dataRow[OrderSndRcvJnlSchema.ct_Col_MazdaUOESectCd3] = kcd;
								break;
							case 3:
								dataRow[OrderSndRcvJnlSchema.ct_Col_MazdaUOESectCd4] = kcd;
								break;
							case 4:
								dataRow[OrderSndRcvJnlSchema.ct_Col_MazdaUOESectCd5] = kcd;
								break;
							case 5:
								dataRow[OrderSndRcvJnlSchema.ct_Col_MazdaUOESectCd6] = kcd;
								break;
							case 6:
								dataRow[OrderSndRcvJnlSchema.ct_Col_MazdaUOESectCd7] = kcd;
								break;
						}
					}
					
					// 在庫（在庫数）	１－７セット
					dataRow[OrderSndRcvJnlSchema.ct_Col_MazdaUOEStockCnt1] = UoeCommonFnc.ToInt32FromByteStrAry(hatyu.hdata[i].zaih[0].zsu);
					dataRow[OrderSndRcvJnlSchema.ct_Col_MazdaUOEStockCnt2] = UoeCommonFnc.ToInt32FromByteStrAry(hatyu.hdata[i].zaih[1].zsu);
					dataRow[OrderSndRcvJnlSchema.ct_Col_MazdaUOEStockCnt3] = UoeCommonFnc.ToInt32FromByteStrAry(hatyu.hdata[i].zaih[2].zsu);
					dataRow[OrderSndRcvJnlSchema.ct_Col_MazdaUOEStockCnt4] = UoeCommonFnc.ToInt32FromByteStrAry(hatyu.hdata[i].zaih[3].zsu);
					dataRow[OrderSndRcvJnlSchema.ct_Col_MazdaUOEStockCnt5] = UoeCommonFnc.ToInt32FromByteStrAry(hatyu.hdata[i].zaih[4].zsu);
					dataRow[OrderSndRcvJnlSchema.ct_Col_MazdaUOEStockCnt6] = UoeCommonFnc.ToInt32FromByteStrAry(hatyu.hdata[i].zaih[5].zsu);
					dataRow[OrderSndRcvJnlSchema.ct_Col_MazdaUOEStockCnt7] = UoeCommonFnc.ToInt32FromByteStrAry(hatyu.hdata[i].zaih[6].zsu);
					
					//コメント(ラインエラーメッセージ)
					dataRow[OrderSndRcvJnlSchema.ct_Col_LineErrorMassage] = UoeCommonFnc.ToStringFromByteStrAry(hatyu.hdata[i].ermsg);
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

				//ヘッダー部
				ms.Read(hatyu.jkbn, 0, hatyu.jkbn.Length); // 情報区分						
				ms.Read(hatyu.seq_no, 0, hatyu.seq_no.Length); // テキストシーケンス番号		
				ms.Read(hatyu.text_len, 0, hatyu.text_len.Length); // テキスト長					
				ms.Read(hatyu.dkbn, 0, hatyu.dkbn.Length); // 電文区分						
				ms.Read(hatyu.kekka, 0, hatyu.kekka.Length); // 処理結果						
				ms.Read(hatyu.tokbn, 0, hatyu.tokbn.Length); // 問合せ／応答区分				
				ms.Read(hatyu.g_id, 0, hatyu.g_id.Length); // 業務ＩＤ						
				ms.Read(hatyu.g_pass, 0, hatyu.g_pass.Length); // 業務パスワード				
				ms.Read(hatyu.prog_ver, 0, hatyu.prog_ver.Length); // 端末プログラムバージョン番号	
				ms.Read(hatyu.kkbn, 0, hatyu.kkbn.Length); // 継続区分						
				ms.Read(hatyu.h_id, 0, hatyu.h_id.Length); // 取引ＩＤ						
				ms.Read(hatyu.ext, 0, hatyu.ext.Length); // 拡張エリア					
				ms.Read(hatyu.gsk, 0, hatyu.gsk.Length); // 業務処理結果					
				ms.Read(hatyu.gsf, 0, hatyu.gsf.Length); // 業務継続フラグ				
				ms.Read(hatyu.seq, 0, hatyu.seq.Length); // シーケンスＮＯ				
				ms.Read(hatyu.bymd, 0, hatyu.bymd.Length); // 端末入力日付・時間			
				ms.Read(hatyu.ymdhms, 0, hatyu.ymdhms.Length); // ホスト日付・時間				

				ms.Read(hatyu.nhkb, 0, hatyu.nhkb.Length); // 納品区分						
				ms.Read(hatyu.rem1, 0, hatyu.rem1.Length); // リマーク						
				ms.Read(hatyu.kyoten, 0, hatyu.kyoten.Length); // 指定拠点						
				ms.Read(hatyu.head_ext, 0, hatyu.head_ext.Length); // ヘッド拡張エリア				

				//エラー部
                if ((hatyu.kekka[0] != 0x00)
                || (hatyu.gsk[0] != 0x00))
                {
                    HERR Herr = hatyu.herr;

                    ms.Read(Herr.ermsg, 0, Herr.ermsg.Length); // エラーメッセージ				
                    ms.Read(Herr.khb, 0, Herr.khb.Length); // 部番							
                    ms.Read(Herr.hasu, 0, Herr.hasu.Length); // 注文数						
                    ms.Read(Herr.bo, 0, Herr.bo.Length); // ＢＯ区分						
                }
                //明細部
                else
                {
                    for (int i = 0; i < hatyu.hdata.Length; i++)
                    {
                        HDATA Hdata = hatyu.hdata[i];

                        ms.Read(Hdata.khb, 0, Hdata.khb.Length); // 品番							
                        ms.Read(Hdata.hasu, 0, Hdata.hasu.Length); // 注文数						
                        ms.Read(Hdata.syk_max, 0, Hdata.syk_max.Length); // 出荷数合計					
                        ms.Read(Hdata.mksu, 0, Hdata.mksu.Length); // ＢＯ数						
                        ms.Read(Hdata.bo, 0, Hdata.bo.Length); // ＢＯ区分						
                        ms.Read(Hdata.knm, 0, Hdata.knm.Length); // 部品名						
                        ms.Read(Hdata.bhb, 0, Hdata.bhb.Length); // 部品番号（注文）				
                        ms.Read(Hdata.gokan, 0, Hdata.gokan.Length); // 互換性コード					
                        ms.Read(Hdata.sktan, 0, Hdata.sktan.Length); // 仕切り単価					
                        ms.Read(Hdata.teika, 0, Hdata.teika.Length); // 希望小売価格					

                        // 出荷情報	構造体
                        for (int j = 0; j < Hdata.syk.Length; j++)
                        {
                            SYK Syk = hatyu.hdata[i].syk[j];

                            ms.Read(Syk.kcd, 0, Syk.kcd.Length); // 拠点コード					
                            ms.Read(Syk.dno, 0, Syk.dno.Length); // 伝票Ｎｏ．					
                            ms.Read(Syk.ssu, 0, Syk.ssu.Length); // 出荷数						
                            ms.Read(Syk.zsu, 0, Syk.zsu.Length); // 在庫数						
                        }

                        // 在庫情報	構造体
                        for (int j = 0; j < Hdata.zaih.Length; j++)
                        {
                            ZAIH Zaih = hatyu.hdata[i].zaih[j];

                            ms.Read(Zaih.kcd, 0, Zaih.kcd.Length); // 拠点コード					
                            ms.Read(Zaih.zsu, 0, Zaih.zsu.Length); // 在庫数						
                        }

                        ms.Read(Hdata.ermsg, 0, Hdata.ermsg.Length); // コメント						
                        ms.Read(Hdata.l_ext, 0, Hdata.l_ext.Length);// ライン拡張エリア
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

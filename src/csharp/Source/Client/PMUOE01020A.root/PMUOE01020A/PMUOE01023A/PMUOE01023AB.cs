//****************************************************************************//
// プログラム名称   : ＵＯＥ受信編集＜発注＞（三菱）アクセスクラス
// プログラム概要   : ＵＯＥ受信編集＜発注＞（三菱）を行う
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
	/// ＵＯＥ受信編集＜発注＞（三菱）アクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : ＵＯＥ受信編集（三菱）アクセスクラス</br>
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

		# region ＵＯＥ受信編集＜発注＞（三菱）
		/// <summary>
		/// ＵＯＥ受信編集＜発注＞（三菱）
		/// </summary>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        private int GetJnlOrder0301(out string message)
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
                    TelegramJnlOrder0301 telegramJnlOrder0301 = new TelegramJnlOrder0301();

                    //ＪＮＬ更新処理
                    foreach (UoeRecDtl dtl in uoeRecDtlList)
                    {
                        telegramJnlOrder0301.Telegram(_uoeRecHed.UOESupplierCd, dtl);
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

		# region ＵＯＥ受信電文作成＜発注＞（三菱）
		/// <summary>
		/// ＵＯＥ受信電文作成＜発注＞（三菱）
		/// </summary>
		public class TelegramJnlOrder0301 : UoeRecEdit0301Acs
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
			//struct	HATYU{
			//	struct	HEAD	head ;
			//	char	nhkb[1] ;					/* 納品区分						*/
			//	char	rem1[8] ;					/* リマーク						*/
			//	char	kyoten[2] ;					/* 指定拠点						*/
			//	char	kikbn[1] ;					/* 緊急区分						*/
			//	char	syamei[20] ;				/* 会社名						*/
			//	char	head_ext[20] ;				/* ヘッド拡張エリア				*/
			//	struct	HDATA	hdata[3] ;			/* ライン項目１～３				*/
			//};

			//明細部
			//struct	HDATA{
			//	char	khb[10] ;					/* 品番							*/
			//	char	knm[20] ;					/* 品名							*/
			//	char	sktan[7] ;					/* 仕切り単価					*/
			//	char	teika[7] ;					/* Ｌ／Ｐ						*/
			//	char	hasu[4] ;					/* 受注数料						*/
			//	char	kysu[4] ;					/* 出庫数						*/
			//	char	shsu[4] ;					/* サブ本部フォロー数			*/
			//	char	hosu[4] ;					/* 本部フォロー数				*/
			//	char	mksu[5] ;					/* メーカーフォロー数			*/
			//	char	mkzsu[4] ;					/* 未出荷数						*/
			//	char	szsu[5] ;					/* サブ本部在庫数				*/
			//	char	hzsu[5] ;					/* 本庫在庫数					*/
			//	char	kydno[5] ;					/* 拠点伝票ＮＯ					*/
			//	char	shdno[5] ;					/* サブ本部フォロー伝票ＮＯ		*/
			//	char	hodno[5] ;					/* 本部フォロー伝票ＮＯ			*/
			//	char	gokan[1] ;					/* 代替有無						*/
			//	char	bo[1] ;						/* ＢＯ区分						*/
			//	char	jhb[10] ;					/* 受注部番						*/
			//	char	ermsg[20] ;					/* エラーメッセージ				*/
			//	char	l_ext[3] ;					/* ライン拡張エリア				*/
			//};

			//エラー部
			//struct	HERR{
			//	struct	HEAD	head ;
			//	char	nhkb[1] ;					/* 納品区分						*/
			//	char	rem1[8] ;					/* リマーク						*/
			//	char	kyoten[2] ;					/* 指定拠点						*/
			//	char	kikbn[1] ;					/* 緊急区分						*/
			//	char	syamei[20] ;				/* 会社名						*/
			//	char	head_ext[20] ;				/* ヘッド拡張エリア				*/
			//	char	ermsg[20] ;					/* エラーメッセージ				*/
			//	char	khb[10] ;					/* 部番							*/
			//	char	hasu[4] ;					/* 数量							*/
			//	char	bo[1] ;						/* ＢＯ区分						*/
			//};
			# endregion

			# region Const Members
			private const Int32 ctBufLen = 3;		//明細バッファサイズ
			# endregion

			# region 電文領域クラス
			/// <summary>
			/// エラー電文領域＜ライン＞
			/// </summary>
			private class ER_H
			{
				public byte[] ermsg = new byte[20] ;			// エラーメッセージ				
				public byte[] khb = new byte[10] ;				// 部番							
				public byte[] hasu = new byte[4] ;				// 数量							
				public byte[] bo = new byte[1];					// ＢＯ区分						
	
				public ER_H()
				{
					Clear(0x00);
				}
				public void Clear(byte cd)
				{
					UoeCommonFnc.MemSet(ref ermsg, cd, ermsg.Length);			// エラーメッセージ				
					UoeCommonFnc.MemSet(ref khb, cd, khb.Length);				// 部番							
					UoeCommonFnc.MemSet(ref hasu, cd, hasu.Length);				// 数量							
					UoeCommonFnc.MemSet(ref bo, cd, bo.Length);					// ＢＯ区分						
				}
			}
	
			/// <summary>
			/// 発注電文領域＜ライン＞
			/// </summary>
			private class LN_H
			{
				public byte[] khb = new byte[10];				// 品番							
				public byte[] knm = new byte[20];				// 品名							
				public byte[] sktan = new byte[7];				// 仕切り単価					
				public byte[] teika = new byte[7];				// Ｌ／Ｐ						
				public byte[] hasu = new byte[4];				// 受注数料						
				public byte[] kysu = new byte[4];				// 出庫数						
				public byte[] shsu = new byte[4];				// サブ本部フォロー数			
				public byte[] hosu = new byte[4];				// 本部フォロー数				
				public byte[] mksu = new byte[5];				// メーカーフォロー数			
				public byte[] mkzsu = new byte[4];				// 未出荷数						
				public byte[] szsu = new byte[5];				// サブ本部在庫数				
				public byte[] hzsu = new byte[5];				// 本庫在庫数					
				public byte[] kydno = new byte[5];				// 拠点伝票ＮＯ					
				public byte[] shdno = new byte[5];				// サブ本部フォロー伝票ＮＯ		
				public byte[] hodno = new byte[5];				// 本部フォロー伝票ＮＯ			
				public byte[] gokan = new byte[1];				// 代替有無						
				public byte[] bo = new byte[1];					// ＢＯ区分						
				public byte[] jhb = new byte[10];				// 受注部番						
				public byte[] ermsg = new byte[20];				// エラーメッセージ				
				public byte[] l_ext = new byte[3];				// ライン拡張エリア				

				public LN_H()
				{
					Clear(0x00);
				}
				public void Clear(byte cd)
				{
					UoeCommonFnc.MemSet(ref khb, cd, khb.Length);				// 品番							
					UoeCommonFnc.MemSet(ref knm, cd, knm.Length);				// 品名							
					UoeCommonFnc.MemSet(ref sktan, cd, sktan.Length);			// 仕切り単価					
					UoeCommonFnc.MemSet(ref teika, cd, teika.Length);			// Ｌ／Ｐ						
					UoeCommonFnc.MemSet(ref hasu, cd, hasu.Length);				// 受注数料						
					UoeCommonFnc.MemSet(ref kysu, cd, kysu.Length);				// 出庫数						
					UoeCommonFnc.MemSet(ref shsu, cd, shsu.Length);				// サブ本部フォロー数			
					UoeCommonFnc.MemSet(ref hosu, cd, hosu.Length);				// 本部フォロー数				
					UoeCommonFnc.MemSet(ref mksu, cd, mksu.Length);				// メーカーフォロー数			
					UoeCommonFnc.MemSet(ref mkzsu, cd, mkzsu.Length);			// 未出荷数						
					UoeCommonFnc.MemSet(ref szsu, cd, szsu.Length);				// サブ本部在庫数				
					UoeCommonFnc.MemSet(ref hzsu, cd, hzsu.Length);				// 本庫在庫数					
					UoeCommonFnc.MemSet(ref kydno, cd, kydno.Length);			// 拠点伝票ＮＯ					
					UoeCommonFnc.MemSet(ref shdno, cd, shdno.Length);			// サブ本部フォロー伝票ＮＯ		
					UoeCommonFnc.MemSet(ref hodno, cd, hodno.Length);			// 本部フォロー伝票ＮＯ			
					UoeCommonFnc.MemSet(ref gokan, cd, gokan.Length);			// 代替有無						
					UoeCommonFnc.MemSet(ref bo, cd, bo.Length);					// ＢＯ区分						
					UoeCommonFnc.MemSet(ref jhb, cd, jhb.Length);				// 受注部番						
					UoeCommonFnc.MemSet(ref ermsg, cd, ermsg.Length);			// エラーメッセージ				
					UoeCommonFnc.MemSet(ref l_ext, cd, l_ext.Length);			// ライン拡張エリア				
				}
			}

			/// <summary>
			/// 発注電文領域＜本体＞
			/// </summary>
			private class DN_H
			{
				//HEAD
				public byte[]	jkbn = new byte[1] ;				// 情報区分						
				public byte[]	seq_no = new byte[2] ;				// テキストシーケンス番号		
				public byte[] text_len = new byte[2];				// テキスト長					
				public byte[]	dkbn = new byte[1] ;				// 電文区分						
				public byte[]	kekka = new byte[1] ;				// 処理結果						
				public byte[]	tokbn = new byte[1] ;				// 問合せ／応答区分				
				public byte[]	g_id = new byte[12] ;				// 業務ＩＤ						
				public byte[]	g_pass = new byte[6] ;				// 業務パスワード				
				public byte[]	prog_ver = new byte[3] ;			// 端末プログラムバージョン番号	
				public byte[]	kkbn = new byte[1] ;				// 継続区分						
				public byte[]	h_id = new byte[3] ;				// 取引ＩＤ						
				public byte[]	ext = new byte[15] ;				// 拡張エリア					
				public byte[]	gsk = new byte[1] ;					// 業務処理結果					
				public byte[]	gsf = new byte[1] ;					// 業務継続フラグ				
				public byte[]	seq = new byte[3] ;					// シーケンスＮＯ				
				public byte[]	bymd = new byte[4] ;				// 端末入力日付・時間			
				public byte[]	ymdhms = new byte[8] ;				// ホスト日付・時間				

				//HATYU
				public byte[]	nhkb = new byte[1] ;				// 納品区分						
				public byte[]	rem1 = new byte[8] ;				// リマーク						
				public byte[]	kyoten = new byte[2] ;				// 指定拠点						
				public byte[]	kikbn = new byte[1] ;				// 緊急区分						
				public byte[]	syamei = new byte[20] ;				// 会社名						
				public byte[]	head_ext = new byte[20] ;			// ヘッド拡張エリア				

				public LN_H[] ln_h = new LN_H[ctBufLen];			// 明細

				public ER_H er_h = new ER_H();						// エラー

				/// <summary>	
				/// コンストラクター
				/// </summary>
				public DN_H()
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

					//明細部
					for (int i = 0; i < ctBufLen; i++)
					{
                        if (ln_h[i] == null)
                        {
                            ln_h[i] = new LN_H();
                        }
                        else
                        {
                            ln_h[i].Clear(0x00);
                        }
					}

					//エラー部
					er_h.Clear(0x00);
				}
			}

			# endregion

			# region Private Members
			//変数
			private Int32 _detailMax = 0;
			private DN_H dn_h = new DN_H(); 
			# endregion

			# region Constructors
			/// <summary>
			/// コンストラクタ
			/// </summary>
			public TelegramJnlOrder0301()
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

				dn_h.Clear(0x00);
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
					DataRow dataRow = _uoeSndRcvJnlAcs.JnlOrderTblRead(
													uOESupplierCd,
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

					//回答電文エラー処理
					if ((dn_h.kekka[0] != 0x00)
					|| (dn_h.gsk[0] != 0x00))
					{
						string errMessage = "";

						if (dn_h.gsk[0] == 0x01)
						{
							errMessage = UoeCommonFnc.ToStringFromByteStrAry(dn_h.er_h.ermsg);

						}
						else
						{
							errMessage = GetHeadErrorMassage(dn_h.gsk[0]);
						}

						//ヘッドエラーメッセージ
						dataRow[OrderSndRcvJnlSchema.ct_Col_HeadErrorMassage] = errMessage;

						//品名
						dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerPartsName] = errMessage;

						continue;
					}

					// 納品区分
                    dataRow[OrderSndRcvJnlSchema.ct_Col_UOEDeliGoodsDiv] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.nhkb);
	
					// リマーク
					dataRow[OrderSndRcvJnlSchema.ct_Col_UoeRemark1] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.rem1);
					
					/* 指定拠点					*/
					dataRow[OrderSndRcvJnlSchema.ct_Col_UOEResvdSection] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.kyoten);

					//代替有無チェック＆セット
					int sw = 0;	//0:代替なし 1:代替あり

					//代替ﾏｰｸ
					//代替あり
					if ((dn_h.ln_h[i].gokan[0] != 0x00)
					&& (dn_h.ln_h[i].gokan[0] != 0x20)
					&& (dn_h.ln_h[i].gokan[0] != 0x30))
					{
						dataRow[OrderSndRcvJnlSchema.ct_Col_UOESubstMark] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].gokan);
						sw = 1;
					}
					else
					{
    					sw = 0;
					}

					//代替なし
					if (sw == 0)
					{
						//回答品番
						dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerPartsNo] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].khb);

						//回答品名
						dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerPartsName] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].knm);
					}
					//代替あり
					else
					{
						//代替品番
						dataRow[OrderSndRcvJnlSchema.ct_Col_SubstPartsNo] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].khb);

						//回答品番
						dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerPartsNo] = dataRow[OrderSndRcvJnlSchema.ct_Col_GoodsNo];

						//回答品名
						dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerPartsName] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].knm);
					}

					//原価単価（仕切り単価）
                    dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerSalesUnitCost] = UoeCommonFnc.ToDoubleFromByteStrAry(dn_h.ln_h[i].sktan);

					//適用（定価） Ｌ／Ｐ
                    dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerListPrice] = UoeCommonFnc.ToDoubleFromByteStrAry(dn_h.ln_h[i].teika);
	
					//受注数量
					dataRow[OrderSndRcvJnlSchema.ct_Col_AcceptAnOrderCnt] = UoeCommonFnc.ToDoubleFromByteStrAry(dn_h.ln_h[i].hasu);

					//UOE拠点出庫数
					dataRow[OrderSndRcvJnlSchema.ct_Col_UOESectOutGoodsCnt] = UoeCommonFnc.ToInt32FromByteStrAry(dn_h.ln_h[i].kysu);

					//BO出庫数1(サブ本部フォロー数)
					dataRow[OrderSndRcvJnlSchema.ct_Col_BOShipmentCnt1] =  UoeCommonFnc.ToInt32FromByteStrAry(dn_h.ln_h[i].shsu);
					
					//BO出庫数1(本部フォロー数)
					dataRow[OrderSndRcvJnlSchema.ct_Col_BOShipmentCnt2] = UoeCommonFnc.ToInt32FromByteStrAry(dn_h.ln_h[i].hosu);
					
					//メーカーフォロー数
					dataRow[OrderSndRcvJnlSchema.ct_Col_MakerFollowCnt] = UoeCommonFnc.ToInt32FromByteStrAry(dn_h.ln_h[i].mksu);
					
					//未出荷数
					dataRow[OrderSndRcvJnlSchema.ct_Col_NonShipmentCnt] = UoeCommonFnc.ToInt32FromByteStrAry(dn_h.ln_h[i].mkzsu);
					
					//BO在庫数1(サブ本部在庫数)
					Int32 szsuTemp = UoeCommonFnc.ToInt32FromByteStrAry(dn_h.ln_h[i].szsu);
					if ( szsuTemp > 999 )	szsuTemp = 999;
					dataRow[OrderSndRcvJnlSchema.ct_Col_BOStockCount1] = szsuTemp;

					//BO在庫数2(本庫在庫数)
					Int32 hzsuTemp = UoeCommonFnc.ToInt32FromByteStrAry(dn_h.ln_h[i].hzsu);
					if ( hzsuTemp > 999 )	hzsuTemp = 999;
					dataRow[OrderSndRcvJnlSchema.ct_Col_BOStockCount2] = hzsuTemp;
					
					//UOE拠点伝票番号
					dataRow[OrderSndRcvJnlSchema.ct_Col_UOESectionSlipNo] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].kydno);

					//BO伝票番号１(サブ本部フォロー伝票ＮＯ)
					dataRow[OrderSndRcvJnlSchema.ct_Col_BOSlipNo1] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].shdno);

					//BO伝票番号２(本部フォロー伝票ＮＯ)
					dataRow[OrderSndRcvJnlSchema.ct_Col_BOSlipNo2] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].hodno);

					//BO区分
					dataRow[OrderSndRcvJnlSchema.ct_Col_BoCode] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].bo);

					//ラインエラーメッセージ
					dataRow[OrderSndRcvJnlSchema.ct_Col_LineErrorMassage] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].ermsg);
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
				//HEAD
				ms.Read(dn_h.jkbn, 0, dn_h.jkbn.Length); 				            // 情報区分						
				ms.Read(dn_h.seq_no, 0, dn_h.seq_no.Length);                        // テキストシーケンス番号		
				ms.Read(dn_h.text_len, 0, dn_h.text_len.Length);                    // テキスト長					
				ms.Read(dn_h.dkbn, 0, dn_h.dkbn.Length);                            // 電文区分						
				ms.Read(dn_h.kekka, 0, dn_h.kekka.Length);                          // 処理結果						
				ms.Read(dn_h.tokbn, 0, dn_h.tokbn.Length);                          // 問合せ／応答区分				
				ms.Read(dn_h.g_id, 0, dn_h.g_id.Length);                            // 業務ＩＤ						
				ms.Read(dn_h.g_pass, 0, dn_h.g_pass.Length);                        // 業務パスワード				
				ms.Read(dn_h.prog_ver, 0, dn_h.prog_ver.Length);                    // 端末プログラムバージョン番号	
				ms.Read(dn_h.kkbn, 0, dn_h.kkbn.Length);                            // 継続区分						
				ms.Read(dn_h.h_id, 0, dn_h.h_id.Length);                            // 取引ＩＤ						
				ms.Read(dn_h.ext, 0, dn_h.ext.Length);                              // 拡張エリア					
				ms.Read(dn_h.gsk, 0, dn_h.gsk.Length);                              // 業務処理結果					
				ms.Read(dn_h.gsf, 0, dn_h.gsf.Length);                              // 業務継続フラグ				
				ms.Read(dn_h.seq, 0, dn_h.seq.Length);                              // シーケンスＮＯ				
				ms.Read(dn_h.bymd, 0, dn_h.bymd.Length);                            // 端末入力日付・時間			
				ms.Read(dn_h.ymdhms, 0, dn_h.ymdhms.Length);                        // ホスト日付・時間				
				//HATYU
				ms.Read(dn_h.nhkb, 0, dn_h.nhkb.Length);                            // 納品区分						
				ms.Read(dn_h.rem1, 0, dn_h.rem1.Length);                            // リマーク						
				ms.Read(dn_h.kyoten, 0, dn_h.kyoten.Length);                        // 指定拠点						
				ms.Read(dn_h.kikbn, 0, dn_h.kikbn.Length);                          // 緊急区分						
				ms.Read(dn_h.syamei, 0, dn_h.syamei.Length);                        // 会社名						
				ms.Read(dn_h.head_ext, 0, dn_h.head_ext.Length);					// ヘッド拡張エリア				

				//エラー部
				if((dn_h.kekka[0] != 0x00)
				|| (dn_h.gsk[0] != 0x00))
				{
					ms.Read(dn_h.er_h.ermsg, 0, dn_h.er_h.ermsg.Length); 			// エラーメッセージ				
					ms.Read(dn_h.er_h.khb, 0, dn_h.er_h.khb.Length); 				// 部番							
					ms.Read(dn_h.er_h.hasu, 0, dn_h.er_h.hasu.Length); 				// 数量							
					ms.Read(dn_h.er_h.bo, 0, dn_h.er_h.bo.Length); 					// ＢＯ区分						
				}
				//明細部
				else
				{
					for (int i = 0; i < ctBufLen; i++)
					{
						ms.Read(dn_h.ln_h[i].khb, 0, dn_h.ln_h[i].khb.Length);      // 品番							
						ms.Read(dn_h.ln_h[i].knm, 0, dn_h.ln_h[i].knm.Length);      // 品名							
						ms.Read(dn_h.ln_h[i].sktan, 0, dn_h.ln_h[i].sktan.Length);  // 仕切り単価					
						ms.Read(dn_h.ln_h[i].teika, 0, dn_h.ln_h[i].teika.Length);  // Ｌ／Ｐ						
						ms.Read(dn_h.ln_h[i].hasu, 0, dn_h.ln_h[i].hasu.Length);    // 受注数料						
						ms.Read(dn_h.ln_h[i].kysu, 0, dn_h.ln_h[i].kysu.Length);    // 出庫数						
						ms.Read(dn_h.ln_h[i].shsu, 0, dn_h.ln_h[i].shsu.Length);    // サブ本部フォロー数			
						ms.Read(dn_h.ln_h[i].hosu, 0, dn_h.ln_h[i].hosu.Length);    // 本部フォロー数				
						ms.Read(dn_h.ln_h[i].mksu, 0, dn_h.ln_h[i].mksu.Length);    // メーカーフォロー数			
						ms.Read(dn_h.ln_h[i].mkzsu, 0, dn_h.ln_h[i].mkzsu.Length);  // 未出荷数						
						ms.Read(dn_h.ln_h[i].szsu, 0, dn_h.ln_h[i].szsu.Length);    // サブ本部在庫数				
						ms.Read(dn_h.ln_h[i].hzsu, 0, dn_h.ln_h[i].hzsu.Length);    // 本庫在庫数					
						ms.Read(dn_h.ln_h[i].kydno, 0, dn_h.ln_h[i].kydno.Length);  // 拠点伝票ＮＯ					
						ms.Read(dn_h.ln_h[i].shdno, 0, dn_h.ln_h[i].shdno.Length);  // サブ本部フォロー伝票ＮＯ		
						ms.Read(dn_h.ln_h[i].hodno, 0, dn_h.ln_h[i].hodno.Length);  // 本部フォロー伝票ＮＯ			
						ms.Read(dn_h.ln_h[i].gokan, 0, dn_h.ln_h[i].gokan.Length);  // 代替有無						
						ms.Read(dn_h.ln_h[i].bo, 0, dn_h.ln_h[i].bo.Length);        // ＢＯ区分						
						ms.Read(dn_h.ln_h[i].jhb, 0, dn_h.ln_h[i].jhb.Length);      // 受注部番						
						ms.Read(dn_h.ln_h[i].ermsg, 0, dn_h.ln_h[i].ermsg.Length);  // エラーメッセージ				
						ms.Read(dn_h.ln_h[i].l_ext, 0, dn_h.ln_h[i].l_ext.Length);  // ライン拡張エリア				
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
					case 0x88:						//-- "ﾙｽﾊﾞﾝｴﾗｰ" --
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

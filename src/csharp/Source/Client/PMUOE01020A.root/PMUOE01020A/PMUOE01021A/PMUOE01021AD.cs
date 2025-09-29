//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : ＵＯＥ受信編集＜在庫＞（トヨタＰＤ４）アクセスクラス
// プログラム概要   : ＵＯＥ受信編集＜在庫＞（トヨタＰＤ４）を行う
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
	/// ＵＯＥ受信編集＜在庫＞（トヨタＰＤ４）アクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : ＵＯＥ受信編集＜在庫＞（トヨタＰＤ４）アクセスクラス</br>
	/// <br>Programmer : 96186 立花裕輔</br>
	/// <br>Date       : 2008.05.26</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// <br>2008.05.26 men 新規作成</br>
	/// </remarks>
	public partial class UoeRecEdit0102Acs
	{
		// ===================================================================================== //
		// プライベートメソッド
		// ===================================================================================== //
		# region Private Methods

		# region ＵＯＥ受信編集＜在庫＞（トヨタＰＤ４）
		/// <summary>
		/// ＵＯＥ受信編集＜在庫＞（トヨタＰＤ４）
		/// </summary>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        private int GetJnlStock0102(out string message)
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
    				TelegramJnlStock0102 telegramJnlStock0102 = new TelegramJnlStock0102();

				    foreach (UoeRecDtl dtl in uoeRecDtlList)
				    {
					    telegramJnlStock0102.Telegram(_uoeRecHed.UOESupplierCd, dtl);
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

		# region ＵＯＥ受信電文作成＜在庫＞（トヨタＰＤ４）
		/// <summary>
		/// ＵＯＥ受信電文作成＜在庫＞（トヨタＰＤ４）
		/// </summary>
		public class TelegramJnlStock0102 : UoeRecEdit0102Acs
		{
			# region ＰＭ７ソース
			//									/*-- 電文領域...ﾗｲﾝ...在確 ---*/
			//struct	LN_Z {					/* 228ﾊﾞｲﾄ                    */
			//	char	hb[12];					/* ﾗｲﾝ      品番              */
			//	char	hn[30];					/*          品名              */
			//	char	l_p[7];					/*          L_P               */
			//	char	chscd[1];				/*          中止CD            */
			//	char	daicd[1];				/*          代替CD            */
			//	char	Akakk[7];				/*          A価格             */
			//	char	hozsu[7];				/*          本部在庫          */
			//	char	idosu[7];				/*          移動中数          */
			//	char	nkicd[1];				/*          納期CD            */
			//	char	kyzsu[31][5];			/*          拠点在庫数02-32   */
			//};

			//									/*-- 電文領域...本体...在確 --*/
			//struct	DN_Z {					/* 51 +1368 +629 = 2048ﾊﾞｲﾄ   */
			//	char	jh;						/* ﾍｯﾀﾞ TTC  情報区分         */
			//	char	ts[2];					/*           ﾃｷｽﾄｼｰｹﾝｽ        */
			//	char	lg[2];					/*           ﾃｷｽﾄ長           */
			//	char	tr[3];					/*      ID   ﾄﾗﾝｻﾞｸｼｮﾝｺｰﾄﾞ    */
			//	char	res;					/*           処理結果         */
			//	char	seq[3];					/*           seq番号          */
			//	char	acd[7];					/*           相手先ｺｰﾄﾞ       */
			//	char	tcd[7];					/*           当方ｺｰﾄﾞ         */
			//	char	dttm[6];				/*           日付･時刻        */
			//	char	pass[6];				/*           ﾊﾟｽﾜｰﾄﾞ          */
			//	char	kflg;					/*           継続ﾌﾗｸﾞ         */
			//	char	rem3[12];				/*      ﾍｯﾄﾞ ﾘﾏｰｸ3            */
			//	struct	LN_Z	z[6];			/* ﾗｲﾝ       6*228=1368ﾊﾞｲﾄ   */
			//	char	dummy[629];				/* ﾗｲﾝ       dummy            */
			//};
			# endregion

			# region Const Members
			private const Int32 ctBufLen = 6;		//明細バッファサイズ
			private const Int32 ctDetailLen = 6;	//明細行数
            private const Int32 ctKyzsuLen = 31;    //拠点在庫数行カウンタ
			# endregion

			# region Private Members
			//変数
			private Int32 _detailMax = 0;
			private DN_Z dn_z = new DN_Z();
			# endregion

			# region 電文領域クラス
			/// <summary>
			/// 在庫電文領域＜ライン＞
			/// </summary>
			private class LN_Z
			{
				public byte[] hb = new byte[12];				// ﾗｲﾝ      品番              
				public byte[] hn = new byte[30];				//          品名              
				public byte[] l_p = new byte[7];				//          L_P               
				public byte[] chscd = new byte[1];				//          中止CD            
				public byte[] daicd = new byte[1];				//          代替CD            
				public byte[] Akakk = new byte[7];				//          A価格             
				public byte[] hozsu = new byte[7];				//          本部在庫          
				public byte[] idosu = new byte[7];				//          移動中数          
				public byte[] nkicd = new byte[1];				//          納期CD            
                public byte[][] kyzsu = new byte[ctKyzsuLen][];			//          拠点在庫数02-32   

				public LN_Z()
				{
                    for (int j = 0; j < ctKyzsuLen; j++)
					{
						kyzsu[j] = new byte[5];			//          拠点在庫数02-32   
					}

					Clear(0x00);
				}
				public void Clear(byte cd)
				{
					UoeCommonFnc.MemSet(ref hb, cd, hb.Length);			// ﾗｲﾝ      品番              
					UoeCommonFnc.MemSet(ref hn, cd, hn.Length);			//          品名              
					UoeCommonFnc.MemSet(ref l_p, cd, l_p.Length);		//          L_P               
					UoeCommonFnc.MemSet(ref chscd, cd, chscd.Length);	//          中止CD            
					UoeCommonFnc.MemSet(ref daicd, cd, daicd.Length);	//          代替CD            
					UoeCommonFnc.MemSet(ref Akakk, cd, Akakk.Length);	//          A価格             
					UoeCommonFnc.MemSet(ref hozsu, cd, hozsu.Length);	//          本部在庫          
					UoeCommonFnc.MemSet(ref idosu, cd, idosu.Length);	//          移動中数          
					UoeCommonFnc.MemSet(ref nkicd, cd, nkicd.Length);	//          納期CD            

                    for (int j = 0; j < ctKyzsuLen; j++)
					{
						UoeCommonFnc.MemSet(ref kyzsu[j], cd, kyzsu[j].Length);	//          拠点在庫数02-32   
					}
				}
			}

			/// <summary>
			/// 在庫電文領域＜本体＞
			/// </summary>
			private class DN_Z
			{
				public byte[] jh = new byte[1];			// ﾍｯﾀﾞ TTC  情報区分         
				public byte[] ts = new byte[2];			//           ﾃｷｽﾄｼｰｹﾝｽ        
				public byte[] lg = new byte[2];			//           ﾃｷｽﾄ長           
				public byte[] tr = new byte[3];			//      ID   ﾄﾗﾝｻﾞｸｼｮﾝｺｰﾄﾞ    
				public byte[] res = new byte[1];		//           処理結果         
				public byte[] seq = new byte[3];		//           seq番号          
				public byte[] acd = new byte[7];		//           相手先ｺｰﾄﾞ       
				public byte[] tcd = new byte[7];		//           当方ｺｰﾄﾞ         
				public byte[] dttm = new byte[6];		//           日付･時刻        
				public byte[] pass = new byte[6];		//           ﾊﾟｽﾜｰﾄﾞ          
				public byte[] kflg = new byte[1];		//           継続ﾌﾗｸﾞ         
				public byte[] rem3 = new byte[12];		//      ﾍｯﾄﾞ ﾘﾏｰｸ3            

				public LN_Z[] ln_z = new LN_Z[ctBufLen];// ﾗｲﾝ       14*10=140ﾊﾞｲﾄ

				public byte[]	dummy = new byte[629];	// ﾗｲﾝ       dummy            

				/// <summary>	
				/// コンストラクター
				/// </summary>
				public DN_Z()
				{
					Clear(0x00);
				}

				public void Clear(byte cd)
				{
					UoeCommonFnc.MemSet(ref jh, cd, jh.Length);			// ﾍｯﾀﾞ TTC  情報区分         
					UoeCommonFnc.MemSet(ref ts, cd, ts.Length);			//           ﾃｷｽﾄｼｰｹﾝｽ        
					UoeCommonFnc.MemSet(ref lg, cd, lg.Length);			//           ﾃｷｽﾄ長           
					UoeCommonFnc.MemSet(ref tr, cd, tr.Length);			//      ID   ﾄﾗﾝｻﾞｸｼｮﾝｺｰﾄﾞ    
					UoeCommonFnc.MemSet(ref res, cd, res.Length);		//           処理結果         
					UoeCommonFnc.MemSet(ref seq, cd, seq.Length);		//           seq番号          
					UoeCommonFnc.MemSet(ref acd, cd, acd.Length);		//           相手先ｺｰﾄﾞ       
					UoeCommonFnc.MemSet(ref tcd, cd, tcd.Length);		//           当方ｺｰﾄﾞ         
					UoeCommonFnc.MemSet(ref dttm, cd, dttm.Length);		//           日付･時刻        
					UoeCommonFnc.MemSet(ref pass, cd, pass.Length);		//           ﾊﾟｽﾜｰﾄﾞ          
					UoeCommonFnc.MemSet(ref kflg, cd, kflg.Length);		//           継続ﾌﾗｸﾞ         
					UoeCommonFnc.MemSet(ref rem3, cd, rem3.Length);		//      ﾍｯﾄﾞ ﾘﾏｰｸ3            

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

					//dummy
					UoeCommonFnc.MemSet(ref dummy, cd, dummy.Length);	// ﾗｲﾝ       dummy            
				}
			}
			# endregion

			# region Constructors
			/// <summary>
			/// コンストラクタ
			/// </summary>
			public TelegramJnlStock0102()
			{
				for (int i = 0; i < ctBufLen; i++)
				{
				}
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
					Int32 lwk = TDateTime.DateTimeToLongDate(DateTime.Now);		//yyyymmdd
					lwk /= 1000000;	// yy
					lwk *= 1000000;	// yy000000

					byte[] byteYymmdd = new byte[6];

					for (int ix = 0; ix < byteYymmdd.Length; ix++)
					{
						byteYymmdd[ix] = dn_z.rem3[ix + 4];
					}
					Int32 int32Yymmdd = UoeCommonFnc.ToInt32FromByteStrAry(byteYymmdd);

					//電文自体にに日付がセットされている
					if (int32Yymmdd > 0)
					{
                        dataRow[StockSndRcvJnlSchema.ct_Col_ReceiveDate] = TDateTime.LongDateToDateTime(int32Yymmdd + lwk);
                    }
					//電文自体にに日付がセットされていない
					else
					{
						dataRow[StockSndRcvJnlSchema.ct_Col_ReceiveDate] = DateTime.Now;
					}

                    //受信時刻(HHMMSS)
                    int hHMMSS = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.dttm);
                    if (hHMMSS == 0)
                    {
                        hHMMSS = TDateTime.DateTimeToLongDate("HHMMSS", DateTime.Now);
                    }
                    dataRow[StockSndRcvJnlSchema.ct_Col_ReceiveTime] = hHMMSS;

					//ヘッドエラーあり
					if (dn_z.res[0] == 0x00)
					{
					}
					//ヘッドエラーなし
					else
					{
						string errMessage = GetHeadErrorMassage(dn_z.res[0]);

						//ヘッドエラーメッセージ
						dataRow[StockSndRcvJnlSchema.ct_Col_HeadErrorMassage] = errMessage;

						//ラインエラーメッセージ
						dataRow[StockSndRcvJnlSchema.ct_Col_LineErrorMassage] = errMessage;

						//品名
						dataRow[StockSndRcvJnlSchema.ct_Col_AnswerPartsName] = errMessage;
					}

					//代替なし
					if ((dn_z.ln_z[i].daicd[0] == 0x00)
					|| (dn_z.ln_z[i].daicd[0] == 0x20)
					|| (dn_z.ln_z[i].daicd[0] == 0x30))
					{
						//代替ﾏｰｸ
						//dataRow[StockSndRcvJnlSchema.ct_Col_UOESubstCode] = "0";

						//回答品番
						dataRow[StockSndRcvJnlSchema.ct_Col_AnswerPartsNo] = UoeCommonFnc.ToStringFromByteStrAry(dn_z.ln_z[i].hb);

						//回答品名
						if (dn_z.res[0] == 0x00)
						{
							dataRow[StockSndRcvJnlSchema.ct_Col_AnswerPartsName] = UoeCommonFnc.ToStringFromByteStrAry(dn_z.ln_z[i].hn);
						}
					}
					//代替あり
					else
					{
						//代替ﾏｰｸ
						dataRow[StockSndRcvJnlSchema.ct_Col_UOESubstCode] = UoeCommonFnc.ToStringFromByteStrAry(dn_z.ln_z[i].daicd);

						//代替品番
						dataRow[StockSndRcvJnlSchema.ct_Col_SubstPartsNo] = UoeCommonFnc.ToStringFromByteStrAry(dn_z.ln_z[i].hb);

						//回答品番
						dataRow[StockSndRcvJnlSchema.ct_Col_AnswerPartsNo] = UoeCommonFnc.ToStringFromByteStrAry(dn_z.ln_z[i].hn);

						//回答品名
						if (dn_z.res[0] == 0x00)
						{
							dataRow[StockSndRcvJnlSchema.ct_Col_AnswerPartsName] = UoeCommonFnc.ToStringFromByteStrAry(dn_z.ln_z[i].hb);
						}
					}

					//摘要L_P
                    dataRow[StockSndRcvJnlSchema.ct_Col_AnswerListPrice] = UoeCommonFnc.ToDoubleFromByteStrAry(dn_z.ln_z[i].l_p);

					//中止ｺｰﾄﾞ
					dataRow[StockSndRcvJnlSchema.ct_Col_UOEStopCd] = UoeCommonFnc.ToStringFromByteStrAry(dn_z.ln_z[i].chscd);

					//A価格 Double
                    dataRow[StockSndRcvJnlSchema.ct_Col_AnswerSalesUnitCost] = UoeCommonFnc.ToDoubleFromByteStrAry(dn_z.ln_z[i].Akakk);
                    dataRow[StockSndRcvJnlSchema.ct_Col_GoodsAPrice] = UoeCommonFnc.ToDoubleFromByteStrAry(dn_z.ln_z[i].Akakk);

					//納期ｺｰﾄﾞ
					dataRow[StockSndRcvJnlSchema.ct_Col_UOEDelivDateCd] = UoeCommonFnc.ToStringFromByteStrAry(dn_z.ln_z[i].nkicd);

					//在庫数00本部
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock1] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].hozsu);

					//在庫数01移動
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock2] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].idosu);

					//在庫数02-32
                    dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock3] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].kyzsu[0]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock4] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].kyzsu[1]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock5] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].kyzsu[2]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock6] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].kyzsu[3]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock7] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].kyzsu[4]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock8] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].kyzsu[5]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock9] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].kyzsu[6]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock10] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].kyzsu[7]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock11] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].kyzsu[8]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock12] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].kyzsu[9]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock13] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].kyzsu[10]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock14] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].kyzsu[11]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock15] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].kyzsu[12]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock16] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].kyzsu[13]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock17] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].kyzsu[14]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock18] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].kyzsu[15]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock19] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].kyzsu[16]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock20] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].kyzsu[17]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock21] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].kyzsu[18]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock22] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].kyzsu[19]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock23] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].kyzsu[20]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock24] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].kyzsu[21]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock25] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].kyzsu[22]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock26] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].kyzsu[23]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock27] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].kyzsu[24]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock28] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].kyzsu[25]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock29] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].kyzsu[26]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock30] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].kyzsu[27]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock31] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].kyzsu[28]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock32] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].kyzsu[29]);
					dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock33] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].kyzsu[30]);
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

				ms.Read(dn_z.jh, 0, dn_z.jh.Length);        // ﾍｯﾀﾞ TTC  情報区分         
				ms.Read(dn_z.ts, 0, dn_z.ts.Length);        //           ﾃｷｽﾄｼｰｹﾝｽ        
				ms.Read(dn_z.lg, 0, dn_z.lg.Length);        //           ﾃｷｽﾄ長           
				ms.Read(dn_z.tr, 0, dn_z.tr.Length);        //      ID   ﾄﾗﾝｻﾞｸｼｮﾝｺｰﾄﾞ    
				ms.Read(dn_z.res, 0, dn_z.res.Length);      //           処理結果         
				ms.Read(dn_z.seq, 0, dn_z.seq.Length);      //           seq番号          
				ms.Read(dn_z.acd, 0, dn_z.acd.Length);      //           相手先ｺｰﾄﾞ       
				ms.Read(dn_z.tcd, 0, dn_z.tcd.Length);      //           当方ｺｰﾄﾞ         
				ms.Read(dn_z.dttm, 0, dn_z.dttm.Length);    //           日付･時刻        
				ms.Read(dn_z.pass, 0, dn_z.pass.Length);    //           ﾊﾟｽﾜｰﾄﾞ          
				ms.Read(dn_z.kflg, 0, dn_z.kflg.Length);    //           継続ﾌﾗｸﾞ         
				ms.Read(dn_z.rem3, 0, dn_z.rem3.Length);    //      ﾍｯﾄﾞ ﾘﾏｰｸ3            


				//明細部
				for (int i = 0; i < ctBufLen; i++)
				{
					ms.Read(dn_z.ln_z[i].hb, 0, dn_z.ln_z[i].hb.Length);        // ﾗｲﾝ      品番              
					ms.Read(dn_z.ln_z[i].hn, 0, dn_z.ln_z[i].hn.Length);        //          品名              
					ms.Read(dn_z.ln_z[i].l_p, 0, dn_z.ln_z[i].l_p.Length);      //          L_P               
					ms.Read(dn_z.ln_z[i].chscd, 0, dn_z.ln_z[i].chscd.Length);  //          中止CD            
					ms.Read(dn_z.ln_z[i].daicd, 0, dn_z.ln_z[i].daicd.Length);  //          代替CD            
					ms.Read(dn_z.ln_z[i].Akakk, 0, dn_z.ln_z[i].Akakk.Length);  //          A価格             
					ms.Read(dn_z.ln_z[i].hozsu, 0, dn_z.ln_z[i].hozsu.Length);  //          本部在庫          
					ms.Read(dn_z.ln_z[i].idosu, 0, dn_z.ln_z[i].idosu.Length);  //          移動中数          
					ms.Read(dn_z.ln_z[i].nkicd, 0, dn_z.ln_z[i].nkicd.Length);  //          納期CD            

                    for (int j = 0; j < ctKyzsuLen; j++)
					{
						ms.Read(dn_z.ln_z[i].kyzsu[j], 0, dn_z.ln_z[i].kyzsu[j].Length); //          拠点在庫数02-32   
					}
				}

				//dummy
				ms.Read(dn_z.dummy, 0, dn_z.dummy.Length); // ﾗｲﾝ       dummy            

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
					case 0x11:						//-- "ﾄﾗﾝｻﾞｸｼｮﾝｴﾗｰ" --
					case 0xF1:						//-- "ﾄﾗﾝｻﾞｸｼｮﾝｴﾗｰ" --
						str = MSG_TRA;
						break;
					case 0x12:						//-- "ｵｷｬｸｻﾏｺｰﾄﾞｴﾗｰ" --
						str = MSG_UCD;
						break;
					case 0x14:						//-- "ﾊﾟｽﾜｰﾄﾞｴﾗｰ" --
						str = MSG_PAS;
						break;
					case 0x88:						//-- "ﾙｽﾊﾞﾝｴﾗｰ" --
						str = MSG_RUS;
						break;
					case 0xF4:						//-- "ﾃﾞｰﾀﾅｼ" --
						str = MSG_DAT;
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

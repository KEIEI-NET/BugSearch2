//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : ＵＯＥ受信編集＜見積＞（トヨタＰＤ４）アクセスクラス
// プログラム概要   : ＵＯＥ受信編集＜見積＞（トヨタＰＤ４）を行う
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
	/// ＵＯＥ受信編集＜見積＞（トヨタＰＤ４）アクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : ＵＯＥ受信編集＜見積＞（トヨタＰＤ４）アクセスクラス</br>
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

		# region ＵＯＥ受信編集＜見積＞（トヨタＰＤ４）
		/// <summary>
		/// ＵＯＥ受信編集＜見積＞（トヨタＰＤ４）
		/// </summary>
		/// <param name="message">エラーメッセージ</param>
		/// <returns>ステータス</returns>
		private int GetJnlEstmt0102(out string message)
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
				    TelegramJnlEstmt0102 telegramJnlEstmt0102 = new TelegramJnlEstmt0102();

				    foreach(UoeRecDtl dtl in uoeRecDtlList)
				    {
					    telegramJnlEstmt0102.Telegram(_uoeRecHed.UOESupplierCd, dtl);
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

		# region ＵＯＥ受信電文作成＜見積＞（トヨタＰＤ４）
		/// <summary>
		/// ＵＯＥ受信電文作成＜見積＞（トヨタＰＤ４）
		/// </summary>
		public class TelegramJnlEstmt0102 : UoeRecEdit0102Acs
		{
			# region ＰＭ７ソース
			//									/*-- 電文領域...ﾗｲﾝ...見積 --*/
			//struct	LN_M {					/* 74ﾊﾞｲﾄ                     */
			//	char	hb[12];					/* ﾗｲﾝ      品番              */
			//	char	su[5];					/*          数量              */
			//	char	hn[30];					/*          品名              */
			//	char	tnk[7];					/*          単価              */
			//	char	hozai[1];				/*          本部在庫          */
			//	char	kyzsu[2];				/*          拠点在庫数        */
			//	char	nkicd[1];				/*          納期CD            */
			//	char	daim[1];				/*          代替ﾏｰｸ           */
			//	char	sktan[7];				/*          仕切価格          */
			//	char	lerr[8];				/*          ﾗｲﾝｴﾗｰ            */
			//};

			/*-- 電文領域...本体...見積 --*/
			//struct	DN_M {						/* 83 +740 +1225 = 2048ﾊﾞｲﾄ   */
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
			//	char	reto[5];				/*           ﾚｰﾄ              */
			//	char	senc;					/*           選択ｺｰﾄﾞ         */
			//	char	remk[8];				/*           ﾘﾏｰｸ             */
			//	char	mitkei[9];				/*           見積金額計       */
			//	char	shkkei[9];				/*           仕切金額計       */
			//	struct	LN_M	m[10];			/* ﾗｲﾝ       74*10=740ﾊﾞｲﾄ    */
			//	char	dummy[1225];			/* ﾗｲﾝ       dummy            */
			//};
			# endregion

			# region Const Members
			private const Int32 ctBufLen = 10;		//明細バッファサイズ
			private const Int32 ctDetailLen = 10;	//明細行数
			# endregion

			# region Private Members
			//変数
			private Int32 _detailMax = 0;
			private DN_M dn_m = new DN_M();
			# endregion

			# region 電文領域クラス
			/// <summary>
			/// 見積電文領域＜ライン＞
			/// </summary>
			private class LN_M
			{
				public byte[] hb = new byte[12];	// ﾗｲﾝ      品番              
				public byte[] su = new byte[5];		//          数量              
				public byte[] hn = new byte[30];	//          品名              
				public byte[] tnk = new byte[7];	//          単価              
				public byte[] hozai = new byte[1];	//          本部在庫          
				public byte[] kyzsu = new byte[2];	//          拠点在庫数        
				public byte[] nkicd = new byte[1];	//          納期CD            
				public byte[] daim = new byte[1];	//          代替ﾏｰｸ           
				public byte[] sktan = new byte[7];	//          仕切価格          
				public byte[] lerr = new byte[8];	//          ﾗｲﾝｴﾗｰ            

				public LN_M()
				{
					Clear(0x00);
				}
				public void Clear(byte cd)
				{
					UoeCommonFnc.MemSet(ref hb, cd, hb.Length);		// ﾗｲﾝ      品番              
					UoeCommonFnc.MemSet(ref su, cd, su.Length);		//          数量              
					UoeCommonFnc.MemSet(ref hn, cd, hn.Length);		//          品名              
					UoeCommonFnc.MemSet(ref tnk, cd, tnk.Length);		//          単価              
					UoeCommonFnc.MemSet(ref hozai, cd, hozai.Length);	//          本部在庫          
					UoeCommonFnc.MemSet(ref kyzsu, cd, kyzsu.Length);	//          拠点在庫数        
					UoeCommonFnc.MemSet(ref nkicd, cd, nkicd.Length);	//          納期CD            
					UoeCommonFnc.MemSet(ref daim, cd, daim.Length);	//          代替ﾏｰｸ           
					UoeCommonFnc.MemSet(ref sktan, cd, sktan.Length);	//          仕切価格          
					UoeCommonFnc.MemSet(ref lerr, cd, lerr.Length);	//          ﾗｲﾝｴﾗｰ            
				}
			}

			/// <summary>
			/// 見積電文領域＜本体＞
			/// </summary>
			private class DN_M
			{
				public byte[] jh = new byte[1];				// ﾍｯﾀﾞ TTC  情報区分         
				public byte[] ts = new byte[2];				//           ﾃｷｽﾄｼｰｹﾝｽ        
				public byte[] lg = new byte[2];				//           ﾃｷｽﾄ長           
				public byte[] tr = new byte[3];				//      ID   ﾄﾗﾝｻﾞｸｼｮﾝｺｰﾄﾞ    
				public byte[] res = new byte[1];			//           処理結果         
				public byte[] seq = new byte[3];			//           seq番号          
				public byte[] acd = new byte[7];			//           相手先ｺｰﾄﾞ       
				public byte[] tcd = new byte[7];			//           当方ｺｰﾄﾞ         
				public byte[] dttm = new byte[6];			//           日付･時刻        
				public byte[] pass = new byte[6];			//           ﾊﾟｽﾜｰﾄﾞ          
				public byte[] kflg = new byte[1];			//           継続ﾌﾗｸﾞ         
				public byte[] rem3 = new byte[12];			//      ﾍｯﾄﾞ ﾘﾏｰｸ3            
				public byte[] reto = new byte[5];			//           ﾚｰﾄ              
				public byte[] senc = new byte[1];			//           選択ｺｰﾄﾞ         
				public byte[] remk = new byte[8];			//           ﾘﾏｰｸ             
				public byte[] mitkei = new byte[9];			//           見積金額計       
				public byte[] shkkei = new byte[9];			//           仕切金額計       

				public LN_M[] ln_m = new LN_M[ctBufLen];// ﾗｲﾝ       14*10=140ﾊﾞｲﾄ

				public byte[] dummy = new byte[1225];			// ﾗｲﾝ       dummy            

				/// <summary>	
				/// コンストラクター
				/// </summary>
				public DN_M()
				{
					Clear(0x00);
				}

				public void Clear(byte cd)
				{
					UoeCommonFnc.MemSet(ref jh, cd, jh.Length);					// ﾍｯﾀﾞ TTC  情報区分         
					UoeCommonFnc.MemSet(ref ts, cd, ts.Length);					//           ﾃｷｽﾄｼｰｹﾝｽ        
					UoeCommonFnc.MemSet(ref lg, cd, lg.Length);					//           ﾃｷｽﾄ長           
					UoeCommonFnc.MemSet(ref tr, cd, tr.Length);					//      ID   ﾄﾗﾝｻﾞｸｼｮﾝｺｰﾄﾞ    
					UoeCommonFnc.MemSet(ref res, cd, res.Length);				//           処理結果         
					UoeCommonFnc.MemSet(ref seq, cd, seq.Length);				//           seq番号          
					UoeCommonFnc.MemSet(ref acd, cd, acd.Length);				//           相手先ｺｰﾄﾞ       
					UoeCommonFnc.MemSet(ref tcd, cd, tcd.Length);				//           当方ｺｰﾄﾞ         
					UoeCommonFnc.MemSet(ref dttm, cd, dttm.Length);				//           日付･時刻        
					UoeCommonFnc.MemSet(ref pass, cd, pass.Length);				//           ﾊﾟｽﾜｰﾄﾞ          
					UoeCommonFnc.MemSet(ref kflg, cd, kflg.Length);				//           継続ﾌﾗｸﾞ         
					UoeCommonFnc.MemSet(ref rem3, cd, rem3.Length);				//      ﾍｯﾄﾞ ﾘﾏｰｸ3            
					UoeCommonFnc.MemSet(ref reto, cd, reto.Length);				//           ﾚｰﾄ              
					UoeCommonFnc.MemSet(ref senc, cd, senc.Length);				//           選択ｺｰﾄﾞ         
					UoeCommonFnc.MemSet(ref remk, cd, remk.Length);				//           ﾘﾏｰｸ             
					UoeCommonFnc.MemSet(ref mitkei, cd, mitkei.Length);			//           見積金額計       
					UoeCommonFnc.MemSet(ref shkkei, cd, shkkei.Length);			//           仕切金額計       

					//明細部
					for (int i = 0; i < ctBufLen; i++)
					{
                        if (ln_m[i] == null)
                        {
                            ln_m[i] = new LN_M();
                        }
                        else
                        {
                            ln_m[i].Clear(0x00);
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
			public TelegramJnlEstmt0102()
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
					Int32 lwk = TDateTime.DateTimeToLongDate(DateTime.Now);		//yyyymmdd
					lwk /= 1000000;	// yy
					lwk *= 1000000;	// yy000000

					byte[] byteYymmdd = new byte[6];
 
					for(int ix=0; ix<byteYymmdd.Length; ix++)
					{
						byteYymmdd[ix] = dn_m.rem3[ix + 4];
					}
					Int32 int32Yymmdd = UoeCommonFnc.ToInt32FromByteStrAry(byteYymmdd);

					//電文自体にに日付がセットされている
					if (int32Yymmdd > 0)
					{
                        dataRow[EstmtSndRcvJnlSchema.ct_Col_ReceiveDate] = TDateTime.LongDateToDateTime(int32Yymmdd + lwk);
                    }
					//電文自体にに日付がセットされていない
					else
					{
                        dataRow[EstmtSndRcvJnlSchema.ct_Col_ReceiveDate] = DateTime.Now;
                    }

					//受信時刻(HHMMSS)
                    int hHMMSS = UoeCommonFnc.ToInt32FromByteStrAry(dn_m.dttm);
                    if (hHMMSS == 0)
                    {
                        hHMMSS = TDateTime.DateTimeToLongDate("HHMMSS", DateTime.Now);
                    }
                    dataRow[EstmtSndRcvJnlSchema.ct_Col_ReceiveTime] = hHMMSS;

					//ヘッドエラーあり
					if (dn_m.res[0] == 0x00)
					{
						//ラインエラーメッセージ
						//dataRow[EstmtSndRcvJnlSchema.ct_Col_LineErrorMassage] = UoeCommonFnc.ToStringFromByteStrAry(dn_m.ln_m[i].lerrM);
					}
					//ヘッドエラーなし
					else
					{
						string errMessage = GetHeadErrorMassage(dn_m.res[0]);

						//ヘッドエラーメッセージ
						dataRow[EstmtSndRcvJnlSchema.ct_Col_HeadErrorMassage] = errMessage;

						//ラインエラーメッセージ
						dataRow[EstmtSndRcvJnlSchema.ct_Col_LineErrorMassage] = errMessage;

						//品名
						dataRow[EstmtSndRcvJnlSchema.ct_Col_AnswerPartsName] = errMessage;
					}

					//代替なし
					if ((dn_m.ln_m[i].daim[0] == 0x00)
					|| (dn_m.ln_m[i].daim[0] == 0x20)
					|| (dn_m.ln_m[i].daim[0] == 0x30))
					{
						//代替ﾏｰｸ
						dataRow[EstmtSndRcvJnlSchema.ct_Col_UOESubstCode] = "";
						
						//回答品番
						dataRow[EstmtSndRcvJnlSchema.ct_Col_AnswerPartsNo] = UoeCommonFnc.ToStringFromByteStrAry(dn_m.ln_m[i].hb);

						//回答品名
						if (dn_m.res[0] == 0x00)
						{
							dataRow[EstmtSndRcvJnlSchema.ct_Col_AnswerPartsName] = UoeCommonFnc.ToStringFromByteStrAry(dn_m.ln_m[i].hn);
						}
					}
					//代替あり
					else
					{
						//代替ﾏｰｸ
						dataRow[EstmtSndRcvJnlSchema.ct_Col_UOESubstCode] = UoeCommonFnc.ToStringFromByteStrAry(dn_m.ln_m[i].daim);
							
						//代替品番
						dataRow[EstmtSndRcvJnlSchema.ct_Col_SubstPartsNo] = UoeCommonFnc.ToStringFromByteStrAry(dn_m.ln_m[i].hb);

						//回答品番
						dataRow[EstmtSndRcvJnlSchema.ct_Col_AnswerPartsNo] = UoeCommonFnc.ToStringFromByteStrAry(dn_m.ln_m[i].hn);

						//回答品名
						if (dn_m.res[0] == 0x00)
						{
							dataRow[EstmtSndRcvJnlSchema.ct_Col_AnswerPartsName] = UoeCommonFnc.ToStringFromByteStrAry(dn_m.ln_m[i].hb);
						}
					}

					//見積単価
                    dataRow[EstmtSndRcvJnlSchema.ct_Col_AnswerListPrice] = UoeCommonFnc.ToDoubleFromByteStrAry(dn_m.ln_m[i].tnk);

					//回答原価単価
                    dataRow[EstmtSndRcvJnlSchema.ct_Col_SalesUnPrcTaxExcFl] = UoeCommonFnc.ToDoubleFromByteStrAry(dn_m.ln_m[i].sktan);
                    dataRow[EstmtSndRcvJnlSchema.ct_Col_AnswerSalesUnitCost] = UoeCommonFnc.ToDoubleFromByteStrAry(dn_m.ln_m[i].sktan);

					//回答定価
                    dataRow[EstmtSndRcvJnlSchema.ct_Col_AnswerListPrice] = UoeCommonFnc.ToDoubleFromByteStrAry(dn_m.ln_m[i].tnk);

					//本部在庫
					dataRow[EstmtSndRcvJnlSchema.ct_Col_HeadQtrsStock] = UoeCommonFnc.ToStringFromByteStrAry(dn_m.ln_m[i].hozai);

					//拠点在庫数
					dataRow[EstmtSndRcvJnlSchema.ct_Col_BranchStock] = UoeCommonFnc.ToStringFromByteStrAry(dn_m.ln_m[i].kyzsu);

					//納期ｺｰﾄﾞ
					dataRow[EstmtSndRcvJnlSchema.ct_Col_UOEDelivDateCd] = UoeCommonFnc.ToStringFromByteStrAry(dn_m.ln_m[i].nkicd);
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

				ms.Read(dn_m.jh, 0, dn_m.jh.Length);                            // ﾍｯﾀﾞ TTC  情報区分         
				ms.Read(dn_m.ts, 0, dn_m.ts.Length);                            //           ﾃｷｽﾄｼｰｹﾝｽ        
				ms.Read(dn_m.lg, 0, dn_m.lg.Length);                            //           ﾃｷｽﾄ長           
				ms.Read(dn_m.tr, 0, dn_m.tr.Length);                            //      ID   ﾄﾗﾝｻﾞｸｼｮﾝｺｰﾄﾞ    
				ms.Read(dn_m.res, 0, dn_m.res.Length);                          //           処理結果         
				ms.Read(dn_m.seq, 0, dn_m.seq.Length);                          //           seq番号          
				ms.Read(dn_m.acd, 0, dn_m.acd.Length);                          //           相手先ｺｰﾄﾞ       
				ms.Read(dn_m.tcd, 0, dn_m.tcd.Length);                          //           当方ｺｰﾄﾞ         
				ms.Read(dn_m.dttm, 0, dn_m.dttm.Length);                        //           日付･時刻        
				ms.Read(dn_m.pass, 0, dn_m.pass.Length);                        //           ﾊﾟｽﾜｰﾄﾞ          
				ms.Read(dn_m.kflg, 0, dn_m.kflg.Length);                        //           継続ﾌﾗｸﾞ         
				ms.Read(dn_m.rem3, 0, dn_m.rem3.Length);                        //      ﾍｯﾄﾞ ﾘﾏｰｸ3            
				ms.Read(dn_m.reto, 0, dn_m.reto.Length);                        //           ﾚｰﾄ              
				ms.Read(dn_m.senc, 0, dn_m.senc.Length);                        //           選択ｺｰﾄﾞ         
				ms.Read(dn_m.remk, 0, dn_m.remk.Length);                        //           ﾘﾏｰｸ             
				ms.Read(dn_m.mitkei, 0, dn_m.mitkei.Length);                    //           見積金額計       
				ms.Read(dn_m.shkkei, 0, dn_m.shkkei.Length);                    //           仕切金額計       

				//明細部
				for (int i = 0; i < ctBufLen; i++)
				{
					ms.Read(dn_m.ln_m[i].hb, 0, dn_m.ln_m[i].hb.Length);        // ﾗｲﾝ      品番              
					ms.Read(dn_m.ln_m[i].su, 0, dn_m.ln_m[i].su.Length);        //          数量              
					ms.Read(dn_m.ln_m[i].hn, 0, dn_m.ln_m[i].hn.Length);        //          品名              
					ms.Read(dn_m.ln_m[i].tnk, 0, dn_m.ln_m[i].tnk.Length);      //          単価              
					ms.Read(dn_m.ln_m[i].hozai, 0, dn_m.ln_m[i].hozai.Length);  //          本部在庫          
					ms.Read(dn_m.ln_m[i].kyzsu, 0, dn_m.ln_m[i].kyzsu.Length);  //          拠点在庫数        
					ms.Read(dn_m.ln_m[i].nkicd, 0, dn_m.ln_m[i].nkicd.Length);  //          納期CD            
					ms.Read(dn_m.ln_m[i].daim, 0, dn_m.ln_m[i].daim.Length);    //          代替ﾏｰｸ           
					ms.Read(dn_m.ln_m[i].sktan, 0, dn_m.ln_m[i].sktan.Length);  //          仕切価格          
					ms.Read(dn_m.ln_m[i].lerr, 0, dn_m.ln_m[i].lerr.Length);    //          ﾗｲﾝｴﾗｰ            
				}
				
				//dummy
				ms.Read(dn_m.dummy, 0, dn_m.dummy.Length);                      // ﾗｲﾝ       dummy            

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
					case 0xF7:						//-- "ｵｷｬｸｻﾏｺｰﾄﾞｴﾗｰ" --
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
					case 0xC1:						//-- "ﾚｰﾄｴﾗｰ" --
						str = MSG_RTE;
						break;
					case 0xC2:						//-- "ｾﾝﾀｸｺｰﾄﾞｴﾗｰ" --
						str = MSG_SCD;
						break;
					case 0xC3:						//-- "ｼｭｶﾝｷｮﾃﾝｴﾗｰ" --
						str = MSG_SKK;
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

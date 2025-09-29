//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : ＵＯＥ受信編集＜発注＞（トヨタＰＤ４）アクセスクラス
// プログラム概要   : ＵＯＥ受信編集＜発注＞（トヨタＰＤ４）を行う
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
	/// ＵＯＥ受信編集＜発注＞（トヨタＰＤ４）アクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : ＵＯＥ受信編集（トヨタＰＤ４）アクセスクラス</br>
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

		# region ＵＯＥ受信編集＜発注＞（トヨタＰＤ４）
		/// <summary>
		/// ＵＯＥ受信編集＜発注＞（トヨタＰＤ４）
		/// </summary>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        private int GetJnlOrder0102(out string message)
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
                    TelegramJnlOrder0102 telegramJnlOrder0102 = new TelegramJnlOrder0102();
                    foreach (UoeRecDtl dtl in uoeRecDtlList)
                    {
                        telegramJnlOrder0102.Telegram(_uoeRecHed.UOESupplierCd, dtl);
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

		# region ＵＯＥ受信電文作成＜発注＞（トヨタＰＤ４）
		/// <summary>
		/// ＵＯＥ受信電文作成＜発注＞（トヨタＰＤ４）
		/// </summary>
		public class TelegramJnlOrder0102 : UoeRecEdit0102Acs
		{
			# region ＰＭ７ソース
												/*-- 電文領域...本体...発注 --*/
			//struct	DN_H {					/* 82 +684 +1282 = 2048       */
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
			//	char	nhkb;					/*           納品区分         */
			//	char	fnkb;					/*           ﾌｫﾛｰ納品区分     */
			//	char	rem1[8];				/*           ﾘﾏｰｸ1            */
			//	char	rem2[10];				/*           ﾘﾏｰｸ2            */
			//	char	kyo[2];					/*           指定拠点         */
			//	char	tan[2];					/*           担当者ｺｰﾄﾞ       */
			//	char	skbn;					/*           処理区分         */
			//	char	ndate[6];				/*           納入指定日       */
			//	struct	LN_H	h[3];			/* ﾗｲﾝ       3*228=684ﾊﾞｲﾄ    */
			//	char	dummy[1282];			/* ﾗｲﾝ       dummy            */
			//};
												/*-- 電文領域...ﾗｲﾝ...発注 --*/
			//struct	LN_H {					/* 228ﾊﾞｲﾄ                    */
			//	char	hb[12];					/* ﾗｲﾝ      品番              */
			//	char	hn[30];					/*          品名              */
			//	char	l_p[7];					/*          L_P               */
			//	char	d_n[7];					/*          D_N               */
			//	char	jsu[5];					/*          受注数            */
			//	char	su[5];					/*          出庫数            */
			//	char	sbfsu[5];				/*          ｻﾌﾞ本部ﾌｫﾛｰ数     */
			//	char	hofsu[5];				/*          本部ﾌｫﾛｰ数        */
			//	char	rgfsu[5];				/*          ﾙｰﾄ外ﾌｫﾛｰ数       */
			//	char	mkfsu[5];				/*          ﾒｰｶｰﾌｫﾛｰ数        */
			//	char	nonsu[5];				/*          未出庫数          */
			//	char	sbzsu[5];				/*          ｻﾌﾞ本部在庫       */
			//	char	hozsu[5];				/*          本部在庫          */
			//	char	rgzai[5];				/*          ﾙｰﾄ外在庫数       */
			//	char	kyden[6];				/*          主管拠点伝番      */
			//	char	sbden[6];				/*          ｻﾌﾞ本部伝番       */
			//	char	hofde[6];				/*          本部ﾌｫﾛｰ伝番      */
			//	char	rgfde[6];				/*          ﾙｰﾄ外ﾌｫﾛｰ伝番     */
			//	char	daita[1];				/*          代替有無          */
			//	char	hbkbn[1];				/*          品番区分          */
			//	char	syocd[1];				/*          商品CD            */
			//	char	hincd[4];				/*          品目CD            */
			//	char	nkicd[1];				/*          納期CD            */
			//	char	hozcd[1];				/*          本部在庫CD        */
			//	char	lerrC[1];				/*          ﾗｲﾝｴﾗｰC           */
			//	char	lerrM[6];				/*          ﾗｲﾝｴﾗｰM           */
			//};
			# endregion

			# region Const Members
			private const Int32 ctBufLen = 3;		//明細バッファサイズ
			private const Int32 ctDetailLen = 3;	//明細行数
			# endregion

			# region Private Members
			//変数
			private Int32 _detailMax = 0;

			# endregion

			private DN_H dn_h = new DN_H();


			# region 電文領域クラス
			/// <summary>
			/// 発注電文領域＜ライン＞
			/// </summary>
			private class LN_H
			{
				public byte[] hb = new byte[12];	// ﾗｲﾝ      品番              
				public byte[] hn = new byte[30];	//	        品名              
				public byte[] l_p = new byte[7];	//          L_P               
				public byte[] d_n = new byte[7];	//          D_N               
				public byte[] jsu = new byte[5];	//          受注数            
				public byte[] su = new byte[5];		//          出庫数            
				public byte[] sbfsu = new byte[5];	//          ｻﾌﾞ本部ﾌｫﾛｰ数     
				public byte[] hofsu = new byte[5];	//          本部ﾌｫﾛｰ数        
				public byte[] rgfsu = new byte[5];	//          ﾙｰﾄ外ﾌｫﾛｰ数       
				public byte[] mkfsu = new byte[5];	//          ﾒｰｶｰﾌｫﾛｰ数        
				public byte[] nonsu = new byte[5];	//          未出庫数          
				public byte[] sbzsu = new byte[5];	//          ｻﾌﾞ本部在庫       
				public byte[] hozsu = new byte[5];	//          本部在庫          
				public byte[] rgzai = new byte[5];	//          ﾙｰﾄ外在庫数       
				public byte[] kyden = new byte[6];	//          主管拠点伝番      
				public byte[] sbden = new byte[6];	//          ｻﾌﾞ本部伝番       
				public byte[] hofde = new byte[6];	//          本部ﾌｫﾛｰ伝番      
				public byte[] rgfde = new byte[6];	//          ﾙｰﾄ外ﾌｫﾛｰ伝番     
				public byte[] daita = new byte[1];	//          代替有無          
				public byte[] hbkbn = new byte[1];	//          品番区分          
				public byte[] syocd = new byte[1];	//          商品CD            
				public byte[] hincd = new byte[4];	//          品目CD            
				public byte[] nkicd = new byte[1];	//          納期CD            
				public byte[] hozcd = new byte[1];	//          本部在庫CD        
				public byte[] lerrC = new byte[1];	//          ﾗｲﾝｴﾗｰC           
				public byte[] lerrM = new byte[6];	//          ﾗｲﾝｴﾗｰM           

				public LN_H()
				{
					Clear(0x00);
				}
				public void Clear(byte cd)
				{
					UoeCommonFnc.MemSet(ref hb, cd, hb.Length);		    // ﾗｲﾝ      品番              
					UoeCommonFnc.MemSet(ref hn, cd, hn.Length);		    //          品名              
					UoeCommonFnc.MemSet(ref l_p, cd, l_p.Length);		//          L_P               
					UoeCommonFnc.MemSet(ref d_n, cd, d_n.Length);		//          D_N               
					UoeCommonFnc.MemSet(ref jsu, cd, jsu.Length);		//          受注数            
					UoeCommonFnc.MemSet(ref su, cd, su.Length);		    //          出庫数            
					UoeCommonFnc.MemSet(ref sbfsu, cd, sbfsu.Length);	//          ｻﾌﾞ本部ﾌｫﾛｰ数     
					UoeCommonFnc.MemSet(ref hofsu, cd, hofsu.Length);	//          本部ﾌｫﾛｰ数        
					UoeCommonFnc.MemSet(ref rgfsu, cd, rgfsu.Length);	//          ﾙｰﾄ外ﾌｫﾛｰ数       
					UoeCommonFnc.MemSet(ref mkfsu, cd, mkfsu.Length);	//          ﾒｰｶｰﾌｫﾛｰ数        
					UoeCommonFnc.MemSet(ref nonsu, cd, nonsu.Length);	//          未出庫数          
					UoeCommonFnc.MemSet(ref sbzsu, cd, sbzsu.Length);	//          ｻﾌﾞ本部在庫       
					UoeCommonFnc.MemSet(ref hozsu, cd, hozsu.Length);	//          本部在庫          
					UoeCommonFnc.MemSet(ref rgzai, cd, rgzai.Length);	//          ﾙｰﾄ外在庫数       
					UoeCommonFnc.MemSet(ref kyden, cd, kyden.Length);	//          主管拠点伝番      
					UoeCommonFnc.MemSet(ref sbden, cd, sbden.Length);	//          ｻﾌﾞ本部伝番       
					UoeCommonFnc.MemSet(ref hofde, cd, hofde.Length);	//          本部ﾌｫﾛｰ伝番      
					UoeCommonFnc.MemSet(ref rgfde, cd, rgfde.Length);	//          ﾙｰﾄ外ﾌｫﾛｰ伝番     
					UoeCommonFnc.MemSet(ref daita, cd, daita.Length);	//          代替有無          
					UoeCommonFnc.MemSet(ref hbkbn, cd, hbkbn.Length);	//          品番区分          
					UoeCommonFnc.MemSet(ref syocd, cd, syocd.Length);	//          商品CD            
					UoeCommonFnc.MemSet(ref hincd, cd, hincd.Length);	//          品目CD            
					UoeCommonFnc.MemSet(ref nkicd, cd, nkicd.Length);	//          納期CD            
					UoeCommonFnc.MemSet(ref hozcd, cd, hozcd.Length);	//          本部在庫CD        
					UoeCommonFnc.MemSet(ref lerrC, cd, lerrC.Length);	//          ﾗｲﾝｴﾗｰC           
					UoeCommonFnc.MemSet(ref lerrM, cd, lerrM.Length);	//          ﾗｲﾝｴﾗｰM           
				}
			}

			/// <summary>
			/// 発注電文領域＜本体＞
			/// </summary>
			private class DN_H
			{
				public byte[] jh = new byte[1];		    // ﾍｯﾀﾞ TTC  情報区分         
				public byte[] ts = new byte[2];		    //           ﾃｷｽﾄｼｰｹﾝｽ        
				public byte[] lg = new byte[2];		    //           ﾃｷｽﾄ長           
				public byte[] tr = new byte[3];		    //      ID   ﾄﾗﾝｻﾞｸｼｮﾝｺｰﾄﾞ    
				public byte[] res = new byte[1];		//           処理結果         
				public byte[] seq = new byte[3];		//           seq番号          
				public byte[] acd = new byte[7];		//           相手先ｺｰﾄﾞ       
				public byte[] tcd = new byte[7];		//           当方ｺｰﾄﾞ         
				public byte[] dttm = new byte[6];		//           日付･時刻        
				public byte[] pass = new byte[6];		//           ﾊﾟｽﾜｰﾄﾞ          
				public byte[] kflg = new byte[1];		//           継続ﾌﾗｸﾞ         
				public byte[] rem3 = new byte[12];	    //      ﾍｯﾄﾞ ﾘﾏｰｸ3            
				public byte[] nhkb = new byte[1];		//           納品区分         
				public byte[] fnkb = new byte[1];		//           ﾌｫﾛｰ納品区分     
				public byte[] rem1 = new byte[8];		//           ﾘﾏｰｸ1            
				public byte[] rem2 = new byte[10];	    //           ﾘﾏｰｸ2            
				public byte[] kyo = new byte[2];		//           指定拠点         
				public byte[] tan = new byte[2];		//           担当者ｺｰﾄﾞ       
				public byte[] skbn = new byte[1];		//           処理区分         
				public byte[] ndate = new byte[6];	    //           納入指定日       
				public LN_H[] ln_h = new LN_H[ctBufLen];// ﾗｲﾝ       14*10=140ﾊﾞｲﾄ

				public byte[] dummy = new byte[1282];	// ﾗｲﾝ       dummy            

				/// <summary>	
				/// コンストラクター
				/// </summary>
				public DN_H()
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
					UoeCommonFnc.MemSet(ref nhkb, cd, nhkb.Length);		//           納品区分         
					UoeCommonFnc.MemSet(ref fnkb, cd, fnkb.Length);		//           ﾌｫﾛｰ納品区分     
					UoeCommonFnc.MemSet(ref rem1, cd, rem1.Length);		//           ﾘﾏｰｸ1            
					UoeCommonFnc.MemSet(ref rem2, cd, rem2.Length);		//           ﾘﾏｰｸ2            
					UoeCommonFnc.MemSet(ref kyo, cd, kyo.Length);		//           指定拠点         
					UoeCommonFnc.MemSet(ref tan, cd, tan.Length);		//           担当者ｺｰﾄﾞ       
					UoeCommonFnc.MemSet(ref skbn, cd, skbn.Length);		//           処理区分         
					UoeCommonFnc.MemSet(ref ndate, cd, ndate.Length);	//           納入指定日       

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

					//dummy
					UoeCommonFnc.MemSet(ref dummy, cd, dummy.Length);	// ﾗｲﾝ       dummy            
				}
			}
			# endregion




			# region Constructors
			/// <summary>
			/// コンストラクタ
			/// </summary>
			public TelegramJnlOrder0102()
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
					Int32 lwk = TDateTime.DateTimeToLongDate(DateTime.Now);		//yyyymmdd
					lwk /= 1000000;	// yy
					lwk *= 1000000;	// yy000000

					byte[] byteYymmdd = new byte[6];
 
					for(int ix=0; ix<byteYymmdd.Length; ix++)
					{
						byteYymmdd[ix] = dn_h.rem3[ix + 4];
					}
					Int32 int32Yymmdd = UoeCommonFnc.ToInt32FromByteStrAry(byteYymmdd);

					//電文自体にに日付がセットされている
					if (int32Yymmdd > 0)
					{
						dataRow[OrderSndRcvJnlSchema.ct_Col_ReceiveDate] = TDateTime.LongDateToDateTime(int32Yymmdd + lwk);
					}
					//電文自体にに日付がセットされていない
					else
					{
						dataRow[OrderSndRcvJnlSchema.ct_Col_ReceiveDate] = DateTime.Now;
					}

					//受信時刻(HHMMSS)
                    int hHMMSS = UoeCommonFnc.ToInt32FromByteStrAry(dn_h.dttm);
                    if (hHMMSS == 0)
                    {
                        hHMMSS = TDateTime.DateTimeToLongDate("HHMMSS", DateTime.Now);
                    }
                    dataRow[OrderSndRcvJnlSchema.ct_Col_ReceiveTime] = hHMMSS;

					//ヘッドエラーあり
					if (dn_h.res[0] == 0x00)
					{
						//ラインエラーメッセージ
						dataRow[OrderSndRcvJnlSchema.ct_Col_LineErrorMassage] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].lerrM);
					}
					//ヘッドエラーなし
					else
					{
						string errMessage = GetHeadErrorMassage(dn_h.res[0]);
						//ヘッドエラーメッセージ
						dataRow[OrderSndRcvJnlSchema.ct_Col_HeadErrorMassage] = errMessage;

						//ラインエラーメッセージ
						dataRow[OrderSndRcvJnlSchema.ct_Col_LineErrorMassage] = errMessage;

						//品名
						dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerPartsName] = errMessage;
					}

					//代替なし
					if ((dn_h.ln_h[i].daita[0] == 0x00)
					|| (dn_h.ln_h[i].daita[0] == 0x20)
					|| (dn_h.ln_h[i].daita[0] == 0x30))
					{
						//回答品番
						dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerPartsNo] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].hb);

						//回答品名
						if (dn_h.res[0] == 0x00)
						{
							dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerPartsName] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].hn);
						}
					}
					//代替あり
					else
					{
						//代替ﾏｰｸ
                        dataRow[OrderSndRcvJnlSchema.ct_Col_UOESubstMark] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].daita);

						//代替品番
						dataRow[OrderSndRcvJnlSchema.ct_Col_SubstPartsNo] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].hb);

						//回答品番
						dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerPartsNo] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].hn);

						//回答品名
						if (dn_h.res[0] == 0x00)
						{
							dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerPartsName] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].hb);
						}
					}

					//拠点出庫数
					dataRow[OrderSndRcvJnlSchema.ct_Col_UOESectOutGoodsCnt] = UoeCommonFnc.ToInt32FromByteStrAry(dn_h.ln_h[i].su);

					//BO出庫数1
					dataRow[OrderSndRcvJnlSchema.ct_Col_BOShipmentCnt1] = UoeCommonFnc.ToInt32FromByteStrAry(dn_h.ln_h[i].sbfsu);

					//BO出庫数2
					dataRow[OrderSndRcvJnlSchema.ct_Col_BOShipmentCnt2] = UoeCommonFnc.ToInt32FromByteStrAry(dn_h.ln_h[i].hofsu);

					//BO出庫数3
					dataRow[OrderSndRcvJnlSchema.ct_Col_BOShipmentCnt3] = UoeCommonFnc.ToInt32FromByteStrAry(dn_h.ln_h[i].rgfsu);

					//メーカーフォロー数
					dataRow[OrderSndRcvJnlSchema.ct_Col_MakerFollowCnt] = UoeCommonFnc.ToInt32FromByteStrAry(dn_h.ln_h[i].mkfsu);

					//未出庫数
					dataRow[OrderSndRcvJnlSchema.ct_Col_NonShipmentCnt] = UoeCommonFnc.ToInt32FromByteStrAry(dn_h.ln_h[i].nonsu);

					//BO在庫数1
					dataRow[OrderSndRcvJnlSchema.ct_Col_BOStockCount1] = UoeCommonFnc.ToInt32FromByteStrAry(dn_h.ln_h[i].sbzsu);

					//BO出庫数2
					dataRow[OrderSndRcvJnlSchema.ct_Col_BOStockCount2] = UoeCommonFnc.ToInt32FromByteStrAry(dn_h.ln_h[i].hozsu);

					//BO出庫数3
					dataRow[OrderSndRcvJnlSchema.ct_Col_BOStockCount3] = UoeCommonFnc.ToInt32FromByteStrAry(dn_h.ln_h[i].rgzai);

					//拠点伝票№
					dataRow[OrderSndRcvJnlSchema.ct_Col_UOESectionSlipNo] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].kyden);

					//BO伝票№1
					dataRow[OrderSndRcvJnlSchema.ct_Col_BOSlipNo1] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].sbden);

					//BO伝票№2
					dataRow[OrderSndRcvJnlSchema.ct_Col_BOSlipNo2] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].hofde);

					//BO伝票№3
					dataRow[OrderSndRcvJnlSchema.ct_Col_BOSlipNo3] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].rgfde);

					//適用（定価）
					dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerListPrice] = UoeCommonFnc.ToDoubleFromByteStrAry(dn_h.ln_h[i].l_p);

					//原価単価（仕切り単価）
                    dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerSalesUnitCost] = UoeCommonFnc.ToDoubleFromByteStrAry(dn_h.ln_h[i].d_n);
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

				ms.Read(dn_h.jh, 0, dn_h.jh.Length);        // ﾍｯﾀﾞ TTC  情報区分         
                ms.Read(dn_h.ts, 0, dn_h.ts.Length);        //           ﾃｷｽﾄｼｰｹﾝｽ        
				ms.Read(dn_h.lg, 0, dn_h.lg.Length);        //           ﾃｷｽﾄ長           
				ms.Read(dn_h.tr, 0, dn_h.tr.Length);        //      ID   ﾄﾗﾝｻﾞｸｼｮﾝｺｰﾄﾞ    
				ms.Read(dn_h.res, 0, dn_h.res.Length);      //           処理結果         
				ms.Read(dn_h.seq, 0, dn_h.seq.Length);      //           seq番号          
				ms.Read(dn_h.acd, 0, dn_h.acd.Length);      //           相手先ｺｰﾄﾞ       
				ms.Read(dn_h.tcd, 0, dn_h.tcd.Length);      //           当方ｺｰﾄﾞ         
				ms.Read(dn_h.dttm, 0, dn_h.dttm.Length);    //           日付･時刻        
				ms.Read(dn_h.pass, 0, dn_h.pass.Length);    //           ﾊﾟｽﾜｰﾄﾞ          
				ms.Read(dn_h.kflg, 0, dn_h.kflg.Length);    //           継続ﾌﾗｸﾞ         
				ms.Read(dn_h.rem3, 0, dn_h.rem3.Length);    //      ﾍｯﾄﾞ ﾘﾏｰｸ3            
				ms.Read(dn_h.nhkb, 0, dn_h.nhkb.Length);    //           納品区分         
				ms.Read(dn_h.fnkb, 0, dn_h.fnkb.Length);    //           ﾌｫﾛｰ納品区分     
				ms.Read(dn_h.rem1, 0, dn_h.rem1.Length);    //           ﾘﾏｰｸ1            
				ms.Read(dn_h.rem2, 0, dn_h.rem2.Length);    //           ﾘﾏｰｸ2            
				ms.Read(dn_h.kyo, 0, dn_h.kyo.Length);      //           指定拠点         
				ms.Read(dn_h.tan, 0, dn_h.tan.Length);      //           担当者ｺｰﾄﾞ       
				ms.Read(dn_h.skbn, 0, dn_h.skbn.Length);    //           処理区分         
				ms.Read(dn_h.ndate, 0, dn_h.ndate.Length);  //           納入指定日       

				//明細部
				for (int i = 0; i < ctBufLen; i++)
				{
					ms.Read(dn_h.ln_h[i].hb, 0, dn_h.ln_h[i].hb.Length);        // ﾗｲﾝ      品番              
					ms.Read(dn_h.ln_h[i].hn, 0, dn_h.ln_h[i].hn.Length);        //          品名              
					ms.Read(dn_h.ln_h[i].l_p, 0, dn_h.ln_h[i].l_p.Length);      //          L_P               
					ms.Read(dn_h.ln_h[i].d_n, 0, dn_h.ln_h[i].d_n.Length);      //          D_N               
					ms.Read(dn_h.ln_h[i].jsu, 0, dn_h.ln_h[i].jsu.Length);      //          受注数            
					ms.Read(dn_h.ln_h[i].su, 0, dn_h.ln_h[i].su.Length);        //          出庫数            
					ms.Read(dn_h.ln_h[i].sbfsu, 0, dn_h.ln_h[i].sbfsu.Length);  //          ｻﾌﾞ本部ﾌｫﾛｰ数     
					ms.Read(dn_h.ln_h[i].hofsu, 0, dn_h.ln_h[i].hofsu.Length);  //          本部ﾌｫﾛｰ数        
					ms.Read(dn_h.ln_h[i].rgfsu, 0, dn_h.ln_h[i].rgfsu.Length);  //          ﾙｰﾄ外ﾌｫﾛｰ数       
					ms.Read(dn_h.ln_h[i].mkfsu, 0, dn_h.ln_h[i].mkfsu.Length);  //          ﾒｰｶｰﾌｫﾛｰ数        
					ms.Read(dn_h.ln_h[i].nonsu, 0, dn_h.ln_h[i].nonsu.Length);  //          未出庫数          
					ms.Read(dn_h.ln_h[i].sbzsu, 0, dn_h.ln_h[i].sbzsu.Length);  //          ｻﾌﾞ本部在庫       
					ms.Read(dn_h.ln_h[i].hozsu, 0, dn_h.ln_h[i].hozsu.Length);  //          本部在庫          
					ms.Read(dn_h.ln_h[i].rgzai, 0, dn_h.ln_h[i].rgzai.Length);  //          ﾙｰﾄ外在庫数       
					ms.Read(dn_h.ln_h[i].kyden, 0, dn_h.ln_h[i].kyden.Length);  //          主管拠点伝番      
					ms.Read(dn_h.ln_h[i].sbden, 0, dn_h.ln_h[i].sbden.Length);  //          ｻﾌﾞ本部伝番       
					ms.Read(dn_h.ln_h[i].hofde, 0, dn_h.ln_h[i].hofde.Length);  //          本部ﾌｫﾛｰ伝番      
					ms.Read(dn_h.ln_h[i].rgfde, 0, dn_h.ln_h[i].rgfde.Length);  //          ﾙｰﾄ外ﾌｫﾛｰ伝番     
					ms.Read(dn_h.ln_h[i].daita, 0, dn_h.ln_h[i].daita.Length);  //          代替有無          
					ms.Read(dn_h.ln_h[i].hbkbn, 0, dn_h.ln_h[i].hbkbn.Length);  //          品番区分          
					ms.Read(dn_h.ln_h[i].syocd, 0, dn_h.ln_h[i].syocd.Length);  //          商品CD            
					ms.Read(dn_h.ln_h[i].hincd, 0, dn_h.ln_h[i].hincd.Length);  //          品目CD            
					ms.Read(dn_h.ln_h[i].nkicd, 0, dn_h.ln_h[i].nkicd.Length);  //          納期CD            
					ms.Read(dn_h.ln_h[i].hozcd, 0, dn_h.ln_h[i].hozcd.Length);  //          本部在庫CD        
					ms.Read(dn_h.ln_h[i].lerrC, 0, dn_h.ln_h[i].lerrC.Length);  //          ﾗｲﾝｴﾗｰC           
					ms.Read(dn_h.ln_h[i].lerrM, 0, dn_h.ln_h[i].lerrM.Length);  //          ﾗｲﾝｴﾗｰM           
				}
				
				//dummy
				ms.Read(dn_h.dummy, 0, dn_h.dummy.Length);                      // ﾗｲﾝ       dummy            

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
					case 0xF2:						//-- "ﾍﾝｼﾝﾃﾞｰﾀﾅｼ" --
						str = MSG_HEN;
						break;
					case 0xF3:						//-- "ﾉｳﾋﾝｺｰﾄﾞﾅｼ" --
						str = MSG_NOU;
						break;
					case 0xF4:						//-- "ﾃﾞｰﾀﾅｼ" --
						str = MSG_DAT;
						break;
					case 0xF5:						//-- "ｼﾃｲｷｮﾃﾝｴﾗｰ" --
						str = MSG_STK;
						break;
					case 0xC3:						//-- "ｶｼｭｳｳﾘｱｹﾞﾌｶ" --
						str = MSG_KUF;
						break;
					case 0xC4:						//-- "ﾊｯﾁｭｳﾀﾝﾄｳｼｬｴﾗｰ" --
						str = MSG_HTA;
						break;
					case 0xC5:						//-- "ﾌｫﾛｰﾉｰﾋﾝｺｰﾄﾞﾅｼ" --
						str = MSG_FNC;
						break;
					case 0xC6:						//-- "ｶｼｭｳｵｷｬｸｻﾏｺｰﾄﾞｴﾗｰ" --
						str = MSG_KOC;
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

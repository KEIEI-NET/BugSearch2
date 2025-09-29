//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : ＵＯＥ受信編集＜在庫＞（優良）アクセスクラス
// プログラム概要   : ＵＯＥ受信編集＜在庫＞（優良）を行う
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
	/// ＵＯＥ受信編集＜在庫＞（優良）アクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : ＵＯＥ受信編集＜在庫＞（優良）アクセスクラス</br>
	/// <br>Programmer : 96186 立花裕輔</br>
	/// <br>Date       : 2008.05.26</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// <br>2008.05.26 men 新規作成</br>
	/// </remarks>
	public partial class UoeRecEdit1001Acs
	{
		// ===================================================================================== //
		// プライベートメソッド
		// ===================================================================================== //
		# region Private Methods

		# region ＵＯＥ受信編集＜在庫＞（優良）
		/// <summary>
		/// ＵＯＥ受信編集＜在庫＞（優良）
		/// </summary>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        private int GetJnlStock1001(out string message)
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
                    TelegramJnlStock1001 telegramJnlStock1001 = new TelegramJnlStock1001();

                    foreach (UoeRecDtl dtl in uoeRecDtlList)
                    {
                        telegramJnlStock1001.Telegram(_uoeRecHed.UOESupplierCd, dtl);
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

		# region ＵＯＥ受信電文作成＜在庫＞（優良）
		/// <summary>
		/// ＵＯＥ受信電文作成＜在庫＞（優良）
		/// </summary>
		public class TelegramJnlStock1001 : UoeRecEdit1001Acs
		{
			# region ＰＭ７ソース
			//struct	DN_Z {					// 155 + 1893 = 2048          
			//	char	dn[1];					// ﾍｯﾀﾞ TTC  電文区分         
			//	char	sykb[1];				//           処理区分         
			//	char	res[2];					//           処理結果         
			//	char	dnbn[6];				//           電文問合せ番号   
			//	char	dngy[1];				//           回答電文対応行   
			//	char	rim[10];				//           ﾘﾏｰｸ	          
			//	char	nhkb[1];				//           納品区分         
			//	char	kyo[3];					//           指定拠点         
			//	char	g_hb[20];				//           受注部品番号     
			//	char	s_hb[20];				//           出荷部品番号     
			//	char	mkcd[4];				//           ﾒｰｶｰｺｰﾄﾞ         
			//	char	bncd[4];				//           分類ｺｰﾄﾞ         
			//	char	hinm[20];				//           品名		      
			//	char	tk[7];					//           定価	          
			//	char	sktk[7];				//           仕切り単価	      
			//	char	jysu[3];				//           受注数           
			//	char	sksu[3];				//           出荷数           
			//	char	bo[1];					//           B/O区分          
			//	char	yobi[1];				//           予備ｺｰﾄﾞ         
			//	char	bosu[3];				//           B/O数	          
			//	char	syno[6];				//           出荷伝票番号     
			//	char	bono[6];				//           B/O伝票番号      
			//	char	lner[15];				//           ﾗｲﾝｴﾗｰ		      
			//	char	ckcd[10];				//           ﾁｪｯｸｺｰﾄﾞ	      
			//	char	dummy[1893];			// ﾗｲﾝ       dummy            
			//};
			# endregion

			# region Const Members
			private const Int32 ctBufLen = 5;	//明細バッファサイズ

            private List<DN_Z> dn_z_List = new List<DN_Z>();
            # endregion

			# region Private Members
			//変数
			private Int32 _detailMax = 0;
			# endregion

			# region 電文領域クラス
			/// <summary>
			/// 在庫電文領域＜本体＞
			/// </summary>
			private class DN_Z
			{
				public byte[] dn = new byte[1];		    // ﾍｯﾀﾞ TTC  電文区分         
				public byte[] sykb = new byte[1];		//           処理区分         
				public byte[] res = new byte[2];		//           処理結果         
				public byte[] dnbn = new byte[6];		//           電文問合せ番号   
				public byte[] dngy = new byte[1];		//           回答電文対応行   
				public byte[] rim = new byte[10];		//           ﾘﾏｰｸ	          
				public byte[] nhkb = new byte[1];		//           納品区分         
				public byte[] kyo = new byte[3];		//           指定拠点         
				public byte[] g_hb = new byte[20];	    //           受注部品番号     
				public byte[] s_hb = new byte[20];	    //           出荷部品番号     
				public byte[] mkcd = new byte[4];		//           ﾒｰｶｰｺｰﾄﾞ         
				public byte[] bncd = new byte[4];		//           分類ｺｰﾄﾞ         
				public byte[] hinm = new byte[20];	    //           品名		      
				public byte[] tk = new byte[7];		    //           定価	          
				public byte[] sktk = new byte[7];		//           仕切り単価	      
				public byte[] jysu = new byte[3];		//           受注数           
				public byte[] sksu = new byte[3];		//           出荷数           
				public byte[] bo = new byte[1];		    //           B/O区分          
				public byte[] yobi = new byte[1];		//           予備ｺｰﾄﾞ         
				public byte[] bosu = new byte[3];		//           B/O数	          
				public byte[] syno = new byte[6];		//           出荷伝票番号     
				public byte[] bono = new byte[6];		//           B/O伝票番号      
				public byte[] lner = new byte[15];	    //           ﾗｲﾝｴﾗｰ		      
				public byte[] ckcd = new byte[10];	    //           ﾁｪｯｸｺｰﾄﾞ	      
				public byte[] dummy = new byte[101];	// ﾗｲﾝ       dummy            

				/// <summary>	
				/// コンストラクター
				/// </summary>
				public DN_Z()
				{
					Clear(0x00);
				}

				public void Clear(byte cd)
				{
					UoeCommonFnc.MemSet(ref dn, cd, dn.Length);			// ﾍｯﾀﾞ TTC  電文区分         
					UoeCommonFnc.MemSet(ref sykb, cd, sykb.Length);		//           処理区分         
					UoeCommonFnc.MemSet(ref res, cd, res.Length);		//           処理結果         
					UoeCommonFnc.MemSet(ref dnbn, cd, dnbn.Length);		//           電文問合せ番号   
					UoeCommonFnc.MemSet(ref dngy, cd, dngy.Length);		//           回答電文対応行   
					UoeCommonFnc.MemSet(ref rim, cd, rim.Length);		//           ﾘﾏｰｸ	          
					UoeCommonFnc.MemSet(ref nhkb, cd, nhkb.Length);		//           納品区分         
					UoeCommonFnc.MemSet(ref kyo, cd, kyo.Length);		//           指定拠点         
					UoeCommonFnc.MemSet(ref g_hb, cd, g_hb.Length);		//           受注部品番号     
					UoeCommonFnc.MemSet(ref s_hb, cd, s_hb.Length);		//           出荷部品番号     
					UoeCommonFnc.MemSet(ref mkcd, cd, mkcd.Length);		//           ﾒｰｶｰｺｰﾄﾞ         
					UoeCommonFnc.MemSet(ref bncd, cd, bncd.Length);		//           分類ｺｰﾄﾞ         
					UoeCommonFnc.MemSet(ref hinm, cd, hinm.Length);		//           品名		      
					UoeCommonFnc.MemSet(ref tk, cd, tk.Length);			//           定価	          
					UoeCommonFnc.MemSet(ref sktk, cd, sktk.Length);		//           仕切り単価	      
					UoeCommonFnc.MemSet(ref jysu, cd, jysu.Length);		//           受注数           
					UoeCommonFnc.MemSet(ref sksu, cd, sksu.Length);		//           出荷数           
					UoeCommonFnc.MemSet(ref bo, cd, bo.Length);			//           B/O区分          
					UoeCommonFnc.MemSet(ref yobi, cd, yobi.Length);		//           予備ｺｰﾄﾞ         
					UoeCommonFnc.MemSet(ref bosu, cd, bosu.Length);		//           B/O数	          
					UoeCommonFnc.MemSet(ref syno, cd, syno.Length);		//           出荷伝票番号     
					UoeCommonFnc.MemSet(ref bono, cd, bono.Length);		//           B/O伝票番号      
					UoeCommonFnc.MemSet(ref lner, cd, lner.Length);		//           ﾗｲﾝｴﾗｰ		      
					UoeCommonFnc.MemSet(ref ckcd, cd, ckcd.Length);		//           ﾁｪｯｸｺｰﾄﾞ	      
					UoeCommonFnc.MemSet(ref dummy, cd, dummy.Length);	// ﾗｲﾝ       dummy            
				}

			}
			# endregion

			# region Constructors
			/// <summary>
			/// コンストラクタ
			/// </summary>
			public TelegramJnlStock1001()
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
                
				//電文の行数取得
				_detailMax = dtl.UOESalesOrderRowNo.Count;

                //バイト型配列に変換
                FromByteArray(dtl.RecTelegram, _detailMax);

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

                    DN_Z dn_z = dn_z_List[i];

					//データ送信区分
                    dataRow[StockSndRcvJnlSchema.ct_Col_DataSendCode] = dtl.DataSendCode;

					//データ復旧区分
					dataRow[StockSndRcvJnlSchema.ct_Col_DataRecoverDiv] = dtl.DataRecoverDiv;

					//受信日付
					dataRow[StockSndRcvJnlSchema.ct_Col_ReceiveDate] = DateTime.Now;

					//受信時間
					dataRow[StockSndRcvJnlSchema.ct_Col_ReceiveTime] = TDateTime.DateTimeToLongDate("HHMMSS", DateTime.Now);

					// ＵＯＥリマーク１
					dataRow[StockSndRcvJnlSchema.ct_Col_UoeRemark1] = UoeCommonFnc.ToStringFromByteStrAry(dn_z.rim);

					// 回答品番
					string g_hb = UoeCommonFnc.ToStringFromByteStrAry(dn_z.g_hb);
					dataRow[StockSndRcvJnlSchema.ct_Col_AnswerPartsNo] = g_hb;

					// 代替品番(出荷部品番号)
					string s_hb = UoeCommonFnc.ToStringFromByteStrAry(dn_z.s_hb);
					if(s_hb.Trim() != g_hb.Trim())
					{
						dataRow[StockSndRcvJnlSchema.ct_Col_SubstPartsNo] = s_hb;
					}

					// 回答品名
					dataRow[StockSndRcvJnlSchema.ct_Col_AnswerPartsName] = UoeCommonFnc.ToStringFromByteStrAry(dn_z.hinm);

					// 摘要定価(定価 浮動)
                    dataRow[StockSndRcvJnlSchema.ct_Col_AnswerListPrice] = UoeCommonFnc.ToDoubleFromByteStrAry(dn_z.tk);

					//原価単価(仕切単価)
                    double sktk = UoeCommonFnc.ToDoubleFromByteStrAry(dn_z.sktk);
                    if (_uoeSndRcvJnlAcs.ChkMeiji(uOESupplierCd) == true)
                    {
                        sktk = sktk / 10;
                    }
                    dataRow[StockSndRcvJnlSchema.ct_Col_AnswerSalesUnitCost] = sktk;

					// 回答メーカーコードを発注メーカーにセット
					if((s_hb.Trim() != "") || (s_hb.Trim() != g_hb.Trim()))	//品番ﾁｪｯｸ
					{
						//商品メーカーコード
						if((int)dataRow[StockSndRcvJnlSchema.ct_Col_GoodsMakerCd] == 0)
						{
							dataRow[StockSndRcvJnlSchema.ct_Col_GoodsMakerCd] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.mkcd);
						}

						//伝票印刷用品番
						//if (memcmp(uoejla.D3010H, uoejla.D3010P, 15) == 0 && uoejla.D3018P == 0)
						//{
						//	// 印刷メーカーコード
						//	dataRow[StockSndRcvJnlSchema.] = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.mkcd);
						//}
					
						// UOE代替コード
						dataRow[StockSndRcvJnlSchema.ct_Col_UOESubstCode] = "  ";
					}
					else
					{
						// UOE代替コード
						dataRow[StockSndRcvJnlSchema.ct_Col_UOESubstCode] = "01";
					}

					// UOE拠点出庫数
					int sksu = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.sksu);
					if(sksu > 999)
					{
						sksu = 999;
					}
                    dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock1] = sksu;

					// BO出庫数1(本部ﾌｫﾛｰ数)
					int bosu = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.bosu);
					if(bosu > 999)
					{
						sksu = 999;
					}
                    dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock2] = bosu;

					// ラインエラーメッセージ
					dataRow[StockSndRcvJnlSchema.ct_Col_LineErrorMassage] = UoeCommonFnc.ToStringFromByteStrAry(dn_z.lner);
				}
			}
			# endregion

			# endregion

			# region private Methods

			# region バイト型配列に変換
            /// <summary>
            /// バイト型配列に変換
            /// </summary>
            /// <param name="line">変換元バッファ</param>
            /// <param name="maxLen"></param>
            private void FromByteArray(byte[] line, int maxCnt)
            {
                dn_z_List.Clear();

                MemoryStream ms = new MemoryStream();
				ms.Write(line, 0, line.Length);
                ms.Seek(0, SeekOrigin.Begin);

                for (int i = 0; i < maxCnt; i++)
                {
                    DN_Z dn_z = new DN_Z();
                    ms.Read(dn_z.dn, 0, dn_z.dn.Length);        // ﾍｯﾀﾞ TTC  電文区分         
                    ms.Read(dn_z.sykb, 0, dn_z.sykb.Length);    //           処理区分         
                    ms.Read(dn_z.res, 0, dn_z.res.Length);      //           処理結果         
                    ms.Read(dn_z.dnbn, 0, dn_z.dnbn.Length);    //           電文問合せ番号   
                    ms.Read(dn_z.dngy, 0, dn_z.dngy.Length);    //           回答電文対応行   
                    ms.Read(dn_z.rim, 0, dn_z.rim.Length);      //           ﾘﾏｰｸ	          
                    ms.Read(dn_z.nhkb, 0, dn_z.nhkb.Length);    //           納品区分         
                    ms.Read(dn_z.kyo, 0, dn_z.kyo.Length);      //           指定拠点         
                    ms.Read(dn_z.g_hb, 0, dn_z.g_hb.Length);    //           受注部品番号     
                    ms.Read(dn_z.s_hb, 0, dn_z.s_hb.Length);    //           出荷部品番号     
                    ms.Read(dn_z.mkcd, 0, dn_z.mkcd.Length);    //           ﾒｰｶｰｺｰﾄﾞ         
                    ms.Read(dn_z.bncd, 0, dn_z.bncd.Length);    //           分類ｺｰﾄﾞ         
                    ms.Read(dn_z.hinm, 0, dn_z.hinm.Length);    //           品名		      
                    ms.Read(dn_z.tk, 0, dn_z.tk.Length);        //           定価	          
                    ms.Read(dn_z.sktk, 0, dn_z.sktk.Length);    //           仕切り単価	      
                    ms.Read(dn_z.jysu, 0, dn_z.jysu.Length);    //           受注数           
                    ms.Read(dn_z.sksu, 0, dn_z.sksu.Length);    //           出荷数           
                    ms.Read(dn_z.bo, 0, dn_z.bo.Length);        //           B/O区分          
                    ms.Read(dn_z.yobi, 0, dn_z.yobi.Length);    //           予備ｺｰﾄﾞ         
                    ms.Read(dn_z.bosu, 0, dn_z.bosu.Length);    //           B/O数	          
                    ms.Read(dn_z.syno, 0, dn_z.syno.Length);    //           出荷伝票番号     
                    ms.Read(dn_z.bono, 0, dn_z.bono.Length);    //           B/O伝票番号      
                    ms.Read(dn_z.lner, 0, dn_z.lner.Length);    //           ﾗｲﾝｴﾗｰ		      
                    ms.Read(dn_z.ckcd, 0, dn_z.ckcd.Length);    //           ﾁｪｯｸｺｰﾄﾞ	      
                    ms.Read(dn_z.dummy, 0, dn_z.dummy.Length);   // ﾗｲﾝ       dummy   

                    dn_z_List.Add(dn_z);
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

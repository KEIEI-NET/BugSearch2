//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : ＵＯＥ受信編集＜発注＞（ホンダ）アクセスクラス
// プログラム概要   : ＵＯＥ受信編集＜発注＞（ホンダ）を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10501071-00 作成担当 : 立花 裕輔
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
	/// ＵＯＥ受信編集＜発注＞（ホンダ）アクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : ＵＯＥ受信編集（ホンダ）アクセスクラス</br>
	/// <br>Programmer : 96186 立花裕輔</br>
	/// <br>Date       : 2008.05.26</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// <br>2008.05.26 men 新規作成</br>
	/// </remarks>
	public partial class UoeRecEdit0501Acs
	{
		// ===================================================================================== //
		// プライベートメソッド
		// ===================================================================================== //
		# region Private Methods

		# region ＵＯＥ受信編集＜発注＞（ホンダ）
		/// <summary>
		/// ＵＯＥ受信編集＜発注＞（ホンダ）
		/// </summary>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        private int GetJnlOrder0501(out string message)
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
                    TelegramJnlOrder0501 telegramJnlOrder0501 = new TelegramJnlOrder0501();
                    telegramJnlOrder0501.Telegram(_uoeRecHed);
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

		# region ＵＯＥ受信電文作成＜発注＞（ホンダ）
		/// <summary>
		/// ＵＯＥ受信電文作成＜発注＞（ホンダ）
		/// </summary>
		public class TelegramJnlOrder0501 : UoeRecEdit0501Acs
		{
			# region ＰＭ７ソース
            // /************************************************************/
            // /********            発注  全体ヘッダー部            ********/
            // /************************************************************/
            // struct HHD_1 {				/* 発注  第一電文  	65byte	*/
            // 	char	sei[8];				/* 制御部					*/
            // 	char	skb_flg[1];			/* 識別フラグ				*/
            // 	char	kak_era[10];		/* 拡張エリア				*/
            // 	char	date[8];			/* 日付						*/
            // 	char	time[8];			/* 時間						*/
            // 	char	msg[2];				/* 全体メッセージ			*/
            // 	char	seq[3];				/* ＳＥＱ					*/
            // 	char	ymdtime[6];			/* 年月日月時秒				*/
            // 	char	kei_flg[1];			/* 継続フラグ				*/
            // 	char	item[5];			/* アイテム					*/
            // 	char	deno[6];			/* 伝票Ｎｏ					*/
            // 	char	dai_cd[5];			/* 代理店コード				*/
            // 	char	kensu[2];			/* 全体件数					*/
            // };
            // 
            // struct HHD_5 {					// 第一電文ヘッダーエラー
            // 	char	head[47];
            // 	char	msg[40];
            // };
            // /************************************************************/
            // /********            発注  データ部                  ********/
            // /************************************************************/
            // struct	HDT_1_R {			/* 発注  識別１				*/
            // 	char	on_no[2];			/* オンラインＮｏ			*/
            // 	char	skb_flg[1];			/* 識別フラグ				*/
            // 	char	hb[15];				/* 出荷品番					*/
            // 	char	sijisu[3];			/* 指示数					*/
            // 	char	hky[5];				/* 出荷元					*/
            // 	char	k_kk[7];			/* 希望価格					*/
            // 	char	h_kk[7];			/* 販売価格					*/
            // 	char	nm[17];				/* 品名						*/
            // 	char	dsp_hb[15];			/* 表示用部品				*/
            // 	char	mark[1];			/* マーク					*/
            // };
            // 
            // struct	HDT_21_R {			/* 発注  識別２ー１			*/
            // 	char	on_no[2];			/* オンラインＮｏ			*/
            // 	char	skb_flg[1];			/* 識別フラグ				*/
            // 	char	spc[13];			/* 空白						*/
            // 	char	nkim[1];			/* 納期Ｍ					*/
            // 	char	daim[1];			/* 代替Ｍ					*/
            // 	char	orosi[3];			/* 卸						*/
            // 	char	ta[3];				/* 他						*/
            // 	char	hm[2];				/* ＨＭ						*/
            // 	char	k_kk[7];			/* 希望価格					*/
            // 	char	h_kk[7];			/* 販売価格					*/
            // 	char	nm[17];				/* 品名						*/
            // 	char	dsp_hb[15];			/* 表示用部品				*/
            // 	char	mark[1];			/* マーク					*/
            // };
            // 
            // struct	HDT_22_R {				/* 発注  識別２ー２			*/
            // 	char	on_no[2];			/* オンラインＮｏ			*/
            // 	char	skb_flg[1];			/* 識別フラグ				*/
            // 	char	msg[10];			/* メッセージ				*/
            // 	char	bo[3];				/* Ｂ／Ｏ数					*/
            // 	char	spc[24];			/* 空白						*/
            // 	char	nm[17];				/* 品名						*/
            // 	char	dsp_hb[15];			/* 表示用部品				*/
            // 	char	mark[1];			/* マーク					*/
            // };
            // 
            // struct	HDT_3_R {				/* 発注  識別３				*/
            // 	char	on_no[2];			/* オンラインＮｏ			*/
            // 	char	skb_flg[1];			/* 識別フラグ				*/
            // 	char	spc[37];			/* 空白						*/
            // 	char	msg[17];			/* メッセージ				*/
            // 	char	dsp_hb[15];			/* 表示用部品				*/
            // 	char	mark[1];			/* マーク					*/
            // };
            // 
            # endregion

			# region Const Members
            private const Int32 ctTelegramMax = 510;//最大電文長
            private const Int32 ctBufLen = 6;		//明細バッファサイズ
            private const Int32 ctDt_hLen = 73;     //データ部レコードサイズ
			# endregion

			# region 電文領域クラス

            # region 発注受信データ
            /// <summary>
            /// 発注受信データ
            /// </summary>
            private class HRV_BUFF
            {
                //発注ヘッダー部
                public int _uOESalesOrderNo = 0;                    // UOE発注番号
                public List<int> _uOESalesOrderRowNoList = null;    //UOE発注番号行番号

                public int _dataSendCode = 0;                       // データ送信区分
                public int _dataRecoverDiv = 0;                     // データ復旧区分

                public int divHRV = 0;              // 識別フラグ 0:データ部更新 1,3:エラー制御部セット 2:ヘッダーエラーセット
                public HHD_1 hhd_1 = null;          // 第一電文
                public HHD_ERR hhd_err = null;          // 第一電文ヘッダーエラー


                // 発注データ部
                public List<DT_H> dt_h_List = null;

                public HRV_BUFF()
                {
                    Clear();
                }

                public void Clear()
                {
                    _uOESalesOrderNo = 0;

                    if(_uOESalesOrderRowNoList == null)
                    {
                        _uOESalesOrderRowNoList = new List<int>();
                    }
                    else
                    {
                        _uOESalesOrderRowNoList.Clear();
                    }

                    divHRV = 0;
                    hhd_1 = null;
                    hhd_err = null;

                    if (dt_h_List == null)
                    {
                        dt_h_List = new List<DT_H>();
                    }
                    else
                    {
                        dt_h_List.Clear();
                    }
                }

                public void Setting(UoeRecDtl uoeRecDtl)
                {
                    # region ヘッダー部更新
                    //ヘッダー部更新
                    //第１電文処理
                    //UOE発注番号 UOE発注行番号の保存
                    _uOESalesOrderNo = uoeRecDtl.UOESalesOrderNo;
                    _uOESalesOrderRowNoList = new List<int>();
                    _uOESalesOrderRowNoList.AddRange(uoeRecDtl.UOESalesOrderRowNo);

                    //識別フラグ
                    divHRV = UoeCommonFnc.atobs(uoeRecDtl.RecTelegram, 8, 1);

                    // エラー制御部
                    if ((divHRV >= 1) && divHRV <= 3)
                    {
                        hhd_err = new HHD_ERR();
                        hhd_err.Setting(uoeRecDtl.RecTelegram, 0);
                        return;
                    }
                    //第一電文ヘッダー格納処理
                    else
                    {
                        hhd_1 = new HHD_1();
                        hhd_1.Setting(uoeRecDtl.RecTelegram, 0);
                    }
			        # endregion

                    # region データ部更新
                    // データ部　更新
                    if (divHRV == 0)
                    {
                        int start = 65;                                 //第一電文位置の設定
                        int maxSize = uoeRecDtl.RecTelegramLen;         //総サイズ
                        int blkSize = maxSize / ctTelegramMax;          //電文数
                        if ((maxSize % ctTelegramMax) != 0) blkSize++;

                        for (int blkCnt = 0; blkCnt < blkSize; blkCnt++)
                        {
                            for (int i = 0; i < ctBufLen; i++)
                            {
                                //(電文開始オフセット) + (初回データ部オフセット) +(データ部開始オフセット)
                                int idx = (ctTelegramMax * blkCnt) + start + (i * ctDt_hLen);

                                //データなし判定
                                if ((idx + ctDt_hLen) > uoeRecDtl.RecTelegramLen) break;
                                if (UoeCommonFnc.MemCmp(uoeRecDtl.RecTelegram, idx, 0x20, ctDt_hLen) == 0) break;
                                if (UoeCommonFnc.MemCmp(uoeRecDtl.RecTelegram, idx, 0x00, ctDt_hLen) == 0) break;

                                //データ部格納処理
                                DT_H dt_h = new DT_H();
                                dt_h.Setting(uoeRecDtl.RecTelegram, idx);
                                dt_h_List.Add(dt_h);
                            }
                            start = 8;                    // 第二電文位置の設定
                        }
                    }
        			# endregion
                }
            }
			# endregion

            # region 電文ヘッダー
            /// <summary>
            /// 電文ヘッダー
            /// </summary>
            private class HHD_1
            {
                public byte[] sei = new byte[8];			// 制御部					
                public byte[] skb_flg = new byte[1];		// 識別フラグ				
                public byte[] kak_era = new byte[10];		// 拡張エリア				
                public byte[] date = new byte[8];			// 日付						
                public byte[] time = new byte[8];			// 時間						
                public byte[] msg = new byte[2];			// 全体メッセージ			
                public byte[] seq = new byte[3];			// ＳＥＱ					
                public byte[] ymdtime = new byte[6];		// 年月日月時秒				
                public byte[] kei_flg = new byte[1];		// 継続フラグ				
                public byte[] item = new byte[5];			// アイテム					
                public byte[] deno = new byte[6];			// 伝票Ｎｏ					
                public byte[] dai_cd = new byte[5];			// 代理店コード				
                public byte[] kensu = new byte[2];			// 全体件数					

                public HHD_1()
				{
					Clear(0x00);
				}

				public void Clear(byte cd)
				{
                    UoeCommonFnc.MemSet(ref sei, cd, sei.Length);			// 制御部					
                    UoeCommonFnc.MemSet(ref skb_flg, cd, skb_flg.Length);	// 識別フラグ				
                    UoeCommonFnc.MemSet(ref kak_era, cd, kak_era.Length);	// 拡張エリア				
                    UoeCommonFnc.MemSet(ref date, cd, date.Length);			// 日付						
                    UoeCommonFnc.MemSet(ref time, cd, time.Length);			// 時間						
                    UoeCommonFnc.MemSet(ref msg, cd, msg.Length);			// 全体メッセージ			
                    UoeCommonFnc.MemSet(ref seq, cd, seq.Length);			// ＳＥＱ					
                    UoeCommonFnc.MemSet(ref ymdtime, cd, ymdtime.Length);	// 年月日月時秒				
                    UoeCommonFnc.MemSet(ref kei_flg, cd, kei_flg.Length);	// 継続フラグ				
                    UoeCommonFnc.MemSet(ref item, cd, item.Length);			// アイテム					
                    UoeCommonFnc.MemSet(ref deno, cd, deno.Length);			// 伝票Ｎｏ					
                    UoeCommonFnc.MemSet(ref dai_cd, cd, dai_cd.Length);		// 代理店コード				
                    UoeCommonFnc.MemSet(ref kensu, cd, kensu.Length);		// 全体件数		

                }

                public void Setting(byte[] line, int start)
                {
                    MemoryStream ms = new MemoryStream();
                    ms.Write(line, 0, line.Length);
                    ms.Seek(start, SeekOrigin.Begin);

                    ms.Read(sei, 0, sei.Length);			// 制御部					
                    ms.Read(skb_flg, 0, skb_flg.Length);	// 識別フラグ				
                    ms.Read(kak_era, 0, kak_era.Length);	// 拡張エリア				
                    ms.Read(date, 0, date.Length);			// 日付						
                    ms.Read(time, 0, time.Length);			// 時間						
                    ms.Read(msg, 0, msg.Length);			// 全体メッセージ			
                    ms.Read(seq, 0, seq.Length);			// ＳＥＱ					
                    ms.Read(ymdtime, 0, ymdtime.Length);	// 年月日月時秒				
                    ms.Read(kei_flg, 0, kei_flg.Length);	// 継続フラグ				
                    ms.Read(item, 0, item.Length);			// アイテム					
                    ms.Read(deno, 0, deno.Length);			// 伝票Ｎｏ					
                    ms.Read(dai_cd, 0, dai_cd.Length);		// 代理店コード				
                    ms.Read(kensu, 0, kensu.Length);		// 全体件数					

                    ms.Close();
                }
            }
			# endregion

            # region 電文ヘッダーエラー
            /// <summary>
            /// 電文ヘッダーエラー
            /// </summary>
            private class HHD_ERR
            {
                public byte[] sei = new byte[8];			// 制御部					
                public byte[] skb_flg = new byte[1];		// 識別フラグ				
                public byte[] kak_era = new byte[10];		// 拡張エリア				
                public byte[] date = new byte[8];			// 日付						
                public byte[] time = new byte[8];			// 時間						
                public byte[] msg = new byte[2];			// 全体メッセージ			
                public byte[] seq = new byte[3];			// ＳＥＱ					
                public byte[] ymdtime = new byte[6];		// 年月日月時秒				
                public byte[] kei_flg = new byte[1];		// 継続フラグ				
                public byte[] errmsg = new byte[40];

                public HHD_ERR()
				{
					Clear(0x00);
				}
				
				public void Clear(byte cd)
				{
                    UoeCommonFnc.MemSet(ref sei, cd, sei.Length);			// 制御部					
                    UoeCommonFnc.MemSet(ref skb_flg, cd, skb_flg.Length);	// 識別フラグ				
                    UoeCommonFnc.MemSet(ref kak_era, cd, kak_era.Length);	// 拡張エリア				
                    UoeCommonFnc.MemSet(ref date, cd, date.Length);			// 日付						
                    UoeCommonFnc.MemSet(ref time, cd, time.Length);			// 時間						
                    UoeCommonFnc.MemSet(ref msg, cd, msg.Length);			// 全体メッセージ			
                    UoeCommonFnc.MemSet(ref seq, cd, seq.Length);			// ＳＥＱ					
                    UoeCommonFnc.MemSet(ref ymdtime, cd, ymdtime.Length);	// 年月日月時秒				
                    UoeCommonFnc.MemSet(ref kei_flg, cd, kei_flg.Length);	// 継続フラグ				
                    UoeCommonFnc.MemSet(ref errmsg, cd, msg.Length);
                }

                public void Setting(byte[] line, int start)
                {
                    MemoryStream ms = new MemoryStream();
                    ms.Write(line, 0, line.Length);
                    ms.Seek(start, SeekOrigin.Begin);

                    ms.Read(sei, 0, sei.Length);			// 制御部					
                    ms.Read(skb_flg, 0, skb_flg.Length);	// 識別フラグ				
                    ms.Read(kak_era, 0, kak_era.Length);	// 拡張エリア				
                    ms.Read(date, 0, date.Length);			// 日付						
                    ms.Read(time, 0, time.Length);			// 時間						
                    ms.Read(msg, 0, msg.Length);			// 全体メッセージ			
                    ms.Read(seq, 0, seq.Length);			// ＳＥＱ					
                    ms.Read(ymdtime, 0, ymdtime.Length);	// 年月日月時秒				
                    ms.Read(kei_flg, 0, kei_flg.Length);	// 継続フラグ				
                    ms.Read(errmsg, 0, errmsg.Length);

                    ms.Close();
                }
            }
			# endregion

            # region データ部
            # region 発注データ部メイン
            /// <summary>
            /// 発注データ部メイン
            /// </summary>
            private class DT_H
            {
                public int divHDT = 0;              // 識別フラグ 1:識別1 21:識別2-1 22:識別2-2 3:発注3
                public int _uOESalesOrderRowNo = 0; // UOE発注行番号

                public HDT_1_R hdt_1 = null;	    // 発注　データ部（識別1）
                public HDT_21_R hdt_21 = null;	    // 発注　データ部（識別2-1）
                public HDT_22_R hdt_22 = null;	    // 発注　データ部（識別2-2）
                public HDT_3_R hdt_3 = null;	    // 発注　データ部（識別3）

                public DT_H()
                {
                    Clear();
                }

                public void Clear()
                {
                    divHDT = 0;
                    _uOESalesOrderRowNo = 0;
                    hdt_1 = null;
                    hdt_21 = null;
                    hdt_22 = null;
                    hdt_3 = null;
                }

                public void Setting(byte[] line, int start)
                {
                    try
                    {
                        if(line == null)    return;

                        Clear();

                        //識別 1 or 3 判定
                        divHDT = UoeCommonFnc.atobs(line, start + 2, 1);

                        //識別 2-1 or 2-2 判定
                        if(divHDT == 2)
                        {
                            if ((UoeCommonFnc.MemCmp(line, start+3, 0x20, 13) == 0)
                            && (UoeCommonFnc.MemCmp(line, start+16, 0x20, 24) != 0))
                            {
                                divHDT = 21;
                            }
                            else
                            {
                                divHDT = 22;
                            }
                        }

                        switch(divHDT)
                        {
                            case 1:
                                hdt_1 = new HDT_1_R();
                                hdt_1.Setting(line, start);
                                _uOESalesOrderRowNo = UoeCommonFnc.atobs(hdt_1.on_no, hdt_1.on_no.Length);
                                break;
                            case 21:
                                hdt_21 = new HDT_21_R();
                                hdt_21.Setting(line, start);
                                _uOESalesOrderRowNo = UoeCommonFnc.atobs(hdt_21.on_no, hdt_21.on_no.Length);
                                break;
                            case 22:
                                hdt_22 = new HDT_22_R();
                                hdt_22.Setting(line, start);
                                _uOESalesOrderRowNo = UoeCommonFnc.atobs(hdt_22.on_no, hdt_22.on_no.Length);
                                break;
                            case 3:
                                hdt_3 = new HDT_3_R();
                                hdt_3.Setting(line, start);
                                _uOESalesOrderRowNo = UoeCommonFnc.atobs(hdt_3.on_no, hdt_3.on_no.Length);
                                break;
                            default:
                                divHDT = 0;
                                _uOESalesOrderRowNo = 0;
                                break;
                        }
                    }
                    catch (Exception)
                    {
                        Clear();
                    }
                }
            }
            # endregion

            # region 発注データ部(識別１)
            /// <summary>
            /// 発注データ部(識別１)
            /// </summary>
            private class HDT_1_R
            {
                public byte[] on_no = new byte[2];			// オンラインＮｏ			
                public byte[] skb_flg = new byte[1];		// 識別フラグ				
                public byte[] hb = new byte[15];			// 出荷品番					
                public byte[] sijisu = new byte[3];			// 指示数					
                public byte[] hky = new byte[5];			// 出荷元					
                public byte[] k_kk = new byte[7];			// 希望価格					
                public byte[] h_kk = new byte[7];			// 販売価格					
                public byte[] nm = new byte[17];			// 品名						
                public byte[] dsp_hb = new byte[15];		// 表示用部品				
                public byte[] mark = new byte[1];			// マーク					

                public HDT_1_R()
				{
					Clear(0x00);
				}

                public HDT_1_R(byte[] line, int start)
                {
                    Clear(0x00);
                }
				

				public void Clear(byte cd)
				{
                    UoeCommonFnc.MemSet(ref on_no, cd, on_no.Length);		// オンラインＮｏ			
                    UoeCommonFnc.MemSet(ref skb_flg, cd, skb_flg.Length);	// 識別フラグ				
                    UoeCommonFnc.MemSet(ref hb, cd, hb.Length);				// 出荷品番					
                    UoeCommonFnc.MemSet(ref sijisu, cd, sijisu.Length);		// 指示数					
                    UoeCommonFnc.MemSet(ref hky, cd, hky.Length);			// 出荷元					
                    UoeCommonFnc.MemSet(ref k_kk, cd, k_kk.Length);			// 希望価格					
                    UoeCommonFnc.MemSet(ref h_kk, cd, h_kk.Length);			// 販売価格					
                    UoeCommonFnc.MemSet(ref nm, cd, nm.Length);				// 品名						
                    UoeCommonFnc.MemSet(ref dsp_hb, cd, dsp_hb.Length);		// 表示用部品				
                    UoeCommonFnc.MemSet(ref mark, cd, mark.Length);			// マーク					
                }

                public void Setting(byte[] line, int start)
                {
                    MemoryStream ms = new MemoryStream();
                    ms.Write(line, 0, line.Length);
                    ms.Seek(start, SeekOrigin.Begin);

                    ms.Read(on_no, 0, on_no.Length);		// オンラインＮｏ			
                    ms.Read(skb_flg, 0, skb_flg.Length);	// 識別フラグ				
                    ms.Read(hb, 0, hb.Length);				// 出荷品番					
                    ms.Read(sijisu, 0, sijisu.Length);		// 指示数					
                    ms.Read(hky, 0, hky.Length);			// 出荷元					
                    ms.Read(k_kk, 0, k_kk.Length);			// 希望価格					
                    ms.Read(h_kk, 0, h_kk.Length);			// 販売価格					
                    ms.Read(nm, 0, nm.Length);				// 品名						
                    ms.Read(dsp_hb, 0, dsp_hb.Length);		// 表示用部品				
                    ms.Read(mark, 0, mark.Length);			// マーク					

                    ms.Close();
                }
            }
			# endregion

            # region 発注データ部(識別２ー１)
            /// <summary>
            /// 発注データ部(識別２ー１)
            /// </summary>
            private class HDT_21_R
            {
                public byte[] on_no = new byte[2];			// オンラインＮｏ			
                public byte[] skb_flg = new byte[1];		// 識別フラグ				
                public byte[] spc = new byte[13];			// 空白						
                public byte[] nkim = new byte[1];			// 納期Ｍ					
                public byte[] daim = new byte[1];			// 代替Ｍ					
                public byte[] orosi = new byte[3];			// 卸						
                public byte[] ta = new byte[3];				// 他						
                public byte[] hm = new byte[2];				// ＨＭ						
                public byte[] k_kk = new byte[7];			// 希望価格					
                public byte[] h_kk = new byte[7];			// 販売価格					
                public byte[] nm = new byte[17];			// 品名						
                public byte[] dsp_hb = new byte[15];		// 表示用部品				
                public byte[] mark = new byte[1];			// マーク					

                public HDT_21_R()
				{
					Clear(0x00);
				}
				
				public void Clear(byte cd)
				{
                    UoeCommonFnc.MemSet(ref on_no, cd, on_no.Length);		// オンラインＮｏ			
                    UoeCommonFnc.MemSet(ref skb_flg, cd, skb_flg.Length);	// 識別フラグ				
                    UoeCommonFnc.MemSet(ref spc, cd, spc.Length);			// 空白						
                    UoeCommonFnc.MemSet(ref nkim, cd, nkim.Length);			// 納期Ｍ					
                    UoeCommonFnc.MemSet(ref daim, cd, daim.Length);			// 代替Ｍ					
                    UoeCommonFnc.MemSet(ref orosi, cd, orosi.Length);		// 卸						
                    UoeCommonFnc.MemSet(ref ta, cd, ta.Length);				// 他						
                    UoeCommonFnc.MemSet(ref hm, cd, hm.Length);				// ＨＭ						
                    UoeCommonFnc.MemSet(ref k_kk, cd, k_kk.Length);			// 希望価格					
                    UoeCommonFnc.MemSet(ref h_kk, cd, h_kk.Length);			// 販売価格					
                    UoeCommonFnc.MemSet(ref nm, cd, nm.Length);				// 品名						
                    UoeCommonFnc.MemSet(ref dsp_hb, cd, dsp_hb.Length);		// 表示用部品				
                    UoeCommonFnc.MemSet(ref mark, cd, mark.Length);			// マーク					
                }

                public void Setting(byte[] line, int start)
                {
                    MemoryStream ms = new MemoryStream();
                    ms.Write(line, 0, line.Length);
                    ms.Seek(start, SeekOrigin.Begin);

                    ms.Read(on_no, 0, on_no.Length);		// オンラインＮｏ			
                    ms.Read(skb_flg, 0, skb_flg.Length);	// 識別フラグ				
                    ms.Read(spc, 0, spc.Length);			// 空白						
                    ms.Read(nkim, 0, nkim.Length);		// 納期Ｍ					
                    ms.Read(daim, 0, daim.Length);		// 代替Ｍ					
                    ms.Read(orosi, 0, orosi.Length);		// 卸						
                    ms.Read(ta, 0, ta.Length);			// 他						
                    ms.Read(hm, 0, hm.Length);			// ＨＭ						
                    ms.Read(k_kk, 0, k_kk.Length);		// 希望価格					
                    ms.Read(h_kk, 0, h_kk.Length);		// 販売価格					
                    ms.Read(nm, 0, nm.Length);			// 品名						
                    ms.Read(dsp_hb, 0, dsp_hb.Length);	// 表示用部品				
                    ms.Read(mark, 0, mark.Length);		// マーク					

                    ms.Close();
                }
            }
			# endregion

            # region 発注データ部(識別２ー２)
            /// <summary>
            /// 発注データ部(識別２ー２)
            /// </summary>
            private class HDT_22_R
            {
                public byte[] on_no = new byte[2];			// オンラインＮｏ			
                public byte[] skb_flg = new byte[1];		// 識別フラグ				
                public byte[] msg = new byte[10];			// メッセージ				
                public byte[] bo = new byte[3];				// Ｂ／Ｏ数					
                public byte[] spc = new byte[24];			// 空白						
                public byte[] nm = new byte[17];			// 品名						
                public byte[] dsp_hb = new byte[15];		// 表示用部品				
                public byte[] mark = new byte[1];			// マーク					

                public HDT_22_R()
				{
					Clear(0x00);
				}
				
				public void Clear(byte cd)
				{
                    UoeCommonFnc.MemSet(ref on_no, cd, on_no.Length);		// オンラインＮｏ			
                    UoeCommonFnc.MemSet(ref skb_flg, cd, skb_flg.Length);	// 識別フラグ				
                    UoeCommonFnc.MemSet(ref msg, cd, msg.Length);			// メッセージ				
                    UoeCommonFnc.MemSet(ref bo, cd, bo.Length);				// Ｂ／Ｏ数					
                    UoeCommonFnc.MemSet(ref spc, cd, spc.Length);			// 空白						
                    UoeCommonFnc.MemSet(ref nm, cd, nm.Length);				// 品名						
                    UoeCommonFnc.MemSet(ref dsp_hb, cd, dsp_hb.Length);		// 表示用部品				
                    UoeCommonFnc.MemSet(ref mark, cd, mark.Length);			// マーク					
                }

                public void Setting(byte[] line, int start)
                {
                    MemoryStream ms = new MemoryStream();
                    ms.Write(line, 0, line.Length);
                    ms.Seek(start, SeekOrigin.Begin);

                    ms.Read(on_no, 0, on_no.Length);		// オンラインＮｏ			
                    ms.Read(skb_flg, 0, skb_flg.Length);	// 識別フラグ				
                    ms.Read(msg, 0, msg.Length);			// メッセージ				
                    ms.Read(bo, 0, bo.Length);			// Ｂ／Ｏ数					
                    ms.Read(spc, 0, spc.Length);			// 空白						
                    ms.Read(nm, 0, nm.Length);			// 品名						
                    ms.Read(dsp_hb, 0, dsp_hb.Length);	// 表示用部品				
                    ms.Read(mark, 0, mark.Length);		// マーク					

                    ms.Close();
                }
            }
			# endregion

            # region 発注データ部(識別３)
            /// <summary>
            /// 発注データ部(識別３)
            /// </summary>
            private class HDT_3_R
            {
                public byte[] on_no = new byte[2];			// オンラインＮｏ			
                public byte[] skb_flg = new byte[1];		// 識別フラグ				
                public byte[] spc = new byte[37];			// 空白						
                public byte[] msg = new byte[17];			// メッセージ				
                public byte[] dsp_hb = new byte[15];		// 表示用部品				
                public byte[] mark = new byte[1];			// マーク					

                public HDT_3_R()
				{
					Clear(0x00);
				}
				
				public void Clear(byte cd)
				{
                    UoeCommonFnc.MemSet(ref on_no, cd, on_no.Length);		// オンラインＮｏ			
                    UoeCommonFnc.MemSet(ref skb_flg, cd, skb_flg.Length);	// 識別フラグ				
                    UoeCommonFnc.MemSet(ref spc, cd, spc.Length);			// 空白						
                    UoeCommonFnc.MemSet(ref msg, cd, msg.Length);			// メッセージ				
                    UoeCommonFnc.MemSet(ref dsp_hb, cd, dsp_hb.Length);		// 表示用部品				
                    UoeCommonFnc.MemSet(ref mark, cd, mark.Length);			// マーク					
                }

                public void Setting(byte[] line, int start)
                {
                    MemoryStream ms = new MemoryStream();
                    ms.Write(line, 0, line.Length);
                    ms.Seek(start, SeekOrigin.Begin);

                    ms.Read(on_no, 0, on_no.Length);		// オンラインＮｏ			
                    ms.Read(skb_flg, 0, skb_flg.Length);	// 識別フラグ				
                    ms.Read(spc, 0, spc.Length);			// 空白						
                    ms.Read(msg, 0, msg.Length);			// メッセージ				
                    ms.Read(dsp_hb, 0, dsp_hb.Length);		// 表示用部品				
                    ms.Read(mark, 0, mark.Length);			// マーク					

                    ms.Close();
                }
            }
        	# endregion
			# endregion

            # endregion

			# region Private Members
			//変数
            private UOESupplier _uOESupplier = null;

            private Int32 _detailMax = 0;

            private List<HRV_BUFF> hrv_list = null; 
			# endregion

			# region Constructors
			/// <summary>
			/// コンストラクタ
			/// </summary>
			public TelegramJnlOrder0501()
			{
				Clear();
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
			public void Clear()
			{
                _detailMax = 0;
                if(hrv_list == null)
                {
                    hrv_list = new List<HRV_BUFF>();
                }
                else
                {
                    hrv_list.Clear();
                }
			}
			# endregion

            # region バイト型配列に変換
            /// <summary>
            /// バイト型配列に変換
            /// </summary>
            /// <param name="list">展開元リスト</param>
            private void FromByteArray(List<UoeRecDtl> list)
            {
                //電文クラスの作成
                Clear();
                HRV_BUFF hrv_buff = null;
                int savUOESalesOrderNo = 0;

                foreach (UoeRecDtl dtl in list)
                {
                    // 初回時処理
                    if (hrv_buff == null)
                    {
                        hrv_buff = new HRV_BUFF();
                        savUOESalesOrderNo = dtl.UOESalesOrderNo;
                        hrv_buff._dataSendCode = dtl.DataSendCode;
                        hrv_buff._dataRecoverDiv = dtl.DataRecoverDiv;
                    }

                    // UOE発注番号のチェック
                    if (savUOESalesOrderNo != dtl.UOESalesOrderNo)
                    {
                        // リストへと保存
                        hrv_list.Add(hrv_buff);

                        // クリア処理
                        savUOESalesOrderNo = dtl.UOESalesOrderNo;
                        hrv_buff = new HRV_BUFF();
                    }

                    //受信データ格納処理
                    hrv_buff.Setting(dtl);
                }

                // 編集中の受信データ格納処理
                if (hrv_buff != null)
                {
                    hrv_list.Add(hrv_buff);
                }
            }
            # endregion

			# region データ編集処理
			/// <summary>
			/// データ編集処理
			/// </summary>
			/// <param name="dtl"></param>
			/// <param name="jnl"></param>
            public void Telegram(UoeRecHed uoeRecHed)
			{
                // UOE発注先の取得
                int uOESupplierCd = uoeRecHed.UOESupplierCd;
                _uOESupplier = _uoeSndRcvJnlAcs.SearchUOESupplier(uOESupplierCd);

                //-----------------------------------------------------------
                // 送受信エラーの設定処理
                //-----------------------------------------------------------
                # region 送受信エラーの設定処理
                foreach (UoeRecDtl dtl in uoeRecHed.UoeRecDtlList)
                {
                    foreach (int uOESalesOrderRowNo in dtl.UOESalesOrderRowNo)
                    {

                        DataRow dataRow = _uoeSndRcvJnlAcs.JnlOrderTblRead(
                                                        uOESupplierCd,
                                                        dtl.UOESalesOrderNo,
                                                        uOESalesOrderRowNo);

                        if (dataRow == null)
                        {
                            continue;
                        }

                        //データ送信区分
                        dataRow[OrderSndRcvJnlSchema.ct_Col_DataSendCode] = dtl.DataSendCode;

                        //データ復旧区分
                        dataRow[OrderSndRcvJnlSchema.ct_Col_DataRecoverDiv] = dtl.DataRecoverDiv;
                    }
                }
                # endregion

                //バイト型配列に変換
                FromByteArray(uoeRecHed.UoeRecDtlList);

                //電文変数処理
                foreach (HRV_BUFF hrv_buff in hrv_list)
                {
                    # region エラー制御部 更新
                    // エラー制御部 更新
                    // 識別フラグ 0:データ部更新 1,3:エラー制御部セット 2:ヘッダーエラーセット
                    if (hrv_buff.divHRV >= 1 && hrv_buff.divHRV <= 3)
                    {
                        ToDataRowFromHdt_5(hrv_buff, _uOESupplier.UOESupplierCd);
                        continue;
                    }
        			# endregion

                    # region ヘッダー・データ部 更新
                    // ヘッダー・データ部 更新
                    foreach(DT_H dt_h in hrv_buff.dt_h_List)
                    {
                        //取得＜送受信JNL-DATATABLE→送受信JNL-CLASS＞
                        int uOESalesOrderNo = hrv_buff._uOESalesOrderNo;
                        int uOESalesOrderRowNo = dt_h._uOESalesOrderRowNo;

                        DataRow dataRow = _uoeSndRcvJnlAcs.JnlOrderTblRead(
                                                        uOESupplierCd,
                                                        uOESalesOrderNo,
                                                        uOESalesOrderRowNo);
                        if (dataRow == null)
                        {
                            continue;
                        }

                        //データ送信区分
                        dataRow[OrderSndRcvJnlSchema.ct_Col_DataSendCode] = hrv_buff._dataSendCode;

                        //データ復旧区分
                        dataRow[OrderSndRcvJnlSchema.ct_Col_DataRecoverDiv] = hrv_buff._dataRecoverDiv;

                        //受信日付(YYYYMMDD)
                        dataRow[OrderSndRcvJnlSchema.ct_Col_ReceiveDate] = UoeCommonFnc.ToDateFromByte(hrv_buff.hhd_1.date);

                        //受信時刻(HHMM)
                        dataRow[OrderSndRcvJnlSchema.ct_Col_ReceiveTime] = UoeCommonFnc.ToTimeIntFromByte(hrv_buff.hhd_1.time);

                        // 識別フラグ 1:識別1 21:識別2-1 22:識別2-2 3:発注3
                        switch(dt_h.divHDT)
                        {
                            //識別1
                            case 1:
                                ToDataRowFromHdt_1(ref dataRow, hrv_buff.hhd_1, dt_h.hdt_1);
                                break;
                            //識別2-1
                            case 21:
                                ToDataRowFromHdt_21(ref dataRow, dt_h.hdt_21);
                                break;
                            //識別2-2
                            case 22:
                                ToDataRowFromHdt_22(ref dataRow, dt_h.hdt_22);
                                break;
                            //識別3
                            case 3:
                                ToDataRowFromHdt_3(ref dataRow, dt_h.hdt_3);
                                break;
                        }
                    }
        			# endregion
                }
            }
            # endregion

            # region データエラー更新
            /// <summary>
            /// データエラー更新
            /// </summary>
            /// <param name="hrv_buff">発注受信データ</param>
            /// <param name="uOESupplierCd">発注先コード</param>
            private void ToDataRowFromHdt_5(HRV_BUFF hrv_buff, int uOESupplierCd)
            {
                HHD_ERR hhd_err = hrv_buff.hhd_err;

                int uOESalesOrderNo = hrv_buff._uOESalesOrderNo;

                foreach (int uOESalesOrderRowNo in hrv_buff._uOESalesOrderRowNoList)
                {
                    //取得＜送受信JNL-DATATABLE→送受信JNL-CLASS＞
                    DataRow dataRow = _uoeSndRcvJnlAcs.JnlOrderTblRead(
                                                    uOESupplierCd,
                                                    uOESalesOrderNo,
                                                    uOESalesOrderRowNo);
                    if (dataRow == null)
                    {
                        continue;
                    }

                    //受信日付(YYYYMMDD)
                    dataRow[OrderSndRcvJnlSchema.ct_Col_ReceiveDate] = UoeCommonFnc.ToDateFromByte(hhd_err.date);

                    //受信時刻(HHMM)
                    dataRow[OrderSndRcvJnlSchema.ct_Col_ReceiveTime] = UoeCommonFnc.ToTimeIntFromByte(hhd_err.time);

                    // ヘッダーエラーセット
                    if (hhd_err.skb_flg[0] == '2')
                    {
                        string errMessage = UoeCommonFnc.ToStringFromByteStrAry(hhd_err.errmsg);

						//ヘッドエラーメッセージ
						dataRow[OrderSndRcvJnlSchema.ct_Col_HeadErrorMassage] = errMessage;

						//品名
						dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerPartsName] = errMessage;
                    }
                    // エラー制御部　セット
                    else if((hhd_err.skb_flg[0] == '1') || (hhd_err.skb_flg[0] == '3') )
                    {
                        string errMessage = UoeCommonFnc.ToStringFromByteStrAry(hhd_err.sei);

						//ヘッドエラーメッセージ
						dataRow[OrderSndRcvJnlSchema.ct_Col_HeadErrorMassage] = errMessage;

						//品名
						dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerPartsName] = errMessage;
                    }
                }
            }
            # endregion

            # region データ部更新(識別1)
            /// <summary>
            /// データ部更新(識別1)
            /// </summary>
            /// <param name="dataRow">データテーブル内データ</param>
            /// <param name="hrv_buff">発注受信データ</param>
            private void ToDataRowFromHdt_1(ref DataRow dataRow, HHD_1 hhd_1, HDT_1_R hdt_1)
            {
                string hb1 = UoeCommonFnc.ToStringFromByteStrAry(hdt_1.hb);
                string hb2 = UoeCommonFnc.ToStringFromByteStrAry(hdt_1.dsp_hb);

                // 代替品ﾁｪｯｸあり
                if(hb1.Trim() != hb2.Trim())
	            {
                    // 回答品番
                    dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerPartsNo] = hb2;

                    // 回答品名
                    dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerPartsName] = UoeCommonFnc.ToStringFromByteStrAry(hdt_1.nm);

                    // 代替品番
                    dataRow[OrderSndRcvJnlSchema.ct_Col_SubstPartsNo] = hb1;
                }
                // 代替品ﾁｪｯｸなし
                else									
                {
                    // 回答品番
                    dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerPartsNo] = hb1;

                    // 回答品名
                    dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerPartsName] = UoeCommonFnc.ToStringFromByteStrAry(hdt_1.nm);

                    // 代替品番
                    dataRow[OrderSndRcvJnlSchema.ct_Col_SubstPartsNo] = "";
                }
				
                // 適用定価
                dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerListPrice] = UoeCommonFnc.ToDoubleFromByteStrAry(hdt_1.k_kk);
				
                // 仕切単価
                dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerSalesUnitCost] = UoeCommonFnc.ToDoubleFromByteStrAry(hdt_1.h_kk);

                // マーク
                dataRow[OrderSndRcvJnlSchema.ct_Col_UOEMarkCode] = UoeCommonFnc.ToStringFromByteStrAry(hdt_1.mark);

                // 出荷元クリア
                dataRow[OrderSndRcvJnlSchema.ct_Col_SourceShipment] = "";

                // 指示数とﾎﾝﾀﾞ用拠点　比較
                string hondaSectionCode = _uOESupplier.HondaSectionCode.Trim(); // ホンダ担当拠点
                string hkySstring =  UoeCommonFnc.ToStringFromByteStrAry(hdt_1.hky);
                
                if(hondaSectionCode.Trim() == hkySstring.Trim())
                {
                    // 拠点出庫数　加算
                    int cnt = (int)dataRow[OrderSndRcvJnlSchema.ct_Col_UOESectOutGoodsCnt];
                    dataRow[OrderSndRcvJnlSchema.ct_Col_UOESectOutGoodsCnt] = UoeCommonFnc.atobs(hdt_1.sijisu, hdt_1.sijisu.Length) + cnt;
					
                    // 拠点伝票Ｎｏセット
                    dataRow[OrderSndRcvJnlSchema.ct_Col_UOESectionSlipNo] = UoeCommonFnc.ToStringFromByteStrAry(hhd_1.deno);
                }
                else
                {
                    // 出荷元（本部Ｆ用）
                    dataRow[OrderSndRcvJnlSchema.ct_Col_SourceShipment] = UoeCommonFnc.ToStringFromByteStrAry(hdt_1.hky);
					
                    // 本部Ｆ数　加算
                    int cnt = (int)dataRow[OrderSndRcvJnlSchema.ct_Col_BOShipmentCnt1];
                    dataRow[OrderSndRcvJnlSchema.ct_Col_BOShipmentCnt1] = UoeCommonFnc.atobs(hdt_1.sijisu, hdt_1.sijisu.Length) + cnt;
					
                    // 本部Ｆ伝票Ｎｏセット
                    dataRow[OrderSndRcvJnlSchema.ct_Col_BOSlipNo1] = UoeCommonFnc.ToStringFromByteStrAry(hhd_1.deno);
                }
            }
            # endregion

            # region データ部更新(識別21)
            /// <summary>
            /// データ部更新(識別21)
            /// </summary>
            /// <param name="dataRow">データテーブル内データ</param>
            /// <param name="hrv_buff">発注受信データ</param>
            private void ToDataRowFromHdt_21(ref DataRow dataRow, HDT_21_R hdt_21)
            {

                // 回答品番
                dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerPartsNo] = UoeCommonFnc.ToStringFromByteStrAry(hdt_21.dsp_hb);

                // 品名
                dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerPartsName] = UoeCommonFnc.ToStringFromByteStrAry(hdt_21.nm);

                // マーク
                dataRow[OrderSndRcvJnlSchema.ct_Col_UOEMarkCode] = UoeCommonFnc.ToStringFromByteStrAry(hdt_21.mark);

                // 代替無し
                if (hdt_21.daim[0] == '0' || hdt_21.daim[0] == ' ' || hdt_21.daim[0] == 0x00)
	            {
                    dataRow[OrderSndRcvJnlSchema.ct_Col_UOESubstMark] = "";
	            }
                // 代替有り
                else
                {
                    // 代替マーク
                    dataRow[OrderSndRcvJnlSchema.ct_Col_UOESubstMark] = UoeCommonFnc.ToStringFromByteStrAry(hdt_21.daim);
	            }

                // 卸
                dataRow[OrderSndRcvJnlSchema.ct_Col_UOEDistributionCd] = UoeCommonFnc.ToStringFromByteStrAry(hdt_21.orosi);

                // 他
                dataRow[OrderSndRcvJnlSchema.ct_Col_UOEOtherCd] = UoeCommonFnc.ToStringFromByteStrAry(hdt_21.ta);
				
                // ＨＭ
                dataRow[OrderSndRcvJnlSchema.ct_Col_UOEHMCd] = UoeCommonFnc.ToStringFromByteStrAry(hdt_21.hm);

				
                // 適用定価
                dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerListPrice] = UoeCommonFnc.ToDoubleFromByteStrAry(hdt_21.k_kk);
				
                // 仕切単価
                dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerSalesUnitCost] = UoeCommonFnc.ToDoubleFromByteStrAry(hdt_21.h_kk);
            }
            # endregion

            # region データ部更新(識別22)
            /// <summary>
            /// データ部更新(識別22)
            /// </summary>
            /// <param name="dataRow">データテーブル内データ</param>
            /// <param name="hrv_buff">発注受信データ</param>
            private void ToDataRowFromHdt_22(ref DataRow dataRow, HDT_22_R hdt_22)
            {
                // 回答品番
                dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerPartsNo] = UoeCommonFnc.ToStringFromByteStrAry(hdt_22.dsp_hb);

				// 品名
                dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerPartsName] = UoeCommonFnc.ToStringFromByteStrAry(hdt_22.nm);
                
                // マーク
				dataRow[OrderSndRcvJnlSchema.ct_Col_UOEMarkCode] = UoeCommonFnc.ToStringFromByteStrAry(hdt_22.mark);

                // メッセージ
                string errMessage = UoeCommonFnc.ToStringFromByteStrAry(hdt_22.msg);
                dataRow[OrderSndRcvJnlSchema.ct_Col_HeadErrorMassage] = errMessage;

                // ＢＯ数
	            dataRow[OrderSndRcvJnlSchema.ct_Col_BOCount] = UoeCommonFnc.atobs( hdt_22.bo, hdt_22.bo.Length );
            }
            # endregion

            # region データ部更新(識別3)
            /// <summary>
            /// データ部更新(識別3)
            /// </summary>
            /// <param name="dataRow">データテーブル内データ</param>
            /// <param name="hrv_buff">発注受信データ</param>
            private void ToDataRowFromHdt_3(ref DataRow dataRow, HDT_3_R hdt_3)
            {
                // 回答品番
                dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerPartsNo] = UoeCommonFnc.ToStringFromByteStrAry(hdt_3.dsp_hb);

				//ラインエラーメッセージ
                string errMessage = UoeCommonFnc.ToStringFromByteStrAry(hdt_3.msg);
                dataRow[OrderSndRcvJnlSchema.ct_Col_LineErrorMassage] = errMessage;

				//品名
				dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerPartsName] = errMessage;

                //マーク
                dataRow[OrderSndRcvJnlSchema.ct_Col_UOEMarkCode] = UoeCommonFnc.ToStringFromByteStrAry(hdt_3.mark);
            }
            # endregion

            # endregion

			# region private Methods



            # endregion
        }
		# endregion

		# endregion


	}
}

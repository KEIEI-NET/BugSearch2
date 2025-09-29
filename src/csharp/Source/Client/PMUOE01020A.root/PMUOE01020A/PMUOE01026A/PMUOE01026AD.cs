//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : ＵＯＥ受信編集＜在庫＞（ホンダ）アクセスクラス
// プログラム概要   : ＵＯＥ受信編集＜在庫＞（ホンダ）を行う
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
	/// ＵＯＥ受信編集＜在庫＞（ホンダ）アクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : ＵＯＥ受信編集＜在庫＞（ホンダ）アクセスクラス</br>
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

		# region ＵＯＥ受信編集＜在庫＞（ホンダ）
		/// <summary>
		/// ＵＯＥ受信編集＜在庫＞（ホンダ）
		/// </summary>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        private int GetJnlStock0501(out string message)
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
                    TelegramJnlStock0501 telegramJnlStock0501 = new TelegramJnlStock0501();
                    telegramJnlStock0501.Telegram(_uoeRecHed);
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

		# region ＵＯＥ受信電文作成＜在庫＞（ホンダ）
		/// <summary>
		/// ＵＯＥ受信電文作成＜在庫＞（ホンダ）
		/// </summary>
		public class TelegramJnlStock0501 : UoeRecEdit0501Acs
		{
			# region ＰＭ７ソース
            // /************************************************************/
            // /********            在庫  ヘッダー部                ********/
            // /************************************************************/
            // struct ZHD_1 {					/* 見積  第一電文  			*/
            // 	char	sei[8];				/* 制御部					*/
            // 	char	skb_flg[1];			/* 識別フラグ				*/
            // 	char	kak_era[10];		/* 拡張エリア				*/
            // 	char	date[8];			/* 日付						*/
            // 	char	time[8];			/* 時間						*/
            // 	char	msg[2];				/* 全体メッセージ			*/
            // 	char	seq[3];				/* ＳＥＱ					*/
            // 	char	ymdtime[6];			/* 年月日月時秒				*/
            // 	char	kei_flg[1];			/* 継続フラグ				*/
            // 	char	kensu[2];			/* 全体件数					*/
            // };
            // 
            // /************************************************************/
            // /********            在庫  データ部                  ********/
            // /************************************************************/
            // 
            // struct	ZZAI_R {				/* 在庫データ部（在庫）		*/
            // 	char	dai_cd[5];			/* 代理店コード				*/
            // 	char	su[3];				/* 数						*/
            // };
            // 
            // struct	ZDT_1_R {				/* 在庫データ部	（識別１）	*/
            // 	char	skb_flg[1];			/* 識別フラグ				*/
            // 	char	nm_hb[17];			/* 品名＆結合部番			*/
            // 	char	k_kk[7];			/* 希望価格					*/
            // 	char	h_kk[7];			/* 販売価格					*/
            // 	char	h_zai[2];			/* 本部在庫					*/
            // 	struct	ZZAI_R	zzai[5];	/* 在庫データ部（在庫）		*/
            // 	char	dsp_hb[15];			/* 表示用部品				*/
            // };
            // 
            // struct	ZDT_2_R {				/* 在庫データ部	（識別２）	*/
            // 	char	skb_flg[1];			/* 識別フラグ				*/
            // 	char	lmsg[17];			/* ラインメッセージ			*/
            // 	char	spc[56];			/* 空白						*/
            // 	char	dsp_hb[15];			/* 表示用部品				*/
            // };
			# endregion

			# region Const Members
            private const Int32 ctTelegramMax = 510;//最大電文長
            private const Int32 ctBufLen = 5;		//明細バッファサイズ
            private const Int32 ctDt_hLen = 89;     //データ部レコードサイズ
            # endregion

			# region Private Members
			//変数
			private Int32 _detailMax = 0;
            private List<ZRV_BUFF> zrv_list = null;
			# endregion

			# region 電文領域クラス
            # region 見積受信データ
            /// <summary>
            /// 見積受信データ
            /// </summary>
            private class ZRV_BUFF
            {
                //見積ヘッダー部
                public int _uOESalesOrderNo = 0;                    // UOE発注番号
                public List<int> _uOESalesOrderRowNoList = null;    //UOE発注番号行番号

                public int _dataSendCode = 0;                       // データ送信区分
                public int _dataRecoverDiv = 0;                     // データ復旧区分

                public int divZRV = 0;              // 識別フラグ 0:データ部更新 1,3:エラー制御部セット 2:ヘッダーエラーセット
                public ZHD_1 zhd_1 = null;          // 第一電文
                public ZHD_ERR zhd_err = null;      // 第一電文ヘッダーエラー

                // 在庫データ部
                public List<DT_Z> dt_z_List = null;

                public ZRV_BUFF()
                {
                    Clear();
                }

                public void Clear()
                {
                    _uOESalesOrderNo = 0;
                    _uOESalesOrderRowNoList = new List<int>();

                    divZRV = 0;
                    zhd_1 = null;
                    zhd_err = null;

                    if (dt_z_List == null)
                    {
                        dt_z_List = new List<DT_Z>();
                    }
                    else
                    {
                        dt_z_List.Clear();
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
                    divZRV = UoeCommonFnc.atobs(uoeRecDtl.RecTelegram, 8, 1);

                    // エラー制御部
                    if ((divZRV >= 1) && divZRV <= 3)
                    {
                        zhd_err = new ZHD_ERR();
                        zhd_err.Setting(uoeRecDtl.RecTelegram, 0);
                        return;
                    }
                    //第一電文ヘッダー格納処理
                    else
                    {
                        zhd_1 = new ZHD_1();
                        zhd_1.Setting(uoeRecDtl.RecTelegram, 0);
                    }
                    # endregion

                    # region データ部更新
                    // データ部　更新
                    if (divZRV == 0)
                    {
                        int start = 49;                                 //第一電文位置の設定
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
                                DT_Z dt_z = new DT_Z();
                                dt_z.Setting(uoeRecDtl.RecTelegram, idx);
                                dt_z_List.Add(dt_z);
                            }
                            start = 8;                    // 第二電文位置の設定
                        }
                    }
                    # endregion
                }
            }
            # endregion

            # region 在庫ヘッダー部
            /// <summary>
            /// 在庫ヘッダー部
            /// </summary>
            public class ZHD_1
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
                public byte[] kensu = new byte[2];			// 全体件数					

                public ZHD_1()
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
	                UoeCommonFnc.MemSet(ref kensu, cd, kensu.Length);		// 全体件数					
				}

                public void Setting(byte[] line, int start)
                {
                    MemoryStream ms = new MemoryStream();
                    ms.Write(line, 0, line.Length);
                    ms.Seek(start, SeekOrigin.Begin);

                    // 見積  第一電文  		
                    ms.Read(sei, 0, sei.Length);			// 制御部					
                    ms.Read(skb_flg, 0, skb_flg.Length);	// 識別フラグ				
                    ms.Read(kak_era, 0, kak_era.Length);	// 拡張エリア				
                    ms.Read(date, 0, date.Length);			// 日付						
                    ms.Read(time, 0, time.Length);			// 時間						
                    ms.Read(msg, 0, msg.Length);			// 全体メッセージ			
                    ms.Read(seq, 0, seq.Length);			// ＳＥＱ					
                    ms.Read(ymdtime, 0, ymdtime.Length);	// 年月日月時秒				
                    ms.Read(kei_flg, 0, kei_flg.Length);	// 継続フラグ				
                    ms.Read(kensu, 0, kensu.Length);		// 全体件数					

                    ms.Close();
                }
            }
            # endregion

            # region 電文ヘッダーエラー
            /// <summary>
            /// 電文ヘッダーエラー
            /// </summary>
            public class ZHD_ERR
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

                public ZHD_ERR()
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
            # region 在庫データ部メイン
            /// <summary>
            /// 在庫データ部メイン
            /// </summary>
            public class DT_Z
            {
                public int divZDT = 0;              // 識別フラグ 1:識別1 21:識別2-1 22:識別2-2 3:発注3
                public int _uOESalesOrderRowNo = 0; // UOE発注行番号

                public ZDT_1_R zdt_1 = null;        //在庫データ部（識別１）
                public ZDT_2_R zdt_2 = null;        //在庫データ部（識別２）

                public DT_Z()
                {
                    Clear();
                }

                public void Clear()
                {
                    divZDT = 0;
                    _uOESalesOrderRowNo = 0;
                    zdt_1 = null;
                    zdt_2 = null;
                }

                public void Setting(byte[] line, int start)
                {
                    try
                    {
                        if (line == null) return;

                        Clear();

                        //識別 1 or 2 判定
                        divZDT = UoeCommonFnc.atobs(line, start, 1);

                        switch (divZDT)
                        {
                            case 1:
                                zdt_1 = new ZDT_1_R();
                                zdt_1.Setting(line, start);
                                break;
                            default:
                                zdt_2 = new ZDT_2_R();
                                zdt_2.Setting(line, start);
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

			# region 在庫データ部（在庫）
            /// <summary>
            /// 在庫データ部（在庫）
            /// </summary>
            public class ZZAI_R
            {
                public byte[] dai_cd = new byte[5];			// 代理店コード				
                public byte[] su = new byte[3];				// 数						

                public ZZAI_R()
				{
					Clear(0x00);
				}
				
				public void Clear(byte cd)
				{
	                UoeCommonFnc.MemSet(ref dai_cd, cd, dai_cd.Length);		// 代理店コード				
	                UoeCommonFnc.MemSet(ref su, cd, su.Length);				// 数						
				}
            }
            # endregion

			# region 在庫データ部（識別１）
            /// <summary>
            /// 在庫データ部（識別１）
            /// </summary>
            public class ZDT_1_R
            {
	            public byte[] skb_flg = new byte[1];		// 識別フラグ				
	            public byte[] nm_hb = new byte[17];			// 品名＆結合部番			
	            public byte[] k_kk = new byte[7];			// 希望価格					
	            public byte[] h_kk = new byte[7];			// 販売価格					
	            public byte[] h_zai = new byte[2];			// 本部在庫					
                public ZZAI_R[] zzai = new ZZAI_R[5];		// 在庫データ部（在庫）		
	            public byte[] dsp_hb = new byte[15];		// 表示用部品				

                public ZDT_1_R()
				{
					Clear(0x00);
				}
				
				public void Clear(byte cd)
				{
	                UoeCommonFnc.MemSet(ref skb_flg, cd, skb_flg.Length);	// 識別フラグ				
	                UoeCommonFnc.MemSet(ref nm_hb, cd, nm_hb.Length);		// 品名＆結合部番			
	                UoeCommonFnc.MemSet(ref k_kk, cd, k_kk.Length);			// 希望価格					
	                UoeCommonFnc.MemSet(ref h_kk, cd, h_kk.Length);			// 販売価格					
	                UoeCommonFnc.MemSet(ref h_zai, cd, h_zai.Length);		// 本部在庫					

                    // 在庫データ部（在庫）		
					for(int i=0;i<zzai.Length; i++)
					{
                        if (zzai[i] == null)
                        {
                            zzai[i] = new ZZAI_R();
                        }
                        else
                        {
                            zzai[i].Clear(0x00);
                        }
					}

	                UoeCommonFnc.MemSet(ref dsp_hb, cd, dsp_hb.Length);		// 表示用部品				
				}

                public void Setting(byte[] line, int start)
                {
                    MemoryStream ms = new MemoryStream();
                    ms.Write(line, 0, line.Length);
                    ms.Seek(start, SeekOrigin.Begin);

                    ms.Read(skb_flg, 0, skb_flg.Length);	// 識別フラグ				
                    ms.Read(nm_hb, 0, nm_hb.Length);		// 品名＆結合部番			
                    ms.Read(k_kk, 0, k_kk.Length);			// 希望価格					
                    ms.Read(h_kk, 0, h_kk.Length);			// 販売価格					
                    ms.Read(h_zai, 0, h_zai.Length);		// 本部在庫					

                    // 在庫データ部（在庫）
                    for (int j = 0; j < zzai.Length; j++)
                    {
                        ms.Read(zzai[j].dai_cd, 0, zzai[j].dai_cd.Length);		// 代理店コード				
                        ms.Read(zzai[j].su, 0, zzai[j].su.Length);				// 数						
                    }

                    ms.Read(dsp_hb, 0, dsp_hb.Length);		// 表示用部品				

                    ms.Close();
                }
            }
            # endregion

			# region 在庫データ部（識別２）
            /// <summary>
            /// 在庫データ部（識別２）
            /// </summary>
            public class ZDT_2_R
            {
                public byte[] skb_flg = new byte[1];		// 識別フラグ				
                public byte[] lmsg = new byte[17];			// ラインメッセージ			
                public byte[] spc = new byte[56];			// 空白						
                public byte[] dsp_hb = new byte[15];		// 表示用部品				

                public ZDT_2_R()
				{
					Clear(0x00);
				}
				
				public void Clear(byte cd)
				{
	                UoeCommonFnc.MemSet(ref skb_flg, cd, skb_flg.Length);	// 識別フラグ				
	                UoeCommonFnc.MemSet(ref lmsg, cd, lmsg.Length);			// ラインメッセージ			
	                UoeCommonFnc.MemSet(ref spc, cd, spc.Length);			// 空白						
	                UoeCommonFnc.MemSet(ref dsp_hb, cd, dsp_hb.Length);		// 表示用部品				
				}

                public void Setting(byte[] line, int start)
                {
                    MemoryStream ms = new MemoryStream();
                    ms.Write(line, 0, line.Length);
                    ms.Seek(start, SeekOrigin.Begin);

                    ms.Read(skb_flg, 0, skb_flg.Length);	// 識別フラグ				
                    ms.Read(lmsg, 0, lmsg.Length);			// ラインメッセージ			
                    ms.Read(spc, 0, spc.Length);			// 空白						
                    ms.Read(dsp_hb, 0, dsp_hb.Length);		// 表示用部品				

                    ms.Close();
                }
            }
            # endregion
			# endregion
			# endregion

			# region Constructors
			/// <summary>
			/// コンストラクタ
			/// </summary>
			public TelegramJnlStock0501()
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
                if (zrv_list == null)
                {
                    zrv_list = new List<ZRV_BUFF>();
                }
                else
                {
                    zrv_list.Clear();
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
                ZRV_BUFF zrv_buff = null;
                int savUOESalesOrderNo = 0;

                foreach (UoeRecDtl dtl in list)
                {
                    // 初回時処理
                    if (zrv_buff == null)
                    {
                        zrv_buff = new ZRV_BUFF();
                        savUOESalesOrderNo = dtl.UOESalesOrderNo;
                        zrv_buff._dataSendCode = dtl.DataSendCode;
                        zrv_buff._dataRecoverDiv = dtl.DataRecoverDiv;
                    }

                    // UOE発注番号のチェック
                    if (savUOESalesOrderNo != dtl.UOESalesOrderNo)
                    {
                        // リストへと保存
                        zrv_list.Add(zrv_buff);

                        // クリア処理
                        savUOESalesOrderNo = dtl.UOESalesOrderNo;
                        zrv_buff = new ZRV_BUFF();
                    }

                    //受信データ格納処理
                    zrv_buff.Setting(dtl);
                }

                // 編集中の受信データ格納処理
                if (zrv_buff != null)
                {
                    zrv_list.Add(zrv_buff);
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
                int uOESupplierCd = uoeRecHed.UOESupplierCd;                 // UOE発注先コード

                //バイト型配列に変換
                FromByteArray(uoeRecHed.UoeRecDtlList);

                //電文変数処理
                foreach (ZRV_BUFF zrv_buff in zrv_list)
                {
                    # region エラー制御部 更新
                    // エラー制御部 更新
                    // 識別フラグ 0:データ部更新 1,3:エラー制御部セット 2:ヘッダーエラーセット
                    if (zrv_buff.divZRV >= 1 && zrv_buff.divZRV <= 3)
                    {
                        ToDataRowFromZdt_err(zrv_buff, uOESupplierCd);
                        continue;
                    }
                    # endregion

                    # region ヘッダー・データ部 更新
                    // ヘッダー・データ部 更新
                    int uOESalesOrderRowNo = 0;
                    foreach (DT_Z dt_z in zrv_buff.dt_z_List)
                    {
                        //取得＜送受信JNL-DATATABLE→送受信JNL-CLASS＞
                        int uOESalesOrderNo = zrv_buff._uOESalesOrderNo;
                        uOESalesOrderRowNo++;

                        DataRow dataRow = _uoeSndRcvJnlAcs.JnlStockTblRead(
                                                        uOESupplierCd,
                                                        uOESalesOrderNo,
                                                        uOESalesOrderRowNo);
                        if (dataRow == null)
                        {
                            continue;
                        }

                        //データ送信区分
                        dataRow[StockSndRcvJnlSchema.ct_Col_DataSendCode] = zrv_buff._dataRecoverDiv;

                        //データ復旧区分
                        dataRow[StockSndRcvJnlSchema.ct_Col_DataRecoverDiv] = zrv_buff._dataRecoverDiv;

                        //受信日付(YYYYMMDD)
                        dataRow[StockSndRcvJnlSchema.ct_Col_ReceiveDate] = UoeCommonFnc.ToDateFromByte(zrv_buff.zhd_1.date);

                        //受信時刻(HHMM)
                        dataRow[StockSndRcvJnlSchema.ct_Col_ReceiveTime] = UoeCommonFnc.ToTimeIntFromByte(zrv_buff.zhd_1.time);

                        // 識別フラグ 1:識別1 2:識別2
                        switch (dt_z.divZDT)
                        {
                            //識別1
                            case 1:
                                ToDataRowFromZdt_1(ref dataRow, dt_z.zdt_1);
                                break;
                            //識別2
                            default:
                                ToDataRowFromZdt_2(ref dataRow, dt_z.zdt_2);
                                break;
                        }
                    }
                    # endregion
                }
			}
			# endregion

			# endregion

			# region private Methods
            # region データエラー更新
            /// <summary>
            /// データエラー更新
            /// </summary>
            /// <param name="zrv_buff">発注受信データ</param>
            /// <param name="uOESupplierCd">発注先コード</param>
            private void ToDataRowFromZdt_err(ZRV_BUFF zrv_buff, int uOESupplierCd)
            {
                ZHD_ERR zhd_err = zrv_buff.zhd_err;

                int uOESalesOrderNo = zrv_buff._uOESalesOrderNo;

                foreach (int uOESalesOrderRowNo in zrv_buff._uOESalesOrderRowNoList)
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
                    dataRow[StockSndRcvJnlSchema.ct_Col_ReceiveDate] = UoeCommonFnc.ToDateFromByte(zhd_err.date);

                    //受信時刻(HHMM)
                    dataRow[StockSndRcvJnlSchema.ct_Col_ReceiveTime] = UoeCommonFnc.ToTimeIntFromByte(zhd_err.time);

                    // エラー制御部　セット
                    string errMessage = UoeCommonFnc.ToStringFromByteStrAry(zhd_err.sei);

                    //ヘッドエラーメッセージ
                    dataRow[StockSndRcvJnlSchema.ct_Col_HeadErrorMassage] = errMessage;
                }
            }
            # endregion

            # region データ部更新(識別1)
            /// <summary>
            /// データ部更新(識別1)
            /// </summary>
            /// <param name="dataRow">データテーブル内データ</param>
            /// <param name="zdt_1">在庫受信データ</param>
            private void ToDataRowFromZdt_1(ref DataRow dataRow, ZDT_1_R zdt_1)
            {
			
                // 品番
                dataRow[StockSndRcvJnlSchema.ct_Col_AnswerPartsNo] = UoeCommonFnc.ToStringFromByteStrAry(zdt_1.dsp_hb);
				
                // 品名
                dataRow[StockSndRcvJnlSchema.ct_Col_AnswerPartsName] = UoeCommonFnc.ToStringFromByteStrAry(zdt_1.nm_hb);
				
                // 適用(L/P)
                dataRow[StockSndRcvJnlSchema.ct_Col_AnswerListPrice] = UoeCommonFnc.ToDoubleFromByteStrAry(zdt_1.k_kk);
           
				// 販売店仕入単価
                double shopStUnitPrice = UoeCommonFnc.ToDoubleFromByteStrAry(zdt_1.h_kk);
                dataRow[StockSndRcvJnlSchema.ct_Col_ShopStUnitPrice] = shopStUnitPrice;
                dataRow[StockSndRcvJnlSchema.ct_Col_AnswerSalesUnitCost] = shopStUnitPrice;

                // （本部在庫）在庫数００
                string headQtrsStock = UoeCommonFnc.ToStringFromByteStrAry(zdt_1.h_zai);
                dataRow[StockSndRcvJnlSchema.ct_Col_HeadQtrsStock] = headQtrsStock;

                // UOE拠点コード１
                dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionCode1] = UoeCommonFnc.ToStringFromByteStrAry(zdt_1.zzai[0].dai_cd);
				
                // UOE拠点在庫数１
                dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock1] = UoeCommonFnc.atobs(zdt_1.zzai[0].su, zdt_1.zzai[0].su.Length); 
				
                // UOE拠点コード２
                dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionCode2] = UoeCommonFnc.ToStringFromByteStrAry(zdt_1.zzai[1].dai_cd);
				
                // UOE拠点在庫数２
                dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock2] = UoeCommonFnc.atobs(zdt_1.zzai[1].su, zdt_1.zzai[0].su.Length); 
				
                // UOE拠点コード３
                dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionCode3] = UoeCommonFnc.ToStringFromByteStrAry(zdt_1.zzai[2].dai_cd);
				
                // UOE拠点在庫数３
                dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock3] = UoeCommonFnc.atobs(zdt_1.zzai[2].su, zdt_1.zzai[0].su.Length); 
				
                // UOE拠点コード４
                dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionCode4] = UoeCommonFnc.ToStringFromByteStrAry(zdt_1.zzai[3].dai_cd);
				
                // UOE拠点在庫数４
                dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock4] = UoeCommonFnc.atobs(zdt_1.zzai[3].su, zdt_1.zzai[0].su.Length); 
				
                // UOE拠点コード５
                dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionCode5] = UoeCommonFnc.ToStringFromByteStrAry(zdt_1.zzai[4].dai_cd);
				
                // UOE拠点在庫数５
                dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock5] = UoeCommonFnc.atobs(zdt_1.zzai[4].su, zdt_1.zzai[0].su.Length); 
            }
			# endregion

            # region データ部更新(識別2)
            /// <summary>
            /// データ部更新(識別2)
            /// </summary>
            /// <param name="dataRow">データテーブル内データ</param>
            /// <param name="zdt_1">在庫受信データ</param>
            private void ToDataRowFromZdt_2(ref DataRow dataRow, ZDT_2_R zdt_2)
            {
                //品番
                dataRow[StockSndRcvJnlSchema.ct_Col_AnswerPartsNo] = UoeCommonFnc.ToStringFromByteStrAry(zdt_2.dsp_hb);

                //品名
                dataRow[StockSndRcvJnlSchema.ct_Col_AnswerPartsName] = UoeCommonFnc.ToStringFromByteStrAry(zdt_2.lmsg);
                dataRow[StockSndRcvJnlSchema.ct_Col_HeadErrorMassage] = UoeCommonFnc.ToStringFromByteStrAry(zdt_2.lmsg);
                dataRow[StockSndRcvJnlSchema.ct_Col_LineErrorMassage] = UoeCommonFnc.ToStringFromByteStrAry(zdt_2.lmsg);
            }
			# endregion

			# endregion
		}
		# endregion

		# endregion


	}
}

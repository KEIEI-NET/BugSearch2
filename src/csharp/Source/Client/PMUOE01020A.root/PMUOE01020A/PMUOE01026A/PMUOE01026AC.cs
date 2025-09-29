//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : ＵＯＥ受信編集＜見積＞（ホンダ）アクセスクラス
// プログラム概要   : ＵＯＥ受信編集＜見積＞（ホンダ）を行う
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
	/// ＵＯＥ受信編集＜見積＞（ホンダ）アクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : ＵＯＥ受信編集＜見積＞（ホンダ）アクセスクラス</br>
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

		# region ＵＯＥ受信編集＜見積＞（ホンダ）
		/// <summary>
		/// ＵＯＥ受信編集＜見積＞（ホンダ）
		/// </summary>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        private int GetJnlEstmt0501(out string message)
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
                    TelegramJnlEstmt0501 telegramJnlEstmt0501 = new TelegramJnlEstmt0501();
                    telegramJnlEstmt0501.Telegram(_uoeRecHed);
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

		# region ＵＯＥ受信電文作成＜見積＞（ホンダ）
		/// <summary>
		/// ＵＯＥ受信電文作成＜見積＞（ホンダ）
		/// </summary>
		public class TelegramJnlEstmt0501 : UoeRecEdit0501Acs
		{
			# region ＰＭ７ソース
            // /************************************************************/
            // /********            見積  全体ヘッダー部            ********/
            // /************************************************************/
            // struct MHD_1 {					/* 見積  第一電文  			*/
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
            // /********            見積  データ部                  ********/
            // /************************************************************/
            // struct	MDT_R {					/* 見積データ部				*/
            // 	char	nm[17];				/* 品名						*/
            // 	char	k_kk[7];			/* 希望価格					*/
            // 	char	h_kk[7];			/* 販売価格					*/
            // 	char	zaim[1];			/* 在庫有Ｍ					*/
            // 	char	or_zai[2];			/* 卸店在庫Ｍ				*/
            // 	char	nkim[1];			/* 納期Ｍ					*/
            // 	char	daim[1];			/* 代替Ｍ					*/
            // 	char	dsp_hb[15];			/* 表示用部品				*/
            // 	char	lmsg[9];			/* コメント（ﾗｲﾝﾒｯｾｰｼﾞ）	*/
            // };
            # endregion

			# region Const Members
            private const Int32 ctTelegramMax = 510;//最大電文長
			private const Int32 ctBufLen = 7;		//明細バッファサイズ
            private const Int32 ctDt_hLen = 60;     //データ部レコードサイズ
            # endregion

			# region Private Members
			//変数
			private Int32 _detailMax = 0;
            private List<MRV_BUFF> mrv_list = null;
            # endregion

			# region 電文領域クラス
            # region 見積受信データ
            /// <summary>
            /// 見積受信データ
            /// </summary>
            private class MRV_BUFF
            {
                //見積ヘッダー部
                public int _uOESalesOrderNo = 0;                    // UOE発注番号
                public List<int> _uOESalesOrderRowNoList = null;    //UOE発注番号行番号

                public int _dataSendCode = 0;                       // データ送信区分
                public int _dataRecoverDiv = 0;                     // データ復旧区分

                public int divHRV = 0;              // 識別フラグ 0:データ部更新 1,3:エラー制御部セット 2:ヘッダーエラーセット
                public MHD_1 mhd_1 = null;          // 第一電文
                public MHD_ERR mhd_err = null;      // 第一電文ヘッダーエラー


                // 発注データ部
                public List<MDT_R> mdt_List = null;

                public MRV_BUFF()
                {
                    Clear();
                }

                public void Clear()
                {
                    _uOESalesOrderNo = 0;
                    _uOESalesOrderRowNoList = new List<int>();

                    divHRV = 0;
                    mhd_1 = null;
                    mhd_err = null;

                    if (mdt_List == null)
                    {
                        mdt_List = new List<MDT_R>();
                    }
                    else
                    {
                        mdt_List.Clear();
                    }
                }

                public void Setting(UoeRecDtl uoeRecDtl)
                {
                    # region ヘッダー部更新
                    //第１電文 ヘッダー部更新
                    //UOE発注番号 UOE発注行番号の保存
                    _uOESalesOrderNo = uoeRecDtl.UOESalesOrderNo;
                    _uOESalesOrderRowNoList = new List<int>();
                    _uOESalesOrderRowNoList.AddRange(uoeRecDtl.UOESalesOrderRowNo);

                    //識別フラグ
                    divHRV = UoeCommonFnc.atobs(uoeRecDtl.RecTelegram, 8, 1);

                    // エラー制御部
                    if ((divHRV >= 1) && divHRV <= 3)
                    {
                        mhd_err = new MHD_ERR();
                        mhd_err.Setting(uoeRecDtl.RecTelegram, 0);
                        return;

                    }
                    //第一電文ヘッダー格納処理
                    else
                    {
                        mhd_1 = new MHD_1();
                        mhd_1.Setting(uoeRecDtl.RecTelegram, 0);
                    }
                    # endregion

                    # region データ部更新
                    // データ部　更新
                    if (divHRV == 0)
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
                                MDT_R mdt = new MDT_R();
                                mdt.Setting(uoeRecDtl.RecTelegram, idx);
                                mdt_List.Add(mdt);
                            }
                            start = 8;                    // 第二電文位置の設定
                        }
                    }
                    # endregion
                }
            }
            # endregion

			# region 見積  第一電文
            /// <summary>
            /// 見積  第一電文
            /// </summary>
            private class MHD_1
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

                public MHD_1()
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
            private class MHD_ERR
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

                public MHD_ERR()
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

            # region 見積データ部
            /// <summary>
            /// 見積データ部
            /// </summary>
            private class MDT_R
            {
                public byte[] nm = new byte[17];			// 品名						
                public byte[] k_kk = new byte[7];			// 希望価格					
                public byte[] h_kk = new byte[7];			// 販売価格					
                public byte[] zaim = new byte[1];			// 在庫有Ｍ					
                public byte[] or_zai = new byte[2];			// 卸店在庫Ｍ				
                public byte[] nkim = new byte[1];			// 納期Ｍ					
                public byte[] daim = new byte[1];			// 代替Ｍ					
                public byte[] dsp_hb = new byte[15];		// 表示用部品				
                public byte[] lmsg = new byte[9];			// コメント（ﾗｲﾝﾒｯｾｰｼﾞ）	

                public MDT_R()
				{
					Clear(0x00);
				}
				
				public void Clear(byte cd)
				{
                    UoeCommonFnc.MemSet(ref nm, cd, nm.Length);				// 品名						
                    UoeCommonFnc.MemSet(ref k_kk, cd, k_kk.Length);			// 希望価格					
                    UoeCommonFnc.MemSet(ref h_kk, cd, h_kk.Length);			// 販売価格					
                    UoeCommonFnc.MemSet(ref zaim, cd, zaim.Length);			// 在庫有Ｍ					
                    UoeCommonFnc.MemSet(ref or_zai, cd, or_zai.Length);		// 卸店在庫Ｍ				
                    UoeCommonFnc.MemSet(ref nkim, cd, nkim.Length);			// 納期Ｍ					
                    UoeCommonFnc.MemSet(ref daim, cd, daim.Length);			// 代替Ｍ					
                    UoeCommonFnc.MemSet(ref dsp_hb, cd, dsp_hb.Length);		// 表示用部品				
                    UoeCommonFnc.MemSet(ref lmsg, cd, lmsg.Length);			// コメント（ﾗｲﾝﾒｯｾｰｼﾞ）	
                }

                public void Setting(byte[] line, int start)
                {
                    MemoryStream ms = new MemoryStream();
                    ms.Write(line, 0, line.Length);
                    ms.Seek(start, SeekOrigin.Begin);

                    // 見積データ部
                    ms.Read(nm, 0, nm.Length);					// 品名						
                    ms.Read(k_kk, 0, k_kk.Length);				// 希望価格					
                    ms.Read(h_kk, 0, h_kk.Length);				// 販売価格					
                    ms.Read(zaim, 0, zaim.Length);				// 在庫有Ｍ					
                    ms.Read(or_zai, 0, or_zai.Length);			// 卸店在庫Ｍ				
                    ms.Read(nkim, 0, nkim.Length);				// 納期Ｍ					
                    ms.Read(daim, 0, daim.Length);				// 代替Ｍ					
                    ms.Read(dsp_hb, 0, dsp_hb.Length);			// 表示用部品				
                    ms.Read(lmsg, 0, lmsg.Length);				// 

                    ms.Close();
                }

            }
            # endregion
			# endregion

			# region Constructors
			/// <summary>
			/// コンストラクタ
			/// </summary>
			public TelegramJnlEstmt0501()
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
                if (mrv_list == null)
                {
                    mrv_list = new List<MRV_BUFF>();
                }
                else
                {
                    mrv_list.Clear();
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
                MRV_BUFF mrv_buff = null;
                int savUOESalesOrderNo = 0;

                foreach (UoeRecDtl dtl in list)
                {
                    // 初回時処理
                    if (mrv_buff == null)
                    {
                        mrv_buff = new MRV_BUFF();
                        savUOESalesOrderNo = dtl.UOESalesOrderNo;
                        mrv_buff._dataSendCode = dtl.DataSendCode;
                        mrv_buff._dataRecoverDiv = dtl.DataRecoverDiv;
                    }

                    // UOE発注番号のチェック
                    if (savUOESalesOrderNo != dtl.UOESalesOrderNo)
                    {
                        // リストへと保存
                        mrv_list.Add(mrv_buff);

                        // クリア処理
                        savUOESalesOrderNo = dtl.UOESalesOrderNo;
                        mrv_buff = new MRV_BUFF();
                    }

                    //受信データ格納処理
                    mrv_buff.Setting(dtl);
                }

                // 編集中の受信データ格納処理
                if (mrv_buff != null)
                {
                    mrv_list.Add(mrv_buff);
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
                int uOESupplierCd = uoeRecHed.UOESupplierCd;

                //バイト型配列に変換
                FromByteArray(uoeRecHed.UoeRecDtlList);

                //電文変数処理
                foreach (MRV_BUFF mrv_buff in mrv_list)
                {
                    # region エラー制御部 更新
                    // エラー制御部 更新
                    // 識別フラグ 0:データ部更新 1,3:エラー制御部セット 2:ヘッダーエラーセット
                    if (mrv_buff.divHRV >= 1 && mrv_buff.divHRV <= 3)
                    {
                        ToDataRowFromHdt_err(mrv_buff, uOESupplierCd);
                        continue;
                    }
                    # endregion

                    # region ヘッダー・データ部 更新
                    // ヘッダー・データ部 更新
                    int uOESalesOrderRowNo = 0;
                    foreach (MDT_R mdt in mrv_buff.mdt_List)
                    {
                        //取得＜送受信JNL-DATATABLE→送受信JNL-CLASS＞
                        int uOESalesOrderNo = mrv_buff._uOESalesOrderNo;
                        uOESalesOrderRowNo++;

                        DataRow dataRow = _uoeSndRcvJnlAcs.JnlEstmtTblRead(
                                                        uOESupplierCd,
                                                        uOESalesOrderNo,
                                                        uOESalesOrderRowNo);
                        if (dataRow == null)
                        {
                            continue;
                        }

                        //データ送信区分
                        dataRow[EstmtSndRcvJnlSchema.ct_Col_DataSendCode] = mrv_buff._dataRecoverDiv;

                        //データ復旧区分
                        dataRow[EstmtSndRcvJnlSchema.ct_Col_DataRecoverDiv] = mrv_buff._dataRecoverDiv;

                        //受信日付(YYYYMMDD)
                        dataRow[EstmtSndRcvJnlSchema.ct_Col_ReceiveDate] = UoeCommonFnc.ToDateFromByte(mrv_buff.mhd_1.date);

                        //受信時刻(HHMM)
                        dataRow[EstmtSndRcvJnlSchema.ct_Col_ReceiveTime] = UoeCommonFnc.ToTimeIntFromByte(mrv_buff.mhd_1.time);

                        // 品番
                        dataRow[EstmtSndRcvJnlSchema.ct_Col_AnswerPartsNo] = UoeCommonFnc.ToStringFromByteStrAry(mdt.dsp_hb);
	                    
                        // 品名
                        dataRow[EstmtSndRcvJnlSchema.ct_Col_AnswerPartsName] = UoeCommonFnc.ToStringFromByteStrAry(mdt.nm);
						
                        // 適用価格
                        dataRow[EstmtSndRcvJnlSchema.ct_Col_AnswerListPrice] = UoeCommonFnc.ToDoubleFromByteStrAry(mdt.k_kk);
						
                        // 仕切単価
                        dataRow[EstmtSndRcvJnlSchema.ct_Col_SalesUnPrcTaxExcFl] = UoeCommonFnc.ToDoubleFromByteStrAry(mdt.h_kk);
                        dataRow[EstmtSndRcvJnlSchema.ct_Col_AnswerSalesUnitCost] = UoeCommonFnc.ToDoubleFromByteStrAry(mdt.h_kk);

                        // 予備拠点在庫数
                        int branchStock = UoeCommonFnc.ToInt32FromByteStrAry(mdt.or_zai);
                        dataRow[EstmtSndRcvJnlSchema.ct_Col_BranchStock] = branchStock.ToString();

                        // 納期ﾏｰｸ
                        dataRow[EstmtSndRcvJnlSchema.ct_Col_UOEDelivDateCd] = UoeCommonFnc.ToStringFromByteStrAry(mdt.nkim);
						
                        // 在庫ﾏｰｸ
                        dataRow[EstmtSndRcvJnlSchema.ct_Col_HeadQtrsStock] = UoeCommonFnc.ToStringFromByteStrAry(mdt.zaim);

                        // 互換ｺｰﾄﾞ
                        dataRow[EstmtSndRcvJnlSchema.ct_Col_UOESubstCode] = UoeCommonFnc.ToStringFromByteStrAry(mdt.daim);
						
                        // ｴﾗｰﾒｯｾｰｼﾞ
                        dataRow[EstmtSndRcvJnlSchema.ct_Col_LineErrorMassage] = UoeCommonFnc.ToStringFromByteStrAry(mdt.lmsg);
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
            /// <param name="mrv_buff">発注受信データ</param>
            /// <param name="uOESupplierCd">発注先コード</param>
            private void ToDataRowFromHdt_err(MRV_BUFF mrv_buff, int uOESupplierCd)
            {
                MHD_ERR mhd_err = mrv_buff.mhd_err;

                int uOESalesOrderNo = mrv_buff._uOESalesOrderNo;

                foreach (int uOESalesOrderRowNo in mrv_buff._uOESalesOrderRowNoList)
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
                    dataRow[EstmtSndRcvJnlSchema.ct_Col_ReceiveDate] = UoeCommonFnc.ToDateFromByte(mhd_err.date);

                    //受信時刻(HHMM)
                    dataRow[EstmtSndRcvJnlSchema.ct_Col_ReceiveTime] = UoeCommonFnc.ToTimeIntFromByte(mhd_err.time);

                    // エラー制御部　セット
                    string errMessage = UoeCommonFnc.ToStringFromByteStrAry(mhd_err.sei);

                    //ヘッドエラーメッセージ
                    dataRow[EstmtSndRcvJnlSchema.ct_Col_HeadErrorMassage] = errMessage;
                }
            }
            # endregion

			# endregion
		}
		# endregion

		# endregion
	}
}

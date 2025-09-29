//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : ＵＯＥ受信編集＜見積＞（日産Ｎパーツ）アクセスクラス
// プログラム概要   : ＵＯＥ受信編集＜見積＞（日産Ｎパーツ）を行う
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
	/// ＵＯＥ受信編集＜見積＞（日産Ｎパーツ）アクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : ＵＯＥ受信編集＜見積＞（日産Ｎパーツ）アクセスクラス</br>
	/// <br>Programmer : 96186 立花裕輔</br>
	/// <br>Date       : 2008.05.26</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// <br>2008.05.26 men 新規作成</br>
	/// </remarks>
	public partial class UoeRecEdit0202Acs
	{
		// ===================================================================================== //
		// プライベートメソッド
		// ===================================================================================== //
		# region Private Methods

		# region ＵＯＥ受信編集＜見積＞（日産Ｎパーツ）
		/// <summary>
		/// ＵＯＥ受信編集＜見積＞（日産Ｎパーツ）
		/// </summary>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        private int GetJnlEstmt0202(out string message)
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
                    TelegramJnlEstmt0202 telegramJnlEstmt0202 = new TelegramJnlEstmt0202();

                    //ＪＮＬ更新処理
                    foreach (UoeRecDtl dtl in uoeRecDtlList)
                    {
                        telegramJnlEstmt0202.Telegram(_uoeRecHed.UOESupplierCd, dtl);
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

		# region ＵＯＥ受信電文作成＜見積＞（日産Ｎパーツ）
		/// <summary>
		/// ＵＯＥ受信電文作成＜見積＞（日産Ｎパーツ）
		/// </summary>
		public class TelegramJnlEstmt0202 : UoeRecEdit0202Acs
		{
			# region ＰＭ７ソース
            ////-- 電文領域...本体...見積 -------------------------------------------
            //struct	LN_M {							//                             
            //	char	ghjkn [ 2];					// ﾗｲﾝ      互換性部品条件	   
            //    char	hb    [12];					// 			照会部品番号	   
            //	char	hn    [15];					// 			部品名称		   
            //	char	msu   [ 3];					// 			見積数			   
            //	char	tanka [ 7];					// 			見積単価    	   
            //	char	teika [ 7];					// 			希望小売価格	   
            //	char	sob   [ 2];					// 			部品層別		   
            //	char	sktan [ 7];					// 			仕切単価           
            //	char	kyo   [ 3];					// 			拠点               
            //	char	cen   [ 3];					// 			ｻﾌﾞｾﾝﾀｰ			   
            //	char	mai   [ 3];					// 			メイン			   
            //};
            //struct	DN_MIT {						//                             
            //	char	jh     [ 1];				// TTC  情報区分   		       
            //	char	ts     [ 2];				//      ﾃｷｽﾄｼｰｹﾝｽ  	    	   
            //	char	lg     [ 2];				// 		ﾃｷｽﾄ長				   
            //	char	dbkb   [ 1];				// ﾍｯﾄﾞ 電文区分			   
            //	char	res    [ 1];				//      処理結果			   
            //	char	toikb  [ 1];				//      問い合わせ・応答区分   
            //	char	gyoid  [12];				//      業務ID				   
            //	char	pass   [ 6];				//      業務ﾊﾟｽﾜｰﾄﾞ		   
            //	char	vers   [ 3];				//      端末PGﾊﾞｰｼﾞｮﾝ		   
            //	char	keikb  [ 1];				//      継続区分			   
            //	char	trid   [ 3];				//      取引ID				   
            //	char	exten  [15];				//      拡張エリア			   
            //	char	syocd  [ 2];				//      処理コード			   
            //	char	user   [ 6];				//      ﾕｰｻﾞｰｺｰﾄﾞ			   
            //	char	reto   [ 3];				//      ﾚｰﾄ					   
            //	char	senc   [ 1];				//      選択ｺｰﾄﾞ			   
            //	char	rem    [10];				//      コメント	 		   
            //	struct	LN_M  m[10];				// ﾗｲﾝ       67*10=670ﾊﾞｲﾄ     
            //    char	uscd   [ 6];	            // 端末対応ﾕｰｻﾞｰｺｰﾄﾞ   		   
            //	char	dummy[1332];				// dummy 			           
            //};
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
			/// 見積電文領域＜ライン＞
			/// </summary>
			private class LN_M
			{
                public byte[] ghjkn = new byte[2];					// ﾗｲﾝ      互換性部品条件	   
                public byte[] hb = new byte[12];					// 			照会部品番号	   
                public byte[] hn = new byte[15];					// 			部品名称		   
                public byte[] msu = new byte[3];					// 			見積数			   
                public byte[] tanka = new byte[7];					// 			見積単価    	   
                public byte[] teika = new byte[7];					// 			希望小売価格	   
                public byte[] sob = new byte[2];					// 			部品層別		   
                public byte[] sktan = new byte[7];					// 			仕切単価           
                public byte[] kyo = new byte[3];					// 			拠点               
                public byte[] cen = new byte[3];					// 			ｻﾌﾞｾﾝﾀｰ			   
                public byte[] mai = new byte[3];					// 			メイン			   

				public LN_M()
				{
					Clear(0x00);
				}
				public void Clear(byte cd)
				{
	                UoeCommonFnc.MemSet(ref ghjkn, cd, ghjkn.Length);		// ﾗｲﾝ      互換性部品条件	   
	                UoeCommonFnc.MemSet(ref hb, cd, hb.Length);			// 			照会部品番号	   
	                UoeCommonFnc.MemSet(ref hn, cd, hn.Length);				// 			部品名称		   
	                UoeCommonFnc.MemSet(ref msu, cd, msu.Length);			// 			見積数			   
	                UoeCommonFnc.MemSet(ref tanka, cd, tanka.Length);		// 			見積単価    	   
	                UoeCommonFnc.MemSet(ref teika, cd, teika.Length);		// 			希望小売価格	   
	                UoeCommonFnc.MemSet(ref sob, cd, sob.Length);			// 			部品層別		   
	                UoeCommonFnc.MemSet(ref sktan, cd, sktan.Length);		// 			仕切単価           
	                UoeCommonFnc.MemSet(ref kyo, cd, kyo.Length);			// 			拠点               
	                UoeCommonFnc.MemSet(ref cen, cd, cen.Length);			// 			ｻﾌﾞｾﾝﾀｰ			   
	                UoeCommonFnc.MemSet(ref mai, cd, mai.Length);			// 			メイン			   
				}
			}

			/// <summary>
			/// 見積電文領域＜本体＞
			/// </summary>
			private class DN_M
			{
	            public byte[]	jh      = new byte[ 1];				// TTC  情報区分   		       
	            public byte[]	ts      = new byte[ 2];				//      ﾃｷｽﾄｼｰｹﾝｽ  	    	   
	            public byte[]	lg      = new byte[ 2];				// 		ﾃｷｽﾄ長				   
	            public byte[]	dbkb    = new byte[ 1];				// ﾍｯﾄﾞ 電文区分			   
	            public byte[]	res     = new byte[ 1];				//      処理結果			   
	            public byte[]	toikb   = new byte[ 1];				//      問い合わせ・応答区分   
	            public byte[]	gyoid   = new byte[12];				//      業務ID				   
	            public byte[]	pass    = new byte[ 6];				//      業務ﾊﾟｽﾜｰﾄﾞ		   
	            public byte[]	vers    = new byte[ 3];				//      端末PGﾊﾞｰｼﾞｮﾝ		   
	            public byte[]	keikb   = new byte[ 1];				//      継続区分			   
	            public byte[]	trid    = new byte[ 3];				//      取引ID				   
	            public byte[]	exten   = new byte[15];				//      拡張エリア			   
	            public byte[]	syocd   = new byte[ 2];				//      処理コード			   
	            public byte[]	user    = new byte[ 6];				//      ﾕｰｻﾞｰｺｰﾄﾞ			   
	            public byte[]	reto    = new byte[ 3];				//      ﾚｰﾄ					   
	            public byte[]	senc    = new byte[ 1];				//      選択ｺｰﾄﾞ			   
	            public byte[]	rem     = new byte[10];				//      コメント	 		   
				public LN_M[] ln_m = new LN_M[ctBufLen];	        // ﾗｲﾝ       14*10=140ﾊﾞｲﾄ
                public byte[]	uscd    = new byte[ 6];	            // 端末対応ﾕｰｻﾞｰｺｰﾄﾞ   		   
	            public byte[]	dummy   = new byte[1332];			// dummy 			           

				/// <summary>	
				/// コンストラクター
				/// </summary>
				public DN_M()
				{
					Clear(0x00);
				}

				public void Clear(byte cd)
				{
	                UoeCommonFnc.MemSet(ref jh, cd, jh.Length);				// TTC  情報区分   		       
	                UoeCommonFnc.MemSet(ref ts, cd, ts.Length);				//      ﾃｷｽﾄｼｰｹﾝｽ  	    	   
	                UoeCommonFnc.MemSet(ref lg, cd, lg.Length);				// 		ﾃｷｽﾄ長				   
	                UoeCommonFnc.MemSet(ref dbkb, cd, dbkb.Length);			// ﾍｯﾄﾞ 電文区分			   
	                UoeCommonFnc.MemSet(ref res, cd, res.Length);			//      処理結果			   
	                UoeCommonFnc.MemSet(ref toikb, cd, toikb.Length);		//      問い合わせ・応答区分   
	                UoeCommonFnc.MemSet(ref gyoid, cd, gyoid.Length);		//      業務ID				   
	                UoeCommonFnc.MemSet(ref pass, cd, pass.Length);			//      業務ﾊﾟｽﾜｰﾄﾞ		   
	                UoeCommonFnc.MemSet(ref vers, cd, vers.Length);			//      端末PGﾊﾞｰｼﾞｮﾝ		   
	                UoeCommonFnc.MemSet(ref keikb, cd, keikb.Length);		//      継続区分			   
	                UoeCommonFnc.MemSet(ref trid, cd, trid.Length);			//      取引ID				   
	                UoeCommonFnc.MemSet(ref exten, cd, exten.Length);		//      拡張エリア			   
	                UoeCommonFnc.MemSet(ref syocd, cd, syocd.Length);		//      処理コード			   
	                UoeCommonFnc.MemSet(ref user, cd, user.Length);			//      ﾕｰｻﾞｰｺｰﾄﾞ			   
	                UoeCommonFnc.MemSet(ref reto, cd, reto.Length);			//      ﾚｰﾄ					   
	                UoeCommonFnc.MemSet(ref senc, cd, senc.Length);			//      選択ｺｰﾄﾞ			   
	                UoeCommonFnc.MemSet(ref rem, cd, rem.Length);			//      コメント	 		   

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
                    
                    UoeCommonFnc.MemSet(ref uscd, cd, uscd.Length);	        // 端末対応ﾕｰｻﾞｰｺｰﾄﾞ   		   
	                UoeCommonFnc.MemSet(ref dummy, cd, dummy.Length);		// dummy 			           
				}
			}
			# endregion

			# region Constructors
			/// <summary>
			/// コンストラクタ
			/// </summary>
			public TelegramJnlEstmt0202()
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

                    // 受信日付
                    dataRow[EstmtSndRcvJnlSchema.ct_Col_ReceiveDate] = DateTime.Now;

                    // 受信時刻
                    dataRow[EstmtSndRcvJnlSchema.ct_Col_ReceiveTime] = TDateTime.DateTimeToLongDate("HHMMSS", DateTime.Now);

                    //ヘッダーエラーの格納処理
                    //ヘッダーエラーなし
                    if (dn_m.res[0] == 0x00)
                    {
                    }
                    //ヘッダーエラーあり
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

		            // レート
                    dataRow[EstmtSndRcvJnlSchema.ct_Col_EstimateRate] = String.Format("{0:D3}",
                                                                            UoeCommonFnc.ToInt32FromByteStrAry(dn_m.reto) * 10);
                    // 選択コード
                    dataRow[EstmtSndRcvJnlSchema.ct_Col_SelectCode] = UoeCommonFnc.ToStringFromByteStrAry(dn_m.senc);

		            // リマーク
                    dataRow[EstmtSndRcvJnlSchema.ct_Col_UoeRemark1] = UoeCommonFnc.ToStringFromByteStrAry(dn_m.rem);

		            // 品番
                    dataRow[EstmtSndRcvJnlSchema.ct_Col_AnswerPartsNo] = UoeCommonFnc.ToStringFromByteStrAry(dn_m.ln_m[i].hb);

                    // 代替品番
                    dataRow[EstmtSndRcvJnlSchema.ct_Col_SubstPartsNo] = UoeCommonFnc.ToStringFromByteStrAry(dn_m.ln_m[i].hn);

		            // 品名
                    //ヘッダーエラーなし
                    if (dn_m.res[0] == 0x00)
                    {
                        dataRow[EstmtSndRcvJnlSchema.ct_Col_AnswerPartsName] = UoeCommonFnc.ToStringFromByteStrAry(dn_m.ln_m[i].hn);
                    }

		            // 見積単価
                    dataRow[EstmtSndRcvJnlSchema.ct_Col_SalesUnPrcTaxExcFl] = UoeCommonFnc.ToDoubleFromByteStrAry(dn_m.ln_m[i].tanka);

		            // 互換性コード
                    dataRow[EstmtSndRcvJnlSchema.ct_Col_UOESubstCode] = UoeCommonFnc.ToStringFromByteStrAry(dn_m.ln_m[i].ghjkn);

		            // 仕切単価
                    dataRow[EstmtSndRcvJnlSchema.ct_Col_AnswerSalesUnitCost] = UoeCommonFnc.ToDoubleFromByteStrAry(dn_m.ln_m[i].sktan);

		            // 定価
                    dataRow[EstmtSndRcvJnlSchema.ct_Col_AnswerListPrice] = UoeCommonFnc.ToDoubleFromByteStrAry(dn_m.ln_m[i].tanka);

		            // 拠点在庫数
                    dataRow[EstmtSndRcvJnlSchema.ct_Col_BranchStock] = UoeCommonFnc.ToInt32FromByteStrAry(dn_m.ln_m[i].kyo);

		            // センター在庫数
                    dataRow[EstmtSndRcvJnlSchema.ct_Col_SectionStock] = UoeCommonFnc.ToInt32FromByteStrAry(dn_m.ln_m[i].cen);

		            // メーカー（メイン）在庫数
                    dataRow[EstmtSndRcvJnlSchema.ct_Col_HeadQtrsStock] = UoeCommonFnc.ToInt32FromByteStrAry(dn_m.ln_m[i].mai);

		            // 層別
                    dataRow[EstmtSndRcvJnlSchema.ct_Col_PartsLayerCd] = UoeCommonFnc.ToStringFromByteStrAry(dn_m.ln_m[i].sob);

					//データ送信区分
                    dataRow[EstmtSndRcvJnlSchema.ct_Col_DataSendCode] = dtl.DataSendCode;

					//データ復旧区分
					dataRow[EstmtSndRcvJnlSchema.ct_Col_DataRecoverDiv] = dtl.DataRecoverDiv;
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

                ms.Read(dn_m.jh, 0, dn_m.jh.Length);			// TTC  情報区分   		       
                ms.Read(dn_m.ts, 0, dn_m.ts.Length);			//      ﾃｷｽﾄｼｰｹﾝｽ  	    	   
                ms.Read(dn_m.lg, 0, dn_m.lg.Length);			// 		ﾃｷｽﾄ長				   
                ms.Read(dn_m.dbkb, 0, dn_m.dbkb.Length);		// ﾍｯﾄﾞ 電文区分			   
                ms.Read(dn_m.res, 0, dn_m.res.Length);			//      処理結果			   
                ms.Read(dn_m.toikb, 0, dn_m.toikb.Length);		//      問い合わせ・応答区分   
                ms.Read(dn_m.gyoid, 0, dn_m.gyoid.Length);		//      業務ID				   
                ms.Read(dn_m.pass, 0, dn_m.pass.Length);		//      業務ﾊﾟｽﾜｰﾄﾞ		   
                ms.Read(dn_m.vers, 0, dn_m.vers.Length);		//      端末PGﾊﾞｰｼﾞｮﾝ		   
                ms.Read(dn_m.keikb, 0, dn_m.keikb.Length);		//      継続区分			   
                ms.Read(dn_m.trid, 0, dn_m.trid.Length);		//      取引ID				   
                ms.Read(dn_m.exten, 0, dn_m.exten.Length);		//      拡張エリア			   
                ms.Read(dn_m.syocd, 0, dn_m.syocd.Length);		//      処理コード			   
                ms.Read(dn_m.user, 0, dn_m.user.Length);		//      ﾕｰｻﾞｰｺｰﾄﾞ			   
                ms.Read(dn_m.reto, 0, dn_m.reto.Length);		//      ﾚｰﾄ					   
                ms.Read(dn_m.senc, 0, dn_m.senc.Length);		//      選択ｺｰﾄﾞ			   
                ms.Read(dn_m.rem, 0, dn_m.rem.Length);			//      コメント	 		   

				//明細部
				for (int i = 0; i < ctBufLen; i++)
				{
                    LN_M _ln_m = dn_m.ln_m[i];

	                ms.Read(_ln_m.ghjkn, 0, _ln_m.ghjkn.Length);		// ﾗｲﾝ      互換性部品条件	   
	                ms.Read(_ln_m.hb, 0, _ln_m.hb.Length);			    // 			照会部品番号	   
	                ms.Read(_ln_m.hn, 0, _ln_m.hn.Length);				// 			部品名称		   
	                ms.Read(_ln_m.msu, 0, _ln_m.msu.Length);			// 			見積数			   
	                ms.Read(_ln_m.tanka, 0, _ln_m.tanka.Length);		// 			見積単価    	   
	                ms.Read(_ln_m.teika, 0, _ln_m.teika.Length);		// 			希望小売価格	   
	                ms.Read(_ln_m.sob, 0, _ln_m.sob.Length);			// 			部品層別		   
	                ms.Read(_ln_m.sktan, 0, _ln_m.sktan.Length);		// 			仕切単価           
	                ms.Read(_ln_m.kyo, 0, _ln_m.kyo.Length);			// 			拠点               
	                ms.Read(_ln_m.cen, 0, _ln_m.cen.Length);			// 			ｻﾌﾞｾﾝﾀｰ			   
	                ms.Read(_ln_m.mai, 0, _ln_m.mai.Length);			// 			メイン			   
				}

                ms.Read(dn_m.uscd, 0, dn_m.uscd.Length);	    // 端末対応ﾕｰｻﾞｰｺｰﾄﾞ   		   
                ms.Read(dn_m.dummy, 0, dn_m.dummy.Length);		// dummy 			           

				ms.Close();
			}
			# endregion


			# endregion
		}
		# endregion

		# endregion
	}
}

//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : ＵＯＥ受信編集＜在庫＞（日産Ｎパーツ）アクセスクラス
// プログラム概要   : ＵＯＥ受信編集＜在庫＞（日産Ｎパーツ）を行う
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
	/// ＵＯＥ受信編集＜在庫＞（日産Ｎパーツ）アクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : ＵＯＥ受信編集＜在庫＞（日産Ｎパーツ）アクセスクラス</br>
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

		# region ＵＯＥ受信編集＜在庫＞（日産Ｎパーツ）
		/// <summary>
		/// ＵＯＥ受信編集＜在庫＞（日産Ｎパーツ）
		/// </summary>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        private int GetJnlStock0202(out string message)
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
                    TelegramJnlStock0202 telegramJnlStock0202 = new TelegramJnlStock0202();

                    //ＪＮＬ更新処理
                    foreach (UoeRecDtl dtl in uoeRecDtlList)
                    {
                        telegramJnlStock0202.Telegram(_uoeRecHed.UOESupplierCd, dtl);
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

		# region ＵＯＥ受信電文作成＜在庫＞（日産Ｎパーツ）
		/// <summary>
		/// ＵＯＥ受信電文作成＜在庫＞（日産Ｎパーツ）
		/// </summary>
		public class TelegramJnlStock0202 : UoeRecEdit0202Acs
		{
			# region ＰＭ７ソース
            //struct	LN_Z {							//                             
            //	char	hb    [12];					// ﾗｲﾝ      品番			   
            //	char	ercd  [ 1];					// 			ｴﾗｰｺｰﾄﾞ			   
            //	char	jkn   [ 2];					// 	前対応	条件			   
            //	char	bhb   [12];					// 			部品番号		   
            //	char	tyob  [ 3];					//          予備               
            //	char	kzsu  [ 3];					// 			拠点在庫数		   
            //
            //	char	sjkn  [ 2];					// 	後対応	条件			   
            //	char	sbhb  [12];					// 			部品番号		   
            //	char	szsu  [ 3];					// 			ｾﾝﾀ在庫数		   
            //	char	syob  [ 3];					// 			予備		       
            //	char	bsob  [ 2];					// 			部品層別		   
            //	char	teika [ 7];					// 			小売価格		   
            //
            //	char	zdmy  [ 3];					// ダミー（未定義）            
            //	char	sedai [ 1];					// 世代区分                    
            //	char	seibi [ 2];					// 整備形態区分                
            //	char	hizyo [ 1];					// 非常備区分                  
            //
            //	char	mkyo  [ 2];					//  ｾﾝﾀｰ区分 ﾒｲﾝｾﾝﾀ拠点番号	   
            //	char	skyo  [ 5][2];				// 	〃  	 ｻﾌﾞｾﾝﾀ拠点番号1-5 
            //	char	kyos  [ 2];					// 	拠点数					   
            //	char	kyobn [40][3];				//	拠点番号1-40			   
            //};
            //struct	DN_ZAI {						//                             
            //	char	jh    [ 1];					// TTC  情報区分   		       
            //	char	ts    [ 2];					//      ﾃｷｽﾄｼｰｹﾝｽ  	    	   
            //	char	lg    [ 2];					// 		ﾃｷｽﾄ長				   
            //	char	dbkb  [ 1];					// ﾍｯﾄﾞ 電文区分			   
            //	char	res   [ 1];					//      処理結果			   
            //	char	toikb [ 1];					//      問い合わせ・応答区分   
            //	char	gyoid [12];					//      業務ID				   
            //	char	pass  [ 6];					//      業務ﾊﾟｽﾜｰﾄﾞ		   
            //	char	vers  [ 3];					//      端末PGﾊﾞｰｼﾞｮﾝ		   
            //	char	keikb [ 1];					//      継続区分			   
            //	char	trid  [ 3];					//      取引ID				   
            //	char	exten [15];					//      拡張エリア			   
            //	char	syocd [ 2];					//      処理コード			   
            //	struct	LN_Z  z[5];					// ﾗｲﾝ       205*5=1025ﾊﾞｲﾄ    
            //	char	uscd  [ 6];		       	    // 端末対応ﾕｰｻﾞｰｺｰﾄﾞ	   	   
            //	char	dummy[992];					// dummy   				       
            //};
			# endregion

			# region Const Members
			private const Int32 ctBufLen = 5;		//明細バッファサイズ
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
	            public byte[]	hb     = new byte[12];					// ﾗｲﾝ      品番			   
	            public byte[]	ercd   = new byte[ 1];					// 			ｴﾗｰｺｰﾄﾞ			   
	            public byte[]	jkn    = new byte[ 2];					// 	前対応	条件			   
	            public byte[]	bhb    = new byte[12];					// 			部品番号		   
	            public byte[]	tyob   = new byte[ 3];					//          予備               
	            public byte[]	kzsu   = new byte[ 3];					// 			拠点在庫数		   

	            public byte[]	sjkn   = new byte[ 2];					// 	後対応	条件			   
	            public byte[]	sbhb   = new byte[12];					// 			部品番号		   
	            public byte[]	szsu   = new byte[ 3];					// 			ｾﾝﾀ在庫数		   
	            public byte[]	syob   = new byte[ 3];					// 			予備		       
	            public byte[]	bsob   = new byte[ 2];					// 			部品層別		   
	            public byte[]	teika  = new byte[ 7];					// 			小売価格		   

	            public byte[]	zdmy   = new byte[ 3];					// ダミー（未定義）            
	            public byte[]	sedai  = new byte[ 1];					// 世代区分                    
	            public byte[]	seibi  = new byte[ 2];					// 整備形態区分                
	            public byte[]	hizyo  = new byte[ 1];					// 非常備区分                  

	            public byte[]	mkyo   = new byte[ 2];					//  ｾﾝﾀｰ区分 ﾒｲﾝｾﾝﾀ拠点番号	   
	            public byte[][]	skyo   = new byte[ 5][];				// 	〃  	 ｻﾌﾞｾﾝﾀ拠点番号1-5 new byte[ 5][2] 
	            public byte[]	kyos   = new byte[ 2];					// 	拠点数					   
	            public byte[][]	kyobn  = new byte[40][];				//	拠点番号1-40 new byte[40][3]			   

				public LN_Z()
				{
					Clear(0x00);
				}
				public void Clear(byte cd)
				{
	                UoeCommonFnc.MemSet(ref hb, cd, hb.Length);				// ﾗｲﾝ      品番			   
	                UoeCommonFnc.MemSet(ref ercd, cd, ercd.Length);			// 			ｴﾗｰｺｰﾄﾞ			   
	                UoeCommonFnc.MemSet(ref jkn, cd, jkn.Length);			// 	前対応	条件			   
	                UoeCommonFnc.MemSet(ref bhb, cd, bhb.Length);			// 			部品番号		   
	                UoeCommonFnc.MemSet(ref tyob, cd, tyob.Length);			//          予備               
	                UoeCommonFnc.MemSet(ref kzsu, cd, kzsu.Length);			// 			拠点在庫数		   

	                UoeCommonFnc.MemSet(ref sjkn, cd, sjkn.Length);			// 	後対応	条件			   
	                UoeCommonFnc.MemSet(ref sbhb, cd, sbhb.Length);			// 			部品番号		   
	                UoeCommonFnc.MemSet(ref szsu, cd, szsu.Length);			// 			ｾﾝﾀ在庫数		   
	                UoeCommonFnc.MemSet(ref syob, cd, syob.Length);			// 			予備		       
	                UoeCommonFnc.MemSet(ref bsob, cd, bsob.Length);			// 			部品層別		   
	                UoeCommonFnc.MemSet(ref teika, cd, teika.Length);		// 			小売価格		   

	                UoeCommonFnc.MemSet(ref zdmy, cd, zdmy.Length);			// ダミー（未定義）            
	                UoeCommonFnc.MemSet(ref sedai, cd, sedai.Length);		// 世代区分                    
	                UoeCommonFnc.MemSet(ref seibi, cd, seibi.Length);		// 整備形態区分                
	                UoeCommonFnc.MemSet(ref hizyo, cd, hizyo.Length);		// 非常備区分                  

	                UoeCommonFnc.MemSet(ref mkyo, cd, mkyo.Length);			//  ｾﾝﾀｰ区分 ﾒｲﾝｾﾝﾀ拠点番号	   

                    // 	〃  	 ｻﾌﾞｾﾝﾀ拠点番号1-5 
                    for (int i = 0; i < skyo.Length; i++)
                    {
                        skyo[i] = new byte[2];
                    }

	                UoeCommonFnc.MemSet(ref kyos, cd, kyos.Length);			// 	拠点数					   

                    //	拠点番号1-40			   
                    for (int i = 0; i < kyobn.Length; i++)
                    {
                        kyobn[i] = new byte[3];
                    }
				}
			}

			/// <summary>
			/// 在庫電文領域＜本体＞
			/// </summary>
			private class DN_Z
			{
	            public byte[]	jh     = new byte[ 1];					// TTC  情報区分   		       
	            public byte[]	ts     = new byte[ 2];					//      ﾃｷｽﾄｼｰｹﾝｽ  	    	   
	            public byte[]	lg     = new byte[ 2];					// 		ﾃｷｽﾄ長				   
	            public byte[]	dbkb   = new byte[ 1];					// ﾍｯﾄﾞ 電文区分			   
	            public byte[]	res    = new byte[ 1];					//      処理結果			   
	            public byte[]	toikb  = new byte[ 1];					//      問い合わせ・応答区分   
	            public byte[]	gyoid  = new byte[12];					//      業務ID				   
	            public byte[]	pass   = new byte[ 6];					//      業務ﾊﾟｽﾜｰﾄﾞ		   
	            public byte[]	vers   = new byte[ 3];					//      端末PGﾊﾞｰｼﾞｮﾝ		   
	            public byte[]	keikb  = new byte[ 1];					//      継続区分			   
	            public byte[]	trid   = new byte[ 3];					//      取引ID				   
	            public byte[]	exten  = new byte[15];					//      拡張エリア			   
	            public byte[]	syocd  = new byte[ 2];					//      処理コード			   

                public LN_Z[] ln_z = new LN_Z[ctBufLen];                // ﾗｲﾝ

                public byte[]	uscd   = new byte[ 6];		       	    // 端末対応ﾕｰｻﾞｰｺｰﾄﾞ	   	   
	            public byte[]	dummy  = new byte[992];					// dummy   				       

				/// <summary>	
				/// コンストラクター
				/// </summary>
				public DN_Z()
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

					//明細部
                    for (int i = 0; i < ln_z.Length; i++)
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

	                UoeCommonFnc.MemSet(ref uscd, cd, uscd.Length);			// 端末対応ﾕｰｻﾞｰｺｰﾄﾞ	   	   
	                UoeCommonFnc.MemSet(ref dummy, cd, dummy.Length);		// dummy   				       
				}

			}
			# endregion

			# region Constructors
			/// <summary>
			/// コンストラクタ
			/// </summary>
			public TelegramJnlStock0202()
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

                    // 受信日付
                    dataRow[StockSndRcvJnlSchema.ct_Col_ReceiveDate] = DateTime.Now;

                    // 受信時刻
                    dataRow[StockSndRcvJnlSchema.ct_Col_ReceiveTime] = TDateTime.DateTimeToLongDate("HHMMSS", DateTime.Now);

                    //ヘッダーエラーの格納処理
                    //ヘッダーエラーなし
                    if (dn_z.res[0] == 0x00)
                    {
                    }
                    //ヘッダーエラーあり
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

		            // 部品番号
                    dataRow[StockSndRcvJnlSchema.ct_Col_AnswerPartsNo] = UoeCommonFnc.ToStringFromByteStrAry(dn_z.ln_z[i].hb);
#if False
		            /* 品番補正----------------------------------------------------*/
		            memset( hibn, 0x20, sizeof hibn );
		            if( memcmp( uoejlc.PM3010JH, hibn, sizeof uoejlc.PM3010JH ) == 0 )
			            memcpy( uoejlc.PM3010JH, uoejlc.D3010H, sizeof uoejlc.D3010H  );
#endif

		            /* 品名（代替品番１）------------------------------------------*/
		            if(	( dn_z.ln_z[i].ercd[0] == '4'   )
		            ||  ( dn_z.ln_z[i].jkn[0] == 'F' )
		            ||	( dn_z.ln_z[i].jkn[0] == 'B' ))
		            {//代替あり
                        dataRow[StockSndRcvJnlSchema.ct_Col_SubstPartsNo] = UoeCommonFnc.ToStringFromByteStrAry(dn_z.ln_z[i].bhb);
		            }
                    else
                    {
                        if (dn_z.res[0] == 0x00)
                        {
                            string answerPartsName = "";
				            if( dn_z.ln_z[i].ercd[0] == '1' )
                            {
                                answerPartsName = "ｼｭｯｶﾃｲｼﾌﾞﾋﾝ";
                            }
				            else if( dn_z.ln_z[i].ercd[0] == '2' )
                            {
                                answerPartsName = "ﾋｻﾞｲｺﾋﾝ";
                            }
				            else if( dn_z.ln_z[i].ercd[0] == '3' )
                            {
                                answerPartsName = "ｱﾝﾏｯﾁｴﾗｰ";
                            }
				            else
                            {
                                answerPartsName = UoeCommonFnc.ToStringFromByteStrAry(dn_z.ln_z[i].bhb);
                            }
                            dataRow[StockSndRcvJnlSchema.ct_Col_AnswerPartsName] = answerPartsName;
                        }
		            }

		            // 品名（代替品番２）
                    if ((dn_z.ln_z[i].ercd[0] == '4')
		            ||  ( dn_z.ln_z[i].sjkn[0] == 'F' )
		            ||	( dn_z.ln_z[i].sjkn[0] == 'B' ))
		            {//代替あり
                        dataRow[StockSndRcvJnlSchema.ct_Col_CenterSubstPartsNo] = UoeCommonFnc.ToStringFromByteStrAry(dn_z.ln_z[i].sbhb);
		            }
                    else
                    {
                        if (dn_z.res[0] == 0x00)
                        {
                            string answerPartsName = "";
                            if (dn_z.ln_z[i].ercd[0] == '1')
                            {
                                answerPartsName = "ｼｭｯｶﾃｲｼﾌﾞﾋﾝ";
                            }
                            else if (dn_z.ln_z[i].ercd[0] == '2')
                            {
                                answerPartsName = "ﾋｻﾞｲｺﾋﾝ";
                            }
                            else if (dn_z.ln_z[i].ercd[0] == '3')
                            {
                                answerPartsName = "ｱﾝﾏｯﾁｴﾗｰ";
                            }
				            else
                            {
                                string bhbString = UoeCommonFnc.ToStringFromByteStrAry(dn_z.ln_z[i].bhb);
                                if(bhbString.Trim() == "")
                                {
                                    answerPartsName = UoeCommonFnc.ToStringFromByteStrAry(dn_z.ln_z[i].sbhb);
                                }
				            }
                            if (answerPartsName.Trim() != "")
                            {
                                dataRow[StockSndRcvJnlSchema.ct_Col_AnswerPartsName] = answerPartsName;
                            }
			            }
		            }

		            // 定価
                    dataRow[StockSndRcvJnlSchema.ct_Col_AnswerListPrice] = UoeCommonFnc.ToDoubleFromByteStrAry(dn_z.ln_z[i].teika);

		            // サブセンター拠点
        			# region サブセンター拠点
		            for (int ix = 0 ; ix < 35 ; ix++ )
                    {
                        int kyobnInt = 0;

			            if(	UoeCommonFnc.MemCmp( dn_z.ln_z[i].kyobn[ix], "***", dn_z.ln_z[i].kyobn[ix].Length ) == 0
			            ||	UoeCommonFnc.MemCmp( dn_z.ln_z[i].kyobn[ix], "   ", dn_z.ln_z[i].kyobn[ix].Length ) == 0
			            ||	UoeCommonFnc.MemCmp( dn_z.ln_z[i].kyobn[ix], "000", dn_z.ln_z[i].kyobn[ix].Length ) == 0 )
			            {
                            kyobnInt = 0;
			            }
                        else
                        {
                            kyobnInt = UoeCommonFnc.ToInt32FromByteStrAry(dn_z.ln_z[i].kyobn[ix]);
                        }
                        switch(ix)
                        {
                            case 0:
                                dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock1] = kyobnInt;
                                break;
                            case 1:
                                dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock2] = kyobnInt;
                                break;
                            case 2:
                                dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock3] = kyobnInt;
                                break;
                            case 3:
                                dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock4] = kyobnInt;
                                break;
                            case 4:
                                dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock5] = kyobnInt;
                                break;
                            case 5:
                                dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock6] = kyobnInt;
                                break;
                            case 6:
                                dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock7] = kyobnInt;
                                break;
                            case 7:
                                dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock8] = kyobnInt;
                                break;
                            case 8:
                                dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock9] = kyobnInt;
                                break;
                            case 9:
                                dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock10] = kyobnInt;
                                break;
                            case 10:
                                dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock11] = kyobnInt;
                                break;
                            case 11:
                                dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock12] = kyobnInt;
                                break;
                            case 12:
                                dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock13] = kyobnInt;
                                break;
                            case 13:
                                dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock14] = kyobnInt;
                                break;
                            case 14:
                                dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock15] = kyobnInt;
                                break;
                            case 15:
                                dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock16] = kyobnInt;
                                break;
                            case 16:
                                dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock17] = kyobnInt;
                                break;
                            case 17:
                                dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock18] = kyobnInt;
                                break;
                            case 18:
                                dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock19] = kyobnInt;
                                break;
                            case 19:
                                dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock20] = kyobnInt;
                                break;
                            case 20:
                                dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock21] = kyobnInt;
                                break;
                            case 21:
                                dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock22] = kyobnInt;
                                break;
                            case 22:
                                dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock23] = kyobnInt;
                                break;
                            case 23:
                                dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock24] = kyobnInt;
                                break;
                            case 24:
                                dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock25] = kyobnInt;
                                break;
                            case 25:
                                dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock26] = kyobnInt;
                                break;
                            case 26:
                                dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock27] = kyobnInt;
                                break;
                            case 27:
                                dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock28] = kyobnInt;
                                break;
                            case 28:
                                dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock29] = kyobnInt;
                                break;
                            case 29:
                                dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock30] = kyobnInt;
                                break;
                            case 30:
                                dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock31] = kyobnInt;
                                break;
                            case 31:
                                dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock32] = kyobnInt;
                                break;
                            case 32:
                                dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock33] = kyobnInt;
                                break;
                            case 33:
                                dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock34] = kyobnInt;
                                break;
                            case 34:
                                dataRow[StockSndRcvJnlSchema.ct_Col_UOESectionStock35] = kyobnInt;
                                break;
                        }
		            }
        			# endregion

		            // 層別
                    dataRow[StockSndRcvJnlSchema.ct_Col_PartsLayerCd] = UoeCommonFnc.ToStringFromByteStrAry(dn_z.ln_z[i].bsob);

					// データ送信区分
                    dataRow[StockSndRcvJnlSchema.ct_Col_DataSendCode] = dtl.DataSendCode;

					// データ復旧区分
					dataRow[StockSndRcvJnlSchema.ct_Col_DataRecoverDiv] = dtl.DataRecoverDiv;
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

	            ms.Read(dn_z.jh, 0, dn_z.jh.Length);				// TTC  情報区分   		       
	            ms.Read(dn_z.ts, 0, dn_z.ts.Length);				//      ﾃｷｽﾄｼｰｹﾝｽ  	    	   
	            ms.Read(dn_z.lg, 0, dn_z.lg.Length);				// 		ﾃｷｽﾄ長				   
	            ms.Read(dn_z.dbkb, 0, dn_z.dbkb.Length);			// ﾍｯﾄﾞ 電文区分			   
	            ms.Read(dn_z.res, 0, dn_z.res.Length);			    //      処理結果			   
	            ms.Read(dn_z.toikb, 0, dn_z.toikb.Length);		    //      問い合わせ・応答区分   
	            ms.Read(dn_z.gyoid, 0, dn_z.gyoid.Length);		    //      業務ID				   
	            ms.Read(dn_z.pass, 0, dn_z.pass.Length);			//      業務ﾊﾟｽﾜｰﾄﾞ		   
	            ms.Read(dn_z.vers, 0, dn_z.vers.Length);			//      端末PGﾊﾞｰｼﾞｮﾝ		   
	            ms.Read(dn_z.keikb, 0, dn_z.keikb.Length);		    //      継続区分			   
	            ms.Read(dn_z.trid, 0, dn_z.trid.Length);			//      取引ID				   
	            ms.Read(dn_z.exten, 0, dn_z.exten.Length);		    //      拡張エリア			   
	            ms.Read(dn_z.syocd, 0, dn_z.syocd.Length);		    //      処理コード			   

				//明細部
				for (int i = 0; i < ctBufLen; i++)
				{
                    LN_Z _ln_z = dn_z.ln_z[i];

	                ms.Read(_ln_z.hb, 0, _ln_z.hb.Length);				// ﾗｲﾝ      品番			   
	                ms.Read(_ln_z.ercd, 0, _ln_z.ercd.Length);			// 			ｴﾗｰｺｰﾄﾞ			   
	                ms.Read(_ln_z.jkn, 0, _ln_z.jkn.Length);			// 	前対応	条件			   
	                ms.Read(_ln_z.bhb, 0, _ln_z.bhb.Length);			// 			部品番号		   
	                ms.Read(_ln_z.tyob, 0, _ln_z.tyob.Length);			//          予備               
	                ms.Read(_ln_z.kzsu, 0, _ln_z.kzsu.Length);			// 			拠点在庫数		   

	                ms.Read(_ln_z.sjkn, 0, _ln_z.sjkn.Length);			// 	後対応	条件			   
	                ms.Read(_ln_z.sbhb, 0, _ln_z.sbhb.Length);			// 			部品番号		   
	                ms.Read(_ln_z.szsu, 0, _ln_z.szsu.Length);			// 			ｾﾝﾀ在庫数		   
	                ms.Read(_ln_z.syob, 0, _ln_z.syob.Length);			// 			予備		       
	                ms.Read(_ln_z.bsob, 0, _ln_z.bsob.Length);			// 			部品層別		   
	                ms.Read(_ln_z.teika, 0, _ln_z.teika.Length);		// 			小売価格		   

	                ms.Read(_ln_z.zdmy, 0, _ln_z.zdmy.Length);			// ダミー（未定義）            
	                ms.Read(_ln_z.sedai, 0, _ln_z.sedai.Length);		// 世代区分                    
	                ms.Read(_ln_z.seibi, 0, _ln_z.seibi.Length);		// 整備形態区分                
	                ms.Read(_ln_z.hizyo, 0, _ln_z.hizyo.Length);		// 非常備区分                  

	                ms.Read(_ln_z.mkyo, 0, _ln_z.mkyo.Length);			//  ｾﾝﾀｰ区分 ﾒｲﾝｾﾝﾀ拠点番号	   
	
                    // ｻﾌﾞｾﾝﾀ拠点番号1-5 
                    for (int j = 0; j < _ln_z.skyo.Length; j++)
                    {
    	                ms.Read(_ln_z.skyo[j], 0, _ln_z.skyo[j].Length);//  ｾﾝﾀｰ区分 ﾒｲﾝｾﾝﾀ拠点番号	   
                    }

                	ms.Read(_ln_z.kyos, 0, _ln_z.kyos.Length);			// 	拠点数					   
                    
                    //	拠点番号1-40			   
                    for (int j = 0; j < _ln_z.kyobn.Length; j++)
                    {
    	                ms.Read(_ln_z.kyobn[j], 0, _ln_z.kyobn[j].Length);  //  ｾﾝﾀｰ区分 ﾒｲﾝｾﾝﾀ拠点番号	   
                    }
				}

	            ms.Read(dn_z.uscd, 0, dn_z.uscd.Length);		        // 端末対応ﾕｰｻﾞｰｺｰﾄﾞ	   	   
	            ms.Read(dn_z.dummy, 0, dn_z.dummy.Length);		        // dummy   				       

				ms.Close();
			}
			# endregion

			# endregion
		}
		# endregion

		# endregion


	}
}

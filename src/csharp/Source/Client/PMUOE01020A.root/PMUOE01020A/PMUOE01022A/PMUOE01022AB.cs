//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : ＵＯＥ受信編集＜発注＞（日産Ｎパーツ）アクセスクラス
// プログラム概要   : ＵＯＥ受信編集＜発注＞（日産Ｎパーツ）を行う
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
	/// ＵＯＥ受信編集＜発注＞（日産Ｎパーツ）アクセスクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : ＵＯＥ受信編集（日産Ｎパーツ）アクセスクラス</br>
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

		# region ＵＯＥ受信編集＜発注＞（日産Ｎパーツ）
		/// <summary>
		/// ＵＯＥ受信編集＜発注＞（日産Ｎパーツ）
		/// </summary>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        private int GetJnlOrder0202(out string message)
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
                    TelegramJnlOrder0202 telegramJnlOrder0202 = new TelegramJnlOrder0202();

                    //ＪＮＬ更新処理
                    foreach (UoeRecDtl dtl in uoeRecDtlList)
                    {
                        telegramJnlOrder0202.Telegram(_uoeRecHed.UOESupplierCd, dtl);
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

		# region ＵＯＥ受信電文作成＜発注＞（日産Ｎパーツ）
		/// <summary>
		/// ＵＯＥ受信電文作成＜発注＞（日産Ｎパーツ）
		/// </summary>
		public class TelegramJnlOrder0202 : UoeRecEdit0202Acs
		{
			# region ＰＭ７ソース
            //struct	LN_H {						//                             
            //	char	hadt    [12];				// 部品番号					   
            //	char	bo      [ 1];				// Ｂ／Ｏ区分				   
            //	char	knm     [16];				// 品名						   
            //	char	hasu    [ 5];				// 発注数量					   
            //	char	bos     [ 1];				// Ｂ／Ｏｼﾝﾎﾞﾙ				   
            //	char	kysu    [ 5];				// 拠点   出庫数               
            //	char	kydno   [ 6];				//        納品書ＮＯ		   
            //	char	skzk    [ 1];				//        仕掛在庫引当ｼﾝﾎﾞﾙ    
            //	char	skzd    [ 4];				//        仕掛在庫引当表示     
            //	char	skzs    [ 5];				//        仕掛在庫引当数量     
            //	char	shcd    [ 3];				// ＳＳ   拠点ｺｰﾄﾞ			   
            //	char	shsu    [ 5];				//        出庫数			   
            //	char	shdno   [ 6];				//        納品書ＮＯ		   
            //	char	shzk    [ 1];				//        仕掛在庫引当ｼﾝﾎﾞﾙ    
            //	char	hocd    [ 3];				// ＭＳ   拠点ｺｰﾄﾞ			   
            //	char	hosu    [ 5];				//        出庫数			   
            //	char	hodno   [ 6];				//        納品書ＮＯ		   
            //	char	hozk    [ 1];				//        仕掛在庫引当ｼﾝﾎﾞﾙ    
            //	char	f3cd    [ 3];				// その他 拠点ｺｰﾄﾞ			   
            //	char	f3su    [ 5];				//        出庫数			   
            //	char	f3dno   [ 6];				//        納品書ＮＯ		   
            //
            //	char	hzan    [ 5];				// 発注残引当数				   
            //	char	fzan    [ 5];				// 不足数      				   
            //	char	eohb    [12];				// ﾒｰｶｰE/O引当部品番号		   
            //	char	eosu    [ 3];				// ﾒｰｶｰE/O引当数      		   
            //	char	mksu    [ 3];				// ﾒｰｶｰB/O数        		   
            //	char	nkkb    [ 1];				// 予定納期区分     		   
            //	char	ytmd    [ 4];				// 納入予定日       		   
            //	char	mkdno   [ 6];				// Ｂ／Ｏ管理№				   
            //	char	azaid   [ 1];				// 全社在庫表示				   
            //	char	azais   [ 5];				// 全社在庫数  				   
            //	char	teika   [ 7];				// 摘要(定価)				   
            //	char	tanka   [ 7];				// 仕切価格					   
            //	char	sob     [ 2];				// 部品層別					   
            //	char	lmsg    [12];				// ﾗｲﾝﾒｯｾｰｼﾞ				   
            //
            //	char	bomsg   [ 1];				// （結果）Ｂ／Ｏﾒｯｾｰｼﾞ区分	   
            //	char	bosu    [ 5];				// （結果）Ｂ／Ｏ数            
            //  char	sinb	[ 1];				// ２世代前シンボル            
            //
            //};
            //struct	DN_HAC {					//                             
            //	char	jkbn    [ 1];				// 情報区分					   
            //	char	seq_no  [ 2];				// テキストシーケンス番号	   
            //	char	text_len[ 2];				// テキスト長				   
            //	char	dkbn    [ 1];				// 電文区分					   
            //	char	kekka   [ 1];				// 処理結果					   
            //	char	tokbn   [ 1];				// 問合せ／応答区分			   
            //	char	g_id    [12];				// 業務ＩＤ					   
            //	char	g_pass  [ 6];				// 業務パスワード			   
            //	char	prog_ver[ 3];				// 端末プログラムバージョン番号
            //	char	kkbn    [ 1];				// 継続区分					   
            //	char	h_id    [ 3];				// 引当ＩＤ					   
            //	char	ext     [15];				// 拡張エリア				   
            //	char	syori_cd[ 2];				// 処理コード				   
            //	char	out_ren [ 6];				// 出力通番					   
            //	char	saisou  [ 1];				// 再送結果					   
            //	char	user_cd [ 6];				// ユーザーコード			   
            //	char	tori_cd [ 6];				// 取引先  コード			   
            //	char	nhkb    [ 1];				// 納品区分					   
            //	char	iracd   [ 2];				// 依頼者コード				   
            //	char	kyoten  [ 3];				// 指定拠点					   
            //	char	bin     [ 1];				// 便      					   
            //	char	rem     [10];				// リマーク  				   
            //  char	rem2    [10];				// リマーク２  				   
            //	char	ermsg   [12];				// エラーメッセージ			   
            //	struct	LN_H	ln_h[4];			// ライン                      
            //	char	tuser_cd[ 6];				// 端末対応ユーザーコード	   
            //	char	mkmdhms [10];				// ﾒｰｶｰ回答問合時刻 MMDDHHMMSS 
            //	char	mkkb    [ 1];				// ﾒｰｶｰ区分					   
            //	char	dnymdhm [12];				// 電文送信時刻   YYYYMMDDHHMM 
            //	char	dummy [1191];				// 予備                        
            //};

            # endregion

			# region Const Members
			private const Int32 ctBufLen = 4;		//明細バッファサイズ
			# endregion

			# region 電文領域クラス
			/// <summary>
			/// 発注電文領域＜ライン＞
			/// </summary>
			private class LN_H
			{
                public byte[] hadt = new byte[12];				// 部品番号					   
                public byte[] bo = new byte[1];				// Ｂ／Ｏ区分				   
                public byte[] knm = new byte[16];				// 品名						   
                public byte[] hasu = new byte[5];				// 発注数量					   
                public byte[] bos = new byte[1];				// Ｂ／Ｏｼﾝﾎﾞﾙ				   
                public byte[] kysu = new byte[5];				// 拠点   出庫数               
                public byte[] kydno = new byte[6];				//        納品書ＮＯ		   
                public byte[] skzk = new byte[1];				//        仕掛在庫引当ｼﾝﾎﾞﾙ    
                public byte[] skzd = new byte[4];				//        仕掛在庫引当表示     
                public byte[] skzs = new byte[5];				//        仕掛在庫引当数量     
                public byte[] shcd = new byte[3];				// ＳＳ   拠点ｺｰﾄﾞ			   
                public byte[] shsu = new byte[5];				//        出庫数			   
                public byte[] shdno = new byte[6];				//        納品書ＮＯ		   
                public byte[] shzk = new byte[1];				//        仕掛在庫引当ｼﾝﾎﾞﾙ    
                public byte[] hocd = new byte[3];				// ＭＳ   拠点ｺｰﾄﾞ			   
                public byte[] hosu = new byte[5];				//        出庫数			   
                public byte[] hodno = new byte[6];				//        納品書ＮＯ		   
                public byte[] hozk = new byte[1];				//        仕掛在庫引当ｼﾝﾎﾞﾙ    
                public byte[] f3cd = new byte[3];				// その他 拠点ｺｰﾄﾞ			   
                public byte[] f3su = new byte[5];				//        出庫数			   
                public byte[] f3dno = new byte[6];				//        納品書ＮＯ		   

                public byte[] hzan = new byte[5];				// 発注残引当数				   
                public byte[] fzan = new byte[5];				// 不足数      				   
                public byte[] eohb = new byte[12];				// ﾒｰｶｰE/O引当部品番号		   
                public byte[] eosu = new byte[3];				// ﾒｰｶｰE/O引当数      		   
                public byte[] mksu = new byte[3];				// ﾒｰｶｰB/O数        		   
                public byte[] nkkb = new byte[1];				// 予定納期区分     		   
                public byte[] ytmd = new byte[4];				// 納入予定日       		   
                public byte[] mkdno = new byte[6];				// Ｂ／Ｏ管理№				   
                public byte[] azaid = new byte[1];				// 全社在庫表示				   
                public byte[] azais = new byte[5];				// 全社在庫数  				   
                public byte[] teika = new byte[7];				// 摘要(定価)				   
                public byte[] tanka = new byte[7];				// 仕切価格					   
                public byte[] sob = new byte[2];				// 部品層別					   
                public byte[] lmsg = new byte[12];				// ﾗｲﾝﾒｯｾｰｼﾞ				   

                public byte[] bomsg = new byte[1];				// （結果）Ｂ／Ｏﾒｯｾｰｼﾞ区分	   
                public byte[] bosu = new byte[5];				// （結果）Ｂ／Ｏ数            
                public byte[] sinb = new byte[1];				// ２世代前シンボル            

				public LN_H()
				{
					Clear(0x00);
				}
				public void Clear(byte cd)
				{
	                UoeCommonFnc.MemSet(ref hadt, cd, hadt.Length);			// 部品番号					   
	                UoeCommonFnc.MemSet(ref bo, cd, bo.Length);				// Ｂ／Ｏ区分				   
	                UoeCommonFnc.MemSet(ref knm, cd, knm.Length);			// 品名						   
	                UoeCommonFnc.MemSet(ref hasu, cd, hasu.Length);			// 発注数量					   
	                UoeCommonFnc.MemSet(ref bos, cd, bos.Length);			// Ｂ／Ｏｼﾝﾎﾞﾙ				   
	                UoeCommonFnc.MemSet(ref kysu, cd, kysu.Length);			// 拠点   出庫数               
	                UoeCommonFnc.MemSet(ref kydno, cd, kydno.Length);		//        納品書ＮＯ		   
	                UoeCommonFnc.MemSet(ref skzk, cd, skzk.Length);			//        仕掛在庫引当ｼﾝﾎﾞﾙ    
	                UoeCommonFnc.MemSet(ref skzd, cd, skzd.Length);			//        仕掛在庫引当表示     
	                UoeCommonFnc.MemSet(ref skzs, cd, skzs.Length);			//        仕掛在庫引当数量     
	                UoeCommonFnc.MemSet(ref shcd, cd, shcd.Length);			// ＳＳ   拠点ｺｰﾄﾞ			   
	                UoeCommonFnc.MemSet(ref shsu, cd, shsu.Length);			//        出庫数			   
	                UoeCommonFnc.MemSet(ref shdno, cd, shdno.Length);		//        納品書ＮＯ		   
	                UoeCommonFnc.MemSet(ref shzk, cd, shzk.Length);			//        仕掛在庫引当ｼﾝﾎﾞﾙ    
	                UoeCommonFnc.MemSet(ref hocd, cd, hocd.Length);			// ＭＳ   拠点ｺｰﾄﾞ			   
	                UoeCommonFnc.MemSet(ref hosu, cd, hosu.Length);			//        出庫数			   
	                UoeCommonFnc.MemSet(ref hodno, cd, hodno.Length);		//        納品書ＮＯ		   
	                UoeCommonFnc.MemSet(ref hozk, cd, hozk.Length);			//        仕掛在庫引当ｼﾝﾎﾞﾙ    
	                UoeCommonFnc.MemSet(ref f3cd, cd, f3cd.Length);			// その他 拠点ｺｰﾄﾞ			   
	                UoeCommonFnc.MemSet(ref f3su, cd, f3su.Length);			//        出庫数			   
	                UoeCommonFnc.MemSet(ref f3dno, cd, f3dno.Length);		//        納品書ＮＯ		   

	                UoeCommonFnc.MemSet(ref hzan, cd, hzan.Length);			// 発注残引当数				   
	                UoeCommonFnc.MemSet(ref fzan, cd, fzan.Length);			// 不足数      				   
	                UoeCommonFnc.MemSet(ref eohb, cd, eohb.Length);			// ﾒｰｶｰE/O引当部品番号		   
	                UoeCommonFnc.MemSet(ref eosu, cd, eosu.Length);			// ﾒｰｶｰE/O引当数      		   
	                UoeCommonFnc.MemSet(ref mksu, cd, mksu.Length);			// ﾒｰｶｰB/O数        		   
	                UoeCommonFnc.MemSet(ref nkkb, cd, nkkb.Length);			// 予定納期区分     		   
	                UoeCommonFnc.MemSet(ref ytmd, cd, ytmd.Length);			// 納入予定日       		   
	                UoeCommonFnc.MemSet(ref mkdno, cd, mkdno.Length);		// Ｂ／Ｏ管理№				   
	                UoeCommonFnc.MemSet(ref azaid, cd, azaid.Length);		// 全社在庫表示				   
	                UoeCommonFnc.MemSet(ref azais, cd, azais.Length);		// 全社在庫数  				   
	                UoeCommonFnc.MemSet(ref teika, cd, teika.Length);		// 摘要(定価)				   
	                UoeCommonFnc.MemSet(ref tanka, cd, tanka.Length);		// 仕切価格					   
	                UoeCommonFnc.MemSet(ref sob, cd, sob.Length);			// 部品層別					   
	                UoeCommonFnc.MemSet(ref lmsg, cd, lmsg.Length);			// ﾗｲﾝﾒｯｾｰｼﾞ				   

	                UoeCommonFnc.MemSet(ref bomsg, cd, bomsg.Length);		// （結果）Ｂ／Ｏﾒｯｾｰｼﾞ区分	   
	                UoeCommonFnc.MemSet(ref bosu, cd, bosu.Length);			// （結果）Ｂ／Ｏ数            
	                UoeCommonFnc.MemSet(ref sinb, cd, sinb.Length);		    // ２世代前シンボル            
				}
			}

			/// <summary>
			/// 発注電文領域＜本体＞
			/// </summary>
			private class DN_H
			{
	            public byte[]	jkbn     = new byte[ 1];				// 情報区分					   
	            public byte[]	seq_no   = new byte[ 2];				// テキストシーケンス番号	   
	            public byte[]	text_len = new byte[ 2];				// テキスト長				   
	            public byte[]	dkbn     = new byte[ 1];				// 電文区分					   
	            public byte[]	kekka    = new byte[ 1];				// 処理結果					   
	            public byte[]	tokbn    = new byte[ 1];				// 問合せ／応答区分			   
	            public byte[]	g_id     = new byte[12];				// 業務ＩＤ					   
	            public byte[]	g_pass   = new byte[ 6];				// 業務パスワード			   
	            public byte[]	prog_ver = new byte[ 3];				// 端末プログラムバージョン番号
	            public byte[]	kkbn     = new byte[ 1];				// 継続区分					   
	            public byte[]	h_id     = new byte[ 3];				// 引当ＩＤ					   
	            public byte[]	ext      = new byte[15];				// 拡張エリア				   
	            public byte[]	syori_cd = new byte[ 2];				// 処理コード				   
	            public byte[]	out_ren  = new byte[ 6];				// 出力通番					   
	            public byte[]	saisou   = new byte[ 1];				// 再送結果					   
	            public byte[]	user_cd  = new byte[ 6];				// ユーザーコード			   
	            public byte[]	tori_cd  = new byte[ 6];				// 取引先  コード			   
	            public byte[]	nhkb     = new byte[ 1];				// 納品区分					   
	            public byte[]	iracd    = new byte[ 2];				// 依頼者コード				   
	            public byte[]	kyoten   = new byte[ 3];				// 指定拠点					   
	            public byte[]	bin      = new byte[ 1];				// 便      					   
	            public byte[]	rem      = new byte[10];				// リマーク  				   
	            public byte[]	rem2     = new byte[10];				// リマーク２  				   
	            public byte[]	ermsg    = new byte[12];				// エラーメッセージ			   
                public LN_H[] ln_h = new LN_H[ctBufLen];    			// ライン                      
	            public byte[]	tuser_cd = new byte[ 6];				// 端末対応ユーザーコード	   
	            public byte[]	mkmdhms  = new byte[10];				// ﾒｰｶｰ回答問合時刻 MMDDHHMMSS 
	            public byte[]	mkkb     = new byte[ 1];				// ﾒｰｶｰ区分					   
	            public byte[]	dnymdhm  = new byte[12];				// 電文送信時刻   YYYYMMDDHHMM 
	            public byte[]	dummy    = new byte[1191];				// 予備                        

				/// <summary>	
				/// コンストラクター
				/// </summary>
				public DN_H()
				{
					Clear(0x00);
				}

				public void Clear(byte cd)
				{
	                UoeCommonFnc.MemSet(ref jkbn, cd, jkbn.Length);			// 情報区分					   
	                UoeCommonFnc.MemSet(ref seq_no, cd, seq_no.Length);		// テキストシーケンス番号	   
	                UoeCommonFnc.MemSet(ref text_len, cd, text_len.Length);	//				// テキスト長				   
	                UoeCommonFnc.MemSet(ref dkbn, cd, dkbn.Length);			// 電文区分					   
	                UoeCommonFnc.MemSet(ref kekka, cd, kekka.Length);		// 処理結果					   
	                UoeCommonFnc.MemSet(ref tokbn, cd, tokbn.Length);		// 問合せ／応答区分			   
	                UoeCommonFnc.MemSet(ref g_id, cd, g_id.Length);			// 業務ＩＤ					   
	                UoeCommonFnc.MemSet(ref g_pass, cd, g_pass.Length);		// 業務パスワード			   
	                UoeCommonFnc.MemSet(ref prog_ver, cd, prog_ver.Length);	// 端末プログラムバージョン番号
	                UoeCommonFnc.MemSet(ref kkbn, cd, kkbn.Length);			// 継続区分					   
	                UoeCommonFnc.MemSet(ref h_id, cd, h_id.Length);			// 引当ＩＤ					   
	                UoeCommonFnc.MemSet(ref ext, cd, ext.Length);			// 拡張エリア				   
	                UoeCommonFnc.MemSet(ref syori_cd, cd, syori_cd.Length);	// 処理コード				   
	                UoeCommonFnc.MemSet(ref out_ren, cd, out_ren.Length);	// 出力通番					   
	                UoeCommonFnc.MemSet(ref saisou, cd, saisou.Length);		// 再送結果					   
	                UoeCommonFnc.MemSet(ref user_cd, cd, user_cd.Length);	// ユーザーコード			   
	                UoeCommonFnc.MemSet(ref tori_cd, cd, tori_cd.Length);	// 取引先  コード			   
	                UoeCommonFnc.MemSet(ref nhkb, cd, nhkb.Length);			// 納品区分					   
	                UoeCommonFnc.MemSet(ref iracd, cd, iracd.Length);		// 依頼者コード				   
	                UoeCommonFnc.MemSet(ref kyoten, cd, kyoten.Length);		// 指定拠点					   
	                UoeCommonFnc.MemSet(ref bin, cd, bin.Length);			// 便      					   
	                UoeCommonFnc.MemSet(ref rem, cd, rem.Length);			// リマーク  				   
                    UoeCommonFnc.MemSet(ref rem2, cd, rem2.Length);			// リマーク２  				   
	                UoeCommonFnc.MemSet(ref ermsg, cd, ermsg.Length);		// エラーメッセージ			   

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

                    UoeCommonFnc.MemSet(ref tuser_cd, cd, tuser_cd.Length);	// 端末対応ユーザーコード	   
	                UoeCommonFnc.MemSet(ref mkmdhms, cd, mkmdhms.Length);	// ﾒｰｶｰ回答問合時刻 MMDDHHMMSS 
	                UoeCommonFnc.MemSet(ref mkkb, cd, mkkb.Length);			// ﾒｰｶｰ区分					   
	                UoeCommonFnc.MemSet(ref dnymdhm, cd, dnymdhm.Length);	// 電文送信時刻   YYYYMMDDHHMM 
	                UoeCommonFnc.MemSet(ref dummy, cd, dummy.Length);		// 予備                        
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
			public TelegramJnlOrder0202()
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

		            // 受信日付
    				dataRow[OrderSndRcvJnlSchema.ct_Col_ReceiveDate] = DateTime.Now;

		            // 受信時刻
                    dataRow[OrderSndRcvJnlSchema.ct_Col_ReceiveTime] = TDateTime.DateTimeToLongDate("HHMMSS", DateTime.Now);

                    //ヘッダーエラーの格納処理
                    //ヘッダーエラーなし
		            if( dn_h.kekka[0] == 0x00 )
                    {
                    }
                    //ヘッダーエラーあり
                    else
                    {
                        string errMessage = GetHeadErrorMassage(dn_h.kekka[0]);

						//ヘッドエラーメッセージ
						dataRow[OrderSndRcvJnlSchema.ct_Col_HeadErrorMassage] = errMessage;

						//ラインエラーメッセージ
						dataRow[OrderSndRcvJnlSchema.ct_Col_LineErrorMassage] = errMessage;

						//品名
						dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerPartsName] = errMessage;
		            }
#if False
		            /* 納品区分----------------------------------------------------*/
		            uoejla.D6310[0] = dnh.nhkb[0];

		            /* リマーク１--------------------------------------------------*/
		            memcpy( uoejla.PM1590, dnh.rem, sizeof dnh.rem );

		            /* 指定拠点----------------------------------------------------*/
		            memcpy( uoejla.D6334  , dnh.kyoten,sizeof dnh.kyoten);
#endif

                    //代替あり
					if (((dn_h.ln_h[i].knm[0] == 'F') || (dn_h.ln_h[i].knm[0] == 'B'))
			        && ('2' <= dn_h.ln_h[i].knm[1] && dn_h.ln_h[i].knm[1] <= '5')
                    && dn_h.ln_h[i].knm[2] == ' ')
					{
                        //回答品番
                        dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerPartsNo] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].hadt);

                        //代替品番
                        string knmString = UoeCommonFnc.GetRemove(UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].knm), 0, 3);
                        dataRow[OrderSndRcvJnlSchema.ct_Col_SubstPartsNo] = knmString;

                        //回答品名
                        dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerPartsName] = knmString;
					}
                    //代替なし
                    else
					{
                        //回答品番
                        dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerPartsNo] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].hadt);

                        //回答品名
                        dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerPartsName] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].knm);
                    }


#if Fals
                    /* ＢＯ区分					*/
		            uoejla.PM1504[0] = dnh.ln_h[no].bo[0] ;

                    /* 発注数					*/
                    chg_num( dnh.ln_h[no].hasu ,sizeof dnh.ln_h[no].hasu ,&lng,0 );
		            uoejla.PM6201 = (short)lng ;
#endif
                    

                    //拠点 出庫数
					dataRow[OrderSndRcvJnlSchema.ct_Col_UOESectOutGoodsCnt] = UoeCommonFnc.ToInt32FromByteStrAry(dn_h.ln_h[i].kysu);

                    //拠点  納品書ＮＯ
					dataRow[OrderSndRcvJnlSchema.ct_Col_UOESectionSlipNo] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].kydno);

                    /*サブセンター---------------------------------------------------------*/
                    //サブセンター 出庫数
					dataRow[OrderSndRcvJnlSchema.ct_Col_BOShipmentCnt1] = UoeCommonFnc.ToInt32FromByteStrAry(dn_h.ln_h[i].shsu);

                    //サブセンター 納品書ＮＯ
					dataRow[OrderSndRcvJnlSchema.ct_Col_BOSlipNo1] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].shdno);

                    /*メインセンター-------------------------------------------------------*/
                    //メインセンター 出庫数
					dataRow[OrderSndRcvJnlSchema.ct_Col_BOShipmentCnt2] = UoeCommonFnc.ToInt32FromByteStrAry(dn_h.ln_h[i].hosu);

                    //メインセンター 納品書ＮＯ
					dataRow[OrderSndRcvJnlSchema.ct_Col_BOSlipNo2] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].hodno);

                    /*他拠点---------------------------------------------------------------*/
                    //他拠点 出庫数
					dataRow[OrderSndRcvJnlSchema.ct_Col_BOShipmentCnt3] = UoeCommonFnc.ToInt32FromByteStrAry(dn_h.ln_h[i].f3su);

                    //他拠点 納品書ＮＯ
					dataRow[OrderSndRcvJnlSchema.ct_Col_BOSlipNo3] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].f3dno);

                    /*メーカーＢＯ---------------------------------------------------------*/
                    //メーカーＢＯ ﾒｰｶｰB/O数
					dataRow[OrderSndRcvJnlSchema.ct_Col_MakerFollowCnt] = UoeCommonFnc.ToInt32FromByteStrAry(dn_h.ln_h[i].mksu);

                    //メーカーＢＯ Ｂ／Ｏ管理№
					dataRow[OrderSndRcvJnlSchema.ct_Col_BOManagementNo] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].mkdno);

#if False
                    /* 予定納期区分        */
		            uoejla.PM1598[0] = dnh.ln_h[no].nkkb[0];

                    /*納入予定日           */
		            memcpy(&uoejla.PM6338[6]  ,dnh.ln_h[no].ytmd, 4 );
#endif
                    // 定価
                    dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerListPrice] = UoeCommonFnc.ToDoubleFromByteStrAry(dn_h.ln_h[i].teika);

                    // 仕切り単価
                    dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerSalesUnitCost] = UoeCommonFnc.ToDoubleFromByteStrAry(dn_h.ln_h[i].tanka);

                    // 層別
                    dataRow[OrderSndRcvJnlSchema.ct_Col_PartsLayerCd] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].sob);

                    // ラインメッセージ
					dataRow[OrderSndRcvJnlSchema.ct_Col_LineErrorMassage] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].lmsg);

		            if( UoeCommonFnc.MemCmp(dn_h.ln_h[i].eosu, "   ", 3) == 0
		            ||  UoeCommonFnc.MemCmp(dn_h.ln_h[i].eosu, "000", 3) == 0 ){
                        dataRow[OrderSndRcvJnlSchema.ct_Col_EOAlwcCount] = 0;
		            }else{
                        /*ＢＯ管理No.          */
						dataRow[OrderSndRcvJnlSchema.ct_Col_BOManagementNo] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].mkdno);

                        /*ＥＯ引当発注数       */
    					dataRow[OrderSndRcvJnlSchema.ct_Col_EOAlwcCount] = UoeCommonFnc.ToInt32FromByteStrAry(dn_h.ln_h[i].eosu);


		            }
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

                ms.Read(dn_h.jkbn, 0, dn_h.jkbn.Length);		    // 情報区分					   
                ms.Read(dn_h.seq_no, 0, dn_h.seq_no.Length);	    // テキストシーケンス番号	   
                ms.Read(dn_h.text_len, 0, dn_h.text_len.Length);    //				// テキスト長				   
                ms.Read(dn_h.dkbn, 0, dn_h.dkbn.Length);		    // 電文区分					   
                ms.Read(dn_h.kekka, 0, dn_h.kekka.Length);		    // 処理結果					   
                ms.Read(dn_h.tokbn, 0, dn_h.tokbn.Length);		    // 問合せ／応答区分			   
                ms.Read(dn_h.g_id, 0, dn_h.g_id.Length);		    // 業務ＩＤ					   
                ms.Read(dn_h.g_pass, 0, dn_h.g_pass.Length);	    // 業務パスワード			   
                ms.Read(dn_h.prog_ver, 0, dn_h.prog_ver.Length);    // 端末プログラムバージョン番号
                ms.Read(dn_h.kkbn, 0, dn_h.kkbn.Length);		    // 継続区分					   
                ms.Read(dn_h.h_id, 0, dn_h.h_id.Length);		    // 引当ＩＤ					   
                ms.Read(dn_h.ext, 0, dn_h.ext.Length);			    // 拡張エリア				   
                ms.Read(dn_h.syori_cd, 0, dn_h.syori_cd.Length);    // 処理コード				   
                ms.Read(dn_h.out_ren, 0, dn_h.out_ren.Length);	    // 出力通番					   
                ms.Read(dn_h.saisou, 0, dn_h.saisou.Length);	    // 再送結果					   
                ms.Read(dn_h.user_cd, 0, dn_h.user_cd.Length);	    // ユーザーコード			   
                ms.Read(dn_h.tori_cd, 0, dn_h.tori_cd.Length);	    // 取引先  コード			   
                ms.Read(dn_h.nhkb, 0, dn_h.nhkb.Length);		    // 納品区分					   
                ms.Read(dn_h.iracd, 0, dn_h.iracd.Length);		    // 依頼者コード				   
                ms.Read(dn_h.kyoten, 0, dn_h.kyoten.Length);	    // 指定拠点					   
                ms.Read(dn_h.bin, 0, dn_h.bin.Length);			    // 便      					   
                ms.Read(dn_h.rem, 0, dn_h.rem.Length);			    // リマーク  				   
                ms.Read(dn_h.rem2, 0, dn_h.rem2.Length);		    // リマーク２  				   
                ms.Read(dn_h.ermsg, 0, dn_h.ermsg.Length);		    // エラーメッセージ			   

				//明細部
				for (int i = 0; i < ctBufLen; i++)
				{
                    LN_H _ln_h = dn_h.ln_h[i];

	                ms.Read(_ln_h.hadt, 0, _ln_h.hadt.Length);		// 部品番号					   
	                ms.Read(_ln_h.bo, 0, _ln_h.bo.Length);			// Ｂ／Ｏ区分				   
	                ms.Read(_ln_h.knm, 0, _ln_h.knm.Length);		// 品名						   
	                ms.Read(_ln_h.hasu, 0, _ln_h.hasu.Length);		// 発注数量					   
	                ms.Read(_ln_h.bos, 0, _ln_h.bos.Length);		// Ｂ／Ｏｼﾝﾎﾞﾙ				   
	                ms.Read(_ln_h.kysu, 0, _ln_h.kysu.Length);		// 拠点   出庫数               
	                ms.Read(_ln_h.kydno, 0, _ln_h.kydno.Length);	//        納品書ＮＯ		   
	                ms.Read(_ln_h.skzk, 0, _ln_h.skzk.Length);		//        仕掛在庫引当ｼﾝﾎﾞﾙ    
	                ms.Read(_ln_h.skzd, 0, _ln_h.skzd.Length);		//        仕掛在庫引当表示     
	                ms.Read(_ln_h.skzs, 0, _ln_h.skzs.Length);		//        仕掛在庫引当数量     
	                ms.Read(_ln_h.shcd, 0, _ln_h.shcd.Length);		// ＳＳ   拠点ｺｰﾄﾞ			   
	                ms.Read(_ln_h.shsu, 0, _ln_h.shsu.Length);		//        出庫数			   
	                ms.Read(_ln_h.shdno, 0, _ln_h.shdno.Length);	//        納品書ＮＯ		   
	                ms.Read(_ln_h.shzk, 0, _ln_h.shzk.Length);		//        仕掛在庫引当ｼﾝﾎﾞﾙ    
	                ms.Read(_ln_h.hocd, 0, _ln_h.hocd.Length);		// ＭＳ   拠点ｺｰﾄﾞ			   
	                ms.Read(_ln_h.hosu, 0, _ln_h.hosu.Length);		//        出庫数			   
	                ms.Read(_ln_h.hodno, 0, _ln_h.hodno.Length);	//        納品書ＮＯ		   
	                ms.Read(_ln_h.hozk, 0, _ln_h.hozk.Length);		//        仕掛在庫引当ｼﾝﾎﾞﾙ    
	                ms.Read(_ln_h.f3cd, 0, _ln_h.f3cd.Length);		// その他 拠点ｺｰﾄﾞ			   
	                ms.Read(_ln_h.f3su, 0, _ln_h.f3su.Length);		//        出庫数			   
	                ms.Read(_ln_h.f3dno, 0, _ln_h.f3dno.Length);	//        納品書ＮＯ		   

	                ms.Read(_ln_h.hzan, 0, _ln_h.hzan.Length);		// 発注残引当数				   
	                ms.Read(_ln_h.fzan, 0, _ln_h.fzan.Length);		// 不足数      				   
	                ms.Read(_ln_h.eohb, 0, _ln_h.eohb.Length);		// ﾒｰｶｰE/O引当部品番号		   
	                ms.Read(_ln_h.eosu, 0, _ln_h.eosu.Length);		// ﾒｰｶｰE/O引当数      		   
	                ms.Read(_ln_h.mksu, 0, _ln_h.mksu.Length);		// ﾒｰｶｰB/O数        		   
	                ms.Read(_ln_h.nkkb, 0, _ln_h.nkkb.Length);		// 予定納期区分     		   
	                ms.Read(_ln_h.ytmd, 0, _ln_h.ytmd.Length);		// 納入予定日       		   
	                ms.Read(_ln_h.mkdno, 0, _ln_h.mkdno.Length);	// Ｂ／Ｏ管理№				   
	                ms.Read(_ln_h.azaid, 0, _ln_h.azaid.Length);	// 全社在庫表示				   
	                ms.Read(_ln_h.azais, 0, _ln_h.azais.Length);	// 全社在庫数  				   
	                ms.Read(_ln_h.teika, 0, _ln_h.teika.Length);	// 摘要(定価)				   
	                ms.Read(_ln_h.tanka, 0, _ln_h.tanka.Length);	// 仕切価格					   
	                ms.Read(_ln_h.sob, 0, _ln_h.sob.Length);		// 部品層別					   
	                ms.Read(_ln_h.lmsg, 0, _ln_h.lmsg.Length);		// ﾗｲﾝﾒｯｾｰｼﾞ				   

	                ms.Read(_ln_h.bomsg, 0, _ln_h.bomsg.Length);	// （結果）Ｂ／Ｏﾒｯｾｰｼﾞ区分	   
	                ms.Read(_ln_h.bosu, 0, _ln_h.bosu.Length);		// （結果）Ｂ／Ｏ数            
	                ms.Read(_ln_h.sinb, 0, _ln_h.sinb.Length);		// ２世代前シンボル            
				}

                ms.Read(dn_h.tuser_cd, 0, dn_h.tuser_cd.Length);    // 端末対応ユーザーコード	   
                ms.Read(dn_h.mkmdhms, 0, dn_h.mkmdhms.Length);	    // ﾒｰｶｰ回答問合時刻 MMDDHHMMSS 
                ms.Read(dn_h.mkkb, 0, dn_h.mkkb.Length);		    // ﾒｰｶｰ区分					   
                ms.Read(dn_h.dnymdhm, 0, dn_h.dnymdhm.Length);	    // 電文送信時刻   YYYYMMDDHHMM 
                ms.Read(dn_h.dummy, 0, dn_h.dummy.Length);		    // 予備                        

				ms.Close();
			}
			# endregion


			# endregion
		}
		# endregion
		# endregion


	}
}

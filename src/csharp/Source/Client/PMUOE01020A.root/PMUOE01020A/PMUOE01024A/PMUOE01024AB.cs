//****************************************************************************//
// 僔僗僥儉         : PM.NS僔儕乕僘
// 僾儘僌儔儉柤徧   : 倀俷俤庴怣曇廤亙敪拲亜乮媽儅僣僟乯傾僋僙僗僋儔僗
// 僾儘僌儔儉奣梫   : 倀俷俤庴怣曇廤亙敪拲亜乮媽儅僣僟乯傪峴偆
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 棜楌
//----------------------------------------------------------------------------//
// 娗棟斣崋  10402071-00 嶌惉扴摉 : 棫壴 桾曘
// 嶌 惉 擔  2008/05/26  廋惓撪梕 : 怴婯嶌惉
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
	/// 倀俷俤庴怣曇廤亙敪拲亜乮媽儅僣僟乯傾僋僙僗僋儔僗
	/// </summary>
	/// <remarks>
	/// <br>Note       : 倀俷俤庴怣曇廤乮媽儅僣僟乯傾僋僙僗僋儔僗</br>
	/// <br>Programmer : 96186 棫壴桾曘</br>
	/// <br>Date       : 2008.05.26</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// <br>2008.05.26 men 怴婯嶌惉</br>
	/// </remarks>
	public partial class UoeRecEdit0401Acs
	{
		// ===================================================================================== //
		// 僾儔僀儀乕僩儊僜僢僪
		// ===================================================================================== //
		# region Private Methods

		# region 倀俷俤庴怣曇廤亙敪拲亜乮媽儅僣僟乯
		/// <summary>
		/// 倀俷俤庴怣曇廤亙敪拲亜乮媽儅僣僟乯
		/// </summary>
        /// <param name="message">僄儔乕儊僢僙乕僕</param>
        /// <returns>僗僥乕僞僗</returns>
        private int GetJnlOrder0401(out string message)
		{
			//曄悢偺弶婜壔
			int status = (int)EnumUoeConst.Status.ct_NORMAL;
			message = "";

            try
			{
                //-----------------------------------------------------------
                // 俰俶俴峏怴張棟
                //-----------------------------------------------------------
                if (uoeRecHed != null)
                {
                    TelegramJnlOrder0401 telegramJnlOrder0401 = new TelegramJnlOrder0401();

                    //俰俶俴峏怴張棟
                    foreach (UoeRecDtl dtl in uoeRecDtlList)
                    {
                        telegramJnlOrder0401.Telegram(_uoeRecHed.UOESupplierCd, dtl);
                    }
                }

                //-----------------------------------------------------------
                // 憲庴怣俰俶俴亙憲怣僼儔僌丒暅媽僼儔僌亜偺峏怴
                //   憲怣僼儔僌 (峏怴慜)1:張棟拞 仺 (峏怴屻)2:憲怣僄儔乕
                //   暅媽僼儔僌 (峏怴慜)0:枹張棟 仺 (峏怴屻)1:暅媽懳徾
                //-----------------------------------------------------------
                _uoeSndRcvJnlAcs.JnlOrderTblFlgUpdt(_uoeSndHed.UOESupplierCd,
                    (int)EnumUoeConst.ctDataSendCode.ct_Process,		//1:張棟拞
                    (int)EnumUoeConst.ctDataRecoverDiv.ct_NonProcess,	//0:枹張棟
                    (int)EnumUoeConst.ctDataSendCode.ct_SndNG,			//2:憲怣僄儔乕
                    (int)EnumUoeConst.ctDataRecoverDiv.ct_YES);			//9:暅媽懳徾
            }
			catch (Exception ex)
			{
				status = -1;
				message = ex.Message;
			}
			return (status);
		}
		# endregion

		# region 倀俷俤庴怣揹暥嶌惉亙敪拲亜乮媽儅僣僟乯
		/// <summary>
		/// 倀俷俤庴怣揹暥嶌惉亙敪拲亜乮媽儅僣僟乯
		/// </summary>
		public class TelegramJnlOrder0401 : UoeRecEdit0401Acs
		{
			# region 俹俵俈僜乕僗
			///********************** 夞摎庴怣揹暥 嫟捠晹 峔憿懱 **********************/
			//typedef struct	{
			//	char	jkbn[1] ;					/* 忣曬嬫暘						*/
			//	short	seq_no ;					/* 僥僉僗僩僔乕働儞僗斣崋		*/
			//	short	text_len ;					/* 僥僉僗僩挿					*/
			//	char	dkbn[1] ;					/* 揹暥嬫暘						*/
			//	char	kekka[1] ;					/* 張棟寢壥						*/
			//	char	tokbn[1] ;					/* 栤崌偣乛墳摎嬫暘				*/
			//	char	g_id[12] ;					/* 嬈柋俬俢						*/
			//	char	g_pass[6] ;					/* 嬈柋僷僗儚乕僪				*/
			//	char	prog_ver[3] ;				/* 抂枛僾儘僌儔儉僶乕僕儑儞斣崋	*/
			//	char	kkbn[1] ;					/* 宲懕嬫暘						*/
			//	char	h_id[3] ;					/* 庢堷俬俢						*/
			//	char	ext[15] ;					/* 奼挘僄儕傾					*/
			//	char	gsk[1] ;					/* 嬈柋張棟寢壥					*/
			//	char	gsf[1] ;					/* 嬈柋宲懕僼儔僌				*/
			//	char	seq[3] ;					/* 僔乕働儞僗俶俷				*/
			//	char	bymd[4] ;					/* 抂枛擖椡擔晅丒帪娫			*/
			//	char	ymdhms[8] ;					/* 儂僗僩擔晅丒帪娫				*/
			//} HEAD ;
			//
			///************************ 敪拲夞摎庴怣揹暥峔憿懱 ************************/
			//typedef struct	{
			//	char	khb[24] ;					/* 昳斣							*/
			//	char	hasu[5] ;					/* 拲暥悢						*/
			//	char	bo[1] ;						/* 俛俷嬫暘						*/
			//	char	sktan[7] ;					/* 巇愗傝扨壙					*/
			//	char	teika[7] ;					/* 婓朷彫攧壙奿					*/
			//	char	knm[20] ;					/* 晹昳柤						*/
			//	char	mksu[5] ;					/* 俛俷悢						*/
			//	char	kydno[7] ;					/* 嫆揰揱昜俶俷					*/
			//	char	shdno[7] ;					/* 巟揦揱昜俶俷					*/
			//	char	hodno[7] ;					/* 杮幮揱昜俶俷					*/
			//	char	kysu[5] ;					/* 嫆揰弌壸悢					*/
			//	char	shsu[5] ;					/* 巟揦弌壸悢					*/
			//	char	hosu[5] ;					/* 杮幮弌壸悢					*/
			//	char	bhb[24] ;					/* 晹昳斣崋乮拲暥乯				*/
			//	char	gokan[2] ;					/* 屳姺惈僐乕僪					*/
			//	char	ermsg[15] ;					/* 僐儊儞僩						*/
			//	char	l_ext[3] ;					/* 儔僀儞奼挘僄儕傾				*/
			//} HDATA ;
			//
			//typedef struct	{
			//	HEAD	head ;
			//	char	nhkb[1] ;					/* 擺昳嬫暘						*/
			//	char	rem1[10] ;					/* 儕儅乕僋						*/
			//	char	kyoten[2] ;					/* 巜掕嫆揰						*/
			//	char	head_ext[20] ;				/* 僿僢僪奼挘僄儕傾				*/
			//	HDATA	hdata[6] ;					/* 儔僀儞崁栚侾乣俇				*/
			//} HATYU ;
			//
			///********************** 敪拲僿僢僪僄儔乕揹暥峔憿懱 **********************/
			//typedef struct	{
			//	HEAD	head ;
			//	char	nhkb[1] ;					/* 擺昳嬫暘						*/
			//	char	rem1[10] ;					/* 儕儅乕僋						*/
			//	char	kyoten[2] ;					/* 巜掕嫆揰						*/
			//	char	head_ext[20] ;				/* 僿僢僪奼挘僄儕傾				*/
			//	char	ermsg[20] ;					/* 僄儔乕儊僢僙乕僕				*/
			//	char	khb[24] ;					/* 晹斣							*/
			//	char	hasu[5] ;					/* 拲暥悢						*/
			//	char	bo[1] ;						/* 俛俷嬫暘						*/
			//} HERR ;
			# endregion

			# region Const Members
			private const Int32 ctBufLen = 6;		//柧嵶僶僢僼傽僒僀僘
			# endregion

			# region 揹暥椞堟僋儔僗
			/// <summary>
			/// 僄儔乕揹暥椞堟亙儔僀儞亜
			/// </summary>
			private class ER_H
			{
				public byte[] ermsg = new byte[20];		// 僄儔乕儊僢僙乕僕				
				public byte[] khb = new byte[24];		// 晹斣							
				public byte[] hasu = new byte[5];		// 拲暥悢						
				public byte[] bo = new byte[1];			// 俛俷嬫暘						
	
				public ER_H()
				{
					Clear(0x00);
				}
				public void Clear(byte cd)
				{
					UoeCommonFnc.MemSet(ref ermsg, cd, ermsg.Length);		// 僄儔乕儊僢僙乕僕				
					UoeCommonFnc.MemSet(ref khb, cd, khb.Length);			// 晹斣							
					UoeCommonFnc.MemSet(ref hasu, cd, hasu.Length);			// 拲暥悢						
					UoeCommonFnc.MemSet(ref bo, cd, bo.Length);				// 俛俷嬫暘						
				}
			}
	
			/// <summary>
			/// 敪拲揹暥椞堟亙儔僀儞亜
			/// </summary>
			private class LN_H
			{
				public byte[] khb = new byte[24];		// 昳斣							
				public byte[] hasu = new byte[5];		// 拲暥悢						
				public byte[] bo = new byte[1];			// 俛俷嬫暘						
				public byte[] sktan = new byte[7];		// 巇愗傝扨壙					
				public byte[] teika = new byte[7];		// 婓朷彫攧壙奿					
				public byte[] knm = new byte[20];		// 晹昳柤						
				public byte[] mksu = new byte[5];		// 俛俷悢						
				public byte[] kydno = new byte[7];		// 嫆揰揱昜俶俷					
				public byte[] shdno = new byte[7];		// 巟揦揱昜俶俷					
				public byte[] hodno = new byte[7];		// 杮幮揱昜俶俷					
				public byte[] kysu = new byte[5];		// 嫆揰弌壸悢					
				public byte[] shsu = new byte[5];		// 巟揦弌壸悢					
				public byte[] hosu = new byte[5];		// 杮幮弌壸悢					
				public byte[] bhb = new byte[24];		// 晹昳斣崋乮拲暥乯				
				public byte[] gokan = new byte[2];		// 屳姺惈僐乕僪					
				public byte[] ermsg = new byte[15];		// 僐儊儞僩						
				public byte[] l_ext = new byte[3];		// 儔僀儞奼挘僄儕傾				

				public LN_H()
				{
					Clear(0x00);
				}
				public void Clear(byte cd)
				{
					UoeCommonFnc.MemSet(ref khb, cd, khb.Length);			// 昳斣							
					UoeCommonFnc.MemSet(ref hasu, cd, hasu.Length);			// 拲暥悢						
					UoeCommonFnc.MemSet(ref bo, cd, bo.Length);				// 俛俷嬫暘						
					UoeCommonFnc.MemSet(ref sktan, cd, sktan.Length);		// 巇愗傝扨壙					
					UoeCommonFnc.MemSet(ref teika, cd, teika.Length);		// 婓朷彫攧壙奿					
					UoeCommonFnc.MemSet(ref knm, cd, knm.Length);			// 晹昳柤						
					UoeCommonFnc.MemSet(ref mksu, cd, mksu.Length);			// 俛俷悢						
					UoeCommonFnc.MemSet(ref kydno, cd, kydno.Length);		// 嫆揰揱昜俶俷					
					UoeCommonFnc.MemSet(ref shdno, cd, shdno.Length);		// 巟揦揱昜俶俷					
					UoeCommonFnc.MemSet(ref hodno, cd, hodno.Length);		// 杮幮揱昜俶俷					
					UoeCommonFnc.MemSet(ref kysu, cd, kysu.Length);			// 嫆揰弌壸悢					
					UoeCommonFnc.MemSet(ref shsu, cd, shsu.Length);			// 巟揦弌壸悢					
					UoeCommonFnc.MemSet(ref hosu, cd, hosu.Length);			// 杮幮弌壸悢					
					UoeCommonFnc.MemSet(ref bhb, cd, bhb.Length);			// 晹昳斣崋乮拲暥乯				
					UoeCommonFnc.MemSet(ref gokan, cd, gokan.Length);		// 屳姺惈僐乕僪					
					UoeCommonFnc.MemSet(ref ermsg, cd, ermsg.Length);		// 僐儊儞僩						
					UoeCommonFnc.MemSet(ref l_ext, cd, l_ext.Length);		// 儔僀儞奼挘僄儕傾				
				}
			}

			/// <summary>
			/// 敪拲揹暥椞堟亙杮懱亜
			/// </summary>
			private class DN_H
			{
				public byte[] jkbn = new byte[1];		// 忣曬嬫暘						
				public byte[] seq_no = new byte[2];		// 僥僉僗僩僔乕働儞僗斣崋		
				public byte[] text_len = new byte[2];	// 僥僉僗僩挿					
				public byte[] dkbn = new byte[1];		// 揹暥嬫暘						
				public byte[] kekka = new byte[1];		// 張棟寢壥						
				public byte[] tokbn = new byte[1];		// 栤崌偣乛墳摎嬫暘				
				public byte[] g_id = new byte[12];		// 嬈柋俬俢						
				public byte[] g_pass = new byte[6];		// 嬈柋僷僗儚乕僪				
				public byte[] prog_ver = new byte[3];	// 抂枛僾儘僌儔儉僶乕僕儑儞斣崋	
				public byte[] kkbn = new byte[1];		// 宲懕嬫暘						
				public byte[] h_id = new byte[3];		// 庢堷俬俢						
				public byte[] ext = new byte[15];		// 奼挘僄儕傾					
				public byte[] gsk = new byte[1];		// 嬈柋張棟寢壥					
				public byte[] gsf = new byte[1];		// 嬈柋宲懕僼儔僌				
				public byte[] seq = new byte[3];		// 僔乕働儞僗俶俷				
				public byte[] bymd = new byte[4];		// 抂枛擖椡擔晅丒帪娫			
				public byte[] ymdhms = new byte[8];		// 儂僗僩擔晅丒帪娫				

				public byte[] nhkb = new byte[1];		// 擺昳嬫暘						
				public byte[] rem1 = new byte[10];		// 儕儅乕僋						
				public byte[] kyoten = new byte[2];		// 巜掕嫆揰						
				public byte[] head_ext = new byte[20];	// 僿僢僪奼挘僄儕傾				

				public LN_H[] ln_h = new LN_H[ctBufLen];// 柧嵶

				public ER_H er_h = new ER_H();			// 僄儔乕

				/// <summary>	
				/// 僐儞僗僩儔僋僞乕
				/// </summary>
				public DN_H()
				{
					Clear(0x00);
				}

				public void Clear(byte cd)
				{
					UoeCommonFnc.MemSet(ref jkbn, cd, jkbn.Length);			// 忣曬嬫暘						
					UoeCommonFnc.MemSet(ref seq_no, cd, seq_no.Length);		// 僥僉僗僩僔乕働儞僗斣崋		
					UoeCommonFnc.MemSet(ref text_len, cd, text_len.Length);	// 僥僉僗僩挿					
					UoeCommonFnc.MemSet(ref dkbn, cd, dkbn.Length);			// 揹暥嬫暘						
					UoeCommonFnc.MemSet(ref kekka, cd, kekka.Length);		// 張棟寢壥						
					UoeCommonFnc.MemSet(ref tokbn, cd, tokbn.Length);		// 栤崌偣乛墳摎嬫暘				
					UoeCommonFnc.MemSet(ref g_id, cd, g_id.Length);			// 嬈柋俬俢						
					UoeCommonFnc.MemSet(ref g_pass, cd, g_pass.Length);		// 嬈柋僷僗儚乕僪				
					UoeCommonFnc.MemSet(ref prog_ver, cd, prog_ver.Length);	// 抂枛僾儘僌儔儉僶乕僕儑儞斣崋	
					UoeCommonFnc.MemSet(ref kkbn, cd, kkbn.Length);			// 宲懕嬫暘						
					UoeCommonFnc.MemSet(ref h_id, cd, h_id.Length);			// 庢堷俬俢						
					UoeCommonFnc.MemSet(ref ext, cd, ext.Length);			// 奼挘僄儕傾					
					UoeCommonFnc.MemSet(ref gsk, cd, gsk.Length);			// 嬈柋張棟寢壥					
					UoeCommonFnc.MemSet(ref gsf, cd, gsf.Length);			// 嬈柋宲懕僼儔僌				
					UoeCommonFnc.MemSet(ref seq, cd, seq.Length);			// 僔乕働儞僗俶俷				
					UoeCommonFnc.MemSet(ref bymd, cd, bymd.Length);			// 抂枛擖椡擔晅丒帪娫			
					UoeCommonFnc.MemSet(ref ymdhms, cd, ymdhms.Length);		// 儂僗僩擔晅丒帪娫				

					UoeCommonFnc.MemSet(ref nhkb, cd, nhkb.Length);			// 擺昳嬫暘						
					UoeCommonFnc.MemSet(ref rem1, cd, rem1.Length);			// 儕儅乕僋						
					UoeCommonFnc.MemSet(ref kyoten, cd, kyoten.Length);		// 巜掕嫆揰						
					UoeCommonFnc.MemSet(ref head_ext, cd, head_ext.Length);	// 僿僢僪奼挘僄儕傾				

					//柧嵶晹
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

					//僄儔乕晹
					er_h.Clear(0x00);
				}
			}

			# endregion

			# region Private Members
			//曄悢
			private Int32 _detailMax = 0;
			private DN_H dn_h = new DN_H(); 
			# endregion

			# region Constructors
			/// <summary>
			/// 僐儞僗僩儔僋僞
			/// </summary>
			public TelegramJnlOrder0401()
			{
				Clear(0x00);
			}
			# endregion

			# region Properties
			# region 柧嵶峴悢
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

			# region 僄儔乕晹
			/// <summary>
			/// 僄儔乕晹
			/// </summary>
			private ER_H Er_h
			{
				get
				{
					return dn_h.er_h;
				}
				set
				{
					this.dn_h.er_h = value;
				}
			}
			# endregion

			# region 柧嵶晹
			/// <summary>
			/// 柧嵶晹
			/// </summary>
			private LN_H[] Ln_h
			{
				get
				{
					return dn_h.ln_h;
				}
				set
				{
					this.dn_h.ln_h = value;
				}
			}
			# endregion

			# endregion

			# region Public Methods
			# region 僨乕僞弶婜壔張棟
			/// <summary>
			/// 僨乕僞弶婜壔張棟
			/// </summary>
			public void Clear(byte cd)
			{
				_detailMax = 0;

				dn_h.Clear(0x00);
			}
			# endregion

			# region 僨乕僞曇廤張棟
			/// <summary>
			/// 僨乕僞曇廤張棟
			/// </summary>
			/// <param name="dtl"></param>
			/// <param name="jnl"></param>
			public void Telegram(Int32 uOESupplierCd, UoeRecDtl dtl)
			{
                //奐嬊丒暵嬊揹暥偺僗僉僢僾張棟
                if ((dtl.UOESalesOrderNo == 0) && (dtl.UOESalesOrderRowNo.Count == 0)) return;

                //僶僀僩宆攝楍偵曄姺
				FromByteArray(dtl.RecTelegram);

				//揹暥偺峴悢庢摼
				_detailMax = dtl.UOESalesOrderRowNo.Count;

				for (int i = 0; i < _detailMax; i++)
				{
					//庢摼亙憲庴怣JNL-DATATABLE仺憲庴怣JNL-CLASS亜
					DataRow dataRow = _uoeSndRcvJnlAcs.JnlOrderTblRead(
													uOESupplierCd,
													dtl.UOESalesOrderNo,
													dtl.UOESalesOrderRowNo[i]);
					if (dataRow == null)
					{
						continue;
					}

					//僨乕僞憲怣嬫暘
                    dataRow[OrderSndRcvJnlSchema.ct_Col_DataSendCode] = dtl.DataSendCode;

					//僨乕僞暅媽嬫暘
					dataRow[OrderSndRcvJnlSchema.ct_Col_DataRecoverDiv] = dtl.DataRecoverDiv;

					//庴怣擔晅(YYYYMMDD)
					int int32Yymmdd = UoeCommonFnc.atobs(dn_h.ymdhms, 0, 4) * 100;

					//揹暥帺懱偵偵擔晅偑僙僢僩偝傟偰偄傞
					if (int32Yymmdd != 0)
					{
						int lwk = TDateTime.DateTimeToLongDate(DateTime.Now);		//yyyymmdd
						lwk /= 1000000;	// yy
						lwk *= 1000000;	// yy000000

						dataRow[OrderSndRcvJnlSchema.ct_Col_ReceiveDate] = TDateTime.LongDateToDateTime(int32Yymmdd + lwk);
					}
					//揹暥帺懱偵偵擔晅偑僙僢僩偝傟偰偄側偄
					else
					{
						dataRow[OrderSndRcvJnlSchema.ct_Col_ReceiveDate] = DateTime.Now;
					}

					//庴怣帪崗(HHMM)
					dataRow[OrderSndRcvJnlSchema.ct_Col_ReceiveTime] = UoeCommonFnc.atobs(dn_h.ymdhms, 4, 4) * 100;

					/* 夞摎揹暥僄儔乕僠僃僢僋	*/
					if ( ( dn_h.kekka[0] != 0x00 )
					||	 ( dn_h.gsk[0] != 0x00 ) )
					{
						string errMessage = "";

						if (dn_h.gsk[0] == 0x01)
						{
							errMessage = UoeCommonFnc.ToStringFromByteStrAry(dn_h.er_h.ermsg);
						}
						else
						{
							errMessage = GetHeadErrorMassage(dn_h.kekka[0]);
						}
						//僿僢僪僄儔乕儊僢僙乕僕
						dataRow[OrderSndRcvJnlSchema.ct_Col_HeadErrorMassage] = errMessage;

						//昳柤
						dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerPartsName] = errMessage;
						
						continue;
					}
					
					// 擺昳嬫暘
                    dataRow[OrderSndRcvJnlSchema.ct_Col_UOEDeliGoodsDiv] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.nhkb);
					
					// 儕儅乕僋
					dataRow[OrderSndRcvJnlSchema.ct_Col_UoeRemark1] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.rem1);

					// 巜掕嫆揰
					dataRow[OrderSndRcvJnlSchema.ct_Col_UOEResvdSection] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.kyoten);

					//戙懼桳柍僠僃僢僋仌僙僢僩
					//戙懼側偟
					if ((dn_h.ln_h[i].gokan[0] == 0x00)
					|| (dn_h.ln_h[i].gokan[0] == 0x20)
					|| (dn_h.ln_h[i].gokan[0] == 0x30))
					{
						//夞摎昳斣
						dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerPartsNo] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].khb);

						//夞摎昳柤
						dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerPartsName] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].knm);
					}
					//戙懼偁傝
					else
					{
						//戙懼嬫暘
						dataRow[OrderSndRcvJnlSchema.ct_Col_UOESubstMark] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].gokan);

						//戙懼昳斣
						dataRow[OrderSndRcvJnlSchema.ct_Col_SubstPartsNo] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].khb);

						//夞摎昳斣
						dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerPartsNo] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].bhb);

						//夞摎昳柤
						dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerPartsName] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].knm);
					}

					//悢検(拲暥悢)
					dataRow[OrderSndRcvJnlSchema.ct_Col_AcceptAnOrderCnt] = UoeCommonFnc.ToDoubleFromByteStrAry(dn_h.ln_h[i].hasu);

					//BO嬫暘
					dataRow[OrderSndRcvJnlSchema.ct_Col_BoCode] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].bo);

					//尨壙扨壙乮巇愗傝扨壙乯
                    dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerSalesUnitCost] = UoeCommonFnc.ToDoubleFromByteStrAry(dn_h.ln_h[i].sktan);

					//揔梡乮掕壙乯 俴乛俹
                    dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerListPrice] = UoeCommonFnc.ToDoubleFromByteStrAry(dn_h.ln_h[i].teika);

					//儊乕僇乕僼僅儘乕悢
					dataRow[OrderSndRcvJnlSchema.ct_Col_MakerFollowCnt] = UoeCommonFnc.ToInt32FromByteStrAry(dn_h.ln_h[i].mksu);

					//UOE嫆揰揱昜斣崋
					dataRow[OrderSndRcvJnlSchema.ct_Col_UOESectionSlipNo] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].kydno);

					//BO揱昜斣崋侾(僒僽杮晹僼僅儘乕揱昜俶俷)
					dataRow[OrderSndRcvJnlSchema.ct_Col_BOSlipNo1] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].shdno);

					//BO揱昜斣崋俀(杮晹僼僅儘乕揱昜俶俷)
					dataRow[OrderSndRcvJnlSchema.ct_Col_BOSlipNo2] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].hodno);

					//UOE嫆揰弌屔悢
					dataRow[OrderSndRcvJnlSchema.ct_Col_UOESectOutGoodsCnt] = UoeCommonFnc.ToInt32FromByteStrAry(dn_h.ln_h[i].kysu);

					//BO弌屔悢1(僒僽杮晹僼僅儘乕悢)
					dataRow[OrderSndRcvJnlSchema.ct_Col_BOShipmentCnt1] =  UoeCommonFnc.ToInt32FromByteStrAry(dn_h.ln_h[i].shsu);
					
					//BO弌屔悢1(杮晹僼僅儘乕悢)
					dataRow[OrderSndRcvJnlSchema.ct_Col_BOShipmentCnt2] = UoeCommonFnc.ToInt32FromByteStrAry(dn_h.ln_h[i].hosu);

					//僐儊儞僩(儔僀儞僄儔乕儊僢僙乕僕)
					dataRow[OrderSndRcvJnlSchema.ct_Col_LineErrorMassage] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].ermsg);
				}
			}
			# endregion

			# endregion

			# region private Methods

			# region 僶僀僩宆攝楍偵曄姺
			/// <summary>
			/// 僶僀僩宆攝楍偵曄姺
			/// </summary>
			/// <returns></returns>
			private void FromByteArray(byte[] line)
			{
				_detailMax = 0;
				MemoryStream ms = new MemoryStream();
				ms.Write(line, 0, line.Length);
                ms.Seek(0, SeekOrigin.Begin);

				//僿僢僟乕晹
				ms.Read(dn_h.jkbn, 0, dn_h.jkbn.Length);            // 忣曬嬫暘						
				ms.Read(dn_h.seq_no, 0, dn_h.seq_no.Length);        // 僥僉僗僩僔乕働儞僗斣崋		
				ms.Read(dn_h.text_len, 0, dn_h.text_len.Length);    // 僥僉僗僩挿					
				ms.Read(dn_h.dkbn, 0, dn_h.dkbn.Length);            // 揹暥嬫暘						
				ms.Read(dn_h.kekka, 0, dn_h.kekka.Length);          // 張棟寢壥						
				ms.Read(dn_h.tokbn, 0, dn_h.tokbn.Length);          // 栤崌偣乛墳摎嬫暘				
				ms.Read(dn_h.g_id, 0, dn_h.g_id.Length);            // 嬈柋俬俢						
				ms.Read(dn_h.g_pass, 0, dn_h.g_pass.Length);        // 嬈柋僷僗儚乕僪				
				ms.Read(dn_h.prog_ver, 0, dn_h.prog_ver.Length);    // 抂枛僾儘僌儔儉僶乕僕儑儞斣崋	
				ms.Read(dn_h.kkbn, 0, dn_h.kkbn.Length);            // 宲懕嬫暘						
				ms.Read(dn_h.h_id, 0, dn_h.h_id.Length);            // 庢堷俬俢						
				ms.Read(dn_h.ext, 0, dn_h.ext.Length);              // 奼挘僄儕傾					
				ms.Read(dn_h.gsk, 0, dn_h.gsk.Length);              // 嬈柋張棟寢壥					
				ms.Read(dn_h.gsf, 0, dn_h.gsf.Length);              // 嬈柋宲懕僼儔僌				
				ms.Read(dn_h.seq, 0, dn_h.seq.Length);              // 僔乕働儞僗俶俷				
				ms.Read(dn_h.bymd, 0, dn_h.bymd.Length);            // 抂枛擖椡擔晅丒帪娫			
				ms.Read(dn_h.ymdhms, 0, dn_h.ymdhms.Length);        // 儂僗僩擔晅丒帪娫				

				ms.Read(dn_h.nhkb, 0, dn_h.nhkb.Length);            // 擺昳嬫暘						
				ms.Read(dn_h.rem1, 0, dn_h.rem1.Length);            // 儕儅乕僋						
				ms.Read(dn_h.kyoten, 0, dn_h.kyoten.Length);        // 巜掕嫆揰						
				ms.Read(dn_h.head_ext, 0, dn_h.head_ext.Length);    // 僿僢僪奼挘僄儕傾				

				//僄儔乕晹
				if((dn_h.kekka[0] != 0x00)
				|| (dn_h.gsk[0] != 0x00))
				{
					ms.Read(Er_h.ermsg, 0, Er_h.ermsg.Length);      // 僄儔乕儊僢僙乕僕				
					ms.Read(Er_h.khb, 0, Er_h.khb.Length);          // 晹斣							
					ms.Read(Er_h.hasu, 0, Er_h.hasu.Length);        // 拲暥悢						
					ms.Read(Er_h.bo, 0, Er_h.bo.Length);            // 俛俷嬫暘						
				}
				//柧嵶晹
				else
				{
					for (int i = 0; i < ctBufLen; i++)
					{
						ms.Read(Ln_h[i].khb, 0, Ln_h[i].khb.Length); // 昳斣							
						ms.Read(Ln_h[i].hasu, 0, Ln_h[i].hasu.Length); // 拲暥悢						
						ms.Read(Ln_h[i].bo, 0, Ln_h[i].bo.Length); // 俛俷嬫暘						
						ms.Read(Ln_h[i].sktan, 0, Ln_h[i].sktan.Length); // 巇愗傝扨壙					
						ms.Read(Ln_h[i].teika, 0, Ln_h[i].teika.Length); // 婓朷彫攧壙奿					
						ms.Read(Ln_h[i].knm, 0, Ln_h[i].knm.Length); // 晹昳柤						
						ms.Read(Ln_h[i].mksu, 0, Ln_h[i].mksu.Length); // 俛俷悢						
						ms.Read(Ln_h[i].kydno, 0, Ln_h[i].kydno.Length); // 嫆揰揱昜俶俷					
						ms.Read(Ln_h[i].shdno, 0, Ln_h[i].shdno.Length); // 巟揦揱昜俶俷					
						ms.Read(Ln_h[i].hodno, 0, Ln_h[i].hodno.Length); // 杮幮揱昜俶俷					
						ms.Read(Ln_h[i].kysu, 0, Ln_h[i].kysu.Length); // 嫆揰弌壸悢					
						ms.Read(Ln_h[i].shsu, 0, Ln_h[i].shsu.Length); // 巟揦弌壸悢					
						ms.Read(Ln_h[i].hosu, 0, Ln_h[i].hosu.Length); // 杮幮弌壸悢					
						ms.Read(Ln_h[i].bhb, 0, Ln_h[i].bhb.Length); // 晹昳斣崋乮拲暥乯				
						ms.Read(Ln_h[i].gokan, 0, Ln_h[i].gokan.Length); // 屳姺惈僐乕僪					
						ms.Read(Ln_h[i].ermsg, 0, Ln_h[i].ermsg.Length); // 僐儊儞僩						
						ms.Read(Ln_h[i].l_ext, 0, Ln_h[i].l_ext.Length); 
					}
				}
				ms.Close();
			}
			# endregion

			# region 僿僢僪僄儔乕儊僢僙乕僕偺庢摼
			/// <summary>
			/// 僿僢僪僄儔乕儊僢僙乕僕偺庢摼
			/// </summary>
			/// <param name="cd"></param>
			/// <returns></returns>
			private string GetHeadErrorMassage(byte cd)
			{
				string str = "";

				switch (cd)
				{
					case 0x88:						//-- "嫁遁掇泊装" --
						str = MSG_RUS;
						break;
					case 0x99:						//-- "可来装" --
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

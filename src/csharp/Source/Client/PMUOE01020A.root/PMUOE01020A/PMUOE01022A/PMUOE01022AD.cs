//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �t�n�d��M�ҏW���݌Ɂ��i���Y�m�p�[�c�j�A�N�Z�X�N���X
// �v���O�����T�v   : �t�n�d��M�ҏW���݌Ɂ��i���Y�m�p�[�c�j���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10402071-00 �쐬�S�� : ���� �T��
// �� �� ��  2008/05/26  �C�����e : �V�K�쐬
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
	/// �t�n�d��M�ҏW���݌Ɂ��i���Y�m�p�[�c�j�A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �t�n�d��M�ҏW���݌Ɂ��i���Y�m�p�[�c�j�A�N�Z�X�N���X</br>
	/// <br>Programmer : 96186 ���ԗT��</br>
	/// <br>Date       : 2008.05.26</br>
	/// <br></br>
	/// <br>UpDate</br>
	/// <br>2008.05.26 men �V�K�쐬</br>
	/// </remarks>
	public partial class UoeRecEdit0202Acs
	{
		// ===================================================================================== //
		// �v���C�x�[�g���\�b�h
		// ===================================================================================== //
		# region Private Methods

		# region �t�n�d��M�ҏW���݌Ɂ��i���Y�m�p�[�c�j
		/// <summary>
		/// �t�n�d��M�ҏW���݌Ɂ��i���Y�m�p�[�c�j
		/// </summary>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        private int GetJnlStock0202(out string message)
		{
			//�ϐ��̏�����
			int status = (int)EnumUoeConst.Status.ct_NORMAL;
			message = "";

			try
			{
                //-----------------------------------------------------------
                // �i�m�k�X�V����
                //-----------------------------------------------------------
                if (uoeRecHed != null)
                {
                    TelegramJnlStock0202 telegramJnlStock0202 = new TelegramJnlStock0202();

                    //�i�m�k�X�V����
                    foreach (UoeRecDtl dtl in uoeRecDtlList)
                    {
                        telegramJnlStock0202.Telegram(_uoeRecHed.UOESupplierCd, dtl);
                    }
                }

                //-----------------------------------------------------------
                // ����M�i�m�k�����M�t���O�E�����t���O���̍X�V
                //   ���M�t���O (�X�V�O)1:������ �� (�X�V��)2:���M�G���[
                //   �����t���O (�X�V�O)0:������ �� (�X�V��)1:�����Ώ�
                //-----------------------------------------------------------
                _uoeSndRcvJnlAcs.JnlOrderTblFlgUpdt(_uoeSndHed.UOESupplierCd,
                    (int)EnumUoeConst.ctDataSendCode.ct_Process,		//1:������
                    (int)EnumUoeConst.ctDataRecoverDiv.ct_NonProcess,	//0:������
                    (int)EnumUoeConst.ctDataSendCode.ct_SndNG,			//2:���M�G���[
                    (int)EnumUoeConst.ctDataRecoverDiv.ct_YES);			//9:�����Ώ�
            }
			catch (Exception ex)
			{
				status = -1;
				message = ex.Message;
			}
			return (status);
		}
		# endregion

		# region �t�n�d��M�d���쐬���݌Ɂ��i���Y�m�p�[�c�j
		/// <summary>
		/// �t�n�d��M�d���쐬���݌Ɂ��i���Y�m�p�[�c�j
		/// </summary>
		public class TelegramJnlStock0202 : UoeRecEdit0202Acs
		{
			# region �o�l�V�\�[�X
            //struct	LN_Z {							//                             
            //	char	hb    [12];					// ײ�      �i��			   
            //	char	ercd  [ 1];					// 			�װ����			   
            //	char	jkn   [ 2];					// 	�O�Ή�	����			   
            //	char	bhb   [12];					// 			���i�ԍ�		   
            //	char	tyob  [ 3];					//          �\��               
            //	char	kzsu  [ 3];					// 			���_�݌ɐ�		   
            //
            //	char	sjkn  [ 2];					// 	��Ή�	����			   
            //	char	sbhb  [12];					// 			���i�ԍ�		   
            //	char	szsu  [ 3];					// 			����݌ɐ�		   
            //	char	syob  [ 3];					// 			�\��		       
            //	char	bsob  [ 2];					// 			���i�w��		   
            //	char	teika [ 7];					// 			�������i		   
            //
            //	char	zdmy  [ 3];					// �_�~�[�i����`�j            
            //	char	sedai [ 1];					// ����敪                    
            //	char	seibi [ 2];					// �����`�ԋ敪                
            //	char	hizyo [ 1];					// �����敪                  
            //
            //	char	mkyo  [ 2];					//  �����敪 Ҳݾ�����_�ԍ�	   
            //	char	skyo  [ 5][2];				// 	�V  	 ��޾�����_�ԍ�1-5 
            //	char	kyos  [ 2];					// 	���_��					   
            //	char	kyobn [40][3];				//	���_�ԍ�1-40			   
            //};
            //struct	DN_ZAI {						//                             
            //	char	jh    [ 1];					// TTC  ���敪   		       
            //	char	ts    [ 2];					//      ÷�ļ��ݽ  	    	   
            //	char	lg    [ 2];					// 		÷�Ē�				   
            //	char	dbkb  [ 1];					// ͯ�� �d���敪			   
            //	char	res   [ 1];					//      ��������			   
            //	char	toikb [ 1];					//      �₢���킹�E�����敪   
            //	char	gyoid [12];					//      �Ɩ�ID				   
            //	char	pass  [ 6];					//      �Ɩ��߽ܰ��		   
            //	char	vers  [ 3];					//      �[��PG�ް�ޮ�		   
            //	char	keikb [ 1];					//      �p���敪			   
            //	char	trid  [ 3];					//      ���ID				   
            //	char	exten [15];					//      �g���G���A			   
            //	char	syocd [ 2];					//      �����R�[�h			   
            //	struct	LN_Z  z[5];					// ײ�       205*5=1025�޲�    
            //	char	uscd  [ 6];		       	    // �[���Ή�հ�ް����	   	   
            //	char	dummy[992];					// dummy   				       
            //};
			# endregion

			# region Const Members
			private const Int32 ctBufLen = 5;		//���׃o�b�t�@�T�C�Y
			# endregion

			# region Private Members
			//�ϐ�
			private Int32 _detailMax = 0;
			private DN_Z dn_z = new DN_Z(); 
			# endregion

			# region �d���̈�N���X
			/// <summary>
			/// �݌ɓd���̈恃���C����
			/// </summary>
			private class LN_Z
			{
	            public byte[]	hb     = new byte[12];					// ײ�      �i��			   
	            public byte[]	ercd   = new byte[ 1];					// 			�װ����			   
	            public byte[]	jkn    = new byte[ 2];					// 	�O�Ή�	����			   
	            public byte[]	bhb    = new byte[12];					// 			���i�ԍ�		   
	            public byte[]	tyob   = new byte[ 3];					//          �\��               
	            public byte[]	kzsu   = new byte[ 3];					// 			���_�݌ɐ�		   

	            public byte[]	sjkn   = new byte[ 2];					// 	��Ή�	����			   
	            public byte[]	sbhb   = new byte[12];					// 			���i�ԍ�		   
	            public byte[]	szsu   = new byte[ 3];					// 			����݌ɐ�		   
	            public byte[]	syob   = new byte[ 3];					// 			�\��		       
	            public byte[]	bsob   = new byte[ 2];					// 			���i�w��		   
	            public byte[]	teika  = new byte[ 7];					// 			�������i		   

	            public byte[]	zdmy   = new byte[ 3];					// �_�~�[�i����`�j            
	            public byte[]	sedai  = new byte[ 1];					// ����敪                    
	            public byte[]	seibi  = new byte[ 2];					// �����`�ԋ敪                
	            public byte[]	hizyo  = new byte[ 1];					// �����敪                  

	            public byte[]	mkyo   = new byte[ 2];					//  �����敪 Ҳݾ�����_�ԍ�	   
	            public byte[][]	skyo   = new byte[ 5][];				// 	�V  	 ��޾�����_�ԍ�1-5 new byte[ 5][2] 
	            public byte[]	kyos   = new byte[ 2];					// 	���_��					   
	            public byte[][]	kyobn  = new byte[40][];				//	���_�ԍ�1-40 new byte[40][3]			   

				public LN_Z()
				{
					Clear(0x00);
				}
				public void Clear(byte cd)
				{
	                UoeCommonFnc.MemSet(ref hb, cd, hb.Length);				// ײ�      �i��			   
	                UoeCommonFnc.MemSet(ref ercd, cd, ercd.Length);			// 			�װ����			   
	                UoeCommonFnc.MemSet(ref jkn, cd, jkn.Length);			// 	�O�Ή�	����			   
	                UoeCommonFnc.MemSet(ref bhb, cd, bhb.Length);			// 			���i�ԍ�		   
	                UoeCommonFnc.MemSet(ref tyob, cd, tyob.Length);			//          �\��               
	                UoeCommonFnc.MemSet(ref kzsu, cd, kzsu.Length);			// 			���_�݌ɐ�		   

	                UoeCommonFnc.MemSet(ref sjkn, cd, sjkn.Length);			// 	��Ή�	����			   
	                UoeCommonFnc.MemSet(ref sbhb, cd, sbhb.Length);			// 			���i�ԍ�		   
	                UoeCommonFnc.MemSet(ref szsu, cd, szsu.Length);			// 			����݌ɐ�		   
	                UoeCommonFnc.MemSet(ref syob, cd, syob.Length);			// 			�\��		       
	                UoeCommonFnc.MemSet(ref bsob, cd, bsob.Length);			// 			���i�w��		   
	                UoeCommonFnc.MemSet(ref teika, cd, teika.Length);		// 			�������i		   

	                UoeCommonFnc.MemSet(ref zdmy, cd, zdmy.Length);			// �_�~�[�i����`�j            
	                UoeCommonFnc.MemSet(ref sedai, cd, sedai.Length);		// ����敪                    
	                UoeCommonFnc.MemSet(ref seibi, cd, seibi.Length);		// �����`�ԋ敪                
	                UoeCommonFnc.MemSet(ref hizyo, cd, hizyo.Length);		// �����敪                  

	                UoeCommonFnc.MemSet(ref mkyo, cd, mkyo.Length);			//  �����敪 Ҳݾ�����_�ԍ�	   

                    // 	�V  	 ��޾�����_�ԍ�1-5 
                    for (int i = 0; i < skyo.Length; i++)
                    {
                        skyo[i] = new byte[2];
                    }

	                UoeCommonFnc.MemSet(ref kyos, cd, kyos.Length);			// 	���_��					   

                    //	���_�ԍ�1-40			   
                    for (int i = 0; i < kyobn.Length; i++)
                    {
                        kyobn[i] = new byte[3];
                    }
				}
			}

			/// <summary>
			/// �݌ɓd���̈恃�{�́�
			/// </summary>
			private class DN_Z
			{
	            public byte[]	jh     = new byte[ 1];					// TTC  ���敪   		       
	            public byte[]	ts     = new byte[ 2];					//      ÷�ļ��ݽ  	    	   
	            public byte[]	lg     = new byte[ 2];					// 		÷�Ē�				   
	            public byte[]	dbkb   = new byte[ 1];					// ͯ�� �d���敪			   
	            public byte[]	res    = new byte[ 1];					//      ��������			   
	            public byte[]	toikb  = new byte[ 1];					//      �₢���킹�E�����敪   
	            public byte[]	gyoid  = new byte[12];					//      �Ɩ�ID				   
	            public byte[]	pass   = new byte[ 6];					//      �Ɩ��߽ܰ��		   
	            public byte[]	vers   = new byte[ 3];					//      �[��PG�ް�ޮ�		   
	            public byte[]	keikb  = new byte[ 1];					//      �p���敪			   
	            public byte[]	trid   = new byte[ 3];					//      ���ID				   
	            public byte[]	exten  = new byte[15];					//      �g���G���A			   
	            public byte[]	syocd  = new byte[ 2];					//      �����R�[�h			   

                public LN_Z[] ln_z = new LN_Z[ctBufLen];                // ײ�

                public byte[]	uscd   = new byte[ 6];		       	    // �[���Ή�հ�ް����	   	   
	            public byte[]	dummy  = new byte[992];					// dummy   				       

				/// <summary>	
				/// �R���X�g���N�^�[
				/// </summary>
				public DN_Z()
				{
					Clear(0x00);
				}

				public void Clear(byte cd)
				{
	                UoeCommonFnc.MemSet(ref jh, cd, jh.Length);				// TTC  ���敪   		       
	                UoeCommonFnc.MemSet(ref ts, cd, ts.Length);				//      ÷�ļ��ݽ  	    	   
	                UoeCommonFnc.MemSet(ref lg, cd, lg.Length);				// 		÷�Ē�				   
	                UoeCommonFnc.MemSet(ref dbkb, cd, dbkb.Length);			// ͯ�� �d���敪			   
	                UoeCommonFnc.MemSet(ref res, cd, res.Length);			//      ��������			   
	                UoeCommonFnc.MemSet(ref toikb, cd, toikb.Length);		//      �₢���킹�E�����敪   
	                UoeCommonFnc.MemSet(ref gyoid, cd, gyoid.Length);		//      �Ɩ�ID				   
	                UoeCommonFnc.MemSet(ref pass, cd, pass.Length);			//      �Ɩ��߽ܰ��		   
	                UoeCommonFnc.MemSet(ref vers, cd, vers.Length);			//      �[��PG�ް�ޮ�		   
	                UoeCommonFnc.MemSet(ref keikb, cd, keikb.Length);		//      �p���敪			   
	                UoeCommonFnc.MemSet(ref trid, cd, trid.Length);			//      ���ID				   
	                UoeCommonFnc.MemSet(ref exten, cd, exten.Length);		//      �g���G���A			   
	                UoeCommonFnc.MemSet(ref syocd, cd, syocd.Length);		//      �����R�[�h			   

					//���ו�
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

	                UoeCommonFnc.MemSet(ref uscd, cd, uscd.Length);			// �[���Ή�հ�ް����	   	   
	                UoeCommonFnc.MemSet(ref dummy, cd, dummy.Length);		// dummy   				       
				}

			}
			# endregion

			# region Constructors
			/// <summary>
			/// �R���X�g���N�^
			/// </summary>
			public TelegramJnlStock0202()
			{
				Clear(0x00);
			}
			# endregion

			# region Properties
			# region ���׍s��
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
			# region �f�[�^����������
			/// <summary>
			/// �f�[�^����������
			/// </summary>
			public void Clear(byte cd)
			{
				_detailMax = 0;
				dn_z.Clear(0x00);
			}
			# endregion

			# region �f�[�^�ҏW����
			/// <summary>
			/// �f�[�^�ҏW����
			/// </summary>
			/// <param name="dtl"></param>
			/// <param name="jnl"></param>
			public void Telegram(Int32 uOESupplierCd, UoeRecDtl dtl)
			{
                //�J�ǁE�Ǔd���̃X�L�b�v����
                if ((dtl.UOESalesOrderNo == 0) && (dtl.UOESalesOrderRowNo.Count == 0)) return;

                //�o�C�g�^�z��ɕϊ�
				FromByteArray(dtl.RecTelegram);

				//�d���̍s���擾
				_detailMax = dtl.UOESalesOrderRowNo.Count;

				for (int i = 0; i < _detailMax; i++)
				{
					//�擾������MJNL-DATATABLE������MJNL-CLASS��
					DataRow dataRow = _uoeSndRcvJnlAcs.JnlStockTblRead(
													uOESupplierCd,
													dtl.UOESalesOrderNo,
													dtl.UOESalesOrderRowNo[i]);
					if (dataRow == null)
					{
						continue;
					}

                    // ��M���t
                    dataRow[StockSndRcvJnlSchema.ct_Col_ReceiveDate] = DateTime.Now;

                    // ��M����
                    dataRow[StockSndRcvJnlSchema.ct_Col_ReceiveTime] = TDateTime.DateTimeToLongDate("HHMMSS", DateTime.Now);

                    //�w�b�_�[�G���[�̊i�[����
                    //�w�b�_�[�G���[�Ȃ�
                    if (dn_z.res[0] == 0x00)
                    {
                    }
                    //�w�b�_�[�G���[����
                    else
                    {
                        string errMessage = GetHeadErrorMassage(dn_z.res[0]);

                        //�w�b�h�G���[���b�Z�[�W
                        dataRow[StockSndRcvJnlSchema.ct_Col_HeadErrorMassage] = errMessage;

                        //���C���G���[���b�Z�[�W
                        dataRow[StockSndRcvJnlSchema.ct_Col_LineErrorMassage] = errMessage;

                        //�i��
                        dataRow[StockSndRcvJnlSchema.ct_Col_AnswerPartsName] = errMessage;
                    }

		            // ���i�ԍ�
                    dataRow[StockSndRcvJnlSchema.ct_Col_AnswerPartsNo] = UoeCommonFnc.ToStringFromByteStrAry(dn_z.ln_z[i].hb);
#if False
		            /* �i�ԕ␳----------------------------------------------------*/
		            memset( hibn, 0x20, sizeof hibn );
		            if( memcmp( uoejlc.PM3010JH, hibn, sizeof uoejlc.PM3010JH ) == 0 )
			            memcpy( uoejlc.PM3010JH, uoejlc.D3010H, sizeof uoejlc.D3010H  );
#endif

		            /* �i���i��֕i�ԂP�j------------------------------------------*/
		            if(	( dn_z.ln_z[i].ercd[0] == '4'   )
		            ||  ( dn_z.ln_z[i].jkn[0] == 'F' )
		            ||	( dn_z.ln_z[i].jkn[0] == 'B' ))
		            {//��ւ���
                        dataRow[StockSndRcvJnlSchema.ct_Col_SubstPartsNo] = UoeCommonFnc.ToStringFromByteStrAry(dn_z.ln_z[i].bhb);
		            }
                    else
                    {
                        if (dn_z.res[0] == 0x00)
                        {
                            string answerPartsName = "";
				            if( dn_z.ln_z[i].ercd[0] == '1' )
                            {
                                answerPartsName = "����ò�����";
                            }
				            else if( dn_z.ln_z[i].ercd[0] == '2' )
                            {
                                answerPartsName = "˻޲���";
                            }
				            else if( dn_z.ln_z[i].ercd[0] == '3' )
                            {
                                answerPartsName = "��ϯ��װ";
                            }
				            else
                            {
                                answerPartsName = UoeCommonFnc.ToStringFromByteStrAry(dn_z.ln_z[i].bhb);
                            }
                            dataRow[StockSndRcvJnlSchema.ct_Col_AnswerPartsName] = answerPartsName;
                        }
		            }

		            // �i���i��֕i�ԂQ�j
                    if ((dn_z.ln_z[i].ercd[0] == '4')
		            ||  ( dn_z.ln_z[i].sjkn[0] == 'F' )
		            ||	( dn_z.ln_z[i].sjkn[0] == 'B' ))
		            {//��ւ���
                        dataRow[StockSndRcvJnlSchema.ct_Col_CenterSubstPartsNo] = UoeCommonFnc.ToStringFromByteStrAry(dn_z.ln_z[i].sbhb);
		            }
                    else
                    {
                        if (dn_z.res[0] == 0x00)
                        {
                            string answerPartsName = "";
                            if (dn_z.ln_z[i].ercd[0] == '1')
                            {
                                answerPartsName = "����ò�����";
                            }
                            else if (dn_z.ln_z[i].ercd[0] == '2')
                            {
                                answerPartsName = "˻޲���";
                            }
                            else if (dn_z.ln_z[i].ercd[0] == '3')
                            {
                                answerPartsName = "��ϯ��װ";
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

		            // �艿
                    dataRow[StockSndRcvJnlSchema.ct_Col_AnswerListPrice] = UoeCommonFnc.ToDoubleFromByteStrAry(dn_z.ln_z[i].teika);

		            // �T�u�Z���^�[���_
        			# region �T�u�Z���^�[���_
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

		            // �w��
                    dataRow[StockSndRcvJnlSchema.ct_Col_PartsLayerCd] = UoeCommonFnc.ToStringFromByteStrAry(dn_z.ln_z[i].bsob);

					// �f�[�^���M�敪
                    dataRow[StockSndRcvJnlSchema.ct_Col_DataSendCode] = dtl.DataSendCode;

					// �f�[�^�����敪
					dataRow[StockSndRcvJnlSchema.ct_Col_DataRecoverDiv] = dtl.DataRecoverDiv;
				}
			}
			# endregion

			# endregion

			# region private Methods

			# region �o�C�g�^�z��ɕϊ�
			/// <summary>
			/// �o�C�g�^�z��ɕϊ�
			/// </summary>
			/// <returns></returns>
			private void FromByteArray(byte[] line)
			{
				_detailMax = 0;
				MemoryStream ms = new MemoryStream();
				ms.Write(line, 0, line.Length);
                ms.Seek(0, SeekOrigin.Begin);

	            ms.Read(dn_z.jh, 0, dn_z.jh.Length);				// TTC  ���敪   		       
	            ms.Read(dn_z.ts, 0, dn_z.ts.Length);				//      ÷�ļ��ݽ  	    	   
	            ms.Read(dn_z.lg, 0, dn_z.lg.Length);				// 		÷�Ē�				   
	            ms.Read(dn_z.dbkb, 0, dn_z.dbkb.Length);			// ͯ�� �d���敪			   
	            ms.Read(dn_z.res, 0, dn_z.res.Length);			    //      ��������			   
	            ms.Read(dn_z.toikb, 0, dn_z.toikb.Length);		    //      �₢���킹�E�����敪   
	            ms.Read(dn_z.gyoid, 0, dn_z.gyoid.Length);		    //      �Ɩ�ID				   
	            ms.Read(dn_z.pass, 0, dn_z.pass.Length);			//      �Ɩ��߽ܰ��		   
	            ms.Read(dn_z.vers, 0, dn_z.vers.Length);			//      �[��PG�ް�ޮ�		   
	            ms.Read(dn_z.keikb, 0, dn_z.keikb.Length);		    //      �p���敪			   
	            ms.Read(dn_z.trid, 0, dn_z.trid.Length);			//      ���ID				   
	            ms.Read(dn_z.exten, 0, dn_z.exten.Length);		    //      �g���G���A			   
	            ms.Read(dn_z.syocd, 0, dn_z.syocd.Length);		    //      �����R�[�h			   

				//���ו�
				for (int i = 0; i < ctBufLen; i++)
				{
                    LN_Z _ln_z = dn_z.ln_z[i];

	                ms.Read(_ln_z.hb, 0, _ln_z.hb.Length);				// ײ�      �i��			   
	                ms.Read(_ln_z.ercd, 0, _ln_z.ercd.Length);			// 			�װ����			   
	                ms.Read(_ln_z.jkn, 0, _ln_z.jkn.Length);			// 	�O�Ή�	����			   
	                ms.Read(_ln_z.bhb, 0, _ln_z.bhb.Length);			// 			���i�ԍ�		   
	                ms.Read(_ln_z.tyob, 0, _ln_z.tyob.Length);			//          �\��               
	                ms.Read(_ln_z.kzsu, 0, _ln_z.kzsu.Length);			// 			���_�݌ɐ�		   

	                ms.Read(_ln_z.sjkn, 0, _ln_z.sjkn.Length);			// 	��Ή�	����			   
	                ms.Read(_ln_z.sbhb, 0, _ln_z.sbhb.Length);			// 			���i�ԍ�		   
	                ms.Read(_ln_z.szsu, 0, _ln_z.szsu.Length);			// 			����݌ɐ�		   
	                ms.Read(_ln_z.syob, 0, _ln_z.syob.Length);			// 			�\��		       
	                ms.Read(_ln_z.bsob, 0, _ln_z.bsob.Length);			// 			���i�w��		   
	                ms.Read(_ln_z.teika, 0, _ln_z.teika.Length);		// 			�������i		   

	                ms.Read(_ln_z.zdmy, 0, _ln_z.zdmy.Length);			// �_�~�[�i����`�j            
	                ms.Read(_ln_z.sedai, 0, _ln_z.sedai.Length);		// ����敪                    
	                ms.Read(_ln_z.seibi, 0, _ln_z.seibi.Length);		// �����`�ԋ敪                
	                ms.Read(_ln_z.hizyo, 0, _ln_z.hizyo.Length);		// �����敪                  

	                ms.Read(_ln_z.mkyo, 0, _ln_z.mkyo.Length);			//  �����敪 Ҳݾ�����_�ԍ�	   
	
                    // ��޾�����_�ԍ�1-5 
                    for (int j = 0; j < _ln_z.skyo.Length; j++)
                    {
    	                ms.Read(_ln_z.skyo[j], 0, _ln_z.skyo[j].Length);//  �����敪 Ҳݾ�����_�ԍ�	   
                    }

                	ms.Read(_ln_z.kyos, 0, _ln_z.kyos.Length);			// 	���_��					   
                    
                    //	���_�ԍ�1-40			   
                    for (int j = 0; j < _ln_z.kyobn.Length; j++)
                    {
    	                ms.Read(_ln_z.kyobn[j], 0, _ln_z.kyobn[j].Length);  //  �����敪 Ҳݾ�����_�ԍ�	   
                    }
				}

	            ms.Read(dn_z.uscd, 0, dn_z.uscd.Length);		        // �[���Ή�հ�ް����	   	   
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

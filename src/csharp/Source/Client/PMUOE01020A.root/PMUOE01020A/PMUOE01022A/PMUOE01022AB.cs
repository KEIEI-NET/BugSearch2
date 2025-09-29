//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �t�n�d��M�ҏW���������i���Y�m�p�[�c�j�A�N�Z�X�N���X
// �v���O�����T�v   : �t�n�d��M�ҏW���������i���Y�m�p�[�c�j���s��
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
	/// �t�n�d��M�ҏW���������i���Y�m�p�[�c�j�A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �t�n�d��M�ҏW�i���Y�m�p�[�c�j�A�N�Z�X�N���X</br>
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

		# region �t�n�d��M�ҏW���������i���Y�m�p�[�c�j
		/// <summary>
		/// �t�n�d��M�ҏW���������i���Y�m�p�[�c�j
		/// </summary>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        private int GetJnlOrder0202(out string message)
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
                    TelegramJnlOrder0202 telegramJnlOrder0202 = new TelegramJnlOrder0202();

                    //�i�m�k�X�V����
                    foreach (UoeRecDtl dtl in uoeRecDtlList)
                    {
                        telegramJnlOrder0202.Telegram(_uoeRecHed.UOESupplierCd, dtl);
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

		# region �t�n�d��M�d���쐬���������i���Y�m�p�[�c�j
		/// <summary>
		/// �t�n�d��M�d���쐬���������i���Y�m�p�[�c�j
		/// </summary>
		public class TelegramJnlOrder0202 : UoeRecEdit0202Acs
		{
			# region �o�l�V�\�[�X
            //struct	LN_H {						//                             
            //	char	hadt    [12];				// ���i�ԍ�					   
            //	char	bo      [ 1];				// �a�^�n�敪				   
            //	char	knm     [16];				// �i��						   
            //	char	hasu    [ 5];				// ��������					   
            //	char	bos     [ 1];				// �a�^�n�����				   
            //	char	kysu    [ 5];				// ���_   �o�ɐ�               
            //	char	kydno   [ 6];				//        �[�i���m�n		   
            //	char	skzk    [ 1];				//        �d�|�݌Ɉ��������    
            //	char	skzd    [ 4];				//        �d�|�݌Ɉ����\��     
            //	char	skzs    [ 5];				//        �d�|�݌Ɉ�������     
            //	char	shcd    [ 3];				// �r�r   ���_����			   
            //	char	shsu    [ 5];				//        �o�ɐ�			   
            //	char	shdno   [ 6];				//        �[�i���m�n		   
            //	char	shzk    [ 1];				//        �d�|�݌Ɉ��������    
            //	char	hocd    [ 3];				// �l�r   ���_����			   
            //	char	hosu    [ 5];				//        �o�ɐ�			   
            //	char	hodno   [ 6];				//        �[�i���m�n		   
            //	char	hozk    [ 1];				//        �d�|�݌Ɉ��������    
            //	char	f3cd    [ 3];				// ���̑� ���_����			   
            //	char	f3su    [ 5];				//        �o�ɐ�			   
            //	char	f3dno   [ 6];				//        �[�i���m�n		   
            //
            //	char	hzan    [ 5];				// �����c������				   
            //	char	fzan    [ 5];				// �s����      				   
            //	char	eohb    [12];				// Ұ��E/O�������i�ԍ�		   
            //	char	eosu    [ 3];				// Ұ��E/O������      		   
            //	char	mksu    [ 3];				// Ұ��B/O��        		   
            //	char	nkkb    [ 1];				// �\��[���敪     		   
            //	char	ytmd    [ 4];				// �[���\���       		   
            //	char	mkdno   [ 6];				// �a�^�n�Ǘ���				   
            //	char	azaid   [ 1];				// �S�Ѝ݌ɕ\��				   
            //	char	azais   [ 5];				// �S�Ѝ݌ɐ�  				   
            //	char	teika   [ 7];				// �E�v(�艿)				   
            //	char	tanka   [ 7];				// �d�؉��i					   
            //	char	sob     [ 2];				// ���i�w��					   
            //	char	lmsg    [12];				// ײ�ү����				   
            //
            //	char	bomsg   [ 1];				// �i���ʁj�a�^�nү���ދ敪	   
            //	char	bosu    [ 5];				// �i���ʁj�a�^�n��            
            //  char	sinb	[ 1];				// �Q����O�V���{��            
            //
            //};
            //struct	DN_HAC {					//                             
            //	char	jkbn    [ 1];				// ���敪					   
            //	char	seq_no  [ 2];				// �e�L�X�g�V�[�P���X�ԍ�	   
            //	char	text_len[ 2];				// �e�L�X�g��				   
            //	char	dkbn    [ 1];				// �d���敪					   
            //	char	kekka   [ 1];				// ��������					   
            //	char	tokbn   [ 1];				// �⍇���^�����敪			   
            //	char	g_id    [12];				// �Ɩ��h�c					   
            //	char	g_pass  [ 6];				// �Ɩ��p�X���[�h			   
            //	char	prog_ver[ 3];				// �[���v���O�����o�[�W�����ԍ�
            //	char	kkbn    [ 1];				// �p���敪					   
            //	char	h_id    [ 3];				// �����h�c					   
            //	char	ext     [15];				// �g���G���A				   
            //	char	syori_cd[ 2];				// �����R�[�h				   
            //	char	out_ren [ 6];				// �o�͒ʔ�					   
            //	char	saisou  [ 1];				// �đ�����					   
            //	char	user_cd [ 6];				// ���[�U�[�R�[�h			   
            //	char	tori_cd [ 6];				// �����  �R�[�h			   
            //	char	nhkb    [ 1];				// �[�i�敪					   
            //	char	iracd   [ 2];				// �˗��҃R�[�h				   
            //	char	kyoten  [ 3];				// �w�苒�_					   
            //	char	bin     [ 1];				// ��      					   
            //	char	rem     [10];				// ���}�[�N  				   
            //  char	rem2    [10];				// ���}�[�N�Q  				   
            //	char	ermsg   [12];				// �G���[���b�Z�[�W			   
            //	struct	LN_H	ln_h[4];			// ���C��                      
            //	char	tuser_cd[ 6];				// �[���Ή����[�U�[�R�[�h	   
            //	char	mkmdhms [10];				// Ұ���񓚖⍇���� MMDDHHMMSS 
            //	char	mkkb    [ 1];				// Ұ���敪					   
            //	char	dnymdhm [12];				// �d�����M����   YYYYMMDDHHMM 
            //	char	dummy [1191];				// �\��                        
            //};

            # endregion

			# region Const Members
			private const Int32 ctBufLen = 4;		//���׃o�b�t�@�T�C�Y
			# endregion

			# region �d���̈�N���X
			/// <summary>
			/// �����d���̈恃���C����
			/// </summary>
			private class LN_H
			{
                public byte[] hadt = new byte[12];				// ���i�ԍ�					   
                public byte[] bo = new byte[1];				// �a�^�n�敪				   
                public byte[] knm = new byte[16];				// �i��						   
                public byte[] hasu = new byte[5];				// ��������					   
                public byte[] bos = new byte[1];				// �a�^�n�����				   
                public byte[] kysu = new byte[5];				// ���_   �o�ɐ�               
                public byte[] kydno = new byte[6];				//        �[�i���m�n		   
                public byte[] skzk = new byte[1];				//        �d�|�݌Ɉ��������    
                public byte[] skzd = new byte[4];				//        �d�|�݌Ɉ����\��     
                public byte[] skzs = new byte[5];				//        �d�|�݌Ɉ�������     
                public byte[] shcd = new byte[3];				// �r�r   ���_����			   
                public byte[] shsu = new byte[5];				//        �o�ɐ�			   
                public byte[] shdno = new byte[6];				//        �[�i���m�n		   
                public byte[] shzk = new byte[1];				//        �d�|�݌Ɉ��������    
                public byte[] hocd = new byte[3];				// �l�r   ���_����			   
                public byte[] hosu = new byte[5];				//        �o�ɐ�			   
                public byte[] hodno = new byte[6];				//        �[�i���m�n		   
                public byte[] hozk = new byte[1];				//        �d�|�݌Ɉ��������    
                public byte[] f3cd = new byte[3];				// ���̑� ���_����			   
                public byte[] f3su = new byte[5];				//        �o�ɐ�			   
                public byte[] f3dno = new byte[6];				//        �[�i���m�n		   

                public byte[] hzan = new byte[5];				// �����c������				   
                public byte[] fzan = new byte[5];				// �s����      				   
                public byte[] eohb = new byte[12];				// Ұ��E/O�������i�ԍ�		   
                public byte[] eosu = new byte[3];				// Ұ��E/O������      		   
                public byte[] mksu = new byte[3];				// Ұ��B/O��        		   
                public byte[] nkkb = new byte[1];				// �\��[���敪     		   
                public byte[] ytmd = new byte[4];				// �[���\���       		   
                public byte[] mkdno = new byte[6];				// �a�^�n�Ǘ���				   
                public byte[] azaid = new byte[1];				// �S�Ѝ݌ɕ\��				   
                public byte[] azais = new byte[5];				// �S�Ѝ݌ɐ�  				   
                public byte[] teika = new byte[7];				// �E�v(�艿)				   
                public byte[] tanka = new byte[7];				// �d�؉��i					   
                public byte[] sob = new byte[2];				// ���i�w��					   
                public byte[] lmsg = new byte[12];				// ײ�ү����				   

                public byte[] bomsg = new byte[1];				// �i���ʁj�a�^�nү���ދ敪	   
                public byte[] bosu = new byte[5];				// �i���ʁj�a�^�n��            
                public byte[] sinb = new byte[1];				// �Q����O�V���{��            

				public LN_H()
				{
					Clear(0x00);
				}
				public void Clear(byte cd)
				{
	                UoeCommonFnc.MemSet(ref hadt, cd, hadt.Length);			// ���i�ԍ�					   
	                UoeCommonFnc.MemSet(ref bo, cd, bo.Length);				// �a�^�n�敪				   
	                UoeCommonFnc.MemSet(ref knm, cd, knm.Length);			// �i��						   
	                UoeCommonFnc.MemSet(ref hasu, cd, hasu.Length);			// ��������					   
	                UoeCommonFnc.MemSet(ref bos, cd, bos.Length);			// �a�^�n�����				   
	                UoeCommonFnc.MemSet(ref kysu, cd, kysu.Length);			// ���_   �o�ɐ�               
	                UoeCommonFnc.MemSet(ref kydno, cd, kydno.Length);		//        �[�i���m�n		   
	                UoeCommonFnc.MemSet(ref skzk, cd, skzk.Length);			//        �d�|�݌Ɉ��������    
	                UoeCommonFnc.MemSet(ref skzd, cd, skzd.Length);			//        �d�|�݌Ɉ����\��     
	                UoeCommonFnc.MemSet(ref skzs, cd, skzs.Length);			//        �d�|�݌Ɉ�������     
	                UoeCommonFnc.MemSet(ref shcd, cd, shcd.Length);			// �r�r   ���_����			   
	                UoeCommonFnc.MemSet(ref shsu, cd, shsu.Length);			//        �o�ɐ�			   
	                UoeCommonFnc.MemSet(ref shdno, cd, shdno.Length);		//        �[�i���m�n		   
	                UoeCommonFnc.MemSet(ref shzk, cd, shzk.Length);			//        �d�|�݌Ɉ��������    
	                UoeCommonFnc.MemSet(ref hocd, cd, hocd.Length);			// �l�r   ���_����			   
	                UoeCommonFnc.MemSet(ref hosu, cd, hosu.Length);			//        �o�ɐ�			   
	                UoeCommonFnc.MemSet(ref hodno, cd, hodno.Length);		//        �[�i���m�n		   
	                UoeCommonFnc.MemSet(ref hozk, cd, hozk.Length);			//        �d�|�݌Ɉ��������    
	                UoeCommonFnc.MemSet(ref f3cd, cd, f3cd.Length);			// ���̑� ���_����			   
	                UoeCommonFnc.MemSet(ref f3su, cd, f3su.Length);			//        �o�ɐ�			   
	                UoeCommonFnc.MemSet(ref f3dno, cd, f3dno.Length);		//        �[�i���m�n		   

	                UoeCommonFnc.MemSet(ref hzan, cd, hzan.Length);			// �����c������				   
	                UoeCommonFnc.MemSet(ref fzan, cd, fzan.Length);			// �s����      				   
	                UoeCommonFnc.MemSet(ref eohb, cd, eohb.Length);			// Ұ��E/O�������i�ԍ�		   
	                UoeCommonFnc.MemSet(ref eosu, cd, eosu.Length);			// Ұ��E/O������      		   
	                UoeCommonFnc.MemSet(ref mksu, cd, mksu.Length);			// Ұ��B/O��        		   
	                UoeCommonFnc.MemSet(ref nkkb, cd, nkkb.Length);			// �\��[���敪     		   
	                UoeCommonFnc.MemSet(ref ytmd, cd, ytmd.Length);			// �[���\���       		   
	                UoeCommonFnc.MemSet(ref mkdno, cd, mkdno.Length);		// �a�^�n�Ǘ���				   
	                UoeCommonFnc.MemSet(ref azaid, cd, azaid.Length);		// �S�Ѝ݌ɕ\��				   
	                UoeCommonFnc.MemSet(ref azais, cd, azais.Length);		// �S�Ѝ݌ɐ�  				   
	                UoeCommonFnc.MemSet(ref teika, cd, teika.Length);		// �E�v(�艿)				   
	                UoeCommonFnc.MemSet(ref tanka, cd, tanka.Length);		// �d�؉��i					   
	                UoeCommonFnc.MemSet(ref sob, cd, sob.Length);			// ���i�w��					   
	                UoeCommonFnc.MemSet(ref lmsg, cd, lmsg.Length);			// ײ�ү����				   

	                UoeCommonFnc.MemSet(ref bomsg, cd, bomsg.Length);		// �i���ʁj�a�^�nү���ދ敪	   
	                UoeCommonFnc.MemSet(ref bosu, cd, bosu.Length);			// �i���ʁj�a�^�n��            
	                UoeCommonFnc.MemSet(ref sinb, cd, sinb.Length);		    // �Q����O�V���{��            
				}
			}

			/// <summary>
			/// �����d���̈恃�{�́�
			/// </summary>
			private class DN_H
			{
	            public byte[]	jkbn     = new byte[ 1];				// ���敪					   
	            public byte[]	seq_no   = new byte[ 2];				// �e�L�X�g�V�[�P���X�ԍ�	   
	            public byte[]	text_len = new byte[ 2];				// �e�L�X�g��				   
	            public byte[]	dkbn     = new byte[ 1];				// �d���敪					   
	            public byte[]	kekka    = new byte[ 1];				// ��������					   
	            public byte[]	tokbn    = new byte[ 1];				// �⍇���^�����敪			   
	            public byte[]	g_id     = new byte[12];				// �Ɩ��h�c					   
	            public byte[]	g_pass   = new byte[ 6];				// �Ɩ��p�X���[�h			   
	            public byte[]	prog_ver = new byte[ 3];				// �[���v���O�����o�[�W�����ԍ�
	            public byte[]	kkbn     = new byte[ 1];				// �p���敪					   
	            public byte[]	h_id     = new byte[ 3];				// �����h�c					   
	            public byte[]	ext      = new byte[15];				// �g���G���A				   
	            public byte[]	syori_cd = new byte[ 2];				// �����R�[�h				   
	            public byte[]	out_ren  = new byte[ 6];				// �o�͒ʔ�					   
	            public byte[]	saisou   = new byte[ 1];				// �đ�����					   
	            public byte[]	user_cd  = new byte[ 6];				// ���[�U�[�R�[�h			   
	            public byte[]	tori_cd  = new byte[ 6];				// �����  �R�[�h			   
	            public byte[]	nhkb     = new byte[ 1];				// �[�i�敪					   
	            public byte[]	iracd    = new byte[ 2];				// �˗��҃R�[�h				   
	            public byte[]	kyoten   = new byte[ 3];				// �w�苒�_					   
	            public byte[]	bin      = new byte[ 1];				// ��      					   
	            public byte[]	rem      = new byte[10];				// ���}�[�N  				   
	            public byte[]	rem2     = new byte[10];				// ���}�[�N�Q  				   
	            public byte[]	ermsg    = new byte[12];				// �G���[���b�Z�[�W			   
                public LN_H[] ln_h = new LN_H[ctBufLen];    			// ���C��                      
	            public byte[]	tuser_cd = new byte[ 6];				// �[���Ή����[�U�[�R�[�h	   
	            public byte[]	mkmdhms  = new byte[10];				// Ұ���񓚖⍇���� MMDDHHMMSS 
	            public byte[]	mkkb     = new byte[ 1];				// Ұ���敪					   
	            public byte[]	dnymdhm  = new byte[12];				// �d�����M����   YYYYMMDDHHMM 
	            public byte[]	dummy    = new byte[1191];				// �\��                        

				/// <summary>	
				/// �R���X�g���N�^�[
				/// </summary>
				public DN_H()
				{
					Clear(0x00);
				}

				public void Clear(byte cd)
				{
	                UoeCommonFnc.MemSet(ref jkbn, cd, jkbn.Length);			// ���敪					   
	                UoeCommonFnc.MemSet(ref seq_no, cd, seq_no.Length);		// �e�L�X�g�V�[�P���X�ԍ�	   
	                UoeCommonFnc.MemSet(ref text_len, cd, text_len.Length);	//				// �e�L�X�g��				   
	                UoeCommonFnc.MemSet(ref dkbn, cd, dkbn.Length);			// �d���敪					   
	                UoeCommonFnc.MemSet(ref kekka, cd, kekka.Length);		// ��������					   
	                UoeCommonFnc.MemSet(ref tokbn, cd, tokbn.Length);		// �⍇���^�����敪			   
	                UoeCommonFnc.MemSet(ref g_id, cd, g_id.Length);			// �Ɩ��h�c					   
	                UoeCommonFnc.MemSet(ref g_pass, cd, g_pass.Length);		// �Ɩ��p�X���[�h			   
	                UoeCommonFnc.MemSet(ref prog_ver, cd, prog_ver.Length);	// �[���v���O�����o�[�W�����ԍ�
	                UoeCommonFnc.MemSet(ref kkbn, cd, kkbn.Length);			// �p���敪					   
	                UoeCommonFnc.MemSet(ref h_id, cd, h_id.Length);			// �����h�c					   
	                UoeCommonFnc.MemSet(ref ext, cd, ext.Length);			// �g���G���A				   
	                UoeCommonFnc.MemSet(ref syori_cd, cd, syori_cd.Length);	// �����R�[�h				   
	                UoeCommonFnc.MemSet(ref out_ren, cd, out_ren.Length);	// �o�͒ʔ�					   
	                UoeCommonFnc.MemSet(ref saisou, cd, saisou.Length);		// �đ�����					   
	                UoeCommonFnc.MemSet(ref user_cd, cd, user_cd.Length);	// ���[�U�[�R�[�h			   
	                UoeCommonFnc.MemSet(ref tori_cd, cd, tori_cd.Length);	// �����  �R�[�h			   
	                UoeCommonFnc.MemSet(ref nhkb, cd, nhkb.Length);			// �[�i�敪					   
	                UoeCommonFnc.MemSet(ref iracd, cd, iracd.Length);		// �˗��҃R�[�h				   
	                UoeCommonFnc.MemSet(ref kyoten, cd, kyoten.Length);		// �w�苒�_					   
	                UoeCommonFnc.MemSet(ref bin, cd, bin.Length);			// ��      					   
	                UoeCommonFnc.MemSet(ref rem, cd, rem.Length);			// ���}�[�N  				   
                    UoeCommonFnc.MemSet(ref rem2, cd, rem2.Length);			// ���}�[�N�Q  				   
	                UoeCommonFnc.MemSet(ref ermsg, cd, ermsg.Length);		// �G���[���b�Z�[�W			   

                    //���ו�
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

                    UoeCommonFnc.MemSet(ref tuser_cd, cd, tuser_cd.Length);	// �[���Ή����[�U�[�R�[�h	   
	                UoeCommonFnc.MemSet(ref mkmdhms, cd, mkmdhms.Length);	// Ұ���񓚖⍇���� MMDDHHMMSS 
	                UoeCommonFnc.MemSet(ref mkkb, cd, mkkb.Length);			// Ұ���敪					   
	                UoeCommonFnc.MemSet(ref dnymdhm, cd, dnymdhm.Length);	// �d�����M����   YYYYMMDDHHMM 
	                UoeCommonFnc.MemSet(ref dummy, cd, dummy.Length);		// �\��                        
				}
			}

			# endregion

			# region Private Members
			//�ϐ�
			private Int32 _detailMax = 0;
			private DN_H dn_h = new DN_H(); 
			# endregion

			# region Constructors
			/// <summary>
			/// �R���X�g���N�^
			/// </summary>
			public TelegramJnlOrder0202()
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

				dn_h.Clear(0x00);
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
					DataRow dataRow = _uoeSndRcvJnlAcs.JnlOrderTblRead(
													uOESupplierCd,
													dtl.UOESalesOrderNo,
													dtl.UOESalesOrderRowNo[i]);
					if (dataRow == null)
					{
						continue;
					}

                    //�f�[�^���M�敪
                    dataRow[OrderSndRcvJnlSchema.ct_Col_DataSendCode] = dtl.DataSendCode;

                    //�f�[�^�����敪
                    dataRow[OrderSndRcvJnlSchema.ct_Col_DataRecoverDiv] = dtl.DataRecoverDiv;

		            // ��M���t
    				dataRow[OrderSndRcvJnlSchema.ct_Col_ReceiveDate] = DateTime.Now;

		            // ��M����
                    dataRow[OrderSndRcvJnlSchema.ct_Col_ReceiveTime] = TDateTime.DateTimeToLongDate("HHMMSS", DateTime.Now);

                    //�w�b�_�[�G���[�̊i�[����
                    //�w�b�_�[�G���[�Ȃ�
		            if( dn_h.kekka[0] == 0x00 )
                    {
                    }
                    //�w�b�_�[�G���[����
                    else
                    {
                        string errMessage = GetHeadErrorMassage(dn_h.kekka[0]);

						//�w�b�h�G���[���b�Z�[�W
						dataRow[OrderSndRcvJnlSchema.ct_Col_HeadErrorMassage] = errMessage;

						//���C���G���[���b�Z�[�W
						dataRow[OrderSndRcvJnlSchema.ct_Col_LineErrorMassage] = errMessage;

						//�i��
						dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerPartsName] = errMessage;
		            }
#if False
		            /* �[�i�敪----------------------------------------------------*/
		            uoejla.D6310[0] = dnh.nhkb[0];

		            /* ���}�[�N�P--------------------------------------------------*/
		            memcpy( uoejla.PM1590, dnh.rem, sizeof dnh.rem );

		            /* �w�苒�_----------------------------------------------------*/
		            memcpy( uoejla.D6334  , dnh.kyoten,sizeof dnh.kyoten);
#endif

                    //��ւ���
					if (((dn_h.ln_h[i].knm[0] == 'F') || (dn_h.ln_h[i].knm[0] == 'B'))
			        && ('2' <= dn_h.ln_h[i].knm[1] && dn_h.ln_h[i].knm[1] <= '5')
                    && dn_h.ln_h[i].knm[2] == ' ')
					{
                        //�񓚕i��
                        dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerPartsNo] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].hadt);

                        //��֕i��
                        string knmString = UoeCommonFnc.GetRemove(UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].knm), 0, 3);
                        dataRow[OrderSndRcvJnlSchema.ct_Col_SubstPartsNo] = knmString;

                        //�񓚕i��
                        dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerPartsName] = knmString;
					}
                    //��ւȂ�
                    else
					{
                        //�񓚕i��
                        dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerPartsNo] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].hadt);

                        //�񓚕i��
                        dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerPartsName] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].knm);
                    }


#if Fals
                    /* �a�n�敪					*/
		            uoejla.PM1504[0] = dnh.ln_h[no].bo[0] ;

                    /* ������					*/
                    chg_num( dnh.ln_h[no].hasu ,sizeof dnh.ln_h[no].hasu ,&lng,0 );
		            uoejla.PM6201 = (short)lng ;
#endif
                    

                    //���_ �o�ɐ�
					dataRow[OrderSndRcvJnlSchema.ct_Col_UOESectOutGoodsCnt] = UoeCommonFnc.ToInt32FromByteStrAry(dn_h.ln_h[i].kysu);

                    //���_  �[�i���m�n
					dataRow[OrderSndRcvJnlSchema.ct_Col_UOESectionSlipNo] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].kydno);

                    /*�T�u�Z���^�[---------------------------------------------------------*/
                    //�T�u�Z���^�[ �o�ɐ�
					dataRow[OrderSndRcvJnlSchema.ct_Col_BOShipmentCnt1] = UoeCommonFnc.ToInt32FromByteStrAry(dn_h.ln_h[i].shsu);

                    //�T�u�Z���^�[ �[�i���m�n
					dataRow[OrderSndRcvJnlSchema.ct_Col_BOSlipNo1] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].shdno);

                    /*���C���Z���^�[-------------------------------------------------------*/
                    //���C���Z���^�[ �o�ɐ�
					dataRow[OrderSndRcvJnlSchema.ct_Col_BOShipmentCnt2] = UoeCommonFnc.ToInt32FromByteStrAry(dn_h.ln_h[i].hosu);

                    //���C���Z���^�[ �[�i���m�n
					dataRow[OrderSndRcvJnlSchema.ct_Col_BOSlipNo2] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].hodno);

                    /*�����_---------------------------------------------------------------*/
                    //�����_ �o�ɐ�
					dataRow[OrderSndRcvJnlSchema.ct_Col_BOShipmentCnt3] = UoeCommonFnc.ToInt32FromByteStrAry(dn_h.ln_h[i].f3su);

                    //�����_ �[�i���m�n
					dataRow[OrderSndRcvJnlSchema.ct_Col_BOSlipNo3] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].f3dno);

                    /*���[�J�[�a�n---------------------------------------------------------*/
                    //���[�J�[�a�n Ұ��B/O��
					dataRow[OrderSndRcvJnlSchema.ct_Col_MakerFollowCnt] = UoeCommonFnc.ToInt32FromByteStrAry(dn_h.ln_h[i].mksu);

                    //���[�J�[�a�n �a�^�n�Ǘ���
					dataRow[OrderSndRcvJnlSchema.ct_Col_BOManagementNo] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].mkdno);

#if False
                    /* �\��[���敪        */
		            uoejla.PM1598[0] = dnh.ln_h[no].nkkb[0];

                    /*�[���\���           */
		            memcpy(&uoejla.PM6338[6]  ,dnh.ln_h[no].ytmd, 4 );
#endif
                    // �艿
                    dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerListPrice] = UoeCommonFnc.ToDoubleFromByteStrAry(dn_h.ln_h[i].teika);

                    // �d�؂�P��
                    dataRow[OrderSndRcvJnlSchema.ct_Col_AnswerSalesUnitCost] = UoeCommonFnc.ToDoubleFromByteStrAry(dn_h.ln_h[i].tanka);

                    // �w��
                    dataRow[OrderSndRcvJnlSchema.ct_Col_PartsLayerCd] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].sob);

                    // ���C�����b�Z�[�W
					dataRow[OrderSndRcvJnlSchema.ct_Col_LineErrorMassage] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].lmsg);

		            if( UoeCommonFnc.MemCmp(dn_h.ln_h[i].eosu, "   ", 3) == 0
		            ||  UoeCommonFnc.MemCmp(dn_h.ln_h[i].eosu, "000", 3) == 0 ){
                        dataRow[OrderSndRcvJnlSchema.ct_Col_EOAlwcCount] = 0;
		            }else{
                        /*�a�n�Ǘ�No.          */
						dataRow[OrderSndRcvJnlSchema.ct_Col_BOManagementNo] = UoeCommonFnc.ToStringFromByteStrAry(dn_h.ln_h[i].mkdno);

                        /*�d�n����������       */
    					dataRow[OrderSndRcvJnlSchema.ct_Col_EOAlwcCount] = UoeCommonFnc.ToInt32FromByteStrAry(dn_h.ln_h[i].eosu);


		            }
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

                ms.Read(dn_h.jkbn, 0, dn_h.jkbn.Length);		    // ���敪					   
                ms.Read(dn_h.seq_no, 0, dn_h.seq_no.Length);	    // �e�L�X�g�V�[�P���X�ԍ�	   
                ms.Read(dn_h.text_len, 0, dn_h.text_len.Length);    //				// �e�L�X�g��				   
                ms.Read(dn_h.dkbn, 0, dn_h.dkbn.Length);		    // �d���敪					   
                ms.Read(dn_h.kekka, 0, dn_h.kekka.Length);		    // ��������					   
                ms.Read(dn_h.tokbn, 0, dn_h.tokbn.Length);		    // �⍇���^�����敪			   
                ms.Read(dn_h.g_id, 0, dn_h.g_id.Length);		    // �Ɩ��h�c					   
                ms.Read(dn_h.g_pass, 0, dn_h.g_pass.Length);	    // �Ɩ��p�X���[�h			   
                ms.Read(dn_h.prog_ver, 0, dn_h.prog_ver.Length);    // �[���v���O�����o�[�W�����ԍ�
                ms.Read(dn_h.kkbn, 0, dn_h.kkbn.Length);		    // �p���敪					   
                ms.Read(dn_h.h_id, 0, dn_h.h_id.Length);		    // �����h�c					   
                ms.Read(dn_h.ext, 0, dn_h.ext.Length);			    // �g���G���A				   
                ms.Read(dn_h.syori_cd, 0, dn_h.syori_cd.Length);    // �����R�[�h				   
                ms.Read(dn_h.out_ren, 0, dn_h.out_ren.Length);	    // �o�͒ʔ�					   
                ms.Read(dn_h.saisou, 0, dn_h.saisou.Length);	    // �đ�����					   
                ms.Read(dn_h.user_cd, 0, dn_h.user_cd.Length);	    // ���[�U�[�R�[�h			   
                ms.Read(dn_h.tori_cd, 0, dn_h.tori_cd.Length);	    // �����  �R�[�h			   
                ms.Read(dn_h.nhkb, 0, dn_h.nhkb.Length);		    // �[�i�敪					   
                ms.Read(dn_h.iracd, 0, dn_h.iracd.Length);		    // �˗��҃R�[�h				   
                ms.Read(dn_h.kyoten, 0, dn_h.kyoten.Length);	    // �w�苒�_					   
                ms.Read(dn_h.bin, 0, dn_h.bin.Length);			    // ��      					   
                ms.Read(dn_h.rem, 0, dn_h.rem.Length);			    // ���}�[�N  				   
                ms.Read(dn_h.rem2, 0, dn_h.rem2.Length);		    // ���}�[�N�Q  				   
                ms.Read(dn_h.ermsg, 0, dn_h.ermsg.Length);		    // �G���[���b�Z�[�W			   

				//���ו�
				for (int i = 0; i < ctBufLen; i++)
				{
                    LN_H _ln_h = dn_h.ln_h[i];

	                ms.Read(_ln_h.hadt, 0, _ln_h.hadt.Length);		// ���i�ԍ�					   
	                ms.Read(_ln_h.bo, 0, _ln_h.bo.Length);			// �a�^�n�敪				   
	                ms.Read(_ln_h.knm, 0, _ln_h.knm.Length);		// �i��						   
	                ms.Read(_ln_h.hasu, 0, _ln_h.hasu.Length);		// ��������					   
	                ms.Read(_ln_h.bos, 0, _ln_h.bos.Length);		// �a�^�n�����				   
	                ms.Read(_ln_h.kysu, 0, _ln_h.kysu.Length);		// ���_   �o�ɐ�               
	                ms.Read(_ln_h.kydno, 0, _ln_h.kydno.Length);	//        �[�i���m�n		   
	                ms.Read(_ln_h.skzk, 0, _ln_h.skzk.Length);		//        �d�|�݌Ɉ��������    
	                ms.Read(_ln_h.skzd, 0, _ln_h.skzd.Length);		//        �d�|�݌Ɉ����\��     
	                ms.Read(_ln_h.skzs, 0, _ln_h.skzs.Length);		//        �d�|�݌Ɉ�������     
	                ms.Read(_ln_h.shcd, 0, _ln_h.shcd.Length);		// �r�r   ���_����			   
	                ms.Read(_ln_h.shsu, 0, _ln_h.shsu.Length);		//        �o�ɐ�			   
	                ms.Read(_ln_h.shdno, 0, _ln_h.shdno.Length);	//        �[�i���m�n		   
	                ms.Read(_ln_h.shzk, 0, _ln_h.shzk.Length);		//        �d�|�݌Ɉ��������    
	                ms.Read(_ln_h.hocd, 0, _ln_h.hocd.Length);		// �l�r   ���_����			   
	                ms.Read(_ln_h.hosu, 0, _ln_h.hosu.Length);		//        �o�ɐ�			   
	                ms.Read(_ln_h.hodno, 0, _ln_h.hodno.Length);	//        �[�i���m�n		   
	                ms.Read(_ln_h.hozk, 0, _ln_h.hozk.Length);		//        �d�|�݌Ɉ��������    
	                ms.Read(_ln_h.f3cd, 0, _ln_h.f3cd.Length);		// ���̑� ���_����			   
	                ms.Read(_ln_h.f3su, 0, _ln_h.f3su.Length);		//        �o�ɐ�			   
	                ms.Read(_ln_h.f3dno, 0, _ln_h.f3dno.Length);	//        �[�i���m�n		   

	                ms.Read(_ln_h.hzan, 0, _ln_h.hzan.Length);		// �����c������				   
	                ms.Read(_ln_h.fzan, 0, _ln_h.fzan.Length);		// �s����      				   
	                ms.Read(_ln_h.eohb, 0, _ln_h.eohb.Length);		// Ұ��E/O�������i�ԍ�		   
	                ms.Read(_ln_h.eosu, 0, _ln_h.eosu.Length);		// Ұ��E/O������      		   
	                ms.Read(_ln_h.mksu, 0, _ln_h.mksu.Length);		// Ұ��B/O��        		   
	                ms.Read(_ln_h.nkkb, 0, _ln_h.nkkb.Length);		// �\��[���敪     		   
	                ms.Read(_ln_h.ytmd, 0, _ln_h.ytmd.Length);		// �[���\���       		   
	                ms.Read(_ln_h.mkdno, 0, _ln_h.mkdno.Length);	// �a�^�n�Ǘ���				   
	                ms.Read(_ln_h.azaid, 0, _ln_h.azaid.Length);	// �S�Ѝ݌ɕ\��				   
	                ms.Read(_ln_h.azais, 0, _ln_h.azais.Length);	// �S�Ѝ݌ɐ�  				   
	                ms.Read(_ln_h.teika, 0, _ln_h.teika.Length);	// �E�v(�艿)				   
	                ms.Read(_ln_h.tanka, 0, _ln_h.tanka.Length);	// �d�؉��i					   
	                ms.Read(_ln_h.sob, 0, _ln_h.sob.Length);		// ���i�w��					   
	                ms.Read(_ln_h.lmsg, 0, _ln_h.lmsg.Length);		// ײ�ү����				   

	                ms.Read(_ln_h.bomsg, 0, _ln_h.bomsg.Length);	// �i���ʁj�a�^�nү���ދ敪	   
	                ms.Read(_ln_h.bosu, 0, _ln_h.bosu.Length);		// �i���ʁj�a�^�n��            
	                ms.Read(_ln_h.sinb, 0, _ln_h.sinb.Length);		// �Q����O�V���{��            
				}

                ms.Read(dn_h.tuser_cd, 0, dn_h.tuser_cd.Length);    // �[���Ή����[�U�[�R�[�h	   
                ms.Read(dn_h.mkmdhms, 0, dn_h.mkmdhms.Length);	    // Ұ���񓚖⍇���� MMDDHHMMSS 
                ms.Read(dn_h.mkkb, 0, dn_h.mkkb.Length);		    // Ұ���敪					   
                ms.Read(dn_h.dnymdhm, 0, dn_h.dnymdhm.Length);	    // �d�����M����   YYYYMMDDHHMM 
                ms.Read(dn_h.dummy, 0, dn_h.dummy.Length);		    // �\��                        

				ms.Close();
			}
			# endregion


			# endregion
		}
		# endregion
		# endregion


	}
}

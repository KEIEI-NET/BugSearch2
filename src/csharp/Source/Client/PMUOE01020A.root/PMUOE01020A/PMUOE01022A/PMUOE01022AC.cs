//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �t�n�d��M�ҏW�����ρ��i���Y�m�p�[�c�j�A�N�Z�X�N���X
// �v���O�����T�v   : �t�n�d��M�ҏW�����ρ��i���Y�m�p�[�c�j���s��
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
	/// �t�n�d��M�ҏW�����ρ��i���Y�m�p�[�c�j�A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �t�n�d��M�ҏW�����ρ��i���Y�m�p�[�c�j�A�N�Z�X�N���X</br>
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

		# region �t�n�d��M�ҏW�����ρ��i���Y�m�p�[�c�j
		/// <summary>
		/// �t�n�d��M�ҏW�����ρ��i���Y�m�p�[�c�j
		/// </summary>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        private int GetJnlEstmt0202(out string message)
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
                    TelegramJnlEstmt0202 telegramJnlEstmt0202 = new TelegramJnlEstmt0202();

                    //�i�m�k�X�V����
                    foreach (UoeRecDtl dtl in uoeRecDtlList)
                    {
                        telegramJnlEstmt0202.Telegram(_uoeRecHed.UOESupplierCd, dtl);
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

		# region �t�n�d��M�d���쐬�����ρ��i���Y�m�p�[�c�j
		/// <summary>
		/// �t�n�d��M�d���쐬�����ρ��i���Y�m�p�[�c�j
		/// </summary>
		public class TelegramJnlEstmt0202 : UoeRecEdit0202Acs
		{
			# region �o�l�V�\�[�X
            ////-- �d���̈�...�{��...���� -------------------------------------------
            //struct	LN_M {							//                             
            //	char	ghjkn [ 2];					// ײ�      �݊������i����	   
            //    char	hb    [12];					// 			�Ɖ�i�ԍ�	   
            //	char	hn    [15];					// 			���i����		   
            //	char	msu   [ 3];					// 			���ϐ�			   
            //	char	tanka [ 7];					// 			���ϒP��    	   
            //	char	teika [ 7];					// 			��]�������i	   
            //	char	sob   [ 2];					// 			���i�w��		   
            //	char	sktan [ 7];					// 			�d�ؒP��           
            //	char	kyo   [ 3];					// 			���_               
            //	char	cen   [ 3];					// 			��޾���			   
            //	char	mai   [ 3];					// 			���C��			   
            //};
            //struct	DN_MIT {						//                             
            //	char	jh     [ 1];				// TTC  ���敪   		       
            //	char	ts     [ 2];				//      ÷�ļ��ݽ  	    	   
            //	char	lg     [ 2];				// 		÷�Ē�				   
            //	char	dbkb   [ 1];				// ͯ�� �d���敪			   
            //	char	res    [ 1];				//      ��������			   
            //	char	toikb  [ 1];				//      �₢���킹�E�����敪   
            //	char	gyoid  [12];				//      �Ɩ�ID				   
            //	char	pass   [ 6];				//      �Ɩ��߽ܰ��		   
            //	char	vers   [ 3];				//      �[��PG�ް�ޮ�		   
            //	char	keikb  [ 1];				//      �p���敪			   
            //	char	trid   [ 3];				//      ���ID				   
            //	char	exten  [15];				//      �g���G���A			   
            //	char	syocd  [ 2];				//      �����R�[�h			   
            //	char	user   [ 6];				//      հ�ް����			   
            //	char	reto   [ 3];				//      ڰ�					   
            //	char	senc   [ 1];				//      �I����			   
            //	char	rem    [10];				//      �R�����g	 		   
            //	struct	LN_M  m[10];				// ײ�       67*10=670�޲�     
            //    char	uscd   [ 6];	            // �[���Ή�հ�ް����   		   
            //	char	dummy[1332];				// dummy 			           
            //};
            # endregion

			# region Const Members
			private const Int32 ctBufLen = 10;		//���׃o�b�t�@�T�C�Y
			# endregion

			# region Private Members
			//�ϐ�
			private Int32 _detailMax = 0;
			private DN_M dn_m = new DN_M(); 
			# endregion

			# region �d���̈�N���X
			/// <summary>
			/// ���ϓd���̈恃���C����
			/// </summary>
			private class LN_M
			{
                public byte[] ghjkn = new byte[2];					// ײ�      �݊������i����	   
                public byte[] hb = new byte[12];					// 			�Ɖ�i�ԍ�	   
                public byte[] hn = new byte[15];					// 			���i����		   
                public byte[] msu = new byte[3];					// 			���ϐ�			   
                public byte[] tanka = new byte[7];					// 			���ϒP��    	   
                public byte[] teika = new byte[7];					// 			��]�������i	   
                public byte[] sob = new byte[2];					// 			���i�w��		   
                public byte[] sktan = new byte[7];					// 			�d�ؒP��           
                public byte[] kyo = new byte[3];					// 			���_               
                public byte[] cen = new byte[3];					// 			��޾���			   
                public byte[] mai = new byte[3];					// 			���C��			   

				public LN_M()
				{
					Clear(0x00);
				}
				public void Clear(byte cd)
				{
	                UoeCommonFnc.MemSet(ref ghjkn, cd, ghjkn.Length);		// ײ�      �݊������i����	   
	                UoeCommonFnc.MemSet(ref hb, cd, hb.Length);			// 			�Ɖ�i�ԍ�	   
	                UoeCommonFnc.MemSet(ref hn, cd, hn.Length);				// 			���i����		   
	                UoeCommonFnc.MemSet(ref msu, cd, msu.Length);			// 			���ϐ�			   
	                UoeCommonFnc.MemSet(ref tanka, cd, tanka.Length);		// 			���ϒP��    	   
	                UoeCommonFnc.MemSet(ref teika, cd, teika.Length);		// 			��]�������i	   
	                UoeCommonFnc.MemSet(ref sob, cd, sob.Length);			// 			���i�w��		   
	                UoeCommonFnc.MemSet(ref sktan, cd, sktan.Length);		// 			�d�ؒP��           
	                UoeCommonFnc.MemSet(ref kyo, cd, kyo.Length);			// 			���_               
	                UoeCommonFnc.MemSet(ref cen, cd, cen.Length);			// 			��޾���			   
	                UoeCommonFnc.MemSet(ref mai, cd, mai.Length);			// 			���C��			   
				}
			}

			/// <summary>
			/// ���ϓd���̈恃�{�́�
			/// </summary>
			private class DN_M
			{
	            public byte[]	jh      = new byte[ 1];				// TTC  ���敪   		       
	            public byte[]	ts      = new byte[ 2];				//      ÷�ļ��ݽ  	    	   
	            public byte[]	lg      = new byte[ 2];				// 		÷�Ē�				   
	            public byte[]	dbkb    = new byte[ 1];				// ͯ�� �d���敪			   
	            public byte[]	res     = new byte[ 1];				//      ��������			   
	            public byte[]	toikb   = new byte[ 1];				//      �₢���킹�E�����敪   
	            public byte[]	gyoid   = new byte[12];				//      �Ɩ�ID				   
	            public byte[]	pass    = new byte[ 6];				//      �Ɩ��߽ܰ��		   
	            public byte[]	vers    = new byte[ 3];				//      �[��PG�ް�ޮ�		   
	            public byte[]	keikb   = new byte[ 1];				//      �p���敪			   
	            public byte[]	trid    = new byte[ 3];				//      ���ID				   
	            public byte[]	exten   = new byte[15];				//      �g���G���A			   
	            public byte[]	syocd   = new byte[ 2];				//      �����R�[�h			   
	            public byte[]	user    = new byte[ 6];				//      հ�ް����			   
	            public byte[]	reto    = new byte[ 3];				//      ڰ�					   
	            public byte[]	senc    = new byte[ 1];				//      �I����			   
	            public byte[]	rem     = new byte[10];				//      �R�����g	 		   
				public LN_M[] ln_m = new LN_M[ctBufLen];	        // ײ�       14*10=140�޲�
                public byte[]	uscd    = new byte[ 6];	            // �[���Ή�հ�ް����   		   
	            public byte[]	dummy   = new byte[1332];			// dummy 			           

				/// <summary>	
				/// �R���X�g���N�^�[
				/// </summary>
				public DN_M()
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
	                UoeCommonFnc.MemSet(ref user, cd, user.Length);			//      հ�ް����			   
	                UoeCommonFnc.MemSet(ref reto, cd, reto.Length);			//      ڰ�					   
	                UoeCommonFnc.MemSet(ref senc, cd, senc.Length);			//      �I����			   
	                UoeCommonFnc.MemSet(ref rem, cd, rem.Length);			//      �R�����g	 		   

					//���ו�
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
                    
                    UoeCommonFnc.MemSet(ref uscd, cd, uscd.Length);	        // �[���Ή�հ�ް����   		   
	                UoeCommonFnc.MemSet(ref dummy, cd, dummy.Length);		// dummy 			           
				}
			}
			# endregion

			# region Constructors
			/// <summary>
			/// �R���X�g���N�^
			/// </summary>
			public TelegramJnlEstmt0202()
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
				dn_m.Clear(0x00);
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
					DataRow dataRow = _uoeSndRcvJnlAcs.JnlEstmtTblRead(
													uOESupplierCd,
													dtl.UOESalesOrderNo,
													dtl.UOESalesOrderRowNo[i]);
					if (dataRow == null)
					{
						continue;
					}

                    // ��M���t
                    dataRow[EstmtSndRcvJnlSchema.ct_Col_ReceiveDate] = DateTime.Now;

                    // ��M����
                    dataRow[EstmtSndRcvJnlSchema.ct_Col_ReceiveTime] = TDateTime.DateTimeToLongDate("HHMMSS", DateTime.Now);

                    //�w�b�_�[�G���[�̊i�[����
                    //�w�b�_�[�G���[�Ȃ�
                    if (dn_m.res[0] == 0x00)
                    {
                    }
                    //�w�b�_�[�G���[����
                    else
                    {
                        string errMessage = GetHeadErrorMassage(dn_m.res[0]);

                        //�w�b�h�G���[���b�Z�[�W
                        dataRow[EstmtSndRcvJnlSchema.ct_Col_HeadErrorMassage] = errMessage;

                        //���C���G���[���b�Z�[�W
                        dataRow[EstmtSndRcvJnlSchema.ct_Col_LineErrorMassage] = errMessage;

                        //�i��
                        dataRow[EstmtSndRcvJnlSchema.ct_Col_AnswerPartsName] = errMessage;
                    }

		            // ���[�g
                    dataRow[EstmtSndRcvJnlSchema.ct_Col_EstimateRate] = String.Format("{0:D3}",
                                                                            UoeCommonFnc.ToInt32FromByteStrAry(dn_m.reto) * 10);
                    // �I���R�[�h
                    dataRow[EstmtSndRcvJnlSchema.ct_Col_SelectCode] = UoeCommonFnc.ToStringFromByteStrAry(dn_m.senc);

		            // ���}�[�N
                    dataRow[EstmtSndRcvJnlSchema.ct_Col_UoeRemark1] = UoeCommonFnc.ToStringFromByteStrAry(dn_m.rem);

		            // �i��
                    dataRow[EstmtSndRcvJnlSchema.ct_Col_AnswerPartsNo] = UoeCommonFnc.ToStringFromByteStrAry(dn_m.ln_m[i].hb);

                    // ��֕i��
                    dataRow[EstmtSndRcvJnlSchema.ct_Col_SubstPartsNo] = UoeCommonFnc.ToStringFromByteStrAry(dn_m.ln_m[i].hn);

		            // �i��
                    //�w�b�_�[�G���[�Ȃ�
                    if (dn_m.res[0] == 0x00)
                    {
                        dataRow[EstmtSndRcvJnlSchema.ct_Col_AnswerPartsName] = UoeCommonFnc.ToStringFromByteStrAry(dn_m.ln_m[i].hn);
                    }

		            // ���ϒP��
                    dataRow[EstmtSndRcvJnlSchema.ct_Col_SalesUnPrcTaxExcFl] = UoeCommonFnc.ToDoubleFromByteStrAry(dn_m.ln_m[i].tanka);

		            // �݊����R�[�h
                    dataRow[EstmtSndRcvJnlSchema.ct_Col_UOESubstCode] = UoeCommonFnc.ToStringFromByteStrAry(dn_m.ln_m[i].ghjkn);

		            // �d�ؒP��
                    dataRow[EstmtSndRcvJnlSchema.ct_Col_AnswerSalesUnitCost] = UoeCommonFnc.ToDoubleFromByteStrAry(dn_m.ln_m[i].sktan);

		            // �艿
                    dataRow[EstmtSndRcvJnlSchema.ct_Col_AnswerListPrice] = UoeCommonFnc.ToDoubleFromByteStrAry(dn_m.ln_m[i].tanka);

		            // ���_�݌ɐ�
                    dataRow[EstmtSndRcvJnlSchema.ct_Col_BranchStock] = UoeCommonFnc.ToInt32FromByteStrAry(dn_m.ln_m[i].kyo);

		            // �Z���^�[�݌ɐ�
                    dataRow[EstmtSndRcvJnlSchema.ct_Col_SectionStock] = UoeCommonFnc.ToInt32FromByteStrAry(dn_m.ln_m[i].cen);

		            // ���[�J�[�i���C���j�݌ɐ�
                    dataRow[EstmtSndRcvJnlSchema.ct_Col_HeadQtrsStock] = UoeCommonFnc.ToInt32FromByteStrAry(dn_m.ln_m[i].mai);

		            // �w��
                    dataRow[EstmtSndRcvJnlSchema.ct_Col_PartsLayerCd] = UoeCommonFnc.ToStringFromByteStrAry(dn_m.ln_m[i].sob);

					//�f�[�^���M�敪
                    dataRow[EstmtSndRcvJnlSchema.ct_Col_DataSendCode] = dtl.DataSendCode;

					//�f�[�^�����敪
					dataRow[EstmtSndRcvJnlSchema.ct_Col_DataRecoverDiv] = dtl.DataRecoverDiv;
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

                ms.Read(dn_m.jh, 0, dn_m.jh.Length);			// TTC  ���敪   		       
                ms.Read(dn_m.ts, 0, dn_m.ts.Length);			//      ÷�ļ��ݽ  	    	   
                ms.Read(dn_m.lg, 0, dn_m.lg.Length);			// 		÷�Ē�				   
                ms.Read(dn_m.dbkb, 0, dn_m.dbkb.Length);		// ͯ�� �d���敪			   
                ms.Read(dn_m.res, 0, dn_m.res.Length);			//      ��������			   
                ms.Read(dn_m.toikb, 0, dn_m.toikb.Length);		//      �₢���킹�E�����敪   
                ms.Read(dn_m.gyoid, 0, dn_m.gyoid.Length);		//      �Ɩ�ID				   
                ms.Read(dn_m.pass, 0, dn_m.pass.Length);		//      �Ɩ��߽ܰ��		   
                ms.Read(dn_m.vers, 0, dn_m.vers.Length);		//      �[��PG�ް�ޮ�		   
                ms.Read(dn_m.keikb, 0, dn_m.keikb.Length);		//      �p���敪			   
                ms.Read(dn_m.trid, 0, dn_m.trid.Length);		//      ���ID				   
                ms.Read(dn_m.exten, 0, dn_m.exten.Length);		//      �g���G���A			   
                ms.Read(dn_m.syocd, 0, dn_m.syocd.Length);		//      �����R�[�h			   
                ms.Read(dn_m.user, 0, dn_m.user.Length);		//      հ�ް����			   
                ms.Read(dn_m.reto, 0, dn_m.reto.Length);		//      ڰ�					   
                ms.Read(dn_m.senc, 0, dn_m.senc.Length);		//      �I����			   
                ms.Read(dn_m.rem, 0, dn_m.rem.Length);			//      �R�����g	 		   

				//���ו�
				for (int i = 0; i < ctBufLen; i++)
				{
                    LN_M _ln_m = dn_m.ln_m[i];

	                ms.Read(_ln_m.ghjkn, 0, _ln_m.ghjkn.Length);		// ײ�      �݊������i����	   
	                ms.Read(_ln_m.hb, 0, _ln_m.hb.Length);			    // 			�Ɖ�i�ԍ�	   
	                ms.Read(_ln_m.hn, 0, _ln_m.hn.Length);				// 			���i����		   
	                ms.Read(_ln_m.msu, 0, _ln_m.msu.Length);			// 			���ϐ�			   
	                ms.Read(_ln_m.tanka, 0, _ln_m.tanka.Length);		// 			���ϒP��    	   
	                ms.Read(_ln_m.teika, 0, _ln_m.teika.Length);		// 			��]�������i	   
	                ms.Read(_ln_m.sob, 0, _ln_m.sob.Length);			// 			���i�w��		   
	                ms.Read(_ln_m.sktan, 0, _ln_m.sktan.Length);		// 			�d�ؒP��           
	                ms.Read(_ln_m.kyo, 0, _ln_m.kyo.Length);			// 			���_               
	                ms.Read(_ln_m.cen, 0, _ln_m.cen.Length);			// 			��޾���			   
	                ms.Read(_ln_m.mai, 0, _ln_m.mai.Length);			// 			���C��			   
				}

                ms.Read(dn_m.uscd, 0, dn_m.uscd.Length);	    // �[���Ή�հ�ް����   		   
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

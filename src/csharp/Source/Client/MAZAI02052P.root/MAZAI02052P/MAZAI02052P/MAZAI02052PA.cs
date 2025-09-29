//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �݌Ɏd���m�F�\
// �v���O�����T�v   : �݌Ɏd���m�F�\�̈�����s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : amami
// �� �� ��  2007/03/15  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���� ��`
// �C �� ��  2007/10/04  �C�����e : DC.NS�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���� ��`
// �C �� ��  2008/01/24  �C�����e : DC.NS�Ή��i�s��Ή��j
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Ɠc �M�u
// �C �� ��  2008/10/07  �C�����e : �o�O�C���A�d�l�ύX�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Ɠc �M�u
// �C �� ��  2009/01/23  �C�����e : �s��Ή�[10420]
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��� �r��
// �C �� ��  2009/04/07  �C�����e : �s��Ή�[13059]
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11370074-00 �쐬�S�� : 3H �k�P�N
// �C �� ��  2017/09/11 �C�����e : �n���f�B�Ή��i2���j�݌ɕ�[���̈�����\�Ή�
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Drawing.Printing;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Drawing.Printing
{
	/// <summary>
	/// �݌ɒ����m�F�\����N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �݌ɒ����m�F�\�̈�����s���B</br>
	/// <br>Programmer : 97036 amami</br>
	/// <br>Date       : 2007.03.15</br>
    /// <br>UpdateNote : 2007.10.04 980035 ���� ��`</br>
    /// <br>             �E DC.NS�Ή�</br>
    /// <br>UpdateNote : 2008.01.24 980035 ���� ��`</br>
    /// <br>			 �E DC.NS�Ή��i�s��Ή��j</br>
    /// <br>UpdateNote : 2008/10/07        �Ɠc �M�u</br>
    /// <br>			 �E�o�O�C���A�d�l�ύX�Ή�</br>
    /// <br>             2009/01/23        �Ɠc �M�u�@�s��Ή�[10420]</br>
    /// <br>Update Note: 2009/04/07 30452 ��� �r��</br>
    /// <br>            �E��Q�Ή�13059</br>
    /// <br>Update Note: 2017/09/11 3H �k�P�N</br>
    /// <br>�Ǘ��ԍ�   : 11370074-00 �n���f�B�Ή��i2���j</br>
    /// <br>             �݌ɕ�[���̈�����\�Ή�</br>
    /// </remarks>
	class MAZAI02052PA: IPrintProc
	{

		# region Constructor
		/// <summary>
		/// �݌ɒ����m�F�\����N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �݌ɒ����m�F�\����N���X�̃C���X�^���X�̍쐬���s���B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2007.03.15</br>
		/// </remarks>
		public MAZAI02052PA()
		{
		}

		/// <summary>
		/// �݌ɒ����m�F�\����N���X�R���X�g���N�^
		/// </summary>
		/// <param name="printInfo">������I�u�W�F�N�g</param>
		/// <remarks>
		/// <br>Note       : �݌ɒ����m�F�\����N���X�̃C���X�^���X�̍쐬���s���B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2007.03.15</br>
		/// </remarks>
		public MAZAI02052PA( object printInfo )
		{
			this._printInfo = printInfo as SFCMN06002C;
			this._confirmStockAdjustListCndtn = this._printInfo.jyoken as ConfirmStockAdjustListCndtn;
		}
		# endregion

		# region Pricate Const
		/// <summary> ����t�H�[���l�[���X�y�[�X </summary>
		private const string ct_ReportForm_NameSpace = "Broadleaf.Drawing.Printing";
		/// <summary> �X�y�[�X(����p) </summary>
		private const string ct_Space = "�@";
		/// <summary> �J�n ���o�͈͏����l(����p) </summary>
        //private const string ct_Extr_Top = "�s�n�o";          // DEL 2008.07.08
        private const string ct_Extr_Top = "�ŏ�����";          // ADD 2008.07.08
        /// <summary> �I�� ���o�͈͏����l(����p) </summary>
        //private const string ct_Extr_End = "�d�m�c";          // DEL 2008.07.08
        private const string ct_Extr_End = "�Ō�܂�";          // ADD 2008.07.08
        # endregion

		# region Private Member
		/// <summary> ������N���X </summary>
		private SFCMN06002C _printInfo;
		/// <summary> ���o�����N���X </summary>
		private ConfirmStockAdjustListCndtn _confirmStockAdjustListCndtn;
		# endregion

		# region Exception Class
		/// <summary> ��O�N���X </summary>
        private class ConfirmStockAdjustException: ApplicationException
		{
			private int _status;
			# region Constructor
			/// <summary>
			/// ��O�N���X�R���X�g���N�^
			/// </summary>
			/// <param name="message">���b�Z�[�W</param>
			/// <param name="status">�X�e�[�^�X</param>
			public ConfirmStockAdjustException(string message, int status) : base(message)
			{
				this._status = status; 
			}
			# endregion
    
			# region Public Property
			/// <summary> �X�e�[�^�X�v���p�e�B </summary>
			public int Status
			{
				get{ return this._status; }
			}
			# endregion
		}
		# endregion
		


		# region IPrintProc �C���^�[�t�F�[�X
		# region Public Property
		/// <summary>
		/// ������擾�v���p�e�B
		/// </summary>
		public SFCMN06002C Printinfo
		{
			get { return this._printInfo; }
			set { this._printInfo = value;}
		}
		# endregion

		# region Public Method
		/// <summary>
		/// ��������J�n
		/// </summary>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : ������J�n����B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2007.03.15</br>
		/// </remarks>
		public int StartPrint()
		{
			// �������
			return PrintMain();
		}
		# endregion
		# endregion 

		# region Private Method
		/// <summary>
		/// �������
		/// </summary>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : ����������s���B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2007.03.15</br>
		/// </remarks>
		private int PrintMain()
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			// ����t�H�[���N���X�C���X�^���X�쐬
			DataDynamics.ActiveReports.ActiveReport3 prtRpt = null;
			
			try
			{
				// �e��ActiveReport���[�C���X�^���X�쐬
				this.CreateReport(out prtRpt, this._printInfo.prpid); 
				if (prtRpt == null) return status;

				// �e��v���p�e�B�ݒ�
				status = this.SettingProperty(ref prtRpt);
				if (status != 0) return status;
							
				// �f�[�^�\�[�X�ݒ�
				prtRpt.DataSource = (DataView)this._printInfo.rdData;
                prtRpt.DataMember = MAZAI02054EA.ct_Tbl_StockAdjustDtl;
				
				// ������ʏ��v���p�e�B�ݒ�
				Broadleaf.Windows.Forms.SFCMN00293UC commonInfo;
			    this.SetPrintCommonInfo(out commonInfo);

			    // �v���r���[�L��				
			    int mode = this._printInfo.prevkbn;
				
			    // �o�̓��[�h���o�c�e�̏ꍇ�A�������Ńv���r���[��
			    if (this._printInfo.printmode == 2)
			    {
			        mode = 0;
			    }
				
			    switch(mode)
			    {
			        case 0:		// �v���r����
			        {
			            Broadleaf.Windows.Forms.SFCMN00293UB processForm = new Broadleaf.Windows.Forms.SFCMN00293UB();
						
			            // ���ʏ����ݒ�
			            processForm.CommonInfo = commonInfo;

			            // �v���O���X�o�[UP�C�x���g�ǉ�
			            if (prtRpt is IPrintActiveReportTypeCommon)
			            {
			                ((IPrintActiveReportTypeCommon)prtRpt).ProgressBarUpEvent +=
			                    new ProgressBarUpEventHandler(processForm.ProgressBarUpEvent);
			            }

			            // ������s
			            status = processForm.Run(prtRpt);

			            // �߂�l�ݒ�
			            this._printInfo.status = status;

			            break;
			        }
			        case 1:		// �v���r���L
			        {
			            Broadleaf.Windows.Forms.SFCMN00293UA viewForm = new Broadleaf.Windows.Forms.SFCMN00293UA();

			            // ���ʏ����ݒ�
			            viewForm.CommonInfo   = commonInfo;

			            // �v���r���[���s
			            status = viewForm.Run(prtRpt); 

			            // �߂�l�ݒ�
			            this._printInfo.status = status;
						
			            break;
			        }
			    }

			    // �o�c�e�o�͂̏ꍇ
			    if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
			    {
			        switch (this._printInfo.printmode)
			        {
			            case 1:  // �v�����^
			                break;
			            case 2:  // �o�c�e
			            case 3:  // ����(�v�����^ + �o�c�e)
			            {
			                // �o�c�e�\���t���OON
			                this._printInfo.pdfopen = true;
   
			                // ����������̂ݗ���ۑ�
			                if (this._printInfo.printmode == 3)
			                {
			                    // �o�͗����Ǘ��ɒǉ�
			                    Broadleaf.Windows.Forms.SFANL06101UA pdfHistoryControl = new Broadleaf.Windows.Forms.SFANL06101UA();
			                    pdfHistoryControl.AddPrintInfo(this._printInfo.key, this._printInfo.prpnm, this._printInfo.prpnm,
			                        this._printInfo.pdftemppath);
			                }
			                break;
			            }
			        }
			    }
			}
			catch(Exception ex)
			{
			    this.MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP,
			        ex.Message, -1, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
			}
			finally
			{
			    if ( prtRpt != null )
			    {
			        prtRpt.Dispose();
			    }
			}
			return status;
		}

		/// <summary>
		/// �e��ActiveReport���[�C���X�^���X�쐬
		/// </summary>
		/// <param name="rptObj">�C���X�^���X�����ꂽ���[�t�H�[���N���X</param>
		/// <param name="prpid">���[�t�H�[��ID</param>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : �w�肳�ꂽ�A�Z���u���y�уN���X�����A�N���X���C���X�^���X�����܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2007.03.15</br>
		/// </remarks>
		private void CreateReport(out DataDynamics.ActiveReports.ActiveReport3 rptObj,string prpid)
		{
			// ����t�H�[���N���X�C���X�^���X�쐬
			rptObj = (DataDynamics.ActiveReports.ActiveReport3)this.LoadAssemblyReport(
				prpid.Trim(), ct_ReportForm_NameSpace + "." + prpid.Trim(), 
				typeof(DataDynamics.ActiveReports.ActiveReport3));
		}

		/// <summary>
		/// ���|�[�g�A�Z���u���C���X�^���X��
		/// </summary>
		/// <param name="asmname">�A�Z���u������</param>
		/// <param name="classname">�N���X����</param>
		/// <param name="type">��������N���X�^</param>
		/// <returns>�C���X�^���X�����ꂽ�N���X</returns>
		/// <remarks>
		/// <br>Note       : �w�肳�ꂽ�A�Z���u���y�уN���X�����A�N���X���C���X�^���X�����܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2007.03.15</br>
		/// </remarks>
		private	object LoadAssemblyReport(string asmname, string classname, Type type)
		{
			object	obj	= null;
			try
			{
				System.Reflection.Assembly	asm	= System.Reflection.Assembly.Load(asmname);
				Type	objType	= asm.GetType(classname);
				if (objType != null)
				{
					if ((objType == type) || (objType.IsSubclassOf(type) == true) || (objType.GetInterface(type.Name).Name == type.Name))
					{
						obj = Activator.CreateInstance(objType);
					}
				}
			}
			catch(System.IO.FileNotFoundException)
			{
				throw new ConfirmStockAdjustException(asmname + "�����݂��܂���B", -1);
			}
			catch(System.Exception er)
			{
				throw new ConfirmStockAdjustException(er.Message, -1);
			}
			return obj;
		}

		/// <summary>
		/// �����ʋ��ʏ��ݒ�
		/// </summary>
		/// <param name="commonInfo"></param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �����ʋ��ʏ����̐ݒ���s���܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2007.03.15</br>
		/// </remarks>
		private void SetPrintCommonInfo(out Broadleaf.Windows.Forms.SFCMN00293UC commonInfo)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			commonInfo = new Broadleaf.Windows.Forms.SFCMN00293UC();
			
			// ���[�`���[�g���ʕ��i�N���X
			SFCMN00331C cmnCommon = new SFCMN00331C(); 

			// PDF�p�X�擾
			string pdfPath = "";
			string pdfName = "";
		
			// �v�����^��
			commonInfo.PrinterName = this._printInfo.prinm;
			// ���[��
			commonInfo.PrintName   = this._printInfo.prpnm;
			// ������[�h
			commonInfo.PrintMode   = this.Printinfo.printmode;
			// �������
			//commonInfo.PrintMax    = 0;                                           //DEL 2009/01/23 �s��Ή�[10420]
            commonInfo.PrintMax = (this._printInfo.rdData as DataView).Count;       //ADD 2009/01/23 �s��Ή�[10420]
			
			status = cmnCommon.GetPdfSavePathName(this._printInfo.prpnm, ref pdfPath, ref pdfName);
			this._printInfo.pdftemppath = pdfPath + pdfName;
			commonInfo.PdfFullPath = this._printInfo.pdftemppath;

			// ��]��
			commonInfo.MarginsTop  = this._printInfo.py;
			// ���]��
			commonInfo.MarginsLeft = this._printInfo.px;
		}

		/// <summary>
		/// �e��v���p�e�B�ݒ�
		/// </summary>
		/// <param name="rpt">�C���X�^���X�����ꂽ���[�t�H�[���N���X</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �e��v���p�e�B��ݒ肵�܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2007.03.15</br>
		/// </remarks>
		private int SettingProperty(ref DataDynamics.ActiveReports.ActiveReport3 rpt)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

			// ActiveReport�C���^�[�t�F�[�X�ɃL���X�g
			IPrintActiveReportTypeList instance = rpt as IPrintActiveReportTypeList;

			// ��������擾
            ConfirmStockAdjustListCndtn extraInfo = (ConfirmStockAdjustListCndtn)this._printInfo.jyoken;

			// ���[�o�͐ݒ���擾 
			PrtOutSet prtOutSet;
			string message;
			int st = StockAdjustListAcs.ReadPrtOutSet(out prtOutSet, out message);
			if (st != 0) 
			{
                throw new ConfirmStockAdjustException(message, status);
            }
			
			// ���o�����w�b�_�o�͋敪
			instance.ExtraCondHeadOutDiv = prtOutSet.ExtraCondHeadOutDiv;

			// ���o�����ҏW����
			StringCollection extraInfomations;
			this.MakeExtarCondition( out extraInfomations );

			instance.ExtraConditions = extraInfomations; 
			
			// �t�b�^�o�͋敪
			instance.PageFooterOutCode   = prtOutSet.FooterPrintOutCode;

			// �t�b�^�o�̓��b�Z�[�W
			StringCollection footers = new StringCollection();
			footers.Add(prtOutSet.PrintFooter1);
			footers.Add(prtOutSet.PrintFooter2);
			
			instance.PageFooters = footers;

			// ������I�u�W�F�N�g
			instance.PrintInfo = this._printInfo;

			// �w�b�_�[�T�u�^�C�g��
			instance.PageHeaderSubtitle = this._confirmStockAdjustListCndtn.PrintDivName;

			status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

			return status;
		}

		/// <summary>
		/// ���o�����o�͏��쐬
		/// </summary>
		/// <param name="extraConditions">�쐬�㒊�o�����R���N�V����</param>
		/// <remarks>
		/// <br>Note       : �o�͂��钊�o������������쐬����B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2007.03.15</br>
        /// <br>Update Note: 2017/09/11 3H �k�P�N</br>
        /// <br>�Ǘ��ԍ�   : 11370074-00 �n���f�B�Ή��i2���j</br>
        /// <br>             �݌ɕ�[���̈�����\�Ή�</br>
		/// </remarks>
		private void MakeExtarCondition( out StringCollection extraConditions )
		{
			const string ct_RangeConst = "�F{0} �` {1}";
			extraConditions = new StringCollection();

			// --- �������t --- //
			string st_AdjustDate = string.Empty;
			string ed_AdjustDate = string.Empty;
            
            //--- ADD 2008/07/08 ---------->>>>>
            // --- ���͓��t --- //
            string st_InputDay = string.Empty;
            string ed_InputDay = string.Empty;
            //--- ADD 2008/07/08 ----------<<<<<

            // �J�n
			if (this._confirmStockAdjustListCndtn.St_AdjustDate != DateTime.MinValue)
				st_AdjustDate = TDateTime.DateTimeToString(MAZAI02054EA.ct_DateFomat, this._confirmStockAdjustListCndtn.St_AdjustDate);
			else
				st_AdjustDate = ct_Extr_Top;
			// �I��
			if (this._confirmStockAdjustListCndtn.Ed_AdjustDate != DateTime.MinValue)
				ed_AdjustDate = TDateTime.DateTimeToString(MAZAI02054EA.ct_DateFomat, this._confirmStockAdjustListCndtn.Ed_AdjustDate);
			else
				ed_AdjustDate = ct_Extr_End;
            /* --- DEL 2008/10/07 �����ύX ---------------------------------------------------------------------------------------------------->>>>>
            //this.EditCondition(ref extraConditions, string.Format("�������t�@" + ct_RangeConst, st_AdjustDate, ed_AdjustDate)); // DEL 2008/09/26
            this.EditCondition(ref extraConditions, string.Format("�d�����t�@" + ct_RangeConst, st_AdjustDate, ed_AdjustDate));
               --- DEL 2008/10/07 -------------------------------------------------------------------------------------------------------------<<<<< */
            if (st_AdjustDate != ct_Extr_Top || ed_AdjustDate != ct_Extr_End) // ADD 2009/04/07
            {
                this.EditCondition(ref extraConditions, string.Format("�d�����@" + ct_RangeConst, st_AdjustDate, ed_AdjustDate));   //ADD 2008/10/07
            }
            //--- ADD 2008/07/08 ---------->>>>>
            // �J�n
            if (this._confirmStockAdjustListCndtn.St_InputDay != DateTime.MinValue)
                st_InputDay = TDateTime.DateTimeToString(MAZAI02054EA.ct_DateFomat, this._confirmStockAdjustListCndtn.St_InputDay);
            else
                st_InputDay = ct_Extr_Top; // ADD 2009/04/07
            // �I��
            if (this._confirmStockAdjustListCndtn.Ed_InputDay != DateTime.MinValue)
                ed_InputDay = TDateTime.DateTimeToString(MAZAI02054EA.ct_DateFomat, this._confirmStockAdjustListCndtn.Ed_InputDay);
            else
                ed_InputDay = ct_Extr_End; // ADD 2009/04/07

            //if(st_InputDay != string.Empty && ed_InputDay != string.Empty) // DEL 2009/04/07
            if (st_InputDay != ct_Extr_Top || ed_InputDay != ct_Extr_End) // ADD 2009/04/07
                //this.EditCondition(ref extraConditions, string.Format("���͓��t�@" + ct_RangeConst, st_InputDay, ed_InputDay));   //DEL 2008/10/07 �����ύX
                this.EditCondition(ref extraConditions, string.Format("���͓��@" + ct_RangeConst, st_InputDay, ed_InputDay));       //ADD 2008/10/07
            //--- ADD 2008/07/08 ----------<<<<<

			StringCollection addConditions = new StringCollection();

            //--- DEL 2008/07/08 ---------->>>>>
			// --- �����`�[�ԍ� --- //
            //if ((this._confirmStockAdjustListCndtn.St_StockAdjustSlipNo != 0) || (this._confirmStockAdjustListCndtn.Ed_StockAdjustSlipNo != 999999999))
            //{
            //    this.EditCondition( ref addConditions, 
            //        string.Format( "�����`�[�ԍ��F{0} �` {1}",
            //            String.Format("{0:D9}", this._confirmStockAdjustListCndtn.St_StockAdjustSlipNo),
            //            String.Format("{0:D9}", this._confirmStockAdjustListCndtn.Ed_StockAdjustSlipNo) 
            //        )
            //    );
            //}
            //--- DEL 2008/07/08 ----------<<<<<

            //--- DEL 2008/07/08 ---------->>>>>
            //// --- ���[�J�[�R�[�h --- //
            //// 2007.10.04 �C�� >>>>>>>>>>>>>>>>>>>>
            ////if ((this._confirmStockAdjustListCndtn.St_MakerCode != 0) || (this._confirmStockAdjustListCndtn.Ed_MakerCode != 999))
            //if ((this._confirmStockAdjustListCndtn.St_GoodsMakerCd != 0) || (this._confirmStockAdjustListCndtn.Ed_GoodsMakerCd != 999999))
            //// 2007.10.04 �C�� <<<<<<<<<<<<<<<<<<<<
            //{
            //    this.EditCondition( ref addConditions, 
            //        string.Format( "���[�J�[�R�[�h�F{0} �` {1}",
            //            // 2007.10.04 �C�� >>>>>>>>>>>>>>>>>>>>
            //            //String.Format("{0:D}", this._confirmStockAdjustListCndtn.St_MakerCode),
            //            //String.Format("{0:D}", this._confirmStockAdjustListCndtn.Ed_MakerCode)
            //            String.Format("{0:D}", this._confirmStockAdjustListCndtn.St_GoodsMakerCd),
            //            String.Format("{0:D}", this._confirmStockAdjustListCndtn.Ed_GoodsMakerCd)
            //            // 2007.10.04 �C�� <<<<<<<<<<<<<<<<<<<<
            //        )
            //    );
            //}
            //--- DEL 2008/07/08 ----------<<<<<

			// --- ���i�R�[�h --- //
            // 2007.10.04 �C�� >>>>>>>>>>>>>>>>>>>>
			//if ((this._confirmStockAdjustListCndtn.St_GoodsCode != string.Empty ) || ( this._confirmStockAdjustListCndtn.Ed_GoodsCode != string.Empty))
			//{
			//	this.EditCondition( ref addConditions, 
			//		this.GetConditionRange( "���i�R�[�h", this._confirmStockAdjustListCndtn.St_GoodsCode, this._confirmStockAdjustListCndtn.Ed_GoodsCode));
			//}
            // 2009.02.16 30413 ���� ���i�R�[�h�͒��o�����ɖ����̂ō폜 >>>>>>START
            //if ((this._confirmStockAdjustListCndtn.St_GoodsNo != string.Empty) || (this._confirmStockAdjustListCndtn.Ed_GoodsNo != string.Empty))
            //{
            //    this.EditCondition(ref addConditions,
            //        this.GetConditionRange("���i�R�[�h", this._confirmStockAdjustListCndtn.St_GoodsNo, this._confirmStockAdjustListCndtn.Ed_GoodsNo));
            //}
            // 2009.02.16 30413 ���� ���i�R�[�h�͒��o�����ɖ����̂ō폜 <<<<<<END
            // 2007.10.04 �C�� <<<<<<<<<<<<<<<<<<<<

            // 2007.10.04 �폜 >>>>>>>>>>>>>>>>>>>>
            //// --- �����ԍ� --- //
            //if ((this._confirmStockAdjustListCndtn.St_ProductNumber != string.Empty ) || ( this._confirmStockAdjustListCndtn.Ed_ProductNumber != string.Empty))
			//{
			//	this.EditCondition( ref addConditions, 
            //		this.GetConditionRange( "�����ԍ�", this._confirmStockAdjustListCndtn.St_ProductNumber, this._confirmStockAdjustListCndtn.Ed_ProductNumber));
            //}
            //
            //// --- �d�b�ԍ� --- //
            //if ((this._confirmStockAdjustListCndtn.St_StockTelNo1 != string.Empty ) || ( this._confirmStockAdjustListCndtn.Ed_StockTelNo1 != string.Empty))
            //{
            //	this.EditCondition( ref addConditions, 
            //		this.GetConditionRange( "�d�b�ԍ�", this._confirmStockAdjustListCndtn.St_StockTelNo1, this._confirmStockAdjustListCndtn.Ed_StockTelNo1));
            //}
            // 2007.10.04 �폜 <<<<<<<<<<<<<<<<<<<<

            // 2009.02.16 30413 ���� �q�ɁA�S���ҁA���s�^�C�v�̏��ɒ��o�������󎚂���悤�ɏC�� >>>>>>START
            // 2008.01.24 �C�� >>>>>>>>>>>>>>>>>>>>
            // --- �q�ɃR�[�h --- //
            if ((this._confirmStockAdjustListCndtn.St_WarehouseCode != string.Empty) || (this._confirmStockAdjustListCndtn.Ed_WarehouseCode != string.Empty))
            {
                this.EditCondition(ref addConditions,
                    //this.GetConditionRange("�q�ɃR�[�h", this._confirmStockAdjustListCndtn.St_WarehouseCode, this._confirmStockAdjustListCndtn.Ed_WarehouseCode)); // DEL 2008/09/26
                    this.GetConditionRange("�q��", this._confirmStockAdjustListCndtn.St_WarehouseCode, this._confirmStockAdjustListCndtn.Ed_WarehouseCode));

            }
            // 2008.01.24 �C�� <<<<<<<<<<<<<<<<<<<<

			// --- �S���҃R�[�h --- //
			if ((this._confirmStockAdjustListCndtn.St_InputAgenCd != string.Empty ) || ( this._confirmStockAdjustListCndtn.Ed_InputAgenCd != string.Empty))
			{
				this.EditCondition( ref addConditions,
                    //this.GetConditionRange( "���͒S���҃R�[�h", this._confirmStockAdjustListCndtn.St_InputAgenCd, this._confirmStockAdjustListCndtn.Ed_InputAgenCd)); // DEL 2008/09/26
                    this.GetConditionRange( "���͒S����", this._confirmStockAdjustListCndtn.St_InputAgenCd, this._confirmStockAdjustListCndtn.Ed_InputAgenCd));
			}

            // --- ���s�^�C�v --- //
            if (this._confirmStockAdjustListCndtn.AcPaySlipCd == null)
            {
                // �S��
                this.EditCondition(ref addConditions, "���s�^�C�v�F�S��");
            }
            else if (this._confirmStockAdjustListCndtn.AcPaySlipCd[0] == 13)
            {
                // �݌Ɏd�����͕�
                this.EditCondition(ref addConditions, "���s�^�C�v�F�݌Ɏd�����͕�");
            }
            else if (this._confirmStockAdjustListCndtn.AcPaySlipCd[0] == 50)
            {
                // �I��������
                this.EditCondition(ref addConditions, "���s�^�C�v�F�I��������");
            }
            else if (this._confirmStockAdjustListCndtn.AcPaySlipCd[0] == 42)
            {
                // �}�X����������
                this.EditCondition(ref addConditions, "���s�^�C�v�F�}�X����������");
            }
            // 2009.02.16 30413 ���� �q�ɁA�S���ҁA���s�^�C�v�̏��ɒ��o�������󎚂���悤�ɏC�� <<<<<<END
            // --- ADD 3H �k�P�N 2017/09/11---------->>>>>
            else if (this._confirmStockAdjustListCndtn.AcPaySlipCd[0] == 70)
            {
                // �ϑ��݌ɕ�[��
                this.EditCondition(ref addConditions, "���s�^�C�v�F�ϑ��݌ɕ�[��");
            }
            // --- ADD 3H �k�P�N 2017/09/11----------<<<<<
			foreach (string exCondStr in addConditions)
			{
				extraConditions.Add(exCondStr);
			}
		}

		/// <summary>
		/// ���o�͈͕�����쐬
		/// </summary>
		/// <returns>�쐬������</returns>
		/// <remarks>
		/// <br>Note       : ���o�͈͕�������쐬���܂�</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2007.03.14</br>
		/// </remarks>
		private string GetConditionRange( string title, string startString, string endString )
		{
			string result = "";
			if ((startString != "") || (endString != ""))
			{
				string start = ct_Extr_Top;
				string end	 = ct_Extr_End;
				if (startString	!= "")	start	= startString;
				if (endString	!= "")	end		= endString;
				result = String.Format(title + "�F {0} �` {1}", start, end);
			}
			return result;
		}

		/// <summary>
		/// ���o����������ҏW
		/// </summary>
		/// <param name="editArea">�i�[�G���A</param>
		/// <param name="target">�Ώە�����</param>
		/// <remarks>
		/// <br>Note       : �o�͂��钊�o�����������ҏW���܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2007.03.15</br>
		/// </remarks>
		private void EditCondition(ref StringCollection editArea, string target)
		{
			bool isEdit = false;
			
			// �ҏW�Ώە����o�C�g���Z�o
			int targetByte = TStrConv.SizeCountSJIS(target);
			
			for (int i = 0; i < editArea.Count; i++)
			{
				int areaByte = 0;
				
				// �i�[�G���A�̃o�C�g���Z�o
				if (editArea[i] != null)
				{
					areaByte = TStrConv.SizeCountSJIS(editArea[i]);
				}

				if ((areaByte + targetByte + 2) <= 190)
				{
					isEdit = true;

					// �S�p�X�y�[�X��}��
					if (editArea[i] != null) editArea[i] += ct_Space;
					
					editArea[i]  += target;
					break;
				}
			}
			// �V�K�ҏW�G���A�쐬
			if (!isEdit)
			{
				editArea.Add(target);
			}
		}

		/// <summary>
		/// ���b�Z�[�W�\��
		/// </summary>
		/// <param name="iLevel">�G���[���x��</param>
		/// <param name="iMsg">�G���[���b�Z�[�W</param>
		/// <param name="iSt">�X�e�[�^�X</param>
		/// <param name="iButton">�\���{�^��</param>
		/// <param name="iDefButton">�f�t�H���g�t�H�[�J�X�{�^��</param>
		/// <returns>DialogResult</returns>
		/// <remarks>
		/// <br>Note       : �o�͌����̐ݒ���s���܂��B</br>
		/// <br>Programmer : 22013 �v�� ����</br>
		/// <br>Date       : 2007.03.08</br>
		/// </remarks>
		private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
		{
			return TMsgDisp.Show(iLevel, "MAHNB02012P", iMsg, iSt, iButton, iDefButton);
		}
		#endregion
	}
}

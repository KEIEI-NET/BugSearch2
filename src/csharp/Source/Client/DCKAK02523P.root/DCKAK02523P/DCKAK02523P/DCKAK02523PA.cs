//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �x���m�F�\
// �v���O�����T�v   : �x���m�F�\�̈󎚂��s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30415 �ēc �ύK
// �� �� ��  2008/08/05  �C�����e : PM.NS�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30452 ��� �r��
// �� �� ��  2009/03/27  �C�����e : ��Q�Ή�11468
//                       �C�����e : ��Q�Ή�11468(���[�w�b�_�̒��o�����̉��s���폜)
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��� �r��
// �� �� ��  2009/04/03  �C�����e : ��Q�Ή�13090
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30413 ����
// �� �� ��  2009/04/28  �C�����e : MANTIS�y13225�z�x�����킪�S�Ă̏ꍇ�A�u��������F�v���u�x������F�v�ɏC��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : FSI���� ���T
// �� �� ��  2012/10/03  �C�����e : �d���摍���Ή�
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
using Broadleaf.Application.Controller.Util;    // ADD 2008/10/03 �s��Ή�[5866]
using Broadleaf.Application.UIData;
using Broadleaf.Drawing.Printing;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Drawing.Printing
{
	/// <summary>
	/// �x���m�F�\����N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : �x���m�F�\�̈�����s���B</br>
	/// <br>Programmer : 20081 �D�c �E�l</br>
	/// <br>Date       : 2007.09.10</br>
    /// <br>UpdateNote : 2008/08/05 30415 �ēc �ύK</br>
    /// <br>        	 �EPM.NS�Ή�</br>   
    /// <br>UpdateNote : 2009/03/27 30452 ��� �r��</br>
    /// <br>            �E��Q�Ή�11468</br>
    /// <br>UpdateNote : 2009/03/27 30452 ��� �r��</br>
    /// <br>            �E��Q�Ή�11468(���[�w�b�_�̒��o�����̉��s���폜)</br>
    /// <br>Update Note: 2009/04/03 30452 ��� �r��</br>
    /// <br>            �E��Q�Ή�13090</br>
    /// </remarks>
	class DCKAK02523PA: IPrintProc
	{

		#region �� Constructor
		/// <summary>
		/// �x���m�F�\����N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �x���m�F�\����N���X�̃C���X�^���X�̍쐬���s���B</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.09.10</br>
		/// </remarks>
		public DCKAK02523PA()
		{
		}

		/// <summary>
		/// �x���m�F�\����N���X�R���X�g���N�^
		/// </summary>
		/// <param name="printInfo">������I�u�W�F�N�g</param>
		/// <remarks>
		/// <br>Note       : �x���m�F�\����N���X�̃C���X�^���X�̍쐬���s���B</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.09.10</br>
		/// </remarks>
		public DCKAK02523PA( object printInfo )
		{
			this._printInfo = printInfo as SFCMN06002C;
            this._paymentMainCndtn = this._printInfo.jyoken as PaymentMainCndtn;
		}
		#endregion �� Constructor

		#region �� Pricate Const
		private const string ct_ReportForm_NameSpace = "Broadleaf.Drawing.Printing";
		private const string ct_Space	= "�@";
        private const string ct_Extr_Top= RangeUtil.FROM_BEGIN; // MOD 2008/10/03 �s��Ή�[5866] "�ŏ�����"��RangeUtil.FROM_BEGIN
        private const string ct_Extr_End= RangeUtil.TO_END;     // MOD 2008/10/03 �s��Ή�[5866] "�Ō�܂�"��RangeUtil.TO_END
		#endregion �� Pricate Const

		#region �� Private Member
		private SFCMN06002C _printInfo;					// ������N���X
        private PaymentMainCndtn _paymentMainCndtn;		// ���o�����N���X
		#endregion �� Private Member

		#region �� Exception Class
		/// <summary> ��O�N���X </summary>
        private class PaymentMainException: ApplicationException
		{
			private int _status;
			#region �� Constructor
			/// <summary>
			/// ��O�N���X�R���X�g���N�^
			/// </summary>
			/// <param name="message">���b�Z�[�W</param>
			/// <param name="status">�X�e�[�^�X</param>
			public PaymentMainException(string message, int status): base(message)
			{
				this._status = status; 
			}
			#endregion
    
			#region �� Public Property
			/// <summary> �X�e�[�^�X�v���p�e�B </summary>
			public int Status
			{
				get{ return this._status; }
			}
			#endregion
		}
		#endregion �� Exception Class
		


		#region �� IPrintProc �����o
		#region �� Public Property
		/// <summary>
		/// ������擾�v���p�e�B
		/// </summary>
		public SFCMN06002C Printinfo
		{
			get { return this._printInfo; }
			set { this._printInfo = value;}
		}
		#endregion �� Public Property

		#region �� Public Method
		#region �� ��������J�n
		/// <summary>
		/// ��������J�n
		/// </summary>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : ������J�n����B</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.09.10</br>
		/// </remarks>
		public int StartPrint ()
		{
			return PrintMain();
		}
		#endregion
		#endregion �� Public Method
		#endregion �� IPrintProc �����o

		#region �� Private Member
		#region �� �������
		/// <summary>
		/// �������
		/// </summary>
		/// <returns>Status</returns>
		/// <remarks>
		/// <br>Note       : ����������s���B</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.09.10</br>
		/// </remarks>
		private int PrintMain ()
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
			// ����t�H�[���N���X�C���X�^���X�쐬
			DataDynamics.ActiveReports.ActiveReport3 prtRpt = null;
			try
			{
				// ���|�[�g�C���X�^���X�쐬
				this.CreateReport(out prtRpt, this._printInfo.prpid); 
				if (prtRpt == null) return status;

				// �e��v���p�e�B�ݒ�
				status = this.SettingProperty(ref prtRpt);
				if (status != 0) return status;
							
				// �f�[�^�\�[�X�ݒ�
				prtRpt.DataSource = (DataSet)this._printInfo.rdData;
                prtRpt.DataMember = DCKAK02525EA.Col_Tbl_PaymentMain;
				
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
		#endregion �� �������

		#region �� ���|�[�g�t�H�[���ݒ�֘A
		#region �� �e��ActiveReport���[�C���X�^���X�쐬
		/// <summary>
		/// �e��ActiveReport���[�C���X�^���X�쐬
		/// </summary>
		/// <param name="rptObj">�C���X�^���X�����ꂽ���[�t�H�[���N���X</param>
		/// <param name="prpid">���[�t�H�[��ID</param>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : �w�肳�ꂽ�A�Z���u���y�уN���X�����A�N���X���C���X�^���X�����܂��B</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.09.10</br>
		/// </remarks>
		private void CreateReport(out DataDynamics.ActiveReports.ActiveReport3 rptObj,string prpid)
		{
			// ����t�H�[���N���X�C���X�^���X�쐬
			rptObj = (DataDynamics.ActiveReports.ActiveReport3)this.LoadAssemblyReport(
				prpid.Trim(), ct_ReportForm_NameSpace + "." + prpid.Trim(), 
				typeof(DataDynamics.ActiveReports.ActiveReport3));
		}
		#endregion

		#region �� ���|�[�g�A�Z���u���C���X�^���X��
		/// <summary>
		/// ���|�[�g�A�Z���u���C���X�^���X��
		/// </summary>
		/// <param name="asmname">�A�Z���u������</param>
		/// <param name="classname">�N���X����</param>
		/// <param name="type">��������N���X�^</param>
		/// <returns>�C���X�^���X�����ꂽ�N���X</returns>
		/// <remarks>
		/// <br>Note       : �w�肳�ꂽ�A�Z���u���y�уN���X�����A�N���X���C���X�^���X�����܂��B</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.09.10</br>
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
				throw new PaymentMainException(asmname + "�����݂��܂���B",-1);
			}
			catch(System.Exception er)
			{
				throw new PaymentMainException(er.Message, -1);
			}
			return obj;
		}
		#endregion

		#region �� �����ʋ��ʏ��ݒ�

		/// <summary>
		/// �����ʋ��ʏ��ݒ�
		/// </summary>
		/// <param name="commonInfo"></param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �����ʋ��ʏ����̐ݒ���s���܂��B</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.09.10</br>
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
			commonInfo.PrintMax    = 0;
			
			status = cmnCommon.GetPdfSavePathName(this._printInfo.prpnm, ref pdfPath, ref pdfName);
			this._printInfo.pdftemppath = pdfPath + pdfName;
			commonInfo.PdfFullPath = this._printInfo.pdftemppath;

			// ��]��
			commonInfo.MarginsTop  = this._printInfo.py;
			// ���]��
			commonInfo.MarginsLeft = this._printInfo.px;
		}

		#endregion
		

		#region �� �e��v���p�e�B�ݒ�
		
		/// <summary>
		/// �e��v���p�e�B�ݒ�
		/// </summary>
		/// <param name="rpt">�C���X�^���X�����ꂽ���[�t�H�[���N���X</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �e��v���p�e�B��ݒ肵�܂��B</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.09.10</br>
		/// </remarks>
		private int SettingProperty(ref DataDynamics.ActiveReports.ActiveReport3 rpt)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

			// ActiveReport�C���^�[�t�F�[�X�ɃL���X�g
			IPrintActiveReportTypeList instance = rpt as IPrintActiveReportTypeList;

			// ��������擾
            PaymentMainCndtn extraInfo = (PaymentMainCndtn)this._printInfo.jyoken;

			// �\�[�g���v���p�e�B�ݒ�
			instance.PageHeaderSortOderTitle = GetSortOrderName( extraInfo );
			
			// ���[�o�͐ݒ���擾 
			PrtOutSet prtOutSet;
			string message;
            int st = PaymentMainAcs.ReadPrtOutSet(out prtOutSet, out message);
			if (st != 0) 
			{
                throw new PaymentMainException(message, status);
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
			//instance.PageHeaderSubtitle = this._paymentMainCndtn.PrintDivName;  // DEL 2008/08/05

			// ���̑��f�[�^
			ArrayList otherDataList = new ArrayList();

            // --- DEL 2008/08/05 -------------------------------->>>>>
            //otherDataList.Add(this._paymentMainCndtn.SumDivPrintName);			// ���v�^�C�g��
            //otherDataList.Add(this._paymentMainCndtn.EmployeeKindDivName);		// �S���҃^�C�g������
            //otherDataList.Add(string.Empty );
            // --- DEL 2008/08/05 --------------------------------<<<<< 

            // --- ADD 2008/08/05 ���햼�̎擾 -------------------------------->>>>>
            Dictionary<int, string> dicKindName = new Dictionary<int, string>();
            PaymentMainAcs paymentMainAcs = new PaymentMainAcs();
            status = paymentMainAcs.SearchKindName(out dicKindName);
            if (status == 0)
            {
                otherDataList.Add(dicKindName);
            }
            // --- ADD 2008/08/05 ���햼�̎擾 --------------------------------<<<<< 

			instance.OtherDataList = otherDataList;

			status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

			return status;
		}

		#endregion

		#region �� �\�[�g�����̎擾
		/// <summary>
		/// �\�[�g�����̎擾
		/// </summary>
		/// <param name="paymentMainCndtn">���o����</param>
		/// <returns>�\�[�g������</returns>
		/// <remarks>
		/// <br>Note       : �\�[�g�����̂��擾����B</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.09.10</br>
		/// </remarks>
        private string GetSortOrderName(PaymentMainCndtn paymentMainCndtn)
		{
			string sortOrderName = string.Empty;
			//const string ct_SortFomat = "[{0}{1}]";  // DEL 2008/08/05
            const string ct_SortFomat = "�\�[�g��:[{0}]";  // ADD 2008/08/05
			switch ( paymentMainCndtn.PrintDiv )
			{
                // --- DEL 2008/08/05 -------------------------------->>>>>
                //case (int)PaymentMainCndtn.PrintDivState.GrandTotal:			// �����v
                //    sortOrderName = string.Empty;
                //    break;
                //case (int)PaymentMainCndtn.PrintDivState.Details:		        // �ڍ�
                // --- DEL 2008/08/05 --------------------------------<<<<< 

                case (int)PaymentMainCndtn.PrintDivState.KindTotal:		        // ����ʌv
                case (int)PaymentMainCndtn.PrintDivState.Simple:    			// �ȈՓ��v

                // --- ADD 2012/10/03 ---------------------------->>>>>
                case (int)PaymentMainCndtn.PrintDivState.Simple_SupplSec:		// �ȈՓ��v(�d����-���_��)
                case (int)PaymentMainCndtn.PrintDivState.KindTotal_SupplSec:    // ����ʌv(�d����-���_��)
                // --- ADD 2012/10/03 ----------------------------<<<<<

                    // --- DEL 2008/08/05 -------------------------------->>>>>
                    // ���v�敪���x���ԍ���
                    //if (paymentMainCndtn.SumDiv == PaymentMainCndtn.SumDivState.PaymentSlipNo)
                    //    sortOrderName = string.Format( ct_SortFomat, string.Empty, paymentMainCndtn.SumDivPrintName + "��" );
                    //else
                    //    sortOrderName = string.Format( ct_SortFomat, paymentMainCndtn.SortOrderDivName, ct_Space + paymentMainCndtn.SumDivPrintName + "��" );
                    // --- DEL 2008/08/05 --------------------------------<<<<< 

                    sortOrderName = string.Format(ct_SortFomat, paymentMainCndtn.SortOrderDivName);  // ADD 2008/08/05

                    break;
				default:
					sortOrderName = string.Empty;
					break;
			}
			return sortOrderName;
		}
		#endregion

		#region �� ���o�����o�͏��쐬
		/// <summary>
		/// ���o�����o�͏��쐬
		/// </summary>
		/// <param name="extraConditions">�쐬�㒊�o�����R���N�V����</param>
		/// <remarks>
		/// <br>Note       : �o�͂��钊�o������������쐬����B</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.09.10</br>
		/// </remarks>
		private void MakeExtarCondition( out StringCollection extraConditions )
		{
			const string ct_RangeConst = "�F{0} �` {1}";
			extraConditions = new StringCollection();

			// ���o���t ----------------------------------------------------------------------------------------------------
            // �x����
			string st_AddUpADate = string.Empty;
			string ed_AddUpADate = string.Empty;
            if ((this._paymentMainCndtn.St_AddUpADate != DateTime.MinValue) || (this._paymentMainCndtn.Ed_AddupADate != DateTime.MinValue))  // ADD 2009/04/03
            {
                // �J�n
                if (this._paymentMainCndtn.St_AddUpADate != DateTime.MinValue)
                {
                    // DEL 2008/10/03 �s��Ή�[5866]��
                    //st_AddUpADate = TDateTime.DateTimeToString(PaymentMainCndtn.ct_DateFomat, this._paymentMainCndtn.St_AddUpADate);
                    st_AddUpADate = this._paymentMainCndtn.St_AddUpADate.ToString(RangeUtil.DATE_FORMAT);   // ADD 2008/10/03 �s��Ή�[5866]
                }
                else
                {
                    st_AddUpADate = ct_Extr_Top;
                }
                // �I��
                if (this._paymentMainCndtn.Ed_AddupADate != DateTime.MinValue)
                {
                    // DEL 2008/10/03 �s��Ή�[5866]��
                    //ed_AddUpADate = TDateTime.DateTimeToString(PaymentMainCndtn.ct_DateFomat, this._paymentMainCndtn.Ed_AddupADate);
                    ed_AddUpADate = this._paymentMainCndtn.Ed_AddupADate.ToString(RangeUtil.DATE_FORMAT);   // ADD 2008/10/03 �s��Ή�[5866]
                }
                else
                {
                    ed_AddUpADate = ct_Extr_End;
                }
                //this.EditCondition(ref extraConditions, string.Format( "�x���v����@" + ct_RangeConst, st_AddUpADate, ed_AddUpADate ) );  // DEL 2008/08/05
                this.EditCondition(ref extraConditions, string.Format("�x����" + ct_RangeConst, st_AddUpADate, ed_AddUpADate));           // ADD 2008/08/05
            }

            // ���͓�
            string st_InputDate = string.Empty;
            string ed_InputDate = string.Empty;
            if ((this._paymentMainCndtn.St_InputDate != DateTime.MinValue) || (this._paymentMainCndtn.Ed_InputDate != DateTime.MinValue))  // ADD 2008/08/05
            {
                // �J�n
                if (this._paymentMainCndtn.St_InputDate != DateTime.MinValue)
                {
                    // DEL 2008/10/03 �s��Ή�[5866]��
                    //st_InputDate = TDateTime.DateTimeToString(PaymentMainCndtn.ct_DateFomat, this._paymentMainCndtn.St_InputDate);
                    st_InputDate = this._paymentMainCndtn.St_InputDate.ToString(RangeUtil.DATE_FORMAT); // ADD 2008/10/03 �s��Ή�[5866]
                }
                else
                {
                    st_InputDate = ct_Extr_Top;
                }
                // �I��
                if (this._paymentMainCndtn.Ed_InputDate != DateTime.MinValue)
                {
                    // DEL 2008/10/03 �s��Ή�[5866]��
                    //ed_InputDate = TDateTime.DateTimeToString(PaymentMainCndtn.ct_DateFomat, this._paymentMainCndtn.Ed_InputDate);
                    ed_InputDate = this._paymentMainCndtn.Ed_InputDate.ToString(RangeUtil.DATE_FORMAT); // ADD 2008/10/03 �s��Ή�[5866]
                }
                else
                {
                    ed_InputDate = ct_Extr_End;
                }
                //this.EditCondition(ref extraConditions, string.Format("�x�����͓��@" + ct_RangeConst, st_InputDate, ed_InputDate));  // DEL 2008/08/05
                this.EditCondition(ref extraConditions, string.Format("���͓�" + ct_RangeConst, st_InputDate, ed_InputDate));    // ADD 2008/08/05
            }

            //StringCollection addConditions = new StringCollection(); // DEL 2009/03/30

			// �x����R�[�h ----------------------------------------------------------------------------------------------------
            if ((this._paymentMainCndtn.St_PayeeCode != 0) || (this._paymentMainCndtn.Ed_PayeeCode != 0))
            {
                string st_PayeeCode_Top = string.Empty;
                string ed_PayeeCode_End = string.Empty;

                if (this._paymentMainCndtn.St_PayeeCode == 0)
                {
                    st_PayeeCode_Top = ct_Extr_Top;
                }
                else
                {
                    st_PayeeCode_Top = string.Format("{0:000000}", this._paymentMainCndtn.St_PayeeCode);    // MOD 2008/10/03 �s��Ή�[5866] "0:000000000"��"0:000000"
                }

                if (this._paymentMainCndtn.Ed_PayeeCode == 0)
                {
                    ed_PayeeCode_End = ct_Extr_End;
                }
                else
                {
                    ed_PayeeCode_End = string.Format("{0:000000}", this._paymentMainCndtn.Ed_PayeeCode);    // MOD 2008/10/03 �s��Ή�[5866] "0:000000000"��"0:000000"
                }

                //this.EditCondition(ref addConditions, // DEL 2009/03/30
                this.EditCondition(ref extraConditions, // ADD 2009/03/30
                    string.Format("�x����" + ct_RangeConst, st_PayeeCode_Top, ed_PayeeCode_End));   // MOD 2008/10/03 �s��Ή�[5866] "�x����F{0} �` {1}"��"�x����" + ct_RangeConst
            }

			// �x����J�i ----------------------------------------------------------------------------------------------------
            if ((this._paymentMainCndtn.St_PayeeKana != string.Empty) || (this._paymentMainCndtn.Ed_PayeeKana != string.Empty))
            {
                //this.EditCondition( ref addConditions,  // DEL 2009/03/30
                this.EditCondition(ref extraConditions, // ADD 2009/03/30
                    GetConditionRange("�x����J�i", this._paymentMainCndtn.St_PayeeKana, this._paymentMainCndtn.Ed_PayeeKana));
            }

            // --- DEL 2008/08/05 -------------------------------->>>>>
            //// �S���҃R�[�h ----------------------------------------------------------------------------------------------------
            //if ( ( this._paymentMainCndtn.St_EmployeeCode != string.Empty ) || ( this._paymentMainCndtn.Ed_EmployeeCode != string.Empty ) )
            //{
            //    this.EditCondition( ref addConditions, 
            //        GetConditionRange( this._paymentMainCndtn.EmployeeKindDivName + "�҃R�[�h", this._paymentMainCndtn.St_EmployeeCode, this._paymentMainCndtn.Ed_EmployeeCode ) );
            //}
            // --- DEL 2008/08/05 --------------------------------<<<<< 

			// �x���ԍ� ----------------------------------------------------------------------------------------------------
            string st_PaymentSlipNo = string.Empty;
            string ed_PaymentSlipNo = string.Empty;
            
            if ( ( this._paymentMainCndtn.St_PaymentSlipNo != 0 ) || ( this._paymentMainCndtn.Ed_PaymentSlipNo != 0 ) )
			{
                if (this._paymentMainCndtn.St_PaymentSlipNo != 0 )
                {
                    st_PaymentSlipNo = String.Format( "{0:D9}", this._paymentMainCndtn.St_PaymentSlipNo );
                }
                else
                {
                    st_PaymentSlipNo = ct_Extr_Top;
                }

                if (this._paymentMainCndtn.Ed_PaymentSlipNo != 0)
                {
                    ed_PaymentSlipNo = String.Format( "{0:D9}", this._paymentMainCndtn.Ed_PaymentSlipNo );
                }
                else
                {
                    ed_PaymentSlipNo = ct_Extr_End;
                }

                //this.EditCondition( ref addConditions, // DEL 2009/03/30
                this.EditCondition(ref extraConditions, // ADD 2009/03/30
					string.Format( "�x���ԍ��F{0} �` {1}", st_PaymentSlipNo, ed_PaymentSlipNo)
				);
			}

			// �x������ ----------------------------------------------------------------------------------------------------
            if (!this._paymentMainCndtn.PaymentKind.ContainsKey(PaymentMainCndtn.ct_All_Code))
            {
                //this.EditCondition(ref addConditions, "�x������F" + GetPaymentKindName()); // DEL 2009/03/30
                this.EditCondition(ref extraConditions, "�x������F" + GetPaymentKindName()); // ADD 2009/03/30
            }
            // --- ADD 2009/03/27 -------------------------------->>>>>
            else
            {
                // �u�S�āv�̏ꍇ�͑S�ĕ\��
                Dictionary<int, string> dicKindName = new Dictionary<int, string>();
                PaymentMainAcs paymentMainAcs = new PaymentMainAcs();
                int status = paymentMainAcs.SearchKindName(out dicKindName);
                if (status == 0)
                {
                    StringBuilder sb = new StringBuilder();
                    //sb.Append("��������F");      // DEL 2009/04/28
                    sb.Append("�x������F");        // ADD 2009/04/28

                    for (int i = 0; i < dicKindName.Count && i < 8; i++)
                    {
                        if (i != 0)
                        {
                            sb.Append("�A");
                        }

                        sb.Append(dicKindName[i]);
                    }

                    //this.EditCondition(ref addConditions, sb.ToString()); // DEL 2009/03/30
                    this.EditCondition(ref extraConditions, sb.ToString()); // ADD 2009/03/30
                }
            }
            // --- ADD 2009/03/27 --------------------------------<<<<<

            // --- DEL 2009/03/30 -------------------------------->>>>>
            //foreach ( string exCondStr in addConditions )
            //{
            //    extraConditions.Add( exCondStr );
            //}
            // --- DEL 2009/03/30 --------------------------------<<<<<
		}
		#endregion

		#region �� �x�����햼�̕�����쐬
		/// <summary>
		/// �x�����햼�̕�����쐬
		/// </summary>
		/// <returns>�쐬������</returns>
		/// <remarks>
		/// <br>Note       : ���o�͈͕�������쐬���܂�</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.09.10</br>
		/// </remarks>
        private string GetPaymentKindName()
		{
			StringBuilder result = new StringBuilder();

			foreach ( string corpName in this._paymentMainCndtn.PaymentKind.Values )
			{
				if ( result.ToString().CompareTo( string.Empty ) != 0 )
				{
					result.Append("�A");
				}
				result.Append( corpName );
			}

			return result.ToString();
		}
		#endregion

		#region �� ���o�͈͕�����쐬
		/// <summary>
		/// ���o�͈͕�����쐬
		/// </summary>
		/// <returns>�쐬������</returns>
		/// <remarks>
		/// <br>Note       : ���o�͈͕�������쐬���܂�</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.09.10</br>
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
		#endregion

		#region �� ���o����������ҏW
		/// <summary>
		/// ���o����������ҏW
		/// </summary>
		/// <param name="editArea">�i�[�G���A</param>
		/// <param name="target">�Ώە�����</param>
		/// <remarks>
		/// <br>Note       : �o�͂��钊�o�����������ҏW���܂��B</br>
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.09.10</br>
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
		#endregion
		#endregion �� ���|�[�g�t�H�[���ݒ�֘A

		#region �� ���b�Z�[�W�\��

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
		/// <br>Programmer : 20081 �D�c �E�l</br>
		/// <br>Date       : 2007.09.10</br>
		/// </remarks>
		private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
		{
			return TMsgDisp.Show(iLevel, "DCKAK02523P", iMsg, iSt, iButton, iDefButton);
		}

		#endregion
		#endregion
	}
}

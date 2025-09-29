//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �݌ɕ��͏��ʕ\
// �v���O�����T�v   : �݌ɕ��͏��ʕ\�̈�����s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2006 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��� ���b
// �� �� ��  2007/09/19  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Ɠc �M�u
// �C �� ��  2008/09/30  �C�����e : �o�O�C���A�d�l�ύX�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��� �r��
// �C �� ��  2009/03/17  �C�����e : ��Q�Ή�12707
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �Ɠc �M�u
// �C �� ��  2009/03/27  �C�����e : �s��Ή�[12783]
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
	/// �݌ɓ��o�׈ꗗ�\����N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : �݌ɓ��o�׈ꗗ�\�̈�����s���B</br>
	/// <br>Programmer : 22018 ��� ���b</br>
	/// <br>Date       : 2007.09.19</br>
    /// <br>Update     : 2008/09/30 �Ɠc �M�u�@�o�O�C���A�d�l�ύX�Ή�</br>
    /// <br>Update Note: 2009/03/17 30452 ��� �r��</br>
    /// <br>            �E��Q�Ή�12707</br>
    /// <br>           : 2009/03/27 �Ɠc �M�u�@�s��Ή�[12783]</br>
	/// </remarks>
	class DCZAI02143PA: IPrintProc
	{

		#region �� Constructor
		/// <summary>
		/// �݌ɓ��o�׈ꗗ�\����N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �݌ɓ��o�׈ꗗ�\����N���X�̃C���X�^���X�̍쐬���s���B</br>
		/// <br>Programmer : 22018 ��� ���b</br>
		/// <br>Date       : 2007.09.19</br>
		/// </remarks>
		public DCZAI02143PA()
		{
		}

		/// <summary>
		/// �݌ɓ��o�׈ꗗ�\����N���X�R���X�g���N�^
		/// </summary>
		/// <param name="printInfo">������I�u�W�F�N�g</param>
		/// <remarks>
		/// <br>Note       : �݌ɓ��o�׈ꗗ�\����N���X�̃C���X�^���X�̍쐬���s���B</br>
		/// <br>Programmer : 22018 ��� ���b</br>
		/// <br>Date       : 2007.09.19</br>
		/// </remarks>
		public DCZAI02143PA( object printInfo )
		{
			this._printInfo = printInfo as SFCMN06002C;
			this._stockAnalysisOrderListCndtn = this._printInfo.jyoken as StockAnalysisOrderListCndtn;
		}
		#endregion �� Constructor

		#region �� Pricate Const
		private const string ct_ReportForm_NameSpace = "Broadleaf.Drawing.Printing";
		private const string ct_Space			= "�@";
        //--- DEL 2008/07/17 ---------->>>>>
        //private const string ct_Extr_Top		= "�s�n�o";
        //private const string ct_Extr_End		= "�d�m�c";
        //--- DEL 2008/07/17 ----------<<<<<
        //--- ADD 2008/07/17 ---------->>>>>
        private const string ct_Extr_Top = "�ŏ�����";
        private const string ct_Extr_End = "�Ō�܂�";
        //--- ADD 2008/07/17 ----------<<<<<
        private const string ct_RangeConst = "�F{0} �` {1}";
		#endregion �� Pricate Const

		#region �� Private Member
		private SFCMN06002C _printInfo;					// ������N���X
		private StockAnalysisOrderListCndtn _stockAnalysisOrderListCndtn;		// ���o�����N���X
		#endregion �� Private Member

        

		#region �� Exception Class
		/// <summary> ��O�N���X </summary>
        private class StockMoveException: ApplicationException
		{
			private int _status;
			#region �� Constructor
			/// <summary>
			/// ��O�N���X�R���X�g���N�^
			/// </summary>
			/// <param name="message">���b�Z�[�W</param>
			/// <param name="status">�X�e�[�^�X</param>
			public StockMoveException(string message, int status): base(message)
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
		/// <br>Programmer : 22018 ��� ���b</br>
		/// <br>Date       : 2007.09.19</br>
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
		/// <br>Programmer : 22018 ��� ���b</br>
		/// <br>Date       : 2007.09.19</br>
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
				prtRpt.DataSource = this._printInfo.rdData;
                prtRpt.DataMember = DCZAI02145EA.ct_Tbl_StockAnalysisOrder;
				

				// ������ʏ��v���p�e�B�ݒ�
				Broadleaf.Windows.Forms.SFCMN00293UC commonInfo;
                //this.SetPrintCommonInfo(out commonInfo); // DEL 2009/03/17
                this.SetPrintCommonInfo(ref prtRpt ,out commonInfo); // ADD 2009/03/17

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
		/// <br>Programmer : 22018 ��� ���b</br>
		/// <br>Date       : 2007.09.19</br>
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
		/// <br>Programmer : 22018 ��� ���b</br>
		/// <br>Date       : 2007.09.19</br>
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
				throw new StockMoveException(asmname + "�����݂��܂���B",-1);
			}
			catch(System.Exception er)
			{
				throw new StockMoveException(er.Message, -1);
			}
			return obj;
		}
		#endregion

		#region �� �����ʋ��ʏ��ݒ�

		/// <summary>
		/// �����ʋ��ʏ��ݒ�
		/// </summary>
        /// <param name="rptObj"></param>
		/// <param name="commonInfo"></param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �����ʋ��ʏ����̐ݒ���s���܂��B</br>
		/// <br>Programmer : 22018 ��� ���b</br>
		/// <br>Date       : 2007.09.19</br>
		/// </remarks>
        //private void SetPrintCommonInfo(out Broadleaf.Windows.Forms.SFCMN00293UC commonInfo) // DEL 2009/03/17
        private void SetPrintCommonInfo(ref DataDynamics.ActiveReports.ActiveReport3 rptObj, out Broadleaf.Windows.Forms.SFCMN00293UC commonInfo) // ADD 2009/03/17
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
            commonInfo.PrintMax    = (this._printInfo.rdData as DataView).Count;
			
			status = cmnCommon.GetPdfSavePathName(this._printInfo.prpnm, ref pdfPath, ref pdfName);
			this._printInfo.pdftemppath = pdfPath + pdfName;
			commonInfo.PdfFullPath = this._printInfo.pdftemppath;

			// ��]��
			commonInfo.MarginsTop  = this._printInfo.py;
			// ���]��
			commonInfo.MarginsLeft = this._printInfo.px;

            // --- ADD 2009/03/17 -------------------------------->>>>>
            rptObj.Document.CacheToDisk = true;
            rptObj.Document.CacheToDiskLocation = pdfPath;
            // --- ADD 2009/03/17 --------------------------------<<<<<
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
		/// <br>Programmer : 22018 ��� ���b</br>
		/// <br>Date       : 2007.09.19</br>
		/// </remarks>
		private int SettingProperty(ref DataDynamics.ActiveReports.ActiveReport3 rpt)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

			// ActiveReport�C���^�[�t�F�[�X�ɃL���X�g
			IPrintActiveReportTypeList instance = rpt as IPrintActiveReportTypeList;

			// ��������擾
            StockAnalysisOrderListCndtn extraInfo = (StockAnalysisOrderListCndtn)this._printInfo.jyoken;

			// �\�[�g���v���p�e�B�ݒ�
			instance.PageHeaderSortOderTitle = this._stockAnalysisOrderListCndtn.OrderPrintTypeStateTitle;
			
			// ���[�o�͐ݒ���擾 
			PrtOutSet prtOutSet;
			string message;
			int st = StockAnalysisOrderListAcs.ReadPrtOutSet(out prtOutSet, out message);
			if (st != 0) 
			{
                throw new StockMoveException(message, status);
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
            object[] titleObj = new object[]{"�݌ɕ��͏��ʕ\"};
            instance.PageHeaderSubtitle = string.Format("{0}", titleObj);

			// ���̑��f�[�^
			// Todo:�ړ����Ƃ��n���H���o�����n�邩�炢�����H
			instance.OtherDataList = null;

			status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

			return status;
		}

		#endregion

		#region �� ���o�����o�͏��쐬
		/// <summary>
		/// ���o�����o�͏��쐬
		/// </summary>
		/// <param name="extraConditions">�쐬�㒊�o�����R���N�V����</param>
		/// <remarks>
		/// <br>Note       : �o�͂��钊�o������������쐬����B</br>
		/// <br>Programmer : 22018 ��� ���b</br>
		/// <br>Date       : 2007.09.19</br>
		/// </remarks>
		private void MakeExtarCondition( out StringCollection extraConditions )
		{
            extraConditions = new StringCollection();
            StringCollection addConditions = new StringCollection();

           
            // �Ώ۔N�� ----------------------------------------------------------------------------------------------------
            string st_AnalysisOrderDate = string.Empty;
            string ed_AnalysisOrderDate = string.Empty;
            //string dateFormat = "yyyy�NMM��";         //DEL 2008/09/30 �����ύX
            string dateFormat = "yyyy/MM";              //ADD 2008/09/30

            // �J�n��I���̂����ꂩ�����͂���Ă���Έ�
            if ( ( this._stockAnalysisOrderListCndtn.St_AddUpYearMonth != DateTime.MinValue ) || ( this._stockAnalysisOrderListCndtn.Ed_AddUpYearMonth != DateTime.MinValue ) ) {
                // �J�n
                if ( this._stockAnalysisOrderListCndtn.St_AddUpYearMonth != DateTime.MinValue )
                    st_AnalysisOrderDate = this._stockAnalysisOrderListCndtn.St_AddUpYearMonth.ToString(dateFormat);
                else
                    st_AnalysisOrderDate = ct_Extr_Top;
                // �I��
                if ( this._stockAnalysisOrderListCndtn.Ed_AddUpYearMonth != DateTime.MinValue )
                    ed_AnalysisOrderDate = this._stockAnalysisOrderListCndtn.Ed_AddUpYearMonth.ToString(dateFormat);
                else
                    ed_AnalysisOrderDate = ct_Extr_End;

                this.EditCondition(
                    ref addConditions,
                    string.Format(
                        //"������" + ct_RangeConst,         //DEL 2008/09/30 ���̕ύX
                        "�Ώی�" + ct_RangeConst,           //ADD 2008/09/30
                        st_AnalysisOrderDate,
                        ed_AnalysisOrderDate));
            }

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //// ����^�C�v --------------------------------------------------------------------------------------------------
            //this.EditCondition( ref addConditions, String.Format( "������F{0}", this._stockAnalysisOrderListCndtn.OrderPrintTypeStateTitle ) );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // �o�͏��� ----------------------------------------------------------------------------------------------------
            if ( this._stockAnalysisOrderListCndtn.StockOrderMax != 0 && this._stockAnalysisOrderListCndtn.StockOrderMax != 999999999 )
            {
                this.EditCondition( ref addConditions, String.Format( "�o�͏��ʁF{0} {1}�ʂ܂�",
                                                                        this._stockAnalysisOrderListCndtn.StockOrderDivStateTitle,
                                                                        this._stockAnalysisOrderListCndtn.StockOrderMax.ToString() ) );
            }

            // �o�͏��� ----------------------------------------------------------------------------------------------------
            //if ( this._stockAnalysisOrderListCndtn.St_ShipmentCnt != 0 || this._stockAnalysisOrderListCndtn.Ed_ShipmentCnt != 999999999 )                 //DEL 2008/09/30 Int��Double�A�}�C�i�X�̈�
            if ( this._stockAnalysisOrderListCndtn.St_ShipmentCnt != -999999999.99 || this._stockAnalysisOrderListCndtn.Ed_ShipmentCnt != 999999999.99 )    //ADD 2008/09/30
            {
                string shipmentCntCndtnText = "�o�͏����F";
                //if ( this._stockAnalysisOrderListCndtn.St_ShipmentCnt != 0 )                  //DEL 2008/09/30 Int��Double�A�}�C�i�X�̈�
                if (this._stockAnalysisOrderListCndtn.St_ShipmentCnt != -999999999.99)          //ADD 2008/09/30
                {
                    shipmentCntCndtnText += string.Format( "{0}�ȏ� ", this._stockAnalysisOrderListCndtn.St_ShipmentCnt );
                }
                //if ( this._stockAnalysisOrderListCndtn.Ed_ShipmentCnt != 999999999 )          //DEL 2008/09/30 Int��Double�A�}�C�i�X�̈�
                if (this._stockAnalysisOrderListCndtn.Ed_ShipmentCnt != 999999999.99)           //ADD 2008/09/30
                {
                    shipmentCntCndtnText += string.Format( "{0}�ȉ� ", this._stockAnalysisOrderListCndtn.Ed_ShipmentCnt );
                }

                this.EditCondition( ref addConditions, shipmentCntCndtnText );
            }

            // �P�� --------------------------------------------------------------------------------------------------------
            this.EditCondition(ref addConditions, String.Format("�P�ʁF{0}", this._stockAnalysisOrderListCndtn.MoneyUnitStateTitle));


            // ---ADD 2009/03/27 �s��Ή�[12783] ---------------------------------------------->>>>>
            if (this._stockAnalysisOrderListCndtn.PrintTypeDiv == StockAnalysisOrderListCndtn.PrintTypeDivState.Total)
            {
                this.EditCondition(ref addConditions, "����^�C�v�F�S�Ќv");
            }
            else
            {
                this.EditCondition(ref addConditions, "����^�C�v�F�q�ɕ�");
            }
            // ---ADD 2009/03/27 �s��Ή�[12783] ----------------------------------------------<<<<<

            // ADD 2008/09/30 ----------------------------------------------------------------------------------------->>>>>
            // �Ǘ��敪1
            if ((this._stockAnalysisOrderListCndtn.PartsManagementDivide1 != null) &&
                (this._stockAnalysisOrderListCndtn.PartsManagementDivide1.Length > 0))
            {
                StringBuilder partsMngDiv1 = new StringBuilder("�Ǘ��敪1�F");  // LITERAL:
                Array.Sort<string>(this._stockAnalysisOrderListCndtn.PartsManagementDivide1);
                foreach (string partsMngDiv1Item in this._stockAnalysisOrderListCndtn.PartsManagementDivide1)
                {
                    partsMngDiv1.Append(partsMngDiv1Item);
                }

                EditCondition(ref addConditions, partsMngDiv1.ToString());
            }

            // �Ǘ��敪2
            if ((this._stockAnalysisOrderListCndtn.PartsManagementDivide2 != null) &&
                (this._stockAnalysisOrderListCndtn.PartsManagementDivide2.Length > 0))
            {
                StringBuilder partsMngDiv2 = new StringBuilder("�Ǘ��敪2�F");  // LITERAL:
                Array.Sort<string>(this._stockAnalysisOrderListCndtn.PartsManagementDivide2);
                foreach (string partsMngDiv2Item in this._stockAnalysisOrderListCndtn.PartsManagementDivide2)
                {
                    partsMngDiv2.Append(partsMngDiv2Item);
                }

                EditCondition(ref addConditions, partsMngDiv2.ToString());
            }
            // ADD 2008/09/30 -----------------------------------------------------------------------------------------<<<<<

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            // �q��
            this.EditCondition( ref addConditions,
                this.GetConditionRange( "�q��", this._stockAnalysisOrderListCndtn.St_WarehouseCode, this._stockAnalysisOrderListCndtn.Ed_WarehouseCode )
                );
            
            // �d����
            this.EditCondition( ref addConditions,
                //this.GetConditionRange( "�d����", this._stockAnalysisOrderListCndtn.St_CustomerCode, this._stockAnalysisOrderListCndtn.Ed_CustomerCode, 999999999 )   //DEL 2008/09/30 �����ύX
                this.GetConditionRange( "�d����", this._stockAnalysisOrderListCndtn.St_CustomerCode, this._stockAnalysisOrderListCndtn.Ed_CustomerCode, 999999 )        //ADD 2008/09/30 
                );

            // ���[�J�[
            this.EditCondition( ref addConditions,
                //this.GetConditionRange( "���[�J�[", this._stockAnalysisOrderListCndtn.St_GoodsMakerCd, this._stockAnalysisOrderListCndtn.Ed_GoodsMakerCd, 999999 )    //DEL 2008/09/30 �����ύX
                this.GetConditionRange( "���[�J�[", this._stockAnalysisOrderListCndtn.St_GoodsMakerCd, this._stockAnalysisOrderListCndtn.Ed_GoodsMakerCd, 9999 )       //ADD 2008/09/30
                );

            // ���i�敪�O���[�v
            this.EditCondition( ref addConditions,
                //this.GetConditionRange( "���i�敪�O���[�v", this._stockAnalysisOrderListCndtn.St_LargeGoodsGanreCode, this._stockAnalysisOrderListCndtn.Ed_LargeGoodsGanreCode )  // DEL 2008.07.24
                this.GetConditionRange( "���i�啪��", this._stockAnalysisOrderListCndtn.St_LargeGoodsGanreCode, this._stockAnalysisOrderListCndtn.Ed_LargeGoodsGanreCode )          // ADD 2008.07.24
                );

            // ���i�敪
            this.EditCondition( ref addConditions,
                //this.GetConditionRange("���i�敪", this._stockAnalysisOrderListCndtn.St_MediumGoodsGanreCode, this._stockAnalysisOrderListCndtn.Ed_MediumGoodsGanreCode)          // DEL 2008.07.24
                this.GetConditionRange( "���i������", this._stockAnalysisOrderListCndtn.St_MediumGoodsGanreCode, this._stockAnalysisOrderListCndtn.Ed_MediumGoodsGanreCode )        // ADD 2008.07.24
                );
            
            // ���i�ڍ�
            this.EditCondition( ref addConditions,
                //this.GetConditionRange("���i�敪�ڍ�", this._stockAnalysisOrderListCndtn.St_DetailGoodsGanreCode, this._stockAnalysisOrderListCndtn.Ed_DetailGoodsGanreCode)      // DEL 2008.07.24
                this.GetConditionRange( "�O���[�v�R�[�h", this._stockAnalysisOrderListCndtn.St_DetailGoodsGanreCode, this._stockAnalysisOrderListCndtn.Ed_DetailGoodsGanreCode )    // ADD 2008.07.24
                );

            // �a�k���i�R�[�h
            this.EditCondition( ref addConditions,
                /* --- DEL 2008/09/30 �����ύX ------------------------------------------------------------------------------------------------------------------------------------------------->>>>>
                //this.GetConditionRange("�a�k���i�R�[�h", this._stockAnalysisOrderListCndtn.St_BLGoodsCode, this._stockAnalysisOrderListCndtn.Ed_BLGoodsCode, 99999999)            // DEL 2008.07.24
                this.GetConditionRange( "�a�k�R�[�h", this._stockAnalysisOrderListCndtn.St_BLGoodsCode, this._stockAnalysisOrderListCndtn.Ed_BLGoodsCode, 99999999 )                // ADD 2008.07.24
                   --- DEL 2008/09/30 ----------------------------------------------------------------------------------------------------------------------------------------------------------<<<<< */
                this.GetConditionRange("�a�k�R�[�h", this._stockAnalysisOrderListCndtn.St_BLGoodsCode, this._stockAnalysisOrderListCndtn.Ed_BLGoodsCode, 99999)                    // ADD 2008/09/30
                );

            // �q�ɒI��
            this.EditCondition( ref addConditions,
                //this.GetConditionRange("�q�ɒI��", this._stockAnalysisOrderListCndtn.St_WarehouseShelfNo, this._stockAnalysisOrderListCndtn.Ed_WarehouseShelfNo)                  // DEL 2008.07.24
                this.GetConditionRange( "�I��", this._stockAnalysisOrderListCndtn.St_WarehouseShelfNo, this._stockAnalysisOrderListCndtn.Ed_WarehouseShelfNo )                      // ADD 2008.07.24
                );

            // ���i�ԍ�
            this.EditCondition( ref addConditions,
                //this.GetConditionRange("���i�ԍ�", this._stockAnalysisOrderListCndtn.St_GoodsNo, this._stockAnalysisOrderListCndtn.Ed_GoodsNo)    // DEL 2008.07.24
                this.GetConditionRange( "�i��", this._stockAnalysisOrderListCndtn.St_GoodsNo, this._stockAnalysisOrderListCndtn.Ed_GoodsNo )        // ADD 2008.07.24
                );

            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // �ǉ�
            foreach ( string exCondStr in addConditions ) {
                extraConditions.Add(exCondStr);
            }
        }
		#endregion

		#region �� ���o�͈͕�����쐬
		/// <summary>
		/// ���o�͈͕�����쐬
		/// </summary>
		/// <returns>�쐬������</returns>
		/// <remarks>
		/// <br>Note       : ���o�͈͕�������쐬���܂�</br>
		/// <br>Programmer : 22018 ��� ���b</br>
		/// <br>Date       : 2007.09.19</br>
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
				result = String.Format(title + ct_RangeConst, start, end);
			}
			return result;
		}
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        /// <summary>
        /// ���o�͈͕�����쐬�i���l�p�j
        /// </summary>
        /// <param name="title"></param>
        /// <param name="startCode"></param>
        /// <param name="endCode"></param>
        /// <param name="endMax"></param>
        /// <returns>�쐬������</returns>
        private string GetConditionRange( string title, int startCode, int endCode, int endMax )
        {
            string result = "";
            if ( (startCode != 0) || (endCode != endMax) )
            {
                string start = ct_Extr_Top;
                string end = ct_Extr_End;
                if ( startCode != 0 )
                    //start = startCode.ToString().TrimEnd();                                       //DEL 2008/09/30 �[���l�߂̈�
                    start = startCode.ToString().TrimEnd().PadLeft(endMax.ToString().Length,'0');   //ADD 2008/09/30
                if (endCode != endMax)
                    //end = endCode.ToString().TrimEnd();                                           //DEL 2008/09/30 �[���l�߂̈�
                    end = endCode.ToString().TrimEnd().PadLeft(endMax.ToString().Length,'0');       //ADD 2008/09/30
                result = String.Format(title + ct_RangeConst, start, end);
            }

            // --- ADD 2008/09/30 ------------------------------------------------------->>>>>
            // "�ŏ����� �` �Ō�܂�"�ƂȂ�ꍇ�A�o�͂��Ȃ�
            if ((startCode.Equals(ct_Extr_Top)) && (endCode.Equals(ct_Extr_End)))
            {
                result = string.Empty;
            }
            // --- ADD 2008/09/30 -------------------------------------------------------<<<<<

            return result;
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
		#endregion

		#region �� ���o����������ҏW
		/// <summary>
		/// ���o����������ҏW
		/// </summary>
		/// <param name="editArea">�i�[�G���A</param>
		/// <param name="target">�Ώە�����</param>
		/// <remarks>
		/// <br>Note       : �o�͂��钊�o�����������ҏW���܂��B</br>
		/// <br>Programmer : 22018 ��� ���b</br>
		/// <br>Date       : 2007.09.19</br>
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
		/// <br>Programmer : 22018 ��� ���b</br>
		/// <br>Date       : 2007.09.19</br>
		/// </remarks>
		private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
		{
			return TMsgDisp.Show(iLevel, "MAZAI02032P", iMsg, iSt, iButton, iDefButton);
		}

		#endregion
		#endregion
	}
}

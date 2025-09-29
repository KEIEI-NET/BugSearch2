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
	/// �݌ɥ�q�Ɉړ��m�F�\����N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : �݌ɥ�q�Ɉړ��m�F�\�̈�����s���B</br>
	/// <br>Programmer : 22013 �v�� ����</br>
	/// <br>Date       : 2007.03.08</br>
    /// <br>UpdateNote : 2009/03/16 �Ɠc �M�u�@�s��Ή�[12331]</br>
	/// </remarks>
	class MAZAI02032PA: IPrintProc
	{

		#region �� Constructor
		/// <summary>
		/// �݌ɥ�q�Ɉړ��m�F�\����N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �݌ɥ�q�Ɉړ��m�F�\����N���X�̃C���X�^���X�̍쐬���s���B</br>
		/// <br>Programmer : 22013 �v�� ����</br>
		/// <br>Date       : 2007.03.08</br>
		/// </remarks>
		public MAZAI02032PA()
		{
		}

		/// <summary>
		/// �݌ɥ�q�Ɉړ��m�F�\����N���X�R���X�g���N�^
		/// </summary>
		/// <param name="printInfo">������I�u�W�F�N�g</param>
		/// <remarks>
		/// <br>Note       : �݌ɥ�q�Ɉړ��m�F�\����N���X�̃C���X�^���X�̍쐬���s���B</br>
		/// <br>Programmer : 22013 �v�� ����</br>
		/// <br>Date       : 2007.03.08</br>
		/// </remarks>
		public MAZAI02032PA( object printInfo )
		{
			this._printInfo = printInfo as SFCMN06002C;
			this._stockMoveCndtn = this._printInfo.jyoken as StockMoveCndtn;
		}
		#endregion �� Constructor

		#region �� Pricate Const
		private const string ct_ReportForm_NameSpace = "Broadleaf.Drawing.Printing";
		private const string ct_Space			= "�@";
        //--- DEL 2008/08/12 ---------->>>>>
        //private const string ct_Extr_Top		= "�s�n�o";
        //private const string ct_Extr_End		= "�d�m�c";
        //--- DEL 2008/08/12 ----------<<<<<
        //--- ADD 2008/08/12 ---------->>>>>
        private const string ct_Extr_Top		= "�ŏ�����";
        private const string ct_Extr_End		= "�Ō�܂�";
        //--- ADD 2008/08/12 ----------<<<<<
        private const string ct_RangeConst = "�F{0} �` {1}";
		#endregion �� Pricate Const

		#region �� Private Member
		private SFCMN06002C _printInfo;					// ������N���X
		private StockMoveCndtn _stockMoveCndtn;		    // ���o�����N���X
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
		/// <br>Programmer : 22013 �v�� ����</br>
		/// <br>Date       : 2007.03.08</br>
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
		/// <br>Programmer : 22013 �v�� ����</br>
		/// <br>Date       : 2007.03.08</br>
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
                prtRpt.DataMember = MAZAI02034EA.ct_Tbl_StockMove;
				
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

                // ---ADD 2009/03/16 �s��Ή�[12331] --------------------------------------------------------->>>>>
                // �X�V(���������I���ŁA�W�v�ȊO��)
                if ((status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL) &&
                    (this._stockMoveCndtn.PrintDiv != 13))
                {
                    string errMsg;
                    StockMoveAcs stockMoveAcs = new StockMoveAcs();
                    status = stockMoveAcs.UpdateStockMoveMain((DataView)this.Printinfo.rdData, out errMsg);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        this.MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP, errMsg, -1, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                    }
                }
                // ---ADD 2009/03/16 �s��Ή�[12331] ---------------------------------------------------------<<<<<
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
		/// <br>Programmer : 22013 �v�� ����</br>
		/// <br>Date       : 2007.03.08</br>
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
		/// <br>Programmer : 22013 �v�� ����</br>
		/// <br>Date       : 2007.03.08</br>
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
		/// <param name="commonInfo"></param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �����ʋ��ʏ����̐ݒ���s���܂��B</br>
		/// <br>Programmer : 22013 �v�� ����</br>
		/// <br>Date       : 2007.03.08</br>
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
			commonInfo.PrintMax    = (this._printInfo.rdData as DataView).Count;
			
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
		/// <br>Programmer : 22013 �v�� ����</br>
		/// <br>Date       : 2007.03.08</br>
		/// </remarks>
		private int SettingProperty(ref DataDynamics.ActiveReports.ActiveReport3 rpt)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

			// ActiveReport�C���^�[�t�F�[�X�ɃL���X�g
			IPrintActiveReportTypeList instance = rpt as IPrintActiveReportTypeList;

			// ��������擾
            StockMoveCndtn extraInfo = (StockMoveCndtn)this._printInfo.jyoken;

			// �\�[�g���v���p�e�B�ݒ�
			//instance.PageHeaderSortOderTitle = "";                                                            //DEL 2008/10/02 �o�͏��ǉ��̈�
            // --- ADD 2008/10/02 ------------------------------------------------------------------------------------------------------->>>>>
            // �o�͏�
            if (this._stockMoveCndtn.OutputOrder == StockMoveCndtn.OutputOrderDivState.ShipArrivalDate)       // �Ώۓ���
            {
                instance.PageHeaderSortOderTitle = "�Ώۓ���";
            }
            else if (this._stockMoveCndtn.OutputOrder == StockMoveCndtn.OutputOrderDivState.CreateDate)       // ���͓���
            {
                instance.PageHeaderSortOderTitle = "���͓���";
            }
            else if (this._stockMoveCndtn.OutputOrder == StockMoveCndtn.OutputOrderDivState.Warehouse)        // ����q�ɏ�
            {
                instance.PageHeaderSortOderTitle = "����q�ɏ�";
            }
            // --- ADD 2008/10/02 -------------------------------------------------------------------------------------------------------<<<<<

			// ���[�o�͐ݒ���擾 
			PrtOutSet prtOutSet;
			string message;
			int st = StockMoveAcs.ReadPrtOutSet(out prtOutSet, out message);
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
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //object[] titleObj = new object[]{ 
            //    this._stockMoveCndtn.StockMoveFormalDivName,	// ���[�敪(�݌Ɉړ�or�q�Ɉړ�)
            //    this._stockMoveCndtn.ShipmentArrivalDivName,	// �����敪(���o��,���)
            //    this._stockMoveCndtn.GrossPrintDivName };		// �W�v�P��(����or���i)
            //instance.PageHeaderSubtitle = string.Format("{0}({1}�E{2})", titleObj);
            //--- DEL 2008.08.12 ---------->>>>>
            //object[] titleObj = new object[]{ 
            //    this._stockMoveCndtn.StockMoveFormalDivName,	// ���[�敪(�݌Ɉړ�or�q�Ɉړ�)     
            //    this._stockMoveCndtn.ShipmentArrivalDivName};	// �����敪(���o��,���)
            //instance.PageHeaderSubtitle = string.Format("{0}({1})", titleObj);
            //--- DEL 2008.08.12 ----------<<<<<
            //--- ADD 2008.08.12 ---------->>>>>
            instance.PageHeaderSubtitle = string.Format("{0}", this._printInfo.prpnm);
            //--- ADD 2008.08.12 ----------<<<<<
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            
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
		/// <br>Programmer : 22013 �v�� ����</br>
		/// <br>Date       : 2007.03.08</br>
		/// </remarks>
		private void MakeExtarCondition( out StringCollection extraConditions )
		{
            //--- DEL 2008/08/12 ---------->>>>>
            //const string ct_Section = "���_�R�[�h";
            //const string ct_WareHouse = "�q�ɃR�[�h";

            //string swName = string.Empty;		// ���_��q�Ƀ^�C�g��
            //extraConditions = new StringCollection();


            //// ��q�ɃR�[�h ----------------------------------------------------------------------------------------------------
            //swName = string.Format( "{0}{1}", this._stockMoveCndtn.MainExtractTitle, ct_WareHouse );
            //if ( ( this._stockMoveCndtn.St_MainBfAfEnterWarehCd != string.Empty ) || ( this._stockMoveCndtn.Ed_MainBfAfEnterWarehCd != string.Empty ) )
            //{
            //    this.EditCondition( ref extraConditions, 
            //        GetConditionRange( swName, this._stockMoveCndtn.St_MainBfAfEnterWarehCd, this._stockMoveCndtn.Ed_MainBfAfEnterWarehCd ) );
            //}
            //else
            //{
            //    // �J�n��I������Ȃ�u�S�q�Ɂv�ƈ�
            //    this.EditCondition( ref extraConditions, string.Format( "{0}�F {1}", swName, "�S�q��") );
            //}

            //StringCollection addConditions = new StringCollection();
            //// ���o���t ----------------------------------------------------------------------------------------------------
            //string st_ShipArrivalDate = string.Empty;
            //string ed_ShipArrivalDate = string.Empty;
            //// �J�n��I���̂����ꂩ�����͂���Ă���Έ�
            //if ( ( this._stockMoveCndtn.St_ShipArrivalDate != DateTime.MinValue ) || ( this._stockMoveCndtn.Ed_ShipArrivalDate != DateTime.MinValue ) )
            //{
            //    // �J�n
            //    if ( this._stockMoveCndtn.St_ShipArrivalDate != DateTime.MinValue )
            //        st_ShipArrivalDate = TDateTime.DateTimeToString( StockMoveCndtn.ct_DateFomat, this._stockMoveCndtn.St_ShipArrivalDate );
            //    else
            //        st_ShipArrivalDate = ct_Extr_Top;
            //    // �I��
            //    if ( this._stockMoveCndtn.Ed_ShipArrivalDate != DateTime.MinValue )
            //        ed_ShipArrivalDate = TDateTime.DateTimeToString( StockMoveCndtn.ct_DateFomat, this._stockMoveCndtn.Ed_ShipArrivalDate );
            //    else
            //        ed_ShipArrivalDate = ct_Extr_End;

            //    this.EditCondition(
            //        ref addConditions, 
            //        string.Format( 
            //            this._stockMoveCndtn.ExtractDateTitle.PadRight( 7, '�@' ) + ct_RangeConst, 
            //            st_ShipArrivalDate, 
            //            ed_ShipArrivalDate ) );
            //}

            //// �i���݋��_�R�[�h ----------------------------------------------------------------------------------------------------
            //// �݌Ɉړ��̂Ƃ��̂�
            //if (this._stockMoveCndtn.StockMoveFormalDiv == StockMoveCndtn.StockMoveFormalDivState.StockMove)
            //{
            //    if ((this._stockMoveCndtn.St_ShipArrivalSectionCd != string.Empty) || (this._stockMoveCndtn.Ed_ShipArrivalSectionCd != string.Empty))
            //    {
            //        swName = string.Format("{0}{1}", this._stockMoveCndtn.ExtractTitle, ct_Section);
            //        this.EditCondition(ref extraConditions,
            //            GetConditionRange(swName, this._stockMoveCndtn.St_ShipArrivalSectionCd, this._stockMoveCndtn.Ed_ShipArrivalSectionCd));
            //    }
            //}

            //// �i���ݑq�ɃR�[�h ----------------------------------------------------------------------------------------------------
            //if ( ( this._stockMoveCndtn.St_ShipArrivalEnterWarehCd != string.Empty ) || ( this._stockMoveCndtn.Ed_ShipArrivalEnterWarehCd != string.Empty ) )
            //{
            //    swName = string.Format( "{0}{1}", this._stockMoveCndtn.ExtractTitle, ct_WareHouse );
            //    this.EditCondition( ref extraConditions, 
            //        GetConditionRange( swName, this._stockMoveCndtn.St_ShipArrivalEnterWarehCd, this._stockMoveCndtn.Ed_ShipArrivalEnterWarehCd ) );
            //}

            //// �ړ��`�[�ԍ� ----------------------------------------------------------------------------------------------------
            //if ( ( this._stockMoveCndtn.St_StockMoveSlipNo != 0 ) || ( this._stockMoveCndtn.Ed_StockMoveSlipNo != 999999999 ) )
            //{
            //    this.EditCondition( ref addConditions, 
            //        string.Format( "�ړ��`�[�ԍ��F{0} �` {1}", this._stockMoveCndtn.St_StockMoveSlipNo, this._stockMoveCndtn.Ed_StockMoveSlipNo )
            //    );
            //}

            //// ���[�J�[�R�[�h ----------------------------------------------------------------------------------------------------
            //if ( ( this._stockMoveCndtn.St_GoodsMakerCd != 0 ) || ( this._stockMoveCndtn.Ed_GoodsMakerCd != 999 ) )
            //{
            //    this.EditCondition( ref addConditions, 
            //        string.Format( "���[�J�[�R�[�h�F{0} �` {1}", this._stockMoveCndtn.St_GoodsMakerCd, this._stockMoveCndtn.Ed_GoodsMakerCd )
            //    );
            //}

            //// ���i�R�[�h ----------------------------------------------------------------------------------------------------
            //if ( ( this._stockMoveCndtn.St_GoodsNo != string.Empty ) || ( this._stockMoveCndtn.Ed_GoodsNo != string.Empty ) )
            //{
            //    this.EditCondition( ref addConditions, 
            //        GetConditionRange( "���i�R�[�h", this._stockMoveCndtn.St_GoodsNo, this._stockMoveCndtn.Ed_GoodsNo ) );
            //}

            //foreach ( string exCondStr in addConditions )
            //{
            //    extraConditions.Add( exCondStr );
            //}
            //--- DEL 2008/08/12 ----------<<<<<

            //--- ADD 2008/08/12 ---------->>>>>
            extraConditions = new StringCollection();

            StringCollection addConditions = new StringCollection();

            // --- ADD 2008/10/02 -------------------------------->>>>>
            // �Ώۓ�
            string st_ShipArrivalDate = string.Empty;
            string ed_ShipArrivalDate = string.Empty;
            if ((this._stockMoveCndtn.St_ShipArrivalDate != DateTime.MinValue) || (this._stockMoveCndtn.Ed_ShipArrivalDate != DateTime.MinValue))
            {
                // �J�n
                if (this._stockMoveCndtn.St_ShipArrivalDate != DateTime.MinValue)
                    st_ShipArrivalDate = this._stockMoveCndtn.St_ShipArrivalDate.ToString("yyyy/MM/dd");
                else
                    st_ShipArrivalDate = ct_Extr_Top;
                // �I��
                if (this._stockMoveCndtn.Ed_ShipArrivalDate != DateTime.MinValue)
                    ed_ShipArrivalDate = this._stockMoveCndtn.Ed_ShipArrivalDate.ToString("yyyy/MM/dd");
                else
                    ed_ShipArrivalDate = ct_Extr_End;

                this.EditCondition(ref addConditions, string.Format("�Ώۓ�" + ct_RangeConst, st_ShipArrivalDate, ed_ShipArrivalDate));
            }

            // ������
            string st_CreateDate = string.Empty;
            string ed_CreateDate = string.Empty;
            if ((this._stockMoveCndtn.St_CreateDate != DateTime.MinValue) || (this._stockMoveCndtn.Ed_CreateDate != DateTime.MinValue))
            {
                // �J�n
                if (this._stockMoveCndtn.St_CreateDate != DateTime.MinValue)
                    st_CreateDate = this._stockMoveCndtn.St_CreateDate.ToString("yyyy/MM/dd");
                else
                    st_CreateDate = ct_Extr_Top;
                // �I��
                if (this._stockMoveCndtn.Ed_CreateDate != DateTime.MinValue)
                    ed_CreateDate = this._stockMoveCndtn.Ed_CreateDate.ToString("yyyy/MM/dd");
                else
                    ed_CreateDate = ct_Extr_End;

                this.EditCondition(ref addConditions, string.Format("������" + ct_RangeConst, st_CreateDate, ed_CreateDate));
            }
            
            // --- ADD 2008/10/02 -------------------------------->>>>>

            // �ړ����q��
            if ((this._stockMoveCndtn.St_MainBfAfEnterWarehCd != string.Empty) || (this._stockMoveCndtn.Ed_MainBfAfEnterWarehCd != string.Empty))
            {
                this.EditCondition(ref addConditions,
                    GetConditionRange("�ړ����q��", this._stockMoveCndtn.St_MainBfAfEnterWarehCd, this._stockMoveCndtn.Ed_MainBfAfEnterWarehCd));
            }

            // ���s�^�C�v
            this.EditCondition(ref addConditions, String.Format("���s�^�C�v�F{0}", this._stockMoveCndtn.PrintTypeTitle));

            // �ړ��拒�_
            if ((this._stockMoveCndtn.St_ShipArrivalSectionCd != string.Empty) || (this._stockMoveCndtn.Ed_ShipArrivalSectionCd != string.Empty))
            {
                this.EditCondition(ref addConditions,
                    GetConditionRange("�ړ��拒�_", this._stockMoveCndtn.St_ShipArrivalSectionCd, this._stockMoveCndtn.Ed_ShipArrivalSectionCd));
            }

            // �ړ���q��
            if ((this._stockMoveCndtn.St_ShipArrivalEnterWarehCd != string.Empty) || (this._stockMoveCndtn.Ed_ShipArrivalEnterWarehCd != string.Empty))
            {
                this.EditCondition(ref addConditions,
                    GetConditionRange("�ړ���q��", this._stockMoveCndtn.St_ShipArrivalEnterWarehCd, this._stockMoveCndtn.Ed_ShipArrivalEnterWarehCd));
            }

            // �o�͎w��
            this.EditCondition(ref addConditions, String.Format("�o�͎w��F{0}", this._stockMoveCndtn.OutputDesignatTitle));

            // ���z�w��
            this.EditCondition(ref addConditions, String.Format("���z�w��F{0}", this._stockMoveCndtn.PriceDesignatTitle));

            // ���͒S����
            if ((this._stockMoveCndtn.St_StockMvEmpCode != string.Empty) || (this._stockMoveCndtn.Ed_StockMvEmpCode != string.Empty))
            {
                this.EditCondition(ref addConditions,
                    GetConditionRange("���͒S����", this._stockMoveCndtn.St_StockMvEmpCode, this._stockMoveCndtn.Ed_StockMvEmpCode));
            }

            foreach (string exCondStr in addConditions)
            {
                extraConditions.Add(exCondStr);
            }

            //--- ADD 2008/08/12 ----------<<<<<
		}
		#endregion

		#region �� ���o�͈͕�����쐬
		/// <summary>
		/// ���o�͈͕�����쐬
		/// </summary>
		/// <returns>�쐬������</returns>
		/// <remarks>
		/// <br>Note       : ���o�͈͕�������쐬���܂�</br>
		/// <br>Programmer : 22013 �v�� ����</br>
		/// <br>Date       : 2007.03.08</br>
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
		#endregion

		#region �� ���o����������ҏW
		/// <summary>
		/// ���o����������ҏW
		/// </summary>
		/// <param name="editArea">�i�[�G���A</param>
		/// <param name="target">�Ώە�����</param>
		/// <remarks>
		/// <br>Note       : �o�͂��钊�o�����������ҏW���܂��B</br>
		/// <br>Programmer : 22013 �v�� ����</br>
		/// <br>Date       : 2007.03.08</br>
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
		/// <br>Programmer : 22013 �v�� ����</br>
		/// <br>Date       : 2007.03.08</br>
		/// </remarks>
		private DialogResult MsgDispProc(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
		{
			return TMsgDisp.Show(iLevel, "MAZAI02032P", iMsg, iSt, iButton, iDefButton);
		}

		#endregion
		#endregion
	}
}

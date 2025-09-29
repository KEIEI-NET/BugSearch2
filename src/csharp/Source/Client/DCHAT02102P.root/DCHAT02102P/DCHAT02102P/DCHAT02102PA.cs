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
	/// �����ꗗ�\����N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : �����ꗗ�\�̈�����s���B</br>
	/// <br>Programmer : 22018 ��� ���b</br>
	/// <br>Date       : 2007.09.19</br>
    /// -----------------------------------------------------------------------------------
    /// <br>UpdateNote : PM.NS�Ή�</br>
    /// <br>Programmer : ����</br>
    /// <br>Date	   : 2008.09.03</br>
    /// <br>UpdateNote : �����c�ꗗ�\�ǉ�</br>
    /// <br>Programmer : �a�J�@���</br>
    /// <br>Date	   : 2008.12.10</br>
    /// <br>UpdateNote : �r�����䏈���ǉ�</br>
    /// <br>Programmer : �E�@�K�j</br>
    /// <br>Date	   : 2009.02.02</br>
    /// <br>UpdateNote : Redmine#34986 �����ꗗ�\�X�V���s�̏ꍇ�A�G���[���b�Z�[�W�̏C��</br>
    /// <br>Programmer : pengjie</br>
    /// <br>Date	   : 2013.03.14</br>
    /// <br>UpdateNote : �n���f�B�^�[�~�i���񎟊J���̑Ή�</br>
    /// <br>Programmer : 杍^</br>
    /// <br>Date	   : 2017/09/14</br>
    /// </remarks>
	class DCHAT02102PA: IPrintProc
	{

		#region �� Constructor
		/// <summary>
		/// �����ꗗ�\����N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �����ꗗ�\����N���X�̃C���X�^���X�̍쐬���s���B</br>
		/// <br>Programmer : 22018 ��� ���b</br>
		/// <br>Date       : 2007.09.19</br>
		/// </remarks>
		public DCHAT02102PA()
		{
		}

		/// <summary>
		/// �����ꗗ�\����N���X�R���X�g���N�^
		/// </summary>
		/// <param name="printInfo">������I�u�W�F�N�g</param>
		/// <remarks>
		/// <br>Note       : �����ꗗ�\����N���X�̃C���X�^���X�̍쐬���s���B</br>
		/// <br>Programmer : 22018 ��� ���b</br>
		/// <br>Date       : 2007.09.19</br>
		/// </remarks>
		public DCHAT02102PA( object printInfo )
		{
			this._printInfo = printInfo as SFCMN06002C;
			this._orderListCndtn = this._printInfo.jyoken as OrderListCndtn;
		}
		#endregion �� Constructor

		#region �� Pricate Const
		private const string ct_ReportForm_NameSpace = "Broadleaf.Drawing.Printing";
		private const string ct_Space			= "�@";
		private const string ct_Extr_Top		= "�s�n�o";
		private const string ct_Extr_End		= "�d�m�c";
		private	const string ct_RangeConst		= "�F{0} �` {1}";
		#endregion �� Pricate Const

		#region �� Private Member
		private SFCMN06002C _printInfo;					// ������N���X
		private OrderListCndtn _orderListCndtn;		// ���o�����N���X
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
            // 2008.09.03 30413 ���� ���g�p�v���p�e�B�폜 >>>>>>START
            //int number = 0;
            //number = 1;
            // 2008.09.03 30413 ���� ���g�p�v���p�e�B�폜 <<<<<<END
            
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
        /// <br>UpdateNote : Redmine#34986 �����ꗗ�\�X�V���s�̏ꍇ�A�G���[���b�Z�[�W�̏C��</br>
        /// <br>Programmer : pengjie</br>
        /// <br>Date	   : 2013.03.14</br>
        /// <br>UpdateNote : �n���f�B�^�[�~�i���񎟊J���̑Ή�</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date	   : 2017/09/14</br>
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
                prtRpt.DataMember = DCHAT02104EA.ct_Tbl_OrderList;
				
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

                // ------ ADD 2017/09/14 杍^ �n���f�B�^�[�~�i���񎟊J�� --------- >>>>
                // �o�[�R�[�h�\�����Ȃ��ꍇ
                if (((OrderListCndtn)this._printInfo.jyoken).BarCodeShowDiv != 0)
                {
                // ------ ADD 2017/09/14 杍^ �n���f�B�^�[�~�i���񎟊J�� --------- <<<<
                    // 2008.12.10 UPD 1:�����c�ꗗ�\�̏ꍇ�͏������I�� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    if (((OrderListCndtn)this._printInfo.jyoken).PrtPaperTypeDiv == 0)
                    {
#if true
                        // ��������擾
                        OrderListCndtn extraInfo = (OrderListCndtn)this._printInfo.jyoken;
                        OrderListAcs orderListAcs = new OrderListAcs();
                        int st = orderListAcs.UpdateOrderDate(extraInfo.BlanketStockInputDataDiv);
                        // --- CHG 2009/02/02 �r�����䏈���ǉ�------------------------------------------------------>>>>>
                        //if (st != 0)
                        //{
                        //    MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        //                "�����f�[�^�̍X�V�����s���܂����B",
                        //                st,
                        //                MessageBoxButtons.OK,
                        //                MessageBoxDefaultButton.Button1);
                        //}
                        switch (st)
                        {
                            case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                                {
                                    break;
                                }
                            // ��ƃ��b�N�^�C���A�E�g
                            case (int)ConstantManagement.DB_Status.ctDB_ENT_LOCK_TIMEOUT:
                                {
                                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP,
                                        "DCHAT02102P",
                                        "�X�V�Ɏ��s���܂����B" + "\r\n"
                                        + "\r\n" +
                                        "�V�F�A�`�F�b�N�G���[�i��ƃ��b�N�j�ł��B" + "\r\n" +
                                        "�����������A���̑��̋Ɩ����s���Ă��邽�ߖ{�����͍s���܂���B" + "\r\n" +
                                        "�Ď��s���邩�A���΂炭�҂��Ă���ēx�������s���Ă��������B",
                                        status,
                                        MessageBoxButtons.OK);
                                    break;
                                }
                            // ���_���b�N�^�C���A�E�g
                            case (int)ConstantManagement.DB_Status.ctDB_SEC_LOCK_TIMEOUT:
                                {
                                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP,
                                        "DCHAT02102P",
                                        "�X�V�Ɏ��s���܂����B" + "\r\n"
                                        + "\r\n" +
                                        "�V�F�A�`�F�b�N�G���[�i���_���b�N�j�ł��B" + "\r\n" +
                                        "���������A���������ݍ����Ă��邽�߃^�C���A�E�g���܂����B" + "\r\n" +
                                        "�Ď��s���邩�A���΂炭�҂��Ă���ēx�������s���Ă��������B",
                                        status,
                                        MessageBoxButtons.OK);
                                    break;
                                }
                            // �q�Ƀ��b�N�^�C���A�E�g
                            case (int)ConstantManagement.DB_Status.ctDB_WAR_LOCK_TIMEOUT:
                                {
                                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP,
                                        "DCHAT02102P",
                                        "�X�V�Ɏ��s���܂����B" + "\r\n"
                                        + "\r\n" +
                                        "�V�F�A�`�F�b�N�G���[�i�q�Ƀ��b�N�j�ł��B" + "\r\n" +
                                        "�I���������A���̑��̍݌ɋƖ����s���Ă��邽�߃^�C���A�E�g���܂����B" + "\r\n" +
                                        "�Ď��s���邩�A���΂炭�҂��Ă���ēx�������s���Ă��������B",
                                        status,
                                        MessageBoxButtons.OK);
                                    break;
                                }
                            default:
                                {
                                    MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                        // "�����f�[�^�̍X�V�����s���܂����B",  // DEL pengjie 2013/03/14 REDMINE#34986 
                                        "�����f�[�^�̍X�V�����s���܂����B" + "ST=" + st, // ADD pengjie 2013/03/14 REDMINE#34986 
                                        st,
                                        MessageBoxButtons.OK,
                                        MessageBoxDefaultButton.Button1);
                                    break;
                                }
                        }
                        // --- CHG 2009/02/02 �r�����䏈���ǉ�------------------------------------------------------<<<<<
#else
                    // �����f�[�^�X�V
                    DialogResult ret = MessageBox.Show("�����f�[�^���X�V���܂����H", "�����f�[�^�X�V�m�F", MessageBoxButtons.YesNo);
                    if (ret == DialogResult.Yes)
                    {
                        // ��������擾
                        OrderListCndtn extraInfo = (OrderListCndtn)this._printInfo.jyoken;
                        OrderListAcs orderListAcs = new OrderListAcs();
                        int st = orderListAcs.UpdateOrderDate(extraInfo.BlanketStockInputDataDiv);
                        if (st == 0)
                        {
                            MessageBox.Show("�����f�[�^�̍X�V���������܂����B", "�����f�[�^�X�V�����ʒm");
                        }
                        else
                        {
                            MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                        "�����f�[�^�̍X�V�����s���܂����B",
                                        st,
                                        MessageBoxButtons.OK,
                                        MessageBoxDefaultButton.Button1);
                        }
#endif
                    }
                } // ADD 2017/09/14 杍^ �n���f�B�^�[�~�i���񎟊J��

                /*
                }
#if true
                // ��������擾
                OrderListCndtn extraInfo = (OrderListCndtn)this._printInfo.jyoken;
                OrderListAcs orderListAcs = new OrderListAcs();
                int st = orderListAcs.UpdateOrderDate(extraInfo.BlanketStockInputDataDiv);
                if (st != 0)
                {
                    MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                "�����f�[�^�̍X�V�����s���܂����B",
                                st,
                                MessageBoxButtons.OK,
                                MessageBoxDefaultButton.Button1);
                }
#else
                // �����f�[�^�X�V
                DialogResult ret = MessageBox.Show("�����f�[�^���X�V���܂����H", "�����f�[�^�X�V�m�F", MessageBoxButtons.YesNo);
                if (ret == DialogResult.Yes)
                {
                    // ��������擾
                    OrderListCndtn extraInfo = (OrderListCndtn)this._printInfo.jyoken;
                    OrderListAcs orderListAcs = new OrderListAcs();
                    int st = orderListAcs.UpdateOrderDate(extraInfo.BlanketStockInputDataDiv);
                    if (st == 0)
                    {
                        MessageBox.Show("�����f�[�^�̍X�V���������܂����B", "�����f�[�^�X�V�����ʒm");
                    }
                    else
                    {
                        MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                    "�����f�[�^�̍X�V�����s���܂����B",
                                    st,
                                    MessageBoxButtons.OK,
                                    MessageBoxDefaultButton.Button1);
                    }
                }                
#endif
                */
                // 2008.12.10 UPD 1:�����c�ꗗ�\�̏ꍇ�͏������I�� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

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
		/// <param name="commonInfo"></param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �����ʋ��ʏ����̐ݒ���s���܂��B</br>
		/// <br>Programmer : 22018 ��� ���b</br>
		/// <br>Date       : 2007.09.19</br>
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
            commonInfo.PrintMax = (this._printInfo.rdData as DataView).Count;
			
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
		/// <br>Programmer : 22018 ��� ���b</br>
		/// <br>Date       : 2007.09.19</br>
		/// </remarks>
		private int SettingProperty(ref DataDynamics.ActiveReports.ActiveReport3 rpt)
		{
			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

			// ActiveReport�C���^�[�t�F�[�X�ɃL���X�g
			IPrintActiveReportTypeList instance = rpt as IPrintActiveReportTypeList;

			// ��������擾
            OrderListCndtn extraInfo = (OrderListCndtn)this._printInfo.jyoken;

			// �\�[�g���v���p�e�B�ݒ�
            instance.PageHeaderSortOderTitle = extraInfo.PrintSortDivTitle;
			
			// ���[�o�͐ݒ���擾 
			PrtOutSet prtOutSet;
			string message;
			int st = OrderListAcs.ReadPrtOutSet(out prtOutSet, out message);
			if (st != 0) 
			{
                throw new StockMoveException(message, status);
            }

           
			
			// ���o�����w�b�_�o�͋敪
			instance.ExtraCondHeadOutDiv = prtOutSet.ExtraCondHeadOutDiv;

            // 2008.09.03 30413 ���� ���o�����͈󎚂��Ȃ� >>>>>>START
            //// ���o�����ҏW����
            //StringCollection extraInfomations;
            //this.MakeExtarCondition( out extraInfomations );

            //instance.ExtraConditions = extraInfomations;
            // 2008.09.03 30413 ���� ���o�����͈󎚂��Ȃ� <<<<<<END
        
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
            object[] titleObj = new object[] { _printInfo.prpnm };
            instance.PageHeaderSubtitle = string.Format("{0}", titleObj);

			// ���̑��f�[�^
			instance.OtherDataList = null;

			status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

			return status;
		}

		#endregion

        // 2008.09.03 30413 ���� ���o�����͈󎚂��Ȃ� >>>>>>START
        #region �� ���o�����o�͏��쐬
        ///// <summary>
        ///// ���o�����o�͏��쐬
        ///// </summary>
        ///// <param name="extraConditions">�쐬�㒊�o�����R���N�V����</param>
        ///// <remarks>
        ///// <br>Note       : �o�͂��钊�o������������쐬����B</br>
        ///// <br>Programmer : 22018 ��� ���b</br>
        ///// <br>Date       : 2007.09.19</br>
        ///// </remarks>
        //private void MakeExtarCondition( out StringCollection extraConditions )
        //{
        //    extraConditions = new StringCollection();
        //    StringCollection addConditions = new StringCollection();

        //    //-------------------------------------------------------------------------------------------------------
        //    // ���͓�
        //    this.EditCondition(ref addConditions,
        //        GetExtarConditionOfDates("���͓�", this._orderListCndtn.St_OrderDataCreateDate, this._orderListCndtn.Ed_OrderDataCreateDate));

        //    //-------------------------------------------------------------------------------------------------------
        //    // ������
        //    this.EditCondition(ref addConditions,
        //        GetExtarConditionOfDates("������", this._orderListCndtn.St_OrderFormPrintDate, this._orderListCndtn.St_OrderFormPrintDate));

        //    //-------------------------------------------------------------------------------------------------------
        //    // ��]�[��
        //    this.EditCondition(ref addConditions,
        //        GetExtarConditionOfDates("��]�[��", this._orderListCndtn.St_ExpectDeliveryDate, this._orderListCndtn.Ed_ExpectDeliveryDate));

        //    ////-------------------------------------------------------------------------------------------------------
        //    //// �\�[�g��
        //    //this.EditCondition(ref addConditions, String.Format("�\�[�g���F{0}",this._orderListCndtn.PrintSortDivTitle));

        //    //-------------------------------------------------------------------------------------------------------
        //    // �������
        //    this.EditCondition( ref addConditions, String.Format( "������ԁF{0}", this._orderListCndtn.OrderFormIssuedDivTitle ) );

        //    //-------------------------------------------------------------------------------------------------------
        //    // �����`��
        //    this.EditCondition( ref addConditions, String.Format( "�����`�ԁF{0}", this._orderListCndtn.StockOrderDivCdTitle ) );


        //    //-------------------------------------------------------------------------------------------------------
        //    // ���׏�
        //    this.EditCondition(ref addConditions, String.Format("���׏󋵁F{0}", this._orderListCndtn.ArrivalStateDivTitle));

        //    //-------------------------------------------------------------------------------------------------------
        //    // �S���҃R�[�h
        //    if ( ( !string.IsNullOrEmpty(this._orderListCndtn.St_StockAgentCode) ) || ( !string.IsNullOrEmpty(this._orderListCndtn.Ed_StockAgentCode) ) ) {
        //        this.EditCondition(ref addConditions,
        //            string.Format("�S����" + ct_RangeConst, this._orderListCndtn.St_StockAgentCode, this._orderListCndtn.Ed_StockAgentCode)
        //        );
        //    }
        //    //-------------------------------------------------------------------------------------------------------
        //    // ���͎҃R�[�h
        //    if ( ( !string.IsNullOrEmpty(this._orderListCndtn.St_StockInputCode) ) || ( !string.IsNullOrEmpty(this._orderListCndtn.Ed_StockInputCode) ) ) {
        //        this.EditCondition(ref addConditions,
        //            string.Format("���͎�" + ct_RangeConst, this._orderListCndtn.St_StockInputCode, this._orderListCndtn.Ed_StockInputCode)
        //        );
        //    }
        //    //-------------------------------------------------------------------------------------------------------
        //    // ������R�[�h
        //    if ( ( this._orderListCndtn.St_SupplierCd != 0 ) || ( this._orderListCndtn.Ed_SupplierCd != 999999999 ) ) {
        //        this.EditCondition(ref addConditions,
        //            string.Format("������" + ct_RangeConst, this._orderListCndtn.St_SupplierCd, this._orderListCndtn.Ed_SupplierCd)
        //        );
        //    }
        //    //-------------------------------------------------------------------------------------------------------
        //    // �q�ɃR�[�h
        //    if ( ( !string.IsNullOrEmpty(this._orderListCndtn.St_WarehouseCode) ) || ( !string.IsNullOrEmpty(this._orderListCndtn.Ed_WarehouseCode) ) ) {
        //        this.EditCondition(ref addConditions,
        //            string.Format("�q��" + ct_RangeConst, this._orderListCndtn.St_WarehouseCode, this._orderListCndtn.Ed_WarehouseCode)
        //        );
        //    }
        //    //-------------------------------------------------------------------------------------------------------
        //    // ���[�J�[�R�[�h
        //    if ( ( this._orderListCndtn.St_GoodsMakerCd != 0 ) || ( this._orderListCndtn.Ed_GoodsMakerCd != 999999 ) ) {
        //        this.EditCondition(ref addConditions,
        //            string.Format("���[�J�[" + ct_RangeConst, this._orderListCndtn.St_GoodsMakerCd, this._orderListCndtn.Ed_GoodsMakerCd)
        //        );
        //    }
        //    //-------------------------------------------------------------------------------------------------------
        //    // ���i�ԍ�
        //    if ( ( !string.IsNullOrEmpty(this._orderListCndtn.St_GoodsNo) ) || ( !string.IsNullOrEmpty(this._orderListCndtn.Ed_GoodsNo) ) ) {
        //        this.EditCondition(ref addConditions,
        //            string.Format("���i�ԍ�" + ct_RangeConst, this._orderListCndtn.St_GoodsNo, this._orderListCndtn.Ed_GoodsNo)
        //        );
        //    }

        //    // �ǉ�
        //    foreach ( string exCondStr in addConditions ) {
        //        extraConditions.Add(exCondStr);
        //    }
        //}
        // 2008.09.03 30413 ���� ���o�����͈󎚂��Ȃ� <<<<<<END
        
        /// <summary>
        /// ���t�͈̔͏��������񐶐�
        /// </summary>
        /// <param name="dateTitle">���t�^�C�g��</param>
        /// <param name="stDate">�J�n���t</param>
        /// <param name="edDate">�I�����t</param>
        /// <returns></returns>
        private string GetExtarConditionOfDates( string dateTitle, DateTime stDate, DateTime edDate )
        {
            string wkStDate = string.Empty;
            string wkEdDate = string.Empty;

            string resultString = string.Empty;

            // �J�n��I���̂����ꂩ�����͂���Ă���Έ�
            if ( ( stDate != DateTime.MinValue ) || ( edDate != DateTime.MinValue ) ) {
                // �J�n
                if ( stDate != DateTime.MinValue ) {
                    wkStDate = stDate.ToString("yyyy/MM/dd");
                }
                else {
                    wkStDate = ct_Extr_Top;
                }

                // �I��
                if ( edDate != DateTime.MinValue ) {
                    wkEdDate = edDate.ToString("yyyy/MM/dd");
                }
                else {
                    wkEdDate = ct_Extr_End;
                }

                resultString = string.Format( dateTitle + ct_RangeConst, wkStDate, wkEdDate);
            }

            return resultString;
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
			return TMsgDisp.Show(iLevel, "DCHAT02102P", iMsg, iSt, iButton, iDefButton);
		}

		#endregion
		#endregion
	}
}

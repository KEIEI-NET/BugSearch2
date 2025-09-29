//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : ����m�F�\
// �v���O�����T�v   : ����m�F�\�̈�����s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30413 ����
// �� �� ��  2008/07/08  �C�����e : Partsman�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30413 ����
// �C �� ��  2009/06/12  �C�����e : ��Q�Ή�13453
//----------------------------------------------------------------------------//

#define CHG20060329
#define CHG20060410
#define CHG20060418
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Drawing.Printing;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Text;

namespace Broadleaf.Drawing.Printing
{
    /// <summary>
    /// ����m�F�\ ����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ����m�F�\�̈���N���X�ł�</br>
    /// <br>Programer  : 30413 ����</br>
    /// <br>Date       : 2008.07.08</br>
    /// </remarks>
    public class MAHNB02343PA
	{
		//================================================================================
		//  �R���X�g���N�^�[
		//================================================================================
		#region �R���X�g���N�^�[
        /// <summary>
        /// ����m�F�\ ����N���X�ÓI�R���X�g���N�^�[
        /// </summary>
        /// <remarks>
        /// <br>Note       : �R���X�g���N�^�[</br>
        /// <br>Programer  : 30413 ����</br>
        /// <br>Date       : 2008.07.08</br>
        /// </remarks>
        public MAHNB02343PA()
		{
		}
        /// <summary>
        /// ����m�F�\ ����N���X�ÓI�R���X�g���N�^�[
        /// </summary>
        /// <param name="printInfo">������</param>
        /// <remarks>
        /// <br>Note       : �R���X�g���N�^�[</br>
        /// <br>Programer  : 30413 ����</br>
        /// <br>Date       : 2008.07.08</br>
        /// </remarks>
        public MAHNB02343PA(object printInfo)
		{
			this._printInfo         = printInfo as SFCMN06002C;
			
			this._pdfHistoryControl = new PdfHistoryControl();
			this._sfcmn00331C       = new SFCMN00331C();

            this._csSaleOrderPara = this._printInfo.jyoken as ExtrInfo_MAHNB02347E;

            this.SelectTableName();

         }
		#endregion

		//================================================================================
		//  �����萔
		//================================================================================
		#region private constant
		private const string CT_REPORTFORM_NAMESPASE = "Broadleaf.Drawing.Printing";
		private const string CT_ITEM_INTERVAL        = "�@";

		#endregion
		
		//================================================================================
		//  �����ϐ�
		//================================================================================
		#region private member    
		private SFCMN06002C     _printInfo           = null;
		private PdfHistoryControl _pdfHistoryControl = null;
		private SFCMN00331C _sfcmn00331C             = null;			// ���[�n���ʕ��i
        private ExtrInfo_MAHNB02347E _csSaleOrderPara = null;
        #endregion

        // �� 2007.11.08 Keigo Yata Delete ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>�\������</summary>
        //private string CT_Sort1_Odr = "SectionCodeRF, SalesDateRF, SalesSlipNumRF, SalesRowNoRF, SalesSlipExpNumRF";                                               // ��������`�[�ԍ�
        //private string CT_Sort2_Odr = "SectionCodeRF, SalesDateRF, CustomerCodeRF, SalesFormCodeRF, GoodsCodeRF, SalesSlipNumRF, SalesRowNoRF, SalesSlipExpNumRF"; // ����������Ӑ恨�̔��`�ԁ����i���`�[�ԍ�
        //private string CT_Sort3_Odr = "SectionCodeRF, SalesDateRF, CustomerCodeRF, SalesSlipNumRF, SalesRowNoRF, SalesSlipExpNumRF";                               // ����������Ӑ恨�`�[�ԍ�
        //private string CT_Sort4_Odr = "SectionCodeRF, SalesFormCodeRF, CustomerCodeRF, SalesDateRF, SalesSlipNumRF, SalesRowNoRF, SalesSlipExpNumRF";              // �̔��`�ԁ����Ӑ恨��������`�[�ԍ�
        //private string CT_Sort5_Odr = "SectionCodeRF, SalesSlipNumRF, SalesRowNoRF, SalesSlipExpNumRF";                                                            // �`�[�ԍ�

        //private string CT_Sort1_OdrStr = "��������`�[�ԍ�";
        //private string CT_Sort2_OdrStr = "����������Ӑ恨�̔��`�ԁ����i���`�[�ԍ�";
        //private string CT_Sort3_OdrStr = "����������Ӑ恨�`�[�ԍ�";
        //private string CT_Sort4_OdrStr = "�̔��`�ԁ����Ӑ恨��������`�[�ԍ�";
        //private string CT_Sort5_OdrStr = "�`�[�ԍ�";
        // �� 2007.11.08 Keigo Yata Delete ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // 2008.07.08 30413 ���� �o�͏��̃v���p�e�B�ύX >>>>>>START
        // �� 2007.11.08 Keigo Yata Add ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //private string CT_Sort1_Odr = "SectionCodeRF, SalesDateRF, SalesSlipNumRF, SalesRowNoRF";                                 // �����+�`�[�ԍ�
        //private string CT_Sort2_Odr = "SectionCodeRF, CustomerCodeRF, SalesDateRF, SalesSlipNumRF"; �@                            // ���Ӑ�+�����+�`�[�ԍ�
        //private string CT_Sort3_Odr = "SectionCodeRF, SearchSlipDateRF, SalesSlipNumRF, SalesRowNoRF";                            // ���͓�+�`�[�ԍ�
        //private string CT_Sort4_Odr = "SectionCodeRF, CustomerCodeRF, SearchSlipDateRF, SalesSlipNumRF, SalesRowNoRF";            // ���Ӑ�+���͓�+�`�[�ԍ�
        //private string CT_Sort5_Odr = "SectionCodeRF, SalesEmployeeNmRF, SalesSlipNumRF, SalesRowNoRF";                           // �S����+�`�[�ԍ�
        //private string CT_Sort6_Odr = "SectionCodeRF, SalesAreaCodeRF, SalesSlipNumRF, SalesRowNoRF";                             // �n��+�`�[�ԍ�

        //private string CT_Sort1_OdrStr = "�����+�`�[�ԍ�";
        //private string CT_Sort2_OdrStr = "���Ӑ�+�����+�`�[�ԍ�";
        //private string CT_Sort3_OdrStr = "���͓�+�`�[�ԍ�";
        //private string CT_Sort4_OdrStr = "���Ӑ�+���͓�+�`�[�ԍ�";
        //private string CT_Sort5_OdrStr = "�S����+�`�[�ԍ�";
        //private string CT_Sort6_OdrStr = "�̔��G���A+�`�[�ԍ�";
        // �� 2007.11.08 Keigo Yata Delete ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private string CT_Sort1_Odr = "SectionCode, SalesDate, SalesSlipNum, SalesRowNo";                               // ���_+�����+�`�[�ԍ�+�`�[�s�ԍ�
        private string CT_Sort2_Odr = "SectionCode, CustomerCode, SalesDate, SalesSlipNum, SalesRowNo"; �@              // ���_+���Ӑ�+�����+�`�[�ԍ�+�`�[�s�ԍ�
        private string CT_Sort3_Odr = "SectionCode, SearchSlipDate, SalesSlipNum, SalesRowNo";                          // ���_+���͓�+�`�[�ԍ�+�`�[�s�ԍ�
        private string CT_Sort4_Odr = "SectionCode, CustomerCode, SearchSlipDate, SalesSlipNum, SalesRowNo";            // ���_+���Ӑ�+���͓�+�`�[�ԍ�+�`�[�s�ԍ�
        // 2009.01.26 30413 ���� �S���Җ����S���҃R�[�h�ɏC�� >>>>>>START
        //private string CT_Sort5_Odr = "SectionCode, SalesEmployeeNm, SalesSlipNum, SalesRowNo";                         // ���_+�S����+�`�[�ԍ�+�`�[�s�ԍ�
        private string CT_Sort5_Odr = "SectionCode, SalesEmployeeCd, SalesSlipNum, SalesRowNo";                         // ���_+�S����+�`�[�ԍ�+�`�[�s�ԍ�
        // 2009.01.26 30413 ���� �S���Җ����S���҃R�[�h�ɏC�� <<<<<<END
        private string CT_Sort6_Odr = "SectionCode, SalesAreaCode, SalesSlipNum, SalesRowNo";                           // ���_+�n��(�̔��G���A)+�`�[�ԍ�+�`�[�s�ԍ�
        private string CT_Sort7_Odr = "SectionCode, BusinessTypeCode, SalesSlipNum, SalesRowNo";                        // ���_+�Ǝ�+�`�[�ԍ�+�`�[�s�ԍ�
        // ADD 2009/06/12 ------>>>
        private string CT_Sort8_Odr = "SectionCode, SalesSlipNum, SalesRowNo";                                          // ���_+�`�[�ԍ�+�`�[�s�ԍ�
        // ADD 2009/06/12 ------<<<
        
        private string CT_Sort1_OdrStr = "�����+�`�[�ԍ�";
        private string CT_Sort2_OdrStr = "���Ӑ�+�����+�`�[�ԍ�";
        private string CT_Sort3_OdrStr = "���͓�+�`�[�ԍ�";
        private string CT_Sort4_OdrStr = "���Ӑ�+���͓�+�`�[�ԍ�";
        private string CT_Sort5_OdrStr = "�S����+�`�[�ԍ�";
        private string CT_Sort6_OdrStr = "�n��+�`�[�ԍ�";
        private string CT_Sort7_OdrStr = "�Ǝ�+�`�[�ԍ�";
        // ADD 2009/06/12 ------>>>
        private string CT_Sort8_OdrStr = "�`�[�ԍ�";
        // ADD 2009/06/12 ------<<<
        // 2008.07.08 30413 ���� �o�͏���ǉ� <<<<<<END
        
        // �f�[�^�擾���e�[�u����
        private string ct_TableName;

		//================================================================================
		//  �O���񋟃v���p�e�B
		//================================================================================
		#region public property
		#region IPrintProc�̎�����(�v���p�e�B) 
		/// <summary>����f�[�^</summary>
		/// <value>�������f�[�^���擾�܂��͐ݒ肵�܂��B</value>
		public SFCMN06002C Printinfo
		{
			get { return _printInfo; }
			set { _printInfo = value; }
		}
		#endregion
		#endregion

		// ===============================================================================
		// ��O�N���X
		// ===============================================================================
		#region ��O�N���X
		private class DemandPrintException: ApplicationException
		{
			private int _status;

			#region constructor
			public DemandPrintException(string message, int status): base(message)
			{
				this._status = status; 
			}
			#endregion
    
			#region public property
			public int Status
			{
				get{return this._status;}
			}
			#endregion
		}
		#endregion
		
		//================================================================================
		//  IPrintProc�̎������@������C������
		//================================================================================
		#region IPrintProc�̎�����
		/// <summary>
		/// ����J�n����
		/// </summary>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : ����̊J�n�������s���܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.11.17</br>
		/// </remarks>
		public int StartPrint()
		{
			return this.PrintMain();
		}
		#endregion

		//================================================================================
		// �����֐�
		//================================================================================
		#region Private Methods
		#region ���@������C������
		/// <summary>
		/// ������C������
		/// </summary>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : ����̃��C���������s���܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.11.15</br>
		/// </remarks>
		private int PrintMain()
		{

			int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

			try
			{
				// ����t�H�[���N���X�C���X�^���X�쐬
				DataDynamics.ActiveReports.ActiveReport3 prtRpt;

				// ���|�[�g�C���X�^���X�쐬
				this.CreateReport(out prtRpt, this._printInfo.prpid); 
				if (prtRpt == null) return status;

				// �e��v���p�e�B�ݒ�
				status = this.SettingProperty(ref prtRpt);
				if (status != 0) return status;

				// ����f�[�^�擾
				DataSet ds = (DataSet)this._printInfo.rdData;
				DataView dv = new DataView();
                dv.Table = ds.Tables[ct_TableName];
				
				// �\�[�g���ݒ�
				dv.Sort = this.GetPrintOderQuerry();
				
				// �f�[�^�\�[�X�ݒ�
				prtRpt.DataSource = dv;

				// ������ʏ��v���p�e�B�ݒ�
				Broadleaf.Windows.Forms.SFCMN00293UC commonInfo;
				this.SetPrintCommonInfo(out commonInfo);

				// �v���r���[�L��				
				int prevkbn = this._printInfo.prevkbn;
               
                // �o�̓��[�h���o�c�e�̏ꍇ�A�������Ńv���r���[��
				if (this._printInfo.printmode == 2)
				{
					prevkbn = 0;
				}
				switch(prevkbn)
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
						case 1:		// �v�����^
							break;
						case 2:		// �o�c�e
						case 3:		// ����(�v�����^ + �o�c�e)
						{
							// �o�c�e�\���t���OON
							this._printInfo.pdfopen = true;
							
							// ����������̂ݗ���ۑ�
							if (this._printInfo.printmode == 3)
							{
                                // 2007.05.23 modified by T-Kidate : PDF�����Ǘ����i�̏����������̒ǉ�
                                //// �o�͗����Ǘ��ɒǉ�
                                //this._pdfHistoryControl.AddPrintHistoryList(this._printInfo.key, "����m�F�\", this._printInfo.prpnm,
                                //    this._printInfo.pdftemppath);

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
			catch(DemandPrintException ex)
			{
				TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP,
					ex.Message, ex.Status, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
			}
			catch(Exception ex)
			{
				TMessageBox(emErrorLevel.ERR_LEVEL_STOPDISP,
					ex.Message, -1, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
			}

			return status;
		}

        /// <summary>
        /// �d�l�e�[�u�����ݒ菈��
        /// </summary>
        private void SelectTableName()
        {
            //if(this._csSaleOrderPara.IsDetails == true)
            //{
                // ���גP��
                ct_TableName = MAHNB02349EA.CT_SalesConfDataTable;
            //}
            //else
            //{
            //    // ���_��
            //    ct_TableName = MAHNB02349EB.CT_SalesOrderSectionDataTable;
            //}

        }

		#endregion
	
		#region ���@ActiveReport���[�C���X�^���X�쐬�֘A
		/// <summary>
		/// �e��ActiveReport���[�C���X�^���X�쐬
		/// </summary>
		/// <param name="rptObj">�C���X�^���X�����ꂽ���[�t�H�[���N���X</param>
		/// <param name="prpid">���[�t�H�[��ID</param>
		/// <returns></returns>
		/// <remarks>
		/// <br>Note       : �w�肳�ꂽ�A�Z���u���y�уN���X�����A�N���X���C���X�^���X�����܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.11.15</br>
		/// </remarks>
		private void CreateReport(out DataDynamics.ActiveReports.ActiveReport3 rptObj,string prpid)
		{
			// ����t�H�[���N���X�C���X�^���X�쐬
			rptObj = (DataDynamics.ActiveReports.ActiveReport3)this.LoadAssemblyReport(
				prpid.Trim(), CT_REPORTFORM_NAMESPASE + "." + prpid.Trim(), 
				typeof(DataDynamics.ActiveReports.ActiveReport3));
		}

		/// <summary>
		/// �w�肳�ꂽ�A�Z���u���y�уN���X�����A�N���X���C���X�^���X������
		/// </summary>
		/// <param name="asmname">�A�Z���u������</param>
		/// <param name="classname">�N���X����</param>
		/// <param name="type">��������N���X�^</param>
		/// <returns>�C���X�^���X�����ꂽ�N���X</returns>
		/// <remarks>
		/// <br>Note       : �w�肳�ꂽ�A�Z���u���y�уN���X�����A�N���X���C���X�^���X�����܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.11.15</br>
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
				throw new DemandPrintException(asmname + "�����݂��܂���B",-1);
			}
			catch(System.Exception er)
			{
				throw new DemandPrintException(er.Message, -1);
			}
			return obj;
		}
		#endregion
	
		#region ���@AvtiveReport�Ɋe��v���p�e�B��ݒ肵�܂�
		/// <summary>
		/// �e��v���p�e�B�ݒ�
		/// </summary>
		/// <param name="rpt">�C���X�^���X�����ꂽ���[�t�H�[���N���X</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �e��v���p�e�B��ݒ肵�܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.11.15</br>
		/// </remarks>
		private int SettingProperty(ref DataDynamics.ActiveReports.ActiveReport3 rpt)
		{
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // ActiveReport�C���^�[�t�F�[�X�ɃL���X�g
            IPrintActiveReportTypeList instance = rpt as IPrintActiveReportTypeList;


            // ���[�o�͐ݒ���擾 
            PrtOutSet prtOutSet;
            string message;

            int st = SaleConfAcs.ReadPrtOutSet(out prtOutSet, out message);

            if (st != 0)
            {
                throw new DemandPrintException(message, status);
            }

            // ���o�����ҏW����
            StringCollection extraInfomations;
            this.MakeExtarCondition(out extraInfomations);

            instance.ExtraConditions = extraInfomations;

            // �� 2007.11.08 Keigo Yata Add ////////////////////////////////////////////////////
            // �e���`�F�b�N�͈�(�R���g���[���ɒl������ꍇ�ɏo��)
            if ((this._csSaleOrderPara.GrsProfitCheckLower != 0) && (this._csSaleOrderPara.GrsProfitCheckBest != 0))
            {
                if (this._csSaleOrderPara.GrsProfitCheckUpper != 0)
                {
                    string makegrossmargin = "";
                    this.MakeGrossMargin(out makegrossmargin);

                    instance.PageHeaderSubtitle = makegrossmargin;
                }
            }

            // �o�͏�
            string target = "";
            this.SortTilte(out target);

            instance.PageHeaderSortOderTitle = target;
            // �� 2007.11.08 Keigo Yata Add ////////////////////////////////////////////////////

            // �� 2008.03.04 Keigo Yata Add ///////////////////////////////////////////////////
            // �t�b�^�o�͋敪
            instance.PageFooterOutCode = prtOutSet.FooterPrintOutCode;

            // �t�b�^�o�̓��b�Z�[�W
            StringCollection footers = new StringCollection();
            footers.Add(prtOutSet.PrintFooter1);
            footers.Add(prtOutSet.PrintFooter2);

            instance.PageFooters = footers;
            // �� 2008.03.04 Keigo Yata Add ///////////////////////////////////////////////////

            // ������I�u�W�F�N�g
            instance.PrintInfo = this._printInfo;

            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            return status;
		}
		#endregion

        // �� 2007.11.08 Keigo Yata Add ///////////////////////////////////////////////////////
        // �e�����̒l����͂���R���g���[����6���͂ł���Ƃ����3�ɕύX
        #region ���@�e���`�F�b�N���X�g�͈͍쐬����
        /// <summary>
        /// �e���`�F�b�N���X�g�͈͏��쐬
        /// ���L��Comentout�͂��ׂẴR���g���[�������͉\�Ȏ��̑e���͈͂��o�͂���R�[�h
        /// </summary>
        /// <param name="makeGrossMargin">�쐬�㒊�o�����R���N�V����</param>
        /// <remarks>
        /// <br>Note       : �o�͂��钊�o������������쐬���܂��B</br>
        /// <br>Programmer : ��c �h��</br>
        /// <br>Date       : 2007.11.08</br>
        /// </remarks>
        private void MakeGrossMargin(out string makeGrossMargin)
        {
            makeGrossMargin  = "";
            string stTarget  = "";
            string stTarget1 = "";
            string stTarget2 = "";

            string edTarget  = "";
            string edTarget1 = "";
            string edTarget2 = "";

            string markTarget  = "";
            string markTarget1 = "";
            string markTarget2 = "";
            string markTarget3 = "";


            //if(this._csSaleOrderPara.GrossMarginSt != 0)
            //{
            //    stTarget  = this._csSaleOrderPara.GrossMarginSt + " �� ����";
            //    markTarget = this._csSaleOrderPara.GrossMargin1Mark;
            //    makeGrossMargin = stTarget+":"+markTarget;
            //}


            //if ((this._csSaleOrderPara.GrossMarginSt != 0) && (this._csSaleOrderPara.GrsProfitCheckLower != 0))
            //{
            //    stTarget  = this._csSaleOrderPara.GrossMarginSt + " �� ����";
            //    markTarget = this._csSaleOrderPara.GrossMargin1Mark;
                
            //    stTarget1   = this._csSaleOrderPara.GrsProfitCheckLower + " �� �ȏ�` ";
            //    edTarget    = this._csSaleOrderPara.GrossMargin2Ed + " �� ���� ";
            //    markTarget1 = this._csSaleOrderPara.GrossMargin2Mark;

            //    makeGrossMargin = stTarget + ":" + markTarget + "  " + stTarget1 + edTarget + ":"+ markTarget1;

            //}

            
            //if ((this._csSaleOrderPara.GrsProfitCheckLower != 0) && (this._csSaleOrderPara.GrsProfitCheckBest != 0))
            //{
            //    stTarget    = this._csSaleOrderPara.GrossMarginSt + " �� ����";
            //    markTarget  = this._csSaleOrderPara.GrossMargin1Mark;

            //    stTarget1   = this._csSaleOrderPara.GrsProfitCheckLower + " �� �ȏ�` ";
            //    edTarget    = this._csSaleOrderPara.GrossMargin2Ed + " �� ���� ";
            //    markTarget1 = this._csSaleOrderPara.GrossMargin2Mark;

            //    stTarget2   = this._csSaleOrderPara.GrsProfitCheckBest + " �� �ȏ�` ";
            //    edTarget1   = this._csSaleOrderPara.GrossMargin3Ed     + " �� ���� ";
            //    markTarget2 = this._csSaleOrderPara.GrossMargin3Mark;

            //    makeGrossMargin = stTarget + ":" + markTarget + "  " + stTarget1 + edTarget + ":" + markTarget1
            //                      + "   " + stTarget2 + edTarget1 + ":" + markTarget2;

            //}

            if(this._csSaleOrderPara.GrsProfitCheckLower != 0)
            {
                if((this._csSaleOrderPara.GrsProfitCheckBest!= 0) && (this._csSaleOrderPara.GrsProfitCheckUpper != 0))
                {
                    stTarget   = this._csSaleOrderPara.GrossMarginSt + " �� ����";
                    markTarget = this._csSaleOrderPara.GrossMargin1Mark;
                    
                    stTarget1   = this._csSaleOrderPara.GrsProfitCheckLower + " �� �ȏ�  �` ";
                    edTarget = this._csSaleOrderPara.GrossMargin2Ed + " �� ���� ";
                    markTarget1 = this._csSaleOrderPara.GrossMargin2Mark;

                    stTarget2   = this._csSaleOrderPara.GrsProfitCheckBest + " �� �ȏ�  �` ";
                    edTarget1   = this._csSaleOrderPara.GrossMargin3Ed     + " �� ���� ";
                    markTarget2 = this._csSaleOrderPara.GrossMargin3Mark;
                    
                    edTarget2   = this._csSaleOrderPara.GrossMargin3Ed + " �� �ȏ� ";
                    markTarget3 = this._csSaleOrderPara.GrossMargin4Mark;
                    
                    makeGrossMargin = stTarget + ":" + markTarget + "  " + stTarget1 + edTarget + ":" + markTarget1
                                  + "   " + stTarget2 + edTarget1 + ":" + markTarget2 + "   " + edTarget2 + ":"
                                  + markTarget3;
                }

            }

            //if ((this._csSaleOrderPara.GrsProfitCheckUpper != 0) && (this._csSaleOrderPara.GrsProfitCheckBest == 0))
            //{
            //    if ((this._csSaleOrderPara.GrossMarginSt == 0) && (this._csSaleOrderPara.GrsProfitCheckLower == 0))
            //    {
            //        stTarget = this._csSaleOrderPara.GrsProfitCheckUpper + " �� �ȏ�";
            //        markTarget = this._csSaleOrderPara.GrossMargin4Mark;

            //        makeGrossMargin = stTarget + ":" + markTarget;
            //    }
            //}



            //if ((this._csSaleOrderPara.GrossMarginSt == 0) && (this._csSaleOrderPara.GrsProfitCheckBest == 0))
            //{
            //    if ((this._csSaleOrderPara.GrsProfitCheckUpper == 0))
            //    {
            //        stTarget = this._csSaleOrderPara.GrsProfitCheckLower + " �� �ȏ� ";
            //        edTarget = this._csSaleOrderPara.GrossMargin2Ed + " �� ���� ";
            //        markTarget = this._csSaleOrderPara.GrossMargin2Mark;

            //        makeGrossMargin = stTarget + edTarget + ":" + markTarget;
            //    }
            //}




            //if ((this._csSaleOrderPara.GrossMarginSt == 0) && (this._csSaleOrderPara.GrsProfitCheckUpper == 0))
            //{
            //    if ((this._csSaleOrderPara.GrsProfitCheckLower != 0) && (this._csSaleOrderPara.GrsProfitCheckBest != 0))
            //    {
            //        stTarget = this._csSaleOrderPara.GrsProfitCheckLower + " �� �ȏ�` ";
            //        edTarget = this._csSaleOrderPara.GrossMargin2Ed + " �� ���� ";
            //        markTarget = this._csSaleOrderPara.GrossMargin2Mark;

            //        stTarget1 = this._csSaleOrderPara.GrsProfitCheckBest + " �� �ȏ�` ";
            //        edTarget1 = this._csSaleOrderPara.GrossMargin3Ed + " �� ���� ";
            //        markTarget1 = this._csSaleOrderPara.GrossMargin3Mark;

            //        makeGrossMargin = stTarget + edTarget + ":" + markTarget + "    " + stTarget1 + edTarget1 + ":" + markTarget1;
            //    }
            //}



        }

        #endregion

        #region ���@�o�͏��̍쐬
        /// <summary>
        /// �o�͏��̍쐬
        /// </summary>
        /// <param name="target">�o�͏��̕�����</param>
        /// <remarks>
        /// <br>Note       : �o�͂��镶������쐬���܂��B</br>
        /// <br>Programmer : ��c �h��</br>
        /// <br>Date       : 2007.11.08</br>
        /// </remarks>
        private void SortTilte(out string target)
        {
       
            string wrkstr = "";

            switch (this._csSaleOrderPara.SortOrder)
            {
                case 0:
                    {
                        wrkstr = CT_Sort1_OdrStr;
                        break;
                    }
                case 1:
                    {
                        wrkstr = CT_Sort2_OdrStr;
                        break;
                    }
                case 2:
                    {
                        wrkstr = CT_Sort3_OdrStr;
                        break;
                    }
                case 3:
                    {
                        wrkstr = CT_Sort4_OdrStr;
                        break;
                    }
                case 4:
                    {
                        wrkstr = CT_Sort5_OdrStr;
                        break;
                    }
                case 5:
                    {
                        wrkstr = CT_Sort6_OdrStr;
                        break;
                    }
                // 2008.07.08 30413 ���� �o�͏���ǉ� >>>>>>START
                case 6:
                    {
                        wrkstr = CT_Sort7_OdrStr;
                        break;
                    }
                // 2008.07.08 30413 ���� �o�͏���ǉ� <<<<<<END
                // ADD 2009/06/12 ------>>>
                case 7:
                    {
                        wrkstr = CT_Sort8_OdrStr;
                        break;
                    }
                // ADD 2009/06/12 ------<<<
            }

            target = "[�\�[�g���F" + wrkstr + "]";
            

        }

        #endregion
        // �� 2007.11.08 Keigo Yata Add ///////////////////////////////////////////////////////

        #region ���@���o�����w�b�_�[�쐬����

        // 2008.07.17 30413 ���� �R�����g�� >>>>>>START
        #region ���o�����o�͏��쐬
        ///// <summary>
        ///// ���o�����o�͏��쐬
        ///// </summary>
        ///// <param name="extraConditions">�쐬�㒊�o�����R���N�V����</param>
        ///// <remarks>
        ///// <br>Note       : �o�͂��钊�o������������쐬���܂��B</br>
        ///// <br>Programmer : 18012 Y.Sasaki</br>
        ///// <br>Date       : 2005.11.15</br>
        ///// </remarks>
        //private void MakeExtarCondition(out StringCollection extraConditions)
        //{
        //    // ���o�����w�b�_�[����
        //    extraConditions = new StringCollection();
			
        //    // �� 2007.11.08 Keigo Yata Delete ///////////////////////////////////////////////////////////////////////////////
        //    //// �Ώۊ���
        //    //string target = "";
        //    //string stTarget = "";
        //    //string edTarget = "";
        //    //string wrkstr = "";
        //    //wrkstr = "";

        //    //stTarget = "�Ώۊ��ԁF " + TDateTime.LongDateToString("YYYY/MM/DD", this._csSaleOrderPara.SalesDateSt);
        //    //edTarget = "  �`�@" + TDateTime.LongDateToString("YYYY/MM/DD", this._csSaleOrderPara.SalesDateEd);

        //    //target = stTarget + edTarget;

        //    //this.EditCondition(ref extraConditions, target);
        //    // �� 2007.11.08 Keigo Yata Delete //////////////////////////////////////////////////////////////////////////////



        //    // �� 2007.11.08 Keigo Yata Add /////////////////////////////////////////////////////////////////////////////////
        //    // ���͓�

        //    string target = "";
        //    //string stTarget = "";
        //    //string edTarget = "";
        //    string wrkstr = "";
        //    wrkstr = "";


        //    //if ((this._csSaleOrderPara.SearchSlipDataSt != 0) && (this._csSaleOrderPara.SearchSlipDataEd != 0))
        //    //{
        //    //    stTarget = "���͓�  " + TDateTime.LongDateToString("YYYY/MM/DD", this._csSaleOrderPara.SearchSlipDataSt);
        //    //    edTarget = "  �`�@" + TDateTime.LongDateToString("YYYY/MM/DD", this._csSaleOrderPara.SearchSlipDataEd);
        //    //    target = stTarget + edTarget;
        //    //    this.EditCondition(ref extraConditions, target);
        //    //}
        //    // �� 2007.11.08 Keigo Yata Add ////////////////////////////////////////////////////////////////////////////////


        //    // �� 2007.11.08 Keigo Yata Delete /////////////////////////////////////////////////////////////////////////////
        //    // �o�͒P��
        //    //target = "�o�͒P�ʁF";
        //    //if (this._csSaleOrderPara.IsDetails == true)
        //    //{
        //    //    target += "�`�[���גP��";
        //    //}
        //    //else
        //    //{
        //    //    target += "�����ԍ��P��";
        //    //}
        //    //this.EditCondition(ref extraConditions, target);

        //    // �L�����A
        //    //target = "";
        //    //foreach (string s in this._csSaleOrderPara.CarrierNameList)
        //    //{
        //    //    if (wrkstr != "") wrkstr += "�E" + s;
        //    //    else wrkstr = s;
        //    //}
        //    //target = "�L�����A�F" + wrkstr;
        //    //this.EditCondition(ref extraConditions, target);

        //    // ����`��
        //    //wrkstr = "";
        //    //target = "";
        //    //foreach (string s in this._csSaleOrderPara.SalesFormalList)
        //    //{
        //    //    if (wrkstr != "") wrkstr += "�E" + s;
        //    //    else wrkstr = s;
        //    //}
        //    //target = "����`���F" + wrkstr;
        //    //this.EditCondition(ref extraConditions, target);

        //    // �̔��`��
        //    //wrkstr = "";
        //    //target = "";
        //    //foreach (string s in this._csSaleOrderPara.SalesFormList)
        //    //{
        //    //    if (wrkstr != "") wrkstr += "�E" + s;
        //    //    else wrkstr = s;
        //    //}
        //    //target = "�̔��`�ԁF" + wrkstr;
        //    //this.EditCondition(ref extraConditions, target);

        //    // �\�[�g��
        //    //wrkstr = "";
        //    //target = "";
        //    //switch (this._csSaleOrderPara.SortOrder)
        //    //{
        //    //    case 0:
        //    //        {
        //    //            wrkstr = CT_Sort1_OdrStr;
        //    //            break;
        //    //        }
        //    //    case 1:
        //    //        {
        //    //            wrkstr = CT_Sort2_OdrStr;
        //    //            break;
        //    //        }
        //    //    case 2:
        //    //        {
        //    //            wrkstr = CT_Sort3_OdrStr;
        //    //            break;
        //    //        }
        //    //    case 3:
        //    //        {
        //    //            wrkstr = CT_Sort4_OdrStr;
        //    //            break;
        //    //        }
        //    //    case 4:
        //    //        {
        //    //            wrkstr = CT_Sort5_OdrStr;
        //    //            break;
        //    //        }
        //    //}
        //    // �� 2007.11.08 Keigo Yata Delete /////////////////////////////////////////////////////////////////////////////

        //    // �� 2007.11.08 Keigo Yata Add ////////////////////////////////////////////////////////////////////////////////
        //    // �\�[�g��
        //    wrkstr = "";
        //    target = "";
        //    switch (this._csSaleOrderPara.SortOrder)
        //    {
        //        case 0:
        //            {
        //                wrkstr = CT_Sort1_OdrStr;
        //                break;
        //            }
        //        case 1:
        //            {
        //                wrkstr = CT_Sort2_OdrStr;
        //                break;
        //            }
        //        case 2:
        //            {
        //                wrkstr = CT_Sort3_OdrStr;
        //                break;
        //            }
        //        case 3:
        //            {
        //                wrkstr = CT_Sort4_OdrStr;
        //                break;
        //            }
        //        case 4:
        //            {
        //                wrkstr = CT_Sort5_OdrStr;
        //                break;
        //            }
        //        case 5:
        //            {
        //                wrkstr = CT_Sort6_OdrStr;
        //                break;
        //            }
        //    }
        //    // �� 2007.11.08 Keigo Yata Add ////////////////////////////////////////////////////////////////////////////////

        //    //target = "�\�[�g���F" + wrkstr + " ��";
        //    //this.EditCondition(ref extraConditions, target);

        //    // �� 2007.11.08 Keigo Yata Delete /////////////////////////////////////////////////////////////////////////////////////////////////////
        //    //// ���i�敪�O���[�v
        //    //if (this._csSaleOrderPara.LargeGoodsGanreCdSt != "")
        //    //{
        //    //    target = "���i�敪�O���[�v: " + this._csSaleOrderPara.LargeGoodsGanreCdSt + " �` " + this._csSaleOrderPara.LargeGoodsGanreCdEd;
        //    //    this.EditCondition(ref extraConditions, target);
        //    //}

        //    //// ���i�敪
        //    //if (this._csSaleOrderPara.MediumGoodsGanreCdEd != "")
        //    //{
        //    //    target = "���i�敪: " + this._csSaleOrderPara.MediumGoodsGanreCdSt + " �` " + this._csSaleOrderPara.MediumGoodsGanreCdEd;
        //    //    this.EditCondition(ref extraConditions, target);
        //    //}

        //    //// �@��R�[�h
        //    //if (this._csSaleOrderPara.CellphoneModelCodeEd != "")
        //    //{
        //    //    target = "�@��R�[�h: " + this._csSaleOrderPara.CellphoneModelCodeSt + " �` " + this._csSaleOrderPara.CellphoneModelCodeEd;
        //    //    this.EditCondition(ref extraConditions, target);
        //    //}
        //    // �� 2007.11.08 Keigo Yata Delete //////////////////////////////////////////////////////////////////////////////////////////////////////

        //    // �� 2007.11.08 Keigo Yata Change /////////////////////////////////////////////////////////////////////////////////////////////////////
        //    // ���i�R�[�h
        //    //if (this._csSaleOrderPara.GoodsCodeEd != "")
        //    //{
        //    //    target = "���i�R�[�h: " + this._csSaleOrderPara.GoodsCodeSt + " �` " + this._csSaleOrderPara.GoodsCodeEd;
        //    //    this.EditCondition(ref extraConditions, target);
        //    //}
        //    // �� 2007.11.08 Keigo Yata Change /////////////////////////////////////////////////////////////////////////////////////////////////////

        //    // �� 2007.11.15 Keigo Yata Add ///////////////////////////////////////////////////////////////////////////////////////////////////////

        //    // ���Ӑ�--------------------------------------------------------------------------------------------------------------------------------
        //    if ((this._csSaleOrderPara.CustomerCodeSt == 0) && (this._csSaleOrderPara.CustomerCodeEd != 0))
        //    {
        //        target = "���Ӑ�: " + "�ŏ�����" + " �` " + this._csSaleOrderPara.CustomerCodeEd.ToString();
        //        this.EditCondition(ref extraConditions, target);
        //    }

        //    if ((this._csSaleOrderPara.CustomerCodeSt > 0) && (this._csSaleOrderPara.CustomerCodeEd == 0))
        //    {
        //        target = "���Ӑ�: " + this._csSaleOrderPara.CustomerCodeSt.ToString() + " �` " + "�Ō�܂�";
        //        this.EditCondition(ref extraConditions, target);
        //    }

        //    if ((this._csSaleOrderPara.CustomerCodeSt > 0) && (this._csSaleOrderPara.CustomerCodeEd != 0))
        //    {
        //        target = "���Ӑ�: " + this._csSaleOrderPara.CustomerCodeSt.ToString() + " �` " + this._csSaleOrderPara.CustomerCodeEd.ToString();
        //        this.EditCondition(ref extraConditions, target);
        //    }
        //    //---------------------------------------------------------------------------------------------------------------------------------------

        //    // �`�[�敪------------------------------------------------------------------------------------------------------------------------------
        //    switch (this._csSaleOrderPara.SalesSlipCd)
        //    {
        //        case -1:
        //            {
        //                target = "�`�[�敪�F �S��";
        //                this.EditCondition(ref extraConditions, target);
        //                break;
        //            }
        //        case 0:
        //            {
        //                target = "�`�[�敪�F ����";
        //                this.EditCondition(ref extraConditions, target);
        //                break;
        //            }
        //        case 1:
        //            {
        //                target = "�`�[�敪�F �ԕi";
        //                this.EditCondition(ref extraConditions, target);
        //                break;
        //            }
        //    }

        //    switch (this._csSaleOrderPara.DebitNoteDiv)
        //    {
        //        case -1:
        //            {
        //                target = "�ԓ`�敪�F �S��";
        //                this.EditCondition(ref extraConditions, target);
        //                break;
        //            }
        //        case 0:
        //            {
        //                target = "�ԓ`�敪�F ���`";
        //                this.EditCondition(ref extraConditions, target);
        //                break;
        //            }
        //        case 1:
        //            {
        //                target = "�ԓ`�敪�F �ԓ`";
        //                this.EditCondition(ref extraConditions, target);
        //                break;
        //            }
        //        case 2:
        //            {
        //                target = "�ԓ`�敪�F ����";
        //                this.EditCondition(ref extraConditions, target);
        //                break;
        //            }
        //    }
        //    //---------------------------------------------------------------------------------------------------------------------------------------
        //    // �� 2007.11.15 Keigo Yata Add /////////////////////////////////////////////////////////////////////////////////////////////////////

        //    // �� 2007.11.08 Keigo Yata Add /////////////////////////////////////////////////////////////////////////////////////////////////////

        //    // ���͎҃R�[�h--------------------------------------------------------------------------------------------------------------------------
        //    if ((this._csSaleOrderPara.SalesInputCodeSt == "") && (this._csSaleOrderPara.SalesInputCodeEd != ""))
        //    {
        //        target = "���͎҃R�[�h: " + "�ŏ�����" + " �` " + this._csSaleOrderPara.SalesInputCodeEd;
        //        this.EditCondition(ref extraConditions, target);
        //    }
            
        //    if ((this._csSaleOrderPara.SalesInputCodeSt != "")&&(this._csSaleOrderPara.SalesInputCodeEd == ""))
        //    {
        //        target = "���͎҃R�[�h: " + this._csSaleOrderPara.SalesInputCodeSt + " �` " + "�Ō�܂�";
        //        this.EditCondition(ref extraConditions, target);
        //    }

        //    if ((this._csSaleOrderPara.SalesInputCodeSt != "")&&(this._csSaleOrderPara.SalesInputCodeEd != ""))
        //    {
        //        target = "���͎҃R�[�h: " + this._csSaleOrderPara.SalesInputCodeSt + " �` " + this._csSaleOrderPara.SalesInputCodeEd;
        //        this.EditCondition(ref extraConditions, target);
        //    }
        //    //---------------------------------------------------------------------------------------------------------------------------------------
        //    // �� 2007.11.08 Keigo Yata Add /////////////////////////////////////////////////////////////////////////////////////////////////////

            
        //    // �S���҃R�[�h--------------------------------------------------------------------------------------------------------------------------
        //    if ((this._csSaleOrderPara.SalesEmployeeCdSt != "") && (this._csSaleOrderPara.SalesEmployeeCdEd == ""))
        //    {
        //        target = "�S���҃R�[�h: " + this._csSaleOrderPara.SalesEmployeeCdSt + " �` " + "�Ō�܂�";
        //        this.EditCondition(ref extraConditions, target);
        //    }

        //    if ((this._csSaleOrderPara.SalesEmployeeCdSt == "")&&(this._csSaleOrderPara.SalesEmployeeCdEd != ""))
        //    {
        //        target = "�S���҃R�[�h: " + "�ŏ�����" + " �` " + this._csSaleOrderPara.SalesEmployeeCdEd;
        //        this.EditCondition(ref extraConditions, target);
        //    }

        //    if ((this._csSaleOrderPara.SalesEmployeeCdSt != "") && (this._csSaleOrderPara.SalesEmployeeCdEd != ""))
        //    {
        //        target = "�S���҃R�[�h: " + this._csSaleOrderPara.SalesEmployeeCdSt + " �` " + this._csSaleOrderPara.SalesEmployeeCdEd;
        //        this.EditCondition(ref extraConditions, target);
        //    }
        //    //---------------------------------------------------------------------------------------------------------------------------------------

        //    // �`�[�ԍ�------------------------------------------------------------------------------------------------------------------------------
        //    if ((this._csSaleOrderPara.SalesSlipNumSt != "")&&(this._csSaleOrderPara.SalesSlipNumEd == ""))
        //    {
        //        target = "�`�[�ԍ�: " + this._csSaleOrderPara.SalesSlipNumSt + " �` "  + "�Ō�܂�";
        //        this.EditCondition(ref extraConditions, target);
        //    }

        //    if ((this._csSaleOrderPara.SalesSlipNumSt == "") && (this._csSaleOrderPara.SalesSlipNumEd != ""))
        //    {
        //        target = "�`�[�ԍ�: " + "�ŏ�����" + " �` " + this._csSaleOrderPara.SalesSlipNumEd;
        //        this.EditCondition(ref extraConditions, target);
        //    }

        //    if ((this._csSaleOrderPara.SalesSlipNumSt != "")&&(this._csSaleOrderPara.SalesSlipNumEd != ""))
        //    {
        //        target = "�`�[�ԍ�: " + this._csSaleOrderPara.SalesSlipNumSt + " �` " + this._csSaleOrderPara.SalesSlipNumEd;
        //        this.EditCondition(ref extraConditions, target);
        //    }
        //    //---------------------------------------------------------------------------------------------------------------------------------------

        //}
        #endregion
        // 2008.07.17 30413 ���� �R�����g�� <<<<<<END

        #region ���o�����o�͏��쐬
        /// <summary>
        /// ���o�����o�͏��쐬
        /// </summary>
        /// <param name="extraConditions">�쐬�㒊�o�����R���N�V����</param>
        /// <remarks>
        /// <br>Note       : �o�͂��钊�o������������쐬���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.07.17</br>
        /// </remarks>
        private void MakeExtarCondition(out StringCollection extraConditions)
        {
            // ���o�����w�b�_�[����
            extraConditions = new StringCollection();
            StringCollection addConditions = new StringCollection();
            
            const string ct_RangeConst = "�F{0} �` {1}";
            const string ct_DateFormat = "YYYY/MM/DD";
            const string ct_Extr_Top = "�ŏ�����";
            const string ct_Extr_End = "�Ō�܂�";

            string target = "";

            // �����
            if ((this._csSaleOrderPara.SalesDateSt != 0) || (this._csSaleOrderPara.SalesDateEd != 0))
            {
                string st_SalesDate = string.Empty;
                string ed_SalesDate = string.Empty;
                // �J�n
                if (this._csSaleOrderPara.SalesDateSt != 0)
                    st_SalesDate = TDateTime.LongDateToString(ct_DateFormat, this._csSaleOrderPara.SalesDateSt);
                else
                    st_SalesDate = ct_Extr_Top;
                // �I��
                if (this._csSaleOrderPara.SalesDateEd != 0)
                    ed_SalesDate = TDateTime.LongDateToString(ct_DateFormat, this._csSaleOrderPara.SalesDateEd);
                else
                    ed_SalesDate = ct_Extr_End;

                this.EditCondition(ref addConditions, string.Format("������@" + ct_RangeConst, st_SalesDate, ed_SalesDate));
            }

            // ���͓�
            if ((this._csSaleOrderPara.SearchSlipDateSt != 0) || (this._csSaleOrderPara.SearchSlipDateEd != 0))
            {
                string st_SalesDate = string.Empty;
                string ed_SalesDate = string.Empty;
                // �J�n
                if (this._csSaleOrderPara.SearchSlipDateSt != 0)
                    st_SalesDate = TDateTime.LongDateToString(ct_DateFormat, this._csSaleOrderPara.SearchSlipDateSt);
                else
                    st_SalesDate = ct_Extr_Top;
                // �I��
                if (this._csSaleOrderPara.SearchSlipDateEd != 0)
                    ed_SalesDate = TDateTime.LongDateToString(ct_DateFormat, this._csSaleOrderPara.SearchSlipDateEd);
                else
                    ed_SalesDate = ct_Extr_End;

                this.EditCondition(ref addConditions, string.Format("���͓��@" + ct_RangeConst, st_SalesDate, ed_SalesDate));
            }

            // ���s��
            if ((this._csSaleOrderPara.SalesInputCodeSt == "") && (this._csSaleOrderPara.SalesInputCodeEd != ""))
            {
                target = "���s��: " + ct_Extr_Top + " �` " + this._csSaleOrderPara.SalesInputCodeEd;
                this.EditCondition(ref addConditions, target);
            }

            if ((this._csSaleOrderPara.SalesInputCodeSt != "") && (this._csSaleOrderPara.SalesInputCodeEd == ""))
            {
                target = "���s��: " + this._csSaleOrderPara.SalesInputCodeSt + " �` " + ct_Extr_End;
                this.EditCondition(ref addConditions, target);
            }

            if ((this._csSaleOrderPara.SalesInputCodeSt != "") && (this._csSaleOrderPara.SalesInputCodeEd != ""))
            {
                target = "���s��: " + this._csSaleOrderPara.SalesInputCodeSt + " �` " + this._csSaleOrderPara.SalesInputCodeEd;
                this.EditCondition(ref addConditions, target);
            }

            // �S����
            if ((this._csSaleOrderPara.SalesEmployeeCdSt == "") && (this._csSaleOrderPara.SalesEmployeeCdEd != ""))
            {
                target = "�S����: " + ct_Extr_Top + " �` " + this._csSaleOrderPara.SalesEmployeeCdEd.ToString();
                this.EditCondition(ref addConditions, target);
            }

            if ((this._csSaleOrderPara.SalesEmployeeCdSt != "") && (this._csSaleOrderPara.SalesEmployeeCdEd == ""))
            {
                target = "�S����: " + this._csSaleOrderPara.SalesEmployeeCdSt.ToString() + " �` " + ct_Extr_End;
                this.EditCondition(ref addConditions, target);
            }

            if ((this._csSaleOrderPara.SalesEmployeeCdSt != "") && (this._csSaleOrderPara.SalesEmployeeCdEd != ""))
            {
                target = "�S����: " + this._csSaleOrderPara.SalesEmployeeCdSt + " �` " + this._csSaleOrderPara.SalesEmployeeCdEd;
                this.EditCondition(ref addConditions, target);
            }

            // �n��
            if ((this._csSaleOrderPara.SalesAreaCodeSt == 0) && (this._csSaleOrderPara.SalesAreaCodeEd != 0))
            {
                target = "�n��: " + ct_Extr_Top + " �` " + this._csSaleOrderPara.SalesAreaCodeEd.ToString("d04");
                this.EditCondition(ref addConditions, target);
            }

            if ((this._csSaleOrderPara.SalesAreaCodeSt > 0) && (this._csSaleOrderPara.SalesAreaCodeEd == 0))
            {
                target = "�n��: " + this._csSaleOrderPara.SalesAreaCodeSt.ToString("d04") + " �` " + ct_Extr_End;
                this.EditCondition(ref addConditions, target);
            }

            if ((this._csSaleOrderPara.SalesAreaCodeSt > 0) && (this._csSaleOrderPara.SalesAreaCodeEd != 0))
            {
                target = "�n��: " + this._csSaleOrderPara.SalesAreaCodeSt.ToString("d04") + " �` " + this._csSaleOrderPara.SalesAreaCodeEd.ToString("d04");
                this.EditCondition(ref addConditions, target);
            }

            // �Ǝ�
            if ((this._csSaleOrderPara.BusinessTypeCodeSt == 0) && (this._csSaleOrderPara.BusinessTypeCodeEd != 0))
            {
                target = "�Ǝ�: " + ct_Extr_Top + " �` " + this._csSaleOrderPara.BusinessTypeCodeEd.ToString("d04");
                this.EditCondition(ref addConditions, target);
            }

            if ((this._csSaleOrderPara.BusinessTypeCodeSt > 0) && (this._csSaleOrderPara.BusinessTypeCodeEd == 0))
            {
                target = "�Ǝ�: " + this._csSaleOrderPara.BusinessTypeCodeSt.ToString("d04") + " �` " + ct_Extr_End;
                this.EditCondition(ref addConditions, target);
            }

            if ((this._csSaleOrderPara.BusinessTypeCodeSt > 0) && (this._csSaleOrderPara.BusinessTypeCodeEd != 0))
            {
                target = "�Ǝ�: " + this._csSaleOrderPara.BusinessTypeCodeSt.ToString("d04") + " �` " + this._csSaleOrderPara.BusinessTypeCodeEd.ToString("d04");
                this.EditCondition(ref addConditions, target);
            }

            // ���Ӑ�
            if ((this._csSaleOrderPara.CustomerCodeSt == 0) && (this._csSaleOrderPara.CustomerCodeEd != 0))
            {
                target = "���Ӑ�: " + ct_Extr_Top + " �` " + this._csSaleOrderPara.CustomerCodeEd.ToString("d08");
                this.EditCondition(ref addConditions, target);
            }

            if ((this._csSaleOrderPara.CustomerCodeSt > 0) && (this._csSaleOrderPara.CustomerCodeEd == 0))
            {
                target = "���Ӑ�: " + this._csSaleOrderPara.CustomerCodeSt.ToString("d08") + " �` " + ct_Extr_End;
                this.EditCondition(ref addConditions, target);
            }

            if ((this._csSaleOrderPara.CustomerCodeSt > 0) && (this._csSaleOrderPara.CustomerCodeEd != 0))
            {
                target = "���Ӑ�: " + this._csSaleOrderPara.CustomerCodeSt.ToString("d08") + " �` " + this._csSaleOrderPara.CustomerCodeEd.ToString("d08");
                this.EditCondition(ref addConditions, target);
            }

            // �d����
            if ((this._csSaleOrderPara.SupplierCdSt == 0) && (this._csSaleOrderPara.SupplierCdEd != 0))
            {
                target = "�d����: " + ct_Extr_Top + " �` " + this._csSaleOrderPara.SupplierCdEd.ToString("d06");
                this.EditCondition(ref addConditions, target);
            }

            if ((this._csSaleOrderPara.SupplierCdSt > 0) && (this._csSaleOrderPara.SupplierCdEd == 0))
            {
                target = "�d����: " + this._csSaleOrderPara.SupplierCdSt.ToString("d06") + " �` " + ct_Extr_End;
                this.EditCondition(ref addConditions, target);
            }

            if ((this._csSaleOrderPara.SupplierCdSt > 0) && (this._csSaleOrderPara.SupplierCdEd != 0))
            {
                target = "�d����: " + this._csSaleOrderPara.SupplierCdSt.ToString("d06") + " �` " + this._csSaleOrderPara.SupplierCdEd.ToString("d06");
                this.EditCondition(ref addConditions, target);
            }

            // �`�[�ԍ�
            if ((this._csSaleOrderPara.SalesSlipNumSt != "") && (this._csSaleOrderPara.SalesSlipNumEd == ""))
            {
                target = "�`�[�ԍ�: " + this._csSaleOrderPara.SalesSlipNumSt + " �` " + ct_Extr_End;
                this.EditCondition(ref addConditions, target);
            }

            if ((this._csSaleOrderPara.SalesSlipNumSt == "") && (this._csSaleOrderPara.SalesSlipNumEd != ""))
            {
                target = "�`�[�ԍ�: " + ct_Extr_Top + " �` " + this._csSaleOrderPara.SalesSlipNumEd;
                this.EditCondition(ref addConditions, target);
            }

            if ((this._csSaleOrderPara.SalesSlipNumSt != "") && (this._csSaleOrderPara.SalesSlipNumEd != ""))
            {
                target = "�`�[�ԍ�: " + this._csSaleOrderPara.SalesSlipNumSt + " �` " + this._csSaleOrderPara.SalesSlipNumEd;
                this.EditCondition(ref addConditions, target);
            }

            // �`�[�敪
            switch (this._csSaleOrderPara.SalesSlipCd)
            {
                case -1:
                    {
                        target = "�`�[�敪�F �S��";
                        this.EditCondition(ref addConditions, target);
                        break;
                    }
                case 0:
                    {
                        target = "�`�[�敪�F ����";
                        this.EditCondition(ref addConditions, target);
                        break;
                    }
                case 1:
                    {
                        target = "�`�[�敪�F �ԕi";
                        this.EditCondition(ref addConditions, target);
                        break;
                    }
                case 2:
                    {
                        target = "�`�[�敪�F �ԕi+�l����";
                        this.EditCondition(ref addConditions, target);
                        break;
                    }
            }

            // �ԓ`�敪
            switch (this._csSaleOrderPara.DebitNoteDiv)
            {
                case -1:
                    {
                        target = "�ԓ`�敪�F �S��";
                        this.EditCondition(ref addConditions, target);
                        break;
                    }
                case 0:
                    {
                        target = "�ԓ`�敪�F ���`";
                        this.EditCondition(ref addConditions, target);
                        break;
                    }
                case 1:
                    {
                        target = "�ԓ`�敪�F �ԓ`";
                        this.EditCondition(ref addConditions, target);
                        break;
                    }
                case 2:
                    {
                        target = "�ԓ`�敪�F ����";
                        this.EditCondition(ref addConditions, target);
                        break;
                    }
            }

            // ���s�^�C�v
            if ((this._csSaleOrderPara.SalesSlipUpdateCd == -1) && (this._csSaleOrderPara.LogicalDeleteCode == 0))
            {
                target = "���s�^�C�v�F �ʏ�";
                this.EditCondition(ref addConditions, target);
            }
            else if ((this._csSaleOrderPara.SalesSlipUpdateCd == 1) && (this._csSaleOrderPara.LogicalDeleteCode == 0))
            {
                target = "���s�^�C�v�F ����";
                this.EditCondition(ref addConditions, target);
            }
            else if ((this._csSaleOrderPara.SalesSlipUpdateCd == -1) && (this._csSaleOrderPara.LogicalDeleteCode == 1))
            {
                target = "���s�^�C�v�F �폜";
                this.EditCondition(ref addConditions, target);
            }
            else if ((this._csSaleOrderPara.SalesSlipUpdateCd == 1) && (this._csSaleOrderPara.LogicalDeleteCode == 1))
            {
                target = "���s�^�C�v�F �����{�폜";
                this.EditCondition(ref addConditions, target);
            }

            // �o�͎w��
            if ((this._csSaleOrderPara.SalesOrderDivCd == -1) && (this._csSaleOrderPara.WayToOrder == -1))
            {
                target = "�o�͎w��F �S��";
                this.EditCondition(ref addConditions, target);
            }
            else if ((this._csSaleOrderPara.SalesOrderDivCd == 1) && (this._csSaleOrderPara.WayToOrder == -1))
            {
                target = "�o�͎w��F �݌�";
                this.EditCondition(ref addConditions, target);
            }
            else if ((this._csSaleOrderPara.SalesOrderDivCd == 0) && (this._csSaleOrderPara.WayToOrder == -1))
            {
                target = "�o�͎w��F ���";
                this.EditCondition(ref addConditions, target);
            }
            else if ((this._csSaleOrderPara.SalesOrderDivCd == -1) && (this._csSaleOrderPara.WayToOrder == 2))
            {
                target = "�o�͎w��F UOE";
                this.EditCondition(ref addConditions, target);
            }

            // �w������݈̂��
            // �����[��
            if (this._csSaleOrderPara.ZeroSalesPrint == 1)
            {
                target = "�����[���݈̂�";
                this.EditCondition(ref addConditions, target);
            }
            // �����[��
            if (this._csSaleOrderPara.ZeroCostPrint == 1)
            {
                target = "�����[���݈̂�";
                this.EditCondition(ref addConditions, target);
            }
            // �e���[��
            if (this._csSaleOrderPara.ZeroGrsProfitPrint == 1)
            {
                target = "�e���[���݈̂�";
                this.EditCondition(ref addConditions, target);
            }
            // �e���[���ȉ�
            if (this._csSaleOrderPara.ZeroUdrGrsProfitPrint == 1)
            {
                target = "�e���[���ȉ��݈̂�";
                this.EditCondition(ref addConditions, target);
            }
            // �e����
            if (this._csSaleOrderPara.GrsProfitRatePrint == 1)
            {
                if (this._csSaleOrderPara.GrsProfitRatePrintDiv == 0)
                {
                    target = "�e�����F " + this._csSaleOrderPara.GrsProfitRatePrintVal.ToString() + "���ȉ�";
                }
                else
                {
                    target = "�e�����F " + this._csSaleOrderPara.GrsProfitRatePrintVal.ToString() + "���ȏ�";
                }
                this.EditCondition(ref addConditions, target);
            }

            foreach (string exCondStr in addConditions)
            {
                extraConditions.Add(exCondStr);
            }
            
        }
        #endregion

		/// <summary>
		/// ���o����������ҏW
		/// </summary>
		/// <param name="editArea">�i�[�G���A</param>
		/// <param name="target">�Ώە�����</param>
		/// <remarks>
		/// <br>Note       : �o�͂��钊�o�����������ҏW���܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.11.15</br>
		/// </remarks>
		private void EditCondition(ref StringCollection editArea, string target)
		{
			bool isEdit = false;

            // 2008.09.17 30413 ���� ���o������K�X���s����悤�ɏC�� >>>>>>START
            // �ҏW�Ώە����o�C�g���Z�o
			int targetByte = TStrConv.SizeCountSJIS(target);
			
            //for (int i = 0; i < editArea.Count; i++)
            //{
            //    int areaByte = 0;
				
				
            //    // �i�[�G���A�̃o�C�g���Z�o
            //    if (editArea[i] != null)
            //    {
            //        areaByte = TStrConv.SizeCountSJIS(editArea[i]);
            //    }

            //    if ((areaByte + targetByte + 2) <= 220)
            //    {
            //        isEdit = true;

            //        // �S�p�X�y�[�X��}��
            //        if (editArea[i] != null) editArea[i] += CT_ITEM_INTERVAL;
					
            //        editArea[i]  += target;
            //        break;
            //    }
            //}

            int index = 0;
            int areaByte = 0;
            
            // �ǉ�����G���A�̃C���f�b�N�X���擾
            if (editArea.Count != 0)
            {
                index = editArea.Count - 1;

                // �i�[�G���A�̃o�C�g���Z�o
                if (editArea[index] != null)
                {
                    areaByte = TStrConv.SizeCountSJIS(editArea[index]);
                }

                if ((areaByte + targetByte + 2) >= 140)
                {
                    // ���s
                    editArea[index] += "\n";
                }
                else
                {
                    isEdit = true;

                    // �S�p�X�y�[�X��}��
                    if (editArea[index] != null) editArea[index] += CT_ITEM_INTERVAL;

                    editArea[index] += target;
                }
            }
            // 2008.09.17 30413 ���� ���o������K�X���s����悤�ɏC�� <<<<<<END
            
			// �V�K�ҏW�G���A�쐬
			if (!isEdit)
			{
				editArea.Add(target);
			}
		}
		#endregion
		
		#region ���@���ʃv���r���[���i�p�����[�^�ݒ�
		/// <summary>
		/// �����ʋ��ʏ��ݒ�
		/// </summary>
		/// <param name="commonInfo"></param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �����ʋ��ʏ����̐ݒ���s���܂��B</br>
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.11.15</br>
		/// </remarks>
		private void SetPrintCommonInfo(out Broadleaf.Windows.Forms.SFCMN00293UC commonInfo)
		{
			commonInfo = new Broadleaf.Windows.Forms.SFCMN00293UC();
		
			// �v�����^��
			commonInfo.PrinterName = this._printInfo.prinm;

            // ���[��
            commonInfo.PrintName = this._printInfo.prpnm;

			// �������
            commonInfo.PrintMax = ((DataSet)this._printInfo.rdData).Tables[ct_TableName].Rows.Count;
			
			// ������[�h
			commonInfo.PrintMode   = this._printInfo.printmode;
			
			// �]���ݒ�
			// ���ʒu
			commonInfo.MarginsLeft = this._printInfo.px;
			
			// �s�ʒu
			commonInfo.MarginsTop  = this._printInfo.py;

			// PDF�o�̓t���p�X
			string pdfPath = "";
			string pdfName = "";
			this._sfcmn00331C.GetPdfSavePathName(this._printInfo.prpnm, ref pdfPath, ref pdfName);
			
			string pdfFileName     = System.IO.Path.Combine(pdfPath,pdfName);
			commonInfo.PdfFullPath = pdfFileName;
			
			this._printInfo.pdftemppath = pdfFileName;
		}
		#endregion
		

		// �� 2007.11.08 Keigo Yata Delete ////////////////////////////////////////////////////////////////
        #region ���@������N�G���쐬�֐�
        ///// <summary>
        ///// �󎚏��N�G���쐬����
        ///// </summary>
        ///// <returns>�쐬�����N�G��</returns>
        ///// <remarks>
        ///// <br>Note       : DataView�ɐݒ肷��󎚏��ʂ̃N�G�����쐬���܂��B</br>
        ///// <br>Programmer : 18012 Y.Sasaki</br>
        ///// <br>Date       : 2005.12.06</br>
        ///// </remarks>
        //private string GetPrintOderQuerry()
        //{
        //    string oderQuerry = "";

        //    switch (this._csSaleOrderPara.SortOrder)
        //    {
        //        case 0:
        //            {
        //                oderQuerry = CT_Sort1_Odr;
        //                break;
        //            }
        //        case 1:
        //            {
        //                oderQuerry = CT_Sort2_Odr;
        //                break;
        //            }
        //        case 2:
        //            {
        //                oderQuerry = CT_Sort3_Odr;
        //                break;
        //            }
        //        case 3:
        //            {
        //                oderQuerry = CT_Sort4_Odr;
        //                break;
        //            }
        //        case 4:
        //            {
        //                oderQuerry = CT_Sort5_Odr;
        //                break;
        //            }

        //    }
			
        //    return oderQuerry;
        //}
        #endregion
        // �� 2007.11.08 Keigo Yata Delete ////////////////////////////////////////////////////////////////

        // �� 2007.11.08 Keigo Yata Add //////////////////////////////////////////////////////////////////
        #region ���@������N�G���쐬�֐�
        /// <summary>
        /// �󎚏��N�G���쐬����
        /// </summary>
        /// <returns>�쐬�����N�G��</returns>
        /// <remarks>
        /// <br>Note       : DataView�ɐݒ肷��󎚏��ʂ̃N�G�����쐬���܂��B</br>
        /// <br>Programmer : ��c �h��</br>
        /// <br>Date       : 2007.11.08</br>
        /// </remarks>
        private string GetPrintOderQuerry()
        {
            string oderQuerry = "";

            switch (this._csSaleOrderPara.SortOrder)
            {
                case 0:
                    {
                        oderQuerry = CT_Sort1_Odr;
                        break;
                    }
                case 1:
                    {
                        oderQuerry = CT_Sort2_Odr;
                        break;
                    }
                case 2:
                    {
                        oderQuerry = CT_Sort3_Odr;
                        break;
                    }
                case 3:
                    {
                        oderQuerry = CT_Sort4_Odr;
                        break;
                    }
                case 4:
                    {
                        oderQuerry = CT_Sort5_Odr;
                        break;
                    }
                case 5:
                    {
                        oderQuerry = CT_Sort6_Odr;
                        break;
                    }
                // 2008.07.08 30413 ���� �o�͏���ǉ� >>>>>>START
                case 6:
                    {
                        oderQuerry = CT_Sort7_Odr;
                        break;
                    }
                // 2008.07.08 30413 ���� �o�͏���ǉ� <<<<<<END
                // ADD 2009/06/12 ------>>>
                case 7:
                    {
                        oderQuerry = CT_Sort8_Odr;
                        break;
                    }
                // ADD 2009/06/12 ------<<<
            }

            return oderQuerry;
        }
        // �� 2007.11.08 Keigo Yata Add //////////////////////////////////////////////////////////////////
		#endregion
		
		#region ���@���b�Z�[�W�\������
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
		/// <br>Programmer : 18012 Y.Sasaki</br>
		/// <br>Date       : 2005.11.15</br>
		/// </remarks>
		private DialogResult TMessageBox(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
		{
			return TMsgDisp.Show(iLevel, "MAHNB02343P", iMsg, iSt, iButton, iDefButton);
		}
		#endregion
		#endregion
	}
}

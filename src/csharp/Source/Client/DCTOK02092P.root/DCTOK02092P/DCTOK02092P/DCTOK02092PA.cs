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
using Broadleaf.Library.Resources;
using Broadleaf.Drawing.Printing;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Text;

namespace Broadleaf.Drawing.Printing
{
	/// <summary>
	/// �O�N�Δ�\����N���X
	/// </summary>
	public class DCTOK02092PA
	{
		//================================================================================
		//  �R���X�g���N�^�[
		//================================================================================
		#region �R���X�g���N�^�[
		/// <summary>
		/// �R���X�g���N�^�[
		/// </summary>
		public DCTOK02092PA(object printInfo)
		{
			this._printInfo         = printInfo as SFCMN06002C;
			
			this._pdfHistoryControl = new PdfHistoryControl();
			this._sfcmn00331C       = new SFCMN00331C();

            this._prYearCpPara = this._printInfo.jyoken as ExtrInfo_DCTOK02093E;

            this.SelectTableName();

        }
		#endregion

		//================================================================================
		//  �����萔
		//================================================================================
		#region private constant
		private const string CT_REPORTFORM_NAMESPASE = "Broadleaf.Drawing.Printing";
		private const string CT_ITEM_INTERVAL        = "�@�@�@�@�@";

		#endregion
		
		//================================================================================
		//  �����ϐ�
		//================================================================================
		#region private member    
		private SFCMN06002C     _printInfo           = null;
		private PdfHistoryControl _pdfHistoryControl = null;
		private SFCMN00331C _sfcmn00331C             = null;			// ���[�n���ʕ��i
		private ExtrInfo_DCTOK02093E _prYearCpPara = null;
        #endregion
               
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
		/// <br>Programmer : 30462 �s�V �m��</br>
		/// <br>Date       : 2008.11.25</br>
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
		/// <br>Programmer : 30462 �s�V �m��</br>
		/// <br>Date       : 2008.11.25</br>
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

						// TODO 11.30�v���O���X�o�[UP�C�x���g�ǉ�
						if (prtRpt is IPrintActiveReportTypeCommon)
						{
                            // ADD 2009/01/28 �s��Ή�[9829] ---------->>>>>
                            ((IPrintActiveReportTypeCommon)prtRpt).ProgressBarUpEvent += new ProgressBarUpEventHandler(processForm.ProgressBarUpEvent);
                            // ADD 2008/01/28 �s��Ή�[9829] ----------<<<<<
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
			ct_TableName = DCTOK02094EA.CT_PrevYearCpDataTable;
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
		/// <br>Programmer : 30462 �s�V �m��</br>
		/// <br>Date       : 2008.11.25</br>
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
		/// <br>Programmer : 30462 �s�V �m��</br>
		/// <br>Date       : 2008.11.25</br>
		/// </remarks>
		private	object LoadAssemblyReport(string asmname, string classname, Type type)
		{
			object	obj	= null;
			try
			{
				System.Reflection.Assembly asm = System.Reflection.Assembly.Load(asmname);
				Type objType = asm.GetType(classname);
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
		/// <br>Programmer : 30462 �s�V �m��</br>
		/// <br>Date       : 2008.11.25</br>
		/// </remarks>
		private int SettingProperty(ref DataDynamics.ActiveReports.ActiveReport3 rpt)
		{
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // ActiveReport�C���^�[�t�F�[�X�ɃL���X�g
            IPrintActiveReportTypeList instance = rpt as IPrintActiveReportTypeList;

            // 2009.03.17 30413 ���� �t�b�^�[���̈󎚕ύX >>>>>>START
            // ���[�o�͐ݒ���擾 
            PrtOutSet prtOutSet;
            string message;

            int st = PrevYearComparison.ReadPrtOutSet(out prtOutSet, out message);

            if (st != 0)
            {
                throw new DemandPrintException(message, status);
            }
            // 2009.03.17 30413 ���� �t�b�^�[���̈󎚕ύX <<<<<<END
            
            // ���o�����ҏW����
            StringCollection extraInfomations;
            this.MakeExtarCondition(out extraInfomations);

            instance.ExtraConditions = extraInfomations;

			// �\�[�g���̏o��
			string sortTitle = "";
			this.SORTTITLE(out sortTitle);

			instance.PageHeaderSortOderTitle = sortTitle;

			// SUBTITLE�̏o��
			string subTitle = "";
			this.SUBTITLE(out subTitle);

			instance.PageHeaderSubtitle = subTitle;

            // 2009.03.17 30413 ���� �t�b�^�[���̈󎚕ύX >>>>>>START
            // �t�b�^�o�͋敪
            instance.PageFooterOutCode = prtOutSet.FooterPrintOutCode;

            // �t�b�^�o�̓��b�Z�[�W
            StringCollection footers = new StringCollection();
            footers.Add(prtOutSet.PrintFooter1);
            footers.Add(prtOutSet.PrintFooter2);

            instance.PageFooters = footers;
            // 2009.03.17 30413 ���� �t�b�^�[���̈󎚕ύX <<<<<<END
            
            // ������I�u�W�F�N�g
            instance.PrintInfo = this._printInfo;

            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            return status;
		}
		#endregion

		#region ���@�\�[�g���o��
		/// <summary>
		/// �\�[�g���o��
		/// </summary>
		/// <param name="sorttitle">�\�[�g���o��</param>
		/// <remarks>
		/// <br> �\�[�g���̏o�͂��쐬���܂��B</br>
		/// </remarks>
		private void SORTTITLE(out string sorttitle)
		{
			// �\�[�g��
			string wrkstr = "";
			sorttitle = "";
			switch (this._prYearCpPara.ListType)
			{
                case 0:
                    {
                        switch (this._prYearCpPara.IssueType)
                        {
                            case 0:
                            case 3:
                            case 4:
                                wrkstr = "���Ӑ�";
                                break;
                            case 1:
                            case 2:
                                wrkstr = "���_";
                                break;                            
                        }
                        break;
                    }
                case 1:
                    {
                        switch (this._prYearCpPara.IssueType)
                        {
                            case 0:
                            case 3:
                                wrkstr = "�S����";
                                break;
                            case 1:
                                wrkstr = "���Ӑ�";
                                break;
                            case 2:
                                wrkstr = "���_";
                                break;
                        }
                        break;
                    }
                case 2:
                    {
                        switch (this._prYearCpPara.IssueType)
                        {
                            case 0:
                            case 3:
                                wrkstr = "�󒍎�";
                                break;
                            case 1:
                                wrkstr = "���Ӑ�";
                                break;
                            case 2:
                                wrkstr = "���_";
                                break;
                        }
                        break;
                    }
                case 3:
                    {
                        switch (this._prYearCpPara.IssueType)
                        {
                            case 0:
                            case 3:
                                wrkstr = "�n��";
                                break;
                            case 1:
                                wrkstr = "���Ӑ�";
                                break;
                            case 2:
                                wrkstr = "���_";
                                break;
                        }
                        break;
                    }
                case 4:
                    {
                        switch (this._prYearCpPara.IssueType)
                        {
                            case 0:
                            case 3:
                                wrkstr = "�Ǝ�";
                                break;
                            case 1:
                                wrkstr = "���Ӑ�";
                                break;
                            case 2:
                                wrkstr = "���_";
                                break;
                        }
                        break;
                    }
                case 5:
                    {
                        switch (this._prYearCpPara.IssueType)
                        {
                            case 0:
                                wrkstr = "�O���[�v�R�[�h";
                                break;
                            case 1:
                                wrkstr = "���i������";
                                break;
                            case 2:
                                wrkstr = "���i�啪��";
                                break;
                        }
                        break;
                    }
                case 6:
                    {
                        switch (this._prYearCpPara.IssueType)
                        {
                            case 0:
                                wrkstr = "�a�k�R�[�h";
                                break;
                            case 1:
                                wrkstr = "���Ӑ�";
                                break;
                            case 2:
                                wrkstr = "�S����";
                                break;
                        }
                        break;
                    }

			}

			sorttitle = wrkstr;

		}
		#endregion

		#region ���@SUBTITLE�o��
		/// <summary>
		/// SUBTITLE�o��
		/// </summary>
		/// <param name="subtitle">SUBTITLE�o��</param>
		/// <remarks>
		/// <br> SUBTITLE�̏o�͂��쐬���܂��B</br>
		/// </remarks>
		private void SUBTITLE(out string subtitle)
		{
			// SUBTITLE�o��
			string substr = "";
			subtitle = "";
			switch (this._prYearCpPara.ListType)
			{
				case 0:
					{
                        substr = "�i���Ӑ�ʁj";
						break;
					}
				case 1:
					{
                        substr = "�i�S���ҕʁj";
						break;
					}
				case 2:
					{
						substr = "�i�󒍎ҕʁj";
						break;
					}
				case 3:
					{
						substr = "�i�n��ʁj";
						break;
					}
				case 4:
					{
						substr = "�i�Ǝ�ʁj";
						break;
					}
				case 5:
					{
						substr = "�i�O���[�v�R�[�h�ʁj";
						break;
                    }
                case 6:
                    {
                        substr = "�i�a�k�R�[�h�ʁj";
                        break;
                    }
			}

			subtitle = substr;

		}
				#endregion	
	
		#region ���@���o�����w�b�_�[�쐬����
		/// <summary>
		/// ���o�����o�͏��쐬
		/// </summary>
		/// <param name="extraConditions">�쐬�㒊�o�����R���N�V����</param>
		/// <remarks>
		/// <br>Note       : �o�͂��钊�o������������쐬���܂��B</br>
		/// <br>Programmer : 30462 �s�V �m��</br>
		/// <br>Date       : 2008.11.25</br>
		/// </remarks>
		private void MakeExtarCondition(out StringCollection extraConditions)
		{
			// ���o�����w�b�_�[����
			extraConditions = new StringCollection();
			
			// �Ώۊ���
			string target = "";
			string stTarget = "";
			string edTarget = "";
			string stmonth = "";
			string edmonth = "";

			// �Ώ۔N��
            if ((this._prYearCpPara.St_AddUpYearMonth != 0) ||
               (this._prYearCpPara.Ed_AddUpYearMonth != 0))
            {

				stmonth = this._prYearCpPara.St_AddUpYearMonth.ToString() + "01";
				DateTime dt_stMonth = DateTime.ParseExact(stmonth, "yyyyMMdd", null);
                //stTarget = "�Ώ۔N��: " + dt_stMonth.ToString("Y");       // DEL 2008.12.18 [9355]
                stTarget = "�Ώ۔N��: " + dt_stMonth.ToString("yyyy/MM");   // ADD 2008.12.18 [9355]

				edmonth = this._prYearCpPara.Ed_AddUpYearMonth.ToString() + "01";
				DateTime dt_edMonth = DateTime.ParseExact(edmonth, "yyyyMMdd", null);
                //edTarget = " �` " + dt_edMonth.ToString("Y");             // DEL 2008.12.18 [9355]
                edTarget = " �` " + dt_edMonth.ToString("yyyy/MM");         // ADD 2008.12.18 [9355]


                target = stTarget + edTarget;

                this.EditCondition(ref extraConditions, target);
            }

            // �W�v���@
			target = "�W�v���@: ";
            if (this._prYearCpPara.TotalWay == 0)
            {
                target += "�S��";
            }
            else
            {
                target += "���_��";
            }
            this.EditCondition(ref extraConditions, target);

			// ����^�C�v
			target = "����^�C�v: ";
			switch (this._prYearCpPara.PrintType)
			{
				case 0:
					target += "����";
					break;

				case 1:
					target += "�e��";
					break;

				case 2:
					target += "���さ�e��";
					break;
			}
			this.EditCondition(ref extraConditions, target);

			// ���z�P��
			target = "���z�P��: ";
			switch (this._prYearCpPara.MoneyUnit)
			{
				case 0:
					target += "�~";
					break;

				case 1:
					target += "��~";
					break;
			}
			this.EditCondition(ref extraConditions, target);


            switch (this._prYearCpPara.ListType)
            {
                case 0:
                    if (this._prYearCpPara.NewPage)
                    {
                        target = "����: ���_�P��";
                        this.EditCondition(ref extraConditions, target);
                    }
                    target = "���s�^�C�v: ";
                    switch (this._prYearCpPara.IssueType)
                    {
                        case 0:
                            target += "���Ӑ��";
                            break;
                        case 1:
                            target += "���_��";
                            break;
                        case 2:
                            target += "���Ӑ�ʋ��_��";
                            break;
                        case 3:
                            target += "�Ǘ����_��";
                            break;
                        case 4:
                            target += "�������";
                            break;
                    }
                    this.EditCondition(ref extraConditions, target);
                    break;
                case 1:
                    if (this._prYearCpPara.NewPage &&
                        !this._prYearCpPara.NewPage2)
                    {
                        target = "����: ���_�P��";
                        this.EditCondition(ref extraConditions, target);
                    }
                    if (!this._prYearCpPara.NewPage &&
                        this._prYearCpPara.NewPage2)
                    {
                        target = "����: �S���ҒP��";
                        this.EditCondition(ref extraConditions, target);
                    }
                    if (this._prYearCpPara.NewPage &&
                        this._prYearCpPara.NewPage2)
                    {
                        target = "����: ���_�P�ʁ^�S���ҒP��";
                        this.EditCondition(ref extraConditions, target);
                    }
                    target = "���s�^�C�v: ";
                    switch (this._prYearCpPara.IssueType)
                    {
                        case 0:
                            target += "�S���ҕ�";
                            break;
                        case 1:
                            target += "���Ӑ��";
                            break;
                        case 2:
                            target += "�S���ҕʋ��_��";
                            break;
                        case 3:
                            target += "�Ǘ����_��";
                            break;
                    }
                    this.EditCondition(ref extraConditions, target);

                    break;
                case 2:
                    if (this._prYearCpPara.NewPage &&
                        !this._prYearCpPara.NewPage2)
                    {
                        target = "����: ���_�P��";
                        this.EditCondition(ref extraConditions, target);
                    }
                    if (!this._prYearCpPara.NewPage &&
                        this._prYearCpPara.NewPage2)
                    {
                        target = "����: �󒍎ҒP��";
                        this.EditCondition(ref extraConditions, target);
                    }
                    if (this._prYearCpPara.NewPage &&
                        this._prYearCpPara.NewPage2)
                    {
                        target = "����: ���_�P�ʁ^�󒍎ҒP��";
                        this.EditCondition(ref extraConditions, target);
                    }
                    target = "���s�^�C�v: ";
                    switch (this._prYearCpPara.IssueType)
                    {
                        case 0:
                            target += "�󒍎ҕ�";
                            break;
                        case 1:
                            target += "���Ӑ��";
                            break;
                        case 2:
                            target += "�󒍎ҕʋ��_��";
                            break;
                        case 3:
                            target += "�Ǘ����_��";
                            break;
                    }
                    this.EditCondition(ref extraConditions, target);
                    break;
                case 3:
                    if (this._prYearCpPara.NewPage &&
                        !this._prYearCpPara.NewPage2)
                    {
                        target = "����: ���_�P��";
                        this.EditCondition(ref extraConditions, target);
                    }
                    if (!this._prYearCpPara.NewPage &&
                        this._prYearCpPara.NewPage2)
                    {
                        target = "����: �n��P��";
                        this.EditCondition(ref extraConditions, target);
                    }
                    if (this._prYearCpPara.NewPage &&
                        this._prYearCpPara.NewPage2)
                    {
                        target = "����: ���_�P�ʁ^�n��P��";
                        this.EditCondition(ref extraConditions, target);
                    }
                    target = "���s�^�C�v: ";
                    switch (this._prYearCpPara.IssueType)
                    {
                        case 0:
                            target += "�n���";
                            break;
                        case 1:
                            target += "���Ӑ��";
                            break;
                        case 2:
                            target += "�n��ʋ��_��";
                            break;
                        case 3:
                            target += "�Ǘ����_��";
                            break;
                    }
                    this.EditCondition(ref extraConditions, target);
                    break;
                case 4:
                    if (this._prYearCpPara.NewPage &&
                        !this._prYearCpPara.NewPage2)
                    {
                        target = "����: ���_�P��";
                        this.EditCondition(ref extraConditions, target);
                    }
                    if (!this._prYearCpPara.NewPage &&
                        this._prYearCpPara.NewPage2)
                    {
                        target = "����: �Ǝ�P��";
                        this.EditCondition(ref extraConditions, target);
                    }
                    if (this._prYearCpPara.NewPage &&
                        this._prYearCpPara.NewPage2)
                    {
                        target = "����: ���_�P�ʁ^�Ǝ�P��";
                        this.EditCondition(ref extraConditions, target);
                    }
                    target = "���s�^�C�v: ";
                    switch (this._prYearCpPara.IssueType)
                    {
                        case 0:
                            target += "�Ǝ��";
                            break;
                        case 1:
                            target += "���Ӑ��";
                            break;
                        case 2:
                            target += "�Ǝ�ʋ��_��";
                            break;
                        case 3:
                            target += "�Ǘ����_��";
                            break;
                    }
                    this.EditCondition(ref extraConditions, target);
                    break;
                case 5:
                    if (this._prYearCpPara.NewPage)
                    {
                        target = "����: ���_�P��";
                        this.EditCondition(ref extraConditions, target);
                    }
                    target = "���s�^�C�v: ";
                    switch (this._prYearCpPara.IssueType)
                    {
                        case 0:
                            target += "�O���[�v�R�[�h��";
                            break;
                        case 1:
                            target += "���i�����ޕ�";
                            break;
                        case 2:
                            target += "���i�啪�ޕ�";
                            break;
                    }
                    this.EditCondition(ref extraConditions, target);
                    break;
                case 6:
                    if (this._prYearCpPara.NewPage &&
                        !this._prYearCpPara.NewPage2)
                    {
                        target = "����: ���_�P��";
                        this.EditCondition(ref extraConditions, target);
                    }
                    if (!this._prYearCpPara.NewPage &&
                        this._prYearCpPara.NewPage2)
                    {
                        target = "����: �a�k�R�[�h�P��";
                        this.EditCondition(ref extraConditions, target);
                    }
                    if (this._prYearCpPara.NewPage &&
                        this._prYearCpPara.NewPage2)
                    {
                        target = "����: ���_�P�ʁ^�a�k�R�[�h�P��";
                        this.EditCondition(ref extraConditions, target);
                    }
                    target = "���s�^�C�v: ";
                    switch (this._prYearCpPara.IssueType)
                    {
                        case 0:
                            target += "�a�k�R�[�h��";
                            break;
                        case 1:
                            target += "�a�k�R�[�h�ʓ��Ӑ��";
                            break;
                        case 2:
                            target += "�a�k�R�[�h�ʒS���ҕ�";
                            break;
                    }
                    this.EditCondition(ref extraConditions, target);
                    break;
            }

            target = "����������: ";
            if (this._prYearCpPara.St_MonthSalesRatio_ck == true &&
                this._prYearCpPara.Ed_MonthSalesRatio_ck == true)
            {                
                target += this._prYearCpPara.St_MonthSalesRatio.ToString() + "�� �` ";
                target += this._prYearCpPara.Ed_MonthSalesRatio.ToString() + "��";
                this.EditCondition(ref extraConditions, target);
            }
            else if (this._prYearCpPara.St_MonthSalesRatio_ck == true &&
                this._prYearCpPara.Ed_MonthSalesRatio_ck == false)
            {
                target += this._prYearCpPara.St_MonthSalesRatio.ToString() + "�� �` ";
                target += "�Ō�܂�";
                this.EditCondition(ref extraConditions, target);
            }
            else if (this._prYearCpPara.St_MonthSalesRatio_ck == false &&
                   this._prYearCpPara.Ed_MonthSalesRatio_ck == true)
            {
                target += "�ŏ����� �` ";
                target += this._prYearCpPara.Ed_MonthSalesRatio.ToString() + "��";
                this.EditCondition(ref extraConditions, target);
            }

            target = "���N������: ";
            if (this._prYearCpPara.St_YearSalesRatio_ck == true &&
                this._prYearCpPara.Ed_YearSalesRatio_ck == true)
            {
                target += this._prYearCpPara.St_YearSalesRatio.ToString() + "�� �` ";
                target += this._prYearCpPara.Ed_YearSalesRatio.ToString() + "��";
                this.EditCondition(ref extraConditions, target);
            }
            else if (this._prYearCpPara.St_YearSalesRatio_ck == true &&
                     this._prYearCpPara.Ed_YearSalesRatio_ck == false)
            {
                target += this._prYearCpPara.St_YearSalesRatio.ToString() + "�� �` ";
                target += "�Ō�܂�";
                this.EditCondition(ref extraConditions, target);
            }
            else if (this._prYearCpPara.St_YearSalesRatio_ck == false &&
                     this._prYearCpPara.Ed_YearSalesRatio_ck == true)
            {
                target += "�ŏ����� �` ";
                target += this._prYearCpPara.Ed_YearSalesRatio.ToString() + "��";
                this.EditCondition(ref extraConditions, target);
            }

            target = "�����e��: ";
            if (this._prYearCpPara.St_MonthGrossRatio_ck == true &&
                this._prYearCpPara.Ed_MonthGrossRatio_ck == true)
            {
                target += this._prYearCpPara.St_MonthGrossRatio.ToString() + "�� �` ";
                target += this._prYearCpPara.Ed_MonthGrossRatio.ToString() + "��";
                this.EditCondition(ref extraConditions, target);
            }
            else if (this._prYearCpPara.St_MonthGrossRatio_ck == true &&
                     this._prYearCpPara.Ed_MonthGrossRatio_ck == false)
            {
                target += this._prYearCpPara.St_MonthGrossRatio.ToString() + "�� �` ";
                target += "�Ō�܂�";
                this.EditCondition(ref extraConditions, target);
            }
            else if (this._prYearCpPara.St_MonthGrossRatio_ck == false &&
                     this._prYearCpPara.Ed_MonthGrossRatio_ck == true)
            {
                target += "�ŏ����� �` ";
                target += this._prYearCpPara.Ed_MonthGrossRatio.ToString() + "��";
                this.EditCondition(ref extraConditions, target);
            }

            target = "���N�e��: ";
            if (this._prYearCpPara.St_YearGrossRatio_ck == true &&
                this._prYearCpPara.Ed_YearGrossRatio_ck == true)
            {
                target += this._prYearCpPara.St_YearGrossRatio.ToString() + "�� �` ";
                target += this._prYearCpPara.Ed_YearGrossRatio.ToString() + "��";
                this.EditCondition(ref extraConditions, target);
            }
            else if (this._prYearCpPara.St_YearGrossRatio_ck == true &&
                     this._prYearCpPara.Ed_YearGrossRatio_ck == false)
            {
                target += this._prYearCpPara.St_YearGrossRatio.ToString() + "�� �` ";
                target += "�Ō�܂�";
                this.EditCondition(ref extraConditions, target);
            }
            else if (this._prYearCpPara.St_YearGrossRatio_ck == false &&
           this._prYearCpPara.Ed_YearGrossRatio_ck == true)
            {
                target += "�ŏ����� �` ";
                target += this._prYearCpPara.Ed_YearGrossRatio.ToString() + "��";
                this.EditCondition(ref extraConditions, target);
            }

            switch (this._prYearCpPara.ListType)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                case 6:
                    target = "���Ӑ�: ";
                    if (this._prYearCpPara.St_CustomerCode != 0 &&
                        this._prYearCpPara.Ed_CustomerCode != 0)
                    {
                        target += this._prYearCpPara.St_CustomerCode + " �` ";
                        target += this._prYearCpPara.Ed_CustomerCode;
                        this.EditCondition(ref extraConditions, target);
                    }
                    else if (this._prYearCpPara.St_CustomerCode == 0 &&
                             this._prYearCpPara.Ed_CustomerCode != 0)
                    {
                        target += "�ŏ����� �` ";
                        target += this._prYearCpPara.Ed_CustomerCode;
                        this.EditCondition(ref extraConditions, target);
                    }
                    else if (this._prYearCpPara.St_CustomerCode != 0 &&
                             this._prYearCpPara.Ed_CustomerCode == 0)
                    {
                        target += this._prYearCpPara.St_CustomerCode + " �` ";
                        target += "�Ō�܂�";
                        this.EditCondition(ref extraConditions, target);
                    }
                    if (this._prYearCpPara.ListType == 1 ||
                        this._prYearCpPara.ListType == 2 ||
                        this._prYearCpPara.ListType == 6)
                    {
                        if (this._prYearCpPara.ListType == 1 ||
                            this._prYearCpPara.ListType == 6)
                        {
                            target = "�S����: ";
                        }
                        else
                        {
                            target = "�󒍎�: ";
                        }
                        if (!this._prYearCpPara.St_EmployeeCode.Trim().PadLeft(4,'0').Equals("0000") &&
                            !this._prYearCpPara.Ed_EmployeeCode.Trim().PadLeft(4, '0').Equals("0000"))
                        {
                            target += this._prYearCpPara.St_EmployeeCode + " �` ";
                            target += this._prYearCpPara.Ed_EmployeeCode;
                            this.EditCondition(ref extraConditions, target);
                        }
                        else if (this._prYearCpPara.St_EmployeeCode.Trim().PadLeft(4, '0').Equals("0000") &&
                                 !this._prYearCpPara.Ed_EmployeeCode.Trim().PadLeft(4, '0').Equals("0000"))
                        {
                            target += "�ŏ����� �` ";
                            target += this._prYearCpPara.Ed_EmployeeCode;
                            this.EditCondition(ref extraConditions, target);
                        }
                        else if (!this._prYearCpPara.St_EmployeeCode.Trim().PadLeft(4, '0').Equals("0000") &&
                                 this._prYearCpPara.Ed_EmployeeCode.Trim().PadLeft(4, '0').Equals("0000"))
                        {
                            target += this._prYearCpPara.St_EmployeeCode + " �` ";
                            target += "�Ō�܂�";
                            this.EditCondition(ref extraConditions, target);
                        }
                    }

                    if (this._prYearCpPara.ListType == 3)
                    {
                        target = "�n��: ";
                        if (this._prYearCpPara.St_SalesAreaCode != 0 &&
                            this._prYearCpPara.Ed_SalesAreaCode != 0)
                        {
                            target += this._prYearCpPara.St_SalesAreaCode + " �` ";
                            target += this._prYearCpPara.Ed_SalesAreaCode;
                            this.EditCondition(ref extraConditions, target);
                        }
                        else if (this._prYearCpPara.St_SalesAreaCode == 0 &&
                                 this._prYearCpPara.Ed_SalesAreaCode != 0)
                        {
                            target += "�ŏ����� �` ";
                            target += this._prYearCpPara.Ed_SalesAreaCode;
                            this.EditCondition(ref extraConditions, target);
                        }
                        else if (this._prYearCpPara.St_SalesAreaCode != 0 &&
                               this._prYearCpPara.Ed_SalesAreaCode == 0)
                        {
                            target += this._prYearCpPara.St_SalesAreaCode + " �` ";
                            target += "�Ō�܂�";
                            this.EditCondition(ref extraConditions, target);
                        }
                    }
                    if (this._prYearCpPara.ListType == 4)
                    {
                        target = "�Ǝ�: ";
                        if (this._prYearCpPara.St_BusinessTypeCode != 0 &&
                            this._prYearCpPara.Ed_BusinessTypeCode != 0)
                        {
                            target += this._prYearCpPara.St_BusinessTypeCode + " �` ";
                            target += this._prYearCpPara.Ed_BusinessTypeCode;
                            this.EditCondition(ref extraConditions, target);
                        }
                        else if (this._prYearCpPara.St_BusinessTypeCode == 0 &&
                                 this._prYearCpPara.Ed_BusinessTypeCode != 0)
                        {
                            target += "�ŏ����� �` ";
                            target += this._prYearCpPara.Ed_BusinessTypeCode;
                            this.EditCondition(ref extraConditions, target);
                        }
                        else if (this._prYearCpPara.St_BusinessTypeCode != 0 &&
                                 this._prYearCpPara.Ed_BusinessTypeCode == 0)
                        {
                            target += this._prYearCpPara.St_BusinessTypeCode + " �` ";
                            target += "�Ō�܂�";
                            this.EditCondition(ref extraConditions, target);
                        }
                    }
                    if (this._prYearCpPara.ListType == 6)
                    {
                        target = "�a�k�R�[�h: ";
                        if (this._prYearCpPara.St_BLGoodsCode != 0 &&
                            this._prYearCpPara.Ed_BLGoodsCode != 0)
                        {
                            target += this._prYearCpPara.St_BLGoodsCode + " �` ";
                            target += this._prYearCpPara.Ed_BLGoodsCode;
                            this.EditCondition(ref extraConditions, target);
                        }
                        else if (this._prYearCpPara.St_BLGoodsCode == 0 &&
                                 this._prYearCpPara.Ed_BLGoodsCode != 0)
                        {
                            target += "�ŏ����� �` ";
                            target += this._prYearCpPara.Ed_BusinessTypeCode;
                            this.EditCondition(ref extraConditions, target);
                        }
                        else if (this._prYearCpPara.St_BLGoodsCode != 0 &&
                                 this._prYearCpPara.Ed_BLGoodsCode == 0)
                        {
                            target += this._prYearCpPara.St_BLGoodsCode + " �` ";
                            target += "�Ō�܂�";
                            this.EditCondition(ref extraConditions, target);
                        }
                    }
                    break;
                case 5:
                    target = "���i�啪��: ";
                    if (this._prYearCpPara.St_GoodsLGroup != 0 &&
                        this._prYearCpPara.Ed_GoodsLGroup != 0)
                    {
                        target += this._prYearCpPara.St_GoodsLGroup + " �` ";
                        target += this._prYearCpPara.Ed_GoodsLGroup;
                        this.EditCondition(ref extraConditions, target);
                    }
                    else if (this._prYearCpPara.St_GoodsLGroup == 0 &&
                             this._prYearCpPara.Ed_GoodsLGroup != 0)
                    {
                        target += "�ŏ����� �` ";
                        target += this._prYearCpPara.Ed_GoodsLGroup;
                        this.EditCondition(ref extraConditions, target);
                    }
                    else if (this._prYearCpPara.St_GoodsLGroup != 0 &&
                             this._prYearCpPara.Ed_GoodsLGroup == 0)
                    {
                        target += this._prYearCpPara.St_GoodsLGroup + " �` ";
                        target += "�Ō�܂�";
                        this.EditCondition(ref extraConditions, target);
                    }
                    target = "���i������: ";
                    if (this._prYearCpPara.St_GoodsMGroup != 0 &&
                        this._prYearCpPara.Ed_GoodsMGroup != 0)
                    {
                        target += this._prYearCpPara.St_GoodsMGroup + " �` ";
                        target += this._prYearCpPara.Ed_GoodsMGroup;
                        this.EditCondition(ref extraConditions, target);
                    }
                    else if (this._prYearCpPara.St_GoodsMGroup == 0 &&
                             this._prYearCpPara.Ed_GoodsMGroup != 0)
                    {
                        target += "�ŏ����� �` ";
                        target += this._prYearCpPara.Ed_GoodsMGroup;
                        this.EditCondition(ref extraConditions, target);
                    }
                    else if (this._prYearCpPara.St_GoodsMGroup != 0 &&
                             this._prYearCpPara.Ed_GoodsMGroup == 0)
                    {
                        target += this._prYearCpPara.St_GoodsMGroup + " �` ";
                        target += "�Ō�܂�";
                        this.EditCondition(ref extraConditions, target);
                    }
                    target = "�O���[�v�R�[�h: ";
                    if (this._prYearCpPara.St_BLGroupCode != 0 &&
                        this._prYearCpPara.Ed_BLGroupCode != 0)
                    {
                        target += this._prYearCpPara.St_BLGroupCode + " �` ";
                        target += this._prYearCpPara.Ed_BLGroupCode;
                        this.EditCondition(ref extraConditions, target);
                    }
                    else if (this._prYearCpPara.St_BLGroupCode == 0 &&
                             this._prYearCpPara.Ed_BLGroupCode != 0)
                    {
                        target += "�ŏ����� �` ";
                        target += this._prYearCpPara.Ed_BLGroupCode;
                        this.EditCondition(ref extraConditions, target);
                    }
                    else if (this._prYearCpPara.St_BLGroupCode != 0 &&
                             this._prYearCpPara.Ed_BLGroupCode == 0)
                    {
                        target += this._prYearCpPara.St_BLGroupCode + " �` ";
                        target += "�Ō�܂�";
                        this.EditCondition(ref extraConditions, target);
                    }
                    break;
            }
		}
		
		/// <summary>
		/// ���o����������ҏW
		/// </summary>
		/// <param name="editArea">�i�[�G���A</param>
		/// <param name="target">�Ώە�����</param>
		/// <remarks>
		/// <br>Note       : �o�͂��钊�o�����������ҏW���܂��B</br>
		/// <br>Programmer : 30462 �s�V �m��</br>
		/// <br>Date       : 2008.11.25</br>
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

				if ((areaByte + targetByte + 2) <= 180)
				{
					isEdit = true;

					// �S�p�X�y�[�X��}��
					if (editArea[i] != null) editArea[i] += CT_ITEM_INTERVAL;
					
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
		
		#region ���@���ʃv���r���[���i�p�����[�^�ݒ�
		/// <summary>
		/// �����ʋ��ʏ��ݒ�
		/// </summary>
		/// <param name="commonInfo"></param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �����ʋ��ʏ����̐ݒ���s���܂��B</br>
		/// <br>Programmer : 30462 �s�V �m��</br>
		/// <br>Date       : 2008.11.25</br>
		/// </remarks>
		private void SetPrintCommonInfo(out Broadleaf.Windows.Forms.SFCMN00293UC commonInfo)
		{
			commonInfo = new Broadleaf.Windows.Forms.SFCMN00293UC();
		
			// �v�����^��
			commonInfo.PrinterName = this._printInfo.prinm;
			
			// ���[��
			commonInfo.PrintName   = this._printInfo.prpnm;				
				
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
		
		#region ���@������N�G���쐬�֐�
		/// <summary>
		/// �󎚏��N�G���쐬����
		/// </summary>
		/// <returns>�쐬�����N�G��</returns>
		/// <remarks>
		/// <br>Note       : DataView�ɐݒ肷��󎚏��ʂ̃N�G�����쐬���܂��B</br>
		/// <br>Programmer : 30462 �s�V �m��</br>
		/// <br>Date       : 2008.11.25</br>
		/// </remarks>
		private string GetPrintOderQuerry()
		{
            string oderQuerry = "";

            //switch (this._prYearCpPara.PrintType)         //DEL 2009/01/30 �s��Ή�[9841]
            switch (this._prYearCpPara.ListType)            //ADD 2009/01/30 �s��Ή�[9841]
            {
                case 0:
                    {
                        switch (this._prYearCpPara.IssueType)
                        {
                            case 0:
                            case 3:
                            case 4:
                                oderQuerry = "AddUpSecCode,CustomerCode";   // ���_�����Ӑ�
                                break;
                            case 1:
                                oderQuerry = "AddUpSecCode";                // ���_
                                break;
                            case 2:
                                oderQuerry = "CustomerCode,AddUpSecCode";   // ���Ӑ�^���_
                                break;
                        }
                        break;
                    }
                case 1:
                case 2:
                    {
                        switch (this._prYearCpPara.IssueType)
                        {
                            case 0:
                            case 3:
                                oderQuerry = "AddUpSecCode,EmployeeCode";               // ���_���S����
                                break;
                            case 1:
                                oderQuerry = "AddUpSecCode,EmployeeCode,CustomerCode";  // ���_���S���ҁ����Ӑ�
                                break;
                            case 2:
                                oderQuerry = "EmployeeCode,AddUpSecCode";               // �S���ҁ����_
                                break;
                        }
                        break;
                    }
                case 3:
                    {
                        switch (this._prYearCpPara.IssueType)
                        {
                            case 0:
                            case 3:
                                oderQuerry = "AddUpSecCode,SalesAreaCode";              // ���_���n��
                                break;
                            case 1:
                                oderQuerry = "AddUpSecCode,SalesAreaCode,CustomerCode"; // ���_���n�恨���Ӑ�
                                break;
                            case 2:
                                oderQuerry = "SalesAreaCode,AddUpSecCode";              // �n�恨���_
                                break;
                        }
                        break;
                    }
                case 4:
                    {
                        switch (this._prYearCpPara.IssueType)
                        {
                            case 0:
                            case 3:
                                oderQuerry = "AddUpSecCode,BusinessTypeCode";              // ���_���Ǝ�
                                break;
                            case 1:
                                oderQuerry = "AddUpSecCode,BusinessTypeCode,CustomerCode"; // ���_���Ǝ큨���Ӑ�
                                break;
                            case 2:
                                oderQuerry = "BusinessTypeCode,AddUpSecCode";              // �Ǝ큨���_
                                break;
                        }
                        break;
                    }
                case 5:
                    {
                        switch (this._prYearCpPara.IssueType)
                        {
                            case 0:
                                oderQuerry = "AddUpSecCode,BLGroupCode";        // ���_���O���[�v�R�[�h
                                break;
                            case 1:
                                oderQuerry = "AddUpSecCode,GoodsMGroup";        // ���_�����i������
                                break;
                            case 2:
                                oderQuerry = "AddUpSecCode,GoodsLGroup";        // ���_�����i�啪��
                                break;
                        }
                        break;
                    }
                case 6:
                    {
                        switch (this._prYearCpPara.IssueType)
                        {
                            case 0:
                                oderQuerry = "AddUpSecCode,BLGoodsCode";                // ���_���a�k�R�[�h
                                break;
                            case 1:
                                oderQuerry = "AddUpSecCode,BLGoodsCode,CustomerCode";   // ���_���a�k�R�[�h�����Ӑ�
                                break;
                            case 2:
                                oderQuerry = "AddUpSecCode,BLGoodsCode,EmployeeCode";   // ���_���a�k�R�[�h���S����
                                break;
                        }
                        break;
                    }
                
            }
			
			return oderQuerry;
		}
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
		/// <br>Programmer : 30462 �s�V �m��</br>
		/// <br>Date       : 2008.11.25</br>
		/// </remarks>
		private DialogResult TMessageBox(emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton)
		{
			return TMsgDisp.Show(iLevel, "DCTOK02092P", iMsg, iSt, iButton, iDefButton);
		}
		#endregion
		#endregion
	}
}

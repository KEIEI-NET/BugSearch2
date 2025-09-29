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
    /// ���ϊm�F�\����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���ϊm�F�\�̈�����s���B</br>
    /// <br>Programmer : 22018 ��� ���b</br>
    /// <br>Date       : 2007.09.19</br>
    /// </remarks>
    class DCMIT02102PA : IPrintProc
    {
        #region �� Constructor
        /// <summary>
        /// ���ϊm�F�\����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ϊm�F�\����N���X�̃C���X�^���X�̍쐬���s���B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.09.19</br>
        /// </remarks>
        public DCMIT02102PA ()
        {
        }

        /// <summary>
        /// ���ϊm�F�\����N���X�R���X�g���N�^
        /// </summary>
        /// <param name="printInfo">������I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ���ϊm�F�\����N���X�̃C���X�^���X�̍쐬���s���B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.09.19</br>
        /// </remarks>
        public DCMIT02102PA ( object printInfo )
        {
            this._printInfo = printInfo as SFCMN06002C;
            this._estimateListCndtn = this._printInfo.jyoken as EstimateListCndtn;
        }
        #endregion �� Constructor

        #region �� Pricate Const
        private const string ct_ReportForm_NameSpace = "Broadleaf.Drawing.Printing";
        private const string ct_Space = "�@";
        // 2008.08.01 30413 ���� �����ύX >>>>>>START
        //private const string ct_Extr_Top = "�s�n�o";
        //private const string ct_Extr_End = "�d�m�c";
        private const string ct_Extr_Top = "�ŏ�����";
        private const string ct_Extr_End = "�Ō�܂�";
        // 2008.08.01 30413 ���� �����ύX <<<<<<END
        private const string ct_RangeConst = "�F{0} �` {1}";
        #endregion �� Pricate Const

        #region �� Private Member
        private SFCMN06002C _printInfo;					// ������N���X
        private EstimateListCndtn _estimateListCndtn;		// ���o�����N���X
        #endregion �� Private Member

        #region �� Exception Class
        /// <summary> ��O�N���X </summary>
        private class StockMoveException : ApplicationException
        {
            private int _status;
            #region �� Constructor
            /// <summary>
            /// ��O�N���X�R���X�g���N�^
            /// </summary>
            /// <param name="message">���b�Z�[�W</param>
            /// <param name="status">�X�e�[�^�X</param>
            public StockMoveException ( string message, int status )
                : base( message )
            {
                this._status = status;
            }
            #endregion

            #region �� Public Property
            /// <summary> �X�e�[�^�X�v���p�e�B </summary>
            public int Status
            {
                get { return this._status; }
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
            set { this._printInfo = value; }
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
                this.CreateReport( out prtRpt, this._printInfo.prpid );
                if ( prtRpt == null ) return status;

                // �e��v���p�e�B�ݒ�
                status = this.SettingProperty( ref prtRpt );
                if ( status != 0 ) return status;

                // �f�[�^�\�[�X�ݒ�
                prtRpt.DataSource = this._printInfo.rdData;
                prtRpt.DataMember = DCMIT02104EA.ct_Tbl_EstimateList;

                // ������ʏ��v���p�e�B�ݒ�
                Broadleaf.Windows.Forms.SFCMN00293UC commonInfo;
                this.SetPrintCommonInfo( out commonInfo );

                // �v���r���[�L��				
                int mode = this._printInfo.prevkbn;

                // �o�̓��[�h���o�c�e�̏ꍇ�A�������Ńv���r���[��
                if ( this._printInfo.printmode == 2 )
                {
                    mode = 0;
                }

                switch ( mode )
                {
                    case 0:		// �v���r����
                        {
                            Broadleaf.Windows.Forms.SFCMN00293UB processForm = new Broadleaf.Windows.Forms.SFCMN00293UB();

                            // ���ʏ����ݒ�
                            processForm.CommonInfo = commonInfo;

                            // �v���O���X�o�[UP�C�x���g�ǉ�
                            if ( prtRpt is IPrintActiveReportTypeCommon )
                            {
                                ( (IPrintActiveReportTypeCommon)prtRpt ).ProgressBarUpEvent +=
                                    new ProgressBarUpEventHandler( processForm.ProgressBarUpEvent );
                            }

                            // ������s
                            status = processForm.Run( prtRpt );

                            // �߂�l�ݒ�
                            this._printInfo.status = status;

                            break;
                        }
                    case 1:		// �v���r���L
                        {
                            Broadleaf.Windows.Forms.SFCMN00293UA viewForm = new Broadleaf.Windows.Forms.SFCMN00293UA();

                            // ���ʏ����ݒ�
                            viewForm.CommonInfo = commonInfo;

                            // �v���r���[���s
                            status = viewForm.Run( prtRpt );

                            // �߂�l�ݒ�
                            this._printInfo.status = status;

                            break;
                        }
                }

                // �o�c�e�o�͂̏ꍇ
                if ( status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
                {
                    switch ( this._printInfo.printmode )
                    {
                        case 1:  // �v�����^
                            break;
                        case 2:  // �o�c�e
                        case 3:  // ����(�v�����^ + �o�c�e)
                            {
                                // �o�c�e�\���t���OON
                                this._printInfo.pdfopen = true;

                                // ����������̂ݗ���ۑ�
                                if ( this._printInfo.printmode == 3 )
                                {
                                    // �o�͗����Ǘ��ɒǉ�
                                    Broadleaf.Windows.Forms.SFANL06101UA pdfHistoryControl = new Broadleaf.Windows.Forms.SFANL06101UA();
                                    pdfHistoryControl.AddPrintInfo( this._printInfo.key, this._printInfo.prpnm, this._printInfo.prpnm,
                                        this._printInfo.pdftemppath );
                                }
                                break;
                            }
                    }
                }
            }
            catch ( Exception ex )
            {
                this.MsgDispProc( emErrorLevel.ERR_LEVEL_STOPDISP,
                    ex.Message, -1, MessageBoxButtons.OK, MessageBoxDefaultButton.Button1 );
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
        private void CreateReport ( out DataDynamics.ActiveReports.ActiveReport3 rptObj, string prpid )
        {
            // ����t�H�[���N���X�C���X�^���X�쐬
            rptObj = (DataDynamics.ActiveReports.ActiveReport3)this.LoadAssemblyReport(
                prpid.Trim(), ct_ReportForm_NameSpace + "." + prpid.Trim(),
                typeof( DataDynamics.ActiveReports.ActiveReport3 ) );
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
        private object LoadAssemblyReport ( string asmname, string classname, Type type )
        {
            object obj = null;
            try
            {
                System.Reflection.Assembly asm = System.Reflection.Assembly.Load( asmname );
                Type objType = asm.GetType( classname );
                if ( objType != null )
                {
                    if ( ( objType == type ) || ( objType.IsSubclassOf( type ) == true ) || ( objType.GetInterface( type.Name ).Name == type.Name ) )
                    {
                        obj = Activator.CreateInstance( objType );
                    }
                }
            }
            catch ( System.IO.FileNotFoundException )
            {
                throw new StockMoveException( asmname + "�����݂��܂���B", -1 );
            }
            catch ( System.Exception er )
            {
                throw new StockMoveException( er.Message, -1 );
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
        private void SetPrintCommonInfo ( out Broadleaf.Windows.Forms.SFCMN00293UC commonInfo )
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
            commonInfo.PrintName = this._printInfo.prpnm;
            // ������[�h
            commonInfo.PrintMode = this.Printinfo.printmode;
            // �������
            commonInfo.PrintMax = (this._printInfo.rdData as DataView).Count;

            status = cmnCommon.GetPdfSavePathName( this._printInfo.prpnm, ref pdfPath, ref pdfName );
            this._printInfo.pdftemppath = pdfPath + pdfName;
            commonInfo.PdfFullPath = this._printInfo.pdftemppath;

            // ��]��
            commonInfo.MarginsTop = this._printInfo.py;
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
        private int SettingProperty ( ref DataDynamics.ActiveReports.ActiveReport3 rpt )
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // ActiveReport�C���^�[�t�F�[�X�ɃL���X�g
            IPrintActiveReportTypeList instance = rpt as IPrintActiveReportTypeList;

            // ��������擾
            EstimateListCndtn extraInfo = (EstimateListCndtn)this._printInfo.jyoken;

            // �\�[�g���v���p�e�B�ݒ�
            instance.PageHeaderSortOderTitle = "";

            // ���[�o�͐ݒ���擾 
            PrtOutSet prtOutSet;
            string message;
            int st = EstimateListAcs.ReadPrtOutSet( out prtOutSet, out message );
            if ( st != 0 )
            {
                throw new StockMoveException( message, status );
            }



            // ���o�����w�b�_�o�͋敪
            instance.ExtraCondHeadOutDiv = prtOutSet.ExtraCondHeadOutDiv;

            // ���o�����ҏW����
            StringCollection extraInfomations;
            this.MakeExtarCondition( out extraInfomations );

            instance.ExtraConditions = extraInfomations;

            // �t�b�^�o�͋敪
            instance.PageFooterOutCode = prtOutSet.FooterPrintOutCode;

            // �t�b�^�o�̓��b�Z�[�W
            StringCollection footers = new StringCollection();
            footers.Add( prtOutSet.PrintFooter1 );
            footers.Add( prtOutSet.PrintFooter2 );

            instance.PageFooters = footers;

            // ������I�u�W�F�N�g
            instance.PrintInfo = this._printInfo;

            // �w�b�_�[�T�u�^�C�g��
            object[] titleObj = new object[] { "���ϊm�F�\" };
            instance.PageHeaderSubtitle = string.Format( "{0}", titleObj );

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
        private void MakeExtarCondition ( out StringCollection extraConditions )
        {
            // 2008.08.01 30413 ���� �����ύX >>>>>>START
            //const string dateFormat = "yyyy�NMM��dd��";
            const string dateFormat = "yyyy/MM/dd";
            // 2008.08.01 30413 ���� �����ύX <<<<<<END
            
            extraConditions = new StringCollection();
            StringCollection addConditions = new StringCollection();
            string target = "";
            string stTarget = string.Empty;
            string edTarget = string.Empty;
            
            // 2008.08.01 30413 ���� ���ϓ����Ɉ� >>>>>>START
            //-------------------------------------------------------------------------------------------------------------------
            // ���ϓ�

            // �J�n��I���̂����ꂩ�����͂���Ă���Έ�
            if ((this._estimateListCndtn.St_SalesDate != DateTime.MinValue) || (this._estimateListCndtn.Ed_SalesDate != DateTime.MinValue))
            {
                // �J�n
                if (this._estimateListCndtn.St_SalesDate != DateTime.MinValue)
                {
                    stTarget = this._estimateListCndtn.St_SalesDate.ToString(dateFormat);
                }
                else
                {
                    stTarget = ct_Extr_Top;
                }
                // �I��
                if (this._estimateListCndtn.Ed_SalesDate != DateTime.MinValue)
                {
                    edTarget = this._estimateListCndtn.Ed_SalesDate.ToString(dateFormat);
                }
                else
                {
                    edTarget = ct_Extr_End;
                }
                this.EditCondition(ref addConditions, string.Format("���ϓ�" + ct_RangeConst, stTarget, edTarget));
            }
            // 2008.08.01 30413 ���� ���ϓ����Ɉ� <<<<<<END
            
            //-------------------------------------------------------------------------------------------------------------------
            // ���͓�
            // �J�n��I���̂����ꂩ�����͂���Ă���Έ�
            if ( ( this._estimateListCndtn.St_SearchSlipDate != DateTime.MinValue ) || ( this._estimateListCndtn.Ed_SearchSlipDate != DateTime.MinValue ) )
            {
                // �J�n
                if ( this._estimateListCndtn.St_SearchSlipDate != DateTime.MinValue )
                {
                    stTarget = this._estimateListCndtn.St_SearchSlipDate.ToString(dateFormat);
                }
                else
                {
                    stTarget = ct_Extr_Top;
                }
                // �I��
                if ( this._estimateListCndtn.Ed_SearchSlipDate != DateTime.MinValue )
                {
                    edTarget = this._estimateListCndtn.Ed_SearchSlipDate.ToString(dateFormat);
                }
                else
                {
                    edTarget = ct_Extr_End;
                }
                this.EditCondition(ref addConditions, string.Format("���͓�" + ct_RangeConst, stTarget, edTarget));
            }

            // 2008.08.01 30413 ���� ���ϓ����Ɉ� >>>>>>START
            ////-------------------------------------------------------------------------------------------------------------------
            //// ���ϓ�

            //// �J�n��I���̂����ꂩ�����͂���Ă���Έ�
            //if ( (this._estimateListCndtn.St_SalesDate != DateTime.MinValue) || (this._estimateListCndtn.Ed_SalesDate != DateTime.MinValue) )
            //{
            //    // �J�n
            //    if ( this._estimateListCndtn.St_SalesDate != DateTime.MinValue )
            //    {
            //        stDate = this._estimateListCndtn.St_SalesDate.ToString( dateFormat );
            //    }
            //    else
            //    {
            //        stDate = ct_Extr_Top;
            //    }
            //    // �I��
            //    if ( this._estimateListCndtn.Ed_SalesDate != DateTime.MinValue )
            //    {
            //        edDate = this._estimateListCndtn.Ed_SalesDate.ToString( dateFormat );
            //    }
            //    else
            //    {
            //        edDate = ct_Extr_End;
            //    }
            //    this.EditCondition( ref addConditions, string.Format( "���ϓ�" + ct_RangeConst, stDate, edDate ) );
            //}
            // 2008.08.01 30413 ���� ���ϓ����Ɉ� <<<<<<END

            // 2008.09.01 30413 ���� �S���ҁA���Ӑ�̏��ň� >>>>>>START
            ////----------------------------------------------------------------------------------------------------------------
            //// ���Ӑ�
            //// �J�n��I���̂����ꂩ�����͂���Ă���Έ�
            //if ( this._estimateListCndtn.St_CustomerCode != 0 || this._estimateListCndtn.Ed_CustomerCode != 999999999 )
            //{
            //    string stCode = this._estimateListCndtn.St_CustomerCode.ToString();
            //    string edCode = this._estimateListCndtn.Ed_CustomerCode.ToString();
            //    if ( stCode == string.Empty ) stCode = ct_Extr_Top;
            //    if ( edCode == string.Empty ) edCode = ct_Extr_End;

            //    this.EditCondition( ref addConditions, string.Format( "���Ӑ�" + ct_RangeConst, stCode, edCode ) );
            //}

            ////-------------------------------------------------------------------------------------------------------------------
            //// �S���� 
            //// �J�n��I���̂����ꂩ�����͂���Ă���Έ�
            //if ( this._estimateListCndtn.St_SalesEmployeeCd != string.Empty || this._estimateListCndtn.Ed_SalesEmployeeCd != string.Empty )
            //{
            //    string stCode = this._estimateListCndtn.St_SalesEmployeeCd;
            //    string edCode = this._estimateListCndtn.Ed_SalesEmployeeCd;
            //    if ( stCode == string.Empty ) stCode = ct_Extr_Top;
            //    if ( edCode == string.Empty ) edCode = ct_Extr_End;

            //    this.EditCondition( ref addConditions, string.Format( "�S����" + ct_RangeConst, stCode, edCode ) );
            //}


            ////----------------------------------------------------------------------------------------------------------------
            //// ���Ӑ�
            //if ((this._estimateListCndtn.St_CustomerCode == 0) && (this._estimateListCndtn.Ed_CustomerCode != 999999999))
            //{
            //    target = string.Format("���Ӑ�" + ct_RangeConst, ct_Extr_Top, this._estimateListCndtn.Ed_CustomerCode.ToString());
            //}

            //if ((this._estimateListCndtn.St_CustomerCode > 0) && (this._estimateListCndtn.Ed_CustomerCode == 999999999))
            //{
            //    target = string.Format("���Ӑ�" + ct_RangeConst, this._estimateListCndtn.St_CustomerCode.ToString(), ct_Extr_End);
            //}

            //if ((this._estimateListCndtn.St_CustomerCode > 0) && (this._estimateListCndtn.Ed_CustomerCode != 999999999))
            //{
            //    target = string.Format("���Ӑ�" + ct_RangeConst, this._estimateListCndtn.St_CustomerCode.ToString(), this._estimateListCndtn.Ed_CustomerCode.ToString());
            //}
            //this.EditCondition(ref addConditions, target);
            // 2008.09.01 30413 ���� �S���ҁA���Ӑ�̏��ň� <<<<<<END

            // 2008.09.26 30413 ���� ���o�����̏o�͐����ύX >>>>>>START
            // �S����
            if ((this._estimateListCndtn.St_SalesEmployeeCd == "") && (this._estimateListCndtn.Ed_SalesEmployeeCd != ""))
            {
                stTarget = ct_Extr_Top;
                edTarget = this._estimateListCndtn.Ed_SalesEmployeeCd;
                this.EditCondition(ref addConditions, string.Format("�S����" + ct_RangeConst, stTarget, edTarget));
            }
            else if ((this._estimateListCndtn.St_SalesEmployeeCd != "") && (this._estimateListCndtn.Ed_SalesEmployeeCd == ""))
            {
                stTarget = this._estimateListCndtn.St_SalesEmployeeCd;
                edTarget = ct_Extr_End;
                this.EditCondition(ref addConditions, string.Format("�S����" + ct_RangeConst, stTarget, edTarget));
            }
            else if ((this._estimateListCndtn.St_SalesEmployeeCd != "") && (this._estimateListCndtn.Ed_SalesEmployeeCd != ""))
            {
                stTarget = this._estimateListCndtn.St_SalesEmployeeCd;
                edTarget = this._estimateListCndtn.Ed_SalesEmployeeCd;
                this.EditCondition(ref addConditions, string.Format("�S����" + ct_RangeConst, stTarget, edTarget));
            }

            // ���Ӑ�
            if ((this._estimateListCndtn.St_CustomerCode == 0) && (this._estimateListCndtn.Ed_CustomerCode != 0))
            {
                stTarget = ct_Extr_Top;
                edTarget = this._estimateListCndtn.Ed_CustomerCode.ToString("d08");
                this.EditCondition(ref addConditions, string.Format("���Ӑ�" + ct_RangeConst, stTarget, edTarget));
            }
            else if ((this._estimateListCndtn.St_CustomerCode > 0) && (this._estimateListCndtn.Ed_CustomerCode == 0))
            {
                stTarget = this._estimateListCndtn.St_CustomerCode.ToString("d08");
                edTarget = ct_Extr_End;
                this.EditCondition(ref addConditions, string.Format("���Ӑ�" + ct_RangeConst, stTarget, edTarget));
            }
            else if ((this._estimateListCndtn.St_CustomerCode > 0) && (this._estimateListCndtn.Ed_CustomerCode != 0))
            {
                stTarget = this._estimateListCndtn.St_CustomerCode.ToString("d08");
                edTarget = this._estimateListCndtn.Ed_CustomerCode.ToString("d08");
                this.EditCondition(ref addConditions, string.Format("���Ӑ�" + ct_RangeConst, stTarget, edTarget));
            }
            // 2008.09.26 30413 ���� ���o�����̏o�͐����ύX <<<<<<END

            // 2008.08.01 30413 ���� ���σ^�C�v�A���s�^�C�v��ǉ� >>>>>>START
            // ���σ^�C�v
            switch (this._estimateListCndtn.EstimateDivide)
            {
                case -1:
                    {
                        target = "���σ^�C�v�F �S��";
                        this.EditCondition(ref addConditions, target);
                        break;
                    }
                case 0:
                    {
                        target = "���σ^�C�v�F ������͕�";
                        this.EditCondition(ref addConditions, target);
                        break;
                    }
                case 1:
                    {
                        target = "���σ^�C�v�F �������ϕ�";
                        this.EditCondition(ref addConditions, target);
                        break;
                    }
            }

            // ���s�^�C�v
            switch (this._estimateListCndtn.PrintDiv)
            {
                case -1:
                    {
                        target = "���s�^�C�v�F �S��";
                        this.EditCondition(ref addConditions, target);
                        break;
                    }
                case 0:
                    {
                        target = "���s�^�C�v�F ���όv��";
                        this.EditCondition(ref addConditions, target);
                        break;
                    }
            }
            // 2008.08.01 30413 ���� ���σ^�C�v��ǉ� <<<<<<END
            
            // �ǉ�
            foreach ( string exCondStr in addConditions )
            {
                extraConditions.Add( exCondStr );
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
        private string GetConditionRange ( string title, string startString, string endString )
        {
            string result = "";
            if ( ( startString != "" ) || ( endString != "" ) )
            {
                string start = ct_Extr_Top;
                string end = ct_Extr_End;
                if ( startString != "" ) start = startString;
                if ( endString != "" ) end = endString;
                result = String.Format( title + ct_RangeConst, start, end );
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
        private void EditCondition ( ref StringCollection editArea, string target )
        {
            bool isEdit = false;

            // 2008.09.26 30413 ���� ���o������K�X���s����悤�ɏC�� >>>>>>START
            // �ҏW�Ώە����o�C�g���Z�o
            int targetByte = TStrConv.SizeCountSJIS(target);

            //for ( int i = 0; i < editArea.Count; i++ )
            //{
            //    int areaByte = 0;

            //    // �i�[�G���A�̃o�C�g���Z�o
            //    if ( editArea[i] != null )
            //    {
            //        areaByte = TStrConv.SizeCountSJIS( editArea[i] );
            //    }

            //    if ( ( areaByte + targetByte + 2 ) <= 190 )
            //    {
            //        isEdit = true;

            //        // �S�p�X�y�[�X��}��
            //        if ( editArea[i] != null ) editArea[i] += ct_Space;

            //        editArea[i] += target;
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
                    if (editArea[index] != null) editArea[index] += ct_Space;

                    editArea[index] += target;
                }
            }
            // 2008.09.17 30413 ���� ���o������K�X���s����悤�ɏC�� <<<<<<END

            // �V�K�ҏW�G���A�쐬
            if ( !isEdit )
            {
                editArea.Add( target );
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
        private DialogResult MsgDispProc ( emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton )
        {
            // 2008.08.01 30413 ���� �A�Z���u��ID���C�� >>>>>>START
            //return TMsgDisp.Show(iLevel, "MAZAI02032P", iMsg, iSt, iButton, iDefButton);
            return TMsgDisp.Show(iLevel, "DCMIT02102P", iMsg, iSt, iButton, iDefButton);
            // 2008.08.01 30413 ���� �A�Z���u��ID���C�� >>>>>>START
        }

        #endregion
        #endregion
    }
}

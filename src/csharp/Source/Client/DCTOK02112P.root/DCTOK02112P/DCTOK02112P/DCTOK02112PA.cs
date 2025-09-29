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
    /// ������ѕ\����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ������ѕ\�̈�����s���B</br>
    /// <br>Programmer : 22018 ��� ���b</br>
    /// <br>Date       : 2007.11.26</br>
    /// <br>Update Note: 2008.10.08 30452 ��� �r��</br>
    /// <br>            �EPM.NS�Ή�</br>
    /// <br>Update Note: 2008/10/23       �Ɠc �M�u</br>
    /// <br>            �E�o�O�C���A�d�l�ύX�Ή�</br>
    /// <br>Update Note: 2009/02/10       ��� �r��</br>
    /// <br>            �E��Q�Ή�11324,11325,11326</br>
    /// <br>Update Note: 2009/03/17       ��� �r��</br>
    /// <br>            �E��Q�Ή�12698</br>
    /// <br>Update Note: 2009.04.11 ����</br>
    /// <br>            �E������ѕ\�i�d����ʁj�̒ǉ�</br>
    /// <br>Update Note: 2014/12/16 �� ��</br>
    /// <br>�Ǘ��ԍ�   : 11070263-00</br>
    /// <br>           : �����Y�ƗlSeiken�i�ԕύX</br>
    /// </remarks>
    class DCTOK02112PA : IPrintProc
    {
        #region �� Constructor
        /// <summary>
        /// ������ѕ\����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ������ѕ\����N���X�̃C���X�^���X�̍쐬���s���B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.11.26</br>
        /// </remarks>
        public DCTOK02112PA ()
        {
        }

        /// <summary>
        /// ������ѕ\����N���X�R���X�g���N�^
        /// </summary>
        /// <param name="printInfo">������I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ������ѕ\����N���X�̃C���X�^���X�̍쐬���s���B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.11.26</br>
        /// </remarks>
        public DCTOK02112PA ( object printInfo )
        {
            this._printInfo = printInfo as SFCMN06002C;
            this._salesRsltListCndtn = this._printInfo.jyoken as SalesRsltListCndtn;
        }
        #endregion �� Constructor

        #region �� Pricate Const
        private const string ct_ReportForm_NameSpace = "Broadleaf.Drawing.Printing";
        private const string ct_Space = "�@";
        //private const string ct_Extr_Top = "�s�n�o"; // DEL 2008/10/08
        //private const string ct_Extr_End = "�d�m�c"; // DEL 2008/10/08
        private const string ct_Extr_Top = "�ŏ�����"; // ADD 2008/10/08
        private const string ct_Extr_End = "�Ō�܂�"; // ADD 2008/10/08
        private const string ct_RangeConst = "�F{0} �` {1}";
        #endregion �� Pricate Const

        #region �� Private Member
        private SFCMN06002C _printInfo;					// ������N���X
        private SalesRsltListCndtn _salesRsltListCndtn;		// ���o�����N���X
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
        /// <br>Date       : 2007.11.26</br>
        /// </remarks>
        public int StartPrint ()
        {
            return PrintMain();
        }
        #endregion
        #endregion �� Public Method
        #endregion �� IPrintProc �����o

        #region �� Private Method
        #region �� �������
        /// <summary>
        /// �������
        /// </summary>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : ����������s���B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.11.26</br>
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
                prtRpt.DataMember = DCTOK02114EA.ct_Tbl_SalesRsltList;

                // ������ʏ��v���p�e�B�ݒ�
                Broadleaf.Windows.Forms.SFCMN00293UC commonInfo;
                //this.SetPrintCommonInfo( out commonInfo ); // DEL 2009/03/17
                this.SetPrintCommonInfo(ref prtRpt, out commonInfo); // ADD 2009/03/17

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
        /// <br>Date       : 2007.11.26</br>
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
        /// <br>Date       : 2007.11.26</br>
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
        /// <param name="rptObj"></param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �����ʋ��ʏ����̐ݒ���s���܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.11.26</br>
        /// </remarks>
        //private void SetPrintCommonInfo ( out Broadleaf.Windows.Forms.SFCMN00293UC commonInfo ) // DEL 2009/03/17
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
        /// <br>Date       : 2007.11.26</br>
        /// </remarks>
        private int SettingProperty ( ref DataDynamics.ActiveReports.ActiveReport3 rpt )
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;

            // ActiveReport�C���^�[�t�F�[�X�ɃL���X�g
            IPrintActiveReportTypeList instance = rpt as IPrintActiveReportTypeList;

            // ��������擾
            SalesRsltListCndtn extraInfo = (SalesRsltListCndtn)this._printInfo.jyoken;

            // �\�[�g���v���p�e�B�ݒ�
            //instance.PageHeaderSortOderTitle = ""; // DEL 2008/10/08
            instance.PageHeaderSortOderTitle = "[" + extraInfo.DetailDataValueName + "��]"; // ADD 2008/10/08

            // ���[�o�͐ݒ���擾 
            PrtOutSet prtOutSet;
            string message;
            int st = SalesRsltListAcs.ReadPrtOutSet( out prtOutSet, out message );
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
            instance.PageHeaderSubtitle = string.Format( "{0}", this._printInfo.prpnm );

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
        /// <br>Date       : 2007.11.26</br>
        /// <br>Update Note: 2014/12/16 �� ��</br>
        /// <br>�Ǘ��ԍ�   : 11070263-00</br>
        /// <br>           : �����Y�ƗlSeiken�i�ԕύX</br>
        /// </remarks>
        private void MakeExtarCondition ( out StringCollection extraConditions )
        {
            extraConditions = new StringCollection();
            StringCollection addConditions = new StringCollection();

            string stCode;
            string edCode;

            //------------------------------------------------------------------------------------------------------------
            if (this._salesRsltListCndtn.TotalType != SalesRsltListCndtn.TotalTypeState.EachWareHouse)
            {
                /*  --- DEL 2008/10/23 �����ύX ------------------------------------------------------------------------------------------------------>>>>>
                // �Ώ۔N��
                //this.EditCondition(ref addConditions, string.Format("�Ώ۔N��" + ct_RangeConst,
                //                                                        this._salesRsltListCndtn.St_ThisMonth.ToString("yyyy�NMM��"),
                //                                                        this._salesRsltListCndtn.Ed_ThisMonth.ToString("yyyy�NMM��")));// DEL 2008/10/08
                this.EditCondition(ref addConditions, string.Format("�Ώ۔N��" + ct_RangeConst,
                                                                        this._salesRsltListCndtn.AddUpYearMonthSt.ToString("yyyy�NMM��"),
                                                                        this._salesRsltListCndtn.AddUpYearMonthEd.ToString("yyyy�NMM��")));// ADD 2008/10/08
                // --- DEL 2008/10/23 ----------------------------------------------------------------------------------------------------------------<<<<< */
                // --- ADD 2008/10/23 ---------------------------------------------------------------------------------------------------------------->>>>>
                this.EditCondition(ref addConditions, string.Format("�Ώ۔N��" + ct_RangeConst,
                                                                        this._salesRsltListCndtn.AddUpYearMonthSt.ToString("yyyy/MM"),
                                                                        this._salesRsltListCndtn.AddUpYearMonthEd.ToString("yyyy/MM")));
                // --- ADD 2008/10/23 ----------------------------------------------------------------------------------------------------------------<<<<<
            }
            else
            {
                /*  --- DEL 2008/10/23 �����ύX ------------------------------------------------------------------------------------------------------>>>>>
                // �Ώۊ���
                this.EditCondition(ref addConditions, string.Format("�Ώۊ���" + ct_RangeConst,
                                                                        this._salesRsltListCndtn.SalesDateSt.ToString("yyyy�NMM��dd��"),
                                                                        this._salesRsltListCndtn.SalesDateEd.ToString("yyyy�NMM��dd��")));// ADD 2008/10/08
                // --- DEL 2008/10/23 ----------------------------------------------------------------------------------------------------------------<<<<< */
                // --- ADD 2008/10/23 ---------------------------------------------------------------------------------------------------------------->>>>>
                this.EditCondition(ref addConditions, string.Format("�Ώۊ���" + ct_RangeConst,
                                                                        this._salesRsltListCndtn.SalesDateSt.ToString("yyyy/MM/dd"),
                                                                        this._salesRsltListCndtn.SalesDateEd.ToString("yyyy/MM/dd")));
                // --- ADD 2008/10/23 ----------------------------------------------------------------------------------------------------------------<<<<<
            }
            
            // �W�v���@
            //this.EditCondition(ref addConditions, string.Format("�W�v���@�F{0}", this._salesRsltListCndtn.GroupBySectionDivName)); // DEL 2008/10/08
            this.EditCondition(ref addConditions, string.Format("�W�v���@�F{0}", this._salesRsltListCndtn.TtlTypeName)); // ADD 2008/10/08

            // �o�א��w��
            //this.EditCondition( ref addConditions, string.Format( "�o�א��w��" + ct_RangeConst,
            //                                                        this._salesRsltListCndtn.St_ShipmentCnt,
            //                                                        this._salesRsltListCndtn.Ed_ShipmentCnt));// DEL 2008/10/08
            // --- ADD 2008/10/08 -------------------------------->>>>>

            //if (this._salesRsltListCndtn.PrintRangeSt != 0 || this._salesRsltListCndtn.PrintRangeEd != 999999999)     //DEL�@""��ALL9���͂̋�ʂ�����K�v�������
            // --- DEL 2009/02/12 -------------------------------->>>>>
            //// --- ADD 2008/10/23 -------------------------------------------------------------------------------->>>>>
            //if (this._salesRsltListCndtn.PrintRangeSt != 0 ||
            //    ((this._salesRsltListCndtn.PrintRangeEd != 0) &&
            //     (string.IsNullOrEmpty(this._salesRsltListCndtn.PrintRangeEd.ToString()) == false)))
            //// --- ADD 2008/10/23 --------------------------------------------------------------------------------<<<<<
            // --- DEL 2009/02/12 --------------------------------<<<<<
            // --- ADD 2009/02/12 -------------------------------->>>>>
            if (!this._salesRsltListCndtn.PrintRangeStNoInputFlg || !this._salesRsltListCndtn.PrintRangeEdNoInputFlg)
            // --- ADD 2009/02/12 --------------------------------<<<<<
            {
                stCode = ct_Extr_Top;
                edCode = ct_Extr_End;

                //if (this._salesRsltListCndtn.PrintRangeSt != 0) // DEL 2009/02/12
                if (!this._salesRsltListCndtn.PrintRangeStNoInputFlg) // ADD 2009/02/12
                {
                    //stCode = this._salesRsltListCndtn.PrintRangeSt.ToString("000000000");     //DEL 2008/10/23 �[���l�߂��Ȃ�
                    stCode = this._salesRsltListCndtn.PrintRangeSt.ToString();                  //ADD 2008/10/23
                }

                //if (this._salesRsltListCndtn.PrintRangeEd != 999999999)       //DEL�@""��ALL9���͂̋�ʂ�����K�v�������
                //if ((this._salesRsltListCndtn.PrintRangeEd != 0) && (string.IsNullOrEmpty(this._salesRsltListCndtn.PrintRangeEd.ToString()) == false)) // DEL 2009/02/12
                if (!this._salesRsltListCndtn.PrintRangeEdNoInputFlg) // ADD 2009/02/12
                {
                    //edCode = this._salesRsltListCndtn.PrintRangeEd.ToString("000000000");     //DEL 2008/10/23 �[���l�߂��Ȃ�
                    edCode = this._salesRsltListCndtn.PrintRangeEd.ToString();                  //ADD 2008/10/23
                }

                this.EditCondition(ref addConditions, 
                    string.Format("�o�א��w��" + ct_RangeConst + " " + this._salesRsltListCndtn.PrintRangeDivName, stCode, edCode));
            }
            // --- ADD 2008/10/08 --------------------------------<<<<<

            // ���z�P��
            this.EditCondition( ref addConditions, string.Format( "���z�P�ʁF{0}",
                                                                    this._salesRsltListCndtn.PriceUnitDivName ) );

            if (this._salesRsltListCndtn.TotalType != SalesRsltListCndtn.TotalTypeState.EachWareHouse)
            {
                // �݌Ɏ��w��
                //this.EditCondition( ref addConditions, string.Format( "�݌Ɏ��w��F{0}",
                //                                                        this._salesRsltListCndtn.StockOrderDivName ) ); // DEL 2008/10/08
                this.EditCondition(ref addConditions, string.Format("�݌Ɏ��w��F{0}",
                                                                        this._salesRsltListCndtn.RsltTtlDivCdName)); // ADD 2008/10/08
            }
            else
            {
                // �������
                this.EditCondition(ref addConditions, string.Format("��������F{0}",
                                                                        this._salesRsltListCndtn.AnnualPrintDivName)); // ADD 2008/10/08
            }

            // ���[�J�[�ʈ��
            this.EditCondition(ref addConditions, string.Format("���[�J�[�ʈ���F{0}",
                                                                    this._salesRsltListCndtn.MakerPrintDivName)); // ADD 2008/10/08
            // --- ADD 2008/10/08 -------------------------------->>>>>
            // ����
            if (this._salesRsltListCndtn.NewPageDiv != SalesRsltListCndtn.NewPageDivState.None)
            {
                this.EditCondition(ref addConditions, string.Format("���ŁF{0}",
                                                                this._salesRsltListCndtn.NewPageDivName));
            }
            // --- ADD 2014/12/16 ���� �����Y�ƗlSeiken�i�ԕύX-------------------------------->>>>>
            // ����(���i��)�����גP�ʂ��u�i�ԁv�̏ꍇ�A�i�ԏW�v�敪�ƕi�ԕ\���敪���󎚂��܂��B
            if (this._salesRsltListCndtn.TotalType == SalesRsltListCndtn.TotalTypeState.EachGoods
               && this._salesRsltListCndtn.DetailDataValue == SalesRsltListCndtn.DetailDataValueState.GoosNo)
            {
                this.EditCondition(ref addConditions, string.Format("�i�ԏW�v�敪�F{0}",
                                                               this._salesRsltListCndtn.GoodsNoSumDivName));
                // �i�ԏW�v�敪:���Z�̏ꍇ�A�i�ԕ\���敪���o�͂��܂��B
                if (this._salesRsltListCndtn.GoodsNoSumDiv == SalesRsltListCndtn.GoodsNoSumState.GoodsNoSum)
                {
                    this.EditCondition(ref addConditions, string.Format("�i�ԕ\���敪�F{0}",
                                                                    this._salesRsltListCndtn.GoodsNoDisDivName));
                }
            }
            // --- ADD 2014/12/16 ���� �����Y�ƗlSeiken�i�ԕύX--------------------------------<<<<<
            // ���s�^�C�v
            if (this._salesRsltListCndtn.TotalType == SalesRsltListCndtn.TotalTypeState.EachWareHouse)
            {
                this.EditCondition(ref addConditions, string.Format("���s�^�C�v�F{0}",
                                                                this._salesRsltListCndtn.PrintTypeName));
            }
            // --- ADD 2008/10/08 --------------------------------<<<<<

            //------------------------------------------------------------------------------------------------------------
            // --- ADD 2008/10/08 -------------------------------->>>>>
            /*  --- DEL 2008/10/23 �����͎��A�l�Ȃ��ɕύX�̈� --------------------------------------------------------------->>>>>
            // �q��
            if ((this._salesRsltListCndtn.WarehouseCodeSt != "0000") || (this._salesRsltListCndtn.WarehouseCodeEd != "9999"))
            {
                stCode = this._salesRsltListCndtn.WarehouseCodeSt.ToString();
                edCode = this._salesRsltListCndtn.WarehouseCodeEd.ToString();
                if (this._salesRsltListCndtn.WarehouseCodeSt == "0000") stCode = ct_Extr_Top;
                if (this._salesRsltListCndtn.WarehouseCodeEd == "9999") edCode = ct_Extr_End;

                this.EditCondition(ref addConditions, string.Format("�q��" + ct_RangeConst, stCode, edCode));
            }
               --- DEL 2008/10/23 -------------------------------------------------------------------------------------------<<<<< */
            // --- ADD 2008/10/23 ------------------------------------------------------------------------------------------->>>>>
            // �q��
            if ((string.IsNullOrEmpty(this._salesRsltListCndtn.WarehouseCodeSt) == false) ||
                (string.IsNullOrEmpty(this._salesRsltListCndtn.WarehouseCodeEd) == false))
            {
                stCode = this._salesRsltListCndtn.WarehouseCodeSt.ToString();
                edCode = this._salesRsltListCndtn.WarehouseCodeEd.ToString();
                if (string.IsNullOrEmpty(this._salesRsltListCndtn.WarehouseCodeSt)) stCode = ct_Extr_Top;
                if (string.IsNullOrEmpty(this._salesRsltListCndtn.WarehouseCodeEd)) edCode = ct_Extr_End;

                this.EditCondition(ref addConditions, string.Format("�q��" + ct_RangeConst, stCode, edCode));
            }
            // --- ADD 2008/10/23 -------------------------------------------------------------------------------------------<<<<<

            // ���Ӑ�
            /* --- DEL 2008/10/23 ""��ALL9���͂̋�ʂ�����K�v������� ------------------------------------------------>>>>>
            if ((this._salesRsltListCndtn.CustomerCodeSt != 0) ||
                (this._salesRsltListCndtn.CustomerCodeEd != 99999999))
               --- DEL 2008/10/23 ---------------------------------------------------------------------------------------<<<<< */
            // --- ADD 2008/10/23 --------------------------------------------------------------------------------------->>>>>
            if ((this._salesRsltListCndtn.CustomerCodeSt != 0) ||
                ((this._salesRsltListCndtn.CustomerCodeEd != 0) &&
                 (string.IsNullOrEmpty(this._salesRsltListCndtn.CustomerCodeEd.ToString()) == false)))
            // --- ADD 2008/10/23 ---------------------------------------------------------------------------------------<<<<<
            {
                stCode = this._salesRsltListCndtn.CustomerCodeSt.ToString("00000000");
                edCode = this._salesRsltListCndtn.CustomerCodeEd.ToString("00000000");
                if (this._salesRsltListCndtn.CustomerCodeSt == 0) stCode = ct_Extr_Top;
                //if (this._salesRsltListCndtn.CustomerCodeEd == 99999999) edCode = ct_Extr_End;        //DEL 2008/10/23 ""��ALL9���͂̋�ʂ�����K�v�������
                // --- ADD 2008/10/23 --------------------------------------------------------------------------------------->>>>>
                if ((this._salesRsltListCndtn.CustomerCodeEd == 0) ||
                    (string.IsNullOrEmpty(this._salesRsltListCndtn.CustomerCodeEd.ToString()) == true))
                {
                    edCode = ct_Extr_End;      
                }
                // --- ADD 2008/10/23 ---------------------------------------------------------------------------------------<<<<<

                this.EditCondition(ref addConditions, string.Format("���Ӑ�" + ct_RangeConst, stCode, edCode));
            }

            // ----ADD 2009/04/11 --------------------------------------------------------------------------------------->>>>>
            // �d����
            if ((this._salesRsltListCndtn.SupplierCodeSt != 0) ||
                ((this._salesRsltListCndtn.SupplierCodeEd != 0) &&
                 (string.IsNullOrEmpty(this._salesRsltListCndtn.SupplierCodeEd.ToString()) == false)))
            {
                stCode = this._salesRsltListCndtn.SupplierCodeSt.ToString("000000");
                edCode = this._salesRsltListCndtn.SupplierCodeEd.ToString("000000");
                if (this._salesRsltListCndtn.SupplierCodeSt == 0) stCode = ct_Extr_Top;
                if ((this._salesRsltListCndtn.SupplierCodeEd == 0) ||
                    (string.IsNullOrEmpty(this._salesRsltListCndtn.SupplierCodeEd.ToString()) == true))
                {
                    edCode = ct_Extr_End;
                }
                this.EditCondition(ref addConditions, string.Format("�d����" + ct_RangeConst, stCode, edCode));
            }
            // --- ADD 2009/04/11 ---------------------------------------------------------------------------------------<<<<<

            // �S����
            /* --- DEL 2008/10/23 ""��ALL9���͂̋�ʂ�����K�v������� ------------------------------------------------>>>>>
            if ((this._salesRsltListCndtn.EmployeeCodeSt.TrimEnd() != "0000") ||
                (this._salesRsltListCndtn.EmployeeCodeEd.TrimEnd() != "9999"))
               --- DEL 2008/10/23 ---------------------------------------------------------------------------------------<<<<< */
            // --- DEL 2009/02/10 -------------------------------->>>>>
            //// --- ADD 2008/10/23 --------------------------------------------------------------------------------------->>>>>
            //if ((this._salesRsltListCndtn.EmployeeCodeSt.TrimEnd() != "0000") ||
            //    ((this._salesRsltListCndtn.EmployeeCodeEd.TrimEnd() != "0000") &&
            //     (string.IsNullOrEmpty(this._salesRsltListCndtn.EmployeeCodeEd.TrimEnd()) == false)))
            //// --- ADD 2008/10/23 ---------------------------------------------------------------------------------------<<<<<
            // --- DEL 2009/02/10 --------------------------------<<<<<
            // --- ADD 2009/02/10 -------------------------------->>>>>
            if ((string.IsNullOrEmpty(this._salesRsltListCndtn.EmployeeCodeSt) == false) ||
                (string.IsNullOrEmpty(this._salesRsltListCndtn.EmployeeCodeEd) == false))
            // --- ADD 2009/02/10 --------------------------------<<<<<
            {
                stCode = this._salesRsltListCndtn.EmployeeCodeSt.TrimEnd();
                edCode = this._salesRsltListCndtn.EmployeeCodeEd.TrimEnd();
                if (this._salesRsltListCndtn.EmployeeCodeSt.TrimEnd() == "0000") stCode = ct_Extr_Top;
                //if (this._salesRsltListCndtn.EmployeeCodeEd.TrimEnd() == "9999") edCode = ct_Extr_End;        //DEL 2008/10/23 ""��ALL9���͂̋�ʂ�����K�v�������
                // --- ADD 2008/10/23 --------------------------------------------------------------------------------------->>>>>
                if ((this._salesRsltListCndtn.EmployeeCodeEd.TrimEnd() == "0000") ||
                    (string.IsNullOrEmpty(this._salesRsltListCndtn.EmployeeCodeEd.TrimEnd()) == true))
                {
                    edCode = ct_Extr_End;
                }
                // --- ADD 2008/10/23 ---------------------------------------------------------------------------------------<<<<<

                this.EditCondition(ref addConditions, string.Format("�S����" + ct_RangeConst, stCode, edCode));
            }

            // ���[�J�[
            /* --- DEL 2008/10/23 ""��ALL9���͂̋�ʂ�����K�v������� ------------------------------------------------>>>>>
            if ((this._salesRsltListCndtn.GoodsMakerCdSt != 0) ||
                (this._salesRsltListCndtn.GoodsMakerCdEd != 9999))
               --- DEL 2008/10/23 ---------------------------------------------------------------------------------------<<<<< */
            // --- ADD 2008/10/23 --------------------------------------------------------------------------------------->>>>>
            if ((this._salesRsltListCndtn.GoodsMakerCdSt != 0) ||
                ((this._salesRsltListCndtn.GoodsMakerCdEd != 0) &&
                (string.IsNullOrEmpty(this._salesRsltListCndtn.GoodsMakerCdEd.ToString()) == false)))
            // --- ADD 2008/10/23 ---------------------------------------------------------------------------------------<<<<<
            {
                stCode = this._salesRsltListCndtn.GoodsMakerCdSt.ToString("0000");
                edCode = this._salesRsltListCndtn.GoodsMakerCdEd.ToString("0000");
                if (this._salesRsltListCndtn.GoodsMakerCdSt == 0) stCode = ct_Extr_Top;
                //if (this._salesRsltListCndtn.GoodsMakerCdEd == 9999) edCode = ct_Extr_End;        //DEL 2008/10/23 ""��ALL9���͂̋�ʂ�����K�v�������
                // --- ADD 2008/10/23 --------------------------------------------------------------------------------------->>>>>
                if ((this._salesRsltListCndtn.GoodsMakerCdEd == 0) || (string.IsNullOrEmpty(this._salesRsltListCndtn.GoodsMakerCdEd.ToString()) == true))
                {
                    edCode = ct_Extr_End;
                }
                // --- ADD 2008/10/23 ---------------------------------------------------------------------------------------<<<<<

                this.EditCondition(ref addConditions, string.Format("���[�J�[" + ct_RangeConst, stCode, edCode));
            }

            // ���i�啪��
            /* --- DEL 2008/10/23 ""��ALL9���͂̋�ʂ�����K�v������� ------------------------------------------------>>>>>
            if ((this._salesRsltListCndtn.GoodsLGroupSt != 0) ||
                (this._salesRsltListCndtn.GoodsLGroupEd != 9999))
               --- DEL 2008/10/23 ---------------------------------------------------------------------------------------<<<<< */
            // --- ADD 2008/10/23 --------------------------------------------------------------------------------------->>>>>
            if ((this._salesRsltListCndtn.GoodsLGroupSt != 0) ||
                ((this._salesRsltListCndtn.GoodsLGroupEd != 0) &&
                 (string.IsNullOrEmpty(this._salesRsltListCndtn.GoodsLGroupEd.ToString()) == false)))
            // --- ADD 2008/10/23 ---------------------------------------------------------------------------------------<<<<<
            {
                stCode = this._salesRsltListCndtn.GoodsLGroupSt.ToString("0000");
                edCode = this._salesRsltListCndtn.GoodsLGroupEd.ToString("0000");
                if (this._salesRsltListCndtn.GoodsLGroupSt == 0) stCode = ct_Extr_Top;
                //if (this._salesRsltListCndtn.GoodsLGroupEd == 9999) edCode = ct_Extr_End;     //DEL 2008/10/23 ""��ALL9���͂̋�ʂ�����K�v�������
                // --- ADD 2008/10/23 --------------------------------------------------------------------------------------->>>>>
                if ((this._salesRsltListCndtn.GoodsLGroupEd == 0) || (string.IsNullOrEmpty(this._salesRsltListCndtn.GoodsLGroupEd.ToString()) == true))
                {
                    edCode = ct_Extr_End;
                }
                // --- ADD 2008/10/23 ---------------------------------------------------------------------------------------<<<<<

                this.EditCondition(ref addConditions, string.Format("���i�啪��" + ct_RangeConst, stCode, edCode));
            }

            // ���i������
            /* --- DEL 2008/10/23 ""��ALL9���͂̋�ʂ�����K�v������� ------------------------------------------------>>>>>
            if ((this._salesRsltListCndtn.GoodsMGroupSt != 0) ||
                (this._salesRsltListCndtn.GoodsMGroupEd != 9999))
               --- DEL 2008/10/23 ---------------------------------------------------------------------------------------<<<<< */
            // --- ADD 2008/10/23 --------------------------------------------------------------------------------------->>>>>
            if ((this._salesRsltListCndtn.GoodsMGroupSt != 0) ||
                ((this._salesRsltListCndtn.GoodsMGroupEd != 0) &&
                 (string.IsNullOrEmpty(this._salesRsltListCndtn.GoodsMGroupEd.ToString()) == false)))
            // --- ADD 2008/10/23 ---------------------------------------------------------------------------------------<<<<<
            {
                stCode = this._salesRsltListCndtn.GoodsMGroupSt.ToString("0000");
                edCode = this._salesRsltListCndtn.GoodsMGroupEd.ToString("0000");
                if (this._salesRsltListCndtn.GoodsMGroupSt == 0) stCode = ct_Extr_Top;
                //if (this._salesRsltListCndtn.GoodsMGroupEd == 9999) edCode = ct_Extr_End;     //DEL 2008/10/23 ""��ALL9���͂̋�ʂ�����K�v�������
                // --- ADD 2008/10/23 --------------------------------------------------------------------------------------->>>>>
                if ((this._salesRsltListCndtn.GoodsMGroupEd == 0) || (string.IsNullOrEmpty(this._salesRsltListCndtn.GoodsMGroupEd.ToString()) == true))
                {
                    edCode = ct_Extr_End;
                }
                // --- ADD 2008/10/23 ---------------------------------------------------------------------------------------<<<<<

                this.EditCondition(ref addConditions, string.Format("���i������" + ct_RangeConst, stCode, edCode));
            }

            // �O���[�v�R�[�h
            /* --- DEL 2008/10/23 ""��ALL9���͂̋�ʂ�����K�v������� ------------------------------------------------>>>>>
            if ((this._salesRsltListCndtn.BLGroupCodeSt != 0) ||
                (this._salesRsltListCndtn.BLGroupCodeEd != 99999))
               --- DEL 2008/10/23 ---------------------------------------------------------------------------------------<<<<< */
            // --- ADD 2008/10/23 --------------------------------------------------------------------------------------->>>>>
            if ((this._salesRsltListCndtn.BLGroupCodeSt != 0) ||
                ((this._salesRsltListCndtn.BLGroupCodeEd != 0) &&
                 (string.IsNullOrEmpty(this._salesRsltListCndtn.BLGroupCodeEd.ToString()) == false)))
            // --- ADD 2008/10/23 ---------------------------------------------------------------------------------------<<<<<
            {
                stCode = this._salesRsltListCndtn.BLGroupCodeSt.ToString("00000");
                edCode = this._salesRsltListCndtn.BLGroupCodeEd.ToString("00000");
                if (this._salesRsltListCndtn.BLGroupCodeSt == 0) stCode = ct_Extr_Top;
                //if (this._salesRsltListCndtn.BLGroupCodeEd == 99999) edCode = ct_Extr_End;        //DEL 2008/10/23 ""��ALL9���͂̋�ʂ�����K�v�������
                // --- ADD 2008/10/23 --------------------------------------------------------------------------------------->>>>>
                if ((this._salesRsltListCndtn.BLGroupCodeEd == 0) || (string.IsNullOrEmpty(this._salesRsltListCndtn.BLGroupCodeEd.ToString()) == true))
                {
                    edCode = ct_Extr_End;
                }
                // --- ADD 2008/10/23 ---------------------------------------------------------------------------------------<<<<<

                this.EditCondition(ref addConditions, string.Format("�O���[�v�R�[�h" + ct_RangeConst, stCode, edCode));
            }

            // �a�k�R�[�h
            /* --- DEL 2008/10/23 ""��ALL9���͂̋�ʂ�����K�v������� ------------------------------------------------>>>>>
            if ((this._salesRsltListCndtn.BLGoodsCodeSt != 0) ||
                (this._salesRsltListCndtn.BLGoodsCodeEd != 99999))
               --- DEL 2008/10/23 ---------------------------------------------------------------------------------------<<<<< */
            // --- ADD 2008/10/23 --------------------------------------------------------------------------------------->>>>>
            if ((this._salesRsltListCndtn.BLGoodsCodeSt != 0) ||
                ((this._salesRsltListCndtn.BLGoodsCodeEd != 0) &&
                 (string.IsNullOrEmpty(this._salesRsltListCndtn.BLGoodsCodeEd.ToString()) == false)))
            // --- ADD 2008/10/23 ---------------------------------------------------------------------------------------<<<<<
            {
                stCode = this._salesRsltListCndtn.BLGoodsCodeSt.ToString("00000");
                edCode = this._salesRsltListCndtn.BLGoodsCodeEd.ToString("00000");
                if (this._salesRsltListCndtn.BLGoodsCodeSt == 0) stCode = ct_Extr_Top;
                //if (this._salesRsltListCndtn.BLGoodsCodeEd == 99999) edCode = ct_Extr_End;        //DEL 2008/10/23 ""��ALL9���͂̋�ʂ�����K�v�������
                // --- ADD 2008/10/23 --------------------------------------------------------------------------------------->>>>>
                if ((this._salesRsltListCndtn.BLGoodsCodeEd == 0) || (string.IsNullOrEmpty(this._salesRsltListCndtn.BLGoodsCodeEd.ToString()) == true))
                {
                    edCode = ct_Extr_End;
                }
                // --- ADD 2008/10/23 ---------------------------------------------------------------------------------------<<<<<

                this.EditCondition(ref addConditions, string.Format("�a�k�R�[�h" + ct_RangeConst, stCode, edCode));
            }

            // �i��
            if ((this._salesRsltListCndtn.GoodsNoSt.TrimEnd() != string.Empty) ||
                (this._salesRsltListCndtn.GoodsNoEd.TrimEnd() != string.Empty))
            {
                stCode = this._salesRsltListCndtn.GoodsNoSt.TrimEnd();
                edCode = this._salesRsltListCndtn.GoodsNoEd.TrimEnd();
                if (this._salesRsltListCndtn.GoodsNoSt.TrimEnd() == string.Empty) stCode = ct_Extr_Top;
                if (this._salesRsltListCndtn.GoodsNoEd.TrimEnd() == string.Empty) edCode = ct_Extr_End;

                this.EditCondition(ref addConditions, string.Format("�i��" + ct_RangeConst, stCode, edCode));
            }
            // --- ADD 2008/10/08 --------------------------------<<<<<

            // --- DEL 2008/10/08 -------------------------------->>>>>
            //// ���Ӑ�
            //if ( ( this._salesRsltListCndtn.St_CustomerCode != 0 ) ||
            //    ( this._salesRsltListCndtn.Ed_CustomerCode != 999999999 ) )
            //{
            //    stCode = this._salesRsltListCndtn.St_CustomerCode.ToString();
            //    edCode = this._salesRsltListCndtn.Ed_CustomerCode.ToString();
            //    if ( this._salesRsltListCndtn.St_CustomerCode == 0 ) stCode = ct_Extr_Top;
            //    if ( this._salesRsltListCndtn.Ed_CustomerCode == 999999999 ) edCode = ct_Extr_End;

            //    this.EditCondition( ref addConditions, string.Format( "���Ӑ�" + ct_RangeConst, stCode, edCode ) );
            //}

            //// �S����
            //if ( ( this._salesRsltListCndtn.St_EmployeeCode.TrimEnd() != string.Empty ) ||
            //    ( this._salesRsltListCndtn.Ed_EmployeeCode.TrimEnd() != string.Empty ) )
            //{
            //    stCode = this._salesRsltListCndtn.St_EmployeeCode.TrimEnd();
            //    edCode = this._salesRsltListCndtn.Ed_EmployeeCode.TrimEnd();
            //    if ( this._salesRsltListCndtn.St_EmployeeCode.TrimEnd() == string.Empty ) stCode = ct_Extr_Top;
            //    if ( this._salesRsltListCndtn.Ed_EmployeeCode.TrimEnd() == string.Empty ) edCode = ct_Extr_End;

            //    this.EditCondition( ref addConditions, string.Format( "�S����" + ct_RangeConst, stCode, edCode ) );
            //}

            //// ���[�J�[
            //if ( ( this._salesRsltListCndtn.St_GoodsMakerCd != 0 ) ||
            //    ( this._salesRsltListCndtn.Ed_GoodsMakerCd != 999999 ) )
            //{
            //    stCode = this._salesRsltListCndtn.St_GoodsMakerCd.ToString();
            //    edCode = this._salesRsltListCndtn.Ed_GoodsMakerCd.ToString();
            //    if ( this._salesRsltListCndtn.St_GoodsMakerCd == 0 ) stCode = ct_Extr_Top;
            //    if ( this._salesRsltListCndtn.Ed_GoodsMakerCd == 999999 ) edCode = ct_Extr_End;

            //    this.EditCondition( ref addConditions, string.Format( "���[�J�[" + ct_RangeConst, stCode, edCode ) );
            //}

            //// ���i�敪�O���[�v
            //if ( ( this._salesRsltListCndtn.St_LargeGoodsGanreCode.TrimEnd() != string.Empty ) ||
            //    ( this._salesRsltListCndtn.Ed_LargeGoodsGanreCode.TrimEnd() != string.Empty ) )
            //{
            //    stCode = this._salesRsltListCndtn.St_LargeGoodsGanreCode.TrimEnd();
            //    edCode = this._salesRsltListCndtn.Ed_LargeGoodsGanreCode.TrimEnd();
            //    if ( this._salesRsltListCndtn.St_LargeGoodsGanreCode.TrimEnd() == string.Empty ) stCode = ct_Extr_Top;
            //    if ( this._salesRsltListCndtn.Ed_LargeGoodsGanreCode.TrimEnd() == string.Empty ) edCode = ct_Extr_End;

            //    this.EditCondition( ref addConditions, string.Format( "���i�敪�O���[�v" + ct_RangeConst, stCode, edCode ) );
            //}

            //// ���i�敪
            //if ( ( this._salesRsltListCndtn.St_MediumGoodsGanreCode.TrimEnd() != string.Empty ) ||
            //    ( this._salesRsltListCndtn.Ed_MediumGoodsGanreCode.TrimEnd() != string.Empty ) )
            //{
            //    stCode = this._salesRsltListCndtn.St_MediumGoodsGanreCode.TrimEnd();
            //    edCode = this._salesRsltListCndtn.Ed_MediumGoodsGanreCode.TrimEnd();
            //    if ( this._salesRsltListCndtn.St_MediumGoodsGanreCode.TrimEnd() == string.Empty ) stCode = ct_Extr_Top;
            //    if ( this._salesRsltListCndtn.Ed_MediumGoodsGanreCode.TrimEnd() == string.Empty ) edCode = ct_Extr_End;

            //    this.EditCondition( ref addConditions, string.Format( "���i�敪" + ct_RangeConst, stCode, edCode ) );
            //}

            //// ���i�敪�ڍ�
            //if ( ( this._salesRsltListCndtn.St_DetailGoodsGanreCode.TrimEnd() != string.Empty ) ||
            //    ( this._salesRsltListCndtn.Ed_DetailGoodsGanreCode.TrimEnd() != string.Empty ) )
            //{
            //    stCode = this._salesRsltListCndtn.St_DetailGoodsGanreCode.TrimEnd();
            //    edCode = this._salesRsltListCndtn.Ed_DetailGoodsGanreCode.TrimEnd();
            //    if ( this._salesRsltListCndtn.St_DetailGoodsGanreCode.TrimEnd() == string.Empty ) stCode = ct_Extr_Top;
            //    if ( this._salesRsltListCndtn.Ed_DetailGoodsGanreCode.TrimEnd() == string.Empty ) edCode = ct_Extr_End;

            //    this.EditCondition( ref addConditions, string.Format( "���i�敪�ڍ�" + ct_RangeConst, stCode, edCode ) );
            //}

            //// �a�k���i�R�[�h
            //if ( ( this._salesRsltListCndtn.St_BLGoodsCode != 0 ) ||
            //    ( this._salesRsltListCndtn.Ed_BLGoodsCode != 99999999 ) )
            //{
            //    stCode = this._salesRsltListCndtn.St_BLGoodsCode.ToString();
            //    edCode = this._salesRsltListCndtn.Ed_BLGoodsCode.ToString();
            //    if ( this._salesRsltListCndtn.St_BLGoodsCode == 0 ) stCode = ct_Extr_Top;
            //    if ( this._salesRsltListCndtn.Ed_BLGoodsCode == 99999999 ) edCode = ct_Extr_End;

            //    this.EditCondition( ref addConditions, string.Format( "�a�k���i�R�[�h" + ct_RangeConst, stCode, edCode ) );
            //}

            //// ���i�ԍ�
            //if ( ( this._salesRsltListCndtn.St_GoodsNo.TrimEnd() != string.Empty ) ||
            //    ( this._salesRsltListCndtn.Ed_GoodsNo.TrimEnd() != string.Empty ) )
            //{
            //    stCode = this._salesRsltListCndtn.St_GoodsNo.TrimEnd();
            //    edCode = this._salesRsltListCndtn.Ed_GoodsNo.TrimEnd();
            //    if ( this._salesRsltListCndtn.St_GoodsNo.TrimEnd() == string.Empty ) stCode = ct_Extr_Top;
            //    if ( this._salesRsltListCndtn.Ed_GoodsNo.TrimEnd() == string.Empty ) edCode = ct_Extr_End;

            //    this.EditCondition( ref addConditions, string.Format( "���i�ԍ�" + ct_RangeConst, stCode, edCode ) );
            //}
            // --- DEL 2008/10/08 --------------------------------<<<<<

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
        /// <br>Date       : 2007.11.26</br>
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
        /// <br>Date       : 2007.11.26</br>
        /// </remarks>
        private void EditCondition ( ref StringCollection editArea, string target )
        {
            bool isEdit = false;

            // �ҏW�Ώە����o�C�g���Z�o
            int targetByte = TStrConv.SizeCountSJIS( target );

            for ( int i = 0; i < editArea.Count; i++ )
            {
                int areaByte = 0;

                // �i�[�G���A�̃o�C�g���Z�o
                if ( editArea[i] != null )
                {
                    areaByte = TStrConv.SizeCountSJIS( editArea[i] );
                }

                if ( ( areaByte + targetByte + 2 ) <= 190 )
                {
                    isEdit = true;

                    // �S�p�X�y�[�X��}��
                    if ( editArea[i] != null ) editArea[i] += ct_Space;

                    editArea[i] += target;
                    break;
                }
            }
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
        /// <br>Date       : 2007.11.26</br>
        /// </remarks>
        private DialogResult MsgDispProc ( emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton )
        {
            return TMsgDisp.Show( iLevel, "MAZAI02032P", iMsg, iSt, iButton, iDefButton );
        }

        #endregion
        #endregion
    }
}

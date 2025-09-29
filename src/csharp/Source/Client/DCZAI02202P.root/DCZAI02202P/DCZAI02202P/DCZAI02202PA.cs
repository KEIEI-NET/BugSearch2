using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Controller.Util;    // ADD 2008/10/02 �s��Ή�[6047]
using Broadleaf.Application.UIData;
using Broadleaf.Drawing.Printing;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Drawing.Printing
{
    /// <summary>
    /// �݌Ɏ󕥊m�F�\����N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �݌Ɏ󕥊m�F�\�̈�����s���B</br>
    /// <br>Programmer : 22018 ��� ���b</br>
    /// <br>Date       : 2007.09.19</br>
    /// <br>UpdateNote : 2010/11/15 yangmj�@�@�\���ǂp�S</br>
    /// </remarks>
    class DCZAI02202PA : IPrintProc
    {
        #region �� Constructor
        /// <summary>
        /// �݌Ɏ󕥊m�F�\����N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �݌Ɏ󕥊m�F�\����N���X�̃C���X�^���X�̍쐬���s���B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.09.19</br>
        /// </remarks>
        public DCZAI02202PA ()
        {
        }

        /// <summary>
        /// �݌Ɏ󕥊m�F�\����N���X�R���X�g���N�^
        /// </summary>
        /// <param name="printInfo">������I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : �݌Ɏ󕥊m�F�\����N���X�̃C���X�^���X�̍쐬���s���B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2007.09.19</br>
        /// </remarks>
        public DCZAI02202PA ( object printInfo )
        {
            this._printInfo = printInfo as SFCMN06002C;
            this._stockAcPayListCndtn = this._printInfo.jyoken as StockAcPayListCndtn;
        }
        #endregion �� Constructor

        #region �� Pricate Const
        private const string ct_ReportForm_NameSpace = "Broadleaf.Drawing.Printing";
        private const string ct_Space = "�@";
        //--- DEL 2008/07/02 ---------->>>>>
        //private const string ct_Extr_Top = "�s�n�o";
        //private const string ct_Extr_End = "�d�m�c";
        //--- DEL 2008/07/02 ----------<<<<<
        //--- ADD 2008/07/02 ---------->>>>>
        private const string ct_Extr_Top = RangeUtil.FROM_BEGIN;    // MOD 2008/10/02 �s��Ή�[6047] "�ŏ�����"��RangeUtil.FROM_BEGIN
        private const string ct_Extr_End = RangeUtil.TO_END;        // MOD 2008/10/02 �s��Ή�[6047] "�Ō�܂�"��RangeUtil.TO_END
        //--- ADD 2008/07/02 ----------<<<<<
        private const string ct_RangeConst = "�F{0} �` {1}";
        #endregion �� Pricate Const

        #region �� Private Member
        private SFCMN06002C _printInfo;					// ������N���X
        private StockAcPayListCndtn _stockAcPayListCndtn;		// ���o�����N���X
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
                prtRpt.DataMember = DCZAI02204EA.ct_Tbl_StockAcPayList;

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
            StockAcPayListCndtn extraInfo = (StockAcPayListCndtn)this._printInfo.jyoken;

            // �\�[�g���v���p�e�B�ݒ�
            instance.PageHeaderSortOderTitle = "";

            // ���[�o�͐ݒ���擾 
            PrtOutSet prtOutSet;
            string message;
            int st = StockAcPayListAcs.ReadPrtOutSet( out prtOutSet, out message );
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
            object[] titleObj = new object[] { "�݌ɓ��o�Ɋm�F�\" };  // MOD 2008/09/25 �s��Ή�[5550] "�݌Ɏ󕥊m�F�\" ��"�݌ɓ��o�Ɋm�F�\"
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
        /// <br>UpdateNote : 2010/11/15 yangmj�@�@�\���ǂp�S</br>
        /// </remarks>
        private void MakeExtarCondition ( out StringCollection extraConditions )
        {
            // DEL 2008/10/02 �s��Ή�[6047]��
            //const string dateFormat = "yyyy�NMM��dd��";

            extraConditions = new StringCollection();
            StringCollection addConditions = new StringCollection();

            //-------------------------------------------------------------------------------------------------------------------
            // ���o�ד�
            string stDate = string.Empty;
            string edDate = string.Empty;

            // �J�n��I���̂����ꂩ�����͂���Ă���Έ�
            if ( ( this._stockAcPayListCndtn.St_IoGoodsDay != DateTime.MinValue ) || ( this._stockAcPayListCndtn.Ed_IoGoodsDay != DateTime.MinValue ) )
            {
                stDate = ct_Extr_Top;
                edDate = ct_Extr_End;
                // �J�n
                if ( this._stockAcPayListCndtn.St_IoGoodsDay != DateTime.MinValue )
                {
                    stDate = this._stockAcPayListCndtn.St_IoGoodsDay.ToString(RangeUtil.DATE_FORMAT);   // MOD 2008/10/08 �s��Ή�[6047] dateFormat��RangeUtil.DATE_FORMAT
                }
                // �I��
                if ( this._stockAcPayListCndtn.Ed_IoGoodsDay != DateTime.MinValue )
                {
                    edDate = this._stockAcPayListCndtn.Ed_IoGoodsDay.ToString(RangeUtil.DATE_FORMAT);   // MOD 2008/10/08 �s��Ή�[6047] dateFormat��RangeUtil.DATE_FORMAT
                }
                this.EditCondition( ref addConditions, string.Format( "���o�ד�" + ct_RangeConst, stDate, edDate ) );
            }

            // ---ADD 2010/11/15----->>>>>
            // �J�n��I���̂����ꂩ�����͂���Ă���Έ�
            if ((this._stockAcPayListCndtn.St_detInputDay != DateTime.MinValue))
            {
                stDate = ct_Extr_Top;
                edDate = ct_Extr_End;
                // �J�n

                stDate = this._stockAcPayListCndtn.St_detInputDay.ToString(RangeUtil.DATE_FORMAT);

                // �I��
                edDate = this._stockAcPayListCndtn.Ed_detInputDay.ToString(RangeUtil.DATE_FORMAT);
                this.EditCondition(ref addConditions, string.Format("���͓�" + ct_RangeConst, stDate, edDate));
            }
            // ---ADD 2010/11/15-----<<<<<
            //-------------------------------------------------------------------------------------------------------------------
            // �q��
            // DEL 2008/09/25 �s��Ή�[5556]---------->>>>>
            //if ( this._stockAcPayListCndtn.St_WarehouseCode.TrimEnd() != string.Empty
            //     || this._stockAcPayListCndtn.Ed_WarehouseCode.TrimEnd() != string.Empty )
            //{
            //    string stCode = this._stockAcPayListCndtn.St_WarehouseCode;
            //    string edCode = this._stockAcPayListCndtn.Ed_WarehouseCode;
            //    if ( stCode == string.Empty ) stCode = ct_Extr_Top;
            //    if ( edCode == string.Empty ) edCode = ct_Extr_End;

            //    this.EditCondition( ref addConditions, string.Format( "�q��" + ct_RangeConst, stCode, edCode ) );
            //}
            // DEL 2008/09/25 �s��Ή�[5556]----------<<<<<
            // ADD 2008/09/25 �s��Ή�[5556]---------->>>>>
            if (string.IsNullOrEmpty(this._stockAcPayListCndtn.Ed_WarehouseCode.Trim()))
            {
                this._stockAcPayListCndtn.Ed_WarehouseCode = (RangeUtil.WarehouseCode.MAX + 1).ToString();
            }
            if (!RangeUtil.WarehouseCode.IsAllRange(
                this._stockAcPayListCndtn.St_WarehouseCode.TrimEnd(),
                this._stockAcPayListCndtn.Ed_WarehouseCode.TrimEnd()
            ))
            {
                string start = RangeUtil.WarehouseCode.GetStartString(this._stockAcPayListCndtn.St_WarehouseCode.TrimEnd());
                string end = RangeUtil.WarehouseCode.GetEndString(this._stockAcPayListCndtn.Ed_WarehouseCode.TrimEnd());

                EditCondition(
                    ref addConditions,
                    string.Format("�q��" + ct_RangeConst, start, end)
                );
            }
            // ADD 2008/09/25 �s��Ή�[5556]----------<<<<<

            //----------------------------------------------------------------------------------------------------------------
            // ���[�J�[�R�[�h
            // DEL 2008/09/25 �s��Ή�[5556]---------->>>>>
            //if (this._stockAcPayListCndtn.St_GoodsMakerCd != 0 || this._stockAcPayListCndtn.Ed_GoodsMakerCd != 9999)    // MOD 2008/09/25 �s��Ή�[5556] 999999��9999
            //{
            //    // ADD 2008/09/25 �s��Ή�[5556] ---------->>>>>
            //    string stCode = this._stockAcPayListCndtn.St_GoodsMakerCd.ToString("0000");
            //    string edCode = this._stockAcPayListCndtn.Ed_GoodsMakerCd.ToString("0000");
            //    if (this._stockAcPayListCndtn.St_GoodsMakerCd <= 0)         stCode = ct_Extr_Top;
            //    if (this._stockAcPayListCndtn.Ed_GoodsMakerCd.Equals(9999)) edCode = ct_Extr_End;
            //    // ADD 2008/09/25 �s��Ή�[5556] ----------<<<<<
            //    // DEL 2008/09/25 �s��Ή�[5556]��
            //    //this.EditCondition( ref addConditions, string.Format( "���[�J�[" + ct_RangeConst, this._stockAcPayListCndtn.St_GoodsMakerCd, this._stockAcPayListCndtn.Ed_GoodsMakerCd ) );
            //    this.EditCondition(ref addConditions, string.Format("���[�J�[" + ct_RangeConst, stCode, edCode));   // ADD 2008/09/25 �s��Ή�[5556]
            //}
            // DEL 2008/09/25 �s��Ή�[5556]----------<<<<<
            // ADD 2008/09/25 �s��Ή�[5556]---------->>>>>
            if (!RangeUtil.GoodsMakerCode.IsAllRange(
                this._stockAcPayListCndtn.St_GoodsMakerCd,
                this._stockAcPayListCndtn.Ed_GoodsMakerCd
            ))
            {
                string start= RangeUtil.GoodsMakerCode.GetStartString(this._stockAcPayListCndtn.St_GoodsMakerCd);
                string end  = RangeUtil.GoodsMakerCode.GetEndString(this._stockAcPayListCndtn.Ed_GoodsMakerCd);

                EditCondition(
                    ref addConditions,
                    string.Format("���[�J�[" + ct_RangeConst, start, end)
                );
            }
            // ADD 2008/09/25 �s��Ή�[5556]----------<<<<<

            //-------------------------------------------------------------------------------------------------------------------
            // ���i�ԍ�
            if ( this._stockAcPayListCndtn.St_GoodsNo.TrimEnd() != string.Empty
                 || this._stockAcPayListCndtn.Ed_GoodsNo.TrimEnd() != string.Empty )
            {
                string stCode = this._stockAcPayListCndtn.St_GoodsNo;
                string edCode = this._stockAcPayListCndtn.Ed_GoodsNo;
                if ( stCode == string.Empty ) stCode = ct_Extr_Top;
                if ( edCode == string.Empty ) edCode = ct_Extr_End;
                //this.EditCondition(ref addConditions, string.Format("���i�ԍ�" + ct_RangeConst, stCode, edCode));     // DEL 2008.07.04
                this.EditCondition(ref addConditions, string.Format("�i��" + ct_RangeConst, stCode, edCode));       // ADD 2008.07.04
            }
            // ---ADD 2010/11/15----->>>>>
            // �`�[�ԍ�
            if (this._stockAcPayListCndtn.St_AcPaySlipNum.TrimEnd() != string.Empty
                 || this._stockAcPayListCndtn.Ed_AcPaySlipNum.TrimEnd() != string.Empty)
            {
                string stCode = this._stockAcPayListCndtn.St_AcPaySlipNum;
                string edCode = this._stockAcPayListCndtn.Ed_AcPaySlipNum;
                if (stCode == string.Empty) stCode = ct_Extr_Top;
                if (edCode == string.Empty) edCode = ct_Extr_End;
                this.EditCondition(ref addConditions, string.Format("�`�[�ԍ�" + ct_RangeConst, stCode, edCode));
            }

            // �`�[�敪
            string slipdiv = "";
            Dictionary<int, string> acPaySlipNmDic = CreateAcPaySlipNmDictionary();
            if (acPaySlipNmDic.ContainsKey(this._stockAcPayListCndtn.AcPaySlipCd))
            {
                slipdiv = acPaySlipNmDic[this._stockAcPayListCndtn.AcPaySlipCd];
            }
            this.EditCondition(ref addConditions, "�`�[�敪�F" + slipdiv);
  
            // ---ADD 2010/11/15-----<<<<<
            // �ǉ�
            foreach ( string exCondStr in addConditions )
            {
                extraConditions.Add( exCondStr );
            }
        }

        // ---ADD 2010/11/15----->>>>>
        /// <summary>
        /// �`�[�敪���̃f�B�N�V���i������
        /// </summary>
        /// <returns></returns>
        private Dictionary<int, string> CreateAcPaySlipNmDictionary()
        {
            Dictionary<int, string> dic = new Dictionary<int, string>();
            dic.Add(-1, "�S��");
            dic.Add(10, "�d��");
            dic.Add(11, "����");
            dic.Add(12, "��v��");
            dic.Add(13, "�݌Ɏd��"); 
            dic.Add(20, "����");
            dic.Add(21, "���v��");
            dic.Add(22, "�ݏo");
            dic.Add(23, "����");
            dic.Add(30, "�ړ��o��");
            dic.Add(31, "�ړ�����");
            dic.Add(40, "����");
            dic.Add(41, "����");
            dic.Add(42, "�}�X�^�����e");
            dic.Add(50, "�I��");
            dic.Add(60, "�g��");
            dic.Add(61, "����");
            dic.Add(70, "��[����");
            dic.Add(71, "��[�o��");

            return dic;
        }
        // ---ADD 2010/11/15-----<<<<<
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
        /// <br>Date       : 2007.09.19</br>
        /// </remarks>
        private DialogResult MsgDispProc ( emErrorLevel iLevel, string iMsg, int iSt, MessageBoxButtons iButton, MessageBoxDefaultButton iDefButton )
        {
            return TMsgDisp.Show( iLevel, "MAZAI02032P", iMsg, iSt, iButton, iDefButton );
        }

        #endregion
        #endregion
    }
}

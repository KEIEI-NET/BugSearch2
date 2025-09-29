using System;
using System.IO;
using System.Text;
using System.Data;
using System.Collections;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Collections.Generic;

using ar=DataDynamics.ActiveReports;
using DataDynamics.ActiveReports.Document;

using Broadleaf.Library.Resources;
//using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Drawing.Printing
{
	/// <summary>
	/// ���R���[(�݌Ɉړ��`�[)����N���X
	/// </summary>
	/// <remarks>
    /// <br>Note         : ���DataSource�̃e�[�u���������s���܂��B</br>
    /// <br>               </br>
	/// <br>Programmer   : 22018 ��؁@���b</br>
	/// <br>Date         : 2008.06.03</br>
	/// <br></br>
	/// <br>Update Note  : 2010/03/31  30531 ��� �r��</br>
    /// <br>             : Mantis�y14813�z�a���E����̈󎚐���̏C��</br>
    /// <br></br>
    /// <br>Update Note  : 2010/05/27  30531 ��� �r��</br>
    /// <br>             : �o�ɁA���Ƀ^�C�g���̈󎚓��e��ݒ�ł���悤�ɏC��</br>
    /// <br></br>
    /// <br>Update Note  : 2011/08/15 ����� �A��985</br>
    /// <br>             �@�yPM�v�]����9���z�M���zRedmine#23541 �A��985�̑Ή�</br> 
    /// <br></br>
    /// <br>Update Note  : 2011/09/27  22018 ��� ���b</br>
    /// <br>               ��x�̈���œ`�[��5����������s��̏C��</br>
    /// <br>Update Note  : 2017/08/30 3H �k�P�N</br>
    /// <br>�Ǘ��ԍ�     : 11370074-00 �n���f�B�Ή��i2���j</br>
    /// <br></br>
	/// </remarks>
	internal class PMZAI08001PB
    {
        # region [public static readonly �����o]
        /// <summary>���R���[�݌Ɉړ��`�[�e�[�u��</summary>
        public static readonly string ct_TBL_FREPSTOCKMOVESLIP = "FREPSTOCKMOVESLIP";
        /// <summary>����y�[�W���R�s�[�J�E���gcolumn����</summary>
        public static readonly string ct_InPageCopyCount = "PMZAI08001P.INPAGECOPYCOUNT";
        /// <summary>���ʃ^�C�g���P</summary>
        public static readonly string ct_InPageCopyTitle1 = "PMZAI08001P.INPAGECOPYTITLE1";
        /// <summary>���ʃ^�C�g���Q</summary>
        public static readonly string ct_InPageCopyTitle2 = "PMZAI08001P.INPAGECOPYTITLE2";
        /// <summary>���ʃ^�C�g���R</summary>
        public static readonly string ct_InPageCopyTitle3 = "PMZAI08001P.INPAGECOPYTITLE3";
        /// <summary>���ʃ^�C�g���S</summary>
        public static readonly string ct_InPageCopyTitle4 = "PMZAI08001P.INPAGECOPYTITLE4";
        /// <summary>�Ő�</summary>
        public static readonly string ct_PageCount = "PAGE.PAGECOUNTRF";
        /// <summary>�o�Ƀ^�C�g��</summary>
        public static readonly string ct_BfTitle = "LABEL.BFTITLERF";
        /// <summary>���Ƀ^�C�g��</summary>
        public static readonly string ct_AfTitle = "LABEL.AFTITLERF";

        // --- ADD ����� 2011/08/15---------->>>>>
        /// <summary>(Label)�T�u���|�[�g�p�`�[�^�C�g���P�E�P</summary>
        public static readonly string ct_SlipTitle11 = "PMZAI08001P.SLIPTITLE11";
        /// <summary>(Label)�T�u���|�[�g�p�`�[�^�C�g���P�E�Q</summary>
        public static readonly string ct_SlipTitle12 = "PMZAI08001P.SLIPTITLE12";
        /// <summary>(Label)�T�u���|�[�g�p�`�[�^�C�g���P�E�R</summary>
        public static readonly string ct_SlipTitle13 = "PMZAI08001P.SLIPTITLE13";
        /// <summary>(Label)�T�u���|�[�g�p�`�[�^�C�g���P�E�S</summary>
        public static readonly string ct_SlipTitle14 = "PMZAI08001P.SLIPTITLE14";
        /// <summary>(Label)�T�u���|�[�g�p�`�[�^�C�g���P�E�T</summary>
        public static readonly string ct_SlipTitle15 = "PMZAI08001P.SLIPTITLE15";
        /// <summary>(Label)�T�u���|�[�g�p�`�[�^�C�g���Q�E�P</summary>
        public static readonly string ct_SlipTitle21 = "PMZAI08001P.SLIPTITLE21";
        /// <summary>(Label)�T�u���|�[�g�p�`�[�^�C�g���Q�E�Q</summary>
        public static readonly string ct_SlipTitle22 = "PMZAI08001P.SLIPTITLE22";
        /// <summary>(Label)�T�u���|�[�g�p�`�[�^�C�g���Q�E�R</summary>
        public static readonly string ct_SlipTitle23 = "PMZAI08001P.SLIPTITLE23";
        /// <summary>(Label)�T�u���|�[�g�p�`�[�^�C�g���Q�E�S</summary>
        public static readonly string ct_SlipTitle24 = "PMZAI08001P.SLIPTITLE24";
        /// <summary>(Label)�T�u���|�[�g�p�`�[�^�C�g���Q�E�T</summary>
        public static readonly string ct_SlipTitle25 = "PMZAI08001P.SLIPTITLE25";
        /// <summary>(Label)�T�u���|�[�g�p�`�[�^�C�g���R�E�P</summary>
        public static readonly string ct_SlipTitle31 = "PMZAI08001P.SLIPTITLE31";
        /// <summary>(Label)�T�u���|�[�g�p�`�[�^�C�g���R�E�Q</summary>
        public static readonly string ct_SlipTitle32 = "PMZAI08001P.SLIPTITLE32";
        /// <summary>(Label)�T�u���|�[�g�p�`�[�^�C�g���R�E�R</summary>
        public static readonly string ct_SlipTitle33 = "PMZAI08001P.SLIPTITLE33";
        /// <summary>(Label)�T�u���|�[�g�p�`�[�^�C�g���R�E�S</summary>
        public static readonly string ct_SlipTitle34 = "PMZAI08001P.SLIPTITLE34";
        /// <summary>(Label)�T�u���|�[�g�p�`�[�^�C�g���R�E�T</summary>
        public static readonly string ct_SlipTitle35 = "PMZAI08001P.SLIPTITLE35";
        /// <summary>(Label)�T�u���|�[�g�p�`�[�^�C�g���S�E�P</summary>
        public static readonly string ct_SlipTitle41 = "PMZAI08001P.SLIPTITLE41";
        /// <summary>(Label)�T�u���|�[�g�p�`�[�^�C�g���S�E�Q</summary>
        public static readonly string ct_SlipTitle42 = "PMZAI08001P.SLIPTITLE42";
        /// <summary>(Label)�T�u���|�[�g�p�`�[�^�C�g���S�E�R</summary>
        public static readonly string ct_SlipTitle43 = "PMZAI08001P.SLIPTITLE43";
        /// <summary>(Label)�T�u���|�[�g�p�`�[�^�C�g���S�E�S</summary>
        public static readonly string ct_SlipTitle44 = "PMZAI08001P.SLIPTITLE44";
        /// <summary>(Label)�T�u���|�[�g�p�`�[�^�C�g���S�E�T</summary>
        public static readonly string ct_SlipTitle45 = "PMZAI08001P.SLIPTITLE45";
        // --- ADD ����� 2011/08/15----------<<<<<
        # endregion

        // --- ADD  ���r��  2010/03/31 ---------->>>>>
        #region [private static �����o]
        /// <summary>���|�[�g���ڃf�B�N�V���i��</summary>
        private static Dictionary<string, string> stc_reportItemDic;
        #endregion
        
        #region [public static �����o]
        /// <summary>���|�[�g���ڃf�B�N�V���i��</summary>
        public static Dictionary<string, string> ReportItemDic
        {
            get
            {
                if (stc_reportItemDic == null)
                {
                    stc_reportItemDic = new Dictionary<string, string>();
                }
                return stc_reportItemDic;
            }
            set { stc_reportItemDic = value; }
        }
        #endregion
        // --- ADD  ���r��  2010/03/31 ----------<<<<<

        # region [�f�[�^�e�[�u������]
        /// <summary>
        /// �f�[�^�e�[�u�����������i�X�L�[�}��`�j
        /// </summary>
        /// <remarks>
        /// <br>Update Note  : 2017/08/30 3H �k�P�N</br>
        /// <br>�Ǘ��ԍ�     : 11370074-00 �n���f�B�Ή��i2���j</br>
        /// </remarks>
        public static DataTable CreateFrePStockMoveSlipTable( int index)
        {
            DataTable table = new DataTable( ct_TBL_FREPSTOCKMOVESLIP + index.ToString() );
            
            # region [�X�L�[�}��`�i�`�[���ځj]
            table.Columns.Add( new DataColumn( "MOVH.STOCKMOVEFORMALRF", typeof( Int32 ) ) ); // �݌Ɉړ��`��
            table.Columns.Add( new DataColumn( "MOVH.STOCKMOVESLIPNORF", typeof( Int32 ) ) ); // �݌Ɉړ��`�[�ԍ�
            table.Columns.Add( new DataColumn( "MOVH.BFSECTIONCODERF", typeof( String ) ) ); // �ړ������_�R�[�h
            table.Columns.Add( new DataColumn( "MOVH.BFSECTIONGUIDESNMRF", typeof( String ) ) ); // �ړ������_�K�C�h����
            table.Columns.Add( new DataColumn( "MOVH.BFENTERWAREHCODERF", typeof( String ) ) ); // �ړ����q�ɃR�[�h
            table.Columns.Add( new DataColumn( "MOVH.BFENTERWAREHNAMERF", typeof( String ) ) ); // �ړ����q�ɖ���
            table.Columns.Add( new DataColumn( "MOVH.AFSECTIONCODERF", typeof( String ) ) ); // �ړ��拒�_�R�[�h
            table.Columns.Add( new DataColumn( "MOVH.AFSECTIONGUIDESNMRF", typeof( String ) ) ); // �ړ��拒�_�K�C�h����
            table.Columns.Add( new DataColumn( "MOVH.AFENTERWAREHCODERF", typeof( String ) ) ); // �ړ���q�ɃR�[�h
            table.Columns.Add( new DataColumn( "MOVH.AFENTERWAREHNAMERF", typeof( String ) ) ); // �ړ���q�ɖ���
            table.Columns.Add( new DataColumn( "MOVH.SHIPMENTSCDLDAYRF", typeof( Int32 ) ) ); // �o�ח\���
            table.Columns.Add( new DataColumn( "MOVH.INPUTDAYRF", typeof( Int32 ) ) ); // ���͓�
            table.Columns.Add( new DataColumn( "MOVH.STOCKMVEMPCODERF", typeof( String ) ) ); // �݌Ɉړ����͏]�ƈ��R�[�h
            table.Columns.Add( new DataColumn( "MOVH.STOCKMVEMPNAMERF", typeof( String ) ) ); // �݌Ɉړ����͏]�ƈ�����
            table.Columns.Add( new DataColumn( "MOVH.SHIPAGENTCDRF", typeof( String ) ) ); // �o�גS���]�ƈ��R�[�h
            table.Columns.Add( new DataColumn( "MOVH.SHIPAGENTNMRF", typeof( String ) ) ); // �o�גS���]�ƈ�����
            table.Columns.Add( new DataColumn( "MOVH.RECEIVEAGENTCDRF", typeof( String ) ) ); // ����S���]�ƈ��R�[�h
            table.Columns.Add( new DataColumn( "MOVH.RECEIVEAGENTNMRF", typeof( String ) ) ); // ����S���]�ƈ�����
            table.Columns.Add( new DataColumn( "MOVH.OUTLINERF", typeof( String ) ) ); // �`�[�E�v
            table.Columns.Add( new DataColumn( "MOVH.WAREHOUSENOTE1RF", typeof( String ) ) ); // �q�ɔ��l1
            table.Columns.Add( new DataColumn( "MOVH.SLIPPRINTFINISHCDRF", typeof( Int32 ) ) ); // �`�[���s�ϋ敪
            table.Columns.Add( new DataColumn( "SEC1.SECTIONGUIDENMRF", typeof( String ) ) ); // ���_�K�C�h����
            table.Columns.Add( new DataColumn( "SEC1.COMPANYNAMECD1RF", typeof( Int32 ) ) ); // ���Ж��̃R�[�h1
            table.Columns.Add( new DataColumn( "SEC2.SECTIONGUIDENMRF", typeof( String ) ) ); // ���_�K�C�h����
            table.Columns.Add( new DataColumn( "SEC2.COMPANYNAMECD1RF", typeof( Int32 ) ) ); // ���Ж��̃R�[�h1
            table.Columns.Add( new DataColumn( "COMPANYINFRF.COMPANYNAME1RF", typeof( String ) ) ); // ���Ж���1
            table.Columns.Add( new DataColumn( "COMPANYINFRF.COMPANYNAME2RF", typeof( String ) ) ); // ���Ж���2
            table.Columns.Add( new DataColumn( "COMPANYINFRF.POSTNORF", typeof( String ) ) ); // �X�֔ԍ�
            table.Columns.Add( new DataColumn( "COMPANYINFRF.ADDRESS1RF", typeof( String ) ) ); // �Z��1�i�s���{���s��S�E�����E���j
            table.Columns.Add( new DataColumn( "COMPANYINFRF.ADDRESS3RF", typeof( String ) ) ); // �Z��3�i�Ԓn�j
            table.Columns.Add( new DataColumn( "COMPANYINFRF.ADDRESS4RF", typeof( String ) ) ); // �Z��4�i�A�p�[�g���́j
            table.Columns.Add( new DataColumn( "COMPANYINFRF.COMPANYTELNO1RF", typeof( String ) ) ); // ���Гd�b�ԍ�1
            table.Columns.Add( new DataColumn( "COMPANYINFRF.COMPANYTELNO2RF", typeof( String ) ) ); // ���Гd�b�ԍ�2
            table.Columns.Add( new DataColumn( "COMPANYINFRF.COMPANYTELNO3RF", typeof( String ) ) ); // ���Гd�b�ԍ�3
            table.Columns.Add( new DataColumn( "COMPANYINFRF.COMPANYTELTITLE1RF", typeof( String ) ) ); // ���Гd�b�ԍ��^�C�g��1
            table.Columns.Add( new DataColumn( "COMPANYINFRF.COMPANYTELTITLE2RF", typeof( String ) ) ); // ���Гd�b�ԍ��^�C�g��2
            table.Columns.Add( new DataColumn( "COMPANYINFRF.COMPANYTELTITLE3RF", typeof( String ) ) ); // ���Гd�b�ԍ��^�C�g��3
            table.Columns.Add( new DataColumn( "CMP1.COMPANYPRRF", typeof( String ) ) ); // ����PR��
            table.Columns.Add( new DataColumn( "CMP1.COMPANYNAME1RF", typeof( String ) ) ); // ���Ж���1
            table.Columns.Add( new DataColumn( "CMP1.COMPANYNAME2RF", typeof( String ) ) ); // ���Ж���2
            table.Columns.Add( new DataColumn( "CMP1.POSTNORF", typeof( String ) ) ); // �X�֔ԍ�
            table.Columns.Add( new DataColumn( "CMP1.ADDRESS1RF", typeof( String ) ) ); // �Z��1�i�s���{���s��S�E�����E���j
            table.Columns.Add( new DataColumn( "CMP1.ADDRESS3RF", typeof( String ) ) ); // �Z��3�i�Ԓn�j
            table.Columns.Add( new DataColumn( "CMP1.ADDRESS4RF", typeof( String ) ) ); // �Z��4�i�A�p�[�g���́j
            table.Columns.Add( new DataColumn( "CMP1.COMPANYTELNO1RF", typeof( String ) ) ); // ���Гd�b�ԍ�1
            table.Columns.Add( new DataColumn( "CMP1.COMPANYTELNO2RF", typeof( String ) ) ); // ���Гd�b�ԍ�2
            table.Columns.Add( new DataColumn( "CMP1.COMPANYTELNO3RF", typeof( String ) ) ); // ���Гd�b�ԍ�3
            table.Columns.Add( new DataColumn( "CMP1.COMPANYTELTITLE1RF", typeof( String ) ) ); // ���Гd�b�ԍ��^�C�g��1
            table.Columns.Add( new DataColumn( "CMP1.COMPANYTELTITLE2RF", typeof( String ) ) ); // ���Гd�b�ԍ��^�C�g��2
            table.Columns.Add( new DataColumn( "CMP1.COMPANYTELTITLE3RF", typeof( String ) ) ); // ���Гd�b�ԍ��^�C�g��3
            table.Columns.Add( new DataColumn( "CMP1.TRANSFERGUIDANCERF", typeof( String ) ) ); // ��s�U���ē���
            table.Columns.Add( new DataColumn( "CMP1.ACCOUNTNOINFO1RF", typeof( String ) ) ); // ��s����1
            table.Columns.Add( new DataColumn( "CMP1.ACCOUNTNOINFO2RF", typeof( String ) ) ); // ��s����2
            table.Columns.Add( new DataColumn( "CMP1.ACCOUNTNOINFO3RF", typeof( String ) ) ); // ��s����3
            table.Columns.Add( new DataColumn( "CMP1.COMPANYSETNOTE1RF", typeof( String ) ) ); // ���Аݒ�E�v1
            table.Columns.Add( new DataColumn( "CMP1.COMPANYSETNOTE2RF", typeof( String ) ) ); // ���Аݒ�E�v2
            table.Columns.Add( new DataColumn( "CMP1.IMAGEINFODIVRF", typeof( Int32 ) ) ); // �摜���敪
            table.Columns.Add( new DataColumn( "CMP1.IMAGEINFOCODERF", typeof( Int32 ) ) ); // �摜���R�[�h
            table.Columns.Add( new DataColumn( "CMP1.COMPANYURLRF", typeof( String ) ) ); // ����URL
            table.Columns.Add( new DataColumn( "CMP1.COMPANYPRSENTENCE2RF", typeof( String ) ) ); // ����PR��2
            table.Columns.Add( new DataColumn( "CMP1.IMAGECOMMENTFORPRT1RF", typeof( String ) ) ); // �摜�󎚗p�R�����g1
            table.Columns.Add( new DataColumn( "CMP1.IMAGECOMMENTFORPRT2RF", typeof( String ) ) ); // �摜�󎚗p�R�����g2
            table.Columns.Add( new DataColumn( "CMP2.COMPANYPRRF", typeof( String ) ) ); // ����PR��
            table.Columns.Add( new DataColumn( "CMP2.COMPANYNAME1RF", typeof( String ) ) ); // ���Ж���1
            table.Columns.Add( new DataColumn( "CMP2.COMPANYNAME2RF", typeof( String ) ) ); // ���Ж���2
            table.Columns.Add( new DataColumn( "CMP2.POSTNORF", typeof( String ) ) ); // �X�֔ԍ�
            table.Columns.Add( new DataColumn( "CMP2.ADDRESS1RF", typeof( String ) ) ); // �Z��1�i�s���{���s��S�E�����E���j
            table.Columns.Add( new DataColumn( "CMP2.ADDRESS3RF", typeof( String ) ) ); // �Z��3�i�Ԓn�j
            table.Columns.Add( new DataColumn( "CMP2.ADDRESS4RF", typeof( String ) ) ); // �Z��4�i�A�p�[�g���́j
            table.Columns.Add( new DataColumn( "CMP2.COMPANYTELNO1RF", typeof( String ) ) ); // ���Гd�b�ԍ�1
            table.Columns.Add( new DataColumn( "CMP2.COMPANYTELNO2RF", typeof( String ) ) ); // ���Гd�b�ԍ�2
            table.Columns.Add( new DataColumn( "CMP2.COMPANYTELNO3RF", typeof( String ) ) ); // ���Гd�b�ԍ�3
            table.Columns.Add( new DataColumn( "CMP2.COMPANYTELTITLE1RF", typeof( String ) ) ); // ���Гd�b�ԍ��^�C�g��1
            table.Columns.Add( new DataColumn( "CMP2.COMPANYTELTITLE2RF", typeof( String ) ) ); // ���Гd�b�ԍ��^�C�g��2
            table.Columns.Add( new DataColumn( "CMP2.COMPANYTELTITLE3RF", typeof( String ) ) ); // ���Гd�b�ԍ��^�C�g��3
            table.Columns.Add( new DataColumn( "CMP2.TRANSFERGUIDANCERF", typeof( String ) ) ); // ��s�U���ē���
            table.Columns.Add( new DataColumn( "CMP2.ACCOUNTNOINFO1RF", typeof( String ) ) ); // ��s����1
            table.Columns.Add( new DataColumn( "CMP2.ACCOUNTNOINFO2RF", typeof( String ) ) ); // ��s����2
            table.Columns.Add( new DataColumn( "CMP2.ACCOUNTNOINFO3RF", typeof( String ) ) ); // ��s����3
            table.Columns.Add( new DataColumn( "CMP2.COMPANYSETNOTE1RF", typeof( String ) ) ); // ���Аݒ�E�v1
            table.Columns.Add( new DataColumn( "CMP2.COMPANYSETNOTE2RF", typeof( String ) ) ); // ���Аݒ�E�v2
            table.Columns.Add( new DataColumn( "CMP2.COMPANYURLRF", typeof( String ) ) ); // ����URL
            table.Columns.Add( new DataColumn( "CMP2.COMPANYPRSENTENCE2RF", typeof( String ) ) ); // ����PR��2
            table.Columns.Add( new DataColumn( "CMP2.IMAGECOMMENTFORPRT1RF", typeof( String ) ) ); // �摜�󎚗p�R�����g1
            table.Columns.Add( new DataColumn( "CMP2.IMAGECOMMENTFORPRT2RF", typeof( String ) ) ); // �摜�󎚗p�R�����g2
            table.Columns.Add( new DataColumn( "EMP1.KANARF", typeof( String ) ) ); // �J�i
            table.Columns.Add( new DataColumn( "EMP1.SHORTNAMERF", typeof( String ) ) ); // �Z�k����
            table.Columns.Add( new DataColumn( "EMP2.KANARF", typeof( String ) ) ); // �J�i
            table.Columns.Add( new DataColumn( "EMP2.SHORTNAMERF", typeof( String ) ) ); // �Z�k����
            table.Columns.Add( new DataColumn( "EMP3.KANARF", typeof( String ) ) ); // �J�i
            table.Columns.Add( new DataColumn( "EMP3.SHORTNAMERF", typeof( String ) ) ); // �Z�k����
            table.Columns.Add( new DataColumn( "IMAGEINFORF.IMAGEINFODATARF", typeof( Byte[] ) ) ); // �摜���f�[�^
            table.Columns.Add( new DataColumn( "HADD.STOCKMOVEFORMALNMRF", typeof( String ) ) ); // �݌Ɉړ��`������
            table.Columns.Add( new DataColumn( "HADD.SHIPMENTSCDLDFYRF", typeof( Int32 ) ) ); // �o�ח\�������N
            table.Columns.Add( new DataColumn( "HADD.SHIPMENTSCDLDFSRF", typeof( Int32 ) ) ); // �o�ח\�������N��
            table.Columns.Add( new DataColumn( "HADD.SHIPMENTSCDLDFWRF", typeof( Int32 ) ) ); // �o�ח\����a��N
            table.Columns.Add( new DataColumn( "HADD.SHIPMENTSCDLDFMRF", typeof( Int32 ) ) ); // �o�ח\�����
            table.Columns.Add( new DataColumn( "HADD.SHIPMENTSCDLDFDRF", typeof( Int32 ) ) ); // �o�ח\�����
            table.Columns.Add( new DataColumn( "HADD.SHIPMENTSCDLDFGRF", typeof( String ) ) ); // �o�ח\�������
            table.Columns.Add( new DataColumn( "HADD.SHIPMENTSCDLDFRRF", typeof( String ) ) ); // �o�ח\�������
            table.Columns.Add( new DataColumn( "HADD.SHIPMENTSCDLDFLSRF", typeof( String ) ) ); // �o�ח\������e����(/)
            table.Columns.Add( new DataColumn( "HADD.SHIPMENTSCDLDFLPRF", typeof( String ) ) ); // �o�ח\������e����(.)
            table.Columns.Add( new DataColumn( "HADD.SHIPMENTSCDLDFLYRF", typeof( String ) ) ); // �o�ח\������e����(�N)
            table.Columns.Add( new DataColumn( "HADD.SHIPMENTSCDLDFLMRF", typeof( String ) ) ); // �o�ח\������e����(��)
            table.Columns.Add( new DataColumn( "HADD.SHIPMENTSCDLDFLDRF", typeof( String ) ) ); // �o�ח\������e����(��)
            table.Columns.Add( new DataColumn( "HADD.INPUTDFYRF", typeof( Int32 ) ) ); // ���͓�����N
            table.Columns.Add( new DataColumn( "HADD.INPUTDFSRF", typeof( Int32 ) ) ); // ���͓�����N��
            table.Columns.Add( new DataColumn( "HADD.INPUTDFWRF", typeof( Int32 ) ) ); // ���͓��a��N
            table.Columns.Add( new DataColumn( "HADD.INPUTDFMRF", typeof( Int32 ) ) ); // ���͓���
            table.Columns.Add( new DataColumn( "HADD.INPUTDFDRF", typeof( Int32 ) ) ); // ���͓���
            table.Columns.Add( new DataColumn( "HADD.INPUTDFGRF", typeof( String ) ) ); // ���͓�����
            table.Columns.Add( new DataColumn( "HADD.INPUTDFRRF", typeof( String ) ) ); // ���͓�����
            table.Columns.Add( new DataColumn( "HADD.INPUTDFLSRF", typeof( String ) ) ); // ���͓����e����(/)
            table.Columns.Add( new DataColumn( "HADD.INPUTDFLPRF", typeof( String ) ) ); // ���͓����e����(.)
            table.Columns.Add( new DataColumn( "HADD.INPUTDFLYRF", typeof( String ) ) ); // ���͓����e����(�N)
            table.Columns.Add( new DataColumn( "HADD.INPUTDFLMRF", typeof( String ) ) ); // ���͓����e����(��)
            table.Columns.Add( new DataColumn( "HADD.INPUTDFLDRF", typeof( String ) ) ); // ���͓����e����(��)
            table.Columns.Add( new DataColumn( "HADD.NOTE1RF", typeof( String ) ) ); // ���Д��l�P
            table.Columns.Add( new DataColumn( "HADD.NOTE2RF", typeof( String ) ) ); // ���Д��l�Q
            table.Columns.Add( new DataColumn( "HADD.NOTE3RF", typeof( String ) ) ); // ���Д��l�R
            table.Columns.Add( new DataColumn( "HADD.REISSUEMARKRF", typeof( String ) ) ); // �Ĕ��s�}�[�N
            table.Columns.Add( new DataColumn( "HADD.PRINTERMNGNORF", typeof( Int32 ) ) ); // �v�����^�Ǘ�No
            table.Columns.Add( new DataColumn( "HADD.SLIPPRTSETPAPERIDRF", typeof( String ) ) ); // �`�[����ݒ�p���[ID
            table.Columns.Add( new DataColumn( "HADD.PRINTTIMEHOURRF", typeof( Int32 ) ) ); // �������HH
            table.Columns.Add( new DataColumn( "HADD.PRINTTIMEMINUTERF", typeof( Int32 ) ) ); // �������MM
            table.Columns.Add( new DataColumn( "HADD.PRINTTIMESECONDRF", typeof( Int32 ) ) ); // �������SS
            table.Columns.Add( new DataColumn( "HADD.TTLSTOCKMOVEPRICERF", typeof( Int64 ) ) ); // �`�[���v���z
            table.Columns.Add( new DataColumn( "HADD.TTLSTOCKMOVELISTPRICERF", typeof( Int64 ) ) ); // �`�[���v���z(�W�����i)
            table.Columns.Add( new DataColumn( "HADD.PRINTENTERPRISENAME1FHRF", typeof( String ) ) ); // ���Ж��P�i�O���j
            table.Columns.Add( new DataColumn( "HADD.PRINTENTERPRISENAME1LHRF", typeof( String ) ) ); // ���Ж��P�i�㔼�j
            table.Columns.Add( new DataColumn( "HADD.PRINTENTERPRISENAME2FHRF", typeof( String ) ) ); // ���Ж��Q�i�O���j
            table.Columns.Add( new DataColumn( "HADD.PRINTENTERPRISENAME2LHRF", typeof( String ) ) ); // ���Ж��Q�i�㔼�j
            table.Columns.Add( new DataColumn( "MOVH.UPDATESECCDRF", typeof( String ) ) ); // ���͋��_�R�[�h
            table.Columns.Add( new DataColumn( "SEC0.SECTIONGUIDESNMRF", typeof( String ) ) ); // ���͋��_�K�C�h����
            table.Columns.Add( new DataColumn( "SEC0.SECTIONGUIDENMRF", typeof( String ) ) ); // ���͋��_�K�C�h����

            // --- ADD ����� 2011/08/15---------->>>>>
            table.Columns.Add(new DataColumn(ct_SlipTitle11, typeof(string))); //�^�C�g���P�E�P
            table.Columns.Add(new DataColumn(ct_SlipTitle12, typeof(string))); //�^�C�g���P�E�Q
            table.Columns.Add(new DataColumn(ct_SlipTitle13, typeof(string))); //�^�C�g���P�E�R
            table.Columns.Add(new DataColumn(ct_SlipTitle14, typeof(string))); //�^�C�g���P�E�S
            table.Columns.Add(new DataColumn(ct_SlipTitle15, typeof(string))); //�^�C�g���P�E�T

            table.Columns.Add(new DataColumn(ct_SlipTitle21, typeof(string))); //�^�C�g���Q�E�P
            table.Columns.Add(new DataColumn(ct_SlipTitle22, typeof(string))); //�^�C�g���Q�E�Q
            table.Columns.Add(new DataColumn(ct_SlipTitle23, typeof(string))); //�^�C�g���Q�E�R
            table.Columns.Add(new DataColumn(ct_SlipTitle24, typeof(string))); //�^�C�g���Q�E�S
            table.Columns.Add(new DataColumn(ct_SlipTitle25, typeof(string))); //�^�C�g���Q�E�T

            table.Columns.Add(new DataColumn(ct_SlipTitle31, typeof(string))); //�^�C�g���R�E�P
            table.Columns.Add(new DataColumn(ct_SlipTitle32, typeof(string))); //�^�C�g���R�E�Q
            table.Columns.Add(new DataColumn(ct_SlipTitle33, typeof(string))); //�^�C�g���R�E�R
            table.Columns.Add(new DataColumn(ct_SlipTitle34, typeof(string))); //�^�C�g���R�E�S
            table.Columns.Add(new DataColumn(ct_SlipTitle35, typeof(string))); //�^�C�g���R�E�T

            table.Columns.Add(new DataColumn(ct_SlipTitle41, typeof(string))); //�^�C�g���S�E�P
            table.Columns.Add(new DataColumn(ct_SlipTitle42, typeof(string))); //�^�C�g���S�E�Q
            table.Columns.Add(new DataColumn(ct_SlipTitle43, typeof(string))); //�^�C�g���S�E�R
            table.Columns.Add(new DataColumn(ct_SlipTitle44, typeof(string))); //�^�C�g���S�E�S
            table.Columns.Add(new DataColumn(ct_SlipTitle45, typeof(string))); //�^�C�g���S�E�T
            // --- ADD ����� 2011/08/15----------<<<<<
            # endregion

            # region [�X�L�[�}��`�i���׍��ځj]
            table.Columns.Add( new DataColumn( "MOVD.STOCKMOVEFORMALRF", typeof( Int32 ) ) ); // �݌Ɉړ��`��
            table.Columns.Add( new DataColumn( "MOVD.STOCKMOVESLIPNORF", typeof( Int32 ) ) ); // �݌Ɉړ��`�[�ԍ�
            table.Columns.Add( new DataColumn( "MOVD.STOCKMOVEROWNORF", typeof( Int32 ) ) ); // �݌Ɉړ��s�ԍ�
            table.Columns.Add( new DataColumn( "MOVD.BFSECTIONCODERF", typeof( String ) ) ); // �ړ������_�R�[�h
            table.Columns.Add( new DataColumn( "MOVD.BFENTERWAREHCODERF", typeof( String ) ) ); // �ړ����q�ɃR�[�h
            table.Columns.Add( new DataColumn( "MOVD.AFSECTIONCODERF", typeof( String ) ) ); // �ړ��拒�_�R�[�h
            table.Columns.Add( new DataColumn( "MOVD.AFENTERWAREHCODERF", typeof( String ) ) ); // �ړ���q�ɃR�[�h
            table.Columns.Add( new DataColumn( "MOVD.SUPPLIERCDRF", typeof( Int32 ) ) ); // �d����R�[�h
            table.Columns.Add( new DataColumn( "MOVD.SUPPLIERSNMRF", typeof( String ) ) ); // �d���旪��
            table.Columns.Add( new DataColumn( "MOVD.GOODSMAKERCDRF", typeof( Int32 ) ) ); // ���i���[�J�[�R�[�h
            table.Columns.Add( new DataColumn( "MOVD.MAKERNAMERF", typeof( String ) ) ); // ���[�J�[����
            table.Columns.Add( new DataColumn( "MOVD.GOODSNORF", typeof( String ) ) ); // ���i�ԍ�
            table.Columns.Add( new DataColumn( "MOVD.GOODSNAMERF", typeof( String ) ) ); // ���i����
            table.Columns.Add( new DataColumn( "MOVD.GOODSNAMEKANARF", typeof( String ) ) ); // ���i���̃J�i
            table.Columns.Add( new DataColumn( "MOVD.STOCKDIVRF", typeof( Int32 ) ) ); // �݌ɋ敪
            table.Columns.Add( new DataColumn( "MOVD.STOCKUNITPRICEFLRF", typeof( Double ) ) ); // �d���P���i�Ŕ�,�����j
            table.Columns.Add( new DataColumn( "MOVD.TAXATIONDIVCDRF", typeof( Int32 ) ) ); // �ېŋ敪
            table.Columns.Add( new DataColumn( "MOVD.MOVECOUNTRF", typeof( Double ) ) ); // �ړ���
            table.Columns.Add( new DataColumn( "MOVD.BFSHELFNORF", typeof( String ) ) ); // �ړ����I��
            table.Columns.Add( new DataColumn( "MOVD.AFSHELFNORF", typeof( String ) ) ); // �ړ���I��
            table.Columns.Add( new DataColumn( "MOVD.BLGOODSCODERF", typeof( Int32 ) ) ); // BL���i�R�[�h
            table.Columns.Add( new DataColumn( "MOVD.BLGOODSFULLNAMERF", typeof( String ) ) ); // BL���i�R�[�h���́i�S�p�j
            table.Columns.Add( new DataColumn( "MOVD.LISTPRICEFLRF", typeof( Double ) ) ); // �艿�i�����j
            table.Columns.Add( new DataColumn( "MOVD.MOVESTATUSRF", typeof( Int32 ) ) ); // �ړ����
            table.Columns.Add( new DataColumn( "BLGOODSCDURF.BLGOODSHALFNAMERF", typeof( String ) ) ); // BL���i�R�[�h���́i���p�j
            table.Columns.Add( new DataColumn( "MAKERURF.MAKERSHORTNAMERF", typeof( String ) ) ); // ���[�J�[����
            table.Columns.Add( new DataColumn( "MAKERURF.MAKERKANANAMERF", typeof( String ) ) ); // ���[�J�[�J�i����
            table.Columns.Add( new DataColumn( "STC1.DUPLICATIONSHELFNO1RF", typeof( String ) ) ); // �d���I�ԂP
            table.Columns.Add( new DataColumn( "STC1.DUPLICATIONSHELFNO2RF", typeof( String ) ) ); // �d���I�ԂQ
            table.Columns.Add( new DataColumn( "STC1.PARTSMANAGEMENTDIVIDE1RF", typeof( String ) ) ); // ���i�Ǘ��敪�P
            table.Columns.Add( new DataColumn( "STC1.PARTSMANAGEMENTDIVIDE2RF", typeof( String ) ) ); // ���i�Ǘ��敪�Q
            table.Columns.Add( new DataColumn( "STC1.STOCKNOTE1RF", typeof( String ) ) ); // �݌ɔ��l�P
            table.Columns.Add( new DataColumn( "STC1.STOCKNOTE2RF", typeof( String ) ) ); // �݌ɔ��l�Q
            table.Columns.Add( new DataColumn( "STC1.SHIPMENTPOSCNTRF", typeof( Double ) ) ); // �o�׉\��
            table.Columns.Add( new DataColumn( "STC2.DUPLICATIONSHELFNO1RF", typeof( String ) ) ); // �d���I�ԂP
            table.Columns.Add( new DataColumn( "STC2.DUPLICATIONSHELFNO2RF", typeof( String ) ) ); // �d���I�ԂQ
            table.Columns.Add( new DataColumn( "STC2.PARTSMANAGEMENTDIVIDE1RF", typeof( String ) ) ); // ���i�Ǘ��敪�P
            table.Columns.Add( new DataColumn( "STC2.PARTSMANAGEMENTDIVIDE2RF", typeof( String ) ) ); // ���i�Ǘ��敪�Q
            table.Columns.Add( new DataColumn( "STC2.STOCKNOTE1RF", typeof( String ) ) ); // �݌ɔ��l�P
            table.Columns.Add( new DataColumn( "STC2.STOCKNOTE2RF", typeof( String ) ) ); // �݌ɔ��l�Q
            table.Columns.Add( new DataColumn( "STC2.SHIPMENTPOSCNTRF", typeof( Double ) ) ); // �o�׉\��
            table.Columns.Add( new DataColumn( "SUP.SUPPLIERNM1RF", typeof( String ) ) ); // �d���於1
            table.Columns.Add( new DataColumn( "SUP.SUPPLIERNM2RF", typeof( String ) ) ); // �d���於2
            table.Columns.Add( new DataColumn( "SUP.SUPPHONORIFICTITLERF", typeof( String ) ) ); // �d����h��
            table.Columns.Add( new DataColumn( "SUP.SUPPLIERKANARF", typeof( String ) ) ); // �d����J�i
            table.Columns.Add( new DataColumn( "SUP.PURECODERF", typeof( Int32 ) ) ); // �����敪
            table.Columns.Add( new DataColumn( "SUP.SUPPLIERNOTE1RF", typeof( String ) ) ); // �d������l1
            table.Columns.Add( new DataColumn( "SUP.SUPPLIERNOTE2RF", typeof( String ) ) ); // �d������l2
            table.Columns.Add( new DataColumn( "SUP.SUPPLIERNOTE3RF", typeof( String ) ) ); // �d������l3
            table.Columns.Add( new DataColumn( "SUP.SUPPLIERNOTE4RF", typeof( String ) ) ); // �d������l4
            table.Columns.Add( new DataColumn( "GDS.GOODSNAMEKANARF", typeof( String ) ) ); // ���i���̃J�i
            table.Columns.Add( new DataColumn( "GDS.JANRF", typeof( String ) ) ); // JAN�R�[�h
            table.Columns.Add( new DataColumn( "GDS.GOODSRATERANKRF", typeof( String ) ) ); // ���i�|�������N
            table.Columns.Add( new DataColumn( "GDS.GOODSNONONEHYPHENRF", typeof( String ) ) ); // �n�C�t�������i�ԍ�
            table.Columns.Add( new DataColumn( "GDS.GOODSNOTE1RF", typeof( String ) ) ); // ���i���l�P
            table.Columns.Add( new DataColumn( "GDS.GOODSNOTE2RF", typeof( String ) ) ); // ���i���l�Q
            table.Columns.Add( new DataColumn( "GDS.GOODSSPECIALNOTERF", typeof( String ) ) ); // ���i�K�i�E���L����
            table.Columns.Add( new DataColumn( "DADD.STOCKDIVNMRF", typeof( String ) ) ); // �݌ɋ敪����
            table.Columns.Add( new DataColumn( "DADD.TAXATIONDIVCDNMRF", typeof( String ) ) ); // �ېŋ敪����
            table.Columns.Add( new DataColumn( "DADD.PURECODENMRF", typeof( String ) ) ); // �����敪����
            table.Columns.Add( new DataColumn( "DADD.STOCKMOVEPRICERF", typeof( Int64 ) ) ); // �ړ����z
            table.Columns.Add( new DataColumn( "DADD.STOCKMOVELISTPRICERF", typeof( Int64 ) ) ); // �ړ����z(�W�����i)
            table.Columns.Add( new DataColumn( "DADD.BFSTOCKCOUNTPREVRF", typeof( Double ) ) ); // �ړ����ړ��O��
            table.Columns.Add( new DataColumn( "DADD.BFSTOCKCOUNTRF", typeof( Double ) ) ); // �ړ����ړ��㐔
            table.Columns.Add( new DataColumn( "DADD.AFSTOCKCOUNTPREVRF", typeof( Double ) ) ); // �ړ���ړ��O��
            table.Columns.Add( new DataColumn( "DADD.AFSTOCKCOUNTRF", typeof( Double ) ) ); // �ړ���ړ��㐔
            table.Columns.Add( new DataColumn( "MOVD.STOCKMOVEPRICERF", typeof( Int64 ) ) ); // �ړ����z
            # endregion

            # region [���䍀��]
            table.Columns.Add( new DataColumn( ct_InPageCopyTitle1, typeof( string ) ) );  // ���ʃ^�C�g��
            table.Columns.Add( new DataColumn( ct_InPageCopyTitle2, typeof( string ) ) );  // ���ʃ^�C�g��
            table.Columns.Add( new DataColumn( ct_InPageCopyTitle3, typeof( string ) ) );  // ���ʃ^�C�g��
            table.Columns.Add( new DataColumn( ct_InPageCopyTitle4, typeof( string ) ) );  // ���ʃ^�C�g��
            table.Columns.Add( new DataColumn( ct_InPageCopyCount, typeof( int ) ) );  // ����y�[�W���R�s�[�J�E���g
            table.Columns.Add( new DataColumn( ct_PageCount, typeof( int ) ) );  // �y�[�W��
            table.Columns.Add( new DataColumn( ct_BfTitle, typeof( string ) ) );  // �o�Ƀ^�C�g��
            table.Columns.Add( new DataColumn( ct_AfTitle, typeof( string ) ) );  // ���Ƀ^�C�g��
            # endregion
            table.Columns.Add(new DataColumn("HPRT.BARCDSALESSLNUMRF", typeof(string)));  // �o�[�R�[�h�i�`�[�ԍ��j // --- ADD 3H �k�P�N 2017/08/30

            return table;
        }
        # endregion

        # region [�f�[�^�ڍs�iDataClass��DataTable�j]
        /// <summary>
        /// �f�[�^�ڍs����
        /// </summary>
        /// <param name="table"></param>
        /// <param name="currentIndex"></param>
        /// <param name="slipWork"></param>
        /// <param name="detailWorks"></param>
        /// <param name="frePrtPSet"></param>
        /// <param name="slipPrtSet"></param>
        /// <param name="stockMngTtlSt"></param>
        /// <param name="slipPrintParameter"></param>
        /// <remarks>
        /// <br>Update Note  : 2017/08/30 3H �k�P�N</br>
        /// <br>�Ǘ��ԍ�     : 11370074-00 �n���f�B�Ή��i2���j</br>
        /// </remarks>
        // --- UPD  ���r��  2010/05/27 ---------->>>>>
        // --- UPD m.suzuki 2010/05/17 ---------->>>>>
        //public static void CopyToDataTable( ref DataTable table, FrePStockMoveSlipWork slipWork, List<FrePStockMoveDetailWork> detailWorks, FrePrtPSetWork frePrtPSet, SlipPrtSetWork slipPrtSet, EachSlipTypeSet eachSlipTypeSet, StockMngTtlStWork stockMngTtlSt, AllDefSetWork allDefSet, SlipPrintParameter slipPrintParameter, Dictionary<string, string> columnVisibleTypeDic )
        //public static void CopyToDataTable( ref List<DataTable> retTables, ref int currentIndex, FrePStockMoveSlipWork slipWork, List<FrePStockMoveDetailWork> detailWorks, FrePrtPSetWork frePrtPSet, SlipPrtSetWork slipPrtSet, EachSlipTypeSet eachSlipTypeSet, StockMngTtlStWork stockMngTtlSt, AllDefSetWork allDefSet, SlipPrintParameter slipPrintParameter, Dictionary<string, string> columnVisibleTypeDic )
        // --- UPD ����� 2011/08/15---------->>>>>
        //public static void CopyToDataTable( ref List<DataTable> retTables, ref int currentIndex, FrePStockMoveSlipWork slipWork, List<FrePStockMoveDetailWork> detailWorks, FrePrtPSetWork frePrtPSet, SlipPrtSetWork slipPrtSet, EachSlipTypeSet eachSlipTypeSet, StockMngTtlStWork stockMngTtlSt, AllDefSetWork allDefSet, SlipPrintParameter slipPrintParameter, Dictionary<string, string> columnVisibleTypeDic, Dictionary<string, string> titleDic)
        public static void CopyToDataTable(ref List<DataTable> retTables, ref int currentIndex, FrePStockMoveSlipWork slipWork, List<FrePStockMoveDetailWork> detailWorks, FrePrtPSetWork frePrtPSet, SlipPrtSetWork slipPrtSet, EachSlipTypeSet eachSlipTypeSet, StockMngTtlStWork stockMngTtlSt, AllDefSetWork allDefSet, SlipPrintParameter slipPrintParameter, Dictionary<string, string> columnVisibleTypeDic, Dictionary<string, string> titleDic, Dictionary<string, ar.ActiveReport3> subReportDic)
        // --- UPD ����� 2011/08/15----------<<<<<
        // --- UPD m.suzuki 2010/05/17 ----------<<<<<
        // --- UPD  ���r��  2010/05/27 ----------<<<<<
        {
            //----------------------------------------------------
            // �ȉ��̏����́A��{�I�Ɏ��̃|���V�[�ɏ]���L�q���܂��B
            // 
            // �@�E�`�[���ɑ΂���A�Œ薼�̂̃Z�b�g�Ȃǂ�
            // �@�@for�̑O�ɗ\�ߍs���܂��B
            //    �i�P��ŏI��点��ׁj
            // 
            // �@�E���׏��ɑ΂��鏈���́Afor�̒��ōs���܂��B
            //   �@�i���[�v���Q��܂킳�Ȃ��ׁj
            //
            //   �E�`�[���v���z�͖��ׂ��W�v���܂����A�w�b�_�Ɉ󎚂���
            //     �\��������ׁA��O�I��for�ŗ\�ߏW�v���܂��B
            // 
            // �������͏������x���d�����܂��B
            //----------------------------------------------------

            // �`�[work�e�햼��
            # region [slipWork�e�햼��]
            slipWork.HADD_STOCKMOVEFORMALNMRF = GetHADD_STOCKMOVEFORMALNMRFRF( slipWork.MOVH_STOCKMOVEFORMALRF );
            # endregion

            // ���v���z�̎Z�o
            # region [���v���z]
            // ���v���z
            slipWork.HADD_TTLSTOCKMOVEPRICERF = 0;
            slipWork.HADD_TTLSTOCKMOVELISTPRICERF = 0;
            foreach ( FrePStockMoveDetailWork detail in detailWorks )
            {
                // ���z�Z�o
                detail.DADD_STOCKMOVEPRICERF = GetSTOCKMOVEPRICERF( detail );// �ړ����z
                detail.DADD_STOCKMOVELISTPRICERF = GetSTOCKMOVELISTPRICERF( detail );// �ړ����z(�W�����i)

                // �W�v�l�ɍ��Z
                slipWork.HADD_TTLSTOCKMOVEPRICERF += detail.DADD_STOCKMOVEPRICERF; // �ړ����z
                slipWork.HADD_TTLSTOCKMOVELISTPRICERF += detail.DADD_STOCKMOVELISTPRICERF; // �ړ����z(�W�����i)
            }
            # endregion

            # region [����]
            DateTime printTime = DateTime.Now;
            slipWork.HADD_PRINTTIMEHOURRF = printTime.Hour;
            slipWork.HADD_PRINTTIMEMINUTERF = printTime.Minute;
            slipWork.HADD_PRINTTIMESECONDRF = printTime.Second;
            # endregion

            // �`�[�^�C�g���擾����
            List<List<string>> inPageCopyTitle = GetInPageCopyTitles( slipPrtSet );

            // �P�y�[�W�̖��׍s�����擾
            int feedCount = frePrtPSet.FormFeedLineCount;
            if ( feedCount <= 0 ) feedCount = 1;
            if ( slipPrtSet.DetailRowCount <= 0 ) slipPrtSet.DetailRowCount = feedCount;

            // ���s���擾
            int allDetailCount = GetAllDetailCount( detailWorks.Count, Math.Min( feedCount, slipPrtSet.DetailRowCount ) );

            // �S�y�[�W��
            int allPageCount = allDetailCount / Math.Min( feedCount, slipPrtSet.DetailRowCount );
            int pageStartIndex = 0;
            int pageEndIndex = pageStartIndex + feedCount - 1;

            int printEndIndex = pageStartIndex + slipPrtSet.DetailRowCount - 1;

            for ( int pageIndex = 0; pageIndex < allPageCount; pageIndex++ )
            {
                // --- ADD m.suzuki 2010/05/17 ---------->>>>>
                DataTable table = PMZAI08001PB.CreateFrePStockMoveSlipTable( currentIndex++ );
                retTables.Add( table );
                // --- ADD m.suzuki 2010/05/17 ----------<<<<<

                for ( int inPageCopyCount = 0; inPageCopyCount < inPageCopyTitle[0].Count; inPageCopyCount++ )
                {
                    // ���׍s�ڍs
                    for ( int index = pageStartIndex; index <= pageEndIndex; index++ )
                    {
                        DataRow row = table.NewRow();

                        # region [���גǉ�]
                        // �y�[�W��
                        row[ct_PageCount] = pageIndex + 1;

                        // �ŏ��̃��R�[�h�^�Ō�̃��R�[�h�̂ݓ`�[���ڂ��Z�b�g����B
                        // (�P���ɖ��ׂ̐������{�������Ȃ���)
                        // �Ȃ������ł�"�Ō�̃��R�[�h"�Ƃ͋󔒍s�̉\�����܂ށB
                        if ( index == pageStartIndex || index == pageEndIndex )
                        {
                            # region [�`�[����Copy]
                            row["MOVH.STOCKMOVEFORMALRF"] = slipWork.MOVH_STOCKMOVEFORMALRF; // �݌Ɉړ��`��
                            row["MOVH.STOCKMOVESLIPNORF"] = slipWork.MOVH_STOCKMOVESLIPNORF; // �݌Ɉړ��`�[�ԍ�
                            row["MOVH.BFSECTIONCODERF"] = slipWork.MOVH_BFSECTIONCODERF; // �ړ������_�R�[�h
                            row["MOVH.BFSECTIONGUIDESNMRF"] = slipWork.MOVH_BFSECTIONGUIDESNMRF; // �ړ������_�K�C�h����
                            row["MOVH.BFENTERWAREHCODERF"] = slipWork.MOVH_BFENTERWAREHCODERF; // �ړ����q�ɃR�[�h
                            row["MOVH.BFENTERWAREHNAMERF"] = slipWork.MOVH_BFENTERWAREHNAMERF; // �ړ����q�ɖ���
                            row["MOVH.AFSECTIONCODERF"] = slipWork.MOVH_AFSECTIONCODERF; // �ړ��拒�_�R�[�h
                            row["MOVH.AFSECTIONGUIDESNMRF"] = slipWork.MOVH_AFSECTIONGUIDESNMRF; // �ړ��拒�_�K�C�h����
                            row["MOVH.AFENTERWAREHCODERF"] = slipWork.MOVH_AFENTERWAREHCODERF; // �ړ���q�ɃR�[�h
                            row["MOVH.AFENTERWAREHNAMERF"] = slipWork.MOVH_AFENTERWAREHNAMERF; // �ړ���q�ɖ���
                            row["MOVH.SHIPMENTSCDLDAYRF"] = slipWork.MOVH_SHIPMENTSCDLDAYRF; // �o�ח\���
                            row["MOVH.INPUTDAYRF"] = slipWork.MOVH_INPUTDAYRF; // ���͓�
                            row["MOVH.STOCKMVEMPCODERF"] = slipWork.MOVH_STOCKMVEMPCODERF; // �݌Ɉړ����͏]�ƈ��R�[�h
                            row["MOVH.STOCKMVEMPNAMERF"] = slipWork.MOVH_STOCKMVEMPNAMERF; // �݌Ɉړ����͏]�ƈ�����
                            row["MOVH.SHIPAGENTCDRF"] = slipWork.MOVH_SHIPAGENTCDRF; // �o�גS���]�ƈ��R�[�h
                            row["MOVH.SHIPAGENTNMRF"] = slipWork.MOVH_SHIPAGENTNMRF; // �o�גS���]�ƈ�����
                            row["MOVH.RECEIVEAGENTCDRF"] = slipWork.MOVH_RECEIVEAGENTCDRF; // ����S���]�ƈ��R�[�h
                            row["MOVH.RECEIVEAGENTNMRF"] = slipWork.MOVH_RECEIVEAGENTNMRF; // ����S���]�ƈ�����
                            row["MOVH.OUTLINERF"] = slipWork.MOVH_OUTLINERF; // �`�[�E�v
                            row["MOVH.WAREHOUSENOTE1RF"] = slipWork.MOVH_WAREHOUSENOTE1RF; // �q�ɔ��l1
                            row["MOVH.SLIPPRINTFINISHCDRF"] = slipWork.MOVH_SLIPPRINTFINISHCDRF; // �`�[���s�ϋ敪
                            row["SEC1.SECTIONGUIDENMRF"] = slipWork.SEC1_SECTIONGUIDENMRF; // ���_�K�C�h����
                            row["SEC1.COMPANYNAMECD1RF"] = slipWork.SEC1_COMPANYNAMECD1RF; // ���Ж��̃R�[�h1
                            row["SEC2.SECTIONGUIDENMRF"] = slipWork.SEC2_SECTIONGUIDENMRF; // ���_�K�C�h����
                            row["SEC2.COMPANYNAMECD1RF"] = slipWork.SEC2_COMPANYNAMECD1RF; // ���Ж��̃R�[�h1
                            row["COMPANYINFRF.COMPANYNAME1RF"] = slipWork.COMPANYINFRF_COMPANYNAME1RF; // ���Ж���1
                            row["COMPANYINFRF.COMPANYNAME2RF"] = slipWork.COMPANYINFRF_COMPANYNAME2RF; // ���Ж���2
                            row["COMPANYINFRF.POSTNORF"] = slipWork.COMPANYINFRF_POSTNORF; // �X�֔ԍ�
                            row["COMPANYINFRF.ADDRESS1RF"] = slipWork.COMPANYINFRF_ADDRESS1RF; // �Z��1�i�s���{���s��S�E�����E���j
                            row["COMPANYINFRF.ADDRESS3RF"] = slipWork.COMPANYINFRF_ADDRESS3RF; // �Z��3�i�Ԓn�j
                            row["COMPANYINFRF.ADDRESS4RF"] = slipWork.COMPANYINFRF_ADDRESS4RF; // �Z��4�i�A�p�[�g���́j
                            row["COMPANYINFRF.COMPANYTELNO1RF"] = slipWork.COMPANYINFRF_COMPANYTELNO1RF; // ���Гd�b�ԍ�1
                            row["COMPANYINFRF.COMPANYTELNO2RF"] = slipWork.COMPANYINFRF_COMPANYTELNO2RF; // ���Гd�b�ԍ�2
                            row["COMPANYINFRF.COMPANYTELNO3RF"] = slipWork.COMPANYINFRF_COMPANYTELNO3RF; // ���Гd�b�ԍ�3
                            row["COMPANYINFRF.COMPANYTELTITLE1RF"] = slipWork.COMPANYINFRF_COMPANYTELTITLE1RF; // ���Гd�b�ԍ��^�C�g��1
                            row["COMPANYINFRF.COMPANYTELTITLE2RF"] = slipWork.COMPANYINFRF_COMPANYTELTITLE2RF; // ���Гd�b�ԍ��^�C�g��2
                            row["COMPANYINFRF.COMPANYTELTITLE3RF"] = slipWork.COMPANYINFRF_COMPANYTELTITLE3RF; // ���Гd�b�ԍ��^�C�g��3
                            row["CMP1.COMPANYPRRF"] = slipWork.CMP1_COMPANYPRRF; // ����PR��
                            row["CMP1.COMPANYNAME1RF"] = slipWork.CMP1_COMPANYNAME1RF; // ���Ж���1
                            row["CMP1.COMPANYNAME2RF"] = slipWork.CMP1_COMPANYNAME2RF; // ���Ж���2
                            row["CMP1.POSTNORF"] = slipWork.CMP1_POSTNORF; // �X�֔ԍ�
                            row["CMP1.ADDRESS1RF"] = slipWork.CMP1_ADDRESS1RF; // �Z��1�i�s���{���s��S�E�����E���j
                            row["CMP1.ADDRESS3RF"] = slipWork.CMP1_ADDRESS3RF; // �Z��3�i�Ԓn�j
                            row["CMP1.ADDRESS4RF"] = slipWork.CMP1_ADDRESS4RF; // �Z��4�i�A�p�[�g���́j
                            row["CMP1.COMPANYTELNO1RF"] = slipWork.CMP1_COMPANYTELNO1RF; // ���Гd�b�ԍ�1
                            row["CMP1.COMPANYTELNO2RF"] = slipWork.CMP1_COMPANYTELNO2RF; // ���Гd�b�ԍ�2
                            row["CMP1.COMPANYTELNO3RF"] = slipWork.CMP1_COMPANYTELNO3RF; // ���Гd�b�ԍ�3
                            row["CMP1.COMPANYTELTITLE1RF"] = slipWork.CMP1_COMPANYTELTITLE1RF; // ���Гd�b�ԍ��^�C�g��1
                            row["CMP1.COMPANYTELTITLE2RF"] = slipWork.CMP1_COMPANYTELTITLE2RF; // ���Гd�b�ԍ��^�C�g��2
                            row["CMP1.COMPANYTELTITLE3RF"] = slipWork.CMP1_COMPANYTELTITLE3RF; // ���Гd�b�ԍ��^�C�g��3
                            row["CMP1.TRANSFERGUIDANCERF"] = slipWork.CMP1_TRANSFERGUIDANCERF; // ��s�U���ē���
                            row["CMP1.ACCOUNTNOINFO1RF"] = slipWork.CMP1_ACCOUNTNOINFO1RF; // ��s����1
                            row["CMP1.ACCOUNTNOINFO2RF"] = slipWork.CMP1_ACCOUNTNOINFO2RF; // ��s����2
                            row["CMP1.ACCOUNTNOINFO3RF"] = slipWork.CMP1_ACCOUNTNOINFO3RF; // ��s����3
                            row["CMP1.COMPANYSETNOTE1RF"] = slipWork.CMP1_COMPANYSETNOTE1RF; // ���Аݒ�E�v1
                            row["CMP1.COMPANYSETNOTE2RF"] = slipWork.CMP1_COMPANYSETNOTE2RF; // ���Аݒ�E�v2
                            row["CMP1.IMAGEINFODIVRF"] = slipWork.CMP1_IMAGEINFODIVRF; // �摜���敪
                            row["CMP1.IMAGEINFOCODERF"] = slipWork.CMP1_IMAGEINFOCODERF; // �摜���R�[�h
                            row["CMP1.COMPANYURLRF"] = slipWork.CMP1_COMPANYURLRF; // ����URL
                            row["CMP1.COMPANYPRSENTENCE2RF"] = slipWork.CMP1_COMPANYPRSENTENCE2RF; // ����PR��2
                            row["CMP1.IMAGECOMMENTFORPRT1RF"] = slipWork.CMP1_IMAGECOMMENTFORPRT1RF; // �摜�󎚗p�R�����g1
                            row["CMP1.IMAGECOMMENTFORPRT2RF"] = slipWork.CMP1_IMAGECOMMENTFORPRT2RF; // �摜�󎚗p�R�����g2
                            row["CMP2.COMPANYPRRF"] = slipWork.CMP2_COMPANYPRRF; // ����PR��
                            row["CMP2.COMPANYNAME1RF"] = slipWork.CMP2_COMPANYNAME1RF; // ���Ж���1
                            row["CMP2.COMPANYNAME2RF"] = slipWork.CMP2_COMPANYNAME2RF; // ���Ж���2
                            row["CMP2.POSTNORF"] = slipWork.CMP2_POSTNORF; // �X�֔ԍ�
                            row["CMP2.ADDRESS1RF"] = slipWork.CMP2_ADDRESS1RF; // �Z��1�i�s���{���s��S�E�����E���j
                            row["CMP2.ADDRESS3RF"] = slipWork.CMP2_ADDRESS3RF; // �Z��3�i�Ԓn�j
                            row["CMP2.ADDRESS4RF"] = slipWork.CMP2_ADDRESS4RF; // �Z��4�i�A�p�[�g���́j
                            row["CMP2.COMPANYTELNO1RF"] = slipWork.CMP2_COMPANYTELNO1RF; // ���Гd�b�ԍ�1
                            row["CMP2.COMPANYTELNO2RF"] = slipWork.CMP2_COMPANYTELNO2RF; // ���Гd�b�ԍ�2
                            row["CMP2.COMPANYTELNO3RF"] = slipWork.CMP2_COMPANYTELNO3RF; // ���Гd�b�ԍ�3
                            row["CMP2.COMPANYTELTITLE1RF"] = slipWork.CMP2_COMPANYTELTITLE1RF; // ���Гd�b�ԍ��^�C�g��1
                            row["CMP2.COMPANYTELTITLE2RF"] = slipWork.CMP2_COMPANYTELTITLE2RF; // ���Гd�b�ԍ��^�C�g��2
                            row["CMP2.COMPANYTELTITLE3RF"] = slipWork.CMP2_COMPANYTELTITLE3RF; // ���Гd�b�ԍ��^�C�g��3
                            row["CMP2.TRANSFERGUIDANCERF"] = slipWork.CMP2_TRANSFERGUIDANCERF; // ��s�U���ē���
                            row["CMP2.ACCOUNTNOINFO1RF"] = slipWork.CMP2_ACCOUNTNOINFO1RF; // ��s����1
                            row["CMP2.ACCOUNTNOINFO2RF"] = slipWork.CMP2_ACCOUNTNOINFO2RF; // ��s����2
                            row["CMP2.ACCOUNTNOINFO3RF"] = slipWork.CMP2_ACCOUNTNOINFO3RF; // ��s����3
                            row["CMP2.COMPANYSETNOTE1RF"] = slipWork.CMP2_COMPANYSETNOTE1RF; // ���Аݒ�E�v1
                            row["CMP2.COMPANYSETNOTE2RF"] = slipWork.CMP2_COMPANYSETNOTE2RF; // ���Аݒ�E�v2
                            row["CMP2.COMPANYURLRF"] = slipWork.CMP2_COMPANYURLRF; // ����URL
                            row["CMP2.COMPANYPRSENTENCE2RF"] = slipWork.CMP2_COMPANYPRSENTENCE2RF; // ����PR��2
                            row["CMP2.IMAGECOMMENTFORPRT1RF"] = slipWork.CMP2_IMAGECOMMENTFORPRT1RF; // �摜�󎚗p�R�����g1
                            row["CMP2.IMAGECOMMENTFORPRT2RF"] = slipWork.CMP2_IMAGECOMMENTFORPRT2RF; // �摜�󎚗p�R�����g2
                            row["EMP1.KANARF"] = slipWork.EMP1_KANARF; // �J�i
                            row["EMP1.SHORTNAMERF"] = slipWork.EMP1_SHORTNAMERF; // �Z�k����
                            row["EMP2.KANARF"] = slipWork.EMP2_KANARF; // �J�i
                            row["EMP2.SHORTNAMERF"] = slipWork.EMP2_SHORTNAMERF; // �Z�k����
                            row["EMP3.KANARF"] = slipWork.EMP3_KANARF; // �J�i
                            row["EMP3.SHORTNAMERF"] = slipWork.EMP3_SHORTNAMERF; // �Z�k����
                            row["IMAGEINFORF.IMAGEINFODATARF"] = slipWork.IMAGEINFORF_IMAGEINFODATARF; // �摜���f�[�^
                            row["HADD.STOCKMOVEFORMALNMRF"] = slipWork.HADD_STOCKMOVEFORMALNMRF; // �݌Ɉړ��`������
                            //row["HADD.SHIPMENTSCDLDFYRF"] = slipWork.HADD_SHIPMENTSCDLDFYRF; // �o�ח\�������N
                            //row["HADD.SHIPMENTSCDLDFSRF"] = slipWork.HADD_SHIPMENTSCDLDFSRF; // �o�ח\�������N��
                            //row["HADD.SHIPMENTSCDLDFWRF"] = slipWork.HADD_SHIPMENTSCDLDFWRF; // �o�ח\����a��N
                            //row["HADD.SHIPMENTSCDLDFMRF"] = slipWork.HADD_SHIPMENTSCDLDFMRF; // �o�ח\�����
                            //row["HADD.SHIPMENTSCDLDFDRF"] = slipWork.HADD_SHIPMENTSCDLDFDRF; // �o�ח\�����
                            //row["HADD.SHIPMENTSCDLDFGRF"] = slipWork.HADD_SHIPMENTSCDLDFGRF; // �o�ח\�������
                            //row["HADD.SHIPMENTSCDLDFRRF"] = slipWork.HADD_SHIPMENTSCDLDFRRF; // �o�ח\�������
                            //row["HADD.SHIPMENTSCDLDFLSRF"] = slipWork.HADD_SHIPMENTSCDLDFLSRF; // �o�ח\������e����(/)
                            //row["HADD.SHIPMENTSCDLDFLPRF"] = slipWork.HADD_SHIPMENTSCDLDFLPRF; // �o�ח\������e����(.)
                            //row["HADD.SHIPMENTSCDLDFLYRF"] = slipWork.HADD_SHIPMENTSCDLDFLYRF; // �o�ח\������e����(�N)
                            //row["HADD.SHIPMENTSCDLDFLMRF"] = slipWork.HADD_SHIPMENTSCDLDFLMRF; // �o�ח\������e����(��)
                            //row["HADD.SHIPMENTSCDLDFLDRF"] = slipWork.HADD_SHIPMENTSCDLDFLDRF; // �o�ח\������e����(��)
                            //row["HADD.INPUTDFYRF"] = slipWork.HADD_INPUTDFYRF; // ���͓�����N
                            //row["HADD.INPUTDFSRF"] = slipWork.HADD_INPUTDFSRF; // ���͓�����N��
                            //row["HADD.INPUTDFWRF"] = slipWork.HADD_INPUTDFWRF; // ���͓��a��N
                            //row["HADD.INPUTDFMRF"] = slipWork.HADD_INPUTDFMRF; // ���͓���
                            //row["HADD.INPUTDFDRF"] = slipWork.HADD_INPUTDFDRF; // ���͓���
                            //row["HADD.INPUTDFGRF"] = slipWork.HADD_INPUTDFGRF; // ���͓�����
                            //row["HADD.INPUTDFRRF"] = slipWork.HADD_INPUTDFRRF; // ���͓�����
                            //row["HADD.INPUTDFLSRF"] = slipWork.HADD_INPUTDFLSRF; // ���͓����e����(/)
                            //row["HADD.INPUTDFLPRF"] = slipWork.HADD_INPUTDFLPRF; // ���͓����e����(.)
                            //row["HADD.INPUTDFLYRF"] = slipWork.HADD_INPUTDFLYRF; // ���͓����e����(�N)
                            //row["HADD.INPUTDFLMRF"] = slipWork.HADD_INPUTDFLMRF; // ���͓����e����(��)
                            //row["HADD.INPUTDFLDRF"] = slipWork.HADD_INPUTDFLDRF; // ���͓����e����(��)
                            //row["HADD.NOTE1RF"] = slipWork.HADD_NOTE1RF; // ���Д��l�P
                            //row["HADD.NOTE2RF"] = slipWork.HADD_NOTE2RF; // ���Д��l�Q
                            //row["HADD.NOTE3RF"] = slipWork.HADD_NOTE2RF; // ���Д��l�R
                            //row["HADD.REISSUEMARKRF"] = slipWork.HADD_REISSUEMARKRF; // �Ĕ��s�}�[�N
                            //row["HADD.PRINTERMNGNORF"] = slipWork.HADD_PRINTERMNGNORF; // �v�����^�Ǘ�No
                            //row["HADD.SLIPPRTSETPAPERIDRF"] = slipWork.HADD_SLIPPRTSETPAPERIDRF; // �`�[����ݒ�p���[ID
                            row["MOVH.UPDATESECCDRF"] = slipWork.MOVH_UPDATESECCDRF; // ���͋��_�R�[�h
                            row["SEC0.SECTIONGUIDESNMRF"] = slipWork.SEC0_SECTIONGUIDESNMRF; // ���͋��_�K�C�h����
                            row["SEC0.SECTIONGUIDENMRF"] = slipWork.SEC0_SECTIONGUIDENMRF; // ���͋��_�K�C�h����

                            // --- ADD 3H �k�P�N 2017/08/30---------->>>>>
                            #region�u�n���f�B�Ή��i2���j�v
                            // �o�[�R�[�h�i�`�[�ԍ��j
                            row["HPRT.BARCDSALESSLNUMRF"] = "*" + string.Format("{0:D9}", slipWork.MOVH_STOCKMOVESLIPNORF) + "*";
                            #endregion
                            // --- ADD 3H �k�P�N 2017/08/30----------<<<<<

                            # endregion

                            # region [�`�[����(�����ȊO)]

                            // ���ݒ莞 ��󎚃R�[�h
                            # region [���ݒ�]
                            // ������R�[�h
                            if ( IsZero( slipWork.MOVH_BFSECTIONCODERF ) ) row["MOVH.BFSECTIONCODERF"] = DBNull.Value; // �ړ������_�R�[�h
                            if ( IsZero( slipWork.MOVH_BFENTERWAREHCODERF ) ) row["MOVH.BFENTERWAREHCODERF"] = DBNull.Value; // �ړ����q�ɃR�[�h
                            if ( IsZero( slipWork.MOVH_AFSECTIONCODERF ) ) row["MOVH.AFSECTIONCODERF"] = DBNull.Value; // �ړ��拒�_�R�[�h
                            if ( IsZero( slipWork.MOVH_AFENTERWAREHCODERF ) ) row["MOVH.AFENTERWAREHCODERF"] = DBNull.Value; // �ړ���q�ɃR�[�h
                            if ( IsZero( slipWork.MOVH_STOCKMVEMPCODERF ) ) row["MOVH.STOCKMVEMPCODERF"] = DBNull.Value; // �݌Ɉړ����͏]�ƈ��R�[�h
                            if ( IsZero( slipWork.MOVH_SHIPAGENTCDRF ) ) row["MOVH.SHIPAGENTCDRF"] = DBNull.Value; // �o�גS���]�ƈ��R�[�h
                            if ( IsZero( slipWork.MOVH_RECEIVEAGENTCDRF ) ) row["MOVH.RECEIVEAGENTCDRF"] = DBNull.Value; // ����S���]�ƈ��R�[�h
                            # endregion

                            // ���Д��l
                            # region [���Д��l]
                            row["HADD.NOTE1RF"] = slipPrtSet.Note1; // ���Д��l�P
                            row["HADD.NOTE2RF"] = slipPrtSet.Note2; // ���Д��l�Q
                            row["HADD.NOTE3RF"] = slipPrtSet.Note3; // ���Д��l�R
                            # endregion

                            // �Ĕ��s�}�[�N
                            # region [�Ĕ��s]
                            if ( slipPrintParameter.ReissueDiv )
                            {
                                row["HADD.REISSUEMARKRF"] = slipPrtSet.ReissueMark; // �Ĕ��s�}�[�N
                            }
                            else
                            {
                                row["HADD.REISSUEMARKRF"] = string.Empty;
                            }
                            # endregion

                            // ���t�֘A�W�J
                            # region [���t�W�J]
                            // �ʏ�
                            ExtractDate( ref row, allDefSet.EraNameDispCd2, slipWork.MOVH_SHIPMENTSCDLDAYRF, "HADD.SHIPMENTSCDLD", false ); // �o�ח\���
                            ExtractDate( ref row, allDefSet.EraNameDispCd2, slipWork.MOVH_INPUTDAYRF, "HADD.INPUTD", false ); // ���͓�
                            # endregion

                            // ����
                            # region [����]
                            if ( slipPrtSet.TimePrintDivCd != 0 )
                            {
                                // ��
                                row["HADD.PRINTTIMEHOURRF"] = slipWork.HADD_PRINTTIMEHOURRF; // �������HH
                                row["HADD.PRINTTIMEMINUTERF"] = slipWork.HADD_PRINTTIMEMINUTERF; // �������MM
                                row["HADD.PRINTTIMESECONDRF"] = slipWork.HADD_PRINTTIMESECONDRF; // �������SS
                            }
                            else
                            {
                                // ���
                                row["HADD.PRINTTIMEHOURRF"] = DBNull.Value; // �������HH
                                row["HADD.PRINTTIMEMINUTERF"] = DBNull.Value; // �������MM
                                row["HADD.PRINTTIMESECONDRF"] = DBNull.Value; // �������SS
                            }
                            # endregion

                            // ���Џ��
                            # region [���Џ��̐���]
                            // 0:���Ж��󎚁@1:���_���󎚁@2:�r�b�g�}�b�v���󎚁@3:�󎚂��Ȃ�
                            switch ( slipPrtSet.EnterpriseNamePrtCd )
                            {
                                // ���Ж�
                                case 0:
                                    {
                                        // CompanyInf�̓��e�ɍ����ւ���
                                        row["CMP1.COMPANYNAME1RF"] = slipWork.COMPANYINFRF_COMPANYNAME1RF; // ���Ж���1
                                        row["CMP1.COMPANYNAME2RF"] = slipWork.COMPANYINFRF_COMPANYNAME2RF; // ���Ж���2
                                        row["CMP1.POSTNORF"] = slipWork.COMPANYINFRF_POSTNORF; // �X�֔ԍ�
                                        row["CMP1.ADDRESS1RF"] = slipWork.COMPANYINFRF_ADDRESS1RF; // �Z��1�i�s���{���s��S�E�����E���j
                                        row["CMP1.ADDRESS3RF"] = slipWork.COMPANYINFRF_ADDRESS3RF; // �Z��3�i�Ԓn�j
                                        row["CMP1.ADDRESS4RF"] = slipWork.COMPANYINFRF_ADDRESS4RF; // �Z��4�i�A�p�[�g���́j
                                        row["CMP1.COMPANYTELNO1RF"] = slipWork.COMPANYINFRF_COMPANYTELNO1RF; // ���Гd�b�ԍ�1
                                        row["CMP1.COMPANYTELNO2RF"] = slipWork.COMPANYINFRF_COMPANYTELNO2RF; // ���Гd�b�ԍ�2
                                        row["CMP1.COMPANYTELNO3RF"] = slipWork.COMPANYINFRF_COMPANYTELNO3RF; // ���Гd�b�ԍ�3
                                        row["CMP1.COMPANYTELTITLE1RF"] = slipWork.COMPANYINFRF_COMPANYTELTITLE1RF; // ���Гd�b�ԍ��^�C�g��1
                                        row["CMP1.COMPANYTELTITLE2RF"] = slipWork.COMPANYINFRF_COMPANYTELTITLE2RF; // ���Гd�b�ԍ��^�C�g��2
                                        row["CMP1.COMPANYTELTITLE3RF"] = slipWork.COMPANYINFRF_COMPANYTELTITLE3RF; // ���Гd�b�ԍ��^�C�g��3
                                        // bitmap�Ȃ�
                                        row["CMP1.IMAGECOMMENTFORPRT1RF"] = DBNull.Value; // �摜�󎚗p�R�����g1
                                        row["CMP1.IMAGECOMMENTFORPRT2RF"] = DBNull.Value; // �摜�󎚗p�R�����g2
                                        row["IMAGEINFORF.IMAGEINFODATARF"] = DBNull.Value; // �摜���f�[�^
                                    }
                                    break;
                                // ���_��
                                case 1:
                                    {
                                        // bitmap�Ȃ�
                                        row["CMP1.IMAGECOMMENTFORPRT1RF"] = DBNull.Value; // �摜�󎚗p�R�����g1
                                        row["CMP1.IMAGECOMMENTFORPRT2RF"] = DBNull.Value; // �摜�󎚗p�R�����g2
                                        row["IMAGEINFORF.IMAGEINFODATARF"] = DBNull.Value; // �摜���f�[�^
                                    }
                                    break;
                                // �r�b�g�}�b�v
                                case 2:
                                    {
                                        // ���Џ�񕶎���Ȃ�
                                        row["CMP1.COMPANYNAME1RF"] = DBNull.Value; // ���Ж���1
                                        row["CMP1.COMPANYNAME2RF"] = DBNull.Value; // ���Ж���2
                                        row["CMP1.POSTNORF"] = DBNull.Value; // �X�֔ԍ�
                                        row["CMP1.ADDRESS1RF"] = DBNull.Value; // �Z��1�i�s���{���s��S�E�����E���j
                                        row["CMP1.ADDRESS3RF"] = DBNull.Value; // �Z��3�i�Ԓn�j
                                        row["CMP1.ADDRESS4RF"] = DBNull.Value; // �Z��4�i�A�p�[�g���́j
                                        row["CMP1.COMPANYTELNO1RF"] = DBNull.Value; // ���Гd�b�ԍ�1
                                        row["CMP1.COMPANYTELNO2RF"] = DBNull.Value; // ���Гd�b�ԍ�2
                                        row["CMP1.COMPANYTELNO3RF"] = DBNull.Value; // ���Гd�b�ԍ�3
                                        row["CMP1.COMPANYTELTITLE1RF"] = DBNull.Value; // ���Гd�b�ԍ��^�C�g��1
                                        row["CMP1.COMPANYTELTITLE2RF"] = DBNull.Value; // ���Гd�b�ԍ��^�C�g��2
                                        row["CMP1.COMPANYTELTITLE3RF"] = DBNull.Value; // ���Гd�b�ԍ��^�C�g��3
                                    }
                                    break;
                                // �󎚂��Ȃ�
                                case 3:
                                default:
                                    {
                                        // ���Џ�񕶎���Ȃ�
                                        row["CMP1.COMPANYNAME1RF"] = DBNull.Value; // ���Ж���1
                                        row["CMP1.COMPANYNAME2RF"] = DBNull.Value; // ���Ж���2
                                        row["CMP1.POSTNORF"] = DBNull.Value; // �X�֔ԍ�
                                        row["CMP1.ADDRESS1RF"] = DBNull.Value; // �Z��1�i�s���{���s��S�E�����E���j
                                        row["CMP1.ADDRESS3RF"] = DBNull.Value; // �Z��3�i�Ԓn�j
                                        row["CMP1.ADDRESS4RF"] = DBNull.Value; // �Z��4�i�A�p�[�g���́j
                                        row["CMP1.COMPANYTELNO1RF"] = DBNull.Value; // ���Гd�b�ԍ�1
                                        row["CMP1.COMPANYTELNO2RF"] = DBNull.Value; // ���Гd�b�ԍ�2
                                        row["CMP1.COMPANYTELNO3RF"] = DBNull.Value; // ���Гd�b�ԍ�3
                                        row["CMP1.COMPANYTELTITLE1RF"] = DBNull.Value; // ���Гd�b�ԍ��^�C�g��1
                                        row["CMP1.COMPANYTELTITLE2RF"] = DBNull.Value; // ���Гd�b�ԍ��^�C�g��2
                                        row["CMP1.COMPANYTELTITLE3RF"] = DBNull.Value; // ���Гd�b�ԍ��^�C�g��3
                                        // bitmap�Ȃ�
                                        row["CMP1.IMAGECOMMENTFORPRT1RF"] = DBNull.Value; // �摜�󎚗p�R�����g1
                                        row["CMP1.IMAGECOMMENTFORPRT2RF"] = DBNull.Value; // �摜�󎚗p�R�����g2
                                        row["IMAGEINFORF.IMAGEINFODATARF"] = DBNull.Value; // �摜���f�[�^
                                    }
                                    break;
                            }

                            // ���Ж��P����
                            if ( row["CMP1.COMPANYNAME1RF"] != DBNull.Value )
                            {
                                string firstHalf;
                                string lastHalf;
                                DivideEnterpriseName( (string)row["CMP1.COMPANYNAME1RF"], out firstHalf, out lastHalf );
                                row["HADD.PRINTENTERPRISENAME1FHRF"] = firstHalf;
                                row["HADD.PRINTENTERPRISENAME1LHRF"] = lastHalf;
                            }
                            else
                            {
                                row["HADD.PRINTENTERPRISENAME1FHRF"] = DBNull.Value;
                                row["HADD.PRINTENTERPRISENAME1LHRF"] = DBNull.Value;
                            }
                            // ���Ж��Q����
                            if ( row["CMP1.COMPANYNAME2RF"] != DBNull.Value )
                            {
                                string firstHalf;
                                string lastHalf;
                                DivideEnterpriseName( (string)row["CMP1.COMPANYNAME2RF"], out firstHalf, out lastHalf );
                                row["HADD.PRINTENTERPRISENAME2FHRF"] = firstHalf;
                                row["HADD.PRINTENTERPRISENAME2LHRF"] = lastHalf;
                            }
                            else
                            {
                                row["HADD.PRINTENTERPRISENAME2FHRF"] = DBNull.Value;
                                row["HADD.PRINTENTERPRISENAME2LHRF"] = DBNull.Value;
                            }

                            # endregion

                            // �`�[���v���z
                            # region [�`�[���v���z]
                            if ( pageIndex == allPageCount - 1 )
                            {
                                row["HADD.TTLSTOCKMOVEPRICERF"] = slipWork.HADD_TTLSTOCKMOVEPRICERF; // �ړ����z
                                row["HADD.TTLSTOCKMOVELISTPRICERF"] = slipWork.HADD_TTLSTOCKMOVELISTPRICERF; // �ړ����z(�W�����i)
                            }
                            else
                            {
                                row["HADD.TTLSTOCKMOVEPRICERF"] = DBNull.Value; // �ړ����z
                                row["HADD.TTLSTOCKMOVELISTPRICERF"] = DBNull.Value; // �ړ����z(�W�����i)
                            }
                            # endregion

                            # endregion

                            # region [�`�[����(�`�[�^�C�v�ʐݒ�)]
                            // �S����
                            if ( eachSlipTypeSet.SalesEmployee == 0 )
                            {
                                row["MOVH.SHIPAGENTCDRF"] = DBNull.Value; // �o�גS���]�ƈ��R�[�h
                                row["MOVH.SHIPAGENTNMRF"] = DBNull.Value; // �o�גS���]�ƈ�����
                            }
                            // ���s��
                            if ( eachSlipTypeSet.SalesInput == 0 )
                            {
                                row["MOVH.STOCKMVEMPCODERF"] = DBNull.Value; // �݌Ɉړ����͏]�ƈ��R�[�h
                                row["MOVH.STOCKMVEMPNAMERF"] = DBNull.Value; // �݌Ɉړ����͏]�ƈ�����
                            }
                            // �W�����i
                            if ( eachSlipTypeSet.ListPrice1 == 0 )
                            {
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/00/00 DEL
                                //row["HADD.STOCKMOVELISTPRICERF"] = DBNull.Value; // �ړ����z(�W�����i)
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/00/00 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/00/00 ADD
                                row["HADD.TTLSTOCKMOVELISTPRICERF"] = DBNull.Value; // �`�[���v���z(�W�����i)
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/00/00 ADD
                            }
                            // ����
                            if ( eachSlipTypeSet.Cost == 0 )
                            {
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/00/00 DEL
                                //row["HADD.STOCKMOVEPRICERF"] = DBNull.Value; // �ړ����z
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/00/00 DEL
                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/00/00 ADD
                                row["HADD.TTLSTOCKMOVEPRICERF"] = DBNull.Value; // �`�[���v���z
                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/00/00 ADD
                            }
                            # endregion
                        }

                        if ( index <= printEndIndex && index < detailWorks.Count )
                        {
                            //-------------------------------------------
                            // ������
                            //-------------------------------------------

                            # region [���׍���Copy]
                            row["MOVD.STOCKMOVEFORMALRF"] = detailWorks[index].MOVD_STOCKMOVEFORMALRF; // �݌Ɉړ��`��
                            row["MOVD.STOCKMOVESLIPNORF"] = detailWorks[index].MOVD_STOCKMOVESLIPNORF; // �݌Ɉړ��`�[�ԍ�
                            row["MOVD.STOCKMOVEROWNORF"] = detailWorks[index].MOVD_STOCKMOVEROWNORF; // �݌Ɉړ��s�ԍ�
                            row["MOVD.BFSECTIONCODERF"] = detailWorks[index].MOVD_BFSECTIONCODERF; // �ړ������_�R�[�h
                            row["MOVD.BFENTERWAREHCODERF"] = detailWorks[index].MOVD_BFENTERWAREHCODERF; // �ړ����q�ɃR�[�h
                            row["MOVD.AFSECTIONCODERF"] = detailWorks[index].MOVD_AFSECTIONCODERF; // �ړ��拒�_�R�[�h
                            row["MOVD.AFENTERWAREHCODERF"] = detailWorks[index].MOVD_AFENTERWAREHCODERF; // �ړ���q�ɃR�[�h
                            row["MOVD.SUPPLIERCDRF"] = detailWorks[index].MOVD_SUPPLIERCDRF; // �d����R�[�h
                            row["MOVD.SUPPLIERSNMRF"] = detailWorks[index].MOVD_SUPPLIERSNMRF; // �d���旪��
                            row["MOVD.GOODSMAKERCDRF"] = detailWorks[index].MOVD_GOODSMAKERCDRF; // ���i���[�J�[�R�[�h
                            row["MOVD.MAKERNAMERF"] = detailWorks[index].MOVD_MAKERNAMERF; // ���[�J�[����
                            row["MOVD.GOODSNORF"] = detailWorks[index].MOVD_GOODSNORF; // ���i�ԍ�
                            row["MOVD.GOODSNAMERF"] = detailWorks[index].MOVD_GOODSNAMERF; // ���i����
                            row["MOVD.GOODSNAMEKANARF"] = detailWorks[index].MOVD_GOODSNAMEKANARF; // ���i���̃J�i
                            row["MOVD.STOCKDIVRF"] = detailWorks[index].MOVD_STOCKDIVRF; // �݌ɋ敪
                            row["MOVD.STOCKUNITPRICEFLRF"] = detailWorks[index].MOVD_STOCKUNITPRICEFLRF; // �d���P���i�Ŕ�,�����j
                            row["MOVD.TAXATIONDIVCDRF"] = detailWorks[index].MOVD_TAXATIONDIVCDRF; // �ېŋ敪
                            row["MOVD.MOVECOUNTRF"] = detailWorks[index].MOVD_MOVECOUNTRF; // �ړ���
                            row["MOVD.BFSHELFNORF"] = detailWorks[index].MOVD_BFSHELFNORF; // �ړ����I��
                            row["MOVD.AFSHELFNORF"] = detailWorks[index].MOVD_AFSHELFNORF; // �ړ���I��
                            row["MOVD.BLGOODSCODERF"] = detailWorks[index].MOVD_BLGOODSCODERF; // BL���i�R�[�h
                            row["MOVD.BLGOODSFULLNAMERF"] = detailWorks[index].MOVD_BLGOODSFULLNAMERF; // BL���i�R�[�h���́i�S�p�j
                            row["MOVD.LISTPRICEFLRF"] = detailWorks[index].MOVD_LISTPRICEFLRF; // �艿�i�����j
                            row["MOVD.MOVESTATUSRF"] = detailWorks[index].MOVD_MOVESTATUSRF; // �ړ����
                            row["BLGOODSCDURF.BLGOODSHALFNAMERF"] = detailWorks[index].BLGOODSCDURF_BLGOODSHALFNAMERF; // BL���i�R�[�h���́i���p�j
                            row["MAKERURF.MAKERSHORTNAMERF"] = detailWorks[index].MAKERURF_MAKERSHORTNAMERF; // ���[�J�[����
                            row["MAKERURF.MAKERKANANAMERF"] = detailWorks[index].MAKERURF_MAKERKANANAMERF; // ���[�J�[�J�i����
                            row["STC1.DUPLICATIONSHELFNO1RF"] = detailWorks[index].STC1_DUPLICATIONSHELFNO1RF; // �d���I�ԂP
                            row["STC1.DUPLICATIONSHELFNO2RF"] = detailWorks[index].STC1_DUPLICATIONSHELFNO2RF; // �d���I�ԂQ
                            row["STC1.PARTSMANAGEMENTDIVIDE1RF"] = detailWorks[index].STC1_PARTSMANAGEMENTDIVIDE1RF; // ���i�Ǘ��敪�P
                            row["STC1.PARTSMANAGEMENTDIVIDE2RF"] = detailWorks[index].STC1_PARTSMANAGEMENTDIVIDE2RF; // ���i�Ǘ��敪�Q
                            row["STC1.STOCKNOTE1RF"] = detailWorks[index].STC1_STOCKNOTE1RF; // �݌ɔ��l�P
                            row["STC1.STOCKNOTE2RF"] = detailWorks[index].STC1_STOCKNOTE2RF; // �݌ɔ��l�Q
                            row["STC1.SHIPMENTPOSCNTRF"] = detailWorks[index].STC1_SHIPMENTPOSCNTRF; // �o�׉\��
                            row["STC2.DUPLICATIONSHELFNO1RF"] = detailWorks[index].STC2_DUPLICATIONSHELFNO1RF; // �d���I�ԂP
                            row["STC2.DUPLICATIONSHELFNO2RF"] = detailWorks[index].STC2_DUPLICATIONSHELFNO2RF; // �d���I�ԂQ
                            row["STC2.PARTSMANAGEMENTDIVIDE1RF"] = detailWorks[index].STC2_PARTSMANAGEMENTDIVIDE1RF; // ���i�Ǘ��敪�P
                            row["STC2.PARTSMANAGEMENTDIVIDE2RF"] = detailWorks[index].STC2_PARTSMANAGEMENTDIVIDE2RF; // ���i�Ǘ��敪�Q
                            row["STC2.STOCKNOTE1RF"] = detailWorks[index].STC2_STOCKNOTE1RF; // �݌ɔ��l�P
                            row["STC2.STOCKNOTE2RF"] = detailWorks[index].STC2_STOCKNOTE2RF; // �݌ɔ��l�Q
                            row["STC2.SHIPMENTPOSCNTRF"] = detailWorks[index].STC2_SHIPMENTPOSCNTRF; // �o�׉\��
                            row["SUP.SUPPLIERNM1RF"] = detailWorks[index].SUP_SUPPLIERNM1RF; // �d���於1
                            row["SUP.SUPPLIERNM2RF"] = detailWorks[index].SUP_SUPPLIERNM2RF; // �d���於2
                            row["SUP.SUPPHONORIFICTITLERF"] = detailWorks[index].SUP_SUPPHONORIFICTITLERF; // �d����h��
                            row["SUP.SUPPLIERKANARF"] = detailWorks[index].SUP_SUPPLIERKANARF; // �d����J�i
                            row["SUP.PURECODERF"] = detailWorks[index].SUP_PURECODERF; // �����敪
                            row["SUP.SUPPLIERNOTE1RF"] = detailWorks[index].SUP_SUPPLIERNOTE1RF; // �d������l1
                            row["SUP.SUPPLIERNOTE2RF"] = detailWorks[index].SUP_SUPPLIERNOTE2RF; // �d������l2
                            row["SUP.SUPPLIERNOTE3RF"] = detailWorks[index].SUP_SUPPLIERNOTE3RF; // �d������l3
                            row["SUP.SUPPLIERNOTE4RF"] = detailWorks[index].SUP_SUPPLIERNOTE4RF; // �d������l4
                            row["GDS.GOODSNAMEKANARF"] = detailWorks[index].GDS_GOODSNAMEKANARF; // ���i���̃J�i
                            row["GDS.JANRF"] = detailWorks[index].GDS_JANRF; // JAN�R�[�h
                            row["GDS.GOODSRATERANKRF"] = detailWorks[index].GDS_GOODSRATERANKRF; // ���i�|�������N
                            row["GDS.GOODSNONONEHYPHENRF"] = detailWorks[index].GDS_GOODSNONONEHYPHENRF; // �n�C�t�������i�ԍ�
                            row["GDS.GOODSNOTE1RF"] = detailWorks[index].GDS_GOODSNOTE1RF; // ���i���l�P
                            row["GDS.GOODSNOTE2RF"] = detailWorks[index].GDS_GOODSNOTE2RF; // ���i���l�Q
                            row["GDS.GOODSSPECIALNOTERF"] = detailWorks[index].GDS_GOODSSPECIALNOTERF; // ���i�K�i�E���L����
                            //row["DADD.STOCKDIVNMRF"] = detailWorks[index].DADD_STOCKDIVNMRF; // �݌ɋ敪����
                            //row["DADD.TAXATIONDIVCDNMRF"] = detailWorks[index].DADD_TAXATIONDIVCDNMRF; // �ېŋ敪����
                            //row["DADD.PURECODENMRF"] = detailWorks[index].DADD_PURECODENMRF; // �����敪����
                            //row["DADD.STOCKMOVEPRICERF"] = detailWorks[index].DADD_STOCKMOVEPRICERF; // �ړ����z
                            //row["DADD.STOCKMOVELISTPRICERF"] = detailWorks[index].DADD_STOCKMOVELISTPRICERF; // �ړ����z(�W�����i)
                            //row["DADD.BFSTOCKCOUNTPREVRF"] = detailWorks[index].DADD_BFSTOCKCOUNTPREVRF; // �ړ����ړ��O��
                            //row["DADD.BFSTOCKCOUNTRF"] = detailWorks[index].DADD_BFSTOCKCOUNTRF; // �ړ����ړ��㐔
                            //row["DADD.AFSTOCKCOUNTPREVRF"] = detailWorks[index].DADD_AFSTOCKCOUNTPREVRF; // �ړ���ړ��O��
                            //row["DADD.AFSTOCKCOUNTRF"] = detailWorks[index].DADD_AFSTOCKCOUNTRF; // �ړ���ړ��㐔
                            # endregion

                            # region [���׍���(�����ȊO)]

                            // ���ݒ莞 ��󎚃R�[�h
                            # region [���ݒ�]
                            // ���l�R�[�h
                            if ( IsZero( detailWorks[index].MOVD_SUPPLIERCDRF ) ) row["MOVD.SUPPLIERCDRF"] = DBNull.Value; // �d����R�[�h
                            if ( IsZero( detailWorks[index].MOVD_GOODSMAKERCDRF ) ) row["MOVD.GOODSMAKERCDRF"] = DBNull.Value; // ���i���[�J�[�R�[�h
                            if ( IsZero( detailWorks[index].MOVD_BLGOODSCODERF ) ) row["MOVD.BLGOODSCODERF"] = DBNull.Value; // BL���i�R�[�h
                            // ������R�[�h
                            if ( IsZero( detailWorks[index].MOVD_BFSECTIONCODERF ) ) row["MOVD.BFSECTIONCODERF"] = DBNull.Value; // �ړ������_�R�[�h
                            if ( IsZero( detailWorks[index].MOVD_BFENTERWAREHCODERF ) ) row["MOVD.BFENTERWAREHCODERF"] = DBNull.Value; // �ړ����q�ɃR�[�h
                            if ( IsZero( detailWorks[index].MOVD_AFSECTIONCODERF ) ) row["MOVD.AFSECTIONCODERF"] = DBNull.Value; // �ړ��拒�_�R�[�h
                            if ( IsZero( detailWorks[index].MOVD_AFENTERWAREHCODERF ) ) row["MOVD.AFENTERWAREHCODERF"] = DBNull.Value; // �ړ���q�ɃR�[�h
                            # endregion

                            // �敪����
                            # region [�敪����]
                            row["DADD.STOCKDIVNMRF"] = GetDADD_STOCKDIVNMRFRF( detailWorks[index].MOVD_STOCKDIVRF ); // �݌ɋ敪����
                            row["DADD.TAXATIONDIVCDNMRF"] = GetDADD_TAXATIONDIVCDNMRFRF( detailWorks[index].MOVD_TAXATIONDIVCDRF ); // �ېŋ敪����
                            row["DADD.PURECODENMRF"] = GetDADD_PURECODENMRFRF( detailWorks[index].SUP_PURECODERF ); // �����敪����
                            # endregion

                            // �ړ����z�E�ړ����z(�W�����i)
                            # region [���z]
                            row["DADD.STOCKMOVEPRICERF"] = detailWorks[index].DADD_STOCKMOVEPRICERF; // �ړ����z
                            row["DADD.STOCKMOVELISTPRICERF"] = detailWorks[index].DADD_STOCKMOVELISTPRICERF; // �ړ����z(�W�����i)
                            # endregion

                            // �ړ����E�ړ���̈ړ��O��݌ɐ�
                            # region [�ړ��O�㐔]
                            // 0:�ړ��ΏۊO�A1:���o�׏�ԁA2:�ړ����A9:���׍�
                            switch ( detailWorks[index].MOVD_MOVESTATUSRF )
                            {
                                case 1:
                                    {
                                        // ���o�׏��
                                        row["DADD.BFSTOCKCOUNTPREVRF"] = detailWorks[index].STC1_SHIPMENTPOSCNTRF; // �ړ����E�ړ��O��
                                        row["DADD.BFSTOCKCOUNTRF"] = detailWorks[index].STC1_SHIPMENTPOSCNTRF - detailWorks[index].MOVD_MOVECOUNTRF; // �ړ����E�ړ��㐔
                                        row["DADD.AFSTOCKCOUNTPREVRF"] = detailWorks[index].STC2_SHIPMENTPOSCNTRF; // �ړ���E�ړ��O��
                                        row["DADD.AFSTOCKCOUNTRF"] = detailWorks[index].STC2_SHIPMENTPOSCNTRF + detailWorks[index].MOVD_MOVECOUNTRF; // �ړ���E�ړ��㐔
                                    }
                                    break;
                                case 2:
                                    {
                                        // �ړ���
                                        row["DADD.BFSTOCKCOUNTPREVRF"] = detailWorks[index].STC1_SHIPMENTPOSCNTRF + detailWorks[index].MOVD_MOVECOUNTRF; // �ړ����E�ړ��O��
                                        row["DADD.BFSTOCKCOUNTRF"] = detailWorks[index].STC1_SHIPMENTPOSCNTRF; // �ړ����E�ړ��㐔
                                        row["DADD.AFSTOCKCOUNTPREVRF"] = detailWorks[index].STC2_SHIPMENTPOSCNTRF; // �ړ���E�ړ��O��
                                        row["DADD.AFSTOCKCOUNTRF"] = detailWorks[index].STC2_SHIPMENTPOSCNTRF + detailWorks[index].MOVD_MOVECOUNTRF; // �ړ���E�ړ��㐔
                                    }
                                    break;
                                case 9:
                                    {
                                        // ���׍�
                                        row["DADD.BFSTOCKCOUNTPREVRF"] = detailWorks[index].STC1_SHIPMENTPOSCNTRF + detailWorks[index].MOVD_MOVECOUNTRF; // �ړ����E�ړ��O��
                                        row["DADD.BFSTOCKCOUNTRF"] = detailWorks[index].STC1_SHIPMENTPOSCNTRF; // �ړ����E�ړ��㐔
                                        row["DADD.AFSTOCKCOUNTPREVRF"] = detailWorks[index].STC2_SHIPMENTPOSCNTRF - detailWorks[index].MOVD_MOVECOUNTRF; // �ړ���E�ړ��O��
                                        row["DADD.AFSTOCKCOUNTRF"] = detailWorks[index].STC2_SHIPMENTPOSCNTRF; // �ړ���E�ړ��㐔
                                    }
                                    break;
                                default:
                                    {
                                        // �󎚂��Ȃ�(DBNull������)
                                        row["DADD.BFSTOCKCOUNTPREVRF"] = DBNull.Value; // �ړ����E�ړ��O��
                                        row["DADD.BFSTOCKCOUNTRF"] = DBNull.Value; // �ړ����E�ړ��㐔
                                        row["DADD.AFSTOCKCOUNTPREVRF"] = DBNull.Value; // �ړ���E�ړ��O��
                                        row["DADD.AFSTOCKCOUNTRF"] = DBNull.Value; // �ړ���E�ړ��㐔
                                    }
                                    break;
                            }
                            # endregion

                            // �o�ɁE���Ƀ^�C�g��
                            # region [�o�ɁE���Ƀ^�C�g��]
                            // --- ADD  ���r��  2010/05/27 ---------->>>>>
                            if (titleDic.ContainsKey(ct_BfTitle))
                            {
                                row[ct_BfTitle] = titleDic[ct_BfTitle];
                            }
                            else
                            {
                                row[ct_BfTitle] = "�o";
                            }
                            if (titleDic.ContainsKey(ct_AfTitle))
                            {
                                row[ct_AfTitle] = titleDic[ct_AfTitle];
                            }
                            else
                            {
                                row[ct_AfTitle] = "��";
                            }
                            //row[ct_BfTitle] = "�o";
                            //row[ct_AfTitle] = "��";
                            // --- ADD  ���r��  2010/05/27 ----------<<<<<
                            # endregion

                            // ���p���Ή�
                            # region [���p���Ή�]
                            if ( string.IsNullOrEmpty( detailWorks[index].MOVD_GOODSNAMEKANARF ) )
                            {
                                row["MOVD.GOODSNAMEKANARF"] = detailWorks[index].MOVD_GOODSNAMERF; // �i���J�i���i���Z�b�g
                            }
                            # endregion

                            # endregion

                            # region [���׍���(�`�[�^�C�v�ʐݒ�)]
                            // �i��
                            if ( eachSlipTypeSet.GoodsNo == 0 )
                            {
                                row["MOVD.GOODSNORF"] = DBNull.Value; // ���i�ԍ�
                                row["GDS.GOODSNONONEHYPHENRF"] = DBNull.Value; // �n�C�t�������i�ԍ�
                            }
                            // �a�k�R�[�h
                            if ( eachSlipTypeSet.BLGoodsCode == 0 )
                            {
                                row["MOVD.BLGOODSCODERF"] = DBNull.Value; // BL���i�R�[�h
                                row["MOVD.BLGOODSFULLNAMERF"] = DBNull.Value; // BL���i�R�[�h���́i�S�p�j
                                row["BLGOODSCDURF.BLGOODSHALFNAMERF"] = DBNull.Value; // BL���i�R�[�h���́i���p�j
                            }
                            // �W�����i
                            if ( eachSlipTypeSet.ListPrice1 == 0 )
                            {
                                row["MOVD.LISTPRICEFLRF"] = DBNull.Value; // �艿�i�����j
                                row["DADD.STOCKMOVELISTPRICERF"] = DBNull.Value; // �ړ����z(�W�����i)
                            }
                            // ����
                            if ( eachSlipTypeSet.Cost == 0 )
                            {
                                row["MOVD.STOCKUNITPRICEFLRF"] = DBNull.Value; // �d���P���i�Ŕ�,�����j
                                row["DADD.STOCKMOVEPRICERF"] = DBNull.Value; // �ړ����z
                            }
                            # endregion
                        }
                        else
                        {
                            //-------------------------------------------
                            // �󖾍�
                            //-------------------------------------------
                        }

                        # region [���䍀��]
                        row[ct_InPageCopyTitle1] = inPageCopyTitle[0][inPageCopyCount];    // ���ʃ^�C�g��
                        row[ct_InPageCopyTitle2] = inPageCopyTitle[1][inPageCopyCount];    // ���ʃ^�C�g��
                        row[ct_InPageCopyTitle3] = inPageCopyTitle[2][inPageCopyCount];    // ���ʃ^�C�g��
                        row[ct_InPageCopyTitle4] = inPageCopyTitle[3][inPageCopyCount];    // ���ʃ^�C�g��
                        row[ct_InPageCopyCount] = (pageIndex * 10) + inPageCopyCount;    // ����y�[�W���R�s�[�J�E���g

                        // --- ADD ����� 2011/08/15---------->>>>>
                        // --- UPD m.suzuki 2011/09/27 ---------->>>>>
                        //if ( inPageCopyTitle[0].Count < 5 )
                        //{
                        //    for (int i = inPageCopyTitle[0].Count; i < 5; i++)
                        //    {
                        //        inPageCopyTitle[0].Add(string.Empty);
                        //    }
                        //}
                        //row[ct_SlipTitle11] = inPageCopyTitle[0][0]; // �^�C�g���P�E�P
                        //row[ct_SlipTitle12] = inPageCopyTitle[0][1]; // �^�C�g���P�E�Q
                        //row[ct_SlipTitle13] = inPageCopyTitle[0][2]; // �^�C�g���P�E�R
                        //row[ct_SlipTitle14] = inPageCopyTitle[0][3]; // �^�C�g���P�E�S
                        //row[ct_SlipTitle15] = inPageCopyTitle[0][4]; // �^�C�g���P�E�T

                        for ( int i = 0; i < inPageCopyTitle[0].Count; i++ )
                            {
                            row["PMZAI08001P.SLIPTITLE1" + (i + 1)] = inPageCopyTitle[0][i];
                            }
                        // --- UPD m.suzuki 2011/09/27 ----------<<<<<

                        row[ct_SlipTitle21] = inPageCopyTitle[1][0]; // �^�C�g���Q�E�P
                        row[ct_SlipTitle22] = inPageCopyTitle[1][1]; // �^�C�g���Q�E�Q
                        row[ct_SlipTitle23] = inPageCopyTitle[1][2]; // �^�C�g���Q�E�R
                        row[ct_SlipTitle24] = inPageCopyTitle[1][3]; // �^�C�g���Q�E�S
                        row[ct_SlipTitle25] = inPageCopyTitle[1][4]; // �^�C�g���Q�E�T

                        row[ct_SlipTitle31] = inPageCopyTitle[2][0]; // �^�C�g���R�E�P
                        row[ct_SlipTitle32] = inPageCopyTitle[2][1]; // �^�C�g���R�E�Q
                        row[ct_SlipTitle33] = inPageCopyTitle[2][2]; // �^�C�g���R�E�R
                        row[ct_SlipTitle34] = inPageCopyTitle[2][3]; // �^�C�g���R�E�S
                        row[ct_SlipTitle35] = inPageCopyTitle[2][4]; // �^�C�g���R�E�T

                        row[ct_SlipTitle41] = inPageCopyTitle[3][0]; // �^�C�g���S�E�P
                        row[ct_SlipTitle42] = inPageCopyTitle[3][1]; // �^�C�g���S�E�Q
                        row[ct_SlipTitle43] = inPageCopyTitle[3][2]; // �^�C�g���S�E�R
                        row[ct_SlipTitle44] = inPageCopyTitle[3][3]; // �^�C�g���S�E�S
                        row[ct_SlipTitle45] = inPageCopyTitle[3][4]; // �^�C�g���S�E�T
                        // --- ADD ����� 2011/08/15----------<<<<<
                        # endregion

                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/16 ADD
                        // �^�C�g���ʈ󎚐���Ή�
                        ReflectColumnVisibleType( ref row, columnVisibleTypeDic, inPageCopyCount );
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/16 ADD
                        # endregion

                        table.Rows.Add( row );
                    }

                    // --- ADD ����� 2011/08/15---------->>>>>
                    // �T�u���|�[�g���L��i�T�u���|�[�g�@�\�̏����j
                    if (subReportDic.Count > 0)
                    {
                        break;
                    }
                    // --- ADD ����� 2011/08/15----------<<<<<
                }

                pageStartIndex = Math.Min( pageEndIndex, printEndIndex ) + 1;
                pageEndIndex = pageStartIndex + feedCount - 1;
                printEndIndex = pageStartIndex + slipPrtSet.DetailRowCount - 1;
            }
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/16 ADD
        /// <summary>
        /// �^�C�g���ʈ󎚐���Ή�
        /// </summary>
        /// <param name="row"></param>
        /// <param name="columnVisibleTypeDic"></param>
        private static void ReflectColumnVisibleType( ref DataRow row, Dictionary<string, string> columnVisibleTypeDic, int inPageCopyCount )
        {
            foreach ( DataColumn column in row.Table.Columns )
            {
                string columnName = column.ColumnName.ToUpper();

                if ( columnVisibleTypeDic.ContainsKey( columnName ) )
                {
                    bool visible = false;

                    # region [�^�C�g����Visible�擾]
                    switch ( columnVisibleTypeDic[columnName] )
                    {
                        case "1":
                            if ( inPageCopyCount == 0 ) visible = true; break;
                        case "2":
                            if ( inPageCopyCount == 1 ) visible = true; break;
                        case "3":
                            if ( inPageCopyCount == 2 ) visible = true; break;
                        case "4":
                            if ( inPageCopyCount == 3 ) visible = true; break;
                        case "5":
                            if ( inPageCopyCount == 4 ) visible = true; break;
                        case "6":
                            if ( inPageCopyCount != 0 ) visible = true; break;
                        case "7":
                            if ( inPageCopyCount != 1 ) visible = true; break;
                        case "8":
                            if ( inPageCopyCount != 2 ) visible = true; break;
                        case "9":
                            if ( inPageCopyCount != 3 ) visible = true; break;
                        case "10":
                            if ( inPageCopyCount != 4 ) visible = true; break;
                        case "11":
                            if ( inPageCopyCount == 0 || inPageCopyCount == 1 ) visible = true; break;
                        case "12":
                            if ( inPageCopyCount == 0 || inPageCopyCount == 1 || inPageCopyCount == 2 ) visible = true; break;
                        case "13":
                            if ( inPageCopyCount == 2 || inPageCopyCount == 3 || inPageCopyCount == 4 ) visible = true; break;
                        case "14":
                            if ( inPageCopyCount == 3 || inPageCopyCount == 4 ) visible = true; break;
                        default:
                            visible = true; break;
                    }
                    # endregion

                    // �󎚃L�����Z��
                    if ( visible == false )
                    {
                        row[columnName] = DBNull.Value;
                    }
                }
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/16 ADD
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/16 ADD
        /// <summary>
        /// ���Ж��̕�������
        /// </summary>
        /// <param name="originName"></param>
        /// <param name="firstHalf"></param>
        /// <param name="lastHalf"></param>
        private static void DivideEnterpriseName( string originName, out string firstHalf, out string lastHalf )
        {
            // �m�r�̓}�X�^�ݒ�ł̓��͉\���������p�E�S�p��ʂ��Ȃ��d�l�Ȃ̂�
            // �o�C�g���ł͂Ȃ��������ŕ�������B

            const int fullLength = 20;
            const int divideLength = 10;

            // �X�y�[�X�ŋl�߂�
            originName = originName.PadRight( fullLength, ' ' );
            // ����
            firstHalf = originName.Substring( 0, divideLength ).TrimEnd();
            lastHalf = originName.Substring( divideLength, divideLength ).TrimEnd();
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/16 ADD

        /// <summary>
        /// �ړ����z
        /// </summary>
        /// <param name="frePStockMoveDetailWork"></param>
        /// <returns></returns>
        private static Int64 GetSTOCKMOVEPRICERF( FrePStockMoveDetailWork frePStockMoveDetailWork )
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/22 DEL
            //decimal unitPrice = (decimal)frePStockMoveDetailWork.MOVD_STOCKUNITPRICEFLRF; // �d���P���i�Ŕ�,�����j
            //decimal moveCount = (decimal)frePStockMoveDetailWork.MOVD_MOVECOUNTRF; // �ړ���
            //return (Int64)Round( unitPrice * moveCount );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/22 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/22 ADD
            return frePStockMoveDetailWork.MOVD_STOCKMOVEPRICERF;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/22 ADD
        }
        /// <summary>
        /// �ړ����z�i�W�����i�j
        /// </summary>
        /// <param name="frePStockMoveDetailWork"></param>
        /// <returns></returns>
        private static Int64 GetSTOCKMOVELISTPRICERF( FrePStockMoveDetailWork frePStockMoveDetailWork )
        {
            decimal unitPrice = (decimal)frePStockMoveDetailWork.MOVD_LISTPRICEFLRF; // �艿�i�����j
            decimal moveCount = (decimal)frePStockMoveDetailWork.MOVD_MOVECOUNTRF; // �ړ���
            return (Int64)Round( unitPrice * moveCount );
        }
        /// <summary>
        /// ���ʃ^�C�g���擾����
        /// </summary>
        /// <param name="slipPrtSet"></param>
        /// <returns></returns>
        private static List<List<string>> GetInPageCopyTitles( SlipPrtSetWork slipPrtSet )
        {
            //*********************************************************************
            // ���ʂP���ڂ̃^�C�g�����ɂ���āA1�y�[�W���̃R�s�[�������肷��ׁA
            // �P���ڂ̂� string.Empty �̔�����s���܂��B
            // 
            // �Q���ڈȍ~�͂P�y�[�W���R�s�[���ւ̉e���������̂ŁA���̂܂ܑS�ăZ�b�g���܂��B
            //*********************************************************************

            List<List<string>> retList = new List<List<string>>();
            List<string> retList1 = new List<string>();

            //----------------------------------------------
            // ���ʂP���ڂ̃^�C�g���Q
            //----------------------------------------------
            retList1.Add( slipPrtSet.TitleName1 );
            List<string> title1List = new List<string>( new string[] { slipPrtSet.TitleName102, slipPrtSet.TitleName103, slipPrtSet.TitleName104, slipPrtSet.TitleName105 } );
            for ( int index = 0; index < title1List.Count; index++ )
            {
                // �󔒂�����΂����ŏI��
                if ( title1List[index] == string.Empty ) break;
                // �P�ǉ�
                retList1.Add( title1List[index] );
            }
            retList.Add( retList1 );

            //----------------------------------------------
            // ���ʂQ���ڈȍ~�̓x�^�ŃR�s�[����
            //----------------------------------------------
            retList.Add( new List<string>( new string[] { slipPrtSet.TitleName2, slipPrtSet.TitleName202, slipPrtSet.TitleName203, slipPrtSet.TitleName204, slipPrtSet.TitleName205 } ) );
            retList.Add( new List<string>( new string[] { slipPrtSet.TitleName3, slipPrtSet.TitleName302, slipPrtSet.TitleName303, slipPrtSet.TitleName304, slipPrtSet.TitleName305 } ) );
            retList.Add( new List<string>( new string[] { slipPrtSet.TitleName4, slipPrtSet.TitleName402, slipPrtSet.TitleName403, slipPrtSet.TitleName404, slipPrtSet.TitleName405 } ) );

            // �ԋp
            return retList;
        }
        /// <summary>
        /// ���ב��s���̎Z�o
        /// </summary>
        /// <param name="dataCount"></param>
        /// <param name="feedCount"></param>
        /// <returns></returns>
        private static int GetAllDetailCount( int dataCount, int feedCount )
        {
            if ( dataCount % feedCount == 0 )
            {
                // ����؂�� �� �f�[�^�s���Ɩ��ב��s���̓C�R�[���łn�j
                return dataCount;
            }
            else
            {
                // ����؂�Ȃ� �� �K�v�ȗ]�����܂߂����׍s����Ԃ�
                return (dataCount + (feedCount - (dataCount % feedCount)));
            }
        }
        /// <summary>
        /// ���݃y�[�W���擾
        /// </summary>
        /// <param name="index"></param>
        /// <param name="feedCount"></param>
        /// <returns></returns>
        private static int GetPageCount( int index, int feedCount )
        {
            return (index / feedCount) + 1;
        }
        # endregion

        # region [�e��敪���̎擾]
        /// <summary>
        /// �݌Ɉړ��`������
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private static string GetHADD_STOCKMOVEFORMALNMRFRF( int code )
        {
            // 1:�݌Ɉړ��A2�F�q�Ɉړ�
            switch ( code )
            {
                case 1:
                    return "�݌Ɉړ�";
                case 2:
                    return "�q�Ɉړ�";
                default:
                    return string.Empty;
            }
        }
        /// <summary>
        /// �݌ɋ敪����
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private static string GetDADD_STOCKDIVNMRFRF( int code )
        {
            // 0:���ЁA1:���
            switch ( code )
            {
                case 0:
                    return "����";
                case 1:
                    return "���";
                default:
                    return string.Empty;
            }
        }
        /// <summary>
        /// �ېŋ敪����
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private static string GetDADD_TAXATIONDIVCDNMRFRF( int code )
        {
            // 0:�O��,1:��ې�,2:����
            switch ( code )
            {
                case 0:
                    return "�O��";
                case 1:
                    return "��ې�";
                case 2:
                    return "����";
                default:
                    return string.Empty;
            }
        }
        /// <summary>
        /// �����敪����
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private static string GetDADD_PURECODENMRFRF( int code )
        {
            // 0:�����A1:�D��
            switch ( code )
            {
                case 0:
                    return "����";
                case 1:
                    return "�D��";
                default:
                    return string.Empty;
            }
        }
        # endregion

        # region [���t�֘A���� �W�J����]
        /// <summary>
        /// ���t�֘A���ځ@�W�J
        /// </summary>
        /// <param name="targetRow"></param>
        /// <param name="eraNameDispCd"></param>
        /// <param name="date"></param>
        /// <param name="dateColumnName"></param>
        /// <param name="isMonth"></param>
        private static void ExtractDate( ref DataRow targetRow, int eraNameDispCd, DateTime date, string dateColumnName, bool isMonth )
        {
            // DateTime��Ή�����Int�l�ɕϊ�
            int dateInt = 0;
            if ( date != DateTime.MinValue )
            {
                if ( !isMonth )
                {
                    dateInt = (date.Year * 10000) + (date.Month * 100) + (date.Day);
                }
                else
                {
                    dateInt = (date.Year * 100) + (date.Month);
                }
            }

            // ���t�W�J���\�b�h�ɓn��
            ExtractDate( ref targetRow, eraNameDispCd, dateInt, dateColumnName, isMonth );
        }
        /// <summary>
        /// ���t�֘A���ځ@�W�J
        /// </summary>
        /// <param name="targetRow"></param>
        /// <param name="eraNameDispCd">0:����@1:�a��</param>
        /// <param name="date"></param>
        /// <param name="dateColumnName"></param>
        /// <param name="isMonth"></param>
        private static void ExtractDate( ref DataRow targetRow, int eraNameDispCd, int date, string dateColumnName, bool isMonth )
        {
            //-------------------------------------------------------------------
            // �y���ڂ̈󎚗L���z
            //         YMD YM Y
            // 2009    ���@���@��
            // 01      ���@���@�~
            // 31      ���@�~�@�~
            // �N      ���@���@��
            // ��      ���@���@�~
            // ��      ���@�~�@�~
            // /       ���@���@�~
            // .       ���@���@�~
            // ����    ���@���@��
            // H       ���@���@��
            // 21      ���@���@��
            //-------------------------------------------------------------------

            // --- DEL  ���r��  2010/03/31 ---------->>>>>
            // �a��t���O
            //bool jpEra = (eraNameDispCd == 1);
            // --- DEL  ���r��  2010/03/31 ----------<<<<<
            // --- ADD  ���r��  2010/03/31 ---------->>>>>
            bool jpEra;
            if (!ReportItemDic.ContainsKey(string.Format("{0}{1}RF", dateColumnName, "FW")))
            {
                // "�a��N"���ڂ�����������Œ�
                jpEra = false;
            }
            else if (!ReportItemDic.ContainsKey(string.Format("{0}{1}RF", dateColumnName, "FY")) &&
                      !ReportItemDic.ContainsKey(string.Format("{0}{1}RF", dateColumnName, "FS")))
            {
                // "����N"�E"����N��"���ڂ������������a��Œ�
                jpEra = true;
            }
            else
            {
                // �ʏ�͋敪�l�ɏ]��
                jpEra = (eraNameDispCd == 1);
            }
            // --- ADD  ���r��  2010/03/31 ----------<<<<<
            // �N�̂ݔ���t���O
            bool isYear = false;

            if ( date != 0 )
            {
                // �N�����ڂ̏ꍇ�́A�a��ϊ��ɔ����Ďw��N���̍ŏI���ɕϊ�����
                if ( isMonth )
                {
                    // �N�̂ݔ���("200900"��2009�N)
                    isYear = (date % 100 == 0);

                    if ( isYear )
                    {
                        //-----------------------------------------------
                        // �N�̂�
                        //-----------------------------------------------

                        // �w��N���̓��������߂�(=���̔N�̍ŏI��)��12/31�ł����O�̂��߁c
                        int dd = DateTime.DaysInMonth( date / 100, 12 );

                        // YYYYMMDD�ɂ���
                        date = ((int)(date / 100) * 10000) + (12 * 100) + dd;
                    }
                    else
                    {
                        //-----------------------------------------------
                        // �N���̂�
                        //-----------------------------------------------

                        // �w��N���̓��������߂�(=���̌��̍ŏI��)
                        int dd = DateTime.DaysInMonth( date / 100, date % 100 );

                        // YYYYMMDD�ɂ���
                        date = (date * 100) + dd;
                    }
                }

                // �N�i�a��or����j
                if ( jpEra )
                {
                    // �a��
                    targetRow[string.Format( "{0}{1}RF", dateColumnName, "FW" )] = GetDateFW( date ); // �a��N
                    targetRow[string.Format( "{0}{1}RF", dateColumnName, "FG" )] = TDateTime.LongDateToString( "GG", date ); // �a���
                    targetRow[string.Format( "{0}{1}RF", dateColumnName, "FR" )] = TDateTime.LongDateToString( "gg", date ); // �a�������
                    // �N���A
                    targetRow[string.Format( "{0}{1}RF", dateColumnName, "FY" )] = DBNull.Value;
                    targetRow[string.Format( "{0}{1}RF", dateColumnName, "FS" )] = DBNull.Value;
                }
                else
                {
                    // ����
                    targetRow[string.Format( "{0}{1}RF", dateColumnName, "FY" )] = (date / 10000); // ����N
                    targetRow[string.Format( "{0}{1}RF", dateColumnName, "FS" )] = (date / 10000) % 100; // ����N(��)
                    // �N���A
                    targetRow[string.Format( "{0}{1}RF", dateColumnName, "FW" )] = DBNull.Value;
                    targetRow[string.Format( "{0}{1}RF", dateColumnName, "FG" )] = DBNull.Value;
                    targetRow[string.Format( "{0}{1}RF", dateColumnName, "FR" )] = DBNull.Value;
                }

                // �N���e����
                targetRow[string.Format( "{0}{1}RF", dateColumnName, "FLY" )] = "�N";

                if ( !isYear )
                {
                    // ��
                    targetRow[string.Format( "{0}{1}RF", dateColumnName, "FM" )] = (date / 100) % 100; // ��

                    // ���e�����n
                    targetRow[string.Format( "{0}{1}RF", dateColumnName, "FLS" )] = "/";
                    targetRow[string.Format( "{0}{1}RF", dateColumnName, "FLP" )] = ".";
                    targetRow[string.Format( "{0}{1}RF", dateColumnName, "FLM" )] = "��";

                    if ( !isMonth )
                    {
                        targetRow[string.Format( "{0}{1}RF", dateColumnName, "FD" )] = (date % 100); // ��
                        targetRow[string.Format( "{0}{1}RF", dateColumnName, "FLD" )] = "��";
                    }
                }
            }
            else
            {
                // �����ȓ��t�Ȃ�΋�
                targetRow[string.Format( "{0}{1}RF", dateColumnName, "FY" )] = DBNull.Value;
                targetRow[string.Format( "{0}{1}RF", dateColumnName, "FS" )] = DBNull.Value;
                targetRow[string.Format( "{0}{1}RF", dateColumnName, "FW" )] = DBNull.Value;
                targetRow[string.Format( "{0}{1}RF", dateColumnName, "FM" )] = DBNull.Value;
                targetRow[string.Format( "{0}{1}RF", dateColumnName, "FG" )] = DBNull.Value;
                targetRow[string.Format( "{0}{1}RF", dateColumnName, "FR" )] = DBNull.Value;
                targetRow[string.Format( "{0}{1}RF", dateColumnName, "FLS" )] = DBNull.Value;
                targetRow[string.Format( "{0}{1}RF", dateColumnName, "FLP" )] = DBNull.Value;
                targetRow[string.Format( "{0}{1}RF", dateColumnName, "FLY" )] = DBNull.Value;
                targetRow[string.Format( "{0}{1}RF", dateColumnName, "FLM" )] = DBNull.Value;

                if ( !isMonth )
                {
                    targetRow[string.Format( "{0}{1}RF", dateColumnName, "FD" )] = DBNull.Value;
                    targetRow[string.Format( "{0}{1}RF", dateColumnName, "FLD" )] = DBNull.Value;
                }
            }
        }

        /// <summary>
        /// �a��N�擾�����iH20��"20"�݂̂��擾����j
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        private static int GetDateFW( int date )
        {
            // �a������擾
            string date_gg = TDateTime.LongDateToString( "gg", date );  // H
            string date_exggyy = TDateTime.LongDateToString( "exggyy", date );  // H20

            // "H20" ���� "H" ����菜���� "20" ���擾����
            return ToInt( date_exggyy.Substring( date_gg.Length, date_exggyy.Length - date_gg.Length ) );

        }
        /// <summary>
        /// ���l�ϊ�����
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private static int ToInt( string text )
        {
            try
            {
                return Int32.Parse( text );
            }
            catch
            {
                return 0;
            }
        }

        # endregion

        # region [���ʏ���]
        /// <summary>
        /// �l�̌ܓ�����
        /// </summary>
        /// <param name="parameter">�[����������decimal�l</param>
        /// <returns>�l�̌ܓ����ꂽdecimal</returns>
        public static decimal Round( decimal parameter )
        {
            // �l�̌ܓ�
            return Round( parameter, 0, 5 );
        }
        /// <summary>
        /// �l�̌ܓ�����
        /// </summary>
        /// <param name="parameter">�[����������Double�l</param>
        /// <param name="digits">�����_�ȉ��̗L������</param>
        /// <param name="divide">�؂�グ�鋫�E�̒l 1�`9�@(ex. 5���l�̌ܓ�)</param>
        /// <returns>�l�̌ܓ����ꂽdecimal</returns>
        public static decimal Round( decimal parameter, int digits, int divide )
        {
            decimal dCoef = (decimal)Math.Pow( 10, digits );
            decimal dDiv = 1.0m - ((decimal)divide / 10);

            if ( parameter > 0 )
            {
                // 0.5�𑫂��āu�{�̂Ƃ��̐؂�̂āv�i�[���ɋ߂Â���j
                return Math.Floor( (parameter * dCoef) + dDiv ) / dCoef;
            }
            else
            {
                // -0.5�𑫂��āu�|�̂Ƃ��̐؂�̂āv�i�[���ɋ߂Â���j
                return Math.Ceiling( (parameter * dCoef) - dDiv ) / dCoef;
            }
        }
        /// <summary>
        /// ������R�[�h�̃[������
        /// </summary>
        /// <param name="textValue"></param>
        /// <returns></returns>
        private static bool IsZero( string textValue )
        {
            if ( textValue == null || textValue.Trim() == string.Empty ) return true;

            try
            {
                return (Int32.Parse( textValue ) == 0);
            }
            catch
            {
                return true;
            }
        }
        /// <summary>
        /// ���l�R�[�h�̃[������
        /// </summary>
        /// <param name="intValue"></param>
        /// <returns></returns>
        private static bool IsZero( int intValue )
        {
            return (intValue == 0);
        }
        # endregion
    }
}

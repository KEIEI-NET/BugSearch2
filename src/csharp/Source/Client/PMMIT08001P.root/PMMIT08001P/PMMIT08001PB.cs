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
using Broadleaf.Application.UIData;

namespace Broadleaf.Drawing.Printing
{
	/// <summary>
	/// ���R���[(���Ϗ�)����N���X
	/// </summary>
	/// <remarks>
    /// <br>Note         : ���DataSource�̃e�[�u���������s���܂��B</br>
    /// <br>               </br>
	/// <br>Programmer   : 22018 ��؁@���b</br>
	/// <br>Date         : 2008.06.03</br>
	/// <br></br>
	/// <br>Update Note  : 2010.03.08 22018 ���  ���b</br>
    /// <br>             : �������̑Ή��B�i�o�l�V�p�b�P�[�W���l�̓��Ӑ於�̂̐����g�ݍ��݁j</br>
    /// <br></br>
    /// </remarks>
	internal class PMMIT08001PB
    {
        # region [public static readonly �����o]
        /// <summary>���R���[���Ϗ��e�[�u��</summary>
        public static readonly string ct_TBL_FREPESTFM = "FREPESTFM";
        /// <summary>����y�[�W���R�s�[�J�E���gcolumn����</summary>
        public static readonly string ct_InPageCopyCount = "PMMIT08001P.INPAGECOPYCOUNT";
        /// <summary>���ʃ^�C�g���P</summary>
        public static readonly string ct_InPageCopyTitle1 = "PMMIT08001P.INPAGECOPYTITLE1";
        /// <summary>���ʃ^�C�g���Q</summary>
        public static readonly string ct_InPageCopyTitle2 = "PMMIT08001P.INPAGECOPYTITLE2";
        /// <summary>���ʃ^�C�g���R</summary>
        public static readonly string ct_InPageCopyTitle3 = "PMMIT08001P.INPAGECOPYTITLE3";
        /// <summary>���ʃ^�C�g���S</summary>
        public static readonly string ct_InPageCopyTitle4 = "PMMIT08001P.INPAGECOPYTITLE4";
        /// <summary>�Ő�</summary>
        public static readonly string ct_PageCount = "PAGE.PAGECOUNTRF";
        /// <summary>(�擪)�ޕʌ^���n�C�t��</summary>
        public static readonly string ct_HCategoryHyp = "HPRT.CATEGORYHYPRF";
        /// <summary>���Ӑ於�P�{���Ӑ於�Q</summary>
        public static readonly string ct_HPrintCustomerNameJoin12 = "HPRT.PRINTCUSTOMERNAMEJOIN12RF";
        /// <summary>���Ӑ於�P�{���Ӑ於�Q�{�h��</summary>
        public static readonly string ct_HPrintCustomerNameJoinHn12 = "HPRT.PRINTCUSTOMERNAMEJOIN12HNRF";
        /// <summary>���Ж��P�i�O���j</summary>
        public static readonly string ct_HPrintEnterpriseName1FH = "HPRT.PRINTENTERPRISENAME1FHRF";
        /// <summary>���Ж��P�i�㔼�j</summary>
        public static readonly string ct_HPrintEnterpriseName1LH = "HPRT.PRINTENTERPRISENAME1LHRF";
        /// <summary>���Ж��Q�i�O���j</summary>
        public static readonly string ct_HPrintEnterpriseName2FH = "HPRT.PRINTENTERPRISENAME2FHRF";
        /// <summary>���Ж��Q�i�㔼�j</summary>
        public static readonly string ct_HPrintEnterpriseName2LH = "HPRT.PRINTENTERPRISENAME2LHRF";
        # endregion

        # region [�f�[�^�e�[�u������]
        /// <summary>
        /// �f�[�^�e�[�u�����������i�X�L�[�}��`�j
        /// </summary>
        /// <remarks></remarks>
        public static DataTable CreateFrePEstFmHeadTable( int subNo )
        {
            DataTable table = new DataTable( ct_TBL_FREPESTFM + subNo.ToString() );
            
            # region [�X�L�[�}��`�i�`�[���ځj]
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SALESSLIPNUMRF", typeof( String ) ) ); // ����`�[�ԍ�
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SECTIONCODERF", typeof( String ) ) ); // ���_�R�[�h
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SALESDATERF", typeof( Int32 ) ) ); // ������t
            table.Columns.Add( new DataColumn( "SALESSLIPRF.ESTIMATEFORMNORF", typeof( String ) ) ); // ���Ϗ��ԍ�
            table.Columns.Add( new DataColumn( "SALESSLIPRF.ESTIMATEDIVIDERF", typeof( Int32 ) ) ); // ���ϋ敪
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SALESINPUTCODERF", typeof( String ) ) ); // ������͎҃R�[�h
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SALESINPUTNAMERF", typeof( String ) ) ); // ������͎Җ���
            table.Columns.Add( new DataColumn( "SALESSLIPRF.FRONTEMPLOYEECDRF", typeof( String ) ) ); // ��t�]�ƈ��R�[�h
            table.Columns.Add( new DataColumn( "SALESSLIPRF.FRONTEMPLOYEENMRF", typeof( String ) ) ); // ��t�]�ƈ�����
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SALESEMPLOYEECDRF", typeof( String ) ) ); // �̔��]�ƈ��R�[�h
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SALESEMPLOYEENMRF", typeof( String ) ) ); // �̔��]�ƈ�����
            table.Columns.Add( new DataColumn( "SALESSLIPRF.CONSTAXLAYMETHODRF", typeof( Int32 ) ) ); // ����œ]�ŕ���
            table.Columns.Add( new DataColumn( "SALESSLIPRF.CUSTOMERCODERF", typeof( Int32 ) ) ); // ���Ӑ�R�[�h
            table.Columns.Add( new DataColumn( "SALESSLIPRF.CUSTOMERNAMERF", typeof( String ) ) ); // ���Ӑ於��
            table.Columns.Add( new DataColumn( "SALESSLIPRF.CUSTOMERNAME2RF", typeof( String ) ) ); // ���Ӑ於��2
            table.Columns.Add( new DataColumn( "SALESSLIPRF.CUSTOMERSNMRF", typeof( String ) ) ); // ���Ӑ旪��
            table.Columns.Add( new DataColumn( "SALESSLIPRF.HONORIFICTITLERF", typeof( String ) ) ); // ���Ӑ�h��
            table.Columns.Add( new DataColumn( "SALESSLIPRF.SALESSLIPPRINTDATERF", typeof( Int32 ) ) ); // ����`�[���s��
            table.Columns.Add( new DataColumn( "SALESSLIPRF.TOTALAMOUNTDISPWAYCDRF", typeof( Int32 ) ) ); // ���z�\�����@�敪
            table.Columns.Add( new DataColumn( "SECINFOSETRF.SECTIONGUIDENMRF", typeof( String ) ) ); // ���_�K�C�h����
            table.Columns.Add( new DataColumn( "COMPANYNMRF.COMPANYPRRF", typeof( String ) ) ); // ���_����PR��
            table.Columns.Add( new DataColumn( "COMPANYNMRF.COMPANYNAME1RF", typeof( String ) ) ); // ���_���Ж���1
            table.Columns.Add( new DataColumn( "COMPANYNMRF.COMPANYNAME2RF", typeof( String ) ) ); // ���_���Ж���2
            table.Columns.Add( new DataColumn( "COMPANYNMRF.POSTNORF", typeof( String ) ) ); // ���_�X�֔ԍ�
            table.Columns.Add( new DataColumn( "COMPANYNMRF.ADDRESS1RF", typeof( String ) ) ); // ���_�Z��1�i�s���{���s��S�E�����E���j
            table.Columns.Add( new DataColumn( "COMPANYNMRF.ADDRESS3RF", typeof( String ) ) ); // ���_�Z��3�i�Ԓn�j
            table.Columns.Add( new DataColumn( "COMPANYNMRF.ADDRESS4RF", typeof( String ) ) ); // ���_�Z��4�i�A�p�[�g���́j
            table.Columns.Add( new DataColumn( "COMPANYNMRF.COMPANYTELNO1RF", typeof( String ) ) ); // ���_���Гd�b�ԍ�1
            table.Columns.Add( new DataColumn( "COMPANYNMRF.COMPANYTELNO2RF", typeof( String ) ) ); // ���_���Гd�b�ԍ�2
            table.Columns.Add( new DataColumn( "COMPANYNMRF.COMPANYTELNO3RF", typeof( String ) ) ); // ���_���Гd�b�ԍ�3
            table.Columns.Add( new DataColumn( "COMPANYNMRF.COMPANYTELTITLE1RF", typeof( String ) ) ); // ���_���Гd�b�ԍ��^�C�g��1
            table.Columns.Add( new DataColumn( "COMPANYNMRF.COMPANYTELTITLE2RF", typeof( String ) ) ); // ���_���Гd�b�ԍ��^�C�g��2
            table.Columns.Add( new DataColumn( "COMPANYNMRF.COMPANYTELTITLE3RF", typeof( String ) ) ); // ���_���Гd�b�ԍ��^�C�g��3
            table.Columns.Add( new DataColumn( "COMPANYNMRF.TRANSFERGUIDANCERF", typeof( String ) ) ); // ���_��s�U���ē���
            table.Columns.Add( new DataColumn( "COMPANYNMRF.ACCOUNTNOINFO1RF", typeof( String ) ) ); // ���_��s����1
            table.Columns.Add( new DataColumn( "COMPANYNMRF.ACCOUNTNOINFO2RF", typeof( String ) ) ); // ���_��s����2
            table.Columns.Add( new DataColumn( "COMPANYNMRF.ACCOUNTNOINFO3RF", typeof( String ) ) ); // ���_��s����3
            table.Columns.Add( new DataColumn( "COMPANYNMRF.COMPANYSETNOTE1RF", typeof( String ) ) ); // ���_���Аݒ�E�v1
            table.Columns.Add( new DataColumn( "COMPANYNMRF.COMPANYSETNOTE2RF", typeof( String ) ) ); // ���_���Аݒ�E�v2
            table.Columns.Add( new DataColumn( "COMPANYNMRF.COMPANYURLRF", typeof( String ) ) ); // ���_����URL
            table.Columns.Add( new DataColumn( "COMPANYNMRF.COMPANYPRSENTENCE2RF", typeof( String ) ) ); // ���_����PR��2
            table.Columns.Add( new DataColumn( "COMPANYNMRF.IMAGECOMMENTFORPRT1RF", typeof( String ) ) ); // ���_�摜�󎚗p�R�����g1
            table.Columns.Add( new DataColumn( "COMPANYNMRF.IMAGECOMMENTFORPRT2RF", typeof( String ) ) ); // ���_�摜�󎚗p�R�����g2
            table.Columns.Add( new DataColumn( "IMAGEINFORF.IMAGEINFODATARF", typeof( Byte[] ) ) ); // ���_���Љ摜
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
            table.Columns.Add( new DataColumn( "HEST.FOOTNOTES1RF", typeof( String ) ) ); // �r���P
            table.Columns.Add( new DataColumn( "HEST.FOOTNOTES2RF", typeof( String ) ) ); // �r���Q
            table.Columns.Add( new DataColumn( "HEST.ESTIMATETITLE1RF", typeof( String ) ) ); // ���σ^�C�g���P
            table.Columns.Add( new DataColumn( "HEST.ESTIMATETITLE2RF", typeof( String ) ) ); // ���σ^�C�g���Q
            table.Columns.Add( new DataColumn( "HEST.ESTIMATETITLE3RF", typeof( String ) ) ); // ���σ^�C�g���R
            table.Columns.Add( new DataColumn( "HEST.ESTIMATETITLE4RF", typeof( String ) ) ); // ���σ^�C�g���S
            table.Columns.Add( new DataColumn( "HEST.ESTIMATETITLE5RF", typeof( String ) ) ); // ���σ^�C�g���T
            table.Columns.Add( new DataColumn( "HEST.ESTIMATENOTE1RF", typeof( String ) ) ); // ���ϔ��l�P
            table.Columns.Add( new DataColumn( "HEST.ESTIMATENOTE2RF", typeof( String ) ) ); // ���ϔ��l�Q
            table.Columns.Add( new DataColumn( "HEST.ESTIMATENOTE3RF", typeof( String ) ) ); // ���ϔ��l�R
            table.Columns.Add( new DataColumn( "HEST.ESTIMATENOTE4RF", typeof( String ) ) ); // ���ϔ��l�S
            table.Columns.Add( new DataColumn( "HEST.ESTIMATENOTE5RF", typeof( String ) ) ); // ���ϔ��l�T
            table.Columns.Add( new DataColumn( "HEST.ESTIMATEVALIDITYLIMITRF", typeof( Int32 ) ) ); // ���Ϗ��L������
            table.Columns.Add( new DataColumn( "HEST.ESTIMATEVALIDITYLIMITFYRF", typeof( Int32 ) ) ); // ���Ϗ��L����������N
            table.Columns.Add( new DataColumn( "HEST.ESTIMATEVALIDITYLIMITFSRF", typeof( Int32 ) ) ); // ���Ϗ��L����������N��
            table.Columns.Add( new DataColumn( "HEST.ESTIMATEVALIDITYLIMITFWRF", typeof( Int32 ) ) ); // ���Ϗ��L�������a��N
            table.Columns.Add( new DataColumn( "HEST.ESTIMATEVALIDITYLIMITFMRF", typeof( Int32 ) ) ); // ���Ϗ��L��������
            table.Columns.Add( new DataColumn( "HEST.ESTIMATEVALIDITYLIMITFDRF", typeof( Int32 ) ) ); // ���Ϗ��L��������
            table.Columns.Add( new DataColumn( "HEST.ESTIMATEVALIDITYLIMITFGRF", typeof( String ) ) ); // ���Ϗ��L����������
            table.Columns.Add( new DataColumn( "HEST.ESTIMATEVALIDITYLIMITFRRF", typeof( String ) ) ); // ���Ϗ��L����������
            table.Columns.Add( new DataColumn( "HEST.ESTIMATEVALIDITYLIMITFLSRF", typeof( String ) ) ); // ���Ϗ��L���������e����(/)
            table.Columns.Add( new DataColumn( "HEST.ESTIMATEVALIDITYLIMITFLPRF", typeof( String ) ) ); // ���Ϗ��L���������e����(.)
            table.Columns.Add( new DataColumn( "HEST.ESTIMATEVALIDITYLIMITFLYRF", typeof( String ) ) ); // ���Ϗ��L���������e����(�N)
            table.Columns.Add( new DataColumn( "HEST.ESTIMATEVALIDITYLIMITFLMRF", typeof( String ) ) ); // ���Ϗ��L���������e����(��)
            table.Columns.Add( new DataColumn( "HEST.ESTIMATEVALIDITYLIMITFLDRF", typeof( String ) ) ); // ���Ϗ��L���������e����(��)
            table.Columns.Add( new DataColumn( "HADD.CARMNGNORF", typeof( Int32 ) ) ); // �ԗ��Ǘ��ԍ�
            table.Columns.Add( new DataColumn( "HADD.CARMNGCODERF", typeof( String ) ) ); // ���q�Ǘ��R�[�h
            table.Columns.Add( new DataColumn( "HADD.NUMBERPLATE1CODERF", typeof( Int32 ) ) ); // ���^�������ԍ�
            table.Columns.Add( new DataColumn( "HADD.NUMBERPLATE1NAMERF", typeof( String ) ) ); // ���^�����ǖ���
            table.Columns.Add( new DataColumn( "HADD.NUMBERPLATE2RF", typeof( String ) ) ); // �ԗ��o�^�ԍ��i��ʁj
            table.Columns.Add( new DataColumn( "HADD.NUMBERPLATE3RF", typeof( String ) ) ); // �ԗ��o�^�ԍ��i�J�i�j
            table.Columns.Add( new DataColumn( "HADD.NUMBERPLATE4RF", typeof( Int32 ) ) ); // �ԗ��o�^�ԍ��i�v���[�g�ԍ��j
            table.Columns.Add( new DataColumn( "HADD.FIRSTENTRYDATERF", typeof( Int32 ) ) ); // ���N�x
            table.Columns.Add( new DataColumn( "HADD.MAKERCODERF", typeof( Int32 ) ) ); // ���[�J�[�R�[�h
            table.Columns.Add( new DataColumn( "HADD.MAKERFULLNAMERF", typeof( String ) ) ); // ���[�J�[�S�p����
            table.Columns.Add( new DataColumn( "HADD.MAKERHALFNAMERF", typeof( String ) ) ); // ���[�J�[���p����
            table.Columns.Add( new DataColumn( "HADD.MODELCODERF", typeof( Int32 ) ) ); // �Ԏ�R�[�h
            table.Columns.Add( new DataColumn( "HADD.MODELSUBCODERF", typeof( Int32 ) ) ); // �Ԏ�T�u�R�[�h
            table.Columns.Add( new DataColumn( "HADD.MODELFULLNAMERF", typeof( String ) ) ); // �Ԏ�S�p����
            table.Columns.Add( new DataColumn( "HADD.MODELHALFNAMERF", typeof( String ) ) ); // �Ԏ피�p����
            table.Columns.Add( new DataColumn( "HADD.EXHAUSTGASSIGNRF", typeof( String ) ) ); // �r�K�X�L��
            table.Columns.Add( new DataColumn( "HADD.SERIESMODELRF", typeof( String ) ) ); // �V���[�Y�^��
            table.Columns.Add( new DataColumn( "HADD.CATEGORYSIGNMODELRF", typeof( String ) ) ); // �^���i�ޕʋL���j
            table.Columns.Add( new DataColumn( "HADD.FULLMODELRF", typeof( String ) ) ); // �^���i�t���^�j
            table.Columns.Add( new DataColumn( "HADD.MODELDESIGNATIONNORF", typeof( Int32 ) ) ); // �^���w��ԍ�
            table.Columns.Add( new DataColumn( "HADD.CATEGORYNORF", typeof( Int32 ) ) ); // �ޕʔԍ�
            table.Columns.Add( new DataColumn( "HADD.FRAMEMODELRF", typeof( String ) ) ); // �ԑ�^��
            table.Columns.Add( new DataColumn( "HADD.FRAMENORF", typeof( String ) ) ); // �ԑ�ԍ�
            table.Columns.Add( new DataColumn( "HADD.SEARCHFRAMENORF", typeof( Int32 ) ) ); // �ԑ�ԍ��i�����p�j
            table.Columns.Add( new DataColumn( "HADD.ENGINEMODELNMRF", typeof( String ) ) ); // �G���W���^������
            table.Columns.Add( new DataColumn( "HADD.RELEVANCEMODELRF", typeof( String ) ) ); // �֘A�^��
            table.Columns.Add( new DataColumn( "HADD.SUBCARNMCDRF", typeof( Int32 ) ) ); // �T�u�Ԗ��R�[�h
            table.Columns.Add( new DataColumn( "HADD.MODELGRADESNAMERF", typeof( String ) ) ); // �^���O���[�h����
            table.Columns.Add( new DataColumn( "HADD.COLORCODERF", typeof( String ) ) ); // �J���[�R�[�h
            table.Columns.Add( new DataColumn( "HADD.COLORNAME1RF", typeof( String ) ) ); // �J���[����1
            table.Columns.Add( new DataColumn( "HADD.TRIMCODERF", typeof( String ) ) ); // �g�����R�[�h
            table.Columns.Add( new DataColumn( "HADD.TRIMNAMERF", typeof( String ) ) ); // �g��������
            table.Columns.Add( new DataColumn( "HADD.MILEAGERF", typeof( Int32 ) ) ); // �ԗ����s����
            table.Columns.Add( new DataColumn( "HADD.PRINTERMNGNORF", typeof( Int32 ) ) ); // �v�����^�Ǘ�No
            table.Columns.Add( new DataColumn( "HADD.SLIPPRTSETPAPERIDRF", typeof( String ) ) ); // �`�[����ݒ�p���[ID
            table.Columns.Add( new DataColumn( "HADD.NOTE1RF", typeof( String ) ) ); // ���Д��l�P
            table.Columns.Add( new DataColumn( "HADD.NOTE2RF", typeof( String ) ) ); // ���Д��l�Q
            table.Columns.Add( new DataColumn( "HADD.NOTE3RF", typeof( String ) ) ); // ���Д��l�R
            table.Columns.Add( new DataColumn( "HADD.FIRSTENTRYDATEFYRF", typeof( Int32 ) ) ); // ���N�x����N
            table.Columns.Add( new DataColumn( "HADD.FIRSTENTRYDATEFSRF", typeof( Int32 ) ) ); // ���N�x����N��
            table.Columns.Add( new DataColumn( "HADD.FIRSTENTRYDATEFWRF", typeof( Int32 ) ) ); // ���N�x�a��N
            table.Columns.Add( new DataColumn( "HADD.FIRSTENTRYDATEFMRF", typeof( Int32 ) ) ); // ���N�x��
            table.Columns.Add( new DataColumn( "HADD.FIRSTENTRYDATEFGRF", typeof( String ) ) ); // ���N�x����
            table.Columns.Add( new DataColumn( "HADD.FIRSTENTRYDATEFRRF", typeof( String ) ) ); // ���N�x����
            table.Columns.Add( new DataColumn( "HADD.FIRSTENTRYDATEFLSRF", typeof( String ) ) ); // ���N�x���e����(/)
            table.Columns.Add( new DataColumn( "HADD.FIRSTENTRYDATEFLPRF", typeof( String ) ) ); // ���N�x���e����(.)
            table.Columns.Add( new DataColumn( "HADD.FIRSTENTRYDATEFLYRF", typeof( String ) ) ); // ���N�x���e����(�N)
            table.Columns.Add( new DataColumn( "HADD.FIRSTENTRYDATEFLMRF", typeof( String ) ) ); // ���N�x���e����(��)
            table.Columns.Add( new DataColumn( "HADD.PRINTCUSTOMERNM1RF", typeof( String ) ) ); // ����p���Ӑ於��(��i)
            table.Columns.Add( new DataColumn( "HADD.PRINTCUSTOMERNM2RF", typeof( String ) ) ); // ����p���Ӑ於��(���i)
            table.Columns.Add( new DataColumn( "HPURE.SALESTOTALTAXINCRF", typeof( Int64 ) ) ); // ��������`�[���v�i�ō��݁j
            table.Columns.Add( new DataColumn( "HPURE.SALESTOTALTAXEXCRF", typeof( Int64 ) ) ); // ��������`�[���v�i�Ŕ����j
            table.Columns.Add( new DataColumn( "HPURE.SALESSUBTOTALTAXINCRF", typeof( Int64 ) ) ); // �������㏬�v�i�ō��݁j
            table.Columns.Add( new DataColumn( "HPURE.SALESSUBTOTALTAXEXCRF", typeof( Int64 ) ) ); // �������㏬�v�i�Ŕ����j
            table.Columns.Add( new DataColumn( "HPURE.SALESSUBTOTALTAXRF", typeof( Int64 ) ) ); // �������㏬�v�i�Łj
            table.Columns.Add( new DataColumn( "HPRIME.SALESTOTALTAXINCRF", typeof( Int64 ) ) ); // �D�ǔ���`�[���v�i�ō��݁j
            table.Columns.Add( new DataColumn( "HPRIME.SALESTOTALTAXEXCRF", typeof( Int64 ) ) ); // �D�ǔ���`�[���v�i�Ŕ����j
            table.Columns.Add( new DataColumn( "HPRIME.SALESSUBTOTALTAXINCRF", typeof( Int64 ) ) ); // �D�ǔ��㏬�v�i�ō��݁j
            table.Columns.Add( new DataColumn( "HPRIME.SALESSUBTOTALTAXEXCRF", typeof( Int64 ) ) ); // �D�ǔ��㏬�v�i�Ŕ����j
            table.Columns.Add( new DataColumn( "HPRIME.SALESSUBTOTALTAXRF", typeof( Int64 ) ) ); // �D�ǔ��㏬�v�i�Łj
            table.Columns.Add( new DataColumn( "HADD.PRINTTIMEHOURRF", typeof( Int32 ) ) ); // ������� ��
            table.Columns.Add( new DataColumn( "HADD.PRINTTIMEMINUTERF", typeof( Int32 ) ) ); // ������� ��
            table.Columns.Add( new DataColumn( "HADD.PRINTTIMESECONDRF", typeof( Int32 ) ) ); // ������� �b
            table.Columns.Add( new DataColumn( "HADD.ESTFMDIVRF", typeof( Int32 ) ) ); // ���Ϗ��������敪
            table.Columns.Add( new DataColumn( "HADD.SALESDATEFYRF", typeof( Int32 ) ) ); // ������t����N
            table.Columns.Add( new DataColumn( "HADD.SALESDATEFSRF", typeof( Int32 ) ) ); // ������t����N��
            table.Columns.Add( new DataColumn( "HADD.SALESDATEFWRF", typeof( Int32 ) ) ); // ������t�a��N
            table.Columns.Add( new DataColumn( "HADD.SALESDATEFMRF", typeof( Int32 ) ) ); // ������t��
            table.Columns.Add( new DataColumn( "HADD.SALESDATEFDRF", typeof( Int32 ) ) ); // ������t��
            table.Columns.Add( new DataColumn( "HADD.SALESDATEFGRF", typeof( String ) ) ); // ������t����
            table.Columns.Add( new DataColumn( "HADD.SALESDATEFRRF", typeof( String ) ) ); // ������t����
            table.Columns.Add( new DataColumn( "HADD.SALESDATEFLSRF", typeof( String ) ) ); // ������t���e����(/)
            table.Columns.Add( new DataColumn( "HADD.SALESDATEFLPRF", typeof( String ) ) ); // ������t���e����(.)
            table.Columns.Add( new DataColumn( "HADD.SALESDATEFLYRF", typeof( String ) ) ); // ������t���e����(�N)
            table.Columns.Add( new DataColumn( "HADD.SALESDATEFLMRF", typeof( String ) ) ); // ������t���e����(��)
            table.Columns.Add( new DataColumn( "HADD.SALESDATEFLDRF", typeof( String ) ) ); // ������t���e����(��)
            table.Columns.Add( new DataColumn( "HADD.SALESSLIPPRINTDATEFYRF", typeof( Int32 ) ) ); // ����`�[���s������N
            table.Columns.Add( new DataColumn( "HADD.SALESSLIPPRINTDATEFSRF", typeof( Int32 ) ) ); // ����`�[���s������N��
            table.Columns.Add( new DataColumn( "HADD.SALESSLIPPRINTDATEFWRF", typeof( Int32 ) ) ); // ����`�[���s���a��N
            table.Columns.Add( new DataColumn( "HADD.SALESSLIPPRINTDATEFMRF", typeof( Int32 ) ) ); // ����`�[���s����
            table.Columns.Add( new DataColumn( "HADD.SALESSLIPPRINTDATEFDRF", typeof( Int32 ) ) ); // ����`�[���s����
            table.Columns.Add( new DataColumn( "HADD.SALESSLIPPRINTDATEFGRF", typeof( String ) ) ); // ����`�[���s������
            table.Columns.Add( new DataColumn( "HADD.SALESSLIPPRINTDATEFRRF", typeof( String ) ) ); // ����`�[���s������
            table.Columns.Add( new DataColumn( "HADD.SALESSLIPPRINTDATEFLSRF", typeof( String ) ) ); // ����`�[���s�����e����(/)
            table.Columns.Add( new DataColumn( "HADD.SALESSLIPPRINTDATEFLPRF", typeof( String ) ) ); // ����`�[���s�����e����(.)
            table.Columns.Add( new DataColumn( "HADD.SALESSLIPPRINTDATEFLYRF", typeof( String ) ) ); // ����`�[���s�����e����(�N)
            table.Columns.Add( new DataColumn( "HADD.SALESSLIPPRINTDATEFLMRF", typeof( String ) ) ); // ����`�[���s�����e����(��)
            table.Columns.Add( new DataColumn( "HADD.SALESSLIPPRINTDATEFLDRF", typeof( String ) ) ); // ����`�[���s�����e����(��)
            table.Columns.Add( new DataColumn( "HADD.SYSTEMATICCODERF", typeof( Int32 ) ) ); // �n���R�[�h
            table.Columns.Add( new DataColumn( "HADD.SYSTEMATICNAMERF", typeof( String ) ) ); // �n������
            table.Columns.Add( new DataColumn( "HADD.STPRODUCETYPEOFYEARRF", typeof( Int32 ) ) ); // �J�n���Y�N��
            table.Columns.Add( new DataColumn( "HADD.EDPRODUCETYPEOFYEARRF", typeof( Int32 ) ) ); // �I�����Y�N��
            table.Columns.Add( new DataColumn( "HADD.DOORCOUNTRF", typeof( Int32 ) ) ); // �h�A��
            table.Columns.Add( new DataColumn( "HADD.BODYNAMECODERF", typeof( Int32 ) ) ); // �{�f�B�[���R�[�h
            table.Columns.Add( new DataColumn( "HADD.BODYNAMERF", typeof( String ) ) ); // �{�f�B�[����
            table.Columns.Add( new DataColumn( "HADD.STPRODUCEFRAMENORF", typeof( Int32 ) ) ); // ���Y�ԑ�ԍ��J�n
            table.Columns.Add( new DataColumn( "HADD.EDPRODUCEFRAMENORF", typeof( Int32 ) ) ); // ���Y�ԑ�ԍ��I��
            table.Columns.Add( new DataColumn( "HADD.ENGINEMODELRF", typeof( String ) ) ); // �����@�^���i�G���W���j
            table.Columns.Add( new DataColumn( "HADD.MODELGRADENMRF", typeof( String ) ) ); // �^���O���[�h����
            table.Columns.Add( new DataColumn( "HADD.ENGINEDISPLACENMRF", typeof( String ) ) ); // �r�C�ʖ���
            table.Columns.Add( new DataColumn( "HADD.EDIVNMRF", typeof( String ) ) ); // E�敪����
            table.Columns.Add( new DataColumn( "HADD.TRANSMISSIONNMRF", typeof( String ) ) ); // �~�b�V��������
            table.Columns.Add( new DataColumn( "HADD.SHIFTNMRF", typeof( String ) ) ); // �V�t�g����
            table.Columns.Add( new DataColumn( "HADD.WHEELDRIVEMETHODNMRF", typeof( String ) ) ); // �쓮��������
            table.Columns.Add( new DataColumn( "HADD.ADDICARSPEC1RF", typeof( String ) ) ); // �ǉ�����1
            table.Columns.Add( new DataColumn( "HADD.ADDICARSPEC2RF", typeof( String ) ) ); // �ǉ�����2
            table.Columns.Add( new DataColumn( "HADD.ADDICARSPEC3RF", typeof( String ) ) ); // �ǉ�����3
            table.Columns.Add( new DataColumn( "HADD.ADDICARSPEC4RF", typeof( String ) ) ); // �ǉ�����4
            table.Columns.Add( new DataColumn( "HADD.ADDICARSPEC5RF", typeof( String ) ) ); // �ǉ�����5
            table.Columns.Add( new DataColumn( "HADD.ADDICARSPEC6RF", typeof( String ) ) ); // �ǉ�����6
            table.Columns.Add( new DataColumn( "HADD.ADDICARSPECTITLE1RF", typeof( String ) ) ); // �ǉ������^�C�g��1
            table.Columns.Add( new DataColumn( "HADD.ADDICARSPECTITLE2RF", typeof( String ) ) ); // �ǉ������^�C�g��2
            table.Columns.Add( new DataColumn( "HADD.ADDICARSPECTITLE3RF", typeof( String ) ) ); // �ǉ������^�C�g��3
            table.Columns.Add( new DataColumn( "HADD.ADDICARSPECTITLE4RF", typeof( String ) ) ); // �ǉ������^�C�g��4
            table.Columns.Add( new DataColumn( "HADD.ADDICARSPECTITLE5RF", typeof( String ) ) ); // �ǉ������^�C�g��5
            table.Columns.Add( new DataColumn( "HADD.ADDICARSPECTITLE6RF", typeof( String ) ) ); // �ǉ������^�C�g��6
            table.Columns.Add( new DataColumn( "HADD.STPRODUCETYPEOFYEARFYRF", typeof( Int32 ) ) ); // �J�n���Y�N������N
            table.Columns.Add( new DataColumn( "HADD.STPRODUCETYPEOFYEARFSRF", typeof( Int32 ) ) ); // �J�n���Y�N������N��
            table.Columns.Add( new DataColumn( "HADD.STPRODUCETYPEOFYEARFWRF", typeof( Int32 ) ) ); // �J�n���Y�N���a��N
            table.Columns.Add( new DataColumn( "HADD.STPRODUCETYPEOFYEARFMRF", typeof( Int32 ) ) ); // �J�n���Y�N����
            table.Columns.Add( new DataColumn( "HADD.STPRODUCETYPEOFYEARFGRF", typeof( String ) ) ); // �J�n���Y�N������
            table.Columns.Add( new DataColumn( "HADD.STPRODUCETYPEOFYEARFRRF", typeof( String ) ) ); // �J�n���Y�N������
            table.Columns.Add( new DataColumn( "HADD.STPRODUCETYPEOFYEARFLSRF", typeof( String ) ) ); // �J�n���Y�N�����e����(/)
            table.Columns.Add( new DataColumn( "HADD.STPRODUCETYPEOFYEARFLPRF", typeof( String ) ) ); // �J�n���Y�N�����e����(.)
            table.Columns.Add( new DataColumn( "HADD.STPRODUCETYPEOFYEARFLYRF", typeof( String ) ) ); // �J�n���Y�N�����e����(�N)
            table.Columns.Add( new DataColumn( "HADD.STPRODUCETYPEOFYEARFLMRF", typeof( String ) ) ); // �J�n���Y�N�����e����(��)
            table.Columns.Add( new DataColumn( "HADD.EDPRODUCETYPEOFYEARFYRF", typeof( Int32 ) ) ); // �I�����Y�N������N
            table.Columns.Add( new DataColumn( "HADD.EDPRODUCETYPEOFYEARFSRF", typeof( Int32 ) ) ); // �I�����Y�N������N��
            table.Columns.Add( new DataColumn( "HADD.EDPRODUCETYPEOFYEARFWRF", typeof( Int32 ) ) ); // �I�����Y�N���a��N
            table.Columns.Add( new DataColumn( "HADD.EDPRODUCETYPEOFYEARFMRF", typeof( Int32 ) ) ); // �I�����Y�N����
            table.Columns.Add( new DataColumn( "HADD.EDPRODUCETYPEOFYEARFGRF", typeof( String ) ) ); // �I�����Y�N������
            table.Columns.Add( new DataColumn( "HADD.EDPRODUCETYPEOFYEARFRRF", typeof( String ) ) ); // �I�����Y�N������
            table.Columns.Add( new DataColumn( "HADD.EDPRODUCETYPEOFYEARFLSRF", typeof( String ) ) ); // �I�����Y�N�����e����(/)
            table.Columns.Add( new DataColumn( "HADD.EDPRODUCETYPEOFYEARFLPRF", typeof( String ) ) ); // �I�����Y�N�����e����(.)
            table.Columns.Add( new DataColumn( "HADD.EDPRODUCETYPEOFYEARFLYRF", typeof( String ) ) ); // �I�����Y�N�����e����(�N)
            table.Columns.Add( new DataColumn( "HADD.EDPRODUCETYPEOFYEARFLMRF", typeof( String ) ) ); // �I�����Y�N�����e����(��)
            # endregion

            # region [�X�L�[�}��`�i���׍��ځj]
            table.Columns.Add( new DataColumn( "SALESDETAILRF.SALESSLIPNUMRF", typeof( String ) ) ); // ����`�[�ԍ�
            table.Columns.Add( new DataColumn( "SALESDETAILRF.SALESROWNORF", typeof( Int32 ) ) ); // ����s�ԍ�
            table.Columns.Add( new DataColumn( "DPURE.GOODSMAKERCDRF", typeof( Int32 ) ) ); // �������i���[�J�[�R�[�h
            table.Columns.Add( new DataColumn( "DPURE.MAKERNAMERF", typeof( String ) ) ); // �������[�J�[����
            table.Columns.Add( new DataColumn( "DPURE.MAKERKANANAMERF", typeof( String ) ) ); // �������[�J�[�J�i����
            table.Columns.Add( new DataColumn( "DPURE.GOODSNORF", typeof( String ) ) ); // �������i�ԍ�
            table.Columns.Add( new DataColumn( "DPURE.GOODSNAMERF", typeof( String ) ) ); // �������i����
            table.Columns.Add( new DataColumn( "DPURE.GOODSNAMEKANARF", typeof( String ) ) ); // �������i���̃J�i
            table.Columns.Add( new DataColumn( "DPURE.BLGOODSCODERF", typeof( Int32 ) ) ); // ����BL���i�R�[�h
            table.Columns.Add( new DataColumn( "DPURE.SALESUNPRCTAXINCFLRF", typeof( Double ) ) ); // ��������P���i�ō��C�����j
            table.Columns.Add( new DataColumn( "DPURE.SALESUNPRCTAXEXCFLRF", typeof( Double ) ) ); // ��������P���i�Ŕ��C�����j
            table.Columns.Add( new DataColumn( "DPURE.LISTPRICETAXINCFLRF", typeof( Double ) ) ); // �����艿�i�ō��C�����j
            table.Columns.Add( new DataColumn( "DPURE.LISTPRICETAXEXCFLRF", typeof( Double ) ) ); // �����艿�i�Ŕ��C�����j
            table.Columns.Add( new DataColumn( "DPURE.SALESMONEYTAXINCRF", typeof( Int64 ) ) ); // ����������z�i�ō��݁j
            table.Columns.Add( new DataColumn( "DPURE.SALESMONEYTAXEXCRF", typeof( Int64 ) ) ); // ����������z�i�Ŕ����j
            table.Columns.Add( new DataColumn( "DPURE.TAXATIONDIVCDRF", typeof( Int32 ) ) ); // �����ېŋ敪
            table.Columns.Add( new DataColumn( "DPURE.SALESUNPRCFLRF", typeof( Double ) ) ); // ��������P��
            table.Columns.Add( new DataColumn( "DPURE.LISTPRICERF", typeof( Double ) ) ); // �����艿
            table.Columns.Add( new DataColumn( "DPURE.SHIPMENTCNTRF", typeof( Double ) ) ); // �����o�א�
            table.Columns.Add( new DataColumn( "DPURE.SALESMONEYRF", typeof( Int64 ) ) ); // ����������z
            table.Columns.Add( new DataColumn( "DPRIM.GOODSMAKERCDRF", typeof( Int32 ) ) ); // �D�Ǐ��i���[�J�[�R�[�h
            table.Columns.Add( new DataColumn( "DPRIM.MAKERNAMERF", typeof( String ) ) ); // �D�ǃ��[�J�[����
            table.Columns.Add( new DataColumn( "DPRIM.MAKERKANANAMERF", typeof( String ) ) ); // �D�ǃ��[�J�[�J�i����
            table.Columns.Add( new DataColumn( "DPRIM.GOODSNORF", typeof( String ) ) ); // �D�Ǐ��i�ԍ�
            table.Columns.Add( new DataColumn( "DPRIM.GOODSNAMERF", typeof( String ) ) ); // �D�Ǐ��i����
            table.Columns.Add( new DataColumn( "DPRIM.GOODSNAMEKANARF", typeof( String ) ) ); // �D�Ǐ��i���̃J�i
            table.Columns.Add( new DataColumn( "DPRIM.BLGOODSCODERF", typeof( Int32 ) ) ); // �D��BL���i�R�[�h
            table.Columns.Add( new DataColumn( "DPRIM.SALESUNPRCTAXINCFLRF", typeof( Double ) ) ); // �D�ǔ���P���i�ō��C�����j
            table.Columns.Add( new DataColumn( "DPRIM.SALESUNPRCTAXEXCFLRF", typeof( Double ) ) ); // �D�ǔ���P���i�Ŕ��C�����j
            table.Columns.Add( new DataColumn( "DPRIM.LISTPRICETAXINCFLRF", typeof( Double ) ) ); // �D�ǒ艿�i�ō��C�����j
            table.Columns.Add( new DataColumn( "DPRIM.LISTPRICETAXEXCFLRF", typeof( Double ) ) ); // �D�ǒ艿�i�Ŕ��C�����j
            table.Columns.Add( new DataColumn( "DPRIM.SALESMONEYTAXINCRF", typeof( Int64 ) ) ); // �D�ǔ�����z�i�ō��݁j
            table.Columns.Add( new DataColumn( "DPRIM.SALESMONEYTAXEXCRF", typeof( Int64 ) ) ); // �D�ǔ�����z�i�Ŕ����j
            table.Columns.Add( new DataColumn( "DPRIM.TAXATIONDIVCDRF", typeof( Int32 ) ) ); // �D�ǉېŋ敪
            table.Columns.Add( new DataColumn( "DPRIM.SALESUNPRCFLRF", typeof( Double ) ) ); // �D�ǔ���P��
            table.Columns.Add( new DataColumn( "DPRIM.LISTPRICERF", typeof( Double ) ) ); // �D�ǒ艿
            table.Columns.Add( new DataColumn( "DPRIM.SHIPMENTCNTRF", typeof( Double ) ) ); // �D�Ǐo�א�
            table.Columns.Add( new DataColumn( "DPRIM.SALESMONEYRF", typeof( Int64 ) ) ); // �D�ǔ�����z
            table.Columns.Add( new DataColumn( "DADD.SPECIALNOTERF", typeof( String ) ) ); // �I�v�V�����E�K�i���
            # endregion

            # region [���䍀��]
            table.Columns.Add( new DataColumn( ct_InPageCopyTitle1, typeof( string ) ) );  // ���ʃ^�C�g��
            table.Columns.Add( new DataColumn( ct_InPageCopyTitle2, typeof( string ) ) );  // ���ʃ^�C�g��
            table.Columns.Add( new DataColumn( ct_InPageCopyTitle3, typeof( string ) ) );  // ���ʃ^�C�g��
            table.Columns.Add( new DataColumn( ct_InPageCopyTitle4, typeof( string ) ) );  // ���ʃ^�C�g��
            table.Columns.Add( new DataColumn( ct_InPageCopyCount, typeof( int ) ) );  // ����y�[�W���R�s�[�J�E���g
            table.Columns.Add( new DataColumn( ct_PageCount, typeof( int ) ) ); // �Ő�
            table.Columns.Add( new DataColumn( ct_HCategoryHyp, typeof( string ) ) );  // (�擪)�ޕʌ^���n�C�t��
            table.Columns.Add( new DataColumn( ct_HPrintCustomerNameJoin12, typeof( string ) ) );  // (�擪)�ޕʌ^���n�C�t��
            table.Columns.Add( new DataColumn( ct_HPrintCustomerNameJoinHn12, typeof( string ) ) );  // (�擪)�ޕʌ^���n�C�t��
            table.Columns.Add( new DataColumn( ct_HPrintEnterpriseName1FH, typeof( string ) ) );  // (�擪)�ޕʌ^���n�C�t��
            table.Columns.Add( new DataColumn( ct_HPrintEnterpriseName1LH, typeof( string ) ) );  // (�擪)�ޕʌ^���n�C�t��
            table.Columns.Add( new DataColumn( ct_HPrintEnterpriseName2FH, typeof( string ) ) );  // (�擪)�ޕʌ^���n�C�t��
            table.Columns.Add( new DataColumn( ct_HPrintEnterpriseName2LH, typeof( string ) ) );  // (�擪)�ޕʌ^���n�C�t��
            table.Columns.Add( new DataColumn( "HLG.PRINTCUSTOMERNAMEJOIN12RF", typeof( string ) ) );  // �i�c�{�j���Ӑ於�P�{���Ӑ於�Q
            table.Columns.Add( new DataColumn( "HLG.PRINTCUSTOMERNAMEJOIN12HNRF", typeof( string ) ) );  // �i�c�{�j���Ӑ於�P�{���Ӑ於�Q�{�h��
            table.Columns.Add( new DataColumn( "HLG.CUSTOMERNAMERF", typeof( string ) ) );  // �i�c�{�j���Ӑ於��
            table.Columns.Add( new DataColumn( "HLG.CUSTOMERNAME2RF", typeof( string ) ) );  // �i�c�{�j���Ӑ於��2
            table.Columns.Add( new DataColumn( "HLG.CUSTOMERSNMRF", typeof( string ) ) );  // �i�c�{�j���Ӑ旪��
            table.Columns.Add( new DataColumn( "HLG.HONORIFICTITLERF", typeof( string ) ) );  // �i�c�{�j���Ӑ�h��
            table.Columns.Add( new DataColumn( "HLG.PRINTCUSTOMERNM1RF", typeof( string ) ) );  // �i�c�{�j����p���Ӑ於��(��i)
            table.Columns.Add( new DataColumn( "HLG.PRINTCUSTOMERNM2RF", typeof( string ) ) );  // �i�c�{�j����p���Ӑ於��(���i)
            # endregion

            return table;
        }
        # endregion

        # region [�f�[�^�ڍs�iDataClass��DataTable�j]
        /// <summary>
        /// �f�[�^�ڍs����
        /// </summary>
        /// <param name="table"></param>
        /// <param name="slipWork"></param>
        /// <param name="detailWorks"></param>
        /// <param name="slipPrtSet"></param>
        /// <param name="frePrtPSetWork"></param>
        /// <param name="slipPrintParameter"></param>
        /// <param name="estimateDefSet"></param>
        public static void CopyToDataTable( ref DataTable table, FrePEstFmHead slipWork, List<FrePEstFmDetail> detailWorks, SlipPrtSetWork slipPrtSet, EachSlipTypeSet eachSlipTypeSet,FrePrtPSetWork frePrtPSetWork, SlipPrintParameter slipPrintParameter, EstimateDefSet estimateDefSet, AllDefSetWork allDefSet, Dictionary<string, string> columnVisibleTypeDic )
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
            // �������͏������x���d�����܂��B
            //----------------------------------------------------

            # region [����]
            DateTime printTime = DateTime.Now;
            slipWork.HADD_PRINTTIMEHOURRF = printTime.Hour;
            slipWork.HADD_PRINTTIMEMINUTERF = printTime.Minute;
            slipWork.HADD_PRINTTIMESECONDRF = printTime.Second;
            # endregion

            # region [�`�[�f�[�^�̕ҏW]
            
            // ���Ϗ����s���i���V�X�e�����t���Z�b�g�j
            //   ��UI���͂������t�͓`�[���t�ɃZ�b�g����Ă���B
            slipWork.SALESSLIPRF_SALESSLIPPRINTDATERF = DateTime.Today;

            // �`�[�ԍ��[��
            if ( IsZero( slipWork.SALESSLIPRF_SALESSLIPNUMRF ) )
            {
                slipWork.SALESSLIPRF_SALESSLIPNUMRF = string.Empty;
            }
            // ���Ϗ��ԍ��i���`�[�ԍ����Z�b�g�j
            slipWork.SALESSLIPRF_ESTIMATEFORMNORF = slipWork.SALESSLIPRF_SALESSLIPNUMRF;

            // �h��
            if ( string.IsNullOrEmpty( slipWork.SALESSLIPRF_HONORIFICTITLERF ) )
            {
                slipWork.SALESSLIPRF_HONORIFICTITLERF = slipPrtSet.HonorificTitle;
            }
            
            # endregion


            // �`�[�^�C�g���擾����
            List<List<string>> inPageCopyTitle = GetInPageCopyTitles( slipPrtSet );

            // �P�y�[�W���̍s���Z�o
            int feedCount = GetFeedCount( frePrtPSetWork, slipWork, estimateDefSet );

            // ���ב��s���̎Z�o
            int allDetailCount = GetAllDetailCount( detailWorks.Count, feedCount );

            for ( int inPageCopyCount = 0; inPageCopyCount < inPageCopyTitle[0].Count; inPageCopyCount++ )
            {
                // ���׍s�ڍs
                //for ( int index = 0; index < slipPrtSet.DetailRowCount; index++ )
                for ( int index = 0; index < allDetailCount; index++ )
                {
                    DataRow row = table.NewRow();

                    // �����y�[�W����Ɏg�p����̂ŁA�S���ׂɃZ�b�g����B
                    // �y�[�W��
                    row[ct_PageCount] = GetPageCount( index, feedCount );

                    // �ŏ��̃��R�[�h�^�Ō�̃��R�[�h�̂ݓ`�[���ڂ��Z�b�g����B
                    // (�P���ɖ��ׂ̐������{�������Ȃ���)
                    // �Ȃ������ł�"�Ō�̃��R�[�h"�Ƃ͋󔒍s�̉\�����܂ށB
                    //if ( index == 0 || index == slipPrtSet.DetailRowCount - 1 )
                    if ( index % feedCount == 0 || (index + 1) % feedCount == 0 )
                    {
                        # region [�`�[����Copy]
                        row["SALESSLIPRF.SALESSLIPNUMRF"] = slipWork.SALESSLIPRF_SALESSLIPNUMRF; // ����`�[�ԍ�
                        row["SALESSLIPRF.SECTIONCODERF"] = slipWork.SALESSLIPRF_SECTIONCODERF; // ���_�R�[�h
                        //row["SALESSLIPRF.SALESDATERF"] = slipWork.SALESSLIPRF_SALESDATERF; // ������t
                        row["SALESSLIPRF.ESTIMATEFORMNORF"] = slipWork.SALESSLIPRF_ESTIMATEFORMNORF; // ���Ϗ��ԍ�
                        row["SALESSLIPRF.ESTIMATEDIVIDERF"] = slipWork.SALESSLIPRF_ESTIMATEDIVIDERF; // ���ϋ敪
                        row["SALESSLIPRF.SALESINPUTCODERF"] = slipWork.SALESSLIPRF_SALESINPUTCODERF; // ������͎҃R�[�h
                        row["SALESSLIPRF.SALESINPUTNAMERF"] = slipWork.SALESSLIPRF_SALESINPUTNAMERF; // ������͎Җ���
                        row["SALESSLIPRF.FRONTEMPLOYEECDRF"] = slipWork.SALESSLIPRF_FRONTEMPLOYEECDRF; // ��t�]�ƈ��R�[�h
                        row["SALESSLIPRF.FRONTEMPLOYEENMRF"] = slipWork.SALESSLIPRF_FRONTEMPLOYEENMRF; // ��t�]�ƈ�����
                        row["SALESSLIPRF.SALESEMPLOYEECDRF"] = slipWork.SALESSLIPRF_SALESEMPLOYEECDRF; // �̔��]�ƈ��R�[�h
                        row["SALESSLIPRF.SALESEMPLOYEENMRF"] = slipWork.SALESSLIPRF_SALESEMPLOYEENMRF; // �̔��]�ƈ�����
                        row["SALESSLIPRF.CONSTAXLAYMETHODRF"] = slipWork.SALESSLIPRF_CONSTAXLAYMETHODRF; // ����œ]�ŕ���
                        row["SALESSLIPRF.CUSTOMERCODERF"] = slipWork.SALESSLIPRF_CUSTOMERCODERF; // ���Ӑ�R�[�h
                        row["SALESSLIPRF.CUSTOMERNAMERF"] = slipWork.SALESSLIPRF_CUSTOMERNAMERF; // ���Ӑ於��
                        row["SALESSLIPRF.CUSTOMERNAME2RF"] = slipWork.SALESSLIPRF_CUSTOMERNAME2RF; // ���Ӑ於��2
                        row["SALESSLIPRF.CUSTOMERSNMRF"] = slipWork.SALESSLIPRF_CUSTOMERSNMRF; // ���Ӑ旪��
                        row["SALESSLIPRF.HONORIFICTITLERF"] = slipWork.SALESSLIPRF_HONORIFICTITLERF; // ���Ӑ�h��
                        //row["SALESSLIPRF.SALESSLIPPRINTDATERF"] = slipWork.SALESSLIPRF_SALESSLIPPRINTDATERF; // ����`�[���s��
                        row["SALESSLIPRF.TOTALAMOUNTDISPWAYCDRF"] = slipWork.SALESSLIPRF_TOTALAMOUNTDISPWAYCDRF; // ���z�\�����@�敪
                        row["SECINFOSETRF.SECTIONGUIDENMRF"] = slipWork.SECINFOSETRF_SECTIONGUIDENMRF; // ���_�K�C�h����
                        row["COMPANYNMRF.COMPANYPRRF"] = slipWork.COMPANYNMRF_COMPANYPRRF; // ���_����PR��
                        row["COMPANYNMRF.COMPANYNAME1RF"] = slipWork.COMPANYNMRF_COMPANYNAME1RF; // ���_���Ж���1
                        row["COMPANYNMRF.COMPANYNAME2RF"] = slipWork.COMPANYNMRF_COMPANYNAME2RF; // ���_���Ж���2
                        row["COMPANYNMRF.POSTNORF"] = slipWork.COMPANYNMRF_POSTNORF; // ���_�X�֔ԍ�
                        row["COMPANYNMRF.ADDRESS1RF"] = slipWork.COMPANYNMRF_ADDRESS1RF; // ���_�Z��1�i�s���{���s��S�E�����E���j
                        row["COMPANYNMRF.ADDRESS3RF"] = slipWork.COMPANYNMRF_ADDRESS3RF; // ���_�Z��3�i�Ԓn�j
                        row["COMPANYNMRF.ADDRESS4RF"] = slipWork.COMPANYNMRF_ADDRESS4RF; // ���_�Z��4�i�A�p�[�g���́j
                        row["COMPANYNMRF.COMPANYTELNO1RF"] = slipWork.COMPANYNMRF_COMPANYTELNO1RF; // ���_���Гd�b�ԍ�1
                        row["COMPANYNMRF.COMPANYTELNO2RF"] = slipWork.COMPANYNMRF_COMPANYTELNO2RF; // ���_���Гd�b�ԍ�2
                        row["COMPANYNMRF.COMPANYTELNO3RF"] = slipWork.COMPANYNMRF_COMPANYTELNO3RF; // ���_���Гd�b�ԍ�3
                        row["COMPANYNMRF.COMPANYTELTITLE1RF"] = slipWork.COMPANYNMRF_COMPANYTELTITLE1RF; // ���_���Гd�b�ԍ��^�C�g��1
                        row["COMPANYNMRF.COMPANYTELTITLE2RF"] = slipWork.COMPANYNMRF_COMPANYTELTITLE2RF; // ���_���Гd�b�ԍ��^�C�g��2
                        row["COMPANYNMRF.COMPANYTELTITLE3RF"] = slipWork.COMPANYNMRF_COMPANYTELTITLE3RF; // ���_���Гd�b�ԍ��^�C�g��3
                        row["COMPANYNMRF.TRANSFERGUIDANCERF"] = slipWork.COMPANYNMRF_TRANSFERGUIDANCERF; // ���_��s�U���ē���
                        row["COMPANYNMRF.ACCOUNTNOINFO1RF"] = slipWork.COMPANYNMRF_ACCOUNTNOINFO1RF; // ���_��s����1
                        row["COMPANYNMRF.ACCOUNTNOINFO2RF"] = slipWork.COMPANYNMRF_ACCOUNTNOINFO2RF; // ���_��s����2
                        row["COMPANYNMRF.ACCOUNTNOINFO3RF"] = slipWork.COMPANYNMRF_ACCOUNTNOINFO3RF; // ���_��s����3
                        row["COMPANYNMRF.COMPANYSETNOTE1RF"] = slipWork.COMPANYNMRF_COMPANYSETNOTE1RF; // ���_���Аݒ�E�v1
                        row["COMPANYNMRF.COMPANYSETNOTE2RF"] = slipWork.COMPANYNMRF_COMPANYSETNOTE2RF; // ���_���Аݒ�E�v2
                        row["COMPANYNMRF.COMPANYURLRF"] = slipWork.COMPANYNMRF_COMPANYURLRF; // ���_����URL
                        row["COMPANYNMRF.COMPANYPRSENTENCE2RF"] = slipWork.COMPANYNMRF_COMPANYPRSENTENCE2RF; // ���_����PR��2
                        row["COMPANYNMRF.IMAGECOMMENTFORPRT1RF"] = slipWork.COMPANYNMRF_IMAGECOMMENTFORPRT1RF; // ���_�摜�󎚗p�R�����g1
                        row["COMPANYNMRF.IMAGECOMMENTFORPRT2RF"] = slipWork.COMPANYNMRF_IMAGECOMMENTFORPRT2RF; // ���_�摜�󎚗p�R�����g2
                        row["IMAGEINFORF.IMAGEINFODATARF"] = slipWork.IMAGEINFORF_IMAGEINFODATARF; // ���_���Љ摜
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
                        row["HEST.FOOTNOTES1RF"] = slipWork.HEST_FOOTNOTES1RF; // �r���P
                        row["HEST.FOOTNOTES2RF"] = slipWork.HEST_FOOTNOTES2RF; // �r���Q
                        row["HEST.ESTIMATETITLE1RF"] = slipWork.HEST_ESTIMATETITLE1RF; // ���σ^�C�g���P
                        row["HEST.ESTIMATETITLE2RF"] = slipWork.HEST_ESTIMATETITLE2RF; // ���σ^�C�g���Q
                        row["HEST.ESTIMATETITLE3RF"] = slipWork.HEST_ESTIMATETITLE3RF; // ���σ^�C�g���R
                        row["HEST.ESTIMATETITLE4RF"] = slipWork.HEST_ESTIMATETITLE4RF; // ���σ^�C�g���S
                        row["HEST.ESTIMATETITLE5RF"] = slipWork.HEST_ESTIMATETITLE5RF; // ���σ^�C�g���T
                        row["HEST.ESTIMATENOTE1RF"] = slipWork.HEST_ESTIMATENOTE1RF; // ���ϔ��l�P
                        row["HEST.ESTIMATENOTE2RF"] = slipWork.HEST_ESTIMATENOTE2RF; // ���ϔ��l�Q
                        row["HEST.ESTIMATENOTE3RF"] = slipWork.HEST_ESTIMATENOTE3RF; // ���ϔ��l�R
                        row["HEST.ESTIMATENOTE4RF"] = slipWork.HEST_ESTIMATENOTE4RF; // ���ϔ��l�S
                        row["HEST.ESTIMATENOTE5RF"] = slipWork.HEST_ESTIMATENOTE5RF; // ���ϔ��l�T
                        //row["HEST.ESTIMATEVALIDITYLIMITRF"] = slipWork.HEST_ESTIMATEVALIDITYLIMITRF; // ���Ϗ��L������
                        //row["HEST.ESTIMATEVALIDITYLIMITFYRF"] = slipWork.HEST_ESTIMATEVALIDITYLIMITFYRF; // ���Ϗ��L����������N
                        //row["HEST.ESTIMATEVALIDITYLIMITFSRF"] = slipWork.HEST_ESTIMATEVALIDITYLIMITFSRF; // ���Ϗ��L����������N��
                        //row["HEST.ESTIMATEVALIDITYLIMITFWRF"] = slipWork.HEST_ESTIMATEVALIDITYLIMITFWRF; // ���Ϗ��L�������a��N
                        //row["HEST.ESTIMATEVALIDITYLIMITFMRF"] = slipWork.HEST_ESTIMATEVALIDITYLIMITFMRF; // ���Ϗ��L��������
                        //row["HEST.ESTIMATEVALIDITYLIMITFDRF"] = slipWork.HEST_ESTIMATEVALIDITYLIMITFDRF; // ���Ϗ��L��������
                        //row["HEST.ESTIMATEVALIDITYLIMITFGRF"] = slipWork.HEST_ESTIMATEVALIDITYLIMITFGRF; // ���Ϗ��L����������
                        //row["HEST.ESTIMATEVALIDITYLIMITFRRF"] = slipWork.HEST_ESTIMATEVALIDITYLIMITFRRF; // ���Ϗ��L����������
                        //row["HEST.ESTIMATEVALIDITYLIMITFLSRF"] = slipWork.HEST_ESTIMATEVALIDITYLIMITFLSRF; // ���Ϗ��L���������e����(/)
                        //row["HEST.ESTIMATEVALIDITYLIMITFLPRF"] = slipWork.HEST_ESTIMATEVALIDITYLIMITFLPRF; // ���Ϗ��L���������e����(.)
                        //row["HEST.ESTIMATEVALIDITYLIMITFLYRF"] = slipWork.HEST_ESTIMATEVALIDITYLIMITFLYRF; // ���Ϗ��L���������e����(�N)
                        //row["HEST.ESTIMATEVALIDITYLIMITFLMRF"] = slipWork.HEST_ESTIMATEVALIDITYLIMITFLMRF; // ���Ϗ��L���������e����(��)
                        //row["HEST.ESTIMATEVALIDITYLIMITFLDRF"] = slipWork.HEST_ESTIMATEVALIDITYLIMITFLDRF; // ���Ϗ��L���������e����(��)
                        row["HADD.CARMNGNORF"] = slipWork.HADD_CARMNGNORF; // �ԗ��Ǘ��ԍ�
                        row["HADD.CARMNGCODERF"] = slipWork.HADD_CARMNGCODERF; // ���q�Ǘ��R�[�h
                        row["HADD.NUMBERPLATE1CODERF"] = slipWork.HADD_NUMBERPLATE1CODERF; // ���^�������ԍ�
                        row["HADD.NUMBERPLATE1NAMERF"] = slipWork.HADD_NUMBERPLATE1NAMERF; // ���^�����ǖ���
                        row["HADD.NUMBERPLATE2RF"] = slipWork.HADD_NUMBERPLATE2RF; // �ԗ��o�^�ԍ��i��ʁj
                        row["HADD.NUMBERPLATE3RF"] = slipWork.HADD_NUMBERPLATE3RF; // �ԗ��o�^�ԍ��i�J�i�j
                        row["HADD.NUMBERPLATE4RF"] = slipWork.HADD_NUMBERPLATE4RF; // �ԗ��o�^�ԍ��i�v���[�g�ԍ��j
                        //row["HADD.FIRSTENTRYDATERF"] = slipWork.HADD_FIRSTENTRYDATERF; // ���N�x
                        row["HADD.MAKERCODERF"] = slipWork.HADD_MAKERCODERF; // ���[�J�[�R�[�h
                        row["HADD.MAKERFULLNAMERF"] = slipWork.HADD_MAKERFULLNAMERF; // ���[�J�[�S�p����
                        row["HADD.MAKERHALFNAMERF"] = slipWork.HADD_MAKERHALFNAMERF; // ���[�J�[���p����
                        row["HADD.MODELCODERF"] = slipWork.HADD_MODELCODERF; // �Ԏ�R�[�h
                        row["HADD.MODELSUBCODERF"] = slipWork.HADD_MODELSUBCODERF; // �Ԏ�T�u�R�[�h
                        row["HADD.MODELFULLNAMERF"] = slipWork.HADD_MODELFULLNAMERF; // �Ԏ�S�p����
                        row["HADD.MODELHALFNAMERF"] = slipWork.HADD_MODELHALFNAMERF; // �Ԏ피�p����
                        row["HADD.EXHAUSTGASSIGNRF"] = slipWork.HADD_EXHAUSTGASSIGNRF; // �r�K�X�L��
                        row["HADD.SERIESMODELRF"] = slipWork.HADD_SERIESMODELRF; // �V���[�Y�^��
                        row["HADD.CATEGORYSIGNMODELRF"] = slipWork.HADD_CATEGORYSIGNMODELRF; // �^���i�ޕʋL���j
                        row["HADD.FULLMODELRF"] = slipWork.HADD_FULLMODELRF; // �^���i�t���^�j
                        row["HADD.MODELDESIGNATIONNORF"] = slipWork.HADD_MODELDESIGNATIONNORF; // �^���w��ԍ�
                        row["HADD.CATEGORYNORF"] = slipWork.HADD_CATEGORYNORF; // �ޕʔԍ�
                        row["HADD.FRAMEMODELRF"] = slipWork.HADD_FRAMEMODELRF; // �ԑ�^��
                        row["HADD.FRAMENORF"] = slipWork.HADD_FRAMENORF; // �ԑ�ԍ�
                        row["HADD.SEARCHFRAMENORF"] = slipWork.HADD_SEARCHFRAMENORF; // �ԑ�ԍ��i�����p�j
                        row["HADD.ENGINEMODELNMRF"] = slipWork.HADD_ENGINEMODELNMRF; // �G���W���^������
                        row["HADD.RELEVANCEMODELRF"] = slipWork.HADD_RELEVANCEMODELRF; // �֘A�^��
                        row["HADD.SUBCARNMCDRF"] = slipWork.HADD_SUBCARNMCDRF; // �T�u�Ԗ��R�[�h
                        row["HADD.MODELGRADESNAMERF"] = slipWork.HADD_MODELGRADESNAMERF; // �^���O���[�h����
                        row["HADD.COLORCODERF"] = slipWork.HADD_COLORCODERF; // �J���[�R�[�h
                        row["HADD.COLORNAME1RF"] = slipWork.HADD_COLORNAME1RF; // �J���[����1
                        row["HADD.TRIMCODERF"] = slipWork.HADD_TRIMCODERF; // �g�����R�[�h
                        row["HADD.TRIMNAMERF"] = slipWork.HADD_TRIMNAMERF; // �g��������
                        row["HADD.MILEAGERF"] = slipWork.HADD_MILEAGERF; // �ԗ����s����
                        //row["HADD.PRINTERMNGNORF"] = slipWork.HADD_PRINTERMNGNORF; // �v�����^�Ǘ�No
                        //row["HADD.SLIPPRTSETPAPERIDRF"] = slipWork.HADD_SLIPPRTSETPAPERIDRF; // �`�[����ݒ�p���[ID
                        //row["HADD.NOTE1RF"] = slipWork.HADD_NOTE1RF; // ���Д��l�P
                        //row["HADD.NOTE2RF"] = slipWork.HADD_NOTE2RF; // ���Д��l�Q
                        //row["HADD.NOTE3RF"] = slipWork.HADD_NOTE3RF; // ���Д��l�R
                        //row["HADD.FIRSTENTRYDATEFYRF"] = slipWork.HADD_FIRSTENTRYDATEFYRF; // ���N�x����N
                        //row["HADD.FIRSTENTRYDATEFSRF"] = slipWork.HADD_FIRSTENTRYDATEFSRF; // ���N�x����N��
                        //row["HADD.FIRSTENTRYDATEFWRF"] = slipWork.HADD_FIRSTENTRYDATEFWRF; // ���N�x�a��N
                        //row["HADD.FIRSTENTRYDATEFMRF"] = slipWork.HADD_FIRSTENTRYDATEFMRF; // ���N�x��
                        //row["HADD.FIRSTENTRYDATEFGRF"] = slipWork.HADD_FIRSTENTRYDATEFGRF; // ���N�x����
                        //row["HADD.FIRSTENTRYDATEFRRF"] = slipWork.HADD_FIRSTENTRYDATEFRRF; // ���N�x����
                        //row["HADD.FIRSTENTRYDATEFLSRF"] = slipWork.HADD_FIRSTENTRYDATEFLSRF; // ���N�x���e����(/)
                        //row["HADD.FIRSTENTRYDATEFLPRF"] = slipWork.HADD_FIRSTENTRYDATEFLPRF; // ���N�x���e����(.)
                        //row["HADD.FIRSTENTRYDATEFLYRF"] = slipWork.HADD_FIRSTENTRYDATEFLYRF; // ���N�x���e����(�N)
                        //row["HADD.FIRSTENTRYDATEFLMRF"] = slipWork.HADD_FIRSTENTRYDATEFLMRF; // ���N�x���e����(��)
                        //row["HADD.PRINTCUSTOMERNM1RF"] = slipWork.HADD_PRINTCUSTOMERNM1RF; // ����p���Ӑ於��(��i)
                        //row["HADD.PRINTCUSTOMERNM2RF"] = slipWork.HADD_PRINTCUSTOMERNM2RF; // ����p���Ӑ於��(���i)
                        row["HPURE.SALESTOTALTAXINCRF"] = slipWork.HPURE_SALESTOTALTAXINCRF; // ��������`�[���v�i�ō��݁j
                        row["HPURE.SALESTOTALTAXEXCRF"] = slipWork.HPURE_SALESTOTALTAXEXCRF; // ��������`�[���v�i�Ŕ����j
                        row["HPURE.SALESSUBTOTALTAXINCRF"] = slipWork.HPURE_SALESSUBTOTALTAXINCRF; // �������㏬�v�i�ō��݁j
                        row["HPURE.SALESSUBTOTALTAXEXCRF"] = slipWork.HPURE_SALESSUBTOTALTAXEXCRF; // �������㏬�v�i�Ŕ����j
                        row["HPURE.SALESSUBTOTALTAXRF"] = slipWork.HPURE_SALESSUBTOTALTAXRF; // �������㏬�v�i�Łj
                        row["HPRIME.SALESTOTALTAXINCRF"] = slipWork.HPRIME_SALESTOTALTAXINCRF; // �D�ǔ���`�[���v�i�ō��݁j
                        row["HPRIME.SALESTOTALTAXEXCRF"] = slipWork.HPRIME_SALESTOTALTAXEXCRF; // �D�ǔ���`�[���v�i�Ŕ����j
                        row["HPRIME.SALESSUBTOTALTAXINCRF"] = slipWork.HPRIME_SALESSUBTOTALTAXINCRF; // �D�ǔ��㏬�v�i�ō��݁j
                        row["HPRIME.SALESSUBTOTALTAXEXCRF"] = slipWork.HPRIME_SALESSUBTOTALTAXEXCRF; // �D�ǔ��㏬�v�i�Ŕ����j
                        row["HPRIME.SALESSUBTOTALTAXRF"] = slipWork.HPRIME_SALESSUBTOTALTAXRF; // �D�ǔ��㏬�v�i�Łj
                        //row["HADD.PRINTTIMEHOURRF"] = slipWork.HADD_PRINTTIMEHOURRF; // ������� ��
                        //row["HADD.PRINTTIMEMINUTERF"] = slipWork.HADD_PRINTTIMEMINUTERF; // ������� ��
                        //row["HADD.PRINTTIMESECONDRF"] = slipWork.HADD_PRINTTIMESECONDRF; // ������� �b
                        row["HADD.ESTFMDIVRF"] = (int)slipWork.HADD_ESTFMDIVRF; // ���Ϗ��������敪
                        //row["HADD.SALESDATEFYRF"] = slipWork.HADD_SALESDATEFYRF; // ������t����N
                        //row["HADD.SALESDATEFSRF"] = slipWork.HADD_SALESDATEFSRF; // ������t����N��
                        //row["HADD.SALESDATEFWRF"] = slipWork.HADD_SALESDATEFWRF; // ������t�a��N
                        //row["HADD.SALESDATEFMRF"] = slipWork.HADD_SALESDATEFMRF; // ������t��
                        //row["HADD.SALESDATEFDRF"] = slipWork.HADD_SALESDATEFDRF; // ������t��
                        //row["HADD.SALESDATEFGRF"] = slipWork.HADD_SALESDATEFGRF; // ������t����
                        //row["HADD.SALESDATEFRRF"] = slipWork.HADD_SALESDATEFRRF; // ������t����
                        //row["HADD.SALESDATEFLSRF"] = slipWork.HADD_SALESDATEFLSRF; // ������t���e����(/)
                        //row["HADD.SALESDATEFLPRF"] = slipWork.HADD_SALESDATEFLPRF; // ������t���e����(.)
                        //row["HADD.SALESDATEFLYRF"] = slipWork.HADD_SALESDATEFLYRF; // ������t���e����(�N)
                        //row["HADD.SALESDATEFLMRF"] = slipWork.HADD_SALESDATEFLMRF; // ������t���e����(��)
                        //row["HADD.SALESDATEFLDRF"] = slipWork.HADD_SALESDATEFLDRF; // ������t���e����(��)
                        //row["HADD.SALESSLIPPRINTDATEFYRF"] = slipWork.HADD_SALESSLIPPRINTDATEFYRF; // ����`�[���s������N
                        //row["HADD.SALESSLIPPRINTDATEFSRF"] = slipWork.HADD_SALESSLIPPRINTDATEFSRF; // ����`�[���s������N��
                        //row["HADD.SALESSLIPPRINTDATEFWRF"] = slipWork.HADD_SALESSLIPPRINTDATEFWRF; // ����`�[���s���a��N
                        //row["HADD.SALESSLIPPRINTDATEFMRF"] = slipWork.HADD_SALESSLIPPRINTDATEFMRF; // ����`�[���s����
                        //row["HADD.SALESSLIPPRINTDATEFDRF"] = slipWork.HADD_SALESSLIPPRINTDATEFDRF; // ����`�[���s����
                        //row["HADD.SALESSLIPPRINTDATEFGRF"] = slipWork.HADD_SALESSLIPPRINTDATEFGRF; // ����`�[���s������
                        //row["HADD.SALESSLIPPRINTDATEFRRF"] = slipWork.HADD_SALESSLIPPRINTDATEFRRF; // ����`�[���s������
                        //row["HADD.SALESSLIPPRINTDATEFLSRF"] = slipWork.HADD_SALESSLIPPRINTDATEFLSRF; // ����`�[���s�����e����(/)
                        //row["HADD.SALESSLIPPRINTDATEFLPRF"] = slipWork.HADD_SALESSLIPPRINTDATEFLPRF; // ����`�[���s�����e����(.)
                        //row["HADD.SALESSLIPPRINTDATEFLYRF"] = slipWork.HADD_SALESSLIPPRINTDATEFLYRF; // ����`�[���s�����e����(�N)
                        //row["HADD.SALESSLIPPRINTDATEFLMRF"] = slipWork.HADD_SALESSLIPPRINTDATEFLMRF; // ����`�[���s�����e����(��)
                        //row["HADD.SALESSLIPPRINTDATEFLDRF"] = slipWork.HADD_SALESSLIPPRINTDATEFLDRF; // ����`�[���s�����e����(��)
                        row["HADD.SYSTEMATICCODERF"] = slipWork.HADD_SYSTEMATICCODERF; // �n���R�[�h
                        row["HADD.SYSTEMATICNAMERF"] = slipWork.HADD_SYSTEMATICNAMERF; // �n������
                        //row["HADD.STPRODUCETYPEOFYEARRF"] = slipWork.HADD_STPRODUCETYPEOFYEARRF; // �J�n���Y�N��
                        //row["HADD.EDPRODUCETYPEOFYEARRF"] = slipWork.HADD_EDPRODUCETYPEOFYEARRF; // �I�����Y�N��
                        row["HADD.DOORCOUNTRF"] = slipWork.HADD_DOORCOUNTRF; // �h�A��
                        row["HADD.BODYNAMECODERF"] = slipWork.HADD_BODYNAMECODERF; // �{�f�B�[���R�[�h
                        row["HADD.BODYNAMERF"] = slipWork.HADD_BODYNAMERF; // �{�f�B�[����
                        row["HADD.STPRODUCEFRAMENORF"] = slipWork.HADD_STPRODUCEFRAMENORF; // ���Y�ԑ�ԍ��J�n
                        row["HADD.EDPRODUCEFRAMENORF"] = slipWork.HADD_EDPRODUCEFRAMENORF; // ���Y�ԑ�ԍ��I��
                        row["HADD.ENGINEMODELRF"] = slipWork.HADD_ENGINEMODELRF; // �����@�^���i�G���W���j
                        row["HADD.MODELGRADENMRF"] = slipWork.HADD_MODELGRADENMRF; // �^���O���[�h����
                        row["HADD.ENGINEDISPLACENMRF"] = slipWork.HADD_ENGINEDISPLACENMRF; // �r�C�ʖ���
                        row["HADD.EDIVNMRF"] = slipWork.HADD_EDIVNMRF; // E�敪����
                        row["HADD.TRANSMISSIONNMRF"] = slipWork.HADD_TRANSMISSIONNMRF; // �~�b�V��������
                        row["HADD.SHIFTNMRF"] = slipWork.HADD_SHIFTNMRF; // �V�t�g����
                        row["HADD.WHEELDRIVEMETHODNMRF"] = slipWork.HADD_WHEELDRIVEMETHODNMRF; // �쓮��������
                        row["HADD.ADDICARSPEC1RF"] = slipWork.HADD_ADDICARSPEC1RF; // �ǉ�����1
                        row["HADD.ADDICARSPEC2RF"] = slipWork.HADD_ADDICARSPEC2RF; // �ǉ�����2
                        row["HADD.ADDICARSPEC3RF"] = slipWork.HADD_ADDICARSPEC3RF; // �ǉ�����3
                        row["HADD.ADDICARSPEC4RF"] = slipWork.HADD_ADDICARSPEC4RF; // �ǉ�����4
                        row["HADD.ADDICARSPEC5RF"] = slipWork.HADD_ADDICARSPEC5RF; // �ǉ�����5
                        row["HADD.ADDICARSPEC6RF"] = slipWork.HADD_ADDICARSPEC6RF; // �ǉ�����6
                        row["HADD.ADDICARSPECTITLE1RF"] = slipWork.HADD_ADDICARSPECTITLE1RF; // �ǉ������^�C�g��1
                        row["HADD.ADDICARSPECTITLE2RF"] = slipWork.HADD_ADDICARSPECTITLE2RF; // �ǉ������^�C�g��2
                        row["HADD.ADDICARSPECTITLE3RF"] = slipWork.HADD_ADDICARSPECTITLE3RF; // �ǉ������^�C�g��3
                        row["HADD.ADDICARSPECTITLE4RF"] = slipWork.HADD_ADDICARSPECTITLE4RF; // �ǉ������^�C�g��4
                        row["HADD.ADDICARSPECTITLE5RF"] = slipWork.HADD_ADDICARSPECTITLE5RF; // �ǉ������^�C�g��5
                        row["HADD.ADDICARSPECTITLE6RF"] = slipWork.HADD_ADDICARSPECTITLE6RF; // �ǉ������^�C�g��6
                        //row["HADD.STPRODUCETYPEOFYEARFYRF"] = slipWork.HADD_STPRODUCETYPEOFYEARFYRF; // �J�n���Y�N������N
                        //row["HADD.STPRODUCETYPEOFYEARFSRF"] = slipWork.HADD_STPRODUCETYPEOFYEARFSRF; // �J�n���Y�N������N��
                        //row["HADD.STPRODUCETYPEOFYEARFWRF"] = slipWork.HADD_STPRODUCETYPEOFYEARFWRF; // �J�n���Y�N���a��N
                        //row["HADD.STPRODUCETYPEOFYEARFMRF"] = slipWork.HADD_STPRODUCETYPEOFYEARFMRF; // �J�n���Y�N����
                        //row["HADD.STPRODUCETYPEOFYEARFGRF"] = slipWork.HADD_STPRODUCETYPEOFYEARFGRF; // �J�n���Y�N������
                        //row["HADD.STPRODUCETYPEOFYEARFRRF"] = slipWork.HADD_STPRODUCETYPEOFYEARFRRF; // �J�n���Y�N������
                        //row["HADD.STPRODUCETYPEOFYEARFLSRF"] = slipWork.HADD_STPRODUCETYPEOFYEARFLSRF; // �J�n���Y�N�����e����(/)
                        //row["HADD.STPRODUCETYPEOFYEARFLPRF"] = slipWork.HADD_STPRODUCETYPEOFYEARFLPRF; // �J�n���Y�N�����e����(.)
                        //row["HADD.STPRODUCETYPEOFYEARFLYRF"] = slipWork.HADD_STPRODUCETYPEOFYEARFLYRF; // �J�n���Y�N�����e����(�N)
                        //row["HADD.STPRODUCETYPEOFYEARFLMRF"] = slipWork.HADD_STPRODUCETYPEOFYEARFLMRF; // �J�n���Y�N�����e����(��)
                        //row["HADD.EDPRODUCETYPEOFYEARFYRF"] = slipWork.HADD_EDPRODUCETYPEOFYEARFYRF; // �I�����Y�N������N
                        //row["HADD.EDPRODUCETYPEOFYEARFSRF"] = slipWork.HADD_EDPRODUCETYPEOFYEARFSRF; // �I�����Y�N������N��
                        //row["HADD.EDPRODUCETYPEOFYEARFWRF"] = slipWork.HADD_EDPRODUCETYPEOFYEARFWRF; // �I�����Y�N���a��N
                        //row["HADD.EDPRODUCETYPEOFYEARFMRF"] = slipWork.HADD_EDPRODUCETYPEOFYEARFMRF; // �I�����Y�N����
                        //row["HADD.EDPRODUCETYPEOFYEARFGRF"] = slipWork.HADD_EDPRODUCETYPEOFYEARFGRF; // �I�����Y�N������
                        //row["HADD.EDPRODUCETYPEOFYEARFRRF"] = slipWork.HADD_EDPRODUCETYPEOFYEARFRRF; // �I�����Y�N������
                        //row["HADD.EDPRODUCETYPEOFYEARFLSRF"] = slipWork.HADD_EDPRODUCETYPEOFYEARFLSRF; // �I�����Y�N�����e����(/)
                        //row["HADD.EDPRODUCETYPEOFYEARFLPRF"] = slipWork.HADD_EDPRODUCETYPEOFYEARFLPRF; // �I�����Y�N�����e����(.)
                        //row["HADD.EDPRODUCETYPEOFYEARFLYRF"] = slipWork.HADD_EDPRODUCETYPEOFYEARFLYRF; // �I�����Y�N�����e����(�N)
                        //row["HADD.EDPRODUCETYPEOFYEARFLMRF"] = slipWork.HADD_EDPRODUCETYPEOFYEARFLMRF; // �I�����Y�N�����e����(��)
                        # endregion

                        # region [�`�[����(�����ȊO)]

                        // ���ݒ莞 ��󎚃R�[�h
                        # region [���ݒ�]
                        if ( IsZero( slipWork.SALESSLIPRF_SECTIONCODERF ) ) row["SALESSLIPRF.SECTIONCODERF"] = DBNull.Value; // ���_�R�[�h
                        if ( IsZero( slipWork.SALESSLIPRF_SALESINPUTCODERF ) ) row["SALESSLIPRF.SALESINPUTCODERF"] = DBNull.Value; // ������͎҃R�[�h
                        if ( IsZero( slipWork.SALESSLIPRF_SALESINPUTNAMERF ) ) row["SALESSLIPRF.SALESINPUTNAMERF"] = DBNull.Value; // ������͎Җ���
                        if ( IsZero( slipWork.SALESSLIPRF_FRONTEMPLOYEECDRF ) ) row["SALESSLIPRF.FRONTEMPLOYEECDRF"] = DBNull.Value; // ��t�]�ƈ��R�[�h
                        if ( IsZero( slipWork.SALESSLIPRF_FRONTEMPLOYEENMRF ) ) row["SALESSLIPRF.FRONTEMPLOYEENMRF"] = DBNull.Value; // ��t�]�ƈ�����
                        if ( IsZero( slipWork.SALESSLIPRF_SALESEMPLOYEECDRF ) ) row["SALESSLIPRF.SALESEMPLOYEECDRF"] = DBNull.Value; // �̔��]�ƈ��R�[�h
                        if ( IsZero( slipWork.SALESSLIPRF_CUSTOMERCODERF ) ) row["SALESSLIPRF.CUSTOMERCODERF"] = DBNull.Value; // ���Ӑ�R�[�h
                        if ( IsZero( slipWork.HADD_MAKERCODERF ) ) row["HADD.MAKERCODERF"] = DBNull.Value; // ���[�J�[�R�[�h
                        if ( IsZero( slipWork.HADD_MODELCODERF ) ) row["HADD.MODELCODERF"] = DBNull.Value; // �Ԏ�R�[�h
                        if ( IsZero( slipWork.HADD_MODELSUBCODERF ) ) row["HADD.MODELSUBCODERF"] = DBNull.Value; // �Ԏ�T�u�R�[�h
                        if ( IsZero( slipWork.HADD_MODELDESIGNATIONNORF ) ) row["HADD.MODELDESIGNATIONNORF"] = DBNull.Value; // �^���w��ԍ�
                        if ( IsZero( slipWork.HADD_CATEGORYNORF ) ) row["HADD.CATEGORYNORF"] = DBNull.Value; // �ޕʔԍ�
                        if ( IsZero( slipWork.HADD_SYSTEMATICCODERF ) ) row["HADD.SYSTEMATICCODERF"] = DBNull.Value; // �n���R�[�h
                        if ( IsZero( slipWork.HADD_DOORCOUNTRF ) ) row["HADD.DOORCOUNTRF"] = DBNull.Value; // �h�A��
                        if ( IsZero( slipWork.HADD_BODYNAMECODERF ) ) row["HADD.BODYNAMECODERF"] = DBNull.Value; // �{�f�B�[���R�[�h
                        if ( IsZero( slipWork.HADD_CARMNGNORF ) ) row["HADD.CARMNGNORF"] = DBNull.Value; // �ԗ��Ǘ��ԍ�
                        if ( IsZero( slipWork.HADD_NUMBERPLATE1CODERF ) ) row["HADD.NUMBERPLATE1CODERF"] = DBNull.Value; // ���^�������ԍ�
                        if ( IsZero( slipWork.HADD_NUMBERPLATE4RF ) ) row["HADD.NUMBERPLATE4RF"] = DBNull.Value; // �ԗ��o�^�ԍ��i�v���[�g�ԍ��j
                        if ( IsZero( slipWork.HADD_SEARCHFRAMENORF ) ) row["HADD.SEARCHFRAMENORF"] = DBNull.Value; // �ԑ�ԍ��i�����p�j
                        if ( IsZero( slipWork.HADD_SUBCARNMCDRF ) ) row["HADD.SUBCARNMCDRF"] = DBNull.Value; // �T�u�Ԗ��R�[�h
                        # endregion

                        // ���Д��l
                        # region [���Д��l]
                        row["HADD.NOTE1RF"] = slipPrtSet.Note1; // ���Д��l�P
                        row["HADD.NOTE2RF"] = slipPrtSet.Note2; // ���Д��l�Q
                        row["HADD.NOTE3RF"] = slipPrtSet.Note3; // ���Д��l�R
                        # endregion

                        ////// �Ĕ��s�}�[�N
                        ////if ( slipPrintParameter.ReissueDiv )
                        ////{
                        ////    row["HADD.REISSUEMARKRF"] = slipPrtSet.ReissueMark; // �Ĕ��s�}�[�N
                        ////}
                        ////else
                        ////{
                        ////    row["HADD.REISSUEMARKRF"] = string.Empty;
                        ////}

                        // ���t�֘A�W�J
                        # region [���t]
                        // �ʏ�
                        ExtractDate( ref row, allDefSet.EraNameDispCd2, slipWork.HEST_ESTIMATEVALIDITYLIMITRF, "HEST.ESTIMATEVALIDITYLIMIT", false ); // ���Ϗ��L������
                        ExtractDate( ref row, allDefSet.EraNameDispCd2, slipWork.SALESSLIPRF_SALESDATERF, "HADD.SALESDATE", false ); // ������t
                        ExtractDate( ref row, allDefSet.EraNameDispCd2, slipWork.SALESSLIPRF_SALESSLIPPRINTDATERF, "HADD.SALESSLIPPRINTDATE", false ); // ����`�[���s��
                        // �N��
                        ExtractDate( ref row, allDefSet.EraNameDispCd1, slipWork.HADD_FIRSTENTRYDATERF, "HADD.FIRSTENTRYDATE", true ); // ���N�x
                        ExtractDate( ref row, allDefSet.EraNameDispCd1, slipWork.HADD_STPRODUCETYPEOFYEARRF, "HADD.STPRODUCETYPEOFYEAR", true ); // �J�n���Y�N��
                        ExtractDate( ref row, allDefSet.EraNameDispCd1, slipWork.HADD_EDPRODUCETYPEOFYEARRF, "HADD.EDPRODUCETYPEOFYEAR", true ); // �I�����Y�N��
                        # endregion

                        // ���Ӑ於��
                        # region [���Ӑ於��]
                        if ( slipWork.SALESSLIPRF_CUSTOMERNAME2RF.Trim() != string.Empty )
                        {
                            // ��F���̂P
                            // ���F���̂Q�{�h��
                            row["HADD.PRINTCUSTOMERNM1RF"] = slipWork.SALESSLIPRF_CUSTOMERNAMERF.Trim();
                            row["HADD.PRINTCUSTOMERNM2RF"] = slipWork.SALESSLIPRF_CUSTOMERNAME2RF.Trim() + "  " + slipWork.SALESSLIPRF_HONORIFICTITLERF.Trim();
                        }
                        else
                        {
                            //// ��F��
                            //// ���F���̂P�{�h��
                            //row["HADD.PRINTCUSTOMERNM1RF"] = DBNull.Value;
                            //row["HADD.PRINTCUSTOMERNM2RF"] = slipWork.SALESSLIPRF_CUSTOMERNAMERF.Trim() + "  " + slipWork.SALESSLIPRF_HONORIFICTITLERF.Trim();

                            // ��F���̂P�{�h��
                            // ���F��
                            row["HADD.PRINTCUSTOMERNM1RF"] = slipWork.SALESSLIPRF_CUSTOMERNAMERF.Trim() + "  " + slipWork.SALESSLIPRF_HONORIFICTITLERF.Trim();
                            row["HADD.PRINTCUSTOMERNM2RF"] = DBNull.Value;
                        }
                        // ���̂P�{���̂Q
                        row["HPRT.PRINTCUSTOMERNAMEJOIN12RF"] = slipWork.SALESSLIPRF_CUSTOMERNAMERF + slipWork.SALESSLIPRF_CUSTOMERNAME2RF;

                        // --- UPD m.suzuki 2010/03/08 ---------->>>>>
                        //// ���̂P�{���̂Q�{�󔒁{�h��
                        //row["HPRT.PRINTCUSTOMERNAMEJOIN12HNRF"] = (string)row["HPRT.PRINTCUSTOMERNAMEJOIN12RF"] + "�@" + slipWork.SALESSLIPRF_HONORIFICTITLERF.Trim();

                        // ���Ӑ於�̂P�{���Ӑ於�̂Q��20���܂Ŏ擾
                        string printCustomerNameJoin12 = (string)row["HPRT.PRINTCUSTOMERNAMEJOIN12RF"];
                        printCustomerNameJoin12 = printCustomerNameJoin12.PadRight( 20, ' ' ).Substring( 0, 20 ).TrimEnd();

                        // PM7�̓��Ӑ於�̂Ɠ��l�̐�����s��
                        if ( slipWork.SALESSLIPRF_CUSTOMERNAMERF.Trim() != string.Empty )
                        {
                            if ( slipWork.SALESSLIPRF_CUSTOMERNAME2RF.Trim() != string.Empty )
                            {
                                // ���̂P�{���̂Q�{�h��
                                row["HPRT.PRINTCUSTOMERNAMEJOIN12HNRF"] = printCustomerNameJoin12 + slipWork.SALESSLIPRF_HONORIFICTITLERF.Trim();
                            }
                            else
                            {
                                // ���̂P�{(���̂Q�{)�󔒁{�h��
                                row["HPRT.PRINTCUSTOMERNAMEJOIN12HNRF"] = printCustomerNameJoin12 + "�@" + slipWork.SALESSLIPRF_HONORIFICTITLERF.Trim();
                            }
                        }
                        else
                        {
                            if ( slipWork.SALESSLIPRF_CUSTOMERNAME2RF.Trim() != string.Empty )
                            {
                                // (���̂P�{)���̂Q�{�󔒁{�h��
                                row["HPRT.PRINTCUSTOMERNAMEJOIN12HNRF"] = printCustomerNameJoin12 + "�@" + slipWork.SALESSLIPRF_HONORIFICTITLERF.Trim();
                            }
                            else
                            {
                                // ��
                                row["HPRT.PRINTCUSTOMERNAMEJOIN12HNRF"] = string.Empty;
                            }
                        }
                        // --- UPD m.suzuki 2010/03/08 ----------<<<<<
                        # endregion

                        // �c�{�p�Ή�
                        # region [�c�{�p�Ή�]
                        // ������ȑO�̏�����row�ɃZ�b�g�������e���g�p���܂��B

                        // �����T�C�Y (0:�W��,1:��)
                        if ( slipPrtSet.SlipFontSize == 0 )
                        {
                            // �W��
                            row["HLG.PRINTCUSTOMERNAMEJOIN12RF"] = DBNull.Value;  // �i�c�{�j���Ӑ於�P�{���Ӑ於�Q
                            row["HLG.PRINTCUSTOMERNAMEJOIN12HNRF"] = DBNull.Value;  // �i�c�{�j���Ӑ於�P�{���Ӑ於�Q�{�h��
                            row["HLG.CUSTOMERNAMERF"] = DBNull.Value;  // �i�c�{�j���Ӑ於��
                            row["HLG.CUSTOMERNAME2RF"] = DBNull.Value;  // �i�c�{�j���Ӑ於��2
                            row["HLG.CUSTOMERSNMRF"] = DBNull.Value;  // �i�c�{�j���Ӑ旪��
                            row["HLG.HONORIFICTITLERF"] = DBNull.Value;  // �i�c�{�j���Ӑ�h��
                            row["HLG.PRINTCUSTOMERNM1RF"] = DBNull.Value;  // �i�c�{�j����p���Ӑ於��(��i)
                            row["HLG.PRINTCUSTOMERNM2RF"] = DBNull.Value;  // �i�c�{�j����p���Ӑ於��(���i)
                        
                        }
                        else
                        {
                            // �c�{�p
                            row["HLG.PRINTCUSTOMERNAMEJOIN12RF"] = row["HPRT.PRINTCUSTOMERNAMEJOIN12RF"];  // �i�c�{�j���Ӑ於�P�{���Ӑ於�Q
                            row["HLG.PRINTCUSTOMERNAMEJOIN12HNRF"] = row["HPRT.PRINTCUSTOMERNAMEJOIN12HNRF"];  // �i�c�{�j���Ӑ於�P�{���Ӑ於�Q�{�h��
                            row["HLG.CUSTOMERNAMERF"] = row["SALESSLIPRF.CUSTOMERNAMERF"];  // �i�c�{�j���Ӑ於��
                            row["HLG.CUSTOMERNAME2RF"] = row["SALESSLIPRF.CUSTOMERNAME2RF"];  // �i�c�{�j���Ӑ於��2
                            row["HLG.CUSTOMERSNMRF"] = row["SALESSLIPRF.CUSTOMERSNMRF"];  // �i�c�{�j���Ӑ旪��
                            row["HLG.HONORIFICTITLERF"] = row["SALESSLIPRF.HONORIFICTITLERF"];  // �i�c�{�j���Ӑ�h��
                            row["HLG.PRINTCUSTOMERNM1RF"] = row["HADD.PRINTCUSTOMERNM1RF"];  // �i�c�{�j����p���Ӑ於��(��i)
                            row["HLG.PRINTCUSTOMERNM2RF"] = row["HADD.PRINTCUSTOMERNM2RF"];  // �i�c�{�j����p���Ӑ於��(���i)

                            row["SALESSLIPRF.CUSTOMERNAMERF"] = DBNull.Value; // ���Ӑ於��
                            row["SALESSLIPRF.CUSTOMERNAME2RF"] = DBNull.Value; // ���Ӑ於��2
                            row["SALESSLIPRF.CUSTOMERSNMRF"] = DBNull.Value; // ���Ӑ旪��
                            row["SALESSLIPRF.HONORIFICTITLERF"] = DBNull.Value; // ���Ӑ�h��
                            row["HADD.PRINTCUSTOMERNM1RF"] = DBNull.Value; // ����p���Ӑ於��(��i)
                            row["HADD.PRINTCUSTOMERNM2RF"] = DBNull.Value; // ����p���Ӑ於��(���i)
                            row["HPRT.PRINTCUSTOMERNAMEJOIN12RF"] = DBNull.Value; // ���Ӑ於�P�{���Ӑ於�Q
                            row["HPRT.PRINTCUSTOMERNAMEJOIN12HNRF"] = DBNull.Value; // ���Ӑ於�P�{���Ӑ於�Q�{�h��
                        }
                        # endregion

                        // ����
                        # region [����]
                        row["HADD.PRINTTIMEHOURRF"] = slipWork.HADD_PRINTTIMEHOURRF; // �������HH
                        row["HADD.PRINTTIMEMINUTERF"] = slipWork.HADD_PRINTTIMEMINUTERF; // �������MM
                        row["HADD.PRINTTIMESECONDRF"] = slipWork.HADD_PRINTTIMESECONDRF; // �������SS
                        # endregion

                        // ���v��
                        # region [���v���̐���]

                        bool subTotalPrintEnable = true;
                        bool totalPrintEnable = true;
                        bool taxPrintEnable = true;

                        // ���v���͍ŏ��̃w�b�_�܂��͍ŏI�̃t�b�^�݈̂�
                        if ( index == 0 || index == allDetailCount - 1 )
                        {
                            // ����ŋ敪 0:����@1:���Ȃ�
                            if ( estimateDefSet.ConsTaxPrintDiv == 0 )
                            {
                                // �]�ŕ����@0:�`�[�P��1:���גP��2:�����e 3:�����q 9:��ې�
                                switch ( slipWork.SALESSLIPRF_CONSTAXLAYMETHODRF )
                                {
                                    case 0:
                                    case 1:
                                        {
                                        }
                                        break;
                                    case 2:
                                    case 3:
                                        {
                                            totalPrintEnable = false;
                                        }
                                        break;
                                    case 9:
                                    default:
                                        {
                                            totalPrintEnable = false;
                                            taxPrintEnable = false;
                                        }
                                        break;
                                }
                            }
                            else
                            {
                                totalPrintEnable = false;
                                taxPrintEnable = false;
                            }
                        }
                        else
                        {
                            subTotalPrintEnable = false;
                            totalPrintEnable = false;
                            taxPrintEnable = false;
                        }

                        // ���v�i�Ŕ��j
                        if ( subTotalPrintEnable == false )
                        {
                            row["HPURE.SALESTOTALTAXEXCRF"] = DBNull.Value; // ��������`�[���v�i�Ŕ����j
                            row["HPURE.SALESSUBTOTALTAXEXCRF"] = DBNull.Value; // �������㏬�v�i�Ŕ����j
                            row["HPRIME.SALESTOTALTAXEXCRF"] = DBNull.Value; // �D�ǔ���`�[���v�i�Ŕ����j
                            row["HPRIME.SALESSUBTOTALTAXEXCRF"] = DBNull.Value; // �D�ǔ��㏬�v�i�Ŕ����j
                        }
                        // ���v�i�ō��j
                        if ( totalPrintEnable == false )
                        {
                            row["HPURE.SALESTOTALTAXINCRF"] = DBNull.Value; // ��������`�[���v�i�ō��݁j
                            row["HPURE.SALESSUBTOTALTAXINCRF"] = DBNull.Value; // �������㏬�v�i�ō��݁j
                            row["HPRIME.SALESTOTALTAXINCRF"] = DBNull.Value; // �D�ǔ���`�[���v�i�ō��݁j
                            row["HPRIME.SALESSUBTOTALTAXINCRF"] = DBNull.Value; // �D�ǔ��㏬�v�i�ō��݁j
                        }
                        // ��
                        if ( taxPrintEnable == false )
                        {
                            row["HPURE.SALESSUBTOTALTAXRF"] = DBNull.Value; // �������㏬�v�i�Łj
                            row["HPRIME.SALESSUBTOTALTAXRF"] = DBNull.Value; // �D�ǔ��㏬�v�i�Łj
                        }
                        # endregion

                        // �ޕʌ^���n�C�t��
                        # region [�ޕʌ^���n�C�t��]
                        if ( slipWork.HADD_CATEGORYNORF == 0 && slipWork.HADD_MODELDESIGNATIONNORF == 0 )
                        {
                            row[ct_HCategoryHyp] = DBNull.Value;
                        }
                        else
                        {
                            row[ct_HCategoryHyp] = "-";
                        }
                        # endregion

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
                                    row["COMPANYNMRF.COMPANYNAME1RF"] = slipWork.COMPANYINFRF_COMPANYNAME1RF; // ���Ж���1
                                    row["COMPANYNMRF.COMPANYNAME2RF"] = slipWork.COMPANYINFRF_COMPANYNAME2RF; // ���Ж���2
                                    row["COMPANYNMRF.POSTNORF"] = slipWork.COMPANYINFRF_POSTNORF; // �X�֔ԍ�
                                    row["COMPANYNMRF.ADDRESS1RF"] = slipWork.COMPANYINFRF_ADDRESS1RF; // �Z��1�i�s���{���s��S�E�����E���j
                                    row["COMPANYNMRF.ADDRESS3RF"] = slipWork.COMPANYINFRF_ADDRESS3RF; // �Z��3�i�Ԓn�j
                                    row["COMPANYNMRF.ADDRESS4RF"] = slipWork.COMPANYINFRF_ADDRESS4RF; // �Z��4�i�A�p�[�g���́j
                                    row["COMPANYNMRF.COMPANYTELNO1RF"] = slipWork.COMPANYINFRF_COMPANYTELNO1RF; // ���Гd�b�ԍ�1
                                    row["COMPANYNMRF.COMPANYTELNO2RF"] = slipWork.COMPANYINFRF_COMPANYTELNO2RF; // ���Гd�b�ԍ�2
                                    row["COMPANYNMRF.COMPANYTELNO3RF"] = slipWork.COMPANYINFRF_COMPANYTELNO3RF; // ���Гd�b�ԍ�3
                                    row["COMPANYNMRF.COMPANYTELTITLE1RF"] = slipWork.COMPANYINFRF_COMPANYTELTITLE1RF; // ���Гd�b�ԍ��^�C�g��1
                                    row["COMPANYNMRF.COMPANYTELTITLE2RF"] = slipWork.COMPANYINFRF_COMPANYTELTITLE2RF; // ���Гd�b�ԍ��^�C�g��2
                                    row["COMPANYNMRF.COMPANYTELTITLE3RF"] = slipWork.COMPANYINFRF_COMPANYTELTITLE3RF; // ���Гd�b�ԍ��^�C�g��3
                                    // bitmap�Ȃ�
                                    row["COMPANYNMRF.IMAGECOMMENTFORPRT1RF"] = DBNull.Value; // �摜�󎚗p�R�����g1
                                    row["COMPANYNMRF.IMAGECOMMENTFORPRT2RF"] = DBNull.Value; // �摜�󎚗p�R�����g2
                                    row["IMAGEINFORF.IMAGEINFODATARF"] = DBNull.Value; // �摜���f�[�^
                                }
                                break;
                            // ���_��
                            case 1:
                                {
                                    // bitmap�Ȃ�
                                    row["COMPANYNMRF.IMAGECOMMENTFORPRT1RF"] = DBNull.Value; // �摜�󎚗p�R�����g1
                                    row["COMPANYNMRF.IMAGECOMMENTFORPRT2RF"] = DBNull.Value; // �摜�󎚗p�R�����g2
                                    row["IMAGEINFORF.IMAGEINFODATARF"] = DBNull.Value; // �摜���f�[�^
                                }
                                break;
                            // �r�b�g�}�b�v
                            case 2:
                                {
                                    // ���Џ�񕶎���Ȃ�
                                    row["COMPANYNMRF.COMPANYNAME1RF"] = DBNull.Value; // ���Ж���1
                                    row["COMPANYNMRF.COMPANYNAME2RF"] = DBNull.Value; // ���Ж���2
                                    row["COMPANYNMRF.POSTNORF"] = DBNull.Value; // �X�֔ԍ�
                                    row["COMPANYNMRF.ADDRESS1RF"] = DBNull.Value; // �Z��1�i�s���{���s��S�E�����E���j
                                    row["COMPANYNMRF.ADDRESS3RF"] = DBNull.Value; // �Z��3�i�Ԓn�j
                                    row["COMPANYNMRF.ADDRESS4RF"] = DBNull.Value; // �Z��4�i�A�p�[�g���́j
                                    row["COMPANYNMRF.COMPANYTELNO1RF"] = DBNull.Value; // ���Гd�b�ԍ�1
                                    row["COMPANYNMRF.COMPANYTELNO2RF"] = DBNull.Value; // ���Гd�b�ԍ�2
                                    row["COMPANYNMRF.COMPANYTELNO3RF"] = DBNull.Value; // ���Гd�b�ԍ�3
                                    row["COMPANYNMRF.COMPANYTELTITLE1RF"] = DBNull.Value; // ���Гd�b�ԍ��^�C�g��1
                                    row["COMPANYNMRF.COMPANYTELTITLE2RF"] = DBNull.Value; // ���Гd�b�ԍ��^�C�g��2
                                    row["COMPANYNMRF.COMPANYTELTITLE3RF"] = DBNull.Value; // ���Гd�b�ԍ��^�C�g��3
                                }
                                break;
                            // �󎚂��Ȃ�
                            case 3:
                            default:
                                {
                                    // ���Џ�񕶎���Ȃ�
                                    row["COMPANYNMRF.COMPANYNAME1RF"] = DBNull.Value; // ���Ж���1
                                    row["COMPANYNMRF.COMPANYNAME2RF"] = DBNull.Value; // ���Ж���2
                                    row["COMPANYNMRF.POSTNORF"] = DBNull.Value; // �X�֔ԍ�
                                    row["COMPANYNMRF.ADDRESS1RF"] = DBNull.Value; // �Z��1�i�s���{���s��S�E�����E���j
                                    row["COMPANYNMRF.ADDRESS3RF"] = DBNull.Value; // �Z��3�i�Ԓn�j
                                    row["COMPANYNMRF.ADDRESS4RF"] = DBNull.Value; // �Z��4�i�A�p�[�g���́j
                                    row["COMPANYNMRF.COMPANYTELNO1RF"] = DBNull.Value; // ���Гd�b�ԍ�1
                                    row["COMPANYNMRF.COMPANYTELNO2RF"] = DBNull.Value; // ���Гd�b�ԍ�2
                                    row["COMPANYNMRF.COMPANYTELNO3RF"] = DBNull.Value; // ���Гd�b�ԍ�3
                                    row["COMPANYNMRF.COMPANYTELTITLE1RF"] = DBNull.Value; // ���Гd�b�ԍ��^�C�g��1
                                    row["COMPANYNMRF.COMPANYTELTITLE2RF"] = DBNull.Value; // ���Гd�b�ԍ��^�C�g��2
                                    row["COMPANYNMRF.COMPANYTELTITLE3RF"] = DBNull.Value; // ���Гd�b�ԍ��^�C�g��3
                                    // bitmap�Ȃ�
                                    row["COMPANYNMRF.IMAGECOMMENTFORPRT1RF"] = DBNull.Value; // �摜�󎚗p�R�����g1
                                    row["COMPANYNMRF.IMAGECOMMENTFORPRT2RF"] = DBNull.Value; // �摜�󎚗p�R�����g2
                                    row["IMAGEINFORF.IMAGEINFODATARF"] = DBNull.Value; // �摜���f�[�^
                                }
                                break;
                        }
                        // ���Ж��P����
                        if ( row["COMPANYNMRF.COMPANYNAME1RF"] != DBNull.Value )
                        {
                            string firstHalf;
                            string lastHalf;
                            DivideEnterpriseName( (string)row["COMPANYNMRF.COMPANYNAME1RF"], out firstHalf, out lastHalf );
                            row["HPRT.PRINTENTERPRISENAME1FHRF"] = firstHalf;
                            row["HPRT.PRINTENTERPRISENAME1LHRF"] = lastHalf;
                        }
                        else
                        {
                            row["HPRT.PRINTENTERPRISENAME1FHRF"] = DBNull.Value;
                            row["HPRT.PRINTENTERPRISENAME1LHRF"] = DBNull.Value;
                        }
                        // ���Ж��Q����
                        if ( row["COMPANYNMRF.COMPANYNAME2RF"] != DBNull.Value )
                        {
                            string firstHalf;
                            string lastHalf;
                            DivideEnterpriseName( (string)row["COMPANYNMRF.COMPANYNAME2RF"], out firstHalf, out lastHalf );
                            row["HPRT.PRINTENTERPRISENAME2FHRF"] = firstHalf;
                            row["HPRT.PRINTENTERPRISENAME2LHRF"] = lastHalf;
                        }
                        else
                        {
                            row["HPRT.PRINTENTERPRISENAME2FHRF"] = DBNull.Value;
                            row["HPRT.PRINTENTERPRISENAME2LHRF"] = DBNull.Value;
                        }
                        # endregion
                    }

                    if ( index < detailWorks.Count )
                    {
                        //-------------------------------------------
                        // ������
                        //-------------------------------------------

                        # region [���׍���Copy]
                        row["SALESDETAILRF.SALESSLIPNUMRF"] = detailWorks[index].SALESDETAILRF_SALESSLIPNUMRF; // ����`�[�ԍ�
                        row["SALESDETAILRF.SALESROWNORF"] = detailWorks[index].SALESDETAILRF_SALESROWNORF; // ����s�ԍ�
                        row["DPURE.GOODSMAKERCDRF"] = detailWorks[index].DPURE_GOODSMAKERCDRF; // �������i���[�J�[�R�[�h
                        row["DPURE.MAKERNAMERF"] = detailWorks[index].DPURE_MAKERNAMERF; // �������[�J�[����
                        row["DPURE.MAKERKANANAMERF"] = detailWorks[index].DPURE_MAKERKANANAMERF; // �������[�J�[�J�i����
                        row["DPURE.GOODSNORF"] = detailWorks[index].DPURE_GOODSNORF; // �������i�ԍ�
                        row["DPURE.GOODSNAMERF"] = detailWorks[index].DPURE_GOODSNAMERF; // �������i����
                        row["DPURE.GOODSNAMEKANARF"] = detailWorks[index].DPURE_GOODSNAMEKANARF; // �������i���̃J�i
                        row["DPURE.BLGOODSCODERF"] = detailWorks[index].DPURE_BLGOODSCODERF; // ����BL���i�R�[�h
                        row["DPURE.SALESUNPRCTAXINCFLRF"] = detailWorks[index].DPURE_SALESUNPRCTAXINCFLRF; // ��������P���i�ō��C�����j
                        row["DPURE.SALESUNPRCTAXEXCFLRF"] = detailWorks[index].DPURE_SALESUNPRCTAXEXCFLRF; // ��������P���i�Ŕ��C�����j
                        row["DPURE.LISTPRICETAXINCFLRF"] = detailWorks[index].DPURE_LISTPRICETAXINCFLRF; // �����艿�i�ō��C�����j
                        row["DPURE.LISTPRICETAXEXCFLRF"] = detailWorks[index].DPURE_LISTPRICETAXEXCFLRF; // �����艿�i�Ŕ��C�����j
                        row["DPURE.SALESMONEYTAXINCRF"] = detailWorks[index].DPURE_SALESMONEYTAXINCRF; // ����������z�i�ō��݁j
                        row["DPURE.SALESMONEYTAXEXCRF"] = detailWorks[index].DPURE_SALESMONEYTAXEXCRF; // ����������z�i�Ŕ����j
                        row["DPURE.TAXATIONDIVCDRF"] = detailWorks[index].DPURE_TAXATIONDIVCDRF; // �����ېŋ敪
                        //row["DPURE.SALESUNPRCFLRF"] = detailWorks[index].DPURE_SALESUNPRCFLRF; // ��������P��
                        //row["DPURE.LISTPRICERF"] = detailWorks[index].DPURE_LISTPRICERF; // �����艿
                        row["DPURE.SHIPMENTCNTRF"] = detailWorks[index].DPURE_SHIPMENTCNTRF; // �����o�א�
                        //row["DPURE.SALESMONEYRF"] = detailWorks[index].DPURE_SALESMONEYRF; // ����������z
                        row["DPRIM.GOODSMAKERCDRF"] = detailWorks[index].DPRIM_GOODSMAKERCDRF; // �D�Ǐ��i���[�J�[�R�[�h
                        row["DPRIM.MAKERNAMERF"] = detailWorks[index].DPRIM_MAKERNAMERF; // �D�ǃ��[�J�[����
                        row["DPRIM.MAKERKANANAMERF"] = detailWorks[index].DPRIM_MAKERKANANAMERF; // �D�ǃ��[�J�[�J�i����
                        row["DPRIM.GOODSNORF"] = detailWorks[index].DPRIM_GOODSNORF; // �D�Ǐ��i�ԍ�
                        row["DPRIM.GOODSNAMERF"] = detailWorks[index].DPRIM_GOODSNAMERF; // �D�Ǐ��i����
                        row["DPRIM.GOODSNAMEKANARF"] = detailWorks[index].DPRIM_GOODSNAMEKANARF; // �D�Ǐ��i���̃J�i
                        row["DPRIM.BLGOODSCODERF"] = detailWorks[index].DPRIM_BLGOODSCODERF; // �D��BL���i�R�[�h
                        row["DPRIM.SALESUNPRCTAXINCFLRF"] = detailWorks[index].DPRIM_SALESUNPRCTAXINCFLRF; // �D�ǔ���P���i�ō��C�����j
                        row["DPRIM.SALESUNPRCTAXEXCFLRF"] = detailWorks[index].DPRIM_SALESUNPRCTAXEXCFLRF; // �D�ǔ���P���i�Ŕ��C�����j
                        row["DPRIM.LISTPRICETAXINCFLRF"] = detailWorks[index].DPRIM_LISTPRICETAXINCFLRF; // �D�ǒ艿�i�ō��C�����j
                        row["DPRIM.LISTPRICETAXEXCFLRF"] = detailWorks[index].DPRIM_LISTPRICETAXEXCFLRF; // �D�ǒ艿�i�Ŕ��C�����j
                        row["DPRIM.SALESMONEYTAXINCRF"] = detailWorks[index].DPRIM_SALESMONEYTAXINCRF; // �D�ǔ�����z�i�ō��݁j
                        row["DPRIM.SALESMONEYTAXEXCRF"] = detailWorks[index].DPRIM_SALESMONEYTAXEXCRF; // �D�ǔ�����z�i�Ŕ����j
                        row["DPRIM.TAXATIONDIVCDRF"] = detailWorks[index].DPRIM_TAXATIONDIVCDRF; // �D�ǉېŋ敪
                        //row["DPRIM.SALESUNPRCFLRF"] = detailWorks[index].DPRIM_SALESUNPRCFLRF; // �D�ǔ���P��
                        //row["DPRIM.LISTPRICERF"] = detailWorks[index].DPRIM_LISTPRICERF; // �D�ǒ艿
                        row["DPRIM.SHIPMENTCNTRF"] = detailWorks[index].DPRIM_SHIPMENTCNTRF; // �D�Ǐo�א�
                        //row["DPRIM.SALESMONEYRF"] = detailWorks[index].DPRIM_SALESMONEYRF; // �D�ǔ�����z
                        row["DADD.SPECIALNOTERF"] = detailWorks[index].DADD_SPECIALNOTE; // �I�v�V�����E�K�i���
                        # endregion

                        # region [���׍���(�����ȊO)]
                        // ���ݒ莞 ��󎚃R�[�h
                        # region [���ݒ�]
                        if ( IsZero( detailWorks[index].DPURE_GOODSMAKERCDRF ) ) row["DPURE.GOODSMAKERCDRF"] = DBNull.Value; // �������i���[�J�[�R�[�h
                        if ( IsZero( detailWorks[index].DPRIM_GOODSMAKERCDRF ) ) row["DPRIM.GOODSMAKERCDRF"] = DBNull.Value; // �D�Ǐ��i���[�J�[�R�[�h
                        if ( IsZero( detailWorks[index].DPURE_BLGOODSCODERF ) ) row["DPURE.BLGOODSCODERF"] = DBNull.Value; // ����BL���i�R�[�h
                        if ( IsZero( detailWorks[index].DPRIM_BLGOODSCODERF ) ) row["DPRIM.BLGOODSCODERF"] = DBNull.Value; // �D��BL���i�R�[�h
                        # endregion

                        // ����P���E����艿�E������z�̊m��
                        # region [�ō��E�Ŕ�]
                        // �����ō��t���O
                        bool pureTaxIn = false;
                        // �D�ǐō��t���O
                        bool primeTaxIn = false;

                        # region [�󎚑I��]
                        // ����ŋ敪 0:����@1:���Ȃ�
                        if ( estimateDefSet.ConsTaxPrintDiv == 0 )
                        {
                            // 0:���z�\�����Ȃ��i�Ŕ����j,1:���z�\������i�ō��݁j
                            if ( slipWork.SALESSLIPRF_TOTALAMOUNTDISPWAYCDRF == 1 )
                            {
                                //------------------------------------------------------------
                                // ���z�\��������@���@�ېŋ敪�ɂ�炸�A��ɐō��\��
                                //------------------------------------------------------------
                                pureTaxIn = true;
                                primeTaxIn = true;
                            }
                            else
                            {
                                //------------------------------------------------------------
                                // ���z�\�������Ȃ��@���@���ꂼ��̉ېŋ敪�ɏ]��
                                //------------------------------------------------------------
                                // 0:�ې�,1:��ې�,2:�ېŁi���Łj
                                if ( detailWorks[index].DPURE_TAXATIONDIVCDRF == 2 )
                                {
                                    // �ō��݂���
                                    pureTaxIn = true;
                                }
                                // 0:�ې�,1:��ې�,2:�ېŁi���Łj
                                if ( detailWorks[index].DPRIM_TAXATIONDIVCDRF == 2 )
                                {
                                    // �ō�����
                                    primeTaxIn = true;
                                }
                            }
                        }
                        # endregion

                        # region [�󎚍��ڃZ�b�g]
                        // ����
                        if ( pureTaxIn )
                        {
                            // �ō��݂���
                            row["DPURE.SALESUNPRCFLRF"] = detailWorks[index].DPURE_SALESUNPRCTAXINCFLRF; // ��������P��
                            row["DPURE.LISTPRICERF"] = detailWorks[index].DPURE_LISTPRICETAXINCFLRF; // �����艿
                            row["DPURE.SALESMONEYRF"] = detailWorks[index].DPURE_SALESMONEYTAXINCRF; // ����������z
                        }
                        else
                        {
                            // �Ŕ�������
                            row["DPURE.SALESUNPRCFLRF"] = detailWorks[index].DPURE_SALESUNPRCTAXEXCFLRF; // ��������P��
                            row["DPURE.LISTPRICERF"] = detailWorks[index].DPURE_LISTPRICETAXEXCFLRF; // �����艿
                            row["DPURE.SALESMONEYRF"] = detailWorks[index].DPURE_SALESMONEYTAXEXCRF; // ����������z
                        }

                        // �D��
                        if (primeTaxIn)
                        {
                            // �ō��݂���
                            row["DPRIM.SALESUNPRCFLRF"] = detailWorks[index].DPRIM_SALESUNPRCTAXINCFLRF; // �D�ǔ���P��
                            row["DPRIM.LISTPRICERF"] = detailWorks[index].DPRIM_LISTPRICETAXINCFLRF; // �D�ǒ艿
                            row["DPRIM.SALESMONEYRF"] = detailWorks[index].DPRIM_SALESMONEYTAXINCRF; // �D�ǔ�����z
                        }
                        else
                        {
                            // �Ŕ�������
                            row["DPRIM.SALESUNPRCFLRF"] = detailWorks[index].DPRIM_SALESUNPRCTAXEXCFLRF; // �D�ǔ���P��
                            row["DPRIM.LISTPRICERF"] = detailWorks[index].DPRIM_LISTPRICETAXEXCFLRF; // �D�ǒ艿
                            row["DPRIM.SALESMONEYRF"] = detailWorks[index].DPRIM_SALESMONEYTAXEXCRF; // �D�ǔ�����z
                        }
                        # endregion

                        # endregion

                        // �󎚗L���敪�̔��f
                        # region [�󎚗L���敪�̔��f]
                        // �i�Ԉ󎚋敪 
                        if ( estimateDefSet.PartsNoPrtCd == 0 )
                        {
                            // 0:���Ȃ����i�ԋ󔒂ɂ���
                            row["DPURE.GOODSNORF"] = DBNull.Value; // �������i�ԍ�
                            row["DPRIM.GOODSNORF"] = DBNull.Value; // �D�Ǐ��i�ԍ�
                        }
                        // �艿�󎚋敪
                        if ( estimateDefSet.ListPricePrintDiv == 0 )
                        {
                            // 0:���Ȃ����艿�󔒂ɂ���
                            row["DPURE.LISTPRICERF"] = DBNull.Value; // �����艿
                            row["DPRIM.LISTPRICERF"] = DBNull.Value; // �D�ǒ艿
                        }
                        # endregion

                        // �D�Ǐ�񂪖����ꍇ�͔��
                        # region [�D�Ǐ�񂪖����ꍇ�͔��]
                        // �i��=�󔒂��i��=�󔒂Ȃ�A�D�Ǐ��Ȃ��Ɣ��f����
                        if (string.IsNullOrEmpty(detailWorks[index].DPRIM_GOODSNORF) && string.IsNullOrEmpty(detailWorks[index].DPRIM_GOODSNAMERF))
                        {
                            // �D�Ǐ���S�ăN���A
                            row["DPRIM.GOODSMAKERCDRF"] = DBNull.Value; // �D�Ǐ��i���[�J�[�R�[�h
                            row["DPRIM.MAKERNAMERF"] = DBNull.Value; // �D�ǃ��[�J�[����
                            row["DPRIM.MAKERKANANAMERF"] = DBNull.Value; // �D�ǃ��[�J�[�J�i����
                            row["DPRIM.GOODSNORF"] = DBNull.Value; // �D�Ǐ��i�ԍ�
                            row["DPRIM.GOODSNAMERF"] = DBNull.Value; // �D�Ǐ��i����
                            row["DPRIM.GOODSNAMEKANARF"] = DBNull.Value; // �D�Ǐ��i���̃J�i
                            row["DPRIM.BLGOODSCODERF"] = DBNull.Value; // �D��BL���i�R�[�h
                            row["DPRIM.SALESUNPRCTAXINCFLRF"] = DBNull.Value; // �D�ǔ���P���i�ō��C�����j
                            row["DPRIM.SALESUNPRCTAXEXCFLRF"] = DBNull.Value; // �D�ǔ���P���i�Ŕ��C�����j
                            row["DPRIM.LISTPRICETAXINCFLRF"] = DBNull.Value; // �D�ǒ艿�i�ō��C�����j
                            row["DPRIM.LISTPRICETAXEXCFLRF"] = DBNull.Value; // �D�ǒ艿�i�Ŕ��C�����j
                            row["DPRIM.SALESMONEYTAXINCRF"] = DBNull.Value; // �D�ǔ�����z�i�ō��݁j
                            row["DPRIM.SALESMONEYTAXEXCRF"] = DBNull.Value; // �D�ǔ�����z�i�Ŕ����j
                            row["DPRIM.TAXATIONDIVCDRF"] = DBNull.Value; // �D�ǉېŋ敪
                            row["DPRIM.SALESUNPRCFLRF"] = DBNull.Value; // �D�ǔ���P��
                            row["DPRIM.LISTPRICERF"] = DBNull.Value; // �D�ǒ艿
                            row["DPRIM.SHIPMENTCNTRF"] = DBNull.Value; // �D�Ǐo�א�
                            row["DPRIM.SALESMONEYRF"] = DBNull.Value; // �D�ǔ�����z
                        }
                        # endregion

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
                    row[ct_InPageCopyCount] = inPageCopyCount;    // ����y�[�W���R�s�[�J�E���g
                    # endregion

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/01/16 ADD
                    // �^�C�g���ʈ󎚐���Ή�
                    ReflectColumnVisibleType( ref row, columnVisibleTypeDic, inPageCopyCount );
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/01/16 ADD

                    table.Rows.Add( row );
                }
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
            # region // DEL
            //// ���Ж��̂̍ő咷(byte)
            //const int fullByteCount = 40;
            //// ������̒���(byte)
            //const int halfByteCount = 20;

            //// �X�y�[�X�ŋl�߂�
            //originName = originName.PadRight( fullByteCount, ' ' );
            //// �O�����擾
            //firstHalf = SubStringOfByte( originName, halfByteCount );
            //// �㔼���擾
            //lastHalf = originName.Substring( firstHalf.Length, originName.Length - firstHalf.Length );

            //// ���X�y�[�X�J�b�g
            //firstHalf = firstHalf.TrimEnd();
            //lastHalf = lastHalf.TrimEnd();
            # endregion

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
        /// ���׍s��
        /// </summary>
        /// <param name="frePrtPSetWork"></param>
        /// <param name="slipWork"></param>
        /// <param name="estimateDefSet"></param>
        /// <returns></returns>
        private static int GetFeedCount( FrePrtPSetWork frePrtPSetWork, FrePEstFmHead slipWork, EstimateDefSet estimateDefSet )
        {
//# if DEBUG
//            slipWork.HADD_ESTFMDIVRF = EstFmDivState.All;
//            estimateDefSet.OptionPringDivCd = 1;
//            // ���������@ReflectDetailDesign
//# endif


            // ��{�̒l�͎��R���[����ݒ肩��擾����
            int feedCount = frePrtPSetWork.FormFeedLineCount;
            if ( feedCount <= 0 ) feedCount = 1;

            // �����Ϗ��̓���d�l�Ƃ��āA�P���ׂ̍����������ɂ��ϓ�����̂ŁA
            // �@���C�A�E�g���ɂ���ăf�[�^�e�[�u����̖��א����Z�o����B

            int countInRow = 1;
            # region [countInRow�̎Z�o]
            using ( MemoryStream stream = new MemoryStream( frePrtPSetWork.PrintPosClassData ) )
            {
                // ���C�A�E�g���̓W�J
                ar.ActiveReport3 prtRpt = new ar.ActiveReport3();
                stream.Position = 0;
                prtRpt.LoadLayout( stream );

                try
                {
                    ar.Section detail = prtRpt.Sections["Detail1"];
                    // ���׃f�U�C���p���x��
                    ar.Label designDetail2 = null;
                    ar.Label designDetail3 = null;

                    // ���׃Z�N�V�����̃R���g���[���𒲍�
                    foreach ( ar.ARControl control in detail.Controls )
                    {
                        string tagText = (string)control.Tag;
                        tagText = tagText.Substring( 0, 3 );

                        switch ( tagText )
                        {
                            case "69,":
                                designDetail2 = (ar.Label)control;
                                break;
                            case "70,":
                                designDetail3 = (ar.Label)control;
                                break;
                            default:
                                break;
                        }
                    }

                    //// �P���ׂ̍s�����J�E���g����
                    //countInRow = 1;
                    //if ( designDetail2 != null ) countInRow++;
                    //if ( designDetail3 != null ) countInRow++;


                    if ( estimateDefSet.OptionPringDivCd > 0 )
                    {
                        // �I�v�V����������P�F����
                        if ( slipWork.HADD_ESTFMDIVRF == EstFmDivState.All )
                        {
                            //--------------------------------------------------------
                            // �����{�D�ǁ{�I�v�V����
                            //--------------------------------------------------------
                            countInRow = 1;
                            if ( designDetail2 != null ) countInRow++;
                            if ( designDetail3 != null ) countInRow++;
                        }
                        else
                        {
                            //--------------------------------------------------------
                            // ����or�D�ǁ{�I�v�V����
                            //--------------------------------------------------------
                            countInRow = 1;
                            if ( designDetail3 != null ) countInRow++;
                        }
                    }
                    else
                    {
                        // �I�v�V����������O�F���Ȃ�
                        if ( slipWork.HADD_ESTFMDIVRF == EstFmDivState.All )
                        {
                            //--------------------------------------------------------
                            // �����{�D��
                            //--------------------------------------------------------
                            countInRow = 1;
                            if ( designDetail2 != null ) countInRow++;
                        }
                        else
                        {
                            //--------------------------------------------------------
                            // ����or�D��
                            //--------------------------------------------------------
                            countInRow = 1;
                        }
                    }

                }
                catch
                {
                }
            }
            # endregion

            // �P���ו��̍s���Ŋ����āA�؂�̂Ă�
            return (feedCount / countInRow);
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
        ///// <summary>
        ///// �ړ����z
        ///// </summary>
        ///// <param name="frePEstFmDetailWork"></param>
        ///// <returns></returns>
        //private static Int64 GetSTOCKMOVEPRICERF( FrePEstFmDetail frePEstFmDetailWork )
        //{
        //    decimal unitPrice = (decimal)frePEstFmDetailWork.MOVD_STOCKUNITPRICEFLRF; // �d���P���i�Ŕ�,�����j
        //    decimal moveCount = (decimal)frePEstFmDetailWork.MOVD_MOVECOUNTRF; // �ړ���
        //    return (Int64)Round( unitPrice * moveCount );
        //}
        ///// <summary>
        ///// �ړ����z�i�W�����i�j
        ///// </summary>
        ///// <param name="frePEstFmDetailWork"></param>
        ///// <returns></returns>
        //private static Int64 GetSTOCKMOVELISTPRICERF( FrePEstFmDetail frePEstFmDetailWork )
        //{
        //    decimal unitPrice = (decimal)frePEstFmDetailWork.MOVD_LISTPRICEFLRF; // �艿�i�����j
        //    decimal moveCount = (decimal)frePEstFmDetailWork.MOVD_MOVECOUNTRF; // �ړ���
        //    return (Int64)Round( unitPrice * moveCount );
        //}
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

            // �a��t���O
            bool jpEra = (eraNameDispCd == 1);
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

        # region [���׍��ڕ���]
        /// <summary>
        /// ���ׂP����
        /// </summary>
        /// <returns></returns>
        public static List<string> GetDesignDetail1List()
        {
            List<string> list = new List<string>();
            list.Add( "SALESDETAILRF.SALESSLIPNUMRF" );
            list.Add( "SALESDETAILRF.SALESROWNORF" );
            list.Add( "DPURE.GOODSMAKERCDRF" );
            list.Add( "DPURE.MAKERNAMERF" );
            list.Add( "DPURE.MAKERKANANAMERF" );
            list.Add( "DPURE.GOODSNORF" );
            list.Add( "DPURE.GOODSNAMERF" );
            list.Add( "DPURE.GOODSNAMEKANARF" );
            list.Add( "DPURE.BLGOODSCODERF" );
            list.Add( "DPURE.SALESUNPRCTAXINCFLRF" );
            list.Add( "DPURE.SALESUNPRCTAXEXCFLRF" );
            list.Add( "DPURE.LISTPRICETAXINCFLRF" );
            list.Add( "DPURE.LISTPRICETAXEXCFLRF" );
            list.Add( "DPURE.SALESMONEYTAXINCRF" );
            list.Add( "DPURE.SALESMONEYTAXEXCRF" );
            list.Add( "DPURE.TAXATIONDIVCDRF" );
            list.Add( "DPURE.SALESUNPRCFLRF" );
            list.Add( "DPURE.LISTPRICERF" );
            list.Add( "DPURE.SHIPMENTCNTRF" );
            list.Add( "DPURE.SALESMONEYRF" );
            return list;
        }
        /// <summary>
        /// ���ׂQ����
        /// </summary>
        /// <returns></returns>
        public static List<string> GetDesignDetail2List()
        {
            List<string> list = new List<string>();
            list.Add( "DPRIM.GOODSMAKERCDRF" );
            list.Add( "DPRIM.MAKERNAMERF" );
            list.Add( "DPRIM.MAKERKANANAMERF" );
            list.Add( "DPRIM.GOODSNORF" );
            list.Add( "DPRIM.GOODSNAMERF" );
            list.Add( "DPRIM.GOODSNAMEKANARF" );
            list.Add( "DPRIM.BLGOODSCODERF" );
            list.Add( "DPRIM.SALESUNPRCTAXINCFLRF" );
            list.Add( "DPRIM.SALESUNPRCTAXEXCFLRF" );
            list.Add( "DPRIM.LISTPRICETAXINCFLRF" );
            list.Add( "DPRIM.LISTPRICETAXEXCFLRF" );
            list.Add( "DPRIM.SALESMONEYTAXINCRF" );
            list.Add( "DPRIM.SALESMONEYTAXEXCRF" );
            list.Add( "DPRIM.TAXATIONDIVCDRF" );
            list.Add( "DPRIM.SALESUNPRCFLRF" );
            list.Add( "DPRIM.LISTPRICERF" );
            list.Add( "DPRIM.SHIPMENTCNTRF" );
            list.Add( "DPRIM.SALESMONEYRF" );
            return list;
        }
        /// <summary>
        /// ���ׂR����
        /// </summary>
        /// <returns></returns>
        public static List<string> GetDesignDetail3List()
        {
            List<string> list = new List<string>();
            list.Add( "DADD.SPECIALNOTERF" );
            return list;
        }
        # endregion

        # region [�s����̏��擾]
        /// <summary>
        /// ���Ϗ��敪�擾
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public static EstFmDivState GetRowInfoEstFmDiv( DataRow row )
        {
            return (EstFmDivState)row["HADD.ESTFMDIVRF"];
        }
        /// <summary>
        /// �ېŋ敪�擾
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public static int GetRowInfoConsTaxLayMethod( DataRow row )
        {
            return (int)row["SALESSLIPRF.CONSTAXLAYMETHODRF"];
        }
        /// <summary>
        /// �`�[�ԍ��擾
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public static string GetRowInfoSalesSlipNum( DataRow row )
        {
            return (string)row["SALESSLIPRF.SALESSLIPNUMRF"];
        }
        # endregion

        # region [���v���ڕ���]
        /// <summary>
        /// ���v
        /// </summary>
        /// <returns></returns>
        public static List<string> GetDesignSubTotalList()
        {
            List<string> list = new List<string>();
            list.Add( "HPURE.SALESTOTALTAXEXCRF" ); // ��������`�[���v�i�Ŕ����j
            list.Add( "HPURE.SALESSUBTOTALTAXEXCRF" ); // �������㏬�v�i�Ŕ����j
            list.Add( "HPRIME.SALESTOTALTAXEXCRF" ); // �D�ǔ���`�[���v�i�Ŕ����j
            list.Add( "HPRIME.SALESSUBTOTALTAXEXCRF" ); // �D�ǔ��㏬�v�i�Ŕ����j
            return list;
        }
        /// <summary>
        /// ��
        /// </summary>
        /// <returns></returns>
        public static List<string> GetDesignTaxList()
        {
            List<string> list = new List<string>();
            list.Add( "HPURE.SALESSUBTOTALTAXRF" ); // �������㏬�v�i�Łj
            list.Add( "HPRIME.SALESSUBTOTALTAXRF" ); // �D�ǔ��㏬�v�i�Łj
            return list;
        }
        /// <summary>
        /// ���v
        /// </summary>
        /// <returns></returns>
        public static List<string> GetDesignTotalList()
        {
            List<string> list = new List<string>();
            list.Add( "HPURE.SALESTOTALTAXINCRF" ); // ��������`�[���v�i�ō��݁j
            list.Add( "HPURE.SALESSUBTOTALTAXINCRF" ); // �������㏬�v�i�ō��݁j
            list.Add( "HPRIME.SALESTOTALTAXINCRF" ); // �D�ǔ���`�[���v�i�ō��݁j
            list.Add( "HPRIME.SALESSUBTOTALTAXINCRF" ); // �D�ǔ��㏬�v�i�ō��݁j
            return list;
        }
        /// <summary>
        /// �D�ǌv
        /// </summary>
        /// <returns></returns>
        public static List<string> GetDesignTotalPrimeList()
        {
            List<string> list = new List<string>();
            list.Add( "HPRIME.SALESTOTALTAXINCRF" ); // �D�ǔ���`�[���v�i�ō��݁j
            list.Add( "HPRIME.SALESTOTALTAXEXCRF" ); // �D�ǔ���`�[���v�i�Ŕ����j
            list.Add( "HPRIME.SALESSUBTOTALTAXINCRF" ); // �D�ǔ��㏬�v�i�ō��݁j
            list.Add( "HPRIME.SALESSUBTOTALTAXEXCRF" ); // �D�ǔ��㏬�v�i�Ŕ����j
            list.Add( "HPRIME.SALESSUBTOTALTAXRF" ); // �D�ǔ��㏬�v�i�Łj
            return list;
        }
        # endregion

        # region [�c�{�p�Ή����X�g]
        /// <summary>
        /// �c�{�p�Ή����X�g�擾����
        /// </summary>
        /// <returns></returns>
        public static List<string> GetDoubleHeightTargetList()
        {
            List<string> list = new List<string>();

            list.Add( "HLG.PRINTCUSTOMERNAMEJOIN12RF" );  // �i�c�{�j���Ӑ於�P�{���Ӑ於�Q
            list.Add( "HLG.PRINTCUSTOMERNAMEJOIN12HNRF" );  // �i�c�{�j���Ӑ於�P�{���Ӑ於�Q�{�h��
            list.Add( "HLG.CUSTOMERNAMERF" );  // �i�c�{�j���Ӑ於��
            list.Add( "HLG.CUSTOMERNAME2RF" );  // �i�c�{�j���Ӑ於��2
            list.Add( "HLG.CUSTOMERSNMRF" );  // �i�c�{�j���Ӑ旪��
            list.Add( "HLG.HONORIFICTITLERF" );  // �i�c�{�j���Ӑ�h��
            list.Add( "HLG.PRINTCUSTOMERNM1RF" );  // �i�c�{�j����p���Ӑ於��(��i)
            list.Add( "HLG.PRINTCUSTOMERNM2RF" );  // �i�c�{�j����p���Ӑ於��(���i)

            return list;
        }
        # endregion
    }
}

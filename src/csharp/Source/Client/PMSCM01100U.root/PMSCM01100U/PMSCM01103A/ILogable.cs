//****************************************************************************//
// �V�X�e��         : �񓚑��M����
// �v���O��������   : �񓚑��M�����A�N�Z�X
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2009/07/21  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 21112 �v�ۓc ��
// �� �� ��  2011/06/01  �C�����e : �e�[�u�����C�A�E�g�ύX�ɔ������ڂ̒ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30744 ���� ����q
// �� �� ��  2012/12/27  �C�����e : 2013/03/13�z�M SCM��Q��10378�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11470007-00 �쐬�S�� : ����
// �C �� ��  2018/04/16  �C�����e : SF����̖⍇���E�����̃f�[�^�ɐVBL�R�[�h�A�VBL�T�u�R�[�h���ڒǉ�
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.UIData;
using Broadleaf.Application.UIData.WebDB;

namespace Broadleaf.Application.Controller
{
    using WebHeaderRecordType   = Broadleaf.Application.UIData.ScmOdrData;
    using WebCarRecordType      = Broadleaf.Application.UIData.ScmOdDtCar;
    using WebDetailRecordType   = Broadleaf.Application.UIData.ScmOdDtInq;
    using WebAnswerRecordType   = Broadleaf.Application.UIData.ScmOdDtAns;

    /// <summary>
    /// ���O�C���^�[�t�F�[�X
    /// </summary>
    public interface ILogable
    {
        /// <summary>
        /// ���O�������݂܂��B
        /// </summary>
        /// <param name="msg">���b�Z�[�W</param>
        void WriteLog(string msg);
    }

    /// <summary>
    /// ���b�Z�[�W���[�e�B���e�B
    /// </summary>
    public static class MsgUtil
    {
        #region <CSV�ϊ�>

        /// <summary>�J���}</summary>
        public const string COMMA = ",";

        /// <summary>
        /// CSV�ɕϊ����܂��B
        /// </summary>
        /// <param name="scmHeaderRecordList">SCM�󔭒��f�[�^�̃��R�[�h���X�g</param>
        /// <returns>CSV</returns>
        public static string ConvertCSV(IList<WebHeaderRecordType> scmHeaderRecordList)
        {
            IList<ISCMOrderHeaderRecord> webHeaderRecordList = new List<ISCMOrderHeaderRecord>();
            {
                foreach (WebHeaderRecordType webRecord in scmHeaderRecordList)
                {
                    webHeaderRecordList.Add(new WebSCMOrderHeaderRecord(webRecord));
                }
            }

            StringBuilder csv = new StringBuilder();
            {
                #region <�^�C�g���s>

                if (webHeaderRecordList != null && webHeaderRecordList.Count > 0)
                {
                    if (webHeaderRecordList[0] is UserSCMOrderHeaderRecord)
                    {
                        #region <User���R�[�h>

                        csv.Append("01.�쐬����").Append(COMMA);
                        csv.Append("02.�X�V����").Append(COMMA);
                        csv.Append("03.��ƃR�[�h").Append(COMMA);
                        csv.Append("04.GUID").Append(COMMA);
                        csv.Append("05.�X�V�]�ƈ��R�[�h").Append(COMMA);
                        csv.Append("06.�X�V�A�Z���u��1").Append(COMMA);
                        csv.Append("07.�X�V�A�Z���u��2").Append(COMMA);
                        csv.Append("08.�_���폜�敪").Append(COMMA);
                        csv.Append("09.�⍇������ƃR�[�h").Append(COMMA);
                        csv.Append("10.�⍇�������_�R�[�h").Append(COMMA);
                        csv.Append("11.�⍇�����ƃR�[�h").Append(COMMA);
                        csv.Append("12.�⍇���拒�_�R�[�h").Append(COMMA);
                        csv.Append("13.�⍇���ԍ�").Append(COMMA);
                        csv.Append("14.���Ӑ�R�[�h").Append(COMMA);
                        csv.Append("15.�X�V�N����").Append(COMMA);
                        csv.Append("16.�X�V�����b�~���b").Append(COMMA);
                        csv.Append("17.�񓚋敪").Append(COMMA);
                        csv.Append("18.�m���").Append(COMMA);
                        csv.Append("19.�⍇���E�������l").Append(COMMA);
                        csv.Append("20.�Y�t�t�@�C��").Append(COMMA);
                        csv.Append("21.�Y�t�t�@�C����").Append(COMMA);
                        csv.Append("22.�⍇���]�ƈ��R�[�h").Append(COMMA);
                        csv.Append("23.�⍇���]�ƈ�����").Append(COMMA);
                        csv.Append("24.�񓚏]�ƈ��R�[�h").Append(COMMA);
                        csv.Append("25.�񓚏]�ƈ�����").Append(COMMA);
                        csv.Append("26.�⍇����").Append(COMMA);
                        csv.Append("27.�󒍃X�e�[�^�X").Append(COMMA);
                        csv.Append("28.����`�[�ԍ�").Append(COMMA);
                        csv.Append("29.����`�[���v(�ō���)").Append(COMMA);
                        csv.Append("30.���㏬�v(��)").Append(COMMA);
                        csv.Append("31.�⍇���E�������").Append(COMMA);
                        csv.Append("32.�┭�E�񓚎��").Append(COMMA);
                        csv.Append("33.��M����").Append(COMMA);
                        //csv.Append("34.�񓚍쐬�敪").Append(Environment.NewLine);  //DEL 2011/06/01
                        //--- ADD 2011/06/01 ------------------------------------>>>
                        csv.Append("34.�񓚍쐬�敪").Append(COMMA);
                        csv.Append("35.�L�����Z���敪").Append(COMMA);
                        csv.Append("36.CMT�A�g�敪").Append(COMMA);
                        csv.Append("37.SF-PM�A�g�w�����ԍ�").Append(Environment.NewLine);
                        //--- ADD 2011/06/01 ------------------------------------<<<
                        #endregion // </User���R�[�h>
                    }
                    else
                    {
                        #region <Web���R�[�h>

                        csv.Append("01.�쐬����").Append(COMMA);
                        csv.Append("02.�X�V����").Append(COMMA);
                        csv.Append("03.�_���폜�敪").Append(COMMA);
                        csv.Append("04.�⍇������ƃR�[�h").Append(COMMA);
                        csv.Append("05.�⍇�������_�R�[�h").Append(COMMA);
                        csv.Append("06.�⍇�����ƃR�[�h").Append(COMMA);
                        csv.Append("07.�⍇���拒�_�R�[�h").Append(COMMA);
                        csv.Append("08.�⍇���ԍ�").Append(COMMA);
                        csv.Append("09.�X�V�N����").Append(COMMA);
                        csv.Append("10.�X�V�����b�~���b").Append(COMMA);
                        csv.Append("11.�񓚋敪").Append(COMMA);
                        csv.Append("12.�m���").Append(COMMA);
                        csv.Append("13.�⍇���E�������l").Append(COMMA);
                        csv.Append("14.�⍇���]�ƈ��R�[�h").Append(COMMA);
                        csv.Append("15.�⍇���]�ƈ�����").Append(COMMA);
                        csv.Append("16.�񓚏]�ƈ��R�[�h").Append(COMMA);
                        csv.Append("17.�񓚏]�ƈ�����").Append(COMMA);
                        csv.Append("18.�⍇����").Append(COMMA);
                        csv.Append("19.�⍇���E�������").Append(COMMA);
                        csv.Append("20.�┭�E�񓚎��").Append(COMMA);
                        csv.Append("21.��M����").Append(COMMA);
                        //csv.Append("22.�ŐV���ʋ敪").Append(Environment.NewLine);  //DEL 2011/06/01
                        //--- ADD 2011/06/01 ------------------------------------>>>
                        csv.Append("22.�ŐV���ʋ敪").Append(COMMA);
                        csv.Append("23.�L�����Z���敪").Append(COMMA);
                        csv.Append("24.CMT�A�g�敪").Append(COMMA);
                        csv.Append("25.SF-PM�A�g�w�����ԍ�").Append(Environment.NewLine);
                        //--- ADD 2011/06/01 ------------------------------------<<<
                        #endregion // </Web���R�[�h>
                    }
                }

                #endregion // </�^�C�g���s>

                foreach (ISCMOrderHeaderRecord scmHeaderRecord in webHeaderRecordList)
                {
                    csv.Append(scmHeaderRecord.ToCSV()).Append(Environment.NewLine);
                }
            }
            return csv.ToString();
        }

        /// <summary>
        /// CSV�ɕϊ����܂��B
        /// </summary>
        /// <param name="scmCarRecord">SCM�󔭒��f�[�^(�ԗ����)�̃��R�[�h</param>
        /// <returns>CSV</returns>
        public static string ConvertCSV(WebCarRecordType scmCarRecord)
        {
            if (scmCarRecord == null) return "null" + Environment.NewLine;

            IList<WebCarRecordType> scmCarRecordList = new List<WebCarRecordType>();
            {
                scmCarRecordList.Add(scmCarRecord);
            }
            return ConvertCSV(scmCarRecordList);
        }

        /// <summary>
        /// CSV�ɕϊ����܂��B
        /// </summary>
        /// <param name="scmCarRecordList">SCM�󔭒��f�[�^(�ԗ����)�̃��R�[�h���X�g</param>
        /// <returns>CSV</returns>
        public static string ConvertCSV(IList<WebCarRecordType> scmCarRecordList)
        {
            IList<ISCMOrderCarRecord> webCarRecordList = new List<ISCMOrderCarRecord>();
            {
                foreach (WebCarRecordType webRecord in scmCarRecordList)
                {
                    webCarRecordList.Add(new WebSCMOrderCarRecord(webRecord));
                }
            }

            StringBuilder csv = new StringBuilder();
            {
                #region <�^�C�g���s>

                if (webCarRecordList != null && webCarRecordList.Count > 0)
                {
                    if (webCarRecordList[0] is UserSCMOrderCarRecord)
                    {
                        #region <User���R�[�h>

                        csv.Append("01.�쐬����").Append(COMMA);
                        csv.Append("02.�X�V����").Append(COMMA);
                        csv.Append("03.��ƃR�[�h").Append(COMMA);
                        csv.Append("04.GUID").Append(COMMA);
                        csv.Append("05.�X�V�]�ƈ��R�[�h").Append(COMMA);
                        csv.Append("06.�X�V�A�Z���u��1").Append(COMMA);
                        csv.Append("07.�X�V�A�Z���u��2").Append(COMMA);
                        csv.Append("08.�_���폜�敪").Append(COMMA);
                        csv.Append("09.�⍇������ƃR�[�h").Append(COMMA);
                        csv.Append("10.�⍇�������_�R�[�h").Append(COMMA);
                        csv.Append("11.�⍇���ԍ�").Append(COMMA);
                        csv.Append("12.���^�������ԍ�").Append(COMMA);
                        csv.Append("13.���^�����ǖ���").Append(COMMA);
                        csv.Append("14.�ԗ��o�^�ԍ�(���)").Append(COMMA);
                        csv.Append("15.�ԗ��o�^�ԍ�(�J�i)").Append(COMMA);
                        csv.Append("16.�ԗ��o�^�ԍ�(�v���[�g�ԍ�)").Append(COMMA);
                        csv.Append("17.�^���w��ԍ�").Append(COMMA);
                        csv.Append("18.�ޕʔԍ�").Append(COMMA);
                        csv.Append("19.���[�J�[�R�[�h").Append(COMMA);
                        csv.Append("20.�Ԏ�R�[�h").Append(COMMA);
                        csv.Append("21.�Ԏ�T�u�R�[�h").Append(COMMA);
                        csv.Append("22.�Ԏ햼").Append(COMMA);
                        csv.Append("23.�Ԍ��،^��").Append(COMMA);
                        csv.Append("24.�^��(�t���^)").Append(COMMA);
                        csv.Append("25.�ԑ�ԍ�").Append(COMMA);
                        csv.Append("26.�ԑ�^��").Append(COMMA);
                        csv.Append("27.�V���V�[No").Append(COMMA);
                        csv.Append("28.�ԗ��ŗL�ԍ�").Append(COMMA);
                        csv.Append("29.���Y�N��(NUM�^�C�v)").Append(COMMA);
                        csv.Append("30.�R�����g").Append(COMMA);
                        csv.Append("31.���y�A�J���[�R�[�h").Append(COMMA);
                        csv.Append("32.�J���[����1").Append(COMMA);
                        csv.Append("33.�g�����R�[�h").Append(COMMA);
                        csv.Append("34.�g��������").Append(COMMA);
                        csv.Append("35.�ԗ����s����").Append(COMMA);
                        csv.Append("36.�����I�u�W�F�N�g").Append(COMMA);
                        csv.Append("37.�󒍃X�e�[�^�X").Append(COMMA);
                        csv.Append("38.����`�[�ԍ�").Append(Environment.NewLine);

                        #endregion // </User���R�[�h>
                    }
                    else
                    {
                        #region <Web���R�[�h>

                        csv.Append("01.�쐬����").Append(COMMA);
                        csv.Append("02.�X�V����").Append(COMMA);
                        csv.Append("03.�_���폜�敪").Append(COMMA);
                        csv.Append("04.�⍇������ƃR�[�h").Append(COMMA);
                        csv.Append("05.�⍇�������_�R�[�h").Append(COMMA);
                        csv.Append("06.�⍇���ԍ�").Append(COMMA);
                        csv.Append("07.���^�������ԍ�").Append(COMMA);
                        csv.Append("08.���^�����ǖ���").Append(COMMA);
                        csv.Append("09.�ԗ��o�^�ԍ�(���)").Append(COMMA);
                        csv.Append("10.�ԗ��o�^�ԍ�(�J�i)").Append(COMMA);
                        csv.Append("11.�ԗ��o�^�ԍ�(�v���[�g�ԍ�)").Append(COMMA);
                        csv.Append("12.�^���w��ԍ�").Append(COMMA);
                        csv.Append("13.�ޕʔԍ�").Append(COMMA);
                        csv.Append("14.���[�J�[�R�[�h").Append(COMMA);
                        csv.Append("15.�Ԏ�R�[�h").Append(COMMA);
                        csv.Append("16.�Ԏ�T�u�R�[�h").Append(COMMA);
                        csv.Append("17.�Ԏ햼").Append(COMMA);
                        csv.Append("18.�Ԍ��،^��").Append(COMMA);
                        csv.Append("19.�^��(�t���^)").Append(COMMA);
                        csv.Append("20.�ԑ�ԍ�").Append(COMMA);
                        csv.Append("21.�ԑ�^��").Append(COMMA);
                        csv.Append("22.�V���V�[No").Append(COMMA);
                        csv.Append("23.�ԗ��ŗL�ԍ�").Append(COMMA);
                        csv.Append("24.���Y�N��(NUM�^�C�v)").Append(COMMA);
                        csv.Append("25.�R�����g").Append(COMMA);
                        csv.Append("26.���y�A�J���[�R�[�h").Append(COMMA);
                        csv.Append("27.�J���[����1").Append(COMMA);
                        csv.Append("28.�g�����R�[�h").Append(COMMA);
                        csv.Append("29.�g��������").Append(COMMA);
                        csv.Append("30.�ԗ����s����").Append(COMMA);
                        csv.Append("31.�����I�u�W�F�N�g").Append(Environment.NewLine);

                        #endregion // </Web���R�[�h>
                    }
                }

                #endregion // </�^�C�g���s>

                foreach (ISCMOrderCarRecord scmCarRecord in webCarRecordList)
                {
                    csv.Append(scmCarRecord.ToCSV()).Append(Environment.NewLine);
                }
            }
            return csv.ToString();
        }

        /// <summary>
        /// CSV�ɕϊ����܂��B
        /// </summary>
        /// <param name="scmAnswerRecordList">SCM�󔭒����׃f�[�^(��)�̃��R�[�h���X�g</param>
        /// <returns>CSV</returns>
        /// <remarks>
        /// <br>Update Note      :   2018/04/16 ����</br>
        /// <br>�Ǘ��ԍ�         :   11470007-00</br>
        /// <br>                 :   SF����̖⍇���E�����̃f�[�^�ɐVBL�R�[�h�A�VBL�T�u�R�[�h���ڒǉ�</br>
        /// </remarks>
        public static string ConvertCSV(IList<WebAnswerRecordType> scmAnswerRecordList)
        {
            IList<ISCMOrderAnswerRecord> webAnswerRecordList = new List<ISCMOrderAnswerRecord>();
            {
                foreach (WebAnswerRecordType webRecord in scmAnswerRecordList)
                {
                    webAnswerRecordList.Add(new WebSCMOrderAnswerRecord(webRecord));
                }
            }

            StringBuilder csv = new StringBuilder();
            {
                #region <�^�C�g���s>

                if (webAnswerRecordList != null && webAnswerRecordList.Count > 0)
                {
                    if (webAnswerRecordList[0] is UserSCMOrderAnswerRecord)
                    {
                        #region <User���R�[�h>

                        csv.Append("01.�쐬����").Append(COMMA);
                        csv.Append("02.�X�V����").Append(COMMA);
                        csv.Append("03.��ƃR�[�h").Append(COMMA);
                        csv.Append("04.GUID").Append(COMMA);
                        csv.Append("05.�X�V�]�ƈ��R�[�h").Append(COMMA);
                        csv.Append("06.�X�V�A�Z���u��1").Append(COMMA);
                        csv.Append("07.�X�V�A�Z���u��2").Append(COMMA);
                        csv.Append("08.�_���폜�敪").Append(COMMA);
                        csv.Append("09.�⍇������ƃR�[�h").Append(COMMA);
                        csv.Append("10.�⍇�������_�R�[�h").Append(COMMA);
                        csv.Append("11.�⍇�����ƃR�[�h").Append(COMMA);
                        csv.Append("12.�⍇���拒�_�R�[�h").Append(COMMA);
                        csv.Append("13.�⍇���ԍ�").Append(COMMA);
                        csv.Append("14.�X�V�N����").Append(COMMA);
                        csv.Append("15.�X�V�����b�~���b").Append(COMMA);
                        csv.Append("16.�⍇���s�ԍ�").Append(COMMA);
                        csv.Append("17.�⍇���s�ԍ��}��").Append(COMMA);
                        csv.Append("18.�⍇�������׎���GUID").Append(COMMA);
                        csv.Append("19.�⍇���於�掯��GUID").Append(COMMA);
                        csv.Append("20.���i���").Append(COMMA);
                        csv.Append("21.���T�C�N�����i���").Append(COMMA);
                        csv.Append("22.���T�C�N�����i����").Append(COMMA);
                        csv.Append("23.�[�i�敪").Append(COMMA);
                        csv.Append("24.�戵�敪").Append(COMMA);
                        csv.Append("25.���i�`��").Append(COMMA);
                        csv.Append("26.�[�i�m�F�敪").Append(COMMA);
                        csv.Append("27.�[�i�����\���").Append(COMMA);
                        csv.Append("28.�񓚔[��").Append(COMMA);
                        csv.Append("29.BL���i�R�[�h").Append(COMMA);
                        csv.Append("30.BL���i�R�[�h�}��").Append(COMMA);
                        csv.Append("31.�┭���i��").Append(COMMA);
                        csv.Append("32.�񓚏��i��").Append(COMMA);
                        csv.Append("33.������").Append(COMMA);
                        csv.Append("34.�[�i��").Append(COMMA);
                        csv.Append("35.���i�ԍ�").Append(COMMA);
                        csv.Append("36.���i���[�J�[�R�[�h").Append(COMMA);
                        csv.Append("37.���i���[�J�[����").Append(COMMA);
                        csv.Append("38.�������i���[�J�[�R�[�h").Append(COMMA);
                        csv.Append("39.�┭�������i�ԍ�").Append(COMMA);
                        csv.Append("40.�񓚏������i�ԍ�").Append(COMMA);
                        csv.Append("41.�艿").Append(COMMA);
                        csv.Append("42.�P��").Append(COMMA);
                        csv.Append("43.���i�⑫���").Append(COMMA);
                        csv.Append("44.�e���z").Append(COMMA);
                        csv.Append("45.�e����").Append(COMMA);
                        csv.Append("46.�񓚊���").Append(COMMA);
                        csv.Append("47.���l(����)").Append(COMMA);
                        csv.Append("48.�Y�t�t�@�C��(����)").Append(COMMA);
                        csv.Append("49.�Y�t�t�@�C����(����)").Append(COMMA);
                        csv.Append("50.�I��").Append(COMMA);
                        csv.Append("51.�ǉ��敪").Append(COMMA);
                        csv.Append("52.�����敪").Append(COMMA);
                        csv.Append("53.�󒍃X�e�[�^�X").Append(COMMA);
                        csv.Append("54.����`�[�ԍ�").Append(COMMA);
                        csv.Append("55.����`�[�s�ԍ�").Append(COMMA);
                        csv.Append("56.�L�����y�[���R�[�h").Append(COMMA);
                        csv.Append("57.�݌ɋ敪").Append(COMMA);
                        csv.Append("58.�⍇���E�������").Append(COMMA);
                        csv.Append("59.�\������").Append(COMMA);
                        //csv.Append("60.���i�Ǘ��ԍ�").Append(Environment.NewLine);  //DEL 2011/06/01
                        //--- ADD 2011/06/01 ------------------------------------>>>
                        csv.Append("60.���i�Ǘ��ԍ�").Append(COMMA);  //DEL 2011/06/01
                        csv.Append("61.�L�����Z����ԋ敪").Append(COMMA);
                        csv.Append("62.PM�󒍃X�e�[�^�X").Append(COMMA);
                        csv.Append("63.PM����`�[�ԍ�").Append(COMMA);
                        csv.Append("64.PM����s�ԍ�").Append(COMMA);
                        csv.Append("65.���׎捞�敪").Append(COMMA);
                        csv.Append("66.PM�q�ɃR�[�h").Append(COMMA);
                        csv.Append("67.PM�q�ɖ���").Append(COMMA);
                        csv.Append("68.PM�I��").Append(Environment.NewLine);
                        //--- ADD 2011/06/01 ------------------------------------<<<
                        #endregion // </User���R�[�h>
                    }
                    else
                    {
                        #region <Web���R�[�h>

                        csv.Append("01.�쐬����").Append(COMMA);
                        csv.Append("02.�X�V����").Append(COMMA);
                        csv.Append("03.�_���폜�敪").Append(COMMA);
                        csv.Append("04.�⍇������ƃR�[�h").Append(COMMA);
                        csv.Append("05.�⍇�������_�R�[�h").Append(COMMA);
                        csv.Append("06.�⍇�����ƃR�[�h").Append(COMMA);
                        csv.Append("07.�⍇���拒�_�R�[�h").Append(COMMA);
                        csv.Append("08.�⍇���ԍ�").Append(COMMA);
                        csv.Append("09.�X�V�N����").Append(COMMA);
                        csv.Append("10.�X�V�����b�~���b").Append(COMMA);
                        csv.Append("11.�⍇���s�ԍ�").Append(COMMA);
                        csv.Append("12.�⍇���s�ԍ��}��").Append(COMMA);
                        csv.Append("13.�⍇�������׎���GUID").Append(COMMA);
                        csv.Append("14.�⍇���於�掯��GUID").Append(COMMA);
                        csv.Append("15.���i���").Append(COMMA);
                        csv.Append("16.���T�C�N�����i���").Append(COMMA);
                        csv.Append("17.���T�C�N�����i����").Append(COMMA);
                        csv.Append("18.�[�i�敪").Append(COMMA);
                        csv.Append("19.�戵�敪").Append(COMMA);
                        csv.Append("20.���i�`��").Append(COMMA);
                        csv.Append("21.�[�i�m�F�敪").Append(COMMA);
                        csv.Append("22.�[�i�����\���").Append(COMMA);
                        csv.Append("23.�񓚔[��").Append(COMMA);
                        csv.Append("24.BL���i�R�[�h").Append(COMMA);
                        csv.Append("25.BL���i�R�[�h�}��").Append(COMMA);
                        csv.Append("26.�┭���i��").Append(COMMA);
                        csv.Append("27.�񓚏��i��").Append(COMMA);
                        csv.Append("28.������").Append(COMMA);
                        csv.Append("29.�[�i��").Append(COMMA);
                        csv.Append("30.���i�ԍ�").Append(COMMA);
                        csv.Append("31.���i���[�J�[�R�[�h").Append(COMMA);
                        csv.Append("32.���i���[�J�[����").Append(COMMA);
                        csv.Append("33.�������i���[�J�[�R�[�h").Append(COMMA);
                        csv.Append("34.�┭�������i�ԍ�").Append(COMMA);
                        csv.Append("35.�񓚏������i�ԍ�").Append(COMMA);
                        csv.Append("36.�艿").Append(COMMA);
                        csv.Append("37.�P��").Append(COMMA);
                        csv.Append("38.���i�⑫���").Append(COMMA);
                        csv.Append("39.�e���z").Append(COMMA);
                        csv.Append("40.�e����").Append(COMMA);
                        csv.Append("41.�񓚊���").Append(COMMA);
                        csv.Append("42.���l(����)").Append(COMMA);
                        csv.Append("43.�I��").Append(COMMA);
                        csv.Append("44.�ǉ��敪").Append(COMMA);
                        csv.Append("45.�����敪").Append(COMMA);
                        csv.Append("46.�⍇���E�������").Append(COMMA);
                        csv.Append("47.�\������").Append(COMMA);
                        //csv.Append("48.�ŐV���ʋ敪").Append(Environment.NewLine);  //DEL 2011/06/01
                        //--- ADD 2011/06/01 ------------------------------------>>>
                        csv.Append("48.�ŐV���ʋ敪").Append(COMMA);
                        csv.Append("49.�L�����Z����ԋ敪").Append(COMMA);
                        csv.Append("50.PM�󒍃X�e�[�^�X").Append(COMMA);
                        csv.Append("51.PM����`�[�ԍ�").Append(COMMA);
                        csv.Append("52.PM����s�ԍ�").Append(COMMA);
                        csv.Append("53.���׎捞�敪").Append(COMMA);
                        csv.Append("54.PM�q�ɃR�[�h").Append(COMMA);
                        csv.Append("55.PM�q�ɖ���").Append(COMMA);
                        // UPD 2018/04/16 ���� �VBL�R�[�h�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
                        //csv.Append("56.PM�I��").Append(Environment.NewLine);
                        csv.Append("56.PM�I��").Append(COMMA);
                        csv.Append("57.�┭BL���ꕔ�i�R�[�h(�X���[�R�[�h��)").Append(COMMA);
                        csv.Append("58.�┭BL���ꕔ�i�T�u�R�[�h").Append(COMMA);
                        csv.Append("59.��BL���ꕔ�i�R�[�h(�X���[�R�[�h��)").Append(COMMA);
                        csv.Append("60.��BL���ꕔ�i�T�u�R�[�h").Append(COMMA);
                        csv.Append("61.��BL���i�R�[�h").Append(COMMA);
                        csv.Append("62.��BL���i�R�[�h�}��").Append(Environment.NewLine);
                        // UPD 2018/04/16 ���� �VBL�R�[�h�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                        //--- ADD 2011/06/01 ------------------------------------<<<
                        #endregion // </Web���R�[�h>
                    }
                }

                #endregion // </�^�C�g���s>

                foreach (ISCMOrderAnswerRecord scmAnswerRecord in webAnswerRecordList)
                {
                    csv.Append(scmAnswerRecord.ToCSV()).Append(Environment.NewLine);
                }
            }
            return csv.ToString();
        }

        // ADD 2012/12/27 2013/03/13�z�M SCM��Q��10378�Ή� ------------------------------------>>>>> 
        /// <summary>
        /// CSV�ɕϊ����܂��B
        /// </summary>
        /// <param name="scmDetailRecordList">SCM�󔭒����׃f�[�^(�⍇���E����)�̃��R�[�h���X�g</param>
        /// <returns>CSV</returns>
        /// <remarks>
        /// <br>Update Note      :   2018/04/16 ����</br>
        /// <br>�Ǘ��ԍ�         :   11470007-00</br>
        /// <br>                 :   SF����̖⍇���E�����̃f�[�^�ɐVBL�R�[�h�A�VBL�T�u�R�[�h���ڒǉ�</br>
        /// </remarks>
        public static string ConvertCSV(List<WebDetailRecordType> scmDetailRecordList)
        {
            List<ISCMOrderDetailRecord> webDetailRecordList = new List<ISCMOrderDetailRecord>();
            {
                foreach (WebDetailRecordType webRecord in scmDetailRecordList)
                {
                    webDetailRecordList.Add(new WebSCMOrderDetailRecord(webRecord));
                }
            }

            StringBuilder csv = new StringBuilder();
            {
                #region <�^�C�g���s>

                if (webDetailRecordList != null && webDetailRecordList.Count > 0)
                {
                    if (webDetailRecordList[0] is UserSCMOrderDetailRecord)
                    {
                        #region <User���R�[�h>

                        csv.Append("01.�쐬����").Append(COMMA);
                        csv.Append("02.�X�V����").Append(COMMA);
                        csv.Append("03.��ƃR�[�h").Append(COMMA);
                        csv.Append("04.GUID").Append(COMMA);
                        csv.Append("05.�X�V�]�ƈ��R�[�h").Append(COMMA);
                        csv.Append("06.�X�V�A�Z���u��1").Append(COMMA);
                        csv.Append("07.�X�V�A�Z���u��2").Append(COMMA);
                        csv.Append("08.�_���폜�敪").Append(COMMA);
                        csv.Append("09.�⍇������ƃR�[�h").Append(COMMA);
                        csv.Append("10.�⍇�������_�R�[�h").Append(COMMA);
                        csv.Append("11.�⍇�����ƃR�[�h").Append(COMMA);
                        csv.Append("12.�⍇���拒�_�R�[�h").Append(COMMA);
                        csv.Append("13.�⍇���ԍ�").Append(COMMA);
                        csv.Append("14.�X�V�N����").Append(COMMA);
                        csv.Append("15.�X�V�����b�~���b").Append(COMMA);
                        csv.Append("16.�⍇���s�ԍ�").Append(COMMA);
                        csv.Append("17.�⍇���s�ԍ��}��").Append(COMMA);
                        csv.Append("18.�⍇�������׎���GUID").Append(COMMA);
                        csv.Append("19.�⍇���於�掯��GUID").Append(COMMA);
                        csv.Append("20.���i���").Append(COMMA);
                        csv.Append("21.���T�C�N�����i���").Append(COMMA);
                        csv.Append("22.���T�C�N�����i����").Append(COMMA);
                        csv.Append("23.�[�i�敪").Append(COMMA);
                        csv.Append("24.�戵�敪").Append(COMMA);
                        csv.Append("25.���i�`��").Append(COMMA);
                        csv.Append("26.�[�i�m�F�敪").Append(COMMA);
                        csv.Append("27.�[�i�����\���").Append(COMMA);
                        csv.Append("28.�񓚔[��").Append(COMMA);
                        csv.Append("29.BL���i�R�[�h").Append(COMMA);
                        csv.Append("30.BL���i�R�[�h�}��").Append(COMMA);
                        csv.Append("31.�┭���i��").Append(COMMA);
                        csv.Append("32.�񓚏��i��").Append(COMMA);
                        csv.Append("33.������").Append(COMMA);
                        csv.Append("34.�[�i��").Append(COMMA);
                        csv.Append("35.���i�ԍ�").Append(COMMA);
                        csv.Append("36.���i���[�J�[�R�[�h").Append(COMMA);
                        csv.Append("37.���i���[�J�[����").Append(COMMA);
                        csv.Append("38.�������i���[�J�[�R�[�h").Append(COMMA);
                        csv.Append("39.�┭�������i�ԍ�").Append(COMMA);
                        csv.Append("40.�񓚏������i�ԍ�").Append(COMMA);
                        csv.Append("41.�艿").Append(COMMA);
                        csv.Append("42.�P��").Append(COMMA);
                        csv.Append("43.���i�⑫���").Append(COMMA);
                        csv.Append("44.�e���z").Append(COMMA);
                        csv.Append("45.�e����").Append(COMMA);
                        csv.Append("46.�񓚊���").Append(COMMA);
                        csv.Append("47.���l(����)").Append(COMMA);
                        csv.Append("48.�Y�t�t�@�C��(����)").Append(COMMA);
                        csv.Append("49.�Y�t�t�@�C����(����)").Append(COMMA);
                        csv.Append("50.�I��").Append(COMMA);
                        csv.Append("51.�ǉ��敪").Append(COMMA);
                        csv.Append("52.�����敪").Append(COMMA);
                        csv.Append("53.�⍇���E�������").Append(COMMA);
                        csv.Append("54.�\������").Append(COMMA);
                        csv.Append("55.�L�����Z����ԋ敪").Append(COMMA);
                        csv.Append("53.�󒍃X�e�[�^�X").Append(COMMA);
                        csv.Append("54.����`�[�ԍ�").Append(COMMA);
                        csv.Append("55.����`�[�s�ԍ�").Append(Environment.NewLine);

                        #endregion // </User���R�[�h>
                    }
                    else
                    {
                        #region <Web���R�[�h>

                        csv.Append("01.�쐬����").Append(COMMA);
                        csv.Append("02.�X�V����").Append(COMMA);
                        csv.Append("03.��ƃR�[�h").Append(COMMA);
                        csv.Append("04.GUID").Append(COMMA);
                        csv.Append("05.�X�V�]�ƈ��R�[�h").Append(COMMA);
                        csv.Append("06.�X�V�A�Z���u��1").Append(COMMA);
                        csv.Append("07.�X�V�A�Z���u��2").Append(COMMA);
                        csv.Append("08.�_���폜�敪").Append(COMMA);
                        csv.Append("09.�⍇������ƃR�[�h").Append(COMMA);
                        csv.Append("10.�⍇�������_�R�[�h").Append(COMMA);
                        csv.Append("11.�⍇�����ƃR�[�h").Append(COMMA);
                        csv.Append("12.�⍇���拒�_�R�[�h").Append(COMMA);
                        csv.Append("13.�⍇���ԍ�").Append(COMMA);
                        csv.Append("14.�X�V�N����").Append(COMMA);
                        csv.Append("15.�X�V�����b�~���b").Append(COMMA);
                        csv.Append("16.�⍇���s�ԍ�").Append(COMMA);
                        csv.Append("17.�⍇���s�ԍ��}��").Append(COMMA);
                        csv.Append("18.�⍇�������׎���GUID").Append(COMMA);
                        csv.Append("19.�⍇���於�掯��GUID").Append(COMMA);
                        csv.Append("20.���i���").Append(COMMA);
                        csv.Append("21.���T�C�N�����i���").Append(COMMA);
                        csv.Append("22.���T�C�N�����i����").Append(COMMA);
                        csv.Append("23.�[�i�敪").Append(COMMA);
                        csv.Append("24.�戵�敪").Append(COMMA);
                        csv.Append("25.���i�`��").Append(COMMA);
                        csv.Append("26.�[�i�m�F�敪").Append(COMMA);
                        csv.Append("27.�[�i�����\���").Append(COMMA);
                        csv.Append("28.�񓚔[��").Append(COMMA);
                        csv.Append("29.BL���i�R�[�h").Append(COMMA);
                        csv.Append("30.BL���i�R�[�h�}��").Append(COMMA);
                        csv.Append("31.�┭���i��").Append(COMMA);
                        csv.Append("32.�񓚏��i��").Append(COMMA);
                        csv.Append("33.������").Append(COMMA);
                        csv.Append("34.�[�i��").Append(COMMA);
                        csv.Append("35.���i�ԍ�").Append(COMMA);
                        csv.Append("36.���i���[�J�[�R�[�h").Append(COMMA);
                        csv.Append("37.���i���[�J�[����").Append(COMMA);
                        csv.Append("38.�������i���[�J�[�R�[�h").Append(COMMA);
                        csv.Append("39.�┭�������i�ԍ�").Append(COMMA);
                        csv.Append("40.�񓚏������i�ԍ�").Append(COMMA);
                        csv.Append("41.�艿").Append(COMMA);
                        csv.Append("42.�P��").Append(COMMA);
                        csv.Append("43.���i�⑫���").Append(COMMA);
                        csv.Append("44.�e���z").Append(COMMA);
                        csv.Append("45.�e����").Append(COMMA);
                        csv.Append("46.�񓚊���").Append(COMMA);
                        csv.Append("47.���l(����)").Append(COMMA);
                        csv.Append("48.�Y�t�t�@�C��(����)").Append(COMMA);
                        csv.Append("49.�Y�t�t�@�C����(����)").Append(COMMA);
                        csv.Append("50.�I��").Append(COMMA);
                        csv.Append("51.�ǉ��敪").Append(COMMA);
                        csv.Append("52.�����敪").Append(COMMA);
                        csv.Append("53.�⍇���E�������").Append(COMMA);
                        csv.Append("54.�\������").Append(COMMA);
                        csv.Append("55.�L�����Z����ԋ敪").Append(COMMA);
                        csv.Append("53.�󒍃X�e�[�^�X").Append(COMMA);
                        csv.Append("54.����`�[�ԍ�").Append(COMMA);
                        // UPD 2018/04/16 ���� �VBL�R�[�h�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
                        //csv.Append("55.����`�[�s�ԍ�").Append(Environment.NewLine);
                        csv.Append("55.����`�[�s�ԍ�").Append(COMMA);
                        csv.Append("56.�┭BL���ꕔ�i�R�[�h(�X���[�R�[�h��)").Append(COMMA);
                        csv.Append("57.�┭BL���ꕔ�i�T�u�R�[�h").Append(COMMA);
                        csv.Append("58.��BL���ꕔ�i�R�[�h(�X���[�R�[�h��)").Append(COMMA);
                        csv.Append("59.��BL���ꕔ�i�T�u�R�[�h").Append(COMMA);
                        csv.Append("60.��BL���i�R�[�h").Append(COMMA);
                        csv.Append("61.��BL���i�R�[�h�}��").Append(Environment.NewLine);
                        // UPD 2018/04/16 ���� �VBL�R�[�h�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<

                        #endregion // </Web���R�[�h>
                    }
                }

                #endregion // </�^�C�g���s>

                foreach (ISCMOrderDetailRecord scmDetailRecord in webDetailRecordList)
                {
                    csv.Append(scmDetailRecord.ToCSV()).Append(Environment.NewLine);
                }
            }
            return csv.ToString();
        }
        // ADD 2012/12/27 2013/03/13�z�M SCM��Q��10378�Ή� ------------------------------------<<<<< 

        #endregion // </CSV�ϊ�>
    }
}

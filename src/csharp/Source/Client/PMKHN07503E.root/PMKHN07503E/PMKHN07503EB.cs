using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Broadleaf.Application.UIData
{

    //******************************************************************************************
    //
    //  ���̃\�[�X�t�@�C���ɂ́u���[���r���[�A�[�v�Ɋ֘A����N���X, �e��p�����[�^��A
    //  �e���`����������Ă��܂�
    //
    //******************************************************************************************

    /// <summary>
    /// ���[���r���[�A�[����p�����[�^
    /// </summary>
    public class MailViewerOperationInfo
    {
        /// <summary>
        /// �r���[�A�[�\�����[�h 0:Default
        /// </summary>
        static public int ViewMode_Default = 0;

        /// <summary>
        /// �r���[�A�[�\�����[�h 1:ReadOnly
        /// </summary>
        static public int ViewMode_ReadOnly = 1;


        #region �R���X�g���N�^
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public MailViewerOperationInfo()
        {


        }

        #endregion

        #region �v���p�e�B

        /// <summary>
        /// �\�����[�h 0:Default,  1:ReadOnly���[�h....
        /// 0:Default �̏ꍇ�̓��[���f�[�^�̕\���A�ҏW�A���M���S�Ă̋@�\��L���ɂ��Ă�������
        /// </summary>
        public int ViewerMode = 0;

        /// <summary>
        /// �����X�e�[�^�X(�ڍׂȃX�e�[�^�X)
        /// �� ���[�����M�����A�v���r���[�����A �v���r���[��ʂŃL�����Z������� 
        /// </summary>
        public int Status = 0;

        /// <summary>
        /// �������b�Z�[�W(�G���[���b�Z�[�W���ƘA�����郁�b�Z�[�W ��O��throw�ł��Ȃ��ꍇ���A�K�X�g�p���Ă�������)
        /// </summary>
        public string message = "";

        #endregion


    }


    /// <summary>
    /// ���[���f�[�^�\�[�X
    /// </summary>
    /// <remarks>
    /// ���M�Ώۂ̃��[���f�[�^���X�g�Ɗe�푀���񋟂���N���X�ł��B
    /// ���M�Ώۂ̃��[���f�[�^���X�g�ւ̑���(�������A���[���f�[�^�ǉ��A�폜...��)�͂��̃N���X��
    /// �������Ă����Ɨǂ����Ǝv���܂��B
    /// <br></br>
    /// <br></br>
    /// �w���ł��̂悤�ȃN���X���K�v�Ȃ́H�x
    /// <br></br>
    /// <br></br>
    /// ���[���f�[�^�\�[�X��DataSet�łȂ��Ȃ����ꍇ��A
    /// ���[���f�[�^�\�[�X�ɑ΂��ĕҏW�������K�v�ɂȂ�ꍇ��
    /// ���̃N���X���ŃR���o�[�^��ҏW���\�b�h���������ċz������悤�ɂ��܂�
    /// �ǂ̂悤�ȏ�Ԃ�z�肵�Ă��邩�Ƃ����ƁA����� NsMacroConverter --> Preview --> MailSender
    /// �̗����DataSet���g�p���邱�ƂɂȂ��Ă��܂����A
    /// NsMacroConverter�͑��V�X�e���ł͐�p�ɍ�蒼���̂ŁA�K������DataSet���g�p�ł���Ƃ͌���܂���B
    /// ���̂悤�ȏꍇ�ɗႦ�΁AxxMacroConverter �Ő������ꂽ���[���f�[�^�\�[�X��XML�ł���΁A
    /// ����XML�����̃N���X�Ŏ󂯎���ē�����DataSet�֕ϊ������ Preview --> MailSender ���� 
    /// �㑱�����ɕύX��������K�v���Ȃ��Ȃ�܂��B
    /// �܂��A�t�ɖ{���[���T�[�r�X�Ő����������[���f�[�^�𑼂̃T�[�r�X(�V�X�e��)�֓�����悤�Ȃ��Ƃ�
    /// ����΂��̃N���X���Ŏg�p����Ă��� MailDataList ���A���T�[�r�X�̃C���^�t�F�[�X�d�l�ɍ��킹��
    /// �ϊ����郁�\�b�h���������邱�ƂŖ{���[���T�[�r�X���̃f�[�^��`�͕ς����ɘA�g�ł���Ǝv���܂��B
    /// (�����Ƃ��낢�날��̂ł����A�����͌��.... 2006.10.04 R.Sokei)
    /// </remarks>
    public class MailSourceData
    {
        // ���[���f�[�^�\�[�X��DataSet�łȂ��Ȃ����ꍇ��A
        // ���[���f�[�^�\�[�X�ɑ΂��ĕҏW�������K�v�ɂȂ�ꍇ��
        // ���̃N���X���ŃR���o�[�^��ҏW���\�b�h���������ċz������悤�ɂ��܂�
        //
        // �ǂ̂悤�ȏ�Ԃ�z�肵�Ă��邩�Ƃ����ƁA����� NsMacroConverter --> Preview --> MailSender
        // �̗����DataSet���g�p���邱�ƂɂȂ��Ă��܂����A
        // NsMacroConverter�͑��V�X�e���ł͐�p�ɍ�蒼���̂ŁA�K������DataSet���g�p�ł���Ƃ͌���܂���B
        // ���̂悤�ȏꍇ�ɗႦ�΁AxxMacroConverter �Ő������ꂽ���[���f�[�^�\�[�X��XML�ł���΁A
        // ����XML�����̃N���X�Ŏ󂯎���ē�����DataSet�֕ϊ������ Preview --> MailSender ���� 
        // �㑱�����ɕύX��������K�v���Ȃ��Ȃ�܂��B
        // �܂��A�t�ɖ{���[���T�[�r�X�Ő����������[���f�[�^�𑼂̃T�[�r�X(�V�X�e��)�֓�����悤�Ȃ��Ƃ�
        // ����΂��̃N���X���Ŏg�p����Ă��� MailDataList ���A���T�[�r�X�̃C���^�t�F�[�X�d�l�ɍ��킹��
        // �ϊ����郁�\�b�h���������邱�ƂŖ{���[���T�[�r�X���̃f�[�^��`�͕ς����ɘA�g�ł���Ǝv���܂��B
        // (�����͌��.... 2006.10.04 R.Sokei)
        //

        #region �R���X�g���N�^
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public MailSourceData()
        {



        }


        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="mailSource">���[���f�[�^�\�[�X</param>
        public MailSourceData(object mailSource)
        {
            if (mailSource != null)
            {
                if (mailSource is DataSet)
                {
                    // ������mailSource�����[���f�[�^��\���Ă��邩�ǂ����̃`�F�b�N��
                    // ���������ǂ�

                    this.MailDataList = (DataSet)mailSource;

                }
                else if (mailSource is string)
                {
                    // �X�g�����O�^�̃e�L�X�g��\�������邽�߂� DataSet���̃��[���{���ɃZ�b�g����
                    //                    MailDataList = (DataSet)mailSource;

                 
                }
            }
        }

        #endregion


        #region static �����o

        /// <summary>
        /// ���[���f�[�^ �e�[�u������
        /// </summary>
        static public string TABLE_MailDataList = "TABLE_MailDataList";


        /// <summary>
        /// �쐬����
        /// </summary>
        static public string MEMBER_MailData_CreateDateTime = "CreateDateTime";
        /// <summary>
        /// �X�V����
        /// </summary>
        static public string MEMBER_MailData_UpdateDateTime = "UpdateDateTime";
        /// <summary>
        /// ��ƃR�[�h
        /// </summary>
        static public string MEMBER_MailData_EnterpriseCode = "EnterpriseCode";
        /// <summary>
        /// GUID
        /// </summary>
        static public string MEMBER_MailData_FileHeaderGuid = "FileHeaderGuid";
        /// <summary>
        /// �X�V�]�ƈ��R�[�h
        /// </summary>
        static public string MEMBER_MailData_UpdEmployeeCode = "UpdEmployeeCode";
        /// <summary>
        /// �X�V�A�Z���u��ID1
        /// </summary>
        static public string MEMBER_MailData_UpdAssemblyId1 = "UpdAssemblyId1";
        /// <summary>
        /// �X�V�A�Z���u��ID2
        /// </summary>
        static public string MEMBER_MailData_UpdAssemblyId2 = "UpdAssemblyId2";
        /// <summary>
        /// �_���폜�敪
        /// </summary>
        static public string MEMBER_MailData_LogicalDeleteCode = "LogicalDeleteCode";
        /// <summary>
        /// ���M���_�R�[�h
        /// </summary>
        static public string MEMBER_MailData_SendSectionCode = "SendSectionCode";
        /// <summary>
        /// ���[���Ǘ��A��
        /// </summary>
        static public string MEMBER_MailData_MailManagementConsNo = "MailManagementConsNo";
        /// <summary>
        /// ���[���X�e�[�^�X
        /// </summary>
        static public string MEMBER_MailData_MailStatus = "MailStatus";
        /// <summary>
        /// ���M����
        /// </summary>
        static public string MEMBER_MailData_SendDateTime = "SendDateTime";
        /// <summary>
        /// ���Ӑ�R�[�h
        /// </summary>
        static public string MEMBER_MailData_CustomerCode = "CustomerCode";
        /// <summary>
        /// ����
        /// </summary>
        static public string MEMBER_MailData_Name = "Name";
        /// <summary>
        /// ����2
        /// </summary>
        static public string MEMBER_MailData_Name2 = "Name2";
        /// <summary>
        /// ����1+2(���ۂ̃}�X�^�f�[�^�ɂ͑��݂��܂���)
        /// </summary>
        static public string MEMBER_MailData_FullName = "CustomerFullName";
        /// <summary>
        /// �h��
        /// </summary>
        static public string MEMBER_MailData_HonorificTitle = "HonorificTitle";
        /// <summary>
        /// �J�i
        /// </summary>
        static public string MEMBER_MailData_Kana = "Kana";
        /// <summary>
        /// ���[���A�h���X
        /// </summary>
        static public string MEMBER_MailData_MailAddress = "MailAddress";
        /// <summary>
        /// ���[���A�h���X��ʃR�[�h
        /// </summary>
        static public string MEMBER_MailData_MailAddrKindCode1 = "MailAddrKindCode1";
        /// <summary>
        /// ���[���A�h���X��ʖ���
        /// </summary>
        static public string MEMBER_MailData_MailAddrKindName1 = "MailAddrKindName1";
        /// <summary>
        /// ���[�����M�敪�R�[�h
        /// </summary>
        static public string MEMBER_MailData_MailSendCode1 = "MailSendCode1";
        /// <summary>
        /// ���[���`��
        /// </summary>
        static public string MEMBER_MailData_MailFormal = "MailFormal";
        /// <summary>
        /// ���o�A�Z���u���敪
        /// </summary>
        static public string MEMBER_MailData_ExtraAssemblyDivide = "ExtraAssemblyDivide";
        /// <summary>
        /// ���[�������ԍ�
        /// </summary>
        static public string MEMBER_MailData_MailDocumentNo = "MailDocumentNo";
        /// <summary>
        /// ���[�������敪
        /// </summary>
        static public string MEMBER_MailData_MailDocCode = "MailDocCode";

        /// <summary>
        /// ���[���^�C�g��
        /// </summary>
        static public string MEMBER_MailData_MailTitle = "MailTitle";
        /// <summary>
        /// ���[������
        /// </summary>
        static public string MEMBER_MailData_MailDocumentCnts = "MailDocumentCnts";

        /// <summary>
        /// ���[���Ǘ�Guid
        /// </summary>
        static public string MEMBER_MailData_MailMngGuid = "MailMngGuid";

        /// <summary>
        /// CC
        /// </summary>
        static public string MEMBER_MailData_CarbonCopy = "CarbonCopy";

        /// <summary>
        /// �Y�t�t�@�C��
        /// </summary>
        static public string MEMBER_MailData_AttachFile = "AttachFile";

        #endregion


        #region �v���p�e�B
        /// <summary>
        /// ���[���f�[�^�\�[�X
        /// </summary>
        public DataSet MailDataList = null;


        private bool _EnableCarInfo = true;
        #endregion



        #region public���\�b�h

        /// <summary>
        /// ���݂̃f�[�^�\�[�X�̎w�肳�ꂽ�ʒu�̃f�[�^��MailBackup�N���X�̌`���Ŏ擾���܂�
        /// </summary>
        /// <param name="pos">�擾�ʒu</param>
        /// <returns>�擾�f�[�^</returns>
        public MailBackup GetMailBackupData(int pos)
        {
            MailBackup retObj = null;
            if (this.MailDataList != null)
            {

                if (this.MailDataList.Tables.Contains(TABLE_MailDataList))
                {

                    if(this.MailDataList.Tables[TABLE_MailDataList].Rows.Count >= pos)
                    {
                        // �w�肳�ꂽ�ʒu�̃f�[�^�� MailBackup�C���X�^���X�֓]�L 
                        DataRow dr = this.MailDataList.Tables[TABLE_MailDataList].Rows[pos];
                        retObj = new MailBackup();

                        //  �쐬����
                        if (this.MailDataList.Tables[TABLE_MailDataList].Columns.Contains(MailSourceData.MEMBER_MailData_CreateDateTime))
                        {
                            if ((dr[MailSourceData.MEMBER_MailData_CreateDateTime] != null) && ((dr[MailSourceData.MEMBER_MailData_CreateDateTime] != DBNull.Value)))
                            {
                                retObj.CreateDateTime = (DateTime)dr[MailSourceData.MEMBER_MailData_CreateDateTime];
                            }
                        }

                        // �X�V����
                        if (this.MailDataList.Tables[TABLE_MailDataList].Columns.Contains(MailSourceData.MEMBER_MailData_UpdateDateTime))
                        {
                            if ((dr[MailSourceData.MEMBER_MailData_UpdateDateTime] != null) && (dr[MailSourceData.MEMBER_MailData_UpdateDateTime] != DBNull.Value))
                            {
                                retObj.UpdateDateTime = (DateTime)dr[MailSourceData.MEMBER_MailData_UpdateDateTime];
                            }
                        }
                        // ��ƃR�[�h
                        if (this.MailDataList.Tables[TABLE_MailDataList].Columns.Contains(MailSourceData.MEMBER_MailData_EnterpriseCode))
                        {
                            retObj.EnterpriseCode = (string)dr[MailSourceData.MEMBER_MailData_EnterpriseCode];
                        }
                        // GUID
                        if (this.MailDataList.Tables[TABLE_MailDataList].Columns.Contains(MailSourceData.MEMBER_MailData_FileHeaderGuid))
                        {
                            if ((dr[MailSourceData.MEMBER_MailData_FileHeaderGuid] != null) && ((dr[MailSourceData.MEMBER_MailData_FileHeaderGuid] != DBNull.Value)))
                            {
                                retObj.FileHeaderGuid = (Guid)dr[MailSourceData.MEMBER_MailData_FileHeaderGuid];
                            }
                        }
                        // �X�V�]�ƈ��R�[�h
                        if (this.MailDataList.Tables[TABLE_MailDataList].Columns.Contains(MailSourceData.MEMBER_MailData_UpdEmployeeCode))
                        {
                            retObj.UpdEmployeeCode = (string)dr[MailSourceData.MEMBER_MailData_UpdEmployeeCode];
                        }
                        // �X�V�A�Z���u��ID1
                        if (this.MailDataList.Tables[TABLE_MailDataList].Columns.Contains(MailSourceData.MEMBER_MailData_UpdAssemblyId1))
                        {
                            retObj.UpdAssemblyId1 = (string)dr[MailSourceData.MEMBER_MailData_UpdAssemblyId1];
                        }
                        // �X�V�A�Z���u��ID2
                        if (this.MailDataList.Tables[TABLE_MailDataList].Columns.Contains(MailSourceData.MEMBER_MailData_UpdAssemblyId2))
                        {
                            retObj.UpdAssemblyId2 = (string)dr[MailSourceData.MEMBER_MailData_UpdAssemblyId2];
                        }
                        // �_���폜�敪
                        if (this.MailDataList.Tables[TABLE_MailDataList].Columns.Contains(MailSourceData.MEMBER_MailData_LogicalDeleteCode))
                        {
                            retObj.LogicalDeleteCode = (int)dr[MailSourceData.MEMBER_MailData_LogicalDeleteCode];
                        }
                        // ���M���_�R�[�h
                        if (this.MailDataList.Tables[TABLE_MailDataList].Columns.Contains(MailSourceData.MEMBER_MailData_SendSectionCode))
                        {
                            retObj.SendSectionCode = (string)dr[MailSourceData.MEMBER_MailData_SendSectionCode];
                        }
                        // ���[���Ǘ��A��
                        if (this.MailDataList.Tables[TABLE_MailDataList].Columns.Contains(MailSourceData.MEMBER_MailData_MailManagementConsNo))
                        {
                            retObj.MailManagementConsNo = (int)dr[MailSourceData.MEMBER_MailData_MailManagementConsNo];
                        }
                        // ���[���X�e�[�^�X
                        if (this.MailDataList.Tables[TABLE_MailDataList].Columns.Contains(MailSourceData.MEMBER_MailData_MailStatus))
                        {
                            retObj.MailStatus = (int)dr[MailSourceData.MEMBER_MailData_MailStatus];
                        }
                        // ���M����
                        if (this.MailDataList.Tables[TABLE_MailDataList].Columns.Contains(MailSourceData.MEMBER_MailData_SendDateTime))
                        {
                            retObj.SendDateTime = (long)dr[MailSourceData.MEMBER_MailData_SendDateTime];
                        }
                        // ���Ӑ�R�[�h
                        if (this.MailDataList.Tables[TABLE_MailDataList].Columns.Contains(MailSourceData.MEMBER_MailData_CustomerCode))
                        {
                            retObj.CustomerCode = (int)dr[MailSourceData.MEMBER_MailData_CustomerCode];
                        }
                        // ����
                        if (this.MailDataList.Tables[TABLE_MailDataList].Columns.Contains(MailSourceData.MEMBER_MailData_Name))
                        {
                            retObj.Name = (string)dr[MailSourceData.MEMBER_MailData_Name];
                        }
                        // ����2
                        if (this.MailDataList.Tables[TABLE_MailDataList].Columns.Contains(MailSourceData.MEMBER_MailData_Name2))
                        {
                            retObj.Name2 = (string)dr[MailSourceData.MEMBER_MailData_Name2];
                        }
                        // �h��
                        if (this.MailDataList.Tables[TABLE_MailDataList].Columns.Contains(MailSourceData.MEMBER_MailData_HonorificTitle))
                        {
                            retObj.HonorificTitle = (string)dr[MailSourceData.MEMBER_MailData_HonorificTitle];
                        }
                        // �J�i
                        if (this.MailDataList.Tables[TABLE_MailDataList].Columns.Contains(MailSourceData.MEMBER_MailData_Kana))
                        {
                            retObj.Kana = (string)dr[MailSourceData.MEMBER_MailData_Kana];
                        }
                        // ���[���A�h���X
                        if (this.MailDataList.Tables[TABLE_MailDataList].Columns.Contains(MailSourceData.MEMBER_MailData_MailAddress))
                        {
                            retObj.MailAddress = (string)dr[MailSourceData.MEMBER_MailData_MailAddress];
                        }

                        // ���[���A�h���X��ʃR�[�h
                        if (this.MailDataList.Tables[TABLE_MailDataList].Columns.Contains(MailSourceData.MEMBER_MailData_MailAddrKindCode1))
                        {
                            retObj.MailAddrKindCode1 = (int)dr[MailSourceData.MEMBER_MailData_MailAddrKindCode1];
                        }
                        // ���[���A�h���X��ʖ���
                        if (this.MailDataList.Tables[TABLE_MailDataList].Columns.Contains(MailSourceData.MEMBER_MailData_MailAddrKindName1))
                        {
                            retObj.MailAddrKindName1 = (string)dr[MailSourceData.MEMBER_MailData_MailAddrKindName1];
                        }
                        // ���[�����M�敪�R�[�h
                        if (this.MailDataList.Tables[TABLE_MailDataList].Columns.Contains(MailSourceData.MEMBER_MailData_MailSendCode1))
                        {
                            retObj.MailSendCode1 = (int)dr[MailSourceData.MEMBER_MailData_MailSendCode1];
                        }
                        // ���[���`��
                        if (this.MailDataList.Tables[TABLE_MailDataList].Columns.Contains(MailSourceData.MEMBER_MailData_MailFormal))
                        {
                            retObj.MailFormal = (int)dr[MailSourceData.MEMBER_MailData_MailFormal];
                        }
                        // ���o�A�Z���u���敪
                        if (this.MailDataList.Tables[TABLE_MailDataList].Columns.Contains(MailSourceData.MEMBER_MailData_ExtraAssemblyDivide))
                        {
                            retObj.ExtraAssemblyDivide = (string)dr[MailSourceData.MEMBER_MailData_ExtraAssemblyDivide];
                        }
                        // ���[�������ԍ�
                        if (this.MailDataList.Tables[TABLE_MailDataList].Columns.Contains(MailSourceData.MEMBER_MailData_MailDocumentNo))
                        {
                            retObj.MailDocumentNo = (int)dr[MailSourceData.MEMBER_MailData_MailDocumentNo];
                        }
                        // ���[�������敪
                        if (this.MailDataList.Tables[TABLE_MailDataList].Columns.Contains(MailSourceData.MEMBER_MailData_MailDocCode))
                        {
                            retObj.MailDocCode = (int)dr[MailSourceData.MEMBER_MailData_MailDocCode];
                        }
                        // ���[���^�C�g��
                        if (this.MailDataList.Tables[TABLE_MailDataList].Columns.Contains(MailSourceData.MEMBER_MailData_MailTitle))
                        {
                            retObj.MailTitle = (string)dr[MailSourceData.MEMBER_MailData_MailTitle];
                        }
                        // ���[������
                        if (this.MailDataList.Tables[TABLE_MailDataList].Columns.Contains(MailSourceData.MEMBER_MailData_MailDocumentCnts))
                        {
                            retObj.MailDocumentCnts = (string)dr[MailSourceData.MEMBER_MailData_MailDocumentCnts];
                        }
                        // ���[���Ǘ�Guid
                        if (this.MailDataList.Tables[TABLE_MailDataList].Columns.Contains(MailSourceData.MEMBER_MailData_MailMngGuid))
                        {
                            if ((dr[MailSourceData.MEMBER_MailData_MailMngGuid] != null) && ((dr[MailSourceData.MEMBER_MailData_MailMngGuid] != DBNull.Value)))
                            {
                                retObj.MailMngGuid = (Guid)dr[MailSourceData.MEMBER_MailData_MailMngGuid];
                            }
                        }
                        // CC
                        if (this.MailDataList.Tables[TABLE_MailDataList].Columns.Contains(MailSourceData.MEMBER_MailData_CarbonCopy))
                        {
                            retObj.CarbonCopy = (string)dr[MailSourceData.MEMBER_MailData_CarbonCopy];
                        }
                        // �Y�t�t�@�C��
                        if (this.MailDataList.Tables[TABLE_MailDataList].Columns.Contains(MailSourceData.MEMBER_MailData_AttachFile))
                        {
                            retObj.AttachFile = (string)dr[MailSourceData.MEMBER_MailData_AttachFile];
                        }
                    }
                }

            }

            return retObj;
        }


        /// <summary>
        /// �f�[�^�\�[�X�ɐV�������[���f�[�^��ǉ����܂�
        /// </summary>
        /// <returns></returns>
        public bool AddNewMailData()
        {

            if (this.MailDataList != null)
            {

                if (this.MailDataList.Tables.Contains(TABLE_MailDataList))
                {

                    DataRow dr = this.MailDataList.Tables[TABLE_MailDataList].NewRow();


                    this.MailDataList.Tables[TABLE_MailDataList].Rows.Add(dr);

                }

            }

            return true;
        }

        /// <summary>
        /// �f�[�^�\�[�X�ɐV�������[���f�[�^��ǉ����܂�
        /// </summary>
        /// <param name="mailBackup">���[���o�b�N�A�b�v�f�[�^</param>
        /// <returns>�������� true:����, false:���s</returns>
        public bool AddNewMailData(MailBackup mailBackup)
        {

            if (this.MailDataList == null)
            {
                this.MailDataList = CreateNewMailDataList();
            }

            if (this.MailDataList.Tables.Contains(TABLE_MailDataList))
            {

                DataRow dr = this.MailDataList.Tables[TABLE_MailDataList].NewRow();

                if (mailBackup != null)
                {
                    dr[MEMBER_MailData_CreateDateTime] = mailBackup.CreateDateTime;
                    dr[MEMBER_MailData_UpdateDateTime] = mailBackup.UpdateDateTime;
                    dr[MEMBER_MailData_EnterpriseCode] = mailBackup.EnterpriseCode;
                    dr[MEMBER_MailData_FileHeaderGuid] = mailBackup.FileHeaderGuid;
                    dr[MEMBER_MailData_UpdEmployeeCode] = mailBackup.UpdEmployeeCode;
                    dr[MEMBER_MailData_UpdAssemblyId1] = mailBackup.UpdAssemblyId1;
                    dr[MEMBER_MailData_UpdAssemblyId2] = mailBackup.UpdAssemblyId2;
                    dr[MEMBER_MailData_LogicalDeleteCode] = mailBackup.LogicalDeleteCode;
                    dr[MEMBER_MailData_SendSectionCode] = mailBackup.SendSectionCode;
                    dr[MEMBER_MailData_MailManagementConsNo] = mailBackup.MailManagementConsNo;
                    dr[MEMBER_MailData_MailStatus] = mailBackup.MailStatus;
                    dr[MEMBER_MailData_SendDateTime] = mailBackup.SendDateTime;
                    dr[MEMBER_MailData_CustomerCode] = mailBackup.CustomerCode;
                    dr[MEMBER_MailData_Name] = mailBackup.Name;
                    dr[MEMBER_MailData_Name2] = mailBackup.Name2;

                    dr[MEMBER_MailData_FullName] = mailBackup.Name + " " + mailBackup.Name2;

                    dr[MEMBER_MailData_HonorificTitle] = mailBackup.HonorificTitle;
                    dr[MEMBER_MailData_Kana] = mailBackup.Kana;
                    dr[MEMBER_MailData_MailAddress] = mailBackup.MailAddress;
                    dr[MEMBER_MailData_MailAddrKindCode1] = mailBackup.MailAddrKindCode1;
                    dr[MEMBER_MailData_MailAddrKindName1] = mailBackup.MailAddrKindName1;
                    dr[MEMBER_MailData_MailSendCode1] = mailBackup.MailSendCode1;
                    dr[MEMBER_MailData_MailFormal] = mailBackup.MailFormal;
                    dr[MEMBER_MailData_ExtraAssemblyDivide] = mailBackup.ExtraAssemblyDivide;
                    dr[MEMBER_MailData_MailDocumentNo] = mailBackup.MailDocumentNo;
                    dr[MEMBER_MailData_MailDocCode] = mailBackup.MailDocCode;
                    dr[MEMBER_MailData_MailTitle] = mailBackup.MailTitle;
                    dr[MEMBER_MailData_MailDocumentCnts] = mailBackup.MailDocumentCnts;
                    dr[MEMBER_MailData_MailMngGuid] = mailBackup.MailMngGuid;
                    dr[MEMBER_MailData_CarbonCopy] = mailBackup.CarbonCopy;
                    dr[MEMBER_MailData_AttachFile] = mailBackup.AttachFile;

                }

                this.MailDataList.Tables[TABLE_MailDataList].Rows.Add(dr);
            }


            return true;
        }



        /// <summary>
        /// �f�[�^�\�[�X�̎w�肳�ꂽ�ʒu�ɐV�������[���f�[�^��}�����܂�
        /// </summary>
        /// <param name="mailBackup">���[���o�b�N�A�b�v�f�[�^</param>
        /// <param name="pos">�}���ʒu</param>
        /// <returns>�������� true:����, false:���s</returns>
        public bool InsertNewMailData(MailBackup mailBackup, int pos)
        {

            if (this.MailDataList == null)
            {
                this.MailDataList = CreateNewMailDataList();
            }

            if (this.MailDataList.Tables.Contains(TABLE_MailDataList))
            {

                DataRow dr = this.MailDataList.Tables[TABLE_MailDataList].NewRow();

                if (mailBackup != null)
                {
                    dr[MEMBER_MailData_CreateDateTime] = mailBackup.CreateDateTime;
                    dr[MEMBER_MailData_UpdateDateTime] = mailBackup.UpdateDateTime;
                    dr[MEMBER_MailData_EnterpriseCode] = mailBackup.EnterpriseCode;
                    dr[MEMBER_MailData_FileHeaderGuid] = mailBackup.FileHeaderGuid;
                    dr[MEMBER_MailData_UpdEmployeeCode] = mailBackup.UpdEmployeeCode;
                    dr[MEMBER_MailData_UpdAssemblyId1] = mailBackup.UpdAssemblyId1;
                    dr[MEMBER_MailData_UpdAssemblyId2] = mailBackup.UpdAssemblyId2;
                    dr[MEMBER_MailData_LogicalDeleteCode] = mailBackup.LogicalDeleteCode;
                    dr[MEMBER_MailData_SendSectionCode] = mailBackup.SendSectionCode;
                    dr[MEMBER_MailData_MailManagementConsNo] = mailBackup.MailManagementConsNo;
                    dr[MEMBER_MailData_MailStatus] = mailBackup.MailStatus;
                    dr[MEMBER_MailData_SendDateTime] = mailBackup.SendDateTime;
                    dr[MEMBER_MailData_CustomerCode] = mailBackup.CustomerCode;
                    dr[MEMBER_MailData_Name] = mailBackup.Name;
                    dr[MEMBER_MailData_Name2] = mailBackup.Name2;

                    dr[MEMBER_MailData_FullName] = mailBackup.Name + " " + mailBackup.Name2;

                    dr[MEMBER_MailData_HonorificTitle] = mailBackup.HonorificTitle;
                    dr[MEMBER_MailData_Kana] = mailBackup.Kana;
                    dr[MEMBER_MailData_MailAddress] = mailBackup.MailAddress;
                    dr[MEMBER_MailData_MailAddrKindCode1] = mailBackup.MailAddrKindCode1;
                    dr[MEMBER_MailData_MailAddrKindName1] = mailBackup.MailAddrKindName1;
                    dr[MEMBER_MailData_MailSendCode1] = mailBackup.MailSendCode1;
                    dr[MEMBER_MailData_MailFormal] = mailBackup.MailFormal;
                    dr[MEMBER_MailData_ExtraAssemblyDivide] = mailBackup.ExtraAssemblyDivide;
                    dr[MEMBER_MailData_MailDocumentNo] = mailBackup.MailDocumentNo;
                    dr[MEMBER_MailData_MailDocCode] = mailBackup.MailDocCode;
                    dr[MEMBER_MailData_MailTitle] = mailBackup.MailTitle;
                    dr[MEMBER_MailData_MailDocumentCnts] = mailBackup.MailDocumentCnts;
                    dr[MEMBER_MailData_MailMngGuid] = mailBackup.MailMngGuid;
                    dr[MEMBER_MailData_CarbonCopy] = mailBackup.CarbonCopy;
                    dr[MEMBER_MailData_AttachFile] = mailBackup.AttachFile;

                }

                this.MailDataList.Tables[TABLE_MailDataList].Rows.InsertAt(dr, pos);
            }


            return true;
        
        
        }


        /// <summary>
        /// �f�[�^�\�[�X�̎w�肳�ꂽ�ʒu�ɐV�������[���f�[�^���X�V���܂�
        /// </summary>
        /// <param name="mailBackup">���[���o�b�N�A�b�v�f�[�^</param>
        /// <param name="pos">�}���ʒu</param>
        /// <returns>�������� true:����, false:���s</returns>
        public bool UpdateNewMailData(MailBackup mailBackup, int pos)
        {

            if (this.MailDataList == null)
            {
                this.MailDataList = CreateNewMailDataList();
            }

            if (this.MailDataList.Tables.Contains(TABLE_MailDataList))
            {
                if (pos < this.MailDataList.Tables[TABLE_MailDataList].Rows.Count)
                {
                    DataRow dr = this.MailDataList.Tables[TABLE_MailDataList].Rows[pos];

                    if (mailBackup != null)
                    {
                        dr[MEMBER_MailData_CreateDateTime] = mailBackup.CreateDateTime;
                        dr[MEMBER_MailData_UpdateDateTime] = mailBackup.UpdateDateTime;
                        dr[MEMBER_MailData_EnterpriseCode] = mailBackup.EnterpriseCode;
                        dr[MEMBER_MailData_FileHeaderGuid] = mailBackup.FileHeaderGuid;
                        dr[MEMBER_MailData_UpdEmployeeCode] = mailBackup.UpdEmployeeCode;
                        dr[MEMBER_MailData_UpdAssemblyId1] = mailBackup.UpdAssemblyId1;
                        dr[MEMBER_MailData_UpdAssemblyId2] = mailBackup.UpdAssemblyId2;
                        dr[MEMBER_MailData_LogicalDeleteCode] = mailBackup.LogicalDeleteCode;
                        dr[MEMBER_MailData_SendSectionCode] = mailBackup.SendSectionCode;
                        dr[MEMBER_MailData_MailManagementConsNo] = mailBackup.MailManagementConsNo;
                        dr[MEMBER_MailData_MailStatus] = mailBackup.MailStatus;
                        dr[MEMBER_MailData_SendDateTime] = mailBackup.SendDateTime;
                        dr[MEMBER_MailData_CustomerCode] = mailBackup.CustomerCode;
                        dr[MEMBER_MailData_Name] = mailBackup.Name;
                        dr[MEMBER_MailData_Name2] = mailBackup.Name2;

                        dr[MEMBER_MailData_FullName] = mailBackup.Name + " " + mailBackup.Name2;

                        dr[MEMBER_MailData_HonorificTitle] = mailBackup.HonorificTitle;
                        dr[MEMBER_MailData_Kana] = mailBackup.Kana;
                        dr[MEMBER_MailData_MailAddress] = mailBackup.MailAddress;
                        dr[MEMBER_MailData_MailAddrKindCode1] = mailBackup.MailAddrKindCode1;
                        dr[MEMBER_MailData_MailAddrKindName1] = mailBackup.MailAddrKindName1;
                        dr[MEMBER_MailData_MailSendCode1] = mailBackup.MailSendCode1;
                        dr[MEMBER_MailData_MailFormal] = mailBackup.MailFormal;
                        dr[MEMBER_MailData_ExtraAssemblyDivide] = mailBackup.ExtraAssemblyDivide;
                        dr[MEMBER_MailData_MailDocumentNo] = mailBackup.MailDocumentNo;
                        dr[MEMBER_MailData_MailDocCode] = mailBackup.MailDocCode;
                        dr[MEMBER_MailData_MailTitle] = mailBackup.MailTitle;
                        dr[MEMBER_MailData_MailDocumentCnts] = mailBackup.MailDocumentCnts;
                        dr[MEMBER_MailData_MailMngGuid] = mailBackup.MailMngGuid;
                        dr[MEMBER_MailData_CarbonCopy] = mailBackup.CarbonCopy;
                        dr[MEMBER_MailData_AttachFile] = mailBackup.AttachFile;
                    }
                }

            }


            return true;
        }


        #region test
        /// <summary>
        /// �f�[�^�\�[�X��Test�p�̃��[���f�[�^��ǉ����܂�
        /// </summary>
        /// <returns></returns>
        public bool AddTestMailData(int no)
        {

            MailBackup mailBackup = new MailBackup();

            //mailBackup.CustomerCode = 1;
            //mailBackup.Name = "�����H���X";
            //mailBackup.Name2 = "���R�c�Ə�";
            //mailBackup.HonorificTitle = "�l";
            //mailBackup.MakerName = "�g���^";
            //mailBackup.ModelName = "�J���[��";
            //mailBackup.NumberPlate1Code = 9120;
            //mailBackup.NumberPlate1Name = "�Ó�";
            //mailBackup.NumberPlate2 = "500";
            //mailBackup.NumberPlate3 = "��";
            //mailBackup.NumberPlate4 = 7777;
            //mailBackup.MailTitle = "�Ԍ��̂��ē�";
            //mailBackup.MailAddress = "misaebon@itxtn.co.jp";
            //mailBackup.MailAddrKindName1 = "����";
            //mailBackup.MailDocumentCnts = "�����H���X ���R�c�Ə� �l \n�Ԍ��̎������߂Â��Ă��܂� \n\n��ӂƒʒ��������Q�̏�A�Ԍ��̌��ςɂ�������Ⴂ�B \n\n ";
            //mailBackup.MailDocumentNo = 100;
            //AddNewMailData(mailBackup);
            //mailBackup = new MailBackup();
            //mailBackup.CustomerCode = 2540;
            //mailBackup.Name = "����(�m)";
            //mailBackup.Name2 = "�V";
            //mailBackup.HonorificTitle = "�a";
            //mailBackup.MakerName = "�j�b�T��";
            //mailBackup.ModelName = "�u���[�o�[�h";
            //mailBackup.NumberPlate1Code = 9120;
            //mailBackup.NumberPlate1Name = "�|��";
            //mailBackup.NumberPlate2 = "330";
            //mailBackup.NumberPlate3 = "��";
            //mailBackup.NumberPlate4 = 941;
            //mailBackup.MailTitle = "�Ԍ��ɗ��񂵂Ⴂ�I�I";
            //mailBackup.MailAddress = "xxx_xxxxxx_xxxx@docomo.ne.jp";
            //mailBackup.MailAddrKindCode1 = 2;
            //mailBackup.MailAddrKindName1 = "�g�ђ[��";
            //mailBackup.MailDocumentCnts = "����(�m) �V�a \n�Ԍ��̎������߂��Ă܂�(���Č������؂�Ă܂�) \n\n��ӂƒʒ��������Q�̏�A�Ԍ��̌��ςɂ�������Ⴂ(�Ԃɏ���Ă��Ă͂����܂���) \n\n ���Ȃ���T�����肾������I \n �Ȃ�ƍ���Ԍ����󂯂�Ɠ��I���ÎԂ���ʊ������i�ł��񋟁I�I";
            //mailBackup.MailDocumentNo = 100100;
            //mailBackup.MailDocCode = 1;
            //AddNewMailData(mailBackup);

            return true;
        }

        #endregion
    
        /// <summary>
        /// �V�������[���f�[�^�\�[�X(DataSet)���쐬���܂�
        /// </summary>
        /// <returns></returns>
        public DataSet CreateNewMailDataList()
        {

            DataSet ds = new DataSet("MailDataList");

            DataTable dt;

            // DataSet�ɐV�K�e�[�u����ǉ�����
            dt = ds.Tables.Add("TABLE_MailDataList");

            // �L�[�͐ݒ肵�Ȃ�
            //            DataColumn[] dc = new DataColumn[1];
            // DataSet�̃e�[�u���Ƀt�B�[���h��ǉ����Ď�L�[��ݒ肷��
            //            dc[0] = dt.Columns.Add("�Ј��ԍ�"
            //                , Type.GetType("System.String"));
            //            dt.PrimaryKey = dc;

            // ���`
            dt.Columns.Add(MEMBER_MailData_CreateDateTime, Type.GetType("System.DateTime"));
            dt.Columns.Add(MEMBER_MailData_UpdateDateTime, Type.GetType("System.DateTime"));
            dt.Columns.Add(MEMBER_MailData_EnterpriseCode, Type.GetType("System.String"));
            dt.Columns.Add(MEMBER_MailData_FileHeaderGuid, Type.GetType("System.Guid"));
            dt.Columns.Add(MEMBER_MailData_UpdEmployeeCode, Type.GetType("System.String"));
            dt.Columns.Add(MEMBER_MailData_UpdAssemblyId1, Type.GetType("System.String"));
            dt.Columns.Add(MEMBER_MailData_UpdAssemblyId2, Type.GetType("System.String"));
            dt.Columns.Add(MEMBER_MailData_LogicalDeleteCode, Type.GetType("System.Int32"));
            dt.Columns.Add(MEMBER_MailData_SendSectionCode, Type.GetType("System.String"));
            dt.Columns.Add(MEMBER_MailData_MailManagementConsNo, Type.GetType("System.Int32"));
            dt.Columns.Add(MEMBER_MailData_MailStatus, Type.GetType("System.Int32"));
            dt.Columns.Add(MEMBER_MailData_SendDateTime, Type.GetType("System.Int64"));
            dt.Columns.Add(MEMBER_MailData_CustomerCode, Type.GetType("System.Int32"));
            dt.Columns.Add(MEMBER_MailData_Name, Type.GetType("System.String"));
            dt.Columns.Add(MEMBER_MailData_Name2, Type.GetType("System.String"));
            dt.Columns.Add(MEMBER_MailData_FullName, Type.GetType("System.String"));
            dt.Columns.Add(MEMBER_MailData_HonorificTitle, Type.GetType("System.String"));
            dt.Columns.Add(MEMBER_MailData_Kana, Type.GetType("System.String"));
            dt.Columns.Add(MEMBER_MailData_MailAddress, Type.GetType("System.String"));
            dt.Columns.Add(MEMBER_MailData_MailAddrKindCode1, Type.GetType("System.Int32"));
            dt.Columns.Add(MEMBER_MailData_MailAddrKindName1, Type.GetType("System.String"));
            dt.Columns.Add(MEMBER_MailData_MailSendCode1, Type.GetType("System.Int32"));
            dt.Columns.Add(MEMBER_MailData_MailFormal, Type.GetType("System.Int32"));
            dt.Columns.Add(MEMBER_MailData_ExtraAssemblyDivide, Type.GetType("System.String"));
            dt.Columns.Add(MEMBER_MailData_MailDocumentNo, Type.GetType("System.Int32"));
            dt.Columns.Add(MEMBER_MailData_MailDocCode, Type.GetType("System.Int32"));
            dt.Columns.Add(MEMBER_MailData_MailTitle, Type.GetType("System.String"));
            dt.Columns.Add(MEMBER_MailData_MailDocumentCnts, Type.GetType("System.String"));
            dt.Columns.Add(MEMBER_MailData_MailMngGuid, Type.GetType("System.Guid"));
            dt.Columns.Add(MEMBER_MailData_CarbonCopy, Type.GetType("System.String"));
            dt.Columns.Add(MEMBER_MailData_AttachFile, Type.GetType("System.String"));

            // �񖼒�`
            dt.Columns[MEMBER_MailData_CreateDateTime].Caption = "�쐬����";
            dt.Columns[MEMBER_MailData_UpdateDateTime].Caption = "�X�V����";
            dt.Columns[MEMBER_MailData_EnterpriseCode].Caption = "��ƃR�[�h";
            dt.Columns[MEMBER_MailData_FileHeaderGuid].Caption = "GUID";
            dt.Columns[MEMBER_MailData_UpdEmployeeCode].Caption = "�X�V�]�ƈ��R�[�h";
            dt.Columns[MEMBER_MailData_UpdAssemblyId1].Caption = "�X�V�A�Z���u��ID1";
            dt.Columns[MEMBER_MailData_UpdAssemblyId2].Caption = "�X�V�A�Z���u��ID2";
            dt.Columns[MEMBER_MailData_LogicalDeleteCode].Caption = "�_���폜�敪";
            dt.Columns[MEMBER_MailData_SendSectionCode].Caption = "���M���_�R�[�h";
            dt.Columns[MEMBER_MailData_MailManagementConsNo].Caption = "���[���Ǘ��A��";
            dt.Columns[MEMBER_MailData_MailStatus].Caption = "���[���X�e�[�^�X";
            dt.Columns[MEMBER_MailData_SendDateTime].Caption = "���M����";
            dt.Columns[MEMBER_MailData_CustomerCode].Caption = "���Ӑ�R�[�h";
            dt.Columns[MEMBER_MailData_Name].Caption = "���Ӑ於��";
            dt.Columns[MEMBER_MailData_Name2].Caption = "���Ӑ於��2";
            dt.Columns[MEMBER_MailData_FullName].Caption = "���Ӑ於��";
            dt.Columns[MEMBER_MailData_HonorificTitle].Caption = "�h��";
            dt.Columns[MEMBER_MailData_Kana].Caption = "���Ӑ於�̃J�i";
            dt.Columns[MEMBER_MailData_MailAddress].Caption = "���[���A�h���X";
            dt.Columns[MEMBER_MailData_MailAddrKindCode1].Caption = "���[���A�h���X��ʃR�[�h";
            dt.Columns[MEMBER_MailData_MailAddrKindName1].Caption = "���[���A�h���X��ʖ���";
            dt.Columns[MEMBER_MailData_MailSendCode1].Caption = "���[�����M�敪�R�[�h";
            dt.Columns[MEMBER_MailData_MailFormal].Caption = "���[���`��";
            dt.Columns[MEMBER_MailData_ExtraAssemblyDivide].Caption = "���o�A�Z���u���敪";
            dt.Columns[MEMBER_MailData_MailDocumentNo].Caption = "���[�������ԍ�";
            dt.Columns[MEMBER_MailData_MailDocCode].Caption = "���[�������敪";
            dt.Columns[MEMBER_MailData_MailTitle].Caption = "���[���^�C�g��";
            dt.Columns[MEMBER_MailData_MailDocumentCnts].Caption = "���[������";
            dt.Columns[MEMBER_MailData_MailDocumentCnts].Caption = "���[���Ǘ�Guid";
            dt.Columns[MEMBER_MailData_CarbonCopy].Caption = "CC";
            dt.Columns[MEMBER_MailData_AttachFile].Caption = "�Y�t�t�@�C��";

            // �� Default Value ��`
            dt.Columns[MEMBER_MailData_CreateDateTime].DefaultValue = DBNull.Value;
            dt.Columns[MEMBER_MailData_UpdateDateTime].DefaultValue = DBNull.Value;
            dt.Columns[MEMBER_MailData_EnterpriseCode].DefaultValue = "";
            dt.Columns[MEMBER_MailData_FileHeaderGuid].DefaultValue = DBNull.Value;
            dt.Columns[MEMBER_MailData_UpdEmployeeCode].DefaultValue = "";
            dt.Columns[MEMBER_MailData_UpdAssemblyId1].DefaultValue = "";
            dt.Columns[MEMBER_MailData_UpdAssemblyId2].DefaultValue = "";
            dt.Columns[MEMBER_MailData_LogicalDeleteCode].DefaultValue = 0;
            dt.Columns[MEMBER_MailData_SendSectionCode].DefaultValue = "";
            dt.Columns[MEMBER_MailData_MailManagementConsNo].DefaultValue = 0;
            dt.Columns[MEMBER_MailData_MailStatus].DefaultValue = 0;
            dt.Columns[MEMBER_MailData_SendDateTime].DefaultValue = 0;
            dt.Columns[MEMBER_MailData_CustomerCode].DefaultValue = 0;
            dt.Columns[MEMBER_MailData_Name].DefaultValue = "";
            dt.Columns[MEMBER_MailData_Name2].DefaultValue = "";
            dt.Columns[MEMBER_MailData_FullName].DefaultValue = "";
            dt.Columns[MEMBER_MailData_HonorificTitle].DefaultValue = "";
            dt.Columns[MEMBER_MailData_Kana].DefaultValue = "";
            dt.Columns[MEMBER_MailData_MailAddress].DefaultValue = "";
            dt.Columns[MEMBER_MailData_MailAddrKindCode1].DefaultValue = 0;
            dt.Columns[MEMBER_MailData_MailAddrKindName1].DefaultValue = "";
            dt.Columns[MEMBER_MailData_MailSendCode1].DefaultValue = 0;
            dt.Columns[MEMBER_MailData_MailFormal].DefaultValue = 0;
            dt.Columns[MEMBER_MailData_ExtraAssemblyDivide].DefaultValue = "";
            dt.Columns[MEMBER_MailData_MailDocumentNo].DefaultValue = 0;
            dt.Columns[MEMBER_MailData_MailDocCode].DefaultValue = 0;
            dt.Columns[MEMBER_MailData_MailTitle].DefaultValue = "";
            dt.Columns[MEMBER_MailData_MailDocumentCnts].DefaultValue = "";
            dt.Columns[MEMBER_MailData_MailMngGuid].DefaultValue = DBNull.Value;
            dt.Columns[MEMBER_MailData_CarbonCopy].DefaultValue = "";
            dt.Columns[MEMBER_MailData_AttachFile].DefaultValue = "";

            return ds;

        }

        /// <summary>
        /// �ԗ����L���敪����
        /// </summary>
        /// <returns>true:�ԗ����L�� false:�ԗ���񖳌�</returns>
        public bool EnableCarInfo()
        {
            bool ret = _EnableCarInfo;
            return ret;
        }

        /// <summary>
        /// �ԗ����L���敪�ݒ�(NsMailFactory�ȊO�ł͎g�p���Ȃ��ł�������)
        /// </summary>
        /// <param name="enableFg"></param>
        public void SetCarInfoStatus(bool enableFg)
        {
            _EnableCarInfo = enableFg;
        }

        #endregion


    }
}

//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : ���i�o�[�R�[�h�֘A�t���}�X�^�o�^�A�N�Z�X�N���X
// �v���O�����T�v   : ���i�o�[�R�[�h�֘A�t���}�X�^�o�^�A�N�Z�X�N���X�ł�
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11370006-00 �쐬�S�� : 杍^
// �� �� ��  2017/06/12  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.IO;
using System.Text;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Common;
using System.Collections;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ���i�o�[�R�[�h�֘A�t���}�X�^�o�^�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���i�o�[�R�[�h�֘A�t���}�X�^�o�^�A�N�Z�X�N���X�ł��B</br>
    /// <br>Programmer : 杍^</br>
    /// <br>Date       : 2017/06/12</br>
    /// <br></br>
    /// <br>Update Note:</br>
    /// </remarks>
    public class HandyGoodsBarCodeAcs
    {
        #region [�萔]
        // �o�^����������ɏI�������X�e�[�^�X
        private const int StatusNomal = 0;
        // �o�^�������^�C���A�E�g�X�e�[�^�X
        private const int StatusTimeout = 5;
        // DB�������ŃG���[�����������X�e�[�^�X
        private const int StatusError = -1;
        /// <summary>���Ńf�[�^���ύX�ς݂̏ꍇ�A�iST_ARSET�j�̃X�e�[�^�X</summary>
        private const int StatusArset = -2;
        /// <summary>�f�t�H���g�G���R�[�h</summary>
        private const string DefaultEncode = "shift_jis";
        /// <summary>���O�p�X</summary>
        private const string PathLog = @"\Log\PMHND";
        /// <summary>�f�t�H���g���O�t�@�C������</summary>
        private const string DefaultNamePgid = "PMHND09301A_";
        /// <summary>�f�t�H���g���O�t�@�C������</summary>
        private const string DefaultNameFile = ".log";
        /// <summary>�f�t�H���g���O�t�@�C�����̓����t�H�[�}�b�g</summary>
        private const string DefaultNameTime = "yyyyMMdd";
        /// <summary>�f�t�H���g���O���e�t�H�[�}�b�g</summary>
        private const string DefaultLogFormat = "{0,-19} {1,-5} {2,-200}";     // yyyy/MM/dd hh:mm:ss
        /// <summary>��ƃR�[�h</summary>
        private const string EnterpriseCode = "��ƃR�[�h:";
        /// <summary>�]�ƈ��R�[�h</summary>
        private const string EmployeeCode = "�]�ƈ��R�[�h:";
        /// <summary>�R���s���[�^��</summary>
        private const string MachineName = "�R���s���[�^��:";
        /// <summary>���i���[�J�[�R�[�h</summary>
        private const string GoodsMakerCd = "���i���[�J�[�R�[�h:";
        /// <summary>���i�ԍ�</summary>
        private const string GoodsNo = "���i�ԍ�:";
        /// <summary>���i�o�[�R�[�h</summary>
        private const string GoodsBarCode = "���i�o�[�R�[�h:";
        /// <summary>���i�o�[�R�[�h���</summary>
        private const string GoodsBarCodeKind = "���i�o�[�R�[�h���:";
        /// <summary>�p�����[�^null���b�Z�[�W</summary>
        private const string ErrorMsgNull = "����������null�ł��B";
        /// <summary>�p�����[�^�G���[���b�Z�[�W</summary>
        private const string ErrorMsgParam = "���̓p�����[�^�G���[���������܂����B";
        #endregion

        // ===================================================================================== //
        // Static �ϐ�
        // ===================================================================================== //
        #region Static Members
        /// <summary>���O�p���b�N</summary>
        static object LogLockObj = null;
        #endregion

        # region [�R���X�g���N�^]
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �R���X�g���N�^�ł��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        public HandyGoodsBarCodeAcs()
        {
            LogLockObj = new object();
        }
        # endregion

        # region [Public Methods]
        /// <summary>
        /// ���i�o�[�R�[�h�֘A�t���}�X�^�o�^����
        /// </summary>
        /// <param name="insertObj">���������I�u�W�F�N�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���i�o�[�R�[�h�֘A�t���}�X�^��o�^���܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2017/06/12</br>
        /// </remarks>
        public int InsertHandyGoodsBarCode(object insertObj)
        {
            int status = StatusError;

            // �o�^�f�[�^
            GoodsBarCodeRevnWork goodsBarCodeRevnWork = insertObj as GoodsBarCodeRevnWork;

            // �p�����[�^��null�̏ꍇ�A
            if (goodsBarCodeRevnWork == null)
            {
                // ���O�o�͂��܂��B
                this.WriteLog(goodsBarCodeRevnWork, ErrorMsgNull);
                return status;
            }
            // �p�����[�^��null�ł͂Ȃ��ꍇ�A�p�����[�^���`�F�b�N���܂��B
            else
            {
                // �K�{���͍��ڃ`�F�b�N
                if (string.IsNullOrEmpty(goodsBarCodeRevnWork.EnterpriseCode)
                    || string.IsNullOrEmpty(goodsBarCodeRevnWork.MachineName.Trim()) 
                    || string.IsNullOrEmpty(goodsBarCodeRevnWork.EmployeeCode.Trim())
                    || string.IsNullOrEmpty(goodsBarCodeRevnWork.GoodsNo.Trim()) 
                    || string.IsNullOrEmpty(goodsBarCodeRevnWork.GoodsBarCode.Trim())
                    || goodsBarCodeRevnWork.GoodsMakerCd <= 0)
                {
                    // �G���[���b�Z�[�W�Ɉ����̖��O�ƒl�����O�o�͂��܂��B
                    this.WriteLog(goodsBarCodeRevnWork, ErrorMsgParam);
                    return status;
                }

                // �����`�F�b�N
                if (goodsBarCodeRevnWork.GoodsMakerCd > 999999 || goodsBarCodeRevnWork.GoodsNo.Length > 40
                    || goodsBarCodeRevnWork.GoodsBarCode.Length > 128 || goodsBarCodeRevnWork.GoodsBarCodeKind > 99
                    || goodsBarCodeRevnWork.EmployeeCode.Length > 9)
                {
                    // �G���[���b�Z�[�W�Ɉ����̖��O�ƒl�����O�o�͂��܂��B
                    this.WriteLog(goodsBarCodeRevnWork, ErrorMsgParam);
                    return status;
                }
            }

            // �o�^�f�[�^�̕␳
            // �`�F�b�N�f�W�b�g�敪�͌Œ�l(0:�Ȃ�)
            goodsBarCodeRevnWork.CheckdigitCode = 0;
            // �񋟃f�[�^�敪�͌Œ�l(0:���[�U�f�[�^)
            goodsBarCodeRevnWork.OfferDataDiv = 0;

            try
            {
                #region ���i�o�[�R�[�h�֘A�t���}�X�^����o�^����
                // �����[�g�擾
                IHandyGoodsBarCodeDB iHandyGoodsBarCodeDB = (IHandyGoodsBarCodeDB)MediationHandyGoodsBarCodeDB.GetHandyGoodsBarCodeDB();

                // ���i�o�[�R�[�h�֘A�t���}�X�^�����[�g�Ăяo��
                byte[] insertByte = XmlByteSerializer.Serialize(goodsBarCodeRevnWork);

                status = iHandyGoodsBarCodeDB.InsertForHandy(insertByte);

                // �o�^����������ɏI�������ꍇ
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = StatusNomal;
                }
                // �o�^�������^�C���A�E�g�̏ꍇ
                else if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                {
                    status = StatusTimeout;
                }
                // ���Ńf�[�^���ύX�ς݂̏ꍇ
                else if (status == StatusArset)
                {
                    status = StatusArset;
                }
                // DB�������ŃG���[�����������ꍇ
                else
                {
                    status = StatusError;
                }
                #endregion
            }
            catch (Exception ex)
            {
                // �G���[���b�Z�[�W�Ɉ����̖��O�ƒl�����O�o�͂��܂��B
                this.WriteLog(goodsBarCodeRevnWork, ex.ToString());
                status = StatusError;
            }
            finally
            {
                // �������Ȃ�
            }

            return status;
        }
        # endregion

        # region [private Methods]
        /// <summary>
        /// �G���[���O�o�͏���
        /// </summary>
        /// <param name="goodsBarCodeRevnWork">���������I�u�W�F�N�g</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>�Ȃ�</returns>
        /// <remarks>
        /// <br>Note       : �G���[���O�����o�͂��܂��B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2017/06/05</br>
        /// </remarks>
        private void WriteLog(GoodsBarCodeRevnWork goodsBarCodeRevnWork, string errMsg)
        {
            string path = System.IO.Directory.GetCurrentDirectory() + PathLog;

            lock (LogLockObj)
            {
                // �t�H���_�����݂��Ȃ��ꍇ�A
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                FileStream fileStream = new FileStream(Path.Combine(path, DefaultNamePgid + DateTime.Now.ToString(DefaultNameTime) + DefaultNameFile), FileMode.Append, FileAccess.Write, FileShare.Write);
                StreamWriter writer = new StreamWriter(fileStream, Encoding.GetEncoding(DefaultEncode));
                DateTime writingDateTime = DateTime.Now;
                writer.WriteLine(string.Format(DefaultLogFormat, writingDateTime, writingDateTime.Millisecond, errMsg));
                // �p�����[�^��null�ł͂Ȃ��ꍇ�A�G���[���b�Z�[�W�Ɉ����̖��O�ƒl���o�͂��܂��B
                if (goodsBarCodeRevnWork != null)
                {
                    // ��ƃR�[�h
                    writer.WriteLine(EnterpriseCode + goodsBarCodeRevnWork.EnterpriseCode);
                    // �]�ƈ��R�[�h
                    writer.WriteLine(EmployeeCode + goodsBarCodeRevnWork.EmployeeCode);
                    // �R���s���[�^��
                    writer.WriteLine(MachineName + goodsBarCodeRevnWork.MachineName);
                    // ���i���[�J�[�R�[�h
                    writer.WriteLine(GoodsMakerCd + goodsBarCodeRevnWork.GoodsMakerCd);
                    // ���i�ԍ�
                    writer.WriteLine(GoodsNo + goodsBarCodeRevnWork.GoodsNo);
                    // ���i�o�[�R�[�h
                    writer.WriteLine(GoodsBarCode + goodsBarCodeRevnWork.GoodsBarCode);
                    // ���i�o�[�R�[�h���
                    writer.WriteLine(GoodsBarCodeKind + goodsBarCodeRevnWork.GoodsBarCodeKind);
                }
                // �t�@�C���X�g���[����null�ł͂Ȃ��ꍇ�A
                if (writer != null) writer.Close();
                if (fileStream != null) fileStream.Close();
            }
            
        }
        #endregion
    }
}

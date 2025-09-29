//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : UOE�ڑ�����}�X�^�����e�i���X
// �v���O�����T�v   : UOE�ڑ�����}�X�^�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : caowj
// �� �� ��  2010/07/27  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Data;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Common;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.Adapter;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// UOE�ڑ�����}�X�^�����e�i���X�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: UOE�ڑ�����}�X�^�e�[�u���̃A�N�Z�X�N���X�ł��B</br>
    /// <br>Programmer	: caowj</br>
    /// <br>Date		: 2010/07/27</br>
    /// <br></br>
    /// </remarks>
    public class UOEConnectInfoAcs
    {
        # region -- Private Members --
        /// <summary> �����[�g�I�u�W�F�N�g�i�[�o�b�t�@ </summary>
        private IUOEConnectInfoDB _iUOEConnectInfoDB = null;
        /// <summary>���O�C�����_</summary>
        private string _loginSectionCode = "";
        # endregion

        # region -- �R���X�g���N�^ --
        /// <summary>
        ///  UOE�ڑ�����}�X�^�����e�i���X�A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note		: UOE�ڑ�����}�X�^�����e�i���X�A�N�Z�X�N���X�̃R���X�g���N�^�ł��B</br>
        /// <br>Programmer	: caowj</br>
        /// <br>Date		: 2010/07/27</br>
        /// <br></br>
        /// </remarks>
        public UOEConnectInfoAcs()
        {
            try
            {
                // �����[�g�I�u�W�F�N�g�擾
                this._iUOEConnectInfoDB = (IUOEConnectInfoDB)MediationUOEConnectInfoDB.GetUOEConnectInfoDB();

            }
            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
                this._iUOEConnectInfoDB = null;
            }

            // ���O�C�����_�擾
            Employee loginEmployee = LoginInfoAcquisition.Employee;
            if (loginEmployee != null)
            {
                this._loginSectionCode = loginEmployee.BelongSectionCode;
            }
        }
        # endregion

        # region [���[�J���A�N�Z�X�p]
        /// <summary> �I�����C�����[�h�̗񋓌^ </summary>
        public enum OnlineMode
        {
            /// <summary> �I�t���C�� </summary>
            Offline,
            /// <summary> �I�����C�� </summary>
            Online
        }

        /// <summary>
        /// �I�����C�����[�h�擾����
        /// </summary>
        /// <returns>OnlineMode</returns>
        /// <remarks>
        /// <br>Note		: �I�����C�����[�h���擾���܂�</br>
        /// <br>Programmer	: caowj</br>
        /// <br>Date		: 2010/07/27</br>
        /// <br></br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if (this._iUOEConnectInfoDB == null)
            {
                return (int)OnlineMode.Offline;
            }
            else
            {
                return (int)OnlineMode.Online;
            }
        }
        # endregion

        # region -- �������� --
        /// <summary>
        /// UOE�ڑ�����}�X�^�N���X�ǂݍ��ݏ���
        /// </summary>
        /// <param name="uOEConnectInfo">UOE�ڑ�����}�X�^�N���X�I�u�W�F�N�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="commAssemblyId">�ʐM�A�Z���u��ID</param>
        /// <param name="cashRegisterNo">���W�ԍ�</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : UOE�ڑ�����}�X�^�N���X����ǂݍ��݂܂��B</br>
        /// <br>Programmer : caowj</br>
        /// <br>Date	   : 2010/07/27</br>
        /// </remarks>
        public int Read(out UOEConnectInfo uOEConnectInfo, string enterpriseCode, string commAssemblyId, int cashRegisterNo)
        {
            try
            {
                uOEConnectInfo = null;
                UOEConnectInfoWork uOEConnectInfoWork = new UOEConnectInfoWork();
                uOEConnectInfoWork.EnterpriseCode = enterpriseCode;
                uOEConnectInfoWork.CommAssemblyId = commAssemblyId;
                uOEConnectInfoWork.CashRegisterNo = cashRegisterNo;

                // XML�֕ϊ����A������̃o�C�i����
                byte[] parabyte = XmlByteSerializer.Serialize(uOEConnectInfoWork);

                // UOE�ڑ�����}�X�^�ǂݍ���
                int status = this._iUOEConnectInfoDB.Read(ref parabyte, 0);

                if (status == 0)
                {
                    // XML�̓ǂݍ���
                    uOEConnectInfoWork = (UOEConnectInfoWork)XmlByteSerializer.Deserialize(parabyte, typeof(UOEConnectInfoWork));
                    // �N���X�������o�R�s�[
                    uOEConnectInfo = CopyToUOEConnectInfoFromUOEConnectInfoWork(uOEConnectInfoWork);
                }
                return status;
            }
            catch (Exception)
            {
                //�ʐM�G���[��-1��߂�
                uOEConnectInfo = null;
                //�I�t���C������null���Z�b�g
                this._iUOEConnectInfoDB = null;
                return -1;
            }
        }

        /// <summary>
        /// �S���������i�_���폜�����j
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : UOE�ڑ�����}�X�^�̑S�����������s���܂��B</br>
        /// <br>	       : �_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
        /// <br>Programmer : caowj</br>
        /// <br>Date	   : 2010/07/27</br>
        /// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode)
        {
            bool nextData;
            int retTotalCnt;
            return SearchUOEConnectInfoProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01, 0, null);
        }

        /// <summary>
        /// ���������i�_���폜�܂ށj
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : UOE�ڑ�����}�X�^�̑S�����������s���܂��B</br>
        /// <br>		   : �_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
        /// <br>Programmer	: caowj</br>
        /// <br>Date		: 2010/07/27</br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, int readCnt, UOEConnectInfo prevUOEConnectInfo)
        {
            return SearchUOEConnectInfoProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01, readCnt, prevUOEConnectInfo);
        }
        
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�S�f�[�^)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �����������s���܂��B</br>
        /// <br>Programmer	: caowj</br>
        /// <br>Date		: 2010/07/27</br>
        /// </remarks>
        private int SearchUOEConnectInfoProc(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, UOEConnectInfo prevUOEConnectInfo)
        {
            UOEConnectInfoWork uOEConnectInfoWork = new UOEConnectInfoWork();
            if (prevUOEConnectInfo != null)
            {
                uOEConnectInfoWork = CopyToUOEConnectInfoWorkFromUOEConnectInfo(prevUOEConnectInfo);
            }
            uOEConnectInfoWork.EnterpriseCode = enterpriseCode;

            // ���f�[�^�L��������
            nextData = false;
            // 0�ŏ�����
            retTotalCnt = 0;

            UOEConnectInfoWork[] al;
            retList = new ArrayList();
            retList.Clear();

            // ���_���擾����
            ArrayList wkList = new ArrayList();
            wkList.Clear();

            // XML�֕ϊ����A������̃o�C�i����
            byte[] parabyte = XmlByteSerializer.Serialize(uOEConnectInfoWork);

            byte[] retbyte;

            // UOE�ڑ�����}�X�^����
            int status = 0;
            status = this._iUOEConnectInfoDB.Search(out retbyte, parabyte, 0, logicalMode);

            if ((status == 0) ||
                (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
            {
                // XML�̓ǂݍ���
                al = (UOEConnectInfoWork[])XmlByteSerializer.Deserialize(retbyte, typeof(UOEConnectInfoWork[]));

                for (int i = 0; i < al.Length; i++)
                {
                    // �T�[�`���ʎ擾
                    UOEConnectInfoWork wkUOEConnectInfoWork = (UOEConnectInfoWork)al[i];
                    // UOE�ڑ�����}�X�^�N���X�փ����o�R�s�[
                    wkList.Add(CopyToUOEConnectInfoFromUOEConnectInfoWork(wkUOEConnectInfoWork));
                }

                retList = wkList;
                if (retList.Count > 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_EOF;
                }
            }
            // �S�����[�h�̏ꍇ�͖߂�l�̌������Z�b�g
            if (readCnt == 0)
            {
                retTotalCnt = retList.Count;
            }

            return status;
        }
        # endregion

        # region -- �o�^��X�V���� --
        /// <summary>
        /// UOE�ڑ�����}�X�^�o�^�E�X�V����
        /// </summary>
        /// <param name="uOEConnectInfo">UOE�ڑ�����}�X�^�N���X</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : UOE�ڑ�����}�X�^�o�^�E�X�V�������s���܂��B</br>
        /// <br>Programmer : caowj</br>
        /// <br>Date	   : 2010/07/27</br>
        /// </remarks>
        public int Write(ref UOEConnectInfo uOEConnectInfo)
        {
            // UOE�ڑ�����}�X�^�N���X����UOE�ڑ�����}�X�^���[�J�[�N���X�Ƀ����o�R�s�[
            UOEConnectInfoWork uOEConnectInfoWork = CopyToUOEConnectInfoWorkFromUOEConnectInfo(uOEConnectInfo);

            // XML�֕ϊ����A������̃o�C�i����
            byte[] parabyte = XmlByteSerializer.Serialize(uOEConnectInfoWork);

            int status = 0;
            try
            {
                // UOE�ڑ�����}�X�^���[�N��������
                status = this._iUOEConnectInfoDB.Write(ref parabyte);
                if (status == 0)
                {
                    // �t�@�C������n����UOE�ڑ�����}�X�^���[�N�N���X���f�V���A���C�Y����
                    uOEConnectInfoWork = (UOEConnectInfoWork)XmlByteSerializer.Deserialize(parabyte, typeof(UOEConnectInfoWork));
                    // �N���X�������o�R�s�[
                    uOEConnectInfo = CopyToUOEConnectInfoFromUOEConnectInfoWork(uOEConnectInfoWork);
                }
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iUOEConnectInfoDB = null;
                //�ʐM�G���[��-1��߂�
                status = -1;
            }
            return status;
        }
        # endregion

        #region -- �폜��������� --
        /// <summary>
        /// �����폜����
        /// </summary>
        /// <param name="uOEConnectInfo">�f�[�^�N���X</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �����폜���s���܂��B</br>
        /// <br>Programmer : caowj</br>
        /// <br>Date	   : 2010/07/27</br>
        /// </remarks>
        public int Delete(UOEConnectInfo uOEConnectInfo)
        {
            try
            {
                UOEConnectInfoWork uOEConnectInfoWorks = new UOEConnectInfoWork();
                uOEConnectInfoWorks = CopyToUOEConnectInfoWorkFromUOEConnectInfo(uOEConnectInfo);

                byte[] parabyte = XmlByteSerializer.Serialize(uOEConnectInfoWorks);

                // �����폜
                int status = this._iUOEConnectInfoDB.Delete(parabyte);
                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iUOEConnectInfoDB = null;

                //�ʐM�G���[��-1��߂�
                return -1;
            }
        }

        /// <summary>
        /// �_���폜����
        /// </summary>
        /// <param name="uOEConnectInfo">�f�[�^�N���X</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �_���폜���s���܂��B</br>
        /// <br>Programmer : caowj</br>
        /// <br>Date	   : 2010/07/27</br>
        /// </remarks>
        public int LogicalDelete(ref UOEConnectInfo uOEConnectInfo)
        {
            try
            {
                UOEConnectInfoWork uOEConnectInfoWork = CopyToUOEConnectInfoWorkFromUOEConnectInfo(uOEConnectInfo);
                // XML�֕ϊ����A������̃o�C�i����
                byte[] parabyte = XmlByteSerializer.Serialize(uOEConnectInfoWork);
                // �C�ӕی��K�C�h�_���폜
                int status = this._iUOEConnectInfoDB.LogicalDelete(ref parabyte);

                if (status == 0)
                {
                    // �t�@�C������n���ĔC�ӕی��K�C�h���[�N�N���X���f�V���A���C�Y����
                    uOEConnectInfoWork = (UOEConnectInfoWork)XmlByteSerializer.Deserialize(parabyte, typeof(UOEConnectInfoWork));
                    // �N���X�������o�R�s�[
                    uOEConnectInfo = CopyToUOEConnectInfoFromUOEConnectInfoWork(uOEConnectInfoWork);

                }
                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iUOEConnectInfoDB = null;
                //�ʐM�G���[��-1��߂�
                return -1;
            }
        }

        /// <summary>
        /// UOE�ڑ�����}�X�^�_���폜��������
        /// </summary>
        /// <param name="uOEConnectInfo">UOE�ڑ�����}�X�^�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : UOE�ڑ�����}�X�^�������s���܂��B</br>
        /// <br>Programmer : caowj</br>
        /// <br>Date	   : 2010/07/27</br>
        /// </remarks>
        public int Revival(ref UOEConnectInfo uOEConnectInfo)
        {
            try
            {
                UOEConnectInfoWork uOEConnectInfoWork = CopyToUOEConnectInfoWorkFromUOEConnectInfo(uOEConnectInfo);
                // XML�֕ϊ����A������̃o�C�i����
                byte[] parabyte = XmlByteSerializer.Serialize(uOEConnectInfoWork);
                // ��������
                int status = this._iUOEConnectInfoDB.RevivalLogicalDelete(ref parabyte);

                if (status == 0)
                {
                    // �t�@�C������n���ď]�ƈ����[�N�N���X���f�V���A���C�Y����
                    uOEConnectInfoWork = (UOEConnectInfoWork)XmlByteSerializer.Deserialize(parabyte, typeof(UOEConnectInfoWork));
                    // �N���X�������o�R�s�[
                    uOEConnectInfo = CopyToUOEConnectInfoFromUOEConnectInfoWork(uOEConnectInfoWork);
                }

                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iUOEConnectInfoDB = null;
                //�ʐM�G���[��-1��߂�
                return -1;
            }
        }
        # endregion

        # region -- �N���X�����o�[�R�s�[���� --
        /// <summary>
        /// �N���X�����o�R�s�[�����iUOE�ڑ�����}�X�^���[�N�N���X��UOE�ڑ�����}�X�^�N���X�j
        /// </summary>
        /// <param name="uOEConnectInfoWork">UOE�ڑ�����}�X�^���[�N�N���X</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note		: UOE�ڑ�����}�X�^���[�N�N���X����UOE�ڑ�����}�X�^�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer  : caowj</br>
        /// <br>Date	    : 2010/07/27</br>
        /// <br></br>
        /// </remarks>
        private UOEConnectInfo CopyToUOEConnectInfoFromUOEConnectInfoWork(UOEConnectInfoWork uOEConnectInfoWork)
        {
            UOEConnectInfo uOEConnectInfo = new UOEConnectInfo();

            uOEConnectInfo.CreateDateTime = uOEConnectInfoWork.CreateDateTime;
            uOEConnectInfo.UpdateDateTime = uOEConnectInfoWork.UpdateDateTime;
            uOEConnectInfo.EnterpriseCode = uOEConnectInfoWork.EnterpriseCode;
            uOEConnectInfo.FileHeaderGuid = uOEConnectInfoWork.FileHeaderGuid;
            uOEConnectInfo.UpdEmployeeCode = uOEConnectInfoWork.UpdEmployeeCode;
            uOEConnectInfo.UpdAssemblyId1 = uOEConnectInfoWork.UpdAssemblyId1;
            uOEConnectInfo.UpdAssemblyId2 = uOEConnectInfoWork.UpdAssemblyId2;
            uOEConnectInfo.LogicalDeleteCode = uOEConnectInfoWork.LogicalDeleteCode;
            uOEConnectInfo.CommAssemblyId = uOEConnectInfoWork.CommAssemblyId;
            uOEConnectInfo.CashRegisterNo = uOEConnectInfoWork.CashRegisterNo;
            uOEConnectInfo.SocketCommPort = uOEConnectInfoWork.SocketCommPort;
            uOEConnectInfo.ReceiveComputerNm = uOEConnectInfoWork.ReceiveComputerNm;
            uOEConnectInfo.ClientTimeOut = uOEConnectInfoWork.ClientTimeOut;

            return uOEConnectInfo;
        }

        /// <summary>
        /// �N���X�����o�R�s�[�����iUOE�ڑ�����}�X�^�N���X��UOE�ڑ�����}�X�^���[�N�N���X�j
        /// </summary>
        /// <param name="uOEConnectInfo">UOE�ڑ�����}�X�^�N���X</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note		: UOE�ڑ�����}�X�^�N���X����UOE�ڑ�����}�X�^���[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer  : caowj</br>
        /// <br>Date	    : 2010/07/27</br>
        /// <br></br>
        /// </remarks>
        private UOEConnectInfoWork CopyToUOEConnectInfoWorkFromUOEConnectInfo(UOEConnectInfo uOEConnectInfo)
        {
            UOEConnectInfoWork uOEConnectInfoWork = new UOEConnectInfoWork();

            uOEConnectInfoWork.CreateDateTime = uOEConnectInfo.CreateDateTime;
            uOEConnectInfoWork.UpdateDateTime = uOEConnectInfo.UpdateDateTime;
            uOEConnectInfoWork.EnterpriseCode = uOEConnectInfo.EnterpriseCode;
            uOEConnectInfoWork.FileHeaderGuid = uOEConnectInfo.FileHeaderGuid;
            uOEConnectInfoWork.UpdEmployeeCode = uOEConnectInfo.UpdEmployeeCode;
            uOEConnectInfoWork.UpdAssemblyId1 = uOEConnectInfo.UpdAssemblyId1;
            uOEConnectInfoWork.UpdAssemblyId2 = uOEConnectInfo.UpdAssemblyId2;
            uOEConnectInfoWork.LogicalDeleteCode = uOEConnectInfo.LogicalDeleteCode;
            uOEConnectInfoWork.CommAssemblyId = uOEConnectInfo.CommAssemblyId;
            uOEConnectInfoWork.CashRegisterNo = uOEConnectInfo.CashRegisterNo;
            uOEConnectInfoWork.SocketCommPort = uOEConnectInfo.SocketCommPort;
            uOEConnectInfoWork.ReceiveComputerNm = uOEConnectInfo.ReceiveComputerNm;
            uOEConnectInfoWork.ClientTimeOut = uOEConnectInfo.ClientTimeOut;

            return uOEConnectInfoWork;
        }
        # endregion
    }
}

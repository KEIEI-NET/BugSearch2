//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �ڑ�����ݒ�}�X�^�����e�i���X
// �v���O�����T�v   : �ڑ�����ݒ�}�X�^�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10805731-00 �쐬�S�� : �����M
// �� �� ��  2012/12/15  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.Adapter;
using System.Data;
using Broadleaf.Xml.Serialization;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �ڑ�����ݒ�}�X�^�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �ڑ�����ݒ�}�X�^�̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer : �����M</br>
    /// <br>Date       : 2012/12/15</br>
    /// <br>�Ǘ��ԍ�   : 10805731-00</br>
    /// <br></br>
    /// </remarks>
    public class ConnectInfoWorkAcs
    {
        #region -- �����[�g�I�u�W�F�N�g�i�[�o�b�t�@ --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �����[�g�I�u�W�F�N�g�i�[�o�b�t�@
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : �����M</br>
        /// <br>Date       : 2012/12/15</br>
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// <br></br>
        /// </remarks>
        private IConnectInfoPrcPrStDB _iConnectInfoWorkAcsDB = null;

        // ���[�J���c�a���[�h
        private static bool _isLocalDBRead = false;	// �f�t�H���g�̓����[�g

        #endregion

        #region -- �R���X�g���N�^ --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : �����M</br>
        /// <br>Date       : 2012/12/15</br>
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// <br></br>
        /// </remarks>
        public ConnectInfoWorkAcs()
        {
            // �����[�g�I�u�W�F�N�g�擾
            this._iConnectInfoWorkAcsDB = (IConnectInfoPrcPrStDB)MediationConnectInfoPrcPrStDB.GetConnectInfoPrcPrStDB();
        }

        #endregion

        #region -- [���[�J���A�N�Z�X�p] --
        /// <summary> �������[�h </summary>
        public enum SearchMode
        {
            /// <summary> ���[�J���A�N�Z�X </summary>
            Local = 0,
            /// <summary> �����[�g�A�N�Z�X </summary>
            Remote = 1
        }
        #endregion

        #region -- �o�^��X�V���� --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �o�^�E�X�V����
        /// </summary>
        /// <param name="connectInfoWork">UI�f�[�^�N���X</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �o�^�E�X�V�������s���܂��B</br>
        /// <br>Programmer : �����M</br>
        /// <br>Date       : 2012/12/15</br>
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// <br></br>
        /// </remarks>
        public int Write(ref ConnectInfoWork connectInfoWork)
        {
            int status = 0;
           
            try
            {
                object objConnectInfoWorkAcsWork = connectInfoWork;

                int writeMode = 0;

                // �������ݏ���
                status = this._iConnectInfoWorkAcsDB.Write(ref objConnectInfoWorkAcsWork, writeMode);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {

                    connectInfoWork = objConnectInfoWorkAcsWork as ConnectInfoWork;
                }
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iConnectInfoWorkAcsDB = null;

                //�ʐM�G���[��-1��߂�
                return -1;
            }
          
            return status;
        }
        #endregion -- �o�^��X�V���� --

        #region -- �폜���� --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �_���폜����
        /// </summary>
        /// <param name="connectInfoWork">�ڑ�����ݒ�}�X�^�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �ڑ�����ݒ�}�X�^�̘_���폜���s���܂��B</br>
        /// <br>Programmer : �����M</br>
        /// <br>Date       : 2012/12/15</br>
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// <br></br>
        /// </remarks>
        public int LogicalDelete(ref ConnectInfoWork connectInfoWork)
        {
            try
            {
                object objConnectInfoWorkAcsWork = connectInfoWork;

                // �ڑ�����_���폜
                int status = this._iConnectInfoWorkAcsDB.LogicalDelete(ref objConnectInfoWorkAcsWork);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �t�@�C������n���ď�񃏁[�N�N���X���f�V���A���C�Y����
                    connectInfoWork = objConnectInfoWorkAcsWork as ConnectInfoWork;
                }
                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iConnectInfoWorkAcsDB = null;

                //�ʐM�G���[��-1��߂�
                return -1;
            }
        }

        /// <summary>
        /// �����폜����
        /// </summary>
        /// <param name="connectInfoWork">�ڑ�����ݒ�}�X�^�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �ڑ�����ݒ�}�X�^�̕����폜���s���܂��B</br>
        /// <br>Programmer : �����M</br>
        /// <br>Date       : 2012/12/15</br>
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// <br></br>
        /// </remarks>
        public int Delete(ConnectInfoWork connectInfoWork)
        {
            try
            {
                byte[] parabyte = XmlByteSerializer.Serialize(connectInfoWork);

                // �����폜
                int status = this._iConnectInfoWorkAcsDB.Delete(parabyte);
                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iConnectInfoWorkAcsDB = null;

                //�ʐM�G���[��-1��߂�
                return -1;
            }
        }
        #endregion

        #region -- ������������� --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �ڑ�����ݒ�}�X�^�S�����������i�_���폜�܂ށj
        /// </summary>
        /// <param name="connectInfoWorkAcsList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �ڑ�����ݒ�}�X�^�̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
        /// <br>Programmer : �����M</br>
        /// <br>Date       : 2012/12/15</br>
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// <br></br>
        /// </remarks>
        public int SearchAll(out ArrayList connectInfoWorkAcsList, string enterpriseCode)
        {
            return SearchProc(out connectInfoWorkAcsList, enterpriseCode, SearchMode.Remote);
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �ڑ�����ݒ�}�X�^�S����������
        /// </summary>
        /// <param name="connectInfoWorkAcsList">�Ǎ����ʃR���N�V����</param>  
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="searchMode">�������[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �ڑ�����ݒ�}�X�^�̌����������s���܂��B</br>
        /// <br>Programmer : �����M</br>
        /// <br>Date       : 2012/12/15</br>
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// <br></br>
        /// </remarks>
        private int SearchProc(out ArrayList connectInfoWorkAcsList, string enterpriseCode, SearchMode searchMode)
        {
            try
            {
                // ���[�h���Z�b�g
                _isLocalDBRead = searchMode == SearchMode.Local ? true : false;

                ConnectInfoWork connectInfoWork = new ConnectInfoWork();

                connectInfoWork.EnterpriseCode = enterpriseCode;

                int status = 0;

                connectInfoWorkAcsList = new ArrayList();
                connectInfoWorkAcsList.Clear();

                ArrayList connectInfoWorkAcsWorkList = new ArrayList();
                connectInfoWorkAcsWorkList.Clear();

                // �����[�g�ɓǍ����ʗp
                object paraobj = connectInfoWork;
                object retobj = null;

                status = this._iConnectInfoWorkAcsDB.Search(out retobj, paraobj, 0, ConstantManagement.LogicalMode.GetData01);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    connectInfoWorkAcsWorkList = retobj as ArrayList;

                    foreach (ConnectInfoWork wkConnectInfoWork in connectInfoWorkAcsWorkList)
                    {
                        // �Ǎ�����
                        connectInfoWorkAcsList.Add(wkConnectInfoWork);
                    }
                    status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                }

                // STATUS ��ݒ�
                if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) &&
                    (connectInfoWorkAcsList.Count == 0))
                {
                    status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                }
                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iConnectInfoWorkAcsDB = null;
                // �Ǎ�����null���Z�b�g
                connectInfoWorkAcsList = null;

                //�ʐM�G���[��-1��߂�
                return -1;
            }
        }

        /// <summary>
        /// �ڑ�����ݒ�}�X�^��������
        /// </summary>
        /// <param name="connectInfoWork">�ڑ�����ݒ�N���X�I�u�W�F�N�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="SupplierCd">�d����R�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �ڑ�����ݒ�}�X�^�̌����������s���܂��B</br>
        /// <br>Programmer : �����M</br>
        /// <br>Date       : 2012/12/15</br>
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// <br></br>
        /// </remarks>
        public int Read(out ConnectInfoWork connectInfoWork, string enterpriseCode, int SupplierCd)
        {
            try
            {
                connectInfoWork = new ConnectInfoWork();

                connectInfoWork.EnterpriseCode = enterpriseCode;
                connectInfoWork.SupplierCd = SupplierCd;

                // XML�֕ϊ����A������̃o�C�i����
                byte[] parabyte = XmlByteSerializer.Serialize(connectInfoWork);

                // ���[�����M�Ǘ��t�B�[���h���̓ǂݍ���
                int status = this._iConnectInfoWorkAcsDB.Read(ref parabyte, 0);

                if (status == 0)
                {
                    // XML�̓ǂݍ���
                    connectInfoWork = (ConnectInfoWork)XmlByteSerializer.Deserialize(parabyte, typeof(ConnectInfoWork));
                }
                return status;
            }
            catch (Exception)
            {
                //�ʐM�G���[��-1��߂�
                connectInfoWork = null;
                //�I�t���C������null���Z�b�g
                this._iConnectInfoWorkAcsDB = null;
                return -1;
            }
        }

        /// <summary>
        /// �_���폜��������
        /// </summary>
        /// <param name="connectInfoWork">�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �������s���܂��B</br>
        /// <br>Programmer : �����M</br>
        /// <br>Date       : 2012/12/15</br>
        /// <br>�Ǘ��ԍ�   : 10805731-00</br>
        /// <br></br>
        /// </remarks>
        public int Revival(ref ConnectInfoWork connectInfoWork)
        {
            try
            {
                // XML�֕ϊ����A������̃o�C�i����
                object objConnectInfoWorkAcsWork = connectInfoWork;

                // ��������
                int status = this._iConnectInfoWorkAcsDB.RevivalLogicalDelete(ref objConnectInfoWorkAcsWork);


                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �t�@�C������n���ď�񃏁[�N�N���X���f�V���A���C�Y����
                    connectInfoWork = objConnectInfoWorkAcsWork as ConnectInfoWork;
                }
                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iConnectInfoWorkAcsDB = null;

                //�ʐM�G���[��-1��߂�
                return -1;
            }
        }
        #endregion -- ������������� --
    }
}

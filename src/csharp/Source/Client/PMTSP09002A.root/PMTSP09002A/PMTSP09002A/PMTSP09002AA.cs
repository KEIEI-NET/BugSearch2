//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : TSP�C�����C���Ή�
// �v���O�����T�v   : TSP�C�����C���Ή�
//----------------------------------------------------------------------------//
//                (c)Copyright  2020 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� : 11670305-00  �쐬�S�� : 3H ������
// �� �� �� : 2020/11/23  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using System.Reflection;
using System.Diagnostics;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// TSP�A�g�}�X�^�ݒ� �e�[�u���A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note            : TSP�A�g�}�X�^�ݒ� �e�[�u���A�N�Z�X�N���X�B</br>
    /// <br>Programmer      : 3H ������</br>
    /// <br>Date            : 2020/11/23</br>
    /// <br>�Ǘ��ԍ�        : 11670305-00</br>
    /// </remarks>
    public class TspCprtStAcs
    {
        #region Private Members
        /// <summary>TSP�A�g�}�X�^�ݒ菈�������[�g</summary>
        private ITspCprtStDB iTspCprtSt = null;
        #endregion

        #region Constructor

        /// <summary>
        /// TSP�A�g�}�X�^�ݒ�A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note            : TSP�A�g�}�X�^�ݒ�A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer      : 3H ������</br>
        /// <br>Date            : 2020/11/23</br>
        /// </remarks>
        public TspCprtStAcs()
        {
            try
            {
                // �����[�g�I�u�W�F�N�g�擾
                this.iTspCprtSt = MediationTspCprtStDB.GetTspCprtStDB();
            }
            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
                this.iTspCprtSt = null;
            }
        }

        #endregion

        #region Public Methods

        #region ��������(���W�b�N�폜�����܂܂Ȃ�)
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="tspCprtStWork">TSP�A�g�}�X�^�ݒ� �f�[�^�p�����[�^</param>
        /// <param name="tspCprtStWorkList">���ʃ��X�g</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note            : �����������s���܂��B</br>
        /// <br>Programmer      : 3H ������</br>
        /// <br>Date            : 2020/11/23</br>
        /// </remarks>
        public int Search(TspCprtStWork tspCprtStWork, out ArrayList tspCprtStWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            tspCprtStWorkList = new ArrayList();

            try
            {
                object tspCprtStWorkObj = tspCprtStWork;
                // ��������
                status = iTspCprtSt.Search(tspCprtStWork, out tspCprtStWorkObj, ConstantManagement.LogicalMode.GetData0);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    tspCprtStWorkList = (ArrayList)tspCprtStWorkObj;
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        #endregion

        #region �S��������(���W�b�N�폜�����܂�)
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="tspCprtStWork">TSP�A�g�}�X�^�ݒ� �f�[�^�p�����[�^</param>
        /// <param name="tspCprtStWorkList">���ʃ��X�g</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note            : �����������s���܂��B</br>
        /// <br>Programmer      : 3H ������</br>
        /// <br>Date            : 2020/11/23</br>
        /// </remarks>
        public int SearchAll(TspCprtStWork tspCprtStWork, out ArrayList tspCprtStWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            tspCprtStWorkList = new ArrayList();

            try
            {
                object tspCprtStWorkObj = tspCprtStWork;
                // ��������
                status = iTspCprtSt.Search(tspCprtStWork, out tspCprtStWorkObj, ConstantManagement.LogicalMode.GetData01);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    tspCprtStWorkList = (ArrayList)tspCprtStWorkObj;
                }
            }
            catch(Exception )
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        #endregion

        #region �ǉ��ƍX�V����
        /// <summary>
        /// �ǉ��ƍX�V����
        /// </summary>
        /// <param name="tspCprtStWork">TSP�A�g�}�X�^�ݒ� �f�[�^�p�����[�^</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note            : �ǉ��ƍX�V�������s���܂��B</br>
        /// <br>Programmer      : 3H ������</br>
        /// <br>Date            : 2020/11/23</br>
        /// </remarks>
        public int Write(ref TspCprtStWork tspCprtStWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                object tspCprtStWorkObj = tspCprtStWork;
                // �ǉ��X�V����
                status = iTspCprtSt.Write(ref tspCprtStWorkObj);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    tspCprtStWork = (TspCprtStWork)tspCprtStWorkObj;
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        #endregion

        #region ���S�폜����
        /// <summary>
        /// ���S�폜����
        /// </summary>
        /// <param name="tspCprtStWork">TSP�A�g�}�X�^�ݒ� �f�[�^�p�����[�^</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note            : ���S�폜�������s���܂��B</br>
        /// <br>Programmer      : 3H ������</br>
        /// <br>Date            : 2020/11/23</br>
        /// </remarks>
        public int Delete(TspCprtStWork tspCprtStWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                object tspCprtStWorkObj = tspCprtStWork;
                // ���S�폜����
                status = iTspCprtSt.Delete(tspCprtStWorkObj);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    tspCprtStWork = (TspCprtStWork)tspCprtStWorkObj;
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        #endregion

        #region ���W�b�N�폜����
        /// <summary>
        /// ���W�b�N�폜����
        /// </summary>
        /// <param name="tspCprtStWork">TSP�A�g�}�X�^�ݒ� �f�[�^�p�����[�^</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note            : ���W�b�N�폜�������s���܂��B</br>
        /// <br>Programmer      : 3H ������</br>
        /// <br>Date            : 2020/11/23</br>
        /// </remarks>
        public int LogicalDelete(ref TspCprtStWork tspCprtStWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                object tspCprtStWorkObj = tspCprtStWork;
                // �_���폜����
                status = iTspCprtSt.LogicalDelete(ref tspCprtStWorkObj);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    tspCprtStWork = (TspCprtStWork)tspCprtStWorkObj;
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }
        #endregion

        #region ��������
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="tspCprtStWork">TSP�A�g�}�X�^�ݒ� �f�[�^�p�����[�^</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note            : �����������s���܂��B</br>
        /// <br>Programmer      : 3H ������</br>
        /// <br>Date            : 2020/11/23</br>
        /// </remarks>
        public int Relive(ref TspCprtStWork tspCprtStWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                object tspCprtStWorkObj = tspCprtStWork;
                // ��������
                status = iTspCprtSt.Revival(ref tspCprtStWorkObj);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    tspCprtStWork = (TspCprtStWork)tspCprtStWorkObj;
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        #endregion
        #endregion

    }
}

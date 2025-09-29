using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Xml.Serialization;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ����ڕW�ݒ�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ����ڕW�ݒ�A�N�Z�X�N���X</br>
    /// <br>Programmer : 30414 �E �K�j</br>
    /// <br>Date       : 2008/10/08</br>
    /// <br>Update Note: 2010/12/20 ������</br>
    /// <br>             ��Q���ǑΉ��P�Q��</br>
    /// </remarks>
    public class SalesTargetAcs
    {
        #region �� Private Members

        private IEmpSalesTargetDB _iEmpSalesTargetDB;       // �]�ƈ��ʔ���ڕW�����[�g
        private ICustSalesTargetDB _iCustSalesTargetDB;     // ���Ӑ�ʔ���ڕW�����[�g
        private IGcdSalesTargetDB _iGcdSalesTargetDB;       // ���i�ʔ���ڕW�����[�g

        #endregion �� Private Members

        
        #region �� Constructor
        /// <summary>
        /// ����ڕW�ݒ�A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ����ڕW�ݒ�A�N�Z�X�N���X</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        public SalesTargetAcs()
        {
            try
            {
                // �����[�g�I�u�W�F�N�g�擾
                this._iEmpSalesTargetDB = (IEmpSalesTargetDB)MediationEmpSalesTargetDB.GetEmpSalesTargetDB();
                this._iCustSalesTargetDB = (ICustSalesTargetDB)MediationCustSalesTargetDB.GetCustSalesTargetDB();
                this._iGcdSalesTargetDB = (IGcdSalesTargetDB)MediationGcdSalesTargetDB.GetGcdSalesTargetDB();
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iEmpSalesTargetDB = null;
                this._iCustSalesTargetDB = null;
                this._iGcdSalesTargetDB = null;
            }
        }
        #endregion �� Constructor


        #region �� Public Methods

        #region �I�����C�����[�h�擾
        /// <summary>
        /// �I�����C�����[�h�擾����
        /// </summary>
        /// <returns>OnlineMode</returns>
        /// <remarks>
        /// <br>Note       : �I�����C�����[�h���擾���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if ((this._iEmpSalesTargetDB == null) || (this._iCustSalesTargetDB == null) || (this._iGcdSalesTargetDB == null))
            {
                return (int)ConstantManagement.OnlineMode.Offline;
            }
            else
            {
                return (int)ConstantManagement.OnlineMode.Online;
            }
        }
        #endregion �I�����C�����[�h�擾

        #region ��������
        /// <summary>
        /// ��������(�]�ƈ��ʔ���ڕW)
        /// </summary>
        /// <param name="empSalesTargetList">�]�ƈ��ʔ���ڕW���X�g</param>
        /// <param name="searchEmpSalesTargetPara">�]�ƈ��ʔ���ڕW��������</param>
        /// <param name="logicalMode">�_���폜�敪</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �]�ƈ��ʔ���ڕW�ݒ�}�X�^���������܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        public int Search(out List<EmpSalesTarget> empSalesTargetList, SearchEmpSalesTargetPara searchEmpSalesTargetPara, ConstantManagement.LogicalMode logicalMode)
        {
            empSalesTargetList = new List<EmpSalesTarget>();

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            try
            {
                // �N���X�����o�R�s�[����(E��D)
                SearchEmpSalesTargetParaWork paraWork = CopyToSearchEmpSalesTargetParaWorkFromSearchEmpSalesTargetPara(searchEmpSalesTargetPara);

                object paraObj = paraWork;
                object retObj;

                // ��������
                status = this._iEmpSalesTargetDB.Search(out retObj, paraObj, 0, logicalMode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �p�����[�^���n���ė��Ă��邩�m�F
                    ArrayList retList = retObj as ArrayList;
                    if (retList == null)
                    {
                        return ((int)ConstantManagement.DB_Status.ctDB_ERROR);
                    }

                    // �f�[�^�ϊ�
                    foreach (EmpSalesTargetWork empSalesTargetWork in retList)
                    {
                        // �N���X�����o�R�s�[����(D��E)
                        empSalesTargetList.Add(CopyToEmpSalesTargetFromEmpSalesTargetWork(empSalesTargetWork));
                    }
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return (status);
        }

        /// <summary>
        /// ��������(���Ӑ�ʔ���ڕW)
        /// </summary>
        /// <param name="custSalesTargetList">���Ӑ�ʔ���ڕW���X�g</param>
        /// <param name="searchCustSalesTargetPara">���Ӑ�ʔ���ڕW��������</param>
        /// <param name="logicalMode">�_���폜�敪</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�ʔ���ڕW�ݒ�}�X�^���������܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        public int Search(out List<CustSalesTarget> custSalesTargetList, SearchCustSalesTargetPara searchCustSalesTargetPara, ConstantManagement.LogicalMode logicalMode)
        {
            custSalesTargetList = new List<CustSalesTarget>();

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            try
            {
                // �N���X�����o�R�s�[����(E��D)
                SearchCustSalesTargetParaWork paraWork = CopyToSearchCustSalesTargetParaWorkFromSearchCustSalesTargetPara(searchCustSalesTargetPara);

                object paraObj = paraWork;
                object retObj;

                // ��������
                status = this._iCustSalesTargetDB.Search(out retObj, paraObj, 0, logicalMode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �p�����[�^���n���ė��Ă��邩�m�F
                    ArrayList retList = retObj as ArrayList;
                    if (retList == null)
                    {
                        return ((int)ConstantManagement.DB_Status.ctDB_ERROR);
                    }

                    // �f�[�^�ϊ�
                    foreach (CustSalesTargetWork custSalesTargetWork in retList)
                    {
                        // �N���X�����o�R�s�[����(D��E)
                        custSalesTargetList.Add(CopyToCustSalesTargetFromCustSalesTargetWork(custSalesTargetWork));
                    }
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return (status);
        }

        /// <summary>
        /// ��������(���i�ʔ���ڕW)
        /// </summary>
        /// <param name="gcdSalesTargetList">���i�ʔ���ڕW���X�g</param>
        /// <param name="searchGcdSalesTargetPara">���i�ʔ���ڕW��������</param>
        /// <param name="logicalMode">�_���폜�敪</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���i�ʔ���ڕW�ݒ�}�X�^���������܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        public int Search(out List<GcdSalesTarget> gcdSalesTargetList, SearchGcdSalesTargetPara searchGcdSalesTargetPara, ConstantManagement.LogicalMode logicalMode)
        {
            gcdSalesTargetList = new List<GcdSalesTarget>();

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            try
            {
                // �N���X�����o�R�s�[����(E��D)
                SearchGcdSalesTargetParaWork paraWork = CopyToSearchGcdSalesTargetParaWorkFromSearchGcdSalesTargetPara(searchGcdSalesTargetPara);

                object paraObj = paraWork;
                object retObj;

                // ��������
                status = this._iGcdSalesTargetDB.Search(out retObj, paraObj, 0, logicalMode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �p�����[�^���n���ė��Ă��邩�m�F
                    ArrayList retList = retObj as ArrayList;
                    if (retList == null)
                    {
                        return ((int)ConstantManagement.DB_Status.ctDB_ERROR);
                    }

                    // �f�[�^�ϊ�
                    foreach (GcdSalesTargetWork gcdSalesTargetWork in retList)
                    {
                        // �N���X�����o�R�s�[����(D��E)
                        gcdSalesTargetList.Add(CopyToGcdSalesTargetFromGcdSalesTargetWork(gcdSalesTargetWork));
                    }
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return (status);
        }
        #endregion ��������

        #region �X�V����
        /// <summary>
        /// �X�V����(�]�ƈ��ʔ���ڕW)
        /// </summary>
        /// <param name="empSalesTargetList">�]�ƈ��ʔ���ڕW���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �]�ƈ��ʔ���ڕW�ݒ�}�X�^���X�V���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        public int Write(ref List<EmpSalesTarget> empSalesTargetList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList paraList = new ArrayList();

                foreach (EmpSalesTarget empSalesTarget in empSalesTargetList)
                {
                    // �N���X�����o�R�s�[����(E��D)
                    paraList.Add(CopyToEmpSalesTargetWorkFromEmpSalesTarget(empSalesTarget));
                }

                object paraObj = paraList;

                // �X�V����
                status = this._iEmpSalesTargetDB.Write(ref paraObj);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �p�����[�^���n���ė��Ă��邩�m�F
                    ArrayList retList = paraObj as ArrayList;
                    if (retList == null)
                    {
                        return ((int)ConstantManagement.DB_Status.ctDB_ERROR);
                    }

                    // List������
                    empSalesTargetList.Clear();

                    // �f�[�^�ϊ�
                    foreach (EmpSalesTargetWork empSalesTargetWork in retList)
                    {
                        // �N���X�����o�R�s�[����(D��E)
                        empSalesTargetList.Add(CopyToEmpSalesTargetFromEmpSalesTargetWork(empSalesTargetWork));
                    }
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return (status);
        }

        // ---ADD 2010/12/20--------->>>>>
        /// <summary>
        /// �X�V����(�]�ƈ��ʔ���ڕW)
        /// </summary>
        /// <param name="empSalesTargetWriteList">�]�ƈ��ʔ���ڕW���X�g(write�p)</param>
        /// <param name="empSalesTargetDelList">�]�ƈ��ʔ���ڕW���X�g(delete�p)</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �]�ƈ��ʔ���ڕW�ݒ�}�X�^���X�V���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/12/20</br>
        /// </remarks>
        public int WriteProc(ref List<EmpSalesTarget> empSalesTargetWriteList, List<EmpSalesTarget> empSalesTargetDelList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList paraWriteList = new ArrayList();
                foreach (EmpSalesTarget empSalesTarget in empSalesTargetWriteList)
                {
                    // �N���X�����o�R�s�[����(E��D)
                    paraWriteList.Add(CopyToEmpSalesTargetWorkFromEmpSalesTarget(empSalesTarget));
                }
                object paraWriteObj = paraWriteList;

                EmpSalesTargetWork[] paraWorkArray = new EmpSalesTargetWork[empSalesTargetDelList.Count];
                for (int index = 0; index < empSalesTargetDelList.Count; index++)
                {
                    // �N���X�����o�R�s�[����(E��D)
                    paraWorkArray[index] = CopyToEmpSalesTargetWorkFromEmpSalesTarget(empSalesTargetDelList[index]);
                }
                // XML�֕ϊ����A������̃o�C�i����
                byte[] paraDeleteByte = XmlByteSerializer.Serialize(paraWorkArray);

                // �X�V����
                status = this._iEmpSalesTargetDB.WriteProc(ref paraWriteObj, paraDeleteByte);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �p�����[�^���n���ė��Ă��邩�m�F
                    ArrayList retList = paraWriteObj as ArrayList;
                    if (retList == null)
                    {
                        return ((int)ConstantManagement.DB_Status.ctDB_ERROR);
                    }

                    // List������
                    empSalesTargetWriteList.Clear();

                    // �f�[�^�ϊ�
                    foreach (EmpSalesTargetWork empSalesTargetWork in retList)
                    {
                        // �N���X�����o�R�s�[����(D��E)
                        empSalesTargetWriteList.Add(CopyToEmpSalesTargetFromEmpSalesTargetWork(empSalesTargetWork));
                    }
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return (status);
        }

        /// <summary>
        /// �X�V����(���Ӑ�ʔ���ڕW)
        /// </summary>
        /// <param name="custSalesTargetWriteList">���Ӑ�ʔ���ڕW���X�g(write�p)</param>
        /// <param name="custSalesTargetDelList">���Ӑ�ʔ���ڕW���X�g(delete�p)</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�ʔ���ڕW�ݒ�}�X�^���X�V���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/12/20</br>
        /// </remarks>
        public int WriteProc(ref List<CustSalesTarget> custSalesTargetWriteList, List<CustSalesTarget> custSalesTargetDelList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList paraWriteList = new ArrayList();
                foreach (CustSalesTarget custSalesTarget in custSalesTargetWriteList)
                {
                    // �N���X�����o�R�s�[����(E��D)
                    paraWriteList.Add(CopyToCustSalesTargetWorkFromCustSalesTarget(custSalesTarget));
                }
                object paraWriteObj = paraWriteList;

                CustSalesTargetWork[] paraWorkArray = new CustSalesTargetWork[custSalesTargetDelList.Count];
                for (int index = 0; index < custSalesTargetDelList.Count; index++)
                {
                    // �N���X�����o�R�s�[����(E��D)
                    paraWorkArray[index] = CopyToCustSalesTargetWorkFromCustSalesTarget(custSalesTargetDelList[index]);
                }
                // XML�֕ϊ����A������̃o�C�i����
                byte[] paraDeleteByte = XmlByteSerializer.Serialize(paraWorkArray);

                // �X�V����
                status = this._iCustSalesTargetDB.WriteProc(ref paraWriteObj, paraDeleteByte);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �p�����[�^���n���ė��Ă��邩�m�F
                    ArrayList retList = paraWriteObj as ArrayList;
                    if (retList == null)
                    {
                        return ((int)ConstantManagement.DB_Status.ctDB_ERROR);
                    }

                    // List������
                    custSalesTargetWriteList.Clear();

                    // �f�[�^�ϊ�
                    foreach (CustSalesTargetWork custSalesTargetWork in retList)
                    {
                        // �N���X�����o�R�s�[����(D��E)
                        custSalesTargetWriteList.Add(CopyToCustSalesTargetFromCustSalesTargetWork(custSalesTargetWork));
                    }
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return (status);
        }

        /// <summary>
        /// �X�V����(���i�ʔ���ڕW)
        /// </summary>
        /// <param name="gcdSalesTargetWriteList">���i�ʔ���ڕW���X�g(write�p)</param>
        /// <param name="gcdSalesTargetDelList">���i�ʔ���ڕW���X�g(delete�p)</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���i�ʔ���ڕW�ݒ�}�X�^���X�V���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2010/12/20</br>
        /// </remarks>
        public int WriteProc(ref List<GcdSalesTarget> gcdSalesTargetWriteList, List<GcdSalesTarget> gcdSalesTargetDelList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList paraWriteList = new ArrayList();
                foreach (GcdSalesTarget gcdSalesTarget in gcdSalesTargetWriteList)
                {
                    // �N���X�����o�R�s�[����(E��D)
                    paraWriteList.Add(CopyToGcdSalesTargetWorkFromGcdSalesTarget(gcdSalesTarget));
                }
                object paraWriteObj = paraWriteList;

                GcdSalesTargetWork[] paraWorkArray = new GcdSalesTargetWork[gcdSalesTargetDelList.Count];
                for (int index = 0; index < gcdSalesTargetDelList.Count; index++)
                {
                    // �N���X�����o�R�s�[����(E��D)
                    paraWorkArray[index] = CopyToGcdSalesTargetWorkFromGcdSalesTarget(gcdSalesTargetDelList[index]);
                }
                // XML�֕ϊ����A������̃o�C�i����
                byte[] paraDeleteByte = XmlByteSerializer.Serialize(paraWorkArray);

                // �X�V����
                status = this._iGcdSalesTargetDB.WriteProc(ref paraWriteObj, paraDeleteByte);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �p�����[�^���n���ė��Ă��邩�m�F
                    ArrayList retList = paraWriteObj as ArrayList;
                    if (retList == null)
                    {
                        return ((int)ConstantManagement.DB_Status.ctDB_ERROR);
                    }

                    // List������
                    gcdSalesTargetWriteList.Clear();

                    // �f�[�^�ϊ�
                    foreach (GcdSalesTargetWork gcdSalesTargetWork in retList)
                    {
                        // �N���X�����o�R�s�[����(D��E)
                        gcdSalesTargetWriteList.Add(CopyToGcdSalesTargetFromGcdSalesTargetWork(gcdSalesTargetWork));
                    }
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return (status);
        }
        // ---ADD 2010/12/20---------<<<<<

        /// <summary>
        /// �X�V����(���Ӑ�ʔ���ڕW)
        /// </summary>
        /// <param name="custSalesTargetList">���Ӑ�ʔ���ڕW���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�ʔ���ڕW�ݒ�}�X�^���X�V���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        public int Write(ref List<CustSalesTarget> custSalesTargetList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList paraList = new ArrayList();

                foreach (CustSalesTarget custSalesTarget in custSalesTargetList)
                {
                    // �N���X�����o�R�s�[����(E��D)
                    paraList.Add(CopyToCustSalesTargetWorkFromCustSalesTarget(custSalesTarget));
                }

                object paraObj = paraList;

                // �X�V����
                status = this._iCustSalesTargetDB.Write(ref paraObj);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �p�����[�^���n���ė��Ă��邩�m�F
                    ArrayList retList = paraObj as ArrayList;
                    if (retList == null)
                    {
                        return ((int)ConstantManagement.DB_Status.ctDB_ERROR);
                    }

                    // List������
                    custSalesTargetList.Clear();

                    // �f�[�^�ϊ�
                    foreach (CustSalesTargetWork custSalesTargetWork in retList)
                    {
                        // �N���X�����o�R�s�[����(D��E)
                        custSalesTargetList.Add(CopyToCustSalesTargetFromCustSalesTargetWork(custSalesTargetWork));
                    }
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return (status);
        }

        /// <summary>
        /// �X�V����(���i�ʔ���ڕW)
        /// </summary>
        /// <param name="gcdSalesTargetList">���i�ʔ���ڕW���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���i�ʔ���ڕW�ݒ�}�X�^���X�V���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        public int Write(ref List<GcdSalesTarget> gcdSalesTargetList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList paraList = new ArrayList();

                foreach (GcdSalesTarget gcdSalesTarget in gcdSalesTargetList)
                {
                    // �N���X�����o�R�s�[����(E��D)
                    paraList.Add(CopyToGcdSalesTargetWorkFromGcdSalesTarget(gcdSalesTarget));
                }

                object paraObj = paraList;

                // �X�V����
                status = this._iGcdSalesTargetDB.Write(ref paraObj);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �p�����[�^���n���ė��Ă��邩�m�F
                    ArrayList retList = paraObj as ArrayList;
                    if (retList == null)
                    {
                        return ((int)ConstantManagement.DB_Status.ctDB_ERROR);
                    }

                    // List������
                    gcdSalesTargetList.Clear();

                    // �f�[�^�ϊ�
                    foreach (GcdSalesTargetWork gcdSalesTargetWork in retList)
                    {
                        // �N���X�����o�R�s�[����(D��E)
                        gcdSalesTargetList.Add(CopyToGcdSalesTargetFromGcdSalesTargetWork(gcdSalesTargetWork));
                    }
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return (status);
        }
        #endregion �X�V����

        #region �_���폜����
        /// <summary>
        /// �_���폜����(�]�ƈ��ʔ���ڕW)
        /// </summary>
        /// <param name="empSalesTargetList">�]�ƈ��ʔ���ڕW���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �]�ƈ��ʔ���ڕW�ݒ�}�X�^��_���폜���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        public int LogicalDelete(ref List<EmpSalesTarget> empSalesTargetList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList paraList = new ArrayList();

                foreach (EmpSalesTarget empSalesTarget in empSalesTargetList)
                {
                    // �N���X�����o�R�s�[����(E��D)
                    paraList.Add(CopyToEmpSalesTargetWorkFromEmpSalesTarget(empSalesTarget));
                }

                object paraObj = paraList;

                // �_���폜����
                status = this._iEmpSalesTargetDB.LogicalDelete(ref paraObj);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �p�����[�^���n���ė��Ă��邩�m�F
                    ArrayList retList = paraObj as ArrayList;
                    if (retList == null)
                    {
                        return ((int)ConstantManagement.DB_Status.ctDB_ERROR);
                    }

                    // List������
                    empSalesTargetList.Clear();

                    // �f�[�^�ϊ�
                    foreach (EmpSalesTargetWork empSalesTargetWork in retList)
                    {
                        // �N���X�����o�R�s�[����(D��E)
                        empSalesTargetList.Add(CopyToEmpSalesTargetFromEmpSalesTargetWork(empSalesTargetWork));
                    }
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return (status);
        }

        /// <summary>
        /// �_���폜����(���Ӑ�ʔ���ڕW)
        /// </summary>
        /// <param name="custSalesTargetList">���Ӑ�ʔ���ڕW���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�ʔ���ڕW�ݒ�}�X�^��_���폜���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        public int LogicalDelete(ref List<CustSalesTarget> custSalesTargetList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList paraList = new ArrayList();

                foreach (CustSalesTarget custSalesTarget in custSalesTargetList)
                {
                    // �N���X�����o�R�s�[����(E��D)
                    paraList.Add(CopyToCustSalesTargetWorkFromCustSalesTarget(custSalesTarget));
                }

                object paraObj = paraList;

                // �_���폜����
                status = this._iCustSalesTargetDB.LogicalDelete(ref paraObj);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �p�����[�^���n���ė��Ă��邩�m�F
                    ArrayList retList = paraObj as ArrayList;
                    if (retList == null)
                    {
                        return ((int)ConstantManagement.DB_Status.ctDB_ERROR);
                    }

                    // List������
                    custSalesTargetList.Clear();

                    // �f�[�^�ϊ�
                    foreach (CustSalesTargetWork custSalesTargetWork in retList)
                    {
                        // �N���X�����o�R�s�[����(D��E)
                        custSalesTargetList.Add(CopyToCustSalesTargetFromCustSalesTargetWork(custSalesTargetWork));
                    }
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return (status);
        }

        /// <summary>
        /// �_���폜����(���i�ʔ���ڕW)
        /// </summary>
        /// <param name="gcdSalesTargetList">���i�ʔ���ڕW���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���i�ʔ���ڕW�ݒ�}�X�^��_���폜���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        public int LogicalDelete(ref List<GcdSalesTarget> gcdSalesTargetList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList paraList = new ArrayList();

                foreach (GcdSalesTarget gcdSalesTarget in gcdSalesTargetList)
                {
                    // �N���X�����o�R�s�[����(E��D)
                    paraList.Add(CopyToGcdSalesTargetWorkFromGcdSalesTarget(gcdSalesTarget));
                }

                object paraObj = paraList;

                // �_���폜����
                status = this._iGcdSalesTargetDB.LogicalDelete(ref paraObj);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �p�����[�^���n���ė��Ă��邩�m�F
                    ArrayList retList = paraObj as ArrayList;
                    if (retList == null)
                    {
                        return ((int)ConstantManagement.DB_Status.ctDB_ERROR);
                    }

                    // List������
                    gcdSalesTargetList.Clear();

                    // �f�[�^�ϊ�
                    foreach (GcdSalesTargetWork gcdSalesTargetWork in retList)
                    {
                        // �N���X�����o�R�s�[����(D��E)
                        gcdSalesTargetList.Add(CopyToGcdSalesTargetFromGcdSalesTargetWork(gcdSalesTargetWork));
                    }
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return (status);
        }
        #endregion �_���폜����

        #region �����폜����
        /// <summary>
        /// �����폜����(�]�ƈ��ʔ���ڕW)
        /// </summary>
        /// <param name="empSalesTargetList">�]�ƈ��ʔ���ڕW���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �]�ƈ��ʔ���ڕW�ݒ�}�X�^�𕨗��폜���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        public int Delete(List<EmpSalesTarget> empSalesTargetList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                EmpSalesTargetWork[] paraWorkArray = new EmpSalesTargetWork[empSalesTargetList.Count];

                for (int index = 0; index < empSalesTargetList.Count; index++)
                {
                    // �N���X�����o�R�s�[����(E��D)
                    paraWorkArray[index] = CopyToEmpSalesTargetWorkFromEmpSalesTarget(empSalesTargetList[index]);
                }

                // XML�֕ϊ����A������̃o�C�i����
                byte[] paraByte = XmlByteSerializer.Serialize(paraWorkArray);

                // �����폜����
                status = this._iEmpSalesTargetDB.Delete(paraByte);
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return (status);
        }

        /// <summary>
        /// �����폜����(���Ӑ�ʔ���ڕW)
        /// </summary>
        /// <param name="custSalesTargetList">���Ӑ�ʔ���ڕW���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�ʔ���ڕW�ݒ�}�X�^�𕨗��폜���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        public int Delete(List<CustSalesTarget> custSalesTargetList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                CustSalesTargetWork[] paraWorkArray = new CustSalesTargetWork[custSalesTargetList.Count];

                for (int index = 0; index < custSalesTargetList.Count; index++)
                {
                    // �N���X�����o�R�s�[����(E��D)
                    paraWorkArray[index] = CopyToCustSalesTargetWorkFromCustSalesTarget(custSalesTargetList[index]);
                }

                // XML�֕ϊ����A������̃o�C�i����
                byte[] paraByte = XmlByteSerializer.Serialize(paraWorkArray);

                // �����폜����
                status = this._iCustSalesTargetDB.Delete(paraByte);
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return (status);
        }

        /// <summary>
        /// �����폜����(���i�ʔ���ڕW)
        /// </summary>
        /// <param name="gcdSalesTargetList">���i�ʔ���ڕW���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���i�ʔ���ڕW�ݒ�}�X�^�𕨗��폜���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        public int Delete(List<GcdSalesTarget> gcdSalesTargetList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                GcdSalesTargetWork[] paraWorkArray = new GcdSalesTargetWork[gcdSalesTargetList.Count];

                for (int index = 0; index < gcdSalesTargetList.Count; index++)
                {
                    // �N���X�����o�R�s�[����(E��D)
                    paraWorkArray[index] = CopyToGcdSalesTargetWorkFromGcdSalesTarget(gcdSalesTargetList[index]);
                }

                // XML�֕ϊ����A������̃o�C�i����
                byte[] paraByte = XmlByteSerializer.Serialize(paraWorkArray);

                // �����폜����
                status = this._iGcdSalesTargetDB.Delete(paraByte);
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return (status);
        }
        #endregion �����폜����

        #region ��������
        /// <summary>
        /// ��������(�]�ƈ��ʔ���ڕW)
        /// </summary>
        /// <param name="empSalesTargetList">�]�ƈ��ʔ���ڕW���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �]�ƈ��ʔ���ڕW�ݒ�}�X�^�𕜊����܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        public int Revival(ref List<EmpSalesTarget> empSalesTargetList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList paraList = new ArrayList();

                foreach (EmpSalesTarget empSalesTarget in empSalesTargetList)
                {
                    // �N���X�����o�R�s�[����(E��D)
                    paraList.Add(CopyToEmpSalesTargetWorkFromEmpSalesTarget(empSalesTarget));
                }

                object paraObj = paraList;

                // �_���폜����
                status = this._iEmpSalesTargetDB.RevivalLogicalDelete(ref paraObj);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �p�����[�^���n���ė��Ă��邩�m�F
                    ArrayList retList = paraObj as ArrayList;
                    if (retList == null)
                    {
                        return ((int)ConstantManagement.DB_Status.ctDB_ERROR);
                    }

                    // List������
                    empSalesTargetList.Clear();

                    // �f�[�^�ϊ�
                    foreach (EmpSalesTargetWork empSalesTargetWork in retList)
                    {
                        // �N���X�����o�R�s�[����(D��E)
                        empSalesTargetList.Add(CopyToEmpSalesTargetFromEmpSalesTargetWork(empSalesTargetWork));
                    }
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return (status);
        }

        /// <summary>
        /// ��������(���Ӑ�ʔ���ڕW)
        /// </summary>
        /// <param name="custSalesTargetList">���Ӑ�ʔ���ڕW���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�ʔ���ڕW�ݒ�}�X�^�𕜊����܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        public int Revival(ref List<CustSalesTarget> custSalesTargetList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList paraList = new ArrayList();

                foreach (CustSalesTarget custSalesTarget in custSalesTargetList)
                {
                    // �N���X�����o�R�s�[����(E��D)
                    paraList.Add(CopyToCustSalesTargetWorkFromCustSalesTarget(custSalesTarget));
                }

                object paraObj = paraList;

                // �_���폜����
                status = this._iCustSalesTargetDB.RevivalLogicalDelete(ref paraObj);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �p�����[�^���n���ė��Ă��邩�m�F
                    ArrayList retList = paraObj as ArrayList;
                    if (retList == null)
                    {
                        return ((int)ConstantManagement.DB_Status.ctDB_ERROR);
                    }

                    // List������
                    custSalesTargetList.Clear();

                    // �f�[�^�ϊ�
                    foreach (CustSalesTargetWork custSalesTargetWork in retList)
                    {
                        // �N���X�����o�R�s�[����(D��E)
                        custSalesTargetList.Add(CopyToCustSalesTargetFromCustSalesTargetWork(custSalesTargetWork));
                    }
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return (status);
        }

        /// <summary>
        /// ��������(���i�ʔ���ڕW)
        /// </summary>
        /// <param name="gcdSalesTargetList">���i�ʔ���ڕW���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���i�ʔ���ڕW�ݒ�}�X�^�𕜊����܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        public int Revival(ref List<GcdSalesTarget> gcdSalesTargetList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                ArrayList paraList = new ArrayList();

                foreach (GcdSalesTarget gcdSalesTarget in gcdSalesTargetList)
                {
                    // �N���X�����o�R�s�[����(E��D)
                    paraList.Add(CopyToGcdSalesTargetWorkFromGcdSalesTarget(gcdSalesTarget));
                }

                object paraObj = paraList;

                // �_���폜����
                status = this._iGcdSalesTargetDB.RevivalLogicalDelete(ref paraObj);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �p�����[�^���n���ė��Ă��邩�m�F
                    ArrayList retList = paraObj as ArrayList;
                    if (retList == null)
                    {
                        return ((int)ConstantManagement.DB_Status.ctDB_ERROR);
                    }

                    // List������
                    gcdSalesTargetList.Clear();

                    // �f�[�^�ϊ�
                    foreach (GcdSalesTargetWork gcdSalesTargetWork in retList)
                    {
                        // �N���X�����o�R�s�[����(D��E)
                        gcdSalesTargetList.Add(CopyToGcdSalesTargetFromGcdSalesTargetWork(gcdSalesTargetWork));
                    }
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return (status);
        }
        #endregion ��������

        #endregion �� Public Methods


        #region �� Private Methods

        #region �N���X�����o�R�s�[����(E��D)
        /// <summary>
        /// �N���X�����o�R�s�[����(�]�ƈ��ʔ���ڕW)
        /// </summary>
        /// <param name="empSalesTarget">�]�ƈ��ʔ���ڕW�ݒ�}�X�^</param>
        /// <returns>�]�ƈ��ʔ���ڕW�ݒ�}�X�^���[�N</returns>
        /// <remarks>
        /// <br>Note       : �N���X�����o���R�s�[���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private EmpSalesTargetWork CopyToEmpSalesTargetWorkFromEmpSalesTarget(EmpSalesTarget empSalesTarget)
        {
            EmpSalesTargetWork empSalesTargetWork = new EmpSalesTargetWork();

            empSalesTargetWork.CreateDateTime = empSalesTarget.CreateDateTime;          // �쐬����
            empSalesTargetWork.UpdateDateTime = empSalesTarget.UpdateDateTime;          // �X�V����
            empSalesTargetWork.EnterpriseCode = empSalesTarget.EnterpriseCode;          // ��ƃR�[�h
            empSalesTargetWork.FileHeaderGuid = empSalesTarget.FileHeaderGuid;          // GUID
            empSalesTargetWork.UpdEmployeeCode = empSalesTarget.UpdEmployeeCode;        // �X�V�]�ƈ��R�[�h
            empSalesTargetWork.UpdAssemblyId1 = empSalesTarget.UpdAssemblyId1;          // �X�V�A�Z���u��ID1
            empSalesTargetWork.UpdAssemblyId2 = empSalesTarget.UpdAssemblyId2;          // �X�V�A�Z���u��ID2
            empSalesTargetWork.LogicalDeleteCode = empSalesTarget.LogicalDeleteCode;    // �_���폜�敪
            empSalesTargetWork.SectionCode = empSalesTarget.SectionCode;                // ���_�R�[�h
            empSalesTargetWork.TargetSetCd = empSalesTarget.TargetSetCd;                // �ڕW�ݒ�敪
            empSalesTargetWork.TargetContrastCd = empSalesTarget.TargetContrastCd;      // �ڕW�Δ�敪
            empSalesTargetWork.TargetDivideCode = empSalesTarget.TargetDivideCode;      // �ڕW�敪�R�[�h
            empSalesTargetWork.TargetDivideName = empSalesTarget.TargetDivideName;      // �ڕW�敪����
            empSalesTargetWork.EmployeeDivCd = empSalesTarget.EmployeeDivCd;            // �]�ƈ��敪
            empSalesTargetWork.SubSectionCode = empSalesTarget.SubSectionCode;          // ����R�[�h
            empSalesTargetWork.EmployeeCode = empSalesTarget.EmployeeCode;              // �]�ƈ��R�[�h
            empSalesTargetWork.ApplyStaDate = empSalesTarget.ApplyStaDate;              // �K�p�J�n��
            empSalesTargetWork.ApplyEndDate = empSalesTarget.ApplyEndDate;              // �K�p�I����
            empSalesTargetWork.SalesTargetMoney = empSalesTarget.SalesTargetMoney;      // ����ڕW���z
            empSalesTargetWork.SalesTargetProfit = empSalesTarget.SalesTargetProfit;    // ����ڕW�e���z
            empSalesTargetWork.SalesTargetCount = empSalesTarget.SalesTargetCount;      // ����ڕW����

            return empSalesTargetWork;
        }

        /// <summary>
        /// �N���X�����o�R�s�[����(���Ӑ�ʔ���ڕW)
        /// </summary>
        /// <param name="custSalesTarget">���Ӑ�ʔ���ڕW�ݒ�}�X�^</param>
        /// <returns>���Ӑ�ʔ���ڕW�ݒ�}�X�^���[�N</returns>
        /// <remarks>
        /// <br>Note       : �N���X�����o���R�s�[���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private CustSalesTargetWork CopyToCustSalesTargetWorkFromCustSalesTarget(CustSalesTarget custSalesTarget)
        {
            CustSalesTargetWork custSalesTargetWork = new CustSalesTargetWork();

            custSalesTargetWork.CreateDateTime = custSalesTarget.CreateDateTime;            // �쐬����
            custSalesTargetWork.UpdateDateTime = custSalesTarget.UpdateDateTime;            // �X�V����
            custSalesTargetWork.EnterpriseCode = custSalesTarget.EnterpriseCode;            // ��ƃR�[�h
            custSalesTargetWork.FileHeaderGuid = custSalesTarget.FileHeaderGuid;            // GUID
            custSalesTargetWork.UpdEmployeeCode = custSalesTarget.UpdEmployeeCode;          // �X�V�]�ƈ��R�[�h
            custSalesTargetWork.UpdAssemblyId1 = custSalesTarget.UpdAssemblyId1;            // �X�V�A�Z���u��ID1
            custSalesTargetWork.UpdAssemblyId2 = custSalesTarget.UpdAssemblyId2;            // �X�V�A�Z���u��ID2
            custSalesTargetWork.LogicalDeleteCode = custSalesTarget.LogicalDeleteCode;      // �_���폜�敪
            custSalesTargetWork.SectionCode = custSalesTarget.SectionCode;                  // ���_�R�[�h
            custSalesTargetWork.TargetSetCd = custSalesTarget.TargetSetCd;                  // �ڕW�ݒ�敪
            custSalesTargetWork.TargetContrastCd = custSalesTarget.TargetContrastCd;        // �ڕW�Δ�敪
            custSalesTargetWork.TargetDivideCode = custSalesTarget.TargetDivideCode;        // �ڕW�敪�R�[�h
            custSalesTargetWork.TargetDivideName = custSalesTarget.TargetDivideName;        // �ڕW�敪����
            custSalesTargetWork.BusinessTypeCode = custSalesTarget.BusinessTypeCode;        // �Ǝ�R�[�h
            custSalesTargetWork.SalesAreaCode = custSalesTarget.SalesAreaCode;              // �̔��G���A�R�[�h
            custSalesTargetWork.CustomerCode = custSalesTarget.CustomerCode;                // ���Ӑ�R�[�h
            custSalesTargetWork.ApplyStaDate = custSalesTarget.ApplyStaDate;                // �K�p�J�n��
            custSalesTargetWork.ApplyEndDate = custSalesTarget.ApplyEndDate;                // �K�p�I����
            custSalesTargetWork.SalesTargetMoney = custSalesTarget.SalesTargetMoney;        // ����ڕW���z
            custSalesTargetWork.SalesTargetProfit = custSalesTarget.SalesTargetProfit;      // ����ڕW�e���z
            custSalesTargetWork.SalesTargetCount = custSalesTarget.SalesTargetCount;        // ����ڕW����

            return custSalesTargetWork;
        }

        /// <summary>
        /// �N���X�����o�R�s�[����(���i�ʔ���ڕW)
        /// </summary>
        /// <param name="gcdSalesTarget">���i�ʔ���ڕW�ݒ�}�X�^</param>
        /// <returns>���i�ʔ���ڕW�ݒ�}�X�^���[�N</returns>
        /// <remarks>
        /// <br>Note       : �N���X�����o���R�s�[���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private GcdSalesTargetWork CopyToGcdSalesTargetWorkFromGcdSalesTarget(GcdSalesTarget gcdSalesTarget)
        {
            GcdSalesTargetWork gcdSalesTargetWork = new GcdSalesTargetWork();

            gcdSalesTargetWork.CreateDateTime = gcdSalesTarget.CreateDateTime;              // �쐬����
            gcdSalesTargetWork.UpdateDateTime = gcdSalesTarget.UpdateDateTime;              // �X�V����
            gcdSalesTargetWork.EnterpriseCode = gcdSalesTarget.EnterpriseCode;              // ��ƃR�[�h
            gcdSalesTargetWork.FileHeaderGuid = gcdSalesTarget.FileHeaderGuid;              // GUID
            gcdSalesTargetWork.UpdEmployeeCode = gcdSalesTarget.UpdEmployeeCode;            // �X�V�]�ƈ��R�[�h
            gcdSalesTargetWork.UpdAssemblyId1 = gcdSalesTarget.UpdAssemblyId1;              // �X�V�A�Z���u��ID1
            gcdSalesTargetWork.UpdAssemblyId2 = gcdSalesTarget.UpdAssemblyId2;              // �X�V�A�Z���u��ID2
            gcdSalesTargetWork.LogicalDeleteCode = gcdSalesTarget.LogicalDeleteCode;        // �_���폜�敪
            gcdSalesTargetWork.SectionCode = gcdSalesTarget.SectionCode;                    // ���_�R�[�h
            gcdSalesTargetWork.TargetSetCd = gcdSalesTarget.TargetSetCd;                    // �ڕW�ݒ�敪
            gcdSalesTargetWork.TargetContrastCd = gcdSalesTarget.TargetContrastCd;          // �ڕW�Δ�敪
            gcdSalesTargetWork.TargetDivideCode = gcdSalesTarget.TargetDivideCode;          // �ڕW�敪�R�[�h
            gcdSalesTargetWork.TargetDivideName = gcdSalesTarget.TargetDivideName;          // �ڕW�敪����
            gcdSalesTargetWork.GoodsMakerCd = gcdSalesTarget.GoodsMakerCd;                  // ���[�J�[�R�[�h
            gcdSalesTargetWork.GoodsNo = gcdSalesTarget.GoodsNo;                            // �i��
            gcdSalesTargetWork.BLGroupCode = gcdSalesTarget.BLGroupCode;                    // �O���[�v�R�[�h
            gcdSalesTargetWork.BLGoodsCode = gcdSalesTarget.BLGoodsCode;                    // BL�R�[�h
            gcdSalesTargetWork.SalesCode = gcdSalesTarget.SalesCode;                        // �̔��敪�R�[�h
            gcdSalesTargetWork.EnterpriseGanreCode = gcdSalesTarget.EnterpriseGanreCode;    // ���i�敪
            gcdSalesTargetWork.ApplyStaDate = gcdSalesTarget.ApplyStaDate;                  // �K�p�J�n��
            gcdSalesTargetWork.ApplyEndDate = gcdSalesTarget.ApplyEndDate;                  // �K�p�I����
            gcdSalesTargetWork.SalesTargetMoney = gcdSalesTarget.SalesTargetMoney;          // ����ڕW���z
            gcdSalesTargetWork.SalesTargetProfit = gcdSalesTarget.SalesTargetProfit;        // ����ڕW�e���z
            gcdSalesTargetWork.SalesTargetCount = gcdSalesTarget.SalesTargetCount;          // ����ڕW����

            return gcdSalesTargetWork;
        }

        /// <summary>
        /// �N���X�����o�R�s�[����(�]�ƈ��ʔ���ڕW��������)
        /// </summary>
        /// <param name="para">�]�ƈ��ʔ���ڕW��������</param>
        /// <returns>�]�ƈ��ʔ���ڕW�����������[�N</returns>
        /// <remarks>
        /// <br>Note       : �N���X�����o���R�s�[���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private SearchEmpSalesTargetParaWork CopyToSearchEmpSalesTargetParaWorkFromSearchEmpSalesTargetPara(SearchEmpSalesTargetPara para)
        {
            SearchEmpSalesTargetParaWork searchEmpSalesTargetParaWork = new SearchEmpSalesTargetParaWork();

            searchEmpSalesTargetParaWork.EnterpriseCode = para.EnterpriseCode;              // ��ƃR�[�h
            searchEmpSalesTargetParaWork.LogicalDeleteCode = para.LogicalDeleteCode;        // �_���폜�敪
            searchEmpSalesTargetParaWork.SelectSectCd = para.SelectSectCd;                  // �I�����_�R�[�h
            searchEmpSalesTargetParaWork.AllSecSelEpUnit = para.AllSecSelEpUnit;            // �S�БI��
            searchEmpSalesTargetParaWork.AllSecSelSecUnit = para.AllSecSelSecUnit;          // �S���_���R�[�h�o��
            searchEmpSalesTargetParaWork.TargetSetCd = para.TargetSetCd;                    // �ڕW�ݒ�敪
            searchEmpSalesTargetParaWork.TargetContrastCd = para.TargetContrastCd;          // �ڕW�Δ�敪
            searchEmpSalesTargetParaWork.TargetDivideCode = para.TargetDivideCode;          // �ڕW�敪�R�[�h
            searchEmpSalesTargetParaWork.TargetDivideName = para.TargetDivideName;          // �ڕW�敪����
            searchEmpSalesTargetParaWork.StartApplyStaDate = para.StartApplyStaDate;        // �K�p�J�n��(�J�n)
            searchEmpSalesTargetParaWork.EndApplyStaDate = para.EndApplyStaDate;            // �K�p�J�n��(�I��)
            searchEmpSalesTargetParaWork.StartApplyEndDate = para.StartApplyEndDate;        // �K�p�I����(�J�n)
            searchEmpSalesTargetParaWork.EndApplyEndDate = para.EndApplyEndDate;            // �K�p�I����(�I��)
            searchEmpSalesTargetParaWork.EmployeeCode = para.EmployeeCode;                  // �]�ƈ��R�[�h
            searchEmpSalesTargetParaWork.EmployeeDivCd = para.EmployeeDivCd;                // �]�ƈ��敪
            searchEmpSalesTargetParaWork.SubSectionCode = para.SubSectionCode;              // ����R�[�h

            return searchEmpSalesTargetParaWork;
        }

        /// <summary>
        /// �N���X�����o�R�s�[����(���Ӑ�ʔ���ڕW��������)
        /// </summary>
        /// <param name="para">���Ӑ�ʔ���ڕW��������</param>
        /// <returns>���Ӑ�ʔ���ڕW�����������[�N</returns>
        /// <remarks>
        /// <br>Note       : �N���X�����o���R�s�[���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private SearchCustSalesTargetParaWork CopyToSearchCustSalesTargetParaWorkFromSearchCustSalesTargetPara(SearchCustSalesTargetPara para)
        {
            SearchCustSalesTargetParaWork searchCustSalesTargetParaWork = new SearchCustSalesTargetParaWork();

            searchCustSalesTargetParaWork.EnterpriseCode = para.EnterpriseCode;             // ��ƃR�[�h
            searchCustSalesTargetParaWork.LogicalDeleteCode = para.LogicalDeleteCode;       // �_���폜�敪
            searchCustSalesTargetParaWork.SelectSectCd = para.SelectSectCd;                 // �I�����_�R�[�h
            searchCustSalesTargetParaWork.AllSecSelEpUnit = para.AllSecSelEpUnit;           // �S�БI��
            searchCustSalesTargetParaWork.AllSecSelSecUnit = para.AllSecSelSecUnit;         // �S���_���R�[�h�o��
            searchCustSalesTargetParaWork.TargetSetCd = para.TargetSetCd;                   // �ڕW�ݒ�敪
            searchCustSalesTargetParaWork.TargetContrastCd = para.TargetContrastCd;         // �ڕW�Δ�敪
            searchCustSalesTargetParaWork.TargetDivideCode = para.TargetDivideCode;         // �ڕW�敪�R�[�h
            searchCustSalesTargetParaWork.TargetDivideName = para.TargetDivideName;         // �ڕW�敪����
            searchCustSalesTargetParaWork.StartApplyStaDate = para.StartApplyStaDate;       // �K�p�J�n��(�J�n)
            searchCustSalesTargetParaWork.EndApplyStaDate = para.EndApplyStaDate;           // �K�p�J�n��(�I��)
            searchCustSalesTargetParaWork.StartApplyEndDate = para.StartApplyEndDate;       // �K�p�I����(�J�n)
            searchCustSalesTargetParaWork.EndApplyEndDate = para.EndApplyEndDate;           // �K�p�I����(�I��)
            searchCustSalesTargetParaWork.CustomerCode = para.CustomerCode;                 // ���Ӑ�R�[�h
            searchCustSalesTargetParaWork.BusinessTypeCode = para.BusinessTypeCode;         // �Ǝ�R�[�h
            searchCustSalesTargetParaWork.SalesAreaCode = para.SalesAreaCode;               // �n��R�[�h

            return searchCustSalesTargetParaWork;
        }

        /// <summary>
        /// �N���X�����o�R�s�[����(���i�ʔ���ڕW��������)
        /// </summary>
        /// <param name="para">���i�ʔ���ڕW��������</param>
        /// <returns>���i�ʔ���ڕW�����������[�N</returns>
        /// <remarks>
        /// <br>Note       : �N���X�����o���R�s�[���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private SearchGcdSalesTargetParaWork CopyToSearchGcdSalesTargetParaWorkFromSearchGcdSalesTargetPara(SearchGcdSalesTargetPara para)
        {
            SearchGcdSalesTargetParaWork searchGcdSalesTargetParaWork = new SearchGcdSalesTargetParaWork();

            searchGcdSalesTargetParaWork.EnterpriseCode = para.EnterpriseCode;              // ��ƃR�[�h
            searchGcdSalesTargetParaWork.LogicalDeleteCode = para.LogicalDeleteCode;        // �_���폜�敪
            searchGcdSalesTargetParaWork.SelectSectCd = para.SelectSectCd;                  // �I�����_�R�[�h
            searchGcdSalesTargetParaWork.AllSecSelEpUnit = para.AllSecSelEpUnit;            // �S�БI��
            searchGcdSalesTargetParaWork.AllSecSelSecUnit = para.AllSecSelSecUnit;          // �S���_���R�[�h�o��
            searchGcdSalesTargetParaWork.TargetSetCd = para.TargetSetCd;                    // �ڕW�ݒ�敪
            searchGcdSalesTargetParaWork.TargetContrastCd = para.TargetContrastCd;          // �ڕW�Δ�敪
            searchGcdSalesTargetParaWork.TargetDivideCode = para.TargetDivideCode;          // �ڕW�敪�R�[�h
            searchGcdSalesTargetParaWork.TargetDivideName = para.TargetDivideName;          // �ڕW�敪����
            searchGcdSalesTargetParaWork.StartApplyStaDate = para.StartApplyStaDate;        // �K�p�J�n��(�J�n)
            searchGcdSalesTargetParaWork.EndApplyStaDate = para.EndApplyStaDate;            // �K�p�J�n��(�I��)
            searchGcdSalesTargetParaWork.StartApplyEndDate = para.StartApplyEndDate;        // �K�p�I����(�J�n)
            searchGcdSalesTargetParaWork.EndApplyEndDate = para.EndApplyEndDate;            // �K�p�I����(�I��)
            searchGcdSalesTargetParaWork.BLGoodsCode = para.BLGoodsCode;                    // BL�R�[�h
            searchGcdSalesTargetParaWork.BLGroupCode = para.BLGroupCode;                    // �O���[�v�R�[�h
            searchGcdSalesTargetParaWork.GoodsMakerCd = para.GoodsMakerCd;                  // ���[�J�[�R�[�h
            searchGcdSalesTargetParaWork.GoodsNo = para.GoodsNo;                            // �i��
            searchGcdSalesTargetParaWork.EnterpriseGanreCode = para.EnterpriseGanreCode;    // ���Е��ރR�[�h
            searchGcdSalesTargetParaWork.SalesCode = para.SalesCode;                        // �̔��敪�R�[�h

            return searchGcdSalesTargetParaWork;
        }
        #endregion �N���X�����o�R�s�[����(E��D)

        #region �N���X�����o�R�s�[����(D��E)
        /// <summary>
        /// �N���X�����o�R�s�[����(�]�ƈ��ʔ���ڕW)
        /// </summary>
        /// <param name="empSalesTargetWork">�]�ƈ��ʔ���ڕW�ݒ�}�X�^���[�N</param>
        /// <returns>�]�ƈ��ʔ���ڕW�ݒ�}�X�^</returns>
        /// <remarks>
        /// <br>Note       : �N���X�����o���R�s�[���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private EmpSalesTarget CopyToEmpSalesTargetFromEmpSalesTargetWork(EmpSalesTargetWork empSalesTargetWork)
        {
            EmpSalesTarget empSalesTarget = new EmpSalesTarget();

            empSalesTarget.CreateDateTime = empSalesTargetWork.CreateDateTime;          // �쐬����
            empSalesTarget.UpdateDateTime = empSalesTargetWork.UpdateDateTime;          // �X�V����
            empSalesTarget.EnterpriseCode = empSalesTargetWork.EnterpriseCode;          // ��ƃR�[�h
            empSalesTarget.FileHeaderGuid = empSalesTargetWork.FileHeaderGuid;          // GUID
            empSalesTarget.UpdEmployeeCode = empSalesTargetWork.UpdEmployeeCode;        // �X�V�]�ƈ��R�[�h
            empSalesTarget.UpdAssemblyId1 = empSalesTargetWork.UpdAssemblyId1;          // �X�V�A�Z���u��ID1
            empSalesTarget.UpdAssemblyId2 = empSalesTargetWork.UpdAssemblyId2;          // �X�V�A�Z���u��ID2
            empSalesTarget.LogicalDeleteCode = empSalesTargetWork.LogicalDeleteCode;    // �_���폜�敪
            empSalesTarget.SectionCode = empSalesTargetWork.SectionCode;                // ���_�R�[�h
            empSalesTarget.TargetSetCd = empSalesTargetWork.TargetSetCd;                // �ڕW�ݒ�敪
            empSalesTarget.TargetContrastCd = empSalesTargetWork.TargetContrastCd;      // �ڕW�Δ�敪
            empSalesTarget.TargetDivideCode = empSalesTargetWork.TargetDivideCode;      // �ڕW�敪�R�[�h
            empSalesTarget.TargetDivideName = empSalesTargetWork.TargetDivideName;      // �ڕW�敪����
            empSalesTarget.EmployeeDivCd = empSalesTargetWork.EmployeeDivCd;            // �]�ƈ��敪
            empSalesTarget.SubSectionCode = empSalesTargetWork.SubSectionCode;          // ����R�[�h
            empSalesTarget.EmployeeCode = empSalesTargetWork.EmployeeCode;              // �]�ƈ��R�[�h
            empSalesTarget.ApplyStaDate = empSalesTargetWork.ApplyStaDate;              // �K�p�J�n��
            empSalesTarget.ApplyEndDate = empSalesTargetWork.ApplyEndDate;              // �K�p�I����
            empSalesTarget.SalesTargetMoney = empSalesTargetWork.SalesTargetMoney;      // ����ڕW���z
            empSalesTarget.SalesTargetProfit = empSalesTargetWork.SalesTargetProfit;    // ����ڕW�e���z
            empSalesTarget.SalesTargetCount = empSalesTargetWork.SalesTargetCount;      // ����ڕW����

            return empSalesTarget;
        }

        /// <summary>
        /// �N���X�����o�R�s�[����(���Ӑ�ʔ���ڕW)
        /// </summary>
        /// <param name="custSalesTargetWork">���Ӑ�ʔ���ڕW�ݒ�}�X�^���[�N</param>
        /// <returns>���Ӑ�ʔ���ڕW�ݒ�}�X�^</returns>
        /// <remarks>
        /// <br>Note       : �N���X�����o���R�s�[���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private CustSalesTarget CopyToCustSalesTargetFromCustSalesTargetWork(CustSalesTargetWork custSalesTargetWork)
        {
            CustSalesTarget custSalesTarget = new CustSalesTarget();

            custSalesTarget.CreateDateTime = custSalesTargetWork.CreateDateTime;            // �쐬����
            custSalesTarget.UpdateDateTime = custSalesTargetWork.UpdateDateTime;            // �X�V����
            custSalesTarget.EnterpriseCode = custSalesTargetWork.EnterpriseCode;            // ��ƃR�[�h
            custSalesTarget.FileHeaderGuid = custSalesTargetWork.FileHeaderGuid;            // GUID
            custSalesTarget.UpdEmployeeCode = custSalesTargetWork.UpdEmployeeCode;          // �X�V�]�ƈ��R�[�h
            custSalesTarget.UpdAssemblyId1 = custSalesTargetWork.UpdAssemblyId1;            // �X�V�A�Z���u��ID1
            custSalesTarget.UpdAssemblyId2 = custSalesTargetWork.UpdAssemblyId2;            // �X�V�A�Z���u��ID2
            custSalesTarget.LogicalDeleteCode = custSalesTargetWork.LogicalDeleteCode;      // �_���폜�敪
            custSalesTarget.SectionCode = custSalesTargetWork.SectionCode;                  // ���_�R�[�h
            custSalesTarget.TargetSetCd = custSalesTargetWork.TargetSetCd;                  // �ڕW�ݒ�敪
            custSalesTarget.TargetContrastCd = custSalesTargetWork.TargetContrastCd;        // �ڕW�Δ�敪
            custSalesTarget.TargetDivideCode = custSalesTargetWork.TargetDivideCode;        // �ڕW�敪�R�[�h
            custSalesTarget.TargetDivideName = custSalesTargetWork.TargetDivideName;        // �ڕW�敪����
            custSalesTarget.BusinessTypeCode = custSalesTargetWork.BusinessTypeCode;        // �Ǝ�R�[�h
            custSalesTarget.SalesAreaCode = custSalesTargetWork.SalesAreaCode;              // �̔��G���A�R�[�h
            custSalesTarget.CustomerCode = custSalesTargetWork.CustomerCode;                // ���Ӑ�R�[�h
            custSalesTarget.ApplyStaDate = custSalesTargetWork.ApplyStaDate;                // �K�p�J�n��
            custSalesTarget.ApplyEndDate = custSalesTargetWork.ApplyEndDate;                // �K�p�I����
            custSalesTarget.SalesTargetMoney = custSalesTargetWork.SalesTargetMoney;        // ����ڕW���z
            custSalesTarget.SalesTargetProfit = custSalesTargetWork.SalesTargetProfit;      // ����ڕW�e���z
            custSalesTarget.SalesTargetCount = custSalesTargetWork.SalesTargetCount;        // ����ڕW����

            return custSalesTarget;
        }

        /// <summary>
        /// �N���X�����o�R�s�[����(���i�ʔ���ڕW)
        /// </summary>
        /// <param name="gcdSalesTargetWork">���i�ʔ���ڕW�ݒ�}�X�^���[�N</param>
        /// <returns>���i�ʔ���ڕW�ݒ�}�X�^</returns>
        /// <remarks>
        /// <br>Note       : �N���X�����o���R�s�[���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/10/08</br>
        /// </remarks>
        private GcdSalesTarget CopyToGcdSalesTargetFromGcdSalesTargetWork(GcdSalesTargetWork gcdSalesTargetWork)
        {
            GcdSalesTarget gcdSalesTarget = new GcdSalesTarget();

            gcdSalesTarget.CreateDateTime = gcdSalesTargetWork.CreateDateTime;              // �쐬����
            gcdSalesTarget.UpdateDateTime = gcdSalesTargetWork.UpdateDateTime;              // �X�V����
            gcdSalesTarget.EnterpriseCode = gcdSalesTargetWork.EnterpriseCode;              // ��ƃR�[�h
            gcdSalesTarget.FileHeaderGuid = gcdSalesTargetWork.FileHeaderGuid;              // GUID
            gcdSalesTarget.UpdEmployeeCode = gcdSalesTargetWork.UpdEmployeeCode;            // �X�V�]�ƈ��R�[�h
            gcdSalesTarget.UpdAssemblyId1 = gcdSalesTargetWork.UpdAssemblyId1;              // �X�V�A�Z���u��ID1
            gcdSalesTarget.UpdAssemblyId2 = gcdSalesTargetWork.UpdAssemblyId2;              // �X�V�A�Z���u��ID2
            gcdSalesTarget.LogicalDeleteCode = gcdSalesTargetWork.LogicalDeleteCode;        // �_���폜�敪
            gcdSalesTarget.SectionCode = gcdSalesTargetWork.SectionCode;                    // ���_�R�[�h
            gcdSalesTarget.TargetSetCd = gcdSalesTargetWork.TargetSetCd;                    // �ڕW�ݒ�敪
            gcdSalesTarget.TargetContrastCd = gcdSalesTargetWork.TargetContrastCd;          // �ڕW�Δ�敪
            gcdSalesTarget.TargetDivideCode = gcdSalesTargetWork.TargetDivideCode;          // �ڕW�敪�R�[�h
            gcdSalesTarget.TargetDivideName = gcdSalesTargetWork.TargetDivideName;          // �ڕW�敪����
            gcdSalesTarget.GoodsMakerCd = gcdSalesTargetWork.GoodsMakerCd;                  // ���[�J�[�R�[�h
            gcdSalesTarget.GoodsNo = gcdSalesTargetWork.GoodsNo;                            // �i��
            gcdSalesTarget.BLGroupCode = gcdSalesTargetWork.BLGroupCode;                    // �O���[�v�R�[�h
            gcdSalesTarget.BLGoodsCode = gcdSalesTargetWork.BLGoodsCode;                    // BL�R�[�h
            gcdSalesTarget.SalesCode = gcdSalesTargetWork.SalesCode;                        // �̔��敪�R�[�h
            gcdSalesTarget.EnterpriseGanreCode = gcdSalesTargetWork.EnterpriseGanreCode;    // ���i�敪
            gcdSalesTarget.ApplyStaDate = gcdSalesTargetWork.ApplyStaDate;                  // �K�p�J�n��
            gcdSalesTarget.ApplyEndDate = gcdSalesTargetWork.ApplyEndDate;                  // �K�p�I����
            gcdSalesTarget.SalesTargetMoney = gcdSalesTargetWork.SalesTargetMoney;          // ����ڕW���z
            gcdSalesTarget.SalesTargetProfit = gcdSalesTargetWork.SalesTargetProfit;        // ����ڕW�e���z
            gcdSalesTarget.SalesTargetCount = gcdSalesTargetWork.SalesTargetCount;          // ����ڕW����

            return gcdSalesTarget;
        }
        #endregion �N���X�����o�R�s�[����(D��E)

        #endregion �� Private Methods
    }
}

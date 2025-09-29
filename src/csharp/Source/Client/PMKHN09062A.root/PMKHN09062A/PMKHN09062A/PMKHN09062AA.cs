using System;
using System.Text;
using System.Data;
using System.Collections;
using System.Collections.Generic;

using Broadleaf.Windows.Forms;

using Broadleaf.Xml.Serialization;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// BL�O���[�v�}�X�^�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: BL�O���[�v�}�X�^�̃A�N�Z�X������s���܂��B
    ///					  IGeneralGuideData���������Ă��܂��B</br>
    /// <br>Programmer	: 30414 �E�@�K�j</br>
    /// <br>Date		: 2008/06/11</br>
    /// </remarks>
    public class BLGroupUAcs : IGeneralGuideData
    {
        #region Constants

        //�f�[�^�敪
        private const int DIVISION_USR = 0;
        private const int DIVISION_OFR = 1;
        private const string DIVISIONNAME_USR = "���[�U�[�f�[�^";
        private const string DIVISIONNAME_OFR = "�񋟃f�[�^";

        #endregion Constants

        #region Private Members

        /// <summary>�����[�g�I�u�W�F�N�g�i�[�o�b�t�@</summary>
        IBLGroupUDB _iBLGroupUDB = null;
        //IBlGroupDB _iBLGroupDB = null;

        // �L���b�V���p�n�b�V���e�[�u��
        private static Hashtable _bLGroupUTable = null;

        #endregion Private Members

        # region Constructor

        /// <summary>
        /// BL�O���[�v�e�[�u���A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : BL�O���[�v�e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/06/11</br>
        /// </remarks>
        public BLGroupUAcs()
        {
            _bLGroupUTable = null;

            try
            {
                // �����[�g�I�u�W�F�N�g�擾
                this._iBLGroupUDB = (IBLGroupUDB)MediationBLGroupUDB.GetBLGroupUDB();
                //this._iBLGroupDB = (IBlGroupDB)MediationBLGroupDB.GetBLGroupDB();

            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iBLGroupUDB = null;
                //this._iBLGroupDB = null;
            }
        }

        # endregion

        #region Public Methods

        /// <summary>
        /// �I�����C�����[�h�擾����
        /// </summary>
        /// <returns>OnlineMode</returns>
        /// <remarks>
        /// <br>Note       : �I�����C�����[�h���擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/06/11</br>
        /// </remarks>
        public int GetOnlineMode()
        {
            //if ((this._iBLGroupUDB == null) || (this._iBLGroupDB == null))
            if (this._iBLGroupUDB == null)
            {
                return (int)ConstantManagement.OnlineMode.Offline;
            }
            else
            {
                return (int)ConstantManagement.OnlineMode.Online;
            }
        }




        /// <summary>
        /// BL�O���[�v�R�[�h�S���ǂݍ��ݏ���(�_���폜�܂�)
        /// </summary>
        /// <param name="retList">�Q�ƌ��ʃ��X�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : BL�O���[�v�R�[�h����ǂݍ��݂܂��B<br/>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/06/11</br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode)
        {
            int status = 0;

            retList = new ArrayList();
            retList.Clear();

            _bLGroupUTable = new Hashtable();

            // ���[�U�[�f�[�^
            status = SearchBLGroupUser(ref retList, enterpriseCode, 0);

            // �񋟃f�[�^
            //status = SearchBLGroupOffer(ref retList, 0);

            return status;
        }

        /// <summary>
        /// �}�X�^���������iDataSet�p�j
        /// </summary>
        /// <param name="ds">�擾���ʊi�[�pDataSet</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note        : �擾���ʂ�DataSet�ŕԂ��܂��B</br>
        /// <br>Programmer  : 30414 �E�@�K�j</br>
        /// <br>Date	    : 2008/06/11</br>
        /// </remarks>
        public int Search(ref DataSet dataSet, string enterpriseCode)
        {
            ArrayList retList = new ArrayList();

            int status = 0;

            // �}�X�^�T�[�`
            status = SearchAll(out retList, enterpriseCode);
            if (status != 0)
            {
                return status;
            }

            ArrayList wkList = retList.Clone() as ArrayList;
            SortedList wkSort = new SortedList();

            // --- [�S��] --- //
            // ���̂܂ܑS���Ԃ�
            foreach (BLGroupU bLGroupU in wkList)
            {
                if (bLGroupU.LogicalDeleteCode == 0)
                {
                    wkSort.Add(bLGroupU.BLGroupCode, bLGroupU);
                }
            }

            BLGroupU[] aryBLGroupU = new BLGroupU[wkSort.Count];

            // �f�[�^�����ɖ߂�
            for (int i = 0; i < wkSort.Count; i++)
            {
                aryBLGroupU[i] = (BLGroupU)wkSort.GetByIndex(i);
            }

            byte[] retbyte = XmlByteSerializer.Serialize(aryBLGroupU);
            XmlByteSerializer.ReadXml(ref dataSet, retbyte);

            return status;
        }

        /// <summary>
        /// BL�O���[�v�f�[�^��������
        /// </summary>
        /// <param name="bLGroupU">BL�O���[�v�I�u�W�F�N�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="bLGroupCode">BL�O���[�v�R�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���i�����ރf�[�^���������܂��B<br/>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/06/11</br>
        /// </remarks>
        public int Search(out BLGroupU bLGroupU, string enterpriseCode, int bLGroupCode)
        {
            int status;
            bLGroupU = new BLGroupU();
            _bLGroupUTable = new Hashtable();
            ArrayList retList = new ArrayList();

            // ���[�U�[�f�[�^
            status = SearchBLGroupUser(ref retList, enterpriseCode, bLGroupCode);

            // �񋟃f�[�^
            //status = SearchBLGroupOffer(ref retList, bLGroupCode);

            if ((retList == null) || (retList.Count == 0))
            {
                return 9;
            }
            else
            {
                bLGroupU = (BLGroupU)retList[0];
                return 0;
            }
        }

        /// <summary>
        /// BL�O���[�v�}�X�^�o�^�E�X�V����
        /// </summary>
        /// <param name="bLGroupU">BL�O���[�v�}�X�^�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : BL�O���[�v�}�X�^���̓o�^�E�X�V���s���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/06/11</br>
        /// </remarks>
        public int Write(ref BLGroupU bLGroupU)
        {
            // ------------------------------------------------------
            // �o�^�̓��[�U�[�o�^���������肦�Ȃ�
            // ------------------------------------------------------

            int status = 0;

            try
            {
                // �N���X�����o�[�R�s�[����(�d�N���X���c�N���X(���[�U�[))
                BLGroupUWork bLGroupUWork = CopyToBLGroupUWorkFromBLGroupU(bLGroupU);
                ArrayList paraList = new ArrayList();
                paraList.Add(bLGroupUWork);

                object paraobj = paraList;

                // BL�O���[�v�}�X�^��������
                status = this._iBLGroupUDB.Write(ref paraobj);
                if (status == 0)
                {
                    ArrayList retList = new ArrayList();
                    retList = (ArrayList)paraobj;

                    bLGroupUWork = (BLGroupUWork)retList[0];

                    // �N���X�����o�[�R�s�[����(�c�N���X(���[�U�[)���d�N���X)
                    bLGroupU = CopyToBLGroupUFromBLGroupUWork(bLGroupUWork);
                }
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iBLGroupUDB = null;

                //�ʐM�G���[��-1��߂�
                status = -1;
            }

            return status;
        }

        /// <summary>
        /// BL�O���[�v�}�X�^�����폜����
        /// </summary>
        /// <param name="bLGroupU">BL�O���[�v�}�X�^�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : BL�O���[�v�}�X�^�̕����폜���s���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/06/11</br>
        /// </remarks>
        public int Delete(BLGroupU bLGroupU)
        {
            // ------------------------------------------------------
            // �����폜�̓��[�U�[�o�^���������肦�Ȃ�
            // ------------------------------------------------------

            int status = 0;

            try
            {
                // �N���X�����o�[�R�s�[����(�d�N���X���c�N���X(���[�U�[))
                BLGroupUWork bLGroupUWork = CopyToBLGroupUWorkFromBLGroupU(bLGroupU);
                ArrayList paraList = new ArrayList();
                paraList.Add(bLGroupUWork);

                object paraObj = paraList;

                // BL�O���[�v�}�X�^�����폜
                status = this._iBLGroupUDB.Delete(paraObj);
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iBLGroupUDB = null;

                //�ʐM�G���[��-1��߂�
                return -1;
            }

            return status;
        }

        /// <summary>
        /// BL�O���[�v�}�X�^�_���폜����
        /// </summary>
        /// <param name="bLGroupU">BL�O���[�v�}�X�^�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : BL�O���[�v�}�X�^�̘_���폜���s���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/06/11</br>
        /// </remarks>
        public int LogicalDelete(ref BLGroupU bLGroupU)
        {
            // ------------------------------------------------------
            // �_���폜�̓��[�U�[�o�^���������肦�Ȃ�
            // ------------------------------------------------------

            int status = 0;

            try
            {
                // �N���X�����o�[�R�s�[����(�d�N���X���c�N���X(���[�U�[))
                BLGroupUWork bLGroupUWork = CopyToBLGroupUWorkFromBLGroupU(bLGroupU);
                ArrayList paraList = new ArrayList();
                paraList.Add(bLGroupUWork);

                object paraObj = paraList;

                // BL�O���[�v�}�X�^�_���폜
                status = this._iBLGroupUDB.LogicalDelete(ref paraObj);

                if (status == 0)
                {
                    ArrayList retList = new ArrayList();
                    retList = (ArrayList)paraObj;

                    bLGroupUWork = (BLGroupUWork)retList[0];

                    // �N���X�����o�[�R�s�[����(�c�N���X(���[�U�[)���d�N���X)
                    bLGroupU = CopyToBLGroupUFromBLGroupUWork(bLGroupUWork);
                }
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iBLGroupUDB = null;

                //�ʐM�G���[��-1��߂�
                return -1;
            }

            return status;
        }

        /// <summary>
        /// BL�O���[�v�}�X�^��������
        /// </summary>
        /// <param name="bLGroupU">BL�O���[�v�}�X�^�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : BL�O���[�v�}�X�^�̕������s���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/06/11</br>
        /// </remarks>
        public int Revival(ref BLGroupU bLGroupU)
        {
            // ------------------------------------------------------
            // �_���폜�����̓��[�U�[�o�^���������肦�Ȃ�
            // ------------------------------------------------------

            int status = 0;

            try
            {
                // �N���X�����o�[�R�s�[����(�d�N���X���c�N���X(���[�U�[))
                BLGroupUWork bLGroupUWork = CopyToBLGroupUWorkFromBLGroupU(bLGroupU);
                ArrayList paraList = new ArrayList();
                paraList.Add(bLGroupUWork);

                object paraObj = paraList;

                // ��������
                status = this._iBLGroupUDB.RevivalLogicalDelete(ref paraObj);
                if (status == 0)
                {
                    ArrayList retList = new ArrayList();
                    retList = (ArrayList)paraObj;

                    bLGroupUWork = (BLGroupUWork)retList[0];

                    // �N���X�����o�[�R�s�[����(�c�N���X(���[�U�[)���d�N���X)
                    bLGroupU = CopyToBLGroupUFromBLGroupUWork(bLGroupUWork);
                }
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iBLGroupUDB = null;

                //�ʐM�G���[��-1��߂�
                return -1;
            }

            return status;
        }

        /// <summary>
        /// BL�O���[�v�R�[�h�}�X�^�K�C�h�N������
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="bLGroupU">�擾�f�[�^</param>
        /// <returns>STATUS[0:�擾����,1:�L�����Z��]</returns>
        /// <remarks>
        /// <br>Note		: BL���i�R�[�h�}�X�^�̈ꗗ�\���@�\�����K�C�h���N�����܂��B</br>
        /// <br>Programmer	: 30414 �E�@�K�j</br>
        /// <br>Date	    : 2008/06/11</br>
        /// </remarks>
        public int ExecuteGuid(string enterpriseCode, out BLGroupU bLGroupU)
        {
            int status = -1;
            bLGroupU = new BLGroupU();

            TableGuideParent tableGuideParent = new TableGuideParent("BLGROUPGUIDEPARENT.XML");
            Hashtable inObj = new Hashtable();
            Hashtable retObj = new Hashtable();

            // ��ƃR�[�h
            inObj.Add("EnterpriseCode", enterpriseCode);

            if (tableGuideParent.Execute(0, inObj, ref retObj))
            {
                string strCode;

                // BL�O���[�v�R�[�h
                strCode = retObj["BLGroupCode"].ToString();
                bLGroupU.BLGroupCode = int.Parse(strCode);

                // BL�O���[�v����
                bLGroupU.BLGroupName = retObj["BLGroupName"].ToString();

                // ���i�啪�ރR�[�h
                strCode = retObj["GoodsLGroup"].ToString();
                bLGroupU.GoodsLGroup = int.Parse(strCode);

                // ���i�����ރR�[�h
                strCode = retObj["GoodsMGroup"].ToString();
                bLGroupU.GoodsMGroup = int.Parse(strCode);

                // �̔��敪�R�[�h
                strCode = retObj["SalesCode"].ToString();
                bLGroupU.SalesCode = int.Parse(strCode);

                // �f�[�^�敪�R�[�h
                strCode = retObj["OfferDataDiv"].ToString();
                bLGroupU.OfferDataDiv = int.Parse(strCode);

                // �f�[�^�敪����
                bLGroupU.OfferDataDivName = retObj["OfferDataDivName"].ToString();

                status = 0;
            }
            // �L�����Z��
            else
            {
                status = 1;
            }

            return status;
        }

        /// <summary>
        /// �ėp�K�C�h�f�[�^�擾(IGeneralGuidData�C���^�[�t�F�[�X����)
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="inParm"></param>
        /// <param name="guideList"></param>
        /// <returns>STATUS[0:�擾����,1:�L�����Z��,4:���R�[�h����]</returns>
        /// <remarks>
        /// <br>Note		: �ėp�K�C�h�ݒ�p�f�[�^���擾���܂��B</br>
        /// <br>Programmer	: 30414 �E�@�K�j</br>
        /// <br>Date	    : 2008/06/11</br>
        /// </remarks>
        public int GetGuideData(int mode, Hashtable inParm, ref DataSet dataSet)
        {
            int status = -1;
            string enterpriseCode = "";

            // ��ƃR�[�h�ݒ�L��
            if (inParm.ContainsKey("EnterpriseCode"))
            {
                enterpriseCode = inParm["EnterpriseCode"].ToString();
            }
            // ��ƃR�[�h�ݒ薳��
            else
            {
                // �L�蓾�Ȃ��̂ŃG���[
                return status;
            }

            // �}�X�^�e�[�u���Ǎ���
            status = Search(ref dataSet, enterpriseCode);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        status = 4;
                        break;
                    }
                default:
                    status = -1;
                    break;
            }

            return status;
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// BL�O���[�v�R�[�h(���[�U�[�f�[�^)�S���ǂݍ��ݏ���(�_���폜�܂�)
        /// </summary>
        /// <param name="retList">�Q�ƌ��ʃ��X�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="bLGroupUCode">BL�O���[�v�R�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : BL�O���[�v�R�[�h(���[�U�[�f�[�^)��ǂݍ��݂܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/06/11</br>
        /// </remarks>
        private int SearchBLGroupUser(ref ArrayList retList, string enterpriseCode, int bLGroupCode)
        {
            // ����������
            int status = 0;
            int hashKey;

            // �������o�N���X(D)�̐ݒ�
            BLGroupUWork bLGroupUWork = new BLGroupUWork();
            bLGroupUWork.EnterpriseCode = enterpriseCode;
            bLGroupUWork.BLGroupCode = bLGroupCode;

            ArrayList paraList = new ArrayList();
            object paraobj = bLGroupUWork;
            object retobj = paraList;

            // �����[�g�I�u�W�F�N�g�̌Ăяo��
            status = this._iBLGroupUDB.Search(ref retobj, paraobj, 0, ConstantManagement.LogicalMode.GetDataAll);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    paraList = retobj as ArrayList;

                    if (paraList == null)
                    {
                        return status;
                    }

                    foreach (BLGroupUWork wkbLGroupUWork in paraList)
                    {
                        // BL�O���[�v�R�[�h�擾
                        hashKey = wkbLGroupUWork.BLGroupCode;

                        if (_bLGroupUTable[hashKey] != null)
                        {
                            continue;
                        }

                        // �N���X�����o�[�R�s�[����(�c�N���X(���[�U�[)���d�N���X)
                        BLGroupU bLGroupU = CopyToBLGroupUFromBLGroupUWork(wkbLGroupUWork);
                        retList.Add(bLGroupU);

                        // static�ێ�
                        _bLGroupUTable[hashKey] = bLGroupU;
                    }

                    break;
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    break;
                default:
                    return status;
            }

            return status;
        }

        ///// <summary>
        ///// BL�O���[�v�R�[�h(�񋟃f�[�^)�S���ǂݍ��ݏ���(�_���폜�܂�)
        ///// </summary>
        ///// <param name="retList">�Q�ƌ��ʃ��X�g</param>
        ///// <param name="enterpriseCode">��ƃR�[�h</param>
        ///// <param name="bLGroupUCode">BL�O���[�v�R�[�h</param>
        ///// <returns>STATUS</returns>
        ///// <remarks>
        ///// <br>Note       : BL�O���[�v�R�[�h(�񋟃f�[�^)��ǂݍ��݂܂��B</br>
        ///// <br>Programmer : 30414 �E�@�K�j</br>
        ///// <br>Date	   : 2008/06/11</br>
        ///// </remarks>
        //private int SearchBLGroupOffer(ref ArrayList retList, int bLGroupCode)
        //{
        //    // ����������
        //    int status = 0;
        //    int hashKey;

        //    // �������o�N���X(D)�̐ݒ�
        //    BLGroupWork bLGroupWork = new BLGroupWork();
        //    bLGroupWork.BLGloupCode = bLGroupCode;

        //    ArrayList paraList = new ArrayList();
        //    object paraobj = bLGroupWork;
        //    object retobj = paraList;

        //    // �����[�g�I�u�W�F�N�g�̌Ăяo��
        //    status = this._iBLGroupDB.Search(out retobj, paraobj);
        //    switch (status)
        //    {
        //        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
        //            paraList = retobj as ArrayList;

        //            if (paraList == null)
        //            {
        //                return status;
        //            }

        //            foreach (BLGroupWork wkbLGroupWork in paraList)
        //            {
        //                // BL�O���[�v�R�[�h�擾
        //                hashKey = wkbLGroupWork.BLGloupCode;

        //                if (_bLGroupUTable[hashKey] != null)
        //                {
        //                    continue;
        //                }

        //                // �N���X�����o�[�R�s�[����(�c�N���X(��)���d�N���X)
        //                BLGroupU bLGroupU = CopyToBLGroupUFromBLGroupWork(wkbLGroupWork);
        //                retList.Add(bLGroupU);

        //                // static�ێ�
        //                _bLGroupUTable[hashKey] = bLGroupU;
        //            }

        //            break;
        //        case (int)ConstantManagement.DB_Status.ctDB_EOF:
        //            break;
        //        default:
        //            return status;
        //    }

        //    return status;
        //}

        /// <summary>
        /// �N���X�����o�[�R�s�[�����iBL�O���[�v�}�X�^�N���X(E)�˃��[�U�[BL�O���[�v�}�X�^���[�N�N���X(D)�j
        /// </summary>
        /// <param name="bLGroupU">BL�O���[�v�}�X�^�N���X</param>
        /// <returns>BL�O���[�v�}�X�^���[�N�N���X</returns>
        /// <remarks>
        /// <br>Note       : BL�O���[�v�}�X�^�N���X����BL�O���[�v�}�X�^���[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/06/11</br>
        /// </remarks>
        private BLGroupUWork CopyToBLGroupUWorkFromBLGroupU(BLGroupU bLGroupU)
        {
            BLGroupUWork bLGroupUWork = new BLGroupUWork();

            bLGroupUWork.EnterpriseCode = bLGroupU.EnterpriseCode;          // ��ƃR�[�h
            bLGroupUWork.CreateDateTime = bLGroupU.CreateDateTime;          // �쐬����
            bLGroupUWork.UpdateDateTime = bLGroupU.UpdateDateTime;          // �X�V����
            bLGroupUWork.FileHeaderGuid = bLGroupU.FileHeaderGuid;          // GUID
            bLGroupUWork.UpdEmployeeCode = bLGroupU.UpdEmployeeCode;        // �X�V�]�ƈ��R�[�h
            bLGroupUWork.UpdAssemblyId1 = bLGroupU.UpdAssemblyId1;          // �X�V�A�Z���u��ID1
            bLGroupUWork.UpdAssemblyId2 = bLGroupU.UpdAssemblyId2;          // �X�V�A�Z���u��ID2
            bLGroupUWork.LogicalDeleteCode = bLGroupU.LogicalDeleteCode;    // �_���폜�敪

            bLGroupUWork.BLGroupCode = bLGroupU.BLGroupCode;                // BL�O���[�v�R�[�h
            bLGroupUWork.BLGroupName = bLGroupU.BLGroupName;                // BL�O���[�v����
            bLGroupUWork.BLGroupKanaName = bLGroupU.BLGroupKanaName;        // BL�O���[�v����(�J�i)
            bLGroupUWork.GoodsLGroup = bLGroupU.GoodsLGroup;                // ���i�啪�ރR�[�h
            bLGroupUWork.GoodsMGroup = bLGroupU.GoodsMGroup;                // ���i�����ރR�[�h
            bLGroupUWork.SalesCode = bLGroupU.SalesCode;                    // �̔��敪�R�[�h
            bLGroupUWork.OfferDate = bLGroupU.OfferDate;                    // �񋟓��t
            bLGroupUWork.OfferDataDiv = bLGroupU.OfferDataDiv;              // �񋟃f�[�^�敪

            return bLGroupUWork;
        }

        /// <summary>
        /// �N���X�����o�[�R�s�[�����i���[�U�[BL�O���[�v�}�X�^���[�N�N���X(D)��BL�O���[�v�}�X�^�N���X(E)�j
        /// </summary>
        /// <param name="bLGroupUWork">BL�O���[�v�}�X�^���[�N�N���X</param>
        /// <returns>BL�O���[�v�}�X�^�N���X</returns>
        /// <remarks>
        /// <br>Note       : BL�O���[�v�}�X�^���[�N�N���X����BL�O���[�v�}�X�^�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/06/11</br>
        /// </remarks>
        private BLGroupU CopyToBLGroupUFromBLGroupUWork(BLGroupUWork bLGroupUWork)
        {
            BLGroupU bLGroupU = new BLGroupU();

            bLGroupU.EnterpriseCode = bLGroupUWork.EnterpriseCode;          // ��ƃR�[�h
            bLGroupU.CreateDateTime = bLGroupUWork.CreateDateTime;          // �쐬����
            bLGroupU.UpdateDateTime = bLGroupUWork.UpdateDateTime;          // �X�V����
            bLGroupU.FileHeaderGuid = bLGroupUWork.FileHeaderGuid;          // GUID
            bLGroupU.UpdEmployeeCode = bLGroupUWork.UpdEmployeeCode;        // �X�V�]�ƈ��R�[�h
            bLGroupU.UpdAssemblyId1 = bLGroupUWork.UpdAssemblyId1;          // �X�V�A�Z���u��ID1
            bLGroupU.UpdAssemblyId2 = bLGroupUWork.UpdAssemblyId2;          // �X�V�A�Z���u��ID2
            bLGroupU.LogicalDeleteCode = bLGroupUWork.LogicalDeleteCode;    // �_���폜�敪

            bLGroupU.BLGroupCode = bLGroupUWork.BLGroupCode;                // BL�O���[�v�R�[�h
            bLGroupU.BLGroupName = bLGroupUWork.BLGroupName;                // BL�O���[�v����
            bLGroupU.BLGroupKanaName = bLGroupUWork.BLGroupKanaName;        // BL�O���[�v����(�J�i)
            bLGroupU.GoodsLGroup = bLGroupUWork.GoodsLGroup;                // ���i�啪�ރR�[�h
            bLGroupU.GoodsMGroup = bLGroupUWork.GoodsMGroup;                // ���i�����ރR�[�h
            bLGroupU.SalesCode = bLGroupUWork.SalesCode;                    // �̔��敪�R�[�h
            bLGroupU.OfferDate = bLGroupUWork.OfferDate;                    // �񋟓��t
            bLGroupU.OfferDataDiv = bLGroupUWork.OfferDataDiv;              // �񋟃f�[�^�敪
            if (bLGroupU.OfferDate == DateTime.MinValue)
            {
                bLGroupU.OfferDataDiv = DIVISION_USR;                           // �f�[�^�敪
                bLGroupU.OfferDataDivName = DIVISIONNAME_USR;                   // �f�[�^�敪����
            }
            else
            {
                bLGroupU.OfferDataDiv = DIVISION_OFR;
                bLGroupU.OfferDataDivName = DIVISIONNAME_OFR;
            }
            
            return bLGroupU;
        }

        ///// <summary>
        ///// �N���X�����o�[�R�s�[�����i��BL�O���[�v�}�X�^���[�N�N���X(D)��BL�O���[�v�}�X�^�N���X(E)�j
        ///// </summary>
        ///// <param name="bLGroupWork">BL�O���[�v�}�X�^���[�N�N���X</param>
        ///// <returns>BL�O���[�v�}�X�^�N���X</returns>
        ///// <remarks>
        ///// <br>Note       : BL�O���[�v�}�X�^���[�N�N���X����BL�O���[�v�}�X�^�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        ///// <br>Programmer : 30414 �E�@�K�j</br>
        ///// <br>Date	   : 2008/06/11</br>
        ///// </remarks>
        //private BLGroupU CopyToBLGroupUFromBLGroupWork(BLGroupWork bLGroupWork)
        //{
        //    BLGroupU bLGroupU = new BLGroupU();

        //    bLGroupU.BLGroupCode = bLGroupWork.BLGloupCode;     // BL�O���[�v�R�[�h
        //    bLGroupU.BLGroupName = bLGroupWork.BLGloupName;     // BL�O���[�v����
        //    bLGroupU.GoodsMGroup = bLGroupWork.GoodsMGroup;     // ���i�����ރR�[�h
        //    bLGroupU.DivisionCode = DIVISION_OFR;               // �f�[�^�敪
        //    bLGroupU.DivisionName = DIVISIONNAME_OFR;           // �f�[�^�敪����

        //    return bLGroupU;
        //}
        
        #endregion Private Methods
    }
}

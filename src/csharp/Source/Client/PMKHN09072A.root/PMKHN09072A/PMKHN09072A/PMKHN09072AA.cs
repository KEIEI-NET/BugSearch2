using System;
using System.Text;
using System.Data;
using System.Collections;
using System.Collections.Generic;

using Broadleaf.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ���i�����ރ}�X�^�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: ���i�����ރ}�X�^�̃A�N�Z�X������s���܂��B
    ///					  IGeneralGuideData���������Ă��܂��B</br>
    /// <br>Programmer	: 30414 �E�@�K�j</br>
    /// <br>Date		: 2008/06/11</br>
    /// </remarks>
    public class GoodsGroupUAcs : IGeneralGuideData
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
        IGoodsGroupUDB _iGoodsGroupUDB = null;
        IGoodsMGroupDB _iGoodsMGroupDB = null;

        // �L���b�V���p�n�b�V���e�[�u��
        private static Hashtable _goodsGroupUTable = null;

        #endregion Private Members

        # region Constructor

        /// <summary>
        /// ���i�����ރe�[�u���A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���i�����ރe�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/06/11</br>
        /// </remarks>
        public GoodsGroupUAcs()
        {
            _goodsGroupUTable = null;

            try
            {
                // �����[�g�I�u�W�F�N�g�擾
                this._iGoodsGroupUDB = (IGoodsGroupUDB)MediationGoodsGroupUDB.GetGoodsGroupUDB();
                this._iGoodsMGroupDB = (IGoodsMGroupDB)MediationGoodsMGroupDB.GetGoodsMGroupDB();

            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iGoodsGroupUDB = null;
                this._iGoodsMGroupDB = null;
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
            if ((this._iGoodsGroupUDB == null) || (this._iGoodsMGroupDB == null))
            {
                return (int)ConstantManagement.OnlineMode.Offline;
            }
            else
            {
                return (int)ConstantManagement.OnlineMode.Online;
            }
        }

        /// <summary>
        /// ���i�����ރR�[�h�S���ǂݍ��ݏ���(�_���폜�܂�)
        /// </summary>
        /// <param name="retList">�Q�ƌ��ʃ��X�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���i�����ރR�[�h����ǂݍ��݂܂��B<br/>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/06/11</br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode)
        {
            int status = 0;

            retList = new ArrayList();
            retList.Clear();

            _goodsGroupUTable = new Hashtable();

            // ���[�U�[�f�[�^
            status = SearchGoodsGroupUser(ref retList, enterpriseCode, 0);

            // �񋟃f�[�^
            //status = SearchGoodsGroupOffer(ref retList, 0);

            return 0;
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
            foreach (GoodsGroupU goodsGroupU in wkList)
            {
                if (goodsGroupU.LogicalDeleteCode == 0)
                {
                    wkSort.Add(goodsGroupU.GoodsMGroup, goodsGroupU);
                }
            }

            GoodsGroupU[] aryGoodsGroupU = new GoodsGroupU[wkSort.Count];

            // �f�[�^�����ɖ߂�
            for (int i = 0; i < wkSort.Count; i++)
            {
                aryGoodsGroupU[i] = (GoodsGroupU)wkSort.GetByIndex(i);
            }

            byte[] retbyte = XmlByteSerializer.Serialize(aryGoodsGroupU);
            XmlByteSerializer.ReadXml(ref dataSet, retbyte);

            return status;
        }

        /// <summary>
        /// ���i�����ރf�[�^��������
        /// </summary>
        /// <param name="goodsGroupU">���i�����ރI�u�W�F�N�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="goodsGroupUCode">���i�����ރR�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���i�����ރf�[�^���������܂��B<br/>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/06/11</br>
        /// </remarks>
        public int Search(out GoodsGroupU goodsGroupU, string enterpriseCode, int goodsGroupUCode)
        {
            int status;
            goodsGroupU = new GoodsGroupU();
            _goodsGroupUTable = new Hashtable();
            ArrayList retList = new ArrayList();

            // ���[�U�[�f�[�^
            status = SearchGoodsGroupUser(ref retList, enterpriseCode, goodsGroupUCode);

            // �񋟃f�[�^
            //status = SearchGoodsGroupOffer(ref retList, goodsGroupUCode);

            if ((retList == null) || (retList.Count == 0))
            {
                return 9;
            }
            else
            {
                goodsGroupU = (GoodsGroupU)retList[0];
                return 0;
            }
        }

        /// <summary>
        /// ���i�����ރ}�X�^�o�^�E�X�V����
        /// </summary>
        /// <param name="goodsGroupU">���i�����ރ}�X�^�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���i�����ރ}�X�^���̓o�^�E�X�V���s���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/06/11</br>
        /// </remarks>
        public int Write(ref GoodsGroupU goodsGroupU)
        {
            // ------------------------------------------------------
            // �o�^�̓��[�U�[�o�^���������肦�Ȃ�
            // ------------------------------------------------------

            int status = 0;

            try
            {
                // �N���X�����o�[�R�s�[����(�d�N���X���c�N���X(���[�U�[))
                GoodsGroupUWork goodsGroupUWork = CopyToGoodsGroupUWorkFromGoodsGroupU(goodsGroupU);
                ArrayList paraList = new ArrayList();
                paraList.Add(goodsGroupUWork);

                object paraobj = paraList;

                // ���i�����ރ}�X�^��������
                status = this._iGoodsGroupUDB.Write(ref paraobj);
                if (status == 0)
                {
                    ArrayList retList = new ArrayList();
                    retList = (ArrayList)paraobj;

                    goodsGroupUWork = (GoodsGroupUWork)retList[0];

                    // �N���X�����o�[�R�s�[����(�c�N���X(���[�U�[)���d�N���X)
                    goodsGroupU = CopyToGoodsGroupUFromGoodsGroupUWork(goodsGroupUWork);
                }
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iGoodsGroupUDB = null;

                //�ʐM�G���[��-1��߂�
                status = -1;
            }

            return status;
        }

        /// <summary>
        /// ���i�����ރ}�X�^�����폜����
        /// </summary>
        /// <param name="goodsGroupU">���i�����ރ}�X�^�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���i�����ރ}�X�^�̕����폜���s���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/06/11</br>
        /// </remarks>
        public int Delete(GoodsGroupU goodsGroupU)
        {
            // ------------------------------------------------------
            // �����폜�̓��[�U�[�o�^���������肦�Ȃ�
            // ------------------------------------------------------

            int status = 0;

            try
            {
                // �N���X�����o�[�R�s�[����(�d�N���X���c�N���X(���[�U�[))
                GoodsGroupUWork goodsGroupUWork = CopyToGoodsGroupUWorkFromGoodsGroupU(goodsGroupU);
                ArrayList paraList = new ArrayList();
                paraList.Add(goodsGroupUWork);

                object paraObj = paraList;

                // ���i�����ރ}�X�^�����폜
                status = this._iGoodsGroupUDB.Delete(paraObj);
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iGoodsGroupUDB = null;

                //�ʐM�G���[��-1��߂�
                return -1;
            }

            return status;
        }

        /// <summary>
        /// ���i�����ރ}�X�^�_���폜����
        /// </summary>
        /// <param name="goodsGroupU">���i�����ރ}�X�^�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���i�����ރ}�X�^�̘_���폜���s���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/06/11</br>
        /// </remarks>
        public int LogicalDelete(ref GoodsGroupU goodsGroupU)
        {
            // ------------------------------------------------------
            // �_���폜�̓��[�U�[�o�^���������肦�Ȃ�
            // ------------------------------------------------------

            int status = 0;

            try
            {
                // �N���X�����o�[�R�s�[����(�d�N���X���c�N���X(���[�U�[))
                GoodsGroupUWork goodsGroupUWork = CopyToGoodsGroupUWorkFromGoodsGroupU(goodsGroupU);
                ArrayList paraList = new ArrayList();
                paraList.Add(goodsGroupUWork);

                object paraObj = paraList;

                // ���i�����ރ}�X�^�_���폜
                status = this._iGoodsGroupUDB.LogicalDelete(ref paraObj);

                if (status == 0)
                {
                    ArrayList retList = new ArrayList();
                    retList = (ArrayList)paraObj;

                    goodsGroupUWork = (GoodsGroupUWork)retList[0];

                    // �N���X�����o�[�R�s�[����(�c�N���X(���[�U�[)���d�N���X)
                    goodsGroupU = CopyToGoodsGroupUFromGoodsGroupUWork(goodsGroupUWork);
                }
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iGoodsGroupUDB = null;

                //�ʐM�G���[��-1��߂�
                return -1;
            }

            return status;
        }

        /// <summary>
        /// ���i�����ރ}�X�^��������
        /// </summary>
        /// <param name="goodsGroupU">���i�����ރ}�X�^�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���i�����ރ}�X�^�̕������s���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/06/11</br>
        /// </remarks>
        public int Revival(ref GoodsGroupU goodsGroupU)
        {
            // ------------------------------------------------------
            // �_���폜�����̓��[�U�[�o�^���������肦�Ȃ�
            // ------------------------------------------------------

            int status = 0;

            try
            {
                // �N���X�����o�[�R�s�[����(�d�N���X���c�N���X(���[�U�[))
                GoodsGroupUWork goodsGroupUWork = CopyToGoodsGroupUWorkFromGoodsGroupU(goodsGroupU);
                ArrayList paraList = new ArrayList();
                paraList.Add(goodsGroupUWork);

                object paraObj = paraList;

                // ��������
                status = this._iGoodsGroupUDB.RevivalLogicalDelete(ref paraObj);
                if (status == 0)
                {
                    ArrayList retList = new ArrayList();
                    retList = (ArrayList)paraObj;

                    goodsGroupUWork = (GoodsGroupUWork)retList[0];

                    // �N���X�����o�[�R�s�[����(�c�N���X(���[�U�[)���d�N���X)
                    goodsGroupU = CopyToGoodsGroupUFromGoodsGroupUWork(goodsGroupUWork);
                }
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iGoodsGroupUDB = null;

                //�ʐM�G���[��-1��߂�
                return -1;
            }

            return status;
        }

        /// <summary>
        /// ���i�����ރK�C�h�N������
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="goodsGroupU">�擾�f�[�^</param>
        /// <returns>STATUS[0:�擾����,1:�L�����Z��]</returns>
        /// <remarks>
        /// <br>Note		: BL���i�R�[�h�}�X�^�̈ꗗ�\���@�\�����K�C�h���N�����܂��B</br>
        /// <br>Programmer	: 30414 �E�@�K�j</br>
        /// <br>Date	    : 2008/06/11</br>
        /// </remarks>
        public int ExecuteGuid(string enterpriseCode, out GoodsGroupU goodsGroupU)
        {
            int status = ExecuteGuid(enterpriseCode, "GOODSMGROUPGUIDEPARENT.XML", out goodsGroupU);

            return status;
        }

        /// <summary>
        /// ���i�����ރK�C�h�N������
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="goodsGroupU">�擾�f�[�^</param>
        /// <param name="dispGoodsMGroup">���i�����ޕ\���K�C�h�t���O(True:���i�����ރK�C�h�@False:���i�|����ٰ�߃K�C�h)</param>
        /// <returns>STATUS[0:�擾����,1:�L�����Z��]</returns>
        /// <remarks>
        /// <br>Note		: BL���i�R�[�h�}�X�^�̈ꗗ�\���@�\�����K�C�h���N�����܂��B</br>
        /// <br>Programmer	: 30414 �E�@�K�j</br>
        /// <br>Date	    : 2008/06/11</br>
        /// </remarks>
        public int ExecuteGuid(string enterpriseCode, out GoodsGroupU goodsGroupU, bool dispGoodsMGroup)
        {
            string guideFileName;

            if (dispGoodsMGroup == true)
            {
                // ���i�����ރK�C�h��\��
                guideFileName = "GOODSMGROUPGUIDEPARENT.XML";
            }
            else
            {
                // ���i�|���O���[�v�K�C�h��\��
                guideFileName = "GOODSGROUPGUIDEPARENT.XML";
            }

            int status = ExecuteGuid(enterpriseCode, guideFileName, out goodsGroupU);

            return status;
        }

        /// <summary>
        /// ���i�����ރK�C�h�N������
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="guideFileName">�K�C�hXML��</param>
        /// <param name="goodsGroupU">�擾�f�[�^</param>
        /// <returns></returns>
        private int ExecuteGuid(string enterpriseCode, string guideFileName, out GoodsGroupU goodsGroupU)
        {
            int status = -1;
            goodsGroupU = new GoodsGroupU();

            TableGuideParent tableGuideParent = new TableGuideParent(guideFileName);
            Hashtable inObj = new Hashtable();
            Hashtable retObj = new Hashtable();

            // ��ƃR�[�h
            inObj.Add("EnterpriseCode", enterpriseCode);

            if (tableGuideParent.Execute(0, inObj, ref retObj))
            {
                string strCode;

                // ���i�����ރR�[�h
                strCode = retObj["GoodsMGroup"].ToString();
                goodsGroupU.GoodsMGroup = int.Parse(strCode);

                // ���i�����ޖ���
                goodsGroupU.GoodsMGroupName = retObj["GoodsMGroupName"].ToString();

                // �f�[�^�敪�R�[�h
                strCode = retObj["DivisionCode"].ToString();
                goodsGroupU.DivisionCode = int.Parse(strCode);

                // �f�[�^�敪����
                goodsGroupU.DivisionName = retObj["DivisionName"].ToString();

                status = 0;
            }
            // �L�����Z��
            else
            {
                status = 1;
            }

            return (status);
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
        /// ���i�����ރR�[�h(���[�U�[�f�[�^)�S���ǂݍ��ݏ���(�_���폜�܂�)
        /// </summary>
        /// <param name="retList">�Q�ƌ��ʃ��X�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="goodsGroupUCode">���i�����ރR�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���i�����ރR�[�h(���[�U�[�f�[�^)��ǂݍ��݂܂��B<br/>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/06/11</br>
        /// </remarks>
        private int SearchGoodsGroupUser(ref ArrayList retList, string enterpriseCode, int goodsGroupCode)
        {
            // ����������
            int status = 0;
            int hashKey;

            // �������o�N���X(D)�̐ݒ�
            GoodsGroupUWork goodsGroupUWork = new GoodsGroupUWork();
            goodsGroupUWork.EnterpriseCode = enterpriseCode;
            goodsGroupUWork.GoodsMGroup = goodsGroupCode;

            ArrayList paraList = new ArrayList();
            object paraobj = goodsGroupUWork;
            object retobj = paraList;

            // �����[�g�I�u�W�F�N�g�̌Ăяo��
            status = this._iGoodsGroupUDB.Search(ref retobj, paraobj, 0, ConstantManagement.LogicalMode.GetDataAll);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    paraList = retobj as ArrayList;

                    if (paraList == null)
                    {
                        return status;
                    }

                    foreach (GoodsGroupUWork wkgoodsGroupUWork in paraList)
                    {
                        // ���i�����ރR�[�h
                        hashKey = wkgoodsGroupUWork.GoodsMGroup;

                        if (_goodsGroupUTable[hashKey] != null)
                        {
                            continue;
                        }

                        // �N���X�����o�[�R�s�[����(�c�N���X(���[�U�[)���d�N���X)
                        GoodsGroupU goodsGroupU = CopyToGoodsGroupUFromGoodsGroupUWork(wkgoodsGroupUWork);
                        retList.Add(goodsGroupU);

                        // static�ێ�
                        _goodsGroupUTable[hashKey] = goodsGroupU;
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
        ///// ���i�����ރR�[�h(�񋟃f�[�^)�S���ǂݍ��ݏ���(�_���폜�܂�)
        ///// </summary>
        ///// <param name="retList">�Q�ƌ��ʃ��X�g</param>
        ///// <param name="enterpriseCode">��ƃR�[�h</param>
        ///// <param name="goodsGroupUCode">���i�����ރR�[�h</param>
        ///// <returns>STATUS</returns>
        ///// <remarks>
        ///// <br>Note       : ���i�����ރR�[�h(�񋟃f�[�^)��ǂݍ��݂܂��B<br/>
        ///// <br>Programmer : 30414 �E�@�K�j</br>
        ///// <br>Date	   : 2008/06/11</br>
        ///// </remarks>
        //private int SearchGoodsGroupOffer(ref ArrayList retList, int goodsGroupCode)
        //{
        //    // ����������
        //    int status = 0;
        //    int hashKey;

        //    // �������o�N���X(D)�̐ݒ�
        //    GoodsMGroupWork goodsMGroupWork = new GoodsMGroupWork();
        //    goodsMGroupWork.GoodsMGroup = goodsGroupCode;

        //    ArrayList paraList = new ArrayList();
        //    object paraobj = goodsMGroupWork;
        //    object retobj = paraList;

        //    // �����[�g�I�u�W�F�N�g�̌Ăяo��
        //    status = this._iGoodsMGroupDB.Search(out retobj, paraobj);
        //    switch (status)
        //    {
        //        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
        //            paraList = retobj as ArrayList;

        //            if (paraList == null)
        //            {
        //                return status;
        //            }

        //            foreach (GoodsMGroupWork wkGoodsGroupWork in paraList)
        //            {
        //                // ���i�����ރR�[�h�擾
        //                hashKey = wkGoodsGroupWork.GoodsMGroup;

        //                if (_goodsGroupUTable[hashKey] != null)
        //                {
        //                    continue;
        //                }

        //                // �N���X�����o�[�R�s�[����(�c�N���X(��)���d�N���X)
        //                GoodsGroupU goodsGroupU = CopyToGoodsGroupUFromGoodsGroupWork(wkGoodsGroupWork);
        //                retList.Add(goodsGroupU);

        //                // static�ێ�
        //                _goodsGroupUTable[hashKey] = goodsGroupU;
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
        /// �N���X�����o�[�R�s�[�����i���i�����ރ}�X�^�N���X(E)�˃��[�U�[���i�����ރ}�X�^���[�N�N���X(D)�j
        /// </summary>
        /// <param name="goodsGroupU">���i�����ރ}�X�^�N���X</param>
        /// <returns>���i�����ރ}�X�^���[�N�N���X</returns>
        /// <remarks>
        /// <br>Note       : ���i�����ރ}�X�^�N���X���珤�i�����ރ}�X�^���[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/06/11</br>
        /// </remarks>
        private GoodsGroupUWork CopyToGoodsGroupUWorkFromGoodsGroupU(GoodsGroupU goodsGroupU)
        {
            GoodsGroupUWork goodsGroupUWork = new GoodsGroupUWork();

            goodsGroupUWork.EnterpriseCode = goodsGroupU.EnterpriseCode;        // ��ƃR�[�h
            goodsGroupUWork.CreateDateTime = goodsGroupU.CreateDateTime;        // �쐬����
            goodsGroupUWork.UpdateDateTime = goodsGroupU.UpdateDateTime;        // �X�V����
            goodsGroupUWork.FileHeaderGuid = goodsGroupU.FileHeaderGuid;        // GUID
            goodsGroupUWork.UpdEmployeeCode = goodsGroupU.UpdEmployeeCode;      // �X�V�]�ƈ��R�[�h
            goodsGroupUWork.UpdAssemblyId1 = goodsGroupU.UpdAssemblyId1;        // �X�V�A�Z���u��ID1
            goodsGroupUWork.UpdAssemblyId2 = goodsGroupU.UpdAssemblyId2;        // �X�V�A�Z���u��ID2
            goodsGroupUWork.LogicalDeleteCode = goodsGroupU.LogicalDeleteCode;  // �_���폜�敪

            goodsGroupUWork.GoodsMGroup = goodsGroupU.GoodsMGroup;              // ���i�����ރR�[�h
            goodsGroupUWork.GoodsMGroupName = goodsGroupU.GoodsMGroupName;      // ���i�����ޖ���
            goodsGroupUWork.OfferDate = goodsGroupU.OfferDate;                  // �񋟓��t
            goodsGroupUWork.OfferDataDiv = goodsGroupU.OfferDataDiv;            // �񋟃f�[�^�敪
            
            return goodsGroupUWork;
        }

        /// <summary>
        /// �N���X�����o�[�R�s�[�����i���[�U�[���i�����ރ}�X�^���[�N�N���X(D)�ˏ��i�����ރ}�X�^�N���X(E)�j
        /// </summary>
        /// <param name="goodsGroupUWork">���i�����ރ}�X�^���[�N�N���X</param>
        /// <returns>���i�����ރ}�X�^�N���X</returns>
        /// <remarks>
        /// <br>Note       : ���i�����ރ}�X�^���[�N�N���X���珤�i�����ރ}�X�^�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date	   : 2008/06/11</br>
        /// </remarks>
        private GoodsGroupU CopyToGoodsGroupUFromGoodsGroupUWork(GoodsGroupUWork goodsGroupUWork)
        {
            GoodsGroupU goodsGroupU = new GoodsGroupU();

            goodsGroupU.EnterpriseCode = goodsGroupUWork.EnterpriseCode;        // ��ƃR�[�h
            goodsGroupU.CreateDateTime = goodsGroupUWork.CreateDateTime;        // �쐬����
            goodsGroupU.UpdateDateTime = goodsGroupUWork.UpdateDateTime;        // �X�V����
            goodsGroupU.FileHeaderGuid = goodsGroupUWork.FileHeaderGuid;        // GUID
            goodsGroupU.UpdEmployeeCode = goodsGroupUWork.UpdEmployeeCode;      // �X�V�]�ƈ��R�[�h
            goodsGroupU.UpdAssemblyId1 = goodsGroupUWork.UpdAssemblyId1;        // �X�V�A�Z���u��ID1
            goodsGroupU.UpdAssemblyId2 = goodsGroupUWork.UpdAssemblyId2;        // �X�V�A�Z���u��ID2
            goodsGroupU.LogicalDeleteCode = goodsGroupUWork.LogicalDeleteCode;  // �_���폜�敪

            goodsGroupU.GoodsMGroup = goodsGroupUWork.GoodsMGroup;              // ���i�����ރR�[�h
            goodsGroupU.GoodsMGroupName = goodsGroupUWork.GoodsMGroupName;      // ���i�����ޖ���
            goodsGroupU.OfferDate = goodsGroupUWork.OfferDate;                  // �񋟓��t
            goodsGroupU.OfferDataDiv = goodsGroupUWork.OfferDataDiv;            // �񋟃f�[�^�敪

            if (goodsGroupU.OfferDate == DateTime.MinValue)
            {
                goodsGroupU.DivisionCode = DIVISION_USR;                         
                goodsGroupU.DivisionName = DIVISIONNAME_USR;                   
            }
            else
            {
                goodsGroupU.DivisionCode = DIVISION_OFR;
                goodsGroupU.DivisionName = DIVISIONNAME_OFR;
            }

            return goodsGroupU;
        }

        ///// <summary>
        ///// �N���X�����o�[�R�s�[�����i�񋟏��i�����ރ}�X�^���[�N�N���X(D)�ˏ��i�����ރ}�X�^�N���X(E)�j
        ///// </summary>
        ///// <param name="goodsMGroupWork">���i�����ރ}�X�^���[�N�N���X</param>
        ///// <returns>���i�����ރ}�X�^�N���X</returns>
        ///// <remarks>
        ///// <br>Note       : ���i�����ރ}�X�^���[�N�N���X���珤�i�����ރ}�X�^�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        ///// <br>Programmer : 30414 �E�@�K�j</br>
        ///// <br>Date	   : 2008/06/11</br>
        ///// </remarks>
        //private GoodsGroupU CopyToGoodsGroupUFromGoodsGroupWork(GoodsMGroupWork goodsMGroupWork)
        //{
        //    GoodsGroupU goodsGroupU = new GoodsGroupU();

        //    goodsGroupU.GoodsMGroup = goodsMGroupWork.GoodsMGroup;              // ���i�����ރR�[�h
        //    goodsGroupU.GoodsMGroupName = goodsMGroupWork.GoodsMGroupName;      // ���i�����ޖ���
        //    goodsGroupU.DivisionCode = DIVISION_OFR;                            // �f�[�^�敪
        //    goodsGroupU.DivisionName = DIVISIONNAME_OFR;                        // �f�[�^�敪����

        //    return goodsGroupU;
        //}

        #endregion Private Methods
    }
}

using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Text;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �i�ԕϊ��}�X�^�e�[�u���A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �i�ԕϊ��̐ݒ���s���܂��B</br>
    /// <br>Programmer : �i�N</br>
    /// <br>Date       : 2014/12/23</br>
    /// </remarks>
    public class GoodsNoChangeAcs
    {
        #region ��Public Members

        /// <summary>��ʕ\���f�[�^�e�[�u���i�[�f�[�^�Z�b�g�N���X</summary>
        public DataSet GoodsNoChangeDataSet;

        #region ��DataTable�p���̏��
        /// <summary>�f�[�^�e�[�u���J��������(G
        /// UID)</summary>
        public static readonly string FILEHEADERGUID_TITLE = "Guid";
        /// <summary>�f�[�^�e�[�u���J��������(�폜��)</summary>
        public static readonly string DELETE_DATE = "�폜��";
        /// <summary>�f�[�^�e�[�u���J��������(�_���폜�敪)</summary>
        public static readonly string LOGICALDELETE_TITLE = "�_���폜�敪";
        /// <summary>�f�[�^�e�[�u���J��������(���i���[�J�[�R�[�h)</summary>
        public static readonly string GOODSMAKERCD_TITLE = "���i���[�J�[�R�[�h";
        /// <summary>�f�[�^�e�[�u���J��������(���[�J�[����)</summary>
        public static readonly string MAKERNAME_TITLE = "���[�J�[����";
        /// <summary>�f�[�^�e�[�u���J��������(�����i�ԍ�)</summary>
        public static readonly string OLDGOODSNO_TITLE = "���i��";
        /// <summary>�f�[�^�e�[�u���J��������(�V���i�ԍ�)</summary>
        public static readonly string NEWGOODSNO_TITLE = "�V�i��";

        /// <summary>�f�[�^�e�[�u������</summary>
        public static readonly string GOODSMNG_TABLE = "GoodsNoChange_Table";
        #endregion

        #endregion


        #region ��Private Members

        #region ��Static Members
        /// <summary>�i�ԕϊ��}�X�^�N���XSearch�t���O</summary>
        private static bool _searchFlg = false;
        #endregion

        #region ��Const
        /// <summary>�폜���\���`��</summary>
        private const string DATATIME_FORM = "ggYY/MM/DD";
        /// <summary>�K�C�h�pXML�̃t�@�C����</summary>
        private const string GUIDEXML_TITLE = "GOODSSETGUIDEPARENT.XML";
        // �����i�ԍ�
        private const string OLDGOODSNO_COLUMN = "OldGoodsNoRF";
        // �V���i�ԍ�
        private const string NEWGOODSNO_COLUMN = "NewGoodsNoRF";
        // ���i���[�J�[�R�[�h
        private const string GOODSMAKERCD_COLUMN = "GoodsMakerCdRF";
        //�G���[���b�Z�[�W
        private const string GOODS_ERROR = "GoodsErrorRF";
        // �e�[�u������
        private const string PRINTSET_TABLE = "GoodsNoChangeErr";
        #endregion

        #region ��Normal Members

        /// <summary>�i�ԕϊ������[�g�I�u�W�F�N�g�i�[�o�b�t�@</summary>
        private IGoodsNoChangeDB _iGoodsNoChangeDB = null;

        #endregion

        #endregion

        #region ��Constructor

        /// <summary>
        /// �i�ԕϊ��A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note           : �i�ԕϊ��擾�̂��߂̃����[�g�I�u�W�F�N�g���L�q���܂��B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
        public GoodsNoChangeAcs()
        {
            try
            {
                // �i�ԕϊ��}�X�^�����[�g�I�u�W�F�N�g�擾
                this._iGoodsNoChangeDB = (IGoodsNoChangeDB)MediationGoodsNoChangeDB.GetGoodsNoChangeDB();
            }
            catch (Exception)
            {
                this._iGoodsNoChangeDB = null;
            }
        }

        #endregion

        #region ��Public Methods

        /// <summary>�I�����C�����[�h�̗񋓌^�ł��B</summary>
        public enum OnlineMode
        {
            /// <summary>�I�t���C��</summary>
            Offline,
            /// <summary>�I�����C��</summary>
            Online
        }

        /// <summary>
        /// �I�����C�����[�h�擾����
        /// </summary>
        /// <returns>OnlineMode</returns>
        /// <remarks>
        /// <br>Note       : �I�����C�����[�h���擾���܂��B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if (LoginInfoAcquisition.OnlineFlag)
            {
                return (int)OnlineMode.Online;
            }
            else
            {
                return (int)OnlineMode.Offline;
            }
        }

        /// <summary>
        /// �i�ԕϊ��S���ǂݍ��ݏ���(�_���폜�܂�)
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// /// <param name="retList">�Q�ƌ��ʃ��X�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �i�ԕϊ�����ǂݍ��݂܂��B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
        public int SearchAll(string enterpriseCode, out ArrayList retList)
        {
            int status = -1;
            bool nextData;
            int retTotalCnt = 0;
            retList = new ArrayList();
            retList.Clear();

            #region < �������� >
            status = SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode,
                                                ConstantManagement.LogicalMode.GetDataAll, 0, null);
            #endregion

            #region < �����㏈�� >
            if (status == 0)
            {
                ArrayList paraList = new ArrayList();

                foreach (object retobj in retList)
                {
                    GoodsNoChange goodsNoChange = this.CopyToGoodsNoChangeFromGoodsNoChangeWork(retobj);

                    paraList.Add(goodsNoChange);
                }
                retList = paraList;
            }
            #endregion

            return status;
        }

        /// <summary>
        /// �i�ԕϊ��ǂݍ��ݏ���(�����[�e�B���O)
        /// </summary>
        /// <param name="retGoodsNoChangeList">�i�ԕϊ��Y���f�[�^���X�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="goodsNoChangeCode">���i�R�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �i�ԕϊ���ǂݍ��݂܂��B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
        public int ReadWithGoodsSet(out List<GoodsNoChange> retGoodsNoChangeList, string enterpriseCode, int goodsNoChangeCode)
        {
            int status = -1;
            retGoodsNoChangeList = new List<GoodsNoChange>();     // �i�ԕϊ��f�[�^���X�g
            GoodsNoChange goodsNoChange = new GoodsNoChange();

            // �L���b�V�� or �����[�e�B���O���f�[�^���擾���f�[�^�e�[�u�����쐬���܂�
            status = this.GetGoodsNoChangeData(enterpriseCode);

            #region �������㏈��
            switch (status)
            {
                #region -- ����I�� --
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // �Y���f�[�^�擾����
                        this.GetGoodsNoChangeDataList(ref retGoodsNoChangeList, goodsNoChangeCode);
                        break;
                    }
                #endregion

                #region -- �f�[�^���� --
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        status = 4;
                        break;
                    }
                #endregion

                #region -- �������s --
                default:
                    {
                        status = -1;
                        break;
                    }
                #endregion
            }
            #endregion

            return status;
        }

        /// <summary>
        /// �i�ԕϊ��o�^�E�X�V����
        /// </summary>
        /// <param name="goodsNoChange">�i�ԕϊ��f�[�^�N���X</param>
        /// <returns>STATUS</returns>
        /// 
        /// <remarks>
        /// <br>Note       : �i�ԕϊ��̓o�^�E�X�V���s���܂��B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
        public int Write(ref GoodsNoChange goodsNoChange)
        {
            int status = -1;

            try
            {
                #region < �o�^�f�[�^�������� >
                GoodsNoChangeWork goodsNoChangeWork = new GoodsNoChangeWork();
                ArrayList paraList = new ArrayList();

                //�i�ԕϊ����[�N�N���X�ւ̃f�[�^�i�[����
                goodsNoChangeWork = this.CopyToGoodsNoChangeWorkFromGoodsNoChange(goodsNoChange);

                object paraobj = goodsNoChangeWork;
                #endregion

                #region < �o�^���� >
                // �i�ԕϊ���������(�A����O��֐ڑ�)
                status = this._iGoodsNoChangeDB.Write(ref paraobj);
                #endregion

                #region < �o�^�㏈�� >
                if (status == 0)
                {
                    #region < �o�^�f�[�^���f���� >

                    // �N���X�������o�R�s�[
                    goodsNoChange = this.CopyToGoodsNoChangeFromGoodsNoChangeWork(paraobj);

                    #endregion

                    status = 0;
                }
                #endregion

                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iGoodsNoChangeDB = null;
                //�ʐM�G���[��-1��߂�
                status = -1;
                return status;
            }
        }

        /// <summary>
        /// �i�ԕϊ��_���폜����
        /// </summary>
        /// <param name="goodsNoChange">�i�ԕϊ��f�[�^�N���X</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �i�ԕϊ��_���폜���s���܂��B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
        public int LogicalDelete(ref GoodsNoChange goodsNoChange)
        {
            int status = 0;

            try
            {
                GoodsNoChangeWork goodsNoChangeWork = new GoodsNoChangeWork();
                ArrayList paraList = new ArrayList();

                #region < �_���폜�f�[�^�������� >
                //�i�ԕϊ����[�N�N���X�ւ̃f�[�^�i�[����
                goodsNoChangeWork = this.CopyToGoodsNoChangeWorkFromGoodsNoChange(goodsNoChange);
                paraList.Add(goodsNoChangeWork);
                object paraObj = paraList;
                #endregion

                #region < �_���폜���� >
                status = this._iGoodsNoChangeDB.LogicalDelete(ref paraObj);
                #endregion

                if (status == 0)
                {
                    #region < �_���폜�f�[�^���f���� >
                    // ��ʕ\���p�f�[�^�e�[�u���ɍ폜����\������
                    ArrayList retList = (ArrayList)paraObj;

                    // �N���X�������o�R�s�[
                    goodsNoChange = this.CopyToGoodsNoChangeFromGoodsNoChangeWork((GoodsNoChangeWork)retList[0]);

                    #endregion

                    status = 0;
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                }
                else
                {
                    status = -1;
                }

                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iGoodsNoChangeDB = null;
                //�ʐM�G���[��-1��߂�
                return -1;
            }
        }

        /// <summary>
        /// �i�ԕϊ������폜����
        /// </summary>
        /// <param name="goodsNoChange">�i�ԕϊ��f�[�^�N���X</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �i�ԕϊ������폜���s���܂��B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
        public int Delete(GoodsNoChange goodsNoChange)
        {
            int status;

            try
            {
                #region < �����폜�f�[�^�������� >
                GoodsNoChangeWork goodsNoChangeWork;
                //�i�ԕϊ����[�N�N���X�ւ̃f�[�^�i�[����
                goodsNoChangeWork = this.CopyToGoodsNoChangeWorkFromGoodsNoChange(goodsNoChange);
                #endregion

                #region < XML �V���A���C�Y >
                // XML�֕ϊ����A������̃o�C�i����
                byte[] parabyte = XmlByteSerializer.Serialize(goodsNoChangeWork);
                #endregion

                #region < �����폜���� >
                status = this._iGoodsNoChangeDB.Delete(parabyte);
                #endregion

                #region < �����폜�㏈�� >
                if (status == 0)
                {
                    #region -- ����I�� --
                    #endregion

                    status = 0;
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                }
                else
                {
                    //�T�[�o�[�G���[��-1��߂�
                    status = -1;
                }
                #endregion

                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iGoodsNoChangeDB = null;
                //�ʐM�G���[��-1��߂�
                return -1;
            }
        }

        /// <summary>
        /// �i�ԕϊ��_���폜��������
        /// </summary>
        /// <param name="goodsNoChange">�i�ԕϊ��f�[�^�N���X</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �i�ԕϊ��̕������s���܂��B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
        public int Revival(ref GoodsNoChange goodsNoChange)
        {
            int status = 0;
            try
            {
                #region < �����f�[�^�������� >
                GoodsNoChangeWork goodsNoChangeWork = new GoodsNoChangeWork();
                ArrayList paraList = new ArrayList();

                //�i�ԕϊ����[�N�N���X�ւ̃f�[�^�i�[����
                goodsNoChangeWork = this.CopyToGoodsNoChangeWorkFromGoodsNoChange(goodsNoChange);
                paraList.Add(goodsNoChangeWork);
                object paraobj = paraList;
                #endregion

                #region < �������� >
                status = this._iGoodsNoChangeDB.RevivalLogicalDelete(ref paraobj);
                #endregion

                #region < �����㏈�� >
                if (status == 0)
                {
                    #region -- �����f�[�^���f���� --
                    ArrayList retList = (ArrayList)paraobj;

                    // �N���X�������o�R�s�[
                    goodsNoChange = this.CopyToGoodsNoChangeFromGoodsNoChangeWork((GoodsNoChangeWork)retList[0]);
                    #endregion

                    status = 0;
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE;
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE;
                }
                else
                {
                    status = -1;
                }
                #endregion

                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iGoodsNoChangeDB = null;
                //�ʐM�G���[��-1��߂�
                return -1;
            }
        }

        /// <summary>
        /// �i�ԕϊ��}�X�^�f�[�^�擾����(�����[�e�B���O)
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �i�ԕϊ��}�X�^�f�[�^���L���b�V�� or �����[�e�B���O�ɂ��擾���܂��B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
        public int GetGoodsNoChangeData(string enterpriseCode)
        {
            int status = -1;

            #region ���e�[�u���쐬
            if (_searchFlg == false)
            {
                #region < �����[�e�B���O�擾 >
                ArrayList retList;
                int retTotalCnt;
                bool nextData;

                // �S����
                status = this.SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode,
                                                        ConstantManagement.LogicalMode.GetDataAll, 0, null);
                #endregion
            }
            #endregion

            return status;
        }

        #endregion

        #region ��Private Methods

        /// <summary>
        /// �i�ԕϊ���������
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������(prevMaker��null�̏ꍇ�̂ݖ߂�)</param>
        /// <param name="nextData">���f�[�^�L��</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�S�f�[�^)</param>
        /// <param name="readCnt">�Ǎ�����</param>
        /// <param name="prevGoodsNoChange">�O��ŏI�S���҃f�[�^�I�u�W�F�N�g�i�����null�w��K�{�j</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �i�ԕϊ��̌����������s���܂��B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, GoodsNoChange prevGoodsNoChange)
        {
            GoodsNoChangeWork goodsNoChangeWork = new GoodsNoChangeWork();
            goodsNoChangeWork.EnterpriseCode = enterpriseCode;

            int status = 0;
            nextData = false;
            retTotalCnt = 0;

            retList = new ArrayList();
            retList.Clear();

            object paraobj = goodsNoChangeWork;
            object retobj = null;

            // �i�ԕϊ�����
            if (readCnt == 0)
            {
                status = this._iGoodsNoChangeDB.Search(out retobj, paraobj, 0, logicalMode);
            }

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    retList = retobj as ArrayList;
                    break;

                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    break;

                default:
                    return status;
            }

            //�S�����[�h�̏ꍇ�͖߂�l�̌������Z�b�g
            if (readCnt == 0) retTotalCnt = retList.Count;

            // SearchFlg ON
            _searchFlg = true;

            return status;
        }

        /// <summary>
        /// �i�ԕϊ��f�[�^�N���X �� �i�ԕϊ��f�[�^���[�N�N���X
        /// </summary>
        /// <param name="goodsNoChange">�i�ԕϊ��f�[�^�N���X</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �i�ԕϊ��̕������s���܂��B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
        private GoodsNoChangeWork CopyToGoodsNoChangeWorkFromGoodsNoChange(GoodsNoChange goodsNoChange)
        {
            GoodsNoChangeWork goodsNoChangeWork = new GoodsNoChangeWork();

            goodsNoChangeWork.CreateDateTime = goodsNoChange.CreateDateTime;
            goodsNoChangeWork.UpdateDateTime = goodsNoChange.UpdateDateTime;
            goodsNoChangeWork.EnterpriseCode = goodsNoChange.EnterpriseCode;
            goodsNoChangeWork.FileHeaderGuid = goodsNoChange.FileHeaderGuid;
            goodsNoChangeWork.UpdAssemblyId1 = goodsNoChange.UpdAssemblyId1;
            goodsNoChangeWork.UpdAssemblyId2 = goodsNoChange.UpdAssemblyId2;
            goodsNoChangeWork.UpdEmployeeCode = goodsNoChange.UpdEmployeeCode;
            goodsNoChangeWork.LogicalDeleteCode = goodsNoChange.LogicalDeleteCode;

            goodsNoChangeWork.GoodsMakerCd = goodsNoChange.GoodsMakerCd;�@�@// ���i���[�J�[�R�[�h
            goodsNoChangeWork.OldGoodsNo = goodsNoChange.OldGoodsNo;        // �����i�R�[�h
            goodsNoChangeWork.NewGoodsNo = goodsNoChange.NewGoodsNo;        // �V���i�R�[�h

            return goodsNoChangeWork;
        }

        /// <summary>
        /// Read�Y���f�[�^���X�g�擾����
        /// </summary>
        /// <param name="goodsNoChangeList">�i�ԕϊ��f�[�^�N���X���X�g</param>
        /// <param name="BLGoodsCode">�����L�[</param>
        /// <remarks>
        /// <br>Note		: �L���b�V������i�ԕϊ����̂��擾���܂��B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
        private void GetGoodsNoChangeDataList(ref List<GoodsNoChange> goodsNoChangeList, int BLGoodsCode)
        {
            GoodsNoChange goodsNoChange = new GoodsNoChange();

            #region ���Y���f�[�^���X�g�쐬
            GoodsAcs goodsAcs = new GoodsAcs();

            #region < ���i���擾 >
            goodsNoChange.FileHeaderGuid = (Guid)this.GoodsNoChangeDataSet.Tables[GOODSMNG_TABLE].DefaultView[0][FILEHEADERGUID_TITLE];
            goodsNoChange.GoodsMakerCd = (int)this.GoodsNoChangeDataSet.Tables[GOODSMNG_TABLE].DefaultView[0][GOODSMAKERCD_TITLE];
            goodsNoChange.MakerName = (string)this.GoodsNoChangeDataSet.Tables[GOODSMNG_TABLE].DefaultView[0][MAKERNAME_TITLE];
            goodsNoChange.OldGoodsNo = (string)this.GoodsNoChangeDataSet.Tables[GOODSMNG_TABLE].DefaultView[0][OLDGOODSNO_TITLE];
            goodsNoChange.NewGoodsNo = (string)this.GoodsNoChangeDataSet.Tables[GOODSMNG_TABLE].DefaultView[0][NEWGOODSNO_TITLE];
            #endregion

            #endregion
        }

        /// <summary>
        /// Read�Y���f�[�^���X�g�擾����
        /// </summary>
        /// <param name="MakerCode">���[�J�[�R�[�h</param>
        /// <remarks>
        /// <br>Note       : �L���b�V������i�ԕϊ����̂��擾���܂��B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
        private string CreateReadRowFilter(int MakerCode)
        {
            string rowFilter = "";

            #region < ���[�J�[�R�[�h�̂� >
            if (MakerCode != 0)
            {
                rowFilter = GoodsNoChangeAcs.GOODSMAKERCD_TITLE + " = '" + MakerCode + "'";
            }
            #endregion
            return rowFilter;
        }

        /// <summary>
        /// �i�ԕϊ����[�N�N���X����i�ԕϊ��N���X���쐬���܂��B
        /// </summary>
        /// <param name="paraobj">�i�ԕϊ����[�N�N���X</param>
        /// <remarks>
        /// <br>Note       : �i�ԕϊ��N���X���쐬���܂��B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
        private GoodsNoChange CopyToGoodsNoChangeFromGoodsNoChangeWork(object paraobj)
        {
            GoodsNoChangeWork goodsNoChangeWork = new GoodsNoChangeWork();
            Type paraType = paraobj.GetType();
            MakerAcs makerAcs = new MakerAcs();
            MakerUMnt makerUMnt = new MakerUMnt();

            #region ��Object �� GoodsNoChangeWork�N���X����
            if (paraType.Name == "ArrayList")
            {
                ArrayList paraList = (ArrayList)paraobj;
                goodsNoChangeWork = (GoodsNoChangeWork)paraList[0];
            }
            else if (paraType.Name == "GoodsNoChangeWork")
            {
                goodsNoChangeWork = (GoodsNoChangeWork)paraobj;
            }
            #endregion

            GoodsNoChange goodsNoChange = new GoodsNoChange();
            goodsNoChange.FileHeaderGuid     = goodsNoChangeWork.FileHeaderGuid;          // �f�[�^�e�[�u���J��������
            goodsNoChange.LogicalDeleteCode  = goodsNoChangeWork.LogicalDeleteCode;       // �_���폜�敪
            goodsNoChange.UpdateDateTime     = goodsNoChangeWork.UpdateDateTime;          // �C�����t
            goodsNoChange.EnterpriseCode = goodsNoChangeWork.EnterpriseCode;
            goodsNoChange.UpdateDateTime = goodsNoChangeWork.UpdateDateTime;
            goodsNoChange.CreateDateTime = goodsNoChangeWork.CreateDateTime;
            goodsNoChange.UpdAssemblyId1 = goodsNoChangeWork.UpdAssemblyId1;
            goodsNoChange.UpdAssemblyId2 = goodsNoChangeWork.UpdAssemblyId2;
            goodsNoChange.UpdEmployeeCode = goodsNoChangeWork.UpdEmployeeCode;
            goodsNoChange.GoodsMakerCd = goodsNoChangeWork.GoodsMakerCd;
            goodsNoChange.OldGoodsNo = goodsNoChangeWork.OldGoodsNo;
            goodsNoChange.NewGoodsNo = goodsNoChangeWork.NewGoodsNo;
            //���[�J�[���擾
            int st = makerAcs.Read(out makerUMnt, goodsNoChange.EnterpriseCode, goodsNoChange.GoodsMakerCd);
            if (st == (int)ConstantManagement.DB_Status.ctDB_NORMAL && makerUMnt != null)
            {
                goodsNoChange.MakerName = makerUMnt.MakerName;
            }

            return goodsNoChange;
        }

        #endregion
    }
}

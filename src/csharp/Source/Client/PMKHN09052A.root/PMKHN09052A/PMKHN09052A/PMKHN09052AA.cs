using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Windows.Forms;


namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ���ʃR�[�h�}�X�^�e�[�u���A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���ʃR�[�h�}�X�^�e�[�u���̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer : 30413 ����</br>
    /// <br>Date       : 2008.06.17</br>
    /// <br></br>
    /// </remarks>
    public class PartsPosCodeUAcs : IGeneralGuideData
    {
        #region Private Member

        /// <summary>�����[�g�I�u�W�F�N�g�i�[�o�b�t�@</summary>
        // ���ʃR�[�h�}�X�^�i���[�U�[�j
        private IPartsPosCodeUDB _iPartsPosCodeUDB = null;
        // ���ʃR�[�h�}�X�^�i�񋟁j
        private IPartsPosCodeDB _iPartsPosCodeDB = null;

        // BL�R�[�h�}�X�^�̃��X�g
        private ArrayList _blGoodsList;

        // 2008.10.20 30413 ���� ���Ӑ���̃L���b�V���ǉ� >>>>>>START
        // ���Ӑ���̃L���b�V��
        private ArrayList _customerList;
        // 2008.10.20 30413 ���� ���Ӑ���̃L���b�V���ǉ� <<<<<<END

        #endregion

        #region Constructor

        /// <summary>
        /// ���ʃR�[�h�}�X�^�e�[�u���A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ʃR�[�h�}�X�^�e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.17</br>
        /// </remarks>
        public PartsPosCodeUAcs()
        {
            try
            {
                // �����[�g�I�u�W�F�N�g�擾
                this._iPartsPosCodeUDB = (IPartsPosCodeUDB)MediationPartsPosCodeUDB.GetPartsPosCodeUDB();
                this._iPartsPosCodeDB = (IPartsPosCodeDB)MediationPartsPosCodeDB.GetPartsPosCodeDB();

                // ���X�g������
                this._blGoodsList = new ArrayList();

                // 2008.10.20 30413 ���� ���Ӑ���̃L���b�V���ǉ� >>>>>>START
                this._customerList = new ArrayList();
                // 2008.10.20 30413 ���� ���Ӑ���̃L���b�V���ǉ� <<<<<<END                
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iPartsPosCodeUDB = null;
                this._iPartsPosCodeDB = null;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// �I�����C�����[�h�擾����
        /// </summary>
        /// <returns>OnlineMode</returns>
        /// <remarks>
        /// <br>Note       : �I�����C�����[�h���擾���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.17</br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if (this._iPartsPosCodeUDB == null)
            {
                return (int)ConstantManagement.OnlineMode.Offline;
            }
            else
            {
                return (int)ConstantManagement.OnlineMode.Online;
            }
        }

        /// <summary>
        /// ���ʃR�[�h�ǂݍ��ݏ���
        /// </summary>
        /// <param name="partsPosCodeU">���ʃR�[�h�I�u�W�F�N�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="partsPosCode">���ʃR�[�h</param>
        /// <param name="tbsPartsCode">BL�R�[�h</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���ʃR�[�h����ǂݍ��݂܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.17</br>
        /// </remarks>
        public int Read(out PartsPosCodeU partsPosCodeU, string enterpriseCode, int partsPosCode, int tbsPartsCode)
        {
            try
            {
                // �L�[���̐ݒ�
                partsPosCodeU = null;
                PartsPosCodeUWork partsPosCodeUWork = new PartsPosCodeUWork();
                partsPosCodeUWork.EnterpriseCode = enterpriseCode;
                partsPosCodeUWork.SearchPartsPosCode = partsPosCode;
                partsPosCodeUWork.TbsPartsCode = tbsPartsCode;

                // ���ʃR�[�h���[�J�[�N���X���I�u�W�F�N�g�ɐݒ�
                object paraObj = (object)partsPosCodeUWork;

                //���ʃR�[�h�ǂݍ���
                int status = this._iPartsPosCodeUDB.Read(ref paraObj, 0);

                if (status == 0)
                {
                    // �ǂݍ��݌��ʂ𕔈ʃR�[�h���[�J�[�N���X�ɐݒ�
                    PartsPosCodeUWork wkPartsPosCodeUWork = (PartsPosCodeUWork)paraObj;
                    // ���ʃR�[�h���[�J�[�N���X���畔�ʃR�[�h�N���X�ɃR�s�[
                    partsPosCodeU = CopyToPartsPosCodeUFromPartsPosCodeUWork(wkPartsPosCodeUWork);
                }

                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iPartsPosCodeUDB = null;
                this._iPartsPosCodeDB = null;
                //�ʐM�G���[��-1��߂�
                partsPosCodeU = null;
                return -1;
            }
        }

        /// <summary>
        /// ���ʃR�[�h�ǂݍ��ݏ���
        /// </summary>
        /// <param name="partsPosCodeU">���ʃR�[�h�I�u�W�F�N�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="partsPosCode">���ʃR�[�h</param>
        /// <param name="tbsPartsCode">BL�R�[�h</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���ʃR�[�h����ǂݍ��݂܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.17</br>
        /// </remarks>
        public int Read(out PartsPosCodeU partsPosCodeU, string enterpriseCode,int customerCode, int partsPosCode, int tbsPartsCode)
        {
            try
            {
                // �L�[���̐ݒ�
                partsPosCodeU = null;
                PartsPosCodeUWork partsPosCodeUWork = new PartsPosCodeUWork();
                partsPosCodeUWork.EnterpriseCode = enterpriseCode;
                partsPosCodeUWork.CustomerCode = customerCode;
                partsPosCodeUWork.SearchPartsPosCode = partsPosCode;
                partsPosCodeUWork.TbsPartsCode = tbsPartsCode;

                // ���ʃR�[�h���[�J�[�N���X���I�u�W�F�N�g�ɐݒ�
                object paraObj = (object)partsPosCodeUWork;

                //���ʃR�[�h�ǂݍ���
                int status = this._iPartsPosCodeUDB.Read(ref paraObj, 0);

                if (status == 0)
                {
                    // �ǂݍ��݌��ʂ𕔈ʃR�[�h���[�J�[�N���X�ɐݒ�
                    PartsPosCodeUWork wkPartsPosCodeUWork = (PartsPosCodeUWork)paraObj;
                    // ���ʃR�[�h���[�J�[�N���X���畔�ʃR�[�h�N���X�ɃR�s�[
                    partsPosCodeU = CopyToPartsPosCodeUFromPartsPosCodeUWork(wkPartsPosCodeUWork);
                }

                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iPartsPosCodeUDB = null;
                this._iPartsPosCodeDB = null;
                //�ʐM�G���[��-1��߂�
                partsPosCodeU = null;
                return -1;
            }
        }

        /// <summary>
        /// ���ʃR�[�h�V���A���C�Y����
        /// </summary>
        /// <param name="partsPosCodeU">�V���A���C�Y�Ώە��ʃR�[�h�N���X</param>
        /// <param name="fileName">�V���A���C�Y�t�@�C����</param>
        /// <remarks>
        /// <br>Note       : ���ʃR�[�h�̃V���A���C�Y���s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.17</br>
        /// </remarks>
        public void Serialize(PartsPosCodeU partsPosCodeU, string fileName)
        {
            // ���ʃR�[�h�N���X���畔�ʃR�[�h���[�J�[�N���X�Ƀ����o�R�s�[
            PartsPosCodeUWork partsPosCodeUWork = CopyToPartsPosCodeUWorkFromPartsPosCodeU(partsPosCodeU);

            // ���ʃR�[�h���[�J�[�N���X���V���A���C�Y
            XmlByteSerializer.Serialize(partsPosCodeUWork, fileName);
        }

        /// <summary>
        /// ���ʃR�[�hList�V���A���C�Y����
        /// </summary>
        /// <param name="arrPartsPosCodeU">�V���A���C�Y�Ώە��ʃR�[�hList�N���X</param>
        /// <param name="fileName">�V���A���C�Y�t�@�C����</param>
        /// <remarks>
        /// <br>Note       : ���ʃR�[�hList���̃V���A���C�Y���s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.17</br>
        /// </remarks>
        public void ListSerialize(ArrayList arrPartsPosCodeU, string fileName)
        {
            PartsPosCodeUWork[] partsPosCodeUWorks = new PartsPosCodeUWork[arrPartsPosCodeU.Count];

            for (int i = 0; i < arrPartsPosCodeU.Count; i++)
            {
                partsPosCodeUWorks[i] = CopyToPartsPosCodeUWorkFromPartsPosCodeU((PartsPosCodeU)arrPartsPosCodeU[i]);
            }

            // ���ʃR�[�h���[�J�[�N���X���V���A���C�Y
            XmlByteSerializer.Serialize(partsPosCodeUWorks, fileName);
        }

        /// <summary>
        /// ���ʃR�[�h�N���X�f�V���A���C�Y����
        /// </summary>
        /// <param name="fileName">�f�V���A���C�Y�Ώ�XML�t�@�C���t���p�X</param>
        /// <returns>���ʃR�[�h�N���X</returns>
        /// <remarks>
        /// <br>Note       : ���ʃR�[�h�N���X���f�V���A���C�Y���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.17</br>
        /// </remarks>
        public PartsPosCodeU Deserialize(string fileName)
        {
            PartsPosCodeU partsPosCodeU = null;

            // �t�@�C������n���ĕ��ʃR�[�h���[�N�N���X���f�V���A���C�Y����
            PartsPosCodeUWork partsPosCodeUWork = (PartsPosCodeUWork)XmlByteSerializer.Deserialize(fileName, typeof(PartsPosCodeUWork));

            // �f�V���A���C�Y���ʂ𕔈ʃR�[�h�N���X�փR�s�[
            if (partsPosCodeUWork != null) partsPosCodeU = CopyToPartsPosCodeUFromPartsPosCodeUWork(partsPosCodeUWork);

            return partsPosCodeU;
        }

        /// <summary>
        /// ���ʃR�[�h�o�^�E�X�V����
        /// </summary>
        /// <param name="partsPosCodeUList">���ʃR�[�h�N���X</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���ʃR�[�h�̓o�^�E�X�V���s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.17</br>
        /// </remarks>
        public int Write(ref ArrayList partsPosCodeUList)
        {
            PartsPosCodeUWork partsPosCodeUWork = new PartsPosCodeUWork();
            ArrayList paraList = new ArrayList();
                
            foreach (PartsPosCodeU wkPartsPosCodeU in partsPosCodeUList)
            {
                // ���ʃR�[�h�N���X���畔�ʃR�[�h���[�N�N���X�Ƀ����o�R�s�[
                partsPosCodeUWork = CopyToPartsPosCodeUWorkFromPartsPosCodeU(wkPartsPosCodeU);

                // ���ʃR�[�h�̓o�^�E�X�V����ݒ�
                paraList.Add(partsPosCodeUWork);            
            }
            
            object paraObj = paraList;

            int status = 0;
            try
            {
                // ���ʃR�[�h��������
                status = this._iPartsPosCodeUDB.Write(ref paraObj);

                if (status == 0)
                {
                    paraList = (ArrayList)paraObj;
                    partsPosCodeUList.Clear();

                    foreach (PartsPosCodeUWork wkPartsPosCodeUWork in paraList)
                    {
                        PartsPosCodeU partsPosCodeU = new PartsPosCodeU();
                        // ���ʃR�[�h���[�N�N���X���畔�ʃR�[�h�N���X�Ƀ����o�R�s�[
                        partsPosCodeU = this.CopyToPartsPosCodeUFromPartsPosCodeUWork((PartsPosCodeUWork)wkPartsPosCodeUWork);
                        partsPosCodeUList.Add(partsPosCodeU);
                    }
                }
            }
            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
                this._iPartsPosCodeUDB = null;
                this._iPartsPosCodeDB = null;
                // �ʐM�G���[��-1��߂�
                status = -1;
            }

            return status;
        }

        /// <summary>
        /// ���ʃR�[�h���̘_���폜����
        /// </summary>
        /// <param name="partsPosCodeUList">���ʃR�[�h�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���ʃR�[�h���̘_���폜���s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.20</br>
        /// </remarks>
        public int LogicalDelete(ref ArrayList partsPosCodeUList)
        {
            int status = 0;

            try
            {
                PartsPosCodeUWork partsPosCodeUWork = new PartsPosCodeUWork();
                ArrayList paraList = new ArrayList();

                foreach (PartsPosCodeU wkPartsPosCodeU in partsPosCodeUList)
                {
                    // ���ʃR�[�h�N���X���畔�ʃR�[�h���[�N�N���X�Ƀ����o�R�s�[
                    partsPosCodeUWork = CopyToPartsPosCodeUWorkFromPartsPosCodeU(wkPartsPosCodeU);
                    // ���ʃR�[�h�̘_���폜����ݒ�
                    paraList.Add(partsPosCodeUWork);
                }

                object paraObj = paraList;

                // ���ʃR�[�h�N���X�_���폜
                status = this._iPartsPosCodeUDB.LogicalDelete(ref paraObj);

                if (status == 0)
                {
                    paraList = (ArrayList)paraObj;
                    partsPosCodeUList.Clear();

                    foreach (PartsPosCodeUWork wkPartsPosCodeUWork in paraList)
                    {
                        PartsPosCodeU partsPosCodeU = new PartsPosCodeU();
                        // ���ʃR�[�h���[�N�N���X���畔�ʃR�[�h�N���X�Ƀ����o�R�s�[
                        partsPosCodeU = this.CopyToPartsPosCodeUFromPartsPosCodeUWork((PartsPosCodeUWork)wkPartsPosCodeUWork);
                        partsPosCodeUList.Add(partsPosCodeU);
                    }
                }

                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iPartsPosCodeUDB = null;
                this._iPartsPosCodeDB = null;
                //�ʐM�G���[��-1��߂�
                return -1;
            }
        }

        /// <summary>
        /// ���ʃR�[�h�����폜����
        /// </summary>
        /// <param name="partsPosCodeUList">���ʃR�[�h�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���ʃR�[�h���̕����폜���s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.20</br>
        /// </remarks>
        public int Delete(ArrayList partsPosCodeUList)
        {
            try
            {
                PartsPosCodeUWork partsPosCodeUWork = new PartsPosCodeUWork();
                ArrayList paraList = new ArrayList();

                foreach (PartsPosCodeU wkPartsPosCodeU in partsPosCodeUList)
                {
                    // ���ʃR�[�h�N���X���畔�ʃR�[�h���[�N�N���X�Ƀ����o�R�s�[
                    partsPosCodeUWork = CopyToPartsPosCodeUWorkFromPartsPosCodeU(wkPartsPosCodeU);

                    // ���ʃR�[�h�̓o�^�E�X�V����ݒ�
                    paraList.Add(partsPosCodeUWork);
                }

                object paraObj = paraList;

                // ���ʃR�[�h�����폜
                int status = this._iPartsPosCodeUDB.Delete(paraObj);

                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iPartsPosCodeUDB = null;
                this._iPartsPosCodeDB = null;
                //�ʐM�G���[��-1��߂�
                return -1;
            }
        }

        /// <summary>
        /// ���ʃR�[�h�_���폜��������
        /// </summary>
        /// <param name="partsPosCodeUList">���ʃR�[�h���̃I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���ʃR�[�h���̕������s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.20</br>
        /// </remarks>
        public int Revival(ref ArrayList partsPosCodeUList)
        {
            try
            {
                PartsPosCodeUWork partsPosCodeUWork = new PartsPosCodeUWork();
                ArrayList paraList = new ArrayList();

                foreach (PartsPosCodeU wkPartsPosCodeU in partsPosCodeUList)
                {
                    // ���ʃR�[�h�N���X���畔�ʃR�[�h���[�N�N���X�Ƀ����o�R�s�[
                    partsPosCodeUWork = CopyToPartsPosCodeUWorkFromPartsPosCodeU(wkPartsPosCodeU);
                    // ���ʃR�[�h�̕�������ݒ�
                    paraList.Add(partsPosCodeUWork);
                }

                object paraobj = paraList;

                // ��������
                int status = this._iPartsPosCodeUDB.RevivalLogicalDelete(ref paraobj);

                if (status == 0)
                {
                    paraList = (ArrayList)paraobj;
                    partsPosCodeUList.Clear();

                    foreach (PartsPosCodeUWork wkPartsPosCodeUWork in paraList)
                    {
                        PartsPosCodeU partsPosCodeU = new PartsPosCodeU();
                        // ���ʃR�[�h���[�N�N���X���畔�ʃR�[�h�N���X�Ƀ����o�R�s�[
                        partsPosCodeU = this.CopyToPartsPosCodeUFromPartsPosCodeUWork((PartsPosCodeUWork)wkPartsPosCodeUWork);
                        partsPosCodeUList.Add(partsPosCodeU);
                    }
                }
                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iPartsPosCodeUDB = null;
                this._iPartsPosCodeDB = null;
                //�ʐM�G���[��-1��߂�
                return -1;
            }
        }

        /// <summary>
        /// ���ʃR�[�h�}�X�^���������iDataSet�p�j
        /// </summary>
        /// <param name="ds">�擾���ʊi�[�pDataSet</param>
        /// <param name="belongPartsPosCode">���ʃR�[�h</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note        : �擾���ʂ�DataSet�ŕԂ��܂��B</br>
        /// <br>Programmer	: 30413 ����</br>
        /// <br>Date		: 2008.06.17</br>
        /// </remarks>
        public int Search(ref DataSet ds,int belongPartsPosCode, string enterpriseCode)
        {
            ArrayList retList = new ArrayList();

            int status = 0;
            int retTotalCnt;
            bool nextData;
            // ���ʃR�[�h�}�X�^�i�񋟁j�T�[�`
            status = SearchPartsPosCodeOfrProc(belongPartsPosCode, ref retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData0, 0, null);
            if (status != 0)
            {
                return status;
            }

            ArrayList wkList = retList.Clone() as ArrayList;
            SortedList wkSort = new SortedList();

            // --- [�S��] --- //
            // ���̂܂ܑS���Ԃ�
            foreach (PartsPosCodeU wkPartsPosCodeU in wkList)
            {
                // �_���폜�f�[�^��BL�R�[�h���[���͑ΏۊO
                if ((wkPartsPosCodeU.LogicalDeleteCode == 0) && (wkPartsPosCodeU.TbsPartsCode != 0))
                {
                    string key = wkPartsPosCodeU.SearchPartsPosCode.ToString("d2") + wkPartsPosCodeU.PosDispOrder.ToString("d4") + wkPartsPosCodeU.TbsPartsCode.ToString("d8");
                    wkSort.Add(key, wkPartsPosCodeU);
                }
            }

            PartsPosCodeU[] partsPosCodeUs = new PartsPosCodeU[wkSort.Count];

            // �f�[�^�����ɖ߂�
            for (int i = 0; i < wkSort.Count; i++)
            {
                partsPosCodeUs[i] = (PartsPosCodeU)wkSort.GetByIndex(i);
            }

            byte[] retbyte = XmlByteSerializer.Serialize(partsPosCodeUs);
            XmlByteSerializer.ReadXml(ref ds, retbyte);

            return status;
        }

        /// <summary>
        /// ���ʃR�[�h�S���������i�_���폜�܂ށj
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���ʃR�[�h�̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.17</br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode)
        {
            bool nextData;
            int retTotalCnt;
            int status = 0;
            int customerCode = 0;
            int partsPosCode = 0;
            ArrayList list = new ArrayList();

            retList = new ArrayList();
            retList.Clear();
            retTotalCnt = 0;

            // ���[�U�[
            status = SearchPartsPosCodeUProc(customerCode, partsPosCode, ref list, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetDataAll, 0, null);

            // 2008.10.20 30413 ���� �񋟃f�[�^�͓ǂݍ��܂Ȃ� >>>>>>START
            //switch (status)
            //{
            //    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
            //    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
            //    case (int)ConstantManagement.DB_Status.ctDB_EOF:
            //        break;
            //    default:
            //        return status;
            //}

            //// ��
            //status = SearchPartsPosCodeOfrProc(partsPosCode, ref list, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetDataAll, 0, null);

            //// �������ʌ�����0���ȊO�ł���΃X�e�[�^�X��0(����)�ɐݒ�
            //if (retTotalCnt != 0)
            //{
            //    status = 0;
            //}
            // 2008.10.20 30413 ���� �񋟃f�[�^�͓ǂݍ��܂Ȃ� <<<<<<END
            
            retList = list;

            return status;
        }

        /// <summary>
        /// ���ʃR�[�h���������i�_���폜�܂ށj
        /// </summary>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="partsPosCode">���ʃR�[�h</param>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���ʃR�[�h�̌����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.10.20</br>
        /// </remarks>
        public int SearchSelect(int customerCode, int partsPosCode, out ArrayList retList, string enterpriseCode)
        {
            bool nextData;
            int retTotalCnt;
            int status = 0;
            ArrayList list = new ArrayList();

            retList = new ArrayList();
            retList.Clear();
            retTotalCnt = 0;

            // ���[�U�[
            status = SearchPartsPosCodeUProc(customerCode, partsPosCode, ref list, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetDataAll, 0, null);

            retList = list;

            return status;
        }

        /// <summary>
        /// ���Ӑ旪�̎擾����(Public Methods)
        /// </summary>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>���Ӑ旪��</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ旪�̂��擾���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008/10/21</br>
        /// </remarks>
        public void SerachCustomerInfo(int customerCode, string enterpriseCode, out string customerSnm)
        {
            // ���Ӑ旪�̂̎擾
            customerSnm = this.GetCustomerSnm(customerCode, enterpriseCode);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// �N���X�����o�[�R�s�[�����i���ʃR�[�h���[�N�N���X�˕��ʃR�[�h�N���X�j
        /// </summary>
        /// <param name="partsPosCodeUWork">���ʃR�[�h���[�N�N���X</param>
        /// <returns>���ʃR�[�h�N���X</returns>
        /// <remarks>
        /// <br>Note       : ���ʃR�[�h���[�N�N���X���畔�ʃR�[�h�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.17</br>
        /// </remarks>
        private PartsPosCodeU CopyToPartsPosCodeUFromPartsPosCodeUWork(PartsPosCodeUWork partsPosCodeUWork)
        {
            PartsPosCodeU partsPosCodeU = new PartsPosCodeU();

            partsPosCodeU.CreateDateTime = partsPosCodeUWork.CreateDateTime;
            partsPosCodeU.UpdateDateTime = partsPosCodeUWork.UpdateDateTime;
            partsPosCodeU.EnterpriseCode = partsPosCodeUWork.EnterpriseCode;
            partsPosCodeU.FileHeaderGuid = partsPosCodeUWork.FileHeaderGuid;
            partsPosCodeU.UpdEmployeeCode = partsPosCodeUWork.UpdEmployeeCode;
            partsPosCodeU.UpdAssemblyId1 = partsPosCodeUWork.UpdAssemblyId1;
            partsPosCodeU.UpdAssemblyId2 = partsPosCodeUWork.UpdAssemblyId2;
            partsPosCodeU.LogicalDeleteCode = partsPosCodeUWork.LogicalDeleteCode;

            // 2008.10.20 30413 ���� ���Ӑ�̒ǉ� >>>>>>START
            partsPosCodeU.SectionCode = partsPosCodeUWork.SectionCode;                      // ���_�R�[�h(���g�p)
            partsPosCodeU.CustomerCode = partsPosCodeUWork.CustomerCode;                    // ���Ӑ�R�[�h
            partsPosCodeU.CustomerSnm = GetCustomerSnm(partsPosCodeUWork.CustomerCode, partsPosCodeUWork.EnterpriseCode);   // ���Ӑ旪��
            // 2008.10.20 30413 ���� ���Ӑ�̒ǉ� <<<<<<END
            partsPosCodeU.SearchPartsPosCode = partsPosCodeUWork.SearchPartsPosCode;        // �������ʃR�[�h
            partsPosCodeU.SearchPartsPosName = partsPosCodeUWork.SearchPartsPosName;        // �������ʃR�[�h����
            partsPosCodeU.PosDispOrder = partsPosCodeUWork.PosDispOrder;                    // �������ʕ\������
            partsPosCodeU.TbsPartsCode = partsPosCodeUWork.TbsPartsCode;                    // BL�R�[�h
            partsPosCodeU.TbsPartsCdDerivedNo = partsPosCodeUWork.TbsPartsCdDerivedNo;      // BL�R�[�h�}��
            partsPosCodeU.TbsPartsName = GetTbsPartsName(partsPosCodeUWork.TbsPartsCode, partsPosCodeUWork.EnterpriseCode);   // BL����
            partsPosCodeU.Division = 0;
            partsPosCodeU.DivisionName = "���[�U�[";

            return partsPosCodeU;
        }

        /// <summary>
        /// �N���X�����o�[�R�s�[�����i���ʃR�[�h�N���X�˕��ʃR�[�h���[�N�N���X�j
        /// </summary>
        /// <param name="partsPosCodeU">���ʃR�[�h���[�N�N���X</param>
        /// <returns>���ʃR�[�h�N���X</returns>
        /// <remarks>
        /// <br>Note       : ���ʃR�[�h�N���X���畔�ʃR�[�h���[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.17</br>
        /// </remarks>
        private PartsPosCodeUWork CopyToPartsPosCodeUWorkFromPartsPosCodeU(PartsPosCodeU partsPosCodeU)
        {
            PartsPosCodeUWork partsPosCodeUWork = new PartsPosCodeUWork();

            partsPosCodeUWork.CreateDateTime = partsPosCodeU.CreateDateTime;
            partsPosCodeUWork.UpdateDateTime = partsPosCodeU.UpdateDateTime;
            partsPosCodeUWork.EnterpriseCode = partsPosCodeU.EnterpriseCode;
            partsPosCodeUWork.FileHeaderGuid = partsPosCodeU.FileHeaderGuid;
            partsPosCodeUWork.UpdEmployeeCode = partsPosCodeU.UpdEmployeeCode;
            partsPosCodeUWork.UpdAssemblyId1 = partsPosCodeU.UpdAssemblyId1;
            partsPosCodeUWork.UpdAssemblyId2 = partsPosCodeU.UpdAssemblyId2;
            partsPosCodeUWork.LogicalDeleteCode = partsPosCodeU.LogicalDeleteCode;

            // 2008.10.20 30413 ���� ���Ӑ�̒ǉ� >>>>>>START
            partsPosCodeUWork.CustomerCode = partsPosCodeU.CustomerCode;                    // ���Ӑ�R�[�h
            // 2008.10.20 30413 ���� ���Ӑ�̒ǉ� <<<<<<END
            partsPosCodeUWork.SearchPartsPosCode = partsPosCodeU.SearchPartsPosCode;        // �������ʃR�[�h
            partsPosCodeUWork.SearchPartsPosName = partsPosCodeU.SearchPartsPosName;        // �������ʃR�[�h����
            partsPosCodeUWork.PosDispOrder = partsPosCodeU.PosDispOrder;                    // �������ʕ\������
            partsPosCodeUWork.TbsPartsCode = partsPosCodeU.TbsPartsCode;                    // BL�R�[�h
            partsPosCodeUWork.TbsPartsCdDerivedNo = partsPosCodeU.TbsPartsCdDerivedNo;      // BL�R�[�h�}��
            
            return partsPosCodeUWork;
        }

        /// <summary>
        /// �N���X�����o�[�R�s�[�����i���ʃR�[�h�i�񋟁j���[�N�N���X�˕��ʃR�[�h�N���X�j
        /// </summary>
        /// <param name="partsPosCodeWork">���ʃR�[�h�i�񋟁j���[�N�N���X</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>���ʃR�[�h�N���X</returns>
        /// <remarks>
        /// <br>Note       : ���ʃR�[�h�i�񋟁j���[�N�N���X���畔�ʃR�[�h�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.17</br>
        /// </remarks>
        private PartsPosCodeU CopyToPartsPosCodeUFromPartsPosCodeWork(PartsPosCodeWork partsPosCodeWork, string enterpriseCode)
        {
            PartsPosCodeU partsPosCodeU = new PartsPosCodeU();

            partsPosCodeU.SearchPartsPosCode = partsPosCodeWork.SearchPartsPosCode;         // �������ʃR�[�h
            partsPosCodeU.SearchPartsPosName = partsPosCodeWork.SearchPartsPosName;         // �������ʃR�[�h����
            partsPosCodeU.PosDispOrder = partsPosCodeWork.PosDispOrder;                     // �������ʕ\������
            partsPosCodeU.TbsPartsCode = partsPosCodeWork.TbsPartsCode;                     // BL�R�[�h
            partsPosCodeU.TbsPartsCdDerivedNo = partsPosCodeWork.TbsPartsCdDerivedNo;       // BL�R�[�h�}��
            partsPosCodeU.TbsPartsName = GetTbsPartsName(partsPosCodeWork.TbsPartsCode, enterpriseCode);    // BL����
            partsPosCodeU.Division = 1;
            partsPosCodeU.DivisionName = "��";

            return partsPosCodeU;
        }

        /// <summary>
        /// �N���X�����o�[�R�s�[�����i���ʃR�[�h�N���X�˕��ʃR�[�h�i�񋟁j���[�N�N���X�j
        /// </summary>
        /// <param name="partsPosCodeU">���ʃR�[�h���[�N�N���X</param>
        /// <returns>���ʃR�[�h�i�񋟁j�N���X</returns>
        /// <remarks>
        /// <br>Note       : ���ʃR�[�h�N���X���畔�ʃR�[�h�i�񋟁j���[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.17</br>
        /// </remarks>
        private PartsPosCodeWork CopyToPartsPosCodeWorkFromPartsPosCodeU(PartsPosCodeU partsPosCodeU)
        {
            PartsPosCodeWork partsPosCodeWork = new PartsPosCodeWork();

            partsPosCodeWork.SearchPartsPosCode = partsPosCodeU.SearchPartsPosCode;         // �������ʃR�[�h
            partsPosCodeWork.SearchPartsPosName = partsPosCodeU.SearchPartsPosName;         // �������ʃR�[�h����
            partsPosCodeWork.PosDispOrder = partsPosCodeU.PosDispOrder;                     // �������ʕ\������
            partsPosCodeWork.TbsPartsCode = partsPosCodeU.TbsPartsCode;                     // BL�R�[�h
            partsPosCodeWork.TbsPartsCdDerivedNo = partsPosCodeU.TbsPartsCdDerivedNo;       // BL�R�[�h�}��
            
            return partsPosCodeWork;
        }

        /// <summary>
        /// ���ʃR�[�h��������
        /// </summary>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="partsPosCode">���ʃR�[�h</param>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������(prevEmployee��null�̏ꍇ�̂ݖ߂�)</param>
        /// <param name="nextData">���f�[�^�L��</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�S�f�[�^)</param>
        /// <param name="readCnt">�Ǎ�����</param>
        /// <param name="prevPartsPosCodeU">�O��ŏI���ʃR�[�h�f�[�^�I�u�W�F�N�g�i�����null�w��K�{�j</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���ʃR�[�h�̌����������s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.17</br>
        /// </remarks>
        private int SearchPartsPosCodeUProc(Int32 customerCode, Int32 partsPosCode, ref ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, PartsPosCodeU prevPartsPosCodeU)
        {
            PartsPosCodeUWork partsPosCodeUWork = new PartsPosCodeUWork();

            // ���f�[�^�L��������
            nextData = false;
            // �Ǎ��Ώۃf�[�^������0�ŏ�����
            retTotalCnt = 0;

            int status = 0;

            ArrayList workList = new ArrayList();
            object retObj = workList;

            if (retList.Count == 0)
            {
                // ���o�����ݒ�
                partsPosCodeUWork.CustomerCode = customerCode;
                partsPosCodeUWork.SearchPartsPosCode = partsPosCode;
                partsPosCodeUWork.EnterpriseCode = enterpriseCode;

                // ���ʃR�[�h���[�J�[�N���X���I�u�W�F�N�g�ɐݒ�
                object paraObj = (object)partsPosCodeUWork;

                // �S���Ǎ�
                status = this._iPartsPosCodeUDB.Search(ref retObj, paraObj, 0, logicalMode);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        workList = retObj as ArrayList;
                        if (workList != null)
                        {
                            foreach (PartsPosCodeUWork wkPartsPosCodeUWork in workList)
                            {
                                // �����[�g�p�����[�^�f�[�^ �� �f�[�^�N���X
                                PartsPosCodeU wkPartsPosCodeU = CopyToPartsPosCodeUFromPartsPosCodeUWork(wkPartsPosCodeUWork);
                                // �f�[�^�N���X��Ǎ����ʂփR�s�[
                                retList.Add(wkPartsPosCodeU);
                                
                            }
                        }
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        break;
                    default:
                        return status;
                }
            }

            // �S�����[�h�̏ꍇ�͖߂�l�̌������Z�b�g
            if (readCnt == 0) retTotalCnt = retList.Count;

            return status;
        }

        /// <summary>
        /// ���ʃR�[�h�i�񋟁j��������
        /// </summary>
        /// <param name="partsPosCode">���ʃR�[�h</param>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������(prevEmployee��null�̏ꍇ�̂ݖ߂�)</param>
        /// <param name="nextData">���f�[�^�L��</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�S�f�[�^)</param>
        /// <param name="readCnt">�Ǎ�����</param>
        /// <param name="prevPartsPosCodeU">�O��ŏI���ʃR�[�h�}�X�^�i�񋟁j�f�[�^�I�u�W�F�N�g�i�����null�w��K�{�j</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���ʃR�[�h�}�X�^�i�񋟁j�̌����������s���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008.06.17</br>
        /// </remarks>
        private int SearchPartsPosCodeOfrProc(Int32 partsPosCode, ref ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, PartsPosCodeU prevPartsPosCodeU)
        {
            PartsPosCodeWork partsPosCodeWork = new PartsPosCodeWork();

            // ���f�[�^�L��������
            nextData = false;
            // �Ǎ��Ώۃf�[�^������0�ŏ�����
            retTotalCnt = 0;

            int status = 0;

            ArrayList workList = new ArrayList();
            object retObj = workList;
            SortedList sortWk = new SortedList();

            // �Z�L�����e�B���x���L�[�w��
            partsPosCodeWork.SearchPartsPosCode = partsPosCode;

            // USB�m�F
            // ��^�񋟋敪
            if ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_BigCarOfferData) > 0)
            {
                partsPosCodeWork.BigCarOfferDiv = 1;
            }
            else
            {
                partsPosCodeWork.BigCarOfferDiv = 0;
            }

            // �����^�C�v
            // �����l��-1
            partsPosCodeWork.SearchPartsType = -1;
            if ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_BasicOfferData) > 0)
            {
                // ��{
                partsPosCodeWork.SearchPartsType = 0;
            }
            //if ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_ExtOfferData) > 0)
            //{
            //    // �g��
            //    partsPosCodeWork.SearchPartsType = 10;
            //}
            if ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_OutsideOfferData) > 0)
            {
                // �O��
                partsPosCodeWork.SearchPartsType = 20;
            }

            // �����^�C�v��-1�̏ꍇ�A�񋟃}�X�^��ǂݍ��܂Ȃ��ŏI��
            if (partsPosCodeWork.SearchPartsType == -1)
            {
                return status;
            }

            // ���ʃR�[�h�i�񋟁j���[�J�[�N���X���I�u�W�F�N�g�ɐݒ�
            object paraObj = (object)partsPosCodeWork;

            // �S���Ǎ�
            status = this._iPartsPosCodeDB.Search(out retObj, paraObj);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    workList = retObj as ArrayList;
                    if (workList != null)
                    {
                        foreach (PartsPosCodeWork wkPartsPosCodeWork in workList)
                        {
                            // �����[�g�p�����[�^�f�[�^ �� �f�[�^�N���X
                            PartsPosCodeU wkPartsPosCodeU = CopyToPartsPosCodeUFromPartsPosCodeWork(wkPartsPosCodeWork, enterpriseCode);
                            // �f�[�^�N���X��Ǎ����ʂփR�s�[
                            retList.Add(wkPartsPosCodeU);
                        }
                    }
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    break;
                default:
                    return status;
            }

            // �S�����[�h�̏ꍇ�͖߂�l�̌������Z�b�g
            if (readCnt == 0) retTotalCnt = retList.Count;

            return status;
        }

        /// <summary>
        /// �a�k���̎擾����
        /// </summary>
        /// <param name="tbsPartsCode">�a�k�R�[�h</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>�a�k����</returns>
        /// <remarks>
        /// <br>Note       : �a�k���̂��擾���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008/06/20</br>
        /// </remarks>
        private string GetTbsPartsName(int tbsPartsCode, string enterpriseCode)
        {
            string tbsPartsName = "";

            int status;
            ArrayList retList;
            BLGoodsCdAcs blGoodsCdAcs = new BLGoodsCdAcs();

            try
            {
                if (this._blGoodsList.Count == 0)
                {
                    status = blGoodsCdAcs.SearchAll(out retList, enterpriseCode);
                    if (status == 0)
                    {
                        if (retList.Count <= 0)
                        {
                            return tbsPartsName;
                        }

                        foreach (BLGoodsCdUMnt blGoodsCdUMnt in retList)
                        {
                            this._blGoodsList.Add(blGoodsCdUMnt);
                        }
                    }
                }

                foreach (BLGoodsCdUMnt blGoodsCdUMnt in this._blGoodsList)
                {
                    if (blGoodsCdUMnt.BLGoodsCode == tbsPartsCode)
                    {
                        tbsPartsName = blGoodsCdUMnt.BLGoodsFullName.Trim();
                        return tbsPartsName;
                    }
                }
            }
            catch
            {
                tbsPartsName = "";
            }

            return tbsPartsName;
        }

        /// <summary>
        /// ���Ӑ旪�̎擾����
        /// </summary>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>���Ӑ旪��</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ旪�̂��擾���܂��B</br>
        /// <br>Programmer : 30413 ����</br>
        /// <br>Date       : 2008/10/20</br>
        /// </remarks>
        private string GetCustomerSnm(int customerCode, string enterpriseCode)
        {
            string customerSnm = "";

            int status;
            CustomerSearchAcs customerSearchAcs = new CustomerSearchAcs();

            CustomerSearchRet[] customerSearchRetArray;
            CustomerSearchPara customerSearchPara = new CustomerSearchPara();
            customerSearchPara.EnterpriseCode = enterpriseCode;

            try
            {
                if (this._customerList.Count == 0)
                {
                    status = customerSearchAcs.Serch(out customerSearchRetArray, customerSearchPara);
                    if (status == 0)
                    {
                        if (customerSearchRetArray.Length <= 0)
                        {
                            return customerSnm;
                        }

                        foreach (CustomerSearchRet customerSearchRet in customerSearchRetArray)
                        {
                            // �_���폜�f�[�^�͓ǂݍ��܂Ȃ�
                            if (customerSearchRet.LogicalDeleteCode != 1)
                            {
                                this._customerList.Add(customerSearchRet);
                            }
                        }
                    }
                }

                foreach (CustomerSearchRet customerSearchRet in this._customerList)
                {
                    if (customerSearchRet.CustomerCode == customerCode)
                    {
                        customerSnm = customerSearchRet.Snm.Trim();
                        return customerSnm;
                    }
                }
            }
            catch
            {
                customerSnm = "";
            }

            return customerSnm;
        }

        #endregion

        #region Guid Methods

        /// <summary>
        /// �ėp�K�C�h�f�[�^�擾(IGeneralGuidData�C���^�[�t�F�[�X����)
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="inParm"></param>
        /// <param name="guideList"></param>
        /// <returns>STATUS[0:�擾����,1:�L�����Z��,4:���R�[�h����]</returns>
        /// <remarks>
        /// <br>Note		: �ėp�K�C�h�ݒ�p�f�[�^���擾���܂��B</br>
        /// <br>Programmer	: 30413 ����</br>
        /// <br>Date		: 2008.06.17</br>
        /// </remarks>
        public int GetGuideData(int mode, Hashtable inParm, ref DataSet guideList)
        {
            int status = -1;
            int partsPosCode = 0;
            string enterpriseCode = "";

            // ���ʃR�[�h�A��ƃR�[�h�ݒ�L��
            if ((inParm.ContainsKey("SearchPartsPosCode")) && (inParm.ContainsKey("EnterpriseCode")))
            {
                partsPosCode = (int)inParm["SearchPartsPosCode"];
                enterpriseCode = inParm["EnterpriseCode"].ToString();
            }
            // ���ʃR�[�h�A��ƃR�[�h�ݒ薳��
            else
            {
                // �L�蓾�Ȃ��̂ŃG���[
                return status;
            }

            // ���ʃR�[�h�}�X�^�e�[�u���Ǎ���
            status = Search(ref guideList, partsPosCode, enterpriseCode);

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

        /// <summary>
        /// ���ʃR�[�h�}�X�^�K�C�h�N������
        /// </summary>
        /// <param name="partsPosCode">���ʃR�[�h</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="partsPosCodeU">�擾�f�[�^</param>
        /// <returns>STATUS[0:�擾����,1:�L�����Z��]</returns>
        /// <remarks>
        /// <br>Note		: ���ʃR�[�h�}�X�^�̈ꗗ�\���@�\�����K�C�h���N�����܂��B</br>
        /// <br>Programmer	: 30413 ����</br>
        /// <br>Date		: 2008.06.17</br>
        /// </remarks>
        public int ExecuteGuid(int partsPosCode, string enterpriseCode, out PartsPosCodeU partsPosCodeU)
        {
            int status = -1;
            partsPosCodeU = new PartsPosCodeU();

            TableGuideParent tableGuideParent = new TableGuideParent("PARTPOSCODEGUIDEPARENT.XML");
            Hashtable inObj = new Hashtable();
            Hashtable retObj = new Hashtable();

            // ���ʃR�[�h
            inObj.Add("SearchPartsPosCode", partsPosCode);
            // ��ƃR�[�h
            inObj.Add("EnterpriseCode", enterpriseCode);

            if (tableGuideParent.Execute(0, inObj, ref retObj))
            {
                // �������ʃR�[�h
                string strCode = retObj["SearchPartsPosCode"].ToString();
                partsPosCodeU.SearchPartsPosCode = int.Parse(strCode);

                // �������ʃR�[�h����
                partsPosCodeU.SearchPartsPosName = retObj["SearchPartsPosName"].ToString();

                // �������ʕ\������
                strCode = retObj["PosDispOrder"].ToString();
                partsPosCodeU.PosDispOrder = int.Parse(strCode);

                // BL�R�[�h
                strCode = retObj["TbsPartsCode"].ToString();
                partsPosCodeU.TbsPartsCode = int.Parse(strCode);
                
                // BL�R�[�h�}��
                strCode = retObj["TbsPartsCdDerivedNo"].ToString();
                partsPosCodeU.TbsPartsCdDerivedNo = int.Parse(strCode);

                // BL����
                partsPosCodeU.TbsPartsName = retObj["TbsPartsName"].ToString();
                status = 0;
            }
            // �L�����Z��
            else
            {
                status = 1;
            }

            return status;
        }

        #endregion
    }
}

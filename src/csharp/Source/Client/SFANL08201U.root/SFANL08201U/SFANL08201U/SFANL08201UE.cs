using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;


namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �ŏI���o������I/O�N���X�ł�
    /// </summary>
	class FPprECndAcs
	{
        /// <summary>�w�l�k�t�@�C������ݒ�(���R���[���o����)</summary>
        private string _fileNameGr;
        /// <summary>�w�l�k�t�@�C���p�X(���R���[���o����)</summary>
        private string _filePathGr;
        /// <summary>�w�l�k�t�@�C������ݒ�(���R���[���o��������)</summary>
        private string _fileNameDt;
        /// <summary>�w�l�k�t�@�C���p�X(���R���[���o��������)</summary>
        private string _filePathDt;

        /// <summary>�f�[�^�o�b�t�@(���R���[���o����)</summary>
        private static List<FrePprECnd> _buff_FrePprECnd = null;
        /// <summary>�f�[�^�o�b�t�@(���R���[���o��������)</summary>
        private static List<FrePExCndD> _buff_FrePExCndD = null;


        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        #region constructor
        /// <summary>
		/// ���R���[�O�񒊏o�����A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : ���R���[�O�񒊏o�����A�N�Z�X�N���X�R���X�g���N�^</br>
		/// <br>Programmer : 22011 ���� ���l</br>
		/// <br>Date       : 2007.04.17</br>
		/// </remarks>
        public FPprECndAcs()
		{
			try
			{
                // �w�l�k�t�@�C������ݒ�(���R���[���o����)
				this._fileNameGr = "FrePprECnd.xml";
                // �w�l�k�t�@�C���p�X(���R���[���o����)
                this._filePathGr = ConstantManagement_ClientDirectory.LocalApplicationData_AppSettingData + "\\" + _fileNameGr;
                // �w�l�k�t�@�C������ݒ�(���R���[���o��������)
                this._fileNameDt = "FrePprECndDt.xml";
                // �w�l�k�t�@�C���p�X(���R���[���o��������)
                this._filePathDt = ConstantManagement_ClientDirectory.LocalApplicationData_AppSettingData + "\\" + _fileNameDt;
            }
			catch (Exception)
			{
			}
        }
        #endregion

        #region public Methods

        #region ���R���[���o�����ǂݍ��ݏ���(Read)
        /// <summary>
        /// ���R���[���o�����ǂݍ��ݏ���
        /// </summary>
        /// <param name="frePprECndLs">���R���[���o�����I�u�W�F�N�g�̃R���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="outputFormFileName">�o�̓t�@�C����</param>
        /// <param name="userPrtPprIdDerivNo">���[�U�[���[ID�}��</param>
        /// <returns>���R���[���o�����N���X</returns>
        /// <remarks>
        /// <br>Note       : ���R���[���o��������ǂݍ��݂܂��B�󎚈ʒu�ݒ�}�X�^�P���R�[�h�P�ʂŊ֘A��������擾���܂��B</br>
        /// <br>Programmer : 22011 ���� ���l</br>
        /// <br>Date       : 2007.04.17</br>
        /// </remarks>
        public int Read(out List<FrePprECnd> frePprECndLs, string enterpriseCode, string outputFormFileName, int userPrtPprIdDerivNo)
        {
            frePprECndLs = new List<FrePprECnd>();
            
            try
            {
                int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                // �f�[�^��r�p�p�����[�^
                FrePprECnd frePprECndPara = new FrePprECnd();
                frePprECndPara.EnterpriseCode = enterpriseCode;
                frePprECndPara.OutputFormFileName = outputFormFileName;
                frePprECndPara.UserPrtPprIdDerivNo = userPrtPprIdDerivNo;

                // �w�l�k�̓ǂݍ���
                FrePprECnd[] frePprECnds = XmlDeserialize();

                foreach (FrePprECnd frePprECndTemp in frePprECnds)
                {
                    // �O�̂��ߊ�ƃR�[�h���`�F�b�N
                    if ((frePprECndTemp.EnterpriseCode == frePprECndPara.EnterpriseCode) &&
                        (frePprECndTemp.OutputFormFileName == frePprECndPara.OutputFormFileName) &&
                        (frePprECndTemp.UserPrtPprIdDerivNo == frePprECndPara.UserPrtPprIdDerivNo))
                    {
                        frePprECndLs.Add(frePprECndTemp.Clone());
                    }
                }

                if ((frePprECndLs.Count == 0) || (frePprECndLs == null))
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }

                return status;
            }
            catch (System.IO.FileNotFoundException)
            {
                return (int)ConstantManagement.DB_Status.ctDB_EOF;
            }
            catch (Exception)
            {
                frePprECndLs = null;
                // �G���[��-1��߂�
                return -1;
            }
        }
        #endregion

        #region ���R���[���o�����o�^�E�X�V����(Write)
        /// <summary>
        /// ���R���[���o�����o�^�E�X�V����
        /// </summary>
        /// <param name="frePprECndLs">���R���[���o�����N���X</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���R���[���o�������̓o�^�E�X�V���s���܂��B</br>
        /// <br>Programmer : 22011 ���� ���l</br>
        /// <br>Date       : 2007.04.17</br>
        /// </remarks>
        public int Write(ref List<FrePprECnd> frePprECndLs)
        {
            ArrayList frePprECndList = new ArrayList();

            // �X�e�[�^�X�� ctDB_NOT_FOUND �ɂ��Ă���
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            try
            {
                // �w�l�k�̓ǂݍ���
                FrePprECnd[] frePprECnds = XmlDeserialize();

                //�A���C���X�g�Ɋi�[
                foreach(FrePprECnd frePprECnd in frePprECnds)
                {
                    frePprECndList.Add(frePprECnd);
                }

                bool addFlg = false; 

                foreach(FrePprECnd newFrePprECnd in frePprECndLs)
                {
                    addFlg = false;
                    for (int ix = 0; ix < frePprECnds.Length; ix++)
                    {
                        if((frePprECnds[ix].EnterpriseCode == newFrePprECnd.EnterpriseCode) &&
                           (frePprECnds[ix].OutputFormFileName == newFrePprECnd.OutputFormFileName) &&
                           (frePprECnds[ix].UserPrtPprIdDerivNo == newFrePprECnd.UserPrtPprIdDerivNo) &&
                           (frePprECnds[ix].FrePrtPprExtraCondCd == newFrePprECnd.FrePrtPprExtraCondCd))
                        {
                            //�L�[��v�F�X�V
                            newFrePprECnd.CreateDateTime = frePprECnds[ix].CreateDateTime;	        // �쐬����
                            newFrePprECnd.UpdateDateTime = DateTime.Now;�@�@                        // �X�V�����X�V
                            newFrePprECnd.FileHeaderGuid = frePprECnds[ix].FileHeaderGuid;          // GUID
                            newFrePprECnd.EnterpriseCode = frePprECnds[ix].EnterpriseCode;          // ��ƃR�[�h
                            frePprECndList[ix] = newFrePprECnd;
                            addFlg = true;
                            break;
                        }        
                    }

                    if (addFlg == false) // �ǉ�����Ă��Ȃ��Ƃ�
                    {
                        //�L�[�s��v�F�V�K�o�^
                        newFrePprECnd.CreateDateTime = DateTime.Now;	                        // �쐬����
                        newFrePprECnd.UpdateDateTime = DateTime.Now;                            // �X�V�����X�V
                        newFrePprECnd.FileHeaderGuid = System.Guid.NewGuid();	                // GUID
                        newFrePprECnd.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;     // ��ƃR�[�h
                        frePprECndList.Add(newFrePprECnd);
                    }
                }
            
                // �X�e�[�^�X���`�F�b�N
                
                // KEY�ŕ��ёւ���
                frePprECndList.Sort();
                // �w�l�k�̏������݁i���R���[���o����List�V���A���C�Y�����j
                this.ListSerialize(frePprECndList, this._fileNameGr);
                


                if (_buff_FrePprECnd != null)
                {
                    SortedList sortList = new SortedList();

                    //�L���b�V���X�V
                    foreach (FrePprECnd frePprECndwk in frePprECndList)
                    {
                        sortList.Add(frePprECndwk.DisplayOrder, frePprECndwk);
                    }
                    _buff_FrePprECnd.Clear();

                    foreach (FrePprECnd frePprECndwk in sortList.Values)
                    {
                        _buff_FrePprECnd.Add(frePprECndwk);
                    }                    
                }
                
            }
            catch (Exception)
            {
                // �G���[�I
                status = -1;
            }

            return status;
        }
        #endregion
    
        #region ���R���[���o������������(SearchAll)
        /// <summary>
        /// ���R���[���o�������������i�_���폜�܂ށj
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���R���[���o�����̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
        /// <br>Programmer : 22011 ���� ���l</br>
        /// <br>Date       : 2007.04.17</br>
        /// </remarks>
        public int SearchAll(out List<FrePprECnd> retList, string enterpriseCode)
        {
            retList = new List<FrePprECnd>();
            
            int status = 0;
            try
            {
                // �w�l�k�̓ǂݍ���
                FrePprECnd[] frePprECnds = XmlDeserialize();

                for (int ix = 0; ix < frePprECnds.Length; ix++)
                {
                    // �Ǎ����ʃR���N�V�����ɒǉ�
                    if (frePprECnds[ix].LogicalDeleteCode == 0)
                        retList.Add(frePprECnds[ix]);
                }

                // �Ǎ����ʂȂ��̏ꍇ��EOF��Ԃ�
                if (retList.Count <= 0)
                    status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            }
            catch (System.IO.FileNotFoundException)
            {
                return (int)ConstantManagement.DB_Status.ctDB_EOF;
            }
            catch (Exception)
            {
                // �G���[�I
                return -1;
            }
            return status;
        }
          #endregion

        #region �L���b�V���擾����
        /// <summary>
        /// �L���b�V���擾����
        /// </summary>
        /// <param name="retList">�f�[�^�o�b�t�@</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="mode">0:�_���폜������,1:�_���폜���܂�</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �f�[�^�o�b�t�@���擾���܂�</br>
        /// <br>Programmer : 22011 ���� ���l</br>
        /// <br>Date       : 2007.04.17</br>
        /// </remarks>
        public int GetBuff(out List<FrePprECnd> retList, string enterpriseCode, int mode)
        {
            int status = 0;

            // �K�C�h�p�o�b�t�@�Ƀf�[�^��������΃����[�g���擾����
            if ((_buff_FrePprECnd == null) || (_buff_FrePprECnd.Count == 0))
            {
                if (_buff_FrePprECnd == null) { _buff_FrePprECnd = new List<FrePprECnd>(); }
                _buff_FrePprECnd.Clear();

                List<FrePprECnd> frePprECndLs = new List<FrePprECnd>();
                status = SearchAll(out frePprECndLs, enterpriseCode);

                foreach (FrePprECnd frePprECnd in frePprECndLs)
                {
                    if (frePprECnd.LogicalDeleteCode == 0)
                    {
                        _buff_FrePprECnd.Add(frePprECnd);
                    }
                    //_logicalBuff_FrePprECnd.Add(frePprECnd);
                }
            }
            if (mode == 0)
            {
                retList = _buff_FrePprECnd;
            }
            else
            {
                // ��̏�ԂŕԂ�
                retList = new List<FrePprECnd>();
            }

            return status;
        }
        #endregion

        #region ���R���[���o�����ǂݍ��ݏ���(�L���b�V������)
        /// <summary>
        /// ���R���[���o�����ǂݍ��ݏ���(�L���b�V������)
        /// </summary>
        /// <param name="frePprECnd">���R���[���o�����I�u�W�F�N�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="outputFormFileName">�o�̓t�@�C����</param>
        /// <param name="userPrtPprIdDerivNo">���[�U�[���[ID�}��</param>
        /// <returns>���R���[���o�����N���X</returns>
        /// <remarks>
        /// <br>Note       : ���R���[���o���������L���b�V������ǂݍ��݂܂��B</br>
        /// <br>Programmer : 22011 �����@���l</br>
        /// <br>Date       : 2007.04.17</br>
        /// </remarks>
        public int SearchStaticMemory(out List<FrePprECnd> frePprECnd, string enterpriseCode, string outputFormFileName, int userPrtPprIdDerivNo)
        {
            frePprECnd = new List<FrePprECnd>();

            try
            {
                int status = 0;

                // �o�b�t�@�Ƀf�[�^���������XML���擾����
                if ((_buff_FrePprECnd == null) || (_buff_FrePprECnd.Count == 0))
                {
                    if (_buff_FrePprECnd == null)
                    {
                        _buff_FrePprECnd = new List<FrePprECnd>();
                    }
                    _buff_FrePprECnd.Clear();

                    List<FrePprECnd> frePprECndLs = new List<FrePprECnd>();
                    status = SearchAll(out frePprECndLs, enterpriseCode);

                    foreach (FrePprECnd prtMng in frePprECndLs)
                    {
                        if (prtMng.LogicalDeleteCode == 0)
                        {
                            _buff_FrePprECnd.Add(prtMng);
                        }
                    }
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }
                }
                else
                {
                    frePprECnd = _buff_FrePprECnd;
                }
                return status;
            }
            catch (Exception)
            {
                frePprECnd = null;
                // �G���[��-1��߂�
                return -1;
            }
        }
        #endregion

        #region ���R���[���o�����ǂݍ��ݏ���(Read)
        /// <summary>
        /// ���R���[���o�������דǂݍ��ݏ���
        /// </summary>
        /// <param name="frePExCndDLs">���R���[���o�������׃I�u�W�F�N�g�̃R���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="extraCondDatailGrpCd">���o�������׃O���[�v�R�[�h</param>
        /// <returns>���R���[���o�����N���X</returns>
        /// <remarks>
        /// <br>Note       : ���R���[���o�������׏���ǂݍ��݂܂��B�󎚈ʒu�ݒ�}�X�^�P���R�[�h�P�ʂŊ֘A��������擾���܂��B</br>
        /// <br>Programmer : 22011 ���� ���l</br>
        /// <br>Date       : 2007.04.17</br>
        /// </remarks>
        public int ReadDtl(out List<FrePExCndD> frePExCndDLs, string enterpriseCode, int extraCondDatailGrpCd)
        {
            frePExCndDLs = new List<FrePExCndD>();

            try
            {
                int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                // �f�[�^��r�p�p�����[�^
                FrePExCndD frePExCndDPara = new FrePExCndD();
                frePExCndDPara.EnterpriseCode = enterpriseCode;
                frePExCndDPara.ExtraCondDetailGrpCd = extraCondDatailGrpCd;
                
                // �w�l�k�̓ǂݍ���
                FrePExCndD[] frePExCndDs = XmlDeserializeDtl();

                foreach (FrePExCndD frePExCndDTemp in frePExCndDs)
                {
                    // �O�̂��ߊ�ƃR�[�h���`�F�b�N
                    if ((frePExCndDTemp.EnterpriseCode == frePExCndDPara.EnterpriseCode) &&
                        (frePExCndDTemp.ExtraCondDetailCode == frePExCndDPara.ExtraCondDetailCode))
                    {
                        frePExCndDLs.Add(frePExCndDTemp.Clone());
                    }
                }

                if ((frePExCndDLs.Count == 0) || (frePExCndDLs == null))
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }

                return status;
            }
            catch (System.IO.FileNotFoundException)
            {
                return (int)ConstantManagement.DB_Status.ctDB_EOF;
            }
            catch (Exception)
            {
                frePExCndDLs = null;
                // �G���[��-1��߂�
                return -1;
            }
        }
        #endregion

        #region ���R���[���o�������� �o�^�E�X�V����(Write)
        /// <summary>
        /// ���R���[���o�������דo�^�E�X�V����
        /// </summary>
        /// <param name="frePExCndDLs">���R���[���o�������׃N���X</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���R���[���o�������׏��̓o�^�E�X�V���s���܂��B</br>
        /// <br>Programmer : 22011 ���� ���l</br>
        /// <br>Date       : 2007.04.17</br>
        /// </remarks>
        public int WriteDtl(ref List<FrePExCndD> frePExCndDLs)
        {
            ArrayList frePExCndDList = new ArrayList();

            // �X�e�[�^�X�� ctDB_NOT_FOUND �ɂ��Ă���
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            try
            {
                // �w�l�k�̓ǂݍ���
                FrePExCndD[] frePExCndDs = XmlDeserializeDtl();

                //�A���C���X�g�Ɋi�[
                foreach (FrePExCndD frePExCndD in frePExCndDs)
                {
                    frePExCndDList.Add(frePExCndD);
                }

                bool addFlg = false;

                foreach (FrePExCndD newFrePExCndD in frePExCndDLs)
                {
                    addFlg = false;
                    for (int ix = 0; ix < frePExCndDs.Length; ix++)
                    {
                        if ((frePExCndDs[ix].EnterpriseCode == newFrePExCndD.EnterpriseCode) &&
                           (frePExCndDs[ix].ExtraCondDetailCode == newFrePExCndD.ExtraCondDetailCode) &&
                           (frePExCndDs[ix].ExtraCondDetailCode == newFrePExCndD.ExtraCondDetailCode))
                        {
                            //�L�[��v�F�X�V
                            newFrePExCndD.CreateDateTime = frePExCndDs[ix].CreateDateTime;	        // �쐬����
                            newFrePExCndD.UpdateDateTime = DateTime.Now;�@�@                        // �X�V�����X�V
                            newFrePExCndD.FileHeaderGuid = frePExCndDs[ix].FileHeaderGuid;          // GUID
                            newFrePExCndD.EnterpriseCode = frePExCndDs[ix].EnterpriseCode;          // ��ƃR�[�h
                            frePExCndDList[ix] = newFrePExCndD;
                            addFlg = true;
                            break;
                        }
                    }

                    if (addFlg == false) // �ǉ�����Ă��Ȃ��Ƃ�
                    {
                        //�L�[�s��v�F�V�K�o�^
                        newFrePExCndD.CreateDateTime = DateTime.Now;	                        // �쐬����
                        newFrePExCndD.UpdateDateTime = DateTime.Now;                            // �X�V�����X�V
                        newFrePExCndD.FileHeaderGuid = System.Guid.NewGuid();	                // GUID
                        newFrePExCndD.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;     // ��ƃR�[�h
                        frePExCndDList.Add(newFrePExCndD);
                    }
                }

                // �X�e�[�^�X���`�F�b�N

                // KEY�ŕ��ёւ���
                frePExCndDList.Sort();
                // �w�l�k�̏������݁i���R���[���o����List�V���A���C�Y�����j
                this.ListSerialize(frePExCndDList, this._fileNameDt);



                if (_buff_FrePExCndD != null)
                {
                    SortedList sortList = new SortedList();

                    //�L���b�V���X�V
                    foreach (FrePExCndD frePExCndDwk in frePExCndDList)
                    {
                        sortList.Add(frePExCndDwk.ExtraCondDetailCode, frePExCndDwk);
                    }
                    _buff_FrePExCndD.Clear();

                    foreach (FrePExCndD frePExCndDwk in sortList.Values)
                    {
                        _buff_FrePExCndD.Add(frePExCndDwk);
                    }
                }

            }
            catch (Exception)
            {
                // �G���[�I
                status = -1;
            }
            return status;
        }
        #endregion


        #endregion

        #region private Methods

        #region ���R���[���o����List�V���A���C�Y����
        /// <summary>
        /// ���R���[���o����List�V���A���C�Y����
        /// </summary>
        /// <param name="frePprECndList">�V���A���C�Y�Ώێ��R���[���o����List�N���X</param>
        /// <param name="fileName">�V���A���C�Y�t�@�C����</param>
        /// <remarks>
        /// <br>Note       : ���R���[���o����List���̃V���A���C�Y���s���܂��B</br>
        /// <br>Programmer : 22011 ���� ���l</br>
        /// <br>Date       : 2007.04.17</br>
        /// </remarks>
        private void ListSerialize(ArrayList frePprECndList, string fileName)
        {
            // ArrayList����z��𐶐�
            FrePprECnd[] frePprECnds = (FrePprECnd[])frePprECndList.ToArray(typeof(FrePprECnd));
            //�i�[�f�B���N�g�����Ȃ���΍쐬
            if (System.IO.Directory.Exists(ConstantManagement_ClientDirectory.LocalApplicationData_AppSettingData) == false)
            {
                System.IO.Directory.CreateDirectory(ConstantManagement_ClientDirectory.LocalApplicationData_AppSettingData);
            }

            UserSettingController.SerializeUserSetting(frePprECnds, _filePathGr);
        }
        #endregion

        #region ���R���\���o�����f�V���A���C�Y����
        /// <summary>
        /// XML���玩�R���\���o�����N���X�փf�V���A���C�Y���܂�
        /// </summary>
        /// <returns>���R���\���o�����z��</returns>
        private FrePprECnd[] XmlDeserialize()
        {
            return (FrePprECnd[])UserSettingController.DeserializeUserSetting(this._filePathGr, typeof(FrePprECnd[]));
        }
        #endregion

        #region ���R���[���o��������List�V���A���C�Y����
        /// <summary>
        /// ���R���[���o����List�V���A���C�Y����
        /// </summary>
        /// <param name="frePExCndDList">�V���A���C�Y�Ώێ��R���[���o����List�N���X</param>
        /// <param name="fileName">�V���A���C�Y�t�@�C����</param>
        /// <remarks>
        /// <br>Note       : ���R���[���o����List���̃V���A���C�Y���s���܂��B</br>
        /// <br>Programmer : 22011 ���� ���l</br>
        /// <br>Date       : 2007.04.17</br>
        /// </remarks>
        private void ListSerializeDtl(ArrayList frePExCndDList, string fileName)
        {
            // ArrayList����z��𐶐�
            FrePExCndD[] frePExCndDs = (FrePExCndD[])frePExCndDList.ToArray(typeof(FrePExCndD));
            //�i�[�f�B���N�g�����Ȃ���΍쐬
            if (System.IO.Directory.Exists(ConstantManagement_ClientDirectory.LocalApplicationData_AppSettingData) == false)
            {
                System.IO.Directory.CreateDirectory(ConstantManagement_ClientDirectory.LocalApplicationData_AppSettingData);
            }

            UserSettingController.SerializeUserSetting(frePExCndDs, _filePathDt);
        }
        #endregion

        #region ���R���\���o�������׃f�V���A���C�Y����
        /// <summary>
        /// XML���玩�R���\���o�����N���X�փf�V���A���C�Y���܂�
        /// </summary>
        /// <returns>���R���\���o�����z��</returns>
        private FrePExCndD[] XmlDeserializeDtl()
        {
            return (FrePExCndD[])UserSettingController.DeserializeUserSetting(this._filePathDt, typeof(FrePExCndD[]));
        }
        #endregion

        #endregion

    }
}

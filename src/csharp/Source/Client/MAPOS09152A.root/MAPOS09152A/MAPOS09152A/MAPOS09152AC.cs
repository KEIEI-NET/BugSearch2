//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �[���Ǘ��ݒ�}�X�^
// �v���O�����T�v   : �[���Ǘ��ݒ�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30413 ����
// �� �� ��  2009/06/05  �C�����e : SCM�I�v�V�����Ή�
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

using Broadleaf.Application.LocalAccess;
using Broadleaf.Application.Common; // ADD 2009/06/05
using Broadleaf.Application.Remoting;   // ADD 2009/06/05
using Broadleaf.Application.Remoting.Adapter;   // ADD 2009/06/05
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Xml.Serialization;
using System.Net.NetworkInformation;

using Broadleaf.Application.Resources;// 2010/06/29 Add
namespace Broadleaf.Application.Controller
{
	/// <summary>�[���Ǘ��e�[�u��(���[�J��DB��p)�A�N�Z�X�N���X</summary>
	/// <remarks>
	/// <br>Note       : �[���Ǘ��e�[�u��(���[�J��DB)�̃A�N�Z�X������s���܂��B</br>
    /// <br>             ���݂���f�[�^�́A���[�J��DB���ł͏��1���R�[�h�݂̂Ƃ��܂��B</br>
    /// <br>Programmer : �É�@���S��</br>
	/// <br>Date       : 2007.04.13</br>
    /// <br></br>
    /// <br>UpdateNote : 2007.06.11�@�Éꏬ�S���@���ڒǉ��Ή�</br>
    /// <br>UpdateNote : 2007.07.03�@�Éꏬ�S���@�V���N�����Ή�(XML�쐬�@�\�ǉ�)</br>
    /// <br>UpdateNote : 2007.07.05  �Éꏬ�S���@���_�������_����[���ݒu���_�ɕύX</br>
    /// <br>UpdateNote : 2007.07.09  �Éꏬ�S���@�V���N�o�b�N�A�b�v�����Ή�</br>
    /// <br>UpdateNote : 2008.01.31  ���@�O�M�@���[�J���c�a�Ή��i���_�j</br>
    /// <br>UpdateNote : 2009.07.14 20056 ���n ��� �T�[�o�[�֔z�u����N���C�A���g�A�Z���u���Ή�</br>
    /// <br>             �@���_���}�X�^�A�N�Z�X�N���X���g�p���Ȃ�</br>
    /// <br>             �ABkPosTerminalMgAcs�̃C���X�^���X�������s��Ȃ�</br>
    /// <br>UpdateNote : 2010/06/29 30517 �Ė� �x�� Mantis.15667�@�d�l�ύX</br>
    /// </remarks>
	public class PosTerminalMgAcs
    {

        # region private �萔
        /// <summary>���[�J��DB�A�N�Z�X�I�u�W�F�N�g�i�[�o�b�t�@</summary>
		private PosTerminalMgLcDB _posTerminalMgLcDB = null;
        //private SecInfoAcs _secInfoAcs = null; // 2009.07.14
        // 2007.07.03  S.Koga  ADD --------------------------------------------
        private PosTerminalMgXMLDataAcs _posTerminalMgXMLDataAcs = null;
        // --------------------------------------------------------------------
        // 2007.07.09  S.Koga  ADD --------------------------------------------
        //private BkPosTerminalMgAcs _bkPosTerminalMgAcs = null; // 2009.07.14
        // --------------------------------------------------------------------

        // ADD 2009/06/05 ------>>>
        /// <summary>�����[�gDB�A�N�Z�X�I�u�W�F�N�g�i�[�o�b�t�@</summary>
        private IPosTerminalMgDB _iPosTerminalMgDB = null;

        private Employee _employee;
        // ADD 2009/06/05 ------<<<

        private bool _scmFlg = false;   // 2010/06/29 Add
        # endregion

        # region �R���X�g���N�^
        /// <summary>�[���Ǘ��e�[�u���A�N�Z�X�N���X�R���X�g���N�^</summary>
		/// <remarks>
		/// <br>Note       : �[���Ǘ��e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : �É�@���S��</br>
		/// <br>Date       : 2007.04.13</br>
		/// </remarks>
		public PosTerminalMgAcs()
		{
            // ���[�J��DB�A�N�Z�X�I�u�W�F�N�g�擾
            this._posTerminalMgLcDB = new PosTerminalMgLcDB();

            // 2009.07.14 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            ////----- ueno upd ---------- start 2008.01.31        
            //// �����I�Ƀ��[�J���Ăяo�����s��
            //this._secInfoAcs = new SecInfoAcs(0);
            ////----- ueno upd ---------- end 2008.01.31
            // 2009.07.14 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            
            // 2007.07.03  S.Koga  ADD ----------------------------------------
            this._posTerminalMgXMLDataAcs = new PosTerminalMgXMLDataAcs();
            // ----------------------------------------------------------------
            // 2007.07.09  S.Koga  ADD ----------------------------------------
            //this._bkPosTerminalMgAcs = BkPosTerminalMgAcs.GetInstance(); // 2009.07.14
            // ----------------------------------------------------------------

            // ADD 2009/06/05 ------>>>
            // �����[�gDB�A�N�Z�X�I�u�W�F�N�g�擾
            this._iPosTerminalMgDB = (IPosTerminalMgDB)MediationPosTerminalMgDB.GetPosTerminalMgDB();

            this._employee = LoginInfoAcquisition.Employee;
            // ADD 2009/06/05 ------<<<

            // 2010/06/29 Add >>>
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus scmPs;
            scmPs = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_SCM);
            if (scmPs == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
            {
                _scmFlg = true;
            }
            else
            {
                _scmFlg = false;
            }
            // 2010/06/29 Add <<<

        }
        # endregion

        /// <summary>���W�ԍ��擾����</summary>
        /// <param name="cashRegisterNo">���W�ԍ�</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>�Ǎ����ʃX�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �[���ɓo�^����Ă��郌�W�ԍ����擾���܂��B(��1���R�[�h�̂�)</br>
        /// <br>Programmer : �É�@���S��</br>
        /// <br>Date       : 2007.04.13</br>
        /// </remarks>
        public int GetCashRegisterNo(out int cashRegisterNo, string enterpriseCode)
        {
            cashRegisterNo = 0;
            int status = 0;
            PosTerminalMgWork posTerminalMgWork = new PosTerminalMgWork();
            List<PosTerminalMgWork> resList = new List<PosTerminalMgWork>();
            try
            {
                posTerminalMgWork.EnterpriseCode = enterpriseCode;

                //�����Ӑݒ�ǂݍ���
                status = this._posTerminalMgLcDB.Search(out resList, posTerminalMgWork, 0, 0);

                if (status == 0)
                {
                    PosTerminalMgWork resWork = (PosTerminalMgWork)resList[0];
                    // �N���X�������o�R�s�[
                    cashRegisterNo = resWork.CashRegisterNo;
                }

            }
            catch (Exception)
            {
                status = -1;
            }
            return status;
        }

        /// <summary>�[���Ǘ�XML�擾����</summary>
        /// <returns>�[���Ǘ��ݒ�XML���</returns>
        /// <remarks>
        /// <br>Note        : XML�ɓo�^����Ă���[���Ǘ�����Ԃ��܂��B</br>
        /// <br>Programmer  : 20031 �É�@���S��</br>
        /// <br>Date        : 2007.07.03</br>
        /// </remarks>
        public int GetCashRegisterNoFromXML(out PosTerminalMgXMLData data)
        {
            int status = 0;
            //data = new PosTerminalMgXMLData();

            this._posTerminalMgXMLDataAcs.Deserialize();
            data = this._posTerminalMgXMLDataAcs.GetData();

            if (data == null)
                status = 4;

            return status;
        }

        /// <summary>�[���Ǘ��ǂݍ��ݏ���</summary>
		/// <param name="posTerminalMg">�[���Ǘ��I�u�W�F�N�g</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <returns>�Ǎ����ʃX�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �[���Ǘ���ǂݍ��݂܂��B</br>
		/// <br>Programmer : �É�@���S��</br>
		/// <br>Date       : 2007.04.13</br>
		/// </remarks>
		public int Search(out PosTerminalMg posTerminalMg, string enterpriseCode)
		{
            posTerminalMg = null;
            PosTerminalMgWork posTerminalMgWork = new PosTerminalMgWork();
            List<PosTerminalMgWork> resList = new List<PosTerminalMgWork>();
            try
			{
				posTerminalMgWork.EnterpriseCode	= enterpriseCode;

				//�����Ӑݒ�ǂݍ���
				int status = this._posTerminalMgLcDB.Search(out resList, posTerminalMgWork,0,0);

				if (status == 0)
				{
                    PosTerminalMgWork resWork = (PosTerminalMgWork)resList[0];
					// �N���X�������o�R�s�[
                    posTerminalMg = CopyToPosTerminalMgFromPosTerminalMgWork(resWork);
				}

				return status;
			}
			catch (Exception)
			{
				return -1;
			}
		}

        // ADD 2009/06/05 ------>>>
        /// <summary>�[���Ǘ��ǂݍ��ݏ���(�_���폜���܂ޑS����)</summary>
        /// <param name="retList">�������ʃI�u�W�F�N�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>�Ǎ����ʃX�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �[���Ǘ���ǂݍ��݂܂��B</br>
        /// <br></br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode)
        {
            if (this._employee.UserAdminFlag == 1)
            {
                if (_scmFlg == true)   // 2010/06/29 SCM�I�v�V�������L���Ȃ�Ǘ��҃��[�h�Ŏ��s Add
                    // �Ǘ��҃��[�h
                    return SearchServer(out retList, enterpriseCode);
                // 2010/06/29 Add >>>
                else
                {
                    // ��ʃ��[�U�[���[�h
                    return SearchLocal(out retList, enterpriseCode);
                }
            // 2010/06/29 Add <<<
            }
            else
            {
                // ��ʃ��[�U�[���[�h
                return SearchLocal(out retList, enterpriseCode);
            }
        }

        /// <summary>�[���Ǘ��ǂݍ��ݏ���(�T�[�o�[)</summary>
        /// <param name="retList">�������ʃI�u�W�F�N�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>�Ǎ����ʃX�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �[���Ǘ���ǂݍ��݂܂��B</br>
        /// <br></br>
        /// </remarks>
        public int SearchServer(out ArrayList retList, string enterpriseCode)
        {
            PosTerminalMgServerWork posTerminalMgServerWork = new PosTerminalMgServerWork();
            posTerminalMgServerWork.EnterpriseCode = enterpriseCode;

            retList = new ArrayList();

            object paraobj = posTerminalMgServerWork;
			object retobj = null;

            // �[���Ǘ��ݒ�̑S����
            int status = this._iPosTerminalMgDB.Search(out retobj, paraobj, 0, ConstantManagement.LogicalMode.GetDataAll);
            if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) ||
                (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
            {
                ArrayList workList = retobj as ArrayList;

                foreach (PosTerminalMgServerWork wkPosTerminalMgServerWork in workList)
                {
                    retList.Add(CopyToPosTerminalMgFromPosTerminalMgServerWork(wkPosTerminalMgServerWork));
                }
            }

            return status;
        }

        /// <summary>�[���Ǘ��ǂݍ��ݏ���(���[�J��)</summary>
        /// <param name="retList">�������ʃI�u�W�F�N�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>�Ǎ����ʃX�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �[���Ǘ���ǂݍ��݂܂��B</br>
        /// <br></br>
        /// </remarks>
        public int SearchLocal(out ArrayList retList, string enterpriseCode)
        {
            PosTerminalMgWork posTerminalMgWork = new PosTerminalMgWork();
            posTerminalMgWork.EnterpriseCode = enterpriseCode;
            
            retList = new ArrayList();

            List<PosTerminalMgWork> resList = new List<PosTerminalMgWork>();

            // ���[�J��DB�̌���
            int status = this._posTerminalMgLcDB.Search(out resList, posTerminalMgWork, 0, 0);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                PosTerminalMgWork resWork = (PosTerminalMgWork)resList[0];
                // �N���X�������o�R�s�[
                retList.Add(CopyToPosTerminalMgFromPosTerminalMgWork(resWork));
            }
            else if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) ||
                     (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
            {
                PosTerminalMg posTerminalMg = new PosTerminalMg();
                retList.Add(posTerminalMg);
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }

            return status;
        }
        // ADD 2009/06/05 ------<<<
        
        /// <summary>�[���Ǘ��ǂݍ��ݏ���</summary>
        /// <param name="posTerminalMg">�[���Ǘ��I�u�W�F�N�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>�Ǎ����ʃX�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �[���Ǘ���ǂݍ��݂܂��B</br>
        /// <br>Programmer : �É�@���S��</br>
        /// <br>Date       : 2007.04.13</br>
        /// </remarks>
        public string GetSecInfo(string sectionCode)
        {
            string sectionGuideName = "";
            // 2009.07.14 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
            //{
            //    if (secInfoSet.SectionCode.Equals(sectionCode))
            //    {
            //        sectionGuideName = secInfoSet.SectionGuideNm;
            //    }
            //}
            // 2009.07.14 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            return sectionGuideName;
        }

        /// <summary>���_���̎擾����</summary>
        /// <param name="sectionName">���_�K�C�h����</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>�擾���ʃX�e�[�^�X(true:OK, false:NG)</returns>
        /// <remarks>
        /// <br>Note        : �w�肵�����_�R�[�h�̋��_�K�C�h���̂��擾���A���ʂ�bool�^�ŕԂ��܂��B</br>
        /// <br>Programmer  : 20031 �É�@���S��</br>
        /// <br>Date        : 2007.07.05</br>
        /// </remarks>
        public bool GetSectionName(out string sectionName, string sectionCode)
        {
            sectionName = GetSecInfo(sectionCode);

            if (sectionName.Equals(""))
                return false;
            else
                return true;
        }

        /// <summary>���_���ꗗ�擾����</summary>
        /// <returns>���_�R�[�h/���_�K�C�h���̂̃L�[�ƒl�̈ꗗ</returns>
        /// <remarks>
        /// <br>Note        : ���_���̈ꗗ���擾���A�R�[�h�ƃK�C�h���݂̂̂̃R���N�V������Ԃ��܂��B</br>
        /// <br>Programmer  : 20031 �É�@���S��</br>
        /// <br>Date        : 2007.07.05</br>
        /// </remarks>
        public Hashtable GetSecInfoList()
        {
            Hashtable secInfoList = new Hashtable();

            // 2009.07.14 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
            //{
            //    secInfoList.Add(secInfoSet.SectionCode, secInfoSet.SectionGuideNm);
            //}
            // 2009.07.14 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            return secInfoList;
        }

        /// <summary>�[���Ǘ��o�^�E�X�V����</summary>
		/// <param name="posTerminalMg">�[���Ǘ��N���X</param>
		/// <returns>�X�V���ʃX�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �[���Ǘ��̓o�^�E�X�V���s���܂��B</br>
		/// <br>Programmer : �É�@���S��</br>
		/// <br>Date       : 2007.04.13</br>
		/// </remarks>
		public int Write(ref PosTerminalMg posTerminalMg, PosTerminalMg delTerminalMg)
		{
			//�N���X���烏�[�J�[�N���X�Ƀ����o�R�s�[
            //PosTerminalMgWork delTerminalMgWork = CopyToPosTerminalMgWorkFromPosTerminalMg(delTerminalMg);
            PosTerminalMgWork posTerminalMgWork = CopyToPosTerminalMgWorkFromPosTerminalMg(posTerminalMg);

            // �������ʊi�[List
            List<PosTerminalMgWork> posList = new List<PosTerminalMgWork>();
            // �����p�����[�^�i�[Work
            PosTerminalMgWork paraWork = new PosTerminalMgWork();
            paraWork.EnterpriseCode = delTerminalMg.EnterpriseCode;
            // �폜�p�����[�^�i�[List
            List<PosTerminalMgWork> delParaList = new List<PosTerminalMgWork>();
            // �X�V�p�����[�^�i�[List
            List<PosTerminalMgWork> wriParaList = new List<PosTerminalMgWork>();
            wriParaList.Add(posTerminalMgWork);

			int status = 0;
			try
			{
                status = this._posTerminalMgLcDB.Search(out posList, paraWork, 0, 0);
                if (status == 0)
                {
                    foreach (PosTerminalMgWork delPara in posList)
                    {
                        delParaList.Add(delPara);
                        status = this._posTerminalMgLcDB.Delete(delParaList);
                        if (status != 0)
                            return status;
                    }
                }
                else if(status != 4 && status != 9)
                    return status;

                //��������
                status = this._posTerminalMgLcDB.Write(ref wriParaList);
                if (status == 0)
                {
                    // �t�@�C������n���ă��[�N�N���X���f�V���A���C�Y����
                    posTerminalMgWork = (PosTerminalMgWork)wriParaList[0];
                    // �N���X�������o�R�s�[
                    posTerminalMg = CopyToPosTerminalMgFromPosTerminalMgWork(posTerminalMgWork);

                    // 2007.07.03  S.Koga  ADD --------------------------------
                    PosTerminalMgXMLData data = new PosTerminalMgXMLData();
                    data.EnterpriseCode = posTerminalMg.EnterpriseCode;
                    //data.SectionCode = posTerminalMg.SectionCode;                 // DEL 2008/06/18
                    data.CashRegisterNo = posTerminalMg.CashRegisterNo;
                    this._posTerminalMgXMLDataAcs.Cache(data);
                    this._posTerminalMgXMLDataAcs.Serialize();
                    // --------------------------------------------------------

                    //--- DEL 2008/06/19 --------->>>>>
                    // 2007.07.09  S.Koga  ADD --------------------------------
                    // �o�b�N�A�b�v�����G���[�̏ꍇ�͌����_�ł̓X���[���܂��B
                    // --------------------------------------------------------
                    //int onlinestatus = 0;
                    //if(CheckOnline())
                    //    onlinestatus = this._bkPosTerminalMgAcs.BackUpExec();
                    // --------------------------------------------------------
                    //--- DEL 2008/06/19 ---------<<<<<
                }

			}
			catch (Exception)
			{
				//�G���[��������-1��Ԃ�
				status = -1;
			}
			return status;
		}

		/// <summary>�[���Ǘ��V���A���C�Y����</summary>
		/// <param name="PosTerminalMg">�V���A���C�Y�Ώے[���Ǘ��N���X</param>
		/// <param name="fileName">�V���A���C�Y�t�@�C����</param>
		/// <remarks>
		/// <br>Note       : �[���Ǘ��̃V���A���C�Y���s���܂��B</br>
		/// <br>Programmer : �É�@���S��</br>
		/// <br>Date       : 2007.04.13</br>
		/// </remarks>
		public void PosTerminalMgSerialize(PosTerminalMg posTerminalMg,string fileName)
		{
			//�v�����^�Ǘ����[�J�[�N���X���V���A���C�Y
			XmlByteSerializer.Serialize(posTerminalMg,fileName);
		}

		/// <summary>�[���Ǘ�List�V���A���C�Y����</summary>
		/// <param name="PosTerminalMgList">�V���A���C�Y�Ώے[���Ǘ�List�N���X</param>
		/// <param name="fileName">�V���A���C�Y�t�@�C����</param>
		/// <remarks>
		/// <br>Note       : �[���Ǘ�List���̃V���A���C�Y���s���܂��B</br>
		/// <br>Programmer : �É�@���S��</br>
		/// <br>Date       : 2007.04.13</br>
		/// </remarks>
		public void PosTerminalMgListSerialize(ArrayList posTerminalMgList,string fileName)
		{
			// ArrayList����z��𐶐�
			PosTerminalMg[] posTerminalMgs = (PosTerminalMg[])posTerminalMgList.ToArray(typeof(PosTerminalMg));
			// �v�����^�Ǘ����[�J�[�N���X���V���A���C�Y
			XmlByteSerializer.Serialize(posTerminalMgs,fileName);

		}

		/// <summary>�N���X�����o�[�R�s�[�����i�[���Ǘ����[�N�N���X�˒[���Ǘ��N���X�j</summary>
		/// <param name="PosTerminalMgWork">�[���Ǘ����[�N�N���X</param>
		/// <returns>�[���Ǘ��N���X</returns>
		/// <remarks>
		/// <br>Note       : �[���Ǘ����[�N�N���X����[���Ǘ��N���X�փ����o�[�̃R�s�[���s���܂��B</br>
		/// <br>Programmer : �É�@���S��</br>
		/// <br>Date       : 2007.04.13</br>
		/// </remarks>
		private PosTerminalMg CopyToPosTerminalMgFromPosTerminalMgWork(PosTerminalMgWork posTerminalMgWork)
		{
			PosTerminalMg posTerminalMg = new PosTerminalMg();

			//�t�@�C���w�b�_����
			posTerminalMg.CreateDateTime    = posTerminalMgWork.CreateDateTime;
			posTerminalMg.UpdateDateTime    = posTerminalMgWork.UpdateDateTime;
			posTerminalMg.EnterpriseCode    = posTerminalMgWork.EnterpriseCode;
			posTerminalMg.FileHeaderGuid    = posTerminalMgWork.FileHeaderGuid;
			posTerminalMg.UpdEmployeeCode   = posTerminalMgWork.UpdEmployeeCode;
			posTerminalMg.UpdAssemblyId1    = posTerminalMgWork.UpdAssemblyId1;
			posTerminalMg.UpdAssemblyId2    = posTerminalMgWork.UpdAssemblyId2;
			posTerminalMg.LogicalDeleteCode = posTerminalMgWork.LogicalDeleteCode;

            //posTerminalMg.SectionCode       = posTerminalMgWork.SectionCode;          // DEL 2008/06/18
            posTerminalMg.CashRegisterNo    = posTerminalMgWork.CashRegisterNo;

            // 2007.06.11  S.Koga  ADD ----------------------------------------
            // POS/PC�[���敪
            posTerminalMg.PosPCTermCd = posTerminalMgWork.PosPCTermCd;
            // ----------------------------------------------------------------

            //--- ADD 2008/06/18 ---------->>>>>
            posTerminalMg.UseLanguageDivCd = posTerminalMgWork.UseLanguageDivCd;
            posTerminalMg.UseCultureDivCd = posTerminalMgWork.UseCultureDivCd;
            //--- ADD 2008/06/18 ---------->>>>>

            // ADD 2009/06/05 ------>>>
            posTerminalMg.MachineIpAddr = posTerminalMgWork.MachineIpAddr;
            posTerminalMg.MachineName = posTerminalMgWork.MachineName;
            // ADD 2009/06/05 ------<<<
            
            return posTerminalMg;
		}

		/// <summary>�N���X�����o�[�R�s�[�����i�[���Ǘ��N���X�˒[���Ǘ����[�N�N���X�j</summary>
		/// <param name="PosTerminalMg">�[���Ǘ����[�N�N���X</param>
		/// <returns>�[���Ǘ��N���X</returns>
		/// <remarks>
		/// <br>Note       : �[���Ǘ��N���X����[���Ǘ����[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
		/// <br>Programmer : �É�@���S��</br>
		/// <br>Date       : 2007.04.13</br>
		/// </remarks>
		private PosTerminalMgWork CopyToPosTerminalMgWorkFromPosTerminalMg(PosTerminalMg posTerminalMg)
		{
			PosTerminalMgWork posTerminalMgWork = new PosTerminalMgWork();

			posTerminalMgWork.CreateDateTime    = posTerminalMg.CreateDateTime;
			posTerminalMgWork.UpdateDateTime    = posTerminalMg.UpdateDateTime;
			posTerminalMgWork.EnterpriseCode    = posTerminalMg.EnterpriseCode.Trim();
			posTerminalMgWork.FileHeaderGuid    = posTerminalMg.FileHeaderGuid;
			posTerminalMgWork.UpdEmployeeCode   = posTerminalMg.UpdEmployeeCode;
			posTerminalMgWork.UpdAssemblyId1    = posTerminalMg.UpdAssemblyId1;
			posTerminalMgWork.UpdAssemblyId2    = posTerminalMg.UpdAssemblyId2;
			posTerminalMgWork.LogicalDeleteCode = posTerminalMg.LogicalDeleteCode;

            //posTerminalMgWork.SectionCode       = posTerminalMg.SectionCode;          // DEL 2008/06/18
            posTerminalMgWork.CashRegisterNo    = posTerminalMg.CashRegisterNo;

            // 2007.06.11  S.Koga  ADD ----------------------------------------
            // POS/PC�[���敪
            posTerminalMgWork.PosPCTermCd = posTerminalMg.PosPCTermCd;
            // ----------------------------------------------------------------

            //--- ADD 2008/06/18 ---------->>>>>
            posTerminalMgWork.UseLanguageDivCd = posTerminalMg.UseLanguageDivCd;
            posTerminalMgWork.UseCultureDivCd = posTerminalMg.UseCultureDivCd;
            //--- ADD 2008/06/18 ---------->>>>>

            // ADD 2009/06/05 ------>>>
            posTerminalMgWork.MachineIpAddr = posTerminalMg.MachineIpAddr;
            posTerminalMgWork.MachineName = posTerminalMg.MachineName;
            // ADD 2009/06/05 ------<<<

            return posTerminalMgWork;
		}

        /// <summary>�N���X�����o�[�R�s�[�����i�[���Ǘ������[�g���[�N�N���X�˒[���Ǘ��N���X�j</summary>
        /// <param name="posTerminalMgServerWork">�[���Ǘ������[�g���[�N�N���X</param>
        /// <returns>�[���Ǘ��N���X</returns>
        /// <remarks>
        /// <br>Note       : �[���Ǘ������[�g���[�N�N���X����[���Ǘ��N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br></br>
        /// </remarks>
        private PosTerminalMg CopyToPosTerminalMgFromPosTerminalMgServerWork(PosTerminalMgServerWork posTerminalMgServerWork)
        {
            PosTerminalMg posTerminalMg = new PosTerminalMg();

            //�t�@�C���w�b�_����
            posTerminalMg.CreateDateTime = posTerminalMgServerWork.CreateDateTime;
            posTerminalMg.UpdateDateTime = posTerminalMgServerWork.UpdateDateTime;
            posTerminalMg.EnterpriseCode = posTerminalMgServerWork.EnterpriseCode;
            posTerminalMg.FileHeaderGuid = posTerminalMgServerWork.FileHeaderGuid;
            posTerminalMg.UpdEmployeeCode = posTerminalMgServerWork.UpdEmployeeCode;
            posTerminalMg.UpdAssemblyId1 = posTerminalMgServerWork.UpdAssemblyId1;
            posTerminalMg.UpdAssemblyId2 = posTerminalMgServerWork.UpdAssemblyId2;
            posTerminalMg.LogicalDeleteCode = posTerminalMgServerWork.LogicalDeleteCode;

            posTerminalMg.CashRegisterNo = posTerminalMgServerWork.CashRegisterNo;

            // POS/PC�[���敪
            posTerminalMg.PosPCTermCd = posTerminalMgServerWork.PosPCTermCd;
            
            posTerminalMg.UseLanguageDivCd = posTerminalMgServerWork.UseLanguageDivCd;
            posTerminalMg.UseCultureDivCd = posTerminalMgServerWork.UseCultureDivCd;
            
            posTerminalMg.MachineIpAddr = posTerminalMgServerWork.MachineIpAddr;
            posTerminalMg.MachineName = posTerminalMgServerWork.MachineName;
            
            return posTerminalMg;
        }

        /// <summary>�N���X�����o�[�R�s�[�����i�[���Ǘ��N���X�˒[���Ǘ������[�g���[�N�N���X�j</summary>
        /// <param name="PosTerminalMg">�[���Ǘ����[�N�N���X</param>
        /// <returns>�[���Ǘ��N���X</returns>
        /// <remarks>
        /// <br>Note       : �[���Ǘ��N���X����[���Ǘ������[�g���[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br></br>
        /// </remarks>
        private PosTerminalMgServerWork CopyToPosTerminalMgServerWorkFromPosTerminalMg(PosTerminalMg posTerminalMg)
        {
            PosTerminalMgServerWork posTerminalMgServerWork = new PosTerminalMgServerWork();

            posTerminalMgServerWork.CreateDateTime = posTerminalMg.CreateDateTime;
            posTerminalMgServerWork.UpdateDateTime = posTerminalMg.UpdateDateTime;
            posTerminalMgServerWork.EnterpriseCode = posTerminalMg.EnterpriseCode.Trim();
            posTerminalMgServerWork.FileHeaderGuid = posTerminalMg.FileHeaderGuid;
            posTerminalMgServerWork.UpdEmployeeCode = posTerminalMg.UpdEmployeeCode;
            posTerminalMgServerWork.UpdAssemblyId1 = posTerminalMg.UpdAssemblyId1;
            posTerminalMgServerWork.UpdAssemblyId2 = posTerminalMg.UpdAssemblyId2;
            posTerminalMgServerWork.LogicalDeleteCode = posTerminalMg.LogicalDeleteCode;

            posTerminalMgServerWork.CashRegisterNo = posTerminalMg.CashRegisterNo;

            // POS/PC�[���敪
            posTerminalMgServerWork.PosPCTermCd = posTerminalMg.PosPCTermCd;
            
            posTerminalMgServerWork.UseLanguageDivCd = posTerminalMg.UseLanguageDivCd;
            posTerminalMgServerWork.UseCultureDivCd = posTerminalMg.UseCultureDivCd;
            
            posTerminalMgServerWork.MachineIpAddr = posTerminalMg.MachineIpAddr;
            posTerminalMgServerWork.MachineName = posTerminalMg.MachineName;
            
            return posTerminalMgServerWork;
        }

        /// <summary>���O�I�����I�����C����ԃ`�F�b�N����</summary>
        /// <returns>�I�����C����ԃ`�F�b�N����</returns>
        /// <remarks>
        /// <br>Note        : �I�����C����Ԃ��`�F�b�N���A���ʂ�Ԃ��܂��B</br>
        /// <br>Programmer  : 20031 �É�@���S��</br>
        /// <br>Date        : 2007.07.09</br>
        /// </remarks>
        private bool CheckOnline()
        {
            // �I�����C���t���O�ɂ�锻��
            if (Broadleaf.Application.Common.LoginInfoAcquisition.OnlineFlag == false)
            {
                return false;
            }
            else
            {
                // ���[�J���G���A�ڑ���Ԃɂ��I�����C������
                if (CheckRemoteOn() == false)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>�����[�g�ڑ��\����</summary>
        /// <returns>�����[�g�ڑ��\���茋��</returns>
        /// <remarks>
        /// <br>Note        : �����[�g�ڑ�����C���^�[�l�b�g�ڑ���Ԃ𔻒肵�A���ʂ�Ԃ��܂��B</br>
        /// <br>Programmer  : 20031 �É�@���S��</br>
        /// <br>Date        : 2007.07.09</br>
        /// </remarks>
        private bool CheckRemoteOn()
        {
            bool isLocalAreaConnected = NetworkInterface.GetIsNetworkAvailable();
            if (isLocalAreaConnected == false)
            {
                // �C���^�[�l�b�g�ڑ��s�\���
                return false;
            }
            else
            {
                return true;
            }
        }

        // ADD 2009/06/05 ------>>>
        #region -- �ǂݍ��ݏ��� --
        /// <summary>
        /// �ǂݍ��ݏ���
        /// </summary>
        /// <param name="posTerminalMg">UI�f�[�^�N���X</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param> 
        /// <param name="cashRegisterNo">�[���ԍ�</param>  
        /// <remarks>
        /// <br>Note       : </br>
        /// <br></br>
        /// </remarks>
        public int Read(out PosTerminalMg posTerminalMg, string enterpriseCode, int cashRegisterNo)
        {
            return ReadProc(out posTerminalMg, enterpriseCode, cashRegisterNo);
        }

        /// <summary>
        /// �ǂݍ��ݏ���
        /// </summary>
        /// <param name="posTerminalMg">UI�f�[�^�N���X</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param> 
        /// <param name="cashRegisterNo">�[���ԍ�</param>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br></br>
        /// </remarks>
        private int ReadProc(out PosTerminalMg posTerminalMg, string enterpriseCode, int cashRegisterNo)
        {
            int status = 0;

            posTerminalMg = null;

            try
            {
                PosTerminalMgServerWork posTerminalMgServerWork = new PosTerminalMgServerWork();
                posTerminalMgServerWork.EnterpriseCode = enterpriseCode;
                posTerminalMgServerWork.CashRegisterNo = cashRegisterNo;

                // XML�֕ϊ����A������̃o�C�i����
                byte[] parabyte = XmlByteSerializer.Serialize(posTerminalMgServerWork);

                status = this._iPosTerminalMgDB.Read(ref parabyte, 0);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // XML�̓ǂݍ���
                    posTerminalMgServerWork = (PosTerminalMgServerWork)XmlByteSerializer.Deserialize(parabyte, typeof(PosTerminalMgServerWork));
                    // ���[�N��UI�f�[�^�N���X
                    posTerminalMg = CopyToPosTerminalMgFromPosTerminalMgServerWork(posTerminalMgServerWork);
                }

                return status;
            }
            catch (Exception)
            {
                posTerminalMg = null;
                // �I�t���C������null���Z�b�g
                this._iPosTerminalMgDB = null;
                // �ʐM�G���[��-1��߂�
                return -1;
            }
        }
        #endregion

        #region -- �o�^��X�V���� --
        /// <summary>
        /// �o�^�E�X�V����
        /// </summary>
        /// <param name="posTerminalMg">UI�f�[�^�N���X</param>
        /// <param name="delTerminalMg">UI�f�[�^�N���X(�폜�p)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �o�^�E�X�V�������s���܂��B</br>
        /// <br></br>
        /// </remarks>
        public int WriteAll(ref PosTerminalMg posTerminalMg, PosTerminalMg delTerminalMg)
        {
            if (this._employee.UserAdminFlag == 1)
            {
                if (_scmFlg == true)   // 2010/06/29 SCM�I�v�V�������L���Ȃ�Ǘ��҃��[�h�Ŏ��s Add
                    // �Ǘ��҃��[�h
                    return WriteServer(ref posTerminalMg, delTerminalMg);
                // 2010/06/29 Add >>>
                else
                {
                    // ��ʃ��[�U�[���[�h
                    PosTerminalMg posTerminalMgClone = posTerminalMg.Clone();
                    // ���[�J��DB�o�^
                    int status = Write(ref posTerminalMg, delTerminalMg);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }
                    // �T�[�o�[�o�^
                    return WriteServer(ref posTerminalMgClone, delTerminalMg);
                }
            // 2010/06/29 Add <<<
            }
            else
            {
                // ��ʃ��[�U�[���[�h
                PosTerminalMg posTerminalMgClone = posTerminalMg.Clone();
                // ���[�J��DB�o�^
                int status = Write(ref posTerminalMg, delTerminalMg);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }
                // �T�[�o�[�o�^
                return WriteServer(ref posTerminalMgClone, delTerminalMg);
            }
        }

        /// <summary>�[���Ǘ��o�^�E�X�V����(�T�[�o�[)</summary>
        /// <param name="posTerminalMg">�[���Ǘ��N���X</param>
        /// <param name="delTerminalMg">UI�f�[�^�N���X(�폜�p)</param>
        /// <returns>�X�V���ʃX�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �[���Ǘ��̓o�^�E�X�V���s���܂��B</br>
        /// <br></br>
        /// </remarks>
        public int WriteServer(ref PosTerminalMg posTerminalMg, PosTerminalMg delTerminalMg)
        {
            int status = 0;

            try
            {
                if (delTerminalMg != null)
                {
                    // �폜�Ώۂ̒[���ԍ�������
                    PosTerminalMg readPosTerminalMg;
                    status = Read(out readPosTerminalMg, delTerminalMg.EnterpriseCode, delTerminalMg.CashRegisterNo);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // �����f�[�^�̍폜����
                        status = Delete(readPosTerminalMg);
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            return status;
                        }
                    }
                    else if ((status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) &&
                             (status != (int)ConstantManagement.DB_Status.ctDB_EOF))
                    {
                        return status;
                    }
                }

                // UI�f�[�^�N���X�����[�N
                PosTerminalMgServerWork posTerminalMgServerWork = CopyToPosTerminalMgServerWorkFromPosTerminalMg(posTerminalMg);
                object obj = posTerminalMgServerWork;

                // �������ݏ���
                status = this._iPosTerminalMgDB.Write(ref obj);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (obj is ArrayList)
                    {
                        posTerminalMgServerWork = (PosTerminalMgServerWork)((ArrayList)obj)[0];
                        // ���[�N��UI�f�[�^�N���X
                        posTerminalMg = CopyToPosTerminalMgFromPosTerminalMgServerWork(posTerminalMgServerWork);
                    }
                }

                return status;
            }
            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
                this._iPosTerminalMgDB = null;
                // �ʐM�G���[��-1��߂�
                status = -1;
            }

            return status;
        }
        #endregion

        #region -- �폜���� --
        /// <summary>
        /// �_���폜����
        /// </summary>
        /// <param name="posTerminalMg">UI�f�[�^�N���X</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �[���Ǘ������[�g�̘_���폜���s���܂��B</br>
        /// <br></br>
        /// </remarks>
        public int LogicalDelete(ref PosTerminalMg posTerminalMg)
        {
            int status = 0;

            // UI�f�[�^�N���X�����[�N
            PosTerminalMgServerWork posTerminalMgServerWork = CopyToPosTerminalMgServerWorkFromPosTerminalMg(posTerminalMg);

            object obj = posTerminalMgServerWork;

            try
            {
                // �_���폜
                status = this._iPosTerminalMgDB.LogicalDelete(ref obj);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    posTerminalMgServerWork = (PosTerminalMgServerWork)obj;
                    // ���[�N��UI�f�[�^�N���X
                    posTerminalMg = CopyToPosTerminalMgFromPosTerminalMgServerWork(posTerminalMgServerWork);
                }

                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iPosTerminalMgDB = null;
                //�ʐM�G���[��-1��߂�
                return -1;
            }
        }

        /// <summary>
        /// �����폜����
        /// </summary>
        /// <param name="posTerminalMg">UI�f�[�^�N���X</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �[���Ǘ������[�g�̕����폜���s���܂��B</br>
        /// <br></br>
        /// </remarks>
        public int Delete(PosTerminalMg posTerminalMg)
        {
            int status = 0;

            try
            {
                // UI�f�[�^�N���X�����[�N
                PosTerminalMgServerWork posTerminalMgServerWork = CopyToPosTerminalMgServerWorkFromPosTerminalMg(posTerminalMg);

                // XML�֕ϊ����A������̃o�C�i����
                byte[] parabyte = XmlByteSerializer.Serialize(posTerminalMgServerWork);

                // �����폜
                status = this._iPosTerminalMgDB.Delete(parabyte);

                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iPosTerminalMgDB = null;
                //�ʐM�G���[��-1��߂�
                return -1;
            }
        }
        #endregion

        #region -- �������� --
        /// <summary>
        /// �[���Ǘ������[�g��������
        /// </summary>
        /// <param name="posTerminalMg">UI�f�[�^�N���X</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �[���Ǘ������[�g�̕������s���܂�</br>
        /// <br></br>
        /// </remarks>
        public int Revival(ref PosTerminalMg posTerminalMg)
        {
            int status = 0;

            try
            {
                // UI�f�[�^�N���X�����[�N
                PosTerminalMgServerWork posTerminalMgServerWork = CopyToPosTerminalMgServerWorkFromPosTerminalMg(posTerminalMg);

                object obj = posTerminalMgServerWork;

                // ��������
                status = this._iPosTerminalMgDB.RevivalLogicalDelete(ref obj);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    posTerminalMgServerWork = (PosTerminalMgServerWork)obj;
                    // ���[�N��UI�f�[�^�N���X
                    posTerminalMg = CopyToPosTerminalMgFromPosTerminalMgServerWork(posTerminalMgServerWork);
                }

                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iPosTerminalMgDB = null;
                //�ʐM�G���[��-1��߂�
                return -1;
            }
        }
        #endregion
        // ADD 2009/06/05 ------<<<
    }
}

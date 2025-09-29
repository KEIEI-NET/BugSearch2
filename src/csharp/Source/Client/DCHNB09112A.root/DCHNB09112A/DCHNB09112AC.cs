using System;
using System.Collections;
using System.Data;
using System.Collections.Generic;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Windows.Forms;
using Broadleaf.Xml.Serialization;
//----- ueno add---------- start 2008.01.31
using Broadleaf.Application.LocalAccess;
//----- ueno add ---------- end 2008.01.31

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ������z�����敪�ݒ�e�[�u���A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ������z�����敪�ݒ�e�[�u���̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer : 21024 ���X�� ��</br>
    /// <br>Date       : 2007.08.20</br>
    /// <br>Update Note: 2008.01.31 30167 ��� �O�M ���[�J���c�a�Ή�</br>
    /// <br>Update Note: 2009.07.13 20056 ���n ��� LoginInfoAcquisition.OnlineFlag���Q�Ƃ��Đ���ؑւ��s��Ȃ�(���Online)</br>
    /// </remarks>
    public class SalesProcMoneyAcs : IGeneralGuideData
    {
        # region Private Member

        /// <summary>�����[�g�I�u�W�F�N�g�i�[�o�b�t�@</summary>
        private ISalesProcMoneyDB _iSalesProcMoneyDB = null;

		//----- ueno add ---------- start 2008.01.31
		// ���[�J���I�u�W�F�N�g�i�[�o�b�t�@
		private SalesProcMoneyLcDB _salesProcMoneyLcDB = null;
		//----- ueno add ---------- end 2008.01.31

        // Static�i�[�pHashTable
        private static Hashtable _static_SalesProcMoneyTable = null;
        /// <summary>������z�����敪�ݒ�}�X�^�N���XSearch�t���O</summary>
        private static bool _searchFlg;

        // �I�t���C���f�[�^�i�[��p�X
        private string _offlineDataDirPath = "";

        private const string GUIDE_SEARCHMODE_PARA = "SearchMode";                     // �K�C�h�f�[�^�T�[�`���[�h(0:���[�J��,1:�����[�g)

		//----- ueno upd ---------- start 2008.01.31
        //private static bool _isLocalDBRead = true;
        private static bool _isLocalDBRead = false;	// �f�t�H���g�̓����[�g
		//----- ueno upd ---------- end 2008.01.31

        # endregion

        #region �R���X�g���N�^
        /// <summary>
        /// ������z�����敪�ݒ�e�[�u���A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ������z�����敪�ݒ�e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 21024 ���X�� ��</br>
        /// <br>Date       : 2007.08.20</br>
        /// </remarks>
        public SalesProcMoneyAcs()
        {
            // ��������������
            MemoryCreate();

            // �I�t���C���f�[�^�i�[��p�X
            this._offlineDataDirPath = ConstantManagement_ClientDirectory.LocalApplicationData_AppSettingData;

            // 2009.07.13 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //// ���O�C�����i�ŒʐM��Ԃ��m�F
            //if (LoginInfoAcquisition.OnlineFlag)
            //{
            //    try
            //    {
            //        // �����[�g�I�u�W�F�N�g�擾
            //        this._iSalesProcMoneyDB = (ISalesProcMoneyDB)MediationSalesProcMoneyDB.GetSalesProcMoneyDB();
            //    }
            //    catch (Exception)
            //    {
            //        // �I�t���C������null���Z�b�g
            //        this._iSalesProcMoneyDB = null;
            //    }
            //}
            //else
            //{
            //    // �I�t���C�����̃f�[�^�ǂݍ���(������)
            //}

            try
            {
                // �����[�g�I�u�W�F�N�g�擾
                this._iSalesProcMoneyDB = (ISalesProcMoneyDB)MediationSalesProcMoneyDB.GetSalesProcMoneyDB();
            }
            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
                this._iSalesProcMoneyDB = null;
            }
            // 2009.07.13 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

			//----- ueno add ---------- start 2008.01.31
			// ���[�J��DB�A�N�Z�X�I�u�W�F�N�g�擾
			this._salesProcMoneyLcDB = new SalesProcMoneyLcDB();
			//----- ueno add ---------- end 2008.01.31
        }

        /// <summary>
        /// ������z�����敪�ݒ�e�[�u���A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ������z�����敪�ݒ�e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 21024 ���X�� ��</br>
        /// <br>Date       : 2007.08.20</br>
        /// </remarks>
        static SalesProcMoneyAcs()
        {
            // Static�i�[�pHashTable
            _static_SalesProcMoneyTable = new Hashtable();
        }
        #endregion

        #region Public Property

        //================================================================================
        //  �v���p�e�B
        //================================================================================
        /// <summary>
        /// ���[�J���c�aRead���[�h
        /// </summary>
        public bool IsLocalDBRead
        {
            get { return _isLocalDBRead; }
            set { _isLocalDBRead = value; }
        }

        #endregion

        #region Public Method

        /// <summary>
        /// �I�����C�����[�h�擾����
        /// </summary>
        /// <returns>OnlineMode</returns>
        /// <remarks>
        /// <br>Note       : �I�����C�����[�h���擾���܂��B</br>
        /// <br>Programmer : 21024 ���X�� ��</br>
        /// <br>Date       : 2007.08.20</br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if (this._iSalesProcMoneyDB == null)
            {
                return (int)ConstantManagement.OnlineMode.Offline;
            }
            else
            {
                return (int)ConstantManagement.OnlineMode.Online;
            }
        }

        /// <summary>
        /// ������z�����敪�ݒ� Static�������S���擾����
        /// </summary>
        /// <param name="retList">������z�����敪�ݒ�}�X�^ �N���XList</param>
        /// <returns>�X�e�[�^�X(0:����I��, -1:�G���[, 9:�f�[�^����)</returns>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <remarks>
        /// <br>Note       : ������z�����敪�ݒ�}�X�^ Static�������̑S�����擾���܂��B</br>
        /// <br>Programer  : 21024  ���X��  ��</br>
        /// <br>Date       : 2007.08.28</br>
        /// </remarks>
        public int SearchStaticMemory( out ArrayList retList, string enterpriseCode )
        {
            retList = new ArrayList();
            retList.Clear();
            SortedList sortedList = new SortedList();

            if (( _static_SalesProcMoneyTable == null ) ||
                ( _static_SalesProcMoneyTable.Count == 0 ))
            {
                //return -1;
                this.SearchAll(out retList, enterpriseCode);

                return 0;
            }
            else if (_static_SalesProcMoneyTable.Count == 0)
            {
                return 9;
            }

            foreach (SalesProcMoney salesProcMoney in _static_SalesProcMoneyTable.Values)
            {
                sortedList.Add(CreateHashKey(salesProcMoney), salesProcMoney);
            }

            retList.AddRange(sortedList.Values);

            return 0;
        }

        /// <summary>
        /// ������z�����敪�ݒ�ǂݍ��ݏ���
        /// </summary>
        /// <param name="salesProcMoney">������z�����敪�ݒ�I�u�W�F�N�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="fracProcMoneyDiv">�[�������Ώۋ��z�敪</param>
        /// <param name="fractionProcCode">�[�������R�[�h</param>
        /// <param name="upperLimitPrice">������z</param>
        /// <returns>������z�����敪�ݒ�N���X</returns>
        /// <remarks>
        /// <br>Note       : ������z�����敪�ݒ����ǂݍ��݂܂��B</br>
        /// <br>Programmer : 21024 ���X�� ��</br>
        /// <br>Date       : 2007.08.20</br>
        /// </remarks>
        public int Read( out SalesProcMoney salesProcMoney, string enterpriseCode, Int32 fracProcMoneyDiv, Int32 fractionProcCode, Double upperLimitPrice )
        {
            try
            {
                int status = 0;
                salesProcMoney = null;
                SalesProcMoneyWork salesProcMoneyWork = new SalesProcMoneyWork();

                // �L�[���ڐݒ�
                salesProcMoneyWork.EnterpriseCode = enterpriseCode;
                salesProcMoneyWork.FracProcMoneyDiv = fracProcMoneyDiv;
                salesProcMoneyWork.FractionProcCode = fractionProcCode;
                salesProcMoneyWork.UpperLimitPrice = upperLimitPrice;

				//----- ueno upd ---------- start 2008.01.31
				// ���[�J��
                if (_isLocalDBRead)
                {
					status = this._salesProcMoneyLcDB.Read(ref salesProcMoneyWork, 0);
                }
                // �����[�g
                else
                {
                    // XML�֕ϊ����A������̃o�C�i����
                    byte[] parabyte = XmlByteSerializer.Serialize(salesProcMoneyWork);

                    // ������z�����敪�ݒ�ǂݍ���
                    status = this._iSalesProcMoneyDB.Read(ref parabyte, 0);

                    // XML�̓ǂݍ��� 
                    salesProcMoneyWork = (SalesProcMoneyWork)XmlByteSerializer.Deserialize(parabyte, typeof(SalesProcMoneyWork));
                }
				//----- ueno upd ---------- end 2008.01.31

                if (status == 0)
                {
                    // �N���X�������o�R�s�[
                    salesProcMoney = CopyToSalesProcMoneyFromSalesProcMoneyWork(salesProcMoneyWork);
                    // Read�pStatic�ɕێ�
                    _static_SalesProcMoneyTable[CreateHashKey(salesProcMoney)] = salesProcMoney;
                }
                return status;
            }
            catch (Exception)
            {
                // �ʐM�G���[��-1��߂�
                salesProcMoney = null;
                // �I�t���C������null���Z�b�g
                this._iSalesProcMoneyDB = null;
                return -1;
            }
        }

        /// <summary>
        /// ������z�����敪�ݒ�o�^�E�X�V����
        /// </summary>
        /// <param name="salesProcMoney">������z�����敪�ݒ�N���X</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ������z�����敪�ݒ���̓o�^�E�X�V���s���܂��B</br>
        /// <br>Programmer : 21024 ���X�� ��</br>
        /// <br>Date       : 2007.08.20</br>
        /// </remarks>
        public int Write( ref SalesProcMoney salesProcMoney )
        {
            int status = 0;

            try
            {
                // ������z�����敪�ݒ�N���X���甄����z�����敪�ݒ胏�[�N�N���X�Ƀ����o�R�s�[
                SalesProcMoneyWork salesProcMoneyWork = CopyToSalesProcMoneyWorkFromSalesProcMoney(salesProcMoney);

                ArrayList paraList = new ArrayList();
                paraList.Add(salesProcMoneyWork);
                object paraObj = (object)paraList;

                //������z�����敪�ݒ菑������
                status = this._iSalesProcMoneyDB.Write(ref paraObj);

                if (status == 0)
                {
                    paraList = paraObj as ArrayList;

                    salesProcMoneyWork = (SalesProcMoneyWork)paraList[0];
                    // �N���X�������o�R�s�[
                    salesProcMoney = CopyToSalesProcMoneyFromSalesProcMoneyWork(salesProcMoneyWork);
                    // Read�pStatic�ɍX�V
                    _static_SalesProcMoneyTable[CreateHashKey(salesProcMoney)] = salesProcMoney;
                }
            }
            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
                this._iSalesProcMoneyDB = null;
                // �ʐM�G���[��-1��߂�
                status = -1;
            }

            return status;
        }

        /// <summary>
        /// ������z�����敪�ݒ�_���폜����
        /// </summary>
        /// <param name="salesProcMoney">������z�����敪�ݒ�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ������z�����敪�ݒ���̘_���폜���s���܂��B</br>
        /// <br>Programmer : 21024 ���X�� ��</br>
        /// <br>Date       : 2007.08.20</br>
        /// </remarks>
        public int LogicalDelete( ref SalesProcMoney salesProcMoney )
        {
            try
            {
                int status = 0;
                SalesProcMoneyWork salesProcMoneyWork = CopyToSalesProcMoneyWorkFromSalesProcMoney(salesProcMoney);

                ArrayList paraList = new ArrayList();
                paraList.Add(salesProcMoneyWork);
                object paraObj = (object)paraList;

                // �_���폜
                status = this._iSalesProcMoneyDB.LogicalDelete(ref paraObj);

                if (status == 0)
                {
                    paraList = paraObj as ArrayList;
                    salesProcMoneyWork = (SalesProcMoneyWork)paraList[0];
                    // �N���X�������o�R�s�[
                    salesProcMoney = CopyToSalesProcMoneyFromSalesProcMoneyWork(salesProcMoneyWork);
                    // Read�pStatic�ɍX�V
                    _static_SalesProcMoneyTable[CreateHashKey(salesProcMoney)] = salesProcMoney.Clone();
                }
                return status;
            }
            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
                this._iSalesProcMoneyDB = null;
                // �ʐM�G���[��-1��߂�
                return -1;
            }
        }

        /// <summary>
        /// ������z�����敪�ݒ蕨���폜����
        /// </summary>
        /// <param name="salesProcMoney">������z�����敪�ݒ�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ������z�����敪�ݒ���̕����폜���s���܂��B</br>
        /// <br>Programmer : 21024 ���X�� ��</br>
        /// <br>Date       : 2007.08.20</br>
        /// </remarks>
        public int Delete( SalesProcMoney salesProcMoney )
        {
            try
            {
                int status = 0;
                SalesProcMoneyWork salesProcMoneyWork = CopyToSalesProcMoneyWorkFromSalesProcMoney(salesProcMoney);

                // XML�֕ϊ����A������̃o�C�i����
                byte[] parabyte = XmlByteSerializer.Serialize(salesProcMoneyWork);

                // �����폜
                status = this._iSalesProcMoneyDB.Delete(parabyte);

                // Static�X�V
                _static_SalesProcMoneyTable.Remove(CreateHashKey(salesProcMoney));

                return status;
               
            }
            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
                this._iSalesProcMoneyDB = null;
                // �ʐM�G���[��-1��߂�
                return -1;
            }
        }

        /// <summary>
        /// ������z�����敪�ݒ�S���������i�_���폜�����j
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ������z�����敪�ݒ�̑S�����������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
        /// <br>Programmer : 21024 ���X�� ��</br>
        /// <br>Date       : 2007.08.20</br>
        /// </remarks>
        public int Search( out ArrayList retList, string enterpriseCode )
        {
            int retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, enterpriseCode, ConstantManagement.LogicalMode.GetData0, null);
        }

        /// <summary>
        /// ������z�����敪�ݒ茟�������i�_���폜�܂ށj
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ������z�����敪�ݒ�̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
        /// <br>Programmer : 21024 ���X�� ��</br>
        /// <br>Date       : 2007.08.20</br>
        /// </remarks>
        public int SearchAll( out ArrayList retList, string enterpriseCode )
        {
            int retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, enterpriseCode, ConstantManagement.LogicalMode.GetDataAll, null);
        }

        /// <summary>
        /// �����w�蔄����z�����敪�ݒ茟�������i�_���폜�����j
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������(prevSalesProcMoney��null�̏ꍇ�̂ݖ߂�)</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="prevSalesProcMoney">�O��ŏI������z�����敪�ݒ�f�[�^�I�u�W�F�N�g�i�����null�w��K�{�j</param>			
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �������w�肵�Ĕ�����z�����敪�ݒ�̌����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
        /// <br>Programmer : 21024 ���X�� ��</br>
        /// <br>Date       : 2007.08.20</br>
        /// </remarks>
        public int SearchAll( out ArrayList retList, out int retTotalCnt, string enterpriseCode, SalesProcMoney prevSalesProcMoney )
        {
            return SearchProc(out retList, out retTotalCnt, enterpriseCode, ConstantManagement.LogicalMode.GetData01, prevSalesProcMoney);
        }

        /// <summary>
        /// ������z�����敪�ݒ�}�X�^���������iDataSet�p�j
        /// </summary>
        /// <param name="ds">�擾���ʊi�[�pDataSet</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="fracProcMoneyDiv">�[�������Ώۋ��z�敪</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ������z�����敪�ݒ�}�X�^�̌����������s���A�擾���ʂ�DataSet�ŕԂ��܂��B</br>
        /// <br>Programmer : 21024 ���X�� ��</br>
        /// <br>Date       : 2007.08.28</br>
        /// </remarks>
        public int Search( ref DataSet ds, string enterpriseCode, int fracProcMoneyDiv )
        {
            ArrayList ar = new ArrayList();
            ArrayList salesProcMoneyList = new ArrayList();

            int status = 0;
            int retTotalCnt;

            // 2009.07.13 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //// �I�����C�����ASearch���s���Ă��Ȃ��ꍇ�i�I�t���C���̏ꍇ�̓R���X�g���N�^��Static�W�J�ς݁j
            //if (( !_searchFlg ) && ( LoginInfoAcquisition.OnlineFlag ))
            //{
            //    // ������z�����敪�ݒ�}�X�^�T�[�`
            //    status = this.SearchProc(out salesProcMoneyList, out retTotalCnt, enterpriseCode, ConstantManagement.LogicalMode.GetDataAll, null);
            //    if (status == 0)
            //    {
            //    }
            //    else
            //    {
            //        return status;
            //    }
            //}

            // �I�����C�����ASearch���s���Ă��Ȃ��ꍇ�i�I�t���C���̏ꍇ�̓R���X�g���N�^��Static�W�J�ς݁j
            if (!_searchFlg)
            {
                // ������z�����敪�ݒ�}�X�^�T�[�`
                status = this.SearchProc(out salesProcMoneyList, out retTotalCnt, enterpriseCode, ConstantManagement.LogicalMode.GetDataAll, null);
                if (status == 0)
                {
                }
                else
                {
                    return status;
                }
            }
            // 2009.07.13 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            // Static����K�C�h�\���i�I��/�I�t���ʁj	
            foreach (SalesProcMoney salesProcMoney in _static_SalesProcMoneyTable.Values)
            {
                // �[�������Ώۋ敪���w�肳��Ă���ꍇ�͂����ōi�荞��
                if (( fracProcMoneyDiv == -1 ) || ( salesProcMoney.FracProcMoneyDiv == fracProcMoneyDiv ))
                {
                    // �S�Е\��
                    ar.Add(salesProcMoney.Clone());
                }
            }

            ArrayList wkList = ar.Clone() as ArrayList;
            SortedList wkSort = new SortedList();

            // --- [�S��] --- //
            // ���̂܂ܑS���Ԃ�
            foreach (SalesProcMoney wkSalesProcMoney in wkList)
            {
                if (wkSalesProcMoney.LogicalDeleteCode == 0)
                {
                    wkSort.Add(CreateHashKey(wkSalesProcMoney),wkSalesProcMoney);
                }
            }

            SalesProcMoney[] salesProcMoneys = new SalesProcMoney[wkSort.Count];

            // �f�[�^�����ɖ߂�
            for (int i = 0; i < wkSort.Count; i++)
            {
                salesProcMoneys[i] = (SalesProcMoney)wkSort.GetByIndex(i);
            }

            byte[] retbyte = XmlByteSerializer.Serialize(salesProcMoneys);
            XmlByteSerializer.ReadXml(ref ds, retbyte);

            return status;
        }


        /// <summary>
        /// ������z�����敪�ݒ�_���폜��������
        /// </summary>
        /// <param name="salesProcMoney">������z�����敪�ݒ�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ������z�����敪�ݒ���̕������s���܂��B</br>
        /// <br>Programmer : 21024 ���X�� ��</br>
        /// <br>Date       : 2007.08.20</br>
        /// </remarks>
        public int Revival( ref SalesProcMoney salesProcMoney )
        {
            try
            {
                int status = 0;
                SalesProcMoneyWork salesProcMoneyWork = CopyToSalesProcMoneyWorkFromSalesProcMoney(salesProcMoney);

                ArrayList paraList = new ArrayList();
                paraList.Add(salesProcMoneyWork);
                object paraObj = (object)paraList;

                // ��������
                status = this._iSalesProcMoneyDB.RevivalLogicalDelete(ref paraObj);

                if (status == 0)
                {
                    paraList = paraObj as ArrayList;
                    salesProcMoneyWork = (SalesProcMoneyWork)paraList[0];

                    // �N���X�������o�R�s�[
                    salesProcMoney = CopyToSalesProcMoneyFromSalesProcMoneyWork(salesProcMoneyWork);
                    // Static�X�V
                    _static_SalesProcMoneyTable[CreateHashKey(salesProcMoney)] = salesProcMoney;
                }

                return status;
            }
            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
                this._iSalesProcMoneyDB = null;
                // �ʐM�G���[��-1��߂�
                return -1;
            }
        }

        /// <summary>
        /// �}�X�^�K�C�h�N������(�ʏ�(���[�J��))
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="fracProcMoneyDiv">�[�������Ώۋ��z�敪</param>
        /// <param name="salesProcMoney">������z�����敪�ݒ�UI�N���X</param>
        /// <returns>STATUS[0:�擾����,1:�L�����Z��]</returns>
        /// <remarks>
        /// <br>Note       : �}�X�^�̈ꗗ�\���@�\�����K�C�h���N�����܂��B</br>
        /// <br>Programmer : 21024 ���X�� ��</br>
        /// <br>Date       : 2007.08.28</br>
        /// </remarks>
        public int ExecuteGuid( string enterpriseCode, int fracProcMoneyDiv, out SalesProcMoney salesProcMoney )
        {
            if (this.GetOnlineMode() == (int)ConstantManagement.OnlineMode.Offline)
            {
                // ���[�J��
                return this.ExecuteGuid(enterpriseCode, fracProcMoneyDiv, out salesProcMoney, 0);
            }
            else
            {
                // �����[�g
                return this.ExecuteGuid(enterpriseCode, fracProcMoneyDiv, out salesProcMoney, 1);
            }
        }

        #region ���K�C�h�N������
        /// <summary>
        /// ������z�����敪�ݒ�K�C�h�N������
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="fracProcMoneyDiv">�[�������Ώۋ��z�敪</param>
        /// <param name="salesProcMoney">�擾�f�[�^</param>
        /// <param name="searchMode">�Ǎ����[�h(0:���[�J��,1:�����[�g)</param>
        /// <returns>STATUS[0:�擾����,1:�L�����Z��]</returns>
        /// <remarks>
        /// <br>Note		: ������z�����敪�ݒ�}�X�^�̈ꗗ�\���@�\�����K�C�h���N�����܂��B</br>
        /// <br>Programmer	: 21024 ���X�� ��</br>
        /// <br>Date		: 2007.08.28</br>
        /// </remarks>
        public int ExecuteGuid( string enterpriseCode, int fracProcMoneyDiv, out SalesProcMoney salesProcMoney, int searchMode )
        {
            int status = -1;
            salesProcMoney = new SalesProcMoney();
            TableGuideParent tableGuideParent = new TableGuideParent("SALESPROCMONEYGUIDEPARENT.XML");
            Hashtable inObj = new Hashtable();
            Hashtable retObj = new Hashtable();

            // ��ƃR�[�h
            inObj.Add("EnterpriseCode", enterpriseCode);
            inObj.Add("FracProcMoneyDiv", fracProcMoneyDiv);
            // �K�C�h�f�[�^�T�[�`���[�h(0:���[�J��,1:�����[�g)
            inObj.Add(GUIDE_SEARCHMODE_PARA, searchMode);

            if (tableGuideParent.Execute(0, inObj, ref retObj))
            {
                salesProcMoney.FracProcMoneyDiv = int.Parse(retObj["FracProcMoneyDiv"].ToString());
                salesProcMoney.UpperLimitPrice = double.Parse(retObj["UpperLimitPrice"].ToString());
                salesProcMoney.FractionProcCdNm = retObj["FractionProcCdNm"].ToString();
                salesProcMoney.FractionProcCode = int.Parse(retObj["FractionProcCode"].ToString());
                salesProcMoney.FractionProcCd = SalesProcMoney.GetFractionProcCd(salesProcMoney.FractionProcCdNm);

                status = 0;
            }
            // �L�����Z��
            else
            {
                status = 1;
            }

            return status;
        }
        # endregion

        #region ��IGeneralGuidData Method
        /// <summary>
        /// �ėp�K�C�h�f�[�^�擾(IGeneralGuidData�C���^�[�t�F�[�X����)
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="inParm"></param>
        /// <param name="guideList"></param>
        /// <returns>STATUS[0:�擾����,1:�L�����Z��,4:���R�[�h����]</returns>
        /// <remarks>
        /// <br>Note		: �ėp�K�C�h�ݒ�p�f�[�^���擾���܂��B</br>
        /// <br>Programmer	: 21024 ���X�� ��</br>
        /// <br>Date		: 2007.08.28</br>
        /// </remarks>
        public int GetGuideData( int mode, Hashtable inParm, ref DataSet guideList )
        {
            int status = -1;
            string enterpriseCode = "";
            int fracProcMoneyDiv = 0;

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

            // �[�������Ώۋ��z�敪�ݒ�L��
            if (inParm.ContainsKey("FracProcMoneyDiv"))
            {
                fracProcMoneyDiv = (Int32)inParm["FracProcMoneyDiv"];
            }

            // ������z�����敪�ݒ�}�X�^�e�[�u���Ǎ���(���[�J��DB)  
            int searchMode = 0;
            _searchFlg = false;
            if (inParm.ContainsKey(GUIDE_SEARCHMODE_PARA))
            {
                searchMode = int.Parse(inParm[GUIDE_SEARCHMODE_PARA].ToString());
            }

            if (searchMode == 1)
            {
                status = Search(ref guideList, enterpriseCode, fracProcMoneyDiv);
            }
            else
            {
                //status = SearchLocalDB(ref guideList, enterpriseCode);
            }
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
        #endregion

        # endregion

        #region Private Method

        /// <summary>
        /// ������z�����敪�ݒ茟������
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������(prevSalesProcMoney��null�̏ꍇ�̂ݖ߂�)</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�S�f�[�^)</param>
        /// <param name="prevSalesProcMoney">�O��ŏI������z�����敪�ݒ�f�[�^�I�u�W�F�N�g�i�����null�w��K�{�j</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ������z�����敪�ݒ�̌����������s���܂��B</br>
        /// <br>Programmer : 21024 ���X�� ��</br>
        /// <br>Date       : 2007.08.20</br>
        /// </remarks>
        private int SearchProc( out ArrayList retList, out int retTotalCnt, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, SalesProcMoney prevSalesProcMoney )
        {
            SalesProcMoneyWork salesProcMoneyWork = new SalesProcMoneyWork();

            if (prevSalesProcMoney != null)
            {
                salesProcMoneyWork = CopyToSalesProcMoneyWorkFromSalesProcMoney(prevSalesProcMoney);
            }
            salesProcMoneyWork.EnterpriseCode = enterpriseCode;
            salesProcMoneyWork.FracProcMoneyDiv = -1;
            salesProcMoneyWork.FractionProcCode = -1;

            retList = new ArrayList();
            retList.Clear();
            ArrayList paraList = new ArrayList();

            retTotalCnt = 0;
            int status = 0;

            object retObj = null;

            ArrayList al = new ArrayList();
            al.Add(salesProcMoneyWork);
            object paraObj = al;

            // 2009.07.13 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //// �I�t���C���̏ꍇ�̓L���b�V������ǂ�
            //if (!LoginInfoAcquisition.OnlineFlag)
            //{
            //    status = SearchStaticMemory(out retList, enterpriseCode);
            //}
            //else
            //{
            //    SalesProcMoney salesProcMoney = new SalesProcMoney();

            //    //----- ueno upd ---------- start 2008.01.31
            //    if (_isLocalDBRead)
            //    {
            //        // ���[�J��
            //        List<SalesProcMoneyWork> salesProcMoneyWorkList = new List<SalesProcMoneyWork>();
            //        status = this._salesProcMoneyLcDB.Search(out salesProcMoneyWorkList, salesProcMoneyWork, 0, logicalMode);

            //        if (status == 0)
            //        {
            //            ArrayList wkAl = new ArrayList();
            //            wkAl.AddRange(salesProcMoneyWorkList);
            //            retObj = (object)wkAl;
            //        }
            //    }
            //    else
            //    {
            //        // �����[�g 
            //        status = this._iSalesProcMoneyDB.Search(out retObj, paraObj, 0, logicalMode);
            //    }
            //    //----- ueno upd ---------- end 2008.01.31
				
            //    if (status == 0)
            //    {
            //        // ������z�����敪�ݒ�}�X�^���[�J�[�N���X��UI�N���XStatic�]�L����
            //        CopyToStaticFromWorker(retObj as ArrayList);

            //        // �p�����[�^���n���ė��Ă��邩�m�F
            //        paraList = retObj as ArrayList;
            //        SalesProcMoneyWork[] wkSalesProcMoneyWork = new SalesProcMoneyWork[paraList.Count];

            //        // �f�[�^�����ɖ߂�
            //        for (int i = 0; i < paraList.Count; i++)
            //        {
            //            wkSalesProcMoneyWork[i] = (SalesProcMoneyWork)paraList[i];
            //        }
            //        for (int i = 0; i < wkSalesProcMoneyWork.Length; i++)
            //        {
            //            salesProcMoney = CopyToSalesProcMoneyFromSalesProcMoneyWork(wkSalesProcMoneyWork[i]);
            //            // �T�[�`���ʎ擾
            //            retList.Add(salesProcMoney);
            //            // �X�^�e�B�b�N�X�V
            //            _static_SalesProcMoneyTable[CreateHashKey(salesProcMoney)] = salesProcMoney;
            //        }
            //        // SearchFlg ON
            //        _searchFlg = true;
            //    }
            //}

            SalesProcMoney salesProcMoney = new SalesProcMoney();

            if (_isLocalDBRead)
            {
                // ���[�J��
                List<SalesProcMoneyWork> salesProcMoneyWorkList = new List<SalesProcMoneyWork>();
                status = this._salesProcMoneyLcDB.Search(out salesProcMoneyWorkList, salesProcMoneyWork, 0, logicalMode);

                if (status == 0)
                {
                    ArrayList wkAl = new ArrayList();
                    wkAl.AddRange(salesProcMoneyWorkList);
                    retObj = (object)wkAl;
                }
            }
            else
            {
                // �����[�g 
                status = this._iSalesProcMoneyDB.Search(out retObj, paraObj, 0, logicalMode);
            }

            if (status == 0)
            {
                // ������z�����敪�ݒ�}�X�^���[�J�[�N���X��UI�N���XStatic�]�L����
                CopyToStaticFromWorker(retObj as ArrayList);

                // �p�����[�^���n���ė��Ă��邩�m�F
                paraList = retObj as ArrayList;
                SalesProcMoneyWork[] wkSalesProcMoneyWork = new SalesProcMoneyWork[paraList.Count];

                // �f�[�^�����ɖ߂�
                for (int i = 0; i < paraList.Count; i++)
                {
                    wkSalesProcMoneyWork[i] = (SalesProcMoneyWork)paraList[i];
                }
                for (int i = 0; i < wkSalesProcMoneyWork.Length; i++)
                {
                    salesProcMoney = CopyToSalesProcMoneyFromSalesProcMoneyWork(wkSalesProcMoneyWork[i]);
                    // �T�[�`���ʎ擾
                    retList.Add(salesProcMoney);
                    // �X�^�e�B�b�N�X�V
                    _static_SalesProcMoneyTable[CreateHashKey(salesProcMoney)] = salesProcMoney;
                }
                // SearchFlg ON
                _searchFlg = true;
            }
            // 2009.07.13 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            return status;
        }

        /// <summary>
        /// �N���X�����o�[�R�s�[�����i������z�����敪�ݒ胏�[�N�N���X�˔�����z�����敪�ݒ�N���X�j
        /// </summary>
        /// <param name="salesProcMoneyWork">������z�����敪�ݒ胏�[�N�N���X</param>
        /// <returns>������z�����敪�ݒ�N���X</returns>
        /// <remarks>
        /// <br>Note       : ������z�����敪�ݒ胏�[�N�N���X���甄����z�����敪�ݒ�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : 21024 ���X�� ��</br>
        /// <br>Date       : 2007.08.20</br>
        /// </remarks>
        private SalesProcMoney CopyToSalesProcMoneyFromSalesProcMoneyWork( SalesProcMoneyWork salesProcMoneyWork )
        {
            SalesProcMoney salesProcMoney = new SalesProcMoney();

            salesProcMoney.CreateDateTime = salesProcMoneyWork.CreateDateTime;
            salesProcMoney.UpdateDateTime = salesProcMoneyWork.UpdateDateTime;
            salesProcMoney.EnterpriseCode = salesProcMoneyWork.EnterpriseCode;
            salesProcMoney.FileHeaderGuid = salesProcMoneyWork.FileHeaderGuid;
            salesProcMoney.UpdEmployeeCode = salesProcMoneyWork.UpdEmployeeCode;
            salesProcMoney.UpdAssemblyId1 = salesProcMoneyWork.UpdAssemblyId1;
            salesProcMoney.UpdAssemblyId2 = salesProcMoneyWork.UpdAssemblyId2;
            salesProcMoney.LogicalDeleteCode = salesProcMoneyWork.LogicalDeleteCode;
            salesProcMoney.FracProcMoneyDiv = salesProcMoneyWork.FracProcMoneyDiv;
            salesProcMoney.FractionProcCode = salesProcMoneyWork.FractionProcCode;
            salesProcMoney.UpperLimitPrice = salesProcMoneyWork.UpperLimitPrice;
            salesProcMoney.FractionProcUnit = salesProcMoneyWork.FractionProcUnit;
            salesProcMoney.FractionProcCd = salesProcMoneyWork.FractionProcCd;
            salesProcMoney.FractionProcCdNm = SalesProcMoney.GetFractionProcCdNm(salesProcMoneyWork.FractionProcCd);

            return salesProcMoney;
        }

        /// <summary>
        /// �N���X�����o�[�R�s�[�����i������z�����敪�ݒ�N���X�˔�����z�����敪�ݒ胏�[�N�N���X�j
        /// </summary>
        /// <param name="salesProcMoney">������z�����敪�ݒ胏�[�N�N���X</param>
        /// <returns>������z�����敪�ݒ�N���X</returns>
        /// <remarks>
        /// <br>Note       : ������z�����敪�ݒ�N���X���甄����z�����敪�ݒ胏�[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : 21024 ���X�� ��</br>
        /// <br>Date       : 2007.08.20</br>
        /// </remarks>
        private SalesProcMoneyWork CopyToSalesProcMoneyWorkFromSalesProcMoney( SalesProcMoney salesProcMoney )
        {
            SalesProcMoneyWork salesProcMoneyWork = new SalesProcMoneyWork();

            salesProcMoneyWork.CreateDateTime = salesProcMoney.CreateDateTime;
            salesProcMoneyWork.UpdateDateTime = salesProcMoney.UpdateDateTime;
            salesProcMoneyWork.EnterpriseCode = salesProcMoney.EnterpriseCode.Trim();
            salesProcMoneyWork.FileHeaderGuid = salesProcMoney.FileHeaderGuid;
            salesProcMoneyWork.UpdEmployeeCode = salesProcMoney.UpdEmployeeCode;
            salesProcMoneyWork.UpdAssemblyId1 = salesProcMoney.UpdAssemblyId1;
            salesProcMoneyWork.UpdAssemblyId2 = salesProcMoney.UpdAssemblyId2;
            salesProcMoneyWork.LogicalDeleteCode = salesProcMoney.LogicalDeleteCode;
            salesProcMoneyWork.FracProcMoneyDiv = salesProcMoney.FracProcMoneyDiv;
            salesProcMoneyWork.FractionProcCode = salesProcMoney.FractionProcCode;
            salesProcMoneyWork.UpperLimitPrice = salesProcMoney.UpperLimitPrice;
            salesProcMoneyWork.FractionProcUnit = salesProcMoney.FractionProcUnit;
            salesProcMoneyWork.FractionProcCd = salesProcMoney.FractionProcCd;

            return salesProcMoneyWork;
        }

        /// <summary>
        /// ��������������
        /// </summary>
        /// <remarks>
        /// <br>Note       : ������z�����敪�ݒ�A�N�Z�X�N���X���ێ����郁�����𐶐����܂��B</br>
        /// <br>Programer  : 21024 ���X�؁@��</br>
        /// <br>Date       : 2007.08.28</br>
        /// </remarks>
        private void MemoryCreate()
        {

            // ������z�����敪�ݒ�}�X�^�N���XStatic
            if (_static_SalesProcMoneyTable == null)
            {
                _static_SalesProcMoneyTable = new Hashtable();
            }
        }

        /// <summary>
        /// ���[�J���t�@�C���Ǎ��ݏ���
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[�J���t�@�C����Ǎ���ŁA����Static�ɕێ����܂��B</br>
        /// <br>Programer  : 21024  ���X�؁@��</br>
        /// <br>Date       : 2007.08.28</br>
        /// </remarks>
        private void SearchOfflineData()
        {
            // �I�t���C���V���A���C�Y�f�[�^�쐬���iI/O
            OfflineDataSerializer offlineDataSerializer = new OfflineDataSerializer();

            // --- Search�p --- //
            // KeyList�ݒ�
            string[] salesProcMoneyKeys = new string[1];
            salesProcMoneyKeys[0] = LoginInfoAcquisition.EnterpriseCode;
            // ���[�J���t�@�C���Ǎ��ݏ���
            object wkObj = offlineDataSerializer.DeSerialize("SalesProcMoneyAcs", salesProcMoneyKeys);
            // ArrayList�ɃZ�b�g
            List<SalesProcMoneyWork> wkList = new List<SalesProcMoneyWork>();

            if (( wkList != null ) &&
                ( wkList.Count != 0 ))
            {
                // ������z�����敪�ݒ胏�[�J�[�N���X�iArrayList�j �� UI�N���X�iStatic�j�ϊ�����
                CopyToStaticFromWorker(wkList);
            }
        }

        /// <summary>
        /// ������z�����敪�ݒ胏�[�J�[�N���X�iList�j �� UI�N���X�ϊ�����
        /// </summary>
        /// <param name="salesProcMoneyWorkList">������z�����敪�ݒ�}�X�^���[�J�[�N���X��ArrayList</param>
        /// <remarks>
        /// <br>Note       : ������z�����敪�ݒ�}�X�^���[�J�[�N���X��UI�̃N���X�ɕϊ����āA
        ///					 Search�pStatic�������ɕێ����܂��B</br>
        /// <br>Programer  : 21024  ���X��  ��</br>
        /// <br>Date       : 2007.08.28</br>
        /// </remarks>
        private void CopyToStaticFromWorker( List<SalesProcMoneyWork> salesProcMoneyWorkList )
        {
            ArrayList salesProcMoneyWorkArray = new ArrayList();
            salesProcMoneyWorkArray.AddRange(salesProcMoneyWorkList);

            CopyToStaticFromWorker(salesProcMoneyWorkArray);
        }

        /// <summary>
        /// ������z�����敪�ݒ胏�[�J�[�N���X�iArrayList�j �� UI�N���X�ϊ�����
        /// </summary>
        /// <param name="salesProcMoneyWorkList">������z�����敪�ݒ�}�X�^���[�J�[�N���X��ArrayList</param>
        /// <remarks>
        /// <br>Note       : ������z�����敪�ݒ胏�[�J�[�N���X��UI�̃N���X�ɕϊ����āA
        ///					 Search�pStatic�������ɕێ����܂��B</br>
        /// <br>Programer  : 21024  ���X��  ��</br>
        /// <br>Date       : 2007.08.28</br>
        /// </remarks>
        private void CopyToStaticFromWorker( ArrayList salesProcMoneyWorkList )
        {
            string hashKey;
            foreach (SalesProcMoneyWork wkSalesProcMoneyWork in salesProcMoneyWorkList)
            {
                SalesProcMoney salesProcMoney = CopyToSalesProcMoneyFromSalesProcMoneyWork(wkSalesProcMoneyWork);

                // HashKey:�[�������Ώۋ��z�敪�A�[�������R�[�h�A������z
                hashKey = CreateHashKey(salesProcMoney);

                _static_SalesProcMoneyTable[hashKey] = salesProcMoney;
            }
        }

        /// <summary>
        /// HashTable�pKey�쐬
        /// </summary>
        /// <param name="salesProcMoney">������z�����敪�ݒ�N���X</param>
        /// <returns>Hash�pKey</returns>
        /// <remarks>
        /// <br>Note       : ������z�����敪�ݒ�N���X����n�b�V���e�[�u���p��
        ///					 �L�[���쐬���܂��B</br>
        /// <br>Programer  : 21024  ���X��  ��</br>
        /// <br>Date       : 2007.08.28</br>
        /// </remarks>
        private string CreateHashKey( SalesProcMoney salesProcMoney )
        {
            return salesProcMoney.FracProcMoneyDiv.ToString("d9") +
                   salesProcMoney.FractionProcCode.ToString("d9") +
                   salesProcMoney.UpperLimitPrice.ToString("000000000.00");
        }

        #endregion
    }
}

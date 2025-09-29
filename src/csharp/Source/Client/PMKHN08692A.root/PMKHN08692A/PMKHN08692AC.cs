using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Windows.Forms;
using Broadleaf.Application.LocalAccess;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// ���_���e�[�u���A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���_���e�[�u���̃A�N�Z�X������s���܂��B</br>
	/// <br>Programmer : 30462 �s�V �m��</br>
	/// <br>Date       : 2008.10.24</br>
	/// <br></br>
    /// </remarks>
	public class SecPrintSetAcs 
	{

		/// <summary>�����[�g�I�u�W�F�N�g�i�[�o�b�t�@</summary>
		private ISecInfoSetDB _iSecInfoSetDB = null;
        private SectionInfoLcDB _sectionInfoLcDB = null;
        private static bool _isLocalDBRead = false;

		/// <summary>���Ж��̊i�[�o�b�t�@</summary>
		private Hashtable _companyNmTable = null;

        /// <summary>���Џ��i�[�o�b�t�@</summary>
        private Hashtable _companyInfTable = null;

        /// <summary>���_�q�ɖ��̊i�[�o�b�t�@</summary>
        private Hashtable _sectWarehouseNmTable = null;

		private SecInfoAcs _secInfoAcs;

        /// <summary> ���[�J���c�a�Q�ƃ��[�h�v���p�e�B</summary>
        public bool IsLocalDBRead
        {
            get { return _isLocalDBRead; }
            set { _isLocalDBRead = value; }
        }

        /// <summary>
		/// ���_���e�[�u���A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���_���e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        public SecPrintSetAcs()
		{

			this._companyNmTable = null;
            this._companyInfTable = null;

			try
			{
				// �����[�g�I�u�W�F�N�g�擾
				this._iSecInfoSetDB = (ISecInfoSetDB)MediationSecInfoSetDB.GetSecInfoSetDB();
			}
			catch (Exception)
			{				
				//�I�t���C������null���Z�b�g
				this._iSecInfoSetDB = null;
			}
            // ���[�J��DB�A�N�Z�X�I�u�W�F�N�g�擾
            this._sectionInfoLcDB = new SectionInfoLcDB();
        }

        /// <summary>
        /// ���[�J���c�a�Ή����_���N���X�쐬����
        /// </summary>
        /// <returns>Boolean</returns>
        /// <remarks>
        /// <br>Note       : ���_���N���X�쐬�𖢍쐬���ɍ쐬���܂��B</br>
        /// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        private Boolean ConstructSecInfoAcs()
        {
            if (this._secInfoAcs == null)
            {
                this._secInfoAcs = new SecInfoAcs(_isLocalDBRead ? 0 : 1);
                if (this._secInfoAcs != null)
                {
                    return true;
                }
            }
            return false;
        }

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
		/// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
		/// </remarks>
		public int GetOnlineMode()
		{
			if (this._iSecInfoSetDB == null)
			{
				return (int)OnlineMode.Offline;
			}
			else
			{
				return (int)OnlineMode.Online;
			}
		}

		/// <summary>
		/// ���_���S���������i�_���폜�����j
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���_���̑S�����������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
		/// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
		/// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode, SectionPrintWork sectionPrintWork)
		{
			bool nextData;
			int  retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, 0, 0,  sectionPrintWork);
		}

		/// <summary>
		/// ���_��񌟍������i�_���폜�܂ށj
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���_���̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
		/// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
		/// </remarks>
		public int SearchAll(out ArrayList retList, string enterpriseCode, SectionPrintWork sectionPrintWork)
		{

			bool nextData;
			int	 retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01, 0,  sectionPrintWork);
		}

		

		/// <summary>
		/// ���_��񌟍�����
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������(prevEmployee��null�̏ꍇ�̂ݖ߂�)</param>
		/// <param name="nextData">���f�[�^�L��</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�S�f�[�^)</param>
		/// <param name="readCnt">�Ǎ�����</param>
        /// <param name="sectionPrintWork">���o����</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���_���̌����������s���܂��B</br>
		/// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, SectionPrintWork sectionPrintWork)
		{
			SecInfoSetWork secInfoSetWork = new SecInfoSetWork();
			secInfoSetWork.EnterpriseCode = enterpriseCode;
			
			//���f�[�^�L��������
			nextData = false;
			//0�ŏ�����
			retTotalCnt = 0;

            int checkstatus = 0;

			SecInfoSetWork[] al;
			retList = new ArrayList();
			retList.Clear();

			// XML�֕ϊ����A������̃o�C�i����
			byte[] parabyte = XmlByteSerializer.Serialize(secInfoSetWork);

			byte[] retbyte;

			// ���_��񌟍�
			int status = 0;
            if (_isLocalDBRead)
            {
                List<SecInfoSetWork> workList = new List<SecInfoSetWork>();
                // ���_��񌟍�
                status = this._sectionInfoLcDB.Search(out workList, secInfoSetWork, 0, logicalMode);
                if (status == 0)
                {
                    //���_���N���X�փ����o�R�s�[
                    for (int i = 0; i < workList.Count; i++)
                    {
                        // ���o����
                        checkstatus = DataCheck(workList[i], sectionPrintWork);
                        if (checkstatus == 0)
                        {
                            //���_���N���X�փ����o�R�s�[
                            retList.Add(CopyToSecInfoSetFromSecInfoSetWork(workList[i]));
                        }
                        
                    }
                }
            }
            else
            {
                if (readCnt == 0)
                {
                	status = this._iSecInfoSetDB.Search(out retbyte,parabyte,0,logicalMode);
                }
                else
                {
                	status = this._iSecInfoSetDB.SearchSpecification(out retbyte,out retTotalCnt,out nextData,parabyte,0,logicalMode,readCnt);
                }
                if (status == 0)
                {
                	// XML�̓ǂݍ���
                	al = (SecInfoSetWork[])XmlByteSerializer.Deserialize(retbyte,typeof(SecInfoSetWork[]));

                	for(int i = 0;i < al.Length;i++)
                	{
                		//�T�[�`���ʎ擾
                		SecInfoSetWork wkSecInfoSetWork = (SecInfoSetWork)al[i];

                        // ���o����
                        checkstatus = DataCheck(wkSecInfoSetWork, sectionPrintWork);
                        if (checkstatus == 0)
                        {
                            //���_���N���X�փ����o�R�s�[
                            retList.Add(CopyToSecInfoSetFromSecInfoSetWork(wkSecInfoSetWork));
                        }
                		
                	}
                }
            }
            //�S�����[�h�̏ꍇ�͖߂�l�̌������Z�b�g
			if (readCnt == 0) retTotalCnt = retList.Count;
				
			return status;
		}

		/// <summary>
        /// ���Ж��̎擾����
		/// </summary>
		/// <param name="companyName1">���Ж��̂P</param>
		/// <param name="companyName2">���Ж��̂Q</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="companyNameCd">���Ж��̃R�[�h</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���Ж��̃R�[�h���玩�Џ����擾���܂�</br>
		/// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
		/// </remarks>
		public int GetCompanyName( out string companyName1, out string companyName2, out string postco,
                                   out string address1, out string address3, out string address4,
                                   out string companyTelNo1, out string companyTelNo2,out string companyTelNo3,
                                   out string companySetNote1, out string companySetNote2,
                                   string enterpriseCode, int companyNameCd )
		{
			int status = 0;
			CompanyNm companyNm = null;
            
			companyName1 = "";
			companyName2 = "";
            postco = "";
            address1 = "";
            address3 = "";
            address4 = "";
            companyTelNo1 = "";
            companyTelNo2 = "";
            companyTelNo3 = "";
            companySetNote1 = "";
            companySetNote2 = "";
			if( companyNameCd > 0 ) {

				// ���Ж��̓ǂݍ���
				status = ReadCompanyNm( out companyNm, enterpriseCode, companyNameCd );
				if( status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) {
					if( companyNm.LogicalDeleteCode == 0 ) {
						companyName1 = companyNm.CompanyName1;
						companyName2 = companyNm.CompanyName2;
                        postco = companyNm.PostNo;
                        address1 = companyNm.Address1;
                        address3 = companyNm.Address3;
                        address4 = companyNm.Address4;
                        companyTelNo1 = companyNm.CompanyTelNo1;
                        companyTelNo2 = companyNm.CompanyTelNo2;
                        companyTelNo3 = companyNm.CompanyTelNo3;
                        companySetNote1 = companyNm.CompanySetNote1;
                        companySetNote2 = companyNm.CompanySetNote2;
					}
					else {
                        companyName1 = "�폜��";
						status = -1;
					}
				}
				else {
                    companyName1 = "���o�^";
				}
			}

			return status;
		}

		/// <summary>
        /// ���Ж��̓Ǎ�����
		/// </summary>
		/// <param name="companyNm">���Ж��̃I�u�W�F�N�g</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="companyNameCd">���Ж��̃R�[�h</param>
		/// <returns>STATUS</returns>
		public int ReadCompanyNm( out CompanyNm companyNm, string enterpriseCode, int companyNameCd )
		{
			int status = 0;
			companyNm = null;

				status = SetCompanyNmTable( enterpriseCode );
				if( status != ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) {
					// �ǂݍ��ݎ��s
					return status;
				}

			// �e�[�u���ɃL�[�����݂��Ă���
			if( this._companyNmTable.ContainsKey( companyNameCd ) == true ) {
				companyNm = ( ( CompanyNm )this._companyNmTable[ companyNameCd ] ).Clone();
			}
			else {
				status = ( int )ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			}

			return status;
		}

		/// <summary>
		/// ���Ж��̌�������
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���Ж��̂̌����������s���A�o�b�t�@�Ɋi�[���܂��B</br>
        /// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
		private int SetCompanyNmTable( string enterpriseCode )
		{
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            if (this._companyNmTable == null)
            {
                this._companyNmTable = new Hashtable();
                CompanyNmAcs companyNmAcs = new CompanyNmAcs();
                companyNmAcs.IsLocalDBRead = _isLocalDBRead;
                ArrayList retList = null;
                this._companyNmTable.Clear();
                status = companyNmAcs.SearchAll(out retList, enterpriseCode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    foreach (CompanyNm companyNm in retList)
                    {
                        if (this._companyNmTable.ContainsKey(companyNm.CompanyNameCd) == false)
                        {
                            this._companyNmTable.Add(companyNm.CompanyNameCd, companyNm.Clone());
                        }
                    }
                }
            }

			return status;
		}

        /// <summary>
        /// ���Џ�񌟍�
        /// </summary>
        /// <param name="companyTelTitle3"></param>
        /// <param name="companyTelTitle3"></param>
        /// <param name="companyTelTitle3"></param>
        /// <param name="enterpriseCode"></param>
        /// <returns></returns>
        public int GetCompanyInf(out string companyTelTitle1, out string companyTelTitle2, out string companyTelTitle3, string enterpriseCode)
        {
            int status = 0;
            CompanyInf companyInf = null;

            companyTelTitle1 = "";
            companyTelTitle2 = "";
            companyTelTitle3 = "";

            // ���Џ��ǂݍ���
            status = ReadCompanyInf(out companyInf, enterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (companyInf.LogicalDeleteCode == 0)
                {
                    companyTelTitle1 = companyInf.CompanyTelTitle1;
                    companyTelTitle2 = companyInf.CompanyTelTitle2;
                    companyTelTitle3 = companyInf.CompanyTelTitle3;
                }
                else
                {
                    status = -1;
                }
            }

            return status;
        }

        /// <summary>
        /// ���Џ��Ǎ�����
        /// </summary>
        /// <param name="companyInf"></param>
        /// <param name="enterpriseCode"></param>
        /// <returns></returns>
        public int ReadCompanyInf(out CompanyInf companyInf, string enterpriseCode)
        {
            int status = 0;
            companyInf = null;

            status = SetCompanyInfTable(enterpriseCode);
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // �ǂݍ��ݎ��s
                return status;
            }

            // �e�[�u���ɃL�[�����݂��Ă���
            if (this._companyInfTable.ContainsKey(0) == true)
            {
                companyInf = ((CompanyInf)this._companyInfTable[0]).Clone();
            }
            else
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }

            return status;
        }

        /// <summary>
        /// ���Џ�񌟍�����
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <returns></returns>
        private int SetCompanyInfTable(string enterpriseCode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            if (this._companyInfTable == null)
            {
                this._companyInfTable = new Hashtable();
                CompanyInfAcs companyInfAcs = new CompanyInfAcs();
                companyInfAcs.IsLocalDBRead = _isLocalDBRead;
                CompanyInf companyInf = null;
                this._companyInfTable.Clear();
                status = companyInfAcs.Read(out companyInf, enterpriseCode);

                this._companyInfTable.Add(0, companyInf.Clone());
            }

            return status;
        }

        /// <summary>
        /// ���_�q�ɖ��̂̎擾����
        /// </summary>
        /// <param name="warehouseName">���_�q�ɖ���</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="warehouseCode">���_�q�ɃR�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���_�q�ɃR�[�h���狒�_�q�ɖ��̂��擾���܂�</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        /// 
        public int GetWarehouseName(out string warehouseName, string enterpriseCode, string sectionCode, string warehouseCode)
        {
            int status = 0;

            warehouseName = "";

            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            Warehouse warehouse = null;

            this._sectWarehouseNmTable = new Hashtable();

            WarehouseAcs warehouseAcs = new WarehouseAcs();
            warehouseAcs.IsLocalDBRead = _isLocalDBRead;

            // ���_�q�ɖ��̂̓Ǎ�
            status = warehouseAcs.Read(out warehouse, enterpriseCode, sectionCode, warehouseCode);

            if (warehouseCode != "")
            {
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (warehouse.LogicalDeleteCode == 0)
                    {
                        warehouseName = warehouse.WarehouseName;
                    }

                    else
                    {
                        warehouseName = "�폜��";
                    }
                }

                else
                {
                    warehouseName = "���o�^";
                }
            }

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // �ǂݍ��ݎ��s
                return status;
            }

            return status;
        }


        /// <summary>
        /// �N���X�����o�[�R�s�[�����i���_��񃏁[�N�N���X�ˋ��_���N���X�j
        /// </summary>
        /// <param name="secInfoSetWork">���_��񃏁[�N�N���X</param>
        /// <returns>���_���N���X</returns>
        /// <remarks>
        /// <br>Note       : ���_��񃏁[�N�N���X���狒�_���N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : 30462 �s�V �m��</br>
        /// <br>Date       : 2008.10.24</br>
        /// </remarks>
        private SecPrintSet CopyToSecInfoSetFromSecInfoSetWork(SecInfoSetWork secInfoSetWork)
        {

            SecPrintSet secPrintSet = new SecPrintSet();

            secPrintSet.SectionCode = secInfoSetWork.SectionCode;
            secPrintSet.CompanyNameCd1 = secInfoSetWork.CompanyNameCd1;

            // ���Ж��̎擾
            for (int ix = 0; ix < 1; ix++)
            {
                string companyName1 = null;
                string companyName2 = null;
                string postco = null;
                string address1 = null;
                string address3 = null;
                string address4 = null;
                string companyTelNo1 = null;
                string companyTelNo2 = null;
                string companyTelNo3 = null;
                string companySetNote1 = null;
                string companySetNote2 = null;
                GetCompanyName(out companyName1, out companyName2, out postco,
                               out address1, out address3, out address4,
                               out companyTelNo1, out companyTelNo2,out companyTelNo3,
                               out companySetNote1, out companySetNote2,
                               secInfoSetWork.EnterpriseCode, secPrintSet.GetCompanyNameCd(ix));
                secPrintSet.CompanyName1 = companyName1;
                secPrintSet.CompanyName2 = companyName2;
                secPrintSet.PostNo = postco;
                secPrintSet.Address1 = address1;
                secPrintSet.Address3 = address3;
                secPrintSet.Address4  = address4;
                secPrintSet.CompanyTelNo1 = companyTelNo1;
                secPrintSet.CompanyTelNo2 = companyTelNo2;
                secPrintSet.CompanyTelNo3 = companyTelNo3;
                secPrintSet.CompanySetNote1 = companySetNote1;
                secPrintSet.CompanySetNote2 = companySetNote2;

            }

            // �d�b���̃^�C�g��
            string companyTelTitle1 = null;
            string companyTelTitle2 = null;
            string companyTelTitle3 = null;
            GetCompanyInf(out companyTelTitle1, out companyTelTitle2, out companyTelTitle3, secInfoSetWork.EnterpriseCode);
            if (companyTelTitle1.Trim().Equals(string.Empty))
            {
                secPrintSet.CompanyTelTitle1 = "�d�b�P";
            }
            else
            {
                secPrintSet.CompanyTelTitle1 = companyTelTitle1;
            }
            if (companyTelTitle2.Trim().Equals(string.Empty))
            {
                secPrintSet.CompanyTelTitle2 = "�d�b�Q";
            }
            else
            {
                secPrintSet.CompanyTelTitle2 = companyTelTitle2;
            }
            if (companyTelTitle3.Trim().Equals(string.Empty))
            {
                secPrintSet.CompanyTelTitle3 = "�e�`�w";
            }
            else
            {
                secPrintSet.CompanyTelTitle3 = companyTelTitle3;
            }

            secPrintSet.SectionGuideNm = secInfoSetWork.SectionGuideNm;
            secPrintSet.SectionGuideSnm = secInfoSetWork.SectionGuideSnm;

            // �X�֔ԍ��E�Z���E�d�b�ԍ�

            secPrintSet.SectWarehouseCd1 = secInfoSetWork.SectWarehouseCd1;
            secPrintSet.SectWarehouseCd2 = secInfoSetWork.SectWarehouseCd2;
            secPrintSet.SectWarehouseCd3 = secInfoSetWork.SectWarehouseCd3;

            //���_�q�ɖ��̎擾
            for (int ix = 0; ix < 3; ix++)
            {
                string warehouse1 = null;
                GetWarehouseName(out warehouse1, secInfoSetWork.EnterpriseCode,
                    secInfoSetWork.SectionCode, secPrintSet.GetSectWarehouseCd(ix));
                secPrintSet.SetSectWarehouseNm(warehouse1, ix);
            }

            


            return secPrintSet;
        }


        /// <summary>
        /// ���o����
        /// </summary>
        /// <param name="secInfoSetWork"></param>
        /// <param name="sectionPrintWork"></param>
        /// <returns></returns>
        private int DataCheck(SecInfoSetWork secInfoSetWork, SectionPrintWork sectionPrintWork)
        {
            int status = 0;

            if (secInfoSetWork.LogicalDeleteCode != sectionPrintWork.LogicalDeleteCode)
            {
                status = -1;
                return status;
            }


            string upDateTime = secInfoSetWork.UpdateDateTime.Year.ToString("0000") +
                                secInfoSetWork.UpdateDateTime.Month.ToString("00") +
                                secInfoSetWork.UpdateDateTime.Day.ToString("00");

            if (sectionPrintWork.LogicalDeleteCode == 1 &&
                sectionPrintWork.DeleteDateTimeSt != 0 &&
                sectionPrintWork.DeleteDateTimeEd != 0)
            {

                if (Int32.Parse(upDateTime) < sectionPrintWork.DeleteDateTimeSt ||
                    Int32.Parse(upDateTime) > sectionPrintWork.DeleteDateTimeEd)
                {
                    status = -1;
                    return status;
                }
            }
            else if (sectionPrintWork.LogicalDeleteCode == 1 &&
                        sectionPrintWork.DeleteDateTimeSt != 0 &&
                        sectionPrintWork.DeleteDateTimeEd == 0)
            {
                if (Int32.Parse(upDateTime) < sectionPrintWork.DeleteDateTimeSt)
                {
                    status = -1;
                    return status;
                }
            }
            else if (sectionPrintWork.LogicalDeleteCode == 1 &&
                       sectionPrintWork.DeleteDateTimeSt == 0 &&
                       sectionPrintWork.DeleteDateTimeEd != 0)
            {
                if (Int32.Parse(upDateTime) > sectionPrintWork.DeleteDateTimeEd)
                {
                    status = -1;
                    return status;
                }
            }


            if (!sectionPrintWork.SectionCodeSt.Trim().Equals(string.Empty) &&
                !sectionPrintWork.SectionCodeEd.Trim().Equals(string.Empty))
            {
                if (Int32.Parse(secInfoSetWork.SectionCode) < Int32.Parse(sectionPrintWork.SectionCodeSt) ||
                   Int32.Parse(secInfoSetWork.SectionCode) > Int32.Parse(sectionPrintWork.SectionCodeEd))
                {
                    status = -1;
                    return status;
                }
            }
            else if (!sectionPrintWork.SectionCodeSt.Trim().Equals(string.Empty))
            {
                if (Int32.Parse(secInfoSetWork.SectionCode) < Int32.Parse(sectionPrintWork.SectionCodeSt))
                {
                    status = -1;
                    return status;
                }
            }
            else if (!sectionPrintWork.SectionCodeEd.Trim().Equals(string.Empty))
            {
                if (Int32.Parse(secInfoSetWork.SectionCode) > Int32.Parse(sectionPrintWork.SectionCodeEd))
                {
                    status = -1;
                    return status;
                }
            }

            return status;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Serialization;


namespace Broadleaf.Application.UIData
{


    /// public class name:   TspServiceDataManager
    /// <summary>
    ///                      TSP�T�[�r�X�f�[�^�}�l�[�W���[
    /// </summary>
    /// <remarks>
    /// <br>note             :   TSP�T�[�r�X�Ŏg�p����e��f�[�^�ƃf�[�^�����񋟂���</br>
    /// <br>Programmer       :   32470 ����</br>
    /// <br>Date             :   2020/12/01</br>
	/// <br>				 :	 1.TSP�C�����C���̎�����M���[�h���Ɏw�����ԍ����w�肵�Ď�M�ł���悤�ɕύX</br>
	/// </remarks>
    /// 
    [XmlInclude(typeof(TspServiceDataManager))]
    public class TspServiceDataManager
    {

        // �A�N�Z�X�`�P�b�g
        /// <summary>
        /// �A�N�Z�X�`�P�b�g
        /// </summary>
        public string AccessTicket = "";

        // ��������

        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        public string EnterpriseCode = "";

		/// <summary>�w�����ԍ�</summary>
		public string InstSlipNoStr = "";
 
        /// public propaty name  :  Status
        /// <summary>�����X�e�[�^�X</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   WEB�T�[�r�X�₢���킹�̏����X�e�[�^�X</br>
        /// <br>Programer        :   ����</br>
        /// </remarks>
        public int Status;

        // �����X�e�[�^�X���b�Z�[�W

        // 
        /// public propaty name  :  TspServiceDataList
        /// <summary>TSP�T�[�r�X�f�[�^���X�g</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   TSP�T�[�r�X�f�[�^�̃��X�g</br>
        /// <br>Programer        :   ����</br>
        /// </remarks>
        public TspServiceData[] TspServiceDataList;


        /// public propaty name  :  ResultTspRequestList
        /// <summary>���s���� TSP�⍇���f�[�^</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����M�f�[�^�X�V�A�폜������ TspServiceDataList ���̊e�I�u�W�F�N�g�ɑ΂��錋�ʃZ�b�g��Ԃ��܂�</br>
        /// </remarks>
        public TspRequest[] ResultTspRequestList;


        /// public propaty name  :  Message
        /// <summary>�������b�Z�[�W</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������b�Z�[�W</br>
        /// <br>Programer        :   ����</br>
        /// </remarks>
        public string Message;


        #region �R���X�g���N�^


        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public TspServiceDataManager()
        {
    
    
        }

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="tspServiceData">TSP�T�[�r�X�f�[�^</param>
        public TspServiceDataManager(TspServiceData tspServiceData)
        {

            this.Status = 0;
            this.TspServiceDataList = new TspServiceData[1];
            this.TspServiceDataList[0] = tspServiceData;

        }

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="tspServiceDataList">TSP�T�[�r�X�f�[�^���X�g</param>
        public TspServiceDataManager(TspServiceData[] tspServiceDataList)
        {
            this.Status = 0;
            this.TspServiceDataList = tspServiceDataList;

        }


        #endregion �R���X�g���N�^

        /// <summary>
        /// TSP�ʐM�ԍ����X�g�擾
        /// </summary>
        /// <remarks>
        /// ���ݕێ����Ă���TSP�T�[�r�X�f�[�^���X�g����TSP�ʐM�ԍ��݂̂𒊏o���ă��X�g�����܂�
        /// </remarks>
        /// <returns>TSP�ʐM�ԍ����X�g</returns>
        public int[] GetTspCommNoList()
        { 
            ArrayList al = new ArrayList();

            foreach (TspServiceData dtl in this.TspServiceDataList)
            {
                al.Add(dtl.TspSdRvData.TspCommNo);
            }

            return (int[])al.ToArray(typeof(int));
        }


        /// <summary>
        /// TSP�⍇���f�[�^ ���X�g�擾
        /// </summary>
        /// <remarks>
        /// ���ݕێ����Ă���TSP�T�[�r�X�f�[�^���X�g����TSP�⍇���f�[�^�̍��ڂ݂̂𒊏o���ă��X�g�����܂�
        /// </remarks>
        /// <returns>TSP�ʐM�ԍ����X�g</returns>
        public TspRequest[] GetTspRequestList()
        {
            
            ArrayList al = new ArrayList();
            TspRequest tspReq = null;

            foreach (TspServiceData dtl in this.TspServiceDataList)
            {
                tspReq = new TspRequest();
                tspReq.EnterpriseCode = dtl.TspSdRvData.EnterpriseCode;
                if(tspReq.EnterpriseCode.Trim().Equals(""))
                {
                    tspReq.EnterpriseCode = EnterpriseCode;
                }

                tspReq.PmEnterpriseCode = dtl.TspSdRvData.PmEnterpriseCode;
                tspReq.TspCommNo = dtl.TspSdRvData.TspCommNo;
                tspReq.CommConditionDivCd = dtl.TspSdRvData.CommConditionDivCd;

                al.Add(tspReq);
            }

            return (TspRequest[])al.ToArray(typeof(TspRequest));
        }


    }

     
    /// public class name:   TspServiceData
    /// <summary>
    ///                      TSP�T�[�r�X�f�[�^
    /// </summary>
    /// <remarks>
    /// <br>note             :   TSP�T�[�r�X�Ŏg�p����e��f�[�^�ƃf�[�^�����񋟂���</br>
    /// <br>Programmer       :   32470 ����</br>
    /// <br>Date             :   2020/12/01</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    /// 
    [XmlInclude(typeof(TspServiceData))]
    public class TspServiceData
    {

        // TSP����M�f�[�^�N���X
        /// public propaty name  :  TspSdRvData
        /// <summary>TSP����M�f�[�^�N���X</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   TSP����M�f�[�^�N���X</br>
        /// </remarks>
        public TspSdRvDt TspSdRvData;

        
        /// public propaty name  :  TspSdRvData
        /// <summary>TSP����M���׃f�[�^�N���X</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   TSP����M���׃f�[�^�N���X</br>
        /// </remarks>
        public TspSdRvDtl[] TspSdRvDtlDataList;


        /// <summary>
        /// �����X�e�[�^�X(���̃f�[�^�ɑ΂��ēo�^�A�X�V�A�폜�����s�����ۂ̏������ʃX�e�[�^�X�������Ă��܂�)
        /// </summary>
        public int ResultStatus = 0;

         
        #region �R���X�g���N�^

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public TspServiceData()
        {

        }

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="tspSdRvData">TSP����M�f�[�^</param>
        /// <param name="tspSdRvDtlList">TSP����M���׃f�[�^</param>
        public TspServiceData(TspSdRvDt tspSdRvData, TspSdRvDtl[] tspSdRvDtlList)
        {
            this.TspSdRvData = tspSdRvData;
            this.TspSdRvDtlDataList = tspSdRvDtlList;
            this.ResultStatus = 0;
        }

        #endregion �R���X�g���N�^

    }



}

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Threading;
using Broadleaf.Application.Partsman.WebService.TSPService;
using System.IO;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using System.Data;


namespace Broadleaf.Application.Controller
{

    /// <summary>
    /// .NS TSP�T�[�r�X�N���C�A���g�v���L�V
    /// </summary>
    /// <remarks>
    /// <br>Note       : WEB�T�[�r�X�N���C�A���g�v���L�V�̃��b�p�[�ł�</br>
    /// <br>Programmer : ����</br>
    /// <br>Date       : 2020/12/01</br>
    /// </remarks>
    public class NSTspService : TspService
    {

        // WEB�T�[�r�X�N���C�A���g�v���L�V��URL���w�肷�邽�߂ɖ{�N���X���`���Ă��܂�
        #region �R���X�g���N�^
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="serviceURL"></param>
        public NSTspService(string serviceURL)
        {
            // URL�w��
            this.Url = serviceURL;
        }
        #endregion

    }

    /// <summary>
    /// TSP�T�[�r�X�N���C�A���g(PM��)
    /// </summary>
    /// <remarks>
    /// <br>Note       : TSP WEB�T�[�r�X�֐ڑ�����N���C�A���g�v���L�V</br>
    /// <br>Programmer : ����</br>
    /// <br>Date       : 2020/12/01</br>
    /// </remarks>
    public class TSPServiceClientForPM
    {
        #region �萔
        private const string XML_FILE_NAME = "PMTSP01102A_UserSetting.xml";
        #endregion

        #region �R���X�g���N�^

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public TSPServiceClientForPM()
        {

            //
            // �����Őڑ����� URL���擾���� _ServiceURL �փZ�b�g���܂�       
            // ����A���炩�̃��[�J���ݒ�t�@�C�����������āA���̃t�@�C������URL���擾�ł���ꍇ��
            // �擾����URL�Őڑ��ł���悤�ɂ���(�ݒ�t�@�C���������ꍇ�̓f�t�H���g�ݒ�Őڑ�)
            //
            _DefaultPath = Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME);
            try
            {
                if (UserSettingController.ExistUserSetting(_DefaultPath))
                {
                    DataSet UiDataSet = new DataSet();
                    UiDataSet.ReadXml(Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, _DefaultPath));
                    _ServiceURL = UiDataSet.Tables["UserSettingInfo"].Rows[0][0].ToString();
                }
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("�T�[�r�X�ڑ��t�@�C������`����Ă��܂����ǂݍ��߂܂���\n"+e.Message+"\n"+e.StackTrace);

                // �둗�M�h�~
                _ServiceURL = string.Empty;
            }

        }

        #endregion


        #region private �����o

        private string _DefaultPath = "TspDefault";

        /// <summary>
        /// WEB�T�[�r�XURL
        /// </summary>
//		private string _ServiceURL = "http://www40.superfrontman.net/TSPROOT/TspService.asmx"; // �e�X�g�T�[�o
        private string _ServiceURL = "https://tsp.nsblcloud.jp/TSPROOT/TspService.asmx";
        #endregion


        //
        //  �ȉ��� public ���\�b�h�� TspServicePM.CS ���ɒ�`���ꂽ�v���L�V�N���X��
        // �e�탁���o����\�b�h�ɃA�N�Z�X���܂��B 
        //

        #region public ���\�b�h

        /// <summary>
        /// TSP�T�[�r�X PM���f�[�^���M
        /// </summary>
        /// <param name="tspServiceDataManager">���M�Ώ� TSP����M�f�[�^�Ǘ��N���X</param>
        /// <returns>���M���� 0:����, -1:���M�G���[, -99:DB�ڑ��G���[</returns>
        public int SendPMTspData(Broadleaf.Application.UIData.TspServiceDataManager tspServiceDataManager)
        {


            TspServiceDataManagerWork tsDM = ConvertToTspServiceDataManager(tspServiceDataManager);

            // �ȉ���2�s������ʃX���b�h�Ŏ��s���܂�(�R�[�h�ʂ͂��Ȃ葝�����܂�.....)
            // Broadleaf.Application.Controller.NSTspService tspService = new Broadleaf.Application.Controller.NSTspService(_ServiceURL);
            // int st = tspService.SendPMTspData(tsDM);
            
            // �����X���b�h���s(�ڑ��^�C���A�E�g���v�邽�߂ɃX���b�h�������s���Ă��܂�)
            #region �X���b�h���s          
            int st = 0;
            AutoResetEvent ev = new AutoResetEvent(false);
			TSPServiceThreadInfo ti = new TSPServiceThreadInfo();

			// �X���b�h�𐶐�
			ti.Handle = ThreadPool.RegisterWaitForSingleObject(
				ev,
				new WaitOrTimerCallback(SendPMTspDataThread),
				ti,
				120000, // 2���Ԃ̃^�C���A�E�g�҂�
				false
				);

            // �X���b�h�֊e��p�����[�^��n��
            ti.parmObj1        = tsDM;   // ���M�Ώ� TSP��M�f�[�^
			ti.Complete        = false;
			ti.TimeOut         = false;

            // �X���b�h���s
			ev.Set();
			while(true) 
			{
				Thread.Sleep(1000);
                // �������������邩�^�C���A�E�g����������܂Ń��[�v
				if((ti.TimeOut) || (ti.Complete))
				{
					ev.Reset();
					break;
				}
            }

            #endregion 

            #region �X���b�h����̖߂�l�̔���
            if (ti.Complete)
			{
                //---- �X���b�h�����̐���I��(WEB�T�[�o�̏����̐����̓p�����[�^�̃X�e�[�^�X�Ŕ��f)

                // �f�[�^�̓]�L����
                tsDM = (TspServiceDataManagerWork)ti.parmObj1;
                Broadleaf.Application.UIData.TspServiceDataManager tspServiceDataManager2;
                tspServiceDataManager2 = ConvertToUITspServiceDataManager(tsDM);

                tspServiceDataManager.ResultTspRequestList = tspServiceDataManager2.ResultTspRequestList;
                tspServiceDataManager.TspServiceDataList = tspServiceDataManager2.TspServiceDataList;

                st = tsDM.Status;
            }
			else if(ti.TimeOut)
            {
                //---- �����^�C���A�E�g
                tsDM = new TspServiceDataManagerWork();
                tsDM.Status = TSPServiceMessageHelperForPM.STATUS_SERVICE_TIMEOUT;
                st = tsDM.Status;
                tspServiceDataManager.Status = st;
                tspServiceDataManager.Message = TSPServiceMessageHelperForPM.GetMessage(st);
            }
			else
			{
                //---- ���̑��G���[
                tsDM = new TspServiceDataManagerWork();
                tsDM.Status = TSPServiceMessageHelperForPM.STATUS_SYSTEM_ERROR;
                st = tsDM.Status;
                tspServiceDataManager.Status = st;
                tspServiceDataManager.Message = TSPServiceMessageHelperForPM.GetMessage(st);
            }
            #endregion

            return st;
        }


        /// <summary>
        /// TSP�T�[�r�X PM���f�[�^��M(2006.10.27���� �g�p����Ă��܂���)
        /// </summary>
        /// <param name="tspServiceDataManager">��M�Ώ� TSP����M�f�[�^�Ǘ��N���X</param>
        /// <returns>��M����(TSP����M�f�[�^�Ǘ��N���X)</returns>
        public Broadleaf.Application.UIData.TspServiceDataManager ReceivePMTspData(Broadleaf.Application.UIData.TspServiceDataManager tspServiceDataManager)
        {

            Broadleaf.Application.Controller.NSTspService tspService = new Broadleaf.Application.Controller.NSTspService(_ServiceURL);

            TspServiceDataManagerWork rTsDM = null;
            Broadleaf.Application.UIData.TspServiceDataManager rUITsDM = null;
            TspServiceDataManagerWork tsDM = ConvertToTspServiceDataManager(tspServiceDataManager);


            rTsDM = tspService.RecivePMTspData(tsDM);

            if (rTsDM != null)
            {
                rUITsDM = ConvertToUITspServiceDataManager(rTsDM);
            }

            if (rUITsDM == null)
            {
                rUITsDM = new Broadleaf.Application.UIData.TspServiceDataManager();
                rUITsDM.Status = -1;
            }


            // �����X�e�[�^�X�ɑ΂��郁�b�Z�[�W���쐬����
            rUITsDM.Message = MakeStatusMessage(rUITsDM);
            return rUITsDM;

        }

        /// <summary>
        /// TSP�T�[�r�X PM������M�f�[�^ �X�e�[�^�X�ύX(�ʐM��ԋ敪)
        /// </summary>
        /// <param name="statusMode">�ύX�X�e�[�^�X(�ʐM��ԋ敪)</param>
        /// <param name="tspRequestList">�ύX�Ώ�TSP����M�f�[�^���w�肷��TSP�⍇���N���X</param>
        /// <returns>�������� 0:����, -1:�G���[</returns>
        public int ChangeStatusPMTspData(Int32 statusMode, Broadleaf.Application.UIData.TspRequest[] tspRequestList)
        {
            Broadleaf.Application.Controller.NSTspService tspService = new Broadleaf.Application.Controller.NSTspService(_ServiceURL);

            int st = tspService.ChangeStatusPMTspData(statusMode, ConvertToTspRequestWork(tspRequestList));

            return st;

        }


        /// <summary>
        /// TSP�T�[�r�X PM�� TSP����M�f�[�^�Ɖ�
        /// </summary>
        /// <param name="tspRequestList">�Ɖ��TSP����M�f�[�^���w�肷��TSP�⍇���N���X(�Ɖ�ʂ������ɃZ�b�g����܂�)</param>
        /// <returns>�Ɖ�� 0:����, -1:�Ɖ�G���[, 4:�Ɖ�f�[�^���� </returns>
        public int InquiryPMTspData(ref Broadleaf.Application.UIData.TspRequest[] tspRequestList)
        {
            Broadleaf.Application.Controller.NSTspService tspService = new Broadleaf.Application.Controller.NSTspService(_ServiceURL);

            TspRequestWork[] parm = ConvertToTspRequestWork(tspRequestList);

            int st = tspService.InquiryPMTspDataEx(ref parm);


            tspRequestList = ConvertToTspRequest(parm);
            return st;
        }


        /// <summary>
        /// TSP�T�[�r�X PM�� TSP����M�f�[�^�폜
        /// </summary>
        /// <param name="tspRequestList">�폜�Ώ�TSP����M�f�[�^���w�肷��TSP�⍇���N���X</param>
        /// <returns>�������� 0:���� -1:�폜�G���[</returns>
        public int DeletePMTspData(Broadleaf.Application.UIData.TspRequest[] tspRequestList)
        {
            Broadleaf.Application.Controller.NSTspService tspService = new Broadleaf.Application.Controller.NSTspService(_ServiceURL);

            TspRequestWork[] tspRequestWorkList = ConvertToTspRequestWork(tspRequestList);

            int st = tspService.DeletePMTspData(ref tspRequestWorkList);

            tspRequestList = ConvertToTspRequest(tspRequestWorkList);

            return st;
        }

        #endregion


        #region private���\�b�h
        /// <summary>
        /// TSP�T�[�r�X PM���f�[�^���M�X���b�h����
        /// </summary>
        /// <param name="state"></param>
        /// <param name="timedOut"></param>
        private void SendPMTspDataThread(object state, bool timedOut)
        {

            TSPServiceThreadInfo ti = (TSPServiceThreadInfo)state;
            TspServiceDataManagerWork tsDM = (TspServiceDataManagerWork)ti.parmObj1;

            if (!timedOut)
            {

                # region TSP�T�[�r�X PM���f�[�^���M
                int st = -1;
                ti.Status = -1;

                Broadleaf.Application.Controller.NSTspService tspService = new Broadleaf.Application.Controller.NSTspService(_ServiceURL);
                st = tspService.SendPMTspData(tsDM);

                # endregion ���T�C�N���p�[�c����

                // �����������I��������t���O�Z�b�g
                ti.Status = st;
                ti.Complete = true;
                ti.parmObj1 = tsDM;

                if (ti.Complete)
                {
                    if (ti.Handle != null)
                    {
                        ti.Handle.Unregister(null);
                    }
                }

            }
            else
            {

                ti.Status = TSPServiceMessageHelperForPM.STATUS_SERVICE_TIMEOUT;   // �^�C���A�E�g
                ti.Complete = false;
                ti.TimeOut = true;
                ti.parmObj1 = tsDM;

                if (ti.Handle != null)
                {
                    ti.Handle.Unregister(null);
                }

            }


        }

        #endregion private���\�b�h

        //
        // �e��f�[�^�R���o�[�^ �ɂ��� 
        //
        // �����TSP WEB�T�[�r�X�����ł́AWEB�T�[�r�X�ƃN���C�A���g�Ԃł���肳���p�����[�^(�N���X)
        // �Ƃ͕ʂɊe��UI���Ŏg�p�����N���X���`���Ďg�p���Ă��܂�(�v���p�e�B���̍\���͂قڈꏏ�ł�)�B
        //
        // ���̂���WEB�T�[�r�X�Ŏg�p���Ă���p�����[�^�ɕύX������ꍇ�́A
        //
        //  (1)WEB�T�[�r�X�̃p�����[�^�̕ύX�A
        //  (2)UI���N���X�̕ύX, 
        //  (3)WEB�T�[�r�X�N���C�A���g�v���L�V�̍Đ���, 
        //  (4) WEB�T�[�r�X�̃p�����[�^ <---> UI���N���X �̃f�[�^�R���o�[�^�C��
        //
        //  �ȏ�̏C�����K�v�ƂȂ�܂��B
        //  �{���ł���΁AUI����(3)�Ŏ����������ꂽ�p�����[�^�N���X���g�p���邱�ƂŁA
        // (2),(4)���Ȃ����Ƃ��\�ł����A����́A1��WEB�T�[�r�X�ɑ΂��āA�قȂ�o�[�W������
        // WEB�T�[�r�X�N���C�A���g�����݂��邱�Ƃ�O��ɍ쐬���Ă��܂��̂ŁA���̂悤��
        // �璷�ȏ������K�v�ƂȂ��Ă��܂��B
        //
        //  ��̓I�ɂ́AWEB�T�[�r�X�ƃN���C�A���g�̃o�[�W�����̍�(�p�����[�^�̑���)��
        // �{�N���X�ƈȉ��̃f�[�^�R���o�[�^�ŋz�����邱�ƂŁAWEB�T�[�r�X�͏�ɍŐV�̂��݂̂̂�
        // �񋟂���A�N���C�A���g��WEB�T�[�r�X�̃o�[�W�������ӎ�����K�v���Ȃ��Ȃ�܂��B 
        // 
        // ���Ђ̕����I�ɂ�WEB�T�[�r�X�̕ύX�Ƌ��ɃN���C�A���g���S�o�[�W������ĂɏC��
        // ����悤�Ȏ��������̂ł����AMS�Ђ̃A�[�L�e�N�g���̗p���Ă����@����L
        // �̂��̂ɋ߂������̂ł��̎�@���̗p���Ă��܂� 
        //

        #region �e��f�[�^�R���o�[�^

        /// <summary>
        /// TspServiceDataManagerWork --> TspServiceDataManager �R���o�[�g
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        private TspServiceDataManagerWork ConvertToTspServiceDataManager(Broadleaf.Application.UIData.TspServiceDataManager source)
        {

            TspSdRvDtWork tspDt;
            TspSdRvDtlWork tspDtl;
            TspServiceDataWork tsd;
            TspServiceDataManagerWork tsDM;
            TspServiceDataWork[] tsdList;

            tspDt = new TspSdRvDtWork();
            tspDtl = new TspSdRvDtlWork();

            TspSdRvDtlWork[] tspDtlLst = new TspSdRvDtlWork[1];
            tspDtlLst[0] = tspDtl;

            tsd = new TspServiceDataWork();
            tsd.TspSdRvData = tspDt;
            tsd.TspSdRvDtlDataList = tspDtlLst;
            tsdList = new TspServiceDataWork[1];
            tsdList[0] = tsd;

            tsDM = new TspServiceDataManagerWork();
            tsDM.TspServiceDataList = tsdList;

            if (source != null)
            {
                tsDM.EnterpriseCode = source.EnterpriseCode;
                tsDM.Message = source.Message;
                tsDM.TspServiceDataList = ConvertToTspServiceData(source.TspServiceDataList);
            }

            return tsDM;
        }

        /// <summary>
        /// TspServiceDataManager -->  TspServiceDataManagerWork�R���o�[�g
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        private Broadleaf.Application.UIData.TspServiceDataManager ConvertToUITspServiceDataManager(TspServiceDataManagerWork source)
        {

            Broadleaf.Application.UIData.TspSdRvDt tspDt;
            Broadleaf.Application.UIData.TspSdRvDtl tspDtl;
            Broadleaf.Application.UIData.TspServiceData tsd;
            Broadleaf.Application.UIData.TspServiceDataManager tsDM = null;
            Broadleaf.Application.UIData.TspServiceData[] tsdList;

            tspDt = new Broadleaf.Application.UIData.TspSdRvDt();
            tspDtl = new Broadleaf.Application.UIData.TspSdRvDtl();

            Broadleaf.Application.UIData.TspSdRvDtl[] tspDtlLst = new Broadleaf.Application.UIData.TspSdRvDtl[1];
            tspDtlLst[0] = tspDtl;

            tsd = new Broadleaf.Application.UIData.TspServiceData();
            tsd.TspSdRvData = tspDt;
            tsd.TspSdRvDtlDataList = tspDtlLst;
            tsdList = new Broadleaf.Application.UIData.TspServiceData[1];
            tsdList[0] = tsd;

            tsDM = new Broadleaf.Application.UIData.TspServiceDataManager();
            tsDM.TspServiceDataList = tsdList;


            if (source != null)
            {
                tsDM.Status = source.Status;
                tsDM.EnterpriseCode = source.EnterpriseCode;
                tsDM.Message = source.Message;

                tsDM.TspServiceDataList = ConvertToUITspServiceData(source.TspServiceDataList);

                // �����X�e�[�^�X�̓]�L
                ArrayList al = new ArrayList();
                Broadleaf.Application.UIData.TspRequest tspRequest = null;

                if (tsDM.TspServiceDataList != null)
                {

                    foreach (Broadleaf.Application.UIData.TspServiceData tspServiceData in tsDM.TspServiceDataList)
                    {
                        if (tspServiceData.TspSdRvData != null)
                        {

                            tspRequest = new Broadleaf.Application.UIData.TspRequest();
                            tspRequest.TspCommCount = tspServiceData.TspSdRvData.TspCommCount;
                            tspRequest.EnterpriseCode = tspServiceData.TspSdRvData.EnterpriseCode;
                            tspRequest.PmEnterpriseCode = tspServiceData.TspSdRvData.PmEnterpriseCode;
                            tspRequest.TspCommNo = tspServiceData.TspSdRvData.TspCommNo;
                            tspRequest.CommConditionDivCd = tspServiceData.TspSdRvData.CommConditionDivCd;
                            al.Add(tspRequest);
                        }

                    }
                }

                tsDM.ResultTspRequestList = (Broadleaf.Application.UIData.TspRequest[])al.ToArray(typeof(Broadleaf.Application.UIData.TspRequest));

            
            }
            else
            {
                ArrayList al = new ArrayList();
                tsDM.ResultTspRequestList = (Broadleaf.Application.UIData.TspRequest[])al.ToArray(typeof(Broadleaf.Application.UIData.TspRequest));
            }


            return tsDM;

        }


        /// <summary>
        /// TspServiceDataWork --> TspServiceData �R���o�[�g
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        private Broadleaf.Application.UIData.TspServiceData ConvertToUITspServiceData(TspServiceDataWork source)
        {

            Broadleaf.Application.UIData.TspSdRvDt tspHead;
            Broadleaf.Application.UIData.TspSdRvDtl tspDtl;
            Broadleaf.Application.UIData.TspServiceData tspSData;

            tspHead = new Broadleaf.Application.UIData.TspSdRvDt();
            TspSdRvDtWork sourceHead = source.TspSdRvData;

            tspHead.CreateDateTime = sourceHead.CreateDateTime; // �쐬����
            tspHead.UpdateDateTime = sourceHead.UpdateDateTime; // �X�V����
            tspHead.EnterpriseCode = sourceHead.EnterpriseCode; // ��ƃR�[�h
            tspHead.FileHeaderGuid = sourceHead.FileHeaderGuid; // GUID
            tspHead.UpdEmployeeCode = sourceHead.UpdEmployeeCode; // �X�V�]�ƈ��R�[�h
            tspHead.UpdAssemblyId1 = sourceHead.UpdAssemblyId1; // �X�V�A�Z���u��ID1
            tspHead.UpdAssemblyId2 = sourceHead.UpdAssemblyId2; // �X�V�A�Z���u��ID2
            tspHead.LogicalDeleteCode = sourceHead.LogicalDeleteCode; // �_���폜�敪
            tspHead.PmEnterpriseCode = sourceHead.PmEnterpriseCode; // PM��ƃR�[�h
            tspHead.TspCommNo = sourceHead.TspCommNo; // TSP�ʐM�ԍ�
            tspHead.TspCommCount = sourceHead.TspCommCount; // TSP�ʐM��
            tspHead.OrderContentsDivCd = sourceHead.OrderContentsDivCd; // �������e�敪
            tspHead.InstSlipNoStr = sourceHead.InstSlipNoStr; // �w�����ԍ��i������j
            tspHead.AcceptAnOrderNo = sourceHead.AcceptAnOrderNo; // �󒍔ԍ�
            tspHead.DataInputSystem = sourceHead.DataInputSystem; // �f�[�^���̓V�X�e��
            tspHead.SlipNo = sourceHead.SlipNo; // �`�[�ԍ�
            tspHead.SlipKind = sourceHead.SlipKind; // �`�[���
            tspHead.CommConditionDivCd = sourceHead.CommConditionDivCd; // �ʐM��ԋ敪
            tspHead.NumberPlate1Code = sourceHead.NumberPlate1Code; // ���^�������ԍ�
            tspHead.NumberPlate1Name = sourceHead.NumberPlate1Name; // ���^�����ǖ���
            tspHead.NumberPlate2 = sourceHead.NumberPlate2; // �ԗ��o�^�ԍ��i��ʁj
            tspHead.NumberPlate3 = sourceHead.NumberPlate3; // �ԗ��o�^�ԍ��i�J�i�j
            tspHead.NumberPlate4 = sourceHead.NumberPlate4; // �ԗ��o�^�ԍ��i�v���[�g�ԍ��j
            tspHead.ModelDesignationNo = sourceHead.ModelDesignationNo; // �^���w��ԍ�
            tspHead.CategoryNo = sourceHead.CategoryNo; // �ޕʔԍ�
            tspHead.MakerCode = sourceHead.MakerCode; // ���[�J�[�R�[�h
            tspHead.ModelCode = sourceHead.ModelCode; // �Ԏ�R�[�h
            tspHead.ModelSubCode = sourceHead.ModelSubCode; // �Ԏ�T�u�R�[�h
            tspHead.ModelName = sourceHead.ModelName; // �Ԏ햼
            tspHead.CarInspectCertModel = sourceHead.CarInspectCertModel; // �Ԍ��،^��
            tspHead.FullModel = sourceHead.FullModel; // �^���i�t���^�j
            tspHead.FrameNo = sourceHead.FrameNo; // �ԑ�ԍ�
            tspHead.FrameModel = sourceHead.FrameModel; // �ԑ�^��
            tspHead.ChassisNo = sourceHead.ChassisNo; // �V���V�[No
            tspHead.CarProperNo = sourceHead.CarProperNo; // �ԗ��ŗL�ԍ�
            tspHead.ProduceTypeOfYearNum = sourceHead.ProduceTypeOfYearNum; // ���Y�N���iNUM�^�C�v�j
            tspHead.SalesOrderDate = sourceHead.SalesOrderDate; // ������
            tspHead.SalesOrderEmployeeCd = sourceHead.SalesOrderEmployeeCd; // �����ҏ]�ƈ��R�[�h
            tspHead.SalesOrderEmployeeNm = sourceHead.SalesOrderEmployeeNm; // �����ҏ]�ƈ�����
            tspHead.SalesOrderComment = sourceHead.SalesOrderComment; // �������R�����g
            tspHead.OrderSideSystemVerCd = sourceHead.OrderSideSystemVerCd; // �������V�X�e���o�[�W�����敪
            tspHead.TspAnswerDataMngNo = sourceHead.TspAnswerDataMngNo; // TSP�񓚃f�[�^�Ǘ��ԍ�
            tspHead.TspSlipType = sourceHead.TspSlipType; // TSP�`�[�^�C�v
            tspHead.AcceptAnOrderDate = sourceHead.AcceptAnOrderDate; // �󒍓�
            tspHead.PmSlipNo = sourceHead.PmSlipNo; // PM�`�[�ԍ�
            tspHead.AcceptAnOrderNm = sourceHead.AcceptAnOrderNm; // �󒍎Җ�
            tspHead.TspTotalSlipPrice = sourceHead.TspTotalSlipPrice; // TSP�`�[���v���z
            tspHead.PmComment = sourceHead.PmComment; // PM�R�����g
            tspHead.PmVersion = sourceHead.PmVersion; // PM�o�[�W����
            tspHead.PmSendDate = sourceHead.PmSendDate; // PM���M��
            tspHead.PmSlipKind = sourceHead.PmSlipKind; // PM�`�[���
            tspHead.PmOriginalSlipNo = sourceHead.PmOriginalSlipNo; // PM�����`�[�ԍ�

            ArrayList al = new ArrayList();

            foreach (TspSdRvDtlWork sourcedtl in source.TspSdRvDtlDataList)
            {

                tspDtl = new Broadleaf.Application.UIData.TspSdRvDtl();

                tspDtl.CreateDateTime = sourcedtl.CreateDateTime; // �쐬����
                tspDtl.UpdateDateTime = sourcedtl.UpdateDateTime; // �X�V����
                tspDtl.EnterpriseCode = sourcedtl.EnterpriseCode; // ��ƃR�[�h
                tspDtl.FileHeaderGuid = sourcedtl.FileHeaderGuid; // GUID
                tspDtl.UpdEmployeeCode = sourcedtl.UpdEmployeeCode; // �X�V�]�ƈ��R�[�h
                tspDtl.UpdAssemblyId1 = sourcedtl.UpdAssemblyId1; // �X�V�A�Z���u��ID1
                tspDtl.UpdAssemblyId2 = sourcedtl.UpdAssemblyId2; // �X�V�A�Z���u��ID2
                tspDtl.LogicalDeleteCode = sourcedtl.LogicalDeleteCode; // �_���폜�敪
                tspDtl.PmEnterpriseCode = sourcedtl.PmEnterpriseCode; // PM��ƃR�[�h
                tspDtl.TspCommNo = sourcedtl.TspCommNo; // TSP�ʐM�ԍ�
                tspDtl.TspCommCount = sourcedtl.TspCommCount; // TSP�ʐM��
                tspDtl.TspCommRowNo = sourcedtl.TspCommRowNo; // TSP�ʐM�s�ԍ�
                tspDtl.DeliveredGoodsDiv = sourcedtl.DeliveredGoodsDiv; // �[�i�敪
                tspDtl.HandleDivCode = sourcedtl.HandleDivCode; // �戵�敪
                tspDtl.PartsShape = sourcedtl.PartsShape; // ���i�`��
                tspDtl.DelivrdGdsConfCd = sourcedtl.DelivrdGdsConfCd; // �[�i�m�F�敪
                tspDtl.DeliGdsCmpltDueDate = sourcedtl.DeliGdsCmpltDueDate; // �[�i�����\���
                tspDtl.TbsPartsCode = sourcedtl.TbsPartsCode; // �����i�R�[�h
                tspDtl.PmPartsNameKana = sourcedtl.PmPartsNameKana; // PM���i���i�J�i�j
                tspDtl.SalesOrderCount = sourcedtl.SalesOrderCount; // ������
                tspDtl.DeliveredGoodsCount = sourcedtl.DeliveredGoodsCount; // �[�i��
                tspDtl.PartsNoWithHyphen = sourcedtl.PartsNoWithHyphen; // �n�C�t���t�i��
                tspDtl.PmPartsMakerCode = sourcedtl.PmPartsMakerCode; // PM���i���[�J�[�R�[�h
                tspDtl.PurePartsMakerCode = sourcedtl.PurePartsMakerCode; // �������i���[�J�[�R�[�h
                tspDtl.PurePrtsNoWithHyphen = sourcedtl.PurePrtsNoWithHyphen; // �����n�C�t���t�i��
                tspDtl.ListPrice = sourcedtl.ListPrice; // �艿
                tspDtl.UnitPrice = sourcedtl.UnitPrice; // �P��
                tspDtl.PmDtlTakeinDivCd = sourcedtl.PmDtlTakeinDivCd; // PM���׎捞�敪


                al.Add(tspDtl);
            }

            Broadleaf.Application.UIData.TspSdRvDtl[] dtlList = (Broadleaf.Application.UIData.TspSdRvDtl[])al.ToArray(typeof(Broadleaf.Application.UIData.TspSdRvDtl));
            tspSData = new Broadleaf.Application.UIData.TspServiceData(tspHead.Clone(), dtlList);
            tspSData.ResultStatus = source.ResultStatus;

            return tspSData;

        }



        /// <summary>
        /// TspServiceData --> TspServiceDataWork �R���o�[�g
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        private TspServiceDataWork ConvertToTspServiceData(Broadleaf.Application.UIData.TspServiceData source)
        {

            TspSdRvDtWork tspHead;
            TspSdRvDtlWork tspDtl;
            TspServiceDataWork tspSData;

            tspHead = new TspSdRvDtWork();
            Broadleaf.Application.UIData.TspSdRvDt sourceHead = source.TspSdRvData;

            tspHead.CreateDateTime = sourceHead.CreateDateTime; // �쐬����
            tspHead.UpdateDateTime = sourceHead.UpdateDateTime; // �X�V����
            tspHead.EnterpriseCode = sourceHead.EnterpriseCode; // ��ƃR�[�h
            tspHead.FileHeaderGuid = sourceHead.FileHeaderGuid; // GUID
            tspHead.UpdEmployeeCode = sourceHead.UpdEmployeeCode; // �X�V�]�ƈ��R�[�h
            tspHead.UpdAssemblyId1 = sourceHead.UpdAssemblyId1; // �X�V�A�Z���u��ID1
            tspHead.UpdAssemblyId2 = sourceHead.UpdAssemblyId2; // �X�V�A�Z���u��ID2
            tspHead.LogicalDeleteCode = sourceHead.LogicalDeleteCode; // �_���폜�敪
            tspHead.PmEnterpriseCode = sourceHead.PmEnterpriseCode; // PM��ƃR�[�h
            tspHead.TspCommNo = sourceHead.TspCommNo; // TSP�ʐM�ԍ�
            tspHead.TspCommCount = sourceHead.TspCommCount; // TSP�ʐM��
            tspHead.OrderContentsDivCd = sourceHead.OrderContentsDivCd; // �������e�敪
            tspHead.InstSlipNoStr = sourceHead.InstSlipNoStr; // �w�����ԍ��i������j
            tspHead.AcceptAnOrderNo = sourceHead.AcceptAnOrderNo; // �󒍔ԍ�
            tspHead.DataInputSystem = sourceHead.DataInputSystem; // �f�[�^���̓V�X�e��
            tspHead.SlipNo = sourceHead.SlipNo; // �`�[�ԍ�
            tspHead.SlipKind = sourceHead.SlipKind; // �`�[���
            tspHead.CommConditionDivCd = sourceHead.CommConditionDivCd; // �ʐM��ԋ敪
            tspHead.NumberPlate1Code = sourceHead.NumberPlate1Code; // ���^�������ԍ�
            tspHead.NumberPlate1Name = sourceHead.NumberPlate1Name; // ���^�����ǖ���
            tspHead.NumberPlate2 = sourceHead.NumberPlate2; // �ԗ��o�^�ԍ��i��ʁj
            tspHead.NumberPlate3 = sourceHead.NumberPlate3; // �ԗ��o�^�ԍ��i�J�i�j
            tspHead.NumberPlate4 = sourceHead.NumberPlate4; // �ԗ��o�^�ԍ��i�v���[�g�ԍ��j
            tspHead.ModelDesignationNo = sourceHead.ModelDesignationNo; // �^���w��ԍ�
            tspHead.CategoryNo = sourceHead.CategoryNo; // �ޕʔԍ�
            tspHead.MakerCode = sourceHead.MakerCode; // ���[�J�[�R�[�h
            tspHead.ModelCode = sourceHead.ModelCode; // �Ԏ�R�[�h
            tspHead.ModelSubCode = sourceHead.ModelSubCode; // �Ԏ�T�u�R�[�h
            tspHead.ModelName = sourceHead.ModelName; // �Ԏ햼
            tspHead.CarInspectCertModel = sourceHead.CarInspectCertModel; // �Ԍ��،^��
            tspHead.FullModel = sourceHead.FullModel; // �^���i�t���^�j
            tspHead.FrameNo = sourceHead.FrameNo; // �ԑ�ԍ�
            tspHead.FrameModel = sourceHead.FrameModel; // �ԑ�^��
            tspHead.ChassisNo = sourceHead.ChassisNo; // �V���V�[No
            tspHead.CarProperNo = sourceHead.CarProperNo; // �ԗ��ŗL�ԍ�
            tspHead.ProduceTypeOfYearNum = sourceHead.ProduceTypeOfYearNum; // ���Y�N���iNUM�^�C�v�j
            tspHead.SalesOrderDate = sourceHead.SalesOrderDate; // ������
            tspHead.SalesOrderEmployeeCd = sourceHead.SalesOrderEmployeeCd; // �����ҏ]�ƈ��R�[�h
            tspHead.SalesOrderEmployeeNm = sourceHead.SalesOrderEmployeeNm; // �����ҏ]�ƈ�����
            tspHead.SalesOrderComment = sourceHead.SalesOrderComment; // �������R�����g
            tspHead.OrderSideSystemVerCd = sourceHead.OrderSideSystemVerCd; // �������V�X�e���o�[�W�����敪
            tspHead.TspAnswerDataMngNo = sourceHead.TspAnswerDataMngNo; // TSP�񓚃f�[�^�Ǘ��ԍ�
            tspHead.TspSlipType = sourceHead.TspSlipType; // TSP�`�[�^�C�v
            tspHead.AcceptAnOrderDate = sourceHead.AcceptAnOrderDate; // �󒍓�
            tspHead.PmSlipNo = sourceHead.PmSlipNo; // PM�`�[�ԍ�
            tspHead.AcceptAnOrderNm = sourceHead.AcceptAnOrderNm; // �󒍎Җ�
            tspHead.TspTotalSlipPrice = sourceHead.TspTotalSlipPrice; // TSP�`�[���v���z
            tspHead.PmComment = sourceHead.PmComment; // PM�R�����g
            tspHead.PmVersion = sourceHead.PmVersion; // PM�o�[�W����
            tspHead.PmSendDate = sourceHead.PmSendDate; // PM���M��
            tspHead.PmSlipKind = sourceHead.PmSlipKind; // PM�`�[���
            tspHead.PmOriginalSlipNo = sourceHead.PmOriginalSlipNo; // PM�����`�[�ԍ�


            ArrayList al = new ArrayList();

            foreach (Broadleaf.Application.UIData.TspSdRvDtl sourcedtl in source.TspSdRvDtlDataList)
            {

                tspDtl = new TspSdRvDtlWork();

                tspDtl.CreateDateTime = sourcedtl.CreateDateTime; // �쐬����
                tspDtl.UpdateDateTime = sourcedtl.UpdateDateTime; // �X�V����
                tspDtl.EnterpriseCode = sourcedtl.EnterpriseCode; // ��ƃR�[�h
                tspDtl.FileHeaderGuid = sourcedtl.FileHeaderGuid; // GUID
                tspDtl.UpdEmployeeCode = sourcedtl.UpdEmployeeCode; // �X�V�]�ƈ��R�[�h
                tspDtl.UpdAssemblyId1 = sourcedtl.UpdAssemblyId1; // �X�V�A�Z���u��ID1
                tspDtl.UpdAssemblyId2 = sourcedtl.UpdAssemblyId2; // �X�V�A�Z���u��ID2
                tspDtl.LogicalDeleteCode = sourcedtl.LogicalDeleteCode; // �_���폜�敪
                tspDtl.PmEnterpriseCode = sourcedtl.PmEnterpriseCode; // PM��ƃR�[�h
                tspDtl.TspCommNo = sourcedtl.TspCommNo; // TSP�ʐM�ԍ�
                tspDtl.TspCommCount = sourcedtl.TspCommCount; // TSP�ʐM��
                tspDtl.TspCommRowNo = sourcedtl.TspCommRowNo; // TSP�ʐM�s�ԍ�
                tspDtl.DeliveredGoodsDiv = sourcedtl.DeliveredGoodsDiv; // �[�i�敪
                tspDtl.HandleDivCode = sourcedtl.HandleDivCode; // �戵�敪
                tspDtl.PartsShape = sourcedtl.PartsShape; // ���i�`��
                tspDtl.DelivrdGdsConfCd = sourcedtl.DelivrdGdsConfCd; // �[�i�m�F�敪
                tspDtl.DeliGdsCmpltDueDate = sourcedtl.DeliGdsCmpltDueDate; // �[�i�����\���
                tspDtl.TbsPartsCode = sourcedtl.TbsPartsCode; // �����i�R�[�h
                tspDtl.PmPartsNameKana = sourcedtl.PmPartsNameKana; // PM���i���i�J�i�j
                tspDtl.SalesOrderCount = sourcedtl.SalesOrderCount; // ������
                tspDtl.DeliveredGoodsCount = sourcedtl.DeliveredGoodsCount; // �[�i��
                tspDtl.PartsNoWithHyphen = sourcedtl.PartsNoWithHyphen; // �n�C�t���t�i��
                tspDtl.PmPartsMakerCode = sourcedtl.PmPartsMakerCode; // PM���i���[�J�[�R�[�h
                tspDtl.PurePartsMakerCode = sourcedtl.PurePartsMakerCode; // �������i���[�J�[�R�[�h
                tspDtl.PurePrtsNoWithHyphen = sourcedtl.PurePrtsNoWithHyphen; // �����n�C�t���t�i��
                tspDtl.ListPrice = sourcedtl.ListPrice; // �艿
                tspDtl.UnitPrice = sourcedtl.UnitPrice; // �P��
                tspDtl.PmDtlTakeinDivCd = sourcedtl.PmDtlTakeinDivCd; // PM���׎捞�敪


                al.Add(tspDtl);
            }

            TspSdRvDtlWork[] dtlList = (TspSdRvDtlWork[])al.ToArray(typeof(TspSdRvDtlWork));
            tspSData = new TspServiceDataWork(); //TspServiceDataWork(tspHead, dtlList);
            tspSData.TspSdRvData = tspHead;
            tspSData.TspSdRvDtlDataList = dtlList;
            tspSData.ResultStatus = source.ResultStatus;

            return tspSData;

        }



        /// <summary>
        /// TspServiceDataWork[] -->  TspServiceData[] �R���o�[�g
        /// </summary>
        /// <param name="source">TSP�T�[�r�X�f�[�^�}�l�[�W��Work���X�g</param>
        /// <returns>TSP�T�[�r�X�f�[�^�}�l�[�W�� ���X�g</returns>
        private Broadleaf.Application.UIData.TspServiceData[] ConvertToUITspServiceData(TspServiceDataWork[] source)
        {

            Broadleaf.Application.UIData.TspServiceData tspSData;
            ArrayList al = new ArrayList();
            foreach (TspServiceDataWork sourceData in source)
            {
                tspSData = ConvertToUITspServiceData(sourceData);
                al.Add(tspSData);
            }

            Broadleaf.Application.UIData.TspServiceData[] tspSDataList = (Broadleaf.Application.UIData.TspServiceData[])al.ToArray(typeof(Broadleaf.Application.UIData.TspServiceData));


            return tspSDataList;

        }


        /// <summary>
        /// TspServiceData[] -->  TspServiceDataWork[] �R���o�[�g
        /// </summary>
        /// <param name="source">TSP�T�[�r�X�f�[�^�}�l�[�W�� ���X�g</param>
        /// <returns>TSP�T�[�r�X�f�[�^�}�l�[�W��Work���X�g</returns>
        private TspServiceDataWork[] ConvertToTspServiceData(Broadleaf.Application.UIData.TspServiceData[] source)
        {

            TspServiceDataWork tspSData;
            ArrayList al = new ArrayList();
            foreach (Broadleaf.Application.UIData.TspServiceData sourceData in source)
            {
                tspSData = ConvertToTspServiceData(sourceData);
                al.Add(tspSData);
            }

            TspServiceDataWork[] tspSDataList = (TspServiceDataWork[])al.ToArray(typeof(TspServiceDataWork));


            return tspSDataList;

        }


        /// <summary>
        /// TSP�⍇���f�[�^Work[] --> TSP�⍇���f�[�^[] �R���o�[�g
        /// </summary>
        /// <param name="source">TSP�⍇���f�[�^Work ���X�g</param>
        /// <returns>TSP�⍇���f�[�^ ���X�g</returns>
        private Broadleaf.Application.UIData.TspRequest[] ConvertToTspRequest(TspRequestWork[] source)
        {

            Broadleaf.Application.UIData.TspRequest tspSData;
            Broadleaf.Application.UIData.TspRequest[] tspSDataList = null;
            ArrayList al = new ArrayList();

            if (source != null)
            {
                foreach (TspRequestWork sourceData in source)
                {
                    tspSData = ConvertToTspRequest(sourceData);
                    al.Add(tspSData);
                }

                tspSDataList = (Broadleaf.Application.UIData.TspRequest[])al.ToArray(typeof(Broadleaf.Application.UIData.TspRequest));
            }

            return tspSDataList;

        }


        /// <summary>
        /// TSP�⍇���f�[�^ --> TSP�⍇���f�[�^Work �R���o�[�g
        /// </summary>
        /// <param name="tspRequest">TSP�⍇���f�[�^Work </param>
        /// <returns>TSP�⍇���f�[�^ </returns>
        private Broadleaf.Application.UIData.TspRequest ConvertToTspRequest(TspRequestWork tspRequest)
        {

            Broadleaf.Application.UIData.TspRequest resObj = new Broadleaf.Application.UIData.TspRequest();

            if (tspRequest != null)
            {
                resObj.CommConditionDivCd = tspRequest.CommConditionDivCd;
                resObj.EnterpriseCode = tspRequest.EnterpriseCode;
                resObj.PmEnterpriseCode = tspRequest.PmEnterpriseCode;
                resObj.TspCommNo = tspRequest.TspCommNo;
                resObj.TspCommCount = tspRequest.TspCommCount;
            }

            return resObj;
        }



        /// <summary>
        /// TSP�⍇���f�[�^[] --> TSP�⍇���f�[�^Work[] �R���o�[�g
        /// </summary>
        /// <param name="source">TSP�⍇���f�[�^ ���X�g</param>
        /// <returns>TSP�⍇���f�[�^Work ���X�g</returns>
        private TspRequestWork[] ConvertToTspRequestWork(Broadleaf.Application.UIData.TspRequest[] source)
        {

            TspRequestWork tspSData;
            ArrayList al = new ArrayList();
            foreach (Broadleaf.Application.UIData.TspRequest sourceData in source)
            {
                tspSData = ConvertToTspRequestWork(sourceData);
                al.Add(tspSData);
            }

            TspRequestWork[] tspSDataList = (TspRequestWork[])al.ToArray(typeof(TspRequestWork));


            return tspSDataList;

        }


        /// <summary>
        /// TSP�⍇���f�[�^ --> TSP�⍇���f�[�^Work �R���o�[�g
        /// </summary>
        /// <param name="tspRequest">TSP�⍇���f�[�^</param>
        /// <returns>TSP�⍇���f�[�^Work</returns>
        private TspRequestWork ConvertToTspRequestWork(Broadleaf.Application.UIData.TspRequest tspRequest)
        {

            TspRequestWork resObj = new TspRequestWork();

            if (tspRequest != null)
            {
                resObj.CommConditionDivCd = tspRequest.CommConditionDivCd;
                resObj.EnterpriseCode = tspRequest.EnterpriseCode;
                resObj.PmEnterpriseCode = tspRequest.PmEnterpriseCode;
                resObj.TspCommNo = tspRequest.TspCommNo;
                resObj.TspCommCount = tspRequest.TspCommCount;
            }

            return resObj;
        }



        /// <summary>
        /// �X�e�[�^�X���b�Z�[�W����(���̃��\�b�h�͋������ׂ̈ɍ쐬���ꂽ���̂ł�)
        /// �G���[���b�Z�[�W���擾����ۂ́ATSPServiceMessageHelperForPM �N���X��
        /// �e���`�A���\�b�h���g�p���Ă�������
        /// </summary>
        /// <param name="tspServiceDataManager"></param>
        /// <returns>�X�e�[�^�X���b�Z�[�W</returns>
        private string MakeStatusMessage(Broadleaf.Application.UIData.TspServiceDataManager tspServiceDataManager)
        {
            string messsageStr = "";

            int status = tspServiceDataManager.Status;
            switch (status)
            {
                case 0:
                    messsageStr = "TSP����M�����͐���ɍs���܂���";
                    break;
                case 4:
                    messsageStr = "�����ɊY������f�[�^������܂���";
                    break;
                case 9:
                    messsageStr = "TSP����M�f�[�^�̈ꕔ�͏����ł��܂���ł���";
                    break;
                case -9:
                    messsageStr = "TSP����M�f�[�^�͎擾�ł��܂���ł��� - �����������s���ł�";
                    break;
                case -15:
                    messsageStr = "TSP�T�[�r�X�֐ڑ��ł��܂��� - ���O�C����񂪗L���ł͂���܂���";
                    break;
                case -99:
                    messsageStr = "TSP�T�[�r�XDB�֐ڑ��ł��܂���";
                    break;
                case -1:
                    messsageStr = "TSP�T�[�r�X�ڑ����ɗ\�����Ȃ��G���[���������܂���";
                    break;
                case 103:
                    messsageStr = "TSP�T�[�r�X����ڑ��e�X�g�f�[�^������M����܂���" + "\n" + tspServiceDataManager.Message;
                    break;

                default:
                    break;
            }


            return messsageStr;
        }



        #endregion �e��f�[�^�R���o�[�^


        #region inner�N���X
        /// <summary>
        /// �X���b�h�����p��ԑJ�ڃp�����[�^�N���X
        /// </summary>
        private class TSPServiceThreadInfo
        {
            // �e��X���b�h�̏�ԂƁA�����p�����[�^���`
            //
            // �ėp�p�����[�^�̂悤�� object�^�� ����ȃf�[�^�ɑ΂��Ďg�p�����
            // �p�t�H�[�}���X��������̂ŁA���̏ꍇ�͌^��`�����v���p�e�B��ʓr
            // �������Ďg�p���Ă�������(����͂��܂�傫�ȃf�[�^�͈���Ȃ��̂ł��̂܂܎g�p)

            /// <summary>
            /// 
            /// </summary>
            public RegisteredWaitHandle Handle = null;
            /// <summary>
            /// 
            /// </summary>
            public bool TimeOut = false;
            /// <summary>
            /// 
            /// </summary>
            public bool Complete = false;
            /// <summary>
            /// 
            /// </summary>
            public object parmObj1 = null;   // �ėp�p�����[�^
            /// <summary>
            /// 
            /// </summary>
            public object parmObj2 = null;   // �ėp�p�����[�^
            /// <summary>
            /// 
            /// </summary>
            public object parmObj3 = null;   // �ėp�p�����[�^
            /// <summary>
            /// 
            /// </summary>
            public int Status = 0;

        }

        #endregion
    }



    /// <summary>
    /// TSP�T�[�r�X ���b�Z�[�W�w���p�[(PM)
    /// </summary>
    /// <remarks>
    /// <br>Note       : TSP�T�[�r�X�̊e��X�e�[�^�X�ƃ��b�Z�[�W��񋟂��܂�</br>
    /// <br>Programmer : ����</br>
    /// <br>Date       : 2020/12/01</br>
    /// </remarks>
    public static class TSPServiceMessageHelperForPM
    {
        static TSPServiceMessageHelperForPM()
        { 
            // �ÓI�N���X�Ȃ̂ŃC���X�^���X���͋����܂���
        }

        /// <summary>
        /// �X�e�[�^�X 0:��������
        /// </summary>
        static public int STATUS_SUCCESS = ctSTATUS_SUCCESS;        // ��������

        /// <summary>
        /// �X�e�[�^�X 4:�����ɊY������f�[�^������
        /// </summary>
        static public int STATUS_DATA_NOT_FOUND = ctSTATUS_DATA_NOT_FOUND;        // �f�[�^��������Ȃ�

        /// <summary>
        /// �X�e�[�^�X 9:�ꕔ�̃f�[�^�ɏ����G���[���������Ă���
        /// </summary>
        static public int STATUS_DATA_ERROR_SUBSET = ctSTATUS_DATA_ERROR_SUBSET;        // �f�[�^�ꕔ�G���[

        /// <summary>
        /// �X�e�[�^�X -9:�����������s��
        /// </summary>
        static public int STATUS_SEARCH_PARAM_UNENABLE = ctSTATUS_SEARCH_PARAM_UNENABLE;       // �����������s��

        /// <summary>
        /// �X�e�[�^�X -99:DB�ڑ��G���[
        /// </summary>
        static public int STATUS_DB_ERROR = ctSTATUS_DB_ERROR;      // DB�ڑ��G���[

        /// <summary>
        /// �X�e�[�^�X -1:�V�X�e���G���[(�\�����Ȃ��G���[)
        /// </summary>
        static public int STATUS_SYSTEM_ERROR = ctSTATUS_SYSTEM_ERROR;       // �V�X�e���G���[

        /// <summary>
        /// �X�e�[�^�X -1:WEB�T�[�r�X�ڑ��^�C���A�E�g(�\�����Ȃ��G���[)
        /// </summary>
        static public int STATUS_SERVICE_TIMEOUT = ctSTATUS_SERVICE_TIMEOUT;       // �^�C���A�E�g

        /// <summary>
        /// �X�e�[�^�X 0:��������
        /// </summary>
        private const int ctSTATUS_SUCCESS = 0;        // ��������

        /// <summary>
        /// �X�e�[�^�X 4:�����ɊY������f�[�^������
        /// </summary>
        private const int ctSTATUS_DATA_NOT_FOUND = 4;        // �f�[�^��������Ȃ�

        /// <summary>
        /// �X�e�[�^�X 9:�ꕔ�̃f�[�^�ɏ����G���[���������Ă���
        /// </summary>
        private const int ctSTATUS_DATA_ERROR_SUBSET = 9;        // �f�[�^�ꕔ�G���[

        /// <summary>
        /// �X�e�[�^�X -9:�����������s��
        /// </summary>
        private const int ctSTATUS_SEARCH_PARAM_UNENABLE = -9;       // �����������s��

        /// <summary>
        /// �X�e�[�^�X -99:DB�ڑ��G���[
        /// </summary>
        private const int ctSTATUS_DB_ERROR = -99;      // DB�ڑ��G���[

        /// <summary>
        /// �X�e�[�^�X -1:�V�X�e���G���[(�\�����Ȃ��G���[)
        /// </summary>
        private const int ctSTATUS_SYSTEM_ERROR = -1;       // �V�X�e���G���[

        /// <summary>
        /// �X�e�[�^�X -104:WEB�T�[�r�X�ڑ��^�C���A�E�g(�\�����Ȃ��G���[)
        /// </summary>
        private const int ctSTATUS_SERVICE_TIMEOUT = -104;       // �^�C���A�E�g


        /// <summary>
        /// �X�e�[�^�X���b�Z�[�W�擾
        /// </summary>
        /// <param name="status">�X�e�[�^�X</param>
        /// <returns>���b�Z�[�W������</returns>
        static public string GetMessage(int status)
        {
            string messsageStr = "";

            switch (status)
            {
                case TSPServiceMessageHelperForPM.ctSTATUS_SUCCESS:
                    messsageStr = "TSP����M�����͐���ɍs���܂���";
                    break;
                case TSPServiceMessageHelperForPM.ctSTATUS_DATA_NOT_FOUND:
                    messsageStr = "�����ɊY������f�[�^������܂���";
                    break;
                case TSPServiceMessageHelperForPM.ctSTATUS_DATA_ERROR_SUBSET:
                    messsageStr = "TSP����M�f�[�^�̈ꕔ�͏����ł��܂���ł���";
                    break;
                case TSPServiceMessageHelperForPM.ctSTATUS_SEARCH_PARAM_UNENABLE:
                    messsageStr = "TSP����M�f�[�^�͎擾�ł��܂���ł��� - �����������s���ł�";
                    break;
                case -15:
                    messsageStr = "TSP�T�[�r�X�֐ڑ��ł��܂��� - ���O�C����񂪗L���ł͂���܂���";
                    break;
                case TSPServiceMessageHelperForPM.ctSTATUS_DB_ERROR:
                    messsageStr = "TSP�T�[�r�XDB�֐ڑ��ł��܂���";
                    break;
                case TSPServiceMessageHelperForPM.ctSTATUS_SYSTEM_ERROR:
                    messsageStr = "TSP�T�[�r�X�ڑ����ɗ\�����Ȃ��G���[���������܂���";
                    break;
                case TSPServiceMessageHelperForPM.ctSTATUS_SERVICE_TIMEOUT:
                    messsageStr = "TSP�T�[�r�X�֐ڑ��ł��܂���ł���(�ڑ��^�C���A�E�g)";
                    break;
                case 103:
                    messsageStr = "TSP�T�[�r�X����ڑ��e�X�g�f�[�^������M����܂���";
                    break;

                default:
                    if (status > 0)
                    {
                        messsageStr = "TSP�T�[�r�X�ŗ\�����Ȃ��G���[���������܂���";
                    }
                    break;
            }

            return messsageStr;
        
        }
    
    }

    public static class TspXMLDecryptTableResource
    {
        /// <summary>
        /// �������x�N�^
        /// </summary>
        public static readonly byte[] InitVector = Encoding.Default.GetBytes("BRLFTSPN");
        /// <summary>
        /// �������E���h�L�[�e�[�u��
        /// </summary>
        public static readonly byte[] Key = Encoding.Default.GetBytes("y��5nuv�Sqs2v�sQ");
    }

}

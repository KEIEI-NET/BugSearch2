using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �ʔԃR�[�h (�ԍ��^�C�v�Ǘ��}�X�^�̔ԍ��R�[�h�ɑΉ�)
    /// </summary>
    public enum SerialNumberCode
    {
        /// <summary>0:���ݒ�</summary>
        Empty = 0,
        /// <summary>3:�����`�[�ԍ�</summary>
        DepositSlipNo = 3,
        /// <summary>4:�̎����ԍ�</summary>
        ReceiptNo = 4,
        /// <summary>5:�󒍔ԍ�</summary>
        AcceptAnOrderNo = 5,
        /// <summary>7:�󒍊Ǘ��ԍ�</summary>
        AcptAnOdrMngNo = 7,
        /// <summary>52:�x���`�[�ԍ�</summary>
        PaymentSlipNo = 52,
        /// <summary>500:�d���`�[�ԍ�</summary>
        SupplierSlipNo = 500,
        /// <summary>510:���ד`�[�ԍ�</summary>
        ArrGdsSlipNo = 510,
        /// <summary>520:�����`�[�ԍ�</summary>
        SalesOrderSlipNo = 520,
        /// <summary>530:���ϓ`�[�ԍ�</summary>
        EstimateSlipNo = 530,
        /// <summary>540:�󒍓`�[�ԍ�</summary>
        AcptAnOdrSlipNo = 540,
        /// <summary>1000:���ϔԍ�</summary>
        EstimateNo = 1000,
        /// <summary>1200:����`�[�ԍ�</summary>
        SalesSlipNum = 1200,
        /// <summary>1300:�o�ד`�[�ԍ�</summary>
        ShipmentSlipNo = 1300,
        //// 1700:�ړ��o�ד`�[�ԍ�
        //MoveShipmentSlipNo = 1700,  //DEL 2008/07/07 M.Kubota
        /// <summary>1700:�݌Ɉړ��`�[�ԍ�</summary>
        StockMoveSlipNo = 1700,       //ADD 2008/07/07 M.Kubota
        /// <summary>1720:�݌ɒ����`�[�ԍ�</summary>
        StockAdjustSlipNo = 1720,
        //// <summary>1730:�ړ����ד`�[�ԍ�</summary>
        //MoveArrGdsSlipNo = 1730,  //DEL 2008/07/07 M.Kubota
        /// <summary>3000:���ʒʔ�</summary>
        CommonNo = 3000,
        /// <summary>3010:���㖾�גʔ�(����,��,�o��,����)</summary>
        SailsDtlNo = 3010,
        /// <summary>3020:�d�����גʔ�(�d��,����,����)</summary>
        StockDtlNo = 3020,
        /// <summary>3030:�������גʔ�</summary>
        DepositDtlNo = 3030,
        /// <summary>3040:�x�����גʔ�</summary>
        PaymentDtlNo = 3040,
        //// <summary>3100:�������Z�`�[�ԍ�</summary>
        //Dmd = 3100,
        /// <summary>3200:���q�Ǘ��ԍ�(SEQ)</summary>
        CarMngNo = 3200,
        /// <summary>3300:UOE�����ԍ�</summary>
        UOESalesOrderNo = 3300,
        /// <summary>3310:UOE�I�����C���ԍ�</summary>
        UOEOnlineNo = 3310,
        /// <summary>3500:����M�������O���M�ԍ�</summary>
        SndRcvHisConsNo = 3500
    }

    /// <summary>
    /// �̔ԊǗ����s���N���X�ł��B
    /// </summary>
    /// <remarks>
    /// <br>Note       : �ԍ��Ǘ��ݒ�}�X�^�̒l�����Ɋe��A�Ԃ��擾����N���X�ł��B</br>
    /// <br>Programmer : 21112�@�v�ۓc�@��</br>
    /// <br>Date       : 2008.05.27</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class NumberingManager : RemoteDB
    {
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 21112�@�v�ۓc�@��</br>
        /// <br>Date       : 2007.09.12</br>
        /// </remarks>
        public NumberingManager()
        {
        }

        /// <summary>
        /// ���g���C�񐔂��擾���܂��B
        /// </summary>
        private int RetryCount
        {
            get { return 50; }
        }

        /// <summary>
        /// ���g���C���̃C���^�[�o�����~���b�Ŏ擾���܂��B
        /// </summary>
        private int RetryInterval
        {
           get { return 500; }
        }

        /// <summary>
        /// �ʔԂ��̔Ԃ��܂��B
        /// </summary>
        /// <param name="enterprisecode">��ƃR�[�h���w�肵�܂��B</param>
        /// <param name="sectioncode">���_�R�[�h���w�肵�܂��B</param>
        /// <param name="serialnumcd">�ʔԃR�[�h���w�肵�܂��B</param>
        /// <param name="serialnumber">�ԍ��R�[�h�Ɋ�č̔Ԃ��ꂽ�ʔԂ�Ԃ��܂��B</param>
        /// <returns>STATUS</returns>
        public int GetSerialNumber(string enterprisecode, string sectioncode, SerialNumberCode serialnumcd, out Int64 serialnumber)
        {
            // �߂�l�̏�����
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            serialnumber = 0;

            // �ԍ��̔ԕ��i�̏���
            NumberNumbering numMng = new NumberNumbering();

            int noCode = (int)serialnumcd;
            string[] strParam = new string[0];
            string no = "";
            int noItemPatternCd = 0;
            string retMsg = "";

            int retrycount = this.RetryCount;
            do
            {
                // �߂�l�̏�����
                no = "";
                noItemPatternCd = 0;
                retMsg = "";

                // �ʔԂ��̔�
                status = numMng.Numbering(enterprisecode, sectioncode, noCode, strParam, out no, out noItemPatternCd, out retMsg);

                if (status == (int)ConstantManagement.DB_Status.ctDB_CONCT_TIMEOUT)
                {
                    retrycount -= 1;
                    base.WriteErrorLog(string.Format("GetSerialNumber: Retry = {0} Time = {1} NoCode = {2} RetMsg = {3}", (this.RetryCount - retrycount), DateTime.Now.TimeOfDay.ToString(), noCode, retMsg));
                    System.Threading.Thread.Sleep(this.RetryInterval);
                }
                else
                {
                    retrycount = 0;
                }
            }
            while (retrycount > 0);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                serialnumber = Convert.ToInt64(no);
            }
            else
            {
                base.WriteErrorLog("NumberingManager.GetSerialNumber�ɂăG���[ Msg = " + retMsg, status);
            }

            return status;
        }
    }
}

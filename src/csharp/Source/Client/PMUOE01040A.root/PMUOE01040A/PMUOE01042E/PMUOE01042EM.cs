//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �t�n�d�`�[����N���X
// �v���O�����T�v   : �t�n�d�`�[����̒�`���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10402071-00 �쐬�S�� : ���� �T��
// �� �� ��  2008/05/26  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.IO;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// (����p)UOE���㖾�׃N���X
    /// </summary>
    public class PrtSalesDetail
    {
        // �R���X�g���N�^
        public PrtSalesDetail()
        {
            Clear();
        }
        //������
        public void Clear()
        {
            prtReceiveTime = 0;
            prtBoCode = "";
            prtUOEDeliGoodsDiv = "";
            prtDeliveredGoodsDivNm = "";
            prtFollowDeliGoodsDiv = "";
            prtFollowDeliGoodsDivNm = "";

            prtAcceptAnOrderCnt = 0;
            prtShipmentCnt = 0;
            prtUOESectOutGoodsCnt = 0;
            prtBOShipmentCnt = 0;
            detailCd = (int)ctDetailCd.ct_Normal;
        }

        /// <summary>(����p)��M����</summary>
        public Int32 prtReceiveTime = 0;

        /// <summary>(����p)BO�敪</summary>
        public string prtBoCode = "";

        /// <summary>(����p)UOE�[�i�敪</summary>
        public string prtUOEDeliGoodsDiv = "";

        /// <summary>(����p)�[�i�敪����</summary>
        public string prtDeliveredGoodsDivNm = "";

        /// <summary>(����p)�t�H���[�[�i�敪</summary>
        public string prtFollowDeliGoodsDiv = "";

        /// <summary>(����p)�t�H���[�[�i�敪����</summary>
        public string prtFollowDeliGoodsDivNm = "";

        /// <summary>(����p)�󒍐�</summary>
        public double prtAcceptAnOrderCnt = 0;

        /// <summary>(����p)�o�ɐ�</summary>
        public Int32 prtShipmentCnt = 0;

        /// <summary>(����p)���_�o�ɐ�</summary>
        public Int32 prtUOESectOutGoodsCnt = 0;

        /// <summary>(����p)BO�o�ɐ�</summary>
        public Int32 prtBOShipmentCnt = 0;


        /// <summary>���׎��</summary>
        /// 0:�ʏ햾��
        /// 9:�[������
        public Int32 detailCd = (int)ctDetailCd.ct_Normal;

        //UOE�`�[���
        public enum ctDetailCd : int
        {
            ct_Normal = 0, //�ʏ햾��
            ct_Zero = 9,   //�[������
        }
    }

    /// <summary>
    /// UOE���㖾�׃N���X
    /// </summary>
    public class UoeSalesDetail
    {
        // �R���X�g���N�^
        public UoeSalesDetail()
        {
            Clear();
        }

        //������
        public void Clear()
        {
            salesDetailWork = new SalesDetailWork();
            prtSalesDetail = new PrtSalesDetail();
        }

		/// <summary>���㖾��</summary>
        public SalesDetailWork salesDetailWork = null;

        /// <summary>(����p)���㖾��</summary>
        public PrtSalesDetail prtSalesDetail = null; 
    }

    /// <summary>
    /// UOE����`�[�N���X
    /// </summary>
    public class UoeSales
    {
        // �R���X�g���N�^
        public UoeSales()
        {
            Clear();
        }
        //������
        public void Clear()
        {
            salesSlipWork = new SalesSlipWork();
            totalCnt = 0;
            slipCd = (int)ctSlipCd.ct_Section;

            if (uoeSalesDetailList == null)
            {
                uoeSalesDetailList = new List<UoeSalesDetail>();
            }
            else
            {
                uoeSalesDetailList.Clear();
            }
        }

		/// <summary>����f�[�^</summary>
        public SalesSlipWork salesSlipWork = null;
		
        /// <summary>UOE���㖾��</summary>
        public List<UoeSalesDetail> uoeSalesDetailList = null;

        //�o�ɐ����v
        public int totalCnt = 0;

		/// <summary>UOE�`�[��ʁi���Z���j</summary>
        // �`�[��ʁi���Z�j        0:�m�F�`�[ 1:�t�H���[�`�[ 9:�[���`�[
        // �`�[��ʁi�ʁX�F���ʁj  0:�m�F�`�[ 1:BO1�`�[ 2:BO2�`�[ 3:BO3�`�[ 4:EO�`�[ 5:���[�J�[�t�H���[�`�[ 9:�[���`�[
        // �`�[��ʁi�ʁX�F�z���_�j0:�m�F�`�[ 1:BO1�`�[ 8:��BO�`�[ 9:�[���`�[
        public Int32 slipCd = (int)ctSlipCd.ct_Section;

        //UOE�`�[���
        public enum ctSlipCd : int
        {
            ct_Section = 0, //�m�F�`�[
            ct_BO1 = 1,     //BO1�`�[
            ct_BO2 = 2,     //BO2�`�[
            ct_BO3 = 3,     //BO3�`�[
            ct_EO = 4,      //EO�`�[
            ct_Maker = 5,   //���[�J�[�t�H���[�`�[
            ct_OtherBO = 8, //��BO�`�[
            ct_Zero = 9,    //�[���`�[
        }

        //UOE�`�[���(������)
        public const string ct_strSection = "_0"; //�m�F�`�[
        public const string ct_strBO1 = "_1";     //BO1�`�[
        public const string ct_strBO2 = "_2";     //BO2�`�[
        public const string ct_strBO3 = "_3";     //BO3�`�[
        public const string ct_strEO = "_4";      //EO�`�[
        public const string ct_strMaker = "_5";   //���[�J�[�t�H���[�`�[
        public const string ct_strOtherBO = "_8"; //��BO�`�[
        public const string ct_strZero = "_9";    //�[���`�[
    }
}

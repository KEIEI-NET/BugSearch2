//****************************************************************************//
// �V�X�e��         : �����񓚏���
// �v���O��������   : �����񓚏����A�N�Z�X
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2009/06/15  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2010/04/05  �C�����e : �ȑO�Ɍ��ϓ`�[�f�[�^���쐬���Ă��锭���̏ꍇ�A�쐬����񓚃f�[�^����є���`�[�f�[�^�͌��ϓ`�[�f�[�^�����ɍ쐬����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : 20056 ���n ���
// �� �� ��  2012/04/11  �C�����e : �������Ή�
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.Controller.Other;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData.Util;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Controller.Agent
{
    // ADD 2010/04/05 �ȑO�Ɍ��ϓ`�[�f�[�^���쐬���Ă��锭���̏ꍇ�A�쐬����񓚃f�[�^����є���`�[�f�[�^�͌��ϓ`�[�f�[�^�����ɍ쐬���� ---------->>>>>
    using SalesDetailTuple = Tuple<
        List<SalesDetailWork>,  // ���㖾�׃f�[�^
        List<AcceptOdrCarWork>, // 
        List<StockSlipWork>,    // �d���f�[�^
        List<StockDetailWork>,  // �d�����׃f�[�^
        List<UOEOrderDtlWork>,  // UOE�󒍃f�[�^
        NullObject,
        NullObject,
        NullObject,
        NullObject,
        NullObject
    >;
    // ADD 2010/04/05 �ȑO�Ɍ��ϓ`�[�f�[�^���쐬���Ă��锭���̏ꍇ�A�쐬����񓚃f�[�^����є���`�[�f�[�^�͌��ϓ`�[�f�[�^�����ɍ쐬���� ----------<<<<<

    /// <summary>
    /// ����`�[���͂�I/O�A�N�Z�X�̑㗝�l�N���X
    /// </summary>
    public static class SalesSlipIOAgent
    {
        /// <summary>
        /// �����݂܂��B
        /// </summary>
        /// <param name="salesData">����f�[�^</param>
        /// <param name="writeFlg">DB�X�V�t���O</param>
        /// <returns>Key:���ʃR�[�h/Value:���`�����[�g�̏����݌���</returns>
        //>>>2012/04/11
        //public static KeyValuePair<int, object> Write(CustomSerializeArrayList salesData)
        public static KeyValuePair<int, object> Write(CustomSerializeArrayList salesData, bool writeFlg)
        //<<<2012/04/11
        {
            #region <Guard Phrase>

            if (salesData == null || salesData.Count <= 1)
            {
                return new KeyValuePair<int, object>((int)ResultUtil.ResultCode.Normal, null);
            }

            #endregion // </Guard Phrase>

            // 1�p����
            object paraList = (object)salesData;

            // 2�p����
            string msg = string.Empty;

            // 3�p����
            string itemInfo = string.Empty;

            IIOWriteControlDB writer = MediationIOWriteControlDB.GetIOWriteControlDB();

            //>>>2012/04/11
            //int status = writer.Write(
            //    ref paraList,
            //    out msg,
            //    out itemInfo
            //);
            int status = 0;

            if (writeFlg)
            {
                status = writer.Write(
                    ref paraList,
                    out msg,
                    out itemInfo
                );
            }
            //<<<2012/04/11

            if ( !status.Equals( (int)ResultUtil.ResultCode.Normal ) )
            {
                Debug.WriteLine(msg + "[" + itemInfo + "]");
            }

            return new KeyValuePair<int, object>(status, paraList);
        }
    }

    // ADD 2010/04/05 �ȑO�Ɍ��ϓ`�[�f�[�^���쐬���Ă��锭���̏ꍇ�A�쐬����񓚃f�[�^����є���`�[�f�[�^�͌��ϓ`�[�f�[�^�����ɍ쐬���� ---------->>>>>
    /// <summary>
    /// ���㖾�׃f�[�^�A�N�Z�X�̑㗝�l�N���X
    /// </summary>
    public sealed class SalesDetailAgent
    {
        #region ���㖾�׃f�[�^�̃}�b�v

        /// <summary>���㖾�׃f�[�^�̃}�b�v</summary>
        private readonly Dictionary<string, SalesDetailTuple> _salesDetailMap = new Dictionary<string, SalesDetailTuple>();
        /// <summary>���㖾�׃f�[�^�̃}�b�v���擾���܂��B</summary>
        /// <remarks>�L�[�F��ƃR�[�h + ���_�R�[�h + �󒍃X�e�[�^�X + ����`�[�ԍ� + ���㖾�׍s�ԍ�</remarks>
        private Dictionary<string, SalesDetailTuple> SalesDetailMap { get { return _salesDetailMap; } }

        /// <summary>
        /// �L�[���擾���܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="acptAnOdrStatus">�󒍃X�e�[�^�X</param>
        /// <param name="salesSlipNum">����`�[�ԍ�</param>
        /// <param name="salesRowNo">���㖾�׍s�ԍ�</param>
        /// <returns>��ƃR�[�h + ���_�R�[�h + �󒍃X�e�[�^�X + ����`�[�ԍ� + ���㖾�׍s�ԍ�</returns>
        private static string GetKey(
            string enterpriseCode,
            string sectionCode,
            int acptAnOdrStatus,
            string salesSlipNum,
            int salesRowNo
        )
        {
            StringBuilder key = new StringBuilder();
            {
                key.Append(SCMEntityUtil.FormatEnterpriseCode(enterpriseCode));
                key.Append(SCMEntityUtil.FormatSectionCode(sectionCode));
                key.Append(acptAnOdrStatus.ToString("00"));
                key.Append(salesSlipNum.PadLeft(9, '0'));
                key.Append(salesRowNo.ToString("000"));
            }
            return key.ToString();
        }

        #endregion // ���㖾�׃f�[�^�̃}�b�v

        #region Constructor

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public SalesDetailAgent() { }

        #endregion // Constructor

        /// <summary>
        /// ���㖾�׃f�[�^���������܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="acptAnOdrStatus">�󒍃X�e�[�^�X</param>
        /// <param name="salesSlipNum">����`�[�ԍ�</param>
        /// <param name="salesRowNo">���㖾�׍s�ԍ�</param>
        /// <param name="detailWorkArray">���㖾�׃f�[�^</param>
        /// <param name="acceptOdrCarWorkArray">�󒍃}�X�^�i�ԗ��j</param>
        /// <returns>�Y�����锄�㖾�׃f�[�^�z�� ���Y���f�[�^���Ȃ��ꍇ�A��(�T�C�Y0)�̔��㖾�׃f�[�^�z���Ԃ��܂�</returns>
        // 2011/02/09 >>>
        //public SalesDetailWork[] FindSalesDetails(
        //    string enterpriseCode,
        //    string sectionCode,
        //    int acptAnOdrStatus,
        //    string salesSlipNum,
        //    int salesRowNo
        //)

        public void FindSalesDetailInfo(
            string enterpriseCode,
            string sectionCode,
            int acptAnOdrStatus,
            string salesSlipNum,
            int salesRowNo,
            out SalesDetailWork[] detailWorkArray,
            out AcceptOdrCarWork[] acceptOdrCarWorkArray
        )
        // 2011/02/09 <<<
        {
            // 2011/02/09 Add >>>
            detailWorkArray = null;
            acceptOdrCarWorkArray = null;
            // 2011/02/09 Add <<<

            string key = GetKey(enterpriseCode, sectionCode, acptAnOdrStatus, salesSlipNum, salesRowNo);
            if (SalesDetailMap.ContainsKey(key))
            {
                // 2011/02/09 >>>
                //return SalesDetailMap[key].Member01.ToArray();
                detailWorkArray = SalesDetailMap[key].Member01.ToArray();
                acceptOdrCarWorkArray = SalesDetailMap[key].Member02.ToArray();
                // 2011/02/09 <<<
            }
            // 2011/02/09 >>>
            //OtherAppComponent otherApp = new OtherAppComponent(enterpriseCode, sectionCode);
            //SalesDetailTuple salesDetailTuple = otherApp.SearchSalesDetail(acptAnOdrStatus, salesSlipNum, salesRowNo);
            //SalesDetailMap.Add(key, salesDetailTuple);

            //return salesDetailTuple.Member01.ToArray();
            else
            {
                OtherAppComponent otherApp = new OtherAppComponent(enterpriseCode, sectionCode);
                SalesDetailTuple salesDetailTuple = otherApp.SearchSalesDetail(acptAnOdrStatus, salesSlipNum, salesRowNo);
                SalesDetailMap.Add(key, salesDetailTuple);

                detailWorkArray = salesDetailTuple.Member01.ToArray();
                acceptOdrCarWorkArray = salesDetailTuple.Member02.ToArray();
            }
            // 2011/02/09 <<<
        }
    }
    // ADD 2010/04/05 �ȑO�Ɍ��ϓ`�[�f�[�^���쐬���Ă��锭���̏ꍇ�A�쐬����񓚃f�[�^����є���`�[�f�[�^�͌��ϓ`�[�f�[�^�����ɍ쐬���� ----------<<<<<
}

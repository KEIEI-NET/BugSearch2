using System;
using System.Collections;
using System.Data;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Collections;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Common;
using Broadleaf.Library;

namespace Broadleaf.Application.Common
{
	/// <summary>
	/// ���i�d����擾�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note		: ���i�Ǘ�����ǂݍ��݁A�d����̎擾���s���܂��B</br>
	/// <br>Programmer	: 22008�@���� ���n</br>
	/// <br>Date		: 2009.04.16</br>
    /// <br></br>
    /// <br>Note		: �d����擾�̗D�揇�ʂ�ύX[ MANTIS ID:13460]</br>
    /// <br>Programmer	: 23012�@���� �[���N</br>
    /// <br>Date		: 2009.06.11</br>
    /// <br>Update Note: 2013/05/06 yangyi</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00 PM1301E(���x�����j</br>
    /// <br>           : Redmine#35493 �@�I�����������ŁA�|���}�X�^�̌������������ɁA�������Ԃ������A���T�[�o�[���ׂ������Ȃ�(#1902)</br>
    /// </remarks>
	public class GoodsSupplierGetter
	{
        // ===================================================================================== //
        // �p�u���b�N�ϐ�
        // ===================================================================================== //
        #region ��Public Members
        /// <summary>�S�Ўw�苒�_�R�[�h</summary>
        public const string ctAllDefSectionCode = "00";

		#endregion

        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        # region ��Private Members

        # endregion

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region ��Constracter

		/// <summary>
		/// �P���Z�o�N���X �R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Programmer : 22008�@���� ���n</br>
		/// <br>Date       : 2009.04.16</br>
		/// </remarks>
        public GoodsSupplierGetter()
		{

        }

		# endregion

        // ===================================================================================== //
        // �p�u���b�N���\�b�h
        // ===================================================================================== //
        #region��Public Methods
        /// <summary>
        /// ���i�d������擾
        /// </summary>
        /// <param name="goodsSupplierDataList">�擾�p�f�[�^�N���X���X�g</param>
        public void GetGoodsMngInfo(ref List<GoodsSupplierDataWork> goodsSupplierDataList)
        {
            int status = 0;

            //��ƃR�[�h�擾
            string enterpriseCode = (goodsSupplierDataList[0] as GoodsSupplierDataWork).EnterpriseCode;

            //���i�Ǘ����}�X�^�擾
            List<GoodsMngWork> goodsMngList = null;
            status = Search_GoodsMng(enterpriseCode, out goodsMngList);

            //���i�Ǘ���񂪎擾�o���Ȃ��ꍇ�͈ȉ��̏������s��Ȃ�
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return;
            
            Dictionary<string, GoodsMngWork> goodsMngDic1 = null;     //���_�{���[�J�[�{�i��
            Dictionary<string, GoodsMngWork> goodsMngDic2 = null;     //���_�{�����ށ{���[�J�[�{�a�k
            Dictionary<string, GoodsMngWork> goodsMngDic3 = null;     //���_�{�����ށ{���[�J�[
            Dictionary<string, GoodsMngWork> goodsMngDic4 = null;     //���_�{���[�J�[

            //���i�Ǘ����}�X�^
            MakeGoodsMngDictionary(goodsMngList, out goodsMngDic1, out goodsMngDic2, out goodsMngDic3, out goodsMngDic4);

            for (int i = 0; i < goodsSupplierDataList.Count;i++ )
            {
                GoodsSupplierDataWork goodsSupplierDataWork = goodsSupplierDataList[i];

                //���i�Ǘ���񂩂�Ώۂ̎d������擾
                GetGoodsMngInfoProc(goodsMngDic1, goodsMngDic2, goodsMngDic3, goodsMngDic4, ref goodsSupplierDataWork);
            }

        }


        // --- ADD yangyi 2013/05/06 for Redmine#35493 ------->>>>>>>>>>>
        /// <summary>
        /// ���i�d������擾
        /// </summary>
        public void GetGoodsMngInfo(string enterpriseCode, ref Dictionary<string, GoodsMngWork> goodsMngDic1, ref Dictionary<string, GoodsMngWork> goodsMngDic2, ref Dictionary<string, GoodsMngWork> goodsMngDic3, ref Dictionary<string, GoodsMngWork> goodsMngDic4)
        {
            int status = 0;

            //���i�Ǘ����}�X�^�擾
            List<GoodsMngWork> goodsMngList = null;
            status = Search_GoodsMng(enterpriseCode, out goodsMngList);

            //���i�Ǘ���񂪎擾�o���Ȃ��ꍇ�͈ȉ��̏������s��Ȃ�
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return;

            //���i�Ǘ����}�X�^
            MakeGoodsMngDictionary(goodsMngList, out goodsMngDic1, out goodsMngDic2, out goodsMngDic3, out goodsMngDic4);
        }

        public void GetSupplierInfo(ref GoodsSupplierDataWork goodsSupplierDataWork, Dictionary<string, GoodsMngWork> goodsMngDic1, Dictionary<string, GoodsMngWork> goodsMngDic2, Dictionary<string, GoodsMngWork> goodsMngDic3, Dictionary<string, GoodsMngWork> goodsMngDic4)
        {
            GetGoodsMngInfoProc(goodsMngDic1, goodsMngDic2, goodsMngDic3, goodsMngDic4, ref goodsSupplierDataWork);
        }
        // --- ADD yangyi 2013/05/06 for Redmine#35493 -------<<<<<<<<<<<

		#endregion

        // ===================================================================================== //
        // �v���C�x�[�g���\�b�h
        // ===================================================================================== //
        #region ��Private Methods
        /// <summary>
        /// ���i�Ǘ����擾
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="goodsMngList">���i�Ǘ���񃊃X�g</param>
        /// <returns>STATUS</returns>
        private int Search_GoodsMng(string enterpriseCode, out List<GoodsMngWork> goodsMngList)
        {
            int status = 0;

            goodsMngList = new List<GoodsMngWork>();
            GoodsMngDB goodsMngDB = new GoodsMngDB();

            GoodsMngWork paraWork = new GoodsMngWork();
            paraWork.EnterpriseCode = enterpriseCode;

            object paraobj = paraWork;
            object retobj = null;

            //���i�Ǘ����}�X�^���o
            status = goodsMngDB.Search(out retobj, paraobj, 0, 0);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                ArrayList list = retobj as ArrayList;
                goodsMngList.AddRange((GoodsMngWork[])list.ToArray(typeof(GoodsMngWork)));
            }

            return status;
        }

        /// <summary>
        /// ���i�Ǘ����擾
        /// </summary>
        /// <param name="goodsMngList">���i�Ǘ���񃊃X�g</param>
        /// <param name="goodsMngDic1">���_�{���[�J�[�{�i��</param>
        /// <param name="goodsMngDic2">���_�{�����ށ{���[�J�[�{�a�k</param>
        /// <param name="goodsMngDic3">���_�{�����ށ{���[�J�[</param>
        /// <param name="goodsMngDic4">���_�{���[�J�[</param>
        /// <returns>STATUS</returns>
        private void MakeGoodsMngDictionary(List<GoodsMngWork> goodsMngList, out Dictionary<string, GoodsMngWork> goodsMngDic1, out Dictionary<string, GoodsMngWork> goodsMngDic2, out Dictionary<string, GoodsMngWork> goodsMngDic3, out Dictionary<string, GoodsMngWork> goodsMngDic4)
        {

            goodsMngDic1 = new Dictionary<string, GoodsMngWork>();     //���_�{���[�J�[�{�i��
            goodsMngDic2 = new Dictionary<string, GoodsMngWork>();     //���_�{�����ށ{���[�J�[�{�a�k
            goodsMngDic3 = new Dictionary<string, GoodsMngWork>();     //���_�{�����ށ{���[�J�[
            goodsMngDic4 = new Dictionary<string, GoodsMngWork>();     //���_�{���[�J�[

            StringBuilder goodsMngDic1Key = null;
            StringBuilder goodsMngDic2Key = null;
            StringBuilder goodsMngDic3Key = null;
            StringBuilder goodsMngDic4Key = null;

            for (int i = 0; i <= goodsMngList.Count - 1; i++)
            {
                goodsMngDic1Key = new StringBuilder();
                goodsMngDic2Key = new StringBuilder();
                goodsMngDic3Key = new StringBuilder();
                goodsMngDic4Key = new StringBuilder();

                goodsMngDic4Key.Append(goodsMngList[i].SectionCode.Trim().PadLeft(2, '0'));     //���_
                goodsMngDic4Key.Append(goodsMngList[i].GoodsMakerCd.ToString("0000"));          //���[�J�[

                if (goodsMngList[i].GoodsNo.Trim() != string.Empty)
                {
                    goodsMngDic1Key.Append(goodsMngDic4Key.ToString());                         //���_�{���[�J�[
                    goodsMngDic1Key.Append(goodsMngList[i].GoodsNo.Trim());                     //�i��

                    //���_�{���[�J�[�{�i��
                    if (!goodsMngDic1.ContainsKey(goodsMngDic1Key.ToString()))
                    {
                       goodsMngDic1.Add(goodsMngDic1Key.ToString(), goodsMngList[i]);
                    }
                }
                else
                {
                    goodsMngDic3Key.Append(goodsMngDic4Key.ToString());                         //���_�{���[�J�[
                    goodsMngDic3Key.Append(goodsMngList[i].GoodsMGroup.ToString("0000"));       //������

                    goodsMngDic2Key.Append(goodsMngDic3Key.ToString());                         //���_�{���[�J�[�{������
                    goodsMngDic2Key.Append(goodsMngList[i].BLGoodsCode.ToString("00000"));      //�a�k

                    if (goodsMngList[i].BLGoodsCode != 0)
                    {
                        //���_�{�����ށ{���[�J�[�{�a�k
                        if (!goodsMngDic2.ContainsKey(goodsMngDic2Key.ToString()))
                        {
                            goodsMngDic2.Add(goodsMngDic2Key.ToString(), goodsMngList[i]);
                        }
                    }
                    else if (goodsMngList[i].GoodsMGroup != 0)
                    {
                        //���_�{�����ށ{���[�J�[
                        if (!goodsMngDic3.ContainsKey(goodsMngDic3Key.ToString()))
                        {
                            goodsMngDic3.Add(goodsMngDic3Key.ToString(), goodsMngList[i]);
                        }
                    }
                    else
                    {
                        //���_�{���[�J�[
                        if (!goodsMngDic4.ContainsKey(goodsMngDic4Key.ToString()))
                        {
                            goodsMngDic4.Add(goodsMngDic4Key.ToString(), goodsMngList[i]);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// ���i�Ǘ����擾
        /// </summary>
        /// <param name="goodsSupplierData">���i�A���f�[�^�I�u�W�F�N�g</param>
        /// <param name="goodsMngDic1">���_�{���[�J�[�{�i��</param>
        /// <param name="goodsMngDic2">���_�{�����ށ{���[�J�[�{�a�k</param>
        /// <param name="goodsMngDic3">���_�{�����ށ{���[�J�[</param>
        /// <param name="goodsMngDic4">���_�{���[�J�[</param>
        private void GetGoodsMngInfoProc(Dictionary<string, GoodsMngWork> goodsMngDic1, Dictionary<string, GoodsMngWork> goodsMngDic2, Dictionary<string, GoodsMngWork> goodsMngDic3, Dictionary<string, GoodsMngWork> goodsMngDic4, ref GoodsSupplierDataWork goodsSupplierData)
        {
            GoodsMngWork retGoodsMng = null;

            try
            {
                #region DEL 2009/06/11
                /*
                StringBuilder goodsMngDic1key = new StringBuilder();
                StringBuilder goodsMngDic2key = new StringBuilder();
                StringBuilder goodsMngDic3key = new StringBuilder();
                StringBuilder goodsMngDic4key = new StringBuilder();
                StringBuilder goodsMngDic5key = new StringBuilder();
                StringBuilder goodsMngDic6key = new StringBuilder();
                StringBuilder goodsMngDic7key = new StringBuilder();
                StringBuilder goodsMngDic8key = new StringBuilder();

                goodsMngDic4key.Append(goodsSupplierData.SectionCode.Trim().PadLeft(2, '0'));    //���_
                goodsMngDic4key.Append(goodsSupplierData.GoodsMakerCd.ToString("0000"));        //���[�J�[

                goodsMngDic1key.Append(goodsMngDic4key.ToString());                         //���_�{���[�J�[
                goodsMngDic1key.Append(goodsSupplierData.GoodsNo.Trim());                       //�i��

                goodsMngDic3key.Append(goodsMngDic4key.ToString());                         //���_�{���[�J�[
                goodsMngDic3key.Append(goodsSupplierData.GoodsMGroup.ToString("0000"));         //������

                goodsMngDic2key.Append(goodsMngDic3key.ToString());                         //���_�{���[�J�[�{������
                goodsMngDic2key.Append(goodsSupplierData.BLGoodsCode.ToString("00000"));        //�a�k

                if (goodsMngDic1.ContainsKey(goodsMngDic1key.ToString()))
                {
                    //���_�{���[�J�[�{�i��
                    retGoodsMng = goodsMngDic1[goodsMngDic1key.ToString()];
                }
                else if (goodsMngDic2.ContainsKey(goodsMngDic2key.ToString()))
                {
                    //���_�{�����ށ{���[�J�[�{�a�k
                    retGoodsMng = goodsMngDic2[goodsMngDic2key.ToString()];
                }
                else if (goodsMngDic3.ContainsKey(goodsMngDic3key.ToString()))
                {
                    //���_�{�����ށ{���[�J�[
                    retGoodsMng = goodsMngDic3[goodsMngDic3key.ToString()];
                }
                else if (goodsMngDic4.ContainsKey(goodsMngDic4key.ToString()))
                {
                    //���_�{���[�J�[
                    retGoodsMng = goodsMngDic4[goodsMngDic4key.ToString()];
                }
                else
                {
                    goodsMngDic8key.Append(ctAllDefSectionCode);                            //�S��
                    goodsMngDic8key.Append(goodsSupplierData.GoodsMakerCd.ToString("0000"));    //���[�J�[

                    goodsMngDic5key.Append(goodsMngDic8key.ToString());                     //�S�Ё{���[�J�[
                    goodsMngDic5key.Append(goodsSupplierData.GoodsNo.Trim());                   //�i��

                    goodsMngDic7key.Append(goodsMngDic8key.ToString());                     //�S�Ё{���[�J�[
                    goodsMngDic7key.Append(goodsSupplierData.GoodsMGroup.ToString("0000"));     //������

                    goodsMngDic6key.Append(goodsMngDic7key.ToString());                     //�S�Ё{���[�J�[�{������
                    goodsMngDic6key.Append(goodsSupplierData.BLGoodsCode.ToString("00000"));    //�a�k

                    if (goodsMngDic1.ContainsKey(goodsMngDic5key.ToString()))
                    {
                        //�S�Ё{���[�J�[�{�i��
                        retGoodsMng = goodsMngDic1[goodsMngDic5key.ToString()];
                    }
                    else if (goodsMngDic2.ContainsKey(goodsMngDic6key.ToString()))
                    {
                        //�S�Ё{�����ށ{���[�J�[�{�a�k
                        retGoodsMng = goodsMngDic2[goodsMngDic6key.ToString()];
                    }
                    else if (goodsMngDic3.ContainsKey(goodsMngDic7key.ToString()))
                    {
                        //�S�Ё{�����ށ{���[�J�[
                        retGoodsMng = goodsMngDic3[goodsMngDic7key.ToString()];
                    }
                    else if (goodsMngDic4.ContainsKey(goodsMngDic8key.ToString()))
                    {
                        //�S�Ё{���[�J�[
                        retGoodsMng = goodsMngDic4[goodsMngDic8key.ToString()];
                    }
                }
                */
                #endregion

                // ---ADD 2009/06/11 �D�揇�ύX ------------------------------------->>>>>
                //���_�{���[�J�[
                StringBuilder goodsMngDic4key = new StringBuilder();
                goodsMngDic4key.Append(goodsSupplierData.SectionCode.Trim().PadLeft(2, '0'));
                goodsMngDic4key.Append(goodsSupplierData.GoodsMakerCd.ToString("0000"));
                //�y���_�{���[�J�[�z�{�i��
                StringBuilder goodsMngDic1key = new StringBuilder();
                goodsMngDic1key.Append(goodsMngDic4key.ToString());
                goodsMngDic1key.Append(goodsSupplierData.GoodsNo.Trim());

                //1.���_�{���[�J�[�{�i��
                if (goodsMngDic1.ContainsKey(goodsMngDic1key.ToString()))
                {
                    retGoodsMng = goodsMngDic1[goodsMngDic1key.ToString()];
                    return;
                }

                //�S�Ё{���[�J�[
                StringBuilder goodsMngDic8key = new StringBuilder();
                goodsMngDic8key.Append(ctAllDefSectionCode);
                goodsMngDic8key.Append(goodsSupplierData.GoodsMakerCd.ToString("0000"));
                //�y�S�Ё{���[�J�[�z�{�i��
                StringBuilder goodsMngDic5key = new StringBuilder();
                goodsMngDic5key.Append(goodsMngDic8key.ToString());
                goodsMngDic5key.Append(goodsSupplierData.GoodsNo.Trim());

                //2.�S�Ё{���[�J�[�{�i��
                if (goodsMngDic1.ContainsKey(goodsMngDic5key.ToString()))
                {
                    retGoodsMng = goodsMngDic1[goodsMngDic5key.ToString()];
                    return;
                }

                //�y���_�{���[�J�[�z�{������
                StringBuilder goodsMngDic3key = new StringBuilder();
                goodsMngDic3key.Append(goodsMngDic4key.ToString());
                goodsMngDic3key.Append(goodsSupplierData.GoodsMGroup.ToString("0000"));
                //�y���_�{���[�J�[�{�����ށz�{�a�k
                StringBuilder goodsMngDic2key = new StringBuilder();
                goodsMngDic2key.Append(goodsMngDic3key.ToString());
                goodsMngDic2key.Append(goodsSupplierData.BLGoodsCode.ToString("00000"));

                //3.���_�{�����ށ{���[�J�[�{�a�k
                if (goodsMngDic2.ContainsKey(goodsMngDic2key.ToString()))
                {
                    retGoodsMng = goodsMngDic2[goodsMngDic2key.ToString()];
                    return;
                }

                //�y�S�Ё{���[�J�[�z�{������
                StringBuilder goodsMngDic7key = new StringBuilder();
                goodsMngDic7key.Append(goodsMngDic8key.ToString());
                goodsMngDic7key.Append(goodsSupplierData.GoodsMGroup.ToString("0000"));
                //�y�S�Ё{���[�J�[�{�����ށz�{�a�k
                StringBuilder goodsMngDic6key = new StringBuilder();
                goodsMngDic6key.Append(goodsMngDic7key.ToString());
                goodsMngDic6key.Append(goodsSupplierData.BLGoodsCode.ToString("00000"));

                //4.�S�Ё{�����ށ{���[�J�[�{�a�k
                if (goodsMngDic2.ContainsKey(goodsMngDic6key.ToString()))
                {
                    retGoodsMng = goodsMngDic2[goodsMngDic6key.ToString()];
                    return;
                }

                //5.���_�{�����ށ{���[�J�[
                if (goodsMngDic3.ContainsKey(goodsMngDic3key.ToString()))
                {
                    retGoodsMng = goodsMngDic3[goodsMngDic3key.ToString()];
                    return;
                }

                //6.�S�Ё{�����ށ{���[�J�[
                if (goodsMngDic3.ContainsKey(goodsMngDic7key.ToString()))
                {
                    retGoodsMng = goodsMngDic3[goodsMngDic7key.ToString()];
                    return;
                }

                //7.���_�{���[�J�[
                if (goodsMngDic4.ContainsKey(goodsMngDic4key.ToString()))
                {
                    retGoodsMng = goodsMngDic4[goodsMngDic4key.ToString()];
                    return;
                }

                //8.�S�Ё{���[�J�[
                if (goodsMngDic4.ContainsKey(goodsMngDic8key.ToString()))
                {
                    retGoodsMng = goodsMngDic4[goodsMngDic8key.ToString()];
                    return;
                }
                // ---ADD 2009/06/11 �D�揇�ύX -------------------------------------<<<<<

            }
            finally
            {
                if (retGoodsMng != null)
                {
                    // ���i�A���N���X�֏��i�Ǘ����Z�b�g
                    goodsSupplierData.SectionCode = retGoodsMng.SectionCode;
                    goodsSupplierData.SupplierCd = retGoodsMng.SupplierCd;
                    goodsSupplierData.SupplierLot = retGoodsMng.SupplierLot;

                }
            }
        }

		#endregion


	}

}
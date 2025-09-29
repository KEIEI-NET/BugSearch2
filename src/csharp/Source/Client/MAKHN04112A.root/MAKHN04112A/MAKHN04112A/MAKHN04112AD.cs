# region ��using
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;

using Broadleaf.Library.Collections;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Text;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.LocalAccess;
using Broadleaf.Xml.Serialization;
using Broadleaf.Library.Runtime.Serialization;
# endregion

namespace Broadleaf.Application.Controller
{
    ///// <summary>
    ///// ���i�}�X�^(�񋟕�) �e�[�u���A�N�Z�X�N���X
    ///// </summary>
    ///// <remarks>
    ///// -----------------------------------------------------------------------------------
    ///// <br>Note		: ���i�}�X�^(�񋟕�) �e�[�u���̃A�N�Z�X������s���܂��B</br>
    ///// <br>Programmer	: 20056 ���n ���</br>
    ///// <br>Date		: 2007.08.13</br>
    ///// <br>UpdateNote : 2008.02.19 96012�@���F �]</br>
    ///// <br>           : ���[�J���c�a�Q�ƑΉ�</br>
    ///// <br>UpdateNote : 2008.02.29 96012�@���F �]</br>
    ///// <br>           : �񋟕��̓��[�J���c�a�ւ̃A�N�Z�X�̂�</br>
    ///// </remarks>
    //public class OfrGoodsPriceAcs
    //{
    //    # region ��Private Member
    //    /// <summary>�����[�g�I�u�W�F�N�g�i�[�o�b�t�@</summary>
    //    // 2008.02.29 96012 �񋟕��̓��[�J���c�a�ւ̃A�N�Z�X�̂� Begin
    //    //private IOfrGoodsPriceDB _iOfrGoodsPriceDB = null;
    //    // 2008.02.29 96012 �񋟕��̓��[�J���c�a�ւ̃A�N�Z�X�̂� end
    //    // 2008.02.19 96012 ���[�J���c�a�Q�ƑΉ� Begin
    //    private OfrGoodsPriceLcDB _ofrGoodsPriceLcDB = null;
    //    // 2008.02.19 96012 ���[�J���c�a�Q�ƑΉ� end

    //    /// <summary>���i�}�X�^(�񋟕�) �N���XStatic</summary>
    //    private static Hashtable _ofrgoodspriceTable_Stc = null;

    //    /// <summary>���[�J���c�a���[�h</summary>
    //    // 2008.02.19 96012 ���[�J���c�a�Q�ƑΉ� Begin
    //    //private static bool _isLocalDBRead = true;
    //    private static bool _isLocalDBRead = false;
    //    // 2008.02.19 96012 ���[�J���c�a�Q�ƑΉ� end

    //    private const string GUIDE_SEARCHMODE_PARA = "SearchMode";                     // �K�C�h�f�[�^�T�[�`���[�h(0:���[�J��,1:�����[�g) iitani a 2007.05.07

    //    # endregion

    //    # region ��Constracter
    //    /// <summary>
    //    /// ���i�}�X�^(�񋟕�) �e�[�u���A�N�Z�X�N���X�R���X�g���N�^
    //    /// </summary>
    //    /// <remarks>
    //    /// <br>Note       : ���i�}�X�^ �e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
    //    /// <br>Programmer : 20056 ���n ���</br>
    //    /// <br>Date       : 2007.08.13</br>
    //    /// -----------------------------------------------------------------------
    //    /// <br>UpdateNote : 2008.02.19 96012�@���F �]</br>
    //    /// <br>           : ���[�J���c�a�Q�ƑΉ�</br>
    //    /// <br>UpdateNote : 2008.02.29 96012�@���F �]</br>
    //    /// <br>           : �񋟕��̓��[�J���c�a�ւ̃A�N�Z�X�̂�</br>
    //    /// </remarks>
    //    public OfrGoodsPriceAcs()
    //    {
    //        // ��������������
    //        MemoryCreate();

    //        // 2008.02.29 96012 �񋟕��̓��[�J���c�a�ւ̃A�N�Z�X�̂� Begin
    //        //// ���O�C�����i�ŒʐM��Ԃ��m�F
    //        //if (LoginInfoAcquisition.OnlineFlag)
    //        //{
    //        //    try
    //        //    {
    //        //        // �����[�g�I�u�W�F�N�g�擾
    //        //        this._iOfrGoodsPriceDB = (IOfrGoodsPriceDB)MediationOfrGoodsPriceDB.GetOfrGoodsPriceDB();
    //        //    }
    //        //    catch (Exception)
    //        //    {
    //        //        //�I�t���C������null���Z�b�g
    //        //        this._iOfrGoodsPriceDB = null;
    //        //    }
    //        //}
    //        //else
    //        //{
    //        //    // �I�t���C�����̃f�[�^�ǂݍ���
    //        //    this.SearchOfflineData();
    //        //}
    //        // 2008.02.29 96012 �񋟕��̓��[�J���c�a�ւ̃A�N�Z�X�̂� end

    //        // ���[�J��DB�A�N�Z�X�I�u�W�F�N�g�擾
    //        //this._lGoodsGanreLcDB = new LGoodsGanreLcDB();   // iitani a
    //        // 2008.02.19 96012 ���[�J���c�a�Q�ƑΉ� Begin
    //        // ���[�J��DB�A�N�Z�X�I�u�W�F�N�g�擾
    //        this._ofrGoodsPriceLcDB = new OfrGoodsPriceLcDB();
    //        // 2008.02.19 96012 ���[�J���c�a�Q�ƑΉ� end
    //    }
    //    # endregion

    //    //================================================================================
    //    //  �v���p�e�B
    //    //================================================================================
    //    #region Public Property

    //    /// <summary>
    //    /// ���[�J���c�aRead���[�h
    //    /// </summary>
    //    public bool IsLocalDBRead
    //    {
    //        get { return _isLocalDBRead; }
    //        set { _isLocalDBRead = value; }
    //    }
    //    #endregion

    //    # region ��public int GetOnlineMode()
    //    /// <summary>
    //    /// �I�����C�����[�h�擾����
    //    /// </summary>
    //    /// <returns>OnlineMode</returns>
    //    /// <remarks>
    //    /// <br>Note       : �I�����C�����[�h���擾���܂��B</br>
    //    /// <br>Programmer : 20056 ���n ���</br>
    //    /// <br>Date       : 2007.08.01</br>
    //    /// <br>UpdateNote : 2008.02.29 96012�@���F �]</br>
    //    /// <br>           : �񋟕��̓��[�J���c�a�ւ̃A�N�Z�X�̂�</br>
    //    /// </remarks>
    //    public int GetOnlineMode()
    //    {
    //        // 2008.02.29 96012 �񋟕��̓��[�J���c�a�ւ̃A�N�Z�X�̂� Begin
    //        //if (this._iOfrGoodsPriceDB == null)
    //        //{
    //        //    return (int)ConstantManagement.OnlineMode.Offline;
    //        //}
    //        //else
    //        //{
    //        //    return (int)ConstantManagement.OnlineMode.Online;
    //        //}
    //        return (int)ConstantManagement.OnlineMode.Offline;
    //        // 2008.02.29 96012 �񋟕��̓��[�J���c�a�ւ̃A�N�Z�X�̂� end
    //    }
    //    # endregion

    //    #region ��Public Method
    //    /// <summary>
    //    /// ���i�}�X�^(�񋟕�) �}�X�^Static�������S���擾����
    //    /// </summary>
    //    /// <param name="retList">���i�}�X�^ �N���XList</param>
    //    /// <returns>�X�e�[�^�X(0:����I��, -1:�G���[, 9:�f�[�^����)</returns>
    //    /// <param name="enterpriseCode">��ƃR�[�h</param>
    //    /// <remarks>
    //    /// <br>Note       : ���i�}�X�^ �}�X�^Static�������̑S�����擾���܂��B</br>
    //    /// <br>Programer  : 20056 ���n ���</br>
    //    /// <br>Date       : 2007.08.13</br>
    //    /// </remarks>
    //    public int SearchStaticMemory(out ArrayList retList, object objParaList, string enterpriseCode)
    //    {
    //        retList = new ArrayList();
    //        retList.Clear();
    //        SortedList sortedList = new SortedList();

    //        if ((_ofrgoodspriceTable_Stc == null) ||
    //            (_ofrgoodspriceTable_Stc.Count == 0))
    //        {
    //            this.SearchAll(out retList, objParaList, enterpriseCode);
    //            return 0;
    //        }
    //        else if (_ofrgoodspriceTable_Stc.Count == 0)
    //        {
    //            return 9;
    //        }

    //        foreach (OfrGoodsPrice ofrGoodsPrice in _ofrgoodspriceTable_Stc.Values)
    //        {
    //            string strkey = string.Format("000000", ofrGoodsPrice.GoodsMakerCd) + ofrGoodsPrice.GoodsNo + string.Format("00", ofrGoodsPrice.PriceDivCd);
    //            sortedList.Add(strkey, ofrGoodsPrice);
    //        }

    //        retList.AddRange(sortedList.Values);

    //        return 0;
    //    }

    //    /// <summary>
    //    /// ���i�}�X�^(�񋟕�)�@�}�X�^Static�������擾����
    //    /// </summary>
    //    /// <param name="alttlblockstrf"></param>
    //    /// <param name="enterpriseCodeRF"></param>
    //    /// <param name="alTtlBlockCodeRF"></param>
    //    /// <returns></returns>
    //    public int ReadStaticMemory(out OfrGoodsPrice ofrgoodspricerf, object objParaList, string enterpriseCodeRF, int goodsMakerCdRF, string goodsNoRF, int priceDivCdRF)
    //    //public int ReadStaticMemory(out AlTtlBlockSt alttlblockstrf, string enterpriseCodeRF, string alTtlBlockCodeRF)
    //    {
    //        ofrgoodspricerf = new OfrGoodsPrice();
    //        //alttlblockstrf = new AlTtlBlockSt();

    //        if ((_ofrgoodspriceTable_Stc == null) ||
    //            (_ofrgoodspriceTable_Stc.Count == 0))
    //        {
    //            ArrayList ofrgoodspriceList = new ArrayList();
    //            this.SearchAll(out ofrgoodspriceList, objParaList, enterpriseCodeRF);
    //        }

    //        // Static���猟��
    //        string strkey = string.Format("000000", goodsMakerCdRF) + goodsNoRF + string.Format("00", priceDivCdRF);
    //        if (_ofrgoodspriceTable_Stc[strkey] == null)
    //        {
    //            return 4;
    //        }
    //        else 
    //        {
    //            ofrgoodspricerf = (OfrGoodsPrice)_ofrgoodspriceTable_Stc[strkey];
    //        }

    //        return 0;

    //    }

    //    /// <summary>
    //    /// ���i�}�X�^(�񋟕�) Static���������I�t���C���������ݏ���
    //    /// </summary>
    //    /// <param name="sender">object�i�ďo���I�u�W�F�N�g�j</param>
    //    /// <returns>STATUS</returns>
    //    /// <remarks>
    //    /// <br>Note       : ���i�}�X�^(�񋟕�) Static�������̏������[�J���t�@�C���ɕۑ����܂��B</br>
    //    /// <br>Programer  : 20056 ���n ���</br>
    //    /// <br>Date       : 2007.08.13</br>
    //    /// </remarks>
    //    public int WriteOfflineData(object sender)
    //    {
    //        // �I�t���C���V���A���C�Y�f�[�^�쐬���iI/O
    //        OfflineDataSerializer offlineDataSerializer = new OfflineDataSerializer();
    //        int status;

    //        // KeyList�ݒ�
    //        string[] ofrgoodspriceKeys = new string[1];
    //        ofrgoodspriceKeys[0] = LoginInfoAcquisition.EnterpriseCode;

    //        SortedList sortedList = new SortedList();

    //        OfrGoodsPriceWork ofrgoodspriceWork = new OfrGoodsPriceWork();
    //        foreach (OfrGoodsPrice ofrgoodsprice in _ofrgoodspriceTable_Stc.Values)
    //        {
    //            // �N���X�˃��[�J�[�N���X
    //            ofrgoodspriceWork = CopyToOfrGoodsPriceWorkFromOfrGoodsPrice(ofrgoodsprice);
                
    //            // �\�[�g
    //            string strkey = string.Format("000000", ofrgoodsprice.GoodsMakerCd) + ofrgoodsprice.GoodsNo + string.Format("00", ofrgoodsprice.PriceDivCd);
    //            sortedList.Add(strkey, ofrgoodspriceWork);
    //        }

    //        ArrayList ofrgoodspriceWorkList = new ArrayList();
    //        ofrgoodspriceWorkList.AddRange(sortedList.Values);
    //        status = offlineDataSerializer.Serialize("OfrGoodsPriceAcs", ofrgoodspriceKeys, ofrgoodspriceWorkList);

    //        return status;
    //    }

    //    /// <summary>
    //    /// ���i�}�X�^(��)�ǂݍ��ݏ���
    //    /// </summary>
    //    /// <param name="ofrgoodsprice">���i�}�X�^(��)�I�u�W�F�N�g</param>
    //    /// <param name="enterpriseCode">��ƃR�[�h</param>
    //    /// <param name="goodsmakercd">���i���[�J�[�R�[�h</param>
    //    /// <param name="goodsno">���i�ԍ�</param>
    //    /// <returns></returns>
    //    /// <remarks>
    //    /// <br>Note       : ���i�}�X�^(��)����ǂݍ��݂܂��B</br>
    //    /// <br>Programmer : 20056 ���n ���</br>
    //    /// <br>Date       : 2007.08.01</br>
    //    /// <br>UpdateNote : 2008.02.29 96012�@���F �]</br>
    //    /// <br>           : �񋟕��̓��[�J���c�a�ւ̃A�N�Z�X�̂�</br>
    //    /// </remarks>
    //    public int Read(out OfrGoodsPrice ofrgoodsprice, string enterpriseCode, int goodsmakercd, string goodsno)
    //    {
    //        try
    //        {
    //            int status;
    //            ofrgoodsprice = null;
    //            OfrGoodsPriceWork ofrgoodspriceWork = new OfrGoodsPriceWork();

    //            //ofrgoodspriceWork.EnterpriseCode = enterpriseCode;
    //            ofrgoodspriceWork.GoodsMakerCd = goodsmakercd;
    //            ofrgoodspriceWork.GoodsNo = goodsno;

    //            // 2008.02.29 96012 �񋟕��̓��[�J���c�a�ւ̃A�N�Z�X�̂� Begin
    //            //byte[] parabyte = null;
    //            //
    //            //// �����[�g
    //            //parabyte = XmlByteSerializer.Serialize(ofrgoodspriceWork);
    //            //status = this._iOfrGoodsPriceDB.Read(ref parabyte, 0);
    //            //if (status == 0)
    //            //{
    //            //    ofrgoodspriceWork = (OfrGoodsPriceWork)XmlByteSerializer.Deserialize(parabyte, typeof(OfrGoodsPriceWork));
    //            //}
    //            status = this._ofrGoodsPriceLcDB.Read(ref ofrgoodspriceWork, 0);
    //            // 2008.02.29 96012 �񋟕��̓��[�J���c�a�ւ̃A�N�Z�X�̂� end

    //            if (status == 0)
    //            {
    //                // �N���X�������o�R�s�[
    //                ofrgoodsprice = CopyToOfrGoodsPriceFormOfrGoodsPriceWork(ofrgoodspriceWork);
    //                // Read�pStatic�ɕێ�
    //                string strkey = string.Format("000000", ofrgoodsprice.GoodsMakerCd) + ofrgoodsprice.GoodsNo + string.Format("00", ofrgoodsprice.PriceDivCd);
    //                _ofrgoodspriceTable_Stc[strkey] = ofrgoodsprice;
    //            }

    //            return status;
    //        }
    //        catch (Exception)
    //        {
    //            //�ʐM�G���[��-1��߂�
    //            ofrgoodsprice = null;
    //            // 2008.02.29 96012 �񋟕��̓��[�J���c�a�ւ̃A�N�Z�X�̂� Begin
    //            ////�I�t���C������null���Z�b�g
    //            //this._iOfrGoodsPriceDB = null;
    //            // 2008.02.29 96012 �񋟕��̓��[�J���c�a�ւ̃A�N�Z�X�̂� end
    //            return -1;
    //        }
    //    }

    //    /// <summary>
    //    /// ���i�}�X�^(��) �N���X�f�V���A���C�Y����
    //    /// </summary>
    //    /// <param name="fileName">�f�V���A���C�Y�Ώ�XML�t�@�C���t���p�X</param>
    //    /// <returns>���i�}�X�^(��) �N���X</returns>
    //    /// <remarks>
    //    /// <br>Note       : ���i�}�X�^(��) �N���X���f�V���A���C�Y���܂��B</br>
    //    /// <br>Programmer : 20056 ���n ���</br>
    //    /// <br>Date       : 2007.08.13</br>
    //    /// </remarks>
    //    public OfrGoodsPrice Deserialize(string fileName)
    //    {
    //        return null;
    //    }

    //    /// <summary>
    //    /// ���i�}�X�^(��) List�N���X�f�V���A���C�Y����
    //    /// </summary>
    //    /// <param name="fileName">�f�V���A���C�Y�Ώ�XML�t�@�C���t���p�X</param>
    //    /// <returns>���i�}�X�^(��) �N���XLIST</returns>
    //    /// <remarks>
    //    /// <br>Note       : ���i�}�X�^�}�X�^ ���X�g�N���X���f�V���A���C�Y���܂��B</br>
    //    /// <br>Programmer : 20056 ���n ���</br>
    //    /// <br>Date       : 2007.08.13</br>
    //    /// </remarks>
    //    public ArrayList ListDeserialize(string fileName)
    //    {
    //        ArrayList al = new ArrayList();

    //        // �t�@�C������n���ĉ��i�}�X�^(��)���[�N�N���X���f�V���A���C�Y����
    //        OfrGoodsPriceWork[] ofrgoodspriceWorks = (OfrGoodsPriceWork[])XmlByteSerializer.Deserialize(fileName, typeof(OfrGoodsPriceWork[]));
            
    //        //�f�V���A���C�Y���ʂ����i�}�X�^(��)�N���X�փR�s�[
    //        if (ofrgoodspriceWorks != null)
    //        {
    //            al.Capacity = ofrgoodspriceWorks.Length;
    //            for (int i = 0; i < ofrgoodspriceWorks.Length; i++)
    //            {
    //                al.Add(CopyToOfrGoodsPriceFormOfrGoodsPriceWork(ofrgoodspriceWorks[i]));
    //            }
    //        }

    //        return al;
    //    }

    //    /// <summary>
    //    /// ���i�}�X�^(��)�V���A���C�Y����
    //    /// </summary>
    //    /// <param name="ofrgoodsprice">�V���A���C�Y�Ώۉ��i�}�X�^(��)�N���X</param>
    //    /// <param name="fileName">�V���A���C�Y�t�@�C����</param>
    //    public void Serialize(OfrGoodsPrice ofrgoodsprice, string fileName)
    //    {
    //        //���i�}�X�^(��)�N���X���牿�i�}�X�^(��)���[�J�[�N���X�Ƀ����o�R�s�[
    //        OfrGoodsPriceWork ofrgoodspriceWork = CopyToOfrGoodsPriceWorkFromOfrGoodsPrice(ofrgoodsprice);
    //        //���i�}�X�^(��)���[�J�[�N���X���V���A���C�Y
    //        XmlByteSerializer.Serialize(ofrgoodspriceWork, fileName);
    //    }

    //    /// <summary>
    //    /// ���i�}�X�^(��)List�V���A���C�Y����
    //    /// </summary>
    //    /// <param name="ofrgoodsprices">�V���A���C�Y�Ώۉ��i�}�X�^(��)List�N���X</param>
    //    /// <param name="fileName">�V���A���C�Y�t�@�C����</param>
    //    /// <remarks>
    //    /// <br>Note       : ���i�}�X�^(��)List���̃V���A���C�Y���s���܂��B</br>
    //    /// <br>Programmer : 20056 ���n ���</br>
    //    /// <br>Date       : 2007.08.13</br>
    //    /// </remarks>
    //    public void ListSerialize(ArrayList ofrgoodsprices, string fileName)
    //    {
    //        OfrGoodsPriceWork[] ofrgoodspriceWorks = new OfrGoodsPriceWork[ofrgoodsprices.Count];
    //        for (int i = 0; i < ofrgoodsprices.Count; i++)
    //        {
    //            ofrgoodspriceWorks[i] = CopyToOfrGoodsPriceWorkFromOfrGoodsPrice((OfrGoodsPrice)ofrgoodsprices[i]);
    //        }
    //        //���i�}�X�^(��)���[�J�[�N���X���V���A���C�Y
    //        XmlByteSerializer.Serialize(ofrgoodsprices, fileName);
    //    }

    //    /// <summary>
    //    /// ���i�}�X�^(��)�S���������i�_���폜�����j
    //    /// </summary>
    //    /// <param name="retList">�Ǎ����ʃR���N�V����</param>
    //    /// <param name="enterpriseCode">��ƃR�[�h</param>		
    //    /// <returns>STATUS</returns>
    //    /// <remarks>
    //    /// <br>Note       : ���i�}�X�^(��)�̑S�����������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
    //    /// <br>Programmer : 20056 ���n ���</br>
    //    /// <br>Date       : 2007.08.13</br>
    //    /// </remarks>
    //    public int Search(out ArrayList retList, object objParaList, string enterpriseCode)
    //    {
    //        bool nextData;
    //        int retTotalCnt;
    //        return SearchProc(out retList, out retTotalCnt, out nextData, objParaList, enterpriseCode, 0, 0, null);
    //    }

    //    /// <summary>
    //    /// ���i�}�X�^(��)���������i�_���폜�܂ށj
    //    /// </summary>
    //    /// <param name="retList">�Ǎ����ʃR���N�V����</param>
    //    /// <param name="enterpriseCode">��ƃR�[�h</param>		
    //    /// <returns>STATUS</returns>
    //    /// <remarks>
    //    /// <br>Note       : ���i�}�X�^�̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
    //    /// <br>Programmer : 20056 ���n ���</br>
    //    /// <br>Date       : 2007.08.13</br>
    //    /// </remarks>
    //    public int SearchAll(out ArrayList retList, object objParaList, string enterpriseCode)
    //    {
    //        bool nextData;
    //        int retTotalCnt;
    //        return SearchProc(out retList, out retTotalCnt, out nextData, objParaList, enterpriseCode, ConstantManagement.LogicalMode.GetData01, 0, null);
    //    }

    //    /// <summary>
    //    /// �����w�艿�i�}�X�^(��)���������i�_���폜�����j
    //    /// </summary>
    //    /// <param name="retList">�Ǎ����ʃR���N�V����</param>
    //    /// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������(prevLGoodsGanre��null�̏ꍇ�̂ݖ߂�)</param>
    //    /// <param name="nextData">���f�[�^�L��</param>
    //    /// <param name="enterpriseCode">��ƃR�[�h</param>
    //    /// <param name="readCnt">�Ǎ�����</param>		
    //    /// <param name="prevOfrGoodsPrice">�O��f�[�^�I�u�W�F�N�g�i�����null�w��K�{�j</param>			
    //    /// <returns>STATUS</returns>
    //    /// <remarks>
    //    /// <br>Note       : �������w�肵�ĉ��i�}�X�^(��)�̌����������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
    //    /// <br>Programmer : 20056 ���n ���</br>
    //    /// <br>Date       : 2007.08.13</br>
    //    /// </remarks>
    //    public int Search(out ArrayList retList, out int retTotalCnt, out bool nextData, object objParaList, string enterpriseCode, int readCnt, OfrGoodsPrice prevOfrGoodsPrice)
    //    {
    //        return SearchProc(out retList, out retTotalCnt, out nextData, objParaList, enterpriseCode, 0, readCnt, prevOfrGoodsPrice);
    //    }

    //    /// <summary>
    //    /// �����w�艿�i�}�X�^(��)���������i�_���폜�܂ށj
    //    /// </summary>
    //    /// <param name="retList">�Ǎ����ʃR���N�V����</param>
    //    /// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������(prevLGoodsGanre��null�̏ꍇ�̂ݖ߂�)</param>
    //    /// <param name="nextData">���f�[�^�L��</param>
    //    /// <param name="enterpriseCode">��ƃR�[�h</param>
    //    /// <param name="readCnt">�Ǎ�����</param>		
    //    /// <param name="prevAlTtlBlockSt">�O��f�[�^�I�u�W�F�N�g�i�����null�w��K�{�j</param>			
    //    /// <returns>STATUS</returns>
    //    /// <remarks>
    //    /// <br>Note       : �������w�肵�ĉ��i�}�X�^(��)�̌����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
    //    /// <br>Programmer : 20056 ���n ���</br>
    //    /// <br>Date       : 2007.08.13</br>
    //    /// </remarks>
    //    public int SearchAll(out ArrayList retList, out int retTotalCnt, out bool nextData, object objParaList, string enterpriseCode, int readCnt, OfrGoodsPrice prevOfrGoodsPrice)
    //    {
    //        return SearchProc(out retList, out retTotalCnt, out nextData, objParaList, enterpriseCode, ConstantManagement.LogicalMode.GetData01, readCnt, prevOfrGoodsPrice);
    //    }

    //    /// <summary>
    //    /// ���i�}�X�^(��)��������(DataSet�p)
    //    /// </summary>
    //    /// <param name="ds">�擾���ʊi�[�pDataSet</param>
    //    /// <param name="enterpriseCode">��ƃR�[�h</param>
    //    /// <returns>STATUS</returns>
    //    /// <remarks>
    //    /// <br>Note       : ���i�}�X�^(��)�̌����������s���A�擾���ʂ�DataSet�ŕԂ��܂��B</br>
    //    /// <br>Programmer : 20056 ���n ���</br>
    //    /// <br>Date       : 2007.08.13</br>
    //    /// -----------------------------------------------------------------------
    //    /// <br>UpdateNote : 2008.02.19 96012�@���F �]</br>
    //    /// <br>           : ���[�J���c�a�Q�ƑΉ�</br>
    //    /// <br>UpdateNote : 2008.02.29 96012�@���F �]</br>
    //    /// <br>           : �񋟕��̓��[�J���c�a�ւ̃A�N�Z�X�̂�</br>
    //    /// </remarks>
    //    public int Search(ref DataSet ds, object objParaList, string enterpriseCode)
    //    {
    //        OfrGoodsPriceWork ofrgoodspriceWork = new OfrGoodsPriceWork();

    //        ArrayList ar = new ArrayList();

    //        int status = 0;
    //        // 2008.02.29 96012 �񋟕��̓��[�J���c�a�ւ̃A�N�Z�X�̂� Begin
    //        //object objectOfrGoodsPriceWork;
    //        // 2008.02.29 96012 �񋟕��̓��[�J���c�a�ւ̃A�N�Z�X�̂� end

    //        // 2008.02.29 96012 �񋟕��̓��[�J���c�a�ւ̃A�N�Z�X�̂� Begin
    //        //// �I�����C�����ASearch���s���Ă��Ȃ��ꍇ�i�I�t���C���̏ꍇ�̓R���X�g���N�^��Static�W�J�ς݁j
    //        //if ((!_searchFlg) && (LoginInfoAcquisition.OnlineFlag))
    //        //{
    //        //    // ���i�}�X�^(��)�T�[�`
    //        //    status = this._iOfrGoodsPriceDB.Search(out objectOfrGoodsPriceWork, ofrgoodspriceWork, 0, ConstantManagement.LogicalMode.GetData01);
    //        //
    //        //    if (status == 0)
    //        //    {
    //        //        // ���i�}�X�^(��)���[�J�[�N���X��UI�N���XStatic�]�L����
    //        //        CopyToStaticFromWorker(objectOfrGoodsPriceWork as ArrayList);
    //        //        // SearchFlg ON
    //        //        _searchFlg = true;
    //        //    }
    //        //    else
    //        //    {
    //        //        return status;
    //        //    }
    //        //}
    //        // ���i�}�X�^(��)�T�[�`
    //        List<OfrGoodsPriceWork> workList = new List<OfrGoodsPriceWork>();
    //        status = this._ofrGoodsPriceLcDB.Search(out workList, ofrgoodspriceWork, 0, ConstantManagement.LogicalMode.GetData01);
    //        if (status == 0)
    //        {
    //            for (int i = 0; i < workList.Count; ++i)
    //            {
    //                ar.Add(workList[i]);
    //            }
    //            // ���i�}�X�^(��)���[�J�[�N���X��UI�N���XStatic�]�L����
    //            CopyToStaticFromWorker(ar);
    //        }
    //        else
    //        {
    //            return status;
    //        }
    //        // 2008.02.29 96012 �񋟕��̓��[�J���c�a�ւ̃A�N�Z�X�̂� end

    //        /*
    //        // Static����K�C�h�\���i�I��/�I�t���ʁj	
    //        foreach (AlTtlBlockSt alttlblockstWk in _alttlblockstTable_Stc.Values)
    //        {
    //            // ArrayList�փ����o�R�s�[
    //            if (belongSectionCode.Trim() == "")
    //            {
    //                // �S�Е\��
    //                ar.Add(alttlblockstWk.Clone());
    //            }
    //        }
    //        */

    //        ArrayList wkList = ar.Clone() as ArrayList;
    //        SortedList wkSort = new SortedList();

    //        // --- [�S��] --- //
    //        // ���̂܂ܑS���Ԃ�
    //        foreach (OfrGoodsPrice wkOfrGoodsPrice in wkList)
    //        {
    //            if (wkOfrGoodsPrice.LogicalDeleteCode == 0)
    //            {
    //                string strkey = string.Format("000000", wkOfrGoodsPrice.GoodsMakerCd) + wkOfrGoodsPrice.GoodsNo + string.Format("00", wkOfrGoodsPrice.PriceDivCd);
    //                wkSort.Add(strkey, wkOfrGoodsPrice);
    //            }
    //        }

    //        OfrGoodsPrice[] ofrgoodsprices = new OfrGoodsPrice[wkSort.Count];

    //        // �f�[�^�����ɖ߂�
    //        for (int i = 0; i < wkSort.Count; i++)
    //        {
    //            ofrgoodsprices[i] = (OfrGoodsPrice)wkSort.GetByIndex(i);
    //        }

    //        byte[] retbyte = XmlByteSerializer.Serialize(ofrgoodsprices);
    //        XmlByteSerializer.ReadXml(ref ds, retbyte);

    //        return status;
    //    }

    //    /// <summary>
    //    /// �N���X�����o�[�R�s�[����(���i�}�X�^(��)���[�N�N���X�ˉ��i�}�X�^(��)�N���X)
    //    /// </summary>
    //    /// <param name="ofrgoodspricework">���i�}�X�^(��)���[�N�N���X</param>
    //    /// <returns>���i�}�X�^(��)�N���X</returns>
    //    /// <remarks>
    //    /// <br>Note       : ���i�}�X�^(��)�}�X�^���[�N�N���X���牿�i�}�X�^(��)�N���X�փ����o�[�̃R�s�[���s���܂��B�i���C�A�E�g���̂݁j</br>
    //    /// <br>Programmer : 20056 ���n ���</br>
    //    /// <br>Date       : 2007.08.13</br>
    //    /// </remarks>
    //    public static OfrGoodsPrice CopyToOfrGoodsPrice(OfrGoodsPriceWork ofrgoodspricework)
    //    {
    //        OfrGoodsPrice ofrgoodsprice = new OfrGoodsPrice();

    //        ofrgoodsprice.CreateDateTime = ofrgoodspricework.CreateDateTime;
    //        ofrgoodsprice.UpdateDateTime = ofrgoodspricework.UpdateDateTime;
    //        ofrgoodsprice.LogicalDeleteCode = ofrgoodspricework.LogicalDeleteCode;

    //        ofrgoodsprice.GoodsMakerCd = ofrgoodspricework.GoodsMakerCd;
    //        ofrgoodsprice.GoodsNo = ofrgoodspricework.GoodsNo;
    //        ofrgoodsprice.NewPrice = ofrgoodspricework.NewPrice;
    //        ofrgoodsprice.NewPriceStartDate = ofrgoodspricework.NewPriceStartDate;
    //        ofrgoodsprice.OfferDate = ofrgoodspricework.OfferDate;
    //        ofrgoodsprice.OldPrice = ofrgoodspricework.OldPrice;
    //        ofrgoodsprice.OpenPriceDiv = ofrgoodspricework.OpenPriceDiv;
    //        ofrgoodsprice.PriceDivCd = ofrgoodspricework.PriceDivCd;

    //        return ofrgoodsprice;
    //    }

    //    /// <summary>
    //    /// ���i�}�X�^(��)�e�[�u���쐬����
    //    /// </summary>
    //    /// <param name="GoodsPriceTable"></param>
    //    /// <param name="goodsPriceTable"></param>
    //    /// <param name="retList"></param>
    //    public void MakeHashTableFromOfrGoodsPrice(out Hashtable GoodsPriceTable, Hashtable goodsPriceTable, ArrayList retList)
    //    {
    //        string HasyKey = "";
    //        Hashtable hashTable = new Hashtable();
    //        foreach (OfrGoodsPrice ofrgoodsprice in retList)
    //        {
    //            HasyKey = ofrgoodsprice.PriceDivCd.ToString("00");
    //            if (!goodsPriceTable.Contains(HasyKey))
    //            {
    //                GoodsPrice goodsprice = new GoodsPrice();

    //                goodsprice.CreateDateTime = ofrgoodsprice.CreateDateTime; // �쐬����
    //                goodsprice.UpdateDateTime = ofrgoodsprice.UpdateDateTime; // �X�V����
    //                //goodsprice.EnterpriseCode = ofrgoodsprice.EnterpriseCode; // ��ƃR�[�h
    //                //goodsprice.FileHeaderGuid = ofrgoodsprice.FileHeaderGuid; // GUID
    //                //goodsprice.UpdEmployeeCode = ofrgoodsprice.UpdEmployeeCode; // �X�V�]�ƈ��R�[�h
    //                //goodsprice.UpdAssemblyId1 = ofrgoodsprice.UpdAssemblyId1; // �X�V�A�Z���u��ID1
    //                //goodsprice.UpdAssemblyId2 = ofrgoodsprice.UpdAssemblyId2; // �X�V�A�Z���u��ID2
    //                goodsprice.LogicalDeleteCode = ofrgoodsprice.LogicalDeleteCode; // �_���폜�敪
    //                goodsprice.GoodsMakerCd = ofrgoodsprice.GoodsMakerCd; // ���i���[�J�[�R�[�h
    //                goodsprice.GoodsNo = ofrgoodsprice.GoodsNo; // ���i�ԍ�
    //                //goodsprice.PriceStartDate = ofrgoodsprice.PriceStartDate; // ���i�J�n��
    //                //goodsprice.ListPrice = ofrgoodsprice.ListPrice; // �艿�i�����j
    //                //goodsprice.SalesUnitCost = ofrgoodsprice.SalesUnitCost; // �����P��
    //                //goodsprice.StockRate = ofrgoodsprice.StockRate; // �d����
    //                goodsprice.OpenPriceDiv = ofrgoodsprice.OpenPriceDiv; // �I�[�v�����i�敪
    //                goodsprice.OfferDate = ofrgoodsprice.OfferDate; // �񋟓��t
    //                //goodsprice.UpdateDate = ofrgoodsprice.UpdateDate; // �X�V�N����

    //                hashTable[HasyKey] = goodsprice;
    //            }
    //        }
    //        GoodsPriceTable = hashTable;

    //    }

    //    #region ���}�X����UI�N���X�p�Q�Ə���
    //    /// <summary>
    //    /// ���_���̎擾����
    //    /// </summary>
    //    /// <param name="enterpriseCode">��ƃR�[�h</param>
    //    /// <param name="sectionCode">���_�R�[�h</param>
    //    /// <returns>���_����</returns>
    //    /// <remarks>
    //    /// <br>Note       : ���_���̂�Ԃ��܂��B</br>
    //    /// <br>Programmer : 20056 ���n ���</br>
    //    /// <br>Date       : 2007.08.01</br>
    //    /// </remarks>
    //    public string GetSectionName(string enterpriseCode, string sectionCode)
    //    {
    //        return "���o�^";
    //    }
    //    #endregion

    //    #endregion

    //    #region ��Private Method
    //    /// <summary>
    //    /// ���i�}�X�^(��)��������
    //    /// </summary>
    //    /// <param name="retList">�Ǎ����ʃR���N�V����</param>
    //    /// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������</param>
    //    /// <param name="nextData">���f�[�^�L��</param>
    //    /// <param name="enterpriseCode">��ƃR�[�h</param>
    //    /// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�S�f�[�^)</param>
    //    /// <param name="readCnt">�Ǎ�����</param>
    //    /// <param name="prevOfrGoodsPriceSt">�O��ŏI�S���҃f�[�^�I�u�W�F�N�g</param>
    //    /// <returns>STATUS</returns>
    //    /// <remarks>
    //    /// <br>Note       : ���i�}�X�^(��)�̌����������s���܂��B</br>
    //    /// <br>Programmer : 20056 ���n ���</br>
    //    /// <br>Date       : 2007.08.13</br>
    //    /// <br>UpdateNote : 2008.02.29 96012�@���F �]</br>
    //    /// <br>           : �񋟕��̓��[�J���c�a�ւ̃A�N�Z�X�̂�</br>
    //    /// </remarks>
    //    private int SearchProc(out ArrayList retList, out int retTotalCnt, out bool nextData, object objParaList, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, OfrGoodsPrice prevOfrGoodsPriceSt)
    //    {
    //        OfrGoodsPriceWork ofrgoodspriceWork = new OfrGoodsPriceWork();
    //        if (prevOfrGoodsPriceSt != null) ofrgoodspriceWork = CopyToOfrGoodsPriceWorkFromOfrGoodsPrice(prevOfrGoodsPriceSt);
    //        //alttlblockstWork.EnterpriseCode = enterpriseCode;

    //        int status;

    //        //���f�[�^�L��������
    //        nextData = false;
    //        //0�ŏ�����
    //        retTotalCnt = 0;

    //        retList = new ArrayList();
    //        retList.Clear();
    //        ArrayList paraList = new ArrayList();

    //        // �I�t���C���̏ꍇ�̓L���b�V������ǂ�
    //        if (!LoginInfoAcquisition.OnlineFlag)
    //        {
    //            status = SearchStaticMemory(out retList, objParaList, enterpriseCode);
    //        }
    //        else
    //        {
    //            OfrGoodsPrice ofrgoodsprice = new OfrGoodsPrice();
    //            object objectOfrGoodsPriceWork = null;

    //            // ���i�}�X�^(��)����
    //            // �����[�g 
    //            // 2008.02.29 96012 �񋟕��̓��[�J���c�a�ւ̃A�N�Z�X�̂� Begin
    //            //status = this._iOfrGoodsPriceDB.Search(out objectOfrGoodsPriceWork, objParaList, 0, logicalMode);
    //            List<OfrGoodsPriceWork> workList = new List<OfrGoodsPriceWork>();
    //            status = this._ofrGoodsPriceLcDB.Search(out workList, ofrgoodspriceWork, 0, logicalMode);
    //            if (status == 0)
    //            {
    //                ArrayList ar = new ArrayList();
    //                for (int i = 0; i < workList.Count; ++i)
    //                {
    //                    ar.Add(workList[i]);
    //                }
    //                objectOfrGoodsPriceWork = ar;
    //            }
    //            // 2008.02.29 96012 �񋟕��̓��[�J���c�a�ւ̃A�N�Z�X�̂� end

    //            if (status == 0)
    //            {
    //                // ���i�}�X�^(��)���[�J�[�N���X��UI�N���XStatic�]�L����
    //                CopyToStaticFromWorker(objectOfrGoodsPriceWork as ArrayList);

    //                // �p�����[�^���n���ė��Ă��邩�m�F
    //                paraList = objectOfrGoodsPriceWork as ArrayList;
    //                OfrGoodsPriceWork[] wkOfrGoodsPriceWork = new OfrGoodsPriceWork[paraList.Count];

    //                // �f�[�^�����ɖ߂�
    //                for (int i = 0; i < paraList.Count; i++)
    //                {
    //                    wkOfrGoodsPriceWork[i] = (OfrGoodsPriceWork)paraList[i];
    //                }
    //                for (int i = 0; i < wkOfrGoodsPriceWork.Length; i++)
    //                {
    //                    ofrgoodsprice = CopyToOfrGoodsPriceFormOfrGoodsPriceWork(wkOfrGoodsPriceWork[i]);
    //                    // �T�[�`���ʎ擾
    //                    retList.Add(ofrgoodsprice);
    //                    // �X�^�e�B�b�N�X�V
    //                    string strkey = string.Format("000000", ofrgoodsprice.GoodsMakerCd) + ofrgoodsprice.GoodsNo + string.Format("00", ofrgoodsprice.PriceDivCd);
    //                    _ofrgoodspriceTable_Stc[strkey] = ofrgoodsprice;
    //                }
    //            }
    //        }
    //        //�S�����[�h�̏ꍇ�͖߂�l�̌������Z�b�g
    //        if (readCnt == 0) retTotalCnt = retList.Count;

    //        return status;
    //    }

    //    /// <summary>
    //    /// �N���X�����o�[�R�s�[�����i���i�}�X�^(��)���[�N�N���X�ˉ��i�}�X�^(��)�N���X�j
    //    /// </summary>
    //    /// <param name="ofrgoodspricework">���i�}�X�^(��)���[�N�N���X</param>
    //    /// <returns>���i�}�X�^(��)�N���X</returns>
    //    /// <remarks>
    //    /// <br>Note       : ���i�}�X�^(��)���[�N�N���X���牿�i�}�X�^(��)�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
    //    /// <br>		    : ���������ɒǉ������v���p�e�B�����Z�b�g���܂��B</br>
    //    /// <br>Programmer : 20056 ���n ���</br>
    //    /// <br>Date       : 2007.08.13</br>
    //    /// </remarks>
    //    private OfrGoodsPrice CopyToOfrGoodsPriceFormOfrGoodsPriceWork(OfrGoodsPriceWork ofrgoodspricework)
    //    {
    //        OfrGoodsPrice ofrgoodsprice = new OfrGoodsPrice();

    //        ofrgoodsprice = CopyToOfrGoodsPrice(ofrgoodspricework);

    //        return ofrgoodsprice;
    //    }

    //    /// <summary>
    //    /// �N���X�����o�[�R�s�[�����i���i�}�X�^(��)�N���X�ˉ��i�}�X�^(��)���[�N�N���X�j
    //    /// </summary>
    //    /// <param name="ofrgoodsprice">���i�}�X�^(��)���[�N�N���X</param>
    //    /// <returns>���i�}�X�^(��)�N���X</returns>
    //    /// <remarks>
    //    /// <br>Note       : ���i�}�X�^(��)�N���X���牿�i�}�X�^(��)�}�X�^���[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
    //    /// <br>Programmer : 20056 ���n ���</br>
    //    /// <br>Date       : 2007.08.13</br>
    //    /// </remarks>
    //    private OfrGoodsPriceWork CopyToOfrGoodsPriceWorkFromOfrGoodsPrice(OfrGoodsPrice ofrgoodsprice)
    //    {
    //        OfrGoodsPriceWork ofrgoodspricework = new OfrGoodsPriceWork();

    //        ofrgoodspricework.CreateDateTime = ofrgoodsprice.CreateDateTime;
    //        ofrgoodspricework.UpdateDateTime = ofrgoodsprice.UpdateDateTime;
    //        ofrgoodspricework.LogicalDeleteCode = ofrgoodsprice.LogicalDeleteCode;

    //        ofrgoodspricework.GoodsMakerCd = ofrgoodsprice.GoodsMakerCd;
    //        ofrgoodspricework.GoodsNo = ofrgoodsprice.GoodsNo;
    //        ofrgoodspricework.NewPrice = ofrgoodsprice.NewPrice;
    //        ofrgoodspricework.NewPriceStartDate = ofrgoodsprice.NewPriceStartDate;
    //        ofrgoodspricework.OfferDate = ofrgoodsprice.OfferDate;
    //        ofrgoodspricework.OldPrice = ofrgoodsprice.OldPrice;
    //        ofrgoodspricework.OpenPriceDiv = ofrgoodsprice.OpenPriceDiv;
    //        ofrgoodspricework.PriceDivCd = ofrgoodsprice.PriceDivCd;

    //        return ofrgoodspricework;
    //    }

    //    /// <summary>
    //    /// ��������������
    //    /// </summary>
    //    /// <remarks>
    //    /// <br>Note       : ���i�}�X�^(��)�ݒ�A�N�Z�X�N���X���ێ����郁�����𐶐����܂��B</br>
    //    /// <br>Programer  : 20056 ���n ���</br>
    //    /// <br>Date       : 2007.08.13</br>
    //    /// </remarks>
    //    private void MemoryCreate()
    //    {

    //        // ���i�}�X�^(��)�}�X�^�N���XStatic
    //        if (_ofrgoodspriceTable_Stc == null)
    //        {
    //            _ofrgoodspriceTable_Stc = new Hashtable();
    //        }

    //    }

    //    /// <summary>
    //    /// ���i�}�X�^(��)�N���X���[�J�[�N���X(List) �� UI�N���X�ϊ�����
    //    /// </summary>
    //    /// <param name="ofrgoodspriceWorkList"></param>
    //    /// <remarks>
    //    /// <br>Note       : ���i�}�X�^(��)�u���[�J�[�N���X��UI�̕��ʕ��i�N���X�ɕϊ����āA
    //    ///					 Search�pStatic�������ɕێ����܂��B</br>
    //    /// <br>Programer  : 20056 ���n ���</br>
    //    /// <br>Date       : 2007.08.13</br>
    //    /// </remarks>
    //    private void CopyToStaticFromWorker(List<OfrGoodsPriceWork> ofrgoodspriceWorkList)
    //    {
    //        ArrayList ofrgoodspriceWorkArray = new ArrayList();
    //        ofrgoodspriceWorkArray.AddRange(ofrgoodspriceWorkList);

    //        CopyToStaticFromWorker(ofrgoodspriceWorkArray);
    //    }

    //    /// <summary>
    //    /// ���i�}�X�^(��)�N���X���[�J�[�N���X(ArrayList) �� UI�N���X�ϊ�����
    //    /// </summary>
    //    /// <param name="ofrgoodspriceWorkList"></param>
    //    /// <remarks>
    //    /// <br>Note       : ���i�}�X�^(��)���[�J�[�N���X��UI�̕��ʕ��i�N���X�ɕϊ����āA
    //    ///					 Search�pStatic�������ɕێ����܂��B</br>
    //    /// <br>Programer  : 20056 ���n ���</br>
    //    /// <br>Date       : 2007.08.13</br>
    //    /// </remarks>
    //    private void CopyToStaticFromWorker(ArrayList ofrgoodspriceWorkList)
    //    {
    //        string hashKey;
    //        foreach (OfrGoodsPriceWork wkOfrGoodsPriceWork in ofrgoodspriceWorkList)
    //        {
    //            OfrGoodsPrice wkOfrGoodsPrice = new OfrGoodsPrice();

    //            // HashKey:���i�敪
    //            hashKey = string.Format("00", wkOfrGoodsPriceWork.PriceDivCd);

    //            wkOfrGoodsPrice.CreateDateTime = wkOfrGoodsPriceWork.CreateDateTime;
    //            wkOfrGoodsPrice.UpdateDateTime = wkOfrGoodsPriceWork.UpdateDateTime;
    //            wkOfrGoodsPrice.LogicalDeleteCode = wkOfrGoodsPriceWork.LogicalDeleteCode;

    //            wkOfrGoodsPrice.GoodsMakerCd = wkOfrGoodsPriceWork.GoodsMakerCd;
    //            wkOfrGoodsPrice.GoodsNo = wkOfrGoodsPriceWork.GoodsNo;
    //            wkOfrGoodsPrice.NewPrice = wkOfrGoodsPriceWork.NewPrice;
    //            wkOfrGoodsPrice.NewPriceStartDate = wkOfrGoodsPriceWork.NewPriceStartDate;
    //            wkOfrGoodsPrice.OfferDate = wkOfrGoodsPriceWork.OfferDate;
    //            wkOfrGoodsPrice.OldPrice = wkOfrGoodsPriceWork.OldPrice;
    //            wkOfrGoodsPrice.OpenPriceDiv = wkOfrGoodsPriceWork.OpenPriceDiv;
    //            wkOfrGoodsPrice.PriceDivCd = wkOfrGoodsPriceWork.PriceDivCd;

    //            _ofrgoodspriceTable_Stc[hashKey] = wkOfrGoodsPrice;
    //        }
    //    }

    //    /// <summary>
    //    /// ���[�J���t�@�C���Ǎ��ݏ���
    //    /// </summary>
    //    /// <remarks>
    //    /// <br>Note       : ���[�J���t�@�C����Ǎ���ŁA����Static�ɕێ����܂��B</br>
    //    /// <br>Programer  : 20056 ���n ���</br>
    //    /// <br>Date       : 2007.08.13</br>
    //    /// </remarks>
    //    private void SearchOfflineData()
    //    {
    //        // �I�t���C���V���A���C�Y�f�[�^�쐬���iI/O
    //        OfflineDataSerializer offlineDataSerializer = new OfflineDataSerializer();

    //        // --- Search�p --- //
    //        // KeyList�ݒ�
    //        string[] ofrgoodspriceKeys = new string[1];
    //        ofrgoodspriceKeys[0] = LoginInfoAcquisition.EnterpriseCode;
    //        // ���[�J���t�@�C���Ǎ��ݏ���
    //        object wkObj = offlineDataSerializer.DeSerialize("OfrGoddsPriceAcs", ofrgoodspriceKeys);
    //        // ArrayList�ɃZ�b�g
    //        List<OfrGoodsPriceWork> wkList = new List<OfrGoodsPriceWork>();

    //        if ((wkList != null) &&
    //            (wkList.Count != 0))
    //        {
    //            // ���i�}�X�^(��)�N���X���[�J�[�N���X�iArrayList�j �� UI�N���X�iStatic�j�ϊ�����
    //            CopyToStaticFromWorker(wkList);
    //        }
    //    }
    //    #endregion
    //}

    ///// <summary>
    ///// ���i�}�X�^(���[�U�[�o�^��) �e�[�u���A�N�Z�X�N���X
    ///// </summary>
    ///// <remarks>
    ///// -----------------------------------------------------------------------------------
    ///// <br>Note		: ���i�}�X�^(���[�U�[�o�^��) �e�[�u���̃A�N�Z�X������s���܂��B</br>
    ///// <br>Programmer	: 20056 ���n ���</br>
    ///// <br>Date		: 2007.08.13</br>
    ///// -----------------------------------------------------------------------
    ///// <br>UpdateNote : 2008.02.19 96012�@���F �]</br>
    ///// <br>           : ���[�J���c�a�Q�ƑΉ�</br>
    ///// </remarks>
    //public class GoodsPriceUAcs
    //{
    //    # region ��Private Member
    //    /// <summary>�����[�g�I�u�W�F�N�g�i�[�o�b�t�@</summary>
    //    private IGoodsPriceUDB _iGoodsPriceUDB = null;
    //    // 2008.02.19 96012 ���[�J���c�a�Q�ƑΉ� Begin
    //    private GoodsPriceULcDB _goodsPriceULcDB = null;
    //    // 2008.02.19 96012 ���[�J���c�a�Q�ƑΉ� end

    //    /// <summary>���i�}�X�^(���[�U�[�o�^��) �N���XStatic</summary>
    //    private static List<GoodsPriceU> _goodsPriceUList_Stc = null;
    //    /// <summary>���i�}�X�^�N���XSearch�t���O</summary>
    //    private static bool _searchFlg;

    //    /// <summary>���[�J���c�a���[�h</summary>
    //    // 2008.02.19 96012 ���[�J���c�a�Q�ƑΉ� Begin
    //    //private static bool _isLocalDBRead = true;
    //    private static bool _isLocalDBRead = false;
    //    // 2008.02.19 96012 ���[�J���c�a�Q�ƑΉ� end

    //    /// <summary>���[�U�[�K�C�h�}�X�^ �A�N�Z�X�N���X</summary>
    //    private UserGuideAcs _userGuideAcs;

    //    /// <summary>���[�U�[�K�C�h�}�X�^</summary>
    //    private static ArrayList _userGdBdPriceDivCd = null;
    //    private static ArrayList _userGdBdUnitCode = null;
    //    private static ArrayList _userGdBdEnterpriseGanreCode = null;

    //    private const string GUIDE_SEARCHMODE_PARA = "SearchMode";                     // �K�C�h�f�[�^�T�[�`���[�h(0:���[�J��,1:�����[�g) iitani a 2007.05.07
    //    # endregion

    //    # region ��Constracter
    //    /// <summary>
    //    /// ���i�}�X�^(���[�U�[�o�^��) �e�[�u���A�N�Z�X�N���X�R���X�g���N�^
    //    /// </summary>
    //    /// <remarks>
    //    /// <br>Note       : ���i�}�X�^ �e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
    //    /// <br>Programmer : 20056 ���n ���</br>
    //    /// <br>Date       : 2007.08.13</br>
    //    /// -----------------------------------------------------------------------
    //    /// <br>UpdateNote : 2008.02.19 96012�@���F �]</br>
    //    /// <br>           : ���[�J���c�a�Q�ƑΉ�</br>
    //    /// </remarks>
    //    public GoodsPriceUAcs()
    //    {
    //        // ��������������
    //        MemoryCreate();

    //        // ���O�C�����i�ŒʐM��Ԃ��m�F
    //        if (LoginInfoAcquisition.OnlineFlag)
    //        {
    //            try
    //            {
    //                // �����[�g�I�u�W�F�N�g�擾
    //                this._iGoodsPriceUDB = (IGoodsPriceUDB)MediationGoodsPriceUDB.GetGoodsPriceUDB();
    //            }
    //            catch (Exception)
    //            {
    //                //�I�t���C������null���Z�b�g
    //                this._iGoodsPriceUDB = null;
    //            }
    //        }
    //        else
    //        {
    //            // �I�t���C�����̃f�[�^�ǂݍ���
    //            this.SearchOfflineData();
    //        }
    //        // 2008.02.19 96012 ���[�J���c�a�Q�ƑΉ� Begin
    //        // ���i���i�}�X�^���[�J���I�u�W�F�N�g�擾
    //        this._goodsPriceULcDB = new GoodsPriceULcDB();
    //        // 2008.02.19 96012 ���[�J���c�a�Q�ƑΉ� end

    //        this._userGuideAcs = new UserGuideAcs();
            
    //    }
    //    # endregion

    //    //================================================================================
    //    //  �v���p�e�B
    //    //================================================================================
    //    #region Public Property

    //    /// <summary>
    //    /// ���[�J���c�aRead���[�h
    //    /// </summary>
    //    public bool IsLocalDBRead
    //    {
    //        get { return _isLocalDBRead; }
    //        set { _isLocalDBRead = value; }
    //    }

    //    public static ArrayList UserGdBdPriceDivCd
    //    {
    //        get { return _userGdBdPriceDivCd; }
    //        set { _userGdBdPriceDivCd = value; }
    //    }
    //    public static ArrayList UserGdBdUnitCode
    //    {
    //        get { return _userGdBdUnitCode; }
    //        set { _userGdBdUnitCode = value; }
    //    }
    //    public static ArrayList UserGdBdEnterpriseGanreCode
    //    {
    //        get { return _userGdBdEnterpriseGanreCode; }
    //        set { _userGdBdEnterpriseGanreCode = value; }
    //    }
    //    #endregion

    //    # region ��public int GetOnlineMode()
    //    /// <summary>
    //    /// �I�����C�����[�h�擾����
    //    /// </summary>
    //    /// <returns>OnlineMode</returns>
    //    /// <remarks>
    //    /// <br>Note       : �I�����C�����[�h���擾���܂��B</br>
    //    /// <br>Programmer : 20056 ���n ���</br>
    //    /// <br>Date       : 2007.08.01</br>
    //    /// </remarks>
    //    public int GetOnlineMode()
    //    {
    //        if (this._iGoodsPriceUDB == null)
    //        {
    //            return (int)ConstantManagement.OnlineMode.Offline;
    //        }
    //        else
    //        {
    //            return (int)ConstantManagement.OnlineMode.Online;
    //        }
    //    }
    //    # endregion

    //    #region ��Public Method
    //    /// <summary>
    //    /// ���i�}�X�^(���[�U�[�o�^��) �}�X�^Static�������S���擾����
    //    /// </summary>
    //    /// <param name="retList">���i�}�X�^ �N���XList</param>
    //    /// <returns>�X�e�[�^�X(0:����I��, -1:�G���[, 9:�f�[�^����)</returns>
    //    /// <param name="enterpriseCode">��ƃR�[�h</param>
    //    /// <remarks>
    //    /// <br>Note       : ���i�}�X�^ �}�X�^Static�������̑S�����擾���܂��B</br>
    //    /// <br>Programer  : 20056 ���n ���</br>
    //    /// <br>Date       : 2007.08.13</br>
    //    /// </remarks>
    //    public int SearchStaticMemory(out ArrayList retList, object objParaList, string enterpriseCode)
    //    {
    //        retList = new ArrayList();
    //        retList.Clear();
    //        SortedList sortedList = new SortedList();

    //        if ((_goodsPriceUList_Stc == null) ||
    //            (_goodsPriceUList_Stc.Count == 0))
    //        {
    //            this.SearchAll(out retList,  objParaList, enterpriseCode);
    //            return 0;
    //        }
    //        else if (_goodsPriceUList_Stc.Count == 0)
    //        {
    //            return 9;
    //        }

    //        foreach (GoodsPriceU goodsPriceU in _goodsPriceUList_Stc.Values)
    //        {
    //            string strkey = string.Format("000000", goodsPriceU.GoodsMakerCd) + goodsPriceU.GoodsNo + string.Format("00000000000000", goodsPriceU.PriceStartDate.Ticks);
    //            sortedList.Add(strkey, goodsPriceU);
    //        }

    //        retList.AddRange(sortedList.Values);

    //        return 0;
    //    }

    //    /// <summary>
    //    /// ���i�}�X�^(���[�U�[�o�^��)�@�}�X�^Static�������擾����
    //    /// </summary>
    //    /// <param name="alttlblockstrf"></param>
    //    /// <param name="enterpriseCodeRF"></param>
    //    /// <param name="alTtlBlockCodeRF"></param>
    //    /// <returns></returns>
    //    public int ReadStaticMemory(out GoodsPriceU goodspriceurf, object objParaList, string enterpriseCodeRF, int goodsMakerCdRF, string goodsNoRF, int priceDivCdRF)
    //    {
    //        goodspriceurf = new GoodsPriceU();

    //        if ((_goodsPriceUList_Stc == null) ||
    //            (_goodsPriceUList_Stc.Count == 0))
    //        {
    //            ArrayList goodspriceuList = new ArrayList();
    //            this.SearchAll(out goodspriceuList,  objParaList, enterpriseCodeRF);
    //        }

    //        // Static���猟��
    //        string strkey = string.Format("000000", goodsMakerCdRF) + goodsNoRF + string.Format("00", priceDivCdRF);
    //        if (_goodsPriceUList_Stc[strkey] == null)
    //        {
    //            return 4;
    //        }
    //        else 
    //        {
    //            goodspriceurf = (GoodsPriceU)_goodsPriceUList_Stc[strkey];
    //        }

    //        return 0;

    //    }

    //    /// <summary>
    //    /// ���i�}�X�^(���[�U�[�o�^��) Static���������I�t���C���������ݏ���
    //    /// </summary>
    //    /// <param name="sender">object�i�ďo���I�u�W�F�N�g�j</param>
    //    /// <returns>STATUS</returns>
    //    /// <remarks>
    //    /// <br>Note       : ���i�}�X�^(���[�U�[�o�^��) Static�������̏������[�J���t�@�C���ɕۑ����܂��B</br>
    //    /// <br>Programer  : 20056 ���n ���</br>
    //    /// <br>Date       : 2007.08.13</br>
    //    /// </remarks>
    //    public int WriteOfflineData(object sender)
    //    {
    //        // �I�t���C���V���A���C�Y�f�[�^�쐬���iI/O
    //        OfflineDataSerializer offlineDataSerializer = new OfflineDataSerializer();
    //        int status;

    //        // KeyList�ݒ�
    //        string[] goodspriceuKeys = new string[1];
    //        goodspriceuKeys[0] = LoginInfoAcquisition.EnterpriseCode;

    //        SortedList sortedList = new SortedList();

    //        GoodsPriceUWork goodspriceuWork = new GoodsPriceUWork();
    //        foreach (GoodsPriceU goodspriceu in _goodsPriceUList_Stc.Values)
    //        {
    //            // �N���X�˃��[�J�[�N���X
    //            goodspriceuWork = CopyToGoodsPriceUWorkFromGoodsPriceU(goodspriceu);
                
    //            // �\�[�g
    //            string strkey = string.Format("000000", goodspriceu.GoodsMakerCd) + goodspriceu.GoodsNo + string.Format("00000000000000", goodspriceu.PriceStartDate.Ticks);
    //            sortedList.Add(strkey, goodspriceuWork);
    //        }

    //        ArrayList goodspriceuWorkList = new ArrayList();
    //        goodspriceuWorkList.AddRange(sortedList.Values);
    //        status = offlineDataSerializer.Serialize("GoodsPriceUAcs", goodspriceuKeys, goodspriceuWorkList);

    //        return status;
    //    }

    //    /// <summary>
    //    /// ���i�}�X�^(���[�U�[�o�^)�ǂݍ��ݏ���
    //    /// </summary>
    //    /// <param name="goodspriceu">���i�}�X�^(���[�U�[�o�^)�I�u�W�F�N�g</param>
    //    /// <param name="enterpriseCode">��ƃR�[�h</param>
    //    /// <param name="goodsmakercd">���i���[�J�[�R�[�h</param>
    //    /// <param name="goodsno">���i�ԍ�</param>
    //    /// <returns></returns>
    //    /// <remarks>
    //    /// <br>Note       : ���i�}�X�^(���[�U�[�o�^)����ǂݍ��݂܂��B</br>
    //    /// <br>Programmer : 20056 ���n ���</br>
    //    /// <br>Date       : 2007.08.01</br>
    //    /// -----------------------------------------------------------------------
    //    /// <br>UpdateNote : 2008.02.19 96012�@���F �]</br>
    //    /// <br>           : ���[�J���c�a�Q�ƑΉ�</br>
    //    /// </remarks>
    //    public int Read(out GoodsPriceU goodspriceu, string enterpriseCode, int goodsmakercd, string goodsno)
    //    {
    //        try
    //        {
    //            int status;
    //            goodspriceu = null;
    //            GoodsPriceUWork goodspriceuWork = new GoodsPriceUWork();

    //            goodspriceuWork.EnterpriseCode = enterpriseCode;
    //            goodspriceuWork.GoodsMakerCd = goodsmakercd;
    //            goodspriceuWork.GoodsNo = goodsno;

    //            byte[] parabyte = null;

    //            // �����[�g
    //            // 2008.02.19 96012 ���[�J���c�a�Q�ƑΉ� Begin
    //            //parabyte = XmlByteSerializer.Serialize(goodspriceuWork);
    //            //status = this._iGoodsPriceUDB.Read(ref parabyte, 0);
    //            //if (status == 0)
    //            //{
    //            //    goodspriceuWork = (GoodsPriceUWork)XmlByteSerializer.Deserialize(parabyte, typeof(GoodsPriceUWork));
    //            //}
    //            //
    //            //if (status == 0)
    //            //{
    //            //    // �N���X�������o�R�s�[
    //            //    goodspriceu = CopyToGoodsPriceUFormGoodsPriceUWork(goodspriceuWork);
    //            //    // Read�pStatic�ɕێ�
    //            //    string strkey = string.Format("000000", goodspriceu.GoodsMakerCd) + goodspriceu.GoodsNo + string.Format("00", goodspriceu.PriceDivCd);
    //            //    _goodspriceuTable_Stc[strkey] = goodspriceu;
    //            //}
    //            if (_isLocalDBRead)
    //            {
    //                status = this._goodsPriceULcDB.Read(ref goodspriceuWork, 0);
    //                if (status == 0)
    //                {
    //                    goodspriceuWork = (GoodsPriceUWork)XmlByteSerializer.Deserialize(parabyte, typeof(GoodsPriceUWork));
    //                }
    //                if (status == 0)
    //                {
    //                    // �N���X�������o�R�s�[
    //                    goodspriceu = CopyToGoodsPriceUFormGoodsPriceUWork(goodspriceuWork);
    //                    // Read�pStatic�ɕێ�
    //                    string strkey = string.Format("000000", goodspriceu.GoodsMakerCd) + goodspriceu.GoodsNo + string.Format("00000000000000", goodspriceu.PriceStartDate.Ticks);
    //                    _goodsPriceUList_Stc[strkey] = goodspriceu;
    //                }
    //            }
    //            else
    //            {
    //                parabyte = XmlByteSerializer.Serialize(goodspriceuWork);
    //                status = this._iGoodsPriceUDB.Read(ref parabyte, 0);
    //                if (status == 0)
    //                {
    //                    goodspriceuWork = (GoodsPriceUWork)XmlByteSerializer.Deserialize(parabyte, typeof(GoodsPriceUWork));
    //                }
    //                if (status == 0)
    //                {
    //                    // �N���X�������o�R�s�[
    //                    goodspriceu = CopyToGoodsPriceUFormGoodsPriceUWork(goodspriceuWork);
    //                    // Read�pStatic�ɕێ�
    //                    string strkey = string.Format("000000", goodspriceu.GoodsMakerCd) + goodspriceu.GoodsNo + string.Format("00000000000000", goodspriceu.PriceStartDate.Ticks);
    //                    _goodsPriceUList_Stc[strkey] = goodspriceu;
    //                }
    //            }
    //            // 2008.02.19 96012 ���[�J���c�a�Q�ƑΉ� end

    //            return status;
    //        }
    //        catch (Exception)
    //        {
    //            //�ʐM�G���[��-1��߂�
    //            goodspriceu = null;
    //            //�I�t���C������null���Z�b�g
    //            this._iGoodsPriceUDB = null;
    //            return -1;
    //        }
    //    }

    //    /// <summary>
    //    /// ���i�}�X�^(���[�U�[�o�^) �N���X�f�V���A���C�Y����
    //    /// </summary>
    //    /// <param name="fileName">�f�V���A���C�Y�Ώ�XML�t�@�C���t���p�X</param>
    //    /// <returns>���i�}�X�^(���[�U�[�o�^) �N���X</returns>
    //    /// <remarks>
    //    /// <br>Note       : ���i�}�X�^(���[�U�[�o�^) �N���X���f�V���A���C�Y���܂��B</br>
    //    /// <br>Programmer : 20056 ���n ���</br>
    //    /// <br>Date       : 2007.08.13</br>
    //    /// </remarks>
    //    public GoodsPriceU Deserialize(string fileName)
    //    {
    //        return null;
    //    }

    //    /// <summary>
    //    /// ���i�}�X�^(���[�U�[�o�^) List�N���X�f�V���A���C�Y����
    //    /// </summary>
    //    /// <param name="fileName">�f�V���A���C�Y�Ώ�XML�t�@�C���t���p�X</param>
    //    /// <returns>���i�}�X�^(���[�U�[�o�^) �N���XLIST</returns>
    //    /// <remarks>
    //    /// <br>Note       : ���i�}�X�^�}�X�^ ���X�g�N���X���f�V���A���C�Y���܂��B</br>
    //    /// <br>Programmer : 20056 ���n ���</br>
    //    /// <br>Date       : 2007.08.13</br>
    //    /// </remarks>
    //    public ArrayList ListDeserialize(string fileName)
    //    {
    //        ArrayList al = new ArrayList();

    //        // �t�@�C������n���ĉ��i�}�X�^(���[�U�[�o�^)���[�N�N���X���f�V���A���C�Y����
    //        GoodsPriceUWork[] goodspriceuWorks = (GoodsPriceUWork[])XmlByteSerializer.Deserialize(fileName, typeof(GoodsPriceUWork[]));
            
    //        //�f�V���A���C�Y���ʂ����i�}�X�^(���[�U�[�o�^)�N���X�փR�s�[
    //        if (goodspriceuWorks != null)
    //        {
    //            al.Capacity = goodspriceuWorks.Length;
    //            for (int i = 0; i < goodspriceuWorks.Length; i++)
    //            {
    //                al.Add(CopyToGoodsPriceUFormGoodsPriceUWork(goodspriceuWorks[i]));
    //            }
    //        }

    //        return al;
    //    }

    //    /// <summary>
    //    /// ���i�}�X�^(���[�U�[�o�^)�o�^�E�X�V
    //    /// </summary>
    //    /// <param name="goodspriceu">���i�}�X�^(���[�U�[�o�^)</param>
    //    /// <returns></returns>
    //    /// <remarks>
    //    /// <br>Note       : ���i�}�X�^(���[�U�[�o�^)���̓o�^�E�X�V���s���܂��B</br>
    //    /// <br>Programmer : 20056 ���n ���</br>
    //    /// <br>Date       : 2007.08.01</br>
    //    /// </remarks>
    //    public int Write(ref GoodsPriceU goodspriceu)
    //    {
    //        //���i�}�X�^(���[�U�[�o�^)���牿�i�}�X�^���[�J�[�N���X�Ƀ����o�R�s�[
    //        GoodsPriceUWork goodspriceuWork = CopyToGoodsPriceUWorkFromGoodsPriceU(goodspriceu);
    //        ArrayList al = new ArrayList();

    //        object parabyte = (object)goodspriceuWork;
    //        object errobj = null;

    //        int status = 0;
    //        try
    //        {
    //            //���i�}�X�^(���[�U�[�o�^)��������
    //            status = this._iGoodsPriceUDB.Write(ref parabyte, out errobj);
    //            if (status == 0)
    //            {
    //                al = (ArrayList)parabyte;
    //                goodspriceuWork = (GoodsPriceUWork)al[0];

    //                // �N���X�������o�R�s�[
    //                goodspriceu = CopyToGoodsPriceUFormGoodsPriceUWork(goodspriceuWork);
    //                // Static�f�[�^�X�V
    //                string strkey = string.Format("000000", goodspriceu.GoodsMakerCd) + goodspriceu.GoodsNo + string.Format("00000000000000", goodspriceu.PriceStartDate.Ticks);
    //                _goodsPriceUList_Stc[strkey] = goodspriceu;
    //            }

    //        }
    //        catch (Exception)
    //        {
    //            //�I�t���C������null���Z�b�g
    //            this._iGoodsPriceUDB = null;
    //            //�ʐM�G���[��-1��߂�
    //            status = -1;
    //        }

    //        return status;
    //    }

    //    /// <summary>
    //    /// ���i�}�X�^(���[�U�[�o�^)�o�^�E�X�V(���X�g)
    //    /// </summary>
    //    /// <param name="goodspriceuList">���i�}�X�^(���[�U�[�o�^)</param>
    //    /// <returns></returns>
    //    /// <remarks>
    //    /// <br>Note       : ���i�}�X�^(���[�U�[�o�^)���̓o�^�E�X�V���s���܂��B</br>
    //    /// <br>Programmer : 20056 ���n ���</br>
    //    /// <br>Date       : 2007.08.01</br>
    //    /// </remarks>
    //    public int Write(ref ArrayList goodspriceuList)
    //    {
    //        //���i�}�X�^(���[�U�[�o�^)���牿�i�}�X�^���[�J�[�N���X�Ƀ����o�R�s�[
    //        ArrayList goodspriceuWorkList = CopyToGoodsPriceUWorkFromGoodsPriceUList(goodspriceuList);
    //        ArrayList al = new ArrayList();

    //        object parabyte = (object)goodspriceuWorkList;
    //        object errobj = null;

    //        int status = 0;
    //        try
    //        {
    //            //���i�}�X�^(���[�U�[�o�^)��������
    //            status = this._iGoodsPriceUDB.Write(ref parabyte, out errobj);
    //            if (status == 0)
    //            {

    //                al = (ArrayList)parabyte;
    //                GoodsPriceU goodspriceu = new GoodsPriceU();
    //                foreach (GoodsPriceUWork goodspriceuwork in al)
    //                {
    //                    goodspriceu = CopyToGoodsPriceUFormGoodsPriceUWork(goodspriceuwork);
    //                    goodspriceuList.Add(goodspriceu);


    //                    // Static�f�[�^�X�V
    //                    string strkey = string.Format("000000", goodspriceu.GoodsMakerCd) + goodspriceu.GoodsNo + string.Format("00000000000000", goodspriceu.PriceStartDate.Ticks);
    //                    _goodsPriceUList_Stc[strkey] = goodspriceu;
    //                }
                    
    //            }

    //        }
    //        catch (Exception)
    //        {
    //            //�I�t���C������null���Z�b�g
    //            this._iGoodsPriceUDB = null;
    //            //�ʐM�G���[��-1��߂�
    //            status = -1;
    //        }

    //        return status;
    //    }

    //    /// <summary>
    //    /// ���i�}�X�^(���[�U�[�o�^)�V���A���C�Y����
    //    /// </summary>
    //    /// <param name="goodspriceu">�V���A���C�Y�Ώۉ��i�}�X�^(���[�U�[�o�^)�N���X</param>
    //    /// <param name="fileName">�V���A���C�Y�t�@�C����</param>
    //    public void Serialize(GoodsPriceU goodspriceu, string fileName)
    //    {
    //        //���i�}�X�^(���[�U�[�o�^)�N���X���牿�i�}�X�^(���[�U�[�o�^)���[�J�[�N���X�Ƀ����o�R�s�[
    //        GoodsPriceUWork goodspriceuWork = CopyToGoodsPriceUWorkFromGoodsPriceU(goodspriceu);
    //        //���i�}�X�^(���[�U�[�o�^)���[�J�[�N���X���V���A���C�Y
    //        XmlByteSerializer.Serialize(goodspriceuWork, fileName);
    //    }

    //    /// <summary>
    //    /// ���i�}�X�^(���[�U�[�o�^)List�V���A���C�Y����
    //    /// </summary>
    //    /// <param name="goodspriceus">�V���A���C�Y�Ώۉ��i�}�X�^(���[�U�[�o�^)List�N���X</param>
    //    /// <param name="fileName">�V���A���C�Y�t�@�C����</param>
    //    /// <remarks>
    //    /// <br>Note       : ���i�}�X�^(���[�U�[�o�^)List���̃V���A���C�Y���s���܂��B</br>
    //    /// <br>Programmer : 20056 ���n ���</br>
    //    /// <br>Date       : 2007.08.13</br>
    //    /// </remarks>
    //    public void ListSerialize(ArrayList goodspriceus, string fileName)
    //    {
    //        GoodsPriceUWork[] goodspriceuWorks = new GoodsPriceUWork[goodspriceus.Count];
    //        for (int i = 0; i < goodspriceus.Count; i++)
    //        {
    //            goodspriceuWorks[i] = CopyToGoodsPriceUWorkFromGoodsPriceU((GoodsPriceU)goodspriceus[i]);
    //        }
    //        //���i�}�X�^(���[�U�[�o�^)���[�J�[�N���X���V���A���C�Y
    //        XmlByteSerializer.Serialize(goodspriceus, fileName);
    //    }

    //    /// <summary>
    //    /// ���i�}�X�^(���[�U�[�o�^)�_���폜����
    //    /// </summary>
    //    /// <param name="goodspriceu">���i�}�X�^(���[�U�[�o�^)�I�u�W�F�N�g</param>
    //    /// <returns></returns>
    //    /// <remarks>
    //    /// <br>Note       : ���i�}�X�^(���[�U�[�o�^)���̘_���폜���s���܂��B</br>
    //    /// <br>Programmer : 20056 ���n ���</br>
    //    /// <br>Date       : 2007.08.13</br>
    //    /// </remarks>
    //    //public int LogicalDelete(ref GoodsPriceU goodspriceu)
    //    public int LogicalDelete(ref ArrayList goodspriceuList)
    //    {
    //        try
    //        {

    //            //���i�}�X�^(���[�U�[�o�^)���牿�i�}�X�^���[�J�[�N���X�Ƀ����o�R�s�[
    //            ArrayList goodspriceuWorkList = CopyToGoodsPriceUWorkFromGoodsPriceUList(goodspriceuList);
    //            ArrayList al = new ArrayList();

    //            object parabyte = (object)goodspriceuWorkList;

    //            int status = 0;
    //            try
    //            {
    //                //���i�}�X�^(���[�U�[�o�^)�_���폜
    //                status = this._iGoodsPriceUDB.LogicalDelete(ref parabyte);
    //                if (status == 0)
    //                {

    //                    al = (ArrayList)parabyte;
    //                    GoodsPriceU goodspriceu = new GoodsPriceU();
    //                    foreach (GoodsPriceUWork goodspriceuwork in al)
    //                    {
    //                        goodspriceu = CopyToGoodsPriceUFormGoodsPriceUWork(goodspriceuwork);
    //                        goodspriceuList.Add(goodspriceu);


    //                        // Static�f�[�^�X�V
    //                        string strkey = string.Format("000000", goodspriceu.GoodsMakerCd) + goodspriceu.GoodsNo + string.Format("00000000000000", goodspriceu.PriceStartDate.Ticks);
    //                        _goodsPriceUList_Stc[strkey] = goodspriceu;
    //                    }

    //                }

    //            }
    //            catch (Exception)
    //            {
    //                //�I�t���C������null���Z�b�g
    //                this._iGoodsPriceUDB = null;
    //                //�ʐM�G���[��-1��߂�
    //                status = -1;
    //            }
    //            return status;
    //        }
    //        catch (Exception)
    //        {
    //            //�I�t���C������null���Z�b�g
    //            this._iGoodsPriceUDB = null;
    //            //�ʐM�G���[��-1��߂�
    //            return -1;
    //        }
    //    }

    //    /// <summary>
    //    /// ���i�}�X�^(���[�U�[�o�^)�����폜����
    //    /// </summary>
    //    /// <param name="goodspriceu">���i�}�X�^(���[�U�[�o�^)�I�u�W�F�N�g</param>
    //    /// <returns></returns>
    //    /// <remarks>
    //    /// <br>Note       : ���i�}�X�^(���[�U�[�o�^)���̕����폜���s���܂��B</br>
    //    /// <br>Programmer : 20056 ���n ���</br>
    //    /// <br>Date       : 2007.08.13</br>
    //    /// </remarks>
    //    public int Delete(ArrayList goodspriceuList)
    //    {
    //        try
    //        {
    //            //���i�}�X�^(���[�U�[�o�^)���牿�i�}�X�^���[�J�[�N���X�Ƀ����o�R�s�[
    //            ArrayList goodspriceuWorkList = CopyToGoodsPriceUWorkFromGoodsPriceUList(goodspriceuList);
    //            ArrayList al = new ArrayList();
    //            GoodsPriceUWork[] goodspriceuWork = null;

    //            byte[] parabyte = XmlByteSerializer.Serialize(goodspriceuWorkList);
                
    //            // ���i�}�X�^(���[�U�[�o�^)�}�X�^�����폜
    //            int status = this._iGoodsPriceUDB.Delete(parabyte);

    //            if (status == 0)
    //            {
    //                goodspriceuWork = (GoodsPriceUWork[])XmlByteSerializer.Deserialize(parabyte, typeof(GoodsPriceUWork[]));
    //                al.AddRange(goodspriceuWork);
    //                GoodsPriceU goodspriceu = new GoodsPriceU();
    //                foreach (GoodsPriceUWork goodspriceuwork in al)
    //                {
    //                    goodspriceu = CopyToGoodsPriceUFormGoodsPriceUWork(goodspriceuwork);
    //                    goodspriceuList.Add(goodspriceu);


    //                    // Static�f�[�^�X�V
    //                    string strkey = string.Format("000000", goodspriceu.GoodsMakerCd) + goodspriceu.GoodsNo + string.Format("00000000000000", goodspriceu.PriceStartDate.Ticks);
    //                    _goodsPriceUList_Stc.Remove(strkey);
    //                }

    //            }

    //            return status;
    //        }
    //        catch (Exception)
    //        {
    //            //�I�t���C������null���Z�b�g
    //            this._iGoodsPriceUDB = null;
    //            //�ʐM�G���[��-1��߂�
    //            return -1;
    //        }
    //    }

    //    /// <summary>
    //    /// ���i�}�X�^(���[�U�[�o�^)�S���������i�_���폜�����j
    //    /// </summary>
    //    /// <param name="retList">�Ǎ����ʃR���N�V����</param>
    //    /// <param name="enterpriseCode">��ƃR�[�h</param>		
    //    /// <returns>STATUS</returns>
    //    /// <remarks>
    //    /// <br>Note       : ���i�}�X�^(���[�U�[�o�^)�̑S�����������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
    //    /// <br>Programmer : 20056 ���n ���</br>
    //    /// <br>Date       : 2007.08.13</br>
    //    /// </remarks>
    //    public int Search(out ArrayList retList, object objParaList, string enterpriseCode)
    //    {
    //        bool nextData;
    //        int retTotalCnt;
    //        return SearchProc(out retList, out retTotalCnt, out nextData, objParaList, enterpriseCode, 0, 0, null);
    //    }

    //    /// <summary>
    //    /// ���i�}�X�^(���[�U�[�o�^)���������i�_���폜�܂ށj
    //    /// </summary>
    //    /// <param name="retList">�Ǎ����ʃR���N�V����</param>
    //    /// <param name="enterpriseCode">��ƃR�[�h</param>		
    //    /// <returns>STATUS</returns>
    //    /// <remarks>
    //    /// <br>Note       : ���i�}�X�^�̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
    //    /// <br>Programmer : 20056 ���n ���</br>
    //    /// <br>Date       : 2007.08.13</br>
    //    /// </remarks>
    //    public int SearchAll(out ArrayList retList, object objParaList, string enterpriseCode)
    //    {
    //        bool nextData;
    //        int retTotalCnt;
    //        return SearchProc(out retList, out retTotalCnt, out nextData, objParaList, enterpriseCode, ConstantManagement.LogicalMode.GetData01, 0, null);
    //    }

    //    /// <summary>
    //    /// �����w�艿�i�}�X�^(���[�U�[�o�^)���������i�_���폜�����j
    //    /// </summary>
    //    /// <param name="retList">�Ǎ����ʃR���N�V����</param>
    //    /// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������(prevLGoodsGanre��null�̏ꍇ�̂ݖ߂�)</param>
    //    /// <param name="nextData">���f�[�^�L��</param>
    //    /// <param name="enterpriseCode">��ƃR�[�h</param>
    //    /// <param name="readCnt">�Ǎ�����</param>		
    //    /// <param name="prevGoodsPriceU">�O��f�[�^�I�u�W�F�N�g�i�����null�w��K�{�j</param>			
    //    /// <returns>STATUS</returns>
    //    /// <remarks>
    //    /// <br>Note       : �������w�肵�ĉ��i�}�X�^(���[�U�[�o�^)�̌����������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
    //    /// <br>Programmer : 20056 ���n ���</br>
    //    /// <br>Date       : 2007.08.13</br>
    //    /// </remarks>
    //    public int Search(out ArrayList retList, out int retTotalCnt, out bool nextData, object objParaList, string enterpriseCode, int readCnt, GoodsPriceU prevGoodsPriceU)
    //    {
    //        return SearchProc(out retList, out retTotalCnt, out nextData,  objParaList, enterpriseCode, 0, readCnt, prevGoodsPriceU);
    //    }

    //    /// <summary>
    //    /// �����w�艿�i�}�X�^(���[�U�[�o�^)���������i�_���폜�����j
    //    /// </summary>
    //    /// <param name="retList">�Ǎ����ʃR���N�V����</param>
    //    /// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������(prevLGoodsGanre��null�̏ꍇ�̂ݖ߂�)</param>
    //    /// <param name="nextData">���f�[�^�L��</param>
    //    /// <param name="enterpriseCode">��ƃR�[�h</param>
    //    /// <param name="readCnt">�Ǎ�����</param>		
    //    /// <param name="prevAlTtlBlockSt">�O��f�[�^�I�u�W�F�N�g�i�����null�w��K�{�j</param>			
    //    /// <returns>STATUS</returns>
    //    /// <remarks>
    //    /// <br>Note       : �������w�肵�ĉ��i�}�X�^(���[�U�[�o�^)�̌����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
    //    /// <br>Programmer : 20056 ���n ���</br>
    //    /// <br>Date       : 2007.08.13</br>
    //    /// </remarks>
    //    public int SearchAll(out ArrayList retList, out int retTotalCnt, out bool nextData, object objParaList, string enterpriseCode, int readCnt, GoodsPriceU prevGoodsPriceU)
    //    {
    //        return SearchProc(out retList, out retTotalCnt, out nextData, objParaList, enterpriseCode, ConstantManagement.LogicalMode.GetData01, readCnt, prevGoodsPriceU);
    //    }

    //    /// <summary>
    //    /// ���i�}�X�^(���[�U�[�o�^)�_���폜��������
    //    /// </summary>
    //    /// <param name="goodspriceu">���i�}�X�^(���[�U�[�o�^)�}�X�^�I�u�W�F�N�g</param>
    //    /// <returns>STATUS</returns>
    //    /// <remarks>
    //    /// <br>Note       : ���i�}�X�^(���[�U�[�o�^)���̕������s���܂��B</br>
    //    /// <br>Programmer : 20056 ���n ���</br>
    //    /// <br>Date       : 2007.08.13</br>
    //    /// </remarks>
    //    public int Revival(ref ArrayList goodspriceuList)
    //    {
    //        try
    //        {
    //            //���i�}�X�^(���[�U�[�o�^)���牿�i�}�X�^���[�J�[�N���X�Ƀ����o�R�s�[
    //            ArrayList goodspriceuWorkList = CopyToGoodsPriceUWorkFromGoodsPriceUList(goodspriceuList);
    //            ArrayList al = new ArrayList();

    //            object parabyte = (object)goodspriceuWorkList;

    //            // ��������
    //            int status = this._iGoodsPriceUDB.RevivalLogicalDelete(ref parabyte);

    //            if (status == 0)
    //            {
    //                al = (ArrayList)parabyte;
    //                GoodsPriceU goodspriceu = new GoodsPriceU();
    //                foreach (GoodsPriceUWork goodspriceuwork in al)
    //                {
    //                    goodspriceu = CopyToGoodsPriceUFormGoodsPriceUWork(goodspriceuwork);
    //                    goodspriceuList.Add(goodspriceu);

    //                    // Static�f�[�^�X�V
    //                    string strkey = string.Format("000000", goodspriceu.GoodsMakerCd) + goodspriceu.GoodsNo + string.Format("00000000000000", goodspriceu.PriceStartDate.Ticks);
    //                    _goodsPriceUList_Stc[strkey] = goodspriceu;
    //                }

    //            }

    //            return status;
    //        }
    //        catch (Exception)
    //        {
    //            //�I�t���C������null���Z�b�g
    //            this._iGoodsPriceUDB = null;
    //            //�ʐM�G���[��-1��߂�
    //            return -1;
    //        }
    //    }

    //    /// <summary>
    //    /// ���i�}�X�^(���[�U�[�o�^)��������(DataSet�p)
    //    /// </summary>
    //    /// <param name="ds">�擾���ʊi�[�pDataSet</param>
    //    /// <param name="enterpriseCode">��ƃR�[�h</param>
    //    /// <returns>STATUS</returns>
    //    /// <remarks>
    //    /// <br>Note       : ���i�}�X�^(���[�U�[�o�^)�̌����������s���A�擾���ʂ�DataSet�ŕԂ��܂��B</br>
    //    /// <br>Programmer : 20056 ���n ���</br>
    //    /// <br>Date       : 2007.08.13</br>
    //    /// -----------------------------------------------------------------------
    //    /// <br>UpdateNote : 2008.02.19 96012�@���F �]</br>
    //    /// <br>           : ���[�J���c�a�Q�ƑΉ�</br>
    //    /// </remarks>
    //    public int Search(ref DataSet ds, object objParaList, string enterpriseCode)
    //    {
    //        GoodsPriceUWork goodspriceuWork = new GoodsPriceUWork();

    //        ArrayList ar = new ArrayList();

    //        int status = 0;
    //        object objectGoodsPriceUWork;

    //        // 2008.02.19 96012 ���[�J���c�a�Q�ƑΉ� Begin
    //        //// �I�����C�����ASearch���s���Ă��Ȃ��ꍇ�i�I�t���C���̏ꍇ�̓R���X�g���N�^��Static�W�J�ς݁j
    //        //if ((!_searchFlg) && (LoginInfoAcquisition.OnlineFlag))
    //        //{
    //        //    // ���i�}�X�^(���[�U�[�o�^)�T�[�`
    //        //    status = this._iGoodsPriceUDB.Search(out objectGoodsPriceUWork, objParaList, 0, ConstantManagement.LogicalMode.GetData01);
    //        //
    //        //    if (status == 0)
    //        //    {
    //        //        // ���i�}�X�^(���[�U�[�o�^)���[�J�[�N���X��UI�N���XStatic�]�L����
    //        //        CopyToStaticFromWorker(objectGoodsPriceUWork as ArrayList);
    //        //        // SearchFlg ON
    //        //        _searchFlg = true;
    //        //    }
    //        //    else
    //        //    {
    //        //        return status;
    //        //    }
    //        //}
    //        if (_isLocalDBRead)
    //        {
    //            List<GoodsPriceUWork> workList = new List<GoodsPriceUWork>();
    //            GoodsPriceUWork workPara = new GoodsPriceUWork();
    //            status = this._goodsPriceULcDB.Search(out workList, objParaList as GoodsPriceUWork, 0, ConstantManagement.LogicalMode.GetData01);
    //            if (status == 0)
    //            {
    //                ArrayList arrayList = new ArrayList();
    //                arrayList.AddRange(workList);
    //                // ���i�}�X�^(���[�U�[�o�^)���[�J�[�N���X��UI�N���XStatic�]�L����
    //                CopyToStaticFromWorker(arrayList);
    //                // SearchFlg ON
    //                _searchFlg = true;
    //            }
    //            else
    //            {
    //                return status;
    //            }
    //        }
    //        else
    //        {
    //            // �I�����C�����ASearch���s���Ă��Ȃ��ꍇ�i�I�t���C���̏ꍇ�̓R���X�g���N�^��Static�W�J�ς݁j
    //            if ((!_searchFlg) && (LoginInfoAcquisition.OnlineFlag))
    //            {
    //                // ���i�}�X�^(���[�U�[�o�^)�T�[�`
    //                status = this._iGoodsPriceUDB.Search(out objectGoodsPriceUWork, objParaList, 0, ConstantManagement.LogicalMode.GetData01);

    //                if (status == 0)
    //                {
    //                    // ���i�}�X�^(���[�U�[�o�^)���[�J�[�N���X��UI�N���XStatic�]�L����
    //                    CopyToStaticFromWorker(objectGoodsPriceUWork as ArrayList);
    //                    // SearchFlg ON
    //                    _searchFlg = true;
    //                }
    //                else
    //                {
    //                    return status;
    //                }
    //            }
    //        }
    //        // 2008.02.19 96012 ���[�J���c�a�Q�ƑΉ� end

    //        /*
    //        // Static����K�C�h�\���i�I��/�I�t���ʁj	
    //        foreach (AlTtlBlockSt alttlblockstWk in _alttlblockstTable_Stc.Values)
    //        {
    //            // ArrayList�փ����o�R�s�[
    //            if (belongSectionCode.Trim() == "")
    //            {
    //                // �S�Е\��
    //                ar.Add(alttlblockstWk.Clone());
    //            }
    //        }
    //        */

    //        ArrayList wkList = ar.Clone() as ArrayList;
    //        SortedList wkSort = new SortedList();

    //        // --- [�S��] --- //
    //        // ���̂܂ܑS���Ԃ�
    //        foreach (GoodsPriceU wkGoodsPriceU in wkList)
    //        {
    //            if (wkGoodsPriceU.LogicalDeleteCode == 0)
    //            {
    //                string strkey = string.Format("000000", wkGoodsPriceU.GoodsMakerCd) + wkGoodsPriceU.GoodsNo + string.Format("00000000000000", wkGoodsPriceU.PriceStartDate.Ticks);
    //                wkSort.Add(strkey, wkGoodsPriceU);
    //            }
    //        }

    //        GoodsPriceU[] goodspriceus = new GoodsPriceU[wkSort.Count];

    //        // �f�[�^�����ɖ߂�
    //        for (int i = 0; i < wkSort.Count; i++)
    //        {
    //            goodspriceus[i] = (GoodsPriceU)wkSort.GetByIndex(i);
    //        }

    //        byte[] retbyte = XmlByteSerializer.Serialize(goodspriceus);
    //        XmlByteSerializer.ReadXml(ref ds, retbyte);

    //        return status;
    //    }

    //    /// <summary>
    //    /// �N���X�����o�[�R�s�[����(���i�}�X�^(���[�U�[�o�^)���[�N�N���X�ˉ��i�}�X�^(���[�U�[�o�^)�N���X)
    //    /// </summary>
    //    /// <param name="goodspriceuwork">���i�}�X�^(���[�U�[�o�^)���[�N�N���X</param>
    //    /// <returns>���i�}�X�^(���[�U�[�o�^)�N���X</returns>
    //    /// <remarks>
    //    /// <br>Note       : ���i�}�X�^(���[�U�[�o�^)�}�X�^���[�N�N���X���牿�i�}�X�^(���[�U�[�o�^)�N���X�փ����o�[�̃R�s�[���s���܂��B�i���C�A�E�g���̂݁j</br>
    //    /// <br>Programmer : 20056 ���n ���</br>
    //    /// <br>Date       : 2007.08.13</br>
    //    /// </remarks>
    //    public static GoodsPriceU CopyToGoodsPriceU(GoodsPriceUWork goodspriceuwork)
    //    {
    //        GoodsPriceU goodspriceu = new GoodsPriceU();

    //        goodspriceu.CreateDateTime = goodspriceuwork.CreateDateTime; // �쐬����
    //        goodspriceu.UpdateDateTime = goodspriceuwork.UpdateDateTime; // �X�V����
    //        goodspriceu.EnterpriseCode = goodspriceuwork.EnterpriseCode; // ��ƃR�[�h
    //        goodspriceu.FileHeaderGuid = goodspriceuwork.FileHeaderGuid; // GUID
    //        goodspriceu.UpdEmployeeCode = goodspriceuwork.UpdEmployeeCode; // �X�V�]�ƈ��R�[�h
    //        goodspriceu.UpdAssemblyId1 = goodspriceuwork.UpdAssemblyId1; // �X�V�A�Z���u��ID1
    //        goodspriceu.UpdAssemblyId2 = goodspriceuwork.UpdAssemblyId2; // �X�V�A�Z���u��ID2
    //        goodspriceu.LogicalDeleteCode = goodspriceuwork.LogicalDeleteCode; // �_���폜�敪
    //        goodspriceu.GoodsMakerCd = goodspriceuwork.GoodsMakerCd; // ���i���[�J�[�R�[�h
    //        goodspriceu.GoodsNo = goodspriceuwork.GoodsNo; // ���i�ԍ�
    //        goodspriceu.PriceStartDate = goodspriceuwork.PriceStartDate; // ���i�J�n��
    //        goodspriceu.ListPrice = goodspriceuwork.ListPrice; // �艿�i�����j
    //        goodspriceu.SalesUnitCost = goodspriceuwork.SalesUnitCost; // �����P��
    //        goodspriceu.StockRate = goodspriceuwork.StockRate; // �d����
    //        goodspriceu.OpenPriceDiv = goodspriceuwork.OpenPriceDiv; // �I�[�v�����i�敪
    //        goodspriceu.OfferDate = goodspriceuwork.OfferDate; // �񋟓��t
    //        goodspriceu.UpdateDate = goodspriceuwork.UpdateDate; // �X�V�N����

    //        return goodspriceu;
    //    }

    //    ///// <summary>
    //    ///// ���i�}�X�^(���[�U�[�o�^)�e�[�u���쐬����
    //    ///// </summary>
    //    ///// <param name="GoodsPriceTable"></param>
    //    ///// <param name="goodsPriceTable"></param>
    //    ///// <param name="retList"></param>
    //    //public void MakeHashTableFromGoodsPriceU(out Hashtable GoodsPriceTable, Hashtable goodsPriceTable, ArrayList retList)
    //    //{
    //    //    Hashtable hashTable = new Hashtable();
    //    //    foreach (GoodsPriceU goodspriceu in retList)
    //    //    {
    //    //        GoodsUnitData.GoodsPriceKey goodsPriceKey = new GoodsUnitData.GoodsPriceKey(goodspriceu.GoodsNo, goodspriceu.GoodsMakerCd, goodspriceu.PriceStartDate);
    //    //        if (!goodsPriceTable.Contains(goodsPriceKey))
    //    //        {
    //    //            GoodsPrice goodsprice = new GoodsPrice();

    //    //            goodsprice.CreateDateTime = goodspriceu.CreateDateTime; // �쐬����
    //    //            goodsprice.UpdateDateTime = goodspriceu.UpdateDateTime; // �X�V����
    //    //            goodsprice.EnterpriseCode = goodspriceu.EnterpriseCode; // ��ƃR�[�h
    //    //            goodsprice.FileHeaderGuid = goodspriceu.FileHeaderGuid; // GUID
    //    //            goodsprice.UpdEmployeeCode = goodspriceu.UpdEmployeeCode; // �X�V�]�ƈ��R�[�h
    //    //            goodsprice.UpdAssemblyId1 = goodspriceu.UpdAssemblyId1; // �X�V�A�Z���u��ID1
    //    //            goodsprice.UpdAssemblyId2 = goodspriceu.UpdAssemblyId2; // �X�V�A�Z���u��ID2
    //    //            goodsprice.LogicalDeleteCode = goodspriceu.LogicalDeleteCode; // �_���폜�敪
    //    //            goodsprice.GoodsMakerCd = goodspriceu.GoodsMakerCd; // ���i���[�J�[�R�[�h
    //    //            goodsprice.GoodsNo = goodspriceu.GoodsNo; // ���i�ԍ�
    //    //            goodsprice.PriceStartDate = goodspriceu.PriceStartDate; // ���i�J�n��
    //    //            goodsprice.ListPrice = goodspriceu.ListPrice; // �艿�i�����j
    //    //            goodsprice.SalesUnitCost = goodspriceu.SalesUnitCost; // �����P��
    //    //            goodsprice.StockRate = goodspriceu.StockRate; // �d����
    //    //            goodsprice.OpenPriceDiv = goodspriceu.OpenPriceDiv; // �I�[�v�����i�敪
    //    //            goodsprice.OfferDate = goodspriceu.OfferDate; // �񋟓��t
    //    //            goodsprice.UpdateDate = goodspriceu.UpdateDate; // �X�V�N����

    //    //            hashTable[goodsPriceKey] = goodsprice;
    //    //        }
    //    //    }
    //    //    GoodsPriceTable = hashTable;
    //    //}

    //    #region ���}�X����UI�N���X�p�Q�Ə���
    //    /// <summary>
    //    /// ���_���̎擾����
    //    /// </summary>
    //    /// <param name="enterpriseCode">��ƃR�[�h</param>
    //    /// <param name="sectionCode">���_�R�[�h</param>
    //    /// <returns>���_����</returns>
    //    /// <remarks>
    //    /// <br>Note       : ���_���̂�Ԃ��܂��B</br>
    //    /// <br>Programmer : 20056 ���n ���</br>
    //    /// <br>Date       : 2007.08.01</br>
    //    /// </remarks>
    //    public string GetSectionName(string enterpriseCode, string sectionCode)
    //    {
    //        return "���o�^";
    //    }
    //    #endregion

        //#region ���@���[�U�[�K�C�h�}�X�^�擾
        ///// <summary>
        ///// ���[�U�[�K�C�h�}�X�^�擾
        ///// </summary>
        ///// <param name="enterpriseCode">��ƃR�[�h</param>
        ///// <param name="sectionCode">���_�R�[�h</param>
        ///// <param name="msg">�G���[���b�Z�[�W</param>
        ///// <returns></returns>
        //public int SearchInitial_UserGdBd(string enterpriseCode, out ArrayList userGdBd, Int32 userGuideDivCd)
        //{
        //    string msg;
        //    return SearchInitial_UserGdBd(enterpriseCode, out msg, out userGdBd, userGuideDivCd);
        //}

        ///// <summary>
        ///// ���[�U�[�K�C�h�}�X�^�擾
        ///// </summary>
        ///// <param name="enterpriseCode">��ƃR�[�h</param>
        ///// <param name="sectionCode">���_�R�[�h</param>
        ///// <param name="msg">�G���[���b�Z�[�W</param>
        ///// <returns></returns>
        //public int SearchInitial_UserGdBd(string enterpriseCode, out string msg, out ArrayList userGdBd, Int32 userGuideDivCd)
        //{

        //    userGdBd = null;

        //    // Static�L���b�V���N���A
        //    ArrayList clearData = new ArrayList();
        //    clearData.Add(typeof(UserGdBd));

        //    int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //    msg = "";

        //    try
        //    {
        //        status = this._userGuideAcs.SearchAllDivCodeBody(
        //            out userGdBd,
        //            enterpriseCode,
        //            userGuideDivCd,
        //            UserGuideAcsData.UserBodyData);

        //        switch (status)
        //        {
        //            case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
        //                {
        //                    switch (userGuideDivCd)
        //                    {
        //                        case USERGDBD_PRICEDIVCD:
        //                            {
        //                                _userGdBdPriceDivCd = userGdBd;
        //                                break;
        //                            }
        //                        case USERGDBD_UNITCODE:
        //                            {
        //                                _userGdBdUnitCode = userGdBd;
        //                                break;
        //                            }
        //                        case USERGDBD_ENTERPRISEGANRECODE:
        //                            {
        //                                _userGdBdEnterpriseGanreCode = userGdBd;
        //                                break;
        //                            }
        //                    }
        //                    break;
        //                }
        //            case (int)ConstantManagement.DB_Status.ctDB_EOF:
        //                {
        //                    break;
        //                }
        //            default:
        //                {
        //                    msg = "���[�U�[�K�C�h�}�X�^�̎擾�Ɏ��s���܂���";
        //                    break;
        //                }
        //        }


        //    }
        //    catch (Exception ex)
        //    {
        //        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //        msg = "���[�U�[�K�C�h�}�X�^�̎擾�ŗ�O���������܂���[" + ex.Message + "]";
        //        msg = ex.Message;
        //    }


        //    return 0;

        //}

        ///// <summary>
        ///// ���[�U�[�K�C�h�C���f�b�N�X�擾����
        ///// </summary>
        ///// <param name="userGdBd"></param>
        ///// <param name="value"></param>
        ///// <returns></returns>
        //public int GetIndex(ArrayList userGdBd, Int32 value)
        //{
        //    int index = 0;
        //    foreach (UserGdBd wkUserGdBdWork in userGdBd)
        //    {
        //        if (wkUserGdBdWork.GuideCode == value)
        //        {
        //            return index;
        //        }
        //        index++;
        //    }
        //    return index;
        //}
        //#endregion


    //    #endregion

    //    #region ��Private Method
    //    /// <summary>
    //    /// ���i�}�X�^(���[�U�[�o�^)��������
    //    /// </summary>
    //    /// <param name="retList">�Ǎ����ʃR���N�V����</param>
    //    /// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������</param>
    //    /// <param name="nextData">���f�[�^�L��</param>
    //    /// <param name="enterpriseCode">��ƃR�[�h</param>
    //    /// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�S�f�[�^)</param>
    //    /// <param name="readCnt">�Ǎ�����</param>
    //    /// <param name="prevGoodsPriceUSt">�O��ŏI�S���҃f�[�^�I�u�W�F�N�g</param>
    //    /// <returns>STATUS</returns>
    //    /// <remarks>
    //    /// <br>Note       : ���i�}�X�^(���[�U�[�o�^)�̌����������s���܂��B</br>
    //    /// <br>Programmer : 20056 ���n ���</br>
    //    /// <br>Date       : 2007.08.13</br>
    //    /// -----------------------------------------------------------------------
    //    /// <br>UpdateNote : 2008.02.19 96012�@���F �]</br>
    //    /// <br>           : ���[�J���c�a�Q�ƑΉ�</br>
    //    /// </remarks>
    //    private int SearchProc(out ArrayList retList, out int retTotalCnt, out bool nextData, object objParaList, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, GoodsPriceU prevGoodsPriceUSt)
    //    {
    //        GoodsPriceUWork goodspriceuWork = new GoodsPriceUWork();
    //        if (prevGoodsPriceUSt != null) goodspriceuWork = CopyToGoodsPriceUWorkFromGoodsPriceU(prevGoodsPriceUSt);
    //        //alttlblockstWork.EnterpriseCode = enterpriseCode;

    //        int status;

    //        //���f�[�^�L��������
    //        nextData = false;
    //        //0�ŏ�����
    //        retTotalCnt = 0;

    //        retList = new ArrayList();
    //        retList.Clear();
    //        ArrayList paraList = new ArrayList();

    //        // 2008.02.19 96012 ���[�J���c�a�Q�ƑΉ� Begin
    //        //// �I�t���C���̏ꍇ�̓L���b�V������ǂ�
    //        //if (!LoginInfoAcquisition.OnlineFlag)
    //        //{
    //        //    status = SearchStaticMemory(out retList, objParaList, enterpriseCode);
    //        //}
    //        //else
    //        //{
    //        //    GoodsPriceU goodspriceu = new GoodsPriceU();
    //        //    object objectGoodsPriceUWork = null;
    //        //
    //        //    // ���i�}�X�^(���[�U�[�o�^)����
    //        //    // �����[�g 
    //        //    status = this._iGoodsPriceUDB.Search(out objectGoodsPriceUWork, objectGoodsPriceUWork, 0, logicalMode);
    //        //
    //        //    if (status == 0)
    //        //    {
    //        //        // ���i�}�X�^(���[�U�[�o�^)���[�J�[�N���X��UI�N���XStatic�]�L����
    //        //        CopyToStaticFromWorker(objectGoodsPriceUWork as ArrayList);
    //        //
    //        //        // �p�����[�^���n���ė��Ă��邩�m�F
    //        //        paraList = objectGoodsPriceUWork as ArrayList;
    //        //        GoodsPriceUWork[] wkGoodsPriceUWork = new GoodsPriceUWork[paraList.Count];
    //        //
    //        //        // �f�[�^�����ɖ߂�
    //        //        for (int i = 0; i < paraList.Count; i++)
    //        //        {
    //        //            wkGoodsPriceUWork[i] = (GoodsPriceUWork)paraList[i];
    //        //        }
    //        //        for (int i = 0; i < wkGoodsPriceUWork.Length; i++)
    //        //        {
    //        //            goodspriceu = CopyToGoodsPriceUFormGoodsPriceUWork(wkGoodsPriceUWork[i]);
    //        //            // �T�[�`���ʎ擾
    //        //            retList.Add(goodspriceu);
    //        //            // �X�^�e�B�b�N�X�V
    //        //            string strkey = string.Format("000000", goodspriceu.GoodsMakerCd) + goodspriceu.GoodsNo + string.Format("00", goodspriceu.PriceDivCd);
    //        //            _goodspriceuTable_Stc[strkey] = goodspriceu;
    //        //        }
    //        //
    //        //        _searchFlg = true;
    //        //    }
    //        //}
    //        if (_isLocalDBRead)
    //        {
    //            List<GoodsPriceUWork> workList = new List<GoodsPriceUWork>();
    //            GoodsPriceUWork workPara = new GoodsPriceUWork();
    //            GoodsPriceU goodspriceu = new GoodsPriceU();
    //            status = this._goodsPriceULcDB.Search(out workList, objParaList as GoodsPriceUWork, 0, ConstantManagement.LogicalMode.GetData01);
    //            if (status == 0)
    //            {
    //                ArrayList arrayList = new ArrayList();
    //                arrayList.AddRange(workList);
    //                // ���i�}�X�^(���[�U�[�o�^)���[�J�[�N���X��UI�N���XStatic�]�L����
    //                CopyToStaticFromWorker(arrayList);
    //                for (int i = 0; i < workList.Count; ++i)
    //                {
    //                    goodspriceu = CopyToGoodsPriceUFormGoodsPriceUWork(workList[i]);
    //                    // �T�[�`���ʎ擾
    //                    retList.Add(goodspriceu);
    //                    // �X�^�e�B�b�N�X�V
    //                    string strkey = string.Format("000000", goodspriceu.GoodsMakerCd) + goodspriceu.GoodsNo + string.Format("00000000000000", goodspriceu.PriceStartDate.Ticks);
    //                    _goodsPriceUList_Stc[strkey] = goodspriceu;
    //                }
    //                // SearchFlg ON
    //                _searchFlg = true;
    //            }
    //            else
    //            {
    //                return status;
    //            }
    //        }
    //        else
    //        {
    //            //�S�����[�h�̏ꍇ�͖߂�l�̌������Z�b�g
    //            if (readCnt == 0) retTotalCnt = retList.Count;
    //            // �I�t���C���̏ꍇ�̓L���b�V������ǂ�
    //            if (!LoginInfoAcquisition.OnlineFlag)
    //            {
    //                status = SearchStaticMemory(out retList, objParaList, enterpriseCode);
    //            }
    //            else
    //            {
    //                GoodsPriceU goodspriceu = new GoodsPriceU();
    //                object objectGoodsPriceUWork = null;
    //                // ���i�}�X�^(���[�U�[�o�^)����
    //                // �����[�g 
    //                status = this._iGoodsPriceUDB.Search(out objectGoodsPriceUWork, objectGoodsPriceUWork, 0, logicalMode);
    //                if (status == 0)
    //                {
    //                    // ���i�}�X�^(���[�U�[�o�^)���[�J�[�N���X��UI�N���XStatic�]�L����
    //                    CopyToStaticFromWorker(objectGoodsPriceUWork as ArrayList);
    //                    // �p�����[�^���n���ė��Ă��邩�m�F
    //                    paraList = objectGoodsPriceUWork as ArrayList;
    //                    GoodsPriceUWork[] wkGoodsPriceUWork = new GoodsPriceUWork[paraList.Count];
    //                    // �f�[�^�����ɖ߂�
    //                    for (int i = 0; i < paraList.Count; i++)
    //                    {
    //                        wkGoodsPriceUWork[i] = (GoodsPriceUWork)paraList[i];
    //                    }
    //                    for (int i = 0; i < wkGoodsPriceUWork.Length; i++)
    //                    {
    //                        goodspriceu = CopyToGoodsPriceUFormGoodsPriceUWork(wkGoodsPriceUWork[i]);
    //                        // �T�[�`���ʎ擾
    //                        retList.Add(goodspriceu);
    //                        // �X�^�e�B�b�N�X�V
    //                        string strkey = string.Format("000000", goodspriceu.GoodsMakerCd) + goodspriceu.GoodsNo + string.Format("00000000000000", goodspriceu.PriceStartDate.Ticks);
    //                        _goodsPriceUList_Stc[strkey] = goodspriceu;
    //                    }
    //                    _searchFlg = true;
    //                }
    //            }
    //        }
    //        // 2008.02.19 96012 ���[�J���c�a�Q�ƑΉ� end
    //        //�S�����[�h�̏ꍇ�͖߂�l�̌������Z�b�g
    //        if (readCnt == 0) retTotalCnt = retList.Count;

    //        return status;
    //    }

    //    /// <summary>
    //    /// �N���X�����o�[�R�s�[�����i���i�}�X�^(���[�U�[�o�^)���[�N�N���X�ˉ��i�}�X�^(���[�U�[�o�^)�N���X�j
    //    /// </summary>
    //    /// <param name="goodspriceuwork">���i�}�X�^(���[�U�[�o�^)���[�N�N���X</param>
    //    /// <returns>���i�}�X�^(���[�U�[�o�^)�N���X</returns>
    //    /// <remarks>
    //    /// <br>Note       : ���i�}�X�^(���[�U�[�o�^)���[�N�N���X���牿�i�}�X�^(���[�U�[�o�^)�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
    //    /// <br>		    : ���������ɒǉ������v���p�e�B�����Z�b�g���܂��B</br>
    //    /// <br>Programmer : 20056 ���n ���</br>
    //    /// <br>Date       : 2007.08.13</br>
    //    /// </remarks>
    //    private GoodsPriceU CopyToGoodsPriceUFormGoodsPriceUWork(GoodsPriceUWork goodspriceuwork)
    //    {
    //        GoodsPriceU goodspriceu = new GoodsPriceU();

    //        goodspriceu = CopyToGoodsPriceU(goodspriceuwork);

    //        return goodspriceu;
    //    }

    //    /// <summary>
    //    /// �N���X�����o�[�R�s�[�����i���i�}�X�^(���[�U�[�o�^)�N���X�ˉ��i�}�X�^(���[�U�[�o�^)���[�N�N���X�j
    //    /// </summary>
    //    /// <param name="goodspriceu">���i�}�X�^(���[�U�[�o�^)���[�N�N���X</param>
    //    /// <returns>���i�}�X�^(���[�U�[�o�^)�N���X</returns>
    //    /// <remarks>
    //    /// <br>Note       : ���i�}�X�^(���[�U�[�o�^)�N���X���牿�i�}�X�^(���[�U�[�o�^)�}�X�^���[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
    //    /// <br>Programmer : 20056 ���n ���</br>
    //    /// <br>Date       : 2007.08.13</br>
    //    /// </remarks>
    //    private GoodsPriceUWork CopyToGoodsPriceUWorkFromGoodsPriceU(GoodsPriceU goodspriceu)
    //    {
    //        GoodsPriceUWork goodspriceuwork = new GoodsPriceUWork();

    //        goodspriceuwork.CreateDateTime = goodspriceu.CreateDateTime; // �쐬����
    //        goodspriceuwork.UpdateDateTime = goodspriceu.UpdateDateTime; // �X�V����
    //        goodspriceuwork.EnterpriseCode = goodspriceu.EnterpriseCode; // ��ƃR�[�h
    //        goodspriceuwork.FileHeaderGuid = goodspriceu.FileHeaderGuid; // GUID
    //        goodspriceuwork.UpdEmployeeCode = goodspriceu.UpdEmployeeCode; // �X�V�]�ƈ��R�[�h
    //        goodspriceuwork.UpdAssemblyId1 = goodspriceu.UpdAssemblyId1; // �X�V�A�Z���u��ID1
    //        goodspriceuwork.UpdAssemblyId2 = goodspriceu.UpdAssemblyId2; // �X�V�A�Z���u��ID2
    //        goodspriceuwork.LogicalDeleteCode = goodspriceu.LogicalDeleteCode; // �_���폜�敪
    //        goodspriceuwork.GoodsMakerCd = goodspriceu.GoodsMakerCd; // ���i���[�J�[�R�[�h
    //        goodspriceuwork.GoodsNo = goodspriceu.GoodsNo; // ���i�ԍ�
    //        goodspriceuwork.PriceStartDate = goodspriceu.PriceStartDate; // ���i�J�n��
    //        goodspriceuwork.ListPrice = goodspriceu.ListPrice; // �艿�i�����j
    //        goodspriceuwork.SalesUnitCost = goodspriceu.SalesUnitCost; // �����P��
    //        goodspriceuwork.StockRate = goodspriceu.StockRate; // �d����
    //        goodspriceuwork.OpenPriceDiv = goodspriceu.OpenPriceDiv; // �I�[�v�����i�敪
    //        goodspriceuwork.OfferDate = goodspriceu.OfferDate; // �񋟓��t
    //        goodspriceuwork.UpdateDate = goodspriceu.UpdateDate; // �X�V�N����

    //        return goodspriceuwork;
    //    }

    //    /// <summary>
    //    /// �N���X�����o�[�R�s�[�����i���i�}�X�^(���[�U�[�o�^)�N���X�ˉ��i�}�X�^(���[�U�[�o�^)���[�N�N���X(���X�g)�j
    //    /// </summary>
    //    /// <param name="goodspriceu">���i�}�X�^(���[�U�[�o�^)���[�N�N���X</param>
    //    /// <returns>���i�}�X�^(���[�U�[�o�^)�N���X</returns>
    //    /// <remarks>
    //    /// <br>Note       : ���i�}�X�^(���[�U�[�o�^)�N���X���牿�i�}�X�^(���[�U�[�o�^)�}�X�^���[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
    //    /// <br>Programmer : 20056 ���n ���</br>
    //    /// <br>Date       : 2007.08.13</br>
    //    /// </remarks>
    //    private ArrayList CopyToGoodsPriceUWorkFromGoodsPriceUList(ArrayList goodspriceuList)
    //    {

    //        ArrayList retArray = new ArrayList();

    //        foreach (GoodsPriceU goodspriceu in goodspriceuList)
    //        {
    //            GoodsPriceUWork goodspriceuwork = new GoodsPriceUWork();
    //            goodspriceuwork.CreateDateTime = goodspriceu.CreateDateTime; // �쐬����
    //            goodspriceuwork.UpdateDateTime = goodspriceu.UpdateDateTime; // �X�V����
    //            goodspriceuwork.EnterpriseCode = goodspriceu.EnterpriseCode; // ��ƃR�[�h
    //            goodspriceuwork.FileHeaderGuid = goodspriceu.FileHeaderGuid; // GUID
    //            goodspriceuwork.UpdEmployeeCode = goodspriceu.UpdEmployeeCode; // �X�V�]�ƈ��R�[�h
    //            goodspriceuwork.UpdAssemblyId1 = goodspriceu.UpdAssemblyId1; // �X�V�A�Z���u��ID1
    //            goodspriceuwork.UpdAssemblyId2 = goodspriceu.UpdAssemblyId2; // �X�V�A�Z���u��ID2
    //            goodspriceuwork.LogicalDeleteCode = goodspriceu.LogicalDeleteCode; // �_���폜�敪
    //            goodspriceuwork.GoodsMakerCd = goodspriceu.GoodsMakerCd; // ���i���[�J�[�R�[�h
    //            goodspriceuwork.GoodsNo = goodspriceu.GoodsNo; // ���i�ԍ�
    //            goodspriceuwork.PriceStartDate = goodspriceu.PriceStartDate; // ���i�J�n��
    //            goodspriceuwork.ListPrice = goodspriceu.ListPrice; // �艿�i�����j
    //            goodspriceuwork.SalesUnitCost = goodspriceu.SalesUnitCost; // �����P��
    //            goodspriceuwork.StockRate = goodspriceu.StockRate; // �d����
    //            goodspriceuwork.OpenPriceDiv = goodspriceu.OpenPriceDiv; // �I�[�v�����i�敪
    //            goodspriceuwork.OfferDate = goodspriceu.OfferDate; // �񋟓��t
    //            goodspriceuwork.UpdateDate = goodspriceu.UpdateDate; // �X�V�N����

    //            retArray.Add(goodspriceuwork);                
    //        }

    //        return retArray;
    //    }
        
    //    /// <summary>
    //    /// ��������������
    //    /// </summary>
    //    /// <remarks>
    //    /// <br>Note       : ���i�}�X�^(���[�U�[�o�^)�ݒ�A�N�Z�X�N���X���ێ����郁�����𐶐����܂��B</br>
    //    /// <br>Programer  : 20056 ���n ���</br>
    //    /// <br>Date       : 2007.08.13</br>
    //    /// </remarks>
    //    private void MemoryCreate()
    //    {

    //        // ���i�}�X�^(���[�U�[�o�^)�}�X�^�N���XStatic
    //        if (_goodsPriceUList_Stc == null)
    //        {
    //            _goodsPriceUList_Stc = new Hashtable();
    //        }

    //    }

    //    /// <summary>
    //    /// ���i�}�X�^(���[�U�[�o�^)�N���X���[�J�[�N���X(List) �� UI�N���X�ϊ�����
    //    /// </summary>
    //    /// <param name="goodspriceuWorkList"></param>
    //    /// <remarks>
    //    /// <br>Note       : ���i�}�X�^(���[�U�[�o�^)�u���[�J�[�N���X��UI�̕��ʕ��i�N���X�ɕϊ����āA
    //    ///					 Search�pStatic�������ɕێ����܂��B</br>
    //    /// <br>Programer  : 20056 ���n ���</br>
    //    /// <br>Date       : 2007.08.13</br>
    //    /// </remarks>
    //    private void CopyToStaticFromWorker(List<GoodsPriceUWork> goodspriceuWorkList)
    //    {
    //        ArrayList goodspriceuWorkArray = new ArrayList();
    //        goodspriceuWorkArray.AddRange(goodspriceuWorkList);

    //        CopyToStaticFromWorker(goodspriceuWorkArray);
    //    }

    //    /// <summary>
    //    /// ���i�}�X�^(���[�U�[�o�^)�N���X���[�J�[�N���X(ArrayList) �� UI�N���X�ϊ�����
    //    /// </summary>
    //    /// <param name="goodspriceuWorkList"></param>
    //    /// <remarks>
    //    /// <br>Note       : ���i�}�X�^(���[�U�[�o�^)���[�J�[�N���X��UI�̕��ʕ��i�N���X�ɕϊ����āA
    //    ///					 Search�pStatic�������ɕێ����܂��B</br>
    //    /// <br>Programer  : 20056 ���n ���</br>
    //    /// <br>Date       : 2007.08.13</br>
    //    /// </remarks>
    //    private void CopyToStaticFromWorker(ArrayList goodspriceuWorkList)
    //    {
    //        foreach (GoodsPriceUWork wkGoodsPriceUWork in goodspriceuWorkList)
    //        {
    //            GoodsPriceU wkGoodsPriceU = new GoodsPriceU();

    //            GoodsUnitData.GoodsPriceKey goodsPriceKey = new GoodsUnitData.GoodsPriceKey(wkGoodsPriceUWork.GoodsNo, wkGoodsPriceUWork.GoodsMakerCd, wkGoodsPriceUWork.PriceStartDate);

    //            wkGoodsPriceU.CreateDateTime = wkGoodsPriceUWork.CreateDateTime; // �쐬����
    //            wkGoodsPriceU.UpdateDateTime = wkGoodsPriceUWork.UpdateDateTime; // �X�V����
    //            wkGoodsPriceU.EnterpriseCode = wkGoodsPriceUWork.EnterpriseCode; // ��ƃR�[�h
    //            wkGoodsPriceU.FileHeaderGuid = wkGoodsPriceUWork.FileHeaderGuid; // GUID
    //            wkGoodsPriceU.UpdEmployeeCode = wkGoodsPriceUWork.UpdEmployeeCode; // �X�V�]�ƈ��R�[�h
    //            wkGoodsPriceU.UpdAssemblyId1 = wkGoodsPriceUWork.UpdAssemblyId1; // �X�V�A�Z���u��ID1
    //            wkGoodsPriceU.UpdAssemblyId2 = wkGoodsPriceUWork.UpdAssemblyId2; // �X�V�A�Z���u��ID2
    //            wkGoodsPriceU.LogicalDeleteCode = wkGoodsPriceUWork.LogicalDeleteCode; // �_���폜�敪
    //            wkGoodsPriceU.GoodsMakerCd = wkGoodsPriceUWork.GoodsMakerCd; // ���i���[�J�[�R�[�h
    //            wkGoodsPriceU.GoodsNo = wkGoodsPriceUWork.GoodsNo; // ���i�ԍ�
    //            wkGoodsPriceU.PriceStartDate = wkGoodsPriceUWork.PriceStartDate; // ���i�J�n��
    //            wkGoodsPriceU.ListPrice = wkGoodsPriceUWork.ListPrice; // �艿�i�����j
    //            wkGoodsPriceU.SalesUnitCost = wkGoodsPriceUWork.SalesUnitCost; // �����P��
    //            wkGoodsPriceU.StockRate = wkGoodsPriceUWork.StockRate; // �d����
    //            wkGoodsPriceU.OpenPriceDiv = wkGoodsPriceUWork.OpenPriceDiv; // �I�[�v�����i�敪
    //            wkGoodsPriceU.OfferDate = wkGoodsPriceUWork.OfferDate; // �񋟓��t
    //            wkGoodsPriceU.UpdateDate = wkGoodsPriceUWork.UpdateDate; // �X�V�N����

    //            _goodsPriceUList_Stc[goodsPriceKey] = wkGoodsPriceU;
    //        }
    //    }

    //    /// <summary>
    //    /// ���[�J���t�@�C���Ǎ��ݏ���
    //    /// </summary>
    //    /// <remarks>
    //    /// <br>Note       : ���[�J���t�@�C����Ǎ���ŁA����Static�ɕێ����܂��B</br>
    //    /// <br>Programer  : 20056 ���n ���</br>
    //    /// <br>Date       : 2007.08.13</br>
    //    /// </remarks>
    //    private void SearchOfflineData()
    //    {
    //        // �I�t���C���V���A���C�Y�f�[�^�쐬���iI/O
    //        OfflineDataSerializer offlineDataSerializer = new OfflineDataSerializer();

    //        // --- Search�p --- //
    //        // KeyList�ݒ�
    //        string[] goodspriceuKeys = new string[1];
    //        goodspriceuKeys[0] = LoginInfoAcquisition.EnterpriseCode;
    //        // ���[�J���t�@�C���Ǎ��ݏ���
    //        object wkObj = offlineDataSerializer.DeSerialize("GoddsPriceUAcs", goodspriceuKeys);
    //        // ArrayList�ɃZ�b�g
    //        List<GoodsPriceUWork> wkList = new List<GoodsPriceUWork>();

    //        if ((wkList != null) &&
    //            (wkList.Count != 0))
    //        {
    //            // ���i�}�X�^(���[�U�[�o�^)�N���X���[�J�[�N���X�iArrayList�j �� UI�N���X�iStatic�j�ϊ�����
    //            CopyToStaticFromWorker(wkList);
    //        }
    //    }
    //    #endregion

    //    #region ��Public Const
    //    public const Int32 USERGDBD_PRICEDIVCD = 47; // ���i�敪
    //    public const Int32 USERGDBD_UNITCODE = 45; // �P�ʃR�[�h
    //    public const Int32 USERGDBD_ENTERPRISEGANRECODE = 41; // ���Е��ރR�[�h
    //    #endregion

    //}
}

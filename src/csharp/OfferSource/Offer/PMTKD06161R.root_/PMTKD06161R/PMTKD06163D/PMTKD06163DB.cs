using System;
using System.Collections;
using System.Collections.Generic;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   PartsSubstWork
    /// <summary>
    ///                      ���i��փ��[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���i��փ��[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2006/11/15</br>
    /// <br>Genarated Date   :   2007/01/29  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class PartsSubstWork
    {
        /// <summary>�J�^���O���i���[�J�[�R�[�h</summary>
        private Int32 _catalogPartsMakerCd;

        /// <summary>�n�C�t���t���i��</summary>
        private string _oldPartsNoWithHyphen = "";

        /// <summary>�n�C�t���t�V�i��</summary>
        private string _newPartsNoWithHyphen = "";

        /// <summary>�n�C�t���t�V�i�ԕ\������</summary>
        private Int32 _nPrtNoWithHypnDspOdr;

        /// <summary>���i������փt���O</summary>
        /// <remarks>0:������ւȂ� 1:������ւ���</remarks>
        private Int32 _partsPluralSubstFlg;

        /// <summary>���C���E�T�u���i�敪</summary>
        /// <remarks>0:������ւȂ� 1:���C�� 2�`:�q</remarks>
        private Int32 _mainOrSubPartsDivCd;

        /// <summary>���iQTY</summary>
        /// <remarks>���C���E�T�u���i�敪��0�ȊO�̎��ɗL��</remarks>
        private Double _partsQty;

        /// <summary>���i������֓E�v</summary>
        /// <remarks>���C���E�T�u���i�敪��0�ȊO�̎��ɗL��</remarks>
        private string _partsPluralSubstCmnt = "";

        /// <summary>������֌��n�C�t���t�V�i��</summary>
        /// <remarks>���C���E�T�u���i�敪��0�ȊO�̎��ɗL��</remarks>
        private string _plrlSubNewPrtNoHypn = "";

        /// <summary>�n�C�t�����ŐV���i�i��</summary>
        private string _newPrtsNoNoneHyphen = "";

        /// <summary>�����i�R�[�h</summary>
        /// <remarks>1�`99999:�񋟕�,100000�`���[�U�[�o�^�p</remarks>
        private Int32 _tbsPartsCode;

        /// <summary>�����i�R�[�h�}��</summary>
        private Int32 _tbsPartsCdDerivedNo;

        /// <summary>���[�J�[�񋟕��i����</summary>
        private string _makerOfferPartsName = "";

        /// <summary>���i���i</summary>
        private Int64 _partsPrice;

        /// <summary>���i�J�n��</summary>
        private DateTime _partsPriceStDate;

        /// <summary>�w�ʃR�[�h</summary>
        private string _partsLayerCd = "";

        /// <summary>���i��񐧌�t���O</summary>
        /// <remarks>0:���ʕ��i 1:SF.NS��p���i(PM����̌����͕s�j</remarks>
        private Int32 _partsInfoCtrlFlg;

        /// <summary>���i����</summary>
        private string _partsName = "";

        /// <summary>���i�敪�R�[�h</summary>
        /// <remarks>��ƕ��i�敪�}�X�^�̋敪�R�[�h</remarks>
        private Int32 _partsCode;

        /// <summary>���i�����敪</summary>
        /// <remarks>0:���i���i��������,1:�ʏ핔�i���i����,2:���MT������</remarks>
        private Int32 _partsSearchCode;

        /// <summary>�񋟓��t</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _offerDate;

        /// <summary>���i�񋟓��t</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _priceOfferDate;

        /// <summary>���[�J�[�񋟕��i�J�i����</summary>
        private string _makerOfferPartsKana;

        /// <summary>�I�[�v�����i�敪</summary>
        private Int32 _openPriceDiv;

        /// public propaty name  :  CatalogPartsMakerCd
        /// <summary>�J�^���O���i���[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�^���O���i���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CatalogPartsMakerCd
        {
            get { return _catalogPartsMakerCd; }
            set { _catalogPartsMakerCd = value; }
        }

        /// public propaty name  :  OldPartsNoWithHyphen
        /// <summary>�n�C�t���t���i�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �n�C�t���t���i�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string OldPartsNoWithHyphen
        {
            get { return _oldPartsNoWithHyphen; }
            set { _oldPartsNoWithHyphen = value; }
        }

        /// public propaty name  :  NewPartsNoWithHyphen
        /// <summary>�n�C�t���t�V�i�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �n�C�t���t�V�i�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string NewPartsNoWithHyphen
        {
            get { return _newPartsNoWithHyphen; }
            set { _newPartsNoWithHyphen = value; }
        }

        /// public propaty name  :  NPrtNoWithHypnDspOdr
        /// <summary>�n�C�t���t�V�i�ԕ\�����ʃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �n�C�t���t�V�i�ԕ\�����ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 NPrtNoWithHypnDspOdr
        {
            get { return _nPrtNoWithHypnDspOdr; }
            set { _nPrtNoWithHypnDspOdr = value; }
        }

        /// public propaty name  :  PartsPluralSubstFlg
        /// <summary>���i������փt���O�v���p�e�B</summary>
        /// <value>0:������ւȂ� 1:������ւ���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i������փt���O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PartsPluralSubstFlg
        {
            get { return _partsPluralSubstFlg; }
            set { _partsPluralSubstFlg = value; }
        }

        /// public propaty name  :  MainOrSubPartsDivCd
        /// <summary>���C���E�T�u���i�敪�v���p�e�B</summary>
        /// <value>0:������ւȂ� 1:���C�� 2�`:�q</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���C���E�T�u���i�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MainOrSubPartsDivCd
        {
            get { return _mainOrSubPartsDivCd; }
            set { _mainOrSubPartsDivCd = value; }
        }

        /// public propaty name  :  PartsQty
        /// <summary>���iQTY�v���p�e�B</summary>
        /// <value>���C���E�T�u���i�敪��0�ȊO�̎��ɗL��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���iQTY�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double PartsQty
        {
            get { return _partsQty; }
            set { _partsQty = value; }
        }

        /// public propaty name  :  PartsPluralSubstCmnt
        /// <summary>���i������֓E�v�v���p�e�B</summary>
        /// <value>���C���E�T�u���i�敪��0�ȊO�̎��ɗL��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i������֓E�v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PartsPluralSubstCmnt
        {
            get { return _partsPluralSubstCmnt; }
            set { _partsPluralSubstCmnt = value; }
        }

        /// public propaty name  :  PlrlSubNewPrtNoHypn
        /// <summary>������֌��n�C�t���t�V�i�ԃv���p�e�B</summary>
        /// <value>���C���E�T�u���i�敪��0�ȊO�̎��ɗL��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������֌��n�C�t���t�V�i�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PlrlSubNewPrtNoHypn
        {
            get { return _plrlSubNewPrtNoHypn; }
            set { _plrlSubNewPrtNoHypn = value; }
        }

        /// public propaty name  :  NewPrtsNoNoneHyphen
        /// <summary>�n�C�t�����ŐV���i�i�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �n�C�t�����ŐV���i�i�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string NewPrtsNoNoneHyphen
        {
            get { return _newPrtsNoNoneHyphen; }
            set { _newPrtsNoNoneHyphen = value; }
        }

        /// public propaty name  :  TbsPartsCode
        /// <summary>�����i�R�[�h�v���p�e�B</summary>
        /// <value>1�`99999:�񋟕�,100000�`���[�U�[�o�^�p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����i�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TbsPartsCode
        {
            get { return _tbsPartsCode; }
            set { _tbsPartsCode = value; }
        }

        /// public propaty name  :  TbsPartsCdDerivedNo
        /// <summary>�����i�R�[�h�}�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����i�R�[�h�}�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TbsPartsCdDerivedNo
        {
            get { return _tbsPartsCdDerivedNo; }
            set { _tbsPartsCdDerivedNo = value; }
        }

        /// public propaty name  :  MakerOfferPartsName
        /// <summary>���[�J�[�񋟕��i���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[�񋟕��i���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MakerOfferPartsName
        {
            get { return _makerOfferPartsName; }
            set { _makerOfferPartsName = value; }
        }

        /// public propaty name  :  PartsPrice
        /// <summary>���i���i�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���i�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 PartsPrice
        {
            get { return _partsPrice; }
            set { _partsPrice = value; }
        }

        /// public propaty name  :  PartsPriceStDate
        /// <summary>���i���i�J�n���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���i�J�n���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime PartsPriceStDate
        {
            get { return _partsPriceStDate; }
            set { _partsPriceStDate = value; }
        }

        /// public propaty name  :  PartsLayerCd
        /// <summary>�w�ʃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �w�ʃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PartsLayerCd
        {
            get { return _partsLayerCd; }
            set { _partsLayerCd = value; }
        }

        /// public propaty name  :  PartsInfoCtrlFlg
        /// <summary>���i��񐧌�t���O�v���p�e�B</summary>
        /// <value>0:���ʕ��i 1:SF.NS��p���i(PM����̌����͕s�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i��񐧌�t���O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PartsInfoCtrlFlg
        {
            get { return _partsInfoCtrlFlg; }
            set { _partsInfoCtrlFlg = value; }
        }

        /// public propaty name  :  PartsName
        /// <summary>���i���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PartsName
        {
            get { return _partsName; }
            set { _partsName = value; }
        }

        /// public propaty name  :  PartsCode
        /// <summary>���i�敪�R�[�h�v���p�e�B</summary>
        /// <value>��ƕ��i�敪�}�X�^�̋敪�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�敪�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PartsCode
        {
            get { return _partsCode; }
            set { _partsCode = value; }
        }

        /// public propaty name  :  PartsSearchCode
        /// <summary>���i�����敪�v���p�e�B</summary>
        /// <value>0:���i���i��������,1:�ʏ핔�i���i����,2:���MT������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PartsSearchCode
        {
            get { return _partsSearchCode; }
            set { _partsSearchCode = value; }
        }

        /// public propaty name  :  OfferDate
        /// <summary>�񋟓��t�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񋟓��t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime OfferDate
        {
            get { return _offerDate; }
            set { _offerDate = value; }
        }

        /// public propaty name  :  PriceOfferDate
        /// <summary>���i�񋟓��t�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�񋟓��t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime PriceOfferDate
        {
            get { return _priceOfferDate; }
            set { _priceOfferDate = value; }
        }

        /// public propaty name  :  MakerOfferPartsKana
        /// <summary>���[�J�[�񋟕��i�J�i���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   </br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MakerOfferPartsKana
        {
            get { return _makerOfferPartsKana; }
            set { _makerOfferPartsKana = value; }
        }

        /// public propaty name  :  OpenPriceDiv
        /// <summary>�I�[�v�����i�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   </br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 OpenPriceDiv
        {
            get { return _openPriceDiv; }
            set { _openPriceDiv = value; }
        }

        /// <summary>
        /// ���i��փ��[�N�R���X�g���N�^
        /// </summary>
        /// <returns>PartsSubstWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PartsSubstWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PartsSubstWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>PartsSubstWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   PartsSubstWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class PartsSubstWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PartsSubstWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  PartsSubstWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is PartsSubstWork || graph is ArrayList || graph is PartsSubstWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(PartsSubstWork).FullName));

            if (graph != null && graph is PartsSubstWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.PartsSubstWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is PartsSubstWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((PartsSubstWork[])graph).Length;
            }
            else if (graph is PartsSubstWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�J�^���O���i���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //CatalogPartsMakerCd
            //�n�C�t���t���i��
            serInfo.MemberInfo.Add(typeof(string)); //OldPartsNoWithHyphen
            //�n�C�t���t�V�i��
            serInfo.MemberInfo.Add(typeof(string)); //NewPartsNoWithHyphen
            //�n�C�t���t�V�i�ԕ\������
            serInfo.MemberInfo.Add(typeof(Int32)); //NPrtNoWithHypnDspOdr
            //���i������փt���O
            serInfo.MemberInfo.Add(typeof(Int32)); //PartsPluralSubstFlg
            //���C���E�T�u���i�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //MainOrSubPartsDivCd
            //���iQTY
            serInfo.MemberInfo.Add(typeof(Double)); //PartsQty
            //���i������֓E�v
            serInfo.MemberInfo.Add(typeof(string)); //PartsPluralSubstCmnt
            //������֌��n�C�t���t�V�i��
            serInfo.MemberInfo.Add(typeof(string)); //PlrlSubNewPrtNoHypn
            //�n�C�t�����ŐV���i�i��
            serInfo.MemberInfo.Add(typeof(string)); //NewPrtsNoNoneHyphen
            //�����i�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //TbsPartsCode
            //�����i�R�[�h�}��
            serInfo.MemberInfo.Add(typeof(Int32)); //TbsPartsCdDerivedNo
            //���[�J�[�񋟕��i����
            serInfo.MemberInfo.Add(typeof(string)); //MakerOfferPartsName
            //���i���i
            serInfo.MemberInfo.Add(typeof(Int64)); //PartsPrice
            //���i���i�J�n��
            serInfo.MemberInfo.Add(typeof(Int64)); //PartsPriceStDate
            //�w�ʃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //PartsLayerCd
            //���i��񐧌�t���O
            serInfo.MemberInfo.Add(typeof(Int32)); //PartsInfoCtrlFlg
            //���i����
            serInfo.MemberInfo.Add(typeof(string)); //PartsName
            //���i�敪�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //PartsCode
            //���i�����敪
            serInfo.MemberInfo.Add(typeof(Int32)); //PartsSearchCode

            serInfo.MemberInfo.Add(typeof(Int64)); //OfferDate
            serInfo.MemberInfo.Add(typeof(Int64)); //PriceOfferDate

            serInfo.MemberInfo.Add(typeof(string));
            serInfo.MemberInfo.Add(typeof(Int32));

            serInfo.Serialize(writer, serInfo);
            if (graph is PartsSubstWork)
            {
                PartsSubstWork temp = (PartsSubstWork)graph;

                SetPartsSubstWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is PartsSubstWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((PartsSubstWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (PartsSubstWork temp in lst)
                {
                    SetPartsSubstWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// PartsSubstWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 24;

        /// <summary>
        ///  PartsSubstWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PartsSubstWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetPartsSubstWork(System.IO.BinaryWriter writer, PartsSubstWork temp)
        {
            //�J�^���O���i���[�J�[�R�[�h
            writer.Write(temp.CatalogPartsMakerCd);
            //�n�C�t���t���i��
            writer.Write(temp.OldPartsNoWithHyphen);
            //�n�C�t���t�V�i��
            writer.Write(temp.NewPartsNoWithHyphen);
            //�n�C�t���t�V�i�ԕ\������
            writer.Write(temp.NPrtNoWithHypnDspOdr);
            //���i������փt���O
            writer.Write(temp.PartsPluralSubstFlg);
            //���C���E�T�u���i�敪
            writer.Write(temp.MainOrSubPartsDivCd);
            //���iQTY
            writer.Write(temp.PartsQty);
            //���i������֓E�v
            writer.Write(temp.PartsPluralSubstCmnt);
            //������֌��n�C�t���t�V�i��
            writer.Write(temp.PlrlSubNewPrtNoHypn);
            //�n�C�t�����ŐV���i�i��
            writer.Write(temp.NewPrtsNoNoneHyphen);
            //�����i�R�[�h
            writer.Write(temp.TbsPartsCode);
            //�����i�R�[�h�}��
            writer.Write(temp.TbsPartsCdDerivedNo);
            //���[�J�[�񋟕��i����
            writer.Write(temp.MakerOfferPartsName);
            //���i���i
            writer.Write(temp.PartsPrice);
            //���i���i�J�n��
            writer.Write((Int64)temp.PartsPriceStDate.Ticks);
            //�w�ʃR�[�h
            writer.Write(temp.PartsLayerCd);
            //���i��񐧌�t���O
            writer.Write(temp.PartsInfoCtrlFlg);
            //���i����
            writer.Write(temp.PartsName);
            //���i�敪�R�[�h
            writer.Write(temp.PartsCode);
            //���i�����敪
            writer.Write(temp.PartsSearchCode);
            writer.Write(temp.OfferDate.Ticks);
            writer.Write(temp.PriceOfferDate.Ticks);
            writer.Write(temp.MakerOfferPartsKana);
            writer.Write(temp.OpenPriceDiv);
        }

        /// <summary>
        ///  PartsSubstWork�C���X�^���X�擾
        /// </summary>
        /// <returns>PartsSubstWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PartsSubstWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private PartsSubstWork GetPartsSubstWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            PartsSubstWork temp = new PartsSubstWork();

            //�J�^���O���i���[�J�[�R�[�h
            temp.CatalogPartsMakerCd = reader.ReadInt32();
            //�n�C�t���t���i��
            temp.OldPartsNoWithHyphen = reader.ReadString();
            //�n�C�t���t�V�i��
            temp.NewPartsNoWithHyphen = reader.ReadString();
            //�n�C�t���t�V�i�ԕ\������
            temp.NPrtNoWithHypnDspOdr = reader.ReadInt32();
            //���i������փt���O
            temp.PartsPluralSubstFlg = reader.ReadInt32();
            //���C���E�T�u���i�敪
            temp.MainOrSubPartsDivCd = reader.ReadInt32();
            //���iQTY
            temp.PartsQty = reader.ReadDouble();
            //���i������֓E�v
            temp.PartsPluralSubstCmnt = reader.ReadString();
            //������֌��n�C�t���t�V�i��
            temp.PlrlSubNewPrtNoHypn = reader.ReadString();
            //�n�C�t�����ŐV���i�i��
            temp.NewPrtsNoNoneHyphen = reader.ReadString();
            //�����i�R�[�h
            temp.TbsPartsCode = reader.ReadInt32();
            //�����i�R�[�h�}��
            temp.TbsPartsCdDerivedNo = reader.ReadInt32();
            //���[�J�[�񋟕��i����
            temp.MakerOfferPartsName = reader.ReadString();
            //���i���i
            temp.PartsPrice = reader.ReadInt64();
            //���i���i�J�n��
            temp.PartsPriceStDate = new DateTime(reader.ReadInt64());
            //�w�ʃR�[�h
            temp.PartsLayerCd = reader.ReadString();
            //���i��񐧌�t���O
            temp.PartsInfoCtrlFlg = reader.ReadInt32();
            //���i����
            temp.PartsName = reader.ReadString();
            //���i�敪�R�[�h
            temp.PartsCode = reader.ReadInt32();
            //���i�����敪
            temp.PartsSearchCode = reader.ReadInt32();

            temp.OfferDate = new DateTime(reader.ReadInt64());
            temp.PriceOfferDate = new DateTime(reader.ReadInt64());

            temp.MakerOfferPartsKana = reader.ReadString();
            temp.OpenPriceDiv = reader.ReadInt32();

            //�ȉ��͓ǂݔ�΂��ł��B���̃o�[�W�������z�肷�� EmployeeWork�^�ȍ~�̃o�[�W������
            //�f�[�^���f�V���A���C�Y����ꍇ�A�V���A���C�Y�����t�H�[�}�b�^���L�q����
            //�^���ɂ��������āA�X�g���[���������ǂݏo���܂�...�Ƃ����Ă�
            //�ǂݏo���Ď̂Ă邱�ƂɂȂ�܂��B
            for (int k = currentMemberCount; k < serInfo.MemberInfo.Count; ++k)
            {
                //byte[],char[]���f�V���A���C�Y���钼�O�ɁA����length��
                //�f�V���A���C�Y����Ă���P�[�X������Abyte[],char[]��
                //�f�V���A���C�Y�ɂ�length���K�v�Ȃ̂�int�^�̃f�[�^���f
                //�V���A���C�Y�����ꍇ�́A���̒l�����̕ϐ��ɑޔ����܂��B
                int optCount = 0;
                object oMemberType = serInfo.MemberInfo[k];
                if (oMemberType is Type)
                {
                    Type t = (Type)oMemberType;
                    object oData = TypeDeserializer.DeserializePrimitiveType(reader, t, optCount);
                    if (t.Equals(typeof(int)))
                    {
                        optCount = Convert.ToInt32(oData);
                    }
                    else
                    {
                        optCount = 0;
                    }
                }
                else if (oMemberType is string)
                {
                    Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate((string)oMemberType);
                    object userData = formatter.Deserialize(reader);  //�ǂݔ�΂�
                }
            }
            return temp;
        }

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���f�V���A���C�U�ł�
        /// </summary>
        /// <returns>PartsSubstWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PartsSubstWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                PartsSubstWork temp = GetPartsSubstWork(reader, serInfo);
                lst.Add(temp);
            }
            switch (serInfo.RetTypeInfo)
            {
                case 0:
                    retValue = lst;
                    break;
                case 1:
                    retValue = lst[0];
                    break;
                case 2:
                    retValue = (PartsSubstWork[])lst.ToArray(typeof(PartsSubstWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }

}

//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���i�i�e�L�X�g�ϊ��j
// �v���O�����T�v   : ���i�i�e�L�X�g�ϊ��j���[�N
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10902160-00  �쐬�S�� : ���z
// �� �� ��  K2013/08/08  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   GoodsTextExpWork
    /// <summary>
    ///                      ���i�i�e�L�X�g�ϊ��j���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���i�i�e�L�X�g�ϊ��j���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2013/8/8</br>
    /// <br>Genarated Date   :   2013/09/04  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class GoodsTextExpWork
    {
        /// <summary>�J�n���i�ԍ�</summary>
        private string _goodsNoSt = "";

        /// <summary>�I�����i�ԍ�</summary>
        private string _goodsNoEd = "";

        /// <summary>�J�n���i���[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCdSt;

        /// <summary>�I�����i���[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCdEd;

        /// <summary>�J�nBL���i�R�[�h</summary>
        private Int32 _bLGoodsCodeSt;

        /// <summary>�I��BL���i�R�[�h</summary>
        private Int32 _bLGoodsCodeEd;

        /// <summary>�J�n�o�^���t</summary>
        private Int32 _updateDateSt;

        /// <summary>�I���o�^���t</summary>
        private Int32 _updateDateEd;

        /// <summary>���i�J�n��</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _priceStartDate;

        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";


        /// public propaty name  :  GoodsNoSt
        /// <summary>�J�n���i�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���i�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNoSt
        {
            get { return _goodsNoSt; }
            set { _goodsNoSt = value; }
        }

        /// public propaty name  :  GoodsNoEd
        /// <summary>�I�����i�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����i�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNoEd
        {
            get { return _goodsNoEd; }
            set { _goodsNoEd = value; }
        }

        /// public propaty name  :  GoodsMakerCdSt
        /// <summary>�J�n���i���[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���i���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMakerCdSt
        {
            get { return _goodsMakerCdSt; }
            set { _goodsMakerCdSt = value; }
        }

        /// public propaty name  :  GoodsMakerCdEd
        /// <summary>�I�����i���[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����i���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMakerCdEd
        {
            get { return _goodsMakerCdEd; }
            set { _goodsMakerCdEd = value; }
        }

        /// public propaty name  :  BLGoodsCodeSt
        /// <summary>�J�nBL���i�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�nBL���i�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGoodsCodeSt
        {
            get { return _bLGoodsCodeSt; }
            set { _bLGoodsCodeSt = value; }
        }

        /// public propaty name  :  BLGoodsCodeEd
        /// <summary>�I��BL���i�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I��BL���i�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGoodsCodeEd
        {
            get { return _bLGoodsCodeEd; }
            set { _bLGoodsCodeEd = value; }
        }

        /// public propaty name  :  UpdateDateSt
        /// <summary>�J�n�o�^���t�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�o�^���t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UpdateDateSt
        {
            get { return _updateDateSt; }
            set { _updateDateSt = value; }
        }

        /// public propaty name  :  UpdateDateEd
        /// <summary>�I���o�^���t�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���o�^���t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UpdateDateEd
        {
            get { return _updateDateEd; }
            set { _updateDateEd = value; }
        }

        /// public propaty name  :  PriceStartDate
        /// <summary>���i�J�n���v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�J�n���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PriceStartDate
        {
            get { return _priceStartDate; }
            set { _priceStartDate = value; }
        }

        /// public propaty name  :  EnterpriseCode
        /// <summary>��ƃR�[�h�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��ƃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }


        /// <summary>
        /// ���i�i�e�L�X�g�ϊ��j���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>GoodsTextExpWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   GoodsTextExpWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public GoodsTextExpWork()
        {
        }

        /// <summary>
        /// ���i�i�e�L�X�g�ϊ��j���[�N�R���X�g���N�^
        /// </summary>
        /// <param name="goodsNoSt">�J�n���i�ԍ�</param>
        /// <param name="goodsNoEd">�I�����i�ԍ�</param>
        /// <param name="goodsMakerCdSt">�J�n���i���[�J�[�R�[�h</param>
        /// <param name="goodsMakerCdEd">�I�����i���[�J�[�R�[�h</param>
        /// <param name="bLGoodsCodeSt">�J�nBL���i�R�[�h</param>
        /// <param name="bLGoodsCodeEd">�I��BL���i�R�[�h</param>
        /// <param name="updateDateSt">�J�n�o�^���t</param>
        /// <param name="updateDateEd">�I���o�^���t</param>
        /// <param name="priceStartDate">���i�J�n��(YYYYMMDD)</param>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <returns>GoodsTextExpWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   GoodsTextExpWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public GoodsTextExpWork(string goodsNoSt, string goodsNoEd, Int32 goodsMakerCdSt, Int32 goodsMakerCdEd, Int32 bLGoodsCodeSt, Int32 bLGoodsCodeEd, Int32 updateDateSt, Int32 updateDateEd, Int32 priceStartDate, string enterpriseCode)
        {
            this._goodsNoSt = goodsNoSt;
            this._goodsNoEd = goodsNoEd;
            this._goodsMakerCdSt = goodsMakerCdSt;
            this._goodsMakerCdEd = goodsMakerCdEd;
            this._bLGoodsCodeSt = bLGoodsCodeSt;
            this._bLGoodsCodeEd = bLGoodsCodeEd;
            this._updateDateSt = updateDateSt;
            this._updateDateEd = updateDateEd;
            this._priceStartDate = priceStartDate;
            this._enterpriseCode = enterpriseCode;

        }

        /// <summary>
        /// ���i�i�e�L�X�g�ϊ��j���[�N��������
        /// </summary>
        /// <returns>GoodsTextExpWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����GoodsTextExpWork�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public GoodsTextExpWork Clone()
        {
            return new GoodsTextExpWork(this._goodsNoSt, this._goodsNoEd, this._goodsMakerCdSt, this._goodsMakerCdEd, this._bLGoodsCodeSt, this._bLGoodsCodeEd, this._updateDateSt, this._updateDateEd, this._priceStartDate, this._enterpriseCode);
        }

        /// <summary>
        /// ���i�i�e�L�X�g�ϊ��j���[�N��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�GoodsTextExpWork�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   GoodsTextExpWork�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(GoodsTextExpWork target)
        {
            return ((this.GoodsNoSt == target.GoodsNoSt)
                 && (this.GoodsNoEd == target.GoodsNoEd)
                 && (this.GoodsMakerCdSt == target.GoodsMakerCdSt)
                 && (this.GoodsMakerCdEd == target.GoodsMakerCdEd)
                 && (this.BLGoodsCodeSt == target.BLGoodsCodeSt)
                 && (this.BLGoodsCodeEd == target.BLGoodsCodeEd)
                 && (this.UpdateDateSt == target.UpdateDateSt)
                 && (this.UpdateDateEd == target.UpdateDateEd)
                 && (this.PriceStartDate == target.PriceStartDate)
                 && (this.EnterpriseCode == target.EnterpriseCode));
        }

        /// <summary>
        /// ���i�i�e�L�X�g�ϊ��j���[�N��r����
        /// </summary>
        /// <param name="goodsTextExp1">
        ///                    ��r����GoodsTextExpWork�N���X�̃C���X�^���X
        /// </param>
        /// <param name="goodsTextExp2">��r����GoodsTextExpWork�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   GoodsTextExpWork�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(GoodsTextExpWork goodsTextExp1, GoodsTextExpWork goodsTextExp2)
        {
            return ((goodsTextExp1.GoodsNoSt == goodsTextExp2.GoodsNoSt)
                 && (goodsTextExp1.GoodsNoEd == goodsTextExp2.GoodsNoEd)
                 && (goodsTextExp1.GoodsMakerCdSt == goodsTextExp2.GoodsMakerCdSt)
                 && (goodsTextExp1.GoodsMakerCdEd == goodsTextExp2.GoodsMakerCdEd)
                 && (goodsTextExp1.BLGoodsCodeSt == goodsTextExp2.BLGoodsCodeSt)
                 && (goodsTextExp1.BLGoodsCodeEd == goodsTextExp2.BLGoodsCodeEd)
                 && (goodsTextExp1.UpdateDateSt == goodsTextExp2.UpdateDateSt)
                 && (goodsTextExp1.UpdateDateEd == goodsTextExp2.UpdateDateEd)
                 && (goodsTextExp1.PriceStartDate == goodsTextExp2.PriceStartDate)
                 && (goodsTextExp1.EnterpriseCode == goodsTextExp2.EnterpriseCode));
        }
        /// <summary>
        /// ���i�i�e�L�X�g�ϊ��j���[�N��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�GoodsTextExpWork�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   GoodsTextExpWork�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(GoodsTextExpWork target)
        {
            ArrayList resList = new ArrayList();
            if (this.GoodsNoSt != target.GoodsNoSt) resList.Add("GoodsNoSt");
            if (this.GoodsNoEd != target.GoodsNoEd) resList.Add("GoodsNoEd");
            if (this.GoodsMakerCdSt != target.GoodsMakerCdSt) resList.Add("GoodsMakerCdSt");
            if (this.GoodsMakerCdEd != target.GoodsMakerCdEd) resList.Add("GoodsMakerCdEd");
            if (this.BLGoodsCodeSt != target.BLGoodsCodeSt) resList.Add("BLGoodsCodeSt");
            if (this.BLGoodsCodeEd != target.BLGoodsCodeEd) resList.Add("BLGoodsCodeEd");
            if (this.UpdateDateSt != target.UpdateDateSt) resList.Add("UpdateDateSt");
            if (this.UpdateDateEd != target.UpdateDateEd) resList.Add("UpdateDateEd");
            if (this.PriceStartDate != target.PriceStartDate) resList.Add("PriceStartDate");
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");

            return resList;
        }

        /// <summary>
        /// ���i�i�e�L�X�g�ϊ��j���[�N��r����
        /// </summary>
        /// <param name="goodsTextExp1">��r����GoodsTextExpWork�N���X�̃C���X�^���X</param>
        /// <param name="goodsTextExp2">��r����GoodsTextExpWork�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   GoodsTextExpWork�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(GoodsTextExpWork goodsTextExp1, GoodsTextExpWork goodsTextExp2)
        {
            ArrayList resList = new ArrayList();
            if (goodsTextExp1.GoodsNoSt != goodsTextExp2.GoodsNoSt) resList.Add("GoodsNoSt");
            if (goodsTextExp1.GoodsNoEd != goodsTextExp2.GoodsNoEd) resList.Add("GoodsNoEd");
            if (goodsTextExp1.GoodsMakerCdSt != goodsTextExp2.GoodsMakerCdSt) resList.Add("GoodsMakerCdSt");
            if (goodsTextExp1.GoodsMakerCdEd != goodsTextExp2.GoodsMakerCdEd) resList.Add("GoodsMakerCdEd");
            if (goodsTextExp1.BLGoodsCodeSt != goodsTextExp2.BLGoodsCodeSt) resList.Add("BLGoodsCodeSt");
            if (goodsTextExp1.BLGoodsCodeEd != goodsTextExp2.BLGoodsCodeEd) resList.Add("BLGoodsCodeEd");
            if (goodsTextExp1.UpdateDateSt != goodsTextExp2.UpdateDateSt) resList.Add("UpdateDateSt");
            if (goodsTextExp1.UpdateDateEd != goodsTextExp2.UpdateDateEd) resList.Add("UpdateDateEd");
            if (goodsTextExp1.PriceStartDate != goodsTextExp2.PriceStartDate) resList.Add("PriceStartDate");
            if (goodsTextExp1.EnterpriseCode != goodsTextExp2.EnterpriseCode) resList.Add("EnterpriseCode");

            return resList;
        }
    }
    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>GoodsTextExpWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   GoodsTextExpWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class GoodsTextExpWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   GoodsTextExpWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  GoodsTextExpWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is GoodsTextExpWork || graph is ArrayList || graph is GoodsTextExpWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(GoodsTextExpWork).FullName));

            if (graph != null && graph is GoodsTextExpWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.GoodsTextExpWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is GoodsTextExpWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((GoodsTextExpWork[])graph).Length;
            }
            else if (graph is GoodsTextExpWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�J�n���i�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNoSt
            //�I�����i�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNoEd
            //�J�n���i���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCdSt
            //�I�����i���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCdEd
            //�J�nBL���i�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCodeSt
            //�I��BL���i�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCodeEd
            //�J�n�o�^���t
            serInfo.MemberInfo.Add(typeof(Int32)); //UpdateDateSt
            //�I���o�^���t
            serInfo.MemberInfo.Add(typeof(Int32)); //UpdateDateEd
            //���i�J�n��
            serInfo.MemberInfo.Add(typeof(Int32)); //PriceStartDate
            //��ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode


            serInfo.Serialize(writer, serInfo);
            if (graph is GoodsTextExpWork)
            {
                GoodsTextExpWork temp = (GoodsTextExpWork)graph;

                SetGoodsTextExpWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is GoodsTextExpWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((GoodsTextExpWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (GoodsTextExpWork temp in lst)
                {
                    SetGoodsTextExpWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// GoodsTextExpWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 10;

        /// <summary>
        ///  GoodsTextExpWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   GoodsTextExpWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetGoodsTextExpWork(System.IO.BinaryWriter writer, GoodsTextExpWork temp)
        {
            //�J�n���i�ԍ�
            writer.Write(temp.GoodsNoSt);
            //�I�����i�ԍ�
            writer.Write(temp.GoodsNoEd);
            //�J�n���i���[�J�[�R�[�h
            writer.Write(temp.GoodsMakerCdSt);
            //�I�����i���[�J�[�R�[�h
            writer.Write(temp.GoodsMakerCdEd);
            //�J�nBL���i�R�[�h
            writer.Write(temp.BLGoodsCodeSt);
            //�I��BL���i�R�[�h
            writer.Write(temp.BLGoodsCodeEd);
            //�J�n�o�^���t
            writer.Write(temp.UpdateDateSt);
            //�I���o�^���t
            writer.Write(temp.UpdateDateEd);
            //���i�J�n��
            writer.Write(temp.PriceStartDate);
            //��ƃR�[�h
            writer.Write(temp.EnterpriseCode);

        }

        /// <summary>
        ///  GoodsTextExpWork�C���X�^���X�擾
        /// </summary>
        /// <returns>GoodsTextExpWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   GoodsTextExpWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private GoodsTextExpWork GetGoodsTextExpWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            GoodsTextExpWork temp = new GoodsTextExpWork();

            //�J�n���i�ԍ�
            temp.GoodsNoSt = reader.ReadString();
            //�I�����i�ԍ�
            temp.GoodsNoEd = reader.ReadString();
            //�J�n���i���[�J�[�R�[�h
            temp.GoodsMakerCdSt = reader.ReadInt32();
            //�I�����i���[�J�[�R�[�h
            temp.GoodsMakerCdEd = reader.ReadInt32();
            //�J�nBL���i�R�[�h
            temp.BLGoodsCodeSt = reader.ReadInt32();
            //�I��BL���i�R�[�h
            temp.BLGoodsCodeEd = reader.ReadInt32();
            //�J�n�o�^���t
            temp.UpdateDateSt = reader.ReadInt32();
            //�I���o�^���t
            temp.UpdateDateEd = reader.ReadInt32();
            //���i�J�n��
            temp.PriceStartDate = reader.ReadInt32();
            //��ƃR�[�h
            temp.EnterpriseCode = reader.ReadString();


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
        /// <returns>GoodsTextExpWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   GoodsTextExpWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                GoodsTextExpWork temp = GetGoodsTextExpWork(reader, serInfo);
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
                    retValue = (GoodsTextExpWork[])lst.ToArray(typeof(GoodsTextExpWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}


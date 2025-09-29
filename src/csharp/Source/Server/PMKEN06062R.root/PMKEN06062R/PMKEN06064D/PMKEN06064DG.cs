using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   GoodsUCndtnWork
    /// <summary>
    ///                      ���i���o�����N���X���[�N���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���i���o�����N���X���[�N���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/06/12  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2015/08/17 �c����</br>
    /// <br>�Ǘ��ԍ�         :   11170052-00</br>
    /// <br>                 :   Redmine#47036 ���i�݌Ɉꊇ�o�^�C�� �Ǘ����_�E�q�ɂ̒ǉ�</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class GoodsUCndtnWork
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>���i���[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCd;

        /// <summary>���i�ԍ�</summary>
        private string _goodsNo = "";

        /// <summary>���i�ԍ������敪</summary>
        /// <remarks>0:���S��v,1:�O����v����,2:�����v����,3:�B������</remarks>
        private Int32 _goodsNoSrchTyp;

        /// <summary>���i����</summary>
        private string _goodsName = "";

        /// <summary>���i���̌����敪</summary>
        /// <remarks>0:���S��v,1:�O����v����,2:�����v����,3:�B������</remarks>
        private Int32 _goodsNameSrchTyp;

        /// <summary>���i���̃J�i</summary>
        private string _goodsNameKana = "";

        /// <summary>���i�J�i���̌����敪</summary>
        /// <remarks>0:���S��v,1:�O����v����,2:�����v����,3:�B������</remarks>
        private Int32 _goodsNameKanaSrchTyp;

        /// <summary>JAN�R�[�h</summary>
        /// <remarks>�W���^�C�v13���܂��͒Z�k�^�C�v8����JAN�R�[�h</remarks>
        private string _jan = "";

        /// <summary>BL���i�R�[�h</summary>
        private Int32 _bLGoodsCode;

        /// <summary>���i�啪�ރR�[�h</summary>
        /// <remarks>���啪�ށi���[�U�[�K�C�h�j</remarks>
        private Int32 _goodsLGroup;

        /// <summary>���i�����ރR�[�h</summary>
        /// <remarks>�������ށi�}�X�^�L�j</remarks>
        private Int32 _goodsMGroup;

        /// <summary>BL�O���[�v�R�[�h</summary>
        /// <remarks>���O���[�v�R�[�h</remarks>
        private Int32 _bLGroupCode;

        /// <summary>���i����</summary>
        private Int32 _goodsKindCode;

        //----- ADD 2015/08/17 �c���� Redmine#47036 ---------->>>>>
        /// <summary>�Ǘ����_�R�[�h</summary>
        private string _addUpSectionCode = "";

        /// <summary>�q�ɃR�[�h</summary>
        private string _warehouseCode = "";
        //----- ADD 2015/08/17 �c���� Redmine#47036 ----------<<<<<


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

        /// public propaty name  :  GoodsMakerCd
        /// <summary>���i���[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMakerCd
        {
            get { return _goodsMakerCd; }
            set { _goodsMakerCd = value; }
        }

        /// public propaty name  :  GoodsNo
        /// <summary>���i�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNo
        {
            get { return _goodsNo; }
            set { _goodsNo = value; }
        }

        /// public propaty name  :  GoodsNoSrchTyp
        /// <summary>���i�ԍ������敪�v���p�e�B</summary>
        /// <value>0:���S��v,1:�O����v����,2:�����v����,3:�B������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�ԍ������敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsNoSrchTyp
        {
            get { return _goodsNoSrchTyp; }
            set { _goodsNoSrchTyp = value; }
        }

        /// public propaty name  :  GoodsName
        /// <summary>���i���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsName
        {
            get { return _goodsName; }
            set { _goodsName = value; }
        }

        /// public propaty name  :  GoodsNameSrchTyp
        /// <summary>���i���̌����敪�v���p�e�B</summary>
        /// <value>0:���S��v,1:�O����v����,2:�����v����,3:�B������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���̌����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsNameSrchTyp
        {
            get { return _goodsNameSrchTyp; }
            set { _goodsNameSrchTyp = value; }
        }

        /// public propaty name  :  GoodsNameKana
        /// <summary>���i���̃J�i�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���̃J�i�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNameKana
        {
            get { return _goodsNameKana; }
            set { _goodsNameKana = value; }
        }

        /// public propaty name  :  GoodsNameKanaSrchTyp
        /// <summary>���i�J�i���̌����敪�v���p�e�B</summary>
        /// <value>0:���S��v,1:�O����v����,2:�����v����,3:�B������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�J�i���̌����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsNameKanaSrchTyp
        {
            get { return _goodsNameKanaSrchTyp; }
            set { _goodsNameKanaSrchTyp = value; }
        }

        /// public propaty name  :  Jan
        /// <summary>JAN�R�[�h�v���p�e�B</summary>
        /// <value>�W���^�C�v13���܂��͒Z�k�^�C�v8����JAN�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   JAN�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Jan
        {
            get { return _jan; }
            set { _jan = value; }
        }

        /// public propaty name  :  BLGoodsCode
        /// <summary>BL���i�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL���i�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGoodsCode
        {
            get { return _bLGoodsCode; }
            set { _bLGoodsCode = value; }
        }

        /// public propaty name  :  GoodsLGroup
        /// <summary>���i�啪�ރR�[�h�v���p�e�B</summary>
        /// <value>���啪�ށi���[�U�[�K�C�h�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�啪�ރR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsLGroup
        {
            get { return _goodsLGroup; }
            set { _goodsLGroup = value; }
        }

        /// public propaty name  :  GoodsMGroup
        /// <summary>���i�����ރR�[�h�v���p�e�B</summary>
        /// <value>�������ށi�}�X�^�L�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�����ރR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMGroup
        {
            get { return _goodsMGroup; }
            set { _goodsMGroup = value; }
        }

        /// public propaty name  :  BLGroupCode
        /// <summary>BL�O���[�v�R�[�h�v���p�e�B</summary>
        /// <value>���O���[�v�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�O���[�v�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGroupCode
        {
            get { return _bLGroupCode; }
            set { _bLGroupCode = value; }
        }

        /// public propaty name  :  GoodsKindCode
        /// <summary>���i�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsKindCode
        {
            get { return _goodsKindCode; }
            set { _goodsKindCode = value; }
        }

        //----- ADD 2015/08/17 �c���� Redmine#47036 ---------->>>>>
        /// public propaty name  :  AddUpSectionCode
        /// <summary>�Ǘ����_�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ǘ����_�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AddUpSectionCode
        {
            get { return _addUpSectionCode; }
            set { _addUpSectionCode = value; }
        }

        /// public propaty name  :  WarehouseCode
        /// <summary>�q�ɃR�[�h���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɃR�[�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseCode
        {
            get { return _warehouseCode; }
            set { _warehouseCode = value; }
        }
        //----- ADD 2015/08/17 �c���� Redmine#47036 ----------<<<<<


        /// <summary>
        /// ���i���o�����N���X���[�N���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>GoodsUCndtnWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   GoodsUCndtnWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public GoodsUCndtnWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>GoodsUCndtnWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   GoodsUCndtnWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// <br>Update Note      :   2015/08/17 �c����</br>
    /// <br>�Ǘ��ԍ�         :   11170052-00</br>
    /// <br>                 :   Redmine#47036 ���i�݌Ɉꊇ�o�^�C�� �Ǘ����_�E�q�ɂ̒ǉ�</br>
    /// </remarks>
    public class GoodsUCndtnWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   GoodsUCndtnWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  GoodsUCndtnWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is GoodsUCndtnWork || graph is ArrayList || graph is GoodsUCndtnWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(GoodsUCndtnWork).FullName));

            if (graph != null && graph is GoodsUCndtnWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.GoodsUCndtnWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is GoodsUCndtnWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((GoodsUCndtnWork[])graph).Length;
            }
            else if (graph is GoodsUCndtnWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //��ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //���i���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //���i�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //���i�ԍ������敪
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsNoSrchTyp
            //���i����
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            //���i���̌����敪
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsNameSrchTyp
            //���i���̃J�i
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNameKana
            //���i�J�i���̌����敪
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsNameKanaSrchTyp
            //JAN�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //Jan
            //BL���i�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //���i�啪�ރR�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsLGroup
            //���i�����ރR�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMGroup
            //BL�O���[�v�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGroupCode
            //���i����
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsKindCode
            //----- ADD 2015/08/17 �c���� Redmine#47036 ---------->>>>>
            //�Ǘ����_
            serInfo.MemberInfo.Add(typeof(string)); //AddUpSectionCode
            //�q�ɃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseCode
            //----- ADD 2015/08/17 �c���� Redmine#47036 ----------<<<<<


            serInfo.Serialize(writer, serInfo);
            if (graph is GoodsUCndtnWork)
            {
                GoodsUCndtnWork temp = (GoodsUCndtnWork)graph;

                SetGoodsUCndtnWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is GoodsUCndtnWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((GoodsUCndtnWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (GoodsUCndtnWork temp in lst)
                {
                    SetGoodsUCndtnWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// GoodsUCndtnWork�����o��(public�v���p�e�B��)
        /// </summary>
        //private const int currentMemberCount = 14; // DEL 2015/08/17 �c���� Redmine#47036
        private const int currentMemberCount = 16; // ADD 2015/08/17 �c���� Redmine#47036

        /// <summary>
        ///  GoodsUCndtnWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   GoodsUCndtnWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   2015/08/17 �c����</br>
        /// <br>�Ǘ��ԍ�         :   11170052-00</br>
        /// <br>                 :   Redmine#47036 ���i�݌Ɉꊇ�o�^�C�� �Ǘ����_�E�q�ɂ̒ǉ�</br>
        /// </remarks>
        private void SetGoodsUCndtnWork(System.IO.BinaryWriter writer, GoodsUCndtnWork temp)
        {
            //��ƃR�[�h
            writer.Write(temp.EnterpriseCode);
            //���i���[�J�[�R�[�h
            writer.Write(temp.GoodsMakerCd);
            //���i�ԍ�
            writer.Write(temp.GoodsNo);
            //���i�ԍ������敪
            writer.Write(temp.GoodsNoSrchTyp);
            //���i����
            writer.Write(temp.GoodsName);
            //���i���̌����敪
            writer.Write(temp.GoodsNameSrchTyp);
            //���i���̃J�i
            writer.Write(temp.GoodsNameKana);
            //���i�J�i���̌����敪
            writer.Write(temp.GoodsNameKanaSrchTyp);
            //JAN�R�[�h
            writer.Write(temp.Jan);
            //BL���i�R�[�h
            writer.Write(temp.BLGoodsCode);
            //���i�啪�ރR�[�h
            writer.Write(temp.GoodsLGroup);
            //���i�����ރR�[�h
            writer.Write(temp.GoodsMGroup);
            //BL�O���[�v�R�[�h
            writer.Write(temp.BLGroupCode);
            //���i����
            writer.Write(temp.GoodsKindCode);
            //----- ADD 2015/08/17 �c���� Redmine#47036 ---------->>>>>
            //�Ǘ����_
            writer.Write(temp.AddUpSectionCode);
            //�q�ɃR�[�h
            writer.Write(temp.WarehouseCode);
            //----- ADD 2015/08/17 �c���� Redmine#47036 ----------<<<<<

        }

        /// <summary>
        ///  GoodsUCndtnWork�C���X�^���X�擾
        /// </summary>
        /// <returns>GoodsUCndtnWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   GoodsUCndtnWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// <br>Update Note      :   2015/08/17 �c����</br>
        /// <br>�Ǘ��ԍ�         :   11170052-00</br>
        /// <br>                 :   Redmine#47036 ���i�݌Ɉꊇ�o�^�C�� �Ǘ����_�E�q�ɂ̒ǉ�</br>
        /// </remarks>
        private GoodsUCndtnWork GetGoodsUCndtnWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            GoodsUCndtnWork temp = new GoodsUCndtnWork();

            //��ƃR�[�h
            temp.EnterpriseCode = reader.ReadString();
            //���i���[�J�[�R�[�h
            temp.GoodsMakerCd = reader.ReadInt32();
            //���i�ԍ�
            temp.GoodsNo = reader.ReadString();
            //���i�ԍ������敪
            temp.GoodsNoSrchTyp = reader.ReadInt32();
            //���i����
            temp.GoodsName = reader.ReadString();
            //���i���̌����敪
            temp.GoodsNameSrchTyp = reader.ReadInt32();
            //���i���̃J�i
            temp.GoodsNameKana = reader.ReadString();
            //���i�J�i���̌����敪
            temp.GoodsNameKanaSrchTyp = reader.ReadInt32();
            //JAN�R�[�h
            temp.Jan = reader.ReadString();
            //BL���i�R�[�h
            temp.BLGoodsCode = reader.ReadInt32();
            //���i�啪�ރR�[�h
            temp.GoodsLGroup = reader.ReadInt32();
            //���i�����ރR�[�h
            temp.GoodsMGroup = reader.ReadInt32();
            //BL�O���[�v�R�[�h
            temp.BLGroupCode = reader.ReadInt32();
            //���i����
            temp.GoodsKindCode = reader.ReadInt32();
            //----- ADD 2015/08/17 �c���� Redmine#47036 ---------->>>>>
            //�Ǘ����_
            temp.AddUpSectionCode = reader.ReadString();
            //�q�ɃR�[�h
            temp.WarehouseCode = reader.ReadString();
            //----- ADD 2015/08/17 �c���� Redmine#47036 ----------<<<<<


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
        /// <returns>GoodsUCndtnWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   GoodsUCndtnWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                GoodsUCndtnWork temp = GetGoodsUCndtnWork(reader, serInfo);
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
                    retValue = (GoodsUCndtnWork[])lst.ToArray(typeof(GoodsUCndtnWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}

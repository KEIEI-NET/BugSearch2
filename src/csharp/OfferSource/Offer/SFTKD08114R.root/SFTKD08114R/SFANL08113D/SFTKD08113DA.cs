using System;
using System.Collections;

using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   PrtItemGrpWork
	/// <summary>
	///                      �󎚍��ڃO���[�v���[�N
	/// </summary>
	/// <remarks>
	/// <br>note             :   �󎚍��ڃO���[�v���[�N�w�b�_�t�@�C��</br>
	/// <br>Programmer       :   ��������</br>
	/// <br>Date             :   2007/03/15</br>
	/// <br>Genarated Date   :   2007/10/12  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class PrtItemGrpWork : IFileHeaderOffer
	{
		/// <summary>�쐬����</summary>
		/// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
		private DateTime _createDateTime;

		/// <summary>�X�V����</summary>
		/// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
		private DateTime _updateDateTime;

		/// <summary>�_���폜�敪</summary>
		/// <remarks>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</remarks>
		private Int32 _logicalDeleteCode;

		/// <summary>���R���[���ڃO���[�v�R�[�h</summary>
		private Int32 _freePrtPprItemGrpCd;

		/// <summary>���R���[���ڃO���[�v����</summary>
		private string _freePrtPprItemGrpNm = "";

		/// <summary>���[�g�p�敪</summary>
		/// <remarks>1:���[,2:�`�[,3:DM�ꗗ�\,4:DM�͂���</remarks>
		private Int32 _printPaperUseDivcd;

		/// <summary>���o�v���O����ID</summary>
		private string _extractionPgId = "";

		/// <summary>���o�v���O�����N���XID</summary>
		/// <remarks>����v���O����ID or �e�L�X�g�o�̓v���O����ID</remarks>
		private string _extractionPgClassId = "";

		/// <summary>�o�̓v���O����ID</summary>
		private string _outputPgId = "";

		/// <summary>�o�̓v���O�����N���XID</summary>
		private string _outputPgClassId = "";

		/// <summary>�f�[�^���̓V�X�e��</summary>
		/// <remarks>0:����,1:����,2:���,3:�Ԕ�</remarks>
		private Int32 _dataInputSystem;

		/// <summary>�����N�`�[�f�[�^���̓V�X�e��</summary>
		/// <remarks>0:����,1:����,2:���,3:�Ԕ�</remarks>
		private Int32 _linkSlipDataInputSys;

		/// <summary>�����N�`�[������</summary>
		private Int32 _linkSlipPrtKind;

		/// <summary>�����N�`�[����ݒ�p���[ID</summary>
		private string _linkSlipPrtSetPprId = "";

		/// <summary>���o���_��ʋ敪</summary>
		/// <remarks>0:�g�p���Ȃ� 1:���сE���� 2:�d���E�̔�</remarks>
		private Int32 _extraSectionKindCd;

		/// <summary>���o���_�I��L��</summary>
		/// <remarks>0:�g�p���Ȃ� 1:�g�p����(�����I��) 2:�g�p����(�P�̑I��)</remarks>
		private Int32 _extraSectionSelExist;

		/// <summary>���ōs��</summary>
		private Int32 _formFeedLineCount;

		/// <summary>���s������</summary>
		/// <remarks>���`�[�ō�ƁE���i���̂̉��s������</remarks>
		private Int32 _crCharCnt;

		/// <summary>���R���[ ����p�r�敪</summary>
		/// <remarks>0:�g�p���Ȃ�,1:�ē�������^�C�v,2:��p���[,3:�����͂���</remarks>
		private Int32 _freePrtPprSpPrpseCd;


		/// public propaty name  :  CreateDateTime
		/// <summary>�쐬�����v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �쐬�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime CreateDateTime
		{
			get { return _createDateTime; }
			set { _createDateTime = value; }
		}

		/// public propaty name  :  UpdateDateTime
		/// <summary>�X�V�����v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �X�V�����v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public DateTime UpdateDateTime
		{
			get { return _updateDateTime; }
			set { _updateDateTime = value; }
		}

		/// public propaty name  :  LogicalDeleteCode
		/// <summary>�_���폜�敪�v���p�e�B</summary>
		/// <value>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �_���폜�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 LogicalDeleteCode
		{
			get { return _logicalDeleteCode; }
			set { _logicalDeleteCode = value; }
		}

		/// public propaty name  :  FreePrtPprItemGrpCd
		/// <summary>���R���[���ڃO���[�v�R�[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���R���[���ڃO���[�v�R�[�h�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 FreePrtPprItemGrpCd
		{
			get { return _freePrtPprItemGrpCd; }
			set { _freePrtPprItemGrpCd = value; }
		}

		/// public propaty name  :  FreePrtPprItemGrpNm
		/// <summary>���R���[���ڃO���[�v���̃v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���R���[���ڃO���[�v���̃v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string FreePrtPprItemGrpNm
		{
			get { return _freePrtPprItemGrpNm; }
			set { _freePrtPprItemGrpNm = value; }
		}

		/// public propaty name  :  PrintPaperUseDivcd
		/// <summary>���[�g�p�敪�v���p�e�B</summary>
		/// <value>1:���[,2:�`�[,3:DM�ꗗ�\,4:DM�͂���</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���[�g�p�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 PrintPaperUseDivcd
		{
			get { return _printPaperUseDivcd; }
			set { _printPaperUseDivcd = value; }
		}

		/// public propaty name  :  ExtractionPgId
		/// <summary>���o�v���O����ID�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���o�v���O����ID�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string ExtractionPgId
		{
			get { return _extractionPgId; }
			set { _extractionPgId = value; }
		}

		/// public propaty name  :  ExtractionPgClassId
		/// <summary>���o�v���O�����N���XID�v���p�e�B</summary>
		/// <value>����v���O����ID or �e�L�X�g�o�̓v���O����ID</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���o�v���O�����N���XID�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string ExtractionPgClassId
		{
			get { return _extractionPgClassId; }
			set { _extractionPgClassId = value; }
		}

		/// public propaty name  :  OutputPgId
		/// <summary>�o�̓v���O����ID�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �o�̓v���O����ID�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string OutputPgId
		{
			get { return _outputPgId; }
			set { _outputPgId = value; }
		}

		/// public propaty name  :  OutputPgClassId
		/// <summary>�o�̓v���O�����N���XID�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �o�̓v���O�����N���XID�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string OutputPgClassId
		{
			get { return _outputPgClassId; }
			set { _outputPgClassId = value; }
		}

		/// public propaty name  :  DataInputSystem
		/// <summary>�f�[�^���̓V�X�e���v���p�e�B</summary>
		/// <value>0:����,1:����,2:���,3:�Ԕ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �f�[�^���̓V�X�e���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 DataInputSystem
		{
			get { return _dataInputSystem; }
			set { _dataInputSystem = value; }
		}

		/// public propaty name  :  LinkSlipDataInputSys
		/// <summary>�����N�`�[�f�[�^���̓V�X�e���v���p�e�B</summary>
		/// <value>0:����,1:����,2:���,3:�Ԕ�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����N�`�[�f�[�^���̓V�X�e���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 LinkSlipDataInputSys
		{
			get { return _linkSlipDataInputSys; }
			set { _linkSlipDataInputSys = value; }
		}

		/// public propaty name  :  LinkSlipPrtKind
		/// <summary>�����N�`�[�����ʃv���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����N�`�[�����ʃv���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 LinkSlipPrtKind
		{
			get { return _linkSlipPrtKind; }
			set { _linkSlipPrtKind = value; }
		}

		/// public propaty name  :  LinkSlipPrtSetPprId
		/// <summary>�����N�`�[����ݒ�p���[ID�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   �����N�`�[����ݒ�p���[ID�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public string LinkSlipPrtSetPprId
		{
			get { return _linkSlipPrtSetPprId; }
			set { _linkSlipPrtSetPprId = value; }
		}

		/// public propaty name  :  ExtraSectionKindCd
		/// <summary>���o���_��ʋ敪�v���p�e�B</summary>
		/// <value>0:�g�p���Ȃ� 1:���сE���� 2:�d���E�̔�</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���o���_��ʋ敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ExtraSectionKindCd
		{
			get { return _extraSectionKindCd; }
			set { _extraSectionKindCd = value; }
		}

		/// public propaty name  :  ExtraSectionSelExist
		/// <summary>���o���_�I��L���v���p�e�B</summary>
		/// <value>0:�g�p���Ȃ� 1:�g�p����(�����I��) 2:�g�p����(�P�̑I��)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���o���_�I��L���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 ExtraSectionSelExist
		{
			get { return _extraSectionSelExist; }
			set { _extraSectionSelExist = value; }
		}

		/// public propaty name  :  FormFeedLineCount
		/// <summary>���ōs���v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���ōs���v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 FormFeedLineCount
		{
			get { return _formFeedLineCount; }
			set { _formFeedLineCount = value; }
		}

		/// public propaty name  :  CrCharCnt
		/// <summary>���s�������v���p�e�B</summary>
		/// <value>���`�[�ō�ƁE���i���̂̉��s������</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���s�������v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 CrCharCnt
		{
			get { return _crCharCnt; }
			set { _crCharCnt = value; }
		}

		/// public propaty name  :  FreePrtPprSpPrpseCd
		/// <summary>���R���[ ����p�r�敪�v���p�e�B</summary>
		/// <value>0:�g�p���Ȃ�,1:�ē�������^�C�v,2:��p���[,3:�����͂���</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ���R���[ ����p�r�敪�v���p�e�B</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Int32 FreePrtPprSpPrpseCd
		{
			get { return _freePrtPprSpPrpseCd; }
			set { _freePrtPprSpPrpseCd = value; }
		}


		/// <summary>
		/// �󎚍��ڃO���[�v���[�N�R���X�g���N�^
		/// </summary>
		/// <returns>PrtItemGrpWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   PrtItemGrpWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public PrtItemGrpWork()
		{
		}

	}

	/// <summary>
	///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
	/// </summary>
	/// <returns>PrtItemGrpWork�N���X�̃C���X�^���X(object)</returns>
	/// <remarks>
	/// <br>Note�@�@�@�@�@�@ :   PrtItemGrpWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
	/// <br>Programer        :   ��������</br>
	/// </remarks>
	public class PrtItemGrpWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
	{
		#region ICustomSerializationSurrogate �����o

		/// <summary>
		///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
		/// </summary>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   PrtItemGrpWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public void Serialize(System.IO.BinaryWriter writer, object graph)
		{
			// TODO:  PrtItemGrpWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
			if (writer == null)
				throw new ArgumentNullException();

			if (graph != null && !(graph is PrtItemGrpWork || graph is ArrayList || graph is PrtItemGrpWork[]))
				throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(PrtItemGrpWork).FullName));

			if (graph != null && graph is PrtItemGrpWork)
			{
				Type t = graph.GetType();
				if (!CustomFormatterServices.NeedCustomSerialization(t))
					throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
			}

			//SerializationTypeInfo
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.PrtItemGrpWork");

			//�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
			int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
			if (graph is ArrayList)
			{
				serInfo.RetTypeInfo = 0;
				occurrence = ((ArrayList)graph).Count;
			}
			else if (graph is PrtItemGrpWork[])
			{
				serInfo.RetTypeInfo = 2;
				occurrence = ((PrtItemGrpWork[])graph).Length;
			}
			else if (graph is PrtItemGrpWork)
			{
				serInfo.RetTypeInfo = 1;
				occurrence = 1;
			}

			serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

			//�쐬����
			serInfo.MemberInfo.Add(typeof(Int64)); //CreateDateTime
			//�X�V����
			serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTime
			//�_���폜�敪
			serInfo.MemberInfo.Add(typeof(Int32)); //LogicalDeleteCode
			//���R���[���ڃO���[�v�R�[�h
			serInfo.MemberInfo.Add(typeof(Int32)); //FreePrtPprItemGrpCd
			//���R���[���ڃO���[�v����
			serInfo.MemberInfo.Add(typeof(string)); //FreePrtPprItemGrpNm
			//���[�g�p�敪
			serInfo.MemberInfo.Add(typeof(Int32)); //PrintPaperUseDivcd
			//���o�v���O����ID
			serInfo.MemberInfo.Add(typeof(string)); //ExtractionPgId
			//���o�v���O�����N���XID
			serInfo.MemberInfo.Add(typeof(string)); //ExtractionPgClassId
			//�o�̓v���O����ID
			serInfo.MemberInfo.Add(typeof(string)); //OutputPgId
			//�o�̓v���O�����N���XID
			serInfo.MemberInfo.Add(typeof(string)); //OutputPgClassId
			//�f�[�^���̓V�X�e��
			serInfo.MemberInfo.Add(typeof(Int32)); //DataInputSystem
			//�����N�`�[�f�[�^���̓V�X�e��
			serInfo.MemberInfo.Add(typeof(Int32)); //LinkSlipDataInputSys
			//�����N�`�[������
			serInfo.MemberInfo.Add(typeof(Int32)); //LinkSlipPrtKind
			//�����N�`�[����ݒ�p���[ID
			serInfo.MemberInfo.Add(typeof(string)); //LinkSlipPrtSetPprId
			//���o���_��ʋ敪
			serInfo.MemberInfo.Add(typeof(Int32)); //ExtraSectionKindCd
			//���o���_�I��L��
			serInfo.MemberInfo.Add(typeof(Int32)); //ExtraSectionSelExist
			//���ōs��
			serInfo.MemberInfo.Add(typeof(Int32)); //FormFeedLineCount
			//���s������
			serInfo.MemberInfo.Add(typeof(Int32)); //CrCharCnt
			//���R���[ ����p�r�敪
			serInfo.MemberInfo.Add(typeof(Int32)); //FreePrtPprSpPrpseCd


			serInfo.Serialize(writer, serInfo);
			if (graph is PrtItemGrpWork)
			{
				PrtItemGrpWork temp = (PrtItemGrpWork)graph;

				SetPrtItemGrpWork(writer, temp);
			}
			else
			{
				ArrayList lst = null;
				if (graph is PrtItemGrpWork[])
				{
					lst = new ArrayList();
					lst.AddRange((PrtItemGrpWork[])graph);
				}
				else
				{
					lst = (ArrayList)graph;
				}

				foreach (PrtItemGrpWork temp in lst)
				{
					SetPrtItemGrpWork(writer, temp);
				}

			}


		}


		/// <summary>
		/// PrtItemGrpWork�����o��(public�v���p�e�B��)
		/// </summary>
		private const int currentMemberCount = 19;

		/// <summary>
		///  PrtItemGrpWork�C���X�^���X��������
		/// </summary>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   PrtItemGrpWork�̃C���X�^���X����������</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		private void SetPrtItemGrpWork(System.IO.BinaryWriter writer, PrtItemGrpWork temp)
		{
			//�쐬����
			writer.Write((Int64)temp.CreateDateTime.Ticks);
			//�X�V����
			writer.Write((Int64)temp.UpdateDateTime.Ticks);
			//�_���폜�敪
			writer.Write(temp.LogicalDeleteCode);
			//���R���[���ڃO���[�v�R�[�h
			writer.Write(temp.FreePrtPprItemGrpCd);
			//���R���[���ڃO���[�v����
			writer.Write(temp.FreePrtPprItemGrpNm);
			//���[�g�p�敪
			writer.Write(temp.PrintPaperUseDivcd);
			//���o�v���O����ID
			writer.Write(temp.ExtractionPgId);
			//���o�v���O�����N���XID
			writer.Write(temp.ExtractionPgClassId);
			//�o�̓v���O����ID
			writer.Write(temp.OutputPgId);
			//�o�̓v���O�����N���XID
			writer.Write(temp.OutputPgClassId);
			//�f�[�^���̓V�X�e��
			writer.Write(temp.DataInputSystem);
			//�����N�`�[�f�[�^���̓V�X�e��
			writer.Write(temp.LinkSlipDataInputSys);
			//�����N�`�[������
			writer.Write(temp.LinkSlipPrtKind);
			//�����N�`�[����ݒ�p���[ID
			writer.Write(temp.LinkSlipPrtSetPprId);
			//���o���_��ʋ敪
			writer.Write(temp.ExtraSectionKindCd);
			//���o���_�I��L��
			writer.Write(temp.ExtraSectionSelExist);
			//���ōs��
			writer.Write(temp.FormFeedLineCount);
			//���s������
			writer.Write(temp.CrCharCnt);
			//���R���[ ����p�r�敪
			writer.Write(temp.FreePrtPprSpPrpseCd);

		}

		/// <summary>
		///  PrtItemGrpWork�C���X�^���X�擾
		/// </summary>
		/// <returns>PrtItemGrpWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   PrtItemGrpWork�̃C���X�^���X���擾���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		private PrtItemGrpWork GetPrtItemGrpWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
		{
			// V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
			// serInfo.MemberInfo.Count < currentMemberCount
			// �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

			PrtItemGrpWork temp = new PrtItemGrpWork();

			//�쐬����
			temp.CreateDateTime = new DateTime(reader.ReadInt64());
			//�X�V����
			temp.UpdateDateTime = new DateTime(reader.ReadInt64());
			//�_���폜�敪
			temp.LogicalDeleteCode = reader.ReadInt32();
			//���R���[���ڃO���[�v�R�[�h
			temp.FreePrtPprItemGrpCd = reader.ReadInt32();
			//���R���[���ڃO���[�v����
			temp.FreePrtPprItemGrpNm = reader.ReadString();
			//���[�g�p�敪
			temp.PrintPaperUseDivcd = reader.ReadInt32();
			//���o�v���O����ID
			temp.ExtractionPgId = reader.ReadString();
			//���o�v���O�����N���XID
			temp.ExtractionPgClassId = reader.ReadString();
			//�o�̓v���O����ID
			temp.OutputPgId = reader.ReadString();
			//�o�̓v���O�����N���XID
			temp.OutputPgClassId = reader.ReadString();
			//�f�[�^���̓V�X�e��
			temp.DataInputSystem = reader.ReadInt32();
			//�����N�`�[�f�[�^���̓V�X�e��
			temp.LinkSlipDataInputSys = reader.ReadInt32();
			//�����N�`�[������
			temp.LinkSlipPrtKind = reader.ReadInt32();
			//�����N�`�[����ݒ�p���[ID
			temp.LinkSlipPrtSetPprId = reader.ReadString();
			//���o���_��ʋ敪
			temp.ExtraSectionKindCd = reader.ReadInt32();
			//���o���_�I��L��
			temp.ExtraSectionSelExist = reader.ReadInt32();
			//���ōs��
			temp.FormFeedLineCount = reader.ReadInt32();
			//���s������
			temp.CrCharCnt = reader.ReadInt32();
			//���R���[ ����p�r�敪
			temp.FreePrtPprSpPrpseCd = reader.ReadInt32();


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
		/// <returns>PrtItemGrpWork�N���X�̃C���X�^���X(object)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   PrtItemGrpWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public object Deserialize(System.IO.BinaryReader reader)
		{
			object retValue = null;
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
			ArrayList lst = new ArrayList();
			for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
			{
				PrtItemGrpWork temp = GetPrtItemGrpWork(reader, serInfo);
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
					retValue = (PrtItemGrpWork[])lst.ToArray(typeof(PrtItemGrpWork));
					break;
			}
			return retValue;
		}

		#endregion
	}

}

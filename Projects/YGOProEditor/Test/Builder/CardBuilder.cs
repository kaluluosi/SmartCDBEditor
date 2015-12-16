
using YGODevelop;
using System.Collections.Generic;

namespace Builder
{
	public class CardBuilder
	{

		public CardBuilder (datas data)
		{
			this.ID = data.id;
			this.Alias = data.alias;
			this.Level = data.level;
			this.Atk = data.atk;
			this.Def = data.def;
			this.Description = data.texts.desc;
			this.InfoStrings = new List<string> ();
			this.InfoStrings.Add (data.texts.str1);
			this.InfoStrings.Add (data.texts.str2);
			this.InfoStrings.Add (data.texts.str3);
			this.InfoStrings.Add (data.texts.str4);
			this.InfoStrings.Add (data.texts.str5);
			this.InfoStrings.Add (data.texts.str6);
			this.InfoStrings.Add (data.texts.str7);
			this.InfoStrings.Add (data.texts.str8);
			this.InfoStrings.Add (data.texts.str9);
			this.InfoStrings.Add (data.texts.str10);
			this.InfoStrings.Add (data.texts.str11);
			this.InfoStrings.Add (data.texts.str12);
			this.InfoStrings.Add (data.texts.str13);
			this.InfoStrings.Add (data.texts.str14);
			this.InfoStrings.Add (data.texts.str15);
			this.InfoStrings.Add (data.texts.str16);

			//这里有个问题值可能是0,因此Field的VarITem可能为Null,WPF中要对VarItem为Null的情况选中一个默认值.
			this.Ot = new OtField (data.ot);
			this.SetCode = new SetCodeField (data.setcode);
			this.Type = new TypeField (data.type);
			this.Category = new CategoryField (data.category);
			this.Race = new RaceField (data.race);
			this.Attribute = new AttributeField (data.attribute);
		}

		public CardBuilder(){
			this.Ot = new OtField ();
			this.SetCode = new SetCodeField ();
			this.Type = new TypeField ();
			this.Category = new CategoryField ();
			this.Race = new RaceField ();
			this.Attribute = new AttributeField ();
		}
   
		//不需要Field包装的字段
		public int ID { get; set; }

		public int Alias { get; set; }

		public string Name { get; set; }

		public int Level { get; set; }

		public int Atk { get; set; }

		public int Def { get; set; }

		public string Description { get; set; }

		public List<string> InfoStrings { get; set; }


		//需要Field包装的字段
		public OtField Ot { get; set; }

		public SetCodeField SetCode { get; set; }

		public TypeField Type { get; set; }

		public CategoryField Category { get; set; }

		public RaceField Race { get; set; }

		public AttributeField Attribute { get; set; }

		/// <summary>
		/// 转换成
		/// </summary>
		public datas ToDatas ()
		{
			datas data = new datas ();
			data.id = this.ID;
			data.alias = this.Alias;
			data.texts.name = this.Name;
			data.level = this.Level;
			data.atk = this.Atk;
			data.def = this.Def;
			data.texts.desc = this.Description;
			data.texts.str1 = this.InfoStrings [0];
			data.texts.str2 = this.InfoStrings [1];
			data.texts.str3 = this.InfoStrings [2];
			data.texts.str4 = this.InfoStrings [3];
			data.texts.str5 = this.InfoStrings [4];
			data.texts.str6 = this.InfoStrings [5];
			data.texts.str7 = this.InfoStrings [6];
			data.texts.str8 = this.InfoStrings [7];
			data.texts.str9 = this.InfoStrings [8];
			data.texts.str10 = this.InfoStrings [9];
			data.texts.str11 = this.InfoStrings [10];
			data.texts.str12 = this.InfoStrings [11];
			data.texts.str13 = this.InfoStrings [12];
			data.texts.str14 = this.InfoStrings [13];
			data.texts.str15 = this.InfoStrings [14];
			data.texts.str16 = this.InfoStrings [15];

			data.ot = this.Ot.Value;
			data.setcode = this.SetCode.Value;
			data.type = this.Type.Value;
			data.category = this.Category.Value;
			data.race = this.Race.Value;
			data.attribute = this.Attribute.Value;

			return data;
		}
	}
}

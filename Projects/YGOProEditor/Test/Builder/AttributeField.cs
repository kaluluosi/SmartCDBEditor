﻿using System;
using System.Collections.Generic;
using Cfg;

namespace Builder
{
	/// <summary>
	/// 属性字段,单选
	/// </summary>
	public class AttributeField:Field 
	{
		/// <summary>
		/// 如果value的值在配置里找不到则返回Null
		/// </summary>
		public static VarItem GetAttributeItem(Int64 value){
			List<VarItem> cfg = ConfigManager.Load("Attribute");
			VarItem result = cfg.Find(item=>item.Value==value);
			return result;
		}

		public AttributeField(){

		}

		public AttributeField(Int64 value){
			this.AttributeItem = GetAttributeItem(value);
		}

		public VarItem AttributeItem { get; set; }

		public override Int64 Value{
			get{
				return AttributeItem.Value;
			}
		}
	}
}

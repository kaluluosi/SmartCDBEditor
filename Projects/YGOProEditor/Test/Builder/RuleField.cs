﻿using System;
using System.Collections.Generic;
using Cfg;

namespace Builder
{
	/// <summary>
	/// 规则字段,单选
	/// </summary>
	public class OtField :Field
	{
		/// <summary>
		/// 如果value的值在配置里找不到则返回Null
		/// </summary>	
		public static VarItem GetOtItem(Int64 value){
			List<VarItem> cfg = ConfigManager.Load("Ot");
			VarItem result = cfg.Find(item=>item.Value == value);
			return result;
		} 	

		public OtField(){

		}

		public OtField(Int64 value){
			this.OtItem = GetOtItem(value);
		}

		public VarItem OtItem { get; set; }

		public override Int64 Value{
			get{
				return OtItem.Value;
			}
		}
	}
}


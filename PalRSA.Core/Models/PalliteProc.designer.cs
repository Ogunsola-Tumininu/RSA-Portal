﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PalRSA.Core.Models
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="PALSiteDB")]
	public partial class PalliteProcDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public PalliteProcDataContext() : 
				base(global::PalRSA.Core.Properties.Settings.Default.PALSiteDBConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public PalliteProcDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public PalliteProcDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public PalliteProcDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public PalliteProcDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.GetFundId", IsComposable=true)]
		public System.Nullable<int> GetFundId([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(20)")] string pin)
		{
			return ((System.Nullable<int>)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), pin).ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.FnLastValueDate", IsComposable=true)]
		public System.Nullable<System.DateTime> FnLastValueDate([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Decimal(18,0)")] System.Nullable<decimal> fund_id)
		{
			return ((System.Nullable<System.DateTime>)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), fund_id).ReturnValue));
		}
	}
}
#pragma warning restore 1591
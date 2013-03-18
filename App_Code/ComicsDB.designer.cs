﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;



[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="ComicsRUs")]
public partial class ComicsDBDataContext : System.Data.Linq.DataContext
{
	
	private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
	
  #region Extensibility Method Definitions
  partial void OnCreated();
  partial void InsertComicData(ComicData instance);
  partial void UpdateComicData(ComicData instance);
  partial void DeleteComicData(ComicData instance);
  #endregion
	
	public ComicsDBDataContext() : 
			base(global::System.Configuration.ConfigurationManager.ConnectionStrings["ComicsRUsConnectionString"].ConnectionString, mappingSource)
	{
		OnCreated();
	}
	
	public ComicsDBDataContext(string connection) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public ComicsDBDataContext(System.Data.IDbConnection connection) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public ComicsDBDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public ComicsDBDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public System.Data.Linq.Table<ComicData> ComicDatas
	{
		get
		{
			return this.GetTable<ComicData>();
		}
	}
}

[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.ComicData")]
public partial class ComicData : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private string _FileName;
	
	private string _FileExtension;
	
	private string _Website;
	
	private int _Bumps;
	
	private string _FilePath;
	
	private System.DateTime _DateAdded;
	
	private int _TotalNumber;
	
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnFileNameChanging(string value);
    partial void OnFileNameChanged();
    partial void OnFileExtensionChanging(string value);
    partial void OnFileExtensionChanged();
    partial void OnWebsiteChanging(string value);
    partial void OnWebsiteChanged();
    partial void OnBumpsChanging(int value);
    partial void OnBumpsChanged();
    partial void OnFilePathChanging(string value);
    partial void OnFilePathChanged();
    partial void OnDateAddedChanging(System.DateTime value);
    partial void OnDateAddedChanged();
    partial void OnTotalNumberChanging(int value);
    partial void OnTotalNumberChanged();
    #endregion
	
	public ComicData()
	{
		OnCreated();
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FileName", DbType="NVarChar(55) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
	public string FileName
	{
		get
		{
			return this._FileName;
		}
		set
		{
			if ((this._FileName != value))
			{
				this.OnFileNameChanging(value);
				this.SendPropertyChanging();
				this._FileName = value;
				this.SendPropertyChanged("FileName");
				this.OnFileNameChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FileExtension", DbType="NVarChar(5) NOT NULL", CanBeNull=false)]
	public string FileExtension
	{
		get
		{
			return this._FileExtension;
		}
		set
		{
			if ((this._FileExtension != value))
			{
				this.OnFileExtensionChanging(value);
				this.SendPropertyChanging();
				this._FileExtension = value;
				this.SendPropertyChanged("FileExtension");
				this.OnFileExtensionChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Website", DbType="VarChar(25) NOT NULL", CanBeNull=false)]
	public string Website
	{
		get
		{
			return this._Website;
		}
		set
		{
			if ((this._Website != value))
			{
				this.OnWebsiteChanging(value);
				this.SendPropertyChanging();
				this._Website = value;
				this.SendPropertyChanged("Website");
				this.OnWebsiteChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Bumps", DbType="Int NOT NULL")]
	public int Bumps
	{
		get
		{
			return this._Bumps;
		}
		set
		{
			if ((this._Bumps != value))
			{
				this.OnBumpsChanging(value);
				this.SendPropertyChanging();
				this._Bumps = value;
				this.SendPropertyChanged("Bumps");
				this.OnBumpsChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FilePath", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
	public string FilePath
	{
		get
		{
			return this._FilePath;
		}
		set
		{
			if ((this._FilePath != value))
			{
				this.OnFilePathChanging(value);
				this.SendPropertyChanging();
				this._FilePath = value;
				this.SendPropertyChanged("FilePath");
				this.OnFilePathChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DateAdded", DbType="DateTime NOT NULL")]
	public System.DateTime DateAdded
	{
		get
		{
			return this._DateAdded;
		}
		set
		{
			if ((this._DateAdded != value))
			{
				this.OnDateAddedChanging(value);
				this.SendPropertyChanging();
				this._DateAdded = value;
				this.SendPropertyChanged("DateAdded");
				this.OnDateAddedChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TotalNumber", AutoSync=AutoSync.Always, DbType="Int NOT NULL IDENTITY", IsDbGenerated=true)]
	public int TotalNumber
	{
		get
		{
			return this._TotalNumber;
		}
		set
		{
			if ((this._TotalNumber != value))
			{
				this.OnTotalNumberChanging(value);
				this.SendPropertyChanging();
				this._TotalNumber = value;
				this.SendPropertyChanged("TotalNumber");
				this.OnTotalNumberChanged();
			}
		}
	}
	
	public event PropertyChangingEventHandler PropertyChanging;
	
	public event PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		if ((this.PropertyChanging != null))
		{
			this.PropertyChanging(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(String propertyName)
	{
		if ((this.PropertyChanged != null))
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
#pragma warning restore 1591

﻿using System;
using System.Data;
using System.Collections.Generic;
using Danyl.SnnuURP.Common;
using Danyl.SnnuURP.Model;
namespace Danyl.SnnuURP.BLL
{
    /// <summary>
    /// TeachBuilding
    /// </summary>
    public partial class TeachBuilding
	{
		private readonly Danyl.SnnuURP.DAL.TeachBuilding dal=new Danyl.SnnuURP.DAL.TeachBuilding();
		public TeachBuilding()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int DistrictId,int BuildId)
		{
			return dal.Exists(DistrictId,BuildId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Danyl.SnnuURP.Model.TeachBuilding model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Danyl.SnnuURP.Model.TeachBuilding model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int BuildId)
		{
			
			return dal.Delete(BuildId);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int DistrictId,int BuildId)
		{
			
			return dal.Delete(DistrictId,BuildId);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string BuildIdlist )
		{
			return dal.DeleteList(Danyl.SnnuURP.Common.PageValidate.SafeLongFilter(BuildIdlist,0) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Danyl.SnnuURP.Model.TeachBuilding GetModel(int BuildId)
		{
			
			return dal.GetModel(BuildId);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Danyl.SnnuURP.Model.TeachBuilding GetModelByCache(int BuildId)
		{
			
			string CacheKey = "TeachBuildingModel-" + BuildId;
			object objModel = Danyl.SnnuURP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(BuildId);
					if (objModel != null)
					{
						int ModelCache = Danyl.SnnuURP.Common.ConfigHelper.GetConfigInt("ModelCache");
						Danyl.SnnuURP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Danyl.SnnuURP.Model.TeachBuilding)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Danyl.SnnuURP.Model.TeachBuilding> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Danyl.SnnuURP.Model.TeachBuilding> DataTableToList(DataTable dt)
		{
			List<Danyl.SnnuURP.Model.TeachBuilding> modelList = new List<Danyl.SnnuURP.Model.TeachBuilding>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Danyl.SnnuURP.Model.TeachBuilding model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}


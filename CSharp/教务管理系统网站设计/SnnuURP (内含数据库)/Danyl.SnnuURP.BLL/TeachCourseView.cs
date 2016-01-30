﻿using System;
using System.Data;
using System.Collections.Generic;
using Danyl.SnnuURP.Common;
using Danyl.SnnuURP.Model;

namespace Danyl.SnnuURP.BLL
{
    /// <summary>
    /// TeachCourseView
    /// </summary>
    public partial class TeachCourseView
    {
        private readonly Danyl.SnnuURP.DAL.TeachCourseView dal = new Danyl.SnnuURP.DAL.TeachCourseView();
        public TeachCourseView()
        {}

        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Tid, int Cid)
        {
            return dal.Exists(Tid, Cid);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Danyl.SnnuURP.Model.TeachCourseView model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Danyl.SnnuURP.Model.TeachCourseView model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int Tid, int Cid)
        {

            return dal.Delete(Tid, Cid);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Danyl.SnnuURP.Model.TeachCourseView GetModel(int Tid, int Cid)
        {

            return dal.GetModel(Tid, Cid);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Danyl.SnnuURP.Model.TeachCourseView GetModelByCache(int Tid, int Cid)
        {

            string CacheKey = "TeachCourseViewModel-" + Tid + Cid;
            object objModel = Danyl.SnnuURP.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(Tid, Cid);
                    if (objModel != null)
                    {
                        int ModelCache = Danyl.SnnuURP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Danyl.SnnuURP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Danyl.SnnuURP.Model.TeachCourseView)objModel;
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
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Danyl.SnnuURP.Model.TeachCourseView> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Danyl.SnnuURP.Model.TeachCourseView> DataTableToList(DataTable dt)
        {
            List<Danyl.SnnuURP.Model.TeachCourseView> modelList = new List<Danyl.SnnuURP.Model.TeachCourseView>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Danyl.SnnuURP.Model.TeachCourseView model;
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
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
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
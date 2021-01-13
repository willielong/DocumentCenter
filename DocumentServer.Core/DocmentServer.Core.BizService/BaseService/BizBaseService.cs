using AutoMapper;
using DocumentServer.Core.Comm;
using DocumentServer.Core.Model.DbModel;
using DocumentServer.Core.Model.Oupt;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace DocmentServer.Core.BizService.BaseService
{
    public class BizBaseService
    {
        public HttpContext context;
        public DocumentServer.Core.Model.DbModel.Employee CurrentUser;
        public IMapper mapper;
        public BizBaseService(IHttpContextAccessor httpContext, IMapper _mapper)
        {
            context = httpContext.HttpContext;
            GetEmployee(httpContext: httpContext);
            mapper = _mapper;
        } 
        /// <summary>
        /// 根据token获取员工基本信息
        /// </summary>
        /// <param name="httpContext"></param>
        public void GetEmployee(IHttpContextAccessor httpContext, DocumentServer.Core.Model.DbModel.Employee employee = null)
        {
            CurrentUser = new DocumentServer.Core.Model.DbModel.Employee();
            CurrentUser = httpContext != null ? (httpContext.HttpContext.User.ToUser<DocumentServer.Core.Model.DbModel.Employee>() ?? employee) : employee;
        }

        /// <summary>
        /// 将数据库实体转换成页面需要的实体
        /// </summary>
        /// <typeparam name="TModel">数据库实体</typeparam>
        /// <typeparam name="TViewModel">输出实体</typeparam>
        /// <param name="model">数据</param>
        /// <param name="t2">输出数据</param>
        public void ToViewModel<TModel, TViewModel>(TModel model, out TViewModel view) where TModel : class, new() where TViewModel : class, new()
        {
            view = mapper.Map<TModel, TViewModel>(model);
        }
        /// <summary>
        /// 将数据库实体集转换成页面需要的实体集
        /// </summary>
        /// <typeparam name="TModel">数据库实体</typeparam>
        /// <typeparam name="TViewModel">输出实体</typeparam>
        /// <param name="model">数据</param>
        /// <param name="t2">输出数据</param>
        public void ToViewModels<TModel, TViewModel>(List<TModel> model, out List<TViewModel> view) where TModel : class, new() where TViewModel : class, new()
        {
            view = mapper.Map<List<TModel>, List<TViewModel>>(model);
        }

        /// <summary>
        /// 将页面数据转换程数据数据
        /// </summary>
        /// <typeparam name="TModel">数据库实体</typeparam>
        /// <typeparam name="TInputModel">输出实体</typeparam>
        /// <param name="input">输入数据</param>
        /// <param name="model">数据库数据</param>
        public void ToModel<TModel, TInputModel>(TInputModel input, out TModel model) where TModel : class, new() where TInputModel : class, new()
        {
            model = mapper.Map<TInputModel, TModel>(input);
        }

        /// <summary>
        /// 将页面数据集转换程数据集
        /// </summary>
        /// <typeparam name="TModel">数据库实体</typeparam>
        /// <typeparam name="TInputModel">输出实体</typeparam>
        /// <param name="input">输入数据</param>
        /// <param name="model">数据库数据</param>
        public void ToModels<TModel, TInputModel>(List<TInputModel> input, out List<TModel> model) where TModel : class, new() where TInputModel : class, new()
        {
            model = mapper.Map<List<TInputModel>, List<TModel>>(input);
        }
        /// <summary>
        /// 将文件的信息转换成表格文件
        /// </summary>
        /// <typeparam name="TModel">数据库实体</typeparam>
        /// <typeparam name="TViewModel">输出实体</typeparam>
        /// <param name="model">数据</param>
        /// <param name="t2">输出数据</param>
        public List<TreeTableModel> ToFileViewModels(List<Files> model,  int orgId, string apiUrl)
        {
            List<TreeTableModel> result= mapper.Map<List<Files>, List<TreeTableModel>>(model);            
            result.ForEach(o =>
            {
                o.orgid = orgId;
                o.fileurl = apiUrl + o.fileurl;
                //o.filetype = o.ext.ConvertToExtInt();
            });
            return result;
        }
    }
}

using DotnetCoreApi.Dtos;
using DotnetCoreApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using System.Linq.Expressions;
using Newtonsoft.Json;

namespace DotnetCoreApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    [EnableCors("any")]
    public class TableController : Controller
    {
        private readonly TodoContext _context;
        private readonly IMapper _mapper;
        private readonly EFHelper _helper;
        public TableController(TodoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _helper = new EFHelper(_context);
        }

        [HttpGet]
        public ObjectResult GetTableKeys(string tableName)
        {
            TableHead th = new TableHead();
            List<SelectDto> keys = new List<SelectDto>();

            var relation = _context.Relation.Where(x => x.TableName == tableName).FirstOrDefault();
            if (relation == null)
            {
                return Ok(new { code = 1, msg = "表名不存在，请检查对应表" });
            }
            
            
            var typeName = (relation.DtoNameSpace.IsNullOrEmpty() ? "DotnetCoreApi.Models" : relation.DtoNameSpace) +"."+ relation.TableDtoName;

            //switch (tableName)
            //{
            //    case "C-2-55水泥混凝土面层检验记录表":
            //        GetObjKeys(new CementConcrete(), keys);
            //        break;
            //    case "C-2-74钻(挖)孔灌注桩、地下连续墙钢筋安装检验记录表":
            //        GetObjKeys(new RebarSetting(), keys);
            //        break;
            //    default:
            //        break;
            //}
            GetObjKeys(typeName, keys);
            return Ok(new { code = 0, msg = "", data = keys });
        }
        /// <summary>
        /// 通过字符串获取类名
        /// </summary>
        /// <param name="TypeName"></param>
        /// <returns></returns>
        private Type GetType(string TypeName)
        {
            return Type.GetType(TypeName);
        }

        /// <summary>
        /// 获取所有的table表名称
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ObjectResult GetAllTableName()
        {
            var lst = _context.Relation.Select(x => x.TableName).ToList();
            return Ok(new { code = 0, msg = "", data = lst });
        }

        /// <summary>
        /// 通用方法：通过表实例返回对应的key用于绑定
        /// </summary>
        /// <param name="TypeName"></param>
        /// <param name="keys"></param>
        private void GetObjKeys(string TypeName, List<SelectDto> keys)
        {
            //Type t = obj.GetType();
            Type t = Type.GetType(TypeName);
            foreach (PropertyInfo pi in t.GetProperties())
            {
                var name = pi.Name;//获得属性的名字,后面就可以根据名字判断来进行些自己想要的操作
               // var value = pi.GetValue(obj, null);//用pi.GetValue获得值
                var v = (DescriptionAttribute[])pi.GetCustomAttributes(typeof(DescriptionAttribute), false);
                var descriptionName = v.Length > 0 ? v[0].Description : "";
                if (descriptionName != "")
                {
                    keys.Add(new SelectDto() { label = descriptionName, value = name });
                }
               // var type = value?.GetType() ?? typeof(object);//获得属性的类型
            }
        }

        [HttpPost]
        public async Task<ActionResult<PostionTemp>> SavePostion(List<PostionTemp> list)
        {
            foreach (var p in list)
            {
                var entity = await _context.PostionTemp.Where(x => x.Row == p.Row && x.Col == p.Col && x.TableName == p.TableName).FirstOrDefaultAsync();
                if (entity != null)
                {
                    entity.Row = p.Row;
                    entity.Col = p.Col;
                    entity.FieldName = p.FieldName;
                    entity.RowCount = p.RowCount;
                    entity.ColCount = p.ColCount;
                    entity.Type = p.Type;
                    _context.PostionTemp.Update(entity);
                }
                else
                {
                    await _context.PostionTemp.AddAsync(p);
                }

            }

            _context.SaveChanges();
            return Ok();
        }
        /// <summary>
        /// 根据表名获取所有坐标点
        /// </summary>
        /// <param name="TableName"></param>
        /// <returns></returns>
        [HttpGet]
        public ObjectResult GetAllPostion(string TableName)
        {

            return Ok(GetPostion(TableName));
        }
        /// <summary>
        /// 根据表名获取所有的坐标
        /// </summary>
        /// <param name="TableName"></param>
        /// <returns></returns>
        private List<PostionTemp> GetPostion(string TableName)
        {
            var lst = _context.PostionTemp.Where(x => x.TableName == TableName).ToList();
            return lst;
        }

        /// <summary>
        /// 根据表名获取所有坐标点
        /// </summary>
        /// <param name="TableName"></param>
        /// <returns></returns>
        private int GetTableMaxLength(string TableName)
        {
            var result = _context.PostionTemp.Where(x => x.TableName == TableName).GroupBy(x => x.FieldName).Select(c => new { key = c.Key, num = c.Count() }).OrderByDescending(x => x.num).ToList();
            if (result.Count > 0)
            {
                return result[0].num;
            }
            return 0;
        }

        /// <summary>
        /// 通过ID删除坐标点
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> DeletePostion(EntityDto dto)
        {
            var entity = await _context.PostionTemp.FindAsync(dto.Id);
            if (entity == null)
            {
                return NotFound();
            }

            _context.PostionTemp.Remove(entity);
            await _context.SaveChangesAsync();
            return Ok();
        }
        /// <summary>
        /// 通用查询接口
        /// </summary>
        /// <param name="id">表单ID</param>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        [HttpGet]
        public object GetData(int id, string tableName)
        {
            var rel = _context.Relation.Where(x => x.TableName == tableName).FirstOrDefault();
            if (rel==null)
            {
                return Ok(new { code = 1, msg = "表单不存在" });
            }
            GetTableDataDto entity = new GetTableDataDto() { Id = id, TableName = tableName, InstanceCount =rel.InstanceCount };
            var dataTypeName = (rel.TableNamespace.IsNullOrEmpty() ? "DotnetCoreApi.Models" : rel.TableNamespace) + "." + rel.TableDtoDataName;
            var dtoTypeName = (rel.DtoNameSpace.IsNullOrEmpty() ? "DotnetCoreApi.Models" : rel.DtoNameSpace) + "." + rel.TableDtoName;
            Type t = Type.GetType(dtoTypeName);
            Type t2 = Type.GetType(dataTypeName);
            Type[] typeArgs = { t, t2 };
            var result = this.GetType().GetMethod("GetTableDto").MakeGenericMethod(typeArgs).Invoke(this, new object[] { entity });

            return result;
            //try
            //{
            //    switch (entity.TableName)
            //    {
            //        case "C-2-55水泥混凝土面层检验记录表":
            //            return GetTableDto<CementConcrete, ShuiNiHunLingTu>(entity);
            //        // return GetCementConcrete(entity);
            //        case "C-2-74钻(挖)孔灌注桩、地下连续墙钢筋安装检验记录表":
            //            return GetTableDto<RebarSetting, GangJingAnZhuang>(entity);
            //        //return GetRebarSetting(entity);
            //        default:
            //            return Ok(new { code = 1, msg = "没有找到对应的表" });
            //    }
            //}
            //catch (Exception ex)
            //{

            //    return Ok(new { code = 1, msg = ex.Message });
            //}
        }

        private ObjectResult GetCementConcrete(GetTableDataDto dto)
        {
            TableHead th = _context.TableHead.Where(x => x.Id == dto.Id).FirstOrDefault();
            if (th == null)
            {
                CementConcrete entity = new CementConcrete() { TableName = dto.TableName };
                List<ShuiNiHunLingTu> lst = new List<ShuiNiHunLingTu>();
                for (int i = 0; i < GetDataLength(dto.TableName, "Data"); i++)
                {
                    ShuiNiHunLingTu s = new ShuiNiHunLingTu();
                    lst.Add(s);
                }
                entity.Data = lst;
                return Ok(new { code = 0, msg = "", data = entity, postion = GetPostion(dto.TableName) });
            }
            else
            {
                var entity = _mapper.Map<CementConcrete>(th);
                var lst = _context.ShuiNiHunLingTu.Where(x => x.TableHeadId == th.Id).ToList();
                entity.Data = lst;
                return Ok(new { code = 0, msg = "", data = entity, postion = GetPostion(dto.TableName) });
            }
        }
        private ObjectResult GetRebarSetting(GetTableDataDto dto)
        {
            TableHead th = _context.TableHead.Where(x => x.Id == dto.Id).FirstOrDefault();
            if (th == null)
            {
                RebarSetting entity = new RebarSetting() { TableName = dto.TableName };
                List<GangJingAnZhuang> lst = new List<GangJingAnZhuang>();
                for (int i = 0; i < GetDataLength(dto.TableName, "Data"); i++)
                {
                    GangJingAnZhuang s = new GangJingAnZhuang();
                    lst.Add(s);
                }
                entity.Data = lst;
                return Ok(new { code = 0, msg = "", data = entity, postion = GetPostion(dto.TableName) });
            }
            else
            {
                var entity = _mapper.Map<RebarSetting>(th);
                var lst = _context.GangJingAnZhuang.Where(x => x.TableHeadId == th.Id).ToList();
                entity.Data = lst;
                return Ok(new { code = 0, msg = "", data = entity, postion = GetPostion(dto.TableName) });
            }
        }

        /// <summary>
        /// 通用查询方法
        /// </summary>
        /// <typeparam name="T">dto类</typeparam>
        /// <typeparam name="F">dto类下的Data类</typeparam>
        /// <param name="dto"></param>
        /// <returns></returns>
        public ObjectResult GetTableDto<T, F>(GetTableDataDto dto) where T : class, BaseData<T, F>, new() where F : class, BaseParent, new()
        {
            TableHead th = _context.TableHead.Where(x => x.Id == dto.Id).FirstOrDefault();
            if (th == null)
            {
                T entity = new T() { TableName = dto.TableName };

                List<F> lst = new List<F>();
                for (int i = 0; i < dto.InstanceCount; i++)
                {
                    F s = new F();
                    lst.Add(s);
                }
                entity.Data = lst;
                return Ok(new { code = 0, msg = "", data = entity, postion = GetPostion(dto.TableName) });
            }
            else
            {
                var entity = _mapper.Map<T>(th);
                var lst = _helper.Quyery<F>(x => x.TableHeadId == th.Id).ToList();
                entity.Data = lst;
                return Ok(new { code = 0, msg = "", data = entity, postion = GetPostion(dto.TableName) });
            }
        }

        private int GetDataLength(string tableName, string fildName)
        {
            var entity = _context.PostionTemp.Where(x => x.TableName == tableName && x.FieldName == fildName).FirstOrDefault();
            return entity.RowCount;
        }

        [HttpGet]
        public ObjectResult GetAllData()
        {
            var lst = _context.TableHead.Select(x => new { x.Id, x.TableName, x.Name }).ToList();
            return Ok(new { code = 0, msg = "", data = lst });
        }

        /// <summary>
        /// 通用保存接口
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(TableSaveDto dto)
        {
            try
            {
                var rel = _context.Relation.Where(x => x.TableName == dto.tableName).FirstOrDefault();
                if (rel == null)
                {
                    return Ok(new { code = 1, msg = "表单不存在" });
                }
                var dataTypeName = (rel.TableNamespace.IsNullOrEmpty() ? "DotnetCoreApi.Models" : rel.TableNamespace) + "." + rel.TableDtoDataName;
                var dtoTypeName = (rel.DtoNameSpace.IsNullOrEmpty() ? "DotnetCoreApi.Models" : rel.DtoNameSpace) + "." + rel.TableDtoName;
                Type t = Type.GetType(dtoTypeName);
                Type t2 = Type.GetType(dataTypeName);
                Type[] typeArgs = { t, t2 };
                this.GetType().GetMethod("SaveTable").MakeGenericMethod(typeArgs).Invoke(this, new object[] { dto.Data });
                //switch (dto.tableName)
                //{
                //    case "C-2-55水泥混凝土面层检验记录表":
                //        SaveTable<CementConcrete, ShuiNiHunLingTu>(dto.Data);
                //        //SaveCement(JsonConvert.DeserializeObject<CementConcrete>(dto.Data));
                //        //CementConcrete obj = JsonConvert.DeserializeObject<CementConcrete>(dto.Data);
                //        //var elm = _mapper.Map<TableHead>(obj);
                //        //var o = SaveObject<TableHead>(elm);
                //        //var lst = obj.Data;
                //        //foreach (var item in lst)
                //        //{
                //        //    item.TableHeadId = o.Id;
                //        //    SaveObject<ShuiNiHunLingTu>(item);
                //        //}
                //        break;
                //    case "C-2-74钻(挖)孔灌注桩、地下连续墙钢筋安装检验记录表":
                //        SaveTable<RebarSetting, GangJingAnZhuang>(dto.Data);
                //        //SaveRebar(JsonConvert.DeserializeObject<RebarSetting>(dto.Data));
                //        break;
                //    default:
                //        break;
                //}

                return Ok(new { code = 0, msg = "" });
            }
            catch (Exception ex)
            {
                return Ok(new { code = 1, msg = ex.Message });
            }

        }

        /// <summary>
        /// 通用保存逻辑业务
        /// </summary>
        /// <typeparam name="T">表dto</typeparam>
        /// <typeparam name="F">表dto里的数据类型</typeparam>
        /// <param name="json">表dto的json字符串</param>
        public void SaveTable<T, F>(string json) where T : class, BaseData<T, F> where F : class, BaseParent
        {
            T obj = JsonConvert.DeserializeObject<T>(json);
            var th = _mapper.Map<TableHead>(obj);
            var result = SaveObject<TableHead>(th);
            List<F> lst = obj.Data;
            foreach (var item in lst)
            {
                item.TableHeadId = result.Id;
                SaveObject<F>(item);
            }
        }

        private T GetEntityByJson<T>(string json)
        {
            T obj = JsonConvert.DeserializeObject<T>(json);
            return obj;
        }


        private void SaveCement(CementConcrete entity)
        {
            var elm = _mapper.Map<TableHead>(entity);
            var ety = _context.TableHead.AsNoTracking().Where(x => x.Id == entity.Id).FirstOrDefault();
            if (ety != null)
                _context.TableHead.Update(elm);
            else
                _context.TableHead.Add(elm);
            _context.SaveChanges();
            List<ShuiNiHunLingTu> lst = entity.Data;
            foreach (var item in lst)
            {
                item.TableHeadId = elm.Id;
                var obj = _context.ShuiNiHunLingTu.AsNoTracking().Where(x => x.Id == item.Id).FirstOrDefault();
                if (obj == null)
                    _context.ShuiNiHunLingTu.Add(item);
                else
                    _context.ShuiNiHunLingTu.Update(item);
            }
            _context.SaveChanges();
        }

        private void SaveRebar(RebarSetting entity)
        {
            var ety = _context.TableHead.AsNoTracking().Where(x => x.Id == entity.Id).FirstOrDefault();
            if (ety != null)
            {
                ety = _mapper.Map<TableHead>(entity);
                _context.TableHead.Update(ety);
            }
            else
            {
                ety = _mapper.Map<TableHead>(entity);
                _context.TableHead.Add(ety);
            }

            _context.SaveChanges();
            List<GangJingAnZhuang> lst = entity.Data;
            foreach (var item in lst)
            {
                item.TableHeadId = ety.Id;
                var obj = _context.GangJingAnZhuang.AsNoTracking().Where(x => x.Id == item.Id).FirstOrDefault();
                if (obj == null)
                    _context.GangJingAnZhuang.Add(item);
                else
                    _context.GangJingAnZhuang.Update(item);
            }
            _context.SaveChanges();
        }

        /// <summary>
        /// 通用保存方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public T SaveObject<T>(T obj) where T : class, BaseEntity
        {
            if (obj.Id > 0)
            {
                _context.Entry<T>(obj).State = EntityState.Modified;
            }
            else
            {
                _context.Entry<T>(obj).State = EntityState.Added;
            }

            _context.SaveChanges();
            return obj;
        }




    }

}

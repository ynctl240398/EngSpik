using System;
using Microsoft.EntityFrameworkCore;
using BackEnd.EngSpik;
using BackEnd.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEnd.services
{
    public class GeneralService
    {
        private readonly DbContext _app;

        public GeneralService(DbContext app)
        {
            _app = app;
        }

        public DbSet<T> GetDbSet<T>() where T : class
        {
            return _app.Set<T>();
        }

        public async Task<ResponseModel<List<T>>> AllAsync<T>(DbSet<T> dbSet) where T : class
        {
            ResponseModel<List<T>> res = new ResponseModel<List<T>>();
            try
            {
                List<T> list = await dbSet.ToListAsync();
                res.ErrorCode = 0;
                res.Data = list;
            }
            catch (Exception e)
            {
                res.ErrorCode = -1;
                res.ErrorMessage = e.Message;
            }
            return res;
        }

        public async Task<ResponseModel<T>> GetByIdAsync<T>(uint id, DbSet<T> dbSet) where T : class
        {
            ResponseModel<T> res = new ResponseModel<T>();
            try
            {
                T t = await dbSet.FindAsync(id);
                res.ErrorCode = 0;
                res.Data = t;
            }
            catch (Exception e)
            {
                res.ErrorCode = -1;
                res.ErrorMessage = e.Message;
            }
            return res;
        }

        public async Task<ResponseModel<T>> CreateAsync<T>(DbSet<T> dbSet, T t) where T : class
        {
            ResponseModel<T> res = new ResponseModel<T>();
            try
            {
                await dbSet.AddAsync(t);
                _app.SaveChanges();
                res.ErrorCode = 0;
                res.Data = t;
            }
            catch (Exception e)
            {
                res.ErrorCode = -1;
                res.ErrorMessage = e.Message;
            }
            return res;
        }

        public async Task<ResponseModel<T>> UpdateAsync<T>(DbSet<T> dbSet, T t, uint id) where T : class
        {
            ResponseModel<T> res = new ResponseModel<T>();
            try
            {
                T _t = await dbSet.FindAsync(id);
                if (_t == null)
                {
                    res.ErrorCode = -1;
                    res.ErrorMessage = id + " not found!";
                }
                else
                {
                    dbSet.Update(t);
                    await _app.SaveChangesAsync();
                    res.ErrorCode = 0;
                    res.Data = t;
                }
            }
            catch (Exception e)
            {
                res.ErrorCode = -1;
                res.ErrorMessage = e.Message;
            }
            return res;
        }

        public async Task<ResponseModel<T>> DeleteAsync<T>(DbSet<T> dbSet, uint id) where T : class
        {
            ResponseModel<T> res = new ResponseModel<T>();
            try
            {
                T t = await dbSet.FindAsync(id);
                if (t == null)
                {
                    res.ErrorCode = -1;
                    res.ErrorMessage = id + " not found!";
                }
                else
                {
                    res.ErrorCode = 0;
                    res.Data = null;
                }
            }
            catch (Exception e)
            {
                res.ErrorCode = -1;
                res.ErrorMessage = e.Message;
            }
            return res;
        }
    }
}

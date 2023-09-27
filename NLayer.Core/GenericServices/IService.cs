using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.GenericServices
{
    public interface IService<T> where T : class
    {
        
        Task<T> GetByIdAsync(int id);

        Task<IEnumerable<T>> GetAllAsync();//IQUERYABLE İLE DİREKT DATABASEYE GİRMEDEN SORGULARI YAPABİLECEĞİMİZ FONKSİYON
       
        IQueryable<T> Where(Expression<Func<T, bool>> expression);//DB 
       
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
       
        Task<T> AddAsync(T entity);
       
        Task <IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);
        //IgENERCİ rEPOSİTORY DEKİ BİLGİLER VAR ANCAK DÖNÜŞ TİPLERİNDE FARKLILIKLAR VAR OZELLİKLE UPDATE DELETE METOTLARINDA
        Task UpdateAsync(T entity);
       
        Task RemoveAsync(T entity);
       
        Task RemoveRangeAsync(IEnumerable<T> entities);
    }
}


using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess//core katmanı diğer katmanlarını referans almamalı
{
    //generic constraint-generic kısıt class:referans tip olabilir
    //herhangi bir class olamasın
    //new(): new'lenebilir olmalı (soyut nesne olmamalı)
    public interface IEntityRepository<T> where T:class,IEntity ,new()
    {
        //Bu kodlar T'ye ne gönderirsek (category,product) ona göre çalışacak
        List<T> GetAll(Expression<Func<T,bool>> filter=null);
        //categoriye göre getir ya da ürün fiyatına göre getir gibi filtreler yazabilmemizi sağlar.
        T Get(Expression<Func<T, bool>> filter);//null filtre vermeyedebiliriz anlamında
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);

        
    }
}

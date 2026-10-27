using Project.DAL.Database;
using Project.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.DAL.Repository
{
    public class GenericRepository<T> where T : class //statt Brands schreibe wir jetzt T für "Generic", T muss als Class definiert werden
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public T GetEntity(int Id) //IActionResult gehört zu Controller, deswegen Brand return
        {
            var entity = context.Set<T>().Find(Id);
            return entity;
        }

        public List<T> GetAllEntities() //Hier wird eine Liste von Brand zurüchgegeben
        {
            var entities = context.Set<T>().ToList();
            return entities;
        }

        public void RemoveEntity(int Id)
        {
            var entity = context.Set<T>().Find(Id);
            context.Set<T>().Remove(entity);
            context.SaveChanges();
        }

        public void CreateEntity(T request)
        {
            context.Set<T>().Add(request);
            context.SaveChanges();
        }
    }
}
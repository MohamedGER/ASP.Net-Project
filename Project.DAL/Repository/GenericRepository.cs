using Project.DAL.Database;
using Project.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.DAL.Repository
{
    public class GenericRepository<T> where T : class //statt Brands schreibe wir jetzt T für "Generic", T muss als Class definiert werden
    {
        private readonly ApplicationDbContext _context;
        
        public GenericRepository(ApplicationDbContext context) //Konstruktor für "ApplicationDbContext context = new ApplicationDbContext();"
        {
            _context = context;
        }

        public T GetEntity(int Id) //IActionResult gehört zu Controller, deswegen Brand return
        {
            var entity = _context.Set<T>().Find(Id);
            return entity;
        }

        public List<T> GetAllEntities() //Hier wird eine Liste von Brand zurüchgegeben
        {
            var entities = _context.Set<T>().ToList();
            return entities;
        }

        public void RemoveEntity(int Id)
        {
            var entity = _context.Set<T>().Find(Id);
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public void CreateEntity(T request)
        {
            _context.Set<T>().Add(request);
            _context.SaveChanges();
        }
    }
}
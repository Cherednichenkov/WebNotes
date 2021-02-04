using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApplicatioNotes.Models
{
    public class NotesRepository
    {
        //класс-репозиторий напрямую обращается к контексту базы данных
        private readonly AppDatabaseContext context;
        public NotesRepository(AppDatabaseContext context)
        {
            this.context = context;
        }

        //выбрать все записи из таблицы
        public IQueryable<Note> GetNotes()
        {
            return context.Notes.OrderBy(o => o.Name);
        }

        //найти определенную запись по id
        public Note GetNoteById(int id)
        {
            return context.Notes.Single(o => o.Id == id);
        }

        //сохранить новую либо обновить существующую запись в БД
        public int SaveNote(Note entity)
        {
            if (entity.Id == default)
            {
                entity.Date = DateTime.Now;
                context.Notes.Add(entity);
              //  context.Entry(entity).State = EntityState.Added;
            }
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();

            return entity.Id;
        }

        //удалить существующую запись
        public void DeleteNote(Note entity)
        {
            context.Notes.Remove(entity);
            context.SaveChanges();
        }
    }
}

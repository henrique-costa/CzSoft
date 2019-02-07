using System.Collections.Generic;
using CzSoft.Core;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CzSoft.Data
{
    public class SqlProjectData : IProjectData
    {
        private readonly CzSoftDbContext db;

        public SqlProjectData(CzSoftDbContext db)
        {
            this.db = db;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public Project Create(Project newProject)
        {
            db.Add(newProject);
            return newProject;
        }

        public Project Delete(int id)
        {
            var project = GetById(id);
            if (project != null)
            {
                db.Projects.Remove(project);
            }
            return project;
        }

        public Project GetById(int id)
        {
            return db.Projects.Find(id);
        }

        public IEnumerable<Project> GetProjectByName(string name)
        {
            var query = from p in db.Projects
                        where p.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby p.Name
                        select p;

            return query;
        }

        public Project Update(Project updatedProject)
        {
            var entity = db.Projects.Attach(updatedProject);
            entity.State = EntityState.Modified;
            return updatedProject;
        }
    }
}

using CzSoft.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CzSoft.Data
{
    public class InMemoryProjectData : IProjectData
    {
        List<Project> projects;

        public InMemoryProjectData()
        {
            projects = new List<Project>()
            {
                new Project{ Id = 1, Name = "ProjectName1",
                    Description = "Description1 Description1 Description1 Description1 Description1 Description1", CreationDate =  DateTime.Now.ToShortDateString(),
                Type = ProjectType.Flyer },

                new Project{ Id = 2, Name = "ProjectName2",
                    Description = "Description2 Description2 Description2 Description2 Description2 Description2",
                    CreationDate =  DateTime.Now.ToShortDateString(),
                Type = ProjectType.MediaDigital },

                new Project{ Id = 3, Name = "ProjectName3",
                    Description = "Description3 Description3 Description3 Description3 Description3 Description3",
                    CreationDate =  DateTime.Now.ToShortDateString(),
                Type = ProjectType.Tipo4 },

                new Project{ Id = 4, Name = "ProjectName4",
                    Description = "Description4 Description4 Description4 Description4 Description4 Description4",
                    CreationDate =  DateTime.Now.ToShortDateString(),
                Type = ProjectType.Tipo5 },

                new Project{ Id = 5, Name = "ProjectName5",
                    Description = "Description5 Description5 Description5 Description5 Description5 Description5",
                    CreationDate =  DateTime.Now.ToShortDateString(),
                Type = ProjectType.Tipo6 }

            };
        }

        public int Commit()
        {
            return 0;
        }

        public Project Create(Project newProject)
        {
            projects.Add(newProject);
            newProject.Id = projects.Max(r => r.Id) + 1;
            newProject.CreationDate = DateTime.Now.ToShortDateString();
            return newProject; 
        }

        public Project Delete(int id)
        {
            var project = projects.FirstOrDefault(r => r.Id == id);
            if (project != null)
            {
                projects.Remove(project);
            }
            return project;
        }

        public Project GetById(int id)
        {
            return projects.SingleOrDefault(p => p.Id == id);
        }


        public IEnumerable<Project> GetProjectByName(string name = null)
        {
            return from r in projects
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }

        public Project Update(Project updatedProject)
        {
            var project = projects.SingleOrDefault(r => r.Id == updatedProject.Id);
            if (project != null)
            {
                project.Name = updatedProject.Name;
                project.Description = updatedProject.Description;
                project.Type = updatedProject.Type;
            }
            return project;
        }
    }
}

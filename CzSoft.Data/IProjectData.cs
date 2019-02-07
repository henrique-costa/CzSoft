using CzSoft.Core;
using System.Collections.Generic;
using System.Text;

namespace CzSoft.Data
{
    public interface IProjectData
    {
        IEnumerable<Project> GetProjectByName(string name);
        Project GetById(int id);
        Project Update(Project updatedProject);
        int Commit();
        Project Delete(int id);
        Project Create(Project newProject);
    }
}

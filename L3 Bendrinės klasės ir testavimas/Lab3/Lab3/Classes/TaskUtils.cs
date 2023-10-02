using System;
using System.Collections.Generic;

namespace Lab3.Classes
{
    public static class TaskUtils
    {
        /// <summary>
        /// Finds all active projects
        /// </summary>
        /// <param name="Students">List of all student objects</param>
        /// <returns>List of all active projects</returns>
        public static List<string> FindAllActiveProjects(LinkList<Student> Students)
        {
            List<string> Projects = new List<string>();

            foreach (var item in Students)
            {
                if (!Projects.Contains(item.ProjectName))
                {
                    Projects.Add(item.ProjectName);
                }
            }


            return Projects;
        }

        /// <summary>
        /// Finds all inactive projects
        /// </summary>
        /// <param name="Projects">List of all projects</param>
        /// <param name="ActiveProjects">List of all active projects</param>
        /// <returns>List of all inactive projects</returns>
        public static List<string> FindInactiveProjects(LinkList<Project> Projects, List<string> ActiveProjects)
        {
            List<string> projects = new List<string>();

            foreach (var project in Projects)
            {
                if (!ActiveProjects.Contains(project.Name))
                {
                    projects.Add(project.Name);
                }
            }

            return projects;
        }

        /// <summary>
        /// Gets all active proffesors
        /// </summary>
        /// <param name="Projects">List of all projects</param>
        /// <param name="InactiveProjects">List of all inactive projects</param>
        /// <returns></returns>
        public static LinkList<Project> GetAllActiveProffesors(LinkList<Project> Projects, List<string> InactiveProjects)
        {
            LinkList<Project> Proffesors = new LinkList<Project>();
            List<string> proffName = new List<string>();

            foreach (var project in Projects)
            {
                string tempProffesor = String.Format("{0} {1}", project.ProfSurname, project.ProfName);

                if (!InactiveProjects.Contains(project.Name) && !proffName.Contains(tempProffesor))
                {
                    proffName.Add(tempProffesor);
                    Proffesors.Add(project);
                }
            }

            return Proffesors;
        }

        /// <summary>
        /// Finds the proffesor with most projects
        /// </summary>
        /// <param name="Projects">List of all projects</param>
        /// <returns>Returns the proffesors name</returns>
        public static string MostProjects(LinkList<Project> Projects)
        {

            List<String> Proffesors = new List<string>();
            string Proffesor = "";
            int count = -1;

            foreach (var project in Projects)
            {
                string tempProffesor;
                tempProffesor = String.Format("{0} {1}", project.ProfSurname, project.ProfName);
                Proffesors.Add(tempProffesor);
            }

            for (int i = 0; i < Proffesors.Count; i++)
            {
                int tempcount = -1;
                string tempProffesor = Proffesors[i];
                for (int j = 0; j < Proffesors.Count; j++)
                {
                    string jProffesor = Proffesors[j];
                    if (tempProffesor == jProffesor)
                    {
                        tempcount++;
                    }
                }

                if (tempcount > count)
                {
                    Proffesor = tempProffesor;
                    count = tempcount;
                }
            }

            return Proffesor;
        }
        /// <summary>
        /// Gets all project names by <paramref name="proffesor"/> name and surname
        /// </summary>
        /// <param name="proffesor">Proffesor surname and name</param>
        /// <param name="Projects">List of all projects</param>
        /// <returns></returns>
        public static List<string> GetProjectsByProffesor(string proffesor, LinkList<Project> Projects)
        {
            string[] profSplit = proffesor.Split(' ');
            string proffSurname = profSplit[0];
            string proffName = profSplit[1];

            List<string> ProjectNames = new List<string>();

            foreach (var project in Projects)
            {
                if (project.ProfName == proffName && project.ProfSurname == proffSurname)
                {
                    ProjectNames.Add(project.Name);
                }
            }

            return ProjectNames;
        }
    }
}
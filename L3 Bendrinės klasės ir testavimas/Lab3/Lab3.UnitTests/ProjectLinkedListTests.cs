using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab3.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Tests
{
    [TestClass]
    public class ProjectLinkedListTests
    {
        [TestMethod]
        public void Sort_AlreadySortedList_ListUnchanged()
        {
            // Arrange
            var list = new LinkList<Project>();
            var changed = new LinkList<Project>();
            list.Add(new Project("Rekursija", "Jusas", "Vacius", 20));
            list.Add(new Project("Polimorfizmas", "Jančiukas", "Mindaugas", 21));
            list.Add(new Project("Deklaratyvusis programavimas", "Giedrius", "Ziberkas", 22));
            list.Add(new Project("Susietasis sąrašas", "Burbaitė", "Renata", 25));

            changed = list;

            // Act

            changed.Sort();

            List<string> SortedListString = new List<string>();
            List<string> UnsortedListString = new List<string>();

            foreach (Project project in list)
            {
                SortedListString.Add(string.Format("| {0,-35} | {1,-20} | {2,-20} | {3,10} |", project.Name, project.ProfSurname, project.ProfName, project.GivenTime));
            }

            foreach (Project project in changed)
            {
                UnsortedListString.Add(string.Format("| {0,-35} | {1,-20} | {2,-20} | {3,10} |", project.Name, project.ProfSurname, project.ProfName, project.GivenTime));
            }

            // Assert
            Assert.IsTrue(SortedListString.SequenceEqual(UnsortedListString));
        }

        [TestMethod]
        public void Sort_UnsortedList_ListSortedCorrectly()
        {
            // Arrange
            var sortedList = new LinkList<Project>();
            sortedList.Add(new Project("Susietasis sąrašas", "Burbaitė", "Renata", 25));
            sortedList.Add(new Project("Deklaratyvusis programavimas", "Giedrius", "Ziberkas", 22));
            sortedList.Add(new Project("Polimorfizmas", "Jančiukas", "Mindaugas", 21));
            sortedList.Add(new Project("Rekursija", "Jusas", "Vacius", 20));

            var unsortedList = new LinkList<Project>();
            unsortedList.Add(new Project("Rekursija", "Jusas", "Vacius", 20));
            unsortedList.Add(new Project("Susietasis sąrašas", "Burbaitė", "Renata", 25));
            unsortedList.Add(new Project("Polimorfizmas", "Jančiukas", "Mindaugas", 21));
            unsortedList.Add(new Project("Deklaratyvusis programavimas", "Giedrius", "Ziberkas", 22));

            List<string> SortedListString = new List<string>();
            List<string> UnsortedListString = new List<string>();

            // Act

            unsortedList.Sort();

            foreach (Project project in sortedList)
            {
                SortedListString.Add(string.Format("| {0,-35} | {1,-20} | {2,-20} | {3,10} |", project.Name, project.ProfSurname, project.ProfName, project.GivenTime));
            }

            foreach (Project project in unsortedList)
            {
                UnsortedListString.Add(string.Format("| {0,-35} | {1,-20} | {2,-20} | {3,10} |", project.Name, project.ProfSurname, project.ProfName, project.GivenTime));
            }

            // Assert
            Assert.IsTrue(SortedListString.SequenceEqual(UnsortedListString));
        }
    }
}
